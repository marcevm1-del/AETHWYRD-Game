# 11e-04 — Mossdeep, the Land of Small Things: Ten Side Quests (draft)

> *"Thimblefolk tell of a giant who once shared their bread and kept the spiders off. They still set out a thimble of milk for him."*
> — Gazetteer, Mossdeep

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: this region is spoiler-light.

**Region:** `reg_mossdeep` (Thimblefolk Mushroom Town, the Old Shade, the fern forest, the warm springs). **Rank band:** D–C. **Tone:** warm, ingenious, formal to the point of comedy, and very brave.

**Scale rule.** At the inn door the player drinks a **shrinking draught** and plays most Mossdeep quests at Thimblefolk scale (knee-high to a human). Scale changes what is dangerous: an ordinary beetle is a mount, a cat is a calamity, a raindrop is a thrown rock. The draught is a story device with no mechanical penalty; it wears off at the valley mouth.

**Placement notes.**
- **Mother Webcrawler** is the region's Tyrant and is hunting the town from the high ferns. No quest here kills her. Quests 8 and 10 change *how the town prepares*.
- Thimblefolk govern by a council of guild-heads who vote by dropping seeds in cups. Quests 3 and 10 are about that system.
- The big debate in the town is whether to ask the big folk for help. The answer is not obvious, and the quests do not pick a side for the player.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Thimble of Milk | D | OddJob | Dilly Tuffet | Cozy mystery, a giant revealed |
| 2 | The Beetle Rider's Test | D | OddJob | Captain Reedle Brisk | A child's dream, a riding course |
| 3 | The Seed Recount | D | Faction | Speaker Maplin Thorne | Politics at the size of a mushroom |
| 4 | The Blue in the Tapestry | D | Exploration | Odalie Fern | History woven in thread |
| 5 | A Cat Called Disaster | D | OddJob | Fiddlewick Brambly | A calamity with a heart |
| 6 | The Aphid Run | D | Defense | Pomfrey Dew | Herding, chaos, a tiny cavalry |
| 7 | The Honey That Wasn't | C | Investigation | Beatrix Combe | A fraud at scale |
| 8 | The Webcrawler's Larder | C | Escort | Nettle Thrum | A rescue in the ferns |
| 9 | The Old Shade Grows Cold | C | Faction | Elder Mossy Pennywhistle | A tree, a spring, a decision |
| 10 | The Big Folk Are Asked | C | Faction | Speaker Maplin Thorne | The accord |

## Cast (new supporting NPCs)

<!-- npc
id: npc_dilly_tuffet
name: Dilly Tuffet
tier: major
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Keeper of the Giant's shrine
backstory: A tiny, formal shrine-keeper who has set out a thimble of milk every dusk for sixty years and has been told by everyone that it does nothing.
secret: She once saw a hand the size of a barn reach down and take it.
-->
<!-- npc
id: npc_reedle_brisk
name: Captain Reedle Brisk
tier: major
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Captain of the Beetle Riders
backstory: A scarred, kindly captain of the beetle riders who has been thrown from every kind of beetle in Mossdeep and still insists the best ride is the first.
-->
<!-- npc
id: npc_maplin_thorne
name: Speaker Maplin Thorne
tier: major
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Speaker of the toadstool council
backstory: A careful, anxious council speaker who has counted every seed in every vote for forty years and lies awake worrying that one was miscounted.
-->
<!-- npc
id: npc_odalie_fern
name: Odalie Fern
tier: townsfolk
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Moss-weaver
backstory: A proud young moss-weaver who has just inherited her grandmother's loom and is not sure she can finish what the old woman started.
-->
<!-- npc
id: npc_fiddlewick_brambly
name: Fiddlewick Brambly
tier: townsfolk
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Baker
backstory: A cheerful baker whose pie cart has been overturned twice this week by something very large and very soft.
-->
<!-- npc
id: npc_pomfrey_dew
name: Pomfrey Dew
tier: townsfolk
race: Thimblefolk
region: reg_mossdeep
settlement: Mossdeep aphid pastures
role: Herd-master
backstory: A stout herd-master who loves his aphids more than he will admit and has named every one of them, including the difficult ones.
-->
<!-- npc
id: npc_beatrix_combe
name: Beatrix Combe
tier: major
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Honey-keeper guild-head
backstory: A sharp, honest honey-keeper who has watched Mossdeep honey sell for a fortune in Aldmere and has noticed that her own cousins cannot afford a jar.
-->
<!-- npc
id: npc_nettle_thrum
name: Nettle Thrum
tier: townsfolk
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Mother of a missing rider
backstory: A quiet, steady widow whose son rode out with the beetle riders three nights ago and has not come back.
-->
<!-- npc
id: npc_tam_thrum
name: Tam Thrum
tier: townsfolk
race: Thimblefolk
region: reg_mossdeep
settlement: Thimblefolk Mushroom Town
role: Seventeen-year-old beetle rider
backstory: A careful seventeen-year-old beetle rider who volunteered for a scouting ride he was told was safe, and who has been listening to a spider talk for three nights.
-->
<!-- npc
id: npc_mossy_pennywhistle
name: Elder Mossy Pennywhistle
tier: major
race: Thimblefolk
region: reg_mossdeep
settlement: The Old Shade
role: Keeper of the Old Shade
backstory: An ancient, bright-eyed elder who lives in a hollow of the great oak and speaks to the tree as to an old friend.
-->

