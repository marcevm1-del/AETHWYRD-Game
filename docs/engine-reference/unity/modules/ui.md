# Unity 6.6 - UI (UI Toolkit and UGUI)

Sources: Unity 6.6 upgrade guide (read 2026-11-07); `Game/Packages/manifest.json`.
Status: **partly verified**. Only what the upgrade guide states is listed.

- Both `com.unity.modules.ui` (UGUI) and `com.unity.modules.uielements` (UI Toolkit) are in the manifest. Which one Ascend's HUD uses is **not checked**; read `12_Systems/hud_and_ui.md` and `Game/Assets/_Game/Runtime` first.
- UI Toolkit, removed in 6.6: legacy `UxmlFactory`/`UxmlTraits` (use `UxmlElement`/`UxmlAttribute`); `DefaultEventSystem.LegacyInputProcessor`; `UIToolkitInputConfiguration.SetRuntimeInputBackend` (compile error, no replacement).
- Rendering Debugger custom widgets now build their UI with UI Toolkit (`DebugUI.Widget.Create()` returns a `VisualElement`).
- Input System is `com.unity.inputsystem` 1.20.1; the 6.6 guide lists no input changes.

**Not verified:** UI Toolkit runtime features, UGUI changes, screen-space/world-space behaviour in 6.6.
