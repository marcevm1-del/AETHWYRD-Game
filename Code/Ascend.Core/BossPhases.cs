using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Boss phases (08_Bestiary/bosses_and_calamities.md §1). Data: Data/Monsters/boss_phases.json.

    public sealed class BossSummon { public string SpeciesId { get; set; } public int Count { get; set; } = 1; }

    public sealed class BossPhaseData
    {
        public string Name { get; set; }
        /// <summary>The phase starts when HP falls to this fraction or below (the first phase is 1.0).</summary>
        public double AtHpFraction { get; set; } = 1.0;
        public string Banner { get; set; }
        public List<BossSummon> Summon { get; set; } = new List<BossSummon>();
        /// <summary>Speed of its whole routine (attacks and movement); 1 = normal.</summary>
        public double Tempo { get; set; } = 1.0;
        public double DamageMult { get; set; } = 1.0;
    }

    public sealed class BossData
    {
        public string SpeciesId { get; set; }
        public List<BossPhaseData> Phases { get; set; } = new List<BossPhaseData>();
    }

    public sealed class BossFile
    {
        public string Notes { get; set; }
        public List<BossData> Bosses { get; set; } = new List<BossData>();
    }

    /// <summary>
    /// One boss fight's phase tracker. Feed it the boss's HP fraction; it reports each phase as it begins (once,
    /// in order — a big hit that skips a threshold still plays the skipped phase's entrance first).
    /// </summary>
    public sealed class BossFight
    {
        readonly List<BossPhaseData> _phases;

        public BossFight(BossData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            _phases = data.Phases.OrderByDescending(p => p.AtHpFraction).ToList();
            if (_phases.Count == 0) _phases.Add(new BossPhaseData { Name = "Fight" });
        }

        public int PhaseIndex { get; private set; }
        public BossPhaseData Current => _phases[PhaseIndex];
        public int PhaseCount => _phases.Count;
        public double Tempo => Current.Tempo;
        public double DamageMult => Current.DamageMult;

        /// <summary>Phases that begin at this HP (usually none or one).</summary>
        public List<BossPhaseData> Update(double hpFraction)
        {
            var begun = new List<BossPhaseData>();
            while (PhaseIndex + 1 < _phases.Count && hpFraction <= _phases[PhaseIndex + 1].AtHpFraction)
            {
                PhaseIndex++;
                begun.Add(_phases[PhaseIndex]);
            }
            return begun;
        }
    }
}
