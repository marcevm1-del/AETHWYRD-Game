# 12 — Crafting, Quality and Life Skills (Wave B)

How crafting works in the Core rules today. The table of life skills and Canon rules live in `systems.md` §5; this file is the implementation reference. Numbers are canonical in `Data/Items/crafting_rules.json`, `life_skills.json` and `recipes.json`. Code: `Code/Ascend.Core/{Crafting,ItemQuality,LifeSkills,MealBuffs}.cs`. Design audit: `13_Production/crafting_v6_audit.md`.

## Quality
Poor, Normal, Fine, Superior, Masterwork (Legendary is reserved for quest and Tyrant recipes and is not craftable). Fine and above carry the **Crafter's Mark**; Masterwork can be named. Stat bonus tops out at +20% (Masterwork), so a rank never breaks encounter expectations.

```
score = mean ingredient tier (weighted by units used)
      + 0.25 per life rank (F=0 ... SSS=8)
      + 0.5 if attuned
      + 0 .. 0.2 jitter (deterministic from seed, recipe and craft counter; never negative)
tier  = floor(score), capped by: best ingredient + 1, the life-rank cap, the station cap
```
- **No random failure.** A craft is refused before it starts (missing input, wrong station, rank too low) or consumes exactly its listed inputs and gives at least Poor. Rare materials are never lost.
- **Attunement** is the optional experimentation step: spend one extra unit of the recipe's `attuneItem` for +0.5. It can never fail.
- Normal ingredients top out at Fine. Superior needs Fine ingredients and rank B. Masterwork needs Superior ingredients and rank A.
- **Camp stations (campfire) cap at Normal** (Canon §5.1). The inn **hearth** and all workbenches reach Masterwork.
- The old `Craft()` stays the "skip" route: Normal quality at the listed cost. `Make()` is the quality route.
- Inventory keys: Normal is the plain `itemId`; other tiers are `itemId@tier` (`ItemQuality.Compose/Split`).

## Life skills
Ids follow `systems.md` §5 (v6's Armorer/Carpenter/Hunter/Miner/Herbalist list was folded into these). Craft now: blacksmithing, leatherworking, tailoring, alchemy, jewelcrafting, cooking, brewing. Gather (XP only): mining, logging, herbalism, fishing. Listed for later waves: enchanting, runecraft, farming, animal_husbandry, engineering, painting_music.
- Ranks F to SSS. Promotion needs the XP threshold; from **D** up it also needs a passed **masterwork commission** (`PassCommission`, called by quest content, §5.3). At the threshold without the commission, XP waits with no loss.
- XP: each recipe pays by its `lifeRank` (or its `xp` override). The first craft of a recipe pays x3 once; crafting two or more ranks below yours pays x0.25, never below 1. No decay, no mandatory repetition.
- A recipe above your rank in its skill is refused with `RankTooLow`. Rank also raises the quality cap.
- Rough pacing: F to E about 1 crafting hour, E to D 2, D to C 5, C to B 8, then the wider game.

## Recipes
32 recipes on 7 stations: forge (Torvald), alembic (Fennick), loom (Ines), tannery (Wren Ashbourne), hearth and brewery (Marta Gruel, the Sleeping Griffon), campfire (portable). Basic F recipes are known from the start; advanced ones are bought from a teacher (`learnFrom`). Discovery by handling materials and experimenting at a station still works. Each recipe names an `attuneItem`.

## Cooking (optional)
Meals carry a `meal` block (stat effects and 300 to 900 seconds). Eating sets a single **Well Fed** slot (a new meal replaces it, no stacking); strength and duration scale with quality (duration at most 2x). It ends silently with no debuff. There is no hunger, thirst, temperature or any upkeep; eating is never required. The campfire makes simple meals at Normal; the Griffon's hearth reaches Fine and above.

## Not built here
Enchanting, runes, modular parts, repair, survival meters, farming, housing, batch crafting, gathering-quality materials, shop stock for the new items, and Unity wiring (`AscendData.cs` loading, `Crafter.Make` in gameplay, `ItemQuality.Split` in inventory and HUD lookups, `LifeSkills.OnGather` in gather nodes, save/load of `SaveGame.LifeSkills`, applying meal stats).

## Canon proposals (for `Canon.md` §6, not applied)
1. **Quality ladder:** adopt Poor/Normal/Fine/Superior/Masterwork as the craftable tiers with the +20% stat ceiling and the deterministic no-failure rule (extends `systems.md` §5.1).
2. **Commission gate:** life-rank promotion from D needs a passed masterwork commission; below D, XP alone promotes.
3. **Inn hearth:** the Sleeping Griffon's kitchen is a Fine-capable cooking station; campfires stay Normal.
4. **v6 profession list:** record that v6's twelve professions map onto the canonical life-skill table (Armorer to Blacksmithing and Leatherworking, Miner and Herbalist to the gather skills, Hunter and Carpenter have no skill).
