# Audio plan: how AETHWYRD gets a soundtrack and sound design without an audio team

> **Status:** research note and recommendation. Owner: audio-designer (research session, 2026-11-15). **Nothing was downloaded, installed, bought or signed up for.** No asset was added to `Game/`, and `13_Production/third_party_assets.md` is unchanged — per the project rule, a source is registered there with its exact terms *before* any file enters the project.
>
> Canon wins. Canon §1: music mostly instrumental (regional folk + orchestra), anime-rock / J-pop energy for bosses; the System has a voice plus a few short voiced key moments, no narrator. Canon §6: single rock stem (boss-only), music options and score ownership, six audio buses. No locked row is edited here; anything that would change Canon is flagged as needing a Canon §6 proposal.
>
> Companion docs: `12_Systems/audio_and_immersion.md` (what is built), `13_Production/audio_music_cue_sheet.md`, `audio_sfx_event_list.md`, `audio_source_shortlist.md`, `audio_v9_audit.md`, `adaptive_music_and_scene_pacing.md`, `opening_music_and_memories.md`, and `audio_rock_stem_brief.md` (**unmerged**, on `agent/audio-designer/rock-stem-brief`).

## How sources are marked in this document

Precision matters more here than anywhere else in the project: a wrong licence call on shipped audio is expensive *after* release, when the game is already on sale. Three marks, used consistently:

| Mark | Meaning |
|---|---|
| **[read]** | I opened the page or licence text myself on 2026-11-15 and what follows is what it says. URL in §7. |
| **[inherited]** | The claim comes from the audio-designer's licence check of 2026-11-09 (`audio_source_shortlist.md`). **I did not re-read the page.** Their own mark (VERIFIED / SECONDARY / NOT VERIFIED) is carried through, not upgraded. |
| **NOT SOURCEABLE** | I could not source it. Written as a gap, not filled from memory. Every such gap is wired into the recommendation it affects, so it blocks rather than decorates. |

An **[inherited] VERIFIED** is not the same as **[read]**. Licence pages change, and a six-day-old read of a terms page is evidence about 2026-11-09, not about the day we download. Every row that ends in a download gets a fresh read at download time by whoever downloads it.

---

## Part 0 — The short version

1. **Implementation: use Unity's built-in audio with an Audio Mixer. Do not adopt FMOD or Wwise.** Not because of cost (both are free at our scale) but because the adaptive-score logic that middleware sells us *is already built, data-driven and unit-tested* in `Code/Ascend.Core/AdaptiveMusic.cs`, and the one hard technical requirement it has to meet — layer entry quantised to a bar line within 1.2 s — is met by `AudioSource.PlayScheduled` on the `AudioSettings.dspTime` timeline, which Unity's own documentation calls the preferred way to stitch clips in a music player. Adopting middleware would duplicate tested logic in an untestable proprietary graph, and FMOD would put a required third-party logo on the startup screen of a premium game, with the waiver not sold at our tier. Full reasoning and the revisit triggers in §1.

2. **Sound sources: a four-tier pipeline**, in the order that gives feel per hour: the engine's own randomisation and synthesis for footsteps, impacts and UI (free, no licence, no account); CC0 and royalty-free libraries for ambience, foley and weather; **procedural synthesis** for the long tail that recording cannot reach; and commissioned composition for the small set of music that actually carries the game's identity. Music is the one category where free libraries do not get us to shippable, and it is the only category I recommend spending money on. Licence detail per source in §2, with what I verified myself clearly separated from what I inherited.

3. **What we already have is far more than the brief assumed, and one of its premises is wrong: sound already plays in the build.** `Game/Assets/_Game/Runtime/Combat/CombatFx.cs` synthesises nine combat sounds procedurally at startup and plays them, with a PlayMode test asserting that a hit makes a noise. What does not exist is an Audio Mixer, the six Canon buses, any audio file, or any connection between the built music machine and Unity. Three of the four `agent/audio-designer/*` branches are already merged into `main`; one is not. Detail in §3.

4. **The volume implied by 49 regions, 680 species, 14 companions and 65 unique bosses is roughly 1,050–1,250 music files and 2,600–3,400 sound files** if built naively, and about **220 music files and 600 sound files** if built the way the existing design docs already propose — shared stems re-voiced per region, and sounds keyed to the 25 rigs and 5 size bands rather than to 680 species. The design work to make that reduction has already been done and is sound. Numbers and the derivation in §4.

5. **First ten things to do** are in §6, ordered by feel-per-hour, with the three that need the user to spend money or make an account marked clearly. The first four cost nothing, need no account, and would move audio from "a weighted zero" to "a game with a mix".

