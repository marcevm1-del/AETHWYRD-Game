# Gear, runes and enchanting (AETHWYRD)

Rules for sockets, Khazdûr runes, rune words, enchantment scrolls and modular weapon parts. Code: `Code/Ascend.Core/GearFittings.cs` and `Equipment.cs`. Data: `Data/Items/gear_rules.json` (schema `gear_rules.schema.json`), plus rune, scroll and part items in `items.json` and their recipes in `recipes.json`. Audit and decisions: `13_Production/gear_v6b_audit.md`. This finishes the equipment half of upgrade v6; the crafting half is `crafting.md`.

## Principles (Canon wins)
- **Nothing wears out and nothing breaks.** No durability, no repair, no random destruction, no gambling. A rune comes back to the bag when removed. A scroll replaces the old enchantment (the old one is gone, and the UI names it first with `WouldReplace`).
- **Small and additive.** Every bonus is a flat add. A single rune gives +2 ATK or +12 HP at most, a rune word +3 to +4, a scroll +2 to +3. The validator caps these. Nothing multiplies another bonus (`item_and_economy_design.md` 5.4).
- **Quality matters, luck does not.** A rune or scroll made at Fine, Superior or Masterwork scales by the Wave B `statMult`. Quality comes from the same deterministic crafting formula as everything else.
- **No new life skill.** Enchanting and Runecraft were already in `systems.md` §5; they now have stations and recipes.

## Sockets
`gear_rules.sockets`: Common 0, Uncommon 0, Rare 1, Epic 2, Legendary 3, Mythic 3, Divine 0 (Divine gear is story-bound and takes no fittings). A **Masterwork** copy gains one more socket. The cap is 3. This matches the rarity table in `09_Equipment/gear_systems_and_sets.md` (Rare 1 socket, Epic 2) and gives early players a way in: a Masterwork Common sword has one socket. Sockets hold runes only for now (gems and skill crystals are a Jeweler's job for a later wave).

Each piece of gear also has **one enchantment slot**.

A fitting belongs to the **item key** (`itemId` or `itemId@tier`). If you own two copies of the same key, they share it: only one is fitted. Refit freely.

## Runes (Runecraft, rune anvil)
Six runes, made at the **rune anvil** (Torvald Stonebeard's bench) from the `runecraft` recipes: Ember (+2 ATK, weapons), Tide (+2 MDEF, armour and accessories), Stone (+2 DEF, armour), Anvil (+12 HP, anything), Hearth (+2 MATK, weapons and accessories), Gale (+1% crit, weapons and accessories, rank E). Socketing and removing happen at the same anvil. Removal returns the same rune, quality intact, at no cost.

### Rune words
Runes side by side in socket order make a **rune word** (the Runecraft puzzle idea in `systems.md` §5.2: the order matters). Four words: Forge-Oath (Ember, Anvil: +3 ATK), Stonewatch (Stone, Anvil: +3 DEF, +10 HP), Stormfast (Gale, Tide: +1.5% crit, accessories) and Hearthfire (Hearth, Ember, Anvil: +4 MATK, +2 ATK). Only the longest matching word is active. Its bonus scales with the lowest-quality rune in it. A two-rune word needs two sockets, so words start at Epic or Masterwork-Rare gear (`gear_systems_and_sets.md` §8: "rune slots on Epic+; rune-words when combined"). The optional rune-word puzzle mini-game is a UI follow-up; the rules do not need it.

## Enchanting (Enchanting, enchanting table)
Five scrolls, made at the **enchanting table** (Fennick Reed's bench, next to the alembic): Emberbrand (weapon, +2 ATK, Fire), Wardweave (armour, +2 DEF and MDEF), Vitality (armour or accessory, +20 HP), Nightstep (armour or accessory, +2% crit, rank E), Stormthread (weapon, +3 MATK, Lightning, rank E). Scrolls are ordinary Wave B recipes, so they have quality tiers, attunement and life-rank gating. Applying a scroll to gear happens at the same table. `RemoveEnchant` strips it; the gear is untouched. An element on a weapon enchantment appears as `GearBonus.ApplyElement` for combat to read.

## Modular weapons (Blacksmithing, Leatherworking, forge)
Parts are items made by normal recipes: Scrap Blade and Iron Blade (forge), Pelt-Wrapped Hilt and Fang-Capped Hilt (tannery). At the **forge**, one blade plus one hilt assemble into a weapon (`GearAssembler`): Tempered Shortsword (F) or Ironwrought Longsword (rank E). The weapon's quality is the **average tier of the two parts, rounded down**, capped by your Blacksmithing rank and the station. Both parts are used, nothing is rolled, it always works, and it pays Blacksmithing XP like a recipe. Armour stays whole; only weapons are modular, to keep it simple.

## In play
`Equipment` takes optional `QualityRules` and a `GearFitter`. Slots may hold quality keys (`itm_fangblade@fine`). Stats are base × quality `statMult`, plus rune, rune-word and enchantment bonuses, summed over the loadout and rounded once per stat. Without the optional arguments it behaves exactly as before.

## Saves
`SaveGame.GearFittings` (null in old saves, filled by `SaveRules.Upgrade`) maps gear key to `{ runes[], enchant }`. `GearFitter.Load` drops unknown gear, runes and scrolls, and never throws. `GearFitter.Save` writes it back.

## Not built here
Gems and skill crystals, enhancement +1 to +15, reforging, awakening, evolution, extraction of enchantments, multiple enchantment slots, unstable or cursed enchantments, the rune-word puzzle mini-game, shop stock for the new items, and Unity wiring (`AscendData` loading `gear_rules.json`, a socketing screen, applying `ApplyElement`).

## Wave 2 set (items-designer, 2026-11-09)
Decided under delegated creative control; the user may overrule. Everything stays flat, small and under the validator caps.

| Rune | Rank | Fits | Bonus | Made from (rune anvil) |
|---|---|---|---|---|
| Spark | E | weapon, accessory | +3 MATK | Rune Plate, Stinger |
| Dusk | E | armour, accessory | +3 MDEF | Rune Plate, Shade Essence |
| Bastion | E | armour | +3 DEF | Rune Plate, 2 Crude Iron |
| Cinder | D | weapon | +4 ATK | Rune Plate, Brimstone, D Core |
| Warden | D | armour, accessory | +24 HP | Rune Plate, Labyrinth Bronze, D Core |

Rune words: **Cindersong** (Cinder, Spark: weapon, +3 ATK, +3 MATK), **Bastion-Vow** (Bastion, Warden: armour, +4 DEF, +20 HP), **Duskwalk** (Dusk, Gale: accessory, +2% crit, +2 MDEF).

Scrolls (enchanting table): **Rimebrand** (weapon, +2 ATK, Ice), **Ironhide** (armour, +3 DEF), **Lanternlight** (accessory, +3 MATK). Each new word and enchantment grants exactly one gear skill in `Data/Classes/rune_skills.json` (the validator requires it): Cindersong, Bastion Vow, Duskwalk, Rimebrand Cut, Ironhide Brace, Lantern Glow. These six skills were written by items-designer to keep the build valid; class-skill-designer should review their numbers.
