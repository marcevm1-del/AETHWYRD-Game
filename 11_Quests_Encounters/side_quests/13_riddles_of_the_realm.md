# 11e-13 — Riddles of the Realm: Five Puzzle Quests (draft)

> *"A good puzzle is a conversation with a place."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 3 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** A multi-stage puzzle, where *each stage uses a different idea*, and where a short riddle or a landmark points to the next place. Each puzzle is built on **rules Ascend already has**: element auras and reactions (fire, frost, storm, water), rhythm and timing, light, and reading a place. Each tells a *small story* once solved.

**Accessibility (Canon §6, guidance channels).** Every puzzle has **three hint tiers**, chosen by the player: **Nudge** (a world cue), **Hint** (a Journal note naming the idea), and **Show me** (the puzzle is solved and *narrated*, with the story intact). Combat is never required to progress. A player may skip a puzzle and still receive its story from the giver, at a lower reward.

**Rules.** No timer; no punishment; mistakes reset a stage, not the quest. Rewards follow the standard rank table; the story is the reward.

| # | Quest | Rank | Region | Core idea |
|---|---|---|---|---|
| 1 | Six Lanterns of the Examination Hall | B | Haneul | Order and meaning |
| 2 | The River That Remembered Its Bed | B | Zarvan | Element reactions on water |
| 3 | The Thread That Hums | C | Umbravel | Pitch and sequence |
| 4 | The Ball Court of the River-Kings | B | Xochitl Mire | Rhythm, rule, ritual |
| 5 | Cairn of Winds | B | Stormreach | Routing lightning |

## Cast

<!-- npc
id: npc_lantern_examiner_gyeong
name: Lantern-Examiner Gyeong
tier: major
race: Human
region: reg_haneul
settlement: Haneul
role: Keeper of the Examination Hall's six lanterns
backstory: A dry, courteous examiner who has relit the same six lanterns every dawn for thirty years and has recently begun to wonder what they are *for*.
-->
<!-- npc
id: npc_master_azar
name: Master Azar
tier: major
race: Human
region: reg_zarvan
settlement: Garden cities
role: Aqueduct engineer
backstory: A methodical aqueduct engineer who maintains four hundred miles of canal and has noticed that one old channel keeps trying to run where no one dug it.
-->
<!-- npc
id: npc_nadira_duskthread
name: Weaver Nadira Duskthread
tier: major
race: Dark elf
region: reg_umbravel
settlement: Umbravel
role: Master silk-weaver
backstory: A precise, dry-humoured dark-elf weaver who has been tuning the city's hanging threads for sixty years and has found one that will not stay in tune.
-->
<!-- npc
id: npc_priest_citlalin
name: Priest-Astronomer Citlalin
tier: major
race: Human
region: reg_xochitl_mire
settlement: River-cities
role: Priest-astronomer of the ball court
backstory: A bright-eyed priest-astronomer who keeps the calendar of ceremonies and has realised that one ceremony, the oldest, has not been played in four hundred years.
-->
<!-- npc
id: npc_bryn_galehand
name: Storm-Caller Bryn Galehand
tier: major
race: Human
region: reg_stormreach
settlement: Stormreach cliff-towns
role: Storm-caller
backstory: A cheerful, slightly singed storm-caller who reads the weather like a book and has a bet with the sea about when it will next be calm.
-->

---

## 1. Six Lanterns of the Examination Hall

*B · Investigation · Haneul · giver Lantern-Examiner Gyeong*

**The setup.** In the great Examination Hall, six lanterns hang in a row, each carved with a different virtue: *Diligence, Honesty, Humility, Courage, Mercy, Curiosity.* For thirty years Gyeong has lit them in the same order, every dawn. This morning, lighting them in the usual order, the hall's doors would not open.

**Scene 1: Gyeong.**

