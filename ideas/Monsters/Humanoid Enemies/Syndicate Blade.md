---
type: monster
id: mon_syndicate_blade
family: "Humanoid Enemies"
rank: "B"
tier: core
tags: [monster, humanoid-enemies]
---
# Syndicate Blade

> The Syndicate Blade is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its clothing and gear are rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is no face, no name, two knives. It has narrow glowing eyes. Faint runes glow along its body when it fights. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13619 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 80, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.7 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** no face, no name, two knives.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Syndicate Blade is a **menacing humanoid** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** no face, no name, two knives. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies B|loot_humanoid_enemy_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Syndicate Blade Veteran|Syndicate Blade Veteran]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vharlen\|Vharlen]] | 4 | B+, A-, B, C+ | 86–132 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | B, A, B+, B- | 96–146 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | C+, B+, B | 86–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02784` | Vharlen Syndicate Blade Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | B+ | 120 | 1.98 m | Day & Night | Like a typical Syndicate Blade, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02785` | Moraveil Syndicate Blade | [[Regions/Moraveil\|Moraveil]] | Adult | B | 108 | 1.8 m | Day & Night | A typical adult Syndicate Blade of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02786` | Moraveil Syndicate Blade Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A | 146 | 2.43 m | Day & Night | Like a typical Syndicate Blade, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02787` | Vharlen Syndicate Blade Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A- | 132 | 2.25 m | Day & Night | Like a typical Syndicate Blade, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02788` | Strife Marches Syndicate Blade Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 1.26 m | Day & Night | Like a typical Syndicate Blade, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02789` | Strife Marches Syndicate Blade Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 1.8 m | Day & Night | Like a typical Syndicate Blade, but a rare pale form with white skin or fur and red eyes. |
| `pop_02790` | Vharlen Syndicate Blade | [[Regions/Vharlen\|Vharlen]] | Adult | B | 108 | 1.8 m | Day & Night | A typical adult Syndicate Blade of this region, with golden, grass-toned coloring. |
| `pop_02791` | Moraveil Syndicate Blade Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B+ | 120 | 1.8 m | Day & Night | Like a typical Syndicate Blade, but a rare pale form with white skin or fur and red eyes. |
| `pop_02792` | Moraveil Syndicate Blade Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B- | 96 | 1.53 m | Day & Night | Like a typical Syndicate Blade, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02793` | Vharlen Syndicate Blade Runt | [[Regions/Vharlen\|Vharlen]] | Runt | C+ | 86 | 1.26 m | Day & Night | Like a typical Syndicate Blade, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02794` | Strife Marches Syndicate Blade | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 1.8 m | Day & Night | A typical adult Syndicate Blade of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
