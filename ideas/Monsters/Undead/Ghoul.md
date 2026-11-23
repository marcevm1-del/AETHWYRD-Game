---
type: monster
id: mon_ghoul
family: "Undead"
rank: "E+"
tier: core
tags: [monster, undead]
---
# Ghoul

![[mon_ghoul_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ghoul_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,990 tris · 0.528 × 0.35 × 1.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_ghoul.fbx`

> The Ghoul is a person-sized creature with a lean humanoid frame, about 1.6 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with violet markings. Its most striking feature is grey, hairless skin and long black nails. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2175 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.6 m high × 0.48 m long × 0.51 m wide; prefab scale 0.889.
- **Physics:** 53.2 kg, gravity ×1.5, poise 54, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 5.12 m/s, turn 316°/s, stopping distance 0.67 m.
- **Attack count:** 5; **signature:** grey, hairless skin and long black nails.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ghoul is a **dread undead** encountered at E+ rank, around level 32. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** grey, hairless skin and long black nails. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor|Greymoor]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead E|loot_undead_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Vesper-Touched Ghoul|Vesper-Touched Ghoul]]
- [[Monsters/Undead/Blight Ghoul|Blight Ghoul]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Greymoor\|Greymoor]] | 2 | D-, D+ | 40–56 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | D-, D, E, D+ | 26–56 | Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D, D- | 40–48 | Night |
| [[Regions/Lirian\|Lirian]] | 3 | D+, E-, E | 19–56 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00873` | Greymoor Ghoul Albino | [[Regions/Greymoor\|Greymoor]] | Albino | D- | 40 | 1.6 m | Night | Like a typical Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_00874` | Whisperwood Ghoul Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | D- | 40 | 1.6 m | Night | Like a typical Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_00875` | Aldmere Ghoul Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 2 m | Night | Like a typical Ghoul, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_00876` | Whisperwood Ghoul Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 2 m | Night | Like a typical Ghoul, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00877` | Greymoor Ghoul Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D+ | 56 | 2.16 m | Night | Like a typical Ghoul, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_00878` | Lirian Ghoul Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D+ | 56 | 2.16 m | Night | Like a typical Ghoul, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_00879` | Lirian Ghoul Runt | [[Regions/Lirian\|Lirian]] | Runt | E- | 19 | 1.12 m | Night | Like a typical Ghoul, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_00880` | Lirian Ghoul Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | E | 26 | 1.36 m | Night | Like a typical Ghoul, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_00881` | Aldmere Ghoul Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1.6 m | Night | Like a typical Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_00882` | Whisperwood Ghoul Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 1.36 m | Night | Like a typical Ghoul, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00883` | Whisperwood Ghoul Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 2.16 m | Night | Like a typical Ghoul, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#c8bba3` `#807460` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
