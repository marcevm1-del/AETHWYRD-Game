# 11e-26 — Haneul, the Sky Gate: Ten Side Quests (draft)

> *"Haneul built its wall for an enemy from the north. The red gate opened in the sky instead."*
> — Gazetteer, Haneul

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the third regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 5 has Varos "set a paper" before the siege; it reveals only his manner, not his purpose.

**Region:** `reg_haneul` (the terraced gate-towns, the Cloud Gate Guesthouse, the Examination Hall, the Unfallen Wall, the red gate in the clouds). **Rank band:** B-A. **Tone:** courteous, proud, ink-and-pine, under siege. Warmth comes from manners kept up in the face of the unthinkable; comedy comes from people who will not be rude even to a demon. Nobody here forgets to take off their shoes.

**Placement notes.**
- **Varos, Herald of the Red Gate,** is the region's Tyrant: a precise, polite demon officer who treats the siege as an examination the kingdom is failing. **No quest here kills him or ends the siege.** Quest 5 changes *what Varos says before the fight* and how the capital prepares to answer it; quests 6, 8 and 10 hold lines without breaking them.
- The red gate and what the "something larger" is are **not explained.**
- Customs the quests rely on: **shoes off at every door** (even a guesthouse at war); **the brush-bow** (examination candidates bow to their brush before the paper); **ancestor tablets** kept in every home and carried out first in any fire or flight; **the bend-shrines** (a small mountain-spirit shrine at every bend of the pass); **magpie-luck** (a magpie on the sill means a letter is coming).
- Earlier pattern quests here: *Six Lanterns of the Examination Hall* and *The Dream That Was Yours* (the Maelis shrine, Soyeon, Min-jun). Neither is touched.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Candidate's Road | B | Escort | Seo Ji-wan | A scholar with a stubborn mother |
| 2 | The Exile's Survey | A | Faction | Scholar Yoon Taesik | A wall built for the wrong enemy |
| 3 | Shoes at the Cloud Gate | B | OddJob | Guesthouse-keeper Ha Mirae | A mercenary in boots |
| 4 | A Guest in the Rice Loft | B | Hidden | Farmer Gu Jaesung | A shy spirit and a loud rooster |
| 5 | The Paper Varos Set | A | Investigation | Examiner Baek Seonwoo | A demon's question paper |
| 6 | Terrace Seven Holds | B | Defense | Sergeant Jo Dalsu | A granary and a terrace |
| 7 | Tablets Down the Pass | B | Delivery | Widow Na Okja | The ancestors first |
| 8 | Drums on the Wall | A | SiegeDefence | Wall-captain Oh Seongmin | The anniversary vigil |
| 9 | The Watchman Who Still Faces North | B | Exploration | Young sentry Kwon Haru | Sixty years of the wrong direction |
| 10 | Shrines at Every Bend | A | Defense | Spirit-keeper Eom Sora | Little altars, held |

## Cast

