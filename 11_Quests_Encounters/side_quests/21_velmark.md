# 11e-21 — Velmark, the White Duchies: Ten Side Quests (draft)

> *"The first duke paid the land a tithe for its stones. His heirs stopped paying."*
> — Gazetteer, Velmark

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light.

**Region:** `reg_velmark` (the white ducal towns, the Drowned Quarries, the Foundation Stone, the Grand Ducal Court, the farms between). **Rank band:** C–B. **Tone:** good manners over a cracking floor. Everyone is polite, everyone has a ledger, and the ground under the ledgers has started to move. Warm where people stop being tidy and are simply kind.

**Placement notes.**
- **The Tithe Colossus** is the region's Tyrant. It is walking toward the Foundation Stone and towns crack where it passes. No quest here kills it or stops it; quests 6-10 change how the duchies *prepare* and what they admit, and one (quest 8) lets the player hear what the stone does when an offering is laid.
- Velmarkers keep the day-gods soberly. **Every house has a tithe-box by the door**, collected every Kaelsday. The old **stone offering** to the land, laid at the Foundation Stone each year, was abolished a generation ago to save money; some people still do it in private.
- Clerks, notaries and bankers are respected; quarry-workers are the underclass in the shadow of the white towns. The **Grand Ducal Court** is trusted across the world.
- Earlier pattern quests in this region: *The Tithe-Hound* (contract) and *The Cart That Pulled Itself* (stranger). Neither is a prerequisite for anything here.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Kaelsday Round | C | OddJob | Clerk Hobart Pellam | Comic-warm: a punctual man, a cracked town |
| 2 | Down in the Gallery | C | Exploration | Brenna Stoke | Tender: a family held up by a golem |
| 3 | The Ledger in the Walls | C | Investigation | Journeyman Corbin Thaxe | Mystery: the cracks add up |
| 4 | A Long Night at Oakes Farm | C | Defense | Farmer Tamsyn Oakes | Action and comedy: pitchforks and a goose |
| 5 | Condemned, With Regret | C | Faction | Notary Isolde Fairweather | Dilemma: a cracked house and a calm lender |
| 6 | The Eleventh Clause | B | Investigation | Archivist Ottoline Pyke | Mystery: the contract nobody read |
| 7 | The Quiet Petition | B | Faction | Seneschal Percival Ostrander | Dilemma: stop it, but admit nothing |
| 8 | The Last Mason of the Old Rite | B | Hidden | Gideon Marl | Tender: an offering by lamplight |
| 9 | Hollin Cross Pays Its Tithe | B | Exploration | Keeper Aldith Crewe | Sad and strange: the town in the cellar |
| 10 | The Order of Evacuation | B | Defense | Marshal Cordelia Haverlock | Action and dilemma: who walks out last |

## Cast

<!-- npc
id: npc_clerk_hobart_pellam
name: Clerk Hobart Pellam
tier: townsfolk
race: Human
region: reg_velmark
settlement: Ashgrove
role: Tithe-collector for the ward
backstory: A precise, fretful tithe-clerk who has never missed a Kaelsday round in thirty-one years and does not intend to start because the street is cracking.
-->
<!-- npc
id: npc_brenna_stoke
name: Brenna Stoke
tier: townsfolk
race: Human
region: reg_velmark
settlement: Drowned Quarries, Quarrymen's Row
role: Quarry-worker's wife
backstory: A broad, tired woman whose husband and two children vanished when their cellar dropped into the old workings, and whom the ducal office told, politely, that it was not the duchy's concern.
-->
<!-- npc
id: npc_corbin_thaxe
name: Journeyman Corbin Thaxe
tier: major
race: Human
region: reg_velmark
settlement: Ashgrove
role: Journeyman mason
backstory: A young, cautious mason who has been mapping cracks in the town walls for a month and has stopped telling anyone what the map looks like.
-->
<!-- npc
id: npc_tamsyn_oakes
name: Farmer Tamsyn Oakes
tier: townsfolk
race: Human
region: reg_velmark
settlement: Oakes Farm
role: Wheat farmer
backstory: A square, cheerful farmer who sleeps with a hay-fork beside the bed and has named every goose after a duke.
-->
<!-- npc
id: npc_notary_isolde_fairweather
name: Notary Isolde Fairweather
tier: major
race: Human
region: reg_velmark
settlement: Ashgrove
role: Notary and clerk of the lending-house
backstory: A composed notary who believes the law is the kindest thing people have invented, and who is about to find out what it costs.
-->
<!-- npc
id: npc_widow_garrow
name: Widow Philippa Garrow
tier: townsfolk
race: Human
region: reg_velmark
settlement: Ashgrove
role: Owner of a cracked terraced house
backstory: An elderly widow who has paid her mortgage punctually for forty years on a house that is now leaning, and does not understand why that makes it the bank's.
-->
<!-- npc
id: npc_ottoline_pyke
name: Archivist Ottoline Pyke
tier: major
race: Human
region: reg_velmark
settlement: Grand Ducal Court
role: Junior archivist of the Court
backstory: A bookish, underpaid archivist who has found the original tithe contract in a sealed box and is quietly frightened by how short it is.
-->
<!-- npc
id: npc_seneschal_ostrander
name: Seneschal Percival Ostrander
tier: major
race: Human
region: reg_velmark
settlement: Grand Ducal Court
role: Seneschal to the Grand Duke
backstory: A smooth, tireless official who is paid to make problems disappear without anyone being to blame for them.
-->
<!-- npc
id: npc_banker_lucan_ferris
name: Banker Lucan Ferris
tier: major
race: Human
region: reg_velmark
settlement: Grand Ducal Court
role: Guild banker and councillor
backstory: A courteous banker who funds half the duchies' defences and has never once been seen to raise his voice or open his hand.
-->
<!-- npc
id: npc_gideon_marl
name: Old Gideon Marl
tier: major
race: Human
region: reg_velmark
settlement: Ashgrove
role: Retired stonemason
backstory: An old mason with white dust in his eyebrows who still lays a small stone at the Foundation Stone each autumn, as his father did, and has stopped explaining why.
-->
<!-- npc
id: npc_aldith_crewe
name: Keeper Aldith Crewe
tier: major
race: Human
region: reg_velmark
settlement: Hollin Cross, the drowned town
role: Keeper of a collapsed town's memory
backstory: A thin, stubborn woman descended from the people of Hollin Cross, who rings the surviving bell once a year over a quarry-lake and has told no ducal office why.
-->
<!-- npc
id: npc_marshal_haverlock
name: Marshal Cordelia Haverlock
tier: major
race: Human
region: reg_velmark
settlement: Brightstone
role: Ducal marshal in charge of evacuation
backstory: A brisk, honest marshal who has been handed a list of who leaves a doomed town first, and has just read who is at the bottom of it.
-->
<!-- npc
id: npc_foreman_rudd_ketteridge
name: Foreman Rudd Ketteridge
tier: townsfolk
race: Human
region: reg_velmark
settlement: Brightstone, Quarrymen's Row
role: Quarry foreman
backstory: A rough, patient foreman who speaks for four hundred quarry-workers and has learned to ask for things as if they were favours.
-->

