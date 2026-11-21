# MCP servers for a Unity + Blender pipeline

> Entry format and verification vocabulary: [README.md](README.md). Nothing here was installed,
> bought or signed up for. Where a tool is already configured on this machine, its **package source
> was read from the local uv cache** rather than its marketing page, and the entry says so.
>
> **Source weighting used throughout:** package source on disk > `LICENSE` and repo files >
> official docs > blog or search snippet (marked `SECONDARY`).


> **Read §1e before acting on §1a or §1d.** A second pass through the package source corrected two
> claims there: Poly Pizza *does* need an API key, and the telemetry consent can be switched on from a
> dialog inside Claude Code (it was already declined). Sections 2 onward add the Unity MCP, the Blender
> alternative, mesh optimisation, retargeting, profiling and the adjacent finds.

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

---

## 1e. Corrections to 1a and 1d — read the source again, and two claims above were wrong

**VERIFIED — source read.** Where this section disagrees with §1a or §1d, **this section is right.**

**Correction A — all three asset sources are gated, not just Sketchfab.** §1a said Poly Pizza "needs no
key". It does. `addon.py` registers each source's handlers only behind a per-scene checkbox
(`blendermcp_use_polyhaven`, `_sketchfab`, `_polypizza`), **all `default=False`**, and Poly Pizza *also*
needs a free API key (its own status string says "API key is not given. To enable it: Get a free API key
at poly.pizza/settings/api"). Poly Haven needs only the checkbox. So the reachable default is **no asset
source at all**, and the order of exposure is: (1) **Poly Haven**, one checkbox, CC0, harmless — the one
to enable; (2) **Poly Pizza**, checkbox plus a key, **needs the user's decision: account / key**, and if
enabled the CC-BY trap is live so `licence="CC0"` must be passed on every search; (3) **Sketchfab**,
checkbox plus a key, the *only* source with no licence filter at all — **recommend never enabling it.**
The tick state lives inside `.blend` scenes and `userpref.blend`, so it cannot be read from disk without
calling a tool (which itself emits a usage event). **Ask the user or check the N-panel.**

**Correction B — the telemetry consent can be switched ON from inside Claude, by a dialog, and it has
already been answered.** §1d said to "leave the box unticked" as if that were purely a Blender-side
choice. `blender_mcp/consent_prompt.py` appends a consent prompt to the return value of
**`get_addon_status`** — which the server's own instructions say to call first — and it renders as a real
yes/no dialog in Claude Code asking whether to share "your prompts, the code that gets generated,
viewport screenshots, and scene metadata". It is one click. **The live state, read from
`C:/Users/marce/.config/blender-mcp/consent_prompt.json`:** `{"action": "decline", "consent": false,
"via": "elicitation", "prompt_version": 2}` — **the user was already shown it (about 2026-10-24) and
declined.** The residual risk: the file records `prompt_version`, and the code says *"Bump to re-ask
everyone"*. Our config is unpinned `uvx blender-mcp`, so the day the author bumps it to 3 **the dialog
returns mid-task and looks like a routine permission prompt.** Also, `execute_blender_code` is arbitrary
`bpy`, so it *can* set the preference directly; the checkbox is not a hard boundary.
`NOT SOURCEABLE — whether BLENDER_MCP_SAFE_MODE blocks preference writes.`

**What that changes.** `DISABLE_TELEMETRY=true` is now the **primary** control, not a belt-and-braces
one: it sets `config.enabled = False`, checked at the top of `record_event`, `upload_screenshot` and the
trajectory writer, so **nothing is transmitted even if consent were flipped on by a dialog or by stray
code.** (The dialog can still *appear* with the variable set; it would be inert — cosmetic, not a leak.)
In order: (1) set `DISABLE_TELEMETRY=true` on the `blender` entry in `C:/Users/marce/.claude.json` —
**needs the user's action, it is their file, 5 minutes**; (2) consider pinning `uvx mcp-for-blender@2.2.9`
— **needs the user's decision**; (3) if the dialog ever reappears, **decline it** and note that in
`tutorial_vision.md`; (4) never call `record_trajectory_feedback`.

**Correction C — the installed add-on is behind the server, and there are two Blender installs.**
`AppData/Roaming/Blender Foundation/Blender/5.2/scripts/addons/blender_mcp_addon.py` is version **1.8**;
the add-on bundled with server 2.2.9 is **2.0** (protocol 16). Newer commands come back as "Unknown
command type" and become a "please update" message; `uvx mcp-for-blender install-addon` then a Blender
restart fixes it, ~10 minutes. Config directories exist for **both 5.2 and 5.3**, and 5.3 was touched on
2026-11-15, so a second Blender is on this machine. **That partly retracts §1c's "Blender 5.2 cannot run
it"**, but the reject stands on the other three grounds (splats are not meshes, photoreal fights the toon
look, 500k splats on a 4 GB card). `NOT SOURCEABLE — which Blender binary sits at the Steam path.`
Worth confirming: a script run against the wrong Blender silently gets different behaviour.

