# 11e-36 — Lumbaya, the Temple Jungle: Ten Side Quests (draft)

> *"We do not say their names after dark. We hum them. The dead do not mind a tune."*
> — Gazetteer, Lumbaya

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 7 and 10 plant unexplained seeds.

**Region:** `reg_lumbaya` (the temple villages, the Sky Temples, the Root Stair, the Night Market). **Rank band:** B–A. **Tone:** warm, loud, musical, family-crowded, with a held breath at dusk.

**Placement notes.**
- **The Nightmother** is the region's Tyrant. Her nightshifters wear the faces of people you love. No quest here finds, fights or unmasks her, and none says why she wants the temples.
- Customs the quests rely on: villages are led by a council of elders and a temple-keeper; music goes with every task and every village has its own songs; families share everything; **the dead are never named after dark** (they are hummed); the old star alignments are no longer fully understood.
- **Open questions left open.** Why the temple roofs were torn off *from the inside;* what the star alignments did; what the nightshifters are. Quest 3 tests one alignment and proves nothing. Quest 7 and quest 10 are labelled seeds.
- **Rank note.** Quests 1, 2, 4, 5 and 8 are rank B (levels 86-119); 3, 6, 7, 9 and 10 are rank A (levels 120+). Rewards follow the neighbouring B and A files (B about 10-12k gold, 600-740 GP; A about 29-35k gold, 1,450-1,700 GP).

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Question Only He Would Know | B | Investigation | Sefa Rootsong | A wife and a very careful question |
| 2 | Counting the Children | B | Faction | Elder Mabu Fernwake | A dusk ritual and a tired mother |
| 3 | The Fourth Alignment | A | Exploration | Temple-Keeper Oruna Starcount | Lighting a lamp the old way |
| 4 | Her Mother's Face | B | Hidden | Kiki Lowcanopy | A child who saw something |
| 5 | A Name to Hum | B | OddJob | Widow Calu Reedflute | Grief with a tune in it |
| 6 | The Night Market Stall | A | Investigation | Tavo Nightbasket | A bargain with a smiling thing |
| 7 | What the Root Stair Climbs To | A | Exploration | Stair-Warden Imeru Figroot | A roofless room |
| 8 | Leaf, Bark and Fever | B | Gathering | Healer Zanu Brightbark | A sick village and a flute |
| 9 | A Song for a Password | A | Faction | Auntie Lowa Drumhand | Songs as locks |
| 10 | Auntie Nokoma Has Not Aged | A | Hidden | Nokoma's grand-niece, Ysa | A kindness that cannot be proven |

## Cast

<!-- npc
id: npc_sefa_rootsong
name: Sefa Rootsong
tier: major
race: Human
region: reg_lumbaya
settlement: Lumbaya temple villages
role: Farmer who fears her husband has been replaced
backstory: A sturdy, sensible rice-farmer of forty who has loved her husband Dano for twenty years and has begun, to her own shame, to watch him eat.
-->
<!-- npc
id: npc_mabu_fernwake
name: Elder Mabu Fernwake
tier: major
race: Human
region: reg_lumbaya
settlement: Lumbaya temple villages
role: Elder who leads the dusk count
backstory: A broad, patient elder who has counted the children of Lowriver Village at dusk every day for eleven months and has never once let his voice shake.
-->
<!-- npc
id: npc_oruna_starcount
name: Temple-Keeper Oruna Starcount
tier: major
race: Human
region: reg_lumbaya
settlement: The Sky Temples
role: Temple-keeper who wants to restore the star alignments
backstory: A lean, stubborn temple-keeper in her fifties who learned the star alignments from the last keeper's notebooks and knows she may be getting them wrong.
-->
<!-- npc
id: npc_kiki_lowcanopy
name: Kiki Lowcanopy
tier: townsfolk
race: Human
region: reg_lumbaya
settlement: Lumbaya temple villages
role: Child who saw a face
backstory: A serious seven-year-old with a missing front tooth who says she saw a woman in the mangroves with her mother's face, and that the woman was not warm.
-->
<!-- npc
id: npc_calu_reedflute
name: Widow Calu Reedflute
tier: townsfolk
race: Human
region: reg_lumbaya
settlement: Lumbaya temple villages
role: Widow who wants to say a name
backstory: A small, cheerful widow of seventy who has not spoken her husband's name aloud in a year, because the law of the village says only by day, and she sleeps by day now.
-->
<!-- npc
id: npc_tavo_nightbasket
name: Tavo Nightbasket
tier: major
race: Human
region: reg_lumbaya
settlement: The Night Market
role: Fruit-seller who went to the Night Market once
backstory: A jumpy, soft-voiced fruit-seller who walked into the Night Market by mistake three weeks ago, bought something, and has not been able to pay for it since.
-->
<!-- npc
id: npc_imeru_figroot
name: Stair-Warden Imeru Figroot
tier: major
race: Human
region: reg_lumbaya
settlement: The Root Stair
role: Warden of the Root Stair
backstory: A weathered climber who has kept the Root Stair clear of vines for thirty years and has never reached the top, because the fig tree has always grown a step ahead of her.
-->
<!-- npc
id: npc_zanu_brightbark
name: Healer Zanu Brightbark
tier: major
race: Human
region: reg_lumbaya
settlement: Lumbaya temple villages
role: Village healer
backstory: A brisk, laughing healer who plays the double flute while she works and has run out of silverbark in the middle of a river-fever outbreak.
-->
<!-- npc
id: npc_lowa_drumhand
name: Auntie Lowa Drumhand
tier: major
race: Human
region: reg_lumbaya
settlement: Lumbaya temple villages
role: Song-keeper of three villages
backstory: A round, thunder-voiced song-keeper who knows two hundred and eleven songs and has begun to teach them in a new way, as locks.
-->
<!-- npc
id: npc_ysa_nokoma_kin
name: Ysa Nokoma-Kin
tier: townsfolk
race: Human
region: reg_lumbaya
settlement: Lumbaya temple villages
role: Grand-niece of Auntie Nokoma
backstory: A quiet nineteen-year-old who notices that her great-aunt Nokoma, who raised her, looks exactly as she did in the village paintings from sixty years ago.
-->

