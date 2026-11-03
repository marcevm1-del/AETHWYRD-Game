# -*- coding: utf-8 -*-
"""The Spell Loom: Aetheria's original spell-building and passive system (PROPOSED).

Inspired by mechanics studied in Path of Exile (gem sockets, support modifiers with cost multipliers, a budgeted
resource for persistent effects, trigger gems, a passive tree with keystones, ascendancy sub-classes). Only the
mechanical ideas are used. Names, numbers, text and structure here are original and fitted to Canon (12 base classes,
chant mastery, proficiency 1-10 with Evolve or Fuse, free respec, rank bands).
"""

# ----------------------------------------------------------------------------- Loom ranks (one row per rank)
# rank, loom slots, max thread sockets, hold budget, what unlocks
LOOM_RANKS = [
    ("F", 2, 1, 0, "Plain spells. One thread socket appears on your first spell. No Hold: persistent spells wait until E."),
    ("E", 3, 2, 20, "Third spell slot, second thread socket and your first Hold. Shape threads from trainers. Free respec of the tree ends at level 10."),
    ("D", 4, 2, 40, "Four spells. Power threads appear in trainer shops. Spells of Intermediate tier (1.5 s chant)."),
    ("C", 4, 3, 60, "Advanced class: Ascension tree opens and the third socket arrives. Attune threads (add an element aura)."),
    ("B", 5, 3, 80, "Fifth slot. Trigger threads (react to a dodge, a parry or a reaction). Advanced tier spells (3 s chant)."),
    ("A", 5, 4, 100, "Fourth socket. Keystones become reachable on the attunement tree."),
    ("S", 6, 4, 130, "Sixth slot. Expert class. Grand tier spells (5 s chant). Imprint any spell at proficiency 10."),
    ("SS", 6, 5, 160, "Fifth socket. Forbidden spells (8 s chant) and Weave-light threads; Aether Saturation matters."),
    ("SSS", 7, 5, 200, "Seventh slot. Master class and the Divine rituals. Everything the Loom can hold."),
]
SPELL_TIER_SOCKET_CAP = {"Basic": 3, "Intermediate": 4, "Advanced": 5, "Grand": 5, "Forbidden": 5, "Divine": 5}

# ----------------------------------------------------------------------------- threads
ELEM = ["AET", "FLM", "TID", "GAL", "STN", "FRS", "VRD", "RAD", "UMB"]
GROUPS = {"weave": ELEM, "bond": ["SPR"], "faith": ["DIV"], "frayed": ["FBD"]}
C_ALL = ["Strike", "Barrage", "Ward", "Binding", "Mobility", "Sensing", "Mending", "Empowerment", "Hex", "Illusion", "Pact", "Utility"]

