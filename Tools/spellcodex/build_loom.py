# -*- coding: utf-8 -*-
"""Generate the Spell Loom data (Data/Spells/*.json), the design doc and the workbook sheets."""
import json, math, os, re
from data_core import DISCIPLINES
from rank_class import RANKS, BAND_START, TIER, CHANT, ADV, CLS
import loom_data as L

DNAME = {d["code"]: d["name"] for d in DISCIPLINES}
RING = ["AET", "FLM", "GAL", "STN", "FRS", "TID", "VRD", "SPR", "DIV", "RAD", "UMB", "FBD"]
STARTS = ["mage", "swordsman", "lancer", "guardian", "martial_artist", "ranger", "tamer", "cleric", "bard", "rogue", "occultist", "artisan"]
ELEM_DISC = {"Fire": "FLM", "Water": "TID", "Wind": "GAL", "Earth": "STN", "Ice": "FRS", "Nature": "VRD", "Light": "RAD", "Dark": "UMB",
             "Lightning": "GAL", "Poison": "VRD"}


def slug(s):
    return re.sub(r"[^a-z0-9]+", "_", s.lower()).strip("_")


def cname(k):
    return k.replace("_", " ").title()


# ----------------------------------------------------------------------------- data builders
def build_threads():
    rows = []
    for name, grp, strain, cats, minr, eff in L.SHAPE:
        disc = [DNAME[c] for c in L.GROUPS[grp]]
        rows.append(dict(id="thr_" + slug(name), name=name, kind="shape", group=grp, strain=strain, categories=cats, disciplines=disc,
                         minRank=minr, hold=0, trigger="", element="None", effect=eff, status="proposed"))
    for name, strain, cats, discs, minr, eff in L.POWER:
        disc = [DNAME[c] for c in (discs or [d["code"] for d in DISCIPLINES])]
        rows.append(dict(id="thr_" + slug(name), name=name, kind="power", group="any", strain=strain, categories=cats, disciplines=disc,
                         minRank=minr, hold=0, trigger="", element="None", effect=eff, status="proposed"))
    for nm, elem in L.ATTUNE:
        rows.append(dict(id="thr_attune_" + slug(nm), name="Attune: " + nm, kind="attune", group="any", strain=1.25,
                         categories=["Strike", "Barrage", "Hex", "Binding"], disciplines=[DNAME[d["code"]] for d in DISCIPLINES if d["code"] != ELEM_DISC[elem]],
                         minRank="C", hold=0, trigger="", element=elem,
                         effect="Adds a %s aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element." % elem,
                         status="proposed"))
    for name, trig, hold, cats, minr, eff in L.TRIGGER:
        rows.append(dict(id="thr_" + slug(name), name=name, kind="trigger", group="any", strain=1.0, categories=cats,
                         disciplines=[d["name"] for d in DISCIPLINES], minRank=minr, hold=hold, trigger=trig, element="None", effect=eff, status="proposed"))
    return rows


