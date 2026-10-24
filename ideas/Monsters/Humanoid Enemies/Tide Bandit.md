---
type: monster
id: mon_tide_bandit
family: "Humanoid Enemies"
rank: "F+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Tide Bandit

> The Tide Bandit is a person-sized creature with an upright humanoid build, about 1.8 m tall. Its clothing and gear are rough, scarred and spiked, colored in deep blues with a glassy shine. Look for a patched cloak and a mismatched sword. It has burning slit pupils. It has no ornament at all: simple, readable shapes. It strides with heavy steps, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Bandit\|Bandit]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 1.8 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 646 · 74 · 62 · 50 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Lightning. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 79.6 kg, gravity ×1.5, poise 50, knockback resistance 0.3, death style `ragdoll`.
- **Navigation:** speed 5.18 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** a patched cloak and a mismatched sword.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tide Bandit is a **menacing humanoid** encountered at F+ rank, around level 13. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a patched cloak and a mismatched sword. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies F|loot_humanoid_enemy_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | F, E+, E-, F-, F+, E | 3–32 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F, E-, E, F+ | 8–26 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05560` | Aldmere Tide Bandit Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 1.53 m | Day & Night | Like a typical Tide Bandit, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05561` | Whisperwood Tide Bandit Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 1.53 m | Day & Night | Like a typical Tide Bandit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05562` | Aldmere Tide Bandit Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 2.43 m | Day & Night | Like a typical Tide Bandit, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05563` | Whisperwood Tide Bandit Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E- | 19 | 1.8 m | Day & Night | Like a typical Tide Bandit, but a rare pale form with white skin or fur and red eyes. |
| `pop_05564` | Aldmere Tide Bandit Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 1.8 m | Day & Night | Like a typical Tide Bandit, but a rare pale form with white skin or fur and red eyes. |
| `pop_05565` | Whisperwood Tide Bandit Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E- | 19 | 1.98 m | Day & Night | Like a typical Tide Bandit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05566` | Aldmere Tide Bandit Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.26 m | Day & Night | Like a typical Tide Bandit, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05567` | Aldmere Tide Bandit | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 1.8 m | Day & Night | A typical adult Tide Bandit of this region, with golden, grass-toned coloring. |
| `pop_05568` | Whisperwood Tide Bandit Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E | 26 | 2.25 m | Day & Night | Like a typical Tide Bandit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05569` | Whisperwood Tide Bandit | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 1.8 m | Day & Night | A typical adult Tide Bandit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05570` | Aldmere Tide Bandit Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 2.25 m | Day & Night | Like a typical Tide Bandit, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
