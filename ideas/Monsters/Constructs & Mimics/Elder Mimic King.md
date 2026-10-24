---
type: monster
id: mon_elder_mimic_king
family: "Constructs & Mimics"
rank: "S"
tier: variant
tags: [monster, constructs-mimics]
---
# Elder Mimic King

![[mon_elder_mimic_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_mimic_king_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Mimic King is a huge creature with an object-shaped body that hides its true form, about 9.6 m tall. Its surface is stretched, stitched and constantly shifting, colored in muted greys and dusty browns. Survivors describe a treasure vault that walks on a hundred stolen legs. It has a human-like face in the wrong place. Its regal silhouette is crowned by a halo-like ring of aura. It crawls across ceilings. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Mimic King\|Mimic King]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 5 · Horror |
| Element · weakness | None · Fire |
| Size | 9.6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 48443 · 953 · 686 · 480 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 9.6 m high × 10.29 m long × 10.08 m wide; prefab scale 4.8.
- **Physics:** 26542.1 kg, gravity ×1.2, poise 1340, knockback resistance 0.78, death style `collapse_and_melt`.
- **Navigation:** speed 12.97 m/s, turn 161°/s, stopping distance 3.28 m.
- **Attack count:** 4; **signature:** a treasure vault that walks on a hundred stolen legs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Mimic King is a **horror construct** encountered at S rank, around level 188. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a treasure vault that walks on a hundred stolen legs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics S|loot_construct_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | S-, SS-, S+, S, A+ | 159–218 | Night |
| [[Regions/Vesper\|Vesper]] | 5 | S+, S, SS-, A+ | 159–218 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04418` | Sky Archipelago Elder Mimic King Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S- | 173 | 8.16 m | Night | Like a typical Elder Mimic King, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_04419` | Sky Archipelago Elder Mimic King Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SS- | 218 | 12 m | Night | Like a typical Elder Mimic King, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |
| `pop_04420` | Sky Archipelago Elder Mimic King Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | S+ | 203 | 10.56 m | Night | Like a typical Elder Mimic King, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_04421` | Vesper Elder Mimic King Albino | [[Regions/Vesper\|Vesper]] | Albino | S+ | 203 | 9.6 m | Night | Like a typical Elder Mimic King, but a rare pale form with white skin or fur and red eyes. |
| `pop_04422` | Sky Archipelago Elder Mimic King | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S | 188 | 9.6 m | Night | A typical adult Elder Mimic King of this region, with cloud-pale coloring and lighter bones. |
| `pop_04423` | Vesper Elder Mimic King | [[Regions/Vesper\|Vesper]] | Adult | S | 188 | 9.6 m | Night | A typical adult Elder Mimic King of this region, with dust-grey coloring and old rune scars. |
| `pop_04424` | Vesper Elder Mimic King Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SS- | 218 | 12 m | Night | Like a typical Elder Mimic King, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04425` | Sky Archipelago Elder Mimic King Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | S+ | 203 | 9.6 m | Night | Like a typical Elder Mimic King, but a rare pale form with white skin or fur and red eyes. |
| `pop_04426` | Vesper Elder Mimic King Scarred | [[Regions/Vesper\|Vesper]] | Scarred | S+ | 203 | 10.56 m | Night | Like a typical Elder Mimic King, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04427` | Vesper Elder Mimic King Runt | [[Regions/Vesper\|Vesper]] | Runt | A+ | 159 | 6.72 m | Night | Like a typical Elder Mimic King, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04428` | Sky Archipelago Elder Mimic King Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | A+ | 159 | 6.72 m | Night | Like a typical Elder Mimic King, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · broken symmetry, mimicry, audio-first reveal
