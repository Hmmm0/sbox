﻿
public static partial class SAM
{
	readonly static int[] tab48426 = new[] { 0x18, 0x1A, 0x17, 0x17, 0x17 };

	readonly static int[] tab47492 = new int[]
	{
	0 , 0 , 0xE0 , 0xE6 , 0xEC , 0xF3 , 0xF9 , 0 ,
	6 , 0xC , 6
	};


	readonly static int[] amplitudeRescale = new int[]
	{
	0 , 1 , 2 , 2 , 2 , 3 , 3 , 4 ,
	4 , 5 , 6 , 8 , 9 ,0xB ,0xD ,0xF, 0  //17 elements?
    };

	// Used to decide which phoneme's blend lengths. The candidate with the lower score is selected.
	// tab45856
	readonly static int[] blendRank = new int[]
	{
	0 , 0x1F , 0x1F , 0x1F , 0x1F , 2 , 2 , 2 ,
	2 , 2 , 2 , 2 , 2 , 2 , 5 , 5 ,
	2 ,0xA , 2 , 8 , 5 , 5 ,0xB ,0xA ,
	9 , 8 , 8 , 0xA0 , 8 , 8 , 0x17 , 0x1F ,
	0x12 , 0x12 , 0x12 , 0x12 , 0x1E , 0x1E , 0x14 , 0x14 ,
	0x14 , 0x14 , 0x17 , 0x17 , 0x1A , 0x1A , 0x1D , 0x1D ,
	2 , 2 , 2 , 2 , 2 , 2 , 0x1A , 0x1D ,
	0x1B , 0x1A , 0x1D , 0x1B , 0x1A , 0x1D , 0x1B , 0x1A ,
	0x1D , 0x1B , 0x17 , 0x1D , 0x17 , 0x17 , 0x1D , 0x17 ,
	0x17 , 0x1D , 0x17 , 0x17 , 0x1D , 0x17 , 0x17 , 0x17
	};


	// Number of frames at the end of a phoneme devoted to interpolating to next phoneme's final value
	//tab45696
	readonly static int[] outBlendLength = new int[]
	{
	0 , 2 , 2 , 2 , 2 , 4 , 4 , 4 ,
	4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 ,
	4 , 4 , 3 , 2 , 4 , 4 , 2 , 2 ,
	2 , 2 , 2 , 1 , 1 , 1 , 1 , 1 ,
	1 , 1 , 1 , 1 , 1 , 1 , 2 , 2 ,
	2 , 1 , 0 , 1 , 0 , 1 , 0 , 5 ,
	5 , 5 , 5 , 5 , 4 , 4 , 2 , 0 ,
	1 , 2 , 0 , 1 , 2 , 0 , 1 , 2 ,
	0 , 1 , 2 , 0 , 2 , 2 , 0 , 1 ,
	3 , 0 , 2 , 3 , 0 , 2 , 0xA0 , 0xA0
	};


	// Number of frames at beginning of a phoneme devoted to interpolating to phoneme's final value
	// tab45776
	readonly static int[] inBlendLength = new int[]
	{
	0 , 2 , 2 , 2 , 2 , 4 , 4 , 4 ,
	4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 ,
	4 , 4 , 3 , 3 , 4 , 4 , 3 , 3 ,
	3 , 3 , 3 , 1 , 2 , 3 , 2 , 1 ,
	3 , 3 , 3 , 3 , 1 , 1 , 3 , 3 ,
	3 , 2 , 2 , 3 , 2 , 3 , 0 , 0 ,
	5 , 5 , 5 , 5 , 4 , 4 , 2 , 0 ,
	2 , 2 , 0 , 3 , 2 , 0 , 4 , 2 ,
	0 , 3 , 2 , 0 , 2 , 2 , 0 , 2 ,
	3 , 0 , 3 , 3 , 0 , 3 , 0xB0 , 0xA0
	};


