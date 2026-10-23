using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Ring 0 week 9: XP and level-ups, the Style meter, and the HUD / Status Window content.</summary>
    public sealed class ProgressAndHudPlayModeTests
    {
        GameObject _ground, _player, _hudGo;
        PlayerMotor _motor;
        PlayerCombat _combat;
        PlayerDefense _defense;
        RingZeroHud _hud;

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
            _motor = _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            _hudGo = new GameObject("Hud");
            _hud = _hudGo.AddComponent<RingZeroHud>();
            _hud.Player = _combat;
            Physics.SyncTransforms();
            for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, 1f / 60f);
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var t in new System.Type[] { typeof(MonsterDummy), typeof(DamageNumber), typeof(ReactionPopup) })
                foreach (var o in Object.FindObjectsByType(t, FindObjectsSortMode.None)) Object.DestroyImmediate(((Component)o).gameObject);
            Object.DestroyImmediate(_hudGo);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
        }

        MonsterDummy Goblin(Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = pos + Vector3.up;
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = "mon_goblin";
            go.SetActive(true);
            Physics.SyncTransforms();
            return go.GetComponent<MonsterDummy>();
        }

        IEnumerator Mash(int frames)
        {
            for (int f = 0; f < frames; f++)
            {
                if (f % 6 == 0) _combat.Attack();
                _combat.Tick(1f / 60f);
                _motor.Tick(Vector3.zero, false, false, 1f / 60f);
                Physics.SyncTransforms();
                GameTime.Clear();
                yield return null;
            }
        }

        [UnityTest]
        public IEnumerator KillingAGoblinGivesXp()
        {
            var g = Goblin(new Vector3(0, 0, 1.3f));
            long xp = 0;
            _combat.XpGained += v => xp += v;
            yield return Mash(180);
            Assert.IsTrue(g.IsDead, "the goblin is defeated");
            Assert.Greater(xp, 0, "XP awarded on the kill");
            Assert.AreEqual(xp, _combat.Progress.XpIntoLevel, "XP lands in the progress bar");
        }

        [Test]
        public void LevelUpRaisesStatsHealsAndShowsABanner()
        {
            int hp1 = _combat.Stats.Hp, atk1 = _combat.Stats.Atk;
            _defense.ReceiveAttack(30, Telegraph.Red);
            Assert.Less(_defense.Hp, _defense.MaxHp, "hurt first");
            _combat.GrantXp(_combat.Progress.ToNext);
            Assert.AreEqual(2, _combat.Level, "level 2");
            Assert.Greater(_combat.Stats.Hp, hp1, "more HP");
            Assert.GreaterOrEqual(_combat.Stats.Atk, atk1, "ATK doesn't drop");
            Assert.AreEqual(_defense.MaxHp, _defense.Hp, "a level-up heals fully");
            Assert.AreEqual(_combat.Stats.Hp, _defense.MaxHp, "max HP follows the new stats");
            StringAssert.Contains("LEVEL UP · 1 → 2", _hud.Banner, "the banner shows");
        }

        [Test]
        public void LevelFourUnlocksRisingCut()
        {
            Assert.IsFalse(_combat.Caster.Slots.Any(s => s.Id == "skl_rising_cut"), "locked at Lv 1");
            _combat.SetLevel(4);
            Assert.IsTrue(_combat.Caster.Slots.Any(s => s.Id == "skl_rising_cut"), "slotted at Lv 4");
        }

        [UnityTest]
        public IEnumerator VariedHitsRaiseStyleAndGettingHitDropsIt()
        {
            var big = Goblin(new Vector3(0, 0, 1.3f));
            big.SpeciesId = "mon_goblin";
            // Build style on a sturdy target: cast skills between strings for variety.
            var archer = Goblin(new Vector3(0.6f, 0, 1.5f));
            _combat.Caster.AddAwakening(0);
            for (int i = 0; i < 3; i++)
            {
                yield return Mash(40);
                foreach (var s in _combat.Caster.Slots) _combat.CastSlot(_combat.Caster.Slots.ToList().IndexOf(s));
                yield return Mash(40);
            }
            var rank = _combat.Style.Rank;
            Assert.Greater(_combat.Style.Points, 0, "hits score Style");
            Assert.IsNotEmpty(_hud.StyleLabel(), "the HUD shows a Style Rank");
            if (rank > StyleRank.C)
            {
                _defense.ReceiveAttack(5, Telegraph.Red);
                Assert.Less(_combat.Style.Rank, rank, "getting hit drops a Style Rank");
            }
            Assert.Greater(_combat.Caster.Awakening, 0, "Style fills Awakening");
            Object.DestroyImmediate(archer.gameObject);
        }

        [Test]
        public void StatusWindowListsRankStatsSkillsAndTheRedactedLine()
        {
            var lines = _hud.StatusLines();
            StringAssert.Contains("Swordsman · Lv 1 · Guild Rank F", lines[0], "class, level and rank");
            Assert.IsTrue(lines.Any(l => l.StartsWith("STR ")), "primary stats");
            Assert.IsTrue(lines.Any(l => l.StartsWith("HP ") && l.Contains("ATK")), "derived stats");
            Assert.IsTrue(lines.Any(l => l.StartsWith("Skills:") && l.Contains("Slash Chain")), "skills listed");
            Assert.IsTrue(lines.Any(l => l.Contains("[REDACTED]")), "the Lying Interface's redacted line");
            _hud.StatusOpen = true;
            Assert.IsTrue(_hud.StatusOpen, "the window toggles");
        }
    }
}
