# -*- coding: utf-8 -*-
"""Workbook sheets, data export and docs for spell ranks, class access and monster casters."""
import json, os, collections
from data_core import DISCIPLINES, CAT_NAMES
from rank_class import RANKS, BAND_START, TIER, CHANT, MIN_CLASS_TIER, ADV, ACCESS, CLS
from monster_spells import spell_id

TITLES = {"F": "Rookie", "E": "Novice", "D": "Journeyman", "C": "Veteran", "B": "Elite", "A": "Champion", "S": "Hero", "SS": "Calamity", "SSS": "Transcendent"}
BAND_END = {"F": 15, "E": 35, "D": 60, "C": 90, "B": 125, "A": 165, "S": 210, "SS": 260, "SSS": 300}
CLASS_NAME = {k: k.replace("cls_", "").replace("_", " ").title() for k in ADV}


def cls_names(ids):
    return ", ".join(CLASS_NAME[i] for i in ids)


def export_data(recs, mons, out_dir):
    os.makedirs(out_dir, exist_ok=True)
    rows = []
    from feel_gen import spec
    for r in recs:
        s = spec(r)
        row = dict(id=spell_id(r), name=r["name"], discipline=r["disc_name"], category=r["cat"], subDiscipline=r["sub"], family=r["family"],
                   form=r["form"], element=r["element"], rank=r["rank"], tier=r["tier"], minLevel=r["minLevel"], chantSec=r["chant"],
                   minClassTier=r["minClassTier"], primaryClasses=r["classes"], altClasses=r["alt"], release=s["release"], active=s["active"],
                   recovery=s["recovery"], hitWeight=s["weight"], source=r["src"], status="proposed")
        if r.get("slice"):
            row["sliceWave"] = r["slice"]
        rows.append(row)
    with open(os.path.join(out_dir, "spells.json"), "w", encoding="utf-8") as f:
        f.write("[\n" + ",\n".join(json.dumps(x, ensure_ascii=False) for x in rows) + "\n]\n")
    with open(os.path.join(out_dir, "monster_spells.json"), "w", encoding="utf-8") as f:
        f.write("[\n" + ",\n".join(json.dumps(x, ensure_ascii=False) for x in mons) + "\n]\n")


