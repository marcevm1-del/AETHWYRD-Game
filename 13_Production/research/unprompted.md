# Things nobody asked about

> Findings that fell out of the sweeps and fit none of the requested areas — or that matter more than the
> area they were found in. Entry format and verification vocabulary: [README.md](README.md). Each line
> names where the evidence is.

## A. Defects in the repo, found by reading it

| # | Finding | Evidence | Fix |
|---|---|---|---|
| 1 | **The save write is not atomic, and its comment says it is.** `PlayerSave.Save()` deletes the live file *before* moving the temp file over it, so between the two no slot file exists, and `Load()` never looks at the complete `.tmp` beside it. No rotating backup. | [techniques A3b](techniques_and_systems.md) | 3–5 h. Highest value per hour in the library |
| 2 | **The migration suite tests a loader the game does not use.** Tests deserialise with `System.Text.Json`; `PlayerSave.cs` uses Newtonsoft. | [techniques A3a](techniques_and_systems.md) | 3–6 h |
| 3 | **`SaveGame` stores absolute Unity floats**, and the world origin was set to the map's north-west corner (floats reach +153,600 m, ULP 15.6 mm) against the plan's own Brindlewick recommendation. The plan document still contradicts `Data/World/world_scale.json`. No rebase code exists. | [techniques A1, A2](techniques_and_systems.md) | 4–8 h for the save half, before it matters |
| 4 | **The lock-on and companion-follow feel constants are hardcoded C#**, in a project whose rule is data-driven JSON. | [techniques B4](techniques_and_systems.md) | under 2 h |
| 5 | **`AscendToon.shader` has no DOTS-instancing block**, so every toon building would be excluded from the GPU Resident Drawer. | [techniques A6](techniques_and_systems.md) | measure first |
| 6 | **The whole player-facing UI is runtime IMGUI** (181 `GUI.*` calls, no TextMeshPro, no UXML); `BagWindow.cs` calls itself a placeholder. Accessibility needs (text scaling, colourblind modes) are hard to meet on IMGUI. | [skills_and_plugins §4b](skills_and_plugins.md) | a user and Canon decision |
| 7 | **`com.unity.modules.unityanalytics` and `adaptiveperformance` are in the manifest**, probably by default. A shipped analytics module in an offline-complete teen-rated game is worth a deliberate decision. | [mcp_servers §8](mcp_servers.md) | 15 min |
| 8 | **The Unity splash screen is on** (`m_ShowUnitySplashScreen: 1`) though Unity 6 makes it optional. | [asset_sources A3](asset_sources.md) | under 1 h |

## B. Documentation that is wrong

- **`13_Production/tutorial_vision.md` says MCP for Unity is "editor-only". It is not**: its Runtime
  assembly compiles into player builds. It also says it "has no screenshot tool"; 10.3.0 has one, so
  `TutorialVisionCapture.cs` may be redundant. ([mcp_servers §2b](mcp_servers.md))
- **It prescribes `DISABLE_TELEMETRY=true` for the Blender MCP; the live config does not have it.**
  ([mcp_servers §1d](mcp_servers.md))
- **`third_party_assets.md` and `E:\Ideas\README.md` name a folder that no longer exists**
  (`E:\Ideas\Asset-Library`); it is `Resources\Asset-Library\`, and that folder **is not gitignored**
  (about 140 MB of third-party archives, including GPL and CC-BY-SA art, one `git add -A` from the
  `aetheria` remote). ([asset_sources A0](asset_sources.md))
- **`terrain_unity_import.md` §2 still recommends a Brindlewick origin**, contradicting
  `Data/World/world_scale.json`.
- The register's "Not imported until licence confirmed" table should move `human-base-mesh.zip` (CC-BY-SA
  and GPL) to "Not for the game".

## C. Money, accounts and decisions only the user can make

| Decision | Why it is theirs | Source |
|---|---|---|
| Set `DISABLE_TELEMETRY=true` in `~/.claude.json`; optionally pin `uvx mcp-for-blender@2.2.9` | Their config file | [mcp_servers §1e](mcp_servers.md) |
| Whether to accept a public AI-disclosure on the Steam page so TripoSR output may ship, or demote TripoSR to blockout-only | Policy | [asset_sources A2](asset_sources.md) |
| Whether to contact Clint Bellanger about permissive terms for `potions.blend` (21 potion meshes) | Contacting a third party | [asset_sources A1](asset_sources.md) |
| Unity Pro, $210/month or from $2,310/yr, **only if** Unity-connected revenue passes $200,000 over a trailing 12 months, tested daily | Money, but on success | [asset_sources A3](asset_sources.md) |
| A Steam partner account and appid, before any upload automation | Money and account | [video_tutorials §2](video_tutorials.md) |
| An Adobe account for Mixamo, after reading its terms | Account | [mcp_servers §5](mcp_servers.md) |
| Poly Pizza API key, **never** Sketchfab | Account, and a licence trap | [mcp_servers §1e](mcp_servers.md) |
| A C# language server plugin | An install | [skills_and_plugins §3h](skills_and_plugins.md) |

## D. Process findings about running this project

- **Usage limits killed this research session's own subagents three times.** The levers for that problem
  are free and unused: model-tier the 49 agents on `inherit`, add `maxTurns` to the 27 that lack it, set
  `crossSessionInbound: hold`, disable the ~28 irrelevant plugins, and measure with `/usage` first
  ([skills_and_plugins §3](skills_and_plugins.md)). `ListPlugins` shows 30 enabled plugins, two on-subject.
- **Heredocs with apostrophes or non-ASCII broke subagent writes repeatedly** — CLAUDE.md's own rule. Every
  failed sweep call here was one. Briefs should say "use Write and Edit, not heredocs" up front.
- **`tv.py scan` spends its frame budget on a webcam inset**, because the activity measure sees a moving
  face. A `--ignore-rect` option would raise the yield of every talking-head tutorial
  ([video_tutorials §5](video_tutorials.md)).
- **Searching YouTube through `yt-dlp ytsearch<N>:<query> --flat-playlist --print`** returns real ids,
  durations, channels and view counts, which beats web search (mostly SEO aggregator pages) for finding
  primary-source videos.
- **A second Blender (5.3) is installed**, and the repo's scripts assume 5.2.

## E. Method worth keeping

For old Blender files, **the licence is often inside the file as a text datablock**, and internal paths
identify the author when the archive has no readme. Byte-scanning a `.blend` is safe (no Blender, no
execution) and resolved three of five unlicensed archives in minutes after web search found nothing.
([asset_sources A1](asset_sources.md))

## F. Compliance seeds, not verified

Steam's EU trader-information requirement under the DSA; whether the European Accessibility Act reaches
games; whether EU AI Act Article 50 reaches shipped pre-generated assets; the copyrightability of AI
output and what it means for TripoSR meshes; trademark searches for AETHWYRD and for Karak (the repo
already flags the dwarf-hold echo); an EULA carve-out for third-party assets under their own open licences
(CC BY 4.0 §2(a)(5)(B)). All belong in the IP-lawyer review Canon already schedules.
