#!/usr/bin/env python3
"""Readiness check, error classification and provenance validation for the local 3D / image tools.

Standard library only (it must run with any Python 3.11+, before the TripoSR venv is known to work).

  python Tools/ai3d/tsr_doctor.py                # report: venv, torch+CUDA, GPU memory, TripoSR code, weights, SD weights
  python Tools/ai3d/tsr_doctor.py --json         # same, machine-readable
  python Tools/ai3d/tsr_doctor.py --provenance Art/Generation/staging/meshes/crate/provenance.json

Exit code: 0 = every check is OK, 1 = something is MISSING or FAILED, 3 = something could not be assessed.
A check that could not run (no nvidia-smi, venv probe timed out) says NOT ASSESSED; it is never reported as OK.

The same functions back `model_requests.py doctor` and `triposr_run.py --check`.
"""
import argparse
import glob
import json
import os
import re
import subprocess
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, "..", ".."))
OK, MISSING, FAILED, NOT_ASSESSED = "OK", "MISSING", "FAILED", "NOT ASSESSED"

# Free VRAM (MiB) below which TripoSR at the default settings is likely to run out of memory on a 4 GB card.
MIN_FREE_MIB_TRIPOSR = 2200
MIN_FREE_MIB_SD = 3000

PROVENANCE_REQUIRED = ["tool", "model", "licence", "createdUtc", "inputs", "meshes", "status"]
PROVENANCE_V2_REQUIRED = ["settings", "environment", "outputs"]
SHA_RE = re.compile(r"^[0-9a-f]{64}$")


def env_paths():
    """Resolved at call time so tests (and the user's shell) can override them."""
    return {
        "python": os.environ.get("TRIPOSR_PYTHON", r"E:\tsr-venv\Scripts\python.exe"),
        "triposr_dir": os.environ.get("TRIPOSR_DIR", r"E:\Ideas\AI-Game-Toolkit\TripoSR"),
        "hf_home": os.environ.get("HF_HOME") or os.path.join(os.path.expanduser("~"), ".cache", "huggingface"),
    }


# ---------------------------------------------------------------- error classification

_PATTERNS = [
    ("oom", re.compile(r"out of memory|CUDA error: out of memory|CUBLAS_STATUS_ALLOC_FAILED|"
                       r"OutOfMemoryError|Unable to allocate .* GiB", re.I),
     "The GPU ran out of memory. Close other GPU programs (Unity, Blender, a browser with hardware "
     "acceleration), then retry; or lower --mc-resolution (try 96) and --chunk-size (try 1024)."),
    ("gpu-busy", re.compile(r"CUDA-capable device\(s\) is/are busy|device is busy|CUDA error: .*unavailable|"
                            r"all CUDA-capable devices are busy", re.I),
     "The GPU is busy or unavailable. Another process holds it; wait for it to finish (check nvidia-smi) and retry."),
    ("no-cuda", re.compile(r"no CUDA GPUs are available|Torch not compiled with CUDA|CUDA driver version is "
                           r"insufficient|could not find CUDA|AssertionError: Torch not compiled", re.I),
     "PyTorch cannot see a CUDA GPU. Run `model_requests.py doctor`; check the NVIDIA driver and that the venv "
     "has the CUDA build of torch."),
    ("weights-download", re.compile(r"couldn.t connect to 'https://huggingface|LocalEntryNotFoundError|"
                                    r"OfflineModeIsEnabled|Max retries exceeded.*huggingface|"
                                    r"We couldn.t connect|ConnectionError", re.I),
     "The model weights are not cached and could not be downloaded. Connect once to download them (see "
     "`model_requests.py doctor` for the cache path), or set HF_HOME to a folder that already has them."),
    ("disk-full", re.compile(r"No space left on device|OSError: \[Errno 28\]|disk full", re.I),
     "The disk is full. Free some space (staging output is under Art/Generation/staging/) and retry."),
    ("missing-module", re.compile(r"ModuleNotFoundError: No module named '([\w.]+)'", re.I),
     "A Python package is missing from the TripoSR venv. Install it into that venv (not the system Python)."),
]