<!-- npc
id: npc_seo_jiwan
name: Seo Ji-wan
tier: townsfolk
race: Human
region: reg_haneul
settlement: Lower gate-town
role: Examination candidate
backstory: A thin, anxious young scholar who has studied eleven years for a single morning and whose mother has insisted on walking to the hall beside him.
-->
<!-- npc
id: npc_madam_seo_hyeja
name: Madam Seo Hye-ja
tier: townsfolk
race: Human
region: reg_haneul
settlement: Lower gate-town
role: Candidate's mother
backstory: A small, fierce widow who sold her loom for her son's ink and who has made it perfectly clear that the demons may do as they please but he will eat before the paper.
-->
<!-- npc
id: npc_yoon_taesik
name: Scholar Yoon Taesik
tier: major
race: Human
region: reg_haneul
settlement: Hermitage below the pass
role: Exiled scholar-official
backstory: A spare, ink-stained scholar exiled thirty years ago for proving the Unfallen Wall was built facing the wrong enemy, who now asks to come home and be useful.
-->
<!-- npc
id: npc_ha_mirae
name: Guesthouse-keeper Ha Mirae
tier: major
race: Human
region: reg_haneul
settlement: Cloud Gate Guesthouse
role: Keeper of the Cloud Gate Guesthouse
backstory: A tall, composed keeper who has hosted ambassadors, exiles and one memorable goat, and who has never once allowed a boot across her threshold.
-->
<!-- npc
id: npc_captain_dorjin_vael
name: Captain Dorjin Vael
tier: townsfolk
race: Human
region: reg_haneul
settlement: Cloud Gate Guesthouse
role: Outland mercenary captain
backstory: A broad, honest sellsword from the western road who has crossed two continents in the same boots and who cannot understand why anyone would ask him to remove them in a siege.
-->
<!-- npc
id: npc_gu_jaesung
name: Farmer Gu Jaesung
tier: townsfolk
race: Human
region: reg_haneul
settlement: Terrace Four
role: Rice farmer
backstory: A big, gruff farmer whose rice loft has been invaded by a shy mountain spirit that has eaten nothing and moved everything, and whose wife has stopped speaking to him about it.
-->
<!-- npc
id: npc_spirit_of_the_loft
name: The Quiet Guest
tier: townsfolk
race: Spirit
region: reg_haneul
settlement: Terrace Four
role: Hiding mountain spirit
backstory: A small, moth-pale mountain spirit the size of a heron, driven from the high pines by demons, which has hidden in a farmer's loft and speaks only in bell-like whispers.
-->
<!-- npc
id: npc_baek_seonwoo
name: Examiner Baek Seonwoo
tier: major
race: Human
region: reg_haneul
settlement: The capital
role: Chief examiner of the kingdom
backstory: A dry, scrupulous chief examiner who has read ten thousand papers and has just received one he does not know how to grade.
-->
<!-- npc
id: npc_sergeant_jo_dalsu
name: Sergeant Jo Dalsu
tier: townsfolk
race: Human
region: reg_haneul
settlement: Terrace Seven
role: Gate-town sergeant
backstory: A cheerful, scarred sergeant of the standing army who has been given forty soldiers, six hundred sacks of barley and one terrace to hold, and has decided to be pleased about it.
-->
<!-- npc
id: npc_widow_na_okja
name: Widow Na Okja
tier: townsfolk
race: Human
region: reg_haneul
settlement: Upper gate-town
role: Keeper of a family's ancestor tablets
backstory: A frail, upright widow of the upper town who fled at midsummer with her children and left seven generations of her family's tablets in a house now behind demon lines.
-->
<!-- npc
id: npc_oh_seongmin
name: Wall-captain Oh Seongmin
tier: major
race: Human
region: reg_haneul
settlement: The Unfallen Wall
role: Captain of the wall watch
backstory: A hard, tired captain who has held the capital's wall for ninety-one nights and whose men have just realised that tomorrow is the anniversary of the winter the wall stood.
-->
<!-- npc
id: npc_kwon_haru
name: Young Sentry Kwon Haru
tier: townsfolk
race: Human
region: reg_haneul
settlement: The Unfallen Wall
role: Wall sentry
backstory: A restless young sentry assigned to the oldest northern post, who has noticed that the watchman there has faced north for sixty years and has never once been told to stop.
-->
<!-- npc
id: npc_old_watchman_chae
name: Old Watchman Chae
tier: townsfolk
race: Human
region: reg_haneul
settlement: The Unfallen Wall
role: Northern watchman
backstory: A stooped, courteous old watchman who has stood the northern post since before the captain was born, for an enemy who has never arrived, and does not intend to leave early.
-->
<!-- npc
id: npc_eom_sora
name: Spirit-keeper Eom Sora
tier: major
race: Human
region: reg_haneul
settlement: The pass
role: Keeper of the bend-shrines
backstory: A quiet, grey-eyed shrine-keeper who tends forty small altars along the pass, and who has watched the demons take the spirits that live in them one by one.
-->

---

## 1. The Candidate's Road

*B · Escort · the lower gate-town to the Examination Hall · giver Seo Ji-wan*

**The short version.** The examinations are being held despite the siege. Ji-wan has studied eleven years. His mother insists on coming too. The road runs along a ridge that demons have been watching.

**What is really going on.** Ji-wan is not afraid of the paper. He is afraid of being the reason his mother is hurt on the way. Madam Seo is not afraid of anything; she is afraid of her son thinking, for even a moment, that he was not worth the risk. The quest is about keeping both at once.

**Scene 1: the doorstep.**

**JI-WAN:** "Honoured traveller. I am told you can see a candidate safely to the hall. I am also told the road is watched."
**MADAM SEO:** "I am coming. I will not discuss it."
**JI-WAN:** "Mother, it's *dangerous.*"
**MADAM SEO:** "Eat your rice."
> ► **"I'll take you both."** — **MADAM SEO:** "Good. Mind your boots at the door."
> ► **"Is it wise to bring her?"** — **MADAM SEO:** "I have outlived two husbands and one famine."
> ► **"What if a demon appears?"** — **JI-WAN:** "I will recite the Analects at it."

**Scene 2: the ridge road.** The path climbs, then narrows. Magpies cry on the pines. Below, a long line of watchfires; above, the red light in the clouds.
*(Gameplay: escort with light stealth. Dodge a demon patrol; share a flask; Madam Seo insists on stopping to feed a stray dog.)*

**MADAM SEO:** "He is thin. Look at his ribs. Do you have a rice ball?"
**JI-WAN:** "Mother, *demons.*"
**MADAM SEO:** "Demons do not mind a dog being fed."
> ► **"Hide in the shrine."** — A bend-shrine's shadow.
> ► **"Lead the patrol away."** — A close call.
> ► **"Wait until the lamp passes."** — A tense pause.

**Scene 3: the hall.** The Examination Hall stands lit, shuttered and half-empty. A clerk at the door checks Ji-wan's brush, and then checks it again.

**CLERK:** "Candidates only past this line."
**MADAM SEO:** "I will wait."
**CLERK:** "It will be many hours."
**MADAM SEO:** "I have waited eleven years."
> ► **"Stay with her."** — A long vigil.
> ► **"Go ahead, Ji-wan."** — **JI-WAN:** (bows to his brush) "...Yes."
> ► **"Tell him something kind."** — A moment.

**Scene 4: the hours.** Madam Seo sits on the outer step. Around her, a quiet ring of mothers, fathers and old teachers gather. She distributes rice balls. Nobody speaks of demons.

