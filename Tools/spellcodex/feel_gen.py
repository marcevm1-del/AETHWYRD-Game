# -*- coding: utf-8 -*-
"""Generate the per-spell Look & Feel specification and the bible tables."""
import zlib, colorsys
from data_feel import D, C, F, SUB_KEY, MOTIF, CAT_MOTIF, HEAVY_FAMILIES, RULES, CHANT_TIERS, MASTERY_STEPS

HS = {"Light": 0.04, "Medium": 0.07, "Heavy": 0.11, "Launch": 0.08, "None": 0.0}
SHAKE = {"Light": 0.0, "Medium": 0.08, "Heavy": 0.18, "Launch": 0.08, "None": 0.0}
RX = {"Light": "flinch", "Medium": "stagger", "Heavy": "knockback or knockdown", "Launch": "airborne", "None": "none"}
RING = {"Strike": 1.2, "Barrage": 1.6, "Ward": 1.4, "Binding": 1.2, "Mobility": 1.0, "Sensing": 1.2, "Mending": 1.4,
        "Empowerment": 1.0, "Hex": 1.2, "Illusion": 1.0, "Pact": 1.8, "Utility": 0.8}
AURA_CATS = ("Strike", "Barrage", "Hex", "Binding")
REACT = {"Fire": "Fire + Wind Firestorm, + Ice Thermal Shock, + Earth Magma, + Nature Wildfire",
         "Water": "Water + Ice Freeze, + Lightning Storm Prison", "Wind": "Wind + any element Swirl",
         "Earth": "Earth + Fire Magma, + Lightning Grounded", "Ice": "Ice + Water Freeze, + Fire Thermal Shock",
         "Nature": "Nature + Fire Wildfire", "Light": "Light + Dark Twilight Burst", "Dark": "Dark + Light Twilight Burst"}
FORM_GROUPS = [
    ["Needlepoint", "Sweeping Arc", "Twin Cast", "Spiral Form", "Grounded Form", "Rising Form", "Echo Form"],
    ["Gentle Call", "Urgent Call", "Shared Guard", "Guiding Path", "Warning Sign", "Resonant Echo", "Parting Form"],
    ["Quiet Prayer", "Public Prayer", "Vigil Form", "Pilgrim Form", "Sanctuary Form", "Oathbound Form", "Last-Rite Form"],
    ["Space: Needle Fold", "Space: Wide Fold", "Time: Single Echo", "Time: Delayed Echo", "Void: Thin Edge", "Void: Quiet Field", "Fracture Form"],
]
PIPS = {f: i + 1 for g in FORM_GROUPS for i, f in enumerate(g)}
PIPS["Standard"] = 0
PIPS["Signature"] = -1


def _hex(h):
    h = h.lstrip("#")
    return tuple(int(h[i:i + 2], 16) / 255.0 for i in (0, 2, 4))


def _tohex(rgb):
    return "#%02X%02X%02X" % tuple(max(0, min(255, int(round(c * 255)))) for c in rgb)


def enemy_hex(h, shadow):
    """Dimmer enemy variant: lightness x0.85, saturation x0.7, then 25% toward the discipline shadow."""
    r, g, b = _hex(h)
    hh, ll, ss = colorsys.rgb_to_hls(r, g, b)
    rgb = colorsys.hls_to_rgb(hh, ll * 0.85, ss * 0.7)
    sh = _hex(shadow)
    return _tohex(tuple(rgb[i] * 0.75 + sh[i] * 0.25 for i in range(3)))


def _j(key, salt):
    return 0.9 + (zlib.crc32((key + salt).encode()) % 21) / 100.0


def _r05(x, lo=0.05):
    return max(lo, round(x * 20) / 20.0)


def _r1(x):
    return round(x * 10) / 10.0


def _r5(x):
    return int(round(x / 5.0) * 5)


def fx(n):
    return int(round(n * 60))