	// Looks like it's used as bit flags
	// High bits masked by 248 (11111000)
	//
	// 32: S*    241         11110001
	// 33: SH    226         11100010
	// 34: F*    211         11010011
	// 35: TH    187         10111011
	// 36: /H    124         01111100
	// 37: /X    149         10010101
	// 38: Z*    1           00000001
	// 39: ZH    2           00000010
	// 40: V*    3           00000011
	// 41: DH    3           00000011
	// 43: **    114         01110010
	// 45: **    2           00000010
	// 67: **    27          00011011
	// 70: **    25          00011001
	// tab45936
	readonly static int[] sampledConsonantFlags = new int[]
	{
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0xF1 , 0xE2 , 0xD3 , 0xBB , 0x7C , 0x95 , 1 , 2 ,
	3 , 3 , 0 , 0x72 , 0 , 2 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 , 0 , 0 , 0x1B , 0 , 0 , 0x19 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0
	};


	//tab45056
	readonly static int[] freq1data = new int[]
	{
	0x00 ,0x13 ,0x13 ,0x13 ,0x13 , 0xA , 0xE ,0x12
	,  0x18 ,0x1A ,0x16 ,0x14 ,0x10 ,0x14 , 0xE ,0x12
	,   0xE ,0x12 ,0x12 ,0x10 , 0xC , 0xE , 0xA ,0x12
	,   0xE ,0xA  , 8  , 6  , 6  ,  6 ,  6 ,0x11
	,    6 , 6 , 6 , 6 ,0xE , 0x10 , 9 ,0xA
	,    8 ,0xA , 6 , 6 , 6 , 5 , 6 , 0
	,  0x12 , 0x1A , 0x14 , 0x1A , 0x12 ,0xC , 6 , 6
	,    6 , 6 , 6 , 6 , 6 , 6 , 6 , 6
	,    6 , 6 , 6 , 6 , 6 , 6 , 6 , 6
	,    6 ,0xA ,0xA , 6 , 6 , 6 , 0x2C , 0x13
	};

	//tab451356
	readonly static int[] freq2data = new int[]
	{
	0x00 , 0x43 , 0x43 , 0x43 , 0x43 , 0x54 , 0x48 , 0x42 ,
	0x3E , 0x28 , 0x2C , 0x1E , 0x24 , 0x2C , 0x48 , 0x30 ,
	0x24 , 0x1E , 0x32 , 0x24 , 0x1C , 0x44 , 0x18 , 0x32 ,
	0x1E , 0x18 , 0x52 , 0x2E , 0x36 , 0x56 , 0x36 , 0x43 ,
	0x49 , 0x4F , 0x1A , 0x42 , 0x49 , 0x25 , 0x33 , 0x42 ,
	0x28 , 0x2F , 0x4F , 0x4F , 0x42 , 0x4F , 0x6E , 0x00 ,
	0x48 , 0x26 , 0x1E , 0x2A , 0x1E , 0x22 , 0x1A , 0x1A ,
	0x1A , 0x42 , 0x42 , 0x42 , 0x6E , 0x6E , 0x6E , 0x54 ,
	0x54 , 0x54 , 0x1A , 0x1A , 0x1A , 0x42 , 0x42 , 0x42 ,
	0x6D , 0x56 , 0x6D , 0x54 , 0x54 , 0x54 , 0x7F , 0x7F
	};

	//tab45216
	readonly static int[] freq3data = new int[]
	{
	0x00 , 0x5B , 0x5B , 0x5B , 0x5B , 0x6E , 0x5D , 0x5B ,
	0x58 , 0x59 , 0x57 , 0x58 , 0x52 , 0x59 , 0x5D , 0x3E ,
	0x52 , 0x58 , 0x3E , 0x6E , 0x50 , 0x5D , 0x5A , 0x3C ,
	0x6E , 0x5A , 0x6E , 0x51 , 0x79 , 0x65 , 0x79 , 0x5B ,
	0x63 , 0x6A , 0x51 , 0x79 , 0x5D , 0x52 , 0x5D , 0x67 ,
	0x4C , 0x5D , 0x65 , 0x65 , 0x79 , 0x65 , 0x79 , 0x00 ,
	0x5A , 0x58 , 0x58 , 0x58 , 0x58 , 0x52 , 0x51 , 0x51 ,
	0x51 , 0x79 , 0x79 , 0x79 , 0x70 , 0x6E , 0x6E , 0x5E ,
	0x5E , 0x5E , 0x51 , 0x51 , 0x51 , 0x79 , 0x79 , 0x79 ,
	0x65 , 0x65 , 0x70 , 0x5E , 0x5E , 0x5E , 0x08 , 0x01
	};

