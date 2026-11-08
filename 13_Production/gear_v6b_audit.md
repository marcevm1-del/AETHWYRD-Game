# Gear v6b audit: runes, enchanting, modular equipment

Source: the equipment half of `upgrade v6` (Section 4 modular equipment, Section 5 enchanting). Wave B built the crafting half (`crafting_v6_audit.md`) and explicitly left this out. This is part 2, step 1. Docs: `12_Systems/gear_and_runes.md`.

## What v6 asks and what was built

| v6 item | Decision |
|---|---|
| Modular weapons: blade, handle, guard, pommel, material, rune slot | **Built, simplified.** Blade + hilt only (weapons only); quality is the average of the two parts. Guard and pommel are visual, material is already the recipe input |
| Armour components, material substitution, visual variation, engravings, gems, cosmetics, sets | **Not built** (cosmetics and sets are separate; gems belong to the Jeweler) |
| Runes | **Built.** Six runes from the canonical Runecraft skill, a rune anvil station, and rune words (ordered) |
| Rune slot | **Built** as sockets by rarity (matches `gear_systems_and_sets.md`) plus one at Masterwork |
| Enchanting categories (elemental, defensive, offensive, utility, resource, movement, crit, resistance) | **Built** as five scrolls: elemental/offensive (Emberbrand, Stormthread), defensive (Wardweave), utility/survivability (Vitality), crit (Nightstep). Resource and movement bonuses are not built |
| Multiple enchantment slots | **Not built** (one slot, per the brief) |
| Enchantment rarity | **Quality tier** takes that role (Wave B ladder) |
| Rune combinations (Fire + Strength etc.) | **Built** as ordered rune words |
| Enchantment extraction | **Not built**; `RemoveEnchant` strips it without a refund |
| Enchantment replacement | **Built**, with a preview of what would be replaced |
| Compatibility restrictions | **Built** (`fits`: weapon, armor, accessory) |
| Magical instability, legendary discoveries | **Rejected / deferred.** Instability is random loss, which Canon Slow-Life forbids |
| Enchanter profession, enchantment tester | Enchanting skill and table built; a tester UI is a UI follow-up |

## Canon checks
- `Canon.md` Slow-Life rows and §5 loss rules: no durability, repair, decay, random destruction or gambling. The validator rejects keys named durability, repair, decay, break, destroy or fail in `gear_rules.json`.
- `item_and_economy_design.md` 5.4: sockets are scarce, enchantments narrow, no multiplicative stacking, no chance. Followed.
- `systems.md` §5 life skills: Enchanting and Runecraft stay canonical ids. They moved from "deferred" to "craft".
- Locked Canon rows are untouched. The two new stations belong to existing NPCs: the rune anvil to Torvald Stonebeard (a dwarf smith), the enchanting table to Fennick Reed (the alchemist). Both are in the decisions list below.

## Build summary
- New: `GearFittings.cs` (rules, `GearFitter`, `GearAssembler`), `gear_rules.json`, `gear_rules.schema.json`, 6 rune, 5 scroll, 4 part and 2 weapon items, 15 recipes, 2 stations (`rune_anvil`, `enchanting_table`), `GearTests.cs` (14 tests).
- Changed: `Equipment.cs` (quality keys, optional quality and fitter), `Player.cs` (`GearBonus.ApplyElement`), `SaveGame.cs` (`GearFittings`), `Data.cs` (`GameDatabase.Gear`), item schema categories (`rune`, `scroll`, `part`), station lists, validator, `RealCraftingTests` (recipe count is now a minimum).
- Old saves: `GearFittings` is null in old saves, `Upgrade` fills it, a test loads a save without it.

## Decisions (made under delegated creative control, the user may overrule)
1. Rune anvil station is Torvald Stonebeard's bench, enchanting table is Fennick Reed's bench. A real Iron Hold rune anvil can replace the owner later by editing `recipes.json` `stations`.
2. Sockets follow the rarity table, plus one on Masterwork, capped at 3. Divine gear takes no fittings.
3. Fittings belong to the item key; copies of one key share them.
4. A scroll replaces the old enchantment (no extraction, no refund). The old enchantment cannot be recovered.
5. A rune word's bonus scales with its lowest-quality rune; only the longest matching word is active.
6. Assembly quality is the average of the two part tiers (rounded down), capped by rank and station. Deterministic.
7. Only weapons are modular.
8. Stat caps in the validator: 6 per attack/defence stat, 40 HP, 3% crit per source (1.5x for words and scrolls).

## Skipped and why
Gems, enhancement, reforging, awakening, evolution, extraction, multi-slot enchanting, cursed or unstable enchantments (Canon), cosmetic customisation, the rune-word puzzle UI, shop stock, and all Unity wiring (this part never touches `Game/`).
