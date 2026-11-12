# Audit: progression, magic, economy, crafting, companions (2026-11-12)

AGENT: systems-designer (also covering economy-designer and companion-ai-designer views)
MODEL TIER: Sonnet
ASSIGNED TASK: read-only audit of Scopes A (SYS-PRG), B (SYS-ECN), C (SYS-CMP) plus triage of AETHWYRD.odt
FILES MODIFIED: this report only.
FILES INSPECTED (sampled, not exhaustively read): Canon.md (§2, §5, §6 headings), Data/Classes/{classes,progression}.json, Data/World/{guild_ranks,world_tuning}.json, Data/Items/{items,materials,recipes,shops,crops}.json, Data/Companions/companions.json, Code/Ascend.Core/{Progress,Player,Damage,Skills,Shops,SaveGame}.cs, Game/Assets/_Game/Runtime/{Combat/PlayerCombat*.cs, Player/PlayerWorldState.cs, Player/PlayerSave.cs, UI/NpcDialog.cs, UI/CompanionWindow.cs}, Game/Assets/_Game/Editor/Ring0SceneBuilder.Npcs.cs, 13_Production/phase1_api.md, `formula v.1.0` (headings and sections 3, 4.1, 5.1), AETHWYRD.odt.txt, Catagolue_file.ods.txt.
NOT INSPECTED (say so): the 13_Production *_audit.md files, pricing_pass and housing_farming_balance docs, loot_tables.json, gear_rules/crafting_rules numbers, the Core test bodies, party_synergy/companion_field_ai docs, banter. Statuses below rest on code and data reads, not on running anything. No Unity or tests were run.

Key to labels: VF verified fact, DF documented fact, RC reasoned conclusion, REC design recommendation, UA unverified assumption, OQ open question.

## 1. System table

