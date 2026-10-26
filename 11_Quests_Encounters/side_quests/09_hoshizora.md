# 11e-09 — Hoshizora, the Land Under the Star-Sky: Ten Side Quests (draft)

> *"Hoshizora's shrines are rebuilt every twenty years so that the gods stay curious. The last rebuilding was left unfinished."*
> — Gazetteer, Hoshizora

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light; quest 10 gives Kurogane a *reason*, which is a proposal.

**Region:** `reg_hoshizora` (Hoshizora City, the Bamboo Sea villages, the cedar mountains, the Oni Volcano). **Rank band:** C–A. **Tone:** graceful, reserved, funny at the edges, and very good at silence. Courtesy is a form of courage.

**Placement notes.**
- **Kurogane, the Oni Warlord**, is the region's Tyrant. He came down from the volcano *with a mask for every village he means to rule* and has taken three villages. No quest here kills Kurogane. Quests 4, 8 and 10 are about the masks, the villages and the man.
- Spirits are given seats at festivals and must be sent home at dawn. Spirit etiquette is a game rule: wrong manners give a spirit grounds for offence, never for violence.
- The **Eastern Shogunate** (Canon faction table) is seated in Hoshizora City. The Exalted reward is the legendary katana **Moonveil**; quest 7 is a swordsmith story and is *not* the source of Moonveil.
- **Suzune Kagura**'s arc (the Kitsune Isles, *Nine Tails, Nine Debts*) is not touched. Fox-spirits here are local and independent of her.
- Shrines are rebuilt every twenty years. The last rebuilding is unfinished. Quest 1 is about *why*.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Last Pillar | C | Exploration | Master Carpenter Daigo Hanamura | A tradition, a question |
| 2 | The Spirit Who Had No Seat | C | OddJob | Little Hana | A festival, a small kindness |
| 3 | The Kappa's Bow | C | Faction | Boatman Genji | Courtesy as a weapon |
| 4 | The Mask-Carver | B | Investigation | Okuni the Carver | Faces made to order |
| 5 | Fourteen People and a Festival | B | Faction | Headwoman Fumiko | A dying village hosts the gods |
| 6 | The Tengu's Test | B | Hidden | Tengu Soujo | The sword that does not strike |
| 7 | The Sword Given to the Gods | B | OddJob | Swordsmith Munetoshi | A masterwork, not for sale |
| 8 | The Masked Village | A | Faction | Priestess Aoi | A laugh that breaks a mask |
| 9 | The Hundredth Lantern | A | Hidden | Lantern-Keeper Shino | A century's procession |
| 10 | A Letter Written in Courtesy | A | Faction | Courier-Fox Benten | An oni, answered in verse |

## Cast (new supporting NPCs)

<!-- npc
id: npc_daigo_hanamura
name: Master Carpenter Daigo Hanamura
tier: major
race: Human
region: reg_hoshizora
settlement: Hoshizora City
role: Master shrine carpenter
backstory: A thin, grey-eyed master carpenter who has rebuilt eleven shrines in his life and has just been told the twelfth cannot be finished.
secret: He left one pillar bare on purpose and has never told anyone why.
-->
<!-- npc
id: npc_little_hana
name: Little Hana
tier: townsfolk
race: Human
region: reg_hoshizora
settlement: Bamboo Sea villages
role: Festival organiser, aged nine
backstory: A bossy, determined nine-year-old who has taken it upon herself to organise her village's spirit festival and has counted every seat twice.
-->
<!-- npc
id: npc_genji_boatman
name: Boatman Genji
tier: townsfolk
race: Human
region: reg_hoshizora
settlement: Bamboo Sea villages
role: River boatman
backstory: A weathered boatman who has been refused passage by a kappa three times this month and has begun to suspect it is his manners.
-->
<!-- npc
id: npc_okuni_carver
name: Okuni the Carver
tier: major
race: Human
region: reg_hoshizora
settlement: Kasumi village
role: Mask-carver
backstory: A quiet, gifted mask-carver who was ordered by Kurogane's agents to carve three hundred identical faces and who has been awake for twelve days.
-->
<!-- npc
id: npc_headwoman_fumiko
name: Headwoman Fumiko
tier: major
race: Human
region: reg_hoshizora
settlement: Mizu-no-sato
role: Headwoman of a village of fourteen
backstory: A small, fierce headwoman of a village that was once four hundred and is now fourteen, who has decided that the gods will be welcomed, whether the village survives or not.
-->
<!-- npc
id: npc_tengu_soujo
name: Tengu Soujo
tier: major
race: Tengu
region: reg_hoshizora
settlement: The cedar peaks
role: Tengu swordmaster
backstory: A lean, red-faced tengu swordmaster who has refused three hundred students and has asked for one more.
-->
<!-- npc
id: npc_munetoshi_smith
name: Swordsmith Munetoshi
tier: major
race: Human
region: reg_hoshizora
settlement: Hoshizora City
role: Master swordsmith
backstory: A broad, gentle master swordsmith who has forged forty swords and sold none of the good ones, because he believes a sword should be chosen by its owner, not its buyer.
-->
<!-- npc
id: npc_priestess_aoi
name: Priestess Aoi
tier: major
race: Human
region: reg_hoshizora
settlement: Kasumi shrine
role: Priestess of Kasumi shrine
backstory: A calm priestess whose village was taken by Kurogane a week ago and who has been walking its masked streets in the evenings, looking for one face.
-->
<!-- npc
id: npc_shino_lantern
name: Lantern-Keeper Shino
tier: major
race: Human
region: reg_hoshizora
settlement: Hoshizora City
role: Keeper of the Hundred Lanterns
backstory: A young lantern-keeper who has inherited a duty that comes once in a hundred years and who has been told, very late, that it is her turn.
-->
<!-- npc
id: npc_courier_benten
name: Courier-Fox Benten
tier: major
race: Fox-spirit
region: reg_hoshizora
settlement: The red bridge
role: Go-between and courier
backstory: A sleek, composed fox-spirit who carries letters between worlds and has never read one, and has been asked to carry an oni's.
-->

