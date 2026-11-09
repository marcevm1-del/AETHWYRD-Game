using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Guild membership and per-guild reputation (Canon section 6 proposal M3; bible section 8). Data: Data/World/guilds.json.
    // The Adventurers' Guild keeps its own F to SSS ladder (GuildRank); the other 29 guilds use the 8-step member ladder here.
    // Rules that always hold: reputation is tracked per guild; a player may belong to many guilds and be loved by one and distrusted
    // by another; the player never holds the top tier or owns a guild (Canon section 4); each reputation event has a daily cap so
    // nothing can be farmed; discounts are bounded (Canon section 6, item economy guardrails). Hidden guilds need a story flag.

    public sealed class GuildTierData
    {
        public string Id { get; set; }
        public int Tier { get; set; }
        public string Name { get; set; }
        public int ReputationToReach { get; set; }
        public int ContractsToReach { get; set; }
        /// <summary>none, test, appointment or story.</summary>
        public string Gate { get; set; } = "none";
        public bool PlayerCanHold { get; set; }
        public int DiscountPercent { get; set; }
    }

    public sealed class GuildReputationEvent
    {
        public string Id { get; set; }
        public string Kind { get; set; }
        public int Delta { get; set; }
        public int DailyCap { get; set; }
    }

    public sealed class GuildStandingsData
    {
        public int DistrustedBelow { get; set; } = -50;
        public int BannedBelow { get; set; } = -150;
    }

    public sealed class GuildRivalry
    {
        public string A { get; set; }
        public string B { get; set; }
        public string Text { get; set; }
    }

    public sealed class GuildData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>public, restricted or hidden.</summary>
        public string Access { get; set; } = "public";
        public bool UsesMemberLadder { get; set; } = true;
        /// <summary>The Adventurers' Guild rank needed to be admitted ("C" for restricted guilds), or null.</summary>
        public string RequiresAdventurerRank { get; set; }
        /// <summary>A story flag that must be set before a hidden guild can be found or joined.</summary>
        public string UnlockFlag { get; set; }
        public bool ImpliedContractsOnly { get; set; }
    }

    public sealed class GuildFile
    {
        public string Notes { get; set; }
        public int PlayerMaxTier { get; set; } = 7;
        public int MaxDiscountPercent { get; set; } = 12;
        public GuildStandingsData Standings { get; set; } = new GuildStandingsData();
        public List<GuildTierData> MemberLadder { get; set; } = new List<GuildTierData>();
        public List<GuildReputationEvent> ReputationEvents { get; set; } = new List<GuildReputationEvent>();
        public List<GuildRivalry> Rivalries { get; set; } = new List<GuildRivalry>();
        public List<GuildData> Guilds { get; set; } = new List<GuildData>();
    }

    public enum GuildStandingLevel { Banned, Distrusted, Neutral, Respected }

    public sealed class GuildDayCapSave
    {
        public int Day { get; set; } = -1;
        public int Applied { get; set; }
    }

    public sealed class GuildMemberSave
    {
        public int Reputation { get; set; }
        /// <summary>0 = not a member.</summary>
        public int Tier { get; set; }
        public int Contracts { get; set; }
        public Dictionary<string, GuildDayCapSave> DayCaps { get; set; } = new Dictionary<string, GuildDayCapSave>();
    }

    public sealed class GuildsSave
    {
        public Dictionary<string, GuildMemberSave> Guilds { get; set; } = new Dictionary<string, GuildMemberSave>();
    }

    public sealed class GuildStanding
    {
        readonly GuildFile _file;
        readonly Dictionary<string, GuildData> _byId;
        readonly Dictionary<string, GuildMemberSave> _state = new Dictionary<string, GuildMemberSave>();

        public GuildStanding(GuildFile file)
        {
            _file = file ?? new GuildFile();
            _byId = _file.Guilds.ToDictionary(g => g.Id);
        }

        public event Action Changed;
        public GuildFile Data => _file;
        public IReadOnlyList<GuildData> Guilds => _file.Guilds;
        public GuildData Guild(string id) => id != null && _byId.TryGetValue(id, out var g) ? g : null;

        GuildMemberSave St(string id)
        {
            if (!_state.TryGetValue(id, out var s)) _state[id] = s = new GuildMemberSave();
            return s;
        }

        public int Reputation(string id) => id != null && _state.TryGetValue(id, out var s) ? s.Reputation : 0;
        public int Tier(string id) => id != null && _state.TryGetValue(id, out var s) ? s.Tier : 0;
        public int Contracts(string id) => id != null && _state.TryGetValue(id, out var s) ? s.Contracts : 0;
        public bool IsMember(string id) => Tier(id) > 0;
        public IEnumerable<string> Memberships => _state.Where(kv => kv.Value.Tier > 0).Select(kv => kv.Key).OrderBy(x => x, StringComparer.Ordinal);
        public string TierName(string id) => TierData(Tier(id))?.Name;
        GuildTierData TierData(int tier) => _file.MemberLadder.FirstOrDefault(t => t.Tier == tier);

        public GuildStandingLevel Level(string id)
        {
            int rep = Reputation(id);
            if (rep < _file.Standings.BannedBelow) return GuildStandingLevel.Banned;
            if (rep < _file.Standings.DistrustedBelow) return GuildStandingLevel.Distrusted;
            return rep >= TierData(2)?.ReputationToReach ? GuildStandingLevel.Respected : GuildStandingLevel.Neutral;
        }

        /// <summary>Is this guild visible and open to the player? Hidden guilds need their flag; restricted ones an Adventurers' rank.</summary>
        public bool IsOpen(string id, RankLetter adventurerRank, Func<string, bool> hasFlag)
        {
            var g = Guild(id);
            if (g == null || !g.UsesMemberLadder) return false;
            if (!string.IsNullOrEmpty(g.UnlockFlag) && !(hasFlag?.Invoke(g.UnlockFlag) ?? false)) return false;
            if (!string.IsNullOrEmpty(g.RequiresAdventurerRank) && Enum.TryParse(g.RequiresAdventurerRank, false, out RankLetter need) && Enum.IsDefined(typeof(RankLetter), need) && adventurerRank < need) return false;
            return true;
        }

        /// <summary>Registers as an Applicant. Refused when the guild is closed, the player is banned there or already a member.</summary>
        public bool Join(string id, RankLetter adventurerRank, Func<string, bool> hasFlag)
        {
            if (!IsOpen(id, adventurerRank, hasFlag) || IsMember(id) || Level(id) == GuildStandingLevel.Banned) return false;
            var s = St(id);
            s.Tier = 1;
            Changed?.Invoke();
            return true;
        }

        /// <summary>
        /// Applies a reputation event for <paramref name="units"/> (1 for most; donations count per 100 copper). The change is limited by the
        /// event's daily cap for this guild. Returns the reputation actually changed. Falling below the ban line revokes membership.
        /// </summary>
        public int Apply(string guildId, string eventId, int day, int units = 1)
        {
            var g = Guild(guildId);
            var ev = _file.ReputationEvents.FirstOrDefault(e => e.Id == eventId);
            if (g == null || ev == null || units < 1) return 0;
            var s = St(guildId);
            string key = eventId;
            if (!s.DayCaps.TryGetValue(key, out var cap)) s.DayCaps[key] = cap = new GuildDayCapSave();
            if (cap.Day != day) { cap.Day = day; cap.Applied = 0; }
            int want = (int)Math.Min(int.MaxValue / 2, Math.Abs((long)ev.Delta) * (long)units);
            int room = Math.Max(0, ev.DailyCap - cap.Applied);
            int take = Math.Min(want, room);
            if (take <= 0) return 0;
            cap.Applied += take;
            int change = ev.Delta < 0 ? -take : take;
            s.Reputation += change;
            if (s.Tier > 0 && s.Reputation < _file.Standings.BannedBelow) { s.Tier = 0; s.Contracts = 0; }
            Changed?.Invoke();
            return change;
        }

        /// <summary>A guild contract handed in: one more contract and the contract_completed reputation event.</summary>
        public int ContractDone(string guildId, int day)
        {
            if (Guild(guildId) == null) return 0;
            St(guildId).Contracts++;
            int change = Apply(guildId, "contract_completed", day);
            Changed?.Invoke();
            return change;
        }

        /// <summary>The reason the next tier cannot be taken yet, or null when it can.</summary>
        public string WhyNotPromote(string id, bool passedTest, bool appointed)
        {
            var g = Guild(id);
            if (g == null || !g.UsesMemberLadder) return "not a member guild";
            int tier = Tier(id);
            if (tier == 0) return "not a member";
            if (Level(id) != GuildStandingLevel.Neutral && Level(id) != GuildStandingLevel.Respected) return "standing too low";
            var next = TierData(tier + 1);
            if (next == null || tier + 1 > _file.PlayerMaxTier || !next.PlayerCanHold) return "the top of the ladder is story-only";
            if (Reputation(id) < next.ReputationToReach) return $"needs {next.ReputationToReach} reputation";
            if (Contracts(id) < next.ContractsToReach) return $"needs {next.ContractsToReach} contracts";
            if (next.Gate == "test" && !passedTest) return "needs a mastery test";
            if (next.Gate == "appointment" && !appointed) return "needs the guild's vote or appointment";
            if (next.Gate == "story") return "story-only";
            return null;
        }

        public bool Promote(string id, bool passedTest, bool appointed)
        {
            if (WhyNotPromote(id, passedTest, appointed) != null) return false;
            St(id).Tier++;
            Changed?.Invoke();
            return true;
        }

        /// <summary>Guild discount, bounded by the data cap; none while distrusted or banned.</summary>
        public int DiscountPercent(string id)
        {
            if (Level(id) < GuildStandingLevel.Neutral) return 0;
            var t = TierData(Tier(id));
            return t == null ? 0 : Math.Min(t.DiscountPercent, _file.MaxDiscountPercent);
        }

        public IEnumerable<string> Rivals(string id) =>
            _file.Rivalries.Where(r => r.A == id || r.B == id).Select(r => r.A == id ? r.B : r.A);

        // --- saves ---
        public GuildsSave Save()
        {
            var save = new GuildsSave();
            foreach (var kv in _state.OrderBy(k => k.Key, StringComparer.Ordinal))
                save.Guilds[kv.Key] = new GuildMemberSave
                {
                    Reputation = kv.Value.Reputation, Tier = kv.Value.Tier, Contracts = kv.Value.Contracts,
                    DayCaps = kv.Value.DayCaps.ToDictionary(c => c.Key, c => new GuildDayCapSave { Day = c.Value.Day, Applied = c.Value.Applied })
                };
            return save;
        }

        /// <summary>Restores a save. Null (an older save) changes nothing; guilds the data no longer has are ignored; tiers are clamped to what the player can hold.</summary>
        public void Load(GuildsSave s)
        {
            _state.Clear();
            if (s?.Guilds != null)
                foreach (var kv in s.Guilds)
                {
                    if (!_byId.ContainsKey(kv.Key) || kv.Value == null) continue;
                    var m = kv.Value;
                    _state[kv.Key] = new GuildMemberSave
                    {
                        Reputation = m.Reputation, Contracts = Math.Max(0, m.Contracts),
                        Tier = Math.Max(0, Math.Min(_file.PlayerMaxTier, m.Tier)),
                        DayCaps = (m.DayCaps ?? new Dictionary<string, GuildDayCapSave>()).ToDictionary(c => c.Key, c => c.Value ?? new GuildDayCapSave())
                    };
                }
            Changed?.Invoke();
        }
    }
}
