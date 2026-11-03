# 05b — The Skill Map (Star Loom) (v0.1, proposal)

> **Status:** design proposal, owned by the class-skill-designer. Nothing here is locked; the summary row is in Canon §6 for the user's OK. It builds on rules that already exist and does not change them: the skill families and proficiency (Lv 1–10, Evolve or Fuse) in `skills_and_magic.md`, the class ladder and Sub-Class in `04_Classes/base_and_advanced.md`, mastery without grind in `04_Classes/progression_experience.md`, class affinity (borrowed feature #2) and the "woven constellation" Skills tab in `12_Systems/hud_and_ui.md`. Kit levels and numbers stay in `Data/Classes/classes.json`.

## 1. What other games in the genre do (mechanics only)
We take patterns, never names, art, text or data (`13_Production/reference_games.md` rule).

| Pattern | Seen in | What works | What goes wrong |
|---|---|---|---|
| **Linear class kit** (skills unlock at set levels) | Most action JRPGs, MMOs | Easy to read; each level feels like a gift | No choice; two players of one class are identical |
| **Branching talent tree** (points into 3 branches) | Western ARPGs, MMO talent trees | Real build identity; "I'm a counter Swordsman" | Trap nodes, +2% filler, a single "correct" build online |
| **Shared grid / board** (one big map all characters walk) | Classic JRPG grids and licence boards | Feeling of a journey; any character can drift into any role | Roles blur; huge boards are tiring to plan |
| **Huge passive web** (hundreds of small nodes, a few keystones) | Hardcore ARPGs | Endless theory-crafting; keystones change the rules | Overwhelming; most nodes are dull numbers |
| **Use-based skill trees** (doing a thing levels its tree) | Open-world fantasy RPGs | Natural, no menu planning; trees drawn as constellations | Grind by repetition (jumping in place, casting at walls) |
| **Arte evolution and fusion** (use a move enough and it evolves; two mastered moves combine) | Anime action JRPG series | The anime "my technique grew" moment | Hidden requirements; players never find fusions |
| **Variant picks per skill** (each move gets 2–3 upgrade options, pick one) | Modern ARPGs, hero shooters | Choice without a giant tree; each pick changes how a move plays | Too many tiny choices if every skill has them |
| **Job borrowing** (learn abilities in one job, equip them in another) | Job-system JRPGs, vocation RPGs | Rewards trying every class; old work never wasted | Strong combos can break balance |
| **Character "constellations"** (dupes or story unlocks add stars) | Gacha action RPGs | Beautiful presentation | Pay-to-unlock; we reject the monetisation, keep only the look |
| **Weapon-defined moves** (the weapon is the class) | Hunting action games | Deep weapon feel | Little character growth outside gear |

**What we take:** the constellation look, three branches with a few keystones, per-skill variant picks, use-based evolution and fusion, and job borrowing. **What we reject:** filler +2% nodes, repetition grind, paid or random unlocks, and one shared board that blurs the 12 class identities.

## 2. The Star Loom in one paragraph
Every class is a **constellation** on the Skills tab. Its centre star is the **Class Mechanic** (Edge Flow, Bulwark, Chant…). Three **branches** run out from it, each a playstyle. Active skills are **bright stars** that light up at their kit level as now; between them sit **minor stars** (passives and branch perks) the player buys with **Sparks**. Each active has two **Facets** (variant picks). At the end of each branch is a **Keystone** that bends a rule. Using a skill fills its proficiency; at Lv 10 its star grows an **Evolve** ring, and where two Lv 10 threads cross, a **Fusion** star appears (the UI already draws this). Advanced classes hang off the base constellation; borrowed skills sit in it as **guest stars**.

