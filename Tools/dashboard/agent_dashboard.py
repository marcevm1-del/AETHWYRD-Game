#!/usr/bin/env python3
"""A live view of every Claude session working on this project.

Claude Code writes one JSONL transcript per session under ~/.claude/projects/<slug>/, and appends to it as the
session works. That file's modification time is therefore a truthful "is it doing something right now", and its
last records say what. This reads those files plus the repo's git state and serves one page.

    python Tools/dashboard/agent_dashboard.py            # serve on http://127.0.0.1:8787
    python Tools/dashboard/agent_dashboard.py --once     # print the JSON and exit (no server)
    python Tools/dashboard/agent_dashboard.py --port 9000 --hours 24

Standard library only. It reads; it never writes to a transcript or to git.
"""
import argparse
import datetime
import html
import io
import json
import os
import re
import subprocess
import time

HOME = os.path.expanduser("~")
PROJECTS = os.path.join(HOME, ".claude", "projects")
REPO = os.path.abspath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", ".."))
WORKING_SEC = 90          # touched this recently = working right now
RECENT_SEC = 15 * 60      # touched this recently = still warm


def ago(seconds):
    if seconds < 60:
        return "%ds" % int(seconds)
    if seconds < 3600:
        return "%dm" % int(seconds / 60)
    if seconds < 86400:
        return "%dh %dm" % (int(seconds / 3600), int(seconds % 3600 / 60))
    return "%dd" % int(seconds / 86400)


def tail_lines(path, limit=400, block=262144):
    """The last `limit` lines without reading the whole file: transcripts reach tens of megabytes."""
    out = []
    with io.open(path, "rb") as f:
        f.seek(0, os.SEEK_END)
        end = f.tell()
        buf = b""
        while end > 0 and buf.count(b"\n") <= limit:
            start = max(0, end - block)
            f.seek(start)
            buf = f.read(end - start) + buf
            end = start
    for line in buf.split(b"\n"):
        if line.strip():
            out.append(line.decode("utf-8", "replace"))
    return out[-limit:]


def first_record(path, max_bytes=4 * 1024 * 1024):
    """The first parsable record, for cwd / branch / session id. The first line can be very long."""
    with io.open(path, "rb") as f:
        chunk = f.read(max_bytes)
    for line in chunk.split(b"\n"):
        if not line.strip():
            continue
        try:
            return json.loads(line.decode("utf-8", "replace"))
        except ValueError:
            continue
    return {}


def text_of(message):
    """Readable text from a transcript message, whatever shape it is."""
    if not isinstance(message, dict):
        return ""
    content = message.get("content")
    if isinstance(content, str):
        return content
    parts = []
    if isinstance(content, list):
        for c in content:
            if not isinstance(c, dict):
                continue
            if c.get("type") == "text" and c.get("text"):
                parts.append(c["text"])
            elif c.get("type") == "tool_use":
                name = c.get("name", "tool")
                inp = c.get("input") or {}
                hint = inp.get("description") or inp.get("command") or inp.get("file_path") or inp.get("pattern") or ""
                parts.append("[%s] %s" % (name, str(hint)[:120]))
    return "\n".join(parts)


# Injected context that is not what the session is doing: status notes, reminders, caveats, slash-command envelopes.
NOISE = ("linked sessions now", "system-reminder", "caveat:", "<command-name", "<local-command",
         "this session is being continued", "no response requested", "[system notification",
         "the user sent a new message while you were working", "<ci-monitor-event", "<side-sessions-event")


def is_noise(text):
    t = (text or "").strip().lower()
    return (not t) or any(t.startswith(n) or n in t[:160] for n in NOISE)


def clean(s, limit=240):
    s = re.sub(r"<[^>]{1,40}>", " ", s or "")          # system-reminder style tags
    s = re.sub(r"\s+", " ", s).strip()
    return s[:limit]


