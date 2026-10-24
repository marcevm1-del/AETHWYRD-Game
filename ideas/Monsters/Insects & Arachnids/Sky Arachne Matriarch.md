---
type: monster
id: mon_sky_arachne_matriarch
family: "Insects & Arachnids"
rank: "S+"
tier: variant
tags: [monster, insects-arachnids]
---
# Sky Arachne Matriarch

> The Sky Arachne Matriarch is a huge creature with a squat, many-legged arachnid build, about 8 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in pale jade and cloud white. Guild sketches always show a crown of silk and eight eyes like jewels. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It moves in jerky stop-motion bursts, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Arachne Matriarch\|Arachne Matriarch]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 43832 · 822 · 658 · 575 · 658 · 135 |
| XP · gold | 14769 · 2553 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Quaking Lands\|Quaking Lands]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 2.24 m high × 8 m long × 5.47 m wide; prefab scale 8.
- **Physics:** 15206.4 kg, gravity ×1.12, poise 1424, knockback resistance 0.38, death style `flip_legs_curl`.
- **Navigation:** speed 16.3 m/s, turn 212°/s, stopping distance 2.4 m.
- **Attack count:** 5; **signature:** a crown of silk and eight eyes like jewels.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sky Arachne Matriarch is a **dread insectoid** encountered at S+ rank, around level 203. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of silk and eight eyes like jewels. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Quaking Lands|Quaking Lands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids S|loot_insect_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 6 | S+, S, S-, SS-, SS+, SS | 173–253 | Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | SS, S+, S-, SS- | 173–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06462` | Quaking Lands Sky Arachne Matriarch | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | S+ | 203 | 8 m | Night | A typical adult Sky Arachne Matriarch of this region, with golden, grass-toned coloring. |
| `pop_06463` | Quaking Lands Sky Arachne Matriarch Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | S | 188 | 6.8 m | Night | Like a typical Sky Arachne Matriarch, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06464` | Moraveil Sky Arachne Matriarch Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SS | 236 | 10 m | Night | Like a typical Sky Arachne Matriarch, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06465` | Moraveil Sky Arachne Matriarch | [[Regions/Moraveil\|Moraveil]] | Adult | S+ | 203 | 8 m | Night | A typical adult Sky Arachne Matriarch of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06466` | Quaking Lands Sky Arachne Matriarch Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | S- | 173 | 5.6 m | Night | Like a typical Sky Arachne Matriarch, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06467` | Quaking Lands Sky Arachne Matriarch Albino | [[Regions/Quaking Lands\|Quaking Lands]] | Albino | SS- | 218 | 8 m | Night | Like a typical Sky Arachne Matriarch, but a rare pale form with white skin or fur and red eyes. |
| `pop_06468` | Moraveil Sky Arachne Matriarch Runt | [[Regions/Moraveil\|Moraveil]] | Runt | S- | 173 | 5.6 m | Night | Like a typical Sky Arachne Matriarch, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06469` | Quaking Lands Sky Arachne Matriarch Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | SS+ | 253 | 10.8 m | Night | Like a typical Sky Arachne Matriarch, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06470` | Moraveil Sky Arachne Matriarch Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | SS- | 218 | 8.8 m | Night | Like a typical Sky Arachne Matriarch, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06471` | Moraveil Sky Arachne Matriarch Albino | [[Regions/Moraveil\|Moraveil]] | Albino | SS- | 218 | 8 m | Night | Like a typical Sky Arachne Matriarch, but a rare pale form with white skin or fur and red eyes. |
| `pop_06472` | Quaking Lands Sky Arachne Matriarch Alpha | [[Regions/Quaking Lands\|Quaking Lands]] | Alpha | SS | 236 | 10 m | Night | Like a typical Sky Arachne Matriarch, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · elongated, irregular silhouette; still-then-sudden timing
