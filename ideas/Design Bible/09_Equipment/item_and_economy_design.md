# Item and Economy Design — Expansion Proposal

**Status:** design proposal; Canon.md remains authoritative. This document expands the existing gear and economy drafts into one player-facing promise and one production-ready design direction. It does not authorize multiplayer, monetization, or changes to locked canon.

## 1. The promise

Every item should answer at least one useful question: *What can I do with this? What does it tell me about this place? Who might need it? Is it worth carrying?* Every coin should connect to a choice the player understands. Every long chase should produce progress even before its final reward.

Ascend's economy should make a player feel like a newcomer learning how a living world works, then a trusted adventurer whose work changes local fortunes. It should not ask them to run a spreadsheet, repeat a dull activity, or pay a hidden tax to keep their existing build viable.

### Design pillars

1. **Useful discovery:** exploration finds gear, recipes, materials, local knowledge, services and people who can act on what was found.
2. **Readable choice:** show costs, effects, risks, rank limits and likely outcomes before commitment.
3. **Many viable routes:** fight, investigate, craft, trade, help a town or pursue a story; no single profession is mandatory.
4. **Identity over replacement:** gear expresses a playstyle and can stay relevant through upgrades; a higher number is not automatically better.
5. **Loss protection:** no ordinary failure permanently erases a unique item, rare material, companion investment or long-term progress.
6. **Local character:** settlements have different crafts, supply needs and trade customs because of ecology, history and culture.
7. **Small-team feasibility:** simulate the economy at useful decision points, not as a fully autonomous simulation of every object and shopkeeper.

## 2. Audit of the current draft

These are design risks to resolve before the draft is treated as a build specification.

| Existing idea | Risk | Recommended direction |
|---|---|---|
| Rank prices rise by roughly four times at each letter | One rank step can make routine supplies and repairs unaffordable; economic inflation becomes detached from player value | Rank governs access, threat and crafting eligibility. Prices use bounded local modifiers and a separate item-value curve |
| Guaranteed monster-core buy prices | Players may find one safe spawn and farm guaranteed money, flattening quest and crafting choices | Cores have a reliable base use and sell value, but finite regional demand, inventory limits and recipe demand prevent infinite perfect arbitrage |
| Five coin denominations through Mithril | Large purchases can become hard to read if every price is shown in copper | Keep copper, silver, gold, platinum and mithril as the world denominations; store exact value in copper and auto-format the largest denominations with change |
| Durability reduces stats to 50% at zero | A long trip or forgotten repair makes the character abruptly weaker and turns maintenance into a chore | Condition is cosmetic by default; optional difficulty can add modest, signposted effects. Gear never breaks or vanishes |
| Enhancement can downgrade levels above +10 | A player can lose an evening of progress through a random roll | Replace failure with a known material surcharge, a progress guarantee, or a temporary overheat/cooldown; no downgrade on the default ruleset |
| 0.5% relic drops and 50+ hour chases | A rare item can become mandatory-feeling or never appear in a very long save | Keep pure chance as a bonus route, while offering evidence, tokens, crafting or a guaranteed culmination route |
| Quality depends heavily on minigame performance | Input dexterity can become a build gate; players who dislike minigames may feel locked out | Minigames are optional; automation and accessibility assistance produce reliable standard quality. Skill improves efficiency, extra yield or cosmetic marks |
| Material rank controls item rank | One missing high-tier drop blocks craft access, while low-tier materials become dead weight | Rank is a recipe/access rule; alternative inputs and salvage let old materials remain useful |
| Every material should be useful | Too many item definitions create clutter, not meaningful utility | Give each material one primary use, one secondary sink and a clear sale/discard path; consolidate near-duplicates |
| Caravan raids and vulnerable cargo | Failure could erase hours of investment, contradicting Canon's loss rules | Show risk and insurance/recovery terms up front; default cargo is recoverable, and loss only affects time/fees/route reputation |
| Carry weight plus dying pack animals/porters | Several individually optional pressures compound into severe progress loss | Default inventory is comfortable, cargo recovery is guaranteed, and strict weight plus lethal companions are separate opt-in difficulty rules |
| Prosperity, siege, reputation, season, CHA and knowledge all affect price | Layered modifiers can make a price unpredictable or opaque | Show the final quote and each factor; cap combined modifiers; no hidden price rolls |
| Shops, farms, caravans and home shop all generate income | Passive income may trivialize quest rewards or force repetitive management | Give passive income a low-touch cap, weekly report and optional management; never require checking in daily |

