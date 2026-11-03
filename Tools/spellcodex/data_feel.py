# -*- coding: utf-8 -*-
"""Spell look-and-feel specification tables.

Built on the project's own rules:
  * 12_Systems/combat.md and Data/Combat/combat_tuning.json  (hit-stop tiers, shake, telegraph colours, auras)
  * 13_Production/art_direction.md                            (toon shader, bloom, outline, reserved colours, 60/30/10)
  * 05_Skills_Magic/skills_and_magic.md                       (chant time by tier)
All numbers are PROPOSED and tunable (marked in the sheets); none changes Canon.
"""

# ----------------------------------------------------------------------------- global rules
CHANT_TIERS = [
    # tier, canon chant time, ring diameter scale, glyph count, VFX scale, extra
    ("Basic (F-E)", "0.5 s", 0.6, 1, 0.6, "Single glyph at the hand; no ring on the ground."),
    ("Intermediate (D-C)", "1.5 s", 1.0, 2, 1.0, "Baseline: every per-spell value in the Look & Feel sheet is authored at this tier."),
    ("Advanced (B-A)", "3 s", 1.4, 3, 1.4, "Full ring plus an outer ring that turns the other way; caster hair and cloth lift."),
    ("Grand (S)", "5 s", 1.8, 4, 1.8, "Ring, outer ring and a vertical glyph column 3 m tall; ambient light dims 15% while charging."),
    ("Forbidden (SS)", "8 s + Aether Saturation", 2.2, 5, 2.0, "Ring cracks outward in steps; world desaturates 20% in 6 m; sound lowpasses at 1.2 kHz."),
    ("Divine (SSS)", "Ritual / Devotion", 2.0, 6, 1.8, "No chant timer: the ring opens as the ritual is performed and closes only when answered."),
]

MASTERY_STEPS = [
    ("Full chant", "Full ring, every glyph, voice speaks the whole verse.", "100% of tier chant time"),
    ("Short chant", "Two glyphs, ring at 70% diameter, voice speaks the last line only.", "about 60% of tier chant time"),
    ("Skill name only", "One glyph at the hand, 0.3 m wide, the spell name spoken once.", "about 25% of tier chant time"),
    ("Chantless", "No ring and no glyph: a 0.2 s hand glow in the discipline's mid colour, no voice.", "none (release only)"),
]

RULES = [
    ("Spell lifecycle", "Source -> Chant tell -> Release -> Active -> Recovery -> Afterglow. Every spell shows all five; the tell is never colour alone (shape, sound and motion also change).", "combat.md section 13"),
    ("Chant interrupt", "A stagger during chant or release shatters the ring into 12 shards over 0.25 s, plays a glass tick, then a 0.4 s fizzle puff in the discipline's mid colour. No damage VFX is spawned.", "Canon: staggered chants break"),
    ("Reserved colours", "Telegraph blue #3DA5FF, red #FF3B30 and gold #FFC93C, quest gold #FFD34D, interaction cyan #7FE3FF and the rank colours may not be a spell's dominant colour and never pulse in a spell. Spell effects flicker (noise) or glow steady; only telegraphs pulse.", "art_direction.md 2.6"),
    ("Hostile casts", "Any spell cast by an enemy adds the shared telegraph on top of its own VFX: blue circle (parryable), red triangle (unblockable), gold square (grab), none for chip effects. Player casts never show a telegraph.", "combat.md section 5"),
    ("Value and saturation", "Spell body S 25-60%; accent S 70-90%; above 90% only for the emissive core. No pure black or pure white: darkest #14102A, lightest #FFFBEA. Shadows lean violet-blue, lights warm.", "art_direction.md 2.3-2.5"),
    ("60 / 30 / 10", "Every spell is 60% one palette colour, 30% a second, 10% an accent, plus an emissive core. The order depends on category (see Feel Categories).", "art_direction.md 2.2"),
    ("Toon shading", "Effect meshes use the Ascend/Toon two-tone shader: hard terminator (_ShadowStep 0.5, softness 0.06), shadow tint 0.58/0.56/0.78. Particles, smoke and water have no outline. Solid constructs (walls, crystals, constructs) get a 1.5 px outline at the local colour x 0.35.", "art_direction.md 3"),
    ("Bloom and emission", "Bloom threshold 1.0, intensity 0.4, only on emissives. Magic emission 2.0, ember 2.5, spirit and blossom 1.5. A lit pixel keeps at least 50% saturation and stays within 15 degrees of its palette key; a white-hot centre is a failed render.", "art_direction.md 3 and 3.1"),
    ("Hit-stop tiers", "Light 0.04 s, Medium 0.07 s, Heavy 0.11 s, Launch 0.08 s, Ultimate 0.18 s plus an impact frame. Shake: Light 0, Medium 0.08, Heavy 0.18, Launch 0.08, Ultimate 0.40, decaying over 0.25 s. Spells use these tiers and never invent their own.", "combat_tuning.json"),
    ("Hit feedback checklist", "Hit-stop, 1-frame white hit flash on the target, impact VFX at the contact point, layered sound (cast + impact + material), damage number, reaction animation, controller rumble. Non-damaging spells replace hit-stop with an application flash on the target.", "combat.md section 11"),
    ("Element aura", "Fire, Water, Wind, Earth, Ice, Nature, Light and Dark spells that hit leave a 6 s element aura on the target: a thin rim glow plus 6 orbiting motes in the aura colour at 40% opacity. A second element during the aura triggers the matching reaction (sheet Reactions VFX).", "combat_tuning.json reactions"),
    ("Camera", "No spell moves the camera except through the shake tiers above, a 3 degree FOV kick on Mobility (0.3 s), and a 15% world desaturation while Sensing is active. Effects must never cover the player character or the lock-on target for more than 0.3 s.", "combat.md section 13"),
    ("Readability", "Greyscale and 25% size test: the spell's category must still read from its silhouette alone (bolt, cone, dome, line, trail, ring, motes, tag, ghost, spirit, marker).", "art_direction.md pillars"),
    ("Accessibility", "A reduced-effects setting halves particle counts, removes distortion quads and screen desaturation, keeps every telegraph shape and sound, and replaces flicker with steady glow.", "proposed"),
    ("Performance", "Per spell: at most 1 point light, 2 distortion quads, 1 decal projector and the particle budget in the sheet. At 25 m the budget halves; at 50 m only the core sprite and the light remain. Five concurrent spells must stay inside 2.0 ms GPU.", "proposed"),
    ("Refusal and failure", "Spiritbond and Divine spells that are declined never flash red or buzz: the effect dims over 1.0-1.2 s and drifts away with a soft descending note. Failure must feel like a quiet no, not a punishment.", "proposed"),
    ("Forbidden consequence", "Forbidden casts leave a hairline Weave-scar decal for 30 s that other casters can read. It is a visual consequence only; player-facing text never explains it (designer spoiler).", "Canon: frays the Weave"),
]

