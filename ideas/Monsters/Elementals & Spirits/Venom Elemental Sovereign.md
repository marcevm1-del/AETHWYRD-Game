---
type: monster
id: mon_venom_elemental_sovereign
family: "Elementals & Spirits"
rank: "SSS+"
tier: variant
tags: [monster, elementals-spirits]
---
# Venom Elemental Sovereign

> The Venom Elemental Sovereign is a colossal creature with a floating, cloth-like shape, about 20 m tall. Its body is rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show four orbiting crowns of fire, ice, storm and stone. It has burning slit pupils. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It charges without hesitation, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Elemental Sovereign\|Elemental Sovereign]] (elemental) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 20 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 91824 · 712 · 830 · 1660 · 1542 · 90 |
| XP · gold | 26706 · 4286 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 20 m high × 6 m long × 12.8 m wide; prefab scale 20.
- **Physics:** 800 kg, gravity ×0, poise 935, knockback resistance 0.24, death style `dissolve_into_motes`.
- **Navigation:** speed 22.24 m/s, turn 161°/s, stopping distance 5.4 m.
- **Attack count:** 5; **signature:** four orbiting crowns of fire, ice, storm and stone.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Venom Elemental Sovereign is a **menacing elemental** encountered at SSS+ rank, around level 294. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

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

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | EX-, SSS+, EX, SSS-, SSS, EX+ | 267–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04561` | Nox Dominion Venom Elemental Sovereign Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | EX- | 300 | 22 m | Day & Night | Like a typical Venom Elemental Sovereign, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_04562` | Nox Dominion Venom Elemental Sovereign Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | EX- | 300 | 20 m | Day & Night | Like a typical Venom Elemental Sovereign, but a rare pale form with white skin or fur and red eyes. |
| `pop_04563` | Nox Dominion Venom Elemental Sovereign | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS+ | 294 | 20 m | Day & Night | A typical adult Venom Elemental Sovereign of this region, with ash-dark coloring with glowing cracks. |
| `pop_04564` | Nox Dominion Venom Elemental Sovereign Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX | 300 | 25 m | Day & Night | Like a typical Venom Elemental Sovereign, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_04565` | Nox Dominion Venom Elemental Sovereign Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SSS- | 267 | 14 m | Day & Night | Like a typical Venom Elemental Sovereign, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04566` | Nox Dominion Venom Elemental Sovereign Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS | 281 | 17 m | Day & Night | Like a typical Venom Elemental Sovereign, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_04567` | Nox Dominion Venom Elemental Sovereign Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX+ | 300 | 27 m | Day & Night | Like a typical Venom Elemental Sovereign, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
