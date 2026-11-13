# Third-Party Assets Register

> Everything from outside the project, with its licence and what we do with it. The game is commercial, so only assets whose licence allows commercial use go in. Assets from other studios' games are never used (ideas only; see [[reference_games]]). Source folder: `E:\Ideas\Asset-Library` (supplied 2026-10-25; sorted and renamed 2026-10-25, see `E:\Ideas\README.md`).

## Imported (CC0: commercial use, no attribution required)

All of these are extracted into `Art/ThirdParty/` and imported as Blender assets into `Art/Blender/AssetLibrary_CC0/<pack>.blend`, both local and not in git. Rebuild with `blender -b --factory-startup -P Tools/blender/import_cc0_packs.py`. Contact sheets are in `13_Production/screenshots/cc0/`. Each asset carries licence `CC0-1.0` and its author in its asset metadata.

| Pack | Licence evidence | Assets | Notes |
|---|---|---|---|
| Kenney Retro Fantasy Kit 2.0 | `License.txt` (CC0, kenney.nl) | 105 | Modular stone and wood walls, roofs, towers, stairs, fences, props (GLB) |
| Kenney Retro Textures Fantasy | `License.txt` (CC0) | (textures) | Extracted only; not used yet |
| Nobiax Modular Building | `readme.txt` (CC0 1.0) | 34 | Modern brick and concrete wall kit with 4K textures; fits Gearholm and Cinderhole more than the heartland |
| Nobiax Rocks | `readme.txt` (CC0 1.0) | 5 | FBX 6.1 is too old for Blender 5, so the OBJs beside them are imported |
| Nobiax Bushes, Hedges, Wooden Crates | `readme.txt` (CC0 1.0) | 5 + 5 + 5 | Garden and street dressing |
| 3TD Fantasy Ruins Pack | `3TD_CC0_License_EULA.pdf` in the pack | 12 | COLLADA. Blender 5 dropped that importer, so `Tools/blender/collada_lite.py` reads it. Only the highest detail level is kept, and collision meshes are dropped. The pack's Torque scripts (`.cs`) are ignored, never run |

Kenney UI borders (`kenney_fantasy-ui-borders.zip`, CC0) are 2D UI art and are left for the HUD work.

## Not imported until their licence is confirmed

None of these archives includes a licence file. Before any of them goes in, find each on its download page (most look like OpenGameArt uploads) and record the licence here.

| File | Contents |
|---|---|
| `modular-village-collection.zip` | 142 OBJ modular village pieces (canopies, roofs, cobblestone, wells, props) |
| `dungeon-collection-2.zip` | 90 OBJ dungeon pieces (walls, pillars, stairs, doors, torches) |
| `destroyed-walls-lfa.zip` | Destroyed wall meshes (OBJ, FBX, Maya) |
| `claimed-dungeon-tiles-obj.zip`, `dungeon-tileset-textures-claimed.zip` | "Claimed" dungeon tiles and textures |
| `human-base-mesh.zip`, `potions.blend`, `rts-props.blend` | A human base mesh, potion and RTS props |

## Not for the game

| File | Why |
|---|---|
| `books-oga-gpl.blend` | GPL art. It would oblige us to release derived assets under the GPL, which is a poor fit for a commercial game. Avoid |
| `rea.zip` | "Reverse Engineer Anything", an MCP for reverse-engineering binaries. Taking code or data from other studios' games is ruled out, so it isn't used |
| `tripo-ai-docs.zip`, the two `tripo-showcase-*.mp4` videos | Tripo's blog, SDK notes and two showcase turntables (an orc warrior, a moss-backed turtle) of the sculpted, stylised quality we're aiming for. Reference only |
| `TripoSG.zip` (MIT) | Open-source image-to-3D model. Running it locally means installing PyTorch and downloading model weights. Not done; `localfit` in the AI Game Toolkit already wraps it. `TripoSR` was decided on 2026-11-08, see "AI generation tools" below |
| `asset-sources-and-links.txt` | Bookmarks (Tripo Studio, Sketchfab, Fab, CGTrader, Poly Haven, Freesound, itch.io). Check each asset's licence there before downloading |

## AI generation tools (decided 2026-11-08)

The user asked for TripoSR to help build models and for Gemini and other image generators to be added. These are **tools**, not assets: nothing they make goes into `Game/` until the output has been reviewed, finished (Blender step in `13_Production/monster_model_pipeline.md`) and listed here.

| Tool | What it does | Licence / terms | Where it lives | Status |
|---|---|---|---|---|
| TripoSR (VAST-AI-Research/TripoSR) | One image to a 3D mesh | MIT for code and weights (Tripo AI and Stability AI). Confirm the Hugging Face model card when the weights first download | Clone at `E:\Ideas\AI-Game-Toolkit\TripoSR`; Python env `E:\tsr-venv`; wrapper `Tools/ai3d/triposr_run.py` | Cloned and wrapped. Install and first mesh: see `Tools/ai3d/README.md` |
| Gemini API (Google) | Concept images from text | Google's Gemini API terms apply. Check output ownership and any commercial-use limits before an image is used in the game | `Tools/ai_images/generate_image.py` (stdlib only); key from the environment variable `GEMINI_API_KEY` or `GOOGLE_API_KEY`, set by the user, never stored | Wired, offline-tested. The live call is **not verified** (no key was used) and the model id in `providers.json` is unverified |
| OpenAI Images API | Concept images from text | OpenAI's terms apply; same check as above | Same CLI, `--provider openai`, key from `OPENAI_API_KEY` | Wired, offline-tested, live call not verified |
| Stable Diffusion 1.5 (`stable-diffusion-v1-5/stable-diffusion-v1-5`) | Concept and reference images from text, run locally on the GPU, no API key | CreativeML OpenRAIL-M: commercial use of outputs allowed, subject to the licence's use restrictions. Weights (about 2 GB) download from Hugging Face on first run; the model's safety checker stays on | `Tools/ai_images/local_sd.py`, run with `E:\tsr-venv\Scripts\python.exe` | Installed and run locally; GTX 16-series needs full precision (half precision returns black images) |

**Provenance rules.** Every generated file lands in the gitignored `Art/Generation/staging/` with a sidecar recording tool, model, prompt, date and hash. The AI Game Toolkit repos cloned on 2026-11-08 (`oss-for-generative-ai`, MIT; `awesome-learn-gamedev`, CC0) are reading lists and code samples only; nothing from them is copied into the game.
