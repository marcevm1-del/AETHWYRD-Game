# 11e-19 — Moraveil, the Truce Country: Ten Side Quests (draft)

> *"Moraveil's truce began when a goblin child pulled a farmer's daughter out of a flooded cave. Both of them are still alive."*
> — Gazetteer, Moraveil

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light.

**Region:** `reg_moraveil` (the goblin cliff-village, the human market town, the Truce Bridge, the Flooded Cave, the Northern Hills). **Rank band:** C–A. **Tone:** two languages shouting over a market, and, underneath, a fragile, stubborn, very ordinary peace. Everything is a negotiation. Most things are also a joke.

**Placement notes.**
- **Grakkus, the Orc Disaster,** is the region's Tyrant. He has smashed two goblin villages and is marching on Moraveil. No quest here kills him; quests 6–10 are about how the two peoples *prepare*, and what they are before he arrives.
- The two founders of the truce, the **goblin child** (now a grown goblin) and the **farmer's daughter** (now a woman), still sit on the joint council. They appear as **Zik Tallowtongue** and **Marra Cobb-Wennick**.
- Humans keep the day-gods; goblins keep spirits of cave and fungus. **Truce Day** is celebrated with a shared feast on the Truce Bridge.
- Earlier pattern quests in this region: *The Beast That Ate the Bridge* (contract) and *First Snow* (Kiri).

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Word for "Truce" | C | OddJob | Pib Wennick | Two languages, one word |
| 2 | Mushrooms and Malice | C | Investigation | Merchant Osgar Pell | A poisoning that isn't |
| 3 | The Worm's Lesson | C | Exploration | Elder Grubnak | What the first digger taught |
| 4 | Ladders and Stairs | C | OddJob | Engineer Fizz Ladderlimb | A lift both sides can use |
| 5 | Sixteen Years of Quiet | B | Faction | Zik Tallowtongue | The founders fall out |
| 6 | The Warband at the Gate | B | Faction | Warband-Captain Skarra | Goblins who want to leave |
| 7 | Drill Day | B | Faction | Marra Cobb-Wennick | A militia in two languages |
| 8 | A Safe Road for a Sick Child | B | Escort | Orc-Mother Hrega | The hills ask for something |
| 9 | Two Children, One Rope | A | Hidden | Zik Tallowtongue | A relic at the Flooded Cave |
| 10 | What the Disaster Left | A | Escort | Refugee-Elder Mok | The smashed villages walk in |

## Cast

<!-- npc
id: npc_pib_wennick
name: Pib Wennick
tier: townsfolk
race: Human
region: reg_moraveil
settlement: Moraveil market town
role: Bilingual schoolgirl, aged eleven
backstory: A bright, anxious eleven-year-old who speaks both Moraveil tongues and has been asked to translate at the joint council, and who is terrified of getting one word wrong.
-->
<!-- npc
id: npc_merchant_osgar_pell
name: Merchant Osgar Pell
tier: major
race: Human
region: reg_moraveil
settlement: Moraveil market town
role: Mushroom merchant accused of poisoning
backstory: A stout, honest mushroom merchant accused of poisoning the goblins' crop, who has never hurt anyone in his life and is mortified.
-->
<!-- npc
id: npc_elder_grubnak
name: Elder Grubnak
tier: major
race: Goblin
region: reg_moraveil
settlement: Moraveil goblin village
role: Cave-elder of the goblin village
backstory: A wizened goblin cave-elder who keeps the old stories of the great worm and has been told by three generations of children that his stories are too long.
-->
<!-- npc
id: npc_fizz_ladderlimb
name: Engineer Fizz Ladderlimb
tier: major
race: Goblin
region: reg_moraveil
settlement: Moraveil goblin village
role: Goblin cliff-engineer
backstory: A cheerful goblin engineer who built every ladder in the cliff-village and has just been asked to build a *stair*, and is deeply insulted and secretly thrilled.
-->
<!-- npc
id: npc_zik_tallowtongue
name: Zik Tallowtongue
tier: major
race: Goblin
region: reg_moraveil
settlement: Moraveil goblin village
role: Goblin councillor, founder of the truce
backstory: The goblin child who pulled a farmer's daughter out of a flooded cave, now a grey, sharp-tongued councillor who has sat on the joint council for forty years and has never once let it win an argument.
-->
<!-- npc
id: npc_warband_captain_skarra
name: Warband-Captain Skarra
tier: major
race: Goblin
region: reg_moraveil
settlement: The Northern Hills
role: Goblin warband captain
backstory: A scarred, proud hill-goblin captain who has marched her warband to Moraveil to join Grakkus and is already, very quietly, having doubts.
-->
<!-- npc
id: npc_marra_cobb_wennick
name: Marra Cobb-Wennick
tier: major
race: Human
region: reg_moraveil
settlement: Moraveil market town
role: Human councillor, founder of the truce
backstory: The farmer's daughter who was pulled from a flooded cave as a child, now a strong, tired councillor with calloused hands and a deep, private debt.
-->
<!-- npc
id: npc_orc_mother_hrega
name: Orc-Mother Hrega
tier: major
race: Orc
region: reg_moraveil
settlement: The Northern Hills
role: Orc mother of a sick child
backstory: A tall, wary orc mother from the northern hills with a feverish child in her arms and no one else left to ask.
-->
<!-- npc
id: npc_refugee_elder_mok
name: Refugee-Elder Mok
tier: major
race: Goblin
region: reg_moraveil
settlement: The Northern Hills road
role: Elder of a smashed goblin village
backstory: A gaunt goblin elder leading three hundred survivors out of two smashed hill villages toward the one place in the world that might take them in.
-->

