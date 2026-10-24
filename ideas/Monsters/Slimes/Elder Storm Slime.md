---
type: monster
id: mon_elder_storm_slime
family: "Slimes"
rank: "A"
tier: variant
tags: [monster, slimes]
---
# Elder Storm Slime

> The Elder Storm Slime is a person-sized creature with a wobbling mound of translucent gel, about 1.9 m tall. Its gel is weathered and natural, colored in storm violet shot through with electric yellow. Survivors describe a storm-cloud interior that flashes with tiny lightning. It has dark, wary eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It stalks low to the ground, surrounded by crackling arcs that jump across its body. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Storm Slime\|Storm Slime]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 1.9 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13847 · 475 · 356 · 356 · 356 · 110 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1.9 m high × 1.77 m long × 1.71 m wide; prefab scale 3.8.
- **Physics:** 3601 kg, gravity ×1.6, poise 85, knockback resistance 0.25, death style `splat_dissolve`.
- **Navigation:** speed 8.08 m/s, turn 261°/s, stopping distance 1.25 m.
- **Attack count:** 5; **signature:** a storm-cloud interior that flashes with tiny lightning.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Storm Slime is a **wild ooze** encountered at A rank, around level 146. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a storm-cloud interior that flashes with tiny lightning. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes A|loot_slime_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | S-, A-, B+ | 120–173 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | S-, B+, A+, A- | 120–173 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | A+, B+, S-, A- | 120–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05868` | Great Labyrinth (Floors 41-90) Elder Storm Slime Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 2.38 m | Day & Night | Like a typical Elder Storm Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05869` | Hoshizora Elder Storm Slime Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | S- | 173 | 2.38 m | Day & Night | Like a typical Elder Storm Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05870` | Moraveil Elder Storm Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A+ | 159 | 2.09 m | Day & Night | Like a typical Elder Storm Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05871` | Great Labyrinth (Floors 41-90) Elder Storm Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A- | 132 | 1.61 m | Day & Night | Like a typical Elder Storm Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05872` | Moraveil Elder Storm Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B+ | 120 | 1.33 m | Day & Night | Like a typical Elder Storm Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05873` | Moraveil Elder Storm Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S- | 173 | 2.38 m | Day & Night | Like a typical Elder Storm Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05874` | Hoshizora Elder Storm Slime Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B+ | 120 | 1.33 m | Day & Night | Like a typical Elder Storm Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05875` | Hoshizora Elder Storm Slime Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | A+ | 159 | 1.9 m | Day & Night | Like a typical Elder Storm Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05876` | Hoshizora Elder Storm Slime Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A- | 132 | 1.61 m | Day & Night | Like a typical Elder Storm Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05877` | Great Labyrinth (Floors 41-90) Elder Storm Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B+ | 120 | 1.33 m | Day & Night | Like a typical Elder Storm Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05878` | Moraveil Elder Storm Slime Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A- | 132 | 1.61 m | Day & Night | Like a typical Elder Storm Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · real-animal silhouette with one fantasy exaggeration
