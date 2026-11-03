# Spell Codex Canon Check

> **Owner:** canon-keeper. **Date:** 2026-11-03. **Checked:** the Spell Codex (2,417 proposed spells, `05_Skills_Magic/Aetheria_Spell_Codex.xlsx`, `Data/Spells/`), its rank and class rules ([[spell_ranks_and_classes]]) and its look-and-feel rules ([[spell_look_and_feel]]) against `Canon.md`, [[skills_and_magic]], [[ranks]], [[base_and_advanced]], [[expert_master_legendary_hidden]], `02_Lore/world_systems.md` and `Data/`.
> **Result:** no locked Canon row is changed. **Nine findings:** 3 need your decision (Canon section 6 rows added), 4 are gaps to fill, 2 are notes. Everything else matches.

## 1. What matches Canon

| Check | Result |
|---|---|
| The six hard limits (no free Aether, no lasting gold or cores, no revival after the lantern, no Status rewrite, no road to Earth, no lasting will control) | Every spell obeys them; the spell text was scanned for violations and the Forbidden consequence is never stated plainly (`world_systems.md`: designer spoiler) |
| Level bands and rank titles F to SSS | Spell minimum levels are exactly the band starts (1, 16, 36, 61, 91, 126, 166, 211, 261), checked by the validator |
| Spell tiers and chant times (Basic 0.5 s to Grand 5 s, Forbidden 8 s, Divine ritual) | Used as is (`Data/Spells/spells.json` `chantSec`) |
| Forbidden is SS and above, Space/Time/Void | All 163 Forbidden Arts spells are SS; no other discipline reaches SS |
| Divine tier is SSS | Only five Divine rites are SSS |
| Class names and mechanics | The 12 base classes are the only class ids used; advanced names come from the Canon map |
| Chant mastery (full, short, name only, chantless) | The look-and-feel chant tells follow these four steps |
| Overcasting and Weave-scars | The Forbidden consequence (scar decal, local light flicker) reuses the Weave-scar idea |
| Telegraph colours and shapes, reserved colours, bloom, outline, hit-stop tiers | Taken from `art_direction.md`, `combat.md` and `combat_tuning.json` unchanged |
| Rank colours and quest and interaction colours | Not used as spell colours (checked per spell); Radiance and Divine stay cream and rose, not gold |
| Content rules (teen, no fanservice, warmth over comedy) | Spell prose is gentle; refusals fade quietly, never punish |

## 2. Findings that need your decision

These are written into Canon section 6 as proposals. Nothing is applied until you say so.

