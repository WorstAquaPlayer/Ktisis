﻿using System.Numerics;

using ImGuiNET;

namespace Ktisis.Interface {
	internal class ConfigUI {
		private Ktisis Plugin;

		public bool Visible = false;

		// Constructor

		public ConfigUI(Ktisis plugin) {
			Plugin = plugin;
		}

		// Toggle visibility

		public void Show() {
			Visible = true;
		}

		public void Hide() {
			Visible = false;
		}

		// Draw

		public void Draw() {
			if (!Visible)
				return;

			var size = new Vector2(-1, -1);
			ImGui.SetNextWindowSize(size, ImGuiCond.Always);
			ImGui.SetNextWindowSizeConstraints(size, size);

			ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(10, 10));

			if (ImGui.Begin("Ktisis Settings", ref Visible, ImGuiWindowFlags.NoResize)) {
				if (ImGui.BeginTabBar("Settings")) {
					var cfg = Plugin.Configuration;

					if (ImGui.BeginTabItem("Overlay"))
						DrawOverlayTab(cfg);
					if (ImGui.BeginTabItem("Gizmo"))
						DrawGizmoTab(cfg);

					ImGui.EndTabBar();
				}
			}

			ImGui.PopStyleVar(1);
			ImGui.End();
		}

		// Overlay

		public void DrawOverlayTab(Configuration cfg) {
			ImGui.EndTabItem();
		}

		// Gizmo

		public void DrawGizmoTab(Configuration cfg) {
			var allowAxisFlip = cfg.AllowAxisFlip;
			if (ImGui.Checkbox("Flip axis to face camera", ref allowAxisFlip)) {
				cfg.AllowAxisFlip = allowAxisFlip;
				cfg.Save(Plugin);
			}

			ImGui.EndTabItem();
		}
	}
}