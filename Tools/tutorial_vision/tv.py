#!/usr/bin/env python3
"""Tutorial Vision: turn a video tutorial into timestamped frames, change crops, OCR and transcript that Claude
can look at, so a technique is learned from what the video SHOWS, not only from what it says.

    python Tools/tutorial_vision/tv.py fetch   <youtube-url | other-url | local-video-file>
    python Tools/tutorial_vision/tv.py scan    <id> [--budget 60] [--max-gap 10] [--no-ocr]
    python Tools/tutorial_vision/tv.py frames  <id> --at 83.5 [--crop x,y,w,h] [--scale 2]
    python Tools/tutorial_vision/tv.py frames  <id> --range 80 95 [--step 0.5]
    python Tools/tutorial_vision/tv.py compare <reference.png> <result.png> [--crop x,y,w,h] [--out side.png]
    python Tools/tutorial_vision/tv.py status  <id>

Everything is cached under .tutorial_cache/<id>/ (gitignored): the video, info.json, subtitles, frames/, crops/,
sheets/ (contact sheets for a cheap first look), manifest.json and review.md (what Claude reads first), and
steps.md (the visual step list Claude writes after looking).

Needs: ffmpeg/ffprobe, numpy, Pillow; yt-dlp for URLs; tesseract for OCR (optional).
No API keys: the frames are read by the Claude session running this (a vision model), nothing is uploaded.
"""
import argparse
import hashlib
import json
import os
import re
import shutil
import subprocess
import sys

import numpy as np
from PIL import Image, ImageDraw, ImageFont

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", ".."))
CACHE = os.environ.get("TV_CACHE") or os.path.join(ROOT, ".tutorial_cache")

# ------------------------------------------------------------------------------------------------ helpers


def die(msg, code=1):
    print("tv: " + msg, file=sys.stderr)
    sys.exit(code)


def run(cmd, **kw):
    return subprocess.run(cmd, capture_output=True, text=True, **kw)


def vdir(vid):
    d = os.path.join(CACHE, vid)
    if not os.path.isdir(d):
        die("unknown video id %r (run fetch first; cached ids: %s)" % (vid, ", ".join(sorted(os.listdir(CACHE))) if os.path.isdir(CACHE) else "none"))
    return d


def video_file(d):
    for f in sorted(os.listdir(d)):
        if f.startswith("video."):
            return os.path.join(d, f)
    die("no video file in %s" % d)


def probe(path):
    r = run(["ffprobe", "-v", "error", "-select_streams", "v:0", "-show_entries", "stream=width,height,r_frame_rate:format=duration",
             "-of", "json", path])
    if r.returncode:
        die("ffprobe failed: " + r.stderr.strip()[:300])
    j = json.loads(r.stdout)
    s = j["streams"][0]
    num, den = (s.get("r_frame_rate") or "30/1").split("/")
    return {"width": int(s["width"]), "height": int(s["height"]), "fps": float(num) / max(1.0, float(den)),
            "duration": float(j["format"]["duration"])}


def fmt_t(t):
    m, s = divmod(t, 60)
    return "%d:%04.1f" % (m, s)


def grab(path, t, out, width=None):
    """One frame at time t (accurate seek) as JPEG/PNG; width=None keeps the source resolution."""
    vf = ["-vf", "scale=%d:-2:flags=lanczos" % width] if width else []
    r = run(["ffmpeg", "-y", "-v", "error", "-ss", "%.3f" % t, "-i", path, "-frames:v", "1"] + vf + ["-q:v", "2", out])
    if r.returncode or not os.path.exists(out):
        die("ffmpeg could not grab t=%.2f: %s" % (t, r.stderr.strip()[:300]))
    return out


# ------------------------------------------------------------------------------------------------ fetch