## 3. Pieces
| Piece | Look | How you get it | Rule |
|---|---|---|---|
| **Core star** | Large rune in the centre | Choosing the class | The class mechanic. Never costs Sparks |
| **Bright star** (active) | White-gold star | Class level = kit `unlockLevel` (unchanged) | Free. Equip in a skill slot |
| **Facet** | Two small points beside a bright star | Skill proficiency Lv 3 (Facet A or B) | Pick one; swap free outside combat. Changes how the move plays, not just its numbers |
| **Minor star** (passive / perk) | Small blue star on a branch | 1 Spark each | Must touch a lit star. Every minor star changes a behaviour or adds a clear number the player can feel (no +2% filler) |
| **Keystone** | Large star at the branch tip, ringed | 3 Sparks, and class Lv 25 | Bends a rule; has a drawback. **Only one Keystone per class constellation may be active** |
| **Evolve ring** | Ring around a bright star | Skill proficiency Lv 10 + one evidence event (§5) | Upgrade the move (Fire Bolt → Inferno Lance). Keeps both Facets' choice |
| **Fusion star** | Star where two threads cross | Two Lv 10 skills from the fusion table, and an attempt at a shrine or trainer | A new skill. **The player names it**, and the System comments |
| **Guest star** | Star in another class's colour | Class Affinity 10 with a companion (borrowed feature #2) | One borrowed skill per guest slot (2 slots; 3 at A rank) |
| **Ultimate** | Crown at the top of the map | Class Lv 30 of that tier (unchanged) | One Ultimate equipped |

## 4. Sparks (the only point currency)
- **1 Spark every 2 class levels** (Lv 2, 4 … 30 = 15), **+1 for the class quest**, **+1 for each trainer test** (one per branch, short practical tests from `progression_experience.md`), **+1 for each of the first 3 skills mastered to Lv 10**. That is **22 Sparks per tier**.
- A base constellation costs **33 Sparks** in total (8 minor stars per branch = 24, plus 3 Keystones × 3 = 9). With 22, the player fills about **two branches and dips into the third**, and takes **one** Keystone. Builds differ, but nobody is starved; levelling the class further than 30 never adds Sparks (no grind wall).
- Sparks belong to the **class tier** they were earned in. Advanced Sparks buy Advanced stars.
- **Respec (Canon §5, unchanged):** free to Lv 10; then gold at the Shrine of Ilvaris, plus one free token per class-tier change. Respec refunds Sparks and Facets; it never removes learned skills, proficiency or Evolves.

## 5. Proficiency without grind
Proficiency (Lv 1–10) rises from **varied use**, not repetition, in the mastery bands of `progression_experience.md`:
- **Learned (Lv 1–3):** use in real fights. Hits on training posts count only up to Lv 3.
- **Practiced (Lv 4–7):** use that "does its job": a launcher that launches, a counter that counters, a heal that saves an ally under 30% HP. Against foes at your rank or above it counts in full; far below your rank, a tenth.
- **Mastered (Lv 8–10):** the same, plus one **evidence event** for Lv 10 from any of: an elite or boss kill, the trainer's test, a story encounter, or a skill challenge on the guild board. Several routes, none random.
- Diminishing returns per fight stop spamming one move; the Style meter already rewards variety.

## 6. Loadout
- **4 skill slots + a second palette of 4** (RB+LB, per `hud_and_ui.md`) **+ 1 Ultimate**. Basic string is fixed by weapon.
- With a **Sub-Class** (C rank): 2 of the 8 slots may hold Sub-Class actives; Sub-Class minor stars give 50% (unchanged rule), and its Keystones are locked.
- **Weapon Arts** sit on a small **weapon ring** per weapon type (5 stars, by weapon mastery) at the edge of the map and share the same slots.
- **Monster, Racial, Unique and Extra skills** get their own outer band of stars; they do not cost Sparks.

## 7. The class ladder on the map
```
                      ✦ Ultimate (Lv 30)
                 ╱        │         ╲
        Keystone A    Keystone B    Keystone C
            │             │             │
        branch A      branch B      branch C
             ╲            │            ╱
                   ◉ Core star (Class Mechanic)
                          │
        ┌─────────────────┴─────────────────┐
   Advanced A constellation          Advanced B constellation
   (opens at D; links to branch A)   (opens at D; links to branch C)
```
- An Advanced class **grows out of the branch it fits**: Blademaster from Swordsman's Flow branch, Berserker from its Fury branch. A player who built that branch gets **1 Spark back** in the new tier, a welcome, not a requirement.
- Expert, Master and Legendary constellations stack outwards the same way. The base map stays visible and lit; old skills keep working (Canon §5; an off-class skill at 50% per the class change rule).