---

## Part 1 — The implementation decision

### 1.1 What the choice actually is

The question is usually posed as "built-in versus middleware", but for this project it is narrower than that, because of something specific: **the adaptive-music logic is already written, and it is not written in Unity.**

`Code/Ascend.Core/AdaptiveMusic.cs` (21 KB) holds a `MusicMachine` that takes a `MusicInput` each tick and returns a `MusicFrame`: the current state, per-layer gains, stingers, an optional transition with its crossfade length, the region motif event, the companion theme event and the day-part variant. It implements ten states with priorities, enter delays, minimum holds, exit delays, retreat handling, victory resolution, advantage and danger overlays with hysteresis, and the two Canon-mandated player options. It has no clock and no randomness, so the same inputs always produce the same score, and it is covered by `AdaptiveMusicTests` in `Code/Ascend.Core.Tests` — which `npm run build` runs.

That changes the comparison. FMOD Studio and Wwise are two things sold together: **an authoring tool for sound designers**, and **a runtime that executes the logic authored in it**. We have no sound designer, and we already have the logic in tested C#. So the real question is:

> Does Unity's built-in audio system have a *capability gap* that stops it executing the `MusicFrame` our machine already produces, large enough to justify adopting a middleware runtime, re-authoring the logic in a proprietary graph, and accepting that middleware's terms?

### 1.2 The one capability that decides it

Across the existing design docs there is exactly one hard, numbered technical requirement that a naive implementation would fail. From `audio_rock_stem_brief.md` §3 and §8:

> Enter and exit only on bar lines (the machine adds layers at a phase change; the music system must quantise to the next bar, max 1.2 s)

and, listed as a gap:

> Layers are not quantised to bars in the machine (it reports gains and a crossfade length) → gameplay-engineer's `MusicDirector`: schedule layer changes on the next bar (Unity-side, not testable in Core)

This is the requirement that would justify middleware, because bar-accurate layer entry on synchronised looping stems is exactly what FMOD's and Wwise's music systems are built to do. If Unity's built-in system cannot do it, the case for FMOD is strong.

It can. **[read]** `AudioSource.PlayScheduled(double time)` plays a clip "at a specific time on the absolute time-line that `AudioSettings.dspTime` reads from". The documentation states plainly that this is **"the preferred way to stitch AudioClips in music players"**, because it is independent of frame rate and gives the audio system time to prepare playback without CPU spikes. The page's own worked example is a music stitcher that assumes **16-bar segments at 140 BPM**, alternates two AudioSources so loading one does not disturb the other, schedules each clip about a second ahead, and whose comment describes preloading and **sample-accurately stitching** clips. `AudioSource.SetScheduledEndTime` exists to end a clip at a chosen DSP time, and the related example is described as playing two clips "without pops or clicks between the clips".

The rock stem brief asks for bar-line entry within 1.2 s. The DSP clock is a sample-accurate absolute timeline, bar length is `60 / BPM × beatsPerBar` seconds, and every stem in a region shares one tempo and key by design (`audio_music_cue_sheet.md` §1, "Phrase grid"). Scheduling a layer at the next bar boundary is arithmetic on `AudioSettings.dspTime` plus one `PlayScheduled` call. The capability gap that would justify middleware is not there.

This is the load-bearing finding, so note its limit honestly: I verified the API's contract and intended use from Unity's documentation, including that its canonical example is a bar-aligned music stitcher. **I did not build and measure a layered-stem prototype in this project.** The claim is "the documented mechanism exists and is the documented way to do exactly this", not "I measured it holding sync for twenty minutes on a GTX 1650". To-do 5 in §6 is that measurement, and it is the thing that would falsify this verdict if it failed. NOT ASSESSED, not a pass.

### 1.3 Cost for a commercial release at our scale

Both middleware options are **free** for a project of this size. Cost is not the reason to choose, so it must not be presented as one.

**FMOD [read 2026-11-15, fmod.com/licensing].** Pricing is per game, in USD, by development budget:

| Level | Indie | Basic | Premium |
|---|---|---|---|
| Development budget | Under $600k | $600k – $1.8M | Over $1.8M |
| Fee (per game) | Free or $2,000 (see note) | $6,000 | $18,000 |
| Distribution rights | Lifetime | Lifetime | Lifetime |
| FMOD features / platforms | All | All | All |
| **FMOD logo** | **Required** | **Required** | **Required** |
| Logo waiver | **No** | $6,000 | $12,000 |
| Email support | No | 1 year | 2 years |