def compute(rec):
    key = rec["id"]
    d, c, f = D[rec["disc"]], C[rec["cat"]], F[rec["form"]]
    pal = list(d["pal"])
    names = list(d["names"])
    sub = rec["sub"]
    if rec["disc"] == "FBD":
        for pre in ("Space", "Time", "Void"):
            if rec["form"].startswith(pre + ":"):
                sub = pre
    if rec["disc"] == "FBD" and sub in SUB_KEY:
        pal[0], names[0] = SUB_KEY[sub][0], SUB_KEY[sub][1]
    rel = _r05(c["rel"] * d["rel"] * f["rel"] * _j(key, "r"))
    sustained = c["act"] >= 2.0
    act = c["act"] * f["act"] * _j(key, "a")
    act = round(act * 2) / 2.0 if sustained else _r05(act)
    recv = _r05(c["rec"] * (d["rel"] ** 0.5) * _j(key, "c"))
    spd = int(round(c["spd"] * d["spd"] * _j(key, "s"))) if c["spd"] else 0
    size = _r1(c["size"] * f["w"] * _j(key, "w")) if c["size"] >= 0.5 else round(c["size"] * f["w"] * _j(key, "w"), 2)
    rng = _r1(c["rng"] * f["rng"] * _j(key, "g"))
    weight = c["weight"]
    fam, form = rec["family"], rec["form"]
    if rec["cat"] == "Strike":
        if fam in HEAVY_FAMILIES or fam.split()[-1] in HEAVY_FAMILIES:
            weight = "Heavy"
        if form == "Sweeping Arc" or form == "Twin Cast":
            weight = "Light"
        if form == "Rising Form":
            weight = "Launch"
    if rec["cat"] == "Barrage" and form == "Rising Form":
        weight = "Launch"
    parts = _r5(c["parts"] * _j(key, "p") * (0.8 if form in ("Needlepoint", "Quiet Prayer") else 1.0))
    lr, li = c["light"]
    lr = _r1(lr * _j(key, "l")) if lr else 0
    li = round(li * _j(key, "i"), 1) if li else 0
    aura = d["aura"] if (d["aura"] and rec["cat"] in AURA_CATS) else ""
    motif = MOTIF.get(fam.split()[-1]) or MOTIF.get(fam) or CAT_MOTIF[rec["cat"]]
    return dict(d=d, c=c, f=f, pal=pal, names=names, rel=rel, act=act, rec=recv, spd=spd, size=size, rng=rng,
                weight=weight, parts=parts, lr=lr, li=li, aura=aura, motif=motif, sustained=sustained)


def spec(rec):
    v = compute(rec)
    d, c, f, pal, names = v["d"], v["c"], v["f"], v["pal"], v["names"]
    cat, form = rec["cat"], rec["form"]
    hs, sh = HS[v["weight"]], SHAKE[v["weight"]]
    ring = RING[cat]
    o = c["order"]
    # 1 pose and chant tell
    pose = "%s %s%s Chant tell: %s at the feet, %.1f m wide at Intermediate tier, drawn in %s at 60%% opacity." % (
        c["pose"], d["gesture"], (" " + f["pose"].rstrip(".") + ".") if f["pose"] else "", d["rune"], ring, names[1])
    # 2 timing
    cancel = _r05(0.35 * v["rec"])
    act_txt = "%.2f s (%d f)" % (v["act"], fx(v["act"])) if not v["sustained"] else "%.1f s%s" % (v["act"], " (until broken)" if cat in ("Ward", "Binding") else "")
    timing = ("After the chant (0.5 / 1.5 / 3 / 5 s by tier): Release %.2f s (%d f) -> Active %s -> Recovery %.2f s (%d f). "
              "Dodge-cancel opens %.2f s into recovery. A stagger during chant or release breaks the spell and plays the 0.4 s fizzle.") % (
        v["rel"], fx(v["rel"]), act_txt, v["rec"], fx(v["rec"]), cancel)
    # 3 shape, size and motion
    shape = c["shape"].format(w=v["size"], l=_r1(max(0.6, v["size"] * 10 if cat == "Strike" else v["size"] * 2)), s=v["spd"], r=v["rng"],
                              a=90 if form == "Sweeping Arc" else (30 if form == "Needlepoint" else 55),
                              pw=_r1(2.4 * f["w"]), ph=2.2, h=2.0, n=int(14 * (v["parts"] / 50 + 0.5)), t=v["act"], sz=_r1(v["size"] * 0.8 + 0.4))
    if form in F and F[form]["shape"]:
        shape += " " + f["shape"]
    shape += " Silhouette: %s. %s" % (v["motif"], d["shape"])
    motion = d["motion"] + ((" " + f["motion"]) if f["motion"] else "")
    # 4 palette and material
    emi = d["emi"]
    pal_txt = ("60%% %s %s . 30%% %s %s . 10%% %s %s . Emissive core %s at x%.1f. %s %s") % (
        names[o[0]], pal[o[0]], names[o[1]], pal[o[1]], names[o[2]], pal[o[2]], pal[4], emi, d["material"], d["note"])
    pal_txt = pal_txt.replace(" .", " ·")
    # 5 vfx build
    light = "no light" if not v["lr"] else "1 point light (range %.1f m, intensity %.1f, %s)" % (v["lr"], v["li"], pal[0])
    vfx = ("%s Budget: up to %d particles, %s, %d distortion quad%s, 1 decal. LOD: budget halves beyond 25 m; only the core sprite and light remain beyond 50 m." %
           (c["vfx"], v["parts"], light, c["dist"], "" if c["dist"] == 1 else "s"))
    # 6 impact
    impact = c["impact"].format(wt=v["weight"], hs=hs, sh=sh, rx=RX[v["weight"]])
    if v["aura"]:
        impact += " On hit: %s aura for 6 s (%s)." % (v["aura"], REACT[v["aura"]])
    if rec["disc"] == "FBD":
        impact += " Weave scar left at the spot."
    # 7 audio
    audio = "Cast: %s rising across the %.2f s release. Active: %s at %d dB. Impact: %s, layered with the target's material hit. Category voice: %s%s" % (
        d["sfx"][0], v["rel"], d["sfx"][1], d["body_db"], d["sfx"][2], c["cat_audio"], (" " + f["audio"]) if f["audio"] else "")
    # 8 aftermath
    after = d["after"] + " " + c["cat_after"].format(sz=_r1(v["size"] * 0.8 + 0.4))
    # 9 readability, telegraph and icon
    pips = PIPS.get(form, 0)
    pip_txt = "no pips" if pips == 0 else ("a star pip" if pips < 0 else "%d form pip%s" % (pips, "" if pips == 1 else "s"))
    ek, em, ea = (enemy_hex(pal[o[0]], pal[2]), enemy_hex(pal[o[1]], pal[2]), enemy_hex(pal[o[2]], pal[2]))
    read = ("Hostile cast: %s Enemy variant: %s / %s / %s, emission x0.6, no white-hot core; the telegraph stays full brightness on top. Player cast: no telegraph. Silhouette test: reads as %s at 25%% size. Icon: %s, glyph is %s, two-tone %s / %s, 2 px outline at x0.35, %s in the corner." % (
        c["tele"], ek, em, ea, c["read"], c["icon"], v["motif"], pal[0], pal[2], pip_txt))
    return dict(
        release=v["rel"], active=v["act"], recovery=v["rec"], weight=v["weight"], hitstop=hs, shake=sh,
        aura=v["aura"] or "-", range=v["rng"], size=v["size"], key=pal[o[0]], mid=pal[o[1]], accent=pal[o[2]], core=pal[4], ekey=ek, emid=em, eaccent=ea,
        parts=v["parts"], light=("none" if not v["lr"] else "%.1f m / %.1f" % (v["lr"], v["li"])),
        pose=pose, timing=timing, shape=shape, motion=motion, palette=pal_txt, vfx=vfx, impact=impact, audio=audio,
        after=after, read=read)


