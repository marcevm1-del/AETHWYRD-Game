# Questionnaire #1: Answers & Design Impact (2026-10-22)
> **Historical record.** These answers have been folded into the design docs. Where anything here differs, **Canon.md** and the topic docs win.

Answers 1–50.

| # | Answer | Design impact |
|---|---|---|
| 1 | **Unity** | Unity 6 LTS + URP. Install to **E:** (C: has 14 GB free) |
| 2 | **Blender** (Claude connected via MCP) | Claude can script models, props, terrain pieces and exports in Blender |
| 3 | **4–5 hrs/week** | Small focused milestones; Claude does heavy lifting between sessions |
| 4 | PC: Ryzen 5 5600H, **GTX 1650 4 GB**, 16 GB RAM | Fine for toon-shaded URP. Large-world editing needs streaming + LODs from day one. Target spec = Steam Deck-class hardware |
| 5 | Budget later | Prefer free/owned tools: VRoid, Mixamo, Unity Toon Shader, Blender |
| 6 | **Anime combat**: fluid, fast, flashy **and** heavy; stylish combos; big explosions | Action combat with hit-stop, launchers, air combos, cancels, screen-filling ultimates. See *Combat Pillars* below |
| 7 | **No companion swapping**; companions are their own AI | Companion AI quality is critical: personalities, tactics, banter. Command wheel stays |
| 8 | **Lock-on + free aim, switchable** | One button toggles; ranged/magic gets a free-aim reticle |
| 9 | **Choose difficulty, but S-rank+ content is brutal on every setting** | "Difficulty floor": from S-rank content up, enemy AI, damage and mechanics ignore the easy settings |
| 10 | **Elemental combos = yes**, as anime as possible | Elemental Reaction system is core combat (see Skills doc) |
| 11 | **Dialogue choices**; voice TBD (your call later) | Write all dialogue voice-ready; keep a VO budget slot open |
| 12 | Claude decides comedy/drama | **55% warm/funny early → shifting to 60% serious after Act III** |
| 13 | **Teen-dark, more serious deeper in** (hundreds of hours) | Late-game arcs carry heavier themes: war, loss, the System's cost |
| 14 | Claude picks the first Origin | **Transported** first (cleanest intro to the world, Mochi from minute one) |
| 15 | **Romance for all companions**; **male and female player choices** | Player body type/gender choice; all companions romanceable |
| 16 | **Long grind: SSS ≈ 1,000 hours** | Pacing rebuilt (see Rank doc). Most of the 1,000 hrs must come from **systemic, replayable content**: Labyrinth, rifts, contracts, taming, crafting, chase items |
| 17 | **Exceptional Promotion**: clearing a quest rated far above you can skip a rank, followed by a **Guild Master's trial** | Added to the rank system |
| 18 | **Max level 300** | New level bands per rank |
| 19 | **Respec costly after Lv 10** | Free respec Lv 1–10; after that, rare items + gold + quest |
| 20 | Rethink "secretly OP" → **grind for extremely special items** | New **Relic / Chase Item** system; rank concealment becomes a minor optional item |
| 21 | **12 base classes** | +4 new: **Lancer, Martial Artist, Bard, Occultist** |
| 22 | Switching classes possible but **very difficult and costly** | Class change = quest + rare *Rebirth Sigil* + time penalty |
| 23 | Unique Skills: **some random, some chosen** | Split pool: **Chosen** (pick freely) vs **Fated** (random only, rarer, stronger) |
| 24 | Hidden classes come from **specific scenarios** | Hidden class unlocks rewritten as scenario quests |
| 25 | Game-changing Unique Skills **with many limits** | Each gets cooldowns, costs and counters |
| 26 | **One seamless, huge open world**, lots of regions and travel; Skyrim-like, exploration-heavy | World streaming architecture is the #1 technical risk; discovery density is key |
| 27 | Climbing/gliding tied to **flight-capable characters/abilities** | Basic climbing for all; gliding and flight come from race (Bird-kin, Dragonkin, Fairy), skills or items |
| 28 | **25+ regions** (detail later) | Region list expands from 12 → 25+ in a later pass |
| 29 | **No flying mounts**; flight and teleport are abilities. Underwater "maybe later" | Ground mounts only; flight = skill/race/Transcendence. Underwater → stretch goal |
| 30 | **Towns change permanently**, including getting richer, safer, better built | New **Settlement Prosperity** system |
| 31 | Mostly **menacing**; F-rank has cute ones **and** terrifying ones; research anime rankings | New **Menace** axis separate from Rank (see Bestiary research doc) |
| 32 | **Bosses optional**, rank-based, challengeable any time; the game shows if it's a good match ("good but not easy") | **Boss Suitability rating** on every boss and quest |
| 33 | **Taming = full collector path**: 3 active monsters max, swap for higher-ranked ones over time | Tamer roster: 3 active + ranch storage; evolve, release, trade up |
| 34 | Research monster families from anime | See `08_Bestiary/menace_and_rank_research.md` |

## Combat Pillars (from Q6)
1. **Fluid:** every attack can cancel into a dodge; skills cancel into skills (on a combo budget).
2. **Fast:** quick base speed, dash, air dash, launch → juggle → slam.
3. **Heavy:** hit-stop on impact, camera shake, enemies get knocked back, ground cracks, sound punches.
4. **Flashy:** elemental VFX trails, a short cinematic camera for ultimates, glowing magic circles, screen-wide explosions.
5. **Stylish:** a **Style Rank** meter (C → B → A → S → SS → SSS, fitting our rank theme!) rewards variety; higher style gives bonus XP and drops.
6. **Combinational:** weapon arts + spells + elemental reactions + companion Union Skills chain together.