def read_session(path):
    st = os.stat(path)
    idle = time.time() - st.st_mtime
    head = first_record(path)
    lines = tail_lines(path)
    users = assistants = 0
    last_text = last_tool = ""
    brief = ""
    late_branch = ""
    for raw in lines:
        try:
            d = json.loads(raw)
        except ValueError:
            continue
        if d.get("gitBranch"):
            late_branch = d["gitBranch"]
        t = d.get("type")
        if t == "user":
            users += 1
        elif t == "assistant":
            assistants += 1
            txt = text_of(d.get("message"))
            if txt and not is_noise(txt):
                last_text = txt
                m = re.search(r"\[(\w+)\]", txt)
                if m:
                    last_tool = m.group(1)
    # The brief: the first user message of the session, which for our research sessions is the whole task.
    # The brief can sit a long way in, after the reminders and context the harness injects first, so scan by bytes
    # rather than by line count: a line cap found nothing on sessions that start with a wall of injected context.
    seen = 0
    with io.open(path, encoding="utf-8", errors="replace") as f:
        for raw in f:
            seen += len(raw)
            if seen > 2 * 1024 * 1024 or brief:
                break
            try:
                d = json.loads(raw)
            except ValueError:
                continue
            if d.get("type") != "user" or d.get("isMeta"):
                continue
            cand = clean(text_of(d.get("message")), 400)
            if len(cand) > 40 and not is_noise(cand):
                brief = cand
    state = "working" if idle < WORKING_SEC else ("warm" if idle < RECENT_SEC else "idle")
    # Naming: the records do not always carry cwd or branch, so fall back to the project-folder slug (which encodes
    # the worktree path) and finally to the first words of the brief. A blank row is useless on a dashboard.
    slug = os.path.basename(os.path.dirname(path))
    if os.path.basename(os.path.dirname(path)) == "subagents":
        slug = os.path.basename(os.path.dirname(os.path.dirname(path)))
    tail = slug.split("worktrees-")[-1] if "worktrees-" in slug else slug
    tail = re.sub(r"-[0-9a-f]{6}$", "", tail).replace("-", " ").strip()
    name = head.get("gitBranch") or late_branch or ""
    if not name:
        name = tail if tail and tail.lower() not in ("e  ideas", "e  ideas project ascend") else ""
    if not name:
        name = " ".join((brief or "session").split()[:7])
    return {
        "name": name[:46],
        "file": os.path.basename(path),
        "cwd": head.get("cwd", ""),
        "branch": head.get("gitBranch", ""),
        "sessionId": head.get("sessionId", ""),
        "idleSec": round(idle),
        "idle": ago(idle),
        "state": state,
        "messages": users + assistants,
        "brief": brief,
        "last": clean(last_text),
        "lastTool": last_tool,
        "sizeMB": round(st.st_size / 1048576.0, 1),
        "isSubagent": os.sep + "subagents" + os.sep in path,
    }


def scan(hours):
    cutoff = time.time() - hours * 3600
    rows = []
    for root, _dirs, files in os.walk(PROJECTS):
        for n in files:
            if not n.endswith(".jsonl"):
                continue
            p = os.path.join(root, n)
            try:
                if os.stat(p).st_mtime < cutoff:
                    continue
                rows.append(read_session(p))
            except OSError:
                continue
    order = {"working": 0, "warm": 1, "idle": 2}
    rows.sort(key=lambda r: (order.get(r["state"], 3), r["idleSec"]))
    return rows


def git(*args):
    try:
        out = subprocess.run(["git", "-c", "safe.directory=" + REPO.replace("\\", "/"), "-C", REPO] + list(args),
                             capture_output=True, text=True, timeout=25)
        return out.stdout.strip()
    except Exception:
        return ""


def branches():
    raw = git("for-each-ref", "--sort=-committerdate", "--count=25",
              "--format=%(refname:short)\t%(committerdate:relative)\t%(contents:subject)", "refs/heads")
    rows = []
    for line in raw.splitlines():
        parts = line.split("\t")
        if len(parts) == 3:
            rows.append({"branch": parts[0], "when": parts[1], "subject": parts[2][:90]})
    return rows


