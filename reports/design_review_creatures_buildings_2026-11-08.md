# Design review: rebuilt creature and building contact sheets (2026-11-08)

Reviewer: anime-fantasy-director. Follows `reports/design_review_2026-10-31.md` and the fixes in `reports/blender_wave_2026-11-02/`.

## Looked at (all opened)
`reports/blender_wave_2026-11-02/toon/creatures_toon_v2.png`, `toon/buildings_toon_v2.png`, `creatures/after_dragons.png`, `creatures/after_faces.png`; `reports/toon_preview_2026-10-31/creatures_toon.png`, `buildings_toon.png`, `dark_families_toon.png`. Read `blender_wave_2026-11-02/creatures.md`.
**Not opened:** `after_bipeds`, `after_control`, `after_mushrooms`, the building before/after folders, `mushrooms_toon`, `whisperwood_vs_aldmere_toon`, and the per-family sheets in `13_Production/screenshots/` (only 12 creatures and 6 buildings are on the v2 sheets, out of 680 species and 28 building types). Verdict covers the sampled set only. No in-game (Unity, `Ascend/Toon`) renders were checked.

Verdict: **Buildings PASS. Creatures PASS WITH FIXES** (strong faces and silhouettes, weak surface treatment and a few placeholder-looking props).

## Protect
**Buildings**
- Region identity is excellent: thatch and blue shutters (Brindlewick), hip-roof stone with ochre trim (Iron Hold), narrow purple-slate with violet windows and lanterns (Umbravel), stilt timber with teal shutters (Greymoor), paper lantern post (Hoshizora) against brass gas lamp (Gearholm). Each reads as a different place in silhouette and colour with no label.
- Ink lines are thick enough to survive thumbnail size, roof texture is painted not noisy, and small warm lights (windows, lanterns) give the "lived-in at dusk" feel.
- Same family, two types (house and smithy) share materials: kit consistency works.
**Creatures**
- The faces fix landed. Goblin amber slit eyes, werewolf glow irises, skeleton violet eye-lights, mushroom big dot eyes and tiny "o" mouth, mandrake mismatched eyes: every creature has a readable face from front and 3/4, as `art_direction.md` section 6.1 requires.
- Menace-by-rank reads: slime, rabbit, mandrake and mushroom are cute first; werewolf, orc and scarecrow carry weight.
- Size ladder against the grey human reference works (0.30 m rabbit to 6.55 m dragon).
- Slime: dome with a flat skirt, two glossy dot eyes: iconic and original.

## Resemblance check
- **Goblin: caution (medium).** Bald green head, long horizontal pointed ears, wrinkled face and a small robe-like shirt together read close to a famous green elder from a film franchise. Fix below (G1). Cleared once ears and head are changed.
- **Slime: cleared.** Dome + skirt, no pointed drip tip, no smile. Keep it: do not add a wide smiling mouth or a teardrop tip.
- **Skeleton: cleared** (generic undead cast; cape and shoulder pads are common).
- Rabbit with a spiral horn, crow, mandrake, wolf, mushroom, orc, werewolf, dragon: generic genre cast. Dragons: no specific design copied (wings 2.2 x body is the new rule).
- Buildings: no specific building or town copied; the thatch-and-blue-shutter cottage is common fantasy-village vocabulary.

## Problems, priority order
Owners: **creature-artist** for creatures and species profiles; **environment-artist** for buildings and props; **technical-artist** for shader; **bestiary-designer** for species data.

### C1 Creatures look like glossy plastic or glass, buildings look painted: the two do not match
Evidence: wolf, goblin, orc and scarecrow show soft translucent-looking sheen and broad specular bands (the wolf looks like grey jelly). `art_direction.md` section 3 says no PBR gloss on fur, cloth, skin, stone: one painted highlight blob on gel, eyes, metal and wet surfaces only. Buildings follow the rule; creatures do not, so a goblin standing at a house door would look like it came from a different game.
Fix: in the preview and in `Ascend/Toon`, give creature materials the same two-tone ramp as the buildings, specular off except on slime, eyes, metal; add a hand-painted fur/skin value shift (one darker patch on underside and one lighter on the back). Check the wolf and goblin first. Owner: technical-artist, creature-artist.

