using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The player's map in play (Core MapKnowledge; hud_and_ui.md §8, 12_Systems/world_map.md): the local area inks
    /// itself in a circle around you as you walk, accepting a quest pencils its region onto the world map, and each
    /// guild rank's map seal names the next ring of lands (and, from Rank E, opens the System overlay). Tab / M or
    /// the gamepad's View button opens the map. Starts painting the world map on a worker thread as the game loads.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat))]
    public sealed class PlayerMap : MonoBehaviour
    {
        PlayerInventory _inv;
        PlayerQuests _quests;
        Vector3 _lastReveal = new Vector3(float.MaxValue, 0, 0);
        bool _drawTried;

        LocalMapArea _area;
        AreaFog _fog;

        public MapKnowledge Knowledge { get; private set; }
        /// <summary>The scene's local area (found or defaulted on first use).</summary>
        public LocalMapArea Area { get { EnsureArea(); return _area; } }
        /// <summary>The explored cells of <see cref="Area"/>.</summary>
        public AreaFog Fog { get { EnsureArea(); return _fog; } }
        /// <summary>Goes up whenever the map changes (the window recomposes its textures when it does).</summary>
        public int Version { get; private set; }

        void Awake()
        {
            _inv = GetComponent<PlayerInventory>();
            _quests = GetComponent<PlayerQuests>();
            Knowledge = new MapKnowledge(AscendData.Db.World.Map, AscendData.Db.Regions.Values);
            if (_quests != null) { _quests.Accepted += OnAccepted; _quests.RankedUp += OnRankedUp; }
        }

        void OnDestroy()
        {
            if (_quests != null) { _quests.Accepted -= OnAccepted; _quests.RankedUp -= OnRankedUp; }
        }

        void Start()
        {
            if (Knowledge.Visit(Area.RegionId)) Version++;
            RevealHere();
            WorldMapArt.Begin();
        }

        void EnsureArea()
        {
            if (_area != null) return;
            _area = LocalMapArea.Current;
            _fog = Knowledge.Area(_area.AreaId, _area.MinX, _area.MinZ, _area.Size);
        }

        void Update()
        {
            // Draw the area once the scene has settled (the minimap and the map's Area page use the drawing).
            if (!_drawTried && Time.frameCount > 3 && !AreaMapArt.HasDrawing(Area.AreaId))
            {
                _drawTried = true;
                try { AreaMapArt.Capture(Area); }
                catch (System.Exception e) { Debug.LogWarning($"Area map capture failed: {e.Message}"); }
            }
            Vector3 d = transform.position - _lastReveal; d.y = 0;
            if (d.sqrMagnitude > 1.5f * 1.5f) RevealHere();
        }

        /// <summary>Inks the local map around where you stand; returns how many cells were new.</summary>
        public int RevealHere()
        {
            _lastReveal = transform.position;
            int added = Fog.Reveal(transform.position.x, transform.position.z, Knowledge.Tuning.AreaRevealMetres);
            if (added > 0) Version++;
            return added;
        }

        /// <summary>Pencils a region onto the world map, with a toast saying how you heard of it.</summary>
        public bool Hear(string regionId, string how)
        {
            if (!Knowledge.Hear(regionId)) return false;
            Version++;
            Toast($"Map: {RegionName(regionId)} pencilled in ({how})");
            return true;
        }

        void OnAccepted(QuestData q) => Hear(q.Region, "from a quest");

        void OnRankedUp(PromotionData p)
        {
            if (_quests == null) return;
            var rank = _quests.Rank.Rank;
            var news = Knowledge.OnGuildRank(rank);
            if (news.Count > 0)
            {
                Version++;
                Toast($"The guild's map seal adds {news.Count} lands: {string.Join(", ", news.Take(4).Select(RegionName))}{(news.Count > 4 ? "…" : "")}", 6f);
            }
            if (Knowledge.HasSystemOverlay(rank) && !Knowledge.HasSystemOverlay(rank - 1)) Toast("Map: the System overlay is open (O on the map)", 6f);
        }

        /// <summary>Whether the System overlay is open at your guild rank.</summary>
        public bool HasSystemOverlay => Knowledge.HasSystemOverlay(_quests != null ? _quests.Rank.Rank : RankLetter.F);

        public MapSave Save() => Knowledge.Save();

        public void Load(MapSave save)
        {
            Knowledge.Load(save, id => id == Area.AreaId ? Fog : null);
            Knowledge.Visit(Area.RegionId);
            Version++;
        }

        public static string RegionName(string id) => id != null && AscendData.Db.Regions.TryGetValue(id, out var r) ? r.Name : id;

        void Toast(string text, float seconds = 4f) { if (_inv != null) _inv.Toast(text, seconds); }
    }
}
