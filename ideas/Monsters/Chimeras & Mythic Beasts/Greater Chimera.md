---
type: monster
id: mon_greater_chimera
family: "Chimeras & Mythic Beasts"
rank: "A+"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Greater Chimera

> The Greater Chimera is a huge creature with a powerful four-legged hunter's body, about 5.6 m long. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is lion, goat and serpent heads on one body. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by heat-shimmer and drifting sparks. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Chimera\|Chimera]] (elder) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 5.6 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 35351 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zarvan\|Zarvan]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.64 m high × 5.6 m long × 0.9 m wide; prefab scale 1.4.
- **Physics:** 3512.3 kg, gravity ×1.2, poise 145, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 8.63 m/s, turn 135°/s, stopping distance 1.52 m.
- **Attack count:** 5; **signature:** lion, goat and serpent heads on one body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Chimera is a **menacing mythic beast** encountered at A+ rank, around level 159. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** lion, goat and serpent heads on one body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Sunscar|Sunscar]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts A|loot_chimera_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 2 | A, S | 146–188 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | S, A+, S-, S+, A- | 132–203 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | S, S-, A, A- | 132–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05026` | Zarvan Greater Chimera Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | A | 146 | 4.76 m | Day & Night | Like a typical Greater Chimera, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05027` | Nox Dominion Greater Chimera Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S | 188 | 7 m | Day & Night | Like a typical Greater Chimera, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_05028` | Nox Dominion Greater Chimera | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | A+ | 159 | 5.6 m | Day & Night | A typical adult Greater Chimera of this region, with red-black coloring with faint ember veins. |
| `pop_05029` | Sunscar Greater Chimera Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | S | 188 | 7 m | Day & Night | Like a typical Greater Chimera, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05030` | Sunscar Greater Chimera Albino | [[Regions/Sunscar\|Sunscar]] | Albino | S- | 173 | 5.6 m | Day & Night | Like a typical Greater Chimera, but a rare pale form with white skin or fur and red eyes. |
| `pop_05031` | Nox Dominion Greater Chimera Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S- | 173 | 5.6 m | Day & Night | Like a typical Greater Chimera, but a rare pale form with white skin or fur and red eyes. |
| `pop_05032` | Nox Dominion Greater Chimera Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | S+ | 203 | 7.56 m | Day & Night | Like a typical Greater Chimera, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_05033` | Sunscar Greater Chimera Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | A | 146 | 4.76 m | Day & Night | Like a typical Greater Chimera, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05034` | Zarvan Greater Chimera Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | S | 188 | 7 m | Day & Night | Like a typical Greater Chimera, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05035` | Sunscar Greater Chimera Runt | [[Regions/Sunscar\|Sunscar]] | Runt | A- | 132 | 3.92 m | Day & Night | Like a typical Greater Chimera, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05036` | Nox Dominion Greater Chimera Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A- | 132 | 3.92 m | Day & Night | Like a typical Greater Chimera, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