---

## 1. The Last Pillar

*C · Exploration · Hoshizora City · giver Master Carpenter Daigo Hanamura*

**The short version.** The great shrine of Hoshizora City is rebuilt every twenty years so that the gods stay curious. This time, one pillar was left bare. The priests say it is unlucky. Daigo wants to finish it.

**What is really going on.** The pillar was left bare **on purpose**. The old tradition, almost forgotten, says: *a shrine finished is a shrine dead.* The pillar is left unfinished so the gods will *keep working on it*. Daigo, who is old and afraid his craft is dying, has *forgotten* his own reason, until he rediscovers it in his master's notebook.

**Scene 1: the shrine.**

**DAIGO:** "Eleven shrines I have built. Eleven. And the twelfth is the one the priests will not bless."
**DAIGO:** "A pillar, bare. Uncarved. I left it, and I do not remember *why*."
**DAIGO:** "It is the first time in my life I have not known what I was doing."
> ► **"Why did you leave it?"** — **DAIGO:** "I have a feeling. But I cannot *name* it."
> ► **"The priests are worried?"** — **DAIGO:** "They say it is an *omen*."
> ► **"I'll help you find out."** — **DAIGO:** "Thank you. I am ashamed to ask."

**Scene 2: the notebook.** In an old timber storehouse, among stacks of dusty carpenter's tools, the player finds Daigo's master's journals, in a brittle hand.

*"My master told me: leave one pillar unfinished. I asked: why? He said: a god watches closest what is not done. A finished thing is a closed door."*
**DAIGO:** (reading aloud, slowly) "'A finished shrine is a shrine the gods stop visiting.'"
**DAIGO:** "...I *knew* that. I knew it forty years ago. I forgot."
> ► **"You didn't forget. You remembered with your hands."** — **DAIGO:** "...That is a kind thing to say."
> ► **"So the pillar stays bare?"** — **DAIGO:** "It *must*."
> ► **"Then tell the priests."** — **DAIGO:** "They will not *believe* me."

**Scene 3: the priests.** In the shrine hall, three robed priests listen, stony-faced.

**HIGH PRIEST:** "A bare pillar is an *insult* to the god."
**DAIGO:** "It is an *invitation.*"
**HIGH PRIEST:** "The old tradition is a *story*, not a *rule*."
> ► **"It's both."** — A long silence.
> ► **"Ask the god."** — **HIGH PRIEST:** "...How?"
> ► **"Let the pillar stand for one festival."** — **HIGH PRIEST:** "...One."

**Scene 4: the festival.** At the next festival, the bare pillar stands in a ring of lanterns. The spirits arrive, a parade of cranes, lanterns and small bright ghosts. One, a faint, shining figure in an old carpenter's robe, stops at the pillar and *runs a hand down it*.

**DAIGO:** (barely audible) "...Master."
*The figure smiles, nods, and fades into the dark.*

**Outcomes and receipt.**
- The pillar stays bare; the priests accept the tradition. If the player argued for finishing it, Daigo finishes and the shrine falls quiet.
- **Receipt:** a small, dust-free hollow in the bare pillar where a lantern is lit nightly; Daigo teaches a young apprentice the unfinished pillar.

<!-- quest
id: qst_hsz_last_pillar
title: The Last Pillar
rank: C
type: Exploration
giver: npc_daigo_hanamura
region: reg_hoshizora
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: hsz_pillar_resolved
summary: The great shrine's last pillar was left bare, and the priests call it unlucky. The carpenter has forgotten why he did it.
objectives:
  talk npc_daigo_hanamura
  reach hoshizora_shrine_storehouse
  choice leave_finish_or_festival
-->

---

## 2. The Spirit Who Had No Seat

*C · OddJob · the Bamboo Sea villages · giver Little Hana*

**The short version.** At the spirit festival every spirit gets a seat. Nine-year-old Hana has counted the seats three times. There are *seventy-one* seats and *seventy-two* spirits.

**What is really going on.** The extra spirit is a small **umbrella-spirit**, a one-legged paper umbrella with a single eye, who arrived late and is too shy to ask for a seat. He has *always* come to the festival, and always been given a seat by a grandmother who has died. Nobody remembered to save him one.

