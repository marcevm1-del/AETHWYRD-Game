using System.Linq;
using Ascend.Core;
using Ascend.Game;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Proves the shared rules and data work inside Unity:
    ///   Unity.exe -batchmode -quit -projectPath Game -executeMethod Ascend.EditorTools.SmokeTest.RunBatch
    /// </summary>
    public static class SmokeTest
    {
        [MenuItem("Ascend/Smoke Test (load data + rules)")]
        public static void Run() => Execute(false);

        public static void RunBatch() => Execute(true);

        static void Execute(bool batch)
        {
            try
            {
                AscendData.Reload();
                var db = AscendData.Db;
                Debug.Log($"[Ascend] Data loaded from {AscendData.DataRoot}: {db.Species.Count} species, {db.Regions.Count} regions, " +
                          $"{db.Quests.Count} quests, {db.WeeklyQuests.Count} weekly quests, {db.Inns.Count} inns, {db.Classes.Count} classes");

                var ring0 = string.Join(", ", db.SpeciesInRing(0).Select(s => $"{s.Name} (Lv {s.LevelRange[0]}-{s.LevelRange[1]})"));
                Debug.Log($"[Ascend] Ring 0 monsters: {ring0}");

                var sw = db.Classes["cls_swordsman"];
                var p = PlayerStats.Derive(PlayerStats.Primary(sw, 1, db.Progression), 1, db.Progression, new GearBonus { Atk = 8, Def = 3 });
                var goblin = db.Species["mon_goblin"];
                var hit = new DamageCalculator(db.Tuning.Damage).Compute(new DamageInput { Attack = p.Atk, Defense = goblin.Stats.Def, Power = 0.8 }, new DeterministicRandom(1));
                Debug.Log($"[Ascend] Lv 1 Swordsman: HP {p.Hp}, ATK {p.Atk}; a light hit on a goblin deals {hit.Amount} of its {goblin.Stats.Hp} HP");

                var cal = new GameCalendar(db.World.Calendar);
                var attacks = new SiegeScheduler(db.World.Siege, 1024).AttacksInWeek(db.Regions["reg_whisperwood"], 0);
                Debug.Log("[Ascend] Whisperwood siege week 0: " + string.Join("; ", attacks.Select(a => $"{cal.Weekday(a.Day)} {a.Hour}:00 at {a.Settlement}")));

                var board = new WeeklyBoard(db.WeeklyQuests.Values, cal, 1024).Build(0, "Brindlewick", RegionState.Besieged);
                Debug.Log($"[Ascend] Solenday board: special \"{board.Special?.Title}\", dailies: {string.Join(", ", board.Dailies.Select(q => q.Title))}");

                Debug.Log("[Ascend] SMOKE TEST PASSED");
                if (batch) EditorApplication.Exit(0);
            }
            catch (System.Exception e)
            {
                Debug.LogError("[Ascend] SMOKE TEST FAILED: " + e);
                if (batch) EditorApplication.Exit(1);
            }
        }
    }
}
