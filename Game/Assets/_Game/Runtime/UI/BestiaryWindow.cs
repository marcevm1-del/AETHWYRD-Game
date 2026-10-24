using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// The Bestiary page (IMGUI placeholder; hud_and_ui.md §9): every species you've seen, revealed tier by tier —
    /// name, rank and Menace; then HP, element and weakness; then attacks, drops and lore (its look and field note) —
    /// with a completion stamp and the field's completion percentage. B opens and closes it; up/down scroll.
    /// </summary>
    public sealed class BestiaryWindow : MonoBehaviour
    {
        static BestiaryWindow _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static BestiaryWindow Instance => _instance != null ? _instance : _instance = FindFirstObjectByType<BestiaryWindow>() ?? new GameObject("BestiaryWindow").AddComponent<BestiaryWindow>();

        bool _open;
        PlayerBestiary _owner;
        int _scroll;
        float _openedAt;
        GUIStyle _box, _title, _item;

        public void Toggle(PlayerBestiary owner) { if (_open) _open = false; else { _owner = owner; _open = true; _scroll = 0; _openedAt = Time.unscaledTime; } }
        public void Close() => _open = false;

        /// <summary>The page's lines (also used by tests).</summary>
        public List<string> Lines()
        {
            var lines = new List<string>();
            if (_owner == null) return lines;
            var db = AscendData.Db;
            var book = _owner.Book;
            var field = db.Species.Values.Where(s => s.Ring <= 1).Select(s => s.Id).ToList();
            lines.Add($"Seen {book.Entries.Values.Count(e => e.Seen)} of {db.Species.Count} species · Ring 0–1 completion {book.Completion(field) * 100:0}%");
            foreach (var e in book.Entries.Values.Where(e => e.Seen).OrderBy(e => db.Species[e.SpeciesId].Ring).ThenBy(e => Rank.Parse(db.Species[e.SpeciesId].Rank).Value).ThenBy(e => e.SpeciesId))
            {
                var s = db.Species[e.SpeciesId];
                int tier = book.Tier(s.Id);
                string stamp = book.Stamped(s.Id) ? "  ★ 100%" : "";
                lines.Add($"■ {s.Name} — rank {s.Rank} · {s.MenaceLabel} · {s.Family} · kills {e.Kills}{(e.Tamed ? " · tamed" : "")}{stamp}");
                if (tier >= 2) lines.Add($"    HP {s.Stats.Hp} · element {s.Element ?? "none"} · weak to {s.Weakness ?? "nothing known"}");
                else lines.Add($"    (defeat {AscendData.Db.World.Bestiary.Tier2Kills} for HP, element and weakness)");
                if (tier >= 3)
                {
                    string drops = string.Join(", ", book.PossibleDrops(s.Id).Select(d => (e.DropsFound.Contains(d) ? "" : "?") + (db.Items.TryGetValue(d, out var it) ? it.Name : d)));
                    lines.Add($"    Drops: {drops}");
                    if (!string.IsNullOrEmpty(s.Look)) lines.Add($"    {s.Look}");
                    if (!string.IsNullOrEmpty(s.FieldNote)) lines.Add($"    Field note: {s.FieldNote}");
                }
            }
            return lines;
        }

        void Update()
        {
            if (!_open || Time.unscaledTime - _openedAt < 0.15f) return;
            var kb = Keyboard.current;
            if (kb != null)
            {
                if (kb.escapeKey.wasPressedThisFrame || kb.bKey.wasPressedThisFrame) { Close(); return; }
                if (kb.downArrowKey.wasPressedThisFrame) _scroll++;
                if (kb.upArrowKey.wasPressedThisFrame) _scroll = Mathf.Max(0, _scroll - 1);
            }
            var pad = Gamepad.current;
            if (pad != null)
            {
                if (pad.buttonEast.wasPressedThisFrame) { Close(); return; }
                if (pad.dpad.down.wasPressedThisFrame) _scroll++;
                if (pad.dpad.up.wasPressedThisFrame) _scroll = Mathf.Max(0, _scroll - 1);
            }
        }

        void OnGUI()
        {
            if (!_open) return;
            _box ??= new GUIStyle(GUI.skin.box);
            _title ??= new GUIStyle(GUI.skin.label) { fontSize = 20, fontStyle = FontStyle.Bold };
            _item ??= new GUIStyle(GUI.skin.label) { fontSize = 14, wordWrap = false };
            var lines = Lines();
            float w = Mathf.Min(900f, Screen.width - 40f), h = Mathf.Min(Screen.height - 60f, 640f);
            var r = new Rect((Screen.width - w) / 2f, (Screen.height - h) / 2f, w, h);
            GUI.Box(r, "", _box);
            GUI.Label(new Rect(r.x + 16, r.y + 10, w - 32, 26), "BESTIARY", _title);
            int rows = (int)((h - 50) / 20);
            _scroll = Mathf.Clamp(_scroll, 0, Mathf.Max(0, lines.Count - rows));
            for (int i = 0; i < rows && _scroll + i < lines.Count; i++)
                GUI.Label(new Rect(r.x + 16, r.y + 42 + i * 20, w - 32, 20), lines[_scroll + i], _item);
        }
    }
}
