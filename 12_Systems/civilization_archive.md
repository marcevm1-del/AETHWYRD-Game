# Civilization Archive and archaeology (AETHWYRD)

An optional record of lost history, with ruins to read, fragments to dig up and artifacts to restore. Code: `Code/Ascend.Core/CivilizationArchive.cs`. Data: `Data/World/civilization_archive.json` (schema `civilization_archive.schema.json`). Audit: `13_Production/archive_v7b_audit.md`. This is the Canon-safe part of `upgrade v7` (sections 3 and 4). Dungeons, puzzles and clues already exist (`dungeons_and_puzzles.md`, Wave E); the archive links to them but changes none of their rules.

## Principles (Canon wins)
- **Lore guard.** Every civilization and entry paraphrases lore that already exists in `02_Lore/history.md`, `cosmology.md` and the Salvage Warren data. It shows the **public account only**. The validator and a test scan every title and text for the Big Secrets of Canon §3 (Vesper, Ezrath, the Hooded Traveler, Caspian, Malchior, the harvest and the rest) and fail the build if one appears.
- **Nothing here is Canon that was not already.** New wording and new placements are marked `draft` (see "Proposed, not Canon" below). Nothing was written into `Canon.md` or `02_Lore/`.
- **Optional.** No quest, rank, story flag, ending or shop reads the archive (a test checks the quest, board, story-flag and guild-rank data). It gives knowledge, never power: no money, XP or items.
- **No grind, no luck.** Each fragment can be found once. Restoring is deterministic and uses up only the fragments.

## The record
Entries use the same **Unknown / Heard / Visited** style as maps and dungeon clues (`MapStatus`). A rumour makes an entry Heard (`Hear`); reading it in place or restoring it makes it Visited. A visit is never downgraded.

| Civilization | Source in the lore | Entries |
|---|---|---|
| The Dragons and the First Folk | history II | Draconic Warning Stones (read), The Draconic Covenant (restore) |
| The Titans | history III and IV | Aether Engines of the Sky Cities (read), The War of Heaven and Stone (read) |
| The Dwarves of Karak Dûn | history V, cosmology | Thorgrim's forge (restore), Khazdûr Runes (read, from the Runesmith's mural clue) |
| The Sylvaran Court | history V | The Planting of Lothaniel (restore), The Felled Grove War (read) |
| Valdrisia, the Old Magic Empire | history V and VI | Old Weave-tongue Primer (restore), Towers and Ley-line Farms (read), Roads That End at a Cliff (read), The Glass of the Ritual Circles (restore), The Battle of Ashen Gate, public account (read) |

13 entries in all, 8 read in place and 5 restored.

## Reading
`ReadAtSite` marks an entry Visited when you are at its ruin. `ReadFromClue` marks one Visited once the matching dungeon clue has been **found in place** (Visited), so the Khazdûr Runes entry rides on the Salvage Warren's Runesmith mural clue from Wave E.

## Archaeology
- **Ruins** are the six regions that already carry the `ruins` feature in `regions.json` (Aldmere, Whisperwood, Strife Marches, Sunscar, Lumbaya, the Nox Dominion). Only the Sunscar is tied to a civilization by existing lore (Valdrisia lay in the then-green Sunscar). The other five assignments are proposals.
- **Fragments** (11, item category `fragment`) lie at a ruin site or in a Salvage Warren room. `Excavate` hands one over once, only at its own place.
- **Restoring** (`Restore`) rebuilds an artifact from all its fragments (2 or 3). It is optional, can only be refused before anything is spent, and rewards: the entry (Visited), a displayable artifact name for a future collection screen, and pencilled-in hints (`Apply`). Hints only mark a dungeon clue as Heard (it never reveals a hidden way) and put a region on the map as Heard.

## Saves
`SaveGame.Archive` (entry statuses, fragments found, artifacts restored). Null in old saves; `Upgrade` fills it. `Load` ignores unknown ids and never downgrades a visit.

## Proposed, not Canon (draft)
Everything below is new and waits for the user's approval. None of it is in `Canon.md` or `02_Lore/`.
1. All 11 **fragment placements** (which ruin or room holds which fragment) and their item names and flavour text.
2. The **artifact names** (Karak Dûn foundation plate, Seed-bowl of the Court, Weave-tongue primer, Humming glass disc).
3. Five **site-to-civilization assignments** (Strife Marches, Aldmere, Whisperwood, Lumbaya, Nox Dominion).
4. The **Warren link**: the Runesmith's mural counting as a Khazdûr rune inscription, and a Karak Dûn plate half in the rune cistern.
5. The **wording** of each entry is a short paraphrase of the cited lore line; the audit lists the source of every one.

## Not built here
Museum displays and a collection screen, restoration mini-games, ancient maps that reveal new locations, a language or translation system, hidden or underground civilizations, new ruins or new lore, historian NPCs, artifact buffs, and Unity wiring (loading the JSON, ruin interaction, excavation spots, an archive screen, saving `Archive`).
