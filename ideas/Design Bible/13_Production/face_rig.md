# Facial shape-key rig and expression set (animator-rigger, job 4)

A complete set of facial shape keys and 19 expressions for the human bases, built on the face the character generator already makes (thin decals projected onto the head: eyes, brows and mouth as three objects). **No lip-sync, no visemes, no facial animation system**: the game blends expression weights and runs the blink data. Original and procedural. Key image: `face_rig_images/human_male_base_expressions.png` (all 19 expressions, front view, hair hidden so the brows read).

## Build and check
```
set ASCEND_CHARACTERS_DIR=<folder holding ascend_characters>       (only until branch claude/humans-base is merged)
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_face_rig.py [-- --bodies human_male_base --sheets <dir> --no-export --no-manifest]
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_face.py [-- --self-test]
```
Output: `Art/Blender/AnimationLibrary/Faces/<body>/<body>.fbx` (gitignored; the character exporter's rigged FBX plus sidecar JSON, now carrying the new keys) and the committed manifest `Data/Characters/face_expressions.json` (every key per part with measured displacement, the legacy keys, the expressions, the blink data). `npm run build` validates the manifest (`Tools/validate/animation_checks.js`).

## How it is built
`Tools/blender/ascend_animation/face_rig.py`. The generator's own `Face` builder is run again on the same head, and the result must reproduce each decal object's vertices exactly (else `apply` raises: a changed generator cannot silently shift the keys). Each key moves vertices of the decal's 2D layout (the iris, the upper lash line, one end of a brow, the mouth's lower edge) and projects them back onto the head surface with the generator's projection, so a moved vertex stays on the skin on every head shape. `apply` adds the keys next to the generator's six and leaves those untouched. Expressions: `ascend_animation/face_expressions.py`.

## The keys (33, plus the generator's 6)
| Part | Keys |
|---|---|
| eyes | `eyes_close_L/R` (a calm U-shaped closed eye), `eyes_happy_L/R` (the closed ^ ^ smile), `eyes_wide_L/R`, `eyes_narrow_L/R` (half-lidded), `eyes_look_left/right/up/down` (iris, pupil and highlights move inside the eye) |
| brows | `brow_up`, `brow_down`, `brow_inner_up`, `brow_inner_down` (the inner ends also draw together), `brow_outer_up`, `brow_outer_down`, each `_L` and `_R` |
| mouth | `mouth_smile_wide`, `mouth_frown`, `mouth_smirk_L/R`, `mouth_open_small`, `mouth_open_wide`, `mouth_o`, `mouth_pressed`, `mouth_pout` |
| generator's (kept as they are) | `blink_L`, `blink_R`, `brow_up`, `brow_down`, `smile`, `open` |

L is the character's left (+X). Weights are 0..1 (Unity blend-shape weight = 100 x). A closed or happy eye sinks its sclera, iris and highlights 4 mm under the skin and moves the lash line into a closed arc, so no eye ever shows through a closed lid.

## Expressions (weights over the keys; Data/Characters/face_expressions.json)
neutral, happy, joy, laugh, sad, worried, angry, surprised, shy, smug, determined, tired, pain, embarrassed, thinking, sleepy, sulking, wink, blink. Smug, thinking and wink are deliberately asymmetrical. Blink data for the game's face driver: interval 2.0-5.5 s, 0.06 s closing, 0.03 s hold, 0.09 s opening, a 12 % chance of a double blink. Default blend between expressions 0.18 s (0.08 s to or from `blink` and `sleepy`).

## What is measured (both bases, plus determinism)
Every key moves its decal (at least 0.5 mm, at most 40 mm, no NaN), the L/R pairs mirror (within 1.5 mm across the face and 5 mm in depth; the head surface itself is not perfectly symmetric), every expression names only existing keys with weights in 0..1, no two expressions are the same face (the closest pair, happy and shy, differs by 3.5 mm at its most different vertex), nothing is named like a viseme or phoneme, the legacy six survive, and a second build gives identical displacements. `check_face.py --self-test` kills a key, breaks a mirror pair and adds a viseme-named expression and fails unless each is caught (all three were). The first runs also corrected two of my own checks: the mirror test compared vertices by index although a ribbon on the right side runs the other way, and "distinct" was an RMS that diluted real differences.

## Findings for the character generator (not mine to edit; humans-base session)
Both findings come from reading `generate.py` and `face.py`, not from a measurement.
- The generator's own mouth keys `smile` and `open` are indexed over *all* mouth-object vertices in two halves, but the object also holds the nose tick (10 vertices after the 18 mouth vertices), so the halves do not match the top and bottom edges: `open` pushes part of the lower lip and the nose tick down. The new `mouth_smile_wide` and `mouth_open_*` do not have this problem and are selected by tag. Suggest the generator drops its two mouth keys, or fixes the index, once the new rig is merged.
- The generator's `blink_L/R` only shifts the whole eye down 40 % rather than closing it; `eyes_close_L/R` closes it properly. Both are kept.

## Integration (when branch claude/humans-base is merged)
`face_rig.apply(ch)` takes the dict `generate.character` returns, so one call at the end of `generate.character` (before the export) puts the keys into every variant, sample variants included, instead of only the bases that `build_face_rig.py` exports. Until then the bases get them from `build_face_rig.py`, and `check_face.py` proves the rig on both.

## Not done / not verified
- Unity: nothing imported or run. The new keys arrive as blend shapes on the three face renderers (`<id>_eyes`, `<id>_brows`, `<id>_mouth`); a face driver script that blends an expression's weights and runs the blink data is the gameplay or ui engineer's to write.
- Only the two bases were checked and rendered; the six sample variants (and later races with longer ears or other head shapes) go through the same code but were not run, to keep the shared GPU free.
- No tongue or teeth (the generator has none), so `mouth_open_wide` shows the skin colour inside the lips as a dark red shape; no cheek blush or sweat-drop decals (those would be new geometry); no eyelash-thickness changes per expression beyond the closed eyes.
