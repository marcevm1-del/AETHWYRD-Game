---
type: monster
id: mon_vesper_touched_will_o_wisp
family: "Elementals & Spirits"
rank: "D-"
tier: variant
tags: [monster, elementals-spirits]
---
# Vesper-Touched Will-o'-Wisp

![[mon_vesper_touched_will_o_wisp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_will_o_wisp_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.241 × 0.257 × 0.3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Elementals & Spirits/mon_vesper_touched_will_o_wisp.fbx`

> The Vesper-Touched Will-o'-Wisp is a tiny creature with a bodiless, glowing form, about 0.3 m tall. Its body is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Its most striking feature is a pale flame that leads travelers into bogs. It has too many eyes, opening one after another. A distinctive marking runs along its back. It copies the walk of whatever it hunts, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Will-o'-Wisp\|Will-o'-Wisp]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 0.3 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1347 · 102 · 119 · 238 · 221 · 90 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 0.3 m high × 0.09 m long × 0.19 m wide; prefab scale 0.3.
- **Physics:** 0.5 kg, gravity ×0, poise 5, knockback resistance 0.06, death style `dissolve_into_motes`.
- **Navigation:** speed 3.28 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a pale flame that leads travelers into bogs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Will-o'-Wisp is a **horror elemental** encountered at D- rank, around level 40. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a pale flame that leads travelers into bogs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits D|loot_elemental_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 2 | D, D+ | 48–56 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | E+, D, D-, E, D+ | 26–56 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | D, C-, D- | 40–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04462` | Aldmere Vesper-Touched Will-o'-Wisp Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D | 48 | 0.33 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04463` | Hoshizora Vesper-Touched Will-o'-Wisp Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | E+ | 32 | 0.26 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04464` | Hoshizora Vesper-Touched Will-o'-Wisp Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D | 48 | 0.3 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but a rare pale form with white skin or fur and red eyes. |
| `pop_04465` | Hoshizora Vesper-Touched Will-o'-Wisp | [[Regions/Hoshizora\|Hoshizora]] | Adult | D- | 40 | 0.3 m | Night | A typical adult Vesper-Touched Will-o'-Wisp of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04466` | Hoshizora Vesper-Touched Will-o'-Wisp Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E | 26 | 0.21 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04467` | Hoshizora Vesper-Touched Will-o'-Wisp Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D | 48 | 0.33 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04468` | Aldmere Vesper-Touched Will-o'-Wisp Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 0.38 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04469` | Iron Hold Vesper-Touched Will-o'-Wisp Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D | 48 | 0.33 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04470` | Iron Hold Vesper-Touched Will-o'-Wisp Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C- | 65 | 0.41 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04471` | Iron Hold Vesper-Touched Will-o'-Wisp | [[Regions/Iron Hold\|Iron Hold]] | Adult | D- | 40 | 0.3 m | Night | A typical adult Vesper-Touched Will-o'-Wisp of this region, with slate-grey coloring and hardened hide. |
| `pop_04472` | Hoshizora Vesper-Touched Will-o'-Wisp Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | D+ | 56 | 0.38 m | Night | Like a typical Vesper-Touched Will-o'-Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#292940` · broken symmetry, mimicry, audio-first reveal
