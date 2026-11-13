#!/usr/bin/env python3
"""Run TripoSR (image -> 3D mesh) from the AI Game Toolkit clone, for AETHWYRD model work.

Run it with the TripoSR virtual environment's Python (system Python has no torch, on purpose):

  E:\\tsr-venv\\Scripts\\python.exe Tools\\ai3d\\triposr_run.py path\\to\\image.png [more images] [options]

What this wrapper adds to upstream `run.py` (which is left unedited):
  1. A pure-Python `torchmcubes` shim (scikit-image marching cubes). Upstream needs `torchmcubes` compiled from source
     with CMake and a C++ compiler, which this PC does not have.
  2. Defaults that fit a 4 GB GPU (GTX 1650): a smaller --chunk-size and --mc-resolution. Override them with the same flags.
  3. Output goes to the gitignored staging folder Art/Generation/staging/meshes/<image-name>/, with a sidecar JSON
     (tool, model, input hash, date, licence note), and meshes with inverted winding are flipped.
  4. The finished mesh is meant to be imported into Blender and finished with Tools/blender/finish_generated_monster.py
     (see 13_Production/monster_model_pipeline.md). Nothing goes into Game/ from here.

TripoSR code and weights are MIT (Tripo AI and Stability AI). The weights download from Hugging Face on first run.

  ... triposr_run.py --check          report whether the venv, torch+CUDA, GPU memory, code and weights are ready
  ... triposr_run.py img.png --request-id warren_crate   record the model-request id in provenance.json
Exit codes: 0 done, 2 bad input or missing setup, 3 GPU busy or out of memory (retry later or lower the settings),
4 the run finished but the provenance or mesh failed validation.
"""
import datetime
import hashlib
import json
import os
import runpy
import sys
import types

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, "..", ".."))
sys.path.insert(0, HERE)
import tsr_doctor  # noqa: E402  (readiness check, error hints, provenance validation)

TRIPOSR_DIR = os.environ.get("TRIPOSR_DIR", r"E:\Ideas\AI-Game-Toolkit\TripoSR")
STAGING = os.path.join(ROOT, "Art", "Generation", "staging", "meshes")
DEFAULT_CHUNK = "2048"
DEFAULT_MC_RES = "128"


def install_torchmcubes_shim():
    """Provide `torchmcubes.marching_cubes(vol, thresh) -> (verts, faces)` with scikit-image.

    Upstream calls `v_pos[..., [2, 1, 0]]` on the result, so torchmcubes returns vertices in reversed axis order; we
    reverse skimage's (axis0, axis1, axis2) the same way so the final mesh matches the grid used by TripoSR.
    """
    import numpy as np
    import torch
    from skimage import measure

    def marching_cubes(vol, thresh):
        volume = vol.detach().cpu().numpy().astype(np.float32)
        lo, hi = float(volume.min()), float(volume.max())
        if not (lo < thresh < hi):  # no surface crossing at this threshold
            return torch.zeros((0, 3), dtype=torch.float32), torch.zeros((0, 3), dtype=torch.int64)
        verts, faces, _normals, _values = measure.marching_cubes(volume, level=thresh)
        verts = verts[:, [2, 1, 0]].copy()
        return torch.from_numpy(verts).float(), torch.from_numpy(faces.astype(np.int64))

    module = types.ModuleType("torchmcubes")
    module.marching_cubes = marching_cubes
    sys.modules["torchmcubes"] = module


def parse(argv):
    """Split our options from upstream's. We only need the image list, output dir and format to post-process."""
    images, out_dir, fmt = [], None, "obj"
    i = 0
    takes_value = {"--device", "--pretrained-model-name-or-path", "--chunk-size", "--mc-resolution",
                   "--foreground-ratio", "--output-dir", "--model-save-format", "--texture-resolution", "--request-id"}
    while i < len(argv):
        a = argv[i]
        if a.startswith("--"):
            if a == "--output-dir":
                out_dir = argv[i + 1]
            if a == "--model-save-format":
                fmt = argv[i + 1]
            i += 2 if a in takes_value else 1
        else:
            images.append(a)
            i += 1
    return images, out_dir, fmt


def with_defaults(argv):
    argv = list(argv)
    if "--chunk-size" not in argv:
        argv += ["--chunk-size", DEFAULT_CHUNK]
    if "--mc-resolution" not in argv:
        argv += ["--mc-resolution", DEFAULT_MC_RES]
    return argv


def settings_from(argv):
    """The effective settings, so a mesh can be regenerated: upstream flags with our defaults applied."""
    out = {"chunk_size": int(DEFAULT_CHUNK), "mc_resolution": int(DEFAULT_MC_RES), "foreground_ratio": 0.85,
           "model_save_format": "obj", "device": "cuda:0"}
    keymap = {"--chunk-size": "chunk_size", "--mc-resolution": "mc_resolution", "--foreground-ratio": "foreground_ratio",
              "--model-save-format": "model_save_format", "--device": "device"}
    for i, a in enumerate(argv):
        if a in keymap and i + 1 < len(argv):
            v = argv[i + 1]
            try:
                v = float(v) if "." in v else int(v)
            except ValueError:
                pass
            out[keymap[a]] = v
    return out


