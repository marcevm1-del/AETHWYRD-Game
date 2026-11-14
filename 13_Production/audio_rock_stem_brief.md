# Arrangement brief: the boss-only rock stem and the instrumental layers (job 4)

> **Status:** text brief for a composer or for placeholder production. No audio exists or is added. Rules it follows: Canon §1 (mostly instrumental; anime-rock / J-pop energy for bosses), Canon §6 "Single rock stem" (boss-only layer; ordinary fights use instrumental layers only), "Music options and score ownership" (no-combat-music and reduced-intensity options; one state owns the score; phases follow gameplay state, never a timestamp). Data it maps onto: `Data/Audio/music_states.json` (13 layer ids, boss `phaseLayers`), `Code/Ascend.Core/AdaptiveMusic.cs`. Companion docs: `audio_music_cue_sheet.md` (regions and states), `audio_source_shortlist.md` (sources). Owner: audio-designer. **Proposals are mine; the user may overrule.**

## 1. Design goals

1. Ordinary fights feel like a **fantasy orchestra with a pulse**. Boss fights feel like an **anime opening**: band energy arrives when the fight becomes personal.
2. The rock stem is an **event**, so it must be absent from every other state, including `elite`, siege waves and Tyrant add-waves, until the boss itself is on the field.
3. One tempo, one key per boss, so layers can be added and removed on bar lines with no pitch or tempo change.
4. The mix always leaves room for the **System Voice** and companion callouts (dialogue bus ducks music 4 dB; keep 1 to 4 kHz uncluttered under the stem, see §6).
5. Boss music must work **without the rock stem** (the no-combat-music option, reduced intensity, or a player who dislikes it) and still feel like a boss.

## 2. Layer inventory (the 13 shipped ids)

