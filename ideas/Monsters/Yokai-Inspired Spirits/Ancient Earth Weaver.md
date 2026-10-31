---
type: monster
id: mon_ancient_earth_weaver
family: "Yokai-Inspired Spirits"
rank: "A"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Ancient Earth Weaver

![[mon_ancient_earth_weaver_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_earth_weaver_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,408 tris · 7.831 × 9 × 5.296 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Earth Weaver is a huge creature with a squat, many-legged arachnid build, about 9 m long. Its form is patchy and subtly wrong, as if assembled from memory, colored in lacquer red, with ochre markings. Look for a tiger-striped spider the size of a house. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by pebbles that tremble and float near it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Earth Weaver\|Earth Weaver]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 9 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 27701 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Haneul\|Haneul]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Wind. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 2.52 m high × 9 m long × 6.16 m wide; prefab scale 9.
- **Physics:** 31274.1 kg, gravity ×1.54, poise 1796, knockback resistance 0.5, death style `flip_legs_curl`.
- **Navigation:** speed 12.72 m/s, turn 200°/s, stopping distance 2.65 m.
- **Attack count:** 5; **signature:** a tiger-striped spider the size of a house.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Earth Weaver is a **dread spirit** encountered at A rank, around level 146. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a tiger-striped spider the size of a house. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Haneul|Haneul]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits A|loot_yokai_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | A+, A, B+, A-, S- | 120–173 | Night |
| [[Regions/Haneul\|Haneul]] | 5 | S, A+, S-, A, A- | 132–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05367` | Shen-Lu Ancient Earth Weaver Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A+ | 159 | 9 m | Night | Like a typical Ancient Earth Weaver, but a rare pale form with white skin or fur and red eyes. |
| `pop_05368` | Shen-Lu Ancient Earth Weaver | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | A | 146 | 9 m | Night | A typical adult Ancient Earth Weaver of this region, with slate-grey coloring and hardened hide. |
| `pop_05369` | Shen-Lu Ancient Earth Weaver Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | B+ | 120 | 6.3 m | Night | Like a typical Ancient Earth Weaver, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05370` | Haneul Ancient Earth Weaver Elderborn | [[Regions/Haneul\|Haneul]] | Elderborn | S | 188 | 12.15 m | Night | Like a typical Ancient Earth Weaver, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05371` | Haneul Ancient Earth Weaver Albino | [[Regions/Haneul\|Haneul]] | Albino | A+ | 159 | 9 m | Night | Like a typical Ancient Earth Weaver, but a rare pale form with white skin or fur and red eyes. |
| `pop_05372` | Shen-Lu Ancient Earth Weaver Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | A+ | 159 | 9.9 m | Night | Like a typical Ancient Earth Weaver, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05373` | Shen-Lu Ancient Earth Weaver Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A- | 132 | 7.65 m | Night | Like a typical Ancient Earth Weaver, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05374` | Shen-Lu Ancient Earth Weaver Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | S- | 173 | 11.25 m | Night | Like a typical Ancient Earth Weaver, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05375` | Haneul Ancient Earth Weaver Alpha | [[Regions/Haneul\|Haneul]] | Alpha | S- | 173 | 11.25 m | Night | Like a typical Ancient Earth Weaver, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05376` | Haneul Ancient Earth Weaver | [[Regions/Haneul\|Haneul]] | Adult | A | 146 | 9 m | Night | A typical adult Ancient Earth Weaver of this region, with slate-grey coloring and hardened hide. |
| `pop_05377` | Haneul Ancient Earth Weaver Juvenile | [[Regions/Haneul\|Haneul]] | Juvenile | A- | 132 | 7.65 m | Night | Like a typical Ancient Earth Weaver, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `paper_ink_spirit` · VFX `rock_debris` · palette `#ac393b` `#6b272a` `#d1a15a` · elongated, irregular silhouette; still-then-sudden timing