QUALITY_NAMES = {0: "absent", 1: "blockout", 2: "working", 3: "polished", 4: "shippable"}


def goal_count(spec):
    """How many of a thing the repo actually contains. Returns None when the file is missing, which is NOT ASSESSED
    rather than zero: a dashboard that reports a missing file as 0% invents a fact."""
    path = os.path.join(REPO, spec["file"])
    if not os.path.exists(path):
        return None
    try:
        d = json.load(io.open(path, encoding="utf-8"))
    except Exception:
        return None
    if spec.get("key"):
        d = d.get(spec["key"])
    if isinstance(d, list):
        return len(d)
    if isinstance(d, dict):
        return len(d)
    return None


def completion():
    """Scores every goal in Data/completion_goals.json. quantity x quality, weighted."""
    path = os.path.join(REPO, "Data", "completion_goals.json")
    if not os.path.exists(path):
        return {"error": "Data/completion_goals.json is missing", "goals": [], "overall": None}
    cfg = json.load(io.open(path, encoding="utf-8"))
    snap_path = os.path.join(REPO, "13_Production", "status_snapshot.json")
    snap = {}
    if os.path.exists(snap_path):
        try:
            snap = json.load(io.open(snap_path, encoding="utf-8"))
        except Exception:
            snap = {}
    rows, wsum, wscore = [], 0.0, 0.0
    for g in cfg.get("goals", []):
        if "count" in g:
            have = goal_count(g["count"])
            source = g["count"]["file"]
        elif "snapshot" in g:
            have = snap.get(g["snapshot"])
            source = "13_Production/status_snapshot.json:" + g["snapshot"]
        else:
            have = g.get("manual")
            source = "hand-set in completion_goals.json"
        target = g.get("target") or 1
        qual = g.get("quality")
        if have is None or qual is None:
            rows.append({"id": g["id"], "area": g["area"], "label": g["label"], "assessed": False,
                         "have": have, "target": target, "quality": qual, "qualityName": "NOT ASSESSED",
                         "quantityPct": None, "pct": None, "weight": g.get("weight", 1),
                         "source": source, "evidence": g.get("evidence", ""),
                         "targetEstimated": bool(g.get("targetEstimated"))})
            continue
        qpct = min(1.0, float(have) / float(target))
        pct = qpct * (float(qual) / 4.0)
        w = float(g.get("weight", 1))
        wsum += w
        wscore += w * pct
        rows.append({"id": g["id"], "area": g["area"], "label": g["label"], "assessed": True,
                     "have": have, "target": target, "quality": qual, "qualityName": QUALITY_NAMES.get(qual, "?"),
                     "quantityPct": round(qpct * 100), "pct": round(pct * 100), "weight": g.get("weight", 1),
                     "source": source, "evidence": g.get("evidence", ""),
                     "targetEstimated": bool(g.get("targetEstimated"))})
    rows.sort(key=lambda r: (r["area"], -(r["weight"] or 0)))
    overall = round(wscore / wsum * 100, 1) if wsum else None
    unassessed = [r["id"] for r in rows if not r["assessed"]]
    return {"goals": rows, "overall": overall, "notAssessed": unassessed,
            "levels": cfg.get("qualityLevels", {})}


def snapshot(hours):
    return {
        "generated": datetime.datetime.now().isoformat(timespec="seconds"),
        "repo": REPO,
        "main": git("rev-parse", "--short", "HEAD"),
        "sessions": scan(hours),
        "branches": branches(),
        "completion": completion(),
    }


