# Monster Core Pricing

**Status:** proposed baseline for economy tuning. Canon.md remains authoritative. Prices below are guild purchase values in copper, not a mandate that cores be sold.

## 1. Core role

A monster core is a condensed residue of a creature's mana and identity. It has three roles, in priority order:

1. **Crafting and progression input** — recipes, research, awakening and specialist services consume selected cores.
2. **Reliable side income** — a hunter can sell surplus cores to the Guild at a posted, predictable price.
3. **Bestiary evidence** — appraisal can identify rank, element and unusual traits; named cores may reveal story clues.

Cores are materials with a market value, not a second currency. The player never needs to sell one to progress. A recipe preview warns when the selected core is needed for a known recipe, and quest-bound cores are protected.

## 2. Proposed guild buy prices

`Data/Items/materials.json` stores copper as the base unit, consistent with `priceCopper` in the inn data. Wallet display converts automatically at 100:1 through copper, silver, gold, platinum and mithril. The proposed base table doubles by rank:

| Rank | Core item ID | Guild buy value | Display |
|---|---|---:|---:|
| F | `itm_core_f` | 2 c | 2 copper |
| E | `itm_core_e` | 4 c | 4 copper |
| D | `itm_core_d` | 8 c | 8 copper |
| C | `itm_core_c` | 16 c | 16 copper |
| B | `itm_core_b` | 32 c | 32 copper |
| A | `itm_core_a` | 64 c | 64 copper |
| S | `itm_core_s` | 128 c | 1 silver, 28 copper |
| SS | `itm_core_ss` | 256 c | 2 silver, 56 copper |
| SSS | `itm_core_sss` | 512 c | 5 silver, 12 copper |
| EX | `itm_core_ex` | 1,024 c | 10 silver, 24 copper |

This is a conservative starting curve, not a player-facing rank multiplier. Rank value is tied to the danger and likely handling cost of the source creature. It does not follow the old ×4-per-letter retail-price curve.

## 3. Why these prices

- Ordinary cores are currently guaranteed in monster loot tables. A guaranteed drop should provide steady modest income, not a jackpot.
- F cores at 2 copper give a useful small supplement beside F-rank contracts and common materials. They are not a better primary income loop than contracts.
- The doubling curve is easy to remember and tune. It avoids the steep jump that would make a late core worth thousands of early cores and encourage rank farming solely for money.
- The price is independent of rarity, quality, or luck. A core's crafting value can be much higher than its sale value.
- Selling all the cores from an encounter remains a valid fallback; the player is not punished with artificial quota exhaustion or a surprise price crash.

## 4. Buying, selling and stock

### Guild buyback

The Adventurers' Guild posts the base table and buys ordinary surplus cores at the listed amount. This is a guaranteed baseline price and does not fluctuate with settlement Prosperity, weather, CHA, siege state or random merchant mood. That makes it dependable without making the core a dominant wealth source.

### Optional specialist demand

Alchemists, enchanters and research houses may post time-bounded **wanted notices** for an element or rank. These pay a visible premium or exchange the core for a recipe component, research credit or local reputation. Notices are optional, have a stated quantity, and refresh on the weekly calendar. The player can always use the Guild baseline instead.

Specialist demand is not a hidden dynamic-market tax: the posted price is stable until the notice expires. It should reward noticing local demand, not require checking every vendor daily.

### Retail purchase

Most ordinary cores are not stocked as standard shop goods. A player who needs a core can:

- hunt the matching rank band;
- buy from a licensed specialist when stock exists;
- commission a research/crafting substitute where the recipe allows it; or
- exchange Guild marks or a quest reward if explicitly listed.

Retail price is authored per offer and includes a clear service premium; it is not automatically the same as the Guild's purchase price. This blocks trivial buy-sell arbitrage.

## 5. Core categories and variation

The ten generic rank cores remain the compact baseline. Elemental, corrupted, ancient and regional creatures may drop a **trait-bearing core** only when a recipe or research system uses that trait. Do not create a new sell-only core for every species or variant.

Where a trait-bearing core is needed, represent it as one of:

