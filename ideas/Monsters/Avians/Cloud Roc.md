---
type: monster
id: mon_cloud_roc
family: "Avians"
rank: "A+"
tier: variant
tags: [monster, avians]
---
# Cloud Roc

> The Cloud Roc is a colossal creature with a feathered avian body, about 30 m tall. Its plumage is rough, scarred and spiked, colored in pale jade and cloud white. Look for a shadow as big as a cloud. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by swirling leaves and a constant breeze. Adapted to sky lands, it has cloud-pale coloring and lighter bones.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Roc\|Roc]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 30 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 42771 · 646 · 517 · 452 · 517 · 135 |
| XP · gold | 9993 · 1815 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Heavenreach\|Heavenreach]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 13.8 m high × 30 m long × 51.6 m wide; prefab scale 50.
- **Physics:** 340200 kg, gravity ×0.8, poise 9739, knockback resistance 0.2, death style `tumble_feathers_burst`.
- **Navigation:** speed 18.53 m/s, turn 110°/s, stopping distance 6.4 m.
- **Attack count:** 5; **signature:** a shadow as big as a cloud.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cloud Roc is a **menacing avian** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shadow as big as a cloud. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Heavenreach|Heavenreach]], [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians A|loot_avian_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Heavenreach\|Heavenreach]] | 6 | S+, A+, A-, S-, S | 132–203 | Day & Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 5 | S-, A-, S, S+, A+ | 132–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04979` | Heavenreach Cloud Roc Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | S+ | 203 | 40.5 m | Day & Night | Like a typical Cloud Roc, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04980` | Sky Archipelago Cloud Roc Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | S- | 173 | 33 m | Day & Night | Like a typical Cloud Roc, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_04981` | Sky Archipelago Cloud Roc Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | A- | 132 | 21 m | Day & Night | Like a typical Cloud Roc, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_04982` | Heavenreach Cloud Roc | [[Regions/Heavenreach\|Heavenreach]] | Adult | A+ | 159 | 30 m | Day & Night | A typical adult Cloud Roc of this region, with slate-grey coloring and hardened hide. |
| `pop_04983` | Heavenreach Cloud Roc Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | A- | 132 | 21 m | Day & Night | Like a typical Cloud Roc, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04984` | Heavenreach Cloud Roc Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | S- | 173 | 33 m | Day & Night | Like a typical Cloud Roc, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04985` | Heavenreach Cloud Roc Albino | [[Regions/Heavenreach\|Heavenreach]] | Albino | S- | 173 | 30 m | Day & Night | Like a typical Cloud Roc, but a rare pale form with white skin or fur and red eyes. |
| `pop_04986` | Sky Archipelago Cloud Roc Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | S | 188 | 37.5 m | Day & Night | Like a typical Cloud Roc, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |
| `pop_04987` | Sky Archipelago Cloud Roc Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | S+ | 203 | 40.5 m | Day & Night | Like a typical Cloud Roc, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_04988` | Sky Archipelago Cloud Roc | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | A+ | 159 | 30 m | Day & Night | A typical adult Cloud Roc of this region, with cloud-pale coloring and lighter bones. |
| `pop_04989` | Heavenreach Cloud Roc Alpha | [[Regions/Heavenreach\|Heavenreach]] | Alpha | S | 188 | 37.5 m | Day & Night | Like a typical Cloud Roc, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
