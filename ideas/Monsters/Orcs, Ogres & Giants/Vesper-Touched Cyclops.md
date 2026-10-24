---
type: monster
id: mon_vesper_touched_cyclops
family: "Orcs, Ogres & Giants"
rank: "A"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Vesper-Touched Cyclops

![[mon_vesper_touched_cyclops_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_cyclops_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,136 tris · 3.65 × 2.515 × 6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Cyclops is a huge creature with a towering, heavy-limbed body, about 6 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Its most striking feature is a single huge eye and a hammer made from a millstone. It has eyes that never blink. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Cyclops\|Cyclops]] (corrupted) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 6 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 40459 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Quaking Lands\|Quaking Lands]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 6 m high × 1.8 m long × 2.52 m wide; prefab scale 1.714.
- **Physics:** 5054.4 kg, gravity ×1.43, poise 321, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.58 m/s, turn 155°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** a single huge eye and a hammer made from a millstone.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Cyclops is a **dread giant** encountered at A rank, around level 146. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a single huge eye and a hammer made from a millstone. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Quaking Lands|Quaking Lands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants A|loot_orc_giant_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 5 | A-, A, S-, S, A+ | 132–188 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | S, A, A+, S- | 146–188 | Night |
| [[Regions/Vharlen\|Vharlen]] | 1 | S | 188–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04035` | Quaking Lands Vesper-Touched Cyclops Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | A- | 132 | 5.1 m | Night | Like a typical Vesper-Touched Cyclops, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04036` | Iron Hold Vesper-Touched Cyclops Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S | 188 | 8.1 m | Night | Like a typical Vesper-Touched Cyclops, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04037` | Iron Hold Vesper-Touched Cyclops | [[Regions/Iron Hold\|Iron Hold]] | Adult | A | 146 | 6 m | Night | A typical adult Vesper-Touched Cyclops of this region, with slate-grey coloring and hardened hide. |
| `pop_04038` | Quaking Lands Vesper-Touched Cyclops | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | A | 146 | 6 m | Night | A typical adult Vesper-Touched Cyclops of this region, with slate-grey coloring and hardened hide. |
| `pop_04039` | Quaking Lands Vesper-Touched Cyclops Alpha | [[Regions/Quaking Lands\|Quaking Lands]] | Alpha | S- | 173 | 7.5 m | Night | Like a typical Vesper-Touched Cyclops, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04040` | Vharlen Vesper-Touched Cyclops Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | S | 188 | 8.1 m | Night | Like a typical Vesper-Touched Cyclops, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_04041` | Iron Hold Vesper-Touched Cyclops Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A+ | 159 | 6.6 m | Night | Like a typical Vesper-Touched Cyclops, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04042` | Quaking Lands Vesper-Touched Cyclops Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | S | 188 | 8.1 m | Night | Like a typical Vesper-Touched Cyclops, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04043` | Iron Hold Vesper-Touched Cyclops Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | S- | 173 | 7.5 m | Night | Like a typical Vesper-Touched Cyclops, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04044` | Quaking Lands Vesper-Touched Cyclops Albino | [[Regions/Quaking Lands\|Quaking Lands]] | Albino | A+ | 159 | 6 m | Night | Like a typical Vesper-Touched Cyclops, but a rare pale form with white skin or fur and red eyes. |
| `pop_04045` | Iron Hold Vesper-Touched Cyclops Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A+ | 159 | 6 m | Night | Like a typical Vesper-Touched Cyclops, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