**C1. Canon has Forbidden and Divine spells inside every element; the codex does not.** `skills_and_magic.md` lists, for each element, a Forbidden tier (Fire's *Solar Collapse*, Water's *Abyssal Deluge*, Wind's *Breathless Sky*, Earth's *Gravity Collapse*, Ice's *Eternal Winter*, Lightning's *Rail of Heaven*) and for Fire a Divine tier (*Solenne's Judgment*), as well as a separate Space/Time/Void school. The codex puts Forbidden only in Forbidden Arts and caps every elemental discipline at S. *Proposal:* add one to three SS capstone spells to each elemental discipline (the six above), plus the Divine capstones, and relax the validator rule "Forbidden Arts are exactly the SS spells" when they arrive.

**C2. Three Canon elements have no discipline of their own.** The schema and the monsters use Lightning (27 species), Poison (53) and Blood (25). *Proposal (applied in the data as a proposal):* Lightning is the **Storm** branch of Galecraft (45 spells), Poison the **Blight** branch of Verdance (44 spells), Blood falls under Umbral (no separate branch yet), Void is Forbidden Arts. Aethercraft and Spiritbond are two new non-elemental disciplines, and Divine is a discipline as well as the SSS tier.

**C3. Resurrection wording differs across Canon documents.** `world_systems.md` rule 3: revival works only within minutes, through Morrowyn's mercy, and the Lantern Seal is the single exception. But `skills_and_magic.md` lists *Resurrection (out of combat)* at Light Intermediate, `base_and_advanced.md` gives the Priest *resurrection in combat*, and `expert_master_legendary_hidden.md` gives the Divine Saint *mass resurrection, including NPCs* and the Saint of Lanterns *bring a single dead soul back*. The codex deliberately contains **no** resurrection spell; its closest spell, *Morrow's Measure Prayer*, only steadies a soul inside the window. *Proposal:* state that all resurrection is limited to the minutes-long window, and that the two legendary abilities are story-scale exceptions the Lantern Seal rule must name.

## 3. Gaps to fill

**G1. Canon's named spells are mostly absent from the codex.** The codex has its own names. Closest equivalents for the main Canon spells:

| Canon spell (tier) | Closest codex spell | Note |
|---|---|---|
| Fire Bolt (Basic) | Cinder Fang | The Ring 0 Fire starter; rank E |
| Fireball (Intermediate) | Cinder Dart, Spiral Form | A Barrage burst would suit better; add |
| Flame Wall (Intermediate) | Furnace Ring | Ward or Barrage hybrid |
| Blazing Weapon (Intermediate) | Emberbrand Edge | Matches |
| Heat Haze (Intermediate) | Phoenix Shroud, Soot Phantom | Matches |
| Inferno Pillar (Advanced) | Furnace Ring, Rising Form | Matches |
| Crimson Sun (Grand) | none | Add a Grand Flamecraft Barrage |
| Water Lance (Intermediate) | Current Needle Jet | Matches |
| Tidal Wave (Intermediate) | Breakwall Surge | Matches |
| Healing Rain (Intermediate) | Raincall Veil | Needs a Mending variant |
| Mirror Lake (Advanced) | Mirrorpool Scry | Matches |
| Leviathan's Coil (Grand) | Leviathan Coil | Same name; rank by form |
| Wind Cutter (Basic) | Razorwind Blade | Matches |
| Featherfall (Basic) | Featherfall Drift | Matches |
| Whisper (Basic) | Whisperline Courier | Matches |
| Air Step (Intermediate) | Cloudstep Cushion | Matches |
| Silence Field (Intermediate) | Vacuum Hollow | Close |
| Stone Bullet (Basic) | Quarry Fist | Heavier than Canon's Basic |
| Earth Wall (Basic) | Bastion Rise | Rank B in the codex; lower it if Canon wants Basic |
| Frost Shard (Basic) | Rimefang Shard | Matches |
| Ice Floor (Basic) | Winterstep Bridge | Matches |
| Vine Whip, Entangle (Basic, Intermediate) | Rootsnare Grasp | Matches |
| Heal (Basic) | Blooming Remedy, Mercy Flame | Verdance and Radiance forms; add a Divine Basic heal |
| Sanctuary (Intermediate) | Sanctuary of Hands Prayer | Matches |
| Shadow Bolt (Basic) | none | Add an Umbral Strike at F |
| Shadow Bind (Intermediate) | Duskbind Chain | Matches |
| Summon Shade (Intermediate) | Eclipse Double | Decoy only; the Occultist summon is still missing |
| Teleport, Gate, Pocket Realm, Spatial Storage (Space) | Folded Threshold Step (short step) | The codex deliberately has only brief, local folds |
| Haste, Slow, Stop (Time) | Hollow Interval Gap (nearest) | No Haste, Slow or Stop yet |
| Erase, Null Field, Unmake (Void) | Nullglass Edge Cut | Only the small cut exists |

*Proposal:* add a Canon crosswalk pass that gives every Canon spell a codex entry (rank and tier already given by Canon), so the Canon list and the codex agree.

**G2. Divine patron gods.** The Cleric's Devotion mechanic picks a patron (Solenne holy fire, Sylvara vines and regeneration, Morrowyn spirit lanterns) and Canon lists Divine Favor per god. Divine spells carry no patron tag yet. *Next:* tag each Divine spell with the god that would answer it (the Eight plus Ezrath's silence).

**G3. Aether Saturation for Forbidden spells.** Canon: Forbidden chants take 8 s plus Aether Saturation, a hidden meter. The spell data has no saturation cost. *Next:* a `saturation` field on the 163 SS spells once the meter is designed.

**G4. Sub-grades.** Canon ranks also use minus, normal and plus sub-grades. Spells use plain letters. *Note:* intentional for now; sub-grades could order spells inside a rank later.

## 4. Notes

**N1. Colour overlap.** Aethercraft's cyan sits close to the S-rank colour (mithril cyan). Rank colours belong to cards, loot beams and aura rings; spell effects may use cyan as long as they never appear as a rank ring or loot beam. Recorded in the look-and-feel rules.

**N2. Monsters.** The monster mapping uses the generated species file, so it must be regenerated if species are regenerated; the validator fails if a species id disappears or a spell outranks its caster.

## 5. Where the proposals are

Canon section 6 now carries six new proposed rows (spell codex, ranks and class access, elemental branches, elemental Forbidden and Divine capstones, resurrection wording, monster casters). No locked row was edited.