---

## 1. The Kaelsday Round

*C · OddJob · Ashgrove · giver Clerk Hobart Pellam*

**The short version.** The street is cracking, half the neighbours have gone to their cousins' farms, and Clerk Pellam still intends to collect every tithe-box in the ward before sundown, in order, with receipts. He needs someone to carry the sack and keep him from the open cracks.

**What is really going on.** The tithe-boxes are not full of coin. They are full of small things: a pebble, a button, a folded apology, a half a pie. Since the first crack, people have been leaving *a stone* in the box instead of money, unasked and unexplained. Pellam has been writing them off as "irregular receipts" and cannot decide what that means.

**Scene 1: the doorstep.**

**PELLAM:** "It is Kaelsday. Kaelsday has a *round.* The round does not care about subsidence."
**PELLAM:** "Sixty-one boxes, ward four. I have never missed one. I once did the round with a *fever.*"
**PELLAM:** "You will carry the sack. You will not *comment* on the sack."
> ► **"The street's cracking."** — **PELLAM:** "Then we shall *step over it,* in order."
> ► **"I'll carry it."** — **PELLAM:** "Splendid. Do not drop the pie."
> ► **"What is in the sack?"** — **PELLAM:** "Receipts. And, regrettably, pie."

**Scene 2: the round.** House after house. Box after box. A pebble. A button. A child's drawing of a very tall stone man with a smiling mouth. A note: *"For whoever is hungry. Please share with the one underneath."*

**PELLAM:** (holding the pebble up to the light) "This is not a *tithe.* It is not *legal tender.* It is, I think, a... *gesture.*"
**NEIGHBOUR (through a window):** "Is that the tithe-man? Tell him I put the good one in the red box."
> ► **"They want to give something."** — **PELLAM:** "People are not *permitted* to want. We have *forms.*"
> ► **"Log them as received."** — **PELLAM:** "Under what heading?"
> ► **"Keep them safe."** — **PELLAM:** "...Safe. Yes. That is a *category.*"

**Scene 3: the last box.** Sixty-one. It stands in the lee of a wall that has split from roof to cellar. A single white stone in the box, so clean it has been washed.

**PELLAM:** "Sixty-one. I have a *sack of pebbles,* player. A sack. Of *pebbles.* What does one *do?*"
> ► **"Enter them as 'Sundry stone, with thanks.'"** — Pellam writes it, slowly, and then underlines it.
> ► **"Lay them at the ward gate."** — Pellam hesitates, then carries the heaviest himself.
> ► **"Ask the neighbours to bring more."** — By dusk the gate has a cairn.

**Scene 4: the receipt.** Pellam stamps the last page of the round.

**PELLAM:** "Ward four, Kaelsday. Sixty-one boxes. Collected in full. Nobody has ever *asked* me what I thought of the tithe."
**PELLAM:** "I think it was meant to be a *thing you give.* Not a thing you *pay.*"

