---
type: monster
id: mon_elite_goblin_trapper
family: "Goblinoids"
rank: "D"
tier: variant
tags: [monster, goblinoids]
---
# Elite Goblin Trapper

![[mon_elite_goblin_trapper_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elite_goblin_trapper_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,122 tris · 0.805 × 0.947 × 1.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elite Goblin Trapper is a person-sized creature with a small, compact humanoid body, about 1.6 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is snares and rusted bells hanging from its belt. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Trapper\|Goblin Trapper]] (elder) |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3037 · 202 · 162 · 99 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1.6 m high × 0.48 m long × 0.64 m wide; prefab scale 1.455.
- **Physics:** 65.5 kg, gravity ×1.5, poise 47, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 6.73 m/s, turn 332°/s, stopping distance 0.72 m.
- **Attack count:** 4; **signature:** snares and rusted bells hanging from its belt.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Elite Goblin Trapper is a **menacing humanoid** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** snares and rusted bells hanging from its belt. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 5 | D, D+, C, D- | 40–76 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | D+, C-, E+, D | 32–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D, D- | 40–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05923` | Moraveil Elite Goblin Trapper | [[Regions/Moraveil\|Moraveil]] | Adult | D | 48 | 1.6 m | Day & Night | A typical adult Elite Goblin Trapper of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05924` | Strife Marches Elite Goblin Trapper Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 1.76 m | Day & Night | Like a typical Elite Goblin Trapper, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05925` | Strife Marches Elite Goblin Trapper Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 2 m | Day & Night | Like a typical Elite Goblin Trapper, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05926` | Moraveil Elite Goblin Trapper Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D+ | 56 | 1.6 m | Day & Night | Like a typical Elite Goblin Trapper, but a rare pale form with white skin or fur and red eyes. |
| `pop_05927` | Strife Marches Elite Goblin Trapper Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.12 m | Day & Night | Like a typical Elite Goblin Trapper, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05928` | Aldmere Elite Goblin Trapper | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.6 m | Day & Night | A typical adult Elite Goblin Trapper of this region, with golden, grass-toned coloring. |
| `pop_05929` | Moraveil Elite Goblin Trapper Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C | 76 | 2.16 m | Day & Night | Like a typical Elite Goblin Trapper, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05930` | Strife Marches Elite Goblin Trapper | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1.6 m | Day & Night | A typical adult Elite Goblin Trapper of this region, with golden, grass-toned coloring. |
| `pop_05931` | Moraveil Elite Goblin Trapper Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 1.76 m | Day & Night | Like a typical Elite Goblin Trapper, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05932` | Moraveil Elite Goblin Trapper Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D- | 40 | 1.36 m | Day & Night | Like a typical Elite Goblin Trapper, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05933` | Aldmere Elite Goblin Trapper Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.36 m | Day & Night | Like a typical Elite Goblin Trapper, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
