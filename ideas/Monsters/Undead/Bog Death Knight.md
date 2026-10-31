---
type: monster
id: mon_bog_death_knight
family: "Undead"
rank: "B+"
tier: variant
tags: [monster, undead]
---
# Bog Death Knight

![[mon_bog_death_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_death_knight_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,544 tris · 1.301 × 1.398 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bog Death Knight is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its flesh and bone are rough, scarred and spiked, colored in grave-mould grey-green. Look for black plate, a cloak of ash and a sword of cold fire. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Death Knight\|Death Knight]] (regional) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 2.4 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17586 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Cinderhole\|Cinderhole]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 92, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 4.97 m/s, turn 258°/s, stopping distance 0.81 m.
- **Attack count:** 5; **signature:** black plate, a cloak of ash and a sword of cold fire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Death Knight is a **menacing undead** encountered at B+ rank, around level 120. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black plate, a cloak of ash and a sword of cold fire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Cinderhole|Cinderhole]], [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead B|loot_undead_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Cinderhole\|Cinderhole]] | 5 | A-, A, B-, B+ | 96–146 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | B+, B-, B, A | 96–146 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 2 | B-, B | 96–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03815` | Cinderhole Bog Death Knight Albino | [[Regions/Cinderhole\|Cinderhole]] | Albino | A- | 132 | 2.4 m | Night | Like a typical Bog Death Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_03816` | Cinderhole Bog Death Knight Alpha | [[Regions/Cinderhole\|Cinderhole]] | Alpha | A | 146 | 3 m | Night | Like a typical Bog Death Knight, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_03817` | Cinderhole Bog Death Knight Scarred | [[Regions/Cinderhole\|Cinderhole]] | Scarred | A- | 132 | 2.64 m | Night | Like a typical Bog Death Knight, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_03818` | Cinderhole Bog Death Knight Runt | [[Regions/Cinderhole\|Cinderhole]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Bog Death Knight, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_03819` | Cinderhole Bog Death Knight | [[Regions/Cinderhole\|Cinderhole]] | Adult | B+ | 120 | 2.4 m | Night | A typical adult Bog Death Knight of this region, with soot-stained hide and scavenged scraps. |
| `pop_03820` | Great Labyrinth (Floors 41-90) Bog Death Knight | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B+ | 120 | 2.4 m | Night | A typical adult Bog Death Knight of this region, with dust-grey coloring and old rune scars. |
| `pop_03821` | Great Labyrinth (Floors 41-90) Bog Death Knight Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Bog Death Knight, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03822` | Great Labyrinth (Floors 41-90) Bog Death Knight Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B | 108 | 2.04 m | Night | Like a typical Bog Death Knight, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03823` | Great Labyrinth (Floors 41-90) Bog Death Knight Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A | 146 | 3 m | Night | Like a typical Bog Death Knight, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03824` | Xochitl Mire Bog Death Knight Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Bog Death Knight, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03825` | Xochitl Mire Bog Death Knight Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | B | 108 | 2.04 m | Night | Like a typical Bog Death Knight, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8c9979` `#5b654f` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