**Outcomes and receipt.**
- Ji-wan sits the paper; the result is not known in this quest. Madam Seo, who feeds forty people on the step, is later called "the Rice-Ball Mother of the Hall."
- **Receipt:** a long bench outside the Examination Hall, installed by the clerks for waiting families, with a rice-ball basket permanently on it.

<!-- quest
id: qst_han_candidates_road
title: The Candidate's Road
rank: B
type: Escort
giver: npc_seo_jiwan
region: reg_haneul
level: 89
act: 4
requires_rank: B
reward: 10200 | 610 | 44500
sets: han_candidate_done
summary: A candidate and his formidable mother must reach the Examination Hall along a ridge road watched by demons.
objectives:
  talk npc_seo_jiwan
  escort npc_seo_jiwan
  escort npc_madam_seo_hyeja
  reach haneul_examination_hall
  choice shrine_lure_or_wait
-->

---

## 2. The Exile's Survey

*A · Faction · the Hermitage below the pass · giver Scholar Yoon Taesik*

**The short version.** Thirty years ago, a scholar-official proved the Unfallen Wall was built facing the wrong enemy, and was exiled for saying so. The red gate opened in the sky. Yoon Taesik wants to come home and be useful.

**What is really going on.** Yoon is not asking for vindication. He wants to survey the wall for the one place that *can* be defended against a threat from above, and the council would rather not hear that its exile was right. The player is to carry his survey to the council and make sure it is read.

**Scene 1: the hermitage.**

**YOON:** "I wrote one sentence thirty years ago. 'The wall faces north; the danger will not.' I was exiled for the sentence."
**YOON:** "I do not wish to be thanked. I wish the wall to be useful."
**YOON:** "I have measured the pass for thirty years. I know where a wall that faces *up* would stand. And where this one is weak."
> ► **"What do you want from the council?"** — **YOON:** "To be heard, once, and then ignored politely if they must."
> ► **"They exiled you."** — **YOON:** "They were frightened. Fear writes poor laws."
> ► **"I'll carry your survey."** — **YOON:** "Mind the maps. They are my children."

**Scene 2: the council.** In the capital's council hall, the scholar-officials listen with tight faces. An old minister, **Minister Pyo,** rises.

**PYO:** "This man was exiled by order of the throne. Do we undo the throne's order in a siege?"
**YOON'S MAP (read aloud):** "The wall's northern face is thick. Its southern face is thin. Its top is open. If the enemy comes from above..."
**PYO:** "It is *treason* to say the wall is flawed."
> ► **"It is treason to leave it flawed."** — The room stirs.
> ► **"Read the map aloud, line by line."** — **PYO:** "Very well."
> ► **"Let the soldiers speak."** — A captain stands.

**Scene 3: the walk.** The council agrees, grudgingly, to walk the wall with Yoon. The scholar, in his thirty-year-old coat, stands under the open sky at the top of the stair and looks up at the red light.

**YOON:** "It is just as I drew it. I had thought I would feel vindicated."
**YOON:** "I feel only *tired,* and *late.*"
> ► **"You are not late."** — **YOON:** "Thank you. That was kind."
> ► **"What do we build?"** — **YOON:** "A roof, of sorts. In stages."
> ► **"Show them the weak place."** — He points.

**Scene 4: the decree.** The council issues three orders: the weak southern stair is reinforced; a covered gallery is added to the wall-top; and Yoon Taesik's name is struck from the exile-roll in the sight of the whole court.

**PYO:** (stiffly) "Scholar Yoon. The throne has... reconsidered."
**YOON:** "Thank you, Minister. I will begin at once."

**Outcomes and receipt.**
- The wall gains a covered gallery and a reinforced southern stair; the capital's drill adds a "look up" station. If the soldiers spoke, the garrison trusts Yoon at once; if the map was read line by line, the council does.
- **Receipt:** Yoon's name painted fresh on the Scholars' Wall, and a long, low roof of tile and timber over the wall-top walk.

<!-- quest
id: qst_han_exiles_survey
title: The Exile's Survey
rank: A
type: Faction
giver: npc_yoon_taesik
region: reg_haneul
level: 127
act: 4
requires_rank: A
reward: 29000 | 1520 | 128000
sets: han_survey_done
summary: A scholar exiled for proving the wall faced the wrong enemy wants to come home and survey it for the real one.
objectives:
  talk npc_yoon_taesik
  reach haneul_council_hall
  reach haneul_wall_top
  choice map_soldiers_or_walk
-->

---

## 3. Shoes at the Cloud Gate

*B · OddJob · the Cloud Gate Guesthouse · giver Guesthouse-keeper Ha Mirae*

**The short version.** An outland mercenary captain has arrived to help hold the wall. He has not taken off his boots. The guesthouse has a rule.

**What is really going on.** The captain's boots are the only pair he has ever owned; his left foot has a bad scar and a worse smell, and he is mortified. He is not being rude. He is being *proud.* The guesthouse-keeper does not want to break her rule; she wants to find a way to keep it kindly.

**Scene 1: the threshold.**

**MIRAE:** "I have hosted ambassadors, exiles and one goat. In forty years not one boot has crossed this sill."
**MIRAE:** "Captain Vael has stood on the step for an hour. I cannot ask him to leave. I cannot allow him to enter."
**MIRAE:** "Find me a third thing."
> ► **"What has he said?"** — **MIRAE:** "He says, 'It is not a matter of disrespect.'"
> ► **"Offer him slippers."** — **MIRAE:** "He refuses slippers."
> ► **"I'll talk to him."** — **MIRAE:** "Do not mention his feet."

