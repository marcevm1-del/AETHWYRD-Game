---
type: monster
id: mon_dune_centaur_khan
family: "Centaurs & Taurs"
rank: "A+"
tier: variant
tags: [monster, centaurs-taurs]
---
# Dune Centaur Khan

![[mon_dune_centaur_khan_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dune_centaur_khan_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dune Centaur Khan is a large creature with a powerful taur build, about 3 m tall. Its coat is weathered and natural, colored in ochre, clay and mossy stone. Guild sketches always show a lightning-bolt war standard. It has alert animal eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It lopes in long strides, surrounded by pebbles that tremble and float near it. Adapted to desert lands, it has sun-bleached, sand-scoured coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Variant of | [[Monsters/Centaurs & Taurs/Centaur Khan\|Centaur Khan]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 3 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 28876 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 3.15 m high × 3 m long × 0.72 m wide; prefab scale 1.25.
- **Physics:** 702 kg, gravity ×1.43, poise 176, knockback resistance 0.9, death style `ragdoll_slide`.
- **Navigation:** speed 8.35 m/s, turn 208°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** a lightning-bolt war standard.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dune Centaur Khan is a **wild beastfolk** encountered at A+ rank, around level 159. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lightning-bolt war standard. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs A|loot_centaur_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 4 | S-, A+, A | 146–173 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | S-, A-, S+, S | 132–203 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | A+, A-, S | 132–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05169` | Zarvan Dune Centaur Khan Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | S- | 173 | 3.3 m | Day & Night | Like a typical Dune Centaur Khan, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05170` | Sunscar Dune Centaur Khan Albino | [[Regions/Sunscar\|Sunscar]] | Albino | S- | 173 | 3 m | Day & Night | Like a typical Dune Centaur Khan, but a rare pale form with white skin or fur and red eyes. |
| `pop_05171` | Sunscar Dune Centaur Khan Runt | [[Regions/Sunscar\|Sunscar]] | Runt | A- | 132 | 2.1 m | Day & Night | Like a typical Dune Centaur Khan, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05172` | Zaruma Dune Centaur Khan | [[Regions/Zaruma\|Zaruma]] | Adult | A+ | 159 | 3 m | Day & Night | A typical adult Dune Centaur Khan of this region, with golden, grass-toned coloring. |
| `pop_05173` | Zarvan Dune Centaur Khan | [[Regions/Zarvan\|Zarvan]] | Adult | A+ | 159 | 3 m | Day & Night | A typical adult Dune Centaur Khan of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05174` | Zaruma Dune Centaur Khan Runt | [[Regions/Zaruma\|Zaruma]] | Runt | A- | 132 | 2.1 m | Day & Night | Like a typical Dune Centaur Khan, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05175` | Zarvan Dune Centaur Khan Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | A | 146 | 2.55 m | Day & Night | Like a typical Dune Centaur Khan, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05176` | Sunscar Dune Centaur Khan Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S+ | 203 | 4.05 m | Day & Night | Like a typical Dune Centaur Khan, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05177` | Zaruma Dune Centaur Khan Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | S | 188 | 3.75 m | Day & Night | Like a typical Dune Centaur Khan, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05178` | Sunscar Dune Centaur Khan Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | S | 188 | 3.75 m | Day & Night | Like a typical Dune Centaur Khan, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05179` | Zarvan Dune Centaur Khan Albino | [[Regions/Zarvan\|Zarvan]] | Albino | S- | 173 | 3 m | Day & Night | Like a typical Dune Centaur Khan, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