## 3. Currency and price model

### 3.1 Everyday money

Use one clearly displayed wallet with copper, silver, gold, platinum and mithril denominations. Conversion is **100 copper = 1 silver; 100 silver = 1 gold; 100 gold = 1 platinum; 100 platinum = 1 mithril coin**. The player should see compact values (`2g 14s 8c`, `3p 2g`, or `1m 4p`) and a total in the chosen display style. Pickup and spending never require manual coin conversion. Copper remains the storage unit for item values, inns and other tuned prices.

Mithril coin is a high denomination of the same money, not a separate grind currency. Foreign coinage may appear as collectible or regional flavor; it is exchanged at a licensed moneychanger with rate and fee shown before confirming.

Monster cores remain **items**, not a parallel universal currency. Their uses are crafting, research, awakening and sale. A core's rank and origin explain its price. This preserves the sense that a core is a creature's remnant rather than a generic coin substitute. Quest-bound cores are protected from accidental sale.

### 3.2 Price equation

For ordinary items, use an authored reference value with bounded, visible adjustments:

`final price = reference value × local supply × local demand × service/reputation modifier × condition modifier`

Recommended total adjustment bounds for the first playable slice: **0.70× to 1.50×** reference value for ordinary commodities, excluding clearly labeled unique quest deals. This is a starting tuning range, not a canon number. Rank alone never multiplies all prices exponentially.

- **Reference value** is authored by item category, intended use, craft cost and expected reward budget.
- **Supply** responds to local stock and trade routes; the stock display tells the player whether a good is scarce, common or overstocked.
- **Demand** comes from a few broad local needs: food, medicine, building, defense, craft and luxury.
- **Service** covers shop skill, guild standing, a known artisan, a license or a quest favor.
- **Condition** applies only to used/salvaged goods, never to an item's combat performance by default.
- **Final quote** appears before the transaction; haggling cannot secretly worsen unrelated prices.

Do not calculate every combination from scratch for every NPC. Settlements use a small number of market profiles, a weekly supply update and a few story-state overrides. Named merchants can have authored exceptions. Prices should remain stable enough that a player can plan a purchase after a short trip.

### 3.3 Price communication

An item card should show: buy price; sell price; local trend (scarce / steady / abundant); required rank or license; weight if weight mode is active; binding/quest protection; main combat or crafting effect; upgrade compatibility; and source when known.

The transaction preview lists the final amount, relevant modifier and resulting wallet total. Selling a unique, quest-linked or equipped item requires a second explicit confirmation and explains the consequence. Bulk sell excludes favorites, equipped items, quest items and unique gear.

### 3.4 Haggling

Haggling is optional social play, not a required tax on every purchase. It can use dialogue, evidence, relationship, CHA and a limited daily/weekly merchant patience value. The player sees a proposed outcome and can accept the posted price at any point. Repeated failed offers end the conversation without hidden hostility unless the player explicitly chooses an insulting dialogue option.

The accessibility version is one clear choice: **Ask for a fairer price**. Players who do not want negotiation use the posted price. No timed button sequence is required.

## 4. A useful, legible item taxonomy

### 4.1 Player-facing families