---

## 1. A Thimble of Milk

*D · OddJob · Thimblefolk Mushroom Town · giver Dilly Tuffet*

**The short version.** Every dusk Dilly leaves a thimble of milk at the Giant's shrine. Every dawn it is empty. Everyone says it is a cat. Dilly knows better.

**What is really going on.** The giant is real. He is **Oswin Grist**, a retired human adventurer who lives in a hut at the valley mouth and has spent forty years keeping spiders away from the town with smoke, pretending not to notice the thimbles. He is deaf in one ear and very shy. Nobody has ever said hello.

**Scene 1: the draught.** At the inn door, a rotund innkeeper presses a tiny cup into your hand.

**INNKEEPER:** "Drink, honoured guest. All of it. It tastes of dandelion and mild regret."
*The world swells. The ferns become towers. The inn's door is a gate the size of a house.*
**INNKEEPER:** "Welcome to Mossdeep. Mind the beetles. They've right of way."

**Scene 2: the shrine.**

**DILLY:** "Sixty years. Every dusk. A thimble of milk, set on the stone, *just so*."
**DILLY:** "My grandmother did it. Her grandmother. They say a giant once shared his bread with us and kept the spiders off. They say he *went away*. I say he never left."
**DILLY:** "I saw a hand once. I was nine. It reached over the ferns and took the thimble like *that*. Never saw it again."
> ► **"Why tell me?"** — **DILLY:** "Because you're the first person who didn't laugh."
> ► **"What do you want to know?"** — **DILLY:** "Who he is. And whether he's lonely."

**Scene 3: the stakeout.** At dusk, you wait in the long grass. A great shadow crosses the stars. A hand, vast, scarred, slow, descends. It stops a hair's breadth from the thimble.

**VOICE (distant, like thunder):** "...Ah. Sorry. I did not mean to *hover*."
The hand withdraws a little. A huge, kindly eye looks down through a gap in the ferns.
**OSWIN:** "I didn't know anyone was there. Forgive me. I'm *not* good at this."
> ► **"You're the Giant."** — **OSWIN:** "I'm an old man with a pipe. But yes, I suppose."
> ► **"Thank you for the spiders."** — **OSWIN:** "...You *noticed*?"
> ► **"She's been leaving the milk for sixty years."** — **OSWIN:** "...Sixty? I thought it was... a different family."

**Scene 4: the meeting.** In a slow, delicate scene, Dilly walks to the edge of the stone. Oswin lowers his hand, palm up, a rickety bridge. She steps onto it.

**DILLY:** "I am Dilly Tuffet, keeper of the shrine."
**OSWIN:** "I am Oswin Grist, keeper of... spiders, I suppose."
**DILLY:** "I have wanted to say thank you for sixty years."
**OSWIN:** "I have wanted to say *you're welcome*."
*He is, very quietly, crying. His tears land like warm rain.*

**Outcomes and receipt.**
- Oswin becomes a recurring friend at the valley mouth; the shrine acquires a *large* cup beside the thimble.
- **Receipt:** a second thimble of milk is left at his hut every dusk; Oswin's smoke-line against the spiders is reinforced by Thimblefolk bees; the council's debate about asking the big folk for help gets one fewer "no."

<!-- quest
id: qst_md_thimble_milk
title: A Thimble of Milk
rank: D
type: OddJob
giver: npc_dilly_tuffet
region: reg_mossdeep
level: 36
act: 2
requires_rank: D
reward: 1400 | 85 | 5800
sets: md_milk_resolved
summary: A shrine-keeper has left a thimble of milk for a legendary giant for sixty years. It always vanishes. The giant is real, and shy.
objectives:
  talk npc_dilly_tuffet
  reach mossdeep_giants_shrine_dusk
  choice meet_thank_or_watch
-->

---

## 2. The Beetle Rider's Test

*D · OddJob · Thimblefolk Mushroom Town · giver Captain Reedle Brisk*

**The short version.** A twelve-year-old has applied to be a beetle rider. The Captain wants someone to ride beside her as a safety. She is not allowed to know it.

**What is really going on.** **Pip Marrow** is small even for a Thimblefolk and has been told for years that she is too light to hold a saddle. Reedle thinks she is exactly the right weight for a *scout* beetle, the swift kind. She has never ridden one. The test is dangerous, and Reedle will not let her fail.

**Scene 1: the stable.**

