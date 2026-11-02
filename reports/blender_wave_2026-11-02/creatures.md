# Creature fixes, Blender wave 2026-11-02

Follow-up to `reports/design_review_2026-10-31.md`: C1, C3, C5, mushroom faces and N4. All the code is in `Tools/blender/ascend_creatures/`, and `13_Production/creature_system.md` is updated.

**How the sheets were made:** Blender 5.2.3, headless with software OpenGL, medium detail, 320 px tiles, yaw −35°, pitch 14°. "Before" is a clean worktree of `origin/main` (ee7f861). Both before and after use that worktree's `ascend_buildings` preview code, so the other agents' live edits don't skew the comparison.

## Fix to function

| Item | Fix | Function | Before / after |
|---|---|---|---|
| C1 werewolf eyes | `eye_size` 0.26, snapped onto the skull surface (the old eyes were buried in the metaball swell; the code had 0.27, not 0.22). Glowing amber iris `#FFB347` in a narrowed dark almond with a slit pupil and no white. Brow ridge 0.15 hr deep | `plans.biped`, `features.eyes` (`glow_iris`), `features.organic` (`b.brow`), `looks.palette` | [before](creatures/before_faces.png) / [after](creatures/after_faces.png) |
| C1 skull | Cranium, narrower upper face, cheekbones and carved sockets. Dark sockets r 0.22 hr `#2A2238` with a glow point r 0.12 hr. Separate jaw 0.05 hr below the upper face, square teeth, no nose, no lids, bone `#E8DFC8` | `plans.skull`, `features.skull_parts`, `features.eyes` (`socket`) | same sheets (Skeleton, Skeleton Knight, Greater Skeleton) |
| C3 wings | Tip-to-tip span / nose-to-tail length: Young Dragon and Hatchling **2.22**, Drake Lord and Wyvern **2.25** (was about 1.5). Thicker finger bones (4 per wing) and scallops 2.5× deeper | `plans.dragon` (`wing_span`), `features.wings` | [before](creatures/before_dragons.png) / [after](creatures/after_dragons.png) |
| C3 legs | Digitigrade hind legs (hip, knee forward, hock, toes) with thighs 1.4× the forelimb radius (0.098 vs 0.07). Shoulders at 0.8× the hip height (0.336 vs 0.42), so the back slopes | `plans._dleg`, `plans.dragon` | same |
| C3 tail | The tail is about 1.1 units, longer than the 0.74 torso, and ends in a flat spade. `tail_blade` draws as the spade on dragons | `plans.dragon`, `features.dragon_spade` | same |
| C3 check | At 64 px in solid black, at the sheet angle and from the side, no dragon can be mistaken for the Forest Wolf | — | [64 px](creatures/silhouette_64px_dragons_vs_wolf.png), [×4](creatures/silhouette_64px_dragons_vs_wolf_x4.png) |
| C5/N4 loincloth | A trapezoid (top 0.8× hip width, bottom 0.55×, 0.35× leg long) in two segments with a 10° flare. It is curved round the hips, with folds, a back flap at 0.85× the length and a waist cord. Cloth `#8A5A35` with a 0.03 m hem in `#5A3820` | `features.loincloth` | [before](creatures/before_bipeds.png) / [after](creatures/after_bipeds.png) |
| C5 taper | Biped thigh and upper arm swell to 1.15 r0; knee 0.95 r1, ankle and wrist 0.72 r1. Thigh to shin is ≥ 1.6×. Quadrupeds, plants and other plans keep the old taper | `plans.leg/arm(taper=True)` | same |
| C5 ribcage | 5 thin ribs (was 6) that slope down to the front, with wide gaps and a short sternum | `features.ribcage` | faces sheets |
| C5 sword | Blade width = max(0.1 × size, 7 cm): the Orc Grunt goes from 11.7 to 19.5 cm, the Skeleton Knight from 5.8 to 9.7 cm. A dark fuller is added | `features.weapon`, `Ctx.metres` | bipeds and faces sheets |
| Mushroom faces | F–E: dot eyes 0.36, 24°, `eye_up` 0, a tiny "o" mouth 0.12 hr, no teeth, no painted spots on the face. Spore Lords: teeth plus glowing irises. Growths keep their edge ≥ 0.5 hr from any eye's edge (all species) | `plans.plant`, `features.mouth`, `features.mushroom_mouth`, `features.growths`, `body.paint` | [before](creatures/before_mushrooms.png) / [after](creatures/after_mushrooms.png) |
| Control set | Slime, goblin, horned rabbit, forest wolf, crow, mandrake | — | [before](creatures/before_control.png) / [after](creatures/after_control.png) |

## Notes for others
- **bestiary-designer:**
  - The Spore Lord and Bog Spore Lord are rank C, but the review treats Spore Lords as B+. They get the lord face because they are matched on the name.
  - The Orc Grunt's look text says "dented iron axe", but its part is `weapon_socket`, which draws a sword.
- **Shared plans:** the Gargoyle and the Arch Demon use `wyvern_base`, so they get the new wings, legs and spade tail too.
- **Still open:** at sheet size, the 2.2× wings leave the dragon body small in its tile. All four dragons share one silhouette; a per-species hero shape would help.
