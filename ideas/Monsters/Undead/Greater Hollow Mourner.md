---
type: monster
id: mon_greater_hollow_mourner
family: "Undead"
rank: "E"
tier: variant
tags: [monster, undead]
---
# Greater Hollow Mourner

![[mon_greater_hollow_mourner_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_hollow_mourner_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Hollow Mourner is a large creature with an upright humanoid build, about 2.7 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Survivors describe a weeping figure that moves only when you look away. It has eyes set slightly too far apart. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Hollow Mourner\|Hollow Mourner]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.7 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1929 · 137 · 114 · 91 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.7 m high × 0.81 m long × 0.86 m wide; prefab scale 1.5.
- **Physics:** 255.9 kg, gravity ×1.5, poise 70, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 5.44 m/s, turn 243°/s, stopping distance 0.86 m.
- **Attack count:** 5; **signature:** a weeping figure that moves only when you look away.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Hollow Mourner is a **dread undead** encountered at E rank, around level 26. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a weeping figure that moves only when you look away. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, E+, E-, D, E | 13–48 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | F+, E+, E | 13–32 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | E-, E+, D- | 19–40 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03727` | Whisperwood Greater Hollow Mourner Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 1.89 m | Night | Like a typical Greater Hollow Mourner, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03728` | Great Labyrinth (Floors 1-40) Greater Hollow Mourner Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F+ | 13 | 1.89 m | Night | Like a typical Greater Hollow Mourner, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03729` | Whisperwood Greater Hollow Mourner Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 2.7 m | Night | Like a typical Greater Hollow Mourner, but a rare pale form with white skin or fur and red eyes. |
| `pop_03730` | Whisperwood Greater Hollow Mourner Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 2.29 m | Night | Like a typical Greater Hollow Mourner, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03731` | Great Labyrinth (Floors 1-40) Greater Hollow Mourner Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E+ | 32 | 2.7 m | Night | Like a typical Greater Hollow Mourner, but a rare pale form with white skin or fur and red eyes. |
| `pop_03732` | Aldmere Greater Hollow Mourner Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 2.29 m | Night | Like a typical Greater Hollow Mourner, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03733` | Whisperwood Greater Hollow Mourner Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 3.65 m | Night | Like a typical Greater Hollow Mourner, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03734` | Aldmere Greater Hollow Mourner Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 2.97 m | Night | Like a typical Greater Hollow Mourner, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_03735` | Whisperwood Greater Hollow Mourner | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 2.7 m | Night | A typical adult Greater Hollow Mourner of this region, with dust-grey coloring and old rune scars. |
| `pop_03736` | Aldmere Greater Hollow Mourner Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 3.38 m | Night | Like a typical Greater Hollow Mourner, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_03737` | Great Labyrinth (Floors 1-40) Greater Hollow Mourner | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 2.7 m | Night | A typical adult Greater Hollow Mourner of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
