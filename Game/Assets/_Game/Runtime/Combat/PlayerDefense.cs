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
        /// <summary>Held by a grab (gold telegraph): no moving, attacking or dodging until it lets go.</summary>
        public bool IsHeld => Time.time < _heldUntil;
        public const float GrabHoldSec = 1.0f;
        float _heldUntil = -1f;

        /// <summary>Raised after every incoming attack with the result and the damage taken.</summary>
        public event Action<DefenseResult, int> Defended;
        /// <summary>Raised once when HP reaches 0 (with the monster that landed the blow, if any).</summary>
        public event Action<MonsterDummy> Died;
        public bool IsDead => Hp <= 0;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            _combat = GetComponent<PlayerCombat>();
            _t = AscendData.Db.Tuning;
            if (_combat == null) return; // PlayerCombat is added first, so its stats exist by now
            MaxHp = Hp = Mathf.Max(1, _combat.Stats.Hp);
            _combat.LeveledUp += (_, __) => { MaxHp = Mathf.Max(1, _combat.Stats.Hp); Hp = MaxHp; }; // a level-up heals fully
            _combat.StatsChanged += () => { MaxHp = Mathf.Max(1, _combat.Stats.Hp); Hp = Mathf.Min(Hp, MaxHp); }; // gear can change max HP
        }

        /// <summary>Block button state; a fresh press starts the parry window.</summary>
        public void SetBlock(bool held)
        {
            if (held && !IsBlocking) _blockPressedAt = Time.unscaledTimeAsDouble;
            IsBlocking = held && !_motor.IsDodging;
        }

        public DefenseResult ReceiveAttack(int rawDamage, Telegraph telegraph, MonsterDummy attacker = null)
        {
            if (IsDead) return DefenseResult.Dodged; // nothing more can happen to a fallen player
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
                    CombatFx.Play(CombatFx.Sfx.PerfectDodge, transform.position);
                    break;
                case DefenseResult.Parried:
                    _blockPressedAt = null; // one parry per press
                    if (attacker != null) attacker.Stagger(transform.position);
                    if (_combat != null) { _combat.OpenRiposte(); _combat.Style.RegisterEvent(StyleEvent.Parry); }
                    HitStop.Trigger((float)_t.Hitstop.Medium);
                    CombatFx.Play(CombatFx.Sfx.Parry, transform.position + Vector3.up);
                    CombatFx.Burst(transform.position + Vector3.up * 1.2f + transform.forward * 0.5f, 24, new Color(0.5f, 0.8f, 1f), 5f);
                    CombatFx.Rumble(HitWeight.Heavy);
                    CameraShake.Kick(HitWeight.Medium);
                    break;
                case DefenseResult.Blocked:
                    CameraShake.Kick(HitWeight.Light);
                    CombatFx.Play(CombatFx.Sfx.Block, transform.position);
                    CombatFx.Rumble(HitWeight.Light);
                    break;
                case DefenseResult.Grabbed:
                    _heldUntil = Time.time + GrabHoldSec;
                    goto case DefenseResult.Hit;
                case DefenseResult.Hit:
                    CameraShake.Kick(HitWeight.Medium);
                    if (taken > 0) _combat?.Style.RegisterPlayerHit();
                    CombatFx.Play(CombatFx.Sfx.PlayerHurt, transform.position);
                    CombatFx.Rumble(HitWeight.Medium);
                    break;
            }
            LastResult = r;
            Defended?.Invoke(r, taken);
            if (IsDead && taken > 0) Died?.Invoke(attacker);
            return r;
        }

        /// <summary>Back to full health (respawn).</summary>
        public void Revive() { Hp = MaxHp; _heldUntil = -1f; IsBlocking = false; }

        public void Heal(int amount) => Hp = Mathf.Min(MaxHp, Hp + Mathf.Max(0, amount));
    }
}
