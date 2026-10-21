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
| `Data/Monsters/species.json` / `.csv` | 600+ | Full species with look description and design recipe |
| `Data/Monsters/population.csv` / `.json` | 6,000+ | Named population variants: region, tier, rank, size, look delta, spawn |
| `08_Bestiary/species_catalog.md` | 600+ | Readable catalog grouped by family |
| `Tools/monster_gen/generate.js` | — | The generator. Edit it and rerun `node Tools/monster_gen/generate.js` |