**GYEONG:** "I light them in the order the examiners were taught. *Diligence, Honesty, Humility, Courage, Mercy, Curiosity.* Thirty years."
**GYEONG:** "This morning the doors would not open. There is a poem on the lintel I have never read properly."
> ► **"What does the poem say?"** — **GYEONG:** "It says: *Begin where the learned stop.*"
> ► **"What did you change?"** — **GYEONG:** "Nothing. That is the problem."

**Puzzle (3 stages).**
- **Stage 1: the lintel.** Read the poem and the six virtues. *"Begin where the learned stop"* suggests the order is *reversed from the traditional.* The player lights **Curiosity** first.
- **Stage 2: the order.** The poem's remaining lines name each virtue by what it *does for the one after it*: Curiosity asks; Mercy listens; Courage speaks; Humility bows; Honesty corrects; Diligence returns. The player lights them in that order.
- **Stage 3: the sixth door.** After the sixth lantern, a *seventh* niche appears. It holds an *unlit* lantern and a slip: *"For the examiner."* The player lights it *for Gyeong.*

**Hints.** *Nudge:* the lintel poem glows faintly when the player faces it. *Hint:* the Journal records *"The order is reversed."* *Show me:* the lanterns light themselves in sequence and the player hears the poem read aloud.

**Scene 2: the seventh.**

**GYEONG:** "...The seventh lantern. I did not know there was one."
**GYEONG:** "It's for the examiner. It is the lantern one lights *after* the candidates. To remind us that we are *also* being examined."
*The doors swing wide. A soft gold light spills out. Gyeong, to his surprise, laughs.*
**GYEONG:** "Thirty years. I have been starting at the *wrong end.*"
> ► **"What will you do now?"** — **GYEONG:** "Begin at the right one."

**Outcomes and receipt.**
- The hall opens; a new custom begins: the seventh lantern is lit for the *examiners* each dawn.
- **Receipt:** a seventh lantern hangs in the hall; a small card: *"For those who ask."*

<!-- quest
id: qst_pat_riddle_six_lanterns
title: Six Lanterns of the Examination Hall
rank: B
type: Investigation
giver: npc_lantern_examiner_gyeong
region: reg_haneul
level: 90
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: pat_riddle_six_lanterns_done
summary: The Examination Hall's doors will not open when its six virtue-lanterns are lit in the usual order. A poem on the lintel says to begin where the learned stop.
objectives:
  talk npc_lantern_examiner_gyeong
  reach haneul_exam_hall_lintel
  reach haneul_six_lanterns 6
  choice light_the_seventh
-->

---

## 2. The River That Remembered Its Bed

*B · Exploration · the Garden Cities · giver Master Azar*

**The setup.** In Zarvan, the great aqueducts are older than the kingdom. One old channel, dry for centuries, keeps trying to flood. The engineer has noticed a pattern: water *wants* to run to a particular place.

**Scene 1: the dry bed.**

**AZAR:** "Four hundred miles of canal. I maintain every inch. And one channel, which does not exist on any plan, floods after every storm."
**AZAR:** "It runs to a garden that is not on the map."
**AZAR:** "Water *remembers.* Treaties signed in it are forgotten. But the *bed* remembers. I would like you to help me open the way."
> ► **"What garden?"** — **AZAR:** "I think it is the *first.* The first garden in Zarvan."
> ► **"What do I do?"** — **AZAR:** "Three sluices. Three tricks. Bring the right element."

**Puzzle (3 stages).**
- **Stage 1: the first sluice.** A frozen channel blocks the water. **Fire** melts it, but too quickly the water floods the wrong way. The player must use **small, steady flame** (a lantern, not a bomb) to melt the ice slowly.
- **Stage 2: the second sluice.** A rusted gate, jammed with root. **Water + frost** *(freeze-and-shatter reaction)*: flood the gate, freeze it, and crack it, leaving the root brittle.
- **Stage 3: the third sluice.** A silted weir. **Storm** *(a charged strike)* shakes the silt loose; the water runs clear.

