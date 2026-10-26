# 11e-37 — True-Name Isles, the Naming Islands: Ten Side Quests (draft)

> *"A true name is shared with those you love most. Everyone else gets the one you use at market."*
> — Gazetteer, True-Name Isles

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 4 and 10 plant unexplained seeds.

**Region:** `reg_true_name_isles` (the Naming Voyage harbour, the Naming Rocks, the Hall of Names, the Silent Reef). **Rank band:** B–A. **Tone:** calm, private, careful with words; grief that is quiet rather than loud.

**Placement notes.**
- **The Nameless Tide** is the region's Tyrant. It takes the true names of children on their Naming Voyages and tries each on; none fit. No quest here names, kills or banishes it, and none says what it is.
- Customs the quests rely on: every islander has a **common name** and a **true name**; the true name is given by the sea on the Naming Voyage and shared only with those a person loves most; whoever knows it can *call* that person across any distance; a child who returns without a name is **unfinished** and may try again next year; a **council of namers** governs and keeps the **Hall of Names.** The council has suspended the voyages.
- **Open questions left open.** What the Nameless Tide is, where taken names go, whether a taken name can be returned, and what the Tide would do with a name it was given. Quests 2, 4 and 10 are labelled seeds.
- **Rank note.** Quests 1, 3, 5, 6 and 7 are rank B (levels 86-119); 2, 4, 8, 9 and 10 are rank A (levels 120+). Rewards follow the neighbouring B and A files.
- **Canon-safe lore.** The "generation ago" child with the unpronounceable name is named in quest 5. That is new detail for Canon approval.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Girl Who Came Home Empty | B | Investigation | Selke Brinehand | A mother and a name that will not return |
| 2 | A Name on Loan | A | Faction | Namer Orsolo Tidewrit | A council's careful, doomed theory |
| 3 | Listening Reef | B | Escort | Grandmother Pehu Saltwick | An old woman and a very quiet shore |
| 4 | The Navigator's Chart | A | Exploration | Navigator Maru Longwake | A place that keeps what it takes |
| 5 | Said Once | B | Hidden | Navigator-Emeritus Lio Marenpath | A name no one can say |
| 6 | The Blank Ledger | B | Investigation | Clerk Wim Inkwater | Ink that fades |
| 7 | Parents From Far Away | B | OddJob | Ilsabet Fenrow | A foreign couple and a custom they do not understand |
| 8 | A Boat Nobody May Sail | A | OddJob | Boatwright Dovrik Plankmaker | A small boat for a year that may not come |
| 9 | The Lantern Vigil | A | Defense | Vigilkeeper Odu Lanternwright | Families on the night the voyages would sail |
| 10 | The Pillar That Does Not Answer | A | Exploration | Pillar-Tender Ennis Hollowtide | Silence in the shape of a name |

## Cast

<!-- npc
id: npc_selke_brinehand
name: Selke Brinehand
tier: major
race: Human
region: reg_true_name_isles
settlement: Naming Voyage harbor
role: Mother of a child who returned empty
backstory: A salt-roughened net-mender of thirty-five whose daughter Arro came back from her Naming Voyage able to walk, eat and smile, and unable to say who she is.
-->
<!-- npc
id: npc_orsolo_tidewrit
name: Namer Orsolo Tidewrit
tier: major
race: Human
region: reg_true_name_isles
settlement: The Hall of Names
role: Senior namer of the council
backstory: A tall, gentle, careful namer of sixty who has proposed that the council offer the Nameless Tide a name, and who has not slept properly since.
-->
<!-- npc
id: npc_pehu_saltwick
name: Grandmother Pehu Saltwick
tier: townsfolk
race: Human
region: reg_true_name_isles
settlement: Naming Voyage harbor
role: Old woman who wants to listen at the Silent Reef
backstory: A frail, funny woman of ninety who has lost her mind to age by degrees and wants to sit at the Silent Reef once before she forgets what a name is.
-->
<!-- npc
id: npc_maru_longwake
name: Navigator Maru Longwake
tier: major
race: Human
region: reg_true_name_isles
settlement: Naming Voyage harbor
role: Navigator who claims to have found where names are kept
backstory: A wiry, sun-dark navigator who sailed a straight line for nine days and arrived back at the harbour with a chart she cannot explain.
-->
<!-- npc
id: npc_lio_marenpath
name: Navigator-Emeritus Lio Marenpath
tier: major
race: Human
region: reg_true_name_isles
settlement: Naming Voyage harbor
role: Greatest navigator of her age
backstory: A very old, very sharp woman who returned from her Naming Voyage a generation ago with a name nobody could pronounce, and has never once heard it said.
-->
<!-- npc
id: npc_wim_inkwater
name: Clerk Wim Inkwater
tier: townsfolk
race: Human
region: reg_true_name_isles
settlement: The Hall of Names
role: Clerk of the Hall of Names
backstory: A fussy, anxious young clerk who has noticed that some entries in the great ledger are growing paler, and that all of them belong to children from the last year.
-->
<!-- npc
id: npc_ilsabet_fenrow
name: Ilsabet Fenrow
tier: townsfolk
race: Human
region: reg_true_name_isles
settlement: Naming Voyage harbor
role: Foreign mother waiting for a Naming Voyage
backstory: A merchant's wife from the mainland who sailed out with her husband and nine-year-old son to have the boy named, and who does not understand why no one will tell her what the name is for.
-->
<!-- npc
id: npc_dovrik_plankmaker
name: Boatwright Dovrik Plankmaker
tier: townsfolk
race: Human
region: reg_true_name_isles
settlement: Naming Voyage harbor
role: Boatwright of the Naming boats
backstory: A silent, barrel-chested boatwright who has built a small boat each spring for forty years for a child's Naming Voyage, and is building one this year too.
-->
<!-- npc
id: npc_odu_lanternwright
name: Vigilkeeper Odu Lanternwright
tier: major
race: Human
region: reg_true_name_isles
settlement: Naming Voyage harbor
role: Keeper of the vigil lanterns
backstory: A quiet, steady man of fifty who lights the harbour lanterns each year on the night the voyages sail, and who has decided that the empty children's families should light them anyway.
-->
<!-- npc
id: npc_ennis_hollowtide
name: Pillar-Tender Ennis Hollowtide
tier: major
race: Human
region: reg_true_name_isles
settlement: The Naming Rocks
role: Tender of the Naming Rocks
backstory: A lean, windburnt tender who has swept the salt from the stone pillars every dawn for twenty years and has noticed that one of them has stopped sounding.
-->

