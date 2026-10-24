---
type: monster
id: mon_ancient_scorpion_rider
family: "Centaurs & Taurs"
rank: "A"
tier: variant
tags: [monster, centaurs-taurs]
---
# Ancient Scorpion Rider

![[mon_ancient_scorpion_rider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_scorpion_rider_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Scorpion Rider is a large creature with a centauroid body with a humanoid torso on a four-legged base, about 4.5 m tall. Its coat is rough, scarred and spiked, colored in bruise purple with sickly green. Survivors describe a humanoid torso on a giant scorpion body. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by a low toxic haze that clings to the ground. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Variant of | [[Monsters/Centaurs & Taurs/Scorpion Rider\|Scorpion Rider]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 4.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 29044 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 4.73 m high × 4.5 m long × 1.08 m wide; prefab scale 1.875.
- **Physics:** 1822.5 kg, gravity ×1.3, poise 302, knockback resistance 0.75, death style `ragdoll_slide`.
- **Navigation:** speed 10.79 m/s, turn 170°/s, stopping distance 1.12 m.
- **Attack count:** 5; **signature:** a humanoid torso on a giant scorpion body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Scorpion Rider is a **menacing beastfolk** encountered at A rank, around level 146. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a humanoid torso on a giant scorpion body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs A|loot_centaur_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 6 | A-, A, A+, B+, S, S- | 120–188 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 5 | B+, A+, A-, A, S- | 120–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05158` | Moraveil Ancient Scorpion Rider Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A- | 132 | 3.82 m | Day & Night | Like a typical Ancient Scorpion Rider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05159` | Zaruma Ancient Scorpion Rider Runt | [[Regions/Zaruma\|Zaruma]] | Runt | B+ | 120 | 3.15 m | Day & Night | Like a typical Ancient Scorpion Rider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05160` | Moraveil Ancient Scorpion Rider | [[Regions/Moraveil\|Moraveil]] | Adult | A | 146 | 4.5 m | Day & Night | A typical adult Ancient Scorpion Rider of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05161` | Moraveil Ancient Scorpion Rider Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A+ | 159 | 4.95 m | Day & Night | Like a typical Ancient Scorpion Rider, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05162` | Moraveil Ancient Scorpion Rider Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B+ | 120 | 3.15 m | Day & Night | Like a typical Ancient Scorpion Rider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05163` | Moraveil Ancient Scorpion Rider Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S | 188 | 6.08 m | Day & Night | Like a typical Ancient Scorpion Rider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05164` | Zaruma Ancient Scorpion Rider Albino | [[Regions/Zaruma\|Zaruma]] | Albino | A+ | 159 | 4.5 m | Day & Night | Like a typical Ancient Scorpion Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_05165` | Zaruma Ancient Scorpion Rider Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | A- | 132 | 3.82 m | Day & Night | Like a typical Ancient Scorpion Rider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05166` | Zaruma Ancient Scorpion Rider | [[Regions/Zaruma\|Zaruma]] | Adult | A | 146 | 4.5 m | Day & Night | A typical adult Ancient Scorpion Rider of this region, with golden, grass-toned coloring. |
| `pop_05167` | Zaruma Ancient Scorpion Rider Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | S- | 173 | 5.63 m | Day & Night | Like a typical Ancient Scorpion Rider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05168` | Moraveil Ancient Scorpion Rider Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S- | 173 | 5.63 m | Day & Night | Like a typical Ancient Scorpion Rider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
