---
type: monster
id: mon_thunderbird
family: "Avians"
rank: "B"
tier: core
tags: [monster, avians]
---
# Thunderbird

![[mon_thunderbird_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thunderbird_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,150 tris · 3.516 × 7.736 × 8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thunderbird is a huge creature with a feathered avian body, about 8 m tall. Its plumage is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Survivors describe wings that drum thunder. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17071 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Heavenreach\|Heavenreach]], [[Regions/Vharlen\|Vharlen]], [[Regions/Stormreach\|Stormreach]], [[Regions/Zarvan\|Zarvan]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 3.68 m high × 8 m long × 13.76 m wide; prefab scale 13.333.
- **Physics:** 7168 kg, gravity ×1, poise 1192, knockback resistance 0.17, death style `tumble_feathers_burst`.
- **Navigation:** speed 8.7 m/s, turn 212°/s, stopping distance 2 m.
- **Attack count:** 5; **signature:** wings that drum thunder.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thunderbird is a **menacing avian** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wings that drum thunder. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Heavenreach|Heavenreach]], [[Regions/Vharlen|Vharlen]], [[Regions/Stormreach|Stormreach]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians B|loot_avian_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Avians/Tide Thunderbird|Tide Thunderbird]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 4 | B+, B, C+ | 86–120 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | A, C+, B | 86–146 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 1 | B | 108–108 | Day & Night |
| [[Regions/Heavenreach\|Heavenreach]] | 2 | B+, A | 120–146 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 1 | B- | 96–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02107` | Hoshizora Thunderbird Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B+ | 120 | 8.8 m | Day & Night | Like a typical Thunderbird, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02108` | Vharlen Thunderbird Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | A | 146 | 10.8 m | Day & Night | Like a typical Thunderbird, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02109` | Zarvan Thunderbird | [[Regions/Zarvan\|Zarvan]] | Adult | B | 108 | 8 m | Day & Night | A typical adult Thunderbird of this region, with slate-grey coloring and hardened hide. |
| `pop_02110` | Hoshizora Thunderbird Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B+ | 120 | 8 m | Day & Night | Like a typical Thunderbird, but a rare pale form with white skin or fur and red eyes. |
| `pop_02111` | Vharlen Thunderbird Runt | [[Regions/Vharlen\|Vharlen]] | Runt | C+ | 86 | 5.6 m | Day & Night | Like a typical Thunderbird, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02112` | Hoshizora Thunderbird | [[Regions/Hoshizora\|Hoshizora]] | Adult | B | 108 | 8 m | Day & Night | A typical adult Thunderbird of this region, with slate-grey coloring and hardened hide. |
| `pop_02113` | Hoshizora Thunderbird Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | C+ | 86 | 5.6 m | Day & Night | Like a typical Thunderbird, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02114` | Heavenreach Thunderbird Albino | [[Regions/Heavenreach\|Heavenreach]] | Albino | B+ | 120 | 8 m | Day & Night | Like a typical Thunderbird, but a rare pale form with white skin or fur and red eyes. |
| `pop_02115` | Heavenreach Thunderbird Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | A | 146 | 10.8 m | Day & Night | Like a typical Thunderbird, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02116` | Stormreach Thunderbird Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | B- | 96 | 6.8 m | Day & Night | Like a typical Thunderbird, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02117` | Vharlen Thunderbird | [[Regions/Vharlen\|Vharlen]] | Adult | B | 108 | 8 m | Day & Night | A typical adult Thunderbird of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