---

## 1. The Word for "Truce"

*C · OddJob · the Truce Bridge · giver Pib Wennick*

**The short version.** Pib, eleven, has been asked to translate at the joint council. She has found one word that will not cross: *truce.*

**What is really going on.** The human word means *"a stop in fighting."* The goblin word means *"a shared roof."* The councillors have been speaking past each other for forty years and nobody noticed, because everyone nodded.

**Scene 1: the schoolyard.**

**PIB:** "I'm going to get it *wrong.* I know I am."
**PIB:** "They want me to say *truce.* In both languages. But the goblin word isn't *truce.* It's... it's *a thing I don't have a word for.*"
**PIB:** "It's... *roof-together.* It's *the roof we share.* A truce is when the fighting *stops.* A roof-together is when you *stay.*"
> ► **"Is that different?"** — **PIB:** "It's *very* different!"
> ► **"What will you do?"** — **PIB:** "I don't know. Tell them. Or not."
> ► **"I'll help."** — **PIB:** "Thank you. Come early."

**Scene 2: the old ones.** The player asks both councillors what the word means to them.

**MARRA:** "A truce is... a pause. A *rest.* A promise not to hurt each other, *for now.*"
**ZIK:** "A truce is... *a roof.* A thing you build *together.* Something you *keep repairing.*"
**MARRA:** (a long silence) "...I have been saying *rest* for forty years."
**ZIK:** "I have been saying *roof.* We were not *talking* about the same thing."

**Scene 3: the council.** At the joint council, the two founders face each other across the bridge. Pib, with trembling hands, steps forward.

> ► **(Let Pib translate.)** — She says both words, and *explains.*
> ► **(Translate for her.)** — A careful, kind choice.
> ► **(Say nothing.)** — The silence is *its own answer.*

**PIB:** "In human, it means *a pause.* In goblin, it means *a roof.* I think... both are true."
*The council is silent. Then Zik laughs, a rusty sound, and Marra, after a moment, joins.*

**Outcomes and receipt.**
- The two meanings are written into the Truce Day oath: *"We rest, and we build."*
- **Receipt:** a small painted roof on the Truce Bridge; Pib is made Junior Interpreter of the council.

<!-- quest
id: qst_mor_word_truce
title: The Word for "Truce"
rank: C
type: OddJob
giver: npc_pib_wennick
region: reg_moraveil
level: 60
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: mor_word_truce_done
summary: An eleven-year-old translator finds that the human and goblin words for "truce" mean different things.
objectives:
  talk npc_pib_wennick
  reach moraveil_truce_bridge_council
  choice pib_player_or_silence
-->

---

## 2. Mushrooms and Malice

*C · Investigation · the market town · giver Merchant Osgar Pell*

**The short version.** A batch of goblin mushrooms has gone bad, and the goblins blame a human merchant. Osgar is that merchant. He has not poisoned anything, and someone wants the truce to fail.

**What is really going on.** A *neighbouring human lord's* agent has been slipping a harmless blight-spore into the goblin cellars, and a note into Osgar's cart. The goal: a riot on Truce Day, and a reason for the lord to "restore order."

