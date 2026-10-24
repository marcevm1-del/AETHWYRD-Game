---
type: monster
id: mon_brine_eternal_phoenix
family: "Avians"
rank: "SSS+"
tier: variant
tags: [monster, avians]
---
# Brine Eternal Phoenix

![[mon_brine_eternal_phoenix_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_brine_eternal_phoenix_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,722 tris · 32.35 × 25.472 × 30 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Brine Eternal Phoenix is a colossal creature with a broad-winged bird frame, about 30 m tall. Its plumage is smooth and clean, colored in deep blues with a glassy shine. Survivors describe a sun-bright body that rises again from its own ash. It has wide curious eyes with star-shaped highlights. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It hops in little bursts, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Eternal Phoenix\|Eternal Phoenix]] (elemental) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 30 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 107326 · 1186 · 949 · 830 · 949 · 135 |
| XP · gold | 26706 · 4286 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Moraveil\|Moraveil]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 13.8 m high × 30 m long × 51.6 m wide; prefab scale 50.
- **Physics:** 396900 kg, gravity ×1, poise 12927, knockback resistance 0.29, death style `tumble_feathers_burst`.
- **Navigation:** speed 13.37 m/s, turn 110°/s, stopping distance 6.4 m.
- **Attack count:** 5; **signature:** a sun-bright body that rises again from its own ash.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Brine Eternal Phoenix is a **charming avian** encountered at SSS+ rank, around level 294. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a sun-bright body that rises again from its own ash. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians SSS|loot_avian_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 5 | EX, SSS, SSS-, EX+, EX- | 267–300 | Day |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | EX-, SSS, EX+, SSS+, SSS- | 267–300 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05004` | Moraveil Brine Eternal Phoenix Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | EX | 300 | 37.5 m | Day | Like a typical Brine Eternal Phoenix, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05005` | Moraveil Brine Eternal Phoenix Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | SSS | 281 | 25.5 m | Day | Like a typical Brine Eternal Phoenix, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05006` | Moraveil Brine Eternal Phoenix Runt | [[Regions/Moraveil\|Moraveil]] | Runt | SSS- | 267 | 21 m | Day | Like a typical Brine Eternal Phoenix, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05007` | Sky Archipelago Brine Eternal Phoenix Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | EX- | 300 | 33 m | Day | Like a typical Brine Eternal Phoenix, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_05008` | Moraveil Brine Eternal Phoenix Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | EX+ | 300 | 40.5 m | Day | Like a typical Brine Eternal Phoenix, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05009` | Sky Archipelago Brine Eternal Phoenix Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | SSS | 281 | 25.5 m | Day | Like a typical Brine Eternal Phoenix, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_05010` | Sky Archipelago Brine Eternal Phoenix Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | EX+ | 300 | 40.5 m | Day | Like a typical Brine Eternal Phoenix, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_05011` | Sky Archipelago Brine Eternal Phoenix Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | EX- | 300 | 30 m | Day | Like a typical Brine Eternal Phoenix, but a rare pale form with white skin or fur and red eyes. |
| `pop_05012` | Sky Archipelago Brine Eternal Phoenix | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SSS+ | 294 | 30 m | Day | A typical adult Brine Eternal Phoenix of this region, with cloud-pale coloring and lighter bones. |
| `pop_05013` | Sky Archipelago Brine Eternal Phoenix Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | SSS- | 267 | 21 m | Day | Like a typical Brine Eternal Phoenix, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_05014` | Moraveil Brine Eternal Phoenix Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | EX- | 300 | 33 m | Day | Like a typical Brine Eternal Phoenix, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