	readonly static int[] ampl1data = new int[]
	{
	0 , 0 , 0 , 0 , 0 ,0xD ,0xD ,0xE ,
	0xF ,0xF ,0xF ,0xF ,0xF ,0xC ,0xD ,0xC ,
	0xF ,0xF ,0xD ,0xD ,0xD ,0xE ,0xD ,0xC ,
	0xD ,0xD ,0xD ,0xC , 9 , 9 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 ,0xB ,0xB ,
	0xB ,0xB , 0 , 0 , 1 ,0xB , 0 , 2 ,
	0xE ,0xF ,0xF ,0xF ,0xF ,0xD , 2 , 4 ,
	0 , 2 , 4 , 0 , 1 , 4 , 0 , 1 ,
	4 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 ,0xC , 0 , 0 , 0 , 0 ,0xF ,0xF
	};

	readonly static int[] ampl2data = new int[]
	{
	0 , 0 , 0 , 0 , 0 ,0xA ,0xB ,0xD ,
	0xE ,0xD ,0xC ,0xC ,0xB , 9 ,0xB ,0xB ,
	0xC ,0xC ,0xC , 8 , 8 ,0xC , 8 ,0xA ,
	8 , 8 ,0xA , 3 , 9 , 6 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 3 , 5 ,
	3 , 4 , 0 , 0 , 0 , 5 ,0xA , 2 ,
	0xE ,0xD ,0xC ,0xD ,0xC , 8 , 0 , 1 ,
	0 , 0 , 1 , 0 , 0 , 1 , 0 , 0 ,
	1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 ,0xA , 0 , 0 ,0xA , 0 , 0 , 0
	};

	readonly static int[] ampl3data = new int[]
	{
	0 , 0 , 0 , 0 , 0 , 8 , 7 , 8 ,
	8 , 1 , 1 , 0 , 1 , 0 , 7 , 5 ,
	1 , 0 , 6 , 1 , 0 , 7 , 0 , 5 ,
	1 , 0 , 8 , 0 , 0 , 3 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 ,
	0 , 0 , 0 , 0 , 0 , 1 ,0xE , 1 ,
	9 , 1 , 0 , 1 , 0 , 0 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
	0 , 7 , 0 , 0 , 5 , 0 , 0x13 , 0x10
	};



	//tab42240
	readonly static int[] sinus = new int[]
	{0,3,6,9,12,16,19,22,25,28,31,34,37,40,43,46,49,51,54,57,60,63,65,68,71,73,76,78,81,83,85,88,90,92,94,96,98,100,102,104,106,107,109,111,112,113,115,116,117,118,120,121,122,122,123,124,125,125,126,126,126,127,127,127,127,127,127,127,126,126,126,125,125,124,123,122,122,121,120,118,117,116,115,113,112,111,109,107,106,104,102,100,98,96,94,92,90,88,85,83,81,78,76,73,71,68,65,63,60,57,54,51,49,46,43,40,37,34,31,28,25,22,19,16,12,9,6,3,0,-3,-6,-9,-12,-16,-19,-22,-25,-28,-31,-34,-37,-40,-43,-46,-49,-51,-54,-57,-60,-63,-65,-68,-71,-73,-76,-78,-81,-83,-85,-88,-90,-92,-94,-96,-98,-100,-102,-104,-106,-107,-109,-111,-112,-113,-115,-116,-117,-118,-120,-121,-122,-122,-123,-124,-125,-125,-126,-126,-126,-127,-127,-127,-127,-127,-127,-127,-126,-126,-126,-125,-125,-124,-123,-122,-122,-121,-120,-118,-117,-116,-115,-113,-112,-111,-109,-107,-106,-104,-102,-100,-98,-96,-94,-92,-90,-88,-85,-83,-81,-78,-76,-73,-71,-68,-65,-63,-60,-57,-54,-51,-49,-46,-43,-40,-37,-34,-31,-28,-25,-22,-19,-16,-12,-9,-6,-3};