| ID | System | Description | Core status | In-game status | Evidence | Depends on | Known issues | Next action | Pri |
|---|---|---|---|---|---|---|---|---|---|
| SYS-PRG-01 | Attributes and derived stats | 8 stats, base 10, 5 free points per level; atk/matk/def/mdef/hp/mp/sp/spd/crit derived from progression.json | Core TESTED | PARTIAL: derived stats used by PlayerCombat; no allocation UI found | Data/Classes/progression.json; Player.cs L59,164; PlayerCombat.cs L66 | classes | Free points: no spend UI found (UA: none exists in Runtime/UI) | Decide auto-allocate versus manual | P2 |
| SYS-PRG-02 | Level and XP curve | ToNext = MonsterXp(level) x (10 + 0.25 x level) kills; cap 300 | Core TESTED | IMPLEMENTED in game (PlayerCombat.Progress.cs) | Player.cs L201-221; Progress.cs | progression.json | Curve is kill-count based, not the `formula v.1.0` polynomial | none | P4 |
| SYS-PRG-03 | Guild rank F to SSS and promotions | 8 promotion rows with level, GP, quests, special requirement, trial | Core TESTED | PARTIAL: PlayerQuests and NpcDialog "Ask about promotion" show requirements | guild_ranks.json; GuildRank.cs; NpcDialog.cs L143 | quests | Specials such as advanced_class, honored_nation, demon_general, master_floor90 reference content that does not exist in game; only F to E can be played through in Ring 0 (RC) | Confirm Ring 0 stops at E | P3 |
| SYS-PRG-04 | Classes | 12 base classes as data with kits, passives, starter weapons. 24 advanced and 48 expert: ZERO data (only classes.json with 12 entries; no tier other than base) | Core TESTED (ClassKitTests) | PARTIAL: ONE playable class. classId is a serialized field defaulting to cls_swordsman; no class-selection UI, no class-change flow | classes.json (12 ids); PlayerCombat.cs L24, L88; no hit for cls_ in UI/ | Canon §2 12/24/48 | Cannot pick any other class in the Unity build (VF by grep). Advanced/expert and Sub-Class (docs) absent | Decide Ring 0 class count; add selector for the 12 base kits if wanted | P1 |
| SYS-PRG-05 | Skills and kits | Per-class kit with slots (basic, skill x4, ultimate), cooldowns, costs, awakening meter | Core TESTED (SkillCaster) | PARTIAL: PlayerCombat.Skills.cs casts kit skills | Skills.cs; PlayerCombat.Skills.cs | classes | Kits are first-pass tuning (DF classes doc). Skill mastery as a progression track: not found in Core | none | P3 |
| SYS-PRG-06 | Magic | Elemental skills exist as kit data (Mage 11 skills, Cleric, Occultist); `DamageKind.Magical` exists in Damage.cs | Core: enum only. DamageCalculator.Compute treats both kinds identically (uses Attack/Defense as passed; no branch on Kind) | NOT WIRED: every in-game hit uses DamageKind.Physical with Stats.Atk and monster Defense | Damage.cs L19, L64-80; PlayerCombat.Skills.cs L134; MonsterController.cs L397; CompanionAI.cs L202; costMp present in 9 to 11 kit skills of Mage etc but no Runtime code reads MP cost (grep) | classes, combat | Magic has no own formula path in the game: matk, mdef and MP derive in Core but nothing consumes them. A Mage would deal ATK-based damage and cast with SP (VF by grep; RC for the effect) | Wire Kind from skill element or school; spend MP; test | P1 |
| SYS-PRG-07 | Spell structure, chants, restrictions | Chants and restrictions described in 05_Skills_Magic | DOCUMENTED | not present | 05_Skills_Magic/skills_and_magic.md (not read in depth) | magic | no data fields found for chants | defer | P4 |
| SYS-PRG-08 | Races and origins | 06_Races_Origins | DOCUMENTED | not present | UA (no Data/ file for races listed in Data/Player? not inspected) | none | Ring 0 has no creation screen | defer | P4 |
| SYS-PRG-09 | Equipment slots | Slots from items, CanEquip by class weapon and armor lists | Core TESTED (EquipmentTests) | IMPLEMENTED: BagWindow equip, PlayerCombat starter gear, saved | Equipment.cs; BagWindow.cs L73; PlayerSave | items | none found | none | P4 |
| SYS-PRG-10 | Inventory | Counts, key items, spend | Core TESTED | IMPLEMENTED (PlayerInventory, BagWindow) | Inventory.cs; PlayerInventory.cs | items | none | none | P4 |
| SYS-PRG-11 | Titles | card names per rank in guild_ranks.json | Data only | shown via rank | guild_ranks.json titles | ranks | No title-collection system (the ODT asks for more rewards; none exist) | defer | P4 |
| SYS-PRG-12 | Style Rank as progression | Style Rank gives XP and drop bonuses | Core TESTED (StyleRewards) | UA: Style meter used in combat; XP bonus applied via KillXp | Progress.cs L55-70 | combat | none | none | P3 |
| SYS-PRG-13 | Respec and loss rules | Canon §5: respec always possible, free to Lv 10, one free token per tier change; XP loss never de-levels | Loss: Core TESTED (LoseXp never levels down). Respec: NO CODE found (grep Respec in Core: none) | not present | Canon.md L88; Progress.cs L38 | stats | Canon promises respec; nothing implements it (VF grep). Moot while free points have no UI | Add to backlog with SYS-PRG-01 | P2 |
| SYS-ECN-01 | Currency | copper base, 5 denominations at 100x, auto-change; Canon §2 | Core TESTED | IMPLEMENTED (coin purse in HUD, UA) | world_tuning.json L5-14 | none | Note: Canon says each is 100x the previous; data gold = 10000 copper, platinum = 1,000,000: consistent | none | P4 |
| SYS-ECN-02 | Shops and vendors | 4 shops: guild core buyback (rate 1.0), Reed Remedies, Ottoline wagon, Stonebeard smithy; buyback 10 slots | Core TESTED (ShopTests) | IMPLEMENTED: NpcDialog and PlayerInventory use Shop | shops.json; Shops.cs | items | none | none | P3 |
| SYS-ECN-03 | Pricing and sell rates | Buy price about 1.2x to 1.5x of item value, sell 0.5 of value for the categories a shop buys | Core TESTED | IMPLEMENTED | shops.json read in full; computed table below | shops | See loop analysis (no profitable loop found) | none | P3 |
| SYS-ECN-04 | Loot tables and monster cores | loot_tables.json, core pricing doc | Core TESTED (Loot.cs, 87 lines) | PARTIAL (UA: MonsterController drops) | Loot.cs; not inspected data | monsters | loot_tables.json not sampled | owner of economy to sample | P3 |
| SYS-ECN-05 | Materials and gathering | 86 materials; gather nodes in Ring 0 | Core TESTED (GatheringTests) | IMPLEMENTED (GatherNode, saved) | materials.json; GatherNode.cs; PlayerSave | world | none | none | P3 |
| SYS-ECN-06 | Recipes and crafting quality | 58 recipes, stations, quality tiers, attune, XP | Core TESTED (CraftingTests, RealCraftingTests, QualityTests) | IMPLEMENTED: CraftingWindow, PlayerCrafting, saved | recipes.json; Crafting.cs; PlayerCrafting.cs; phase1_api.md §2 | materials | none found | none | P3 |
| SYS-ECN-07 | Life skills | ranked life skills incl. farming | Core TESTED | PARTIAL: CraftingWindow shows rows; used by crafting | LifeSkills.cs; PlayerCrafting.cs | crafting | none | none | P3 |
| SYS-ECN-08 | Meal buffs | Cooked food buffs | Core TESTED (MealTests) | NOT WIRED: only PlayerWorldState mentions MealBuff; no combat reads them (grep) | MealBuffs.cs; PlayerWorldState.cs | cooking | in-game effect absent | wire or defer | P3 |
| SYS-ECN-09 | Gear runes and enchanting | GearFitter: runes, enchantments; 11 rune items in items.json | Core TESTED (GearTests) | NOT REACHABLE: Gear property exists in PlayerWorldState and is saved, no UI or call site (grep for Socket/Enchant/.Gear in Runtime outside WorldState: none) | GearFittings.cs; PlayerWorldState.cs L178 | crafting | Core only | decide whether Ring 0 needs it | P3 |
| SYS-ECN-10 | Housing and farming | Home, crops (4), grow hours, seedsBack | Core TESTED (HousingTests) | NOT REACHABLE: `new Home(...)` constructed and saved, no UI/plant/harvest call in Runtime (grep Plant/Harvest: none) | Housing.cs; PlayerWorldState.cs L86; crops.json | life skills | Core only | defer past Ring 0 | P3 |
| SYS-ECN-11 | Inns | rest and rent | Core TESTED | IMPLEMENTED (PlayerRest, NpcDialog) | Inns.cs; PlayerRest.cs | world | none | none | P3 |
| SYS-ECN-12 | Sinks, faucets, guardrails | systems.md §sinks list: repairs, enhancement, housing, taxes, tuition, respec, fares, festival goods | DOCUMENTED | Only shop and inn sinks exist in game; repairs/taxes/tuition/respec/fares do not (RC) | systems.md L54 | all | Most listed sinks are unbuilt, so late-game currency has no drain (RC) | Defer, but note | P3 |
| SYS-CMP-01 | Companion roster | 14 companions in data (12 + Tobin + Elsie) | Core TESTED | ONE recruitable: only npc_lyra_brightwood gets CompanionAI in the scene builder | companions.json (14 ids); Ring0SceneBuilder.Npcs.cs L30 | quests | 1 of 14 in game (VF) | Ring 0 scope decision | P2 |
| SYS-CMP-02 | Recruitment | "Travel together" offered after qst_main_status_granted | Core partial | IMPLEMENTED for Lyra | NpcDialog.cs L63, L114 | quest | none | none | P3 |
| SYS-CMP-03 | Relationship tracks | Trust, Respect, Closeness, Tension; departures; romance opt-in | Core TESTED (RelationshipTests, CompanionV8Tests) | PARTIAL: CompanionWindow shows the four tracks; BondOf per session and saved | CompanionRelations.cs; CompanionWindow.cs L157; SaveGame.cs L83 | companions | See problem P-03 (stale doc) | none | P3 |
| SYS-CMP-04 | Roles, field AI, orders | CompanionAI in Runtime/World, command wheel | Core TESTED (GroupTactics, presets) | IMPLEMENTED for Lyra (PROTOTYPE quality, UA); companion damage is physical only | CompanionAI.cs L202 | combat | none | none | P3 |
| SYS-CMP-05 | Presets | Balanced etc., saved | Core TESTED | PARTIAL: stored; phase1_api says SetPreset does not retune a joined CompanionAI | phase1_api.md L47-49; SaveGame.cs L85 | companions | live retune absent (DF) | verify | P3 |
| SYS-CMP-06 | Party synergy | assist triggers | Core TESTED (GroupTacticsTests) | UA: wiring per group_tactics_wiring.md (not read) | GroupTactics.cs | field AI | not verified | check | P3 |
| SYS-CMP-07 | Taming and partners | bond, assists, evolution, roster | Core TESTED | IMPLEMENTED: PlayerTaming, PartnerFollower, saved Partners | Taming.cs; PlayerTaming.cs; PlayerSave.cs L87 | monsters | none | none | P3 |
| SYS-CMP-08 | Stables and mounts | Stables built from partner roster; mount families by rank | Core TESTED (StablesTests, MountTests) | PARTIAL: Stables object exists and is saved; CompanionWindow lists mount families; NO riding code found | PlayerWorldState.cs L159-171; CompanionWindow.cs L84-90; grep Mount in Player/: none | taming | Mounts cannot be ridden in the Unity build (VF by grep) | defer | P3 |
| SYS-CMP-09 | Banter | 25 KB banter.json, quiet toggle | Core partial | IMPLEMENTED for Lyra (NpcDialog "Talk less on the road") | banter.json; NpcDialog.cs L111 | companion | none | none | P4 |

