#!/usr/bin/env python3
"""Self-test for tv.py on a synthetic 'tutorial' with known on-screen events (no network needed).

    python Tools/tutorial_vision/test_tv.py

Events: a dark panel opens at 5 s; the text "Roughness 0.35" appears at 10 s; a box is dragged across the screen
from 14 s to 17 s; rolling auto-captions narrate only part of it. Exit code 0 when every check passes.
"""
import json
import os
import shutil
import subprocess
import sys
import tempfile

HERE = os.path.dirname(os.path.abspath(__file__))
TV = [sys.executable, os.path.join(HERE, "tv.py")]
fails = []


def check(cond, what):
    print(("PASS  " if cond else "FAIL  ") + what)
    if not cond:
        fails.append(what)


def main():
    tmp = tempfile.mkdtemp(prefix="tv_test_")
    env = dict(os.environ, TV_CACHE=os.path.join(tmp, "cache"))
    vid = os.path.join(tmp, "synthetic.mp4")
    font = next((p for p in ("/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf", "C:/Windows/Fonts/arial.ttf") if os.path.exists(p)), None)
    text = ("drawtext=fontfile=%s:text='Roughness 0.35':x=900:y=200:fontsize=40:fontcolor=white:enable='gte(t,10)'," % font) if font else ""
    vf = ("[0:v]drawbox=x=820:y=120:w=420:h=420:color=0x202024:t=fill:enable='gte(t,5)'," + text.rstrip(",") +
          "[bg];[bg][1:v]overlay=x='100+min(t-14\\,3)*150':y=560:enable='gte(t,14)'")
    r = subprocess.run(["ffmpeg", "-y", "-v", "error", "-f", "lavfi", "-i", "color=c=0x5a6e8c:s=1280x720:r=30:d=22",
                        "-f", "lavfi", "-i", "color=c=orange:s=80x80:r=30:d=22",
                        "-filter_complex", vf, "-pix_fmt", "yuv420p", vid], capture_output=True, text=True)
    check(r.returncode == 0, "synthetic video rendered")
    open(os.path.join(tmp, "synthetic.vtt"), "w").write(
        "WEBVTT\n\n00:00:01.000 --> 00:00:04.000\nfirst open the material panel\n\n"
        "00:00:04.000 --> 00:00:09.000\nfirst open the material panel\nthere it is\n\n"
        "00:00:09.000 --> 00:00:13.000\nthere it is\nnow tweak it a little\n")
    out = subprocess.run(TV + ["fetch", vid], capture_output=True, text=True, env=env)
    check(out.returncode == 0, "fetch local file")
    vid_id = out.stdout.strip()
    sc = subprocess.run(TV + ["scan", vid_id, "--budget", "30"], capture_output=True, text=True, env=env)
    print(sc.stdout.strip() or sc.stderr.strip())
    check(sc.returncode == 0, "scan")
    d = os.path.join(env["TV_CACHE"], vid_id)
    m = json.load(open(os.path.join(d, "manifest.json")))
    ts = [f["t"] for f in m["frames"]]
    near = lambda a, b: any(a <= t <= b for t in ts)
    check(near(5.0, 6.5), "a frame right after the panel opens (5 s): %s" % ts)
    check(near(10.0, 11.5), "a frame right after the value appears (10 s)")
    check(near(14.5, 16.8), "a frame during the 3 s drag (14-17 s)")
    check(near(17.0, 18.5), "a frame after the drag ends (17 s)")
    check(len(ts) <= 30, "frame budget respected (%d)" % len(ts))
    check(all(os.path.exists(os.path.join(d, f["file"])) for f in m["frames"]), "every frame file exists")
    panel = [f for f in m["frames"] if 5 <= f["t"] <= 6.5]
    box_ok = any(c["box"][0] <= 830 and c["box"][0] + c["box"][2] >= 1230 for f in panel for c in f["changes"])
    check(box_ok, "change crop covers the new panel (x 820-1240)")
    if font and shutil.which("tesseract"):
        val = [f for f in m["frames"] if 10 <= f["t"] <= 11.5]
        txt = " ".join((c.get("ocr") or "") for f in val for c in f["changes"]) + " ".join((f.get("ocr") or "") for f in val)
        check("Roughness" in txt and "0.35" in txt, "OCR reads the new value: %r" % txt[:80])
    said = " ".join(f["said"] for f in m["frames"])
    check(said.count("first open the material panel") == 1, "rolling captions de-duplicated")
    check(any("tweak" in f["said"] for f in m["frames"] if 9 <= f["t"] <= 14), "narration aligned to the frames near 10-13 s")
    check(os.path.exists(os.path.join(d, "review.md")) and m["sheets"], "review.md and contact sheets written")
    fr = subprocess.run(TV + ["frames", vid_id, "--at", "10.5", "--crop", "880,180,360,80", "--scale", "3"], capture_output=True, text=True, env=env)
    check(fr.returncode == 0 and os.path.exists(fr.stdout.strip().split()[0]), "on-demand zoomed crop")
    rng = subprocess.run(TV + ["frames", vid_id, "--range", "14", "15", "--step", "0.5"], capture_output=True, text=True, env=env)
    check(rng.returncode == 0 and len(rng.stdout.strip().splitlines()) == 3, "on-demand frame range (3 frames)")
    a, b = os.path.join(d, m["frames"][0]["file"]), os.path.join(d, m["frames"][-1]["file"])
    cp = subprocess.run(TV + ["compare", a, a], capture_output=True, text=True, env=env)
    j = json.loads(cp.stdout)
    check(j["colour_histogram_overlap"] > 0.99 and j["structure_correlation"] > 0.99, "compare: identical images score ~1")
    cp2 = json.loads(subprocess.run(TV + ["compare", a, b], capture_output=True, text=True, env=env).stdout)
    check(cp2["structure_correlation"] < j["structure_correlation"], "compare: different images score lower")
    shutil.rmtree(tmp, ignore_errors=True)
    print("\n%s: %d failed" % ("OK" if not fails else "FAILED", len(fails)))
    sys.exit(1 if fails else 0)


if __name__ == "__main__":
    main()
