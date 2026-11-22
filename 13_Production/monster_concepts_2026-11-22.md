# Three monster concepts, and the one I would build

Written 2026-11-22 as art direction, not as data. Nothing here is Canon until the user says so; the species rows,
ids and stats would be proposed in Canon §6 afterwards.

The brief was three original anime-fantasy monsters — one aggressive, one supernatural, one beautiful and lethal —
good enough to model from. They are designed against AETHWYRD's own taxonomy (31 families, 13 elements, menace 1–5,
ranks F to SSS+) and against a measured weakness in our bestiary: the 680 species score **7.7/20 on "reads at a
glance"**, and **41.8% duplicate another species' entire fight profile** inside their own region and ring
(`13_Production/research/monsters.md`). So each concept is judged on whether it is a silhouette and a fight nobody
else in the roster already owns.

All three are original designs. Ideas and genre furniture come from anywhere; no other studio's art, models or
character likenesses are used, per `CLAUDE.md`. Teen rating: eerie, never gory.

---

## 1. The Vaultbreaker — aggressive *(reworked 2026-11-22, see the Rework section below)*

**Shape language: a forward wedge.** At thumbnail size it is an arrow pointing at you.

A knuckle-walking quadruped whose front half is a battering ram and whose back half is almost an afterthought.
Forelimbs half again as long as the hind legs, so it stands permanently braced nose-down, like a loaded spring that
has not yet gone off. Shoulders enormous; haunches small and tucked.

**The head is the gimmick.** There is no face on the front of it. The skull ends in a broad chisel of laminated bone
— a door-ram grown out of its own body — and the eyes sit far out on the *sides* of that plate, where a hammerhead's
would be. Nothing to look at, nothing to aim for: just the plate coming toward you. It has no front teeth at all. It
does not bite. It arrives.

**Visual storytelling.** The ram-plate carries the negative impressions of everything it has broken: gate studs,
portcullis bars, the square of a lock-box. You can read its career on its face. Older individuals have deeper
tooling and a plate re-grown in visible layers, like rings in wood.

**Movement and tell.** It does not charge from across the field. It rocks back onto the small hind legs — the whole
silhouette shortening for about three quarters of a second — then slams forward one body length. The rock-back is
the tell, and it is readable from any angle because the whole shape changes, not just a limb.

Earth · menace 5 · Beasts or a new Siegebeast family · about 2.8 m at the shoulder · Iron Hold and the Strife Marches.

---

## 2. The Tall Mourner — supernatural

**Shape language: a tall narrow column.** A single upright lozenge with a small blob on top.

Something is walking the fog roads of Moraveil in a long grey drape, head bowed, moving at a funeral pace. It is
about two and a half metres tall, far too tall for a person, and the drape falls all the way to the ground.

**It is not one creature.** It is four small spirits standing on one another's shoulders under a single drape. The
silhouette is a lie, and the lie is the design. Everything about the figure is built to sell "one tall mourner"
until it stops being true.

**What gives it away, if you look.** The drape is lumpy at the shoulder line, because the bearers are not the same
height. The hem does not hang level. And there is a finger's width of clear air under the hem — enough, if you are
low or far enough back, to count the feet. There are eight.

**The head is an unlit lantern.** Where a face should be there is a lantern of grey glass and tarnished brass, hung
in a cowl, and it is dark. The light comes from somewhere else: thin cold seams glowing between the bodies under
the drape, so the figure is lit from *inside the stack*, at the joins, and the lantern stays black. A light source
that gives no light is a quiet, specific unease, and it costs one emissive mask to build.

**The break.** Hurt it enough and the stack comes apart — the drape drops, and four small fast things scatter in
four directions. One silhouette becomes four. The fight changes shape rather than its numbers going down.

Dark · menace 4 · around rank B− · Moraveil, and the upper Labyrinth where the fog gets in.

---

## 3. The Glasswing — beautiful, and lethal

**Shape language: a wide shallow cross.** Nothing else in the roster has that footprint.

A great pale moth-ray that hangs in the air over Hoshizora on nights when the sky is clear. The body is slender and
ornamental — a single calligraphic stroke, thickening once and tapering to two long trailing streamers. The wings
are thin iridescent membrane, almost entirely transparent, with a visible thickening at the centre of each wing
where the membrane swells into a lens.

**Because that is what they are.** The wings focus starlight. The Glasswing does not strike, does not bite, has
nothing resembling a weapon. It positions itself, and a burning point of focused light crawls across the ground
beneath it. The danger is geometry: where it hovers relative to the sky and to you. Fighting it is about reading a
moving bright spot and not being in it.

**The appeal and the problem.** It is the most beautiful of the three and the most novel to fight. It is also the
one we cannot build today: a moving focused-light hazard is a system we do not have, and the honest cost is new
runtime work, not a model.

