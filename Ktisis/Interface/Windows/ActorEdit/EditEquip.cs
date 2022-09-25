﻿using ImGuiNET;

using Ktisis.Structs.Actor;

namespace Ktisis.Interface.Windows.ActorEdit {
	public class EditEquip {
		public unsafe static Actor* Target => EditActor.Target;

		// UI Code

		public static void Draw() {
			ImGui.EndTabItem();
		}
	}
}