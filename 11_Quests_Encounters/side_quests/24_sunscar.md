# 11e-24 — Sunscar, the Glass Desert: Ten Side Quests (draft)

> *"Qadira's water-keepers can recite the oasis's shoreline for every year back to the first well."*
> — Gazetteer, Sunscar

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the third regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 7, 8 and 9 touch the Colossus and the buried machine; none of them explains what the machine is.

**Region:** `reg_sunscar` (the Oasis of Qadira, the Seven Wells, the Glass Streaks, the Sunken Towers, the caravan roads). **Rank band:** B–A. **Tone:** dry, hot, courteous and watchful; water is sacred and counting it is a form of prayer. Funny in a wry, sunburnt way, never cruel.

**Placement notes.**
- **The Colossus of Sunscar, Walker of the Dunes,** is the region's Tyrant: a construct of the vanished empire that still carries water to cities that no longer exist, and spills it on the sand. It does not know. **No quest here kills it, stops it or ends the drying of the wells.** Quests 7, 8 and 9 change how Qadira *prepares and what it understands*, nothing more.
- **General Morthis** (Canon) and the vanished empire's name are **not used**. The empire stays "the old empire", and nothing here says what it was or who burned it.
- Customs the quests rely on: the **water-tithe** (every caravan pays one measure in ten at the oasis); the **dawn call** at the wells; **the recital** (the keepers say the shoreline of every year aloud, so the oasis can never be flattered); the rule that **water is never refused to a stranger who asks by name of the well**, and never wasted in front of one.
- Earlier pattern quest here: *The Table Set for Six* (the Qadira road).

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Year Nobody Recited | B | Investigation | Keeper Zahra Merin | A number too heavy to say |
| 2 | The Unpaid Tithe | B | Escort | Old Hadiya Qasr | A debt carried on foot |
| 3 | A Dowry in Salt | B | Faction | Matchmaker Yusra Bell-Tamin | Two tribes, one stubborn camel |
| 4 | The Night the Awning Held | B | Defense | Caravanserai-master Odo Marsh | A storm and two hundred guests |
| 5 | What the Glass Remembers | B | Exploration | Glass-singer Idris Valmont-Sef | A map written in heat |
| 6 | The Last Sunrise on the Streaks | B | OddJob | Blind guide Nuru Taleb | One more walk |
| 7 | A Shovel Under Seal | A | Investigation | Calla Ferrin | A digger and a locked door |
| 8 | The Walker's Road | A | Exploration | Keeper Imran Sabeh | Following the footprints |
| 9 | The Eighth Well | A | Hidden | Elder Mother Kalsum | A well that is only sung |
| 10 | The Ration Council | A | Trial | Keeper-Elect Basma Orlin | Who drinks first |

## Cast

<!-- npc
id: npc_keeper_zahra_merin
name: Keeper Zahra Merin
tier: major
race: Human
region: reg_sunscar
settlement: Oasis of Qadira
role: Senior water-keeper and reciter
backstory: A calm, exact keeper in her fifties who has recited the shoreline at the dawn call for thirty years and has just noticed that one year in the record does not sound right.
-->
<!-- npc
id: npc_tarek_ashur
name: Tarek Ashur
tier: townsfolk
race: Human
region: reg_sunscar
settlement: Oasis of Qadira
role: Apprentice water-keeper
backstory: A soft-spoken apprentice with ink on his sleeves who learned the recital faster than anyone in a generation and cannot bring himself to say one of its numbers aloud.
-->
<!-- npc
id: npc_old_hadiya_qasr
name: Old Hadiya Qasr
tier: townsfolk
race: Human
region: reg_sunscar
settlement: The Qadira road
role: Last survivor of a lost caravan
backstory: A tiny, fierce old woman who walked out of a sandstorm alone with her caravan's tithe-ledger in a goatskin bag and who refuses to arrive anywhere with a debt unpaid.
-->
<!-- npc
id: npc_yusra_bell_tamin
name: Matchmaker Yusra Bell-Tamin
tier: townsfolk
race: Human
region: reg_sunscar
settlement: Oasis Caravanserai
role: Matchmaker to the nomad tribes
backstory: A round, bright-eyed matchmaker who has arranged forty-one tribal weddings and has never once had two negotiating families agree before the third pot of tea.
-->
<!-- npc
id: npc_odo_marsh
name: Caravanserai-master Odo Marsh
tier: major
race: Human
region: reg_sunscar
settlement: Oasis Caravanserai
role: Master of the Oasis Caravanserai
backstory: A heavy, sweating, endlessly practical outsider who bought into the caravanserai thirty years ago and now fears the storm season more than any bandit.
-->
<!-- npc
id: npc_idris_valmont_sef
name: Glass-singer Idris Valmont-Sef
tier: townsfolk
race: Human
region: reg_sunscar
settlement: The Glass Streaks
role: Hermit who listens to the glass
backstory: A thin, sun-dark hermit who claims the Glass Streaks hum a different note at each hour and has spent nine years writing the notes down on strips of hide.
-->
<!-- npc
id: npc_nuru_taleb
name: Nuru Taleb
tier: townsfolk
race: Human
region: reg_sunscar
settlement: Oasis of Qadira
role: Retired caravan guide
backstory: A blind, laughing old guide who led caravans across Sunscar for fifty years by sound and smell and who wants to hear the sun come up over the glass one last time.
-->
<!-- npc
id: npc_calla_ferrin
name: Calla Ferrin
tier: major
race: Human
region: reg_sunscar
settlement: Oasis Caravanserai
role: Treasure-hunter
backstory: A sharp, sunburnt treasure-hunter who found a door in the ruins as a girl, watched the water-keepers bury it, and has spent twenty years certain it could save the oasis.
-->
<!-- npc
id: npc_imran_sabeh
name: Keeper Imran Sabeh
tier: major
race: Human
region: reg_sunscar
settlement: Oasis of Qadira
role: Water-keeper and surveyor
backstory: A gaunt, patient keeper who believes the Colossus walks a fixed road and has measured its footprints for eleven years in the hope that a road can be understood.
-->
<!-- npc
id: npc_elder_mother_kalsum
name: Elder Mother Kalsum
tier: major
race: Human
region: reg_sunscar
settlement: The Red Dunes
role: Elder of a nomad tribe
backstory: A broad, slow-smiling tribal elder whose people sing of eight wells while the water-keepers count seven, and who has never argued the point because she did not want to be right.
-->
<!-- npc
id: npc_basma_orlin
name: Keeper-Elect Basma Orlin
tier: major
race: Human
region: reg_sunscar
settlement: Oasis of Qadira
role: Keeper-elect and ration steward
backstory: A young, sleepless keeper elected last month to divide the oasis's shrinking water, who has not yet worked out how to do it so that no one is ashamed.
-->

