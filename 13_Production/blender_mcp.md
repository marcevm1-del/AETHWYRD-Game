# Driving Blender live from a Claude session

Set up and measured on 2026-11-21. This is the fast path for character and creature work: instead of running a
headless build, writing a turnaround sheet and reading the PNG back, a session generates the asset inside a running
Blender and looks at it directly.

## Starting it

```
"E:/SteamLibrary/steamapps/common/Blender/blender.exe" --python Tools/blender/start_mcp.py
```

That enables the `blender_mcp` add-on and starts its socket server on port 9876, so nobody has to click
"Connect to Claude" in the sidebar. From the session, `get_addon_status` should then answer.

If it does not: `netstat -ano | findstr 9876`. A second Blender already holding the port is the usual reason, and
two instances will both appear to listen.

## What it reported here

| | |
|---|---|
| Blender | 5.3.0 |
| Add-on | 1.8, protocol **15** against an expected **16** |
| Asset libraries | Poly Haven, Sketchfab, Poly Pizza — all **off** |
| 3D generators | Tripo, Hunyuan3D, Hyper3D, Meshy — all **off** |
| Telemetry | off |

The protocol is one version behind. The server's advice is `uvx mcp-for-blender install-addon`, and that was
**deliberately not run**: the older protocol works through fallbacks, and updating needs a Blender restart. Worth
doing on a quiet day, not mid-session.

Poly Haven is **CC0 with no attribution required** (read from its licence page on 2026-11-15, see
`13_Production/research/tools_and_sources.md`), so switching that library on is free and safe. Sketchfab and all
four generators need accounts or credits, which are the user's decision, and they stay off.

## What it is good for

Generating a character in the live session and inspecting it, in seconds:

```python
import sys, os, bpy
sys.path.insert(0, r"<repo>\Tools\blender")
os.chdir(r"<repo>")
from ascend_characters import generate
ch = generate.character("human_male_base")
```

Then `look` with `mode: angles` for front, three-quarter, side and back, or `get_scene_info` with the `topology`
and `weights` fields for numbers our own checks do not produce.

## What that measured, 2026-11-21

Numbers for `human_male_base` that we had never had before:

- **Body: 5,106 faces, 100% quads** — no tris, no ngons, **0 non-manifold edges, 0 boundary edges, 0 loose
  vertices**, 111 poles. The generator's topology is clean, which matters because it is what animation deforms.
- **Every mesh: 0 unweighted vertices.** Our own validator asserts this; an independent tool agrees.
- Whole character: 12 meshes, 11,484 faces, 62 bones.

And one thing that looked like a defect and is not. On the male base, the hair weights **only to `Head`** — the
`HairBack_*` and `HairSide*` swing chains carry nothing. That is correct for a crop, which should not swing. The
female base, whose style is `long_loose`, weights its hair across all seven chains (HairBack_1 460 verts, _2 528,
_3 892, each HairSide 92–108). Checked before reporting, because the male figure alone reads as a bug.

## Rules that still apply

An LLM running `bpy` in a live Blender can destroy unsaved work. Point it at a scratch file, never at a `.blend`
that matters, and never at a scene somebody has open and unsaved. Nothing here enters `Game/` without going through
`13_Production/third_party_assets.md` first.
