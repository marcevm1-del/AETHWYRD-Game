# -*- coding: utf-8 -*-
"""Hand-written text for the 50 vertical-slice spells.

name -> (description, visual design, how it works, signature moment).
Each of the first three is 50-100 words. They obey the magic laws: no free Aether, no lasting gold,
no revival past the lantern, no Status rewrite, no road to Earth, no lasting mind control.
"""
T = {}

# ------------------------------------------------------------------ Aethercraft
T["Skypiercer Lance"] = (
    "A needle of compressed mana fired along the caster's line of sight to punish a chanting enemy in mid-sentence. It is the first attack every Aethercrafter learns to trust: precise, quick and narrow, built to break a chant rather than to break armour. Against a plated knight it barely scratches, but a mage who has just drawn breath will lose the whole spell. It cannot turn corners and gives out at mid-range.",
    "A cyan beam no thicker than a finger leaves two raised fingertips and crosses the field in a straight, dead-level line. Silver rings spiral off its tail like ripples on a drawn wire, each one fading a half-second behind the last. Where it ends, a single hard indigo spark flashes and a faint hexagon of light lingers on the target's chest for one breath, marking exactly where the chant broke.",
    "The caster squeezes mana along their line of sight into a high-pressure filament and releases it in one clean motion. The tighter the focus, the harder the interruption lands, but the filament loses force beyond mid-range and cannot bend around cover. The cast needs a full chant and an unbroken view, so being staggered or losing sight of the target ruins it. A rival Aethercrafter can blunt it by raising any plane in its path.",
    "The tail rings snap together into a single silver dot a heartbeat before impact, then bloom outward as the target's chant shatters.")

T["Aegis Arc Bulwark"] = (
    "A curved plane of solidified mana that stands before the caster and absorbs blows from one direction until its structure fails. It is the frontline Aethercrafter's signature defence: wide enough to cover a doorway, strong enough to stop a charging boar, and honest about being temporary. Allies may shelter behind it, but only on the side it faces. Heavy or repeated strikes crack it, and it never protects a flank.",
    "A semicircular shield of layered indigo glass unfolds in the air, each layer a slightly different shade so the surface looks deep. Every impact sends a ripple across it like rain on still water, brightest at the point of contact. As it weakens, hairline cracks of white light spread from the ripples, and at the end it breaks into sixteen shards that hang for a moment before fading to silver dust.",
    "The caster folds mana into a taut convex membrane and braces it against the incoming force, which spreads across the curve and bleeds into the Weave. Rounding the plane makes it strong against one direction and useless against any other. The shield holds only as long as it keeps its shape and the caster keeps their focus; a stagger drops it at once, and force beyond the pattern's tolerance shatters it like glass.",
    "On break the sixteen shards rise rather than fall, drifting upward for half a second as if the pattern were exhaling.")

T["Fatestring Tether"] = (
    "A taut filament of mana that joins two visible points and carries tension between them. It can pull the caster toward an ally, hold a falling crate, restrain a stumbling enemy or carry a spoken signal along its length. It is a restraint and never a leash: a struggling Status-bearer can strain it to the snapping point, and it holds nothing for long. Used on a wall or a rooftop, it becomes a way across.",
    "A hair-thin silver line stretches from the caster's open palm to the chosen point, nearly invisible until it catches the light. When tension changes it hums a soft chime that rises in pitch as it tightens. Under strain the line thickens and glows from silver to pale cyan, with tiny beads of light sliding along it toward the strongest pull, and at the limit it snaps with a bright, clean flash.",
    "The caster fixes both ends and sets a maximum tension into the pattern. Pulling harder than that limit snaps the line cleanly rather than stretching it, which makes it safe for people and dangerous only to the plan. It can carry a short message, but only along its length. The tether needs a clear line between its anchors, breaks if either anchor moves out of reach, and dies at once when its caster is staggered.",
    "At the snapping limit the line sings one clear note that drops an octave as it breaks, so every ally knows the instant it let go.")

T["Truesight Lens"] = (
    "A rotating lens of bent mana that opens before the caster's eye and exposes concealed magic: glamours, hidden runes, disguised enchantments and the residue of recent spellcasting. It reveals magical traces, not lies. A forged document, a clever disguise made of makeup or a confident actor passes through untouched. Skilled casters read the distortion like handwriting and can often tell who cast a pattern and roughly when.",
    "A cyan iris spins open in the air before the caster's face, ringed by thin silver spokes. Through it, the world dims by about a seventh and every trace of magic glows with a false-colour outline: warm amber for fresh work, cool violet for old. Hidden runes shimmer on walls, and glamoured faces show a faint seam at the jaw. The lens makes a clear, soft ticking like a clock.",
    "The caster bends ambient mana around one chosen subject so that any disturbed pattern diffracts differently from its surroundings. Fresh castings glow brighter, old ones fade, and layered glamours show as stacked outlines. The lens can focus on one subject at a time and costs the caster their own peripheral vision while it holds. It does not read minds, intentions or lies, and a counter-pattern designed to look natural can slip through.",
    "When the lens finds a hidden rune it clicks once, and the rune's outline blooms into a full silver sigil that stays for two seconds.")

# ------------------------------------------------------------------ Flamecraft
T["Cinder Fang"] = (
    "A compact ember flicked at a single target, hard enough to sting and hot enough to ignite anything dry it lands on. It is the first spell a young Flamecrafter learns and the one veterans never stop using: cheap, quick and exactly as dangerous as the fuel around it. On bare wet stone it is a spark; in a haystack it is a disaster. It leaves a brief trail of sparks that makes its path obvious to anyone watching.",
    "A teardrop of orange flame, no larger than a thumb, leaves the caster's fingers with a crack like a snapped twig. It flies in a steady arc, shedding a thin trail of gold sparks that wink out one by one. On impact it bursts into a short splash of ember-coloured light and a small cone of smoke, leaving a faint scorch mark the size of a coin that smoulders for three seconds.",
    "The caster draws mana into the fuel already present, such as the oil in a wick, the dry grass or the caster's own breath, and shapes it into a dart of heat. Combustion needs air and something to burn, so the spell gutters underwater, in heavy rain and in a sealed room. It ignites dry material on contact, which can spread to allies if the caster is careless. Being staggered snuffs the chant before the flame forms.",
    "The first spark it sheds always lands at the target's feet a moment before the ember itself, like a warning that arrives too late.")