A further `SECONDARY` item: one comparison article states **four CVEs were published against
`ahujasid/blender-mcp` during 2026**. `NOT SOURCEABLE — the CVE numbers, severities and fix status.`
Check the repository's security advisories before the next session; if they are fixed above 2.2.9 that
argues for *updating* rather than pinning, which cuts against recommendation (2).

---

## 2. MCP for Unity: two routes, and the first-party one is already on this machine

### 2a. `unity mcp` — Unity's own CLI has an MCP server built in — **adopt (trial-grade), evaluate first**

**VERIFIED — source read, and run.** `which unity` → `AppData/Local/Unity/bin/unity`; `unity --version` →
`1.0.0-beta.13`; `unity mcp --help` → "MCP server and client configuration for Unity Editor". The
installed plugin's `unity-cli/SKILL.md` and `references/integration-advanced.md` were read.

**1. What it is.** The official `unity` CLI exposes a connected Editor's commands as MCP tools over stdio,
and the tool list is **dynamic** — "commands that a connected Editor adds show up as tools
automatically". The Editor side is the first-party `com.unity.pipeline` package from Unity's own registry.
`unity mcp configure claude-code --dry-run` previews the config change.

**2. What it would do for us.** It reaches the same three bottlenecks as the community server, first-party:
the **196 PlayMode tests**; **terrain tile import** (`unity command eval` can drive
`Game/Assets/_Game/Editor/Terrain/TerrainTileImportStub.cs` instead of a human clicking a menu); and
scene work across `Game/Assets/_Game/Runtime/` without hand-editing `.unity` YAML. The decisive fact is
speed: a connected Editor answers in **200–600 ms with no script recompile and no domain reload**, versus
a cold batch start per action — the difference between a loop an agent can iterate in and one it cannot.
And `integration-advanced.md` covers authoring custom `[CliCommand]` tools, so **the MCP surface can be
made to match our pipeline** (bake-and-import a creature, rebuild a contact sheet) instead of the other
way round.

**3. Cost, licence and requirements.** Free, no account for the MCP part, no GPU. `com.unity.pipeline`
needs **Unity 6.0+** — ours is 6000.6.7f1, a first-party statement and not an inferred floor. The plugin
wrapping it is `LicenseRef-Unity-Companion-License`, `0.1.2-beta`. `NOT SOURCEABLE — telemetry behaviour
of the unity CLI; read SECURITY.md first, given what §1d found in the Blender server.`

**4. Effort and risk.** **1.5–3 h**: ~15 min `unity pipeline install` and `unity status`; ~15 min
configure; ~1 h to confirm the 196 tests run through it; ~30 min on `SECURITY.md`; ~1 h first real use on
terrain import. **It is beta** (`1.0.0-beta.13`, `UNITY_CLI_CHANNEL=beta`), so expect breaking changes
between betas. `eval` runs arbitrary C# in the live Editor — **commit first.** And it adds
`com.unity.pipeline` to `Game/Packages/manifest.json`.

**The Safe Mode deadlock is documented and will bite.** *"When a project has C# compile errors, the
Unity Editor starts in Safe Mode… the MCP server cannot connect… This is a deadlock for an agent that
wants to fix the compile errors through the Editor… there is no CLI-side workaround."* **Design rule: never
build an agent process that assumes the Editor is reachable; always keep the file-editing path for
compile errors.**

**5. Verdict. Adopt — trial-grade — and evaluate it before CoplayDev.** First-party, free, already
installed, an explicit Unity 6.0+ statement, and no third-party assembly in the shipping build. (This
supersedes the "the install is `irm … | iex`" caution in
[skills_and_plugins.md](skills_and_plugins.md) §4a: the CLI is **already installed here**.)

### 2b. `CoplayDev/unity-mcp` ("MCP for Unity") v10.3.0 — trial, on a branch