# shape threads (the codex forms): name, group, strain, categories, min rank, effect
SHAPE = [
    ("Needlepoint", "weave", 1.15, ["Strike", "Binding", "Hex", "Sensing", "Mending"], "F", "Narrows the spell to a single point: half width, +20% range, no spread."),
    ("Sweeping Arc", "weave", 1.20, ["Strike", "Barrage", "Hex", "Ward"], "E", "Widens the spell to a 90 degree arc: triple width, -20% range."),
    ("Twin Cast", "weave", 1.30, ["Strike", "Barrage", "Binding", "Ward", "Mending", "Hex"], "D", "Casts two linked halves 1.5 m apart, each at 60% strength."),
    ("Spiral Form", "weave", 1.25, ["Strike", "Barrage", "Binding", "Illusion"], "D", "Rotates the pattern so it is harder to read, less stable to interruption."),
    ("Grounded Form", "weave", 1.10, ["Strike", "Barrage", "Binding", "Hex", "Ward", "Utility"], "F", "Keeps the spell low, following terrain and affecting footing."),
    ("Rising Form", "weave", 1.20, ["Strike", "Barrage", "Ward", "Mobility", "Sensing"], "D", "Angles the spell upward as a 5 m column for ledges and fliers."),
    ("Echo Form", "weave", 1.40, ["Strike", "Barrage", "Ward", "Mending", "Empowerment", "Sensing", "Illusion"], "C", "Repeats the spell 0.45 s later at 60% strength; the repeat can be interrupted."),
    ("Gentle Call", "bond", 1.00, C_ALL, "F", "A low-pressure request: the spirit has plenty of room to refuse and rarely takes offence."),
    ("Urgent Call", "bond", 1.25, C_ALL, "E", "Presses the request: faster answer, 130% brightness, but too many sour the bond."),
    ("Shared Guard", "bond", 1.20, C_ALL, "D", "Caster and spirit share the strain; any harm to one is felt by the other."),
    ("Guiding Path", "bond", 1.10, C_ALL, "E", "The spirit lays out a route of 5-7 lights instead of acting directly."),
    ("Warning Sign", "bond", 1.10, C_ALL, "E", "The spirit keeps watch and signals when something draws near."),
    ("Resonant Echo", "bond", 1.35, C_ALL, "C", "The working repeats twice at 70% and 40% strength, coloured by the spirit's memory."),
    ("Parting Form", "bond", 1.00, C_ALL, "D", "Releases the spirit with thanks and leaves a final gift as it goes."),
    ("Quiet Prayer", "faith", 0.90, C_ALL, "F", "A private appeal at half scale. Cheap, gentle, easily lost in noise."),
    ("Public Prayer", "faith", 1.40, C_ALL, "D", "Prays aloud for a group at x1.8 scale. Others in range add their own lights."),
    ("Vigil Form", "faith", 1.30, C_ALL, "D", "Holds the prayer over a long time (20 s). Ends when the caster tires."),
    ("Pilgrim Form", "faith", 1.15, C_ALL, "E", "The prayer travels with the caster, leaving footprints of light for 3 s."),
    ("Sanctuary Form", "faith", 1.35, C_ALL, "C", "Claims a small place as refuge, radius 2.5 m."),
    ("Oathbound Form", "faith", 1.30, C_ALL, "B", "Ties the prayer to a vow and one named person; stronger while the oath is kept."),
    ("Last-Rite Form", "faith", 1.20, C_ALL, "B", "Comfort and mercy at the end of a life, inside the narrow limits the world allows."),
    ("Needle Fold", "frayed", 1.20, C_ALL, "SS", "A hairline seam of space 2 m long. Precise and brief."),
    ("Wide Fold", "frayed", 1.45, C_ALL, "SS", "A broad 3 x 2 m sheet. Strains the Weave more."),
    ("Single Echo", "frayed", 1.25, C_ALL, "SS", "Draws out one echo of a recent moment at 50% strength."),
    ("Delayed Echo", "frayed", 1.30, C_ALL, "SS", "The echo arrives 0.8 s late at 35% strength."),
    ("Thin Edge", "frayed", 1.20, C_ALL, "SS", "A 0.03 m line of absence that unthreads small constructs."),
    ("Quiet Field", "frayed", 1.40, C_ALL, "SS", "A zone of radius 2.5 m where spellwork falters and colour drains."),
    ("Fracture Form", "frayed", 1.60, C_ALL, "SS", "9-12 jagged shards that scatter and reassemble. The greatest Weave damage."),
]
SHAPE_GROUP_NAME = {"weave": "Weave", "bond": "Bond", "faith": "Faith", "frayed": "Frayed"}