T["Dragon Maw Breath"] = (
    "A broad cone of flame driven ahead of the caster, strongest at arm's length and thinner with every metre. It is the Flamecrafter's answer to a crowd: it clears a stairwell, scatters a pack and burns a row of bandages off a door. It is also slow to gather, loud, and tells the enemy exactly where the caster stands. Wind turns it back, rain weakens it, and a clever foe simply steps out of its width.",
    "The caster opens both hands like jaws and a roaring cone of white-gold flame fans out, deepening to orange and then to ember red at the edges. Heat shimmer bends the air in front of it into rippling lenses. Sparks pop in the rhythm of a heartbeat, soot drifts upward in ribbons, and the ground beneath the cone glows briefly like cooling coals before darkening to a scorched ring.",
    "The caster gathers mana into a large volume of available fuel and air and releases it forward in a fan. The first moment is the hottest; the flame thins as it spreads and gutters in the wind. Because it burns oxygen, the spell is weaker in closed rooms and fails entirely underwater. It burns everything in its width, friend or foe, scorches the ground, thins the local Aether with heavy use and breaks if the caster is staggered.",
    "For one frame the cone's centre goes dead white, then the colour floods outward like a lit fuse, and the sound arrives a heartbeat later.")

T["Emberbrand Edge"] = (
    "A controlled glow wrapped around an ally's weapon or armour that adds a measure of heat to every contact. Blades hiss as they cut, shields scorch what strikes them and frost melts off a spear tip. It does not make a weapon sharper or an ally braver, and it burns out when the mana does. Careless smiths wince at it; careful ones ask for it before a winter patrol.",
    "A thin edge of orange light runs along the weapon from guard to tip, steady and bright, with a few embers peeling away and rising. The metal takes on a soft glow like cooling iron, shading from white near the hilt to deep red at the point. When the weapon strikes, a short flare of sparks follows each cut. As the effect ends, the glow fades over two seconds with a long, soft tick.",
    "The caster presses mana into the weapon's own metal and shapes it into a steady heat that rides along the edge. It adds warmth to contact, not damage on its own, and it does nothing to weapons that cannot hold heat, such as wood or bone. It lasts a short while, cannot be stacked indefinitely, and ends the moment the caster loses focus. Fire-resistant targets shrug it off, and water or heavy rain dampens it.",
    "On the first strike each cut leaves a bright after-line in the air that holds for one frame, like a chalk mark drawn by the blade.")

T["Soot Phantom"] = (
    "A smoky decoy silhouette that steps out of the caster and repeats one simple movement before drifting apart. It draws a glance, a shot or a lunge, and buys the caster a heartbeat to move. It is made of soot and heat haze, not a living soul, and anyone who looks closely sees the emptiness behind the mask. Spirits and high monsters are not fooled at all.",
    "A dark, wavering outline of the caster slides out of their shoulders in black smoke edged with ember orange. The phantom's face is blank, its outline blurred like a charcoal smudge, and its feet leave no prints. As it moves, it sheds soot flakes that glow orange for a moment and darken. When struck, it bursts into a puff of ash and a small shower of dying sparks.",
    "The caster shapes smoke and heat into a loose shell and gives it a short movement loop to repeat. Any contact disrupts the pattern, and the phantom scatters at once. It fools sight and sometimes hearing, but not smell, touch or beings that sense souls. The decoy needs soot or smoke to form and does poorly in clean, wet air. Staggering the caster while it forms leaves only a grey cough of ash.",
    "When it breaks, the ash holds its shape for a single frame, so the player sees the decoy's silhouette in grey before it falls apart.")

# ------------------------------------------------------------------ Tidecraft
T["Breakwall Surge"] = (
    "A rolling wall of water driven across the ground, strongest on a slope or beside a source. It sweeps feet from under a crowd, carries loose gear away and douses small fires in its path. It does not cut and it does not drown; it shoves and tires. Without water nearby it is a puddle, and against a braced shield wall it only gets everyone wet.",
    "A broad crest of sea-green water rises waist high and rolls forward with a white foam edge, glass-clear in the middle where the light passes through. Droplets spray ahead of it like scattered pearls, and the front folds over itself in a slow curl. Behind it the ground shines wet and dark, and a low rush of surf fades into trickling streams.",
    "The caster draws water from a nearby source and pushes it outward in a single heavy mass. The wave gains weight on a slope, loses it on level ground and hits hardest in the first few metres. It is slow to build and slow to stop, so it favours open lanes over tight corridors. A dry battlefield leaves almost nothing to work with. Staggering the caster collapses the wall into harmless runoff.",
    "For half a second the wave holds its curl at the top, a frozen green arch, and the whole crowd glances up before it falls.")

T["Undertow Snare"] = (
    "A pull of water around an enemy's legs that spoils balance without touching the mind. The target can still speak, think and fight, but their feet no longer go where they want. It works best on a wet floor, a riverbank or a shore. A strong enough target strides out of it, and any heat that boils the water ends it.",
    "A loop of dark teal water curls up from the ground and wraps around the target's ankles like a ribbon, tightening in a slow spiral. White foam traces the edge and tiny bubbles stream upward. When it pulls, a short, heavy gulp sounds and the water darkens, and when it breaks, the loop falls apart in a splash of bright droplets.",
    "The caster draws water that is already present and tightens it around the target's legs, trading speed for weight. It slows movement and spoils footing for several seconds; it does not hold the target in place and does nothing to flyers. Freezing cold turns it brittle, fire boils it away, and a sharp pull from a strong target snaps it. A stagger ends the chant before the water answers.",
    "A tiny whirlpool spins open in the ground at the moment it grips, so the player can see which foot is caught.")

T["Foamstep Cushion"] = (
    "A brief cushion of froth beneath a falling ally or a jumping caster. It softens a drop from a rooftop, a rough landing on cobbles or a leap into the unknown. It does not stop a fall from any height; it turns a bruise into a shrug. Without water nearby it still works, thinly, on dew and damp.",
    "A burst of bright white foam blooms under the caster's boots with a soft, wet pop, rising like a small cloud before settling into a ring of bubbles. Each bubble catches a sliver of rainbow before it bursts. The caster lands in the middle with a gentle bounce and a splash of droplets that fall in a neat, glittering circle around them.",
    "The caster gathers whatever water and air are at hand, even the dampness of the air, and whips it into a thick foam beneath the landing point. The foam spreads the impact over a longer moment, reducing it sharply but not removing it. It lasts only a few seconds and must be placed before the fall. A long drop still hurts, and a staggered caster gets only a damp puff and a hard landing.",
    "The caster's landing sound is a soft chime rather than a thud, and the bubbles pop in a quick descending run like keys on a xylophone.")