**VERIFIED — source read** (LICENSE, `package.json`, `pyproject.toml`, the Runtime `.asmdef`, the 74-entry
`Editor/Tools/` listing, `ManageProfiler.cs`, `BlenderBridgeTool.cs`; not the README). **MIT**,
"Copyright (c) 2025 CoplayDev". Declared minimum Unity **2021.3**; `NOT SOURCEABLE — a statement that
10.3.0 is tested on 6000.6.x`, so treat it as allowed, not confirmed. Python ≥ 3.10.

**What it adds over 2a — a curated tool surface:** `manage_profiler` (`get_frame_timing`, `get_counters`,
`memory_take_snapshot`, `memory_compare_snapshots`, `frame_debugger_get_events`; opt-in, `AutoRegister =
false`) — **the only agent-drivable profiling route found anywhere in this sweep, and the right one for a
GTX 1650 with 4 GB**; `blender_bridge` (`import_model`, `compare_screenshot`, `screenshot`), which talks
to the **same Blender add-on we already run** and so automates the Blender→Unity seam that
`Tools/blender/bake_to_game.py` and the terrain stub leave manual; `manage_graphics` with renderer-feature
and Volume operations (the URP toon pipeline); `ManageAnimation` for Animator controllers and blend trees;
`RunTests`/`ReadConsole`. It adds **no new transitive dependencies** — every module it needs is already in
our manifest, and `com.unity.test-framework` is 1.4.6 against its 1.1.31 floor.

**Two corrections to `13_Production/tutorial_vision.md`, which is currently wrong on both:**
1. **It says the package is "editor-only". It is not.** `MCPForUnity.Runtime.asmdef` has
   `"includePlatforms": []` and `autoReferenced: true`, so **that assembly compiles into player builds**.
   Its contents are small compatibility shims and a screenshot helper, so benign-looking — but it is a
   third-party MIT assembly in the retail build unless excluded. Cheap to fix; it must be a deliberate
   step, and it belongs in `third_party_assets.md`.
2. **It says "MCP for Unity has no screenshot tool".** 10.3.0 has `ScreenshotUtility.cs` and a
   `screenshot` action, so **`Game/Assets/_Game/Editor/TutorialVisionCapture.cs` may now be redundant.**

**Effort and risk: 3–5 h**, and a higher-stakes install than the Blender one: it mutates the game
project, and `ExecuteCode`, `ExecuteMenuItem` and `BatchExecute` mean an agent can run arbitrary C# and
menu items. **Adopt on a branch with everything committed.** The documented install pins `#main`, so **a
fresh clone resolves to whatever `main` is that day** — pin `#v10.3.0`, or vendor it under `Packages/` for
a project that must build years from now. `NOT SOURCEABLE — server telemetry; grep `Server/src/` for
analytics, posthog, supabase and DISABLE_* before installing.` Coplay is a commercial company: assume an
upsell path exists until checked. **Verdict: trial**, *after* 2a, to add `manage_profiler` and
`blender_bridge` on top. They are not mutually exclusive. Free, needs no account — no money anywhere.

**Other Unity MCP servers** (triage, `SECONDARY`): licences run MIT to **GPLv3**; a GPLv3 package inside
`Game/Assets` of a closed-source game is a genuine legal problem. **Read the specific repo's LICENSE; the
star count is not what to compare.** Hold.

---

## 3. Blender: replace the server we run?

### 3a. The official Blender Lab MCP server — trial, the user's hour to read first

**`Verified: docs only` — and with a caveat.** Direct fetches of `blender.org/lab/mcp-server/` and
`projects.blender.org/lab/blender_mcp` returned **HTTP 403**. What follows came from a search restricted
to Blender's own domains; **every figure needs a direct read before adoption.** It is a first-party
Blender Foundation server (an extension plus a `.mcpb` bundle), **requires Blender 5.1+** (we are on 5.2),
reportedly slated for 5.2 LTS, latest **v1.0.3 (2026-09-11)**, first stable 2026-04-27.
`NOT SOURCEABLE — its licence (Blender's code is GPL, so very likely GPL-2.0-or-later) and tool list.`

