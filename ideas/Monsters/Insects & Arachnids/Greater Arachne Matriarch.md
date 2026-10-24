---
type: monster
id: mon_greater_arachne_matriarch
family: "Insects & Arachnids"
rank: "SS"
tier: variant
tags: [monster, insects-arachnids]
---
# Greater Arachne Matriarch

![[mon_greater_arachne_matriarch_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_arachne_matriarch_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,274 tris · 10.386 × 12.8 × 7.024 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Arachne Matriarch is a huge creature with a bulbous spider frame on long jointed legs, about 12.8 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a crown of silk and eight eyes like jewels. It has eyes that never blink. The air distorts slightly around its outline. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Arachne Matriarch\|Arachne Matriarch]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 12.8 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 62629 · 954 · 763 · 668 · 763 · 135 |
| XP · gold | 18792 · 3152 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/The Maw\|The Maw]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 3.58 m high × 12.8 m long × 8.76 m wide; prefab scale 12.8.
- **Physics:** 69206 kg, gravity ×1.4, poise 3308, knockback resistance 0.41, death style `flip_legs_curl`.
- **Navigation:** speed 18.23 m/s, turn 168°/s, stopping distance 3.6 m.
- **Attack count:** 5; **signature:** a crown of silk and eight eyes like jewels.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Arachne Matriarch is a **dread insectoid** encountered at SS rank, around level 236. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of silk and eight eyes like jewels. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids SS|loot_insect_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 6 | SS+, S+, SS-, SS, SSS | 203–281 | Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | SSS, S+, SSS-, SS+, SS | 203–281 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03617` | The Maw Greater Arachne Matriarch Scarred | [[Regions/The Maw\|The Maw]] | Scarred | SS+ | 253 | 14.08 m | Night | Like a typical Greater Arachne Matriarch, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03618` | The Maw Greater Arachne Matriarch Runt | [[Regions/The Maw\|The Maw]] | Runt | S+ | 203 | 8.96 m | Night | Like a typical Greater Arachne Matriarch, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03619` | The Maw Greater Arachne Matriarch Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | SS- | 218 | 10.88 m | Night | Like a typical Greater Arachne Matriarch, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03620` | Great Labyrinth (Floors 91-120) Greater Arachne Matriarch Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | SSS | 281 | 17.28 m | Night | Like a typical Greater Arachne Matriarch, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03621` | The Maw Greater Arachne Matriarch | [[Regions/The Maw\|The Maw]] | Adult | SS | 236 | 12.8 m | Night | A typical adult Greater Arachne Matriarch of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03622` | Great Labyrinth (Floors 91-120) Greater Arachne Matriarch Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | S+ | 203 | 8.96 m | Night | Like a typical Greater Arachne Matriarch, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03623` | The Maw Greater Arachne Matriarch Albino | [[Regions/The Maw\|The Maw]] | Albino | SS+ | 253 | 12.8 m | Night | Like a typical Greater Arachne Matriarch, but a rare pale form with white skin or fur and red eyes. |
| `pop_03624` | The Maw Greater Arachne Matriarch Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | SSS | 281 | 17.28 m | Night | Like a typical Greater Arachne Matriarch, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03625` | Great Labyrinth (Floors 91-120) Greater Arachne Matriarch Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SSS- | 267 | 16 m | Night | Like a typical Greater Arachne Matriarch, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03626` | Great Labyrinth (Floors 91-120) Greater Arachne Matriarch Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SS+ | 253 | 14.08 m | Night | Like a typical Greater Arachne Matriarch, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03627` | Great Labyrinth (Floors 91-120) Greater Arachne Matriarch | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | SS | 236 | 12.8 m | Night | A typical adult Greater Arachne Matriarch of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
