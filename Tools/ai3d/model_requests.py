#!/usr/bin/env python3
"""Model request queue for AETHWYRD: designers ask, the triposr-modeler agent makes the 3D model.

A request is one small JSON file in 13_Production/model_requests/ (tracked in git, so every agent can file one).
The modeler runs the queue: it turns each request's reference image (or, if there is none, an image made from the
request's prompt with Tools/ai_images/generate_image.py) into a mesh with TripoSR (Tools/ai3d/triposr_run.py).
Meshes land in the gitignored Art/Generation/staging/meshes/ folder with a provenance file. Nothing goes into Game/
from here: a generated mesh is reviewed, then finished in Blender by the owning artist.

Standard library only. Run it with any Python 3.11+:

  python Tools/ai3d/model_requests.py new --id warren_crate --kind prop --name "Salvage Warren supply crate" \
      --by environment-artist --prompt "a sturdy wooden supply crate with iron bands, three-quarter view" --size 1.0
  python Tools/ai3d/model_requests.py list [--status requested]
  python Tools/ai3d/model_requests.py run [--limit 1] [--dry-run]       # the modeler runs this, one job at a time
  python Tools/ai3d/model_requests.py review warren_crate --approve --by anime-fantasy-director --note "reads well"
  python Tools/ai3d/model_requests.py finish warren_crate --by environment-artist --note "baked to Art/..."

Scope: props, set dressing, creatures, plants, weapons, armour, building parts and terrain features. NOT character
or NPC bodies: those come from Tools/blender/ascend_characters, and the queue refuses a request that asks for one.

Statuses: requested -> generated -> approved -> finished, or needs-image (no image and no image key yet),
failed (TripoSR or the image tool errored; the error is kept) and rejected (with the reviewer's note).
"""
import argparse
import datetime
import glob
import json
import os
import re
import subprocess
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.environ.get("MODEL_REQUESTS_ROOT") or os.path.abspath(os.path.join(HERE, "..", ".."))
QUEUE = os.path.join(ROOT, "13_Production", "model_requests")
IMAGES = os.path.join(ROOT, "Art", "Generation", "staging", "images")
MESHES = os.path.join(ROOT, "Art", "Generation", "staging", "meshes")
TRIPOSR_PYTHON = os.environ.get("TRIPOSR_PYTHON", r"E:\tsr-venv\Scripts\python.exe")

KINDS = ["prop", "creature", "building-part", "weapon", "armor", "plant", "terrain-feature"]

# Retired after the character test of 2026-11-13 (the measured limits are in .claude/agents/triposr-modeler.md):
# TripoSR reconstructed our own base-body render as a watertight 4,582-vertex blockout with the right silhouette,
# but with mitten hands and no face. Bodies come from Tools/blender/ascend_characters, which gives clean topology,
# a humanoid rig and data-driven variants, so the queue refuses body requests instead of making a worse start.
BODIES_COME_FROM = "character and NPC bodies come from Tools/blender/ascend_characters, not from TripoSR"
RETIRED_KINDS = {"character-reference": BODIES_COME_FROM}
# Narrow on purpose: these phrases mean a humanoid body, and none of them fits a prop, a monster or a mount.
BODY_PHRASES = ("base body", "player body", "npc body", "human body", "humanoid body", "humanoid base",
                "character body", "player character model", "base mesh for the player")
STATUSES = ["requested", "needs-image", "generated", "approved", "rejected", "finished", "failed"]
ID_RE = re.compile(r"^[a-z0-9][a-z0-9_-]{1,63}$")
IMAGE_EXT = (".png", ".jpg", ".jpeg", ".webp")
IMAGE_KEYS = ("GEMINI_API_KEY", "OPENAI_API_KEY")


def now():
    return datetime.datetime.now().isoformat(timespec="seconds")


def path_for(rid):
    return os.path.join(QUEUE, rid + ".json")


def load(rid):
    with open(path_for(rid), encoding="utf-8") as f:
        return json.load(f)


def save(req):
    os.makedirs(QUEUE, exist_ok=True)
    tmp = path_for(req["id"]) + ".tmp"
    with open(tmp, "w", encoding="utf-8") as f:
        json.dump(req, f, indent=2, ensure_ascii=False)
        f.write("\n")
    os.replace(tmp, path_for(req["id"]))


