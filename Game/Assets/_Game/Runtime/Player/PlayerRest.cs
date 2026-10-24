using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Inn stays (inns.md): sleeping in a room heals you, jumps the clock to dawn, and gives Rested / Well Rested — bonus
    /// kill XP for hours of play (Well Rested plays first). At F–E rank Marta lets you sleep on her tab at the Sleeping
    /// Griffon when you're short; the tab never blocks anything. Nights per inn count toward regular status.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat), typeof(PlayerInventory))]
    public sealed class PlayerRest : MonoBehaviour
    {
        PlayerCombat _combat;
        PlayerInventory _inv;
        readonly Dictionary<string, int> _nights = new Dictionary<string, int>();

        public List<RestBuff> Buffs { get; private set; } = new List<RestBuff>();
        public InnTab Tab { get; private set; }
        public IReadOnlyDictionary<string, int> Nights => _nights;
        public double XpBonus => InnStay.XpBonus(Buffs);

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _inv = GetComponent<PlayerInventory>();
            Tab = new InnTab(AscendData.Db.World.Inns.Tab);
            _combat.XpMultiplier = () => 1 + XpBonus;
        }

        void Update()
        {
            if (Buffs.Count > 0) InnStay.Consume(Buffs, Time.unscaledDeltaTime / 3600.0); // hours of play
        }

        /// <summary>Can this room be paid for, or put on the tab here?</summary>
        public bool CanTab(InnData inn) => Tab.AvailableAt(inn.Id, _combat.Progress.RankBand, RegularStatus.Stranger);

        public string Status(InnData inn, out RegularStatus status)
        {
            int n = _nights.TryGetValue(inn.Id, out var v) ? v : 0;
            status = InnStay.Status(n, false, false, AscendData.Db.World.Inns.Regular);
            return $"{status} · {n} night{(n == 1 ? "" : "s")}";
        }

        /// <summary>Sleeps in a room: pay (or tab), heal, wake at dawn, gain the rest buff, autosave. False if you can't pay.</summary>
        public bool Sleep(InnData inn, InnRoom room)
        {
            bool paid = _inv.Items.TrySpend(room.PriceCopper);
            if (!paid)
            {
                if (!CanTab(inn)) { _inv.Toast("You can't afford that room."); return false; }
                Tab.Charge(room.PriceCopper);
                _inv.Toast($"On Marta's tab: {Money.Format(Tab.BalanceCopper, AscendData.Db.World.Currency)} owed", 4f);
            }
            GameTime.Clear();
            var def = GetComponent<PlayerDefense>();
            if (def != null) def.Revive();
            double slept = WorldClock.Instance != null ? WorldClock.Instance.SleepUntilDawn() : 8;
            Buffs = InnStay.Stack(Buffs, InnStay.Rest(room, false, false, AscendData.Db.World.Inns));
            _nights[inn.Id] = (_nights.TryGetValue(inn.Id, out var n) ? n : 0) + 1;
            var top = Buffs.FirstOrDefault();
            _inv.Toast($"Slept {slept:0} hours at {inn.Name}." + (top != null ? $" {Pretty(top.Kind)}: +{top.XpBonus * 100:0}% XP" : ""), 5f);
            var respawn = GetComponent<PlayerRespawn>();
            if (respawn != null) respawn.SetPoint(transform.position, transform.rotation, inn.Id); // you wake where you slept; attuning autosaves
            return true;
        }

        public bool PayTab()
        {
            int owed = Tab.BalanceCopper;
            if (owed <= 0) return false;
            int pay = (int)System.Math.Min(owed, _inv.Items.Copper);
            if (pay <= 0 || !_inv.Items.TrySpend(pay)) { _inv.Toast("You've nothing to pay with."); return false; }
            bool first = !Tab.PaidOffOnce;
            Tab.Pay(pay);
            _inv.Toast(Tab.BalanceCopper == 0 ? (first ? "Tab paid off. Marta beams." : "Tab paid off.") : $"Paid {Money.Format(pay, AscendData.Db.World.Currency)} off the tab.");
            return true;
        }

        public static string Pretty(RestKind k) => k == RestKind.WellRested ? "Well Rested" : "Rested";

        public string BuffText()
        {
            var b = Buffs.FirstOrDefault();
            if (b == null) return null;
            int mins = (int)System.Math.Ceiling(b.Hours * 60);
            return $"{Pretty(b.Kind)} {mins / 60}h {mins % 60:00}m (+{b.XpBonus * 100:0}% XP)";
        }

        // ---------------------------------------------------------------- saves
        public void Load(List<RestBuff> buffs, int tabCopper, bool tabPaidOnce, Dictionary<string, int> nights)
        {
            Buffs = buffs ?? new List<RestBuff>();
            Tab.Load(tabCopper, tabPaidOnce);
            _nights.Clear();
            foreach (var kv in nights ?? new Dictionary<string, int>()) _nights[kv.Key] = kv.Value;
        }
    }
}
