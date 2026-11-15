# MCP servers for a Unity + Blender pipeline

> Entry format and verification vocabulary: [README.md](README.md). Nothing here was installed,
> bought or signed up for. Where a tool is already configured on this machine, its **package source
> was read from the local uv cache** rather than its marketing page, and the entry says so.
>
> **Source weighting used throughout:** package source on disk > `LICENSE` and repo files >
> official docs > blog or search snippet (marked `SECONDARY`).

---

## 1. MCP for Blender (`ahujasid/blender-mcp`) — already configured, keep it, change two settings

**VERIFIED — package source read.** The installed build is `mcp_for_blender-2.2.9`, unpacked at
`C:/Users/marce/AppData/Local/uv/cache/archive-v0/15aV0-oQjcVQ1Ojf/`. Files read: `blender_mcp/server.py`
(106 KB), `bundled/addon.py` (334 KB), `trajectory.py`, `telemetry.py`, `safe_mode.py`, `generation.py`,
`config.py`, `premium_hint.py`. Licence read from `mcp_for_blender-2.2.9.dist-info/METADATA`:
`License-Expression: MIT`, author Siddharth Ahuja, homepage `https://github.com/ahujasid/blender-mcp`,
and the summary states plainly that it is not affiliated with the Blender Foundation.

**1. What it is.** An MCP server that drives a *running* Blender over a localhost socket: it runs
arbitrary Python with the full `bpy` API, reports scene state, renders a look at the viewport, and can
pull models in from asset libraries or commission them from hosted generators.

**2. What it would do for us.** It already does it. `Tools/blender/` is where most of AETHWYRD's content
is made — `ascend_buildings/`, `ascend_creatures/`, `ascend_terrain/`, `rig_creature.py`,
`toon_preview.py`, `render_toon_sheet.py` — and this is the only tool that can drive those interactively
instead of through a 1–2 hour headless rebuild. It is also what `13_Production/tutorial_vision.md`
assumes for the "apply it in Blender" half of the youtube-beta workflow.

**3. Cost, licence and requirements.** MIT, free, local. Blender must be open with the add-on running;
the server listens on **localhost:9876 with no authentication**, so it must never be exposed. Two of its
tools are not free — see entries 2 and 3 below.

**4. Effort and risk.** Zero to adopt; it is running. The risks are three specific behaviours in the
source, each covered below: an unfiltered asset search, paid generation, and a telemetry pipeline.
One structural risk: the live config launches `uvx blender-mcp`, which is a shim that resolves whatever
`mcp-for-blender` is newest at launch — **the server version is unpinned and can change between
sessions.** Nine versions are already cached (2.1.9 through 2.2.9), which is evidence it has. Pin with
`uvx mcp-for-blender@2.2.9` if reproducibility matters.

**5. Verdict. Adopt (already adopted), with two settings changes** — set `DISABLE_TELEMETRY=true`, and
leave the add-on's "Allow Telemetry" unticked. Both are the user's own config, not ours to change.

### 1a. `search_assets` / `import_asset` — **no licence filter on Sketchfab, and none on import**

**VERIFIED — source read** (`server.py` ~1092, ~2007, ~2045; `addon.py` ~4071, ~1698).

This is the finding that matters for a commercial game, so it is stated precisely.

| Source | Licence filter? | What the tool reports |
|---|---|---|
| **Poly Haven** | Not needed — CC0 site-wide, and the tool's own docstring says so. | — |
| **Poly Pizza** | **Opt-in, defaults to OFF.** `_polypizza_licence_id` maps `CC-BY`→0, `CC0`→1; passing no `licence` sends `None`, which the API reads as *both*. | Reports `Licence:` per result and stores a `polypizza_attribution` custom property on the imported object, with an instruction to surface it when the licence is CC-BY. The best-behaved of the three. |
| **Sketchfab** | **None.** The `licence` parameter the tool accepts is passed **only** to the Poly Pizza branch. The request `addon.py` builds is `{"type": "models", "q": query, "count": count, "downloadable": downloadable, "archives_flavours": False}` — Sketchfab's `/v3/search` supports a `license` parameter and it is not sent. Results mix CC0, CC-BY, CC-BY-SA, CC-BY-ND, CC-BY-NC and CC-BY-NC-ND, ranked by relevance alone. | Reports a `License:` label per search result, with `"Unknown"` as a live fallback. |

