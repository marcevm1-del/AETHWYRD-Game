# 05b — The Star Loom: Skill Progression System (v0.2, proposal)

> **Status:** design proposal for the user's OK (Canon §6 row "Skill map (Star Loom)"). Owned by the class-skill-designer; the combat-designer owns the modifier tuning, the systems-designer the point curve, the core-rules-engineer the resolver. Interactive prototype of the web: `Tools/prototypes/star_loom.html` (also published as a private artifact).
>
> **Inspiration:** Path of Exile 1's passive tree, active skills, support gems and keystones, as **design principles only**. No tree layout, node, skill or gem name, number, text or art is taken from it (`13_Production/reference_games.md` rule).
>
> **Tags used below:** **[Principle]** an established design principle, seen across the genre · **[Proposed]** a new mechanic for Ascend · **[Canon]** already locked in `Canon.md` and not changed here · **[Assumption]** something this doc assumes and the user should confirm.
>
> **v0.1 → v0.2:** v0.1 gave each class its own small constellation. On the user's direction ("more like this", with a reference screenshot of a large shared tree) v0.2 makes **one shared web for every class**. Class identity moves to the class kits and the new Class Crowns (§4.7).

---

## 1. Executive summary
Ascend gets a four-layer progression system that lets two Swordsmen at the same level play completely differently, without grind, filler or mandatory "correct" builds:

| Layer | What it is | Player verb | Source of points or items |
|---|---|---|---|
| **The Star Loom** (passive web) | One shared web of about 1,100 stars; 12 class starts on the inner ring | *Where do I walk?* | **Sparks**: about 190 over the whole game, front-loaded |
| **Class kit and Crowns** | Class actives (unchanged kit data) plus a small private tree per class tier | *What kind of class am I?* | Class levels, class quests, trainer tests |
| **Active skills** | Class skills, Weapon Arts, spells, monster, racial and unique skills in 4/6/8 slots | *What do I press?* | Kit levels, mastery, books, teachers, predation |
| **Wefts** (skill modifiers) | Small threads tied to a skill that change *how* it behaves | *How does my move work?* | Found, crafted, taught, earned; never only random |

On top of these sit **Keystones** (rule-bending choices with a cost) and **Masteries** (pick-one effects inside a theme). The design aims at PoE 1's best quality, emergent builds from combinations, while removing what doesn't fit a single-player, offline, teen-rated, real-time action RPG with a 300-level cap: trade-driven economy, gear-socket chasing, punishing respec and hidden-maths traps.

