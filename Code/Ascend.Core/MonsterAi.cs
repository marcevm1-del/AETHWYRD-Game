using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // ---------------------------------------------------------------- motion data (subset of Data/Monsters/motion.json)
    public sealed class MotionFile { public List<SpeciesMotion> Species { get; set; } = new List<SpeciesMotion>(); }

    public sealed class SpeciesMotion
    {
        public string SpeciesId { get; set; }
        public double SizeMeters { get; set; }
        public string RigKey { get; set; }
        public LocomotionData Locomotion { get; set; } = new LocomotionData();
        public MenaceData Menace { get; set; } = new MenaceData();
        public MotionBehavior Behavior { get; set; } = new MotionBehavior();
        public NavAgentData NavAgent { get; set; } = new NavAgentData();
        public List<AttackTimingData> Attacks { get; set; } = new List<AttackTimingData>();
        public AttackTimingData TimingOf(string attackId) => Attacks.FirstOrDefault(a => a.AttackId == attackId);
    }

    public sealed class MotionBehavior
    {
        public string Name { get; set; }
        public string AiPattern { get; set; }
        public double AlertRadius { get; set; }
        public double LeashRadius { get; set; }
        public double PreferredRange { get; set; }
        public double CircleRadius { get; set; }
        public double RetreatHpPct { get; set; }
    }

    public sealed class LocomotionData { public double PlayRate { get; set; } = 1; public double TurnDegPerSec { get; set; } }

    public sealed class MenaceData { public string Label { get; set; } public string Posture { get; set; } public double SquashStretch { get; set; } = 1; }

    public sealed class NavAgentData
    {
        public double Speed { get; set; }
        public double WalkSpeed { get; set; }
        public double AngularSpeed { get; set; }
        public double StoppingDistance { get; set; }
    }

    public sealed class AttackTimingData
    {
        public string AttackId { get; set; }
        public string Kind { get; set; }
        public string Telegraph { get; set; }
        public double WindupSec { get; set; }
        public double ActiveSec { get; set; }
        public double RecoverySec { get; set; }
        public double LungeDistance { get; set; }
        public double HitboxRadius { get; set; }
        public double TrackingWindupDegPerSec { get; set; }
    }

    // ---------------------------------------------------------------- brain
    public enum AiState { Idle, Chase, Reposition, Windup, Active, Recovery, Staggered, Flee, Return }
    public enum AiMove { None, Toward, Away, Circle, Home }

    /// <summary>What the monster can perceive this tick (filled by the game).</summary>
    public struct AiSense
    {
        public double DistanceToPlayer;
        public double DistanceFromHome;
        public double HpFraction;
        /// <summary>Whether this monster holds (or just got) an aggro token. Only token holders start attacks.</summary>
        public bool HasToken;
    }

    /// <summary>What the brain wants this tick.</summary>
    public struct AiCommand
    {
        public AiMove Move;
        public double Speed;
        /// <summary>Turn to face the player (true while chasing and winding up).</summary>
        public bool Face;
        /// <summary>True on the first active frame: the game resolves the hit against the player.</summary>
        public bool StrikeNow;
        /// <summary>Asking for an aggro token (an attack is in range).</summary>
        public bool WantsToken;
        /// <summary>The token can be released (recovery ended, fleeing, returning home).</summary>
        public bool ReleaseToken;
    }

    /// <summary>
    /// A monster's turn (combat.md §10): pick an attack from attackIds by range and cooldown → telegraph (windup)
    /// → strike → recovery (the player's punish window). Timings and ranges come from motion.json; attacks from
    /// attacks.json. Patterns: aggressive_chase / pack_flank / swarm_surround chase and circle for a token;
    /// territorial_guard returns home past its leash; skittish_flee runs first and attacks when it stops;
    /// a retreatHpPct above 0 makes the monster flee when hurt. Engine-free; the game moves the body.
    /// </summary>
    public sealed class MonsterBrain
    {
        public const double StaggerSec = 0.9;
        public const double FleeSec = 2.0;
        public const double RangedMin = 3.0, RangedMax = 10.0, DashMin = 2.0, DashMax = 7.0;

        readonly SpeciesData _species;
        readonly SpeciesMotion _motion;
        readonly List<(AttackData data, AttackTimingData timing)> _attacks;
        readonly Dictionary<string, double> _cooldownLeft = new Dictionary<string, double>();
        readonly IRandom _rng;
        double _stateTime, _windup;

        public AiState State { get; private set; } = AiState.Idle;
        public AttackData CurrentAttack { get; private set; }
        public AttackTimingData CurrentTiming { get; private set; }
        public Telegraph CurrentTelegraph => CurrentAttack == null ? Telegraph.None : DefenseJudge.Parse(CurrentAttack.Telegraph);
        /// <summary>0 → 1 across the windup (drives the shrinking speed-cue ring).</summary>
        public double WindupProgress => State == AiState.Windup && _windup > 0 ? Math.Min(1, _stateTime / _windup) : 0;
        public string Pattern => _motion.Behavior.AiPattern ?? "aggressive_chase";
        public bool IsSkittish => Pattern.StartsWith("skittish");
        public bool IsTerritorial => Pattern.StartsWith("territorial") || Pattern.StartsWith("guardian");

        public MonsterBrain(SpeciesData species, SpeciesMotion motion, IReadOnlyDictionary<string, AttackData> attacks, IRandom rng)
        {
            _species = species ?? throw new ArgumentNullException(nameof(species));
            _motion = motion ?? throw new ArgumentNullException(nameof(motion));
            _rng = rng ?? throw new ArgumentNullException(nameof(rng));
            _attacks = (species.AttackIds ?? new List<string>())
                .Where(attacks.ContainsKey).Select(id => (attacks[id], motion.TimingOf(id)))
                .Where(a => a.Item2 != null && a.Item1.Power > 0 && a.Item1.Kind != "summon" && a.Item2.Kind != "summon" && a.Item2.Kind != "buff")
                .ToList();
        }

        /// <summary>The usable attacks (power above 0, not summons) with their timings.</summary>
        public IReadOnlyList<(AttackData data, AttackTimingData timing)> Attacks => _attacks;

        /// <summary>Attack kinds in motion.json: ranged/magic fire from range, charge/leap close distance, aoe hits around the body, melee/heavy/grab are close.</summary>
        public static bool IsRanged(string kind) => kind == "ranged" || kind == "magic";
        public static bool IsGapCloser(string kind) => kind == "charge" || kind == "leap" || kind == "dash";

        public double ReachOf(AttackTimingData t)
        {
            if (IsRanged(t.Kind)) return RangedMax;
            if (IsGapCloser(t.Kind)) return DashMax;
            double melee = Math.Max(Math.Min(_motion.Behavior.PreferredRange, 2.5), 1.0) + t.LungeDistance + 0.3;
            return t.Kind == "aoe" ? melee + 1.0 : melee;
        }

        public double MinRangeOf(AttackTimingData t) => IsRanged(t.Kind) ? RangedMin : IsGapCloser(t.Kind) ? DashMin : 0;

        /// <summary>A forced interrupt (poise break or a parry): cancels any windup or strike.</summary>
        public void Stagger()
        {
            Enter(AiState.Staggered);
            CurrentAttack = null; CurrentTiming = null;
        }

        public AiCommand Tick(double dt, AiSense s)
        {
            foreach (var k in _cooldownLeft.Keys.ToList()) _cooldownLeft[k] = Math.Max(0, _cooldownLeft[k] - dt);
            _stateTime += dt;
            var b = _motion.Behavior;
            var nav = _motion.NavAgent;
            var cmd = new AiCommand { Move = AiMove.None, Speed = 0 };

            // Leash: everyone gives up past the leash (territorial monsters sooner, at the alert radius ×1.5).
            double leash = IsTerritorial ? Math.Min(b.LeashRadius, b.AlertRadius * 1.5) : b.LeashRadius;
            bool busy = State == AiState.Windup || State == AiState.Active || State == AiState.Recovery || State == AiState.Staggered;
            if (!busy && State != AiState.Return && State != AiState.Idle && s.DistanceFromHome > leash) Enter(AiState.Return);
            if (!busy && State != AiState.Flee && b.RetreatHpPct > 0 && s.HpFraction > 0 && s.HpFraction <= b.RetreatHpPct && State != AiState.Return)
                Enter(AiState.Flee);

            switch (State)
            {
                case AiState.Idle:
                    if (s.DistanceToPlayer <= b.AlertRadius) Enter(IsSkittish ? AiState.Flee : AiState.Chase);
                    break;

                case AiState.Return:
                    cmd.Move = AiMove.Home; cmd.Speed = nav.WalkSpeed > 0 ? nav.WalkSpeed * 1.5 : nav.Speed; cmd.ReleaseToken = true;
                    if (s.DistanceFromHome < 0.5) Enter(AiState.Idle);
                    break;

                case AiState.Flee:
                    cmd.Move = AiMove.Away; cmd.Speed = nav.Speed; cmd.ReleaseToken = true;
                    if (_stateTime >= FleeSec || s.DistanceToPlayer > b.AlertRadius) Enter(s.DistanceToPlayer > b.AlertRadius ? AiState.Idle : AiState.Chase);
                    break;

                case AiState.Chase:
                case AiState.Reposition:
                {
                    cmd.Face = true;
                    var choice = Choose(s.DistanceToPlayer);
                    if (choice.data != null)
                    {
                        cmd.WantsToken = true;
                        if (s.HasToken) { StartWindup(choice); cmd.Move = AiMove.None; break; }
                        Enter(AiState.Reposition);
                        cmd.Move = AiMove.Circle; cmd.Speed = nav.WalkSpeed > 0 ? nav.WalkSpeed : nav.Speed * 0.4;
                        break;
                    }
                    if (State == AiState.Reposition) Enter(AiState.Chase);
                    bool tooFar = s.DistanceToPlayer > Math.Max(b.PreferredRange, nav.StoppingDistance);
                    cmd.Move = tooFar ? AiMove.Toward : AiMove.None;
                    cmd.Speed = nav.Speed;
                    break;
                }

                case AiState.Windup:
                    cmd.Face = true;
                    if (_stateTime >= _windup) { Enter(AiState.Active); cmd.StrikeNow = true; }
                    break;

                case AiState.Active:
                    if (_stateTime >= CurrentTiming.ActiveSec) Enter(AiState.Recovery);
                    break;

                case AiState.Recovery:
                    if (_stateTime >= CurrentTiming.RecoverySec)
                    {
                        cmd.ReleaseToken = true;
                        Enter(IsSkittish ? AiState.Flee : AiState.Chase);
                    }
                    break;

                case AiState.Staggered:
                    cmd.ReleaseToken = true;
                    if (_stateTime >= StaggerSec) Enter(AiState.Chase);
                    break;
            }
            return cmd;
        }

        (AttackData data, AttackTimingData timing) Choose(double distance)
        {
            var ready = _attacks.Where(a => Cooldown(a.data.Id) <= 0 && distance <= ReachOf(a.timing) && distance >= MinRangeOf(a.timing)).ToList();
            if (ready.Count == 0) return default;
            // Prefer the strongest ready attack about half the time, otherwise any ready one: varied but readable.
            if (_rng.NextDouble() < 0.5) return ready.OrderByDescending(a => a.data.Power).First();
            return ready[(int)(_rng.NextDouble() * ready.Count) % ready.Count];
        }

        double Cooldown(string id) => _cooldownLeft.TryGetValue(id, out var c) ? c : 0;

        void StartWindup((AttackData data, AttackTimingData timing) a)
        {
            CurrentAttack = a.data; CurrentTiming = a.timing;
            _windup = a.timing.WindupSec;
            _cooldownLeft[a.data.Id] = Math.Max(a.data.CooldownSec, a.timing.WindupSec + a.timing.ActiveSec + a.timing.RecoverySec);
            Enter(AiState.Windup);
        }

        void Enter(AiState s) { State = s; _stateTime = 0; }
    }
}