**Scene 1: the village green.**

**HANA:** "Seventy-one seats. Seventy-*two* spirits."
**HANA:** "I counted! Three *times!* Somebody has to stand. And that's *rude*."
**HANA:** "You're a hero. Fix it."
> ► **"Who's the extra?"** — **HANA:** "The little umbrella. He's always at the back."
> ► **"Why not squeeze in?"** — **HANA:** "Every seat is *measured.* A seat is a *promise*."
> ► **"I'll find one."** — **HANA:** "Good. A *proper* one."

**Scene 2: the search.** A short, cozy search through the village: an old chair at the baker's, a wobbly stool in a barn, a small cushion in a grandmother's chest. None *fit*.

**BAKER:** "A seat for a spirit? Take the stool. It's wobbly."
**HANA:** "A *wobbly* seat is an *insult*."
**GRANDMOTHER'S CHEST (a note inside):** *"For the little umbrella. Keep him a seat. — Grandmother."*

**Scene 3: the note.** Hana reads the note aloud. Her voice goes small.

**HANA:** "She... she *did* keep him one."
**HANA:** "I forgot. I forgot because she *died*."
**HANA:** "It's a *grandmother's seat*, in the chest."
*The cushion is small, red, worn, and perfectly umbrella-sized.*
> ► **"Give it to him."** — **HANA:** "I *will*."
> ► **"Tell him about her."** — **HANA:** "...He knows."
> ► **"Sit with him."** — **HANA:** "That's the *best* idea."

**Scene 4: the festival.** At dusk, seventy-two seats are laid. The little umbrella-spirit hops in, sees the cushion, freezes, and then, *very slowly*, bows so low his one eye touches the ground.

**UMBRELLA-SPIRIT:** *(a thin, paper-soft voice)* "Thank you. I thought... I thought she was *gone*."
**HANA:** "She is. But she *kept* your seat."
**UMBRELLA-SPIRIT:** "...Then she is *not* gone."

**Outcomes and receipt.**
- Every spirit has a seat. The umbrella-spirit lingers at the village each year; he becomes the festival's *door-keeper*.
- **Receipt:** a small red cushion on the festival bench; Hana is named "Seat-Keeper" and counts the seats *four* times next year.

<!-- quest
id: qst_hsz_spirit_no_seat
title: The Spirit Who Had No Seat
rank: C
type: OddJob
giver: npc_little_hana
region: reg_hoshizora
level: 60
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: hsz_seat_resolved
summary: A nine-year-old organiser has counted seventy-one seats and seventy-two spirits. The extra is a shy umbrella-spirit.
objectives:
  talk npc_little_hana
  reach hoshizora_village_green_dusk
  choice give_tell_or_sit
-->

---

## 3. The Kappa's Bow

*C · Faction · the river · giver Boatman Genji*

**The short version.** A kappa has refused Genji passage three times. The boatman suspects it is his manners. The kappa has a *specific* complaint.

**What is really going on.** Kappa have a hollow in their heads that holds water. When a person bows, the kappa *must* bow back, spilling the water. Genji, who is old and stiff, bows *shallowly*, an insult. The kappa is not angry. He is *afraid of dying*, because a spilled bowl is a death.

**Scene 1: the dock.**

**GENJI:** "Three times. Three times, he's blocked the ford."
**GENJI:** "I bow. I *do*. I'm a polite man."
**GENJI:** "He says it's the *wrong bow.* I do not understand."
> ► **"How do you bow?"** — **GENJI:** "Like *this*. A nod."
> ► **"Let me ask him."** — **GENJI:** "Please. And be *polite*."
> ► **"What's his name?"** — **GENJI:** "Kawataro. I think."

**Scene 2: the ford.** The river is clear and cold. On a stone mid-stream sits a small green creature with a dish-shaped hollow on his head, glaring.

**KAPPA:** "A nod. *A nod.* That is how you greet a *neighbour*? A *nod*?"
**KAPPA:** "I am a *river lord*. I am owed a *proper bow*."
**KAPPA:** "But don't you *dare* bow *deeply*. Don't you *dare*."
> ► **"Why not?"** — **KAPPA:** "Because I would have to *bow back*."
> ► **"What's wrong with bowing back?"** — **KAPPA:** (very quietly) "...The water."
> ► **"I understand."** — **KAPPA:** "Do you?"

**Scene 3: the compromise.** The player works out an arrangement: Genji will bow *to the water*, not to the kappa, as a gesture of respect; and the kappa will be given a *cup*, a lidded porcelain bowl, to keep his head-water safe for a moment while he bows.

**KAPPA:** (turning the cup over, suspicious) "...A lid."
**GENJI:** "For your... *dish.*"
**KAPPA:** "That is... a *very* thoughtful thing."
*Genji bows. Kawataro, after a moment, bows back, and the water in the cup does not spill.*

**Scene 4: the passage.** Genji's ferry crosses the ford. At the far bank, Kawataro waves his little green hand.

