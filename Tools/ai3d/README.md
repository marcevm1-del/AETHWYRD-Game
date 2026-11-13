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

## Is it ready? (doctor)
```powershell
python Tools\ai3d\model_requests.py doctor          # or: E:\tsr-venv\Scripts\python.exe Tools\ai3d\triposr_run.py --check
```
Reports the venv, torch and CUDA, free GPU memory, the TripoSR code, and the cached TripoSR and Stable Diffusion weights. Each line is `OK`, `MISSING`, `FAILED` or `NOT ASSESSED` (the check could not run, for example no `nvidia-smi`; that is never shown as OK). Exit 0 = ready, 1 = something is missing or failed, 3 = something could not be assessed. `python Tools\ai3d\tsr_doctor.py --provenance <file>` validates a `provenance.json`.

## When the GPU is busy or out of memory
- Before a run the wrapper asks `nvidia-smi` for free VRAM; with under about 2.2 GB free it stops with exit code 3 and says to close the other program (Unity, Blender, a browser).
- A CUDA out-of-memory error inside a run is explained in plain words (a `HINT [oom]` line). Through the request queue the run is retried with `--mc-resolution 96 --chunk-size 1024`, then `64` / `512`; the settings actually used are recorded in `provenance.json`.
- A failed request keeps the error text and a new `outputs.errorKind` (`oom`, `gpu-busy`, `no-cuda`, `weights-download`, `disk-full`, `missing-module`, `unknown`). The status model (requested, needs-image, generated, approved, rejected, finished, failed) is unchanged.

## Provenance (`provenance.json`, schema 2)
Besides the tool, model, licence, date and input hashes it records the request id (`--request-id`, set by the queue), the effective settings (chunk size, marching-cubes resolution, device), the environment (Python, torch, trimesh, CUDA, GPU), and for each mesh its sha256, counts and watertightness. The queue refuses to mark a request `generated` unless this file exists and passes `check_provenance` (empty meshes, missing hashes, an edited mesh all fail). Schema-1 files from before still validate.

## Tests
`python -I Tools\ai3d\test_tsr_doctor.py` and `test_model_requests.py` run offline (no GPU, no network). `npm run build` runs every `Tools/*/test_*.py` through `Tools/validate/run_py_tests.js` (it fails if Python is missing instead of skipping).

## Why a wrapper
Upstream needs `torchmcubes` compiled from source (CMake plus a C++ compiler), which this PC does not have. The wrapper puts a scikit-image marching-cubes shim in its place and flips meshes whose winding comes out inverted. Upstream `run.py` is run unchanged.

## From mesh to game
Import the mesh into Blender and finish it with `Tools/blender/finish_generated_monster.py` (see `13_Production/monster_model_pipeline.md`): scale to the species size, feet on the ground, triangle budget, FBX export. Vertex colours are the default; add `--bake-texture` for an atlas. TripoSR meshes are rough, so expect clean-up.

## Status
See "AI generation tools" in `13_Production/third_party_assets.md`. Nothing from here enters `Game/` until that register lists it.
