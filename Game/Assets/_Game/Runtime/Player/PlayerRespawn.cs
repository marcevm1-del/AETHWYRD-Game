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
}
