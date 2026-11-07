# Unity - Deprecated / Removed APIs (6.6)

Source: Unity 6.6 upgrade guide (read 2026-11-07). Only APIs named there.

| Do not use | Use instead | Status in 6.6 |
|---|---|---|
| `UNITY_64` define | `IntPtr.Size == 8` / `== 4` at runtime | Warning UAC0008, error in 6.8 |
| `DEVELOPMENT_BUILD` define | `UNITY_ENABLE_CHECKS` (safety checks), `UNITY_INCLUDE_INSTRUMENTATION` or `[Conditional("UNITY_INCLUDE_INSTRUMENTATION")]` (profiling/logging), or `Debug.isDebugBuild` | Warning UAC0009, error in 6.8 |
| `BuildOptions.ForceEnableAssertions` | `PlayerSettings.SetManagedCodeVariant(namedBuildTarget, ManagedCodeVariant.Checked)` | Obsolete |
| `CoreBuildData.developmentBuild` | `CoreBuildData.useDiagnosticChecks` | Obsolete, always `false` |
| `DebugState`, `DebugState<T>`, `DebugStateBool/Int/Float/Color/Vector`, legacy `DebugUIDrawer`, `DebugStateAttribute`, `LegacyStyles` | `ISerializedDebugDisplaySettings` + `DebugDisplaySerializer`; override `Create()` returning a `VisualElement` in `DebugUI.Widget` subclasses | Removed (compile error) |
| `UIToolkitInputConfiguration.SetRuntimeInputBackend`, `DefaultEventSystem.LegacyInputProcessor` | Remove the calls; no replacement needed | Removed (compile error) |
| `UxmlFactory` / `UxmlTraits` | `UxmlElement` / `UxmlAttribute` | Removed |
| Dynamic batching | Other batching methods (see Unity manual "Choose a method for optimizing calls") | Removed |
| Progressive CPU Lightmapper | Unity Compute Light Baker or Progressive GPU Lightmapper | Deprecated |
| `PlayerSettings.openGLRequireES31` | n/a (getter always `true`, setter no-op); Android only | Deprecated |
| `serializeInlineMappingsOnOneLine` setter | n/a (no-op) | Deprecated |

Anything not in this table is not known to be deprecated by this document. It may
still be; check the Unity 6.x upgrade guides for the version you are moving from.
