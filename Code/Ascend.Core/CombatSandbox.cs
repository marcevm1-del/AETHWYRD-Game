using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // A scripted-fight harness: dummies, scripted hits, a clock, a readout. Deterministic (takes an IRandom).
    // Reactions' DoT and hazards are reported in the readout but not simulated as ticking damage.

    public sealed class SandboxDummySpec
    {
        public string Id { get; set; }
        public string SpeciesId { get; set; }
        public Element Element { get; set; } = Element.None;
        /// <summary>None = the element's default weakness (Elements.WeaknessOf) when the dummy has an element.</summary>
        public Element? Weakness { get; set; }
        /// <summary>Max HP; 0 (or less) means the tuning default (combat_tuning.json sandbox.defaultDummyHp).</summary>
        public int Hp { get; set; }
        public double Defense { get; set; }
        /// <summary>Optional armor. Null falls back to the boss weak point data for SpeciesId, if any.</summary>
        public BossArmorData Armor { get; set; }
        /// <summary>Optional boss phases; the phase name picks which weak points are exposed.</summary>
        public BossData Phases { get; set; }
    }

    public sealed class SandboxHit
    {
        public string AttackerId { get; set; } = "player";
        public string TargetId { get; set; }
        public Element Element { get; set; } = Element.None;
        public HitWeight Weight { get; set; } = HitWeight.Light;
        /// <summary>A free label for the attacker's weight class, echoed in the readout.</summary>
        public string WeightClass { get; set; }
        public string BodyPart { get; set; }
        public DamageKind Kind { get; set; } = DamageKind.Physical;
        public double Attack { get; set; } = 100;
        public double Power { get; set; } = 1.0;
        public double CritChance { get; set; }
        /// <summary>Seconds the clock advances before this hit lands.</summary>
        public double WaitSec { get; set; }
    }

    public sealed class HitReadout
    {
        public double Time { get; set; }
        public string AttackerId { get; set; }
        public string TargetId { get; set; }
        public int Damage { get; set; }
        public bool Crit { get; set; }
        public int HpAfter { get; set; }
        public bool Killed { get; set; }
        // multiplier breakdown
        public double ElementMult { get; set; } = 1;
        public double ReactionMult { get; set; } = 1;
        public double SynergyMult { get; set; } = 1;
        public double ShatterMult { get; set; } = 1;
        public double WeakPointMult { get; set; } = 1;
        public double BrokenArmorMult { get; set; } = 1;
        public double TotalExtraMult { get; set; } = 1;
        public Reaction Reaction { get; set; }
        public string SynergyId { get; set; }
        public string WeakPointId { get; set; }
        public ReactionDot Dot { get; set; }
        public ReactionHazard Hazard { get; set; }
        public SwirlSpread? Swirl { get; set; }
        public double ArmorDamage { get; set; }
        public double ArmorAfter { get; set; }
        public bool ArmorBrokeNow { get; set; }
        public bool ArmorBroken { get; set; }
        public string Phase { get; set; }
    }

    public sealed class DummyReadout
    {
        public string Id { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public Element Aura { get; set; }
        public bool Frozen { get; set; }
        public bool Stunned { get; set; }
        public double Armor { get; set; }
        public bool ArmorBroken { get; set; }
        public string Phase { get; set; }
    }

    public sealed class SandboxReadout
    {
        public double Time { get; set; }
        public List<HitReadout> Hits { get; set; } = new List<HitReadout>();
        public List<DummyReadout> Dummies { get; set; } = new List<DummyReadout>();
    }

    public sealed class CombatSandbox
    {
        sealed class Dummy
        {
            public SandboxDummySpec Spec;
            public int Hp;
            public int MaxHp;
            public ReactionState Reactions;
            public BossArmor Armor;
            public BossWeakPointData Boss;
            public BossFight Fight;
            public double PhaseStartedAt;
        }

        readonly CombatTuning _tuning;
        readonly IRandom _rng;
        readonly ReactionTable _table;
        readonly BossWeakPointFile _weakPoints;
        readonly DamageCalculator _calc;
        readonly Dictionary<string, Dummy> _dummies = new Dictionary<string, Dummy>();
        readonly List<string> _order = new List<string>();
        readonly List<HitReadout> _hits = new List<HitReadout>();

        public double Now { get; private set; }

        /// <summary>The sandbox's seeded generator from tuning (sandbox.defaultSeed).</summary>
        public static IRandom DefaultRandom(CombatTuning tuning) => new DeterministicRandom((ulong)Math.Max(0, tuning?.Sandbox.DefaultSeed ?? 12345));

        /// <summary>A null <paramref name="rng"/> uses <see cref="DefaultRandom"/> (sandbox.defaultSeed), so unseeded runs are still reproducible.</summary>
        public CombatSandbox(CombatTuning tuning, IRandom rng = null, ReactionTable table = null, BossWeakPointFile weakPoints = null)
        {
            _tuning = tuning ?? throw new ArgumentNullException(nameof(tuning));
            _rng = rng ?? DefaultRandom(tuning);
            _table = table ?? ReactionTable.Default;
            _weakPoints = weakPoints ?? new BossWeakPointFile();
            _calc = new DamageCalculator(_tuning.Damage);
        }

        /// <summary>Spawns <paramref name="count"/> copies (ids id_1..id_n) or one dummy when count is 1.</summary>
        public void AddDummy(SandboxDummySpec spec, int count = 1)
        {
            if (spec == null || string.IsNullOrEmpty(spec.Id)) throw new ArgumentException("dummy needs an id");
            int max = Math.Max(1, _tuning.Sandbox.MaxDummies);
            if (_dummies.Count + Math.Max(1, count) > max)
                throw new InvalidOperationException($"the sandbox holds at most {max} dummies (combat_tuning.json sandbox.maxDummies); it has {_dummies.Count} and {Math.Max(1, count)} more were asked for");
            int hp = spec.Hp > 0 ? spec.Hp : Math.Max(1, _tuning.Sandbox.DefaultDummyHp);
            for (int i = 1; i <= Math.Max(1, count); i++)
            {
                string id = count <= 1 ? spec.Id : spec.Id + "_" + i;
                if (_dummies.ContainsKey(id)) throw new InvalidOperationException($"duplicate dummy \"{id}\"");
                var boss = _weakPoints.Bosses.FirstOrDefault(b => b.SpeciesId == spec.SpeciesId);
                var armorData = spec.Armor ?? boss?.Armor;
                var d = new Dummy
                {
                    Spec = spec,
                    Hp = hp,
                    MaxHp = hp,
                    Reactions = new ReactionState(_tuning.Reactions, _table),
                    Boss = boss,
                    Armor = armorData != null ? new BossArmor(armorData) : null,
                    Fight = spec.Phases != null ? new BossFight(spec.Phases) : null,
                };
                _dummies[id] = d;
                _order.Add(id);
            }
        }

        public void Advance(double seconds)
        {
            if (seconds < 0) throw new ArgumentOutOfRangeException(nameof(seconds));
            Now += seconds;
        }

        public HitReadout Hit(SandboxHit hit)
        {
            if (hit == null) throw new ArgumentNullException(nameof(hit));
            if (!_dummies.TryGetValue(hit.TargetId ?? "", out var d)) throw new InvalidOperationException($"no dummy \"{hit.TargetId}\"");
            if (hit.WaitSec > 0) Advance(hit.WaitSec);
            var now = Now;
            var ro = new HitReadout { Time = now, AttackerId = hit.AttackerId, TargetId = hit.TargetId };

            // Boss phase from the HP fraction before this hit.
            if (d.Fight != null)
            {
                int before = d.Fight.PhaseIndex;
                d.Fight.Update((double)d.Hp / d.MaxHp);
                if (d.Fight.PhaseIndex != before) d.PhaseStartedAt = now;
                ro.Phase = d.Fight.Current.Name;
            }

            // Weak point + armor (state before this hit).
            double armorBonus = 1.0;
            if (d.Boss != null || d.Armor != null)
            {
                // A dummy with no Phases has no phase name (ro.Phase is null). When its boss record has weak points that is read as
                // "any phase": every weak point of the record counts as exposed, so a bare dummy can still be used to test them.
                var tr = BossTargeting.Resolve(d.Boss, ro.Phase, hit.BodyPart, hit.Weight, d.Fight != null ? now - d.PhaseStartedAt : double.NaN, _weakPoints.ArmorDamageByWeight, anyPhase: d.Fight == null);
                ro.WeakPointMult = tr.DamageMult;
                ro.WeakPointId = tr.WeakPoint?.Id;
                ro.ArmorDamage = tr.ArmorDamage;
                if (d.Armor != null)
                {
                    armorBonus = d.Armor.DamageTakenMult(now);
                    ro.BrokenArmorMult = armorBonus;
                }
            }

            // Shatter looks at the state before this hit, so the hit that freezes does not shatter itself.
            ro.ShatterMult = d.Reactions.HitMultiplier(hit.Weight, now);
            var rr = d.Reactions.ApplyElementDetailed(hit.Element, now);
            ro.Reaction = rr.Reaction;
            ro.ReactionMult = rr.BonusMult;
            ro.SynergyMult = rr.SynergyMult;
            ro.SynergyId = rr.Synergy?.Id;
            ro.Dot = rr.Dot;
            ro.Hazard = rr.Hazard;
            ro.Swirl = rr.Swirl;

            // The product of every extra multiplier is exposed here and left UNCAPPED on purpose (all numbers are proposals);
            // read TotalExtraMult in the readout to judge how far stacking runs.
            ro.TotalExtraMult = ro.ShatterMult * ro.ReactionMult * ro.SynergyMult * ro.WeakPointMult * ro.BrokenArmorMult;

            var weakness = d.Spec.Weakness ?? (d.Spec.Element != Element.None ? Elements.WeaknessOf(d.Spec.Element) : Element.None);
            var res = _calc.Compute(new DamageInput
            {
                Kind = hit.Kind,
                Attack = hit.Attack,
                Defense = d.Spec.Defense,
                Power = hit.Power,
                AttackElement = hit.Element,
                DefenderWeakness = weakness,
                DefenderResist = d.Spec.Element,
                CritChance = hit.CritChance,
                ReactionMult = ro.TotalExtraMult,
            }, _rng);
            ro.Damage = res.Amount;
            ro.Crit = res.Crit;
            ro.ElementMult = res.ElementMult;

            d.Hp = Math.Max(0, d.Hp - res.Amount);
            ro.HpAfter = d.Hp;
            ro.Killed = d.Hp == 0;

            if (d.Armor != null)
            {
                ro.ArmorBrokeNow = d.Armor.Hit(ro.ArmorDamage, now);
                ro.ArmorAfter = d.Armor.Value(now);
                ro.ArmorBroken = d.Armor.IsBroken(now);
            }
            _hits.Add(ro);
            return ro;
        }

        public SandboxReadout Run(IEnumerable<SandboxHit> script)
        {
            foreach (var h in script ?? Enumerable.Empty<SandboxHit>()) Hit(h);
            return Readout();
        }

        public SandboxReadout Readout()
        {
            var r = new SandboxReadout { Time = Now, Hits = new List<HitReadout>(_hits) };
            foreach (var id in _order)
            {
                var d = _dummies[id];
                r.Dummies.Add(new DummyReadout
                {
                    Id = id,
                    Hp = d.Hp,
                    MaxHp = d.MaxHp,
                    Aura = d.Reactions.Aura.Current(Now),
                    Frozen = d.Reactions.IsFrozen(Now),
                    Stunned = d.Reactions.IsStunned(Now),
                    Armor = d.Armor != null ? d.Armor.Value(Now) : 0,
                    ArmorBroken = d.Armor != null && d.Armor.IsBroken(Now),
                    Phase = d.Fight?.Current.Name,
                });
            }
            return r;
        }
    }
}