- **Equipment:** weapons, armor, shields, foci and accessories.
- **Upgrade materials:** ore, hide, plant, wood, gem, monster parts, cores and regional catalysts.
- **Consumables:** recovery, resistance, status cures, tactical throwables, oils and utility tools.
- **Food and ingredients:** meals, preserved travel food, gifts, bait and crafting inputs.
- **Tools:** gathering, traversal, repair, surveying, fishing or profession equipment.
- **Trade goods:** regionally produced wares whose purpose is commerce, gifting or commissions.
- **Quest and key items:** protected evidence, seals, letters, tokens and objects with authored story use.
- **Collectibles and records:** journals, maps, lore fragments, recipes, trophies and memory-reel subjects.
- **Cosmetics:** outfits, dyes, ornaments, weapon appearances, emotes and camp decor; never sell power as cosmetic access.
- **Companion items:** keepsakes, optional gifts and companion equipment only where the companion system explicitly supports it.

Every item definition should name its family and tags, source and sinks. A generated item with no imaginable player decision is likely unnecessary.

### 4.2 Data fields to grow toward

The current `Data/Items/items.json` shape is intentionally small. A future schema revision should add fields in controlled groups rather than a large bag of optional strings:

| Group | Fields to consider | Why |
|---|---|---|
| Identity | `id`, `displayNameKey`, `descriptionKey`, `category`, `tags`, `iconId`, `modelId` | Stable references and localization-ready presentation |
| Economy | `baseValue`, `currencyId`, `buyable`, `sellable`, `bound`, `marketGroup`, `demandTags` | Pricing and safe transaction behavior |
| Inventory | `stackLimit`, `weight`, `volumeClass`, `questProtected`, `autoSortGroup` | Stacks, weight mode and inventory tools |
| Acquisition | `sourceTags`, `dropTableIds`, `questIds`, `regionIds`, `rankBand` | Show likely routes and validate references |
| Use | `useEffectIds`, `duration`, `cooldown`, `charges`, `consumedOnUse` | Consistent consumables and utility tools |
| Equipment | `slot`, `weaponProfileId`, `armorProfileId`, `statBlock`, `resistances`, `moveProfileId` | Data-driven combat identity |
| Progression | `upgradeFamilyId`, `recipeIds`, `salvageTableId`, `repairProfileId`, `socketProfileId` | Upgrades and recycling |
| Narrative | `loreEntryId`, `ownerNpcId`, `questFlag`, `uniqueGroupId` | Named items and story safety |
| Presentation | `rarity`, `colorId`, `soundCueId`, `pickupEffectId`, `comparisonGroup` | Consistent readable feedback |

Use IDs for relationships (`recipeId`, `lootTableId`) rather than duplicating free-form names. Validate that references resolve, values are nonnegative, stack limits are sensible, unique groups obey their acquisition rules and quest protection is consistent.

## 5. Gear as a playstyle, not a treadmill

### 5.1 Separate five dimensions

Do not collapse all of these into one color or rank:

1. **Guild rank:** what work the character is trusted to undertake.
2. **Item tier/material rank:** the craft challenge and intended content band.
3. **Rarity:** how authored, unusual or distinctive the item is.
4. **Quality:** how well this copy was made or preserved.
5. **Build identity:** the moves, properties and tradeoffs the item enables.

A Legendary low-rank keepsake can remain valuable for its unique utility without having endgame attack power. A Common weapon can be well-made. A high-tier material does not automatically make every recipe a good player choice.

### 5.2 Preserve beloved gear

Every major Ring transition should create a choice between a new item and improving a known item. Starter weapons can gain modest, explicit upgrade paths; signature drops have authored upgrade families. New loot should introduce a different move rhythm, element, utility, resistance profile or exploration interaction—not just a bigger number.

Upgrade preview states what changes, what stays and whether the result changes appearance. Upgrades should use named thresholds, not hidden random outcomes. If a later system includes chance, the player sees the odds, the guaranteed outcome on failure and a route to finish the upgrade.

### 5.3 Weapon and armor identity

Every weapon family should have a distinct cadence: reach, startup, recovery, guard interaction, aerial behavior, stagger profile and utility. Two swords may be different builds if one rewards counterattacks and the other rewards sustained pressure. Weapon descriptions should teach a practical distinction, not only advertise stats.

Armor expresses defense and approach: weight, poise, elemental protection, stealth/noise, recovery, casting interruption, traversal or ally support. Any penalty must be understandable and not nullify an entire class. Mobility should use a few readable bands rather than a hidden burden formula.

