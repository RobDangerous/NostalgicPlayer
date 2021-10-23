﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/*                                                                            */
/* Copyright (C) 2021 by Polycode / NostalgicPlayer team.                     */
/* All rights reserved.                                                       */
/******************************************************************************/
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Polycode.NostalgicPlayer.Agent.Player.SidPlay.LibSidPlayFp.C64.Cia
{
	/// <summary>
	/// TOD implementation taken from Vice
	/// </summary>
	internal class Tod
	{
		private const int TENTHS = 0;
		private const int SECONDS = 1;
		private const int MINUTES = 2;
		private const int HOURS = 3;

		#region Private implementation of Event
		private class PrivateEvent : Event
		{
			private readonly Tod parent;

			/********************************************************************/
			/// <summary>
			/// Constructor
			/// </summary>
			/********************************************************************/
			public PrivateEvent(string name, Tod parent) : base(name)
			{
				this.parent = parent;
			}



			/********************************************************************/
			/// <summary>
			/// 
			/// </summary>
			/********************************************************************/
			public override void DoEvent()
			{
				parent.cycles += parent.period;

				// Fixed precision 25.7
				parent.eventScheduler.Schedule(this, (uint)(parent.cycles >> 7));
				parent.cycles &= 0x7f;	// Just keep the decimal part

				if (!parent.isStopped)
				{
					// Count 50/60 hz ticks
					parent.todTickCounter++;

					// Wild assumption: counter is 3 bits and is not reset elsewhere
					// FIXME: this doesn't seem to be 100% correct - apparently it is reset
					//        in some cases
					parent.todTickCounter &= 7;

					// If the counter matches the TOD frequency ...
					if (parent.todTickCounter == ((parent.regs[Mos652x.CRA] & 0x80) != 0 ? 5 : 6))
					{
						// Reset the counter and update the timer
						parent.todTickCounter = 0;
						parent.UpdateCounters();
					}
				}
			}
		}
		#endregion

		private readonly PrivateEvent eventObject;

		/// <summary>
		/// Event scheduler
		/// </summary>
		private readonly EventScheduler eventScheduler;

		/// <summary>
		/// Pointer to the MOS6526 which this Timer belongs to
		/// </summary>
		private Mos652x parent;

		private readonly uint8_t[] regs;

		private event_clock_t cycles;
		private event_clock_t period;

		private uint todTickCounter;

		private bool isLatched;
		private bool isStopped;

		private readonly uint8_t[] clock = new uint8_t[4];
		private readonly uint8_t[] latch = new uint8_t[4];
		private readonly uint8_t[] alarm = new uint8_t[4];

		/********************************************************************/
		/// <summary>
		/// Constructor
		/// </summary>
		/********************************************************************/
		public Tod(EventScheduler scheduler, Mos652x parent, uint8_t[] regs)
		{
			eventObject = new PrivateEvent("CIA Time of Day", this);
			eventScheduler = scheduler;
			this.parent = parent;
			this.regs = regs;
			period = ~0;		// Dummy
			todTickCounter = 0;
		}



		/********************************************************************/
		/// <summary>
		/// Reset TOD
		/// </summary>
		/********************************************************************/
		public void Reset()
		{
			cycles = 0;
			todTickCounter = 0;

			Array.Clear(clock, 0, clock.Length);
			clock[HOURS] = 1;	// The most common value
			Array.Copy(clock, latch, latch.Length);
			Array.Clear(alarm, 0, alarm.Length);

			isLatched = false;
			isStopped = true;

			eventScheduler.Schedule(eventObject, 0, EventScheduler.event_phase_t.EVENT_CLOCK_PHI1);
		}



		/********************************************************************/
		/// <summary>
		/// Read TOD register
		/// </summary>
		/********************************************************************/
		public uint8_t Read(uint_least8_t reg)
		{
			// TOD clock is latched by reading Hours, and released
			// upon reading Tenths of Seconds. The counter itself
			// keeps ticking all the time.
			// Also note that this latching is different from the input one
			if (!isLatched)
				Array.Copy(clock, latch, latch.Length);

			if (reg == TENTHS)
				isLatched = false;
			else if (reg == HOURS)
				isLatched = true;

			return latch[reg];
		}



		/********************************************************************/
		/// <summary>
		/// Write TOD register
		/// </summary>
		/********************************************************************/
		public void Write(uint_least8_t reg, uint8_t data)
		{
			switch (reg)
			{
				// Time of Day clock 1/10 s
				case TENTHS:
				{
					data &= 0x0f;
					break;
				}

				// Time of Day clock sec
				case SECONDS:
				{
					goto case MINUTES;
				}

				// Time of Day clock min
				case MINUTES:
				{
					data &= 0x7f;
					break;
				}

				// Time of Day clock hour
				case HOURS:
				{
					// Force bits 6-5 = 0
					data &= 0x9f;

					// Flip AM/PM on hour 12
					// Flip AM/PM only when writing time, not when writing alarm
					if (((data & 0x1f) == 0x12) && ((regs[0x0f] & 0x80) == 0))
						data ^= 0x80;

					break;
				}
			}

			bool changed = false;
			if ((regs[0x0f] & 0x80) != 0)
			{
				// Set alarm
				if (alarm[reg] != data)
				{
					changed = true;
					alarm[reg] = data;
				}
			}
			else
			{
				// Set time
				if (reg == TENTHS)
				{
					// Apparently the tick counter is reset to 0 when the clock
					// is not running and then restarted by writing to the 10th
					// seconds register
					if (isStopped)
					{
						todTickCounter = 0;
						isStopped = false;
					}
				}
				else if (reg == HOURS)
					isStopped = true;

				if (clock[reg] != data)
				{
					changed = true;
					clock[reg] = data;
				}
			}

			// Check alarm
			if (changed)
				CheckAlarm();
		}



		/********************************************************************/
		/// <summary>
		/// Set TOD period
		/// </summary>
		/********************************************************************/
		public void SetPeriod(event_clock_t clock)
		{
			period = clock * (1 << 7);
		}

		#region Private methods
		/********************************************************************/
		/// <summary>
		/// 
		/// </summary>
		/********************************************************************/
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateCounters()
		{
			// Advance the counters
			// - individual counters are all 4 bit
			uint8_t t0 = (uint8_t)(clock[TENTHS] & 0x0f);
			uint8_t t1 = (uint8_t)(clock[SECONDS] & 0x0f);
			uint8_t t2 = (uint8_t)((clock[SECONDS] >> 4) & 0x0f);
			uint8_t t3 = (uint8_t)(clock[MINUTES] & 0x0f);
			uint8_t t4 = (uint8_t)((clock[MINUTES] >> 4) & 0x0f);
			uint8_t t5 = (uint8_t)(clock[HOURS] & 0x0f);
			uint8_t t6 = (uint8_t)((clock[HOURS] >> 4) & 0x0f);
			uint8_t pm = (uint8_t)(clock[HOURS] & 0x80);

			// Tenth seconds (0-9)
			t0 = (uint8_t)((t0 + 1) & 0x0f);
			if (t0 == 10)
			{
				t0 = 0;

				// Seconds (0-59)
				t1 = (uint8_t)((t1 + 1) & 0x0f);	// x0...x9
				if (t1 == 10)
				{
					t1 = 0;
					t2 = (uint8_t)((t2 + 1) & 0x07);	// 0x...5x
					if (t2 == 6)
					{
						t2 = 0;

						// Minutes (0-59)
						t3 = (uint8_t)((t3 + 1) & 0x0f);	// x0...x9
						if (t3 == 10)
						{
							t3 = 0;
							t4 = (uint8_t)((t4 + 1) & 0x07);	// 0x...5x
							if (t4 == 6)
							{
								t4 = 0;

								// Hours (1-12)
								t5 = (uint8_t)((t5 + 1) & 0x0f);
								if (t6 != 0)
								{
									// Toggle the am/pm flag when going from 11 to 12 (!)
									if (t5 == 2)
										pm ^= 0x80;
									else if (t5 == 3)	// Wrap 12h -> 1h (FIXME: when hour became x3?)
									{
										t5 = 1;
										t6 = 0;
									}
								}
								else
								{
									if (t5 == 10)
									{
										t5 = 0;
										t6 = 1;
									}
								}
							}
						}
					}
				}
			}

			clock[TENTHS] = t0;
			clock[SECONDS] = (uint8_t)(t1 | (t2 << 4));
			clock[MINUTES] = (uint8_t)(t3 | (t4 << 4));
			clock[HOURS] = (uint8_t)(t5 | (t6 << 4) | pm);

			CheckAlarm();
		}



		/********************************************************************/
		/// <summary>
		/// 
		/// </summary>
		/********************************************************************/
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckAlarm()
		{
			if (clock.SequenceEqual(alarm))
				parent.TodInterrupt();
		}
		#endregion
	}
}
