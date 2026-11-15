# Tools, MCP servers and asset sources

Researched 2026-11-15 by the director session, because the `deep-research` session hit the usage limit before it
could start. This covers the part of its brief that was most urgent; the rest of its areas are still open.

## How claims are marked

- **[verified 2026-11-15]** — I opened the primary source myself and quote it. Licence facts come from GitHub's own
  licence metadata or the project's licence page, never from a directory listing.
- **[read]** — from a search result or secondary page, not confirmed at source.
- **NOT SOURCEABLE** — I could not reach a primary source. Recorded as a gap, never filled from memory.

Every entry answers the same five questions, so entries can be compared: what it is, what it does *for us by name*,
cost and licence, effort and risk, verdict.

---

## 1. Blender MCP — `ahujasid/blender-mcp`

**What it is.** A Blender add-on plus a Python MCP server that lets an LLM drive Blender directly: run `bpy` code,
read the scene, take viewport screenshots, search and import Poly Haven and Sketchfab assets, and generate models.

**What it does for us.** This is almost certainly the `blender` MCP already configured in this session — the tool
names match exactly (`execute_blender_code`, `get_scene_info`, `look`, `search_assets`, `import_asset`,
`generate_3d`). It would let an agent iterate on `Tools/blender/ascend_characters` and `ascend_creatures` by looking
at the result instead of rendering a sheet and reading a PNG, which is how yesterday's character work was done.

**Cost and licence.** **MIT** **[verified 2026-11-15, GitHub licence metadata: `spdx_id: "MIT"`]**. Free. Needs
Blender running with the add-on listening on a socket (default port 9876). Sketchfab and the 3D generation feature
need their own accounts and may cost credits — those parts are the user's decision, the rest is not.

**Effort and risk.** Already installed; it has simply been failing to connect, which means Blender is not running
with the add-on. Health: **34,490 stars, last pushed 2026-11-13** **[verified 2026-11-15]**, not archived — this is
a live project, not an abandoned one. Risk is that an LLM running arbitrary `bpy` code in a live Blender can destroy
unsaved work; it should be pointed at a scratch file, never at a `.blend` that matters.

**Verdict: adopt — it is already here.** Getting it connected is the cheapest capability gain available to us. The
connection, not the tool, is the problem.

---

## 2. Unity MCP — `CoplayDev/unity-mcp`

**What it is.** A bridge between an AI assistant and a running Unity Editor: manage assets, control scenes, edit
scripts and automate editor tasks over MCP.

**What it does for us.** Our Unity loop today is batch mode — `-runTests`, `-executeMethod Ring0SceneBuilder.BuildBatch`
— which costs a full editor start per iteration, minutes at a time. Several of yesterday's failures (the streamer
not finding `world_scale.json` in the built player, the animation clips never imported) are the kind of thing a live
editor connection surfaces in seconds. It is the natural counterpart to the Blender MCP for the half of the project
that lives in `Game/`.

**Cost and licence.** **MIT** **[verified 2026-11-15, GitHub licence metadata: `spdx_id: "MIT"`]**. Free, no account.

**Effort and risk.** Health is good: **15,983 stars, last pushed 2026-11-14 — yesterday** **[verified 2026-11-15]**,
not archived, 129 open issues. Installs as a Unity package plus a local server. The real risk is the same as
Blender's, sharper: an agent with editor access can modify scenes and assets in a project with 196 PlayMode tests
and no undo across a batch. It should be trialled against a scratch scene before it is pointed at `Ring0`.

**Verdict: trial.** Highest-value tool found, but prove it on a throwaway scene first. Note several similarly named
projects exist (`CoderGamester/mcp-unity`, `GameBooom/unity-mcp` — the latter is **GPLv3 [read]**, which matters for
a commercial game in a way MIT does not). Check the licence of whichever is installed, not the one researched.

---

## 3. URP outline renderer feature

**What it is.** Our cel-shaded look uses an inverted-hull outline in `Tools/blender/toon_preview.py` — but that is
the *preview* renderer. The game itself needs an outline as a URP renderer feature, and Unity 6 moved renderer
features to Render Graph, so older implementations need porting.

**Three candidates, and they are not equal:**

