using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Boss weak points and armor (08_Bestiary/bosses_and_calamities.md). Data: Data/Monsters/boss_weakpoints.json.
    // Engine-free: the caller passes the clock in seconds.

    public sealed class BossArmorData
    {
        public double MaxArmor { get; set; }
        /// <summary>How long the break lasts before the armor is restored.</summary>
        public double BreakSec { get; set; }
        /// <summary>Damage multiplier on the boss while its armor is broken (above 1).</summary>
        public double DamageTakenMultWhileBroken { get; set; } = 1.0;
        /// <summary>Seconds without an armor hit before an unbroken armor refills. Zero or less means it never refills.</summary>
        public double RegenDelaySec { get; set; }
    }

    public sealed class WeakPointData
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string BodyPart { get; set; }
        public double DamageMult { get; set; } = 1.0;
        public double ArmorDamageMult { get; set; } = 1.0;
        /// <summary>Phase names (from boss_phases.json) in which this point is exposed.</summary>
        public List<string> ExposedInPhases { get; set; } = new List<string>();
        /// <summary>If set, the point is only exposed this long after the phase begins.</summary>
        public double? ExposedSec { get; set; }
    }

    public sealed class BossWeakPointData
    {
        public string SpeciesId { get; set; }
        public BossArmorData Armor { get; set; } = new BossArmorData();
        public List<WeakPointData> WeakPoints { get; set; } = new List<WeakPointData>();
    }

    public sealed class BossWeakPointFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        /// <summary>Armor points one hit removes, by hit weight (keys light/medium/heavy/launch/skill/ultimate). Absent keys fall back to <see cref="BossTargeting.DefaultArmorDamage"/>.</summary>
        public Dictionary<string, double> ArmorDamageByWeight { get; set; }
        public List<BossWeakPointData> Bosses { get; set; } = new List<BossWeakPointData>();
    }

    /// <summary>
    /// One boss's armor bar. Hits chip it; at zero it breaks for BreakSec (the boss takes extra damage), then it is
    /// restored. An unbroken, unhit armor refills in full after RegenDelaySec. All against a passed-in clock.
    /// </summary>
    public sealed class BossArmor
    {
        readonly BossArmorData _d;
        double _value;
        double _lastHitAt = double.NegativeInfinity;
        double _brokenUntil = double.NegativeInfinity;

        public BossArmor(BossArmorData data)
        {
            _d = data ?? throw new ArgumentNullException(nameof(data));
            _value = Math.Max(0, data.MaxArmor);
        }

        public double MaxArmor => Math.Max(0, _d.MaxArmor);
        public bool HasArmor => MaxArmor > 0;

        public bool IsBroken(double now) => now < _brokenUntil;

        /// <summary>Armor left at <paramref name="now"/> (0 while broken).</summary>
        public double Value(double now)
        {
            Settle(now);
            return IsBroken(now) ? 0 : _value;
        }

        /// <summary>Damage multiplier the boss takes now: the break bonus while broken, else 1.</summary>
        public double DamageTakenMult(double now) => IsBroken(now) ? Math.Max(1.0, _d.DamageTakenMultWhileBroken) : 1.0;

        /// <summary>Chips the armor. Returns true when this hit broke it. Hits during a break change nothing.</summary>
        public bool Hit(double armorDamage, double now)
        {
            if (!HasArmor || armorDamage <= 0) return false;
            Settle(now);
            if (IsBroken(now)) return false;
            _value -= armorDamage;
            _lastHitAt = now;
            if (_value > 0) return false;
            _value = 0;
            _brokenUntil = now + Math.Max(0, _d.BreakSec);
            return true;
        }

        // Applies the lazy transitions: restore after a break, refill after the regen delay.
        void Settle(double now)
        {
            if (_value <= 0 && !IsBroken(now) && _brokenUntil > double.NegativeInfinity)
            {
                _value = MaxArmor;           // break over: armor is back
                _brokenUntil = double.NegativeInfinity;
                _lastHitAt = double.NegativeInfinity;
            }
            else if (_d.RegenDelaySec > 0 && _value > 0 && _value < MaxArmor && now - _lastHitAt >= _d.RegenDelaySec)
            {
                _value = MaxArmor;
            }
        }
    }

    public struct TargetingResult
    {
        /// <summary>Damage multiplier from the weak point hit (1 if none).</summary>
        public double DamageMult;
        /// <summary>Armor points this hit removes (before the armor's own state is considered).</summary>
        public double ArmorDamage;
        /// <summary>The weak point hit and currently exposed, or null.</summary>
        public WeakPointData WeakPoint;
    }

    public static class BossTargeting
    {
        /// <summary>The built-in armor damage per weight, used only when the data file has no armorDamageByWeight entry for it.</summary>
        public static double DefaultArmorDamage(HitWeight weight)
        {
            switch (weight)
            {
                case HitWeight.Light: return 1;
                case HitWeight.Medium: return 2;
                case HitWeight.Heavy: return 4;
                case HitWeight.Launch: return 4;
                case HitWeight.Skill: return 3;
                case HitWeight.Ultimate: return 8;
                default: return 1;
            }
        }

        /// <summary>Base armor damage a hit of this weight does to an unexposed part. Reads the data table (keys are lower-case weight names) when given, else the built-in defaults.</summary>
        public static double BaseArmorDamage(HitWeight weight, IReadOnlyDictionary<string, double> byWeight = null)
        {
            if (byWeight != null)
            {
                string name = weight.ToString();
                foreach (var kv in byWeight)
                    if (string.Equals(kv.Key, name, StringComparison.OrdinalIgnoreCase)) return kv.Value;
            }
            return DefaultArmorDamage(weight);
        }

        /// <summary>Resolves a hit on a body part during a phase (no exposure timer).</summary>
        public static TargetingResult Resolve(BossWeakPointData bossData, string phaseName, string hitPartId, HitWeight hitWeight) =>
            Resolve(bossData, phaseName, hitPartId, hitWeight, double.NaN, null);

        /// <summary>
        /// As above; <paramref name="secondsIntoPhase"/> (NaN = ignore) closes weak points that have an ExposedSec window.
        /// A part matches a weak point by its BodyPart or Id, case-insensitive. With <paramref name="anyPhase"/> the phase check is skipped (a harness target that has no phases).
        /// </summary>
        public static TargetingResult Resolve(BossWeakPointData bossData, string phaseName, string hitPartId, HitWeight hitWeight, double secondsIntoPhase, IReadOnlyDictionary<string, double> armorDamageByWeight = null, bool anyPhase = false)
        {
            var res = new TargetingResult { DamageMult = 1.0, ArmorDamage = BaseArmorDamage(hitWeight, armorDamageByWeight) };
            if (bossData == null || string.IsNullOrEmpty(hitPartId)) return res;
            foreach (var wp in bossData.WeakPoints)
            {
                bool part = string.Equals(wp.BodyPart, hitPartId, StringComparison.OrdinalIgnoreCase)
                         || string.Equals(wp.Id, hitPartId, StringComparison.OrdinalIgnoreCase);
                if (!part) continue;
                if (!anyPhase && !wp.ExposedInPhases.Any(p => string.Equals(p, phaseName, StringComparison.OrdinalIgnoreCase))) continue;
                if (wp.ExposedSec.HasValue && !double.IsNaN(secondsIntoPhase) && secondsIntoPhase > wp.ExposedSec.Value) continue;
                res.DamageMult = wp.DamageMult > 0 ? wp.DamageMult : 1.0;
                res.ArmorDamage = BaseArmorDamage(hitWeight, armorDamageByWeight) * (wp.ArmorDamageMult > 0 ? wp.ArmorDamageMult : 1.0);
                res.WeakPoint = wp;
                break;
            }
            return res;
        }
    }
}
