using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Quest givers, the talk dialog, quest drops, reach places, potions and quest saves.</summary>
    public sealed class QuestPlayModeTests
    {
        GameObject _ground, _player;
        PlayerMotor _motor;
        PlayerCombat _combat;
        PlayerDefense _defense;
        PlayerInventory _inv;
        PlayerQuests _quests;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            AggroDirector.Reset();
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _motor = _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            _inv = _player.AddComponent<PlayerInventory>();
            _player.AddComponent<PlayerRespawn>();
            _quests = _player.AddComponent<PlayerQuests>();
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            if (NpcDialog.IsOpen) NpcDialog.Instance.Close();
            if (BagWindow.IsOpen) BagWindow.Instance.Close();
            foreach (var b in Object.FindObjectsByType<BagWindow>(FindObjectsSortMode.None)) Object.DestroyImmediate(b.gameObject);
            foreach (var t in new System.Type[] { typeof(QuestGiver), typeof(QuestPlace), typeof(NpcDialog), typeof(MonsterDummy) })
                foreach (var o in Object.FindObjectsByType(t, FindObjectsSortMode.None)) Object.DestroyImmediate(((Component)o).gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
        }

        QuestGiver Giver(string npcId, Vector3 at)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = at + Vector3.up;
            var g = go.AddComponent<QuestGiver>();
            g.NpcId = npcId;
            return g;
        }

        int OptionIndex(string contains) => NpcDialog.Instance.OptionTexts.ToList().FindIndex(t => t.Contains(contains));

        [Test]
        public void AcceptKillAndHandInThroughTheDialog()
        {
            var mina = Giver("npc_mina_feathersby", new Vector3(0, 0, 1.5f));
            Assert.AreSame(mina, QuestGiver.Nearest(_player.transform.position), "Mina is in talking range");
            NpcDialog.Instance.Open(mina, _quests);
            Assert.IsTrue(NpcDialog.IsOpen);
            int accept = OptionIndex("Rabbit Season");
            Assert.GreaterOrEqual(accept, 0, "she offers Rabbit Season");
            Assert.IsTrue(NpcDialog.Instance.Choose(accept));
            Assert.IsTrue(_quests.Log.IsActive("qst_gld_f_rabbit_season"));
            StringAssert.Contains("Horned Rabbit 0/8", _quests.TrackerLines().First(), "the tracker shows progress");

            for (int i = 0; i < 8; i++) _quests.Log.OnKill("mon_horned_rabbit");
            NpcDialog.Instance.Open(mina, _quests);
            int handIn = OptionIndex("Hand in: Rabbit Season");
            Assert.GreaterOrEqual(handIn, 0, "the hand-in option appears");
            NpcDialog.Instance.Choose(handIn);
            Assert.AreEqual(60, _inv.Items.Copper, "60 copper");
            Assert.AreEqual(1, _inv.Items.Count("itm_minor_hp_potion"), "and a potion");
            Assert.IsTrue(_quests.Log.Completed.Contains("qst_gld_f_rabbit_season"));
            NpcDialog.Instance.Choose(OptionIndex("Goodbye"));
            Assert.IsFalse(NpcDialog.IsOpen, "goodbye closes the window");
        }

        [Test]
        public void DecisionsAreMadeAtTheGiver()
        {
            var odo = Giver("npc_farmer_odo", new Vector3(0, 0, 1.5f));
            NpcDialog.Instance.Open(odo, _quests);
            NpcDialog.Instance.Choose(OptionIndex("Slime"));
            for (int i = 0; i < 5; i++) _quests.Log.OnKill("mon_blue_slime");
            NpcDialog.Instance.Open(odo, _quests);
            int relocate = OptionIndex("Relocate");
            Assert.GreaterOrEqual(relocate, 0, "relocate or slay is offered");
            NpcDialog.Instance.Choose(relocate);
            Assert.GreaterOrEqual(OptionIndex("Hand in"), 0, "then the hand-in");
        }

        [Test]
        public void QuestItemsDropFromTheirSpecies()
        {
            _combat.GrantXp(100000); // level 3+ for Mina's earring
            Assert.IsTrue(_quests.Accept(AscendData.Db.Quests["qst_odd_minas_earring"]));
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = new Vector3(0, 1, 6);
            go.SetActive(false);
            var crow = go.AddComponent<MonsterDummy>();
            crow.SpeciesId = "mon_giant_crow";
            go.SetActive(true);
            _quests.SendMessage("OnKilled", crow); // the kill path itself is covered in DeathAndLoot; drive the quest hook
            Assert.AreEqual(1, _inv.Items.Count("itm_minas_earring"), "the crow dropped the earring");
            Assert.AreEqual(1, _quests.Log.Get("qst_odd_minas_earring").Counts[1], "collect objective met");
            _quests.SendMessage("OnKilled", crow);
            Assert.AreEqual(1, _inv.Items.Count("itm_minas_earring"), "only one");
        }

        [UnityTest]
        public IEnumerator WalkingIntoAPlaceCountsOncePerVisit()
        {
            var place = new GameObject("gate").AddComponent<QuestPlace>();
            place.PlaceId = "brindlewick_north_gate"; place.Radius = 3f;
            place.transform.position = new Vector3(0, 0, 20);
            _quests.Accept(AscendData.Db.Quests["qst_main_status_granted"]);
            yield return null;
            Assert.AreEqual(0, _quests.Log.Get("qst_main_status_granted").Counts[1]);
            Teleport(new Vector3(0, 0, 19));
            yield return null; yield return null;
            Assert.AreEqual(1, _quests.Log.Get("qst_main_status_granted").Counts[1], "reached the gate");
        }

        void Teleport(Vector3 to)
        {
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = to; cc.enabled = true;
            Physics.SyncTransforms();
        }

        [Test]
        public void TheGuildBoardPostsTakesAndTakesBack()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(0, 1, 1.5f);
            go.AddComponent<QuestGiver>().NpcId = "npc_guild_clerk_wendel";
            go.AddComponent<QuestBoard>();
            var giver = go.GetComponent<QuestGiver>();
            Assert.AreEqual("Adventurers' Guild Board", giver.DisplayName);
            NpcDialog.Instance.Open(giver, _quests);
            int take = OptionIndex("Take [");
            Assert.GreaterOrEqual(take, 0, "something is posted and open now");
            NpcDialog.Instance.Choose(take);
            var p = _quests.Log.Active.Single(x => x.QuestId.StartsWith("qst_wk_"));
            var q = _quests.Log.Quest(p.QuestId);
            for (int i = 0; i < q.Objectives.Count; i++)
            {
                var o = q.Objectives[i];
                int n = System.Math.Max(1, o.Count);
                switch (o.Kind)
                {
                    case "kill": for (int k = 0; k < n; k++) _quests.Log.OnKill(o.Target); break;
                    case "collect": _inv.Items.Add(o.Target, n); break;
                    case "talk": _quests.Log.OnTalk(o.Target); break;
                    case "reach": for (int k = 0; k < n; k++) _quests.Log.OnReach(o.Target); break;
                    case "defend": for (int k = 0; k < n; k++) _quests.Log.OnDefend(o.Target); break;
                    case "choice": _quests.Log.Choose(q.Id, i, "yes"); break;
                }
            }
            Assert.AreEqual(QuestStatus.ReadyToTurnIn, _quests.Log.Get(q.Id).Status, $"{q.Id} complete");
            StringAssert.Contains("the guild board", _quests.TrackerLines().First(), "hand it in at the board");
            NpcDialog.Instance.Open(giver, _quests);
            NpcDialog.Instance.Choose(OptionIndex("Hand in"));
            Assert.IsFalse(_quests.Log.IsActive(q.Id), "handed in");
            Assert.IsTrue(_quests.BoardDoneOn(q.Id, 0), "done today");
            Assert.IsFalse(go.GetComponent<QuestBoard>().Takeable(_quests).Any(w => w.Id == q.Id), "not posted again today");
        }

        [Test]
        public void LearningAndForgingAtTorvalds()
        {
            _player.AddComponent<PlayerCrafting>();
            var torvald = Giver("npc_torvald_stonebeard", new Vector3(0, 0, 1.5f));
            _inv.Items.AddCopper(50);
            _inv.Items.Add("itm_mat_crude_blade", 2); _inv.Items.Add("itm_mat_fang", 2); _inv.Items.Add("itm_core_f", 1);
            NpcDialog.Instance.Open(torvald, _quests);
            NpcDialog.Instance.Choose(OptionIndex("Workbench"));
            NpcDialog.Instance.Choose(OptionIndex("Learn Fangblade"));
            Assert.AreEqual(10, _inv.Items.Copper, "40 copper to learn");
            NpcDialog.Instance.Choose(OptionIndex("Make Fangblade"));
            Assert.AreEqual(1, _inv.Items.Count("itm_fangblade"), "forged");
            Assert.AreEqual(0, _inv.Items.Count("itm_mat_fang"), "fangs used");
        }

        [Test]
        public void CookingAtACampfireFromTheBag()
        {
            _player.AddComponent<PlayerCrafting>();
            _inv.Items.Add("itm_mat_prime_meat", 2);
            BagWindow.Instance.Open(_combat);
            int cook = BagWindow.Instance.OptionTexts.ToList().FindIndex(t => t.Contains("Campfire: cook Hunter's Skewer"));
            Assert.GreaterOrEqual(cook, 0);
            BagWindow.Instance.Choose(cook);
            BagWindow.Instance.Close();
            Assert.AreEqual(1, _inv.Items.Count("itm_hunters_skewer"));
        }

        [Test]
        public void FireBombsGoToTheQuickSlot()
        {
            int before = _combat.FireBombs;
            _inv.Items.Add("itm_fire_bomb", 2);
            Assert.AreEqual(before + 2, _combat.FireBombs, "ready to throw (G)");
            Assert.AreEqual(0, _inv.Items.Count("itm_fire_bomb"), "not left in the bag");
        }

        [Test]
        public void RankingUpFromFToEAtMinasDesk()
        {
            _player.AddComponent<PlayerCrafting>();
            var mina = Giver("npc_mina_feathersby", new Vector3(0, 0, 1.5f));
            NpcDialog.Instance.Open(mina, _quests);
            int ask = OptionIndex("Ask about promotion to rank E");
            Assert.GreaterOrEqual(ask, 0, "Mina explains what's left");
            Assert.Less(OptionIndex("Rank-up ceremony"), 0, "no ceremony yet");
            NpcDialog.Instance.Close();

            // Meet every requirement: level 12, 100 GP, 10 F quests, a life skill, the Goblin Chief trial.
            while (_combat.Progress.Level < 12) _combat.GrantXp(_combat.Progress.ToNext - _combat.Progress.XpIntoLevel);
            _quests.Rank.Load(RankLetter.F, 100, 10);
            _inv.Items.AddCopper(100);
            _player.GetComponent<PlayerCrafting>().Crafter.Learn("rcp_fangblade", _inv.Items, "npc_torvald_stonebeard");
            _quests.Log.Load(null, new[] { "qst_trial_f_goblin_chief" }, 0);
            Assert.IsTrue(_quests.CanRankUp, string.Join(" ", _quests.RankRequirements().Select(r => r.Text + "=" + r.Met)));

            NpcDialog.Instance.Open(mina, _quests);
            NpcDialog.Instance.Choose(OptionIndex("Rank-up ceremony — become rank E"));
            Assert.AreEqual(RankLetter.E, _quests.Rank.Rank, "rank E");
            Assert.AreEqual(1, _inv.Items.Count("itm_copper_compass"), "the rank gift");
            Assert.AreEqual(RankLetter.E, PlayerQuests.RankOf(_player.transform), "rank checks use the guild rank");
        }

        [Test]
        public void QuestGpScalesWithRank()
        {
            _quests.Accept(AscendData.Db.Quests["qst_gld_f_rabbit_season"]);
            for (int i = 0; i < 8; i++) _quests.Log.OnKill("mon_horned_rabbit");
            _quests.TurnIn("qst_gld_f_rabbit_season");
            Assert.AreEqual(8, _quests.Rank.Gp, "an F quest at rank F: full GP");
            Assert.AreEqual(1, _quests.Rank.QuestsAtRank, "counts toward the at-rank quests");
        }

        [Test]
        public void GatheringAHerbPatchThenItRegrows()
        {
            var go = new GameObject("Gather_test");
            go.transform.position = new Vector3(0, 0, 1f);
            var fresh = new GameObject("Fresh"); fresh.transform.SetParent(go.transform, false);
            var node = go.AddComponent<GatherNode>();
            node.NodeId = "node_herb_patch"; node.Fresh = fresh;
            Assert.AreSame(node, GatherNode.Nearest(_player.transform.position), "in reach");
            Assert.IsTrue(node.Ready);
            var drops = node.Gather(_inv);
            Assert.GreaterOrEqual(_inv.Items.Count("itm_healing_herb"), 1, "herbs picked");
            Assert.IsFalse(node.Ready, "regrowing");
            Assert.AreEqual(0, node.Gather(_inv).Count, "nothing until it regrows");
            node.ReadyAtHour = GatherNode.Now - 1;
            Assert.IsTrue(node.Ready, "back after its hours");
            Object.DestroyImmediate(go);
        }

        [Test]
        public void TradingThroughTheDialog()
        {
            var reed = Giver("npc_fennick_reed", new Vector3(0, 0, 1.5f));
            _inv.Items.AddCopper(20);
            _inv.Items.Add("itm_mandrake_root", 1);
            NpcDialog.Instance.Open(reed, _quests);
            NpcDialog.Instance.Choose(OptionIndex("Trade"));
            NpcDialog.Instance.Choose(OptionIndex("Buy Minor Healing Potion"));
            Assert.AreEqual(1, _inv.Items.Count("itm_minor_hp_potion"), "bought a potion");
            Assert.AreEqual(6, _inv.Items.Copper, "for 14 copper");
            NpcDialog.Instance.Choose(OptionIndex("Sell…"));
            NpcDialog.Instance.Choose(OptionIndex("Sell Mandrake Root"));
            Assert.AreEqual(21, _inv.Items.Copper, "sold the root for 15");
            NpcDialog.Instance.Choose(OptionIndex("Back to wares"));
            NpcDialog.Instance.Choose(OptionIndex("Buy back"));
            NpcDialog.Instance.Choose(OptionIndex("Buy back Mandrake Root"));
            Assert.AreEqual(1, _inv.Items.Count("itm_mandrake_root"), "bought it back");
            Assert.AreEqual(6, _inv.Items.Copper, "at the price paid");
        }

        [Test]
        public void QuestItemsCantBeSold()
        {
            _combat.GrantXp(100000);
            _quests.Accept(AscendData.Db.Quests["qst_gather_crying_mandrake"]);
            _inv.Items.Add("itm_mandrake_root", 1);
            var reed = Giver("npc_fennick_reed", new Vector3(0, 0, 1.5f));
            NpcDialog.Instance.Open(reed, _quests);
            NpcDialog.Instance.Choose(OptionIndex("Trade"));
            NpcDialog.Instance.Choose(OptionIndex("Sell…"));
            NpcDialog.Instance.Choose(OptionIndex("Sell Mandrake Root"));
            Assert.AreEqual(1, _inv.Items.Count("itm_mandrake_root"), "kept for the quest");
        }

        [Test]
        public void PotionsHealAndAreUsedUp()
        {
            _inv.Items.Add("itm_minor_hp_potion", 2);
            _defense.ReceiveAttack(150, Telegraph.Red);
            int before = _defense.Hp;
            Assert.IsTrue(_inv.DrinkHealingPotion());
            Assert.Greater(_defense.Hp, before, "healed");
            Assert.AreEqual(1, _inv.Items.Count("itm_minor_hp_potion"), "one used");
            _defense.Revive();
            Assert.IsFalse(_inv.DrinkHealingPotion(), "not wasted at full health");
        }

        [Test]
        public void QuestsSurviveSaveAndLoad()
        {
            string dir = System.IO.Path.Combine(Application.temporaryCachePath, "ascend_quest_save");
            if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true);
            PlayerSave.Folder = dir;
            try
            {
                var save = _player.AddComponent<PlayerSave>();
                _quests.Accept(AscendData.Db.Quests["qst_gld_f_rabbit_season"]);
                _quests.Log.OnKill("mon_horned_rabbit"); _quests.Log.OnKill("mon_horned_rabbit");
                save.Save();
                _quests.Log.Load(null, null, 0);
                Assert.IsFalse(_quests.Log.IsActive("qst_gld_f_rabbit_season"));
                Assert.IsTrue(save.Load(), save.LastError);
                Assert.AreEqual(2, _quests.Log.Get("qst_gld_f_rabbit_season").Counts[0], "progress restored");
            }
            finally { PlayerSave.Folder = null; if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true); }
        }
    }
}
