---
type: monster
id: mon_will_o_wisp
family: "Elementals & Spirits"
rank: "E"
tier: core
tags: [monster, elementals-spirits]
---
# Will-o'-Wisp

![[mon_will_o_wisp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_will_o_wisp_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,632 tris · 0.218 × 0.217 × 0.3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Will-o'-Wisp is a tiny creature with a drifting, half-formed body, about 0.3 m tall. Its body is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a pale flame that leads travelers into bogs. It has pale, pupil-less eyes. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 0.3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 722 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 0.3 m high × 0.09 m long × 0.19 m wide; prefab scale 0.3.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 0.03, death style `dissolve_into_motes`.
- **Navigation:** speed 2.81 m/s, turn 900°/s, stopping distance 0.5 m.
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

Will-o'-Wisp is a **dread elemental** encountered at E rank, around level 26. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a pale flame that leads travelers into bogs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Whisperwood|Whisperwood]], [[Regions/Aldmere|Aldmere]], [[Regions/Mossdeep|Mossdeep]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits E|loot_elemental_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Vesper-Touched Will-o'-Wisp|Vesper-Touched Will-o'-Wisp]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sylvaran\|Sylvaran]] | 3 | F+, E+, E- | 13–32 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, E, E+, D, D- | 13–48 | Night |
| [[Regions/Aldmere\|Aldmere]] | 1 | E+ | 32–32 | Night |
| [[Regions/Mossdeep\|Mossdeep]] | 2 | D-, F+ | 13–40 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01584` | Sylvaran Will-o'-Wisp Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | F+ | 13 | 0.21 m | Night | Like a typical Will-o'-Wisp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01585` | Sylvaran Will-o'-Wisp Albino | [[Regions/Sylvaran\|Sylvaran]] | Albino | E+ | 32 | 0.3 m | Night | Like a typical Will-o'-Wisp, but a rare pale form with white skin or fur and red eyes. |
| `pop_01586` | Whisperwood Will-o'-Wisp Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.21 m | Night | Like a typical Will-o'-Wisp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01587` | Whisperwood Will-o'-Wisp | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 0.3 m | Night | A typical adult Will-o'-Wisp of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01588` | Whisperwood Will-o'-Wisp Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 0.33 m | Night | Like a typical Will-o'-Wisp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01589` | Sylvaran Will-o'-Wisp Juvenile | [[Regions/Sylvaran\|Sylvaran]] | Juvenile | E- | 19 | 0.26 m | Night | Like a typical Will-o'-Wisp, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01590` | Aldmere Will-o'-Wisp Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.33 m | Night | Like a typical Will-o'-Wisp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01591` | Whisperwood Will-o'-Wisp Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.41 m | Night | Like a typical Will-o'-Wisp, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01592` | Mossdeep Will-o'-Wisp Alpha | [[Regions/Mossdeep\|Mossdeep]] | Alpha | D- | 40 | 0.38 m | Night | Like a typical Will-o'-Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01593` | Whisperwood Will-o'-Wisp Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 0.38 m | Night | Like a typical Will-o'-Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01594` | Mossdeep Will-o'-Wisp Runt | [[Regions/Mossdeep\|Mossdeep]] | Runt | F+ | 13 | 0.21 m | Night | Like a typical Will-o'-Wisp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#292940` · elongated, irregular silhouette; still-then-sudden timing
