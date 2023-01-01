﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/******************************************************************************/
namespace Polycode.NostalgicPlayer.Agent.Player.ModTracker
{
	/// <summary>
	/// Different tables needed
	/// </summary>
	internal static class Tables
	{
		/********************************************************************/
		/// <summary>
		/// Periods
		/// </summary>
		/********************************************************************/
		public static readonly ushort[,] Periods =
		{
			// Tuning 0, normal
			{
				3424, 3232, 3048, 2880, 2712, 2560, 2416, 2280, 2152, 2032, 1920, 1812,
				1712, 1616, 1524, 1440, 1356, 1280, 1208, 1140, 1076, 1016,  960,  906,
				 856,  808,  762,  720,  678,  640,  604,  570,  538,  508,  480,  453,
				 428,  404,  381,  360,  339,  320,  302,  285,  269,  254,  240,  226,
				 214,  202,  190,  180,  170,  160,  151,  143,  135,  127,  120,  113,
				 107,  101,   95,   90,   85,   80,   75,   71,   67,   63,   60,   56,
				  53,   50,   47,   45,   42,   40,   37,   35,   33,   31,   30,   28
			},

			// Tuning 1
			{
				3400, 3208, 3028, 2860, 2696, 2548, 2404, 2268, 2140, 2020, 1908, 1800,
				1700, 1604, 1514, 1430, 1348, 1274, 1202, 1134, 1070, 1010,  954,  900,
				 850,  802,  757,  715,  674,  637,  601,  567,  535,  505,  477,  450,
				 425,  401,  379,  357,  337,  318,  300,  284,  268,  253,  239,  225,
				 213,  201,  189,  179,  169,  159,  150,  142,  134,  126,  119,  113,
				 106,  100,   94,   89,   84,   79,   75,   71,   67,   63,   59,   56,
				  53,   50,   47,   44,   42,   39,   37,   35,   33,   31,   29,   28
			},

			// Tuning 2
			{
				3376, 3184, 3008, 2836, 2680, 2528, 2388, 2252, 2128, 2008, 1896, 1788,
				1688, 1592, 1504, 1418, 1340, 1264, 1194, 1126, 1064, 1004,  948,  894,
				 844,  796,  752,  709,  670,  632,  597,  563,  532,  502,  474,  447,
				 422,  398,  376,  355,  335,  316,  298,  282,  266,  251,  237,  224,
				 211,  199,  188,  177,  167,  158,  149,  141,  133,  125,  118,  112,
				 105,   99,   94,   88,   83,   79,   74,   70,   66,   62,   59,   56,
				  52,   49,   47,   44,   41,   39,   37,   35,   33,   31,   29,   28
			},

			// Tuning 3
			{
				3352, 3164, 2984, 2816, 2660, 2512, 2368, 2236, 2112, 1992, 1880, 1776,
				1676, 1582, 1492, 1408, 1330, 1256, 1184, 1118, 1056,  996,  940,  888,
				 838,  791,  746,  704,  665,  628,  592,  559,  528,  498,  470,  444,
				 419,  395,  373,  352,  332,  314,  296,  280,  264,  249,  235,  222,
				 209,  198,  187,  176,  166,  157,  148,  140,  132,  125,  118,  111,
				 104,   99,   93,   88,   83,   78,   74,   70,   66,   62,   59,   55,
				  52,   49,   46,   44,   41,   39,   37,   35,   33,   31,   29,   27
			},

			// Tuning 4
			{
				3328, 3140, 2964, 2796, 2640, 2492, 2352, 2220, 2096, 1980, 1868, 1764,
				1664, 1570, 1482, 1398, 1320, 1246, 1176, 1110, 1048,  990,  934,  882,
				 832,  785,  741,  699,  660,  623,  588,  555,  524,  495,  467,  441,
				 416,  392,  370,  350,  330,  312,  294,  278,  262,  247,  233,  220,
				 208,  196,  185,  175,  165,  156,  147,  139,  131,  124,  117,  110,
				 104,   98,   92,   87,   82,   78,   73,   69,   65,   62,   58,   55,
				  52,   49,   46,   43,   41,   39,   36,   34,   32,   31,   29,   27
			},

			// Tuning 5
			{
				3304, 3116, 2944, 2776, 2620, 2476, 2336, 2204, 2080, 1964, 1852, 1748,
				1652, 1558, 1472, 1388, 1310, 1238, 1168, 1102, 1040,  982,  926,  874,
				 826,  779,  736,  694,  655,  619,  584,  551,  520,  491,  463,  437,
				 413,  390,  368,  347,  328,  309,  292,  276,  260,  245,  232,  219,
				 206,  195,  184,  174,  164,  155,  146,  138,  130,  123,  116,  109,
				 103,   97,   92,   87,   82,   77,   73,   69,   65,   61,   58,   54,
				  51,   48,   46,   43,   41,   38,   36,   34,   32,   30,   29,   27
			},

			// Tuning 6
			{
				3280, 3096, 2920, 2756, 2604, 2456, 2320, 2188, 2064, 1948, 1840, 1736,
				1640, 1548, 1460, 1378, 1302, 1228, 1160, 1094, 1032,  974,  920,  868,
				 820,  774,  730,  689,  651,  614,  580,  547,  516,  487,  460,  434,
				 410,  387,  365,  345,  325,  307,  290,  274,  258,  244,  230,  217,
				 205,  193,  183,  172,  163,  154,  145,  137,  129,  122,  115,  109,
				 102,   96,   91,   86,   81,   77,   72,   68,   64,   61,   57,   54,
				  51,   48,   45,   43,   40,   38,   36,   34,   32,   30,   28,   27
			},

			// Tuning 7
			{
				3256, 3072, 2900, 2736, 2584, 2440, 2300, 2172, 2052, 1936, 1828, 1724,
				1628, 1536, 1450, 1368, 1292, 1220, 1150, 1086, 1026,  968,  914,  862,
				 814,  768,  725,  684,  646,  610,  575,  543,  513,  484,  457,  431,
				 407,  384,  363,  342,  323,  305,  288,  272,  256,  242,  228,  216,
				 204,  192,  181,  171,  161,  152,  144,  136,  128,  121,  114,  108,
				 102,   96,   90,   85,   80,   76,   72,   68,   64,   60,   57,   54,
				  51,   48,   45,   42,   40,   38,   36,   34,   32,   30,   28,   27
			},

			// Tuning -8
			{
				3628, 3424, 3232, 3048, 2880, 2712, 2560, 2416, 2280, 2152, 2032, 1920,
				1814, 1712, 1616, 1524, 1440, 1356, 1280, 1208, 1140, 1076, 1016,  960,
				 907,  856,  808,  762,  720,  678,  640,  604,  570,  538,  508,  480,
				 453,  428,  404,  381,  360,  339,  320,  302,  285,  269,  254,  240,
				 226,  214,  202,  190,  180,  170,  160,  151,  143,  135,  127,  120,
				 113,  107,  101,   95,   90,   85,   80,   75,   71,   67,   63,   60,
				  56,   53,   50,   47,   45,   42,   40,   37,   35,   33,   31,   30
			},

			// Tuning -7
			{
				3600, 3400, 3208, 3028, 2860, 2700, 2544, 2404, 2268, 2140, 2020, 1908,
				1800, 1700, 1604, 1514, 1430, 1350, 1272, 1202, 1134, 1070, 1010,  954,
				 900,  850,  802,  757,  715,  675,  636,  601,  567,  535,  505,  477,
				 450,  425,  401,  379,  357,  337,  318,  300,  284,  268,  253,  238,
				 225,  212,  200,  189,  179,  169,  159,  150,  142,  134,  126,  119,
				 112,  106,  100,   94,   89,   84,   79,   75,   71,   67,   63,   59,
				  56,   53,   50,   47,   44,   42,   39,   37,   35,   33,   31,   29
			},

			// Tuning -6
			{
				3576, 3376, 3184, 3008, 2836, 2680, 2528, 2388, 2252, 2128, 2008, 1896,
				1788, 1688, 1592, 1504, 1418, 1340, 1264, 1194, 1126, 1064, 1004,  948,
				 894,  844,  796,  752,  709,  670,  632,  597,  563,  532,  502,  474,
				 447,  422,  398,  376,  355,  335,  316,  298,  282,  266,  251,  237,
				 223,  211,  199,  188,  177,  167,  158,  149,  141,  133,  125,  118,
				 112,  105,   99,   94,   88,   83,   79,   74,   70,   66,   62,   59,
				  55,   52,   49,   47,   44,   41,   39,   37,   35,   33,   31,   29
			},

			// Tuning -5
			{
				3548, 3352, 3164, 2984, 2816, 2660, 2512, 2368, 2236, 2112, 1992, 1880,
				1774, 1676, 1582, 1492, 1408, 1330, 1256, 1184, 1118, 1056,  996,  940,
				 887,  838,  791,  746,  704,  665,  628,  592,  559,  528,  498,  470,
				 444,  419,  395,  373,  352,  332,  314,  296,  280,  264,  249,  235,
				 222,  209,  198,  187,  176,  166,  157,  148,  140,  132,  125,  118,
				 111,  104,   99,   93,   88,   83,   78,   74,   70,   66,   62,   59,
				  55,   52,   49,   46,   44,   41,   39,   37,   35,   33,   31,   29
			},

			// Tuning -4
			{
				3524, 3328, 3140, 2964, 2796, 2640, 2492, 2352, 2220, 2096, 1976, 1868,
				1762, 1664, 1570, 1482, 1398, 1320, 1246, 1176, 1110, 1048,  988,  934,
				 881,  832,  785,  741,  699,  660,  623,  588,  555,  524,  494,  467,
				 441,  416,  392,  370,  350,  330,  312,  294,  278,  262,  247,  233,
				 220,  208,  196,  185,  175,  165,  156,  147,  139,  131,  123,  117,
				 110,  104,   98,   92,   87,   82,   78,   73,   69,   65,   61,   58,
				  55,   52,   49,   46,   43,   41,   39,   36,   34,   32,   30,   29
			},

			// Tuning -3
			{
				3500, 3304, 3116, 2944, 2776, 2620, 2476, 2336, 2204, 2080, 1964, 1852,
				1750, 1652, 1558, 1472, 1388, 1310, 1238, 1168, 1102, 1040,  982,  926,
				 875,  826,  779,  736,  694,  655,  619,  584,  551,  520,  491,  463,
				 437,  413,  390,  368,  347,  328,  309,  292,  276,  260,  245,  232,
				 219,  206,  195,  184,  174,  164,  155,  146,  138,  130,  123,  116,
				 109,  103,   97,   92,   87,   82,   77,   73,   69,   65,   61,   58,
				  54,   51,   48,   46,   43,   41,   38,   36,   34,   32,   30,   29
			},

			// Tuning -2
			{
				3472, 3280, 3096, 2920, 2756, 2604, 2456, 2320, 2188, 2064, 1948, 1840,
				1736, 1640, 1548, 1460, 1378, 1302, 1228, 1160, 1094, 1032,  974,  920,
				 868,  820,  774,  730,  689,  651,  614,  580,  547,  516,  487,  460,
				 434,  410,  387,  365,  345,  325,  307,  290,  274,  258,  244,  230,
				 217,  205,  193,  183,  172,  163,  154,  145,  137,  129,  122,  115,
				 108,  102,   96,   91,   86,   81,   77,   72,   68,   64,   61,   57,
				  54,   51,   48,   45,   43,   40,   38,   36,   34,   32,   30,   28
			},

			// Tuning -1
			{
				3448, 3256, 3072, 2900, 2736, 2584, 2440, 2300, 2172, 2052, 1936, 1828,
				1724, 1628, 1536, 1450, 1368, 1292, 1220, 1150, 1086, 1026,  968,  914,
				 862,  814,  768,  725,  684,  646,  610,  575,  543,  513,  484,  457,
				 431,  407,  384,  363,  342,  323,  305,  288,  272,  256,  242,  228,
				 216,  203,  192,  181,  171,  161,  152,  144,  136,  128,  121,  114,
				 108,  101,   96,   90,   85,   80,   76,   72,   68,   64,   60,   57,
				  54,   50,   48,   45,   42,   40,   38,   36,   34,   32,   30,   28
			}
		};



