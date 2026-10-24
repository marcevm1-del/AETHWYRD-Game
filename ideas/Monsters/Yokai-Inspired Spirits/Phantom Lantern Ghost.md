---
type: monster
id: mon_phantom_lantern_ghost
family: "Yokai-Inspired Spirits"
rank: "E+"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Phantom Lantern Ghost

> The Phantom Lantern Ghost is a small creature with a drifting, half-formed body, about 0.6 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Its most striking feature is a paper lantern with a torn mouth. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Lantern Ghost\|Lantern Ghost]] (spirit) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1156 · 83 · 97 · 193 · 179 · 90 |
| XP · gold | 776 · 195 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 0.6 m high × 0.18 m long × 0.38 m wide; prefab scale 0.6.
- **Physics:** 0.5 kg, gravity ×0, poise 6, knockback resistance 0.03, death style `dissolve_into_motes`.
- **Navigation:** speed 3.99 m/s, turn 900°/s, stopping distance 0.55 m.
- **Attack count:** 5; **signature:** a paper lantern with a torn mouth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Lantern Ghost is a **dread spirit** encountered at E+ rank, around level 32. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a paper lantern with a torn mouth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits E|loot_yokai_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | D+, D, E-, E+ | 19–56 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 7 | D-, D+, E-, D, E, E+ | 19–56 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05312` | Kitsune Isles Phantom Lantern Ghost Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | D+ | 56 | 0.81 m | Night | Like a typical Phantom Lantern Ghost, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_05313` | Hoshizora Phantom Lantern Ghost Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D- | 40 | 0.6 m | Night | Like a typical Phantom Lantern Ghost, but a rare pale form with white skin or fur and red eyes. |
| `pop_05314` | Hoshizora Phantom Lantern Ghost Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | D+ | 56 | 0.81 m | Night | Like a typical Phantom Lantern Ghost, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05315` | Kitsune Isles Phantom Lantern Ghost Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | D | 48 | 0.75 m | Night | Like a typical Phantom Lantern Ghost, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_05316` | Hoshizora Phantom Lantern Ghost Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D- | 40 | 0.66 m | Night | Like a typical Phantom Lantern Ghost, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05317` | Hoshizora Phantom Lantern Ghost Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E- | 19 | 0.42 m | Night | Like a typical Phantom Lantern Ghost, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05318` | Hoshizora Phantom Lantern Ghost Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | D | 48 | 0.75 m | Night | Like a typical Phantom Lantern Ghost, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05319` | Hoshizora Phantom Lantern Ghost Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | E | 26 | 0.51 m | Night | Like a typical Phantom Lantern Ghost, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05320` | Kitsune Isles Phantom Lantern Ghost Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E- | 19 | 0.42 m | Night | Like a typical Phantom Lantern Ghost, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_05321` | Kitsune Isles Phantom Lantern Ghost | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | E+ | 32 | 0.6 m | Night | A typical adult Phantom Lantern Ghost of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_05322` | Hoshizora Phantom Lantern Ghost | [[Regions/Hoshizora\|Hoshizora]] | Adult | E+ | 32 | 0.6 m | Night | A typical adult Phantom Lantern Ghost of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `paper_ink_spirit` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
