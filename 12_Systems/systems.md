# 12 — Game Systems (v0.2)

## 1. The Status Window
A translucent blue holographic panel with soft chimes; it opens in a burst of runes.
```
╔════════════════════════════════════════════════╗
║  [Player]                Human · Transported   ║
║  RANK: C  (Card shows: F)   TITLE: Goblin Bane ║
║  CLASS: Blademaster Lv.34 · Sub: Cook Lv.12    ║
║  HP 2,140  MP 480  SP 720                      ║
║  STR 168 VIT 112 AGI 190 DEX 141               ║
║  INT 44  WIS 39  LUK 81  CHA 66                ║
║  UNIQUE: [Copy] 3/5 · Affinity: Wind, Light    ║
║  BLESSING: Kaelthas (Devotion 4)               ║
║  SKILLS ▸  TITLES ▸  BESTIARY ▸  JOURNAL ▸     ║
╚════════════════════════════════════════════════╝
```
- **System Voice** (optional voice-over): level-ups, skill evolutions, and world announcements: *"An individual has slain an Elder Dragon. World Recognition updated."*
- **Glitches** (story): the Voice occasionally stutters your old-world name.
- **Titles:** 200+ titles, each with a small passive. Equip 1 main title (shown to NPCs) + 3 passive titles.

## 2. Progression Tracks
| Track | Grows from |
|---|---|
| Level | XP from everything (combat, quests, discovery, crafting) |
| Rank | GP + requirements + trial |
| Class tier | Rank + class quest |
| Skills | Use (proficiency) |
| Unique Skill | Story milestones + feats |
| Titles | Achievements |
| Reputation | Faction actions |
| Devotion | Prayer + divine quests |
| Bonds | Companion time + choices |
| Home/Territory | Investment |
| Bestiary | Appraisal and kills (100% completion rewards) |

**Discovery XP:** finding vistas, ruins, lore and secrets gives meaningful XP. Exploration is a valid way to level.

## 3. Combat Feel
> Overview only. The full, numbered spec is **`12_Systems/combat.md`** (tuning values in `Data/Combat/combat_tuning.json`); it wins on any detail.

- **Third-person action:** light/heavy attack, dodge (i-frames), block/parry, jump, sprint, lock-on.
- **Skill palette:** 4 slots + Ultimate (6 at B, 8 at S); hold a trigger to open the second palette.
- **Companion commands:** a quick wheel (Focus, Defend, Heal, Hold, Union Skill).
- **Union Skills:** when you and a companion both have meter, trigger a cinematic combo.
- **Awakening / Limit Burst:** 100% meter → transformation (aura, hair glow, music swells).
- **Stagger/Break** on bosses; breakable parts.
- **Elemental world interactions:** fire burns grass, lightning chains through water, ice freezes rivers into bridges, wind spreads fire.
- **Difficulty modes:** Story / Adventurer / Veteran / Hardcore (permadeath).

## 4. Economy
- **Coins:** Copper → Silver (100c) → Gold (100s) → Platinum (100g) → **Mithril Coin** (100p). Each step is ×100; wallet and data store exact value in copper, while prices display the largest denominations plus change automatically. `Data/World/world_tuning.json` is the denomination source.
- **Income:** quests, monster cores, loot, crafting, shops, trade routes, farm produce, arena bets, territory taxes.
- **Sinks:** repairs, enhancement, housing, taxes, tuition, respec, airship fares, festival goods.
- **Regional prices:** sell ice gems in the desert for profit, buy cheap spices in the Isles. A trade-route minigame.
- **Supply/demand (light):** flooding a market lowers prices for a while.

### 4.1 Prices by Rank
The old ×4-per-rank-letter curve is an early draft, not a tuning rule. Guild rank controls access and trust; it does not exponentially inflate everyday prices. Prices use an authored copper reference value with bounded, visible local modifiers. Monster cores have a modest fixed Guild buyback price by rank, because ordinary monsters currently drop one reliably. See [[monster_core_pricing]] for the proposed copper table, specialist wanted notices, crafting role and anti-arbitrage rules; it remains a proposal until approved in `Canon.md` §6.

### 4.2 What Moves Prices
| Factor | Effect |
|---|---|
| **Settlement Prosperity** | Stage 0–1: few goods, high prices. Stage 4–5: rare traders, −10% prices |
| **Siege state** | Besieged: food and potions +25%, weapons scarce. Liberated: a one-week **Liberation Market** with rare goods |
| **Reputation** with the town or faction | Up to −15% buying, +15% selling |
| **Haggling** (CHA) | ±10% per deal (HUD §27) |
| **Season & festivals** | Seasonal goods appear; festival stalls sell exclusives |
| **Otherworld Knowledge** | An introduced idea creates new goods (soap, printed books) and can collapse an old trade (scribes) |
| **Blood Vesper** | Monster parts flood the market the next day, so prices drop |

### 4.2a Monster Cores
Monster cores are crafting materials with a sell value, not a universal currency. The Guild provides a reliable baseline buyer; recipes, research and awakening are their main long-term sinks. Trait-bearing cores are reserved for recipes that need them, rather than generated as sell-only variants. Full proposal and exact prices: [[monster_core_pricing]].

### 4.3 Trade Routes
Buy a **trade license** (rank D+) and register a route between two towns. Run it yourself (cart, escort, road events) or **hire a caravan** (paid, runs on its own, can be raided). Routes raise both towns' Wealth. Bandits and Tyrant raids can cut a route until you clear it.

### 4.4 Long-Game Balance (1,000 hours)
- **Rank-scaled sinks:** repair, enhancement and tuition costs grow with item rank, so gold stays meaningful at every stage.
- **Big aspirational buys:** home and territory upgrades, ranch expansions, mounts, Trophy Hall pieces, festival fireworks, town investments that raise Prosperity.
- **No gold for power at the top:** Relics and SS+ gear can't be bought, only earned.
- **Banking:** a guild account works across regions (no carry-weight for coins), and a vault holds valuables. No interest-farming.

## 5. Crafting & Life Skills
> Implementation (Wave B: quality tiers, life-skill ranks, 32 recipes, cooking buffs): `12_Systems/crafting.md`.

