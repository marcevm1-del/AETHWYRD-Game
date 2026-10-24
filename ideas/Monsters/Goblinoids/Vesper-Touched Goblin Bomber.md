---
type: monster
id: mon_vesper_touched_goblin_bomber
family: "Goblinoids"
rank: "C-"
tier: variant
tags: [monster, goblinoids]
---
# Vesper-Touched Goblin Bomber

> The Vesper-Touched Goblin Bomber is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Its most striking feature is a barrel of black powder strapped to its back and a lit fuse in its teeth. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Bomber\|Goblin Bomber]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 1 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4060 · 270 · 216 · 189 · 216 · 135 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 41, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 5.08 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a barrel of black powder strapped to its back and a lit fuse in its teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Goblin Bomber is a **dread humanoid** encountered at C- rank, around level 65. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a barrel of black powder strapped to its back and a lit fuse in its teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids C|loot_goblinoid_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 5 | C-, C, D+, C+ | 56–86 | Night |
| [[Regions/Moraveil\|Moraveil]] | 6 | C, C+, D, D+, C- | 48–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03115` | Iron Hold Vesper-Touched Goblin Bomber | [[Regions/Iron Hold\|Iron Hold]] | Adult | C- | 65 | 1 m | Night | A typical adult Vesper-Touched Goblin Bomber of this region, with slate-grey coloring and hardened hide. |
| `pop_03116` | Iron Hold Vesper-Touched Goblin Bomber Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C | 76 | 1.1 m | Night | Like a typical Vesper-Touched Goblin Bomber, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03117` | Moraveil Vesper-Touched Goblin Bomber Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C | 76 | 1.1 m | Night | Like a typical Vesper-Touched Goblin Bomber, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03118` | Iron Hold Vesper-Touched Goblin Bomber Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D+ | 56 | 0.85 m | Night | Like a typical Vesper-Touched Goblin Bomber, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03119` | Iron Hold Vesper-Touched Goblin Bomber Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C | 76 | 1 m | Night | Like a typical Vesper-Touched Goblin Bomber, but a rare pale form with white skin or fur and red eyes. |
| `pop_03120` | Moraveil Vesper-Touched Goblin Bomber Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C+ | 86 | 1.25 m | Night | Like a typical Vesper-Touched Goblin Bomber, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03121` | Moraveil Vesper-Touched Goblin Bomber Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D | 48 | 0.7 m | Night | Like a typical Vesper-Touched Goblin Bomber, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03122` | Moraveil Vesper-Touched Goblin Bomber Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C | 76 | 1 m | Night | Like a typical Vesper-Touched Goblin Bomber, but a rare pale form with white skin or fur and red eyes. |
| `pop_03123` | Iron Hold Vesper-Touched Goblin Bomber Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C+ | 86 | 1.25 m | Night | Like a typical Vesper-Touched Goblin Bomber, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03124` | Moraveil Vesper-Touched Goblin Bomber Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D+ | 56 | 0.85 m | Night | Like a typical Vesper-Touched Goblin Bomber, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03125` | Moraveil Vesper-Touched Goblin Bomber | [[Regions/Moraveil\|Moraveil]] | Adult | C- | 65 | 1 m | Night | A typical adult Vesper-Touched Goblin Bomber of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
