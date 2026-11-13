#!/usr/bin/env python3
"""Offline tests for model_requests.py (no GPU, no network, no keys). Run: python -I Tools/ai3d/test_model_requests.py"""
import importlib.util
import json
import os
import shutil
import sys
import tempfile

TMP = tempfile.mkdtemp(prefix="model_requests_test_")
os.environ["MODEL_REQUESTS_ROOT"] = TMP
os.environ["TRIPOSR_PYTHON"] = os.path.join(TMP, "no-such-python.exe")  # no local SD in tests
for k in ("GEMINI_API_KEY", "OPENAI_API_KEY"):
    os.environ.pop(k, None)
HERE = os.path.dirname(os.path.abspath(__file__))
spec = importlib.util.spec_from_file_location("model_requests", os.path.join(HERE, "model_requests.py"))
mr = importlib.util.module_from_spec(spec)
spec.loader.exec_module(mr)

passed = 0


def check(cond, what):
    global passed
    if not cond:
        raise AssertionError(what)
    passed += 1


def expect_exit(fn, what):
    try:
        fn()
    except SystemExit:
        check(True, what)
        return
    raise AssertionError(what + " (did not exit)")


def file_request(**kw):
    args = ["new", "--id", kw.get("id", "crate_a"), "--kind", kw.get("kind", "prop"), "--name", "Crate", "--by", "environment-artist"]
    if kw.get("image"):
        args += ["--image", kw["image"]]
    if kw.get("prompt"):
        args += ["--prompt", kw["prompt"]]
    mr.main(args)


try:
    # new: valid request is filed, duplicates and bad input are refused
    file_request(prompt="a wooden crate")
    r = mr.load("crate_a")
    check(r["status"] == "requested" and r["history"][0]["status"] == "requested", "new request is 'requested'")
    expect_exit(lambda: file_request(prompt="again"), "duplicate id is refused")
    expect_exit(lambda: file_request(id="crate_b"), "a request needs an image or a prompt")
    expect_exit(lambda: file_request(id="crate_c", image="https://example.com/a.png"), "URLs are refused")
    expect_exit(lambda: file_request(id="Bad Id", prompt="x"), "bad id is refused")

    # validate: size bounds and kind
    bad = dict(r, targetSizeM=500)
    check(any("targetSizeM" in e for e in mr.validate(bad)), "oversized target is flagged")
    check(any("kind" in e for e in mr.validate(dict(r, kind="spaceship"))), "unknown kind is flagged")

    # process: prompt, no local SD and no key, real image tool -> needs-image, nothing is called
    status = mr.process(r)
    check(status == "needs-image", "no key and no image -> needs-image")

    # process: with a reference image and a stub mesh tool -> generated
    img = os.path.join(TMP, "ref.png")
    open(img, "wb").write(b"\x89PNG stub")
    file_request(id="crate_img", image=img)
    r2 = mr.load("crate_img")
    mesh = os.path.join(TMP, "Art", "Generation", "staging", "meshes", "ref", "mesh.obj")
    os.makedirs(os.path.dirname(mesh), exist_ok=True)
    open(mesh, "w").write("v 0 0 0\n")
    check(mr.process(r2, mesh_tool=lambda image: (mesh, None)) == "generated", "image + mesh tool -> generated")
    check(r2["outputs"]["mesh"].endswith("mesh.obj") and r2["outputs"]["image"].endswith("ref.png"), "outputs recorded")
    mr.save(r2)

    # process: a failing mesh tool -> failed with the error kept
    file_request(id="crate_fail", image=img)
    r3 = mr.load("crate_fail")

    def boom(image):
        raise RuntimeError("CUDA out of memory")

    check(mr.process(r3, mesh_tool=boom) == "failed" and "out of memory" in r3["outputs"]["error"], "errors are kept")
    mr.save(r3)

    # process: prompt with a stub image tool -> generated
    file_request(id="crate_prompt", prompt="a crate")
    r4 = mr.load("crate_prompt")
    check(mr.process(r4, image_tool=lambda p, i: img, mesh_tool=lambda image: (mesh, None)) == "generated", "prompt path works with a stub image tool")

    # review, finish and retry follow the status rules
    expect_exit(lambda: mr.main(["finish", "crate_img", "--by", "x"]), "cannot finish before approval")
    mr.main(["review", "crate_img", "--approve", "--by", "anime-fantasy-director", "--note", "reads well"])
    check(mr.load("crate_img")["status"] == "approved", "review approves")
    mr.main(["finish", "crate_img", "--by", "environment-artist"])
    check(mr.load("crate_img")["status"] == "finished", "finish after approval")
    expect_exit(lambda: mr.main(["review", "crate_fail", "--approve", "--by", "x"]), "cannot review a failed request")
    mr.main(["retry", "crate_fail", "--by", "triposr-modeler"])
    check(mr.load("crate_fail")["status"] == "requested", "retry sends it back")

    # files on disk are valid JSON and every saved request validates
    for f in os.listdir(mr.QUEUE):
        with open(os.path.join(mr.QUEUE, f), encoding="utf-8") as fh:
            check(not mr.validate(json.load(fh)), "saved request validates: " + f)
    print("%d checks passed" % passed)
finally:
    shutil.rmtree(TMP, ignore_errors=True)
