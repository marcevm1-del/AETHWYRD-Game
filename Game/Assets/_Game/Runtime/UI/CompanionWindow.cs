using System;
using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The Companions page (12_Systems/companions_and_mounts.md; IMGUI placeholder): each companion's command preset
    /// (Aggressive / Defensive / Supportive / Balanced, changed with Left/Right or Enter), what the preset does, where the
    /// relationship stands (Trust, Respect, Closeness, Tension as the stage names the data gives), the command wheel for the
    /// companion travelling with you, and the ground mounts with the guild rank that unlocks each. Opened with F3.
    /// Presets and bonds live in <see cref="PlayerWorldState"/> (session only until the save gets fields for them).
    /// </summary>
    public sealed class CompanionWindow : SystemWindow
    {
        static CompanionWindow _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static CompanionWindow Instance => _instance != null ? _instance : _instance = Create<CompanionWindow>();

        static readonly CompanionPreset[] Presets = { CompanionPreset.Aggressive, CompanionPreset.Defensive, CompanionPreset.Supportive, CompanionPreset.Balanced };

        /// <summary>The command wheel rows that map onto the existing orders (Retreat and Interact have no runtime behaviour yet).</summary>
        static readonly (CompanionCommand cmd, string label)[] Commands =
        {
            (CompanionCommand.Follow, "Follow me"),
            (CompanionCommand.HoldPosition, "Hold position"),
            (CompanionCommand.Attack, "Focus my target"),
            (CompanionCommand.Defend, "Guard here"),
            (CompanionCommand.Assist, "Assist me"),
        };

        protected override string Title => "COMPANIONS";
        protected override string Footer => "The stance is a request: companions still retreat when badly hurt and help you up when it is safe.";

        protected override void Build(List<Row> rows)
        {
            var world = World;
            if (world == null) { rows.Add(Info("Companions are not available yet.", true)); return; }
            var roster = world.CompanionRoster;
            var rules = world.CompanionRules;

            rows.Add(Header("PARTY — stance and bond"));
            int shown = 0;
            foreach (var c in roster.Where(x => !x.Stub))
            {
                var data = c;
                var bond = world.BondOf(c.Id);
                if (bond != null && bond.Departed) { rows.Add(Info($"{c.Name} — has gone their own way for now.", true)); shown++; continue; }
                if (bond != null && bond.Availability != CompanionAvailability.Ally)
                {
                    rows.Add(Info($"{c.Name} — {(bond.Availability == CompanionAvailability.Rival ? "not travelling with you yet" : "gone")}.", true));
                    shown++;
                    continue;
                }
                var preset = world.PresetOf(c.Id);
                rows.Add(new Row
                {
                    Text = $"{c.Name}  ·  {c.PreferredRole ?? "Companion"}  ·  stance: {preset}",
                    Act = () => CyclePreset(data, 1),
                    Adjust = dir => CyclePreset(data, dir),
                });
                if (rules != null) rows.Add(Info("      " + PresetText(rules, preset), true));
                if (bond != null && rules != null) rows.Add(Info("      " + BondText(rules.Relationships, bond), true));
                shown++;
            }
            if (shown == 0) rows.Add(Invite("No companion has joined you yet. Your first companion is out there; guild notice boards often mention strays."));

            var joined = JoinedCompanions();
            rows.Add(Header("COMMANDS — for the companion travelling with you"));
            if (joined.Count == 0) rows.Add(Info("Nobody is travelling with you right now.", true));
            else
            {
                rows.Add(Info("Current order: " + string.Join(", ", joined.Select(a => $"{a.Name} {OrderText(a.Order)}")), true));
                foreach (var entry in Commands)
                {
                    var command = entry.cmd;
                    rows.Add(new Row { Text = "      " + entry.label, Act = () => Command(command) });
                }
            }

            rows.Add(Header("MOUNTS — ground mounts only"));
            var table = AscendData.Mounts;
            if (table == null || table.Families == null || table.Families.Count == 0) { rows.Add(Info("No mounts yet.", true)); return; }
            string rank = GuildRankLetter();
            foreach (var kv in table.Families.OrderBy(m => MountTable.RankLetters.IndexOf(m.Value.UnlockRank ?? "F")).ThenBy(m => m.Key))
            {
                var f = kv.Value;
                bool ok = table.CanMount(kv.Key, rank);
                string status = ok ? "ready" : $"unlocks at guild rank {f.UnlockRank}";
                rows.Add(Info($"{f.Label ?? kv.Key}  ·  {table.Speed(kv.Key):0.0} m/s on plains  ·  stamina {f.Stamina.Max:0}  ·  {status}", !ok));
            }
            if (table.KnockedOutInsteadOfKilled(false)) rows.Add(Info("A mount that is beaten is knocked out and recovers; it is never lost.", true));
        }

        // ------------------------------------------------------------------ actions and texts (public for tests)

        void CyclePreset(CompanionData c, int dir)
        {
            var world = World;
            if (world == null) return;
            int i = Array.IndexOf(Presets, world.PresetOf(c.Id));
            var next = Presets[((i < 0 ? 0 : i) + dir + Presets.Length) % Presets.Length];
            world.SetPreset(c.Id, next);
            var rules = world.CompanionRules;
            if (rules != null)
            {
                string first = (c.Name ?? "").Split(' ')[0];
                foreach (var ai in JoinedCompanions())
                    if (first.Length > 0 && (ai.Name ?? "").IndexOf(first, StringComparison.OrdinalIgnoreCase) >= 0) ai.Command(rules.Preset(next).Order);
            }
            Line = $"{c.Name}: stance set to {next}.";
        }

        void Command(CompanionCommand command)
        {
            var effect = CompanionCommands.Map(command);
            foreach (var ai in JoinedCompanions()) ai.Command(effect.Order);
            Line = "Order given: " + Commands.First(x => x.cmd == command).label + ".";
        }

        static List<CompanionAI> JoinedCompanions() =>
            FindObjectsByType<CompanionAI>(FindObjectsSortMode.None).Where(a => a != null && a.Joined).OrderBy(a => a.Name).ToList();

        static string OrderText(CompanionOrder o)
        {
            switch (o)
            {
                case CompanionOrder.Hold: return "holding";
                case CompanionOrder.Focus: return "focusing your target";
                case CompanionOrder.Assist: return "assisting";
                default: return "following";
            }
        }

        string GuildRankLetter()
        {
            var world = World;
            return world != null ? PlayerQuests.RankOf(world).ToString() : "F";
        }

        /// <summary>"opens with Follow · retreats below 25% HP · helps you up from 3 m".</summary>
        public static string PresetText(CompanionRules rules, CompanionPreset preset)
        {
            var p = rules.Preset(preset);
            double retreat = CompanionPresetBrain.RetreatEnter(p, rules.Retreat, false);
            string stance = preset == CompanionPreset.Aggressive ? "presses the attack" : preset == CompanionPreset.Defensive ? "stays close and guards"
                          : preset == CompanionPreset.Supportive ? "backs you up and revives early" : "a bit of everything";
            return $"{stance} · default order {p.Order} · retreats below {retreat * 100:0}% HP · revive reach ×{p.ReviveEagerness:0.0#}";
        }

        /// <summary>"Trust steady · Respect noted · Closeness working · Tension calm".</summary>
        public static string BondText(RelationshipRules rules, RelationshipState s)
        {
            string Stage(RelationTrack t) => rules.Track(t).StageId(s.Get(t));
            return $"Trust {Stage(RelationTrack.Trust)} · Respect {Stage(RelationTrack.Respect)} · Closeness {Stage(RelationTrack.Closeness)} · Tension {Stage(RelationTrack.Tension)}";
        }
    }
}