**Why care:** a first-party server very unlikely ships a Supabase training-data pipeline, a screenshot
bucket or a referral-link upsell, which is exactly what §1d found in the one we run — and for an
unannounced commercial game that is the point. **3–6 h**, mostly migration: the two expose different tool
names, so `13_Production/tutorial_vision.md` and `.claude/agents/youtube-beta.md` assume
`mcp__blender__*`. It may expose *less*. **Run both side by side** — nothing stops two servers being
configured. Blender's own documentation recommends running LLM-driven Blender on a VM or a machine without
sensitive data; we run it on the one machine holding the whole game. That is a defensible solo-developer
choice, but it should be a **conscious** one, recorded in `tutorial_vision.md`.
**Verdict: trial.** An unconfirmed licence and an unread tool list cannot carry "adopt now".

---

## 4. Mesh optimisation: mostly not an MCP server

Three of the four best tools are already on this machine. An MCP server would add only indirection.

- **Blender's QuadriFlow remesh and Decimate modifier, via a headless script — SUPERSEDED. Do not build
  this for game LODs:** running the pipeline showed `bake_to_game.py` already does LODs (voxel remesh plus
  quadric collapse) and the goblin source is 151,423 faces; see [blender_primer.md](blender_primer.md) §6.
  The remaining use is rig-prep quad topology, untested. Original text follows: This is the named gap in
  [monster_model_pipeline.md](../monster_model_pipeline.md): `Tools/ai3d/triposr_run.py` and
  `Tools/monster_gen/` produce dense output that needs retopology before `Tools/blender/rig_creature.py`
  can weight it. A `Tools/blender/retopo_creature.py` beside the existing generators, **2–4 h**, mostly
  tuning target face counts per creature class. CPU-bound, so a 4 GB card is irrelevant. Keep
  `render_toon_sheet.py` as the quality check, since automatic retopology on organic shapes needs a human
  eye. `NOT SOURCEABLE — Blender 5.2's operator names and parameters; verify against docs.blender.org.`
- **`@gltf-transform/cli` v4.5.1, MIT — adopt now, as a CLI.** **VERIFIED**, read from the npm registry's
  own metadata. One install buys `meshoptimizer` simplification, Draco, KTX2, UV atlas (`watlas`),
  tangents and `gltf-validator`. It slots after `Tools/blender/bake_to_game.py` and before Unity, for LODs,
  VRAM-budget texture work, and a validation gate. **2–4 h.** glTF only, so it helps on the GLB path, not
  the FBX one. Needs `npm install` (native binaries for `sharp` and `draco3dgltf`) — **needs the user's
  action**, no money or account. **An already-installed skill, `threejs-agents-model-optimizer`, wraps
  exactly this toolchain and encodes the decisions (which compression, what ratios, when KTX2) — read it
  before writing any glTF script.**
- `gltfpack`, standalone Instant Meshes / QuadriFlow, and an MCP wrapper around gltf-transform: **hold**.
  Texturing: Blender's own baking, which we already do, is the answer; Material Maker and ArmorPaint-likes
  are **hold**.

## 5. Animation retargeting

- **Unity's built-in Humanoid avatar retargeting — adopt now for humanoids.** Free, in-engine, zero new
  dependency. **Not applicable to creatures.**