Armor set effects should support partial sets. Proposed default: a modest 2-piece identity bonus and a meaningful 4-piece bonus; 6-piece effects remain rare, optional or cosmetic. No endgame build should require wearing an unattractive full set. Transmog, dyes and visual loadouts should be available without stat loss.

### 5.4 Enhancement, sockets and enchanting

- Enhancement improves a known stat in small, predictable steps and has a visible cap.
- Sockets are scarce choices, not a second full gear tree. A player can remove or replace a gem with a known cost.
- Enchantments alter tactics or add a narrow interaction; they should not stack multiplicatively into mandatory damage formulas.
- Reforging rerolls only a clearly named bonus group, with a preview and lock option for one retained property.
- Awakening and evolution are authored milestones tied to use, story, research or a feat; progress is tracked openly.
- Failure never destroys a unique item. A workbench always explains whether an operation consumes the material and what the fallback is.

### 5.5 Chase items and relics

Relics can be aspirational and powerful, but the chase should make the player's story richer as it progresses. Each relic has:

- a **rumor discovery** (how the player learns the item exists);
- an **evidence trail** (journal, map, NPC account, bestiary clue or physical landmark);
- a **repeatable progress route** (tokens, materials, trials or a craft path);
- an **optional luck route** (rare drop can accelerate progress, never replace the only route);
- a **combat identity** (what it lets the player do differently);
- a **noncombat consequence** (visual recognition, lore, social response or collection display);
- a **completion guarantee** that does not require 0.5% luck.

Long relic lines may take many sessions, but each session should yield a clue, component, relationship moment or skill test. “50+ hours” is a content-duration ambition, not a minimum grind quota. The player can pause and return without hidden decay.

## 6. Crafting, repair and material circulation

### 6.1 Crafting loop

**Notice a need → learn or find a recipe → choose a source route → gather or buy ingredients → craft with or without the mini-game → inspect the result → use, gift, sell or salvage it.**

Each step should offer at least two routes over the full game: for example, hunt a creature for hide, buy a local hunter's stock, accept a commission, or use a substitute recipe at lower yield. This does not mean every F-rank item needs four sources; it means the game should avoid one random drop being the only gate to a central build.

### 6.2 Recipe discovery

Recipes come from explicit sources: profession trainers, shop stock, story rewards, journals, clan teachings, research tasks, monster observation, exploration, salvage, and optional experimentation. The crafting UI shows whether the player knows the exact recipe, has a hypothesis, or is missing a critical clue. Failed experimentation consumes only the limited, declared test ingredients; it does not consume unique or story items.

Old-world knowledge can offer a hint or a substitute process, but should not make a modern Earth occupation universally superior to Aetherian expertise. The player's new-world relationships and practice remain necessary for advanced results.

### 6.3 Craft quality and mini-games

The existing rhythm forging, stitching, mixing and cooking ideas remain optional. Mastery can shorten animations and unlock batch crafting. Accessibility modes can slow or simplify timing, add hold inputs, or auto-complete. The non-gameplay route gives standard quality at the listed material cost.

Skillful play may grant one of: a small chance at extra yield, a cosmetic crafter's mark, reduced waste on common inputs, or a bounded quality bump. It must not be the only way to obtain competitive gear. Quality never pushes an item into a rank that breaks encounter expectations.

### 6.4 Repair and condition

Default rule: ordinary wear is visual and story flavor; equipment performance does not degrade during normal play. Repairs are a town service and crafting option for role-play, appearance, or optional survival settings. A field repair kit may restore appearance/condition but should never be needed to avoid a mandatory damage penalty.

If a future difficulty adds wear effects, provide a warning well before the threshold, a simple repair route, and an option to turn the effect off. Repair cost scales with item tier and service, with a visible cap. Unique gear cannot be ruined.

### 6.5 Salvage and unwanted loot