**KAPPA:** "Next time, bring *cucumbers*."
**GENJI:** "...Of course."
**KAPPA:** "And bring the *girl* who explains things."
**PLAYER:** (a small bow) "I am honoured."

**Outcomes and receipt.**
- The ford is open; Kawataro is a friendly river-lord who answers questions about the river. If the player insults him, he blocks the ford for a season.
- **Receipt:** a porcelain cup sits on the river-stone with a cucumber each dawn; Genji's ferry flies a small green flag.

<!-- quest
id: qst_hsz_kappa_bow
title: The Kappa's Bow
rank: C
type: Faction
giver: npc_genji_boatman
region: reg_hoshizora
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: hsz_kappa_resolved
summary: A kappa has blocked the ford three times. A boatman's bow is too shallow, and a deep bow would spill the water in the kappa's dish.
objectives:
  talk npc_genji_boatman
  reach hoshizora_kappa_ford
  choice cup_cucumber_or_insult
-->

---

## 4. The Mask-Carver

*B · Investigation · Kasumi village · giver Okuni the Carver*

**The short version.** Okuni has been ordered to carve three hundred identical masks for Kurogane. She has not slept in twelve days. She would like to know what they are *for*.

**What is really going on.** The masks are *not magic*. Kurogane's rule is simple: every villager wears a mask, and *the mask is a face that cannot change.* It makes a village *orderly* by removing the *faces* that argue. Kurogane's agents are also hunting for a *particular carver*, because the masks work best when carved by someone who *loves faces*.

**Scene 1: the workshop.**

**OKUNI:** "Three hundred. Identical. The same eyes, the same mouth. Calm, cold, perfect."
**OKUNI:** "I am a *carver of faces*. I've made kitsune masks, festival masks, the faces of the dead. I've never made the *same* face twice."
**OKUNI:** "I do not know what they are for. I only know they will hurt."
> ► **"Who ordered them?"** — **OKUNI:** "A man in a black coat. He smelled of ash."
> ► **"What happens when they're worn?"** — **OKUNI:** "I do not know. I fear to see."
> ► **"I'll find out."** — **OKUNI:** "Be careful. They carve with *forgetting.*"

**Scene 2: the village.** In Kasumi, the first masked villagers are gentle, quiet and *obedient*. A shopkeeper smiles from behind a pale face, but his voice is perfectly flat.

**SHOPKEEPER (masked):** "Welcome. Welcome. What do you require?"
**SHOPKEEPER:** "Peace is good. Order is good. All is *well*."
**PLAYER:** "Who gave you the mask?"
**SHOPKEEPER:** "A kind man. He said: *you will never be afraid again.*"
> ► **"Do you remember your name?"** — **SHOPKEEPER:** "...Welcome. Welcome."
> ► **"Take it off."** — **SHOPKEEPER:** "I cannot. I would be *afraid*."
> ► **"What do you fear?"** — **SHOPKEEPER:** "*Nothing.* That is the *gift*."

**Scene 3: the flaw.** Back in the workshop, Okuni examines a mask under a lamp. A hairline crack runs along the cheek.

**OKUNI:** "I cut that one with my left hand. The knife slipped."
**OKUNI:** "The mask *didn't work*. The man who tried it *wept*."
**OKUNI:** "It is a face carved with *love*. It cannot be a mask of *forgetting*."
> ► **"Carve them all with love."** — **OKUNI:** "That would take a lifetime."
> ► **"Carve one flaw into each."** — **OKUNI:** "...A *crack*."
> ► **"Burn them."** — **OKUNI:** "And they will be made *again*."

**Scene 4: the three hundred.** Okuni carves, over a long night, a single tiny, almost invisible *smile* into each mask's corner. When Kurogane's agent collects them at dawn, the masks look perfect, but each one leaks, very faintly, a trace of the wearer's own face.

**AGENT:** "...They seem *fine.*"
**OKUNI:** (very calmly) "I did my best."
*As the carts roll away, the player and Okuni look at each other. She is smiling. It is a very small smile.*

**Outcomes and receipt.**
- The masks work *less well*; over the following weeks, villagers begin to *remember*. If the player burns them instead, Kurogane's agents carve new ones elsewhere.
- **Receipt:** Okuni's workshop has a single un-smiling mask hanging in the window, which she touches each day.

<!-- quest
id: qst_hsz_mask_carver
title: The Mask-Carver
rank: B
type: Investigation
giver: npc_okuni_carver
region: reg_hoshizora
level: 94
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: hsz_carver_resolved
summary: A carver has been ordered to make three hundred identical masks for Kurogane. The masks work best when carved without love.
objectives:
  talk npc_okuni_carver
  reach hoshizora_kasumi_village
  choice love_crack_or_burn
-->

---

## 5. Fourteen People and a Festival

*B · Faction · Mizu-no-sato · giver Headwoman Fumiko*

**The short version.** Mizu-no-sato was a village of four hundred. It is a village of fourteen. The spirit festival is tomorrow, and by tradition, if a village does not welcome the spirits, the spirits *forget* it.