- **Mixamo — hold, and it cannot be "adopt now".** `SECONDARY` throughout: every source found was an Adobe
  community forum post or a third-party summary, and **the live terms were not read.** What those sources
  consistently say (unverified): free for personal, commercial and non-profit projects *including video
  games*; the restriction is on redistributing the data as assets; and terms apply as of the time of use.
  It needs an Adobe account (**needs the user's decision: account**), it is an **online service for an
  offline-complete game** — fine for build-time acquisition but a dependency that could vanish, so
  **download and archive what we use** — and it must be recorded in `third_party_assets.md`. First task:
  read `helpx.adobe.com/creative-cloud/faq/mixamo-faq.html` and Adobe's Terms of Use directly, about 1 h.
- Auto-Rig Pro, Rokoko and similar: paid, hold.

## 6. Profiling

**Adopt now: `com.unity.memoryprofiler` 1.2.0 and `com.unity.performance.profile-analyzer` 1.4.2**
(versions confirmed in §Verified below). Free, first-party, editor-only, aimed straight at the hardest
constraint (4 GB VRAM), **1–2 h**, and **neither is in `Game/Packages/manifest.json`.** The cheapest real
win in the sweep after the retopology script, and it reduces the urgency of `manage_profiler`: these two
cover analysis while the Unity MCP can trigger captures. RenderDoc and Superluminal: external tools, hold.

## 7. Asset management, issue tracking, documentation

- **GitHub Issues plus `13_Production/` plus the installed `bug-report` and `tech-debt` skills is already
  enough — adopt (already adopted).** **Reject** any issue-tracking MCP server (Linear, Jira, ClickUp,
  Asana — several are configured in this session, unauthenticated): each needs an account and a network
  service, adds a third-party data home for an unannounced game's design notes, and solves a coordination
  problem we do not have. If a local store is ever wanted, a markdown file beats all of them.
- **`third_party_assets.md` is genuinely good and is the right asset-management tool.** Harden it with the
  evidence practice in [asset_sources.md](asset_sources.md) §A4.
- **A Blender API lookup we already have and may not know about: `bpy_api_lookup` and `describe_node_type`.**
  `Verified: source read` — both are in the add-on's command table. A live, version-exact reference for the
  Blender we are running, strictly better than search for the 2.8→5.x socket-renaming problem
  `tutorial_vision.md` documents. **They are add-on commands, not MCP tools**, reachable through
  `execute_blender_code` or a newer server, and the installed 1.8 add-on may lack them (Correction C).
  ~1 h. **Adopt.**
- General documentation MCPs (Context7 and similar): hold; they add a network dependency for what the above
  gives locally.

**The MCP registry sweep was a negative finding** — nothing relevant to Unity or Blender game work surfaced
beyond what is above.

---

## 8. Adjacent finds

1. **Pin every `uvx` MCP entry and every git-URL UPM package.** `uvx <name>` resolves the newest version at
   every launch, and nine `mcp-for-blender` versions are already cached. A project that must build offline
   years from now needs `@2.2.9`-style pins and `#v10.3.0`, not `#main`. It also closes the consent
   re-ask hole.
2. **CC-BY is the licence trap in this pipeline, not CC-NC.** It is commercially usable, so nothing blocks
   it, which is exactly why it slips through — and shipping it without the credit is then a breach.
3. **Know what ships.** `com.unity.modules.unityanalytics` is in the manifest, probably by default rather
   than choice; for an offline-complete teen-rated game a shipped analytics module is worth a deliberate
   decision (15 minutes: check usages, remove it, and a privacy question goes away). The same audit applies
   to `com.unity.adaptiveperformance`, which is mostly a mobile package
   (`NOT SOURCEABLE — its desktop behaviour in 6000.6`). Same lesson as the CoplayDev runtime assembly.
4. **Check the format's age, not just the licence.** FBX 6.1 is unreadable by Blender 5 and COLLADA was
   dropped, which is why `Tools/blender/collada_lite.py` exists; a CC0 pack in an old format costs a day of
   tooling.
5. **Downloaded packs carry executable content.** The register already ignores the 3TD pack's Torque `.cs`
   scripts, correctly. Make it a standing rule: packs extract to `Art/ThirdParty/`, never into
   `Game/Assets/`, and script files in them are **deleted**, not ignored — Unity would *compile* a `.cs`.
6. **`generate_3d` output rights are an unasked question across three tools** (the Blender MCP's four
   providers, a Higgsfield tool, and local TripoSR), and only TripoSR's licence is recorded. And
   **TripoSR is cloned and wrapped but its first mesh appears never to have been generated**, nor the
   Gemini/OpenAI live calls verified — a strong reason not to pay for a hosted generator before the free
   local one is tried. `NOT SOURCEABLE — whether TripoSR fits in 4 GB VRAM.`
7. **The register names a CC0 UI pack, Kenney UI borders, that is sitting unused** while the UI is runtime
   IMGUI placeholder (see [skills_and_plugins.md](skills_and_plugins.md) §4b).
8. **`rea.zip` was correctly excluded**, and the reasoning is the precedent to keep for any *tool* whose use
   would breach the ideas-not-assets rule.

---

## Verified here, outside the sweep

Checked directly against Unity's package documentation on 2026-11-15:

| Package | Version read | Note |
|---|---|---|
| `com.unity.toonshader` (UTS3) | **0.16.1-preview** | Built-in, URP and HDRP. **Preview**, so not a production dependency; see [video_tutorials.md](video_tutorials.md) entry 3 and the hand-written `Game/Assets/_Game/Art/Shaders/AscendToon.shader` it would replace |
| `com.unity.memoryprofiler` | **1.2.0** | `NOT SOURCEABLE — the page gives no minimum Editor version.` Not in the manifest |
| `com.unity.performance.profile-analyzer` | **1.4.2** | Unity 2021.3 and later. Not in the manifest |
