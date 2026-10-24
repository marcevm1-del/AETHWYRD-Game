---
type: monster
id: mon_thunder_fenrir_blooded_lord
family: "Lycanthropes"
rank: "A+"
tier: variant
tags: [monster, lycanthropes]
---
# Thunder Fenrir-Blooded Lord

![[mon_thunder_fenrir_blooded_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thunder_fenrir_blooded_lord_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thunder Fenrir-Blooded Lord is a large creature with an upright humanoid build, about 3.6 m tall. Its fur is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Its most striking feature is a crown of frost spikes growing from its mane. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Fenrir-Blooded Lord\|Fenrir-Blooded Lord]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 3.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 30683 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Heavenreach\|Heavenreach]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Earth. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.6 m high × 1.08 m long × 1.15 m wide; prefab scale 2.
- **Physics:** 606.5 kg, gravity ×1.5, poise 124, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 8.29 m/s, turn 211°/s, stopping distance 1.01 m.
- **Attack count:** 5; **signature:** a crown of frost spikes growing from its mane.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thunder Fenrir-Blooded Lord is a **menacing cursed beast** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of frost spikes growing from its mane. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | A-, S+, S, S- | 132–203 | Day & Night |
| [[Regions/Heavenreach\|Heavenreach]] | 3 | A+, S, S+ | 159–203 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | S-, S+ | 173–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06341` | Shen-Lu Thunder Fenrir-Blooded Lord Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A- | 132 | 2.52 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06342` | Shen-Lu Thunder Fenrir-Blooded Lord Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | S+ | 203 | 4.86 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06343` | Shen-Lu Thunder Fenrir-Blooded Lord Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | S | 188 | 4.5 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06344` | Heavenreach Thunder Fenrir-Blooded Lord | [[Regions/Heavenreach\|Heavenreach]] | Adult | A+ | 159 | 3.6 m | Day & Night | A typical adult Thunder Fenrir-Blooded Lord of this region, with slate-grey coloring and hardened hide. |
| `pop_06345` | Hoshizora Thunder Fenrir-Blooded Lord Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | S- | 173 | 3.96 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06346` | Hoshizora Thunder Fenrir-Blooded Lord Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S+ | 203 | 4.86 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06347` | Shen-Lu Thunder Fenrir-Blooded Lord Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S- | 173 | 3.6 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_06348` | Shen-Lu Thunder Fenrir-Blooded Lord Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S- | 173 | 3.96 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06349` | Heavenreach Thunder Fenrir-Blooded Lord Alpha | [[Regions/Heavenreach\|Heavenreach]] | Alpha | S | 188 | 4.5 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06350` | Hoshizora Thunder Fenrir-Blooded Lord Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | S- | 173 | 3.6 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_06351` | Heavenreach Thunder Fenrir-Blooded Lord Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | S+ | 203 | 4.86 m | Day & Night | Like a typical Thunder Fenrir-Blooded Lord, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