def all_requests():
    out = []
    for p in sorted(glob.glob(os.path.join(QUEUE, "*.json"))):
        with open(p, encoding="utf-8") as f:
            out.append(json.load(f))
    return sorted(out, key=lambda r: (r.get("requestedOn", ""), r["id"]))


def validate(req):
    """Return a list of problems; empty means the request is valid."""
    errs = []
    if not ID_RE.match(req.get("id", "")):
        errs.append("id must be 2-64 chars of a-z, 0-9, _ or -")
    kind = req.get("kind")
    if kind in RETIRED_KINDS:
        errs.append("kind '%s' is retired: %s" % (kind, RETIRED_KINDS[kind]))
    elif kind not in KINDS:
        errs.append("kind must be one of " + ", ".join(KINDS))
    for k in ("name", "requestedBy"):
        if not str(req.get(k, "")).strip():
            errs.append(k + " is required")
    src = req.get("source") or {}
    img, prompt = src.get("image"), src.get("prompt")
    if not img and not prompt:
        errs.append("give a reference image (--image) or a prompt (--prompt)")
    if img:
        if re.match(r"^[a-z]+://", img, re.I):
            errs.append("image must be a local file, not a URL")
        elif not img.lower().endswith(IMAGE_EXT):
            errs.append("image must be " + "/".join(IMAGE_EXT))
    said = (str(req.get("name", "")) + " " + str(req.get("notes") or "") + " " +
            str((req.get("source") or {}).get("prompt") or "")).lower()
    phrase = next((w for w in BODY_PHRASES if w in said), None)
    if phrase:
        errs.append("this asks for a '%s': %s" % (phrase, BODIES_COME_FROM))
    size = req.get("targetSizeM")
    if size is not None and not (0.05 <= float(size) <= 200):
        errs.append("targetSizeM must be between 0.05 and 200 metres")
    if req.get("status") not in STATUSES:
        errs.append("status must be one of " + ", ".join(STATUSES))
    return errs


def set_status(req, status, by, note=""):
    req["status"] = status
    req.setdefault("history", []).append({"at": now(), "status": status, "by": by, "note": note})


def cmd_new(a):
    if os.path.exists(path_for(a.id)):
        sys.exit("request '%s' already exists" % a.id)
    req = {
        "id": a.id, "kind": a.kind, "name": a.name, "requestedBy": a.by,
        "requestedOn": datetime.date.today().isoformat(),
        "source": {"image": a.image, "prompt": a.prompt},
        "targetSizeM": a.size, "speciesId": a.species, "notes": a.notes or "",
        "status": "requested", "history": [],
        "outputs": {"image": None, "mesh": None, "provenance": None, "error": None},
        "review": None,
    }
    set_status(req, "requested", a.by)
    errs = validate(req)
    if errs:
        sys.exit("invalid request:\n  - " + "\n  - ".join(errs))
    save(req)
    print("filed " + os.path.relpath(path_for(a.id), ROOT))


def cmd_list(a):
    rows = [r for r in all_requests() if not a.status or r["status"] == a.status]
    if not rows:
        print("no requests" + (" with status " + a.status if a.status else ""))
        return
    for r in rows:
        print("%-24s %-12s %-18s %-22s %s" % (r["id"], r["status"], r["kind"], r["requestedBy"], r["name"]))


class NoImageGenerator(Exception):
    """Neither the local generator nor an image-API key is available."""


def local_sd_available():
    return os.path.exists(TRIPOSR_PYTHON) and os.path.exists(os.path.join(ROOT, "Tools", "ai_images", "local_sd.py"))


