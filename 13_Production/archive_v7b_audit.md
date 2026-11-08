# Archive v7b audit: Civilization Archive and archaeology

Source: `upgrade v7` sections 3 and 4 (ancient civilizations, archaeology). Wave E built the dungeon and puzzle half (`dungeon_v7_audit.md`). This is part 2, step 4. Docs: `12_Systems/civilization_archive.md`.

## What was asked and what was built

| v7 item | Decision |
|---|---|
| Several ancient civilizations (architecture, technology, languages, religion, symbols, conflicts) | **Built as a record only**, five civilizations that already exist in `history.md`. No new civilizations, languages or symbols were invented |
| Civilization Archive with manuscripts, inscriptions, paintings, machines, records, objects, maps | **Built.** 13 entries across those seven kinds, Unknown / Heard / Visited |
| Connect discoveries to reveal events and locations | **Built lightly.** A restored entry pencils in a dungeon clue or a region; nothing unlocks |
| Excavation locations, buried fragments | **Built.** 11 fragments, once each, at ruin sites or Warren rooms |
| Fragment identification | Folded into excavation (each fragment names its entry) |
| Restoration minigames | **Not built**; the rule is a deterministic action, a mini-game can sit on top |
| Historical research, museum displays, collections | **Not built** beyond the artifact names and the saved list of restored artifacts |
| Rare discoveries, artifact gameplay benefits | **Rejected.** Knowledge only: no items, XP or power |
| Underground and hidden civilizations, ancient guardians, corrupted archaeological entities | **Not built** (new lore and combat design) |
| Artifact database, civilization data editor | Schema and validator only |

## Canon and lore checks
- **No new canon.** Entry text paraphrases `history.md` II to VI and the material clues in V. The sources are listed in the data and checked to exist. Anything new is marked draft.
- **Spoiler order protected.** The public account only; Canon §3 secrets are scanned out by the validator and a test. The Ashen Gate entry states only the alliance defeated Malgareth, as history.md does (his escape is a Canon §3 secret and does not appear). Review notes: the Sunscar "glass" and "road" entries were trimmed so they do not point at the lost capital before Act V; the Aldmere ruin is assigned to the Dragons draft (not the dwarves).
- **Never gating.** No quest, board, story flag or rank references the archive (checked by a test). The archive has no reward that unlocks anything.
- **No locked Canon row changed.** Decision A1 is recorded in Canon section 6.

## Build summary
- New: `CivilizationArchive.cs`, `civilization_archive.json`, schema, validator block, 11 fragment items, `ArchiveTests.cs` (10 tests).
- Changed: `SaveGame.Archive`, `GameDatabase.Archive`, item category `fragment`.
- Old saves: `Archive` is null, `Upgrade` fills it, a test covers it.

## Decisions (delegated creative control; the user may overrule)
1. Five civilizations, one per existing lore age block, no new ones.
2. Entries are public accounts only; the secrets stay out until a story-driven reveal that this archive does not provide.
3. Fragments hold draft placements and names; they are the only new content, and they are all marked draft.
4. Reading and restoring are separate: 8 entries read in place, 5 restored from 2 or 3 fragments.
5. A restore uses up its fragments (deterministic, once) and pays knowledge only.
6. Hints can only mark things Heard; the Wave E rule that a hidden way opens only when the clue is found in place is untouched.

## Skipped and why
Mini-games, museum and collection screens, new places, artifacts with power, and Unity wiring. New lore needs the user's approval and a lore pass; this part never touches `Game/`.
