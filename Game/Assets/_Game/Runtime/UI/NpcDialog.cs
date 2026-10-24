using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// The talk window (IMGUI placeholder, like the HUD): the NPC's name and role, then numbered options — hand in a
    /// ready quest, make a quest's decision, accept a quest on offer, or leave. Keys 1–9 pick, Esc / B leaves;
    /// on a gamepad D-pad up/down moves and A picks. While it is open the player doesn't move or attack.
    /// </summary>
    public sealed class NpcDialog : MonoBehaviour
    {
        struct Option { public string Text; public System.Action Act; }

        public static bool IsOpen => _open != null && _open._giver != null;
        static NpcDialog _open;

        QuestGiver _giver;
        PlayerQuests _quests;
        readonly List<Option> _options = new List<Option>();
        string _line;
        int _cursor;
        float _openedAt;
        GUIStyle _box, _title, _item;

        public QuestGiver Giver => _giver;
        public IReadOnlyList<string> OptionTexts => _options.Select(o => o.Text).ToList();

        public static NpcDialog Instance
        {
            get
            {
                if (_open == null) _open = FindFirstObjectByType<NpcDialog>() ?? new GameObject("NpcDialog").AddComponent<NpcDialog>();
                return _open;
            }
        }

        public void Open(QuestGiver giver, PlayerQuests quests)
        {
            _giver = giver; _quests = quests; _cursor = 0; _openedAt = Time.unscaledTime; _page = Page.Main;
            quests.Talk(giver.NpcId);
            _line = AscendData.Db.Npcs.TryGetValue(giver.NpcId, out var n) && !string.IsNullOrEmpty(n.Role) ? n.Role : "";
            Rebuild();
        }

        public void Close() { _giver = null; _quests = null; _options.Clear(); }

        /// <summary>Picks option <paramref name="index"/> (0-based); returns false when out of range.</summary>
        public bool Choose(int index)
        {
            if (!IsOpen || index < 0 || index >= _options.Count) return false;
            _options[index].Act();
            if (_giver != null) Rebuild();
            return true;
        }

        enum Page { Main, Buy, Sell, Buyback }
        Page _page;

        void Rebuild()
        {
            _options.Clear();
            var q = _quests;
            var inv = q.GetComponent<PlayerInventory>();
            var shop = inv != null ? inv.ShopFor(_giver.NpcId) : null;
            if (shop != null && _page != Page.Main) { RebuildTrade(shop, inv); return; }
            foreach (var p in _giver.AwaitingChoiceHere(q))
            {
                var data = AscendData.Db.Quests[p.QuestId];
                int idx = data.Objectives.FindIndex(o => o.Kind == "choice" && p.Counts[data.Objectives.IndexOf(o)] < 1);
                if (idx < 0) continue;
                foreach (var opt in QuestChoices.Options(data.Objectives[idx].Target))
                {
                    string id = p.QuestId; int obj = idx; string pick = opt;
                    _options.Add(new Option { Text = $"{data.Title}: {Capital(opt)}", Act = () => { q.Log.Choose(id, obj, pick); _line = $"You chose to {pick}."; } });
                }
            }
            foreach (var p in _giver.ReadyHere(q))
            {
                string id = p.QuestId;
                _options.Add(new Option { Text = $"Hand in: {AscendData.Db.Quests[id].Title}", Act = () => { if (q.TurnIn(id)) _line = "Thank you. The guild pays its debts."; } });
            }
            foreach (var offer in _giver.OffersHere(q))
            {
                var o = offer;
                _options.Add(new Option { Text = $"Accept [{o.Rank}] {o.Title} — {o.Summary}", Act = () => { if (q.Accept(o)) _line = "Good luck out there."; } });
            }
            if (shop != null) _options.Add(new Option { Text = $"Trade — {shop.Data.Name}", Act = () => Go(Page.Buy, shop.Data.Note) });
            _options.Add(new Option { Text = "Goodbye", Act = Close });
            _cursor = Mathf.Clamp(_cursor, 0, _options.Count - 1);
        }

        void Go(Page page, string line = null) { _page = page; _cursor = 0; if (line != null) _line = line; }

        void RebuildTrade(Shop shop, PlayerInventory inv)
        {
            var db = AscendData.Db;
            var cur = db.World.Currency;
            string Name(string id) => db.Items.TryGetValue(id, out var it) ? it.Name : id;
            string Say(TradeResult r) => r switch
            {
                TradeResult.Ok => null,
                TradeResult.NotEnoughMoney => "You can't afford that.",
                TradeResult.OutOfStock => "Sold out, I'm afraid.",
                TradeResult.Protected => "You'll need that for a job you've taken.",
                TradeResult.NotBought => "That's not something I buy.",
                _ => "Hmm?",
            };
            void Did(TradeResult r, string ok) => _line = Say(r) ?? ok;
            switch (_page)
            {
                case Page.Buy:
                    foreach (var o in shop.Data.Stock)
                    {
                        var offer = o;
                        int? left = shop.Left(o.ItemId);
                        string stock = left.HasValue ? $", {left} left" : "";
                        _options.Add(new Option
                        {
                            Text = $"Buy {Name(o.ItemId)} — {Money.Format(o.Price, cur)} (you have {inv.Items.Count(o.ItemId)}{stock})",
                            Act = () => Did(shop.Buy(offer.ItemId, inv.Items), $"Bought {Name(offer.ItemId)}."),
                        });
                    }
                    if (shop.Data.Buys.Categories.Count > 0) _options.Add(new Option { Text = "Sell…", Act = () => Go(Page.Sell) });
                    if (shop.Buyback.Count > 0) _options.Add(new Option { Text = "Buy back…", Act = () => Go(Page.Buyback) });
                    break;
                case Page.Sell:
                    var protectedItems = _quests.ProtectedItems();
                    foreach (var (itemId, count, price) in shop.Sellable(inv.Items).Take(7))
                    {
                        string id = itemId;
                        string guard = protectedItems.Contains(id) ? " [quest]" : "";
                        _options.Add(new Option
                        {
                            Text = $"Sell {Name(id)} ×{count}{guard} — {Money.Format(price, cur)} each",
                            Act = () => Did(shop.Sell(id, inv.Items, protectedItems), $"Sold {Name(id)}."),
                        });
                    }
                    if (_options.Count == 0) _line = "You've nothing I'd buy.";
                    break;
                case Page.Buyback:
                    for (int i = 0; i < shop.Buyback.Count && i < 7; i++)
                    {
                        int idx = i; var (id, price) = shop.Buyback[i];
                        _options.Add(new Option { Text = $"Buy back {Name(id)} — {Money.Format(price, cur)}", Act = () => Did(shop.BuyBack(idx, inv.Items), $"Bought back {Name(id)}.") });
                    }
                    break;
            }
            _options.Add(new Option { Text = _page == Page.Buy ? "Back" : "Back to wares", Act = () => Go(_page == Page.Buy ? Page.Main : Page.Buy, "") });
            _cursor = Mathf.Clamp(_cursor, 0, _options.Count - 1);
        }

        static string Capital(string s) => string.IsNullOrEmpty(s) ? s : char.ToUpperInvariant(s[0]) + s.Substring(1);

        void Update()
        {
            if (!IsOpen) return;
            if (_quests == null || Vector3.Distance(_quests.transform.position, _giver.transform.position) > QuestGiver.TalkRadius * 2f) { Close(); return; }
            if (Time.unscaledTime - _openedAt < 0.15f) return; // the key that opened the window doesn't also pick
            var kb = Keyboard.current;
            if (kb != null)
            {
                if (kb.escapeKey.wasPressedThisFrame) { Close(); return; }
                for (int i = 0; i < 9; i++)
                    if (kb[(Key)((int)Key.Digit1 + i)].wasPressedThisFrame) { Choose(i); return; }
                if (kb.upArrowKey.wasPressedThisFrame) _cursor = Mathf.Max(0, _cursor - 1);
                if (kb.downArrowKey.wasPressedThisFrame) _cursor = Mathf.Min(_options.Count - 1, _cursor + 1);
                if (kb.enterKey.wasPressedThisFrame || kb.eKey.wasPressedThisFrame) { Choose(_cursor); return; }
            }
            var pad = Gamepad.current;
            if (pad != null)
            {
                if (pad.buttonEast.wasPressedThisFrame) { Close(); return; }
                if (pad.dpad.up.wasPressedThisFrame) _cursor = Mathf.Max(0, _cursor - 1);
                if (pad.dpad.down.wasPressedThisFrame) _cursor = Mathf.Min(_options.Count - 1, _cursor + 1);
                if (pad.buttonSouth.wasPressedThisFrame) Choose(_cursor);
            }
        }

        void OnGUI()
        {
            if (!IsOpen) return;
            _box ??= new GUIStyle(GUI.skin.box);
            _title ??= new GUIStyle(GUI.skin.label) { fontSize = 20, fontStyle = FontStyle.Bold };
            _item ??= new GUIStyle(GUI.skin.label) { fontSize = 15, wordWrap = true };
            float w = Mathf.Min(760f, Screen.width - 40f), h = 90f + _options.Count * 44f;
            var r = new Rect((Screen.width - w) / 2f, Screen.height - h - 110f, w, h);
            GUI.Box(r, "", _box);
            GUI.Label(new Rect(r.x + 16, r.y + 10, w - 32, 26), _giver.DisplayName, _title);
            if (_page != Page.Main && _quests != null && _quests.TryGetComponent<PlayerInventory>(out var inv))
                GUI.Label(new Rect(r.x + w - 300, r.y + 14, 284, 22), $"Purse: {inv.MoneyText}", _item);
            GUI.Label(new Rect(r.x + 16, r.y + 38, w - 32, 22), _line, _item);
            for (int i = 0; i < _options.Count; i++)
            {
                string mark = i == _cursor ? "▶ " : "   ";
                GUI.Label(new Rect(r.x + 16, r.y + 68 + i * 44, w - 32, 42), $"{mark}{i + 1}. {_options[i].Text}", _item);
            }
        }
    }
}