# ----------------------------------------------------------------------------- discipline feel
D = {}
D["AET"] = dict(
    names=("indigo", "cyan", "deep indigo", "silver", "ice-white"),
    pal=("#4E55D8", "#5BC8E8", "#2A2F80", "#D5DCEE", "#E9F7FF"),
    rune="a hexagonal grid ring with six node glyphs",
    gesture="Drawn with two fingers in precise, economical geometry.",
    rel=1.0, spd=1.0, aura="",
    shape="Thin straight lines, polyhedra and folded planes; hard 30/60/90 degree angles; always symmetric.",
    motion="Locks into place with a 2-frame overshoot, then holds perfectly still; it never wobbles or flickers.",
    material="Unlit toon glass: 0.3 opacity planes with 2 px scribed edge lines at emission 2.0; refraction quads only on Lens and Mirror spells.",
    sfx=("glass-harmonica swell", "steady sine hum at A4", "struck-crystal tick with a 0.8 s shimmer tail"),
    after="Silver grid lines linger on nearby surfaces for 1.0 s, then vanish. No decal.",
    note="Cyan is steady only: it is never pulsed, so it cannot be mistaken for the interaction-cyan markers; the hex-grid texture is its signature.",
    emi=2.0, body_db=-14)
D["FLM"] = dict(
    names=("ember orange", "deep ember", "soot umber", "pale cream-gold", "warm cream"),
    pal=("#FF8A3D", "#E8692C", "#5A2A1E", "#FFD9A0", "#FFF0C8"),
    rune="a triangle-spiral ring with three flame glyphs",
    gesture="Starts with a flint-snap of the fingers or a palm strike.",
    rel=1.0, spd=1.05, aura="Fire",
    shape="Teardrops and upward-curling flame tongues; asymmetric, widest at the base.",
    motion="Ignites in 3 frames, then flickers with noise at 6-9 Hz (never a regular pulse); embers rise at 0.8 m/s.",
    material="Additive flipbook flame (8x8 sheet, 24 fps), hard two-tone smoke from soot umber to deep ember, emission 2.5 (ember rule).",
    sfx=("ignition whump with rising crackle", "low fire-roar bed", "dull thump with ember pops"),
    after="Scorch decal (soot, 0.6-1.4 m) fades over 12 s; embers hang for 3 s; dry flammable props catch.",
    note="Flame flickers but never pulses on a beat: red and gold pulses belong to telegraphs.",
    emi=2.5, body_db=-12)
D["TID"] = dict(
    names=("sea teal", "sea green", "deep tide blue", "pearl", "foam white"),
    pal=("#2BA5A8", "#5CC9B8", "#1B4F6B", "#EAF6F2", "#D8FFF4"),
    rune="concentric wave rings with three ripple glyphs",
    gesture="Flowing wrist rolls, as if turning a bowl of water.",
    rel=1.0, spd=1.0, aura="Water",
    shape="Ribbons, ripples, bubbles and crescents; long S-curves, rounded ends.",
    motion="Ease-in-out with a lagging tail; surfaces overshoot and settle in 0.3 s; droplets follow ballistic arcs.",
    material="Two-tone toon water (highlight band plus a 1 px pearl foam edge), refraction quad, no outline.",
    sfx=("water swell with bubble pops", "flowing stream bed", "pressure thump with a splash"),
    after="Wet decal and puddles for 8 s, droplets for 1.5 s; small flames within 1 m are extinguished.",
    note="Water is never orange or violet; it keeps its own cool key even when the spell is hostile.",
    emi=2.0, body_db=-13)
D["GAL"] = dict(
    names=("pale mint", "cloud grey-green", "storm teal-grey", "near-white", "soft white-green"),
    pal=("#9ED8B8", "#D5ECE4", "#5E8A8A", "#F4FAF6", "#F7FFFB"),
    rune="an open crescent ring (never closed) with three feather glyphs",
    gesture="Wide, sweeping arm arcs with the weight on the front foot.",
    rel=0.85, spd=1.25, aura="Wind",
    shape="Curves, spirals, speed streaks and razor crescents; long and thin.",
    motion="The fastest discipline: full speed in 2 frames, long streak trails, a soft snap at the end; leaves and dust show the direction.",
    material="Stretched streak quads (alpha-clip), 1-2 px white wind lines, leaf and debris particles, no glow.",
    sfx=("breathy whistle gliding upward", "wind bed with paper flutter", "thunderclap crack with a cloth snap"),
    after="Dust swirls for 2 s; leaves and cloth flutter; nearby flames lean for 1.5 s. No decal.",
    note="Gale has almost no emission: it reads by motion, debris and streaks, not by glow.",
    emi=1.2, body_db=-12)
