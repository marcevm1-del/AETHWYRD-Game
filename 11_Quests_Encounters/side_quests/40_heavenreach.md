# 11e-40 — Heavenreach, the Eyrie of the Heavenfolk: Ten Side Quests (draft)

> *"A promise carried is a promise kept. A promise dropped is a wing broken."*
> — courier-cant proverb, Heavenreach

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 7, 8 and 9 plant unexplained seeds, and quest 8 invents the contents of a letter (see the report).

**Region:** `reg_heavenreach` (the eyries, the Long Stair, the Tribute Peak, the Ledges of Last Flight, the valley below). **Rank band:** A–S. **Tone:** proud, formal, spare of speech, tender underneath; thin cold air and long memories.

**Placement notes.**
- **Aquilon, the Roc Sovereign,** is the region's Tyrant. He demands a tithe of everything that flies: food, feathers and, lately, children. No quest here kills, defeats or bargains away Aquilon. His rocs appear in quests 3, 5 and 10; Aquilon himself appears only as a shadow, a feather and a rumour.
- Customs the quests rely on: **courier-cant,** a language of short, exact sentences; **a child's first flight** is the most important day of a life; **a Heavenfolk who cannot fly is mourned as if dead;** the dead are laid on the **Ledges of Last Flight** for the birds; **breaking a sworn message** is the gravest sin; flight paths are marked with **painted stones;** wingless visitors climb the **Long Stair** (eleven thousand steps, no railing); the council is split over whether to pay the tithe.
- Heavenfolk are people with feathered wings; NPC `race` is written `Heavenfolk`. Valley folk and merchants are `Human`.
- Not used: a siege. Quest 5 is plain `Defense`.
- **Rank note.** This region's band reaches S. Quests 8, 9 and 10 are S-rank; their rewards are extrapolated as in [[31_whitewater_reach]] (S: level 166–205; GP about 3,000; see `Data/World/guild_ranks.json`) and are first-pass.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The First Message | A | Delivery | Cadet Ceyla Ashwing | A courier's first oath, a generation late |
| 2 | Eleven Thousand Steps | A | OddJob | Merchant Bartolo Sellick | A crate, and who it is for |
| 3 | A Climber, Not a Flyer | A | Exploration | Vesna Valewind | A mother, a peak, a bargain not made |
| 4 | A Ledge for a Stranger | A | Hidden | Stair-keeper Gethin Tallstep | A burial the sky does not allow |
| 5 | Flight in Numbers | A | Defense | Wingmistress Kaelis Thornfeather | Young wings under a roc shadow |
| 6 | The Council Cannot Decide | A | Faction | Eldest Mavren Hightalon | Two sides, one tithe |
| 7 | The Stone That Ends in Air | A | Investigation | Flyer Tolvik Swiftrest | A brother's last painted path |
| 8 | The Letter She Carried | S | Investigation | Keeper Ilvane Greywing | A letter, thirty years undelivered |
| 9 | Above the Weather | S | Exploration | Chart-flyer Peregrin Windrede | The thin air, and what it shows |
| 10 | The Bronze Feather | S | Hidden | Wrangler Rennick Lowperch | A roc chick, fallen |

## Cast

<!-- npc
id: npc_cadet_ceyla_ashwing
name: Cadet Ceyla Ashwing
tier: major
race: Heavenfolk
region: reg_heavenreach
settlement: Heavenfolk eyries
role: Young flyer who wants to carry messages again
backstory: A restless nineteen-year-old with grey-and-russet wings who has secretly trained as a courier since the council ended the practice, and who wants her first oath carried by someone with feet.
-->
<!-- npc
id: npc_merchant_bartolo_sellick
name: Merchant Bartolo Sellick
tier: townsfolk
race: Human
region: reg_heavenreach
settlement: Valley below Heavenreach
role: Valley merchant with a crate for the eyrie
backstory: A tired, stubbornly honest merchant of fifty who has been paid, well, to carry a crate up eleven thousand steps and not to ask what is in it.
-->
<!-- npc
id: npc_vesna_valewind
name: Vesna Valewind
tier: major
race: Human
region: reg_heavenreach
settlement: Valley below Heavenreach
role: Yak-herder whose son was taken as tribute
backstory: A broad-shouldered yak-herder who cannot fly, cannot sleep and has decided that if the sky took her son, a climber can fetch him back.
-->
<!-- npc
id: npc_stair_keeper_brannoch_tallstep
name: Stair-keeper Gethin Tallstep
tier: townsfolk
race: Human
region: reg_heavenreach
settlement: The Long Stair
role: Keeper of the Long Stair
backstory: A gnarled stair-keeper who has counted the eleven thousand steps every morning for forty years and who holds the body of a wingless friend in the lowest hut, because the valley has no ground fit to bury him.
-->
<!-- npc
id: npc_wingmistress_kaelis_thornfeather
name: Wingmistress Kaelis Thornfeather
tier: major
race: Heavenfolk
region: reg_heavenreach
settlement: Heavenfolk eyries
role: Leader of the young flyers' escort
backstory: A fierce, brown-winged flyer of forty who has lost four students to the roc flock and has decided that no child of hers will fly alone again.
-->
<!-- npc
id: npc_eldest_mavren_hightalon
name: Eldest Mavren Hightalon
tier: major
race: Heavenfolk
region: reg_heavenreach
settlement: Heavenfolk eyries
role: Eldest of the council of flyers
backstory: An ancient, white-winged eldest who can still reach the highest eyrie only on the best days, and who has not yet decided whether to pay Aquilon's tithe.
-->
<!-- npc
id: npc_flyer_tolvik_swiftrest
name: Flyer Tolvik Swiftrest
tier: townsfolk
race: Heavenfolk
region: reg_heavenreach
settlement: Heavenfolk eyries
role: Flyer searching for a missing brother
backstory: A quiet, lean flyer whose younger brother took off on a solo flight three weeks ago and left a trail of painted stones that stops in empty air.
-->
<!-- npc
id: npc_keeper_ilvane_greywing
name: Keeper Ilvane Greywing
tier: major
race: Heavenfolk
region: reg_heavenreach
settlement: Heavenfolk eyries
role: Keeper of the Ledges of Last Flight
backstory: A grave, silver-winged keeper whose mother was the messenger executed for the contents of a letter she carried, and who has kept the Ledges for thirty years without once asking what was in it.
-->
<!-- npc
id: npc_chart_flyer_orsolo_windrede
name: Chart-flyer Peregrin Windrede
tier: major
race: Heavenfolk
region: reg_heavenreach
settlement: Heavenfolk eyries
role: Maker of flight charts
backstory: A cheerful, ink-stained chart-flyer of seventy who has drawn the safe lanes between the eyries for fifty years and is now drawing, with growing alarm, the lanes the rocs have taken.
-->
<!-- npc
id: npc_wrangler_rennick_lowperch
name: Wrangler Rennick Lowperch
tier: townsfolk
race: Human
region: reg_heavenreach
settlement: Valley below Heavenreach
role: Falcon-wrangler of the foothills
backstory: A soft-spoken falcon-wrangler who found a bronze-feathered chick on a lower scree slope and has hidden it in his hawk-loft, knowing exactly whose chick it must be.
-->

