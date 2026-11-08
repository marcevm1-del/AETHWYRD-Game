using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The Journal (IMGUI placeholder), two pages turned with Left/Right (or Q/E, bumpers): the dungeon clue record
    /// (DungeonKnowledge) and the Civilization Archive (CivilizationArchive). Entries are Unknown (not shown, only counted),
    /// Heard (a rumour: the wording the data gives, never the answer) or Visited (found or read in place). Archive pages also show
    /// fragments found (unfound ones stay "?") and the artifacts you restored. Opened with F4.
    /// </summary>
    public sealed class JournalWindow : SystemWindow
    {
        public enum Page { Clues, Archive }

        static JournalWindow _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static JournalWindow Instance => _instance != null ? _instance : _instance = Create<JournalWindow>();

        public Page Current { get; private set; }

        protected override string Title => "JOURNAL";
        protected override string[] Tabs => new[] { "Dungeon clues", "Civilization Archive" };
        protected override int TabIndex => (int)Current;

        public void ShowPage(Page p) { Current = p; Rebuild(); }

        protected override void OnPage(int dir) { Current = Current == Page.Clues ? Page.Archive : Page.Clues; Rebuild(); }

        protected override void OnOpened() { }

        protected override void Build(List<Row> rows)
        {
            var world = World;
            if (world == null) { rows.Add(Info("The journal is empty for now.", true)); return; }
            if (Current == Page.Clues) BuildClues(rows, world); else BuildArchive(rows, world);
        }

        // ------------------------------------------------------------------ dungeon clues

        void BuildClues(List<Row> rows, PlayerWorldState world)
        {
            var db = AscendData.Db;
            int dungeonsShown = 0;
            foreach (var kv in world.Dungeons.OrderBy(k => k.Key))
            {
                if (!db.Dungeons.TryGetValue(kv.Key, out var d)) continue;
                var know = kv.Value;
                int heard = d.Clues.Count(c => know.StatusOfClue(c.Id) == MapStatus.Heard);
                int found = d.Clues.Count(c => know.StatusOfClue(c.Id) == MapStatus.Visited);
                int visited = d.Rooms.Count(r => know.StatusOfRoom(r.Id) == MapStatus.Visited);
                if (heard + found + visited == 0) continue;
                dungeonsShown++;
                rows.Add(Header($"{d.Name}  ·  rooms seen {visited}/{d.Rooms.Count}  ·  clues found {found}/{d.Clues.Count}" + (know.Cleared ? "  ·  cleared" : "")));
                foreach (var c in d.Clues)
                {
                    var st = know.StatusOfClue(c.Id);
                    if (st == MapStatus.Visited)
                    {
                        bool first = true;
                        foreach (var line in Wrap(c.Text, 100))
                        {
                            rows.Add(Info((first ? "  ■ " : "      ") + line.TrimStart()));
                            first = false;
                        }
                    }
                    else if (st == MapStatus.Heard)
                    {
                        bool first = true;
                        foreach (var line in Wrap(string.IsNullOrEmpty(c.Heard) ? "A rumour hints at something hidden here." : c.Heard, 100))
                        {
                            rows.Add(Info((first ? "  ? Rumour: " : "      ") + line.TrimStart(), true));
                            first = false;
                        }
                    }
                }
                int unknown = d.Clues.Count - heard - found;
                if (unknown > 0) rows.Add(Info($"  … {unknown} more {(unknown == 1 ? "clue" : "clues")} still to be found", true));
            }
            if (dungeonsShown == 0) rows.Add(Invite("No dungeon records yet. Ask around and look closely when you explore."));
        }

        // ------------------------------------------------------------------ civilization archive

        void BuildArchive(List<Row> rows, PlayerWorldState world)
        {
            var archive = world.Archive;
            if (archive == null) { rows.Add(Info("The archive is not available yet.", true)); return; }
            var data = archive.Data;
            int read = data.Entries.Count(e => archive.Status(e.Id) == MapStatus.Visited);
            int shown = 0;
            rows.Add(Header($"Entries read {read} of {data.Entries.Count}  ·  artifacts restored {archive.RestoredArtifacts.Count()}"));
            foreach (var civ in data.Civilizations)
            {
                var entries = data.Entries.Where(e => e.CivilizationId == civ.Id).ToList();
                if (entries.All(e => archive.Status(e.Id) == MapStatus.Unknown)) continue;
                shown++;
                var (visited, total) = archive.Progress(civ.Id);
                rows.Add(Header($"{civ.Name}  ·  {civ.Age}  ·  read {visited}/{total}"));
                if (visited > 0) foreach (var line in Wrap(civ.Summary, 100)) rows.Add(Info("  " + line, true));
                foreach (var e in entries)
                {
                    var st = archive.Status(e.Id);
                    if (st == MapStatus.Unknown) continue;
                    if (st == MapStatus.Heard)
                    {
                        rows.Add(Info($"  ? A rumour of a {(string.IsNullOrEmpty(e.Kind) ? "record" : e.Kind)} — {(e.How == "restore" ? "it may be pieced back together from fragments" : "read it where it lies")}", true));
                    }
                    else
                    {
                        rows.Add(Info($"  ■ {e.Title}" + (string.IsNullOrEmpty(e.Source) ? "" : $"  ({e.Source})")));
                        foreach (var line in Wrap(e.Text, 100)) rows.Add(Info("      " + line.TrimStart()));
                    }
                    var frags = data.FragmentsOf(e.Id).ToList();
                    if (frags.Count > 0)
                    {
                        string list = string.Join(", ", frags.Select(f => archive.FragmentFound(f.Id) ? f.Name : "?"));
                        rows.Add(Info($"      fragments {frags.Count(f => archive.FragmentFound(f.Id))}/{frags.Count}: {list}", true));
                    }
                }
            }
            if (shown == 0) rows.Add(Invite("No records yet. Inscriptions, ruins and old tales will be written here."));
            var restored = archive.RestoredArtifacts.Select(id => data.Entry(id)).Where(e => e != null).ToList();
            if (restored.Count > 0)
            {
                rows.Add(Header("Restored artifacts"));
                foreach (var e in restored) rows.Add(Info("  ■ " + (string.IsNullOrEmpty(e.Artifact) ? e.Title : e.Artifact)));
            }
        }
    }
}