**Scene 2: the step.** On the stone step, a broad man in a patched coat sits stiff as a post, staring fixedly at a sparrow.

**VAEL:** "I don't mean to cause trouble. I've crossed two continents in these boots."
**VAEL:** "I'll sleep in the stable. I'll sleep in the *rain.* I just... can't take them off."
**VAEL:** "...My feet are not what they were."
> ► **"Is it the scar?"** — **VAEL:** "...How did you know?"
> ► **"I have a spare pair of socks."** — **VAEL:** "Socks. Hm."
> ► **"There's a bath behind the guesthouse."** — **VAEL:** "A *bath?*"

**Scene 3: the bath.** Behind the guesthouse is a stone bath, steaming in the cold. Mirae, with great dignity, has laid out clean cloth, a basin of herbs and, silently, a new pair of felted slippers in his size.

**MIRAE:** "The rule is shoes off at the door. It does not say where the door is."
**MIRAE:** "The door is at the bath. The boots may stay there, in honour."
*(Gameplay: a light comic fetch-and-carry; salve, towels, a boot-polish debate.)*

**Scene 4: the sill.** Vael steps over the sill in his felted slippers, carrying his boots in both hands like a sleeping cat.

**VAEL:** "These boots will sit on the shelf of honour, I take it."
**MIRAE:** "Next to the goat's saddle."
**VAEL:** "...Of course they will."

**Outcomes and receipt.**
- The captain's company is housed with honour; the guesthouse adds a "shelf of boots" where soldiers can leave theirs in honour. If the player offered nothing but socks, Vael sleeps in the stable out of pride and is quietly sad.
- **Receipt:** a long wooden shelf by the guesthouse door, with a single pair of scuffed boots on it and a brass plate: *"Crossed two continents."*

<!-- quest
id: qst_han_shoes_cloud_gate
title: Shoes at the Cloud Gate
rank: B
type: OddJob
giver: npc_ha_mirae
region: reg_haneul
level: 91
act: 4
requires_rank: B
reward: 10400 | 620 | 45000
sets: han_shoes_done
summary: An outland mercenary will not take off his boots at a guesthouse where nobody has ever worn them past the sill.
objectives:
  talk npc_ha_mirae
  talk npc_captain_dorjin_vael
  reach haneul_guesthouse_bath
  choice socks_bath_or_leave
-->

---

## 4. A Guest in the Rice Loft

*B · Hidden · Terrace Four · giver Farmer Gu Jaesung*

**The short version.** A shy mountain spirit has moved into Farmer Gu's rice loft. It has eaten nothing and moved everything. The farmer wants it gone. His wife has stopped speaking to him about it.

**What is really going on.** The spirit was driven down from the high pines by demons. It is terrified of being found. It rearranges the loft each night because it is trying, with great care, to make a *nest* that looks like a loft, so as not to be noticed. The farmer's wife has already guessed, and has been leaving out a bowl of warm milk, without telling him.

**Scene 1: the loft.**

**GU:** "A ghost. A *spirit.* Something. It moves the sacks at night. Puts them in neat rows."
**GU:** "I'm a farmer. I don't like neat rows in the loft. They are *wrong.* I do not know where anything is."
**GU:** "My wife has stopped speaking to me about it. That is the worst part."
> ► **"Can I see the loft?"** — **GU:** "Please. Mind the rooster."
> ► **"What does it want?"** — **GU:** "To drive me mad."
> ► **"Is it dangerous?"** — **GU:** "It has... stacked my seed-grain by *height.*"

**Scene 2: the loft by night.** In the dark rice loft, sacks are stacked in careful, symmetrical towers. A small, moth-pale shape hunches in the corner, trembling.

**THE QUIET GUEST:** (a bell-like whisper) "*...please... do not tell them... where I am...*"
**THE QUIET GUEST:** "*...the red ones... they take us first...*"
**THE QUIET GUEST:** "*...I have only tidied... I have broken nothing...*"
> ► **"I won't tell."** — The spirit relaxes slightly.
> ► **"You can't stay here."** — A small whimper.
> ► **"The farmer's wife has been feeding you."** — **GUEST:** "*...she is very kind...*"

**Scene 3: the wife.** Down in the kitchen, Gu's wife is stirring a pot, entirely unsurprised.

**GU'S WIFE:** "I know. I've known for a month."
**GU:** "You... *what?*"
**GU'S WIFE:** "It's frightened. It's a child, near enough. I put out milk."
*Gu stares at his wife for a long moment.*
> ► **"Let it stay until the siege ends."** — The wife nods.
> ► **"Take it to a higher shrine."** — A long, quiet journey.
> ► **"Teach it to hide better."** — A comic lesson.

**Scene 4: the rooster.** The rooster, a vain and furious bird, challenges the spirit at dawn. The spirit, startled, hides inside the rooster's feathers. The rooster, bewildered and flattered, falls silent for the first time in its life.

**GU:** "...It's *in* the rooster."
**GU'S WIFE:** "They get along."

