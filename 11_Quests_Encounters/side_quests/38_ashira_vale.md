# 11e-38 — Ashira Vale, the Kindest Valley: Ten Side Quests (draft)

> *"Everyone is so very happy here. You'll stay a week, I think. Everyone does."*
> — Gazetteer, Ashira Vale

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 3, 4, 6 and 10 plant unexplained seeds.

**Region:** `reg_ashira_vale` (the town of Ashira and its dozen bridges, the Warden's Garden, the Hill Behind the Mill, the Hill Road). **Rank band:** B only (the gazetteer gives B–B), so every quest here is rank B (levels 86-119). **Tone:** gentle, sweet, warm; the horror is in how good everything feels, and nobody is ever threatened with a weapon.

**Placement notes.**
- **The Gentle Warden** is the region's Tyrant. It soothes away grief, ambition, regret and memory and takes what is left. No quest here fights, finds or banishes it; "fighting it means persuading people to want their pain back," and these quests are small, individual acts of that.
- Customs the quests rely on: doors are always open; every traveller gets bread, honey and a bed; the council meets on the first Solenday and decides nothing; honey is left in the Warden's Garden; there is **no graveyard, no funeral custom and no word for mourning;** residents change the subject gently and completely when asked where they came from or what they lost.
- **Open questions left open.** What the Warden is; what it does with "what is left"; where the dead, and the old, go; why the graveyard vanished. Quests 3, 4, 6 and 10 are labelled seeds.
- **Rank note.** All ten are rank B. Rewards sit in the B band (10-12.8k gold, 600-740 GP, about 44-55k XP). Quest 8 follows up the Guild's own missing investigator, which the Gazetteer states as a hook.
- The lead is to confirm that "B–B" is intended and not a typo for a wider band.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Husband Who Stopped Writing | B | Investigation | Hettie Ashdown | A woman from Aldmere and a happy letter |
| 2 | The Baker's Dream | B | Hidden | Baker Maudine Crumb | A battle she cannot remember |
| 3 | Why There Are No Old People | B | OddJob | Posy Applewhite | A child's question nobody can answer |
| 4 | The Hill That Hums | B | Exploration | Miller Alwyn Haskell | A meadow with a hum in it |
| 5 | Wanting the Ache Back | B | OddJob | Brannoch Hive | A soldier who misses his knee |
| 6 | The Milestones That Stop Counting | B | Exploration | Surveyor Ostrel Stonepace | A road that quits |
| 7 | Letters That Say the Same Thing | B | Delivery | Postmistress Lisbet Callow | Happy, happy, happy |
| 8 | The Investigator Who Was Happy | B | Investigation | Investigator Dessa Marchbank | The Guild's own missing agent |
| 9 | The Man Who Would Not Be Comforted | B | Escort | Innkeeper Hob Brackley | A guest who grieves |
| 10 | Honey for the Warden | B | Hidden | Gardener Lenna Honeywell | A quiet seat in a perfect garden |

## Cast

<!-- npc
id: npc_hettie_ashdown
name: Hettie Ashdown
tier: major
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Woman from Aldmere looking for her husband
backstory: A direct, practical dyer of forty-five who has walked the Hill Road twice to find her husband Wilhelm, who wrote that he was happy a year ago and then stopped writing.
-->
<!-- npc
id: npc_maudine_crumb
name: Baker Maudine Crumb
tier: major
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Baker who was once a famous adventurer
backstory: A cheerful, floury woman in her sixties who runs the best bakery in the vale and has begun, in the last month, to dream of a battle she cannot remember.
-->
<!-- npc
id: npc_posy_applewhite
name: Posy Applewhite
tier: townsfolk
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Child who asks why there are no old people
backstory: A clever, stubborn eight-year-old who has counted every resident of the vale on her fingers and noticed that none of them is older than sixty.
-->
<!-- npc
id: npc_osgar_haskell
name: Miller Alwyn Haskell
tier: major
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Miller whose mill stands below the hum
backstory: A broad, easygoing miller who has lived in the shadow of the Hill Behind the Mill his whole life and has recently begun to wonder why he never walks up it.
-->
<!-- npc
id: npc_brannoch_hive
name: Brannoch Hive
tier: major
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Retired soldier who keeps bees
backstory: A big, soft-spoken retired sergeant whose old war wound stopped hurting the day he arrived and who has started to miss the ache.
-->
<!-- npc
id: npc_ostrel_stonepace
name: Surveyor Ostrel Stonepace
tier: major
race: Human
region: reg_ashira_vale
settlement: The Hill Road
role: Road surveyor
backstory: A dry, methodical surveyor who was sent to re-mark the Hill Road and who has lost two apprentices to the vale, both of whom wrote that they were happy.
-->
<!-- npc
id: npc_lisbet_callow
name: Postmistress Lisbet Callow
tier: townsfolk
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Postmistress of Ashira
backstory: A tidy, precise postmistress who has noticed that every outgoing letter from a traveller who has stayed more than a week uses the same three phrases.
-->
<!-- npc
id: npc_dessa_marchbank
name: Investigator Dessa Marchbank
tier: major
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Guild investigator
backstory: A sharp, kind Guild investigator of thirty-eight who walked into Ashira a month ago and wrote back that she had never been happier.
-->
<!-- npc
id: npc_hob_brackley
name: Innkeeper Hob Brackley
tier: townsfolk
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Innkeeper of the Open Door
backstory: A round, kind innkeeper who loves every guest, and who is quietly worried about the one who will not stop crying.
-->
<!-- npc
id: npc_hale_dunmarrow
name: Hale Dunmarrow
tier: townsfolk
race: Human
region: reg_ashira_vale
settlement: Ashira
role: Traveller who lost his daughter a week ago
backstory: A haggard cartwright of fifty who arrived in Ashira three days ago, hollow with fresh grief, and who is the only person in the vale that the vale cannot comfort.
-->
<!-- npc
id: npc_lenna_honeywell
name: Gardener Lenna Honeywell
tier: major
race: Human
region: reg_ashira_vale
settlement: The Warden's Garden
role: Gardener of the Warden's Garden
backstory: A serene, smiling gardener who has tended the Warden's Garden for as long as she can remember, which is not very long at all.
-->

---

## 1. The Husband Who Stopped Writing

*B · Investigation · the town of Ashira · giver Hettie Ashdown*

**The short version.** Hettie's husband Wilhelm came to the vale a year ago and wrote that he was happy. Then he stopped writing. She has walked the Hill Road twice, and was turned gently back each time. She wants someone to find him.

**What is really going on.** Wilhelm is alive and well, keeping bees with Brannoch. He is entirely content. He does not remember Hettie's name, only that there is "someone I should write to." The Warden has not hurt him. It has simply *soothed* the thing that pulled him home. The player's job is to bring Hettie to him, and let them choose.

**Scene 1: the road.**

**HETTIE:** "Twenty-six years of marriage. He wrote every week. Then: *I am so happy. I am so happy. I am so happy.*"
**HETTIE:** "Three times, same words. Then nothing."
**HETTIE:** "I am not a fool. I know what a happy man writes. He writes about the *weather.*"
> ► **"What do you want?"** — **HETTIE:** "To see him. To look at him."
> ► **"Is he in danger?"** — **HETTIE:** "I think he's in a very nice trap."
> ► **"I'll find him."** — **HETTIE:** "Thank you. Bring honey. They like it."

**Scene 2: the town.** Ashira is lovely. Bridges over the clear river, window boxes, bread-smell, laughter. Everyone greets the player by name, though they have not been told it. Asked about Wilhelm, the townsfolk smile, say "oh, the lovely man with the bees," and offer tea.

**BAKER (kindly):** "Have you eaten? You look worn. Stay a night. Stay a week."
*The tea is perfect. The bed is warm. The player feels, for one dangerous second, that there is nothing left to do.*
> ► **(Accept the bread, keep searching.)** — The player eats, and moves on.
> ► **(Refuse politely.)** — The baker's smile does not change.
> ► **(Ask directly where Wilhelm lives.)** — A pause, a smile, a direction.

**Scene 3: the hives.** Wilhelm is sitting in a meadow beside twelve hives, humming. He is smiling. He is thin and tanned and clearly content.

**WILHELM:** "Hello! Are you here for honey? It's marvellous this year."
**WILHELM:** "Hettie? ...That's a nice name. Is she a friend of yours?"
**WILHELM:** "I think I should write to someone. I can't think who."
*Hettie steps out from behind the player. She does not speak. She holds out a folded letter, in his own hand, the first one he wrote her.*
> ► **(Let her read it aloud.)** — Wilhelm's smile wavers.
> ► **(Hold back and watch.)** — Silence; Hettie begins to cry.
> ► **(Tell Wilhelm who she is.)** — **WILHELM:** "Oh. Oh."

**Scene 4: the choice.** Wilhelm looks at the letter for a long time. His eyes fill. He says "I'm so sorry" in a voice that is not yet his own.

**WILHELM:** "I don't want to go. It's so *easy* here."
**WILHELM:** "But I think I would like to go with you. Just for tonight."

**Scene 2b: the other bees.** On the way to the hives the player meets Wilhelm's neighbour, a cheerful woman called Greta, who is delighted to be asked about him.

**GRETA:** "Oh, Wilhelm! A dear. He hums to the bees. He's never cross."
**GRETA:** "He sometimes stops in the middle of a sentence and stares at nothing, and then he smiles. Isn't that sweet?"
*The player realises that every word Greta has said is true, and that every word of it is a symptom.*
> ► **"Does he ever mention a wife?"** — **GRETA:** "A wife? Oh, I don't think so."
> ► **"Does he write letters?"** — **GRETA:** "He thinks he should. He never does."

**Outcomes and receipt.**
- Wilhelm walks with Hettie to the inn and spends the night in tears and conversation. Whether he leaves the vale is left open. If the player told him who Hettie was, the memory comes back faster and hurts more.
- The Warden is not met or opposed. This is one pair of hands pulling one man back from the water.
- **Receipt:** a jar of honey on Hettie's inn windowsill, and one of Wilhelm's letters, mailed that evening, that says nothing of the weather.

<!-- quest
id: qst_ash_husband_stopped_writing
title: The Husband Who Stopped Writing
rank: B
type: Investigation
giver: npc_hettie_ashdown
region: reg_ashira_vale
level: 90
act: 4
requires_rank: B
reward: 10400 | 610 | 45000
sets: ash_husband_done
summary: A woman from Aldmere is looking for her husband, who wrote that he was happy a year ago and then stopped writing.
objectives:
  talk npc_hettie_ashdown
  reach ashira_wilhelm_hives
  choice read_watch_or_tell
-->

---

## 2. The Baker's Dream

*B · Hidden · the bakery · giver Baker Maudine Crumb*

**The short version.** Maudine is the baker of Ashira, and two generations ago she was a famous adventurer. She cannot remember. For a month she has been dreaming of a battle, and she wants to know whether to let herself remember it.

**What is really going on.** The battle was real, and costly. Maudine's party lost someone, and the Warden has softened that grief, along with the rest of her legend. If she remembers, she will remember the loss. If she does not, she will stay happy, and a little less than herself. The player is not asked to decide. The player is asked to *stand with her* while she does.

**Scene 1: the ovens.**

**MAUDINE:** (shaping loaves, flour to the elbow) "I dream of fire. A wall of it. And a voice shouting my name. I can't tell if it's a warning or a goodbye."
**MAUDINE:** "Everybody says I was famous. I make a very good rye. I'd rather like to know what else I did."
**MAUDINE:** "Would you remember, if you were me?"
> ► **"What if it hurts?"** — **MAUDINE:** "It probably will. I've a feeling it already did."
> ► **"What do you remember?"** — **MAUDINE:** "The smell of the smoke. Isn't that silly?"
> ► **"Tell me the dream."** — **MAUDINE:** "Sit. I'll cut you a slice."

**Scene 2: the old party.** In the vale, other members of her party still live: a cheerful former thief, Cato, who grows roses; a bright-eyed healer, Anneke, who teaches weaving. Neither remembers a thing. Both ask the player to be kind to her.

**ANNEKE:** "We were all very happy, you know. Afterwards."
**ANNEKE:** "I've a feeling there was a before. I never wanted to look."
> ► **"Do you want to look?"** — **ANNEKE:** "...Not today."
> ► **"Do you remember who you lost?"** — **ANNEKE:** "I don't think we lost anyone."
> ► **"Tell Maudine you'll sit with her."** — **ANNEKE:** "Yes. That, I could do."

**Scene 3: the night.** Maudine, the player and her old comrades sit in the bakery after closing, warm and quiet. She tells the dream, piece by piece. With each piece, one of her friends stiffens. Cato, very suddenly, puts down his cup.

**PRYOR:** "...Tovah."
**PRYOR:** "There was a girl. Tovah. She held the wall."
*The room goes silent. Maudine's hands are still.*
> ► **(Say, "Tell me about Tovah.")** — Maudine begins to cry.
> ► **(Say nothing, and hold her hand.)** — A long, steady quiet.
> ► **(Say, "You don't have to remember tonight.")** — **MAUDINE:** "Thank you. I know."

**Scene 4: the bread.** At dawn Maudine bakes a small, plain loaf shaped like a shield. She sets it on the counter with a card: *"For Tovah."* She does not say anything else. The first customer buys it and puts it back.

**MAUDINE:** "I think that's enough for now."
**MAUDINE:** "I'm going to remember the rest *slowly.*"

**Scene 2b: the rye.** Before the night begins, Maudine presses a warm loaf into the player's arms and watches them eat the first slice.

**MAUDINE:** "Rye, caraway, a little honey. Nothing fancy."
**MAUDINE:** "My grandmother's recipe, I think. Or someone's grandmother."
**MAUDINE:** "Is it good? Tell me honestly. I only ever hear 'lovely.'"
*It is the best bread the player has ever tasted, and it tastes faintly of ash, of woodsmoke. Maudine watches the player's face closely, and her own face changes.*
> ► **"It tastes of smoke."** — **MAUDINE:** "It always does. I've never known why."
> ► **"It's perfect."** — **MAUDINE:** "That's what they all say."

**Outcomes and receipt.**
- Maudine remembers one name and one grief. The Warden's calm presses back, a little, and the fire in her dreams stays. If the player told her not to remember, the dreams fade within a week.
- **Not answered:** what the Warden took and keeps, or what the party's legend was. The quest only shows one baker choosing to hurt.
- **Receipt:** a shield-shaped loaf on the bakery counter each Solenday, with a card reading *"For Tovah."*

<!-- quest
id: qst_ash_bakers_dream
title: The Baker's Dream
rank: B
type: Hidden
giver: npc_maudine_crumb
region: reg_ashira_vale
level: 100
act: 4
requires_rank: B
reward: 11800 | 700 | 51000
sets: ash_baker_done
summary: The baker of Ashira was once a famous adventurer and cannot remember. For a month she has dreamed of a battle.
objectives:
  talk npc_maudine_crumb
  reach ashira_bakery_night
  choice tovah_hand_or_not_tonight
-->

---

## 3. Why There Are No Old People

*B · OddJob · the town of Ashira · giver Posy Applewhite*

**The short version.** Eight-year-old Posy has counted every resident of the vale and noticed that nobody is over sixty. She has asked her mother, her teacher and the bee-man. They changed the subject. She would like an answer from someone who doesn't.

**What is really going on.** *Nothing is explained.* No old person is found. The player can learn only what is true: that the old maps show a graveyard, that no one remembers one, that the vale has no word for mourning. The quest ends with a child holding a question she is brave enough to keep.

**Scene 1: the schoolyard.**

**POSY:** "I counted. Two hundred and nine people. The oldest is Mr. Haskell, and he is fifty-eight."
**POSY:** "Where do the old people *go?*"
**POSY:** "Mother says: *they're very happy.* But that isn't an answer. That's a *smile.*"
> ► **"What do you think happens?"** — **POSY:** "I think someone's hiding them. Or they leave."
> ► **"Who have you asked?"** — **POSY:** "Everyone. They all give me cake."
> ► **"I'll help you look."** — **POSY:** "Good. Bring a notebook."

**Scene 2: the questions.** For two days the player and Posy walk the town, asking. Each answer is gentler than the last.

**WEAVER:** "Old? Oh, we never worry about that. Time is kind here."
**BEEKEEPER:** "My own father? I... believe he lived up the hill. A long time ago."
**MOTHER (Posy's):** "Darling, please eat your supper."
*Each time, the subject changes. Each time, the speaker looks slightly relieved, as though someone had lifted a stone off their chest.*
> ► **"What does 'a long time ago' feel like?"** — A blank, pleasant look.
> ► **"Do you miss him?"** — The beekeeper pauses, smiles and gives honey.
> ► **"That's enough for today."** — Posy nods, tight-lipped.

**Scene 3: the map.** In the mill's attic the player finds an old hand-drawn map of the vale. On the hill behind the mill, in faded ink, a small square marked with a cross, and a word: *"Rest."*

**POSY:** "That's a graveyard."
**POSY:** "Nobody told me we had a graveyard."
**POSY:** "What's a graveyard *for?*"
> ► **"It's where we remember the dead."** — **POSY:** "Like a library of people."
> ► **"It's a place people go to say goodbye."** — **POSY:** "Why don't we have goodbyes?"
> ► **"I don't know."** — **POSY:** "That's honest. I like honest."

**Scene 4: the notebook.** Posy writes in her notebook, in large wobbling letters: *"No old people. No graveyard. Why?"* She underlines *why* three times.

**POSY:** "I'm going to keep asking."
**POSY:** "Even if it gets me cake."

**Scene 2b: the teacher.** The schoolteacher, a kind young man named Ewan, is the only adult who does not change the subject. He just goes quiet and sets down his chalk.

**EWAN:** "She asked me in the second week of term. I told her I'd think about it."
**EWAN:** "I have thought about it every day since. I don't have an answer."
**EWAN:** "Do you know, I can't remember my own grandparents' faces?"
*He looks at the board, where he has unconsciously drawn a small cross inside a square. He rubs it out, then draws it again.*
> ► **"Do you want to remember?"** — **EWAN:** "I think I'd like to want to."
> ► **"Posy will keep asking."** — **EWAN:** "Good. Someone should."

**Outcomes and receipt.**
- Posy has a question and a map. If the player said *"I don't know,"* she trusts them. If the player gave a comfortable answer, she nods politely and writes it down anyway.
- **Seed (unexplained):** where the old people went, why the graveyard vanished, why the vale has no word for mourning. The quest does not say whether the Warden is responsible.
- **Receipt:** a notebook page, copied and pinned by the school door: *"Why?"*

<!-- quest
id: qst_ash_no_old_people
title: Why There Are No Old People
rank: B
type: OddJob
giver: npc_posy_applewhite
region: reg_ashira_vale
level: 88
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: ash_old_people_done
summary: A child has counted everyone in the vale and found none over sixty. Everyone she asks gives her cake and changes the subject.
objectives:
  talk npc_posy_applewhite
  reach ashira_mill_attic_map
  choice remember_goodbye_or_dont_know
-->

---

## 4. The Hill That Hums

*B · Exploration · the Hill Behind the Mill · giver Miller Alwyn Haskell*

**The short version.** The meadow on the hill behind the mill hums, softly, all year. Alwyn has lived under it fifty-eight years and never climbed it. Posy's questions have made him wonder why not.

**What is really going on.** *Nothing is explained.* The hill is a meadow of wildflowers, bright and quiet. At its crest the hum is strongest, and the grass lies in a faint pattern of long, shallow mounds. The player may stand there. The quest ends on a question.

**Scene 1: the mill.**

**ORRIN:** "I've never been up. Fifty-eight years. It's a short walk. A pretty one."
**ORRIN:** "Every time I think of going, I think of something else. Something nice."
**ORRIN:** "Today I thought of it twice in a row and it frightened me."
> ► **"What's up there?"** — **ORRIN:** "A meadow. That's all anyone says."
> ► **"What does the hum sound like?"** — **ORRIN:** "Like a lullaby, played very slowly by someone very tired."
> ► **"Come with me."** — **ORRIN:** "...I'd like that. Hold my arm."

**Scene 2: the climb.** The path up the hill is smooth and shaded, with butterflies. Birds sing. About halfway, Alwyn's step falters. He looks down the slope at his own mill as though it were far away.

**ORRIN:** "Is there something I was going to do?"
**ORRIN:** "It's gone again."
> ► **"You were climbing."** — He nods, relieved, and goes on.
> ► **"Sit a moment."** — He sits and loses the thread.
> ► **"Hum something yourself."** — He does, hoarsely.

**Scene 3: the crest.** At the top, a broad meadow of long grass and small blue flowers. The hum is loud here, a deep low tone felt in the chest. The grass lies in rows, faint ridges, each a few paces long. Not natural. Not quite anything.

*There are no stones. There are no markers. The ground under the flowers is very, very soft.*
**ORRIN:** (barely a whisper) "...It's the right shape. Isn't it?"
**ORRIN:** "I don't know what shape. But it's *right.*"
> ► **(Kneel and put a hand on the earth.)** — It is warm, and the hum steadies.
> ► **(Lay a flower on the nearest ridge.)** — Alwyn follows.
> ► **(Say nothing and stand.)** — **ORRIN:** "...Thank you."

**Scene 4: the descent.** Alwyn walks down slowly, one hand on the player's arm. At the mill door he stops.

**ORRIN:** "I think I had a father."
**ORRIN:** "I think he's up there."
**ORRIN:** "I can't say any more than that. Not yet."

**Scene 2b: the mill-wheel.** While they wait for Alwyn to catch his breath, the player sits by the mill-wheel and watches the water turn it. It is a cheerful, steady sound.

**ALWYN:** "The wheel's never stopped. Not in my lifetime. Not in my father's, I think."
**ALWYN:** "You'd think I'd have asked about my father by now."
**ALWYN:** "I have a feeling I did. A long time ago. And somebody gave me a very nice cup of tea."
*The wheel turns. The water chuckles. Somewhere uphill, very faintly, a note hangs in the air and does not resolve.*
> ► **"What was he like?"** — **ALWYN:** "Tall. He whistled."
> ► **"Do you hear the hum now?"** — **ALWYN:** "Always. I thought it was the wheel."

**Outcomes and receipt.**
- Alwyn has climbed the hill. The hum quietens by a hair. If the player laid a flower, others follow; by next week the nearest ridge has a dozen, and nobody can say who placed them.
- **Seed (unexplained):** what lies under the meadow, why it hums, why the graveyard is gone. The quest does not say whether the dead are buried there.
- **Receipt:** a small ring of stones set on the crest by Alwyn, unlabelled; he climbs the hill every Solenday.

<!-- quest
id: qst_ash_hill_hums
title: The Hill That Hums
rank: B
type: Exploration
giver: npc_osgar_haskell
region: reg_ashira_vale
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: ash_hill_done
summary: A miller who has lived below a humming hill for fifty-eight years has never climbed it, and has just wondered why.
objectives:
  talk npc_osgar_haskell
  reach ashira_hill_behind_mill_crest
  choice kneel_flower_or_stand
-->

---

## 5. Wanting the Ache Back

*B · OddJob · the apiary · giver Brannoch Hive*

**The short version.** Brannoch took a spear to the knee in a war he barely recalls. It ached every damp morning for twenty years, until the day he reached Ashira. Now it doesn't, and he finds he misses it.

**What is really going on.** The ache was the last thing that tied him to the war: to his comrades, to his sergeant's stripes, to the men who died. Without it he is calmer, but he has lost the only reliable memory he had. The player's job is to help him find another way to carry it.

**Scene 1: the hives.**

**BRANNOCH:** "It hurt every morning. Every. Damn. Morning. I hated it."
**BRANNOCH:** "Now it's gone, and I can't remember why I hated it."
**BRANNOCH:** "That's a daft thing to say. Isn't it?"
> ► **"Is it a daft thing?"** — **BRANNOCH:** "I thought so. Now I'm not so sure."
> ► **"What do you miss?"** — **BRANNOCH:** "The *reason.*"
> ► **"How can I help?"** — **BRANNOCH:** "Hit me with something. Gently."

**Scene 2: the list.** The player does not hit him. Instead they sit by the hives and ask him to name the men he served with. He starts easily. Then more slowly.

**BRANNOCH:** "Harkin. Tuck. The twins, Aled and ... Alden. And... and..."
**BRANNOCH:** "There was a lad. Redhead. He made terrible tea."
*He is not smiling now. His hand has gone to his knee.*
> ► **"Keep going."** — He does, hoarse.
> ► **"Write them down."** — **BRANNOCH:** "I'll lose it tomorrow."
> ► **"What was the tea like?"** — He laughs, and the laugh cracks.

**Scene 3: the knee.** Brannoch stands up. He winces, a small flicker, a real one, for the first time in weeks. He sits down hard.

**BRANNOCH:** "There it is."
**BRANNOCH:** "There. It's *there.*"
**BRANNOCH:** (laughing, tears on his face) "Gods, I'd missed you."

**Scene 4: the keeping.** The player helps Brannoch carve each name onto a hive-frame, one per hive. He sets each in the sun. When the last is done, he stands in the apiary with his hand on his knee, and does not move for a long time.

> ► **(Stay with him.)** — He nods, once.
> ► **(Leave him be.)** — He does not notice you go.
> ► **(Offer to read the names aloud.)** — He declines, then asks you to.

**Scene 2b: the redhead.** Brannoch's memory of the lad with the terrible tea turns out to be the key. He remembers the lad's laugh, a high, unlovely honk, and then, suddenly, his name.

**BRANNOCH:** "Pip. No. Pippin. Pippin Hale. Seventeen. He put salt in the sugar jar and called it an experiment."
**BRANNOCH:** "He died at the ford. I carried him back myself."
**BRANNOCH:** "I haven't thought of him in... I don't know. A year? Ten?"
*He puts down the frame he is holding, very carefully, so as not to drop it.*
> ► **"Say it again."** — **BRANNOCH:** "Pippin Hale. Pippin Hale."
> ► **"You carried him home."** — **BRANNOCH:** "I did. I did."

**Scene 4b: the honey.** A week later the player passes Brannoch's apiary and finds him sitting among the hives with a jar, bitter-faced and grinning.

**BRANNOCH:** "Try it. It's gone dark. The bees know."
**BRANNOCH:** "I can't say it's *good.* But it tastes of something."
*The honey is rich, a little sharp, with a smoky aftertaste. The player thinks of the carved frames, and of twelve men who are not forgotten.*
**BRANNOCH:** "Everybody here says it's too strong. I say they can have the sweet stuff."

**Outcomes and receipt.**
- Brannoch has his ache, and his dead. The calm presses on him, but he has carved names it cannot reach. If the player did not stay, he drifts a little by evening; if the player did, he holds.
- **Receipt:** twelve hive-frames with a name each; the honey from that apiary is darker, and a little bitter, and sells out first.

<!-- quest
id: qst_ash_ache_back
title: Wanting the Ache Back
rank: B
type: OddJob
giver: npc_brannoch_hive
region: reg_ashira_vale
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: ash_ache_done
summary: A retired soldier's old war wound stopped hurting the day he reached the vale, and he has begun to miss it.
objectives:
  talk npc_brannoch_hive
  reach ashira_apiary_hives
  choice stay_leave_or_read
-->

---

## 6. The Milestones That Stop Counting

*B · Exploration · the Hill Road · giver Surveyor Ostrel Stonepace*

**The short version.** Ostrel was sent to re-mark the Hill Road. The milestones count up from the coast: eleven, ten, nine, eight, seven... and then stop. The next stone is blank. Two apprentices went to measure the gap and did not come back.

**What is really going on.** *Nothing is explained.* Past the last numbered stone the road continues for a mile, but every attempt to measure it comes out differently. The surveyor's chain is longer on the way in than on the way out. The quest ends with the player walking the mile and arriving where they began, calm and unharmed.

**Scene 1: the stone.**

**OSTREL:** "Stone seven. Last of the numbered ones. After it, the road goes on, and no one has cut a number since."
**OSTREL:** "My apprentices said: *it's only a mile.* They took the chain. I stayed to watch the horses."
**OSTREL:** "Both wrote me, within the week. *'It's wonderful here. Don't worry.'*"
> ► **"Do you want them back?"** — **OSTREL:** "I want to know what I measured wrong."
> ► **"What do you need?"** — **OSTREL:** "Someone who can count backwards."
> ► **"I'll walk it."** — **OSTREL:** "Use the chain. Count out loud."

**Scene 2: the walk.** A fine, mild afternoon. The road is straight and well kept. The player unrolls the chain and counts aloud, step by step. The count is easy, then slow, then oddly pleasant.

**PLAYER (counting):** "...four hundred and ninety... four hundred and ninety... four..."
*The player has lost count, and does not mind.*
> ► **(Stop and start again.)** — The count comes back, shaky.
> ► **(Tie a rag to the chain at each hundred.)** — A reliable marker.
> ► **(Keep walking and let it go.)** — A pleasant, empty stretch.

**Scene 3: the end of the road.** The road bends once. A fence. A sign: *WELCOME TO ASHIRA.* The player turns to look back along the road. It has been a mile. By the rags, it has been two.

*Beside the road, a milestone, freshly cut, carries a number: nothing. A blank face of stone. A fresh chisel mark begins a curve, and stops.*
**OSTREL (arriving, out of breath):** "...Same. You arrived at the sign, I take it."
**OSTREL:** "So did I. So did they."

**Scene 4: the mark.** Ostrel looks at the blank milestone for a long time. Then he takes out his chisel, and cuts a single number: *6.*

**OSTREL:** "It's a lie. I know it's a lie. But it's the *next* lie."
**OSTREL:** "Perhaps someone will notice the count is still going."

**Scene 2b: the apprentices' camp.** Ostrel has kept the apprentices' camp exactly as they left it: two bedrolls, a kettle, a half-written letter. He shows the player without a word.

**OSTREL:** "Teague wrote the other half before he went. I've never posted it. I wouldn't know where."
*The letter, in a young man's hand, reads: "Dear Mother, the road is very straight and the weather is very fine and I have never in my life felt so little worried about anything. I think there is a thing I have forgotten to be afraid of."*
**OSTREL:** "That last line. He underlined it. I think he knew."
> ► **"Let me take it."** — **OSTREL:** "Please. I can't carry it any further."
> ► **"Have you answered?"** — **OSTREL:** "Nobody answers the road."

**Outcomes and receipt.**
- The player completes the walk. If the player stopped to restart the count, the apprentices' trail is found: two chalked arrows pointing toward the town. If not, nothing.
- **Seed (unexplained):** the changing length, the blank stone, and why the apprentices stayed. The quest does not say whether the Warden bends the road, only that nothing else explains it.
- **Receipt:** a newly cut milestone, number six, at the end of the road; Ostrel carries a rag-tied chain and counts aloud.

<!-- quest
id: qst_ash_milestones_stop
title: The Milestones That Stop Counting
rank: B
type: Exploration
giver: npc_ostrel_stonepace
region: reg_ashira_vale
level: 98
act: 4
requires_rank: B
reward: 11600 | 665 | 49000
sets: ash_milestones_done
summary: A surveyor re-marking the Hill Road finds the milestones stop counting halfway. His apprentices went to measure the gap.
objectives:
  talk npc_ostrel_stonepace
  reach ashira_hill_road_blank_milestone
  choice restart_rags_or_walk
-->

---

## 7. Letters That Say the Same Thing

*B · Delivery · the post office · giver Postmistress Lisbet Callow*

**The short version.** Lisbet reads every letter that leaves Ashira, by habit. Every traveller who has stayed more than a week writes the same three phrases: *I am so happy. Do not worry. I will write again.* She has seventeen such letters, and no replies. She wants them delivered, in person.

**What is really going on.** The letters are sincere. The writers mean them. They are also hollow, pressed out of people who have forgotten what they were afraid of. The player's job is to deliver three of the letters, in person, and tell the families what Ashira is. Each delivery is a different kind of grief.

**Scene 1: the post office.**

**LISBET:** "Seventeen. I keep them in a drawer. I've read each one twice."
**LISBET:** "The handwriting is perfect. The feeling is *flawless.* I've never read a lie that truthful."
**LISBET:** "I cannot post them. I do not think I may keep them. Will you carry them?"
> ► **"Where do they go?"** — **LISBET:** "Aldmere. Greymoor. One to the coast."
> ► **"Why not post them?"** — **LISBET:** "Letters get *answered.* That is the trouble."
> ► **"I'll carry three."** — **LISBET:** "Thank you. Choose carefully."

**Scene 2: the choosing.** The player reads through the seventeen letters and picks three. A fisherman's to his sister. A student's to her mother. A widow's to her only son.

*Each letter says the same words in a different hand. Under the words, a faint trace of something the writer once felt, pressed out like a flower.*
> ► **"The fisherman's."** — To a dockside house in Aldmere.
> ► **"The student's."** — To a mother in a mill town.
> ► **"The widow's."** — To a son who has stopped looking.

**Scene 3: the doors.** The player delivers each letter, and each family receives it differently. The sister laughs, then goes silent. The mother sits down on the stairs. The son, a soldier, reads the letter twice and says only: *"She'd have hated that word. 'Happy.' She always said it was for people who weren't paying attention."*

**SON:** "I'll go. I will. Give me the week."
**MOTHER:** "Tell her I'll bring the good bread."
**SISTER:** "He never wrote that way. Never. Take me there."
> ► **(Offer to guide them.)** — The player writes the road on a map.
> ► **(Warn them.)** — **SISTER:** "Of what?"
> ► **(Say only, "They're well.")** — A small lie, a small kindness.

**Scene 4: the reply.** Three weeks later, three letters arrive at Lisbet's door, each in a different hand, each with one line: *"I'm coming."* She holds them for a long time before she posts the answers.

**LISBET:** "Letters get answered."
**LISBET:** "I used to be afraid of that."

**Scene 2b: the sorting.** Lisbet's drawer of seventeen letters is as neat as a filing cabinet, and she has annotated every one, in pencil, in a tiny scrupulous hand.

**LISBET:** "Date arrived. Date of first letter. Date of last. Number of times the word *happy.*"
**LISBET:** "The average is nine. The highest is fourteen. I think it's a sign of effort."
**LISBET:** "I wonder if the ones who write more are the ones who were most afraid."
*She taps the stack, once, squaring the edges.*
> ► **"That's a good theory."** — **LISBET:** "It is a terrible theory. It is the only one I have."
> ► **"Which one was fourteen?"** — **LISBET:** "The student's. She was the cleverest."

**Outcomes and receipt.**
- Three families set out for Ashira. Whether they arrive intact is left open. If the player warned them, they bring a friend each, which may help.
- **Receipt:** a drawer of fourteen unsent letters, kept; Lisbet starts a log of the ones she does not post.

<!-- quest
id: qst_ash_same_letters
title: Letters That Say the Same Thing
rank: B
type: Delivery
giver: npc_lisbet_callow
region: reg_ashira_vale
level: 102
act: 4
requires_rank: B
reward: 12000 | 690 | 52000
sets: ash_letters_done
summary: Every long-stay traveller writes the same three phrases. The postmistress has seventeen such letters and no replies.
objectives:
  talk npc_lisbet_callow
  reach ashira_three_families_doors
  choice guide_warn_or_lie
-->

---

## 8. The Investigator Who Was Happy

*B · Investigation · the town of Ashira · giver Investigator Dessa Marchbank*

**The short version.** The Guild sent Dessa to find out why travellers vanish on the road. She wrote back that she had never been happier. The Guild now sends the player, with a message from Dessa to Dessa.

**What is really going on.** Dessa is alive and well, and happier than she has ever been. She is also working, very slowly, on her investigation. She doesn't remember that. Before she arrived, she left herself a locked box and a coded note, in case she should forget. The player's job is to open the box with her.

**Scene 1: the guild hall.**

**RECEPTIONIST:** "The note is from Dessa. It came with a message for you."
*The note reads: "If I write that I'm happy, I'm in trouble. Don't believe me. Ask me about the box."*
**RECEPTIONIST:** "It's the last letter we have."
> ► **"What box?"** — **RECEPTIONIST:** "She didn't say."
> ► **"I'll find her."** — **RECEPTIONIST:** "Be careful. She was our best."
> ► **"Is she a prisoner?"** — **RECEPTIONIST:** "No. She was *very* clear that she is free."

**Scene 2: the garden.** Dessa is on a bench in a sunny square, feeding sparrows. She looks well-rested, smiling and a little young.

**DESSA:** "Oh! A visitor! You look tired. Sit. Have a plum."
**DESSA:** "Investigator? Yes, I was. I think. It was a long time ago. Last month, was it?"
**DESSA:** "Do I have a box? ...I do, don't I? I keep it under my bed."
> ► **"Can I see it?"** — **DESSA:** "Of course! I'm so glad you asked."
> ► **"What's in it?"** — **DESSA:** "I haven't looked. It didn't seem urgent."
> ► **"Do you want to open it?"** — **DESSA:** "Do you know, I'm not sure I do."

**Scene 3: the box.** In a small, bright room, under the bed, a battered tin box with a three-digit lock. Dessa turns it in her hands, humming. She tries three numbers and stops, smiling.

**DESSA:** "I can't remember the combination. Isn't that silly?"
**DESSA:** "I think it was my mother's birthday."
> ► **"Try your mother's birthday."** — Click.
> ► **"Try today's date."** — Nothing.
> ► **"Ask her why she locked it."** — **DESSA:** "...To keep a promise."

*The box opens. Inside: a Guild badge, a notebook full of tiny handwriting, and a card in her own hand: "You are not unhappy. You have simply stopped looking. Please start again."*

**Scene 4: the reading.** Dessa reads the card aloud. Her smile falters, and for one terrible moment her eyes are entirely empty. Then something stirs behind them.

**DESSA:** "...Oh."
**DESSA:** "Oh, I was *so* good at this."
**DESSA:** "I'm going to be so *sad.*"

**Scene 2b: the guild's last report.** On the way out of the Guild hall the player is handed Dessa's last sealed report, which she wrote the night before she walked into the vale.

*"The road to Ashira is more pleasant than any road I have ever travelled. I have noted this. I have also noted that I do not wish to leave. I suspect I will write something absurd by the end of the week. If I do, send someone who cannot be pleased easily. Send someone stubborn."*
**RECEPTIONIST:** "That's you, I suppose."
**RECEPTIONIST:** "She thought you'd be stubborn."
> ► **"I've been called worse."** — **RECEPTIONIST:** "She'd laugh."
> ► **"Did she say anything else?"** — **RECEPTIONIST:** "Only: *don't let me stay for the plums.*"

**Outcomes and receipt.**
- Dessa resumes her investigation, slowly. She remembers the Guild, and a few facts about the road. Whether she leaves the vale is not decided.
- If the player tried the wrong numbers, Dessa grows anxious, and the memory takes longer.
- **Receipt:** a new notebook in Dessa's coat pocket, its first page: *"Day 1. I am not happy. I am awake."*

<!-- quest
id: qst_ash_investigator_happy
title: The Investigator Who Was Happy
rank: B
type: Investigation
giver: npc_dessa_marchbank
region: reg_ashira_vale
level: 106
act: 4
requires_rank: B
reward: 12800 | 740 | 55000
sets: ash_investigator_done
summary: The Guild's own investigator wrote back that she had never been happier. She left herself a locked box in case she should forget.
objectives:
  talk npc_dessa_marchbank
  reach ashira_dessa_room_box
  choice birthday_date_or_ask
-->

---

## 9. The Man Who Would Not Be Comforted

*B · Escort · the Open Door inn and the Hill Road · giver Innkeeper Hob Brackley*

**The short version.** Hale arrived three days ago with his daughter's death still on him like a coat. Ashira has fed him, housed him, sung to him, and cannot reach him. Hob thinks he should leave, before the vale does.

**What is really going on.** Hale's grief is so raw that the vale's comfort slides off it, and the townsfolk are growing anxious and gently insistent. They love him and they want to help. They do not realise that "help" means taking his grief away. The player escorts Hale out, and has to decide how forcefully.

**Scene 1: the inn.**

**HOB:** "I love every guest. I've never not loved a guest."
**HOB:** "But he cries all night, and in the morning he is *still sad,* and I haven't the least idea what to do."
**HOB:** "Everyone's trying. Bread. Songs. A warm bath. It's *not working.*"
> ► **"Is that bad?"** — **HOB:** "I'm... not sure it is. And I'm not sure I should think that."
> ► **"What do you want me to do?"** — **HOB:** "Take him out of the vale. Quickly."
> ► **"Let me meet him."** — **HOB:** "Third room. He doesn't talk."

**Scene 2: the guest.** Hale is sitting on the edge of the bed, hands open in his lap. His eyes are red. He looks up at the player and says nothing.

**HALE:** "They keep trying to make me feel better."
**HALE:** "She was seven. I don't *want* to feel better."
**HALE:** "Can you walk me out? Please. I'd like to be sad somewhere that lets me."
> ► **"Yes."** — **HALE:** "Thank you."
> ► **"Tell me about her."** — **HALE:** "...She liked turnips. Odd child."
> ► **"You can stay as long as you like."** — **HALE:** "That's what I'm afraid of."

**Scene 3: the road.** The walk out is long, golden and kind. Townsfolk wave. A girl presses a plum into Hale's hand. A woman runs after them with a loaf. Every smile is tender, and a little too bright. Each time, Hale slows, and each time, the player has to decide whether to let someone say *"Rest."*

*Halfway along, an old man steps in front of them, smiling, with open arms.*
**OLD MAN:** "You poor dear. Come home. Let us look after you."
> ► **(Step between them, firmly.)** — The old man blinks, bewildered.
> ► **(Let Hale answer.)** — **HALE:** "No. Thank you."
> ► **(Offer the old man a kind refusal.)** — **OLD MAN:** "Of course."

**Scene 4: the stone.** At the blank milestone, the road simply continues, a mile, then a fence, then a coastal road. Hale stops and looks back.

**HALE:** "It's very pretty."
**HALE:** "I'd have stayed. I think I'd have been fine. And I'd have forgotten her."
**HALE:** "I'd rather be sad."

**Scene 2b: the plum girl.** The girl who presses a plum into Hale's hand is perhaps nine, and has no idea she is part of anything. She runs alongside them for a hundred paces, talking.

**GIRL:** "Are you sad? You look sad. It's all right. We're very good at making people happy."
**GIRL:** "I was sad once. I think. I don't remember. Isn't that nice?"
*Hale looks at the child for a long moment. His face does something complicated.*
**HALE:** "It's... very kind. But I would like to keep it."
**GIRL:** "Keep what?"
> ► **"Say goodbye, gently."** — She waves, bright and puzzled.
> ► **"Don't answer."** — She runs back, humming.

**Outcomes and receipt.**
- Hale leaves the vale with his grief intact. If the player let him answer the old man himself, he walks away stronger. If the player stepped in, he thanks them but is a little shaken.
- **Receipt:** a plum, half-eaten, on the roadside; Hob, from that day, offers a seat to any guest who says "I'd like to be sad."

<!-- quest
id: qst_ash_not_comforted
title: The Man Who Would Not Be Comforted
rank: B
type: Escort
giver: npc_hob_brackley
region: reg_ashira_vale
level: 92
act: 4
requires_rank: B
reward: 10600 | 620 | 46000
sets: ash_comfort_done
summary: A grieving traveller's sorrow slides off a vale built to comfort. The innkeeper thinks he should leave before the vale decides to help.
objectives:
  talk npc_hob_brackley
  escort npc_hale_dunmarrow
  reach ashira_hill_road_exit
  choice step_answer_or_refuse
-->

---

## 10. Honey for the Warden

*B · Hidden · the Warden's Garden · giver Gardener Lenna Honeywell*

**The short version.** Lenna tends the Warden's Garden, a walled square of flowers always in bloom, where the town leaves honey for its protector. She has noticed that the honey is always gone by morning, and has never once seen who takes it. She asks the player to sit with her.

**What is really going on.** *Nothing is explained.* The Warden is not seen. The player sits in the garden through the night, and is offered a gift: every worry set down. The offer is gentle, and it is the most dangerous moment in the vale. The quest ends with the player's choice, and a question.

**Scene 1: the gate.**

**LENNA:** "I've tended this garden since... a while. I can't recall. It's always been in bloom."
**LENNA:** "Every night the bowls are full. Every morning they're empty."
**LENNA:** "I'd like to know who I'm feeding. And I find I'm *afraid* to want to."
> ► **"Who do you think it is?"** — **LENNA:** "The one who keeps us safe."
> ► **"Safe from what?"** — **LENNA:** "...That's a good question."
> ► **"I'll sit up with you."** — **LENNA:** "Thank you. Bring a blanket."

**Scene 2: the night.** The garden at dusk is the most beautiful place the player has ever seen: lavender, jasmine, roses, beehives humming. The air is warm. A bowl of honey sits at the centre on a flat stone. Lenna lays down a quilt. They wait.

*Hours pass. The player feels the day's weight slip off, one piece at a time: an old grievance, a lingering ache, a small shame. Each one drifts away like a seed.*
> ► **(Notice it, and hold on.)** — The weight returns, heavier.
> ► **(Let a little go.)** — The garden brightens.
> ► **(Speak aloud, "I don't want that.")** — The warmth pauses.

**Scene 3: the offer.** Past midnight, there is no sound, no sight. Only a presence, kind, patient, enormous, and a feeling that every sorrow the player has ever carried might be lifted in a single breath.

**PRESENCE (not a voice; a knowing):** *You are tired. You may rest. Nothing here will hurt you.*
**LENNA (barely awake):** "...Isn't it lovely?"
> ► **"It is. But no."** — The warmth lingers, then recedes, politely.
> ► **"What do you take?"** — The garden is silent; the bowl is full.
> ► **"Thank you. I'll keep it."** — **LENNA:** "Keep what?"

**Scene 4: the dawn.** By morning the honey is gone. Lenna wakes, rubs her eyes and looks at the empty bowl with an expression of faint, pleasant confusion.

**LENNA:** "Did I fall asleep? I always do."
**LENNA:** "I had the loveliest dream. I'm sure it was important."

**Scene 2b: the bees.** Around three in the morning the player notices that the hives in the Garden have gone quiet. Not stopped; *hushed,* as though something large had walked past.

**LENNA (drowsy):** "They do that. Every night. I've never minded."
**LENNA:** "I have a feeling they're listening for something."
*The player looks at the bowl of honey. It is full, and clear, and perfectly still. The moon sits in it like a coin.*
**LENNA:** "Do you ever get the feeling you've been kindly forgotten?"
> ► **"Every day."** — **LENNA:** "How lovely to hear it said."
> ► **"What do you mean?"** — **LENNA:** "Oh, nothing. It's the hour."

**Outcomes and receipt.**
- The Warden is not seen, spoken to or opposed. The player leaves with every worry intact, which is the point. If the player let some go, they feel lighter by a day, and a memory is faint.
- **Seed (unexplained):** the Warden's nature, what it does with what it takes, whether it hears refusal as anything at all.
- **Receipt:** a pressed jasmine in the player's Journal; the bowl is full again the next evening. Lenna, who forgot the night, brings the player tea.

<!-- quest
id: qst_ash_honey_warden
title: Honey for the Warden
rank: B
type: Hidden
giver: npc_lenna_honeywell
region: reg_ashira_vale
level: 110
act: 4
requires_rank: B
reward: 12600 | 730 | 54000
sets: ash_honey_done
summary: A gardener leaves honey for the Warden every night and has never seen who takes it. She asks the player to sit up with her.
objectives:
  talk npc_lenna_honeywell
  reach ashira_wardens_garden_night
  choice hold_release_or_refuse
-->