# power threads: name, strain, categories, disciplines (None = all), min rank, effect
POWER = [
    ("Potency", 1.30, ["Strike", "Barrage", "Hex", "Binding", "Mending", "Ward", "Empowerment"], None, "D", "+25% effect strength."),
    ("Frugal", 0.80, C_ALL, None, "F", "-10% effect strength, but the Strain is lower than 1."),
    ("Swift Chant", 1.25, C_ALL, None, "D", "-30% chant time."),
    ("Steady Chant", 1.20, C_ALL, None, "D", "Light hits no longer break the chant."),
    ("Lingering", 1.20, ["Ward", "Binding", "Hex", "Empowerment", "Illusion", "Utility", "Mending", "Sensing"], None, "E", "+40% duration."),
    ("Far Reach", 1.10, C_ALL, None, "E", "+30% range."),
    ("Focus", 1.15, ["Barrage", "Ward", "Mending"], None, "D", "-30% area and +25% effect strength."),
    ("Wide Weave", 1.20, ["Barrage", "Ward", "Mending", "Hex"], None, "D", "+35% area and -15% effect strength."),
    ("Chain", 1.30, ["Strike", "Hex", "Binding", "Mending"], None, "C", "Jumps once to a nearby target at 60% strength."),
    ("Piercing", 1.35, ["Strike", "Barrage"], None, "C", "Ignores 25% of the target's M.DEF."),
    ("Weave-light", 1.50, C_ALL, ["FBD"], "SS", "-50% Aether Saturation gained by the spell."),
    ("Quickened", 1.25, ["Strike", "Mobility", "Hex", "Binding", "Barrage"], None, "C", "-25% release and recovery time."),
    ("Overcharge", 1.50, ["Strike", "Barrage", "Hex"], None, "B", "+60% effect strength and +40% chant time. At 0 MP the recoil is 10% HP."),
    ("Anchored", 1.15, ["Ward", "Empowerment", "Pact", "Illusion", "Utility"], None, "D", "The spell holds 20% less Hold (persistent spells only)."),
    ("Tether", 1.10, ["Empowerment", "Mending", "Ward"], None, "C", "Also applies to one ally within 6 m."),
    ("Walking Cast", 1.25, C_ALL, None, "E", "You can move at half speed while chanting."),
]

# attune threads: element, discipline whose aura it adds, min rank
ATTUNE = [("Ember", "Fire"), ("Tide", "Water"), ("Gust", "Wind"), ("Stone", "Earth"), ("Rime", "Ice"), ("Thorn", "Nature"),
          ("Gleam", "Light"), ("Gloam", "Dark"), ("Spark", "Lightning"), ("Venom", "Poison")]

# trigger threads: name, trigger, hold, categories, min rank, effect
TRIGGER = [
    ("Reflex Ward", "when you are staggered", 30, ["Ward", "Mobility"], "B", "Casts the linked spell for you when you are staggered. 20 s cooldown."),
    ("Echo of the Dodge", "on a perfect dodge", 25, ["Strike", "Barrage", "Hex", "Binding", "Mobility"], "B", "Casts the linked spell during Flash Time after a perfect dodge."),
    ("Riposte Weave", "on a parry", 25, ["Strike", "Hex"], "B", "Casts the linked spell as part of the riposte."),
    ("Reaction Spark", "on an element reaction", 35, ["Strike", "Barrage", "Mending", "Hex"], "A", "Casts the linked spell whenever you trigger an element reaction."),
]

# ----------------------------------------------------------------------------- attunement tree
# per discipline: names for 6 small nodes, 3 notables (name, effect), keystone (name, effect, downside)
SMALL_STATS = [("potency", "+3% potency of {d} spells"), ("chant", "-2% chant time of {d} spells"), ("cost", "-2% MP cost of {d} spells"),
               ("reach", "+4% range and area of {d} spells"), ("hold", "+3 Hold"), ("duration", "+5% duration of {d} spells")]