T["Raincall Veil"] = (
    "A local shower called from moisture in the air, useful for cooling a forge, hiding a footprint, feeding a garden or putting out an ember. It will not flood a room or end a drought. It rains where the caster says, for as long as there is something to rain, and it fades when the air runs dry.",
    "A fine curtain of rain falls in a shimmering column about three metres wide, each drop catching the light as a thin silver streak. Mist rises where the drops hit, and the air smells of wet stone. Inside, sounds soften and edges blur a little. When the rain stops, a faint sheen of dew remains on every surface for a few moments.",
    "The caster gathers existing moisture into a local cloud and releases it as steady rain. It cools surfaces, washes away fresh tracks, dampens fire and softens dust, but cannot produce water that was not already in the air. A dry desert gives a thin drizzle at best. The spell holds as long as the caster keeps their focus and breaks if they are staggered, leaving a few last drops.",
    "In the last second the rain slows to single drops that fall in perfect rhythm, like a clock winding down.")

# ------------------------------------------------------------------ Galecraft
T["Razorwind Blade"] = (
    "A compressed edge of air that cuts soft material at close range and hisses along a rope. It is quick and quiet, and it loses its edge fast with distance. A canvas sack, a leather strap or an unarmoured sleeve parts easily; plate armour does not notice. It gives no light and no warning beyond a thin whistle, which is why wary opponents listen for it.",
    "A pale crescent of air flicks from the caster's hand, visible only as a bright streak of silver-white and a distortion like heat haze. It leaves a thin white line in the air that fades in a heartbeat. Leaves and loose threads in its path split cleanly in half. A short, high whistle sounds as it passes, then a tiny snap as it hits.",
    "The caster compresses air into a narrow cutting current and releases it in a single line. The edge is sharpest in the first few metres and softens quickly, so the spell rewards closing the distance. It scatters in a crosswind and does nothing in still, heavy air. It cuts soft things, not armour, and breaks if the caster is staggered during the chant, leaving only a gust.",
    "The whistle is always a perfect fifth above the caster's chant, so veterans can hear a Razorwind coming in the middle of a crowd.")

T["Tempest Fan"] = (
    "A broad gust fanned outward to scatter light debris, snuff small flames and break a loose formation. It does not wound; it disorders. Banners fly, hats go, a row of archers loses their aim. It is the Galecrafter's way to take a battlefield apart without drawing a blade, and the first half of the famous Firestorm when it meets flame.",
    "The caster sweeps an arm and a wide fan of pale green-white wind opens in a half circle. Leaves, dust and cloth lift and stream outward in long curling lines, and the air itself shows faint silver streaks like brushstrokes. A deep rushing roar swells and falls, and for a heartbeat every flame nearby leans away from the caster before springing back.",
    "The caster pushes air outward through a wide arc, trading force for width. The gust is strongest within a few metres and fades toward the edge. It spreads any fire or element carried in the air, which makes it dangerous near flame and valuable with the right partner. It cannot move anything heavy, loses to a stronger wind and breaks when the caster is staggered, leaving only a stray breeze.",
    "When it meets a fire aura the fan's silver lines turn orange and curl into a spinning column, which is how the whole party learns a Firestorm has begun.")

T["Zephyr Flash Step"] = (
    "A sudden burst of lateral movement that carries the caster a few strides through clear air in a heartbeat. It dodges a blow, closes a gap or crosses a gap that was one stride too wide. It needs open footing at the end and does not grant flight. The faster it is cast, the less control the caster has over where they stop.",
    "A pale ripple of wind wraps the caster's legs and they blur sideways, leaving three silver afterimages that fade in quick succession. A long streak of white-green light trails behind, and loose leaves spin in the wake. The caster stops with a short skid and a puff of dust, and the afterimages dissolve into a few scattered motes that sink to the ground.",
    "The caster pushes a sudden gust behind their own body and rides it, timing the release to a single stride. The distance is short and the destination must be clear, since the burst stops only when the wind does. It cannot carry a heavy pack far, fails in still enclosed rooms and breaks if the caster is staggered. It is the fastest release in the codex and the easiest to mis-time.",
    "The third afterimage lingers a half-beat longer than the others and points exactly where the caster started, like an arrow home.")

T["Vacuum Hollow"] = (
    "A momentary thinning of the air in a small space that snuffs flame and swallows sound. It never suffocates a person; it steals a candle's light and an enemy's shout. Mages use it to silence an alarm, quench a torch or take the roar out of a fire. Anyone standing in it simply feels a strange pressure and a soundless moment.",
    "A softly shimmering sphere about a metre wide pulls inward, bending the light around it so the background looks slightly pinched. Dust spirals toward its centre and vanishes. All sound dims inside it, replaced by a low, hollow hum that drops in pitch. When it ends, a gentle outward puff releases the dust and the air rushes back with a single soft thud.",
    "The caster draws air out of a small chosen volume for a moment. Fires inside go out and sound cannot carry, but a person inside is never harmed beyond a brief, uncomfortable pressure. The hollow needs a bubble of calm air to work in and collapses in wind or a staggered chant. It cannot be held on a moving target and does nothing at all in open, windy places.",
    "As it closes, every sound that was muffled inside plays back at once in a quick, overlapping rush, a half second of everything caught up.")

# ------------------------------------------------------------------ Stonecraft
T["Quarry Fist"] = (
    "A compact mass of stone drawn from nearby rock and driven forward as a blunt projectile. It is heavy, loud and slow to prepare, and when it lands it stops people and doors alike. It needs stone, sand or hard earth nearby, shows no mercy to the caster's own footing and gives the whole battlefield a long moment to see it coming.",
    "A fist-sized, angular lump of grey stone tears free from the ground with a crack and a spray of dust, glowing faintly along an amber seam. It hangs for a moment, then drives forward with a low grinding roar, trailing gravel and dust. On impact it bursts into jagged chunks that tumble and settle, leaving a crater and a dull, ringing echo.",
    "The caster persuades available rock to leave the ground and shapes it into a heavy mass, then pushes it along a straight path. The wind-up is long and the flight slow, so a watchful target can step aside, but anything it catches takes the full weight. It needs stone, sand or compacted earth within reach and does little on a wooden floor. A stagger drops the stone where it stands.",
    "The stone hangs one beat too long before it flies, and the whole screen's dust settles upward toward it as if the ground were holding its breath.")

T["Bastion Rise"] = (
    "A short wall raised from existing earth to break line of sight or stop a rushing enemy. It is a Stonecrafter's favourite on narrow roads: three seconds of work for an hour of safety. It cannot be moved once raised and will not hold against a siege engine. When the mana is spent the wall crumbles to rubble, which remains as an obstacle for a while.",
    "The ground grumbles and cracks, and a slab of ochre stone climbs out of it in a slow, heavy push, shedding dust and loose gravel. Amber light runs along its seams as it settles with two bounces, then dims. Fine dust rings spread outward on the ground. When it fades, the wall crumbles from the top down into a pile of rounded rubble.",
    "The caster draws on available soil and rock and shapes it into a low wall, setting its height and length by how much material is near. It blocks sight and soft pushing, holds against ordinary blows and fails against anything that can crack stone. The wall stands for a short while and then falls apart. It needs solid ground, cannot be raised on water or ice, and a stagger leaves only a lumpy mound.",
    "The wall's last act is a slow, deliberate crumble from the top, and the rubble it leaves stays put long enough to trip a pursuer.")