CSS = """
:root{--bg:#10131a;--card:#171b24;--line:#232836;--tx:#e6e9f0;--dim:#8b93a7;--go:#4ade80;--warm:#fbbf24;--idle:#5b6376}
*{box-sizing:border-box}
body{margin:0;background:var(--bg);color:var(--tx);font:14px/1.5 ui-sans-serif,system-ui,'Segoe UI',sans-serif}
header{padding:14px 20px;border-bottom:1px solid var(--line);display:flex;gap:16px;align-items:baseline;flex-wrap:wrap}
h1{font-size:16px;margin:0;font-weight:600;letter-spacing:.2px}
.dim{color:var(--dim)}
main{padding:16px 20px;display:grid;gap:12px;grid-template-columns:repeat(auto-fill,minmax(330px,1fr))}
.card{background:var(--card);border:1px solid var(--line);border-radius:10px;padding:12px 14px;overflow:hidden}
.row{display:flex;gap:8px;align-items:center;margin-bottom:6px}
.dot{width:8px;height:8px;border-radius:50%;flex:0 0 8px}
.working .dot{background:var(--go);box-shadow:0 0 0 3px rgba(74,222,128,.18)}
.warm .dot{background:var(--warm)}
.idle .dot{background:var(--idle)}
.name{font-weight:600;white-space:nowrap;overflow:hidden;text-overflow:ellipsis}
.meta{font-size:12px;color:var(--dim);display:flex;gap:10px;flex-wrap:wrap;margin-bottom:8px}
.last{font-size:12.5px;color:#c3c9d8;background:#0d1016;border:1px solid var(--line);border-radius:6px;padding:7px 9px;
      max-height:88px;overflow:hidden}
.brief{font-size:12px;color:var(--dim);margin-top:7px;max-height:40px;overflow:hidden}
table{width:100%;border-collapse:collapse;font-size:12.5px}
td{padding:4px 8px;border-top:1px solid var(--line);vertical-align:top}
td:first-child{color:#a9b2c6;white-space:nowrap}
section{padding:0 20px 24px}
.small{font-size:12px;margin:0 0 8px}
table.goals td{padding:5px 10px}
td.area{color:var(--tx);font-weight:600;padding-top:14px;border-top:none}
td.num{color:var(--dim);white-space:nowrap}
.est{font-size:10px;color:#6b7280;border:1px solid var(--line);border-radius:3px;padding:0 3px}
.q{font-size:11px;text-transform:uppercase;letter-spacing:.06em;white-space:nowrap}
.q0{color:#f87171}.q1{color:#fb923c}.q2{color:#fbbf24}.q3{color:#a3e635}.q4{color:var(--go)}
.na{color:#f87171;font-size:12px}
.barcell{width:46%;white-space:nowrap}
.bar{position:relative;display:inline-block;width:calc(100% - 46px);height:9px;background:#0d1016;
     border:1px solid var(--line);border-radius:5px;overflow:hidden;vertical-align:middle}
.bar i{position:absolute;left:0;top:0;bottom:0;background:#2b3550}
.bar u{position:absolute;left:0;top:0;bottom:0;background:linear-gradient(90deg,#3b82f6,#4ade80)}
.pct{display:inline-block;width:40px;text-align:right;font-size:12px;color:var(--dim)}
h2{font-size:13px;text-transform:uppercase;letter-spacing:.08em;color:var(--dim);margin:18px 0 8px}
"""


