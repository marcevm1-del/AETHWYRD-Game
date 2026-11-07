# Crafting v6 audit and Wave B design contract

Source: `upgrade v6` (root). Canon wins: `Canon.md` rows on Slow-Life ("Progression without repetition debt", "Companion support economy"), the guild row (player cannot own a guild), and `12_Systems/systems.md` §5/§5.1/§5.3. This note says what existed before Wave B, what v6 asks for, what Wave B builds, and what it skips. It is also the contract the Wave B agents build against.

## 1. What existed before Wave B

| Area | State on main | Where |
|---|---|---|
| Items, inventory | 29 items, 86 materials. Inventory is `itemId -> count` plus copper. No quality, no per-item data | `Data/Items/*.json`, `Inventory.cs` |
| Recipes | 6 recipes, 3 stations (forge, alembic, campfire). Fields: skill, station, inputs, output, `learnFrom` teacher | `recipes.json`, `Crafting.cs` |
| Discovery | `Handle` (hypotheses from handled materials) and `Experiment` (work a recipe out at the station). Already implemented | `Crafter` |
| Gathering | Nodes with respawn hours and loot-table yields. Skill id on a node, no XP | `gathering.json`, `Gathering.cs` |
| Equipment | Slot equipment, armour weight, weapon types. No quality stat scaling | `Equipment.cs` |
| Quality | "Standard quality only until the optional mini-games" | `Crafting.cs` header |
| Life skills | Only a free-text `skill` string on a recipe. No XP, rank or gating | n/a |

## 2. v6 ask versus Wave B

| v6 item | Decision |
|---|---|
| Crafting quality tiers, critical outcomes | **Build.** Canon ladder Poor, Normal, Fine, Superior, Masterwork (Legendary reserved for quest and Tyrant recipes). No random failure |
| "Failure and success chances" | **Reject** (Canon §5.1: failure never destroys rare materials; Slow-Life). Quality is deterministic from inputs, skill, station, optional attunement, seed |
| Recipe experimentation | Discovery already exists. **Add** optional *attunement*: spend one declared extra input for a quality bump |
| Crafting XP, mastery levels, unlockable recipes | **Build** on the **canonical** life-skill table (see 3) |
| Profession perks, challenges | Perks = quality cap and recipe unlocks per rank. Challenges = the masterwork commission (hook only, quest content later) |
| Cooking and food buffs | **Build** (optional, short, single "Well Fed" slot, no hunger) |
| Item rarity, custom naming | Crafter's Mark flag on Fine+ and `nameable` on Masterwork (data only; UI later) |
| Gathering professions | XP for Mining, Logging, Herbalism, Fishing via the same skill ladder. Nodes unchanged |
| Specialization bonuses, rare discoveries | Out of scope (teachers and `lifeRank` gating cover the Ring 0 need) |
| Survival and environment needs (v6 §6) | **Not built.** Canon forbids mandatory upkeep and daily decay |
| Housing, farming, player economy (v6 §8-10) | **Not built** (separate waves; no player marketplace per `item_and_economy_design.md` §15) |
| Enchanting, runes, modular equipment, repair | **Not built** (separate waves). Repair stays visual per `item_and_economy_design.md` §6.4 |
| Multiplayer trading, guild crafting halls | **Not built** (single-player; player cannot own a guild) |
| Developer tools (recipe editor) | Validator and schemas only |

### v6's profession list differs from Canon
v6 lists Blacksmith, Armorer, Alchemist, Enchanter, Jeweler, Cook, Leatherworker, Carpenter, Engineer, Herbalist, Hunter, Miner. `systems.md` §5 lists Blacksmithing, Leatherworking, Tailoring, Alchemy, Enchanting, Runecraft, Jewelcrafting, Cooking, Brewing, Farming, Animal husbandry, Mining/Logging/Herbalism, Fishing, Engineering, Painting/Music. **The canonical table wins.** Armorer folds into Blacksmithing (metal) and Leatherworking (light armour). Hunter has no skill: hunting is combat, and the materials it yields feed the crafts. Carpenter is a Housing-wave concern (Logging supplies it). Miner and Herbalist are the gather skills Mining and Herbalism.