**Outcomes and receipt.**
- The spirit is hidden in the loft, taken to a shrine, or given a rooster, depending on choice. Gu's wife starts speaking to him again. The loft stays tidy.
- **Receipt:** a small bowl of warm milk on the loft ledge, a faint bell-sound at dusk, and the rooster quiet in the evenings.

<!-- quest
id: qst_han_rice_loft_guest
title: A Guest in the Rice Loft
rank: B
type: Hidden
giver: npc_gu_jaesung
region: reg_haneul
level: 93
act: 4
requires_rank: B
reward: 10600 | 630 | 45500
sets: han_loft_done
summary: A shy mountain spirit hiding from demons has tidied a farmer's rice loft into towers, and the farmer wants it gone.
objectives:
  talk npc_gu_jaesung
  talk npc_spirit_of_the_loft
  reach haneul_terrace_four_kitchen
  choice stay_shrine_or_hide
-->

---

## 5. The Paper Varos Set

*A · Investigation · the capital · giver Examiner Baek Seonwoo*

**The short version.** A sealed scroll arrived at the wall wrapped in red silk. It is a question paper. The chief examiner has read ten thousand and does not know how to grade this one.

**What is really going on.** Varos treats the siege as an examination the kingdom is failing, and he has set a paper to prove it. Eleven questions. The first reads: *"Name the enemy the wall was built for. Name the enemy at the gate. Explain the difference."* He expects the court to answer. He does not expect the answers to be *kind.*

**Scene 1: the examiner.**

**BAEK:** "I have been chief examiner for twenty-six years. I know a good question when I see one."
**BAEK:** "This is a good question. That is what frightens me."
**BAEK:** "Eleven questions, in a demon's neat hand. And a line at the end: 'Submit before the new moon.'"
> ► **"What do the questions ask?"** — **BAEK:** "How the kingdom prepares. How it fails."
> ► **"Why answer a demon?"** — **BAEK:** "Because I do not like leaving a question unanswered."
> ► **"I'll help."** — **BAEK:** "Bring a clear head. And a steady brush."

**Scene 2: the questions.** In a quiet room, the player and the examiner read the eleven questions. The first is a challenge. The sixth is a taunt. The ninth is *genuinely curious.*

**BAEK:** "He asks: 'What is the thing your people will not surrender, if they must surrender everything else?'"
**BAEK:** "I do not know how to answer that. I think it is the only question that matters."
*(Gameplay: a conversation puzzle. The player gathers answers from five citizens: a scholar, a soldier, a mother, a spirit-keeper, a child. Each answer shapes the final paper.)*
> ► **"Ask the child."** — **CHILD:** "Our names."
> ► **"Ask the soldier."** — **SOLDIER:** "Our shoes at the door."
> ► **"Ask the mother."** — **MOTHER:** "Our dead."

**Scene 3: the paper.** The examiner and the player compose a reply. The player may answer in defiance, in plain honesty or in a courteous refusal.

**BAEK:** "I will write it in my best hand. A demon will read it, and I want him to see that a scholar wrote it."
> ► **"Defy him."** — The paper is sharp.
> ► **"Answer him honestly."** — The paper is humble, and strong.
> ► **"Refuse the examination, politely."** — The paper is three lines.

**Scene 4: the delivery.** The paper is tied to an arrow and shot from the wall at dusk. At dawn, a single line of red calligraphy appears on the clouds above the gate, visible from the whole pass.

**RED LINE:** *"Received. Marked. A promising answer. The examination continues."*
**BAEK:** "...He *graded* it."

**Outcomes and receipt.**
- Varos's next message to the capital, before the fight, is different in tone depending on the paper: more precise, more curious or more cold. The capital learns, for the first time, that he reads. He is not softened. The siege is unchanged.
- **Receipt:** a copy of the paper pinned beside the gate, and a faint line of red script on the clouds that readers insist changes every dawn.

<!-- quest
id: qst_han_paper_varos_set
title: The Paper Varos Set
rank: A
type: Investigation
giver: npc_baek_seonwoo
region: reg_haneul
level: 131
act: 4
requires_rank: A
requires_quests: qst_han_exiles_survey
reward: 30500 | 1580 | 134000
sets: han_paper_done
summary: Varos has sent the capital an eleven-question examination paper, and the chief examiner needs help answering it.
objectives:
  talk npc_baek_seonwoo
  reach haneul_capital_archive
  talk npc_baek_seonwoo
  choice defy_honest_or_refuse
-->

---

## 6. Terrace Seven Holds

*B · Defense · Terrace Seven · giver Sergeant Jo Dalsu*

**The short version.** Forty soldiers, six hundred sacks of barley and one terrace stand between the demons and the next two towns. The sergeant is delighted.

**What is really going on.** The terrace is not strategic. It is a granary, and the barley will feed two thousand people through the winter. The sergeant knows it cannot be held forever. He wants it held for *one night,* long enough to move the barley down the pass, and he wants to do it without a single soldier dying for grain.

**Scene 1: the terrace.**

**JO:** "Forty men. Six hundred sacks. One wall that was built for goats."
**JO:** "I like it! It is a clear task. Hold the wall. Move the sacks."
**JO:** "A few demons will come at dusk. They always come at dusk. Terribly punctual."
> ► **"What do you need?"** — **JO:** "Hands on the sacks. A shield at the gap."
> ► **"Is the grain worth it?"** — **JO:** "Two thousand people. Yes."
> ► **"I'll hold the gap."** — **JO:** "Splendid. Try not to die. It's bad for morale."

