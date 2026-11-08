using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Phase 1 wiring: the player's world state (life skills, home, stables, archive, dungeons, labyrinth, living world, gear,
    /// accessibility) saves and loads with the slot, an old save without those fields still loads, crafting uses quality and the
    /// life skill ladder, the adaptive-music logger logs state changes, and the playtest keys raise window requests.
    /// </summary>
    public sealed class Phase1WorldPlayModeTests
    {
        string _dir;
        readonly List<GameObject> _made = new List<GameObject>();

        [SetUp]
        public void SetUp()
        {
            _dir = Path.Combine(Application.temporaryCachePath, "ascend_phase1_save");
            if (Directory.Exists(_dir)) Directory.Delete(_dir, true);
            PlayerSave.Folder = _dir;
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var go in _made) if (go != null) Object.DestroyImmediate(go);
            _made.Clear();
            PlayerSave.Folder = null;
            if (Directory.Exists(_dir)) Directory.Delete(_dir, true);
            GameTime.Clear();
        }

        GameObject MakePlayer(bool withSave = true)
        {
            var p = new GameObject("TestPlayer");
            _made.Add(p);
            var cc = p.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            p.AddComponent<PlayerMotor>();
            p.AddComponent<PlayerCombat>();
            p.AddComponent<PlayerDefense>();
            p.AddComponent<PlayerInventory>();
            p.AddComponent<PlayerRespawn>();
            p.AddComponent<PlayerCrafting>();
            p.AddComponent<PlayerTaming>();
            if (withSave) p.AddComponent<PlayerSave>();
            return p;
        }

        // An older slot: nothing of Phase 1 in it.
        const string OldSave = "{\"Version\":1,\"Level\":12,\"XpIntoLevel\":40,\"Copper\":340,\"Items\":{\"itm_core_f\":2},"
            + "\"Flags\":[\"arrived_in_aetheria\"],\"KnownRecipes\":[\"rcp_fangblade\"],\"ClockSeconds\":120.5}";

        // A slot whose Phase 1 sections are null, empty or hold ids the data does not know: nothing may throw.
        const string OddSave = "{\"Version\":1,\"Level\":3,\"LifeSkills\":null,\"GearFittings\":{\"itm_gone\":null},\"Home\":null,\"Stables\":{\"Eggs\":null},"
            + "\"Archive\":{\"Entries\":{\"ent_gone\":\"Visited\"}},\"Dungeons\":{\"Dungeons\":null},\"Labyrinth\":{\"Floors\":{\"fl_gone\":\"Visited\"}},"
            + "\"LivingWorld\":{\"Events\":null,\"Journal\":null},\"Accessibility\":{\"TextScale\":50}}";

        string WriteSlot(string json)
        {
            Directory.CreateDirectory(_dir);
            string path = Path.Combine(_dir, "slot0.json");
            File.WriteAllText(path, json);
            return path;
        }

        [Test]
        public void TheWorldStateIsBuiltFromTheCoreData()
        {
            var w = MakePlayer().GetComponent<PlayerWorldState>();
            Assert.IsNotNull(w, "PlayerSave and PlayerCrafting add it");
            Assert.IsNotNull(w.LifeSkills, "life skills");
            Assert.IsNotNull(w.Home, "home");
            Assert.IsNotNull(w.Archive, "archive");
            Assert.IsNotNull(w.Labyrinth, "labyrinth");
            Assert.IsNotNull(w.Journal, "journal");
            Assert.IsNotNull(w.Events, "event director");
            Assert.IsNotNull(w.Meals, "meal buffs");
            Assert.IsNotNull(w.Accessibility, "accessibility");
            Assert.IsNotNull(w.Stables, "stables (the player has a partner roster)");
            Assert.IsNotNull(w.Gear, "gear fittings (the player has a crafter)");
            Assert.Greater(w.Dungeons.Count, 0, "dungeon knowledge per dungeon");
            Assert.IsNotNull(w.Music, "adaptive music logger");
            Assert.IsTrue(w.Music.Ready, w.Music.LastError);
            Assert.AreSame(w.LifeSkills, w.GetComponent<PlayerCrafting>().Skills, "crafting and the world state share one ladder");
        }

        [Test]
        public void EveryPhase1FieldRoundTripsThroughTheSlot()
        {
            var a = MakePlayer();
            var wa = a.GetComponent<PlayerWorldState>();
            string skill = AscendData.Db.LifeSkills.Skills[0].Id;
            wa.LifeSkills.AddXp(skill, 300);
            wa.Home.Load(new HomeSave { Tier = "rented_room", Storage = new Dictionary<string, int> { ["itm_core_f"] = 4 } });
            wa.Stables.NoteSpecies(AscendData.Db.Species.Keys.First());
            string entry = AscendData.Db.Archive.Entries.First().Id;
            wa.Archive.Hear(entry);
            var dungeon = AscendData.Db.Dungeons.Values.First();
            wa.Dungeons[dungeon.Id].VisitRoom(dungeon.EntryRoom);
            wa.LabyrinthKnowledge.VisitFloor(3);
            wa.Journal.Visit("region", "reg_test");
            wa.EventState.LastRolledDay = 7;
            var acc = wa.Accessibility;
            acc.ColorblindPalette = ColorblindPalette.Tritanopia; acc.TextScale = 1.4; acc.NoCombatMusic = true;
            wa.ApplyAccessibility();
            var sa = a.GetComponent<PlayerSave>();
            sa.Save();
            Assert.IsTrue(File.Exists(sa.PathOnDisk), sa.LastError);

            Object.DestroyImmediate(a);
            var b = MakePlayer();
            var wb = b.GetComponent<PlayerWorldState>();
            Assert.AreEqual(ColorblindPalette.Off, wb.Accessibility.ColorblindPalette, "a fresh player starts with defaults");
            var sb = b.GetComponent<PlayerSave>();
            Assert.IsTrue(sb.Load(), sb.LastError);

            Assert.AreEqual(300L, wb.LifeSkills.Xp(skill), "life skill XP");
            Assert.AreEqual("rented_room", wb.Home.Tier.Id, "home tier");
            Assert.AreEqual(4, wb.Home.Stored("itm_core_f"), "home storage");
            Assert.AreEqual(1, wb.Stables.SpeciesKnown, "stables species seen");
            Assert.AreEqual(MapStatus.Heard, wb.Archive.Status(entry), "archive");
            Assert.AreEqual(MapStatus.Visited, wb.Dungeons[dungeon.Id].StatusOfRoom(dungeon.EntryRoom), "dungeon room");
            Assert.AreEqual(MapStatus.Visited, wb.LabyrinthKnowledge.StatusOfFloor(3), "labyrinth floor");
            Assert.AreEqual(MapStatus.Visited, wb.Journal.StatusOf("region", "reg_test"), "discovery journal");
            Assert.AreEqual(7, wb.EventState.LastRolledDay, "event director");
            Assert.AreEqual(ColorblindPalette.Tritanopia, wb.Accessibility.ColorblindPalette, "colourblind palette");
            Assert.AreEqual(1.4, wb.Accessibility.TextScale, 1e-9, "text scale");
            Assert.IsTrue(wb.Music.Prefs.NoCombatMusic, "the music option reaches the music machine");
        }

        [Test]
        public void AnOldSaveWithoutAnyPhase1FieldLoads()
        {
            WriteSlot(OldSave);
            var p = MakePlayer();
            var save = p.GetComponent<PlayerSave>();
            Assert.IsTrue(save.Load(), save.LastError);
            Assert.AreEqual(12, p.GetComponent<PlayerCombat>().Progress.Level, "the old fields still load");
            var w = p.GetComponent<PlayerWorldState>();
            Assert.AreEqual("inn_room", w.Home.Tier.Id, "base inn room");
            Assert.AreEqual("F", w.LifeSkills.Rank(AscendData.Db.LifeSkills.Skills[0].Id), "every life skill at F");
            Assert.AreEqual(0, w.Stables.Eggs.Count, "no eggs");
            Assert.AreEqual(0, w.Archive.Visited.Count(), "nothing visited");
            Assert.AreEqual(ColorblindPalette.Off, w.Accessibility.ColorblindPalette, "safe defaults");
        }

        [Test]
        public void NullAndUnknownPhase1SectionsNeverStopTheLoad()
        {
            WriteSlot(OddSave);
            var p = MakePlayer();
            var save = p.GetComponent<PlayerSave>();
            Assert.IsTrue(save.Load(), save.LastError);
            Assert.AreEqual(3, p.GetComponent<PlayerCombat>().Progress.Level);
            var w = p.GetComponent<PlayerWorldState>();
            Assert.AreEqual(MapStatus.Unknown, w.Archive.Status("ent_gone"), "an id the data does not have is ignored");
            Assert.AreEqual(AccessibilityLimits.TextScaleMax, w.Accessibility.TextScale, 1e-9, "a wild value is clamped");
        }

        [Test]
        public void CraftingUsesTheLifeSkillLadderAndQuality()
        {
            var p = MakePlayer(false);
            var inv = p.GetComponent<PlayerInventory>();
            var craft = p.GetComponent<PlayerCrafting>();
            const string torvald = "npc_torvald_stonebeard";
            inv.Items.AddCopper(50);
            Assert.AreEqual(CraftResult.Ok, craft.Crafter.Learn("rcp_fangblade", inv.Items, torvald));
            Assert.AreEqual(CraftResult.MissingMaterials, craft.StatusOf("rcp_fangblade", torvald), "no materials yet");
            inv.Items.Add("itm_mat_crude_blade", 2); inv.Items.Add("itm_mat_fang", 2); inv.Items.Add("itm_core_f", 1);
            Assert.AreEqual(CraftResult.Ok, craft.StatusOf("rcp_fangblade", torvald));
            Assert.IsTrue(craft.CraftableHere(torvald).Any(r => r.Id == "rcp_fangblade"), "listed at the forge");

            var rep = craft.MakeQuality("rcp_fangblade", torvald);
            Assert.AreEqual(CraftResult.Ok, rep.Result);
            Assert.IsTrue(inv.Items.Items.Keys.Any(k => ItemQuality.BaseId(k) == "itm_fangblade"), "the blade is in the bag");
            Assert.Greater(rep.XpGained, 0L, "crafting earns life skill XP");
            Assert.AreEqual(rep.XpGained, craft.Skills.Xp("blacksmithing"), "on the recipe's skill");
            var row = craft.SkillRows().First(r => r.Id == "blacksmithing");
            Assert.AreEqual("F", row.Rank);
            Assert.Greater(row.XpToNext, 0L);
            var ladder = craft.Ladder("blacksmithing");
            Assert.AreEqual(craft.Skills.Ranks.Count, ladder.Count, "F to SSS");
            Assert.IsTrue(ladder[0].Reached && ladder[0].Current && !ladder[1].Reached);
            Assert.AreEqual(CraftResult.MissingMaterials, craft.StatusOf("rcp_fangblade", torvald), "the materials were used");
        }

        [Test]
        public void ARecipeAboveYourRankIsRefused()
        {
            var p = MakePlayer(false);
            var inv = p.GetComponent<PlayerInventory>();
            var craft = p.GetComponent<PlayerCrafting>();
            var hard = AscendData.Db.Recipes.Recipes.First(r => r.LifeRank == "E" && AscendData.Db.Recipes.Stations.ContainsKey(r.Station));
            craft.Crafter.Load(new[] { hard.Id });
            string owner = AscendData.Db.Recipes.Stations[hard.Station];
            foreach (var i in hard.Inputs) inv.Items.Add(i.ItemId, i.Count);
            Assert.AreEqual(CraftResult.RankTooLow, craft.StatusOf(hard.Id, owner), "rank E recipe at rank F");
            Assert.AreEqual(CraftResult.RankTooLow, craft.MakeQuality(hard.Id, owner).Result);
            Assert.IsNotEmpty(craft.StatusText(CraftResult.RankTooLow, hard));
        }

        // ------------------------------------------------------------------ adaptive music logger

        MusicStateLogger NewLogger()
        {
            var go = new GameObject("MusicLogger");
            _made.Add(go);
            var log = go.AddComponent<MusicStateLogger>();
            Assert.IsTrue(log.Ready, log.LastError);
            return log;
        }

        static MusicInput Calm() => new MusicInput();
        static MusicInput Fight() => new MusicInput { InCombat = true, ThreatLevel = 2 };

        [Test]
        public void TheMusicLoggerLogsEachStateChange()
        {
            var log = NewLogger();
            log.Tick(1.0, Calm());
            Assert.AreEqual(0, log.Log.Count, "nothing changed yet");
            Assert.AreEqual("explore", log.CurrentState);

            log.Tick(0.5, Fight());
            Assert.AreEqual("combat", log.CurrentState);
            Assert.AreEqual(1, log.Log.Count);
            StringAssert.Contains("explore -> combat", log.Log[0]);

            log.Tick(10.0, Calm()); // past the minimum hold and the exit delay
            Assert.AreEqual("explore", log.CurrentState);
            Assert.AreEqual(2, log.Log.Count);
            StringAssert.Contains("combat -> explore", log.Log[1]);
            Assert.IsNotNull(log.LastFrame);
        }

        [Test]
        public void TheLogKeepsOnlyTheLast30Lines()
        {
            var log = NewLogger();
            log.Tick(30.0, Fight());
            string first = log.Log[0];
            for (int i = 0; i < 70; i++) log.Tick(30.0, i % 2 == 0 ? Calm() : Fight());
            Assert.AreEqual(MusicStateLogger.Capacity, log.Log.Count, "a ring buffer of 30");
            Assert.Greater(log.Transitions, MusicStateLogger.Capacity, "more changes happened than are kept");
            Assert.AreNotEqual(first, log.Log[0], "the oldest lines were dropped");
        }

        [Test]
        public void NoCombatMusicKeepsTheScoreCalm()
        {
            var log = NewLogger();
            log.ApplyAccessibility(new AccessibilitySettings { NoCombatMusic = true });
            log.Tick(1.0, Fight());
            Assert.AreEqual("explore", log.CurrentState);
            Assert.AreEqual(0, log.Log.Count);
        }

        [Test]
        public void ABossTakesTheScoreAndItsPhaseStingerIsLogged()
        {
            var log = NewLogger();
            log.Tick(1.0, new MusicInput { InCombat = true, ThreatLevel = 3, BossPhase = 1 });
            Assert.AreEqual("boss", log.CurrentState);
            int lines = log.Log.Count;
            StringAssert.Contains("-> boss", log.Log[lines - 1]);
            if (!string.IsNullOrEmpty(AscendData.Music.Tuning.BossPhaseStinger))
            {
                log.Tick(0.1, new MusicInput { InCombat = true, ThreatLevel = 3, BossPhase = 2 });
                Assert.AreEqual(lines + 1, log.Log.Count, "the phase cue is logged");
                StringAssert.Contains("phase=2", log.Log[lines]);
            }
        }

        // ------------------------------------------------------------------ playtest keys

        [Test]
        public void PlaytestKeysRaiseWindowRequestsAndTheOverlayShowsTheMusicLog()
        {
            var p = MakePlayer(false);
            var keys = p.AddComponent<PlaytestShortcuts>();
            var seen = new List<string>();
            void On(string name) => seen.Add(name);
            PlaytestShortcuts.OpenRequested += On;
            try
            {
                PlaytestShortcuts.Request(PlaytestShortcuts.Windows.Crafting);
                PlaytestShortcuts.Request(PlaytestShortcuts.Windows.PhotoMode);
                CollectionAssert.AreEqual(new[] { "CraftingWindow", "PhotoModeController" }, seen);
            }
            finally { PlaytestShortcuts.OpenRequested -= On; }
            Assert.IsFalse(keys.OverlayVisible);
            keys.SetOverlay(true);
            Assert.IsTrue(keys.OverlayVisible);
            StringAssert.Contains("music:", keys.OverlayText());
            StringAssert.Contains("PLAYTEST", keys.OverlayText());
        }
    }
}
