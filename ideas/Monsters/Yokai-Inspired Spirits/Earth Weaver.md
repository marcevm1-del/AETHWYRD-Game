---
type: monster
id: mon_earth_weaver
family: "Yokai-Inspired Spirits"
rank: "B"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Earth Weaver

> The Earth Weaver is a huge creature with a bulbous spider frame on long jointed legs, about 6 m long. Its form is patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Guild sketches always show a tiger-striped spider the size of a house. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 6 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15662 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Haneul\|Haneul]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Everdusk\|Everdusk]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 1.68 m high × 6 m long × 4.1 m wide; prefab scale 6.
- **Physics:** 9266.4 kg, gravity ×1.54, poise 874, knockback resistance 0.47, death style `flip_legs_curl`.
- **Navigation:** speed 10.93 m/s, turn 245°/s, stopping distance 1.9 m.
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

Earth Weaver is a **dread spirit** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a tiger-striped spider the size of a house. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Haneul|Haneul]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Everdusk|Everdusk]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits B|loot_yokai_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Ancient Earth Weaver|Ancient Earth Weaver]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 2 | C+, A | 86–146 | Night |
| [[Regions/Haneul\|Haneul]] | 3 | B+, A-, C+ | 86–132 | Night |
| [[Regions/Everdusk\|Everdusk]] | 4 | B+, B, A, A- | 108–146 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | B+ | 120–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02516` | Hoshizora Earth Weaver Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | C+ | 86 | 4.2 m | Night | Like a typical Earth Weaver, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02517` | Haneul Earth Weaver Scarred | [[Regions/Haneul\|Haneul]] | Scarred | B+ | 120 | 6.6 m | Night | Like a typical Earth Weaver, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02518` | Everdusk Earth Weaver Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | B+ | 120 | 6.6 m | Night | Like a typical Earth Weaver, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02519` | Haneul Earth Weaver Alpha | [[Regions/Haneul\|Haneul]] | Alpha | A- | 132 | 7.5 m | Night | Like a typical Earth Weaver, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02520` | Hoshizora Earth Weaver Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A | 146 | 8.1 m | Night | Like a typical Earth Weaver, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02521` | Haneul Earth Weaver Runt | [[Regions/Haneul\|Haneul]] | Runt | C+ | 86 | 4.2 m | Night | Like a typical Earth Weaver, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02522` | Shen-Lu Earth Weaver Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B+ | 120 | 6 m | Night | Like a typical Earth Weaver, but a rare pale form with white skin or fur and red eyes. |
| `pop_02523` | Everdusk Earth Weaver | [[Regions/Everdusk\|Everdusk]] | Adult | B | 108 | 6 m | Night | A typical adult Earth Weaver of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02524` | Everdusk Earth Weaver Elderborn | [[Regions/Everdusk\|Everdusk]] | Elderborn | A | 146 | 8.1 m | Night | Like a typical Earth Weaver, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02525` | Everdusk Earth Weaver Alpha | [[Regions/Everdusk\|Everdusk]] | Alpha | A- | 132 | 7.5 m | Night | Like a typical Earth Weaver, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02526` | Shen-Lu Earth Weaver Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B+ | 120 | 6.6 m | Night | Like a typical Earth Weaver, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `paper_ink_spirit` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