## 3. Design contract

### 3.1 Quality (data: `Data/Items/crafting_rules.json`)
Tiers (index): poor 0, normal 1, fine 2, superior 3, masterwork 4, legendary 5 (not craftable). Each tier has `statMult`, `valueMult`, `buffMult` (meals), `mark` (Crafter's Mark on Fine+), `nameable` (Masterwork). Stat bonuses stay small (Masterwork at most +25% stats) so a rank never breaks encounter expectations (`item_and_economy_design.md` §6.3).

```
score = ingredientQuality            (count-weighted mean tier index of the consumed units)
      + skillBonusPerRank * rankIdx  (F=0, E=1 ... SSS=8)
      + experimentBonus   (only if attuned)
      + jitter            (0 .. jitterMax, deterministic from seed + recipe + craft counter; never negative)
index = floor(score), then clamped to [0, cap]
cap   = min(bestIngredientIndex + 1, rankQualityCap[skill rank], stationQualityCap[station])
```
No branch destroys materials randomly. A craft either cannot start (missing input, wrong station, rank too low) or always consumes exactly the listed inputs and yields at least Poor. Camp stations cap at Normal (Canon §5.1: portable camp kits are Poor/Normal only).

**Attunement** is the optional experimentation step: a recipe may declare `attuneItem` (an input or a cheap related item). Spending one extra unit adds `experimentBonus`. Nothing else is consumed and nothing can fail.

**Representing quality in the inventory:** a stack key is `itemId` for Normal and `itemId@tier` otherwise (`ItemQuality.Compose/Split`). Existing saves and tests keep plain ids and stay Normal. Equipment and the HUD must call `ItemQuality.Split` before data lookups (Unity wiring is a follow-up).

### 3.2 Life skills (data: `Data/Items/life_skills.json`)
Skill ids follow `systems.md` §5. Each has a status: `craft` (has recipes now), `gather` (XP from nodes), `deferred` (listed so ids are canonical; no content this wave: enchanting, runecraft, farming, animal_husbandry, engineering, painting_music).
Ranks are the parallel F to SSS tracks (§5.3). XP thresholds per rank are data. Promotion from `commissionFromRank` onward needs the XP **and** a passed masterwork commission (`LifeSkills.PassCommission`, called by quest content); until then the skill sits at the threshold with no loss, so there is no repetition debt. First-time recipe crafts give bonus XP once; crafting far below your rank gives reduced XP, never zero and never a penalty. No decay.
A recipe carries `lifeRank` (default F). You cannot craft a recipe above your rank in its skill. Rank also raises the quality cap.

### 3.3 Recipes
New fields: `lifeRank`, `xp` (optional override), `attuneItem` (optional). Stations are NPC-owned workbenches or portable. Recipes are grouped by station and skill in `recipes.json`. Many early recipes are known from the start; advanced ones have a `learnFrom` teacher.

### 3.4 Cooking buffs
Meals are consumable items with a `meal` block: effects (`stat`, `amount`), `seconds`. Eating sets a single **Well Fed** slot (a new meal replaces the old one, no stacking), strength scales with quality `buffMult`, it expires silently with no debuff. No hunger, thirst, temperature or upkeep. Eating is never required (Canon: Companion support economy, Progression without repetition debt).

## 4. Canon proposals (for the user, in Canon §6)
See the end of `12_Systems/crafting.md`.

## 5. Skipped and why
Enchanting, runes, modular parts, repair, survival, farming, housing, brewing days-long fermentation (waits for Housing), insight-from-failure (the discovery wave; failure can no longer produce Poor except through bad inputs), batch crafting (needs UI), gather-quality materials (needs a gathering-mastery wave).