def add_rank_sheets(wb, recs, mons, species, DISC, HUES, last):
    from openpyxl.styles import Font, PatternFill, Alignment, Border, Side
    from openpyxl.utils import get_column_letter
    HDR_FILL = PatternFill("solid", fgColor="1F2A44")
    HDR_FONT = Font(bold=True, color="FFFFFF", name="Calibri", size=11)
    thin = Side(style="thin", color="C9CDD6")
    BORDER = Border(left=thin, right=thin, top=thin, bottom=thin)
    WRAP = Alignment(wrap_text=True, vertical="top")

    def header(ws, cols, widths):
        for i, (h, w) in enumerate(zip(cols, widths), 1):
            c = ws.cell(row=1, column=i, value=h)
            c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
            c.alignment = Alignment(wrap_text=True, horizontal="center", vertical="center")
            ws.column_dimensions[get_column_letter(i)].width = w
        ws.row_dimensions[1].height = 32

    def put(ws, r, c, v, bold=False):
        cell = ws.cell(row=r, column=c, value=v)
        cell.alignment, cell.border = WRAP, BORDER
        cell.font = Font(name="Calibri", size=10, bold=bold)
        return cell

    SP = "Spells!$%s$2:$%s$" + str(last)
    col = lambda L: SP % (L, L)

    # ---------- Rank Ladder ----------
    ws = wb.create_sheet("Rank Ladder")
    discs = [d["name"] for d in DISCIPLINES]
    header(ws, ["Rank", "Guild title", "Level band", "Spell tier", "Chant time (canon)", "Class tier needed", "Spells"] + discs,
           [7, 14, 12, 14, 18, 16, 9] + [11] * len(discs))
    for i, rk in enumerate(RANKS, 2):
        tier = TIER[rk]
        chant = {"Basic": "0.5 s", "Intermediate": "1.5 s", "Advanced": "3 s", "Grand": "5 s", "Forbidden": "8 s + Aether Saturation", "Divine": "Ritual / Devotion"}[tier]
        for j, v in enumerate([rk, TITLES[rk], "%d-%d" % (BAND_START[rk], BAND_END[rk]), tier, chant, MIN_CLASS_TIER[rk].title(),
                               "=COUNTIF(%s,A%d)" % (col("R"), i)], 1):
            put(ws, i, j, v, j == 1)
        for k, dn in enumerate(discs):
            put(ws, i, 8 + k, "=COUNTIFS(%s,$A%d,%s,%s$1)" % (col("R"), i, col("C"), get_column_letter(8 + k)))
    tr = len(RANKS) + 2
    put(ws, tr, 1, "Total", True)
    for j in range(7, 8 + len(discs)):
        L = get_column_letter(j)
        put(ws, tr, j, "=SUM(%s2:%s%d)" % (L, L, tr - 1), True)
    notes = ["Rank rule: each spell gets a complexity score (category + form + size of the family + a small adjective effect); score 0 or less is F, 1-2 E, 3-4 D, 5 C, 6 B, 7 A, 8 and more S.",
             "Forbidden Arts are all SS (Canon: Forbidden is SS and above). Divine spells run F to S; only the five most complex rites are SSS (Canon: the Divine tier is SSS).",
             "Level and tier come from the Canon level bands and from skills_and_magic.md section 3; the class tier needed follows the promotion table (D>C Advanced, A>S Expert, SS>SSS Master). All proposed."]
    for k, t in enumerate(notes):
        ws.cell(row=tr + 2 + k, column=1, value=t).font = Font(italic=True, size=10)
    ws.freeze_panes = "B2"

    # ---------- Class Access ----------
    ws = wb.create_sheet("Class Access")
    header(ws, ["Class", "Advanced classes", "Primary spells", "Secondary (spellbook) spells"] + discs, [18, 28, 12, 14] + [11] * len(discs))
    for i, k in enumerate(ADV, 2):
        put(ws, i, 1, CLASS_NAME[k], True)
        put(ws, i, 2, ADV[k])
        put(ws, i, 3, '=COUNTIF(%s,"*%s*")' % (col("W"), CLASS_NAME[k]))
        put(ws, i, 4, '=COUNTIF(%s,"*%s*")' % (col("X"), CLASS_NAME[k]))
        for m, dn in enumerate(discs):
            put(ws, i, 5 + m, '=COUNTIFS(%s,"*%s*",%s,%s$1)' % (col("W"), CLASS_NAME[k], col("C"), get_column_letter(5 + m)))
    r0 = len(ADV) + 3
    ws.cell(row=r0, column=1, value="Access rules (proposed)").font = Font(bold=True, size=12, color="1F2A44")
    rules = [
        "Primary classes learn the spell as part of their identity (trainer or class quest). Secondary classes can learn it from a spellbook, scroll or affinity (Spells are learned by Spellbooks, trainers, scrolls and affinity: skills_and_magic.md section 2).",
        "Class tier needed: F-D base class, C-A Advanced, S Expert, SS Expert plus a Forbidden unlock (Church hunts users), SSS Master or a Devotion ritual with a patron god.",
        "Mage owns Aethercraft and the elements; Cleric owns Divine and Radiance; Occultist owns Umbral and the Void branch; Tamer owns Spiritbond; Ranger and Rogue take the movement, sensing and concealment spells; weapon classes borrow a few Empowerment and Strike spells.",
        "Forbidden Arts: Time and Space through Mage (Spellweaver, then Chronomancer); Void through Occultist (Warlock or Necromancer, then Void Walker). Rogue may learn short Space steps and Time illusions.",
        "Bard songs stay in the Bard kit; the Bard access here covers sound-based Galecraft and support spells only.",
    ]
    for k, t in enumerate(rules, 1):
        c = ws.cell(row=r0 + k, column=1, value=t)
        c.alignment = Alignment(wrap_text=True, vertical="top")
        ws.merge_cells(start_row=r0 + k, start_column=1, end_row=r0 + k, end_column=12)
        ws.row_dimensions[r0 + k].height = 32
    ws.freeze_panes = "B2"

    # ---------- Monster Casters ----------
    byid = {spell_id(r): r for r in recs}
    sp = {s["id"]: s for s in species}
    ws = wb.create_sheet("Monster Casters")
    header(ws, ["Species ID", "Species", "Family", "Rank", "Element", "Ring", "Unique", "Role", "Spell 1", "Spell 2", "Spell 3", "Spell 4", "Spell 5", "Telegraphs"],
           [24, 30, 24, 7, 10, 6, 8, 9, 34, 34, 34, 34, 34, 24])
    for i, m in enumerate(mons, 2):
        s = sp[m["speciesId"]]
        vals = [s["id"], s["name"], s["family"], s["rank"], s["element"], s["ring"], "yes" if s.get("isUnique") else "", m["role"]]
        spells = ["%s (%s, %s)" % (byid[x]["name"], byid[x]["rank"], byid[x]["cat"]) for x in m["spellIds"]]
        vals += spells + [""] * (5 - len(spells)) + [", ".join(m["telegraphs"])]
        for j, v in enumerate(vals, 1):
            put(ws, i, j, v, j == 2)
    ws.freeze_panes = "C2"
    ws.auto_filter.ref = "A1:N%d" % (len(mons) + 1)