**What is really going on.** If the spirits forget the village, the village's *shrine, its fields and its dead* lose their protection. Fumiko needs a festival of *at least a hundred people*, music, food and lanterns. She has fourteen. The player has until dusk.

**Scene 1: the green.**

**FUMIKO:** "Four hundred, when I was a girl. Fourteen, now."
**FUMIKO:** "The young ones went to the city. The old ones died. I am the youngest, and I am *sixty-three.*"
**FUMIKO:** "The festival is tomorrow. If we do not hold it, the spirits will *forget* us. And I will not be forgotten."
> ► **"What do you need?"** — **FUMIKO:** "Dancers. Drummers. A feast. A hundred souls."
> ► **"How long do I have?"** — **FUMIKO:** "Until the first lantern is lit."
> ► **"I'll find them."** — **FUMIKO:** "Thank you. *Please.*"

**Scene 2: the recruitment.** The player travels from village to village, asking for help. Each response is different:
- **A drum-troupe** from the next valley agrees, if the player will carry their instruments.
- **A mountain-kitchen** offers a hundred rice-balls for the price of a story.
- **A band of travelling monks** offers chanting for a night's lodging.
- **A young woman** from a vanished village returns, hesitantly, to help.

**YOUNG WOMAN (Sayo):** "I left. I said I'd never come back."
**SAYO:** "I was *ashamed.*"
**FUMIKO (later):** "You came back. That's all that matters."

**Scene 3: the dusk.** By sunset, a hundred and twelve strangers stand on the village green. Lanterns are lit. A drum begins. Slowly, from the bamboo, a procession of spirits arrives: cranes, lanterns, foxes, a small procession of paper umbrellas.

**FUMIKO:** (whispering) "They *came*."
**SPIRIT-ELDER:** *(a deep, mild voice)* "Mizu-no-sato. It has been *long*."
**FUMIKO:** "We kept your seat."
**SPIRIT-ELDER:** "I know. I *saw* the lanterns."
> ► **"Dance."** — The spirits join; the whole green turns.
> ► **"Offer the feast."** — The spirits taste each dish.
> ► **"Tell them the story."** — The spirits listen.

**Scene 4: the dawn.** At first light, the spirits must be sent home. Fumiko rings a small bell.

**FUMIKO:** "Go well. Come again."
**SPIRIT-ELDER:** "We *will.* And we will bring *others*."
*As the last lantern fades, Fumiko sits down on the shrine steps, utterly exhausted.*
**FUMIKO:** "...We held it."

**Outcomes and receipt.**
- The festival is held and the spirits remember the village. Sayo and two other young people stay.
- **Receipt:** a new row of lanterns on the shrine path; the village's population is *seventeen*.

<!-- quest
id: qst_hsz_fourteen_festival
title: Fourteen People and a Festival
rank: B
type: Faction
giver: npc_headwoman_fumiko
region: reg_hoshizora
level: 96
act: 4
requires_rank: B
reward: 12000 | 700 | 52000
sets: hsz_festival_resolved
summary: A village of fourteen must host the spirit festival tomorrow, or the spirits will forget it.
objectives:
  talk npc_headwoman_fumiko
  reach hoshizora_neighbouring_villages 4
  choice dance_feast_or_story
-->

---

## 6. The Tengu's Test

*B · Hidden · the cedar peaks · giver Tengu Soujo*

**The short version.** A tengu swordmaster has refused three hundred students. He has asked for one more. He says the player is *almost* ready.

**What is really going on.** Soujo's art is *the sword that does not strike*: a technique of reading, deflecting and *ending* a fight without a blow. It is the opposite of every school in Hoshizora. He wants a student who has *killed enough* to understand that it is not enough.

**Scene 1: the peak.**

**SOUJO:** "Three hundred students. All came to *win*. None could *stop*."
**SOUJO:** "You are *almost* ready. That is the most dangerous state a swordsman can be in."
**SOUJO:** "I will teach you. But first, you must *lose*."
> ► **"Lose to whom?"** — **SOUJO:** "To me. And you will not be *angry*."
> ► **"What's the technique?"** — **SOUJO:** "A sword that does not strike."
> ► **"I accept."** — **SOUJO:** "Hmph. You do not know what you are accepting."

**Scene 2: the duel.** On a narrow wooden bridge over a cloud-filled gorge, Soujo stands with a wooden practice-blade. The player is given the same.

**SOUJO:** "Strike me."
*The player strikes. Soujo, impossibly, is not there.*
**SOUJO:** "Again."
*(Gameplay: a pattern-reading duel. The player's strikes always miss. The challenge is to *stop striking* and to learn the opponent's rhythm.)*
> ► **(Keep striking.)** — The blade is knocked aside, again and again.
> ► **(Wait.)** — Soujo steps forward, *surprised*.
> ► **(Lower the blade.)** — Soujo's wooden sword stops an inch from your throat.

**SOUJO:** "...There."
**SOUJO:** "The first lesson. The moment you stopped trying to *win*, I could not *beat* you."

**Scene 3: the second lesson.** Over three days on the peak, Soujo teaches: stillness, breath, the angle of an opening, and the courage of *not cutting*. He is gruff, funny and wholly without mercy.

