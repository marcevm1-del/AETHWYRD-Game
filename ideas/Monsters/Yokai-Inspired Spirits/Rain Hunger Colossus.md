---
type: monster
id: mon_rain_hunger_colossus
family: "Yokai-Inspired Spirits"
rank: "A+"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Rain Hunger Colossus

![[mon_rain_hunger_colossus_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_rain_hunger_colossus_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Rain Hunger Colossus is a colossal creature with a massive hunched brute frame, about 30 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Survivors describe a skeleton giant built from the bones of the starved. It has eyes that never blink. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Hunger Colossus\|Hunger Colossus]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 30 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 70446 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 30 m high × 9 m long × 12.6 m wide; prefab scale 8.571.
- **Physics:** 510300 kg, gravity ×1.3, poise 717, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 17.54 m/s, turn 69°/s, stopping distance 6.4 m.
- **Attack count:** 5; **signature:** a skeleton giant built from the bones of the starved.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rain Hunger Colossus is a **dread spirit** encountered at A+ rank, around level 159. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skeleton giant built from the bones of the starved. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Hoshizora\|Hoshizora]] | 7 | A-, S-, A+, S, S+, A | 132–203 | Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | A-, S, S+, A | 132–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05389` | Hoshizora Rain Hunger Colossus Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | A- | 132 | 21 m | Night | Like a typical Rain Hunger Colossus, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05390` | Hoshizora Rain Hunger Colossus Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | S- | 173 | 30 m | Night | Like a typical Rain Hunger Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_05391` | Hoshizora Rain Hunger Colossus | [[Regions/Hoshizora\|Hoshizora]] | Adult | A+ | 159 | 30 m | Night | A typical adult Rain Hunger Colossus of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05392` | Kitsune Isles Rain Hunger Colossus Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | A- | 132 | 21 m | Night | Like a typical Rain Hunger Colossus, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_05393` | Kitsune Isles Rain Hunger Colossus Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | S | 188 | 37.5 m | Night | Like a typical Rain Hunger Colossus, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_05394` | Kitsune Isles Rain Hunger Colossus Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | S+ | 203 | 40.5 m | Night | Like a typical Rain Hunger Colossus, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_05395` | Kitsune Isles Rain Hunger Colossus Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | A | 146 | 25.5 m | Night | Like a typical Rain Hunger Colossus, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_05396` | Hoshizora Rain Hunger Colossus Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | S | 188 | 37.5 m | Night | Like a typical Rain Hunger Colossus, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05397` | Hoshizora Rain Hunger Colossus Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | S- | 173 | 33 m | Night | Like a typical Rain Hunger Colossus, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05398` | Hoshizora Rain Hunger Colossus Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S+ | 203 | 40.5 m | Night | Like a typical Rain Hunger Colossus, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05399` | Hoshizora Rain Hunger Colossus Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A | 146 | 25.5 m | Night | Like a typical Rain Hunger Colossus, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
