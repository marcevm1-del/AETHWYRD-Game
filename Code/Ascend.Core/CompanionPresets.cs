using System;
using System.Collections.Generic;

namespace Ascend.Core
{
    // Companion command presets, retreat, revive and the downed outcome (companion_field_ai.md, Canon section 5).
    // Numbers: Data/Companions/companion_rules.json. Every default below equals the shipped JSON, so a data
    // folder missing a section (an old config) still behaves. CompanionBrain.Decide is untouched; this layer wraps it.

    /// <summary>One roster row of Data/Companions/companions.json (the fields code needs).</summary>
    public sealed class CompanionData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string NpcId { get; set; }
        public string PresetDefault { get; set; } = "Balanced";
        public bool Romanceable { get; set; }
        public bool Adult { get; set; }
        public bool Rideable { get; set; }
        public bool RedeemableArc { get; set; }
        public bool Stub { get; set; }
        public List<string> RoleTags { get; set; } = new List<string>();
        public string PreferredRole { get; set; }
        public List<string> PersonalityTags { get; set; } = new List<string>();
        public List<string> EquipmentSlots { get; set; } = new List<string>();
    }

    public enum CompanionPreset { Aggressive, Defensive, Supportive, Balanced }

    /// <summary>Scalar tweaks of one preset. The defaults are the identity (Balanced).</summary>
    public sealed class PresetTuning
    {
        public string DefaultOrder { get; set; } = "Follow";
        public double LeashMult { get; set; } = 1.0;
        public double FollowDistanceMult { get; set; } = 1.0;
        /// <summary>Scales the retreat threshold: above 1 it retreats earlier, below 1 it fights on longer.</summary>
        public double RetreatHpMult { get; set; } = 1.0;
        /// <summary>Scales the reach of a revive: above 1 it will cross more ground to pick you up.</summary>
        public double ReviveEagerness { get; set; } = 1.0;
        /// <summary>Scales the signature assist.</summary>
        public double AssistBias { get; set; } = 1.0;
        /// <summary>Above 1 it spends costly skills less readily (read by the Unity side's skill picker).</summary>
        public double SkillCostCaution { get; set; } = 1.0;

        public CompanionOrder Order => Enum.TryParse<CompanionOrder>(DefaultOrder, true, out var o) ? o : CompanionOrder.Follow;
    }

    public sealed class RetreatTuning
    {
        public double LowHpFraction { get; set; } = 0.25;
        /// <summary>Once retreating it keeps going until hp reaches max(RecoverHpFraction, enter + Hysteresis).</summary>
        public double Hysteresis { get; set; } = 0.10;
        public double RecoverHpFraction { get; set; } = 0.5;
        public double MortalBondsHpMult { get; set; } = 1.25;
        public bool NeedsSafePathWhenPlayerDowned { get; set; } = true;
    }

    public sealed class ReviveTuning
    {
        public double ReviveRangeM { get; set; } = 3.0;
        public double ReviveCastSec { get; set; } = 2.5;
        public bool Interruptible { get; set; } = true;
        public double CooldownSec { get; set; } = 8;
        public double HealFractionOnRevive { get; set; } = 0.35;
        /// <summary>A revive never spends a rare item without the player's consent (companion_field_ai.md).</summary>
        public bool RareItemsRequireConsent { get; set; } = true;
    }

    public sealed class MortalBondsTuning
    {
        public bool DefaultEnabled { get; set; } = false;
        public bool DeathRequiresLethalBlowWhileDowned { get; set; } = true;
        // Fixed by Canon section 5: informational mirrors of rules DownedOutcome enforces unconditionally.
        public bool TimerCanKill { get; set; } = false;
        public bool PathingCanKill { get; set; } = false;
    }

    public sealed class DownedTuning
    {
        public double GravelyWoundedRecoverySec { get; set; } = 120;
        public double RecoverHpFractionAfterWounded { get; set; } = 0.3;
        public MortalBondsTuning MortalBonds { get; set; } = new MortalBondsTuning();
    }

    /// <summary>Mirror of Data/Companions/companion_rules.json. Missing sections keep their defaults.</summary>
    public sealed class CompanionRules
    {
        public int Version { get; set; } = 1;
        public Dictionary<string, PresetTuning> Presets { get; set; } = new Dictionary<string, PresetTuning>();
        public RetreatTuning Retreat { get; set; } = new RetreatTuning();
        public ReviveTuning Revive { get; set; } = new ReviveTuning();
        public DownedTuning Downed { get; set; } = new DownedTuning();

        /// <summary>The tuning for a preset; a preset the file does not list is the identity (Balanced).</summary>
        public PresetTuning Preset(CompanionPreset p) =>
            Presets != null && Presets.TryGetValue(p.ToString(), out var t) && t != null ? t : new PresetTuning();
    }

    /// <summary>The v8 command wheel: seven intents mapped onto the existing orders.</summary>
    public enum CompanionCommand { Follow, HoldPosition, Attack, Defend, Assist, Retreat, Interact }

    /// <summary>What a command asks for: an existing order plus the flags the old orders cannot express.</summary>
    public struct CompanionCommandEffect
    {
        public CompanionOrder Order;
        /// <summary>Hold where the player stands, not at the spot the command was given (Defend).</summary>
        public bool HoldAtPlayer;
        public bool Retreat;
        public bool Interact;
    }

    public static class CompanionCommands
    {
        public static CompanionCommandEffect Map(CompanionCommand c)
        {
            switch (c)
            {
                case CompanionCommand.HoldPosition: return new CompanionCommandEffect { Order = CompanionOrder.Hold };
                case CompanionCommand.Attack: return new CompanionCommandEffect { Order = CompanionOrder.Focus };
                case CompanionCommand.Defend: return new CompanionCommandEffect { Order = CompanionOrder.Hold, HoldAtPlayer = true };
                case CompanionCommand.Assist: return new CompanionCommandEffect { Order = CompanionOrder.Assist };
                case CompanionCommand.Retreat: return new CompanionCommandEffect { Order = CompanionOrder.Follow, Retreat = true };
                case CompanionCommand.Interact: return new CompanionCommandEffect { Order = CompanionOrder.Follow, Interact = true };
                default: return new CompanionCommandEffect { Order = CompanionOrder.Follow };
            }
        }
    }

    /// <summary>What the preset layer needs beyond CompanionSense. Defaults describe a calm, safe moment.</summary>
    public sealed class CompanionContext
    {
        public bool WasRetreating { get; set; }
        /// <summary>There is a safe route away from the fight.</summary>
        public bool SafeRetreatPath { get; set; } = true;
        /// <summary>An enemy is already on the companion (a revive cast would be interrupted).</summary>
        public bool EnemyEngagingMe { get; set; }
        public double SecSinceLastRevive { get; set; } = 999;
        /// <summary>The player asked for a retreat / an interaction (CompanionCommands).</summary>
        public bool RetreatCommanded { get; set; }
        public bool InteractRequested { get; set; }
    }

    public enum DownedResult { StillDowned, Revived, GravelyWounded, Dead }

    public static class CompanionPresetBrain
    {
        /// <summary>A copy of the tuning with the preset applied; the input is never changed.</summary>
        public static CompanionTuning ApplyPreset(CompanionTuning t, PresetTuning p) => new CompanionTuning
        {
            FollowDistance = t.FollowDistance * p.FollowDistanceMult,
            PersonalSpace = t.PersonalSpace,
            RegroupDistance = t.RegroupDistance,
            Leash = t.Leash * p.LeashMult,
            ReachM = t.ReachM,
            AttackIntervalSec = t.AttackIntervalSec,
            AttackPower = t.AttackPower,
            AssistPower = t.AssistPower * p.AssistBias,
            DodgeCooldownSec = t.DodgeCooldownSec,
            DodgeDistance = t.DodgeDistance,
            DownedSec = t.DownedSec,
            BanterCooldownSec = t.BanterCooldownSec
        };

        public static CompanionTuning ApplyPreset(CompanionTuning t, CompanionRules rules, CompanionPreset preset) =>
            ApplyPreset(t, (rules ?? new CompanionRules()).Preset(preset));

        /// <summary>The hp fraction below which the companion starts a retreat.</summary>
        public static double RetreatEnter(PresetTuning p, RetreatTuning r, bool mortalBonds) =>
            Math.Min(0.95, r.LowHpFraction * p.RetreatHpMult * (mortalBonds ? r.MortalBondsHpMult : 1.0));

        /// <summary>
        /// Retreat with hysteresis: starts below the enter threshold, keeps going until hp reaches
        /// max(recoverHpFraction, enter + hysteresis).
        /// </summary>
        public static bool ShouldRetreat(double hpFraction, bool wasRetreating, PresetTuning p, RetreatTuning r, bool mortalBonds)
        {
            double enter = RetreatEnter(p, r, mortalBonds);
            if (!wasRetreating) return hpFraction < enter;
            return hpFraction < Math.Max(r.RecoverHpFraction, enter + r.Hysteresis);
        }

        /// <summary>Whether a revive of the downed player can start now (range, cooldown, and not about to be interrupted).</summary>
        public static bool CanRevive(CompanionSense s, PresetTuning p, ReviveTuning v, CompanionContext c)
        {
            if (s.Downed) return false;
            if (s.DistanceToPlayer > v.ReviveRangeM * p.ReviveEagerness) return false;
            if (c.SecSinceLastRevive < v.CooldownSec) return false;
            if (v.Interruptible && (s.ThreatWindingUpNearMe || c.EnemyEngagingMe)) return false;
            return true;
        }

        /// <summary>
        /// The existing decision order with three additions: Revive (a safe pick-up of the downed player), Retreat
        /// (low hp or commanded) and Interact (only when nothing is fighting). With the player healthy, hp high and
        /// no extra context it returns exactly what CompanionBrain.Decide returns.
        /// </summary>
        public static CompanionAction Decide(CompanionSense s, CompanionTuning t, PresetTuning p, double hpFraction,
            bool playerDowned, bool mortalBonds, CompanionRules rules = null, CompanionContext ctx = null)
        {
            rules = rules ?? new CompanionRules();
            ctx = ctx ?? new CompanionContext();
            var baseAction = CompanionBrain.Decide(s, t);
            // 1. Safety stays first: a downed companion waits, a readable dodge beats everything.
            if (baseAction == CompanionAction.Downed || baseAction == CompanionAction.Dodge) return baseAction;

            // A downed player outranks the player's other requests when the pick-up is safe.
            if (playerDowned && CanRevive(s, p, rules.Revive, ctx)) return CompanionAction.Revive;

            bool retreatAllowed = !(playerDowned && rules.Retreat.NeedsSafePathWhenPlayerDowned && !ctx.SafeRetreatPath);
            bool inFight = s.InCombat || s.EnemyInLeash || s.ThreatWindingUpNearMe;
            if (retreatAllowed && inFight && (ctx.RetreatCommanded || ShouldRetreat(hpFraction, ctx.WasRetreating, p, rules.Retreat, mortalBonds)))
                return CompanionAction.Retreat;

            if (ctx.InteractRequested && !inFight && !playerDowned) return CompanionAction.Interact;
            return baseAction;
        }

        /// <summary>
        /// Companion death is opt-in (Canon section 5). Without Mortal Bonds the worst result is GravelyWounded (out of the
        /// fight, recovers later). With it, Dead needs one explicit condition: a lethal blow taken while already downed
        /// and not revived. A timer, a pathing mistake or any AI fault can never produce Dead.
        /// </summary>
        public static DownedResult DownedOutcome(bool mortalBonds, bool lethalBlowWhileDowned, bool revived, double downedForSec, CompanionTuning t)
        {
            if (revived) return DownedResult.Revived;
            if (lethalBlowWhileDowned) return mortalBonds ? DownedResult.Dead : DownedResult.GravelyWounded;
            return downedForSec >= t.DownedSec ? DownedResult.GravelyWounded : DownedResult.StillDowned;
        }
    }
}