**REEDLE:** "I have been thrown by every beetle in Mossdeep. Dung beetle, stag beetle, blue ground beetle. I have *ridden* every one, too."
**REEDLE:** "The first ride is the best. It's also the one that kills the weak. I won't let it kill *her*."
**REEDLE:** "I want you on the next beetle, close. If she falls, you catch her. She's *never* to know."
> ► **"Is that fair?"** — **REEDLE:** "No. But it's right."
> ► **"What if she wants to fail?"** — **REEDLE:** "Then I'll let her. But not on *my* watch."

**Scene 2: the ride.** The test course winds through the fern forest, across a stream on a woven bridge, up a mossy ridge, over the lip of a steam vent. Pip rides a small, nervous, blue-green beetle called **Gruff**. The player rides alongside on a patient stag beetle.

**PIP:** "He keeps turning left. *Why* does he keep turning left?"
**GRUFF:** *(a worried chirrup)*
**REEDLE (from a distant ridge):** "Don't pull! *Lean!*"
*(Gameplay: a mounted obstacle course. The player can nudge, steer, or hold back; Pip is never in real danger, but she believes she is.)*

**Scene 3: the gap.** At a wide, wet chasm, Gruff balks. Pip's hands are white on the reins.

**PIP:** "I can't. I can't. I'm too small. They were right."
> ► **"They weren't."** — **PIP:** "How do *you* know?"
> ► **"Lean forward."** — **PIP:** "...That's all?"
> ► **"I'll go first."** — **PIP:** "Then I'll see how."

**Scene 4: the leap.** Gruff jumps. The chasm is wide, but the beetle is fast, and a small girl on a light beetle makes the other side with a handspan to spare.

**PIP:** "I did it! I *did it*!"
**REEDLE:** (arriving, breathless) "I... saw."
**PIP:** "You *saw*?"
**REEDLE:** "I may have been following."
*Pip looks at the player.*
**PIP:** "...Were *you*?"

**Outcomes and receipt.**
- Pip passes. If the player had to catch her, she knows; the quest branches on how the player tells the truth.
- **Receipt:** Pip wears a rider's pin; Gruff is stabled at the front; Reedle retells the story at the inn, and gets it slightly wrong.

<!-- quest
id: qst_md_beetle_test
title: The Beetle Rider's Test
rank: D
type: OddJob
giver: npc_reedle_brisk
region: reg_mossdeep
level: 38
act: 2
requires_rank: D
reward: 1500 | 90 | 6000
sets: md_beetle_resolved
summary: A twelve-year-old is taking the beetle rider's test. The Captain wants you riding close, without her knowing.
objectives:
  talk npc_reedle_brisk
  reach mossdeep_beetle_course
  choice nudge_hold_or_confess
-->

---

## 3. The Seed Recount

*D · Faction · the toadstool council hall · giver Speaker Maplin Thorne*

**The short version.** The council voted on whether to ask the big folk for help. The seeds in the cups add up to one more than the number of voters. Nobody will say who cheated.

**What is really going on.** Nobody cheated. A *mouse* wandered in during the count, dropped a seed, and left. But the town has already split into two camps who each *assume* the other cheated, and the real vote may be a tie.

**Scene 1: the hall.**

**MAPLIN:** "Forty-one voters. Forty-two seeds. Forty-two."
**MAPLIN:** "I have counted this vote nine times. I have counted every vote for forty years. I have never miscounted."
**MAPLIN:** "Someone has *cheated*. And whichever side it was, I cannot tell. I need a stranger. Someone with no seed, and no stake."
> ► **"How can I help?"** — **MAPLIN:** "Count with me. Slowly. In front of everyone."
> ► **"Are you sure it wasn't a mistake?"** — **MAPLIN:** "I am *never* mistaken."
> ► **"Whose seed is extra?"** — **MAPLIN:** "That is *exactly* the question."

**Scene 2: the investigation.** The player questions the six guild-heads. Each has a theory and a grudge:
- **Honey-keeper Beatrix:** "The beetle-riders voted twice. They always do."
- **Beetle-rider Reedle:** "The honey-keepers vote with their purses."
- **Moss-weaver Odalie:** "I counted *my own* seed. I'm certain."
- **Brewer Quince:** "I had a pint. I may have miscounted my own."
- **Witness (a mouse):** *(nervously, in a language only the Thimblefolk partly understand)*

**Scene 3: the mouse.** Behind the council hall, a field mouse hides under a leaf. She is carrying a *seed* in her cheek, and she is very sorry.

**MOUSE (via interpreter):** "She says... she was hungry. She says she *thought* the seeds were for her."
**MAPLIN:** "...A mouse."
**MAPLIN:** "I have been counting seeds for forty years, and *a mouse* has ruined me."
> ► **"Tell everyone."** — The hall is stunned, then laughs.
> ► **"Keep the mouse quiet."** — The town stays divided.
> ► **"Redo the vote."** — Maplin groans, but agrees.

**Scene 4: the second vote.** In front of the whole town, every voter drops a seed; the mouse is given a seat. The count is *forty-one to forty-one*, with one abstention.