## 8. Worked example: Swordsman
Core: **Edge Flow** (Flow 0–5, +6% attack speed per stack).

| Branch | Playstyle | Bright stars (kit) | Minor stars (1 Spark each, examples) | Keystone (3 Sparks) |
|---|---|---|---|---|
| **Flow** (speed) | Never get hit, keep the chain | Slash Chain, Flash Step, Air Slash | *Flowing Step*: dodging keeps Flow · *Edge Wind*: at 5 Flow, Air Slash pierces · *Sidestep* (kit passive) · *Quick Sheath*: weapon swap keeps 1 Flow | **Unbroken Flow**: Flow caps at 8, but a hit drops all of it |
| **Fury** (power) | Trade hits, hit harder | Guard Break, Whirlwind, Thousand Petal Blade | *Fighting Spirit* (kit passive) · *Heavy Edge*: Guard Break breaks 1 more poise bar · *Blood in the Wind*: Whirlwind lasts while SP lasts · *Grit*: getting hit drops 1 Flow, not 2 | **Wounded Tiger**: below 40% HP, Flow fills by being hit instead of hitting |
| **Counter** (timing) | Wait, read, punish | Rising Cut, Parry Riposte | *Sword Mastery* (kit passive) · *Read the Blade*: parry window +2 frames · *Answer*: a perfect dodge refreshes Rising Cut · *Second Riposte*: two parries in 3 s chain a free cut | **Mirror Stance**: parry is your block; no guard, but every parry gives 2 Flow |

**Facets (examples):** Rising Cut — *A: Skyward* (launch higher, follow into the air) or *B: Pommel Rise* (no launch, a stagger on the ground for heavy foes). Flash Step — *A: Through* (passes through, hits all in line) or *B: Return* (dash, cut, and step back to where you started).

**Evolves (Lv 10):** Air Slash → *Moon-Splitting Wave* · Whirlwind → *Tempest Blade* · Parry Riposte → *Heaven's Reply*. **Fusions** use the existing table (Sword Mastery + Fire Magic → Flame Blade Arts; Dash + Lightning Step → Godspeed; Parry + Counter → Perfect Reversal).

## 9. Branches for the other 11 base classes
Bright stars are the current kits; the class-skill-designer fills the minor stars and Facets in the same shape as §8.

