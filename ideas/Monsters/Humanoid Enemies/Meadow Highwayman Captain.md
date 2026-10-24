---
type: monster
id: mon_meadow_highwayman_captain
family: "Humanoid Enemies"
rank: "D+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Meadow Highwayman Captain

![[mon_meadow_highwayman_captain_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_meadow_highwayman_captain_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Meadow Highwayman Captain is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its clothing and gear are rough, scarred and spiked, colored in pale jade and cloud white. Guild sketches always show a feathered hat and two pistols of Veilborn design. It has burning slit pupils. A distinctive marking runs along its back. It strides with heavy steps, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Highwayman Captain\|Highwayman Captain]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5135 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Velmark\|Velmark]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 68.2 kg, gravity ×1.2, poise 65, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.86 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** a feathered hat and two pistols of Veilborn design.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Highwayman Captain is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a feathered hat and two pistols of Veilborn design. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Velmark|Velmark]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies D|loot_humanoid_enemy_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | D, D+, C-, C+ | 48–86 | Day & Night |
| [[Regions/Velmark\|Velmark]] | 6 | C-, D-, C+, C, D | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05571` | Aldmere Meadow Highwayman Captain Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 1.53 m | Day & Night | Like a typical Meadow Highwayman Captain, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05572` | Velmark Meadow Highwayman Captain Scarred | [[Regions/Velmark\|Velmark]] | Scarred | C- | 65 | 1.98 m | Day & Night | Like a typical Meadow Highwayman Captain, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05573` | Aldmere Meadow Highwayman Captain | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 1.8 m | Day & Night | A typical adult Meadow Highwayman Captain of this region, with golden, grass-toned coloring. |
| `pop_05574` | Aldmere Meadow Highwayman Captain Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 1.8 m | Day & Night | Like a typical Meadow Highwayman Captain, but a rare pale form with white skin or fur and red eyes. |
| `pop_05575` | Aldmere Meadow Highwayman Captain Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 1.98 m | Day & Night | Like a typical Meadow Highwayman Captain, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05576` | Velmark Meadow Highwayman Captain Albino | [[Regions/Velmark\|Velmark]] | Albino | C- | 65 | 1.8 m | Day & Night | Like a typical Meadow Highwayman Captain, but a rare pale form with white skin or fur and red eyes. |
| `pop_05577` | Velmark Meadow Highwayman Captain Runt | [[Regions/Velmark\|Velmark]] | Runt | D- | 40 | 1.26 m | Day & Night | Like a typical Meadow Highwayman Captain, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05578` | Velmark Meadow Highwayman Captain Elderborn | [[Regions/Velmark\|Velmark]] | Elderborn | C+ | 86 | 2.43 m | Day & Night | Like a typical Meadow Highwayman Captain, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05579` | Velmark Meadow Highwayman Captain Alpha | [[Regions/Velmark\|Velmark]] | Alpha | C | 76 | 2.25 m | Day & Night | Like a typical Meadow Highwayman Captain, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05580` | Velmark Meadow Highwayman Captain Juvenile | [[Regions/Velmark\|Velmark]] | Juvenile | D | 48 | 1.53 m | Day & Night | Like a typical Meadow Highwayman Captain, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05581` | Aldmere Meadow Highwayman Captain Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 2.43 m | Day & Night | Like a typical Meadow Highwayman Captain, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