---

## 1. The First Message

*A · Delivery · the eyries to the valley · giver Cadet Ceyla Ashwing*

**The short version.** The Heavenfolk have not flown a message for a crown since a king killed a messenger over a letter. Ceyla wants to fly one again, a plain message, from one person to another, with an oath. She asks the player to carry the first with her, on foot, as her second.

**What is really going on.** The message is not important. That is the point: it is a widow's note to a weaver in the valley, saying that her loom-thread is ready. Ceyla needs to prove that a promise can still be carried safely. The risk is not the road. It is that she is tempted to *open* the letter when the road gets hard.

**Scene 1: the practice ledge.**

**CEYLA:** "Short. Exact. That is courier-cant. I have practised it in the mirror for three years."
**CEYLA:** "The council forbids us to carry. But no one forbade us to *walk* beside someone who does."
**CEYLA:** "I need a ground-dweller who will not drop a promise."
> ► **"What is the message?"** — **CEYLA:** "I do not know. It is sealed. That is the first rule."
> ► **"What if the council finds out?"** — **CEYLA:** "Then they will have to say it aloud."
> ► **"I'll carry it with you."** — **CEYLA:** "Swear it. In cant. Short."

**Scene 2: the oath.** On a ledge above the cloud line, with the wind pulling their cloaks, Ceyla teaches the player the oath of the road: six words, three beats, a hand on the seal.

**CEYLA:** "Say it. *Sealed I take. Sealed I give.*"
**YOU:** "Sealed I take. Sealed I give."
**CEYLA:** "Again. You rushed the *give.*"

**Scene 3: the road.** Down the Long Stair and across the foothill meadows, a long, windy journey. A rock-slide closes the path; a yak-herd will not move; a storm turns the final ridge to ice. At the worst of it, the seal on the letter cracks in Ceyla's pack.

**CEYLA (white-faced):** "It is open."
**CEYLA:** "It has not been *read.* It is only *open.*"
**CEYLA:** "...I could close it. Nobody would know."
> ► **"We tell the weaver."** — **CEYLA:** "That the seal broke?" **YOU:** "That the seal broke, and that we did not read it." **CEYLA:** "Yes. That is the oath."
> ► **"Read it, so we can carry it by heart if it is lost."** — **CEYLA:** "...No. That is the sin."
> ► **"Seal it with wax from the lantern."** — A clean fix, and a small lie by silence.

**Scene 4: the loom.** At the weaver's door, an elderly woman reads the note, laughs once and turns to the room.

**WEAVER:** "It says my thread is ready! After three months! I thought she had forgotten."
**CEYLA (very quietly):** "It was delivered."
**WEAVER:** "A winged courier. At my door. My mother used to say it was an honour."
*Ceyla stands very straight. She does not smile until the weaver is not looking.*

**Coda: the cant.** Before the player leaves the ledge, Ceyla teaches one last phrase, the one the old couriers spoke on completing a road.

**CEYLA:** "'*Given as taken.*' It means: nothing added, nothing lost."
**CEYLA:** "My grandmother said it a thousand times. I have never said it to anyone who deserved it."
> ► **"Given as taken."** — **CEYLA:** "Again. Slower. You are rushing the *taken.*"
> ► **"What will you carry next?"** — **CEYLA:** "Whatever is sealed and asked. Even a bad pie."
*Far below, the weaver's chimney sends up a thin, steady line of smoke, like a ribbon tied to the day.*

**Outcomes and receipt.**
- The first message in a generation is carried, with a witness. If the player had the seal re-waxed without telling the weaver, the delivery stands but Ceyla never forgets the small lie. If the player read the letter, Ceyla refuses to go on and the delivery is made by the player alone, without her.
- **Receipt:** a courier's cord, one knot, tied to the player's belt; Ceyla's cant gains a sentence: *"Carried together."*

<!-- quest
id: qst_hvr_first_message
title: The First Message
rank: A
type: Delivery
giver: npc_cadet_ceyla_ashwing
region: reg_heavenreach
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: hvr_first_message_done
summary: A young flyer wants to carry the first message in a generation and asks a ground-dweller to walk it with her. The seal cracks on the road.
objectives:
  talk npc_cadet_ceyla_ashwing
  reach heavenreach_weaver_door
  choice tell_read_or_rewax
-->

---

## 2. Eleven Thousand Steps

*A · OddJob · the Long Stair · giver Merchant Bartolo Sellick*

**The short version.** A valley merchant has been paid well to carry a crate up the Long Stair, and not to ask what is in it. The crate is awkward, heavy and clinking. He asks the player to help, and to keep an eye on him if he gives in to curiosity.

**What is really going on.** The crate holds a **flight-frame,** a harness of ash-wood struts and silk, built by a valley craftsman for a Heavenfolk woman who has lost the use of one wing. Among the Heavenfolk, those who cannot fly are mourned as dead. Her friend wants her to fly again before anyone has to know.

**Scene 1: the first step.**

**BARTOLO:** "Eleven thousand steps. No railing. A crate that weighs as much as a calf."
**BARTOLO:** "Whoever paid me paid for a good deal of silence. I am inclined to give it."
**BARTOLO:** "I would not mind if you kept me honest."
> ► **"What's your fee?"** — **BARTOLO:** "Enough to buy a small field. That's what worries me."
> ► **"Shall we peek?"** — **BARTOLO:** "I said *keep me honest.*"
> ► **"I'll take the back end."** — **BARTOLO:** "Mind the third landing. It crumbles."