**Scene 2: the dusk.** As the sun goes red, the demons come, in scouting waves, shrieking, down the terraces. The soldiers form a line at the goat-wall.
*(Gameplay: defense. Hold the gap; load sacks onto carts with the men; keep the line alive for three waves.)*

**SOLDIER:** "Sergeant! The east post is breaking!"
**JO:** "Fall back to the second wall! Sing something!"
**SOLDIER:** "*Sing?*"
**JO:** "Something *rude!*"
> ► **"Reinforce the east post."** — The line steadies.
> ► **"Burn the oil-barrels at the gap."** — A bright, loud barrier.
> ► **"Send the carts early."** — The grain moves.

**Scene 3: the last cart.** The final cart is stuck in a rut. The demons are close. The sergeant and a dozen soldiers hold the gap while the player and a boy heave the wheel.

**JO:** "Push! Push! Push, you beautiful ox!"
*The cart lurches free.*
**JO:** "*GO!*"

**Scene 4: the dawn.** The terrace is empty of barley, and every soldier is alive. The demons are picking through the wreckage of the goat-wall.

**JO:** "Forty out of forty."
**JO:** "I shall want a medal. Not a *good* one. A lumpy one."

**Outcomes and receipt.**
- The barley reaches the lower towns; the winter ration holds a month longer. Terrace Seven falls, but the sergeant and his men withdraw to a new line. If oil-barrels were burnt, a scorched ridge slows the next advance.
- **Receipt:** a lumpy bronze medal pinned on the player's sleeve, and a painted tally on the lower granary: *600 sacks. 40 men. Home.*

<!-- quest
id: qst_han_terrace_seven
title: Terrace Seven Holds
rank: B
type: Defense
giver: npc_sergeant_jo_dalsu
region: reg_haneul
level: 96
act: 4
requires_rank: B
reward: 11000 | 650 | 47000
sets: han_terrace_done
summary: Forty soldiers hold a granary terrace for one night so six hundred sacks of barley can be moved down the pass.
objectives:
  talk npc_sergeant_jo_dalsu
  defend haneul_terrace_seven
  choice east_oil_or_carts
-->

---

## 7. Tablets Down the Pass

*B · Delivery · the upper gate-town · giver Widow Na Okja*

**The short version.** Seven generations of a family's ancestor tablets lie in a house behind demon lines. The widow who owns them has fled with her children and cannot sleep.

**What is really going on.** The widow does not ask for the house, the furniture or the savings. She asks for the *tablets.* Without them, her family has no ancestors in the world, and the rites of Solenday cannot be performed. The player must slip into a gate-town the demons now hold, find the right house, and carry seven generations down the pass.

**Scene 1: the refugee camp.**

**NA:** "Seven generations. My husband's grandfather's grandfather. Their names, in black lacquer."
**NA:** "I carried my children out. I did not carry them. I was a fool."
**NA:** "I do not ask you to be brave. I ask you to be *quiet.*"
> ► **"Where is the house?"** — **NA:** "Third lane. Under the willow. The door is blue."
> ► **"Is it safe?"** — **NA:** "Nothing is."
> ► **"I'll bring them."** — **NA:** "Bring them *gently.*"

**Scene 2: the upper town.** The upper gate-town is a dim, empty place of hush and shuttered doors. Red light pools in the gutters. In the main square, demons mill, bored and watchful.
*(Gameplay: stealth. Follow back alleys, use rooftops, avoid the square. Take shoes off at the door of the blue house, out of habit.)*

**VOICE (from the dark):** "*...you took off your shoes...*"
*A small, ancient house-spirit peeks from behind the lintel.*
> ► **"It's the custom."** — The spirit nods approvingly.
> ► **"I'm here for the tablets."** — **SPIRIT:** "*...I have been guarding them.*"
> ► **"Please let me through."** — The spirit points.

**Scene 3: the tablets.** On the family altar, seven black-lacquered tablets stand in a row, bright with a thin film of dust. The player wraps each in cloth, one by one, and says the name aloud, as custom asks.

**PLAYER (reading):** "Na Chunbae. Na Gyeongsu. Na Dongil..."
*A small sound at the door. A demon patrol pauses outside.*
> ► **"Hide in the altar alcove."** — A tense minute.
> ► **"Slip out the back."** — A quiet exit.
> ► **"Leave a tablet behind to draw them."** — **SPIRIT:** "*...No. Never.*"

**Scene 4: the pass.** The player carries the tablets down the long road, past the bend-shrines, to the camp. Na Okja stands at the edge, hands clasped, her children behind her.

**NA:** "...Seven."
**NA:** "Thank you. I will not forget your shoes."

**Outcomes and receipt.**
- The tablets are rehoused in the camp's shrine-tent, and the Solenday rite is held. Neighbouring families ask the player to retrieve their own, which is not possible; instead, the camp begins a *shared altar* of names.
- **Receipt:** a long shelf of tablets at the camp shrine-tent, each with a candle; the Na family's seven in the middle.

