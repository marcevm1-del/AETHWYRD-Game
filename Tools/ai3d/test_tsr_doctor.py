#!/usr/bin/env python3
"""Offline tests for tsr_doctor.py and the hardened model_requests / triposr_run paths (no GPU, no network).
Run: python -I Tools/ai3d/test_tsr_doctor.py"""
import hashlib
import importlib.util
import json
import os
import shutil
import subprocess
import sys
import tempfile

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)
import tsr_doctor as td  # noqa: E402

passed = 0


def check(cond, what):
    global passed
    if not cond:
        raise AssertionError(what)
    passed += 1


class Proc:
    def __init__(self, rc=0, out="", err=""):
        self.returncode, self.stdout, self.stderr = rc, out, err


TMP = tempfile.mkdtemp(prefix="tsr_doctor_test_")
try:
    # error classification
    check(td.classify_error("RuntimeError: CUDA out of memory. Tried to allocate 2.00 GiB")[0] == "oom", "oom")
    check(td.classify_error("torch.OutOfMemoryError: CUDA error")[0] == "oom", "oom class name")
    check(td.classify_error("CUDA error: all CUDA-capable devices are busy or unavailable")[0] == "gpu-busy", "busy")
    check(td.classify_error("AssertionError: Torch not compiled with CUDA enabled")[0] == "no-cuda", "no cuda")
    check(td.classify_error("LocalEntryNotFoundError: x")[0] == "weights-download", "offline weights")
    check(td.classify_error("ModuleNotFoundError: No module named 'rembg'")[0] == "missing-module", "missing module")
    check(td.classify_error("division by zero") == ("unknown", ""), "unknown stays unknown")
    check("HINT [oom]" in td.explain_error("CUDA out of memory"), "hint appended")
    check(td.explain_error("division by zero") == "division by zero", "no hint for unknown")
    check(td.is_retryable_oom("CUDA out of memory") and not td.is_retryable_oom("disk full"), "retryable only for oom")

    # nvidia-smi parsing and preflight
    csv = "NVIDIA GeForce GTX 1650, 4096, 400, 3600\n"
    check(td.parse_nvidia_smi(csv) == [{"name": "NVIDIA GeForce GTX 1650", "totalMiB": 4096, "usedMiB": 400, "freeMiB": 3600}], "parse")
    check(td.parse_nvidia_smi("garbage") == [], "garbage parses to nothing")
    ok, msg = td.gpu_preflight(2200, run=lambda *a, **k: Proc(0, csv))
    check(ok and "3600 MiB free" in msg, "preflight passes with free memory")
    ok, msg = td.gpu_preflight(2200, run=lambda *a, **k: Proc(0, "GPU, 4096, 3900, 196"))
    check(not ok and "196 MiB free" in msg, "preflight fails when the GPU is busy")

    def no_smi(*a, **k):
        raise FileNotFoundError()
    ok, msg = td.gpu_preflight(2200, run=no_smi)
    check(ok and "NOT ASSESSED" in msg, "no nvidia-smi: proceeds but says NOT ASSESSED")

    # doctor: everything present
    hub = os.path.join(TMP, "hf", "hub")
    for repo in ("models--stabilityai--TripoSR", "models--stable-diffusion-v1-5--stable-diffusion-v1-5"):
        d = os.path.join(hub, repo, "snapshots", "abc")
        os.makedirs(d)
        open(os.path.join(d, "model.ckpt"), "w").write("x")
    tdir = os.path.join(TMP, "TripoSR")
    os.makedirs(tdir)
    open(os.path.join(tdir, "run.py"), "w").write("")
    py = os.path.join(TMP, "python.exe")
    open(py, "w").write("")
    paths = {"python": py, "triposr_dir": tdir, "hf_home": os.path.join(TMP, "hf")}
    probe = json.dumps({"python": "3.11", "torch": "2.1", "diffusers": "0.30", "transformers": "4.4", "trimesh": "4",
                        "skimage": "0.2", "omegaconf": "2", "einops": "0.7", "cuda": True, "torchCuda": "12.1",
                        "gpu": "GTX 1650"})

    def fake_run(cmd, **k):
        return Proc(0, csv) if cmd[0] == "nvidia-smi" else Proc(0, probe)
    checks = td.doctor(paths, run=fake_run)
    check(td.worst(checks) == 0 and all(c["status"] == td.OK for c in checks), "all OK -> exit 0")
    check("READY" in td.format_report(checks), "report says READY")

    # doctor: missing weights/code and busy GPU are failures
    paths_bad = dict(paths, triposr_dir=os.path.join(TMP, "nope"), hf_home=os.path.join(TMP, "empty"))

    def busy(cmd, **k):
        return Proc(0, "GPU, 4096, 3900, 196") if cmd[0] == "nvidia-smi" else Proc(0, probe)
    checks = td.doctor(paths_bad, run=busy)
    st = {c["name"]: c["status"] for c in checks}
    check(st["TripoSR code"] == td.MISSING and st["TripoSR weights"] == td.MISSING and st["GPU memory"] == td.FAILED, "missing/busy reported")
    check(td.worst(checks) == 1, "failures -> exit 1")

    # doctor: a probe that cannot run is NOT ASSESSED (exit 3), never OK
    def timeout_run(cmd, **k):
        if cmd[0] == "nvidia-smi":
            return Proc(0, csv)
        raise subprocess.TimeoutExpired(cmd, 1)
    checks = td.doctor(paths, run=timeout_run)
    st = {c["name"]: c["status"] for c in checks}
    check(st["venv packages"] == td.NOT_ASSESSED and td.worst(checks) == 3, "unassessed probe -> NOT ASSESSED, exit 3")
    check("not a pass" in td.format_report(checks), "report says unknown is not a pass")
    checks2 = td.doctor(dict(paths, triposr_dir=os.path.join(TMP, "nope")), run=timeout_run)
    check(td.worst(checks2) == 1, "failure outranks NOT ASSESSED")
    cpu = json.dumps(dict(json.loads(probe), cuda=False, gpu=None))
    checks3 = td.doctor(paths, run=lambda cmd, **k: Proc(0, csv) if cmd[0] == "nvidia-smi" else Proc(0, cpu))
    check({c["name"]: c["status"] for c in checks3}["torch CUDA"] == td.FAILED, "CPU-only torch fails")

    # provenance
    mesh = os.path.join(TMP, "out", "mesh.obj")
    os.makedirs(os.path.dirname(mesh))
    open(mesh, "w").write("v 0 0 0\n")
    sha = hashlib.sha256(open(mesh, "rb").read()).hexdigest()
    prov = {"schema": 2, "tool": "t", "model": "m", "licence": "MIT", "createdUtc": "2026-01-01T00:00:00+00:00",
            "inputs": [{"file": "a.png", "sha256": "a" * 64}],
            "meshes": [{"file": "mesh.obj", "sha256": sha, "vertices": 10, "faces": 12, "watertight": True}],
            "status": "staging", "settings": {}, "environment": {}, "outputs": ["mesh.obj"]}
    check(td.check_provenance(prov, os.path.dirname(mesh)) == [], "complete provenance passes")
    bad = json.loads(json.dumps(prov))
    del bad["licence"]
    bad["inputs"][0]["sha256"] = "zz"
    bad["meshes"][0]["vertices"] = 0
    errs = td.check_provenance(bad, os.path.dirname(mesh))
    check(len(errs) == 3, "three problems found: %r" % errs)
    open(mesh, "w").write("v 1 1 1\n")
    check(any("hash mismatch" in e for e in td.check_provenance(prov, os.path.dirname(mesh))), "edited mesh detected")
    os.remove(mesh)
    check(any("not on disk" in e for e in td.check_provenance(prov, os.path.dirname(mesh))), "missing mesh detected")
    old = {k: v for k, v in prov.items() if k not in ("schema", "settings", "environment", "outputs")}
    old["meshes"] = [{k: v for k, v in prov["meshes"][0].items() if k != "sha256"}]
    check(td.check_provenance(old) == [], "schema-1 provenance (older files) still passes")
    check(any("schema 2" in e for e in td.check_provenance(dict(old, schema=2))), "schema 2 needs its extra keys")

    # model_requests: busy GPU fails fast with a clear message; OOM retries with smaller settings
    os.environ["MODEL_REQUESTS_ROOT"] = TMP
    os.environ["TRIPOSR_PYTHON"] = py
    spec = importlib.util.spec_from_file_location("model_requests", os.path.join(HERE, "model_requests.py"))
    mr = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(mr)
    img = os.path.join(TMP, "ref.png")
    open(img, "wb").write(b"x")
    real_run, real_pre = subprocess.run, td.gpu_preflight
    td.gpu_preflight = lambda n, run=None: (False, "GPU X has only 100 MiB free")
    try:
        mr.default_mesh_tool(img)
        check(False, "busy GPU should raise")
    except RuntimeError as e:
        check("GPU busy" in str(e), "busy GPU raises a plain message")
    td.gpu_preflight = lambda n, run=None: (True, "ok")
    calls = []

    def oom_then_ok(cmd, **k):
        calls.append(cmd)
        if len(calls) == 1:
            return Proc(3, "", "RuntimeError: CUDA out of memory")
        out_dir = os.path.join(mr.MESHES, "ref")
        os.makedirs(out_dir, exist_ok=True)
        m = os.path.join(out_dir, "mesh.obj")
        open(m, "w").write("v 0 0 0\n")
        mesh_entry = dict(prov["meshes"][0], sha256=hashlib.sha256(open(m, "rb").read()).hexdigest())
        json.dump(dict(prov, meshes=[mesh_entry]), open(os.path.join(out_dir, "provenance.json"), "w"))
        return Proc(0, "Done")
    subprocess.run = oom_then_ok
    try:
        mr.CURRENT_REQUEST = "crate_a"
        mesh_path, prov_path = mr.default_mesh_tool(img)
    finally:
        subprocess.run = real_run
        td.gpu_preflight = real_pre
    check(len(calls) == 2 and "--mc-resolution" in calls[1] and "96" in calls[1], "OOM retried with smaller settings")
    check("--request-id" in calls[0] and prov_path and prov_path.endswith("provenance.json"), "request id passed, provenance returned")

    # a persistent OOM ends as a failed request with a hint and errorKind; the status model is unchanged
    mr.save({"id": "oomreq", "kind": "prop", "name": "n", "requestedBy": "x", "requestedOn": "2026-01-01",
             "source": {"image": img, "prompt": None}, "status": "requested", "history": [],
             "outputs": {"image": None, "mesh": None, "provenance": None, "error": None}, "review": None})
    r = mr.load("oomreq")

    def always_oom(image):
        raise RuntimeError(td.explain_error("CUDA out of memory"))
    check(mr.process(r, mesh_tool=always_oom) == "failed", "OOM -> failed")
    check(r["outputs"]["errorKind"] == "oom" and "HINT" in r["outputs"]["error"], "errorKind and hint kept")
    check(not mr.validate(r), "failed request still validates")

    # the wrapper: option parsing and effective settings (no torch needed)
    spec2 = importlib.util.spec_from_file_location("triposr_run", os.path.join(HERE, "triposr_run.py"))
    tr = importlib.util.module_from_spec(spec2)
    spec2.loader.exec_module(tr)
    argv, rid = tr.pop_option(["a.png", "--request-id", "r1", "--mc-resolution", "96"], "--request-id")
    check(argv == ["a.png", "--mc-resolution", "96"] and rid == "r1", "--request-id is removed before upstream sees it")
    st = tr.settings_from(["--mc-resolution", "96"])
    check(st["mc_resolution"] == 96 and st["chunk_size"] == 2048, "effective settings recorded with defaults")
    print("%d checks passed" % passed)
finally:
    shutil.rmtree(TMP, ignore_errors=True)