---

## 1. The Girl Who Came Home Empty

*B · Investigation · the harbour · giver Selke Brinehand*

**The short version.** Selke's daughter Arro sailed out on her Naming Voyage and came home a month ago. She eats, sleeps and smiles, and does not know who she is. Selke wants her name back.

**What is really going on.** The Nameless Tide took Arro's *true name* and the sense of self that went with it. It did not take her common name, or her memories, or her habits; she just feels like a stranger inside them. The player cannot restore the true name. What the player can do is help Selke give her daughter a *place to stand.*

**Scene 1: the harbour.**

**SELKE:** "She was gone nine days. She sailed out at dawn with a lantern and came back at dusk with nothing."
**SELKE:** "She says 'mother' as if it were a new word. She says 'Arro' the same way."
**SELKE:** "The council says: *wait a year.* A year! I'll be old."
> ► **"What happened out there?"** — **SELKE:** "She doesn't know. She keeps saying it was *kind.*"
> ► **"What can I do?"** — **SELKE:** "Ask her something I can't."
> ► **"Take me to her."** — **SELKE:** "Be gentle. She breaks nothing, and everything is breakable."

**Scene 2: Arro.** Arro sits on the harbour wall, drawing in the sand with a stick. She is ten, polite, pleasant and a little distant, as though attending a play about her own life.

**ARRO:** "Mother says I used to be loud. I'd like to be loud. I don't know how to start."
**ARRO:** "When I try to remember, it's like picking up a cup that isn't there."
> ► **"What do you like?"** — **ARRO:** "Boats. I like the *shape* of boats. I don't know why."
> ► **"What was the best part of the voyage?"** — **ARRO:** "The quiet. Before the... before."
> ► **"You don't have to be anyone yet."** — **ARRO:** "...Oh. That's *nice.*"

**Scene 3: the beginning.** Over three days, the player and Selke walk with Arro round the harbour, naming things aloud: boats, rope, gulls. Arro begins to choose. She likes the green boat. She does not like pickled herring. She wants a nickname.