**Scene 2: the climb.** A long, breathless climb up eleven thousand steps. The valley shrinks to a green stitch. Prayer-flags tear in the wind. At every landing a Heavenfolk guard watches without a word. At the sixth landing, the crate shifts, and a strut shows through the slats.

**BARTOLO:** "That is a wing."
**BARTOLO:** "That is... a *made* wing."
**BARTOLO:** "Who in the eyries needs a wing someone else has built?"
> ► **"Someone who has lost theirs."** — **BARTOLO (stricken):** "They'd be... they'd be mourned."
> ► **"It's not our business."** — **BARTOLO:** "It is exactly our business. We are carrying it."
> ► **"Let's finish the climb."** — They climb in silence.

**Scene 3: the recipient.** At the top, in a small, plain eyrie, an old Heavenfolk with one drooping wing receives them with courtesy. Her name is Haldis. She does not look at the crate.

**HALDIS:** "I have been told you carry something."
**HALDIS:** "Do not tell me what. Put it down. Go and drink tea."
*Later, from behind a door, the sound of strapped leather, of silk, of a breath held. Then a rustle, huge and unfamiliar, and a long, trembling laugh.*
> ► **(Wait outside.)** — A long minute.
> ► **(Ask her if she needs anything.)** — **HALDIS (through the door):** "Only a wind."
> ► **(Warn her of the council.)** — **HALDIS:** "They already know. They are pretending not to."

**Scene 4: the ledge.** Haldis steps onto the edge of her eyrie in the harness. The wind rises. For a moment she stands, rigid. Then she opens her wings, the good one and the built one, and drops.

**BARTOLO (whispering):** "She's *flying.*"
*The frame holds. Below, a handful of watching Heavenfolk draw breath. None of them speaks. One, very slowly, lifts a hand in the courier-cant salute.*

**Coda: the thread.** Bartolo does not go home straight away. He sits on the top step, hands dangling, and watches the sky where the flyer has gone.

**BARTOLO:** "I was paid to be silent. I did not expect it to be so *loud.*"
**BARTOLO:** "My wife used to say a thing was only worth carrying if you were ashamed to put it down."
> ► **"You carried it well."** — **BARTOLO:** "Eleven thousand steps. I shall feel every one tomorrow."
> ► **"Will you tell anyone?"** — **BARTOLO:** "No. But I shall walk differently. People will wonder why."

**Outcomes and receipt.**
- Haldis flies, haltingly, and the council, who saw, say nothing. Bartolo goes home with his fee and a grandmother's blessing. If the player warned her of the council, she flies at dusk, out of sight, and keeps the secret a little longer.
- **Receipt:** a single silk thread tied to the crate-handle; the craftsman's workshop receives a commission list that grows.

<!-- quest
id: qst_hvr_eleven_steps
title: Eleven Thousand Steps
rank: A
type: OddJob
giver: npc_merchant_bartolo_sellick
region: reg_heavenreach
level: 124
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: hvr_eleven_steps_done
summary: A merchant has been paid to carry a crate up the Long Stair and not to ask. The crate holds a built wing for a flyer who cannot fly.
objectives:
  talk npc_merchant_bartolo_sellick
  reach heavenreach_maelis_eyrie
  choice warn_wait_or_finish
-->

---

## 3. A Climber, Not a Flyer

*A · Exploration · the Tribute Peak · giver Vesna Valewind*

**The short version.** Aquilon has taken a child as tribute. Vesna's son, Arlo, was eight. She cannot fly and she will not wait for the council. She wants a climber to go up the Tribute Peak and bring him down.

**What is really going on.** Arlo is alive. He is held in a stone nest among a handful of tribute children, fed, cold and unharmed, because rocs do not know what to do with them. The player cannot defeat the Roc Sovereign, and the quest never tries. The task is to get *one* child down without provoking the flock, and to decide what to do about the others.

**Scene 1: the yak-camp.**

**VESNA:** "He took his flute and went to the high pasture. A shadow came. That is all I have."
**VESNA:** "The council says the tithe is a matter for the council. My son is not a matter."
**VESNA:** "I do not want you to fight. I want you to *bring him down.*"
> ► **"Where is he?"** — **VESNA:** "The Tribute Peak. The rocs keep the tithe in a stone nest."
> ► **"I can't promise."** — **VESNA:** "Then promise to try. I have no other offer."
> ► **"I'll climb."** — **VESNA:** "Take his scarf. He will know it."

**Scene 2: the ascent.** Three days of thin-air climbing: ice-glazed chimneys, wind that pins a climber to the face, a ledge where a snow leopard watches and does nothing. Overhead, a long, dark roc circles twice and moves on.