**Outcomes and receipt.**
- The round is done, in order, and the receipts are filed under the new heading Pellam invented. Whichever choice the player made, the ward gate becomes a small, patient cairn.
- **Receipt:** a cairn of washed pebbles at the ward gate; a new line in the ward ledger reading *"Sundry stone, with thanks."*

<!-- quest
id: qst_vel_kaelsday_round
title: The Kaelsday Round
rank: C
type: OddJob
giver: npc_clerk_hobart_pellam
region: reg_velmark
level: 58
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: vel_kaelsday_round_done
summary: A tithe-clerk insists on collecting every box in a cracking ward and finds that people have been leaving stones instead of coin.
objectives:
  talk npc_clerk_hobart_pellam
  reach ashgrove_ward_four_tithe_boxes 3
  choice log_gate_or_cairn
-->

---

## 2. Down in the Gallery

*C · Exploration · Quarrymen's Row, the Drowned Quarries · giver Brenna Stoke*

**The short version.** Brenna's husband and two children went down with their cellar into the old workings six days ago. The ducal office has sent a letter of regret. She asks the player to go down and look.

**What is really going on.** They are alive. A small stone golem, one of the first things to climb out of the quarries, has wedged itself across a gallery roof and is holding the ceiling up over them. It is not attacking. It will not move, because if it moves the gallery falls.

**Scene 1: the row.**

**BRENNA:** "I'm not asking the duke. I asked the duke. The duke wrote back that it was 'regrettable but not a ducal matter.'"
**BRENNA:** "I am asking *you.* You can go down."
**BRENNA:** "Bring the little one's blanket. She'll want it."
> ► **"I'll go."** — **BRENNA:** "Mind the third step. It isn't there."
> ► **"What do you think happened?"** — **BRENNA:** "I think the floor was thinner than anyone said."
> ► **"What if they're gone?"** — **BRENNA:** "Then I'll know. I'd rather know."

**Scene 2: the descent.** Ladders, planks, a cold gallery cut by hand three generations ago. Water drips. Far off, a child's voice counts *thirty-one, thirty-two, thirty-three.*

**FATHER (Hal Stoke, from the dark):** "Don't come in fast! He's holding it!"
**CHILD:** "He doesn't *say* anything. But he *looks* when we sing."
*A figure of white stone, squat as a barrel, braced across the roof beam, its shoulders trembling. Its face has no mouth, only a shallow groove where one might be.*

**Scene 3: the problem.** The family can walk out. The golem cannot move without bringing the roof down.

> ► **"Prop the roof, then lead them out."** — A careful job with timber and rope; the golem does not move until the last beam is in.
> ► **"Talk to it."** — The player speaks plainly; the golem's head tilts, and a hand opens.
> ► **"Carry the children out first."** — The fastest way, but the golem sheds a little dust each time they pass.

**CHILD:** "He's not a monster. He held the roof the *whole time.*"
**FATHER:** "I think he thinks we are *his.*"

**Scene 4: the surface.** Brenna waits at the top, hands over her mouth. The little one runs to her. The golem stays below, braced, until the last prop takes the weight, and then it steps back, and sits, and looks at the lantern.

**Outcomes and receipt.**
- The family is out. If the player propped the roof, the golem remains in the gallery as a patient, motionless guardian. If the player talked to it, it follows them to the surface at a distance and stands at the edge of the Row.
- **Receipt:** a stone figure sitting at the edge of Quarrymen's Row, with a child's knitted scarf around its neck. It does not move, and nobody tells it to.

<!-- quest
id: qst_vel_down_in_gallery
title: Down in the Gallery
rank: C
type: Exploration
giver: npc_brenna_stoke
region: reg_velmark
level: 61
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: vel_gallery_family_saved
summary: A quarry-worker's family is alive under a collapsed cellar, held up by a golem that will not let go of the roof.
objectives:
  talk npc_brenna_stoke
  reach drowned_quarry_third_gallery
  choice prop_talk_or_carry
-->

---

## 3. The Ledger in the Walls

*C · Investigation · Ashgrove · giver Journeyman Corbin Thaxe*

**The short version.** A young mason has been mapping the cracks in Ashgrove. He has stopped sleeping. He asks the player to check his sums, because the cracks follow a pattern, and he does not like what it is.

**What is really going on.** Every cracked block carries a mason's mark that says which quarry it came from. The cracks are not random: they run from block to block in order, quarry by quarry, and each crack's length is proportional to how many stones that quarry gave the town. It reads, if you want it to, like an account. Nobody wrote it. It is not clear that anyone had to.

**Scene 1: the lean-to.**

**CORBIN:** "I'm not mad. I want to say that first."
**CORBIN:** "Look. Every block has a mark. The cracks go *along* the marks. The long cracks are on the quarries that gave the *most.*"
**CORBIN:** "It's a *tally.* I think the town is a *tally.*"
> ► **"Show me the map."** — **CORBIN:** "Please don't laugh."
> ► **"Who else has seen it?"** — **CORBIN:** "My master. He told me to burn it."
> ► **"Let's check."** — **CORBIN:** "Thank you. I need someone else to count."

