# Life-skill XP curve review (systems-designer, 2026-11-11)

Scope: `Data/Items/life_skills.json` (`xp` block), `Data/Items/recipes.json`, `Data/World/gathering.json`, `Code/Ascend.Core/LifeSkills.cs`. Decided by Claude under delegated creative control; the user may overrule any row. Slow-Life rules hold: XP never decays, no skill is penalised for absence, nothing is lost.

## 1. The curve itself is fine: no number changes

| Step | XP | Ratio to previous step | Crafts at on-rank recipe XP | Gather nodes at on-rank node XP |
|---|---|---|---|---|
| F to E | 250 | n/a | 25 | 50 |
| E to D | 550 | 2.20 | 40 | 79 |
| D to C | 1,800 | 3.27 | 90 | 180 |
| C to B | 4,000 | 2.22 | 143 | 286 |
| B to A | 9,000 | 2.25 | 225 | 450 |
| A to S | 20,000 | 2.22 | 358 | 715 |
| S to SS | 40,000 | 2.00 | 500 | 1,000 |
| SS to SSS | 70,000 | 1.75 | 637 | 1,273 |

- Total F to SSS is 145,600 XP: about 2,016 on-rank crafts or about 3,600 mixed gather nodes per skill. Spread over a 1,000-hour game (Canon section 2) that is 2 to 4 actions an hour per skill, a background pace, so the length is right.
- Steps grow about 2.2x and ease to 1.75x at the end, which is the right shape (late ranks are long but not a wall). The one bump is D to C (3.27x): it is where masterwork commissions begin (`commissionFromRank` D) and the player needs a real stretch of practice before the first real master NPC, so I keep it.
- Multipliers hold: first craft x3, trivial x0.25 for recipes 2+ ranks below, minimum 1 XP, no penalty anywhere. Nothing to change.

## 2. Findings that do need work (all content or wiring, none in the numbers)

| # | Finding | Evidence | Fix and owner |
|---|---|---|---|
| L1 | **Gathering gives no life-skill XP.** `LifeSkills.OnGather` is called only by the home farm (`Housing.Harvest`). Mining, Logging, Herbalism and Fishing nodes pay nothing, so those four skills cannot rank up from play. | `grep OnGather Code` returns `Housing.cs` and `LifeSkills.cs` only. | **core-rules-engineer:** call `OnGather(node.skill, node.rank)` when a node is gathered, with a test. |
| L2 | **Gathering nodes carry no rank.** `gathering.json` has 4 nodes (herb patch, mushroom ring, weeping pine, scrap heap) with `skill` and `respawnHours` but no `rank`, which `OnGather` needs. | `Data/World/gathering.json`. | **tools-pipeline-engineer** (schema) and **world-builder-engineer** (nodes): add a required `rank` field; ladder below. |
| L3 | **No recipes above rank B.** Craft recipes exist only at F to B (50 recipes, 9 skills); with every skill at B the next steps have no on-rank recipe, and a skill two ranks above its best recipe earns the trivial 25%. Today the ladder effectively ends at about A for crafts. | `recipes.json` count per `lifeRank`. | **items-designer:** add recipes at A, S, SS, SSS (counts below). |
| L4 | **Recipe supply at D and C is a single recipe per skill** (blacksmithing D1 C1 B1, alchemy D1, tailoring D1, leatherworking D1 C1, jewelcrafting C1). D to C needs 90 crafts: grinding one recipe 90 times. Repeat crafts pay full XP, so it works, but it reads as grind. | Same table. | **items-designer:** 4 recipes per rank by D, 5 from C. |

## 3. Targets for the content owners

Recipes per craft skill (9 craft skills) so first-craft bonuses (x3) carry about 30% of each step and repeats carry the rest:

| Rank | F | E | D | C | B | A | S | SS | SSS |
|---|---|---|---|---|---|---|---|---|---|
| Target recipes per skill | 4 | 4 | 4 | 5 | 5 | 6 | 6 | 6 | 6 |
| Exist today (average) | 3.0 | 1.2 | 0.4 | 0.4 | 0.2 | 0 | 0 | 0 | 0 |

That is 46 per skill, roughly 400 in all (about 350 beyond today's 50). It is a long-run target; the minimum that unblocks the ladder is one recipe per rank per skill from A to SSS (36 recipes), then fill D and C to 4.

Gather node ranks (L2): a node's `rank` follows the region it sits in (F Aldmere-class farmland through SSS endgame wilds), with the same rank ladder as monster population tiers. Suggested first four: herb patch F, mushroom ring E, weeping pine F, scrap heap E.

## 4. Test ideas for qa-tester

1. Gathering a rank-r node with the matching skill adds `gatherXpPerNode[r]` XP and never subtracts.
2. A node two ranks below the skill pays 25% (min 1), never 0 and never negative.
3. Every craft skill has at least one recipe at every `lifeRank` it claims (a data invariant, once L3 lands).
4. No recipe or node `rank` is outside F to SSS.
5. Old saves with no gather XP still load (null-coalesce in `LifeSkills.Load`, already true).

## 5. Method

Computed from `life_skills.json`: `crafts = step XP / defaultRecipeXpByRank[rank]`, `nodes = step XP / gatherXpPerNode[rank]`, first-craft recipes for 30% = `ceil(0.3 x step / (3 x recipe XP))`. Recipe and node counts from `recipes.json` and `gathering.json` in this branch.