Light · menace 5 · Hoshizora, clear nights only.

---

## Which one I would build: the Tall Mourner

Not the one with the best thumbnail. The Vaultbreaker is the most immediately striking of the three and I would
expect most people to pick it. I am not picking it, for three reasons.

**It is the most original of the three where it counts.** A creature whose silhouette is a deliberate lie is a
design idea, not a pile of features. The Vaultbreaker is an excellent execution of a familiar thing — a charging
armoured beast. The Glasswing is genuinely novel but its novelty lives in a mechanic we would have to invent.

**It is buildable with systems that already run.** We have group tactics with flank slots, peer yielding and an
aggro-token limit, all working and tested in PlayMode. "One creature that becomes four" is those systems used for a
purpose rather than demonstrated. The Vaultbreaker needs a charge-and-slam that our attack-chain windows can
already express, so it is also cheap — but it adds nothing to what the systems can say.

**It attacks our actual weakness.** Our bestiary's measured failures are "reads at a glance" at 7.7/20 and 41.8% of
species sharing a whole fight profile. The Tall Mourner is unmistakable at thumbnail, and its fight profile — one
target that becomes four mid-fight — is shared with nothing in the roster. It is a direct answer to both numbers.

**The trade-off, stated honestly.** It is the hardest of the three to make legible. If the break reads as "the
monster died and four others spawned", the whole idea collapses into a reskinned summoner, of which we have several.
The drape must fall as one piece and the bearers must be visibly the things that were already inside it. That is an
animation problem more than a modelling one, and it is where this design will live or die.

I would hold the Vaultbreaker as the next build — it is strong and cheap — and shelve the Glasswing until there is
a reason to build a light-hazard system, at which point it becomes the obvious creature to justify it.

---

# Reference sheet — The Tall Mourner

Production reference. Every view below describes the same creature at the same proportions; the measurements are
the contract, so the model can be checked against them rather than eyeballed.

## 1. Creature concept

A funeral procession pretending to be a mourner. Four small fog-spirits of the Moraveil roads carry a drape and a
dead lantern between them, stacked shoulder to shoulder, and walk the roads at a pace that makes travellers step
aside and lower their eyes. It is not malicious so much as committed: it has a route, and it does not deviate, and
what is on the route when it passes is its business.

## 2. Visual identity

The one thing to remember: **a tall grey figure with a lantern for a head, and the lantern is not lit.**

## 3. Anatomy breakdown

**The stack, bottom to top.** Four bearers, each a smooth, limbless-looking ash-grey spirit with a heavy head and
short strong arms — closer to a seal or a swaddled child than to a goblin. They do not have faces; each has a single
pale band where eyes would be, which is where the seam light leaks out.

| | Bearer | Shoulder height | Note |
|---|---|---|---|
| base | the Foot | 0.62 m | widest; carries everything; its arms are braced outward under the drape, which is what makes the shoulder line lumpy |
| 2nd | the Knee | 0.58 m | slightly narrower |
| 3rd | the Hand | 0.55 m | holds the lantern pole against its chest |
| top | the Face | 0.48 m | smallest; its head sits *behind* the lantern, not inside the cowl |

Stacked with overlap, total standing height **2.55 m**. The lantern hangs at **2.28 m**, which is above a human
eye-line and is deliberate: you look up at it.

**Limbs.** Eight arms in total, but only the Foot's and the Hand's are ever outside the drape, and only to the
elbow. Eight feet, all on the ground, all visible in the 0.11 m gap under the hem.

