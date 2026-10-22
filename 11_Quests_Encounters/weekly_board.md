# 11b — The Weekly Board: Anime Daily Quests

Repeatable, slice-of-life adventurer work that gives every in-game day its own flavor. Data: `Data/Quests/weekly_board.json` (schema `weekly_quest`, checked by `npm run validate`). Baseline numbers are for Brindlewick (F–E); other regions reuse the same templates (see §4).

## 1. The Aetherian Week
7 days, each named for one of the Eight. **Ilvaris has no day**: the Church teaches that *"Fate keeps every day."* At 90 real minutes per in-game day, a week is about **10.5 hours of play**. (Secret: old ruins show a **nine-day** week; the scratched-out days belonged to Ilvaris and the Forgotten Ninth.)

| # | Day | God | Name | Board theme |
|---|---|---|---|---|
| 1 | **Solenday** | Solenne | Day of Oaths | Board refresh, bounties, guard work |
| 2 | **Maelsday** | Maelis | Day of Dreams | Mysteries, night blooms, fortunes |
| 3 | **Thorsday** | Thorgrim | Day of the Anvil | Forge orders, deliveries, ore and silk |
| 4 | **Sylvasday** | Sylvara | Day of the Green | Farms, herbs, slimes, taming |
| 5 | **Kaelsday** | Kaelthas | Day of the Banner | Training, sparring, rivals, militia |
| 6 | **Morrowsday** | Morrowyn | Day of the Lantern | Remembrance, rest, cozy party nights |
| 7 | **Vexday** | Vex | Day of the Coin | Market day, odd jobs, games of chance |

## 2. Board Rules
- **Dawn reset:** each morning the guild board shows that day's **Day Special** plus **3 dailies** drawn from that day's pool and the Any-day pool.
- **Day Special:** once per week, a bigger quest with a minigame or a story twist. Missing one is fine; it returns next week.
- **Dailies:** each can be done once on the days it is posted. Twists are rolled, so repeats feel different.
- **Weekly Commission:** Rodrick's weekly goal (finish any 7 board quests). Clearing all 7 Day Specials in one week earns the title *Seven Days of Errands*.
- **Time of day matters:** night quests only appear after dusk; festivals, Full Lumen and Blood Vesper can add twists.
- **Rank-up pacing:** board quests give modest GP, so they support rank-ups but never replace trials or main contracts.

## 3. Sieges and the Board
- **While the region is Besieged:** on an attack day the defence is posted as the top contract (attack at dusk); the day's other quests stay available. Besieged-only filler (e.g. *Goblin Cull*) appears.
- **Once Liberated:** Besieged-only quests disappear, and **hunting contracts** (e.g. *Open Hunting Contract*) take their place. The rest of the weekly board continues as normal.

## 4. Using the Templates in Other Regions
Every quest is a template: the **trope**, structure and twists stay; the giver, targets and rewards are swapped for the local NPC, same-role local species (swarm, pack, elite) and the region's rank band. A coastal town's *Slime Patrol* becomes a crab patrol; an Iron Hold *Forge Rush* uses dwarven steel.

## 5. The Week in Brindlewick

### Solenday
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| special | **Fresh Posters** | The new week's wanted posters | guild_clerk_wendel | morning | 150g · 320 XP · 12 GP |
| daily | **Gate Watch** | Rookie guard duty | guard_tomlin | night | 45g · 110 XP · 4 GP |
| daily | **Witness to an Oath** | Formal ceremony, nervous rookie | sister_pell | day | 30g · 80 XP · 3 GP |
| daily | **The First-Day Cart** | Merchant escort, bandit ambush | traveling_merchant_pell | morning | 60g · 140 XP · 5 GP |

### Maelsday
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| special | **The Fortune Is Always Bad** | Ominous fortune that comes true (sort of) | eolande_fairweather | dusk | 90g · 220 XP · 6 GP |
| daily | **Moonbloom Picking** | Night-only rare herb | fennick_reed | night | 40g · 100 XP · 3 GP |
| daily | **The Lost Cat (Again)** | Find the lost cat | marta_gruel | day | 20g · 60 XP · 2 GP |
| daily | **Bad Dreams at the Orphanage** | Kids' ghost story turns real | tamsin_orphan | night | 25g · 90 XP · 3 GP |

