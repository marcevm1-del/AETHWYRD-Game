# Spell Ranks, Class Access and Monster Casters

> **Owner:** class-skill-designer with the bestiary-designer and systems-designer. **Status:** PROPOSED v1, 2026-11-03, not locked Canon. Machine-readable copies: `Data/Spells/spells.json` (2417 spells) and `Data/Spells/monster_spells.json` (631 species), checked by `node Tools/validate/validate.js`. Prose for every spell is in `05_Skills_Magic/Aetheria_Spell_Codex.xlsx`.
> **Builds on:** [[ranks]] (nine ranks, level bands) · [[skills_and_magic]] (spell tiers and chant times) · [[base_and_advanced]] (the 12 base and 24 advanced classes) · [[spell_look_and_feel]].

## 1. Every spell has a rank

| Rank | Title | Level | Spell tier | Chant | Class tier needed | Spells |
|---|---|---|---|---|---|---|
| **F** | Rookie | 1-15 | Basic | 0.5 s | Base | 324 |
| **E** | Novice | 16-35 | Basic | 0.5 s | Base | 482 |
| **D** | Journeyman | 36-60 | Intermediate | 1.5 s | Base | 750 |
| **C** | Veteran | 61-90 | Intermediate | 1.5 s | Advanced | 232 |
| **B** | Elite | 91-125 | Advanced | 3 s | Advanced | 238 |
| **A** | Champion | 126-165 | Advanced | 3 s | Advanced | 83 |
| **S** | Hero | 166-210 | Grand | 5 s | Expert | 140 |
| **SS** | Calamity | 211-260 | Forbidden | 8 s + Aether Saturation | Expert | 163 |
| **SSS** | Transcendent | 261-300 | Divine | Ritual / Devotion | Master | 5 |

**How a rank is set.** A complexity score is built from the category (Utility is simplest, Barrage most complex), the form (a plain needlepoint is simpler than an echo or an oathbound rite), the size of the family (a Comet or Cascade is bigger than a Spark or Thread) and, for catalogue names, a small adjective effect (Storm and Mountain up, Gentle and Glimmer down). Score 0 or less is F, 1-2 E, 3-4 D, 5 C, 6 B, 7 A, 8 or more S. The same kind of spell has the same rank in every discipline.

**Two disciplines are special.** Forbidden Arts are all **SS** (Canon: Forbidden is SS and above, Space, Time and Void). Divine spells run from F to S as Devotion spells of the Cleric's patron god; only the five most complex rites are **SSS**, the Canon Divine tier.

**Elements.** The schema's elements map to the disciplines: Fire is Flamecraft, Water Tidecraft, Wind and Lightning Galecraft (Lightning is its **Storm** branch), Earth Stonecraft, Ice Frostcraft, Nature and Poison Verdance (Poison is its **Blight** branch), Light Radiance, Dark and Blood Umbral, Void Forbidden. Aethercraft, Spiritbond and Divine have no element.

## 2. Class access

Each spell lists the base classes that learn it as part of their identity (primary) and those that can learn it from a spellbook (secondary). Base class names link to their advanced classes in [[base_and_advanced]].

| Discipline | Primary classes | Secondary classes |
|---|---|---|
| **Aethercraft** | Mage, Artisan | Guardian, Lancer, Rogue, Bard |
| **Flamecraft** | Mage, Martial Artist | Swordsman, Artisan, Lancer, Tamer, Cleric |
| **Tidecraft** | Mage | Cleric, Ranger, Bard, Tamer |
| **Galecraft** | Mage, Swordsman, Ranger, Rogue, Bard, Martial Artist | Lancer, Tamer |
| **Stonecraft** | Mage, Guardian, Artisan | Martial Artist, Tamer, Cleric |
| **Frostcraft** | Mage | Guardian, Ranger, Tamer, Cleric |
| **Verdance** | Ranger, Cleric, Tamer | Mage, Artisan |
| **Radiance** | Cleric, Guardian, Lancer | Mage, Bard, Tamer |
| **Umbral** | Occultist, Rogue | Mage |
| **Spiritbond** | Tamer | Cleric, Ranger, Bard, Occultist |
| **Divine** | Cleric, Martial Artist | Guardian, Bard |
| **Forbidden Arts** | Mage, Occultist | Rogue |

The workbook sheet **Class Access** counts how many spells each class gets, per discipline. The class tier needed follows the promotion table in [[ranks]]: base classes learn F-D spells, Advanced classes C-A, Expert classes S and SS, Master classes SSS.

## 3. Which monsters cast which spells

631 of the 680 species cast spells: 229 true casters (M.ATK above ATK, a magical family, a caster's name, or a unique) with 2 to 5 spells each (most have 3), and 402 elemental species with one affinity spell. Rules:

- **Element picks the discipline** (see section 1); elementless casters use Aethercraft, spirit families Spiritbond, and only Calamity-rank (SS) species and above touch the Forbidden Arts.
- **A spell is never ranked above its caster.** A C+ monster casts spells of rank C or lower, and prefers the top of that range. EX species may cast anything.
- **Menu:** an offence spell (Strike or Barrage), a control spell (Binding or Hex) and a support spell (Ward, Illusion, Mending or Empowerment); uniques add a fourth, Tyrants a fifth, a Barrage.
- **Telegraph follows the category:** Strike is blue (parryable), Barrage red (unblockable zone), Binding gold (grab), the rest none. When a monster casts, the spell uses its dimmer enemy palette from [[spell_look_and_feel]].

The full list is the workbook sheet **Monster Casters** and `Data/Spells/monster_spells.json`.

