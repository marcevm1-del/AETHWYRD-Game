# -*- coding: utf-8 -*-
"""Extra sentence variety, merged into the banks in data_core at import time."""
from data_core import USE, DISCIPLINES

USE["Strike"] += [
    "Practitioners drill it until the aim becomes instinct, because a single clean hit is worth more than a dozen hurried ones.",
    "It is honest about what it is: one target, one moment and no second chance if the opening closes.",
    "Against armoured foes it asks for patience, and against lightly protected casters it asks only for speed.",
    "Its real cost is attention, since the caster must watch the target as closely as the target watches them.",
]
USE["Barrage"] += [
    "It is as much a statement as an attack, telling everyone in range that this ground now belongs to the caster.",
    "Battle mages stagger it with other effects, so that one wave drives the enemy into the path of the next.",
    "Allies must learn its reach, because a barrage cast in anger does not check who is standing at the edge.",
    "It shines at chokepoints, bridges and stairwells, where the enemy has nowhere to go but through it.",
]
USE["Ward"] += [
    "A good ward is judged by the damage it never lets through, which means its best work is usually unseen.",
    "It asks the caster to stand still and trust it, a harder thing than it sounds in the middle of a fight.",
    "Veterans cast it early and keep it small, since a modest shield held well beats a grand one dropped halfway.",
    "It cannot protect everyone at once, so each casting is also a choice about who matters most in that moment.",
]
USE["Binding"] += [
    "It is most useful when paired with a patient striker, since the bound enemy must still be dealt with.",
    "Seasoned casters aim for the weapon arm or the feet, never the whole body, because a small target holds longer.",
    "It does not demand obedience, only delay, which is exactly the commodity a losing fight is short of.",
    "It leaves the target's eyes, ears and voice unbound, so a restrained foe can still call for help.",
]
USE["Mobility"] += [
    "It is a spell of timing, and the best casters rehearse their routes on quiet days so that panic never chooses for them.",
    "Done well it looks like nothing at all, a lucky stumble that happens to land exactly where it should.",
    "Its enemy is gravity and its ally is footing, so a clear patch of ground makes all the difference.",
    "It trades safety for speed, and every casting is a small bet that the landing will be there.",
]
USE["Sensing"] += [
    "It is the quiet half of every good ambush, and the half that decides who springs it.",
    "Trackers pair it with patience, because the first reading is a rumour and the third is a fact.",
    "What it shows can be wrong or old, so careful casters ask it a narrow question and trust a narrow answer.",
    "It costs the caster their own watchfulness for the moment, leaving them a little blind to everything else.",
]
USE["Mending"] += [
    "It works best in the quiet after a fight, when the patient can rest and the healer can pay attention.",
    "Healers prize it for its gentleness, since a kind touch often matters more than a clever one.",
    "It cannot hurry the body past what it can bear, and wise healers stop when the patient's strength says stop.",
    "It leaves the wound, the cause and the lesson exactly where they were, and only eases the walk between them.",
]
USE["Empowerment"] += [
    "It is a small bet on a friend, and it pays best when the friend is already good at what they are about to do.",
    "Timing matters more than strength: a gift given a breath too early is wasted, and one given a breath too late is a eulogy.",
    "It never makes a coward brave or a novice a master, but it can turn a steady hand into an excellent one.",
    "Because it fades, it teaches teams to coordinate, and the best groups chant it in the same breath that they charge.",
]
USE["Hex"] += [
    "It is cheap for what it takes away, which is the whole reason casters love it and enemies hate it.",
    "Its best use is early in a fight, when a small penalty compounds over every action that follows.",
    "A cautious caster layers it behind a frontline so the enemy never learns where the trouble began.",
    "It does not need to land hard, only to land at the right moment, and it works best on those who are already worried.",
]
USE["Illusion"] += [
    "It lives in the gap between what is seen and what is expected, so it works best against those who stopped looking closely.",
    "Its great weakness is the stranger who has never read the room and therefore notices what is out of place.",
    "Experts add one small imperfection on purpose, since a flawless trick is more suspicious than a slightly sloppy one.",
    "It buys seconds, and a clever caster knows exactly what to do with them before the spell ends.",
]
USE["Pact"] += [
    "It rewards those who keep small promises, and spirits and gods keep careful count of promises kept.",
    "Casters who treat the call as a transaction find the help thin, and those who treat it as friendship find it deep.",
    "It cannot be spammed, since every request spends a little goodwill that has to be earned back.",
    "The help is rarely what the caster pictured, and the best casters learn to be glad of what arrives.",
]
USE["Utility"] += [
    "Experienced travellers keep one prepared for every night on the road, because small comforts decide long journeys.",
    "It is the sort of working that nobody writes songs about and everybody relies on.",
    "Used well it saves a fight, a night or an afternoon, which is more than most flashy spells can claim.",
    "Apprentices are taught it first and masters never stop using it, which says everything about its worth.",
]
# fix an awkward phrase in the base bank
USE["Hex"] = [s.replace("A hex stacked with a good timing", "A hex stacked with good timing") for s in USE["Hex"]]

_VIS_EXTRA = {
    "AET": ["Faint grid lines flicker over nearby surfaces for a heartbeat, as if the world were briefly drawn on graph paper.",
            "The silver threads pull tight with a soft hum, then relax into a slow, even glow."],
    "FLM": ["Gold-white sparks swirl up the length of the effect and burst into small, short-lived stars.",
            "The edges glow like cooling iron, shading from white to orange to a deep, soft red."],
    "TID": ["Droplets rise from the effect and hang in the air like a spray of glass beads before falling.",
            "The surface shimmers with passing clouds and light, as if it were a pond seen from above."],
    "GAL": ["Streamers of pale mist peel from the effect and stretch into long, bending lines.",
            "A brief hush follows the gust, and every loose leaf and scrap of cloth settles at once."],
    "STN": ["A hairline crack of amber light runs along the effect and seals again with a quiet click.",
            "Pebbles roll toward the heart of the effect and stack themselves neatly as it fades."],
    "FRS": ["A fine haze of ice dust glitters in the air and drifts down in slow, silent sparkles.",
            "Every edge is rimmed in white, and the shadows beneath the effect turn a pale, cold blue."],
    "VRD": ["Tendrils twist toward the light and nod gently, as if the plants were listening.",
            "A scent of cut grass and warm earth drifts out, strongest where the growth is thickest."],
    "RAD": ["A gentle halo rings the effect, and nearby faces look briefly softer and clearer.",
            "Hard white sparkles glint along each edge and ripple through the colours like sun on water."],
    "UMB": ["The edges are stitched with the faintest silver thread, visible only from the corner of the eye.",
            "Footsteps go quiet nearby, and the dark seems to lean in as if curious."],
    "SPR": ["Small glimmers of light blink on and off in answer, like a conversation conducted in sparks.",
            "Where the spirit passes, grass bends and ripples shiver, though no wind moves."],
    "DIV": ["A hush settles over the area, and for a moment every sound seems to be listening.",
            "Faint ribbons of warm light curl around the supplicant's hands and fade as the prayer ends."],
    "FBD": ["The edges of the effect stutter, repeating themselves a fraction of a second late.",
            "A faint metallic taste fills the air, and nearby shadows seem to point the wrong way."],
}
for _d in DISCIPLINES:
    _d["vis"] += _VIS_EXTRA[_d["code"]]
