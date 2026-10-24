using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Taming (12_Systems/systems.md §7, Taming Roster). Numbers: Data/World/world_tuning.json → taming.

    public sealed class TamingTuning
    {
        public double WeakenHpFraction { get; set; } = 0.3;
        public double NearMeters { get; set; } = 4;
        public double CalmPerSec { get; set; } = 10;
        public double CrouchCalmPerSec { get; set; } = 8;
        public double FearPerAttack { get; set; } = 30;
        public double FearPerDodge { get; set; } = 15;
        public double FearDecayPerSec { get; set; } = 4;
        public double LikedFoodCalm { get; set; } = 35;
        public double WrongFoodFear { get; set; } = 10;
        public double BaseChance { get; set; } = 0.2;
        public double CalmWeight { get; set; } = 0.006;
        public double FearWeight { get; set; } = 0.006;
        public double ChaWeight { get; set; } = 0.01;
        public double LikedFoodBonus { get; set; } = 0.15;
        public double TamerBonus { get; set; } = 0.15;
        public double EnrageChance { get; set; } = 0.35;
        public double RetrySec { get; set; } = 60;
        public int ActivePartners { get; set; } = 3;
        public int BondPerAssists { get; set; } = 3;
        public int MaxBond { get; set; } = 10;
        public int EvolveBond { get; set; } = 5;
        public double KnockedOutSec { get; set; } = 20;
        public double SupportHealFraction { get; set; } = 0.03;
        public double SupportHealEverySec { get; set; } = 6;
        public List<string> UntameableFamilies { get; set; } = new List<string>();
        public Dictionary<string, string> FavouriteFood { get; set; } = new Dictionary<string, string>();
    }

    public enum TameBlock { None, Untameable, AboveYourRank, NotWeakened, Defeated, Remembered }
    public enum TameResult { Tamed, Fled, Enraged }

    public static class TamingRules
    {
        /// <summary>Why this monster can't be tamed right now (None = it can).</summary>
        public static TameBlock CanAttempt(SpeciesData s, double hpFraction, RankLetter playerRank, bool isTamer, TamingTuning t)
        {
            if (s == null || t == null) throw new ArgumentNullException(s == null ? nameof(s) : nameof(t));
            if (s.IsUnique || s.IsTyrant || t.UntameableFamilies.Contains(s.Family)) return TameBlock.Untameable; // some need special quests
            var rank = Rank.Parse(s.Rank);
            if ((int)rank.Letter > (int)playerRank + (isTamer ? 1 : 0)) return TameBlock.AboveYourRank;           // your rank +0 (Tamer +1)
            if (hpFraction <= 0) return TameBlock.Defeated;                                                        // overkill ruins the tame
            if (hpFraction > t.WeakenHpFraction) return TameBlock.NotWeakened;
            return TameBlock.None;
        }

        public static string FavouriteFood(SpeciesData s, TamingTuning t) =>
            s != null && t.FavouriteFood.TryGetValue(s.Family ?? "", out var id) ? id : null;
    }

    /// <summary>
    /// One taming encounter: a calm meter and a fear meter (0–100). Staying near without attacking raises calm (a
    /// crouched, walking approach more); attacks and dodges near it raise fear; fear fades slowly. Fear at 100 and it
    /// flees. Offer when ready: chance = base + calm·w − fear·w + CHA·w (+ favourite food, + Tamer).
    /// </summary>
    public sealed class TameEncounter
    {
        readonly TamingTuning _t;

        public TameEncounter(SpeciesData species, TamingTuning tuning)
        {
            Species = species ?? throw new ArgumentNullException(nameof(species));
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
        }

        public SpeciesData Species { get; }
        public double Calm { get; private set; }
        public double Fear { get; private set; }
        public bool Spooked => Fear >= 100;

        public void Tick(double seconds, bool near, bool crouched)
        {
            seconds = Math.Max(0, seconds);
            if (near) Calm = Clamp(Calm + (_t.CalmPerSec + (crouched ? _t.CrouchCalmPerSec : 0)) * seconds);
            Fear = Clamp(Fear - _t.FearDecayPerSec * seconds);
        }

        public void Attacked() => Fear = Clamp(Fear + _t.FearPerAttack);
        public void Dodged() => Fear = Clamp(Fear + _t.FearPerDodge);

        /// <summary>A snack: its favourite calms it a lot; anything else unsettles it a little.</summary>
        public bool Feed(string itemId)
        {
            bool liked = itemId != null && itemId == TamingRules.FavouriteFood(Species, _t);
            if (liked) Calm = Clamp(Calm + _t.LikedFoodCalm); else Fear = Clamp(Fear + _t.WrongFoodFear);
            return liked;
        }

        public double Chance(double cha, bool likedFoodOffered, bool isTamer) =>
            Math.Max(0.02, Math.Min(0.95, _t.BaseChance + Calm * _t.CalmWeight - Fear * _t.FearWeight + cha * _t.ChaWeight
                                          + (likedFoodOffered ? _t.LikedFoodBonus : 0) + (isTamer ? _t.TamerBonus : 0)));

        public TameResult Offer(double cha, bool likedFoodOffered, bool isTamer, IRandom rng)
        {
            if (rng == null) throw new ArgumentNullException(nameof(rng));
            if (rng.NextDouble() < Chance(cha, likedFoodOffered, isTamer)) return TameResult.Tamed;
            return rng.NextDouble() < _t.EnrageChance ? TameResult.Enraged : TameResult.Fled;
        }

        static double Clamp(double v) => Math.Max(0, Math.Min(100, v));
    }

    /// <summary>Your monsters: up to ActivePartners travel with you; the rest wait on the ranch.</summary>
    public sealed class PartnerRoster
    {
        readonly TamingTuning _t;
        readonly List<PartnerData> _all = new List<PartnerData>();

        public PartnerRoster(TamingTuning tuning) { _t = tuning ?? throw new ArgumentNullException(nameof(tuning)); }

        public IReadOnlyList<PartnerData> All => _all;
        public IEnumerable<PartnerData> Active => _all.Where(p => p.Active);
        public IEnumerable<PartnerData> Ranch => _all.Where(p => !p.Active);

        /// <summary>Adds a newly tamed monster: it joins you if there's room, else goes to the ranch.</summary>
        public PartnerData Add(string speciesId, string name)
        {
            var p = new PartnerData { SpeciesId = speciesId, Name = name, Active = Active.Count() < _t.ActivePartners };
            _all.Add(p);
            return p;
        }

        /// <summary>Swaps a partner in or out (in only if there's room).</summary>
        public bool SetActive(PartnerData p, bool active)
        {
            if (!_all.Contains(p)) return false;
            if (active && !p.Active && Active.Count() >= _t.ActivePartners) return false;
            p.Active = active;
            return true;
        }

        public void Release(PartnerData p) => _all.Remove(p);

        public void Load(IEnumerable<PartnerData> partners)
        {
            _all.Clear();
            foreach (var p in partners ?? Enumerable.Empty<PartnerData>())
                _all.Add(new PartnerData { SpeciesId = p.SpeciesId, Name = p.Name, Active = p.Active && Active.Count() < _t.ActivePartners, Bond = p.Bond, Assists = p.Assists, Evolved = p.Evolved });
        }
    }

    /// <summary>systems.md §7.2. Hauler and Mount come with cargo and riding.</summary>
    public enum PartnerRole { Striker, Vanguard, Support, Scout }

    public static class Partners
    {
        /// <summary>The role a species takes, from its behaviour: guardians and territorial monsters hold the line, gentle ones
        /// support, skittish and ambushing ones scout, the rest strike.</summary>
        public static PartnerRole RoleOf(SpeciesData s)
        {
            switch (s?.Behavior)
            {
                case "Guardian": case "Territorial": return PartnerRole.Vanguard;
                case "Passive": return PartnerRole.Support;
                case "Skittish": case "Ambush": return PartnerRole.Scout;
                default: return PartnerRole.Striker;
            }
        }

        /// <summary>Evolution branches (systems.md §7.3): the species' variants (elemental, elder, ancient, regional…).</summary>
        public static List<SpeciesData> Branches(string speciesId, GameDatabase db) =>
            db.Species.Values.Where(x => x.BaseSpeciesId == speciesId).OrderBy(x => Rank.Parse(x.Rank).Value).ThenBy(x => x.Id).ToList();

        public static bool CanEvolve(PartnerData p, GameDatabase db, TamingTuning t) =>
            p != null && !p.Evolved && p.Bond >= t.EvolveBond && Branches(p.SpeciesId, db).Count > 0;

        /// <summary>Evolves into the chosen branch (must be one of its variants). Keeps the name and bond.</summary>
        public static bool Evolve(PartnerData p, string branchId, GameDatabase db, TamingTuning t)
        {
            if (!CanEvolve(p, db, t) || !Branches(p.SpeciesId, db).Any(b => b.Id == branchId)) return false;
            p.SpeciesId = branchId;
            p.Evolved = true;
            return true;
        }

        /// <summary>Fighting together: every BondPerAssists shared victories raise Bond by one (to the cap). True when Bond rose.</summary>
        public static bool Assist(PartnerData p, TamingTuning t)
        {
            if (p == null || p.Bond >= t.MaxBond) return false;
            p.Assists++;
            if (p.Assists < t.BondPerAssists) return false;
            p.Assists = 0;
            p.Bond++;
            return true;
        }
    }

    public sealed class PartnerData
    {
        public string SpeciesId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        /// <summary>0–10 (systems.md §7.3; grows later).</summary>
        public int Bond { get; set; }
        /// <summary>Shared victories toward the next Bond point.</summary>
        public int Assists { get; set; }
        public bool Evolved { get; set; }
    }
}
