# 11e-48 — Aurumdeep, the Drowned Gold Kingdom: Ten Side Quests (draft)

> *"Pray to Vex before you dive. Leave a coin for the dead. And whatever you see tonight, do not clap."*
> — Gazetteer, Aurumdeep

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[second_set_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 1, 2, 3 and 8 plant unexplained seeds.

**Region:** `reg_aurumdeep` (the explorers' camp, the Long Stair, the flooded avenues, the dry halls, the Golden Theatre at a distance). **Rank band:** A only. **Tone:** greedy, brave, superstitious, grave-haunted; gold that is not always gold; the dead being politely, confusedly kind.

**Placement notes.**
- **The Mad Magician of Aurumdeep, Sinker of Kingdoms,** is the region's Tyrant. He is still performing in the Golden Theatre. **No quest here defeats him, ends his show or says what he promised the king.** The region starts besieged by the walking dead; no quest here ends that siege.
- Customs the quests rely on: prayer to Vex before every dive; a coin on the first step of the water for the dead; **nobody in the camp ever applauds, for anything;** the survivors' descendants keep a silent vigil with an empty seat at every table; claims are sold by the explorers' council and disputed "in the council or in the water."
- Rule for the player on every quest here: **do not clap.** Several quests make use of it; none punishes the player for not clapping.
- Nothing in this file is hostile to the dead who still walk the dry halls. They are polite and confused; the quests treat them as people.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Gilded Partner | A | Investigation | Diver Pell Ashgrove | A man in gold, a clock running |
| 2 | The Prompt-Book | A | Exploration | Tilda Vantoor | A missing page, kept missing |
| 3 | The King Who Waits | A | Investigation | Diver Oskar Tidewell | A throne seen through water |
| 4 | An Empty Seat at Every Table | A | OddJob | Cook Dagobert Kettle | A vigil, kept carefully |
| 5 | The Coin on the First Step | A | Hidden | Tamsin Quill | A child and a thief |
| 6 | Fool's Gold Season | A | Investigation | Assayer Garrick Lathe | Gold that goes to paint |
| 7 | Settled in the Water | A | Faction | Arbiter Marit Deepclaim | A claim, a dive, a rule |
| 8 | The Last Dance on the Card | A | Escort | Lady Merewen Verrane | A dead lady's one request |
| 9 | The Census of the Blind Fish | A | Exploration | Scholar Lucan Marsh | Counting the quiet things |
| 10 | The Hundredth Step | A | Defense | Porter-Captain Hesper Gladewick | A stair that must hold |

## Cast

<!-- npc
id: npc_pell_ashgrove
name: Diver Pell Ashgrove
tier: major
race: Human
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Diver whose partner was turned to gold
backstory: A lean, sleepless diver of thirty-four who has dived twelve seasons beside Dunmore Reck and who found him smiling in a theatre seat, solid gold from collar to boots, three days ago.
-->
<!-- npc
id: npc_tilda_vantoor
name: Tilda Vantoor
tier: major
race: Human
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Survivor's descendant and keeper of the family records
backstory: A precise, quiet woman of fifty whose grandmother was outside the kingdom on the night it sank and who has spent her life wanting one fact: what the Magician promised the king.
-->
<!-- npc
id: npc_oskar_tidewell
name: Diver Oskar Tidewell
tier: townsfolk
race: Human
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Deep diver who saw a man on the throne
backstory: A broad, shaken diver who has gone deeper than anyone in the camp and who swears he saw the king sitting in the flooded throne room, upright, waiting.
-->
<!-- npc
id: npc_dagobert_kettle
name: Cook Dagobert Kettle
tier: townsfolk
race: Dwarf
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Camp cook who hosts the vigil table
backstory: A stout, soft-spoken cook who feeds a hundred explorers a day and who sets one extra chair at his long table every year on the anniversary of the sinking, for the families who never ask him to.
-->
<!-- npc
id: npc_tamsin_quill
name: Tamsin Quill
tier: townsfolk
race: Human
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Child who tends the coin step
backstory: A grave nine-year-old who sweeps the first step of the water each dawn and keeps a tally of the coins left there for the dead, and who has noticed the tally is wrong.
-->
<!-- npc
id: npc_garrick_lathe
name: Assayer Garrick Lathe
tier: major
race: Gnome
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Council assayer of recovered gold
backstory: A fussy, honest gnome who tests every ingot that comes up the Long Stair and who has been handed three bars this month that turned to paint by morning.
-->
<!-- npc
id: npc_marit_deepclaim
name: Arbiter Marit Deepclaim
tier: major
race: Human
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Council arbiter of diving claims
backstory: A broad-shouldered former diver who now settles claim disputes for the explorers' council and who has never lost a ruling she made in the water.
-->
<!-- npc
id: npc_merewen_verrane
name: Lady Merewen Verrane
tier: major
race: Ghost
region: reg_aurumdeep
settlement: The dry halls
role: One of the polite dead, holder of an unfinished dance
backstory: A courtly, confused lady in a gown of pale gold who has waited in the Hall of Mirrors for a hundred and some years for her partner to return and finish the last dance on her card.
-->
<!-- npc
id: npc_lucan_marsh
name: Scholar Lucan Marsh
tier: major
race: Human
region: reg_aurumdeep
settlement: Aurumdeep explorers' camp
role: Naturalist of the flooded streets
backstory: A mild, damp-sleeved scholar who studies the blind white fish and cave eels of the lamp-lit streets and who has noticed that their numbers fall whenever a lamp dies.
-->
<!-- npc
id: npc_hesper_gladewick
name: Porter-Captain Hesper Gladewick
tier: major
race: Human
region: reg_aurumdeep
settlement: The Long Stair
role: Captain of the Long Stair porters
backstory: A square, patient captain who keeps two hundred porters and a thousand steps alive and who knows every shrine on the stair by the chips in its stone.
-->

---

## 1. The Gilded Partner

*A · Investigation · the camp and the theatre doors · giver Diver Pell Ashgrove*

**The short version.** Pell's partner Dunmore sat down to watch the Magician's show and was found the next morning turned to gold in his seat, smiling. The fences have already priced him by the pound. Pell wants him carried out before they carve him up.

**What is really going on.** Nobody knows whether the gold can be undone, and this quest does not decide it. Pell does not actually need Dunmore cured to start grieving; she needs him *not sold.* The player must get a solid gold man up the Long Stair past the fences, the council and a very polite dead usher.

**Scene 1: the tent.**

**PELL:** "Twelve seasons. He always went first through a door. Said it was manners. It was nerves."
**PELL:** "Now there is a man in the third row with Dunmore's face and Dunmore's boots and no Dunmore."
**PELL:** "The fences are bidding. By the *pound.*"
> ► **"Can he be changed back?"** — **PELL:** "Nobody's asked the right person. I won't."
> ► **"What do you need?"** — **PELL:** "Four porters, a sled and someone who can't be bought."
> ► **"I'll bring him out."** — **PELL:** "Don't clap if he looks at you."

**Scene 2: the third row.** The dry gallery of the Golden Theatre, seen from the back. The seats are full: ladies in silk, officers in sashes, all gold-still and smiling. The painted doves flutter across the stage and dissolve against the lamps. Dunmore is in the third row, one hand on the armrest, his mouth open mid-laugh.

**USHER (a thin, gentle dead man in a livery coat):** "Programmes, sir? Madam? The second half begins shortly."
**USHER:** "Your friend enjoyed the first half very much."
> ► **"What happens in the second half?"** — **USHER:** "The trick. We have all been waiting for the trick."
> ► **"May I take him?"** — **USHER:** "Seats are not transferable. ...But he is not using his coat."
> ► **"Is he in pain?"** — **USHER:** "He laughed the whole way."

*Under the player's hand the gold is faintly, impossibly warm.*

**Scene 3: the sled.** The long climb with the sled, a block-and-tackle and four porters. At the third landing three fences wait with a scale and a council chit that is almost, but not quite, valid.

**FENCE:** "Weighs a hundred and ninety. At the market rate, that's a house."
**FENCE:** "He's not a *person*, friend. Look at him."
> ► **(Show the council's burial law.)** — The chit is torn up. Slowly.
> ► **(Pay them off.)** — They leave. The porters stop speaking to you.
> ► **(Stand in front of the sled and wait.)** — A long silence, then the fences go.

**Scene 4: the tent.** Pell sits beside him for a while. She does not take her hand off his.

**PELL:** "He's warm."
**PELL:** "I'm not going to ask what that means. I'm going to sit here."
*Outside, the camp is silent. No one claps for anything.*

**Outcomes and receipt.**
- Dunmore is carried out and sheltered in Pell's tent. Whether he is alive, cursed or something else is **left open.** If the player paid off the fences, the porters' trust drops for a season.
- **Receipt:** a gold man in a tent with a blanket over his knees; Pell plays cards with him every night.
- **Canon-safe:** this is a pure seed. Nothing explains the gold or the Magician's trick.

<!-- quest
id: qst_aur_gilded_partner
title: The Gilded Partner
rank: A
type: Investigation
giver: npc_pell_ashgrove
region: reg_aurumdeep
level: 126
act: 4
requires_rank: A
reward: 30000 | 1500 | 135000
sets: aur_gilded_partner_done
summary: A diver's partner was turned to gold in a theatre seat. The fences have priced him by the pound.
objectives:
  talk npc_pell_ashgrove
  reach aurumdeep_golden_theatre_gallery
  choice law_pay_or_stand
-->

---

## 2. The Prompt-Book

*A · Exploration · the theatre's prompt corner · giver Tilda Vantoor*

**The short version.** Tilda's grandmother was outside the kingdom on the night it sank, and spoke of nothing else. Tilda believes the theatre's prompt-book records what the Magician promised the king. She wants it read, not taken.

**What is really going on.** The prompt-book exists, in a flooded corner behind the stage, and it is intact. The page for the promise is stuck to the page behind it, and unsticking it will tear the one line that matters. The player must decide whether to know, and Tilda must decide with them.

**Scene 1: the records room.**

**ILSABET:** "My grandmother used to say, 'He told the king something, and the king said yes.' That is all she ever said."
**ILSABET:** "Three generations of my family. We petition every crown on the surface to call this place a tomb. None has agreed."
**ILSABET:** "I do not want the gold. I want the sentence."
> ► **"Why the prompt-book?"** — **ILSABET:** "Stage managers write down everything. Even promises."
> ► **"Why not go yourself?"** — **ILSABET:** "I cannot swim. And someone should watch the rope."
> ► **"I'll find it."** — **ILSABET:** "Bring it back wet. Do not dry it by fire."

**Scene 2: the corner.** A diving-bell descent into a drowned prompt corner behind the great stage. Cue-lights still glow under the water. Painted silk dragons coil along the rafters and fall to bits at a touch. In a lead-lined box, a book.

**JOURNAL (auto):** *The prompt-book is bound in blue buckram. Marginal notes in three hands: "Doves on the left." "Do NOT let him add the ending." "Applause here. Wait for applause."*

**Scene 3: the page.** On the surface, in a wet cellar, the player and Tilda find the page. It is glued to its neighbour by a century of damp, and the single line on it shows through as a shadow.

**ILSABET:** "I can see it. I can see the shape of the words."
**ILSABET:** "If I lift it, it tears. If I leave it, it keeps."
> ► **"Lift it."** — **ILSABET:** "Then I will know, and I will have ruined it."
> ► **"Copy the margins instead."** — **ILSABET:** "...The margins. The ones around it."
> ► **"Leave it, and keep it safe."** — **ILSABET:** "Then my grandchildren will have the same question."

**Scene 4: the shelf.** Whatever she decides, Tilda writes the family's name inside the cover, and, beneath it, "Held for the day we are ready."

**ILSABET:** "She never told us because she did not know. That is what I have learned."
**ILSABET:** "That is a sentence, too."

**Outcomes and receipt.**
- The prompt-book is recovered and kept. **Whatever the player chooses, the promise itself is not shown to the player or the reader.** If the page is lifted, it tears across the middle of the line; if it is left, it is sealed in a lead box.
- **Receipt:** a blue buckram book in Tilda's records room; a new family custom of reading its margins aloud at the vigil.
- **Canon-safe:** this deliberately does *not* answer what the Magician promised the king.

<!-- quest
id: qst_aur_prompt_book
title: The Prompt-Book
rank: A
type: Exploration
giver: npc_tilda_vantoor
region: reg_aurumdeep
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 140000
sets: aur_prompt_book_done
summary: A survivor's granddaughter wants the theatre's prompt-book read, because it may record the Magician's promise to the king.
objectives:
  talk npc_tilda_vantoor
  reach aurumdeep_prompt_corner
  choice lift_copy_or_keep
-->

---

## 3. The King Who Waits

*A · Investigation · the Sunken Palace · giver Diver Oskar Tidewell*

**The short version.** Oskar says he saw the king alive in the throne room of the Sunken Palace, sitting upright, waiting for the show to end. No one believes him. He is no longer sure he does.

**What is really going on.** Something is seated on the throne under the water. It is not clear whether it is a body, an illusion or a courtesy. The player is asked only to look, and to come back with something honest to say.

**Scene 1: the dive shed.**

**OSKAR:** "Sixty fathoms, give or take. The upper floors of the palace are in light. The throne room's the third one down."
**OSKAR:** "He was sitting very straight. Hands on the arms. Crown on."
**OSKAR:** "He *looked* at me. And I did what you do, I'm ashamed of it, I turned round and swam."
> ► **"Did he move?"** — **OSKAR:** "No. But the water round him did."
> ► **"What do you want from me?"** — **OSKAR:** "Go and see. Tell me I was wrong. Or right. Either."
> ► **"I'll go."** — **OSKAR:** "Pray first."

**Scene 2: the descent.** A long, still dive through blue-gold light, down a grand staircase where fish drift like thoughts. Enchanted lamps burn in the palace halls. In the third hall, a pair of doors, standing open.

*The throne room is vast and calm. On the throne, upright, a crowned figure. Its face is a mask of calm. The water around it is very slightly warmer.*

**FIGURE (a voice not from the mouth, but from the water):** *"Is it time?"*
> ► **"Not yet."** — **FIGURE:** *"I thought not. It never is."*
> ► **"Who are you?"** — **FIGURE:** *"I am waiting."*
> ► **"I'm only a visitor."** — **FIGURE:** *"Then you are very welcome. Few come in."*

**Scene 3: the crown.** The crown is within reach. It is plain, heavy, plainly gold, and it is the thing every explorer in the camp has come for.

> ► **(Take the crown.)** — The water goes very, very still.
> ► **(Bow, and leave it.)** — The figure inclines its head.
> ► **(Sit with it a while.)** — A long, odd, companionable silence.

**Scene 4: the shed.** On the surface, Oskar waits with a blanket and a flask.

**OSKAR:** "Well?"
**PLAYER:** (the player tells him what was seen, as they choose)
**OSKAR:** "Then I wasn't mad."
**OSKAR:** "That's worse. But thank you."

**Outcomes and receipt.**
- The player brings back an honest account; Oskar is believed by the divers who matter. If the crown was taken, the throne room's warmth fades and the figure is gone from Oskar's telling. If the player sat with it, Oskar dives once more and sits too.
- **Receipt:** a hand-drawn chart of the palace in the dive shed with "the third hall: be polite" written on it.
- **Canon-safe:** this is a pure seed. Whether it is the king, a memory or the Magician's work is **unexplained.**

<!-- quest
id: qst_aur_king_waits
title: The King Who Waits
rank: A
type: Investigation
giver: npc_oskar_tidewell
region: reg_aurumdeep
level: 134
act: 4
requires_rank: A
reward: 32000 | 1600 | 145000
sets: aur_king_waits_done
summary: A deep diver swears he saw the king alive on his throne in the Sunken Palace. He wants someone to check.
objectives:
  talk npc_oskar_tidewell
  reach aurumdeep_palace_throne_room
  choice take_bow_or_sit
-->

---

## 4. An Empty Seat at Every Table

*A · OddJob · the camp's long table · giver Cook Dagobert Kettle*

**The short version.** On the anniversary of the sinking, the survivors' descendants keep a silent vigil with an empty seat at every table. Dagobert cooks for the camp, and for the vigil, and this year the two have clashed.

**What is really going on.** A band of new treasure-hunters has taken the vigil's tables for a loud celebration of their first big find. They don't know the custom, nobody told them, and the descendants will not say. The player's job is to bring the two groups to one long table without a quarrel and without anyone clapping.

**Scene 1: the kitchen.**

**BRANNOCH:** "I feed a hundred a day. This evening I'm told I must feed two hundred, in two rooms, at the same time, and one of them mustn't hear the other."
**BRANNOCH:** "The families have asked for silence. The new lot have bought a barrel."
**BRANNOCH:** "I'd like nobody hurt. And I'd like my soup eaten hot."
> ► **"Whose side are you on?"** — **BRANNOCH:** "The soup's."
> ► **"What does the vigil need?"** — **BRANNOCH:** "An empty chair. And quiet, all night."
> ► **"I'll talk to both."** — **BRANNOCH:** "Gently. They're both grieving, in different ways."

**Scene 2: the newcomers.** The loud table is crowded with a dozen young hunters, one of them wearing a gold chain still wet from the Stair.

**HUNTER (a freckled woman named Josse):** "We found a chest! A *chest!* We're allowed to be happy, aren't we?"
**HUNTER:** "Nobody said anything about a vigil."
> ► **"Tell them what it is."** — **JOSSE:** "...Oh. Oh no."
> ► **"Ask them to share."** — **JOSSE:** "Share what? The barrel?"
> ► **"Ask them to be quiet. Just tonight."** — **JOSSE:** "Is that all? We can do that."

**Scene 3: the families.** In the next hall, the descendants sit shoulder to shoulder, in plain dark coats. A single chair at the head of every table is left bare.

**ELDER (a very old man named Hadley Vantoor-Reeve):** "We do not ask anyone to join. We only ask no one disturb."
> ► **"Would you let them sit with you?"** — A pause.
> ► **"Would you let them bring the chest?"** — **ELDER:** "...What is in it?"
> ► **"I'll hold the door."** — The old man nods.

**Scene 4: the long table.** By midnight, there is one very long table. At its head, a chair that no one sits in. The hunters sit in silence; the descendants pass the bread. Josse, quietly, lays a single gold coin on the empty chair.

**ELDER:** (barely audible) "That is the first time."
**BRANNOCH:** "The soup's cold. No one minds."
*No one applauds. Everyone feels it.*

**Outcomes and receipt.**
- The vigil is kept unbroken, and the newcomers are folded into it. If the player let the hunters keep their barrel loud, the families leave and the vigil is held in the dark, by two people.
- **Receipt:** a gold coin on a chair that stays empty; Dagobert sets a second long table every year.

<!-- quest
id: qst_aur_empty_seat
title: An Empty Seat at Every Table
rank: A
type: OddJob
giver: npc_dagobert_kettle
region: reg_aurumdeep
level: 124
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: aur_empty_seat_done
summary: A loud celebration and a silent vigil have been booked into the same hall on the anniversary of the sinking.
objectives:
  talk npc_dagobert_kettle
  reach aurumdeep_camp_long_table
  choice tell_share_or_hush
-->

---

## 5. The Coin on the First Step

*A · Hidden · the water's edge · giver Tamsin Quill*

**The short version.** Every diver leaves a coin on the first step of the water for the dead. Tamsin sweeps the step each dawn and counts them. For a month, the count has been wrong.

**What is really going on.** Someone is taking coins in the night. It is not a thief. It is one of the polite dead, a small, dripping page-boy in a velvet cap, who has been collecting them to buy, for his mistress, a ribbon from a shop that no longer exists. Tamsin has noticed him; the grown-ups have not.

**Scene 1: the step.**

**TAMSIN:** "Forty-one coins on Monday. Thirty-six on Tuesday. Thirty-eight on Wednesday. They go missing."
**TAMSIN:** "I think it's a person. A small one."
**TAMSIN:** "I don't want him punished. I want to know."
> ► **"Have you seen him?"** — **TAMSIN:** "A bit. He walks on the wet part."
> ► **"Why does it matter?"** — **TAMSIN:** "They're *for* somebody."
> ► **"I'll wait with you."** — **TAMSIN:** "Bring a blanket. He comes after the lamps dim."

**Scene 2: the vigil of two.** Before dawn the player and Tamsin sit on the cold stone above the water. The coins catch the lamp-glow. Then footsteps, small ones, wet ones. A boy, no older than twelve, in a velvet page's cap and livery, dripping.

**PAGE (a whisper):** "I'm sorry. I'm so sorry. I only take the small ones."
**PAGE:** "She'll want a ribbon. It's the Feast of Lamps tomorrow, and she has none."
> ► **"Who is she?"** — **PAGE:** "Lady Merewen. She is very kind."
> ► **"The coins are for the dead."** — **PAGE:** "I *am* the dead."
> ► **"Let him take them."** — **TAMSIN:** "...Yes."

**Scene 3: the shop.** There is no shop; the street it stood on lies fathoms down. But a gold-leaf signboard still hangs in a drowned arcade, and a dry stall inside it holds a coil of ribbon, brittle with age, the colour of apricots.

> ► **(Ask the page to show the way.)** — He does, gravely.
> ► **(Go alone and bring it back.)** — He waits at the water's edge.
> ► **(Buy a fresh ribbon in the camp instead.)** — A quiet shake of his head: "It must be the old kind."

**Scene 4: the offering.** The page carries the ribbon, held out in both hands, into the dry halls.

**PAGE:** "I didn't steal them. I *borrowed* them. I'll put them back."
**TAMSIN:** "You can keep them."
**TAMSIN:** (to the player, solemnly) "He needed them more than the step."

**Outcomes and receipt.**
- The page is thanked. Tamsin starts leaving a second, smaller coin on the step each morning, marked "for the boy." If the player brought a fresh ribbon, the page accepts it and is faintly sad.
- **Receipt:** a velvet cap on the first step, folded, with a single apricot thread beside it.
- **Links:** Lady Merewen Verrane (quest 8) is the "mistress."

<!-- quest
id: qst_aur_coin_step
title: The Coin on the First Step
rank: A
type: Hidden
giver: npc_tamsin_quill
region: reg_aurumdeep
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: aur_coin_step_done
summary: Coins keep vanishing from the first step of the water. A nine-year-old who counts them has a theory.
objectives:
  talk npc_tamsin_quill
  reach aurumdeep_first_step
  choice ask_alone_or_fresh
-->

---

## 6. Fool's Gold Season

*A · Investigation · the camp's assay hall · giver Assayer Garrick Lathe*

**The short version.** Three gold bars passed the assay this month and turned to coloured paint by dawn. The buyers are furious and the camp's reputation is on the line. Garrick wants to know whether it is a swindle or the city.

**What is really going on.** It is neither, quite. The bars were real gold, taken from a particular flooded counting-house whose lamps have failed. The gold is *bound* to the lamp-light that the Magician's enchantment keeps burning; away from it, a bar slowly forgets what it is. Honest divers are being ruined by a fact no one has told them.

**Scene 1: the hall.**

**CORVANE:** "I have assayed gold since before you could hold a pan. These three bars were *good.* The acid said so. The scale said so. And at dawn, they are *paint.*"
**CORVANE:** "I have been accused of fraud by a dwarf. I have never been so insulted."
> ► **"Where did they come from?"** — **CORVANE:** "The Counting-House of Three Scales. Different divers each time."
> ► **"Were they switched?"** — **CORVANE:** "I locked them myself."
> ► **"Show me."** — **CORVANE:** "Gladly. Bring a lamp."

**Scene 2: the counting-house.** A dive into a vault district: heavy doors, rows of locked drawers, enchanted lamps burning gold on the ceiling. In the drawers, ingots and coins, bright and solid. The player carries one back into the dark mouth of a corridor.

*The ingot dulls in the shadow, slowly, from the edges in, like a breath fading on a mirror.*

**CORVANE (in the bell, through a speaking-tube):** "Do you see it? It *goes.*"
> ► **"It needs the light."** — **CORVANE:** "Then it was never ours to take."
> ► **"It's bound to the lamps."** — **CORVANE:** "Then the camp's fortune is borrowed."
> ► **"Try a different lamp."** — **CORVANE:** "Try. And be careful."

**Scene 3: the test.** Back on the surface, three ingots on three tables: one under a lantern from the vault, one under a camp lamp, one in the dark. At dawn, only the vault-lit ingot is still gold.

**CORVANE:** "So the city *lends.* And takes it back."
**CORVANE:** "Which makes this the most honest thing it's ever told us."

**Scene 4: the notice.** Garrick drafts a new rule for the camp: *all ingots to be sold with a vault-lit lamp, for the buyer to carry.*

> ► **(Publish it in full.)** — The market shudders, then adjusts.
> ► **(Tell only the council.)** — The fences keep their edge.
> ► **(Let Garrick choose.)** — **CORVANE:** "Publish. I would rather be honest and poor."

**Outcomes and receipt.**
- The "fool's gold" is explained to the camp; buyers are refunded, and the divers learn which hoards are borrowed. If the player kept the secret, Garrick quietly resigns the assay.
- **Receipt:** a small brass lamp on the assay table, always lit, labelled "for carrying."
- **Canon-safe:** the quest explains only a local rule about the lamps; it does not say what the Magician's enchantment *is.*

<!-- quest
id: qst_aur_fools_gold
title: Fool's Gold Season
rank: A
type: Investigation
giver: npc_garrick_lathe
region: reg_aurumdeep
level: 128
act: 4
requires_rank: A
reward: 30500 | 1520 | 138000
sets: aur_fools_gold_done
summary: Three honest gold bars turned to paint by dawn. The camp's assayer wants to know why.
objectives:
  talk npc_garrick_lathe
  reach aurumdeep_counting_house_vault
  choice publish_council_or_leave
-->

---

## 7. Settled in the Water

*A · Faction · the council's dive-ring · giver Arbiter Marit Deepclaim*

**The short version.** Two crews claim the same drowned avenue. The council's rule is "the council, or the water." Marit has chosen the water, and needs a neutral third diver to witness it.

**What is really going on.** The avenue holds nothing of value except a long row of private shop signs. One crew wants it for the gold leaf; the other, a family of survivors' cousins, want it left as it is. Marit has already decided in her heart. She needs the player to make sure the water decides fairly.

**Scene 1: the ring.**

**MARIT:** "I've settled forty claims. I've drowned in none of them."
**MARIT:** "The Gilt Pair want the avenue stripped. The Cousins want it left. Neither will back down."
**MARIT:** "Rule is: a dive. First one to bring up a token from the far end wins. I need a witness who isn't afraid of the dark."
> ► **"Is the dive safe?"** — **MARIT:** "It's an avenue. It's meant to be."
> ► **"What are you hoping?"** — **MARIT:** "That nobody wins by cheating."
> ► **"I'll witness."** — **MARIT:** "Take a rope and two lamps. Keep both crews in sight."

**Scene 2: the dive.** In green light, two divers each side, the player swimming a slow line between them. Painted shop signs go by, a milliner's, a printer's, a bakery with a golden loaf. The Gilt Pair's leader tugs at a sign as he passes. It comes away in his hand.

**GILT DIVER:** "What? Just a *bit* of leaf."
**COUSIN DIVER (through the tube):** "That is somebody's *name.*"
> ► **"Put it back."** — He does, resentfully.
> ► **"Let it go. It's a sign."** — The Cousin turns away.
> ► **"Flag a foul."** — Marit's horn sounds above.

**Scene 3: the far end.** At the end of the avenue stands a green-glass fountain, still lit from within, and a stone token on its rim that reads *Edge of the Quarter.* Both crews reach for it at once.

> ► **(Let them both touch it.)** — A strange joint tie.
> ► **(Call the Cousins the winners.)** — The Gilt Pair roar.
> ► **(Call the Gilt Pair the winners.)** — The Cousins go quiet.

**Scene 4: the ring.** Marit reads her ruling at the surface.

**MARIT:** "I've never had a tie."
**MARIT:** "The council's rule is: if the water cannot choose, the people must. So. The Gilt Pair may take the leaf from the fountain. The Cousins keep every sign."
**GILT DIVER:** "...That's fair."
**COUSIN:** "It is."

**Outcomes and receipt.**
- A fair compromise, usually. If the player foul-called the Gilt Pair's leader, the Cousins win outright and the Gilt Pair leave the camp.
- **Receipt:** a fountain stripped of leaf and a street still signed; a new council rule, "the water may tie."

<!-- quest
id: qst_aur_settled_water
title: Settled in the Water
rank: A
type: Faction
giver: npc_marit_deepclaim
region: reg_aurumdeep
level: 132
act: 4
requires_rank: A
reward: 31500 | 1580 | 142000
sets: aur_settled_water_done
summary: Two crews claim the same drowned avenue, and the council's rule is that the water decides.
objectives:
  talk npc_marit_deepclaim
  reach aurumdeep_drowned_avenue
  choice back_let_or_foul
-->

---

## 8. The Last Dance on the Card

*A · Escort · the Hall of Mirrors · giver Lady Merewen Verrane*

**The short version.** Lady Merewen has waited in the Hall of Mirrors for more than a century for her partner to finish the last dance on her card. She asks the player to escort her, through the dry halls, to the one place she can be sure he is.

**What is really going on.** The partner is long gone. But in the Bandstand Hall an old gilded orchestra-box still plays on a spring, if wound, the final waltz. The dance is the only thing Merewen needs to *finish.* The player's job is to walk beside her, and not to correct her.

**Scene 1: the mirrors.**

**ODALYS:** "I do beg your pardon. You are not on my card, but you are very kind to stop."
**ODALYS:** "I am waiting for Lord Ferren to return. He was called away for a moment. He said, 'Save me the last waltz.'"
**ODALYS:** "It has been such a long moment."
> ► **"How long have you waited?"** — **ODALYS:** "Oh, an evening. Perhaps two."
> ► **"Where might he be?"** — **ODALYS:** "The Bandstand Hall. It is where the last waltz is always played."
> ► **"I'll take you there."** — **ODALYS:** "How gallant. Do mind the puddles."

**Scene 2: the walk.** A slow progress through dry halls and half-lit galleries, with the lady's pale gown whispering over the stone. She greets the dead they pass, who greet her back.

**ODALYS:** "That is Mr. Hale, who plays the cello. And Mrs. Pym, who has such lovely hands."
**ODALYS:** "Do you dance?"
> ► **"Badly."** — **ODALYS:** "Everyone does, to begin with."
> ► **"No."** — **ODALYS:** "Then you must be very good at something else."
> ► **"I will, if you like."** — **ODALYS:** "Oh, no. I am promised."

A painted dragon of silk uncoils from a chandelier above them and sails down the hall. The lady curtsies to it without breaking step.

**Scene 3: the Bandstand.** The Bandstand Hall is round, high and mostly unflooded. In its centre, an orchestra-box of brass and gilt, wound by a key. The key is on a ribbon on the wall.

**ODALYS:** "He is not here."
**ODALYS:** "...Is he?"
> ► **"Wind the box."** — The waltz begins, thin and sweet.
> ► **"Tell her the truth."** — **ODALYS:** "I know. I think I have always known."
> ► **"Offer your hand for the dance."** — She smiles, and refuses, and accepts.

**Scene 4: the waltz.** The box plays. Merewen closes her eyes, lifts her hand to a partner no one else can see, and turns once, slowly, across the floor. When the music ends, she is smiling.

**ODALYS:** "Thank you. I believe I may sit down now."
*She sits on a gilt chair at the edge of the floor. She does not stand up again. Her gown remains, folded on the chair, the colour of apricots.*
*The player does not clap. No one in the hall does. It is, somehow, the right silence.*

**Outcomes and receipt.**
- Merewen is at rest. If the player told her the truth, she faces the music more bravely. If the player danced, the music box plays a little longer.
- **Receipt:** a gilt chair with a folded gown at the Bandstand Hall; the page-boy (quest 5) brings an apricot ribbon to it.
- **Canon-safe:** the polite dead are shown to be able to finish something and rest. This is not offered as an answer to the sinking.

<!-- quest
id: qst_aur_last_dance
title: The Last Dance on the Card
rank: A
type: Escort
giver: npc_merewen_verrane
region: reg_aurumdeep
level: 136
act: 4
requires_rank: A
reward: 33000 | 1650 | 148000
sets: aur_last_dance_done
summary: A dead lady in the Hall of Mirrors has waited a century for her partner to return for the last dance on her card.
objectives:
  talk npc_merewen_verrane
  escort npc_merewen_verrane
  reach aurumdeep_bandstand_hall
  choice wind_truth_or_dance
-->

---

## 9. The Census of the Blind Fish

*A · Exploration · the flooded streets · giver Scholar Lucan Marsh*

**The short version.** Lucan counts the blind white fish, cave eels and golden-shelled crabs of the lamp-lit streets. Their numbers fall wherever a lamp dies. He needs a diver who will count with him, at depth, in the dark.

**What is really going on.** The ecology of the sunken city rests on lamp-algae, which grows only in enchanted light. Greedy divers take lamps for sale; each lamp lost starves a block. The player's census will show where, and the choice is whether to name the lamp-thieves, or leave their identity unsaid.

**Scene 1: the study.**

**TEODRIC:** "Eight hundred and twelve fish in Lamp Street, on the first count. Two hundred and six on the last."
**TEODRIC:** "Someone is taking the lamps."
**TEODRIC:** "I don't wish to hang anyone. I wish to know where."
> ► **"What do you need counted?"** — **TEODRIC:** "Fish. Eels. Crabs. Algae. Quietly."
> ► **"Is it worth it?"** — **TEODRIC:** "They're the only living things in the city that don't want the gold."
> ► **"I'll count."** — **TEODRIC:** "Do not startle the eels. They sulk."

**Scene 2: the transects.** Three dives in three districts, each beginning with a slate, a rope and a count. The fish are small, white, calm; they turn in the lamp-glow like a slow snow. In one avenue, the lamps are dark, and the fish are gone. The crabs scuttle past in shell-armour of dull gilt.

**TEODRIC (through the tube):** "Two. Three. Four..."
**TEODRIC:** "That is a very large eel."
> ► **"Hold still."** — The eel passes.
> ► **"Count it twice."** — **TEODRIC:** "Yes, in the interest of rigour."
> ► **"Let it count us."** — **TEODRIC:** "Ha."

**Scene 3: the dark block.** In the last district, a block of lampposts has been sawn off at the foot. Scratches on the stone show where a winch was bolted. Scraps of rope still bear a crew's green dye.

**TEODRIC:** "That's the Galloway crew's green."
**TEODRIC:** "...They are my friends."
> ► **"Name them."** — **TEODRIC:** "Then they'll lose their licence."
> ► **"Warn them privately."** — **TEODRIC:** "That is more my style."
> ► **"Ask the council to ban lamp-salvage."** — **TEODRIC:** "It will not be popular."

**Scene 4: the lamp.** Lucan asks the Galloway crew to re-hang one lamp, by hand, at its old post. They do. In an hour, the algae brightens and one white fish drifts back.

**TEODRIC:** "That's the first one since March."
**TEODRIC:** "Be good to him."

**Outcomes and receipt.**
- A lamp-salvage rule is agreed with the council, or a private truce with the crew, depending on the choice. If the crew was named in public, they leave the camp and the lamps are guarded.
- **Receipt:** a slate of counts pinned in the study, each line initialled; a lamp rehung in Lamp Street, with a fish beside it.

<!-- quest
id: qst_aur_blind_fish
title: The Census of the Blind Fish
rank: A
type: Exploration
giver: npc_lucan_marsh
region: reg_aurumdeep
level: 138
act: 4
requires_rank: A
reward: 33500 | 1680 | 150000
sets: aur_blind_fish_done
summary: Fish fall in number wherever a lamp dies. A naturalist needs someone to count them at depth.
objectives:
  talk npc_lucan_marsh
  reach aurumdeep_lamp_street_transects
  choice name_warn_or_ban
-->

---

## 10. The Hundredth Step

*A · Defense · the Long Stair · giver Porter-Captain Hesper Gladewick*

**The short version.** The Long Stair has a memorial shrine at every hundredth step. Eleven hundred steps up, a landing is under attack by a flock of cave bats, and the porters will not leave the shrine undefended.

**What is really going on.** The bats are not hunting. They are fleeing something below, a slow, grinding shake in the rock, that has nothing to do with the Magician and does not get explained. The porters need the stair held for one night so the last supply-line of the season can climb.

**Scene 1: the landing.**

**HESPER:** "Twelve hundred steps and eleven shrines. I have never lost a landing."
**HESPER:** "I have two hundred porters on the stair tonight and a thousand loaves in crates. Something's driving the bats in."
**HESPER:** "I'll hold the shrine. You hold the stair."
> ► **"What's driving them?"** — **HESPER:** "Something below. Not us."
> ► **"How many porters are above?"** — **HESPER:** "Eighty. They need the night."
> ► **"I'll hold."** — **HESPER:** "Then stand where the lamps are brightest."

**Scene 2: the first wave.** Under a vaulting rock roof, in lantern-light, the bats come in drifts: hundreds of small, panicked wings. The porters raise shields and pots and songs. The player strikes, parries, drives them upward, away from the crates.

*(Gameplay: wave defence on a narrow stair; the player protects crates, lamps and the shrine; the bats scatter rather than die, and killing too many shakes the dust down on the porters.)*

**PORTER:** "They're not attacking! They're *running!*"
**HESPER:** "Keep the lamps lit! Let them through!"

**Scene 3: the tremor.** At midnight, a low groan comes up the stair. Dust falls from the roof. At the shrine of the eleventh hundred, a small stone figure slides from its niche.

> ► **(Catch the figure.)** — It is heavy, cold, intact.
> ► **(Shore up the niche.)** — A cluster of porters join you.
> ► **(Clear the stair for the last convoy.)** — The line begins to move.

**Scene 4: the dawn.** The tremor fades. The bats settle on the roof, panting. The last crates climb past the shrine in the grey light, and every porter, passing, touches the figure and says a name.

**HESPER:** "Eleven hundred. We held."
**HESPER:** "Don't clap. They never forgive that."
*A porter laughs, once, very quietly, and then they are all laughing.*

**Outcomes and receipt.**
- The stair holds, the supplies arrive and the shrine is restored. The cause of the tremor is **not explained.** If the player killed many bats, the roost moves down into the city.
- **Receipt:** a new shrine figure, set a little crooked on purpose; the porters' habit of saying a name at each landing.
- **Canon-safe:** the quest does not touch the region's siege or the Magician; it is a defence of a supply stair against a minor, unexplained disturbance.

<!-- quest
id: qst_aur_hundredth_step
title: The Hundredth Step
rank: A
type: Defense
giver: npc_hesper_gladewick
region: reg_aurumdeep
level: 148
act: 4
requires_rank: A
reward: 38000 | 1900 | 170000
sets: aur_hundredth_step_done
summary: Panicked cave bats and a tremor threaten a stair landing and a last convoy of supplies.
objectives:
  talk npc_hesper_gladewick
  defend aurumdeep_long_stair_landing
  choice catch_shore_or_clear
-->