def classify_error(text):
    """Return (kind, hint) for a tool's stderr/stdout tail. kind 'unknown' has an empty hint."""
    for kind, rx, hint in _PATTERNS:
        if rx.search(text or ""):
            return kind, hint
    return "unknown", ""


def explain_error(text):
    """The error text with the plain-language hint appended when we recognise the failure."""
    text = (text or "").strip()
    kind, hint = classify_error(text)
    return (text + "\nHINT [%s]: %s" % (kind, hint)) if hint else text


def is_retryable_oom(text):
    return classify_error(text)[0] == "oom"


# ---------------------------------------------------------------- GPU

def parse_nvidia_smi(csv_text):
    """Parse `nvidia-smi --query-gpu=name,memory.total,memory.used,memory.free --format=csv,noheader,nounits`."""
    gpus = []
    for line in (csv_text or "").strip().splitlines():
        parts = [p.strip() for p in line.split(",")]
        if len(parts) < 4:
            continue
        try:
            gpus.append({"name": parts[0], "totalMiB": int(float(parts[1])), "usedMiB": int(float(parts[2])),
                         "freeMiB": int(float(parts[3]))})
        except ValueError:
            continue
    return gpus


def gpu_info(run=subprocess.run):
    """Return (gpus, error). error is None when nvidia-smi answered."""
    try:
        p = run(["nvidia-smi", "--query-gpu=name,memory.total,memory.used,memory.free",
                 "--format=csv,noheader,nounits"], capture_output=True, text=True, timeout=20)
    except FileNotFoundError:
        return [], "nvidia-smi not found (no NVIDIA driver on PATH)"
    except Exception as e:  # timeout etc.
        return [], "nvidia-smi failed: %s" % e
    if p.returncode != 0:
        return [], "nvidia-smi exited %d: %s" % (p.returncode, (p.stderr or p.stdout).strip()[-200:])
    gpus = parse_nvidia_smi(p.stdout)
    return (gpus, None) if gpus else ([], "nvidia-smi returned no GPUs")


def gpu_preflight(min_free_mib, run=subprocess.run):
    """Return (ok, message). Not being able to ask the driver is NOT a failure here (the tool will find out
    itself); the message says so, so nobody reads it as a pass."""
    gpus, err = gpu_info(run)
    if err:
        return True, "GPU memory NOT ASSESSED (%s)" % err
    g = gpus[0]
    if g["freeMiB"] < min_free_mib:
        return False, ("GPU %s has only %d MiB free of %d (need about %d). Another program is using it; close it "
                       "(Unity, Blender, browser) and retry." % (g["name"], g["freeMiB"], g["totalMiB"], min_free_mib))
    return True, "GPU %s: %d MiB free of %d" % (g["name"], g["freeMiB"], g["totalMiB"])


# ---------------------------------------------------------------- doctor

PROBE = ("import json,sys\n"
         "out={'python':sys.version.split()[0]}\n"
         "for m in ('torch','diffusers','transformers','trimesh','skimage','omegaconf','einops','rembg'):\n"
         "    try:\n"
         "        mod=__import__(m); out[m]=getattr(mod,'__version__','?')\n"
         "    except Exception as e:\n"
         "        out[m]=None\n"
         "try:\n"
         "    import torch\n"
         "    out['cuda']=bool(torch.cuda.is_available())\n"
         "    out['torchCuda']=torch.version.cuda\n"
         "    out['gpu']=torch.cuda.get_device_name(0) if out['cuda'] else None\n"
         "except Exception as e:\n"
         "    out['cuda']=None\n"
         "print(json.dumps(out))\n")