Unwanted equipment may be sold, salvaged or gifted where supported. Salvage previews exact outputs. Common gear returns common materials; dismantling does not create profit greater than buying the same materials without a bounded recipe or skill investment. Salvage never returns a unique quest component that would duplicate a progression gate.

For materials, the design rule is **one primary sink + one alternate sink + sale/discard clarity**:

- primary: a recipe, repair, upgrade, research or story use;
- alternate: another recipe, commission, gift or regional demand;
- exit: sale value, storage or safe discard.

If a material has no primary use after content review, merge it into a broader category or make it an explicit collectible. Avoid “crafting dust” variants differing only by color.

## 7. Loot, rewards and inventory safety

### 7.1 Reward budgets

Every quest and encounter pays from a visible budget across XP, guild credit, coin, materials, gear, reputation and information. It need not award all categories every time. The design pass should compare expected reward with time, rank, risk and travel. Avoid paying the same action at full value through multiple overlapping systems unless the activity is intentionally a marquee event.

Guarantee core progression rewards from first-clear, contract, research or token exchange. Random drops add excitement and alternative pace. Luck affects only eligible bonus rolls and is capped; it does not control mandatory quest objects, rank trials or the final item in a relic chain.

### 7.2 Monster parts and ecology

Part-targeted hunts reward knowledge and choice: sever, harvest, soothe, capture, negotiate or kill where appropriate. For intelligent or community-dwelling monsters, the world makes the social consequence legible before the player acts. Players can choose a less harmful route when the contract allows it.

At easier settings, key parts should not be permanently lost because a player failed a precision break. A toggle or difficulty rule can make break-focused rewards more demanding for players who want that hunt mastery, while preserving a fallback route to essential materials. Horizon Forbidden West's Easy Loot option is a useful precedent for separating tactile part-removal mastery from accessibility and story progression. (See research notes below.)

### 7.3 Inventory, storage and weight

Comfortable inventory is the default. A strict weight mode is an opt-in difficulty choice, and should not be the only place where weight has meaning. Even in strict mode:

- quest and story items do not count toward encumbrance;
- the UI forecasts whether gathering the next item crosses a threshold;
- over-capacity has a graduated effect and never silently deletes loot;
- storage is available at stable hubs, with craft-from-storage only when explicitly unlocked;
- favorite, equipped, unique and quest items are excluded from quick-sell and quick-salvage;
- pack animals/porters follow Canon §5: on default rules they are knocked out and cargo is recoverable; any lethal-risk mode is opt-in;
- a lost cargo marker persists until recovery or an explicit, well-explained substitute resolution.

The item box, backpack, hauler companion and local storage should be alternative convenience tools, not four separate chores. Haulers create a field-preparation choice and companion scenes, not a requirement to bring a fragile NPC.

## 8. Settlement markets and economic identity

### 8.1 Give each shop a reason to exist

Use the cultural-grounding lesson from Horizon Forbidden West: vendors and their stock feel like part of local work and identity, not generic menus. A forge-town's smith may sell repairs, tool steel and heavy weapons; a frontier guild post may stock traps, antidotes and field kits; a river market may specialize in preserved food, rope and boat goods. This is a design inference from Guerrilla's description of culturally specific vendors and settlements; Ascend should author its own cultures rather than copy Horizon's tribes.

Each settlement gets a compact market profile:

- local specialties and shortages;
- one or two signature services;
- one source of export goods;
- one local need that player actions can improve;
- one visible link between Prosperity and people/stock/service;
- a market board or rumor that explains why a price or stock changed.

Liberation should reduce danger premiums and reopen routes over time, but not make every good universally cheap. Some rare reagents remain rare because of climate, expertise or stewardship.

### 8.2 Prosperity connection

Prosperity (Wealth, Safety, Morale/Faith and population) should cause visible economic effects with explanation. A safer route can restore a weekly caravan; a damaged bridge can reduce imported tools; a well-funded clinic may improve medicine stock; a festival can increase food and craft sales. Keep the effect at the settlement level and summarize the change in-world. Do not simulate individual household ledgers.

Player actions alter markets on a clear calendar: weekly board update, siege result, quest outcome, route reopening, seasonal harvest and major story flag. Ordinary monster kills should not cause immediate price whiplash.

