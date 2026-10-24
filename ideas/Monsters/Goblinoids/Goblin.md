---
type: monster
id: mon_goblin
family: "Goblinoids"
rank: "F-"
tier: core
tags: [monster, goblinoids]
---
# Goblin

> The Goblin is a small creature with a hunched, wiry humanoid frame, about 1 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show a grin of needle teeth under a stolen tin helmet. It has burning slit pupils. It has no ornament at all: simple, readable shapes. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | F- · 3 (2–6) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 91 · 22 · 18 · 11 · 18 · 135 |
| XP · gold | 25 · 10 |
| Ring | 0 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 29, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 5.32 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 4; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin is a **menacing humanoid** encountered at F- rank, around level 3. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a grin of needle teeth under a stolen tin helmet. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids F|loot_goblinoid_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Grove Goblin|Grove Goblin]]
- [[Monsters/Goblinoids/Meadow Goblin|Meadow Goblin]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 7 | E-, F, F-, F+ | 3–19 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | F-, E-, F | 3–19 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00156` | Whisperwood Goblin Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E- | 19 | 1.35 m | Day & Night | Like a typical Goblin, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00157` | Whisperwood Goblin Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F | 8 | 1 m | Day & Night | Like a typical Goblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_00158` | Aldmere Goblin Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Goblin, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00159` | Whisperwood Goblin | [[Regions/Whisperwood\|Whisperwood]] | Adult | F- | 3 | 1 m | Day & Night | A typical adult Goblin of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00160` | Aldmere Goblin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E- | 19 | 1.35 m | Day & Night | Like a typical Goblin, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00161` | Aldmere Goblin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.85 m | Day & Night | Like a typical Goblin, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00162` | Whisperwood Goblin Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Goblin, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00163` | Aldmere Goblin Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F | 8 | 1 m | Day & Night | Like a typical Goblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_00164` | Whisperwood Goblin Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.85 m | Day & Night | Like a typical Goblin, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00165` | Whisperwood Goblin Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | F+ | 13 | 1.25 m | Day & Night | Like a typical Goblin, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00166` | Whisperwood Goblin Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F | 8 | 1.1 m | Day & Night | Like a typical Goblin, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Contracts and story encounters

- [[Quests/The Goblin Chief of Hollowpine|The Goblin Chief of Hollowpine]] — rank E, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Goblins in the Granary|Goblins in the Granary]] — rank E, in [[Regions/Aldmere|Aldmere]]
- [[Quests/Weekly Board/The First-Day Cart|The First-Day Cart]] — rank undefined, in [[Regions/Aldmere|Aldmere]]
- [[Quests/Weekly Board/Goblin Cull|Goblin Cull]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
