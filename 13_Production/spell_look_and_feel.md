# Spell Look and Feel Bible

> **Owner:** anime-fantasy-director with the combat-designer, technical-artist and audio-designer. **Status:** PROPOSED v1, 2026-11-03, not locked Canon. Every number is a tunable proposal; the hit-stop and shake tiers are the existing values in `Data/Combat/combat_tuning.json`. The per-spell values are in `05_Skills_Magic/Aetheria_Spell_Codex.xlsx`, sheet **Look & Feel** (2417 spells); this page is the rulebook behind them.
> **Builds on:** [[art_direction]] (toon shader, reserved colours, 60/30/10, bloom) · [[combat]] (hit weight, telegraphs, element auras) · [[skills_and_magic]] (chant time by tier).

## 1. The five-beat spell

Every spell has **Source, Chant tell, Release, Active, Recovery**, then a short **Afterglow**. The player must be able to read the beat they are in from shape, sound and motion, never from colour alone. Chant time comes from the tier (0.5 / 1.5 / 3 / 5 s); the per-spell **Release, Active and Recovery** are what the sheet gives, authored at the Intermediate tier.

## 2. Global rules

| Rule | Specification |
|---|---|
| **Spell lifecycle** | Source -> Chant tell -> Release -> Active -> Recovery -> Afterglow. Every spell shows all five; the tell is never colour alone (shape, sound and motion also change). |
| **Chant interrupt** | A stagger during chant or release shatters the ring into 12 shards over 0.25 s, plays a glass tick, then a 0.4 s fizzle puff in the discipline's mid colour. No damage VFX is spawned. |
| **Reserved colours** | Telegraph blue #3DA5FF, red #FF3B30 and gold #FFC93C, quest gold #FFD34D, interaction cyan #7FE3FF and the rank colours may not be a spell's dominant colour and never pulse in a spell. Spell effects flicker (noise) or glow steady; only telegraphs pulse, with the single exception of the slow ritual breath below. |
| **Ritual pulse (owner decision 2026-11-03)** | Divine and Radiance chant rings, charge-ups and Divine rituals may breathe slowly: 0.5 Hz (a 2 s cycle), +/-15% emission, ivory, rose or amber-peach only. Never during the Active phase of an enemy cast. Telegraph pulses are always 3 Hz or faster, so tempo, shape and colour all differ from the ritual breath. |
| **Hostile casts** | Any spell cast by an enemy adds the shared telegraph on top of its own VFX: blue circle (parryable), red triangle (unblockable), gold square (grab), none for chip effects. Player casts never show a telegraph. |
| **Enemy variant (owner decision 2026-11-03)** | Enemy-cast spells use a dimmer variant of the discipline palette: lightness x0.85, saturation x0.7, then 25% mixed toward the discipline shadow colour (hexes are in the Look & Feel sheet). Emission x0.6 (2.0 becomes 1.2), no white-hot core, outlines on solid constructs at x0.25 instead of x0.35, particle count x0.8, cast sound pitched -2 semitones with a gentle low-pass. The telegraph is drawn over this variant and keeps its full brightness, so the danger signal is always the brightest thing on screen. |
| **Value and saturation** | Spell body S 25-60%; accent S 70-90%; above 90% only for the emissive core. No pure black or pure white: darkest #14102A, lightest #FFFBEA. Shadows lean violet-blue, lights warm. |
| **60 / 30 / 10** | Every spell is 60% one palette colour, 30% a second, 10% an accent, plus an emissive core. The order depends on category (see Feel Categories). |
| **Toon shading** | Effect meshes use the Ascend/Toon two-tone shader: hard terminator (_ShadowStep 0.5, softness 0.06), shadow tint 0.58/0.56/0.78. Particles, smoke and water have no outline. Solid constructs (walls, crystals, constructs) get a 1.5 px outline at the local colour x 0.35. |
| **Bloom and emission** | Bloom threshold 1.0, intensity 0.4, only on emissives. Magic emission 2.0, ember 2.5, spirit and blossom 1.5. A lit pixel keeps at least 50% saturation and stays within 15 degrees of its palette key; a white-hot centre is a failed render. |
| **Hit-stop tiers** | Light 0.04 s, Medium 0.07 s, Heavy 0.11 s, Launch 0.08 s, Ultimate 0.18 s plus an impact frame. Shake: Light 0, Medium 0.08, Heavy 0.18, Launch 0.08, Ultimate 0.40, decaying over 0.25 s. Spells use these tiers and never invent their own. |
| **Hit feedback checklist** | Hit-stop, 1-frame white hit flash on the target, impact VFX at the contact point, layered sound (cast + impact + material), damage number, reaction animation, controller rumble. Non-damaging spells replace hit-stop with an application flash on the target. |
| **Element aura** | Fire, Water, Wind, Earth, Ice, Nature, Light and Dark spells that hit leave a 6 s element aura on the target: a thin rim glow plus 6 orbiting motes in the aura colour at 40% opacity. A second element during the aura triggers the matching reaction (sheet Reactions VFX). |
| **Camera** | No spell moves the camera except through the shake tiers above, a 3 degree FOV kick on Mobility (0.3 s), and a 15% world desaturation while Sensing is active. Effects must never cover the player character or the lock-on target for more than 0.3 s. |
| **Readability** | Greyscale and 25% size test: the spell's category must still read from its silhouette alone (bolt, cone, dome, line, trail, ring, motes, tag, ghost, spirit, marker). |
| **Accessibility** | A reduced-effects setting halves particle counts, removes distortion quads and screen desaturation, keeps every telegraph shape and sound, and replaces flicker with steady glow. |
| **Performance** | Per spell: at most 1 point light, 2 distortion quads, 1 decal projector and the particle budget in the sheet. At 25 m the budget halves; at 50 m only the core sprite and the light remain. Five concurrent spells must stay inside 2.0 ms GPU. |
| **Refusal and failure** | Spiritbond and Divine spells that are declined never flash red or buzz: the effect dims over 1.0-1.2 s and drifts away with a soft descending note. Failure must feel like a quiet no, not a punishment. |
| **Forbidden consequence** | Forbidden casts leave a hairline Weave-scar decal for 30 s that other casters can read. It is a visual consequence only; player-facing text never explains it (designer spoiler). |

