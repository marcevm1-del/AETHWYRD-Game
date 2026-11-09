using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Guild contract templates and the bounty board (Canon section 6 proposal M3; bible section 9). Data: Data/Quests/guild_contracts.json.
    // Templates are not quests: this class only decides what a player may take, what it pays and when it can be taken again.
    // No infinite loops: every template has a cooldown and every guild reputation event has a daily cap (Guilds.cs).

    public sealed class ContractCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public sealed class ContractTemplate
    {
        public string Id { get; set; }
        public string GuildId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string MinRank { get; set; }
        public string MaxRank { get; set; }
        public int CooldownDays { get; set; }
        /// <summary>low, mid or high.</summary>
        public string RewardBand { get; set; } = "mid";
        /// <summary>The member-ladder tier needed (1 Applicant: basic notices; 2 Initiate: low-risk; 3 Member; 4 Veteran; 5 Expert).</summary>
        public int MinTier { get; set; } = 1;
        public bool MembersOnly { get; set; }
    }

    public sealed class BountyClaimRules
    {
        public string Rule { get; set; }
        public double MinContributionShare { get; set; } = 0.15;
        public string SplitBy { get; set; }
        public bool Escrow { get; set; }
        public bool ReputationToQualifyingClaimants { get; set; }
    }

    public sealed class BountyRules
    {
        public List<string> Objectives { get; set; } = new List<string>();
        public List<string> Proofs { get; set; } = new List<string>();
        public Dictionary<string, List<string>> ProofsAccepted { get; set; } = new Dictionary<string, List<string>>();
        public BountyClaimRules Claim { get; set; } = new BountyClaimRules();
    }

    public sealed class ContractFile
    {
        public string Notes { get; set; }
        public List<ContractCategory> Categories { get; set; } = new List<ContractCategory>();
        public Dictionary<string, double> RewardBands { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, int> CopperByRank { get; set; } = new Dictionary<string, int>();
        public BountyRules Bounty { get; set; } = new BountyRules();
        public List<ContractTemplate> Templates { get; set; } = new List<ContractTemplate>();
    }

    public sealed class ContractsSave
    {
        /// <summary>Template id to the in-game day it was last handed in.</summary>
        public Dictionary<string, int> LastDone { get; set; } = new Dictionary<string, int>();
    }

    public sealed class GuildContractBoard
    {
        readonly ContractFile _file;
        readonly GuildStanding _standing;
        readonly Dictionary<string, int> _lastDone = new Dictionary<string, int>();

        public GuildContractBoard(ContractFile file, GuildStanding standing)
        {
            _file = file ?? new ContractFile();
            _standing = standing ?? throw new ArgumentNullException(nameof(standing));
        }

        public ContractTemplate Template(string id) => _file.Templates.FirstOrDefault(t => t.Id == id);

        static bool Rank(string letter, out RankLetter r) => Enum.TryParse(letter, false, out r) && Enum.IsDefined(typeof(RankLetter), r);

        /// <summary>Copper paid for a template at the player's adventurer rank: the rank is clamped into the template's range, then banded.</summary>
        public int Reward(ContractTemplate t, RankLetter playerRank)
        {
            if (!Rank(t.MinRank, out var lo) || !Rank(t.MaxRank, out var hi)) return 0;
            var eff = playerRank < lo ? lo : playerRank > hi ? hi : playerRank;
            if (!_file.CopperByRank.TryGetValue(eff.ToString(), out var copper)) return 0;
            double band = _file.RewardBands.TryGetValue(t.RewardBand ?? "mid", out var b) ? b : 1.0;
            return (int)Math.Round(copper * band, MidpointRounding.AwayFromZero);
        }

        /// <summary>Why a contract cannot be taken now, or null when it can.</summary>
        public string WhyNot(ContractTemplate t, RankLetter playerRank, int day)
        {
            if (t == null) return "unknown contract";
            if (!Rank(t.MinRank, out var lo)) return "bad rank data";
            if (playerRank < lo) return $"needs adventurer rank {t.MinRank}";
            if (!_standing.IsMember(t.GuildId)) return "join the guild first";
            if (_standing.Tier(t.GuildId) < t.MinTier) return $"needs guild tier {t.MinTier}";
            if (_standing.Level(t.GuildId) < GuildStandingLevel.Neutral) return "the guild distrusts you";
            if (_lastDone.TryGetValue(t.Id, out var last) && day < last + t.CooldownDays) return $"available again on day {last + t.CooldownDays}";
            return null;
        }

        public IEnumerable<ContractTemplate> Available(string guildId, RankLetter playerRank, int day) =>
            _file.Templates.Where(t => t.GuildId == guildId && WhyNot(t, playerRank, day) == null);

        /// <summary>Hands a contract in: pays copper, counts it for the guild and gives its reputation. Returns the copper, or -1 when not allowed.</summary>
        public int Complete(string templateId, RankLetter playerRank, int day)
        {
            var t = Template(templateId);
            if (WhyNot(t, playerRank, day) != null) return -1;
            _lastDone[t.Id] = day;
            _standing.ContractDone(t.GuildId, day);
            return Reward(t, playerRank);
        }

        public ContractsSave Save() => new ContractsSave { LastDone = new Dictionary<string, int>(_lastDone) };

        public void Load(ContractsSave s)
        {
            _lastDone.Clear();
            foreach (var kv in s?.LastDone ?? new Dictionary<string, int>())
                if (Template(kv.Key) != null) _lastDone[kv.Key] = kv.Value;
        }
    }

    public sealed class BountyClaimant
    {
        public string Id { get; set; }
        /// <summary>Share of the work, 0 to 1 (for example damage dealt or capture effort). Shares need not add to 1.</summary>
        public double Share { get; set; }
    }

    public sealed class BountyResult
    {
        public bool Valid { get; set; }
        public string Reason { get; set; }
        /// <summary>Claimant id to copper, summing to the reward. Only claimants at or above the minimum share are paid.</summary>
        public Dictionary<string, int> Payouts { get; set; } = new Dictionary<string, int>();
        /// <summary>Claimants who earn guild reputation.</summary>
        public List<string> Reputation { get; set; } = new List<string>();
    }

    public static class BountyResolver
    {
        /// <summary>
        /// Resolves a bounty claim: the proof must be one the objective accepts; the reward (held in escrow) is split by contribution among
        /// claimants at or above the minimum share, with the remainder going to the largest contributor.
        /// </summary>
        public static BountyResult Resolve(BountyRules rules, string objective, string proof, int reward, IList<BountyClaimant> claimants)
        {
            var result = new BountyResult();
            if (rules == null || !rules.ProofsAccepted.TryGetValue(objective ?? "", out var accepted))
            { result.Reason = "unknown objective"; return result; }
            if (!accepted.Contains(proof ?? "")) { result.Reason = $"that proof does not satisfy a {objective} bounty"; return result; }
            var counted = (claimants ?? new List<BountyClaimant>()).Where(c => c.Share >= rules.Claim.MinContributionShare).OrderByDescending(c => c.Share).ThenBy(c => c.Id, StringComparer.Ordinal).ToList();
            if (counted.Count == 0) { result.Reason = "no claimant did enough of the work"; return result; }
            double total = counted.Sum(c => c.Share);
            if (total <= 0 || reward < 0) { result.Reason = "nothing to split"; return result; }
            int paid = 0;
            foreach (var c in counted)
            {
                int part = (int)Math.Floor(reward * (c.Share / total));
                result.Payouts[c.Id] = part;
                paid += part;
            }
            result.Payouts[counted[0].Id] += Math.Max(0, reward) - paid;
            if (rules.Claim.ReputationToQualifyingClaimants) result.Reputation.AddRange(counted.Select(c => c.Id));
            result.Valid = true;
            result.Reason = "ok";
            return result;
        }
    }
}
