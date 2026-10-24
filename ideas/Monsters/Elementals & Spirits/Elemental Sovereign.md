---
type: monster
id: mon_elemental_sovereign
family: "Elementals & Spirits"
rank: "SSS"
tier: core
tags: [monster, elementals-spirits]
---
# Elemental Sovereign

> The Elemental Sovereign is a colossal creature with a bodiless, glowing form, about 20 m tall. Its body is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Look for four orbiting crowns of fire, ice, storm and stone. It has burning slit pupils. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | SSS · 281 (267–294) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 20 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 85809 · 680 · 794 · 1588 · 1474 · 90 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 20 m high × 6 m long × 12.8 m wide; prefab scale 20.
- **Physics:** 800 kg, gravity ×0, poise 935, knockback resistance 0.24, death style `dissolve_into_motes`.
- **Navigation:** speed 27.51 m/s, turn 161°/s, stopping distance 5.4 m.
- **Attack count:** 5; **signature:** four orbiting crowns of fire, ice, storm and stone.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elemental Sovereign is a **menacing elemental** encountered at SSS rank, around level 281. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** four orbiting crowns of fire, ice, storm and stone. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits SSS|loot_elemental_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Venom Elemental Sovereign|Venom Elemental Sovereign]]

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | SSS+, SSS, EX-, EX, SSS-, SS+ | 253–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01683` | Nox Dominion Elemental Sovereign Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SSS+ | 294 | 20 m | Day & Night | Like a typical Elemental Sovereign, but a rare pale form with white skin or fur and red eyes. |
| `pop_01684` | Nox Dominion Elemental Sovereign | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS | 281 | 20 m | Day & Night | A typical adult Elemental Sovereign of this region, with ash-dark coloring with glowing cracks. |
| `pop_01685` | Nox Dominion Elemental Sovereign Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX- | 300 | 25 m | Day & Night | Like a typical Elemental Sovereign, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_01686` | Nox Dominion Elemental Sovereign Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SSS+ | 294 | 22 m | Day & Night | Like a typical Elemental Sovereign, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_01687` | Nox Dominion Elemental Sovereign Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX | 300 | 27 m | Day & Night | Like a typical Elemental Sovereign, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_01688` | Nox Dominion Elemental Sovereign Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS- | 267 | 17 m | Day & Night | Like a typical Elemental Sovereign, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_01689` | Nox Dominion Elemental Sovereign Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS+ | 253 | 14 m | Day & Night | Like a typical Elemental Sovereign, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