## 3. Chant tells by tier and mastery

| Tier | Chant | Ring size | Glyphs | VFX scale | Notes |
|---|---|---|---|---|---|
| Basic (F-E) | 0.5 s | x0.6 | 1 | x0.6 | Single glyph at the hand; no ring on the ground. |
| Intermediate (D-C) | 1.5 s | x1.0 | 2 | x1.0 | Baseline: every per-spell value in the Look & Feel sheet is authored at this tier. |
| Advanced (B-A) | 3 s | x1.4 | 3 | x1.4 | Full ring plus an outer ring that turns the other way; caster hair and cloth lift. |
| Grand (S) | 5 s | x1.8 | 4 | x1.8 | Ring, outer ring and a vertical glyph column 3 m tall; ambient light dims 15% while charging. |
| Forbidden (SS) | 8 s + Aether Saturation | x2.2 | 5 | x2.0 | Ring cracks outward in steps; world desaturates 20% in 6 m; sound lowpasses at 1.2 kHz. |
| Divine (SSS) | Ritual / Devotion | x2.0 | 6 | x1.8 | No chant timer: the ring opens as the ritual is performed and closes only when answered. |

| Mastery step | Visual | Chant time |
|---|---|---|
| Full chant | Full ring, every glyph, voice speaks the whole verse. | 100% of tier chant time |
| Short chant | Two glyphs, ring at 70% diameter, voice speaks the last line only. | about 60% of tier chant time |
| Skill name only | One glyph at the hand, 0.3 m wide, the spell name spoken once. | about 25% of tier chant time |
| Chantless | No ring and no glyph: a 0.2 s hand glow in the discipline's mid colour, no voice. | none (release only) |

## 4. The twelve disciplines