**Scene 1: the stall.**

**OSGAR:** "I sell *mushrooms.* To goblins. They *grow* them. Why would I *poison* them?"
**OSGAR:** "I've done business here thirty years. I have goblin *friends.*"
**OSGAR:** "And yesterday a goblin spat at my stall."
> ► **"Who accuses you?"** — **OSGAR:** "Half the cliff-village."
> ► **"What do you know?"** — **OSGAR:** "Nothing. That's what's *frightening.*"
> ► **"I'll look into it."** — **OSGAR:** "Thank you."

**Evidence.**
- **The spores** are not goblin or human: they are a *lowland* blight, from a lord's estate.
- **The cart-note** is in a fine, educated hand, not Osgar's.
- **A stranger** has been seen near the cellars at night, with a lantern in a *hooded* coat.
- **The goblin cellars** have a small, deliberate hole in the wall.

**Scene 2: the stranger.** The player waits at the cellars. A hooded figure slips out of an alley with a small vial.

**AGENT:** "...Who's there?"
**PLAYER:** "A friend of the market."
**AGENT:** "I don't know what you mean."
> ► **"Stop him."** — A short chase.
> ► **"Follow him."** — A stealth tail to the lord's manor.
> ► **"Ask him who sent him."** — A tense talk.

**Scene 3: the unmasking.** At the Truce Bridge, in front of both councils, the player lays out the evidence: the spores, the note, the hole, the agent.

**ZIK:** "A *lord.* Naturally."
**MARRA:** "We have been *used.*"
**OSGAR:** "I wish I had been *less polite.*"

**Outcomes and receipt.**
- The plot is exposed; the lord's agent is expelled. Goblins and humans share a Truce Day feast with an extra toast for Osgar.
- **Receipt:** a dish of Osgar's mushrooms on the council table; goblin children bring him a cake.

<!-- quest
id: qst_mor_mushrooms_malice
title: Mushrooms and Malice
rank: C
type: Investigation
giver: npc_merchant_osgar_pell
region: reg_moraveil
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: mor_mushrooms_done
summary: A human merchant is accused of poisoning the goblins' mushrooms. Someone else wants the truce to fail.
objectives:
  talk npc_merchant_osgar_pell
  reach moraveil_goblin_cellars_night
  choice stop_follow_or_ask
-->

---

## 3. The Worm's Lesson

*C · Exploration · the deep caves · giver Elder Grubnak*

**The short version.** The goblins say the caves were dug by a great worm that *taught them something.* Nobody remembers what. Elder Grubnak wants to find out before he forgets how to ask.

**What is really going on.** The worm's lesson is *carved* on the wall of its oldest tunnel: a simple mural of one digger, then two, then many, tunnelling *toward each other.* The lesson is *dig together.* It is also a map: the tunnels lead to the Flooded Cave, where the truce began.

**Scene 1: the story.**

**GRUBNAK:** "I tell it *every* Truce Day. *Nobody* listens. It's too long."
**GRUBNAK:** "The great worm dug the caves. She was *kind.* She taught us *something.* The word is lost. The story is *there*, but the *thing* is gone."
**GRUBNAK:** "I would like to know. Before I am *very* old."
> ► **"What's the story?"** — **GRUBNAK:** "It begins: *'Once there was a worm, and she was lonely.'*"
> ► **"How long is it?"** — **GRUBNAK:** "Eleven hours."
> ► **"Let's find it."** — **GRUBNAK:** "I'll bring *snacks.*"

**Scene 2: the tunnel.** A long, quiet descent into the oldest caves. Walls are smooth as glass; every few yards, a deep spiral groove.

**GRUBNAK:** "She dug *this* tunnel. Look at the walls. Not a single *scratch.* All *smooth.*"
**GRUBNAK:** "She didn't *dig.* She *wove* the earth."
*At the tunnel's end, a vast chamber. On the wall, a mural, ancient, bright: a single figure with a pick; then two; then a hundred, all digging toward a single point of light.*
> ► **"Dig together."** — **GRUBNAK:** (very quietly) "...*That's* it."
> ► **"It's a map."** — **GRUBNAK:** "*...Oh.*"
> ► **"It's a warning."** — **GRUBNAK:** "Of what?"

