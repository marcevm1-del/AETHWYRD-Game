---
type: monster
id: mon_rot_vampire_lord
family: "Undead"
rank: "S+"
tier: variant
tags: [monster, undead]
---
# Rot Vampire Lord

![[mon_rot_vampire_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_rot_vampire_lord_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.756 × 0.853 × 2.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_rot_vampire_lord.fbx`

> The Rot Vampire Lord is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its flesh and bone are rough, scarred and spiked, colored in bleached bone and grave-cloth, with sickly green markings. Look for a cape that dissolves into bats. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Vampire Lord\|Vampire Lord]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37457 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 105, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 5.82 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** a cape that dissolves into bats.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rot Vampire Lord is a **menacing undead** encountered at S+ rank, around level 203. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cape that dissolves into bats. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 6 | SS-, SS+, SS, S+, S- | 173–253 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | SS-, S-, SS, S | 173–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06693` | Great Labyrinth (Floors 91-120) Rot Vampire Lord Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SS- | 218 | 2.42 m | Night | Like a typical Rot Vampire Lord, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_06694` | Great Labyrinth (Floors 41-90) Rot Vampire Lord Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | SS- | 218 | 2.42 m | Night | Like a typical Rot Vampire Lord, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_06695` | Great Labyrinth (Floors 41-90) Rot Vampire Lord Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | S- | 173 | 1.54 m | Night | Like a typical Rot Vampire Lord, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06696` | Great Labyrinth (Floors 91-120) Rot Vampire Lord Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | SS- | 218 | 2.2 m | Night | Like a typical Rot Vampire Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_06697` | Great Labyrinth (Floors 41-90) Rot Vampire Lord Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | SS- | 218 | 2.2 m | Night | Like a typical Rot Vampire Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_06698` | Great Labyrinth (Floors 91-120) Rot Vampire Lord Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | SS+ | 253 | 2.97 m | Night | Like a typical Rot Vampire Lord, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06699` | Great Labyrinth (Floors 41-90) Rot Vampire Lord Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS | 236 | 2.75 m | Night | Like a typical Rot Vampire Lord, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_06700` | Great Labyrinth (Floors 91-120) Rot Vampire Lord Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS | 236 | 2.75 m | Night | Like a typical Rot Vampire Lord, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_06701` | Great Labyrinth (Floors 91-120) Rot Vampire Lord | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S+ | 203 | 2.2 m | Night | A typical adult Rot Vampire Lord of this region, with dust-grey coloring and old rune scars. |
| `pop_06702` | Great Labyrinth (Floors 41-90) Rot Vampire Lord Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S | 188 | 1.87 m | Night | Like a typical Rot Vampire Lord, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_06703` | Great Labyrinth (Floors 91-120) Rot Vampire Lord Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | S- | 173 | 1.54 m | Night | Like a typical Rot Vampire Lord, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `toxic_fog` · palette `#e3d2b9` `#91826d` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
