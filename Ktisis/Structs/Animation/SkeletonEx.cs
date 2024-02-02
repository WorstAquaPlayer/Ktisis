using System.Numerics;
using System.Runtime.InteropServices;

using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

using Ktisis.Structs.Attach;

namespace Ktisis.Structs.Animation;

[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public struct SkeletonEx {
	[FieldOffset(0x00)] public Skeleton Skeleton;

	[FieldOffset(0x88)] public unsafe ElementParam* ElementParam;
	[FieldOffset(0x90)] public unsafe Matrix4x4* ElementMatrix;
	[FieldOffset(0x98)] public unsafe ushort* ElementBoneMap;
	[FieldOffset(0xA0)] public uint ElementCount;

	public bool TryGetBoneIndexForElementId(uint id, out ushort index)
		=> this.TryGetBoneIndexForElementId((ElementId)id, out index);

	public unsafe bool TryGetBoneIndexForElementId(ElementId id, out ushort index) {
		index = ushort.MaxValue;
		for (var i = 0; i < this.ElementCount; i++) {
			if (this.ElementParam[i].ElementId != id) continue;
			index = this.ElementBoneMap[i];
			return true;
		}
		return false;
	}
}