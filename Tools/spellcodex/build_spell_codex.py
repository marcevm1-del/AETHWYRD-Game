# -*- coding: utf-8 -*-
"""Build the Aetheria Spell Codex workbook (Excel) from the three source codices plus an expansion set.

Usage:  python3 Tools/spellcodex/build_spell_codex.py [output.xlsx]

Sources (parsed from the supplied PDFs into Tools/spellcodex/sources/*.json):
  1. Anime Naming Edition  - 116 hand-written spells
  2. 1,000-Spell Codex     - 143 base spells x 7 forms = 1,000
  3. 1,001-entry Catalogue - 'Adjective Noun' names with placeholder notes
  4. Expansion (new)       - 300 new 'Imagery + Action' spells
Every spell gets Description, Visual Design and How It Works, each 50-100 words, plus a category.
PROPOSED design content - not locked Canon.
"""
import json, os, re, sys, zlib, random, collections

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)
from data_core import DISCIPLINES, CATEGORIES, CAT_NAMES, CAT_TARGET, USE, PAD_DESC, PAD_VIS, PAD_HOW
import data_extra  # noqa: F401  (merges extra sentence variety into the banks)
import feel_sheets
from slice_data import SLICE
from slice_texts import T as POLISH
import rank_class, rank_sheets, monster_spells
from data_families import B as BASES, FORM_TEXT, FORM_TARGET
from data_nouns import NOUNS, ADJ, STUFF
from data_actions import ACTIONS, IMAGERY

MIN_W, MAX_W, TARGET_W = 50, 100, 56
DISC = {d["code"]: d for d in DISCIPLINES}
DISC_ORDER = [d["code"] for d in DISCIPLINES]
DISC_BY_NAME = {d["name"]: d["code"] for d in DISCIPLINES}
SRC = {1: "Anime Naming Edition", 2: "1,000-Spell Codex", 3: "1,001 Catalogue", 4: "Expansion (new)"}


def load(name):
    with open(os.path.join(HERE, "sources", name), encoding="utf-8") as f:
        return json.load(f)


def wc(t):
    return len(t.split())


def rng_for(key):
    return random.Random(zlib.crc32(key.encode("utf-8")))


def pick(pool, rng, n=1):
    items = list(pool)
    rng.shuffle(items)
    return items[:n]


def ensure_period(s):
    s = s.strip()
    return s if s[-1] in ".!?" else s + "."


def fit(required, optional, key):
    """Join required sentences, then add optional ones while staying <= MAX_W until >= TARGET_W."""
    req = [ensure_period(x) for x in required if x]
    text = " ".join(req)
    if wc(text) > MAX_W:
        raise ValueError("required text too long (%d words) for %s" % (wc(text), key))
    for opt in optional:
        if wc(text) >= TARGET_W:
            break
        cand = ensure_period(opt)
        if wc(text) + wc(cand) <= MAX_W and cand not in text:
            text = text + " " + cand
    if wc(text) < MIN_W:
        raise ValueError("text too short (%d words) for %s: %s" % (wc(text), key, text))
    return re.sub(r"\s+", " ", text)


