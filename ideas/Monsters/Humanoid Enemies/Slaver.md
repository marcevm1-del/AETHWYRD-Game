---
type: monster
id: mon_slaver
family: "Humanoid Enemies"
rank: "D"
tier: core
tags: [monster, humanoid-enemies]
---
# Slaver

![[mon_slaver_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_slaver_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Slaver is a person-sized creature with a lean humanoid frame, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is chains on its belt and a cruel smile. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4168 · 242 · 202 · 113 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 89.2 kg, gravity ×1.5, poise 67, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.32 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 4; **signature:** chains on its belt and a cruel smile.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Slaver is a **menacing humanoid** encountered at D rank, around level 48. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** chains on its belt and a cruel smile. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Velmark|Velmark]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies D|loot_humanoid_enemy_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Alley Slaver|Alley Slaver]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 2 | E+, C- | 32–65 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | D+, C-, E+ | 32–65 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | C, D+, D, D- | 40–76 | Day & Night |
| [[Regions/Velmark\|Velmark]] | 1 | C- | 65–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 1 | D | 48–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02740` | Moraveil Slaver Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 1.33 m | Day & Night | Like a typical Slaver, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02741` | Strife Marches Slaver Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | D+ | 56 | 1.9 m | Day & Night | Like a typical Slaver, but a rare pale form with white skin or fur and red eyes. |
| `pop_02742` | Strife Marches Slaver Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 2.38 m | Day & Night | Like a typical Slaver, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02743` | Moraveil Slaver Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 2.38 m | Day & Night | Like a typical Slaver, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02744` | Hoshizora Slaver Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 2.56 m | Day & Night | Like a typical Slaver, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02745` | Hoshizora Slaver Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 2.09 m | Day & Night | Like a typical Slaver, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02746` | Velmark Slaver Alpha | [[Regions/Velmark\|Velmark]] | Alpha | C- | 65 | 2.38 m | Day & Night | Like a typical Slaver, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02747` | Hoshizora Slaver | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 1.9 m | Day & Night | A typical adult Slaver of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02748` | Hoshizora Slaver Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 1.61 m | Day & Night | Like a typical Slaver, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02749` | Strife Marches Slaver Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.33 m | Day & Night | Like a typical Slaver, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02750` | Aldmere Slaver | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.9 m | Day & Night | A typical adult Slaver of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