D["STN"] = dict(
    names=("ochre", "slate", "umber earth", "amber dust", "pale amber"),
    pal=("#C98C3E", "#8A8478", "#4A4338", "#F0C26A", "#FFE2A0"),
    rune="a square glyph ring with four corner stones",
    gesture="A downward stamp or a fist driven into the ground.",
    rel=1.25, spd=0.9, aura="Earth",
    shape="Blocks, columns, shards and hexagonal basalt; heavy with a low centre of mass.",
    motion="Slow start (6 frames of anticipation), heavy settle with two bounces; debris falls under real gravity.",
    material="Faceted low-poly rock, two-tone hard terminator, amber crack emission 2.0, pooled chunk debris.",
    sfx=("deep grind rising", "stone rumble bed", "boulder knock with gravel scatter"),
    after="Crack decal for 12 s, dust ring for 1.5 s; rubble props remain 20 s then crumble to dust.",
    note="Stone is the heaviest-feeling discipline: longest release, loudest low end, but the least glow.",
    emi=2.0, body_db=-10)
D["FRS"] = dict(
    names=("ice blue", "frost white", "pale violet shadow", "lilac", "frost-white core"),
    pal=("#8FD3F0", "#E8F4FA", "#7A78B8", "#C8B8F0", "#F4FBFF"),
    rune="a six-point snowflake ring with six tick marks",
    gesture="Slow, precise pinching motions with visible breath.",
    rel=1.1, spd=0.95, aura="Ice",
    shape="Hexagonal crystals, branching fern-frost and straight-faceted shards.",
    motion="Grows in steps (a 12 fps stop-motion feel), then holds still; shatters at the full 60 fps.",
    material="Faceted translucent ice (0.7 opacity), white fresnel rim, violet inner shadow tint, sparkle particles.",
    sfx=("glass ticks rising with a breath", "quiet crystalline shimmer", "crisp crunch with a glass tinkle"),
    after="Rime decal for 10 s, breath puffs for 4 s, wet surfaces freeze for 6 s; shards tinkle away.",
    note="Ice blue stays lighter and less saturated than the telegraph blue so the two never read alike.",
    emi=1.6, body_db=-15)
D["VRD"] = dict(
    names=("leaf green", "spring lime", "forest shadow", "pollen yellow", "pale lime"),
    pal=("#5FB35A", "#A8D86A", "#2F6B3C", "#F0D36B", "#E8FFC0"),
    rune="a leaf-and-vine ring with three budding nodes",
    gesture="Cupped hands opening like a bud.",
    rel=1.15, spd=0.9, aura="Nature",
    shape="Spirals, tendrils, leaves and petals; organic S-curves, never straight.",
    motion="Unfurls in 0.4 s with a springy overshoot, sways idly at 0.6 Hz while active and withers when it ends.",
    material="Alpha-cut leaf cards, two-tone toon bark, soft pollen sprites; emission only on blossoms (1.5).",
    sfx=("leaf rustle swell with a wood creak", "soft marimba sustain, very quiet", "wet snap with a seed patter"),
    after="Grass tufts and sprouts for 12 s, then they wither; vines remain 12 s; everything burns if Fire touches it.",
    note="Pollen yellow is desaturated so it never reads as telegraph gold.",
    emi=1.5, body_db=-16)
D["RAD"] = dict(
    names=("warm cream", "amber peach", "lavender shadow", "prism rose", "pale warm white"),
    pal=("#FFF1C9", "#FFB36B", "#B8A0D8", "#FF8FB1", "#FFFDF0"),
    rune="an eight-ray sun ring",
    gesture="Open hands raised toward the sky.",
    rel=0.9, spd=1.3, aura="Light",
    shape="Rays, prisms, circles and stars; radial symmetry.",
    motion="Instant: full brightness in 2 frames, settles over 0.2 s. It glows steadily and never pulses, so it is never mistaken for a gold telegraph.",
    material="Additive soft glow sprites, god-ray cards, a three-colour prism fan (rose #FF8FB1, mint #8FE0B0, violet #B08FFF), bloom on the core only.",
    sfx=("choir 'ah' swell", "shimmering bell pad", "bright bell strike"),
    after="Afterimage for 0.5 s, light motes for 2 s; shadows inside the radius stay hard-edged.",
    note="Radiance is warm cream, not gold: #FFC93C and #FFD34D are reserved.",
    emi=2.0, body_db=-13)
D["UMB"] = dict(
    names=("royal violet", "ink indigo", "near-black plum", "ash silver", "violet rim light"),
    pal=("#4A2F7A", "#2A2250", "#14102A", "#B7B3D6", "#8C7BD0"),
    rune="a crescent-moon ring with three phase glyphs",
    gesture="A low hand, palm down, in a smothering motion.",
    rel=1.0, spd=0.95, aura="Dark",
    shape="Ribbons, veils, crescents and long thin hooks; negative space matters more than the mass.",
    motion="Slides against the light with no ease-in and stops dead; edges lag a few frames behind.",
    material="Dark two-tone body with a silver edge rim (the only thing that reads), soft alpha smoke, ambient light dimmed 40% inside the radius.",
    sfx=("low drone with a muffled breath", "ambience ducked 6 dB under a soft dark hum", "soft thud with no ring and a reversed hiss"),
    after="A cold dark patch for 4 s; nearby lamps dim for 0.5 s; silver moth motes drift for 3 s.",
    note="The darkest tone is #14102A, never #000000; a rim of #8C7BD0 keeps it visible on dark ground.",
    emi=1.4, body_db=-17)
D["SPR"] = dict(
    names=("spirit green", "lantern amber", "deep teal", "mist white", "warm candle"),
    pal=("#6FD6A8", "#F2B867", "#2E6B63", "#EAF7F0", "#FFF4D6"),
    rune="a paw-and-leaf curl ring with three small wisp glyphs",
    gesture="A soft hum or whistle, one hand held out as if to a bird.",
    rel=1.3, spd=0.9, aura="",
    shape="Wisps, round lights, animal silhouettes in mist and soft rounded forms.",
    motion="Arrival is hesitant: a curved path with a pause at 70%; fireflies orbit; the light shifts from green (calm) to amber (eager) to dim (reluctant).",
    material="Soft additive sprites, mist cards at 0.4 opacity, a two-tone glow body with a 2 px darker outline on the spirit only; emission 1.5.",
    sfx=("two or three notes on an ocarina or flute", "gentle chime texture", "soft chime with a whisper"),
    after="Fireflies linger for 6 s; grass bends and ripples shiver; the spirit leaves a faint footprint of light for 3 s.",
    note="If the spirit declines, its light dims over 1.0 s and drifts away with a soft two-note descending chime. Never a red flash.",
    emi=1.5, body_db=-18)