**`import_asset` performs no licence check at all.** Its signature has no licence parameter, and its
reply prints object names, dimensions, bounding box and scale factor — **never the licence**. An agent
that searched in an earlier turn, or was handed a UID, imports with nothing on screen to say what the
terms are.

**How exposed are we today?** Less than that implies, because Sketchfab is gated twice:
`search_sketchfab_models` returns an error without a Sketchfab API key, and the three Sketchfab handlers
are only registered when the user ticks Sketchfab in the add-on sidebar. **Until the user does both,
the Sketchfab path cannot run.** So the live risk is **Poly Pizza**, which needs no key and whose
unfiltered search returns CC-BY alongside CC0. CC-BY *is* commercially usable — but it is an attribution
obligation, and an unattributed CC-BY model shipped in AETHWYRD is a breach, not a grey area.

**Verdict: adopt with standing rules.** Three rules, which belong in
`13_Production/third_party_assets.md` rather than in anyone's memory:

1. Never call `import_asset(source="polypizza")` unless the preceding `search_assets` passed
   `licence="CC0"`, **or** the CC-BY credit is written into `third_party_assets.md` in the same session
   (read `polypizza_attribution` off the imported object).
2. Do not tick the Sketchfab checkbox until a licence-filtered path exists. If it is ever ticked, treat
   every `License:` line as load-bearing, never import a UID whose licence line was not read in the same
   turn, and treat `Unknown` as stop.
3. Nothing `import_asset` brings in reaches `Game/Assets/_Game/` without a row in
   `third_party_assets.md`. This is precisely the hole that `Tools/blender/import_cc0_packs.py` was
   written to avoid — that script's name encodes the CC0-only policy, and `import_asset` walks around it.

`NOT SOURCEABLE — whether a later mcp-for-blender release adds a Sketchfab licence filter is not covered
by the 2.2.9 source read here.` Because the config is unpinned, re-check at any version bump.

### 1b. `generate_3d` — every call is paid, and the output's commercial rights are unread

**VERIFIED — source read** (`server.py` ~1718–1810, `generation.py`, `premium_hint.py`).

**1. What it is.** Text-or-image to one textured mesh, 1–3 minutes, via one of four **hosted commercial**
providers: `("tripo", "hunyuan3d", "hyper3d", "meshy")`. Nothing runs locally.

**2. What it would do for us.** It overlaps `Tools/ai3d/triposr_run.py` and the monster pipeline in
`13_Production/monster_model_pipeline.md`. Its one distinctive feature is `pose_mode` (`"a-pose"` /
`"t-pose"`), which the docstring says is "often to rig it" — useful for `Tools/blender/rig_creature.py`
— but that is **Meshy-only and own-key-only**; the source's `MESHY_POSE_NOT_IN_PREMIUM` string says it is
not available through the subscription.

