---
type: monster
id: mon_goblin_wolf_rider
family: "Goblinoids"
rank: "D"
tier: core
tags: [monster, goblinoids]
---
# Goblin Wolf Rider

![[mon_goblin_wolf_rider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_goblin_wolf_rider_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,334 tris · 0.495 × 0.583 × 1 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Goblin Wolf Rider is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Look for a bone saddle on a snarling war-wolf mount. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2595 · 202 · 162 · 99 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 37, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 5.32 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 4; **signature:** a bone saddle on a snarling war-wolf mount.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin Wolf Rider is a **menacing humanoid** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bone saddle on a snarling war-wolf mount. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]], [[Regions/Aldmere|Aldmere]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids D|loot_goblinoid_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Ancient Goblin Wolf Rider|Ancient Goblin Wolf Rider]]
- [[Monsters/Goblinoids/Phantom Goblin Wolf Rider|Phantom Goblin Wolf Rider]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 1 | D- | 40–40 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | C-, D+ | 56–65 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | D+, C-, D- | 40–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | C-, C, D- | 40–76 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | D, E+ | 32–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00222` | Aldmere Goblin Wolf Rider Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Goblin Wolf Rider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00223` | Iron Hold Goblin Wolf Rider Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00224` | Hoshizora Goblin Wolf Rider Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D+ | 56 | 1 m | Day & Night | Like a typical Goblin Wolf Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_00225` | Moraveil Goblin Wolf Rider Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00226` | Hoshizora Goblin Wolf Rider Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00227` | Strife Marches Goblin Wolf Rider | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Goblin Wolf Rider of this region, with golden, grass-toned coloring. |
| `pop_00228` | Hoshizora Goblin Wolf Rider Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Goblin Wolf Rider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00229` | Moraveil Goblin Wolf Rider Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C | 76 | 1.35 m | Day & Night | Like a typical Goblin Wolf Rider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00230` | Strife Marches Goblin Wolf Rider Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Goblin Wolf Rider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00231` | Iron Hold Goblin Wolf Rider Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 1 m | Day & Night | Like a typical Goblin Wolf Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_00232` | Moraveil Goblin Wolf Rider Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Goblin Wolf Rider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
