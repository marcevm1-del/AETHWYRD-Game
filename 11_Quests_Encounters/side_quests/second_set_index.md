# 11e — Second Regional Set: 380 Side Quests (index)

> **Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Quests are built into `Data/` by `Tools/quests/build_side_quests.js`; the full table is [[all_side_quests]].

Thirty-eight more regions, ten quests each, ranks D to SS. Each file has its own cast, scenes, dialogue, choices, outcomes and receipts. None kills a Tyrant, ends a siege or answers an open Canon question; unexplained seeds are labelled in each file.

| File | Region | Prefix | Ranks |
|---|---|---|---|
| [[19_moraveil]] | Moraveil | qst_mor_ | B–A |
| [[20_strife_marches]] | The Strife Marches | qst_mar_ | B–A |
| [[21_velmark]] | Velmark | qst_vel_ | C–B |
| [[22_umbravel]] | Umbravel | qst_umb_ | C–B |
| [[23_goldmere_coast]] | Goldmere Coast | qst_gmc_ | B–A |
| [[24_sunscar]] | Sunscar | qst_sun_ | B–A |
| [[25_shen_lu]] | Shen-Lu | qst_shl_ | B–A |
| [[26_haneul]] | Haneul | qst_han_ | B–A |
| [[27_zarvan]] | Zarvan | qst_zar_ | B–A |
| [[28_gearholm]] | Gearholm | qst_gea_ | B–A |
| [[29_xochitl_mire]] | Xochitl Mire | qst_xoc_ | C–B |
| [[30_stormreach]] | Stormreach | qst_str_ | B–A |
| [[31_whitewater_reach]] | Whitewater Reach | qst_whr_ | A–S |
| [[32_dunewhale_drift]] | Dunewhale Drift | qst_dwd_ | B–A |
| [[33_labyrinth_upper]] | Upper Labyrinth | qst_lab_ | D–C |
| [[34_kitsune_isles]] | Kitsune Isles | qst_kit_ | C–A |
| [[35_zaruma]] | Zaruma | qst_zrm_ | B–A |
| [[36_lumbaya]] | Lumbaya | qst_lum_ | B–A |
| [[37_true_name_isles]] | True-Name Isles | qst_tni_ | B–A |
| [[38_ashira_vale]] | Ashira Vale | qst_ash_ | B |
| [[39_hollow_sea]] | Hollow Sea | qst_hol_ | B–A |
| [[40_heavenreach]] | Heavenreach | qst_hvr_ | A–S |
| [[41_everdusk]] | Everdusk | qst_evd_ | A–S |
| [[42_dragon_spine]] | Dragon Spine | qst_dsp_ | A–S |
| [[43_vharlen]] | Vharlen | qst_vhl_ | B–A |
| [[44_cinderhole]] | Cinderhole | qst_cnd_ | A |
| [[45_apu_highlands]] | Apu Highlands | qst_apu_ | A–S |
| [[46_lustrine_shores]] | Lustrine Shores | qst_lus_ | A–S |
| [[47_quaking_lands]] | Quaking Lands | qst_qkl_ | S |
| [[48_aurumdeep]] | Aurumdeep | qst_aur_ | A |
| [[49_nox_dominion]] | Nox Dominion | qst_nox_ | S–SS |
| [[50_calamity_steppe]] | Calamity Steppe | qst_cal_ | S–SS |
| [[51_the_maw]] | The Maw | qst_maw_ | S–SS |
| [[52_root_of_the_world]] | Root of the World | qst_rot_ | SS |
| [[53_vesper]] | Vesper | qst_ves_ | SS |
| [[54_sky_archipelago]] | Sky Archipelago | qst_sky_ | S–SS |
| [[55_bastion]] | Bastion | qst_bas_ | B–S |
| [[56_labyrinth_deep]] | Labyrinth, Drowned Floors | qst_ldp_ | B–S |

## Open points for approval
- **SS rewards** (Nox Dominion, Calamity Steppe, Maw, Root of the World, Vesper) are first-pass guesses extrapolated from the S→SS promotion row; no SSS/EX quests exist (the rank enum stops at SSS).
- **More new races** to confirm: "Demon", "Slime", "Vesperite".
- **Collect ids that do not exist** in `Data/Items` (validator does not check): `nox_ashwheat_sheaf`, `steppe_ship_bird_feather`, `maw_resin_leaf`, `rot_hesk_lantern`, `hollow_sea_starter_algae`.
- **Maw quest 8** uses `talk` on an NPC who is not its giver; several unnamed speakers in the Maw/Root/Vesper files have no NPC block.
- **Apu Highlands** renames the real-world Q'eswachaka as "the Rope Gorge"; **Lustrine Shores quest 10** says "the player's own hand" in the lamp (reword if too player-specific).
- **Word counts:** many agent-written quests run 480–700 words, below the 650–900 target; a lengthening pass is possible.
- **New lore and seeds** for files 45–56 are listed at the end of each file (Apu thumb-hollows, Lustrine memory-lamps, Quaking Ridge cycle, Aurumdeep fool's gold, Nox shared well and hidden day-prayer, Steppe release call, Maw second rhythm, Root weeping, Vesper lantern and moon-colour contradictions).
- **Ashira Vale** is all rank B because the gazetteer gives it a "B–B" band; confirm that is intended.
- **More S-rank rewards** (Heavenreach, Everdusk, Dragon Spine) are extrapolated from the promotion table.
- **Hollow Sea quest 4** collects `hollow_sea_starter_algae`, an item that does not exist yet (the validator does not check collect targets; same for several earlier quests).
- **More race values** to confirm: "Fey", "Heavenfolk", "Kitsune", "Kobold".
- **New lore to approve** (details in each file): Lumbaya name-tunes and the Night Market; True-Name Isles ledger and pillars; Heavenreach executed messenger's letter and flight-stones; Everdusk treaty-stone clause; Labyrinth Reset Hour and the key for the next door; Zaruma's unrecovered fourth verse; Hollow Sea's oil-less lantern.
- Pure seeds: Labyrinth floor eleven-and-a-half, Kitsune Sunken Isle apology, Zaruma's seam Mansacor avoids, Dragon Spine's fifth note and warm vertebra, Vharlen's chiselled-out pledge line, Cinderhole's flue voice, Ashira Vale's Warden offer.
- **S-rank rewards** (the two Whitewater Reach quests) are extrapolated from the guild promotion table and are first-pass.
- **Sunscar** dates the old empire and the Colossus's route at about a thousand years; the gazetteer gives no date, so soften or approve.
- **Gearholm:** the Fourth Engine explosion cause (a mistranscribed word), the 212 dead against 31 on the plaque, the Undercity observer's chair.
- **Xochitl Mire:** the river-king's "Pledging" as the hated part of the old feeding rites.
- **Zarvan:** the stone-bearers as Zahhar's div-kin; the basin and its eleven pour-notches.
- **Race values** "Gnome", "Dwarf", "Clockborn", "Bird", "Spirit" on some NPC records were accepted by the validator; confirm they are wanted.
- Pure seeds (no explanation given): Whitewater's skeleton on the beach, Thalassa's four-phrase hum, Velmark's eleventh clause, Umbravel's new knot, Goldmere's dark shape.
