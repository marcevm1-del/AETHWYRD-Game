---
type: monster
id: mon_phantom_goblin_wolf_rider
family: "Goblinoids"
rank: "D+"
tier: variant
tags: [monster, goblinoids]
---
# Phantom Goblin Wolf Rider

![[mon_phantom_goblin_wolf_rider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_goblin_wolf_rider_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Goblin Wolf Rider is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Survivors describe a bone saddle on a snarling war-wolf mount. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Wolf Rider\|Goblin Wolf Rider]] (spirit) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3257 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 15.2 kg, gravity ×1.35, poise 37, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 5.07 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a bone saddle on a snarling war-wolf mount.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Goblin Wolf Rider is a **dread humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bone saddle on a snarling war-wolf mount. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids D|loot_goblinoid_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C-, C, D, D-, D+ | 40–76 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | C-, C+, D+, C, D, D- | 40–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05967` | Strife Marches Phantom Goblin Wolf Rider Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Phantom Goblin Wolf Rider, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05968` | Strife Marches Phantom Goblin Wolf Rider Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Phantom Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05969` | Strife Marches Phantom Goblin Wolf Rider Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 0.85 m | Night | Like a typical Phantom Goblin Wolf Rider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05970` | Hoshizora Phantom Goblin Wolf Rider Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 1 m | Night | Like a typical Phantom Goblin Wolf Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_05971` | Strife Marches Phantom Goblin Wolf Rider Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D- | 40 | 0.7 m | Night | Like a typical Phantom Goblin Wolf Rider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05972` | Strife Marches Phantom Goblin Wolf Rider | [[Regions/Strife Marches\|Strife Marches]] | Adult | D+ | 56 | 1 m | Night | A typical adult Phantom Goblin Wolf Rider of this region, with golden, grass-toned coloring. |
| `pop_05973` | Hoshizora Phantom Goblin Wolf Rider Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Phantom Goblin Wolf Rider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05974` | Hoshizora Phantom Goblin Wolf Rider | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 1 m | Night | A typical adult Phantom Goblin Wolf Rider of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05975` | Hoshizora Phantom Goblin Wolf Rider Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Phantom Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05976` | Hoshizora Phantom Goblin Wolf Rider Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 0.85 m | Night | Like a typical Phantom Goblin Wolf Rider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05977` | Hoshizora Phantom Goblin Wolf Rider Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 0.7 m | Night | Like a typical Phantom Goblin Wolf Rider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