TREE = {
    "AET": dict(label="Aethercraft", smalls=["Neat Strokes", "Quiet Frame", "Spare Lines", "Long Rule", "Tidy Reserve", "Steady Hold"],
        notables=[("Loomwright", "+1 thread socket on your first Loom spell (up to your rank's cap)."),
                  ("Clean Seams", "Shape threads on Aethercraft spells have 15% less Strain."),
                  ("Anchored Mind", "Light hits no longer break the chant of Aethercraft spells.")],
        keystone=("Fixed Pattern", "Shape threads cost no Strain.", "You cannot socket Power threads.")),
    "FLM": dict(label="Flamecraft", smalls=["Ember Focus", "Kindled Voice", "Banked Coals", "Far Sparks", "Hearth Reserve", "Slow Embers"],
        notables=[("Banked Embers", "Fire spells gain +10% potency for 3 s after another Fire spell."),
                  ("Kindler's Breath", "-10% chant time of Fire spells."),
                  ("Phoenix Habit", "Below 30% HP, Fire spells gain +20% potency.")],
        keystone=("Hungry Flame", "Fire spells gain +35% potency.", "Fire spells cost 25% more MP and scorch you for 1% HP at 0 MP.")),
    "TID": dict(label="Tidecraft", smalls=["Still Pool", "Patient Wave", "Fair Draught", "Long Tide", "Spring Reserve", "Slow Current"],
        notables=[("Patient Tide", "+15% duration of Water spells."),
                  ("Undercurrent", "Water Binding spells slow 10% more."),
                  ("Clear Water", "Water Mending spells are 10% stronger.")],
        keystone=("Deep Current", "Water spells chant 25% faster.", "Water spells have 15% less range.")),
    "GAL": dict(label="Galecraft", smalls=["Light Step", "Quick Breath", "Spare Wind", "Far Whistle", "Open Reserve", "Lasting Draft"],
        notables=[("Quick Hands", "-10% release time of all spells."),
                  ("Carried Voice", "+15% range of Wind spells."),
                  ("Unbroken Breath", "Wind spells ignore the first Light hit during a chant.")],
        keystone=("Open Sky", "All spells release 20% faster.", "You have 10% less maximum HP.")),
    "STN": dict(label="Stonecraft", smalls=["Set Stone", "Slow Voice", "Plain Cost", "Wide Ground", "Cellar Reserve", "Long Seam"],
        notables=[("Deep Roots", "Earth Ward spells are 15% stronger."),
                  ("Patient Hammer", "Earth Strike spells with chants of 1.5 s or more deal +10% damage."),
                  ("Slow Mountain", "You take 15% less damage while chanting an Earth spell.")],
        keystone=("Unmoved", "Light and Medium hits no longer break any chant.", "Movement speed is reduced by 15%.")),
    "FRS": dict(label="Frostcraft", smalls=["Clear Cold", "Hushed Voice", "Thrifty Frost", "Wide Drift", "Winter Reserve", "Long Frost"],
        notables=[("Quiet Winter", "+10% duration of Ice spells."),
                  ("Brittle Edge", "Ice spells deal +15% damage to slowed targets."),
                  ("Clear Breath", "-10% MP cost of Ice spells.")],
        keystone=("Stillness", "Ice spells gain +30% potency.", "Ice spells have 25% longer release time.")),
    "VRD": dict(label="Verdance", smalls=["Green Shoot", "Soft Murmur", "Thrifty Leaf", "Spreading Root", "Garden Reserve", "Long Bloom"],
        notables=[("Green Reserve", "+10 Hold."),
                  ("Rooted Calm", "Nature Mending spells are 12% stronger."),
                  ("Thorn Habit", "Nature Binding spells are 10% stronger.")],
        keystone=("Wild Growth", "+30% Hold.", "Nature spells cannot be cast while sprinting.")),
    "RAD": dict(label="Radiance", smalls=["Bright Start", "Clear Voice", "Spare Light", "Far Ray", "Dawn Reserve", "Steady Glow"],
        notables=[("Open Palm", "+10% potency of Light spells."),
                  ("Steady Dawn", "Light Ward spells last 15% longer."),
                  ("Prism Eye", "+25% range of Light Sensing spells.")],
        keystone=("Unveiled", "Light spells gain +25% potency.", "Enemies notice you from 30% farther away.")),
    "UMB": dict(label="Umbral", smalls=["Soft Footfall", "Muffled Chant", "Shaded Cost", "Long Hush", "Dusk Reserve", "Lingering Dim"],
        notables=[("Shaded Reserve", "-10% MP cost of Illusion spells."),
                  ("Long Shadow", "+15% duration of Illusion spells."),
                  ("Quiet Step", "Stealth bonus while a Dark spell is active.")],
        keystone=("Chosen Shadow", "Dark spells gain +25% potency.", "Light spells you cast are 50% weaker.")),
    "SPR": dict(label="Spiritbond", smalls=["Kind Word", "Soft Whistle", "Small Gift", "Open Field", "Shared Lantern", "Good Memory"],
        notables=[("Kind Voice", "+10% chance a spirit accepts your call."),
                  ("Shared Lantern", "+10 Hold."),
                  ("Patient Friend", "Refused calls recover 30% faster.")],
        keystone=("Open Hand", "+15 Hold and spirits accept your calls more often.", "Urgent Call threads cannot be socketed.")),
    "DIV": dict(label="Divine", smalls=["Quiet Vow", "Hushed Verse", "Small Offering", "Wide Circle", "Candle Reserve", "Lasting Light"],
        notables=[("Steady Vow", "Oathbound Form has 15% less Strain."),
                  ("Candle Keeper", "Devotion recovers 20% faster."),
                  ("Kind Hearth", "Divine Mending spells are 10% stronger.")],
        keystone=("Unwavering Faith", "Divine refusals are half as likely.", "Divine spells cost 50% more Devotion.")),
    "FBD": dict(label="Forbidden Arts", smalls=["Hairline", "Thin Voice", "Small Debt", "Long Seam", "Quiet Reserve", "Slow Scar"],
        notables=[("Sharp Seam", "+10% potency of Forbidden spells."),
                  ("Quiet Mend", "-10% Aether Saturation gained."),
                  ("Careful Hand", "Weave-scar decals fade 20% sooner.")],
        keystone=("Frayed Edge", "Forbidden spells chant 40% faster.", "Aether Saturation gained is doubled.")),
}
# class starts: class key -> start effect text
CLASS_START = {
    "swordsman": "+5% potency of Wind spells and spells cast through a weapon.", "guardian": "+5% strength of Ward spells.",
    "mage": "-3% chant time of all spells.", "cleric": "+5 Hold and +5% strength of Mending spells.", "rogue": "+5% duration of Illusion spells.",
    "ranger": "+4% range of all spells.", "tamer": "+5 Hold.", "artisan": "-3% MP cost of Utility spells.", "lancer": "+5% potency of Light Strike spells.",
    "martial_artist": "-3% release time of all spells.", "bard": "+5% duration of Empowerment spells.", "occultist": "+5% potency of Dark spells."}