**SOUJO:** "A sword is a *question*. The strike is a bad answer."
**SOUJO:** "A good swordsman asks the question *so well* that the opponent *answers himself*."
**SOUJO:** "...Do you understand?"
> ► **"Not yet."** — **SOUJO:** "*Good.*"
> ► **"I think so."** — **SOUJO:** "Then you are *wrong*. Again."

**Scene 4: the final test.** At dusk on the third day, three bandits ambush a pilgrim on the peak path. Soujo, arms folded, watches the player.

**SOUJO:** "Now. Without a *strike.*"
*A long, tense scene in which the player ends a fight with three men without a single blow: by stance, by timing, by presence.*
**BANDIT LEADER:** (staring, lowering his blade) "...What *are* you?"
**PLAYER:** "A student."

**Outcomes and receipt.**
- The player learns a new stance; Soujo takes them as his *four hundred and first* student, and the last.
- **Receipt:** a small wooden sword hangs on the player's wall; Soujo sends a letter each spring, never longer than a line.

<!-- quest
id: qst_hsz_tengu_test
title: The Tengu's Test
rank: B
type: Hidden
giver: npc_tengu_soujo
region: reg_hoshizora
level: 100
act: 4
requires_rank: B
reward: 13000 | 760 | 56000
sets: hsz_tengu_resolved
summary: A tengu swordmaster teaches a technique that does not strike. He asks the player to lose first.
objectives:
  talk npc_tengu_soujo
  reach hoshizora_cedar_bridge
  choice strike_wait_or_lower
-->

---

## 7. The Sword Given to the Gods

*B · OddJob · Hoshizora City · giver Swordsmith Munetoshi*

**The short version.** Munetoshi has forged a masterwork. He will not sell it. Kurogane's agents have offered him a fortune. He asks the player to carry it to a shrine and *give it to the gods*.

**What is really going on.** The sword is the finest he has ever made. He believes that a sword that cannot choose its owner should *belong to no one*. The oni want it as a *prize*. He would rather it rust in a shrine than hang in a warlord's hall.

**Scene 1: the forge.**

**MUNETOSHI:** "Forty swords. Thirty-nine, sold. One, kept."
**MUNETOSHI:** "The one I kept is the best thing my hands have ever made. I know it. And I cannot *sell* it."
**MUNETOSHI:** "A sword should *choose* its owner. This one has not chosen."
> ► **"What do the oni want?"** — **MUNETOSHI:** "To *own* it."
> ► **"What do you want?"** — **MUNETOSHI:** "To give it to something that will not *use* it."
> ► **"I'll carry it."** — **MUNETOSHI:** "Thank you. Do not draw it."

**Scene 2: the journey.** A long road through the cedar mountains, with the sword wrapped in silk across the player's back. It hums, very faintly, in the dark. Twice, oni scouts stalk the road; twice, the player avoids them.

**ONI SCOUT:** "You carry something *sharp*."
**PLAYER:** "A gift."
**ONI SCOUT:** "For *whom*?"
**PLAYER:** "...For the gods."
**ONI SCOUT:** (hesitating, then laughing) "*Ha.* That's a *good* one."

**Scene 3: the shrine.** At a mountain shrine, in a ring of ancient cedars, a small altar stands under a plain wooden roof. The air is very still.

**PRIEST:** "A sword, given to the gods. It has not been done in a hundred years."
**PRIEST:** "It is not *destroyed*. It is *rested*."
> ► **"Lay it on the altar."** — The sword's hum falls silent.
> ► **"Draw it first."** — A blade of pale moonlight, utterly clean.
> ► **"Say a prayer."** — The cedars rustle.

**Scene 4: the rest.** The player lays the sword on the altar. A cloud of fine, pale mist rises. When it clears, the sword is *there*, whole, silent, utterly at peace, as if it had always lain there.

**PRIEST:** "It is *given*."
**PRIEST:** "No one may take it. No one may *draw* it. Until the gods choose."
**MUNETOSHI (later, at the forge):** "I feel... *lighter.*"
**MUNETOSHI:** "I have never *made* anything so beautiful, and then *let it go*."

**Outcomes and receipt.**
- The sword rests at the shrine; if the player *draws it*, it burns with moonlight for a heartbeat and is silent again.
- **Receipt:** a small plaque at the shrine: *"Given by Munetoshi."* This sword is not **Moonveil**, the Shogunate's legendary katana; the two are unrelated.

<!-- quest
id: qst_hsz_sword_given
title: The Sword Given to the Gods
rank: B
type: OddJob
giver: npc_munetoshi_smith
region: reg_hoshizora
level: 102
act: 4
requires_rank: B
reward: 14000 | 800 | 60000
sets: hsz_sword_resolved
summary: A swordsmith will not sell his masterwork to the oni. He asks the player to give it to the gods instead.
objectives:
  talk npc_munetoshi_smith
  reach hoshizora_mountain_shrine
  choice lay_draw_or_pray
-->

---

## 8. The Masked Village

*A · Faction · Kasumi · giver Priestess Aoi*