**MAPLIN:** "A tie. After all that."
**MAPLIN:** "...The Speaker may break a tie. I have never done it."
> ► **(Persuade Maplin to vote for asking.)**
> ► **(Persuade Maplin to vote against.)**
> ► **(Offer to sit it out.)**

**Outcomes and receipt.**
- The vote is decided by the player's argument. *Asking* opens quest 10; *not asking* keeps the town self-reliant, with a smaller reward in quest 10.
- **Receipt:** a mouse-shaped weathervane sits on the council hall roof; Maplin keeps a cup labelled "Seed (mouse)".

<!-- quest
id: qst_md_seed_recount
title: The Seed Recount
rank: D
type: Faction
giver: npc_maplin_thorne
region: reg_mossdeep
level: 40
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: md_recount_resolved
summary: The council's vote on whether to ask the big folk for help has one seed too many. The culprit is a mouse, and the town is divided.
objectives:
  talk npc_maplin_thorne
  reach mossdeep_council_hall
  choice ask_refuse_or_abstain
-->

---

## 4. The Blue in the Tapestry

*D · Exploration · Thimblefolk Mushroom Town · giver Odalie Fern*

**The short version.** Odalie's grandmother left a half-finished tapestry. The last blue thread has run out, and the only source is a glowfly that nests on the edge of Mother Webcrawler's range.

**What is really going on.** The tapestry is the town's *history in thread*, and the blue is the **moment the Thimblefolk first met the giant**. It is also the moment they fled a "great hunger" that the tapestry's older panels show as a field of silver eyes. The glowfly nest is also where that old hunger *began*.

**Scene 1: the loom.**

**ODALIE:** "My grandmother wove this for sixty years. It shows everything: the first huts, the first harvest, the first beetle ride."
**ODALIE:** "The last panel is blue. *Sky*. And a very big hand, reaching down. She never finished it."
**ODALIE:** "I can weave, but I can't dye. I need her blue. And the glowfly that makes it nests in the high ferns."
> ► **"What's the risk?"** — **ODALIE:** "Spiders. Spiders everywhere."
> ► **"I'll fetch the thread."** — **ODALIE:** "Please. And don't *scare* them."

**Scene 2: the climb.** A vertical stealth sequence up a rope-and-moss lattice to the glowfly's hollow. Webs hang like curtains; a pair of eyes reflects the lantern.

**GLOWFLY (a soft, bell-like hum):** *(offering a single glowing thread)*
> ► **(Accept the thread gently.)** — The glowfly gives its blue freely.
> ► **(Take it quickly.)** — The glowfly hums in alarm; spiders stir.

**Scene 3: the old panels.** On the way back, a torn strip of the tapestry hangs in a high fern, left by someone long ago. It shows a field of silver eyes, and a river of small figures fleeing from it.

**ODALIE:** (later, in the workshop) "My grandmother never wove those. Someone *cut them out*."
**ODALIE:** "Why would anyone cut out their own history?"
> ► **"Because it was frightening."** — **ODALIE:** "That is... a *reason*."
> ► **"Because someone didn't want it remembered."** — **ODALIE:** "Then *I* want it."
> ► **"Weave it back in."** — **ODALIE:** "Even the frightening part?"

**Scene 4: the weaving.** Odalie weaves the blue sky, the giant's hand, and, at the very end, a *thimble*.

**ODALIE:** "There. It's done. She'd have liked that."
**ODALIE:** "And I'll hang the silver eyes beside it. We should remember what we ran from."

**Outcomes and receipt.**
- The tapestry is completed and hung in the council hall; the silver-eyed panel is a clue (not an explanation) about Mossdeep's old hunger.
- **Receipt:** a visible tapestry in the hall; a faint blue glow in the weaving shop.

<!-- quest
id: qst_md_blue_tapestry
title: The Blue in the Tapestry
rank: D
type: Exploration
giver: npc_odalie_fern
region: reg_mossdeep
level: 42
act: 2
requires_rank: D
reward: 1600 | 95 | 6400
sets: md_tapestry_resolved
summary: A moss-weaver needs the last blue thread to finish her grandmother's tapestry. It nests at the edge of Mother Webcrawler's range.
objectives:
  talk npc_odalie_fern
  reach mossdeep_glowfly_hollow
  choice take_gently_or_quickly
-->

---

## 5. A Cat Called Disaster

*D · OddJob · Thimblefolk Mushroom Town · giver Fiddlewick Brambly*

**The short version.** An enormous soft thing has overturned Fiddlewick's pie cart twice this week. The council calls it **Disaster**. At Thimblefolk scale, a house cat is a landslide with a purr.

**What is really going on.** Disaster is a *stray kitten* who has wandered into the valley from the human road, terrified, hungry, and with no idea that anything she touches is a person's whole life. She is not hunting. She is *playing*.

**Scene 1: the bakery.**