---

## 1. A Question Only He Would Know

*B · Investigation · a rice village · giver Sefa Rootsong*

**The short version.** Sefa believes her husband Dano may have been replaced by a nightshifter. The old advice is to ask something only he would know. She has asked three questions, and he has answered all three, and she is not sure that is good news.

**What is really going on.** Dano is Dano. He has been quietly working himself into the ground because he heard that the nightshifters study families, and he has been trying to be *more himself* than ever, a performance that makes him seem strange. The player's job is to help Sefa find a question no performance can answer, and to see which answer she actually needs.

**Scene 1: the paddy.**

**SEFA:** "Dano. Twenty years. He sings when he plants. He hasn't sung in nine days."
**SEFA:** "Then last night he *sang.* The same song. Every note. Too *neat.*"
**SEFA:** "I've asked him his mother's name, the name of the dog, the colour of our door. He knew all of it."
> ► **"What do you want from me?"** — **SEFA:** "A better question."
> ► **"Have you told the elders?"** — **SEFA:** "And have them *test* him with knives? No."
> ► **"I'll help you ask."** — **SEFA:** "Thank you. Stay near the door."

**Scene 2: the day.** The player works beside Dano all afternoon, hauling water and netting the fish-traps. He is polite, tireless and watchful, and he looks at the player's hands as if learning them. Nothing about him is wrong. Everything about him is *careful.*

**DANO (low, to the player):** "You're the Guild one. Does she think I'm one of *them?*"
**DANO:** "I've tried so hard to be the man she married, I think I've forgotten how."
> ► **"She loves you either way."** — **DANO:** "Then why does she watch me eat?"
> ► **"Stop performing."** — **DANO:** "I don't know how."
> ► **"What do you two never talk about?"** — **DANO:** "...The baby."

**Scene 3: the question.** At dusk, in the doorway, with the lamp lit and the family drums quiet, Sefa asks.

**SEFA:** "The night our first one didn't come. What did you say to me? I've never told a soul."
**DANO:** (a long silence; he is crying) "I said, *'Then we'll plant a tree for her.'* And you said it was a foolish thing to say."
**SEFA:** "...It was the only thing."
*Down by the river, someone is humming a name. Neither of them looks round.*
> ► **(Step outside and leave them.)** — The door closes softly.
> ► **(Stay and say nothing.)** — Sefa takes Dano's hand across the lamp.
> ► **(Tell Sefa the question could never prove it.)** — **SEFA:** "I know. I just wanted him to *say* it."

**Scene 4: the tree.** Next morning there is a seedling in the yard, a young mango, with a small hand-carved tag no one has written on.

**Scene 3b: the neighbours.** News travels in Lumbaya faster than a drum. By the second evening three aunts, a cousin and the village goat have all offered opinions on whether Dano is Dano.

**AUNT:** "Put him in the river. A copy floats."
**SEFA:** "Nobody is putting my husband in the river."
**AUNT:** "Then ask him to sing the planting song backwards."
**SEFA:** "*Nobody* sings it backwards, you silly woman."
*The player quietly steers the aunts back toward the kitchen with a plate of fried plantain. A village that shares everything also shares its fear, and the kindest thing is to give it something else to do with its hands.*
> ► **"Thank you for caring."** — The aunts glow, and go quiet.
> ► **"This is between the two of them."** — A rustle of offence, then respect.

**Outcomes and receipt.**
- Dano is Dano. The couple begins to talk. If the player insists on a second test, Dano passes it and goes quiet for a week.
- **Receipt:** an unmarked tag on a young mango tree. Dano sings again at planting, a little off-key.

<!-- quest
id: qst_lum_question_he_knew
title: A Question Only He Would Know
rank: B
type: Investigation
giver: npc_sefa_rootsong
region: reg_lumbaya
level: 90
act: 4
requires_rank: B
reward: 10400 | 610 | 45000
sets: lum_question_done
summary: A farmer's wife has asked her husband three questions to prove he is himself. He has answered them all, and she is still afraid.
objectives:
  talk npc_sefa_rootsong
  reach lumbaya_rice_village_doorway
  choice leave_stay_or_say
-->

---

## 2. Counting the Children

*B · Faction · Lowriver Village · giver Elder Mabu Fernwake*

**The short version.** Every dusk, Lowriver counts its children, out loud, in a circle. Mabu has done the count for eleven months. The village is losing its voice for it, and a nightshifter has already walked through the ring once.

**What is really going on.** A count is not proof of anything. A nightshifter could be counted too. What the ring really does is make sure every child is *looked at,* by a name and a face, once a day. The player's job is to help the village keep the ritual without letting fear harden it into suspicion.

**Scene 1: the circle.**

**MABU:** "Forty-one children. Forty-one voices. It has been forty-one for eleven months. I say it each night like a prayer."
**MABU:** "Last week it was forty-two for a minute. A girl nobody knew, at the back, singing the count along."
**MABU:** "She walked out when I looked at her. *Smiling.*"
> ► **"What do you need?"** — **MABU:** "Another pair of eyes. And for the mothers to *stop shouting at each other.*"
> ► **"Why a circle?"** — **MABU:** "A circle has no back row."
> ► **"I'll stand the count."** — **MABU:** "Good. Bring your voice."

**Scene 2: the mothers.** The player spends two days among Lowriver's families. The count has made everyone sharp. One mother, Ketu, has stopped letting her daughter out of arm's reach. Another family has accused a neighbour of a "wrong smile."

**KETU:** "You'd do the same. Don't tell me you wouldn't."
**KETU:** "I count mine seven times a day. Mabu counts them once. I don't trust once."
> ► **"Counting seven times won't keep her safe."** — **KETU:** "Then what will?"
> ► **"What happens to a child who is watched all day?"** — **KETU:** "...She stops running."
> ► **"Then let the village count with you."** — **KETU:** "...That might do."

