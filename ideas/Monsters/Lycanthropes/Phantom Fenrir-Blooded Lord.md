---
type: monster
id: mon_phantom_fenrir_blooded_lord
family: "Lycanthropes"
rank: "A+"
tier: variant
tags: [monster, lycanthropes]
---
# Phantom Fenrir-Blooded Lord

![[mon_phantom_fenrir_blooded_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_fenrir_blooded_lord_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 2.243 × 3.045 × 3.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Lycanthropes/mon_phantom_fenrir_blooded_lord.fbx`

> The Phantom Fenrir-Blooded Lord is a large creature with a broad-shouldered humanoid build, about 3.6 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in black-brown, with gold markings. Its most striking feature is a crown of frost spikes growing from its mane. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Fenrir-Blooded Lord\|Fenrir-Blooded Lord]] (spirit) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 3.6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 30683 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.6 m high × 1.08 m long × 1.15 m wide; prefab scale 2.
- **Physics:** 576.2 kg, gravity ×1.35, poise 124, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 7.31 m/s, turn 211°/s, stopping distance 1.01 m.
- **Attack count:** 5; **signature:** a crown of frost spikes growing from its mane.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Fenrir-Blooded Lord is a **dread cursed beast** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of frost spikes growing from its mane. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes A|loot_lycan_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 6 | S, A-, A, A+, S-, S+ | 132–203 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | S-, A, S, S+, A- | 132–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03496` | Hoshizora Phantom Fenrir-Blooded Lord Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | S | 188 | 4.5 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03497` | Shen-Lu Phantom Fenrir-Blooded Lord Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S- | 173 | 3.96 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03498` | Shen-Lu Phantom Fenrir-Blooded Lord Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A | 146 | 3.06 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03499` | Hoshizora Phantom Fenrir-Blooded Lord Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | A- | 132 | 2.52 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03500` | Hoshizora Phantom Fenrir-Blooded Lord Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A | 146 | 3.06 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03501` | Shen-Lu Phantom Fenrir-Blooded Lord Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | S | 188 | 4.5 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03502` | Shen-Lu Phantom Fenrir-Blooded Lord Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | S+ | 203 | 4.86 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03503` | Hoshizora Phantom Fenrir-Blooded Lord | [[Regions/Hoshizora\|Hoshizora]] | Adult | A+ | 159 | 3.6 m | Night | A typical adult Phantom Fenrir-Blooded Lord of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03504` | Hoshizora Phantom Fenrir-Blooded Lord Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | S- | 173 | 3.96 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03505` | Shen-Lu Phantom Fenrir-Blooded Lord Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A- | 132 | 2.52 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03506` | Hoshizora Phantom Fenrir-Blooded Lord Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S+ | 203 | 4.86 m | Night | Like a typical Phantom Fenrir-Blooded Lord, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `holy_motes` · palette `#5e5143` `#463b3b` `#ffd166` · elongated, irregular silhouette; still-then-sudden timing
