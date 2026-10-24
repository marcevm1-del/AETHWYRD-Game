---
type: monster
id: mon_dawn_zombie
family: "Undead"
rank: "F+"
tier: variant
tags: [monster, undead]
---
# Dawn Zombie

![[mon_dawn_zombie_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dawn_zombie_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dawn Zombie is a person-sized creature with a lean humanoid frame, about 1.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in warm gold and pearl white. Look for grey skin, burial clothes and a slack jaw. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It strides with heavy steps, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Zombie\|Zombie]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 1.7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 633 · 74 · 62 · 50 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override (base species)); animation set `anim_medium_biped`.
- **Dimensions:** 1.7 m high × 0.51 m long × 0.54 m wide; prefab scale 0.944.
- **Physics:** 60.7 kg, gravity ×1.35, poise 49, knockback resistance 0.3, death style `ragdoll`.
- **Navigation:** speed 5.27 m/s, turn 307°/s, stopping distance 0.69 m.
- **Attack count:** 5; **signature:** grey skin, burial clothes and a slack jaw.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dawn Zombie is a **menacing undead** encountered at F+ rank, around level 13. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** grey skin, burial clothes and a slack jaw. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead F|loot_undead_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 2 | E, E+ | 26–32 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F, E+, E-, F+ | 8–32 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | E-, F+, E, E+, F | 8–32 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06550` | Aldmere Dawn Zombie Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 2.13 m | Night | Like a typical Dawn Zombie, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06551` | Whisperwood Dawn Zombie Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 1.44 m | Night | Like a typical Dawn Zombie, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_06552` | Great Labyrinth (Floors 1-40) Dawn Zombie Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E- | 19 | 1.7 m | Night | Like a typical Dawn Zombie, but a rare pale form with white skin or fur and red eyes. |
| `pop_06553` | Whisperwood Dawn Zombie Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E+ | 32 | 2.29 m | Night | Like a typical Dawn Zombie, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06554` | Whisperwood Dawn Zombie Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E- | 19 | 1.7 m | Night | Like a typical Dawn Zombie, but a rare pale form with white skin or fur and red eyes. |
| `pop_06555` | Aldmere Dawn Zombie Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 2.29 m | Night | Like a typical Dawn Zombie, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06556` | Great Labyrinth (Floors 1-40) Dawn Zombie | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F+ | 13 | 1.7 m | Night | A typical adult Dawn Zombie of this region, with dust-grey coloring and old rune scars. |
| `pop_06557` | Great Labyrinth (Floors 1-40) Dawn Zombie Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 2.13 m | Night | Like a typical Dawn Zombie, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_06558` | Whisperwood Dawn Zombie | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 1.7 m | Night | A typical adult Dawn Zombie of this region, with dust-grey coloring and old rune scars. |
| `pop_06559` | Great Labyrinth (Floors 1-40) Dawn Zombie Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E+ | 32 | 2.29 m | Night | Like a typical Dawn Zombie, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06560` | Great Labyrinth (Floors 1-40) Dawn Zombie Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F | 8 | 1.44 m | Night | Like a typical Dawn Zombie, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
