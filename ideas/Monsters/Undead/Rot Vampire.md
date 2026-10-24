---
type: monster
id: mon_rot_vampire
family: "Undead"
rank: "A-"
tier: variant
tags: [monster, undead]
---
# Rot Vampire

> The Rot Vampire is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its flesh and bone are rough, scarred and spiked, colored in bruise purple with sickly green. Its most striking feature is aristocratic clothes and eyes like garnets. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Vampire\|Vampire]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18374 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Cinderhole\|Cinderhole]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 88, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 5.26 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** aristocratic clothes and eyes like garnets.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rot Vampire is a **menacing undead** encountered at A- rank, around level 132. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** aristocratic clothes and eyes like garnets. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Cinderhole|Cinderhole]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead A|loot_undead_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 5 | S-, A+, A-, A | 132–173 | Night |
| [[Regions/Cinderhole\|Cinderhole]] | 6 | A, S-, B, B+, A+ | 108–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06671` | Lumbaya Rot Vampire Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | S- | 173 | 2.43 m | Night | Like a typical Rot Vampire, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06672` | Cinderhole Rot Vampire Albino | [[Regions/Cinderhole\|Cinderhole]] | Albino | A | 146 | 1.8 m | Night | Like a typical Rot Vampire, but a rare pale form with white skin or fur and red eyes. |
| `pop_06673` | Cinderhole Rot Vampire Scarred | [[Regions/Cinderhole\|Cinderhole]] | Scarred | A | 146 | 1.98 m | Night | Like a typical Rot Vampire, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_06674` | Lumbaya Rot Vampire Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | A+ | 159 | 2.25 m | Night | Like a typical Rot Vampire, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_06675` | Cinderhole Rot Vampire Elderborn | [[Regions/Cinderhole\|Cinderhole]] | Elderborn | S- | 173 | 2.43 m | Night | Like a typical Rot Vampire, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_06676` | Lumbaya Rot Vampire | [[Regions/Lumbaya\|Lumbaya]] | Adult | A- | 132 | 1.8 m | Night | A typical adult Rot Vampire of this region, with dust-grey coloring and old rune scars. |
| `pop_06677` | Cinderhole Rot Vampire Runt | [[Regions/Cinderhole\|Cinderhole]] | Runt | B | 108 | 1.26 m | Night | Like a typical Rot Vampire, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_06678` | Lumbaya Rot Vampire Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | A | 146 | 1.98 m | Night | Like a typical Rot Vampire, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_06679` | Lumbaya Rot Vampire Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | A | 146 | 1.8 m | Night | Like a typical Rot Vampire, but a rare pale form with white skin or fur and red eyes. |
| `pop_06680` | Cinderhole Rot Vampire Juvenile | [[Regions/Cinderhole\|Cinderhole]] | Juvenile | B+ | 120 | 1.53 m | Night | Like a typical Rot Vampire, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_06681` | Cinderhole Rot Vampire Alpha | [[Regions/Cinderhole\|Cinderhole]] | Alpha | A+ | 159 | 2.25 m | Night | Like a typical Rot Vampire, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
