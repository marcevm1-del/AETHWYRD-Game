# 13d — Monster Model Pipeline

How every monster gets a 3D model, where the files live, and how to redo one. Decided 2026-10-24 by the creative director:
**AI-generate all 680 species from our own text, Ring order first; keep the model files on the local PC; GitHub and the vault carry the information.**

## Steps
1. **Prompt** — `node Tools/monster_gen/build_model_prompts.js` writes `Art/Generation/monster_model_prompts.json`: one prompt per species built only from our own design data (`look`, signature, size) plus the house style (anime, cel-shaded, single creature, neutral pose). Proper names are stripped; no outside artwork is used, so the designs stay ours. Order: Ring 0, then Ring 1 (bosses first), and so on.
2. **Generate** — in Blender with the MCP add-on connected, `generate_3d` from the prompt (one paid generation per species).
3. **Check by eye** — look at the model from the front; if it faces the wrong way, `turn("<object>", degrees)`.
4. **Finish** — `exec(open(r"E:/Ideas/Project-Ascend/Tools/blender/finish_generated_monster.py").read())` then `finish("<object>", "<species_id>", provider="...")`: joins the parts, scales to the real size in `species.json` (height for "tall", length for "long"), puts the feet at the origin, caps triangles (6k under 0.6 m · 12k under 2.5 m · 20k under 8 m · 30k above), exports FBX with embedded textures to `Game/Assets/_Game/Art/Models/Monsters/<Family>/<species_id>.fbx`, and records the result in `Art/Generation/monster_models.json`.
5. **Unity** — the scene builder uses `<Family>/<species_id>.fbx` when it exists and falls back to the blockout. The procedural animation layer (`MonsterAnimator`) works on any model.
6. **Info** — `npm run vault` shows each monster's model status in its note; commit and push the registry.

## Where things live
| What | Where | In git? |
|---|---|---|
| Prompts | `Art/Generation/monster_model_prompts.json` | Yes |
| Model registry (status, date, generator, tris, size, local path) | `Art/Generation/monster_models.json` | Yes |
| Generated FBX models | `Game/Assets/_Game/Art/Models/Monsters/<Family>/` | **No** (local only; several GB for all 680, over GitHub's free LFS) |
| Ring 0 hand-built models | `Game/Assets/_Game/Art/Models/Monsters/*.fbx` | Yes (LFS) |
| Blockout turnarounds (all 680) | `08_Bestiary/turnarounds/<Family>/` | Yes (small JPEGs) |
| Tools | `Tools/blender/`, `Tools/monster_gen/build_model_prompts.js` | Yes |

## Backup
The generated models exist only on this PC. Back up `Game/Assets/_Game/Art/Models/Monsters/` to an external drive or cloud folder after each batch. If they're ever lost, the registry and prompts let them be regenerated (generators aren't deterministic, so a regenerated model will differ).