### C2 Floating brown slabs on goblin, werewolf, orc and scarecrow
Evidence: a plain rectangular brown board hangs at the hip of four bipeds (the `weapon_socket` or loin flap) and extra square patches float at shoulders and arms (werewolf, orc, scarecrow). They read as cardboard, not as cloth or armour. The loincloth fix is visible on the werewolf and orc but the slab remains in the goblin and scarecrow.
Fix: make every wearable carry a clear shape: loincloth with a curved hem and folds (already built, apply to all), pauldrons as rounded half-domes with a rim colour, and strip the rectangle where no look text asks for a shield. Per-species rule: if the look text says shield, draw a round or kite shield with an emblem, else nothing. Owner: creature-artist; bestiary-designer to confirm look text per biped (goblin, scarecrow, werewolf).

### C3 Limbs are uniform sausages on the large bipeds
Evidence: werewolf, orc and scarecrow arms are the same width from shoulder to wrist with no elbow or hand shape; the werewolf hands are dots. Section 5 wants chunky stylised but readable gestures.
Fix: add hand shapes (mitt with three clear fingers and a thumb for the orc and werewolf), an elbow bend of at least 10 degrees in the idle pose, and a wrist cuff. Wrist at 0.72 r of the forearm top is already in the taper rule: confirm it applies to arms on the sheet, since it is not visible. Owner: creature-artist.

### C4 Dragons: big wings, tiny body, one silhouette
Evidence: `after_dragons.png` shows four recolours of one shape; at 320 px the body is smaller than the wing scallops and the pose is flat (wings spread, no head or tail read). The report itself lists this as open.
Fix: raise the body to at least 35 % of the visible silhouette area; give each species a hero feature: Young Dragon a short crest and curled tail, Drake Lord a horn crown and heavier forelimbs, Wyvern no forelimbs (wings as arms) and a barbed tail, Hatchling oversized head and small wings. Show them in a rearing or perching pose on the sheet, not in T-spread. Owner: creature-artist, bestiary-designer for the look text.

### C5 Flat props sit below the house standard (market stall)
Evidence: the stall canopy is a single flat red plane with a wavy edge, produce is smooth blobs, and the counter is a flat box. Houses beside it have thatch, timber frames and ivy.
Fix: give the canopy a visible thickness (3 cm), a scalloped valance, and two stripes of the region accent; add crate edges and a hanging sign. Same ink weight as houses. Owner: environment-artist.

### C6 Shared lamp-post proportions
The Gearholm lamp post (4.24 m) and Hoshizora post (3.53 m) are tall relative to a 1.7 m player (about 2.5 times); lamp heads read well but sit above eye line, so the glow is lost at gameplay camera. Fix: 3.0 to 3.4 m for town posts, keep tall ones for gates and bridges. Owner: environment-artist. Minor.

### C7 Sheets are not showing the full variety
Only 12 of 680 species and 6 buildings appear on the primary sheets, all medium detail at 320 px. Gaps for the next pass: a tall B-rank boss silhouette test at 60 m (three masses rule), a gentle familiar, and a pack of five goblins to check repetition. Owner: producer to schedule; creature-artist to render.

## Verified facts
- Species counts (680) and rules from `art_direction.md` section 5 and `creatures.md`; wing ratio 2.2 and loincloth fix read from `creatures.md`.
- Slab and sheen observations are from the v2 PNGs; I did not confirm which `features.*` call draws the slab (guess: `weapon_socket` at idle). creature-artist should verify.
- Lamp post ratio is calculated from sheet labels (4.24 / 1.70).

## Follow-ups
- Re-review after C1 and C2 fixes with an in-game screenshot (needs Unity, owned by another session).
- Canon: none.