**Scene 2: the count.** Three days of slow work: matching marks, measuring cracks, walking the old quarry roads. A retired quarry-master confirms which pits gave what. An old surveyor's chart in the Court annex gives a fourth set of numbers.

**Evidence.**
- **The marks** match the Court's quarry rolls to the last block.
- **The cracks** are longest where the stone was taken *without a tithe record.*
- **The total** of all cracks in Ashgrove comes within three stones of the town's *unpaid* count.
- **One crack** stops, neatly, at a doorway where a family has always left a pebble in the box.

**QUARRY-MASTER (old Dermot Aldwin):** "I never kept a tithe. Nobody did. After my grandfather's day it was *wasteful.*"

**Scene 3: the argument.** Corbin's master wants the map burned. Corbin wants it shown.

> ► **"Show the Court."** — Corbin submits the map; the Court receives it with great politeness and files it.
> ► **"Keep it quiet."** — The map stays between you; Corbin is relieved, and ashamed of being relieved.
> ► **"Put it where people can see it."** — Corbin paints the tally on the wall of the guildhall in white lime.

**CORBIN:** "It isn't a threat. It's an *invoice.*"
**MASTER MASON:** "It's a rumour with measurements."

**Outcomes and receipt.**
- The map is known, one way or another. Whatever it means is left unsaid: the player decides how loud to be, and whether the Court hears it first.
- **Receipt:** the tally map, drawn in lime on a guildhall wall or hung in the Court annex; a single white pebble set on the doorstep where the crack stopped.

<!-- quest
id: qst_vel_ledger_walls
title: The Ledger in the Walls
rank: C
type: Investigation
giver: npc_corbin_thaxe
region: reg_velmark
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: vel_ledger_walls_done
summary: The cracks in Ashgrove run block to block by quarry, and their lengths add up to the town's unpaid tithe.
objectives:
  talk npc_corbin_thaxe
  reach ashgrove_court_annex_quarry_rolls
  choice court_quiet_or_wall
-->

---

## 4. A Long Night at Oakes Farm

*C · Defense · Oakes Farm · giver Farmer Tamsyn Oakes*

**The short version.** Stone-gnawers have been crawling up out of the old quarry next door and eating the wheat, the fences and, once, a wheelbarrow. Tamsyn has an idea. It involves geese.

**What is really going on.** The gnawers are not hunting. They are following the grinding in the ground, and they are frightened of it. They come up toward the farm lamps because lamps are the opposite of the dark. A farm that stays lit and loud is a place they can mill about in without hurting anyone. A farm that tries to drive them off in the dark makes them panic.

**Scene 1: the kitchen.**

**TAMSYN:** "Right. Seven of the buggers last night. They ate the *gate.*"
**TAMSYN:** "I've the dogs, a hay-fork each, and *Duke Bertrand.* He bites. He's a goose."
**TAMSYN:** "I'd like you here at dusk. I'd like you to be *tactical.*"
> ► **"What do they eat?"** — **TAMSYN:** "Stone. And wheat when the stone's been dug up, which is *rude.*"
> ► **"Why a goose?"** — **TAMSYN:** "He's *very* loud."
> ► **"I'll be tactical."** — **TAMSYN:** "Marvellous. I've made a flask."

**Scene 2: the dusk watch.** Lamps along the fence. The farmhands settle with their tools. Out in the field, small grey shapes rise and sink like loaves.

**TAMSYN:** "That one's *Duchess Mabel.* The grey one. She's *quite* brave."
**FARMHAND (young Pip Oakes):** "Ma, they're not coming at us."
**TAMSYN:** "They never *do,* love. They just *arrive.*"

**Scene 3: the night.** At the third bell, the ground grumbles. Not the gnawers: something far below. The creatures rush the fence in a sudden, panicked tide, all at once.

> ► **"Hold the fence."** — A hard, loud hour of pitchforks, lantern-swinging and a goose going very fast.
> ► **"Open the gate and let them through."** — The tide parts around the farm and pours into the empty meadow.
> ► **"Light every lamp in the barn."** — The gnawers stop, as if surprised, and gather in the glow like moths.

**TAMSYN:** "They're not *attacking.* They're *huddling.*"
**DUKE BERTRAND (the goose):** (a long, outraged honk)

**Scene 4: the dawn.** The fence is chewed but standing. The wheat is half gone. A dozen gnawers sit in the meadow, steaming faintly in the cold.

**TAMSYN:** "I've never been so exhausted. Or so *warm.*"
**TAMSYN:** "Next time I'll leave the lamps *on.*"

**Outcomes and receipt.**
- The farm holds. If the player fought the tide, the gnawers scatter. If the player let them pass or lit the barn, they linger in the meadow until morning and then wander back to the quarry. Either way the farm learns that lamps work better than pitchforks.
- **Receipt:** a row of lamps on posts along the farm fence, left burning; a plaque in the barn reading *"Duke Bertrand, first goose of the line."*

<!-- quest
id: qst_vel_long_night_oakes
title: A Long Night at Oakes Farm
rank: C
type: Defense
giver: npc_tamsyn_oakes
region: reg_velmark
level: 67
act: 3
requires_rank: C
reward: 4100 | 230 | 15500
sets: vel_oakes_farm_held
summary: Frightened stone-gnawers crowd toward a wheat farm, and a farmer's whole plan is a goose.
objectives:
  talk npc_tamsyn_oakes
  defend oakes_farm_fence
  choice hold_open_or_light
