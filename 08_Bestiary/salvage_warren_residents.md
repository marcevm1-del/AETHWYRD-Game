# Salvage Warren residents

Species pages for everything that lives in The Salvage Warren (`dng_salvage_warren`, Great Labyrinth floors 3-4, recommended rank E; layout in `12_Systems/dungeons_and_puzzles.md` §3, spawns in `Data/World/dungeons.json`). Numbers come from `Data/Monsters/species.json` and are not repeated as law here: if they differ, the data wins. This page adds how each species is meant to *read and fight in this place*.

## Who is where

| Room | Residents (min-max) | Role in the room |
|---|---|---|
| Chalk Landing | Kobold Scavenger 1-2, Bone Crawler 1 | Teach the two basic threats: a thing that flees, a thing that hides |
| Scrap Hall | Kobold Miner 1-2, Kobold Sneak 1, Red Slime 0-1 | Hub fight: ambusher, skirmisher, territorial blob |
| Weighing Gallery | Kobold Trapmaster 1, Bone Crawler 1-2 | The key guard: a trap-setter plus hiders |
| Lower Landing | Hollow Mourner 1-2, Red Slime 1 | Quiet, uneasy checkpoint approach |
| Beetle Vault | **Armor Beetle** (boss, no phases) | The one big fight |
| Rune Cistern | none | Secret room stays empty |

The Trapmaster is rank D inside an E dungeon on purpose: it is the one "elite" of the slice and always a single one.

## The Kobolds (family `kobold`, rig `rig_small_biped`)

One family, four jobs. The Warren is a salvage trade, so every kobold carries something it took from someone else; that is the visual thread (sacks, candle helmets, soot, gear harness).

### Kobold Scavenger (F, `mon_kobold_scavenger`)
- **Look:** 0.9 m, slate-blue mangy fur, dog-like head with a chipped snout, a sack of stolen tools. Coin-bright eyes.
- **Behaviour:** Skittish, flees when hurt. Frenzied lunge, thrown junk, stab, trip wire.
- **Weak to:** Fire.
- **How it plays:** The first kobold the player meets. It runs, so it teaches ranged attacks and snares; killing it quickly is the lesson. Its sack is the loot gag (`loot_kobold_f`).
- **Readability:** Smallest silhouette with the biggest ears; the sack makes it the "carrier" shape.

### Kobold Miner (E, `mon_kobold_miner`)
- **Look:** 0.9 m, rust-red fur with ochre marks, a candle helmet and a pick worn smooth.
- **Behaviour:** Ambush. Gains `atk_stone_spike` (Earth); pebbles tremble around it.
- **Weak to:** Wind.
- **How it plays:** Waits near the walls of the Scrap Hall and strikes first. The candle on its helmet is the tell: a flame low against the wall means a miner.
- **Readability:** Warm rust colour against the grey hall; the candle is the only light source it carries.

### Kobold Sneak (E, `mon_kobold_sneak`)
- **Look:** 0.8 m (smallest of the family), soot-blackened slate fur with violet marks, built to vanish in tunnels.
- **Behaviour:** Skittish, circles, flees when hurt. Dark element; shadow grasp.
- **Weak to:** Light.
- **How it plays:** The flanker. A lantern or Light skill strips its cover and ends the fight. Never more than one per room.
- **Readability:** Violet accents and shadow wisps; the only dark-element kobold so it is easy to pick out.

### Kobold Trapmaster (D, `mon_kobold_trapmaster`)
- **Look:** 1.0 m (largest kobold), rust-red spiked fur, a harness of gears, springs and tripwires.
- **Behaviour:** Skittish, flees when hurt. Tripwire trap is its signature attack.
- **Weak to:** Fire.
- **How it plays:** Guards the rusted tally key in the Weighing Gallery. Its traps are telegraphed (visible wires and springs); the fight is about reading the floor, not about damage.
- **Readability:** Gear parts on the joints give it a clearly different silhouette from the other three.

## Bone Crawler (F, `mon_bone_crawler`, family `undead`, rig `rig_aberrant`)
- **Look:** 1.4 m, a skeleton reassembled wrong and crawling on its hands: too many limbs, bleached bone and grave cloth, violet marks, eyes that never blink.
- **Behaviour:** Ambush plus stalker. Mimic voice, unfold, grave and shadow grasp.
- **Weak to:** Light.
- **How it plays:** Hides in the dark corners of Chalk Landing and the Weighing Gallery. Perception and light reveal it before it unfolds. It is the first "check the dark" lesson.
- **Readability:** Pale bone against dark stone; the unfold animation is the warning.

## Hollow Mourner (F, `mon_hollow_mourner`, family `undead`, rig `rig_medium_biped`)
- **Look:** 1.7 m, lean humanoid in a tattered cape, grey-green grave mould, violet marks, pale pupil-less eyes, a weeping figure.
- **Behaviour:** Ambush plus stalker. Slash, heavy swing, guard counter, grave grasp.
- **Weak to:** Light.
- **How it plays:** Haunts the Lower Landing, where the cold draught is the secret's clue. It is sad rather than cruel: it stands where it was left. Tone is warmth over horror; it never jump-scares, it turns around.
- **Readability:** The cape and the slow, still pose; the only tall figure in the Warren.

## Red Slime (E, `mon_red_slime`, family `slime`, rig `rig_blob`)
- **Look:** 0.5 m dome of ember-red gel fading to soot, a faint ember core pulsing like a heartbeat.
- **Behaviour:** Territorial: attacks only if you come near its home. Body slam, engulf, split, acid splash, ember burst.
- **Weak to:** Water.
- **How it plays:** Sits in a fixed spot in the Scrap Hall and Lower Landing. Walking around it is a valid choice; the lesson is that not every monster must be fought.
- **Readability:** The only warm glow in the grey rooms, so its position is obvious from far away.

## Armor Beetle (E+, `mon_armor_beetle`, family `insect`, rig `rig_hexapod`, boss of the Beetle Vault)
- **Look:** 1.2 m six-legged armoured body, amber chitin with ochre marks, a shell like polished bronze, alert animal eyes, pebbles floating near it.
- **Behaviour:** Ambush. Mandible crush, burrow ambush, acid spray, silk snare, stone spike. No phases added for the Warren.
- **Weak to:** Wind. Highest DEF of the roster; slowest (SPD 70).
- **How it plays:** A patient fight against a heavy, slow target. Wind skills and breaking its burrow rhythm are the answer; its shell is the reason the kobolds' salvage heap exists.
- **Readability:** Bronze shell is the brightest metal-coloured thing in the dungeon.

## Ecology notes
- The kobolds are the owners; the undead and the slime are squatters in the lower, colder rooms. Kobolds never share a room with Mourners.
- Light is the dungeon's soft theme: three of the eight species (Bone Crawler, Hollow Mourner, Kobold Sneak) are weak to Light, and the Kobold Miner's candle helmet is the only carried light among the residents, so the Warren rewards bringing a lantern.
- Fire covers the Scavenger and Trapmaster, Wind the Miner and the Beetle, Water the Slime: three element answers for one dungeon, none required.

## Open items (not changed by this page)
- The first-floor look text for the Bone Crawler and Mourner says "assembled from memory"; keep for the whole undead family.
- Species data was not edited: no contradictions between the residents' look text, design recipes and the dungeon data were found.