| Discipline | Key / Mid / Shadow / Accent / Core | Chant ring | Tempo (release x, speed x) | Signature motion | Cast sound |
|---|---|---|---|---|---|
| **Aethercraft** | `#4E55D8` `#5BC8E8` `#2A2F80` `#D5DCEE` `#E9F7FF` | a hexagonal grid ring with six node glyphs | 1.00, 1.00 | Locks into place with a 2-frame overshoot, then holds perfectly still; it never wobbles or flickers. | glass-harmonica swell |
| **Flamecraft** | `#FF8A3D` `#E8692C` `#5A2A1E` `#FFD9A0` `#FFF0C8` | a triangle-spiral ring with three flame glyphs | 1.00, 1.05 | Ignites in 3 frames, then flickers with noise at 6-9 Hz (never a regular pulse); embers rise at 0.8 m/s. | ignition whump with rising crackle |
| **Tidecraft** | `#2BA5A8` `#5CC9B8` `#1B4F6B` `#EAF6F2` `#D8FFF4` | concentric wave rings with three ripple glyphs | 1.00, 1.00 | Ease-in-out with a lagging tail; surfaces overshoot and settle in 0.3 s; droplets follow ballistic arcs. | water swell with bubble pops |
| **Galecraft** | `#9ED8B8` `#D5ECE4` `#5E8A8A` `#F4FAF6` `#F7FFFB` | an open crescent ring (never closed) with three feather glyphs | 0.85, 1.25 | The fastest discipline: full speed in 2 frames, long streak trails, a soft snap at the end; leaves and dust show the direction. | breathy whistle gliding upward |
| **Stonecraft** | `#C98C3E` `#8A8478` `#4A4338` `#F0C26A` `#FFE2A0` | a square glyph ring with four corner stones | 1.25, 0.90 | Slow start (6 frames of anticipation), heavy settle with two bounces; debris falls under real gravity. | deep grind rising |
| **Frostcraft** | `#8FD3F0` `#E8F4FA` `#7A78B8` `#C8B8F0` `#F4FBFF` | a six-point snowflake ring with six tick marks | 1.10, 0.95 | Grows in steps (a 12 fps stop-motion feel), then holds still; shatters at the full 60 fps. | glass ticks rising with a breath |
| **Verdance** | `#5FB35A` `#A8D86A` `#2F6B3C` `#F0D36B` `#E8FFC0` | a leaf-and-vine ring with three budding nodes | 1.15, 0.90 | Unfurls in 0.4 s with a springy overshoot, sways idly at 0.6 Hz while active and withers when it ends. | leaf rustle swell with a wood creak |
| **Radiance** | `#FFF1C9` `#FFB36B` `#B8A0D8` `#FF8FB1` `#FFFDF0` | an eight-ray sun ring | 0.90, 1.30 | Instant: full brightness in 2 frames, settles over 0.2 s. Steady in combat; during a chant or ritual only, the glow may breathe at 0.5 Hz (+/-15% emission, cream or amber-peach, never gold). | choir 'ah' swell |
| **Umbral** | `#4A2F7A` `#2A2250` `#14102A` `#B7B3D6` `#8C7BD0` | a crescent-moon ring with three phase glyphs | 1.00, 0.95 | Slides against the light with no ease-in and stops dead; edges lag a few frames behind. | low drone with a muffled breath |
| **Spiritbond** | `#6FD6A8` `#F2B867` `#2E6B63` `#EAF7F0` `#FFF4D6` | a paw-and-leaf curl ring with three small wisp glyphs | 1.30, 0.90 | Arrival is hesitant: a curved path with a pause at 70%; fireflies orbit; the light shifts from green (calm) to amber (eager) to dim (reluctant). | two or three notes on an ocarina or flute |
| **Divine** | `#FFE8B8` `#F7B8A0` `#C9A6B8` `#FFF8E6` `#FFFBEA` | a double halo ring with candle-flame glyphs, left open until the prayer is answered | 1.40, 0.85 | Descends slowly from above like falling light, steady in combat; during a ritual the ring breathes at 0.5 Hz (+/-15% emission, ivory or rose, never gold); the answer is a 0.3 s brightening, not a flash. | soft choir swell |
| **Forbidden Arts** | `#8A7FA3` `#B5543A` `#2B2536` `#F0ECF7` `#F5F2FA` | a ring broken into three offset arcs, one arc drawn 5 degrees out of phase | 1.10, 1.00 | Stutters: a 2-frame hold every 8 frames; edges repeat 1-2 frames late (frame echo). | detuned reversed piano with a sub rumble |

Per-discipline shape language, materials, aftermath and rules of thumb are in the workbook sheet **Feel Disciplines**.

## 5. The twelve categories