# ascension (advanced class) trees for the casting-capable advanced classes: base class, gate, 3 notables, keystone
ASCENSION = {
    "Elementalist": ("mage", ("Resonant Mind", "Alternating two elements builds Resonance: +4% potency per stack, up to 5."),
        [("Dual Voice", "Casting a spell of a different element than your last spell is 10% faster."),
         ("Reaction Scholar", "Element reactions you trigger are 25% stronger."),
         ("Quick Pair", "Release time between two different elements is 15% shorter.")],
        ("Convergence Seed", "Two different auras on a target can both trigger reactions.", "Non-reaction spells are 20% weaker.")),
    "Spellweaver": ("mage", ("Glyph Hand", "Quick-draw glyphs: your first thread change in a fight is free."),
        [("Wide Margins", "+1 thread socket on one spell (up to your rank's cap)."),
         ("Fair Copy", "Shape threads have 10% less Strain."),
         ("Marginalia", "One spell may carry two Shape threads.")],
        ("Open Margin", "+1 Loom slot.", "Every spell has 1 fewer thread socket.")),
    "Priest": ("cleric", ("Ordained", "+10 Hold and Devotion recovers 10% faster."),
        [("Gentle Hands", "Mending spells are 15% stronger."),
         ("Hymn Keeper", "Public Prayer has 20% less Strain."),
         ("Last Candle", "Last-Rite Form is 25% stronger.")],
        ("Shepherd's Vow", "Mending and Ward spells also affect one more ally at 60%.", "Those spells cost 25% more.")),
    "Templar": ("cleric", ("Sanctified Arms", "Empowerment spells on weapons also add Light to your hits."),
        [("Hallowed Edge", "Empowerment spells are 15% stronger."),
         ("Warding Verse", "Ward spells on yourself are 10% stronger."),
         ("Smiting Chant", "Light Strike spells are 10% stronger.")],
        ("Armed Faith", "Mending spells also deal Light damage.", "Mending spells heal 30% less.")),
    "Warlock": ("occultist", ("Pact of Dark", "Dark spells fill your Corruption Pool 15% more slowly."),
        [("Corrupt Reserve", "+10 Hold."),
         ("Hex Tongue", "Hex spells last 15% longer."),
         ("Hungry Shadow", "Dark Strike spells restore a little HP.")],
        ("Debtor's Power", "Dark spells gain +40% potency.", "At high Corruption you lose HP over time.")),
    "Necromancer": ("occultist", ("Grave Whisper", "Pact summons last 15% longer."),
        [("Bone Reserve", "+15 Hold."),
         ("Quiet Dead", "Your summons make no noise and are harder to notice."),
         ("Hollow Hands", "Dark Binding spells are 10% stronger.")],
        ("Unbroken Line", "Your Pact summons persist until slain.", "They hold twice as much Hold.")),
    "Summoner": ("tamer", ("Many Contracts", "+1 active Pact at once."),
        [("Kind Contracts", "+10% chance a spirit accepts your call."),
         ("Shared Strength", "Summons gain 10% of your spell potency."),
         ("Quick Call", "Pact spells release 20% faster.")],
        ("Gate of a Hundred Spirits", "Temporary summons come in pairs.", "Each summon is 25% weaker.")),
    "Phantom Thief": ("rogue", ("Light Fingers", "Illusion and Mobility spells release 10% faster."),
        [("False Faces", "Illusion spells last 20% longer."),
         ("Quick Exit", "Mobility spells release 15% faster."),
         ("Borrowed Voice", "You may copy the last spell an enemy cast at 40% strength.")],
        ("Calling Card", "Borrowed spells last twice as long.", "Your spells cost 30% more.")),
    "Skald": ("bard", ("Verse Keeper", "Empowerment spells held by Hold cost 10% less Hold."),
        [("Marching Meter", "Empowerment spells are 10% stronger when cast on the beat."),
         ("Loud Voice", "+10 Hold."),
         ("Steady Rhyme", "Chants of Empowerment spells cannot be broken by Light hits.")],
        ("Anthem", "Your Empowerment spells reach the whole party.", "They are 25% weaker.")),
    "Diva": ("bard", ("Stage Presence", "Hex and Illusion spells are 10% stronger."),
        [("Soft Song", "Hex spells that charm or calm last 15% longer."),
         ("Encore", "Echo Form has 15% less Strain."),
         ("Sparkle", "Light Illusion spells are 15% stronger.")],
        ("Grand Finale Seed", "Hex spells affect one more target.", "They are 25% less potent.")),
}

