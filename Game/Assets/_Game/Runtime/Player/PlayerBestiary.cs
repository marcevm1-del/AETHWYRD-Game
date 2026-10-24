using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The Bestiary in play (Core Bestiary; hud_and_ui.md §9): monsters near you are recorded as seen, kills and taming
    /// fill entries tier by tier, and loot you pick up counts toward an entry's completion stamp. Monster labels follow
    /// what you know: "???" until seen, name and rank, then HP from tier 2. B opens the Bestiary window.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat))]
    public sealed class PlayerBestiary : MonoBehaviour
    {
        PlayerCombat _combat;
        PlayerInventory _inv;
        float _nextScan;

        public Bestiary Book { get; private set; }

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _inv = GetComponent<PlayerInventory>();
            Book = new Bestiary(AscendData.Db, AscendData.Db.World.Bestiary);
            _combat.Killed += OnKilled;
            MonsterDummy.AppraisalTier = Book.Tier;
        }

        void OnDestroy()
        {
            if (_combat != null) _combat.Killed -= OnKilled;
            if (MonsterDummy.AppraisalTier == (System.Func<string, int>)Book.Tier) MonsterDummy.AppraisalTier = null;
        }

        void Update()
        {
            if (Time.time < _nextScan) return;
            _nextScan = Time.time + 0.5f;
            float r = (float)AscendData.Db.World.Bestiary.SeenRadius;
            foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None))
            {
                if (m == null || m.IsDead || m.IsPartner) continue;
                Vector3 d = m.transform.position - transform.position; d.y = 0;
                if (d.magnitude > r || !Book.See(m.SpeciesId)) continue;
                Toast($"New bestiary entry: {Name(m.SpeciesId)}");
                RefreshLabels(m.SpeciesId);
            }
        }

        void OnKilled(MonsterDummy m)
        {
            var tier = Book.Kill(m.SpeciesId);
            if (tier == null) return;
            Toast(tier == 2 ? $"Bestiary: {Name(m.SpeciesId)} — HP, element and weakness recorded" : $"Bestiary: {Name(m.SpeciesId)} — full entry (attacks, drops, lore)", 4f);
            RefreshLabels(m.SpeciesId);
        }

        public void Tamed(string speciesId) { Book.Tame(speciesId); RefreshLabels(speciesId); }

        public void Dropped(string speciesId, string itemId)
        {
            bool before = Book.Stamped(speciesId);
            Book.Drop(speciesId, itemId);
            if (!before && Book.Stamped(speciesId)) Toast($"Bestiary: {Name(speciesId)} 100% — completion stamp!", 5f);
        }

        static void RefreshLabels(string speciesId)
        {
            foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) if (m != null && m.SpeciesId == speciesId) m.Refresh();
        }

        public void Load(System.Collections.Generic.IEnumerable<BestiaryEntry> entries)
        {
            Book.Load(entries);
            foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) if (m != null) m.Refresh();
        }

        static string Name(string id) => AscendData.Db.Species.TryGetValue(id, out var s) ? s.Name : id;

        void Toast(string text, float seconds = 3f) { if (_inv != null) _inv.Toast(text, seconds); }
    }
}
