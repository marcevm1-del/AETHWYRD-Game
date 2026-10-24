---
type: monster
id: mon_moss_slime
family: "Slimes"
rank: "E+"
tier: variant
tags: [monster, slimes]
---
# Moss Slime

> The Moss Slime is a small creature with a dome-shaped gelatinous body, about 0.5 m tall. Its gel is weathered and natural, colored in leaf greens over bark brown. Survivors describe a faint ember core pulsing like a heartbeat. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Red Slime\|Red Slime]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 962 · 110 · 83 · 83 · 83 · 110 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.5 m high × 0.47 m long × 0.45 m wide; prefab scale 1.
- **Physics:** 65.6 kg, gravity ×1.6, poise 29, knockback resistance 0.13, death style `splat_dissolve`.
- **Navigation:** speed 3.64 m/s, turn 509°/s, stopping distance 0.63 m.
- **Attack count:** 5; **signature:** a faint ember core pulsing like a heartbeat.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Moss Slime is a **wild ooze** encountered at E+ rank, around level 32. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a faint ember core pulsing like a heartbeat. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes E|loot_slime_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | D-, E-, E+, D+ | 19–56 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 6 | D-, E, D, E-, E+, D+ | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02928` | Aldmere Moss Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.55 m | Day & Night | Like a typical Moss Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02929` | Whisperwood Moss Slime Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | D- | 40 | 0.5 m | Day & Night | Like a typical Moss Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02930` | Whisperwood Moss Slime Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.42 m | Day & Night | Like a typical Moss Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02931` | Aldmere Moss Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.5 m | Day & Night | Like a typical Moss Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02932` | Whisperwood Moss Slime Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 0.63 m | Day & Night | Like a typical Moss Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02933` | Aldmere Moss Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.35 m | Day & Night | Like a typical Moss Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02934` | Aldmere Moss Slime | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.5 m | Day & Night | A typical adult Moss Slime of this region, with golden, grass-toned coloring. |
| `pop_02935` | Whisperwood Moss Slime Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 0.35 m | Day & Night | Like a typical Moss Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02936` | Whisperwood Moss Slime | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 0.5 m | Day & Night | A typical adult Moss Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02937` | Aldmere Moss Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 0.68 m | Day & Night | Like a typical Moss Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02938` | Whisperwood Moss Slime Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 0.68 m | Day & Night | Like a typical Moss Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
