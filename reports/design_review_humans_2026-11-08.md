# Design review: human base bodies and variants (2026-11-08)

Reviewer: anime-fantasy-director. Branch reviewed: `claude/humans-base-aca467` (commit `e4fa7766`).
Looked at: `13_Production/character_male_base.png`, `character_female_base.png`, all 8 turnaround sheets and the face sheet `human_male_sturdy_dark_face.png` in `reports/characters_2026-11-08/` (male: base, young_slim, sturdy_dark, elder_wayfarer; female: base, young_slim, sturdy_tall, elder_scholar). **Not opened:** the other 7 `*_face.png` sheets, the rigged export and any in-game (Toon shader) render: those need Unity or a Blender run. Verdict is on the toon preview only.

Verdict: **PASS WITH FIXES.** The pipeline is sound and the base reads as AETHWYRD, but three things must change before the bodies are locked: hair, the costume template, and face readability at gameplay distance.

## Protect (works, do not change)
- Clean ink hull, two-tone shading and rim light match `art_direction.md` §3. Same look as the creatures and buildings.
- Colour blocking is bold and readable at thumbnail size (blue/ochre/brown, purple/ochre/olive, orange/slate). One accent per figure.
- Skin range is wide and warm; no skin tone is greyed out. Eye colours vary.
- Modest costumes, neutral mannequin body, nothing sexualised. Teen rating holds. Warm, open default smile (not a smirk), as §6.2 asks.
- Height spread 1.62 to 1.86 m and build spread (slim, sturdy) read in the front view.
- Face decal approach gives clean anime eyes, brows and a mouth line from front and 3/4.

## Resemblance check
No figure resembles a well-known character or costume. Checked: hair shape + colour, colour triad, outfit silhouette, accessories.
- Female base (orange hair in two long side tails, green eyes, slate skirt): common archetype, not a specific character. **Guard:** do not add a signature item (a single giant hair ribbon, a red scarf, a straw hat, a cloak+goggles combo) without checking.
- Male base (brown spiky fringe, blue tunic, brown shoulder guards): generic.
- Elder wayfarer and elder scholar (silver/lavender hair, ochre trim): generic.
Status: CLEARED for the current set. Re-run this check on every named hero and companion.

## Problems, priority order
Owners: **creature-artist** does not own humans; the character generator is the work of the `humans-base` session (Blender `Tools/blender/ascend_characters`, `Data/Characters/human_library.json`). Findings below name it "character generator owner" (animator-rigger for rig, technical-artist for shader).

### P1 Hair reads as tangled dreadlock ribbons (young_slim, sturdy_tall, female base)
Why: thin flat strips splay outward with gaps, hang to the waist, and cast no clear "hair mass". Anime hair is 3 to 6 big tapered clumps over a smooth scalp cap with a highlight band; this looks messy and unfinished, and the silhouette is wider than the shoulders in young_slim (hair width about 1.5 x shoulder width).
Fix (character generator owner): scalp cap covering the full crown; 4 to 6 clumps per side, each 2.5 to 3 x the current strip width, tapering to a point; default max length = shoulder blade (long styles are a variant, not the base); keep side strands within 1.15 x shoulder width; add the "angel ring" highlight band at 25 % down the hair mass (§6.2); remove the visible scalp parting gap on the 3/4 view of the female base.

### P2 Costume template is the same shirt, recoloured, so variants do not differ in silhouette
Why: all 8 share cape-like shoulder pads, hem band, wrist bands and boots. Elder and young differ only by hair colour; the elder scholar does not read as a scholar. Genre rule: silhouette first, colour second.
Fix (character generator owner): ship at least 4 outfit silhouettes in `human_library.json`: (a) short tunic (current), (b) long coat to knee, (c) robe/apron with sash, (d) hooded travel cloak. Pauldrons only on (a). Age cues: elders get slightly lower shoulder line (-2 %), a stoop of 3 degrees, and one visible accessory (scarf, staff loop, spectacles shape on the face decal).

### P3 Face unreadable at gameplay distance, and lacks life
Why: at the full-body 1.7 m framing the eyes are about 4 px, so every character looks identical-faced. In the close-up the eyes are inside spec (§6.2: 20 to 24 % of face width) but the brown iris on dark skin loses its edge, the nose is a single tick, and one hard diagonal shadow band across the face (see `sturdy_dark_face`) reads as a stain or half mask.
Fix: eyes +15 % (to the top of the 24 % band) and a thicker upper lash line; iris lightness at least 25 points off skin tone, so on dark skin pick a lighter iris or a bright catch-light pair; soften the face shadow into the §6.2 hand-authored face normal (no diagonal band: shadow shape follows the jaw and under the hair fringe only); nose = soft shade wedge, not a line. Owner: character generator owner (decals), technical-artist (face shadow in `Ascend/Toon`).

### P4 Female skirt is a rigid cone, male trunk is bulky; waist is not clear
Why: §5 asks for a clear waist and long legs (leg = 52 %). The skirt is a stiff A-line with a flat hem that floats like a lampshade, hiding the hip joint. On males the wide hem band plus tunic make a boxy block and the thighs balloon above thin knees.
Fix: skirt in 6 to 8 gores with a slight scalloped or split hem, length to mid-thigh, hem trim at half the current width; belt thicker and one accent colour so the waist shows; male tunic hem band -40 %, thigh radius -8 %; check leg length against 52 % with the proportion check.

### P5 The white diamond at the belt
Why: it floats and reads as paper stuck on the hip, in every figure. A prop that cannot be explained is noise.
Fix: make it a deliberate item: a pouch or an Aether shard charm hanging on a strap, in the accent colour, or delete it. Owner: character generator owner.

### P6 Black jagged strip at the back of the belt (back views)
Why: a spiky fringe looks like a rendering glitch.
Fix: smooth belt ring; if it is a buckle or tabs, make them evenly spaced rounded tabs.

### P7 Mannequin details
- Boots are plain tubes: add a rounded toe cap and a heel step; feet look tiny against the calves (small feet are right, but too small shortens the stance).
- Hands in the A-pose are splayed straight; relax the fingers 10 degrees inward.
- Neck cylinder is visible below the egg-shaped head: taper the jaw into the neck and add a collar on every outfit.
- Ears are small and flat: fine, but raise 5 % to meet the lash line.

## Verified facts (so the next reviewer can trust the list)
- Heights read from the sheet labels: M base 1.72/1.74, young slim 1.72, sturdy dark 1.86, elder 1.74; F base 1.66, sturdy tall 1.74, elder scholar 1.62.
- Hair-width figure in P1 is an eyeball estimate from the front view, not measured.
- Eye pixel size in P3 is an eyeball estimate from the 640 x 960 render.

## Follow-ups
- Re-review after the regenerated renders (job: `humans-base` rework P1, P2, P3).
- The `human_library.json` outfit list change needs the schema and validator to accept new silhouettes: tools-pipeline-engineer.
- Canon impact: none; no §6 proposal needed.