| Life Skill | Produces | Station |
|---|---|---|
| Blacksmithing | Metal weapons/armor | Forge |
| Leatherworking | Light armor, bags | Tannery |
| Tailoring | Cloth armor, cosmetics, dyes | Loom |
| Alchemy | Potions, bombs, transmutation | Alembic |
| Enchanting | Enchantments, scrolls | Enchanting table |
| Runecraft | Khazdûr runes | Rune anvil (Iron Hold) |
| Jewelcrafting | Rings, amulets, gems | Jeweler's bench |
| Cooking | Food buffs, permanent stat dishes | Kitchen/campfire |
| Brewing | Ales, spirits, potions-lite | Brewery |
| Farming | Crops, magic herbs, monster plants | Fields |
| Animal husbandry | Eggs, wool, milk, mounts | Barn |
| Mining / Logging / Herbalism | Raw materials | World nodes |
| Fishing | Fish, sea loot, legendary fish | Water |
| Engineering (Otherworld) | Gadgets, guns, golems, airships | Workshop |
| Painting / Music | Decor, buffs, hidden classes | Easel / instruments |

- **Quality:** Poor → Normal → Fine → Superior → Masterwork → **Legendary**.
- **Crafting minigames** (optional, skippable): forging rhythm, alchemy mixing, cooking timing. Better play gives better quality.
- **Recipe discovery:** experiment, buy, loot, learn from NPCs, or **recall from your old world**.

### 5.1 How a Craft Works
1. **Recipe** (known or experimental) + **materials**. Materials have a **rank** and a **quality**, and the result can't be higher than the best material's rank.
2. **Station**: home, town or a portable camp kit (Poor/Normal quality only). Better stations (upgraded with Prosperity or at home) add +1 quality chance.
3. **Minigame** (skippable after mastery): your score decides the quality tier. A **perfect** run has a small chance of a bonus trait.
4. **Crafter's Mark:** everything you make Fine or above carries **your name**. NPCs who buy or receive it mention it, and Masterwork+ items can be **named by you**.
- **Failure** never destroys rare materials. It gives Poor quality plus **insight**, a progress bar toward the next recipe discovery.

### 5.2 The Minigames
| Discipline | Minigame |
|---|---|
| Blacksmithing | Rhythm hammering + quench timing |
| Leatherworking | Cut along a pattern with even pressure |
| Tailoring | Line-tracing stitches; dye mixing |
| Alchemy | Color-mix wheel + heat control |
| Enchanting | Trace a glowing rune before it fades |
| Runecraft | Rune-word puzzle (combine runes in the right order) |
| Jewelcrafting | Rotate a gem to find its facets |
| Cooking | Timing ring + seasoning balance |
| Brewing | Fermentation over days (check back, adjust) |
| Farming | Soil, water and season planning (not timed) |
| Fishing | Tension reel |
| Engineering | Connect parts on a schematic grid |
| Painting / Music | Free painting with stamps / a rhythm game |

### 5.3 Life Ranks
Each life skill has its own **F → SSS life rank**, using the parallel tracks in `03_Rank_System/ranks.md`. Ranks come from a **masterwork commission** judged by a master NPC (Brannoc for Blacksmithing in Brindlewick, Torvald later, the dwarven Forge Council at S). A higher life rank unlocks recipes, stations and titles (*Masterwork Smith of Iron Hold*).

### 5.4 Commissions & Your Shop
- NPCs and companions **commission** items: a guard wants a better spear, a bride wants a ring. They pay well and remember who made it.
- From A rank, your **home shop** (Housing) sells what you craft while you adventure. Your reputation as a crafter sets prices.
- Some Legendary recipes need **ingredients from Tyrants, Named monsters and Elder Dragons**, so crafting rewards the whole game.

## 6. Housing → Territory (Slow-Life Pillar)
| Stage | Rank | Features |
|---|---|---|
| Inn room | F | Storage, bed (rest bonus). A room at the Sleeping Griffon (see `12_Systems/inns.md`) |
| Rented room in the guild house | C | Party base, crafting stations |
| **Home + land** (Brindlewick plot) | B | Farm, barn, garden, decorate, pets roam, companions live there |
| Manor / Shop | A | Hire NPC staff; your shop sells crafts while you adventure |
| **Village / Territory** | S | Recruit residents (rescued NPCs!), build structures, defense raids, festivals |
| **Free City Patronage** | SS+ | Become a city's Lord Protector (no crown, no guild ownership); diplomacy, defense |

- **Decorating:** free-placement furniture, trophies from bosses (mounted heads, displayed legendary weapons), paintings you made.
- **Residents** come from quests: refugees you saved, a goblin child, a retired knight, a fairy family.

### 6.1 Rooms & Features
| Feature | Unlock | Does |
|---|---|---|
| Bed | Inn room | Sleep (skip time), rest bonus, dreams |
| Storage chest | Inn room | Shared with every crafting station (crafting pulls from it) |
| Mailbox | Rented room | Letters, parcels, commissions |
| Kitchen | Rented room | Cooking, Party Stew Night at home |
| Workshop | Rented room | Crafting stations (upgrade one at a time) |
| Mirror of Vanity | Rented room | Change appearance (Character Creator §3.3) |
| Expedition board | Home + land | Send companions out |
| Guest rooms | Home + land | Companions live with you; each decorates their own room |
| Garden & fields | Home + land | Farming |
| Barn & ranch | Home + land | Animals and stored tamed monsters |
| **Trophy Hall** | Home + land | Trophies, old guild cards, Memory Reel photos |
| Shop front | Manor | Sells your crafts while you adventure |
| Watchtower & walls | Village | Defends your territory in sieges |

### 6.2 Comfort & Decorating
- Furniture has a **Comfort** value and a **style tag** (rustic, elven, dwarven, Isles, Earth-nostalgic…). A higher Comfort gives a longer rest bonus.
- A matching style set gives a small bonus (e.g. a full Isles tea room: +Spirit regen after resting).
- Companions **comment on your decorating** and have favorite styles. They'll sometimes move things around.

