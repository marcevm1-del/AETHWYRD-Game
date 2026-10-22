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
- **Coins:** Copper → Silver (100c) → Gold (100s) → Platinum (100g) → **Mithril Coin** (100p).
- **Income:** quests, monster cores, loot, crafting, shops, trade routes, farm produce, arena bets, territory taxes.
- **Sinks:** repairs, enhancement, housing, taxes, tuition, respec, airship fares, festival goods.
- **Regional prices:** sell ice gems in the desert for profit, buy cheap spices in the Isles. A trade-route minigame.
- **Supply/demand (light):** flooding a market lowers prices for a while.

### 4.1 Prices by Rank
Every item has a rank, and its base price grows about **×4 per rank letter** (F 1× · E 4× · D 16× · C 64× · B 256× · A 1,024× · S 4,096×; SS/SSS are mostly unsellable relics). The −/+ sub-grades are ×0.7 / ×1.4. Monster cores are the economy's "ore": a guild buys every core at a fixed price for its rank, so there's always a floor income.

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

### 4.3 Trade Routes
Buy a **trade license** (rank D+) and register a route between two towns. Run it yourself (cart, escort, road events) or **hire a caravan** (paid, runs on its own, can be raided). Routes raise both towns' Wealth. Bandits and Tyrant raids can cut a route until you clear it.

### 4.4 Long-Game Balance (1,000 hours)
- **Rank-scaled sinks:** repair, enhancement and tuition costs grow with item rank, so gold stays meaningful at every stage.
- **Big aspirational buys:** home and territory upgrades, ranch expansions, mounts, Trophy Hall pieces, festival fireworks, town investments that raise Prosperity.
- **No gold for power at the top:** Relics and SS+ gear can't be bought, only earned.
- **Banking:** a guild account works across regions (no carry-weight for coins), and a vault holds valuables. No interest-farming.

## 5. Crafting & Life Skills
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

## 6. Housing → Territory (Slow-Life Pillar)
| Stage | Rank | Features |
|---|---|---|
| Inn room | F | Storage, bed (rest bonus) |
| Rented room in the guild house | C | Party base, crafting stations |
| **Home + land** (Brindlewick plot) | B | Farm, barn, garden, decorate, pets roam, companions live there |
| Manor / Shop | A | Hire NPC staff; your shop sells crafts while you adventure |
| **Village / Territory** | S | Recruit residents (rescued NPCs!), build structures, defense raids, festivals |
| **Free City Patronage** | SS+ | Become a city's Lord Protector (no crown, no guild ownership); diplomacy, defense |

- **Decorating:** free-placement furniture, trophies from bosses (mounted heads, displayed legendary weapons), paintings you made.
- **Residents** come from quests: refugees you saved, a goblin child, a retired knight, a fairy family.

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
| **Nemesis** | A Named monster that respects you can be named instead of killed. It becomes a full companion |
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
- Companions can be "downed" and revived; permanent companion death only in story moments.

## 11. Quality-of-Life
- **Journal:** quests, rumors, lore, bestiary, recipes, people met.
- **Rumor board:** in every tavern; hints toward secrets and Named monsters.
- **Map:** hand-drawn style; fills in as you explore; custom pins.
- **Photo mode:** with poses, filters, companions.
- **Accessibility:** subtitles, colorblind palettes, combat assist, remappable controls, difficulty sliders.
- **Steam:** achievements (150+), cloud saves, Steam Deck controls, rich presence ("Exploring Whisperwood · Rank D").

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
Every region has a **Tyrant**, its big bad (a named boss with a lair, lieutenants and dens). Until the Tyrant is slain, the region is **Besieged**. After that it's **Liberated** for good, and its quest board switches to normal monster-hunting contracts. The full build spec is in `13_Production/prompts/session_prompt_v0.11.md`.

| State | Settlements | Quest board | Music & look |
|---|---|---|---|
| **Besieged** | Attacked **1–2 times per 7-day week** (never two days in a row, usually at dusk, announced a day ahead) | Defence contracts, Besieged-only filler, Tyrant rumors | Tense themes; red smoke on the map |
| **Weakened** (optional) | Lieutenants or dens cleared, so attacks are smaller | Hunts for remaining lieutenants | — |
| **Liberated** | No more siege attacks; Stampedes and story raids can still happen | **Hunting contracts**: subjugation, bounties, Named hunts, gathering, escort | Liberation festival, brighter themes, green banners |

- **Escalation:** each week the Tyrant lives, its forces grow a step (capped). **Tyrants learn** (Big Upgrade §7): burn their troops every week and they send fire-proof shield-bearers.
- **Missed defences auto-resolve** using the town's Safety, guards and NPC adventurers. Losses cost Prosperity and can damage buildings, but **a settlement is never destroyed** (Loss Safety).
- **Prepare:** set traps, barricades and ballistae, hire guards, drill the militia (weekly board *Drill the Militia*), bring tamed partners and companions. Haulers carry materials.
- **Liberation:** a festival in the main settlement, +1 Prosperity stage, a one-week Liberation Market (§4.2), a Trophy Hall piece, an Adventurer Times headline, and the region's waystones turn green.
- **Ring 1:** the Brindlewick area's Tyrant is proposed to be the **Goblin Chief of Hollowpine** (Canon §6).

## Named Nemesis System
- A Named monster that **defeats you, or escapes you**, levels up, gains a scar/title, learns a counter to your favorite skill, and may **evolve** a rank.
- It **hunts you**: it shows up on the rumor board, ambushes you in its region, and sometimes follows you to other regions.
- **Resolve it any way:** kill it (relic-grade drop), tame it, or **name it** (Name-Giving Ribbon after earning its respect: win while sparing it, feed it, or save it from a bigger threat) → it becomes a **full companion** with its own voice, personality, arc and evolution.
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