REACTIONS = [
    ("Firestorm", "Fire + Wind", "A spinning fire tornado 2.5 m tall and 1.8 m wide, orange with cream sparks, lasting 3 s with a damage tick every 0.5 s.", "#FF8A3D / #FFF0C8", "Roar plus whoosh; shake 0.08 on spawn."),
    ("Storm Prison", "Water + Lightning", "Six pale arcs cage the target in a rotating ring, teal base with violet-white arcs (never telegraph blue); a chain flash jumps to the nearest enemy.", "#5CC9B8 / #E4DCFF", "Crackle plus water hiss; 0.07 s hit-stop on stun."),
    ("Freeze", "Water + Ice", "The target is wrapped in a translucent ice shell (0.7 opacity) for the freeze time; the next Heavy hit shatters it into 16 shards.", "#8FD3F0 / #E8F4FA", "Glass lock then a crunch; shatter is Heavy: 0.11 s hit-stop."),
    ("Thermal Shock", "Fire + Ice", "A 3 m ring shockwave that shifts from white-orange to ice-blue; both aura rims burst outward as motes. The only reaction that uses a 1-frame white impact frame at this tier.", "#FF8A3D / #8FD3F0", "Hard crack and a steam hiss; Heavy hit-stop."),
    ("Magma", "Earth + Fire", "A 2 m pool of dark rock with glowing orange cracks and slow bubbles; the hazard lasts 8 s and cools to grey over the last 2 s.", "#C98C3E / #E8692C", "Low bubbling rumble; no hit-stop."),
    ("Swirl", "Wind + any element", "A spiral ribbon of wind carries the source element's colour from the target to every enemy within 4 m over 0.6 s and leaves a fresh aura on each.", "#9ED8B8 + source colour", "Rising whistle; no hit-stop."),
    ("Wildfire", "Nature + Fire", "Six flame lines creep through grass at 3 m/s, the grass blackens behind them and leaves drift as ash; stops at bare ground or water.", "#5FB35A / #FF8A3D", "Crackling spread; no hit-stop."),
    ("Twilight Burst", "Light + Dark", "Rose-lavender light and ink-violet dark spiral into a 1.2 m sphere over 0.25 s, then burst as a ring with a full impact frame. Rare and late game.", "#FFF1C9 / #4A2F7A", "Choir and sub drone collide; Ultimate tier: 0.18 s hit-stop and shake 0.40."),
    ("Miasma Blast", "Poison + Fire", "A sickly olive-green burst (#8FB94A) leaves a fog of radius 2.5 m for 5 s that drifts slowly upward.", "#8FB94A / #FF8A3D", "Wet pop and a long hiss; Medium hit-stop."),
    ("Grounded", "Lightning + Earth", "Pale violet-white arcs flow into the ground and end in an amber dust ring; the target shows a slow icon and its feet sink 0.05 m.", "#E4DCFF / #C98C3E", "Zap into a thud; Light hit-stop."),
]