		/********************************************************************/
		/// <summary>
		/// Vibrato
		/// </summary>
		/********************************************************************/
		public static readonly byte[] VibratoTable =
		{
			  0,  24,  49,  74,  97, 120, 141, 161,
			180, 197, 212, 224, 235, 244, 250, 253,
			255, 253, 250, 244, 235, 224, 212, 197,
			180, 161, 141, 120,  97,  74,  49,  24
		};



		/********************************************************************/
		/// <summary>
		/// Funk
		/// </summary>
		/********************************************************************/
		public static readonly byte[] FunkTable =
		{
			0, 5, 6, 7, 8, 10, 11, 13, 16, 19, 22, 26, 32, 43, 64, 128
		};



		/********************************************************************/
		/// <summary>
		/// Mega arpeggios
		/// </summary>
		/********************************************************************/
		public static readonly byte[,] MegaArps =
		{
			{ 0, 3, 7, 12, 15, 12, 7, 3, 0, 3, 7, 12, 15, 12, 7, 3 },
			{ 0, 4, 7, 12, 16, 12, 7, 4, 0, 4, 7, 12, 16, 12, 7, 4 },
			{ 0, 3, 8, 12, 15, 12, 8, 3, 0, 3, 8, 12, 15, 12, 8, 3 },
			{ 0, 4, 8, 12, 16, 12, 8, 4, 0, 4, 8, 12, 16, 12, 8, 4 },
			{ 0, 5, 8, 12, 17, 12, 8, 5, 0, 5, 8, 12, 17, 12, 8, 5 },
			{ 0, 5, 9, 12, 17, 12, 9, 5, 0, 5, 9, 12, 17, 12, 9, 5 },
			{ 12, 0, 7, 0, 3, 0, 7, 0, 12, 0, 7, 0, 3, 0, 7, 0 },
			{ 12, 0, 7, 0, 4, 0, 7, 0, 12, 0, 7, 0, 4, 0, 7, 0 },

			{ 0, 3, 7, 3, 7, 12, 7, 12, 15, 12, 7, 12, 7, 3, 7, 3 },
			{ 0, 4, 7, 4, 7, 12, 7, 12, 16, 12, 7, 12, 7, 4, 7, 4 },
			{ 31, 27, 24, 19, 15, 12, 7, 3, 0, 3, 7, 12, 15, 19, 24, 27 },
			{ 31, 28, 24, 19, 16, 12, 7, 4, 0, 4, 7, 12, 16, 19 ,24, 28 },
			{ 0, 12, 0, 12, 0, 12, 0, 12, 0, 12, 0, 12, 0, 12, 0, 12 },
			{ 0, 12, 24, 12, 0, 12, 24, 12, 0, 12, 24, 12, 0, 12, 24, 12 },
			{ 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3 },
			{ 0, 4, 0, 4, 0, 4, 0, 4, 0, 4, 0, 4, 0, 4, 0, 4 }
		};