**The drape.** One piece, from the cowl to 0.11 m above the ground. Heavy wet wool, not silk: it should fall in few
large folds, never ripple. Two shoulder points (the Foot's braced arms) and a third smaller rise where the Hand's
elbow pushes it out on the left. The hem is cut level but never hangs level, because of the feet under it.

## 4. Silhouette and proportions

- Total height **2.55 m**; width across the drape at its widest **0.74 m**; depth **0.52 m**.
- Height-to-width **3.4 : 1** — the tallest, narrowest thing in the bestiary. The nearest competitor is the Bog Lich
  at roughly 1.1 : 1, so this does not collide with anything.
- At 32 × 32 px, solid black: a vertical lozenge, slightly wider at the base, with a small square notch at the top
  where the lantern breaks the cowl line. That notch is the only silhouette detail, and it must survive. It is the
  whole thumbnail read.
- Nothing projects more than 0.08 m from the body outline. **No spikes, no horns, no spread limbs.** The design is
  carried entirely by proportion and by one notch.

## 5. Colour palette

| Role | Hex | Where |
|---|---|---|
| Drape main | `#39414E` | wet slate blue-grey, the body of the cloth |
| Drape shadow | `#262C36` | deep folds, under the cowl, the hem's inner face |
| Hem band | `#D8CFBC` | bone cream, a hand's width at the hem and cuffs — the only light value, and it draws the eye to where the feet are |
| Seam light | `#BFE6D0` | cold green-white, emissive, only in the joins between bearers and the eye-bands |
| Lantern glass | `#5A6270` | dead grey; never emissive, in any state |
| Lantern brass | `#8A7B62` | tarnished, low gloss |
| Bearer skin | `#9AA3AE` | pale ash, glimpsed at wrists and under the hem |

Three values and one accent. The cream hem at the bottom and the dark cowl at the top give a strong vertical
value run, which is what makes a narrow shape read at distance.

## 6. Front view

Vertical, symmetrical at a glance and not quite symmetrical in fact. The cowl's opening is a dark oval; the lantern
hangs in it at 2.28 m, slightly left of centre by 0.04 m. The shoulder line is a wide shallow arc, broken by a
small rise on the left at 1.55 m — the Hand's elbow. The drape falls in four main folds. The cream hem runs level;
beneath it, in the 0.11 m gap, eight pale feet, arranged in two rows of four, the front row slightly splayed.

## 7. Side view

This is the view that tells the truth. The drape's profile is not a column: it steps back twice, at 0.62 m and at
1.20 m, where one bearer's shoulders end and the next begins. The lantern hangs 0.14 m forward of the chest line on
a short brass pole. The cowl juts 0.09 m forward above it. The back line is almost straight from cowl to hem —
deliberately simpler than the front, because the back view is where the creature should look most like a single
person.

## 8. Back view

Nearly featureless: one unbroken fall of slate from cowl to cream hem, two shallow folds, no seam light visible at
all. This is the view a traveller gets as it passes them on the road, and it should be entirely unremarkable. The
unease is that you saw nothing wrong.

## 9. Three-quarter view

The sell. The front's lumpy shoulder line and the side's two steps are both visible at once, so the shape finally
reads as *stacked* rather than tall. Seam light shows as two thin crescents at 0.62 m and 1.20 m where the drape
gaps. The lantern reads as clearly separate from the cowl — an object hung in a hood, not a head in a hood.

## 10. Face close-up, and the lantern

There is no face. The cowl's opening is a dark oval 0.26 m across, and inside it is the lantern: a four-panelled
grey glass box 0.19 m tall in a tarnished brass frame, hung from a ring. Two panels are cracked, and the cracks are
dark, not glowing. Behind and above it, 0.1 m deeper into the cowl, the topmost bearer's eye-band glows faintly —
so when the viewer's eye finally finds the light, it is behind the lantern and higher than expected. A dead lamp
with something lit behind it is the single most important detail on the model.

## 11. Detail: feet, hem, and the seams

**Feet.** Eight, pale ash, soft and round, no claws and no toes — closer to a thumb than a foot. They should look
soft and unsuited to the road, which is part of why it moves slowly.

**Hem.** Cream band, 0.12 m deep, slightly frayed, weighted so it swings late — one beat behind the body.

**Seams.** Two horizontal bands of cold light where bearer meets bearer, visible only from the front and
three-quarter, never from the back. They brighten as the creature takes damage: by the last phase they are the
brightest thing on it, which telegraphs the break without a health bar.

## 12. Movement and the break

Walks at about 0.7 m/s, with no bob — the stack cannot bob without giving itself away, and the stillness is eerie
on its own. It turns by rotating the whole stack in place, never leaning.

**The tell.** Before it breaks, the hem lifts about 0.2 m and the feet visibly re-arrange, three quarters of a
second of warning that reads at any angle.

**The break.** The drape falls as one piece and stays on the ground as a prop. Four bearers scatter at 2.4 m/s,
each now its own target. This is where our existing group tactics take over: four peers, distinct flank slots,
token yielding, all already running.

## 13. Final quality check

- **Silhouette** — unique in the roster at 3.4 : 1, with one notch. Passes.
- **Originality** — the gimmick is a silhouette that lies; I know of nothing we own that does this. Passes.
- **Visual hierarchy** — dark cowl, long slate fall, cream hem; one accent. Passes.
- **Detail distribution** — almost all of it in the top 0.3 m and the bottom 0.15 m, nothing in the middle. By design.
- **Anime register** — flat values, few large folds, one cold accent, a readable graphic shape. Passes.
- **Modelling feasibility** — four simple bodies, one drape, one small hard-surface prop. Cheap.
- **Animation potential** — this is the risk, and it is the whole design. The break must read as *the drape came
  off the things that were always inside it*. If it reads as a summon, the concept has failed, and that is an
  animation and timing problem rather than a modelling one. **NOT ASSESSED until it is animated.**

## What would be needed to build it

Not started here, deliberately — the brief was to choose a concept first. In order: a blockout of the stack at the
heights in §3 to confirm the silhouette at 32 px; the drape as a single surface over all four; then the break
animation, early, because it is the risk. The model is the easy half.


---

# Rework: the Vaultbreaker

I called this one "an excellent execution of a familiar thing" and then said I would build it next. Those two
statements do not sit together. A design worth building is worth making original first, so this is the redesign.

## What was weak

Strip the good details away and the first version is **a big armoured quadruped that charges you**. The ram-plate
face, the side-set eyes and the toolmarked scars are genuinely good, but they decorate a fight every player has had:
something heavy telegraphs, something heavy arrives, you move sideways. The silhouette is strong and static. It
looks the same in the last second of the fight as in the first, which wastes the one thing a boss has that a concept
sketch does not: **time**.

Kept: the forward wedge, the faceless chisel plate, the eyes out on the sides, no front teeth, the career written in
dents. Those are the parts nobody else owns.

## The new idea: it disarms itself and arms you

**Every slam breaks the Vaultbreaker as much as the wall.** The plate is laminated bone grown in layers, and each
impact spalls a layer off, whole slabs half a metre across that fall and stay fallen. It is not shedding because it
is dying. This is how it works: it grows armour in order to spend it, the way a bee spends a sting, and it will
spend every layer and walk away lighter.

Three things follow, and each is why the design is now worth building.

**The arena changes, and the monster changes it.** Those slabs land where they land and stay, as cover, as high
ground, as something between you and the next slam. By the end you are fighting in a field of debris the fight
itself produced. No arena scripting and no phase-triggered scenery: the creature builds the stage.

**It has two silhouettes, not one.** It opens as a hunched wedge, so broad across the shoulders it looks immovable.
It ends lean, long-limbed and fast, because the small hind legs that looked vestigial under all that armour turn out
to be what it actually runs on. The same creature reads as two different animals at the start and the end of one
fight, and the player watches it change without a cutscene.

**Its health bar is on its body.** You can see how much plate is left. Someone who has fought it once knows at a
glance how far in they are, and that "nearly naked" means "fast now". That is a readable phase system with no UI at
all, and our bestiary's worst measured score is reads-at-a-glance, 7.7/20.

## Anatomy, revised

- **Plate:** seven laminated layers over the skull and shoulders, each 40 to 60 mm thick, visibly stratified at the
  edges like slate. The layer seams are the fracture lines, so breakage reads as intended rather than as damage.
  Freshly exposed layers are pale and clean; the outermost is weathered and scarred. **The colour tells you the
  phase**: a creature showing pale has spent most of itself.
- **Hind legs:** long, folded, deliberately hidden under the plate overhang at the start. The reveal is that they
  were always there.
- **Face:** unchanged, and still the best part. No eyes at the front, a chisel of bone, eyes far out on the sides of
  the plate. As layers spall, the eyes sit closer to the edge, and in the last phase they are on a thin rim, exposed,
  which makes the thing finally look vulnerable and a little pitiable.
- **No front teeth.** Unchanged. It has never needed them.

## The fight, in three reads

1. **Loaded.** Seven layers. Rocks back three quarters of a second, slams one body length. Slow, enormous, almost
   stationary. You learn the timing.
2. **Spending.** Three to five layers. Faster between slams; the first slabs are down and you are using them. It
   starts repositioning rather than waiting.
3. **Spent.** One or two layers. It runs. The slam is gone, because it has nothing left to spend, and it fights with
   its body, quick and frantic, in an arena full of its own discarded armour.

A fight that gets faster and lighter as it goes, rather than slower and bigger, is the opposite of the usual boss
curve, and it is the reason to build this one.

## Palette, revised

| Role | Hex | Where |
|---|---|---|
| Weathered plate | `#6B6257` | the outer layers, the ones you meet first |
| Fresh plate | `#C9BFA6` | newly exposed laminate, the phase tell |
| Seam shadow | `#3A342C` | between layers, and along the fracture lines |
| Hide | `#4A3B33` | the body under the armour, barely seen at first |
| Eye | `#E8A33D` | warm amber, the only saturated colour on the animal |

The palette now does work: the creature **lightens in value** as the fight goes on, visibly closer to bone at the
end. That is the whole design in one glance.

## What this costs, honestly

The shed slabs must persist as collidable props for the length of the fight, and must not break pathing for the
player or for anything else in the arena. That is Unity work we have not done and have not measured:
**NOT ASSESSED**. If the slabs cannot persist, the design loses its best third and should be reconsidered rather
than shipped hollow, because an arena-changing monster whose arena does not change is a charging beast again.

Earth, menace 5, about 2.8 m at the shoulder falling to roughly 2.2 m as it spends its plate. Iron Hold and the
Strife Marches, where there are vaults worth breaking.