Counts (36 rows): Core TESTED 22; Core DOCUMENTED 2; Core data-only 1; Core partial 3; others as noted. In game: IMPLEMENTED 11, PARTIAL 11, NOT WIRED or NOT REACHABLE 6 (magic, meal buffs, runes/enchanting, housing/farming, mounts riding, respec), not present or DOCUMENTED 8. These counts are approximate (RC).

## 2. WHAT IS MISSING
- Advanced (24) and expert (48) classes: no data at all (VF: classes.json holds 12 base entries). Sub-Class, class change, class quest chains as flows: none.
- Class selection and character creation in the Unity build (VF): one class, hard default.
- Magic as a damage path: no Magical branch, no MP spend, no spell chants or restrictions in data.
- Respec (Canon §5), free-point allocation UI, skill mastery track, titles.
- 13 of 14 companions recruitable; mount riding; housing, farming, runes, enchanting, meal buffs have no player-facing wiring.
- Most economy sinks named in systems.md.

## 3. PROBLEMS IDENTIFIED
- P-01 (confirmed): Magic damage has no own formula path. Damage.cs has Kind but never branches on it; callers pass Atk and monster Defense regardless. matk/mdef/mp in progression.json are unused by Runtime. A Mage kit, if selected, would use ATK and SP. Evidence above.
- P-02 (confirmed): Only one class is playable; Canon §2 promise of 12/24/48 is data for 12 only, selection for 1.
- P-03 (confirmed stale doc): 13_Production/phase1_api.md §5 "Not persisted yet" says bonds and presets are not in SaveGame. SaveGame.cs now has CompanionBonds (L83) and CompanionPresets (L85), and PlayerWorldState says they are saved. Doc should be corrected (owner: producer or the doc's author).
- P-04 (confirmed): Respec is a Canon §5 rule with no implementation or data field.
- P-05 (RC): guild_ranks.json promotion specials (honored_nation, demon_general, master_floor90, expert_legendary) have no matching content or checks; fine for Ring 0 if Ring 0 ends at E.
- P-06 (confirmed): "Companions 12 + 2" is satisfied as data (14), but the in-game recruit count is 1.
- Canon conflicts: none found that contradict a locked row. Possible tension (OQ): Canon §2 lists 12 to 24 to 48 classes as locked numbers while only 12 exist; this is a scope gap, not a conflict. `formula v.1.0` conflicts with nothing locked but proposes a polynomial XP curve (3.1) versus Core's kills-based curve; Data is canonical, so the curve stays.
- Catalogue check (VF): Catagolue_file.ods is NOT a newer list. It is a spreadsheet export of existing data: 100 item rows equal the 100 items.json ids exactly (zero extra, zero missing; value and rank columns match), 76 of the 86 materials.json ids, 9 recipes of the 58 in recipes.json, 10 `itm_core_*` monster core rows (the ids appear in materials.json and recipes.json, not items.json) and an element table. No new IDs found beyond data.
- Economy loop check (VF, computed from shops.json, items, materials, crops):
  - Buy prices exceed sell values everywhere (e.g. Reed buys herb at 5, pays 1; sells potion 14 vs value 12). No buy-then-sell arbitrage.
  - Farming loop (Core only, unreachable in game): turnip seed 1 value, yield 3 x 3; mandrake seed 8, 1 x 30 value; seedsBack 1; Reed pays 0.5 x value so about 15 copper per mandrake per 72 in-game hours, about 1 copper per turnip. Harvest returns seeds so cost is zero after the first seed. Not exploitable at these magnitudes, but a prosperous infinite faucet if home farming goes live without a sink (RC). The 2026-11-09 balance docs were not read.
  - Guild core buyback at rate 1.0 with a fixed posted price is a designed faucet; loot_tables.json not sampled, so total faucet is UNVERIFIED.
  - No exploitable loop found; absence of sinks is the larger risk.

### formula v.1.0 against Core
- Exist in Core, different form: damage (Core: Attack x Power x DEF/(DEF+C) x element x crit x variance x stealth x reaction, Damage.cs) vs doc 4.1 (W+B)(1+S a)M; defence mitigation (Core has a constant-based diminishing model; doc 4.2 also proposes diminishing returns, same family); crit and element multipliers (4.4, 5.4); derived stats HP/MP/SP (progression.json linear, doc 3.3-3.5 same shape); XP (Core kills-based, doc polynomial A L^p + B L + C).
- Absent from Core (searched Damage.cs, Defense.cs, Player.cs, file list): hit probability 4.5, damage over time 4.6 as a formula (UA, Defense/Elements may cover status), healing 4.7 as a formula, dodge 4.10, weapon durability 4.11, spell damage 5.1 (see P-01), mana cost reduction 5.2, cooldown reduction 5.3, status buildup 5.5, inventory weight and carry capacity 7.4-7.6, crafting success probability 8.1 and crafting time 8.3 (Core has quality tiers, not success odds; UA), gathering yield formulas, normalisation/diminishing helpers 2.x.
- Not checked: sections 6 (AI), 9 onward.
- REC: do not adopt wholesale. Treat as a menu: spell damage and MP cost are the only items needed soon.

## 4. Triage of AETHWYRD.odt (progression, classes, skills, magic, crafting, economy, equipment, companions)
The document is a prompt of about 150 one-line improvement requests, not specs. Triage per distinct item:
- Class mastery opportunities, optional specialisations, class-specific passives (Part 11): PARTIAL ALREADY DESIGNED (passives exist in classes.json; mastery/specialisation in 04_Classes docs) ; specialisations are an IDEA candidate, TOO COSTLY NOW because only one class is selectable.
- Skill interactions and progression milestones: UPGRADE candidate (reaction table exists for elements; milestones absent).
- Optional class challenges, class dialogue identity: ALREADY DESIGNED as class quests ("classQuest" per class) but not built; defer.
- Unique Skill development: IDEA, TOO COSTLY NOW.
- Equipment specialisations, upgrade choices, set interactions, masterwork challenges, descriptions: ALREADY DESIGNED/BUILT in part (gear_and_runes.md, GearFittings, quality tiers, material_descriptions.json); runes and enchanting NOT reachable, so UPGRADE = wire them.
- Crafting discovery, rare materials, crafting quests, crafting-ecology link: ALREADY BUILT in part (recipes known/unknown, attune) ; ecology link is an UPGRADE candidate (core drops feed recipes already).
- Crafting feedback and presentation: UPGRADE (toasts exist).
- Guild ceremonies, challenges, recognition (Part 10): promotion trials are DESIGNED in guild_ranks.json (trialName); ceremonies IDEA; competitions TOO COSTLY NOW.
- Companion combat roles, strategies, positioning, reactions, support abilities: ALREADY DESIGNED (companion_field_ai.md, party_synergy.md) and partly built for Lyra; extend after more companions are recruitable.
- Companion dialogue, relationship milestones, personal quests, motivations, idle behaviours: ALREADY BUILT as data (banter.json, relationship tracks); quests and equipment progression for companions are IDEA / TOO COSTLY NOW.
- Companion-specific equipment progression: IDEA, not designed.
- Reward variety beyond currency (Part 9): UPGRADE candidate; titles unbuilt.
- Part 15 and 17 long-term motivation: ALREADY DESIGNED partly (ranks, Transcendence); legendary gear objectives are IDEA.
- Parts 1-9, 13, 14, 16: belong to other audits.
- CONFLICTS WITH CANON: none found among my areas. Its own rules ("do not assume built") match the audit findings.

## 5. UPGRADE candidates (strongest first; at most 12, 6 given)
1. Magic damage path. Existing: Damage.cs Kind enum, matk/mdef/mp in progression.json, kit costMp. Status: Core partial, game not wired. Problem: P-01. Evidence: Damage.cs L19, PlayerCombat.Skills.cs L134. Improvement: Compute uses Attack/Defense chosen by skill school (physical or magical), cost spends MP, spell-specific bonus field in data. Benefit: Mage, Cleric, Occultist become real. Dependencies: class selection. Files: Damage.cs, PlayerCombat.Skills.cs, classes.json, DamageTuning. Priority P1. Complexity M. Risk: rebalance of ATK vs MATK. Acceptance: a magical hit with MATK 100 vs MDEF 50 equals the formula; MP drops by costMp; physical unchanged. Testing: new Core test next to ClassKitTests; PlayMode cast test.
2. Class selector for the 12 base classes in the Unity build. Problem: P-02. Improvement: a pre-game choice writing classId to save; or explicitly lock Ring 0 to Swordsman and say so in Canon §6. Priority P1, Complexity S-M, Risk: kit quality varies (first-pass). Acceptance: new game with each class runs the basic chain and one skill. Testing: loop SmokeTest over 12 ids.
3. Respec and free-point allocation. Problem: P-04. Improvement: data field respec token rules (free to Lv 10, one token per tier change), Core method, simple UI. Priority P2, Complexity M. Acceptance: respec restores points, never touches level or XP. Testing: Core tests.
4. Fix phase1_api.md §5 stale "Not persisted" text. Priority P2, Complexity S, Risk none.
5. Sink plan for the economy: add repairs, tuition or respec cost data before housing/farming go live. Priority P3, Complexity M.
6. Wire meal buffs or gear runes into one Ring 0 station (crafting window). Priority P3, Complexity M.

## 6. IDEA candidates (3)
1. Companion-as-teacher: relationship stage unlocks a class passive hint or technique (distinctive; fits four-track relations; depends on more recruitable companions).
2. Lying-Interface appraisal on gear (misleading rune descriptions revealed by crafting skill); fits signature feature; depends on runes wiring.
3. Home-farm as tutorial for the economy loop with a seasonal sink (festival goods) so the faucet has a drain.
Each: Complexity M; Risk scope; Design questions: Ring 0 or later?

## 7. RISKS
- Scope: documented systems (24/48 classes, housing, stables, runes) far outrun the Unity build (confirmed gap; high impact for R11).
- Magic unwired (confirmed): a content push on 12 classes would ship unusable casters.
- Economy has few sinks (theoretical until farming/housing are reachable).
- Test claims: 755 Core rules tests were reported by the orchestrator; PlayMode last recorded 183 passed on 2026-11-08 (not re-run).

## 8. DECISIONS REQUIRED
- Ring 0 class count: one, or a selector for the 12 base classes?
- Is magic needed for Ring 0 (Mage/Cleric) or deferred?
- Which of housing, farming, runes, mounts, meal buffs belong in Ring 0?
- Recruit count for Ring 0 (Lyra only, or more)?
- Whether to adopt any part of `formula v.1.0`.

TESTING REQUIRED: magic damage Core tests; class-selector smoke across the 12 kits; save round trip with a class id; respec rules; sink/faucet simulation once housing is reachable.
CONFIDENCE: high for the class, magic, companion-count and reachability findings (direct greps); medium for status of shop/crafting wiring; low for the loot faucet and docs not read.
UNRESOLVED QUESTIONS: is there a free-point UI I missed in a file not in the grep? Are race/origin data files present? What do loot_tables.json rates add to income? Do the 13_Production audits already record P-01 or P-03?
FINAL STATUS: audit delivered as recommendations only. No code, Data or Canon was changed.