**The short version.** Kasumi was taken a week ago. Everyone wears a mask. Aoi walks its streets every evening, looking for a single face.

**What is really going on.** The village is *peaceful*. Terribly so. Aoi's goal is not to free it, but to find **one** villager, a child named **Mika**, who is *not wearing a mask*, and who has *hidden herself* in the shrine's bell-tower, laughing at things the masked adults cannot see.

**Scene 1: the street.**

**AOI:** "A week. A week since the masks came. And not one person has *spoken* in their own voice."
**AOI:** "Except... a *laugh*. I heard it. From the bell-tower. A child's."
**AOI:** "I want to *find her* before the agents do."
> ► **"Why a child?"** — **AOI:** "Children cannot hold a mask. They *laugh*."
> ► **"What can I do?"** — **AOI:** "Walk with me. Quietly. They will not notice you if you *pretend*."
> ► **"What if she's gone?"** — **AOI:** "Then I will find the *laugh* again."

**Scene 2: the walk.** A long, eerie stealth-and-dialogue sequence through the quiet, orderly streets. Masked villagers bow politely as the player passes. Their voices are hollow.

**VILLAGER:** "Welcome. All is well."
**VILLAGER 2:** "There is no fear. There is no sorrow. There is no *laughter*."
**PLAYER:** "Why no laughter?"
**VILLAGER 2:** "It is... *unnecessary.*"

**Scene 3: the bell-tower.** At the top of a long, winding staircase, in the dusty shadows, a small girl in a plain kimono sits cross-legged on the floor, a paper crane in her hands.

**MIKA:** "...Are you the lady with the nice voice?"
**AOI:** "I am."
**MIKA:** "I didn't put it on. I *tried*. It was too *tight.*"
**MIKA:** "And then I laughed, and everyone looked."
> ► **"You're very brave."** — **MIKA:** "I'm *scared*."
> ► **"May I sit?"** — **MIKA:** "Okay."
> ► **"Do you want to go home?"** — **MIKA:** "...This is home."

**Scene 4: the laugh.** The player and Aoi lead Mika down into the square. The masked villagers turn as one, all eyes empty. Mika, in a very small voice, tells a joke.

**MIKA:** "...Why did the tanuki cross the road?"
**MIKA:** "...To get to the *other tanuki*!"
*A pause. Then, in the crowd, a man *snorts.* Then a woman. A cough. A choke.*
*One by one, the masks crack, and fall.*
**VILLAGER (unmasked, weeping):** "...What was I *doing*?"

**Outcomes and receipt.**
- Kasumi is *unmasked* by laughter; Kurogane's agents flee. If the player rushes, the masks hold, and Mika is smuggled to the next village.
- **Receipt:** the village bell is rung every dawn by Mika; a tanuki statue stands in the square, grinning.

<!-- quest
id: qst_hsz_masked_village
title: The Masked Village
rank: A
type: Faction
giver: npc_priestess_aoi
region: reg_hoshizora
level: 128
act: 4
requires_rank: A
requires_quests: qst_hsz_mask_carver
reward: 30000 | 1500 | 130000
sets: hsz_village_resolved
summary: A village has been masked by Kurogane. A priestess searches its streets for the one child who is still laughing.
objectives:
  talk npc_priestess_aoi
  reach hoshizora_kasumi_bell_tower
  choice laugh_smuggle_or_fight
-->

---

## 9. The Hundredth Lantern

*A · Hidden · Hoshizora City · giver Lantern-Keeper Shino*

**The short version.** Once in a hundred years, a procession of a hundred lanterns walks from the old shrine to the shogun's castle. Ninety-nine are lit. The hundredth must be carried by *someone who does not belong*.

**What is really going on.** The procession honours *everyone who was forgotten*: the unnamed dead, the lost, the exiled. The hundredth lantern is for the one person *not remembered by any lantern*. Shino has been told it is her turn. She is terrified. She wants to give it to the player.

**Scene 1: the shrine.**

**SHINO:** "A hundred lanterns. Once a century. My grandmother's grandmother carried the last."
**SHINO:** "I am meant to carry the hundredth. I am *twenty-two*. I do not know *whom* it is for."
**SHINO:** "The old record says: *the one who belongs nowhere.* I think that is *you*."
> ► **"Why me?"** — **SHINO:** "You came from another world. That is the *definition*."
> ► **"What does the lantern do?"** — **SHINO:** "It *remembers*."
> ► **"I'll carry it."** — **SHINO:** "Thank you. I will walk beside you."

**Scene 2: the procession.** At dusk, a hundred lantern-bearers line up on the old road, a long ribbon of soft gold. Ninety-nine are carried by priests, children, fishermen, soldiers. The hundredth is a plain white paper lantern, unlit.

**SHINO:** "It lights when it finds who it is for."
**SHINO:** "Walk."
*(Gameplay: a long, quiet walk through the city with the lantern. NPCs along the route bow, weep, or whisper. The lantern remains dark.)*

**Scene 3: the road.** Along the road, at six moments, the lantern *flickers*. At each stop, a spirit steps out of the shadows: a drowned fisherman, a nameless soldier, a woman in an old court-robe, a child in a rice-field.