## 2. Core design pillars
1. **Combinations beat choices.** A build is the meeting of a skill, its Wefts, a web path and one Keystone, never one pick on a menu. [Principle]
2. **Every star changes something you can feel.** No +1% filler; small stars are small but readable, notables change play. [Proposed]
3. **The action is the build.** Modifiers hook into parries, perfect dodges, launches, chants and reactions, not only into numbers (Ascend's combat is real-time and skill-expressive; `12_Systems/combat.md`). [Proposed]
4. **Depth is optional; competence is not.** A player who follows the System's suggested path and slots any two Wefts gets a solid character. Theory-crafters get the full web. [Principle]
5. **Experimentation is cheap, mastery is earned.** Respec is affordable and fast; proficiency, Evolves and Crown stars are kept forever. [Canon §5 + Proposed]
6. **No repetition debt.** Points come from progress and milestones, never from farming; late levels add little web power so the level 300 cap isn't a grind wall. [Canon §6 proposal "Progression without repetition debt"]

## 3. What makes PoE 1's system work (analysis)

### 3.1 How the layers fit together [Principle]
| Layer | Its job in PoE 1 (general description) | Why it matters |
|---|---|---|
| Passive tree | A huge shared web; each class starts in a different spot; points buy small stats, notables and keystones | Position and pathing *are* the choice. Distance has a cost, so specialising is natural |
| Active skills | Skills are items anyone can use if they meet the stat requirements | Class doesn't lock the fantasy; a "melee class" can cast |
| Support modifiers | Linked supports change a skill's behaviour and cost (more projectiles, conversion, triggers) | One skill becomes many; the same base supports very different builds |
| Keystones | Rare nodes that break a rule with a big drawback | Few in number but build-defining; they create the "archetypes" players talk about |
| Ascendancy | A small class-specific tree on top | Gives each class something nobody else has, which the shared tree alone can't |

### 3.2 Why it creates builds rather than classes [Principle]
- **Multiplicative layers:** skill × supports × tree × gear give tens of thousands of combinations; even a small fraction being good is still hundreds of builds.
- **Shared space, different starting points:** everyone can reach everything, but distance makes neighbours of some classes and strangers of others. Hybrids are possible, not free.
- **Opportunity cost everywhere:** a point spent travelling is a point not spent on power. A support slot used for area is not used for damage.
- **Keystones as identity:** a rule change ("you can't be stunned, you can't evade") defines a build more strongly than any number.

### 3.3 Why it keeps people experimenting [Principle]
- Builds are puzzles with many solutions; finding one feels like authorship.
- Each new skill or support can re-open old builds.
- The community tradition of sharing builds lets new players borrow depth they don't yet understand.

### 3.4 Depth without requiring mastery [Principle]
- A player can follow a guide or the "obvious" cluster near their start and still progress.
- The complexity is front-facing (you can read every node) even when the maths underneath is deep.

### 3.5 Adapt or reject
| PoE 1 principle | For Ascend | Why |
|---|---|---|
| One shared passive web, class starts in different spots | **Adapt** (the Star Loom) | The user's direction; supports hybrids such as a Swordsman drifting into Lancer ground |
| Small stats on travel nodes | **Adapt**, but readable (+5 to one stat) | Travel should still count; no %-soup |
| Notables and keystones | **Adapt** | The core of build identity |
| Masteries (pick one effect per theme) | **Adapt** | Choice without adding more stars |
| Skills usable by any class | **Adapt partly**: Weapon Arts, spells and Extra skills are open; class kits stay class-bound | Ascend's classes, trainers and quests carry story weight (Canon: class change rules, trainers) |
| Supports in linked gear sockets with colours | **Reject** the sockets; **adapt** the modifier idea as Wefts tied to *skills* | Socket and link chasing is RNG gear grind; Canon guardrails: gear never degrades, essential gear never depends on pure luck |
| Separate level for each gem | **Reject**; fold into the existing skill proficiency (Lv 1–10) | One progression per skill is enough |
| Trade economy as the balance lever | **Reject** | Offline single-player (Canon "Offline-first economy") |
| Very large stat stacking (thousands of % increased) | **Reject** | Hard to read, and action combat needs predictable damage for hit-stop, poise and style |
| Expensive full respec | **Reject** | Canon §5 respec rules; experimentation is a pillar |
| Hidden or wiki-only interactions | **Reject** | Every interaction must be explained in the UI (§11) |
| Mana reservation auras | **Defer** | A "Stance" layer could come later; not needed for depth now |

## 4. The passive web (Star Loom)

### 4.1 Shape [Proposed]
```
 outer ring  ─── Keystones (12) at the rim, one per sector ───
 ring 4 (r1450) ── wheels/crescents ── Echo sockets on ring 3 (r1100)
 ring 3 (r1100) ── clusters guarding notables ──
 ring 2 (r760)  ── clusters ──
 class starts (r520), 12 of them, 30° apart, placed by stats
 ring 1 (r300) ── inner ring ── Heart of the Loom (centre)
```
- **12 sectors**, one per base class, ordered so neighbours share a stat: Swordsman (STR/AGI) · Lancer (AGI/STR) · Martial Artist (AGI/VIT) · Rogue (AGI/DEX) · Ranger (DEX/AGI) · Artisan (DEX/INT) · Mage (INT/WIS) · Occultist (INT/LUK) · Cleric (WIS/VIT) · Bard (CHA/WIS) · Tamer (CHA/VIT) · Guardian (VIT/STR), and back to Swordsman.
- **About 1,100 stars:** about 310 ring stars and 220 spoke stars ("paths"), 96 clusters (8 per sector, each one notable plus 4–6 minors), 12 Keystones, 12 Echo sockets, 12 starts, the Heart.
- **Four concentric rings** and **24 spokes** (12 through the starts, 12 between them). A few seeded gaps in rings 2 and 4 make routes interesting. Other classes' **start stars are walls**: paths go around them.
- A player ends the game with about **190 Sparks**, so about **17% of the web**. Two full sectors and a few raids into neighbours, or a long walk to a far Keystone.

### 4.2 Star types
| Type | Count | Cost | Effect size | Example |
|---|---|---|---|---|
| **Path star** | ~530 | 1 Spark | +5 to the local stat | "+5 AGI" |
| **Minor star** | ~480 | 1 | One small, themed effect | "+5% sword damage", "+4% on-beat window" |
| **Notable** | 96 | 1 | Changes how something plays | *Dawn Swings*: your first hit after a dodge deals +30% |
| **Keystone** | 12 | 1 (but far away) | Bends a rule; always has a cost | *Blood Chant*: spells cost HP instead of MP |
| **Echo socket** | 12 | 1 | Holds an Echo Shard (§4.6) | A Horned Rabbit Echo: a one-shot charging summon |
| **Mastery** | 1 per theme (~24 themes) | Free once a notable in the theme is lit | Pick 1 of 3 effects (§4.5) | Sword Mastery: *Longer combos* / *Crit on finishers* / *SP on parry* |
| **Heart of the Loom** | 1 | 1 | +3 to every stat | The crossroads for long hybrids |

Every star costs 1 Spark, as in the genre: **distance is the price**. A Keystone costs nothing extra; reaching it costs 10–15 stars of path.

### 4.3 Writing rules for stars [Proposed]
- **Small stars:** one stat or one tag-scoped % effect; budget ≈ 1 "power unit" (§9.5).
- **Notables:** a behaviour change or a conditional effect worth about 4 power units. Never a bigger version of the minors around it.
- **Keystones:** a rule change worth more than 10 units with a cost of similar size, so the net is about zero for the wrong build and large for the right one.
- **No dead ends:** every cluster sits on two routes; an unlucky gap never strands a build.

### 4.4 Exploration and readability [Proposed]
- **Star fog:** the whole web is visible, but stars more than 4 links from your lit stars show only their type and theme colour until you reach rank E. That keeps the first view calm. The fog lifts fully at rank D; the setting can be turned off.
- **Suggested threads:** the System Voice offers 3 suggested paths per class (for example "Flow duelist", "Fury bruiser", "Counter fencer"). Following one is never worse than average.
- **Hover a star** to see the shortest path from your lit stars and its Spark cost, as in the prototype. Search highlights every star that mentions a word ("parry", "bomb", "Fire").

### 4.5 Masteries [Proposed]
Each cluster theme (swords, shields, chant, traps, songs, partners…) has a **Mastery** star in its centre that costs nothing once you light any notable of that theme. You pick **1 of 3 effects**, and you can swap it freely at any rest (inn, camp, waystone). Each pick changes play, not just numbers:

| Theme | Option A | Option B | Option C |
|---|---|---|---|
| Swords | Combo Budget +1 for sword strings | Finishers always crit | Parries refund 15 SP |
| Chant | Basic tier chants instantly | Holding a chant past its tier stores one free recast | Interrupted chants refund 50% MP |
| Partners | Partners copy your element aura | Partner kills fill Awakening | Swap heals the partner 15% |

### 4.6 Special stars [Proposed]
- **Echo sockets** (one per sector, on ring 3): hold an **Echo Shard** (`01_Core_Concept/borrowed_features.md` #3). A socketed Echo gives either its one-shot summon or a small passive "of its kind" (a Wolf Echo: +5% damage while a partner is near). This replaces PoE's jewels with something tied to Ascend's monsters.
- **Bridge stars:** the 12 spokes between starts carry a few stars that **change a tag**. Example: *Bladesong* lets sword hits count as on-beat for Bard rhythm. These are how hybrids become real rather than just stat-sharing.
- **The Heart of the Loom:** the centre, +3 to every stat, the shortest crossing to the opposite side of the web.

### 4.7 Class identity on a shared web: Class Crowns [Proposed]
A shared web risks blurring the 12 classes (the risk v0.1 avoided). Ascend keeps class identity in three places:
1. **The class kit** (unchanged, `Data/Classes/classes.json`): the class's actives, mechanic and Ultimate.
2. **The starting position:** each class starts beside its own themes.
3. **Class Crowns:** each class tier (Base, Advanced, Expert, Master, Legendary) adds a **small private tree of 8–12 stars** that only that class can use, paid with **Crown points** from the class quest and trainer tests (2–3 per tier, about 6 per tier). Crown stars are the strongest class-specific effects: *Iaido Stance tuning* for the Blademaster, *Glyph capacity* for the Spellweaver. They are this system's answer to PoE's Ascendancy.

The **Sub-Class** (rank C, Canon) adds a second, smaller start on the web: one start star of the Sub-Class's sector becomes passable for you, and its Crown gives 50% effects (the existing Sub-Class rule).

### 4.8 Allocating, removing, respec
| Action | Cost | Rule |
|---|---|---|
| Light a star | 1 Spark | It must touch a lit star. Clicking a far star lights the shortest path, if you have the Sparks |
| Refund one star | 1 **Refund point** | Only if every other lit star stays connected to your start |
| Earn Refund points | Quests (~1 per 3 quests), rank trials (+5 each), inn "reflection" once per in-game week | Generous; they bank up to 40 |
| Full reset | Free to Lv 10; then gold at the **Shrine of Ilvaris** | [Canon §5] Cost rises by rank band but is capped at about one day's quest income for the band |
| Free reset token | One per class-tier change | [Canon §5] |
| Mastery swap | Free at any rest | Encourages trying all three |
| **Loom layouts** | Save up to 3 web layouts; switching costs a full reset | Lets a player keep a boss build and a field build |

## 5. Active skills

### 5.1 Skill categories
| Category | Ascend source | Examples (existing data) | Tags |
|---|---|---|---|
| **Attacks** | Class kit, Weapon Arts | Slash Chain, Piercing Thrust, Power Shot | Attack, Melee or Projectile, weapon |
| **Spells** | Class kit, spellbooks, trainers | Fire Bolt, Chain Lightning, Heal | Spell, element, Chant tier |
| **Movement** | Kit, Weapon Arts, wind spells | Flash Step, Vault, Blink, Shadow Step | Movement, Dash or Blink |
| **Defensive** | Kit | Shield Wall, Parry Riposte, Mana Shield, Counter Stance | Guard, Counter |
| **Summons** | Kit, Echo Shards, Tamer partners | Summon Shade, Deploy Turret, Tame | Summon, Minion |
| **Utility and field** | Kit, life skills | Steal, Appraise, Snare Trap, Lullaby | Utility, Trap, Song |
| **Ultimates** | Kit at the class's Ultimate level | Thousand Petal Blade | Ultimate (no Wefts; §6.6) |

**Tags are the backbone.** Wefts, passives and Keystones all target tags, never named skills, so new skills plug into old content (§10).

### 5.2 Acquisition [Canon + Proposed]
| Route | What | Notes |
|---|---|---|
| Class level | Class kit (data: `unlockLevel`) | [Canon] unchanged |
| Weapon mastery | Weapon Arts (`skills_and_magic.md` §4) | Any class with that weapon |
| Spellbooks, trainers, scrolls | Spells by element and Chant tier | Tier gated by rank band (existing table) |
| Feats and hidden teachers | Extra skills | Story or exploration |
| Predation, pacts, Echo Shards | Monster skills | Reborn Monster origin and Echoes |
| Class affinity | One skill borrowed from a companion's class | [Canon §6 proposal "Borrowed features" #2] |
| Unique skills | Copy, Predator… | Origin-granted |

### 5.3 Resources and constraints
| Constraint | Applies to | Purpose |
|---|---|---|
| **SP** (stamina) | Attacks, movement, guarding | Melee rhythm |
| **MP** | Spells, songs, summons | Caster pacing |
| **HP** | Blood-cost skills, some Keystones | Risk-reward |
| **Cooldown** | Every skill; floors of 1 s (attacks), 2 s (spells), 8 s (summons) | Keeps hit-stop and readability |
| **Combo Budget** | Skill-cancels (3 per string) | [combat.md §4.1] Wefts may change this, within caps |
| **Chant time** | Spells by tier | Mage's Chant mechanic |
| **Awakening** | Ultimates | [combat.md §6] |
| **Weave capacity** | Wefts per skill (§6.3) | Limits modifier stacking |

### 5.4 Slots and loadouts [Canon]
- **4 skill slots, 6 at rank B, 8 at rank S** (`combat.md` §6), plus the Ultimate. The basic string is fixed by weapon.
- With a Sub-Class (rank C), 2 slots may hold Sub-Class actives.
- **Loadouts:** 3 saved loadouts (skills plus their Wefts), swapped at any rest, or in the field with a 10 s lockout. [Proposed]

### 5.5 Upgrades without obsolescence [Canon + Proposed]
- **Proficiency Lv 1–10** from varied use (`progression_experience.md` mastery bands). Each level adds a little power; Lv 3, 6 and 9 add a **Weft capacity** point (§6.3).
- **Facets** (v0.1): each active gets 2 variant picks at proficiency Lv 3, swappable outside combat. Example: Flash Step *Through* (hits a line) or *Return* (dash, cut, step back).
- **Evolve** at Lv 10 into a stronger form; the base form stays learnable, and both keep their Wefts.
- **Fuse** two Lv 10 skills (existing table); the player names the result.
- **Rank resonance:** a skill's base power scales with the rank band of the *character*, not of the skill, so a Lv 1 kit move is still viable at rank S. Early skills never become dead slots; Evolves add behaviour, not just numbers.

## 6. Wefts: the skill modification system

### 6.1 The idea [Proposed]
A skill is the **warp** (the long threads); **Wefts** are the threads you weave across it. You tie Wefts onto a *skill*, not into gear. A Weft is a small item you own once and can move between skills at any rest (cost: none). Owning two copies lets two skills use the same Weft.

### 6.2 Weft families
| Family | Changes | Examples | Exclusive group |
|---|---|---|---|
| **Form** | How the skill is delivered | *Fan* (projectiles split into 3, −30% each) · *Nova* (becomes a ring around you) · *Snare* (becomes a trap that fires when stepped on) · *Ward Stake* (planted, repeats 3 times) | **One Form per skill** |
| **Element** | Damage type and auras | *Kindle* (50% of physical becomes Fire, applies Fire aura) · *Stillwater* (applies Water aura on hit) · *Hush* (Wind damage, applies Swirl) | One conversion per skill; auras stack only as reactions allow |
| **Payload** | What the hit leaves behind | *Ember Trail* (direct damage becomes a 4 s burn worth 140%) · *Chain* (jumps to 2 more foes, −25% each) · *Concussion* (+40% poise damage) · *Frostbite* (Chill, then Freeze on the 3rd hit) | Max 2 Payloads |
| **Rhythm** | Cost, cooldown, targeting | *Quickened* (−30% cooldown, +30% cost) · *Frugal* (−30% cost, −15% damage) · *Long Chant* (a spell's tier +1, chant ×2) · *Homing* (targets the marked foe) | Max 1 cost and 1 cooldown change |
| **Echo** | Repeats | *Twin Echo* (repeats once at 60% after 0.5 s) · *Afterimage* (a delayed copy where you were) | One Echo per skill |
| **Trigger** | Fires the skill from an action | *On Parry* · *On Perfect Dodge* · *On Launch* · *On Reaction* · *On Beat* (Bard rhythm) | One Trigger per skill; triggered skills can't carry Triggers |
| **Combo** | How it fits the action grammar | *Free Cancel* (this skill costs no Combo Budget when cancelled out of a launcher) · *Air Ready* (usable in the air) · *Riposte Link* (follows a Riposte without a gap) | Max 1 |

**Action-combat hooks (Trigger, Combo) are Ascend's own.** They make a build about *what you do*, not only what you stack: a Counter Swordsman with *On Parry → Air Slash* fights differently from a Flow Swordsman with *On Perfect Dodge → Flash Step*.

### 6.3 Weave capacity: how many Wefts fit [Proposed]
- Each skill has **Weave capacity** = 1 + 1 at proficiency Lv 3, 6 and 9 = **up to 4**. Some Crown stars add 1 to one tag (for example Spellweaver: +1 for Spells).
- Each Weft has a **weight** of 1 or 2 (strong ones weigh 2). Total weight must be at most the capacity.
- Each Weft also has a **cost multiplier** (×1.1–×1.5) that multiplies the skill's SP or MP cost. Four strong Wefts make a skill expensive, which is the PoE "more supports, more cost" principle in readable form.

### 6.4 How modifiers resolve [Proposed]
Wefts, passives, Keystones and Facets all resolve in **one fixed pipeline**, the same for every skill:
1. **Form** chooses the delivery shape.
2. **Conversion** (one step only, physical → element, or element → element, max 100%).
3. **Added damage** (flat).
4. **Increased** (all % increases add together).
5. **More** (each "more" multiplies; only notables, Keystones and Wefts may grant "more").
6. **Payload** (DoT, chain, status) uses the result.
7. **Cost and cooldown** (with floors).
8. **Triggers and Echoes** are attached last, with a recursion depth of 1.

The game shows this pipeline in the skill tooltip as a short "Damage story" (§11).

### 6.5 Prohibited and limited combinations [Proposed]
| Rule | Why |
|---|---|
| One Form, one conversion, one Echo, one Trigger per skill | Prevents multiplicative explosions and unreadable skills |
| Triggered skills can't trigger (depth 1) | Stops infinite loops |
| Triggers have a shared internal cooldown of 0.5 s per source | Stops a parry from firing four skills |
| Ultimates take no Wefts | They are authored set pieces |
| Movement skills can't take Ward Stake or Snare | A planted dash makes no sense |
| Summons take only Payload, Element and Rhythm | Keeps summons readable; their own tree gives depth |
| Cooldown floors (§5.3) and a cost floor of 1 | No free spam |
| "More" multipliers from Wefts are capped at ×2.0 total per skill | A single skill can't out-scale the rest of the kit |

### 6.6 Keeping any one combination from dominating [Proposed]
- **Opportunity cost:** capacity is small (max 4); every Weft added is another not taken.
- **Rising cost:** cost multipliers multiply, so a 4-Weft skill costs about twice the base.
- **Situational power:** the strongest Wefts are conditional (On Parry, On Reaction). They are huge for players who perform the action, modest otherwise.
- **Encounter variety:** packs, elites and bosses ask different questions (`combat.md` §14); a pure single-target build struggles with a Stampede, a pure area build with a boss Break gauge.
- **Simulation gate:** every Weft is checked by the balance harness (§9.5) before it ships.

## 7. Keystones and build-defining mechanics
All 12 sit at the rim, one per sector. Each has a real benefit, a real cost and a strategic change.

| Keystone | Sector | Benefit | Cost | Strategic implication |
|---|---|---|---|---|
| **Edge of Glass** | Swordsman | +40% damage dealt | +25% damage taken | Rewards perfect dodging; Flash Time is your defence |
| **Endless Charge** | Lancer | Momentum never fades while you move | You can't block | Keep moving; fights become laps |
| **Empty Hands** | Martial Artist | Unarmed hits use your best weapon's damage | No weapon slot | Gear becomes accessories and armour |
| **Ghost Contract** | Rogue | Every kill returns you to stealth | Healing on you −50% | Chain kills or die; opener builds |
| **Single Breath** | Ranger | Every shot is a fully charged shot | No quick shots | Positioning and timing over volume |
| **Overcrafted** | Artisan | Gadgets gain one quality tier | They cost twice the materials | Crafting economy becomes your damage |
| **Blood Chant** | Mage | Spells cost HP instead of MP | Your healing is now your mana | Pairs with life drain or healers; dangerous with bosses that chip |
| **Hungry Dark** | Occultist | Life drain overheals into a shield | No natural HP regen | You must keep draining to stay alive |
| **Martyr's Grace** | Cleric | Your heals are 50% stronger | You can't heal yourself | You depend on companions (and they on you) |
| **One-Note Wonder** | Bard | One song at a time, at ×2 effect | Only one song | Song choice per fight becomes the build |
| **Shared Heart** | Tamer | You and your partner share one HP pool, +30% larger | If it empties, both fall | Partner positioning becomes your defence |
| **Immovable Oath** | Guardian | You can't be staggered | No dodge-roll, only a step | Blocking and parrying are your only defence |

**The prompt's example categories map onto these:** defence into offence (*Immovable Oath* with the Guardian Mastery "+1% damage per 10 armour"), health for damage (*Blood Chant*, *Edge of Glass*), single element (the Mage Mastery *Pure Element*: all conversions go to one chosen element, reactions you trigger deal ×1.5, you can't apply other auras), mobility for power (*Immovable Oath*, *Single Breath*), attacks into summons or DoT (Wefts *Ward Stake*, *Ember Trail*, and the Occultist Crown star *Thrall Covenant*: your summons inherit 50% of your passive bonuses, you deal 30% less).

**Rule:** only **one Keystone** may be active at a time, plus one from the Sub-Class Crown at rank S. A second Keystone lit on the web is dormant (shown dim) until you pick it as active at a rest.

## 8. Example builds
Each build is shown at its late form (rank A to S) with how it gets there. Points: ~110–130 Sparks by A.

### 8.1 Petal Dancer (Swordsman → Blademaster): the counter-dodge duelist
| | |
|---|---|
| **Fantasy** | Untouchable blade dancer who punishes every miss |
| **Skills** | Flash Step (Facet *Return*), Air Slash, Rising Cut, Parry Riposte; Ultimate Thousand Petal Blade |
| **Web** | Swordsman Flow side → Lancer bridge for movement speed → *Edge of Glass* |
| **Wefts** | Flash Step: *On Perfect Dodge* + *Afterimage* · Air Slash: *Hush* (Wind, Swirl) + *Chain* |
| **Synergy** | A perfect dodge fires Flash Step, its afterimage cuts again, Air Slash spreads Wind; Edge Flow stacks never drop |
| **Strength / weakness** | Huge damage, high Style Rank · one mistake hurts (+25% taken); weak against red unblockable spam with no gaps |
| **Resources** | SP; Mastery *Parries refund SP* keeps the loop fed |
| **Path** | F: Slash Chain + Sidestep notable · D: first Trigger Weft · C: Blademaster Crown (Iaido) · A: Edge of Glass |

### 8.2 Stormbinder (Mage → Elementalist): the reaction engine
| | |
|---|---|
| **Fantasy** | A tactician who sets up two elements and detonates them |
| **Skills** | Water Lance, Chain Lightning, Frost Nova, Blink |
| **Web** | Mage Tide clusters → Artisan bridge (*Long Fuse* for area) → notable *Element Echo* (reactions last longer) |
| **Wefts** | Water Lance: *Stillwater* + *Fan* · Chain Lightning: *On Reaction* + *Chain* |
| **Synergy** | Water auras on a pack → Chain Lightning makes Storm Prison → On Reaction recasts → stuns ripple |
| **Strength / weakness** | Best pack control in the game · weak against single foes immune to Water; needs set-up time |
| **Resources** | MP; *Frugal* on Water Lance; chant timing |
| **Path** | E: Fire Bolt + Air Slash Firestorm (the Ring 0 reaction) · D: Stillwater · C: Elementalist Resonance · B: On Reaction |

### 8.3 Hollow Court (Occultist → Necromancer): the commander
| | |
|---|---|
| **Fantasy** | You stand back and conduct a court of shades |
| **Skills** | Summon Shade, Bone Prison, Hex, Curse of Frailty, Life Drain |
| **Web** | Occultist Thrall clusters → Tamer bridge (*Pack Call*) → Crown *Thrall Covenant* |
| **Wefts** | Summon Shade: *Kindle* (shades burn) + *Quickened* · Hex: *Nova* (curse an area) |
| **Synergy** | Curses spread; shades inherit your passives; Bone Prison holds foes in the burn |
| **Strength / weakness** | Safe, steady, great vs packs · low burst; weak when shades are cleared by area attacks |
| **Resources** | MP and Corruption Pool; Life Drain is your heal |
| **Path** | F: Shadow Bolt · E: Summon Shade · D: Ember Trail on Shadow Bolt · C: Necromancer Crown |

### 8.4 Iron Bulwark (Guardian → Fortress Knight): the wall that hits back
| | |
|---|---|
| **Fantasy** | Stand in the doorway and make the enemy break on you |
| **Skills** | Shield Wall, Shield Bash, Earth Stomp, Guardian's Oath, Charge |
| **Web** | Guardian Bastion clusters → Swordsman bridge (*Honest Blade*) → *Immovable Oath* → Mastery *+1% damage per 10 armour* |
| **Wefts** | Shield Bash: *On Parry* + *Concussion* · Earth Stomp: *Nova* + *Ward Stake* |
| **Synergy** | Every parry fires a bash; Bulwark spends turn into shockwaves; Oath protects a companion |
| **Strength / weakness** | Can't be staggered; best vs bosses with blue tells · slow; no dodge vs red unblockables (must step) |
| **Resources** | SP (blocking drains it); notable *Iron Lung* |
| **Path** | F: Shield Bash + Provoke · D: On Parry · C: Fortress Knight Crown · B: Immovable Oath |

### 8.5 Clockwork Hunter (Artisan with a Ranger bridge): the prepared battlefield
| | |
|---|---|
| **Fantasy** | You win the fight before it starts: traps, turrets, a kill zone |
| **Skills** | Deploy Turret, Bomb Toss, Snare Trap (borrowed via Ranger affinity), Explosive Arrow (Weapon Art) |
| **Web** | Artisan Clockwork → Ranger Wild clusters (*Trapper's Hands*) → *Overcrafted* |
| **Wefts** | Bomb Toss: *Snare* (becomes a mine) + *Twin Echo* · Turret: *Kindle* |
| **Synergy** | Lure with Snare Trap, mines go off, turrets burn the survivors; Firestorm with a Wind Weft |
| **Strength / weakness** | Strongest prepared fights and siege defence (`systems.md` sieges) · weak in surprise ambushes; material cost |
| **Resources** | Materials and SP; crafting quality |
| **Path** | F: Bomb Toss · E: Deploy Turret · D: Snare Weft · C: Alchemist or Blacksmith Crown · B: Overcrafted |

### 8.6 Beast Choir (Bard with a Tamer Sub-Class): the rhythm pack leader
| | |
|---|---|
| **Fantasy** | You sing; your monsters fight on the beat |
| **Skills** | Ballad of Courage, Song of Swiftness, Lullaby; Sub-Class: Command, Rally |
| **Web** | Bard Anthem → Tamer Bond clusters (*Feral Bond*) → notable *Duet* → *One-Note Wonder* |
| **Wefts** | Ballad: *On Beat* + *Nova* · Lullaby: *Homing* |
| **Synergy** | Every on-beat attack pulses the song to your partners; one doubled song all fight |
| **Strength / weakness** | Unique feel, great for long fights · relies on rhythm input (accessibility assist available, `combat.md` §13); low personal damage |
| **Resources** | MP; the beat itself |
| **Path** | F: Ballad · D: On Beat Weft · C: Tamer Sub-Class · S: One-Note Wonder |

**Mechanically different, not just reskinned:** 8.1 is about dodging, 8.2 about set-up and detonation, 8.3 about positioning others, 8.4 about blocking, 8.5 about preparation before combat, 8.6 about rhythm.

## 9. Progression and balance

### 9.1 Sparks over the whole game [Proposed; level bands are Canon]
Front-loaded so early levels feel rich and the long road to 300 is not a passive-point grind.

| Band (Canon) | Levels | Sparks per level | Sparks in band | Running total |
|---|---|---|---|---|
| F | 1–15 | 1 | 14 | 14 |
| E | 16–35 | 1 | 20 | 34 |
| D | 36–60 | 1 | 25 | 59 |
| C | 61–90 | 1 per 2 | 15 | 74 |
| B | 91–125 | 1 per 2 | 17 | 91 |
| A | 126–165 | 1 per 2 | 20 | 111 |
| S | 166–210 | 1 per 3 | 15 | 126 |
| SS | 211–260 | 1 per 3 | 16 | 142 |
| SSS | 261–300 | 1 per 4 | 10 | 152 |
| **Plus** | 8 rank trials ×2 = 16 · ~11 from "Star Charts" (story and exploration) · Transcendence T1–T10 = 10 | | **37** | **≈189** |

Late-game power comes from Crowns, Evolves, Masteries and Wefts more than from Sparks.

### 9.2 Milestones (what opens when)
| Milestone | Rank / when | What opens | Reason |
|---|---|---|---|
| First Spark | Lv 2 | Your start and its two neighbouring clusters; fog beyond | Calm first view |
| First notable | ~Lv 6 | A suggested thread from the System | First "build" feeling |
| **First Weft** | F→E trial (Goblin Chief) reward | Weft slot on kit skills; 3 starter Wefts (one Form, one Element, one Rhythm) | Teaches modifiers with something you already own |
| Fog lifts partly | Rank E | Stars within 8 links show details | Room to plan |
| **Masteries** | First notable of a theme after Lv 36 (D) | Pick-one effects | Choice without more stars |
| Fog lifts fully | Rank D | Whole web readable | |
| **Advanced class + Crown** | D→C (Canon: needs Advanced class) | Crown tree, Crown points | Class identity deepens |
| **Keystones active** | Rank C | One Keystone can be chosen at a rest | By now the player understands the base rules |
| **Sub-Class** | Rank C (Canon) | Second start, 2 Sub slots | Hybrids |
| Trigger and Combo Wefts | Rank C | Action hooks | Needs good combat fundamentals |
| 6 skill slots | Rank B (Canon) | More room for Wefts | |
| Echo sockets | Rank B, or the first Echo Shard, whichever is later | Monster imprints | Ties hunting to the build |
| 8 slots, Sub Keystone | Rank S | Second Keystone from the Sub Crown | Endgame expression |
| Transcendence | SSS | +1 Spark each, Crown capstones | Prestige, not grind |

### 9.3 Not overwhelming the player [Proposed]
- Fog, suggested threads and a **"Just pick for me"** button that lights the next star of the chosen thread.
- Weft families unlock in order (Form, Element, Rhythm → Payload → Echo, Trigger, Combo).
- The System Voice explains each new layer once, in fiction, when it opens ("A thread you can tie across a technique. Try it on something you trust.").

### 9.4 No mandatory or universally optimal builds [Proposed]
- **Many strong points instead of one best:** every sector has at least two notables rated "build-defining" by the harness.
- **Content asks different questions:** pack, elite, boss and siege grammar (`combat.md` §14, Sieges) reward different builds; difficulty changes pressure before HP (Canon proposal "Ring 0 combat/readability contract").
- **Companions cover gaps:** a pure-damage build leans on a healer companion, a tank on a damage companion. Companion AI roles (`12_Systems/companion_field_ai.md`) make this a choice, not a crutch.
- **Single-player stance:** a slightly overpowered build that the player *discovered* is fine; one that trivialises the S-rank difficulty floor (Canon, `ranks.md`) is not.

### 9.5 Balancing powerful combinations [Proposed]
- **Power units:** every star, Weft and Keystone has a budget (small 1, notable 4, Keystone 10±, Weft 2–6). Designers write to the budget; the tool sums it per build.
- **Balance harness** (new Core tests, §10.6): for every class and suggested thread at each band, simulate damage per second, effective HP and clear speed against reference monsters from `Data/Monsters`. Flag any build more than 25% above or 25% below its band's median.
- **Hard caps** (§6.5), cooldown and cost floors, and a cap on total "more" per skill.

### 9.6 Experimentation and respec
[Canon §5] free respec to Lv 10, Shrine gold after, a token per tier; plus Refund points, free Mastery and Weft swaps at rests, and 3 saved layouts (§4.8). Proficiency, Evolves, Fusions and Crown stars are never lost.

### 9.7 Progression without grind
- Proficiency rises from *varied, meaningful* use, not repetition (`progression_experience.md`).
- Wefts come from at least two routes each: a deterministic one (trainer, quest, craft recipe) and a lucky one (drops). [Canon §6 proposal "Relic acquisition"]
- No daily timers, no decay (Canon "Offline-first economy", "In-game-time continuity").

## 10. Technical implementation architecture
**[Assumption]** Rules live in the engine-agnostic C# library `Code/Ascend.Core` with tests, data in `Data/` as validated JSON; Unity only presents and plays. This matches the repo today.

### 10.1 Data files
| File | Holds | Built by |
|---|---|---|
| `Data/Classes/star_loom.json` | Nodes, edges, sector themes, version | `Tools/classes/build_star_loom.js` from a layout spec (rings, spokes, cluster templates) and a hand-written star list |
| `Data/Classes/wefts.json` | Wefts: family, tags, weight, cost multiplier, effects, exclusions | Hand-written |
| `Data/Classes/crowns.json` | Class Crown trees per class tier | Hand-written |
| `Data/Classes/classes.json` | Kits (existing), plus skill tags and Facets | Existing generator |
| `Data/Schemas/*.schema.json` | Schemas for the above | Validator (`npm run build`) |

### 10.2 Shapes
```jsonc
// star_loom.json (node)
{ "id": "sw_n_dawn_swings", "type": "notable", "sector": "swordsman",
  "x": -312.4, "y": -610.0, "theme": "swords",
  "effects": [ { "op": "more", "stat": "damage", "value": 0.30,
                 "when": { "event": "afterDodge", "windowSec": 1.0, "firstHitOnly": true } } ],
  "text": "Your first hit after a dodge deals 30% more damage." }
// edges are stored once: [["sw_p_0412","sw_n_dawn_swings"], ...]

// wefts.json
{ "id": "wft_on_parry", "family": "trigger", "weight": 2, "costMult": 1.3,
  "requiresTags": ["Attack|Spell"], "forbidsTags": ["Ultimate","Summon"],
  "exclusiveGroup": "trigger",
  "effects": [ { "op": "trigger", "on": "parrySuccess", "icdSec": 0.5 } ] }
```
Effects use a **small closed set of operations** (`add`, `increased`, `more`, `convert`, `setFlag`, `trigger`, `form`, `payload`, `costMult`, `cooldownMult`, `grantTag`), so designers add content by data, not code.

### 10.3 The tree at runtime
```csharp
// Ascend.Core
sealed class StarLoom {                       // immutable, loaded once
    public IReadOnlyList<Star> Stars;
    public IReadOnlyList<int>[] Adj;          // adjacency by index
}
sealed class LoomState {                      // saved
    public int TreeVersion;
    public HashSet<int> Lit;                  // includes the class start
    public int ActiveKeystone = -1;
    public Dictionary<string,int> MasteryPick; // theme -> option
}
static class LoomRules {
    public static List<int> PathTo(StarLoom t, LoomState s, int target, int startOfClass);
        // multi-source BFS from Lit; other classes' starts are walls
    public static bool CanRefund(StarLoom t, LoomState s, int star, int start);
        // BFS from start over Lit minus star; must reach all Lit
    public static int SparksAvailable(int level, Milestones m);   // §9.1 table from data
}
```

### 10.4 Resolving a skill
Skills resolve **once when the loadout changes**, not on every hit; the result is cached.
```csharp
SkillSpec Resolve(SkillDef baseSkill, SkillState st, Character c) {
    var spec = SkillSpec.From(baseSkill, st.Proficiency, st.Facet, c.RankBand);
    var mods = new List<Effect>();
    mods.AddRange(c.Loom.EffectsMatching(spec.Tags));       // stars, masteries, keystone
    mods.AddRange(c.Crown.EffectsMatching(spec.Tags));
    foreach (var w in st.Wefts) {
        if (!WeftRules.Allowed(w, spec, st.Wefts, out var why)) throw new InvalidLoadout(why);
        mods.AddRange(w.Effects);
    }
    // fixed pipeline (§6.4)
    spec = Phase.Form(spec, mods);
    spec = Phase.Convert(spec, mods);        // one conversion step, total ≤ 100%
    spec = Phase.Added(spec, mods);
    spec = Phase.Increased(spec, mods);      // sum
    spec = Phase.More(spec, mods, capFromWefts: 2.0);
    spec = Phase.Payload(spec, mods);
    spec = Phase.CostCooldown(spec, mods, Floors.For(spec.Tags));
    spec = Phase.Triggers(spec, mods, maxDepth: 1, icdSec: 0.5);
    spec.Story = Explain(spec, mods);        // the tooltip's "Damage story"
    return spec;
}
```
Combat (Unity) reads only the resolved `SkillSpec`: hits, power, element, poise, cost, cooldown, triggers. The existing damage formula (`combat.md` §9) takes `power` from it.

### 10.5 Preventing conflicts
- **Validation at three points:** the data validator (schemas plus rules such as "every Weft has an exclusiveGroup"), the loadout screen (`WeftRules.Allowed` explains *why* a Weft won't fit), and the resolver (throws in tests, never in play).
- **Exclusive groups and tag rules** (§6.5) are data, so new Wefts inherit them.
- **Event triggers** go through one `TriggerBus` with a depth counter and per-source cooldowns.
- **Determinism:** resolution is pure and testable; the same inputs always give the same `SkillSpec`.

### 10.6 Tests
- Tree: connectivity (every star reachable from every start without crossing other starts), no cluster with a single entrance, refund correctness, path cost.
- Resolver: golden tests for each example build (§8), pipeline order, caps and floors, trigger depth.
- Balance harness: per band, per suggested thread; flags outliers (§9.5).

### 10.7 Future content without redesign
- **Tree versions:** when a new version removes or moves stars, saved lit stars that no longer exist are refunded automatically and the player gets a free reset token (save migration in the save-platform layer).
- **New skills** only need tags; all tag-scoped stars and Wefts work with them.
- **New Wefts** use the closed effect set; a new *operation* is the only change that needs code.
- **New classes** (Hidden or Monster classes) get a start on a new spoke or reuse a sector, plus a Crown.

## 11. Risks and mitigation
| Risk | Why it matters | Mitigation |
|---|---|---|
| **The web overwhelms new players** | 1,100 stars on the first menu kills interest | Star fog, suggested threads, "Just pick for me", layers unlocking by rank (§9.2–9.3) |
| **Shared web blurs class identity** | A Mage and Occultist could end up identical | Class kits, starting position, Crowns, Keystones per sector (§4.7) |
| **Combat readability** | Many triggers and echoes clutter the screen and break hit-stop | Trigger depth 1, internal cooldowns, cooldown floors, max 1 Echo; VFX budget per skill (technical-artist) |
| **One combination dominates** | Players feel forced | Caps, cost growth, situational power, harness gate (§6.6, §9.5) |
| **Hard to communicate** | Hidden maths frustrates | The "Damage story" tooltip, plain-language effects, a training ground at every guild to test builds on dummies with numbers on |
| **Writing and art cost** | 96 notables, ~40 Wefts, 60 Crown trees, icons | Ship in rings (§12); icons by theme families; Crowns for Advanced classes only until Ring 3 |
| **Long-game point inflation** | Level 300 could mean dull late levels | Front-loaded Sparks; late power from Crowns, Evolves, Transcendence (§9.1) |
| **Respec too cheap removes meaning** | Choices feel weightless | Refund points are plentiful but not infinite; full reset costs gold after Lv 10; Crown points don't refund |
| **Rhythm and timing builds exclude some players** | Accessibility | Rhythm and parry assists already planned (`combat.md` §13); timing-based Triggers have relaxed windows in assist mode |
| **Companions trivialise weaknesses** | Builds stop mattering | Companion assists are short (Canon proposal "Party synergy"); bosses test the player's own answer |
| **Wiki-solved web** | The fun of discovery fades | Fine for single-player; the System Voice and Star Charts still give in-world discovery |

**Complexity cut list (what we don't build):** gear sockets and link colours · separate gem levels · trade-balanced drop rates · mana-reservation auras (for now) · more than one conversion step · more than one active Keystone before rank S.

## 12. Roadmap and prototyping priorities
| Ring | Build | Proves |
|---|---|---|
| **Now** | Interactive web prototype (done: `Tools/prototypes/star_loom.html`) | The web reads and paths feel right |
| **Ring 0** | Core: `StarLoom`, `LoomState`, `PathTo`, `CanRefund`, `SparksAvailable` with tests · Swordsman start area only (~40 stars) · 3 Wefts (*Hush*, *Concussion*, *On Perfect Dodge*) on Ring 0 skills · Unity: a simple web window | Does a Weft on Flash Step change how the Ring 0 fight feels? |
| **Ring 1** | Generator for the full web; all 12 sectors' paths and minors; 24 notables; Masteries for 6 themes; ~15 Wefts; Star fog and suggested threads; balance harness v1 | Can a new player pick a build without help? |
| **Ring 2** | All 96 notables and 12 Keystones; Crowns for the 24 Advanced classes; Echo sockets; Trigger and Combo Wefts; loadouts | Do the six example builds feel different in play? |
| **Ring 3** | Expert and Master Crowns, Sub-Class starts, Transcendence, tree versioning and save migration | Long-game health |

**Prototype first:** the Ring 0 test is the most important; if a Weft doesn't change the *feel* of a Swordsman fight, the modifier layer needs redesign before content is written.

## 13. Where this design depends on Ascend
| Dependency | Ascend's answer | If it changed |
|---|---|---|
| Single-player, offline | [Canon] | Multiplayer would need far tighter balance and server-side validation |
| Real-time action combat | [combat.md] | Turn-based combat would drop Trigger and Combo Wefts and move to cost and initiative |
| Teen rating | [Canon] | No impact on mechanics; keeps effect names and VFX non-graphic |
| Companions in the party | [Canon] | Without them, Martyr's Grace and Shared Heart would need redesign |
| Level cap 300 | [Canon] | The Spark curve (§9.1) is built around it |
| Controller support | [hud_and_ui.md] | The web view needs stick navigation along threads and bumper jumps between sectors |

## 14. Open decisions (do not lock silently)
1. **Shared web confirmed?** v0.2 assumes yes (user direction 2026-11-03). If not, v0.1's per-class constellations return.
2. **Wefts as items or as knowledge?** This doc makes them items you own (found, crafted, taught). Alternative: learned once like spells, no copies.
3. **One active Keystone** until rank S, or one per class tier?
4. **Star Charts:** about 11 bonus Sparks from story and exploration; which quests award them is a quest-designer pass.
5. **Names:** "Star Loom", "Sparks", "Wefts", "Crowns" and the 96 notables and 12 Keystones need a canon-keeper and narrative-writer pass (the Loom and the Great Weave are cosmology terms, `02_Lore/cosmology.md`; the tie is intended but should be checked).
6. **The Swordsman's Ultimate** unlocks at Lv 1 in `classes.json` but at Lv 30 in the class doc; which is right?
