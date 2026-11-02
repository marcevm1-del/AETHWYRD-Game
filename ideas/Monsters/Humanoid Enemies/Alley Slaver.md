---
type: monster
id: mon_alley_slaver
family: "Humanoid Enemies"
rank: "D+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Alley Slaver

![[mon_alley_slaver_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_alley_slaver_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,164 tris · 1.03 × 0.7 × 1.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Alley Slaver is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in leather browns and dull steel. Guild sketches always show chains on its belt and a cruel smile. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it. Adapted to city lands, it has soot-stained hide and scavenged scraps.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Slaver\|Slaver]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5231 · 281 · 234 · 131 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Velmark\|Velmark]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 89.2 kg, gravity ×1.5, poise 67, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.58 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 4; **signature:** chains on its belt and a cruel smile.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Alley Slaver is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** chains on its belt and a cruel smile. Watch for its tell and leave a response window before committing to a long combo.

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
| [[Regions/Velmark\|Velmark]] | 7 | C+, D-, C, D, C-, D+ | 40–86 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C+, D-, C, D | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05582` | Velmark Alley Slaver Elderborn | [[Regions/Velmark\|Velmark]] | Elderborn | C+ | 86 | 2.56 m | Day & Night | Like a typical Alley Slaver, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05583` | Velmark Alley Slaver Runt | [[Regions/Velmark\|Velmark]] | Runt | D- | 40 | 1.33 m | Day & Night | Like a typical Alley Slaver, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05584` | Aldmere Alley Slaver Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 2.56 m | Day & Night | Like a typical Alley Slaver, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05585` | Velmark Alley Slaver Alpha | [[Regions/Velmark\|Velmark]] | Alpha | C | 76 | 2.38 m | Day & Night | Like a typical Alley Slaver, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05586` | Velmark Alley Slaver Juvenile | [[Regions/Velmark\|Velmark]] | Juvenile | D | 48 | 1.61 m | Day & Night | Like a typical Alley Slaver, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05587` | Aldmere Alley Slaver Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 1.33 m | Day & Night | Like a typical Alley Slaver, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05588` | Aldmere Alley Slaver Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 2.38 m | Day & Night | Like a typical Alley Slaver, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05589` | Velmark Alley Slaver Scarred | [[Regions/Velmark\|Velmark]] | Scarred | C- | 65 | 2.09 m | Day & Night | Like a typical Alley Slaver, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05590` | Velmark Alley Slaver | [[Regions/Velmark\|Velmark]] | Adult | D+ | 56 | 1.9 m | Day & Night | A typical adult Alley Slaver of this region, with golden, grass-toned coloring. |
| `pop_05591` | Velmark Alley Slaver Albino | [[Regions/Velmark\|Velmark]] | Albino | C- | 65 | 1.9 m | Day & Night | Like a typical Alley Slaver, but a rare pale form with white skin or fur and red eyes. |
| `pop_05592` | Aldmere Alley Slaver Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 1.61 m | Day & Night | Like a typical Alley Slaver, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#96743a` `#62656f` `#c8834d` · triangle-based silhouette, sharp asymmetric spikes
