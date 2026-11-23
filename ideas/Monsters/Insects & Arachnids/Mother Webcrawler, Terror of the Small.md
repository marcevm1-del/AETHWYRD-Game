---
type: monster
id: mon_mother_webcrawler_terror_of_the_small
family: "Insects & Arachnids"
rank: "C+"
tier: core
tags: [monster, insects-arachnids, tyrant, unique]
---
# Mother Webcrawler, Terror of the Small

![[mon_mother_webcrawler_terror_of_the_small_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mother_webcrawler_terror_of_the_small_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.347 × 1.201 × 0.668 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_mother_webcrawler_terror_of_the_small.fbx`

> The Mother Webcrawler, Terror of the Small is a person-sized creature with a bulbous spider frame on long jointed legs, about 1.2 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in glossy brown, with sickly green markings. Look for a spider no bigger than a cat, which to the Thimblefolk is a mountain. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 1.2 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6533 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 74865 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Mossdeep\|Mossdeep]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.34 m high × 1.2 m long × 0.82 m wide; prefab scale 1.2.
- **Physics:** 57 kg, gravity ×1.4, poise 69, knockback resistance 0.29, death style `flip_legs_curl`.
- **Navigation:** speed 5.16 m/s, turn 548°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** a spider no bigger than a cat, which to the Thimblefolk is a mountain.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mother Webcrawler, Terror of the Small is a **dread insectoid** encountered at C+ rank, around level 86. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a spider no bigger than a cat, which to the Thimblefolk is a mountain. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Mossdeep|Mossdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids C|loot_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Mossdeep\|Mossdeep]] | 1 | C+ | 86–86 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06719` | Mother Webcrawler, Terror of the Small | [[Regions/Mossdeep\|Mossdeep]] | Unique | C+ | 86 | 1.2 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#836134` `#543f22` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