**SPIRIT:** "Do you remember me?"
**PLAYER:** "...No."
**SPIRIT:** "Neither do I."
*The lantern glows. The spirit smiles, bows, and steps into the line.*
> ► **(Speak to each spirit.)** — A short, tender scene each time.
> ► **(Walk on, in silence.)** — The spirits fall into line anyway.

**Scene 4: the castle.** At the shogun's gate, the hundredth lantern, still unlit, is raised.

**SHINO:** "Who is it for?"
*A long silence. Then the lantern, very slowly, lights from the *inside*, a clear, warm gold, brighter than any of the others.*
**SHINO:** (very quietly) "...It's for *you*."
**SHINO:** "It was always for the one who came *from nowhere* and stayed anyway."

**Outcomes and receipt.**
- The procession ends; the shogun receives the player as an honoured guest. The hundredth lantern is placed in the shrine, lit.
- **Receipt:** a small golden lantern hangs in the player's home: *the hundredth*, which never goes out.

<!-- quest
id: qst_hsz_hundredth_lantern
title: The Hundredth Lantern
rank: A
type: Hidden
giver: npc_shino_lantern
region: reg_hoshizora
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: hsz_lantern_resolved
summary: Once a century a hundred lanterns walk to the shogun's castle. The hundredth must be carried by someone who belongs nowhere.
objectives:
  talk npc_shino_lantern
  reach hoshizora_lantern_road 6
  reach hoshizora_shogun_gate
  choice speak_silence_or_pause
-->

---

## 10. A Letter Written in Courtesy

*A · Faction · the red bridge · giver Courier-Fox Benten*

*Best played after quests 4 and 8.*

**The short version.** An oni warlord has sent a letter. It is perfectly polite. It invites the player to *write back*.

**What is really going on (proposal).** Kurogane is not cruel. He is *terrified*. His people, the oni of the volcano, have been *forgetting their faces* for three generations. The masks are not a weapon. They are an attempt to give his people *faces they will not lose*. He cannot say this to the shogun, who would refuse. He can say it to a stranger.

**Scene 1: the bridge.**

**BENTEN:** "I carry letters. I do not *read* them. It is my one rule."
**BENTEN:** "But I have been asked to carry *this* one to a stranger. And I have been asked to bring back a *reply*."
**BENTEN:** "It is a letter from *the oni*. In perfect calligraphy."
> ► **"Read it to me."** — **BENTEN:** "I will not. But I will *hold* it."
> ► **"What does he want?"** — **BENTEN:** "A conversation."
> ► **"I'll answer."** — **BENTEN:** "Good. Be *polite*."

**Scene 2: the letter.** The player reads:

*"Honoured Stranger: You have walked in my villages and broken my masks. I am not angry. I am curious. I have done a thing I am ashamed of, and I wish to explain it to someone who is not afraid of me. Would you grant me a letter? — Kurogane, in the house of the mountain."*

**BENTEN:** "He signs himself *in the house of the mountain.* That is the old oni formula for *'alone'.*"
> ► **"Write back."** — The player composes a reply.
> ► **"Burn it."** — **BENTEN:** "...A *wasteful* choice."
> ► **"Show it to the shogun."** — **BENTEN:** "He will not read it."

**Scene 3: the correspondence.** Over three nights, the player and Kurogane exchange letters through Benten. Each is a short scene. Each reveals more.
- **Letter 1:** *"My people are forgetting their faces. I did not know how to say it."*
- **Letter 2:** *"The masks are not a punishment. They are a promise: you will always know who you are."*
- **Letter 3:** *"I do not ask you to forgive me. I ask you to understand why I could not ask."*

> ► **(Answer each in verse, in prose, or in silence.)** — Each reply changes the oni's tone.

**Scene 4: the last letter.** On the third night, Kurogane's final letter arrives. It is very short.

*"I have never had anyone to write to. Thank you. I will not forget your handwriting. — K."*

**BENTEN:** "Whatever you wrote, he has *kept it*."
**BENTEN:** "He sleeps with it under his pillow."

**Outcomes and receipt.**
- The correspondence does *not* end the siege; Kurogane remains the Tyrant. But his pre-fight dialogue changes, and a *peaceful* resolution to the Tyrant fight becomes possible for the first time (a story option in the main Hoshizora arc).
- **Receipt:** three letters in the player's Journal; Benten stays on the bridge, waiting.
- **Proposal (Canon §6):** Kurogane's motive (an oni people forgetting their faces).

<!-- quest
id: qst_hsz_letter_courtesy
title: A Letter Written in Courtesy
rank: A
type: Faction
giver: npc_courier_benten
region: reg_hoshizora
level: 136
act: 4
requires_rank: A
requires_quests: qst_hsz_masked_village
reward: 34000 | 1700 | 150000
sets: hsz_letter_resolved
summary: An oni warlord has sent a perfectly polite letter. It asks for a reply, and for understanding.
objectives:
  talk npc_courier_benten
  reach hoshizora_red_bridge
  choice verse_prose_or_silence
-->
