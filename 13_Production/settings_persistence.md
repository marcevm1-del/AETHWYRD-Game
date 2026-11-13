# Settings persistence

Code: `Code/Ascend.Core/GameSettings.cs`. Tests: `Code/Ascend.Core.Tests/GameSettingsTests.cs`.

## Two files, one rule each
| File | Holds | Synced to Steam cloud | Why |
|---|---|---|---|
| `settings.json` | accessibility (text, HUD, colour palette, subtitles, flash/shake/blur, hold-or-toggle), the six audio buses (master, music, effects, ambience, dialogue, callouts), control rebinds, look sensitivity, invert Y, gamepad deadzone | yes | follows the player to any PC or Steam Deck |
| `device.json` | resolution, fullscreen, vsync, quality, frame cap | no | machine-specific; a 4K choice must not follow the player to a laptop |

Both live next to the saves in `Application.persistentDataPath`, are versioned, and are written with `AtomicFile` (temp file, replace, previous copy kept as `.bak`).

## Behaviour
- **Load never throws.** Missing file gives defaults. A damaged main file falls back to `.bak`, then to defaults, with a note the menu can show.
- **Everything clamps.** Sliders, scales, deadzone and device values are pulled into range; unknown enum values and unknown hold actions are dropped. A hand-edited file cannot make the game unplayable.
- **A newer build's file is never overwritten.** `SettingsStore.LoadedFutureFile` blocks `Save`; this session uses defaults.
- **Rebinds:** at most 3 bindings per action, blanks and duplicates removed, actions the build no longer has are dropped (`knownActions`). `FindConflicts` lists bindings shared by two actions so the rebind screen can ask the player which action keeps it.
- **Saves stay compatible.** `SaveGame.Accessibility` is kept as is. The first time `settings.json` does not exist, seed it from the loaded save with `SettingsRules.SeedFrom(save)`. After that `settings.json` wins and the save's copy is only a fallback.

## Needs a Unity run (not done here)
1. A small `SettingsService` in `Game/Assets/_Game/Runtime` that builds the two `SettingsStore`s (Newtonsoft for serialisation, as `PlayerSave` does), loads at boot before the title screen, applies audio buses, accessibility and bindings, and saves when the settings menu closes.
2. Input System rebinding: store `InputBinding.overridePath` strings in `Bindings`; apply with `ApplyBindingOverride` after load.
3. Apply `DeviceSettings` with `Screen.SetResolution`, `QualitySettings`, `Application.targetFrameRate`.
4. Settings screen wiring (ui-engineer, from the ux-designer spec). Until then the Accessibility block keeps working through the save.
5. Test in a sandbox folder, never the player's real folder.