def probe_venv(python, run=subprocess.run):
    """Return (info dict or None, error or None)."""
    try:
        p = run([python, "-I", "-c", PROBE], capture_output=True, text=True, timeout=300)
    except subprocess.TimeoutExpired:
        return None, "venv probe timed out after 300 s (first torch import on a cold disk can be slow; run again)"
    except Exception as e:
        return None, "could not run the venv python: %s" % type(e).__name__
    if p.returncode != 0:
        return None, "venv probe exited %d: %s" % (p.returncode, (p.stderr or p.stdout).strip()[-200:])
    try:
        return json.loads(p.stdout.strip().splitlines()[-1]), None
    except Exception:
        return None, "venv probe printed unreadable output: " + p.stdout.strip()[-200:]


def find_weights(hf_home, repo_substr):
    """Look for a cached Hugging Face model whose folder name contains repo_substr (e.g. 'TripoSR')."""
    hub = os.path.join(hf_home, "hub")
    hits = glob.glob(os.path.join(hub, "models--*" + repo_substr + "*"))
    for h in hits:
        snaps = glob.glob(os.path.join(h, "snapshots", "*", "*"))
        if snaps:
            return h
    return None


def doctor(paths=None, run=subprocess.run):
    """Return a list of checks: {name, status, detail}. Status is OK, MISSING, FAILED or NOT ASSESSED."""
    P = paths or env_paths()
    checks = []

    def add(name, status, detail):
        checks.append({"name": name, "status": status, "detail": detail})

    py_ok = os.path.isfile(P["python"])
    add("venv python", OK if py_ok else MISSING,
        P["python"] if py_ok else "%s not found (set TRIPOSR_PYTHON)" % P["python"])

    info = None
    if py_ok:
        info, err = probe_venv(P["python"], run)
        if info is None:
            add("venv packages", NOT_ASSESSED, err)
    else:
        add("venv packages", NOT_ASSESSED, "no venv python to ask")
    if info:
        need = {"torch": "torch", "trimesh": "trimesh", "skimage": "scikit-image (marching cubes shim)",
                "omegaconf": "omegaconf", "einops": "einops"}
        miss = [v for k, v in need.items() if not info.get(k)]
        add("venv packages", OK if not miss else MISSING,
            ("torch %s, trimesh %s, skimage %s" % (info.get("torch"), info.get("trimesh"), info.get("skimage")))
            if not miss else "missing: " + ", ".join(miss))
        add("image packages (local SD)", OK if info.get("diffusers") and info.get("transformers") else MISSING,
            "diffusers %s, transformers %s" % (info.get("diffusers"), info.get("transformers")))
        if info.get("cuda") is True:
            add("torch CUDA", OK, "torch %s, CUDA %s, %s" % (info.get("torch"), info.get("torchCuda"), info.get("gpu")))
        elif info.get("cuda") is False:
            add("torch CUDA", FAILED, "torch %s cannot see a GPU (CPU-only build or driver problem); "
                                      "TripoSR would run on the CPU, very slowly" % info.get("torch"))
        else:
            add("torch CUDA", NOT_ASSESSED, "torch could not be imported")

    gpus, gerr = gpu_info(run)
    if gerr:
        add("GPU memory", NOT_ASSESSED, gerr)
    else:
        g = gpus[0]
        detail = "%s: %d MiB free of %d" % (g["name"], g["freeMiB"], g["totalMiB"])
        if g["freeMiB"] < MIN_FREE_MIB_TRIPOSR:
            add("GPU memory", FAILED, detail + " (GPU is busy: TripoSR needs about %d MiB free)" % MIN_FREE_MIB_TRIPOSR)
        else:
            add("GPU memory", OK, detail)

    td = P["triposr_dir"]
    add("TripoSR code", OK if os.path.isfile(os.path.join(td, "run.py")) else MISSING,
        td if os.path.isfile(os.path.join(td, "run.py")) else "%s/run.py not found (set TRIPOSR_DIR)" % td)

    w = find_weights(P["hf_home"], "TripoSR")
    add("TripoSR weights", OK if w else MISSING,
        w or "not cached under %s (they download on the first run; needs internet once)" % P["hf_home"])
    sd = find_weights(P["hf_home"], "stable-diffusion-v1-5")
    add("Stable Diffusion weights", OK if sd else MISSING,
        sd or "not cached under %s (download on first use of local_sd.py)" % P["hf_home"])
    return checks


