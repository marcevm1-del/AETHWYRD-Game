# Footstep, ambience and UI sound event list (job 2)

> **Status:** text spec only; no audio files exist or are added. Event names extend the ones already in `Data/Audio/environment_audio.json` (`sfx_step_<surface>_<gait>`, `sfx_land_<surface>`, `sfx_step_wet_overlay`, `amb_bed_<terrain>`, `amb_*` layers, `rev_*` presets). Everything marked **(new)** is a proposal and is not in data yet; nothing here edits data or code. UI windows come from `12_Systems/hud_and_ui.md` (§6 notifications, §7 Status Window, §8 world UI, §24 UI sound and feel, §25-31 screens). Owner: audio-designer. Companion to `13_Production/audio_music_cue_sheet.md`.

## 1. Conventions

| Prefix | Meaning | Bus |
|---|---|---|
| `sfx_step_`, `sfx_land_` | Footsteps and landings | effects |
| `amb_` | Ambience layers (beds, weather, time of day, zone) | ambience |
| `rev_` | Reverb presets (zone data, not sounds) | ambience send |
| `ui_<window>_<action>` **(new)** | System-window and menu sounds | effects (UI sub-group) |
| `sys_` **(new)** | System notification sounds (toasts, rank-up, warnings) | effects (UI sub-group) |