The page's own note: *"Free Indie License available for developers with less than $200k revenue per year, on a small (under $600k) development budget."* A commercial project must first be registered in an FMOD profile; a project qualifying for the Free Indie License is covered by the FMOD EULA.

So at our scale FMOD costs **$0**. The price is paid in branding, not money. **[read 2026-11-15, fmod.com/attribution]**: projects using FMOD Studio "must include an in-app credit line and the FMOD logo". The credit line must contain the words "FMOD Studio" and "Firelight Technologies Pty Ltd". And:

> The FMOD logo is required to be displayed **on-screen during application startup, before any user interaction.** The logo can exist with other logos, must be with a reasonable/readable size and duration.

Read the two pages together and the consequence is specific: **at the Indie level the logo requirement cannot be waived at all** — the waiver is listed as "No" for Indie and priced only at Basic ($6,000) and Premium ($12,000). A premium single-player Steam game would carry a third-party audio-middleware logo on its startup screen, before the player touches anything, permanently, with no purchasable way out at our tier. For a project whose whole identity is being built by one person, that is a real cost even though it is not a monetary one.

**Wwise [read 2026-11-15, audiokinetic.com/en/wwise/pricing/].** Note the page said *"This page is currently displaying pricing for Asia"* — Audiokinetic's prices are region-selected, so the figures below are the Asia chart and **the figures for the user's own region are NOT SOURCEABLE from what I read.** Prices are in US currency and exclude taxes.

| Plan | Indie | Pro | Premium | Platinum |
|---|---|---|---|---|
| Price | **Free** | Starting at $8,000 | Starting at $27,000 | Starting at $52,000 |
| Production budget | **Less than $250K** | $250K – $2M | Over $2M | Over $2M |
| Sound files / media assets | **Unlimited** | Unlimited | Unlimited | Unlimited |
| All engine features | Yes | Yes | Yes | Yes |
| Royalty free | **0%** | Optional | 0% | 0% |
| Premium plug-ins | No | Optional | Optional | Included |

Wwise Indie is free under a $250K production budget, with **unlimited** media assets and 0% royalty. (Worth stating because the often-repeated figure is a 200- or 500-asset cap on the free tier; the page I read today says unlimited, which is why I read it instead of trusting recall.) No startup logo requirement appears on the pricing page — **whether Wwise requires a splash logo or credit is NOT SOURCEABLE from the pricing page alone; I did not read Audiokinetic's licence agreement or trademark terms.** Wwise also requires registering the project.

**Built-in Unity audio.** Included in the Unity licence the project already uses. No per-title fee, no registration, no logo, no revenue threshold, no third-party EULA. `com.unity.modules.audio` is already in `Game/Packages/manifest.json`.

**The budget cliff, which is the part that matters for a commercial release.** Neither free tier is unconditional. FMOD's Indie level is pinned to an under-$600k development budget and under-$200k annual revenue; Wwise Indie to an under-$250K production budget. A one-person project is far below both today. But "development budget" on a multi-year project counts what is spent on it, and the moment this project commissions composers, buys asset packs, or pays contractors — which §2 recommends doing for music — the budget line starts moving, and Wwise's $250K threshold is the nearer one. Exceeding it converts a free dependency into an $8,000 one (Wwise Pro, Asia chart) or a $2,000–$6,000 one (FMOD), *on a dependency that by then is woven through the project*. Built-in audio has no threshold to cross and so no cliff. For a project that intends to be commercial and does not know its final budget, that asymmetry is worth more than any feature either tool offers.

### 1.4 What adopting middleware would demand of the build, and lock us into

- **A registered project and an account.** Both FMOD and Wwise require the project to be registered with the vendor before commercial use. Claude never creates accounts — so this step is the user's, and it cannot be delegated. That alone makes middleware a decision the user must make, not one a research session can land.
- **A native plugin per platform** shipped inside the build, plus a vendor SDK upgrade cycle that is independent of Unity's. Unity 6000.6.7f1 is already a specific pin; adding a second native dependency with its own compatibility matrix adds a failure mode to a build pipeline currently driven by one batch-mode command.
- **A bank-building step.** Middleware audio lives in vendor banks built by the vendor's authoring tool, not in Unity assets. That inserts a non-Unity, GUI-driven build step into a pipeline whose checks are presently `npm run build` and Unity batch mode. The authored content is not reviewable in a git diff and is not testable by our existing test command — whereas `music_states.json` is both.
- **Duplicated, unverifiable logic.** This is the real lock-in. The state machine, priorities, hold times, overlays and player options would either be re-authored inside the middleware's graph (losing the Core tests that currently enforce Canon — the validator and `MusicRules.Validate` are what keep the rock stem boss-only) or kept in Core with the middleware reduced to a sample player (paying middleware's whole integration cost for a feature set we would not use). The first option moves Canon enforcement out of a tested data file and into a binary authoring project. That is the outcome to avoid.
- **A one-way door in practice.** Migrating off middleware later means re-authoring every event. Migrating *to* it later, from a clean mixer-based implementation driven by our own `MusicFrame`, is comparatively cheap, because the thing being replaced is a thin director layer.