def environment_info():
    env = {"python": sys.version.split()[0]}
    for m in ("torch", "trimesh", "skimage"):
        try:
            env[m] = getattr(__import__(m), "__version__", "?")
        except Exception:
            env[m] = None
    try:
        import torch
        env["cuda"] = torch.version.cuda
        env["gpu"] = torch.cuda.get_device_name(0) if torch.cuda.is_available() else None
    except Exception:
        env["gpu"] = None
    return env


def fix_winding_and_sidecar(out_dir, fmt, images, argv=(), request_id=None):
    import trimesh

    sidecar = {
        "tool": "Tools/ai3d/triposr_run.py",
        "upstream": "https://github.com/VAST-AI-Research/TripoSR",
        "model": "stabilityai/TripoSR",
        "licence": "MIT (code and weights, Tripo AI and Stability AI); confirm the model card when weights are downloaded",
        "createdUtc": datetime.datetime.now(datetime.timezone.utc).isoformat(),
        "inputs": [{"file": os.path.basename(p), "sha256": hashlib.sha256(open(p, "rb").read()).hexdigest()}
                   for p in images],
        "schema": 2,
        "requestId": request_id,
        "settings": settings_from(argv),
        "environment": environment_info(),
        "outputs": [],
        "status": "staging: not registered for use in the game; finish in Blender before any import into Game/",
        "meshes": [],
    }
    for root, _dirs, files in os.walk(out_dir):
        for name in sorted(files):
            if not name.lower().endswith("." + fmt):
                continue
            path = os.path.join(root, name)
            mesh = trimesh.load(path, force="mesh")
            flipped = False
            if mesh.is_watertight and mesh.volume < 0:
                mesh.invert()
                mesh.export(path)
                flipped = True
            sidecar["outputs"].append(name)
            sidecar["meshes"].append({"file": os.path.relpath(path, out_dir).replace("\\", "/"),
                                      "sha256": hashlib.sha256(open(path, "rb").read()).hexdigest(), "vertices": int(len(mesh.vertices)), "faces": int(len(mesh.faces)),
                                      "watertight": bool(mesh.is_watertight), "winding_flipped": flipped})
    with open(os.path.join(out_dir, "provenance.json"), "w", encoding="utf-8") as f:
        json.dump(sidecar, f, indent=2)
        f.write("\n")


def pop_option(argv, name):
    argv = list(argv)
    if name in argv:
        i = argv.index(name)
        val = argv[i + 1] if i + 1 < len(argv) else None
        del argv[i:i + 2]
        return argv, val
    return argv, None


def main(argv):
    if "--check" in argv:
        checks = tsr_doctor.doctor()
        print(tsr_doctor.format_report(checks))
        return tsr_doctor.worst(checks)
    argv, request_id = pop_option(argv, "--request-id")
    images, out_dir, fmt = parse(argv)
    if not images:
        print(__doc__)
        return 2
    for p in images:
        if not os.path.isfile(p):
            print("Input image not found: " + p, file=sys.stderr)
            return 2
    if not os.path.isfile(os.path.join(TRIPOSR_DIR, "run.py")):
        print("TripoSR not found at %s (set TRIPOSR_DIR)." % TRIPOSR_DIR, file=sys.stderr)
        return 2
    images = [os.path.abspath(p) for p in images]
    if out_dir is None:
        out_dir = os.path.join(STAGING, os.path.splitext(os.path.basename(images[0]))[0])
        argv = list(argv) + ["--output-dir", out_dir]
    argv = with_defaults([os.path.abspath(a) if a in images or os.path.isfile(a) else a for a in argv])

    ok, msg = tsr_doctor.gpu_preflight(tsr_doctor.MIN_FREE_MIB_TRIPOSR)
    print(msg, flush=True)
    if not ok:
        print("GPU busy: " + msg, file=sys.stderr)
        return 3
    install_torchmcubes_shim()
    sys.path.insert(0, TRIPOSR_DIR)
    old_cwd = os.getcwd()
    os.chdir(TRIPOSR_DIR)
    sys.argv = [os.path.join(TRIPOSR_DIR, "run.py")] + argv
    try:
        runpy.run_path(os.path.join(TRIPOSR_DIR, "run.py"), run_name="__main__")
    except SystemExit as e:
        if e.code not in (0, None):
            raise
    except BaseException as e:  # explain GPU / download / disk problems in plain words
        text = "%s: %s" % (type(e).__name__, e)
        print(tsr_doctor.explain_error(text), file=sys.stderr)
        kind = tsr_doctor.classify_error(text)[0]
        return 3 if kind in ("oom", "gpu-busy") else 1
    finally:
        os.chdir(old_cwd)
    fix_winding_and_sidecar(out_dir, fmt, images, argv, request_id)
    problems = tsr_doctor.check_provenance(json.load(open(os.path.join(out_dir, "provenance.json"), encoding="utf-8")),
                                           out_dir)
    if problems:
        print("provenance/mesh check FAILED:\n  - " + "\n  - ".join(problems), file=sys.stderr)
        return 4
    print("Done. Output and provenance.json: " + out_dir)
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv[1:]))
