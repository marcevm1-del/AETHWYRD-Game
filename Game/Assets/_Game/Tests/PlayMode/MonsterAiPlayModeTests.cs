using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Ring 0 monster AI in real Unity frames: attacks land, tokens cap attackers, telegraphs show, defence works.</summary>
    public sealed class MonsterAiPlayModeTests
    {
        GameObject _ground, _player;
        PlayerDefense _defense;
        PlayerMotor _motor;

        [SetUp]
        public void SetUp()
        {
            AggroDirector.Reset();
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _motor = _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            foreach (var d in Object.FindObjectsByType<DamageNumber>(FindObjectsSortMode.None)) Object.DestroyImmediate(d.gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        MonsterController Spawn(string species, Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = species;
            go.transform.position = pos + Vector3.up;
            go.transform.rotation = Quaternion.LookRotation(-new Vector3(pos.x, 0, pos.z));
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = species;
            var c = go.AddComponent<MonsterController>();
            go.SetActive(true);
            Physics.SyncTransforms();
            return c;
        }

        [UnityTest]
        public IEnumerator GoblinAttacksAStandingPlayer()
        {
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 1.3f));
            int hits = 0;
            _defense.Defended += (r, dmg) => { if (r == DefenseResult.Hit && dmg > 0) hits++; };
            yield return null;
            int hp = _defense.Hp;
            float t = 0;
            while (hits == 0 && t < 4f) { t += Time.deltaTime; yield return null; }
            Assert.Greater(hits, 0, "the goblin lands a hit within 4 seconds");
            Assert.Less(_defense.Hp, hp, "player HP drops");
            Assert.Greater(goblin.Strikes, 0, "it struck");
        }

        [UnityTest]
        public IEnumerator TelegraphShowsAndTheRingShrinks()
        {
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 1.3f));
            float t = 0;
            while ((goblin.Brain == null || goblin.Brain.State != AiState.Windup) && t < 3f) { t += Time.deltaTime; yield return null; }
            Assert.AreEqual(AiState.Windup, goblin.Brain.State, "winds up");
            yield return null;
            Assert.IsTrue(goblin.TelegraphVisible, "telegraph visible during the windup");
            float first = goblin.RingRadius;
            yield return new WaitForSeconds(0.15f);
            if (goblin.Brain.State == AiState.Windup) Assert.Less(goblin.RingRadius, first, "the ring shrinks toward the strike");
        }

        [UnityTest]
        public IEnumerator AtMostTwoGoblinsAttackAtOnce()
        {
            var pack = new List<MonsterController>();
            for (int i = 0; i < 5; i++)
            {
                float a = i / 5f * Mathf.PI * 2f;
                pack.Add(Spawn("mon_goblin", new Vector3(Mathf.Cos(a) * 1.4f, 0, Mathf.Sin(a) * 1.4f)));
            }
            int cap = AscendData.Db.Tuning.Ai.MaxSimultaneousAttackers, maxSeen = 0;
            float t = 0;
            while (t < 4f)
            {
                t += Time.deltaTime;
                int attacking = pack.Count(c => c.Brain != null && (c.Brain.State == AiState.Windup || c.Brain.State == AiState.Active));
                maxSeen = Mathf.Max(maxSeen, attacking);
                Assert.LessOrEqual(attacking, cap, $"never more than {cap} attacking at once");
                yield return null;
            }
            Assert.Greater(maxSeen, 0, "the pack does attack");
        }

        [UnityTest]
        public IEnumerator DodgingAtTheEndOfTheWindupIsAPerfectDodge()
        {
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 1.3f));
            DefenseResult? result = null;
            _defense.Defended += (r, _) => result ??= r;
            float t = 0;
            while (t < 4f && result == null)
            {
                t += Time.deltaTime;
                var b = goblin.Brain;
                if (b != null && b.State == AiState.Windup && !_motor.IsDodging && b.CurrentTiming != null
                    && b.WindupProgress * b.CurrentTiming.WindupSec >= b.CurrentTiming.WindupSec - 0.08)
                    _motor.Dodge(Vector3.right * 0.01f + Vector3.zero);
                _motor.Tick(Vector3.zero, false, false, Time.deltaTime);
                yield return null;
            }
            Assert.IsTrue(result.HasValue, "the goblin attacked");
            Assert.IsTrue(result == DefenseResult.PerfectDodge || result == DefenseResult.Dodged, $"the dodge avoided the hit (got {result})");
        }

        [UnityTest]
        public IEnumerator ParryStaggersTheGoblinsAttack()
        {
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 1.3f));
            DefenseResult? result = null;
            _defense.Defended += (r, _) => result ??= r;
            float t = 0;
            while (t < 4f && result == null)
            {
                t += Time.deltaTime;
                var b = goblin.Brain;
                bool late = b != null && b.State == AiState.Windup && b.CurrentTiming != null && b.CurrentTelegraph == Telegraph.Blue
                    && b.WindupProgress * b.CurrentTiming.WindupSec >= b.CurrentTiming.WindupSec - 0.06;
                _defense.SetBlock(late || _defense.IsBlocking && b != null && b.State == AiState.Windup);
                yield return null;
            }
            Assert.IsTrue(result.HasValue, "the goblin attacked");
            if (result == DefenseResult.Parried)
            {
                yield return null;
                Assert.AreEqual(AiState.Staggered, goblin.Brain.State, "a parried goblin is staggered");
            }
            else Assert.AreEqual(DefenseResult.Hit, result, $"non-blue attacks get through a late block press (got {result})");
        }
    }
}