D["DIV"] = dict(
    names=("candle cream", "soft rose", "dusty mauve", "ivory", "warm ivory core"),
    pal=("#FFE8B8", "#F7B8A0", "#C9A6B8", "#FFF8E6", "#FFFBEA"),
    rune="a double halo ring with candle-flame glyphs, left open until the prayer is answered",
    gesture="Hands pressed together with the head bowed.",
    rel=1.4, spd=0.85, aura="",
    shape="Circles, candle flames, petals and bells; vertical and symmetric.",
    motion="Descends slowly from above like falling light, steady and never pulsing; the answer is a 0.3 s brightening, not a flash.",
    material="Warm additive soft sprites, glass-like halo rings, petal cards; bloom on the core.",
    sfx=("soft choir swell", "temple-bell sustain", "a single bell with a breath"),
    after="Petal-lights for 3 s and a hush (ambience -3 dB for 2 s).",
    note="If refused, the ring stays open and fades over 1.2 s with one low bell. No flash and no penalty VFX. Starlight gold (the SSS rank colour) is never used.",
    emi=1.8, body_db=-16)
D["FBD"] = dict(
    names=("grey violet", "rust", "dark plum", "fracture white", "pale lilac-white"),
    pal=("#8A7FA3", "#B5543A", "#2B2536", "#F0ECF7", "#F5F2FA"),
    rune="a ring broken into three offset arcs, one arc drawn 5 degrees out of phase",
    gesture="Angular, off-rhythm gestures; the caster's shadow lags 0.1 s behind.",
    rel=1.1, spd=1.0, aura="",
    shape="Seams, cracks, shards, hairlines and mirrored duplicates; deliberately asymmetric.",
    motion="Stutters: a 2-frame hold every 8 frames; edges repeat 1-2 frames late (frame echo).",
    material="Screen-space distortion cracks, 25% world desaturation inside the radius, an inverted-colour edge, a 1 px white hairline.",
    sfx=("detuned reversed piano with a sub rumble", "quiet clock-tick stutter", "dry crack with a reversed tail"),
    after="A hairline Weave-scar decal for 30 s that other casters can read; nearby lights flicker for 2 s. (Designer-only: never explained in player text.)",
    note="Space leans pale blue-grey #9AA8D0, Time rust-sepia #B5543A, Void near-black #1B1626 with a 1 px white edge.",
    emi=1.6, body_db=-17)

SUB_KEY = {"Space": ("#9AA8D0", "pale blue-grey"), "Time": ("#B5543A", "rust-sepia"), "Void": ("#1B1626", "void black-violet")}

# ----------------------------------------------------------------------------- category feel
# release, active, recovery (s); range (m), size (m); speed (m/s); weight; particles; light (range, intensity)
C = {}
C["Strike"] = dict(
    rel=0.15, act=0.30, rec=0.45, rng=14.0, size=0.12, spd=28, weight="Medium", parts=60, light=(4, 2.0), dist=1,
    order=(0, 4, 3), icon="diamond frame", read="bolt",
    pose="One-handed point from shoulder height, two fingers extended, weight forward, off-hand pulled back.",
    shape="Bolt: head {w:.2f} m wide with a {l:.1f} m tail, flying at {s} m/s up to {r:.0f} m.",
    vfx="Core: a stretched toon mesh bolt with a flipbook trail; a 6-frame muzzle flash at the hand; a hit burst of 24 particles, radius 0.8 m.",
    cam="No camera move beyond the Medium shake on hit.",
    tele="Blue circle (parryable) if the target can parry; red triangle if the version is unblockable.",
    impact="Hit weight {wt}: hit-stop {hs:.2f} s on attacker and target, shake {sh:.2f}, 1-frame white flash on the target, burst at the contact point, reaction: {rx}.",
    cat_audio="whoosh sweeping with the bolt, then a punchy impact.",
    cat_after="Impact scar {sz:.1f} m wide.")
C["Barrage"] = dict(
    rel=0.25, act=1.20, rec=0.60, rng=7.0, size=4.0, spd=12, weight="Light", parts=120, light=(5, 1.6), dist=1,
    order=(0, 1, 3), icon="hexagon frame", read="cone",
    pose="Two-handed pushing sweep, feet planted wide, torso rotating through the arc.",
    shape="Zone: a {a} degree cone or a {w:.1f} m radius zone, {r:.0f} m deep, with 6 ticks at 0.2 s intervals.",
    vfx="Core: three layered flipbook sheets sweeping across the zone; a ground decal in the discipline key marks the area for 0.4 s before the first tick.",
    cam="One small shake at the first tick; no continuous shake.",
    tele="Red triangle ground zone (unblockable area); the zone edge draws in 0.5 s before the first tick.",
    impact="Per tick: Light hit-stop {hs:.2f} s (target only), no shake; the final tick is Medium: 0.07 s hit-stop and shake 0.08, reaction: stagger.",
    cat_audio="a long rising wash with a rhythmic tick per hit.",
    cat_after="Zone decal radius {sz:.1f} m.")
C["Ward"] = dict(
    rel=0.15, act=4.00, rec=0.25, rng=8.0, size=1.6, spd=0, weight="Light", parts=40, light=(3, 0.8), dist=1,
    order=(1, 0, 3), icon="arch frame", read="dome",
    pose="Open palm thrust forward, other hand to the chest, stance lowered.",
    shape="Dome of radius {w:.1f} m, or a plane {pw:.1f} x {ph:.1f} m and 0.05 m thick, placed within {r:.0f} m.",
    vfx="Core: a two-tone toon shell at 0.35 opacity with a 1.5 px outline; a ripple ring (0.4 s) spawns at every impact point; breakage is 16 shards flying outward.",
    cam="None.",
    tele="No telegraph (self or ally). Enemy-cast wards show a blue circle on the shell's base ring so players know it can be broken.",
    impact="On absorb: Light hit-stop {hs:.2f} s, a ripple at the contact point and a brightness flash of the shell for 0.1 s. On break: shatter over 0.5 s, shake 0.08 only if the breaking hit was Heavy.",
    cat_audio="a sustained hum that rises in pitch as it takes damage.",
    cat_after="Faint ring on the ground for 1.0 s.")
