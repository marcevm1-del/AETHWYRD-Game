---
type: monster
id: mon_zephyr_rogue_knight
family: "Humanoid Enemies"
rank: "A+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Zephyr Rogue Knight

> The Zephyr Rogue Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its clothing and gear are rough, scarred and spiked, colored in pale jade and cloud white. Its most striking feature is a broken oath engraved on its blade. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Rogue Knight\|Rogue Knight]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25157 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Gearholm\|Gearholm]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 93.6 kg, gravity ×1.2, poise 92, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.18 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** a broken oath engraved on its blade.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Zephyr Rogue Knight is a **menacing humanoid** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a broken oath engraved on its blade. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Gearholm|Gearholm]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies A|loot_humanoid_enemy_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Gearholm\|Gearholm]] | 2 | S-, S+ | 173–203 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | A, S- | 146–173 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 6 | A, A+, S+, S, S-, A- | 132–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05637` | Gearholm Zephyr Rogue Knight Albino | [[Regions/Gearholm\|Gearholm]] | Albino | S- | 173 | 2 m | Day & Night | Like a typical Zephyr Rogue Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_05638` | Hoshizora Zephyr Rogue Knight Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A | 146 | 1.7 m | Day & Night | Like a typical Zephyr Rogue Knight, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05639` | Hoshizora Zephyr Rogue Knight Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | S- | 173 | 2.2 m | Day & Night | Like a typical Zephyr Rogue Knight, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05640` | Vharlen Zephyr Rogue Knight Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | A | 146 | 1.7 m | Day & Night | Like a typical Zephyr Rogue Knight, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05641` | Vharlen Zephyr Rogue Knight | [[Regions/Vharlen\|Vharlen]] | Adult | A+ | 159 | 2 m | Day & Night | A typical adult Zephyr Rogue Knight of this region, with golden, grass-toned coloring. |
| `pop_05642` | Vharlen Zephyr Rogue Knight Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | S+ | 203 | 2.7 m | Day & Night | Like a typical Zephyr Rogue Knight, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05643` | Vharlen Zephyr Rogue Knight Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | S | 188 | 2.5 m | Day & Night | Like a typical Zephyr Rogue Knight, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05644` | Gearholm Zephyr Rogue Knight Elderborn | [[Regions/Gearholm\|Gearholm]] | Elderborn | S+ | 203 | 2.7 m | Day & Night | Like a typical Zephyr Rogue Knight, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_05645` | Vharlen Zephyr Rogue Knight Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | S- | 173 | 2.2 m | Day & Night | Like a typical Zephyr Rogue Knight, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05646` | Vharlen Zephyr Rogue Knight Runt | [[Regions/Vharlen\|Vharlen]] | Runt | A- | 132 | 1.4 m | Day & Night | Like a typical Zephyr Rogue Knight, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05647` | Hoshizora Zephyr Rogue Knight Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | S- | 173 | 2 m | Day & Night | Like a typical Zephyr Rogue Knight, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