def render(snap, hours, port):
    def card(s):
        title = s.get("name") or s["branch"] or s["file"][:8]
        sub = "subagent" if s["isSubagent"] else ""
        return """<div class="card %s">
<div class="row"><span class="dot"></span><span class="name">%s</span><span class="dim" style="margin-left:auto">%s</span></div>
<div class="meta"><span>%s msgs</span><span>%s MB</span><span>%s</span><span>%s</span></div>
<div class="last">%s</div><div class="brief">%s</div></div>""" % (
            s["state"], html.escape(title), html.escape(s["idle"]), s["messages"], s["sizeMB"],
            html.escape(sub), html.escape(s["lastTool"]),
            html.escape(s["last"] or "(nothing yet)"), html.escape(s["brief"]))

    comp = snap.get("completion") or {}
    bars = []
    area = None
    for g in comp.get("goals", []):
        if g["area"] != area:
            area = g["area"]
            bars.append('<tr><td colspan="4" class="area">%s</td></tr>' % html.escape(area))
        if not g["assessed"]:
            bars.append('<tr><td>%s</td><td colspan="3" class="na">NOT ASSESSED &mdash; %s</td></tr>'
                        % (html.escape(g["label"]), html.escape(g["source"])))
            continue
        est = ' <span class="est">est</span>' if g["targetEstimated"] else ""
        bars.append(
            '<tr><td>%s</td><td class="num">%s / %s%s</td>'
            '<td class="q q%d">%s</td>'
            '<td class="barcell"><div class="bar"><i style="width:%d%%"></i><u style="width:%d%%"></u></div>'
            '<span class="pct">%d%%</span></td></tr>'
            % (html.escape(g["label"]), g["have"], g["target"], est, g["quality"],
               html.escape(g["qualityName"]), g["quantityPct"], g["pct"], g["pct"]))
    overall = comp.get("overall")
    comp_html = ('<section><h2>How finished the game is &mdash; %s overall</h2>'
                 '<p class="dim small">Pale bar: how much exists. Solid bar: that multiplied by quality, '
                 '0 absent to 4 shippable. A goal whose file is missing reads NOT ASSESSED, never 0%%.</p>'
                 '<table class="goals">%s</table></section>'
                 % (("<b>%.1f%%</b>" % overall) if overall is not None else "NOT ASSESSED", "".join(bars)))
    working = sum(1 for s in snap["sessions"] if s["state"] == "working")
    rows = "".join("<tr><td>%s</td><td>%s</td><td>%s</td></tr>" % (html.escape(b["branch"]), html.escape(b["when"]),
                                                                   html.escape(b["subject"])) for b in snap["branches"])
    return """<!doctype html><html><head><meta charset="utf-8"><title>AETHWYRD agents</title>
<meta http-equiv="refresh" content="10"><style>%s</style></head><body>
<header><h1>AETHWYRD &mdash; progress and who is working</h1>
<span class="dim">%d of %d active &middot; last %gh &middot; main %s &middot; %s &middot; refreshes every 10s</span></header>
%s
<main>%s</main>
<section><h2>Branches, newest first</h2><table>%s</table></section>
</body></html>""" % (CSS, working, len(snap["sessions"]), hours, snap["main"], snap["generated"], comp_html,
                     "".join(card(s) for s in snap["sessions"]) or "<p class='dim'>No sessions in the window.</p>", rows)


def serve(port, hours):
    from http.server import BaseHTTPRequestHandler, HTTPServer

    class H(BaseHTTPRequestHandler):
        def do_GET(self):
            snap = snapshot(hours)
            if self.path.startswith("/data"):
                body, ctype = json.dumps(snap, indent=1).encode("utf-8"), "application/json"
            else:
                body, ctype = render(snap, hours, port).encode("utf-8"), "text/html; charset=utf-8"
            self.send_response(200)
            self.send_header("Content-Type", ctype)
            self.send_header("Content-Length", str(len(body)))
            self.end_headers()
            self.wfile.write(body)

        def log_message(self, *a):
            pass

    print("dashboard on http://127.0.0.1:%d  (JSON at /data.json)" % port, flush=True)
    HTTPServer(("127.0.0.1", port), H).serve_forever()


def main():
    ap = argparse.ArgumentParser(description="Live view of the Claude sessions working on this project")
    ap.add_argument("--port", type=int, default=8787)
    ap.add_argument("--hours", type=float, default=12.0, help="how far back a transcript counts as interesting")
    ap.add_argument("--once", action="store_true", help="print the snapshot as JSON and exit")
    a = ap.parse_args()
    if a.once:
        print(json.dumps(snapshot(a.hours), indent=1))
        return 0
    serve(a.port, a.hours)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