def cmd_fetch(a):
    src = a.source
    os.makedirs(CACHE, exist_ok=True)
    if os.path.isfile(src):
        h = hashlib.sha1(open(src, "rb").read(1 << 22)).hexdigest()[:12]
        vid = "file_" + h
        d = os.path.join(CACHE, vid)
        os.makedirs(d, exist_ok=True)
        ext = os.path.splitext(src)[1] or ".mp4"
        dst = os.path.join(d, "video" + ext)
        if not os.path.exists(dst):
            shutil.copy2(src, dst)
        for sub in (os.path.splitext(src)[0] + e for e in (".vtt", ".en.vtt", ".srt")):  # a sidecar transcript, if any
            if os.path.exists(sub):
                shutil.copy2(sub, os.path.join(d, "subs" + os.path.splitext(sub)[1]))
        info = {"id": vid, "title": os.path.basename(src), "source": "local file", "path": os.path.abspath(src)}
        json.dump(info, open(os.path.join(d, "info.json"), "w"), indent=1)
        print(vid)
        return
    if not shutil.which("yt-dlp"):
        die("yt-dlp is not installed (pip install yt-dlp)")
    r = run(["yt-dlp", "--print", "%(extractor_key)s_%(id)s", "--skip-download", "--no-warnings", src])
    if r.returncode:
        explain_fetch_error(r.stderr)
    vid = re.sub(r"[^A-Za-z0-9_-]", "_", r.stdout.strip().splitlines()[-1])
    d = os.path.join(CACHE, vid)
    os.makedirs(d, exist_ok=True)
    if any(f.startswith("video.") for f in os.listdir(d)):
        print(vid)
        return
    # 1080p max: small UI text needs the resolution; mp4/h264 first so ffmpeg seeks fast.
    fmt = "bv*[height<=%d][vcodec^=avc1]+ba/bv*[height<=%d]+ba/b[height<=%d]/b" % ((a.max_height,) * 3)
    r = run(["yt-dlp", "-f", fmt, "--merge-output-format", "mp4", "--write-info-json", "--write-subs", "--write-auto-subs",
             "--sub-langs", a.sub_langs, "--sub-format", "vtt/srt/best", "--no-playlist", "--no-warnings",
             "-o", os.path.join(d, "video.%(ext)s"), "-o", "subtitle:" + os.path.join(d, "subs.%(ext)s"),
             "-o", "infojson:" + os.path.join(d, "info"), src])
    if r.returncode or not any(f.startswith("video.") for f in os.listdir(d)):
        explain_fetch_error(r.stderr)
    print(vid)


def explain_fetch_error(stderr):
    s = stderr.strip()
    if "not a bot" in s or "Sign in to confirm" in s or "HTTP Error 429" in s:
        die("the host refused this machine (bot check / rate limit). This tool does not work around that. Run the fetch "
            "on your own PC (home connection), or pass a local video file you are allowed to use.\n" + s[-400:])
    if "Private video" in s or "members-only" in s or "age" in s.lower() and "confirm" in s.lower():
        die("the video needs a signed-in account; download it yourself and pass the local file.\n" + s[-300:])
    die("download failed:\n" + s[-600:])


# ------------------------------------------------------------------------------------------------ transcript


def parse_subs(d):
    path = next((os.path.join(d, f) for f in sorted(os.listdir(d)) if f.startswith("subs") and f.endswith((".vtt", ".srt"))), None)
    if not path:
        return []
    cues, cur = [], None
    tre = re.compile(r"(\d+):(\d\d):(\d\d)[.,](\d\d\d)\s*-->\s*(\d+):(\d\d):(\d\d)[.,](\d\d\d)")
    for line in open(path, encoding="utf8", errors="replace"):
        line = line.rstrip("\n")
        m = tre.search(line)
        if m:
            g = [int(x) for x in m.groups()]
            cur = [g[0] * 3600 + g[1] * 60 + g[2] + g[3] / 1000, g[4] * 3600 + g[5] * 60 + g[6] + g[7] / 1000, []]
            cues.append(cur)
        elif cur is not None and line.strip() and not line.strip().isdigit():
            cur[2].append(re.sub(r"<[^>]+>", "", line).strip())
    # Auto-captions roll: each cue repeats the previous cue's last line first. Keep only the new lines.
    out, last = [], None
    for s, e, lines in cues:
        lines = [x for x in lines if x]
        if not lines:
            continue
        new = lines[1:] if lines[0] == last else lines
        last = lines[-1]
        text = " ".join(new).strip()
        if text and not (out and out[-1]["text"] == text):
            out.append({"start": round(s, 2), "end": round(e, 2), "text": text})
    return out