### Thorsday
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| special | **Forge Rush** | Crafting minigame with a grumpy master | brannoc_emberfist | day | 80g · 150 XP · 4 GP |
| daily | **Scrap Run** | Looting goblin junk piles | torvald_stonebeard | day | 50g · 130 XP · 4 GP |
| daily | **Hot Bread Delivery** | Timed delivery across town | hugo_brand | morning | 30g · 70 XP · 2 GP |
| daily | **Silk for a Dress** | Spider silk for the tailor | ines_valbuena | dusk | 55g · 140 XP · 4 GP |

### Sylvasday
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| special | **Mandrake Harvest** | Screaming plant, earmuffs required | fennick_reed | morning | 90g · 200 XP · 5 GP |
| daily | **Slime Patrol** | The classic F-rank slime quest | farmer_odo | day | 30g · 90 XP · 3 GP |
| daily | **Fix the Fence** | Farm chores between fights | farmer_hesk | morning | 30g · 80 XP · 2 GP |
| daily | **Granny's Taming Lesson** | Tamer lesson with a stubborn critter | granny_mabel | day | 25g · 100 XP · 3 GP |
| daily | **A Basket of Mushrooms** | Which mushroom is the monster? | marta_gruel | day | 35g · 90 XP · 3 GP |

### Kaelsday
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| special | **Race the Crimson Wolves** | Rival party competition | dax_rowan | morning | 120g · 280 XP · 8 GP |
| daily | **Morning Sparring** | Training montage with the old master | old_hollis | morning | 0g · 160 XP · 2 GP |
| daily | **Drill the Militia** | Training nervous villagers | captain_holt | day | 40g · 120 XP · 4 GP |
| daily | **Arm-Wrestling Night** | Tavern strength contest | brutus_kale | night | 50g · 60 XP · 1 GP |

### Morrowsday
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| special | **Lantern Vigil** | Quiet night at the graveyard, ghosts with unfinished business | widow_aster | night | 70g · 200 XP · 5 GP |
| daily | **Babysitting Day** | Adventurer vs. small children | brother_caspian | day | 15g · 80 XP · 2 GP |
| daily | **Party Stew Night** | Cozy campfire meal with the party | lyra_brightwood | dusk | 0g · 60 XP · 0 GP |
| daily | **Tidy the Graves** | Humble chore, hidden lore | sister_pell | morning | 15g · 70 XP · 2 GP |

### Vexday
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| special | **Market Day Mayhem** | Market-stall part-time job | gilda_marsh | day | 140g · 180 XP · 5 GP |
| daily | **Dice with a Stranger** | Gambling with a suspicious lucky stranger | traveling_merchant_pell | night | 60g · 50 XP · 0 GP |
| daily | **Busking with Corwin** | Street performance rhythm game | fiddler_corwin | dusk | 40g · 70 XP · 1 GP |
| daily | **Old Sal's Fishing Contest** | Fishing contest, legendary fish | old_sal | morning | 35g · 60 XP · 1 GP |

### Any day (filler)
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| daily (besieged) | **Goblin Cull** | Standard goblin extermination | mina_feathersby | any | 50g · 140 XP · 4 GP |
| daily | **Herb Run** | The F-rank herb gathering quest | mina_feathersby | day | 25g · 70 XP · 2 GP |
| daily | **Sewer Duty** | The sewer job nobody wants | guild_clerk_wendel | any | 40g · 110 XP · 3 GP |
| daily | **Wolves on the Road** | Pack hunt on the trade road | wren_ashbourne | dusk | 55g · 150 XP · 4 GP |
| daily (liberated) | **Open Hunting Contract** | Normal monster hunting after liberation | mina_feathersby | any | 60g · 150 XP · 4 GP |
| daily | **Rush Hour at the Griffon** | Part-time job at the inn | marta_gruel | dusk | 45g · 80 XP · 1 GP |

### Weekly
| Slot | Quest | Trope | Giver | When | Reward |
|---|---|---|---|---|---|
| weekly | **The Guild's Weekly Commission** | Weekly guild point target | rodrick_hale | any | 200g · 400 XP · 15 GP |
