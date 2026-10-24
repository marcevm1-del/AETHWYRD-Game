---
type: monster
id: mon_bramble_beast
family: "Lycanthropes"
rank: "B-"
tier: variant
tags: [monster, lycanthropes]
---
# Bramble Beast

> The Bramble Beast is a large creature with a lean humanoid frame, about 2.8 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Survivors describe fur that ripples like oil under moonlight. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Moon Beast\|Moon Beast]] (elemental) |
| Rank · level | B- · 96 (86–108) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 2.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13286 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.8 m high × 0.84 m long × 0.9 m wide; prefab scale 1.556.
- **Physics:** 285.4 kg, gravity ×1.5, poise 100, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.45 m/s, turn 239°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** fur that ripples like oil under moonlight.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bramble Beast is a **dread cursed beast** encountered at B- rank, around level 96. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fur that ripples like oil under moonlight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes B|loot_lycan_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | B, C, A-, B-, B+ | 76–132 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | C+, B, B+, A-, B- | 86–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06308` | Shen-Lu Bramble Beast Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B | 108 | 3.08 m | Night | Like a typical Bramble Beast, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06309` | Hoshizora Bramble Beast Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | C+ | 86 | 2.38 m | Night | Like a typical Bramble Beast, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06310` | Hoshizora Bramble Beast Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B | 108 | 3.08 m | Night | Like a typical Bramble Beast, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06311` | Hoshizora Bramble Beast Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B+ | 120 | 3.5 m | Night | Like a typical Bramble Beast, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06312` | Shen-Lu Bramble Beast Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | C | 76 | 1.96 m | Night | Like a typical Bramble Beast, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06313` | Hoshizora Bramble Beast Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A- | 132 | 3.78 m | Night | Like a typical Bramble Beast, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06314` | Shen-Lu Bramble Beast Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | A- | 132 | 3.78 m | Night | Like a typical Bramble Beast, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06315` | Shen-Lu Bramble Beast | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B- | 96 | 2.8 m | Night | A typical adult Bramble Beast of this region, with slate-grey coloring and hardened hide. |
| `pop_06316` | Hoshizora Bramble Beast | [[Regions/Hoshizora\|Hoshizora]] | Adult | B- | 96 | 2.8 m | Night | A typical adult Bramble Beast of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06317` | Shen-Lu Bramble Beast Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B+ | 120 | 3.5 m | Night | Like a typical Bramble Beast, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06318` | Hoshizora Bramble Beast Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B | 108 | 2.8 m | Night | Like a typical Bramble Beast, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
