# Character v3 audit: the two base humans

Status 2026-11-08. Scope: a procedural Blender generator for the male and female player bodies, from which every other human is a data variant. Not in scope: facial animation, cloth physics in Unity, Unity import, other races, the full NPC population.

## What existed
| Existing | Where | Used how |
|---|---|---|
| Creature add-on (metaball bodies, per-vertex `Col` colour, `ac_*` object properties) | `Tools/blender/ascend_creatures/` | Pattern copied: package + CLI + `Col` point attribute + material reading it |
| Building add-on (`Geo` accumulator, palette materials) | `Tools/blender/ascend_buildings/` | Not reused for meshes (the human is a quad tube, not instanced parts); `preview`/`library` helpers reused by the toon preview |
| Rig builder (bones from data, FBX export with the Unity axis fix) | `Tools/blender/build_rig.py` | `export_fbx` reused for the rigged export; the bone data is new (Unity Humanoid names, not the monster rig keys) |
| Toon preview and contact-sheet standard | `Tools/blender/toon_preview.py` | All character sheets use it (two-tone, rim, ink hull) |
| Game-weight bake | `Tools/blender/bake_to_game.py` | Sidecar JSON conventions followed; the human is already game weight (about 10k triangles per body at one subdivision), so no decimate pass |
| Player Animator and `PlayerAnimationDriver` | `Game/Assets/_Game/Runtime/Player`, `animation_v11_audit.md` | Read only. Today a graybox with a Generic rig; `FootIK` already has an untested Humanoid path |

## What the Animator expects of a humanoid
From `animation_clips_required.md` and `FootIK.cs`: a **Humanoid** avatar (`animator.isHuman`), 30 fps clips authored on a Humanoid rig in T-pose or A-pose, facing +Z, feet at y = 0, in place (the `PlayerMotor` moves the body), stride matched to 2.2 / 6.5 / 9.5 m/s. Foot IK uses `OnAnimatorIK` goals, so the avatar must map both feet. So the rig contract is the 52 Unity `HumanBodyBones` (Hips to Toes plus 15 finger bones a hand), named exactly as Unity expects, with Hips as the root.

## Design decisions
1. **One connected quad mesh per body**, not parts glued together: a chain of 18-vertex rings from crotch to crown, arms leaving through a 3 x 2 hole on each side, legs from the two halves of the lowest ring, a flat hand slab whose end face is four quads (one per finger), the thumb from a side quad, feet bent from the leg tube. Closed and manifold; one Catmull-Clark level gives the final mesh.
2. **Clothes use the same builder** with an outward offset, so they fit every variant by construction and inherit the weights.
3. **Face = smooth head + projected decals.** Eyes, brows and mouth are thin patches raycast onto the head surface, so they follow any head shape. They are separate objects with shape keys (blink, brows, smile, open). The nose wedge, chin and brow come from the rings.
4. **Proportions** 7.25 heads, legs 52 % of height, small hands and feet, clear waist (`art_direction.md` section 5). Both bodies from the same tables; the female body is not a re-skin of the male one (narrower shoulders, softer chest, same hip joint height), and neither is sexualised: smooth mannequin body, modest clothing, no anatomical detail.
5. **Colour** is per-vertex (`Col`), palettes in `Data/Characters/human_library.json`. No textures.
6. **Variants by data**: height inside a band, build, age, skin, hair style and colour, eyes, outfit colourway, cloak. Deterministic: `spec.rng` seeds everything, and a vertex hash proves it.
7. **Rig** is fixed for all variants: 52 humanoid bones plus 10 extra chain bones (hair and cloak) that Unity's avatar ignores. Rest pose is a T-pose.

## Risks noted
- Shape keys with the FBX exporter's axis fix (`transform_apply`) are checked early.
- The toon preview doubled the T-posed arms at a camera pitch above 0; the turnarounds therefore use a relaxed pose and a pitch check.
- `blender -b -P` exits 0 when a script raises; every check runs with `--python-exit-code 1`.
