# Quest location audit, 2026-11-03 (wave 6 of world_upgrade_plan.md)

Scope: `Data/Quests/quests.json` (17) and `Data/Quests/weekly_board.json` (36) = **53 quests**, checked against `Data/World/physical_map.json` settlements[] (51) and roads[] (13), `Data/World/regions.json` places/anchors (49 regions; some, e.g. underground ones, have no `map` and count as region-only, not orphans), and `Data/NPCs/npcs.json` (giver home settlement). Nothing applied; the pending proposals are only listed.

## Result
- Quest regions: all 53 use `reg_aldmere` (33) or `reg_whisperwood` (20); both exist and have a map anchor.
- Givers: 53/53 NPCs exist. 50 live in Brindlewick or Millbrook (both resolve to settlements and to regions.json places under Whisperwood). 3 (qst_wk_sol_escort_cart, qst_wk_vex_dice_night via npc_traveling_merchant_pell; qst_wk_any_wolf_pack via npc_wren_ashbourne) are at "Whisperwood edge": a locality, not a settlement or anchor (region-level only, parent reg_whisperwood resolves).
- Place-like objective targets (reach 11, defend 4): 15. Resolving to a settlement/anchor: 0 by exact id or name. All 14 named ones are Ring 0 hub sub-places defined only in docs (`10_World/brindlewick.md`, `quests_and_encounters.md`), each with a parent settlement that does resolve. `{settlement}` in qst_siege_whisperwood_defence is a runtime template filled from regions.json `defenceSettlements` (Brindlewick, Millbrook), both of which resolve.
- Places checked: 53 givers + 15 place targets + 53 quest regions = 121 lookups (plus 19 talk/escort NPC targets, all exist). Orphans (resolve to nothing in map data): **14 named sub-places + 1 locality ("Whisperwood edge") before and after**; none is an exact-name typo, so nothing was changed.
- Fixes to quest data: **none**.

## Orphans (sub-places with a resolving parent)
| Quest | Target | Parent | Kind |
|---|---|---|---|
| qst_gld_c_silver_wolf | mistvale_farms | Whisperwood/Aldmere (no anchor) | reach |
| qst_main_status_granted | brindlewick_north_gate | Brindlewick | reach |
| qst_class_thousand_swings | hollis_yard_dawn | Brindlewick | reach |
| qst_def_goblins_granary | millbrook_granary | Millbrook | defend |
| qst_inv_smiling_scarecrow | millbrook_fields_night | Millbrook | reach |
| qst_explore_nine_thrones | whisperwood_ruins_mural | reg_whisperwood | reach |
| qst_wk_sol_gate_watch | North Gate | Brindlewick | defend |
| qst_wk_mae_fortune_teller | Old Watchtower | Brindlewick | reach |
| qst_wk_mae_lost_and_found | Rooftops of Brindlewick | Brindlewick | reach |
| qst_wk_mae_bad_dreams | Orphanage of the Small Lantern | Brindlewick (Temple Hill) | reach |
| qst_wk_syl_rabbit_fence | Millbrook turnip field | Millbrook | reach |
| qst_wk_kae_rival_race | Boar den, Whisperwood | reg_whisperwood | reach |
| qst_wk_kae_guard_drills | Training yard mock raid | Brindlewick | defend |
| qst_wk_mor_grave_tidy | Temple Hill graveyard | Brindlewick | reach |

## Distances (map unit = 1 km)
- Brindlewick (72.6, 60) to Millbrook (76.1, 58.7): 3.7 km straight; no road connects them (roads[] has none), so all Millbrook-giver quests that send you to Brindlewick (qst_wk_sol_oath_witness talks to Odo and Hesk in Millbrook from Brindlewick) are off-road, about 3.7 km.
- Brindlewick to Aldmere: road_01 12.9 km (straight 12.0), max grade 5.2%, climb 31 m, crosses river_01 and river_30 twice. Millbrook to Aldmere straight 13.3 km, no road.
- No quest sends the player to Aldmere or any other settlement; all other targets are inside Brindlewick/Millbrook/Whisperwood (0 to about 4 km).

## Hairpin roads and steep settlements
No quest touches road_04/05/06/12 or any steep settlement. Giver and target settlements: Brindlewick slope 4.0%, Millbrook 5.5% (both below the 12% warning). Only road_01 (5.2% max) is relevant.

## Mismatch to note (not a typo, not fixed)
Map and regions.json put Brindlewick and Millbrook in `reg_whisperwood`, but 31 of 53 quests (giver in those towns, region `reg_aldmere`) file them under Aldmere. This is the open Canon row "Brindlewick's region" / W7a(iii).

**Resolved 2026-11-23:** Canon §6 (decided 2026-11-07) keeps Brindlewick and Millbrook in `reg_whisperwood`; the quest, weekly-board and NPC `reg_aldmere` rows for those towns were re-filed under `reg_whisperwood`.

## Affected by pending proposals (Canon §6, "2026-11-02 world upgrade")
- W2b (Karak Dûn to Oathdeep), road_04/05, Karak Dûn Pass: 0 quests. No quest text or doc in 11_Quests_Encounters mentions Karak.
- W7c (21 steep settlements, nudge/terrace) and W7b (lake cells): 0 quests; Brindlewick and Millbrook are not on the list.
- W7a(i) Friendly Goblin, W7a(ii) Vharlen split, W7d, W3 (Lirian, Stormreach, Vharlen etc.): 0 quests.
- W7a(iii) / "Brindlewick's region": the 31 quests above, if Brindlewick moves to Aldmere (or if quest regions are changed to Whisperwood). Whichever is chosen, quest-designer would align `region` in quests.json/weekly_board.json (and the 20 quests already on `reg_whisperwood` are consistent with the map today).
- W1a road names: 0 quests (only road_01 "The Reeve's Road" is on the player's Brindlewick-Aldmere route, and no quest names it).
- Suggested follow-up for world-designer: add anchors for the Ring 0 sub-places and "Whisperwood edge" (or let the NPC `settlement` be Brindlewick) if the map should resolve them.

## Checks
`npm run build`: Data valid (quests 17, weekly 36, npcs 39), map warnings 28 (pre-existing: road grade 4, settlement slope 21, in water 2, river confluence 1). `node Tools/run_tests.js`: 177 tests passed.