---

## 1. The Year Nobody Recited

*B · Investigation · the Seven Wells · giver Keeper Zahra Merin*

**The short version.** The recital of the shoreline has a hole in it. One year, last year's, was said aloud at the dawn call and does not match the stakes on the bank.

**What is really going on.** The apprentice **Tarek** inherited the recital this spring and could not say the true number for last year: the oasis lost more shore in one year than in the ten before. He softened it by a hand's breadth. He has not slept since, because the recital is the one thing in Qadira that is never allowed to flatter.

**Scene 1: the dawn call.**

**ZAHRA:** "Thirty years I have said the shoreline. Never a word of comfort in it. That is the *point* of it."
**ZAHRA:** "Last year's line sounds like a man holding a door shut."
**ZAHRA:** "Someone has told the oasis a kindness. I want to know who, and I want to know *why*, before I decide what to do."
> ► **"How do I check a number?"** — **ZAHRA:** "Walk the bank. The stakes do not lie."
> ► **"Who says the recital?"** — **ZAHRA:** "The apprentice. Tarek. He is very good."
> ► **"I'll look into it."** — **ZAHRA:** "Quietly, please."

**Scene 2: the bank.** The player walks the shore from stake to stake, each one notched with a year. The bank has pulled back from last year's notch by a long step. At the last stake someone has scratched the notch *shallower* and then, in a different hand, scratched it deeper again.

**TAREK:** "...You found the stake."
**TAREK:** "I said it a hand shorter. I told myself it was rounding. It was not rounding."
**TAREK:** "My mother is in the fourth row at the dawn call. Every morning. She *listens* to the number."
> ► **"Say the true number to me."** — **TAREK:** (a long breath, then the number, and he flinches.)
> ► **"You were kind."** — **TAREK:** "Kind is how a well dries *politely*."
> ► **"What do you need?"** — **TAREK:** "Someone to stand next to me."

**Scene 3: the choice.** Zahra could correct the record in private, or the true number could be said aloud, in the open, at the dawn call.

**ZAHRA:** "The old rule is that the one who softened the year says it back."
**ZAHRA:** "But the old rule was written for people who did it for pride. He did it for love, and that is a different kind of wrong."
> ► **"Let him say it, with me beside him."** — The public correction.
> ► **"Correct it quietly."** — The record is mended; Tarek is spared.
> ► **"Let the keepers say it together."** — Every keeper says the number.

**Scene 4: the dawn.** At the dawn call, in the grey light, the shoreline is said. Tarek's voice shakes on last year, and then it does not.

**TAREK:** "...and the water stood one long step further from the palms than the year before."
*In the fourth row, a woman puts her hand over her mouth, and then, slowly, nods.*

**Outcomes and receipt.**
- The record is true; Tarek keeps his place. Quietly corrected: Zahra holds the number herself and Tarek leaves the order within the year. All together: the keepers adopt the custom that a hard year is *said by everyone*.
- **Receipt:** a fresh notch on the last stake, cut deep, and a new line of whitewash on the bank at the height of the old shore.

<!-- quest
id: qst_sun_year_not_recited
title: The Year Nobody Recited
rank: B
type: Investigation
giver: npc_keeper_zahra_merin
region: reg_sunscar
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 45000
sets: sun_year_done
summary: The oasis's shoreline recital has a softened year in it, and a young apprentice cannot bring himself to say the true number.
objectives:
  talk npc_keeper_zahra_merin
  reach sunscar_shoreline_stakes
  talk npc_tarek_ashur
  choice say_correct_or_together
-->

---

## 2. The Unpaid Tithe

*B · Escort · the Qadira road · giver Old Hadiya Qasr*

**The short version.** A caravan was lost in a sandstorm and its water-tithe was never paid. One old woman survived, and she means to deliver it on foot, with the player beside her.

