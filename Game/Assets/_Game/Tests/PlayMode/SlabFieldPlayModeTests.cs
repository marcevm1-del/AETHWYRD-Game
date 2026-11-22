using System.Collections;
using System.Collections.Generic;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Can a boss litter its arena with debris without breaking the monsters in it?
    ///
    /// The reworked Vaultbreaker (13_Production/monster_concepts_2026-11-22.md) sheds slabs of its own armour as it
    /// fights, and they stay as cover. That only works if creatures can still move through the result. Monsters here
    /// do not use a NavMesh: MonsterController steps with `transform.position += Blocked(dir, speed * dt)`, and
    /// Blocked slides along a wall at most TWICE before returning zero. Two slides is fine against one wall and is
    /// the obvious thing to fail in a cluster, so this measures it rather than assuming either way.
    ///
    /// It also checks the quieter half: MonsterController.Solid treats any surface with normal.y > 0.6 as walkable
    /// ground, so a slab lying flat is not an obstacle at all - which decides whether debris has to land on edge to
    /// be cover.
    /// </summary>
    public sealed class SlabFieldPlayModeTests
    {
        GameObject _ground, _player;
        readonly List<GameObject> _slabs = new List<GameObject>();

        const float SlabWide = 0.5f;      // the concept's half-metre slab
        const float SlabThick = 0.05f;    // 40-60 mm of laminated plate

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            AggroDirector.Reset();
            MonsterController.ResetTactics();
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
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            foreach (var s in _slabs) if (s != null) Object.DestroyImmediate(s);
            _slabs.Clear();
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
            MonsterController.ResetTactics();
            GameTime.Clear();
            CameraShake.Reset();
        }

        /// <summary>A field of slabs between the monster and the player. upright=false lays them flat on the ground.</summary>
        void Field(int cols, int rows, float spacing, bool upright)
        {
            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    var s = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    s.name = "slab";
                    s.transform.localScale = upright
                        ? new Vector3(SlabWide, SlabWide, SlabThick)
                        : new Vector3(SlabWide, SlabThick, SlabWide);
                    s.transform.position = new Vector3(
                        (c - (cols - 1) * 0.5f) * spacing,
                        upright ? SlabWide * 0.5f : SlabThick * 0.5f,
                        2.5f + r * spacing);
                    s.transform.rotation = Quaternion.Euler(0, (c * 37 + r * 19) % 90, 0);
                    _slabs.Add(s);
                }
            }
            Physics.SyncTransforms();
        }

        /// <summary>Spawns a goblin behind the field, alerts it, and reports how far it closed in `frames`.</summary>
        IEnumerator Chase(float startZ, int frames, System.Action<float, float, bool> report)
        {
            var dummy = MonsterSpawner.Spawn(null, "mon_goblin", new Vector3(0, 0, startZ), _player.transform.position);
            Assert.IsNotNull(dummy, "spawn failed");
            var ctrl = dummy.GetComponent<MonsterController>();
            yield return null;
            if (ctrl != null && ctrl.Brain != null) ctrl.Brain.Alert();

            var start = dummy.transform.position;
            var last = start;
            float stalled = 0f, worstStall = 0f;
            for (int i = 0; i < frames; i++)
            {
                yield return null;
                if (dummy == null) break;
                var now = dummy.transform.position;
                // Only count standing still as a jam while it is still FAR from the player. A monster that has
                // arrived and is attacking does not move either, and the first version of this test called that a
                // jam - it fired on the open-ground control, which is how the mistake was caught.
                bool farOut = Vector3.Distance(now, _player.transform.position) > 4.0f;
                if (farOut && (now - last).sqrMagnitude < 1e-6f) { stalled += Time.captureDeltaTime; worstStall = Mathf.Max(worstStall, stalled); }
                else stalled = 0f;
                last = now;
            }
            float closed = start.z - (dummy != null ? dummy.transform.position.z : start.z);
            float remaining = dummy != null ? Vector3.Distance(dummy.transform.position, _player.transform.position) : -1f;
            report(closed, remaining, worstStall > 1.5f);
            if (dummy != null) Object.DestroyImmediate(dummy.gameObject);
        }

        [UnityTest]
        public IEnumerator OpenGround_MonsterClosesOnThePlayer()
        {
            float closed = 0f, remaining = 0f; bool stalled = false;
            yield return Chase(9f, 420, (c, r, s) => { closed = c; remaining = r; stalled = s; });
            Debug.Log(string.Format("[slabs] control: closed {0:0.00} m, {1:0.00} m remaining, stalled={2}", closed, remaining, stalled));
            Assert.Greater(closed, 2.0f, "control failed: the monster does not close on open ground, so the slab result would mean nothing");
            Assert.IsFalse(stalled, "control monster stalled on open ground");
        }

        [UnityTest]
        public IEnumerator FlatSlabs_AreNotObstaclesAtAll()
        {
            Field(6, 3, 0.9f, upright: false);
            float closed = 0f, remaining = 0f; bool stalled = false;
            yield return Chase(9f, 420, (c, r, s) => { closed = c; remaining = r; stalled = s; });
            Debug.Log(string.Format("[slabs] flat field ({0} slabs): closed {1:0.00} m, {2:0.00} m remaining, stalled={3}",
                _slabs.Count, closed, remaining, stalled));
            Assert.Greater(closed, 2.0f, "a flat slab field stopped the monster, which Solid() says should not happen");
        }

        [UnityTest]
        public IEnumerator UprightSlabField_MonsterStillReachesThePlayer()
        {
            Field(6, 4, 0.9f, upright: true);
            float closed = 0f, remaining = 0f; bool stalled = false;
            yield return Chase(11f, 600, (c, r, s) => { closed = c; remaining = r; stalled = s; });
            Debug.Log(string.Format("[slabs] upright field ({0} slabs): closed {1:0.00} m, {2:0.00} m remaining, stalled={3}",
                _slabs.Count, closed, remaining, stalled));
            Assert.IsFalse(stalled, "the monster jammed in the debris for over 1.5 s: Blocked() slides twice and then stops, "
                                  + "so a cluster traps it. The Vaultbreaker's shed slabs need avoidance work before they can be cover.");
            Assert.Greater(closed, 3.0f, "the monster made almost no ground through the slab field");
        }

        [UnityTest]
        public IEnumerator DenseUprightSlabs_ReportWhetherTheyTrap()
        {
            Field(7, 5, 0.65f, upright: true);     // tight enough that gaps are near the body width
            float closed = 0f, remaining = 0f; bool stalled = false;
            yield return Chase(11f, 600, (c, r, s) => { closed = c; remaining = r; stalled = s; });
            Debug.Log(string.Format("[slabs] DENSE field ({0} slabs, 0.65 m spacing): closed {1:0.00} m, {2:0.00} m remaining, stalled={3}",
                _slabs.Count, closed, remaining, stalled));
            Assert.Greater(closed, 0.5f, "the monster could not move at all in dense debris");
        }
    }
}