**Scene 3: the dusk.** On the third night the circle is wider: grandparents, cousins and fishers all standing, children in the middle, the count passed round hand to hand so no single voice carries it. Mabu begins to hum under it, steadying.

**CHILDREN (counting, off-key, a little silly):** "...*Thirty-nine, forty, forty-one!*"
*At the edge of the torchlight, a figure stands at the back. It is exactly the right height for a child. It does not sing.*
> ► **(Look at it steadily, and say nothing.)** — The figure turns away.
> ► **(Call out, "Who are you?")** — The ring breaks; children scream.
> ► **(Ask the nearest child to say the figure's name.)** — **CHILD:** "There isn't one."

**Scene 4: the quiet.** Whichever way it goes, the figure leaves. Mabu finishes the count. Forty-one.

**MABU:** (very softly) "Forty-one. Thank you. Go home and sleep."

**Scene 2b: Ketu's kitchen.** Late that night, after the rest of the village has gone to bed, Ketu comes to the player's mat with a bowl of cold rice and does not speak for a while.

**KETU:** "My sister's boy was counted every night too. Then one night he was forty-two."
**KETU:** "She stopped counting the day after. I don't think she has slept since."
**KETU:** "I'm not a hard woman. I'm a frightened one. Is there a difference?"
> ► **"Fear is a fair reason."** — **KETU:** "Fair. But not a good one."
> ► **"Come and stand in the ring tomorrow."** — **KETU:** "With my arms folded, then."
*In the morning, when the ring forms, Ketu is standing in it with her arms folded and her daughter beside her. She is humming, very quietly, and it is the count.*

**Outcomes and receipt.**
- The ring becomes a shared, village-wide habit. If the player broke the ring, the count is shaken and Ketu does not speak to the player.
- The figure is never identified. It might have been a nightshifter. It might have been a lost child of another village.
- **Receipt:** a painted drum at the village edge, *"One more, and one more."* Children chant the count as a skipping rhyme.

<!-- quest
id: qst_lum_counting_children
title: Counting the Children
rank: B
type: Faction
giver: npc_mabu_fernwake
region: reg_lumbaya
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: lum_counting_done
summary: A village counts its children aloud every dusk. The count is fraying nerves, and something once stood at the back of the ring.
objectives:
  talk npc_mabu_fernwake
  reach lumbaya_lowriver_dusk_ring
  choice steady_call_or_ask_name
-->

---

## 3. The Fourth Alignment

*A · Exploration · the Sky Temples · giver Temple-Keeper Oruna Starcount*

**The short version.** Oruna wants to restore the star alignments the last keepers understood, believing they kept the nightshifters away in her grandparents' time. She has the notebooks. She needs someone to carry the lamps to the four terraces by midnight.

**What is really going on.** Three alignments are known. The fourth is the one nobody is sure of. Oruna has guessed it. The player lights the lamps, and *something* happens, but it is small, and ambiguous, and Oruna must live with not knowing whether she has restored anything.

**Scene 1: the notebooks.**

**ORUNA:** "Grandmother's keeper wrote it down. *Four lamps. Four terraces. One night.* Three of them I understand."
**ORUNA:** "The fourth he drew as a *question mark.* I think it was a joke. I think it was also an instruction."
**ORUNA:** "I will try it. Alone, if I must."
> ► **"What do you expect to happen?"** — **ORUNA:** "Nothing. That is what I am afraid of."
> ► **"Could it make things worse?"** — **ORUNA:** "The roofs are already gone. How much worse?"
> ► **"I'll carry a lamp."** — **ORUNA:** "Bring water. The terraces are tall."

**Scene 2: the terraces.** The climb is long and hot. At each terrace the player and Oruna set a clay lamp into a carved socket, facing a notch in the horizon. The stone is warm underfoot. Between lamps, Oruna talks about the keepers who taught her, and the one who died before finishing.

**ORUNA:** "He said the sky is not watched *from* the temple. The temple is how the sky watches *us.*"
**ORUNA:** "I never knew what he meant. I think I'm about to."

**Scene 3: the fourth lamp.** The fourth terrace has no socket. Only a worn square of bare stone and a chalk mark. Oruna kneels.

**ORUNA:** "The question mark. Where do we light it?"
> ► **"Put it in the middle."** — Oruna does.
> ► **"Put it where no one stands."** — She shifts it to the empty corner.
> ► **"Leave it dark."** — **ORUNA:** "...Dark. An unlit lamp. That is the *fourth.*"

**Scene 4: the midnight.** At midnight the three lit lamps and the fourth gap align. The warm stone cools, a single breath's worth. Far off, a night-bird stops calling. In the village below, every dog lifts its head. Then the wind returns and the jungle noise resumes.

**ORUNA:** (whispering) "Did it do anything?"
*In the valley, no one knows. The dogs lie down again.*

**Scene 2b: the lamp-maker.** On the way between terraces, a lamp-maker named Dalu, in his eighties, stops them on the path with a basket of clay lamps and a long story about his father.

**DALU:** "My father made the lamps for the old keepers. Same clay, same wick. He used to say the *flame* was never the point."
**ORUNA:** "Then what was?"
**DALU:** "That somebody *climbed up to light it.* Every night. For no one."
*Oruna stands very still for a moment. Then she takes one of Dalu's lamps and tucks it in her pack, and does not say why.*
> ► **"That's not in the notebook."** — **ORUNA:** "No. It wouldn't be."
> ► **"It's a good reason."** — **ORUNA:** "It's the only one I trust."

**Outcomes and receipt.**
- The alignment is performed. Nothing can be shown to have changed. If the player chose the dark fourth, Oruna keeps it as a rite and teaches it as a mystery.
- **Seed (unexplained):** the cooling, the night-bird and the dogs are *not* explained. The quest does not say whether the alignments ever worked, why the roofs were torn off from inside, or why the nightshifters want the temples.
- **Receipt:** four chalk marks on the terrace stone, one unlit lamp socket; Oruna adds a page to the notebook that reads only *"Fourth: tried."*

<!-- quest
id: qst_lum_fourth_alignment
title: The Fourth Alignment
rank: A
type: Exploration
giver: npc_oruna_starcount
region: reg_lumbaya
level: 124
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: lum_alignment_done
summary: A temple-keeper tries to restore four lamps on four terraces. The fourth is a question mark, and nobody knows if it works.
objectives:
  talk npc_oruna_starcount
  reach lumbaya_sky_temple_fourth_terrace
  choice middle_corner_or_dark
-->

---

## 4. Her Mother's Face

*B · Hidden · the mangroves · giver Kiki Lowcanopy*

**The short version.** Seven-year-old Kiki says she met the Nightmother in the mangroves, and that the Nightmother looked like her mother. Nobody believes her, because her mother was at home in bed.

**What is really going on.** Kiki's mother, Peri, was at home. The face was a copy. But the copy was not the real threat: Kiki is far more upset that the thing was *cold,* and that it looked at her the way her mother looks at the washing. The player's job is to make Kiki feel believed, and to show her mother how to prove herself to a child.

**Scene 1: the dock.**

**KIKI:** "I saw her. In the mangroves. She had Mama's face and Mama's blue skirt."
**KIKI:** "She didn't have Mama's *hands.*"
**KIKI:** "She smiled at me. Mama doesn't smile like that."
> ► **"How do you know it wasn't Mama?"** — **KIKI:** "Because Mama smells like soap. She smelled like a *pond.*"
> ► **"Did she speak?"** — **KIKI:** "She said my name. She said it *wrong.* Right sounds. Wrong *weight.*"
> ► **"I believe you."** — **KIKI:** "Nobody does. They all say *dream.*"

**Scene 2: the mother.** Peri is exhausted, frightened and offended all at once.

**PERI:** "I was at the fire. Twenty people saw me. And my own girl thinks I'm a *thing.*"
**PERI:** "How do I prove I'm me to a child who's seen a copy?"
> ► **"Don't prove it. Be it, slowly."** — **PERI:** "That's what I'm afraid of."
> ► **"Let her ask the question."** — **PERI:** "She's seven."
> ► **"Teach her a song only you two know."** — **PERI:** "...We have one."

**Scene 3: the mangroves.** At Kiki's urging, the player goes to the place with her, in daylight. The roots are wet and silent. There is a patch of mud with a bare footprint, a woman's, perfect. Beside it, a second print, slightly different, as though the walker were learning how to stand.

**KIKI:** "She was practising."
*A tree-frog stops. A moment later, so does everything else.*
> ► **(Say the Nightmother's name aloud.)** — The mangrove goes entirely still.
> ► **(Cover the print with a leaf and leave.)** — Quiet and practical.
> ► **(Pick Kiki up and walk back.)** — Safe and a little undignified.

**Scene 4: the song.** Back at the house, at dusk, Peri and Kiki sit together on the step and sing a two-line nonsense song about a frog in a hat. Kiki sings the second line. Peri sings the first, and gets it *wrong* on purpose. Kiki laughs.

**KIKI:** "*That's* Mama. Mama can't ever remember it."

**Scene 2b: the watch.** Peri insists that the player and the village put a proper watch on the mangroves, and the village, which has argued for a week about whether Kiki is telling the truth, agrees in half an hour.

**ELDER:** "If it is a child's story, a watch costs us a few sleepless nights."
**PERI:** "And if it isn't, it costs us less than the other thing."
*Three fishers and a drummer are posted along the water's edge at dusk with lanterns and a pot of tea. Kiki appoints herself captain of the night watch and is, to nobody's surprise, asleep by the second bell.*
> ► **"Wake her gently."** — Peri carries her home on her shoulder.
> ► **"Let her sleep where she is."** — A blanket is found.

**Outcomes and receipt.**
- Kiki is believed; the village posts a watch on the mangroves at dusk. If the player named the Nightmother aloud, Kiki has bad dreams for a week, and Peri blames the player.
- The Nightmother is not seen. The quest never says why she chose that face.
- **Receipt:** a family password in the house, a frog in a hat, painted over the door; Kiki keeps a mud-cast of the print on her windowsill.

<!-- quest
id: qst_lum_mothers_face
title: Her Mother's Face
rank: B
type: Hidden
giver: npc_kiki_lowcanopy
region: reg_lumbaya
level: 88
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: lum_mothers_face_done
summary: A seven-year-old says she met a woman in the mangroves with her mother's face. No one believes her, because her mother was in bed.
objectives:
  talk npc_kiki_lowcanopy
  reach lumbaya_mangrove_footprints
  choice name_leaf_or_carry
-->

---

## 5. A Name to Hum

*B · OddJob · a village evening · giver Widow Calu Reedflute*

**The short version.** In Lumbaya the dead are never named after dark. Calu has taken to sleeping by day, because her work is at night, and she has not said her husband's name for a year.

**What is really going on.** Calu does not want to break the law. She wants to keep it *properly.* The custom permits humming a name, and nobody has hummed hers. Her husband, Orrin, was a flute-maker who never finished his last flute. The player's job is to help her finish it, and to hum him home.

**Scene 1: the porch.**

**CALU:** "I can say him by day. In the sun. I can say *Orrin, Orrin, Orrin.* And I do, in the garden."
**CALU:** "But the evenings are when I miss him. And at night I mustn't."
**CALU:** "Do you know, I never learned his tune. He never gave me one."
> ► **"What is a name-tune?"** — **CALU:** "A few notes. Each person has one, given at birth by the song-keeper. Mine is *four notes, falling.*"
> ► **"Who would know his?"** — **CALU:** "His sister. Three villages away."
> ► **"I'll find it."** — **CALU:** "He'd have liked you. He liked people who *did things.*"

**Scene 2: the sister.** The player walks to the next village and finds Orrin's sister Tava, a loud woman who will not stop feeding people.

**TAVA:** "Orrin's tune? Hum it? I can't hum. I sing, I *roar.*"
**TAVA:** "...I'll roar it for you. Sit."
*Tava's roar is three notes rising, and a fourth she can't remember.*
> ► **"Is there a fourth?"** — **TAVA:** "There was. Mother said it was *a surprise.*"
> ► **"Could the flute have it?"** — **TAVA:** "The unfinished flute! He'd carved a fourth hole!"
> ► **"We'll find it."** — **TAVA:** "Take bread."

**Scene 3: the flute.** In Calu's cupboard, wrapped in cloth, is Orrin's last flute, with a fourth hole half-drilled. The player and Calu finish the hole by hand, with a bow-drill, over an evening, and blow it.

*The fourth note is high, and a little cracked, like a laugh.*
**CALU:** (laughing and crying) "That's *him.* That's the surprise."

**Scene 4: the dusk.** At the edge of the night, Calu sits on the porch and, very softly, plays his four notes. The village goes quiet. From the next porch, a flute answers. Then another.

> ► **(Stay silent.)** — The notes carry.
> ► **(Hum with her.)** — A second voice joins.
> ► **(Step away and let her be.)** — **CALU:** "Thank you. Go. I am quite all right."

**Scene 2b: the sister's recipe.** Before the player leaves Tava's kitchen, she presses a bowl of something hot into their hands and insists on telling the whole story of the day Orrin was born.

**TAVA:** "He came out early. Quiet as a kitten. Mother said: *this one has a tune but he's keeping it.*"
**TAVA:** "I thought it was a joke. Sixty years, and I think she was telling the truth."
**TAVA:** "He never could whistle. But he could make a flute *talk.*"
*She wipes her eyes with a dish-towel and gives the player a second bowl, as though sorrow were something that could be fed.*
> ► **"I'll tell Calu you said so."** — **TAVA:** "Tell her I'll roar at her next feast."
> ► **"Come with me."** — **TAVA:** "To a funeral? No. To a *flute?* Yes."

**Scene 4b: the morning after.** At first light Tava arrives, having walked the whole night, and finds Calu asleep on the porch with the flute in her lap.

**TAVA:** "She's *asleep.* I roared across three villages for this."
**CALU (stirring):** "Hush. You'll wake the neighbours. I want them to wake up to a good morning."
*Tava sits down on the step and, very quietly, for once, does not roar. She hums the first three notes, and Calu hums the fourth.*

**Outcomes and receipt.**
- Orrin's name-tune is finished and played. If the player hummed with her, the village joins in; if not, Calu finishes alone and is content.
- **Receipt:** the finished flute hangs by Calu's door; at dusk the village flutes play four notes, and a fifth, higher, after.

<!-- quest
id: qst_lum_name_to_hum
title: A Name to Hum
rank: B
type: OddJob
giver: npc_calu_reedflute
region: reg_lumbaya
level: 92
act: 4
requires_rank: B
reward: 10600 | 620 | 46000
sets: lum_hum_done
summary: A widow may not say her husband's name after dark. She wants to finish his unfinished flute and hum him home.
objectives:
  talk npc_calu_reedflute
  reach lumbaya_calu_porch_dusk
  choice silent_hum_or_step_away
-->

---

## 6. The Night Market Stall

*A · Investigation · the Night Market · giver Tavo Nightbasket*

**The short version.** Three weeks ago Tavo wandered into the Night Market, where the nightshifters trade, and bought a basket of pale fruit with a promise instead of coins. He cannot remember what he promised. The stall-keeper wants payment tonight.

**What is really going on.** The nightshifter at the stall is not a monster in the usual sense; it wants to learn what a person *values.* The promise was "something I will not miss." Tavo, being generous, offered a lullaby he sang to his daughter. It cannot take what he does not miss. He *does* miss it. The player's job is to find the price that is fair.

**Scene 1: the lamp.**

**TAVO:** "I walked in for a mango. I walked out with a promise I can't read."
**TAVO:** "It's tonight. The stall-keeper said so. It smiled. It had my neighbour's smile."
**TAVO:** "I'd go alone. But the last time I went alone I forgot my own name for an hour."
> ► **"What did you take?"** — **TAVO:** "Pale fruit. They taste of nothing, and I can't stop thinking about them."
> ► **"Why not just stay home?"** — **TAVO:** "It knows my house."
> ► **"I'll go with you."** — **TAVO:** "Thank you. Do not give it your name."

**Scene 2: the market.** A clearing under a fig, lit by green lanterns that give off no heat. Stalls with no signs. Customers who look like neighbours, and are not. At the end of the row, a stall of pale fruit and a keeper wearing the face of Tavo's late father.

**KEEPER (in a kind, wrong voice):** "Tavo. You owe me something you will not miss."
**KEEPER:** "I find nothing in you that you will not miss. Yet you promised."
> ► **"He promised in ignorance."** — **KEEPER:** "A promise is a promise. *We* keep them."
> ► **"What do you want, really?"** — **KEEPER:** "To know what it is to *miss* something."
> ► **"Name your price in words."** — **KEEPER:** "Something small. A habit. A song."

**Scene 3: the bargain.** The player, Tavo and the keeper sit at the stall. Tavo offers his lullaby, and the keeper recoils from it.

**KEEPER:** "That is *loved.* I cannot take what is loved. It will not come off."
**TAVO:** "Then take something I *don't* love."
**KEEPER:** "Name it."
> ► **"His fear of the dark."** — **KEEPER:** "Interesting. Fear is... *heavy.*"
> ► **"A bad memory of the Night Market."** — **KEEPER:** "Ah. A piece of this place. That is a fair swap."
> ► **"Nothing. Walk away."** — The lanterns gutter; the keeper is silent.

**Scene 4: the road home.** Walking out through the stalls, Tavo hums the lullaby very quietly to himself.

**Scene 2b: the hum.** While Tavo fetches his coat, the player stands alone in the dusk and hears a thin, sweet melody drifting between the trees. It is a children's song, one the player half knows, sung a little too slowly and a little too evenly.

**TAVO:** "That's them. That's how they call you. A song you almost remember."
**TAVO:** "If you start humming along, they know your name."
*The player clamps a hand over their own mouth. The melody drifts on, patient and perfectly polite, and does not seem at all disappointed.*
> ► **"What do I do?"** — **TAVO:** "Think of something else. Anything. Soup."
> ► **"How many times have you heard it?"** — **TAVO:** "Twenty-three. I counted."

**Outcomes and receipt.**
- The debt is settled with something real but not precious. If the player walked away, the stall follows Tavo home for a week, and politely asks again each dusk.
- **Not answered:** what the nightshifters want from these trades. The quest only shows that they ask.
- **Receipt:** a single pale fruit left on Tavo's sill, uneaten, and a small cairn at the market's edge, where Tavo leaves a ripe mango each month.

<!-- quest
id: qst_lum_night_market_stall
title: The Night Market Stall
rank: A
type: Investigation
giver: npc_tavo_nightbasket
region: reg_lumbaya
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: lum_night_stall_done
summary: A fruit-seller owes a Night Market stall a promise he cannot remember. The keeper wants payment tonight.
objectives:
  talk npc_tavo_nightbasket
  reach lumbaya_night_market_stall
  choice fear_memory_or_walk
-->

---

## 7. What the Root Stair Climbs To

*A · Exploration · the Root Stair · giver Stair-Warden Imeru Figroot*

**The short version.** The Root Stair is a stone stair swallowed by a giant fig. Imeru has cleared it for thirty years and never reached the top. This season the fig's growth has stopped, and she wants to climb before it starts again.

**What is really going on.** The stair climbs to a single, roofless chamber, and the chamber is *empty.* It has a floor, four walls, a ring of carved stars and no ceiling. The roof was torn off *from the inside,* and the roots grew into the gap afterward. That is all the quest says. The player's job is to see it, and to bring Imeru down safely.

**Scene 1: the foot of the stair.**

**IMERU:** "Thirty years of vines. Every spring, I cut a step. Every summer, the fig grows it back."
**IMERU:** "This spring, it hasn't. Not one new root."
**IMERU:** "I'd like to know why before it *changes its mind.*"
> ► **"What's up there?"** — **IMERU:** "My grandmother said: *a room that looks.*"
> ► **"Is it safe?"** — **IMERU:** "Nothing here is safe. Everything is *climbable.*"
> ► **"I'll go first."** — **IMERU:** "No. *Together.* It's my stair."

**Scene 2: the climb.** A quiet, vertical sequence through green gloom, hand over hand on root and stone. Light falls in coins. Halfway, a hollow in the wall holds offerings left by climbers long dead: shells, a child's toy, a flute with no holes.

**IMERU:** "People came up here once. To look at the sky. Not to hide from it."
*The roots thin. The light turns white. The last step is a lip of bare stone.*

**Scene 3: the room.** A square chamber, forty paces wide. The floor is polished by rain. Four walls rise to a jagged edge. The carved ring of stars is inlaid in the stone, and every star is *pointed inward.*

*The fig has stopped just short of the chamber. Its roots curl back from the walls like fingers pulled from a flame.*
**IMERU:** (barely audible) "The roof isn't *fallen.* It's been *taken.* From here. From *inside.*"
> ► **"What does it mean?"** — **IMERU:** "I don't know. Nobody does."
> ► **"Stand in the centre."** — **IMERU:** "You first."
> ► **"Let's go down."** — **IMERU:** "...Yes."

**Scene 4: the descent.** Whichever way the player chose, nothing happens. The sky above is blue, and a hawk crosses it. They climb down in silence. On the last step, the fig's new root, thin as a thread, reaches across the lowest stair.

**IMERU:** "It's growing again."
**IMERU:** "It was waiting for us to *leave.*"

**Scene 2b: the offerings.** Halfway up, Imeru stops at the hollow of offerings and sits down heavily, rubbing her bad knee. She picks up the child's toy, a little wooden monkey, and turns it over in her fingers.

**IMERU:** "My grandmother brought me up here once. I was four. She said I would understand when I was old enough."
**IMERU:** "I'm sixty-one. I understand nothing."
**IMERU:** "She'd have laughed at that. She had the loudest laugh in the village."
*She sets the monkey back in its niche exactly as she found it, and then, after a moment, takes a small shell from her own pocket and sets it beside it.*
> ► **"Leave something of your own."** — She already has.
> ► **"Rest as long as you need."** — **IMERU:** "No. Up. Before I lose the nerve."

**Outcomes and receipt.**
- The chamber is seen; Imeru finally reaches the top. If the player stood in the centre, they feel a faint pressure, as of being *looked at,* that fades on the way down.
- **Seed (unexplained):** the roofless room, the inward-pointed stars, the fig's pause. The quest does not say what tore the roofs, whether the nightshifters or the Nightmother did it, or why the fig stopped.
- **Receipt:** a bundle of cut vines at the stair's foot; Imeru carves *"top"* on the highest step.

<!-- quest
id: qst_lum_root_stair
title: What the Root Stair Climbs To
rank: A
type: Exploration
giver: npc_imeru_figroot
region: reg_lumbaya
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: lum_root_stair_done
summary: A warden has cleared a swallowed stair for thirty years and never reached the top. This season the fig stopped growing.
objectives:
  talk npc_imeru_figroot
  reach lumbaya_root_stair_top
  choice question_centre_or_descend
-->

---

## 8. Leaf, Bark and Fever

*B · Gathering · the river villages · giver Healer Zanu Brightbark*

**The short version.** A river-fever is moving through three villages, and Zanu has run out of silverbark. It grows only on a ridge above the old causeway. She cannot leave her patients. She asks the player to fetch it, and to play her flute while they work.

**What is really going on.** In Lumbaya, medicine is made to music: each herb is cut to a tune that keeps the cutter's hands steady and the patient's fear low. The fever is real and the cure is ordinary. The hard part is that the silverbark ridge sits beside a place where, at dusk, voices call from the trees in the voices of the sick.

**Scene 1: the sickroom.**

**ZANU:** (playing a quick, bright tune between instructions) "Six beds. Eleven more at home. I've enough bark for two."
**ZANU:** "Silverbark. Ridge above the causeway. It must be cut with the *Morning Cut,* or it turns bitter."
**ZANU:** "Take my flute. Don't lose it. I'm *very* attached."
> ► **"What's the Morning Cut?"** — **ZANU:** "A tune and a knife. Both gentle."
> ► **"Can't you send a runner?"** — **ZANU:** "I could. They'd cut it wrong."
> ► **"I'll go."** — **ZANU:** "Quickly. And home before dusk."

**Scene 2: the ridge.** A pleasant, sweaty walk along a causeway of grey stone. Monkeys heckle. The silverbark trees stand in a pale grove, their trunks shimmering. The player plays the Morning Cut, badly. A bark strip curls off the tree.

**ZANU (remembering, over the memory of the sickroom):** "Slowly. Pretend it's a loaf."
*The strips come away like ribbon. The player fills a basket. A cloud crosses the sun. It is later than it seemed.*

**Scene 3: the voices.** On the walk home, at the edge of dusk, a voice calls from the trees: a child's voice, thin and ill.

**VOICE:** "Please... it hurts... help me..."
**VOICE (a second, from the other side):** "Healer Zanu said to come... she said come quickly..."
> ► **(Keep walking, playing the flute.)** — The voices fall behind.
> ► **(Call back, "Who are you?")** — The voices go silent. The silence is worse.
> ► **(Leave the basket in a safe place and look.)** — Dangerous; the basket is taken.

**Scene 4: the cure.** At nightfall the player returns with the bark. Zanu boils it with honey and ginger root, and plays through the night. By dawn, the fever in the first bed breaks.

**ZANU:** (hoarse) "...Eleven more to go."

**Scene 2b: the child with the knife.** At the ridge's foot, the player passes a small boy of ten sitting on a rock with a bark-knife and a look of enormous importance.

**BOY:** "I'm the lookout. Healer Zanu said so. If you come back after dark, I'm supposed to whistle."
**BOY:** "I can whistle three ways. Want to hear?"
*He whistles three ways, one of which is more of a wet cough. He is clearly quite proud of it.*
**BOY:** "If I whistle, run. That's the rule."
> ► **"What do I run from?"** — **BOY:** "Whatever is whistling back."
> ► **"I'll listen for it."** — **BOY:** "Good. Don't whistle back."

**Scene 4b: the Morning Cut.** In the days that follow, the villagers practise the tune on every tree. Children cut chives to it, and fishers trim their nets. Zanu hears the tune drifting over the river for a week and says nothing, though she is smiling.

**ZANU:** "A tune is a kind of kindness you can hand to someone else."
**ZANU:** "That's all medicine is. The rest is bark."
*The player's flute-playing, she admits, is dreadful. She also admits that three patients said it made them laugh, which is a symptom of recovery.*

**Outcomes and receipt.**
- The fever is cured in all three villages. If the player looked for the voices, the basket is lost and the cure is delayed a day; one patient takes a turn for the worse.
- **Receipt:** Zanu's flute returned with a ribbon of silverbark tied to it; the villages teach the Morning Cut to their children.

<!-- quest
id: qst_lum_leaf_bark_fever
title: Leaf, Bark and Fever
rank: B
type: Gathering
giver: npc_zanu_brightbark
region: reg_lumbaya
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: lum_fever_done
summary: A river-fever spreads through three villages and the healer has run out of silverbark, which must be cut to a tune.
objectives:
  talk npc_zanu_brightbark
  reach lumbaya_silverbark_grove
  choice walk_ask_or_look
-->

---

## 9. A Song for a Password

*A · Faction · three villages · giver Auntie Lowa Drumhand*

**The short version.** Lowa knows two hundred and eleven songs. A nightshifter can copy a voice, but not, she thinks, a *song* sung with a village's own mistakes. She wants every family to have a call-and-response only they know.

**What is really going on.** Lowa's idea is a password built from music: a call sung by one person and answered by another, with an agreed wrong note. A copy can learn the notes. It cannot learn the family *joke* in the wrong note. The challenge is to teach three villages quickly, and to not turn every reunion into an interrogation.

**Scene 1: the drum-house.**

**LOWA:** "Two hundred and eleven songs. And what use are they? A nightshifter has your mother's *voice.*"
**LOWA:** "But does it have her *flat note?*"
**LOWA:** "Every family has one. A mistake they all make and love. We make it a *lock.*"
> ► **"How does it work?"** — **LOWA:** "One sings the call. The other answers wrong, on purpose, in the family way."
> ► **"Won't they learn it?"** — **LOWA:** "Let them try. They learn *notes.* They cannot learn *why it's funny.*"
> ► **"I'll help teach."** — **LOWA:** "Bring ears."

**Scene 2: the lessons.** A noisy, joyous sequence. The player sits among families as Lowa coaxes out each one's private mistake. One family sings flat on the word "river." Another always laughs on the third bar. A grandfather insists on his own verse, and no one is allowed to correct him.

**GRANDFATHER:** "It's *meant* to be wrong. If you fix it, the song stops being mine."
**LOWA:** "Exactly! Exactly that!"
> ► **"Write it down."** — **LOWA:** "No! Written songs are *copyable.*"
> ► **"Practise it often."** — **LOWA:** "Every day. Until it's a habit."
> ► **"Add a hand-sign."** — **LOWA:** "Ah. A *second* lock."

**Scene 3: the test.** On the third night, a stranger walks into the village in the form of a villager's sister. She sings the call perfectly. Lowa is watching. The sister waits for the answer. The villager, Dabo, answers with the family wrong note, and *adds a joke she has never heard.*

*The sister hesitates. Her smile holds. Her eyes do not.*
> ► **(Hold Dabo's hand.)** — The sister steps back.
> ► **(Ask the sister to sing the joke.)** — **SISTER:** "...What joke?"
> ► **(Sing the answer yourself, wrongly.)** — Chaos; Dabo laughs; the sister retreats.

**Scene 4: the morning.** The stranger is gone. In the village square, two hundred people are singing their wrong notes at once.

**LOWA:** "It is the loudest, ugliest noise I have ever heard."
**LOWA:** "And it is the best thing we have ever made."

**Scene 2b: the grandfather's verse.** The grandfather who insisted on his own verse is not finished. At the end of the lesson he draws the player aside, leaning on his stick.

**GRANDFATHER:** "I've a verse nobody has heard. I wrote it for my wife."
**GRANDFATHER:** "She died four years ago. I don't sing it. But I'd like it to be somebody's *lock.*"
**GRANDFATHER:** "Do you think that's allowed?"
*He sings it, once, to the player alone: seven lines, cracked and tender. When he finishes, the player finds that they are, quite unexpectedly, crying.*
> ► **"It's allowed."** — **GRANDFATHER:** "Good. Then I'll teach it to the girl."
> ► **"It should be yours alone."** — **GRANDFATHER:** "Perhaps. Perhaps."

**Outcomes and receipt.**
- Three villages adopt the call-and-response. If the player chose to write songs down, a few families are copied within a month, and Lowa is furious.
- The stranger is not identified or defeated. It might simply have been a very good mimic.
- **Receipt:** a painted drum in each village marked with a wavy line, the sign of *"the wrong note."*

<!-- quest
id: qst_lum_song_password
title: A Song for a Password
rank: A
type: Faction
giver: npc_lowa_drumhand
region: reg_lumbaya
level: 134
act: 4
requires_rank: A
reward: 32500 | 1620 | 140000
sets: lum_password_done
summary: A song-keeper teaches three villages call-and-response songs with a deliberate family mistake, a password a nightshifter cannot fake.
objectives:
  talk npc_lowa_drumhand
  reach lumbaya_three_villages_square
  choice hold_ask_or_sing
-->

---

## 10. Auntie Nokoma Has Not Aged

*A · Hidden · a river village · giver Ysa Nokoma-Kin*

**The short version.** Ysa's great-aunt Nokoma raised her and never once missed a meal. In the village's sixty-year-old painted record, Nokoma looks exactly the same as she does today. Ysa doesn't want her to be anything but her aunt, and cannot stop asking.

**What is really going on.** *Nothing is explained.* Nokoma might be a nightshifter, or a very long-lived woman, or something else. The quest has the player decide how to treat a person whose only crime is being unprovable. It ends on a question.

**Scene 1: the painted wall.**

**YSA:** "That is Nokoma in the village record. Sixty years ago. Look at her face."
**YSA:** "That is Nokoma now. Sit with her. Look."
**YSA:** "She has never said a cruel word to anyone. She has never *missed.*"
> ► **"What do you want?"** — **YSA:** "To not know. And I can't *not* know."
> ► **"Have you asked her?"** — **YSA:** "She laughed and gave me tea."
> ► **"I'll sit with her."** — **YSA:** "She likes people who listen."

**Scene 2: the tea.** The player spends an afternoon at Nokoma's table. She is small, humorous, deeply patient and a little sad. She is an excellent cook. She asks about the player's family and listens to the whole answer.

**NOKOMA:** "You've been sent to look at me. It's all right. They always send someone."
**NOKOMA:** "I can't tell you what you want to hear. I only know what I've been."
**NOKOMA:** "I have been *good,* I think. For a long time."
> ► **"Are you a nightshifter?"** — **NOKOMA:** "I don't know how I'd prove I wasn't."
> ► **"Do you want to be tested?"** — **NOKOMA:** "If it would make Ysa sleep, yes."
> ► **"Tell me about the village record."** — **NOKOMA:** "I sat for that painting. I was thirty. I am... still thirty-ish."

**Scene 3: the choice.** The village elders have heard the rumour. A gathering at dusk is called. They want a test.

**ELDER:** "If she is one of them, she'll fail. If she is not, there is no harm."
**YSA:** "Harm! You'll make her stand in the circle like a suspect."
> ► **(Argue for the test, gently.)** — A quiet, careful trial of songs.
> ► **(Argue against any test.)** — **ELDER:** "Then the doubt stays."
> ► **(Offer to be her witness.)** — **NOKOMA:** "I'd be glad."

**Scene 4: the night.** Whatever the village decides, Nokoma stays. She passes the songs. She passes the questions. She passes everything and the elders are neither relieved nor satisfied.

**NOKOMA:** (to the player, quietly) "That's the trouble with being kind for a very long time. It looks exactly like a disguise."

**Scene 2b: Nokoma's kitchen.** After the tea, Nokoma shows the player a shelf of small clay pots, each labelled in a slanting hand, each holding a different seed.

**NOKOMA:** "I keep the seeds of every garden I've loved. This is from the first house. This one, from a village that's gone."
**NOKOMA:** "I'm not sentimental. I just don't want them to be forgotten."
**NOKOMA:** "People fade, you know. But seeds are patient."
*Ysa stands in the doorway, listening. She says nothing, but she is holding her own elbow very tightly.*
> ► **"Which pot is the oldest?"** — **NOKOMA:** "I don't say. It's rude to the others."
> ► **"Would you plant one for Ysa?"** — **NOKOMA:** "I already have."

**Outcomes and receipt.**
- Nokoma remains in the village. If the player argued against any test, the doubt lingers, and Ysa moves out. If the player witnessed, the village accepts her, uneasily.
- **Seed (unexplained):** the quest never says whether Nokoma is a nightshifter, a long-lived human or something else. The Nightmother is not mentioned.
- **Receipt:** a second, small painting on the village wall, of Nokoma and Ysa at the table; the paint is still wet.

<!-- quest
id: qst_lum_nokoma_not_aged
title: Auntie Nokoma Has Not Aged
rank: A
type: Hidden
giver: npc_ysa_nokoma_kin
region: reg_lumbaya
level: 138
act: 4
requires_rank: A
reward: 34000 | 1700 | 150000
sets: lum_nokoma_done
summary: A girl notices her beloved great-aunt looks exactly as she did in a sixty-year-old painting. No one can prove what she is.
objectives:
  talk npc_ysa_nokoma_kin
  reach lumbaya_nokoma_table
  choice test_refuse_or_witness
-->
