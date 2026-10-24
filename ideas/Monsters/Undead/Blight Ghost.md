---
type: monster
id: mon_blight_ghost
family: "Undead"
rank: "E+"
tier: variant
tags: [monster, undead]
---
# Blight Ghost

![[mon_blight_ghost_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blight_ghost_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,672 tris · 1.314 × 1.454 × 1.7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Blight Ghost is a person-sized creature with a floating, cloth-like shape, about 1.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in bruise purple with sickly green. Its most striking feature is a translucent figure frozen in its last moment. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Ghost\|Ghost]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1615 · 83 · 97 · 193 · 179 · 90 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 1.7 m high × 0.51 m long × 1.09 m wide; prefab scale 1.7.
- **Physics:** 0.5 kg, gravity ×0, poise 10, knockback resistance 0.03, death style `dissolve_into_motes`.
- **Navigation:** speed 6.48 m/s, turn 552°/s, stopping distance 0.83 m.
- **Attack count:** 5; **signature:** a translucent figure frozen in its last moment.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blight Ghost is a **menacing undead** encountered at E+ rank, around level 32. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a translucent figure frozen in its last moment. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead E|loot_undead_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Greymoor\|Greymoor]] | 5 | D+, E+, D-, D | 32–56 | Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | D-, D, D+, E-, E+ | 19–56 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06605` | Greymoor Blight Ghost Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D+ | 56 | 2.29 m | Night | Like a typical Blight Ghost, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06606` | Greymoor Blight Ghost | [[Regions/Greymoor\|Greymoor]] | Adult | E+ | 32 | 1.7 m | Night | A typical adult Blight Ghost of this region, with mud-slick, algae-streaked skin. |
| `pop_06607` | Aldmere Blight Ghost Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.87 m | Night | Like a typical Blight Ghost, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_06608` | Aldmere Blight Ghost Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 2.13 m | Night | Like a typical Blight Ghost, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06609` | Aldmere Blight Ghost Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1.7 m | Night | Like a typical Blight Ghost, but a rare pale form with white skin or fur and red eyes. |
| `pop_06610` | Aldmere Blight Ghost Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 2.29 m | Night | Like a typical Blight Ghost, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06611` | Greymoor Blight Ghost Albino | [[Regions/Greymoor\|Greymoor]] | Albino | D- | 40 | 1.7 m | Night | Like a typical Blight Ghost, but a rare pale form with white skin or fur and red eyes. |
| `pop_06612` | Greymoor Blight Ghost Scarred | [[Regions/Greymoor\|Greymoor]] | Scarred | D- | 40 | 1.87 m | Night | Like a typical Blight Ghost, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_06613` | Greymoor Blight Ghost Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | D | 48 | 2.13 m | Night | Like a typical Blight Ghost, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06614` | Aldmere Blight Ghost Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 1.19 m | Night | Like a typical Blight Ghost, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_06615` | Aldmere Blight Ghost | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 1.7 m | Night | A typical adult Blight Ghost of this region, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