-->

---

## 5. Condemned, With Regret

*C · Faction · Ashgrove · giver Notary Isolde Fairweather*

**The short version.** A terraced house on Mill Row has cracked and is leaning. The lending-house must, under its charter, call the loan and seize the property. Notary Fairweather has drawn up the papers, and for the first time in her career she does not want to deliver them.

**What is really going on.** The charter says a "failed building" defaults the loan. The charter does not say who decides a building has failed, and nobody has ever needed it to. The widow who owns the house has paid forty years without missing a month. The lending-house's council is evenly split on whether to enforce the letter.

**Scene 1: the office.**

**ISOLDE:** "It is not that I disagree with the law. It is that the law is *perfectly clear.*"
**ISOLDE:** "Mrs Garrow has paid forty years. The house leans. By Article Nine, it *has failed.*"
**ISOLDE:** "I have come to ask a stranger what I am afraid to ask myself."
> ► **"What does the charter say?"** — **ISOLDE:** "That a failed building defaults the loan."
> ► **"What do you want to do?"** — **ISOLDE:** "Be someone else for an afternoon."
> ► **"Let me see the house."** — **ISOLDE:** "Thank you."

**Scene 2: the house.** A narrow, tidy house, with every cup in place and the front door hung a hand's breadth out of true.

**PHILIPPA GARROW:** "It doesn't *feel* failed. It feels like it's *tired.*"
**PHILIPPA GARROW:** "I've given the lending-house forty years. They've given me a *ledger.* I keep the ledger."
**PHILIPPA GARROW:** "Would you like tea? The kettle *still* sits level."

**Scene 3: the council.** The lending-house council meets in a high white room, with Banker Ferris presiding. The vote is tied. The player is invited to speak as a neutral witness.

> ► **"The house has not failed. It leans. The charter says nothing of leaning."** — A technical reading, but an honest one.
> ► **"The bank should write it off."** — Ferris looks interested, and then politely closes his folder.
> ► **"Offer the widow a place on the new insured list."** — A middle path: the loan stands, but Mrs Garrow is covered by the tithe-box fund.
> ► **"Say nothing, and let Isolde argue."** — The notary speaks for the first time in her own voice.

**FERRIS:** "There is a precedent for flexibility. There is also a precedent for *not.*"
**ISOLDE:** "Then we shall make a *third.*"

**Scene 4: the door.** The widow's front door is rehung, with a brass plate: *"This house has not failed. By order of the council."*

**Outcomes and receipt.**
- The vote goes the widow's way. A narrow "leaning" clause is written into the charter, and a modest fund is set aside for the next cracked house. If the player said nothing, Isolde wins the vote by one, and does not gloat.
- **Receipt:** the brass plate on Mill Row; a new clause in the charter, signed *I. Fairweather.*

<!-- quest
id: qst_vel_condemned_regret
title: Condemned, With Regret
rank: C
type: Faction
giver: npc_notary_isolde_fairweather
region: reg_velmark
level: 70
act: 3
requires_rank: C
reward: 4300 | 240 | 16000
sets: vel_condemned_resolved
summary: A lending-house must call the loan on a leaning house, and the notary asks a stranger to help her decide what the law is for.
objectives:
  talk npc_notary_isolde_fairweather
  talk npc_widow_garrow
  choice leaning_writeoff_fund_or_silence
-->

---

## 6. The Eleventh Clause

*B · Investigation · the Grand Ducal Court · giver Archivist Ottoline Pyke*

**The short version.** A junior archivist has found the original tithe contract between the first duke and the land. It is one page long. It has eleven clauses. Ten are in every history book. The eleventh has been struck from every copy for two hundred years.

**What is really going on.** The eleventh clause is the *how.* The first ten set the amount: one block in ten, returned. The eleventh sets the *form*: the tithe is not owed in coin or in quarried stone, but "in the builder's own hand, laid in witness of the land." It was never meant to be bought off or sent by a clerk. It was meant to be done by a person, in person, at the stone. It was struck when it became inconvenient.

**Scene 1: the reading room.** Ottoline has locked the door.

**OTTOLINE:** "I haven't told my superior. I haven't told anyone. I have been reading it *aloud* to a plant."
**OTTOLINE:** "It is eleven lines. The copies we use have ten."
**OTTOLINE:** "I would like someone to read it who isn't *me,* and say that I'm wrong."
> ► **"Let me read it."** — **OTTOLINE:** "Please. Slowly."
> ► **"Who struck the clause?"** — **OTTOLINE:** "The records say 'for brevity.'"
> ► **"What do you think it means?"** — **OTTOLINE:** "I think it means we've been *paying the wrong way.*"

**Scene 2: the paper trail.** A second copy in a notary's strongbox. A third in the margin of a grand duke's will. The pieces fit, and the clause says: *the tithe shall be laid by the hand that builds, in witness of the land, once in each year; and the land shall answer.*

