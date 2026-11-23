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
        public double HeightM { get; set; }
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

    public sealed class LocomotionData
    {
        public double PlayRate { get; set; } = 1;
        public double TurnDegPerSec { get; set; }
        /// <summary>"true", "false" or "some_variants" (motion.json).</summary>
        public string CanFly { get; set; }
        /// <summary>"true", "false" or "brief" (perches between flights).</summary>
        public string Hovers { get; set; }
        public bool Flies => CanFly == "true";
    }

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
        /// <summary>Living monsters of its own species nearby (pack odds, after Project Greyborn's bot AI).</summary>
        public int PackmatesNear;
        /// <summary>The target stands inside a town ward this monster won't enter: it doesn't notice them, and breaks off and goes home.</summary>
        public bool TargetWarded;

        // ---- Group tactics (all optional: zero/false means "not supplied" and the brain acts exactly as before). Peers are symmetric; nothing here ranks one monster over another.
        /// <summary>1-based flank slot assigned this frame by the game (FlankSlots.Assign); 0 = none.</summary>
        public int FlankSlot;
        /// <summary>How many slots are in play; 0 = the tuning default.</summary>
        public int FlankSlotCount;
        /// <summary>Living monsters of any species fighting nearby; combined with PackmatesNear for the threat score only.</summary>
        public int AlliesNear;
        /// <summary>Player HP fraction 0-1; 0 or less = not supplied.</summary>
        public double PlayerHpFraction;
        /// <summary>The game (via PeerCoordinator.ShouldYield) says a clearly healthier peer should take the token: skip the attack this tick and keep circling.</summary>
        public bool YieldToken;
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
        /// <summary>0 calm to 1 dire, from ThreatAssessor this tick (information for the game; does not change the brain's choices).</summary>
        public double ThreatLevel;
        /// <summary>When circling with a flank slot: the slot's angle in degrees from the approach axis; otherwise 0.</summary>
        public double FlankAngleDeg;
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
        double _stateTime, _windup, _staggerFor = StaggerSec;

        public AiState State { get; private set; } = AiState.Idle;
        public AttackData CurrentAttack { get; private set; }
        public AttackTimingData CurrentTiming { get; private set; }
        public Telegraph CurrentTelegraph => CurrentAttack == null ? Telegraph.None : DefenseJudge.Parse(CurrentAttack.Telegraph);
        /// <summary>0 → 1 across the windup (drives the shrinking speed-cue ring).</summary>
        public double WindupProgress => State == AiState.Windup && _windup > 0 ? Math.Min(1, _stateTime / _windup) : 0;
        public string Pattern => _motion.Behavior.AiPattern ?? "aggressive_chase";
        public bool IsSkittish => Pattern.StartsWith("skittish");
        public bool IsPack => Pattern.StartsWith("pack") || Pattern.StartsWith("swarm");
        /// <summary>passive_*: idles and never starts a fight from proximity alone; engages only once hit or called by a packmate.</summary>
        public bool IsPassive => Pattern.StartsWith("passive");
        /// <summary>ambush_*: holds still in Idle until the player is inside a short trigger radius, then opens with a strike.</summary>
        public bool IsAmbush => Pattern.StartsWith("ambush");
        /// <summary>The "+stalker" suffix: trails the player at a distance and commits only when the player is busy or hurt.</summary>
        public bool IsStalker => Pattern.Contains("+stalker");

        /// <summary>Base patterns motion.json may declare. Every one is read by the brain; tests check all 680 species map to one.</summary>
        public static readonly string[] BasePatterns = { "aggressive_chase", "pack_flank", "swarm_surround", "territorial_guard", "guardian_hold", "skittish_flee", "passive_wander", "ambush_strike" };
        public const string StalkerSuffix = "+stalker";
        public static bool IsKnownPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return false;
            if (pattern.EndsWith(StalkerSuffix)) pattern = pattern.Substring(0, pattern.Length - StalkerSuffix.Length);
            return Array.IndexOf(BasePatterns, pattern) >= 0;
        }

        /// <summary>An ambusher reveals itself at its alertRadius, but never farther than this (a colossal's 80 m alert radius is not an ambush).</summary>
        public const double AmbushMaxTriggerM = 6.0;
        /// <summary>A stalker commits once the player's HP fraction drops below this.</summary>
        public const double StalkCommitPlayerHp = 0.5;
        /// <summary>A stalker trails at this fraction of its alert radius (at least StalkMinTrailM), within a +-StalkBandM band.</summary>
        public const double StalkTrailFrac = 0.6, StalkMinTrailM = 3.0, StalkBandM = 0.5;

        bool _engaged;        // provoked (hit, called, staggered): passive monsters fight, stalkers commit; cleared on returning to Idle
        bool _committed;      // stalker: the commit condition was met; stays until Idle
        bool _opening = true; // ambusher: the opening strike is still owed
        double _lastHp = -1;

        /// <summary>Seconds left of a raised alarm (a packmate was attacked): it comes for you even from beyond its alert radius.</summary>
        public double AlertedFor { get; private set; }
        public const double AlarmSec = 6, LoneRetreatHp = 0.5;

        /// <summary>A packmate cried out: idle monsters join the fight (skittish ones scatter).</summary>
        public void Alert()
        {
            AlertedFor = AlarmSec;
            _engaged = true;
            if (State == AiState.Idle) Enter(IsSkittish ? AiState.Flee : AiState.Chase);
        }

        public bool IsTerritorial => Pattern.StartsWith("territorial") || Pattern.StartsWith("guardian");

        /// <summary>Group-tactics numbers (defaults in code). Replace from combat_tuning.json when loaded.</summary>
        public GroupTacticsTuning Tactics { get; set; } = GroupTacticsTuning.Default;

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
        public void Stagger() => Stun(StaggerSec);

        /// <summary>Stagger for a custom time (e.g. a charging rabbit stuck in a tree: the big punish window).</summary>
        public void Stun(double seconds)
        {
            _staggerFor = Math.Max(0.05, seconds);
            _engaged = true;
            Enter(AiState.Staggered);
            CurrentAttack = null; CurrentTiming = null;
        }

        public AiCommand Tick(double dt, AiSense s)
        {
            foreach (var k in _cooldownLeft.Keys.ToList()) _cooldownLeft[k] = Math.Max(0, _cooldownLeft[k] - dt);
            _stateTime += dt;
            var b = _motion.Behavior;
            if (AlertedFor > 0) { AlertedFor = Math.Max(0, AlertedFor - dt); s.DistanceToPlayer = Math.Min(s.DistanceToPlayer, b.AlertRadius); }
            if (s.TargetWarded) { AlertedFor = 0; s.DistanceToPlayer = double.MaxValue; } // out of reach behind the ward
            var nav = _motion.NavAgent;
            var cmd = new AiCommand { Move = AiMove.None, Speed = 0 };
            // Being hit = the HP fraction dropped since the last tick (no extra input needed from the game).
            if (s.HpFraction > 0) { if (_lastHp > 0 && s.HpFraction < _lastHp - 1e-9) _engaged = true; _lastHp = s.HpFraction; }
            var tac = Tactics ?? GroupTacticsTuning.Default;
            // Tactics disabled (groupTactics.enabled = false): behave exactly like the brain before tactics. The player's HP counts
            // as "not supplied" for the retreat rules, there is no yielding, no flank angle and no threat score.
            bool tacOn = tac.Enabled;
            double playerHp = tacOn ? s.PlayerHpFraction : 0;
            bool yieldToken = tacOn && s.YieldToken;
            if (tacOn) cmd.ThreatLevel = ThreatAssessor.Score(s.PlayerHpFraction, Math.Max(s.PackmatesNear, s.AlliesNear), s.HpFraction, tac);

            // Leash: everyone gives up past the leash (territorial monsters sooner, at the alert radius ×1.5).
            double leash = IsTerritorial ? Math.Min(b.LeashRadius, b.AlertRadius * 1.5) : b.LeashRadius;
            bool busy = State == AiState.Windup || State == AiState.Active || State == AiState.Recovery || State == AiState.Staggered;
            if (!busy && State != AiState.Return && State != AiState.Idle && s.DistanceFromHome > leash) Enter(AiState.Return);
            if (!busy && s.TargetWarded && (State == AiState.Chase || State == AiState.Reposition || State == AiState.Flee)) Enter(AiState.Return);
            // A pack hunter left alone and hurt falls back home instead of fighting on (Greyborn's fight-or-flee odds).
            if (!busy && IsPack && s.PackmatesNear == 0 && s.HpFraction > 0 && s.HpFraction < RetreatRule.LoneThreshold(LoneRetreatHp, playerHp, tac) && State == AiState.Chase) Enter(AiState.Return);
            if (!busy && State != AiState.Flee && (!IsPassive || _engaged) && b.RetreatHpPct > 0 && s.HpFraction > 0 && s.HpFraction <= RetreatRule.SpeciesThreshold(b.RetreatHpPct, playerHp, tac) && State != AiState.Return)
                Enter(AiState.Flee);

            switch (State)
            {
                case AiState.Idle:
                    if (IsPassive)
                    {
                        // Ignores you: only a hit or a packmate's call (both set _engaged) starts the fight.
                        if (_engaged) Enter(IsSkittish ? AiState.Flee : AiState.Chase);
                    }
                    else if (IsAmbush)
                    {
                        // Dormant until you step inside the short trigger radius (or hurt it), then the opening strike.
                        if (_engaged || s.DistanceToPlayer <= Math.Min(b.AlertRadius, AmbushMaxTriggerM)) Enter(AiState.Chase);
                    }
                    else if (s.DistanceToPlayer <= b.AlertRadius) Enter(IsSkittish ? AiState.Flee : AiState.Chase);
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
                    // Stalker: trail at a distance until the player is busy with another enemy or hurt (or it was hit itself).
                    if (IsStalker && !_committed)
                    {
                        bool busyPlayer = Math.Max(s.PackmatesNear, s.AlliesNear) > 0;
                        bool hurtPlayer = s.PlayerHpFraction > 0 && s.PlayerHpFraction < StalkCommitPlayerHp;
                        if (_engaged || busyPlayer || hurtPlayer) _committed = true;
                    }
                    if (IsStalker && !_committed && !(IsAmbush && _opening))
                    {
                        if (State == AiState.Reposition) Enter(AiState.Chase);
                        double trail = Math.Min(Math.Max(StalkMinTrailM, b.AlertRadius * StalkTrailFrac), Math.Max(b.AlertRadius, StalkMinTrailM));
                        double d = s.DistanceToPlayer;
                        cmd.ReleaseToken = true;
                        double slow = nav.WalkSpeed > 0 ? nav.WalkSpeed : nav.Speed * 0.4;
                        if (d > trail + StalkBandM) { cmd.Move = AiMove.Toward; cmd.Speed = nav.Speed; }
                        else if (d < trail - StalkBandM) { cmd.Move = AiMove.Away; cmd.Speed = slow; }
                        else { cmd.Move = AiMove.Circle; cmd.Speed = slow; }
                        break;
                    }
                    var choice = IsAmbush && _opening ? ChooseOpening(s.DistanceToPlayer) : Choose(s.DistanceToPlayer);
                    if (choice.data != null)
                    {
                        cmd.WantsToken = true;
                        if (s.HasToken && !yieldToken) { _opening = false; StartWindup(choice); cmd.Move = AiMove.None; break; }
                        Enter(AiState.Reposition);
                        cmd.Move = AiMove.Circle; cmd.Speed = nav.WalkSpeed > 0 ? nav.WalkSpeed : nav.Speed * 0.4;
                        if (yieldToken) { cmd.WantsToken = false; cmd.ReleaseToken = true; }
                        if (tacOn && s.FlankSlot > 0) cmd.FlankAngleDeg = FlankSlots.AngleDeg(s.FlankSlot, tac, s.FlankSlotCount);
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
                    if (_stateTime >= _staggerFor) Enter(AiState.Chase);
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

        /// <summary>The ambusher's opening strike: the ready attack with the longest reach (a lunge, dash or ranged one), ignoring the upper reach limit so it can cover the trigger radius.</summary>
        (AttackData data, AttackTimingData timing) ChooseOpening(double distance)
        {
            var ready = _attacks.Where(a => Cooldown(a.data.Id) <= 0 && distance >= MinRangeOf(a.timing)).ToList();
            if (ready.Count == 0) return default;
            return ready.OrderByDescending(a => ReachOf(a.timing)).ThenByDescending(a => a.data.Power).First();
        }

        double Cooldown(string id) => _cooldownLeft.TryGetValue(id, out var c) ? c : 0;

        void StartWindup((AttackData data, AttackTimingData timing) a)
        {
            CurrentAttack = a.data; CurrentTiming = a.timing;
            _windup = a.timing.WindupSec;
            _cooldownLeft[a.data.Id] = Math.Max(a.data.CooldownSec, a.timing.WindupSec + a.timing.ActiveSec + a.timing.RecoverySec);
            Enter(AiState.Windup);
        }

        void Enter(AiState s)
        {
            State = s; _stateTime = 0;
            if (s == AiState.Idle) { _engaged = false; _committed = false; _opening = true; }
        }
    }
}