T["Crystal Ear"] = (
    "A way to read the vibrations in connected stone and detect nearby movement. A foot on a cobbled road, a cart on a bridge or a creature tunnelling beneath the cellar all speak through the rock. It shows where and how heavy, not who. In wet marsh or loose sand it hears almost nothing, and loud mining nearby drowns it out.",
    "The caster presses a palm to the ground and a ring of faint amber light spreads outward in a slow pulse. Where something moves, a small crystalline glint answers, brighter for heavier weight. Dust dances on the surface in tiny patterns, and a low, steady hum rises from the stone. When the spell ends, the glints fade one by one like stars at dawn.",
    "The caster connects their own mana to the surrounding stone and listens for disturbances, translating them into a rough map of weight and speed. It works only through solid, connected rock, shows movement and not identity, and loses sharpness with distance. Loud noise, soft soil and the caster's own stagger ruin the reading. It is quiet, tiring and the best early warning a patient caster can have.",
    "Each glint appears with a soft chime whose pitch drops as the weight rises, so a heavy footfall sounds like a low bell in the dark.")

T["Gravelswarm Skitter"] = (
    "A low stream of pebbles sent skittering across the floor to disrupt footing. It trips runners, jams the hinge of a door and makes a sprint across a courtyard a gamble. It deals no damage of its own. It works on any hard floor with loose stone, and it is entirely wasted on soft grass.",
    "A handful of grey pebbles leaps from the caster's palm and scatters across the ground, clicking and rattling like a startled flock. They glint with amber specks and spread in a widening fan, bouncing off one another. Dust puffs up where they land, and after a few seconds they stop in loose, untidy drifts that crunch underfoot.",
    "The caster flicks a small amount of loose stone along the ground and gives it a push that carries it a dozen metres. The stones disrupt footing and make fast movement risky, but they cannot hold a person and are easily stepped over by a careful one. The effect is strongest on smooth hard floors and weakest on grass. Staggering the caster leaves only a rattle.",
    "The pebbles all stop at the same instant on the last click, and the sudden silence tells every runner to look down.")

# ------------------------------------------------------------------ Frostcraft
T["Rimefang Shard"] = (
    "A small ice shard formed from nearby moisture and sent to a single target. It is brittle, bright and unmistakable, and it shatters on impact into frost that chills for a few moments. On a damp day it is quick to make; in a dry desert it barely exists. It cuts soft things and bruises armour, and the cold it leaves is more annoying than dangerous.",
    "A hexagonal spear of pale ice-blue crystal grows in steps from the caster's fingers, each step a visible click, and then launches at full speed. It trails a thin mist of frost and a faint ringing note. On impact it shatters into dozens of glittering shards that hang for a second, ringing like tiny bells, and a rime of white fern spreads across the target.",
    "The caster draws heat out of the moisture in the air and freezes it into a shard, shaping its edge with careful focus. The shard grows slowly and flies fast. It needs moisture to form, is weak in dry and hot places, and breaks if it strikes something hard enough. The cold it leaves is shallow, and thick clothing or fire shrugs it off. A stagger leaves only a puff of frost.",
    "The shard grows in four distinct stop-motion steps and then, on release, moves at the full speed of the sky with no in-between.")

T["Glacier Lock"] = (
    "A sheet of ice that freezes a wet surface around an object or a foot and holds it in place until the ice is broken. It does not freeze a person solid; it pins them. A heavy blow or a hot flame frees them, and a strong enough target simply tears free. On a dry floor it needs moisture the caster must bring.",
    "A white-blue crust races outward from the caster's palm across the ground, crackling as it grows in branching, feathered lines. It climbs the target's boots in a slow, glittering wrap and thickens into a clear, faceted shell with a violet tint at its core. A sharp icy click marks the lock, and the air near it turns still and bright.",
    "The caster pulls warmth from the moisture around the target and freezes it into a clamp that holds the object or foot in place. It takes a moment to build and a moment to break, and it holds only what the ice can grip. It needs moisture, struggles on dry ground and dissolves in fire or warm weather. A stagger leaves a thin skin of frost that melts in a breath.",
    "The final click of the lock lands exactly on the beat after the target's last step, as though the ice had been waiting for it.")

T["Winterglass Shield"] = (
    "A translucent ice plate that blocks one direction and fractures under repeated blows. It is clear enough to see through, which lets a defender watch the threat, and brittle enough that the third heavy hit ends it. It is cheap, quick and elegant, and it leaves shards behind that can be a nuisance underfoot.",
    "A pane of clear ice-blue glass unfolds before the caster with a bell-like ring, its edge rimmed in white and its centre faintly violet. Light bends through it in soft rainbows. Each blow adds a branching crack that spreads across the surface like frost on a window, and at the end the pane bursts into tinkling shards that melt to silver droplets.",
    "The caster freezes available moisture into a thin, hard plate and holds it in front of themselves or an ally. It absorbs a few ordinary blows, shows damage as cracks and fails suddenly under heavy force. It needs moisture and cold to form, melts in fire, and cannot protect from the sides or above. A stagger drops the shield before it hardens, leaving only a fog of frost.",
    "After the third crack the pane holds for exactly one more beat, long enough for the defender to step back, and then rings once like a struck glass.")

T["Winterstep Bridge"] = (
    "A temporary ice foothold on a wet or cold surface, formed under the caster's next step and gone soon after. It crosses a stream, covers a gap of mud or lets a runner cross a frozen pond without breaking through. It is thin and it melts, so it rewards speed. It cannot be made on dry stone and holds only one person at a time.",
    "A pale blue disc of ice blooms under the caster's boot with a quiet crackle, then another and another, forming a short line of glittering steps. Frost feathers out from each one and a faint breath of mist rises. As the caster passes, the steps fade behind them in a ripple of shining droplets that sink into the surface below.",
    "The caster freezes the water under their foot into a solid pad, placing each step just ahead of the last. The pads last a few seconds and hold a single person; they are strong enough to walk on, not to stand on. They need moisture, fail on dry ground and melt faster in sun or warmth. A stagger leaves a slick that can be as dangerous as the water.",
    "Each step makes a different note on the way across, so the whole bridge plays a short scale that rises and then falls as it melts.")