- **Loudness targets (proposal, on the bus before the player's slider):** footsteps walk -34, run -30, sprint -27 LUFS short-term at 1 m; ambience beds -32 to -28 (never above music explore at -20); UI sounds -26 (open and confirm), -30 (hover); warnings and rank-up -20. Companion footsteps are 6 dB below the player's.
- **Variation:** every event has at least 4 variants (footsteps 6), no immediate repeat, ±2 semitone random pitch, ±1.5 dB random gain. Footsteps pick the variant by foot (left or right).
- **Voice limits and priority (proposal):** footsteps 4 voices (player plus 3 nearest), priority low; ambience beds unlimited-by-design (one bed per active layer), priority lowest; UI 6 voices, priority highest, never stolen by world sounds; `sys_warning_*` and `sys_rank_up` priority top.
- **Silence rule:** unknown terrain falls back to `grass` (already true in `EnvironmentAudio`), and an unknown UI window falls back to `ui_generic_*`, so nothing is ever silent by mistake.
- **Accessibility:** every `sys_` sound that carries information also has a visual cue (already true in `hud_and_ui.md`); the reduced-flash cap does not change audio. Companion callouts and dialogue have their own buses (Canon §6).

## 2. Footsteps per terrain (11 map terrains)

Terrain to surface is the shipped mapping. Gait events exist for `walk`, `run`, `sprint`; each surface also has `sfx_land_<surface>` (a soft and a hard variant picked by fall height **(new)**: `sfx_land_<surface>_hard`) and `sfx_step_<surface>_turn` **(new)** (a small pivot scuff, used when the character turns on the spot).

| Terrain | Surface (data) | Wettable | Sound direction | Extra layers (proposal) |
|---|---|---|---|---|
| plains | `grass` | yes | Soft grass swish, dull thud underneath | Light stem rustle on sprint |
| forest | `leaf_litter` | yes | Crisp leaf crunch, twig snap on run | Occasional twig snap (1 in 8) |
| swamp | `mud` | no | Wet suck and squelch; slower decay | Water droplet tail |
| steppe | `dry_grass` | yes | Dry, brittle brush; hard ground thump | Faint seed-head rattle |
| mountain | `rock` | yes | Hard scuff, small stone clicks | Pebble skitter on sprint |
| volcanic | `ash` | no | Soft crunch of cooled ash, muted | Fine hiss on run |
| tundra | `snow` | no | Squeak and crunch; deep powder variant when the snow tile is deep | Cloth-on-snow shuffle |
| desert | `sand` | yes | Granular shuffle, longer swish | Fine sand patter after landing |
| jungle | `jungle_foliage` | yes | Wet leaf slap, frond brush | Droplet shake on brush-through |
| spirit | `spirit_glow` | no | Almost silent tonal tick, a faint glass chime per step; never louder than -36 LUFS | Soft bell tail on run |
| demon | `cinder` | no | Glassy cinder crackle, slight ember pop | Low hot tick on sprint |

**Context surfaces (data):** `cobble`, `wood`, `stone_floor`, `shallow_water`. Override order from the rules: shallow water beats interior floor beats road beats terrain.

| Context | Surface | Sound direction |
|---|---|---|
| Town road, bridge stone | `cobble` | Hard heel click, light echo through `rev_street` |
| Inn, house, dock, bridge deck | `wood` | Hollow board creak, deeper on run |
| Temple, hall, castle, dungeon floor | `stone_floor` | Clean stone tap with reverb tail from the zone preset |
| Ford, puddle, shore | `shallow_water` | Splash, with small droplet scatter; run adds a bigger splash |

**Weather and gear:** rain and storm add `sfx_step_wet_overlay` on wettable surfaces only (grass, leaf litter, dry grass, rock, sand, jungle foliage, cobble). **(new)** Heavy armour adds `sfx_gear_walk_heavy` (a metal jingle) under any footstep, light gear `sfx_gear_walk_light`; mounted travel replaces footsteps with `sfx_mount_<gait>_<surface>` (hoof beats on the same surface) for ground mounts only (no flying or aquatic mounts, Canon §6).

**Companion and monster footsteps (proposal):** companions use the same events at -6 dB; monsters use `sfx_mon_step_<size>_<surface>` with `size` = small, medium, large, huge (so one set of recordings covers 680 species); flying creatures use `sfx_mon_wing_<size>`.

## 3. Ambience per terrain and window

### 3.1 Biome beds (`amb_bed_<terrain>`, data) and their one-shots

Each bed is a 60 to 90 s seamless loop; the one-shots are randomised every 8 to 25 s inside the bed's listener area **(new)**.

| Terrain | Bed event | One-shots (proposal) |
|---|---|---|
| plains | `amb_bed_plains` | Wind through grass, a distant bird call, a cart creak far away |
| forest | `amb_bed_forest` | Canopy creak, woodpecker, falling twig, a deer step |
| swamp | `amb_bed_swamp` | Frog chorus, bubble burst, heron call, mist drip |
| steppe | `amb_bed_steppe` | Gusting wind, a horse snort far off, a hawk cry |
| mountain | `amb_bed_mountain` | Thin wind, rock tick, eagle cry, an echoing stone fall |
| volcanic | `amb_bed_volcanic` | Rumble, steam vent hiss, distant lava pop |
| tundra | `amb_bed_tundra` | Low wind, ice creak, a lone wolf call |
| desert | `amb_bed_desert` | Dry wind, sand hiss, a lizard scuttle, a far raven |
| jungle | `amb_bed_jungle` | Dense insect layer, monkey calls, rain drip from leaves |
| spirit | `amb_bed_spirit` | Glassy shimmer, soft bells, wordless whispers at -40 LUFS (never intelligible; no lyric words) |
| demon | `amb_bed_demon` | Low ember crackle, a distant groan, wind with a metallic edge |

### 3.2 Weather and time of day (data names)

Weather layers: `amb_wind_low`, `amb_rain_light`, `amb_rain_heavy`, `amb_wind_high`, `amb_thunder_distant`, `amb_snow_hush`, `amb_fog_hush`. Time-of-day layers: `amb_birds_dawn`, `amb_wind_soft`, `amb_insects_day`, `amb_crickets_early`, `amb_birds_dusk`, `amb_crickets_night`, `amb_owl_distant`. **Per-terrain overrides (new, proposal):** at night the forest and plains keep the crickets; the desert replaces crickets with `amb_wind_desert_night` and the tundra with silence plus wind; the jungle keeps insects at night with `amb_frogs_night`; spirit and demon terrain ignore the time-of-day layers (their beds are constant).

### 3.3 Window and zone ambience (reverb zones, data) and the places the player stands

| Zone / place | Zone id (data) | Reverb preset | Ambience (data layers plus proposals) |
|---|---|---|---|
| Open field | `open_air` | `rev_open_air` | Bed, weather, time of day at full gain |
| Forest under canopy | `forest_canopy` | `rev_forest` | Same, weather x0.8 |
| Town street | `town_street` | `rev_street` | `amb_town_murmur` plus **(new)** `amb_town_market` by day, `amb_town_lamps` by night, bed x0.4 |
| Inn or house interior | `wood_room` | `rev_wood_room` | `amb_room_tone`; **(new)** `amb_hearth_fire` at inns, `amb_tavern_chatter` in taverns |
| Guild hall, castle, temple | `stone_hall` | `rev_stone_hall` | `amb_hall_tone`; **(new)** `amb_hall_footfall_far` |
| Cave | `cave` | `rev_cave` | `amb_cave_drip`, `amb_cave_air` |
| Ruin or dungeon interior | `ruin_interior` | `rev_ruin` | `amb_ruin_hum`; **(new)** `amb_ruin_stonefall` rare one-shot |
| Underworld regions (Umbravel, Hollow Sea, Aurumdeep, Maw, Root, Labyrinth) | cave or ruin zone | `rev_cave` / `rev_ruin` | One extra signature layer each: **(new)** `amb_under_umbravel_lanterns`, `amb_under_hollow_sea_pressure`, `amb_under_aurumdeep_metal`, `amb_under_maw_breath`, `amb_under_root_hum`, `amb_under_labyrinth_stone` |
| Shop, guild board room | wood or stone zone | per zone | **(new)** `amb_shop_bell` entry one-shot, soft room tone |
| Home and garden (housing tier) | wood room / open air | per zone | **(new)** `amb_garden_birds`, `amb_chest_creak` on use |

**Region signature beds (proposal, one low layer each):** `amb_region_<id>` layered on top of the terrain bed for places whose identity is sonic: `amb_region_lirian` (canal water lap), `amb_region_iron_hold` (forge hammering far off), `amb_region_gearholm` (clockwork tick), `amb_region_cinderhole` (forge-and-clock), `amb_region_sunscar` (hot wind), `amb_region_zarvan` (fountain and call to market), `amb_region_whisperwood` (soft leaf chime), `amb_region_frostveil` (ice sheet groan), `amb_region_goldmere_coast` (harbour gulls, ropes), `amb_region_stormreach` (surf on cliffs). Others stay terrain-only until a pass adds them.

## 4. UI sound events per window

A shared **family** per `hud_and_ui.md` §24: *open* = glassy chime, *hover* = soft rune hum, *confirm* = crisp click, *cancel* = low tone, *rank-up* = heavy stamp thunk, world UI = physical (paper, quill, wax, coins). Every window uses the generic five (`ui_generic_open`, `_close`, `_hover`, `_confirm`, `_cancel`, plus `_error` and `_tab`) and adds only what is listed.

### 4.1 Generic family

| Event | Sound | When |
|---|---|---|
| `ui_generic_open` | Glassy chime up, rune burst tail (panels slide in over 120-180 ms; sound lands at the first frame of movement) | Any window opens |
| `ui_generic_close` | Reverse chime, shorter | Close |
| `ui_generic_hover` | Soft rune hum | Focus moves |
| `ui_generic_confirm` | Crisp click | Confirm |
| `ui_generic_cancel` | Low tone | Cancel, back |
| `ui_generic_tab` | Light slide | Switch tabs |
| `ui_generic_error` | Short dull buzz, never harsh | Invalid action |
| `ui_generic_scroll` | Faint tick per row | Scrolling a list |

### 4.2 Windows

| Window (doc ref) | Extra events (proposal) |
|---|---|
| Status Window (§7, 10 tabs: Status, Skills, Class, Titles, Bonds, Bestiary, Journal, Map, Memories, System) | `ui_status_open` (rune burst), `ui_status_tab_<name>` (a per-tab accent), `ui_status_stat_add` / `_stat_remove` (up and down tick), `ui_skills_thread_light` (a star lights), `ui_skills_fuse` (two threads cross), `ui_skills_name_commit` (quill), `ui_class_silhouette_reveal`, `ui_titles_equip` |
| Notifications (§6) | `sys_toast`, `sys_level_up` (ring chime plus count-up ticks), `sys_skill_acquired`, `sys_skill_evolved`, `sys_title_earned` (ribbon unfurl), `sys_world_announcement` (broad low bell, all NPCs look up), `sys_rank_up` (stamp thunk, no music duck beyond 4 dB), `sys_warning_danger` (low two-note, red-edged), `sys_warning_boss` |
| System personalities (8) | One tone-set per skin, **(new)**: `sys_skin_<id>` for administrator, mentor, companion, archivist, zealot, warden, duelist, fractured (the fractured skin adds a short glitch crackle; the System Voice itself is a separate dialogue-bus matter) |
| Guild board (§8) | `ui_board_pin_paper`, `ui_board_seal_crack` (day-special wax), `ui_board_dagger_thunk` (siege contract), `ui_board_accept` |
| Guild card (§8) | `ui_card_inspect_rotate`, `ui_card_show_npc` (card slap) |
| Map (§8, world map doc) | `ui_map_open` (parchment unroll), `ui_map_ink` (quill stroke, when a new cell inks), `ui_map_overlay_on` / `_off` (blue-grid hum), `ui_map_pin` |
| Journal and Memory Reel | `ui_journal_page_turn`, `ui_journal_sketch` (pencil scratch), `ui_memory_capture` (shutter click plus soft chord), `ui_memory_pin` |
| Letters and The Adventurer Times (§8) | `ui_letter_arrive` (mailbox flag), `ui_letter_open`, `ui_times_unfold` |
| Dialogue (§10) | `ui_dialogue_advance` (tick), `ui_dialogue_choice_hover`, `ui_dialogue_choice_confirm`, `ui_dialogue_skip`, `ui_dialogue_text_blip` (optional per-line blip, off by default, scaled with the text speed setting) |
| Appraisal (§9) | `ui_appraisal_scan` (rising sweep), `ui_appraisal_seam` (a tiny flicker on a faked window) |
| Inventory and gear (§12) | `ui_bag_open` (leather and clasp), `ui_bag_move`, `ui_bag_drop`, `ui_equip_armor` (buckle), `ui_equip_weapon` (sheath ring), `ui_socket_insert`, `ui_rune_apply`, `ui_scroll_apply`, `ui_item_use_potion` (cork pop), `ui_item_use_food` |
| Shops and haggling (§27) | `ui_shop_open` (door bell), `ui_shop_buy` (coin clink), `ui_shop_sell`, `ui_shop_haggle_start`, `ui_shop_haggle_win` / `_lose`, `ui_coin_pickup` |
| Party formation and Bond screen (§25-26) | `ui_party_slot_set`, `ui_party_swap`, `ui_bond_open`, `ui_bond_level_up` (warm chord), `ui_bond_wants_to_talk` (soft bubble pop) |
| Waystones (§28) | `ui_waystone_attune` (rising chime), `ui_waystone_respawn` (clear bell) |
| Collections Book (§29) | `ui_collection_entry_new` (page flip and chime), `ui_collection_complete` |
| Combat log and training readout (§30) | `ui_combatlog_open` only; no per-line sound (it would add noise in a fight) |
| Expedition and dispatch board (§31) | `ui_dispatch_send` (door slam far), `ui_dispatch_return` |
| Quest log (§21) | `ui_quest_accept` (stamp), `ui_quest_progress` (tick), `ui_quest_complete` (fanfare under 2 s), `ui_quest_lead_new` |
| World markers (§22) | `ui_marker_place`, `ui_marker_remove`; nameplates are silent |
| Guide windows (§23) | `ui_guide_open` (a softer chime than the generic one), `ui_guide_drill_success` |
| Title screen and menus (§17) | `ui_title_start` (title rune hit), `ui_title_continue`, `ui_menu_move` |
| Loading (§18) | None except the optional `ui_loading_done` tick; no looped sound |
| Death and defeat (§19) | `ui_defeat_open` (low hush, no gore), `ui_defeat_retry` |
| Save and load (§20) | `ui_save_ok` (quill and seal), `ui_load_ok`, `ui_save_fail` (generic error plus low tone) |
| Photo mode (`Data/Audio/photo_mode.json`) | `ui_photo_open`, `ui_photo_shutter`, `ui_photo_filter_change`, `ui_photo_close` |
| Settings and accessibility | `ui_setting_toggle_on` / `_off`, `ui_slider_tick`; volume sliders play a short sample on release (music bus: a held chord; effects: a click; dialogue: a "test" tone, not a spoken line) |
| Corruption stages (§13, Lying Interface) | Stage 1: `ui_corrupt_hairline` (one-second glitch across every window), stage 2: `ui_corrupt_crackle` (a crackle under every window), stage 3: `ui_corrupt_choir` (faint choir under gold text) |

### 4.3 Priority, ducking, interruption

- Priority order on the UI group: `sys_warning_boss` > `sys_warning_danger` > `sys_rank_up` > `sys_level_up` > `sys_toast` > window sounds > hover.
- Combat suppresses toasts (`hud_and_ui.md` §6) and their sounds with them; level-ups and warnings pass.
- The music bus ducks 4 dB for 600 ms on `sys_world_announcement` and `sys_rank_up` only. UI sounds never duck dialogue; they are queued behind a System Voice line shorter than 3 s, and played at once if longer.
- Pause or Status Window: ambience low-passes (cut above 6 kHz) and drops 6 dB; music stays at the mix level; UI plays normally.

## 5. Gaps and hand-offs

| Item | Owner |
|---|---|
| Every **(new)** event above is not yet in `Data/Audio/environment_audio.json` or any UI data; adding them needs a schema-valid data file (a `ui_sounds.json` or an extension) | tools-pipeline-engineer / core-rules-engineer |
| Footstep component reading `Terrain` and surface context, wet overlay, gait events | gameplay-engineer, world-builder-engineer |
| UI event hooks in each window prefab | ui-engineer |
| Reverb zone volumes in scenes | world-builder-engineer |
| Fall-height variants, turn scuff, heavy and light gear, mount footsteps need animation events or code | animator-rigger, gameplay-engineer |
| Source and licence for the sounds | job 3 (`audio_source_shortlist.md`) |

## 6. What was not checked

- No sound was auditioned or recorded; loudness and voice-limit numbers are targets.
- Combat hit, telegraph and skill sounds are not in this job (the brief lists footsteps, ambience and UI). They remain on the audio-designer queue.
- `build` does not validate this note; no data or code was changed.
