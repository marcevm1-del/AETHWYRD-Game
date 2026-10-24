using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The Bestiary: sightings, kills, labels that reveal by tier, the window, and taming filling an entry.</summary>
    public sealed class BestiaryPlayModeTests
    {
        GameObject _ground, _player;
        PlayerBestiary _book;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            _player.AddComponent<PlayerDefense>();
            _player.AddComponent<PlayerInventory>();
            _book = _player.AddComponent<PlayerBestiary>();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            if (BestiaryWindow.IsOpen) BestiaryWindow.Instance.Close();
            foreach (var w in Object.FindObjectsByType<BestiaryWindow>(FindObjectsSortMode.None)) Object.DestroyImmediate(w.gameObject);
            foreach (var go in Object.FindObjectsByType<Transform>(FindObjectsSortMode.None).Where(x => x != null && x.name.StartsWith("Raider_")).Select(x => x.gameObject).ToList())
                Object.DestroyImmediate(go);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            Assert.IsNull(MonsterDummy.AppraisalTier, "labels go back to showing everything");
        }

        MonsterDummy Goblin(Vector3 at)
        {
            var m = MonsterSpawner.Spawn(null, "mon_goblin", at, Vector3.zero);
            var label = new GameObject("Label").AddComponent<TextMesh>();
            label.transform.SetParent(m.transform.parent, false);
            m.SetLabel(label);
            m.GetComponent<MonsterController>().enabled = false;
            return m;
        }

        static string LabelOf(MonsterDummy m) { m.Refresh(); return m.transform.parent.GetComponentInChildren<TextMesh>().text; }

        [UnityTest]
        public IEnumerator LabelsRevealWhatYouKnow()
        {
            var g = Goblin(new Vector3(0, 0, 40));
            yield return null;
            Assert.AreEqual("???", LabelOf(g), "never seen");
            g.transform.position = new Vector3(0, 1, 10);
            for (int i = 0; i < 40; i++) yield return null;
            Assert.AreEqual(1, _book.Book.Tier("mon_goblin"), "seen");
            StringAssert.Contains("Goblin", LabelOf(g));
            StringAssert.DoesNotContain("HP", LabelOf(g), "no HP bar yet (appraisal 2)");
            for (int k = 0; k < AscendData.Db.World.Bestiary.Tier2Kills; k++) _book.SendMessage("OnKilled", g);
            StringAssert.Contains("HP", LabelOf(g), "now it shows");

            BestiaryWindow.Instance.Toggle(_book);
            var lines = BestiaryWindow.Instance.Lines();
            Assert.IsTrue(lines.Any(l => l.Contains("Goblin") && l.Contains("kills 3")), "listed with its kills");
            Assert.IsTrue(lines.Any(l => l.Contains("weak to")), "tier 2 shows its weakness");
        }

        [Test]
        public void TamingFillsTheEntry()
        {
            _book.Tamed("mon_horned_rabbit");
            Assert.AreEqual(3, _book.Book.Tier("mon_horned_rabbit"));
            BestiaryWindow.Instance.Toggle(_book);
            Assert.IsTrue(BestiaryWindow.Instance.Lines().Any(l => l.StartsWith("    Field note:")), "lore shown at tier 3");
        }
    }
}
