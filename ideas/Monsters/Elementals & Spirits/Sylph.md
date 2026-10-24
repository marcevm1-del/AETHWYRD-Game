---
type: monster
id: mon_sylph
family: "Elementals & Spirits"
rank: "D+"
tier: core
tags: [monster, elementals-spirits]
---
# Sylph

> The Sylph is a person-sized creature with a lean humanoid frame, about 1.5 m tall. Its body is smooth and clean, colored in pale jade and cloud white. Survivors describe a translucent dancer of wind and leaves. It has big round glossy eyes. A distinctive marking runs along its back. It hops in little bursts, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | D+ · 56 (48–65) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 1.5 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4825 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.5 m high × 0.45 m long × 0.48 m wide; prefab scale 0.833.
- **Physics:** 39.5 kg, gravity ×1.2, poise 59, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 3.75 m/s, turn 327°/s, stopping distance 0.66 m.
- **Attack count:** 5; **signature:** a translucent dancer of wind and leaves.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sylph is a **charming elemental** encountered at D+ rank, around level 56. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a translucent dancer of wind and leaves. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits D|loot_elemental_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Phantom Sylph|Phantom Sylph]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | D, C, D-, D+ | 40–76 | Day |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | D, D+, D-, C, C- | 40–76 | Day |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | D-, C- | 40–65 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01628` | Aldmere Sylph Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 1.27 m | Day | Like a typical Sylph, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01629` | Iron Hold Sylph Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 1.27 m | Day | Like a typical Sylph, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01630` | Aldmere Sylph Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 1.88 m | Day | Like a typical Sylph, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01631` | Iron Hold Sylph | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 1.5 m | Day | A typical adult Sylph of this region, with slate-grey coloring and hardened hide. |
| `pop_01632` | Iron Hold Sylph Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 1.05 m | Day | Like a typical Sylph, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01633` | Hoshizora Sylph Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 1.05 m | Day | Like a typical Sylph, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01634` | Iron Hold Sylph Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C | 76 | 1.88 m | Day | Like a typical Sylph, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01635` | Aldmere Sylph Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 1.05 m | Day | Like a typical Sylph, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01636` | Hoshizora Sylph Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 1.5 m | Day | Like a typical Sylph, but a rare pale form with white skin or fur and red eyes. |
| `pop_01637` | Iron Hold Sylph Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 1.65 m | Day | Like a typical Sylph, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01638` | Aldmere Sylph | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 1.5 m | Day | A typical adult Sylph of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `elemental_emissive` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
