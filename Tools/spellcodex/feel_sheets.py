# -*- coding: utf-8 -*-
"""Excel sheets and the design document for the spell look-and-feel system."""
import os
from data_core import DISCIPLINES, CAT_NAMES
from data_feel import D, C, F, RULES, CHANT_TIERS, MASTERY_STEPS, CAT_MOTIF
from feel_gen import spec, REACTIONS, PIPS, FORM_GROUPS
from slice_data import SLICE


def _lum(h):
    h = h.lstrip("#")
    r, g, b = (int(h[i:i + 2], 16) for i in (0, 2, 4))
    return 0.299 * r + 0.587 * g + 0.114 * b


def add_feel_sheets(wb, recs, DISC, HUES):
    from openpyxl.styles import Font, PatternFill, Alignment, Border, Side
    from openpyxl.utils import get_column_letter
    HDR_FILL = PatternFill("solid", fgColor="1F2A44")
    HDR_FONT = Font(bold=True, color="FFFFFF", name="Calibri", size=11)
    thin = Side(style="thin", color="C9CDD6")
    BORDER = Border(left=thin, right=thin, top=thin, bottom=thin)
    WRAP = Alignment(wrap_text=True, vertical="top")
    base = Font(name="Calibri", size=10)

    def header(ws, cols, widths):
        for i, (h, w) in enumerate(zip(cols, widths), 1):
            c = ws.cell(row=1, column=i, value=h)
            c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
            c.alignment = Alignment(wrap_text=True, vertical="center", horizontal="center")
            ws.column_dimensions[get_column_letter(i)].width = w
        ws.row_dimensions[1].height = 32
        ws.freeze_panes = "B2"

    def put(ws, r, c, v, bold=False, swatch=False):
        cell = ws.cell(row=r, column=c, value=v)
        cell.alignment, cell.border = WRAP, BORDER
        cell.font = Font(name="Calibri", size=10, bold=bold)
        if swatch and isinstance(v, str) and v.startswith("#"):
            cell.fill = PatternFill("solid", fgColor=v.lstrip("#"))
            cell.font = Font(name="Calibri", size=10, bold=True, color="000000" if _lum(v) > 140 else "FFFFFF")
            cell.alignment = Alignment(horizontal="center", vertical="center")
        return cell

    # ---------------- Feel Rules ----------------
    ws = wb.create_sheet("Feel Rules")
    header(ws, ["Rule", "Specification", "Source"], [26, 120, 28])
    for i, (a, b, c) in enumerate(RULES, 2):
        put(ws, i, 1, a, True); put(ws, i, 2, b); put(ws, i, 3, c)
        ws.row_dimensions[i].height = max(30, (len(b) // 125 + 1) * 14 + 6)

    # ---------------- Chant Tiers ----------------
    ws = wb.create_sheet("Chant Tiers")
    header(ws, ["Tier", "Chant time (canon)", "Ring size x", "Glyphs", "VFX scale x", "What the player sees"], [22, 22, 12, 9, 12, 100])
    for i, (t, ct, rs, gl, vs, ex) in enumerate(CHANT_TIERS, 2):
        for j, v in enumerate((t, ct, rs, gl, vs, ex), 1):
            put(ws, i, j, v, j == 1)
    r0 = len(CHANT_TIERS) + 4
    ws.cell(row=r0 - 1, column=1, value="Mastery steps (visual)").font = Font(bold=True, size=12, color="1F2A44")
    for j, h in enumerate(["Step", "Visual", "Chant time"], 1):
        c = ws.cell(row=r0, column=j, value=h)
        c.fill, c.font, c.border = HDR_FILL, HDR_FONT, BORDER
    for i, (a, b, c2) in enumerate(MASTERY_STEPS, r0 + 1):
        put(ws, i, 1, a, True); put(ws, i, 2, b); put(ws, i, 3, c2)
    ws.cell(row=r0 + 7, column=1, value="Every per-spell value in 'Look & Feel' is authored at the Intermediate tier; at runtime scale ring size and VFX by the factors above.").font = Font(italic=True, size=10)

    # ---------------- Feel Disciplines ----------------
    ws = wb.create_sheet("Feel Disciplines")
    cols = ["Code", "Discipline", "Key", "Mid", "Shadow", "Accent", "Core", "Colour names", "Chant ring glyph", "Gesture",
            "Release tempo x", "Speed x", "Element aura", "Shape language", "Motion language", "Material", "Cast sound", "Body loop", "Impact sound",
            "Aftermath", "Rule of thumb"]
    header(ws, cols, [7, 15, 10, 10, 10, 10, 10, 30, 34, 34, 9, 8, 10, 40, 48, 48, 28, 28, 30, 44, 48])
    for i, dd in enumerate(DISCIPLINES, 2):
        x = D[dd["code"]]
        vals = [dd["code"], dd["name"]] + list(x["pal"]) + [", ".join(x["names"]), x["rune"], x["gesture"], x["rel"], x["spd"],
                                                            x["aura"] or "-", x["shape"], x["motion"], x["material"], x["sfx"][0], x["sfx"][1], x["sfx"][2], x["after"], x["note"]]
        for j, v in enumerate(vals, 1):
            put(ws, i, j, v, j == 2, swatch=(3 <= j <= 7))
        ws.cell(row=i, column=1).fill = PatternFill("solid", fgColor=HUES[dd["code"]])
        ws.row_dimensions[i].height = 110

    # ---------------- Feel Categories ----------------
    ws = wb.create_sheet("Feel Categories")
    cols = ["Category", "Release (s)", "Active (s)", "Recovery (s)", "Range (m)", "Size (m)", "Speed (m/s)", "Hit weight", "Particle budget",
            "Light (range m / intensity)", "Icon frame", "Silhouette", "Cast pose", "Shape template", "VFX core", "Camera", "Enemy telegraph",
            "Impact and feedback", "Audio voice", "60/30/10 palette order (key, mid, shadow, accent, core)"]
    header(ws, cols, [13, 9, 9, 10, 9, 8, 9, 10, 10, 14, 20, 11, 42, 50, 56, 30, 40, 56, 36, 24])
    pal_idx = ["key", "mid", "shadow", "accent", "core"]
    for i, cn in enumerate(CAT_NAMES, 2):
        c = C[cn]
        light = "none" if not c["light"][0] else "%s m / %s" % c["light"]
        vals = [cn, c["rel"], c["act"], c["rec"], c["rng"], c["size"], c["spd"], c["weight"], c["parts"], light, c["icon"], c["read"], c["pose"],
                c["shape"], c["vfx"], c["cam"], c["tele"], c["impact"], c["cat_audio"], " / ".join(pal_idx[k] for k in c["order"])]
        for j, v in enumerate(vals, 1):
            put(ws, i, j, v, j == 1)
        ws.row_dimensions[i].height = 105

    # ---------------- Feel Forms ----------------
    ws = wb.create_sheet("Feel Forms")
    header(ws, ["Form", "Group", "Pips", "Release x", "Active x", "Size x", "Range x", "Shape", "Motion", "Audio", "Pose"], [20, 12, 6, 9, 9, 8, 8, 60, 48, 40, 40])
    groups = {}
    for gi, g in enumerate(("Aethercraft and the elements", "Spiritbond", "Divine", "Forbidden Arts")):
        for f in FORM_GROUPS[gi]:
            groups[f] = g
    r = 2
    for f in ["Standard", "Signature"] + [x for g in FORM_GROUPS for x in g]:
        m = F[f]
        vals = [f, groups.get(f, "Any"), PIPS[f], m["rel"], m["act"], m["w"], m["rng"], m["shape"], m["motion"], m["audio"], m["pose"]]
        for j, v in enumerate(vals, 1):
            put(ws, r, j, v, j == 1)
        ws.row_dimensions[r].height = 48
        r += 1

    # ---------------- Reactions VFX ----------------
    ws = wb.create_sheet("Reactions VFX")
    header(ws, ["Reaction", "Aura + trigger", "Look", "Colours", "Sound and feedback"], [18, 22, 100, 24, 52])
    for i, row in enumerate(REACTIONS, 2):
        for j, v in enumerate(row, 1):
            put(ws, i, j, v, j == 1)
        ws.row_dimensions[i].height = 48

    # ---------------- Look & Feel (per spell) ----------------
    ws = wb.create_sheet("Look & Feel")
    cols = ["ID", "Spell Name", "Discipline", "Category", "Form / Variant", "Release (s)", "Active (s)", "Recovery (s)", "Hit Weight", "Hit-stop (s)",
            "Shake", "Element Aura", "Range (m)", "Size (m)", "Key", "Mid", "Accent", "Core", "Enemy Key", "Enemy Mid", "Enemy Accent", "Particle Budget", "Light (m / intensity)",
            "Cast Pose and Chant Tell", "Timing and Cancel", "Shape, Size and Silhouette", "Motion", "Palette and Material", "VFX Build (Unity URP)",
            "Impact and Feedback", "Audio", "Aftermath", "Readability, Telegraph and Icon"]
    widths = [10, 26, 14, 12, 16, 8, 8, 9, 9, 8, 7, 9, 8, 8, 10, 10, 10, 10, 10, 10, 10, 9, 13, 52, 52, 56, 44, 62, 58, 52, 52, 40, 58]
    header(ws, cols, widths)
    for ri, r in enumerate(recs, 2):
        s = spec(r)
        vals = [r["id"], r["name"], DISC[r["disc"]]["name"], r["cat"], r["form"], s["release"], s["active"], s["recovery"], s["weight"], s["hitstop"],
                s["shake"], s["aura"], s["range"], s["size"], s["key"], s["mid"], s["accent"], s["core"], s["ekey"], s["emid"], s["eaccent"], s["parts"], s["light"],
                s["pose"], s["timing"], s["shape"], s["motion"], s["palette"], s["vfx"], s["impact"], s["audio"], s["after"], s["read"]]
        longest = 0
        for j, v in enumerate(vals, 1):
            cell = put(ws, ri, j, v, j == 2, swatch=(15 <= j <= 21))
            if j >= 24:
                longest = max(longest, len(v) / (widths[j - 1] * 1.15))
        ws.cell(row=ri, column=1).fill = PatternFill("solid", fgColor=HUES[r["disc"]])
        ws.row_dimensions[ri].height = min(409, max(60, (int(longest) + 1) * 13.2 + 6))
    ws.freeze_panes = "C2"
    ws.auto_filter.ref = "A1:%s%d" % (get_column_letter(len(cols)), len(recs) + 1)

    # ---------------- Vertical Slice ----------------
    ws = wb.create_sheet("Vertical Slice")
    cols = ["Wave", "ID", "Spell Name", "Discipline", "Category", "Rank", "Tier", "Primary Classes", "VFX Size", "Release (s)", "Hit Weight", "Element Aura",
            "Key", "Enemy Key", "Enemy-cast test", "What it proves", "Signature moment"]
    header(ws, cols, [7, 10, 28, 14, 12, 6, 13, 26, 9, 9, 10, 10, 10, 10, 12, 70, 80])
    SIZE = {"Strike": "S", "Barrage": "L", "Ward": "M", "Binding": "M", "Mobility": "M", "Sensing": "M", "Mending": "S", "Empowerment": "S",
            "Hex": "S", "Illusion": "L", "Pact": "L", "Utility": "S"}
    ENEMY = {"Strike", "Barrage", "Binding", "Hex", "Illusion", "Pact"}
    sl = sorted([r for r in recs if r.get("slice")], key=lambda r: (r["slice"], r["id"]))
    for i, r in enumerate(sl, 2):
        sp_ = spec(r)
        vals = [r["slice"], r["id"], r["name"], DISC[r["disc"]]["name"], r["cat"], r["rank"], r["tier"],
                ", ".join(x.replace("cls_", "").replace("_", " ").title() for x in r["classes"]), SIZE[r["cat"]], sp_["release"], sp_["weight"], sp_["aura"],
                sp_["key"], sp_["ekey"], "Yes" if r["cat"] in ENEMY else "No", SLICE[r["name"]][1], r.get("moment", "")]
        for j, v in enumerate(vals, 1):
            put(ws, i, j, v, j == 3, swatch=(j in (13, 14)))
        ws.cell(row=i, column=2).fill = PatternFill("solid", fgColor=HUES[r["disc"]])
        ws.row_dimensions[i].height = 44
    ws.auto_filter.ref = "A1:Q%d" % (len(sl) + 1)
    ws.freeze_panes = "D2"


DISC_NAME = {d['code']: d['name'] for d in DISCIPLINES}


def write_doc(path, recs):
    L = []
    a = L.append
    a("# Spell Look and Feel Bible")
    a("")
    a("> **Owner:** anime-fantasy-director with the combat-designer, technical-artist and audio-designer. **Status:** PROPOSED v1, 2026-11-03, not locked Canon. Every number is a tunable proposal; the hit-stop and shake tiers are the existing values in `Data/Combat/combat_tuning.json`. The per-spell values are in `05_Skills_Magic/Aetheria_Spell_Codex.xlsx`, sheet **Look & Feel** (%d spells); this page is the rulebook behind them." % len(recs))
    a("> **Builds on:** [[art_direction]] (toon shader, reserved colours, 60/30/10, bloom) · [[combat]] (hit weight, telegraphs, element auras) · [[skills_and_magic]] (chant time by tier).")
    a("")
    a("## 1. The five-beat spell")
    a("")
    a("Every spell has **Source, Chant tell, Release, Active, Recovery**, then a short **Afterglow**. The player must be able to read the beat they are in from shape, sound and motion, never from colour alone. Chant time comes from the tier (0.5 / 1.5 / 3 / 5 s); the per-spell **Release, Active and Recovery** are what the sheet gives, authored at the Intermediate tier.")
    a("")
    a("## 2. Global rules")
    a("")
    a("| Rule | Specification |")
    a("|---|---|")
    for r_, b_, c_ in RULES:
        a("| **%s** | %s |" % (r_, b_))
    a("")
    a("## 3. Chant tells by tier and mastery")
    a("")
    a("| Tier | Chant | Ring size | Glyphs | VFX scale | Notes |")
    a("|---|---|---|---|---|---|")
    for t, ct, rs, gl, vs, ex in CHANT_TIERS:
        a("| %s | %s | x%.1f | %d | x%.1f | %s |" % (t, ct, rs, gl, vs, ex))
    a("")
    a("| Mastery step | Visual | Chant time |")
    a("|---|---|---|")
    for x, y, z in MASTERY_STEPS:
        a("| %s | %s | %s |" % (x, y, z))
    a("")
    a("## 4. The twelve disciplines")
    a("")
    a("| Discipline | Key / Mid / Shadow / Accent / Core | Chant ring | Tempo (release x, speed x) | Signature motion | Cast sound |")
    a("|---|---|---|---|---|---|")
    for dd in DISCIPLINES:
        x = D[dd["code"]]
        a("| **%s** | `%s` | %s | %.2f, %.2f | %s | %s |" % (dd["name"], "` `".join(x["pal"]), x["rune"], x["rel"], x["spd"], x["motion"], x["sfx"][0]))
    a("")
    a("Per-discipline shape language, materials, aftermath and rules of thumb are in the workbook sheet **Feel Disciplines**.")
    a("")
    a("## 5. The twelve categories")
    a("")
    a("| Category | Release / Active / Recovery (s) | Range, size | Hit weight | Silhouette | Enemy telegraph |")
    a("|---|---|---|---|---|---|")
    for cn in CAT_NAMES:
        c = C[cn]
        a("| **%s** | %.2f / %.2f / %.2f | %.0f m, %.2f m | %s | %s (%s) | %s |" % (cn, c["rel"], c["act"], c["rec"], c["rng"], c["size"], c["weight"], c["read"], c["icon"], c["tele"]))
    a("")
    a("## 6. Forms")
    a("")
    a("A form modifies the base spell's shape, motion, sound and pose; it never changes the discipline's palette. Pips in the icon corner count the form (1 to 7); signature spells carry a star pip.")
    a("")
    a("| Form | Shape change |")
    a("|---|---|")
    for g in FORM_GROUPS:
        for f in g:
            a("| %s | %s |" % (f, F[f]["shape"]))
    a("")
    a("## 7. Element reactions: VFX")
    a("")
    a("| Reaction | Trigger | Look | Colours | Sound and feedback |")
    a("|---|---|---|---|---|")
    for row in REACTIONS:
        a("| **%s** | %s | %s | %s | %s |" % row)
    a("")
    a("## 8. Unity implementation notes")
    a("")
    a("- One prefab per spell family under `Game/Assets/_Game/Art/VFX/Spells/<Discipline>/<Category>/`, named `VFX_<SpellID>_<Name>`; forms are variant prefabs that override size, timing and the extra shape.")
    a("- Effect shaders: the `Ascend/Toon` two-tone for solid meshes, an additive unlit sprite shader for glow and motes, a refraction quad shader for Aethercraft, Tidecraft and Forbidden only. Particles and water carry no outline.")
    a("- Drive timing from data, not from the prefab: release, active and recovery come from a future `Data/Spells/spell_feel.json` (columns match the first 20 columns of the Look & Feel sheet), so feel can be tuned without code, the same way `combat_tuning.json` works.")
    a("- Hit feedback calls the existing hit-stop and shake tiers by weight name; a spell never carries its own hit-stop number.")
    a("- Test on three backdrops (sunlit grass, dark cave, night town) and in greyscale at 25% size before sign-off; keep the five-concurrent-spells budget under 2.0 ms GPU.")
    a("")
    a("## 9. Owner decisions (2026-11-03)")
    a("")
    a("1. **Hostile spells use a dimmer enemy variant.** Lightness x0.85, saturation x0.7, 25% mixed toward the discipline shadow colour, emission x0.6, no white-hot core, outlines at x0.25, particles x0.8, cast sound pitched down 2 semitones. The telegraph keeps full brightness on top. Per-spell enemy hexes are in the Look & Feel sheet (Enemy Key, Mid, Accent).")
    a("2. **Divine and Radiance may pulse during rituals.** Only the chant ring, charge-up and ritual: 0.5 Hz, +/-15% emission, ivory, rose or amber-peach, never gold, never during the Active phase of an enemy cast. Telegraph pulses are 3 Hz or faster, so they cannot be confused.")
    import collections as _c
    _sl = [x for x in recs if x.get("slice")]
    _w = _c.Counter(x["slice"] for x in _sl)
    _cat = _c.Counter(x["cat"] for x in _sl)
    a("3. **First vertical slice: %d spells** (4 to 5 per discipline, text hand-written), listed below and in the sheet **Vertical Slice**. Wave 1 (%d spells, one per discipline) proves the pipeline; wave 2 (%d) and wave 3 (%d) fill it out. Category spread: %s. It covers the Ring 0 Firestorm pair (Cinder Fang + Tempest Fan), Freeze (Undertow Snare + Glacier Lock), Twilight Burst (Sunveil Blur with Gloamstep Shift or Duskbind Chain), Wildfire (Seedshot Volley with any Fire spell), and the Spiritbond and Divine refusal feel." % (
        len(_sl), _w[1], _w[2], _w[3], ", ".join("%s %d" % (k, _cat[k]) for k in CAT_NAMES)))
    a("")
    a("| Wave | Spell | Discipline | Category | Rank | What it proves | Signature moment |")
    a("|---|---|---|---|---|---|---|")
    for r in sorted([x for x in recs if x.get("slice")], key=lambda x: (x["slice"], x["id"])):
        a("| %d | **%s** | %s | %s | %s | %s | %s |" % (r["slice"], r["name"], DISC_NAME[r["disc"]], r["cat"], r["rank"], SLICE[r["name"]][1], r.get("moment", "")))
    a("")
    with open(path, "w", encoding="utf-8") as fh:
        fh.write("\n".join(L) + "\n")