def words_between(subs, t0, t1):
    """Narration whose cue starts in (t0, t1]: each cue is attached to exactly one frame."""
    return " ".join(c["text"] for c in subs if t0 < c["start"] <= t1).strip()


# ------------------------------------------------------------------------------------------------ scan


def activity_signal(path, fps, width=320):
    """Decode at low resolution in grey and return per-sample (times, changed-fraction, mean-diff, small frames)."""
    info = probe(path)
    h = int(round(info["height"] * width / info["width"] / 2) * 2)
    p = subprocess.Popen(["ffmpeg", "-v", "error", "-i", path, "-vf", "fps=%g,scale=%d:%d,format=gray" % (fps, width, h),
                          "-f", "rawvideo", "-"], stdout=subprocess.PIPE)
    n = width * h
    frames, prev, frac, mean = [], None, [], []
    while True:
        buf = p.stdout.read(n)
        if len(buf) < n:
            break
        f = np.frombuffer(buf, np.uint8).reshape(h, width)
        frames.append(f)
        if prev is None:
            frac.append(0.0)
            mean.append(0.0)
        else:
            dif = np.abs(f.astype(np.int16) - prev.astype(np.int16))
            frac.append(float((dif > 14).mean()))
            mean.append(float(dif.mean() / 255.0))
        prev = f
    p.wait()
    t = np.arange(len(frames)) / fps
    return info, t, np.array(frac), np.array(mean), frames