C["Binding"] = dict(
    rel=0.20, act=3.00, rec=0.35, rng=9.0, size=0.06, spd=20, weight="Light", parts=50, light=(3, 1.2), dist=0,
    order=(2, 0, 3), icon="octagon frame", read="line",
    pose="A pulling motion: closed fist drawing back along an invisible line.",
    shape="Tether: a {w:.2f} m wide line from hand to target up to {r:.0f} m; tension shown by thickness (x1.5 under strain).",
    vfx="Core: a spline ribbon mesh with a flipbook shimmer; knots or links spawn at the target's limbs over 0.2 s; breaking snaps into 10 shards.",
    cam="None.",
    tele="Gold square (grab) when an enemy casts a grab-type binding; blue circle for ranged snares that can be parried.",
    impact="On application: Light hit-stop {hs:.2f} s and a 1-frame white flash on the bound limb. While bound: a strain flicker every 0.5 s. On break: snap flash, no shake.",
    cat_audio="a taut string pluck on application, with a creak while under strain.",
    cat_after="Short scorch-free mark on the ground for 1.0 s.")
C["Mobility"] = dict(
    rel=0.10, act=0.35, rec=0.30, rng=6.0, size=0.5, spd=18, weight="None", parts=40, light=(0, 0.0), dist=0,
    order=(1, 0, 4), icon="chevron frame", read="trail",
    pose="Crouch-and-spring with the arms trailing, eyes on the landing spot.",
    shape="Movement of {r:.0f} m over {t:.2f} s with three afterimages 0.06 s apart; trail {l:.1f} m long.",
    vfx="Core: three fading caster silhouettes in the discipline key at 40%, 25% and 10% opacity; a speed-streak quad on the body; a landing puff of 16 particles.",
    cam="FOV +3 degrees for 0.3 s; no shake.",
    tele="No telegraph. If an enemy uses it, a 0.25 s blue rim flash and the destination marked by a thin ring.",
    impact="No hit-stop. On arrival: a landing puff and a 0.05 s light flash at the feet; footstep sound resumes on the first contact frame.",
    cat_audio="a whoosh with a footfall at the start and the landing.",
    cat_after="Footprint puff for 0.6 s.")
C["Sensing"] = dict(
    rel=0.20, act=2.50, rec=0.25, rng=12.0, size=12.0, spd=20, weight="None", parts=70, light=(0, 0.0), dist=1,
    order=(1, 3, 4), icon="eye-lozenge frame", read="ring",
    pose="Still stance; one hand cupped to the ear or brow, eyes narrowed, head turning slowly.",
    shape="Pulse ring that expands from 0 to {r:.0f} m in 0.6 s; revealed objects get a {w:.2f} m outline glow for the active time.",
    vfx="Core: a thin torus mesh with a flipbook shimmer; revealed things get a toon outline pass in the discipline mid colour (never interaction cyan); the world desaturates 15% while active.",
    cam="15% desaturation while active; no shake.",
    tele="No telegraph. Enemy-cast sensing shows a small eye glyph above their head.",
    impact="No hit-stop. Each revealed object pings: a 0.1 s outline flash and a soft tick, staggered by distance at 0.03 s per metre.",
    cat_audio="a clean sonar-like ping with a soft tail.",
    cat_after="Outlines fade over 1.0 s after the effect.")
C["Mending"] = dict(
    rel=0.30, act=2.00, rec=0.40, rng=3.0, size=1.0, spd=0, weight="None", parts=50, light=(3, 1.0), dist=0,
    order=(3, 1, 0), icon="teardrop frame", read="motes",
    pose="Both palms cupped over the target, head bowed, shoulders low.",
    shape="Aura of radius {w:.1f} m around the patient; {n} motes rise at 0.5 m/s over {t:.1f} s.",
    vfx="Core: soft additive motes in the mid colour with a warm core, a gentle upward flow; a 0.2 s soft pulse of light at the end (steady, not rhythmic).",
    cam="None.",
    tele="No telegraph.",
    impact="No hit-stop. Application is a soft brightening of the patient's rim for 0.3 s; no white flash, no shake, no damage number colour change.",
    cat_audio="a soft bell with a breath, never a loud sting.",
    cat_after="Motes settle on the ground for 1.5 s.")
C["Empowerment"] = dict(
    rel=0.20, act=10.0, rec=0.30, rng=6.0, size=0.3, spd=0, weight="None", parts=30, light=(2, 0.8), dist=0,
    order=(0, 3, 2), icon="crest frame", read="rim",
    pose="Two fingers touch the weapon or shoulder of the ally, with a brief nod.",
    shape="A rim glow on the ally's weapon or body, {w:.2f} m thick, lasting the buff time; 3 motes orbit the weapon.",
    vfx="Core: a rim-light overlay on the toon shader (intensity 1.4), a trail on the weapon, a pulse-free glow that fades over the last 2 s.",
    cam="None.",
    tele="No telegraph. A hostile buff on an enemy shows a small crest glyph above its head.",
    impact="On application: a 0.15 s flash of the rim. On each empowered hit, a 1-frame brightening of the glow; no extra shake.",
    cat_audio="a rising two-note motif on application and a quiet loop under the buff.",
    cat_after="Glow fades over 2 s.")
