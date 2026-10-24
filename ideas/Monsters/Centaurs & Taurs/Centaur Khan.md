---
type: monster
id: mon_centaur_khan
family: "Centaurs & Taurs"
rank: "A"
tier: core
tags: [monster, centaurs-taurs]
---
# Centaur Khan

![[mon_centaur_khan_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_centaur_khan_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,004 tris · 1.432 × 2.329 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Centaur Khan is a large creature with a powerful taur build, about 3 m tall. Its coat is weathered and natural, colored in storm violet shot through with electric yellow. Its most striking feature is a lightning-bolt war standard. It has alert animal eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It lopes in long strides, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Rank · level | A · 146 (132–159) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 3 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25420 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Calamity Steppe\|Calamity Steppe]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Earth. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 3.15 m high × 3 m long × 0.72 m wide; prefab scale 1.25.
- **Physics:** 540 kg, gravity ×1.3, poise 162, knockback resistance 0.75, death style `ragdoll_slide`.
- **Navigation:** speed 9.81 m/s, turn 208°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** a lightning-bolt war standard.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Centaur Khan is a **wild beastfolk** encountered at A rank, around level 146. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lightning-bolt war standard. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Quaking Lands|Quaking Lands]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Calamity Steppe|Calamity Steppe]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs A|loot_centaur_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Centaurs & Taurs/Dune Centaur Khan|Dune Centaur Khan]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 3 | A, A+, B+ | 120–159 | Day & Night |
| [[Regions/Calamity Steppe\|Calamity Steppe]] | 6 | S-, A, A+, S, B+ | 120–188 | Day & Night |
| [[Regions/Quaking Lands\|Quaking Lands]] | 2 | A, B+ | 120–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02318` | Kitsune Isles Centaur Khan | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | A | 146 | 3 m | Day & Night | A typical adult Centaur Khan of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02319` | Calamity Steppe Centaur Khan Alpha | [[Regions/Calamity Steppe\|Calamity Steppe]] | Alpha | S- | 173 | 3.75 m | Day & Night | Like a typical Centaur Khan, but larger and scarred, and others of its kind follow it, with wind-burnt coloring and a lean frame. |
| `pop_02320` | Kitsune Isles Centaur Khan Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | A+ | 159 | 3.3 m | Day & Night | Like a typical Centaur Khan, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02321` | Calamity Steppe Centaur Khan | [[Regions/Calamity Steppe\|Calamity Steppe]] | Adult | A | 146 | 3 m | Day & Night | A typical adult Centaur Khan of this region, with wind-burnt coloring and a lean frame. |
| `pop_02322` | Quaking Lands Centaur Khan | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | A | 146 | 3 m | Day & Night | A typical adult Centaur Khan of this region, with golden, grass-toned coloring. |
| `pop_02323` | Kitsune Isles Centaur Khan Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | B+ | 120 | 2.1 m | Day & Night | Like a typical Centaur Khan, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02324` | Calamity Steppe Centaur Khan Albino | [[Regions/Calamity Steppe\|Calamity Steppe]] | Albino | A+ | 159 | 3 m | Day & Night | Like a typical Centaur Khan, but a rare pale form with white skin or fur and red eyes. |
| `pop_02325` | Calamity Steppe Centaur Khan Scarred | [[Regions/Calamity Steppe\|Calamity Steppe]] | Scarred | A+ | 159 | 3.3 m | Day & Night | Like a typical Centaur Khan, but covered in old battle scars, with wind-burnt coloring and a lean frame. |
| `pop_02326` | Calamity Steppe Centaur Khan Elderborn | [[Regions/Calamity Steppe\|Calamity Steppe]] | Elderborn | S | 188 | 4.05 m | Day & Night | Like a typical Centaur Khan, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_02327` | Calamity Steppe Centaur Khan Runt | [[Regions/Calamity Steppe\|Calamity Steppe]] | Runt | B+ | 120 | 2.1 m | Day & Night | Like a typical Centaur Khan, but smaller and scrappier than usual, with wind-burnt coloring and a lean frame. |
| `pop_02328` | Quaking Lands Centaur Khan Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | B+ | 120 | 2.1 m | Day & Night | Like a typical Centaur Khan, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · real-animal silhouette with one fantasy exaggeration