Each layer is a stem recorded or rendered to the **same tempo, key and bar grid** as the region's motif. A boss borrows its region's motif, but gets its own tempo and key per boss (listed in the boss row below if set; otherwise the region motif's).

| Layer id | Role | Instrumental or rock | Stem sketch | Used in states |
|---|---|---|---|---|
| `bed` | Harmonic floor | Instrumental | Pad, sustained strings or region's drone instrument | all |
| `motif` | Region melody | Instrumental | Region's lead instrument(s) (cue sheet §4) | explore, town, aftermath, boss phase 1+, cutscene |
| `town_folk` | Settlement colour | Instrumental | Region folk ensemble | town |
| `hearth` | Calm bed | Instrumental | One soft instrument plus fireside tone | rest |
| `dungeon_drone` | Dread | Instrumental | Low drone plus pitched texture | dungeon |
| `pulse` | Heartbeat of tension | Instrumental | Low ostinato (cello, bass drum, hand drum) | uncertainty, combat, elite, boss |
| `percussion` *(intense)* | Rhythm | Instrumental | Region hand drums / taiko / frame drums | combat, elite, boss |
| `strings_drive` *(intense)* | Momentum | Instrumental | Fast spiccato or ostinato strings | elite, boss |
| `bass_weight` *(intense)* | Weight | Instrumental in combat-class overlays; in boss phase 2+ voiced as **band bass** | Low strings, brass, sub; in boss: electric bass + low synth | danger overlay, boss phase 2+ |
| `advantage_perc` *(intense)* | Reward for a good window | Instrumental | Bright triangle, tambourine or hand-percussion ostinato | advantage overlay |
| `rock_lead` *(intense)* | **The rock stem** | **Rock** | See §3 | **boss phase 2+ only** |
| `resolve` | Outcome | Instrumental | Home-key resolution phrase | aftermath |
| `companion_theme` | Companion identity | Instrumental | Cue sheet §5 | explore, town, rest |

## 3. The rock stem (`rock_lead`)

**What it is.** A single stem, a bar-aligned, loopable (8 or 16 bar) take of the band elements that the orchestra does not provide: **drum kit (live-feeling, tight, with a snare backbeat), distorted and clean guitars, electric bass, and a hook line (guitar, synth lead or violin-guitar unison)**. The orchestral boss layers (`strings_drive`, `percussion`, `pulse`) keep playing under it; the stem adds the band, it does not replace them.

**Genre direction.** Anime-rock / J-pop energy: driving eighth-note rhythm guitars, a memorable **topline hook** (as an instrumental lead, mirroring the vocal hook), key change allowed only in the last phase, a chorus-like lift when the phase 3 set arrives. Ideas are generic genre traits; **no melody, riff, chord progression or arrangement is taken from any existing anime or game track** (project rule: ideas only).

**Vocals.** The default stem is **instrumental rock**. A vocal insert-song version (anime-style chorus) is allowed **only on a boss's final phase** and only for high-value bosses (story generals, Elder Dragons, Calamities, the Act finale bosses). Reasons: Canon says the rock energy is a boss event; vocals multiply composition, licensing and localisation cost, and they mask the System Voice. Open decision: whether vocal versions exist at all (they need a commissioned vocalist; see §7).

**Specification.**

| Property | Target (proposal) |
|---|---|
| Tempo | 128 to 168 BPM per boss; **one tempo for the whole fight**; strings and percussion share it |
| Key | The boss's key; a **whole-tone or minor-third up shift is allowed once, at the phase 3 entry**, prepared by a bar-long riser (the strings carry the pivot) |
| Length | 16-bar loop, plus a 2-bar entry fill and a 2-bar tail |
| Format | Stereo stem, 48 kHz, 24-bit master, delivered as 4 stems if the composer can: drums, bass, guitars, lead (the runtime can mix lead separately for reduced intensity) |
| Loudness | Boss short-term -14 LUFS with the stem at full (music bus, before the player slider); the stem alone peaks at -16 LUFS short-term; true peak -1 dBTP |
| Frequency discipline | Keep the vocal-less lead above 1.5 kHz and guitars scooped 1 to 3 kHz in the middle so the System Voice remains intelligible |
| Entry/exit | Enter and exit only on bar lines (the machine adds layers at a phase change; the music system must quantise to the next bar, max 1.2 s) |
| Silence | If the music option **No combat music** is on, the whole boss state is replaced by the place score (already enforced); if **Reduced intensity** is on, `rock_lead` is dropped like every `intense` layer |

## 4. How the layers come in during a boss fight (maps to `phaseLayers`)

The shipped data gives the boss state a base set (`bed` 0.6, `pulse` 1.0, `percussion` 1.0, `strings_drive` 1.0) and three phase sets. Phases follow **gameplay state** (HP thresholds in `boss_phases.json`, not a timestamp), and a phase increase fires `mus_stinger_boss_phase`.

| Boss phase | What the player hears | Layers (data) | Arrangement note |
|---|---|---|---|
| Intro (`mus_stinger_boss_intro`) | Title-card hit: the boss's motif in unison plus a drum break; control returns at once | base set | 1 s hit, no pause in control (Canon: control returns quickly) |
| Phase 1 | Orchestral boss theme: region motif over driving strings and percussion; **no band** | base + `motif` 0.8 | The "orchestra only" version of the theme; must be a complete, satisfying boss track on its own |
| Phase 2 | Band enters: drums, bass and a rhythm guitar join; hook appears in the lead | + `bass_weight` 0.8, `rock_lead` 0.9 | Enter on a bar line with a 2-bar fill; the first rock moment is the lift the player remembers |
| Phase 3 | Full band, hook at full, chorus-like lift; optional key shift | `rock_lead` 1.0, `bass_weight` 1.0 | Climax; if a vocal insert exists, it starts here |
| Phase 4 (bosses with four phases, `bosses_and_calamities.md` §1) | **Not in data**: the machine keeps the last set past the list | (same as phase 3) | Proposal: add a fourth set ("breakdown": drop to drums plus lead for 4 bars then full return) or leave at phase 3; needs a data row, see §8 |
| Boss defeat | `boss` resolves to `aftermath` (`mus_stinger_victory`, crossfade 2 s); the rock stem **stops on a bar line** and the orchestra resolves in the home key | `resolve` | The band ends first, the orchestra holds the last chord |

**Mercy / Talk and spared bosses** (about 30% of bosses can be negotiated, recruited or spared): when a fight is paused for dialogue, `cutscene` owns the score (priority 70) and the band layers drop to nothing; the fight resumes at the same phase set on a bar line. A spared boss gets the `aftermath` resolution without the victory stinger (proposal; data row needed).

## 5. Which fights get the rock stem (and which never do)

| Fight | State | Rock stem? |
|---|---|---|
| Ordinary monster, pack, hunt | `combat` | **Never** |
| Elite or Named monster | `elite` | **Never** (strings drive and percussion only) |
| Siege waves and Tyrant add-waves | `combat` / `elite` | **Never** until the Tyrant itself enters, then `boss` |
| Dungeon bosses, floor guardians, Tyrants, Generals, Elder Dragons, Calamities | `boss` | Yes, from phase 2 |
| Hardcore Death Game presentation fights | per fight class | Same rules; the stem is not a presentation flag |
| Scripted story duels (cutscene-owned) | `cutscene` | Only if the cutscene is authored with it; not by the machine |
| Player Ultimate / Awakening | `combat`, `elite` or `boss` | **No rock stem outside boss**; the opening doc's "Ultimate: vocal insert-song" layer is **superseded** by the single-rock-stem rule (Canon §6) and is kept only as an **in-boss** moment at phase 3 |

## 6. Mix and accessibility rules

- **Stem priority:** `rock_lead` and `bass_weight` are `intense`, so both are cut by Reduced intensity and by No combat music; the bed and hearth are never cut (data).
- **Voice masking:** under a System Voice line the music bus ducks 4 dB; if the stem is on, the lead layer also ducks a further 3 dB (proposal) so the voice stays clear; the companion-callout bus (default 0.8) gets the same.
- **Hearing and sensory comfort:** no sudden loudness jump above the -14 LUFS boss target; the phase stinger is under 1 s and bar-aligned. A **"Boss music: orchestral only"** toggle is proposed (drops `rock_lead` and the band elements of `bass_weight` while keeping the boss state); it is a softer alternative to No combat music for players who like the fight but not the genre.
- **Photosensitivity:** audio has no flash risk; keep the phase fill and the title-card hit in sync with the visual flash cap the settings already apply (reduced flash caps at 0.25), never use a strobe-like 4 to 8 Hz pulse in the stem's rhythm.
- **Teen rating:** lyrics, if any, are warm and heroic; no violent or sexual content; no real-language profanity.

## 7. Sourcing and production path

- **Ring 0 to 1 (placeholder):** instrumental orchestral stems from the sources in `audio_source_shortlist.md` (CC0 or verified free; Incompetech needs a credits entry). A **rock** placeholder is the weak spot: free libraries have few usable stylised rock stems, and the listed sources have not been auditioned. Fallback: ship the boss state without the stem until it exists (the machine only reports gains per layer id; whether the Unity director plays silence for a layer with no clip is not yet built or checked).
- **Later:** commission 2 to 3 composers (orchestral and rock), per `opening_music_and_memories.md` §2; commission the stems **after the boss and story sequence is locked** (`adaptive_music_and_scene_pacing.md` production plan §5), starting with 4 reusable rock stems keyed by tempo and mood rather than one per boss: *heroic* (160 BPM, major), *menace* (140 BPM, minor), *tragic* (128 BPM, minor), *cosmic* (150 BPM, modal). Each boss then picks a stem family and its region's motif is layered over it. This keeps the composition cost low for 40 Tyrants plus dungeon bosses.
- **Ownership and licences:** a commissioned stem is work-for-hire with a written assignment; a licensed stem goes in `third_party_assets.md` first. Vocal performers need a written consent and credit.
- **No reuse of other games' or anime music** in any form (not as reference tracks sent to a composer either: describe the mood and give the tempo and key instead).

## 8. Hand-offs and gaps

| Gap | Needs |
|---|---|
| Boss `phaseLayers` ends at phase 3; 4-phase bosses reuse the last set | core-rules-engineer: add an optional fourth set, or accept the reuse |
| No `MusicInput` field for a spared or negotiated boss, nor an `orchestral only` pref in `MusicPrefs` | core-rules-engineer, save-platform-engineer (settings screen) |
| Layers are not quantised to bars in the machine (it reports gains and a crossfade length) | gameplay-engineer's `MusicDirector`: schedule layer changes on the next bar (Unity-side, not testable in Core) |
| Per-boss tempo and key table | audio-designer (a later data note) once bosses are locked |
| Rock-stem placeholder source | job 3 follow-up: audition the shortlist, or accept "no stem" for Ring 0 |
| Canon §6 is not changed; the proposals "Boss music: orchestral only" and "vocal insert only on the final phase" are **mine, not Canon** | The user |

## 9. What was not checked

- No audio produced or auditioned; every tempo, loudness and frequency number is a target.
- The validator (`audio_checks.js`) only validates the JSON; nothing was changed in data or code in this job.
- The existing `Data/Audio/music_states.json` has **three** boss phase sets; this brief's phase 4 row is a proposal needing data.
