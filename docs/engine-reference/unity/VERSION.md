# Unity Engine - Version Reference

| Field | Value |
|-------|-------|
| **Engine Version** | Unity 6000.6.7f1 (Unity 6.6) |
| **Installed at pin time** | 6000.6.7f1 (`Game/ProjectSettings/ProjectVersion.txt`), editor at `E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe` |
| **Render pipeline** | URP (`com.unity.render-pipelines.universal` 17.6.0 in `Game/Packages/manifest.json`) |
| **Language** | C# |
| **Project Pinned** | 2026-11-07 |
| **Last Docs Verified** | 2026-11-07: the Unity 6.6 upgrade guide (6.5 -> 6.6) only. Nothing else here is verified against Unity's docs. |

## Knowledge Gap Warning

Unity 6.6 is newer than the model's reliable knowledge. Do not assume any API,
package version or URP setting from memory. Check this folder first, then
`Game/Packages/manifest.json`, then the project's own code in `Game/Assets/_Game/`.
Say so when a claim is unverified.

## Packages the project actually uses (from `Game/Packages/manifest.json`)

| Package | Version | Note |
|---|---|---|
| `com.unity.render-pipelines.universal` | 17.6.0 | URP. The 6.6 docs also show 7.x URP upgrade pages; the numbering is unexplained, treat as unverified. |
| `com.unity.inputsystem` | 1.20.1 | New Input System. |
| `com.unity.cinemachine` | 6.6.0 | The 6.6 upgrade guide says Cinemachine is now a core package and 2.x projects auto-upgrade to 3.x. This manifest value looks unusual; confirm what the editor resolved. |
| `com.unity.test-framework` | 1.4.6 | Rules/PlayMode tests. |
| `com.unity.nuget.newtonsoft-json` | 3.2.2 | JSON. |
| `com.projectascend.core` | local (`Code/Ascend.Core`) | Engine-agnostic rules. |

**Not installed:** Addressables, Entities/DOTS, Netcode. The Addressables, DOTS
and networking agents have nothing to work on yet (see `plugins/`).

## Files in this folder

- `breaking-changes.md` - what changed 6.5 -> 6.6.
- `deprecated-apis.md` - APIs to stop using, with replacements.
- `current-best-practices.md` - project-grounded rules (small on purpose).
- `modules/` - rendering, UI, physics notes.
- `plugins/` - Addressables and DOTS status.

Ascend's own docs under `13_Production/` win over this folder.
