---
type: monster
id: mon_greater_gnome
family: "Elementals & Spirits"
rank: "C+"
tier: variant
tags: [monster, elementals-spirits]
---
# Greater Gnome

![[mon_greater_gnome_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_gnome_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,094 tris · 0.543 × 0.532 × 1.1 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Gnome is a small creature with a small, compact humanoid body, about 1.1 m tall. Its body is weathered and natural, colored in ochre, clay and mossy stone. Look for a stone-bearded little figure with gem eyes. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It prowls, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Gnome\|Gnome]] (elder) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 1.1 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6347 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.1 m high × 0.33 m long × 0.44 m wide; prefab scale 1.
- **Physics:** 27.7 kg, gravity ×1.65, poise 44, knockback resistance 0.39, death style `ragdoll_crumple`.
- **Navigation:** speed 4.44 m/s, turn 400°/s, stopping distance 0.62 m.
- **Attack count:** 5; **signature:** a stone-bearded little figure with gem eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Gnome is a **wild elemental** encountered at C+ rank, around level 86. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone-bearded little figure with gem eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits C|loot_elemental_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 4 | B-, C-, C+ | 65–96 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | B-, B+, C-, C, B | 65–120 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | C, B- | 76–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04517` | Hoshizora Greater Gnome Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B- | 96 | 1.21 m | Day & Night | Like a typical Greater Gnome, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04518` | Iron Hold Greater Gnome Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B- | 96 | 1.21 m | Day & Night | Like a typical Greater Gnome, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04519` | Hoshizora Greater Gnome Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | C- | 65 | 0.77 m | Day & Night | Like a typical Greater Gnome, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04520` | Iron Hold Greater Gnome Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | B+ | 120 | 1.49 m | Day & Night | Like a typical Greater Gnome, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04521` | Shen-Lu Greater Gnome Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | C | 76 | 0.94 m | Day & Night | Like a typical Greater Gnome, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04522` | Hoshizora Greater Gnome | [[Regions/Hoshizora\|Hoshizora]] | Adult | C+ | 86 | 1.1 m | Day & Night | A typical adult Greater Gnome of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04523` | Shen-Lu Greater Gnome Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B- | 96 | 1.1 m | Day & Night | Like a typical Greater Gnome, but a rare pale form with white skin or fur and red eyes. |
| `pop_04524` | Iron Hold Greater Gnome Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C- | 65 | 0.77 m | Day & Night | Like a typical Greater Gnome, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04525` | Hoshizora Greater Gnome Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B- | 96 | 1.1 m | Day & Night | Like a typical Greater Gnome, but a rare pale form with white skin or fur and red eyes. |
| `pop_04526` | Iron Hold Greater Gnome Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | C | 76 | 0.94 m | Day & Night | Like a typical Greater Gnome, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04527` | Iron Hold Greater Gnome Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B | 108 | 1.38 m | Day & Night | Like a typical Greater Gnome, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `elemental_emissive` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