**Scene 3: the point of light.** The tunnels converge on one place: the Flooded Cave. The mural's point of light is the *cave.* The goblins' shrine.

**GRUBNAK:** "...The worm *knew.* She knew, a thousand years ago, that goblins and humans would meet *there.*"
**GRUBNAK:** "She *dug* it for us."

**Outcomes and receipt.**
- The lesson is written into the goblins' Truce Day story. *The player's word* is added: the story is shortened to *eight* hours.
- **Receipt:** a small carving of the worm at the Flooded Cave; Grubnak's story is told by the children, each with their own ending.

<!-- quest
id: qst_mor_worms_lesson
title: The Worm's Lesson
rank: C
type: Exploration
giver: npc_elder_grubnak
region: reg_moraveil
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: mor_worm_done
summary: The goblins' oldest story says a great worm taught them something nobody remembers. The mural at the end of her tunnel says what.
objectives:
  talk npc_elder_grubnak
  reach moraveil_worm_tunnel_mural
  choice dig_map_or_warning
-->

---

## 4. Ladders and Stairs

*C · OddJob · the cliff-village · giver Engineer Fizz Ladderlimb*

**The short version.** The humans want a *stair* up the cliff to the goblin village. The goblins have *ladders.* Both are *very* proud. The council has asked Fizz to design a lift.

**What is really going on.** Neither side will use the other's design. The solution is neither ladder nor stair; it is a **counterweight lift** both peoples can *share*, and *both peoples must* build *together* or it will not work.

**Scene 1: the workshop.**

**FIZZ:** "A *stair.* They want a *stair.* I've built four hundred ladders. A stair is just a ladder that *gave up.*"
**FIZZ:** "But a *lift...* That's *interesting.* A lift needs a *weight.* And a weight needs *two sides.*"
> ► **"What do you need?"** — **FIZZ:** "A human *engineer.* One who doesn't mind being called *'big folk.'*"
> ► **"What's the catch?"** — **FIZZ:** "The lift only works if *both* sides pull."
> ► **"I'll find one."** — **FIZZ:** "Splendid."

**Scene 2: the partner.** A human engineer, **Beatrix Stonegate**, arrives with a rolled plan.

**BEATRIX:** "I'm not sure I can *work* with a goblin. No offence."
**FIZZ:** "None taken. I'm not sure I can work with a *human.* No offence."
**BEATRIX:** "..."
**FIZZ:** "..."
*The player sets two stools side by side and a very large pile of rope between them.*

**Scene 3: the building.** A comic, warm montage. The two argue over knots, units, whether a cart should have *wheels* or *runners.* By the end of the first day, they have each stopped *looking* at the plan and started *looking at each other.*

**FIZZ:** "She *swears* in *three languages.*"
**BEATRIX:** "He builds like he's *dancing.*"

**Scene 4: the first ride.** At dusk, the lift stands against the cliff. A human child and a goblin child stand together on the platform. The two engineers each pull a rope. The platform *rises.*

**CHILD (goblin):** "It's *going up!*"
**CHILD (human):** "It's *both* going up!"

**Outcomes and receipt.**
- The lift is built; both sides may use it. If the player takes sides in the argument, the lift is built, *grudgingly.*
- **Receipt:** a plank with two names carved on it; the lift's bell has two tones.

<!-- quest
id: qst_mor_ladders_stairs
title: Ladders and Stairs
rank: C
type: OddJob
giver: npc_fizz_ladderlimb
region: reg_moraveil
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: mor_ladders_done
summary: The humans want a stair up to the goblin village; the goblins have ladders. A counterweight lift needs both sides to pull.
objectives:
  talk npc_fizz_ladderlimb
  reach moraveil_cliff_lift_site
  choice mediate_side_or_dance
-->

---

## 5. Sixteen Years of Quiet

*B · Faction · the Truce Bridge · giver Zik Tallowtongue*

**The short version.** The two founders of the truce have not spoken to each other for sixteen years. They still sit side by side at council. Zik asks the player to find out why.

**What is really going on.** Sixteen years ago, Marra missed Zik's daughter's wedding, because a human farm-fire needed her. Zik took it as a *rejection.* Marra, ashamed, never apologised. They have both *wanted to* every day since.

**Scene 1: the council chamber.**

