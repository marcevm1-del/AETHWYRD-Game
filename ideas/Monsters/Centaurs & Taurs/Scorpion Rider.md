---
type: monster
id: mon_scorpion_rider
family: "Centaurs & Taurs"
rank: "B"
tier: core
tags: [monster, centaurs-taurs]
---
# Scorpion Rider

![[mon_scorpion_rider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_scorpion_rider_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Scorpion Rider is a large creature with a centauroid body with a humanoid torso on a four-legged base, about 3 m tall. Its coat is rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show a humanoid torso on a giant scorpion body. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16207 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]], [[Regions/Fanghold\|Fanghold]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Ashira Vale\|Ashira Vale]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 3.15 m high × 3 m long × 0.72 m wide; prefab scale 1.25.
- **Physics:** 540 kg, gravity ×1.3, poise 148, knockback resistance 0.72, death style `ragdoll_slide`.
- **Navigation:** speed 9.25 m/s, turn 208°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** a humanoid torso on a giant scorpion body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Scorpion Rider is a **menacing beastfolk** encountered at B rank, around level 108. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a humanoid torso on a giant scorpion body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Zaruma|Zaruma]], [[Regions/Fanghold|Fanghold]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Ashira Vale|Ashira Vale]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs B|loot_centaur_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Centaurs & Taurs/Ancient Scorpion Rider|Ancient Scorpion Rider]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 3 | A, B-, A- | 96–146 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 1 | B+ | 120–120 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | A-, B+ | 120–132 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C+, A-, B+, B- | 86–132 | Day & Night |
| [[Regions/Ashira Vale\|Ashira Vale]] | 1 | B | 108–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02307` | Zaruma Scorpion Rider Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | A | 146 | 4.05 m | Day & Night | Like a typical Scorpion Rider, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02308` | Fanghold Scorpion Rider Albino | [[Regions/Fanghold\|Fanghold]] | Albino | B+ | 120 | 3 m | Day & Night | Like a typical Scorpion Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_02309` | Moraveil Scorpion Rider Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Scorpion Rider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02310` | Moraveil Scorpion Rider Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B+ | 120 | 3 m | Day & Night | Like a typical Scorpion Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_02311` | Strife Marches Scorpion Rider Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 2.1 m | Day & Night | Like a typical Scorpion Rider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02312` | Strife Marches Scorpion Rider Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Scorpion Rider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02313` | Ashira Vale Scorpion Rider | [[Regions/Ashira Vale\|Ashira Vale]] | Adult | B | 108 | 3 m | Day & Night | A typical adult Scorpion Rider of this region, with golden, grass-toned coloring. |
| `pop_02314` | Zaruma Scorpion Rider Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | B- | 96 | 2.55 m | Day & Night | Like a typical Scorpion Rider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02315` | Zaruma Scorpion Rider Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Scorpion Rider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02316` | Strife Marches Scorpion Rider Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 3 m | Day & Night | Like a typical Scorpion Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_02317` | Strife Marches Scorpion Rider Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B- | 96 | 2.55 m | Day & Night | Like a typical Scorpion Rider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
