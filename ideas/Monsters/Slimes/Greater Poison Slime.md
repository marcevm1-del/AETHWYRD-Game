---
type: monster
id: mon_greater_poison_slime
family: "Slimes"
rank: "D"
tier: variant
tags: [monster, slimes]
---
# Greater Poison Slime

> The Greater Poison Slime is a small creature with a wobbling mound of translucent gel, about 1 m tall. Its gel is rough, scarred and spiked, colored in bruise purple with sickly green. Survivors describe purple bubbles that hiss when they pop. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Poison Slime\|Poison Slime]] (elder) |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2137 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1 m high × 0.93 m long × 0.9 m wide; prefab scale 2.
- **Physics:** 525 kg, gravity ×1.6, poise 46, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 5.53 m/s, turn 360°/s, stopping distance 0.85 m.
- **Attack count:** 5; **signature:** purple bubbles that hiss when they pop.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Poison Slime is a **menacing ooze** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** purple bubbles that hiss when they pop. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 5 | C-, C, E+, D+, D- | 32–76 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D+, C-, D- | 40–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D+, D, E+ | 32–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05780` | Moraveil Greater Poison Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Greater Poison Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05781` | Great Labyrinth (Floors 1-40) Greater Poison Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 1 m | Day & Night | Like a typical Greater Poison Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05782` | Aldmere Greater Poison Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Greater Poison Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05783` | Moraveil Greater Poison Slime Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C | 76 | 1.35 m | Day & Night | Like a typical Greater Poison Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05784` | Great Labyrinth (Floors 1-40) Greater Poison Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Greater Poison Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05785` | Moraveil Greater Poison Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Greater Poison Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05786` | Moraveil Greater Poison Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Greater Poison Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05787` | Aldmere Greater Poison Slime | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Greater Poison Slime of this region, with golden, grass-toned coloring. |
| `pop_05788` | Moraveil Greater Poison Slime Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Greater Poison Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05789` | Great Labyrinth (Floors 1-40) Greater Poison Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Greater Poison Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05790` | Aldmere Greater Poison Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Greater Poison Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
