# Audio and immersion v9 audit and Wave D design contract

Source: `upgrade v9` (repo root; image links ignored). Canon wins: §1 Product (music mostly instrumental, anime-rock / J-pop energy for bosses; **voice amount TBD by the user**; no narrator, System Voice only), the offline-first and accessibility rows in §6 ("Ring 0 combat/readability contract", "Adaptive music and anime punctuation", "Boss encounter storytelling", "In-game-time continuity"). Scope of this wave: Core rules, data, validator and docs. No Unity code, no scene, no audio files (none exist and none are added), nothing under `Game/`.

## 1. What existed before Wave D

| Area | State on main | Where |
|---|---|---|
| Day/night clock | Done: `GameCalendar` (day parts morning / day / dusk / night, play-seconds clock), `WorldClock` in Unity, `SaveGame.ClockSeconds` | `Code/Ascend.Core/Calendar.cs`, `Game/.../World/WorldClock.cs` |
| Adaptive music | Design only: seven states and combat rules, "first implementation needs a clean event interface" | `13_Production/adaptive_music_and_scene_pacing.md`, `opening_music_and_memories.md` |
| Environmental audio | Nothing. No weather system, no surface-to-sound mapping, no reverb zones | none |
| Accessibility | Design only (`hud_and_ui.md` §14). Telegraph shapes exist in combat data; no settings model, no save field | doc only |
| Photo mode | One design line (`hud_and_ui.md` ~line 150: poses, expressions, filters, frames, hide-everything, shots go to the Memory Reel) | doc only |
| Audio code / folder / assets | None. No `Audio` folder in the runtime, no files in `third_party_assets.md` | none |
| Cinematic director, facial animation, lip-sync | Design docs only | docs |

## 2. v9 section map

Status: **built** (Wave D), **partial**, **deferred** (later wave), **skipped** (reason given).

| v9 section | Status | Decision |
|---|---|---|
| 1 Cinematic camera and scene director | **skipped** | Task brief: out of scope. Needs Unity and a camera rig |
| 2 Dialogue, facial expressions, lip-sync, voice profiles, eye tracking | **skipped** | The amount of voice acting is the user's open decision (Canon §1). Nothing here assumes voiced lines. Subtitles are modelled (they are needed with or without voice) |
| 3 Dynamic music: exploration / combat / boss / tension, transitions, intensity levels, regional identity | **built** | `AdaptiveMusic` state machine, `Data/Audio/music_states.json` |
| 3 Companion-specific themes | **built (event names)** | Only ids in `Data/Companions/companions.json`; validator and Core test enforce it |
| 3 Ancient-civilization soundtracks | **deferred** | Needs a content decision; the region motif event takes any region id so a later region slots in |
| 3 "Music changes with player health, weather, discoveries, story events" | **partial** | Health (danger overlay) and time of day are inputs. Weather is carried by ambience, not the score. Discovery and story stingers are one-shot cue names the game may fire |
| 4 Environmental audio: footsteps, weather, time-of-day ambience, indoor/outdoor | **built (data + rules)** | `EnvironmentAudio`, `Data/Audio/environment_audio.json`. Event names only |
| 4 3D positional sound, sound propagation through caves and buildings | **partial** | Reverb zones as data (preset per space kind). True propagation / occlusion is an engine task, deferred |
| 5 Environmental presentation, volumetric fog, weather rendering | **skipped** | Rendering, not rules |
| 6 Interactive cinematic events | **skipped** | Task brief: out of scope |
| 7 Animation and character performance | **skipped** | Owned by Wave A1 (animation) |
| 8 Photo mode (camera, FOV, DoF, exposure, time-of-day, weather, poses, filters, hide UI) | **built (rules + data)** | `PhotoMode`: hide-UI, pose and filter lists, override that never touches save or clock. Free camera, DoF and screenshot capture are engine work, deferred |
| 9 Audio production tools (importer, validator, missing-audio detection) | **partial** | The validator already checks the four data files and event-name format. A missing-file report waits until audio files exist |
| 10 Accessibility and presentation options | **built (model)** | `AccessibilitySettings` with a save field and safe defaults for old saves |
| 10 Dialogue text speed, camera sensitivity, brightness | **partial** | Text speed is in the model (it is a pure setting). Camera sensitivity and brightness are input / display settings owned by the save-platform layer; deferred |
| Roadmap phases 1, 2, 4, 5, 6 | **skipped** | Same reasons as their sections |