**What is really going on.** The tithe is not coin. It is the caravan's *ledger* and a sealed jar of the caravan's own last water, carried across the dunes because Hadiya's dead companions would not have wanted the oasis to think them cheats. The oasis is rationing and does not want to take it. Hadiya will not be spared the walking.

**Scene 1: the camp.**

**HADIYA:** "Eleven of us left Salt Gate. I am the one who got back to the road, which is not the same as the one who got *away*."
**HADIYA:** "A tithe is a tithe. One measure in ten. We owed it before the storm, and a storm does not cancel it."
**HADIYA:** "You can carry my bag, but I carry the *jar*."
> ► **"The oasis won't hold this against you."** — **HADIYA:** "It will not need to. *I* will."
> ► **"What is in the jar?"** — **HADIYA:** "Water. The last of ours. Do not say anything clever about it."
> ► **"I'll walk with you."** — **HADIYA:** "Slowly. I have been dead twice already."

**Scene 2: the dunes.** The road is gone under new sand. Glass-backed lizards bask on the streaks, flashing the heat into the player's eyes. Hadiya refuses water from the player's own skin.

**HADIYA:** "Not yours. Yours is for *you*. This is the caravan's."
*(Gameplay: navigate by the Sunken Towers; shade-stops; a short sandfall that tests the escort.)*
> ► **"Rest in the tower's shade."** — **HADIYA:** "Ten breaths."
> ► **"Take the glass road; it's faster."** — It is, but the glare is cruel.
> ► **"Let me carry the jar a while."** — **HADIYA:** "...Only if you do not drink it."

**Scene 3: the oasis gate.** At the gate stand two keepers with a rationing chit. They look at the jar and then at each other.

**GATEKEEPER:** "Old mother, we cannot take water in during rationing. It is... it is *more* water than the ledger says we have to give."
**HADIYA:** "It is the tithe."
**GATEKEEPER:** "It is a *kindness*, and kindness is not on the chit."
> ► **"Take it. She walked for it."** — The gatekeeper hesitates.
> ► **"Put it in the common well and enter it in the ledger."** — A third way.
> ► **"Let her pour it herself."** — Hadiya pours.

**Scene 4: the pouring.** At the first well Hadiya pours the jar slowly into the stone mouth. The keepers uncover their heads. The water goes down for a long time.

**HADIYA:** "...Eleven. I have said all eleven."
**HADIYA:** "Now I am paid up."

**Outcomes and receipt.**
- The tithe is entered in the ledger in a new hand. If the player intervened at the gate, the keepers formally accept *the dead's tithe*, and Hadiya takes a room by the First Well as an honoured guest.
- **Receipt:** eleven small stones set on the lip of the First Well, one for each name, and a line in the tithe-ledger that no keeper will ever scratch out.

<!-- quest
id: qst_sun_unpaid_tithe
title: The Unpaid Tithe
rank: B
type: Escort
giver: npc_old_hadiya_qasr
region: reg_sunscar
level: 94
act: 4
requires_rank: B
reward: 10800 | 640 | 46000
sets: sun_tithe_done
summary: The last survivor of a lost caravan is walking its water-tithe to Qadira on foot, and the oasis is too short of water to want it.
objectives:
  talk npc_old_hadiya_qasr
  escort npc_old_hadiya_qasr
  reach sunscar_first_well
  choice accept_enter_or_pour
-->

---

## 3. A Dowry in Salt

*B · Faction · the Oasis Caravanserai · giver Matchmaker Yusra Bell-Tamin*

**The short version.** Two nomad tribes want to marry a son and a daughter. The dowry talks have stalled for eleven days over a single camel.

**What is really going on.** Neither tribe cares about the camel. The camel, a sour-tempered old bull named **Mayor**, is the only animal in either herd that has ever crossed the Red Dunes without losing its way, and each tribe is terrified of being the one who *gave him away*. The bride and groom already know each other and have, in secret, been taking turns feeding him.

**Scene 1: the tent.**

**YUSRA:** "Forty-one weddings. Not once did anyone leave before the third pot of tea. These two have reached the *ninth.*"
**YUSRA:** "The Sandfoot want him as part of the bride-price. The Ghazal say he is *not* a dowry, he is a *relative*."
**YUSRA:** "I need someone neither tribe is related to. That is, regrettably, almost no one, so you will do."
> ► **"Which tribe is right?"** — **YUSRA:** "Both. It is the worst thing about this."
> ► **"What does the camel say?"** — **YUSRA:** "He spits. He is consistent."
> ► **"I'll sit at the table."** — **YUSRA:** "Bring patience. And a fourth pot."

**Scene 2: the talks.** In a tent that smells of cardamom and offended pride, two clan-heads sit with their arms crossed.

**SANDFOOT HEAD:** "The bride-price includes the animal. It has always included the animal."
**GHAZAL HEAD:** "He taught my father to read the stars. You cannot *price* him."
**SANDFOOT HEAD:** "Then he comes *with* the groom. As a gift."
**GHAZAL HEAD:** "A gift to whom? He is not *mine* to give."
> ► **"Ask the camel."** — The tents pause.
> ► **"Ask the couple."** — Heads turn.
> ► **"Propose a shared herd."** — Both clan-heads gasp.