**ZIK:** "Forty years on this council. Sixteen *without a word.*"
**ZIK:** "We *vote.* We *nod.* We *argue.* But we do not *talk.*"
**ZIK:** "I would like to know why. *I* know why. But I would like *her* to say it."
> ► **"What happened?"** — **ZIK:** "A wedding."
> ► **"What do you want?"** — **ZIK:** "For her to *explain.*"
> ► **"I'll ask her."** — **ZIK:** "Be gentle. She is *proud.*"

**Scene 2: Marra.** In her farmhouse kitchen, a tired woman sits with a cup of tea gone cold.

**MARRA:** "Sixteen years. I *wanted* to say it. But what do I say? *'I'm sorry I missed your daughter's wedding'?* It's been *sixteen years.*"
**MARRA:** "The barn was on fire. I had to go. I *chose.* And I never explained."
> ► **"Tell her."** — **MARRA:** "I can't."
> ► **"Write her."** — **MARRA:** "...A letter?"
> ► **"I'll carry a message."** — **MARRA:** "...Please."

**Scene 3: the exchange.** Over three days, the player carries a small, trembling series of messages. A pressed flower. A jar of mushroom jam. A single line, in *goblin script,* from Marra: *"Roof-together."*

**ZIK:** (reading, very still) "...She learned the *word.*"
**ZIK:** "She learned the goblin *word.*"

**Scene 4: the bridge.** At dusk, on the Truce Bridge, the two old women stand a few feet apart, as they have for sixteen years. Neither speaks. Then Marra, very slowly, takes a step closer.

**MARRA:** "I'm sorry."
**ZIK:** "I know. I've known for *sixteen years.*"
**MARRA:** "Then why did you *wait?*"
**ZIK:** "Because *you were the one who had to say it.*"
*They stand side by side, looking at the river, saying nothing, perfectly comfortable.*

**Outcomes and receipt.**
- The founders speak again; council meetings become *shorter* and *far* more productive. If the player pushed too hard, the reconciliation takes longer.
- **Receipt:** two chairs side by side on the bridge; a loaf of bread from Marra to Zik every Truce Day.

<!-- quest
id: qst_mor_sixteen_years
title: Sixteen Years of Quiet
rank: B
type: Faction
giver: npc_zik_tallowtongue
region: reg_moraveil
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: mor_sixteen_done
summary: The two founders of the truce haven't spoken for sixteen years. One of them wants to know why the other never said sorry.
objectives:
  talk npc_zik_tallowtongue
  talk npc_marra_cobb_wennick
  choice tell_write_or_carry
-->

---

## 6. The Warband at the Gate

*B · Faction · the Northern Hills · giver Warband-Captain Skarra*

**The short version.** A hill-goblin warband has marched to Moraveil to join Grakkus. Their captain has asked for a parley. She says it is to *announce* their decision. She is lying, a little.

**What is really going on.** Skarra's warband feel *betrayed.* The Moraveil goblins have *gone soft* in the eyes of the hills; the hills have been *raided* by the very orcs the truce was meant to keep away. They want to *belong* to something. They are not *sure* it is Grakkus.

**Scene 1: the parley.**

**SKARRA:** "I am Skarra. I have eighty warriors. We have come to join the Disaster."
**SKARRA:** "We are *tired.* Tired of being *small.*"
**SKARRA:** "Say what you want. But I have *made up my mind.*"
> ► **"Why Grakkus?"** — **SKARRA:** "Because he *wins.*"
> ► **"What do you want?"** — **SKARRA:** "To not be *afraid.*"
> ► **"Tell me about your warband."** — **SKARRA:** "...Eighty. Most are *young.*"

**Scene 2: the warband.** The player walks through the camp. A dozen warriors, each with a reason.
- **A young goblin**, *Pug*: "My village was smashed. I want *revenge.*"
- **An old one**, *Dura*: "I fought in the *cave war.* I don't want to *do it again.*"
- **A scout**, *Nix*: "I don't want to join *anyone.* But there's *nowhere else.*"
- **Skarra's lieutenant**, *Ghol*: "She's *wavering.* Don't say I said."

**Scene 3: the argument.** The player must speak to the whole warband in a *single* scene, answering three challenges:

> ► **"Grakkus will smash your villages."** — **PUG:** "He's smashed them *already.*"
> ► **"Moraveil will protect you."** — **DURA:** "Will it? Really?"
> ► **"You don't have to choose either."** — **NIX:** "...What does that *mean*?"

