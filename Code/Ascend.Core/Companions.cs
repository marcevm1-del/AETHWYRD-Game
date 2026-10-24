using System;

namespace Ascend.Core
{
    // Companion field AI (12_Systems/companion_field_ai.md, "Ring 0 prototype"). Numbers: world_tuning.json → companions.

    public sealed class CompanionTuning
    {
        public double FollowDistance { get; set; } = 2.5;
        /// <summary>Never closer than this to you (no clipping through the player).</summary>
        public double PersonalSpace { get; set; } = 1.4;
        public double RegroupDistance { get; set; } = 20;
        /// <summary>How far from you (or the held spot) it will chase a target.</summary>
        public double Leash { get; set; } = 12;
        public double ReachM { get; set; } = 1.8;
        public double AttackIntervalSec { get; set; } = 1.1;
        public double AttackPower { get; set; } = 1.0;
        /// <summary>The signature assist on a staggered enemy, as a multiple of a normal hit.</summary>
        public double AssistPower { get; set; } = 2.5;
        public double DodgeCooldownSec { get; set; } = 2.0;
        public double DodgeDistance { get; set; } = 2.5;
        public double DownedSec { get; set; } = 20;
        public double BanterCooldownSec { get; set; } = 25;
    }

    /// <summary>The command wheel's first intents (companion_field_ai.md): Follow is Regroup.</summary>
    public enum CompanionOrder { Follow, Hold, Focus, Assist }

    public enum CompanionAction { Downed, Dodge, Regroup, SignatureAssist, Attack, Guard, Follow }

    /// <summary>What the companion can see this moment.</summary>
    public struct CompanionSense
    {
        public bool Downed;
        public CompanionOrder Order;
        public double DistanceToPlayer;
        /// <summary>A monster winding up an attack within reach of the companion.</summary>
        public bool ThreatWindingUpNearMe;
        public bool DodgeReady;
        /// <summary>A staggered monster nearby that it hasn't used its signature assist on yet.</summary>
        public bool StaggeredEnemyNear;
        /// <summary>The player's lock-on target (Focus) or last-hit target (Assist) exists and is alive.</summary>
        public bool PlayerTargetAlive;
        /// <summary>Any hostile within its leash of you (or the held spot).</summary>
        public bool EnemyInLeash;
        public bool InCombat;
    }

    /// <summary>
    /// The decision order from companion_field_ai.md: 1 safety, 2 the player's request, 3 role objective,
    /// 4 encounter reaction, 5 personality (later), 6 recovery. Pure and testable; the Unity side carries it out.
    /// </summary>
    public static class CompanionBrain
    {
        public static CompanionAction Decide(CompanionSense s, CompanionTuning t)
        {
            if (s.Downed) return CompanionAction.Downed;
            // 1. Safety: a readable dodge away from a wind-up aimed its way.
            if (s.ThreatWindingUpNearMe && s.DodgeReady) return CompanionAction.Dodge;
            // 6 before 2 when far: "if pathing fails, regroup is preferred over teleporting into an active attack".
            if (s.DistanceToPlayer > t.RegroupDistance) return CompanionAction.Regroup;
            // 4. Encounter reaction that rewards the player: the signature assist on an opening they made.
            if (s.StaggeredEnemyNear) return CompanionAction.SignatureAssist;
            // 2. The player's request.
            switch (s.Order)
            {
                case CompanionOrder.Hold: return s.EnemyInLeash ? CompanionAction.Attack : CompanionAction.Guard;
                case CompanionOrder.Focus:
                case CompanionOrder.Assist:
                    if (s.PlayerTargetAlive) return CompanionAction.Attack;
                    break;
            }
            // 3. Role objective: fight what threatens you; otherwise 6. recovery: stay with you.
            return s.EnemyInLeash ? CompanionAction.Attack : CompanionAction.Follow;
        }

        /// <summary>Banter is allowed out of combat, off cooldown, and not in quiet mode.</summary>
        public static bool MaySpeak(bool inCombat, double sinceLastLine, bool quiet, CompanionTuning t) =>
            !quiet && !inCombat && sinceLastLine >= t.BanterCooldownSec;
    }
}
