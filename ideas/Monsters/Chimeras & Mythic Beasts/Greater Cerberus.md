---
type: monster
id: mon_greater_cerberus
family: "Chimeras & Mythic Beasts"
rank: "S+"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Greater Cerberus

![[mon_greater_cerberus_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_cerberus_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,862 tris · 3.085 × 8 × 6.959 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Cerberus is a huge creature with a powerful four-legged hunter's body, about 8 m long. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe three heads with three different moods. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Cerberus\|Cerberus]] (elder) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 8 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 56724 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Dragon Spine\|Dragon Spine]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 5.2 m high × 8 m long × 1.28 m wide; prefab scale 2.
- **Physics:** 10240 kg, gravity ×1.2, poise 188, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 10.32 m/s, turn 113°/s, stopping distance 2 m.
- **Attack count:** 5; **signature:** three heads with three different moods.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Cerberus is a **menacing mythic beast** encountered at S+ rank, around level 203. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** three heads with three different moods. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Dragon Spine|Dragon Spine]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts S|loot_chimera_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dragon Spine\|Dragon Spine]] | 6 | S, SS-, S+, SS, S- | 173–236 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | SS-, SS+, S+, S | 188–253 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05059` | Dragon Spine Greater Cerberus Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | S | 188 | 6.8 m | Day & Night | Like a typical Greater Cerberus, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05060` | Dragon Spine Greater Cerberus Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | SS- | 218 | 8 m | Day & Night | Like a typical Greater Cerberus, but a rare pale form with white skin or fur and red eyes. |
| `pop_05061` | Nox Dominion Greater Cerberus Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS- | 218 | 8.8 m | Day & Night | Like a typical Greater Cerberus, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_05062` | Nox Dominion Greater Cerberus Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS- | 218 | 8 m | Day & Night | Like a typical Greater Cerberus, but a rare pale form with white skin or fur and red eyes. |
| `pop_05063` | Dragon Spine Greater Cerberus | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | S+ | 203 | 8 m | Day & Night | A typical adult Greater Cerberus of this region, with slate-grey coloring and hardened hide. |
| `pop_05064` | Nox Dominion Greater Cerberus Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS+ | 253 | 10.8 m | Day & Night | Like a typical Greater Cerberus, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_05065` | Nox Dominion Greater Cerberus | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S+ | 203 | 8 m | Day & Night | A typical adult Greater Cerberus of this region, with red-black coloring with faint ember veins. |
| `pop_05066` | Dragon Spine Greater Cerberus Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | SS | 236 | 10 m | Day & Night | Like a typical Greater Cerberus, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05067` | Dragon Spine Greater Cerberus Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | SS- | 218 | 8.8 m | Day & Night | Like a typical Greater Cerberus, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05068` | Dragon Spine Greater Cerberus Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | S- | 173 | 5.6 m | Day & Night | Like a typical Greater Cerberus, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05069` | Nox Dominion Greater Cerberus Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S | 188 | 6.8 m | Day & Night | Like a typical Greater Cerberus, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
