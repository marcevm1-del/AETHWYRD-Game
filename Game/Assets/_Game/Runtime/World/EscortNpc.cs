using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// An NPC you can escort (an "escort" objective naming them). With the job active, talk to them to set off: they
    /// walk their route, wait whenever you fall behind, and get ambushed partway (the attackers come for you).
    /// Reaching the end completes the objective; afterwards they head home so the job can be taken again another day.
    /// </summary>
    [RequireComponent(typeof(QuestGiver))]
    public sealed class EscortNpc : MonoBehaviour
    {
        [SerializeField] Vector3[] route = new Vector3[0];
        [SerializeField] float speed = 2.2f;
        [SerializeField] float leashToPlayer = 12f;
        /// <summary>Ambushes along the route: "fraction|species:count,…" e.g. "0.45|mon_goblin:3".</summary>
        [SerializeField] string[] ambushes = { "0.4|mon_goblin:3", "0.75|mon_goblin:2" };
        /// <summary>Things that travel with the NPC (their name label and quest marker).</summary>
        [SerializeField] Transform[] followers = new Transform[0];
        Vector3 _lastPos;

        QuestGiver _giver;
        Vector3 _home;
        Quaternion _homeRot;
        int _leg;
        float _travelled, _length;
        readonly HashSet<int> _sprung = new HashSet<int>();
        readonly List<MonsterDummy> _ambushers = new List<MonsterDummy>();

        public Vector3[] Route { get => route; set => route = value; }
        public string[] Ambushes { get => ambushes; set => ambushes = value; }
        public Transform[] Followers { get => followers; set => followers = value; }
        public bool Travelling { get; private set; }
        public bool Waiting { get; private set; }
        public float Progress => _length > 0 ? _travelled / _length : 0f;
        public IReadOnlyList<MonsterDummy> Ambushers => _ambushers;

        void Awake()
        {
            _giver = GetComponent<QuestGiver>();
            _home = transform.position;
            _homeRot = transform.rotation;
            _lastPos = transform.position;
        }

        void LateUpdate()
        {
            Vector3 moved = transform.position - _lastPos;
            if (moved.sqrMagnitude > 0f) foreach (var f in followers) if (f != null) f.position += moved;
            _lastPos = transform.position;
        }

        /// <summary>An active escort job for this NPC that isn't done yet.</summary>
        public bool JobWaiting(PlayerQuests q) => q.Log.Active.Any(p =>
        {
            var data = q.Log.Quest(p.QuestId);
            return data != null && data.Objectives.Select((o, i) => (o, i)).Any(x => x.o.Kind == "escort" && x.o.Target == _giver.NpcId && p.Counts[x.i] < 1);
        });

        public void SetOff()
        {
            if (Travelling || route.Length == 0) return;
            Travelling = true; _leg = 0; _travelled = 0f; _sprung.Clear();
            var pts = new[] { _home }.Concat(route).ToArray();
            _length = 0f;
            for (int i = 1; i < pts.Length; i++) _length += Vector3.Distance(Flat(pts[i - 1]), Flat(pts[i]));
            Toast($"{_giver.DisplayName} sets off. Stay close.");
        }

        void Update()
        {
            if (!Travelling) return;
            _ambushers.RemoveAll(m => m == null || m.IsDead);
            var player = FindFirstObjectByType<PlayerQuests>();
            // Wait for the player, and while an ambush is still on its feet.
            Waiting = player == null || Vector3.Distance(Flat(player.transform.position), Flat(transform.position)) > leashToPlayer || _ambushers.Count > 0;
            if (Waiting) return;
            Vector3 target = route[_leg];
            Vector3 to = Flat(target) - Flat(transform.position);
            float step = speed * Time.deltaTime;
            if (to.magnitude <= step)
            {
                transform.position = new Vector3(target.x, transform.position.y, target.z);
                _travelled += to.magnitude;
                if (++_leg >= route.Length) { Arrive(player); return; }
            }
            else
            {
                transform.position += to.normalized * step;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(to), 360f * Time.deltaTime);
                _travelled += step;
            }
            for (int i = 0; i < ambushes.Length; i++)
            {
                var parts = ambushes[i].Split('|');
                if (_sprung.Contains(i) || parts.Length != 2 || !float.TryParse(parts[0], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var at) || Progress < at) continue;
                _sprung.Add(i);
                Ambush(parts[1]);
            }
        }

        void Ambush(string spec)
        {
            Toast("Ambush!");
            Vector3 fwd = transform.forward;
            int k = 0;
            foreach (var unit in spec.Split(','))
            {
                var p = unit.Trim().Split(':');
                if (p.Length != 2 || !int.TryParse(p[1], out var count)) continue;
                for (int i = 0; i < count; i++, k++)
                {
                    float side = (k % 2 == 0 ? 1 : -1) * (6f + k);
                    var at = transform.position + fwd * 7f + Vector3.Cross(Vector3.up, fwd) * side;
                    at.y = 0;
                    var m = MonsterSpawner.Spawn(MonsterSpawner.SceneTemplates, p[0], at, transform.position);
                    if (m != null) _ambushers.Add(m);
                }
            }
        }

        void Arrive(PlayerQuests player)
        {
            Travelling = false;
            if (player != null) player.Log.OnEscort(_giver.NpcId);
            Toast($"{_giver.DisplayName} arrived safely.");
            Invoke(nameof(GoHome), 8f);
        }

        void GoHome()
        {
            foreach (var m in _ambushers) if (m != null) Destroy(MonsterSpawner.RootOf(m));
            _ambushers.Clear();
            transform.SetPositionAndRotation(_home, _homeRot);
        }

        static Vector3 Flat(Vector3 v) { v.y = 0; return v; }

        static void Toast(string text)
        {
            var inv = FindFirstObjectByType<PlayerInventory>();
            if (inv != null) inv.Toast(text, 4f);
        }
    }
}