def worst(checks):
    """0 all OK; 1 any MISSING/FAILED; 3 otherwise (something NOT ASSESSED). Failures outrank unknowns."""
    st = {c["status"] for c in checks}
    if st & {MISSING, FAILED}:
        return 1
    if NOT_ASSESSED in st:
        return 3
    return 0


def format_report(checks):
    lines = ["%-28s %-12s %s" % (c["name"], c["status"], c["detail"]) for c in checks]
    code = worst(checks)
    lines.append("")
    lines.append({0: "READY: every check passed.",
                  1: "NOT READY: fix the MISSING / FAILED lines above.",
                  3: "UNKNOWN: some checks could not be assessed (see NOT ASSESSED); this is not a pass."}[code])
    return "\n".join(lines)


# ---------------------------------------------------------------- provenance

def check_provenance(prov, base_dir=None):
    """Return a list of problems with a provenance.json dict (empty = complete). If base_dir is given the listed
    mesh files and their recorded hashes are verified on disk too."""
    errs = []
    for k in PROVENANCE_REQUIRED:
        if k not in prov or prov[k] in (None, "", []):
            errs.append("missing '%s'" % k)
    for i, inp in enumerate(prov.get("inputs") or []):
        if not inp.get("file"):
            errs.append("inputs[%d] has no file" % i)
        if not SHA_RE.match(str(inp.get("sha256", ""))):
            errs.append("inputs[%d] sha256 missing or malformed" % i)
    for i, m in enumerate(prov.get("meshes") or []):
        for k in ("file", "vertices", "faces", "watertight"):
            if k not in m:
                errs.append("meshes[%d] missing '%s'" % (i, k))
        if m.get("vertices") == 0 or m.get("faces") == 0:
            errs.append("meshes[%d] is empty (0 vertices or faces): the surface extraction found nothing" % i)
        if base_dir and m.get("file"):
            p = os.path.join(base_dir, m["file"])
            if not os.path.isfile(p):
                errs.append("mesh file listed but not on disk: " + m["file"])
            elif m.get("sha256"):
                import hashlib
                with open(p, "rb") as f:
                    if hashlib.sha256(f.read()).hexdigest() != m["sha256"]:
                        errs.append("mesh %s changed since it was generated (hash mismatch)" % m["file"])
    if prov.get("schema", 1) >= 2:
        for k in PROVENANCE_V2_REQUIRED:
            if k not in prov:
                errs.append("missing '%s' (schema 2)" % k)
    if "OpenRAIL" in str(prov.get("licence", "")) and not prov.get("prompt") and "inputs" not in prov:
        errs.append("generated image without a prompt record")
    return errs


def main(argv=None):
    ap = argparse.ArgumentParser(description="AETHWYRD local 3D/image tool readiness and provenance check")
    ap.add_argument("--json", action="store_true")
    ap.add_argument("--provenance", metavar="FILE", help="validate a provenance.json instead of the environment")
    a = ap.parse_args(argv)
    if a.provenance:
        with open(a.provenance, encoding="utf-8") as f:
            errs = check_provenance(json.load(f), os.path.dirname(os.path.abspath(a.provenance)))
        print("provenance OK" if not errs else "provenance INCOMPLETE:\n  - " + "\n  - ".join(errs))
        return 1 if errs else 0
    checks = doctor()
    print(json.dumps(checks, indent=2) if a.json else format_report(checks))
    return worst(checks)


if __name__ == "__main__":
    sys.exit(main())