## 9. Trade routes and merchant play

### 9.1 Routes as world choices

Trade routes are an optional mid/late-game profession. A route offers a known origin, destination, cargo class, travel duration, expected return, risk, required license and likely regional benefit. The player can:

1. **Invest** in route safety or a local repair.
2. **Escort** personally for an adventure contract.
3. **Hire** a caravan and receive a delayed report.
4. **Supply** a scarce good for a modest guaranteed reward.
5. **Decline** without penalty.

The risk preview names likely threats and the recovery/insurance rule. Default failure costs a fee, time and perhaps temporary route trust; the cargo is recoverable, replaced by insurance or converted into partial credit. Settlements are never destroyed. This aligns with Canon §5 and keeps merchant risk dramatic but fair.

### 9.2 Avoid passive-income exploit loops

- No infinite buy-low/sell-high loop with guaranteed profit at two adjacent towns.
- Shop stock and demand use broad categories and bounded weekly updates.
- A single route has a weekly payout cap and diminishing returns after repeated identical runs.
- Passive shop/farm/route earnings are summarized in a weekly letter and can be collected in town; no daily log-in reward or real-time clock.
- Automation is transparent; it does not run while the game is closed in a way that incurs fees or losses.
- Route upgrades primarily improve safety, supply and Prosperity; raw coin is one reward among several.

### 9.3 Player shop and commissions

The home-shop idea is valuable only if it supports fantasy and world connection. Keep it low-attention: choose a few product lines, set a safe price band, assign staff if unlocked, then receive a weekly sales summary with named customer anecdotes. The player can take commissions for unique rewards but should not be forced to restock dozens of SKUs.

No kingship or guild ownership is implied. A shop is an artisan's business; settlement restoration and patronage remain within existing canon.

## 10. Money sources and sinks

### Sources

- guild contracts and story milestones;
- monster materials and cores, with limits through local demand;
- exploration finds and caches;
- craft commissions and profession work;
- tournaments and festivals;
- optional trading and market supply;
- slow-life farming, cooking and home-shop sales;
- salvage and selling unwanted equipment;
- restitution, grants or emergency aid when a story loss leaves the player under-resourced.

### Sinks

- gear purchases, upgrades, gems and enchantments;
- consumables, antidotes, tools and travel services;
- inns, meals and optional comfort purchases;
- repairs only when the player chooses a condition-oriented mode;
- profession training, recipes and craft stations;
- optional home improvements and cosmetics;
- optional route licenses, safety improvements and trade fees;
- respec cost within Canon's free-to-level-10 and class-tier token rules;
- story donations, restoration bundles and charitable acts.

Every sink needs a meaningful benefit or choice. Avoid recurring taxes that can make the player lose access to a bed, companion or home. Canon's loss rules prohibit a long-term economic spiral; emergency recovery can be delivered through a guild advance, basic starter kit or accessible low-risk contract, with repayment optional or modest.

## 11. Pacing and economic safety

### 11.1 The 60-minute session test

After one ordinary hour, the player should usually have experienced at least two of: a new place or clue, a combat encounter, a level/skill/research gain, a useful item or material, a relationship/world response, progress toward a purchase or craft, or a relaxing town/camp moment. Do not require a full hour of farming just to restore the prior build.

### 11.2 Early-game guardrails

- Give the player a dependable weapon, basic protection, starter consumables and one useful craft recipe.
- Sell common cures and entry-level materials in the first safe hub at prices a short contract can cover.
- If the player sells a needed ingredient, provide another source or an affordable replacement.
- Teach item comparison using a real choice with visible tradeoffs.
- The first upgrade should be achievable through a nearby hunt or simple commission, not a rare random drop.
- Show a clear path from current gear to a next-step objective.

### 11.3 Anti-softlock recovery

If a player is low on money, consumables or usable equipment, provide a repeatable but low-pressure recovery contract, free basic rest in a safe story moment, cheap guild issue equipment, and a route to recover cargo. Recovery must not require abandoning the main story, deleting items or repeating a boss without information.

