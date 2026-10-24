using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Taming a weakened monster, partners that follow and fight, the rules that block a tame, and saves.</summary>
    public sealed class TamingPlayModeTests
    {
        GameObject _ground, _player;
        PlayerCombat _combat;
        PlayerInventory _inv;
        PlayerQuests _quests;
        PlayerTaming _taming;

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
            _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _player.AddComponent<PlayerDefense>();
            _inv = _player.AddComponent<PlayerInventory>();
            _player.AddComponent<PlayerRespawn>();
            _quests = _player.AddComponent<PlayerQuests>();
            _taming = _player.AddComponent<PlayerTaming>();
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var t in new System.Type[] { typeof(MonsterDummy), typeof(DamageNumber) })
                foreach (var o in Object.FindObjectsByType(t, FindObjectsSortMode.None)) if (o != null) Object.DestroyImmediate(((Component)o).gameObject);
            foreach (var go in Object.FindObjectsByType<Transform>(FindObjectsSortMode.None).Where(x => x != null && x.name.StartsWith("Raider_")).Select(x => x.gameObject).ToList())
                Object.DestroyImmediate(go);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        MonsterDummy Monster(string species, Vector3 at)
        {
            var m = MonsterSpawner.Spawn(null, species, at, Vector3.zero);
            Physics.SyncTransforms();
            return m;
        }

        static void Weaken(MonsterDummy m) => m.TakeHit(m.MaxHp - Mathf.Max(1, m.MaxHp / 5), HitWeight.Light, m.transform.position + Vector3.forward, 0);

        [UnityTest]
        public IEnumerator TamingAWeakenedRabbitMakesItAPartner()
        {
            var rabbit = Monster("mon_horned_rabbit", new Vector3(0, 0, 2f));
            yield return null;
            Assert.IsFalse(_taming.Begin(rabbit), "a healthy rabbit won't be tamed");
            Weaken(rabbit);
            Assert.Less(rabbit.Hp / (float)rabbit.MaxHp, 0.3f);
            Assert.IsTrue(_taming.Begin(rabbit), "weakened: the taming begins");
            Assert.IsFalse(rabbit.GetComponent<MonsterController>().enabled, "it stops fighting");
            for (int i = 0; i < 300; i++) yield return null; // five calm seconds nearby
            Assert.Greater(_taming.Encounter.Calm, 40, "calm builds while you stay close");
            _inv.Items.Add("itm_mat_prime_meat", 1);
            Assert.IsTrue(_quests.Accept(_quests.Log.Quest("qst_wk_syl_tame_practice")), "the board's taming job");
            Assert.AreEqual(TameResult.Tamed, _taming.Offer(), "calm, fed its favourite: tamed");
            Assert.AreEqual(0, _inv.Items.Count("itm_mat_prime_meat"), "the meat was eaten");
            Assert.IsTrue(rabbit.IsPartner, "it's on your side");
            yield return null;
            Assert.IsNull(rabbit.GetComponent<MonsterController>(), "no longer an enemy AI");
            Assert.IsNotNull(rabbit.GetComponent<PartnerFollower>(), "it follows you");
            Assert.IsTrue(rabbit.GetComponentsInChildren<Collider>().All(c => c.isTrigger), "your attacks pass through it");
            Assert.AreEqual(1, _taming.Roster.Active.Count());
            Assert.AreEqual(QuestStatus.ReadyToTurnIn, _quests.Log.Get("qst_wk_syl_tame_practice").Status, "counts for the taming job");
        }

        [UnityTest]
        public IEnumerator PartnersFollowAndJoinTheFight()
        {
            var rabbit = Monster("mon_horned_rabbit", new Vector3(0, 0, 2f));
            yield return null;
            Weaken(rabbit);
            _taming.Begin(rabbit);
            for (int i = 0; i < 400; i++) yield return null;
            _inv.Items.Add("itm_mat_prime_meat", 1);
            Assume.That(_taming.Offer() == TameResult.Tamed, "needs the tame to succeed");
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = new Vector3(10, 0, 0); cc.enabled = true;
            for (int i = 0; i < 240; i++) yield return null;
            Assert.Less(Vector3.Distance(rabbit.transform.position, _player.transform.position), 4.5f, "it trails you");
            var slime = Monster("mon_blue_slime", new Vector3(13, 0, 0));
            var follower = rabbit.GetComponent<PartnerFollower>();
            for (int i = 0; i < 400 && follower.Hits == 0; i++) yield return null;
            Assert.Greater(follower.Hits, 0, "it attacks a monster near you");
            Assert.Less(slime.Hp, slime.MaxHp, "and does damage");
        }

        [Test]
        public void SomeMonstersCantBeTamed()
        {
            var goblin = Monster("mon_goblin", new Vector3(0, 0, 2f));
            Weaken(goblin);
            Assert.IsFalse(_taming.Begin(goblin), "goblins need special quests");
            var boar = Monster("mon_wild_boar", new Vector3(2, 0, 2f));
            Weaken(boar);
            Assert.IsFalse(_taming.Begin(boar), "an E-rank boar won't follow an F rookie");
        }

        [Test]
        public void PartnersAreSaved()
        {
            string dir = System.IO.Path.Combine(Application.temporaryCachePath, "ascend_partner_save");
            if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true);
            PlayerSave.Folder = dir;
            try
            {
                var save = _player.AddComponent<PlayerSave>();
                _taming.Load(new[] { new PartnerData { SpeciesId = "mon_horned_rabbit", Name = "Bun", Active = true } });
                Assert.AreEqual(1, _taming.Following.Count, "Bun appears beside you");
                save.Save();
                _taming.Load(null);
                Assert.AreEqual(0, _taming.Following.Count);
                Assert.IsTrue(save.Load(), save.LastError);
                Assert.AreEqual("Bun", _taming.Roster.Active.Single().Name, "Bun is back");
                Assert.AreEqual(1, _taming.Following.Count, "and in the world");
            }
            finally { PlayerSave.Folder = null; if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true); }
        }
    }
}
