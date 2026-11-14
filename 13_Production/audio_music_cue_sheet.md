# Music cue sheet: per region and per music state (job 1)

> **Status:** text spec only. No audio files exist and none are added. Event names match `Data/Audio/music_states.json` and `Code/Ascend.Core/AdaptiveMusic.cs`; palettes come from the region table in `13_Production/opening_music_and_memories.md` §2 and the 21 architecture families in `13_Production/building_system.md`. Owner: audio-designer. **Everything marked "proposal" is mine and the user may overrule it.** Canon §1: mostly instrumental, anime-rock / J-pop only for bosses (single rock stem, boss-only, Canon §6).

## 1. Ground rules

- One state owns the score at a time (Canon §6). A region never adds a state; it only supplies the `motif` layer (`mus_motif_<regionId>`, e.g. `mus_motif_reg_aldmere`) and a palette for the other layers.
- **Home stems, not 49 full scores.** Each region ships: one motif (8 to 16 bars, loops), one `bed` (pad plus soft rhythm, 60 to 90 s loop), and a palette note that the shared layers (`pulse`, `percussion`, `strings_drive`, `town_folk`, `hearth`) are re-voiced in. Combat, elite and aftermath use the region palette through those shared layers, so no region needs a combat track of its own.
- **Phrase grid:** every loop in a region shares one tempo and key with its motif, bar-aligned, so layers can be added at bar lines. Crossfade lengths stay in `music_states.json`.
- **Loudness targets (proposal, measured on the music bus before the player's slider):** explore and town -20 LUFS integrated; rest -24; dungeon -22; uncertainty -21; aftermath -20; combat -16 short-term; elite -15; boss -14 short-term; cutscene -16; stingers peak at -14 LUFS short-term, true peak -1 dBTP. The dialogue bus ducks music by 4 dB while the System Voice speaks (attack 150 ms, release 600 ms).
- **Teen rating, warmth over comedy:** no parody cues; menace comes from harmony and register, not shock.
- **Everything instrumental except the boss rock stem.** Wordless choir is allowed in any state; lyric vocals only in the boss rock stem and the Act openings (see job 4 and `opening_music_and_memories.md`).

## 2. Cue sheet per music state

Priority, hold and delay values are the shipped data; this table adds what the music should be.

| State (priority) | Cue ids | Layers (data) | Feel and arrangement | Loop / tempo rule | Target loudness |
|---|---|---|---|---|---|
| `explore` (10) | `mus_motif_<region>`, bed, day variants | bed 1.0, motif 0.8 | Open, spacious: motif in the region's lead instrument over a slow pad. Day variants below | Bed 60-90 s loop, 70-96 BPM | -20 LUFS |
| `dungeon` (10) | bed + `dungeon_drone` | bed 0.9, drone 0.9 | Sparse. Drone plus one pitched texture of the dungeon's biome (stone bells, dripping glass, wind in pipes). No melody until phase of discovery | Free time, 40-60 BPM pulse implied | -22 |
| `town` (12) | `town_folk` + motif | bed 0.9, town_folk 1.0, motif 0.6 | Folk ensemble of the region at walking pace; warmest cue in the game; hearth and market rhythm | 84-108 BPM, 4/4 or 6/8 | -20 |
| `rest` (15) | `hearth` | bed 0.6, hearth 1.0 | Inn and camp: one soft instrument (lute, piano, kora, koto by region) plus fireside tone. Must not overlap spoken dialogue | Rubato, under 70 BPM | -24 |
| `uncertainty` (20) | `pulse` | bed 1.0, pulse 0.8 | Low heartbeat pulse and one dissonant interval from the region's mode. Never a stinger-style scare | 60-72 BPM | -21 |
| `aftermath` (25) | `resolve` + `mus_stinger_victory` | bed, resolve, motif 0.5 | The fight's phrase resolves to the home key; motif returns in a gentler voice | 4 to 8 bars, then crossfade 4 s to world score | -20 |
| `combat` (40) | pulse + percussion | bed 0.7, pulse 1.0, percussion 0.9 | Region palette re-voiced in rhythm: the lead instrument plays short ostinato figures, hand percussion of the region | Tempo = region tempo x1.5 or x2, same key | -16 |
| `elite` (50) | + `strings_drive`, `mus_stinger_elite_pickup` | adds strings_drive 0.9 | Full ensemble: strings with the region motif as a countermelody. Short pickup stinger, no vocals | Same grid as combat | -15 |
| `boss` (60) | `mus_stinger_boss_intro`, `mus_stinger_boss_phase`, rock stem in phases 2-3 | strings_drive 1.0, phase layers motif / bass_weight + rock_lead | Orchestra-plus-band. Phase 1: region motif and strings. Phase 2: bass weight and the rock stem enter on a bar line. Phase 3: both at full. Details in job 4 | One tempo per boss; no tempo changes mid-fight | -14 |
| `cutscene` (70) | bed + motif 1.0 | bed 1.0, motif 1.0 | Scored scene in the region motif; hard-cuts allowed only here | Free | -16 |

**Overlays** (no cues of their own): *advantage* adds `advantage_perc` (a bright hand-percussion or triangle ostinato), *danger* adds `bass_weight` (low strings or synth sub, under 120 Hz, so it does not clash with the System Voice).

**Day-part variants** (`daySplit` is set on `explore` and `town`): the machine reports `Variant` = morning / day / dusk / night. Recording brief: **morning** = motif in the highest register of the lead instrument, light percussion; **day** = full motif and bed; **dusk** = same key one register lower, tempo 8% slower, strings added; **night** = solo lead plus pad, no percussion, no `town_folk` brass or drum, tempo 15% slower. Four short alternates of the bed and motif per region (not four tracks); layers beyond those four are shared.

## 3. Stingers and one-shot cues

All fire through the music bus, ignore the loudness of the current state, and last under 4 s unless noted.

| Cue id | Fires when | Sound |
|---|---|---|
| `mus_stinger_region_arrival` | Entering a new region on a calm tick (never first tick after a load) | Region motif's first four notes, lead instrument, 3 s |
| `mus_stinger_victory` | Combat resolves to `aftermath` | Rising resolve in the home key, 2 s |
| `mus_stinger_elite_pickup` | Entering `elite` | Two-bar brass or string swell on the dominant, 1.5 s |
| `mus_stinger_boss_intro` | Entering `boss` | Boss's own motif hit plus a drum break, 2 s; control returns at once |
| `mus_stinger_boss_phase` | Boss phase increases | Rim-shot and bar-aligned fill, 1 s; never a pause in control |
| `mus_companion_<name>` | Companion theme under `explore`, `town`, `rest` only (gain 0.8) | See §5 |
| Proposal: `mus_stinger_rank_up`, `mus_stinger_liberation`, `mus_stinger_discovery`, `mus_stinger_bond` | Story punctuation named in `adaptive_music_and_scene_pacing.md` | One short cue each, region-neutral, played in the world key; not in data yet |

## 4. Region motif sheet (49 regions)

Columns: `mus_motif_reg_<id>`, palette family (the opening doc's instrument group, or a family I propose where it has none), lead instruments for the motif, home mood, explore tempo, home mode. **Mode and tempo are proposals;** instruments for the 16 regions in the opening doc are taken from it, the others are mine and marked *(p)*. Rank and ring come from `Data/World/regions.json`.

| Region id | Rank, ring | Lead instruments | Mood | BPM | Mode |
|---|---|---|---|---|---|
| `whisperwood` | F-E, 1 | Wooden flute, harp, solo cello *(p)* | Ancient, sacred, gentle first steps | 76 | D Dorian |
| `aldmere` | F-C, 2 | Tin whistle, lute, strings, piano | Pastoral, warm | 92 | G major |
| `greymoor` | D-C, 2 | Low whistle, hammered dulcimer, fiddle *(p)* | Misty, wistful | 66 | A Aeolian |
| `sylvaran` | D-B, 3 | Harp, choir, wooden flutes | Ancient, sacred | 70 | E Dorian |
| `mossdeep` | D-C, 3 | Bassoon, marimba, jaw harp *(p)* | Damp, playful, small | 84 | F Lydian |
| `lirian` | D-B, 3 | Mandolin, accordion, harp, soft brass *(p)* | Canal-town elegance | 96 | C major |
| `fanghold` | D-B, 4 | Frame drums, horns, fiddle *(p)* | Rowdy frontier | 108 | D Mixolydian |
| `iron_hold` | C-A, 4 | Anvil percussion, low brass, male choir | Mighty | 80 | C Aeolian |
| `moraveil` | C-S, 4 | Pipes, bodhran, strings *(p)* | Warm, mixed frontier | 100 | A Dorian |
| `strife_marches` | C-B, 4 | Snare march, solo trumpet, strings *(p)* | War-torn, resolute | 88 | B Aeolian |
| `velmark` | C-B, 4 | Harpsichord, strings, woodwinds *(p)* | Orderly, tax-bright | 104 | B-flat major |
| `hoshizora` | C-A, 5 | Koto, shakuhachi, taiko | Serene, ceremonial | 72 | In-sen |
| `kitsune_isles` | C-A, 5 | Koto, shamisen, ocarina, bells *(p)* | Spirit-lit, playful | 90 | Hirajoshi |
| `frostveil` | B-A, 5 | Solo female vocal, cello, frame drum | Lonely, vast | 60 | D Aeolian |
| `shen_lu` | B-S, 5 | Erhu, guzheng, dizi | Soaring | 82 | Pentatonic major |
| `haneul` | B-A, 5 | Gayageum, haegeum, buk drum + synth | Modern-traditional tension | 100 | Gyemyeonjo |
| `whitewater_reach` | A-S, 5 | Solo vocal, cello, glass harp *(p)* | Cold, vast, ice-bright | 58 | F Aeolian |
| `umbravel` | C-B, 5 (under) | Pipe organ, dark choir, muted strings *(p)* | Hush, amber lantern warmth against dread | 64 | C-sharp Phrygian |
| `sunscar` | B-A, 6 | Oud, ney, darbuka | Mysterious, epic | 84 | Hijaz |
| `goldmere_coast` | B-S, 6 | Guitar, steel drum, strings *(p)* | Merchant sun, salt air | 98 | D Mixolydian |
| `zarvan` | B-A, 6 | Oud, ney, darbuka, santur | Mysterious, epic | 92 | Nahawand |
| `zaruma` | B-A, 6 | Kora, talking drum, balafon | Storytelling, golden | 96 | G Mixolydian |
| `dunewhale_drift` | B-A, 6 | Duduk, frame drum, low whale-call pad *(p)* | Vast, drifting | 54 | E Phrygian dominant |
| `xochitl_mire` | C-B, 6 | Ocarina, rattles, clay flutes *(p)* | Humid, ritual | 78 | A Aeolian |
| `lumbaya` | B-A, 6 | Gamelan, kulintang, bamboo flutes | Lush, eerie at night | 88 | Slendro |
| `stormreach` | B-S, 6 | Taiko-like toms, brass, choir *(p)* | Wind-torn, defiant | 110 | E Aeolian |
| `true_name_isles` | B-A, 6 | Harp, tin whistle, wordless chorus *(p)* | Quiet, reverent, ocean-lit | 68 | F Lydian |
| `hollow_sea` | B-A, 6 (under) | Glass harmonica, sub pad, whalesong *(p)* | Pressure, wonder | 48 | Whole tone |
| `ashira_vale` | B-B, 6 | Harp, solo violin, bells *(p)* | Pilgrim peace, grief and hope | 64 | D major |
| `dragon_spine` | A-S, 7 | Horns, low brass, taiko *(p)* | Titanic, mountain | 72 | D Phrygian |
| `sky_archipelago` | S-SS, 7 | Celesta, harp, high strings, choir *(p)* | Floating, awe | 80 | A Lydian |
| `heavenreach` | A-S, 7 | Choir, harp, brass fanfare *(p)* | Radiant, lofty | 84 | E major |
| `vharlen` | B-A, 7 | Snare march, brass band, strings *(p)* | Imperial pressure | 96 | B-flat minor |
| `gearholm` | B-A, 7 | Music-box, clockwork percussion, distorted synth | Mechanical | 112 | F-sharp Aeolian |
| `cinderhole` | A-A, 7 | Music-box, clockwork percussion, distorted synth | Mechanical, ember-lit | 104 | C Locrian |
| `bastion` | B-S, 7 | Horns, drums, throat singing *(p)* | Wide-steppe martial | 100 | G Dorian |
| `everdusk` | A-S, 7 | Celesta, harp, cello, wordless choir *(p)* | Twilight court, bittersweet | 66 | G-flat Lydian |
| `apu_highlands` | A-S, 7 | Panpipes, charango | Vast, spiritual | 74 | A pentatonic minor |
| `lustrine_shores` | A-S, 7 | Moon harp, strings, glass chimes *(p)* | Night-sea shimmer | 62 | B Lydian |
| `quaking_lands` | S-S, 7 | Taiko, low brass, bowed gong *(p)* | Tectonic dread | 70 | C Phrygian |
| `aurumdeep` | A-A, 7 (under) | Hammered bells, strings, brass choir *(p)* | Gilded, sunken, mad | 76 | E-flat Dorian |
| `nox_dominion` | S-SSS, 8 | Pipe organ, dark choir, dissonant strings | Tragic grandeur | 60 | D Phrygian |
| `calamity_steppe` | S-SS, 8 | Horn solo, wind pad, frame drum *(p)* | Scarred, open, silent | 56 | E Aeolian |
| `the_maw` | S-SS, 8 (under) | Sub pad, bowed metal, wordless choir *(p)* | Hunger, vast dark | 44 | Chromatic cluster |
| `root_of_the_world` | SS-EX, 8 (under) | Harp, choir, deep bells *(p)* | Origin, sacred | 52 | F Lydian |
| `vesper` | SS-EX, 9 (post-game) | Reversed Valdrisian hymns, glass harmonica | Haunted | 50 | Whole tone / Dorian |
| `labyrinth_upper` | F-C, 2 (under) | Stone bells, lute drone, wind in shafts *(p)* | Curious dread | 56 | D Aeolian |
| `labyrinth_deep` | B-S, 6 (under) | Low strings, bowed glass, choir *(p)* | Heavy, deep | 48 | B Phrygian |
| `labyrinth_abyss` | SS-EX, 8 (under) | Sub pad, glass harmonica, solo voice *(p)* | Final descent, lonely | 42 | C Locrian |

**Underworld and dungeon regions** (`labyrinth_*`, `umbravel`, `hollow_sea`, `aurumdeep`, `the_maw`, `root_of_the_world`): the `dungeon` state plays their bed and drone; the `motif` layer is not in the dungeon state's layers, so their motif is heard in `cutscene`, `aftermath` and the arrival stinger only. This is the shipped behaviour; no change proposed.

## 5. Companion themes (14 ids in `music_states.json`)

One instrument seed each, chosen from the race in `Data/Companions/companions.json` (race is the only sourced detail I had; personalities come from the character docs, which I did not re-read for this job). **Proposal; the writer or user may overrule.** Each theme is a 4 to 8 bar melody in the party's home key that sits on top of `explore`, `town` or `rest`, gain 0.8, never under combat music.

| Id | Race (data) | Instrument seed |
|---|---|---|
| `cmp_lyra`, `cmp_aldric`, `cmp_elira` | Human | Violin, piano, clarinet |
| `cmp_seraphine` | High Elf | Harp with wordless voice |
| `cmp_kiri` | Wolf-kin | Frame drum with low flute |
| `cmp_nyx` | Dragon (child form) | Celesta with a low horn answer |
| `cmp_bram` | Halfling | Penny whistle with accordion |
| `cmp_kaito` | Human (summoned) | Electric-leaning guitar loop (the only electric hint outside bosses; keep it clean and quiet) |
| `cmp_mochi` | Slime | Marimba and bubbly woodwind |
| `cmp_vexmor` | Demonkin | Cello with muted brass |
| `cmp_torvald` | Dwarf | Bass voice hum with anvil taps |
| `cmp_suzune` | Fox-kin | Koto with small bells |
| `cmp_tobin`, `cmp_elsie` | Origin-dependent | Region motif's lead instrument of the companion's origin region |

## 6. Region state variants (besieged and liberated) and gaps for the engineers

- `Data/World/regions.json` gives every region an `initialState` (`besieged` for 40, `liberated` for the Labyrinth regions, Sky Archipelago, Nox Dominion, Calamity Steppe, Maw, Root and Vesper). **Proposal:** a liberated region's `bed` and motif return in the major-leaning or lifted mode (Aldmere G major stays; Greymoor moves A Aeolian to A Dorian; Nox shifts toward D Dorian), lead instrument unchanged, with 2 added doubling instruments. Liberation is a harmony change, not a new track (`adaptive_music_and_scene_pacing.md`).
- **Gap 1 (needs gameplay-engineer or core-rules-engineer):** `MusicInput` has no region liberation flag, so the machine cannot pick the besieged or liberated variant. Proposed field: `RegionLiberated` (bool), reported as a `Variant` suffix. Not built here (this job touches no code).
- **Gap 2:** `siege_waves.json` battles have no music state. Proposal: a siege wave plays `combat` / `elite`, the Tyrant plays `boss` with the region's motif; no new state.
- **Gap 3:** a victory stinger for *liberation* is listed above as a proposal; it is not in the data.

## 7. What was not checked

- No audio was auditioned, composed or tested; all numbers above are targets.
- The cue sheet was not run through the validator (`Tools/validate/audio_checks.js` validates the JSON, not this note).
- `Canon.md` was searched for the audio rows only (music, voice, rock stem, buses); the personalities of the 14 companions and region lore were not re-read.