		/********************************************************************/
		/// <summary>
		/// AM waveforms
		/// </summary>
		/********************************************************************/
		public static readonly sbyte[][] AmWaveforms =
		{
			new sbyte[]
			{
				   0,   25,   49,   71,   90,  106,  117,  125,
				 127,  125,  117,  106,   90,   71,   49,   25,
				   0, - 25, - 49, - 71, - 90, -106, -117, -125,
				-127, -125, -117, -106, - 90, - 71, - 49, - 25
			},

			new sbyte[]
			{
				-128, -120, -112, -104, - 96, - 88, - 80, - 72,
				- 64, - 56, - 48, - 40, - 32, - 24, - 16, -  8,
				   0,    8,   16,   24,   32,   40,   48,   56,
				  64,   72,   80,   88,   96,  104,  112,  120
			},

			new sbyte[]
			{
				-128, -128, -128, -128, -128, -128, -128, -128,
				-128, -128, -128, -128, -128, -128, -128, -128,
				 127,  127,  127,  127,  127,  127,  127,  127,
				 127,  127,  127,  127,  127,  127,  127,  127
			},

			new sbyte[]
			{
				   0,    0,    0,    0,    0,    0,    0,    0,
			       0,    0,    0,    0,    0,    0,    0,    0,
			       0,    0,    0,    0,    0,    0,    0,    0,
			       0,    0,    0,    0,    0,    0,    0,    0
			}
		};