	//tab42496
	readonly static int[] rectangle = new int[]
	{
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 , 0x90 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 ,
		0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70 , 0x70
	};


	//random data ?
	readonly static int[] sampleTable =
	{
    //00

    0x38 , 0x84 , 0x6B , 0x19 , 0xC6 , 0x63 ,  0x18 , 0x86
	,  0x73 , 0x98 , 0xC6 , 0xB1 , 0x1C , 0xCA , 0x31 , 0x8C
	,  0xC7 , 0x31 , 0x88 , 0xC2 , 0x30 , 0x98 , 0x46 , 0x31
	,  0x18 , 0xC6 , 0x35 ,0xC , 0xCA , 0x31 ,0xC , 0xC6
    //20
    ,  0x21 , 0x10 , 0x24 , 0x69 , 0x12 , 0xC2 , 0x31 , 0x14
	,  0xC4 , 0x71 , 8 , 0x4A , 0x22 , 0x49 , 0xAB , 0x6A
	,  0xA8 , 0xAC , 0x49 , 0x51 , 0x32 , 0xD5 , 0x52 , 0x88
	,  0x93 , 0x6C , 0x94 , 0x22 , 0x15 , 0x54 , 0xD2 , 0x25
    //40
    ,  0x96 , 0xD4 , 0x50 , 0xA5 , 0x46 , 0x21 , 8 , 0x85
	,  0x6B , 0x18 , 0xC4 , 0x63 , 0x10 , 0xCE , 0x6B , 0x18
	,  0x8C , 0x71 , 0x19 , 0x8C , 0x63 , 0x35 ,0xC , 0xC6
	,  0x33 , 0x99 , 0xCC , 0x6C , 0xB5 , 0x4E , 0xA2 , 0x99
    //60
    ,  0x46 , 0x21 , 0x28 , 0x82 , 0x95 , 0x2E , 0xE3 , 0x30
	,  0x9C , 0xC5 , 0x30 , 0x9C , 0xA2 , 0xB1 , 0x9C , 0x67
	,  0x31 , 0x88 , 0x66 , 0x59 , 0x2C , 0x53 , 0x18 , 0x84
	,  0x67 , 0x50 , 0xCA , 0xE3 ,0xA , 0xAC , 0xAB , 0x30
    //80
    ,  0xAC , 0x62 , 0x30 , 0x8C , 0x63 , 0x10 , 0x94 , 0x62
	,  0xB1 , 0x8C , 0x82 , 0x28 , 0x96 , 0x33 , 0x98 , 0xD6
	,  0xB5 , 0x4C , 0x62 , 0x29 , 0xA5 , 0x4A , 0xB5 , 0x9C
	,  0xC6 , 0x31 , 0x14 , 0xD6 , 0x38 , 0x9C , 0x4B , 0xB4
    //A0
    ,  0x86 , 0x65 , 0x18 , 0xAE , 0x67 , 0x1C , 0xA6 , 0x63
	,  0x19 , 0x96 , 0x23 , 0x19 , 0x84 , 0x13 , 8 , 0xA6
	,  0x52 , 0xAC , 0xCA , 0x22 , 0x89 , 0x6E , 0xAB , 0x19
	,  0x8C , 0x62 , 0x34 , 0xC4 , 0x62 , 0x19 , 0x86 , 0x63
    //C0
    ,  0x18 , 0xC4 , 0x23 , 0x58 , 0xD6 , 0xA3 , 0x50 , 0x42
	,  0x54 , 0x4A , 0xAD , 0x4A , 0x25 , 0x11 , 0x6B , 0x64
	,  0x89 , 0x4A , 0x63 , 0x39 , 0x8A , 0x23 , 0x31 , 0x2A
	,  0xEA , 0xA2 , 0xA9 , 0x44 , 0xC5 , 0x12 , 0xCD , 0x42
    //E0
    ,  0x34 , 0x8C , 0x62 , 0x18 , 0x8C , 0x63 , 0x11 , 0x48
	,  0x66 , 0x31 , 0x9D , 0x44 , 0x33 , 0x1D , 0x46 , 0x31
	,  0x9C , 0xC6 , 0xB1 ,0xC , 0xCD , 0x32 , 0x88 , 0xC4
	,  0x73 , 0x18 , 0x86 , 0x73 , 8 , 0xD6 , 0x63 , 0x58
    //100
    ,    7 , 0x81 , 0xE0 , 0xF0 , 0x3C , 7 , 0x87 , 0x90
	,  0x3C , 0x7C ,0xF , 0xC7 , 0xC0 , 0xC0 , 0xF0 , 0x7C
	,  0x1E , 7 , 0x80 , 0x80 , 0 , 0x1C , 0x78 , 0x70
	,  0xF1 , 0xC7 , 0x1F , 0xC0 ,0xC , 0xFE , 0x1C , 0x1F
    //120
    ,  0x1F ,0xE ,0xA , 0x7A , 0xC0 , 0x71 , 0xF2 , 0x83
	,  0x8F , 3 ,0xF ,0xF ,0xC , 0 , 0x79 , 0xF8
	,  0x61 , 0xE0 , 0x43 ,0xF , 0x83 , 0xE7 , 0x18 , 0xF9
	,  0xC1 , 0x13 , 0xDA , 0xE9 , 0x63 , 0x8F ,0xF , 0x83
    //140
    ,  0x83 , 0x87 , 0xC3 , 0x1F , 0x3C , 0x70 , 0xF0 , 0xE1
	,  0xE1 , 0xE3 , 0x87 , 0xB8 , 0x71 ,0xE , 0x20 , 0xE3
	,  0x8D , 0x48 , 0x78 , 0x1C , 0x93 , 0x87 , 0x30 , 0xE1
	,  0xC1 , 0xC1 , 0xE4 , 0x78 , 0x21 , 0x83 , 0x83 , 0xC3
    //160
    ,  0x87 , 6 , 0x39 , 0xE5 , 0xC3 , 0x87 , 7 ,0xE
	,  0x1C , 0x1C , 0x70 , 0xF4 , 0x71 , 0x9C , 0x60 , 0x36
	,  0x32 , 0xC3 , 0x1E , 0x3C , 0xF3 , 0x8F ,0xE , 0x3C
	,  0x70 , 0xE3 , 0xC7 , 0x8F ,0xF ,0xF ,0xE , 0x3C
    //180
    ,  0x78 , 0xF0 , 0xE3 , 0x87 , 6 , 0xF0 , 0xE3 , 7
	,  0xC1 , 0x99 , 0x87 ,0xF , 0x18 , 0x78 , 0x70 , 0x70
	,  0xFC , 0xF3 , 0x10 , 0xB1 , 0x8C , 0x8C , 0x31 , 0x7C
	,  0x70 , 0xE1 , 0x86 , 0x3C , 0x64 , 0x6C , 0xB0 , 0xE1
    //1A0
    ,  0xE3 ,0xF , 0x23 , 0x8F ,0xF , 0x1E , 0x3E , 0x38
	,  0x3C , 0x38 , 0x7B , 0x8F , 7 ,0xE , 0x3C , 0xF4
	,  0x17 , 0x1E , 0x3C , 0x78 , 0xF2 , 0x9E , 0x72 , 0x49
	,  0xE3 , 0x25 , 0x36 , 0x38 , 0x58 , 0x39 , 0xE2 , 0xDE
    //1C0
    ,  0x3C , 0x78 , 0x78 , 0xE1 , 0xC7 , 0x61 , 0xE1 , 0xE1
	,  0xB0 , 0xF0 , 0xF0 , 0xC3 , 0xC7 ,0xE , 0x38 , 0xC0
	,  0xF0 , 0xCE , 0x73 , 0x73 , 0x18 , 0x34 , 0xB0 , 0xE1
	,  0xC7 , 0x8E , 0x1C , 0x3C , 0xF8 , 0x38 , 0xF0 , 0xE1
    //1E0
    ,  0xC1 , 0x8B , 0x86 , 0x8F , 0x1C , 0x78 , 0x70 , 0xF0
	,  0x78 , 0xAC , 0xB1 , 0x8F , 0x39 , 0x31 , 0xDB , 0x38
	,  0x61 , 0xC3 ,0xE ,0xE , 0x38 , 0x78 , 0x73 , 0x17
	,  0x1E , 0x39 , 0x1E , 0x38 , 0x64 , 0xE1 , 0xF1 , 0xC1
    //200
    ,  0x4E ,0xF , 0x40 , 0xA2 , 2 , 0xC5 , 0x8F , 0x81
	,  0xA1 , 0xFC , 0x12 , 8 , 0x64 , 0xE0 , 0x3C , 0x22
	,  0xE0 , 0x45 , 7 , 0x8E ,0xC , 0x32 , 0x90 , 0xF0
	,  0x1F , 0x20 , 0x49 , 0xE0 , 0xF8 ,0xC , 0x60 , 0xF0
    //220
    ,  0x17 , 0x1A , 0x41 , 0xAA , 0xA4 , 0xD0 , 0x8D , 0x12
	,  0x82 , 0x1E , 0x1E , 3 , 0xF8 , 0x3E , 3 ,0xC
	,  0x73 , 0x80 , 0x70 , 0x44 , 0x26 , 3 , 0x24 , 0xE1
	,  0x3E , 4 , 0x4E , 4 , 0x1C , 0xC1 , 9 , 0xCC
    //240
    ,  0x9E , 0x90 , 0x21 , 7 , 0x90 , 0x43 , 0x64 , 0xC0
	,   0xF , 0xC6 , 0x90 , 0x9C , 0xC1 , 0x5B , 3 , 0xE2
	,  0x1D , 0x81 , 0xE0 , 0x5E , 0x1D , 3 , 0x84 , 0xB8
	,  0x2C ,0xF , 0x80 , 0xB1 , 0x83 , 0xE0 , 0x30 , 0x41
    //260
    ,  0x1E , 0x43 , 0x89 , 0x83 , 0x50 , 0xFC , 0x24 , 0x2E
	,  0x13 , 0x83 , 0xF1 , 0x7C , 0x4C , 0x2C , 0xC9 ,0xD
	,  0x83 , 0xB0 , 0xB5 , 0x82 , 0xE4 , 0xE8 , 6 , 0x9C
	,    7 , 0xA0 , 0x99 , 0x1D , 7 , 0x3E , 0x82 , 0x8F
    //280
    ,  0x70 , 0x30 , 0x74 , 0x40 , 0xCA , 0x10 , 0xE4 , 0xE8
	,   0xF , 0x92 , 0x14 , 0x3F , 6 , 0xF8 , 0x84 , 0x88
	,  0x43 , 0x81 ,0xA , 0x34 , 0x39 , 0x41 , 0xC6 , 0xE3
	,  0x1C , 0x47 , 3 , 0xB0 , 0xB8 , 0x13 ,0xA , 0xC2
    //2A0
    ,  0x64 , 0xF8 , 0x18 , 0xF9 , 0x60 , 0xB3 , 0xC0 , 0x65
	,  0x20 , 0x60 , 0xA6 , 0x8C , 0xC3 , 0x81 , 0x20 , 0x30
	,  0x26 , 0x1E , 0x1C , 0x38 , 0xD3 , 1 , 0xB0 , 0x26
	,  0x40 , 0xF4 ,0xB , 0xC3 , 0x42 , 0x1F , 0x85 , 0x32
    //2C0
    ,  0x26 , 0x60 , 0x40 , 0xC9 , 0xCB , 1 , 0xEC , 0x11
	,  0x28 , 0x40 , 0xFA , 4 , 0x34 , 0xE0 , 0x70 , 0x4C
	,  0x8C , 0x1D , 7 , 0x69 , 3 , 0x16 , 0xC8 , 4
	,  0x23 , 0xE8 , 0xC6 , 0x9A ,0xB , 0x1A , 3 , 0xE0
    //2E0
    ,  0x76 , 6 , 5 , 0xCF , 0x1E , 0xBC , 0x58 , 0x31
	,  0x71 , 0x66 , 0 , 0xF8 , 0x3F , 4 , 0xFC ,0xC
	,  0x74 , 0x27 , 0x8A , 0x80 , 0x71 , 0xC2 , 0x3A , 0x26
	,    6 , 0xC0 , 0x1F , 5 ,0xF , 0x98 , 0x40 , 0xAE
    //300
    ,    1 , 0x7F , 0xC0 , 7 , 0xFF , 0 ,0xE , 0xFE
	,    0 , 3 , 0xDF , 0x80 , 3 , 0xEF , 0x80 , 0x1B
	,  0xF1 , 0xC2 , 0 , 0xE7 , 0xE0 , 0x18 , 0xFC , 0xE0
	,  0x21 , 0xFC , 0x80 , 0x3C , 0xFC , 0x40 ,0xE , 0x7E
    //320
    ,    0 , 0x3F , 0x3E , 0 ,0xF , 0xFE , 0 , 0x1F
	,  0xFF , 0 , 0x3E , 0xF0 , 7 , 0xFC , 0 , 0x7E
	,  0x10 , 0x3F , 0xFF , 0 , 0x3F , 0x38 ,0xE , 0x7C
	,    1 , 0x87 ,0xC , 0xFC , 0xC7 , 0 , 0x3E , 4
    //340
    ,   0xF , 0x3E , 0x1F ,0xF ,0xF , 0x1F ,0xF , 2
	,  0x83 , 0x87 , 0xCF , 3 , 0x87 ,0xF , 0x3F , 0xC0
	,    7 , 0x9E , 0x60 , 0x3F , 0xC0 , 3 , 0xFE , 0
	,  0x3F , 0xE0 , 0x77 , 0xE1 , 0xC0 , 0xFE , 0xE0 , 0xC3
    //360
    ,  0xE0 , 1 , 0xDF , 0xF8 , 3 , 7 , 0 , 0x7E
	,  0x70 , 0 , 0x7C , 0x38 , 0x18 , 0xFE ,0xC , 0x1E
	,  0x78 , 0x1C , 0x7C , 0x3E ,0xE , 0x1F , 0x1E , 0x1E
	,  0x3E , 0 , 0x7F , 0x83 , 7 , 0xDB , 0x87 , 0x83
    //380
    ,    7 , 0xC7 , 7 , 0x10 , 0x71 , 0xFF , 0 , 0x3F
	,  0xE2 , 1 , 0xE0 , 0xC1 , 0xC3 , 0xE1 , 0 , 0x7F
	,  0xC0 , 5 , 0xF0 , 0x20 , 0xF8 , 0xF0 , 0x70 , 0xFE
	,  0x78 , 0x79 , 0xF8 , 2 , 0x3F ,0xC , 0x8F , 3
    //3a0
    ,   0xF , 0x9F , 0xE0 , 0xC1 , 0xC7 , 0x87 , 3 , 0xC3
	,  0xC3 , 0xB0 , 0xE1 , 0xE1 , 0xC1 , 0xE3 , 0xE0 , 0x71
	,  0xF0 , 0 , 0xFC , 0x70 , 0x7C ,0xC , 0x3E , 0x38
	,   0xE , 0x1C , 0x70 , 0xC3 , 0xC7 , 3 , 0x81 , 0xC1
    //3c0
    ,  0xC7 , 0xE7 , 0 ,0xF , 0xC7 , 0x87 , 0x19 , 9
	,  0xEF , 0xC4 , 0x33 , 0xE0 , 0xC1 , 0xFC , 0xF8 , 0x70
	,  0xF0 , 0x78 , 0xF8 , 0xF0 , 0x61 , 0xC7 , 0 , 0x1F
	,  0xF8 , 1 , 0x7C , 0xF8 , 0xF0 , 0x78 , 0x70 , 0x3C
    //3e0
    ,  0x7C , 0xCE ,0xE , 0x21 , 0x83 , 0xCF , 8 , 7
	,  0x8F , 8 , 0xC1 , 0x87 , 0x8F , 0x80 , 0xC7 , 0xE3
	,    0 , 7 , 0xF8 , 0xE0 , 0xEF , 0 , 0x39 , 0xF7
	,  0x80 ,0xE , 0xF8 , 0xE1 , 0xE3 , 0xF8 , 0x21 , 0x9F
    //400
    ,  0xC0 , 0xFF , 3 , 0xF8 , 7 , 0xC0 , 0x1F , 0xF8
	,  0xC4 , 4 , 0xFC , 0xC4 , 0xC1 , 0xBC , 0x87 , 0xF0
	,   0xF , 0xC0 , 0x7F , 5 , 0xE0 , 0x25 , 0xEC , 0xC0
	,  0x3E , 0x84 , 0x47 , 0xF0 , 0x8E , 3 , 0xF8 , 3
    //420
    ,  0xFB , 0xC0 , 0x19 , 0xF8 , 7 , 0x9C ,0xC , 0x17
	,  0xF8 , 7 , 0xE0 , 0x1F , 0xA1 , 0xFC ,0xF , 0xFC
	,    1 , 0xF0 , 0x3F , 0 , 0xFE , 3 , 0xF0 , 0x1F
	,    0 , 0xFD , 0 , 0xFF , 0x88 ,0xD , 0xF9 , 1
    //440
    ,  0xFF , 0 , 0x70 , 7 , 0xC0 , 0x3E , 0x42 , 0xF3
	,   0xD , 0xC4 , 0x7F , 0x80 , 0xFC , 7 , 0xF0 , 0x5E
	,  0xC0 , 0x3F , 0 , 0x78 , 0x3F , 0x81 , 0xFF , 1
	,  0xF8 , 1 , 0xC3 , 0xE8 ,0xC , 0xE4 , 0x64 , 0x8F
    ////460
    ,  0xE4 ,0xF , 0xF0 , 7 , 0xF0 , 0xC2 , 0x1F , 0
	,  0x7F , 0xC0 , 0x6F , 0x80 , 0x7E , 3 , 0xF8 , 7
	,  0xF0 , 0x3F , 0xC0 , 0x78 ,0xF , 0x82 , 7 , 0xFE
	,  0x22 , 0x77 , 0x70 , 2 , 0x76 , 3 , 0xFE , 0
    //480
    ,  0xFE , 0x67 , 0 , 0x7C , 0xC7 , 0xF1 , 0x8E , 0xC6
	,  0x3B , 0xE0 , 0x3F , 0x84 , 0xF3 , 0x19 , 0xD8 , 3
	,  0x99 , 0xFC , 9 , 0xB8 ,0xF , 0xF8 , 0 , 0x9D
	,  0x24 , 0x61 , 0xF9 ,0xD , 0 , 0xFD , 3 , 0xF0
    //4a0
    ,  0x1F , 0x90 , 0x3F , 1 , 0xF8 , 0x1F , 0xD0 ,0xF
	,  0xF8 , 0x37 , 1 , 0xF8 , 7 , 0xF0 ,0xF , 0xC0
	,  0x3F , 0 , 0xFE , 3 , 0xF8 ,0xF , 0xC0 , 0x3F
	,    0 , 0xFA , 3 , 0xF0 ,0xF , 0x80 , 0xFF , 1
    //4c0
    ,  0xB8 , 7 , 0xF0 , 1 , 0xFC , 1 , 0xBC , 0x80
	,  0x13 , 0x1E , 0 , 0x7F , 0xE1 , 0x40 , 0x7F , 0xA0
	,  0x7F , 0xB0 , 0 , 0x3F , 0xC0 , 0x1F , 0xC0 , 0x38
	,   0xF , 0xF0 , 0x1F , 0x80 , 0xFF , 1 , 0xFC , 3
    //4e0
    ,  0xF1 , 0x7E , 1 , 0xFE , 1 , 0xF0 , 0xFF , 0
	,  0x7F , 0xC0 , 0x1D , 7 , 0xF0 ,0xF , 0xC0 , 0x7E
	,    6 , 0xE0 , 7 , 0xE0 ,0xF , 0xF8 , 6 , 0xC1
	,  0xFE , 1 , 0xFC , 3 , 0xE0 ,0xF , 0 , 0xFC
	};
}
