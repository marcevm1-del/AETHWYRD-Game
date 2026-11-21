# Top ten shortlist

> Ordered by what would help this game most **per hour of work**, across every area. Hours are the
> estimates in each entry. Verdicts follow the rule in [README.md](README.md): an unverified licence is
> never "adopt now". Nothing here has been done; this is a recommendation.

| # | What | Hours | Why it is here | Entry |
|---|---|---|---|---|
| 1 | **Housekeeping batch: `DISABLE_TELEMETRY=true`, gitignore `Resources/Asset-Library/`, correct the stale paths** | ~0.5 | Closes an IP-disclosure path (Blender MCP can upload screenshots of unreleased art if a re-asked dialog is mis-clicked) and keeps ~140 MB of GPL and CC-BY-SA art out of the remote. **Needs the user for the config file.** | [mcp §1e](mcp_servers.md), [assets A0](asset_sources.md) |
| 2 | **Make `PlayerSave.Save()` safe**: three-file rotation with a `.bak`, `Load()` that offers `.tmp` or `.bak`, fault-injection tests | 3–5 | A save-destroying window with a comment claiming the opposite. For a premium single-player RPG the save *is* the player's investment | [techniques A3b, B2](techniques_and_systems.md) |
| 3 | **Golden-save fixture corpus, and run the suite through the real loader (Newtonsoft)** | 6–12 | Version 1 has not shipped, so the corpus is still free to create; without it "a save from N opens in N+5" is untestable | [techniques A3a, A4](techniques_and_systems.md) |
| 4 | **Usage-limit levers: `/usage` first, model-tier the 49 `inherit` agents, `maxTurns` on our 27, `crossSessionInbound: hold`, disable the ~28 irrelevant plugins** | 4–7 | Usage limits kill waves of sessions (they killed this one's subagents three times). All free and already installed | [skills §3](skills_and_plugins.md) |
| 5 | **Make saved positions origin-independent, and settle the origin decision** | 4–8 | The first real v1→v2 migration; skipping it costs nothing today and has no clean answer once saves exist. Also fixes a doc/data contradiction | [techniques A1, A2](techniques_and_systems.md) |
| 6 | **Blender retopology script** (`Tools/blender/retopo_creature.py`, QuadriFlow + Decimate) | 2–4 | Closes the named gap in `monster_model_pipeline.md`; free, CPU-only, already installed | [mcp §4](mcp_servers.md) |
| 7 | **`unity mcp` trial plus `parse-test-results.js`** | 2.5–5 | First-party, already installed, 200–600 ms warm Editor; plus NUnit XML turned into a few lines for the 196 PlayMode tests. **Needs the user to add `com.unity.pipeline`.** Beta — commit first, keep a file-editing fallback for Safe Mode | [mcp §2a](mcp_servers.md), [skills §2a](skills_and_plugins.md) |
| 8 | **`PreToolUse` log-filter hook plus a project `settings.json`** | 6–12 | Every other item *adds* context; this subtracts it in all ~40 sessions. Must report what it suppressed or it hides failures | [skills §3a, 3g](skills_and_plugins.md) |
| 9 | **Add the memory profiler and profile analyzer packages, and measure three real tiles on the GTX 1650** | 3–5 | The 4 GB budget is currently arithmetic, not measurement. Streaming decisions (Addressables, GPU Resident Drawer, impostors) all wait on it | [mcp §6](mcp_servers.md), [techniques B1](techniques_and_systems.md) |
| 10 | **Path-map the 12 code-side agents and the ~25 file-writing skills; retire `analytics-engineer` and three more** | 5–10 | The path-map reached 22 of 61 agents and 0 of 74 skills — and missed every engineer. `analytics-engineer` contradicts offline-complete | [skills §5](skills_and_plugins.md) |

**Also worth doing, just below the line:** barks as dialogues from the unused `ThreatLevel` hook (8–16 h,
the best perceived-intelligence per hour); lock-on and follow constants into JSON (under 2 h);
`@gltf-transform/cli` after `bake_to_game.py` (2–4 h); incremental contact-sheet rebuilds (3–6 h, skip
unchanged tiles — the per-tile PNGs are already kept); the Unity splash off (under 1 h); a credits screen
generated from a `Data/` JSON (an unavoidable deliverable that `Unity §2.12` already makes mandatory).

## What I would do first, if it were my call

**Items 1 and 2 in one sitting, this week.** Item 1 is thirty minutes and removes a quiet risk; item 2 is
the only finding in the library that can lose a player's progress, it needs no third party, and it is
cheap. Then item 3 while version 1 is still unshipped, because that window closes and never reopens.
Item 4 before the next large wave: the project has already lost work to the limit, and the fix is
configuration. Everything on streaming waits for item 9, because the sourced evidence is thin and a
measurement beats a recommendation.

## The three findings I think are most valuable

1. **Floating origin is designed but unbuilt, the one decision taken doubled its error, and the save format
   would break when it moves.** (Items 3, 5.)
2. **The save write can destroy a save, and the tests prove their guarantees about a loader the game does
   not use.** (Items 2, 3.)
3. **The Blender MCP already installed has a training-data pipeline behind a re-askable consent dialog, an
   unpinned version, and no licence filter on imports — and the Unity CLI with an MCP server is already
   installed too.** The tools that would help most are on this machine; they need configuring, not buying.

## Judged not worth our time

| Item | Why |
|---|---|
| Octahedral impostors | Hundreds of hours; the atlas alone could consume the VRAM budget; the plan's decimated far ring under fog is better |
| GPU Resident Drawer | Needs a renderer-path migration and a shader rewrite, and animated characters are excluded regardless |
| Addressables | An offline game gains nothing from its remote half, and half-converted projects duplicate memory |
| `generate_gaussian_world` | Splats are not meshes, photoreal fights the toon look, 500k splats on a 4 GB card is not a workspace |
| `generate_3d` (hosted) | Paid per call, output rights unread, and the free local TripoSR has never been run |
| dev-gom `unity-editor-toolkit` | Compiles a WebSocket server into the player build; unlicensed DLL; first-party route exists |
| dev-gom auto-commit, auto-stage, auto-docs | Bare `git add -A` on a shared `main` across ~40 sessions; their off-switch is not a real hook field |
| Issue-tracking MCP servers (Linear, Jira, ClickUp) | An account and a third-party data home for an unannounced game; GitHub Issues is enough |
| `unity-dots-specialist`-style ECS migration | A rewrite nobody has proposed |
| Unity Toon Shader package | `0.16.1-preview` — a preview package under the whole look of the game. Keep its eight-zone vocabulary only |