<!-- quest
id: qst_han_tablets_down_pass
title: Tablets Down the Pass
rank: B
type: Delivery
giver: npc_widow_na_okja
region: reg_haneul
level: 100
act: 4
requires_rank: B
reward: 11800 | 690 | 49000
sets: han_tablets_done
summary: A widow asks the player to slip into a demon-held gate-town and carry her family's seven ancestor tablets down the pass.
objectives:
  talk npc_widow_na_okja
  reach haneul_upper_town_blue_house
  reach haneul_refugee_shrine
  choice altar_back_or_lure
-->

---

## 8. Drums on the Wall

*A · SiegeDefence · the Unfallen Wall · giver Wall-captain Oh Seongmin*

**The short version.** Tomorrow is the anniversary of the winter the wall held against an army from the north. The garrison has been awake for ninety-one nights. The captain wants the drums played.

**What is really going on.** The anniversary is a festival. The wall's drum-vigil has been played every year for a hundred and eleven years, and this year the demons are listening. The captain does not want to fight with the drums; he wants to *keep the vigil*, because the kingdom has to know the wall still stands. A raid is coming to stop it. The player holds the drummers.

**Scene 1: the drum-house.**

**OH:** "Ninety-one nights. My men have forgotten what sleep is. But tonight they will play."
**OH:** "The drums are older than the wall. My grandmother's grandmother played them."
**OH:** "The demons will try to silence them. I need someone to stand with the drummers."
> ► **"Why drums?"** — **OH:** "So the valley knows we are here."
> ► **"What is the plan?"** — **OH:** "Play. Hold. Play."
> ► **"I'll stand with them."** — **OH:** "Don't let them stop."