def select_frames(t, frac, frames, budget, max_gap, settle=0.6, fps=4.0):
    """Pick the frames that show the state AFTER each on-screen action (activity burst followed by stillness),
    the state before it, frames inside long actions, and a baseline every max_gap seconds. Duplicates dropped."""
    quiet = 0.0015          # under this changed-fraction the screen is still (cursor blinks stay below it)
    cut = 0.35              # a scene cut or full-screen change
    picks = {}              # sample index -> (reason, importance)

    def add(i, reason, imp):
        i = int(max(0, min(len(t) - 1, i)))
        if i not in picks or picks[i][1] < imp:
            picks[i] = (reason, imp)

    add(0, "start", 1.0)
    add(len(t) - 1, "end", 1.0)
    i, n, need = 1, len(t), max(1, int(round(settle * fps)))
    while i < n:
        if frac[i] > quiet:
            s = i
            while i < n and not all(frac[j] <= quiet for j in range(i, min(n, i + need))):
                i += 1
            e = min(n - 1, i)                       # first still sample after the burst
            # how much of the screen differs before vs after the burst (a new node or a changed value is small but real)
            mag = float((np.abs(frames[e].astype(np.int16) - frames[max(0, s - 1)].astype(np.int16)) > 14).mean())
            big = float(frac[s:e + 1].max()) if e >= s else 0.0
            if mag > 0.002 or big > cut:
                add(s - 1, "before change", 0.4 + mag * 10)
                add(e, "cut" if big > cut else "after change", 0.6 + mag * 20)
            # A long action with real movement (dragging, scrubbing a value, orbiting the view; more than a cursor):
            # sample inside it even if it ends where it began.
            if (e - s) / fps > 2.0 and float(frac[s:e + 1].mean()) > 2 * quiet:
                for k in range(s + int(fps // 2), e, max(1, int(fps))):
                    add(k, "during action", 0.3 + mag * 5)
        i += 1
    last = -1e9
    for k in range(n):                              # baseline coverage
        if k in picks:
            last = t[k]
        elif t[k] - last >= max_gap:
            add(k, "baseline", 0.2)
            last = t[k]
    order = sorted(picks)
    kept, ref = [], None                            # drop near-identical neighbours
    for k in order:
        if ref is not None and np.abs(frames[k].astype(np.int16) - frames[ref].astype(np.int16)).mean() / 255.0 < 0.0015 \
                and picks[k][0] not in ("start", "end"):
            continue
        kept.append(k)
        ref = k
    if len(kept) > budget:                          # keep the most important, but never lose baseline coverage entirely
        ranked = sorted(kept, key=lambda k: -picks[k][1])
        keep = set(ranked[:budget])
        kept = [k for k in kept if k in keep]
    return [(k, picks[k][0], round(picks[k][1], 3)) for k in kept]


def change_boxes(a, b, cell=24, thresh=28, min_cells=2):
    """Regions that differ between two RGB frames (same size): list of (x, y, w, h) in pixels, biggest first."""
    da = np.asarray(a.convert("L"), np.int16)
    db = np.asarray(b.convert("L"), np.int16)
    m = np.abs(da - db) > thresh
    H, W = m.shape
    gh, gw = (H + cell - 1) // cell, (W + cell - 1) // cell
    pad = np.zeros((gh * cell, gw * cell), bool)
    pad[:H, :W] = m
    g = pad.reshape(gh, cell, gw, cell).mean(axis=(1, 3)) > 0.02
    seen = np.zeros_like(g)
    boxes = []
    for y in range(gh):
        for x in range(gw):
            if g[y, x] and not seen[y, x]:
                stack, cells = [(y, x)], []
                seen[y, x] = True
                while stack:
                    cy, cx = stack.pop()
                    cells.append((cy, cx))
                    for ny in range(cy - 1, cy + 2):        # 8-neighbours plus a one-cell gap bridges text lines
                        for nx in range(cx - 2, cx + 3):
                            if 0 <= ny < gh and 0 <= nx < gw and g[ny, nx] and not seen[ny, nx]:
                                seen[ny, nx] = True
                                stack.append((ny, nx))
                if len(cells) >= min_cells:
                    ys = [c[0] for c in cells]
                    xs = [c[1] for c in cells]
                    x0, y0 = min(xs) * cell, min(ys) * cell
                    boxes.append((x0, y0, min(W, (max(xs) + 1) * cell) - x0, min(H, (max(ys) + 1) * cell) - y0, len(cells)))
    boxes.sort(key=lambda b: -b[4])
    return [b[:4] for b in boxes]


def crop_up(img, box, out, pad=20, target=900):
    x, y, w, h = box
    x0, y0 = max(0, x - pad), max(0, y - pad)
    x1, y1 = min(img.width, x + w + pad), min(img.height, y + h + pad)
    c = img.crop((x0, y0, x1, y1))
    s = min(4.0, max(1.0, target / max(c.width, c.height)))  # upscale small regions so UI text is legible
    if s > 1.01:
        c = c.resize((int(c.width * s), int(c.height * s)), Image.LANCZOS)
    c.save(out, quality=92)
    return [x0, y0, x1 - x0, y1 - y0], round(s, 2)


def ocr(path):
    if not shutil.which("tesseract"):
        return None
    r = run(["tesseract", path, "-", "--psm", "11", "-l", "eng"])
    words = [w for w in re.split(r"\s+", r.stdout) if re.search(r"[A-Za-z0-9]{2,}", w)]
    return " ".join(words)[:400]


def font(size):
    for p in ("/usr/share/fonts/truetype/dejavu/DejaVuSans-Bold.ttf", "C:/Windows/Fonts/arialbd.ttf", "/Library/Fonts/Arial Bold.ttf"):
        if os.path.exists(p):
            return ImageFont.truetype(p, size)
    return ImageFont.load_default()


def contact_sheets(d, items, per=12, cols=3, tw=640):
    os.makedirs(os.path.join(d, "sheets"), exist_ok=True)
    out = []
    f = font(22)
    for s in range(0, len(items), per):
        chunk = items[s:s + per]
        ims = [Image.open(os.path.join(d, it["file"])).convert("RGB") for it in chunk]
        th = int(ims[0].height * tw / ims[0].width)
        rows = (len(ims) + cols - 1) // cols
        sheet = Image.new("RGB", (cols * tw, rows * (th + 30)), (24, 24, 28))
        dr = ImageDraw.Draw(sheet)
        for k, (im, it) in enumerate(zip(ims, chunk)):
            x, y = (k % cols) * tw, (k // cols) * (th + 30)
            sheet.paste(im.resize((tw, th), Image.LANCZOS), (x, y + 30))
            dr.text((x + 6, y + 3), "#%d  %s  %s" % (it["index"], fmt_t(it["t"]), it["reason"]), fill=(255, 220, 120), font=f)
        p = os.path.join("sheets", "sheet_%02d.jpg" % (s // per + 1))
        sheet.save(os.path.join(d, p), quality=88)
        out.append(p)
    return out


def cmd_scan(a):
    d = vdir(a.id)
    path = video_file(d)
    info, t, frac, mean, small = activity_signal(path, a.scan_fps)
    sel = select_frames(t, frac, small, a.budget, a.max_gap, fps=a.scan_fps)
    subs = parse_subs(d)
    for sub in ("frames", "crops"):
        shutil.rmtree(os.path.join(d, sub), ignore_errors=True)
        os.makedirs(os.path.join(d, sub))
    items, prev_img, said_until = [], None, -1.0
    for n, (k, reason, imp) in enumerate(sel, 1):
        ts = float(t[k])
        rel = os.path.join("frames", "f%03d_%07.2fs.jpg" % (n, ts))
        grab(path, ts, os.path.join(d, rel))
        img = Image.open(os.path.join(d, rel)).convert("RGB")
        it = {"index": n, "t": round(ts, 2), "time": fmt_t(ts), "file": rel, "reason": reason, "importance": imp,
              "said": words_between(subs, said_until, ts + 1.0), "changes": [], "ocr": None}
        if prev_img is not None and prev_img.size == img.size:
            for j, box in enumerate(change_boxes(prev_img, img)[:a.crops]):
                if box[2] * box[3] < 0.002 * img.width * img.height and len(it["changes"]) >= 1:
                    continue                          # a tiny second region is usually just the cursor
                crel = os.path.join("crops", "f%03d_c%d.jpg" % (n, j + 1))
                region, scale = crop_up(img, box, os.path.join(d, crel))
                ch = {"box": region, "crop": crel, "upscale": scale}
                if not a.no_ocr:
                    ch["ocr"] = ocr(os.path.join(d, crel))
                it["changes"].append(ch)
        if not a.no_ocr and (not it["changes"] or reason in ("start", "cut", "baseline")):
            it["ocr"] = ocr(os.path.join(d, rel))
        items.append(it)
        prev_img, said_until = img, ts + 1.0
    sheets = contact_sheets(d, items)
    manifest = {"id": a.id, "video": os.path.basename(path), "info": load_info(d), "probe": info, "scan_fps": a.scan_fps,
                "activity": {"samples": len(t), "busy_fraction": round(float((frac > 0.0015).mean()), 3)},
                "transcript_cues": len(subs), "frames": items, "sheets": sheets}
    json.dump(manifest, open(os.path.join(d, "manifest.json"), "w"), indent=1)
    write_review(d, manifest)
    print("%s: %d frames from %.0f s (%d transcript cues), %d crops, %d sheets -> %s" % (
        a.id, len(items), info["duration"], len(subs), sum(len(i["changes"]) for i in items), len(sheets), os.path.join(d, "review.md")))


def load_info(d):
    p = next((os.path.join(d, f) for f in ("info.info.json", "info.json") if os.path.exists(os.path.join(d, f))), None)
    if not p:
        return {}
    j = json.load(open(p, encoding="utf8"))
    return {k: j.get(k) for k in ("id", "title", "uploader", "channel", "duration", "webpage_url", "upload_date", "license", "source", "path")
            if j.get(k) is not None} | {"chapters": [{"t": c.get("start_time"), "title": c.get("title")} for c in (j.get("chapters") or [])]}


def write_review(d, m):
    i = m["info"]
    L = ["# Tutorial review pack: %s" % (i.get("title") or m["id"]), "",
         "Source: %s · %s · %.0f s · %dx%d" % (i.get("webpage_url") or i.get("path") or "?", i.get("channel") or i.get("uploader") or "",
                                              m["probe"]["duration"], m["probe"]["width"], m["probe"]["height"]),
         "Transcript cues: %d%s" % (m["transcript_cues"], "" if m["transcript_cues"] else " (none: the visual frames are the only source)"), "",
         "How to read this pack: look at the contact sheets first for the overall flow, then open the frames and the "
         "change crops (upscaled where the UI text is small) around each step. Ask for more frames with "
         "`tv.py frames %s --range A B --step 0.5` or a zoomed region with `--at T --crop x,y,w,h`. Record what you SEE "
         "(menus, nodes, links, values, transforms) in steps.md, including actions the narrator never mentions." % m["id"], "",
         "Sheets: " + ", ".join(m["sheets"]), ""]
    if i.get("chapters"):
        L += ["Chapters: " + "; ".join("%s %s" % (fmt_t(c["t"] or 0), c["title"]) for c in i["chapters"]), ""]
    L += ["| # | time | why | frame | changed regions (crop, OCR) | narration around it |", "|---|---|---|---|---|---|"]
    for f in m["frames"]:
        ch = "<br>".join("%s %s%s" % (c["crop"], c["box"], (" «%s»" % c["ocr"][:80]) if c.get("ocr") else "") for c in f["changes"]) or "–"
        if f.get("ocr") and not f["changes"]:
            ch = "OCR «%s»" % f["ocr"][:100]
        L.append("| %d | %s | %s | %s | %s | %s |" % (f["index"], f["time"], f["reason"], f["file"], ch, (f["said"] or "–")[:220].replace("|", "/")))
    open(os.path.join(d, "review.md"), "w", encoding="utf8").write("\n".join(L) + "\n")


# ------------------------------------------------------------------------------------------------ frames on demand


def cmd_frames(a):
    d = vdir(a.id)
    path = video_file(d)
    os.makedirs(os.path.join(d, "extra"), exist_ok=True)
    times = [a.at] if a.at is not None else list(np.arange(a.range[0], a.range[1] + 1e-6, a.step))
    for ts in times:
        out = os.path.join(d, "extra", "t%07.2fs.png" % ts)
        grab(path, ts, out)
        if a.crop:
            x, y, w, h = [int(v) for v in a.crop.split(",")]
            img = Image.open(out).convert("RGB")
            c = img.crop((x, y, x + w, y + h))
            if a.scale and a.scale != 1:
                c = c.resize((int(c.width * a.scale), int(c.height * a.scale)), Image.LANCZOS)
            out = out.replace(".png", "_crop%d_%d_%d_%d.png" % (x, y, w, h))
            c.save(out)
        line = out
        if a.ocr:
            line += "  OCR: " + (ocr(out) or "")
        print(line)


# ------------------------------------------------------------------------------------------------ compare


def cmd_compare(a):
    A = Image.open(a.reference).convert("RGB")
    B = Image.open(a.result).convert("RGB")
    if a.crop:
        x, y, w, h = [int(v) for v in a.crop.split(",")]
        A = A.crop((x, y, x + w, y + h))
    if a.crop_result:                                 # compare like with like: the same surface in both images
        x, y, w, h = [int(v) for v in a.crop_result.split(",")]
        B = B.crop((x, y, x + w, y + h))
    B = B.resize(A.size, Image.LANCZOS)
    na, nb = np.asarray(A, np.float32) / 255, np.asarray(B, np.float32) / 255
    mean_a, mean_b = na.reshape(-1, 3).mean(0), nb.reshape(-1, 3).mean(0)
    ha = [np.histogram(na[..., c], 16, (0, 1))[0] / na[..., c].size for c in range(3)]
    hb = [np.histogram(nb[..., c], 16, (0, 1))[0] / nb[..., c].size for c in range(3)]
    hist = float(np.mean([np.minimum(x, y).sum() for x, y in zip(ha, hb)]))      # 1 = same colour distribution
    ga, gb = na.mean(2), nb.mean(2)
    ca, cb = ga - ga.mean(), gb - gb.mean()
    if ca.std() < 1e-4 and cb.std() < 1e-4:          # two flat images: the pattern is identical, judge by brightness
        struct = float(1.0 - abs(ga.mean() - gb.mean()))
    else:                                             # -1..1 layout/brightness pattern
        struct = float((ca * cb).sum() / (np.sqrt((ca ** 2).sum() * (cb ** 2).sum()) + 1e-9))
    side = Image.new("RGB", (A.width * 2 + 10, A.height), (30, 30, 30))
    side.paste(A, (0, 0))
    side.paste(B, (A.width + 10, 0))
    out = a.out or os.path.splitext(a.result)[0] + "_vs_reference.png"
    side.save(out)
    print(json.dumps({"colour_histogram_overlap": round(hist, 3), "structure_correlation": round(struct, 3),
                      "mean_rgb_reference": [round(float(v), 3) for v in mean_a], "mean_rgb_result": [round(float(v), 3) for v in mean_b],
                      "side_by_side": out}, indent=1))


def cmd_status(a):
    d = vdir(a.id)
    m = json.load(open(os.path.join(d, "manifest.json"))) if os.path.exists(os.path.join(d, "manifest.json")) else None
    print(json.dumps({"dir": d, "files": sorted(os.listdir(d)), "frames": len(m["frames"]) if m else 0,
                      "steps_written": os.path.exists(os.path.join(d, "steps.md"))}, indent=1))


def main():
    p = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    s = p.add_subparsers(dest="cmd", required=True)
    f = s.add_parser("fetch")
    f.add_argument("source")
    f.add_argument("--max-height", type=int, default=1080)
    f.add_argument("--sub-langs", default="en.*,en")
    c = s.add_parser("scan")
    c.add_argument("id")
    c.add_argument("--budget", type=int, default=60, help="max frames kept (cost control)")
    c.add_argument("--max-gap", type=float, default=10.0, help="baseline frame at least this often (s)")
    c.add_argument("--scan-fps", type=float, default=4.0, help="activity scan rate")
    c.add_argument("--crops", type=int, default=3, help="max change crops per frame")
    c.add_argument("--no-ocr", action="store_true")
    g = s.add_parser("frames")
    g.add_argument("id")
    g.add_argument("--at", type=float)
    g.add_argument("--range", type=float, nargs=2)
    g.add_argument("--step", type=float, default=0.5)
    g.add_argument("--crop")
    g.add_argument("--scale", type=float, default=2.0)
    g.add_argument("--ocr", action="store_true")
    k = s.add_parser("compare")
    k.add_argument("reference")
    k.add_argument("result")
    k.add_argument("--crop", help="x,y,w,h region of the reference")
    k.add_argument("--crop-result", help="x,y,w,h region of the result")
    k.add_argument("--out")
    t = s.add_parser("status")
    t.add_argument("id")
    a = p.parse_args()
    if a.cmd == "frames" and a.at is None and not a.range:
        die("frames needs --at T or --range A B")
    {"fetch": cmd_fetch, "scan": cmd_scan, "frames": cmd_frames, "compare": cmd_compare, "status": cmd_status}[a.cmd](a)


if __name__ == "__main__":
    main()