# ------------------------------------------------------------------ Verdance
T["Seedshot Volley"] = (
    "A scattered burst of hardened seeds fired from a living plant, a hedge, a vine or a reed. Each seed is small and stings; together they punish a crowd. They have limited penetration, and a shield or thick cloth stops them entirely. Where they land they sprout, and the little green marks they leave are a gift to the next gardener.",
    "A cluster of brown and gold seeds bursts from a thicket in a fan, whistling as they spin. Tiny green shoots uncurl from each landing spot within a heartbeat, dotting the ground with fresh sprouts. A faint scent of cut grass and warm earth follows the volley, and a few seed husks drift down like snow in golden light.",
    "The caster coaxes a living plant to harden its seeds and release them in a burst. The volley is wide and weak, with only a few seeds finding any one target. It needs a living plant of some size nearby, does nothing in a stone corridor and is stopped by armour. A stagger leaves only a rattle of husks and a surprised hedge.",
    "A single seed always lands on the caster's own shoe and sprouts a small flower there, which most mages pretend not to notice.")

T["Blooming Remedy"] = (
    "A gentle working that coaxes medicinal plants to release their natural compounds, easing pain and helping the body mend. It is not instant healing, and it does not close a deep wound or replace a physician. It steadies the patient, cools a fever and speeds the first hours of recovery. It works best on those who are calm, close and willing.",
    "Soft green motes rise from the caster's cupped hands like fireflies and settle on the patient in a warm, glowing mist. A small flower of pale petals opens on the nearest leaf and releases a drift of golden pollen that smells of mint and honey. The glow fades with a quiet bell tone, and the patient's rim light softens from tension to calm.",
    "The caster speaks softly to a nearby plant, or a bundle of herbs, and shapes the compounds it releases into a steady, soothing flow. The effect helps the body do its own work and cannot reverse death, close a major wound at once or replace rest, food and skilled care. A stagger, a loud room or a frightened patient spoils it. It is slow, gentle and the benchmark for how healing should feel.",
    "No flash accompanies it at all; the only sign it has worked is the patient's shoulders dropping a finger's width.")

T["Canopy Screen"] = (
    "A temporary screen of leaves and branches bent into place to hide a small group. It breaks line of sight, softens a silhouette and gives a patrol a few quiet moments. It hides movement, not presence, and a wind that parts the leaves ruins it. It needs living growth nearby and fails entirely in a barren corridor.",
    "Branches and leaves lean inward as if pulled by a breath, knitting into a green curtain that rustles softly. Dappled light moves across it in coins of gold and shade, and a faint scent of damp bark hangs in the air. As the screen ends, the leaves relax one by one and spring back to their places with a soft shiver.",
    "The caster persuades nearby foliage to lean and weave into a dense screen for a short time. It blocks sight in one direction and muffles a little sound but does not stop scent, touch or a thrown rock. It needs live branches or tall growth, takes a moment to form and drops when the caster is staggered. A careful stare from a close angle finds the gaps.",
    "The last leaf to spring back always rustles twice, as if the tree itself were checking nobody saw.")

T["Greenpulse Sense"] = (
    "A way to read stress and disturbance through connected roots and nearby plant life. A trampled lawn, a crushed fern or a cart on a forest road all speak through the green. It shows where and how recently, not who. In bare stone or snow it hears nothing, and a strong wind confuses the reading.",
    "The caster kneels and presses a hand to the soil, and a slow, green pulse spreads outward like a heartbeat. Where plants have been disturbed, small glowing leaves open and fade in a trail. The ground smells of rain and warm earth, and a soft, low tone rises and falls with each pulse, like a distant drum in a forest.",
    "The caster connects their mana to roots and plant fibres and listens for stress. Fresh disturbance glows brightly, old traces fade, and the pattern gives a rough map of movement. It works only where living plants grow and is blunted by dry, bare ground and heavy wind. It shows traces, not faces or intentions, and the caster is blind to the rest while concentrating.",
    "Each pulse is a little slower than the last, until the forest's own slow rhythm takes over and the caster's breathing matches it.")

# ------------------------------------------------------------------ Radiance
T["Mercy Flame"] = (
    "A steady, warm light for treatment spaces that eases fear and gives a healer something to work by. It does not close wounds, restore life or cure disease. It keeps a room calm, a night bright and a bandage visible. It is the light that old field hospitals prayed for, and it is entirely honest about doing only that.",
    "A small, soft flame of warm cream and amber hangs in the air at shoulder height, steady and unflickering. A gentle halo spreads around it and softens harsh shadows into warm gold. Faces look a little kinder in its light. When it ends, the flame lowers slowly, like a candle being turned down, and leaves a faint, lingering glow.",
    "The caster gathers ambient light and shapes it into a steady point that gives warmth and brightness. It helps treatment by making work visible and calming those nearby, but it neither heals nor revives. It holds as long as the caster keeps their focus and the mana lasts, and a stagger drops it into the dark. In true darkness, a little ambient light is still needed to begin.",
    "When the flame is turned down, its glow lingers on the patient's hand for one extra breath, as if reluctant to leave.")

T["Aurora Veil"] = (
    "A shifting curtain of colour cast across a space to confuse depth perception and disrupt visual tracking. Archers lose their aim, riders misjudge a gap, and a patrol sees too much to see anything. It does not blind and it does not conceal; it dazzles. Closed eyes, fog and darkness ruin it, and the colours betray the caster's position to everyone nearby.",
    "Bands of rose, mint and violet drift across the air in slow, rippling curtains, overlapping and sliding over one another like silk in water. A soft chime rings as each band appears, and the colours brighten and shift when anything moves behind them. The whole veil glows with a gentle, steady light that never flashes.",
    "The caster bends light into layered bands and sets them in motion across a wide area. The shifting colours scramble depth and make fast targets hard to follow, but they do not hide objects or block sound. A single closed eye, a heavy fog or a stagger ruins the effect. In rituals, the caster may let the veil breathe slowly, but never with a pulse a watcher could mistake for a warning.",
    "At the very end the three colours converge into a single warm line across the horizon for one beat, like a sunrise that lasted a second.")

T["Beacon Crown Pillar"] = (
    "A tall column of light raised as a landmark that allies can use across open terrain. It marks a rally point, a safe crossing or a place where help is needed. Enemies see it too, so it is a promise and a target in equal measure. It does not heal, shield or summon anything; it simply says: here.",
    "A slender pillar of warm cream light climbs from the ground into the sky, narrowing to a sharp point at its peak. Soft rays fan outward near its crown like the points of a circlet. Faint motes drift upward along its length, and a clear, steady tone hums beneath it. At the top, a small ring of light turns slowly, never pulsing.",
    "The caster sets a stable pattern of light and tunes it to a frequency their allies share, then extends it upward. It can be seen from far away by those who know the tone and fades when its stored mana runs dry. It marks position, not safety, so careful casters use it with the enemy in mind. A stagger drops it into a flicker, and heavy fog or rain dims it badly.",
    "At the moment of casting the crown opens one ring at a time from the ground to the sky, each ring a half-second apart, like a staircase being lit.")

