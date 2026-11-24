# Scenario skills: what they are and how we use them

Copied from https://github.com/scenario-labs/skills at commit `3c4d18cd0be2e5280a5accebfeef9ddc98b9a15b` (MIT, licence file in each folder), on 2026-11-24 at the owner's request. **Documents only.** No scripts were installed, and nothing from the source was run.

## Our rules win
1. `Canon.md`, `CLAUDE.md`, `13_Production/agent_team.md`, the owner decisions in `13_Production/studio/DECISION_LOG.md` and the agent's own file override these skills.
2. **Versions differ.** They were written for Unity 6000.3 on macOS and Blender 5.2. We use Unity 6000.6.7f1 on Windows and Blender 5.3. Check every API, package version, menu and path before using it.
3. **Agents do not run Unity** (D-06). Ignore the batch, live-editor, bridge and eval steps.
4. **Do not add or upgrade packages** because a skill says so. Cinemachine, Animation Rigging, VFX Graph, the Unity pipeline package and Timeline are owner decisions.
5. **No Scenario account, MCP, `skill_get`, API key, credits or cloud generation.** If a sibling skill is missing, carry on without it.
6. Scripts and modules the skills mention (`ut_*`, `bx_*`, templates) are **not here**. Do not download them. Do not change git config.
7. **Art stays on D-03:** low-poly, authored at budget, `art_direction.md` section 12. New Blender assets start in the model-request queue.
8. Their reported results are theirs. Here, "Tested" still needs our own tests.

## Who uses what
| Agent | Skills |
|---|---|
| animator-rigger | scenario-blender-animation, scenario-blender-rigging, scenario-blender-export, scenario-unity-animation |
| creature-artist | scenario-blender-expert, scenario-blender-rigging, scenario-blender-retopology, scenario-blender-export |
| environment-artist | scenario-blender-expert, scenario-blender-retopology, scenario-blender-export |
| technical-artist | scenario-unity-shaders, scenario-unity-rendering-lighting, scenario-unity-vfx, scenario-blender-export |
| gameplay-engineer | scenario-unity-gameplay, scenario-unity-animation |
| ai-engineer | scenario-unity-gameplay |
| world-builder-engineer | scenario-unity-world-building, scenario-unity-performance |
| ui-engineer | scenario-unity-ui |
| save-platform-engineer | scenario-unity-architecture |
| tools-pipeline-engineer | scenario-unity-architecture, scenario-blender-export |
| audio-designer | scenario-unity-gameplay |
| performance-analyst | scenario-unity-performance |
| technical-director | scenario-unity-expert, scenario-unity-architecture, scenario-unity-performance |
| lead-programmer | scenario-unity-architecture |
| code-reviewer | scenario-unity-architecture, scenario-unity-performance |
| qa-tester | scenario-unity-expert |

## Left out
Maya, ZBrush, Unreal, Godot, Roblox, Unity 2D, mobile and web, Blender sculpting, hair, rendering and texturing (off the D-03 path), and every skill that drives Scenario's paid cloud generation.
