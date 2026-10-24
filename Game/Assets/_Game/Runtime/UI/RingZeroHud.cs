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
        void OnDestroy() => _status.Dispose();

        void Start()
        {
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
        void OnGUI()
        {
            if (player == null) return;
            _big ??= new GUIStyle(GUI.skin.label) { fontSize = 42, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter };
            _small ??= new GUIStyle(GUI.skin.label) { fontSize = 14 };
            _box ??= new GUIStyle(GUI.skin.box) { fontSize = 14, alignment = TextAnchor.UpperLeft, wordWrap = true };
            var c = player.Caster;

            // Vitals and level (top-left)
            float x = 20, y = 20, sw0 = Screen.width;
            GUI.Label(new Rect(x, y, 300, 20), $"Lv {player.Level} · Rank {PlayerQuests.RankOf(player)}", _small); y += 22;
            Bar(x, ref y, "HP", _defense != null ? _defense.Hp : player.Stats.Hp, _defense != null ? _defense.MaxHp : player.Stats.Hp, new Color(0.85f, 0.25f, 0.25f));
            Bar(x, ref y, "SP", (float)c.Sp, (float)c.MaxSp, new Color(0.95f, 0.75f, 0.2f));
            Bar(x, ref y, "MP", (float)c.Mp, (float)c.MaxMp, new Color(0.3f, 0.55f, 1f));
            Bar(x, ref y, "AWK", (float)c.Awakening, (float)c.MaxAwakening, new Color(0.85f, 0.4f, 1f));
            Bar(x, ref y, "XP", player.Progress.XpIntoLevel, Mathf.Max(1, player.Progress.ToNext), new Color(0.5f, 0.9f, 0.5f));
            if (_inv != null) { GUI.Label(new Rect(x, y, 320, 20), $"Purse: {_inv.MoneyText}", _small); y += 22; }
            var restText = _rest != null ? _rest.BuffText() : null;
            if (restText != null) { GUI.Label(new Rect(x, y, 360, 20), restText, _small); y += 22; }
            if (WorldClock.Instance != null) GUI.Label(new Rect(sw0 / 2 - 160, 44, 320, 20), WorldClock.Instance.Text, _small);
            var taming = player.GetComponent<PlayerTaming>();
            var tameText = taming != null ? taming.StatusText() : null;
            if (tameText != null) GUI.Label(new Rect(sw0 / 2 - 260, Screen.height * 0.68f, 520, 22), tameText, _small);
            if (taming != null && taming.Roster.All.Count > 0)
            {
                GUI.Label(new Rect(x, y, 520, 20), "Partners: " + string.Join(", ", taming.Following.Where(f => f != null && f.Data != null).Select(f => $"{f.Data.Name} ({f.Role}, bond {f.Data.Bond}, {f.Order}{(f.KnockedOut ? ", resting" : "")})")) + (taming.Roster.Ranch.Any() ? $" · ranch {taming.Roster.Ranch.Count()}" : ""), _small);
                y += 22;
            }
            var boss = MonsterController.ActiveBoss;
            if (boss != null)
            {
                var body = boss.GetComponent<MonsterDummy>();
                string bossName = AscendData.Db.Species.TryGetValue(body.SpeciesId, out var bs) ? bs.Name : body.SpeciesId;
                GUI.Label(new Rect(sw0 / 2 - 260, 88, 520, 20), $"{bossName} — {boss.Boss.Current.Name} (phase {boss.Boss.PhaseIndex + 1}/{boss.Boss.PhaseCount})", _small);
                Fill(new Rect(sw0 / 2 - 260, 110, 520, 10), body.MaxHp > 0 ? body.Hp / (float)body.MaxHp : 0f, new Color(0.85f, 0.2f, 0.2f));
            }
            var siege = SiegeDirector.Instance != null ? SiegeDirector.Instance.StatusText() : null;
            if (siege != null) GUI.Label(new Rect(sw0 / 2 - 220, 66, 440, 20), siege, _small);
            if (_quests != null)
            {
                y += 6;
                foreach (var line in _quests.TrackerLines()) { GUI.Label(new Rect(x, y, 520, 20), line, _small); y += 20; }
                var near = UiModal.Any ? null : QuestGiver.Nearest(player.transform.position);
                var nodeNear = UiModal.Any ? null : GatherNode.Nearest(player.transform.position);
                if (nodeNear != null && nodeNear.Data != null && (near == null || Vector3.Distance(nodeNear.transform.position, player.transform.position) < Vector3.Distance(near.transform.position, player.transform.position)))
                { GUI.Label(new Rect(sw0 / 2 - 150, Screen.height * 0.62f, 300, 22), nodeNear.Ready ? $"[E] Gather: {nodeNear.Data.Name}" : $"{nodeNear.Data.Name} (regrowing)", _small); near = null; }
                if (near != null) GUI.Label(new Rect(sw0 / 2 - 150, Screen.height * 0.62f, 300, 22), $"[E] Talk to {near.DisplayName}", _small);
            }

            // Style Rank (top-right)
            float sw = Screen.width;
            GUI.Label(new Rect(sw - 170, 20, 150, 60), StyleLabel(), _big);
            Fill(new Rect(sw - 170, 82, 150, 8), StyleProgress(), new Color(1f, 0.85f, 0.3f));

            // Lock-on target (top-centre)
            if (_lock != null && _lock.IsLocked)
                GUI.Label(new Rect(sw / 2 - 150, 20, 300, 22), $"◎ {_lock.Target.name}  HP {_lock.Target.Hp}/{_lock.Target.MaxHp}", _small);

            // Skills, Ultimate, Fire Bomb (bottom)
            float by = Screen.height - 70, bx = sw / 2 - 260;
            var slots = c.Slots;
            for (int i = 0; i < 4; i++)
            {
                string text = i < slots.Count ? $"{i + 1} {slots[i].Name}" + (c.CooldownLeft(slots[i].Id) > 0 ? $"\n{c.CooldownLeft(slots[i].Id):0.0}s" : "") : $"{i + 1} —";
                GUI.Box(new Rect(bx + i * 110, by, 104, 50), text, _box);
            }
            string ult = c.Ultimate != null ? $"R {c.Ultimate.Name}\n" + (c.Awakening >= c.MaxAwakening ? "READY" : $"{c.Awakening:0}%") : "";
            GUI.Box(new Rect(bx + 4 * 110, by, 130, 50), ult, _box);
            GUI.Box(new Rect(bx + 4 * 110 + 136, by, 70, 50), $"G Bomb\n×{player.FireBombs}", _box);

            // Banners and toasts (centre)
            if (Banner != null) GUI.Label(new Rect(0, Screen.height * 0.3f, sw, 60), Banner, _big);
            if (Time.unscaledTime < _toastUntil) GUI.Label(new Rect(sw / 2 - 80, Screen.height * 0.3f + 60, 160, 24), $"+{_toastXp} XP", _small);

            // Pickups (right, under the Style Rank)
            if (_inv != null) { float ty = 100; foreach (var t in _inv.Toasts) { GUI.Label(new Rect(sw - 260, ty, 240, 20), t, _small); ty += 20; } }

            // Death screen
            if (_respawn != null && _respawn.IsDead)
            {
                float sh = Screen.height;
                GUI.Box(new Rect(0, 0, sw, sh), "");
                GUI.Label(new Rect(0, sh * 0.32f, sw, 60), "YOU FELL", _big);
                GUI.Label(new Rect(sw / 2 - 300, sh * 0.32f + 70, 600, 24), $"Defeated by {_respawn.KilledBy} (Rank {_respawn.KillerRank})", _small);
                GUI.Label(new Rect(sw / 2 - 300, sh * 0.32f + 96, 600, 24), $"Tip: {_respawn.Tip}", _small);
                var pen = _respawn.LastPenalty;
                string lost = pen.DroppedCopper > 0 ? $"Dropped {Money.Format(pen.DroppedCopper, AscendData.Db.World.Currency)} — recover it from the blue lantern." : "Nothing was lost.";
                if (pen.XpLost > 0) lost += $"  Lost {pen.XpLost} XP.";
                GUI.Label(new Rect(sw / 2 - 300, sh * 0.32f + 122, 600, 24), lost, _small);
            }

            // Status Window
            if (StatusOpen)
            {
                var lines = StatusLines();
                GUI.Box(new Rect(sw / 2 - 360, 110, 720, 40 + lines.Count * 26), "STATUS", _box);
                for (int i = 0; i < lines.Count; i++) GUI.Label(new Rect(sw / 2 - 345, 140 + i * 26, 690, 24), lines[i], _small);
            }
        }

        void Bar(float x, ref float y, string label, float value, float max, Color color)
        {
            GUI.Label(new Rect(x, y - 2, 40, 18), label, _small);
            Fill(new Rect(x + 40, y, 220, 12), max > 0 ? value / max : 0, color);
            GUI.Label(new Rect(x + 265, y - 3, 120, 18), $"{value:0}/{max:0}", _small);
            y += 18;
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
