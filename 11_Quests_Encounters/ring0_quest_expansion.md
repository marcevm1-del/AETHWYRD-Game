# 11c — Ring 0 quest expansion (quest-designer)

Data: `Data/Quests/quests.json`, `story_flags.json`, `weekly_board.json`. Numbers are placeholders in the same band as the existing F/E quests (gold is copper). Nothing here edits a locked Canon row.

## 1. Crafting, companion and new-system quests (job 1)

A crafted item is asked for with a `collect` objective that has no `from`: the journal checks the bag at turn-in and takes the items (`QuestLog.TurnIn`). No schema change was needed. Recipes and who teaches them are in `Data/Items/recipes.json`.

| Quest | Giver | Asks for | Station / system | Unlocks |
|---|---|---|---|---|
| `qst_craft_blade_for_the_guild` A Blade for the Guild | Torvald | 1 Fangblade | forge, blacksmithing (Torvald teaches it, 40 cp) | flag `first_commission_forged`, itm_part_iron_blade |
| `qst_craft_cap_for_tomlin` A Cap for Tomlin | Tomlin | 1 Leather Cap, then Captain Holt | tannery, leatherworking | |
| `qst_craft_clinic_stock` Stock for the Clinic | Sister Pell | talk to Fennick, 3 Minor HP Potions | alembic, alchemy | |
| `qst_craft_small_lantern_supper` Supper for the Small Lantern | Marta | 3 Hearth Stews, then Brother Caspian | hearth (the Griffon kitchen only), cooking | flag `small_lantern_supper` |
| `qst_craft_silk_and_ink` Silk and Ink | Ines | Silk Hood and Inkwell Dye | loom, tailoring | |
| `qst_craft_first_glyph` The First Glyph | Torvald | Ember rune and Stone rune | rune anvil, runecraft | flag `first_rune_struck`; needs the blade quest |
| `qst_craft_library_ward` A Ward for the Library | Eolande | 1 Wardweave scroll | enchanting table | needs the Nine Thrones mural quest; rank E |
| `qst_comp_two_on_the_road` Two on the Road | Mina | 4 forest wolves, 1 boar, `partySize` "2" | companions (party of two, the F-rank party size) | |

Decisions (the user may overrule): farming and mount quests were left out because the first home plot arrives at C rank and no Ring 0 mount item exists; the Civilization Archive is never a quest gate (Canon), so no quest reads it.

## 2. The Salvage Warren chain (job 2)

Place: `dng_salvage_warren` (`Data/World/dungeons.json`, Great Labyrinth floors 3-4, rank E, reusable). Five quests in `reg_labyrinth_upper`, in order. All use existing NPCs and species; `reach` targets are the dungeon and room ids so the Unity side can fire them on entry.

| # | Quest | Giver | Objectives | Sets flag |
|---|---|---|---|---|
| 1 | `qst_dng_warren_tally` The Tally of the Lost | Wendel | reach the Warren, 4 Kobold Scavengers, 3 stolen trinkets (drop from scavengers) | |
| 2 | `qst_dng_warren_weighing` Weigh the Way Down | Garrick | Kobold Trapmaster, reach Lower Landing, choice: rusted key or chalk lift | `warren_lower_level_mapped` |
| 3 | `qst_dng_warren_beetle` The Beetle Vault | Rodrick | Armor Beetle (the boss slot), 2 carapace shards | `warren_beetle_felled` |
| 4 | `qst_dng_warren_cistern` The Runesmiths' Game (Hidden) | Torvald | reach the Rune Cistern (secret room), choice: open the lock or leave it | `warren_cistern_found` |
| 5 | `qst_dng_warren_accord` The Tally-Keepers' Accord | Wendel | 3 Kobold Miners, choice: buy back, take a share, or seal | `warren_salvage_settled` |

Rules held (`12_Systems/dungeons_and_puzzles.md`): no quest requires solving a puzzle or holding a puzzle reward (the cistern quest asks for the visit and a choice, not the lock); the key way and the lever way are both honoured in quest 2; kobolds are never allies (`coreIsAlly` false), so quest 5 offers a ruling, not a recruit; the boss is the plain Armor Beetle with no added hierarchy. Because the halls reset weekly, the repeatable run is on the weekly board (section 4).

## 3. The first two companion personal quests (job 3)

Read "first two" as the two companions available in Ring 0 who are also NPCs with a giver id: Lyra (first party member) and Torvald (the smith). Each gets the opener of her or his arc (arcs are 5-8 quests, `07_Characters/companions_and_npcs.md`); later chapters are not written yet. Both are type Companion, need `partySize` 2 and use no hidden relationship numbers: the choice objective is the whole decision, and the companion's reaction is authored dialogue (`quest_outcome_grammar.md`, `companion_relationship_pacing.md`).

| Quest | Arc | What the player does | Choice | Flag |
|---|---|---|---|---|
| `qst_comp_lyra_1_the_girl_who_couldnt_win` | *The Girl Who Couldn't Win* | Watch Lyra at Hollis's yard, spar three dawns | lend a stance / ask her for three of her own / swing beside her | `lyra_arc_first_morning` |
| `qst_comp_torvald_1_the_unfinished_blade` | *The Unfinished Blade* | Gather scrap and crude iron to relight the old forge (needs `qst_craft_blade_for_the_guild`) | ask about the blank / leave it be | `torvald_arc_forge_lit` |

Hand-offs: narrative-writer owns Lyra's rival (unnamed in Canon; do not use Dax, who leads a separate party), the dawn-yard scenes and Torvald's reaction lines; Torvald's son stays off-screen and the tone gentle (teen rating). Whether the choices change Bond or Loyalty is for core-rules-engineer once `RelationshipTests` rules for quest events exist; none is written into data here.

## 4. Weekly board expansion (job 4)

Nine new dailies in `Data/Quests/weekly_board.json` (36 to 45), each on the day's Canon theme (`weekly_board.md` section 1) with three twists. Every day still has one special and at least 3 dailies (the validator checks); a day with more than 3 dailies now varies its board more (the board draws 3 from the day plus the Any pool).

| Day | New daily | Giver | Asks for |
|---|---|---|---|
| Solenday | Warren Salvage Run (rank E, repeatable Warren trip) | Wendel | 3 scavengers, 2 trinkets |
| Solenday | Guild Blade Order | Torvald | 2 scrap blade parts |
| Maelsday | Ink and Dye | Ines | 1 inkwell dye |
| Thorsday | Hearth Poker Order | Brannoc | Fangblade, Carapace Cap |
| Sylvasday | Herbalist's Shelf | Fennick | 2 minor potions |
| Kaelsday | Training Yard Snacks | Hollis | 2 hunter's skewers |
| Morrowsday | Lantern Loaf | Caspian | hearth loaf, talk to Caspian |
| Vexday | Cook-Off Wager | Marta | hearth stew, talk to Gilda |
| Any | Party of Two Contract | Mina | 2 wolves, 1 boar |

Note for the Core side (`WeeklyBoard.cs`): the board filters by weekday and siege state only, not by region or rank, so the Warren run can appear on the Brindlewick board for F-rank players. Its `rankMin` is E; filtering by rank is a small change for core-rules-engineer.
