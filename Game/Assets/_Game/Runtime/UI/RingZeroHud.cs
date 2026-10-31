using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 HUD and Status Window (12_Systems/hud_and_ui.md), drawn with IMGUI as a functional placeholder until the
    /// styled UI Toolkit HUD: HP/SP/MP/Awakening, level and XP, the Style Rank (C → SSS) and its meter, skill slots
    /// with cooldowns, the Ultimate and Fire Bomb count, the lock-on target, level-up banners and reaction-free
    /// XP toasts. The Status Window (Tab / Esc / Start) lists rank, stats and skills, with the Lying Interface's
    /// one [REDACTED] line (Big Upgrade §1).
    /// </summary>
    public sealed class RingZeroHud : MonoBehaviour
    {
        [SerializeField] PlayerCombat player;

        PlayerDefense _defense;
        LockOn _lock;
        PlayerInventory _inv;
        PlayerRespawn _respawn;
        PlayerQuests _quests;
        PlayerRest _rest;
        InputAction _status;
        string _banner;
        float _bannerUntil, _toastUntil;
        long _toastXp;
        GUIStyle _big, _small, _box;

        public bool StatusOpen { get; set; }
        public string Banner => Time.unscaledTime < _bannerUntil ? _banner : null;

        public PlayerCombat Player { get => player; set { player = value; Bind(); } }

        void Awake()
        {
            _status = new InputAction("Status", InputActionType.Button);
            _status.AddBinding("<Keyboard>/tab"); _status.AddBinding("<Keyboard>/escape"); _status.AddBinding("<Gamepad>/start");
        }

        void OnEnable() => _status.Enable();
        void OnDisable() => _status.Disable();
        void OnDestroy() { _status.Dispose(); MonsterDummy.WorldLabels = true; FaceCamera.NpcNameLabels = true; }

        void Start()
        {
            MonsterDummy.WorldLabels = false; // the HUD draws nameplates instead
            FaceCamera.NpcNameLabels = false;  // for NPCs too, so no name is drawn twice
            if (player == null) player = FindFirstObjectByType<PlayerCombat>();
            Bind();
        }

        void Bind()
        {
            if (player == null) return;
            _defense = player.GetComponent<PlayerDefense>();
            _lock = player.GetComponent<LockOn>();
            _inv = player.GetComponent<PlayerInventory>();
            _respawn = player.GetComponent<PlayerRespawn>();
            _quests = player.GetComponent<PlayerQuests>();
            _rest = player.GetComponent<PlayerRest>();
            player.LeveledUp -= OnLevelUp; player.LeveledUp += OnLevelUp;
            player.XpGained -= OnXp; player.XpGained += OnXp;
        }

        void OnLevelUp(int from, int to)
        {
            _banner = $"LEVEL UP · {from} → {to}";
            _bannerUntil = Time.unscaledTime + 2.5f;
        }

        void OnXp(long xp)
        {
            _toastXp = Time.unscaledTime < _toastUntil ? _toastXp + xp : xp;
            _toastUntil = Time.unscaledTime + 1.5f;
        }

        void Update()
        {
            if (_status.WasPressedThisFrame() && !UiModal.Any) StatusOpen = !StatusOpen;
        }

        // ---------------------------------------------------------------- content (testable without drawing)
        /// <summary>The Status Window text, one line per row.</summary>
        public List<string> StatusLines()
        {
            var lines = new List<string>();
            if (player == null) return lines;
            var db = AscendData.Db;
            var cls = db.Classes.Values.First(c => c.Basic != null && player.Chain != null && c.Basic.Id == player.Chain.SkillId);
            var p = PlayerStats.Primary(cls, player.Level, db.Progression);
            var d = player.Stats;
            var quests = player.GetComponent<PlayerQuests>();
            if (quests != null)
            {
                lines.Add($"{cls.Name} · Lv {player.Level} · Rank {quests.Rank.Rank} ({quests.Rank.Title}, {quests.Rank.Card} card) · {quests.Rank.Gp} GP");
                var next = quests.Rank.Next;
                if (next != null) lines.Add($"To {next.To}: " + string.Join("  ", quests.RankRequirements().Select(r => (r.Met ? "✔ " : "✘ ") + r.Text)));
            }
            else lines.Add($"{cls.Name} · Lv {player.Level} · Guild Rank {player.Progress.RankBand}");
            lines.Add($"XP {player.Progress.XpIntoLevel} / {player.Progress.ToNext}");
            lines.Add($"STR {p.Str:0}  VIT {p.Vit:0}  AGI {p.Agi:0}  DEX {p.Dex:0}  INT {p.Int:0}  WIS {p.Wis:0}  LUK {p.Luk:0}  CHA {p.Cha:0}");
            lines.Add($"HP {d.Hp}  MP {d.Mp}  SP {d.Sp}  ATK {d.Atk}  MATK {d.Matk}  DEF {d.Def}  MDEF {d.Mdef}  SPD {d.Spd}  CRIT {d.CritChance:P0}");
            lines.Add($"Mechanic: {cls.Mechanic}");
            lines.Add("Skills: " + string.Join(", ", cls.SkillsAt(player.Level).Select(s => s.Name)));
            var passives = cls.PassivesAt(player.Level).Select(s => s.Name).ToList();
            if (passives.Count > 0) lines.Add("Passives: " + string.Join(", ", passives));
            lines.Add("Title: [REDACTED]");
            return lines;
        }

        public string StyleLabel()
        {
            if (player == null) return "C";
            var s = player.Style;
            return s.Rank.ToString();
        }

        /// <summary>Progress (0–1) from the current Style Rank toward the next one.</summary>
        public float StyleProgress()
        {
            if (player == null) return 0f;
            var s = player.Style;
            if (s.Rank == StyleRank.SSS) return 1f;
            float lo = s.ThresholdOf(s.Rank), hi = s.ThresholdOf(s.Rank + 1);
            return Mathf.Clamp01(((float)s.Points - lo) / Mathf.Max(1f, hi - lo));
        }

        // ---------------------------------------------------------------- drawing
        // Layout after the art-direction concepts (13_Production/art_direction_hud.md): vitals top-left with the level
        // badge, Style Rank and a round minimap top-right with the quest under it, a numbered skill bar bottom-centre
        // with the Combo Budget above it, party top-right below the quest, nameplates as a name over a slim red bar.
        void OnGUI()
        {
            if (player == null) return;
            EnsureStyles();
            var c = player.Caster;
            float sw = Screen.width, sh = Screen.height;

            Nameplates();

            // ---- Top-left: level badge + HP / MP / SP.
            float hp = _defense != null ? _defense.Hp : player.Stats.Hp, maxHp = _defense != null ? _defense.MaxHp : player.Stats.Hp;
            LevelBadge(new Rect(16, 14, 54, 54), player.Level.ToString());
            VitalBar(new Rect(78, 16, 260, 16), "HP", hp, maxHp, new Color(0.86f, 0.22f, 0.2f));
            VitalBar(new Rect(78, 35, 230, 13), "MP", (float)c.Mp, (float)c.MaxMp, new Color(0.25f, 0.55f, 0.95f));
            VitalBar(new Rect(78, 51, 200, 13), "SP", (float)c.Sp, (float)c.MaxSp, new Color(0.45f, 0.8f, 0.3f));
            Fill(new Rect(78, 67, 200, 3), player.Progress.XpIntoLevel / (float)Mathf.Max(1, player.Progress.ToNext), new Color(0.95f, 0.85f, 0.4f));
            float ly = 76;
            Shadowed(new Rect(18, ly, 400, 20), $"Rank {PlayerQuests.RankOf(player)}" + (_inv != null ? $"   ·   {_inv.MoneyText}" : ""), _small); ly += 20;
            if (WorldClock.Instance != null) { Shadowed(new Rect(18, ly, 400, 20), WorldClock.Instance.Text, _small); ly += 20; }
            var restText = _rest != null ? _rest.BuffText() : null;
            if (restText != null) { Shadowed(new Rect(18, ly, 400, 20), restText, _small); ly += 20; }

            // ---- Top-right: Style Rank badge + bar, round minimap, the tracked quest, then the party.
            Shadowed(new Rect(sw - 290, 18, 200, 22), "Style Rank", _bold, TextAnchor.MiddleRight);
            Fill(new Rect(sw - 290, 42, 200, 8), StyleProgress(), new Color(1f, 0.78f, 0.25f));
            RankBadge(new Rect(sw - 80, 10, 62, 62), StyleLabel());
            float mapSize = 150f;
            Radar(new Rect(sw - mapSize - 18, 80, mapSize, mapSize));
            float ry = 80 + mapSize + 8;
            if (player.TryGetComponent<PlayerMap>(out var map) && map.Area != null)
            {
                // Where you are, under the minimap, and how to open the full map.
                Shadowed(new Rect(sw - 330, ry, 312, 18), $"{PlayerMap.RegionName(map.Area.RegionId)} · Tab: map", _tiny, TextAnchor.MiddleRight);
                ry += 20;
            }
            if (_quests != null)
            {
                var tracked = TrackedObjective();
                if (tracked.title != null)
                {
                    Shadowed(new Rect(sw - 330, ry, 312, 22), $"◆ {tracked.title}", _quest, TextAnchor.MiddleRight); ry += 22;
                    Shadowed(new Rect(sw - 330, ry, 312, 20), tracked.objective, _small, TextAnchor.MiddleRight); ry += 20;
                    if (tracked.distance >= 0) { Shadowed(new Rect(sw - 330, ry, 312, 20), $"{tracked.distance:0} m", _small, TextAnchor.MiddleRight); ry += 20; }
                }
            }
            PartyPanel(sw - 228, ry + 8);

            // ---- Top-centre: boss, siege, lock-on.
            var boss = MonsterController.ActiveBoss;
            if (boss != null)
            {
                var body = boss.GetComponent<MonsterDummy>();
                string bossName = AscendData.Db.Species.TryGetValue(body.SpeciesId, out var bs) ? bs.Name : body.SpeciesId;
                Shadowed(new Rect(sw / 2 - 300, 14, 600, 22), $"{bossName} — {boss.Boss.Current.Name}", _bold, TextAnchor.MiddleCenter);
                Frame(new Rect(sw / 2 - 300, 38, 600, 12), body.MaxHp > 0 ? body.Hp / (float)body.MaxHp : 0f, new Color(0.85f, 0.2f, 0.2f));
            }
            var siege = SiegeDirector.Instance != null ? SiegeDirector.Instance.StatusText() : null;
            if (siege != null) Shadowed(new Rect(sw / 2 - 300, 56, 600, 20), siege, _small, TextAnchor.MiddleCenter);

            // ---- Bottom-centre: Combo Budget, the skill name, then the numbered skill bar (skills, bomb, Ultimate).
            float slot = 58, gap = 6, barW = 6 * slot + 5 * gap, bx = (sw - barW) / 2f, by = sh - slot - 26;
            var slots = c.Slots;
            string active = player.CurrentSkillName;
            if (!string.IsNullOrEmpty(active)) Shadowed(new Rect(bx, by - 46, barW, 20), active, _bold, TextAnchor.MiddleCenter);
            Shadowed(new Rect(bx, by - 24, 160, 16), "Combo Budget", _tiny);
            Frame(new Rect(bx + 96, by - 20, barW - 96, 8), player.Budget != null ? player.Budget.Fraction : 1f, new Color(1f, 0.78f, 0.25f));
            for (int i = 0; i < 4; i++)
            {
                bool has = i < slots.Count;
                float cd = has ? (float)c.CooldownLeft(slots[i].Id) : 0;
                SkillSlot(new Rect(bx + i * (slot + gap), by, slot, slot), (i + 1).ToString(), has ? slots[i].Name : "", cd);
            }
            SkillSlot(new Rect(bx + 4 * (slot + gap), by, slot, slot), "G", $"Bomb ×{player.FireBombs}", 0);
            bool ready = c.Ultimate != null && c.Awakening >= c.MaxAwakening;
            SkillSlot(new Rect(bx + 5 * (slot + gap), by, slot, slot), "R", c.Ultimate != null ? (ready ? "READY" : $"{c.Awakening:0}%") : "", 0, ready ? new Color(0.85f, 0.4f, 1f) : (Color?)null);

            // ---- Bottom-right: party order.
            var taming = player.GetComponent<PlayerTaming>();
            bool party = (taming != null && taming.Following.Count > 0) || FindObjectsByType<CompanionAI>(FindObjectsSortMode.None).Any(x => x.Joined);
            if (party) { GUI.Box(new Rect(sw - 196, sh - 64, 180, 44), "", _panel); Shadowed(new Rect(sw - 190, sh - 60, 170, 36), $"Party: {(taming != null ? taming.Order.ToString() : "Follow")}\n[Z / LB] change order", _small); }

            // ---- Right, mid: pickups.
            if (_inv != null) { float ty = sh * 0.52f; foreach (var t in _inv.Toasts) { Shadowed(new Rect(sw - 470, ty, 450, 20), t, _small, TextAnchor.MiddleRight); ty += 20; } }

            // ---- Centre: taming meters, interaction prompt, banners.
            var tameText = taming != null ? taming.StatusText() : null;
            if (tameText != null) Shadowed(new Rect(sw / 2 - 320, sh * 0.66f, 640, 22), tameText, _small, TextAnchor.MiddleCenter);
            if (_quests != null)
            {
                var near = UiModal.Any ? null : QuestGiver.Nearest(player.transform.position);
                var nodeNear = UiModal.Any ? null : GatherNode.Nearest(player.transform.position);
                string prompt = null;
                if (nodeNear != null && nodeNear.Data != null && (near == null || Vector3.Distance(nodeNear.transform.position, player.transform.position) < Vector3.Distance(near.transform.position, player.transform.position)))
                    prompt = nodeNear.Ready ? $"[E]  Gather: {nodeNear.Data.Name}" : $"{nodeNear.Data.Name} (regrowing)";
                else if (near != null) prompt = $"[E]  Talk to {near.DisplayName}";
                if (prompt != null) { GUI.Box(new Rect(sw / 2 - 160, sh * 0.6f, 320, 28), "", _panel); Shadowed(new Rect(sw / 2 - 160, sh * 0.6f + 4, 320, 20), prompt, _small, TextAnchor.MiddleCenter); }
            }
            if (Banner != null) Shadowed(new Rect(0, sh * 0.28f, sw, 60), Banner, _big, TextAnchor.MiddleCenter);
            if (Time.unscaledTime < _toastUntil) Shadowed(new Rect(sw / 2 - 80, sh * 0.28f + 60, 160, 24), $"+{_toastXp} XP", _bold, TextAnchor.MiddleCenter);

            // ---- Death screen
            if (_respawn != null && _respawn.IsDead)
            {
                var old = GUI.color; GUI.color = new Color(0, 0, 0, 0.55f); GUI.DrawTexture(new Rect(0, 0, sw, sh), Texture2D.whiteTexture); GUI.color = old;
                Shadowed(new Rect(0, sh * 0.32f, sw, 60), "YOU FELL", _big, TextAnchor.MiddleCenter);
                Shadowed(new Rect(sw / 2 - 320, sh * 0.32f + 70, 640, 24), $"Defeated by {_respawn.KilledBy} (Rank {_respawn.KillerRank})", _small, TextAnchor.MiddleCenter);
                Shadowed(new Rect(sw / 2 - 320, sh * 0.32f + 96, 640, 24), $"Tip: {_respawn.Tip}", _small, TextAnchor.MiddleCenter);
                var pen = _respawn.LastPenalty;
                string lost = pen.DroppedCopper > 0 ? $"Dropped {Money.Format(pen.DroppedCopper, AscendData.Db.World.Currency)} — recover it from the blue lantern." : "Nothing was lost.";
                if (pen.XpLost > 0) lost += $"  Lost {pen.XpLost} XP.";
                Shadowed(new Rect(sw / 2 - 320, sh * 0.32f + 122, 640, 24), lost, _small, TextAnchor.MiddleCenter);
            }

            // ---- Status Window
            if (StatusOpen)
            {
                var lines = StatusLines();
                GUI.Box(new Rect(sw / 2 - 380, 110, 760, 46 + lines.Count * 26), "", _panel);
                Shadowed(new Rect(sw / 2 - 360, 116, 720, 24), "STATUS", _bold);
                for (int i = 0; i < lines.Count; i++) Shadowed(new Rect(sw / 2 - 360, 144 + i * 26, 720, 24), lines[i], _small);
            }
        }

        // ---------------------------------------------------------------- styles and pieces
        GUIStyle _bold, _center, _tiny, _quest, _panel;
        static Texture2D _circle, _ring;
        Texture2D _minimap;
        float _minimapAt;

        void EnsureStyles()
        {
            if (_bold != null) return;
            _big = new GUIStyle(GUI.skin.label) { fontSize = 44, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter };
            _small = new GUIStyle(GUI.skin.label) { fontSize = 15 };
            _box = new GUIStyle(GUI.skin.box) { fontSize = 14, alignment = TextAnchor.UpperLeft, wordWrap = true };
            _bold = new GUIStyle(GUI.skin.label) { fontSize = 18, fontStyle = FontStyle.Bold };
            _center = new GUIStyle(GUI.skin.label) { fontSize = 15, alignment = TextAnchor.MiddleCenter };
            _tiny = new GUIStyle(GUI.skin.label) { fontSize = 12 };
            _quest = new GUIStyle(_bold) { normal = { textColor = new Color(1f, 0.85f, 0.4f) } };
            _panel = new GUIStyle(GUI.skin.box) { normal = { background = Solid(new Color(0.06f, 0.07f, 0.1f, 0.72f)) } };
            _circle ??= Disc(128, false);
            _ring ??= Disc(128, true);
        }

        static Texture2D Solid(Color c) { var t = new Texture2D(1, 1); t.SetPixel(0, 0, c); t.Apply(); return t; }

        /// <summary>A soft-edged disc (or ring) texture for badges and the round minimap.</summary>
        static Texture2D Disc(int size, bool ring)
        {
            var t = new Texture2D(size, size, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp };
            float r = size / 2f;
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                {
                    float d = Vector2.Distance(new Vector2(x + 0.5f, y + 0.5f), new Vector2(r, r));
                    float a = Mathf.Clamp01(r - d);                       // anti-aliased outer edge
                    if (ring) a *= Mathf.Clamp01(d - (r - size * 0.07f));  // hollow centre
                    t.SetPixel(x, y, new Color(1, 1, 1, a));
                }
            t.Apply();
            return t;
        }

        /// <summary>Text with a dark drop shadow so it reads over bright scenes.</summary>
        void Shadowed(Rect r, string text, GUIStyle style, TextAnchor anchor = TextAnchor.MiddleLeft)
        {
            var s = new GUIStyle(style) { alignment = anchor };
            var col = s.normal.textColor;
            s.normal.textColor = new Color(0, 0, 0, 0.85f);
            GUI.Label(new Rect(r.x + 1.5f, r.y + 1.5f, r.width, r.height), text, s);
            s.normal.textColor = col;
            GUI.Label(r, text, s);
        }

        /// <summary>A bar in a dark frame.</summary>
        static void Frame(Rect r, float t, Color color)
        {
            var old = GUI.color;
            GUI.color = new Color(0.05f, 0.05f, 0.07f, 0.85f); GUI.DrawTexture(new Rect(r.x - 2, r.y - 2, r.width + 4, r.height + 4), Texture2D.whiteTexture);
            GUI.color = new Color(0.18f, 0.18f, 0.22f, 0.9f); GUI.DrawTexture(r, Texture2D.whiteTexture);
            GUI.color = color; GUI.DrawTexture(new Rect(r.x, r.y, r.width * Mathf.Clamp01(t), r.height), Texture2D.whiteTexture);
            GUI.color = new Color(1, 1, 1, 0.18f); GUI.DrawTexture(new Rect(r.x, r.y, r.width * Mathf.Clamp01(t), Mathf.Max(1, r.height * 0.35f)), Texture2D.whiteTexture); // sheen
            GUI.color = old;
        }

        void VitalBar(Rect r, string label, float value, float max, Color color)
        {
            Frame(r, max > 0 ? value / max : 0, color);
            Shadowed(new Rect(r.x + 4, r.y - 2, 40, r.height + 4), label, _tiny);
            Shadowed(new Rect(r.x, r.y - 2, r.width - 4, r.height + 4), $"{value:0}/{max:0}", _tiny, TextAnchor.MiddleRight);
        }

        /// <summary>The level in a diamond (a square turned 45°), as in the concepts.</summary>
        void LevelBadge(Rect r, string text)
        {
            var m = GUI.matrix;
            GUIUtility.RotateAroundPivot(45f, r.center);
            var inner = new Rect(r.x + r.width * 0.15f, r.y + r.height * 0.15f, r.width * 0.7f, r.height * 0.7f);
            var old = GUI.color;
            GUI.color = new Color(0.82f, 0.68f, 0.4f); GUI.DrawTexture(new Rect(inner.x - 2, inner.y - 2, inner.width + 4, inner.height + 4), Texture2D.whiteTexture);
            GUI.color = new Color(0.1f, 0.1f, 0.13f, 0.95f); GUI.DrawTexture(inner, Texture2D.whiteTexture);
            GUI.color = old;
            GUI.matrix = m;
            Shadowed(r, text, _bold, TextAnchor.MiddleCenter);
        }

        /// <summary>The Style Rank letter in a gold-ringed disc.</summary>
        void RankBadge(Rect r, string letter)
        {
            var old = GUI.color;
            GUI.color = new Color(0.1f, 0.1f, 0.13f, 0.92f); GUI.DrawTexture(r, _circle);
            GUI.color = new Color(0.85f, 0.7f, 0.35f); GUI.DrawTexture(r, _ring);
            GUI.color = old;
            var s = new GUIStyle(_big) { fontSize = (int)(r.height * 0.55f), normal = { textColor = new Color(1f, 0.9f, 0.6f) } };
            Shadowed(r, letter, s, TextAnchor.MiddleCenter);
        }

        void SkillSlot(Rect r, string key, string name, float cooldown, Color? glow = null)
        {
            var old = GUI.color;
            GUI.color = glow ?? new Color(0.82f, 0.68f, 0.4f); GUI.DrawTexture(new Rect(r.x - 2, r.y - 2, r.width + 4, r.height + 4), Texture2D.whiteTexture);
            GUI.color = new Color(0.1f, 0.11f, 0.14f, 0.92f); GUI.DrawTexture(r, Texture2D.whiteTexture);
            if (cooldown > 0) { GUI.color = new Color(0, 0, 0, 0.55f); GUI.DrawTexture(r, Texture2D.whiteTexture); }
            GUI.color = old;
            var wrap = new GUIStyle(_tiny) { wordWrap = true, alignment = TextAnchor.MiddleCenter };
            GUI.Label(new Rect(r.x + 2, r.y + 2, r.width - 4, r.height - 4), cooldown > 0 ? $"{cooldown:0.0}s" : name, wrap);
            Shadowed(new Rect(r.x, r.yMax + 2, r.width, 18), key, _tiny, TextAnchor.MiddleCenter);
        }

        void MenuButton(Rect r, string text, System.Action act)
        {
            var style = new GUIStyle(GUI.skin.button) { fontSize = 11 };
            if (GUI.Button(r, text, style)) act();
        }

        /// <summary>Monster and NPC nameplates drawn on screen: the name over a slim red bar (once appraised, tier 2+).
        /// Only the nearest few within range, and never two on top of each other.</summary>
        void Nameplates()
        {
            var cam = Camera.main;
            if (cam == null) return;
            // Start with the HUD panels taken, so a nameplate never covers the vitals, the minimap and quest tracker,
            // or the skill bar (reports/baseline_2026-10-25.md, bug 4). Keep these in step with the layout in OnGUI.
            float sw = Screen.width, sh = Screen.height, barW = 6 * 58f + 5 * 6f;
            var placed = new List<Rect>
            {
                new Rect(0, 0, 440, 140),                         // top-left: level badge, HP/MP/SP, rank, clock
                new Rect(sw - 345, 0, 345, 420),                  // top-right: Style Rank, minimap, region, quest, party
                new Rect((sw - barW) / 2f - 10, sh - 130, barW + 20, 130), // bottom-centre: Combo Budget and skill bar
            };
            var me = player.transform.position;
            var monsters = FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)
                .Where(m => m != null && !m.IsDead).OrderBy(m => (m.transform.position - me).sqrMagnitude).Take(10);
            foreach (var m in monsters)
            {
                if (!OnScreen(cam, m.transform.position + Vector3.up * NameplateHeight(m), 22f, out var p)) continue;
                int tier = MonsterDummy.AppraisalTier != null && !m.IsPartner ? MonsterDummy.AppraisalTier(m.SpeciesId) : 3;
                AscendData.Db.Species.TryGetValue(m.SpeciesId, out var s);
                string name = tier <= 0 ? "???" : s != null ? s.Name : m.SpeciesId;
                var rect = new Rect(p.x - 70, p.y - 22, 140, 30);
                if (placed.Any(o => o.Overlaps(rect))) continue;
                placed.Add(rect);
                Shadowed(new Rect(p.x - 90, p.y - 22, 180, 18), name, _small, TextAnchor.MiddleCenter);
                if (tier >= 2 || m.IsPartner)
                    Frame(new Rect(p.x - 46, p.y - 2, 92, 5), m.MaxHp > 0 ? m.Hp / (float)m.MaxHp : 0, m.IsPartner ? new Color(0.45f, 0.85f, 0.3f) : new Color(0.86f, 0.22f, 0.2f));
            }
            foreach (var g in FindObjectsByType<QuestGiver>(FindObjectsSortMode.None))
            {
                if (g == null || g.GetComponent<QuestBoard>() != null) continue;
                if (!OnScreen(cam, g.transform.position + Vector3.up * 1.3f, 16f, out var p)) continue;
                string role = g.Role;
                var rect = new Rect(p.x - 90, p.y - 22, 180, string.IsNullOrEmpty(role) ? 20 : 34);
                if (placed.Any(o => o.Overlaps(rect))) continue;
                placed.Add(rect);
                var s = new GUIStyle(_small) { normal = { textColor = new Color(0.7f, 0.85f, 1f) } };
                Shadowed(new Rect(rect.x, rect.y, rect.width, 20), g.DisplayName, s, TextAnchor.MiddleCenter);
                if (!string.IsNullOrEmpty(role)) Shadowed(new Rect(rect.x, rect.y + 18, rect.width, 16), role, _tiny, TextAnchor.MiddleCenter);
            }
        }

        static float NameplateHeight(MonsterDummy m)
        {
            var col = m.GetComponent<Collider>();
            return col != null ? col.bounds.max.y - m.transform.position.y + 0.35f : 1.6f;
        }

        bool OnScreen(Camera cam, Vector3 world, float range, out Vector2 gui)
        {
            gui = default;
            if (Vector3.Distance(world, player.transform.position) > range) return false;
            Vector3 sp = cam.WorldToScreenPoint(world);
            if (sp.z <= 0) return false;
            gui = new Vector2(sp.x, Screen.height - sp.y);
            return gui.x > -50 && gui.x < Screen.width + 50 && gui.y > -20 && gui.y < Screen.height;
        }

        const float RadarRange = 40f;

        /// <summary>A round minimap: you at the centre facing up; monsters red, NPCs blue, partners pink, the quest target gold.</summary>
        void Radar(Rect r)
        {
            var old = GUI.color;
            var cam = Camera.main;
            float yaw = cam != null ? cam.transform.eulerAngles.y : player.transform.eulerAngles.y;
            // The ground around you from the area drawing (falls back to a plain disc until it exists).
            bool drawn = false;
            if (player.TryGetComponent<PlayerMap>(out var pm) && AreaMapArt.HasDrawing(pm.Area.AreaId))
            {
                if (Event.current.type == EventType.Repaint && (Time.unscaledTime >= _minimapAt || _minimap == null))
                {
                    _minimapAt = Time.unscaledTime + 1f / 15f;
                    AreaMapArt.Minimap(pm.Area, pm.Fog, player.transform.position, yaw, RadarRange, ref _minimap);
                }
                if (_minimap != null) { GUI.color = Color.white; GUI.DrawTexture(r, _minimap); drawn = true; }
            }
            if (!drawn) { GUI.color = new Color(0.12f, 0.2f, 0.12f, 0.8f); GUI.DrawTexture(r, _circle); }
            GUI.color = new Color(0.85f, 0.7f, 0.35f); GUI.DrawTexture(r, _ring);
            Vector2 centre = r.center;
            float radius = r.width / 2f - 8f;
            void Dot(Vector3 world, Color col, float size)
            {
                Vector3 d = world - player.transform.position; d.y = 0;
                if (d.magnitude > RadarRange) return; // inside the circle only
                Vector3 local = Quaternion.Euler(0, -yaw, 0) * d;
                var pos = centre + new Vector2(local.x, -local.z) * radius / RadarRange;
                GUI.color = col; GUI.DrawTexture(new Rect(pos.x - size / 2, pos.y - size / 2, size, size), _circle);
            }
            foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None))
                if (m != null && !m.IsDead) Dot(m.transform.position, m.IsPartner ? new Color(1f, 0.6f, 0.8f) : new Color(0.95f, 0.3f, 0.25f), 6);
            foreach (var g in FindObjectsByType<QuestGiver>(FindObjectsSortMode.None))
                if (g != null) Dot(g.transform.position, new Color(0.45f, 0.65f, 1f), 7);
            var tracked = TrackedObjective();
            if (tracked.at.HasValue)
            {
                // The quest target: on the map if close, else a gold pip on the rim pointing the way.
                Vector3 d = tracked.at.Value - player.transform.position; d.y = 0;
                Vector3 local = Quaternion.Euler(0, -yaw, 0) * (d.magnitude > RadarRange ? d.normalized * RadarRange : d);
                var pos = centre + new Vector2(local.x, -local.z) * radius / RadarRange;
                GUI.color = new Color(1f, 0.82f, 0.25f); GUI.DrawTexture(new Rect(pos.x - 6, pos.y - 6, 12, 12), _circle);
            }
            GUI.color = Color.white;
            Shadowed(new Rect(centre.x - 8, centre.y - 11, 16, 20), "▲", _tiny, TextAnchor.MiddleCenter);
            GUI.color = old;
        }

        /// <summary>The party: you, your companion, then partners, numbered, with HP.</summary>
        void PartyPanel(float x, float y)
        {
            int n = 1;
            void Row(string who, float hp, float max, string note)
            {
                GUI.Box(new Rect(x, y, 210, 36), "", _panel);
                Shadowed(new Rect(x + 8, y + 2, 170, 18), who + (string.IsNullOrEmpty(note) ? "" : $"  · {note}"), _tiny);
                Shadowed(new Rect(x + 188, y + 2, 16, 18), n.ToString(), _tiny);
                Frame(new Rect(x + 8, y + 23, 178, 5), max > 0 ? hp / max : 0, new Color(0.45f, 0.85f, 0.3f));
                y += 40; n++;
            }
            var comps = FindObjectsByType<CompanionAI>(FindObjectsSortMode.None).Where(cp => cp != null && cp.Joined).ToList();
            var taming = player.GetComponent<PlayerTaming>();
            bool anyone = comps.Count > 0 || (taming != null && taming.Following.Count > 0);
            if (!anyone) return; // solo: the vitals top-left are enough
            Row("You", _defense != null ? _defense.Hp : player.Stats.Hp, _defense != null ? _defense.MaxHp : player.Stats.Hp, null);
            foreach (var comp in comps) Row(comp.Name, comp.Hp, comp.MaxHp, comp.Downed ? "down" : comp.Order.ToString());
            if (taming != null)
                foreach (var f in taming.Following)
                    if (f != null && f.Data != null) Row(f.Data.Name, f.Body.Hp, f.Body.MaxHp, f.KnockedOut ? "resting" : $"{f.Role} · bond {f.Data.Bond}");
            if (taming != null && taming.Roster.Ranch.Any()) Shadowed(new Rect(x, y, 210, 18), $"Ranch: {taming.Roster.Ranch.Count()}", _tiny);
        }

        /// <summary>The first active quest's next objective and where it is (the tracker, the radar and the map).</summary>
        public (string title, string objective, float distance, Vector3? at) TrackedObjective()
        {
            if (_quests == null) return (null, null, -1, null);
            var p = _quests.Log.Active.FirstOrDefault();
            if (p == null) return (null, null, -1, null);
            var q = _quests.Log.Quest(p.QuestId);
            if (q == null) return (null, null, -1, null);
            Vector3 me = player.transform.position;
            Vector3? at = null; string what;
            if (p.Status == QuestStatus.ReadyToTurnIn)
            {
                bool board = q.Id.StartsWith("qst_wk_");
                var giver = FindObjectsByType<QuestGiver>(FindObjectsSortMode.None).FirstOrDefault(g => board ? g.GetComponent<QuestBoard>() != null : g.NpcId == q.Giver);
                at = giver != null ? giver.transform.position : (Vector3?)null;
                what = board ? "Hand in at the guild board" : $"Return to {(AscendData.Db.Npcs.TryGetValue(q.Giver, out var n) ? n.Name : "the giver")}";
            }
            else
            {
                int i = q.Objectives.FindIndex(o => p.Counts[q.Objectives.IndexOf(o)] < System.Math.Max(1, o.Count));
                var o = i >= 0 ? q.Objectives[i] : q.Objectives[0];
                what = _quests.TrackerLines().FirstOrDefault()?.Split(':').Skip(1).FirstOrDefault()?.Trim() ?? o.Kind;
                switch (o.Kind)
                {
                    case "kill": at = FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None).Where(m => m.SpeciesId == o.Target && !m.IsDead && !m.IsPartner).OrderBy(m => (m.transform.position - me).sqrMagnitude).Select(m => (Vector3?)m.transform.position).FirstOrDefault(); break;
                    case "reach": at = FindObjectsByType<QuestPlace>(FindObjectsSortMode.None).Where(pl => pl.PlaceId == o.Target).Select(pl => (Vector3?)pl.transform.position).FirstOrDefault(); break;
                    case "talk": case "escort": at = FindObjectsByType<QuestGiver>(FindObjectsSortMode.None).Where(g => g.NpcId == o.Target).Select(g => (Vector3?)g.transform.position).FirstOrDefault(); break;
                    case "defend": at = FindObjectsByType<DefenceSpot>(FindObjectsSortMode.None).Where(d => d.PlaceId == o.Target).Select(d => (Vector3?)d.transform.position).FirstOrDefault(); break;
                    case "collect":
                        at = o.From != null
                            ? FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None).Where(m => m.SpeciesId == o.From && !m.IsDead).OrderBy(m => (m.transform.position - me).sqrMagnitude).Select(m => (Vector3?)m.transform.position).FirstOrDefault()
                            : GatherNode.All.Where(g => g != null && g.Data != null && g.Data.Yields.Any(y => y.ItemId == o.Target)).OrderBy(g => (g.transform.position - me).sqrMagnitude).Select(g => (Vector3?)g.transform.position).FirstOrDefault();
                        break;
                }
            }
            float dist = at.HasValue ? Vector3.Distance(new Vector3(at.Value.x, 0, at.Value.z), new Vector3(me.x, 0, me.z)) : -1;
            return (q.Title, what, dist, at);
        }

        static void Fill(Rect r, float t, Color color)
        {
            var old = GUI.color;
            GUI.color = new Color(0, 0, 0, 0.5f); GUI.DrawTexture(r, Texture2D.whiteTexture);
            GUI.color = color; GUI.DrawTexture(new Rect(r.x, r.y, r.width * Mathf.Clamp01(t), r.height), Texture2D.whiteTexture);
            GUI.color = old;
        }
    }
}
