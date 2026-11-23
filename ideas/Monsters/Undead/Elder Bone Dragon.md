---
type: monster
id: mon_elder_bone_dragon
family: "Undead"
rank: "SS"
tier: variant
tags: [monster, undead]
---
# Elder Bone Dragon

![[mon_elder_bone_dragon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_bone_dragon_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 51.184 × 32 × 22.83 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_elder_bone_dragon.fbx`

> The Elder Bone Dragon is a colossal creature with a four-legged, two-winged dragon body, about 32 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with violet markings. Its most striking feature is a dragon skeleton held together by green fire. It has eyes that never blink. The air distorts slightly around its outline. It freezes whenever it is looked at, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Bone Dragon\|Bone Dragon]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 32 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 138276 · 1240 · 1145 · 1240 · 1145 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 17.92 m high × 32 m long × 45.12 m wide; prefab scale 2.667.
- **Physics:** 226099.2 kg, gravity ×1, poise 1339, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 13.26 m/s, turn 106°/s, stopping distance 2.96 m.
- **Attack count:** 6; **signature:** a dragon skeleton held together by green fire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Bone Dragon is a **dread undead** encountered at SS rank, around level 236. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dragon skeleton held together by green fire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead SS|loot_undead_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | SSS, SSS-, SS+, S+, SS, SS- | 203–281 | Night |
| [[Regions/Vesper\|Vesper]] | 4 | SS+, S+, SSS, SSS- | 203–281 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06704` | Nox Dominion Elder Bone Dragon Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SSS | 281 | 43.2 m | Night | Like a typical Elder Bone Dragon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_06705` | Nox Dominion Elder Bone Dragon Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SSS- | 267 | 40 m | Night | Like a typical Elder Bone Dragon, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_06706` | Vesper Elder Bone Dragon Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SS+ | 253 | 35.2 m | Night | Like a typical Elder Bone Dragon, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_06707` | Nox Dominion Elder Bone Dragon Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS+ | 253 | 35.2 m | Night | Like a typical Elder Bone Dragon, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_06708` | Nox Dominion Elder Bone Dragon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S+ | 203 | 22.4 m | Night | Like a typical Elder Bone Dragon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_06709` | Nox Dominion Elder Bone Dragon Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS+ | 253 | 32 m | Night | Like a typical Elder Bone Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_06710` | Nox Dominion Elder Bone Dragon | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SS | 236 | 32 m | Night | A typical adult Elder Bone Dragon of this region, with red-black coloring with faint ember veins. |
| `pop_06711` | Vesper Elder Bone Dragon Runt | [[Regions/Vesper\|Vesper]] | Runt | S+ | 203 | 22.4 m | Night | Like a typical Elder Bone Dragon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_06712` | Nox Dominion Elder Bone Dragon Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SS- | 218 | 27.2 m | Night | Like a typical Elder Bone Dragon, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_06713` | Vesper Elder Bone Dragon Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SSS | 281 | 43.2 m | Night | Like a typical Elder Bone Dragon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_06714` | Vesper Elder Bone Dragon Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SSS- | 267 | 40 m | Night | Like a typical Elder Bone Dragon, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#ebe5bf` `#969171` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
