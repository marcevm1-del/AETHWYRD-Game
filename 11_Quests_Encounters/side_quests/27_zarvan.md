# 11e-27 — Zarvan, the Garden Cities: Ten Side Quests (draft)

> *"The div-kings ruled Zarvan before people did. They signed the garden treaties in water, and water forgets."*
> — Gazetteer, Zarvan

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the third regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light.

**Region:** `reg_zarvan` (the terraced garden cities, the Great Aqueduct, the Rose Palace, the University quarter, the mountain villages above, the road to the Div Springs). **Rank band:** B–A. **Tone:** courteous, fragrant, and quietly frightened. Everyone is polite to everyone, because the water is rationed and nobody can afford an enemy. Poetry is how arguments are won, and also how they are lost.

**Placement notes.**
- **Zahhar, King of the Divs,** is the region's Tyrant. He holds the springs above three cities and demands tribute in roses, rosewater and poets. Canon: he is not entirely wrong. No quest here kills him or ends the pressure on the water; quests 7, 8 and 9 change what the cities *say* to him, how they prepare, and one thing he says back.
- Zahhar's servants are called **stone-bearers**: tall, quiet div-kin who collect tribute at the Div Springs gate. They are courteous in their own way and never break an agreement made in water.
- **Customs the quests rely on.** Garden treaties are sealed by pouring a cup of water into a shared basin. Wasting water is a sin and a crime; *used* water (bath, wash, fountain) may be reused without limit. Poetry is prayer, and a well-made verse may be offered as argument in a water-court. Every garden has a shrine at its spring. A tribute caravan goes unarmed, by treaty custom: "roses, not spears."
- Earlier pattern quest in this region: *The River That Remembered Its Bed* (Master Azar, the first garden's carved treaty). Nothing here repeats it.
- The **Forty Days** (the engineers who repaired the broken aqueduct after the great earthquake, working in shifts without rest) is a living memory: grandparents in every city were there.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Rose That Bled | B | Investigation | Head Gardener Parvaneh Sohrabi | A garden drinks what it should not |
| 2 | Two Houses, One Tribute | B | OddJob | Perfumer Mahtab Ghorbani | Rosewater rivals, comic and warm |
| 3 | The Nightingale Who Would Not Sing | B | OddJob | Bird-Keeper Tooba Mansouri | A fountain hushed by rationing |
| 4 | A Cup for the Poet's Garden | B | Faction | Old Golnar Eshraghi | A grave-garden, a water-court, a verse |
| 5 | Seven Wells, One Song | B | Exploration | Clerk Ardavan Shirazi | A mountain village and a hummed key |
| 6 | The Unarmed Caravan | B | Escort | Caravan-Master Hormoz Esfandiari | Defending what custom forbids you to arm |
| 7 | The Poem Zahhar Asked For | A | Escort | Student Farid Nouri | A poet walks up the stair |
| 8 | Forty Days Again | A | Defense | Chief Engineer Soraya Tahmasbi | A broken channel and a long night |
| 9 | The Basin from the Caves | A | Hidden | Professor Kamran Delavar | What the plunderers took, and who gives it back |
| 10 | Who Drinks First | A | Faction | Water-Master Roxana Ardalan | One city is to be left dry |

## Cast

<!-- npc
id: npc_zar_parvaneh
name: Head Gardener Parvaneh Sohrabi
tier: major
race: Human
region: reg_zarvan
settlement: The Rose Palace
role: Head gardener of the Sixth Terrace
backstory: A broad-shouldered, soft-voiced head gardener who has kept the Sixth Terrace of the Rose Palace for thirty years and talks to every bush as if it were a nervous guest.
-->
<!-- npc
id: npc_zar_dara
name: Apprentice Dara
tier: townsfolk
race: Human
region: reg_zarvan
settlement: The Rose Palace
role: Gardener's apprentice, aged fifteen
backstory: A thin, sleepless apprentice who wanted only to save his terrace from the ration and is now too frightened of what he did to say it out loud.
-->
<!-- npc
id: npc_zar_mahtab
name: Perfumer Mahtab Ghorbani
tier: major
race: Human
region: reg_zarvan
settlement: Zarvan, the Perfumers' Row
role: Mistress of the House of the Dawn Petal
backstory: A brisk, proud perfumer whose family has pressed damask rosewater at dawn for nine generations and who regards noon-picked roses as a form of rudeness.
-->
<!-- npc
id: npc_zar_jamshid
name: Perfumer Jamshid Rahimi
tier: major
race: Human
region: reg_zarvan
settlement: Zarvan, the Perfumers' Row
role: Master of the House of Noon Gold
backstory: A cheerful, round perfumer whose house grows a golden cultivar that opens only at midday, and who has been losing an argument about it to Mahtab Ghorbani for twenty years with great enjoyment.
-->
<!-- npc
id: npc_zar_tooba
name: Bird-Keeper Tooba Mansouri
tier: major
race: Human
region: reg_zarvan
settlement: The Rose Palace
role: Keeper of the palace nightingales
backstory: A small, fierce bird-keeper who has served the palace nightingales for forty years, believes birds are better judges of poetry than critics, and has not slept properly since the fountains were hushed.
-->
<!-- npc
id: npc_zar_golnar
name: Old Golnar Eshraghi
tier: major
race: Human
region: reg_zarvan
settlement: The Garden of Last Verses
role: Last living student of a famous poet
backstory: A ninety-year-old woman who tends the grave-garden of her teacher, the poet Simin Aghdasi, alone, and who has watched it dry to the roots on the water-masters' ration.
-->
<!-- npc
id: npc_zar_anoush
name: Water-Master Anoush Farrokhi
tier: major
race: Human
region: reg_zarvan
settlement: Zarvan, the Water-Court
role: Water-master and judge of the water-court
backstory: A dry, scrupulous judge who has never wasted a drop and never allowed a good verse to be wasted either, and who is tired in a way she does not show.
-->
<!-- npc
id: npc_zar_ardavan
name: Clerk Ardavan Shirazi
tier: townsfolk
race: Human
region: reg_zarvan
settlement: Zarvan, the Water-Court
role: Junior clerk of the water-masters
backstory: A rumpled junior clerk who found an old survey of a sealed channel in a drawer, got excited, and was sent to the mountains with no instructions and a letter of introduction nobody will read.
-->
<!-- npc
id: npc_zar_nasrin
name: Headwoman Nasrin Davoudi
tier: major
race: Human
region: reg_zarvan
settlement: Dehbala, a mountain village
role: Headwoman of a mountain village
backstory: A weathered, courteous headwoman who offers every stranger tea three times before she asks them anything, and who keeps her village's oldest secret in a children's counting rhyme.
-->
<!-- npc
id: npc_zar_hormoz
name: Caravan-Master Hormoz Esfandiari
tier: major
race: Human
region: reg_zarvan
settlement: The road to the Div Springs
role: Master of the rose-tribute caravan
backstory: A greying caravan-master who has carried the tribute up the mountain road four times and has never once been robbed, which he attributes to luck and which everyone else attributes to the custom of the unarmed caravan.
-->
<!-- npc
id: npc_zar_farid
name: Student Farid Nouri
tier: townsfolk
race: Human
region: reg_zarvan
settlement: Zarvan, the University quarter
role: Student of the poet Roshanak Behrouzi
backstory: A passionate nineteen-year-old poet who has organised his classmates into a vigil at the tribute gate and cannot bear that his teacher's last poem may be written for a tyrant.
-->
<!-- npc
id: npc_zar_roshanak
name: Poet Roshanak Behrouzi
tier: major
race: Human
region: reg_zarvan
settlement: The Div Springs road
role: Famous poet, taken as tribute
backstory: A calm, middle-aged poet whose verses are recited in every fountain court in Zarvan, and who answered Zahhar's summons with a courtesy that frightened her students more than any refusal.
-->
<!-- npc
id: npc_zar_soraya
name: Chief Engineer Soraya Tahmasbi
tier: major
race: Human
region: reg_zarvan
settlement: The Great Aqueduct, Third Arch
role: Chief engineer of the aqueduct guild
backstory: A stern engineer whose grandmother worked the Forty Days, who keeps her grandmother's tally-stick on her belt, and who has never admitted that she is afraid of this one.
-->
<!-- npc
id: npc_zar_kamran
name: Professor Kamran Delavar
tier: major
race: Human
region: reg_zarvan
settlement: Zarvan, the University quarter
role: Keeper of the Hall of Antiquities
backstory: A soft-spoken scholar of the plundered div caves who has spent a decade quietly proving that the University's finest silver basin is not an ornament, and who loves it too much to be sure what he wants to do about it.
-->
<!-- npc
id: npc_zar_roxana
name: Water-Master Roxana Ardalan
tier: major
race: Human
region: reg_zarvan
settlement: Zarvan, the Council of Water-Masters
role: Water-master of the lower terraces
backstory: A young water-master who inherited her seat from a father who said no to every petition, and has found out how heavy a sensible no can be.
-->
<!-- npc
id: npc_zar_siavash
name: Water-Master Siavash Kermani
tier: major
race: Human
region: reg_zarvan
settlement: Zarvan, the Council of Water-Masters
role: Senior water-master of the capital
backstory: A silver-bearded water-master who proposes the cruel sum in the gentlest voice and genuinely believes he is the only person at the table willing to do arithmetic.
-->

---

## 1. The Rose That Bled

*B · Investigation · the Sixth Terrace of the Rose Palace · giver Head Gardener Parvaneh Sohrabi*

**The short version.** A bed of roses on the Sixth Terrace has started to bleed. Cut a stem and a thin red sap runs out, warm to the touch. The court is whispering about omens. Parvaneh only wants to know whether the plants are sick.

**What is really going on.** Last winter, under the ration, her apprentice Dara planted a cutting of a wild mountain rose from the plundered caves into a bed backing on the old cistern wall. A crack in the wall leaks iron-red, snow-cold water from somewhere deep in the mountain, and the roses are drinking it. They are healthy. They are also, quite literally, drinking something that is not theirs.

**Scene 1: the terrace.**

**PARVANEH:** "Forgive the smell. That's the pruning. Or the blood. I can't tell any more."
**PARVANEH:** "I have kept this terrace thirty years. A rose does not bleed. A rose *weeps,* sometimes, in the heat. This is not weeping."
**PARVANEH:** "The court wants me to burn the bed before the shah's guests arrive. I would like to know what I am burning."
> ► **"Who planted the bed?"** — **PARVANEH:** "My apprentice. Dara. He has been oddly quiet."
> ► **"Is the sap poison?"** — **PARVANEH:** "Not to the bees. They love it. That frightens me more."
> ► **"I'll look into it."** — **PARVANEH:** "Please. And do not tell the court it is a miracle."

**Evidence.**
- **The sap** smells of iron and snowmelt, and carries a trace of mountain clay found nowhere in the palace gardens.
- **The roots** all run one way: toward a hairline crack in the old cistern wall behind the bed.
- **The crack** weeps cold water even in the dry season, and the stone around it is stained the same red.
- **Dara's tools** have been oiled every night, and a pressed cutting of a wild rose is hidden in his workbox, with a tag in a hasty hand: *From the cave-mouth. Do not tell.*

**Scene 2: the apprentice.** The player finds Dara at dawn, on his knees at the crack, pouring a thimble of his own drinking water into it.

**DARA:** "I only wanted the bed to live. They cut our water to a thimble. I found a cutting, and a crack, and I... I didn't *know* where the water came from."
**DARA:** "Then it started to bleed. And I thought, it's *his.* The king's. I've been stealing the king's water."
**DARA:** "I put my own back. A bit. Every night. I don't know if it counts."
> ► **"It might."** — **DARA:** "Really?"
> ► **"You should have said."** — **DARA:** "I know."
> ► **"Show me the crack."** — **DARA:** "Mind the roots. They're warm."

**Scene 3: the choice.** The water-masters, if told, will seal the wall and burn the bed, and treat the whole terrace as a diplomatic risk. The roses are not stolen goods, exactly, but they are certainly unpaid for.

> ► **(Report it to the water-court.)** — The crack is sealed. The bed is burned. The rest of the terrace is safe, and Dara is dismissed.
> ► **(Keep it quiet and shore up the wall.)** — The bed lives. The question of what is owed is left to the next flood.
> ► **(Pay it in the old way.)** — Set a basin at the crack, pour in a cup of rosewater, and say the words of the garden treaties out loud.

**PARVANEH:** (softly, as the cup is poured) "My grandmother did that at the spring in our village. I thought it was a thing grandmothers did."

**Outcomes and receipt.**
- If paid in the old way, the roses stop bleeding by the next dawn and bloom red-veined for ever after. Dara is kept on and made keeper of the basin. If reported, the terrace is safe and the apprentice learns what a ledger is. If hushed, the bleeding continues, quietly.
- **Receipt:** a small brass basin set into the cistern wall, filled each dawn. By the second morning someone has already emptied it. Nobody admits to it.

<!-- quest
id: qst_zar_rose_that_bled
title: The Rose That Bled
rank: B
type: Investigation
giver: npc_zar_parvaneh
region: reg_zarvan
level: 90
act: 4
requires_rank: B
reward: 10400 | 610 | 45000
sets: zar_rose_bled_done
summary: A bed of roses on the palace terrace bleeds when cut, because it has been drinking water that belongs to somebody else.
objectives:
  talk npc_zar_parvaneh
  talk npc_zar_dara
  choice report_hush_or_repay
-->

---

## 2. Two Houses, One Tribute

*B · OddJob · Perfumers' Row · giver Perfumer Mahtab Ghorbani*

**The short version.** Zahhar demands one hundred jars of rosewater. Two great perfume-houses each insist on filling the whole order. Both have sworn that the other's rosewater will never go up the mountain. Mahtab has hired the player to make sure hers does.

**What is really going on.** Neither house will give way because each believes its rosewater *is* Zarvan. Dawn damask is cool and clear; noon gold is warm and sweet. They have been quarrelling for twenty years, and both have, secretly, been wondering what the other's would smell like if blended. Nobody has had the nerve to try.

**Scene 1: the House of the Dawn Petal.**

**MAHTAB:** "There is a *correct* time to pick a damask rose, and that time is before the sun is above the wall. Anything later is simply *warm grass.*"
**MAHTAB:** "Jamshid Rahimi picks at noon. *Noon.* He puts a golden thing in a jar and calls it rosewater. It is a *tea.*"
**MAHTAB:** "The tribute is the shah's honour. It must be *dawn.*"
> ► **"What do you need?"** — **MAHTAB:** "A witness. And someone to make sure no cat gets into my still."
> ► **"Has he done that?"** — **MAHTAB:** "Last spring. A *very* large cat."
> ► **"I'll see he plays fair."** — **MAHTAB:** "Fair. Hah."

**Scene 2: the House of Noon Gold.** The player carries a polite message across Perfumers' Row. Jamshid is delighted.

**JAMSHID:** "She sent a *hireling!* Twenty years and she finally sent a hireling! Sit, sit. Have some of the tea. I mean, the rosewater."
**JAMSHID:** "Between us, I think her dawn damask is the finest scent in the world. Do not tell her. She would explode."
**JAMSHID:** "But a hundred jars of nothing but dawn? It will smell like a cold morning. The king is a *mountain.* He may want something warm."
> ► **"Tell her yourself."** — **JAMSHID:** "Never. That would be an *admission.*"
> ► **"Why not blend?"** — **JAMSHID:** "Oh, I would never. She would never. We *can't.*"
> ► **"What if I can't stop the sabotage?"** — **JAMSHID:** "Then let us have a *sporting* sabotage."

**Scene 3: the sabotage.** Over two days, the quarrel escalates comically: swapped labels, a misplaced ladder, a goat in a cellar, a lovingly forged letter from the water-court demanding both houses stop. The player is called a spy, a mediator, a nuisance and, once, a cat.

> ► **(Referee the quarrel as a contest.)** — Each house fills fifty jars, judged by the street.
> ► **(Quietly blend a test jar.)** — Mix a drop of each in secret, and let them taste it separately.
> ► **(Appeal to the water-court.)** — Let a judge assign the order. Both houses are furious.

**MAHTAB:** (tasting the test jar, silent for a long moment) "...This is *not* offensive."
**JAMSHID:** (tasting, very quietly) "Oh. Oh, it is *lovely.*"
**MAHTAB:** "We shall tell no one."
**JAMSHID:** "Absolutely no one."

**Outcomes and receipt.**
- If blended, the hundred jars go up the mountain under two seals. If contested, they go up split and half-argued. If settled by the court, the houses sulk for a season, and then, grudgingly, blend anyway.
- **Receipt:** a jar on the Perfumers' Row sign marked with both house-seals; the blend is sold in the market as "Two Hands" and sells out in a morning.

<!-- quest
id: qst_zar_two_houses
title: Two Houses, One Tribute
rank: B
type: OddJob
giver: npc_zar_mahtab
region: reg_zarvan
level: 92
act: 4
requires_rank: B
reward: 10800 | 630 | 46000
sets: zar_two_houses_done
summary: Two perfume-houses each insist on filling the whole rosewater tribute for Zahhar. Each has been quietly wondering how the other's smells.
objectives:
  talk npc_zar_mahtab
  talk npc_zar_jamshid
  choice contest_blend_or_court
-->

---

## 3. The Nightingale Who Would Not Sing

*B · OddJob · the nightingale aviary of the Rose Palace · giver Bird-Keeper Tooba Mansouri*

**The short version.** The palace nightingales have fallen silent. The shah's guests arrive at the new moon, and the birds have not sung since the fountains were hushed. Tooba has tried everything. She would now like the player to try something stupid.

**What is really going on.** The nightingales of Zarvan learn their songs beside running water, and sing only to the sound of it. The fountains now run for a quarter-hour at dawn, by order of the water-masters. The birds are not sulking. They are *waiting for the water to start.*

**Scene 1: the aviary.**

**TOOBA:** "Thirty-one nightingales. Eleven are the grandchildren of the first. Not one of them has sung in nine days."
**TOOBA:** "I have read them verses. I have read them *better* verses. I have read them my own verses, and one of them *left the room.*"
**TOOBA:** "A bird is a better critic than any critic. He does not pretend."
> ► **"Are they ill?"** — **TOOBA:** "They eat. They preen. They simply look at the empty fountain."
> ► **"When did it start?"** — **TOOBA:** "The day the fountains went quiet."
> ► **"Maybe it's the fountain."** — **TOOBA:** (very slowly) "...Do not say that to the court. They will want to give the birds *more water.*"

**Scene 2: the experiments.** A comic afternoon. A boy with a bucket pours water from a ladder. A poet recites into a basin to approximate the splash. Two palace cooks bang a ladle on a copper pot. A passing water-master asks, in a very level voice, what the *precise* purpose of the ladder is.

**WATER-MASTER (passing):** "Is any of this water leaving the palace?"
**TOOBA:** "No, Master. It is going back into the bucket."
**WATER-MASTER:** "...Carry on."
*One nightingale tilts its head. That is all. Then it looks away.*
> ► **"It needs to be a real fountain."** — **TOOBA:** "But the ration..."
> ► **"What if the water doesn't leave?"** — **TOOBA:** (stopping) "...Say that again."
> ► **"Bring the engineers."** — **TOOBA:** "Oh, they will *hate* this."

**Scene 3: the loop.** A young pump-engineer, grumbling, builds a small closed channel: a bucket-wheel and a pipe, so that the same cupful of water rises, spills, and falls again for an hour. It uses no new water. Nobody has ever thought of it as *allowed.*

**TOOBA:** "It is not waste. It does not *leave.*"
**ENGINEER:** "It is not waste. It is a very small, very stupid river."
*The wheel turns. The water chimes. Nothing happens. Then, from the back of the aviary, one note: a single, deeply critical, enormously pleased note.*

**Outcomes and receipt.**
- The birds sing. The loop-fountain is approved by the water-court as "reuse," and is soon copied in a dozen courtyards. If the player pushed the court for extra water instead, the song is sweeter but the palace is scolded.
- **Receipt:** a small recirculating fountain in the aviary with a plaque that reads *Nothing leaves. Everything sings.*; the first note is carved on the rim as a musical phrase.

<!-- quest
id: qst_zar_nightingale
title: The Nightingale Who Would Not Sing
rank: B
type: OddJob
giver: npc_zar_tooba
region: reg_zarvan
level: 94
act: 4
requires_rank: B
reward: 11000 | 640 | 47000
sets: zar_nightingale_done
summary: The palace nightingales have gone silent since the fountains were hushed. They are waiting for the water to start.
objectives:
  talk npc_zar_tooba
  reach zarvan_palace_aviary
  choice loop_water_or_ask_court
-->

---

## 4. A Cup for the Poet's Garden

*B · Faction · the Garden of Last Verses and the water-court · giver Old Golnar Eshraghi*

**The short version.** The grave-garden of the poet Simin Aghdasi has dried to the roots. Pilgrims have stopped coming. Her last student, ninety years old, will not live to see another spring. Golnar asks the player to help her get a single cup of water to every rose before the Night of Remembrance.

**What is really going on.** The ration allows water only for food, not for graves. A water-master may grant an exemption, but only if the case is argued in the old way: by a verse. Golnar's teacher wrote four hundred of them. Golnar has forgotten the one she needs.

**Scene 1: the garden.** A terrace of grey stems under a white sky. A tiny woman on a stool, sweeping a path that does not need sweeping.

**GOLNAR:** "She taught me for forty years. Never once raised her voice. When I wrote bad verse, she would say, 'Interesting,' and look at the fountain."
**GOLNAR:** "They say the garden may stand as a memory. I say a memory should be *green.*"
**GOLNAR:** "I remember the verse. I remember where it stood on the page. I do not remember the *words.*"
> ► **"What's the verse about?"** — **GOLNAR:** "Water. Everything is about water."
> ► **"Where can I find it?"** — **GOLNAR:** "Her books are in the University. Some of them. The ones the fire spared."
> ► **"I'll help you ask."** — **GOLNAR:** "Ask *well.*"

**Scene 2: the three paths.** The player has three honest ways to get water to the roses.
- **The verse.** Find the poem in the University stacks (Professor Kamran has a damp, friendly copy) and argue the exemption in the water-court.
- **The grey water.** Carry spent bath-water from the palace baths up four terraces. It is perfectly lawful, and extremely heavy.
- **The cup chain.** Ask each household on the street to give one cup of their own drinking water, and pass them hand to hand to the garden. It is not efficient. It is the kind of thing she would have written a poem about.

> ► **"Argue the verse."** — Water-Master Anoush will hear it in court.
> ► **"Carry the grey water."** — A long, sweaty, honest day.
> ► **"Ask the street."** — A hundred neighbours, a hundred cups.

**Scene 3: the water-court.** If the player argues, Anoush listens without expression.

**ANOUSH:** "Recite."
*The verse is short, four lines. It describes a rose dying of thirst, and the poet kneeling beside it with her own cup. Nobody in the court moves.*
**ANOUSH:** "...That is not the law."
**ANOUSH:** "But she was always a better judge than I am. Granted. One cup, per rose, per day, for forty days, from the palace overflow."
**GOLNAR:** (very quietly, to nobody) "She would have said, *Interesting.*"

**Outcomes and receipt.**
- By the Night of Remembrance the garden is faintly green. If the cup chain was chosen, a whole street stands at the gate with empty hands, crying a little. If the grey water was chosen, the gardeners of the palace baths decide to keep sending it.
- **Receipt:** one rose at the foot of Simin's stone, in full bloom, and a line of her verse written in the dust of the path.

<!-- quest
id: qst_zar_poets_garden
title: A Cup for the Poet's Garden
rank: B
type: Faction
giver: npc_zar_golnar
region: reg_zarvan
level: 96
act: 4
requires_rank: B
reward: 11400 | 660 | 48000
sets: zar_poets_garden_done
summary: A dying poet's last student wants one cup of water for every rose in her teacher's grave-garden. The ration allows water for food only.
objectives:
  talk npc_zar_golnar
  talk npc_zar_anoush
  choice verse_greywater_or_cupchain
-->

---

## 5. Seven Wells, One Song

*B · Exploration · Dehbala, a mountain village · giver Clerk Ardavan Shirazi*

**The short version.** A sealed channel, mentioned in one old survey, might feed a dry terrace in the capital. The channel runs through a mountain village that does not like outsiders. A junior clerk has been sent to ask, with a letter, and no idea how.

**What is really going on.** The channel is not sealed. It is *locked.* Seven well-shafts run down into it, and each hums a different note when the mountain wind passes over it. The sluice opens only when the seven are sounded in the right order. The order is hidden in a children's counting rhyme, and the village has kept it to itself since the Forty Days, when the city took half of their water and gave no thanks.

**Scene 1: the clerk.**

**ARDAVAN:** "I found it in a drawer! A survey of the Dehbala channel, forty years old, marked *sealed.* But sealed by *whom?* It would feed the whole of the Ninth Terrace."
**ARDAVAN:** "They sent me with a letter. It says 'Please.' I think that is all it says."
**ARDAVAN:** "They gave me tea three times and then asked me to go home."
> ► **"Why won't they talk?"** — **ARDAVAN:** "Something about the Forty Days. They looked at my badge as if it were a knife."
> ► **"Take me there."** — **ARDAVAN:** "You'll need an appetite for tea."
> ► **"Is it legal?"** — **ARDAVAN:** "I have no idea. I'm a clerk."

**Scene 2: the village.** Dehbala is a cluster of mud-brick houses clinging to a scree slope. Seven round stone wells stand in a line down the hill, each capped with a flat stone. The wind makes them hum, low and strange.

**NASRIN:** (pouring tea for the third time) "You may ask your question now. A guest should be fed before he is questioned."
**NASRIN:** "The city took our water in the Forty Days. We gave it freely. They did not say thank you. Not once. In forty years."
**NASRIN:** "Ask me again after you have said it."
> ► **"Thank you. For the water. From the city."** — **NASRIN:** (a long pause) "...That is the first time."
> ► **"We have no right to ask."** — **NASRIN:** "That is true. It is also not the question."
> ► **"What can the city give back?"** — **NASRIN:** "Now *that* is a question."

**Scene 3: the rhyme.** Children are skipping stones near the wells, chanting. The player listens until the rhyme repeats, and notes the seven names: *Crow, Pool, Ibex, Salt, Wind, Seed, Moon.* The wells carry the same seven carved marks.

**CHILDREN:** "*Crow in the morning, pool for the thirst, ibex before salt, and the wind before seed. Moon at the end, when the others have bowed.*"
*Each well hums, when the player lays a hand on its cap, a note a little deeper than the last. The sequence is not the order of the hill. It is the order of the rhyme.*
> ► **(Sound the wells in the rhyme's order.)** — The seventh hum drops. Somewhere below, stone moves.
> ► **(Ask Nasrin to do it.)** — She will, if the city pays what it owes.
> ► **(Leave it locked and report.)** — The clerk's survey is filed. The channel stays dry.

**NASRIN:** "The channel is yours to use. The sluice is ours to keep. If your city wants to open it, someone from Dehbala will turn the stones. Every time."

**Outcomes and receipt.**
- The channel runs. Dehbala becomes the **Wardens of the Seven Wells**, paid a share of the water and recognised in the water-court. If the player simply opened it without Nasrin's blessing, the village keeps its silence for another forty years.
- **Receipt:** seven small bells hung over the wells in the order of the rhyme; the clerk gets a posting to a desk with a window.

<!-- quest
id: qst_zar_seven_wells
title: Seven Wells, One Song
rank: B
type: Exploration
giver: npc_zar_ardavan
region: reg_zarvan
level: 98
act: 4
requires_rank: B
reward: 11800 | 680 | 49000
sets: zar_seven_wells_done
summary: A locked channel in a mountain village opens only when seven wells are sounded in the order of a children's rhyme, and the village has no reason to share it.
objectives:
  talk npc_zar_ardavan
  talk npc_zar_nasrin
  reach zarvan_dehbala_seven_wells
  choice sound_ask_or_report
-->

---

## 6. The Unarmed Caravan

*B · Escort · the road to the Div Springs · giver Caravan-Master Hormoz Esfandiari*

**The short version.** Zahhar's tribute travels up the mountain road in a caravan of rose-baskets, with no weapons, by treaty custom. Hormoz has made the trip four times without trouble. This year, the road has been watched.

**What is really going on.** A band of "water-sellers" has been charging villages triple for water carried up from the valley, and they have heard the tribute includes a hundred jars of rosewater and a cask of the last good cuttings. They plan to take it at the Narrow Stair, where the road climbs between two walls of rock. The custom of the unarmed caravan is the only protection the caravan has. It is also the only reason it is vulnerable.

**Scene 1: the staging yard.**

**HORMOZ:** "Roses, not spears. That is the treaty. It is also my insurance. No one in four generations has robbed the tribute. They say the stone-bearers *remember.*"
**HORMOZ:** "But the water-sellers do not care what the stone-bearers remember. And I have forty baskets, thirty mules and seven children who are carrying the lanterns."
**HORMOZ:** "If I arm the caravan, it is a breach, and Zahhar will know. If I do not, I will lose it. Find me a third thing."
> ► **"Who are the water-sellers?"** — **HORMOZ:** "A woman called Sheyda. She is not wicked. She is *hungry.*"
> ► **"What is the third thing?"** — **HORMOZ:** "That is why I hired you."
> ► **"I'll go ahead and look."** — **HORMOZ:** "Careful. They will see your boots."

**Scene 2: the Narrow Stair.** The player scouts ahead and finds the ambush: a dozen lookouts, ropes laid across the road, and a pile of stones on the ledge. Beside it, a hand-lettered ledger of what Sheyda's people are owed.

*Three approaches present themselves.*
- **Disguise.** The caravan's guards ride as poets: cloaks, scrolls, a lute with something inside it.
- **Quiet.** Strip the ambush of its ropes and ladders by night, before the caravan arrives.
- **Talk.** Meet Sheyda herself, with an offer.

> ► **(Ride as poets.)** — The guards march with their hands in their sleeves.
> ► **(Cut the ambush apart at night.)** — A tense, silent hour in the dark.
> ► **(Parley with Sheyda.)** — She is angrier, and fairer, than expected.

**Scene 3: the stair.**

**SHEYDA:** "I sell water because I own the cistern. I charge what the mountain charges me. If the shah would pay a fair price for a barrel, I would not need to rob a rose."
**PLAYER:** "What would you take?"
**SHEYDA:** "A written contract. A shah's seal. Three barrels a week, for a year."
*The offer is not the player's to give. But the caravan-master has a seal, and the tribute has a surplus.*

**HORMOZ:** "...I carry the seal of the tribute. It was never meant to buy *water.*"
**HORMOZ:** "It also was never meant to buy anything *else.* Do it."

**Outcomes and receipt.**
- The caravan reaches the Div Springs gate. Sheyda becomes the water-court's licensed carrier (if parleyed), or loses her ambush and her credit (if cut apart), or is simply outpaced by a caravan of very well-dressed liars (if disguised).
- **Receipt:** a wet seal pressed into the tribute-scroll by a stone-bearer at the gate, which Hormoz carries home and hangs over his door.

<!-- quest
id: qst_zar_unarmed_caravan
title: The Unarmed Caravan
rank: B
type: Escort
giver: npc_zar_hormoz
region: reg_zarvan
level: 100
act: 4
requires_rank: B
reward: 12200 | 700 | 51000
sets: zar_unarmed_caravan_done
summary: The tribute caravan must go unarmed by treaty custom, and a band of water-sellers plans to rob it at the Narrow Stair.
objectives:
  talk npc_zar_hormoz
  escort npc_zar_hormoz
  choice poets_night_or_parley
-->

---

## 7. The Poem Zahhar Asked For

*A · Escort · the Div Springs road · giver Student Farid Nouri*

**The short version.** Zahhar has asked for a poet by name. Roshanak Behrouzi has said yes. Her students are camped at the foot of the tribute stair, and they want her brought home before she writes anything for him.

**What is really going on.** Roshanak is not a hostage and not a collaborator. She is the first person in two hundred years to answer a div-king's summons in his own manner: with courtesy and a poem. She means to write it in the old form, on water, in the shape of a treaty: a *remembering.* Her students are afraid it will be praise. It will not. It is a question.

**Scene 1: the vigil.**

**FARID:** "She said, 'I will walk up with them.' She said it like she was going to the market. She *smiled.*"
**FARID:** "He wants a poem in his honour. A *tyrant.* The same hands that wrote 'The Garden of Salt.' I won't have them used."
**FARID:** "Bring her back. Please. Bring her back before she writes it."
> ► **"What does she say?"** — **FARID:** "Nothing. She asked me to look after the library."
> ► **"What if she wants to go?"** — **FARID:** "...She does. That's what frightens me."
> ► **"I'll walk up with her."** — **FARID:** "Thank you. Don't let him keep her."

**Scene 2: the stair.** A long climb of cut stone, wet in the shadows, lined with offering-niches that are all empty. Roshanak walks at an unhurried pace, a plain satchel on her shoulder.

**ROSHANAK:** "You are the one my students sent. Good. They would send a platoon if they could. I did not want a platoon."
**ROSHANAK:** "Nobody has *asked* a div for anything in two hundred years. We asked for water, and took it, and wrote verses about gratitude. He asked for a poem. That is the first honest request this city has had."
**ROSHANAK:** "I do not intend to flatter him. I intend to *answer.*"
> ► **"Is that wise?"** — **ROSHANAK:** "Probably not."
> ► **"Your students are afraid."** — **ROSHANAK:** "They should be. I am a little afraid too."
> ► **"What are you going to say?"** — **ROSHANAK:** "That water forgets. And that poets do not."

**Scene 3: the gate.** Three choices, each real.

> ► **(Walk her to the gate and wait.)** — She recites the poem into the basin at the stone-bearers' feet.
> ► **(Turn her back.)** — She goes home, writes the poem in the University courtyard, and the player carries it up instead.
> ► **(Help her revise it.)** — The player may suggest a line, and she will weigh it.

*The poem is spoken into a stone basin at the foot of the gate. The stone-bearers do not move. For a long time there is only the sound of the water listening.*

**STONE-BEARER:** "The King has heard."
**STONE-BEARER:** "He says: *Water forgets.* He says: *The poet has not.*"
**STONE-BEARER:** "He says: *Come again.*"

**Outcomes and receipt.**
- Roshanak walks back down the stair, tired and radiant. The cities will argue for a season about what she said. The one thing no one can doubt is that Zahhar answered in her own coin.
- **Receipt:** two lines carved on the rim of the University fountain, in Zahhar's own wording: *Water forgets. The poet has not.* Farid is made keeper of the library.

<!-- quest
id: qst_zar_poem_asked
title: The Poem Zahhar Asked For
rank: A
type: Escort
giver: npc_zar_farid
region: reg_zarvan
level: 126
act: 4
requires_rank: A
reward: 29000 | 1520 | 128000
sets: zar_poem_asked_done
summary: A famous poet has answered Zahhar's summons with a poem. Her students want her home before she writes it.
objectives:
  talk npc_zar_farid
  escort npc_zar_roshanak
  choice gate_home_or_revise
-->

---

## 8. Forty Days Again

*A · Defense · the Great Aqueduct, Third Arch · giver Chief Engineer Soraya Tahmasbi*

**The short version.** A stretch of the Great Aqueduct has cracked above the Third Arch. Lower Zarvan will be dry in three days if it is not mended. The channel crosses a ledge that Zahhar's stone-bearers have marked as theirs, and they have come to watch.

**What is really going on.** The stone-bearers are not here to stop the repair. They are here to see whether the engineers will *ask.* Zahhar signed the treaty with the first shah, and the engineers have never once come to the springs to say, *We are going to cut your mountain.* The old forms of courtesy have lapsed. If the repair is done without them, the stone-bearers will bring it down.

**Scene 1: the arch.**

**SORAYA:** "My grandmother worked the Forty Days. She never said a word about it. She kept the tally-stick. I have it here."
**SORAYA:** "Three days. A crew of sixty. We work in shifts, as she did. A crew that stops is a crew that dies."
**SORAYA:** "Those are stone-bearers on the ledge. They have not moved. They have not spoken. I do not know what that means."
> ► **"Are they a threat?"** — **SORAYA:** "I don't know. I have a repair, not a diplomatic corps."
> ► **"What do you need?"** — **SORAYA:** "Hands. Light. Someone who can stand between sixty engineers and whatever comes next."
> ► **"I'll keep watch."** — **SORAYA:** "Thank you. Stay awake."

**Scene 2: the first night.** The crew works in shifts by lamp. The water booms in the cracked stone. Toward midnight, the scree above shifts, and a slow tremor runs along the ledge.

*Rock begins to fall in earnest.*
> ► **(Shield the crew from the rockfall.)** — The player holds the ledge for an hour.
> ► **(Climb to the ledge and speak to the stone-bearers.)** — A risky, courteous parley.
> ► **(Hold both.)** — Only the strongest could manage it.

**STONE-BEARER:** "You cut the mountain. You did not ask."
**SORAYA:** "...No. We did not."
**STONE-BEARER:** "Ask."
*The chief engineer climbs the ledge herself. She takes the tally-stick from her belt and holds it out, as if it were a cup.*

**SORAYA:** "We are going to mend a channel your king signed his name to. I am sorry we did not say so. We would like to finish by dawn."

**Scene 3: the second and third nights.** The rockfall lessens, then stops. The stone-bearers sit on the ledge and watch, like old men at a well. Once, one of them hands down a rope.

**Outcomes and receipt.**
- The channel is mended on the third night. If the player held the ledge, there are no injuries. If the player parleyed, the stone-bearers lend a hand and the repair finishes a night early.
- **Receipt:** a bronze count-mark set into the Third Arch beside the old Forty Days plaque: **40 + 3.** Soraya adds her grandmother's tally-stick to the plaque, and her own.

<!-- quest
id: qst_zar_forty_days
title: Forty Days Again
rank: A
type: Defense
giver: npc_zar_soraya
region: reg_zarvan
level: 130
act: 4
requires_rank: A
reward: 30500 | 1560 | 133000
sets: zar_forty_days_done
summary: A cracked section of the Great Aqueduct must be mended in three nights while Zahhar's stone-bearers watch from the ledge.
objectives:
  talk npc_zar_soraya
  defend zarvan_aqueduct_third_arch
  choice shield_parley_or_both
-->

---

## 9. The Basin from the Caves

*A · Hidden · the University Hall of Antiquities · giver Professor Kamran Delavar*

**The short version.** In the Hall of Antiquities stands a beautiful silver basin, taken from a div-cave a generation ago and labelled "ceremonial ewer." Kamran has spent ten years proving that it is no ewer. It is the basin the first shah used to seal the garden treaties in water.

**What is really going on.** The basin is the other half of the treaty. Zahhar signed it with water poured from this vessel, and the plunderers took it when the caves were sacked. The University board will not give it up, and the shah's council fears that returning it is a sign of weakness, or worse, an admission. Kamran will not steal it. He will not leave it either.

**Scene 1: the Hall of Antiquities.**

**KAMRAN:** "Look at the rim. See these notches? They are not decoration. They mark where each shah poured a cup. There are *eleven.*"
**KAMRAN:** "The first notch is the deepest. That is Zahhar's own. He poured first."
**KAMRAN:** "The rust-red on that patina is the same red I saw in the Sixth Terrace roses last spring. I do not think that is chance."
**KAMRAN:** "I want it taken back. The board says it is the University's finest piece. The council says it is a bargaining chip."
> ► **"What do you want?"** — **KAMRAN:** "To do the right thing. And to know what that is."
> ► **"Is it dangerous to return?"** — **KAMRAN:** "Everything is dangerous. Not returning is also dangerous."
> ► **"What if it's refused?"** — **KAMRAN:** "Then at least it was *offered.*"

**Scene 2: the argument.** The player speaks to three parties: the University's board (cultured, cautious), a councillor (suspicious, practical), and Kamran's own conscience (rueful, silent).

**BOARD CHAIR:** "It is the finest piece in the Hall. Seven generations of scholars have studied it. It *belongs* here."
**COUNCILLOR:** "If we return it, Zahhar will think we are paying. If we keep it, he will think we are sneering. We cannot win."
**KAMRAN:** "Then let us lose *honestly.*"
> ► **(Steal the basin for Kamran.)** — A tense, quiet theft with a clean conscience and a dirty ledger.
> ► **(Persuade the board.)** — Three audiences, and an argument about what a museum is for.
> ► **(Copy it, and carry the copy.)** — A faithful copy for the Hall; the original goes to the gate.

**Scene 3: the gate.** The player carries the basin up the stair and sets it in the stone cradle at the foot of the gate. The stone-bearers watch, motionless. Kamran pours in a cup of water from the University fountain, and says, with his voice shaking, the words of the first treaty.

**KAMRAN:** "This was taken. It is returned. We do not ask for anything in exchange."
*The stone-bearers do not answer. The water in the basin trembles. Then it is still.*

**Outcomes and receipt.**
- By morning the cradle at the gate is empty, and no one saw it go. Whatever the player chose, the basin is found filled with clear snowmelt, one rose floating on the surface, and the track leading away from it is neither human nor div. Nobody can say who it is for.
- **Receipt:** a stone cradle by the University gate, filled each dawn with a cup of water by the first student through the door. If the board refused and a copy was carried, the copy stands in the Hall with a plaque in Kamran's hand: *the original was returned.*

<!-- quest
id: qst_zar_the_cup
title: The Basin from the Caves
rank: A
type: Hidden
giver: npc_zar_kamran
region: reg_zarvan
level: 134
act: 4
requires_rank: A
requires_quests: qst_zar_rose_that_bled
reward: 32000 | 1600 | 138000
sets: zar_basin_done
summary: A silver basin taken from a div-cave is the other half of the garden treaties. A scholar wants it back at the gate and a board wants it kept.
objectives:
  talk npc_zar_kamran
  reach zarvan_div_springs_gate
  choice steal_persuade_or_copy
-->

---

## 10. Who Drinks First

*A · Faction · the Council of Water-Masters · giver Water-Master Roxana Ardalan*

**The short version.** The water-masters have reached an impossible sum: there is enough for three cities, not four. The motion before the council would cut the Lower Terraces, a city of forty thousand, off from the aqueduct for the season. Roxana would like the player to find another way.

**What is really going on.** The sum is true. There is not enough. But the sum assumes that every city draws its water in the same way, all day, as it always has. It does not need to. The Forty Days proved that the aqueduct can be run in shifts, with each city taking water on alternating days. The first time that was tried it saved the kingdom. Nobody has dared suggest it since.

**Scene 1: the council chamber.**

**ROXANA:** "Three cities. Four of us. The sum does not lie."
**SIAVASH:** "The sum does not lie, and I do not enjoy it. But it is arithmetic. The Lower Terraces have the fewest rose-guilds. They will survive."
**ROXANA:** "They will survive by *leaving.*"
**SIAVASH:** "Some of them."
> ► **"Is there another sum?"** — **ROXANA:** "There is *always* another sum. Find me one."
> ► **"Who benefits?"** — **ROXANA:** "Everyone with a vote."
> ► **"I'll go look at the Forty Days ledgers."** — **ROXANA:** "Bless you. I have never been allowed in."

**Scene 2: the ledgers.** In the aqueduct guild's archive, the player finds Soraya's grandmother's old rota: a table of alternating days that kept every city in the kingdom drinking for forty days with no extra water at all.

*It also carries a warning: the system works only if every city keeps the rota. A single city that cheats breaks it for all.*
> ► **"Is that possible again?"** — **SORAYA:** "It is possible. It is not *easy.*"
> ► **"What about the Lower Terraces?"** — **SORAYA:** "They'd get fewer days. But they'd get them."
> ► **"How do we sell it to Siavash?"** — **SORAYA:** "We do not. We *show* him."

**Scene 3: the vote.** The player has three audiences before the vote.
- **Siavash,** who wants to see a calculation.
- **The Lower Terraces,** who must agree to eat less, and say so.
- **The poets,** who must make the compromise sound like something other than defeat.

> ► **(Present the rota with Siavash's own figures.)** — A quiet, dry victory.
> ► **(Rally the Lower Terraces to speak.)** — A hundred voices in the chamber gallery.
> ► **(Commission a verse for the council.)** — The vote is carried in rhyme.

**SIAVASH:** (after a long silence, quietly) "...I should have thought of the Forty Days."
**ROXANA:** "Everyone should. It was the last time we were all one city."

**Outcomes and receipt.**
- The motion is withdrawn. Water is shared in shifts, and no city is left dry. If Siavash was shown rather than argued with, he becomes the rota's most careful guardian. If the Lower Terraces spoke, they are given a seat in the chamber.
- **Receipt:** the rota is painted on the council chamber wall in the colours of the four cities; below it, in smaller letters, *Every city drinks.*

<!-- quest
id: qst_zar_who_drinks
title: Who Drinks First
rank: A
type: Faction
giver: npc_zar_roxana
region: reg_zarvan
level: 138
act: 4
requires_rank: A
requires_quests: qst_zar_seven_wells
reward: 34000 | 1660 | 146000
sets: zar_who_drinks_done
summary: The water-masters' sum says one city must go dry. The Forty Days' old rota says otherwise, if every city keeps it.
objectives:
  talk npc_zar_roxana
  talk npc_zar_siavash
  talk npc_zar_soraya
  choice figures_voices_or_verse
-->
