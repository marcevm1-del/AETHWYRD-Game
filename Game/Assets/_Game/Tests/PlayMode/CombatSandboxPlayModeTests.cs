using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Wave A2: the reaction and sandbox rules in real Unity. Dummies are built in code (no scene), a Fire-then-Ice hit
    /// sequence on a real MonsterDummy reads out Thermal Shock, and the Core CombatSandbox run with the live
    /// combat_tuning.json agrees with it. Nothing here needs the Wave A3 wiring.
    /// </summary>
    public sealed class CombatSandboxPlayModeTests
    {
        GameObject _ground;

        [SetUp]
        public void SetUp()
        {
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            Object.DestroyImmediate(_ground);
        }

        static MonsterDummy Spawn(string species, Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = species;
            go.transform.position = pos + Vector3.up;
            go.SetActive(false);                       // set the species before Awake reads it
            go.AddComponent<MonsterDummy>().SpeciesId = species;
            go.SetActive(true);
            Physics.SyncTransforms();
            return go.GetComponent<MonsterDummy>();
        }

        [UnityTest]
        public IEnumerator FireThenIceOnADummyReadsOutThermalShock()
        {
            var d = Spawn("mon_goblin", new Vector3(0, 0, 4));
            yield return null;
            Assert.AreEqual(Element.None, d.Aura, "a fresh dummy has no aura");
            Assert.AreEqual(Reaction.None, d.ApplyElement(Element.Fire), "the first hit only sets the aura");
            Assert.AreEqual(Element.Fire, d.Aura, "fire aura is up");
            Assert.AreEqual(Reaction.ThermalShock, d.ApplyElement(Element.Ice), "Fire then Ice is Thermal Shock");
            Assert.AreEqual(Element.None, d.Aura, "the reaction consumed the aura");
        }

        [UnityTest]
        public IEnumerator WaterThenIceFreezesAndAHeavyHitShattersForTheTunedBonus()
        {
            var t = AscendData.Db.Tuning.Reactions;
            var d = Spawn("mon_goblin", new Vector3(0, 0, 4));
            yield return null;
            d.ApplyElement(Element.Water);
            Assert.AreEqual(Reaction.Freeze, d.ApplyElement(Element.Ice), "Water then Ice is Freeze");
            Assert.AreEqual(1.0, d.ReactionHitMultiplier(HitWeight.Light), 1e-9, "a light hit does not shatter");
            Assert.AreEqual(t.ShatterBonus, d.ReactionHitMultiplier(HitWeight.Heavy), 1e-9, "a heavy hit shatters for combat_tuning.json shatterBonus");
            Assert.AreEqual(1.0, d.ReactionHitMultiplier(HitWeight.Heavy), 1e-9, "the shatter ended the freeze");
        }

        [UnityTest]
        public IEnumerator TheSameAuraReactionsAsTheCoreTableForEveryPair()
        {
            // A real dummy must agree with the data-driven table for every element pair (backward compatibility).
            var elements = ((Element[])System.Enum.GetValues(typeof(Element))).Where(e => e != Element.None).ToArray();
            var d = Spawn("mon_goblin", new Vector3(0, 0, 4));
            yield return null;
            foreach (var a in elements)
                foreach (var b in elements)
                {
                    d.ApplyElement(a);                                  // set (or react into) an aura; clear the leftovers below
                    var expect = Elements.React(d.Aura, b);
                    var got = d.ApplyElement(b);
                    Assert.AreEqual(expect, got, $"{a} then {b}: dummy reaction equals Elements.React on its aura");
                    d.ApplyElement(Element.None);
                }
        }

        [Test]
        public void TheCoreSandboxWithLiveTuningReadsOutFireThenIce()
        {
            var db = AscendData.Db;
            var sb = new CombatSandbox(db.Tuning, new DeterministicRandom(1), db.ReactionTable, db.BossWeakPoints);
            sb.AddDummy(new SandboxDummySpec { Id = "d", SpeciesId = "mon_goblin", Hp = 100000, Weakness = Element.None });
            var r = sb.Run(new[]
            {
                new SandboxHit { TargetId = "d", Element = Element.Fire },
                new SandboxHit { TargetId = "d", Element = Element.Ice, WaitSec = 0.5 },
            });
            Assert.AreEqual(2, r.Hits.Count, "two hits scripted");
            Assert.AreEqual(Reaction.None, r.Hits[0].Reaction, "fire sets the aura");
            Assert.AreEqual(Reaction.ThermalShock, r.Hits[1].Reaction, "ice reads out Thermal Shock");
            Assert.AreEqual(0.5, r.Time, 1e-9, "the clock advanced by the scripted wait");
            Assert.AreEqual(Element.None, r.Dummies[0].Aura, "aura consumed");
            Assert.Less(r.Dummies[0].Hp, 100000, "the dummy took damage");
            Assert.GreaterOrEqual(r.Hits[1].TotalExtraMult, 1.0, "the reaction never lowers damage here");
        }

        [Test]
        public void TheSandboxAndARealDummyAgreeOnTheReactionSequence()
        {
            var db = AscendData.Db;
            var sb = new CombatSandbox(db.Tuning, new DeterministicRandom(1), db.ReactionTable, db.BossWeakPoints);
            sb.AddDummy(new SandboxDummySpec { Id = "d", SpeciesId = "mon_goblin", Hp = 100000, Weakness = Element.None });
            var seq = new[] { Element.Water, Element.Ice, Element.Fire, Element.Wind, Element.Lightning, Element.Earth };
            var fromSandbox = sb.Run(seq.Select(e => new SandboxHit { TargetId = "d", Element = e, WaitSec = 0.1 })).Hits.Select(h => h.Reaction).ToArray();
            var state = new ReactionState(db.Tuning.Reactions, db.ReactionTable);
            double t = 0;
            var fromState = seq.Select(e => { t += 0.1; return state.ApplyElement(e, t); }).ToArray();
            CollectionAssert.AreEqual(fromState, fromSandbox, "sandbox readout reactions equal ReactionState's");
        }
    }
}