**Scene 4: the offer.** The player makes an offer: *a place in the Moraveil militia, under their own captain.* Skarra, after a long pause, laughs.

**SKARRA:** "A warband. In a *human* militia."
**SKARRA:** "*That* I did not expect."
*She plants her spear in the ground, point down.*

**Outcomes and receipt.**
- The warband joins the Moraveil militia (or *half* of it does, if the player's argument was weak). Skarra takes a seat on a council subcommittee, scowling.
- **Receipt:** a goblin war-banner flies beside the human one on the Truce Bridge; Skarra's warband sing hill-songs on Truce Day.

<!-- quest
id: qst_mor_warband_gate
title: The Warband at the Gate
rank: B
type: Faction
giver: npc_warband_captain_skarra
region: reg_moraveil
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: mor_warband_done
summary: A hill-goblin warband has marched to Moraveil to join Grakkus. Their captain asks for a parley she half-regrets.
objectives:
  talk npc_warband_captain_skarra
  reach moraveil_warband_camp
  choice smash_protect_or_neither
-->

---

## 7. Drill Day

*B · Faction · the market town · giver Marra Cobb-Wennick*

**The short version.** The council wants a *joint* militia, goblins and humans, trained together, before Grakkus arrives. Marra has one week. She has two languages, no army and a lot of doubt.

**What is really going on.** The drills are less about fighting than about *shouting the same words.* The militia must learn a handful of commands in *both* tongues, and learn to *trust the other side to hear them.*

**Scene 1: the field.**

**MARRA:** "A hundred and forty. Seventy human. Seventy goblin. They've never stood in a line together."
**MARRA:** "Drill them. Not for *fighting.* For *listening.*"
**MARRA:** "If they can follow a command in the other's tongue, they can follow it in the *dark.*"
> ► **"What commands?"** — **MARRA:** "Stop. Hold. Back. Left. Right. Now."
> ► **"How long?"** — **MARRA:** "A week."
> ► **"I'll drill them."** — **MARRA:** "Good. Don't *shout.* They'll copy you."

**Scene 2: the drill.** A short, funny, warm montage. The first day is a disaster: *"Left"* in goblin sounds, to a human, like *"retreat."* A goblin and a human tangle in a hedge. A sergeant weeps.

*(Gameplay: a drill mini-game in which the player calls commands in both languages; success depends on *patience*, not speed.)*

**SERGEANT (human):** "It means *'hold.'* I've been saying *'back.'*"
**SERGEANT (goblin):** "It means *'back.'* I've been saying *'hold.'*"
**BOTH:** "...*Oh.*"

**Scene 3: the night drill.** On the sixth night, the player calls a drill in total darkness. The militia stands in a field, listening.

**PLAYER:** "*Hold.*"
*The line holds.*
**PLAYER:** "*Left.*"
*They turn, in two languages, at once.*

**Scene 4: the parade.** On the seventh day, at dawn, the militia marches through the market in a long, ragged, magnificent line.

**MARRA:** (hoarse) "...They're *in step.*"
**MARRA:** "They are *actually* in step."

**Outcomes and receipt.**
- A joint militia of a hundred and forty is ready. If the player rushed the drill, the militia is ready but *edgy.*
- **Receipt:** a small drum on the Truce Bridge with two drumheads, one human, one goblin; the militia sings a two-language marching song.

<!-- quest
id: qst_mor_drill_day
title: Drill Day
rank: B
type: Faction
giver: npc_marra_cobb_wennick
region: reg_moraveil
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: mor_drill_done
summary: The council wants a joint goblin-human militia trained in a week, in two languages, before Grakkus arrives.
objectives:
  talk npc_marra_cobb_wennick
  defend moraveil_drill_field
  choice patient_rushed_or_night
-->

---

## 8. A Safe Road for a Sick Child

*B · Escort · the Northern Hills · giver Orc-Mother Hrega*

**The short version.** An orc mother from the hills has come to Moraveil with a feverish child. She has heard that the goblin healers are the best in the world. She has also heard that goblins hate orcs.

**What is really going on.** Orcs and goblins have a long, ugly history. Hrega is *terrified.* The goblin healer, **Old Moss**, will treat the child, *if* the player can walk Hrega across the Truce Bridge and past a *crowd.*

**Scene 1: the road.**

**HREGA:** "My daughter is *dying.* I heard there is a healer in the cliff-village."
**HREGA:** "I am an orc. I will be *killed.*"
**HREGA:** "I did not come for *peace.* I came for *medicine.*"
> ► **"I'll walk with you."** — **HREGA:** "Why?"
> ► **"What's wrong with her?"** — **HREGA:** "A cough. A fever. It's been nine days."
> ► **"What will you pay?"** — **HREGA:** "Whatever it costs."

**Scene 2: the bridge.** At the Truce Bridge, a small crowd has gathered. Humans, goblins, a few muttering. A goblin spits. An old human woman crosses herself.

**CROWD:** "An *orc.*"
**CROWD:** "*Grakkus's* folk."
**HREGA:** (very quietly, to the player) "...I told you."
> ► **"She's a mother."** — **CROWD:** (a long silence) "...*That's* a mother."
> ► **"Stand aside."** — A tense moment.
> ► **"Let her through. I'll vouch."** — **MARRA (from the crowd):** "...I'll vouch too."

**Scene 3: the healer.** In a cave-hospital lit by glow-fungi, an ancient goblin woman peers at the sick child.

**OLD MOSS:** "Hm. Cave-fever. I've seen it a hundred times. Bring her *in.*"
**OLD MOSS:** "Orc, goblin, human. A fever doesn't *care.*"
**HREGA:** (a sob) "...Thank you."
*For three days, Hrega sits at the child's bedside, and the goblin women of the cliff-village bring her stew. She does not eat it. On the third day, she does.*

**Scene 4: the leaving.** The child is well. At the Truce Bridge, Hrega pauses.

**HREGA:** "I did not expect... *this.*"
**HREGA:** "Tell them in the hills. About the bridge. About the stew."
**HREGA:** "Not all of us are Grakkus."

**Outcomes and receipt.**
- The child recovers; Hrega returns to the hills as the first orc *friend* of Moraveil. If the crowd was not persuaded, the player must carry the child *alone.*
- **Receipt:** an orc-sized chair on the Truce Bridge; a bundle of hill-herbs left each season at the cliff-village.

<!-- quest
id: qst_mor_sick_child
title: A Safe Road for a Sick Child
rank: B
type: Escort
giver: npc_orc_mother_hrega
region: reg_moraveil
level: 98
act: 4
requires_rank: B
reward: 12000 | 700 | 52000
sets: mor_child_done
summary: An orc mother brings a feverish child to Moraveil's goblin healers, and must cross a bridge with a crowd.
objectives:
  talk npc_orc_mother_hrega
  escort npc_orc_mother_hrega
  reach moraveil_cave_hospital
  choice mother_stand_aside_or_vouch
-->

---

## 9. Two Children, One Rope

*A · Hidden · the Flooded Cave · giver Zik Tallowtongue*

**The short version.** Truce Day is a week away. The founders want to recover the *rope* that pulled the farmer's daughter out of the cave, forty years ago, and hang it on the Truce Bridge as a relic.

**What is really going on.** The rope is still in the Flooded Cave, wedged in a crevice, frayed and grey. The cave is flooded *again.* The founders, now old, cannot go. They ask the player to bring it out, and *tell* the story of how it was.

**Scene 1: the shrine.**

**ZIK:** "It was a *rainy* day. I was ten. I heard a *girl* screaming in a cave."
**ZIK:** "I climbed down. She was *stuck.* I found a rope. I *tied it round* her. And I *pulled.*"
**MARRA:** "I was *nine.* I thought I was going to die."
**MARRA:** "A *goblin.* A *goblin* saved me."
> ► **"Where's the rope?"** — **ZIK:** "In the crevice. Third chamber."
> ► **"Why now?"** — **MARRA:** "Because we're *old.*"
> ► **"I'll fetch it."** — **ZIK:** "Thank you. Be *quiet.* It's a *shrine.*"

**Scene 2: the cave.** A long, careful descent into the flooded dark. Water laps at the player's knees; the walls glitter with fungus-light. In the third chamber, a crevice, and, in it, a grey, frayed rope, still knotted.

*(Gameplay: a quiet, atmospheric dive. No combat. The player must find the rope without disturbing the shrine's offerings.)*

**Scene 3: the offerings.** Along the cave floor, small offerings left by the goblins: shells, mushroom caps, little carved figures of a girl and a goblin, hand in hand.

**PLAYER (reading a small plaque):** *"Here the roof began."*

**Scene 4: the rope.** The player brings the rope out. At the cave mouth, two very old women wait.

**MARRA:** (taking it, hands shaking) "...It's *smaller* than I remembered."
**ZIK:** "I was *smaller* than I remembered."
*They tie it between them, a short length each, and, together, they hold it up for the whole Truce Day crowd to see.*

**Outcomes and receipt.**
- The rope hangs on the Truce Bridge for the feast. *If the player tells the story* in their own words, it is added to the ritual.
- **Receipt:** a small glass case on the bridge, with a frayed grey rope and two small, handwritten cards.

<!-- quest
id: qst_mor_two_children_rope
title: Two Children, One Rope
rank: A
type: Hidden
giver: npc_zik_tallowtongue
region: reg_moraveil
level: 126
act: 4
requires_rank: A
requires_quests: qst_mor_sixteen_years
reward: 30000 | 1500 | 130000
sets: mor_rope_done
summary: The two founders want the rope that pulled a child from the Flooded Cave forty years ago, to hang on the Truce Bridge.
objectives:
  talk npc_zik_tallowtongue
  reach moraveil_flooded_cave_third_chamber
  choice return_tell_or_silence
-->

---

## 10. What the Disaster Left

*A · Escort · the Northern Hills road · giver Refugee-Elder Mok*

**The short version.** Three hundred survivors of two smashed goblin villages are walking toward Moraveil. They have no food. They have no weapons. They have a very old elder, who is sure no one will take them.

**What is really going on.** Grakkus has left a trail of destruction through the hills. The refugees are *slow,* and a scattering of his orc stragglers is behind them. The player must guide them *across* the hills to the Truce Bridge, past wolves, cold and the raw, grieving silence of people who have lost everything.

**Scene 1: the road.**

**MOK:** "Three hundred and eleven. We started with *nine hundred.*"
**MOK:** "We have no food. We have no *home.* We have, I think, a rumour: *that there is a place where goblins and humans live together.*"
**MOK:** "Is it true?"
> ► **"It's true."** — **MOK:** "Then we will *walk.*"
> ► **"It's complicated."** — **MOK:** "Everything *is.*"
> ► **"Rest first."** — **MOK:** "We cannot *stop.*"

**Scene 2: the walk.** A long, slow, heart-heavy escort. Three days. The player helps the weak, shares food, fends off wolves, and sits with the grieving at night. Each small moment is a short scene:
- **A child** who has stopped speaking.
- **A mother** carrying a bundle that is *not* a child.
- **A very old goblin** who sings the cave-songs, softly, in the dark.

**MOK:** "We do not *know* where we are going. But we know where we have *been.*"

**Scene 3: the stragglers.** On the third night, a handful of Grakkus's orc stragglers close in. The player must hold them off, *or* talk them down, *or* lead them away.

**ORC STRAGGLER:** "We're hungry. We're *tired.* We don't even like the *Disaster.*"
> ► **"Fight them."** — A short, hard skirmish.
> ► **"Feed them."** — **ORC STRAGGLER:** "...*What?*"
> ► **"Turn them back."** — A tense talk.

**Scene 4: the bridge.** At dawn on the fourth day, the Truce Bridge rises out of the mist. On the far side, a line of humans and goblins stand, silent, holding bread.

**MARRA:** "Welcome."
**ZIK:** "Come in. *Come in.*"
*Three hundred and eleven people cross the bridge, one at a time. Nobody speaks. The old goblin elder stops at the middle, looks down at the river and begins, very quietly, to sing.*

**Outcomes and receipt.**
- The survivors are housed; the human houses of Moraveil open their doors. The number who arrive depends on the player's care (up to three hundred and eleven).
- **Receipt:** a new quarter in the cliff-village, called *"The Walked-In"*; a bridge-song is added to Truce Day.

<!-- quest
id: qst_mor_disaster_left
title: What the Disaster Left
rank: A
type: Escort
giver: npc_refugee_elder_mok
region: reg_moraveil
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: mor_refugees_done
summary: Three hundred survivors of two smashed goblin villages are walking toward Moraveil with nothing, and an escort is needed.
objectives:
  talk npc_refugee_elder_mok
  escort npc_refugee_elder_mok
  reach moraveil_truce_bridge
  choice fight_feed_or_turn
-->
