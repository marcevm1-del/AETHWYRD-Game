using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ascend.Core
{
    // Ground mounts (Wave C). Numbers: Data/Companions/mounts.json. Canon: the player cannot ride flying mounts;
    // pack animals are knocked out, not killed, unless Hardcore/Mortal Bonds. Aquatic mounts are an open Canon
    // question and are not built. Base speed is a PLACEHOLDER (10 m/s, not approved). Every default below equals
    // the shipped JSON, so a data folder without the file (an old config) still behaves.

    public sealed class MountSpeed
    {
        public double Value { get; set; } = 10.0;
        public bool Placeholder { get; set; } = true;
        public string Note { get; set; } = "placeholder, not approved";
    }

    public sealed class MountStamina
    {
        public double Max { get; set; } = 100;
        public double SprintDrainPerSec { get; set; } = 12;
        public double RegenPerSec { get; set; } = 8;
        public double ExhaustedBelow { get; set; } = 5;
        public double RecoverTo { get; set; } = 35;
    }

    public sealed class MountFamily
    {
        public string Label { get; set; }
        public double SpeedMult { get; set; } = 1.0;
        public Dictionary<string, double> Terrain { get; set; } = new Dictionary<string, double>();
        public MountStamina Stamina { get; set; } = new MountStamina();
        public double CarryBonus { get; set; }
        public string UnlockRank { get; set; } = "F";
        public bool KnockoutOnly { get; set; } = true;
        public List<string> Species { get; set; } = new List<string>();
    }

    public sealed class MountedCombatRules
    {
        public List<string> BannedSkillTags { get; set; } = new List<string> { "big", "aerial", "channelled" };
        public double MeleeReachCapM { get; set; } = 2.5;
        public bool DismountOnStagger { get; set; } = true;
        public double DamageMult { get; set; } = 0.85;
        public int MaxChainHits { get; set; } = 3;
        public bool NoMountInterior { get; set; } = true;
    }

    public sealed class MountTable
    {
        public const string RankLetters = "FEDCBAS";
        static readonly Regex Banned = new Regex("flying|aerial|celestial|dragon|griffin|griffon|aquatic|wyvern|pegasus|hippogriff|drake", RegexOptions.IgnoreCase);
        static readonly Regex FlyRig = new Regex("flyer|wyvern|dragon|avian|fish|floating|cephalopod|serpent|naga", RegexOptions.IgnoreCase);
        static readonly Regex FlyType = new Regex("^(Dragon|Avian|Aquatic|Spirit|Mythic Beast)$");

        public int Version { get; set; } = 1;
        public MountSpeed SpeedMps { get; set; } = new MountSpeed();
        public double ExhaustedWalkFraction { get; set; } = 0.3385;
        public Dictionary<string, double> Condition { get; set; } = new Dictionary<string, double> { { "encumbered", 0.85 }, { "wet", 0.95 } };
        public Dictionary<string, MountFamily> Families { get; set; } = new Dictionary<string, MountFamily>();
        public MountedCombatRules MountedCombat { get; set; } = new MountedCombatRules();
        public bool KnockedOutNotKilled { get; set; } = true;

        /// <summary>Old-config safety: a missing table becomes the safe default (no families, nothing rideable).</summary>
        public static MountTable OrDefault(MountTable t) => t ?? new MountTable();

        public bool TryFamily(string key, out MountFamily family)
        {
            family = null;
            return key != null && Families != null && Families.TryGetValue(key, out family) && family != null;
        }

        /// <summary>Speed in m/s = placeholder base x family x terrain x conditions. 0 for an unknown family; unknown terrain or
        /// condition counts as 1. The "exhausted" condition limits the mount to a walk (ExhaustedWalkFraction of the run-pace speed).</summary>
        public double Speed(string family, string terrain = "plains", IEnumerable<string> conditions = null)
        {
            if (!TryFamily(family, out var f)) return 0.0;
            double v = SpeedMps.Value * f.SpeedMult;
            double t;
            if (terrain != null && f.Terrain != null && f.Terrain.TryGetValue(terrain, out t)) v *= t;
            if (conditions != null)
                foreach (var c in conditions)
                {
                    if (c == "exhausted") v *= ExhaustedWalkFraction;
                    else if (Condition != null && Condition.TryGetValue(c ?? "", out var m)) v *= m;
                }
            return v;
        }

        static int RankIndex(string letter) => string.IsNullOrEmpty(letter) ? -1 : RankLetters.IndexOf(char.ToUpperInvariant(letter[0]));

        /// <summary>Guild rank letter (F..S, any +/- is ignored) must reach the family's unlockRank; interior dungeons forbid mounts.</summary>
        public bool CanMount(string family, string playerRank, bool interiorDungeon = false)
        {
            if (!TryFamily(family, out var f)) return false;
            if (interiorDungeon && MountedCombat.NoMountInterior) return false;
            return RankIndex(playerRank) >= RankIndex(f.UnlockRank) && RankIndex(playerRank) >= 0;
        }

        /// <summary>Skill allowed on a mount: no banned tag (big, aerial, channelled), melee reach within the cap, chain not past the hit limit.</summary>
        public bool CanUseSkillMounted(IEnumerable<string> skillTags, double reachM = 0.0, int chainHitIndex = 0)
        {
            if (skillTags != null)
                foreach (var tag in skillTags)
                    foreach (var b in MountedCombat.BannedSkillTags)
                        if (string.Equals(tag, b, StringComparison.OrdinalIgnoreCase)) return false;
            if (reachM > MountedCombat.MeleeReachCapM) return false;
            return chainHitIndex < MountedCombat.MaxChainHits;
        }

        /// <summary>Pack animals and mounts are knocked out instead of killed unless Mortal Bonds (Hardcore) is on.</summary>
        public bool KnockedOutInsteadOfKilled(bool mortalBonds) => KnockedOutNotKilled && !mortalBonds;

        /// <summary>Throws InvalidOperationException if any family key or species id names a flying/celestial/dragon/aquatic creature, or any
        /// given species row flies, is a dragon/celestial/aquatic, or is not a ground beast. Pass the species table to check rig and type.</summary>
        public void AssertGroundOnly(IReadOnlyDictionary<string, SpeciesData> species = null)
        {
            foreach (var kv in Families)
            {
                if (Banned.IsMatch(kv.Key)) throw new InvalidOperationException($"mounts: family \"{kv.Key}\" is not a ground mount");
                foreach (var id in kv.Value.Species)
                {
                    if (Banned.IsMatch(id)) throw new InvalidOperationException($"mounts: species \"{id}\" names a flying/celestial/dragon/aquatic creature");
                    if (species == null) continue;
                    if (!species.TryGetValue(id, out var sp)) throw new InvalidOperationException($"mounts: species \"{id}\" does not exist");
                    if (FlyRig.IsMatch(sp.RigId ?? "") || FlyType.IsMatch(sp.Type ?? ""))
                        throw new InvalidOperationException($"mounts: species \"{id}\" ({sp.Type}, {sp.RigId}) is not a ground beast");
                }
            }
        }
    }

    /// <summary>Per-mount runtime state: stamina with an exhausted flag that has hysteresis, and the rider's mounted flag.</summary>
    public sealed class MountState
    {
        readonly MountStamina _s;
        public double Stamina { get; private set; }
        public bool Exhausted { get; private set; }
        public bool Mounted { get; private set; }
        public bool KnockedOut { get; private set; }

        public MountState(MountFamily family = null)
        {
            _s = family?.Stamina ?? new MountStamina();
            Stamina = _s.Max;
        }

        public void Mount() { if (!KnockedOut) Mounted = true; }
        public void Dismount() { Mounted = false; }

        /// <summary>Sprinting drains stamina; otherwise it regenerates. Exhausted at or below ExhaustedBelow (sprint no longer drains,
        /// mount is held to a walk) and only clears once stamina reaches RecoverTo. Returns whether sprinting actually applied.</summary>
        public bool StepStamina(double dt, bool sprinting)
        {
            if (dt <= 0) return false;
            bool sprint = sprinting && !Exhausted && Mounted;
            if (sprint) Stamina -= _s.SprintDrainPerSec * dt;
            else Stamina += _s.RegenPerSec * dt;
            Stamina = Math.Max(0.0, Math.Min(_s.Max, Stamina));
            if (!Exhausted && Stamina <= _s.ExhaustedBelow) Exhausted = true;
            else if (Exhausted && Stamina >= _s.RecoverTo) Exhausted = false;
            return sprint;
        }

        /// <summary>The conditions to pass to MountTable.Speed for the current state.</summary>
        public string[] Conditions() => Exhausted ? new[] { "exhausted" } : new string[0];

        /// <summary>A stagger throws the rider; true when that dismounted them.</summary>
        public bool OnStagger(MountTable table)
        {
            if (!Mounted || !MountTable.OrDefault(table).MountedCombat.DismountOnStagger) return false;
            Mounted = false;
            return true;
        }

        /// <summary>Mount reaches 0 HP: it is knocked out and the rider dismounts; false when Mortal Bonds lets it die instead.</summary>
        public bool OnDefeated(MountTable table, bool mortalBonds)
        {
            Mounted = false;
            if (!MountTable.OrDefault(table).KnockedOutInsteadOfKilled(mortalBonds)) return false;
            KnockedOut = true;
            return true;
        }
    }
}
