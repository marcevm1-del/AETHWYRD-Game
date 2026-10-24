---
type: monster
id: mon_ash_vampire_lord
family: "Undead"
rank: "S+"
tier: variant
tags: [monster, undead]
---
# Ash Vampire Lord

![[mon_ash_vampire_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ash_vampire_lord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,596 tris · 1.296 × 2.133 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ash Vampire Lord is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its flesh and bone are rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is a cape that dissolves into bats. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Vampire Lord\|Vampire Lord]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37457 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 105, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 6.3 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** a cape that dissolves into bats.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ash Vampire Lord is a **menacing undead** encountered at S+ rank, around level 203. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cape that dissolves into bats. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead S|loot_undead_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 5 | SS-, S+, S, SS | 188–236 | Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | S-, SS, SS+, S+, SS-, S | 173–253 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03848` | Vesper Ash Vampire Lord Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SS- | 218 | 2.42 m | Night | Like a typical Ash Vampire Lord, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_03849` | Nox Dominion Ash Vampire Lord Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S- | 173 | 1.54 m | Night | Like a typical Ash Vampire Lord, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_03850` | Vesper Ash Vampire Lord Albino | [[Regions/Vesper\|Vesper]] | Albino | SS- | 218 | 2.2 m | Night | Like a typical Ash Vampire Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_03851` | Vesper Ash Vampire Lord | [[Regions/Vesper\|Vesper]] | Adult | S+ | 203 | 2.2 m | Night | A typical adult Ash Vampire Lord of this region, with red-black coloring with faint ember veins. |
| `pop_03852` | Vesper Ash Vampire Lord Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | S | 188 | 1.87 m | Night | Like a typical Ash Vampire Lord, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_03853` | Nox Dominion Ash Vampire Lord Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS | 236 | 2.75 m | Night | Like a typical Ash Vampire Lord, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_03854` | Nox Dominion Ash Vampire Lord Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS+ | 253 | 2.97 m | Night | Like a typical Ash Vampire Lord, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_03855` | Vesper Ash Vampire Lord Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SS | 236 | 2.75 m | Night | Like a typical Ash Vampire Lord, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_03856` | Nox Dominion Ash Vampire Lord | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S+ | 203 | 2.2 m | Night | A typical adult Ash Vampire Lord of this region, with red-black coloring with faint ember veins. |
| `pop_03857` | Nox Dominion Ash Vampire Lord Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS- | 218 | 2.2 m | Night | Like a typical Ash Vampire Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_03858` | Nox Dominion Ash Vampire Lord Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S | 188 | 1.87 m | Night | Like a typical Ash Vampire Lord, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
