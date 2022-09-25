﻿using System.Runtime.InteropServices;

namespace Ktisis.Structs.Actor {
	[StructLayout(LayoutKind.Explicit)]
	public struct Gaze {
		[FieldOffset(8)] public uint Mode; // 0 or 3
		[FieldOffset(16)] public float X;
		[FieldOffset(20)] public float Y;
		[FieldOffset(24)] public float Z;
		[FieldOffset(32)] public uint Unknown5;
	}

	public enum GazeControl : int {
		All = -1,
		Head = 0,
		Torso = 1,
		Eyes = 2
	}
}