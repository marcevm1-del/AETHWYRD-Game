using System;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Death and respawn (systems.md §10): the death screen names what killed you, its rank and its field-note tip;
    /// the difficulty's penalty is applied (Adventurer drops 10% of carried money in a glowing lantern at the death spot —
    /// walk over it to recover it; only the newest lantern stays); after a short pause you return to the last attuned
    /// waystone at full health. Hardcore deaths are final (a "permadeath" screen; Ring 0 still lets you restart).
    /// </summary>
    [RequireComponent(typeof(PlayerDefense))]
    public sealed class PlayerRespawn : MonoBehaviour
    {
        public const float DeathScreenSec = 2.5f;

        PlayerDefense _defense;
        PlayerInventory _inv;
        PlayerCombat _combat;
        Vector3 _point;
        Quaternion _facing;
        float _respawnAt = -1f;

        public bool IsDead => _respawnAt >= 0f;
        public string KilledBy { get; private set; }
        public string KillerRank { get; private set; }
        public string Tip { get; private set; }
        public DeathPenalty LastPenalty { get; private set; }
        public CoinLantern Lantern { get; private set; }
        public int Deaths { get; private set; }
        public Vector3 Point => _point;
        public Quaternion Facing => _facing;
        public string WaystoneId { get; private set; }
        /// <summary>After returning to the waystone (the save system autosaves here).</summary>
        public event Action Respawned;
        /// <summary>A waystone was attuned (autosave).</summary>
        public event Action PointSet;

        void Awake()
        {
            _defense = GetComponent<PlayerDefense>();
            _inv = GetComponent<PlayerInventory>();
            _combat = GetComponent<PlayerCombat>();
            _point = transform.position;
            _facing = transform.rotation;
            _defense.Died += OnDied;
        }

        void OnDestroy() { if (_defense != null) _defense.Died -= OnDied; }

        /// <summary>A waystone attunes here.</summary>
        public void SetPoint(Vector3 position, Quaternion facing, string waystoneId = null)
        {
            _point = position; _facing = facing; WaystoneId = waystoneId;
            PointSet?.Invoke();
        }

        /// <summary>From a save: death count, respawn point (you continue there) and any unrecovered lantern.</summary>
        public void Restore(int deaths, string waystoneId, Vector3? point, float yaw, Vector3? lantern, long lanternCopper)
        {
            Deaths = deaths; WaystoneId = waystoneId;
            if (point.HasValue) { _point = point.Value; _facing = Quaternion.Euler(0, yaw, 0); Teleport(); }
            foreach (var w in FindObjectsByType<Waystone>(FindObjectsSortMode.None)) w.MarkAttuned(w.Id == waystoneId);
            if (Lantern != null) Destroy(Lantern.gameObject);
            Lantern = lantern.HasValue && lanternCopper > 0 ? CoinLantern.Spawn(lantern.Value - Vector3.up * 0.5f, lanternCopper) : null;
        }

        void OnDied(MonsterDummy killer)
        {
            Deaths++;
            var db = AscendData.Db;
            KilledBy = "something unseen"; KillerRank = "?"; Tip = "Watch the telegraph colour: blue can be parried, red only dodged.";
            if (killer != null && db.Species.TryGetValue(killer.SpeciesId, out var s))
            {
                KilledBy = s.Name; KillerRank = s.Rank;
                if (!string.IsNullOrEmpty(s.FieldNote)) Tip = s.FieldNote;
            }
            if (_inv != null)
            {
                LastPenalty = DeathRules.Apply(_inv.Difficulty, _inv.Items, _combat != null ? _combat.Progress : null);
                if (LastPenalty.DroppedCopper > 0)
                {
                    if (Lantern != null) Destroy(Lantern.gameObject); // only the newest pile stays
                    Lantern = CoinLantern.Spawn(transform.position, LastPenalty.DroppedCopper);
                }
            }
            GameTime.Clear();
            _respawnAt = Time.unscaledTime + DeathScreenSec;
        }

        void Update()
        {
            if (_respawnAt >= 0f && Time.unscaledTime >= _respawnAt) Respawn();
        }

        public void Respawn()
        {
            _respawnAt = -1f;
            Teleport();
            _defense.Revive();
            AggroDirector.Reset();
            Respawned?.Invoke();
        }

        void Teleport()
        {
            var cc = GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false; // teleporting a CharacterController needs it off
            transform.SetPositionAndRotation(_point, _facing);
            if (cc != null) cc.enabled = true;
            Physics.SyncTransforms();
        }
    }

    /// <summary>Money dropped at a death spot (Adventurer and Veteran): a glowing blue lantern; walk over it to recover it.</summary>
    public sealed class CoinLantern : MonoBehaviour
    {
        public const float PickupRadius = 1.3f;
        public long Copper { get; private set; }

        public static CoinLantern Spawn(Vector3 at, long copper)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = "CoinLantern";
            Destroy(go.GetComponent<Collider>());
            go.transform.position = at + Vector3.up * 0.5f;
            go.transform.localScale = new Vector3(0.3f, 0.35f, 0.3f);
            var r = go.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Universal Render Pipeline/Unlit") ?? Shader.Find("Sprites/Default"));
            r.material.color = new Color(0.4f, 0.75f, 1f);
            var l = go.AddComponent<CoinLantern>();
            l.Copper = copper;
            return l;
        }

        void Update()
        {
            transform.position += Vector3.up * Mathf.Sin(Time.time * 2f) * 0.002f;
            var inv = FindFirstObjectByType<PlayerInventory>();
            if (inv == null) return;
            var resp = inv.GetComponent<PlayerRespawn>();
            if (resp != null && resp.IsDead) return;
            Vector3 d = inv.transform.position - transform.position; d.y = 0;
            if (d.magnitude > PickupRadius) return;
            inv.Items.AddCopper(Copper);
            inv.Toast($"Recovered {Money.Format(Copper, AscendData.Db.World.Currency)}");
            Destroy(gameObject);
        }
    }

    /// <summary>A waystone (Canon: waystone respawns): walking up to it attunes it as your respawn point.</summary>
    public sealed class Waystone : MonoBehaviour
    {
        public const float AttuneRadius = 2.5f;
        public bool Attuned { get; private set; }
        public string Id => name;
        public void MarkAttuned(bool on) => Attuned = on;

        void Update()
        {
            if (Attuned) return;
            var resp = FindFirstObjectByType<PlayerRespawn>();
            if (resp == null) return;
            Vector3 d = resp.transform.position - transform.position; d.y = 0;
            if (d.magnitude > AttuneRadius) return;
            foreach (var w in FindObjectsByType<Waystone>(FindObjectsSortMode.None)) w.Attuned = w == this;
            if (resp.TryGetComponent<PlayerInventory>(out var inv)) inv.Toast("Waystone attuned");
            resp.SetPoint(transform.position + transform.forward * 1.5f, transform.rotation, Id);
        }
    }
}