def default_image_tool(prompt, rid):
    """Make a reference image from the prompt; return its path or raise.

    First choice: local Stable Diffusion 1.5 (Tools/ai_images/local_sd.py, no key, runs on the GPU). Fallback: the
    API tool Tools/ai_images/generate_image.py, only when the user has set GEMINI_API_KEY or OPENAI_API_KEY."""
    errors = []
    if local_sd_available():
        tool = os.path.join(ROOT, "Tools", "ai_images", "local_sd.py")
        p = subprocess.run([TRIPOSR_PYTHON, tool, "--prompt", prompt, "--style", "object"], cwd=ROOT,
                           capture_output=True, text=True)
        outs = [ln[4:].strip() for ln in p.stdout.splitlines() if ln.startswith("OUT ")]
        if p.returncode == 0 and outs and os.path.exists(outs[-1]):
            return outs[-1]
        errors.append("local SD: " + (p.stderr or p.stdout).strip()[-300:])
    if any(os.environ.get(k) for k in IMAGE_KEYS):
        before = set(glob.glob(os.path.join(IMAGES, "*")))
        tool = os.path.join(ROOT, "Tools", "ai_images", "generate_image.py")
        full = prompt + ", single object, plain light background, three-quarter view, full object visible"
        p = subprocess.run([sys.executable, tool, "--prompt", full], cwd=ROOT, capture_output=True, text=True)
        new = [f for f in set(glob.glob(os.path.join(IMAGES, "*"))) - before if f.lower().endswith(IMAGE_EXT)]
        if p.returncode == 0 and new:
            return max(new, key=os.path.getmtime)
        errors.append("API image tool: " + (p.stderr or p.stdout).strip()[-300:])
    if not errors:
        raise NoImageGenerator("no image generator: local SD is not installed and no image-API key is set")
    raise RuntimeError("image generation failed: " + " | ".join(errors))


def default_mesh_tool(image):
    """Run TripoSR on one image; return (mesh path, provenance path) or raise."""
    if not os.path.exists(TRIPOSR_PYTHON):
        raise RuntimeError("TripoSR python not found at %s (set TRIPOSR_PYTHON)" % TRIPOSR_PYTHON)
    wrapper = os.path.join(ROOT, "Tools", "ai3d", "triposr_run.py")
    p = subprocess.run([TRIPOSR_PYTHON, wrapper, image], cwd=ROOT, capture_output=True, text=True)
    if p.returncode != 0:
        raise RuntimeError("TripoSR failed: " + (p.stderr or p.stdout).strip()[-600:])
    out_dir = os.path.join(MESHES, os.path.splitext(os.path.basename(image))[0])
    meshes = [f for f in glob.glob(os.path.join(out_dir, "**", "*"), recursive=True) if f.lower().endswith((".obj", ".glb"))]
    if not meshes:
        raise RuntimeError("TripoSR reported success but wrote no mesh in " + out_dir)
    prov = os.path.join(out_dir, "provenance.json")
    return max(meshes, key=os.path.getmtime), (prov if os.path.exists(prov) else None)


def rel(p):
    """Path as recorded on the request: relative inside the repo, absolute outside it."""
    if p is None:
        return None
    p = os.path.abspath(p)
    try:
        r = os.path.relpath(p, ROOT)
    except ValueError:      # another drive
        return p.replace("\\", "/")
    if r.startswith(".."):  # outside the repo: an escaping relative path helps nobody
        return p.replace("\\", "/")
    return r.replace("\\", "/")


def process(req, image_tool=default_image_tool, mesh_tool=default_mesh_tool, by="triposr-modeler"):
    """Advance one requested/needs-image request. Returns the new status."""
    src = req.get("source") or {}
    image = src.get("image")
    if image and not os.path.isabs(image):
        image = os.path.join(ROOT, image)
    try:
        if image:
            if not os.path.exists(image):
                raise RuntimeError("reference image not found: " + src["image"])
        else:
            try:
                image = image_tool(src["prompt"], req["id"])
            except NoImageGenerator as e:
                set_status(req, "needs-image", by, str(e) + "; add --image or install local SD")
                return req["status"]
        req["outputs"]["image"] = rel(image)
        mesh, prov = mesh_tool(image)
        req["outputs"].update({"mesh": rel(mesh), "provenance": rel(prov), "error": None})
        set_status(req, "generated", by, "mesh ready for review")
    except Exception as e:  # keep the error on the request, move on to the next one
        req["outputs"]["error"] = str(e)[-600:]
        set_status(req, "failed", by, "see outputs.error")
    return req["status"]


