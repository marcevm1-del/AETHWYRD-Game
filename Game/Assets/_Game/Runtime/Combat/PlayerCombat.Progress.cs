using System;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Level, XP and the Style meter (combat.md §8) on top of PlayerCombat. Kills give XP scaled by the Style Rank;
    /// level-ups recompute stats from the class growth and progression rules. Style points come from varied hits and
    /// events, and feed the Awakening meter.
    /// </summary>
    public sealed partial class PlayerCombat
    {
        PlayerProgress _progress;
        StyleMeter _style;

        public PlayerProgress Progress => _progress ??= new PlayerProgress(AscendData.Db.Progression, level);
        public StyleMeter Style => _style ??= new StyleMeter(_tuning.Style);
        public int Level => level;

        /// <summary>Raised on every level gained: (old level, new level).</summary>
        public event Action<int, int> LeveledUp;
        /// <summary>Raised when XP is awarded (amount).</summary>
        public event Action<long> XpGained;

        /// <summary>Awards XP and applies any level-ups.</summary>
        public void GrantXp(long xp)
        {
            if (xp <= 0) return;
            int before = Progress.Level;
            Progress.AddXp(xp);
            XpGained?.Invoke(xp);
            if (Progress.Level != before) SetLevel(Progress.Level);
        }

        /// <summary>Sets the character level and recomputes stats (also unlocks skills by level).</summary>
        public void SetLevel(int newLevel)
        {
            int old = level;
            level = Mathf.Clamp(newLevel, 1, Levels.Cap);
            var db = AscendData.Db;
            Stats = PlayerStats.Derive(PlayerStats.Primary(_class, level, db.Progression), level, db.Progression, new GearBonus { Atk = gearAtk, Def = gearDef });
            Caster.SetLevel(level);
            if (level != old) LeveledUp?.Invoke(old, level);
        }

        /// <summary>Style move id for the variety bonus: each chain hit, special and skill counts as its own move.</summary>
        string CurrentMoveId()
        {
            if (_special != null && _special.IsBusy)
                return _specialKind == Special.Skill && LastCast != null ? LastCast.Id : _specialKind.ToString();
            return $"{_class.Basic.Id}#{Math.Max(0, _chain.HitIndex)}";
        }

        /// <summary>Style and Awakening for one landed hit, plus kill XP.</summary>
        void ScoreHit(MonsterDummy m, HitWeight weight, Reaction reaction, bool killed, bool fromZone)
        {
            double pts = fromZone ? 0 : Style.RegisterHit(CurrentMoveId(), weight);
            if (reaction != Reaction.None) pts += Style.RegisterEvent(StyleEvent.Reaction);
            bool ultimateHit = CurrentSpecial == Special.Skill && LastCast != null && LastCast.Slot == "ultimate";
            if (!ultimateHit) Caster.GainAwakeningFromStyle(pts); // an Ultimate never refills itself
            if (killed) GrantXp(Progress.KillXp(m.Level, m.IsUnique, Style.Rank, _tuning.Style));
        }
    }
}