**FIDDLEWICK:** "TWICE. Twice in a week! First the pie cart, then the *second* pie cart, and a third has been *sat on*!"
**FIDDLEWICK:** "I don't want her killed. I just want her *elsewhere*. A very large and very understanding elsewhere."
> ► **"What does she look like?"** — **FIDDLEWICK:** "Grey. Huge. Soft. *Purrs like an earthquake.*"
> ► **"Is she dangerous?"** — **FIDDLEWICK:** "Only to everything."

**Scene 2: the stakeout.** At dusk, in the fern shade, a pair of green eyes the size of dinner plates open slowly. A great grey paw pats at a rolling thimble, sending it spinning across the clearing.

**DISASTER:** *(a soft, bone-shaking mew)*
**FIDDLEWICK (hiding behind a mushroom):** "That's her! That's *Disaster!*"
**PLAYER (shrunk):** "She's just a kitten."
**FIDDLEWICK:** "A kitten the size of a *barn*!"

**Scene 3: the offer.** The player coaxes her with milk from the Giant's shrine (quest 1). Disaster rolls over, a world-ending ball of fluff, and a tiny purr rattles every leaf.

> ► **"Take her to Oswin."** — The Giant's smoke-keeper hut is a good home.
> ► **"Take her home to the big folk."** — A human farmhouse nearby may have room.
> ► **"Make her a town guardian."** — The Thimblefolk build a cat-sized nest on the edge of the valley.

**Scene 4: the goodbye.** Whichever home she takes, Fiddlewick walks her to the road and gives her the last pie, a ceremonial one.

**FIDDLEWICK:** "I'll... miss her. A little."
**FIDDLEWICK:** "She was the only customer who ever ate *three* at once."

**Outcomes and receipt.**
- Disaster ends up with Oswin, a farm child, or the valley as a gentle guardian. Each gives a different line in later quests.
- **Receipt:** a small clay cat on Fiddlewick's counter; a "Disaster Special" pie on the menu, which is just a big pie.

<!-- quest
id: qst_md_cat_disaster
title: A Cat Called Disaster
rank: D
type: OddJob
giver: npc_fiddlewick_brambly
region: reg_mossdeep
level: 38
act: 2
requires_rank: D
requires_quests: qst_md_thimble_milk
reward: 1400 | 85 | 5800
sets: md_cat_resolved
summary: A stray kitten the size of a landslide has overturned Fiddlewick's pie cart twice. She is just playing.
objectives:
  talk npc_fiddlewick_brambly
  reach mossdeep_fern_clearing_dusk
  choice oswin_farm_or_guardian
-->

---

## 6. The Aphid Run

*D · Defense · the aphid pastures · giver Pomfrey Dew*

**The short version.** A hailstorm is coming. Pomfrey's aphid herd must be driven under the great mushroom canopy before it hits. It is a thousand aphids, three beetle-riders and one very stubborn bull aphid named **Sir Reginald**.

**What is really going on.** Nothing supernatural. It is a *good old-fashioned herding quest*, with a storm, a stampede and a bull aphid who has taken personal offence at the whole idea of leaving.

**Scene 1: the pasture.**

**POMFREY:** "A thousand head. A *thousand*. And hail in an hour."
**POMFREY:** "I need hands. I need beetles. And I need someone to talk to Reginald."
**POMFREY:** "Reginald is difficult."
> ► **"Which one is Reginald?"** — **POMFREY:** "The *large* one. With the *expression*."
> ► **"What does he want?"** — **POMFREY:** "To be consulted."

**Scene 2: the drive.** A structured defense sequence: the player and three riders drive aphids along a ridge, with hail clouds darkening overhead. Stragglers must be fetched; gaps in the line must be plugged.

**RIDER (calling):** "Left flank's loose! Hold the bend!"
**RIDER 2:** "Reginald's gone *round* the mushroom again!"
*(Gameplay: herding, dodging early hailstones, steering aphids with a lantern.)*

**Scene 3: Reginald.** The bull aphid sits in the middle of the track, eyeing the storm with deep suspicion.

**REGINALD:** *(a soft, offended click)*
**POMFREY:** "He won't move until he's been *asked*."
> ► **"Ask him politely."** — Reginald considers, and *moves*.
> ► **"Push him."** — Reginald sits down.
> ► **"Lead from the front."** — Reginald follows the player like a duck.

**Scene 4: the shelter.** Under the great canopy, with hail the size of apples thudding on the cap, the whole herd huddles together. Reginald is the last in.

**POMFREY:** "...All present. *All present.* A thousand and one."
**POMFREY:** "Reginald, you old fool."
*Reginald clicks, smugly.*

**Outcomes and receipt.**
- The herd survives; the damage to Pomfrey's fields is mostly cosmetic. A bad run costs a few dozen aphids and a day's honeydew.
- **Receipt:** a mushroom-cap shelter stands at the pasture's edge; Reginald stands guard on top of it.

