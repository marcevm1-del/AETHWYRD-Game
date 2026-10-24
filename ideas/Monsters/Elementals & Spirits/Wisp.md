---
type: monster
id: mon_wisp
family: "Elementals & Spirits"
rank: "F"
tier: core
tags: [monster, elementals-spirits]
---
# Wisp

> The Wisp is a tiny creature with a floating, cloth-like shape, about 0.3 m tall. Its body is smooth and clean, colored in warm gold and pearl white. Its most striking feature is a floating ball of soft light. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 152 · 25 · 29 · 59 · 55 · 90 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (override); animation set `anim_floating`.
- **Dimensions:** 0.3 m high × 0.09 m long × 0.19 m wide; prefab scale 0.3.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 0, death style `dissolve_into_motes`.
- **Navigation:** speed 2.41 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Wisp is a **charming elemental** encountered at F rank, around level 8. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a floating ball of soft light. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits F|loot_elemental_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Storm Wisp|Storm Wisp]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | F-, E, F+, E-, F | 3–26 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F+, F-, E-, F | 3–19 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01573` | Aldmere Wisp Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.21 m | Day | Like a typical Wisp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01574` | Whisperwood Wisp Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.33 m | Day | Like a typical Wisp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01575` | Whisperwood Wisp Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.26 m | Day | Like a typical Wisp, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01576` | Whisperwood Wisp Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.38 m | Day | Like a typical Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01577` | Aldmere Wisp Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.26 m | Day | Like a typical Wisp, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01578` | Aldmere Wisp Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.41 m | Day | Like a typical Wisp, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01579` | Aldmere Wisp Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.33 m | Day | Like a typical Wisp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01580` | Aldmere Wisp Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 0.3 m | Day | Like a typical Wisp, but a rare pale form with white skin or fur and red eyes. |
| `pop_01581` | Aldmere Wisp Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.38 m | Day | Like a typical Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01582` | Aldmere Wisp | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.3 m | Day | A typical adult Wisp of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01583` | Whisperwood Wisp | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.3 m | Day | A typical adult Wisp of this region, with moss-green coloring that blends with the undergrowth. |

## Contracts and story encounters

- [[Quests/Weekly Board/Moonbloom Picking|Moonbloom Picking]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/Bad Dreams at the Orphanage|Bad Dreams at the Orphanage]] — rank undefined, in [[Regions/Aldmere|Aldmere]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