def write_rank_doc(path, recs, mons, species):
    L, a = [], None
    a = L.append
    byrank = collections.Counter(r["rank"] for r in recs)
    a("# Spell Ranks, Class Access and Monster Casters")
    a("")
    a("> **Owner:** class-skill-designer with the bestiary-designer and systems-designer. **Status:** PROPOSED v1, 2026-11-03, not locked Canon. Machine-readable copies: `Data/Spells/spells.json` (%d spells) and `Data/Spells/monster_spells.json` (%d species), checked by `node Tools/validate/validate.js`. Prose for every spell is in `05_Skills_Magic/Aetheria_Spell_Codex.xlsx`." % (len(recs), len(mons)))
    a("> **Builds on:** [[ranks]] (nine ranks, level bands) · [[skills_and_magic]] (spell tiers and chant times) · [[base_and_advanced]] (the 12 base and 24 advanced classes) · [[spell_look_and_feel]].")
    a("")
    a("## 1. Every spell has a rank")
    a("")
    a("| Rank | Title | Level | Spell tier | Chant | Class tier needed | Spells |")
    a("|---|---|---|---|---|---|---|")
    for rk in RANKS:
        tier = TIER[rk]
        chant = {"Basic": "0.5 s", "Intermediate": "1.5 s", "Advanced": "3 s", "Grand": "5 s", "Forbidden": "8 s + Aether Saturation", "Divine": "Ritual / Devotion"}[tier]
        a("| **%s** | %s | %d-%d | %s | %s | %s | %d |" % (rk, TITLES[rk], BAND_START[rk], BAND_END[rk], tier, chant, MIN_CLASS_TIER[rk].title(), byrank[rk]))
    a("")
    a("**How a rank is set.** A complexity score is built from the category (Utility is simplest, Barrage most complex), the form (a plain needlepoint is simpler than an echo or an oathbound rite), the size of the family (a Comet or Cascade is bigger than a Spark or Thread) and, for catalogue names, a small adjective effect (Storm and Mountain up, Gentle and Glimmer down). Score 0 or less is F, 1-2 E, 3-4 D, 5 C, 6 B, 7 A, 8 or more S. The same kind of spell has the same rank in every discipline.")
    a("")
    a("**Two disciplines are special.** Forbidden Arts are all **SS** (Canon: Forbidden is SS and above, Space, Time and Void). Divine spells run from F to S as Devotion spells of the Cleric's patron god; only the five most complex rites are **SSS**, the Canon Divine tier.")
    a("")
    a("**Elements.** The schema's elements map to the disciplines: Fire is Flamecraft, Water Tidecraft, Wind and Lightning Galecraft (Lightning is its **Storm** branch), Earth Stonecraft, Ice Frostcraft, Nature and Poison Verdance (Poison is its **Blight** branch), Light Radiance, Dark and Blood Umbral, Void Forbidden. Aethercraft, Spiritbond and Divine have no element.")
    a("")
    a("## 2. Class access")
    a("")
    a("Each spell lists the base classes that learn it as part of their identity (primary) and those that can learn it from a spellbook (secondary). Base class names link to their advanced classes in [[base_and_advanced]].")
    a("")
    a("| Discipline | Primary classes | Secondary classes |")
    a("|---|---|---|")
    for d in DISCIPLINES:
        prim, sec = [], []
        for ck, cats, kind in ACCESS[d["code"]]:
            (prim if kind == "P" else sec).append(CLASS_NAME[CLS[ck]])
        prim = list(dict.fromkeys(prim)); sec = [x for x in dict.fromkeys(sec) if x not in prim]
        a("| **%s** | %s | %s |" % (d["name"], ", ".join(prim), ", ".join(sec)))
    a("")
    a("The workbook sheet **Class Access** counts how many spells each class gets, per discipline. The class tier needed follows the promotion table in [[ranks]]: base classes learn F-D spells, Advanced classes C-A, Expert classes S and SS, Master classes SSS.")
    a("")
    a("## 3. Which monsters cast which spells")
    a("")
    casters = sum(1 for m in mons if m["role"] == "caster")
    a("%d of the 680 species cast spells: %d true casters (M.ATK above ATK, a magical family, a caster's name, or a unique) with 2 to 5 spells each (most have 3), and %d elemental species with one affinity spell. Rules:" % (len(mons), casters, len(mons) - casters))
    a("")
    a("- **Element picks the discipline** (see section 1); elementless casters use Aethercraft, spirit families Spiritbond, and only Calamity-rank (SS) species and above touch the Forbidden Arts.")
    a("- **A spell is never ranked above its caster.** A C+ monster casts spells of rank C or lower, and prefers the top of that range. EX species may cast anything.")
    a("- **Menu:** an offence spell (Strike or Barrage), a control spell (Binding or Hex) and a support spell (Ward, Illusion, Mending or Empowerment); uniques add a fourth, Tyrants a fifth, a Barrage.")
    a("- **Telegraph follows the category:** Strike is blue (parryable), Barrage red (unblockable zone), Binding gold (grab), the rest none. When a monster casts, the spell uses its dimmer enemy palette from [[spell_look_and_feel]].")
    a("")
    a("The full list is the workbook sheet **Monster Casters** and `Data/Spells/monster_spells.json`.")
    a("")
    with open(path, "w", encoding="utf-8") as fh:
        fh.write("\n".join(L) + "\n")