**SELKE:** "Her father used to call her *Fish.*"
**ARRO:** "Fish. That's... a good start. I'd like it."
> ► **(Call her Fish.)** — Arro grins, shy.
> ► **(Let her choose her own.)** — **ARRO:** "I'll think. Is that allowed?"
> ► **(Remind her of her true name's shape.)** — **ARRO:** "No. Please. It's a hole."

**Scene 4: the shore.** On the last evening, Arro sits on the harbour wall and says a word to the water, and the water, for the first time in a month, laps higher against the stones.

**ARRO:** "It's not mine. It's just a word. But I said it."

**Scene 2b: the pencil.** On the second day Arro asks if she may draw on the player's hand. She chooses a charcoal stub and begins, with enormous concentration, to draw a boat.

**ARRO:** "It's a green one. The one by the pier."
**SELKE:** "She's drawn that boat forty times. She doesn't know why."
**ARRO:** "It has a crooked mast. I like that it's crooked."
*She finishes, looks at the drawing, and adds a very small person at the tiller. She frowns at it, rubs it out with her thumb, and draws it again, a little differently.*
> ► **"Who is it?"** — **ARRO:** "I don't know yet."
> ► **"It looks like you."** — **ARRO:** "Does it? ...Maybe."

**Outcomes and receipt.**
- Arro begins a new self, built from small choices. If the player pushed her toward the old name, she withdraws for a week.
- **Not answered:** whether the true name can be returned, or where it is. The quest only shows a child learning to live without one.
- **Receipt:** a green toy boat on the family doorstep; Arro, called *Fish,* signs her name with a small fish in the corner.

<!-- quest
id: qst_tni_girl_came_home_empty
title: The Girl Who Came Home Empty
rank: B
type: Investigation
giver: npc_selke_brinehand
region: reg_true_name_isles
level: 90
act: 4
requires_rank: B
reward: 10400 | 610 | 45000
sets: tni_empty_girl_done
summary: A girl returned from her Naming Voyage unable to say who she is. Her mother wants the name back, and the council says wait.
objectives:
  talk npc_selke_brinehand
  reach tni_harbour_wall_arro
  choice fish_own_or_old
-->

---

## 2. A Name on Loan

*A · Faction · the Hall of Names · giver Namer Orsolo Tidewrit*

**The short version.** The council believes that the Nameless Tide wants a name because it has none. Orsolo proposes to offer it one on loan, a name that is not anyone's true name, as a test. The council is divided.

**What is really going on.** Nobody knows whether giving the Tide a name would satisfy it, enrage it, or hand it the power to *call* every islander it has already met. The quest is not about doing the naming. It is about the council deciding whether to *try,* and the player's job is to help write the question.

**Scene 1: the hall.**

**ORSOLO:** "A name is a hand held out. We have never offered it to something that bites."
**ORSOLO:** "My colleagues say: *do not feed it.* I say: *it is hungry.*"
**ORSOLO:** "I want an outsider's opinion. Someone who does not have a true name to lose."
> ► **"Do I have a name to lose?"** — **ORSOLO:** "You have a common one. That is safe."
> ► **"What is the risk?"** — **ORSOLO:** "It learns the *shape* of naming."
> ► **"I'll sit in."** — **ORSOLO:** "Thank you. Say what you honestly think."

**Scene 2: the council.** A long, quiet session. Six namers sit round a table of driftwood. Their arguments are polite, which makes them worse.

**NAMER HELE:** "If it takes a loaned name, it will have *practised.*"
**NAMER BREN:** "If it does not, it will take *more.* Our children."
**ORSOLO:** "Then the test is small. A single name. A word that means *nothing.*"
> ► **"Offer nothing."** — **BREN:** "That is what we have been doing."
> ► **"Offer a question."** — **HELE:** "A name that is a *question.* ...Interesting."
> ► **"Offer a gift, not a name."** — **ORSOLO:** "A gift is not a name. But it is not *not* a name."

**Scene 3: the offering.** At dusk, by the harbour, the council lowers a small bundle of woven reeds into the water. Inside it, written on a strip of bark, is the loaned name. The sea takes it. The harbour is silent. Nothing happens for a long time.

*Then, from far out, a single long note, like a held breath, as though something has read the strip and is deciding.*
> ► **(Wait.)** — The note ends. The sea settles.
> ► **(Ask the sea a question.)** — **ORSOLO:** "No. Please. We have spoken enough."
> ► **(Withdraw the council.)** — The harbour empties quietly.

**Scene 4: the morning.** The bundle is gone. No child's name has been taken. No answer has come. The council sits at the table with their hands folded.

**ORSOLO:** "We do not know whether it was accepted."
**ORSOLO:** "We do not know whether it will be tried on."
**ORSOLO:** "But it has been *asked.* That is something."

**Scene 2b: the quiet namer.** After the session the youngest namer, a woman called Veda, catches the player on the stair, speaking very low.

**VEDA:** "Orsolo means well. But he has forgotten what the Tide did to my brother's boy."
**VEDA:** "A name on loan is still a name. If it keeps it, it keeps it."
**VEDA:** "I voted yes. I want you to know that I am terrified of it."
*She looks at her hands, which are shaking a little, and folds them in her sleeves.*
> ► **"Why did you vote yes?"** — **VEDA:** "Because we have no other idea."
> ► **"I'll tell Orsolo you're worried."** — **VEDA:** "He knows. He's worried too."

**Outcomes and receipt.**
- The council resolves to wait a month, and watch. If the player asked the sea a question, the council is shaken and does not repeat the offering.
- **Seed (unexplained):** the loaned name, the long note, and whether the Nameless Tide read it. The quest does not say whether naming the Tide is wise, possible or what it would do.
- **Receipt:** a reed bundle drawn on the Hall wall; a chalk line in the ledger, *"a name on loan: pending."*

<!-- quest
id: qst_tni_name_on_loan
title: A Name on Loan
rank: A
type: Faction
giver: npc_orsolo_tidewrit
region: reg_true_name_isles
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: tni_name_loan_done
summary: The council wants to offer the Nameless Tide a name on loan, as a test. It is divided, and wants an outsider's view.
objectives:
  talk npc_orsolo_tidewrit
  reach tni_hall_of_names_table
  choice offer_nothing_question_or_gift
-->

---

## 3. Listening Reef

*B · Escort · the Silent Reef · giver Grandmother Pehu Saltwick*

**The short version.** Pehu is ninety and forgetting. She has lived her whole life at the harbour and wants to sit at the Silent Reef, where nameless children are said to wander, and listen. She wants someone to carry her there.

**What is really going on.** Pehu does not expect to hear anything. She wants to hear *nothing,* once, at the place where nothing lives, because the older she gets the more she suspects that is what she is going to turn into. Escorting her is mostly a matter of carrying a woman and keeping her company.

**Scene 1: the porch.**

**PEHU:** "I am ninety, dear. I have forgotten four husbands."
**PEHU:** "I may have only had two. It's the same grief."
**PEHU:** "There is a place at the edge of the reef where nobody talks. I should like to sit in it."
> ► **"Why there?"** — **PEHU:** "I want to know what silence sounds like before I join it."
> ► **"Can you walk?"** — **PEHU:** "Not at all. I can *complain,* though."
> ► **"I'll carry you."** — **PEHU:** "Wonderful. I weigh nothing. It's a family gift."

**Scene 2: the crossing.** The player carries Pehu, wrapped in a quilt, across a causeway of white sand and low rock, with a lantern and a thermos of tea. She is a magnificent talker. She tells stories that overlap, wander and double back.

**PEHU:** "...and then my second husband, or the first, put a fish in the teapot..."
**PEHU:** "What was I saying? It doesn't matter. The fish was *delightful.*"
*The causeway narrows. The sea falls quiet on either side.*

**Scene 3: the reef.** At the edge of the Silent Reef, the sea is so still it looks like glass. The coral below is bleached and bone-white. There are no fish. There is no wind. There is only a faint, curious pressure in the ears.

**PEHU:** (whispering) "Oh. It's rather lovely."
> ► **(Set her down on the sand.)** — She sits, quiet for the first time.
> ► **(Stay standing, holding the lantern.)** — Steady, patient.
> ► **(Sit beside her.)** — **PEHU:** "Come, dear. It's catching."

*For a long time, nothing. Then Pehu, very softly, begins to hum, and the hum has no tune and no name, only the sound of someone remembering how to breathe.*

**Scene 4: the return.** On the way back, Pehu is asleep in the quilt. At the harbour, she opens her eyes.

**PEHU:** "...Did we go somewhere?"
**PEHU:** "Oh, I *hope* so."

**Scene 2b: the tea.** On the causeway, Pehu insists they stop and drink from the thermos, and falls into a story about her wedding, which she remembers perfectly, and which did not, as far as anyone can tell, happen.

**PEHU:** "It was on a boat. The groom was a seal. Lovely man, terrible conversationalist."
**PEHU:** "We danced on the foredeck. All the gulls came."
*She laughs, and the laugh turns into a cough, and the player holds the cup for her while she recovers.*
**PEHU:** "Don't tell my daughter. She thinks I make it up."
> ► **"Perhaps you did."** — **PEHU:** "Perhaps. It was still a lovely wedding."
> ► **"It sounds wonderful."** — **PEHU:** "Oh, it was. I do wish you'd come."

**Scene 4b: the tea at home.** At the cottage, Pehu's daughter Maile has the kettle on and is not quite angry.

**MAILE:** "You took my mother to the *Silent Reef.* Across a causeway. In the *dark.*"
**PEHU (from the quilt):** "Don't shout at them, dear. I had a lovely time."
**MAILE:** (after a long breath) "...Did she say anything?"
*The player tells her about the humming. Maile sits down, rubs her eyes and, to her own surprise, laughs.*

**Outcomes and receipt.**
- Pehu has her silence. If the player sat with her, she remembers the reef for a week and tells everyone about it. If not, she forgets it by morning and is happy anyway.
- No nameless children are seen. The reef is as the gazetteer says, and that is all.
- **Receipt:** a pressed piece of white coral on Pehu's windowsill; the harbour children call her *"Grandmother Quiet."*

<!-- quest
id: qst_tni_listening_reef
title: Listening Reef
rank: B
type: Escort
giver: npc_pehu_saltwick
region: reg_true_name_isles
level: 88
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: tni_reef_done
summary: A ninety-year-old woman who is forgetting everything wants to be carried to the Silent Reef to listen to nothing, once.
objectives:
  talk npc_pehu_saltwick
  escort npc_pehu_saltwick
  reach tni_silent_reef_edge
  choice set_stand_or_sit
-->

---

## 4. The Navigator's Chart

*A · Exploration · open sea · giver Navigator Maru Longwake*

**The short version.** Maru sailed a dead-straight course for nine days, and found a place where the water is perfectly still. She says it is where the sea keeps the names it has taken. She wants someone to check.

**What is really going on.** *Nothing is explained.* The still water is a circle some forty paces across, where no wind blows and no wave rises. When the player listens, they hear many voices, saying names so faintly that none can be understood. The quest ends on a question.

**Scene 1: the chart.**

**MARU:** "Nine days, due east. I didn't tack once. The compass went round like a spun coin and the sea *pulled.*"
**MARU:** "Then, flat water. A circle. And a noise like a room full of people trying not to be heard."
**MARU:** "I turned back. I'm not proud. I am only alive."
> ► **"Where is it?"** — **MARU:** "On the chart. And I'll sail you, but I won't go in."
> ► **"What did you hear?"** — **MARU:** "Names. Hundreds. Just the *edges* of them."
> ► **"I'll go in."** — **MARU:** "Tie a rope to yourself. And do not answer."

**Scene 2: the voyage.** A quiet nine-day crossing with Maru at the tiller. She teaches the player the old star-songs for steering. On the sixth night a whale passes beneath the boat, huge and silent, and does not breach.

**MARU:** "The whales avoid it. So do the birds. You'll see."
*On the ninth morning the sea goes glass-flat. The wind dies. The sail hangs.*

**Scene 3: the circle.** The boat drifts to the edge of the still water. The surface is a perfect mirror. In it, the sky and the boat, and nothing else. And from beneath, a murmur like a crowd on the other side of a wall.

**VOICES (overlapping, faint):** *"...Isa... Tomren... Rue... Calla... Dov..."*
**MARU (whispering):** "Don't answer."
> ► **(Listen.)** — The names layer and blur; one sounds familiar.
> ► **(Throw a coin into the circle.)** — It sinks without a ripple.
> ► **(Say, "I'm listening.")** — The murmur stops. It starts again, closer.

**Scene 4: the leaving.** The player and Maru row out of the circle. The wind returns. Neither speaks for an hour.

**MARU:** "Were they all children?"
**MARU:** "I could not tell. I couldn't tell if they wanted to be *found.*"

**Scene 2b: the night watch.** On the sixth night Maru insists on taking the first watch alone. The player, half-asleep, hears her singing under her breath, a sailor's song with a refrain about the stars being the only honest map.

**MARU:** "My mother taught me that. She said all other charts lie by omission."
**MARU:** "I used to think she meant the sea. Now I think she meant everything."
*She falls quiet. A long while later she adds, almost to herself: "I wonder if the names are afraid of the dark."*
> ► **"Names can't be afraid."** — **MARU:** "No. But the children they came from could."
> ► **"I'll take the watch."** — **MARU:** "Wake me if the wind goes."

**Scene 4b: the report.** Back at the harbour the player and Maru stand before the council and describe the circle. It is the most uncomfortable hour either has ever spent.

**NAMER HELE:** "You are sure of the voices?"
**MARU:** "I am sure of nothing except that I would rather not hear them again."
**NAMER BREN:** "We should send a boat."
**MARU:** "Then send one with a very long rope, and a very short crew."
*The council agrees to nothing, which, for the council, is a decision.*

**Outcomes and receipt.**
- The chart is confirmed; the council is told. If the player spoke to the circle, the murmur follows the boat for a day, and a name the player has never heard is whispered once at the rail.
- **Seed (unexplained):** the still water, the voices, and whether the names are held, lost or called. The quest does not say whether this is where the Nameless Tide keeps the names, or whether any name could be retrieved.
- **Receipt:** a chart marked with a circle and a question mark; Maru will not sail that way again.

<!-- quest
id: qst_tni_navigators_chart
title: The Navigator's Chart
rank: A
type: Exploration
giver: npc_maru_longwake
region: reg_true_name_isles
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: tni_chart_done
summary: A navigator claims a circle of still water far east where the sea keeps the names it has taken. She won't go in alone.
objectives:
  talk npc_maru_longwake
  reach tni_still_water_circle
  choice listen_coin_or_speak
-->

---

## 5. Said Once

*B · Hidden · the harbour · giver Navigator-Emeritus Lio Marenpath*

**The short version.** Lio returned from her Naming Voyage a generation ago with a name no one could pronounce. She became the greatest navigator of her age. She has never once heard it said aloud. She is eighty-one and wants to.

**What is really going on.** The name is real, and it can be said, but not by one tongue. It needs a chord: three voices at once, in three registers. Lio never found three people willing to try. The player is asked to find them.

**Scene 1: the porch.**

**LIO:** "I have had a name for sixty-four years that I cannot say. It sits in me like a stone in a shoe."
**LIO:** "The sea gave it to me. The sea knows how to say it. I do not."
**LIO:** "I would like to hear it once, before I'm old."
> ► **"You're eighty-one."** — **LIO:** "Quite. I'm already old. I would like to hear it before I'm *dead.*"
> ► **"Why not ask the namers?"** — **LIO:** "They tried. They coughed."
> ► **"I'll find voices."** — **LIO:** "Three. Low, mid, high."

**Scene 2: the choir.** The player collects three voices: a deep-voiced fishmonger, Teka, who sings in the harbour choir; a cheerful boy of fourteen who whistles; and a council clerk with a flute-clear soprano. Lio hums the sounds she remembers: clicks, a long vowel, a sound like a wave retreating.

**RHEA:** "That's not a name. That's a *weather report.*"
**LIO:** "Quite. Try."
*They try, over three days. They fail. They laugh. On the fourth day the three voices find one another, almost.*
> ► **"Slower."** — The chord loosens, steadies.
> ► **"Breathe together first."** — They do.
> ► **"Let Lio conduct."** — She raises both hands.

**Scene 3: the saying.** On the harbour wall at dusk, the three voices stand in a row. Lio sits in the middle of the quay, eyes closed. The first voice begins, low. The second joins. The third rises over both, and the name *comes together,* three sounds that make a fourth, and the water in the harbour shivers once, as though recognising it.

*Lio opens her eyes. She says nothing for a long time.*
**LIO:** "...Oh. It's *me.*"

**Scene 4: the after.** The three singers leave. Lio sits on the wall, listening to the water, which is humming her name very softly back.

**LIO:** "Sixty-four years. And it's only a song."
**LIO:** "How very *nice.*"

**Scene 2b: the old chart.** While the singers rehearse, Lio shows the player a chart she made at sixteen, yellowed, mended, covered in a young girl's confident handwriting.

**LIO:** "Everything I knew then was wrong. The currents, the stars, the winds. I got it all wrong and I made it up bravely."
**LIO:** "That is how one becomes a navigator. Not by being right. By being *specific.*"
*She traces a small island with one finger, a smudge in the corner of the page with a single word beside it.*
**LIO:** "That's my name. In my own handwriting. I wrote it down without ever being able to say it."
> ► **"What does it say?"** — **LIO:** "Home."
> ► **"It looks lovely."** — **LIO:** "It looks young."

**Outcomes and receipt.**
- The name is said once, in chord. If the player asked Lio to conduct, she holds the final note a long time; if not, the singers fade out gently.
- **New lore for Canon approval:** Lio Marenpath is named as the "generation ago" navigator from the gazetteer, and her name as a three-voice chord. Whether the Tide can hear or use such a name is not addressed.
- **Receipt:** a three-note hum the harbour children now use to call Lio in for supper; she answers, every time.

<!-- quest
id: qst_tni_said_once
title: Said Once
rank: B
type: Hidden
giver: npc_lio_marenpath
region: reg_true_name_isles
level: 92
act: 4
requires_rank: B
reward: 10800 | 625 | 46000
sets: tni_said_once_done
summary: The greatest navigator of her age has a true name no one can pronounce. It needs a three-voice chord, and she wants to hear it once.
objectives:
  talk npc_lio_marenpath
  reach tni_harbour_wall_chord
  choice slower_breathe_or_conduct
-->

---

## 6. The Blank Ledger

*B · Investigation · the Hall of Names · giver Clerk Wim Inkwater*

**The short version.** The Hall of Names keeps a record of every name the sea has given. Wim has noticed that some of the entries are fading, and all of them belong to children of the last year. He needs help finding out why.

**What is really going on.** The ink fades because the names are being taken, one by one, as the Tide tries them on. The ledger is a kind of mirror. When a name leaves, its line grows pale. The player's job is to decide what to do with the information: copy the names, memorise them, or let them go.

**Scene 1: the stacks.**

**WIM:** "Two hundred and eleven years of names. Never a smudge. Never a blot."
**WIM:** "And now these. Look."
*He opens the ledger. Eleven lines are pale as breath on glass.*
**WIM:** "Every one is a child from the last year. And every day, the ink gets a little thinner."
> ► **"Can you copy them?"** — **WIM:** "Copying a true name outside the Hall is... forbidden."
> ► **"Is it spreading?"** — **WIM:** "One line a week."
> ► **"Show me the oldest fade."** — **WIM:** "Here. Arro, daughter of Selke."

**Scene 2: the night.** The player and Wim stay in the Hall after closing. Candles. The great ledger on its stand. The room is cold, and very quiet.

*A line goes pale as they watch, letter by letter. The ink does not fade. It is *withdrawn,* as if drawn back through the page.*
**WIM:** (whispering) "It's not dying. It's being *held.*"
> ► **"Hold it back."** — **WIM:** "How? With what?"
> ► **"Write it again."** — **WIM:** "It would be a lie. Names are not ours to write."
> ► **"Say it aloud."** — **WIM:** "Only the family may."

**Scene 3: the families.** The next morning, Wim and the player visit each of the eleven families. Some will not open the door. Some weep. One father, a stonemason, takes down the child's name-stone from the lintel and presses it into Wim's hands.

**FATHER:** "If it must be somewhere, let it be somewhere we can *touch.*"
> ► **(Copy the names onto stone.)** — A slow, careful, private work.
> ► **(Teach the families to memorise them.)** — They gather in a circle and learn.
> ► **(Leave the ledger as it is.)** — Wim nods, grimly.

**Scene 4: the Hall.** Whichever the player chose, the ledger continues to fade. But the pale lines are not empty: each has a small, faint mark beside it, a dot of ink Wim did not make.

**WIM:** "I didn't do that."
**WIM:** "I think someone is... *keeping count.*"

**Scene 2b: the ledger-lamp.** Late on the second night Wim lights a lamp he calls his "reading candle," a thin old taper whose flame burns steady and blue. It is the only light the ledger tolerates.

**WIM:** "Eleven names. I counted them again. I count them every hour."
**WIM:** "Is it terrible to say that I am afraid of the ledger?"
**WIM:** "I was happy here. I thought I was safe among the records."
*The flame bends toward the page, as though listening. The player puts a hand over it, and the flame steadies.*
> ► **"It's not the ledger's fault."** — **WIM:** "I know. I know."
> ► **"You're doing the right thing."** — **WIM:** "I am doing the only thing."

**Outcomes and receipt.**
- The eleven names are held by their families, not the Hall. If the player chose to leave the ledger, the next eleven fade in a month.
- **Not answered:** who or what puts the dots. The quest does not say whether the Tide, a ledger-spirit or the sea itself did it.
- **Receipt:** eleven small name-stones on a shelf in the Hall, each in a different hand; Wim keeps a tally in the margin.

<!-- quest
id: qst_tni_blank_ledger
title: The Blank Ledger
rank: B
type: Investigation
giver: npc_wim_inkwater
region: reg_true_name_isles
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: tni_ledger_done
summary: The Hall of Names keeps every true name. Eleven entries from the last year are slowly fading, line by line.
objectives:
  talk npc_wim_inkwater
  reach tni_hall_of_names_ledger
  choice stone_memorise_or_leave
-->

---

## 7. Parents From Far Away

*B · OddJob · the harbour · giver Ilsabet Fenrow*

**The short version.** Ilsabet and her husband came a month by ship to have their nine-year-old son named. The voyages are suspended. She does not understand why the council will not even tell her the *name* when the voyage is done.

**What is really going on.** For the islanders a true name is a private thing, shared only with those one loves most. For Ilsabet it is a birth certificate. Once the voyages resume, the sea will give her son a name and the council will keep it from her, unless her son chooses to share it. She is afraid of that. The player's job is to translate between two kinds of love.

**Scene 1: the guesthouse.**

**ILSABET:** "We've paid. We've waited. We've been very polite."
**ILSABET:** "And now they tell me: when he's named, *I won't be told.*"
**ILSABET:** "I am his mother."
> ► **"It's their custom."** — **ILSABET:** "It's *my son.*"
> ► **"What do you want?"** — **ILSABET:** "To be trusted with him."
> ► **"I'll talk to the namers."** — **ILSABET:** "Please. I've nothing left to say that isn't rude."

**Scene 2: the namer.** Namer Hele receives them with tea and an air of patient sorrow.

**HELE:** "A true name is what a person is, underneath. A parent can know a child. A parent cannot own one."
**HELE:** "Your son may tell you. Perhaps he will. But *he* must choose."
**ILSABET:** "He's nine!"
**HELE:** "Yes. That is the age we begin to ask."
> ► **"Explain it as a gift."** — **HELE:** "That is nearly right."
> ► **"Explain it as trust."** — **ILSABET:** "I'd like to understand that."
> ► **"Tell her what her son is risking."** — **HELE:** "...A moment."

**Scene 3: the boy.** The player finds Ilsabet's son, Tomas, on the quay, watching the Naming boats. He is serious, curious and a little frightened.

**TOMAS:** "Mum says I'm going to be given a secret."
**TOMAS:** "Will I tell her?"
**TOMAS:** "I think I'd tell her. But I want to be *asked.* Not told."
> ► **(Tell Tomas what Ilsabet fears.)** — He frowns, considering.
> ► **(Tell Tomas he can choose.)** — **TOMAS:** "That's what I thought."
> ► **(Say nothing.)** — He turns back to the boats.

**Scene 4: the conversation.** That evening Ilsabet sits on the quay with Tomas. She does not ask for the name. She asks, instead, whether he will let her ask, someday.

**TOMAS:** "...Yes."
**ILSABET:** "That's all I wanted."

**Scene 2b: the husband.** Ilsabet's husband, Dorran, proves harder than she is. He has spent a week at the harbour, arms folded, watching the boats, saying nothing.

**DORRAN:** "I don't hold with secrets. Not between a father and a son."
**DORRAN:** "On the mainland a name is written down. In a book. You can look it up."
**DORRAN:** "Here it's nowhere. It's in him. And he has not said it."
*He looks, for a moment, very young and very out of his depth, a merchant's man in a place that cannot be bought.*
> ► **"A name that cannot be looked up is a kind of trust."** — He frowns, turning it over.
> ► **"You'll be told, if he wants you to."** — **DORRAN:** "And if he doesn't?"

**Scene 4b: the greeting.** The next morning Ilsabet, walking the quay, calls out to a passing fisher with the harbour's morning greeting, mangling the vowels in a way that makes three people stop and smile.

**FISHER:** "That's very nearly it."
**ILSABET:** "Very *nearly?*"
**FISHER:** "No one gets it right the first time. We think it's better that way."
*She practises it all the way back to the guesthouse, under her breath, like a spell.*

**Outcomes and receipt.**
- Ilsabet and Tomas reach an understanding. The family waits for the voyages to resume. If the player told Tomas what his mother feared, he is anxious and quieter.
- **Receipt:** a small wooden token on Tomas's bag, carved with a question mark; Ilsabet learns the harbour's common-name greetings.

<!-- quest
id: qst_tni_parents_far_away
title: Parents From Far Away
rank: B
type: OddJob
giver: npc_ilsabet_fenrow
region: reg_true_name_isles
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: tni_parents_done
summary: A mainland mother wants her son named and doesn't understand why she won't be told the name. The voyages are suspended.
objectives:
  talk npc_ilsabet_fenrow
  reach tni_harbour_quay_tomas
  choice gift_trust_or_risk
-->

---

## 8. A Boat Nobody May Sail

*A · OddJob · the boatyard · giver Boatwright Dovrik Plankmaker*

**The short version.** Every spring Dovrik builds a small boat for a child's Naming Voyage. The voyages are suspended. He is building this year's boat anyway, and he wants the player to help him finish it.

**What is really going on.** Dovrik has a granddaughter, Nuala, who is eleven and next in line. She is frightened and has not told anyone. The boat is not for the voyage. It is for her to *have,* so that if the day ever comes, she is not alone in it. The player's job is to help build, and to listen.

**Scene 1: the yard.**

**DOVRIK:** (not looking up, planing a plank) "Forty-one boats. Forty-one children. All came home."
**DOVRIK:** "Then they stopped coming home."
**DOVRIK:** "I am building a forty-second."
> ► **"Who is it for?"** — **DOVRIK:** "A girl. She doesn't know."
> ► **"Isn't it pointless?"** — **DOVRIK:** "Everything I do is pointless. It's called craft."
> ► **"I'll help."** — **DOVRIK:** "Hold the end."

**Scene 2: the building.** For three days, in the sun, the player and Dovrik build the small boat: steam-bent ribs, scarfed planks, a mast no thicker than a wrist. Dovrik hums as he works, a three-note tune he does not seem to notice.

**NUALA (entering, small, carrying lunch):** "Grandfather says that's a rowing skiff."
**DOVRIK:** "It is."
**NUALA:** "It's too small for rowing."
**DOVRIK:** "...It's a *very* small skiff."
*Nuala sets the lunch down. She does not meet anyone's eye.*
> ► **"Do you like it?"** — **NUALA:** "It's the best one you've done."
> ► **"What are you afraid of?"** — **NUALA:** "...Not coming back."
> ► **"Would you like to name it?"** — **NUALA:** "...Can I?"

**Scene 3: the launch.** On the fourth morning, the boat is finished. It sits on the slip, pale and clean. Nuala stands beside it.

**NUALA:** "It doesn't have a name yet."
**DOVRIK:** "Boats don't need a true name. Just a common one."
**NUALA:** "Then I'll call it *Back.*"
> ► **(Say, "That's a fine name.")** — Dovrik's jaw tightens.
> ► **(Say nothing, and help launch.)** — They push it down the slip together.
> ► **(Give Nuala a coin for luck.)** — **NUALA:** "I'll keep it."

**Scene 4: the water.** *Back* floats, level and sound, on the calm harbour. Nuala does not get in. She stands on the quay, looking at it. Dovrik stands behind her.

**DOVRIK:** "It'll wait."
**NUALA:** "How long?"
**DOVRIK:** "As long as it takes."

**Scene 2b: the planing.** On the second afternoon Dovrik lets the player try the plane, and the player makes a fine mess of it.

**DOVRIK:** "Long strokes. Like you're stroking a cat."
**PLAYER:** "A cat that doesn't want to be stroked."
**DOVRIK:** "All good wood is like that."
*He takes the plane back, makes one long, whispering stroke along the plank, and a curl of pale wood falls to the floor. It smells of resin and sun.*
**DOVRIK:** "My father's father taught me. He said a boat is a promise you can float."
> ► **"Who was the first boat for?"** — **DOVRIK:** "My brother. He came back."
> ► **"Is this promise kept?"** — **DOVRIK:** "I don't know yet."

**Scene 4b: the grandmother's tea.** That evening Nuala's grandmother, Dovrik's wife Sine, finds the three of them on the quay and, without a word, pours tea for each.

**SINE:** "He hasn't built a boat in weeks. He's built three in his head."
**DOVRIK:** "It's a good habit."
**SINE:** "It's a *worry.* They're the same thing, in you."
*Nuala takes her cup and leans against her grandmother. For the first time that day, she looks like a child instead of a navigator.*

**Outcomes and receipt.**
- Nuala has a boat and a name for it; the voyage is not promised. If the player gave her a coin, she wears it on a cord.
- **Not answered:** whether the voyages will resume or whether Nuala will be safe.
- **Receipt:** the skiff *Back,* moored at the harbour's end, with a small lantern lit each dusk.

<!-- quest
id: qst_tni_boat_nobody_sails
title: A Boat Nobody May Sail
rank: A
type: OddJob
giver: npc_dovrik_plankmaker
region: reg_true_name_isles
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: tni_boat_done
summary: A boatwright builds a small Naming boat each spring. The voyages are suspended, but his granddaughter is next in line.
objectives:
  talk npc_dovrik_plankmaker
  reach tni_boatyard_slip
  choice praise_launch_or_coin
-->

---

## 9. The Lantern Vigil

*A · Defense · the harbour and the Naming Rocks · giver Vigilkeeper Odu Lanternwright*

**The short version.** On the night the voyages would normally sail, the harbour lights lanterns for the children at sea. This year there are no children at sea, and the families of the empty children want to light them anyway. A storm is rising.

**What is really going on.** The storm is natural, but the families are in boats on open water, and the lanterns are on the Naming Rocks. Odu's job is to keep them lit through the night. The player's job is to keep the *people* safe, and to help the vigil hold, without the sea deciding to take anything.

**Scene 1: the quay.**

**ODU:** "Thirty-one years I have lit these. The children sail, and we light the lanterns, and they come home by them."
**ODU:** "This year, nobody sails. And I'm lighting them anyway."
**ODU:** "The families asked. All eleven. I could not say no."
> ► **"Is a storm coming?"** — **ODU:** "By midnight."
> ► **"Is it safe?"** — **ODU:** "Nothing's safe on the Rocks."
> ► **"What do you need?"** — **ODU:** "Hands. Oars. Patience."

**Scene 2: the rowing.** A hushed, determined sequence. A dozen small boats, one for each family, row out to the Naming Rocks in the dusk, each carrying a lantern. The sea is calm, then not. The pillars rise from the dark, a ring of stone teeth.

**ODU:** "One lantern on each pillar. Not one more."
**FATHER:** "If they're not lit, how will our daughters find the way home?"
**ODU:** "They will. They *will.*"

**Scene 3: the storm.** At midnight the wind rises. Waves slap at the pillars. Lanterns gutter. A boat starts to drift. The player must keep the boats in the ring, shield the flames and keep the families calm, as the storm breaks over them in sheets of cold rain.

*(Gameplay: protect the lanterns and boats from rising waves, and rescue anyone who falls.)*
> ► **(Row for the drifting boat first.)** — The family is safe; one lantern goes out.
> ► **(Shield the lanterns first.)** — All lit; one boat is lost for an hour.
> ► **(Call to the families to sing.)** — A thin song steadies the ring.

**Scene 4: the dawn.** The storm passes. The Rocks are wet and shining. Eleven lanterns, still lit. Eleven boats, all afloat.

**ODU:** (hoarse) "We held."
*Far out, past the ring, the water lifts once and falls. The lanterns flicker, and burn on.*

**Scene 2b: the families' boats.** Before the rowing, Odu walks the quay with the player and introduces each family, one by one. There are no speeches. Each simply says a name, the common name of the child, and hands over a lantern.

**MOTHER:** "Kela. She likes the colour orange."
**FATHER:** "Tam. He never sits still."
**GRANDMOTHER:** "Iri. She sang before she talked."
*Eleven lanterns, eleven common names, eleven small facts. They will not be spoken again tonight. Odu writes none of them down. He simply nods at each, as though filing it somewhere that matters.*
> ► **"I'll remember them."** — **ODU:** "Good. That's what the lanterns are for."
> ► **"Do they know?"** — **ODU:** "The children? I hope so."

**Scene 4b: the families at dawn.** As the boats come in, the families do not speak. They carry the lanterns up the quay, still burning, and set them along the harbour wall in a row.

**MOTHER:** "I didn't think I'd feel better."
**FATHER:** "Do you?"
**MOTHER:** "Not better. *Held.*"
*Odu walks the row, trimming each wick with his thumb and forefinger. At the last lantern he stops, and says, to no one in particular, a name that is only a common one, and is enough.*

**Outcomes and receipt.**
- The vigil holds; the families row home as the sun rises. If the player lost a lantern, the family keeps the burnt wick as a charm.
- No name is taken. The Tide does not appear.
- **Receipt:** eleven small lamps on the harbour wall that now stay lit all year; a new custom: *"the lantern for the unsailed."*

<!-- quest
id: qst_tni_lantern_vigil
title: The Lantern Vigil
rank: A
type: Defense
giver: npc_odu_lanternwright
region: reg_true_name_isles
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: tni_vigil_done
summary: The harbour lights lanterns on the night the voyages would sail. Eleven families want to light them at the Naming Rocks, with a storm rising.
objectives:
  talk npc_odu_lanternwright
  defend tni_naming_rocks_vigil
  choice drifting_lanterns_or_song
-->

---

## 10. The Pillar That Does Not Answer

*A · Exploration · the Naming Rocks · giver Pillar-Tender Ennis Hollowtide*

**The short version.** The Naming Rocks are a ring of stone pillars in the open sea, and each one sounds a faint note when the wind passes. Ennis has swept them for twenty years. One has gone silent.

**What is really going on.** *Nothing is explained.* The silent pillar has a smooth hollow on its seaward face, shaped like the outline of a name. The quest ends with the player standing at the pillar's foot, at slack water, and hearing nothing. The question is what the silence is *for.*

**Scene 1: the boat.**

**ENNIS:** "Fourteen pillars. Fourteen notes. I know them like a hymn."
**ENNIS:** "The seventh stopped last month. The wind passes. The stone stays *mute.*"
**ENNIS:** "I've sworn, wept and sung at it. Nothing."
> ► **"Has it cracked?"** — **ENNIS:** "No. It's sound."
> ► **"What do you want?"** — **ENNIS:** "To know if it's *dead* or *listening.*"
> ► **"I'll look."** — **ENNIS:** "Slack water. Dawn. Bring salt."

**Scene 2: the Rocks.** The player and Ennis row out at dawn. The ring is quiet. At the seventh pillar the stone is smooth, grey and cold, and a faint hollow runs down its seaward face, deeper than a hand.

**ENNIS:** "That wasn't there last month."
**ENNIS:** "It has the shape of... I don't want to say."
*Standing in the shallows, the player can trace the hollow's edge. It is the outline of a word, curved, rounded, without letters.*
> ► **(Put a hand in the hollow.)** — The stone is warm.
> ► **(Speak into it.)** — The sound does not return.
> ► **(Brush salt over it.)** — Ennis's old ritual.

**Scene 3: the silence.** The wind drops. The sea goes still. The thirteen other pillars murmur softly, one by one, and then, as the tide turns, fall silent as well. The ring is entirely quiet. The silence has weight. It feels like a held breath, and a held name.

**ENNIS:** (whispering) "...It's *listening.*"
> ► **(Stay and listen.)** — The silence deepens.
> ► **(Call a name, any name.)** — No echo. Not even a whisper.
> ► **(Row away.)** — **ENNIS:** "...Perhaps wise."

**Scene 4: the note.** As the boat pulls away, a single faint note rises from the seventh pillar, so low that it is more felt than heard. It lasts a heartbeat. It is not a note the stone has ever made.

**ENNIS:** "...What *was* that?"
*Neither of them speaks again until they reach the harbour.*

**Scene 2b: the tender's log.** On the row out, Ennis shows the player the log she keeps, a small waterproof book with one line for each dawn: wind, tide, notes of the pillars.

**ENNIS:** "Seven thousand and some dawns. Seven thousand and some lines."
**ENNIS:** "Do you know what I write for the seventh pillar, these last thirty days? *Silent.* One word. Thirty times."
**ENNIS:** "I've started to hate the word."
*She turns the page to a blank line and holds the pencil above it, as though hoping the day will supply a better one.*
> ► **"Write what you feel."** — **ENNIS:** "'Afraid.' ...No. I'd better not."
> ► **"Write what you see."** — **ENNIS:** "'Calm.' Which is the worst of it."

**Outcomes and receipt.**
- The pillar remains silent after the note. If the player called a name, the tender will not say how it felt to hear no echo.
- **Seed (unexplained):** the hollow, the silence of all fourteen pillars and the last note. The quest does not say whether this is the Nameless Tide, the sea's will, or something unrelated.
- **Receipt:** a pinch of salt on the seventh pillar's base; Ennis writes the date in her log, and nothing else.

<!-- quest
id: qst_tni_silent_pillar
title: The Pillar That Does Not Answer
rank: A
type: Exploration
giver: npc_ennis_hollowtide
region: reg_true_name_isles
level: 138
act: 4
requires_rank: A
reward: 34000 | 1700 | 150000
sets: tni_pillar_done
summary: One of fourteen stone pillars in the Naming Rocks has fallen silent, and carries a smooth hollow in the shape of a name.
objectives:
  talk npc_ennis_hollowtide
  reach tni_naming_rocks_seventh_pillar
  choice stay_call_or_row
-->
