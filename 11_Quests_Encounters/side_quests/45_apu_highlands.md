# 11e-45 — Apu Highlands, the Carved Mountains: Ten Side Quests (draft)

> *"A wall that falls is mourned like a person, and rebuilt by the whole community."*
> — Gazetteer, Apu Highlands

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 10 plants an unexplained seed.

**Region:** `reg_apu_highlands` (the terrace cities, the Great Terraces, the Cord House, the Giant's Bed). **Rank band:** A–S. **Tone:** communal, hard-working, quietly proud; stone, wool, rope and knotted cord; grief for walls and pride in mending them.

**Placement notes.**
- **Ukhu-Tal, Stone Giant of the First Making,** is the region's Tyrant. He is the mason who carved the first terraces; he has woken to find them covered in people and patched with other stones. He breaks the walls he did not make. No quest here kills, defeats, bargains with or speaks to Ukhu-Tal, and none ends the siege. He is seen at a distance, and his footfalls are felt.
- Customs the quests rely on: labour, not coin, is the tax; work days are feasts; a fallen wall is mourned like a person and rebuilt by everyone; every peak (apu) has a shrine with coca leaf, maize beer and cloth; the cord-keepers' order is dwindling and the oldest cords are mostly unread.
- **Open Canon point left alone:** whether Ukhu-Tal is angry or proud, and whether anyone can read the oldest cords well enough to tell him. Quests 1, 9 and 10 touch the cords but give no reading that settles it.
- **Rank note.** Quests 1 to 8 are rank A (level 120 to 159). Quests 9 and 10 are rank S (level 160 to 205; GP 3,000; see `Data/World/guild_ranks.json`); their rewards are extrapolated from the promotion table and the Whitewater S-rank quests, and are first-pass.
- The region is `besieged` at start. No quest here is SiegeDefence; quest 7 is a plain Defense of one work site.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Cord With Three Ends | A | Investigation | Cord-Keeper Wayra Quispehuaman | A knot that reads two ways |
| 2 | Mourning a Wall | A | Faction | Mason Tupaq Illapayoc | A funeral for stone |
| 3 | The Last Runner of the Relay | A | Delivery | Chaski Sumaq Rimaypa | A message and a broken road |
| 4 | The Bridge Is Rewoven Once a Year | A | OddJob | Bridge-Mother Ch'aska Mamanipa | Rope, hands and a deadline |
| 5 | The Llama Who Would Not Climb | A | Hidden | Herder Inti Paucarwaman | A young herder and a stubborn animal |
| 6 | A Hundred Kinds of Potato | A | Gathering | Seed-Keeper Rumi Cusihuaman | A lineage in a sack |
| 7 | Work Day at the Falling Terrace | A | Defense | Steward Yachay Apazaqolla | A feast under a threatened wall |
| 8 | The Girl Who Came Back for the Knots | A | OddJob | Illari Ticapampa | Coming home to learn |
| 9 | The Mason's Mark | S | Investigation | Mason-Elder Atoq Huamancho | Which stones are his |
| 10 | The Cord That Ends in a Gap | S | Exploration | Cord-Keeper Sisa Condoriqui | A summit and an unread knot |

## Cast

<!-- npc
id: npc_wayra_quispehuaman
name: Cord-Keeper Wayra Quispehuaman
tier: major
race: Human
region: reg_apu_highlands
settlement: Terrace cities
role: Cord-keeper of the Cord House
backstory: A lean, ink-stained-fingered cord-keeper of sixty who can read two thirds of the Cord House and has hidden, for ten years, how much of the rest she is only guessing.
-->
<!-- npc
id: npc_tupaq_illapayoc
name: Mason Tupaq Illapayoc
tier: major
race: Human
region: reg_apu_highlands
settlement: Terrace cities
role: Master mason of a terrace wall
backstory: A broad, soft-spoken mason who has mended walls for forty years and has just watched the first wall he ever laid fall in a single night.
-->
<!-- npc
id: npc_sumaq_rimaypa
name: Chaski Sumaq Rimaypa
tier: townsfolk
race: Human
region: reg_apu_highlands
settlement: Relay huts
role: Relay runner
backstory: A wiry runner of twenty-three who carries messages along the stone roads and who has just found the next hut a day away, with a gorge where the road used to be.
-->
<!-- npc
id: npc_chaska_mamanipa
name: Bridge-Mother Ch'aska Mamanipa
tier: major
race: Human
region: reg_apu_highlands
settlement: Terrace cities
role: Master of the yearly bridge-weaving
backstory: A sturdy, cheerful grandmother who has led the rewoven rope bridge across the same gorge for thirty-one years and who is short of grass-rope and hands this year.
-->
<!-- npc
id: npc_inti_paucarwaman
name: Herder Inti Paucarwaman
tier: townsfolk
race: Human
region: reg_apu_highlands
settlement: Upper terraces
role: Young llama herder
backstory: A shy fourteen-year-old herder on his first season alone with the upper herd, whose lead llama has stopped at the foot of a stair and will go no further.
-->
<!-- npc
id: npc_rumi_cusihuaman
name: Seed-Keeper Rumi Cusihuaman
tier: major
race: Human
region: reg_apu_highlands
settlement: Terrace cities
role: Keeper of terrace seed stock
backstory: A round, patient seed-keeper who holds in her storehouse three hundred and eleven kinds of potato and knows that a fallen terrace has taken the only field of four of them.
-->
<!-- npc
id: npc_yachay_apazaqolla
name: Steward Yachay Apazaqolla
tier: major
race: Human
region: reg_apu_highlands
settlement: Terrace cities
role: Steward of a great family's work days
backstory: A brisk, tired steward who organises the community work days for a terrace city and who has promised four hundred people a feast on a wall that may not stand until noon.
-->
<!-- npc
id: npc_illari_ticapampa
name: Illari Ticapampa
tier: townsfolk
race: Human
region: reg_apu_highlands
settlement: Terrace cities
role: Returned coast-worker who wants to learn the knots
backstory: A nineteen-year-old who left for the coast at fifteen, came home after the great walls began to fall, and has found that the one cord-keeper left in her valley is not sure she wants a pupil.
-->
<!-- npc
id: npc_atoq_huamancho
name: Mason-Elder Atoq Huamancho
tier: major
race: Human
region: reg_apu_highlands
settlement: Terrace cities
role: Elder mason who keeps the wall-lore
backstory: A very old, very exact mason who can name the builder of a wall by its fit and who has begun to suspect that the oldest, tightest walls were not built by any of the families.
-->
<!-- npc
id: npc_sisa_condoriqui
name: Cord-Keeper Sisa Condoriqui
tier: major
race: Human
region: reg_apu_highlands
settlement: The Giant's Bed approach
role: Cord-keeper of the summit shrine
backstory: A tall, weathered cord-keeper who tends the shrine under the Giant's Bed and carries a single old cord that she has never been able to finish reading.
-->

---

## 1. The Cord With Three Ends

*A · Investigation · the Cord House · giver Cord-Keeper Wayra Quispehuaman*

**The short version.** Wayra has found an old cord that can be read from either end, and each reading says something different about the stone giant's name.

**What is really going on.** The cord is a family's terrace record, and it was knotted by two people, one from each end. Neither reading is wrong. It is a *conversation,* and the player's job is to decide how the Cord House should record it. The cord does not settle what Ukhu-Tal feels.

**Scene 1: the Cord House.**

**WAYRA:** "Three thousand cords on these shelves. I can read two thirds. Most days I tell people it is more."
**WAYRA:** "This one has three ends. From the left it says *Ukhu-Tal built, and the family kept.* From the right it says *Ukhu-Tal built, and the family forgot.*"
> ► **"Which is true?"** — **WAYRA:** "That is what I would like not to have to choose."
> ► **"Who tied it?"** — **WAYRA:** "That is what you can find out."
> ► **"I'll look into it."** — **WAYRA:** "Bring the families' own cords. And be gentle with the old ones."

**Scene 2: the families.** In two terrace homes the player is shown family cords. The Quispe line tie *kept;* the Mayta line, across the gorge, tie *forgot.* Both families built from the same wall.

**OLD MAYTA:** "My grandmother said we were told to stop touching the stones. So we stopped. That is forgetting."
**OLD QUISPE:** "My grandmother said we were told to keep the stones as they were. So we kept them. That is keeping."
> ► **"You were both told the same thing."** — The two old people look at each other for the first time in years.
> ► **"One of you is wrong."** — **OLD QUISPE:** "No. But thank you for wanting a simple answer."
> ► **"Tell me how you tie it."** — Each shows the other a knot.

**Scene 3: the reading.** In the Cord House, Wayra, the player and both old people stand round the long table. The cord is laid flat.

**WAYRA:** "Read from the left."
**OLD QUISPE:** "Ukhu-Tal built. The family kept."
**OLD MAYTA:** "Now from the right. Ukhu-Tal built. The family forgot."
**WAYRA:** "Together?"
*Nobody speaks. Then Old Mayta says, very quietly, "Built. Kept. Forgot. Kept."*
> ► **"Record both."** — **WAYRA:** "A cord with two readers. I have not seen that written."
> ► **"Record the left."** — **WAYRA:** "That is the easy choice. I will write it down as yours."
> ► **"Leave it unread."** — **WAYRA:** "Honest. Perhaps the best."

**Scene 4: the shelf.** Wayra ties a new short cord to the old one, a tag, and sets both on a shelf where they can be reached.

**WAYRA:** "The next keeper will read it the way she needs."
**WAYRA:** "I told someone yesterday I could read nine parts in ten. It is six."

**Scene 5: the choice has a price.** Whichever way the player records the cord, someone is a little unhappy, and Wayra says so out loud.

**WAYRA:** "Every keeper before me chose quietly and let the shelf do the arguing. I would like the next one to know it was a choice."
**OLD MAYTA:** "Will you put my name on the tag?"
**WAYRA:** "I will put both. Quispe and Mayta, side by side, like the knots."
> ► **"Put the player's name too."** — **WAYRA:** "No. A keeper's mark is for the family, not the guest."
> ► **"Leave the names off."** — **WAYRA:** "Then it is a cord nobody owns. I do not know if that is better."
> ► **"Both names, then."** — She nods, and ties them.

*Gameplay note: the record choice sets a quiet flag that changes one line of Wayra's later greeting; it has no mechanical reward penalty.*

**Outcomes and receipt.**
- Recording both readings makes the Cord House slightly more honest and Wayra a little braver with her apprentices. Recording one reading is accepted but the other family goes quiet.
- **Receipt:** a short tag-cord on the old one, tied by the player's choice of knot; Old Mayta and Old Quispe are seen sharing maize beer at the shrine.
- **Canon-safe:** the cord does not say how Ukhu-Tal feels about his walls.

<!-- quest
id: qst_apu_three_ends
title: The Cord With Three Ends
rank: A
type: Investigation
giver: npc_wayra_quispehuaman
region: reg_apu_highlands
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: apu_three_ends_done
summary: An old cord can be read from either end and says two different things about the stone giant's name. It was tied by two people.
objectives:
  talk npc_wayra_quispehuaman
  reach apu_cord_house_long_table
  choice record_both_one_or_leave
-->

---

## 2. Mourning a Wall

*A · Faction · the terrace of the Ayllu stones · giver Mason Tupaq Illapayoc*

**The short version.** The first wall Tupaq ever laid has fallen in a night. By custom the wall must be mourned and rebuilt by everyone. Nobody has come.

**What is really going on.** The terrace is on a slope people think the giant will tread again. They are afraid to be seen mourning it, in case they are *wasting* grief. The player's job is to bring the first mourners, and to choose how the rebuilding is led.

**Scene 1: the rubble.**

**TUPAQ:** "I was twelve. My father set the first stone and let me set the second."
**TUPAQ:** "It fell last night. No sound. I woke up and the hill was a different shape."
**TUPAQ:** "I have called the mourning three times. The horn went out. Nobody came."
> ► **"Why not?"** — **TUPAQ:** "They think he will break it again. They think it is foolish to mourn a thing you will lose twice."
> ► **"I will come."** — **TUPAQ:** "Then it is two. That is a start."
> ► **"What does mourning need?"** — **TUPAQ:** "A song, a stone each, and someone to say its name."

**Scene 2: the village.** The player goes door to door. A weaver, a stonecutter's widow and a boy who worked the wall as a child each say yes, in their own way.

**WEAVER:** "We cannot afford to mourn what the giant will take again."
**STONECUTTER'S WIDOW:** "We cannot afford *not* to. That is what the walls are."
> ► **"Come for the song."** — She comes.
> ► **"Come for Tupaq."** — The weaver comes, grumbling.
> ► **"Come for the boy."** — The boy is already on the road.

**Scene 3: the funeral.** Thirty people gather on the hillside at dusk. Each lays a stone on the rubble and says a word.

**TUPAQ:** "This wall was called Little Brother. It held a field of oca for eleven years."
**TUPAQ:** "It did its work. It was a good wall."
*A flute plays three low notes. The villagers hum them back, uneven.*
> ► **"Rebuild it as it was."** — **TUPAQ:** "That is how my father did it."
> ► **"Rebuild it with a gap for the water."** — **TUPAQ:** "My grandfather would shout. I think my grandmother would agree."
> ► **"Rebuild it together, now."** — The thirty begin at once.

**Scene 4: the first course.** By morning the first course is down, crooked, bound by the whole village.

**TUPAQ:** "It will not be as fine."
**BOY:** "It is ours."

**Scene 5: the second course.** Three days later the wall has risen two courses. The player is asked, by the stonecutter's widow, to set one stone.

**WIDOW:** "Not the first. The first is Tupaq's. But one."
**TUPAQ:** "Choose a stone that does not fit. Then choose its neighbour. A wall is only a long argument that stops."
> ► **"Set it crooked on purpose."** — Tupaq laughs for the first time in a week.
> ► **"Set it true."** — He checks it with a thumb and says nothing, which is praise.
> ► **"Give the stone to the boy."** — The boy sets it, and it is the best-fitted of the day.

**TUPAQ:** "My father would have said the giant could take any of them. I think I would like it if he looked at this one."
*The hillside is quiet. Far above, something very large shifts on the ridge, and nothing falls.*

**Outcomes and receipt.**
- The mourning custom is honoured and the rebuild begun. Choosing the water-gap changes the wall to a better drained shape that is later cited in other terraces.
- **Receipt:** a single flat stone on the new wall with a small hollow for offerings, "Little Brother's Cup."

<!-- quest
id: qst_apu_mourning_wall
title: Mourning a Wall
rank: A
type: Faction
giver: npc_tupaq_illapayoc
region: reg_apu_highlands
level: 124
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: apu_mourning_wall_done
summary: A mason's first wall has fallen overnight and nobody will come to mourn it, for fear of grieving twice.
objectives:
  talk npc_tupaq_illapayoc
  reach apu_ayllu_stones_terrace
  choice rebuild_asis_gap_or_together
-->

---

## 3. The Last Runner of the Relay

*A · Delivery · the stone road above the gorge · giver Chaski Sumaq Rimaypa*

**The short version.** A runner carries a sealed cord to the next city. The road has fallen into a gorge, and there are two ways round.

**What is really going on.** The message is a cord-note from a mother to a son, telling him that his sister is born. It is not an emergency, and Sumaq knows it. He wants to deliver it *anyway,* because that is what the relay is for.

**Scene 1: the relay hut.**

**SUMAQ:** "Day-run to Hatun Pampa. The road went last night. The next hut is on the other side of a gorge that was not there on my last run."
**SUMAQ:** "I could go back. Nobody would ask."
> ► **"What is in the pouch?"** — **SUMAQ:** "A cord. It is a private one."
> ► **"Why not go back?"** — **SUMAQ:** "Because it is a cord."
> ► **"I'll go with you."** — **SUMAQ:** "Do not slow me down. Please."

**Scene 2: the climb.** A high scramble around the gorge's head, over scree and a half-fallen terrace. A condor circles low.

**SUMAQ:** "My mother was a runner. She said the message does not care how you feel."
> ► **"Take the scree route."** — Faster, with a drop.
> ► **"Take the old herders' ledge."** — Slower, safer.
> ► **"Carry the pouch yourself."** — Sumaq looks very relieved.

**Scene 3: the other side.** At a rope bridge lashed together by the villagers of the far side, a small crowd waits. They had seen the road fall, and they are on the bridge with lanterns.

**VILLAGER:** "The cord for Hatun Pampa? We will take it from here. We run."
**SUMAQ:** "It is my cord."
**VILLAGER:** "Then run with us."

**Scene 4: the cord.** In Hatun Pampa, the son reads the cord with his thumb in the dusk. He is silent for a long time, then laughs.

**SON:** "A sister. Her name is Quilla."
**SUMAQ:** "Her name is on the cord, then?"
**SON:** "In the last knot. Where mothers tie it."

**Scene 5: the thread.** Before the player leaves Hatun Pampa, the runners of the far side tie a red thread to the player's wrist, and Sumaq explains what it means.

**SUMAQ:** "It says you carried one of ours. It will not make a road. It will get you a bowl of soup and a bed in any hut on the route."
**RUNNER (far side):** "And a place on the bridge-rope, if you can keep up."
> ► **"I'll keep up."** — Laughter, and a challenge for the morning.
> ► **"What about the road?"** — **SUMAQ:** "Masons will come. Until then we run the long way."
> ► **"Who was the cord from?"** — **SUMAQ:** "His mother. She is a runner. She gave me the message and said not to run too fast."

*The route is not mended by this quest. Roads are mended by work days, and a work day comes next.*

**Scene 6: the road, remembered.** On the way back the player passes the gap where the road fell, and a mason crew is already at work, three days early and unasked.

**MASON:** "A runner came through and told us the cord got there. We had been wondering what the road was for."
**MASON:** "We build the road. The runners make it a road."
> ► **"How long will it take?"** — **MASON:** "A season. Maybe two. The mountain does not hurry us."
> ► **"I'll carry stone."** — A hand pushes a sack onto your shoulder before you finish the sentence.
> ► **"Leave them a lunch."** — They accept it as a toll, with great solemnity.

**Outcomes and receipt.**
- The cord is delivered; the relay holds. Which route the player chose is quietly noted by the runners.
- **Receipt:** a small red thread tied to the player's wrist by the relay runners, "the Chaski's thread," worn lightly on the road.

<!-- quest
id: qst_apu_last_runner
title: The Last Runner of the Relay
rank: A
type: Delivery
giver: npc_sumaq_rimaypa
region: reg_apu_highlands
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: apu_last_runner_done
summary: A relay runner carries a private cord to the next city across a gorge where the road used to be.
objectives:
  talk npc_sumaq_rimaypa
  reach apu_hatun_pampa_bridge
  choice scree_ledge_or_carry
-->

---

## 4. The Bridge Is Rewoven Once a Year

*A · OddJob · the Rope Gorge · giver Bridge-Mother Ch'aska Mamanipa*

**The short version.** The rope bridge must be rewoven in three days. Half the grass-rope is missing and half the hands are mending walls.

**What is really going on.** The grass was cut, then spoiled by damp. The weavers are proud and will not ask the neighbouring valley for help, because the valleys quarrel over water. The player is a neutral pair of hands.

**Scene 1: the gorge.**

**CH'ASKA:** "Thirty-one years. Every June the old bridge comes down and the new one goes up. Everyone brings a rope."
**CH'ASKA:** "This year the rope is wet. And the hands have gone to the walls."
> ► **"What do you need?"** — **CH'ASKA:** "Four hundred arm-lengths of dry grass-rope. And six who will not mind heights."
> ► **"Where is the nearest dry grass?"** — **CH'ASKA:** "Across the water-quarrel. I would rather lose the bridge."
> ► **"I'll ask them."** — **CH'ASKA:** "Be kind to the old man at the lower mill."

**Scene 2: across the quarrel.** The player carries a gift of maize beer to the lower mill. The old miller listens, fiddles with a rope, and agrees.

**MILLER:** "We have dry grass. We have not been asked in nine years."
**MILLER:** "My daughter will bring it. She speaks to no one from your side. Do not talk to her about water."
> ► **"Thank her instead."** — The daughter brings the rope with a stiff nod.
> ► **"Offer to carry some."** — She almost smiles.
> ► **"Say nothing."** — Safe, cold.

**Scene 3: the weaving.** Over two long days, strand twisted to cord to cable, a hundred hands from both sides of the quarrel. The player works the high rope.

**CH'ASKA:** "Left over right. Pull from the heart, not the arm."
*A weaver from each valley ends up working the same cable without noticing.*
> ► **"Let the two sides finish together."** — They do.
> ► **"Give the last knot to the miller's daughter."** — She is startled, then tears up.
> ► **"Give it to Ch'aska."** — **CH'ASKA:** "No. I tied thirty-one. Give it to someone new."

**Scene 4: the crossing.** On the third dawn, the new bridge sways over the gorge. The first crossing is slow, a child, an old woman and a llama, together.

**CH'ASKA:** "She holds."

**Scene 5: the cable's song.** On the second night of weaving, a work song starts that neither valley claims. It is half one valley's tune, half the other's.

**MILLER'S DAUGHTER:** "That is not ours."
**WEAVER (other side):** "It is not ours either."
**CH'ASKA:** "Then it is the bridge's. Sing it."
> ► **"Learn the words."** — They are about rope and weather, and very rude about mules.
> ► **"Hum along."** — The daughter glances at you and hums louder.
> ► **"Ask who wrote it."** — **CH'ASKA:** "Nobody. It is written every year, and nobody remembers the year before."

**CH'ASKA:** "That is how you know it is right."
*The water-quarrel is mentioned only once, by a child, and forgotten in the next verse.*

**Scene 6: after the crossing.** A week after the bridge opens, the player is stopped on it by an old woman with a basket who simply wants to say that her knees remember being young here.

**OLD WOMAN:** "I crossed the first one when I was nine. It had a hole you could drop a cat through."
**OLD WOMAN:** "Mind your feet. And do not look at the water. Look at the other side."
> ► **"What is on the other side?"** — **OLD WOMAN:** "Everyone I will see this year."
> ► **"I'll mind my feet."** — She pats your arm, which sways the whole bridge.
> ► **"Walk with her."** — It takes twenty minutes and it is the best twenty of the day.

**Outcomes and receipt.**
- The bridge is made on time. The water-quarrel is not ended, but the two valleys have woven a rope together.
- **Receipt:** a short length of grass-rope with a double knot, hung in the shrine at the gorge head.

<!-- quest
id: qst_apu_bridge_reweave
title: The Bridge Is Rewoven Once a Year
rank: A
type: OddJob
giver: npc_chaska_mamanipa
region: reg_apu_highlands
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: apu_bridge_done
summary: The yearly rope bridge must be rewoven in three days with half its grass-rope spoiled, and the dry grass lies across a water-quarrel.
objectives:
  talk npc_chaska_mamanipa
  collect apu_dry_grass_rope 4
  choice finish_together_daughter_or_chaska
-->

---

## 5. The Llama Who Would Not Climb

*A · Hidden · the upper terraces · giver Herder Inti Paucarwaman*

**The short version.** A boy's lead llama stops at the foot of a stair and will not climb. The herd will not pass her.

**What is really going on.** The llama can feel a faint tremor on the stair's upper flight that people cannot. The stair is about to fail. She is saving the herd, and she is shy about being thanked.

**Scene 1: the stair.**

**INTI:** "She is called Nina. She has never refused a stair."
**INTI:** "I have shouted. I have pulled. She just looks at me."
**INTI:** "My grandfather says that when a llama will not go, you do not go."
> ► **"Listen to your grandfather."** — **INTI:** "I wanted someone to say it."
> ► **"Let me look."** — **INTI:** "Please do."
> ► **"Try another stair."** — **INTI:** "There isn't one."

**Scene 2: the flight.** The player climbs the stair alone, hand on the stones, and feels what Nina feels: a faint, regular shudder.

**ENV (journal):** *Ninth step: a hairline. Fourteenth: the stone moves a finger's width under a hand.*
> ► **"Mark the steps."** — Chalk, quickly.
> ► **"Send for a mason."** — A runner goes.
> ► **"Warn the herd route."** — Inti nods slowly.

**Scene 3: the fall.** As the player descends, the upper flight lets go with a long grinding sound and slides into the gorge. Dust. Silence.

**INTI:** (whispering) "...She knew."
*Nina turns away, ears back, embarrassed.*
> ► **"Thank her."** — She nudges your elbow.
> ► **"Give her coca."** — She eats it with great dignity.
> ► **"Tell the herd."** — Inti shouts it down the terraces.

**Scene 4: the new road.** The masons mark a safe route round the fall. The herd follows Nina, in a long, patient line.

**INTI:** "I am going to listen to her from now on."
**NINA:** (spits, kindly)

**Scene 5: the herders' fire.** That night the herders gather round Inti's fire, and the older ones tell how many times a llama has been right when a man was wrong.

**OLD HERDER:** "My uncle's mule went down a stair. My uncle's llama did not. We buried the mule, the proper way."
**INTI:** "Nina was crying a bit, I think."
**OLD HERDER:** "That is not crying. That is insulting you. Take it as a mark of respect."
> ► **"Ask how to hear her better."** — A long, generous lesson in ears, tails and spit.
> ► **"Offer the coca to the apu."** — They approve of that more than the thanking.
> ► **"Ask Inti what he'll do now."** — **INTI:** "Listen. And be taller."

*Gameplay note: Nina can be found on the upper terraces afterwards; she will not follow the player, and she will not be petted.*

**Scene 6: the old stair.** The mason sent for in scene 2 arrives, a day late, and looks at the fall with the professional gloom of a man who has been proven right.

**MASON:** "I told them that stair was tired. Nobody listens to a mason who says 'tired.'"
**INTI:** "Nina listened."
**MASON:** "Then she is the better mason. Tell her I said so."
> ► **"I'll tell her."** — You do. She spits near your boot.
> ► **"Will you rebuild it?"** — **MASON:** "Not that stair. A new one, left of it, with a rail."
> ► **"Hire her."** — Inti beams.

**Outcomes and receipt.**
- The player is thanked by the herders; the stair is closed and a new path made. Thanking the animal is noticed by the herding families.
- **Receipt:** a small woven llama-halter charm, red and blue, from Inti.

<!-- quest
id: qst_apu_llama_stair
title: The Llama Who Would Not Climb
rank: A
type: Hidden
giver: npc_inti_paucarwaman
region: reg_apu_highlands
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: apu_llama_done
summary: A boy's lead llama refuses a stair that is about to fall into a gorge.
objectives:
  talk npc_inti_paucarwaman
  reach apu_upper_stair
  choice mark_send_or_warn
-->

---

## 6. A Hundred Kinds of Potato

*A · Gathering · the seed-store and the lost terraces · giver Seed-Keeper Rumi Cusihuaman*

**The short version.** A fallen terrace took the only field of four potato kinds. Rumi needs tubers from four households that still hold a few.

**What is really going on.** The four kinds are tied to four families' marriages and their lost relatives. Each family gives its seed only if the player listens to the story first.

**Scene 1: the store.**

**RUMI:** "Three hundred and eleven kinds. I keep them cold, I keep them dark, and I know the name of every one."
**RUMI:** "Four are gone from the ground. If they are not in a basket somewhere, they are gone."
> ► **"Where might they be?"** — **RUMI:** "A cellar. A grandmother's trunk."
> ► **"Why four?"** — **RUMI:** "Because they belong to people."
> ► **"I'll ask."** — **RUMI:** "Listen first. Carry second."

**Scene 2: the cellars.** Four short visits. An old widow's cellar holds *the Weeping Eye,* her late husband's pick. A boy's trunk holds *the Red Tongue.* A fisher's wife keeps *the Moon Knuckle* in a pot. A family of runners kept *the Little Condor* in a pouch.

**WIDOW:** "He planted them when we were married. He said they would last longer than we did."
> ► **"I will plant them back."** — She sets the tubers in your hands.
> ► **"May I hear about him?"** — She talks for an hour.
> ► **"May I buy them?"** — **WIDOW:** "No. Take them."

**Scene 3: the planting.** On a new terrace above the old, Rumi, the player and the four families plant the four kinds in a single row.

**RUMI:** "Each in its own row. Each by its own people."
> ► **"Plant the Weeping Eye first."** — The widow kneels.
> ► **"Plant the Little Condor first."** — The runners cheer.
> ► **"Let the families choose."** — A friendly argument.

**Scene 4: the seed cord.** Rumi ties four small knots to the seed-store's great cord, one for each kind.

**RUMI:** "They are on the cord. They are back."

**Scene 5: the debts.** At the last cellar, the fisher's wife will not give the Moon Knuckle without a favour, and the player is asked for a small, odd job: to read out the names on a family cord, so the children can hear them.

**FISHER'S WIFE:** "They don't know their great-grandfather had a name. They think he was just a man who planted things."
> ► **"Read all of them."** — The children go quiet at the fourth name.
> ► **"Read the funny one first."** — A great-aunt called Teeth. They laugh.
> ► **"Let the children try."** — They fumble, and she hugs them.

**RUMI (later):** "That is the real seed. The tuber is only the part you can put in the ground."
*No price is paid. The favour is the price.*

**Scene 6: the sack.** At the end, Rumi gives the player a small sack of her own to carry back down the mountain, and a list of seven more lost kinds.

**RUMI:** "These are only guesses. Names I have heard in stories. If you ever pass a cellar..."
**RUMI:** "A hundred kinds is a number I say to children. The truth is three hundred and eleven, and some of them are only a sound."
> ► **"I'll keep an ear out."** — She smiles as if you have given her a gift.
> ► **"Read me the list."** — Seven names, each with a small story.
> ► **"Keep the sack for yourself."** — **RUMI:** "No. It is for planting. Plant it somewhere that will have it."

**Outcomes and receipt.**
- Four lost kinds return. The families keep their pride in the stories. Paying for seed would have been refused.
- **Receipt:** a small bag of mixed seed-potatoes, the player's own to plant.

<!-- quest
id: qst_apu_hundred_potatoes
title: A Hundred Kinds of Potato
rank: A
type: Gathering
giver: npc_rumi_cusihuaman
region: reg_apu_highlands
level: 134
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: apu_potatoes_done
summary: A fallen terrace took the only field of four potato kinds, and four families may still hold a few tubers in their cellars.
objectives:
  talk npc_rumi_cusihuaman
  collect apu_heirloom_seed_potato 4
  choice plant_widow_runners_or_families
-->

---

## 7. Work Day at the Falling Terrace

*A · Defense · the Condor terrace · giver Steward Yachay Apazaqolla*

**The short version.** A work day is called to shore up a terrace the giant's tread has cracked. Four hundred people have come. The wall may not last until noon.

**What is really going on.** The danger is not the giant but the *workers:* a crowd on a loose slope. The player defends the site from rockfall, rushing, and panic, and chooses how to pace the work.

**Scene 1: the call.**

**YACHAY:** "Four hundred. They brought children, soup and drums."
**YACHAY:** "The wall is cracked at the second course. If a hundred pull at once it comes down on all of us."
> ► **"Stagger the lines."** — **YACHAY:** "Slower. Safer. They will grumble."
> ► **"Clear the slope above."** — **YACHAY:** "Scree. Yes."
> ► **"Set watchers."** — **YACHAY:** "On the cliff. I have six."

**Scene 2: the work.** Drums, singing, hands passing stones along a human chain. A tremor rolls through the hillside. The drums stop. The chain does not.

**FOREMAN:** "Hold! Hold the stone!"
*Gameplay: defend the terrace from rockfall and a stampede of spooked llamas; no enemies.*
> ► **"Shout the rhythm."** — The drums pick up.
> ► **"Clear the children."** — A calm retreat.
> ► **"Hold the cracked course."** — Sweat, grit, grunting.

**Scene 3: the noon.** The wall holds. The soup is served on the ground. Nobody has been hurt.

**YACHAY:** "I promised a feast. I did not promise it would be on this side of the wall."

**Scene 4: the feast.** On the new second course, the villagers eat, drink and sing. The player is given a bowl.

**ELDER:** "A work day is a feast. A feast is a wall."

**Scene 5: the drums.** After the feast, with the sun low, a crack runs a hand's width along the third course. Nobody shouts. The foreman simply lifts a drum and begins a slow beat, and the four hundred stop what they are doing and file off the slope in time.

**YACHAY:** "We practise it every work day. Nobody knows that it is a drill. We call it the tune for going home."
**CHILD:** "Is the wall dying?"
**YACHAY:** "It is old. We are young. We will come back."
> ► **"Stay and watch the crack."** — It does not widen. Not tonight.
> ► **"Lead the stragglers down."** — An old man complains, then thanks you.
> ► **"Carry the soup pots."** — Yachay stares at you, then laughs for the first time that day.

*The terrace holds for the night. The quest ends before anyone learns whether it holds for the winter.*

**Scene 6: the night after.** The soup pots are scraped, the drums wrapped in cloth. The steward sits alone on the wall, staring at the crack.

**YACHAY:** "I counted four hundred and eleven. Four hundred and eleven names, and I never lose track."
**YACHAY:** "If I called for a work day tomorrow, I think they would come again."
> ► **"They would."** — **YACHAY:** "That is the whole city. That is the whole point."
> ► **"Rest."** — **YACHAY:** "The wall does not rest. Why should I?"
> ► **"I will take the watch."** — He hands you a blanket and a bowl.

**Outcomes and receipt.**
- The terrace is shored, not saved; it will need another work day. The siege is not touched.
- **Receipt:** a stone from the second course, chalked with the date and every worker's mark.

<!-- quest
id: qst_apu_work_day
title: Work Day at the Falling Terrace
rank: A
type: Defense
giver: npc_yachay_apazaqolla
region: reg_apu_highlands
level: 140
act: 4
requires_rank: A
reward: 34000 | 1700 | 148000
sets: apu_work_day_done
summary: Four hundred villagers gather to shore up a cracked terrace, and the player must keep the work site safe.
objectives:
  talk npc_yachay_apazaqolla
  defend apu_condor_terrace
  choice stagger_clear_or_hold
-->

---

## 8. The Girl Who Came Back for the Knots

*A · OddJob · the Cord House annex · giver Illari Ticapampa*

**The short version.** Illari left for the coast and came back. The only cord-keeper in her valley says she has no time to teach.

**What is really going on.** The cord-keeper is *afraid:* if she teaches and the student fails, the valley's cords die with them both. She needs the student to prove herself before the lesson begins.

**Scene 1: the doorway.**

**ILLARI:** "I was on the coast four years. I counted fish. I counted coin. I never counted a knot."
**ILLARI:** "I came home to learn the cords. The keeper shut the door."
> ► **"Why?"** — **ILLARI:** "She says she is too old."
> ► **"Let me speak to her."** — **ILLARI:** "Please."
> ► **"What can you read?"** — **ILLARI:** "My family's. My grandmother's thread. Nothing else."

**Scene 2: the keeper.** In a dim room, an old keeper repairs a cord with a needle.

**KEEPER:** "If I teach her and she forgets, it dies with her. If I do not teach her, it dies with me. Both are bad."
> ► **"Then teach her one cord."** — **KEEPER:** "...One."
> ► **"She will not forget."** — **KEEPER:** "You cannot know that."
> ► **"I will bring her cords to practise."** — **KEEPER:** "Bring the plainest."

**Scene 3: the lesson.** Illari reads her grandmother's cord aloud, fumbling. The keeper listens with her eyes shut.

**ILLARI:** "...Four, one, four. A field. A name. A debt."
**KEEPER:** "A debt?"
**ILLARI:** "Of three days' labour. To the next terrace."
**KEEPER:** (opens eyes) "Again."
> ► **"Let her try again."** — She does.
> ► **"Correct the debt."** — The keeper looks at you sharply.
> ► **"Say nothing."** — The lesson continues.

**Scene 4: the first knot.** The keeper hands Illari a short cord and a needle.

**KEEPER:** "Tie your name."

**Scene 5: the second reading.** A month later, Illari returns the favour. She asks the player to listen to her read a cord that is hers alone: the one tied by her mother before she left for the coast.

**ILLARI:** "I could not read it before. I think I was afraid to."
**ILLARI:** "'Go. Come back. The field will keep a place.' That is all it says. That is everything."
> ► **"It is a good cord."** — She laughs and wipes her face on a sleeve.
> ► **"Did you tie an answer?"** — **ILLARI:** "Yes. 'I came back.'"
> ► **"Read it again."** — She does, slowly, and her voice does not shake.

**KEEPER:** "You need the cords. The cords need you. Neither of you is in a hurry."
*The keeper has begun to teach a second child. Word travels.*

**Scene 6: the valley hears.** By the next market day, other families have come to the keeper's door, asking whether she has room for one more. She looks at the player with a very mild, very dry complaint.

**KEEPER:** "You did this."
**ILLARI:** "I did not know there were so many of us."
**KEEPER:** "There are fewer than you think. But more than I let myself count."
> ► **"Teach them in a group."** — **KEEPER:** "A class. In my house. With *my* tea."
> ► **"Take only the best."** — **KEEPER:** "I will take the stubborn."
> ► **"Let Illari help."** — Illari straightens and tries not to look pleased.

**Outcomes and receipt.**
- Illari becomes a cord-keeper's apprentice. If the player corrected her reading, the keeper is offended; Illari learns it anyway.
- **Receipt:** a pocket-size cord with the player's name tied in Illari's first, wobbling knot.

<!-- quest
id: qst_apu_knots_return
title: The Girl Who Came Back for the Knots
rank: A
type: OddJob
giver: npc_illari_ticapampa
region: reg_apu_highlands
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: apu_knots_done
summary: A girl back from the coast wants to learn the cords from a keeper who is afraid to teach her.
objectives:
  talk npc_illari_ticapampa
  reach apu_cord_annex_room
  choice teach_one_trust_or_practise
-->

---

## 9. The Mason's Mark

*S · Investigation · the oldest walls · giver Mason-Elder Atoq Huamancho*

**The short version.** Atoq can tell the builder of a wall by its fit. In the oldest walls he has found a fit that matches no family, and it matches the places the giant has *not* broken.

**What is really going on.** Some walls the giant spares and some he breaks. The spared ones carry a tiny fingerprint, a thumb-press on the inside face of each stone. The player maps them. The quest does not say why he spares them, or that the mark is his.

**Scene 1: the wall.**

**ATOQ:** "I have read walls for sixty years. This one has no builder. Look, no gaps. A blade will not slip between."
**ATOQ:** "My teacher said, 'a wall with no builder is a wall made before families.' I did not believe him."
> ► **"Where are the other walls?"** — **ATOQ:** "Everywhere. Under the patches."
> ► **"What do you want?"** — **ATOQ:** "A map. Which stones he leaves. Which he breaks."
> ► **"I'll walk them."** — **ATOQ:** "Take a lamp. And be gentle with the old stones."

**Scene 2: the walk.** Across three terrace cities, the player marks walls: *patched* and *whole.* Nine walls in ten that the giant has broken were patched. Nine in ten he has left standing have no patch.

**MASON (young):** "He breaks the stones we put in. He leaves the ones he put in."
> ► **"Map the patches."** — Chalk and cord.
> ► **"Find a thumb-mark."** — On the inside face of an old stone, a hollow the size of a man's thumb, three times too large.
> ► **"Ask the families."** — Silence and a rustle.

**Scene 3: the hall.** In the masons' hall, Atoq lays the map across the floor. The masons read it in silence.

**MASON-ELDER:** "If we take out the patches..."
**ATOQ:** "He will leave the wall."
**MASON-ELDER:** "If we take out the patches, the field falls."
> ► **"Bring it to the lord."** — Heavy faces.
> ► **"Keep it among masons."** — Atoq nods slowly.
> ► **"Test one wall."** — **ATOQ:** "A test wall. Yes."

**Scene 4: the test.** On a hillside, a patch is pulled from an old wall and replaced with a fitted stone made by Atoq's own hand. For three nights the village waits. Nothing happens.

**ATOQ:** "Perhaps he did not see."
**ATOQ:** "Or perhaps he is thinking."

**Scene 5: the quiet afterwards.** Atoq will not discuss the thumb-hollow with the guild. He discusses it with the player, one evening, at the foot of a wall that has never broken.

**ATOQ:** "I was afraid of finding that the old walls were not ours. I am more afraid that they were, and that we forgot."
**ATOQ:** "A mason is not meant to be sentimental about a stone."
> ► **"You are, though."** — **ATOQ:** "Yes. Forty years of it."
> ► **"Whoever made them wanted them to last."** — **ATOQ:** "That is all I know about them."
> ► **"Do you think he sees the patches?"** — **ATOQ:** "I think he sees *everything.* I do not think he has said so."

*The quest never states who made the old walls. It states only which ones stand.*

**Outcomes and receipt.**
- The map goes to the masons' guild. What Ukhu-Tal thinks of the test wall is left open; the quest ends before the giant does anything.
- **Receipt:** a rubbing of the thumb-hollow on paper, "the First Mason's thumb," in the Journal.
- **Canon-safe:** the quest does not state the mark is Ukhu-Tal's, does not meet him, and does not decide whether he is angry or proud.

<!-- quest
id: qst_apu_masons_mark
title: The Mason's Mark
rank: S
type: Investigation
giver: npc_atoq_huamancho
region: reg_apu_highlands
level: 168
act: 5
requires_rank: S
reward: 68000 | 3000 | 315000
sets: apu_masons_mark_done
summary: The oldest walls have no builder, and the giant spares them. A mason-elder asks the player to map which stones he leaves and which he breaks.
objectives:
  talk npc_atoq_huamancho
  reach apu_oldest_walls
  choice map_thumb_or_test
-->

---

## 10. The Cord That Ends in a Gap

*S · Exploration · the Giant's Bed · giver Cord-Keeper Sisa Condoriqui*

**The short version.** Sisa carries an old cord that stops mid-sentence. She believes its last knots are kept at the summit, on the Giant's Bed, where nobody goes.

**What is really going on.** *Nothing is explained.* On the flat summit the player finds a smooth, body-shaped hollow and a single stone peg with a short cord tied to it, ending in the *same* gap. The quest ends on the gap.

**Scene 1: the shrine.**

**SISA:** "This cord has been in my family for eleven generations. It stops. Not frayed. Not cut. It stops."
**SISA:** "My mother said the end was left on the Bed. I have not had the courage."
> ► **"Why now?"** — **SISA:** "Because he is awake."
> ► **"What is it?"** — **SISA:** "A name, perhaps. The one he forgot."
> ► **"I'll go."** — **SISA:** "Bring coca for the apu. And do not step on the hollow."

**Scene 2: the climb.** A cold, silent ascent through snow and bare grey rock. The player passes a shrine of stacked stones, wind-scoured, and a heap of old offerings.

**ENV (journal):** *The path is worn smooth by feet. Nobody has been this way for a long time. No: *somebody* has, in the last year, and left a bowl.*
> ► **"Leave an offering."** — Coca, cloth, a few drops of beer.
> ► **"Keep going."** — Wind.
> ► **"Look back."** — The terraces, a thousand steps below, glitter like a stair of mirrors.

**Scene 3: the Bed.** On the summit lies a flat, enormous hollow, the shape of a lying body, polished smooth. At its head, a single stone peg, and on the peg a short grey cord, tied.

**SISA'S VOICE (in memory):** *"It ends where it ends."*
*The player takes the cord to the keeper's own, laid side by side. They end in the same gap.*
> ► **"Read it."** — Sisa reads, and stops.
> ► **"Tie them together."** — **SISA:** "No. I will not make an end he did not."
> ► **"Leave it on the peg."** — **SISA:** "Yes."

**Scene 4: the descent.** At the bottom, Sisa sits long over the two cords, thumbs on the gap.

**SISA:** "If someone can read a gap, they can read the whole cord."
**SISA:** "I do not know if I am afraid of that."

**Scene 5: the cold hour.** On the way down the player and Sisa shelter in a stone hut a few hundred steps below the Bed, and the keeper tells the story her mother told her, which has no ending either.

**SISA:** "There was a mason who laid every stone with his hands. When he finished, he lay down. A cord was tied to his thumb, so he would not forget the work."
**SISA:** "Then the story stops."
> ► **"Who was the mason?"** — **SISA:** "A mason. That is all my mother said."
> ► **"Did he wake?"** — **SISA:** "Ask the walls."
> ► **"What was the cord for?"** — **SISA:** "So someone would find him. I think."

*No answer is given. Outside, the wind lowers, and for a moment the whole mountain seems to listen.*

**Outcomes and receipt.**
- The two cords are laid in the Cord House shelf, side by side, unfinished. The gap is a question.
- **Receipt:** a small sketch of two cords ending in the same gap, in the Journal.
- **Canon-safe:** a pure seed. It does not explain the gap, name the giant's forgotten name or say who tied the peg's cord.

<!-- quest
id: qst_apu_cord_gap
title: The Cord That Ends in a Gap
rank: S
type: Exploration
giver: npc_sisa_condoriqui
region: reg_apu_highlands
level: 174
act: 5
requires_rank: S
reward: 75000 | 3200 | 340000
sets: apu_cord_gap_done
summary: A cord-keeper's family cord stops mid-sentence. The other end is said to be on the Giant's Bed.
objectives:
  talk npc_sisa_condoriqui
  reach apu_giants_bed_summit
  choice read_tie_or_leave
-->
