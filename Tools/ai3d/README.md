# TripoSR (image to 3D mesh) for AETHWYRD model work

TripoSR is cloned at `E:\Ideas\AI-Game-Toolkit\TripoSR` (MIT, shallow clone, upstream unedited). Its Python 3.11 virtual environment is `E:\tsr-venv` (a short path: the clone's own `.venv` hit Windows long-path errors), so system Python stays clean. `triposr_run.py` here runs it.

## Run
```powershell
E:\tsr-venv\Scripts\python.exe Tools\ai3d\triposr_run.py path\to\image.png
```
- Output: `Art/Generation/staging/meshes/<image-name>/` (gitignored): the mesh (`.obj`, or `--model-save-format glb`) and `provenance.json`.
- First run downloads the model weights from Hugging Face (about 1.7 GB, MIT) into the Hugging Face cache.
- The GTX 1650 has 4 GB of VRAM. Upstream says the defaults need about 6 GB, so this wrapper defaults to `--chunk-size 2048 --mc-resolution 128`. If it still runs out of memory, add `--device cpu` (slow) or use `localfit`'s cloud route.
- Best inputs: one clear subject, plain background, three-quarter view. Make the picture with `Tools/ai_images/generate_image.py` or your own art.

## Why a wrapper
Upstream needs `torchmcubes` compiled from source (CMake plus a C++ compiler), which this PC does not have. The wrapper puts a scikit-image marching-cubes shim in its place and flips meshes whose winding comes out inverted. Upstream `run.py` is run unchanged.

## From mesh to game
Import the mesh into Blender and finish it with `Tools/blender/finish_generated_monster.py` (see `13_Production/monster_model_pipeline.md`): scale to the species size, feet on the ground, triangle budget, FBX export. Vertex colours are the default; add `--bake-texture` for an atlas. TripoSR meshes are rough, so expect clean-up.

## Status
See "AI generation tools" in `13_Production/third_party_assets.md`. Nothing from here enters `Game/` until that register lists it.
