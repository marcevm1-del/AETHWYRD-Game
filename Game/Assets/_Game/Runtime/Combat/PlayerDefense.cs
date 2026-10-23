using System;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The receiving end for the player (combat.md §3, §5): HP, block, parry and perfect dodge, judged by Core
    /// DefenseJudge from real-time input timings. Monster AI calls ReceiveAttack when an attack connects.
    ///   Perfect dodge → Flash Time and the dodge's stamina back (free defense, market research A4).
    ///   Parry → the attacker staggers and a riposte opens.
    /// </summary>
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerDefense : MonoBehaviour
    {
        PlayerMotor _motor;
        PlayerCombat _combat;
        CombatTuning _t;
        double? _blockPressedAt;

        public int MaxHp { get; private set; } = 100;
        public int Hp { get; private set; } = 100;
        public bool IsBlocking { get; private set; }
        public DefenseResult LastResult { get; private set; } = DefenseResult.Hit;

        /// <summary>Raised after every incoming attack with the result and the damage taken.</summary>
        public event Action<DefenseResult, int> Defended;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            _combat = GetComponent<PlayerCombat>();
            _t = AscendData.Db.Tuning;
            if (_combat == null) return; // PlayerCombat is added first, so its stats exist by now
            MaxHp = Hp = Mathf.Max(1, _combat.Stats.Hp);
            _combat.LeveledUp += (_, __) => { MaxHp = Mathf.Max(1, _combat.Stats.Hp); Hp = MaxHp; }; // a level-up heals fully
        }

        /// <summary>Block button state; a fresh press starts the parry window.</summary>
        public void SetBlock(bool held)
        {
            if (held && !IsBlocking) _blockPressedAt = Time.unscaledTimeAsDouble;
            IsBlocking = held && !_motor.IsDodging;
        }

        public DefenseResult ReceiveAttack(int rawDamage, Telegraph telegraph, MonsterDummy attacker = null)
        {
            var r = DefenseJudge.Resolve(telegraph, Time.unscaledTimeAsDouble, _motor.DodgeStartedAt, _motor.IsInvulnerable,
                _blockPressedAt, IsBlocking, _t.Dodge, _t.Parry);
            int taken = DefenseJudge.DamageTaken(r, rawDamage, _t.Parry);
            Hp = Mathf.Max(0, Hp - taken);
            if (taken > 0 && _combat != null) _combat.Caster.GainAwakeningFromDamage(taken, MaxHp);
            switch (r)
            {
                case DefenseResult.PerfectDodge:
                    GameTime.FlashTime((float)_t.FlashTime.TimeScale, (float)_t.FlashTime.DurationSec);
                    _motor.RefundStamina((float)_t.Dodge.StaminaCost);
                    _combat?.Style.RegisterEvent(StyleEvent.PerfectDodge);
                    break;
                case DefenseResult.Parried:
                    _blockPressedAt = null; // one parry per press
                    if (attacker != null) attacker.Stagger(transform.position);
                    if (_combat != null) { _combat.OpenRiposte(); _combat.Style.RegisterEvent(StyleEvent.Parry); }
                    HitStop.Trigger((float)_t.Hitstop.Medium);
                    CameraShake.Kick(HitWeight.Medium);
                    break;
                case DefenseResult.Blocked:
                    CameraShake.Kick(HitWeight.Light);
                    break;
                case DefenseResult.Hit:
                case DefenseResult.Grabbed:
                    CameraShake.Kick(HitWeight.Medium);
                    if (taken > 0) _combat?.Style.RegisterPlayerHit();
                    break;
            }
            LastResult = r;
            Defended?.Invoke(r, taken);
            return r;
        }

        public void Heal(int amount) => Hp = Mathf.Min(MaxHp, Hp + Mathf.Max(0, amount));
    }
}
