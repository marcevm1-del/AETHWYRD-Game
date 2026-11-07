# 12c — Inns & Taverns

Every settlement has an inn, and every inn is a **social hub**: rest, food, rumors, music, cards, brawls, companions' late-night talks. Inns are where the cozy half of the game lives between adventures. Data: `Data/World/inns.json` (schema `inn`, checked by `npm run validate`).

For the broader town venue kit and tavern staging guide, see [[anime_town_places_and_taverns]].

> **Built (v0.11):** `Code/Ascend.Core/Inns.cs`: rest buffs per room (meal and bath add Well Rested; nights stack), regular status thresholds, and Marta's tab (never blocks). Numbers in `Data/World/world_tuning.json` → `inns`.

## 1. What Every Inn Offers
| Service | What it does |
|---|---|
| **Rooms** | Rest, save, skip time to dawn/dusk/any hour (Systems §11) |
| **Meals** | The house dish and drink give small buffs (Canon: cooking gives small stat boosts); regional cuisine everywhere |
| **Rumor board** | Hints toward secrets, Named monsters, Tyrants (Systems §11, HUD §21) |
| **Tavern stage** | Bards, concerts (Big Upgrade §50), Rosie-style trainers |
| **Tables** | Kaede's Cards, dice, arm-wrestling, drinking contests (juice options always) |
| **Eavesdropping** | Sit near other guests to overhear gossip (Big Upgrade §42) |
| **Stables** | Mounts and pack animals rest and recover; tamed partners sleep here when you have no home |
| **Locker** | A small storage chest per inn |
| **Mail drop** | Send and receive letters and parcels (Big Upgrade §52) |
| **Party hire** | Mercenaries and porters looking for work (Big Upgrade §35) |

## 2. Rooms & Rest
| Room | Price (Aldmere baseline) | Rest bonus |
|---|---|---|
| **Common room / hayloft** | ~20 copper | *Rested* for 2 hours of play: +5% XP, faster regen |
| **Private room** | ~1 silver (lore: a silver buys a night at an inn) | *Well Rested* for 4 hours: +10% XP, +regen, a dream chance |
| **Suite** | ~15 silver | *Well Rested* for 8 hours + a free meal |
| **Signature room** | Varies | Each inn's unique room with its own perk (§6) |
- **Prices scale** with the region's rank band and the town's Prosperity (Economy §4.2).
- **Rest stacks with comfort:** a good meal before bed adds +1 hour of Well Rested; a bath (Aldmere bath culture, invented by Kaede) adds another.
- **Dreams** (Big Upgrade §11): sleeping in a private room or better rolls for a Maelis dream, an Earth memory or a previous Hero's memory.

## 3. Becoming a Regular
Each inn tracks your **regular status**:
| Status | How | Perks |
|---|---|---|
| Stranger | First visit | Normal prices |
| Guest | 3 nights | The keeper greets you by name |
| Regular | 10 nights + a favor | −10% prices, your own mug on the wall, rumors told to you first |
| **Family** | 30 nights + the keeper's personal quest | Your room is kept for you, free meal on every rank-up, the keeper's secret (§6), a unique title (*Griffon Family*) |

