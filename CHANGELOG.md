# Changelog

Version history of the design bible and data. Git history has the exact diffs.

## v0.10.3 — Features & HUD/UI (2026-10-22)
- `the_big_upgrade.md` grows to **20 signature features** (+ chant mastery, monster cuisine, Adventurer Times & Rankings, camp night watch, transformation scenes, mentoring newcomers, Trophy Hall, isekai trope feats, festival event weeks, talking dungeons, monster-town boards, sky events, rival party arcs). Scope-cut suggestions removed.
- New `12_Systems/hud_and_ui.md`: full HUD and UI spec.

## v0.10.2 — The Big Upgrade (proposal, 2026-10-22)
- New `01_Core_Concept/the_big_upgrade.md`: a sharper pitch, 7 signature features built on existing lore, recommended scope cuts and a first-15-minutes demo hook. Listed in Canon §6 for approval.

## v0.10.1 — The Weekly Board (2026-10-22)
- **7-day week** added to the calendar and Canon: Solenday, Maelsday, Thorsday, Sylvasday, Kaelsday, Morrowsday, Vexday (one per god; Ilvaris has none).
- New `11_Quests_Encounters/weekly_board.md` + `Data/Quests/weekly_board.json`: 35 repeatable anime-style quests (7 day specials, 22 dailies, 5 any-day fillers, 1 weekly commission) for Brindlewick, with rolled twists and Besieged/Liberated filtering.
- New `weekly_quest` schema; the validator checks references and that every weekday has a special and at least 3 dailies.
- Siege prompt (`13_Production/prompts/session_prompt_v0.11.md`): attacks 1–2 times per 7-day week.

## v0.10 — Brindlewick (2026-10-22)
- New `10_World/brindlewick.md`: the Ring 1 hub town (history, districts map, daily rhythm, people, Ring 1 quest map, secrets).
- Data: +29 Brindlewick-area NPCs (39 total) with backstories, secrets and relationships; +11 Ring 1 quests (15 total); +6 items.
- Validator now checks quest talk targets (NPCs) and collect targets (items).

## v0.9 — Game rules in C# (2026-10-22)
- New `Code/Ascend.Core` (.NET Standard 2.1 / C# 9, Unity-compatible, no engine dependency): ranks and levels, elements and reactions with aura timing, damage formula, Style Rank meter, loot roller, poise meter, aggro tokens, data models and an indexed `GameDatabase`.
- New `Code/Ascend.Core.Tests`: 22 tests incl. loading all real data and cross-checking generator levels against the C# rank rules. `npm test`; `npm run build` now runs them too.
- `combat_tuning.json` gains Style base points per hit weight.

## v0.8 — Combat spec & Ring 0 plan (2026-10-22)
- New `12_Systems/combat.md`: full combat spec (camera, lock-on/free aim, dodge and Flash Time, combo grammar, hit-stop table, poise and break, parry and telegraph colors, element reactions, Style Rank, damage formula, Ring 0 monster AI, fun test).
- New `Data/Combat/combat_tuning.json`: every feel number in one file.
- New `13_Production/ring0_plan.md`: 10-week Ring 0 plan. Blocker found: the installed Unity editor is missing its Package Manager.

## v0.7 — Consolidation & data layer (2026-10-22)
**Docs**
- One file per topic again. Folded `systems_addendum_v03`, `story_expansion_v04`, `red_prophet_and_nocturne`, `world_regions_v04`, `cultures_research_v05`, `new_base_classes`, `menace_and_rank_research`, `creatures_part1/2`, and the design sections of `answers_01` into their main docs.
- New **`Canon.md`**: settled facts, numbers and spoilers in one place. It overrides every other doc.
- New `02_Lore/story.md` (main plot + villains + endings + tearjerkers), `02_Lore/history.md`, `10_World/world.md` (all 40 regions), `08_Bestiary/bestiary_lore.md` (flavor text).
- Fixed contradictions: 5 Generals (not 4); Demon **Overlord** Azrael; 11 + 1 endings; pacing reconciled (focused ~200–250 hrs main story vs explorer pace; SSS ≈ 1,000 hrs); production rings now use 12 base classes, follow the region rings in `regions.json`, and park Steam/Early Access until near the end.
- Expert classes rewritten for the 12-class tree (48 Experts). Mage's second Advanced class is now **Spellweaver** (Warlock moved to Occultist); Guardian's Fortress Knight gains **Chain Warden**.
- **Risk fixes:** companion combat death is **opt-in** (Mortal Bonds option); pack animals/porters only die on Hardcore/Mortal Bonds; one free respec token per class-tier change; new *Loss Safety* table in Systems.
- **Nyx is never romanceable** (childlike appearance). Princess Elowen is a friendship arc, not a romance (the player can't become royalty).
- Proposed companion-count lock and a lighter dialogue tier for Named-monster companions (in `Canon.md` §6, awaiting the user's OK).

**Data**
- Git repository created (with LFS rules for future art/audio).
- Monster species gain gameplay fields: level, stats, attacks, AI pattern, rig/anim IDs, loot tables. 22 SSS-rank species added.
- Habitats capped at 2–5 regions by rank band, climate and element; unique beings live in their lore lairs; Vesper and the Root of the World only accept fitting families.
- Ring tags: Ring 0 = 3 species, Ring 1 = 17, and variants ship after their base species.
- Albino population variants no longer get contradictory coloring.
- New canonical `Data/World/regions.json` (49 entries incl. 3 Labyrinth depth bands).
- JSON Schemas (`Data/Schemas/`) + dependency-free validator with cross-reference checks; seed data for items, NPCs and quests.
- The 98k-word species catalog is replaced by the filterable `08_Bestiary/bestiary_viewer.html`.

## v0.6 — Monster pass
- Monster design kit (25 shared rigs, 7-choice recipe), generator, 620 species, 6,600 population variants.

## v0.5 — Research pass (Questionnaire #3)
- Red Prophet = Brother Caspian / Malgareth Vey; Vesper = Valdrisia; Nocturne wears Mina's face.
- 11 research-based cultures (40 surface regions), cultivation track, Underworld Deepgates, anime opening and music direction, Memory Reel.

## v0.4 — Story pass (Questionnaire #2)
- Demon Overlord + 5 Generals, redeemable villains, 5 Heroes and Veilborn legends, 8 System personalities, god communion, the Wyrmconclave, 11 + 1 endings, 28 regions.

## v0.3 — Questionnaire #1
- 12 base classes, level cap 300, ~1,000-hr pacing, Menace axis, Settlement Prosperity, Relics, difficulty floor at S rank, history and main-story beats.

## v0.2 — Design bible expansion
- Lore, ranks, classes, skills, races, companions, bestiary, equipment, world, quests, systems, production.

## v0.1 — First draft
- Initial concept with F → SSS ranks.
