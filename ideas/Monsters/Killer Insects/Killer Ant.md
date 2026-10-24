---
type: monster
id: mon_killer_ant
family: "Killer Insects"
rank: "E"
tier: core
tags: [monster, killer-insects]
---
# Killer Ant

> The Killer Ant is a small creature with a segmented six-limbed frame, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in muted greys and dusty browns. Its most striking feature is a pale soldier ant with a jaw that never stops working. It has pale, pupil-less eyes. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1754 · 114 · 171 · 48 · 114 · 70 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 44 kg, gravity ×1.4, poise 44, knockback resistance 0.28, death style `flip_legs_curl`.
- **Navigation:** speed 3.6 m/s, turn 500°/s, stopping distance 0.54 m.
- **Attack count:** 4; **signature:** a pale soldier ant with a jaw that never stops working.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Killer Ant is a **dread insectoid** encountered at E rank, around level 26. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a pale soldier ant with a jaw that never stops working. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects E|loot_killer_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Thorn Killer Ant|Thorn Killer Ant]]
- [[Monsters/Killer Insects/Radiant Killer Ant|Radiant Killer Ant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F+, D-, E+, D | 13–48 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | F+, D-, E+ | 13–40 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | E+, D, D- | 32–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00730` | Whisperwood Killer Ant Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.7 m | Night | Like a typical Killer Ant, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00731` | Aldmere Killer Ant Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.7 m | Night | Like a typical Killer Ant, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00732` | Whisperwood Killer Ant Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 1.25 m | Night | Like a typical Killer Ant, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00733` | Great Labyrinth (Floors 1-40) Killer Ant Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 1.1 m | Night | Like a typical Killer Ant, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00734` | Great Labyrinth (Floors 1-40) Killer Ant Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 1.35 m | Night | Like a typical Killer Ant, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00735` | Aldmere Killer Ant Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.25 m | Night | Like a typical Killer Ant, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00736` | Aldmere Killer Ant Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 1.1 m | Night | Like a typical Killer Ant, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00737` | Whisperwood Killer Ant Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 1 m | Night | Like a typical Killer Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_00738` | Whisperwood Killer Ant Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 1.35 m | Night | Like a typical Killer Ant, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00739` | Aldmere Killer Ant Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 1 m | Night | Like a typical Killer Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_00740` | Great Labyrinth (Floors 1-40) Killer Ant Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 1.25 m | Night | Like a typical Killer Ant, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · elongated, irregular silhouette; still-then-sudden timing