## 12. Ring 0 item/economy slice

The first playable slice should prove the loop with a small curated set, not hundreds of records.

### Scope

- 3 weapon choices: Guild Issue Sword, a slower heavy option, and a basic ranged/focus option when its combat input exists.
- 3 armor profiles: cloth, light and medium; heavy enters when poise/weight is tested.
- 2 accessories with distinct build effects, plus 1 cosmetic choice.
- 3 consumables: minor healing, antidote/thaw choice as appropriate, and one tactical throwable.
- 6–10 crafting materials with a known primary use, alternate use and sale value.
- 3–5 recipes: starter weapon improvement, simple armor repair/cosmetic maintenance, potion, bomb and food.
- 2 shop roles: guild quartermaster and Brannoc's forge; one local specialty.
- One contract that rewards a choice of coin, material bundle or reputation.
- One monster-part target with a forgiving fallback on the default difficulty.
- One town stock change after the Whisperwood liberation state, if the implemented world slice can show it.

### Acceptance questions

1. Can a new player tell why one weapon feels different within a few swings?
2. Can they reach a useful upgrade after one short contract and one exploration detour?
3. Can they sell or salvage clutter safely without losing a unique item?
4. Is each displayed price understandable and affordable through ordinary play?
5. Does a crafting minigame add delight without blocking the same output?
6. Does the town feel different because of stock, service and local craft—not merely a menu skin?
7. Can a low-resource player recover without repeating a long section?

## 13. Options to add later

| Option | Player value | Cost/risk | Recommendation |
|---|---|---|---|
| Monster-part harvesting with anatomy clues | Makes research and preparation tactile | Animation/loot complexity; precision accessibility risk | Prototype a few Ring 0–2 examples with an easy fallback |
| Appraisal and provenance | Items carry maker, owner and region histories | Data and writing workload | Use for named gear and relics, not every common drop |
| Clan artisan marks | Connects gear aesthetics to culture and reputation | Requires cultural review and art variants | Strong later addition; derive from existing clan data |
| Barter and in-kind exchange | Makes remote settlements feel distinct | Harder to communicate value | Use in authored quests and a few isolated markets, not as default trade |
| Public exchange board | Lets crafters and hunters fulfill requests | Can become a menu chore | Weekly, small set of authored/local requests |
| Offline auction house | None in a single-player game without online economy | Contradicts solo scope and introduces service burden | Do not add |
| Player-to-player trading | No role in current single-player design | Multiplayer, support and duplication/security scope | Do not add unless the product premise changes |
| Shared online marketplace | Requires accounts, servers and moderation | Contradicts single-player-only lock | Do not add |
| Online leaderboards | Could compare tournament times or collection milestones | Anti-cheat, privacy, backend upkeep | Optional future read-only service only; no economy rewards |
| Cloud saves | Convenience and backup | Platform integration and conflict handling | Consider only as a platform feature, not an economy system |
| Remote market prices from live players | Social novelty | Online dependency and price manipulation | Do not add |
| Rotating daily offers | Return hook | FOMO and live-ops burden; bad fit for long offline RPG | Do not add |
| Real-money currency / loot boxes | Monetization | Conflicts with buy-once premium and trust | Explicitly excluded |
| Online reference catalogue/wiki | Community knowledge sharing | Spoilers and moderation | A fan resource, never a required game service |

### Online scope decision

The game remains single-player. “Explore options online” means research and inspiration, not designing a live-service economy. The safest useful online-adjacent options are platform cloud saves, achievements, an opt-in leaderboard for skill-based tournament records, and a public data/guide ecosystem. None may gate quests, gear, saves or endings. No online-only currency, timed stock, PvP market, loot box or server-dependent save is recommended.

## 14. Research and lessons for Ascend

### Horizon Forbidden West — culturally grounded markets and readable part targeting