**Scene 3: the couple.** Behind the caravanserai stable, the bride and groom are feeding the camel dates from the same hand. They freeze, mortified.

**BRIDE:** "He bites everyone *except* us."
**GROOM:** "We were going to tell them. After the wedding."
**BRIDE:** "He is the reason we met."
*(Gameplay: the player carries a message between tents, or helps the pair stage a dignified "accident" in which the camel chooses.)*

**Scene 4: the choosing.** In the courtyard, with both tribes watching, the camel is led to the middle and left alone. He chews. He looks at both tribes with deep contempt, and then walks to the couple and sits.

**YUSRA:** "...Well. That's the tenth pot decided."

**Outcomes and receipt.**
- The wedding is held; the camel is named the *shared relative* of both tribes and travels between camps. If the player proposed the shared herd, the two tribes merge their summer wells, which eases the Qadira roads for a season.
- **Receipt:** a pair of salt-white bridal tassels on the camel's saddle, and a new rule in the caravanserai ledger: *No dowry may include a living relative.*

<!-- quest
id: qst_sun_dowry_in_salt
title: A Dowry in Salt
rank: B
type: Faction
giver: npc_yusra_bell_tamin
region: reg_sunscar
level: 95
act: 4
requires_rank: B
reward: 11000 | 620 | 46500
sets: sun_dowry_done
summary: Two nomad tribes will not agree on a bride-price because it includes one sour old camel that neither will give away.
objectives:
  talk npc_yusra_bell_tamin
  reach sunscar_caravanserai_tent
  choice camel_couple_or_shared_herd
-->

---

## 4. The Night the Awning Held

*B · Defense · the Oasis Caravanserai · giver Caravanserai-master Odo Marsh*

**The short version.** A red-sky storm is coming. The caravanserai holds two hundred guests, a hundred and twenty animals and a courtyard awning that has not been properly tested since the Colossus last passed.

**What is really going on.** The wind is not the danger. The danger is the *glass*: sandstorms in Sunscar pick up splinters from the streaks and drive them like arrows. The awning is old sailcloth on cedar poles, and if it goes, a hundred and twenty animals will bolt into two hundred sleeping people.

**Scene 1: the yard.**

**ODO:** "Red sky at noon. Twenty storms I've weathered, and I'd rather weather twenty more than see *this* one."
**ODO:** "The awning goes up on the nine poles. I need hands on every pole and an eye on every rope."
**ODO:** "And I need someone who does not panic when the camels do."
> ► **"What do I do first?"** — **ODO:** "Tie the animals. Then the poles. Then pray."
> ► **"Can we move the guests?"** — **ODO:** "To where? The stone rooms hold sixty."
> ► **"I'll take the north poles."** — **ODO:** "North takes the worst. Thank you."

**Scene 2: the storm.** The sky turns a bruised copper. The first gusts hiss across the yard, shaking the ropes.
*(Gameplay: hold nine poles, re-tie guy-lines, lead panicking camels into the stone stalls; glass-splinters rattle off the awning. A defense-style objective with a rising timer.)*

**CAMEL-WRANGLER:** "The grey mare's bolting! *Mind her!*"
**ODO:** "Pole six is cracking! Somebody *lean!*"
> ► **"Brace pole six with your shoulder."** — It holds, barely.
> ► **"Cut the line to save the awning."** — The awning loses a corner but lives.
> ► **"Calm the mare."** — The mare steadies; the yard breathes.

**Scene 3: the lull.** At the storm's heart, the wind drops. Two hundred people stand in the dark, listening.

**ODO:** "It comes back from the other side. Harder."
**ODO:** "Pole nine. It always goes last."
*A child's voice from the stone room begins singing the dawn call, flat and brave. Others join it.*

**Scene 4: the morning.** The sun comes up red on a yard full of sand and unharmed travellers. The awning, shredded, is still standing.

**ODO:** "I have been trying to buy a stronger awning for twelve years."
**ODO:** "*Nobody* is allowed to tell me it was a fine awning."

**Outcomes and receipt.**
- Nobody is lost; the animals are found. If the player braced the pole, Odo rebuilds in cedar and stone; if the corner was cut, he rebuilds with a quick-release line, which later saves another caravan.
- **Receipt:** nine cedar poles carved with the names of the people who held them, and a storm-bell hung where the awning corner was cut.

<!-- quest
id: qst_sun_awning_held
title: The Night the Awning Held
rank: B
type: Defense
giver: npc_odo_marsh
region: reg_sunscar
level: 97
act: 4
requires_rank: B
reward: 11500 | 660 | 48000
sets: sun_awning_done
summary: A glass-laden sandstorm bears down on a caravanserai with two hundred guests and one old awning.
objectives:
  talk npc_odo_marsh
  defend sunscar_caravanserai_courtyard
  choice brace_cut_or_calm
-->

---

## 5. What the Glass Remembers

*B · Exploration · the Glass Streaks · giver Glass-singer Idris Valmont-Sef*

**The short version.** A hermit says the Glass Streaks hum a different note at each hour. He has written the notes down for nine years and cannot read them.

**What is really going on.** The glass was fused by heat in long lines, and the lines remember the *shape* of what burned them in the way a struck bell remembers the hammer. At the right hours, from the right standpoints, the hum resolves into the outline of a lost aqueduct line: a straight old water-road running toward the oasis from a place that is now only sand.