| Class (core) | Branch A | Branch B | Branch C | Keystone ideas (one each) |
|---|---|---|---|---|
| Guardian (Bulwark) | **Bastion**: block and hold | **Oath**: protect allies | **Rampart**: shield offence | *Immovable* (can't be staggered, can't dodge) · *Shared Wound* (Guardian's Oath links 2 allies) · *Shield Storm* (Bulwark spends become shockwaves) |
| Mage (Chant) | **Sear**: fire and lightning burst | **Tide**: water and ice control | **Stone**: earth and wind shaping | *Overchant* (a tier higher, can't move while chanting) · *Still Water* (frozen foes take all elements) · *Living Ground* (walls and spikes stay twice as long) |
| Cleric (Devotion) | **Mercy**: healing | **Ward**: shields and cleanses | **Judgment**: holy damage | *Martyr* (heals cost your HP, not MP) · *Sanctum* (Sanctuary follows you) · *Zeal* (holy hits heal the lowest ally) |
| Rogue (Shadow) | **Veil**: stealth | **Venom**: poison and bleed | **Trick**: steal and disarm | *Ghost* (re-enter stealth on every kill, half crit damage) · *Toxin Heart* (poisons stack without limit, slower ticks) · *Light Fingers* (every Steal also applies a debuff) |
| Ranger (Focus) | **Hawk**: long range | **Wild**: traps and terrain | **Wind**: mobile shooting | *Deadeye* (Pierce only, no basic shots) · *Snare Field* (2 extra traps, traps arm slower) · *Running Fire* (no Focus, full damage while moving) |
| Tamer (Bond Slots) | **Bond**: one strong partner | **Pack**: many partners | **Command**: orders and swaps | *Soulmate* (1 slot, partner +60% stats) · *Swarm* (+1 slot, partners 25% weaker) · *Conductor* (Swap is free and staggers) |
| Artisan (Gadgets) | **Forge**: weapon and armour boosts | **Clockwork**: turrets | **Powder**: bombs | *Masterwork* (one gadget, quality ×2) · *Factory* (turret cap +2, half health) · *Short Fuse* (bombs explode instantly, hurt you too) |
| Lancer (Momentum) | **Charge**: line attacks | **Sky**: aerial | **Reach**: zone control | *Unstoppable* (Momentum never decays while running, can't sidestep) · *Skyborn* (one extra air jump, ground skills cost more) · *Pike Wall* (Sweep keeps foes at range, no launches) |
| Martial Artist (Combo Chain) | **Storm**: speed strings | **Iron**: body and counters | **Sky**: juggles | *Endless Chain* (chain doesn't drop for 3 s after a hit, finishers weaker) · *Stone Body* (take hits without flinching, slower dodge) · *Heaven's Ladder* (juggled foes fall slower) |
| Bard (Rhythm) | **Anthem**: buffs | **Discord**: debuffs and control | **Encore**: charm and finales | *Perfect Pitch* (on-beat window halved, effects ×1.5) · *Cacophony* (songs stack, off-beat hits hurt you) · *Standing Ovation* (Grand Finale returns at half cooldown) |
| Occultist (Corruption) | **Hex**: curses | **Thrall**: summons | **Hunger**: life drain | *Bloom of Rot* (curses spread on kill, Corruption never falls) · *Legion* (+2 shades, they fade in 20 s) · *Feast* (drain overheals into a shield, no MP regen) |

## 10. How it shows on screen (for the ux-designer)
- The Skills tab already is a woven constellation (`hud_and_ui.md`). Lit threads glow; hovering a star shows the move in a small looping preview, its proficiency band and what it needs next.
- **Plan mode:** tap stars to queue them without spending; the map shows Sparks left. Press confirm to spend.
- **No trap nodes:** every star says in one line what changes in play. The System Voice comments on Keystones ("Bold. I've noted your funeral preferences, just in case.").
- **Discovery:** fusion stars show as faint dust once one of the two skills is Lv 10, so players can find them without a wiki.
- Controller: stick moves between stars along threads; bumpers switch constellations (base, Advanced, Sub, Weapon, Outer band).

## 11. Data shape (when approved)
A new `Data/Classes/skill_map.json` with a schema, built by `Tools/classes/build_classes.js` next to `classes.json`:
```json
{ "classId": "cls_swordsman", "core": "Edge Flow",
  "branches": [ { "id": "flow", "name": "Flow",
    "stars": [ { "id": "skl_flash_step", "type": "active", "links": ["core"] },
               { "id": "prk_flowing_step", "type": "minor", "cost": 1, "links": ["skl_flash_step"], "effect": "Dodging keeps Flow" } ],
    "keystone": { "id": "key_unbroken_flow", "cost": 3, "minLevel": 25, "effect": "Flow caps at 8; a hit drops all Flow" } } ],
  "facets": { "skl_rising_cut": ["Skyward", "Pommel Rise"] } }
```
Core rules (`Code/Ascend.Core`) get a `SkillMap` with tests: Spark budget per tier, adjacency, one Keystone, respec refunds, guest-slot limits.

## 12. Production slice
1. **Ring 0:** Swordsman map only (§8), Sparks and minor stars; no Facets or Keystones yet. Keeps the scope one class.
2. **Ring 1:** all 12 base maps, Facets, Keystones, the Evolve ring for the 3 most used skills per class.
3. **Ring 2:** Advanced constellations, guest stars, fusion discovery.

## 13. Open decisions (do not lock silently)
- Is one active Keystone per class right, or one per tier?
- Should Sparks also come from region liberations (ties the map to the world), or stay class-only?
- Do Facets unlock at proficiency Lv 3 or at a trainer lesson?
- The 24 Advanced constellations: branches and Keystones need a design pass.