| Source | Licence | Health | Note |
|---|---|---|---|
| `CristianQiu/Unity-URP-Outline` | **MIT** **[verified]** | **117 stars** | The upstream. Requires Unity 6000.3.0+; we run 6000.6.7f1, so this is satisfied **[read]** |
| `unitycoder/unity-urp-outline` | MIT **[verified]** | **0 stars**, pushed 2024-11-29 | A **fork** of the above. This is the one the search surfaced first |
| `Unity-Technologies/Per-Object_Outline_RenderGraph_RendererFeature_Example` | **NOASSERTION / "Other"** **[verified]** | 38 stars, pushed **2024-07-15** | Unity's own sample, but with **no identifiable open-source licence** and 16 months stale |

**What it does for us.** It is the missing half of our art direction: the toon look is specified and renders in
Blender previews, and the Unity build has no outline pass at all.

**Effort and risk.** The licence finding is the point here. Unity's official example carries `NOASSERTION`, which
means GitHub could not identify a standard licence — for a commercial game that is a question to resolve before
copying code, not after. The fork with 0 stars is not the project to depend on.

**Verdict: adopt the upstream (`CristianQiu`), reject the fork, and treat Unity's sample as reference only** unless
somebody reads its actual licence text. Read the licence file before any of it enters `Game/`, and register it in
`13_Production/third_party_assets.md`.

---

## 4. Poly Haven — textures, HDRIs, models

**What it is.** A free asset library of HDRIs, textures and models.

**What it does for us.** Environment art is our weakest art area (quality 1 on the dashboard, "everything in it is a
stand-in"). Poly Haven is also directly reachable from the Blender MCP's `search_assets`/`import_asset`, so it is
the path of least resistance for dressing Ring 0.

**Cost and licence.** **CC0** **[verified 2026-11-15, polyhaven.com/license]**. The page states assets may be used
"for any purpose", commercial use included, and **"You do not need to give credit"**. Note the carve-out: the site's
own non-asset content (logos, page text) is *not* CC0, and the terms forbid scraping without permission — so use the
site or the API as intended rather than bulk-downloading.

**Effort and risk.** Low. Style is the real risk, not law: Poly Haven is photoreal, and our look is cel-shaded.
Textures and HDRIs will fit better than models.

**Verdict: adopt for textures and lighting, judge models case by case.**

---

## 5. Mixamo — animation retargeting

**What it is.** Adobe's free character animation and auto-rigging library. The `blender-toolkit` plugin cloned to
`E:/Ideas/claude-code-marketplace` offers Mixamo retargeting with fuzzy bone matching, which is why it matters to us.

**What it does for us.** Animation is at quality 1: 106 combat clips, 55 rider clips and 19 facial expressions per
base exist and **have never been played on a character in Unity**. A retargeting path would give us a second source
to compare our procedural clips against.

**Cost and licence. NOT SOURCEABLE.** `helpx.adobe.com/creative-cloud/faq/mixamo-faq.html` returned **HTTP 403** to
me on 2026-11-15, so I could not read Adobe's current terms. Secondhand **[read]**: Adobe forum posts say embedded
use in a commercial game is permitted royalty-free, while redistributing the raw files or selling them as assets is
not; one 2026 guide describes the service as "unmaintained" and Adobe's own older wording calls it a "limited
duration technology preview".

**Effort and risk.** The licence gap is the risk, and it is not a small one: shipping animation data whose terms
nobody has read is exactly the mistake that is expensive after release.

**Verdict: hold.** Do not put Mixamo data in the build until somebody opens Adobe's current terms directly — that
means the user, signed in, since the page refuses anonymous fetches. Our own generated clips have no such question
hanging over them, which is an argument for finishing their Unity import first.

---

## Shortlist

1. **Reconnect the Blender MCP.** Already installed, MIT, actively maintained. Zero cost, immediate capability.
2. **Trial `CoplayDev/unity-mcp` on a scratch scene.** The batch-mode loop is our slowest feedback path.
3. **Adopt `CristianQiu/Unity-URP-Outline`** and give the game the outline its art direction already assumes.
4. **Pull Poly Haven textures and HDRIs into Ring 0** — CC0, no attribution, and reachable from the Blender MCP.
5. **Resolve the Mixamo licence question** before any retargeting work, or decide to skip Mixamo entirely.

**If it were my call:** items 1 and 3. The Blender MCP costs nothing and is already paid for, and the outline is the
single largest visual gap between what our art direction specifies and what the game renders.

## Still open from the deep-research brief

Claude Code skills and plugins beyond the `dev-gom` marketplace; video tutorials mined with `Tools/tutorial_vision`;
techniques for world streaming, companion AI and save migration; and the remaining asset sources — Kenney,
ambientCG, OpenGameArt, Freesound, Quaternius — each of which needs its licence read at source, not assumed.
