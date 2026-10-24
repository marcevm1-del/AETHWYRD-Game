using System;
using System.IO;
using System.Linq;
using Ascend.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Saves and loads the player's slot (Core SaveGame) as JSON in the save folder. Loads once on Start; autosaves
    /// whenever a waystone is attuned and after each respawn (systems.md §10). A save that fails validation is never
    /// loaded over the current game: it is kept beside the slot as <c>.bad</c> so nothing is lost.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat), typeof(PlayerInventory), typeof(PlayerRespawn))]
    public sealed class PlayerSave : MonoBehaviour
    {
        [SerializeField] string slot = "slot0";
        [SerializeField] bool loadOnStart = true;

        /// <summary>Where saves live; tests point this at a temporary folder.</summary>
        public static string Folder { get; set; }

        static readonly JsonSerializerSettings Json = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = { new StringEnumConverter() },
            Culture = System.Globalization.CultureInfo.InvariantCulture,
        };

        PlayerCombat _combat;
        PlayerInventory _inv;
        PlayerRespawn _respawn;

        public string Slot { get => slot; set => slot = value; }
        public string PathOnDisk => Path.Combine(Folder ?? Application.persistentDataPath, slot + ".json");
        public string LastError { get; private set; }
        public int Saves { get; private set; }

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _inv = GetComponent<PlayerInventory>();
            _respawn = GetComponent<PlayerRespawn>();
            _respawn.Respawned += OnRespawned;
            _respawn.PointSet += OnPointSet;
        }

        void OnDestroy()
        {
            if (_respawn == null) return;
            _respawn.Respawned -= OnRespawned;
            _respawn.PointSet -= OnPointSet;
        }

        void Start() { if (loadOnStart) Load(); }

        void OnRespawned() => Save();
        void OnPointSet() => Save();

        public void Save()
        {
            var s = SaveRules.Capture(_combat.Progress, _inv.Items, _inv.Difficulty, DateTime.UtcNow);
            s.Deaths = _respawn.Deaths;
            s.WaystoneId = _respawn.WaystoneId;
            Vector3 p = _respawn.Point;
            s.Respawn = new[] { p.x, p.y, p.z, _respawn.Facing.eulerAngles.y };
            if (_respawn.Lantern != null)
            {
                Vector3 l = _respawn.Lantern.transform.position;
                s.Lantern = new[] { l.x, l.y, l.z };
                s.LanternCopper = _respawn.Lantern.Copper;
            }
            s.FireBombs = _combat.FireBombs;
            s.Equipment = _combat.Equipment.Slots.ToDictionary(kv => kv.Key, kv => kv.Value);
            if (WorldClock.Instance != null) s.ClockSeconds = WorldClock.Instance.PlaySeconds;
            if (TryGetComponent<PlayerBestiary>(out var book)) s.Bestiary = book.Book.Save();
            if (TryGetComponent<PlayerMap>(out var map)) s.Map = map.Save();
            var withMe = FindObjectsByType<CompanionAI>(FindObjectsSortMode.None).FirstOrDefault(c => c.Joined);
            s.Companion = withMe != null ? withMe.GetComponent<QuestGiver>().NpcId : null;
            s.GatherNodes = GatherNode.All.Where(n => n != null && !n.Ready).ToDictionary(n => n.Key, n => n.ReadyAtHour);
            if (TryGetComponent<PlayerCrafting>(out var crafting)) { s.KnownRecipes = crafting.Crafter.Known.ToList(); s.HandledItems = crafting.Crafter.SeenItems.ToList(); }
            if (TryGetComponent<PlayerTaming>(out var taming))
                s.Partners = taming.Roster.All.Select(p => new PartnerData { SpeciesId = p.SpeciesId, Name = p.Name, Active = p.Active, Bond = p.Bond, Assists = p.Assists, Evolved = p.Evolved }).ToList();
            var siege = SiegeDirector.Instance;
            if (siege != null)
                s.Sieges = new System.Collections.Generic.Dictionary<string, SiegeSave>
                {
                    [siege.Threat.RegionId] = new SiegeSave { State = siege.Threat.State, Escalation = siege.Threat.Escalation, DoneDays = siege.DoneDays.ToList(), LastWeek = siege.LastWeek },
                };
            if (TryGetComponent<PlayerRest>(out var rest))
            {
                s.RestBuffs = rest.Buffs.Select(b => new RestBuff { Kind = b.Kind, Hours = b.Hours, XpBonus = b.XpBonus }).ToList();
                s.TabCopper = rest.Tab.BalanceCopper; s.TabPaidOnce = rest.Tab.PaidOffOnce;
                s.InnNights = rest.Nights.ToDictionary(kv => kv.Key, kv => kv.Value);
            }
            if (TryGetComponent<PlayerQuests>(out var quests))
            {
                s.Quests = quests.Log.SaveActive();
                s.CompletedQuests = quests.Log.Completed.ToList();
                s.Flags = quests.Flags.ToList();
                s.GuildPoints = quests.Log.GuildPoints;
                s.BoardDone = quests.BoardDone.ToDictionary(kv => kv.Key, kv => kv.Value);
                s.GuildRank = quests.Rank.Rank; s.RankGp = quests.Rank.Gp; s.QuestsAtRank = quests.Rank.QuestsAtRank;
            }
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(PathOnDisk));
                string tmp = PathOnDisk + ".tmp";
                File.WriteAllText(tmp, JsonConvert.SerializeObject(s, Json));
                if (File.Exists(PathOnDisk)) File.Delete(PathOnDisk);
                File.Move(tmp, PathOnDisk); // write-then-move: a crash mid-save never leaves half a file
                Saves++;
                _inv.Toast("Saved");
            }
            catch (Exception e) { LastError = e.Message; Debug.LogWarning($"Save failed: {e.Message}"); }
        }

        /// <summary>Loads the slot if it exists; returns whether a save was applied.</summary>
        public bool Load()
        {
            if (!File.Exists(PathOnDisk)) return false;
            SaveGame s;
            try { s = SaveRules.Upgrade(JsonConvert.DeserializeObject<SaveGame>(File.ReadAllText(PathOnDisk), Json)); }
            catch (Exception e) { return Reject("unreadable: " + e.Message); }
            var errors = SaveRules.Validate(s);
            if (errors.Count > 0) return Reject(string.Join("; ", errors));

            SaveRules.Apply(s, _combat.Progress, _inv.Items);
            _combat.SetLevel(_combat.Progress.Level); // stats, skills and max HP follow the loaded level
            var defense = GetComponent<PlayerDefense>();
            if (defense != null) defense.Revive();     // a loaded game starts at full health
            _inv.Difficulty = s.Difficulty;
            if (s.Equipment != null) _combat.Equipment.Load(s.Equipment);
            if (s.ClockSeconds.HasValue && WorldClock.Instance != null) WorldClock.Instance.PlaySeconds = s.ClockSeconds.Value;
            if (s.Sieges != null && SiegeDirector.Instance != null && s.Sieges.TryGetValue(SiegeDirector.Instance.Threat.RegionId, out var sg))
                SiegeDirector.Instance.Load(sg.State, sg.Escalation, sg.DoneDays, sg.LastWeek);
            if (TryGetComponent<PlayerBestiary>(out var book)) book.Load(s.Bestiary);
            if (TryGetComponent<PlayerMap>(out var map)) map.Load(s.Map);
            foreach (var c in FindObjectsByType<CompanionAI>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                bool mine = s.Companion != null && c.GetComponent<QuestGiver>().NpcId == s.Companion;
                if (mine && !c.Joined) c.Join(_combat);
                else if (!mine && c.Joined) c.Leave();
            }
            foreach (var n in GatherNode.All) if (n != null) n.ReadyAtHour = s.GatherNodes.TryGetValue(n.Key, out var h) ? h : double.MinValue;
            if (TryGetComponent<PlayerCrafting>(out var crafting)) crafting.Load(s.KnownRecipes, s.HandledItems);
            if (TryGetComponent<PlayerTaming>(out var taming)) taming.Load(s.Partners);
            if (TryGetComponent<PlayerRest>(out var rest)) rest.Load(s.RestBuffs, s.TabCopper, s.TabPaidOnce, s.InnNights);
            if (TryGetComponent<PlayerQuests>(out var quests)) { quests.Load(s.Quests, s.CompletedQuests, s.GuildPoints, s.Flags); quests.LoadBoard(s.BoardDone); quests.Rank.Load(s.GuildRank, s.RankGp, s.QuestsAtRank); }
            _combat.GiveFireBombs(s.FireBombs - _combat.FireBombs);
            _respawn.Restore(s.Deaths, s.WaystoneId,
                s.Respawn != null ? new Vector3(s.Respawn[0], s.Respawn[1], s.Respawn[2]) : (Vector3?)null,
                s.Respawn != null ? s.Respawn[3] : 0f,
                s.Lantern != null ? new Vector3(s.Lantern[0], s.Lantern[1], s.Lantern[2]) : (Vector3?)null, s.LanternCopper);
            return true;
        }

        bool Reject(string why)
        {
            LastError = why;
            Debug.LogWarning($"Save {PathOnDisk} not loaded ({why}); kept as .bad");
            try { File.Copy(PathOnDisk, PathOnDisk + ".bad", true); } catch (Exception) { }
            return false;
        }
    }
}
