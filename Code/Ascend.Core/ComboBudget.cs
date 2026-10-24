using System;

namespace Ascend.Core
{
    /// <summary>
    /// Combo Budget (combat.md §4.1): `combo.budgetPerString` skill-cancels per ground string or airtime, refilled on
    /// landing or after `combo.budgetRefillSec` without attacking. Keeps combos expressive but not infinite.
    /// </summary>
    public sealed class ComboBudget
    {
        readonly ComboTuning _t;
        double _idle;
        bool _wasAirborne;

        public int Capacity => Math.Max(0, _t.BudgetPerString);
        public int Left { get; private set; }
        /// <summary>Share of the budget left (1 = full), for the HUD bar.</summary>
        public float Fraction => Capacity > 0 ? (float)Left / Capacity : 1f;

        public ComboBudget(ComboTuning tuning)
        {
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
            Left = Capacity;
        }

        /// <summary>Spends one point for a skill-cancel; false when the budget is empty.</summary>
        public bool TrySpend()
        {
            if (Left <= 0) return false;
            Left--;
            _idle = 0;
            return true;
        }

        /// <param name="attacking">Whether the player is mid-attack this step (idle time only counts when not).</param>
        /// <param name="airborne">Landing after airtime refills the budget.</param>
        public void Tick(double dt, bool attacking, bool airborne)
        {
            if (_wasAirborne && !airborne) Left = Capacity;
            _wasAirborne = airborne;
            if (attacking) { _idle = 0; return; }
            _idle += dt;
            if (_idle >= _t.BudgetRefillSec) Left = Capacity;
        }
    }
}
