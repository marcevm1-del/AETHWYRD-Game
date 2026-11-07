# Audio and immersion (Wave D)

> **Status:** rules, data and tests are built in `Code/Ascend.Core`; nothing is wired into Unity yet and **no audio files exist**. Everything below speaks in event names. Source: `upgrade v9`; audit and scope in `13_Production/audio_v9_audit.md`. Canon wins: §1 (music mostly instrumental, anime-rock / J-pop energy for bosses, **amount of voice TBD by the user**, no narrator, System Voice only).

## 1. What is built

| Part | Core | Data | Tests |
|---|---|---|---|
| Adaptive music state machine | `AdaptiveMusic.cs` (`MusicMachine`, `MusicRules`) | `Data/Audio/music_states.json` | `AdaptiveMusicTests` |
| Environmental audio | `EnvironmentAudio.cs` (`EnvironmentAudio`, `EnvironmentRules`) | `Data/Audio/environment_audio.json` | `EnvironmentAudioTests` |
| Accessibility settings | `Accessibility.cs` (`AccessibilitySettings`, `AccessibilityRules`), `SaveGame.Accessibility` | `Data/Audio/accessibility.json` | `AccessibilityTests` |
| Photo mode | `PhotoMode.cs` (`PhotoSession`, `PhotoRules`) | `Data/Audio/photo_mode.json` | `PhotoModeTests` |

Schemas are written by `Tools/validate/audio_schemas.js` (called from `build_schemas.js`); `Tools/validate/audio_checks.js` runs the cross-checks inside `npm run build` (companion ids against the roster, terrain kinds against the map vocabulary, blocked pose tags, rock stem boss-only).

## 2. Adaptive music

One state owns the score at a time. The game fills a `MusicInput` each tick and calls `MusicMachine.Update(dt, input)`; it gets back a `MusicFrame` (state, layer gains, stingers, an optional transition with its crossfade length, the region motif event, the companion theme event, the day-part variant). The machine has no clock and no randomness: the same inputs always give the same score.

**States** (priority in brackets): `explore` (10), `dungeon` (10), `town` (12), `rest` (15), `uncertainty` (20), `aftermath` (25), `combat` (40), `elite` (50), `boss` (60), `cutscene` (70). *Advantage* and *danger* are overlays on combat-class states, not states of their own.

**Inputs:** threat level 0-4, in-combat, boss phase (0 = no boss), place (wilderness / town / interior / rest), region id, day part, cutscene flag, player advantage, player HP fraction, a one-tick combat outcome (victory / retreat), active companion id.

**Rules**
- *Escalation* (an equal or higher priority state is wanted) waits that state's `enterDelaySeconds` (0 for every combat state, so a fight is answered at once; 2 s for `uncertainty`, so a flickering clue never starts the tense layer).
- *Stepping down* needs the current state's `minHoldSeconds` **and** its `exitDelaySeconds` of continuous calm. Combat: hold 8 s, exit 6 s. Boss: hold 15 s, exit 8 s.
- *Retreat* lengthens the exit (combat 12 s, boss 14 s) so the score returns gradually.
- *Victory* resolves a combat-class state straight into `aftermath` (stinger, `resolve` layer), which holds 6 s and then crossfades slowly (4 s) to the world score. A new fight interrupts it.
- *Threat alone never makes a boss.* `boss` needs a boss phase input; threat 3 in combat is `elite`, anything lower is `combat`. Phases follow gameplay state, never a timestamp: phase 1 adds the motif, phase 2 the bass weight and the **rock stem**, phase 3 more of both. Phases past the list keep the last set. A phase increase fires `mus_stinger_boss_phase`.
- *Overlays:* advantage turns on at once and off after 3 s; danger turns on below 30 % HP and off above 45 % (hysteresis). Neither appears outside combat-class states.
- *Options* (`MusicPrefs`, set from the accessibility settings): **No combat music** replaces combat, elite, boss, uncertainty and aftermath by the place score; **Reduced intensity** drops layers marked `intense` and scales the others by 0.6 (the bed and hearth are untouched).
- *Region identity:* any state with the `motif` layer reports `mus_motif_<regionId>`, so a new region needs no code. A region-arrival stinger fires in calm moments only, never on the first tick after a load.
- *Companion themes:* `mus_companion_<name>` for the 14 companions in `Data/Companions/companions.json` (validator and runtime both reject anyone else), only under `explore`, `town` and `rest`, never under combat music.
- *Canon §1:* the `rock_lead` stem is allowed only in the boss state (validator + `MusicRules.Validate`).

Crossfade lengths come from the `crossfades` table (`"from>to"`), default 2.5 s.

## 3. Environmental audio

- **Footsteps:** `ResolveSurface(terrain, context)` maps the 11 map terrain kinds (`MAP_TERRAIN`: plains, forest, swamp, steppe, mountain, volcanic, tundra, desert, jungle, spirit, demon) to 11 surfaces; a context can override it (shallow water beats an interior floor beats a road beats the terrain). Unknown terrain falls back to grass, so a future terrain kind is never silent. Events: `sfx_step_<surface>_<walk|run|sprint>`, `sfx_land_<surface>`; rain and storms add `sfx_step_wet_overlay` on wettable outdoor surfaces. A Core test keeps the terrain list equal to the schema builder's and checks every terrain used by `regions.json`.
- **Ambience:** `Ambience(input)` mixes a biome bed (`amb_bed_<terrain>`), weather layers (clear, overcast, rain, storm, snow, fog) and time-of-day layers (morning, day, dusk, night), then the zone's own layers. Gains under 0.02 are dropped.
- **Reverb zones as data:** `open_air` (default), `forest_canopy`, `town_street`, `wood_room`, `stone_hall`, `cave`, `ruin_interior`. Each names a reverb preset event, whether it is indoor, how much weather, time-of-day and biome bed it lets through, and a blend time. Indoor zones never play the biome bed (validator). Overlapping zones resolve by priority, then by lower id, independent of order.
- **Not built:** real sound propagation and occlusion (an engine job), a weather system (nothing in the game produces weather yet; the photo override and the ambience take a weather id as input).

