# Unity Engine - Version Reference

| Field | Value |
|-------|-------|
| **Engine Version** | Unity 6000.6.7f1 (Unity 6) |
| **Installed at pin time** | 6000.6.7f1, `E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe` (from `CLAUDE.md`) |
| **Render pipeline** | URP |
| **Language** | C# |
| **Project Pinned** | 2026-11-07 |
| **Last Docs Verified** | NOT VERIFIED - no Unity 6000.6 API snapshot has been curated yet |

## Knowledge Gap Warning

Unity 6000.6 was released after the model's training data. Do not assume any
API, package version or URP setting from memory. Check the installed package
versions in `Game/Packages/manifest.json` and the project's own code in
`Game/Assets/_Game/` before suggesting engine calls, and say when a claim is
unverified.

## Where the truth lives for this project

- Unity project: `Game/` (code root `Game/Assets/_Game/Runtime`, tests `Game/Assets/_Game/Tests`).
- Engine-agnostic rules: `Code/Ascend.Core` and `Code/Ascend.Core.Tests`.
- Batch commands (scene build, player build, PlayMode tests): see `CLAUDE.md` Commands.
- Ascend's own docs under `13_Production/` win over this file.

## TODO

Curate breaking-change notes for the Unity 6000.x versions the project uses
(`/setup-engine` can fill this via WebSearch).
