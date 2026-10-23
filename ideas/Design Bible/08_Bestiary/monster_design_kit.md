# 08e — Monster Design Kit (v0.6)

**Goal:** 600+ species and 6,000+ population variants that a two-person team can actually build. The approach: **few skeletons, many parts, systematic variation**. That's how the genre's long-running monster series do it.

## 1. Research: How Anime & Games Build Big Monster Rosters
| Source | What they do | What we take |
|---|---|---|
| **Dragon Quest** (Toriyama) | The slime's simple teardrop silhouette spawned a whole family through **palette swaps** (She-Slime was the series' first palette swap) and **shape variants** (the cube-shaped Box Slime, later in stone variants) | One strong base silhouette → many color and shape variants |
| **Monster Hunter** | Monsters are grouped into **classes** (e.g. wingless Brute Wyverns, primate-like Fanged Beasts) that set their core traits; fans observe that monsters share **skeletons and base movesets**, with new moves added for identity; designs are grounded in researched ecology | **Shared rigs ("body plans")** per class; ecology first |
| **Shape language** | Players read silhouettes and motion before details, so test readability early; circles read as friendly, triangles as aggressive, irregular shapes as unsettling (common in horror); anime/fantasy favors flowing curves with controlled spikes; keep shape logic consistent within a faction | **Menace axis = shape language**; family-consistent shapes |
| **Goblin Slayer / DanMachi / Tensura** (earlier research) | Weak monsters can be terrifying; evolution chains (goblin → hobgoblin → champion → king); out-of-place "irregulars" | Evolution chains; Menace independent of Rank |

