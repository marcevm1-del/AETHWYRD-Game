---
type: monster
id: mon_hill_giant
family: "Orcs, Ogres & Giants"
rank: "B+"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Hill Giant

![[mon_hill_giant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hill_giant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,176 tris · 6.012 × 3.874 × 7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hill Giant is a huge creature with a massive hunched brute frame, about 7 m tall. Its hide is weathered and natural, colored in ochre, clay and mossy stone. Look for a boulder slung over its shoulder like a sack. It has alert animal eyes. Faint runes glow along its body when it fights. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | B+ · 120 (108–132) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 7 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31630 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Frostveil\|Frostveil]], [[Regions/Vharlen\|Vharlen]], [[Regions/Stormreach\|Stormreach]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 7 m high × 2.1 m long × 2.94 m wide; prefab scale 2.
- **Physics:** 8026.2 kg, gravity ×1.43, poise 317, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.8 m/s, turn 144°/s, stopping distance 1.8 m.
- **Attack count:** 5; **signature:** a boulder slung over its shoulder like a sack.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hill Giant is a **wild giant** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a boulder slung over its shoulder like a sack. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Frostveil|Frostveil]], [[Regions/Vharlen|Vharlen]], [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants B|loot_orc_giant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Hill Giant|Vesper-Touched Hill Giant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vharlen\|Vharlen]] | 2 | B-, B | 96–108 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 3 | B, A+, B+ | 108–159 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 1 | A- | 132–132 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | B-, A, B+, A- | 96–146 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 1 | B+ | 120–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01127` | Vharlen Hill Giant Runt | [[Regions/Vharlen\|Vharlen]] | Runt | B- | 96 | 4.9 m | Day & Night | Like a typical Hill Giant, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01128` | Frostveil Hill Giant Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | B | 108 | 5.95 m | Day & Night | Like a typical Hill Giant, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_01129` | Frostveil Hill Giant Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | A+ | 159 | 9.45 m | Day & Night | Like a typical Hill Giant, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_01130` | Vharlen Hill Giant Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | B | 108 | 5.95 m | Day & Night | Like a typical Hill Giant, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01131` | Dragon Spine Hill Giant Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | A- | 132 | 7 m | Day & Night | Like a typical Hill Giant, but a rare pale form with white skin or fur and red eyes. |
| `pop_01132` | Iron Hold Hill Giant Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B- | 96 | 4.9 m | Day & Night | Like a typical Hill Giant, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01133` | Stormreach Hill Giant | [[Regions/Stormreach\|Stormreach]] | Adult | B+ | 120 | 7 m | Day & Night | A typical adult Hill Giant of this region, with slate-grey coloring and hardened hide. |
| `pop_01134` | Frostveil Hill Giant | [[Regions/Frostveil\|Frostveil]] | Adult | B+ | 120 | 7 m | Day & Night | A typical adult Hill Giant of this region, with a thick, frost-rimed coat. |
| `pop_01135` | Iron Hold Hill Giant Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A | 146 | 8.75 m | Day & Night | Like a typical Hill Giant, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01136` | Iron Hold Hill Giant | [[Regions/Iron Hold\|Iron Hold]] | Adult | B+ | 120 | 7 m | Day & Night | A typical adult Hill Giant of this region, with slate-grey coloring and hardened hide. |
| `pop_01137` | Iron Hold Hill Giant Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A- | 132 | 7 m | Day & Night | Like a typical Hill Giant, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