SOURCES = [
    ("Path of Exile: How do Skill Gems and sockets work? (Prima Games)", "https://primagames.com/gaming/path-of-exile-how-do-skill-gems-and-sockets-work"),
    ("Skill Gems, the Help Panel (poedb)", "https://poedb.tw/us/SkillGemBasics"),
    ("Support gem (Path of Exile Wiki)", "https://www.poewiki.net/wiki/Support"),
    ("Item socket and links (Path of Exile Wiki)", "https://www.poewiki.net/wiki/Link"),
    ("Gem tag (Path of Exile Wiki)", "https://pathofexile.fandom.com/wiki/Gem_tag"),
    ("Path of Exile 2 Gemcutting Explained (VULKK)", "https://vulkk.com/2025/03/10/path-of-exile-2-gemcutting-explained/"),
    ("Skill gem system (Mobalytics, Path of Exile 2)", "https://mobalytics.gg/poe-2/guides/skill-gem-system"),
    ("Spirit guide (Maxroll, Path of Exile 2)", "https://maxroll.gg/poe2/guides/spirit-guide"),
    ("Meta gem (Path of Exile 2 Wiki)", "https://www.poe2wiki.net/wiki/Meta_gem"),
    ("Passive skill tree for beginners (Maxroll)", "https://maxroll.gg/poe/getting-started/passive-skill-tree-for-beginners"),
    ("Ascendancy class (Path of Exile Wiki)", "https://www.poewiki.net/wiki/Ascendancy"),
    ("All Path of Exile classes and ascendancy subclasses (Dot Esports)", "https://dotesports.com/path-of-exile/news/all-path-of-exile-classes-all-poe-core-and-ascendancy-subclasses"),
]