## 4. The Tab (Marta's credit)
Marta Gruel feeds every rookie on credit and remembers every debt (Brindlewick). This becomes a light system:
- At **F–E rank**, you can eat and sleep at the Sleeping Griffon **on a tab** up to a limit. Other inns allow it once you're a Regular.
- Pay it off with coins, or **with work** (the weekly board's *Rush Hour at the Griffon*).
- Leave town with an open tab and Marta writes you letters, increasingly dramatic, never threatening. **It never blocks you from anything.**
- Paying off your first tab is a small story moment and raises Brindlewick Prosperity (Wealth).

## 5. Nightly Inn Events
Each evening at an inn rolls one event (more in festivals):
- A brawl (join, stop it, or bet on it)
- A bard duel
- A mysterious stranger (sometimes the **Hooded Traveler**; Canon: sleeping at an inn during a Twin Eclipse triggers him)
- **A confused new Veilborn** stumbles in, which can start a mentoring line (Big Upgrade §13)
- A rival party celebrates loudly
- A proposal, a birthday, a wake
- A monster attacks the stables
- A companion's late-night bar talk (bond scene; each companion has a favorite drink)
- **During a siege:** the inn becomes a refuge and field hospital: wounded defenders, frightened families, the keeper handing out stew. **After Liberation:** a free round for the whole town and a liberation night party.

## 6. Signature Inns
| Inn | Where | Keeper | House dish / drink | Signature room | Quirk |
|---|---|---|---|---|---|
| **The Sleeping Griffon** | Brindlewick (aldmere) | Marta Gruel | Marta's Rookie Stew / Griffon Gold (or honey milk) | *The Rookie Loft*: +10% XP for your first 7 days in Aethwyrd; the walls are carved with the names of every Veilborn who slept here first | Feeds every rookie on credit and remembers every debt |
| **The Crooked Lantern** | Greymoor Stilts (greymoor) | Mother Bramble (swamp witch) | Bog-eel Pie / Dreamwater Tea | *The Room That Moves*: Each night it opens onto a different hallway; one night it opens onto a hidden lore room | The building leans more every year; nobody admits it |
| **Leafhall Rest** | Sylvaran court city (sylvaran) | Thalion Veyraleth (elf) | Moonleaf Salad / Starbloom Wine | *Heartwood Bower*: Sleep inside a living tree: +Spirit regen and a Sylvara Devotion point once a week | Charges humans double until they earn elven reputation (the court-elf snobbery, Canon) |
| **The Thimble & Thistle** | Mossdeep (mossdeep) | Pipwick Burr (Thimblefolk) | One Blueberry (whole) / Dewdrop Cordial | *The Acorn Room*: Only reachable while shrunk; one crumb of bread feeds the whole party | You must drink a shrinking draught at the door |
| **The Anvil's Rest** | Khazdûr Gate (iron_hold) | Brunhild Coalbeard (dwarf) | Stone-oven Mutton / Deep Stout | *The Forge Room*: Heated by the forge below: +1 crafting quality on your next Blacksmithing job | Drinking contests every night; the record holder is 300 years old |
| **The Howling Hearth** | Fanghold (fanghold) | Grandma Ruka (wolfkin) | Fire-roasted Boar Haunch / Fermented Mare Milk | *The Pack Den*: Sleep in the shared fur-pile: +Bond with every companion present | No chairs; everyone eats on the floor and arm-wrestles for the last piece |
| **Ryokan Moon-on-Water** | Hoshizora City (hoshizora) | Okami Sayo | Seasonal Course / Plum Tea | *The Lantern Garden Suite*: Private hot spring: full HP/MP/SP, removes debuffs, a quiet companion scene | Guests wear the inn's robes; spirits check in after midnight |
| **The Ninth Tail Teahouse** | Fox Shrine Isle (kitsune_isles) | Lady Kuzunoha (spirit) | Fox-fire Tofu / Moonlit Sake (or tea) | *Contract Room*: Paid with a memory or a story, not coins. A binding contract (Canon: spirit contracts are magic) | Spirits run it; humans are guests. Breaking house rules breaks a contract |
| **The Wandering Dragon Inn** | Jade Crossroads (shen_lu) | Old Man Feng | Thousand-layer Noodles / Cloud-mist Tea | *The Quiet Room*: Meditation room: +cultivation progress overnight | Martial artists fight over tables; the inn charges for broken furniture in advance |
| **Cloud Gate Guesthouse** | Haneul capital (haneul) | Madam Seo | Fermented-pot Stew / Barley Tea | *The Warm Floor Room*: Heated stone floors: full climate comfort and +stamina for the next day | Shoes off at the door; the keeper remembers every guest's favorite side dish |
| **The Last Fire** | Frostveil hold (frostveil) | Skald Hrafna | Smoked Whale Broth / Honey Mead | *Hearthside Bench*: Sleep by the great fire: full cold comfort and a skald's story (lore) | The fire has never gone out in 600 years; letting it die is a crime |
| **The Oasis Caravanserai** | Oasis of Seven Wells (sunscar) | Saeed al-Najm | Date-and-lamb Tagine / Mint Tea | *The Star Roof*: Sleep under the stars: reveals a hidden desert ruin on your map once | Every trade route in the desert passes through; caravans arrive with news |
| **The Drowned Mermaid** | Port Goldmere (goldmere_coast) | "One-Eyed" Delphine | Kraken Fritters / Black Rum (or limewater) | *The Captain's Cabin*: A smuggler's trapdoor: leave town unseen (clears pursuit by bounty hunters) | Sea shanties every night; card sharks at every table |
| **The Whale's Belly** | Dunewhale town (dunewhale_drift) | Captain Ossa | Sand-shrimp Skewers / Cactus Water | *The Blowhole View*: Wake up somewhere new: the whale moved overnight, revealing a new map area | The whole inn sways; first-time guests get seasick (a short debuff) |
| **The Friendly Goblin** | Moraveil market town (moraveil) | Grukk the Younger (if spared twice) or Old Snaggle | Mystery Meat (it's fine) / Mushroom Brew | *The Peace Room*: Humans and monsters share a table: +monster-town reputation | Monster-run; humans welcome if they're polite. Weapons stay at the door |
| **The Deep Pint** | Labyrinth Floor 30 safe town (labyrinth_upper) | Dorgrim Underbrow (dwarf) | Cave-mushroom Hash / Glowmoss Ale | *Bunk 30*: Save point and Labyrinth checkpoint; restocks your belt | The only bar 30 floors down; prices are 3× and nobody complains |
| **The Lantern Wake** | Labyrinth Floor 40 ghost market (labyrinth_upper) | The Hostess (a ghost) | Memory Soup / Cold Tea | *The Quiet Bed*: Paid in candle stubs (itm_mat_candle_stub). You dream of the adventurers who died in the Labyrinth | All guests are ghosts except you |
| **The Imperial Grand Hotel** | Vharlen capital (vharlen) | Director Aurel Kass | Seven-course Imperial Dinner / Vintage of the Empire | *The Ambassador Suite*: Status symbol: +Renown with Imperium nobles; every wall has ears | Luxurious, cold and full of spies |
| **The Hour That Isn't** | Everdusk court (everdusk) | Mistress Thistledown (fey) | Fairy Feast / Dew of Never | *The Forever Room*: Paid with a name, a laugh or a color. One night here can pass as a week outside (the inn warns you, sometimes) | Fey hospitality: politeness is law, thanks are debts |
| **The Crimson Rest** | Nox Dominion border town (nox_dominion) | Madam Vessa (demon) | Ember Bread / Blood-orange Cordial | *The Neutral Room*: Sanctuary: no fighting allowed, even for the Overlord's soldiers | Demon civilians live ordinary lives here (Canon: consequences on every side) |

Every inn also has a **secret** (in the data file), found by becoming Family, by Appraisal, or by exploring its cellar. Examples: the Sleeping Griffon's Rookie Loft has all three previous Heroes' names carved in the wall, and the Imperial Grand Hotel's basement connects to the prison where the real Mina is held.

## 7. Inns and Other Systems
| System | How inns tie in |
|---|---|
| **Settlement Prosperity** | Stage 0: the inn is a burned shell or a refugee shelter. Stage 3: a new stage and stables. Stage 5: a grand inn with a bathhouse and rare traders |
| **Housing** | The F-rank "inn room" (Housing §6) is a Sleeping Griffon room. You keep a soft spot there for life |
| **Weekly board** | Inn quests: *Rush Hour at the Griffon*, *Arm-Wrestling Night*, *Dice with a Stranger*, *The Lost Cat (Again)* |
| **Legend system** | Bards in inns sing about your actual deeds; tavern rumors exaggerate them (Big Upgrade §6) |
| **Climate comfort** | Northern and desert inns fully restore comfort (Big Upgrade §48) |
| **Bounties** | Some inns hide you (the Drowned Mermaid's trapdoor); others sell you out |
| **Monster towns** | Monster-run inns (The Friendly Goblin) raise monster-town reputation |
| **Labyrinth** | Safe-floor inns are checkpoints (The Deep Pint on floor 30, The Lantern Wake on 40) |
| **Your home** | From A rank, your shop can be a **teahouse or tavern**: hire staff, set the menu from your recipes, and play a serving minigame when you visit |

## 8. Inn UI
- **Inn menu:** room choice with rest preview, the meal board with buffs, the rumor board, your tab and your regular status card.
- **Rest timeline:** a sundial slider to choose how long to sleep; it shows the weekday, moon phase and any siege warning before you confirm.
- **Regular status** appears as a stamp card (like a café loyalty card) with the inn's seal.