T["Sunveil Blur"] = (
    "A bending of light around a moving figure that blurs their outline without making them invisible. Archers lose their mark, a pursuer misjudges a corner and a thief gets a half-second head start. Anyone who looks closely sees a smeared person. Fog and shadow weaken it, and a direct touch ruins it entirely.",
    "A soft golden shimmer clings to the caster's outline and wavers like heat above a road, smearing the edges of their body into pale streaks of cream and peach. Their motion leaves faint after-trails that fade within a heartbeat. A gentle high note sounds as the veil settles, and sunlight seems to bend toward them.",
    "The caster refracts light around their body so that edges blur and the eye slides off. The effect is strongest in bright light and weak in shadow, fog or darkness, and it does nothing against touch, smell or beings who sense souls. It breaks when the caster is struck or staggered. A hard stare from a close angle finds the person inside the blur.",
    "The blur always lags exactly three frames behind the caster's real movement, so a sharp eye can learn to aim at the gap.")

# ------------------------------------------------------------------ Umbral
T["Duskbind Chain"] = (
    "A set of shadowy bands that wrap a target's limbs and weaken when exposed to strong light. They restrain the body and never the mind; the bound foe can still shout and think. A lantern held close or a spell of Radiance frees them, and a strong enough target simply tears free. It works best at dusk, indoors and under tall trees.",
    "Thin chains of violet-black shadow slither from the caster's shadow across the ground and coil around the target's wrists and ankles. Each link has a silver edge that glints faintly, and the chains hang oddly still, as if heavier than they look. A low, quiet clinking sounds as they tighten, and they dissolve into drifting smoke when the light finds them.",
    "The caster pulls a dark band out of existing shadow and wraps it around a limb, binding it by weight. The chains hold only as long as the shadow does, so a strong light, a lantern or a bright spell frees the target at once. They cannot hold a large target for long and do nothing to a mind. A stagger drops the shadow back to where it began.",
    "The chains stop clinking one second before they dissolve, and in that silence the target can hear nothing but their own breath.")

T["Gloamstep Shift"] = (
    "A short move between two connected patches of shadow within a visible distance. It carries the caster from one dark corner to another in a heartbeat and leaves a faint tell for those who know to look. It needs shadow at both ends and fails in bright, open ground. It does not carry others and cannot cross a room lit end to end.",
    "The caster steps into their own shadow and sinks as if into dark water, leaving a ripple of violet-black on the floor. A pair of silver-edged afterimages hang behind for a heartbeat, dissolving into ash-silver motes. They reappear from another shadow with a soft, low whoosh, and the dark where they left slowly settles back into its usual shape.",
    "The caster pushes their body through a pocket of connected shadow and out at another shadow they can see. The distance is short, the shadows must be linked by darkness and the exit must be seen in advance. It does not work in strong light or on moving shadows, and a stagger leaves the caster half-way in and visibly out of place. It is quick, quiet and the thief's favourite.",
    "Their silver-edged afterimage stays one beat longer than expected, and sharp-eyed enemies learn to look at it rather than at where the caster went.")

T["Eclipse Double"] = (
    "A dark duplicate that mimics one simple movement before dissolving. It draws an arrow, a glance or a lunge, and buys the caster a moment. It is a decoy, not a clone, and it cannot speak or strike. Anyone who touches it feels cold and nothing more, and spirits see through it at once.",
    "A silhouette of the caster peels away in violet-black, edged with a thin line of silver, and repeats a short motion in perfect silence. Its face is a blank eclipse ring, and its outline ripples at the edges like ink in water. When struck, it pops with a soft, muffled sound and scatters into a puff of dim, silver-edged smoke.",
    "The caster shapes a shell of shadow and sets it a short motion to repeat, then lets it go. The double lasts a few seconds and is destroyed by any contact. It fools sight and sometimes sound, but not touch, smell or beings that sense souls. A stagger during the chant leaves only a lumpy shadow that does nothing.",
    "When it pops, the silver outline lingers a single frame and the caster's real shadow flickers once to match it.")

T["Raven Mark Sigil"] = (
    "A faint shadow-sign placed on a surface for later recognition by the caster. It tells the caster that someone passed here, that a door was opened or that a meeting place is still safe. It does nothing else and hides itself well in dim light. It lasts a few days at most and fades quickly in sun.",
    "A small raven-feather sigil of near-black plum appears on a wall, edged in a thin silver line that catches the light only from certain angles. It sinks into the surface with a soft hush and is almost invisible until looked at directly. When the caster returns, it glows faintly violet and a single, quiet caw sounds in the mind.",
    "The caster draws a pattern in shadow and ties it to a surface, then ties a small sense of recognition to themselves. Only the caster can easily read the mark, and it fades over time, in sun and under bright light. It shows presence and passing, not identity. A stagger leaves a smudge that means nothing, and a skilled Umbral caster can find, copy or erase the mark.",
    "The faint caw arrives in the caster's ear half a second before they see the sigil, as if the mark had been waiting for them.")

# ------------------------------------------------------------------ Spiritbond
T["Foxfire Guide Call"] = (
    "A request to a willing light-spirit to mark a safe route with drifting flames. The spirit may lead, may decline, or may lead somewhere interesting instead. It knows only what it has seen, and its idea of safe can differ from the caster's. It is the gentlest of the Spiritbond calls and the one apprentices are taught to say thank you for.",
    "A small fox-shaped light of spirit green trots into view at the caster's feet, its tail trailing a line of floating blue-white flames. It pauses, looks back, and its mood tints its light: green when calm, amber when eager, dim when reluctant. Each flame sits low and steady and fades slowly behind it. A soft, quiet bell chimes at each turn.",
    "The caster makes a low-pressure request through a bond already built on trust. The spirit decides whether to answer, how far to lead and what route to choose, and it may refuse without cost to either side. It cannot see danger it does not understand and tires after a short while. A broken bond, a rude request or a stagger leaves nothing but silence and a small, polite flicker.",
    "If the fox declines, its light dims over a full second, it sits, and a soft two-note chime descends. No flash, no penalty: only a quiet no.")

