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
