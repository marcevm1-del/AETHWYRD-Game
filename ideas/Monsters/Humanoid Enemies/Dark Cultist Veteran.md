---
type: monster
id: mon_dark_cultist_veteran
family: "Humanoid Enemies"
rank: "B"
tier: variant
tags: [monster, humanoid-enemies]
---
# Dark Cultist Veteran

![[mon_dark_cultist_veteran_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dark_cultist_veteran_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dark Cultist Veteran is a large creature with a broad-shouldered humanoid build, about 2.9 m tall. Its clothing and gear are patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Its most striking feature is red robes and a mask shaped like a crescent moon. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by a faint red mist that smells of iron. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Dark Cultist\|Dark Cultist]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2.9 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16024 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.9 m high × 0.87 m long × 0.93 m wide; prefab scale 1.611.
- **Physics:** 348.8 kg, gravity ×1.5, poise 102, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.26 m/s, turn 235°/s, stopping distance 0.89 m.
- **Attack count:** 5; **signature:** red robes and a mask shaped like a crescent moon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dark Cultist Veteran is a **dread humanoid** encountered at B rank, around level 108. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** red robes and a mask shaped like a crescent moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies B|loot_humanoid_enemy_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vharlen\|Vharlen]] | 6 | A, B+, B-, A-, B, C+ | 86–146 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C+, B+, B, A- | 86–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05593` | Vharlen Dark Cultist Veteran Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | A | 146 | 3.92 m | Night | Like a typical Dark Cultist Veteran, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05594` | Strife Marches Dark Cultist Veteran Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 2.03 m | Night | Like a typical Dark Cultist Veteran, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05595` | Strife Marches Dark Cultist Veteran Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 2.9 m | Night | Like a typical Dark Cultist Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_05596` | Strife Marches Dark Cultist Veteran | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 2.9 m | Night | A typical adult Dark Cultist Veteran of this region, with golden, grass-toned coloring. |
| `pop_05597` | Vharlen Dark Cultist Veteran Albino | [[Regions/Vharlen\|Vharlen]] | Albino | B+ | 120 | 2.9 m | Night | Like a typical Dark Cultist Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_05598` | Strife Marches Dark Cultist Veteran Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B+ | 120 | 3.19 m | Night | Like a typical Dark Cultist Veteran, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05599` | Vharlen Dark Cultist Veteran Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | B- | 96 | 2.46 m | Night | Like a typical Dark Cultist Veteran, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05600` | Vharlen Dark Cultist Veteran Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A- | 132 | 3.63 m | Night | Like a typical Dark Cultist Veteran, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05601` | Vharlen Dark Cultist Veteran | [[Regions/Vharlen\|Vharlen]] | Adult | B | 108 | 2.9 m | Night | A typical adult Dark Cultist Veteran of this region, with golden, grass-toned coloring. |
| `pop_05602` | Strife Marches Dark Cultist Veteran Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A- | 132 | 3.63 m | Night | Like a typical Dark Cultist Veteran, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05603` | Vharlen Dark Cultist Veteran Runt | [[Regions/Vharlen\|Vharlen]] | Runt | C+ | 86 | 2.03 m | Night | Like a typical Dark Cultist Veteran, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
