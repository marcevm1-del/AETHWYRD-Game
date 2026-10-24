---
type: monster
id: mon_moss_hobgoblin
family: "Goblinoids"
rank: "D-"
tier: variant
tags: [monster, goblinoids]
---
# Moss Hobgoblin

![[mon_moss_hobgoblin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_moss_hobgoblin_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,840 tris · 1.061 × 1.745 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Moss Hobgoblin is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its skin is rough, scarred and spiked, colored in leaf greens over bark brown. Survivors describe a broad scarred chest and a helmet two sizes too small. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Hobgoblin\|Hobgoblin]] (elemental) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3132 · 204 · 170 · 136 · 153 · 100 |
| XP · gold | 1106 · 265 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override (base species)); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 65, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** a broad scarred chest and a helmet two sizes too small.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Moss Hobgoblin is a **menacing humanoid** encountered at D- rank, around level 40. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a broad scarred chest and a helmet two sizes too small. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids D|loot_goblinoid_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | D+, E, C-, D, E+ | 26–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | D-, D, C-, E | 26–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03104` | Aldmere Moss Hobgoblin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 2.25 m | Day & Night | Like a typical Moss Hobgoblin, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03105` | Moraveil Moss Hobgoblin | [[Regions/Moraveil\|Moraveil]] | Adult | D- | 40 | 1.8 m | Day & Night | A typical adult Moss Hobgoblin of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03106` | Aldmere Moss Hobgoblin Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E | 26 | 1.26 m | Day & Night | Like a typical Moss Hobgoblin, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03107` | Aldmere Moss Hobgoblin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 2.43 m | Day & Night | Like a typical Moss Hobgoblin, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03108` | Aldmere Moss Hobgoblin Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D | 48 | 1.8 m | Day & Night | Like a typical Moss Hobgoblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_03109` | Aldmere Moss Hobgoblin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D | 48 | 1.98 m | Day & Night | Like a typical Moss Hobgoblin, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03110` | Aldmere Moss Hobgoblin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E+ | 32 | 1.53 m | Day & Night | Like a typical Moss Hobgoblin, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03111` | Moraveil Moss Hobgoblin Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D | 48 | 1.8 m | Day & Night | Like a typical Moss Hobgoblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_03112` | Moraveil Moss Hobgoblin Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D | 48 | 1.98 m | Day & Night | Like a typical Moss Hobgoblin, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03113` | Moraveil Moss Hobgoblin Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C- | 65 | 2.43 m | Day & Night | Like a typical Moss Hobgoblin, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03114` | Moraveil Moss Hobgoblin Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E | 26 | 1.26 m | Day & Night | Like a typical Moss Hobgoblin, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