<!-- quest
id: qst_md_aphid_run
title: The Aphid Run
rank: D
type: Defense
giver: npc_pomfrey_dew
region: reg_mossdeep
level: 40
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: md_aphid_resolved
summary: A hailstorm is coming and a thousand aphids must be driven under cover, including a very stubborn bull.
objectives:
  talk npc_pomfrey_dew
  defend mossdeep_aphid_pasture
  choice ask_push_or_lead
-->

---

## 7. The Honey That Wasn't

*C · Investigation · Thimblefolk Mushroom Town · giver Beatrix Combe*

**The short version.** Mossdeep honey sells for a fortune in Aldmere. Beatrix's cousins cannot afford a jar. Somewhere between the hive and the market, the honey is being *replaced*.

**What is really going on.** A **Merchants' Consortium** agent in Aldmere has been mixing Mossdeep honey with cheap sugar-syrup and re-selling it as "pure." The Thimblefolk get paid for the full jar; the fraud eats the difference and drives down the *real* honey's price. The agent has a Thimblefolk partner who does not realise what he is signing.

**Scene 1: the combs.**

**BEATRIX:** "Taste this."
*She hands a tiny spoon. It is the most golden thing you have ever seen.*
**BEATRIX:** "Now taste *this*."
*A second spoon. It is... fine. Sweet. Thin.*
**BEATRIX:** "That's what's sold in Aldmere as 'Mossdeep Pure.' It isn't. It isn't even close."
> ► **"Where does it go wrong?"** — **BEATRIX:** "I don't know. Somewhere on the road."
> ► **"Who benefits?"** — **BEATRIX:** "Not us."

**Scene 2: the trace.** The player follows the honey cart. At the valley mouth, a human clerk, **Ferris Tolley**, meets the cart, signs a paper, and rolls the barrels to a warehouse. Through a window: a vat of syrup, a funnel, a Consortium seal.

**FERRIS:** "We *enhance* it. That's all. A bit of volume. A bit of consistency."
**FERRIS:** "The Thimblefolk are very small. They don't notice."
> ► **"They notice."** — **FERRIS:** "Then they don't *complain*."
> ► **"This is fraud."** — **FERRIS:** "This is a *margin*."
> ► **"Who is your partner?"** — **FERRIS:** "...I don't see that that's relevant."

**Scene 3: the partner.** In the council hall, the player finds the Thimblefolk signatory: **Quince**, the brewer. He is *horrified*.

**QUINCE:** "I thought it was a *distribution* agreement. They said 'blend'. I didn't know it meant... *syrup*."
**QUINCE:** "I've been selling my own people short."
> ► **"Tell the council."** — **QUINCE:** "They'll never trust me again."
> ► **"Fix it quietly."** — **QUINCE:** "Please."
> ► **"Turn the tables."** — **QUINCE:** "How?"

**Scene 4: the sting.** With Beatrix and Quince, the player arranges a *tasting*. At the Aldmere market, a stall of real Mossdeep honey is set up *next to* the Consortium's. The crowd tastes both.

**CUSTOMER:** "That's... that's *much* better."
**CUSTOMER 2:** "I've been buying the wrong honey for *years*."
*Ferris Tolley's face is a study in despair.*

**Outcomes and receipt.**
- The player decides how public to make the fraud. *Public* ruins the Consortium agent and enrages the Consortium; *quiet* repairs Quince and shifts the market.
- **Receipt:** Mossdeep honey prices stabilise at a fair rate; the Thimblefolk open a stall at the Aldmere market; Beatrix gifts a tiny jar.

<!-- quest
id: qst_md_honey_fraud
title: The Honey That Wasn't
rank: C
type: Investigation
giver: npc_beatrix_combe
region: reg_mossdeep
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: md_honey_resolved
summary: Mossdeep honey is being mixed with syrup between the hive and the Aldmere market. The Thimblefolk are paid for the full jar and cheated of the difference.
objectives:
  talk npc_beatrix_combe
  reach aldmere_honey_market
  choice public_quiet_or_sting
-->

---

## 8. The Webcrawler's Larder

*C · Escort · the high ferns · giver Nettle Thrum*

**The short version.** Nettle's son **Tam Thrum** rode out with the beetle riders three nights ago and has not come back. The riders were taken into the high ferns, to Mother Webcrawler's larder.

**What is really going on.** The riders are *alive*. The larder is a vast silk chamber where Mother Webcrawler stores prey. She has not eaten them yet. She is *waiting*, because she has noticed that the Thimblefolk will come for their own, and she has learned that she can use that.

**Scene 1: the stilt-house.**

**NETTLE:** "He's seventeen. He's a good boy. He's a *careful* boy."
**NETTLE:** "The captain says the riders went into the high ferns. I've sent for the big folk twice and nobody came."
**NETTLE:** "You came. I'm... I'm asking you."
> ► **"I'll bring him back."** — **NETTLE:** "Don't promise. Just *go*."
> ► **"How many riders?"** — **NETTLE:** "Seven."
> ► **"What do you know about the larder?"** — **NETTLE:** "That it's *silk*. That it's *high*. That nobody has come back."

