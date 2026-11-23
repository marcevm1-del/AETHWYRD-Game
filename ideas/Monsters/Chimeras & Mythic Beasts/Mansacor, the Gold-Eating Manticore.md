---
type: monster
id: mon_mansacor_the_gold_eating_manticore
family: "Chimeras & Mythic Beasts"
rank: "A+"
tier: core
tags: [monster, chimeras-mythic-beasts, tyrant, unique]
---
# Mansacor, the Gold-Eating Manticore

![[mon_mansacor_the_gold_eating_manticore_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mansacor_the_gold_eating_manticore_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 4.785 × 5 × 3.149 m · local file `Game/Assets/_Game/Art/Models/Monsters/Chimeras & Mythic Beasts/mon_mansacor_the_gold_eating_manticore.fbx`

> The Mansacor, the Gold-Eating Manticore is a huge creature with a powerful four-legged hunter's body, about 5 m long. Its hide is rough, scarred and spiked, colored in brown and dark umber, with ochre markings. Look for a hide studded with swallowed gold coins that ring when it moves. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 34118 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Zaruma\|Zaruma]] |
| Tyrant | Yes |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.25 m high × 5 m long × 0.8 m wide; prefab scale 1.25.
- **Physics:** 3250 kg, gravity ×1.32, poise 158, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.94 m/s, turn 143°/s, stopping distance 1.4 m.
- **Attack count:** 5; **signature:** a hide studded with swallowed gold coins that ring when it moves.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mansacor, the Gold-Eating Manticore is a **menacing mythic beast** encountered at A+ rank, around level 159. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hide studded with swallowed gold coins that ring when it moves. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts A|loot_chimera_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06736` | Mansacor, the Gold-Eating Manticore | [[Regions/Zaruma\|Zaruma]] | Unique | A+ | 159 | 5 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `rock_debris` · palette `#846a45` `#594b32` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
