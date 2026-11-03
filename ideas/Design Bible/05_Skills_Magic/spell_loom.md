# The Spell Loom

> **Owner:** class-skill-designer with the systems-designer and combat-designer. **Status:** PROPOSED v1, 2026-11-03, not locked Canon. Data: `Data/Spells/threads.json`, `loom_ranks.json`, `attunement_tree.json`, `ascension.json` (checked by `node Tools/validate/validate.js`). Interactive version: the Aetheria Spell Loom page. Every number is a tunable proposal.
> **Builds on:** [[spell_ranks_and_classes]] (every spell has a rank and learners) · [[skills_and_magic]] (chant tiers, proficiency 1-10, Evolve or Fuse) · [[base_and_advanced]] (classes, the Spellweaver's glyphs) · [[ranks]] · [[combat]].

## 1. The idea in one paragraph

A caster does not just learn spells. They **weave** them. Spells sit in a small number of **Loom slots**. Each spell has **thread sockets**, and a **thread** is a modifier that changes how that one spell behaves: its shape, its power, its element, or when it fires. Every thread raises the spell's **Strain** (a cost multiplier), so power always has a price. Spells that stay up (wards, blessings, familiars) reserve **Hold** from a budget instead of costing MP each time. Behind the Loom sits the **Attunement tree**, a web of passive nodes with keystones that trade one strength for one weakness, and after the advanced class change an **Ascension tree** for the class itself.

## 2. Research: what the Path of Exile skill system does, and what we took

Research date 2026-11-03, from public guides and wikis (listed in section 12). Several wiki pages blocked automated access, so some details come from search summaries and guides; the numbers for Path of Exile 2 were still changing in early access and are not used. **Only mechanics and ideas are used. No names, text, numbers, art or data are copied, as the project rules require.**

| What the studied system does | The idea we kept | How Aetheria does it (original) |
|---|---|---|
| Every ability comes from a socketed gem; **support gems** linked to it modify it | Spells are the base, modifiers attach to one spell | Spells in **Loom slots** with **threads** in each spell's **thread sockets** |
| Supports raise the skill's **mana cost by a multiplier**; a few lower it | Power always costs; the cost is a visible number | Every thread has a **Strain** multiplier; the total is the product (Frugal lowers it) |
| Supports only work with certain skill types, set separately from tags | Compatibility is a rule, not a free-for-all | Each thread lists allowed **categories** and **disciplines** |
| Socket count and links are the long chase (up to 6 links) | A slow, visible power curve for one spell | Thread sockets grow by **rank** (1 to 5), capped by the spell's own tier |
| Persistent effects (auras, permanent minions) **reserve a budget** (Spirit in the sequel) instead of costing mana | A separate budget keeps buffs from stacking without limit | **Hold**: persistent spells and trigger threads reserve it while active |
| **Meta gems** trigger skills on conditions | Spells can fire on your own good play | **Trigger threads**: on a perfect dodge, a parry, a stagger, an element reaction |
| Gems level with use and can be upgraded or swapped | Mastery through use | Proficiency 1-10 by use (Canon); at 10 **Evolve** (imprint a shape thread permanently) or **Fuse** |
| A huge **passive tree**: small, notable and keystone nodes; class start points; one shared web | Where you start only suggests where you go | The **Attunement tree**: 12 discipline arms, 12 class starts, bridges between arms |
| **Keystones** change the rules and come with downsides | Big choices must hurt a little | One keystone per discipline, each with a stated downside |
| **Ascendancy** sub-classes with their own small tree, unlocked by a trial | Class identity deepens late | **Ascension trees** for advanced classes, unlocked by the class change itself |
| Respec is costly and scarce | (Not kept) | Canon says respec is always possible: free to level 10, then a small cost, never blocked |

## 3. The Loom: rules

1. **Loom slots.** Only spells in a slot can be cast. Slots by rank: F 2, E 3, D 4, C 4, B 5, A 5, S 6, SS 6, SSS 7. Weapon arts and class basic strings do not use slots.
2. **Thread sockets.** Each spell has sockets up to the rank cap (F 1, E 2, D 2, C 3, B 3, A 4, S 4, SS 5, SSS 5), and never more than its own tier allows (Basic 3, Intermediate 4, Advanced and above 5).
3. **One shape, one attune.** A spell takes at most one Shape thread and one Attune thread, and never the same thread twice. Power and trigger threads stack freely within sockets.
4. **Strain.** MP cost = base cost x the product of all thread Strain values. Frugal (0.80) is the only thread below 1.
5. **Chant.** Chant time = tier chant (0.5 / 1.5 / 3 / 5 / 8 s) x chant modifiers (Swift Chant 0.7, Overcharge 1.4). Mastery steps (full, short, name only, chantless) still shorten it as in Canon.
6. **Compatibility.** A thread works only on the categories and disciplines it lists. An incompatible thread simply does not fit the socket.
7. **Changing threads** is free out of combat at any Loom Shrine or camp. Mid-fight changes are an Ascension perk (Spellweaver).
8. **Class bonuses.** Spellweavers can carry two Shape threads on one spell (a notable); Clerics and Tamers gain the most Hold; Mages have the widest compatible spell list.

### Loom ranks

| Rank | From level | Tier | Loom slots | Max sockets | Hold | Attunement points | What opens |
|---|---|---|---|---|---|---|---|
| **F** | 1 | Basic | 2 | 1 | 0 | 0 | Plain spells. One thread socket appears on your first spell. No Hold: persistent spells wait until E. |
| **E** | 16 | Basic | 3 | 2 | 20 | 5 | Third spell slot, second thread socket and your first Hold. Shape threads from trainers. Free respec of the tree ends at level 10. |
| **D** | 36 | Intermediate | 4 | 2 | 40 | 12 | Four spells. Power threads appear in trainer shops. Spells of Intermediate tier (1.5 s chant). |
| **C** | 61 | Intermediate | 4 | 3 | 60 | 20 | Advanced class: Ascension tree opens and the third socket arrives. Attune threads (add an element aura). |
| **B** | 91 | Advanced | 5 | 3 | 80 | 30 | Fifth slot. Trigger threads (react to a dodge, a parry or a reaction). Advanced tier spells (3 s chant). |
| **A** | 126 | Advanced | 5 | 4 | 100 | 42 | Fourth socket. Keystones become reachable on the attunement tree. |
| **S** | 166 | Grand | 6 | 4 | 130 | 55 | Sixth slot. Expert class. Grand tier spells (5 s chant). Imprint any spell at proficiency 10. |
| **SS** | 211 | Forbidden | 6 | 5 | 160 | 70 | Fifth socket. Forbidden spells (8 s chant) and Weave-light threads; Aether Saturation matters. |
| **SSS** | 261 | Divine | 7 | 5 | 200 | 87 | Seventh slot. Master class and the Divine rituals. Everything the Loom can hold. |

## 4. Threads (58)

### Shape threads: the codex forms become modifiers

The 28 forms of the Spell Codex are no longer separate spells. They are threads you fit to any compatible spell of their group (Weave: Aethercraft and the elements; Bond; Faith; Frayed). Evolving a spell at proficiency 10 imprints one of them for free.

| Thread | Group | Strain | Min rank | Hold | Effect |
|---|---|---|---|---|---|
| **Needlepoint** | weave | x1.15 | F |  | Narrows the spell to a single point: half width, +20% range, no spread. |
| **Sweeping Arc** | weave | x1.20 | E |  | Widens the spell to a 90 degree arc: triple width, -20% range. |
| **Twin Cast** | weave | x1.30 | D |  | Casts two linked halves 1.5 m apart, each at 60% strength. |
| **Spiral Form** | weave | x1.25 | D |  | Rotates the pattern so it is harder to read, less stable to interruption. |
| **Grounded Form** | weave | x1.10 | F |  | Keeps the spell low, following terrain and affecting footing. |
| **Rising Form** | weave | x1.20 | D |  | Angles the spell upward as a 5 m column for ledges and fliers. |
| **Echo Form** | weave | x1.40 | C |  | Repeats the spell 0.45 s later at 60% strength; the repeat can be interrupted. |
| **Gentle Call** | bond | x1.00 | F |  | A low-pressure request: the spirit has plenty of room to refuse and rarely takes offence. |
| **Urgent Call** | bond | x1.25 | E |  | Presses the request: faster answer, 130% brightness, but too many sour the bond. |
| **Shared Guard** | bond | x1.20 | D |  | Caster and spirit share the strain; any harm to one is felt by the other. |
| **Guiding Path** | bond | x1.10 | E |  | The spirit lays out a route of 5-7 lights instead of acting directly. |
| **Warning Sign** | bond | x1.10 | E |  | The spirit keeps watch and signals when something draws near. |
| **Resonant Echo** | bond | x1.35 | C |  | The working repeats twice at 70% and 40% strength, coloured by the spirit's memory. |
| **Parting Form** | bond | x1.00 | D |  | Releases the spirit with thanks and leaves a final gift as it goes. |
| **Quiet Prayer** | faith | x0.90 | F |  | A private appeal at half scale. Cheap, gentle, easily lost in noise. |
| **Public Prayer** | faith | x1.40 | D |  | Prays aloud for a group at x1.8 scale. Others in range add their own lights. |
| **Vigil Form** | faith | x1.30 | D |  | Holds the prayer over a long time (20 s). Ends when the caster tires. |
| **Pilgrim Form** | faith | x1.15 | E |  | The prayer travels with the caster, leaving footprints of light for 3 s. |
| **Sanctuary Form** | faith | x1.35 | C |  | Claims a small place as refuge, radius 2.5 m. |
| **Oathbound Form** | faith | x1.30 | B |  | Ties the prayer to a vow and one named person; stronger while the oath is kept. |
| **Last-Rite Form** | faith | x1.20 | B |  | Comfort and mercy at the end of a life, inside the narrow limits the world allows. |
| **Needle Fold** | frayed | x1.20 | SS |  | A hairline seam of space 2 m long. Precise and brief. |
| **Wide Fold** | frayed | x1.45 | SS |  | A broad 3 x 2 m sheet. Strains the Weave more. |
| **Single Echo** | frayed | x1.25 | SS |  | Draws out one echo of a recent moment at 50% strength. |
| **Delayed Echo** | frayed | x1.30 | SS |  | The echo arrives 0.8 s late at 35% strength. |
| **Thin Edge** | frayed | x1.20 | SS |  | A 0.03 m line of absence that unthreads small constructs. |
| **Quiet Field** | frayed | x1.40 | SS |  | A zone of radius 2.5 m where spellwork falters and colour drains. |
| **Fracture Form** | frayed | x1.60 | SS |  | 9-12 jagged shards that scatter and reassemble. The greatest Weave damage. |

### Power threads

| Thread | Group | Strain | Min rank | Hold | Effect |
|---|---|---|---|---|---|
| **Potency** | any | x1.30 | D |  | +25% effect strength. |
| **Frugal** | any | x0.80 | F |  | -10% effect strength, but the Strain is lower than 1. |
| **Swift Chant** | any | x1.25 | D |  | -30% chant time. |
| **Steady Chant** | any | x1.20 | D |  | Light hits no longer break the chant. |
| **Lingering** | any | x1.20 | E |  | +40% duration. |
| **Far Reach** | any | x1.10 | E |  | +30% range. |
| **Focus** | any | x1.15 | D |  | -30% area and +25% effect strength. |
| **Wide Weave** | any | x1.20 | D |  | +35% area and -15% effect strength. |
| **Chain** | any | x1.30 | C |  | Jumps once to a nearby target at 60% strength. |
| **Piercing** | any | x1.35 | C |  | Ignores 25% of the target's M.DEF. |
| **Weave-light** | any | x1.50 | SS |  | -50% Aether Saturation gained by the spell. |
| **Quickened** | any | x1.25 | C |  | -25% release and recovery time. |
| **Overcharge** | any | x1.50 | B |  | +60% effect strength and +40% chant time. At 0 MP the recoil is 10% HP. |
| **Anchored** | any | x1.15 | D |  | The spell holds 20% less Hold (persistent spells only). |
| **Tether** | any | x1.10 | C |  | Also applies to one ally within 6 m. |
| **Walking Cast** | any | x1.25 | E |  | You can move at half speed while chanting. |

### Attune threads: borrow an element

| Thread | Group | Strain | Min rank | Hold | Effect |
|---|---|---|---|---|---|
| **Attune: Ember** | any | x1.25 | C |  | Adds a Fire aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Tide** | any | x1.25 | C |  | Adds a Water aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Gust** | any | x1.25 | C |  | Adds a Wind aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Stone** | any | x1.25 | C |  | Adds a Earth aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Rime** | any | x1.25 | C |  | Adds a Ice aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Thorn** | any | x1.25 | C |  | Adds a Nature aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Gleam** | any | x1.25 | C |  | Adds a Light aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Gloam** | any | x1.25 | C |  | Adds a Dark aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Spark** | any | x1.25 | C |  | Adds a Lightning aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |
| **Attune: Venom** | any | x1.25 | C |  | Adds a Poison aura to the spell's hits (6 s), so it can start or finish reactions. Useless on a spell of its own element. |

### Trigger threads: fire on your own good play

| Thread | Group | Strain | Min rank | Hold | Effect |
|---|---|---|---|---|---|
| **Reflex Ward** | any | x1.00 | B | 30 | Casts the linked spell for you when you are staggered. 20 s cooldown. Fires when you are staggered. |
| **Echo of the Dodge** | any | x1.00 | B | 25 | Casts the linked spell during Flash Time after a perfect dodge. Fires on a perfect dodge. |
| **Riposte Weave** | any | x1.00 | B | 25 | Casts the linked spell as part of the riposte. Fires on a parry. |
| **Reaction Spark** | any | x1.00 | A | 35 | Casts the linked spell whenever you trigger an element reaction. Fires on an element reaction. |

## 5. Hold: the budget for spells that stay up

Wards, blessings, illusions, familiars, lanterns and trigger threads reserve **Hold** while active, and give it back when they end. Hold by rank: F 0, E 20, D 40, C 60, B 80, A 100, S 130, SS 160, SSS 200. Suggested reservations: a Ward 30, an Empowerment 25, an Illusion 20, a Pact familiar 40, a Utility lantern 10. MP does not reserve; a caster's MP pool is always full for casting. The Anchored thread lowers a spell's reservation by 20%.

## 6. Proficiency, Evolve and Fuse

Spells level 1-10 by use (Canon). Each level adds 4% potency (36% at 10) and removes 1% Strain. At level 10 the player chooses: **Evolve** (imprint one Shape thread from the spell's family forever: no socket, no Strain) or **Fuse** (merge with another level 10 spell of a reacting element into a combined spell, the old Fuse rule). The codex form ranks are the ranks of the evolved forms.

## 7. The Attunement tree

A radial web of **145 nodes**: 1 hub, 12 class starts, 12 discipline arms of 10 nodes each (6 small, 3 notable, 1 keystone) and 12 bridges between neighbouring arms. You start on your class's start node and may path anywhere; where you start only suggests where you go. Points: 1 per 3 levels (100 at level 300). Costs: small and bridge 1, notable 2, keystone 3. Arms in ring order: Aethercraft, Flamecraft, Galecraft, Stonecraft, Frostcraft, Tidecraft, Verdance, Spiritbond, Divine, Radiance, Umbral, Forbidden Arts. The ring puts Aethercraft beside Flamecraft and Forbidden Arts, Spiritbond beside Divine, and so on.

### Keystones (one per discipline, each with a downside)

| Keystone | Discipline | You gain | You pay |
|---|---|---|---|
| **Fixed Pattern** | Aethercraft | Shape threads cost no Strain. | You cannot socket Power threads. |
| **Hungry Flame** | Flamecraft | Fire spells gain +35% potency. | Fire spells cost 25% more MP and scorch you for 1% HP at 0 MP. |
| **Open Sky** | Galecraft | All spells release 20% faster. | You have 10% less maximum HP. |
| **Unmoved** | Stonecraft | Light and Medium hits no longer break any chant. | Movement speed is reduced by 15%. |
| **Stillness** | Frostcraft | Ice spells gain +30% potency. | Ice spells have 25% longer release time. |
| **Deep Current** | Tidecraft | Water spells chant 25% faster. | Water spells have 15% less range. |
| **Wild Growth** | Verdance | +30% Hold. | Nature spells cannot be cast while sprinting. |
| **Open Hand** | Spiritbond | +15 Hold and spirits accept your calls more often. | Urgent Call threads cannot be socketed. |
| **Unwavering Faith** | Divine | Divine refusals are half as likely. | Divine spells cost 50% more Devotion. |
| **Unveiled** | Radiance | Light spells gain +25% potency. | Enemies notice you from 30% farther away. |
| **Chosen Shadow** | Umbral | Dark spells gain +25% potency. | Light spells you cast are 50% weaker. |
| **Frayed Edge** | Forbidden Arts | Forbidden spells chant 40% faster. | Aether Saturation gained is doubled. |

### Notables

| Notable | Discipline | Effect |
|---|---|---|
| Loomwright | Aethercraft | +1 thread socket on your first Loom spell (up to your rank's cap). |
| Clean Seams | Aethercraft | Shape threads on Aethercraft spells have 15% less Strain. |
| Anchored Mind | Aethercraft | Light hits no longer break the chant of Aethercraft spells. |
| Banked Embers | Flamecraft | Fire spells gain +10% potency for 3 s after another Fire spell. |
| Kindler's Breath | Flamecraft | -10% chant time of Fire spells. |
| Phoenix Habit | Flamecraft | Below 30% HP, Fire spells gain +20% potency. |
| Quick Hands | Galecraft | -10% release time of all spells. |
| Carried Voice | Galecraft | +15% range of Wind spells. |
| Unbroken Breath | Galecraft | Wind spells ignore the first Light hit during a chant. |
| Deep Roots | Stonecraft | Earth Ward spells are 15% stronger. |
| Patient Hammer | Stonecraft | Earth Strike spells with chants of 1.5 s or more deal +10% damage. |
| Slow Mountain | Stonecraft | You take 15% less damage while chanting an Earth spell. |
| Quiet Winter | Frostcraft | +10% duration of Ice spells. |
| Brittle Edge | Frostcraft | Ice spells deal +15% damage to slowed targets. |
| Clear Breath | Frostcraft | -10% MP cost of Ice spells. |
| Patient Tide | Tidecraft | +15% duration of Water spells. |
| Undercurrent | Tidecraft | Water Binding spells slow 10% more. |
| Clear Water | Tidecraft | Water Mending spells are 10% stronger. |
| Green Reserve | Verdance | +10 Hold. |
| Rooted Calm | Verdance | Nature Mending spells are 12% stronger. |
| Thorn Habit | Verdance | Nature Binding spells are 10% stronger. |
| Kind Voice | Spiritbond | +10% chance a spirit accepts your call. |
| Shared Lantern | Spiritbond | +10 Hold. |
| Patient Friend | Spiritbond | Refused calls recover 30% faster. |
| Steady Vow | Divine | Oathbound Form has 15% less Strain. |
| Candle Keeper | Divine | Devotion recovers 20% faster. |
| Kind Hearth | Divine | Divine Mending spells are 10% stronger. |
| Open Palm | Radiance | +10% potency of Light spells. |
| Steady Dawn | Radiance | Light Ward spells last 15% longer. |
| Prism Eye | Radiance | +25% range of Light Sensing spells. |
| Shaded Reserve | Umbral | -10% MP cost of Illusion spells. |
| Long Shadow | Umbral | +15% duration of Illusion spells. |
| Quiet Step | Umbral | Stealth bonus while a Dark spell is active. |
| Sharp Seam | Forbidden Arts | +10% potency of Forbidden spells. |
| Quiet Mend | Forbidden Arts | -10% Aether Saturation gained. |
| Careful Hand | Forbidden Arts | Weave-scar decals fade 20% sooner. |

**Respec (Canon: always possible).** Free to level 10 and one free token at each class-tier change; otherwise a small gold fee scaled to the points refunded, at any Loom Shrine. Nothing is ever locked in.

## 8. Ascension trees

The advanced class change (rank C) opens an Ascension tree for the class: a free gate node, three notables (1 point each) and a keystone (2 points). Ascension points: 2 at the advanced change, 2 at rank A, 1 at the expert change. The 10 casting classes below have trees; the other advanced classes follow in a later pass.

| Advanced class | Gate | Notables | Keystone (gain / pay) |
|---|---|---|---|
| **Elementalist** (Mage) | Resonant Mind: Alternating two elements builds Resonance: +4% potency per stack, up to 5. | Dual Voice: Casting a spell of a different element than your last spell is 10% faster.; Reaction Scholar: Element reactions you trigger are 25% stronger.; Quick Pair: Release time between two different elements is 15% shorter. | **Convergence Seed**: Two different auras on a target can both trigger reactions. / Non-reaction spells are 20% weaker. |
| **Spellweaver** (Mage) | Glyph Hand: Quick-draw glyphs: your first thread change in a fight is free. | Wide Margins: +1 thread socket on one spell (up to your rank's cap).; Fair Copy: Shape threads have 10% less Strain.; Marginalia: One spell may carry two Shape threads. | **Open Margin**: +1 Loom slot. / Every spell has 1 fewer thread socket. |
| **Priest** (Cleric) | Ordained: +10 Hold and Devotion recovers 10% faster. | Gentle Hands: Mending spells are 15% stronger.; Hymn Keeper: Public Prayer has 20% less Strain.; Last Candle: Last-Rite Form is 25% stronger. | **Shepherd's Vow**: Mending and Ward spells also affect one more ally at 60%. / Those spells cost 25% more. |
| **Templar** (Cleric) | Sanctified Arms: Empowerment spells on weapons also add Light to your hits. | Hallowed Edge: Empowerment spells are 15% stronger.; Warding Verse: Ward spells on yourself are 10% stronger.; Smiting Chant: Light Strike spells are 10% stronger. | **Armed Faith**: Mending spells also deal Light damage. / Mending spells heal 30% less. |
| **Warlock** (Occultist) | Pact of Dark: Dark spells fill your Corruption Pool 15% more slowly. | Corrupt Reserve: +10 Hold.; Hex Tongue: Hex spells last 15% longer.; Hungry Shadow: Dark Strike spells restore a little HP. | **Debtor's Power**: Dark spells gain +40% potency. / At high Corruption you lose HP over time. |
| **Necromancer** (Occultist) | Grave Whisper: Pact summons last 15% longer. | Bone Reserve: +15 Hold.; Quiet Dead: Your summons make no noise and are harder to notice.; Hollow Hands: Dark Binding spells are 10% stronger. | **Unbroken Line**: Your Pact summons persist until slain. / They hold twice as much Hold. |
| **Summoner** (Tamer) | Many Contracts: +1 active Pact at once. | Kind Contracts: +10% chance a spirit accepts your call.; Shared Strength: Summons gain 10% of your spell potency.; Quick Call: Pact spells release 20% faster. | **Gate of a Hundred Spirits**: Temporary summons come in pairs. / Each summon is 25% weaker. |
| **Phantom Thief** (Rogue) | Light Fingers: Illusion and Mobility spells release 10% faster. | False Faces: Illusion spells last 20% longer.; Quick Exit: Mobility spells release 15% faster.; Borrowed Voice: You may copy the last spell an enemy cast at 40% strength. | **Calling Card**: Borrowed spells last twice as long. / Your spells cost 30% more. |
| **Skald** (Bard) | Verse Keeper: Empowerment spells held by Hold cost 10% less Hold. | Marching Meter: Empowerment spells are 10% stronger when cast on the beat.; Loud Voice: +10 Hold.; Steady Rhyme: Chants of Empowerment spells cannot be broken by Light hits. | **Anthem**: Your Empowerment spells reach the whole party. / They are 25% weaker. |
| **Diva** (Bard) | Stage Presence: Hex and Illusion spells are 10% stronger. | Soft Song: Hex spells that charm or calm last 15% longer.; Encore: Echo Form has 15% less Strain.; Sparkle: Light Illusion spells are 15% stronger. | **Grand Finale Seed**: Hex spells affect one more target. / They are 25% less potent. |

## 9. The curve from level 1 to 300

| Levels | Rank | What the player is learning |
|---|---|---|
| 1-3 | F | Learn the class's first spell. Cast it, watch the chant ring. No threads, no tree: the game teaches one idea at a time. |
| 3-8 | F | First Attunement point at level 3: pick a small node beside your class start. First thread socket on your first spell; a trainer teaches one shape thread. See Strain on the cost line. |
| 8-15 | F | Second spell; swap a thread out of combat at a camp. Free respec still on until level 10. Try one Frugal or Needlepoint thread. |
| 16-35 | E | Third spell slot and the first Hold. A Ward or a blessing now stays up. Second thread socket. Urgent versus Gentle calls teach that Bond spells can refuse. |
| 36-60 | D | Four spells and Power threads. A notable (2 points) is the first real choice. Spells reach proficiency 10 and the first Evolve or Fuse appears. |
| 61-90 | C | Advanced class change: the Ascension tree opens. Attune threads let a Fire spell carry an Ice aura, so reactions become a build, not an accident. |
| 91-165 | B-A | Trigger threads (react to a dodge, a parry, a stagger). Keystones come into reach. Builds now have a name: 'the Flash-Time Lancer', 'the Public Prayer cleric'. |
| 166-210 | S | Expert class. Grand spells (5 s chant) with four sockets. Imprint anything. The tree's trade-offs now define the character. |
| 211-300 | SS-SSS | Forbidden spells and Weave-light threads; Aether Saturation is the cost. The Divine rituals and the Master class close the Loom. |

## 10. Example builds

**Level 18 Mage (rank E: 3 slots, 2 sockets, Hold 20).** Loom: Cinder Fang with Needlepoint + Far Reach (Strain 1.15 x 1.10 = 1.27, chant 0.5 s); Rimefang Shard with Walking Cast (x1.25); Kindle Thread plain. Two Attunement points (level 18 gives 6): Kindled Voice and Banked Coals. Simple on purpose.

**Level 62 Elementalist (rank C: 4 slots, 3 sockets, Hold 60).** Glacier Lock (Intermediate, chant 1.5 s) with Needlepoint + Swift Chant + Potency: Strain 1.15 x 1.25 x 1.30 = 1.87, chant 1.5 x 0.7 = 1.05 s. Undertow Snare with Attune: Spark, so a Water hit carries a Lightning aura and starts Storm Prison (x1.25). Winterglass Shield with Anchored (x1.15, reserves 24 Hold instead of 30). Emberbrand Edge with Frugal (x0.80). The Ascension notable Reaction Scholar makes the reaction 25% stronger.

**Level 120 Priest (rank B: 5 slots, 3 sockets, Hold 80).** Hearth of Grace with Quiet Prayer (x0.90) and Lingering (x1.20); Sanctuary of Hands with Public Prayer (x1.40), Anchored (x1.15, Hold 24) and the trigger Reflex Ward (Hold 30): Strain 1.61, Hold 54 of 80; Morrow's Measure with Tether (x1.10); Mercy Flame with Steady Chant (x1.20). Keystone Unwavering Faith: refusals halve, Devotion costs 50% more.

## 11. Guardrails

- **No infinite loops.** Strain is multiplicative, sockets are capped by rank and tier, and Hold is a hard budget. The strongest build is the one that spends everything, not one that finds a free multiplier.
- **Every strength has a price.** Keystones carry downsides, Power threads raise Strain, Overcharge adds recoil, Forbidden spells add Aether Saturation.
- **Low levels stay simple.** Rank F has one socket and no Hold; the Loom grows as the player does. A reduced-complexity setting hides threads and suggests a default.
- **Respec is free to try.** A new build is never a trap; Canon section 5.
- **Hard limits hold.** No thread creates Aether, gold, a road to Earth, lasting will control or revival past the lantern. Trigger threads cannot trigger other triggers.
- **Readable in combat.** Threads change shape, sound and colour in the ways described in [[spell_look_and_feel]]; no thread adds a new telegraph colour.

## 12. Sources

Studied for mechanics only (a mix of wikis and community guides; some blocked automated access, so some points rest on search summaries):

- [Path of Exile: How do Skill Gems and sockets work? (Prima Games)](https://primagames.com/gaming/path-of-exile-how-do-skill-gems-and-sockets-work)
- [Skill Gems, the Help Panel (poedb)](https://poedb.tw/us/SkillGemBasics)
- [Support gem (Path of Exile Wiki)](https://www.poewiki.net/wiki/Support)
- [Item socket and links (Path of Exile Wiki)](https://www.poewiki.net/wiki/Link)
- [Gem tag (Path of Exile Wiki)](https://pathofexile.fandom.com/wiki/Gem_tag)
- [Path of Exile 2 Gemcutting Explained (VULKK)](https://vulkk.com/2025/03/10/path-of-exile-2-gemcutting-explained/)
- [Skill gem system (Mobalytics, Path of Exile 2)](https://mobalytics.gg/poe-2/guides/skill-gem-system)
- [Spirit guide (Maxroll, Path of Exile 2)](https://maxroll.gg/poe2/guides/spirit-guide)
- [Meta gem (Path of Exile 2 Wiki)](https://www.poe2wiki.net/wiki/Meta_gem)
- [Passive skill tree for beginners (Maxroll)](https://maxroll.gg/poe/getting-started/passive-skill-tree-for-beginners)
- [Ascendancy class (Path of Exile Wiki)](https://www.poewiki.net/wiki/Ascendancy)
- [All Path of Exile classes and ascendancy subclasses (Dot Esports)](https://dotesports.com/path-of-exile/news/all-path-of-exile-classes-all-poe-core-and-ascendancy-subclasses)