**Scene 2: the climb.** A tense, stealthy sequence through the high ferns. Thread-lines vibrate underfoot; each spider tremor is a warning. Mother Webcrawler herself is *never seen*, only felt: a great, slow weight moving somewhere above.

**TAM (a whisper from a silk cocoon):** "...Is that you? Is that actually you?"
**TAM:** "I thought she'd stop. She *talks*. She said: 'one of you will come. They always do.'"
> ► **"We're getting you out."** — **TAM:** "Quietly."
> ► **"Who else is here?"** — **TAM:** "Six. All alive. She's *saving* us."
> ► **"What does she want?"** — **TAM:** "To be *asked*."

**Scene 3: the web.** A single thread connects the larder to the rest of the web. If cut, every spider within a hundred paces will know. If left, the player can slip out the riders one at a time.

> ► **(Cut the web.)** — A short, wild chase through the ferns.
> ► **(Rescue one at a time.)** — A long, patient stealth sequence.
> ► **(Speak to Mother Webcrawler.)** — She answers.

**Scene 4: the answer.** If the player calls into the dark, a vast, soft voice replies, like silk drawn over silk.

**WEBCRAWLER:** "*Small ones. You came. They said you would not. They said the big folk never come.*"
**WEBCRAWLER:** "*I am hungry. I am not cruel. But I am hungry. I would trade. A feast, for a feast. Do you understand?*"
*(She cannot be killed in this quest. She can be bargained with, or fled from, but not slain.)*

**Outcomes and receipt.**
- All seven riders come home. *Bargain* gives the town a seasonal tithe of honey to the Webcrawler; *flight* leaves the siege as it is; *speaking* gives a hint for quest 10.
- **Receipt:** Tam hugs his mother in the stilt-house; the riders hang a woven silk ribbon on the council hall door.

<!-- quest
id: qst_md_webcrawler_larder
title: The Webcrawler's Larder
rank: C
type: Escort
giver: npc_nettle_thrum
region: reg_mossdeep
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: md_larder_resolved
summary: Seven beetle riders are being held alive in Mother Webcrawler's larder. A mother asks a big-folk stranger to bring her son home.
objectives:
  talk npc_nettle_thrum
  reach mossdeep_high_fern_larder
  escort npc_tam_thrum
  choice cut_stealth_or_speak
-->

---

## 9. The Old Shade Grows Cold

*C · Faction · the Old Shade · giver Elder Mossy Pennywhistle*

**The short version.** The great oak at the valley's head is the town's windbreak and its heart. This winter the warm springs beneath it have begun to cool. Mossy would like to know why before the first frost.

**What is really going on.** A mana-line beneath the oak feeds both the warm springs and the tree. Someone, *something*, has been tapping it from below: a tunnel dug by **a Consortium prospector** hoping to find mana-crystal. The prospector is not malicious; she does not know the tree is alive.

**Scene 1: the hollow.**

**MOSSY:** "Child. Sit. The Old Shade is dreaming. Listen."
*A low, long hum, like a distant bell.*
**MOSSY:** "That's the tree. It's *tired*. It speaks to me, in its own way. It says: *something is drinking from my feet*."
**MOSSY:** "The springs are cooler this week. The ferns are drooping. I'm not a wizard. I'm an old woman with a tree."
> ► **"What should I look for?"** — **MOSSY:** "A hole. A cold place. A tunnel."
> ► **"What if it's a spirit?"** — **MOSSY:** "Then it's a spirit that has *rudely* tapped my tree."

**Scene 2: the tunnel.** In the oak's roots, a narrow, newly dug shaft. A human prospector, **Rhona Ellery**, sits at the bottom by a lamp, surrounded by crystal samples and a very confused expression.

**RHONA:** "I'm not *stealing*. I have a permit."
**RHONA:** "This is a mana-line. A good one. Hundred-year-old oak, healthy roots, perfect for a *mining operation*."
**RHONA:** "Why are you looking at me like that?"
> ► **"The tree is alive."** — **RHONA:** "...It's a *tree*."
> ► **"You're hurting it."** — **RHONA:** "That's not... the *permit* doesn't say so."
> ► **"Come meet the elder."** — **RHONA:** "I have a deadline."

**Scene 3: the elder.** In the hollow, Mossy and Rhona face each other across a small fire.

**MOSSY:** "You're digging in my friend's feet."
**RHONA:** "Your friend... is a tree."
**MOSSY:** "My friend is a tree *who is dying of your tunnel*."
*Rhona looks at the roots, then at the hollow, then at her own hands.*
**RHONA:** "...I did not know."
> ► **"Close the tunnel."** — **RHONA:** "I'll lose the contract."
> ► **"Redirect the mana-line."** — **RHONA:** "That would take months."
> ► **"Offer an alternative."** — **RHONA:** "Like what?"