### 6.3 Visitors & Home Events
NPCs visit when bond and reputation are high: Brother Caspian brings bread (and looks a little too long at your Trophy Hall), mentees ask for advice, rivals show up to brag, and children play in the garden if you've adopted. Seasonal events happen at home too: a snowball fight at Starfire Eve, lanterns at Lantern Night.

### 6.4 Village / Territory (S rank)
- **Residents** come from quests (refugees, the goblin child, a retired knight, a fairy family). Each has a **job**: farmer, smith, guard, teacher, merchant, healer.
- **Buildings** need resources and residents with the right job. They raise your territory's Prosperity using the same stats as towns (Wealth, Safety, Faith/Morale, Population).
- **Your territory can be besieged** if its region has a living Tyrant. Defences use the same siege rules, and your residents fight beside you.
- **Festivals** at your village use your own decorations and residents.

### 6.5 Free City Patronage (SS+)
As **Lord Protector** (no crown, Canon), you set one **city policy** per season (trade fair, open gates to refugees, monster-town alliance, Academy funding). Each policy shifts that city's Prosperity and faction reputations. Your statue appears at Renowned stage.

## 7. Taming & Familiars
- **Tame:** weaken → offer the right food or item → CHA + skill check. Some need special quests.
- **Active partners:** **3 active monsters, always** (see Taming Roster below); the rest live on your **ranch**.
- **Familiars:** level, evolve, learn skills and gain names. Large ground monsters can be **ridden** (Canon: no flying mounts).
- **Name-Giving:** naming a strong monster with a *Name-Giving Ribbon* can trigger a special evolution.

### 7.1 The Taming Encounter
1. **Weaken** it (below 30% HP) without killing it. Stagger and Break count; overkill ruins the tame.
2. **Calm it down** (HUD §11): a **calm meter** and a **fear meter**. Snacks it likes, a crouched posture, a soft voice and not attacking raise calm. Sudden moves, allies fighting near it and the wrong food raise fear.
3. **Offer**: a CHA + Tamer-skill check, with bonuses for its favorite food, the right time of day, its region and your Menace-matched approach (cute monsters like gifts; menacing ones respect strength).
4. **Result:** tamed · flees (try again later, it remembers you) · enraged (fights harder) · **follows you secretly** (a rare event; it shows up at camp).

### 7.2 Partner Roles
Each partner has one **role** from its species and behavior: **Vanguard** (draws aggro), **Striker** (damage), **Support** (heal/buff), **Scout** (finds secrets, warns of ambushes), **Hauler** (carries cargo; replaces a pack animal), **Mount** (rideable). Roles shape their AI and the Union Skills they can join.