Sources: [Slime (Dragon Quest), Wikipedia](https://en.wikipedia.org/wiki/Slime_(Dragon_Quest)) · [She-Slime](https://dragon-quest.org/wiki/She-Slime) · [Box slime](https://dragon-quest.org/wiki/Box_slime) · [Shadow slime](https://dragon-quest.org/wiki/Shadow_Slime) · [MH creature design art book (Staffordshire)](https://gradex.staffs.ac.uk/wp-content/uploads/2025/04/5054_Artbook.pdf) · [Siliconera: MH Generations flagship design](https://www.siliconera.com/doodles-hunt-making-monster-hunter-generations-flagship-monsters/) · [Steam discussion: MH skeleton reuse](https://steamcommunity.com/app/582010/discussions/0/1638662230363915983/?ctp=1) · [Nintendo Life: MH Rise skeleton variety](https://nintendolife.com/reviews/nintendo-switch/monster_hunter_rise) · [RocketBrush: shape language](https://rocketbrush.com/blog/shape-language-in-game-character-design-how-to-make-characters-readable-and-consistent) · [Ulster: creature silhouettes](https://blogs.ulster.ac.uk/b00888684-bdes-animation/category/year-2/page/2)

## 2. The Recipe: Every Monster = 7 Choices
```
BODY PLAN (rig) + PARTS (2–4 from the rig's library) + COVERING (family material)
+ PALETTE (from element) + MENACE STYLE (shape language) + RANK ORNAMENT + VFX (from element)
```
This recipe is stored in every species entry (`design_recipe`), so building a monster means following its card.

## 3. The 25 Body Plans (shared rigs)
Each rig is **one skeleton + one animation set** in Unity. Build these 25 once and reuse them for every monster.
| Rig | Used by | Animation set |
|---|---|---|
| `blob` | Slimes | bounce, squash, split, engulf |
| `small_biped` | Goblins, kobolds, gremlins, gnomes | scurry, stab, throw, cower |
| `medium_biped` | Humanoids, undead, lycans, demons | walk, slash, cast, block |
| `large_biped` | Ogres, giants, minotaurs, oni | stomp, slam, grab, roar |
| `quad_small` | Rabbits, foxes, familiars | hop, dash, bite, flee |
| `quad_large` | Wolves, bears, drakes, griffons | pounce, maul, howl, charge |
| `hexapod` | Ants, beetles, crabs | skitter, bite, sting, burrow |
| `octopod` | Spiders, arachne | skitter, leap, web, ceiling-walk |
| `serpent` | Snakes, worms, hydras, centipedes | coil, strike, constrict, burrow |
| `wyvern` | Wyverns, gargoyles, arch demons | fly, dive, tail-whip, breath |
| `dragon` | Dragons, Elder & Ancient dragons | fly, breath, claw, roar |
| `avian` | Birds, harpies, tengu | fly, swoop, peck, screech |
| `flyer_small` | Imps, bats, pixies, wasps | hover, dart, bite, swarm |
| `floating` | Ghosts, wisps, elementals, liches | drift, phase, wail, lunge |
| `plant_rooted` | Man-eaters, thornvines | snap, lash, spore-burst, retract |
| `plant_walker` | Treants, mushrooms, mandrakes | lumber, sweep, root-slam, regrow |
| `golem` | Golems, sentinels | march, slam, guard, overload |
| `taur` | Centaurs, scorpion riders | gallop, trample, spear, bow |
| `naga` | Lamia, naga, sirens, merfolk | slither, coil, cast, strike |
| `cephalopod` | Octopi, krakens | grab, ink, pull, submerge |
| `fish` | Sea monsters, leviathans, sky whales | swim, lunge, leap, thrash |
| `swarm` | Piranhas, scarabs, fireflies | flow, surround, engulf, scatter |
| `mimic` | Chest/door mimics | idle-disguise, reveal, chomp, scuttle |
| `aberrant` | Horror family | crawl, unfold, mimic, lunge |
| `headless` | Dullahans, headless riders | ride, sweep, throw-head, charge |

## 4. Menace Styles (shape language)
| Menace | Shapes | Eyes | Animation timing |
|---|---|---|---|
| 1 Charming | Circles, soft curves | Big, glossy | Bouncy, squash-and-stretch |
| 2 Wild | Real-animal silhouettes, one fantasy exaggeration | Natural | Naturalistic |
| 3 Menacing | Triangles, spikes, scars, armor | Narrow, glowing | Heavy wind-ups, fast strikes |
| 4 Dread | Elongated limbs, wrong proportions | Unblinking, too wide | Still, then sudden |
| 5 Horror | Broken symmetry, mimicry, extra mouths/eyes | Too many or none | Unpredictable, audio-led |

## 5. Rank Ornament (how power reads at a glance)
F plain · E scars · D a signature marking · C armor or trophies · B glowing runes · A elegant crest + mana veins · S a regal silhouette with an aura ring · SS outline distorts reality · SSS/EX world-scale presence. **Higher rank = more ornate and more elegant**, the anime convention (flowing curves plus controlled spikes).

## 6. Element → Palette & VFX
Every element has a fixed 3-color palette and VFX preset (see the generator). An **Ice variant** of any monster is the same mesh with the Ice palette, frost VFX and one ice part (crystal spikes).

## 7. Variation Layers (how 275 core designs become 600+ species and 6,000+ population)
| Layer | Example | Cost |
|---|---|---|
| **Core species** (275 hand-written) | Goblin | New parts or mesh |
| **Species variants** (elemental, elder, corrupted, ancient, spirit, regional) | Frost Goblin, Elder Goblin, Vesper-Touched Goblin | Palette + 1 part + VFX |
| **Population variants** (region × age/marking tier) | Sunscar Goblin Alpha, Frostveil Goblin Runt | Scale + texture tint + decals |

## 8. How to Build a Monster in Blender → Unity (workflow)
1. Pick the **rig** from the species card; open its base mesh `rig_base.blend`.
2. Attach the listed **parts** to the rig's sockets (horns, armor, tails, etc. from the part library).
3. Apply the **family material** and set the 3 palette colors.
4. Apply **menace shape tweaks** (proportion sliders: limb length, eye size, spikes).
5. Add **rank ornament** decals or emissive runes.
6. Export to Unity; the importer reads `species.json` and attaches **VFX** and stats automatically.
I (Claude) can script steps 1–5 in Blender through the Blender connection once the base meshes and parts exist.

## 9. Data Files
| File | Rows | Contents |
|---|---|---|
| `Data/Monsters/species.json` / `.csv` | 640 | Species: level, stats, attacks, AI pattern, rig/anim IDs, loot table, ring, 2–5 habitats, look, design recipe |
| `Data/Monsters/population.json` / `.csv` | 6,714 | Population variants: region, tier, rank, level, size, ring, look delta, spawn time |
| `Data/Monsters/attacks.json` | 84 | Shared attack library referenced by species |
| `Data/Monsters/loot_tables.json` | 221 | Loot tables (family × rank) with decimal `chance` (0.001 = chase drop) → `Data/Items/materials.json` |
| `08_Bestiary/bestiary_viewer.html` | — | **Filterable viewer** (search, family, rank, menace, element, ring, region). Run `npm run viewer`, open http://localhost:8137 |
| `Tools/monster_gen/families.js` | 287 cores | **Edit here**, then `npm run build` (regenerates + validates) |
| `08_Bestiary/bestiary_lore.md` | — | Hand-written flavor text per family |

## Attack Variety (v0.11)
Rig attack sets are shared: **132 species use the medium-biped trio Slash / Heavy Swing / Guard Counter.** To keep families distinct, every family now adds one **signature attack** (`FAMILY_SIGNATURE` in `Tools/monster_gen/generate.js`): goblins *Sand Toss*, kobolds *Trip-Wire Trap*, beasts *Rending Bite*, undead *Grave Grasp*, slimes *Acid Splash*, and so on for all 31 families. A test checks that every family on a shared rig has at least one attack no other family on that rig has. Next step (per species, later rings): unique boss and Tyrant movesets.

---
# Part 2 — Rank, Menace & Bosses
## What the genre does (research summary)
| Pattern seen in anime/LN | Example | What we take from it |
|---|---|---|
| **Letter ranks double as threat levels** | Fan and canon guild systems rank adventurers F→S and use the same letters for monster danger; S often means "civilization-ending" | ✅ Already core: same scale for monsters and people |
| **Metal-plate ranks** | *Overlord*-style plates: copper/iron for novices up to adamantite legends | ✅ Our guild cards use metals per rank |
| **Quests up to one rank above** | Common guild rule | ✅ Already in the GP rules |
| **Early dungeon floors aren't safe** | *DanMachi*: floors 1–4 have goblins/kobolds, but floors 5–7 bring War Shadows and Killer Ants, and inexperienced adventurers die there. Minotaurs appear from floor 15; floors 29–36 need Lv 3+ | ✅ **Danger spikes inside a rank band**, plus "irregular" monsters out of place |
| **Weak monsters as horror** | *Goblin Slayer*: goblins (the "weakest" monster) are shown as terrifying in groups and in the dark, with hobgoblins, champions and ogres escalating | ✅ **Low rank ≠ cute.** Swarm and context make F-rank monsters horrifying |
| **Cute slimes** | *Tensura* (from *Dragon Quest*'s first, weakest enemy) made cute slimes a genre staple | ✅ Slimes stay the cute F-rank mascot… mostly |
| **Monsters that evolve into calamities** | *Tensura*'s Orc Disaster: an orc that devoured a powerful being and became a proto-Demon Lord | ✅ Named monster evolution, Orc Disaster-type events |

Sources: [Overlord guild ranking (fan lore)](https://fables.gg/worlds/overlord-kono-sekai-cjuxtogis5tm/lore/the-adventurer-s-guild-ranking) · [Isekai hero ranks (fan lore)](https://fables.gg/worlds/an-isekai-story-sf7yeaot2gr2/lore/hero-ranks) · [DanMachi 10th floor (wiki)](https://danmachi.fandom.com/wiki/File:10th_Floor.png) · [DanMachi Vol.1 discussion](https://community.wanikani.com/t/danmachi-volume-1-week-1/41912?page=2) · [Slime (monster), Wikipedia](https://en.wikipedia.org/wiki/Slime_(monster)) · [Goblin Slayer's most powerful monster (Looper)](https://www.looper.com/661309/this-is-the-most-powerful-monster-in-goblin-slayer) · [Scariest isekai monsters](https://thefilibusterblog.com/top-ranked-scariest-monsters-from-isekai-anime/)

## Two Axes: RANK and MENACE
**Rank** = how strong it is (F → EX). **Menace** = how it looks and feels. They are independent.

| Menace | Look & feel | Audio | Example F | Example S |
|---|---|---|---|---|
| **1 · Charming** | Round, bright, big eyes | Squeaks, boings | Blue Slime | Phoenix |
| **2 · Wild** | Natural animal threat | Growls, wingbeats | Horned Rabbit | Silver Fenrir |
| **3 · Menacing** | Sharp silhouettes, glowing eyes, scars | Low roars, armor clank | Goblin Raider | Demon Knight |
| **4 · Dread** | Wrong proportions, unsettling motion | Silence, then a scream | Hollow Mourner | Lich |
| **5 · Horror** | Body horror, mimicry, things in the dark | Whispers, your companions' voices | Skinwalker Mimic | Nameless Abomination |

**Rules**
- Every zone, even an F zone, mixes menace levels. **Daytime meadows lean 1–2; night, caves and ruins lean 3–5.**
- Dread/Horror F-rank monsters are **weak if you understand them** (light, fire, a sound cue) and **lethal if you panic**.
- **Swarm rule:** an F-rank monster in groups of 8+ raises the encounter's effective threat by up to two ranks (the *Goblin Slayer* lesson).
- **Irregulars:** about 1% chance for a monster 2–3 ranks above the zone to appear (the *DanMachi* minotaur-on-a-low-floor moment). The Guild posts an emergency notice afterward.

## F-Rank Roster Across All Menace Levels (new)
| Monster | Menace | Habitat | Behavior | The trick |
|---|---|---|---|---|
| Blue Slime | 1 | Everywhere | Passive | The tutorial friend |
| Puffcap Mushroom | 1 | Forests | Passive, sneezes spores | Spores make you giggle (confuse) |
| Horned Rabbit | 2 | Meadows | Rams when cornered | Rookie killer #1 |
| Forest Wolf | 2 | Forests | Pack | Surrounds you |
| Kobold Scavenger | 3 | Mines, ruins | Pack, steals | Dog-headed scavengers with stolen tools |
| Goblin Raider | 3 | Camps, caves | Pack, ambush, traps | **Not cute.** Cruel, clever, numerous |
| Grave Rat Swarm | 3 | Crypts, sewers | Swarm | Fire scatters them |
| Hollow Mourner | 4 | Night roads | Stands still, weeping; moves only when unseen | Keep your camera on it |
| Lantern Leech | 4 | Swamps | Glows like a lost traveler's lantern | Lures you into the water |
| Bone Crawler | 4 | Battlefields | Skeleton reassembled wrong, crawling on hands | Collapses if you break the skull |
| Skinwalker Mimic | 5 | Woods at night | Mimics companion voices calling you | Real companions stay at your side; check the party UI |
| Door Mimic | 5 | Dungeons | Not a chest. **A door** | Doors don't breathe. Listen |
| The Smiling Scarecrow | 5 | Farms (Millbrook) | Is in a different field every night | Burn it at dawn |

## New Families From Research (added to the roster)
| Family | Rank band | Menace | Members (F → EX) |
|---|---|---|---|
| **Kobolds** | F–C | 3 | Kobold Scavenger → Kobold Miner → Kobold Shaman → Kobold Warlord |
| **Minotaurs & Beastmen** | D–S | 3 | Calf Minotaur → Minotaur → Labyrinth Minotaur → Asterion-type King (ours: **Taurgrim**) |
| **Lycanthropes** | D–S | 4 | Werewolf → Moon Beast → Blood Vesper Alpha → Fenrir-blooded |
| **Killer Insects** | E–B | 4 | Killer Ant → Hornet Lancer → Queen's Guard → Hive Tyrant |
| **Shadows (dungeon-born)** | E–A | 4 | Shadow Wisp → War Shadow → Shade Knight → Umbral Reaper |
| **Lamia, Naga & Serpentfolk** | C–S | 3 | Lamia → Naga Priestess → Serpent Empress |
| **Centaurs** | C–A | 2 | Centaur Scout → Centaur Lancer → Centaur Khan (often neutral) |
| **Dullahans & Headless** | C–S | 4 | Headless Rider → Dullahan → Pale King's Herald |
| **Cyclopes & Giants** | B–S | 3 | Cyclops → Stone Cyclops → Titan-spawn |
| **Gremlins & Imps** | F–C | 2–3 | Gremlin → Saboteur → Gremlin King (breaks your gear) |
| **Aberrations (Horror family)** | F–EX | 5 | Skinwalker Mimic → Faceless One → The Many-Mouthed → Nameless Abomination |
| **Yokai-inspired spirits** (Eastern Isles, original designs) | F–S | 1–5 | Umbrella spirit (1) → Lantern ghost (3) → Long-neck lady (4) → Oni (3) → Nine-tailed Vixen Queen (2) |
| **Dungeon "Floor-born"** | Any | 3–4 | Monsters born from dungeon walls; endless respawn; no drops except cores |

Total families: **28** (16 original + 12 new). Target **~300 base monsters**, **800+ with variants**.

## Zone Composition Rule (per region)
```
Daytime:   60% Charming/Wild · 30% Menacing · 10% Dread
Night:     25% Wild · 40% Menacing · 25% Dread · 10% Horror
Caves/Ruins: 10% Wild · 40% Menacing · 35% Dread · 15% Horror
Blood Vesper: shift everything one Menace level up
```

## Boss Suitability Rating
Every boss and high-tier quest shows a rating based on your level, gear and party:
| Rating | Meaning | Color |
|---|---|---|
| **Trivial** | Way below you | Grey |
| **Comfortable** | You'll win | Green |
| **Worthy** ✦ | *"A good challenge for you, but not easy."* Recommended | Gold |
| **Perilous** | Possible with great play | Orange |
| **Deadly** | Very unlikely | Red |
| **Hopeless** | Don't | Black with a skull, plus the "Oppressive Aura" effect |
You can always attempt any boss. Winning above your rating counts toward **Exceptional Promotion**.