### 1.5 What we give up

Stated plainly, because it is the honest case for the other side:

- **Authoring tools.** FMOD Studio and Wwise are good places for a *sound designer* to work: live mixing against a running game, parameter automation curves, elaborate randomisation and container logic, profiling of voices and memory. We have no sound designer, and the person who would use that UI is the same person building everything else.
- **Mature music systems.** Transition regions, stingers synced to markers, tempo-aware quantisation as a checkbox rather than as DSP arithmetic. We would implement the slice we need by hand.
- **Better profiling of audio specifically.** Unity has an Audio Profiler module **[read]**, but middleware's is more detailed.
- **Spatialisation and propagation.** Both integrate Steam Audio. So does Unity — see §1.6.

The asymmetry is the deciding factor: middleware's value is concentrated in an authoring UI for a role this project does not have, while its costs land on a build pipeline and a tested rules layer that this project does have.

### 1.6 Verdict

**Use Unity's built-in audio system with an Audio Mixer asset, driven by a thin `MusicDirector` that consumes the `MusicFrame` the Core machine already produces, and schedules layer changes with `PlayScheduled` on the DSP clock. Do not adopt FMOD or Wwise now.**

Because: the adaptive logic middleware sells is already built, data-driven and covered by the test command; the single hard requirement (bar-quantised layer entry) is met by a documented built-in API whose canonical example is exactly this use case; both middleware options cost $0 today but attach a budget cliff to a project with an unknown final budget; FMOD additionally requires an unwaivable startup logo at our tier; and both require an account, which is the user's decision and not ours to make. Middleware would duplicate tested logic in an untestable authoring project and move Canon enforcement out of a validated data file.

**Revisit this if any of the following becomes true** — these are the conditions under which the verdict is wrong, and they should be checked rather than assumed:

1. A prototype shows built-in Unity cannot hold bar sync across layered looping stems at acceptable cost on the target machine (to-do 5 in §6). This is the technical falsifier.
2. A dedicated sound designer joins the project, or audio work is contracted out at a scale where the contractor's own tooling matters. Then the authoring UI stops being dead weight.
3. Console certification becomes a goal. Platform-specific audio compliance is where middleware earns its fee, and **NOT SOURCEABLE** — I did not research console audio certification requirements.
4. Occlusion and propagation become gameplay-critical rather than ambience (stealth built around sound, say).

**On Steam Audio.** `12_Systems/audio_and_immersion.md` §3 lists real sound propagation and occlusion as "not built (an engine job)". Steam Audio is the free option for that and it integrates with Unity directly, so it does not require middleware: HRTF binaural rendering, occlusion and reflections off existing scene geometry, real-time and baked propagation, Ambisonics, and "hundreds of low-latency sources" **[read, valvesoftware.github.io/steam-audio]**. Its licence is **Apache-2.0** **[read 2026-11-15, GitHub API `/repos/ValveSoftware/steam-audio/license`, SPDX `Apache-2.0`, file `LICENSE.md`]** — permissive, commercial use allowed, no fee, attribution per the licence's notice terms. **Which Unity versions Steam Audio supports is NOT SOURCEABLE from the page I read** (it lists Unity as an integration without naming versions), so compatibility with 6000.6.7f1 must be checked against its own release notes before anyone installs it — and installing it is a user decision, not ours. It is deliberately *not* in the first ten things to do: occlusion is a refinement, and a game with no mixer does not need propagation yet.

### 1.7 What the engine already gives us that we are not using

The cheapest win is the one already in the box, and in this project the box is fuller than the docs assume — partly because Unity 6 added audio features after the Wave D design work was written. All of the following are verified against the **6000.6** manual, which is our exact editor version, rather than a neighbouring version.