**Hints.** *Nudge:* the water ripples toward the next sluice. *Hint:* the Journal notes the *element* needed. *Show me:* the water solves itself, the narration explaining each reaction.

**Scene 2: the first garden.** Following the water, the player and Azar come to a walled terrace choked with weeds and old stone. At its heart, a dry fountain, and a carved line:

*"We signed in water. May the water remember us when we cannot."*

**AZAR:** "The treaties. The *first* ones. Between the div-kings and the first gardeners."
**AZAR:** "They carved them *here.* On the one thing water cannot wash away."
*Water rushes in, fills the fountain, spills over the stone. The old garden, for the first time in centuries, drinks.*
> ► **"What does it mean?"** — **AZAR:** "That the water was *keeping its word.* Every spring, trying to come home."
> ► **"Will the div-king care?"** — **AZAR:** (carefully) "...I do not *know.*"

**Outcomes and receipt.**
- The first garden is restored; a water-gift is made. If the player chooses, the treaty stone is *copied* for the garden-guild.
- **Receipt:** a small, bright fountain in the first garden; a new aqueduct plan hangs in Azar's office, with one channel marked *"remembered."*
- **Canon-safe:** this adds the *carved treaty text* only; it does not explain the Div King's claim.

<!-- quest
id: qst_pat_riddle_river_bed
title: The River That Remembered Its Bed
rank: B
type: Exploration
giver: npc_master_azar
region: reg_zarvan
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: pat_riddle_river_bed_done
summary: A dry, unmapped aqueduct keeps trying to flood toward a garden that is not on any plan. Three sluices, three elements.
objectives:
  talk npc_master_azar
  reach zarvan_three_sluices 3
  reach zarvan_first_garden
  choice copy_the_stone
-->

---

## 3. The Thread That Hums

*C · Investigation · Umbravel · giver Weaver Nadira Duskthread*

**The setup.** Umbravel's webs hold up the city, and every strand is tuned. One thread, high above the central bridge, will not stay in tune. It hums a single note, and no weaver can say why.

**Scene 1: the loom-house.**

**NADIRA:** "Sixty years I have tuned this city. Every thread has a pitch. Every pitch has a *place.* This one..."
*She plucks the air. A thin, wavering note, almost a hum.*
**NADIRA:** "It is *wrong.* Which is why I like it."
> ► **"What's it for?"** — **NADIRA:** "I think it is *half a song.*"
> ► **"Where does it lead?"** — **NADIRA:** "Up. Into the dark above the bridge."

**Puzzle (3 stages).**
- **Stage 1: the thread.** Climb the web, and find the humming thread. Pluck it: it gives **one note** (say, A).
- **Stage 2: the six.** Around the humming thread hang **five more threads**, each tuned a different pitch. Plucking them in the right sequence builds a *melody*; the sequence is hinted by the *length of each thread* (longest = lowest). The player must pluck from longest to shortest.
- **Stage 3: the chest.** The melody opens a small silk pouch at the web's heart. Inside: a *loom-weight*, a *skein of silver thread* and a *tiny scroll.*

**Hints.** *Nudge:* lower threads *sound* lower as the player nears. *Hint:* the Journal notes "pluck longest to shortest." *Show me:* the melody plays itself and the pouch opens.

**Scene 2: the scroll.** Back in the loom-house, Nadira unrolls the scroll with trembling hands.

*"To whoever finds this: I could not finish the lullaby. My daughter is asleep in the dark below. If you hear it, sing it to her. — Anya Duskthread."*

**NADIRA:** (very quietly) "...That is my mother's hand."
**NADIRA:** "She died when I was a child. They said there was no song."
**NADIRA:** "She hid it in the *web.*"
> ► **"Sing it."** — Nadira does, hoarse, low, in the dark elven tongue.
> ► **"Play it on the thread."** — The web hums the whole lullaby.
> ► **"Tell me about her."** — **NADIRA:** "She was *very* precise. And very afraid."