*(Gameplay: a long vertical climb; stamina and wind management; no combat unless the player lingers in a roc's sight.)*

**Scene 3: the nest.** On a shelf of rock below the summit, six children sit in a ring of stones, wrapped in feathers. Arlo is at the edge, playing a flute that makes no sound in the thin air.

**ARLO:** "Mother's scarf."
**ARLO:** "I knew somebody would come. I just thought it'd be the rocs again."
**ARLO:** "There are five others. They are cold."
> ► **"I can take one at a time."** — **ARLO:** "Then take Neve first. She is the smallest."
> ► **"We have to go now."** — **ARLO:** "Not without Neve."
> ► **"I'll come back for the rest."** — **ARLO:** "You'll want to. Say it like you mean it."

**Scene 4: the descent.** The player carries two children down, one on a back, one in a sling, over the course of a long, silent day. A bronze shadow passes overhead, once, and does not descend.

**VESNA (at the foot, on her knees):** "Arlo."
**ARLO:** "I brought Neve."
**VESNA:** "...Then I will go and find Neve's mother."
*Behind them, high up the peak, four children remain in the nest. A column of smoke rises from a cairn the player built on the ledge: a signal to the eyries that someone has come, and will come again.*

**Coda: the cairn.** That night, in the yak-tent, Vesna sits with her son and does not let go of his hand. Arlo, half-asleep, mumbles:

**ARLO:** "The big shadow didn't come down because it was *counting.*"
**VESNA:** "Counting what, love?"
**ARLO:** "Us. I think it knows there's four left."
*Vesna looks at the player over the sleeping boy's head. She says nothing in words.*
> ► **"I will go back."** — **VESNA:** "Then I will bring soup, and rope, and anyone who can hold either."
> ► **"The eyries know now."** — **VESNA:** "They know. Let us see what knowing does."

**Outcomes and receipt.**
- Arlo and Neve are returned. The other four stay, and the player's cairn tells the council it is no longer a private matter. Aquilon is not engaged. If the player tried to take all six, the climb fails halfway and nobody is lost, but nobody is saved either.
- **Receipt:** the silent flute, hung in Vesna's tent; a cairn on the Tribute Peak, lit each dusk by a Heavenfolk who will not give a name.
- **Open thread:** the remaining four children are not resolved here.

<!-- quest
id: qst_hvr_climber_not_flyer
title: A Climber, Not a Flyer
rank: A
type: Exploration
giver: npc_vesna_valewind
region: reg_heavenreach
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: hvr_climber_done
summary: A yak-herder's son was taken as Aquilon's tribute. She wants a climber, not a flyer, to bring him down the Tribute Peak.
objectives:
  talk npc_vesna_valewind
  reach heavenreach_tribute_nest
  choice smallest_all_or_return
-->

---

## 4. A Ledge for a Stranger

*A · Hidden · the Long Stair · giver Stair-keeper Gethin Tallstep*

**The short version.** Gethin's oldest friend, a wingless valley man named Haskel, died at the foot of the Stair. The valley has no ground fit to bury him in winter. Gethin wants him laid on a Ledge of Last Flight, which is forbidden to anyone without wings.

**What is really going on.** Haskel carried loads up the Stair for forty years and was, in his way, a part of every eyrie. The Heavenfolk do not forbid him out of cruelty; the rule is old, and nobody has asked them to bend it. Keeper Ilvane Greywing, who keeps the Ledges, is the one to ask.

**Scene 1: the hut.**

**BRANNOCH:** "Forty years. He carried flour up and feathers down. He never complained once."
**BRANNOCH:** "He asked, last winter, if he could go on the Ledges. As a joke. He did not mean it."
**BRANNOCH:** "I think he did."
> ► **"Who keeps the Ledges?"** — **BRANNOCH:** "Ilvane Greywing. She is not a cruel woman."
> ► **"Is it forbidden?"** — **BRANNOCH:** "It is not *written.* It has simply never been asked."
> ► **"I'll speak for him."** — **BRANNOCH:** "In short sentences. She likes those."

**Scene 2: the Keeper.** At the Ledges, high on a cliff-face white with frost, Ilvane Greywing listens to the case in courier-cant. Her answer is a single sentence.

**ILVANE:** "The Ledges are for those who flew."
**YOU:** "He climbed eleven thousand steps a day for forty years."
**ILVANE:** "Climbing is not flying."
> ► **"The birds don't care."** — **ILVANE:** "The birds are not the rule-makers."
> ► **"He carried your food."** — **ILVANE:** "Many carried our food."
> ► **"What would make it right?"** — **ILVANE:** "...That is a better question."

**Scene 3: the condition.** After a long silence, Ilvane sets a condition: Haskel must be carried the whole eleven thousand steps by hand, not by flyers, by the people he served. A ground-dweller's burden, for a ground-dweller's last climb.

**ILVANE:** "If the valley will carry him, I will lay him."
**ILVANE:** "If it will not, he belongs to the valley."
> ► **(Ask the valley.)** — A long, wary day, door to door.
> ► **(Carry him yourself.)** — A hard, honest climb.
> ► **(Ask the Heavenfolk to help carry.)** — Ilvane stiffens, then relents, a little.

**Scene 4: the last climb.** At dawn, thirty valley folk begin the climb, and with them, at the third landing, six Heavenfolk guards who say nothing and take the poles from tired hands. At the top, Ilvane lays Haskel on the highest ledge in the oldest way, with his arms folded across his chest like folded wings.

**ILVANE:** "He flew."
**BRANNOCH (hoarse):** "Every step."
*A lammergeier circles once, low, and drifts away over the valley.*

**Coda: the boots.** Weeks later, passing the foot of the Stair, the player finds a line of small offerings: a pair of worn boots, a flour sack, a yak-bell, a carved wooden step.

**GETHIN:** "The valley leaves them. Every morning something new."
**GETHIN:** "Ilvane came down last week. Put a feather on the boots. Said nothing."
> ► **"What did the feather say?"** — **GETHIN:** "It said *noticed.* In cant, that is a great deal."
> ► **"Will you climb it again tomorrow?"** — **GETHIN:** "Every step. I have a count to keep."

**Outcomes and receipt.**
- Haskel is laid on a Ledge. The rule is not changed; an exception is made, and recorded. If the player asked the Heavenfolk to help carry, the exception is granted without argument but Ilvane writes it in her private log as a question.
- **Receipt:** a pair of worn boots on a stone at the foot of the Stair, left by the valley; a small mark on the Ledge: *"One who climbed."*

<!-- quest
id: qst_hvr_ledge_stranger
title: A Ledge for a Stranger
rank: A
type: Hidden
giver: npc_stair_keeper_brannoch_tallstep
region: reg_heavenreach
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: hvr_ledge_done
summary: A stair-keeper wants his wingless friend laid on a Ledge of Last Flight, which is forbidden to anyone who did not fly.
objectives:
  talk npc_stair_keeper_brannoch_tallstep
  talk npc_keeper_ilvane_greywing
  reach heavenreach_ledges_of_last_flight
  choice valley_self_or_heavenfolk
-->

---

## 5. Flight in Numbers

*A · Defense · the flight paths · giver Wingmistress Kaelis Thornfeather*

**The short version.** Since Aquilon's rise, the Heavenfolk fly in groups for safety. Kaelis escorts the young flyers between eyries. Tonight she has forty fledglings to move across a roc-haunted gap. She has twelve escorts and needs a ground-dweller who can fight on the painted stones.

**What is really going on.** The rocs are not attacking out of hatred. They have been told to *collect.* They stoop at any lone flyer, and at groups they test the edges. Kaelis will not fight the flock; she will hold a line until the children are across. The player's job is to hold the landing-stone at the far side.

**Scene 1: the muster.**

**KAELIS:** "Forty fledglings. Twelve escorts. One gap. Nine hundred wingbeats."
**KAELIS:** "I have lost four students. I will not lose a fifth."
**KAELIS:** "You hold the stone at the far side. We do not kill rocs. We *deter* them."
> ► **"What do rocs fear?"** — **KAELIS:** "Noise. Smoke. A bright flag."
> ► **"What if one gets through?"** — **KAELIS:** "Then I will be there."
> ► **"I'll hold the stone."** — **KAELIS:** "Good. Do not leave it."

**Scene 2: the crossing.** In the cold light before dusk, forty young flyers lift off in a long, ragged line, wings beating in the thin air, escorted by a ring of adults. The player stands on the landing-stone, a ledge no wider than a barn door, with a smoke-pot, a flag and a horn.

*(Gameplay: wave defence; the player must keep the landing clear and the smoke burning; rocs stoop in pairs.)*

**FLEDGLING (shouting):** "There's one on the left!"
**KAELIS (from above):** "Eyes front! Keep the line!"

**Scene 3: the stoop.** A huge roc, bronze at the wingtips, folds and drops. Fledglings scatter. For a heartbeat, the line breaks.

> ► **(Fire the smoke-pot.)** — A thick grey plume; the roc veers, snarling.
> ► **(Sound the horn.)** — A long, ugly note; the fledglings regroup.
> ► **(Throw up a flag, and shout their names.)** — The line closes, a name at a time.

**KAELIS:** "That was too close."
**KAELIS:** "That was exactly close enough."
*Overhead, the fledglings who saw it say nothing. They have understood, all at once, why the adults fly in a ring, and what the ring is for. One of them, very small, grips the next one's wingtip and does not let go until the stone.*

**Scene 4: the landing.** One by one, forty fledglings drop onto the stone, gasping, laughing. The last to land is Kaelis, who sets down carefully and counts under her breath.

**KAELIS:** "Thirty-eight, thirty-nine, forty."
**KAELIS:** "Forty."
*She sits down on the cold stone, folds her wings, and puts her face in her hands.*

**Coda: the counting game.** Back on the near eyrie, the fledglings have invented a game. One stands on a rock and shouts a number; the others must land in the order of their heights, wings folded, silent.

**FLEDGLING:** "Forty! Say forty! Now you're *Kaelis!*"
**KAELIS (dry):** "I do not sit down like that."
**FLEDGLING:** "You *do.* We saw."
> ► **"Let them have it."** — **KAELIS:** "I will. But I will not be the one who is Kaelis."
> ► **"You earned it."** — **KAELIS:** "Forty out of forty. Yes. I did."

**Outcomes and receipt.**
- All forty cross. The rocs withdraw, hungry; Aquilon's tithe is not paid in full this season, and the flock's attention is noted. If the player used the horn, the fledglings are scattered but safe; if the smoke, the lane is blocked for a day.
- **Receipt:** a small red flag on the landing-stone, *"Held;"* the fledglings' game of counting aloud.
- No siege: the rocs are Aquilon's, and he is not present.

<!-- quest
id: qst_hvr_flight_numbers
title: Flight in Numbers
rank: A
type: Defense
giver: npc_wingmistress_kaelis_thornfeather
region: reg_heavenreach
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: hvr_flight_done
summary: Forty fledglings must cross a roc-haunted gap. The wingmistress needs someone to hold the landing stone.
objectives:
  talk npc_wingmistress_kaelis_thornfeather
  defend heavenreach_landing_stone
  choice smoke_horn_or_names
-->

---

## 6. The Council Cannot Decide

*A · Faction · the highest eyrie · giver Eldest Mavren Hightalon*

**The short version.** The council of eldest flyers is split on whether to pay Aquilon's tithe. Two factions have drawn up their cases. The Eldest wants a neutral ground-dweller to carry each side's argument to the other, word for word, in courier-cant, with no spin.

**What is really going on.** The council has argued for months. Neither side is wrong. The Pay faction fears the children; the Refuse faction fears the precedent. The player's role is only to *carry the words faithfully,* and to resist the temptation to soften them.

**Scene 1: the highest eyrie.**

**MAVREN:** "Two sides. One tithe. Nine months."
**MAVREN:** "I cannot carry their words. I am one of them. You are a messenger."
**MAVREN:** "In cant. Exactly. If you soften a word, I will know."
> ► **"What are the sides?"** — **MAVREN:** "Pay, and spare the young. Refuse, and spare the future."
> ► **"What do you want?"** — **MAVREN:** "For each to hear the other. Once."
> ► **"I'll carry it."** — **MAVREN:** "Sealed you take. Sealed you give."

**Scene 2: the Pay faction.** On a sunlit ledge, a council flyer named Ulrika speaks quickly.

**ULRIKA:** "We pay. A tithe of food, feathers, the cost of a few. The children we do not give. We *argue.* But we pay."
**ULRIKA:** "A tithe is the price of a season of peace."
**ULRIKA:** "Say it back."
> ► **(Repeat it exactly.)** — **ULRIKA:** "Good."
> ► **(Shorten it.)** — **ULRIKA:** "No. In full."
> ► **(Add a gentle word.)** — **ULRIKA:** "Take it out."

**Scene 3: the Refuse faction.** In a windy, ice-rimed hall, a sharper-voiced flyer named Thrace waits.

**THRACE:** "No tithe. Not a feather. Pay once and we are his. He wants the *children.* Next year he wants the *eyries.*"
**THRACE:** "If we must fall, let us fall as ourselves."
**THRACE:** "Say it back."
*The player carries the Pay faction's words across; the Refuse faction's across again. Each side listens, rigid, then falls silent.*

**Scene 4: the answer.** Neither side moves. But on the third night, Ulrika and Thrace, who have not spoken in nine months, share a cup of tea on a ledge. They do not decide anything.

*A young council-runner, watching from the stair, has to be told twice to stop staring. In forty years she has never seen the two of them in the same place without a wall between.*
**MAVREN:** "That is the first time."
**MAVREN:** "I did not ask for a decision. I asked for a conversation."
> ► **(Say, "They each heard the other.")** — **MAVREN:** "Yes."
> ► **(Say, "They're still stuck.")** — **MAVREN:** "Yes. Stuck, together."
> ► **(Say nothing.)** — **MAVREN:** "Wise. That, too, is cant."

**Coda: the cups.** Weeks later, Mavren invites the player to see the council ledge. Two cups sit side by side on a flat stone. One is chipped. One is new.

**MAVREN:** "They drink at dusk. They argue as they drink. It is not peace. It is the habit of being near."
**MAVREN:** "I am told that is how most peace begins."
> ► **"Will they decide?"** — **MAVREN:** "Not tomorrow. But the next time they disagree, they will do it face to face."
> ► **"Good."** — **MAVREN:** "In cant, that is a long speech. Well done."

**Outcomes and receipt.**
- The council begins to talk. The tithe question is **not answered.** If the player softened any word, the Eldest notices and a small cloud of mistrust follows the player through the eyries.
- **Receipt:** a pair of cups on the council ledge; a new custom of "speaking by carrier" before any vote.

<!-- quest
id: qst_hvr_council_decide
title: The Council Cannot Decide
rank: A
type: Faction
giver: npc_eldest_mavren_hightalon
region: reg_heavenreach
level: 134
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: hvr_council_done
summary: The council is split on whether to pay Aquilon's tithe. The Eldest wants a neutral messenger to carry each side's argument to the other, word for word.
objectives:
  talk npc_eldest_mavren_hightalon
  reach heavenreach_council_ledge
  choice exact_shorten_or_soften
-->

---

## 7. The Stone That Ends in Air

*A · Investigation · the flight paths · giver Flyer Tolvik Swiftrest*

**The short version.** Young flyers have been vanishing on solo flights. Tolvik's brother, Kest, took off three weeks ago and left a trail of newly painted stones that stops in empty air.

**What is really going on.** **Nothing is explained.** The stones are fresh, painted by Kest in his own hand, in a style the old paths do not use. They lead out beyond the eyries, over a gap, and end at a stone painted on a floating tuft of rime that has already blown away. The quest ends on the trail, with no answer.

**Scene 1: the eyrie.**

**TOLVIK:** "Three weeks. He said he wanted to see the other side of the weather."
**TOLVIK:** "He painted stones. Every wingspan. A line of them, going out."
**TOLVIK:** "I have followed it as far as the air allows. I need someone to follow it further."
> ► **"What is the last stone?"** — **TOLVIK:** "There is not one. That is the problem."
> ► **"Did he leave a note?"** — **TOLVIK:** "He left his flute. And a bowl of seeds for me."
> ► **"I'll follow it."** — **TOLVIK:** "In short sentences. I am too tired for long ones."

**Scene 2: the trail.** Along a ridge, a stone every thirty feet, each painted with a small spiral and a single dot. The player follows them over a saddle, down a gully, across a field of wind-carved ice.

*(Gameplay: a quiet investigation; the player reads the stones for direction and weather clues.)*

**JOURNAL (auto):** *The stones are meant for flyers, not walkers. They are set high on the rock, where a wing-tip would pass.*

**Scene 3: the gap.** At the end of the ridge, the stones stop. In front, a drop of three thousand feet. On the last rock, beside a small dish of seeds, a note in Kest's hand:

**NOTE:** *"Tolvik. I am not lost. I am following the stones that were here before mine. I did not paint them all. —Kest"*

**TOLVIK (when you read it to him):** "...He did not paint them all."
**TOLVIK:** "Then who did?"
> ► **"I don't know."** — **TOLVIK:** "No."
> ► **"He may be safe."** — **TOLVIK:** "He wrote *not lost.* I will take that."
> ► **(Look at the far horizon.)** — Mist; and, faint and very far, a glint that might be a high white wall.

**Scene 4: the seeds.** Tolvik sits at the last rock a long time, then sets his own dish of seeds beside his brother's.

**TOLVIK:** "He will want to know I came."
**TOLVIK:** "I will paint one more stone. Here. In my own hand."
*He paints it: a spiral, a dot, and a short line pointing out into the air.*

**Coda: the second bowl.** Tolvik asks the player to stay for a meal on the last rock. They eat seeds, cold bread and dried apricot, and watch the clouds fill the gap below.

**TOLVIK:** "If he is following stones older than the Heavenfolk, they must go somewhere."
**TOLVIK:** "I shall learn to read them. I shall fly them myself, one day."
> ► **"Take care."** — **TOLVIK:** "I am a poor flyer. But I am a very careful one."
> ► **"I'll help you read them."** — **TOLVIK:** "Then there will be two of us who do not know. That is a start."
*The wind rises. Neither seed-bowl is touched by it.*

**Outcomes and receipt.**
- The trail is documented; the council is told. No answer is given about what Kest followed or why the stones predate his. If the player took Kest's note home, Tolvik keeps it; if the player left it, the wind takes it, and Tolvik forgives you in a day.
- **Receipt:** two bowls of seed on the last rock, one full, one fresh; a new stone beside the old ones.
- **Unexplained seed:** a line of flight-stones older than the Heavenfolk's own, running out toward the south and east. No explanation is offered. Do not tie to the Sky Archipelago without Canon approval.

<!-- quest
id: qst_hvr_stone_air
title: The Stone That Ends in Air
rank: A
type: Investigation
giver: npc_flyer_tolvik_swiftrest
region: reg_heavenreach
level: 136
act: 4
requires_rank: A
reward: 33000 | 1650 | 142000
sets: hvr_stone_air_done
summary: A young flyer vanished on a solo flight, leaving a line of freshly painted stones that ends in empty air.
objectives:
  talk npc_flyer_tolvik_swiftrest
  reach heavenreach_last_painted_stone
  choice unknown_safe_or_horizon
-->

---

## 8. The Letter She Carried

*S · Investigation · the Ledges of Last Flight · giver Keeper Ilvane Greywing*

**The short version.** A generation ago, a king had a Heavenfolk messenger executed for the contents of a letter she carried. She was Ilvane's mother. The letter was never delivered. Ilvane has kept the Ledges for thirty years without asking what it said. A courier's satchel has surfaced in a valley court's archive.

**What is really going on.** The letter was addressed not to the king but to someone **inside his court,** and the king read it, as sovereign, by right. The contents are invented here and are **new lore needing approval:** it was a mother's letter to a son who had gone to serve the king, telling him he was free to leave. The king killed the messenger for being the bearer of his son's choice. The sin of the Heavenfolk is a letter undelivered; Ilvane's task is to deliver it.

**Scene 1: the Ledges.**

**ILVANE:** "My mother was a messenger. She died for a letter."
**ILVANE:** "In thirty years I have not asked what was in it. It was not mine to ask."
**ILVANE:** "A satchel has surfaced in a court archive. It has her seal."
> ► **"What do you want?"** — **ILVANE:** "To carry it. If it can still be carried."
> ► **"Is it safe to open?"** — **ILVANE:** "I will not open it. It is not addressed to me."
> ► **"I'll find it with you."** — **ILVANE:** "In short sentences. We will need them."

**Scene 2: the archive.** In a dusty valley court, a bored archivist produces a leather satchel from beneath a stack of petitions. Inside, among rotted bundles, one letter, the seal unbroken.

**ARCHIVIST:** "The king had it read, of course. This is the copy. The original, they say, was burned."
**ILVANE (when you describe it):** "A copy. Not the letter."
**ILVANE:** "Then the letter is still unburned somewhere. Or it was never burned."
> ► **"Let's find where it was sent."** — A trail through three courts.
> ► **"The copy is enough."** — **ILVANE:** "It is not. A copy is not a delivery."
> ► **"Who was it for?"** — The archivist hesitates.

**Scene 3: the recipient.** The trail ends at a small, damp monastery on the edge of the foothills. In a stone cell, an old man, bald and bent, sits by a window. His name is Corlen. He has spent thirty years waiting.

**CORLEN:** "You are carrying a letter for me."
**CORLEN:** "I felt it. Like a hand on my shoulder."
**CORLEN:** "Is it from my mother?"
*Ilvane, who has never wept in front of anyone, looks away.*
> ► **"Yes."** — **CORLEN:** "Read it to me."
> ► **"Ilvane should read it."** — **ILVANE:** "It is not mine to read."
> ► **"We will read it together."** — **CORLEN:** "Slowly. Please."

**Scene 4: the reading.** In the narrow cell, Ilvane breaks the seal and reads in cant.

**ILVANE (reading):** "*Son. You are free to leave the king's court. Come home. Or go anywhere. I will love you either way. I only wanted you to hear it from someone who loved you. —Mother.*"
**CORLEN:** "...She sent a messenger to say that."
**CORLEN:** "And they killed her for saying it."
**ILVANE:** "She was your mother's messenger. And mine."
*They sit side by side for a long time. The light in the window turns from white to gold.*

**Outcomes and receipt.**
- The letter is delivered, thirty years late. Ilvane lays her mother's courier-cord on the Ledges and sits there alone until dawn. If the player insisted on reading first, Ilvane forgives it, but never speaks of the letter to them again.
- **Receipt:** a second courier-cord on the Ledges, tied beside the first; Corlen's name added to the list of those who received.
- **New lore needing approval:** the content of the letter and the identity of its recipient.

<!-- quest
id: qst_hvr_letter_carried
title: The Letter She Carried
rank: S
type: Investigation
giver: npc_keeper_ilvane_greywing
region: reg_heavenreach
level: 168
act: 5
requires_rank: S
reward: 68000 | 3000 | 315000
sets: hvr_letter_done
summary: A messenger was executed a generation ago for a letter she carried. Her daughter, who keeps the Ledges of Last Flight, wants it delivered at last.
objectives:
  talk npc_keeper_ilvane_greywing
  reach heavenreach_monastery_cell
  choice read_together_or_yes
-->

---

## 9. Above the Weather

*S · Exploration · the high peaks · giver Chart-flyer Peregrin Windrede*

**The short version.** Peregrin has drawn the safe lanes between the eyries for fifty years. Since Aquilon's rise, the rocs have taken new lanes, and the old charts are dangerous. Peregrin needs someone to climb above the eyries, where the air is too thin even for the Heavenfolk, and chart what the rocs are doing.

**What is really going on.** The rocs are flying a pattern: a great, slow ring around the Tribute Peak, widening each season. From the top, the pattern is clear. It is also **not explained.** What the player sees from the summit, besides the ring, is a faint, enormous storm wheeling far to the south, over something white.

**Scene 1: the chart-room.**

**ORSOLO:** "Fifty years of lanes. Every one of them wrong, now."
**ORSOLO:** "The rocs are not wandering. They are *going* somewhere."
**ORSOLO:** "I cannot reach the height to see. You can climb. Nothing flies there but them."
> ► **"What do you need?"** — **ORSOLO:** "A drawing. Of the whole pattern, from above."
> ► **"What will I face?"** — **ORSOLO:** "Cold. Thin air. And rocs, if you are loud."
> ► **"I'll go."** — **ORSOLO:** "Take a lamp. The summit is dark by noon."

**Scene 2: the thin air.** A brutal, silent climb above the last eyrie. The air burns the throat. Colours fade. The sky goes a deep, bruised blue. Overhead, a roc crosses the sun like a slow bronze coin.

*(Gameplay: a stamina and breath-management climb; no combat, but noise attracts rocs.)*

**JOURNAL (auto):** *Above the eyries, the wind has a sound. It is the sound of a very large thing breathing out.*

**Scene 3: the summit.** From a shelf of black rock at the roof of the world, the player looks down. Far below, the rocs wheel in a vast ring around the Tribute Peak, nine concentric loops, each wider than the last.

**ORSOLO (by courier-hawk's note):** "A ring. Of course. A *ring.* He is calling something."
**ORSOLO:** "Or counting."
*Far to the south, past the edge of the range, a storm turns slowly on the horizon, so large that its eye is the size of a country. Beneath it, a single glint of white.*
> ► **(Draw the ring.)** — A careful chart, hand-numbed.
> ► **(Draw the storm.)** — A rough sketch; the storm is hard to place.
> ► **(Draw neither; look.)** — You will remember it better.

**Scene 4: the chart.** Back in the chart-room, Peregrin unrolls the drawing and says nothing for a long minute.

**ORSOLO:** "Nine rings. In nine seasons."
**ORSOLO:** "I will chart the lanes around them. It will take a winter. Every flyer will thank you."
**ORSOLO:** "Not in so many words. We do not say that. We simply fly your lanes."

**Coda: the nine rings.** In the chart-room, after the lanes are drawn, Peregrin makes the player a gift: a small paper kite, its tail inked with the nine rings.

**PEREGRIN:** "It does not fly. It is a reminder. Of what you saw, and that I did not."
**PEREGRIN:** "A chart-flyer is only as good as the person who climbed."
> ► **"I'll keep it in my pack."** — **PEREGRIN:** "Good. If you ever see the ring close, tell me."
> ► **"What happens when it closes?"** — **PEREGRIN:** "I do not know. But I shall have the lanes ready."

**Outcomes and receipt.**
- The new lanes are charted; the flyers use them and fewer are lost. The ring's meaning and the southern storm are **not explained.** If the player drew only the ring, Peregrin never learns of the storm; if only the storm, the lanes stay dangerous a little longer.
- **Receipt:** a chart on the council wall with the player's mark in the corner; a small note, *"Nine rings."*
- **Unexplained seed:** the ring of rocs; the storm in the south. No link is made to the Sky Archipelago or any Canon storm without approval.

<!-- quest
id: qst_hvr_above_weather
title: Above the Weather
rank: S
type: Exploration
giver: npc_chart_flyer_orsolo_windrede
region: reg_heavenreach
level: 172
act: 5
requires_rank: S
reward: 72000 | 3100 | 330000
sets: hvr_above_weather_done
summary: The rocs have taken new lanes, and the old flight charts are dangerous. A chart-flyer needs someone to climb above the eyries and draw what they are doing.
objectives:
  talk npc_chart_flyer_orsolo_windrede
  reach heavenreach_summit_shelf
  choice ring_storm_or_look
-->

---

## 10. The Bronze Feather

*S · Hidden · the foothills · giver Wrangler Rennick Lowperch*

**The short version.** A falcon-wrangler found a bronze-feathered chick on a lower scree slope. It is a roc, and its feathers have the sheen of Aquilon's. If the Heavenfolk learn of it, they will kill it. If Aquilon learns, there will be consequences. Rennick asks the player to help him decide.

**What is really going on.** The chick is not Aquilon's. It is a **stray,** blown from a high nest. It is frightened, hungry and very young. The wrangler's problem is that he likes it. The player's job is to get it somewhere safe without provoking anyone: not the Heavenfolk, not the flock, not Aquilon.

**Scene 1: the hawk-loft.**

**RENNICK:** "I did not mean to keep it. I meant to feed it."
**RENNICK:** "It is bronze at the wingtip. That is a high-peak colour."
**RENNICK:** "If the flyers see it, they will kill it. If its kin see it, they will burn my loft."
> ► **"Is it hurt?"** — **RENNICK:** "Hungry. Mostly."
> ► **"Whose chick is it?"** — **RENNICK:** "I do not know. I do not want to."
> ► **"Show me."** — **RENNICK:** "Keep your voice low."

**Scene 2: the chick.** In the rafters of the loft, a lump of tawny down with a hooked beak and enormous, furious eyes. It watches the player, hisses once, then lays its head on its wing.

**RENNICK:** "It has been sleeping since the third day. I think it has given up on being scared."
> ► **(Offer it meat.)** — It eats, with dignity.
> ► **(Sit quietly beside it.)** — It shuffles closer.
> ► **(Leave it be.)** — It watches you go.

**Scene 3: the walk.** Rennick and the player carry the chick, wrapped in a yak-blanket, up a steep goat-track toward the high scree. A shadow passes overhead, long and dark. They freeze. The shadow passes on. Somewhere above, a roc cries once, a long, bronze note.

**CHICK (in the blanket, a small, answering cheep).**
**RENNICK:** "Don't."
**RENNICK:** "Don't *answer.*"
> ► **(Cover the chick's beak.)** — It struggles, then stills.
> ► **(Let it call.)** — The roc above turns.
> ► **(Leave the chick on the scree and withdraw.)** — A cold, sensible choice.

**Scene 4: the nest.** At a shelf below the Tribute Peak, a single huge roc lands, folds her wings, and looks at the player. She does not strike. She picks up the chick in her beak, as gently as a cat, and flies up and out of sight. A single bronze feather, as long as an arm, falls onto the scree.

**RENNICK (whispering):** "She let us go."
**RENNICK:** "I think she was *thanking* us."
*Far above, high on the Tribute Peak, a shadow too large to be a roc turns slowly in the sky, and does not descend.*

**Coda: the loft.** That evening Rennick sits on the loft floor beside an empty perch, turning the bronze feather over in his fingers.

**RENNICK:** "I did not know I would miss it."
**RENNICK:** "It hated me for three days. Then it stopped."
**RENNICK:** "I kept thinking: if it had been a falcon, I would have known what to do."
> ► **"You did know."** — **RENNICK:** "...I suppose I did."
> ► **"She'll remember you."** — **RENNICK:** "Rocs do not remember. But I shall."
*From the high peaks, once, a long bronze cry drifts down the valley. Rennick lifts his head, and listens, and says nothing at all.*

**Outcomes and receipt.**
- The chick is returned. Aquilon does not act; the player is simply, for a moment, noticed. If the player let the chick call, the mother roc arrives sooner, but the flock behind her stays at a distance.
- **Receipt:** a bronze feather in the player's pack; Rennick's loft, which the Heavenfolk do not burn.
- **Unexplained seed:** whether Aquilon saw. Nothing happens, and nothing is said.

<!-- quest
id: qst_hvr_bronze_feather
title: The Bronze Feather
rank: S
type: Hidden
giver: npc_wrangler_rennick_lowperch
region: reg_heavenreach
level: 178
act: 5
requires_rank: S
reward: 76000 | 3300 | 345000
sets: hvr_bronze_feather_done
summary: A falcon-wrangler has hidden a bronze-feathered roc chick in his loft. If anyone finds it, someone will die.
objectives:
  talk npc_wrangler_rennick_lowperch
  reach heavenreach_scree_nest_shelf
  choice cover_call_or_leave
-->