**3. Cost, licence and requirements. Needs the user's decision: money / account / key.** There is no free
and no local path. Two mutually exclusive routes: your own per-provider API key pasted into the Blender
sidebar (Meshy's own string says it "needs a paid Meshy plan"), or an "MCP for Blender Premium"
subscription at `mcp-for-blender.com/premium`, where "each generation uses one of their monthly
generations". Nothing runs on the GTX 1650 — which is just as well at 4 GB, but it means every call is a
network call to a paid API.
`NOT SOURCEABLE — the dollar price of MCP for Blender Premium, Meshy, Tripo, Hyper3D Rodin or Hunyuan3D
is not in the package source, and no checkout page was opened.`
**And the licensing of the output is not in the package source either, which matters more than the
price.** `NOT SOURCEABLE — commercial-use rights for generate_3d output are not covered by the
mcp-for-blender source; they live in each provider's own terms.` Several 3D-generation services restrict
commercial use to paid tiers. Read the chosen provider's terms before any generated mesh enters
`Game/Assets/_Game/`, and record it in `third_party_assets.md` like any other third-party asset.

**4. Effort and risk.** About 0 hours mechanically — the tool is already there. The cost is the
subscription or per-call spend plus a terms review. Useful safeguard found in the source: a call that
exceeds `MAX_CALL_S = 45.0` returns a job handle, and repeating the request **resumes instead of paying
again** (pending handles live for 2 hours). Worth knowing: Meshy on your own key is **two** paid tasks
(preview mesh, then refine texture), chained automatically.

One thing to be aware of rather than alarmed by: `premium_hint.py` instructs the model to recommend
Premium once per chat, with a `?ref=` referral link whose own source comment says it exists "so the
site's analytics can tell them apart". When `generate_3d` output suggests buying Premium, that text came
from a constant in the package, not from a technical necessity.

**5. Verdict. Hold** — it works, but every call is paid, the output's commercial-use rights are unread,
and `Tools/ai3d/triposr_run.py` plus `Tools/monster_gen/` already cover this locally.

### 1c. `generate_gaussian_world` — **reject**, on four independent grounds

**VERIFIED — source read.** Provider is World Labs Marble (`WORLD_PROVIDERS = ("worldlabs",)`). The
docstring: each call "costs the user money or a high-quality monthly generation, and takes about 5
minutes", and the output is "a photoreal capture of the place, not editable meshes".

1. **It cannot run here at all.** It requires Blender 5.3+ (`WORLDLABS_PROTOCOL = 16`); we run Blender
   **5.2** at `E:/SteamLibrary/steamapps/common/Blender/blender.exe`.
2. **Gaussian splats are not meshes**, so nothing downstream consumes them — not
   `Tools/blender/bake_to_game.py`, not `Game/Assets/_Game/Editor/Terrain/TerrainTileImportStub.cs`, not
   `Tools/atlas/`. URP has no splat renderer here.
3. **Photoreal is the opposite of the house look** that `Tools/blender/toon_preview.py` and
   `render_toon_sheet.py` exist to enforce.
4. A 500k-splat viewport (the default; `full_res` is ~2 million) is not a workspace on a **GTX 1650 with
   4 GB**.

**5. Verdict. Reject.** Any one of those four is sufficient on its own.

### 1d. `record_trajectory_feedback` and the telemetry pipeline — **never call it; close the residual stream**

**VERIFIED — source read** (`trajectory.py`, `telemetry.py`, `config.py`, `server.py` ~1433–1472,
`addon.py` ~1167–1200, ~1860–1885, ~3576–3608, ~6873–6884).

**1. What it is.** Not a feedback box. `trajectory.py`'s own module docstring describes "Minimal Dataset B
trajectory capture … Intent → State → Action → State′ → Observation → Feedback", persisted to a Supabase
project owned by the package author (`config.py` hardcodes the URL, the anon key, and a
`telemetry-screenshots` storage bucket). It is an **agent-training-data collection pipeline**, and
`record_trajectory_feedback` is the reward label on it. `@trajectory_tool` and `@observe_tool` decorators
sit on `look`, `generate_3d`, the Sketchfab search and download paths and more, so steps are captured
around ordinary tool use, not only when feedback is recorded. The add-on additionally hooks `undo_post`,
`redo_post` and `depsgraph_update_post` to capture **the user's own manual Blender edits**.

**2. What it would do for us.** Nothing good. The payload includes `correction_text` (up to 3900 chars)
and `goal_text` (up to 1000 chars) — the user's own words — and every tool in the server takes a
`user_prompt` parameter documented as "the user's own words … quoted verbatim". On an AETHWYRD session
that is our art direction in plain English, alongside **viewport screenshots of unreleased creatures,
buildings and terrain**. For an unannounced commercial game that is an IP-disclosure path, not a privacy
nitpick.

**3. Cost, licence and requirements.** Free, and gated — this is the good news, and both sides of the gate
were read. The add-on preference is `telemetry_consent … default=False`, **off by default**. Both
`telemetry.py` and the add-on **fail closed** ("Unreachable Blender means no"). With consent off, no
trajectory row and no screenshot leaves the machine, `upload_screenshot` returns empty, the human-activity
buffer is discarded rather than accumulated, and `record_event` strips prompts, code, params, screenshots
and scene info, replacing error text with "Error occurred (details withheld without consent)".

**What still leaves the machine with consent OFF — i.e. what is going out right now:** `customer_uuid`,
`session_id`, `event_type`, `tool_name`, `success`, `duration_ms`, version, platform, Blender version,
add-on version and timestamp. The `customer_uuid` is written to `%APPDATA%/BlenderMCP/customer_uuid.txt`
and **persists across sessions**, so this is pseudonymous rather than anonymous: a stable per-machine id
plus a tool-by-tool activity log.

**The `disable_telemetry` tool only does half the job.** It sets consent false, and its own reply says so:
"Minimal anonymous usage counts (tool name, success, duration) still apply." The only switch that stops
everything is the environment variable — `telemetry.py` honours `DISABLE_TELEMETRY`,
`BLENDER_MCP_DISABLE_TELEMETRY` or `MCP_DISABLE_TELEMETRY` set to `true/1/yes/on`, which short-circuits
`record_event`, `upload_screenshot` and the trajectory writer alike.

**4. Effort and risk.** Minutes. **`13_Production/tutorial_vision.md` already prescribes
`-e DISABLE_TELEMETRY=true`, and the live config in `C:/Users/marce/.claude.json` does not carry it** —
it launches `uvx blender-mcp` with only `UV_PYTHON_INSTALL_DIR` set. That is a documented intention that
did not reach the machine. **Needs the user's action:** that is the user's own config file and Claude
should not edit it unasked.

**5. Verdict. Reject the tool, adopt the setting** — never call `record_trajectory_feedback` (with consent
off it is a harmless no-op, and there is no reason to call it either way), keep the consent box unticked,
and add `DISABLE_TELEMETRY=true` to the `blender` MCP entry. One line in `tutorial_vision.md` should say
so, so the next session does not have to re-derive it.

Related, and already half-documented: `BLENDER_MCP_SAFE_MODE=1` exists (there is a 45 KB `safe_mode.py`)
and screens scripts passed to `execute_blender_code`.

---

## Still open in this area

Being written by the ongoing sweep; this section is the resume point.

- **MCP for Unity (`CoplayDev/unity-mcp`)** — version, licence, Unity-version support, tool list. This
  one decides whether the installation that `13_Production/tutorial_vision.md` is waiting on the user to
  approve is worth approving.
- Unity MCP alternatives; Blender MCP alternatives.
- Retopology and mesh decimation (meshoptimizer, gltf-transform, quadriflow, InstantMeshes) — CLI counts,
  it need not be MCP.
- Texturing; animation retargeting; profiling; asset management; documentation lookup.
- The official MCP registry sweep.

## Verified here, outside the sweep

Checked directly against Unity's package documentation on 2026-11-15, because all three bear on entries
elsewhere in this library:

| Package | Version read | Note |
|---|---|---|
| `com.unity.toonshader` (Unity Toon Shader / UTS3) | **0.16.1-preview** | Claims compatibility with Built-in, URP and HDRP. **Preview**, so not a production dependency; see [video_tutorials.md](video_tutorials.md) and the hand-written `Game/Assets/_Game/Art/Shaders/AscendToon.shader` it would replace. |
| `com.unity.memoryprofiler` | **1.2.0** | Editor tool for finding leaks and wasteful allocation. `NOT SOURCEABLE — the page gives no minimum Editor version.` Not in `Game/Packages/manifest.json`. |
| `com.unity.performance.profile-analyzer` | **1.4.2** | Summarises and compares sets of Profiler captures, including GC allocation bytes. Compatible with Unity 2021.3 and later. Not in `Game/Packages/manifest.json`. |
