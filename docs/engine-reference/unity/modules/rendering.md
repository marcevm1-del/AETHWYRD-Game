# Unity 6.6 - Rendering (URP)

Sources: Unity 6.6 upgrade guide (read 2026-11-07); `Game/Packages/manifest.json`.
Status: **partly verified**. Only what the upgrade guide states is listed.

- Pipeline: URP, package `com.unity.render-pipelines.universal` 17.6.0.
- Removed/changed in 6.6: dynamic batching removed; Progressive CPU Lightmapper deprecated (use Compute Light Baker or Progressive GPU); surface shader generation uses the caching preprocessor; legacy Rendering Debugger state APIs removed (compile error). Details and replacements: `../breaking-changes.md`, `../deprecated-apis.md`.
- Release builds no longer ship debug-display shader variants or the Render Graph Viewer/Volume panel (gated by `UNITY_ENABLE_CHECKS`).
- `com.unity.render-pipelines.core` no longer pulls in the Terrain module; Ascend's manifest lists it explicitly, so no action.
- Ascend rendering conventions (cel shading, ink outlines, GTX 1650 budget) live in `.claude/agents/technical-artist.md` and `13_Production/`; those win over this file.

**Not verified:** Render Graph behaviour, Shader Graph/VFX Graph changes, URP 17.6 features. Look in the package `CHANGELOG.md` before relying on them.