T["Wisp Errand"] = (
    "A request to a small spirit to carry a light object across a nearby gap. A key to a locked window, a note to a friend across a ravine or a coin to a beggar on a rooftop. The wisp does it if it is willing and the object is light. It carries nothing heavy, nothing alive and nothing it dislikes.",
    "A small ball of soft green-white light drifts up from the caster's palm, circling twice before gently lifting the object in a wobbling arc. Tiny motes orbit it like fireflies. It hesitates at about seventy per cent of the way, then continues, and lowers its cargo with a soft chime. If it declines, it dims and drifts away in a slow curve.",
    "The caster asks a small spirit for a favour, and the spirit shapes a bit of the caster's mana into the strength to carry a light load over a short distance. It may refuse, tire, take a longer route or leave the cargo somewhere unexpected. It cannot carry living things, heavy items or anything it distrusts. A stagger breaks the request before the spirit hears it.",
    "At seventy per cent of the way, the wisp always pauses, and on that pause the player learns whether it will deliver or drift away.")

T["Kindred Pulse Bond"] = (
    "A brief sensation shared between willing bonded allies and their spirits. A warmth, a calm, a quickening of focus passes from one to another and back. It does not command or compel; it shares. A friend who has just felt it knows their companion is near and well, and fights a little more steadily for it.",
    "A soft halo of spirit green and lantern amber forms around caster and spirit together, their lights blending into a single warm ring. A gentle pulse travels around it like a heartbeat, brightening slowly. Tiny motes drift between them in a shared orbit, and a clear, low note hums at the centre. When it ends, each light withdraws to its owner with a soft chime.",
    "The caster and spirit open their bond and share a small part of their state, such as steadiness, warmth or focus. The sharing is mutual and willing, and it works only between those who already trust each other. Harm to one is felt by the other, and either may end it at any moment. A stagger or a broken bond severs the link with a quiet, final click.",
    "At the peak of the pulse the two lights briefly swap colours, spirit green to amber and amber to green, before returning.")

T["Listening Pact"] = (
    "A brief channel through which the caster hears a bonded spirit's impressions of the area. The spirit shares what it has noticed: a sound, a smell, a feeling of unease. It is not an interrogation, and the spirit decides what is worth sharing. The picture it gives is partial, coloured by its own moods and memories.",
    "A soft green ring of light forms around the caster's ear, and faint whispers rise like wind through leaves. Pale mist coils beside them and shapes brief, half-seen figures that fade as quickly as they come. The world dims slightly, and a gentle, low hum fills the silence. The spirit's mood tints the whole scene, calm green or restless gold.",
    "The caster opens a quiet channel with a bonded spirit and listens to what it chooses to share. The spirit reports from its own perspective, so the report may be partial, biased or unwilling. It does not reveal minds, intentions or anything the spirit does not know. A rude request, a distrusted caster or a stagger closes the channel, and a tired spirit simply goes quiet.",
    "The whispers always end on the same soft sigh, and the caster learns to tell a happy spirit from a worried one by that last note.")

T["Dewdrop Covenant"] = (
    "A lasting agreement with a willing spirit, sealed with a promise from each side. The caster offers care, a visit, a gift; the spirit offers its help in return, in its own way and its own time. It is a relationship, not a contract, and it ends the moment either side breaks faith. The better it is kept, the deeper the help becomes.",
    "Two bright rings of light, one spirit green and one lantern amber, rise and link like the ends of a chain. A single dewdrop forms between them, glowing softly and catching a tiny rainbow. The rings turn slowly together, and a warm, clear chime sounds as they settle. When the covenant ends, the rings part gently and the dewdrop falls to the ground and vanishes.",
    "The caster and spirit each name what they will give, and the spirit agrees on its own terms. The bond lasts as long as both sides keep faith and the spirit is treated well, and it grows stronger with time and gratitude. A broken promise, a cruel word or a stagger during the sealing ends it at once, and the spirit may refuse to be called again.",
    "If the covenant is accepted, the dewdrop holds its place for a full second and a tiny flower opens on the ground beneath it.")

# ------------------------------------------------------------------ Divine
T["Hearth of Grace Prayer"] = (
    "A prayer for warmth and calm in a small refuge, without erasing grief or fear. It makes a cold room gentler and a long night shorter. It does not heal, resurrect or banish sorrow, and the god may answer with more or less than was asked. It works best when the supplicant is sincere and the room is full of people who want it to.",
    "A warm gold-white glow settles over the room, as if a hearth had remembered how to be gentle. Soft motes of light rise like embers and fade before they reach the ceiling. A distant bell rings once, low and clear, and every candle leans quietly toward the caster. The glow breathes slowly during the prayer and settles to a steady light when answered.",
    "The caster offers sincere Devotion and a little mana as a prayer, and the god decides whether and how to answer. The answer is warmth, calm and a sense of being watched over, not healing or protection. It lasts as long as the shelter holds and the prayer is not broken. A stagger, a doubting heart or a god's silence ends it, and a refusal costs the caster nothing but the answer.",
    "As the prayer is answered, every flame in the room brightens by the same small step at once, and for a heartbeat nobody speaks.")

T["Sanctuary of Hands Prayer"] = (
    "A request for a protective presence around those sheltering together, strongest when they stand willingly. It does not stop swords; it makes a small circle of safety feel real and gives the frightened something to hold. It cannot protect anyone who brings harm in with them, and it fades if the group breaks apart.",
    "A ring of warm gold light rises around the group like a tent being raised, soft at its edges and clear at its centre. Pale petals of light drift down and vanish before they touch the ground. A low, held chord sounds under it, and the ring breathes slowly at the rhythm of a quiet sleeper. At the end, the petals rise and the ring lowers gently.",
    "The caster asks for sanctuary over a small place, and the god answers according to the devotion of the group. Those inside who are willing receive its calm and a modest buffer against harm; those who are not, or who bring harm in, receive nothing. It fades if the circle breaks or the faith falters. A stagger or a refusal leaves only a faint warmth.",
    "The ring's last note is the first chord played backwards, so the end of the prayer sounds like a door quietly closing.")

T["Morrow's Measure Prayer"] = (
    "A request for a brief stabilising grace for a soul whose lantern has not yet gone out. It steadies a failing breath for a few minutes and gives the healer time. It never returns a lantern that has been snuffed. It is the narrow mercy of Morrowyn, offered in the last window and never beyond it.",
    "A soft lantern glow, pale and rose-tinted, descends slowly from above like falling light. A single bell tolls once, low and warm, and the patient's rim light brightens by the smallest step. Tiny motes gather and settle like fine snow. It makes no flash. The glow dims slowly and leaves a faint warmth that lingers a moment longer than it should.",
    "The caster prays quietly to Morrowyn for the span of a few minutes, and the god may answer with a stabilising grace for a soul still within the window. It does not revive, heal or restore; it steadies. It works only before the lantern goes out, may be refused without warning and ends at once if the caster is staggered or the soul has departed.",
    "A single bell tolls at the moment of answer, and the same bell tolls once more, softer, if the god declines.")

