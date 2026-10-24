using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The companion_field_ai.md Ring 0 prototype checklist, with Lyra.</summary>
    public sealed class CompanionPlayModeTests
    {
        GameObject _ground, _player, _lyraGo;
        PlayerCombat _combat;
        PlayerQuests _quests;
        CompanionAI _lyra;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            AggroDirector.Reset();
            CompanionAI.QuietBanter = false;
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _player.AddComponent<PlayerDefense>();
            _player.AddComponent<PlayerInventory>();
            _player.AddComponent<PlayerRespawn>();
            _quests = _player.AddComponent<PlayerQuests>();
            _player.AddComponent<PlayerTaming>();
            _lyraGo = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            _lyraGo.transform.position = new Vector3(3, 0.9f, 2);
            _lyraGo.SetActive(false);
            _lyraGo.AddComponent<QuestGiver>().NpcId = "npc_lyra_brightwood";
            _lyra = _lyraGo.AddComponent<CompanionAI>();
            _lyra.enabled = false;
            _lyraGo.SetActive(true);
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            CompanionAI.QuietBanter = false;
            if (NpcDialog.IsOpen) NpcDialog.Instance.Close();
            foreach (var d in Object.FindObjectsByType<NpcDialog>(FindObjectsSortMode.None)) Object.DestroyImmediate(d.gameObject);
            foreach (var go in Object.FindObjectsByType<Transform>(FindObjectsSortMode.None).Where(x => x != null && x.name.StartsWith("Raider_")).Select(x => x.gameObject).ToList())
                Object.DestroyImmediate(go);
            Object.DestroyImmediate(_lyraGo);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        MonsterDummy Monster(string species, Vector3 at) => MonsterSpawner.Spawn(null, species, at, _player.transform.position);
        void MovePlayer(Vector3 to) { var cc = _player.GetComponent<CharacterController>(); cc.enabled = false; _player.transform.position = to; cc.enabled = true; }

        [Test]
        public void SheJoinsOnlyAfterStatusGranted()
        {
            NpcDialog.Instance.Open(_lyraGo.GetComponent<QuestGiver>(), _quests);
            Assert.IsTrue(NpcDialog.Instance.OptionTexts.Any(t => t.Contains("after Status Granted")), "not yet");
            NpcDialog.Instance.Close();
            _quests.Log.Load(null, new[] { NpcDialog.CompanionGate }, 0);
            NpcDialog.Instance.Open(_lyraGo.GetComponent<QuestGiver>(), _quests);
            NpcDialog.Instance.Choose(NpcDialog.Instance.OptionTexts.ToList().FindIndex(t => t == "Travel together"));
            Assert.IsTrue(_lyra.Joined, "Lyra joins");
            Assert.IsTrue(_lyraGo.GetComponentsInChildren<Collider>().All(c => c.isTrigger), "she never body-blocks you");
        }

        [UnityTest]
        public IEnumerator SheFollowsWithoutCrowdingYou()
        {
            _lyra.Join(_combat);
            MovePlayer(new Vector3(10, 0, 10));
            float closest = float.MaxValue;
            for (int i = 0; i < 240; i++)
            {
                yield return null;
                Vector3 d = _lyraGo.transform.position - _player.transform.position; d.y = 0;
                if (i > 120) closest = Mathf.Min(closest, d.magnitude);
            }
            Vector3 gap = _lyraGo.transform.position - _player.transform.position; gap.y = 0;
            Assert.Less(gap.magnitude, 4.5f, "she keeps up");
            Assert.GreaterOrEqual(closest, (float)AscendData.Db.World.Companions.PersonalSpace - 0.05f, "and never stands inside you");
        }

        [UnityTest]
        public IEnumerator SheFocusesYourTargetAndTakesYourOpenings()
        {
            _lyra.Join(_combat);
            var goblin = Monster("mon_goblin", new Vector3(0, 0, 5));
            goblin.GetComponent<MonsterController>().enabled = false; // a training target
            _lyra.Command(CompanionOrder.Focus);
            _combat.LockTarget = goblin;
            for (int i = 0; i < 300 && _lyra.Hits == 0; i++) yield return null;
            Assert.Greater(_lyra.Hits, 0, "Focus: she attacks your lock-on target");

            goblin.GetComponent<MonsterController>().enabled = true;
            yield return null;
            goblin.TakeHit(1, HitWeight.Heavy, _player.transform.position, 9999); // you break its poise: an opening
            for (int i = 0; i < 120 && _lyra.Assists == 0; i++) yield return null;
            Assert.AreEqual(1, _lyra.Assists, "Rising Slash on the staggered goblin");
            StringAssert.Contains("Rising Slash", _lyra.LastLine);
        }

        [UnityTest]
        public IEnumerator SheIsOnlyEverDownedAndGetsBackUp()
        {
            _lyra.Join(_combat);
            ((IAlly)_lyra).TakeAllyHit(999999, Vector3.zero);
            Assert.IsTrue(_lyra.Downed, "downed");
            for (int i = 0; i < (int)(AscendData.Db.World.Companions.DownedSec * 60) + 10; i++) yield return null;
            Assert.IsFalse(_lyra.Downed, "back on her feet");
            Assert.AreEqual(_lyra.MaxHp, _lyra.Hp, "rested to full");
        }

        [UnityTest]
        public IEnumerator SheSharesHerReadOnANewMonsterUnlessAskedToBeQuiet()
        {
            _lyra.Join(_combat);
            var moth = Monster("mon_lantern_moth", new Vector3(6, 0, 6));
            for (int i = 0; i < 30; i++) yield return null;
            StringAssert.Contains("her read on the Lantern Moth", _lyra.LastLine ?? "", "an observation, framed as hers");
            Object.DestroyImmediate(MonsterSpawner.RootOf(moth));

            CompanionAI.QuietBanter = true;
            Monster("mon_fluffcap_sheep", new Vector3(-6, 0, 6));
            for (int i = 0; i < 30; i++) yield return null;
            StringAssert.DoesNotContain("Fluffcap", _lyra.LastLine ?? "", "quiet mode");
        }

        [UnityTest]
        public IEnumerator SheDodgesAWindUpBesideHer()
        {
            _lyra.Join(_combat);
            MovePlayer(new Vector3(0, 0, 0));
            _lyraGo.transform.position = new Vector3(1.2f, 0.9f, 1.2f);
            Monster("mon_goblin", new Vector3(0.5f, 0, 2.2f)); // goes for you, right beside her
            for (int i = 0; i < 600 && _lyra.Dodges == 0; i++) { _player.GetComponent<PlayerMotor>().Tick(Vector3.zero, false, false, Time.deltaTime); yield return null; }
            Assert.Greater(_lyra.Dodges, 0, "she sidesteps the telegraphed swing");
        }
    }
}