Guerrilla describes settlements as useful preparation hubs with vendors whose roles reflect local cultures: craft, weapons, potions and meals. Its machine-part upgrades connect observation and combat choices to specific resources, while merchants provide a fallback for selling valuables. The relevant lesson is that a material becomes memorable when the player can identify where it comes from, what action can harvest it and which local service can use it. Ascend inference: use this loop selectively and preserve alternate routes for accessibility and essential progression. [PlayStation Blog: An authentic world](https://blog.playstation.com/?p=356989)

Horizon Forbidden West also offered an Easy Loot setting so players who did not want to detach every component during combat could still obtain components after a kill; this was enabled by default on Story and Easy and configurable elsewhere. The lesson is not to copy its exact feature but to separate mastery rewards from mandatory progression. [PlayStation Blog: Accessibility features](https://blog.playstation.com/2022/02/10/accessibility-features-in-horizon-forbidden-west/)

### Avowed — upgrade identity and flexible build experimentation

Obsidian's Avowed materials describe upgrading unique weapons using resources discovered through exploration, flexibility to respec and deepen a preferred weapon playstyle, and a party camp that combines stash, equipment upgrades and companion downtime. Its guidance stresses maintaining favorite gear through incremental upgrades and making combat feedback visibly communicate whether gear suits the current challenge. Ascend inference: let a few beloved items grow across a region transition, provide one calm preparation hub, and make upgrade results apparent in animation, sound and UI. [Xbox Wire: Player choice in Avowed combat](https://news.xbox.com/en-us/2024/11/21/player-choice-avowed-approach-combat/?ver=3.7.1), [Xbox Wire: Avowed deep dive](https://news.xbox.com/en-us/2024/06/10/avowed-deep-dive-official-xbox-podcast/), [Xbox Wire: Avowed survival guide](https://news.xbox.com/en-us/2025/02/13/avowed-survival-guide-starting-tips/?ver=3.7.1)

### What not to infer

These games differ in structure, production scale and combat. Their developer accounts support lessons about readable systems and authored identity, not proof that Ascend needs every proposed mechanic. Every new system must pass the Ring 0 session test and fit the two-person production reality.

## 15. Proposed locks for Canon §6

1. **Economy readability:** use bounded, visible price modifiers and price previews; rank access does not cause exponential everyday inflation.
2. **Non-punitive gear upkeep:** default durability never reduces combat stats or destroys gear; maintenance pressure is opt-in and recoverable.
3. **Relic guarantees:** rare drops can accelerate an authored chase but are never the only route to essential or signature gear; no mandatory pure-RNG wall.
4. **Material usefulness:** every production material has a primary use, alternate sink and clear sale/storage path; consolidate dead variants.
5. **Cargo safety:** default pack/route failures preserve a recovery path; no ordinary system permanently deletes unique equipment, quest items or long-term investment.
6. **Offline-first economy:** no player marketplace, real-money currency, loot boxes, daily timers or online-gated rewards under the current single-player premium premise.

## 16. Production sequence

1. Lock the player-facing policy in Canon §6; leave tuning values proposed until the Ring 0 economy playtest.
2. Add item-family fields to schemas only when the first real consumer exists; avoid speculative schema sprawl.
3. Author value budgets for the Ring 0 contract, shop stock, three monsters and five recipes.
4. Build inventory safety: favorite/lock, protected quest item, compare, bulk-sell exclusions, storage and clear weight-mode UI.
5. Build two shop services, one craft station, one material trail, one salvage path and one local stock reaction.
6. Playtest a 60-minute session and record money earned/spent, number of menu actions, items left unused, upgrade time and recovery time after failure.
7. Expand by family and region only when the slice demonstrates a real choice. Generate no thousands of items just to fill an index.

## Related documents

- [[gear_systems_and_sets]] — current equipment catalog and upgrade draft.
- [[systems]] — economy, crafting, inventory, prosperity and loss rules.
- [[inns]] — rooms, meals, rest, tabs and town life.
- [[exploration_and_discovery]] — discovery routes and travel pacing.
- [[reactive_world_and_field_journal]] — local clues, rumors and visible consequences.
- [[Canon]] — settled facts and proposals requiring approval.