C["Hex"] = dict(
    rel=0.20, act=4.00, rec=0.35, rng=10.0, size=0.4, spd=22, weight="Light", parts=45, light=(2, 0.8), dist=0,
    order=(2, 0, 3), icon="inverted-pentagon frame", read="tag",
    pose="A downward wrist flick with the fingers splayed, aimed at the target's feet or eyes.",
    shape="Mark {w:.2f} m wide above the target's head or at its feet, with a curse sigil on the ground ({sz:.1f} m).",
    vfx="Core: a small projectile that unfolds into a sigil; the target gets a desaturating tint at 25% and a rim in the discipline shadow colour; the icon above the target mirrors the effect.",
    cam="None.",
    tele="No telegraph for chip hexes; blue circle if the enemy's hex can be parried.",
    impact="Hit weight Light: hit-stop {hs:.2f} s, a 1-frame flash on the target, then the sigil settles. No shake. Reaction: flinch.",
    cat_audio="a muted thunk and a descending tone for the penalty.",
    cat_after="Sigil on the ground for 4 s, fading with the effect.")
C["Illusion"] = dict(
    rel=0.15, act=5.00, rec=0.20, rng=5.0, size=1.0, spd=0, weight="None", parts=35, light=(0, 0.0), dist=1,
    order=(1, 2, 3), icon="crescent-lens frame", read="ghost",
    pose="Fingers drawn across the face or the air like pulling a curtain.",
    shape="A veil or decoy of about {w:.1f} m; the caster drops to 35% opacity or the decoy appears at 60% opacity {r:.0f} m away.",
    vfx="Core: an opacity change with a dissolve noise edge; a decoy copy with a 12-frame loop; outlines on the hidden caster fade to 0.",
    cam="None.",
    tele="No telegraph. Enemy illusions leave a faint shimmer in the air so a careful player can spot them.",
    impact="No hit-stop. If struck, the illusion breaks with a 0.2 s dissolve and a soft pop; the caster flashes back to full opacity.",
    cat_audio="an ambient duck of 3 dB and a reversed shimmer on start and end.",
    cat_after="A faint shimmer for 0.8 s.")
C["Pact"] = dict(
    rel=0.40, act=1.50, rec=0.50, rng=8.0, size=0.4, spd=6, weight="None", parts=55, light=(3, 1.0), dist=0,
    order=(1, 3, 4), icon="double-ring frame", read="spirit",
    pose="An open hand held low, palm up, in offering; kneeling is optional for the longer forms.",
    shape="A call light of {w:.2f} m that travels {r:.0f} m along a curved path, peaking {h:.1f} m high, then lands as the helper.",
    vfx="Core: a spirit orb or construct that arrives on an arc with 12 orbiting motes; it has its own toon outline and its mood sets its colour.",
    cam="None.",
    tele="No telegraph. If an enemy summons, a gold ground ring appears at the arrival point 0.5 s early.",
    impact="No hit-stop. Arrival is a soft burst and a chime; a declined call dims over 1.0 s with a descending two-note chime, never a flash.",
    cat_audio="a call phrase answered by a softer reply.",
    cat_after="Light motes for 3 s.")
C["Utility"] = dict(
    rel=0.20, act=20.0, rec=0.20, rng=5.0, size=0.8, spd=0, weight="None", parts=25, light=(4, 1.2), dist=0,
    order=(0, 3, 4), icon="notched-square frame", read="marker",
    pose="Draw a small glyph in the air with one index finger, then press it into place.",
    shape="A marker {w:.1f} m across placed within {r:.0f} m; it lasts {t:.0f} s or until its mana runs out.",
    vfx="Core: a small glowing construct with a soft point light; a 1.5 s fade on expiry; no particles beyond 25.",
    cam="None.",
    tele="No telegraph.",
    impact="No hit-stop. Placement is a soft pop and a 0.1 s flash; persistent effects hum at -20 dB.",
    cat_audio="a short clean tone and a quiet loop.",
    cat_after="A faint residue ring for 1.0 s.")

HEAVY_FAMILIES = {"Comet", "Blue Comet", "Quarry Fist", "Shatterknuckle", "Thunderclap Palm", "Blue Comet Hammer"}