**Scene 1: the hermit's hide strips.**

**IDRIS:** "Noon is a low note, like an empty jar. Dusk is high, like a wet finger on a cup."
**IDRIS:** "Nine years. Four hundred and twelve strips. And I think they are *not music.*"
**IDRIS:** "I think they are *directions.*"
> ► **"Play me noon."** — **IDRIS:** (He hums it; the glass answers faintly.)
> ► **"Who else knows?"** — **IDRIS:** "A goat. He doesn't talk."
> ► **"Show me the strips."** — **IDRIS:** "Mind the order. I have none."

**Scene 2: the standpoints.** The player visits three standpoints on the streaks at three different hours, humming the recorded note and tapping the glass with a knuckle. At each, the glass rings back, and a heat-shimmer draws a pale line across the sand.
*(Gameplay: puzzle. Match the hide-strip notes to the hour and standpoint; three lines resolve into one.)*

**IDRIS:** "There! There, it's a *road!*"
**IDRIS:** "It's an old water road. It runs... away from the oasis. No. *Towards.* The lines point one way."
> ► **"It leads somewhere."** — **IDRIS:** "Somewhere that is now sand."
> ► **"It's an aqueduct line."** — **IDRIS:** "Drawn in *heat.* By the thing that burned it."
> ► **"Should we follow it?"** — **IDRIS:** "I have, in my head, nine hundred times."

**Scene 3: the end of the line.** The line stops at a low ridge of glass. Beneath it, a stone channel runs under the dune: dry, ancient, perfectly straight, stamped on the lintel with a mark of the old empire.

**IDRIS:** "A stone road for water. And no water in it."
*A faint, patient drip, from somewhere deeper, echoes down the channel. It is not water the oasis can reach, but it is still falling.*

**Scene 4: the choice.** Idris can give the map to the water-keepers, or keep it as a private gift, or ask the player to carry the notes to the keepers in a form no one can misuse.

**IDRIS:** "If I give it to Qadira, they will dig."
**IDRIS:** "If I keep it, I am one more old man with a secret."
> ► **"Give it to the keepers."** — They send a survey party.
> ► **"Keep it; copy only the road."** — A partial map.
> ► **"Sing it back to the glass."** — The streak goes quiet.

**Outcomes and receipt.**
- A surveyed channel gives the keepers a way to test the aquifer without digging; a partial map leaves the choice to later. If Idris sings it back, the streak falls silent and he is content.
- **Receipt:** a line of small white cairns where the glass-song ended, and Idris's hide-strips hung in the keepers' archive, finally in order.

<!-- quest
id: qst_sun_glass_remembers
title: What the Glass Remembers
rank: B
type: Exploration
giver: npc_idris_valmont_sef
region: reg_sunscar
level: 99
act: 4
requires_rank: B
reward: 11800 | 680 | 49000
sets: sun_glass_done
summary: A hermit's nine years of notes from the humming Glass Streaks turn out to be directions to a buried water-road.
objectives:
  talk npc_idris_valmont_sef
  reach sunscar_glass_standpoints 3
  reach sunscar_buried_channel
  choice keepers_partial_or_silence
-->

---

## 6. The Last Sunrise on the Streaks

*B · OddJob · the Glass Streaks · giver Blind guide Nuru Taleb*

**The short version.** Nuru Taleb led caravans across Sunscar for fifty years. He is blind now and wants to hear the sun come up over the glass one last time.

**What is really going on.** Nuru does not need to be led; he needs to be *heard*. The streaks are where he first heard a caravan come home safe, as a boy of ten. He wants to walk there with someone who will not describe it for him.

**Scene 1: the porch.**

**NURU:** "Fifty years I knew where I was by the sound of the sand. Now I know where I *was.*"
**NURU:** "I want to hear the glass at dawn. It sings, a little, when the sun hits."
**NURU:** "Do not tell me what it looks like. I have it already."
> ► **"I'll take your arm."** — **NURU:** "You will take my *elbow*. The arm is mine."
> ► **"It's a long walk."** — **NURU:** "I have been a long walk."
> ► **"When do we leave?"** — **NURU:** "Two hours before light. The sand is quietest then."

**Scene 2: the walk.** In the dark, the player and Nuru cross the dunes, Nuru reading the wind and the sand-shift with his feet.