def roman(n):
    out = ""
    for v, s in ((10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")):
        while n >= v:
            out += s
            n -= v
    return out


def build_records():
    a_rows = load("src1_anime_naming_116.json")
    b_ent = load("src2_codex_1000.json")
    c_rows = load("src3_catalog_1001.json")
    recs = []
    a_by_name = {r["name"]: r for r in a_rows}

    # reverse map: anime name -> base name
    anime_to_base = {}
    for base, (disc, cat, sub, aname, vis, how) in BASES.items():
        if aname:
            assert aname in a_by_name, aname
            anime_to_base[aname] = base
    assert len(anime_to_base) == 116, len(anime_to_base)

    # ---- Source 1: anime-named 116 ----
    for r in a_rows:
        base = anime_to_base[r["name"]]
        disc, cat, sub = BASES[base][0], BASES[base][1], BASES[base][2]
        assert DISC_BY_NAME[r["disc"]] == disc, (r["name"], r["disc"], disc)
        key = "A|" + r["name"]
        rng = rng_for(key)
        use = pick(USE[cat], rng, 3)
        d = DISC[disc]
        desc = fit([r["desc"]], use + pick(PAD_DESC, rng, 2), key + "d")
        vis = fit([r["vis"]], pick(d["vis"], rng, 3) + pick(PAD_VIS, rng, 2), key + "v")
        how = fit([r["how"]], pick(d["channel"], rng, 2) + pick(d["limit"], rng, 2) + pick(PAD_HOW, rng, 2), key + "h")
        recs.append(dict(name=r["name"], disc=disc, cat=cat, sub=sub, family=base, form="Signature",
                         target=CAT_TARGET[cat], src=1, ref="%03d" % r["n"], orig=r["name"],
                         desc=desc, vis=vis, how=how))

    # ---- Source 2: 1,000 codex ----
    tail_re = re.compile(r"\s*Implementation Notes.*$", re.S)
    for num in sorted(b_ent, key=int):
        full, body = b_ent[num]
        base, _, form = full.partition(" — ")
        body = tail_re.sub("", body).strip()
        first, _, rest = body.partition(" ")           # drop discipline word
        sents = re.split(r"(?<=\.)\s+", rest.strip())
        core, formsent = sents[0], sents[1]
        s_tail = sents[2] if len(sents) > 2 else ""
        s_extra = sents[3] if len(sents) > 3 else ""
        disc, cat, sub, aname, bvis, bhow = BASES[base]
        if aname:
            bvis, bhow = a_by_name[aname]["vis"], a_by_name[aname]["how"]
        assert bvis and bhow, base
        d = DISC[disc]
        key = "B|" + num
        rng = rng_for(key)
        fvis, fhow = FORM_TEXT[form]
        fvis, fhow = fvis.format(n=base), fhow
        desc = fit([core, formsent], pick(USE[cat], rng, 3) + pick(PAD_DESC, rng, 2), key + "d")
        vis = fit([bvis, fvis], pick(d["vis"], rng, 3) + pick(PAD_VIS, rng, 2), key + "v")
        opt_how = [s_tail] + pick(d["channel"], rng, 2) + pick(d["limit"], rng, 2)
        try:
            how = fit([bhow, fhow] + ([s_extra] if s_extra else []), opt_how, key + "h")
        except ValueError:
            how = fit([bhow] + ([s_extra] if s_extra else []), [fhow] + opt_how, key + "h")
        recs.append(dict(name=full, disc=disc, cat=cat, sub=sub, family=base, form=form,
                         target=FORM_TARGET[form], src=2, ref=num, orig=full,
                         desc=desc, vis=vis, how=how))

    # ---- Source 3: 1,001 catalogue ----
    seen = collections.Counter()
    for n, name, note in c_rows:
        plain = re.sub(r"\s\d{4}$", "", name)
        seen[plain] += 1
        final = plain if seen[plain] == 1 else "%s %s" % (plain, roman(seen[plain]))
        adj, noun = plain.split(" ", 1)
        disc = ADJ[adj][0]
        cat, ndesc, nvis, nhow = NOUNS[noun]
        d = DISC[disc]
        s, h = STUFF[disc], d["hue"]
        key = "C|%d" % n
        rng = rng_for(key)
        sub = d["sub"]
        if disc == "FBD":
            sub = ("Space", "Time", "Void")[zlib.crc32(noun.encode()) % 3]
        desc = fit([ndesc.format(s=s, h=h), ADJ[adj][1]], pick(USE[cat], rng, 3) + pick(PAD_DESC, rng, 2), key + "d")
        vis = fit([nvis.format(s=s, h=h), ADJ[adj][2]], pick(d["vis"], rng, 3) + pick(PAD_VIS, rng, 2), key + "v")
        how = fit([nhow], pick(d["channel"], rng, 2) + pick(d["limit"], rng, 2) + pick(PAD_HOW, rng, 2), key + "h")
        recs.append(dict(name=final, disc=disc, cat=cat, sub=sub, family=noun, form="Standard",
                         target=CAT_TARGET[cat], src=3, ref=str(n), orig=name,
                         desc=desc, vis=vis, how=how,
                         note="" if final == plain else "Duplicate name in source; numbered %s." % final.split()[-1]))

    # ---- Source 4: expansion (new) ----
    taken = {r["name"].lower() for r in recs}
    for di, code in enumerate(DISC_ORDER):
        d = DISC[code]
        s, h = STUFF[code], d["hue"]
        for k in range(25):
            cat = CAT_NAMES[k % 12]
            acts = ACTIONS[cat]
            act = acts[(k // 12 + di) % 3]
            img = IMAGERY[code][(k * 7 + di * 5) % 12]
            name = "%s %s" % (img, act[0])
            tries = 0
            while name.lower() in taken:
                tries += 1
                img = IMAGERY[code][(k * 7 + di * 5 + tries) % 12]
                name = "%s %s" % (img, act[0])
                assert tries < 12, name
            taken.add(name.lower())
            key = "N|" + name
            rng = rng_for(key)
            sub = d["sub"]
            if code == "FBD":
                sub = ("Space", "Time", "Void")[k % 3]
            desc = fit([act[1].format(s=s, h=h)], pick(USE[cat], rng, 3) + pick(PAD_DESC, rng, 2), key + "d")
            vis = fit([act[2].format(s=s, h=h)], pick(d["vis"], rng, 4) + pick(PAD_VIS, rng, 2), key + "v")
            how = fit([act[3]], pick(d["channel"], rng, 2) + pick(d["limit"], rng, 2) + pick(PAD_HOW, rng, 2), key + "h")
            recs.append(dict(name=name, disc=code, cat=cat, sub=sub, family=act[0], form="Standard",
                             target=CAT_TARGET[cat], src=4, ref="new", orig="", desc=desc, vis=vis, how=how,
                             imagery=img, action=act[0]))

    # ---- IDs ----
    order = {c: i for i, c in enumerate(DISC_ORDER)}
    corder = {c: i for i, c in enumerate(CAT_NAMES)}
    recs.sort(key=lambda r: (order[r["disc"]], corder[r["cat"]], r["src"], r["name"]))
    counters = collections.Counter()
    for r in recs:
        counters[r["disc"]] += 1
        r["id"] = "%s-%04d" % (r["disc"], counters[r["disc"]])
    names = [r["name"].lower() for r in recs]
    assert len(set(names)) == len(names), "duplicate spell names"
    hit = 0
    for r in recs:
        r["disc_name"] = DISC[r["disc"]]["name"]
        if r["name"] in POLISH:
            r["desc"], r["vis"], r["how"], r["moment"] = POLISH[r["name"]]
            r["polished"] = True
        if r["name"] in SLICE:
            r["slice"] = SLICE[r["name"]][0]
            hit += 1
    assert hit == len(SLICE) == len(POLISH) == 50, (hit, len(SLICE), len(POLISH))
    rank_class.retag_subs(recs)
    rank_class.assign_ranks(recs)
    for r in recs:
        r["classes"], r["alt"] = rank_class.class_access(r)
    return recs, a_rows, b_ent, c_rows


def validate(recs):
    problems = []
    for r in recs:
        for f in ("desc", "vis", "how"):
            n = wc(r[f])
            if not (MIN_W <= n <= MAX_W):
                problems.append((r["id"], f, n))
            if "{" in r[f] or "}" in r[f] or "  " in r[f]:
                problems.append((r["id"], f, "bad chars"))
    return problems


# ----------------------------------------------------------------------------- Excel
def write_xlsx(recs, a_rows, b_ent, c_rows, out):
    from openpyxl import Workbook
    from openpyxl.styles import Font, PatternFill, Alignment, Border, Side
    from openpyxl.utils import get_column_letter

    HUES = {"AET": "DCE3F5", "FLM": "FBE0D0", "TID": "D5E8F2", "GAL": "E3EEE8", "STN": "EADFCC", "FRS": "E4F0F8",
            "VRD": "DDEBD2", "RAD": "FFF3CC", "UMB": "DDD6E8", "SPR": "D8EFE6", "DIV": "FBEFD8", "FBD": "E2DCE2"}
    HDR_FILL = PatternFill("solid", fgColor="1F2A44")
    HDR_FONT = Font(bold=True, color="FFFFFF", name="Calibri", size=11)
    thin = Side(style="thin", color="C9CDD6")
    BORDER = Border(left=thin, right=thin, top=thin, bottom=thin)
    WRAP = Alignment(wrap_text=True, vertical="top")
    base_font = Font(name="Calibri", size=10)

    wb = Workbook()

    # ---------- Read Me ----------
    ws = wb.active
    ws.title = "Read Me"
    lines = [
        ("AETHERIA - SPELL CODEX (MASTER WORKBOOK)", "title"),
        ("PROPOSED DESIGN CONTENT - NOT LOCKED CANON. Canon.md and approved source documents always take precedence.", "warn"),
        ("", None),
        ("What this is", "h"),
        ("A single workbook that merges the three supplied spell codices, rewrites every spell so that its Description, Visual Design and How It Works fields are each 50-100 words, adds %d new spells, and sorts everything into 12 disciplines and 12 categories." % sum(1 for r in recs if r["src"] == 4), None),
        ("Total spells: %d (minimum asked for: 1,000)." % len(recs), None),
        ("", None),
        ("Sheets", "h"),
        ("Spells - the master list. Filter by Discipline, Category, Sub-Discipline, Family, Form, Source. Word-count columns are live formulas.", None),
        ("Categories - the 12 categories, their definitions, counts, and a Discipline x Category count matrix.", None),
        ("Disciplines - the 12 disciplines with visual identity, sub-disciplines and counts.", None),
        ("Source Crosswalk - the separate sheet keeping every original entry from the three PDFs, mapped to its new ID.", None),
        ("New Spells - the separate sheet listing only the newly invented expansion spells.", None),
        ("Vertical Slice - the 50 spells chosen for the first playable slice (hand-polished text), in three build waves, with rank, classes, what each one proves and its signature moment. The Spells sheet marks them in the Slice Wave column.", None),
        ("Rank Ladder, Class Access, Monster Casters - every spell's rank, tier, level and chant (Canon bands), which classes learn it, and which monster species cast it. Machine-readable copies are in Data/Spells/.", None),
        ("Look & Feel - the production spec for every spell: timings in seconds and frames, hit weight, hit-stop and shake, palette hexes, shape and size in metres, motion, Unity VFX build and budget, audio, aftermath, telegraph and icon.", None),
        ("Feel Rules, Chant Tiers, Feel Disciplines, Feel Categories, Feel Forms, Reactions VFX - the rulebook behind the Look & Feel sheet (also written up in 13_Production/spell_look_and_feel.md).", None),
        ("", None),
        ("Sources", "h"),
        ("Source 1 - Aetheria Spell Codex, Anime Naming Edition (116 spells). Original prose kept and extended.", None),
        ("Source 2 - Aetheria 1,000-Spell Codex (143 base spells x 7 forms = 1,000). Forms keep their original names and rules text; Family = the base spell.", None),
        ("Source 3 - Aetheria Magic System & Proposed Spell Catalog (1,001 entries). Its placeholder concept notes were replaced with real descriptions; 124 repeated names were numbered II, III.", None),
        ("Source 4 - Expansion (new). Named with the anime formula [Evocative Imagery] + [Action Word].", None),
        ("", None),
        ("Laws every entry obeys (from the source codices)", "h"),
        ("Aether is the source; mana is the usable form. No spell creates Aether or grants free energy.", None),
        ("No spell creates lasting gold or cores, reverses death once the soul's lantern is out, rewrites Status, opens a road to Earth, or permanently commands a Status-bearer's will.", None),
        ("Chants shape mana and being staggered breaks them. Divine answers may be refused. Spirit workings depend on Bond, consent and mood. Every Forbidden use frays the Weave.", None),
        ("The fields deliberately do not invent mana costs, cast times, cooldowns, damage numbers or spell ranks - assign those only after combat testing.", None),
        ("", None),
        ("Fields", "h"),
        ("Description = what the spell does in-world and its meaningful limit. Visual Design = what it looks and sounds like, for animation and VFX. How It Works = the mana logic beneath it, including counterplay and failure states.", None),
        ("Category = the spell's role (Strike, Barrage, Ward, Binding, Mobility, Sensing, Mending, Empowerment, Hex, Illusion, Pact, Utility). Sub-Discipline = the element or branch inside the discipline. Family/Form = the base spell and its variant.", None),
        ("", None),
        ("Rebuild", "h"),
        ("python3 Tools/spellcodex/build_spell_codex.py  (sources are stored in Tools/spellcodex/sources/).", None),
    ]
    for i, (t, kind) in enumerate(lines, 1):
        c = ws.cell(row=i, column=1, value=t)
        c.alignment = Alignment(wrap_text=True, vertical="top")
        c.font = base_font
        if kind == "title":
            c.font = Font(name="Calibri", size=18, bold=True, color="1F2A44")
        elif kind == "warn":
            c.font = Font(name="Calibri", size=10, italic=True, color="9C3B2E")
        elif kind == "h":
            c.font = Font(name="Calibri", size=12, bold=True, color="1F2A44")
    ws.column_dimensions["A"].width = 130
    ws.sheet_view.showGridLines = False

    # ---------- Spells ----------
    sp = wb.create_sheet("Spells")
    headers = ["ID", "Spell Name", "Discipline", "Category", "Sub-Discipline", "Family", "Form / Variant", "Targeting",
               "Source", "Source Ref", "Description", "Visual Design", "How It Works", "Desc Words", "Visual Words", "How Words", "Slice Wave", "Rank", "Tier", "Min Level", "Chant (s)", "Element", "Primary Classes", "Secondary Classes", "Min Class Tier"]
    widths = [10, 28, 15, 13, 13, 20, 18, 20, 20, 10, 62, 62, 62, 8, 8, 8, 8, 7, 13, 9, 9, 10, 34, 34, 12]
    for i, (h, w) in enumerate(zip(headers, widths), 1):
        c = sp.cell(row=1, column=i, value=h)
        c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
        c.alignment = Alignment(wrap_text=True, vertical="center", horizontal="center")
        sp.column_dimensions[get_column_letter(i)].width = w
    sp.row_dimensions[1].height = 30
    for ri, r in enumerate(recs, 2):
        vals = [r["id"], r["name"], DISC[r["disc"]]["name"], r["cat"], r["sub"], r["family"], r["form"], r["target"],
                SRC[r["src"]], r["ref"], r["desc"], r["vis"], r["how"]]
        for ci, v in enumerate(vals, 1):
            c = sp.cell(row=ri, column=ci, value=v)
            c.alignment = WRAP
            c.font = base_font
            c.border = BORDER
        sp.cell(row=ri, column=1).fill = PatternFill("solid", fgColor=HUES[r["disc"]])
        sp.cell(row=ri, column=3).fill = PatternFill("solid", fgColor=HUES[r["disc"]])
        sp.cell(row=ri, column=2).font = Font(name="Calibri", size=10, bold=True)
        for ci, col in ((14, "K"), (15, "L"), (16, "M")):
            c = sp.cell(row=ri, column=ci, value="=LEN(TRIM(%s%d))-LEN(SUBSTITUTE(TRIM(%s%d),\" \",\"\"))+1" % (col, ri, col, ri))
            c.font, c.border = base_font, BORDER
            c.alignment = Alignment(horizontal="center", vertical="top")
        extra = [r.get("slice", ""), r["rank"], r["tier"], r["minLevel"], r["chant"] if r["chant"] is not None else "ritual", r["element"],
                 rank_sheets.cls_names(r["classes"]), rank_sheets.cls_names(r["alt"]), r["minClassTier"].title()]
        sp_class_ids = [", ".join(r["classes"]), ", ".join(r["alt"])]
        for k, v in enumerate(extra):
            col_i = 17 + k
            c = sp.cell(row=ri, column=col_i, value=v)
            c.font, c.border = base_font, BORDER
            c.alignment = Alignment(horizontal="center", vertical="top", wrap_text=(col_i in (23, 24)))
        longest = max(len(r["desc"]), len(r["vis"]), len(r["how"]))
        sp.row_dimensions[ri].height = min(409, max(60, (longest // 68 + 1) * 13.5 + 6))
    sp.freeze_panes = "C2"
    sp.auto_filter.ref = "A1:%s%d" % (get_column_letter(len(headers)), len(recs) + 1)

    last = len(recs) + 1
    SP = "Spells!$%s$2:$%s$" + str(last)

    # ---------- Categories ----------
    ct = wb.create_sheet("Categories")
    hdr = ["Category", "Definition", "Default Targeting", "Spells", "Share"]
    for i, h in enumerate(hdr, 1):
        c = ct.cell(row=1, column=i, value=h)
        c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
        c.alignment = Alignment(horizontal="center", vertical="center", wrap_text=True)
    for ri, (name, definition, tgt) in enumerate(CATEGORIES, 2):
        ct.cell(row=ri, column=1, value=name).font = Font(name="Calibri", size=10, bold=True)
        ct.cell(row=ri, column=2, value=definition)
        ct.cell(row=ri, column=3, value=tgt)
        ct.cell(row=ri, column=4, value="=COUNTIF(%s,A%d)" % (SP % ("D", "D"), ri))
        ct.cell(row=ri, column=5, value="=D%d/$D$%d" % (ri, len(CATEGORIES) + 2)).number_format = "0.0%"
        for ci in range(1, 6):
            c = ct.cell(row=ri, column=ci)
            c.border = BORDER
            c.alignment = WRAP
            if ci != 1:
                c.font = base_font
        ct.row_dimensions[ri].height = 44
    tr = len(CATEGORIES) + 2
    ct.cell(row=tr, column=1, value="Total").font = Font(bold=True)
    ct.cell(row=tr, column=4, value="=SUM(D2:D%d)" % (tr - 1)).font = Font(bold=True)
    # matrix
    m0 = tr + 3
    ct.cell(row=m0 - 1, column=1, value="Spells by Discipline and Category").font = Font(name="Calibri", size=12, bold=True, color="1F2A44")
    ct.cell(row=m0, column=1, value="Discipline")
    for j, cn in enumerate(CAT_NAMES, 2):
        ct.cell(row=m0, column=j, value=cn)
    ct.cell(row=m0, column=len(CAT_NAMES) + 2, value="Total")
    for ci in range(1, len(CAT_NAMES) + 3):
        c = ct.cell(row=m0, column=ci)
        c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
        c.alignment = Alignment(horizontal="center", wrap_text=True)
    for i, d in enumerate(DISCIPLINES, 1):
        rr = m0 + i
        ct.cell(row=rr, column=1, value=d["name"]).font = Font(bold=True)
        ct.cell(row=rr, column=1).fill = PatternFill("solid", fgColor=HUES[d["code"]])
        for j in range(len(CAT_NAMES)):
            col = get_column_letter(j + 2)
            ct.cell(row=rr, column=j + 2, value="=COUNTIFS(%s,$A%d,%s,%s$%d)" % (SP % ("C", "C"), rr, SP % ("D", "D"), col, m0))
        ct.cell(row=rr, column=len(CAT_NAMES) + 2, value="=SUM(B%d:%s%d)" % (rr, get_column_letter(len(CAT_NAMES) + 1), rr))
        for ci in range(1, len(CAT_NAMES) + 3):
            ct.cell(row=rr, column=ci).border = BORDER
    rr = m0 + len(DISCIPLINES) + 1
    ct.cell(row=rr, column=1, value="Total").font = Font(bold=True)
    for j in range(len(CAT_NAMES) + 1):
        col = get_column_letter(j + 2)
        ct.cell(row=rr, column=j + 2, value="=SUM(%s%d:%s%d)" % (col, m0 + 1, col, rr - 1)).font = Font(bold=True)
    for ci in range(1, len(CAT_NAMES) + 3):
        ct.cell(row=rr, column=ci).border = BORDER
    ct.column_dimensions["A"].width = 18
    ct.column_dimensions["B"].width = 70
    ct.column_dimensions["C"].width = 22
    for j in range(4, len(CAT_NAMES) + 3):
        ct.column_dimensions[get_column_letter(j)].width = 13
    ct.freeze_panes = "A2"

    # ---------- Disciplines ----------
    ds = wb.create_sheet("Disciplines")
    hdr = ["Code", "Discipline", "Tagline", "Sub-Disciplines", "Visual Identity", "Works On", "Description", "Spells"]
    for i, h in enumerate(hdr, 1):
        c = ds.cell(row=1, column=i, value=h)
        c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
        c.alignment = Alignment(horizontal="center", vertical="center")
    for ri, d in enumerate(DISCIPLINES, 2):
        subs = sorted({r["sub"] for r in recs if r["disc"] == d["code"]})
        vals = [d["code"], d["name"], d["tagline"], ", ".join(subs), d["hue"], d["medium"], d["blurb"],
                "=COUNTIF(%s,B%d)" % (SP % ("C", "C"), ri)]
        for ci, v in enumerate(vals, 1):
            c = ds.cell(row=ri, column=ci, value=v)
            c.alignment, c.border, c.font = WRAP, BORDER, base_font
        ds.cell(row=ri, column=1).fill = PatternFill("solid", fgColor=HUES[d["code"]])
        ds.cell(row=ri, column=2).font = Font(name="Calibri", size=10, bold=True)
        ds.row_dimensions[ri].height = 62
    rr = len(DISCIPLINES) + 2
    ds.cell(row=rr, column=2, value="Total").font = Font(bold=True)
    ds.cell(row=rr, column=8, value="=SUM(H2:H%d)" % (rr - 1)).font = Font(bold=True)
    for col, w in zip("ABCDEFGH", (8, 16, 24, 26, 30, 20, 80, 9)):
        ds.column_dimensions[col].width = w
    ds.freeze_panes = "A2"

    # ---------- Source Crosswalk ----------
    cw = wb.create_sheet("Source Crosswalk")
    hdr = ["Source", "Original #", "Original Name", "New ID", "Name In Workbook", "Discipline", "Category", "Note"]
    for i, h in enumerate(hdr, 1):
        c = cw.cell(row=1, column=i, value=h)
        c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
        c.alignment = Alignment(horizontal="center")
    ri = 2
    for r in sorted((x for x in recs if x["src"] in (1, 2, 3)), key=lambda x: (x["src"], int(x["ref"]))):
        note = r.get("note", "")
        if r["src"] == 2:
            note = "Form of base spell '%s'." % r["family"]
        if r["src"] == 1:
            note = "Signature spell of family '%s'; original text kept and extended." % r["family"]
        if r["src"] == 3 and not note:
            note = "Placeholder note replaced with full description."
        vals = [SRC[r["src"]], r["ref"], r["orig"], r["id"], r["name"], DISC[r["disc"]]["name"], r["cat"], note]
        for ci, v in enumerate(vals, 1):
            c = cw.cell(row=ri, column=ci, value=v)
            c.font, c.border = base_font, BORDER
        ri += 1
    for col, w in zip("ABCDEFGH", (22, 11, 34, 11, 34, 15, 13, 60)):
        cw.column_dimensions[col].width = w
    cw.freeze_panes = "A2"
    cw.auto_filter.ref = "A1:H%d" % (ri - 1)

    # ---------- New Spells ----------
    ns = wb.create_sheet("New Spells")
    hdr = ["ID", "Spell Name", "Imagery Word", "Action Word", "Discipline", "Category", "Sub-Discipline", "Description"]
    for i, h in enumerate(hdr, 1):
        c = ns.cell(row=1, column=i, value=h)
        c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
        c.alignment = Alignment(horizontal="center")
    ri = 2
    for r in (x for x in recs if x["src"] == 4):
        vals = [r["id"], r["name"], r["imagery"], r["action"], DISC[r["disc"]]["name"], r["cat"], r["sub"], r["desc"]]
        for ci, v in enumerate(vals, 1):
            c = ns.cell(row=ri, column=ci, value=v)
            c.font, c.border, c.alignment = base_font, BORDER, WRAP
        ns.cell(row=ri, column=1).fill = PatternFill("solid", fgColor=HUES[r["disc"]])
        ns.row_dimensions[ri].height = 56
        ri += 1
    for col, w in zip("ABCDEFGH", (10, 28, 16, 13, 15, 13, 13, 90)):
        ns.column_dimensions[col].width = w
    ns.freeze_panes = "C2"
    ns.auto_filter.ref = "A1:H%d" % (ri - 1)

    feel_sheets.add_feel_sheets(wb, recs, DISC, HUES)
    rank_sheets.add_rank_sheets(wb, recs, MONS, SPECIES, DISC, HUES, last)
    wb.save(out)


MONS, SPECIES = [], []


def main():
    global MONS, SPECIES
    out = sys.argv[1] if len(sys.argv) > 1 else os.path.join(HERE, "..", "..", "05_Skills_Magic", "Aetheria_Spell_Codex.xlsx")
    recs, a_rows, b_ent, c_rows = build_records()
    problems = validate(recs)
    if problems:
        print("VALIDATION PROBLEMS:", len(problems))
        for p in problems[:30]:
            print(p)
        sys.exit(1)
    root = os.path.join(HERE, "..", "..")
    sp_path = os.path.join(root, "Data", "Monsters", "species.json")
    if os.path.exists(sp_path):
        SPECIES = json.load(open(sp_path, encoding="utf-8"))
        MONS = monster_spells.build(recs, sp_path)
    write_xlsx(recs, a_rows, b_ent, c_rows, out)
    if os.path.isdir(os.path.join(root, "Data")):
        rank_sheets.export_data(recs, MONS, os.path.join(root, "Data", "Spells"))
        print("wrote Data/Spells (spells.json, monster_spells.json)")
        rank_sheets.write_rank_doc(os.path.join(root, "05_Skills_Magic", "spell_ranks_and_classes.md"), recs, MONS, SPECIES)
    doc = os.path.join(HERE, "..", "..", "13_Production", "spell_look_and_feel.md")
    if os.path.isdir(os.path.dirname(doc)):
        feel_sheets.write_doc(doc, recs)
        print("wrote", os.path.abspath(doc))
    by_src = collections.Counter(r["src"] for r in recs)
    print("wrote", os.path.abspath(out))
    print("total", len(recs), dict(by_src))
    print("disciplines", dict(collections.Counter(r["disc"] for r in recs)))
    print("categories", dict(collections.Counter(r["cat"] for r in recs)))
    for f in ("desc", "vis", "how"):
        ws = [wc(r[f]) for r in recs]
        print(f, "words min/avg/max", min(ws), round(sum(ws) / len(ws), 1), max(ws))


if __name__ == "__main__":
    main()