**OTTOLINE:** "'And the land shall answer.' That's all it says. It doesn't say *how.*"
**OLD CLERK (muttering):** "It answered once, I'm told. I never asked what it said."

**Scene 3: the choice.** The Court's clerks gather. The clause could be read aloud to the Grand Ducal bench, filed quietly with the dukes' private counsel, or copied and sent to every town.

> ► **"Read it in open court."** — The bench is silent. The Grand Duke's seat stays empty.
> ► **"File it with the dukes' counsel."** — The clause is respected in private, and spoken of nowhere.
> ► **"Copy it to every town."** — A hundred scribes work through the night.

**OTTOLINE:** "If the clause is true, the tithe was never a *tax.* It was a *visit.*"

**Outcomes and receipt.**
- The clause is known, and what it means is left for the dukes to argue. Whichever route is taken, Ottoline's name is not struck from the record.
- **Receipt:** the eleventh clause restored to the master copy in the Court, in a different hand; a small bench in the archive with a plaque, *"For those who read to the end."*

<!-- quest
id: qst_vel_eleventh_clause
title: The Eleventh Clause
rank: B
type: Investigation
giver: npc_ottoline_pyke
region: reg_velmark
level: 90
act: 4
requires_rank: B
requires_quests: qst_vel_ledger_walls
reward: 10500 | 620 | 46000
sets: vel_eleventh_clause_found
summary: The original tithe contract has an eleventh clause, struck from every copy, that says how the tithe was supposed to be paid.
objectives:
  talk npc_ottoline_pyke
  reach grand_ducal_court_archive_strongbox
  choice open_court_counsel_or_every_town
-->

---

## 7. The Quiet Petition

*B · Faction · the Grand Ducal Court · giver Seneschal Percival Ostrander*

**The short version.** The Grand Duke wants the Colossus stopped, without the duchies admitting they owe it anything. The Seneschal needs a sworn petition to the Guild of Guardians, worded so that no fault attaches to anyone. The player is asked to carry it and to sign as witness.

**What is really going on.** The petition is perfectly polite. It is also a legal shield: it describes the Colossus as a "natural calamity of unknown origin," which would exempt the dukes from claims by the quarry-families and the towns. The guilds that fund the defence, led by Banker Ferris, will only release gold if the wording is left as it is.

**Scene 1: the antechamber.**

**OSTRANDER:** "A calamity, nothing more. No fault, no cause, no *unpleasantness.*"
**OSTRANDER:** "The duchies will pay for a champion. Handsomely. We do not pay for an *opinion.*"
**OSTRANDER:** "A signature, and the thing is done."
> ► **"What does it say?"** — **OSTRANDER:** "That the Colossus is a calamity, and that we regret it."
> ► **"Who benefits from the wording?"** — **OSTRANDER:** "The treasury."
> ► **"Let me read it."** — **OSTRANDER:** "I would expect nothing less."

**Scene 2: the second room.** In a wood-panelled counting-house, Banker Ferris offers a very large cheque and a very small smile.

**FERRIS:** "We will fund a decent defence. We will not fund an *admission.*"
**FERRIS:** "You understand the distinction. It is what separates a bank from a *charity.*"

Outside, quarry-foremen and townspeople wait in the wet, hoping the petition names them.

**FOREMAN (Rudd Ketteridge):** "They'll say it's nobody's fault, and then we'll all go on paying the same."

**Scene 3: the signature.**

> ► **"Sign as written."** — The defence fund is released, and four hundred quarry-families get nothing.
> ► **"Sign with a rider."** — A single line added: *"without prejudice to any claim of the people."* The Seneschal sighs, and agrees, and is visibly relieved to.
> ► **"Refuse to sign."** — The petition is withdrawn; the fund is frozen.
> ► **"Take it public."** — The player reads it aloud on the Court steps.

**OSTRANDER:** "I did not say *no* to the rider. I said *not before lunch.*"

**Scene 4: the steps.** Whatever the player chose, the Seneschal stands on the Court steps at dusk, with the petition rolled under one arm.

**OSTRANDER:** "I have spent my life making things vanish. It is a great relief to be *seen.*"

**Outcomes and receipt.**
- The petition is sent, in one of four forms. The rider keeps the money flowing and the claim alive; a refusal costs time; a public reading costs the Seneschal his comfort and gains him a reputation.
- **Receipt:** the petition pinned on the Court's public board, with or without the rider; a line of quarry-families queueing patiently for the first time at the ducal clerk's window.

<!-- quest
id: qst_vel_quiet_petition
title: The Quiet Petition
rank: B
type: Faction
giver: npc_seneschal_ostrander
region: reg_velmark
level: 94
act: 4
requires_rank: B
reward: 11500 | 680 | 49000
sets: vel_petition_resolved
summary: The Grand Duke wants the Colossus stopped without admitting any debt, and the wording of a petition decides who gets paid.
objectives:
  talk npc_seneschal_ostrander
  talk npc_banker_lucan_ferris
  choice sign_rider_refuse_or_read
-->

---

## 8. The Last Mason of the Old Rite