## 4. Accessibility

`SaveGame.Accessibility` is null in older saves; `SaveRules.Upgrade` fills it with safe defaults and clamps every value, so older or hand-edited saves load. Values come from `hud_and_ui.md` §14.

| Setting | Range / choices | Default |
|---|---|---|
| Colorblind palette | off, protanopia, deuteranopia, tritanopia | off |
| Subtitles | on / off; size small, medium, large, extra large (0.85 / 1.0 / 1.3 / 1.6); background none, shadow, box | on, medium, box |
| Speaker names | always shown (not a setting) | on |
| Dialogue text speed | 0.5 - 3.0 | 1.0 |
| Text scale / HUD scale | 0.8 - 2.0 / 0.75 - 1.5 | 1.0 / 1.0 |
| High-contrast panels, dyslexia-friendly font | toggles | off |
| Screen shake, flash intensity, motion blur | 0 - 1 | 0.6 / 0.6 / 0.3 |
| Reduced flash | toggle; caps the effective flash at 0.25 | off |
| Hold or toggle | per action: sprint, block, aim, charge heavy, companion wheel, second skill palette | hold |
| No combat music, reduced music intensity | toggles | off |
| Volumes | master, music, effects, ambience, dialogue, companion callouts | 1.0 / 0.8 / 1.0 / 0.8 / 1.0 / 0.8 |

Telegraph **shapes** (circle = parry, triangle = unblockable, square = grab) are always on; the palettes only change the colours, and the validator requires the three telegraph colours of every palette to differ. Palette hex values are first-pass and need a colour-vision simulator check in Unity. The dialogue bus stays silent until the game has voice.

Not modelled here (platform layer): full input remapping, one-handed preset, camera sensitivity, brightness, story-difficulty assists, menu narration.

## 5. Photo mode

A `PhotoSession` is a pure overlay. It holds no `SaveGame` and no clock, so it cannot change either; the time-of-day and weather overrides only change what the picture shows (`EffectiveHour`, `EffectiveWeather`), and closing the session restores the live values. A test snapshots the save JSON and the calendar reading before and after a session full of overrides and requires them identical.

- Opens only when not in combat, a cutscene, a siege battle or dialogue.
- Hide-UI toggle plus per-element hiding; free FOV 20-90; hour override snapped to 15 minutes; weather from the environmental audio list; 6 filters (none, anime cel, watercolor, sketch, golden hour, moonlit), 4 frames, 13 poses.
- **Teen rating:** poses are an allow-list in data. A pose carrying a blocked tag (`suggestive`, `undress`, `gore`, `weapon_at_camera`, `kneel_to_camera`, `lying_pose_close`) fails validation and a session refuses to select it. Pair poses need a companion.
- `Capture()` returns a `PhotoShot` record for the Memory Reel. Storing it is a platform-layer job (a screenshot file, not a save-state change). Expressions are deferred with facial animation.
- Not built: the free camera, depth of field and the screenshot itself (Unity work).

## 6. Hand-over to the Unity side (not done in this wave)

1. `gameplay-engineer` / `ui-engineer`: build a runtime `MusicDirector` that fills `MusicInput` from combat, `WorldClock` and region triggers, and maps layer ids to mixer groups once stems exist.
2. `world-builder-engineer`: place reverb zone volumes in scenes; feed terrain kind and surface context to the footstep component.
3. `save-platform-engineer`: persist `SaveGame.Accessibility` (already in the DTO), expose the settings screens, apply `EffectiveFlash`, shake and blur sliders.
4. `ux-designer` / `ui-engineer`: photo mode screen; the camera rig.
5. `audio-designer`: when stems and sound sources are chosen, list them in `13_Production/third_party_assets.md` first; this wave added no assets.

## 7. Open decisions (the user's call)

- **Amount of voice acting** (Canon §1). Nothing in this wave assumes any. The dialogue volume bus and subtitles work either way.
- **Game title** (placeholder Project Ascend). Event names do not contain it.

## 8. Skipped on purpose

Cinematic director, interactive cinematics, facial animation, lip-sync, eye tracking, voice profiles, motion matching, volumetric fog and weather rendering, audio production tooling beyond the validator, ancient-civilization soundtracks. See the audit note for each reason.

## 9. Proposals for Canon §6 (need the user's OK)

Added as rows in Canon §6; none edits a locked row.
1. **Single rock stem:** the anime-rock / J-pop stem is a boss-only layer; ordinary fights use instrumental layers only.
2. **Music options:** a no-combat-music option and a reduced-intensity option are always available, and one state owns the score at a time.
3. **Photo mode contract:** time-of-day and weather overrides are session-only and never change the save or the in-game clock; photo mode is closed in combat, cutscenes, siege battles and dialogue; poses come from a teen-rating allow-list.
4. **Accessibility floor:** telegraph shapes always on, three colorblind palettes, reduced-flash cap of 0.25, speaker names always shown, a hold-or-toggle choice for every hold action, and safe defaults for older saves.
5. **Audio buses:** master, music, effects, ambience, dialogue and companion-callout volumes; the dialogue bus stays silent until the user decides on voice.
