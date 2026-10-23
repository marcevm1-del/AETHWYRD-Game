using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Ring 0 week 8: Swordsman skills, the Ultimate, the Fire Bomb and the Firestorm reaction, in Unity frames.</summary>
    public sealed class SkillsPlayModeTests
    {
        GameObject _ground, _player;
        PlayerMotor _motor;
        PlayerCombat _combat;

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
            _player.AddComponent<PlayerDefense>();
            Physics.SyncTransforms();
            for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, 1f / 60f);
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var t in new System.Type[] { typeof(MonsterDummy), typeof(DamageNumber), typeof(CombatProjectile), typeof(FirestormZone), typeof(ReactionPopup) })
                foreach (var o in Object.FindObjectsByType(t, FindObjectsSortMode.None)) Object.DestroyImmediate(((Component)o).gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
        }

        /// <summary>A sturdy goblin archer with no AI, so skills can be measured on it.</summary>
        MonsterDummy Target(Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = pos + Vector3.up;
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = "mon_goblin_archer";
            go.SetActive(true);
            Physics.SyncTransforms();
            return go.GetComponent<MonsterDummy>();
        }

        int SlotOf(string skillId) => _combat.Caster.Slots.ToList().FindIndex(s => s.Id == skillId);

        IEnumerator Frames(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _combat.Tick(1f / 60f);
                _motor.Tick(Vector3.zero, false, false, 1f / 60f);
                Physics.SyncTransforms();
                GameTime.Clear();
                yield return null;
            }
        }

        [UnityTest]
        public IEnumerator AirSlashWaveHitsAtRangeAndAppliesWind()
        {
            var t = Target(new Vector3(0, 0, 6));
            int slot = SlotOf("skl_air_slash");
            Assert.GreaterOrEqual(slot, 0, "Air Slash is slotted at Lv 1");
            double mp = _combat.Caster.Mp;
            Assert.AreEqual(CastResult.Ok, _combat.CastSlot(slot));
            Assert.Less(_combat.Caster.Mp, mp, "MP spent");
            yield return Frames(40);
            Assert.Less(t.Hp, t.MaxHp, "the wave hit a target 6 m away");
            Assert.AreEqual(Element.Wind, t.Aura, "Wind aura applied");
            Assert.AreEqual(CastResult.Cooldown, _combat.CastSlot(slot), "on cooldown after casting");
        }

        [UnityTest]
        public IEnumerator FireBombOnAWindAuraMakesAFirestormThatKeepsBurning()
        {
            var t = Target(new Vector3(0, 0, 6));
            Reaction seen = Reaction.None;
            _combat.ReactionTriggered += (_, r) => seen = r;
            _combat.CastSlot(SlotOf("skl_air_slash"));
            yield return Frames(40);
            Assert.AreEqual(Element.Wind, t.Aura, "Wind first");

            int bombs = _combat.FireBombs;
            Assert.IsTrue(_combat.ThrowFireBomb(), "throws a bomb");
            Assert.AreEqual(bombs - 1, _combat.FireBombs, "one bomb used");
            yield return Frames(60);
            Assert.AreEqual(Reaction.Firestorm, seen, "Fire on a Wind aura is a Firestorm");
            var zone = Object.FindFirstObjectByType<FirestormZone>();
            Assert.IsNotNull(zone, "a burning zone appears");
            int hpAfterBurst = t.Hp;
            yield return Frames(90);
            Assert.Greater(zone != null ? zone.Ticks : 99, 0, "the zone ticks");
            Assert.Less(t.Hp, hpAfterBurst, "the Firestorm keeps burning the target");
        }

        [UnityTest]
        public IEnumerator FlashStepDashesForwardAndStrikes()
        {
            var t = Target(new Vector3(0, 0, 5.5f));
            Vector3 start = _player.transform.position;
            Assert.AreEqual(CastResult.Ok, _combat.CastSlot(SlotOf("skl_flash_step")));
            yield return Frames(40);
            float moved = Vector3.Distance(new Vector3(start.x, 0, start.z), new Vector3(_player.transform.position.x, 0, _player.transform.position.z));
            Assert.Greater(moved, 3f, $"dashed forward (moved {moved:0.0} m)");
            Assert.Less(t.Hp, t.MaxHp, "the dash strike hit the target");
        }

        [UnityTest]
        public IEnumerator UltimateNeedsAwakeningThenHitsManyTimes()
        {
            var t = Target(new Vector3(0, 0, 2.5f));
            Assert.AreEqual(CastResult.NoAwakening, _combat.CastUltimate(), "empty Awakening");
            _combat.Caster.AddAwakening(1000);
            int hits = 0;
            _combat.HitLanded += (_, __) => hits++;
            Assert.AreEqual(CastResult.Ok, _combat.CastUltimate(), "full Awakening casts Thousand Petal Blade");
            yield return Frames(400);
            Assert.GreaterOrEqual(hits, 10, $"the ultimate lands most of its 12 strikes (landed {hits})");
            Assert.AreEqual(0, _combat.Caster.Awakening, 1e-6, "Awakening spent");
        }

        [Test]
        public void LockedSkillsAreNotSlotted()
        {
            Assert.IsFalse(_combat.Caster.Slots.Any(s => s.Id == "skl_rising_cut"), "Rising Cut (Lv 4) is not slotted at Lv 1");
            Assert.LessOrEqual(_combat.Caster.Slots.Count, 4, "four slots at most");
        }

        [UnityTest]
        public IEnumerator HitsFillAwakening()
        {
            Target(new Vector3(0, 0, 1.3f));
            double before = _combat.Caster.Awakening;
            _combat.Attack();
            yield return Frames(30);
            Assert.Greater(_combat.Caster.Awakening, before, "landing hits fills the Awakening meter");
        }
    }
}