**Scene 2: the vigil.** The drums begin at dusk: slow, enormous, rolling across the valley. Along the wall, torches are lit one by one. In the pass below, the red light pulses with the beat.
*(Gameplay: a siege defense. Waves of demons climb the wall; the player defends the drum-platform; each drummer lost makes the beat thinner, and the garrison's morale falls.)*

**DRUMMER:** "I can't feel my arms!"
**OH:** "Then play with your *heart!*"
> ► **"Cover the east drum."** — A line holds.
> ► **"Rally the garrison with a shout."** — The wall roars.
> ► **"Take a drum yourself."** — A rough, steady beat.

**Scene 3: the dark hour.** At midnight, the beat falters. A demon officer, tall and elegant, appears on the far ridge and watches.

**OH:** "Varos's men. They watch for the break."
**OH:** "Keep it going. *Keep it going.*"
*A single old drummer, bent double, picks up the beat alone. The others, one by one, join.*

**Scene 4: the dawn.** The vigil ends at sunrise. The drums fall silent. The wall is intact. Along the whole length of it, the soldiers lift their sticks.

**OH:** "Ninety-two nights."
**OH:** "...I shall sleep for a week."

**Outcomes and receipt.**
- The vigil holds; the siege is unchanged, but the kingdom hears the drums in every gate-town and stands taller. If the garrison was rallied, morale holds a full week; if the player took a drum, the drummers adopt a new rhythm, called the Stranger's Beat.
- **Receipt:** a new drum on the wall, painted with the date, and a morning drum-roll at the Cloud Gate Guesthouse each dawn.

<!-- quest
id: qst_han_drums_on_wall
title: Drums on the Wall
rank: A
type: SiegeDefence
giver: npc_oh_seongmin
region: reg_haneul
level: 136
act: 4
requires_rank: A
requires_quests: qst_han_terrace_seven
reward: 32000 | 1640 | 140000
sets: han_drums_done
summary: On the anniversary of the winter the wall held, the garrison plays the drum-vigil while a raid tries to silence it.
objectives:
  talk npc_oh_seongmin
  defend haneul_drum_platform
  choice east_shout_or_drum
-->

---

## 9. The Watchman Who Still Faces North

*B · Exploration · the Unfallen Wall, north post · giver Young Sentry Kwon Haru*

**The short version.** At the oldest post on the northern end of the wall, an old watchman has faced north for sixty years. Nobody has told him to stop. Kwon Haru is not sure he should be the one.

**What is really going on.** The watchman knows the enemy never came from the north. He knows about the red gate. He is not confused; he is *keeping a promise* to a friend who died at the post, who made him swear to watch north until the enemy came. The old man has long since decided that keeping a promise is a kind of defence.

**Scene 1: the north post.**

**HARU:** "He stands there. All day. All night. He nods at me and goes back to watching."
**HARU:** "I thought he was senile. He isn't. He told me the names of every sentry since the wall's building."
**HARU:** "I want to ask him why. I'm afraid of the answer."
> ► **"Ask him politely."** — **HARU:** "I've tried. He says, 'It is a long story.'"
> ► **"Sit with him."** — **HARU:** "He doesn't talk to people who stand."
> ► **"I'll go."** — **HARU:** "Bring tea. He likes the cold cup."

**Scene 2: the vigil.** On the north parapet, an old man in a faded coat stands motionless, hands behind his back, eyes on the empty pass. The wind plays with his white beard.

**CHAE:** "You have brought tea. I will drink it standing."
**CHAE:** "I do not mind company. I mind distraction. Please do not distract me from the north."
*(Gameplay: a slow conversation, with the player standing beside the old man and watching the north too. Over an hour, the pass changes in the light.)*
> ► **"What are you watching for?"** — **CHAE:** "A promise."
> ► **"Nothing has come."** — **CHAE:** "That is what makes it a good watch."
> ► **"The enemy is in the sky."** — **CHAE:** "I know."

**Scene 3: the promise.** Chae tells the story, slowly, to the north wind.

**CHAE:** "My friend, Pak. We were sentries together. He died of a fever the second winter. His last words: 'Watch north until they come.'"
**CHAE:** "I said I would. I have said it every morning for sixty years."
**CHAE:** "I know the enemy is not coming from the north. I know it has gone wrong. But I said I would."
> ► **"He would release you."** — **CHAE:** "He would. I would not release myself."
> ► **"Let me watch for a while."** — Chae hesitates.
> ► **"Teach Haru to keep the watch."** — A handing-on.

**Scene 4: the relief.** Chae accepts a single hour of relief, the first in sixty years. He sits on the parapet step and drinks his tea hot. Haru takes the north watch, awkwardly at first, then steadily.

**CHAE:** "It is a very good view."
**CHAE:** "I had forgotten."

**Outcomes and receipt.**
- The north post is now kept by two: Chae at dawn, Haru by night, a quiet partnership. The wall's watch adopts the custom of the *promised watch,* a post kept by one who made a promise to a friend.
- **Receipt:** a second stool on the north parapet, and a small tin cup of cold tea left each dawn on the stone for Pak.

<!-- quest
id: qst_han_watchman_north
title: The Watchman Who Still Faces North
rank: B
type: Exploration
giver: npc_kwon_haru
region: reg_haneul
level: 103
act: 4
requires_rank: B
reward: 12500 | 730 | 52000
sets: han_watchman_done
summary: An old watchman has faced north for sixty years, long after the wrong enemy was known, and a young sentry wants to know why.
objectives:
  talk npc_kwon_haru
  reach haneul_north_post
  talk npc_old_watchman_chae
  choice relieve_watch_or_teach
-->

---

## 10. Shrines at Every Bend

*A · Defense · the pass · giver Spirit-keeper Eom Sora*

**The short version.** Forty small shrines line the pass, one at every bend. The spirits that live in them are hunted first. Eom Sora wants someone to hold the last twelve.

**What is really going on.** The shrines are not strongholds. They are *roadside altars*, and the spirits are small, shy and bound to them. When a shrine falls, the spirit is gone and the pass is a little emptier of the thing that makes it a road. Eom Sora cannot save them all. She wants them to be *remembered,* and she wants the twelve that remain to be held through a single bad night.

**Scene 1: the keeper.**

**EOM:** "Forty shrines. A spirit in each, a little brown thing the size of a cat, or a lantern-fly, or a sigh."
**EOM:** "Twenty-eight are gone. The red ones take them in the dark."
**EOM:** "I cannot fight. I can tend. I need someone who can stand at a bend and *not move.*"
> ► **"What do I do?"** — **EOM:** "Stand at a shrine. Let nothing pass."
> ► **"Can they be saved?"** — **EOM:** "Some. If they are not left alone."
> ► **"I'll hold the twelve."** — **EOM:** "I will light the lamps."

**Scene 2: the night.** On the pass, twelve small lamps are lit, one by one. In the dark, demons move between the bends in twos and threes.
*(Gameplay: a defense-by-position challenge. The player runs between bends, holds a shrine until the spirit's lamp steadies, then moves on; each shrine saved raises a faint chime along the pass.)*

**SPIRIT (at a shrine):** "*...thank you... I thought I was alone...*"
**EOM:** "Do not stay. Run to the next. They are on the ninth bend."
> ► **"Hold the ninth."** — A hard fight.
> ► **"Carry a lamp to the tenth."** — A race.
> ► **"Call the spirits to one shrine."** — A gamble.

**Scene 3: the twelfth.** At the last bend, a small brown thing the size of a cat sits on the altar, shivering. The lamp has guttered. A demon officer stands over it, courteous and unhurried.

**DEMON:** "You are very persistent. It is a pleasing quality. Step aside."
> ► **"No."** — The demon pauses.
> ► **"What do you want with it?"** — **DEMON:** "Nothing. It is simply in the way."
> ► **"Take me instead."** — **DEMON:** "I am not authorised to accept."

**Scene 4: the dawn.** The demon withdraws before sunrise. Twelve small lamps burn along the bends. In the grey light, Eom Sora walks the line, touching each altar.

**EOM:** "Twelve."
**EOM:** "Twelve of forty. It is not enough. It is what we have."

**Outcomes and receipt.**
- Twelve shrines are held, and the other twenty-eight are honoured by name. The pass-keepers add the *lamp-round* to their duties. The red gate is unchanged; the demons are still hunting spirits.
- **Receipt:** twelve lit lamps along the pass, and twenty-eight small stones set in a row beside the keeper's hut, each marked with the name of a spirit.

<!-- quest
id: qst_han_shrines_every_bend
title: Shrines at Every Bend
rank: A
type: Defense
giver: npc_eom_sora
region: reg_haneul
level: 142
act: 4
requires_rank: A
requires_quests: qst_han_rice_loft_guest
reward: 34000 | 1700 | 148000
sets: han_shrines_done
summary: A shrine-keeper asks the player to hold the last twelve of the pass's forty bend-shrines through one dark night.
objectives:
  talk npc_eom_sora
  defend haneul_bend_shrines
  choice ninth_tenth_or_gather
-->
