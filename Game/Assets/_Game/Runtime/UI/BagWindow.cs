using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// The bag (IMGUI placeholder): what you're wearing, gear you carry with how it compares (▲ better / ▼ worse ATK, DEF…),
    /// and potions. Number keys / D-pad + A equip or use; the same on a worn slot takes it off. I or the gamepad View
    /// button opens and closes it; Esc / B closes. The player stands still while it is open.
    /// </summary>
    public sealed class BagWindow : MonoBehaviour
    {
        struct Option { public string Text; public System.Action Act; }

        static BagWindow _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static BagWindow Instance => _instance != null ? _instance : _instance = FindFirstObjectByType<BagWindow>() ?? new GameObject("BagWindow").AddComponent<BagWindow>();

        bool _open;
        PlayerCombat _combat;
        PlayerInventory _inv;
        readonly List<Option> _options = new List<Option>();
        string _line = "";
        int _cursor;
        float _openedAt;
        GUIStyle _box, _title, _item;

        public IReadOnlyList<string> OptionTexts => _options.Select(o => o.Text).ToList();

        public void Toggle(PlayerCombat combat) { if (_open) Close(); else Open(combat); }

        PartnerData _pendingRelease;

        public void Open(PlayerCombat combat)
        {
            _pendingRelease = null;
            _combat = combat; _inv = combat.GetComponent<PlayerInventory>();
            _open = _inv != null; _cursor = 0; _line = ""; _openedAt = Time.unscaledTime;
            Rebuild();
        }

        public void Close() { _open = false; _options.Clear(); }

        public bool Choose(int index)
        {
            if (!_open || index < 0 || index >= _options.Count) return false;
            _options[index].Act();
            if (_open) Rebuild();
            return true;
        }

        void Rebuild()
        {
            _options.Clear();
            var db = AscendData.Db;
            var eq = _combat.Equipment;
            string Name(string id) => db.Items.TryGetValue(id, out var it) ? it.Name : id;

            foreach (var kv in eq.Slots.OrderBy(k => k.Key))
            {
                string slot = kv.Key, id = kv.Value;
                _options.Add(new Option { Text = $"[{Pretty(slot)}] {Name(id)} — {StatText(db.Items[id])}  (take off)", Act = () => { eq.Unequip(slot, _inv.Items); _line = $"Took off {Name(id)}."; } });
            }
            var now = eq.Bonus();
            foreach (var kv in _inv.Items.Items.OrderBy(k => k.Key))
            {
                if (!db.Items.TryGetValue(kv.Key, out var it)) continue;
                string id = kv.Key;
                if (Equipment.IsGear(it))
                {
                    var can = eq.CanEquip(id, _combat.Class);
                    string why = can == EquipResult.WrongWeapon ? $" — your class can't wield a {it.WeaponType?.Replace('_', ' ')}"
                               : can == EquipResult.WrongArmor ? $" — too {it.ArmorWeight} for your class" : "";
                    string cmp = can == EquipResult.Ok ? Compare(now, eq.BonusWith(id)) : "";
                    _options.Add(new Option
                    {
                        Text = $"Equip {it.Name} ×{kv.Value} [{Pretty(it.Slot)}] {cmp}{why}",
                        Act = () => { var r = eq.Equip(id, _inv.Items, _combat.Class); _line = r == EquipResult.Ok ? $"Equipped {it.Name}." : "You can't use that."; },
                    });
                }
                else if (it.Category == "consumable" && it.Stat("heal") > 0)
                    _options.Add(new Option { Text = $"Drink {it.Name} ×{kv.Value} (+{it.Stat("heal"):0} HP)", Act = () => _inv.DrinkHealingPotion() });
            }
            var crafting = _combat.GetComponent<PlayerCrafting>();
            if (crafting != null)
                foreach (var r in crafting.Crafter.All.Where(r => crafting.Crafter.Knows(r.Id) && crafting.Crafter.StationAvailable(r.Station, null)))
                {
                    var recipe = r;
                    _options.Add(new Option { Text = $"Campfire: cook {r.Name} — {crafting.InputsText(r)}", Act = () => crafting.Make(recipe, null) });
                }
            var taming = _combat.GetComponent<PlayerTaming>();
            if (taming != null)
            {
                var t = db.World.Taming;
                foreach (var p in taming.Roster.All.ToList())
                {
                    var partner = p;
                    var sp = db.Species.TryGetValue(p.SpeciesId, out var s) ? s : null;
                    string what = sp != null ? $"{sp.Name}, {Partners.RoleOf(sp)}" : p.SpeciesId;
                    string where = p.Active ? "with you" : "at the ranch";
                    _options.Add(new Option
                    {
                        Text = $"Partner {p.Name} ({what}) · Bond {p.Bond}/{t.MaxBond} · {where} — {(p.Active ? "send to the ranch" : "bring along")}",
                        Act = () => _line = taming.SetActive(partner, !partner.Active) ? $"{partner.Name} is {(partner.Active ? "with you" : "off to the ranch")}." : $"Three partners travel with you at most.",
                    });
                    _options.Add(new Option
                    {
                        Text = _pendingRelease == p ? $"   Confirm: release {p.Name} to the wild (can't be undone)" : $"   Release {p.Name}…",
                        Act = () => { if (_pendingRelease == partner) { taming.Release(partner); _pendingRelease = null; _line = $"{partner.Name} bounds off into the trees."; } else { _pendingRelease = partner; _line = "Choose it again to confirm."; } },
                    });
                    if (Partners.CanEvolve(p, db, t))
                        foreach (var b in Partners.Branches(p.SpeciesId, db))
                        {
                            var branch = b;
                            _options.Add(new Option
                            {
                                Text = $"   Evolve {p.Name} → {b.Name} (rank {b.Rank}, {b.VariantKind}, {Partners.RoleOf(b)}, ATK {b.Stats.Atk} HP {b.Stats.Hp}) — final",
                                Act = () => { if (taming.Evolve(partner, branch.Id)) _line = $"{partner.Name} is now a {branch.Name}."; },
                            });
                        }
                }
            }
            _options.Add(new Option { Text = "Close", Act = Close });
            _cursor = Mathf.Clamp(_cursor, 0, _options.Count - 1);
        }

        static string Pretty(string slot) => string.IsNullOrEmpty(slot) ? "" : slot.Replace('_', ' ');

        static string StatText(ItemData it)
        {
            var parts = new List<string>();
            foreach (var k in new[] { "atk", "matk", "def", "mdef", "hp" }) { double v = it.Stat(k); if (v != 0) parts.Add($"{k.ToUpperInvariant()} +{v:0}"); }
            double c = it.Stat("crit"); if (c != 0) parts.Add($"CRIT +{c * 100:0}%");
            return parts.Count > 0 ? string.Join(", ", parts) : "no stats";
        }

        /// <summary>Change if equipped: "ATK ▲14 DEF ▼3"; empty when nothing changes.</summary>
        static string Compare(GearBonus now, GearBonus with)
        {
            var parts = new List<string>();
            void D(string n, int d) { if (d != 0) parts.Add($"{n} {(d > 0 ? "▲" : "▼")}{System.Math.Abs(d)}"); }
            D("ATK", with.Atk - now.Atk); D("MATK", with.Matk - now.Matk); D("DEF", with.Def - now.Def); D("MDEF", with.Mdef - now.Mdef); D("HP", with.Hp - now.Hp);
            int crit = (int)System.Math.Round((with.Crit - now.Crit) * 100); D("CRIT%", crit);
            return parts.Count > 0 ? "(" + string.Join(" ", parts) + ")" : "(no change)";
        }

        void Update()
        {
            if (!_open) return;
            if (Time.unscaledTime - _openedAt < 0.15f) return;
            var kb = Keyboard.current;
            if (kb != null)
            {
                if (kb.escapeKey.wasPressedThisFrame || kb.iKey.wasPressedThisFrame) { Close(); return; }
                for (int i = 0; i < 9; i++) if (kb[(Key)((int)Key.Digit1 + i)].wasPressedThisFrame) { Choose(i); return; }
                if (kb.upArrowKey.wasPressedThisFrame) _cursor = Mathf.Max(0, _cursor - 1);
                if (kb.downArrowKey.wasPressedThisFrame) _cursor = Mathf.Min(_options.Count - 1, _cursor + 1);
                if (kb.enterKey.wasPressedThisFrame) { Choose(_cursor); return; }
            }
            var pad = Gamepad.current;
            if (pad != null)
            {
                if (pad.buttonEast.wasPressedThisFrame || pad.selectButton.wasPressedThisFrame) { Close(); return; }
                if (pad.dpad.up.wasPressedThisFrame) _cursor = Mathf.Max(0, _cursor - 1);
                if (pad.dpad.down.wasPressedThisFrame) _cursor = Mathf.Min(_options.Count - 1, _cursor + 1);
                if (pad.buttonSouth.wasPressedThisFrame) Choose(_cursor);
            }
        }

        void OnGUI()
        {
            if (!_open) return;
            _box ??= new GUIStyle(GUI.skin.box);
            _title ??= new GUIStyle(GUI.skin.label) { fontSize = 20, fontStyle = FontStyle.Bold };
            _item ??= new GUIStyle(GUI.skin.label) { fontSize = 15, wordWrap = true };
            float w = Mathf.Min(820f, Screen.width - 40f), h = 96f + _options.Count * 30f;
            var r = new Rect((Screen.width - w) / 2f, Mathf.Max(20f, (Screen.height - h) / 2f), w, h);
            GUI.Box(r, "", _box);
            var s = _combat.Stats;
            GUI.Label(new Rect(r.x + 16, r.y + 10, w - 32, 26), "BAG", _title);
            GUI.Label(new Rect(r.x + 90, r.y + 14, w - 106, 22), $"ATK {s.Atk} · MATK {s.Matk} · DEF {s.Def} · MDEF {s.Mdef} · HP {s.Hp} · CRIT {s.CritChance * 100:0}% · Purse {_inv.MoneyText}", _item);
            GUI.Label(new Rect(r.x + 16, r.y + 40, w - 32, 22), _line, _item);
            for (int i = 0; i < _options.Count; i++)
                GUI.Label(new Rect(r.x + 16, r.y + 68 + i * 30, w - 32, 28), $"{(i == _cursor ? "▶ " : "   ")}{i + 1}. {_options[i].Text}", _item);
        }
    }

    /// <summary>Any window that takes over the controls (talk, bag).</summary>
    public static class UiModal
    {
        public static bool Any => NpcDialog.IsOpen || BagWindow.IsOpen;
    }
}