### 7.3 Growth
- **Level** with you (up to your level), **Bond 0–10**, and **evolution** at Bond 5 into one of 2–3 branches (element, habitat, or how you've used it).
- **Mochi and slime familiars** also absorb items to gain small skills (Big Upgrade §26).
- **Ranch breeding** passes on markings and variant traits (Big Upgrade §27).

### 7.4 Taming Interacts With…
| System | How |
|---|---|
| **Named monsters** | A Named monster that respects you can be named instead of killed. It becomes a companion (lighter tier) |
| **Sieges** | Tamed partners defend towns; Haulers carry barricade materials |
| **Karma / Thread** | Releasing partners back to the wild with care raises Thread; abandoning them lowers Karma |
| **Monster towns** | Tribes treat you better if your partners are happy (and worse if they're battle-scarred) |
| **Bestiary** | Taming fills the bestiary to Appraisal tier 3 at once |

## 8. Bonds & Romance
- Bond 0–10 with each companion. Raise it through camp talks, gifts, shared battles, choices they approve of, and personal quests.
- **Bond rewards:** Union Skills, new outfits, their ultimate class, and their ending epilogue.
- **Romance:** optional, available with the adult companions listed in `Canon.md` §4 (not Nyx, Mochi or Named-monster companions), for male and female player characters, no gender locks, no gameplay gating. A marriage ceremony is possible at your home.
- **Rivalries:** some NPCs have rival meters too (Kaito).

### 8.1 Bond Levels
| Bond | Unlocks |
|---|---|
| 1–2 | Basic banter, first personal request, they call you by name |
| 3 | First **Union Skill**, night-watch scenes (Big Upgrade §11) |
| 4 | Their backstory quest starts; they share a weekly request |
| 5 | **Outfit 2**, they defend you in arguments, new Union Skill tier |
| 6 | Their **Awakening transformation** (Big Upgrade §12) |
| 7 | Personal arc climax (choice-heavy; they can leave if you betray their values) |
| 8 | Romance confession possible (romanceable companions); otherwise a "sworn friend" oath |
| 9 | **Their ultimate class** quest |
| 10 | Max Union Skill, Triple Union possible, their full ending epilogue, Last Stand power bonus |

### 8.2 What Raises and Lowers Bond
- **Raises:** fighting together, camping, gifts they like (discovered by trying), approved choices, their requests, festivals together, saving them in combat, letters while apart.
- **Lowers:** choices against their values (each companion has 2–3 **core values**, e.g. Lyra: *protect the weak · keep promises*), gifts they hate, leaving them behind for long stretches, Mortal Bonds near-deaths you caused.
- Bond **never drops below a floor** once a milestone is reached (5 and 8), so one bad choice can't undo hundreds of hours. **Leaving** only happens at story choices that clearly warn you.

### 8.3 Romance Path
1. **Spark** (Bond 6+): special dialogue options marked ❤.
2. **Festival moment:** Festival of Blossoms, Lantern Night or Starfire Eve date scenes.
3. **Confession** (Bond 8): you or they confess. You can say no kindly and stay friends at full bond.
4. **Together:** a light jealousy reaction (Canon: light) if you spend lots of time with another romanceable companion, then a talk, never a breakup unless the story choice says so.
5. **Marriage** (after Act III): a ceremony at your home or in their hometown, a wedding Memory Reel, and a shared home bonus.
6. **Family:** adopt a child (Canon: adoption only), e.g. one of the Brindlewick orphans if your bond with them is high. The child has their own small story through school, festivals and their first guild card.

## 9. Karma & Morality
- Hidden −1000 to +1000.
- Affects: class unlocks (Paladin +, Necromancer −), unicorns, sentient weapons, NPC trust, guards, endings, the Demon Realm reception.
- **Not binary:** some "dark" acts are justified; the Church's "holy" acts can be monstrous.

### 9.1 Three Hidden Meters
| Meter | Measures | Seen by |
|---|---|---|
| **Karma** (−1000…+1000) | Cruelty vs mercy: killing surrendered foes, theft, saving lives, sparing monsters | Holy items, unicorns, guards, the Church, Paladin/Necromancer lines |
| **Renown** (0…10,000) | How famous you are, good or bad (the Legend log) | Everyone: crowds, bards, the Adventurer Times, bounty hunters |
| **Thread** (hidden until Act V) | Growth the System can't see: promises kept, bonds, slow life, healing towns (Big Upgrade §3) | Ezrath, the anti-System endings, the harvest |
Karma and Renown are separate: a famous villain and an unknown saint are both possible.

### 9.2 Gray Choices (examples)
- Burn a plague village to stop the spread, or risk the region? (Karma unchanged either way; townsfolk remember.)
- Report the goblin child scout to the guard, or hide it? (Mercy +Karma; guards' trust −.)
- Lie to a dying man about his son. (Karma +, Solenne's Devotion −: she hates lies.)
- Steal medicine from the Church for the orphanage. (Karma +, crime: bounty.)
Gods react differently: **Solenne** punishes lies, **Sylvara** punishes cruelty to beasts, **Vex** rewards clever crimes, **Morrowyn** cares about how you treat the dead.

### 9.3 Consequences
| Karma | World reaction |
|---|---|
| +700 and up | Unicorns approach, some holy relics wake, children run to you, guards wave you through |
| +300 … +700 | Discounts at temples, refugees trust you, Paladin quests |
| −300 … +300 | Normal |
| −300 … −700 | Guards watch you, some shops refuse you, bounty hunters appear sooner, Necromancer and Warlock-line quests |
| −700 and below | Demon Realm citizens greet you as kin, the System shifts toward its **Warden** personality, the Crimson Throne path opens fully |
- **Crimes** (theft, assault, murder) are separate from Karma: they create **bounties** (Big Upgrade §30) and a crime record per region, which can be paid off or cleared by quests.
- **Redemption** is always possible through divine quests, healing towns and the Devotion path.

## 10. Death & Difficulty
| Mode | Death penalty |
|---|---|
| Story | Respawn at waystone, no loss |
| Adventurer (default) | Drop 10% carried gold (recover it at your death spot), durability loss |
| Veteran | Lose 5% XP toward next level + item durability |
| Hardcore | Permadeath; your grave appears in the world for new characters to find |
- *Second Dawn* (Unique Skill) replaces death with a time rewind.
- **Companions** can be downed and revived. Permanent companion death happens through clearly signposted story choices, or in combat only with **Mortal Bonds** on (Canon §5).

### 10.1 After You Fall
- **The death screen** (HUD §19) shows what killed you, its rank and one tip, then lets you retry the encounter, return to a waystone, or change gear first.
- **Your dropped gold** waits at a glowing blue lantern where you fell. Die again before collecting it and only the newest pile stays. Monsters never pick it up, except **goblins**, who steal it and run to their camp (a mini-chase).
- **Named monsters do not grow from your deaths** (Canon §4d). What they get up to reaches you through the rumor board instead.

### 10.2 Custom Difficulty
Under any preset, sliders for: enemy damage, enemy HP, parry/dodge windows, aggro-token count (how many attack at once), loot amount, death penalty, and inventory weight. **The S-rank floor still applies**: S+ content ignores the easy settings (below). Changing difficulty is free at any time, except Hardcore, which is locked at creation. The preset numbers, slider ranges and accessibility bundles are in `12_Systems/difficulty_and_accessibility.md` (`Data/Player/difficulty.json`).

### 10.3 Hardcore Legacy
> Hardcore uses the **Death Game** presentation (`01_Core_Concept/borrowed_features.md` #26): the System announces that respawn is disabled. Free for everyone from the start.

A Hardcore character who dies becomes **part of history** for your next characters: a grave in the world with their gear, a journal, and a mention in the history books. This uses the same system as **the Next Summoning** (Big Upgrade §5).

## 11. Quality-of-Life
- **Journal:** quests, rumors, lore, bestiary, recipes, people met.
- **Rumor board:** in every tavern; hints toward secrets and Named monsters.
- **Map:** hand-drawn style; fills in as you explore; custom pins.
- **Photo mode:** with poses, filters, companions.
- **Accessibility:** subtitles, colorblind palettes, combat assist, remappable controls, difficulty sliders (full list: `hud_and_ui.md` §14).
- **Steam:** achievements (150+), cloud saves, Steam Deck controls, rich presence ("Exploring Whisperwood · Rank D").

### 11.1 Convenience
- **Crafting pulls from home storage** wherever you craft at home; **quick-stack** materials to storage from any waystone (after rank D).
- **Auto-loot** options: everything, materials only, or off. **Junk auto-sell** at any merchant with one button.
- **Wait / sleep** anywhere safe (camp, inn, home) to skip to dawn, dusk or a chosen hour.
- **Build loadouts** (gear + skills + partners), from rank C.
- **Track up to 3 quests**, and set a **custom waypoint** from the map that shows on the compass.
- **Bestiary on the go:** check a monster's known weakness from the pause menu mid-fight.
- **Return summary:** loading a save after a long break opens its journal entry (HUD §20) so you remember where you were.

### 11.2 Respecting Time
- Every timed or repeatable system (weekly board, sieges, expeditions, brewing) **waits for you**: nothing expires while the game is off, and the clock only runs while you play.
- Missed Day Specials come back next week; missed siege defences auto-resolve (never destroying anything).

### 11.3 Road travel times (wave 5 check, 2026-11-03)
Checks the 13 roads in `Data/World/physical_map.json` (`roads[]`, read only) against `Data/World/world_tuning.json`. **Everything below that is not in a data file is a proposal** (Canon §6 route), not a locked rule.

**What is tuned today.** `calendar.dayLengthRealMinutes` = 90 (Canon: tunable 60-120), 24 hours, dawn 6, night 20-6. So the clock runs **16 in-game minutes per real minute: 1 in-game hour = 3.75 real minutes**, daylight (6-20) = 52.5 real minutes, night = 37.5. One map unit is one kilometre (`world_map.md` §6). **No travel speed, slope penalty, mount speed or fast-travel rule is tuned anywhere** in `Data/` or the design docs. The only speed in the repo is "run speed 6.5 m/s" in `market_research_2026.md` A12. There are also no pacing targets for a road leg. Waystones exist (respawn, quick-stack) but no doc defines fast travel between them (only the Mapmaker class mentions "fast travel anywhere seen").

**Proposed speeds** (new `travel` block in `world_tuning.json`, not applied): walk 2.0 m/s, run 6.5 m/s (the A12 figure), cart 4.0 m/s, mount 10.0 m/s. **Proposed slope rule** (Tobler-like, normalised to 1.0 on flat): `factor = clamp(exp(-3.5*|g+0.05|) / exp(-0.175), 0.15, 1.2)` with g = rise/run (a gentle descent is slightly faster, steep either way slower). Carts additionally cap at **12% grade** (factor 0.3 beyond it); a trade route needs the whole road under 12%. Any road piece steeper than **35%** is not a road: it is treated as a **stair or lift** and left out of the times below.

**Proposed pacing targets.** On foot at run speed (how a player actually crosses a road): **<= 45 real min (12 in-game hours) per leg**; mounted (Rank D horse, `ranks.md`): **<= 40 real min**. A leg past 52 real min cannot be finished in one daylight stretch, and past 37.5 min it crosses night if started at dusk.

Times use the real polyline points (elevation per point), in real minutes of play; "game h" = real min / 3.75. Walk is shown to make the point: at kilometre scale a 2 m/s walk is unplayable (21-69 in-game hours), so walk speed is for towns and fields only.

| Road | Leg | km | Climb / descent (m) | Walk min | Run min (game h) | Cart min | Mount min | Fit |
|---|---|---|---|---|---|---|---|---|
| road_01 | Brindlewick - Aldmere | 12.9 | 101 / 112 | 108 | 33 (8.8) | 55 | 22 | Good: the F-rank road, one daylight stretch, 3 crossings |
| road_02 | Aldmere - Velmark ducal towns | 21.5 | 162 / 159 | 180 | 55 (14.8) | 92 | 36 | Long on foot (> 45), 7 river crossings |
| road_03 | Velmark - Lirian canal cities | 11.5 | 53 / 54 | 96 | 29 (7.8) | 49 | 19 | Good |
| road_04 | Aldmere - Karak Dun | 10.7 (7.7 road + 3.0 stair) | 318 / 79 road; stair +2,078 | 78 | 24 (6.4) | 43 | 16 | **Fails**: last 3.0 km climbs 2,078 m, 1.0 km of road over 12% |
| road_05 | Karak Dun - Cinderhole | 22.7 (20.5 road + 2.2 stair) | 638 / 1,366 road; stair -1,067 | 219 | 67 (17.9) | 154 | 44 | **Fails**: long and steep, 6.7 km over 12%, 4.2 km over 20% |
| road_06 | Cinderhole - Dragon Bone monasteries | 25.7 (25.0 road + 0.7 stair) | 1,028 / 1,215 road | 260 | 80 (21.3) | 189 | 52 | **Fails**: longest leg, 8.1 km over 12% |
| road_07 | Aldmere - Lothaniel | 15.5 | 142 / 86 | 131 | 40 (10.7) | 67 | 26 | Good |
| road_08 | Lothaniel - Ashira | 17.7 | 98 / 94 | 148 | 45 (12.1) | 75 | 30 | Good (at the edge) |
| road_09 | Lirian canal cities - Port Goldmere | 26.2 | 138 / 111 | 220 | 68 (18.0) | 111 | 44 | Too long, but flat: needs a waystone |
| road_10 | Thimblefolk - Oasis of Qadira | 15.8 | 107 / 72 | 133 | 41 (10.9) | 67 | 27 | Good |
| road_11 | Oasis of Qadira - Zaruma gold road | 19.5 | 47 / 113 | 161 | 50 (13.2) | 82 | 32 | Slightly long on foot (> 45), flat |
| road_12 | Oasis of Qadira - Zarvan | 25.0 (22.4 road + 2.6 stair) | 459 / 203 road; stair +1,985 | 201 | 62 (16.5) | 110 | 40 | **Fails**: long, and the last 2.6 km climbs 1,985 m |
| road_13 | Oasis of Qadira - Thalassa's Back | 10.1 | 8 / 296 | 79 | 24 (6.5) | 42 | 16 | Good (downhill, no crossings) |

Climb/descent is the sum of height steps along the polyline (the file's `climbM` is net, so smaller). Stair figures are the segments steeper than 35%.

**Flags**
1. **The four hairpin roads (04, 05, 06, 12) are not drivable as authored.** Road over 12%: road_04 1.0 km, road_05 6.7 km, road_06 8.1 km, road_12 1.5 km; over 20%: 0.7 / 4.2 / 2.2 / 0.7 km. They have 0-1 turns sharper than 90 degrees, so the switchback waypoints (world_upgrade_plan 2b) are not there yet and the grade is a straight line up the hill.
2. **Karak Dun (2,596 m) and Zarvan (2,583 m) sit on peaks.** road_04 and road_12 each end with a 2.6-3.0 km section gaining about 2,000 m. That matches the existing finding ("reached by road to within 2.5 km, then by their own stair or lift"). Climbing 2,000 m under 12% needs about 17 km of road, so a fully switchbacked road_04 would be about 25 km (not 10.7) and road_12 about 39 km. Better: lower the settlements (the 2b proposals) or keep them stair/lift towns and stop caravans at the foot.
3. **Cart trade routes (§4.3) cannot reach Karak Dun, Cinderhole, the monasteries or Zarvan** until grade is under 12% end to end. Mountain towns suit stairs and lifts in the lore; record it in `Data/` so route registration rejects them.
4. **Long legs.** Over 45 min on foot: roads 02, 05, 06, 09, 11. Over 40 mounted: 05, 06, 09 (road_12 is exactly 40). road_06 is 80 min on foot (21 in-game hours, longer than a night).
5. **Walk speed is unusable for roads** (78-260 min). Use walk only inside towns.
6. **Day/night.** Legs over 37.5 min cross night if started late, so an inn or camp (`inns.md`, "Wait / sleep anywhere safe") must be reachable mid-road. Legs under 30 min (03, 04, 13) fit inside one stretch with margin.

**Proposals (need the user's OK, then data)**
- Add `travel` to `world_tuning.json`: `{walkMps 2.0, runMps 6.5, cartMps 4.0, mountMps 10.0, slope {k 3.5, offset 0.05, minFactor 0.15, maxFactor 1.2}, cartMaxGrade 0.12, stairGrade 0.35, legTargetFootMin 45, legTargetMountMin 40}`. qa-tester: a test that fails when a road's run time exceeds `legTargetFootMin` without a waystone mid-road, and one that fails when a cart route crosses a segment over `cartMaxGrade`.
- **Waystones on the road:** one mid-road waystone on roads 02, 05, 06, 09, 11, 12 (19 km and over) so no leg between waystones passes 40 min on foot; fast travel only between attuned waystones (free, but not during a siege), the Mapmaker widens it. That keeps roads meaningful on the first trip and cheap on the tenth.
- **world-designer:** switchbacks for 04/05/06/12 (or lower / lift-serve Karak Dun and Zarvan), then rerun this table. **canon-keeper:** the speeds and the 45 / 40 min targets as a Canon §6 batch. Cart speed also feeds caravan pay and timing in §4.3.

## Combat Pillars
> Summary of the pillars detailed in `12_Systems/combat.md`.

1. **Fluid:** every attack can cancel into a dodge; skills cancel into skills (on a combo budget).
2. **Fast:** quick base speed, dash, air dash, launch → juggle → slam.
3. **Heavy:** hit-stop on impact, camera shake, enemies get knocked back, ground cracks, sound punches.
4. **Flashy:** elemental VFX trails, a short cinematic camera for ultimates, glowing magic circles, screen-wide explosions.
5. **Stylish:** a **Style Rank** meter (C → B → A → S → SS → SSS, fitting our rank theme!) rewards variety; higher style gives bonus XP and drops.
6. **Combinational:** weapon arts + spells + elemental reactions + companion Union Skills chain together.

---

## Difficulty: Player Choice + the S-Rank Floor
| Setting | F → A content | S → SSS content |
|---|---|---|
| Story | Gentle | **Brutal** |
| Adventurer | Balanced | **Brutal** |
| Veteran | Hard | **Brutal+** |
| Hardcore (permadeath) | Hard | **Nightmare** |
- **"Brutal"** = full enemy AI aggression, unique mechanics, unblockable combos, and boss enrage timers. Easy-mode assists (auto-dodge, damage reduction) **switch off** in S+ zones and fights.
- The game tells you this ahead of time: an in-world Guild warning at A-rank. *"Beyond this point, the world will not go easy on you."*

## Respec
| Level | Stat/skill reset |
|---|---|
| 1–10 | **Free**, unlimited (learning phase) |
| 11+ | **Tome of Forgetting** (rare drop or craft) + gold scaling with level + a 1-day cooldown |
| 100+ | Also requires a **Shrine of Ilvaris trial** |
- **One free respec token** at every class-tier change (Canon §5).
- **Partial respec:** reset only stats or only skills, for half the cost.
- **Preview first:** respec at a shrine shows your new build's numbers on the training dummy before you confirm.
- **Loadouts** (from rank C) store gear and skill bars, not stat points, so switching loadouts never needs a respec.
- Lore: the **Tome of Forgetting** is one of Ilvaris's tools. After Act V, using it shows a gold line from Ezrath: *"What she makes you forget, she keeps."*

## Taming Roster
- **3 active monsters max** (always), plus a **Ranch** for stored monsters (capacity grows with home upgrades).
- **Trade-up loop:** tame a low-rank partner → evolve it, or release it, or retire it to the ranch → tame higher-ranked ones as you climb.
- **Taming rank cap:** you can tame monsters up to **your rank +0** (Tamer line: +1).
- **Bond and evolution:** partners gain Bond; at Bond 5 they can evolve; at Bond 10 with a Name-Giving Ribbon they become **Named** (a full companion with a personality).
- **Monster Collector Codex:** tame one of every species for titles and relics (*Crown of the Beast God* Apex Relic).

## Settlement Prosperity
Every town/village has persistent stats:
| Stat | Raised by | Lowered by |
|---|---|---|
| **Wealth** | Quest rewards spent locally, trade routes, your investments | Raids, taxes, neglect |
| **Safety** | Clearing nearby dens, defending in Stampedes, hiring guards | Ignored threats, monster dens growing |
| **Faith/Morale** | Festivals, healing plagues, shrines restored | Disasters, cult activity |
| **Population** | Safety + Wealth over time; rescued refugees | Deaths, fleeing |

**Visual state stages** (the 3D town actually changes):
| Stage | What you see |
|---|---|
| 0 · Ruined | Burned houses, no NPCs |
| 1 · Struggling | Broken fences, boarded windows, beggars |
| 2 · Stable | Default |
| 3 · Thriving | Repaired roofs, new market stalls, children playing, music |
| 4 · Prosperous | New buildings, stone walls, a bigger guild branch, a festival plaza |
| 5 · Renowned | A statue of **you**, a new district, unique shops and rare traders |

Higher stages unlock better shops, quests, residents and trainers. Neglected towns can fall back.

## Regional Siege & Liberation
Every region has a **Tyrant**, its big bad (a named boss with a lair, lieutenants and dens). Until the Tyrant is slain, the region is **Besieged**. After that it's **Liberated** for good, and its quest board switches to normal monster-hunting contracts. **Built (v0.11):** data in `Data/World/regions.json` (Tyrant, faction, settlements, state) and `Data/World/siege_waves.json` (generated waves per region); rules in `Code/Ascend.Core/Siege.cs` (`RegionThreat`, `SiegeScheduler`, `SiegeAutoResolve`); tuning in `Data/World/world_tuning.json` → `siege`.

| State | Settlements | Quest board | Music & look |
|---|---|---|---|
| **Besieged** | Attacked **1–2 times per 7-day week** (never two days in a row, usually at dusk, announced a day ahead) | Defence contracts, Besieged-only filler, Tyrant rumors | Tense themes; red smoke on the map |
| **Weakened** (optional) | Lieutenants or dens cleared, so attacks are smaller | Hunts for remaining lieutenants | — |
| **Liberated** | No more siege attacks; Stampedes and story raids can still happen | **Hunting contracts**: subjugation, bounties, Named hunts, gathering, escort | Liberation festival, brighter themes, green banners |

- **Escalation:** each week the Tyrant lives, its forces grow a step (capped). **Tyrants learn** (Big Upgrade §7): burn their troops every week and they send fire-proof shield-bearers.
- **Missed defences auto-resolve** using the town's Safety, guards and NPC adventurers. Losses cost Prosperity and can damage buildings, but **a settlement is never destroyed** (Loss Safety).
- **Prepare:** set traps, barricades and ballistae, hire guards, drill the militia (weekly board *Drill the Militia*), bring tamed partners and companions. Haulers carry materials.
- **Liberation:** a festival in the main settlement, +1 Prosperity stage, a one-week Liberation Market (§4.2), a Trophy Hall piece, an Adventurer Times headline, and the region's waystones turn green.
- **Ring 1:** the **Goblin Chief of Hollowpine** is the Tyrant of **Whisperwood**; his raids hit Brindlewick and Millbrook. Killing him is also the F→E trial, so the first siege teaches the whole loop and ends with Act I. Aldmere itself has a higher-rank Tyrant (Ashgrave). Proposed in Canon §6.
- **Unit pools:** waves use the Tyrant's family living in the region and already shipped by its ring; where fewer than 3 such species exist, waves mix in other local species (`factionMixed`).

### Tyrant Roster (proposed, Canon §6)
| Region | Tyrant | Rank | Faction | Settlements attacked |
|---|---|---|---|---|
| Whisperwood (F–E, ring 1) | **Grukk, Goblin Chief of Hollowpine** | E+ | goblinoid | Brindlewick, Millbrook |
| Aldmere (F–C, ring 2) | **Ashgrave, the Oathless Baron** | C+ | undead | Ashby, Greyhollow Village, Royal Valley farms |
| Greymoor (D–C, ring 2) | **The Hollow Abbot, Choir of Silence** | C+ | undead | Greymoor stilt-village, the Walking Hut market |
| Lirian (D–B, ring 3) | **The Drowned Choir, Sirens of the Canals** | B | aquatic | Lirian canal cities |
| Mossdeep (D–C, ring 3) | **Mother Webcrawler, Terror of the Small** | C+ | insect (mixed) | Thimblefolk Mushroom Town |
| Sylvaran (D–B, ring 3) | **Mycelia, the Spore Lord** | B+ | plant (mixed) | Canopy City Lothaniel, Moonwell hamlets |
| Fanghold (D–B, ring 4) | **Varrick Kade, the Slaver Lord** | B+ | humanoid_enemy (mixed) | Fanghold, nomad yurt camps |
| Iron Hold (C–A, ring 4) | **Skarn, the Fire Giant Warlord** | A+ | orc_giant | Karak Dûn, Ashen Mines camps |
| Moraveil (C–S, ring 4) | **Grakkus, the Orc Disaster** | S- | orc_giant (mixed) | Moraveil goblin village, Moraveil market town |
| Strife Marches (C–B, ring 4) | **Diego Alvarez, Voice of the Choir of Chains** | B+ | humanoid_enemy | border baronies, mercenary forts |
| Velmark (C–B, ring 4) | **The Tithe Colossus, Hunger of the Foundation Stones** | B+ | construct | Velmark ducal towns |
| Frostveil (B–A, ring 5) | **Ymgrir, the Frost Sovereign** | S- | orc_giant | Skjaldheim, longhouse steads |
| Haneul (B–A, ring 5) | **Varos, Herald of the Red Gate** | A+ | demon (mixed) | Haneul gate-towns |
| Hoshizora (C–A, ring 5) | **Kurogane, the Oni Warlord** | A+ | yokai | Hoshizora City, Bamboo Sea villages |
| Kitsune Isles (C–A, ring 5) | **The Hollow Bride, Matriarch of the Long Necks** | A | yokai | Fox Shrine Isle, spirit inns |
| Shen-Lu (B–S, ring 5) | **Wuxiang, the Hunger Colossus** | S | yokai | sect foothill towns |
| Umbravel (C–B, ring 5) | **Vel'thara, the Web Queen** | B+ | insect | Umbravel |
| Whitewater Reach (A–S, ring 5) | **Ysgrath, the Ice-Jaw Leviathan** | S | aquatic | ice-fishing villages |
| Ashira Vale (B–B, ring 6) | **The Gentle Warden, Keeper of Ashira** | B+ | aberration (mixed) | Ashira |
| Dunewhale Drift (B–A, ring 6) | **Glassmaw, Worm of the Endless Dune** | A+ | sandborne | the town on Thalassa's back |
| Goldmere Coast (B–S, ring 6) | **Krakenmother Ys, Queen of the Wreck Tide** | S | aquatic | Port Goldmere, pirate stilt-towns |
| Hollow Sea (B–A, ring 6) | **Lumen-Eater, the Abyss Angler** | A+ | aquatic (mixed) | Hollow Sea boat-towns |
| Lumbaya (B–A, ring 6) | **The Nightmother, Queen of the Nightshifters** | A+ | aberration (mixed) | Lumbaya temple villages |
| Stormreach (B–S, ring 6) | **Raikaru, the Storm Roc** | S | avian | Stormreach cliff-towns |
| Sunscar (B–A, ring 6) | **The Colossus of Sunscar, Walker of the Dunes** | A+ | construct | Oasis of Qadira |
| True-Name Isles (B–A, ring 6) | **The Nameless Tide, a Serpent Without a Name** | A+ | aquatic | Naming Voyage harbor |
| Xochitl Mire (C–B, ring 6) | **Xibalbar, the Hydra of the Mire** | B+ | reptile | Xochitl river-cities |
| Zaruma (B–A, ring 6) | **Mansacor, the Gold-Eating Manticore** | A+ | chimera (mixed) | Zaruma gold-road towns |
| Zarvan (B–A, ring 6) | **Zahhar, King of the Divs** | A+ | orc_giant (mixed) | Zarvan garden cities |
| Apu Highlands (A–S, ring 7) | **Ukhu-Tal, Stone Giant of the First Making** | S | orc_giant (mixed) | terrace cities |
| Aurumdeep (A–A, ring 7) | **The Mad Magician of Aurumdeep, Sinker of Kingdoms** | A+ | undead (mixed) | Aurumdeep explorers' camp |
| Bastion (B–S, ring 7) | **Thrakka, Sabretooth Khan of the Steppe Horde** | S | beast (mixed) | Bastion outer ring |
| Cinderhole (A–A, ring 7) | **Cinderlord Vasque, the Smoke Mage** | A+ | humanoid_enemy (mixed) | Cinderhole |
| Dragon Spine (A–S, ring 7) | **Vyrmax, the Drake Lord** | S | draconic | dragon-bone monasteries |
| Everdusk (A–S, ring 7) | **The Briar King, Lord of the Winter Court** | S | plant (mixed) | Summer Court glades |
| Gearholm (B–A, ring 7) | **Cogmaw, the Gremlin Engine-King** | A | gremlin (mixed) | Gearholm Undercity |
| Heavenreach (A–S, ring 7) | **Aquilon, the Roc Sovereign** | S | avian | Heavenfolk eyries |
| Lustrine Shores (A–S, ring 7) | **Ilyanthe, the Moon Harvester** | S | vesperite | Lustrine glass beaches |
| Quaking Lands (S–S, ring 7) | **Quakeback, the Earthshaker Behemoth** | S+ | beast (mixed) | Stiller spring-towns |
| Vharlen (B–A, ring 7) | **Morvane, Vanguard of the Overlord** | A+ | demon (mixed) | Vharlen frontier legions |

**No siege:** Great Labyrinth (Floors 1-40) (dungeon band, not a region with settlements); Great Labyrinth (Floors 41-90) (dungeon band, not a region with settlements); Great Labyrinth (Floors 91-120) (dungeon band, not a region with settlements); Sky Archipelago (abandoned titan cities; zephiel is the act iv story boss); Nox Dominion (story region (acts v–vi)); Calamity Steppe (no settlements); The Maw (its calamity (the hive mother) is a world event, not a siege); Root of the World (underworld depths; no settlements); Vesper (post-game region).

## Named Monsters (revised 2026-10-23: patent design-around, Canon §4d)
> Replaces the old *Named Nemesis System*. Warner Bros.' Nemesis patent (reported to run to 2036) covers enemies that remember defeating the player, rise in rank and pursue personal vendettas. Ascend's named monsters are built to avoid that pattern. **Have an IP lawyer review before release.**
- **A hand-written roster.** Every Named monster is authored by us (`08_Bestiary/bestiary_lore.md`): name, look, temperament, haunts, story. None are generated, promoted or replaced procedurally.
- **No enemy hierarchy.** No captains, warchiefs, promotions, power struggles or forts changing hands between named enemies.
- **They grow with the world, not with your deaths.** A Named monster's level, evolution and habits change with **region state**: ecology cycles, siege escalation, liberation and story flags. Dying to one gives it nothing personal: no scar, no title, no taunt.
- **You hear about them.** The **rumor board** and the Adventurer Times report what a Named monster has been doing ("Old Ironhide trampled the Hensley turnips again"), so the world feels alive without the monster remembering you.
- **Resolve it any way:** kill it (relic-grade drop), tame it, or **name it** (Name-Giving Ribbon after earning its respect: win while sparing it, feed it, or save it from a bigger threat). A named monster becomes a companion on the lighter companion tier (Canon §6).
- Named monster companions count toward the companion roster.

## Inventory Model
| Difficulty | Base inventory |
|---|---|
| Story | Unlimited bag |
| Adventurer | Weight-limited, generous |
| Veteran / Hardcore | Strict weight; encumbrance slows you and drains stamina |

**Expansions:** backpacks (Satchel → Explorer's Pack → Bag of Holding) · **Item Box** (skill, Unique Skill or relic: weightless storage) · **pack animals** (mule, carry-lizard, giant tortoise, Fluffcap ram) that carry a lot but **can be attacked and killed**, dropping their cargo as a lootable pile monsters may steal · a hireable **Porter NPC** (who can also die).

## UI Style Guide
> Full HUD and UI spec (layouts, notifications, Status Window tabs, appraisal tiers, dialogue, accessibility, controller layout, the Lying Interface stages): **`12_Systems/hud_and_ui.md`**.

- The classic anime **System window**: translucent blue-glass panels, thin glowing borders, angled corners, small ornate filigree at the corners, crisp sans-serif text with a fantasy display font for headers.
- Pop-ups appear in a burst of runes, with soft chimes (*"Skill acquired!"*).
- Rank colors are consistent everywhere (F grey → SSS gold).
- HUD is minimal in exploration and expands in combat.

## Loss Safety (protecting a 1,000-hour investment)
Several systems can take things away from the player. These rules keep any single mistake from costing 100+ hours:
| System | Default settings | Only on Hardcore / Mortal Bonds |
|---|---|---|
| Companion combat death | Gravely wounded, back in a few days | Permanent death |
| Pack animals & hired porters | Knocked out; cargo dropped in a lootable pile that stays for 3 in-game days | Can die |
| Respec | Always possible: free before Lv 10, then a Tome of Forgetting + gold; **one free respec token** at every class-tier change | Same |
| Class change | Costly (Rebirth Sigil + trial), but character level and learned skills are never lost | Same |
| Story deaths | Only through a clearly signposted choice | Same |
| Character death | Respawn at a waystone (gold can be recovered from your death spot) | Hardcore: permadeath |
