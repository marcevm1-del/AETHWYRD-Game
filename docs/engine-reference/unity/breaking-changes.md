# Unity 6.6 (6000.6) - Breaking Changes (from 6.5)

Source: Unity 6.6 upgrade guide, https://docs.unity.com/en-us/engine/current/manual/upgrade-guides/upgrade-guide-unity66
(read 2026-11-07). Changes from older versions (6.0 - 6.5) are NOT covered here.
"Affects Ascend" is my reading of `Game/Packages/manifest.json`, not a code audit.

| Area | Change | Affects Ascend? |
|---|---|---|
| Packages | **Cinemachine is now a core package.** 2.x projects auto-upgrade to 3.x (different API and data format). | Yes: Cinemachine is in the manifest. Check which API the camera code uses. |
| Packages | `com.unity.test-framework.performance` is now core. | Only if used. |
| Packages | `com.unity.render-pipelines.core` no longer depends on `com.unity.modules.terrain`. Add the Terrain module explicitly if URP-only projects use Terrain. | Terrain module is already in the manifest. |
| Editor | YAML word wrapping disabled; "Reduce Version Control Noise" removed. `serializeInlineMappingsOnOneLine` setter is a no-op. Expect large unrelated YAML diffs; `AssetDatabase.ForceReserializeAssets` once for everyone. | Yes: this repo is in git with Unity text assets. |
| Graphics | **Dynamic batching removed** (obsolete). | Check any code or setting relying on it. |
| Graphics | Rendering Debugger legacy state management removed (`DebugState`, `DebugState<T>`, `DebugStateBool/Int/Float/Color/Vector`, legacy `DebugUIDrawer`, `DebugStateAttribute`, `LegacyStyles`) - now a compile error. | Only if custom debug UI uses them. |
| Graphics | Surface shader code generation uses the caching preprocessor. | Only if surface shaders are used. |
| Graphics | **Progressive CPU Lightmapper deprecated.** Use Unity Compute Light Baker or Progressive GPU; re-check bake results. | If baked lighting is used. |
| Graphics | Render pipeline debug overlays, Render Graph Viewer, Volume panel and debug-display shader variants are gated by `UNITY_ENABLE_CHECKS`; release builds no longer ship them. | Release builds only. |
| Scripting | `CoreBuildData.developmentBuild` obsolete, always `false`; use `CoreBuildData.useDiagnosticChecks`. | Only in custom render features. |
| Scripting | **`UNITY_64` and `DEVELOPMENT_BUILD` deprecated** (warnings UAC0008/UAC0009, removed in 6.8 as errors). | Yes if any `#if` uses them. |
| Scripting | `BuildOptions.ForceEnableAssertions` obsolete; use `PlayerSettings.SetManagedCodeVariant(..., ManagedCodeVariant.Checked)`. | Check `Ascend.EditorTools.BuildPlayer`. |
| Scripting | New: `Dictionary<TKey,TValue>` fields serialize natively (not a removal). Migrate custom wrappers by adding the new field, copying data, then deleting the old one. | Optional. |
| UI Toolkit | `DefaultEventSystem.LegacyInputProcessor` removed; `UIToolkitInputConfiguration.SetRuntimeInputBackend` now a compile error. | Only if UI Toolkit input was customised. |
| UI Toolkit | Legacy UXML `UxmlFactory`/`UxmlTraits` removed; use `UxmlElement`/`UxmlAttribute`. | Only for custom UI Toolkit controls. |
| Android | Legacy and Round icons removed (Adaptive only); `-androidChainedSignalHandlerBehavior legacy` removed; minimum OpenGL ES raised 3.0 -> 3.1. | No: target is PC/Steam. |
| Physics | No API changes listed. Integrity checks compile into Debug/Checked variants only. | No action. |
| Input | No entries in this guide. | No action. |

## Not covered by this guide

URP 17.6 release notes, Input System 1.20, Cinemachine 3.x behaviour,
Shader Graph and VFX Graph. The search for a "URP 17.6 what's new" page found
nothing usable; check the package `CHANGELOG.md` inside the Unity package cache.