**NURU:** "Dune on the left, steep. Fox in the hollow. Do you smell the tamarisk?"
**NURU:** "Warn me about the glass. It *cuts.*"
*(Gameplay: a quiet escort with no combat; the player may sit, drink, listen; each rest unlocks a small story of Nuru's: a lost goat, a wedding, a miscounted well.)*
> ► **"Tell me about the first caravan."** — **NURU:** "I was ten. I carried a bell."
> ► **"You never got lost?"** — **NURU:** "Every day. That is how I learned the roads."
> ► **"Do you miss the work?"** — **NURU:** "I miss being *needed.* Different thing."

**Scene 3: the first light.** On the lip of the Glass Streaks, the horizon turns the colour of a peach. The glass ticks, then hums, then rings.

**NURU:** "...There."
**NURU:** "I had forgotten it was *higher* than I remembered."
*Nuru stands very still, hands open, face to the sun.*

**Scene 4: the bell.** Nuru takes a small, tarnished bell from his sash: the one he carried at ten.

**NURU:** "Hang it somewhere the wind can ring it. Where the next boy will hear it and think he is lost."
> ► **"I'll hang it here."** — The bell hangs on the streak's edge.
> ► **"I'll hang it at the caravanserai."** — Travellers will hear it.
> ► **"Ring it yourself."** — **NURU:** (He does.)

**Outcomes and receipt.**
- Nuru is walked home before the heat. Whichever place the bell is hung, a new guide's custom starts: *the first bell of the day belongs to the first child to ask.*
- **Receipt:** a small tarnished bell on a bracket, ringing in the dawn wind; Nuru sits beneath it on a stool every morning.

<!-- quest
id: qst_sun_last_sunrise
title: The Last Sunrise on the Streaks
rank: B
type: OddJob
giver: npc_nuru_taleb
region: reg_sunscar
level: 101
act: 4
requires_rank: B
reward: 12000 | 700 | 50000
sets: sun_sunrise_done
summary: A blind old caravan guide wants to hear the sun come up over the Glass Streaks one last time.
objectives:
  talk npc_nuru_taleb
  escort npc_nuru_taleb
  reach sunscar_streak_dawn
  choice hang_ring_or_keep
-->

---

## 7. A Shovel Under Seal

*A · Investigation · the Sunken Towers · giver Calla Ferrin*

**The short version.** Calla Ferrin found a door in the ruins as a girl. The water-keepers buried it. She says whatever is behind it could save the oasis, and she has a shovel.

**What is really going on.** Nobody in the room knows what is behind the door. The keepers buried it because the last person who woke it did not come back; Calla wants it opened because the wells are dying. Both are right about the facts. Neither can say what the thing *is*, and this quest does not find out.

**Scene 1: the caravanserai.**

**DALIA:** "Twenty years. I've told the keepers. I've shouted at them. I've *bribed* a man to lose the key to their archive."
**DALIA:** "They buried a machine. A *working* machine. And then they let the wells go dry."
**DALIA:** "Come and look at the door, and then tell me I am a vandal."
> ► **"What do the keepers say?"** — **DALIA:** "That some doors are shut on purpose."
> ► **"What do you want?"** — **DALIA:** "To open it, once, and see."
> ► **"Show me."** — **DALIA:** "Bring water. It is a long walk to a bad idea."

**Scene 2: the door.** A tilted lintel, half-buried in a dune, stamped with the old empire's mark. The sand around it is *warm* in a way sand should not be. The door itself is smooth, seamless, and faintly sweating.

**DALIA:** "It hums when the Colossus walks. You'll feel it in your teeth."
*(Gameplay: the player examines the door, finds the keepers' seal-wax already cracked, and a second, older set of tool-marks, someone *else* has tried before.)*
> ► **"Someone's been here before."** — **DALIA:** "Not me. That's what scares me."
> ► **"It's warm."** — **DALIA:** "It's *awake.* Or it's dreaming."
> ► **"Let's not open it."** — **DALIA:** "Then why did you come?"

**Scene 3: the keepers.** Keeper Zahra and two elders arrive at the dune. They do not draw weapons. They bring tea.

**ZAHRA:** "Calla. I thought you'd come this week."
**ZAHRA:** "We buried it because the man who opened it first was a keeper too. He is not in our recital, because he is not *finished.*"
**ZAHRA:** "I will not tell you more. I do not know more. That is the *whole* trouble."
> ► **"Let her survey it, not dig."** — A compromise.
> ► **"Re-seal it properly."** — The keepers nod.
> ► **"Open it, with the keepers present."** — A terrible silence.

**Scene 4: the settlement.** Whatever the player argues, the door stays shut. The keepers promise to *watch* it, and Calla is given a place at the watch, as a keeper of the door, not of the oasis.

**DALIA:** "I still want to know."
**ZAHRA:** "So do we. Sit down. Have some tea."

**Outcomes and receipt.**
- The door stays closed. A survey permits Calla to measure it from outside; a re-seal puts a fresh stone cap on it; the third choice ends in a *tense, unresolved stand-off,* no one hurt, and a shared watch.
- **Receipt:** a stone cairn with a lantern, lit nightly, and Calla's name on the watch-roster. Nothing is explained.

<!-- quest
id: qst_sun_shovel_under_seal
title: A Shovel Under Seal
rank: A
type: Investigation
giver: npc_calla_ferrin
region: reg_sunscar
level: 126
act: 4
requires_rank: A
requires_quests: qst_sun_year_not_recited
reward: 29000 | 1520 | 128000
sets: sun_door_done
summary: A treasure-hunter and the water-keepers disagree over whether a buried machine should be opened, and neither knows what it is.
objectives:
  talk npc_calla_ferrin
  reach sunscar_buried_door
  talk npc_keeper_zahra_merin
  choice survey_reseal_or_open
-->

---

## 8. The Walker's Road

*A · Exploration · the Red Dunes · giver Keeper Imran Sabeh*

**The short version.** Imran Sabeh believes the Colossus walks a fixed road. He wants the player to walk beside its footprints and find where the road goes.

**What is really going on.** The road is a *route*, repeated, and it ends at a place that is only sand. The Colossus is carrying water to a city that is no longer there and spilling it on the dunes. Imran's real hope, a control chamber in the chest that could redirect it, is out of reach, but the route itself is the finding: if Qadira knows where the water goes, it knows where it *will* go.

**Scene 1: the survey tent.**

**IMRAN:** "Eleven years. Four hundred footprints. They are *not* random."
**IMRAN:** "It walks a road. We cannot see the road, because the dunes eat it. But the feet remember."
**IMRAN:** "I need someone who can walk beside a footprint the size of a house and not run."
> ► **"What do you hope to find?"** — **IMRAN:** "Where it is going."
> ► **"Can it be stopped?"** — **IMRAN:** "I don't know. I know it can be *understood.*"
> ► **"I'll walk it."** — **IMRAN:** "Thank you. Bring a notebook. And water."

**Scene 2: the footprints.** Each print is a bowl of fused sand, full of cool air and a faint smell of wet stone. The player and Imran chart a line of them across the dunes.
*(Gameplay: track the footprints; avoid the Colossus's distant, rhythmic thud; mark each print on Imran's map.)*

**IMRAN:** "Water leaks from its feet. Look. Dark sand, in a ring."
**IMRAN:** "It is *carrying* something. A great deal."
> ► **"It's watering the sand."** — **IMRAN:** "It is watering the *wrong* sand."
> ► **"It's following a pipe."** — **IMRAN:** "An aqueduct, once. The road is the aqueduct."
> ► **"Where does it end?"** — **IMRAN:** "Let us find out."

**Scene 3: the road's end.** At the end of the line, on a plain of smooth, empty sand, the footprints turn in a wide circle, and every ring of dark sand ends in the same place: a wide, level, perfectly empty square where something large used to stand.

**IMRAN:** "...It is bringing the water *home.*"
**IMRAN:** "There is nothing here. It has been bringing water to nothing for a thousand years."
*In the distance, the thud stops, and the horizon holds its breath.*

**Scene 4: the figures.** Imran does the arithmetic aloud, then again, then says nothing for a long time.

**IMRAN:** "If it passes the Seventh Well every nine years, and takes a hand's breadth each time..."
**IMRAN:** "Then Qadira has one more generation of wells than I feared, and not two."
> ► **"Take this to the keepers."** — The council hears the numbers.
> ► **"Keep the map for the nomads too."** — The tribes can plan their own roads.
> ► **"We could move the gardens."** — A planning idea.

**Outcomes and receipt.**
- Qadira stops treating the Colossus as weather and starts treating it as a *schedule.* The keepers move the grain stores and gardens away from the passing road; the nomads redraw their summer routes. The Colossus is not stopped or approached again.
- **Receipt:** a painted road across the keepers' great map, marked in red where the Walker passes, and a bell rung nine days before each predicted pass.

<!-- quest
id: qst_sun_walkers_road
title: The Walker's Road
rank: A
type: Exploration
giver: npc_imran_sabeh
region: reg_sunscar
level: 130
act: 4
requires_rank: A
requires_quests: qst_sun_glass_remembers
reward: 30000 | 1560 | 132000
sets: sun_road_done
summary: A keeper charts the Colossus's footprints and learns that it walks a fixed route to a city that no longer exists.
objectives:
  talk npc_imran_sabeh
  reach sunscar_colossus_footprints 4
  reach sunscar_empty_square
  choice keepers_nomads_or_gardens
-->

---

## 9. The Eighth Well

*A · Hidden · the Red Dunes · giver Elder Mother Kalsum*

**The short version.** The nomads sing of eight wells. The keepers count seven. Elder Mother Kalsum has never argued the point, until two wells ran dry.

**What is really going on.** The eighth well is not a well that was *lost*. It is a well that was *never dug*, a place the nomads' ancestors found water and, by oath, never took any. They have sung its name for generations as a promise to leave one place untouched. Now the oasis is dying, and the promise is starting to cost people.

**Scene 1: the tent.**

**KALSUM:** "Seven for the keepers. Eight for us. We have sung it since before there was a Qadira."
**KALSUM:** "It is not a well that failed. It is a well we *chose.*"
**KALSUM:** "Last night my granddaughter asked me why we do not drink from it. I had no answer left."
> ► **"What are you asking me?"** — **KALSUM:** "To walk to it. And tell me whether the promise still means something."
> ► **"Where is it?"** — **KALSUM:** "In the song. Not on a map."
> ► **"Why me?"** — **KALSUM:** "You are not of the oasis or of the tribes. You will say it plainly."

**Scene 2: the song.** The eighth well is hidden in the verses. The player must listen to the tribe's sung directions, line by line, and follow them across the dunes by sun, star and wind-shadow.
*(Gameplay: exploration puzzle. Each verse names a landmark; the verses are correct but out of order.)*

**KALSUM'S GRANDDAUGHTER:** "The second verse says 'where the tooth of the dune bites the sun.' That is the *glass tooth.*"
> ► **"Follow the verse."** — The ridge appears.
> ► **"Ask the keepers' records."** — A cross-check.
> ► **"Sing it back to the dunes."** — A harmonic echo.

**Scene 3: the well.** Behind a ridge, in a hollow of green, a stone ring surrounds a still pool that has never seen a bucket. Sand foxes drink there. Songbirds nest on the lip. The water is very, very clear.

**KALSUM:** "...It is *full.*"
**KALSUM:** "Nobody has taken from it in a thousand years, and it is *full.*"
*Around the pool, the tribe's ancestors' names are cut into the stone, each followed by the same word: kept.*

**Scene 4: the decision.**

**KALSUM:** "If we take from it, the oasis lives a few years more. If we do not, it may not."
**KALSUM:** "The promise was made for a reason I cannot remember. That is a poor reason to break it, and a poorer one to keep it."
> ► **"Take one measure, and no more."** — A careful sharing.
> ► **"Keep the oath; find another way."** — The well stays untouched.
> ► **"Tell the keepers it exists, and let them decide."** — Shared knowledge.

**Outcomes and receipt.**
- Whatever is chosen, it is chosen *openly,* by both peoples at the same fire. A single measure is shared in a bowl, once a year, at the dawn call; or the oath holds and the tribes add a seventh song to their calendar; or the keepers are told, and the Eighth Well is added to the recital.
- **Receipt:** a new line in the keepers' recital, "and an eighth, which is kept," and a ring of white stones around the pool.

<!-- quest
id: qst_sun_eighth_well
title: The Eighth Well
rank: A
type: Hidden
giver: npc_elder_mother_kalsum
region: reg_sunscar
level: 134
act: 4
requires_rank: A
requires_quests: qst_sun_walkers_road
reward: 31000 | 1600 | 136000
sets: sun_eighth_done
summary: A nomad elder asks the player to find the eighth well her people sing of and decide whether a thousand-year promise still holds.
objectives:
  talk npc_elder_mother_kalsum
  reach sunscar_eighth_well_verses 3
  reach sunscar_eighth_well
  choice take_keep_or_tell
-->

---

## 10. The Ration Council

*A · Trial · the Oasis of Qadira · giver Keeper-Elect Basma Orlin*

**The short version.** Two wells are dry. The water that remains must be divided between the gardens, the caravans, the sick and the tribes. Basma Orlin has to decide before the next dawn call, and she wants a witness.

**What is really going on.** There is no division that will not wound someone. Basma is not asking the player to choose for her; she is asking the player to sit in the council and *ask the questions she is too tired to ask*, so that whatever she decides, nobody says it was done in secret.

**Scene 1: the keeper-elect.**

**BASMA:** "I have been a keeper for five years and a steward for five weeks."
**BASMA:** "There are four claims. The gardens feed the oasis. The caravans pay the tithe. The sick cannot walk to another well. The tribes were here first."
**BASMA:** "Every one of them is right."
> ► **"What do you need from me?"** — **BASMA:** "Questions. Hard ones. Ask them out loud."
> ► **"Can't you share it equally?"** — **BASMA:** "Equal is a word. It is not a measure."
> ► **"I'll sit with you."** — **BASMA:** "Thank you. You may drink first, and you will not."

**Scene 2: the claimants.** In the council hall, four speakers rise: a gardener with dirt on his hands, a caravan-lord in silk, a healer carrying a bowl, a tribal woman with a child at her knee.

**GARDENER:** "Without the gardens, there is no oasis in five years."
**CARAVAN-LORD:** "Without the caravans, there is no *tithe* in two."
**HEALER:** "Without water, the sick die in nine days. I have the list."
**TRIBAL WOMAN:** "We have walked this desert for ten thousand years, and nobody asked us what we needed."
> ► **"Gardener, what is the least you can spare?"** — He names it, shocked at himself.
> ► **"Caravan-lord, what do you carry that you could sell for water?"** — He flinches.
> ► **"Healer, who is first on the list?"** — She reads a name, and it is a child.

**Scene 3: the privacy of numbers.** In the long hush after, Basma and the player go to the dry Third Well and look into it.

**BASMA:** "Say it plainly. What would you do?"
> ► **"The sick first, then the children."** — A defensible order.
> ► **"A small share for everyone, and a hard look at the tithe."** — A shared ache.
> ► **"The gardens, because they keep the rest alive."** — A long-term gamble.

**Scene 4: the decree.** Basma stands in the dawn light and speaks.

**BASMA:** "The ration is this. And I say now, to the oasis: *it is not enough.*"
**BASMA:** "It will not be enough next year. Whoever feels cheated is right to feel it."
*She does not say it will be all right.*

**Outcomes and receipt.**
- The ration holds without riot. Whichever order the player argued becomes the *first draft* of Qadira's rationing law, to be revised each season by a council that now includes a gardener, a healer, a caravan-factor and a tribal speaker.
- **Receipt:** four stools set at the council table, and a new line at the end of the dawn recital: "and this is how it was divided."

<!-- quest
id: qst_sun_ration_council
title: The Ration Council
rank: A
type: Trial
giver: npc_basma_orlin
region: reg_sunscar
level: 138
act: 4
requires_rank: A
requires_quests: qst_sun_unpaid_tithe
reward: 33000 | 1660 | 142000
sets: sun_ration_done
summary: With two wells dry, a young keeper-elect must divide the oasis's last water among gardeners, caravans, the sick and the tribes, and asks a witness to sit with her.
objectives:
  talk npc_basma_orlin
  reach sunscar_council_hall
  talk npc_basma_orlin
  choice sick_shared_or_gardens
-->
