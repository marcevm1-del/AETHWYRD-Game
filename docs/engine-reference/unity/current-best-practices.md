# Unity - Best Practices for Project Ascend

Deliberately short. Everything here comes from the project's own `CLAUDE.md`,
`project.yaml`, manifest or the 6.6 upgrade guide, not from memory of Unity docs.
Add to it only with a source.

## Project rules
- **Gameplay values are data-driven.** `Data/` is canonical for numbers; `Canon.md` wins over every doc.
- **Engine-agnostic rules live in `Code/Ascend.Core`** (tests in `Code/Ascend.Core.Tests`, run with `node Tools/run_tests.js`). Unity-specific code lives in `Game/Assets/_Game/Runtime`.
- **Check before reporting done:** `npm run build` (data + rules tests), then Unity PlayMode tests when the change touches the game (`CLAUDE.md` Commands).
- **Player-observable changes need a screenshot:** `Game/Builds/Ring0/ProjectAscend.exe ... -ascendShot <png>`.
- **Never touch the player's save** at `%USERPROFILE%/AppData/LocalLow/DefaultCompany/Game/slot0.json`.
- **Target:** PC/Steam, 60 fps (`project.yaml` `performance`); the technical-artist file budgets for a GTX 1650.

## From the 6.6 upgrade guide
- Do not add new `#if UNITY_64` or `#if DEVELOPMENT_BUILD`; use the replacements in `deprecated-apis.md`.
- Use `UxmlElement`/`UxmlAttribute` for any new UI Toolkit control.
- Plan one team-wide `AssetDatabase.ForceReserializeAssets` pass to avoid YAML diff noise.
- Don't rely on dynamic batching or the Progressive CPU Lightmapper.

## Open questions (fill in with a source)
- Which Cinemachine API the camera code uses (2.x vs 3.x).
- Whether baked lighting or surface shaders are used.
- Shader Graph / VFX Graph conventions for the cel-shading pipeline.
