# PROJECT ASCEND (working title, name decision due ~2026-11-01)
### Open-World Isekai / High-Fantasy Adventurer RPG: Design Bible v0.2

> *"Somewhere between your last breath and your first, a voice said: **Status granted.** When you opened your eyes, the sky had two moons, the grass hummed with mana, and a little card in your pocket read **Rank F**."*

## Locked Decisions
| Decision | Answer | Impact |
|---|---|---|
| Presentation | **Full 3D, third-person** | Anime/toon-shaded 3D, open-world streaming |
| Players | **Single-player only** | No netcode. Companions fill the party role |
| Team | **You + Claude** | Data-driven content, tool pipelines, built in "rings" |
| Business model | **Premium, one-time purchase, Steam** | No microtransactions, gacha or timers |
| Title | **Open**, revisit around **Nov 1, 2026** | "Project Ascend" is a placeholder |

## Bible Index
| # | File | Contents |
|---|---|---|
| 01 | 01_Core_Concept/vision.md | Vision, pillars, fantasy-feel rules, loops, acts, endings |
| 02 | 02_Lore/cosmology.md | Creation myth, pantheon, history, the System, moons, calendar, languages, mysteries |
| 03 | 03_Rank_System/ranks.md | F→SSS: guild cards, trials, perks, threat scale, Transcendence |
| 04 | 04_Classes/*.md | Base & Advanced · Expert/Master/Legendary/Hidden · Monster Evolution |
| 05 | 05_Skills_Magic/skills_and_magic.md | Stats, spell lists by element & tier, weapon arts, Unique Skills, fusions |
| 06 | 06_Races_Origins/races_and_origins.md | Races, subraces, cultures, Origins |
| 07 | 07_Characters/companions_and_npcs.md | Companions, key NPCs, villains, factions |
| 08 | 08_Bestiary/*.md | Creatures I & II, Bosses & Calamities |
| 09 | 09_Equipment/*.md | Gear systems & sets, Legendary & Divine artifacts |
| 10 | 10_World/regions.md | Every region in depth |
| 11 | 11_Quests_Encounters/quests_and_encounters.md | Quest framework, sample quests, encounters, events |
| 12 | 12_Systems/systems.md | Economy, crafting, housing, taming, bonds, death |
| 13 | 13_Production/production.md | Engine, 2-person pipeline, build rings, Steam plan |

Every table is meant to become a data file later, so the game grows by adding rows, not rewriting code.

## v0.3 Updates (Questionnaire #1, answers 1–34)
| File | What changed |
|---|---|
| 00_Questions/questionnaire_01.md | The 50 questions (35–50 still open) |
| 00_Questions/answers_01.md | **Authoritative answers + design impact** (overrides older docs) |
| 04_Classes/new_base_classes.md | 12 base classes: + Lancer, Martial Artist, Bard, Occultist; class-change rules |
| 08_Bestiary/menace_and_rank_research.md | Anime rank research, Menace axis (cute → horror), F-rank horrors, 12 new families, Boss Suitability |
| 12_Systems/systems_addendum_v03.md | Difficulty floor at S+, respec, Relics/chase items, Exceptional Promotion, Chosen vs Fated Unique Skills, taming roster, Settlement Prosperity, traversal, 1,000-hr pacing |

## v0.3 Story Pass
| File | Contents |
|---|---|
| 02_Lore/history_detailed.md | Full timeline: Two Hands → Dragons → Titans → Sundering → Valdrisia → Long Night → the 3 previous Heroes → 1024 SC |
| 02_Lore/main_story_beats.md | Prologues per Origin + Acts I–VI beat-by-beat, choices, story flags |
| 02_Lore/life_in_aetheria.md | Veilborn in society, the Guild, faith, law, economy, daily life, race relations |
| 00_Questions/questionnaire_02_story.md | 80 story/world questions |

## v0.4 Story & World Pass (Questionnaire #2)
| File | Contents |
|---|---|
| 00_Questions/answers_02_story.md | **Authoritative answers** to the 80 story questions |
| 02_Lore/story_expansion_v04.md | Demon Overlord + 5 Generals, redeemable villains, 5 Heroes + Veilborn legends, 8 System personalities, god communion, the Wyrmconclave, 11+1 endings, 10 tearjerkers, mascots, childhood friends, tournaments, Academy, living dungeons, NPC plan |
| 10_World/world_regions_v04.md | 28 surface regions + 5 underworld layers, each with anime/literature inspirations |

## v0.5 Research Pass (Questionnaire #3)
| File | Contents |
|---|---|
| 02_Lore/red_prophet_and_nocturne.md | Q21: the Red Prophet = Brother Caspian / Malgareth Vey; **Vesper the red moon IS Valdrisia**; the Seven Red Choirs. Q2: Nocturne wears **Mina's** face from Act III |
| 10_World/cultures_research_v05.md | 11 new research-based cultures (40 surface regions total), the Cultivation track (Q4), 60+ Underworld Deepgates (Q6) |
| 13_Production/opening_music_and_memories.md | Your-character anime OP template (Q8), music direction ("Chen for the world, Sawano for the fights"), Memory Reel + photo mode (Q7) |

**Decided by Claude (Q3):** detail order = **Aldmere/Brindlewick first** (it's what we build), then the **Mossdeep of the Thimblefolk** and **Aurumdeep** as showcase regions.

## v0.6 Monster Pass
| File | Contents |
|---|---|
| 08_Bestiary/monster_design_kit.md | Research (Dragon Quest variants, Monster Hunter skeleton classes, shape language), the 7-choice recipe, 25 shared rigs, Blender → Unity workflow |
| Tools/monster_gen/families.js | **275 hand-written core species** across 31 families (edit here) |
| Tools/monster_gen/generate.js | Generator: `node Tools/monster_gen/generate.js` |
| Data/Monsters/species.json/.csv | **620 species** with look descriptions and design recipes |
| Data/Monsters/population.json/.csv | **6,600 population variants** (region × age/marking tier) |
| 08_Bestiary/species_catalog.md | Readable catalog of all 620 species |
