﻿
namespace Polycode.NostalgicPlayer.Agent.Output.CoreAudioSettings
{
	partial class SettingsControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.deviceLabel = new Krypton.Toolkit.KryptonLabel();
			this.fontPalette = new Polycode.NostalgicPlayer.GuiKit.Components.FontPalette(this.components);
			this.controlResource = new Polycode.NostalgicPlayer.GuiKit.Designer.ControlResource();
			this.deviceComboBox = new Krypton.Toolkit.KryptonComboBox();
			((System.ComponentModel.ISupportInitialize)(this.controlResource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deviceComboBox)).BeginInit();
			this.SuspendLayout();
			// 
			// deviceLabel
			// 
			this.deviceLabel.Location = new System.Drawing.Point(0, 22);
			this.deviceLabel.Name = "deviceLabel";
			this.deviceLabel.Palette = this.fontPalette;
			this.deviceLabel.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
			this.controlResource.SetResourceKey(this.deviceLabel, "IDS_SETTINGS_DEVICE");
			this.deviceLabel.Size = new System.Drawing.Size(78, 16);
			this.deviceLabel.TabIndex = 0;
			this.deviceLabel.Values.Text = "Output device";
			// 
			// controlResource
			// 
			this.controlResource.ResourceClassName = "Polycode.NostalgicPlayer.Agent.Output.CoreAudioSettings.Resources";
			// 
			// deviceComboBox
			// 
			this.deviceComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.deviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.deviceComboBox.DropDownWidth = 305;
			this.deviceComboBox.IntegralHeight = false;
			this.deviceComboBox.Location = new System.Drawing.Point(87, 21);
			this.deviceComboBox.Name = "deviceComboBox";
			this.deviceComboBox.Palette = this.fontPalette;
			this.deviceComboBox.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
			this.controlResource.SetResourceKey(this.deviceComboBox, null);
			this.deviceComboBox.Size = new System.Drawing.Size(305, 18);
			this.deviceComboBox.TabIndex = 1;
			// 
			// SettingsControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.deviceComboBox);
			this.Controls.Add(this.deviceLabel);
			this.MinimumSize = new System.Drawing.Size(400, 62);
			this.Name = "SettingsControl";
			this.controlResource.SetResourceKey(this, null);
			this.Size = new System.Drawing.Size(400, 62);
			((System.ComponentModel.ISupportInitialize)(this.controlResource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deviceComboBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Krypton.Toolkit.KryptonLabel deviceLabel;
		private GuiKit.Designer.ControlResource controlResource;
		private Krypton.Toolkit.KryptonComboBox deviceComboBox;
		private GuiKit.Components.FontPalette fontPalette;
	}
}