def build_ranks():
    rows = []
    for rk, slots, socks, hold, unlock in L.LOOM_RANKS:
        lv = BAND_START[rk]
        rows.append(dict(id="lrk_" + rk.lower(), rank=rk, levelMin=lv, tier=TIER[rk], chantSec=CHANT[TIER[rk]], loomSlots=slots, maxThreadSockets=socks,
                         hold=hold, attunePoints=lv // 3, unlocks=unlock, status="proposed"))
    return rows


def pol(r, a):
    return (r * math.cos(math.radians(a)), r * math.sin(math.radians(a)))


def build_tree():
    nodes = {}
    order = []

    def add(id_, name, kind, cluster, effect, cost, x, y, downside="", cls=""):
        nodes[id_] = dict(id=id_, name=name, kind=kind, cluster=cluster, effect=effect, downside=downside, cost=cost, links=[],
                          x=round(x, 1), y=round(y, 1), **({"classKey": cls} if cls else {}))
        order.append(id_)

    def link(a, b):
        if b not in nodes[a]["links"]:
            nodes[a]["links"].append(b)
        if a not in nodes[b]["links"]:
            nodes[b]["links"].append(a)

    add("att_hub", "Aether Attunement", "hub", "core", "The root of every caster. Free.", 0, 0, 0)
    ang = {c: i * 30 - 90 for i, c in enumerate(RING)}
    for c in RING:
        T = L.TREE[c]
        th = ang[c]
        d = T["label"]
        sm = [dict(name=T["smalls"][i], effect=L.SMALL_STATS[i][1].format(d=d)) for i in range(6)]
        P = lambda k: "att_%s_%s" % (c.lower(), k)
        spec = [("s1", 115, 0), ("s2", 160, 0), ("n1", 218, -8), ("s3", 210, 5), ("s4", 255, 4), ("n2", 305, 11), ("s5", 300, 0), ("n3", 350, -9), ("s6", 352, 3), ("key", 405, 1)]
        for k, r, da in spec:
            x, y = pol(r, th + da)
            if k.startswith("s"):
                s = sm[int(k[1]) - 1]
                add(P(k), s["name"], "small", c, s["effect"], 1, x, y)
            elif k.startswith("n"):
                n = T["notables"][int(k[1]) - 1]
                add(P(k), n[0], "notable", c, n[1], 2, x, y)
            else:
                kn = T["keystone"]
                add(P(k), kn[0], "keystone", c, kn[1], 3, x, y, downside=kn[2])
        for a, b in [("s1", "s2"), ("s2", "n1"), ("s2", "s3"), ("s3", "s4"), ("s4", "n2"), ("s4", "s5"), ("s5", "n3"), ("s5", "s6"), ("s6", "key")]:
            link(P(a), P(b))
    # bridges between neighbouring arms (arm i s3 -> bridge -> arm i+1 n1)
    for i, c in enumerate(RING):
        nxt = RING[(i + 1) % 12]
        x, y = pol(216, ang[c] + 15)
        bid = "att_bridge_%s_%s" % (c.lower(), nxt.lower())
        add(bid, "%s to %s" % (L.TREE[c]["label"], L.TREE[nxt]["label"]), "bridge", "core",
            "+3%% potency of %s and %s spells" % (L.TREE[c]["label"], L.TREE[nxt]["label"]), 1, x, y)
        link("att_%s_s3" % c.lower(), bid)
        link(bid, "att_%s_n1" % nxt.lower())
    # class starts, one per gap between neighbouring arms
    for i, k in enumerate(STARTS):
        a, b = RING[i], RING[(i + 1) % 12]
        ma = ang[a] + 15
        x, y = pol(66, ma)
        sid = "att_start_" + k
        add(sid, "Start: " + cname(k), "start", "core", L.CLASS_START[k], 0, x, y, cls=k)
        link("att_hub", sid)
        link(sid, "att_%s_s1" % a.lower())
        link(sid, "att_%s_s1" % b.lower())
    return [nodes[i] for i in order]


def build_ascension():
    rows = []
    for adv, (base, gate, notables, key) in L.ASCENSION.items():
        a = slug(adv)
        rows.append(dict(id="asc_%s_gate" % a, advancedClass=adv, baseClass="cls_" + base, kind="gate", name=gate[0], effect=gate[1], downside="", cost=0, requires="", status="proposed"))
        for i, (n, e) in enumerate(notables, 1):
            rows.append(dict(id="asc_%s_n%d" % (a, i), advancedClass=adv, baseClass="cls_" + base, kind="notable", name=n, effect=e, downside="", cost=1,
                             requires="asc_%s_gate" % a, status="proposed"))
        rows.append(dict(id="asc_%s_key" % a, advancedClass=adv, baseClass="cls_" + base, kind="keystone", name=key[0], effect=key[1], downside=key[2], cost=2,
                         requires="asc_%s_n3" % a, status="proposed"))
    return rows


def write_json(rows, path):
    with open(path, "w", encoding="utf-8") as f:
        f.write("[\n" + ",\n".join(json.dumps(r, ensure_ascii=False) for r in rows) + "\n]\n")


def export(out_dir):
    th, rk, tr, asc = build_threads(), build_ranks(), build_tree(), build_ascension()
    os.makedirs(out_dir, exist_ok=True)
    write_json(th, os.path.join(out_dir, "threads.json"))
    write_json(rk, os.path.join(out_dir, "loom_ranks.json"))
    write_json(tr, os.path.join(out_dir, "attunement_tree.json"))
    write_json(asc, os.path.join(out_dir, "ascension.json"))
    return th, rk, tr, asc


# ----------------------------------------------------------------------------- workbook sheets
def add_loom_sheets(wb, th, rk, tr, asc):
    from openpyxl.styles import Font, PatternFill, Alignment, Border, Side
    from openpyxl.utils import get_column_letter
    HF = PatternFill("solid", fgColor="1F2A44")
    HFont = Font(bold=True, color="FFFFFF", name="Calibri", size=11)
    thin = Side(style="thin", color="C9CDD6")
    B = Border(left=thin, right=thin, top=thin, bottom=thin)
    W = Alignment(wrap_text=True, vertical="top")

    def sheet(name, cols, widths, rows):
        ws = wb.create_sheet(name)
        for i, (c, w) in enumerate(zip(cols, widths), 1):
            h = ws.cell(row=1, column=i, value=c)
            h.fill, h.font, h.border = HF, HFont, B
            h.alignment = Alignment(wrap_text=True, horizontal="center", vertical="center")
            ws.column_dimensions[get_column_letter(i)].width = w
        for r, row in enumerate(rows, 2):
            for c, v in enumerate(row, 1):
                cell = ws.cell(row=r, column=c, value=v)
                cell.alignment, cell.border, cell.font = W, B, Font(name="Calibri", size=10, bold=(c == 2))
        ws.freeze_panes = "C2"
        ws.auto_filter.ref = "A1:%s%d" % (get_column_letter(len(cols)), len(rows) + 1)
        return ws

    sheet("Loom Ranks", ["ID", "Rank", "Level from", "Spell tier", "Chant (s)", "Loom slots", "Max thread sockets", "Hold", "Attunement points", "What unlocks"],
          [11, 7, 10, 14, 9, 10, 12, 8, 12, 90],
          [[r["id"], r["rank"], r["levelMin"], r["tier"], r["chantSec"] if r["chantSec"] is not None else "ritual", r["loomSlots"], r["maxThreadSockets"], r["hold"],
            r["attunePoints"], r["unlocks"]] for r in rk])
    sheet("Threads", ["ID", "Thread", "Kind", "Group", "Strain x", "Hold", "Min rank", "Trigger", "Element", "Categories", "Effect"],
          [24, 22, 9, 8, 9, 7, 9, 22, 10, 40, 80],
          [[t["id"], t["name"], t["kind"], t["group"], t["strain"], t["hold"] or "", t["minRank"], t["trigger"], t["element"] if t["element"] != "None" else "",
            ", ".join(t["categories"]) if len(t["categories"]) < 12 else "any", t["effect"]] for t in th])
    sheet("Attunement Tree", ["ID", "Node", "Kind", "Cluster", "Cost", "Effect", "Downside", "Links"], [28, 24, 10, 10, 6, 70, 50, 60],
          [[n["id"], n["name"], n["kind"], n["cluster"], n["cost"], n["effect"], n["downside"], ", ".join(n["links"])] for n in tr])
    sheet("Ascension", ["ID", "Advanced class", "Kind", "Node", "Cost", "Effect", "Downside", "Requires"], [26, 16, 9, 24, 6, 70, 50, 26],
          [[a["id"], a["advancedClass"], a["kind"], a["name"], a["cost"], a["effect"], a["downside"], a["requires"]] for a in asc])


# ----------------------------------------------------------------------------- design document
def write_doc(path, th, rk, tr, asc):
    Ln = []
    a = Ln.append
    nodes_by_kind = {}
    for n in tr:
        nodes_by_kind[n["kind"]] = nodes_by_kind.get(n["kind"], 0) + 1
    a("# The Spell Loom")
    a("")
    a("> **Owner:** class-skill-designer with the systems-designer and combat-designer. **Status:** PROPOSED v1, 2026-11-03, not locked Canon. Data: `Data/Spells/threads.json`, `loom_ranks.json`, `attunement_tree.json`, `ascension.json` (checked by `node Tools/validate/validate.js`). Interactive version: the Aetheria Spell Loom page. Every number is a tunable proposal.")
    a("> **Builds on:** [[spell_ranks_and_classes]] (every spell has a rank and learners) · [[skills_and_magic]] (chant tiers, proficiency 1-10, Evolve or Fuse) · [[base_and_advanced]] (classes, the Spellweaver's glyphs) · [[ranks]] · [[combat]].")
    a("")
    a("## 1. The idea in one paragraph")
    a("")
    a("A caster does not just learn spells. They **weave** them. Spells sit in a small number of **Loom slots**. Each spell has **thread sockets**, and a **thread** is a modifier that changes how that one spell behaves: its shape, its power, its element, or when it fires. Every thread raises the spell's **Strain** (a cost multiplier), so power always has a price. Spells that stay up (wards, blessings, familiars) reserve **Hold** from a budget instead of costing MP each time. Behind the Loom sits the **Attunement tree**, a web of passive nodes with keystones that trade one strength for one weakness, and after the advanced class change an **Ascension tree** for the class itself.")
    a("")
    a("## 2. Research: what the Path of Exile skill system does, and what we took")
    a("")
    a("Research date 2026-11-03, from public guides and wikis (listed in section 12). Several wiki pages blocked automated access, so some details come from search summaries and guides; the numbers for Path of Exile 2 were still changing in early access and are not used. **Only mechanics and ideas are used. No names, text, numbers, art or data are copied, as the project rules require.**")
    a("")
    a("| What the studied system does | The idea we kept | How Aetheria does it (original) |")
    a("|---|---|---|")
    a("| Every ability comes from a socketed gem; **support gems** linked to it modify it | Spells are the base, modifiers attach to one spell | Spells in **Loom slots** with **threads** in each spell's **thread sockets** |")
    a("| Supports raise the skill's **mana cost by a multiplier**; a few lower it | Power always costs; the cost is a visible number | Every thread has a **Strain** multiplier; the total is the product (Frugal lowers it) |")
    a("| Supports only work with certain skill types, set separately from tags | Compatibility is a rule, not a free-for-all | Each thread lists allowed **categories** and **disciplines** |")
    a("| Socket count and links are the long chase (up to 6 links) | A slow, visible power curve for one spell | Thread sockets grow by **rank** (1 to 5), capped by the spell's own tier |")
    a("| Persistent effects (auras, permanent minions) **reserve a budget** (Spirit in the sequel) instead of costing mana | A separate budget keeps buffs from stacking without limit | **Hold**: persistent spells and trigger threads reserve it while active |")
    a("| **Meta gems** trigger skills on conditions | Spells can fire on your own good play | **Trigger threads**: on a perfect dodge, a parry, a stagger, an element reaction |")
    a("| Gems level with use and can be upgraded or swapped | Mastery through use | Proficiency 1-10 by use (Canon); at 10 **Evolve** (imprint a shape thread permanently) or **Fuse** |")
    a("| A huge **passive tree**: small, notable and keystone nodes; class start points; one shared web | Where you start only suggests where you go | The **Attunement tree**: 12 discipline arms, 12 class starts, bridges between arms |")
    a("| **Keystones** change the rules and come with downsides | Big choices must hurt a little | One keystone per discipline, each with a stated downside |")
    a("| **Ascendancy** sub-classes with their own small tree, unlocked by a trial | Class identity deepens late | **Ascension trees** for advanced classes, unlocked by the class change itself |")
    a("| Respec is costly and scarce | (Not kept) | Canon says respec is always possible: free to level 10, then a small cost, never blocked |")
    a("")
    a("## 3. The Loom: rules")
    a("")
    a("1. **Loom slots.** Only spells in a slot can be cast. Slots by rank: " + ", ".join("%s %d" % (r["rank"], r["loomSlots"]) for r in rk) + ". Weapon arts and class basic strings do not use slots.")
    a("2. **Thread sockets.** Each spell has sockets up to the rank cap (" + ", ".join("%s %d" % (r["rank"], r["maxThreadSockets"]) for r in rk) + "), and never more than its own tier allows (Basic 3, Intermediate 4, Advanced and above 5).")
    a("3. **One shape, one attune.** A spell takes at most one Shape thread and one Attune thread, and never the same thread twice. Power and trigger threads stack freely within sockets.")
    a("4. **Strain.** MP cost = base cost x the product of all thread Strain values. Frugal (0.80) is the only thread below 1.")
    a("5. **Chant.** Chant time = tier chant (0.5 / 1.5 / 3 / 5 / 8 s) x chant modifiers (Swift Chant 0.7, Overcharge 1.4). Mastery steps (full, short, name only, chantless) still shorten it as in Canon.")
    a("6. **Compatibility.** A thread works only on the categories and disciplines it lists. An incompatible thread simply does not fit the socket.")
    a("7. **Changing threads** is free out of combat at any Loom Shrine or camp. Mid-fight changes are an Ascension perk (Spellweaver).")
    a("8. **Class bonuses.** Spellweavers can carry two Shape threads on one spell (a notable); Clerics and Tamers gain the most Hold; Mages have the widest compatible spell list.")
    a("")
    a("### Loom ranks")
    a("")
    a("| Rank | From level | Tier | Loom slots | Max sockets | Hold | Attunement points | What opens |")
    a("|---|---|---|---|---|---|---|---|")
    for r in rk:
        a("| **%s** | %d | %s | %d | %d | %d | %d | %s |" % (r["rank"], r["levelMin"], r["tier"], r["loomSlots"], r["maxThreadSockets"], r["hold"], r["attunePoints"], r["unlocks"]))
    a("")
    a("## 4. Threads (%d)" % len(th))
    a("")
    kinds = [("shape", "Shape threads: the codex forms become modifiers"), ("power", "Power threads"), ("attune", "Attune threads: borrow an element"), ("trigger", "Trigger threads: fire on your own good play")]
    for kd, title in kinds:
        a("### %s" % title)
        a("")
        if kd == "shape":
            a("The 28 forms of the Spell Codex are no longer separate spells. They are threads you fit to any compatible spell of their group (Weave: Aethercraft and the elements; Bond; Faith; Frayed). Evolving a spell at proficiency 10 imprints one of them for free.")
            a("")
        a("| Thread | Group | Strain | Min rank | Hold | Effect |")
        a("|---|---|---|---|---|---|")
        for t in th:
            if t["kind"] == kd:
                a("| **%s** | %s | x%.2f | %s | %s | %s |" % (t["name"], t["group"] if t["group"] != "any" else "any", t["strain"], t["minRank"], t["hold"] or "", t["effect"] + ((" Fires " + t["trigger"] + ".") if t["trigger"] else "")))
        a("")
    a("## 5. Hold: the budget for spells that stay up")
    a("")
    a("Wards, blessings, illusions, familiars, lanterns and trigger threads reserve **Hold** while active, and give it back when they end. Hold by rank: " + ", ".join("%s %d" % (r["rank"], r["hold"]) for r in rk) + ". Suggested reservations: a Ward 30, an Empowerment 25, an Illusion 20, a Pact familiar 40, a Utility lantern 10. MP does not reserve; a caster's MP pool is always full for casting. The Anchored thread lowers a spell's reservation by 20%.")
    a("")
    a("## 6. Proficiency, Evolve and Fuse")
    a("")
    a("Spells level 1-10 by use (Canon). Each level adds 4% potency (36% at 10) and removes 1% Strain. At level 10 the player chooses: **Evolve** (imprint one Shape thread from the spell's family forever: no socket, no Strain) or **Fuse** (merge with another level 10 spell of a reacting element into a combined spell, the old Fuse rule). The codex form ranks are the ranks of the evolved forms.")
    a("")
    a("## 7. The Attunement tree")
    a("")
    a("A radial web of **%d nodes**: 1 hub, 12 class starts, 12 discipline arms of 10 nodes each (6 small, 3 notable, 1 keystone) and 12 bridges between neighbouring arms. You start on your class's start node and may path anywhere; where you start only suggests where you go. Points: 1 per 3 levels (100 at level 300). Costs: small and bridge 1, notable 2, keystone 3. Arms in ring order: %s. The ring puts Aethercraft beside Flamecraft and Forbidden Arts, Spiritbond beside Divine, and so on." % (len(tr), ", ".join(DNAME[c] for c in RING)))
    a("")
    a("### Keystones (one per discipline, each with a downside)")
    a("")
    a("| Keystone | Discipline | You gain | You pay |")
    a("|---|---|---|---|")
    for n in tr:
        if n["kind"] == "keystone":
            a("| **%s** | %s | %s | %s |" % (n["name"], L.TREE[n["cluster"].upper()]["label"], n["effect"], n["downside"]))
    a("")
    a("### Notables")
    a("")
    a("| Notable | Discipline | Effect |")
    a("|---|---|---|")
    for n in tr:
        if n["kind"] == "notable":
            a("| %s | %s | %s |" % (n["name"], L.TREE[n["cluster"].upper()]["label"], n["effect"]))
    a("")
    a("**Respec (Canon: always possible).** Free to level 10 and one free token at each class-tier change; otherwise a small gold fee scaled to the points refunded, at any Loom Shrine. Nothing is ever locked in.")
    a("")
    a("## 8. Ascension trees")
    a("")
    a("The advanced class change (rank C) opens an Ascension tree for the class: a free gate node, three notables (1 point each) and a keystone (2 points). Ascension points: 2 at the advanced change, 2 at rank A, 1 at the expert change. The %d casting classes below have trees; the other advanced classes follow in a later pass." % len(L.ASCENSION))
    a("")
    a("| Advanced class | Gate | Notables | Keystone (gain / pay) |")
    a("|---|---|---|---|")
    for adv, (base, gate, notes, key) in L.ASCENSION.items():
        a("| **%s** (%s) | %s: %s | %s | **%s**: %s / %s |" % (adv, cname(base), gate[0], gate[1], "; ".join("%s: %s" % n for n in notes), key[0], key[1], key[2]))
    a("")
    a("## 9. The curve from level 1 to 300")
    a("")
    a("| Levels | Rank | What the player is learning |")
    a("|---|---|---|")
    beats = [("1-3", "F", "Learn the class's first spell. Cast it, watch the chant ring. No threads, no tree: the game teaches one idea at a time."),
             ("3-8", "F", "First Attunement point at level 3: pick a small node beside your class start. First thread socket on your first spell; a trainer teaches one shape thread. See Strain on the cost line."),
             ("8-15", "F", "Second spell; swap a thread out of combat at a camp. Free respec still on until level 10. Try one Frugal or Needlepoint thread."),
             ("16-35", "E", "Third spell slot and the first Hold. A Ward or a blessing now stays up. Second thread socket. Urgent versus Gentle calls teach that Bond spells can refuse."),
             ("36-60", "D", "Four spells and Power threads. A notable (2 points) is the first real choice. Spells reach proficiency 10 and the first Evolve or Fuse appears."),
             ("61-90", "C", "Advanced class change: the Ascension tree opens. Attune threads let a Fire spell carry an Ice aura, so reactions become a build, not an accident."),
             ("91-165", "B-A", "Trigger threads (react to a dodge, a parry, a stagger). Keystones come into reach. Builds now have a name: 'the Flash-Time Lancer', 'the Public Prayer cleric'."),
             ("166-210", "S", "Expert class. Grand spells (5 s chant) with four sockets. Imprint anything. The tree's trade-offs now define the character."),
             ("211-300", "SS-SSS", "Forbidden spells and Weave-light threads; Aether Saturation is the cost. The Divine rituals and the Master class close the Loom.")]
    for lv, rkk, txt in beats:
        a("| %s | %s | %s |" % (lv, rkk, txt))
    a("")
    a("## 10. Example builds")
    a("")
    a("**Level 18 Mage (rank E: 3 slots, 2 sockets, Hold 20).** Loom: Cinder Fang with Needlepoint + Far Reach (Strain 1.15 x 1.10 = 1.27, chant 0.5 s); Rimefang Shard with Walking Cast (x1.25); Kindle Thread plain. Two Attunement points (level 18 gives 6): Kindled Voice and Banked Coals. Simple on purpose.")
    a("")
    a("**Level 62 Elementalist (rank C: 4 slots, 3 sockets, Hold 60).** Glacier Lock (Intermediate, chant 1.5 s) with Needlepoint + Swift Chant + Potency: Strain 1.15 x 1.25 x 1.30 = 1.87, chant 1.5 x 0.7 = 1.05 s. Undertow Snare with Attune: Spark, so a Water hit carries a Lightning aura and starts Storm Prison (x1.25). Winterglass Shield with Anchored (x1.15, reserves 24 Hold instead of 30). Emberbrand Edge with Frugal (x0.80). The Ascension notable Reaction Scholar makes the reaction 25% stronger.")
    a("")
    a("**Level 120 Priest (rank B: 5 slots, 3 sockets, Hold 80).** Hearth of Grace with Quiet Prayer (x0.90) and Lingering (x1.20); Sanctuary of Hands with Public Prayer (x1.40), Anchored (x1.15, Hold 24) and the trigger Reflex Ward (Hold 30): Strain 1.61, Hold 54 of 80; Morrow's Measure with Tether (x1.10); Mercy Flame with Steady Chant (x1.20). Keystone Unwavering Faith: refusals halve, Devotion costs 50% more.")
    a("")
    a("## 11. Guardrails")
    a("")
    a("- **No infinite loops.** Strain is multiplicative, sockets are capped by rank and tier, and Hold is a hard budget. The strongest build is the one that spends everything, not one that finds a free multiplier.")
    a("- **Every strength has a price.** Keystones carry downsides, Power threads raise Strain, Overcharge adds recoil, Forbidden spells add Aether Saturation.")
    a("- **Low levels stay simple.** Rank F has one socket and no Hold; the Loom grows as the player does. A reduced-complexity setting hides threads and suggests a default.")
    a("- **Respec is free to try.** A new build is never a trap; Canon section 5.")
    a("- **Hard limits hold.** No thread creates Aether, gold, a road to Earth, lasting will control or revival past the lantern. Trigger threads cannot trigger other triggers.")
    a("- **Readable in combat.** Threads change shape, sound and colour in the ways described in [[spell_look_and_feel]]; no thread adds a new telegraph colour.")
    a("")
    a("## 12. Sources")
    a("")
    a("Studied for mechanics only (a mix of wikis and community guides; some blocked automated access, so some points rest on search summaries):")
    a("")
    for t, u in L.SOURCES:
        a("- [%s](%s)" % (t, u))
    a("")
    with open(path, "w", encoding="utf-8") as fh:
        fh.write("\n".join(Ln) + "\n")
