# 11e-47 — Quaking Lands, the Restless Ground: Ten Side Quests (draft)

> *"They believe the earth is a sleeping beast and that the springs are where it has promised not to move."*
> — Gazetteer, Quaking Lands

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 6 and 10 plant unexplained seeds.

**Region:** `reg_quaking_lands` (the Stiller spring-towns, the Still Springs, the New Gorge, Quakeback's Ridge). **Rank band:** S only. **Tone:** patient, practical, nervous in calm weather; wood and rope, dust and pine, a constant faint vibration underfoot.

**Placement notes.**
- **Quakeback, the Earthshaker Behemoth,** is the region's Tyrant: a creature so vast that the mountains are its back, waking, and unaware of the Stillers. No quest here kills, wakes, defeats, addresses or negotiates with Quakeback, and none ends the siege. The creature is felt and, at the very most, heard.
- Customs the quests rely on: every town is built round a still spring; tremor-readers decide when to farm, move and run; houses of wood and rope can be taken down and moved in a day; farming happens in quick seasons between tremors; Stillers are calm in a crisis and nervous in calm weather.
- **Open Canon points left alone:** whether Quakeback can be woken, calmed or communed with. Quest 3 (a child who calms the ground) and quest 10 (the Ridge's breathing) are seeds and give no answer.
- **Rank note.** Every quest here is rank **S** (level 160 to 205; GP 3,000; see `Data/World/guild_ranks.json`), because the region's band is S to S. Rewards are first-pass, extrapolated from the promotion table and the Whitewater S-rank quests (gold and XP rising with level).
- The region is `besieged` at start. No quest here is SiegeDefence; quest 9 is a plain Defense of one crossing for one night.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Reader Nobody Believed | S | Investigation | Tremor-Reader Maud Thrane | A warning and nine days |
| 2 | Moving Day on the Ridge | S | Escort | Town-Warden Gideon Ropewright | A town on the move |
| 3 | The Child Who Sings to the Ground | S | Hidden | Wick Larkspur | A very small, very odd gift |
| 4 | Room at the Next Spring | S | Faction | Spring-Keeper Hanne Veld | Strangers at a calm pool |
| 5 | A House You Can Carry | S | OddJob | Rope-Wright Dunstan Pellow | A house taken down in a day |
| 6 | The Oldest Maps Are All Wrong | S | Investigation | Map-Maker Ambrose Quenby | A map of what is not yet there |
| 7 | Crystals From Below | S | Delivery | Crystal-Trader Dacian Moorfield | A hum in a wooden box |
| 8 | Nervous in Calm Weather | S | OddJob | Ewart Longmeadow | A man who cannot sleep when it is still |
| 9 | The New Gorge Watch | S | Defense | Watch-Captain Rhys Cairnford | A crossing and an aftershock |
| 10 | Quakeback's Ridge Breathes | S | Exploration | Elder Reader Bertram Greywether | Counting the breaths |

## Cast

<!-- npc
id: npc_maud_thrane
name: Tremor-Reader Maud Thrane
tier: major
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Tremor-reader of a spring-town
backstory: A small, dry, stubborn tremor-reader of fifty who has predicted a great quake in nine days from the way a bowl of water shivers, and whose own town council has stopped inviting her to speak.
-->
<!-- npc
id: npc_gideon_ropewright
name: Town-Warden Gideon Ropewright
tier: major
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Warden of a town that must move
backstory: A broad, soft-voiced warden who has to take two thousand people and their rope-houses across Quakeback's Ridge before the cracked spring fails, and who has never moved a town more than a mile.
-->
<!-- npc
id: npc_wick_larkspur
name: Wick Larkspur
tier: townsfolk
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Child who sings to the ground
backstory: A quiet seven-year-old who hums to the floor whenever it shakes, and has noticed that sometimes, only sometimes, it stops.
-->
<!-- npc
id: npc_hanne_veld
name: Spring-Keeper Hanne Veld
tier: major
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Keeper of a still spring
backstory: A weathered keeper of a small spring-town whose pool has stayed still through every quake for sixty years, and who is now being asked to share it with three hundred strangers.
-->
<!-- npc
id: npc_dunstan_pellow
name: Rope-Wright Dunstan Pellow
tier: townsfolk
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Rope-wright and house-mover
backstory: A cheerful, scarred rope-wright who has moved the same house eleven times and who has promised an old woman that her house will be down and up again in a single day.
-->
<!-- npc
id: npc_ambrose_quenby
name: Map-Maker Ambrose Quenby
tier: major
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Map-maker of the old charts
backstory: A tall, quiet map-maker who copies the Stillers' oldest maps, every one of them wrong, and who has just found one that is wrong in a way he cannot explain.
-->
<!-- npc
id: npc_dacian_moorfield
name: Crystal-Trader Dacian Moorfield
tier: townsfolk
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Trader in quake-crystals
backstory: A sunburnt trader who buys the strange crystals the quakes bring up and who has been paid a great deal to carry one that will not stop humming.
-->
<!-- npc
id: npc_ewart_longmeadow
name: Ewart Longmeadow
tier: townsfolk
race: Human
region: reg_quaking_lands
settlement: Stiller spring-towns
role: Stiller who cannot sleep in calm
backstory: A gentle thirty-year-old carter who sleeps like a child through a tremor and has not slept one night in the three weeks the ground has been still.
-->
<!-- npc
id: npc_rhys_cairnford
name: Watch-Captain Rhys Cairnford
tier: major
race: Human
region: reg_quaking_lands
settlement: The New Gorge
role: Watch-captain of the New Gorge crossing
backstory: A lean, dry watch-captain who has kept the rope-ferry across the New Gorge for twelve years and who expects the next aftershock to bring the stone beasts out of the cracks.
-->
<!-- npc
id: npc_bertram_greywether
name: Elder Reader Bertram Greywether
tier: major
race: Human
region: reg_quaking_lands
settlement: Quakeback's Ridge
role: Elder tremor-reader of the Ridge
backstory: A very old, very patient reader who has counted the breaths of Quakeback's Ridge for fifty years, and who has noticed that the count is no longer even.
-->

---

## 1. The Reader Nobody Believed

*S · Investigation · a spring-town council hall · giver Tremor-Reader Maud Thrane*

**The short version.** Maud says a great quake will come in nine days. Her council does not believe her. She asks the player to check her work.

**What is really going on.** Maud is right about the quake and wrong about its size. The tremors she read from a bowl of water are real, but a second reader's chart, from the next town over, shows a quieter pattern. The player must reconcile two honest readers who have stopped speaking.

**Scene 1: the hall.**

**MAUD:** "Nine days. Between the third and fourth bell. A long one. I read it from a bowl."
**MAUD:** "They say I cried wolf in the spring. I did not. I said *wolf, maybe.*"
**MAUD:** "I would like someone to tell me I am wrong. Properly. With a chart."
> ► **"How do you read a bowl?"** — **MAUD:** "The water shivers before the ground does. Always."
> ► **"Who else reads here?"** — **MAUD:** "Old Corr, in the next town. We have not spoken in a year."
> ► **"I'll check it."** — **MAUD:** "Bring his chart. And do not tell him it is mine."

**Scene 2: the other reader.** In a rope-house workshop, Corr, a stout, grey reader, spreads out a roll of fine paper marked in a different hand.

**CORR:** "She is good. I will say it to you and nobody else. She is the best reader on this side of the ridge."
**CORR:** "She is wrong about the size. The ground to the east is quiet."
> ► **"Why do you disagree?"** — **CORR:** "I read pressure. She reads timing."
> ► **"Can you meet?"** — **CORR:** "I'd rather not."
> ► **"You are both right."** — **CORR:** "...That would be inconvenient."

**Scene 3: the table.** Back in the hall, the player lays the two charts side by side. Maud's timing and Corr's pressure.

**MAUD:** "...It's the same quake."
**CORR (arrived late, unwillingly):** "A long one. Not a big one."
**MAUD:** "A long one is worse for the springs."
> ► **"Move the town."** — The council rustles.
> ► **"Move the stores and the old."** — A compromise.
> ► **"Tell the council to watch the bowl."** — Maud's face tightens.

**Scene 4: the day.** On the ninth day the council gathers at the still spring, small and tense. Maud sets her bowl on the edge. Water trembles.

**MAUD:** "Now."
*Three minutes later the ground begins to shake, a long, low, rolling shudder. Rope houses sway. The spring does not.*

**Scene 5: after.** The quake lasts six minutes. Nobody is hurt, and the stores, moved to higher ground, are intact. Corr and Maud share a pot of tea on the wall.

**CORR:** "Long."
**MAUD:** "Long."
> ► **"Tell them you were right."** — **MAUD:** "No. Tell them we were."
> ► **"Write a joint chart."** — **CORR:** "Two names. Alphabetical."
> ► **"Leave them to it."** — They are already arguing.

**Scene 6: the council.** The next morning the council meets in the hall, and a clerk asks, with great delicacy, whether the town ought to pay Maud for the extra bell-ringing. The room goes very quiet.

**ELDER:** "I voted against her."
**MAUD:** "I know. I counted."
**ELDER:** "I would like to vote again."
> ► **"Let them."** — A show of hands, slow and embarrassed.
> ► **"Ask her to name a price."** — **MAUD:** "A good chair. With arms."
> ► **"Leave the room."** — They manage without you.

**Outcomes and receipt.**
- The town survives in good order. If the player moved the whole town, the council is humbled and angry; if only the stores and old, it is grateful and vague.
- **Receipt:** a small tremor-bowl of fired clay, marked with two readers' initials.

<!-- quest
id: qst_qkl_reader_unbelieved
title: The Reader Nobody Believed
rank: S
type: Investigation
giver: npc_maud_thrane
region: reg_quaking_lands
level: 168
act: 5
requires_rank: S
reward: 69000 | 3000 | 315000
sets: qkl_reader_done
summary: A tremor-reader predicts a long quake in nine days and her council will not listen. The player reconciles her chart with a rival reader's.
objectives:
  talk npc_maud_thrane
  reach qkl_spring_town_council_hall
  choice move_stores_or_watch
-->

---

## 2. Moving Day on the Ridge

*S · Escort · Quakeback's Ridge · giver Town-Warden Gideon Ropewright*

**The short version.** A town of two thousand must cross Quakeback's Ridge before its spring fails. The route is the only one, and the Ridge breathes.

**What is really going on.** The journey is not a fight. It is a long, rhythmic walk: the Ridge heaves, then settles, and the town must move in the settle. Gideon needs someone to keep the line moving, quietly, at the pace of the slowest.

**Scene 1: the square.**

**GIDEON:** "Two thousand. Six hundred rope-houses. Four hundred children. And a hundred and four old people, who all want to carry their own chair."
**GIDEON:** "The spring has begun to cloud. We have a week."
**GIDEON:** "The Ridge is the only way."
> ► **"What do I do?"** — **GIDEON:** "Walk at the back. Watch the slowest."
> ► **"When does the Ridge breathe?"** — **GIDEON:** "Every nine minutes. Six down. Three up."
> ► **"We go at dawn."** — **GIDEON:** "At dawn."

**Scene 2: the climb.** The first day. A long, plodding column, houses on carts, goats on strings, an old woman carrying a kettle. The ground heaves beneath them.

**GIDEON (shouting):** "Settle! Stand! Walk!"
*Gameplay: an escort in rhythm; the player calls the heave and the settle; no combat, but a rockslide and a few stone beasts disturbed by the footfalls.*
> ► **"Walk at the back."** — Slow, safe.
> ► **"Scout ahead."** — Faster, risky.
> ► **"Carry the old woman's kettle."** — She nods graciously.

**Scene 3: the night.** At a bare saddle between two ridges, the town stops to sleep. The ground is warm. A faint, regular pulse comes through the soles.

**CHILD:** "It's breathing."
**GIDEON:** "Yes."
**CHILD:** "Is it asleep?"
**GIDEON:** "I hope so."
> ► **"Sing the children down."** — A lullaby, low.
> ► **"Walk the camp."** — Quiet.
> ► **"Check the carts."** — A cracked axle.

**Scene 4: the descent.** At dawn on the third day the first houses reach the far valley, a green bowl with a new, clear spring.

**GIDEON:** "...Two thousand and eleven."
**GIDEON:** "Eleven more than I started with."
*Four babies and seven goats had been born on the road.*

**Scene 5: the pool.** The new spring is still. The town stands at its edge in silence, then kneels, one by one, and puts a palm flat on the water.

**GIDEON:** "Down with the houses. By nightfall, no one will know we were ever anywhere else."

**Scene 6: the far valley, evening.** After the houses are up, the players of the town's drums set out a slow marching beat, not for walking, but for remembering. The old and the young sit together at the water's edge and eat from one big pot.

**GIDEON:** "We will not go back. The old spring was good for sixty years, and it is gone. We will have to name this one."
**CHILD:** "Can we call it Breath?"
**GIDEON:** "...Ask your mother."
> ► **"Call it Breath."** — The child lights up.
> ► **"Call it the Second."** — Gideon laughs.
> ► **"Let the town choose."** — They argue until midnight.

**Outcomes and receipt.**
- The town arrives. If the player scouted ahead, a risk is cleared at a cost; if they walked at the back, a quiet pride follows.
- **Receipt:** a length of the town's marching-rope, knotted in two thousand and eleven small loops.

<!-- quest
id: qst_qkl_moving_day
title: Moving Day on the Ridge
rank: S
type: Escort
giver: npc_gideon_ropewright
region: reg_quaking_lands
level: 176
act: 5
requires_rank: S
reward: 75000 | 3200 | 340000
sets: qkl_moving_day_done
summary: A town of two thousand must cross Quakeback's Ridge before its spring fails. The Ridge breathes every nine minutes.
objectives:
  talk npc_gideon_ropewright
  escort npc_gideon_ropewright
  reach qkl_ridge_far_valley
  choice back_scout_or_carry
-->

---

## 3. The Child Who Sings to the Ground

*S · Hidden · a spring-town porch · giver Wick Larkspur*

**The short version.** A seven-year-old hums to the floor when it shakes. Sometimes the shaking stops. His mother wants it to be a coincidence.

**What is really going on.** *Nothing is explained.* In six tests, the tremor calms four times. It may be the humming, or the child's calm, or chance. The quest does not decide, and does not say whether Quakeback hears.

**Scene 1: the porch.**

**WICK:** "I hum so it does not feel lonely."
**WICK:** "It is not lonely, is it?"
**MOTHER:** "Wick. Stop."
**WICK:** "I am being polite."
> ► **"Who taught you?"** — **WICK:** "Nobody. It's just what I do."
> ► **"May I listen?"** — **MOTHER:** "Please don't encourage him."
> ► **"Does it work?"** — **WICK:** "Sometimes."

**Scene 2: the tests.** At the player's gentle suggestion, with the mother's wary permission, the village tremor-reader sets bowls on the porch. A tremor comes. Wick hums. The water settles.

**READER:** "...Once."
*Tremor. Hum. Stillness. Tremor. Hum. A shudder, and no stillness. Tremor. Hum. Still.*
> ► **"Try humming a different tune."** — Nothing changes.
> ► **"Try silence."** — The ground shakes the same.
> ► **"Try asking him to stop."** — He stops, and the ground stops, and everyone laughs.

**Scene 3: the mother.** At dusk the mother sits alone on the steps. The player joins her.

**MOTHER:** "I do not want him to be special. Special children in the Quaking Lands are the first to be asked to do things."
**MOTHER:** "If he can calm the ground, they will ask him to calm *all* of it."
> ► **"Nobody has to know."** — She breathes.
> ► **"Tell the reader to keep it quiet."** — She nods.
> ► **"Let him hum, then."** — She winces, and agrees.

**Scene 4: the promise.** The reader, the mother and the player make a small agreement: Wick hums when he likes. Nobody asks him to hum when they need him to.

**READER:** "No one sets a child to hold up a mountain."
**WICK:** "I would not mind."
**MOTHER:** "You would."

**Scene 5: the night.** Late, a small tremor rolls through. In the dark, Wick hums. The house stops swaying. Outside, in the distance, something enormous shifts, as if rolling over.

**MOTHER:** (whispering) "...It's a coincidence."
**WICK:** "Yes, Mam."

**Scene 6: the reader's note.** Some days later the village tremor-reader leaves a short, careful note pinned to the player's pack: a list of the six tests, with a small drawing of a boy and a bowl.

**READER (note):** "Four of six. Could be chance. I will keep testing, quietly, with no one looking. If I learn anything it will not be in the council minutes."
**READER (note):** "He is a very good boy."
> ► **"Keep it."** — It goes in the Journal.
> ► **"Burn it."** — Safer, sadder.
> ► **"Give it to his mother."** — She reads it twice, and puts it in a drawer.

**Outcomes and receipt.**
- The child keeps his humming and the town keeps its peace. No one decides whether it works.
- **Receipt:** a small clay whistle that Wick has made, which hums when the ground does.
- **Canon-safe:** a pure seed. The quest does not say whether Quakeback hears, or whether the child's humming has any effect.

<!-- quest
id: qst_qkl_singing_child
title: The Child Who Sings to the Ground
rank: S
type: Hidden
giver: npc_wick_larkspur
region: reg_quaking_lands
level: 166
act: 5
requires_rank: S
reward: 68000 | 3000 | 310000
sets: qkl_singing_child_done
summary: A seven-year-old hums to the floor when it shakes, and sometimes the shaking stops. His mother wants it to be a coincidence.
objectives:
  talk npc_wick_larkspur
  reach qkl_larkspur_porch
  choice quiet_hum_or_ask
-->

---

## 4. Room at the Next Spring

*S · Faction · a small still spring · giver Spring-Keeper Hanne Veld*

**The short version.** A spring-town has cracked, and three hundred of its people have walked to Hanne's. Her spring is the size of a threshing floor.

**What is really going on.** The still spring will support the town. The danger is *the strangers' fear,* which spreads. The tremor-readers of both towns have to learn to read each other's charts, or the two will fight over a pool.

**Scene 1: the pool.**

**HANNE:** "Sixty years it has been still. Not a ripple in a quake. I have kept it."
**HANNE:** "They arrived at dawn. Three hundred. Some on stretchers."
**HANNE:** "I said yes. I did not say how."
> ► **"How many can it hold?"** — **HANNE:** "Honestly? Two hundred. Maybe."
> ► **"Who leads them?"** — **HANNE:** "A young reader, hardly twenty."
> ► **"What do you need?"** — **HANNE:** "A way to make three hundred feel welcome in a town of ninety."

**Scene 2: the newcomers.** On the field outside the town, the newcomers sit among bundles. A thin young reader, Wren, stands at their head with a tremor-chart in both hands.

**WREN:** "We read pressure. You read timing. I don't know your charts."
**WREN:** "I'm sorry. I don't know where to put anyone."
> ► **"Put them by the spring."** — Wren nods.
> ► **"Put the old nearest."** — She writes it.
> ► **"Put a host with each family."** — Hanne's face lightens.

**Scene 3: the meeting.** In Hanne's hall the two sets of readers lay their charts side by side. For an hour there is only the scratch of chalk and the creak of rope walls.

**HANNE:** "It is the same ground."
**WREN:** "It is a different language."
**HANNE:** "Then we need a word for each."
> ► **"Draw a shared chart."** — A hard, slow evening.
> ► **"Share the watch."** — Pairs of readers, one from each town.
> ► **"Share the pool."** — Hanne agrees, with a hand on her chest.

**Scene 4: the first night.** The three hundred sleep in the open, on bedding lent by the ninety. The spring is, as ever, still.

**WREN (whispering):** "It doesn't move."
**HANNE:** "It never has."

**Scene 5: the morning.** A child from each town is seen at the spring's edge, each with a stick, drawing the same shape in the mud.

**HANNE:** "That is a house. They are both drawing houses."

**Scene 6: a debt in labour.** Within a week the town's tax is drawn up in the Stillers' way: each family owes the spring a share of labour. The newcomers send the first work-party at dawn, unasked, to re-rope the spring's fence.

**HANNE:** "They have been here six days. They have already mended my fence."
**WREN:** "We are not good at sitting still."
**HANNE:** "Then you are Stillers after all."
> ► **"Join the work-party."** — A morning of rope and laughter.
> ► **"Share the first meal."** — A very long table.
> ► **"Walk the boundary with Hanne."** — She tells you every stone's name.

**Outcomes and receipt.**
- Two towns share a spring. The agreement is rough, and the shared chart is the first of its kind.
- **Receipt:** a pair of tremor-chart tokens, one from each town, worn smooth by a year of handling.

<!-- quest
id: qst_qkl_next_spring
title: Room at the Next Spring
rank: S
type: Faction
giver: npc_hanne_veld
region: reg_quaking_lands
level: 172
act: 5
requires_rank: S
reward: 72000 | 3100 | 330000
sets: qkl_next_spring_done
summary: A cracked spring-town's three hundred survivors have walked to a keeper whose pool holds two hundred.
objectives:
  talk npc_hanne_veld
  reach qkl_small_still_spring
  choice chart_watch_or_pool
-->

---

## 5. A House You Can Carry

*S · OddJob · a house on the move · giver Rope-Wright Dunstan Pellow*

**The short version.** Dunstan has promised an old woman her house will be down and up again in one day. It has a stove, a loom and a cat.

**What is really going on.** Every Stiller house is meant to be moved in a day, and almost none ever are, because people hate to. The job is a lesson in letting go, with a rope.

**Scene 1: the porch.**

**DUNSTAN:** "I have moved this house eleven times. She says, 'I am not moving,' every time."
**DUNSTAN:** "Then she gets used to it. Then she is sorry to leave it."
**DUNSTAN:** "This time the spring is cloudy. She has no choice."
> ► **"Where to?"** — **DUNSTAN:** "Four hundred yards east, past the dry ditch."
> ► **"What do I do?"** — **DUNSTAN:** "Lift where I point. Do not stop to look."
> ► **"What about the cat?"** — **DUNSTAN:** "The cat is the hard part."

**Scene 2: the taking-down.** Pegs out, ropes loosed, panels unslotted, in an order Dunstan knows by heart. The old woman sits in a chair with her arms folded.

**OLD WOMAN:** "I was born in that bed."
**DUNSTAN:** "We'll set it in the same corner."
> ► **"Carry the bed first."** — She watches, sharp-eyed.
> ► **"Carry the loom last."** — She nods.
> ► **"Let her tie the first rope."** — She does, with an angry knot.

**Scene 3: the road.** A long line of neighbours carries panels and rafters over the dry ditch. A child carries a spoon.

**NEIGHBOUR:** "Left a bit. Mind the cat."
*Gameplay: a carry sequence with a brief tremor; the player steadies a panel.*
> ► **"Hold the roof-beam."** — Heavy, sweaty.
> ► **"Calm the cat."** — The cat tolerates it.
> ► **"Take the loom."** — A very delicate hour.

**Scene 4: the putting-up.** By afternoon, the house stands in its new field. The bed is in the corner. The stove is lit.

**OLD WOMAN:** "It smells the same."
**DUNSTAN:** "That's the stove."
**OLD WOMAN:** "It *feels* the same."
**DUNSTAN:** "That's you."

**Scene 5: the key.** At dusk the old woman gives Dunstan the first loaf from the stove.

**OLD WOMAN:** "Next time I will not argue so long."
**DUNSTAN:** "Yes, you will."
> ► **"Eat with them."** — A long table, a lit lamp.
> ► **"Check the pegs."** — Dunstan approves.
> ► **"Say goodbye to the old site."** — You do, and she smiles.

**Scene 6: the next house.** Within the month Dunstan is asked to move three more houses. He sends the old woman along to supervise, since she has opinions.

**OLD WOMAN:** "Do not tie it like that. Tie it like *this.*"
**DUNSTAN:** "That is exactly how I tied it."
**OLD WOMAN:** "Then it is wrong in a better way."
> ► **"Ask her to teach the knot."** — She does, grandly.
> ► **"Offer to carry the cat."** — The cat declines.
> ► **"Help raise the next roof."** — Another long afternoon.

**Outcomes and receipt.**
- The house is moved and the old woman is quietly furious and entirely happy.
- **Receipt:** a small wooden peg, carved with the date and the words "Down and up."

<!-- quest
id: qst_qkl_carry_house
title: A House You Can Carry
rank: S
type: OddJob
giver: npc_dunstan_pellow
region: reg_quaking_lands
level: 166
act: 5
requires_rank: S
reward: 68000 | 3000 | 310000
sets: qkl_carry_house_done
summary: A rope-wright has promised an old woman her house will be down and up again in a day.
objectives:
  talk npc_dunstan_pellow
  reach qkl_new_house_field
  choice bed_loom_or_knot
-->

---

## 6. The Oldest Maps Are All Wrong

*S · Investigation · the map-room · giver Map-Maker Ambrose Quenby*

**The short version.** The Stillers' oldest maps show mountains that are no longer there. Ambrose has found one that shows a mountain that is not *yet* there.

**What is really going on.** *Nothing is explained.* A mountain is drawn east of the plain, with a name and a shrine. No such mountain exists. The player and Ambrose walk to the spot and find only flat ground, and a cairn that has been there, they think, for a very long time.

**Scene 1: the map-room.**

**AMBROSE:** "They are all wrong. I copy them anyway. Here, a range that sank. Here, a lake that is dust. Here, a river that is a crack."
**AMBROSE:** "This one is wrong in a different way."
**AMBROSE:** "This mountain is not gone. I think it is *not here yet.*"
> ► **"How can you tell?"** — **AMBROSE:** "The ink is older than any of the others. The mountain is not."
> ► **"What is it called?"** — **AMBROSE:** "The Sitting Hill."
> ► **"I'll walk it."** — **AMBROSE:** "Bring rope. Bring water. Bring no expectations."

**Scene 2: the plain.** A broad rippling plain of tall dry grass. A rope-and-driftwood marker, the site, stands alone on a small rise.

**ENV (journal):** *The ground here is very still. Not the stillness of a spring. The stillness of a held breath.*
> ► **"Walk to the cairn."** — Ten minutes in the grass.
> ► **"Read the ground."** — A faint, slow pulse.
> ► **"Listen."** — Nothing.

**Scene 3: the cairn.** At the top of the rise, a cairn of grey stones and, on its flat top, a shallow bowl worn in the rock, filled with a little clear water that does not shiver.

**AMBROSE:** "Someone has been keeping this."
*There are no footprints. There is a fresh sprig of pine in the bowl.*
> ► **"Add a stone."** — The cairn feels heavier.
> ► **"Take the sprig."** — A cold wind.
> ► **"Leave it as found."** — Ambrose nods.

**Scene 4: the map.** Back in the map-room Ambrose copies the old map slowly, adding a note in the margin.

**AMBROSE:** "'Sitting Hill. Not yet. Kept.'"
**AMBROSE:** "I do not know who I am writing it for."

**Scene 5: the second visit.** A season later, the player passes the rise again. The cairn is one stone taller. The sprig of pine is fresh.

**Scene 6: the margin.** Weeks later a letter arrives at the player's inn, sealed with a thumbprint of ink. Inside is a single drawing of the Sitting Hill, finished in a different hand.

**LETTER:** "It was drawn, I think, by the same hand that drew the first. The paper is new."
**LETTER:** "I am told this is impossible. I am told this by someone I do not trust."
> ► **"Keep the letter."** — It goes in the Journal.
> ► **"Send a reply."** — You write one line and are not sure to whom.
> ► **"Return to the cairn."** — The sprig is fresh.

**Outcomes and receipt.**
- The map is copied, the margin note added. The Sitting Hill remains a question.
- **Receipt:** a pencil rubbing of the old map's Sitting Hill, with a space left where its name should be.
- **Canon-safe:** a pure seed. The quest does not say what the Sitting Hill is, who keeps the cairn, or whether it is related to Quakeback.

<!-- quest
id: qst_qkl_oldest_maps
title: The Oldest Maps Are All Wrong
rank: S
type: Investigation
giver: npc_ambrose_quenby
region: reg_quaking_lands
level: 174
act: 5
requires_rank: S
reward: 73000 | 3150 | 335000
sets: qkl_maps_done
summary: The Stillers' oldest maps show mountains that are gone. One shows a mountain that is not yet there.
objectives:
  talk npc_ambrose_quenby
  reach qkl_sitting_hill_cairn
  choice add_take_or_leave
-->

---

## 7. Crystals From Below

*S · Delivery · the crystal road · giver Crystal-Trader Dacian Moorfield*

**The short version.** A crystal brought up by a quake hums and will not stop. Dacian has to carry it, in a wooden box, to a tremor-reader three days away.

**What is really going on.** The crystal hums at the pitch of the ground beneath it. The nearer it gets to the Ridge, the louder it hums. A reader at the end of the road will pay to learn what it says.

**Scene 1: the market.**

**DACIAN:** "Fifteen years. I buy quake-crystals by the sack. I sell them for lamps, for rattles, for children's toys."
**DACIAN:** "This one hums. It's not a toy."
**DACIAN:** "I'd like to deliver it to a reader. Alive."
> ► **"What does it say?"** — **DACIAN:** "I'd rather someone else tell me."
> ► **"Why three days?"** — **DACIAN:** "The only reader who can read stone lives past the Ridge."
> ► **"I'll go."** — **DACIAN:** "Keep the box shut. And away from the Ridge."

**Scene 2: the road.** A dusty, dry-grass road. The box hums against the player's hip like a trapped bee.

**DACIAN:** "It's higher today."
*Gameplay: a travel sequence; the hum rises near cracks; the player may route around the Ridge or through it.*
> ► **"Go round the Ridge."** — Longer, quieter.
> ► **"Go through the cut."** — Faster, louder.
> ► **"Wrap the box in wool."** — Muffled.

**Scene 3: the reader.** At a rope-house on the far side, a blind old reader lays her palm flat on the box.

**READER:** "...It's keeping time."
**DACIAN:** "With what?"
**READER:** "With something large, and slow, and a long way down."
> ► **"Is it a warning?"** — **READER:** "It is a metronome."
> ► **"Can you stop it?"** — **READER:** "Why would I?"
> ► **"What does it keep time for?"** — **READER:** "I don't know. Nobody asked it."

**Scene 4: the end.** The reader sets the crystal on a shelf in a quiet corner. The hum settles into a slow, patient beat.

**READER:** "I'll keep it. For the town. When it speeds up, we'll know."
**DACIAN:** "How will you know?"
**READER:** "We'll hear it."

**Scene 5: the pay.** Dacian is paid in full. He hands half to the player without being asked.

**DACIAN:** "I'd still be on the Ridge, wrapped in wool, if you hadn't."

**Scene 6: the goat.** On the way home the player passes the reader's goat, now unaccountably the most confident animal on the road. It trots beside the player for a mile and then, at a signpost, sits down and refuses to go on.

**DACIAN:** "That animal has opinions about my crystals."
**DACIAN:** "I think it is jealous."
> ► **"Buy it a ribbon."** — It eats the ribbon.
> ► **"Pat it."** — It leans, a lot.
> ► **"Walk on."** — It follows at a sulky distance.

**Scene 7: what the town keeps.** Before the player leaves, the people of the place press small, practical gifts into their hands: a heel of bread, a coil of cord, a flask of something sharp.

**ELDER:** "It is not payment. Payment is the guild's business."
**ELDER:** "This is what you give a guest who has stood a watch with you."
> ► **"Accept it all."** — Gracious.
> ► **"Take only the bread."** — Understood, and approved.
> ► **"Share it out on the road."** — They like that best.

**Outcomes and receipt.**
- The crystal becomes the town's early-warning tick. Going through the cut makes it hum louder, and scares the reader's goat.
- **Receipt:** a small chip of the same crystal, which hums faintly when the ground does.

<!-- quest
id: qst_qkl_crystal_hum
title: Crystals From Below
rank: S
type: Delivery
giver: npc_dacian_moorfield
region: reg_quaking_lands
level: 170
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: qkl_crystal_done
summary: A trader must carry a humming quake-crystal three days to a reader past the Ridge.
objectives:
  talk npc_dacian_moorfield
  reach qkl_far_reader_house
  choice round_through_or_wool
-->

---

## 8. Nervous in Calm Weather

*S · OddJob · a quiet valley · giver Ewart Longmeadow*

**The short version.** The ground has been still for three weeks. Ewart cannot sleep. He asks the player to shake his bed.

**What is really going on.** Stillers are calm in a crisis and nervous in calm. Ewart's fear is not of the ground but of *what comes after quiet.* The kindest remedy is company, and a rocking cradle bed, built together.

**Scene 1: the cart-shed.**

**EWART:** "Three weeks. Not a tremor. I lie there and listen."
**EWART:** "I sleep through a quake like a stone. It is the quiet that wakes me."
**EWART:** "Everyone says it is a gift. I say it is a held breath."
> ► **"What do you want?"** — **EWART:** "Someone to shake the bed."
> ► **"That sounds silly."** — **EWART:** "It is."
> ► **"I'll try."** — **EWART:** "Not too hard."

**Scene 2: the night.** The player sits at the foot of the bed and rocks it gently. Ewart lies stiff, eyes open.

**EWART:** "Faster."
**EWART:** "Slower."
**EWART:** "No. Just... a heartbeat."
> ► **"Rock in time with a heartbeat."** — He breathes out.
> ► **"Hum."** — He frowns, then relaxes.
> ► **"Tell a story."** — He listens.

**Scene 3: the neighbours.** In the morning the neighbours turn up with food and a surprising number of opinions.

**NEIGHBOUR:** "My mother used to bounce my cot on a rope."
**NEIGHBOUR:** "Mine rolled a barrel round the room."
> ► **"Build a rocking bed."** — A rope cradle goes up.
> ► **"Rig a barrel under the floor."** — A great success.
> ► **"Leave him to sleep in peace."** — They are insulted.

**Scene 4: the bed.** By dusk a rope-hung bed sways gently over the cart-shed floor, with a pulley and a stone counterweight.

**EWART:** "...Oh."
*He is asleep in four minutes.*

**Scene 5: the tremor.** At dawn, a small, ordinary tremor rolls through. Ewart does not wake. The neighbours stand in the doorway, listening to him breathe.

**NEIGHBOUR (whispering):** "There. It's back."

**Scene 6: the quiet valley.** A month later the ground in the valley wakes at last, a gentle, rolling tremor at midmorning. The cart-shed is empty. Ewart is in the field, eyes closed, face lifted, standing very still.

**EWART:** "There you are."
**NEIGHBOUR:** "You were worried about it."
**EWART:** "I was. I am not now."
> ► **"Welcome back."** — He nods.
> ► **"Come and eat."** — He does.
> ► **"Stay a moment."** — You do, and the ground rocks you both.

**Scene 7: what the town keeps.** Before the player leaves, the people of the place press small, practical gifts into their hands: a heel of bread, a coil of cord, a flask of something sharp.

**ELDER:** "It is not payment. Payment is the guild's business."
**ELDER:** "This is what you give a guest who has stood a watch with you."
> ► **"Accept it all."** — Gracious.
> ► **"Take only the bread."** — Understood, and approved.
> ► **"Share it out on the road."** — They like that best.

**Outcomes and receipt.**
- Ewart sleeps again. The town grows a custom of rocking-beds for the calm-sick.
- **Receipt:** a short length of cradle-rope with a single sailor's knot, given by Ewart.

<!-- quest
id: qst_qkl_calm_sick
title: Nervous in Calm Weather
rank: S
type: OddJob
giver: npc_ewart_longmeadow
region: reg_quaking_lands
level: 164
act: 5
requires_rank: S
reward: 67000 | 3000 | 305000
sets: qkl_calm_sick_done
summary: The ground has been still for three weeks, and a carter who sleeps through quakes cannot sleep through the quiet.
objectives:
  talk npc_ewart_longmeadow
  reach qkl_longmeadow_cart_shed
  choice heartbeat_barrel_or_leave
-->

---

## 9. The New Gorge Watch

*S · Defense · the New Gorge crossing · giver Watch-Captain Rhys Cairnford*

**The short version.** An aftershock is due. When the ground moves, stone beasts come out of the cracks. The rope-ferry across the New Gorge must be held for one night.

**What is really going on.** The beasts are not hunting people. They are fleeing the deeper cracks. The watch's job is to keep the ferry and the queue of travellers safe, and to *not* provoke a stampede.

**Scene 1: the ferry.**

**RHYS:** "Twelve years on the rope. Thirty-one aftershocks. Eleven stone herds."
**RHYS:** "They go where the ground goes. That's the crossing."
**RHYS:** "I have forty travellers. And one bridge."
> ► **"What do I hold?"** — **RHYS:** "The east landing. Don't let them cut the rope."
> ► **"How big are the beasts?"** — **RHYS:** "Mostly mule-sized. Some bigger."
> ► **"When?"** — **RHYS:** "Dusk, or soon after."

**Scene 2: the dusk.** The sun sinks, red through dust. The first tremor is small. The second is not.

**RHYS (shouting):** "Rope!"
*Gameplay: defend the landing against fleeing stone beasts; the aim is to turn the herd, not kill it. Travellers are ferried in small groups.*
> ► **"Light fires to turn the herd."** — They veer.
> ► **"Hold the landing."** — Brute work.
> ► **"Ferry the children first."** — Slow, careful.

**Scene 3: the herd.** A thunder of stone hooves along the gorge lip. A large beast, as high as a cart, stops at the lip and stares across.

**TRAVELLER:** "It's looking at us."
**RHYS:** "It's looking for the way."
> ► **"Open a path."** — The beast bolts for the plain.
> ► **"Stand still."** — It snorts and goes.
> ► **"Throw a lantern."** — It spooks, wrong way.

**Scene 4: the dawn.** The last traveller lands on the west bank. The rope is intact. The beasts are gone.

**RHYS:** "Forty."
**RHYS:** "And the rope."

**Scene 5: the count.** Rhys writes the night in the watch log and signs it, then hands the pen to the player.

**RHYS:** "Sign. If you've held the landing, you're on the roll."
> ► **"Sign."** — A new line in the log.
> ► **"Decline."** — He shrugs.
> ► **"Sign for the herd."** — He barks a laugh.

**Scene 6: the log of the night.** Rhys keeps the watch-log in a plain hand and a firm line. Underneath the night's count, he adds a short note about the large beast that stopped at the lip.

**RHYS:** "'One beast, as high as a cart. Stood. Looked across. Left.' I do not know what to call that."
**RHYS:** "I will call it 'courtesy.'"
> ► **"Courtesy is right."** — He writes it in.
> ► **"Call it fear."** — **RHYS:** "Could be both."
> ► **"Leave it unnamed."** — He underlines the gap.

**Scene 7: what the town keeps.** Before the player leaves, the people of the place press small, practical gifts into their hands: a heel of bread, a coil of cord, a flask of something sharp.

**ELDER:** "It is not payment. Payment is the guild's business."
**ELDER:** "This is what you give a guest who has stood a watch with you."
> ► **"Accept it all."** — Gracious.
> ► **"Take only the bread."** — Understood, and approved.
> ► **"Share it out on the road."** — They like that best.

**Outcomes and receipt.**
- The crossing holds. The siege is not touched. The watch adds a new rule: light before the third tremor.
- **Receipt:** a watch-log page with the player's name beside forty tally marks.

<!-- quest
id: qst_qkl_gorge_watch
title: The New Gorge Watch
rank: S
type: Defense
giver: npc_rhys_cairnford
region: reg_quaking_lands
level: 184
act: 5
requires_rank: S
reward: 82000 | 3400 | 370000
sets: qkl_gorge_watch_done
summary: An aftershock will bring stone beasts out of the cracks. The rope-ferry across the New Gorge must be held for one night.
objectives:
  talk npc_rhys_cairnford
  defend qkl_new_gorge_ferry
  choice fires_hold_or_children
-->

---

## 10. Quakeback's Ridge Breathes

*S · Exploration · the Ridge · giver Elder Reader Bertram Greywether*

**The short version.** Bertram has counted the Ridge's breaths for fifty years. The count is no longer even. He asks the player to stand on the Ridge for a full night and count with him.

**What is really going on.** *Nothing is explained.* In the small hours the player and Bertram hear, between two long breaths, a third, shorter breath, like a thing turning over. Bertram does not say what it is. Neither does the quest.

**Scene 1: the hut.**

**BERTRAM:** "Fifty years. Nine minutes. Six down, three up. Every night."
**BERTRAM:** "Last year, ten. This year, nine, ten, eight."
**BERTRAM:** "I have stopped telling the council. They look at me like a man who has counted his own teeth."
> ► **"Why does the count matter?"** — **BERTRAM:** "Because it is the only thing it does that we can follow."
> ► **"What do you need?"** — **BERTRAM:** "Another pair of ears. And no talking."
> ► **"I'll count."** — **BERTRAM:** "Begin at the second bell."

**Scene 2: the Ridge.** A cold, dry night, on a spine of rock that rises and falls beneath them like a sleeper's ribs. A second bell sounds from the village below.

**BERTRAM (whispering):** "One. Down. Two. Down."
*Gameplay: a quiet counting vigil; no combat; the player may speak, sit or stand.*
> ► **"Count aloud."** — Bertram winces.
> ► **"Count on fingers."** — He nods.
> ► **"Lay a palm on the rock."** — It's warm.

**Scene 3: the extra breath.** In the fourth hour, between the sixth and the seventh count, there is a short, soft, uneven breath, almost a sigh.

**BERTRAM:** (barely) "...There."
**BERTRAM:** "I have heard it three times."
> ► **"What was that?"** — **BERTRAM:** "I do not know."
> ► **"Did you feel it?"** — **BERTRAM:** "In my teeth."
> ► **"Write it down."** — He does, carefully.

**Scene 4: the dawn.** The two of them sit on the rock and watch the sun come up over the plain.

**BERTRAM:** "Fifty years I thought I was counting a creature's sleep."
**BERTRAM:** "Now I think I might be counting a person's."

**Scene 5: the log.** Back in the hut Bertram writes in a thick, thumbed book: 9, 10, 8, and a small symbol the player has never seen.

**BERTRAM:** "For the next reader."

**Scene 6: the path down.** Bertram walks the player a little way down the Ridge's long flank in the early light, one hand resting on the warm rock as if on a sleeping dog.

**BERTRAM:** "I used to say goodnight to it. When I was young and foolish."
**BERTRAM:** "I think I will start again."
> ► **"Say it with him."** — The words are small.
> ► **"Say nothing."** — He nods.
> ► **"Ask what he'll write next."** — **BERTRAM:** "A single line. 'Still here.'"

**Scene 7: what the town keeps.** Before the player leaves, the people of the place press small, practical gifts into their hands: a heel of bread, a coil of cord, a flask of something sharp.

**ELDER:** "It is not payment. Payment is the guild's business."
**ELDER:** "This is what you give a guest who has stood a watch with you."
> ► **"Accept it all."** — Gracious.
> ► **"Take only the bread."** — Understood, and approved.
> ► **"Share it out on the road."** — They like that best.

**Outcomes and receipt.**
- The log is kept; the third breath is recorded and unexplained.
- **Receipt:** a page from Bertram's log with the extra breath marked and a margin note, "Not mine."
- **Canon-safe:** a pure seed. It does not say what the third breath is, nor whether Quakeback is waking, dreaming or turning.

<!-- quest
id: qst_qkl_ridge_breathes
title: Quakeback's Ridge Breathes
rank: S
type: Exploration
giver: npc_bertram_greywether
region: reg_quaking_lands
level: 190
act: 5
requires_rank: S
reward: 88000 | 3600 | 395000
sets: qkl_ridge_done
summary: An elder reader has counted the Ridge's breaths for fifty years. The count is no longer even.
objectives:
  talk npc_bertram_greywether
  reach qkl_ridge_vigil
  choice aloud_fingers_or_palm
-->
