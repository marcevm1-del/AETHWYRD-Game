# PROJECT ASCEND (working title; name decision ~2026-11-01)
### Open-World Isekai / High-Fantasy Adventurer RPG — Design Bible v0.7

> *"Somewhere between your last breath and your first, a voice said: **Status granted.** When you opened your eyes, the sky had two moons, the grass hummed with mana, and a little card in your pocket read **Rank F**."*

**Start here:** [`Canon.md`](Canon.md) has the settled facts, numbers and spoilers, and **wins any conflict**. [`CHANGELOG.md`](CHANGELOG.md) has the version history.

## Design Bible (one file per topic)
| # | File | Contents |
|---|---|---|
| 01 | [vision.md](01_Core_Concept/vision.md) | Pillars, fantasy-feel rules, loops, acts, product facts |
| 01 | [the_big_upgrade.md](01_Core_Concept/the_big_upgrade.md) | **52 signature features**: Lying Interface, Appraisal, Thread, Otherworld Knowledge, Next Summoning NG+, chant mastery, monster cuisine, Adventurer Times, mentoring newcomers… |
| 01 | [borrowed_features.md](01_Core_Concept/borrowed_features.md) | 30 proven mechanics from similar games (Echoes of Aincrad, Dragon's Dogma 2, Rune Factory, Monster Hunter, Wuthering Waves, Octopath, Pokémon Legends, Stardew, Palworld…), rebuilt on Ascend's systems |
| 02 | [cosmology.md](02_Lore/cosmology.md) | Creation, the Eight (+ the Forgotten Ninth), the System and its 8 personalities, talking to gods, moons, calendar, languages, the Wyrmconclave |
| 02 | [history.md](02_Lore/history.md) | 50,000 years of history, the Demon Lords, the 5 Heroes and Veilborn legends |
| 02 | [story.md](02_Lore/story.md) | Prologues, Acts I–VI, story flags, the Overlord and 5 Generals, villains, the Red Prophet, Nocturne, endings, tearjerkers |
| 02 | [life_in_aetheria.md](02_Lore/life_in_aetheria.md) | Veilborn in society, the Guild, faith, law, economy, daily life |
| 03 | [ranks.md](03_Rank_System/ranks.md) | F → SSS, trials, perks, Transcendence, Exceptional Promotion, pacing, cultivation |
| 04 | [base_and_advanced.md](04_Classes/base_and_advanced.md) | 12 base + 24 advanced classes, class-change rules |
| 04 | [expert_master_legendary_hidden.md](04_Classes/expert_master_legendary_hidden.md) | 48 expert, master, legendary and hidden classes |
| 04 | [monster_evolution.md](04_Classes/monster_evolution.md) | Reborn Monster Origin evolution trees |
| 05 | [skills_and_magic.md](05_Skills_Magic/skills_and_magic.md) | Stats, spells by element, weapon arts, Unique Skills (Chosen/Fated), fusions, status effects |
| 06 | [races_and_origins.md](06_Races_Origins/races_and_origins.md) | Races, Origins, character creator |
| 07 | [companions_and_npcs.md](07_Characters/companions_and_npcs.md) | Companions, pacing, Mortal Bonds, mascots, NPCs, villains, factions |
| 08 | [monster_design_kit.md](08_Bestiary/monster_design_kit.md) | Research, 25 rigs, design recipe, Menace axis, Boss Suitability, data files |
| 08 | [bosses_and_calamities.md](08_Bestiary/bosses_and_calamities.md) | Bosses, Generals, Elder Dragons, Calamities |
| 08 | [bestiary_lore.md](08_Bestiary/bestiary_lore.md) | Flavor text per monster family |
| 08 | bestiary_viewer.html | Filterable view of all monster data; **generated** by `npm run gen` (not committed), served by `npm run viewer` |
| 09 | [gear_systems_and_sets.md](09_Equipment/gear_systems_and_sets.md) | Slots, rarity, materials, sets, upgrades, Relics |
| 09 | [legendary_artifacts.md](09_Equipment/legendary_artifacts.md) | Divine artifacts, sentient weapons, legendaries |
| 10 | [brindlewick.md](10_World/brindlewick.md) | Ring 1 hub town: history, districts, daily rhythm, people, quests, secrets |
| 10 | [world.md](10_World/world.md) | All 40 regions with inspirations, Underworld, Deepgates, deep dives, traversal, living dungeons |
| 11 | [quests_and_encounters.md](11_Quests_Encounters/quests_and_encounters.md) | Quest framework, encounters, world events, tournaments, the Academy |
| 11 | [weekly_board.md](11_Quests_Encounters/weekly_board.md) | The 7-day week and its anime daily quests: day specials, dailies, weekly commission |
| 12 | [hud_and_ui.md](12_Systems/hud_and_ui.md) | HUD & UI: rank colors, HUD presets, exploration/combat/boss HUDs, notifications, Status Window, world UI, dialogue, appraisal tiers, accessibility, controls |
| 12 | [inns.md](12_Systems/inns.md) | Inns & taverns: rooms and rest, regulars, Marta's tab, nightly events, 20 signature inns, ties to other systems |
| 12 | [combat.md](12_Systems/combat.md) | **Combat spec**: camera, movement, combos, hit-stop, parry, reactions, Style Rank, damage, Ring 0 fun test |
| 12 | [systems.md](12_Systems/systems.md) | Status Window, combat, economy, crafting, housing, difficulty, taming, prosperity, inventory, UI, loss safety |
| 13 | [production.md](13_Production/production.md) | Engine, pipeline, build rings, release (deferred) |
| 13 | [ring0_plan.md](13_Production/ring0_plan.md) | Ring 0 prototype: tech setup, 10-week milestones, your checklist |
| 13 | [opening_music_and_memories.md](13_Production/opening_music_and_memories.md) | Anime opening, music direction, Memory Reel, story presentation |
| 00 | [00_Questions/](00_Questions/) | Questionnaires and answers (**historical record**; folded into the docs above) |

## Data & Tools
All game content lives in `Data/` as JSON, checked against `Data/Schemas/`.

| Command | What it does |
|---|---|
| `npm run build` | Rebuild schemas, regenerate monsters, validate data, run the C# rules tests |
| `npm test` | Run the C# rules tests (`Code/Ascend.Core.Tests`) |
| `npm run validate` | Validate all data (schema + unique IDs + cross-references) |
| `npm run gen` | Regenerate monsters from `Tools/monster_gen/families.js` |
| `npm run viewer` | Serve the bestiary viewer at http://localhost:8137 |

| Data | Path |
|---|---|
| Regions (rank bands, rings, Tyrants, siege state) | `Data/World/regions.json` |
| Siege waves (generated) | `Data/World/siege_waves.json` |
| World tuning (calendar, sieges, inns) | `Data/World/world_tuning.json` |
| Player classes & progression | `Data/Classes/classes.json`, `Data/Classes/progression.json` |
| Story flags | `Data/Quests/story_flags.json` |
| Monsters | `Data/Monsters/` (species, population, attacks, loot tables; Tyrants in `Tools/monster_gen/tyrants.js`). CSVs are generated, not committed |
| Items | `Data/Items/` (materials generated, items hand-written) |
| Inns | `Data/World/inns.json` |
| NPCs / Quests | `Data/NPCs/npcs.json` (with story states and schedules), `Data/Quests/quests.json`, `Data/Quests/weekly_board.json` |
| Combat tuning | `Data/Combat/combat_tuning.json` |
| Game rules (C#) | `Code/Ascend.Core`: engine-agnostic rules: ranks and levels, elements and reactions (Freeze, Storm Prison), damage, Style Rank, loot, poise, aggro, player stats and XP, quest gating, NPC states, **sieges** (`RegionThreat`, `SiegeScheduler`, `SiegeAutoResolve`), **calendar**, **weekly board**, **inns**. Drops into Unity as-is. 54 tests (`npm test`) |

**ID rules:** `reg_`, `mon_`, `pop_00000`, `atk_`, `loot_`, `itm_`, `npc_`, `qst_`, `inn_` + lowercase snake_case. IDs are unique across all data.