**Scene 3: the lullaby.** That night, from the highest thread of the bridge, the whole web sings the lullaby, a long, low, silver note that spreads across the city. In the darkness, the lantern-silk glows.

**NADIRA:** "...Thank you."

**Outcomes and receipt.**
- The lullaby is added to Umbravel's evening bells; a quiet city sings along. If the player plays only the melody (no words), Nadira keeps the words private.
- **Receipt:** a silver thread hangs over the bridge; a small silk pouch in the player's Journal.

<!-- quest
id: qst_pat_riddle_thread_hums
title: The Thread That Hums
rank: C
type: Investigation
giver: npc_nadira_duskthread
region: reg_umbravel
level: 70
act: 3
requires_rank: C
reward: 4300 | 240 | 16000
sets: pat_riddle_thread_hums_done
summary: One thread in Umbravel's web hums a single wrong note. Five more threads, plucked in order, open a pouch with a mother's unfinished lullaby.
objectives:
  talk npc_nadira_duskthread
  reach umbravel_humming_thread
  reach umbravel_five_threads 5
  choice sing_play_or_listen
-->

---

## 4. The Ball Court of the River-Kings

*B · Exploration · the river-cities · giver Priest-Astronomer Citlalin*

**The setup.** The old river-kings *fed the swamp* so that it would not feed on them (Gazetteer). The tradition lapsed. One ceremony, the oldest, was a ball-game played on a hidden court. Citlalin has found the court.

**Scene 1: the stars.**

**CITLALIN:** "Every ceremony has a date, a god and a *game.* The oldest has no date. It has only a *court.*"
**CITLALIN:** "The river-kings played it once a generation. The ball was a heart; the goal was the swamp. They never lost. They *fed* it."
**CITLALIN:** "I would like to play once. *With someone.* A court needs two."
> ► **"What are the rules?"** — **CITLALIN:** "There are three. I have forgotten *one.*"
> ► **"What does the swamp want?"** — **CITLALIN:** "To be remembered."

**Puzzle (3 stages).**
- **Stage 1: the court.** A long stone court, flooded knee-deep. Three hoops hang at different heights. The ball is a *heavy rubber sphere* that must be passed, not carried.
- **Stage 2: the rhythm.** A drum beats on the court's edge. The ball may only be struck *on the beat*; the player and Citlalin must pass, strike and receive in time. The beat *quickens* each round.
- **Stage 3: the third rule.** Citlalin's forgotten rule is revealed when the player *deliberately misses*: **the ball must be given.** At the final hoop, the player lets the ball *drop* into the swamp-water.

**Hints.** *Nudge:* the drum's beat is audible from the first hoop. *Hint:* the Journal notes *"a rule has not been found."* *Show me:* the game plays itself and the third rule is narrated.

**Scene 2: the match.** The pair play a slow, ceremonial, beautiful match. The swamp stirs. A faint green light rises from the water. Beneath the surface, vast, ancient shapes turn.

**CITLALIN:** (breathless) "...It's *watching.*"
> ► **"Give the ball."** — The ball sinks, glowing.
> ► **"Keep playing."** — The beat quickens, dangerous.
> ► **"Ask the swamp."** — A voice like wet leaves answers.

**Scene 3: the answer.** As the ball sinks, the swamp *breathes.* A long, slow sigh. The water clears, and for a moment, the whole court is a perfect, bright mirror.

**CITLALIN:** "It's *not* hungry. It's *lonely.*"
**CITLALIN:** "We stopped playing. It thought we had *died.*"

**Outcomes and receipt.**
- The ceremony is restored: the river-cities agree to play once a year. The swamp is *calmer* for a season (a regional state, not a buff).
- **Receipt:** a stone ball sits at the court's centre; Citlalin carves the third rule into the wall.
- **Canon-safe:** the quest does not touch Xibalbar, the hydra.