# ----------------------------------------------------------------------------- form modifiers
# rel, act, w (width/size), rng multipliers; weight override; text for shape / motion / audio / pose
F = {
    "Standard": dict(rel=1, act=1, w=1, rng=1, shape="", motion="", audio="", pose=""),
    "Signature": dict(rel=1, act=1, w=1, rng=1, shape="", motion="", audio="", pose=""),
    "Needlepoint": dict(rel=0.9, act=1, w=0.5, rng=1.2, shape="Needlepoint: width halved, range +20%, a single hard tip.",
        motion="A single straight line with no spread.", audio="Pitched +4 semitones and thinner.", pose="Aim down the arm with one eye narrowed."),
    "Sweeping Arc": dict(rel=1.2, act=1.1, w=3.0, rng=0.8, shape="Sweeping Arc: a 90 degree arc, width x3, range -20%.",
        motion="Sweeps through the arc in 0.25 s and fades along its trailing edge.", audio="Wider stereo spread, pitched -2 semitones.", pose="The arm travels through the full arc."),
    "Twin Cast": dict(rel=1.1, act=1, w=0.8, rng=1, shape="Twin Cast: two emitters 1.5 m apart, each at 60% brightness and 80% width.",
        motion="The two halves mirror each other and arrive in the same frame.", audio="Left and right voices hard-panned, a fifth apart.", pose="Both hands cast together, one per anchor."),
    "Spiral Form": dict(rel=1.05, act=1, w=1, rng=1, shape="Spiral Form: a helix of radius 0.25 m, 2 revolutions per second.",
        motion="Rotates, throwing off small arcs; the trail twists.", audio="A slow Doppler wobble on the body loop.", pose="The wrist rotates as the hand extends."),
    "Grounded Form": dict(rel=1.1, act=1.2, w=1.2, rng=0.9, shape="Grounded Form: no higher than 0.3 m, crawling at 9 m/s and following the terrain.",
        motion="Hugs the floor, climbing stairs and stones; kicks dust.", audio="A low rumble, pitched -5 semitones.", pose="Palm pressed toward the floor."),
    "Rising Form": dict(rel=1.1, act=1, w=0.9, rng=0.7, shape="Rising Form: a column 5 m tall climbing at 12 m/s.",
        motion="Lifts upward and thins out at the top.", audio="An upward glissando of +7 semitones over 0.5 s.", pose="Palm flips upward and the head tilts to follow."),
    "Echo Form": dict(rel=1, act=1.5, w=1, rng=1, shape="Echo Form: a second pulse 0.45 s later at 60% scale and 60% opacity, with a ghost double.",
        motion="Fires, pauses a half-beat and repeats smaller.", audio="The second hit is 6 dB quieter and low-passed.", pose="A half-beat pause, then the gesture repeats smaller."),
    "Gentle Call": dict(rel=1.2, act=1, w=0.8, rng=1, shape="Gentle Call: arrival at 1.4x time, 80% brightness.",
        motion="A slow, polite arrival.", audio="Two soft notes at pianissimo.", pose="A small bow."),
    "Urgent Call": dict(rel=0.6, act=1, w=1.2, rng=1, shape="Urgent Call: arrival at 0.6x time, 130% brightness.",
        motion="A fast, bright arrival with quick flicker.", audio="Staccato notes with a sharper attack.", pose="A sharp upward gesture."),
    "Shared Guard": dict(rel=1, act=1.2, w=1.3, rng=1, shape="Shared Guard: a double halo around caster and spirit together.",
        motion="Both lights blend into one warm halo.", audio="Two voices in unison.", pose="Arms drawn in around the spirit."),
    "Guiding Path": dict(rel=1, act=1.3, w=1, rng=1.3, shape="Guiding Path: 5-7 lights spaced 1.2 m apart.",
        motion="Each light ignites as the previous fades.", audio="A soft step-wise melody.", pose="An arm sweeps toward the route."),
    "Warning Sign": dict(rel=1, act=1.5, w=1, rng=1, shape="Warning Sign: idle breathing glow at 0.8 Hz, alarm flicker at 3 Hz (never red) when triggered.",
        motion="Idles quietly, then flickers fast when something comes near.", audio="A quiet hum that rises to two short chimes on trigger.", pose="A hand raised, palm out."),
    "Resonant Echo": dict(rel=1, act=1.4, w=1, rng=1, shape="Resonant Echo: the ring repeats twice at 70% and 40% scale.",
        motion="Each ring returns slightly altered in colour.", audio="Reverb tail doubled.", pose="Two soft claps of the hands."),
    "Parting Form": dict(rel=1, act=0.8, w=1, rng=1, shape="Parting Form: dissolves upward over 1.2 s.",
        motion="The light rises and thins out like smoke.", audio="A descending farewell phrase.", pose="A small wave and a bow."),
    "Quiet Prayer": dict(rel=1, act=1, w=0.5, rng=1, shape="Quiet Prayer: half scale, glow cupped around the hands.",
        motion="A tiny steady glow.", audio="A breath and a single soft note.", pose="Hands cupped near the chest."),
    "Public Prayer": dict(rel=1.1, act=1, w=1.8, rng=1.2, shape="Public Prayer: x1.8 scale with a choir swell; others in range add their own lights.",
        motion="A wide column of light falls on the group.", audio="A choir swell.", pose="Arms open to the group."),
    "Vigil Form": dict(rel=1, act=2.0, w=0.8, rng=1, shape="Vigil Form: a low steady flame that lasts 20 s.",
        motion="A candle-like steady burn, unmoved by wind.", audio="A soft bell every 5 s.", pose="Kneeling with hands folded."),
    "Pilgrim Form": dict(rel=1, act=1.5, w=0.8, rng=1.3, shape="Pilgrim Form: footprints of light every 0.8 m that fade after 3 s.",
        motion="Follows the traveller, leaving a trail.", audio="A soft footstep chime.", pose="A bowed walk."),
    "Sanctuary Form": dict(rel=1.1, act=1.3, w=1.5, rng=1, shape="Sanctuary Form: a ring or dome of radius 2.5 m.",
        motion="Rises like a tent being raised.", audio="A hush and a held chord.", pose="Hands spread low, drawing a circle."),
    "Oathbound Form": dict(rel=1, act=1, w=0.6, rng=1, shape="Oathbound Form: a single thread knotted around the caster's hand and linked to one named person.",
        motion="A thin line of warm light tied in a knot.", audio="A single low bell on the knot.", pose="A clasped hand held against the heart."),
    "Last-Rite Form": dict(rel=1.2, act=1.5, w=0.7, rng=0.8, shape="Last-Rite Form: dim light, 2.0 s fade, a single bell note.",
        motion="Slow and gentle, like a hand on a shoulder.", audio="One distant bell.", pose="A hand laid gently on the patient."),
    "Space: Needle Fold": dict(rel=0.9, act=0.8, w=0.3, rng=1, shape="Needle Fold: a hairline seam 0.02 m wide and 2 m long.",
        motion="Opens and closes in 0.2 s.", audio="A thin tearing sound.", pose="A finger cuts a short line in the air."),
    "Space: Wide Fold": dict(rel=1.2, act=1, w=3.0, rng=1, shape="Wide Fold: a shimmering sheet 3 x 2 m.",
        motion="Unfolds like a curtain.", audio="A broad tearing sound with a sub drop.", pose="Both hands pull a curtain apart."),
    "Time: Single Echo": dict(rel=1, act=0.6, w=1, rng=1, shape="Single Echo: one ghost replay of 1 s, at 50% opacity.",
        motion="The replay plays forward once.", audio="The same sound reversed, quietly.", pose="A hand sweeps back across the shoulder."),
    "Time: Delayed Echo": dict(rel=1.1, act=0.8, w=1, rng=1, shape="Delayed Echo: the replay arrives 0.8 s late at 35% opacity.",
        motion="Appears after a pause as a faint copy.", audio="A clock tick, then the echo.", pose="A hand held out, then returned."),
    "Void: Thin Edge": dict(rel=0.9, act=0.8, w=0.3, rng=1, shape="Thin Edge: a line of absence 0.03 m wide with a 1 px white edge.",
        motion="Snaps open and closes at once.", audio="A silent cut, with the ambience dipping 6 dB.", pose="A flat hand slices once."),
    "Void: Quiet Field": dict(rel=1.2, act=1.5, w=2.5, rng=1, shape="Quiet Field: a zone of radius 2.5 m, world desaturated 40% and audio low-passed at 800 Hz.",
        motion="Colour drains outward from the centre.", audio="Everything dulls; a soft sub tone.", pose="Both palms pushed down."),
    "Fracture Form": dict(rel=1.2, act=1, w=1.3, rng=1, shape="Fracture Form: 9-12 jagged shards that scatter and reassemble in the wrong order, plus a 0.3 s screen crack.",
        motion="Splits along its seams and reassembles.", audio="Glass breaking, reversed.", pose="Both hands tear outward."),
}