| Already available, unused | What it replaces | Source |
|---|---|---|
| **Audio Mixer asset with a group hierarchy** — groups accept any number of inputs, mix, and output one signal; sits between source and listener | The six Canon buses (master, music, effects, ambience, dialogue, companion callouts) exist today only as numbers in `accessibility.json`. There is no mixer asset in the project at all | **[read]** mixer overview |
| **Exposed Parameters** — "You can expose any parameter within an Audio Mixer to a script through a string name" | Wiring the six `AccessibilitySettings` volumes to the actual mix, via `AudioMixer.SetFloat`. Today the settings model exists and controls nothing | **[read]** mixer overview |
| **Snapshots** — capture volume, pitch, send level, wet mix level and effect parameters for every group, and "transition between them at runtime" | `audio_sfx_event_list.md` §4.3 asks that opening the Status Window low-pass ambience above 6 kHz and drop it 6 dB. That is a snapshot transition, not code. Also indoor/cave moods, and the "feeling of being in a cave" the docs describe | **[read]** mixer overview |
| **Ducking settings on every group, plus Send/Receive** — "Pitch and Ducking settings: Appear at the top of every group"; ducking described as "automatically lowering the volume of one category when another plays" | The Canon §6 requirement that the dialogue bus ducks music 4 dB while the System Voice speaks (cue sheet: attack 150 ms, release 600 ms). A mixer configuration, not gameplay code | **[read]** mixer overview |
| **Audio Random Container** (Unity 6 feature) — `Playback Mode: Shuffle` "remove audio clips from the pool after they've played. This option avoids repetition until all audio clips have played"; `Avoid Repeating Last` "define how many items can play before an object plays again"; `Volume → Randomization` and `Pitch → Randomization` each with min/max | **This is the single biggest free win.** `audio_sfx_event_list.md` §1 specifies: every event ≥4 variants (footsteps 6), no immediate repeat, ±2 semitone random pitch, ±1.5 dB random gain. The ARC implements that specification as an asset with **no code** — one container per surface per gait, drop in the clips, set the ranges | **[read]** ARC reference, 6000.6 |
| **Scriptable Audio Pipeline** (Unity 6) — extends the audio engine "at specific integration points using Burst-compatible HPC#", with *generators* and *root outputs* | `CombatFx.cs` already synthesises sound by filling float arrays on the main thread and baking them into `AudioClip`s. A Burst generator is where that work belongs, and it is the mechanism for the procedural-synthesis tier in §2. Caveat from the page: **not supported on the Web Platform** — irrelevant for an offline desktop Steam game | **[read]** scriptable audio pipeline, 6000.6 |
| **SFX Reverb effect per group, applied via the effect stack** | The seven data-defined reverb zones in `environment_audio.json` (`open_air`, `forest_canopy`, `town_street`, `wood_room`, `stone_hall`, `cave`, `ruin_interior`) each name a preset event with a blend time. Mixer groups with reverb plus snapshot transitions cover it | **[read]** mixer overview / inspector |
| **Audio Profiler module** | Finding out what is actually costing voices and memory, before optimising by guesswork | **[read]** audio section index |

### 1.8 Two defects this exposes in what is already shipped

Both follow from reading the existing code against the documentation above, and both are cheap to fix. They are the reason to-do 1 in §6 is a mixer rather than a sound.

**1. The nine combat sounds bypass every bus and every volume setting.** `CombatFx.Play` plays through `AudioSource.PlayClipAtPoint(clip, at, volume)`. **[read]** That method "creates an audio source but automatically disposes of it once the clip has finished playing", and its declaration accepts **only** a clip, a world position and a volume — there is no way to set an output mixer group or any other AudioSource property on it. **[read]** And per the mixer overview, "Without an Audio Mixer, the signal that each Audio Source produces ... routes directly to the Audio Listener". So every hit, parry, block, dodge, telegraph, level-up and firestorm sound in the game today routes straight to the listener, outside any mix. When the six Canon buses are built, these sounds will not be on them, and the effects-volume slider will not touch them. The fix is pooled, reusable AudioSources with `outputAudioMixerGroup` set to the Effects group — which also removes a per-sound GameObject allocation in combat.

**2. There are two parallel volume systems.** `FeedbackSettings.SfxVolume` (`HitFeedback.cs`, default `0.8f`) scales combat sound, and `AccessibilitySettings` holds the six Canon bus volumes (master, music, effects 1.0, ambience, dialogue, companion callouts) that `SaveGame.Accessibility` persists. Neither knows about the other. Whichever ships to a settings screen first, the other becomes a hidden multiplier that silently contradicts it. They should be one system, with `FeedbackSettings.SfxVolume` deleted or reduced to a read of the effects bus.

Neither defect is a criticism of the Wave D work, which deliberately stopped at the Unity boundary and said so. They are the seam between a finished rules layer and an unstarted engine layer, and that seam is exactly where the first ten things to do start.
