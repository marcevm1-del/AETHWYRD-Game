---
type: monster
id: mon_spirit_king
family: "Elementals & Spirits"
rank: "S"
tier: core
tags: [monster, elementals-spirits]
---
# Spirit King

![[mon_spirit_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_spirit_king_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Spirit King is a huge creature with a lean humanoid frame, about 6 m tall. Its body is weathered and natural, colored in warm gold and pearl white. Guild sketches always show a crowned elemental giant of pure mana. It has alert animal eyes. Its regal silhouette is crowned by a halo-like ring of aura. It prowls, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | S · 188 (173–203) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 46394 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Heavenreach\|Heavenreach]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 6 m high × 1.8 m long × 1.92 m wide; prefab scale 3.333.
- **Physics:** 2667.6 kg, gravity ×1.35, poise 173, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 8.15 m/s, turn 163°/s, stopping distance 1.42 m.
- **Attack count:** 5; **signature:** a crowned elemental giant of pure mana.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Spirit King is a **wild elemental** encountered at S rank, around level 188. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crowned elemental giant of pure mana. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits S|loot_elemental_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Vesper-Touched Spirit King|Vesper-Touched Spirit King]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 7 | SS-, SS, S-, S, S+, A+ | 159–236 | Day & Night |
| [[Regions/Heavenreach\|Heavenreach]] | 4 | A+, S, S+ | 159–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01672` | Shen-Lu Spirit King Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SS- | 218 | 7.5 m | Day & Night | Like a typical Spirit King, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01673` | Heavenreach Spirit King Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | A+ | 159 | 4.2 m | Day & Night | Like a typical Spirit King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01674` | Shen-Lu Spirit King Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SS | 236 | 8.1 m | Day & Night | Like a typical Spirit King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01675` | Heavenreach Spirit King | [[Regions/Heavenreach\|Heavenreach]] | Adult | S | 188 | 6 m | Day & Night | A typical adult Spirit King of this region, with slate-grey coloring and hardened hide. |
| `pop_01676` | Shen-Lu Spirit King Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | S- | 173 | 5.1 m | Day & Night | Like a typical Spirit King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01677` | Shen-Lu Spirit King | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | S | 188 | 6 m | Day & Night | A typical adult Spirit King of this region, with slate-grey coloring and hardened hide. |
| `pop_01678` | Shen-Lu Spirit King Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S+ | 203 | 6 m | Day & Night | Like a typical Spirit King, but a rare pale form with white skin or fur and red eyes. |
| `pop_01679` | Shen-Lu Spirit King Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S+ | 203 | 6.6 m | Day & Night | Like a typical Spirit King, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01680` | Shen-Lu Spirit King Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A+ | 159 | 4.2 m | Day & Night | Like a typical Spirit King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01681` | Heavenreach Spirit King Albino | [[Regions/Heavenreach\|Heavenreach]] | Albino | S+ | 203 | 6 m | Day & Night | Like a typical Spirit King, but a rare pale form with white skin or fur and red eyes. |
| `pop_01682` | Heavenreach Spirit King Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | S+ | 203 | 6.6 m | Day & Night | Like a typical Spirit King, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `elemental_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