| Category | Release / Active / Recovery (s) | Range, size | Hit weight | Silhouette | Enemy telegraph |
|---|---|---|---|---|---|
| **Strike** | 0.15 / 0.30 / 0.45 | 14 m, 0.12 m | Medium | bolt (diamond frame) | Blue circle (parryable) if the target can parry; red triangle if the version is unblockable. |
| **Barrage** | 0.25 / 1.20 / 0.60 | 7 m, 4.00 m | Light | cone (hexagon frame) | Red triangle ground zone (unblockable area); the zone edge draws in 0.5 s before the first tick. |
| **Ward** | 0.15 / 4.00 / 0.25 | 8 m, 1.60 m | Light | dome (arch frame) | No telegraph (self or ally). Enemy-cast wards show a blue circle on the shell's base ring so players know it can be broken. |
| **Binding** | 0.20 / 3.00 / 0.35 | 9 m, 0.06 m | Light | line (octagon frame) | Gold square (grab) when an enemy casts a grab-type binding; blue circle for ranged snares that can be parried. |
| **Mobility** | 0.10 / 0.35 / 0.30 | 6 m, 0.50 m | None | trail (chevron frame) | No telegraph. If an enemy uses it, a 0.25 s blue rim flash and the destination marked by a thin ring. |
| **Sensing** | 0.20 / 2.50 / 0.25 | 12 m, 12.00 m | None | ring (eye-lozenge frame) | No telegraph. Enemy-cast sensing shows a small eye glyph above their head. |
| **Mending** | 0.30 / 2.00 / 0.40 | 3 m, 1.00 m | None | motes (teardrop frame) | No telegraph. |
| **Empowerment** | 0.20 / 10.00 / 0.30 | 6 m, 0.30 m | None | rim (crest frame) | No telegraph. A hostile buff on an enemy shows a small crest glyph above its head. |
| **Hex** | 0.20 / 4.00 / 0.35 | 10 m, 0.40 m | Light | tag (inverted-pentagon frame) | No telegraph for chip hexes; blue circle if the enemy's hex can be parried. |
| **Illusion** | 0.15 / 5.00 / 0.20 | 5 m, 1.00 m | None | ghost (crescent-lens frame) | No telegraph. Enemy illusions leave a faint shimmer in the air so a careful player can spot them. |
| **Pact** | 0.40 / 1.50 / 0.50 | 8 m, 0.40 m | None | spirit (double-ring frame) | No telegraph. If an enemy summons, a gold ground ring appears at the arrival point 0.5 s early. |
| **Utility** | 0.20 / 20.00 / 0.20 | 5 m, 0.80 m | None | marker (notched-square frame) | No telegraph. |

## 6. Forms

A form modifies the base spell's shape, motion, sound and pose; it never changes the discipline's palette. Pips in the icon corner count the form (1 to 7); signature spells carry a star pip.

| Form | Shape change |
|---|---|
| Needlepoint | Needlepoint: width halved, range +20%, a single hard tip. |
| Sweeping Arc | Sweeping Arc: a 90 degree arc, width x3, range -20%. |
| Twin Cast | Twin Cast: two emitters 1.5 m apart, each at 60% brightness and 80% width. |
| Spiral Form | Spiral Form: a helix of radius 0.25 m, 2 revolutions per second. |
| Grounded Form | Grounded Form: no higher than 0.3 m, crawling at 9 m/s and following the terrain. |
| Rising Form | Rising Form: a column 5 m tall climbing at 12 m/s. |
| Echo Form | Echo Form: a second pulse 0.45 s later at 60% scale and 60% opacity, with a ghost double. |
| Gentle Call | Gentle Call: arrival at 1.4x time, 80% brightness. |
| Urgent Call | Urgent Call: arrival at 0.6x time, 130% brightness. |
| Shared Guard | Shared Guard: a double halo around caster and spirit together. |
| Guiding Path | Guiding Path: 5-7 lights spaced 1.2 m apart. |
| Warning Sign | Warning Sign: idle breathing glow at 0.8 Hz, alarm flicker at 3 Hz (never red) when triggered. |
| Resonant Echo | Resonant Echo: the ring repeats twice at 70% and 40% scale. |
| Parting Form | Parting Form: dissolves upward over 1.2 s. |
| Quiet Prayer | Quiet Prayer: half scale, glow cupped around the hands. |
| Public Prayer | Public Prayer: x1.8 scale with a choir swell; others in range add their own lights. |
| Vigil Form | Vigil Form: a low steady flame that lasts 20 s. |
| Pilgrim Form | Pilgrim Form: footprints of light every 0.8 m that fade after 3 s. |
| Sanctuary Form | Sanctuary Form: a ring or dome of radius 2.5 m. |
| Oathbound Form | Oathbound Form: a single thread knotted around the caster's hand and linked to one named person. |
| Last-Rite Form | Last-Rite Form: dim light, 2.0 s fade, a single bell note. |
| Space: Needle Fold | Needle Fold: a hairline seam 0.02 m wide and 2 m long. |
| Space: Wide Fold | Wide Fold: a shimmering sheet 3 x 2 m. |
| Time: Single Echo | Single Echo: one ghost replay of 1 s, at 50% opacity. |
| Time: Delayed Echo | Delayed Echo: the replay arrives 0.8 s late at 35% opacity. |
| Void: Thin Edge | Thin Edge: a line of absence 0.03 m wide with a 1 px white edge. |
| Void: Quiet Field | Quiet Field: a zone of radius 2.5 m, world desaturated 40% and audio low-passed at 800 Hz. |
| Fracture Form | Fracture Form: 9-12 jagged shards that scatter and reassemble in the wrong order, plus a 0.3 s screen crack. |

## 7. Element reactions: VFX

