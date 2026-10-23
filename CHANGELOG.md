# Changelog

Version history of the design bible and data. Git history has the exact diffs.

## v0.12 — Monster motion & rig validation (2026-10-22)
**Part A: Monster Motion**
- New `08_Bestiary/monster_motion_bible.md` (+ `rig_sheet.png`): Blender ↔ Unity conventions, the scaling laws (mass, Froude gait speeds, play rate, turn rate, attack windups with a fairness floor), the 25 shared rigs, the universal animation set and attack choreography, Menace / element / behavior motion languages, procedural layers, physics & death styles, art budgets, Ring 0–1 motion sheets, step-by-step workflows.
- New data: `Data/Monsters/rigs.json` (25 rigs, `npm run rigs`), `motion_overrides.json` (hand-authored motion for 20 Ring 0–1 monsters; hand-picked rigs for imps and lantern moths), generated `motion.json` for all 680 species (`npm run motion`, part of `npm run build`). Every species gets a rig by its rigId, an override or a keyword; none falls back to the human rig any more. Variants use their base species' hand-picked rig. The 20 species matched by keyword are listed by `npm run motion -- --report` for review.
- New `Tools/blender/build_rig.py`: builds any rig with IK controls and graybox proxies and exports a Unity FBX with the axis fix of the *Blender To Unity FBX Exporter* (no "Apply Transform", which Blender's exporter calls broken with armatures). All 25 rigs exported with Blender 5.0.1 and read back: every bone present, `root` at the origin, rotation 0 and scale 1 on the root objects, facing +Z.
- New `Code/Unity` (local package `com.projectascend.monsters`, not yet added to `Game/`): `MonsterMotion`, `SpringChain`, `SquashStretch`, `SteppedAnimator`, `FreezeWhenObserved`, `Hurtbox`/`BreakablePart`, and *Assets ▸ Ascend ▸ Build Monster Prefabs From Rig*. Compiles against Unity 6000.6.7f1's assemblies without warnings; not yet imported or run in Unity.
- `Code/Ascend.Core/MonsterMotionLaws.cs` with tests that it gives the same numbers as `motion.json` for every species. Tests: 54 → **57**.
**Part B: rig & hitbox validation skill**
- New `.claude/skills/unity-3d-rigging-hitboxes/` (Claude Code skill "RigKit"): Blender scripts that inspect rigs and skin weights, infer a skeleton for unrigged meshes, sweep joint ranges, test walk cycles (foot sliding, floating, knee pops), fit hurtboxes and ragdoll colliders and export to Unity; a Unity package with a read-only validator, clip sampler, collider importer, batch/CI runner and a hit/hurtbox runtime. Own test suite and report in its `tests/` folder.

## v0.11 — Sieges, review fixes, weekly board & inns in code (2026-10-22)
**Part A: Regional Siege & Liberation, built**
- 40 regional **Tyrants** as unique species in their regions (`Tools/monster_gen/tyrants.js`), mostly bosses already in the bestiary; 9 regions marked `noSiege`. Goblin Chief Grukk is Whisperwood's Tyrant (raids Brindlewick and Millbrook) and still the F→E trial.
- `regions.json`: `tyrantSpeciesId`, `siegeFaction`, `defenceSettlements`, `initialState`. Generated `siege_waves.json` (3 waves per region from the Tyrant's faction living there, lieutenant, escalation) + schema.
- Quests: `SiegeDefence` type and a `regionState` condition; Whisperwood defence and post-liberation hunting templates.
- C#: `RegionThreat`, `SiegeScheduler` (1–2 attacks per 7-day week, never on consecutive days, announced a day ahead, deterministic), `SiegeAutoResolve` + `SettlementProsperity` (never destroys, damage repairable), `DeterministicRandom`. New `world_tuning.json`.
**Part B: review fixes**
- Style points cap; real Freeze (shatter) and Storm Prison stun; poise regeneration; loot as decimal `chance` with a 0.1% Relic Shard chase drop and luck as a multiplier.
- Player side: `progression.json` (stat formulas, XP curve shared with the monster generator), `classes.json` (Swordsman + Ring 0 kit), `PlayerStats`, `XpCurve`.
- Ring 0 monsters at F- with level spreads; the Horned Rabbit has its own stat profile.
- Quests: `prerequisites` {quests, flags, act, rank} and `setsFlags`; `story_flags.json`; NPC `states` by story flag (Mina → Nocturne) and `schedule`; `QuestGate`.
- Explicit `bossHpMult` (Tyrants 5, unique beings 6, EX 15) instead of baked-in boss HP; one signature attack per monster family.
- Generated `bestiary_viewer.html` and CSVs are no longer committed.
**Part C: weekly board & inns in code**
- C# models for `weekly_board.json` and `inns.json`, loaded in `GameDatabase`. `GameCalendar`, `WeeklyBoard`, `InnStay` (rest buffs, regular status), `InnTab`.
- Tests: 22 → **54**.

## v0.10.10 — Echoes of Aincrad (2026-10-22)
- `borrowed_features.md` #24–30 from *Echoes of Aincrad* (SAO, July 2026): Switch hand-offs, Command vs Free Rein with fatigue, Death Game presentation for Hardcore (never paywalled), waystone respawn rule, Labyrinth floor-boss raid councils and the Frontline, a playable "Day the Windows Glitched" town event, the Veilborn Circle; plus lessons from its reviews (dungeon variety rule).

## v0.10.9 — Borrowed features (2026-10-22)
- New `01_Core_Concept/borrowed_features.md`: 23 mechanics adapted from similar games, each mapped onto existing Ascend systems (companions, combat, exploration, settlements, presentation), with sources. Listed in Canon §6 for approval.

## v0.10.8 — Inns (2026-10-22)
- New `12_Systems/inns.md`: inn services, room tiers and rest bonuses, regular status (Stranger → Family), Marta's tab, nightly inn events (incl. siege refuge and liberation party), inns tied into Prosperity, housing, the weekly board, bounties, monster towns, the Labyrinth and your own teahouse, plus inn UI.
- New `Data/World/inns.json` + `inn` schema: 20 signature inns across the regions, each with a keeper, house dish and drink, a signature room, a quirk, nightly events and a secret.
- Weekly board: + *Rush Hour at the Griffon* (inn part-time job; can pay off your tab).

## v0.10.7 — Deepening existing systems, part 2 (2026-10-22)
- **Crafting:** how a craft works (material rank caps, stations, Crafter's Mark, naming masterworks, insight on failure), a minigame for every discipline, life ranks judged by master NPCs, commissions and your shop.
- **Housing:** rooms and features by stage, Comfort and style sets, visitors and home events, territory residents and buildings (territories can be besieged), Lord Protector city policies.
- **Death & Difficulty:** fixed the companion-death line to match Mortal Bonds; added the after-death flow (goblins steal your dropped gold), custom difficulty sliders, Hardcore legacy graves.
- **Quality-of-Life:** convenience features and a "the clock only runs while you play" rule.
- **Respec:** free token per class tier, partial respec, preview on the dummy, loadouts.
- **Gear slots:** per-slot rules, belt slots that grow with rank, a separate Relic slot, durability that never fully breaks.
- **Guild Master succession:** if Rodrick dies after Act III, Nocturne (as "Mina") takes the guild unless exposed; guild elections.

## v0.10.6 — Deepening existing systems (2026-10-22)
- **Economy:** prices by rank, what moves prices (Prosperity, sieges, reputation, haggling, seasons, Otherworld Knowledge, Blood Vesper), trade routes, long-game gold balance, banking.
- **Taming:** the full taming encounter (calm vs fear), partner roles, growth, and how taming ties into Nemesis, sieges, Karma/Thread, monster towns and the bestiary. Fixed the old "1 → 2 → 3 familiar slots" line to match the Canon 3-active roster.
- **Bonds & Romance:** bond levels 1–10 with unlocks, companion core values, bond floors (5 and 8), the romance path from spark to marriage and adoption.
- **Karma:** three hidden meters (Karma, Renown, Thread), gray-choice examples, god reactions, Karma bands and their world effects, crimes vs Karma, redemption.
- **Regional Siege & Liberation** now lives in `systems.md` (and Canon §4b), not only in the session prompt.
- **Rank-Up Ceremony:** all nine ceremonies, each with its own place, moment and gift.
- **Character Creator:** full creator flow, 12 old-world jobs with perks, Otherworld Knowledge ideas and dialogue, and the Mirror of Vanity.

## v0.10.5 — Even more features & UI (2026-10-22)
- `the_big_upgrade.md`: features 37–52 (pair & triple Union Skills, interrupting villain monologues, Last Stand friendship revival, sealed-power segments, monster languages, eavesdropping, the Natural History Museum, Earth Relics, archaeology & murals, companion expeditions, mount personalities & racing, climate comfort, the Grand Cooking Contest, concerts, photo requests, letters & parcels).
- `hud_and_ui.md` §25–31: party formation, bond screen, shops & haggling, waystones & fast travel, collections book, combat log & training readout, expedition board.

## v0.10.4 — More features & UI (2026-10-22)
- `the_big_upgrade.md`: features 21–36 (measurement moments, party names & banners, Kaede's Cards card game, spellcrafting, growth weapons, Mochi eats things, ranch breeding & markings, Rift Runs, guild written exam, a bounty on you, street duels, elemental world interaction, silly anime curses, the Vexday time loop, hired party members, guild hall facilities).
- `hud_and_ui.md` §16–24: HUD pieces unlocked through the world, living title screen, loading screens, death screen, journal-style saves, Rumor → Lead → Quest log, world markers & loot beams, replayable Guide tutorials, UI sound & motion.

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