**Scene 4: the fix.** The player brokers a compromise: Rhona's team re-seals the tunnel and moves the mining to a *dry* seam away from the oak; in exchange, Mossy grants the Consortium a *tiny* share of the warm spring's water for medicine.

**MOSSY:** "It's warm. Feel. It's warm again."
**RHONA:** "...I think I owe the tree an apology."
*She kneels, places her hand on the bark, and says it.*

**Outcomes and receipt.**
- The warm springs return; the oak puts out a late, blossom-heavy spring. If the player *sides against the Consortium*, Rhona is fired but befriended.
- **Receipt:** a small plaque on the Old Shade; Rhona sends a gift of mana-crystal each winter.

<!-- quest
id: qst_md_old_shade_cold
title: The Old Shade Grows Cold
rank: C
type: Faction
giver: npc_mossy_pennywhistle
region: reg_mossdeep
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: md_shade_resolved
summary: The warm springs beneath the Old Shade are cooling. A prospector has tunnelled into the tree's mana-line without knowing it is alive.
objectives:
  talk npc_mossy_pennywhistle
  reach old_shade_roots_tunnel
  choice close_redirect_or_alternative
-->

---

## 10. The Big Folk Are Asked

*C · Faction · the council hall · giver Speaker Maplin Thorne*

*Best played after quests 3 and 8. If the council voted **not** to ask, this quest becomes **The Big Folk Are Not Asked**, a smaller version with a different reward.*

**The short version.** The council has decided to ask the big folk for help against Mother Webcrawler. Maplin has written a *formal request*. It is eleven pages. He needs someone to deliver it, and to say yes.

**What is really going on.** The Thimblefolk do not want a hero. They want a *treaty*. For four hundred years they have survived by being small and polite. The request is a *peace-offer* to the Webcrawler *through* the player, because they want the big folk to carry the message, so that the spider will know the Thimblefolk are not alone.

**Scene 1: the request.**

**MAPLIN:** "It is eleven pages. I have rewritten it nine times."
**MAPLIN:** "It begins: 'Honoured Big Folk, in the name of the Thimblefolk Mushroom Town, we respectfully request...' and ends: 'with deepest apologies for the trouble.'"
**MAPLIN:** "I do not know if that is the correct tone."
> ► **"It's perfect."** — **MAPLIN:** "You are being kind."
> ► **"It's a bit long."** — **MAPLIN:** "It is a *treaty*."
> ► **"What do you want me to do?"** — **MAPLIN:** "Carry it to the Webcrawler. And *say* it."

**Scene 2: the treaty walk.** The player carries the request through the fern forest at Thimblefolk scale, past riders on watch, a hush of aphid herds, a silent crowd lining the path. At the foot of the high ferns, a vast silk gate opens.

**WEBCRAWLER:** "*A small one. Carrying a small letter. I am... curious.*"
**PLAYER (reading):** "Honoured Webcrawler, in the name of the Thimblefolk..."
*(A short, tense reading; each paragraph is a dialogue check. The treaty is not to be rushed.)*

**Scene 3: the terms.** Mother Webcrawler listens. She does not agree. She *bargains*.

**WEBCRAWLER:** "*I am hungry. You are small. You are brave. I am... not accustomed to being asked.*"
**WEBCRAWLER:** "*What you want is not peace. It is distance. I will give you distance. For a price.*"
> ► **"A seasonal tithe of honey."** — **WEBCRAWLER:** "*Honey is... acceptable.*"
> ► **"A shared hunting-ground."** — **WEBCRAWLER:** "*...Interesting.*"
> ► **"Nothing."** — **WEBCRAWLER:** "*Then there is no treaty.*"

**Scene 4: the accord.** The terms are written in silk on a long ribbon that stretches from the high ferns to the council hall. Speaker Maplin signs with a quill the size of a pin. The Webcrawler signs with a single, delicate leg.

**MAPLIN:** "It is... done."
**WEBCRAWLER:** "*It is a beginning.*"
**MAPLIN:** (very quietly, to the player) "I have never been prouder of a bad letter."

**Outcomes and receipt.**
- The siege *state* is unchanged; Mother Webcrawler is still the Tyrant and can still be fought. But she no longer raids the town's outer huts while the accord holds, and her pre-fight dialogue changes.
- **Receipt:** a silk ribbon hangs in the council hall; the beetle riders stand a little straighter; Speaker Maplin writes a twelve-page thank-you.

<!-- quest
id: qst_md_big_folk_asked
title: The Big Folk Are Asked
rank: C
type: Faction
giver: npc_maplin_thorne
region: reg_mossdeep
level: 68
act: 3
requires_rank: C
requires_quests: qst_md_seed_recount
reward: 4600 | 250 | 17000
sets: md_accord_resolved
summary: The Thimblefolk council has written an eleven-page request to the big folk. It is really a peace-offer to Mother Webcrawler.
objectives:
  talk npc_maplin_thorne
  reach mossdeep_webcrawler_gate
  choice tithe_hunting_ground_or_nothing
-->