| Reaction | Trigger | Look | Colours | Sound and feedback |
|---|---|---|---|---|
| **Firestorm** | Fire + Wind | A spinning fire tornado 2.5 m tall and 1.8 m wide, orange with cream sparks, lasting 3 s with a damage tick every 0.5 s. | #FF8A3D / #FFF0C8 | Roar plus whoosh; shake 0.08 on spawn. |
| **Storm Prison** | Water + Lightning | Six pale arcs cage the target in a rotating ring, teal base with violet-white arcs (never telegraph blue); a chain flash jumps to the nearest enemy. | #5CC9B8 / #E4DCFF | Crackle plus water hiss; 0.07 s hit-stop on stun. |
| **Freeze** | Water + Ice | The target is wrapped in a translucent ice shell (0.7 opacity) for the freeze time; the next Heavy hit shatters it into 16 shards. | #8FD3F0 / #E8F4FA | Glass lock then a crunch; shatter is Heavy: 0.11 s hit-stop. |
| **Thermal Shock** | Fire + Ice | A 3 m ring shockwave that shifts from white-orange to ice-blue; both aura rims burst outward as motes. The only reaction that uses a 1-frame white impact frame at this tier. | #FF8A3D / #8FD3F0 | Hard crack and a steam hiss; Heavy hit-stop. |
| **Magma** | Earth + Fire | A 2 m pool of dark rock with glowing orange cracks and slow bubbles; the hazard lasts 8 s and cools to grey over the last 2 s. | #C98C3E / #E8692C | Low bubbling rumble; no hit-stop. |
| **Swirl** | Wind + any element | A spiral ribbon of wind carries the source element's colour from the target to every enemy within 4 m over 0.6 s and leaves a fresh aura on each. | #9ED8B8 + source colour | Rising whistle; no hit-stop. |
| **Wildfire** | Nature + Fire | Six flame lines creep through grass at 3 m/s, the grass blackens behind them and leaves drift as ash; stops at bare ground or water. | #5FB35A / #FF8A3D | Crackling spread; no hit-stop. |
| **Twilight Burst** | Light + Dark | Rose-lavender light and ink-violet dark spiral into a 1.2 m sphere over 0.25 s, then burst as a ring with a full impact frame. Rare and late game. | #FFF1C9 / #4A2F7A | Choir and sub drone collide; Ultimate tier: 0.18 s hit-stop and shake 0.40. |
| **Miasma Blast** | Poison + Fire | A sickly olive-green burst (#8FB94A) leaves a fog of radius 2.5 m for 5 s that drifts slowly upward. | #8FB94A / #FF8A3D | Wet pop and a long hiss; Medium hit-stop. |
| **Grounded** | Lightning + Earth | Pale violet-white arcs flow into the ground and end in an amber dust ring; the target shows a slow icon and its feet sink 0.05 m. | #E4DCFF / #C98C3E | Zap into a thud; Light hit-stop. |

## 8. Unity implementation notes

- One prefab per spell family under `Game/Assets/_Game/Art/VFX/Spells/<Discipline>/<Category>/`, named `VFX_<SpellID>_<Name>`; forms are variant prefabs that override size, timing and the extra shape.
- Effect shaders: the `Ascend/Toon` two-tone for solid meshes, an additive unlit sprite shader for glow and motes, a refraction quad shader for Aethercraft, Tidecraft and Forbidden only. Particles and water carry no outline.
- Drive timing from data, not from the prefab: release, active and recovery come from a future `Data/Spells/spell_feel.json` (columns match the first 20 columns of the Look & Feel sheet), so feel can be tuned without code, the same way `combat_tuning.json` works.
- Hit feedback calls the existing hit-stop and shake tiers by weight name; a spell never carries its own hit-stop number.
- Test on three backdrops (sunlit grass, dark cave, night town) and in greyscale at 25% size before sign-off; keep the five-concurrent-spells budget under 2.0 ms GPU.

## 9. Owner decisions (2026-11-03)

1. **Hostile spells use a dimmer enemy variant.** Lightness x0.85, saturation x0.7, 25% mixed toward the discipline shadow colour, emission x0.6, no white-hot core, outlines at x0.25, particles x0.8, cast sound pitched down 2 semitones. The telegraph keeps full brightness on top. Per-spell enemy hexes are in the Look & Feel sheet (Enemy Key, Mid, Accent).
2. **Divine and Radiance may pulse during rituals.** Only the chant ring, charge-up and ritual: 0.5 Hz, +/-15% emission, ivory, rose or amber-peach, never gold, never during the Active phase of an enemy cast. Telegraph pulses are 3 Hz or faster, so they cannot be confused.
3. **First vertical slice: 50 spells** (4 to 5 per discipline, text hand-written), listed below and in the sheet **Vertical Slice**. Wave 1 (12 spells, one per discipline) proves the pipeline; wave 2 (18) and wave 3 (20) fill it out. Category spread: Strike 6, Barrage 4, Ward 4, Binding 4, Mobility 5, Sensing 5, Mending 4, Empowerment 2, Hex 4, Illusion 4, Pact 4, Utility 4. It covers the Ring 0 Firestorm pair (Cinder Fang + Tempest Fan), Freeze (Undertow Snare + Glacier Lock), Twilight Burst (Sunveil Blur with Gloamstep Shift or Duskbind Chain), Wildfire (Seedshot Volley with any Fire spell), and the Spiritbond and Divine refusal feel.

| Wave | Spell | Discipline | Category | Rank | What it proves | Signature moment |
|---|---|---|---|---|---|---|
| 1 | **Skypiercer Lance** | Aethercraft | Strike | E | The baseline Strike: one clean bolt that proves release, hit-stop and the stagger-interrupt loop. | The tail rings snap together into a single silver dot a heartbeat before impact, then bloom outward as the target's chant shatters. |
| 1 | **Hearth of Grace Prayer** | Divine | Mending | E | Mending prayer: warm hush, bell, no flash, and the open ring awaiting the answer. | As the prayer is answered, every flame in the room brightens by the same small step at once, and for a heartbeat nobody speaks. |
| 1 | **Yesterday's Trace Echo** | Forbidden Arts | Sensing | SS | Time Sensing: the stuttering replay, Weave-scar decal and the world's colour drain. | The echo always freezes for exactly one frame on the moment of greatest movement, and the player sees it in a single sharp still before it plays on. |
| 1 | **Cinder Fang** | Flamecraft | Strike | E | Fire Strike: applies the Fire aura, half of the Ring 0 Firestorm test. | The first spark it sheds always lands at the target's feet a moment before the ember itself, like a warning that arrives too late. |
| 1 | **Glacier Lock** | Frostcraft | Binding | D | Ice Binding and the Freeze reaction partner: ice shell, then the Heavy shatter. | The final click of the lock lands exactly on the beat after the target's last step, as though the ice had been waiting for it. |
| 1 | **Tempest Fan** | Galecraft | Barrage | S | Wind Barrage: the other half of Firestorm, and the Swirl spread on every element. | When it meets a fire aura the fan's silver lines turn orange and curl into a spinning column, which is how the whole party learns a Firestorm has begun. |
| 1 | **Aurora Veil** | Radiance | Hex | D | Hex by light: the prism fan and depth confusion, with the ritual-breath rule at low intensity. | At the very end the three colours converge into a single warm line across the horizon for one beat, like a sunrise that lasted a second. |
| 1 | **Foxfire Guide Call** | Spiritbond | Pact | D | Pact: hesitant arrival, mood colours and the quiet refusal. The key emotional test. | If the fox declines, its light dims over a full second, it sits, and a soft two-note chime descends. No flash, no penalty: only a quiet no. |
| 1 | **Bastion Rise** | Stonecraft | Ward | B | Ward as terrain: a wall that blocks line of sight, with the rubble crumble. | The wall's last act is a slow, deliberate crumble from the top, and the rubble it leaves stays put long enough to trip a pursuer. |
| 1 | **Undertow Snare** | Tidecraft | Binding | D | Water Binding: with Glacier Lock it tests the Freeze reaction (shell and shatter). | A tiny whirlpool spins open in the ground at the moment it grips, so the player can see which foot is caught. |
| 1 | **Gloamstep Shift** | Umbral | Mobility | E | Mobility through shadow: dark afterimages with silver edges, the proof that dark effects stay visible. | Their silver-edged afterimage stays one beat longer than expected, and sharp-eyed enemies learn to look at it rather than at where the caster went. |
| 1 | **Blooming Remedy** | Verdance | Mending | E | Mending: soft motes, no flash, and the quiet bell. The tone benchmark for healing. | No flash accompanies it at all; the only sign it has worked is the patient's shoulders dropping a finger's width. |
| 2 | **Aegis Arc Bulwark** | Aethercraft | Ward | B | Sustained Ward: absorb ripple, rising hum and the 0.5 s shatter on break. | On break the sixteen shards rise rather than fall, drifting upward for half a second as if the pattern were exhaling. |
| 2 | **Fatestring Tether** | Aethercraft | Binding | D | Binding with tension: strain flicker and snap, and the gold square grab telegraph when an enemy casts it. | At the snapping limit the line sings one clear note that drops an octave as it breaks, so every ally knows the instant it let go. |
| 2 | **Sanctuary of Hands Prayer** | Divine | Ward | B | Ward as refuge: dome of 2.5 m, ritual breath at 0.5 Hz, and the Public Prayer scale. | The ring's last note is the first chord played backwards, so the end of the prayer sounds like a door quietly closing. |
| 2 | **Hallowed Calling** | Divine | Pact | D | Divine refusal feel: the open ring, the bell, and a quiet no that costs nothing. | An answered call closes the ring with a bell and a brightening; a refusal leaves the ring open and lets it fade, so the player feels the difference without being told. |
| 2 | **Nullglass Edge Cut** | Forbidden Arts | Strike | SS | Void Strike: the thin dark line, the 25% desaturation and the scar. | The cut is silent, and the sound of the room returns one beat after the line closes, as if the world had needed a moment to catch up. |
| 2 | **Hollow Interval Gap** | Forbidden Arts | Hex | SS | Time Hex: the gap in light and sound, and the lagging shadow. | The missing beat is replayed at double speed a second later, so anyone nearby hears the world stutter twice. |
| 2 | **Dragon Maw Breath** | Flamecraft | Barrage | S | Fire Barrage: cone ticks, the red triangle zone telegraph and scorch decals. | For one frame the cone's centre goes dead white, then the colour floods outward like a lit fuse, and the sound arrives a heartbeat later. |
| 2 | **Rimefang Shard** | Frostcraft | Strike | E | Ice Strike: stop-motion growth, shatter at full 60 fps, Ice aura. | The shard grows in four distinct stop-motion steps and then, on release, moves at the full speed of the sky with no in-between. |
| 2 | **Razorwind Blade** | Galecraft | Strike | E | Wind Strike: streaks without glow, proving a discipline that reads by motion alone. | The whistle is always a perfect fifth above the caster's chant, so veterans can hear a Razorwind coming in the middle of a crowd. |
| 2 | **Zephyr Flash Step** | Galecraft | Mobility | F | Mobility: afterimages and speed streaks, and the fastest release in the game. | The third afterimage lingers a half-beat longer than the others and points exactly where the caster started, like an arrow home. |
| 2 | **Beacon Crown Pillar** | Radiance | Utility | E | Utility: the tall light column, a landmark that must not be mistaken for a quest marker. | At the moment of casting the crown opens one ring at a time from the ground to the sky, each ring a half-second apart, like a staircase being lit. |
| 2 | **Kindred Pulse Bond** | Spiritbond | Empowerment | D | Empowerment between friends: the shared halo of caster and spirit. | At the peak of the pulse the two lights briefly swap colours, spirit green to amber and amber to green, before returning. |
| 2 | **Wisp Errand** | Spiritbond | Pact | D | Pact errand: the arc, the orbit and the dim-and-drift on refusal. | At seventy per cent of the way, the wisp always pauses, and on that pause the player learns whether it will deliver or drift away. |
| 2 | **Dewdrop Covenant** | Spiritbond | Pact | B | A lasting Pact: the covenant rings, the dewdrop and the consequence of a broken promise. | If the covenant is accepted, the dewdrop holds its place for a full second and a tiny flower opens on the ground beneath it. |
| 2 | **Quarry Fist** | Stonecraft | Strike | D | Heavy Strike: the 0.11 s hit-stop, shake 0.18 and debris physics. | The stone hangs one beat too long before it flies, and the whole screen's dust settles upward toward it as if the ground were holding its breath. |
| 2 | **Breakwall Surge** | Tidecraft | Barrage | B | Water Barrage: the wide wave, wet decals and flames extinguished within 1 m. | For half a second the wave holds its curl at the top, a frozen green arch, and the whole crowd glances up before it falls. |
| 2 | **Eclipse Double** | Umbral | Illusion | D | Illusion decoy: the 12-frame loop and the pop when struck. | When it pops, the silver outline lingers a single frame and the caster's real shadow flickers once to match it. |
| 2 | **Seedshot Volley** | Verdance | Barrage | B | Nature Barrage: scatter of seeds, sprouts left behind, and Wildfire with Fire. | A single seed always lands on the caster's own shoe and sprouts a small flower there, which most mages pretend not to notice. |
| 3 | **Truesight Lens** | Aethercraft | Sensing | E | Sensing: the 15% desaturation and outline pass, using a mid colour that is never interaction cyan. | When the lens finds a hidden rune it clicks once, and the rune's outline blooms into a full silver sigil that stays for two seconds. |
| 3 | **Morrow's Measure Prayer** | Divine | Mending | E | Last-Rite feel: dim light, one bell, mercy with no flash. | A single bell tolls at the moment of answer, and the same bell tolls once more, softer, if the god declines. |
| 3 | **Oathfire Witness Prayer** | Divine | Utility | E | Utility witness flame: a steady flame for a freely spoken vow. | When the vow is finished the flame stands perfectly straight for one breath, and the whole room hears it settle. |
| 3 | **Folded Threshold Step** | Forbidden Arts | Mobility | SS | Space Mobility: the hairline seam and the pale blue-grey palette. | The footstep echoes a heartbeat after the caster has already passed, and in that echo a sharp listener hears which way they went. |
| 3 | **Emberbrand Edge** | Flamecraft | Empowerment | D | Empowerment: the weapon rim glow, trail and 2 s fade-out. | On the first strike each cut leaves a bright after-line in the air that holds for one frame, like a chalk mark drawn by the blade. |
| 3 | **Soot Phantom** | Flamecraft | Illusion | D | Illusion: decoy at 60% opacity, dissolve edge and the shimmer tell on the enemy variant. | When it breaks, the ash holds its shape for a single frame, so the player sees the decoy's silhouette in grey before it falls apart. |
| 3 | **Winterglass Shield** | Frostcraft | Ward | D | Ward made of ice: brittle shards and the rime decal. | After the third crack the pane holds for exactly one more beat, long enough for the defender to step back, and then rings once like a struck glass. |
| 3 | **Winterstep Bridge** | Frostcraft | Mobility | E | Mobility surface: a temporary foothold that melts, with the stepping sound. | Each step makes a different note on the way across, so the whole bridge plays a short scale that rises and then falls as it melts. |
| 3 | **Vacuum Hollow** | Galecraft | Hex | D | Hex: the audio duck and the penalty tag over the target. | As it closes, every sound that was muffled inside plays back at once in a quick, overlapping rush, a half second of everything caught up. |
| 3 | **Mercy Flame** | Radiance | Mending | E | Mending light: the steady warm glow in a treatment space, no pulse in combat. | When the flame is turned down, its glow lingers on the patient's hand for one extra breath, as if reluctant to leave. |
| 3 | **Sunveil Blur** | Radiance | Illusion | D | Illusion by light: blurred outline, and the Twilight Burst partner. | The blur always lags exactly three frames behind the caster's real movement, so a sharp eye can learn to aim at the gap. |
| 3 | **Listening Pact** | Spiritbond | Sensing | E | Sensing through a spirit: soft whispers and a gentle map. | The whispers always end on the same soft sigh, and the caster learns to tell a happy spirit from a worried one by that last note. |
| 3 | **Crystal Ear** | Stonecraft | Sensing | E | Sensing through stone: pulse ring and the vibration outline with a low-end ping. | Each glint appears with a soft chime whose pitch drops as the weight rises, so a heavy footfall sounds like a low bell in the dark. |
| 3 | **Gravelswarm Skitter** | Stonecraft | Hex | D | Hex on the floor: the stream of stones as a footing penalty. | The pebbles all stop at the same instant on the last click, and the sudden silence tells every runner to look down. |
| 3 | **Foamstep Cushion** | Tidecraft | Mobility | F | Mobility landing: the froth puff, the 3 degree FOV kick and the soft landing sound. | The caster's landing sound is a soft chime rather than a thud, and the bubbles pop in a quick descending run like keys on a xylophone. |
| 3 | **Raincall Veil** | Tidecraft | Utility | F | Utility: persistent, low-cost marker with the 1.5 s fade and the performance budget. | In the last second the rain slows to single drops that fall in perfect rhythm, like a clock winding down. |
| 3 | **Duskbind Chain** | Umbral | Binding | D | Shadow Binding: dim silver rim, the Dark aura and a slow break in strong light. | The chains stop clinking one second before they dissolve, and in that silence the target can hear nothing but their own breath. |
| 3 | **Raven Mark Sigil** | Umbral | Utility | F | Utility sigil in near-black plum with the silver edge rim. | The faint caw arrives in the caster's ear half a second before they see the sigil, as if the mark had been waiting for them. |
| 3 | **Greenpulse Sense** | Verdance | Sensing | E | Sensing through roots: a slow pulse that follows the ground. | Each pulse is a little slower than the last, until the forest's own slow rhythm takes over and the caster's breathing matches it. |
| 3 | **Canopy Screen** | Verdance | Illusion | D | Illusion by foliage: the veil's opacity and the caster's outline fade. | The last leaf to spring back always rustles twice, as if the tree itself were checking nobody saw. |