*B · Hidden · the Foundation Stone · giver Old Gideon Marl*

**The short version.** Every autumn, before dawn, Old Gideon walks to the Foundation Stone and lays a small hand-cut block against its base. His knees have failed. He asks the player to carry the stone for him, and not to tell anyone where they are going.

**What is really going on.** The stone offering was abolished. The Foundation Stone is guarded now, as a monument, and laying anything against it is a minor offence. But the offering was never quite stopped: one family, then three, then a dozen, have been leaving small stones in the dark for forty years. Gideon is the last who knows the words.

**Scene 1: the cottage.**

**GIDEON:** "My father taught me. His father taught him. It's six words. They aren't *good* words. They're just the *right* ones."
**GIDEON:** "I cut it myself. Eleven inches. No more, no less."
**GIDEON:** "You'll want to be quiet. The watch walks the hill at the fourth bell."
> ► **"What are the words?"** — **GIDEON:** "I'll tell you at the stone."
> ► **"Why does it matter?"** — **GIDEON:** "It's what we *owe.* Even when nobody's counting."
> ► **"I'll carry it."** — **GIDEON:** "Mind the edges. It's *sharp.*"

**Scene 2: the hill.** Before dawn. Mist on the white hill. The great Foundation Stone, taller than a house, with the dark shape of a guard-post beside it.

**GUARD (young, bored):** "Halt. Sunrise visits start at six."
> ► **"We have permission."** — A clipped lie, or a half-truth.
> ► **"Talk the guard round."** — **GUARD:** "I'm not supposed to... but my gran does the same."
> ► **"Slip past."** — A hushed, careful climb.

**Scene 3: the offering.** The player and the old man kneel by the stone. Gideon recites six words in an old accent. He lays the block.

**GIDEON:** "*For the stone we took. For the hand that made it.*"

For a moment, nothing happens. Then, from deep underfoot, a long, slow grinding, as if something very large is *counting.* It runs for the length of a held breath, and stops.

**GUARD (quietly):** "...That's not the wind."

**Scene 4: the dawn.** Gideon leans on the player's arm. Down the hill, a long line of dim lanterns is rising: a dozen quarrymen, a baker, three children, an off-duty clerk, each with a small stone.

**GIDEON:** "I thought I was the last."
**GIDEON:** "I was only the last one who *said* it."

**Outcomes and receipt.**
- The offering is laid. If the guard was talked round, he joins the line; if the player slipped past, he pretends not to see. Nobody knows what the grinding meant, and the dukes' guard-post is quietly left unmanned.
- **Receipt:** a growing heap of small white stones at the base of the Foundation Stone; Gideon's block on top, with six words scratched on its underside.

<!-- quest
id: qst_vel_last_mason
title: The Last Mason of the Old Rite
rank: B
type: Hidden
giver: npc_gideon_marl
region: reg_velmark
level: 97
act: 4
requires_rank: B
reward: 12000 | 700 | 51000
sets: vel_offering_laid
summary: An old mason can no longer climb to the Foundation Stone, and asks the player to help lay the abolished offering.
objectives:
  talk npc_gideon_marl
  reach foundation_stone_dawn_offering
  choice permission_talk_or_slip
-->

---

## 9. Hollin Cross Pays Its Tithe

*B · Exploration · the Hollin Cross quarry-lake · giver Keeper Aldith Crewe*

**The short version.** Two generations ago, the quarrying town of Hollin Cross collapsed into its own cellars and became a lake. Every year, Aldith rings the one bell still above water. This year the bell has rung back.

**What is really going on.** The sunken town is not empty. It is *neat.* The streets are swept; the houses have their doors shut; in the guildhall a ledger lies open on the table, with the last entry dated the night of the fall, in a clerk's steady hand: *"Tithe, Hollin Cross: paid in full."* Under the ledger is a receipt, signed in a hand that is not a clerk's. Nobody knows what that means.

**Scene 1: the shore.**

**ALDITH:** "My grandmother was a girl in Hollin Cross. She said the bell rang the night it fell."
**ALDITH:** "I ring it once a year. I've never had a *reply.*"
**ALDITH:** "Last month, it rang *back.* Two strokes. Slowly."
> ► **"Could it be water?"** — **ALDITH:** "It was *measured.*"
> ► **"Who has been down there?"** — **ALDITH:** "No one. They say it's not a ducal matter."
> ► **"Let's go and see."** — **ALDITH:** "I'll row."

**Scene 2: the dive.** Cold green water. The main street is clear; the cobbles shine. The houses have unbroken windows. Fish drift through them like moths.

**ALDITH (surfaced, voice hushed):** "It's as if they only *went out.*"
In the guildhall, a table, a lamp that does not burn, and the ledger.

**Scene 3: the ledger.** The last entry, and the receipt beneath, in a heavy, square hand, as if cut rather than written: *Received.*

**ALDITH:** "My grandmother said the town fell because the tithe was *late.* Not the way you'd think. They paid it that night. All of it. Gold, grain, a sack of stones."
**ALDITH:** "And it fell *anyway.*"
> ► **"Perhaps it was paid too late."** — **ALDITH:** "Perhaps."
> ► **"Perhaps the wrong kind."** — **ALDITH:** "Perhaps. I don't want to say."
> ► **"Perhaps it wasn't about the tithe at all."** — **ALDITH:** "Then what was it?"

