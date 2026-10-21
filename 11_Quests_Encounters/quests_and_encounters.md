# 11 — Quests & Encounters (v0.2)

## 1. Quest Sources
| Source | Volume (full game) | Notes |
|---|---|---|
| Main Story (6 Acts + prologues) | 70–90 | Branching by Origin and choices |
| Guild Board contracts | 200+ templates | Procedurally varied (target, location, twist) |
| Faction chains | 12 factions × 8–15 | Reputation rewards |
| Companion arcs | 12 × 5–8 | Bond-gated |
| Class quests | ~90 (every class change) | Required for promotion |
| NPC side quests | 250+ | Handwritten, many funny or emotional |
| Hidden quests | 60+ | Odd triggers |
| Divine quests | 8 gods × 5 | Devotion |
| Legendary hunts | 30+ | Named monsters, Elder Dragons |
| World events | 15 types | Dynamic |

## 2. Guild Contract Types
| Type | Goal | Twist pool (random) |
|---|---|---|
| **Subjugation** | Kill X | An Elite appears · the targets are protecting young · a rival party is already there |
| **Gathering** | Collect | Rare variant spawns · the herb is guarded · night-only bloom |
| **Escort** | Protect NPC | Client is lying · ambush · client is secretly a noble/monster |
| **Delivery** | Transport | Time limit · fragile · the package is alive |
| **Investigation** | Clues, interviews | Culprit is a monster · culprit is the client · a cult connection |
| **Exploration** | Map an area | Discover a ruin · get lost in a fairy ring |
| **Defense** | Hold position | Waves · sabotage from inside · boss wave |
| **Capture/Tame** | Bring alive | Mother follows · it bonds to you instead |
| **Bounty** | Named target | The target has a sympathetic story · it offers a deal |
| **Dungeon Clear** | Reach the core | Core is intelligent · the dungeon offers you a contract |
| **Odd Jobs** | Non-combat | Babysit, sewer cleaning, cooking judge, model for a painter, find a lost cat (it's Whiskers) |

## 3. Requirement & Reward Schema (data file)
```yaml
quest_id: GLD_C_0147
title: "The Silver Wolf of Mistvale"
rank: C
type: Bounty
giver: "Guild Board — Brindlewick"
summary: "Livestock vanishing under the full moon. Witnesses describe a wolf of silver light."
requirements:
  min_rank: D            # 1 rank above allowed; warning + 150% GP
  min_level: 30
  party_size: 1-4
  prerequisites: [GLD_D_0090_mistvale_rumors]
  reputation: { faction: kingdom_aldmere, min: friendly }
  recommended_items: ["Silver-tipped Arrows x20"]
  time_limit_days: 3
  conditions: [night_only, full_lumen_spawns_named]
objectives:
  - investigate: 3 farms
  - track: wolf trail (Tracking skill or Kiri in party)
  - resolve: [slay, tame (CHA>=120 + Monster Speech), parley]
rewards:
  gold: 4500
  gp: 260
  xp: 18000
  items: [silver_wolf_pelt, { choice: [moonfang_dagger, wolfhide_cloak] }]
  reputation: { kingdom_aldmere: +150 }
  unlocks: [named_companion_pet_frostling]
failure:
  conditions: [time_limit]
  penalty: { gp: -50, reputation: { kingdom_aldmere: -20 } }
world_change:
  on_slay: "Mistvale farmers celebrate; wolf pups appear orphaned later (follow-up quest)"
  on_tame: "Wolf joins; farmers distrust you until compensation quest"
  on_parley: "Wolf relocates; hidden questline: the wolf was guarding a shrine"
```
**Requirement types:** rank · level · class/sub-class · race · origin · party size · prior quests · reputation · items · skill level · Karma · time/weather/moon · story act · companion present · title held · season.

## 4. Sample Quests by Rank (flavor & variety)
| Rank | Quest | Type | Hook |
|---|---|---|---|
| F | **"Rabbit Season"** | Subjugation | Horned rabbits ate a farmer's carrots. One rabbit is enormous |
| F | **"Mina's Lost Earring"** | Odd job | It was taken by a giant crow; its nest is full of shiny loot |
| F | **"The Crying Mandrake"** | Gathering | The mandrake is a baby; its mother is very large |
| E | **"Goblins in the Granary"** | Defense | The goblins are starving and send a child as a scout. Mercy option |
| E | **"The Bridge Troll's Toll"** | Talk/fight | He wants a riddle, not gold |
| E | **"Brindlewick's Got Talent"** | Odd job | Judge the talent show; one contestant is a disguised imp |
| D | **"The Proving Cave"** | Trial | Solo dungeon, every mechanic tested |
| D | **"Wedding of the Wisps"** | Exploration | Escort two wisps to their wedding in a fairy ring |
| D | **"The Haunted Bakery"** | Investigation | The ghost just wants her recipe finished |
| C | **"The Silver Wolf of Mistvale"** | Bounty | See schema above |
| C | **"Dinner with Grandmother Silk"** | Diplomacy | Tea with an Arachne; wrong manners = boss fight |
| C | **"The Academy Entrance Exam"** | Academy arc | Written test (lore questions!), practical, and duel |
| B | **"The Siege of Marrowgate"** | Trial / defense | 3 nights, Stampede, NPC adventurers you've met fight beside you |
| B | **"A Dragon's Tax"** | Diplomacy/boss | A young dragon demands tribute from a town. Pay, fight, or outsmart |
| A | **"The Ball at Crimson Manor"** | Infiltration | A vampire's ball; dance minigame; dueling nobles |
| A | **"Dragonbane"** | Trial | Hunt a Wyrm with 2 companions max |
| S | **"The Unbroken Flame"** | Story | Ignarok's honor duel |
| SS | **"The Hero's Statue"** | Story | Discover who smashed the second Hero's face |
| SSS | **"Ascension"** | Finale | Choose the world's fate |

## 5. Hidden Quest Triggers (examples)
| Trigger | Quest |
|---|---|
| Pet Whiskers 30 times | **"The Cat Who Was a God"** (Vex) |
| Sleep at the inn during a Twin Eclipse | **"The Hooded Traveler"** |
| Sit on a bench in Aldmere for 10 minutes | An old man tells the tale of the first Hero |
| Return a goblin child home | **"The Goblin Who Wanted to Be an Adventurer"**; he joins the guild later as F-Rank |
| Lose to Hollis's broom 10 times | He teaches you a secret technique |
| Feed Mochi 100 different items | **"Mochi's Dream"** |
| Visit every viewpoint in a region | **"The Painter's Last Commission"** |
| Fail a rank trial on purpose 3 times | The Examiner investigates you |

## 6. Encounter Design
| Encounter | Description |
|---|---|
| **Ambient spawns** | Per-zone weighted tables, modified by time, weather, moon, season |
| **Ambush** | Perception vs stealth check; the camera tilts and drums kick in |
| **Roaming Elites/Named** | On the rumor board; patrol routes; remember your last fight |
| **Dynamic events** | Caravan attack, lost child, burning farm, monster birth, injured knight |
| **Mystery encounters** | Wandering merchant with cursed goods, a crossroads shrine, a talking skull, a fairy bargain |
| **Rival party encounters** | Rivals compete for your bounty and steal kills; respect builds over time |
| **Rank-Reveal events** | Scripted reaction scenes |
| **Isekai events** | Another otherworlder arrives nearby: help, rob, or recruit them |
| **Camp events** | Night camp: visitors, ambushes, a stargazing conversation |

### Spawn Table Example
```
Zone: Whisperwood (E)
  Common (68%):  Forest Wolf (F+), Goblin (F), Horned Rabbit (F), Green Slime (F)
  Uncommon (22%): Goblin Shaman (E), Cave Spider (F+), Wisp (F)
  Rare (8%):     Hobgoblin (E+), Metal Slime (D, flees), Owlbear (D+)
  Very Rare (2%): Named "Scarjaw" (D+), Wandering Merchant Pell, The Glass Stag (full Lumen)
  Modifiers: Night → Wraiths, Zombies · Rain → Slimes ×2 · Fog → Will-o'-wisps · Blood Vesper → all +1 rank
```

**Scaling:** zones are **fixed-rank** (rank means something). Rift dungeons, world events, and post-game content scale.

## 7. World Events
| Event | Trigger | Description |
|---|---|---|
| **Monster Stampede** | Dungeon overflow timer (clear dungeons to delay) | Waves vs a town; NPC adventurers you know defend beside you |
| **Blood Vesper Night** | Red moon full | +1 rank to all, rare spawns, cult rituals |
| **Twin Eclipse** | Yearly | Spirits walk; hidden areas open; the Hooded Traveler |
| **Dragon Migration** | Autumn | Dragons cross the sky; fight, hide, or follow to a lair |
| **Demon Incursion** | Story / random late | Portal opens; demon army |
| **Grand Tournament** | Summer | Ranked brackets; famous NPCs enter |
| **Festival of Blossoms** | Spring | Romance and friendship events |
| **Lantern Night** | Autumn | Visit the dead; Morrowyn quests |
| **Starfire Eve** | Winter | Gift-giving, snow fights, an ice dragon parade |
| **Hero Summoning** | Story | New otherworlders arrive |
| **Merchant Caravan Festival** | Random | Rare vendors, exotic goods |
| **Plague** | Ignored quests | Clerics/Alchemists needed; town state can drop |
| **Fairy Wedding** | Random spring | Tiny guests, huge consequences |
| **Calamity Awakening** | Late game | EX-tier raid encounter |
| **Rift Storm** | Random | Rifts spawn all over a region with high-tier loot |

## Recurring Tournament Circuit
| Tournament | Where | Frequency | Brackets |
|---|---|---|---|
| Brindlewick Rookie Cup | Brindlewick | Monthly | F–E |
| Fanghold Grand Arena | Beastkin Plains | Seasonal | D–A |
| Academy Duel League | Arcanum Spire | Weekly during term | Students |
| Jade Dynasty Sect Trials | Shen-Lu | Seasonal | Cultivation ranks |
| **The Grand Tournament** | Aldmere City | Yearly (summer) | F–SS, all brackets |
| Abyssal Pit Fights | Gearholm undercity | Nightly (illegal) | Any; Karma risk |
**Prize money, betting, titles, relic prizes, rival rankings.** Rivals return each season, stronger.

## The Academy (~50 Hours)
- **Arcanum Spire Academy:** 3 school years (in-game seasons), classes as minigames (alchemy, history exams using real lore, dueling, familiar care), student clubs, a rival dorm, festivals, a dorm-house cup, exams, a student council, and the **Academy Incident** (a Forbidden magic disaster in Year 3).
- Teachers and students are full NPCs; Seraphine's arc runs through it.
