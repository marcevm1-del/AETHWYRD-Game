# Character system: the two base humans and their variants

Generator: `Tools/blender/ascend_characters/` (package) and `Tools/blender/build_character_library.py` (CLI). Data: `Data/Characters/human_library.json` (schema `Data/Schemas/characters.schema.json`, checked by `npm run build`). Audit and design decisions: `character_v3_audit.md`. Key images: `character_male_base.png`, `character_female_base.png` here; turnaround sheets in `reports/characters_<date>/`.

Everything is procedural and original. No third-party mesh, texture or generated image is used.

## Generate
```
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_character_library.py                   # all 8 variants (2 bases + 3 samples each)
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_character_library.py -- --ids human_female_base
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_character_library.py -- --variant '{"body":"human_male_base","seed":7,"build":"sturdy","age":"older","heightM":1.80}'
options: --no-sheets --no-export --no-blend --hash-only --levels 1 --date YYYY-MM-DD --out <dir> --reports <dir>
```
`--python-exit-code 1` is required: without it Blender exits 0 even when the script raises, so a broken rig would pass.
In Python: `generate.character("human_female_base")` or `generate.character({...})` returns `{spec, layout, armature, parts, hash}`.

Output (gitignored, local): `Art/Blender/CharacterLibrary/<id>/<id>.fbx` (rigged, Unity axis fix), `.glb` (viewing), `.blend`, `<id>.json` (sidecar: bones, parts, materials, shape keys, swap groups).

## Checks
`blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_characters.py [-- --hashes <file>]`: every variant generates and validates; same seed gives the same mesh hash (in one process, and across processes with `--hashes`); a different seed changes the mesh; a renamed bone, stripped weights and a broken hierarchy are each caught by the validator. `npm run build` checks the JSON (references resolve, heights inside their band, the 52 required bones). `py_compile` all new Python files.

## Data fields (`human_library.json`)
- `bodies[]`: `id`, `sex`, `heightM`, `heightBand`, `headsTall` (7.25), and measurements as fractions of height (shoulder, chest, waist, hip half-widths, chest depth, neck, head, limb lengths, hand and foot size, eye width and height ratio).
- `builds[]` (slim, average, sturdy): multipliers on girth, shoulders, waist, limbs. `ages[]` (young_adult, adult, older): head scale, eye scale, jaw, stoop, brow drop; older variants also grey a non-grey hair colour.
- `palettes`: `skin` (hex plus a blush tone), `hair` (root hex plus a lighter tip), `eyes`, `outfit` (primary, secondary, trim, leather, cloak).
- `hairStyles[]` (5 male, 6 female), `outfits[]` (the Rank-F adventurer in a male and a female cut).
- `variants[]`: `body`, `seed`, `heightM` (inside the body's band), `build`, `age`, `skin`, `hair {style, colour}`, `eyes`, `outfit {id, colours}`, `cloak`, optional `earLength` (1.0; later races lengthen it).
- `rig`: the 52 required bone names, the 10 extra chain bones, 4 influences.

A new human is a new `variants[]` row, never new code. All randomness is `random.Random(body|seed|purpose)`, so a row always gives the same mesh (`hash` in the sidecar).

## The body
One connected quad mesh per body, closed and manifold: a chain of 18-vertex rings from crotch to crown; arms leave through a 3 x 2 hole on each side; legs start from the two halves of the lowest ring; the hand is a slab whose end face is four quads, one per finger, with the thumb from a side quad; feet bend forward from the ankle. One Catmull-Clark level gives about 10k triangles; with hair and outfit a character is about 21k to 25k triangles (budget: player 30k, `art_budgets.md`). Proportions: 7.25 heads, legs 52 % of height, small hands and feet. The female body has narrower shoulders and a softer chest, the same hip joint height, and is not a recolour of the male one. Both are smooth mannequins under modest clothing: no anatomical detail, no revealing outfit.

Parts (separate objects, swappable): `body`, `eyes`, `brows`, `mouth`, `ears`, `hair`, outfit parts `top`, `bottom`, `skirt` (female), `belt`, `boots`, `bracers`, `cloak`. The face is a smooth head plus thin decals projected onto it (sclera, iris, pupil, two highlights, lash line, brows, mouth), so they fit any head. Shape keys (the only facial rig; no facial animation system): eyes `blink_L`, `blink_R`; brows `brow_up`, `brow_down`; mouth `smile`, `open`.

Colour is per-vertex (`Col` point attribute, linear), the creature pipeline. Materials are categories: `CH_skin`, `CH_face`, `CH_eyes`, `CH_hair`, `CH_cloth`, `CH_leather`, `CH_metal`.

## The rig contract
Unity `HumanBodyBones` names, one hierarchy, for every variant: `Hips > Spine > Chest > UpperChest > Neck > Head`; `UpperChest > {Left,Right}Shoulder > UpperArm > LowerArm > Hand > 15 finger bones (Thumb/Index/Middle/Ring/Little x Proximal/Intermediate/Distal)`; `Hips > UpperLeg > LowerLeg > Foot > Toes`. No root bone above Hips. Rest pose: T-pose, facing -Y in Blender (+Z in Unity after the export's axis fix, as for monsters). Extra chains that the Humanoid avatar ignores (always present, weighted or not): `HairBack_1..3`, `HairSideL_1..2`, `HairSideR_1..2` (children of Head) and `CloakBack_1..3` (children of UpperChest). Weights: 4 influences at most, summing to 1, every body vertex weighted, every humanoid bone used by the body. `ascend_characters/validate.py` checks all of this (names, parents, mirror symmetry, bone length, weights, topology, height) and `check_characters.py` proves it fails loudly.

`rig.pose_test()` is a relaxed stance used for the turnarounds; `rig.pose_rest()` returns to the T-pose.

## How Unity should import it (for the art-unity session)
1. Import `<id>.fbx`; Rig > Animation Type **Humanoid**, Avatar Definition **Create From This Model**; check the Configure window maps all 52 bones (the T-pose is the rest pose).
2. Keep each part's mesh as its own SkinnedMeshRenderer; swap hair or outfit by enabling parts. Materials map by name to the toon shader; the base colour is the vertex colour `Col` (import colours; no textures).
3. The sidecar JSON lists parts, groups (`body`, `face`, `hair`, `outfit`), shape keys and the extra bones to drive as spring bones. Cloth physics and facial animation are not built.
4. Clips need the Humanoid avatar (`animation_clips_required.md`); `FootIK`'s Humanoid path becomes live.

## Known limits (v1)
Hair is a stylised lock system (flat pointed locks), good for silhouettes and colour, not a final groom; clothes are single-sided shells with the toon outline closing their edges; no tongue or teeth; hands are simple (fingers do not curl in the rest pose). These are the first things to refine after the Unity import.
