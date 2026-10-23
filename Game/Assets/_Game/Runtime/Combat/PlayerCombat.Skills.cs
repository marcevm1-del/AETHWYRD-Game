using System;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Skills, the Ultimate, the Fire Bomb, elements and reactions (combat.md §6–7), on top of PlayerCombat.
    /// Costs, cooldowns, unlocks and skill-cancels come from Core SkillCaster; each skill plays by its data kind:
    ///   launcher → launch · dash → dash then strike · ranged → a travelling wave · aoe / ultimate → a circle ·
    ///   chain → its hits in front · buff / utility → no attack yet (Ring 1).
    /// Every hit goes through ApplyHit: element aura, reaction (Firestorm spawns a burning zone), damage, numbers.
    /// </summary>
    public sealed partial class PlayerCombat
    {
        enum SkillShape { Arc, Circle }

        public const float WaveSpeed = 20f, WaveRange = 14f, WaveRadius = 0.8f, DashDistance = 5f, BombRadius = 2.5f, BombThrowM = 6f;

        [SerializeField] int fireBombs = 3;

        SkillCaster _caster;
        SkillData _pendingSkill;
        SkillShape _skillShape;
        float _skillReachMult = 1f;
        double _skillDashM;
        Element _skillElement;
        bool _skillAppliesElement;

        public SkillCaster Caster => _caster ??= new SkillCaster(_class, level, Stats, _tuning.Resources, _budget);
        public int FireBombs => fireBombs;
        public SkillData LastCast { get; private set; }
        public CastResult LastCastResult { get; private set; }

        /// <summary>Raised when an element hit triggers a reaction (Style: +reaction).</summary>
        public event Action<MonsterDummy, Reaction> ReactionTriggered;

        // ---------------------------------------------------------------- casting
        /// <summary>Casts the skill in slot 0–3. During an attack it is a skill-cancel (costs a Combo Budget point).</summary>
        public CastResult CastSlot(int slot)
        {
            var slots = Caster.Slots;
            if (slot < 0 || slot >= slots.Count) return LastCastResult = CastResult.NotInKit;
            return Cast(slots[slot]);
        }

        public CastResult CastUltimate() => Cast(Caster.Ultimate);

        CastResult Cast(SkillData skill)
        {
            if (_motor.IsDodging) return LastCastResult = CastResult.Cooldown;
            bool asCancel = IsAttacking;
            var r = Caster.Cast(skill, asCancel);
            LastCastResult = r;
            if (r != CastResult.Ok) return r;
            LastCast = skill;
            _charge.Cancel();
            _chain.Cancel();
            if (_special != null && _special.IsBusy) _special.Cancel();
            if (skill.Hits.Count == 0) return r; // buff / utility: effects arrive with Ring 1

            _skillElement = Enum.TryParse(skill.Element, out Element e) ? e : Element.None;
            _skillAppliesElement = skill.AppliesElement;
            _skillShape = skill.Kind == "aoe" || skill.Kind == "ultimate" ? SkillShape.Circle : SkillShape.Arc;
            _skillReachMult = skill.Kind == "ultimate" ? 1.8f : skill.Kind == "aoe" ? 1.3f : 1f;
            _skillDashM = skill.Kind == "dash" ? DashDistance : 0;

            if (skill.Kind == "ranged") { FireWave(skill); return r; }
            if (skill.Kind == "launcher")
            {
                StartSpecial(Special.Launcher, skill.Hits[skill.Hits.Count - 1].Power, "launch", -1f, 1.0);
                return r;
            }
            if (skill.Kind == "ultimate") GameTime.FlashTime((float)_tuning.FlashTime.TimeScale, 1.2f);
            _pendingSkill = skill;
            StartSpecial(Special.Skill, 0, "light", -1f, 1.0);
            return r;
        }

        void FireWave(SkillData skill)
        {
            var hit = skill.Hits[0];
            var weight = AttackChain.WeightOf(hit);
            Element el = _skillElement; bool applies = _skillAppliesElement;
            FaceTarget();
            CombatProjectile.Launch(transform.position + Vector3.up * 1.0f + transform.forward * 0.6f, transform.forward * WaveSpeed,
                WaveRange, WaveRadius, gravity: 0f, pierce: true, explodeRadius: 0f, owner: this,
                onHit: (m, at) => { ApplyHit(m, at, hit.Power, weight, el, applies, 1.0); CameraShake.Kick(weight); });
        }

        /// <summary>Throws a Fire Bomb (Ring 0 quick item): an arc that bursts into Fire where it lands.</summary>
        public bool ThrowFireBomb()
        {
            if (fireBombs <= 0 || _motor.IsDodging) return false;
            if (!AscendData.Db.Items.TryGetValue("itm_fire_bomb", out var bomb)) return false;
            fireBombs--;
            double power = bomb.Stat("power") > 0 ? bomb.Stat("power") : 1.2;
            FaceTarget();
            Vector3 aimAt = LockTarget != null && !LockTarget.IsDead ? LockTarget.transform.position : transform.position + transform.forward * BombThrowM;
            Vector3 from = transform.position + Vector3.up * 1.4f;
            Vector3 flat = aimAt - from; flat.y = 0;
            const float flightSec = 0.55f, g = 20f;
            Vector3 v = flat / flightSec; v.y = (aimAt.y + 0.5f - from.y) / flightSec + 0.5f * g * flightSec;
            CombatProjectile.Launch(from, v, 30f, 0.4f, gravity: g, pierce: false, explodeRadius: BombRadius, owner: this,
                onHit: (m, at) => ApplyHit(m, at, power, HitWeight.Medium, Element.Fire, true, 1.0));
            return true;
        }

        public void GiveFireBombs(int n) => fireBombs = Mathf.Max(0, fireBombs + n);

        // ---------------------------------------------------------------- one hit on one monster
        /// <summary>Element aura → reaction → damage → feedback, for strikes, waves, bombs and zones alike.</summary>
        public DamageResult ApplyHit(MonsterDummy m, Vector3 contact, double power, HitWeight weight, Element element, bool applyElement, double poiseMult, bool fromZone = false)
        {
            Reaction reaction = Reaction.None;
            double reactionMult = 1.0;
            if (applyElement && element != Element.None)
            {
                reaction = m.ApplyElement(element);
                if (reaction == Reaction.Firestorm)
                {
                    reactionMult = _tuning.Firestorm.BurstMult;
                    FirestormZone.Spawn(m.transform.position, this, _tuning.Firestorm);
                }
            }
            reactionMult *= m.ReactionHitMultiplier(weight);
            var result = _calc.Compute(new DamageInput
            {
                Kind = DamageKind.Physical, Attack = Stats.Atk, Defense = m.Defense, Power = power,
                AttackElement = element, DefenderWeakness = m.Weakness, CritChance = Stats.CritChance, ReactionMult = reactionMult,
            }, _rng);
            bool wasAlive = !m.IsDead;
            m.TakeHit(result.Amount, weight, transform.position, power * PoisePerPower * poiseMult);
            DamageNumber.Spawn(contact + Vector3.up * 0.3f, result.Amount, result.Crit);
            ScoreHit(m, weight, reaction, wasAlive && m.IsDead, fromZone);
            HitLanded?.Invoke(m, result);
            if (reaction != Reaction.None)
            {
                ReactionTriggered?.Invoke(m, reaction);
                ReactionPopup.Spawn(m.transform.position + Vector3.up * 2.2f, reaction);
            }
            return result;
        }
    }
}