1. a rank core plus a data tag (`element: Fire`, `originRegionId`, `variantKind`), if the inventory UI can show it clearly; or
2. a small authored named item for a boss, story creature or signature recipe.

Do not mint an individual inventory item per ordinary monster name. That would multiply schemas, shop stock, icons, localization and vault notes without adding a player decision.

### Named and intelligent monsters

For named or intelligent creatures, a core should not automatically be treated as a trophy or forced kill reward. The quest outcome determines whether the player receives a core, a negotiated token, evidence, or no material. This preserves the moral and ecological consequences already intended for intelligent monster communities.

## 6. Crafting value versus sale value

The core's price must not dictate recipe cost. A high-value recipe can require a particular core because of its lore and properties, while the core's sale value remains modest. Recipes should show:

- which rank/trait is required;
- whether a lower-rank substitute works and what it changes;
- whether the core is consumed;
- how many sources are known;
- whether the item is unique or quest-protected.

Awakening and signature gear should not consume many generic cores solely as a money sink. Use them to express the monster ecology and make the player choose between a concrete set of recipes. Rare progression uses need a guaranteed alternate route or a visible token track; ordinary random drops may speed it up.

## 7. Anti-exploit and fairness rules

- No merchant buys a core for more than its posted purchase price in the same market cycle.
- A core bought from a shop is flagged as purchased for transaction accounting; reselling it pays no more than its purchase price minus the displayed service spread.
- Core rewards are granted once per valid kill/contract event; respawning an already looted body never duplicates a core.
- The player sees core quantity, rank, traits, recipe reservations and total sale amount before confirming.
- Bulk sale excludes favorites, reserved crafting components and quest-protected cores.
- No daily cap on ordinary hunting income. Caps turn a natural RPG activity into a quota; low base prices already keep the payout modest.
- Boss-core premiums are attached to the authored boss reward, not multiplied through generic rank value. A named boss can instead award a unique core used for a specific craft or story exchange.

## 8. Tuning checks

Review core prices against these anchors before expanding to later rings:

| Check | Target behavior |
|---|---|
| One ordinary Ring 0 kill | Core sale feels like a small bonus, not the main reward |
| One F contract | Contract reward remains clearly more valuable than selling its ordinary cores |
| One inn night | A handful of low-rank cores may help cover a basic night, but should not make sleeping free after one kill |
| Ring transition | New-rank cores help fund preparation without immediately buying every best-in-slot item |
| Optional craft | Spending a core has a visible opportunity cost, but the player can later hunt another |
| Repeated hunt | Profit remains modest and consistent; no sudden market collapse or infinite arbitrage |
| Named hunt | Unique story reward feels special because of function and narrative, not just a large cash number |

If F cores prove too valuable in a live slice, reduce only the F purchase value or the common material drop bundle; do not punish the whole economy with rank-wide inflation. If high-rank cores feel pointless to sell, first add a specialist request or recipe use before multiplying their prices.

## 9. Research notes

Capcom's official Monster Hunter manuals separate the market (buy/sell), smithy (forge/upgrade using both money and monster materials), and optional material exchange. Some upgrades accept a category or material-value budget rather than one exact drop. The useful lesson for Ascend is that monster parts can serve as crafting inputs with clear local services and alternative exchange routes; they do not have to be primarily cash. Ascend should preserve its own generic core identity and single-player economy. [Monster Hunter Generations official manual: town facilities](https://game.capcom.com/manual/MH_Gen/en-UK/page-142.html), [weapons, armor and material values](https://game.capcom.com/manual/MH_Gen/en/page-71.html), [Monster Hunter 4 Ultimate Wyporium material exchange](https://game.capcom.com/manual/MH4U/en/page-134.html)

## Related notes

- [[item_and_economy_design]] — wider economy rules and Ring 0 slice.
- [[systems]] — current economy and crafting draft.
- [[gear_systems_and_sets]] — equipment and awakening draft.
- [[monster_design_kit]] — loot-table and species-design rules.
- [[Canon]] — current canon and proposed locks.