		/********************************************************************/
		/// <summary>
		/// AM sinus
		/// </summary>
		/********************************************************************/
		public static readonly byte[] AmSinus =
		{
			  0,   2,   4,   6,   8,  11,  13,  15,
			 17,  20,  22,  24,  26,  28,  30,  33,
			 35,  37,  39,  41,  43,  45,  47,  50,
			 52,  54,  56,  58,  60,  62,  63,  65,
			 67,  69,  71,  73,  75,  77,  78,  80,
			 82,  83,  85,  87,  88,  90,  92,  93,
			 95,  96,  98,  99, 100, 102, 103, 104,
			106, 107, 108, 109, 110, 111, 113, 114,
			115, 116, 116, 117, 118, 119, 120, 121,
			121, 122, 123, 123, 124, 124, 125, 125,
			126, 126, 126, 127, 127, 127, 127, 127,
			127, 127, 128, 127, 127, 127, 127, 127,
			127, 127, 126, 126, 126, 125, 125, 124,
			124, 123, 123, 122, 121, 121, 120, 119,
			118, 117, 116, 115, 114, 113, 111, 110,
			109, 108, 107, 106, 104, 103, 102, 100,
			 99,  98,  96,  95,  93,  92,  90,  88,
			 87,  85,  83,  82,  80,  78,  77,  75,
			 73,  71,  69,  67,  65,  63,  62,  60,
			 58,  56,  54,  52,  50,  47,  45,  43,
			 41,  39,  37,  35,  33,  30,  28,  26,
			 24,  22,  20,  17,  15,  13,  11,   8,
			  6,   4,   2,   0
		};
	}
}