## 3. Canon constraints and how each is enforced

| Constraint | Enforcement |
|---|---|
| Music mostly instrumental; rock energy for bosses | Layer names are instrumental stems; the one rock stem (`rock_lead`) is allowed only in `boss`. Validator + Core test |
| No narrator; System Voice only | No voice, narrator or lip-sync field exists in any new schema. Subtitles carry a speaker name, never a narrator style |
| Voice amount is the user's call | Nothing depends on voice. The mixer buses in the data list dialogue as one bus that stays silent until voice exists |
| One active score owner; no overlapping encounter scores | A single `MusicMachine` holds one current state; a test shows two simultaneous threats still yield one state |
| No-combat-music option and reduced intensity | `MusicPrefs.NoCombatMusic` / `ReducedIntensity`, tested |
| Phase changes follow gameplay state, not a timestamp | Boss phase is an input integer; layers follow it. No time-coded cues |
| Random small enemies never trigger the boss transition | Boss state needs the boss input; threat tier alone caps at `elite`. Tested |
| Retreat returns the score gradually | `retreatExitDelaySeconds` is longer than the normal exit delay. Tested |
| Offline-first / in-game-time continuity | Photo mode overrides live in memory only; `PhotoSession` has no reference to `SaveGame` or the clock and declares `ChangesSaveState` as false. A test snapshots the save and the clock before and after |
| Teen rating | Photo poses are an allow-list in data; the validator rejects any pose whose tags include a blocked tag (`suggestive`, `undress`, `gore`, `weapon_at_camera`). A test checks every shipped pose |
| Accessibility (`hud_and_ui.md` §14) | Three colorblind palettes, subtitle size / background, shake / flash / motion-blur sliders, reduced-flash, text scale, hold-vs-toggle per hold action. Ranges clamp; an old save without the field loads with safe defaults |
| Companion themes only for the roster | `companionThemes` ids must exist in `companions.json`; unknown ids at runtime yield no theme |
| No audio assets, no new third-party packages | None added. `third_party_assets.md` untouched |
| Locked Canon rows | Not edited. Proposals only, in Canon §6 and `12_Systems/audio_and_immersion.md` §9 |

## 4. What Wave D builds

1. This note.
2. `Code/Ascend.Core/AdaptiveMusic.cs` + `Data/Audio/music_states.json` (+ schema `music_states`): states, priorities, hold and delay times, layers per state, boss-phase layers, overlays (advantage, danger), crossfades, stingers, companion themes.
3. `Code/Ascend.Core/EnvironmentAudio.cs` + `Data/Audio/environment_audio.json`: surface-to-footstep events from the existing map terrain kinds, weather and time-of-day ambience layers, reverb zones.
4. `Code/Ascend.Core/Accessibility.cs` + `Data/Audio/accessibility.json`: settings model, defaults, ranges, palettes; `SaveGame.Accessibility` (null in older saves, null-coalesced by `SaveRules.Upgrade`).
5. `Code/Ascend.Core/PhotoMode.cs` + `Data/Audio/photo_mode.json`: photo session rules.
6. `12_Systems/audio_and_immersion.md`, Canon §6 proposals, progress log row.

Tests: `Code/Ascend.Core.Tests/AudioWaveDTests.cs` (and QA additions). Validator rules in `Tools/validate/audio_checks.js`.