# silhouette motifs (by family / noun word)
MOTIF = {
    "Anchor": "a plumb-bob spike with a ring", "Arc": "a crescent stroke", "Beacon": "a tall column with a pointed top",
    "Bloom": "a five-petal flower", "Bridge": "a shallow arch with rails", "Cairn": "a stack of three stones",
    "Chime": "a hanging bell with ripples", "Chorus": "a cluster of small lights", "Cloak": "a draped hooded cape",
    "Compass": "a floating needle in a ring", "Crest": "a ridged fan of points", "Current": "a long S-shaped ribbon",
    "Embrace": "two curved arms", "Flare": "a starburst of rays", "Fold": "a creased sheet", "Gate": "a tall open frame",
    "Glyph": "a single bold sigil", "Halo": "a thin spinning ring", "Horizon": "a long thin line with a bump",
    "Knot": "a tight triple loop", "Lantern": "a round lamp on a hook", "Lattice": "a diamond grid", "Lens": "a round pane with a bright rim",
    "Mantle": "a flowing shoulder cloak", "Mark": "a small bold brand", "Mirror": "a tall oval pane", "Path": "a ribbon of stepping tiles",
    "Pattern": "a repeating tile", "Pulse": "a flat expanding ring", "Reach": "a long thin hand", "Resonance": "concentric ripples",
    "Ribbon": "a looping streamer", "Ring": "a heavy flat ring", "Ripple": "fading concentric rings", "Screen": "a rippling sheet",
    "Seal": "a round stamp with spokes", "Sentinel": "a tall still figure", "Shell": "a pearly dome", "Shroud": "a heavy drape",
    "Sign": "a bold arrow symbol", "Skein": "a tangle of fine threads", "Spindle": "a slim spool with a thread", "Step": "a small floating disc",
    "Suture": "a stitched seam", "Thread": "a hair-thin taut line", "Tide": "a broad rolling crest", "Trace": "a faint outlined path",
    "Vessel": "a floating jar", "Ward": "a faint dome", "Watch": "a single open eye", "Whorl": "a turning vortex",
    "Lance": "a long slim spear", "Fang": "a curved twin tooth", "Comet": "a round head with a long tail", "Cascade": "a falling sheet of drops",
    "Tempest": "a churning cloud with sparks", "Rain": "a field of thin streaks", "Aegis": "a broad round shield", "Bastion": "a ring of walls",
    "Cloister": "a domed hush", "Chains": "bright linked chains", "Snare": "a flat loop trap", "Coil": "a thick winding band",
    "Dance": "ribbons tracing footsteps", "Stride": "puffs under each footfall", "Leap": "a burst under the boots",
    "Gaze": "glowing eyes", "Echo": "a returning ring", "Omen": "half-formed shapes in a cloud", "Lullaby": "slow falling notes",
    "Salve": "a thin glowing sheen", "Grace": "a soft warm glow", "Blessing": "a halo at hands and feet", "Vigor": "a rush along the arms",
    "Oath": "a thin band around the wrist", "Dirge": "slow dim notes", "Mire": "dark bubbling ground", "Pall": "a heavy descending shroud",
    "Mirage": "a rippling image", "Masque": "a pale mask", "Phantom": "a translucent copy", "Covenant": "two linked rings",
    "Calling": "a rising note and an answer light", "Procession": "a line of walking lights", "Loom": "a frame of threads",
    "Atlas": "map lines spreading outward", "Waystone": "a glowing knee-high stone",
    "Dart": "a small fast spark", "Veil": "a thin hanging sheet", "Spear": "a thick short lance", "Burst": "a hard radial flash",
    "Breath": "a broad wide cone", "Phantom": "a smoky silhouette", "Sigil": "a bold brand", "Lash": "a whip with a flick tip",
    "Guard": "a plate shield", "Grip": "a clutching hand", "Wave": "a rolling wall", "Bell": "a bell with rings", "Needle": "a thin bright needle",
    "Pool": "a mirror-smooth disc", "Fan": "a fan of blades", "Palm": "a flat hand shock ring", "Courier": "a ribbon with a message knot",
    "Pocket": "a small hollow", "Hook": "a curved hook", "Ear": "a cupped ear shape", "Rise": "a wall growing from the ground",
    "Fist": "a clenched stone fist", "Brace": "an interlocking frame", "Swarm": "a stream of small stones", "Hush": "a falling soft cloud",
    "Lock": "a thick sealing block", "Curtain": "a slanted sheet", "Salve": "a thin sheen", "Volley": "a spread of small seeds",
    "Ladder": "a vine ladder", "Decoy": "a swirling petal figure", "Blade": "a bright slim blade", "Reveal": "a pane of light",
}
CAT_MOTIF = {
    "Strike": "a pointed bolt", "Barrage": "a wide wave", "Ward": "a curved shield", "Binding": "a taut line", "Mobility": "a streaked trail",
    "Sensing": "an expanding ring", "Mending": "rising soft motes", "Empowerment": "a glowing outline", "Hex": "a small dark tag",
    "Illusion": "a translucent ghost", "Pact": "a small friendly light", "Utility": "a tidy marker",
}