<!-- quest
id: qst_pat_riddle_ball_court
title: The Ball Court of the River-Kings
rank: B
type: Exploration
giver: npc_priest_citlalin
region: reg_xochitl_mire
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: pat_riddle_ball_court_done
summary: A priest has found the hidden court of the river-kings' oldest ceremony, a ball-game with three rules, one forgotten.
objectives:
  talk npc_priest_citlalin
  reach xochitl_hidden_court
  reach xochitl_three_hoops 3
  choice give_keep_or_ask
-->

---

## 5. Cairn of Winds

*B · Exploration · the cliff-towns · giver Storm-Caller Bryn Galehand*

**The setup.** The lightning-rods in Stormreach were built after the first ones worked. At the top of the highest cliff, a cairn of stones with a bolted iron door, and a storm brewing. Bryn has a bet with the sea.

**Scene 1: the cliff.**

**BRYN:** "I read the sky. It says: ten minutes of calm, then the biggest bolt of the year."
**BRYN:** "That cairn has a door. It has had a door since the first bolts. Nobody has opened it. I think a bolt will."
**BRYN:** "I would like *you* to decide where it strikes."
> ► **"How?"** — **BRYN:** "Rods. Chains. A little luck."
> ► **"Is it dangerous?"** — **BRYN:** "Very."
> ► **"I'll try."** — **BRYN:** "*Splendid!* Stand over there."

**Puzzle (3 stages).**
- **Stage 1: the rods.** Five iron rods stand at different heights around the cairn. The storm will strike the *tallest.* The player must *raise or lower* rods so that the bolt falls on the **centre rod**.
- **Stage 2: the chain.** The centre rod is not connected to the door. The player must lay **three iron chains** along the stone so the current travels *round* the cairn, not through it.
- **Stage 3: the door.** The bolt strikes; the door's lock *charges*; the player must *touch* the lock with a *grounded* tool (an iron nail or a wooden handle) at the right moment.

**Hints.** *Nudge:* the wind sings through the rods; the tallest hums. *Hint:* the Journal notes "the bolt takes the tallest." *Show me:* the bolt is steered and narrated.

**Scene 2: the bolt.** The storm breaks. A white-hot bolt crashes into the centre rod, runs round the chains, and slams into the iron door. The door *rings*, and swings open.

**BRYN:** (whooping) "*I won my bet!*"
**BRYN:** "The sea said: calm in ten minutes. *I said: bolts.*"
*Inside the cairn, on a small stone shelf, a battered notebook and a coil of copper wire.*

**Scene 3: the notebook.** The notebook belongs to the first rod-builder, a woman named **Ulla**, who recorded the day the lightning first *obeyed.*

*"Today I stood on the cliff with a rod and a rope and a prayer. The sky opened. The bolt went where I asked. I wept. I think the town will live. — U."*

**BRYN:** "...She built the first one."
**BRYN:** "The whole coast is bolted to the rock because of *her.*"
> ► **"Read it aloud."** — The notebook is read at the next festival.
> ► **"Add a page."** — A small, silly, wonderful moment.
> ► **"Put it back."** — Bryn nods.

**Outcomes and receipt.**
- Ulla's notebook becomes Stormreach's first *civic relic*; the cairn is kept open.
- **Receipt:** a copper rod stands over the cairn; Bryn pays his sea-bet in a cup of salt water.

<!-- quest
id: qst_pat_riddle_cairn_winds
title: Cairn of Winds
rank: B
type: Exploration
giver: npc_bryn_galehand
region: reg_stormreach
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: pat_riddle_cairn_winds_done
summary: A bolted cairn at the top of Stormreach has never been opened. A storm is coming, and a bolt can be steered.
objectives:
  talk npc_bryn_galehand
  reach stormreach_cairn_rods 5
  reach stormreach_cairn_door
  choice read_add_or_return
-->