T["Oathfire Witness Prayer"] = (
    "A prayer that calls a visible flame to bear witness to a freely spoken vow. The flame does not force honesty and cannot compel anyone to keep their word. It only remembers. It is used at weddings, treaties and the quiet promises between friends, and it burns steadily for as long as the vow is kept.",
    "A single flame of warm candle cream rises from the speaker's cupped hands and hangs between the two parties, steady and unmoved by wind. It leans gently toward whoever is speaking and stands tall when the vow is complete. The air hushes and a soft bell rings once. The flame fades slowly, leaving a faint ring of warmth on the ground.",
    "The caster asks the god to witness a vow spoken freely by willing people. The flame records and remembers, nothing more; it does not compel truth, punish a lie or bind anyone's will. It burns as long as the vow is held and dims if it is broken. A stagger, a coerced vow or a god's refusal leaves only a candle's light.",
    "When the vow is finished the flame stands perfectly straight for one breath, and the whole room hears it settle.")

T["Hallowed Calling"] = (
    "A prayer that sends a quiet call to a god and waits for the answer. The god may send comfort, a sign, a small help or nothing. It is a request and never a command, and the caster must be ready for the silence. Devotion spent carelessly makes the next call quieter, and sincerity is the only currency that counts.",
    "A thin ring of warm ivory light opens above the supplicant's head, left open like a door ajar. A single clear note rises and hangs. Pale petals of light drift down in a slow spiral and vanish. If the call is answered, the ring closes with a soft bell and a gentle brightening; if not, it fades over a second and a half with one low, quiet tone.",
    "The caster offers Devotion and mana together and asks. The god decides whether to answer, how much to give and in what form. The answer is shaped by the god's nature and the sincerity of the asker. A stagger, a doubting heart or a careless request ends it, and a refusal leaves no mark except the silence. A god that has refused may still answer the next call.",
    "An answered call closes the ring with a bell and a brightening; a refusal leaves the ring open and lets it fade, so the player feels the difference without being told.")

# ------------------------------------------------------------------ Forbidden Arts
T["Yesterday's Trace Echo"] = (
    "A faint echo of a recent movement in a place: the shape of a fight, the path of a thief, the outline of someone who stood in a doorway. It is incomplete, hours old at most, and never shows the thoughts of those who moved. Each reading frays the trace further, so Forbidden detectives destroy their own evidence one look at a time.",
    "Grey-violet silhouettes replay brief moments in the air, smudged and partial, like figures painted in water that never quite dries. They stutter, holding for two frames every eight, and their edges repeat a frame late. The colours of the room drain slightly, and a quiet clock-tick runs under it. When it ends, a hairline crack of white is left on the air for a moment.",
    "The caster presses on the freshest impressions in the local Weave and draws out an echo of what happened there. The echo is partial, hours old at best, shows motion and not intent, and frays the trace it reads. Every use frays the Weave and invites the System's hidden repair; the consequence is never safe or predictable. A stagger leaves only a smear of grey and a headache.",
    "The echo always freezes for exactly one frame on the moment of greatest movement, and the player sees it in a single sharp still before it plays on.")

T["Nullglass Edge Cut"] = (
    "A thin void boundary that unthreads a small mana construct. A ward, a glyph, a glamour or a snare falls apart along the line, and the caster is left with the cold of having touched nothing. It cannot erase matter without limit, and it leaves a visible wound in the Weave that other casters can read for a long time.",
    "A single hairline of absence, darker than shadow and rimmed in a one-pixel white edge, opens in the air and slides along the target. All sound dips six decibels around it, and colours drain from its edges. The construct it cuts frays into loose grey threads that drift apart. When it closes, a faint scar of grey-violet remains hanging in the air for half a minute.",
    "The caster draws a thin boundary through the Weave and lets it cut along the pattern of a small construct, unthreading it. It affects only constructs of mana, not flesh, stone or will, and it cannot be widened without cost. Every use frays the Weave and invites the System's hidden repair; the consequence is neither safe nor predictable. A stagger leaves the edge half-open and the caster staring at it.",
    "The cut is silent, and the sound of the room returns one beat after the line closes, as if the world had needed a moment to catch up.")

T["Folded Threshold Step"] = (
    "A compression of the apparent distance across a doorway for a single crossing, which then snaps back. It carries the caster across a threshold in one step instead of three and leaves a visible seam for a moment. It never opens a road to another world or crosses a sealed boundary, and it frays the Weave a little each time.",
    "A hairline seam of pale blue-grey light opens in the air across the doorway, the colours on either side sliding half a step out of line. The caster steps through in a single stride and the seam closes behind them with a thin, tearing sound. A faint echo of their footstep repeats a moment late, and the doorframe flickers once before it settles.",
    "The caster folds a very small piece of space across a threshold they can see and steps through before it springs back. The distance is short and brief, the seam is visible to anyone who knows how to look and the arrival is never perfectly certain. It cannot cross sealed realms, barred wards or other worlds. Every use frays the Weave and invites the System's hidden repair.",
    "The footstep echoes a heartbeat after the caster has already passed, and in that echo a sharp listener hears which way they went.")

T["Hollow Interval Gap"] = (
    "A momentary gap in a sound or light sequence that is noticeable to anyone paying attention. A bell skips a toll, a torch loses a flicker, a guard's step misses a beat. It buys the caster a heartbeat of cover and a sharp watcher a reason to be suspicious. It does not stop time; it steals a sliver of it.",
    "The caster's shadow lags a tenth of a second behind them. For a moment, every sound nearby drops out and returns half a beat late, and a thin grey line of distortion runs across the air. Colours dim and return slightly off. A faint tick of a clock sounds once in the silence, and then the room hurries to catch up.",
    "The caster presses on the Weave and cuts out a sliver of a sequence, such as a rhythm, a flicker or a footfall. The gap is small and short, and it is noticed by anyone listening closely. It does not slow or stop anyone, and it leaves the area a little out of tune. Every use frays the Weave and invites the System's hidden repair, which is never safe or predictable.",
    "The missing beat is replayed at double speed a second later, so anyone nearby hears the world stutter twice.")

SLICE_EXTRA = {
    # name -> (wave, what it proves); the two new Pact spells added to the slice
    "Dewdrop Covenant": (2, "A lasting Pact: the covenant rings, the dewdrop and the consequence of a broken promise."),
    "Hallowed Calling": (2, "Divine refusal feel: the open ring, the bell, and a quiet no that costs nothing."),
}