---
# Answers 35–50 (2026-10-22)
| # | Answer | Design impact |
|---|---|---|
| 35 | **Named monsters evolve and hunt you: 100%.** Monsters **you name** can become **companions** | Named Nemesis system (below); Name-Giving turns a tamed/befriended monster into a full companion |
| 36 | Companions **as anime as possible** | Strong archetypes, signature catchphrases, transformation scenes, anime character theme songs, expressive faces |
| 37 | **Take it slow**: few companions per rank | Companion unlock pacing table (below) |
| 38 | **Companions can die permanently** | Story-choice deaths always; combat permadeath via the *Mortal Bonds* setting (below) |
| 39 | **Full character creator mandatory**, with some presets | Presets are starting points only; everything is editable |
| 40 | No own character ideas yet | — |
| 41 | **Deep crafting with minigames** | Every craft discipline gets a minigame (skippable only after mastery) |
| 42 | **Slow life very important**, built **after combat** | Ring order: combat → exploration → slow life |
| 43 | **In-game day = 60–120 real minutes** | Default **90 min/day** (tunable); rest/sleep skips time; quest timers count in days |
| 44 | Cooking gives **small stat boosts** | Confirmed |
| 45 | Inventory **depends on difficulty**; expansions: Item Box, backpacks, a **pack animal that can die** | Inventory model (below) |
| 46 | **Mostly instrumental**; **rock / J-pop for bosses** | Region and town music is orchestral/instrumental; boss and Ultimate moments get anime-rock/J-pop tracks |
| 47 | **English voices** first | English VO (scope TBD) |
| 48 | **Fantasy frames, but clean**: the classic anime "System window" look | UI style guide (below) |
| 49 | **Don't focus on Steam until near the end** | Steam work deferred; build the game first |
| 50 | Dream Early Access: **January 2027** | See the reality check below |

## Named Nemesis System (Q35)
- A Named monster that **defeats you, or escapes you**, levels up, gains a scar/title, learns a counter to your favorite skill, and may **evolve** a rank.
- It **hunts you**: it shows up on the rumor board, ambushes you in its region, and sometimes follows you to other regions.
- **Resolve it any way:** kill it (relic-grade drop), tame it, or **name it** (Name-Giving Ribbon after earning its respect: win while sparing it, feed it, or save it from a bigger threat) → it becomes a **full companion** with its own voice, personality, arc and evolution.
- Named monster companions count toward the companion roster.

## Companion Pacing (Q37)
| Rank | New companions available | Notes |
|---|---|---|
| F | 1 (Lyra) + Mochi as a pet | Learn the basics |
| E | +1 | First choice (Kiri *or* Sir Aldric) |
| D | +1 | |
| C | +1 | |
| B | +1–2 | First Named-monster companion possible |
| A | +1–2 | |
| S | +1–2 | |
| SS / SSS | +1 | Legendary companions (e.g. Nyx's true form) |
Some companions are **mutually exclusive** (recruiting one closes another's path), so each playthrough's party feels different.

## Mortal Bonds: Companion Death (Q38)
- **Story deaths:** certain choices can get a companion killed, on any difficulty. Permanent.
- **Combat deaths:** a downed companion has a **bleed-out timer**. If it expires: on *Story/Adventurer* they're "gravely wounded" (out for several days); on **Veteran/Hardcore**, or with the **Mortal Bonds** toggle on, they **die permanently**.
- Dead companions get a grave at your home, a memorial scene, and their weapon as an heirloom item. Morrowyn's Lantern (Divine artifact) can bring back exactly **one** fallen companion in the whole game.

## Inventory Model (Q45)
| Difficulty | Base inventory |
|---|---|
| Story | Unlimited bag |
| Adventurer | Weight-limited, generous |
| Veteran / Hardcore | Strict weight; encumbrance slows you and drains stamina |

**Expansions:** backpacks (Satchel → Explorer's Pack → Bag of Holding) · **Item Box** (skill, Unique Skill or relic: weightless storage) · **pack animals** (mule, carry-lizard, giant tortoise, Fluffcap ram) that carry a lot but **can be attacked and killed**, dropping their cargo as a lootable pile monsters may steal · a hireable **Porter NPC** (who can also die).

## UI Style Guide (Q48)
- The classic anime **System window**: translucent blue-glass panels, thin glowing borders, angled corners, small ornate filigree at the corners, crisp sans-serif text with a fantasy display font for headers.
- Pop-ups appear in a burst of runes, with soft chimes (*"Skill acquired!"*).
- Rank colors are consistent everywhere (F grey → SSS gold).
- HUD is minimal in exploration and expands in combat.

## Reality Check: January 2027 (Q50)
January is about **2–3 months away**. At 4–5 hrs/week (~50 hours total), an Early Access 3D open-world RPG isn't achievable by then. What **is** realistic by January:
- **Ring 0 playable prototype:** your VRoid character in a graybox field; run, climb, lock-on/free aim, light/heavy/dodge combos with hit-stop; 2–3 monsters (Slime, Goblin, Horned Rabbit); an elemental combo; the Status Window; level-ups.
That's the first real "it's alive" moment. An honest Early Access window is more like **2028+**, after Ring 1 (the vertical slice) and Ring 2 (all of Aldmere).