def cmd_run(a):
    todo = [r for r in all_requests() if r["status"] in ("requested", "needs-image")]
    if a.only:
        todo = [r for r in todo if r["id"] == a.only]
    todo = todo[: a.limit] if a.limit else todo
    if not todo:
        print("nothing to run")
        return
    for r in todo:
        if a.dry_run:
            src = r["source"]
            print("would run %s: %s" % (r["id"], "image " + src["image"] if src.get("image") else "prompt -> image -> mesh"))
            continue
        errs = validate(r)
        if errs:
            print("  %s -> rejected: %s" % (r["id"], "; ".join(errs)))
            set_status(r, "rejected", "model_requests.py", "; ".join(errs))
            save(r)
            continue
        print("running %s ..." % r["id"], flush=True)
        status = process(r)
        save(r)
        print("  %s -> %s%s" % (r["id"], status, (": " + r["outputs"]["error"]) if status == "failed" else ""))


def cmd_review(a):
    r = load(a.id)
    if r["status"] != "generated":
        sys.exit("only a 'generated' request can be reviewed (this one is '%s')" % r["status"])
    r["review"] = {"by": a.by, "at": now(), "approved": bool(a.approve), "note": a.note or ""}
    set_status(r, "approved" if a.approve else "rejected", a.by, a.note or "")
    save(r)
    print("%s -> %s" % (a.id, r["status"]))


def cmd_finish(a):
    r = load(a.id)
    if r["status"] != "approved":
        sys.exit("only an 'approved' request can be finished (this one is '%s')" % r["status"])
    set_status(r, "finished", a.by, a.note or "")
    save(r)
    print("%s -> finished" % a.id)


def cmd_retry(a):
    r = load(a.id)
    if r["status"] not in ("failed", "rejected", "needs-image"):
        sys.exit("only failed, rejected or needs-image requests can be retried")
    if a.image:
        r["source"]["image"] = a.image
    if a.prompt:
        r["source"]["prompt"] = a.prompt
    set_status(r, "requested", a.by, a.note or "retry")
    errs = validate(r)
    if errs:
        sys.exit("invalid request:\n  - " + "\n  - ".join(errs))
    save(r)
    print("%s -> requested" % a.id)


def main(argv=None):
    ap = argparse.ArgumentParser(description="AETHWYRD model request queue (designers ask, TripoSR makes)")
    sub = ap.add_subparsers(dest="cmd", required=True)
    n = sub.add_parser("new", help="file a request")
    n.add_argument("--id", required=True)
    n.add_argument("--kind", required=True, choices=KINDS + sorted(RETIRED_KINDS))
    n.add_argument("--name", required=True)
    n.add_argument("--by", required=True, help="the requesting agent or person")
    n.add_argument("--image", help="local reference image (own art or own render; never another game's art)")
    n.add_argument("--prompt", help="what to draw if there is no reference image")
    n.add_argument("--size", type=float, help="target size in metres (height, or length for long things)")
    n.add_argument("--species", help="species id from Data/Monsters/species.json, for creatures")
    n.add_argument("--notes")
    n.set_defaults(fn=cmd_new)
    l = sub.add_parser("list", help="show the queue")
    l.add_argument("--status", choices=STATUSES)
    l.set_defaults(fn=cmd_list)
    r = sub.add_parser("run", help="process requested items, one at a time (the modeler runs this)")
    r.add_argument("--limit", type=int, default=0)
    r.add_argument("--only")
    r.add_argument("--dry-run", action="store_true")
    r.set_defaults(fn=cmd_run)
    v = sub.add_parser("review", help="approve or reject a generated mesh")
    v.add_argument("id")
    g = v.add_mutually_exclusive_group(required=True)
    g.add_argument("--approve", action="store_true")
    g.add_argument("--reject", action="store_true")
    v.add_argument("--by", required=True)
    v.add_argument("--note")
    v.set_defaults(fn=cmd_review)
    f = sub.add_parser("finish", help="mark an approved model as finished in Blender")
    f.add_argument("id")
    f.add_argument("--by", required=True)
    f.add_argument("--note")
    f.set_defaults(fn=cmd_finish)
    t = sub.add_parser("retry", help="send a failed, rejected or needs-image request back to the queue")
    t.add_argument("id")
    t.add_argument("--by", required=True)
    t.add_argument("--image")
    t.add_argument("--prompt")
    t.add_argument("--note")
    t.set_defaults(fn=cmd_retry)
    a = ap.parse_args(argv)
    a.fn(a)


if __name__ == "__main__":
    main()