**Scene 4: the bell.** On the shore, Aldith asks the player to ring it once more, and to say the town's name when they do.

> ► **"Ring it once."** — A single, clear note over the lake.
> ► **"Ring it twice."** — The lake seems to answer, very faintly, and then goes still.
> ► **"Let Aldith ring it."** — She does, and her hands do not shake.

**Outcomes and receipt.**
- The ledger is recovered and carried to the Court. What it proves is left open: whether the town paid wrong, paid late, or paid something the tithe never asked for. Aldith keeps ringing the bell, and the bell is, once a year, answered.
- **Receipt:** the recovered ledger in a glass case at the Court annex; a small white buoy on the lake over the guildhall.

<!-- quest
id: qst_vel_hollin_cross_tithe
title: Hollin Cross Pays Its Tithe
rank: B
type: Exploration
giver: npc_aldith_crewe
region: reg_velmark
level: 100
act: 4
requires_rank: B
requires_quests: qst_vel_eleventh_clause
reward: 12500 | 730 | 53000
sets: vel_hollin_cross_ledger
summary: A drowned quarry town is eerily tidy, and its last ledger says the tithe was paid in full the night it fell.
objectives:
  talk npc_aldith_crewe
  reach hollin_cross_sunken_guildhall
  choice ring_once_twice_or_keeper
-->

---

## 10. The Order of Evacuation

*B · Defense · Brightstone · giver Marshal Cordelia Haverlock*

**The short version.** The Colossus will reach Brightstone in a day. The ducal list says the guildhall district leaves first and Quarrymen's Row leaves last. Marshal Haverlock must run it, and has read the list.

**What is really going on.** The earth-elementals that ride ahead of the Colossus, the "vanguard," will break the Row's only road within hours. Anyone left till last will be cut off. The list was drawn up by clerks who have never been to the Row. The marshal can follow it, or rewrite it, and she wants a second pair of hands to defend whichever order she chooses.

**Scene 1: the marshal's table.**

**HAVERLOCK:** "A list is a good thing. Lists keep order. Lists are what we have when everything else is *moving.*"
**HAVERLOCK:** "This list puts the Row last. The Row is where the road breaks first."
**HAVERLOCK:** "I would like to be told I have misread it."
> ► **"You haven't."** — **HAVERLOCK:** "I was afraid of that."
> ► **"What do you need?"** — **HAVERLOCK:** "A line of defence on the Row road. And a second opinion."
> ► **"Can you rewrite it?"** — **HAVERLOCK:** "I can. I will be asked why."

**Scene 2: the Row.** Rudd Ketteridge and four hundred quarry-workers wait in the rain with their bundles. Nobody has told them the order.

**RUDD:** "We're used to being last. We just don't like being last *and not told.*"
**RUDD:** "If it's the road that breaks first, then let us go first, and the town can follow."
> ► **"Follow the list."** — Order is kept. The guildhall district leaves in good time.
> ► **"Row first."** — The marshal rewrites the list; the guildhall district complains, loudly.
> ► **"Everyone together."** — A slow, difficult column, with the whole town on the road at once.

**Scene 3: the vanguard.** At the fourth bell the ground shudders. Stone shapes, taller than carts, rise out of the fields on both sides of the road.

> ► **"Hold the bridge."** — A hard defence at the choke point while the column crosses.
> ► **"Lead them off the road."** — A wild, risky crossing of the dry quarry bed.
> ► **"Close the gap at the Row."** — A fast, brutal fight at the weakest point of the line.

**HAVERLOCK:** (shouting over the grinding) "Keep them *moving.* Do not stop for the lamps! Do not stop for the *dogs!*"

**Scene 4: the road.** The last cart rolls clear. Behind it, in a silence that comes down like a lid, Brightstone's white towers lean together and fold. The column does not look back.

**HAVERLOCK:** "I wrote down the order. I'll write down the names. It is the only thing I *can* write."

**Outcomes and receipt.**
- The column escapes. The order chosen decides who is angry and who is alive: the list kept order but cost the Row dearly; the Row-first route saved them and cost the town its pride; the whole-town march was the slowest and the safest. The Colossus is not stopped, and does not need to be.
- **Receipt:** a roll of names pinned on the new camp's gate, including the Row's, in Haverlock's own hand; a white stone from each family set on the roadside where the column crossed.

<!-- quest
id: qst_vel_order_evacuation
title: The Order of Evacuation
rank: B
type: Defense
giver: npc_marshal_haverlock
region: reg_velmark
level: 106
act: 4
requires_rank: B
reward: 13500 | 780 | 58000
sets: vel_brightstone_evacuated
summary: A ducal list puts the quarry-workers last out of a doomed town, on a road that will break first.
objectives:
  talk npc_marshal_haverlock
  talk npc_foreman_rudd_ketteridge
  defend brightstone_row_road
  choice list_row_first_or_together
-->
