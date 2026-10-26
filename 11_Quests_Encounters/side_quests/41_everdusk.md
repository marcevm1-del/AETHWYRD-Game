# 11e-41 — Everdusk, the Twilight Forest: Ten Side Quests (draft)

> *"Never say thank you. Never give your name. Everything else, we can discuss."*
> — woodcutters' saying, the forest's edge

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 6, 7 and 9 plant unexplained seeds.

**Region:** `reg_everdusk` (the Summer Court glades, the Last Glade, the Thorn Throne, the Edge Stones, the silver rivers). **Rank band:** A–S. **Tone:** courteous, uncanny, honey and frost; every kindness has a price and every price can be argued with.

**Placement notes.**
- **The Briar King, Lord of the Winter Court,** is the region's Tyrant. His thorns are swallowing the Summer Court's glades; only the Last Glade remains. No quest here kills, banishes or negotiates away the Briar King, ends the encroachment of the thorns or decides the war between the courts. He is seen only as a bargain-maker's seal, a cold wind and a rumour.
- Customs the quests rely on: **politeness is law;** **thanks are debts** (never say thank you to a fey); **never give your name;** **every bargain binds;** paths change with the walker; time flows differently in the glades; offerings are left at the **Edge Stones;** fey goods and secrets are traded for mortal names, memories and years.
- The Summer Court has begun to **ask mortals for help,** which is unprecedented. Quests 2 and 10 show this without resolving it.
- Not used: a siege. The thorns are an encroachment, not a siege state, so no quest here is `SiegeDefence`.
- Fey NPCs are written `race: Fey`; mortals are `Human`.
- **Rank note.** This region's band reaches S. Quests 7 to 10 are S-rank; their rewards are extrapolated as in [[31_whitewater_reach]] (S: level 166–205; GP about 3,000; see `Data/World/guild_ranks.json`) and are first-pass.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | Back Before Dawn | A | Escort | Woodcutter Torben Oakleft | A father, a revel, and no dawn to be back by |
| 2 | Generous Terms | A | Faction | Herald Sennet Quickdew | A contract that is kind on its face |
| 3 | The Bargain That Would Not Break | A | Investigation | Cooper Merrick Reedmarsh | A debt to the Winter Court |
| 4 | A Debt of Thanks | A | OddJob | Mother Isolt Hazelmere | A boy said the wrong word |
| 5 | The Edge Stones Are Walking | A | Exploration | Edge-keeper Tamsen Mossback | Offerings, and where they go |
| 6 | The Child Who Came Back | A | Hidden | Nissa Underbough | A memory she may not want |
| 7 | Paths That Remember | S | Exploration | Pathwarden Sorcha Hawthornwake | The forest, walked by someone else |
| 8 | A Courtier of the Winter Court | S | Escort | Courtier Ysmere Rimeglass | Grief across a border |
| 9 | Day or Night | S | Investigation | Elowen Briarlight | An old argument, asked by a child |
| 10 | A Guest at the Last Glade | S | OddJob | Lady Calanthe Evenfall | A hospitality, and its rules |

## Cast

<!-- npc
id: npc_woodcutter_torben_oakleft
name: Woodcutter Torben Oakleft
tier: townsfolk
race: Human
region: reg_everdusk
settlement: Forest edge
role: Woodcutter whose daughter went to a revel
backstory: A big, careful woodcutter of fifty who has taught his daughter every rule of the forest and who knows that rules are exactly what the fey invite you to forget.
-->
<!-- npc
id: npc_linnea_oakleft
name: Linnea Oakleft
tier: townsfolk
race: Human
region: reg_everdusk
settlement: Forest edge
role: Woodcutter's daughter at a fey revel
backstory: A bright, curious sixteen-year-old who has been dancing at a revel for what feels like an hour, and who is wearing a dress she cannot remember being given.
-->
<!-- npc
id: npc_herald_sennet_quickdew
name: Herald Sennet Quickdew
tier: major
race: Fey
region: reg_everdusk
settlement: Summer Court glades
role: Herald of the Summer Court
backstory: A slender, golden-eyed herald of the Summer Court who has never in her long life asked a mortal for anything, and who has been ordered, courteously, to begin.
-->
<!-- npc
id: npc_cooper_merrick_reedmarsh
name: Cooper Merrick Reedmarsh
tier: townsfolk
race: Human
region: reg_everdusk
settlement: Forest edge
role: Barrel-maker with a bargain
backstory: A tired, careful barrel-maker of forty-five who made a bargain with the Briar King's thorns for his wife's life and has spent three years paying a price he did not understand when he signed.
-->
<!-- npc
id: npc_mother_isolt_hazelmere
name: Mother Isolt Hazelmere
tier: townsfolk
race: Human
region: reg_everdusk
settlement: Forest edge
role: Mother of a boy who said thank you
backstory: A sharp-tongued, anxious mother of three whose youngest, a boy of seven, thanked a fey for a loaf of bread and has been very quiet ever since.
-->
<!-- npc
id: npc_edge_keeper_tamsen_mossback
name: Edge-keeper Tamsen Mossback
tier: major
race: Human
region: reg_everdusk
settlement: The Edge Stones
role: Keeper of the Edge Stones
backstory: A weathered edge-keeper who has tended the offering-stones at the forest's edge for thirty years and has noticed, with growing disquiet, that they are no longer where she left them.
-->
<!-- npc
id: npc_nissa_underbough
name: Nissa Underbough
tier: major
race: Human
region: reg_everdusk
settlement: Forest edge
role: Woman stolen as a child and returned as an adult
backstory: A quiet, grey-eyed woman of about forty who was taken from the forest's edge as a child and returned, a generation ago, with no memory of where she had been.
-->
<!-- npc
id: npc_pathwarden_sorcha_hawthornwake
name: Pathwarden Sorcha Hawthornwake
tier: major
race: Fey
region: reg_everdusk
settlement: Summer Court glades
role: Warden of the shifting paths
backstory: A tall, thorn-crowned fey who has walked the forest's paths for longer than the treaty has been old, and who has just discovered a path that remembers a walker who was not there.
-->
<!-- npc
id: npc_courtier_ysmere_rimeglass
name: Courtier Ysmere Rimeglass
tier: major
race: Fey
region: reg_everdusk
settlement: Winter Court glades
role: Courtier of the Winter Court
backstory: A cold, graceful courtier of the Winter Court who once shared a long afternoon with a Summer poet and has just learned that the poet is dying.
-->
<!-- npc
id: npc_elowen_briarlight
name: Elowen Briarlight
tier: townsfolk
race: Human
region: reg_everdusk
settlement: Forest edge
role: Nine-year-old who asked whether it is day
backstory: A solemn nine-year-old who lives in the dusk, has never seen a proper noon or a proper night, and has asked a question nobody has dared to answer in a thousand years.
-->
<!-- npc
id: npc_lady_calanthe_evenfall
name: Lady Calanthe Evenfall
tier: major
race: Fey
region: reg_everdusk
settlement: The Last Glade
role: Lady of the Last Glade
backstory: A tall, silver-gold lady of the Summer Court who holds the Last Glade against the thorns and has decided, against all form, to hold a feast.
-->

---

## 1. Back Before Dawn

*A · Escort · the Hour That Isn't · giver Woodcutter Torben Oakleft*

**The short version.** Torben's daughter, Linnea, was invited to a fey revel. She promised to be back before dawn. In Everdusk, dawn is a matter of opinion. Torben asks the player to fetch her, without breaking a single rule.

**What is really going on.** The revel is real, and warm, and not cruel. Linnea has been dancing for what feels like an hour; it has been three days. Taking her *by force* would be an insult, and insult binds. The player must persuade her, and persuade the hosts to let her go, without saying thank you or giving a name.

**Scene 1: the cottage.**

**TORBEN:** "She went to the Edge Stones at dusk. She came back, once, for her shawl. Then she went again."
**TORBEN:** "I taught her the rules. *Never say thank you. Never give your name. Never eat what you are not offered twice.* She will keep them. It is the hosts I am afraid of."
**TORBEN:** "Bring her back before dawn. And be *polite.*"
> ► **"When is dawn?"** — **TORBEN:** "Whenever the glade decides it is."
> ► **"What if she doesn't want to come?"** — **TORBEN:** "Then ask her why. *Gently.*"
> ► **"I'll bring her."** — **TORBEN:** "Do not give them your name."

**Scene 2: the revel.** In a glade lit by floating lanterns, a hundred fey dance in a slow wheel. Linnea is in the middle, laughing, a circlet of white flowers in her hair. A tall host in a cloak of moths notices the player and inclines his head.

**HOST:** "A guest. How lovely. You will eat?"
> ► **"I will, once."** — **HOST:** "Once is not twice. You are wise."
> ► **"I cannot say thank you."** — **HOST:** "Quite right. Say *what you will.*"
> ► **"I have come for the girl."** — **HOST:** "She is a guest, not a captive. Ask her."

**Scene 3: the asking.** Linnea, flushed and bright, takes the player's hands in the dance and says:

**LINNEA:** "I know! I *know.* I'm supposed to go home. But I haven't danced like this in my *life.*"
**LINNEA:** "They gave me this dress. I can't remember when."
**LINNEA:** "If I go home, I'll never be here again. Will I?"
> ► **"You can come back, by invitation."** — **LINNEA:** "Truly?"
> ► **"Your father is afraid."** — **LINNEA:** "...Oh."
> ► **"Dance one more, then we go."** — **LINNEA:** "One more. Only one."

**Scene 4: the leaving.** After one more dance, the host bows low and removes the circlet from her hair, which turns to white petals in his hand.

**HOST:** "A guest may leave at any hour. We trade a gift for a gift. What do you give?"
*The player must offer a gift without saying thank you and without giving a name: a story, a tune, a button, a lock of hair.*
**HOST:** "Accepted. Fair is fair."
*Linnea steps out of the glade, and it is, at last, grey with the first light of an ordinary dawn.*

**Coda: the petal.** At the cottage, Torben does not speak for a long time. He wraps his daughter in the shawl she forgot, and puts the kettle on, and sits with his back to her so she will not see his face.

**TORBEN:** "I will not ask what you ate."
**LINNEA:** "I ate twice."
**TORBEN:** "I know. I can smell the honey."
> ► **"She kept all the rules."** — **TORBEN:** "She did. It is the one thing that surprised me."
> ► **"She may go again, by invitation."** — **TORBEN:** "I know. I will walk her to the stones myself."

**Outcomes and receipt.**
- Linnea is returned to her father; the gift is owed to no one. If the player gave a name, the host says it once, softly, and it follows them through the forest for a night.
- **Receipt:** a single white petal in Linnea's pocket that does not wilt; an invitation, written in dew, to return when the days are long.

<!-- quest
id: qst_evd_back_before_dawn
title: Back Before Dawn
rank: A
type: Escort
giver: npc_woodcutter_torben_oakleft
region: reg_everdusk
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: evd_back_dawn_done
summary: A woodcutter's daughter has been invited to a fey revel and promised to be home before dawn, in a forest where dawn is a matter of opinion.
objectives:
  talk npc_woodcutter_torben_oakleft
  escort npc_linnea_oakleft
  reach everdusk_revel_glade
  choice return_father_or_one_more
-->

---

## 2. Generous Terms

*A · Faction · the Summer Court glades · giver Herald Sennet Quickdew*

**The short version.** For the first time in the forest's history, the Summer Court is asking mortals for help. The herald offers a contract: a mortal champion, generous terms. It is exactly the kind of offer woodcutters are warned about.

**What is really going on.** The Summer Court is not deceiving anyone. It is *desperate,* and it has never learned to ask. Its terms are written in the usual fey way: generous in the headline, unlimited in the small print. The player can sign, amend or refuse. The quest does not require a champion to fight the Briar King; it asks only for a *champion's pledge.*

**Scene 1: the herald.**

**SENNET:** "We have never asked a mortal for anything. We find it... undignified."
**SENNET:** "It is, however, urgent. We have one glade left."
**SENNET:** "Here are our terms. Read them. Do not thank me."
> ► **"What do you want?"** — **SENNET:** "A champion. To stand for us."
> ► **"What is the price?"** — **SENNET:** "There is none. That is the generous part."
> ► **"Show me the contract."** — **SENNET:** "At last. Sense."

**Scene 2: the contract.** On a scroll of woven vines, in silver ink: *"The Summer Court shall grant the Champion all she asks, for all time, in exchange for a single service, to be named."*

**SENNET:** "You may ask anything. Gold, years, the memory of a loved one's face."
**SENNET:** "In exchange, you shall perform a single service. When we name it."
> ► **"What service?"** — **SENNET:** "I do not know. The queen will decide."
> ► **"That is not generous. That is open."** — **SENNET:** "...You are correct. I did not write it."
> ► **"Let me amend it."** — **SENNET:** "Court law allows one amendment."

**Scene 3: the amendment.** The player drafts a clause with the herald across a table of moss. The herald winces at every word.

**SENNET:** "'*The service shall be named at signing.*' Cruel."
**SENNET:** "'*The service shall not require the Champion's name, nor memory, nor years.*' Crueller."
**SENNET:** "'*The Champion may refuse any service and forfeit only the gifts received.*' ...That is almost a *mortal* contract."
> ► **(Insist on all three.)** — The herald, pale, carries them to the queen.
> ► **(Drop the third.)** — Easier; riskier.
> ► **(Walk away.)** — **SENNET:** "...The court will remember this."

**Scene 4: the reply.** After a night that is also a week, the herald returns, hair in disarray.

**SENNET:** "The queen has accepted the first two. The third she has... *amended.*"
**SENNET:** "She says: '*The Champion may refuse any service, and she will be very sorry, and so shall we.*'"
**SENNET:** "It is, I think, the most courteous clause the court has ever written."
*The player signs. The ink dries silver.*

**Coda: the leaf.** Outside the glade, the herald waits by the stream, not looking at the player directly. She hands over the gold-green leaf as if it might bite.

**SENNET:** "I am told this is called a *keepsake.* We do not have the word."
**SENNET:** "It warms when we have need. Do not feel obliged to come."
**SENNET:** "...Feel free to come."
> ► **"I'll come when it warms."** — **SENNET:** "We shall be... adequately grateful. Without saying so."
> ► **"You asked well."** — **SENNET:** "It was very difficult. I should like never to do it again. I will, of course."

**Outcomes and receipt.**
- The Summer Court has a mortal champion on fair terms. The champion is **not** sent against the Briar King and no service is named. If the player walked away, the court remembers, but does not retaliate.
- **Receipt:** a silver-edged scroll in the player's pack; a small gold-green leaf that warms when the Summer Court has need.

<!-- quest
id: qst_evd_generous_terms
title: Generous Terms
rank: A
type: Faction
giver: npc_herald_sennet_quickdew
region: reg_everdusk
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: evd_terms_done
summary: The Summer Court has asked a mortal for help for the first time. Its terms are generous on their face, and open underneath.
objectives:
  talk npc_herald_sennet_quickdew
  reach everdusk_summer_court_table
  choice sign_amend_or_walk
-->

---

## 3. The Bargain That Would Not Break

*A · Investigation · the forest edge · giver Cooper Merrick Reedmarsh*

**The short version.** Merrick made a bargain with the Briar King's thorns three years ago, to save his wife. He wants out. Every bargain binds, but every bargain has a shape. The player looks for the shape.

**What is really going on.** The bargain was for his wife's life in exchange for "a thing he will not miss." The thing was his ability to hear her laugh. She lives, and he cannot hear her. The Briar King's terms are cruel, but not unbreakable: a bargain can be *paid out,* *traded* or *outlasted.*

**Scene 1: the cooperage.**

**MERRICK:** "She is alive. I will not say I regret it."
**MERRICK:** "But she laughs at supper and I see her mouth move and I hear nothing."
**MERRICK:** "I would like it back. If it can be bought."
> ► **"What exactly did you promise?"** — **MERRICK:** "'A thing I will not miss.' I thought it meant a coin."
> ► **"Can bargains be broken?"** — **MERRICK:** "Not broken. *Argued.*"
> ► **"I'll look into it."** — **MERRICK:** "Quietly. The thorns listen."

**Scene 2: the fine print.** At the Edge Stones, a bored thorn-clerk with a face like a hedge produces a ledger and reads the clause aloud.

**CLERK:** "'*A thing he will not miss.* Fulfilled. He does not miss it. He has forgotten what it sounded like.'"
**CLERK:** "A bargain is satisfied by the *giving.* It is not undone by the *regret.*"
> ► **"Can he buy it back?"** — **CLERK:** "Anything may be bought. At a fair price."
> ► **"What is a fair price?"** — **CLERK:** "A thing he *would* miss."
> ► **"Can another pay?"** — **CLERK:** "...An interesting question."

**Scene 3: the price.** The clerk names the price: *a thing he would miss, given freely.* Merrick considers his tools, his father's axe, his house. Then his wife, who has come silently to stand beside him, signs with a flourish.

**WIFE (in sign-speech, translated by the player):** "She says: *Her voice for his hearing. But only on Sundays.*"
**CLERK:** "...Half a bargain. Interesting."
> ► **(Accept the half.)** — The clerk nods.
> ► **(Argue for the whole.)** — The thorns rustle.
> ► **(Offer yourself in her place.)** — **CLERK:** "You are not party to the contract."

**Scene 4: the Sunday.** On the first Sunday, Merrick sits at supper. His wife, speaking aloud, laughs at a joke he has told a hundred times. He hears it.

**MERRICK:** "...Oh."
**MERRICK:** "I'd forgotten it was that *bright.*"
*She does not speak again until the following Sunday, and the house is full of other sounds.*

**Coda: the Sunday supper.** The following month Merrick invites the player to supper, on a Sunday, and sets an extra plate without being asked.

**MERRICK:** "I thought I would resent the six days. I do not. She writes me notes. They are better than speech."
**MERRICK:** "On Sundays she tells me everything she thought during the week. It takes the whole afternoon."
> ► **"It sounds like a fair price."** — **MERRICK:** "It sounds like a good marriage, to be honest."
> ► **"The thorns will remember."** — **MERRICK:** "Let them. I have a ledger line that says *paid.*"

**Outcomes and receipt.**
- A tithe-and-trade: Merrick hears her laugh on Sundays, at the cost of her voice on the other six days. The Briar King is not confronted. If the player argued for the whole, the thorns close their ledger for a season and nothing is changed.
- **Receipt:** a small bell on the cooperage door that rings only on Sundays; a ledger line, *"Paid in kind."*

<!-- quest
id: qst_evd_bargain_break
title: The Bargain That Would Not Break
rank: A
type: Investigation
giver: npc_cooper_merrick_reedmarsh
region: reg_everdusk
level: 130
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: evd_bargain_done
summary: A barrel-maker bargained with the Briar King's thorns for his wife's life and lost the ability to hear her laugh. He wants it back.
objectives:
  talk npc_cooper_merrick_reedmarsh
  reach everdusk_edge_stones_ledger
  choice half_whole_or_self
-->

---

## 4. A Debt of Thanks

*A · OddJob · the forest edge · giver Mother Isolt Hazelmere*

**The short version.** Isolt's youngest, a boy of seven, was handed a loaf of bread by a fey and, without thinking, said "thank you." He has been quiet ever since. Thanks are debts, and he owes one.

**What is really going on.** A thank-you is a debt of *the same size as the gift.* The fey who gave the bread is not a villain; she is a small, bored hedge-sprite who has never been thanked. She does not know what she is owed. The player must help the boy settle the debt before it is *named.*

**Scene 1: the kitchen.**

**ISOLT:** "He came home with bread in his hand and fear on his face."
**ISOLT:** "He said it. In front of her. *Thank you.* He has not spoken since."
**ISOLT:** "She has not named the debt. Not yet. Once she does, it is hers."
> ► **"What does the debt cost?"** — **ISOLT:** "Whatever she thinks a loaf is worth."
> ► **"Is she cruel?"** — **ISOLT:** "She is *bored.* It's worse."
> ► **"Where is she?"** — **ISOLT:** "The old hedge by the mill."

**Scene 2: the hedge.** At a hedge as thick as a wall, the player waits until a small, brown, leaf-haired sprite steps out, holding the half-eaten loaf.

**SPRITE:** "He said *thank you.* No one has ever said that to me."
**SPRITE:** "It is the loveliest word. I want to say it too. May I?"
**SPRITE:** "What does one owe for a word like that?"
> ► **"Nothing. It was a mistake."** — **SPRITE:** "A mistake? It was a *gift.*"
> ► **"A loaf, in return."** — **SPRITE:** "Oh, that is fair. And dull."
> ► **"What would you like?"** — **SPRITE:** "...To say it back. Once."

**Scene 3: the exchange.** The sprite, trembling, explains: fey cannot say thank you, but they can *receive* one, and they want to know what it feels like to give it. The boy, brought to the hedge in his mother's arms, listens in silence.

**SPRITE (to the boy):** "I cannot say it. But I can... *show* it. If you let me."
*She takes the loaf, tears it in half, and hands him the larger piece with a small, shy bow.*
> ► **(Let the boy decide.)** — He holds out his hand.
> ► **(Tell the sprite to name a price.)** — She hesitates.
> ► **(Call the debt settled.)** — Court law agrees.

**Scene 4: the bread.** The boy takes the bread. He eats it. He does not say thank you. He looks the sprite in the eye, nods once, and gives her a button from his sleeve.

**SPRITE:** "...That is the nicest thing."
**SPRITE:** "I will keep it for ever."
*The boy says one word, his first in a week: "Friend."*

**Coda: the button.** Back at the Hazelmere cottage, Isolt kneels in front of her son and tries not to cry in front of him.

**ISOLT:** "You gave her a *button.*"
**BOY:** "It was my second-best."
**ISOLT:** "That is exactly the right price."
*From the hedge by the mill, a small brown figure watches the window, one hand cupped around something shiny.*
> ► **"He'll be all right."** — **ISOLT:** "He said *friend.* I would have given her the house."
> ► **"What will you tell the neighbours?"** — **ISOLT:** "That the boy has manners, and the hedge has a friend."

**Outcomes and receipt.**
- The debt is settled in kind; the boy speaks again. If the player named a price, the sprite wanted a year of the boy's laughter and was talked down to a week.
- **Receipt:** a loaf left each morning on the Hazelmere sill; a button on the hedge, sewn in with thread.

<!-- quest
id: qst_evd_debt_thanks
title: A Debt of Thanks
rank: A
type: OddJob
giver: npc_mother_isolt_hazelmere
region: reg_everdusk
level: 124
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: evd_debt_thanks_done
summary: A seven-year-old said thank you to a fey who gave him bread. Thanks are debts, and she hasn't named the price.
objectives:
  talk npc_mother_isolt_hazelmere
  reach everdusk_old_hedge
  choice mistake_loaf_or_ask
-->

---

## 5. The Edge Stones Are Walking

*A · Exploration · the forest edge · giver Edge-keeper Tamsen Mossback*

**The short version.** The stones at the forest's edge, where offerings are left, are moving inward a hand's breadth a week. Tamsen has kept them thirty years. She wants to know where they are going before the villages lose their only line of communication with the fey.

**What is really going on.** The stones are not being moved by the Briar King. They are *following the offerings.* The Summer Court, which cannot reach the edge past the thorns, has been quietly pulling the stones toward the last glade, so offerings can still reach it. The player must find where the stones end.

**Scene 1: the circle.**

**TAMSEN:** "Thirty years. A ring of nine. Now seven are inside the line."
**TAMSEN:** "I left a bowl of honey last night. This morning it was a dozen paces in, and the honey was gone."
**TAMSEN:** "Something is tugging."
> ► **"Is it the thorns?"** — **TAMSEN:** "The thorns would have taken the *stones.*"
> ► **"Can we follow?"** — **TAMSEN:** "That's why I called you."
> ► **"Where do they end?"** — **TAMSEN:** "I do not know. I would like to."

**Scene 2: the trail.** Along a path of flattened bracken, stone by stone, the player follows a pale, shifting line deeper into the dusk. The trees lean closer. Somewhere ahead, a quiet music plays.

*(Gameplay: a quiet trail-following exploration; the paths change as the player walks.)*

**JOURNAL (auto):** *The stones are warm. They are being drawn along, like children by the hand.*

**Scene 3: the hands.** At the end of the trail, a ring of small fey children, no taller than a knee, stand in a circle around the ninth stone, hauling it forward on ropes of braided grass.

**CHILD:** "Shh! We're not supposed to be seen."
**CHILD:** "The Lady says the offerings must still reach us. The edge is too far. So we pull the *edge.*"
> ► **"That's clever."** — **CHILD:** "We know."
> ► **"The village will worry."** — **CHILD:** "We didn't think of that."
> ► **"Can I help?"** — **CHILD:** "Only if you don't say *thank you.*"

**Scene 4: the new edge.** The player helps haul the last stone to the Last Glade's border, where it settles with a quiet clink. At the village, Tamsen builds a new ring, nine stones, a few paces closer. The honey is accepted.

*In the village, a few of the older folk come out to look at the new ring and are unsure whether to be pleased. A boy asks, loudly, why the stones are grinning. Tamsen tells him it is only the way the moss grows, and does not look at the player.*
**TAMSEN:** "They're not moving any more."
**TAMSEN:** "They are exactly where they need to be."
*The honey bowl, in the morning, is empty and rinsed.*

**Coda: the honey bowl.** On the first evening of the new ring, Tamsen asks the player to help carry the honey out. They set it on the ninth stone together.

**TAMSEN:** "In thirty years I have never watched it taken."
**TAMSEN:** "Tonight, I think I will."
*They sit at the edge of the dusk, on the cold grass, and say nothing. After an hour, a small brown hand reaches out of the bracken, takes the bowl, and withdraws. A moment later it returns, rinsed, with a single wild strawberry in it.*
> ► **"Do we eat it?"** — **TAMSEN:** "Twice offered. Yes. Quietly."

**Outcomes and receipt.**
- The offerings reach the Last Glade; the villages keep their link to the Summer Court. If the player told Tamsen the stones were being hauled by children, she laughs for a full minute.
- **Receipt:** a ring of nine stones, one nearer than the others, wearing a small knot of braided grass.

<!-- quest
id: qst_evd_edge_stones
title: The Edge Stones Are Walking
rank: A
type: Exploration
giver: npc_edge_keeper_tamsen_mossback
region: reg_everdusk
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: evd_edge_stones_done
summary: The offering stones at the forest's edge are creeping inward a hand's breadth a week. The keeper wants to know where they are going.
objectives:
  talk npc_edge_keeper_tamsen_mossback
  reach everdusk_ninth_stone
  choice clever_worry_or_help
-->

---

## 6. The Child Who Came Back

*A · Hidden · the forest edge · giver Nissa Underbough*

**The short version.** A generation ago, a child was stolen from the forest's edge and returned as an adult, with no memory of where she had been. Nissa is that woman. She has lived forty years with a hole in her. She asks the player to help her ask the forest one question.

**What is really going on.** Nissa does not want her memory back; she wants to know whether she *should.* The fey who took her are not cruel, and not apologetic. The player's role is to help her ask, politely, in a way that binds nothing. **The quest does not answer where she was.** It answers only whether she gets to choose.

**Scene 1: the cottage.**

**NISSA:** "I was nine when I went. I was forty-nine when I came back. At least, my body was. My mind was nine."
**NISSA:** "They say I walked out of the trees one dawn with a basket of apples. The apples were still warm."
**NISSA:** "I have never asked. I have always been afraid of the answer."
> ► **"Why now?"** — **NISSA:** "Because I have a daughter who is nine."
> ► **"What do you fear?"** — **NISSA:** "That it was *wonderful.*"
> ► **"I'll go with you."** — **NISSA:** "Thank you. No. I mean: *noted.*"

**Scene 2: the Hour That Isn't.** In a glade where the light holds still, a tall, patient fey lady receives them. She is not the one who took Nissa; she is the one who keeps the book.

**LADY:** "Every guest who leaves leaves with something. Every guest who stays leaves something. You left a memory."
**LADY:** "It is not lost. It is kept. It is, in fact, rather well-tended."
**LADY:** "Would you like it back?"
> ► **"What does it cost?"** — **LADY:** "Nothing. It is yours."
> ► **"What happens if she takes it?"** — **LADY:** "She will remember. All of it."
> ► **"What happens if she doesn't?"** — **LADY:** "Nothing at all. It will wait."

**Scene 3: the question.** Nissa sits very still. The lady waits, her hands folded.

**NISSA:** "If I take it back, will I still be... *here?*"
**LADY:** "That is not a question I can answer. It is your question."
> ► **"Ask for one hour of it."** — **LADY:** "That is allowed."
> ► **"Ask for none."** — **LADY:** "That, too."
> ► **"Ask for it all."** — **LADY:** "Courage is not always wise. But it is allowed."

**Scene 4: the choice.** Whichever Nissa chooses (and the player's advice does not decide it), the lady closes the book. If an hour: Nissa laughs, once, a young delighted sound, and weeps. If none: she nods and walks home in the dusk, lighter. If all: she is silent for three days and does not say what she saw.

**NISSA (afterwards):** "I wanted to know I could choose."
**NISSA:** "That was the whole thing."

**Coda: the apples.** In the autumn, Nissa sends word to the player, by way of a farm-boy who has no idea what he is carrying: a small basket of apples, still warm.

**NISSA (in a note):** "I chose. I will not tell you what. It was mine to choose and I am glad I did."
**NISSA:** "My daughter asked me what the forest is like. I said: *polite.* She said that sounded boring. I said: *it is not.*"
> ► **(Eat one.)** — It tastes of orchards that do not exist.
> ► **(Keep them.)** — They stay warm for a very long time.

**Outcomes and receipt.**
- Nissa makes her choice, and it is hers. **The quest does not say where she was, who took her or why.** The forest does not apologise.
- **Receipt:** a small basket of apples, still warm, left at her door each autumn; her daughter, nine, who asks her one question and gets one answer.
- **Unexplained seed:** the lady and her book. Whether other returned children are kept there is left open.

<!-- quest
id: qst_evd_child_came_back
title: The Child Who Came Back
rank: A
type: Hidden
giver: npc_nissa_underbough
region: reg_everdusk
level: 134
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: evd_child_back_done
summary: A woman who was stolen as a child and returned with no memory wants to ask the forest whether she should have it back.
objectives:
  talk npc_nissa_underbough
  reach everdusk_hour_that_isnt
  choice hour_none_or_all
-->

---

## 7. Paths That Remember

*S · Exploration · the shifting paths · giver Pathwarden Sorcha Hawthornwake*

**The short version.** In Everdusk, paths change depending on who walks them. Sorcha has found a path that remembers a walker who was not there, one that bends where no one has been. She wants it followed to its end.

**What is really going on.** The path is the old line of the **treaty** that divided the forest in two in the grandparents' time. It remembers the walkers who laid it. One of them left a clause unsigned. **What the clause says is not revealed.** The player's task is to walk the path as each of the three walkers it remembers.

**Scene 1: the warden.**

**SORCHA:** "I have walked these paths a thousand years. They bend for me. They bend for you. For *her,* they did not."
**SORCHA:** "This path bends for someone who is not here."
**SORCHA:** "Walk it. I cannot. It does not know me."
> ► **"What is at the end?"** — **SORCHA:** "I do not know. I fear it is a door."
> ► **"Why me?"** — **SORCHA:** "Because you are a stranger. Paths are fond of strangers."
> ► **"I'll walk it."** — **SORCHA:** "Do not say your name. Not even to the moss."

**Scene 2: the first walker.** The path unfolds in silver, and as the player steps, the forest changes: the trees are younger, the light is whiter, and the player walks with a limp that is not theirs. A soft voice hums a song the player has never heard.

**VOICE (a gentle, old fey):** "We agreed on the glades. We agreed on the rivers. We agreed on the hours. That leaves the clause."
> ► **(Follow the voice.)** — The path steadies.
> ► **(Ask the voice a question.)** — It does not answer.
> ► **(Stay still.)** — The path waits.

**Scene 3: the second walker.** The path bends. The air is colder. The player walks as someone angry and old, with a thorn at the heel.

**SECOND VOICE (a hard, winter voice):** "I will sign the rest. I will not sign that."
**FIRST VOICE:** "Then we leave it open."
**SECOND VOICE:** "Open is how wars start."
**FIRST VOICE:** "Open is how they *end.*"

**Scene 4: the third walker.** At the end of the path, in a clearing where the light does not move, a small stone sits with an unwritten line below the treaty's text. The third walker was a mortal child, the player knows, though the voice is silent. A hand, small and warm, rests briefly on the player's shoulder.

*On the stone, beneath the carved clauses, a blank space the width of a sentence.*
> ► **(Write nothing.)** — The stone stays blank.
> ► **(Trace the space with a finger.)** — It warms, and then cools.
> ► **(Leave a mark of your own.)** — The path bends toward you, gently, once.

**SORCHA:** "You walked it."
**SORCHA:** "And you did not sign."
**SORCHA:** "Good. Whatever it is, it is not yet ours to write."

**Coda: the thread.** Sorcha walks the player to the forest's edge, where the silver thread on their wrist trembles faintly toward the treaty-stone.

**SORCHA:** "You may walk it again. It will not bend for you every time. Paths are fickle."
**SORCHA:** "But it will remember you were there."
**SORCHA:** "I have not been remembered by a path in a thousand years. I find I am jealous."
> ► **"Walk it with me, next time."** — **SORCHA:** "It will not know me. But I shall try."
> ► **"What do you think the clause says?"** — **SORCHA:** "I think it says *to be continued.* I have no evidence."

**Outcomes and receipt.**
- The path is walked and the treaty-stone found. **The unsigned clause and the mortal child are not explained.** If the player left a mark, the path remembers the player, and bends for them for the rest of the forest.
- **Receipt:** a silver thread on the player's wrist that leads, faintly, back to the stone; a line in Sorcha's ledger: *"A walker who did not sign."*
- **Unexplained seed:** the unsigned clause and its mortal witness. Do not resolve without Canon approval.

<!-- quest
id: qst_evd_paths_remember
title: Paths That Remember
rank: S
type: Exploration
giver: npc_pathwarden_sorcha_hawthornwake
region: reg_everdusk
level: 166
act: 5
requires_rank: S
reward: 66000 | 2900 | 305000
sets: evd_paths_done
summary: A path bends for a walker who is not there. It follows the old treaty line that divided the forest, and it ends at an unsigned clause.
objectives:
  talk npc_pathwarden_sorcha_hawthornwake
  reach everdusk_treaty_stone
  choice nothing_trace_or_mark
-->

---

## 8. A Courtier of the Winter Court

*S · Escort · the Winter and Summer borders · giver Courtier Ysmere Rimeglass*

**The short version.** Ysmere belongs to the Winter Court. Years ago, she spent a long afternoon with a Summer poet, Aelwyn. Aelwyn is dying in the Last Glade. Ysmere cannot cross the border without being noticed, and cannot ask. She asks a mortal to escort her.

**What is really going on.** A Winter courtier at the Last Glade is, politically, an act of war. The thorns will see. The Summer Court may refuse her. Ysmere does not care. The quest asks the player to get her there, quietly, without hurting anyone and without forcing the border.

**Scene 1: the cold hall.**

**YSMERE:** "We are not permitted to grieve for them. It is *unseemly.*"
**YSMERE:** "I am going to anyway."
**YSMERE:** "I cannot go as a courtier. I will go as your servant, if you will have me."
> ► **"Why trust me?"** — **YSMERE:** "Because you are the only person in the forest I have not lied to."
> ► **"What will the thorns do?"** — **YSMERE:** "They will talk. It's what they do."
> ► **"I'll take you."** — **YSMERE:** "Do not say thank you. I shall not say it either."

**Scene 2: the way.** Three ways lie before them: through the thorns, round by the silver river, or by an old hunters' road that crosses the border at a ford.

> ► **(Through the thorns.)** — Fast and watched.
> ► **(By the river.)** — Slow, quiet and cold.
> ► **(By the ford.)** — Legal, if barely.

*(Gameplay: a quiet stealth and negotiation journey; Winter sentries can be bargained with, not fought.)*

**SENTRY:** "A Winter courtier at the border. In a mortal's cloak."
**YSMERE:** "I am the mortal's servant."
**SENTRY:** "You are the worst servant I have ever seen."
**YSMERE:** "I have never done it before."

**Scene 3: the border.** At the ford, a Summer guard bars the way with a spear of pale wood.

**GUARD:** "No Winter under this bough."
**YSMERE:** "I am not here as Winter."
**GUARD:** "What are you here as?"
**YSMERE (very quietly):** "A friend."
> ► **"She means it."** — The guard hesitates.
> ► **"Let her through. I will vouch."** — **GUARD:** "Your word binds you."
> ► **(Offer a gift for passage.)** — The guard laughs, a short bark.

**Scene 4: the Last Glade.** In a ring of golden light, ringed by thorns, a thin, silver-haired fey lies on a couch of moss. Her eyes are open. She smiles at the sight of the cold courtier.

**AELWYN:** "You came."
**YSMERE:** "I did."
**AELWYN:** "Winter never comes."
**YSMERE:** "No. But I am very bad at being Winter."
*They sit together. The player withdraws to the border of the glade. The thorns, for a moment, do not close.*

**Coda: the rose.** Ysmere returns to Winter before the next dusk. At the border, she turns.

**YSMERE:** "I shall be asked where I have been."
**YSMERE:** "I shall say: *walking.* It will be, in some sense, the truth."
**YSMERE:** "You have my... I cannot say it. But you have what I would say, if I could."
> ► **"I know."** — **YSMERE:** "Good. It is a very small word and I am glad of it."
> ► **"Will you come again?"** — **YSMERE:** "If I can. If Winter forgets to look."
*She crosses back into the cold. The thorns part for her, and part again, and do not close behind.*

**Outcomes and receipt.**
- Ysmere reaches her friend; Aelwyn dies the following morning, in her arms. The border is not breached, no war is declared and the Briar King does not respond. If the player forced the thorns, the passage is faster but the thorns remember Ysmere's face.
- **Receipt:** a pressed winter-rose in the Last Glade's poetry-book, beside a golden leaf; Ysmere stays one night, and returns to Winter in the morning, changed.

<!-- quest
id: qst_evd_winter_courtier
title: A Courtier of the Winter Court
rank: S
type: Escort
giver: npc_courtier_ysmere_rimeglass
region: reg_everdusk
level: 170
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: evd_courtier_done
summary: A Winter courtier wants to reach the Last Glade to be with a dying Summer friend. It is, politically, an act of war.
objectives:
  talk npc_courtier_ysmere_rimeglass
  escort npc_courtier_ysmere_rimeglass
  reach everdusk_last_glade_couch
  choice thorns_river_or_ford
-->

---

## 9. Day or Night

*S · Investigation · the forest edge · giver Elowen Briarlight*

**The short version.** Elowen, nine, has been told that the courts made the dusk to settle an argument about whether it is day or night. She has asked a simple question: *Who won?* Nobody in the forest, mortal or fey, has ever said.

**What is really going on.** The argument is **not resolved,** and the player does not resolve it. Elowen asks the player to carry her question to both courts, and to bring back whatever they say. The answers are the point: each court has an honest, partial reply, and each is proud of it.

**Scene 1: the doorstep.**

**ELOWEN:** "My teacher says the courts made the dusk because they couldn't agree."
**ELOWEN:** "I want to know who was right."
**ELOWEN:** "I tried asking a sprite. She said *'Politely, no.'*"
> ► **"That's a hard question."** — **ELOWEN:** "That's why I asked a grown-up."
> ► **"Why does it matter?"** — **ELOWEN:** "Because I want to know if I'm supposed to be sleepy."
> ► **"I'll ask."** — **ELOWEN:** "Write down what they say. *Exactly.*"

**Scene 2: the Summer reply.** At the Last Glade's border, a courtier of the Summer Court, golden and tired, listens to the question with great seriousness.

**COURTIER:** "It was day. It was always day. We made the dusk because the *Winter Court* insisted it was night, and a compromise was needed."
**COURTIER:** "Tell the child we were right. Tell her, kindly."
> ► **(Write it exactly.)** — You do.
> ► **(Ask if they're sure.)** — **COURTIER:** "Of course. We were there."
> ► **(Ask what it felt like.)** — **COURTIER:** "...Warm."

**Scene 3: the Winter reply.** At the edge of the thorns, a Winter courtier, pale, sharp and amused, listens.

**COURTIER:** "It was night. It was always night. We made the dusk because the *Summer Court* insisted on day, and a compromise was needed."
**COURTIER:** "Tell the child we were right. Do not be kind."
> ► **(Write it exactly.)** — You do.
> ► **(Ask if they're sure.)** — **COURTIER:** "Of course. We were there."
> ► **(Ask what it felt like.)** — **COURTIER:** "...Quiet."

**Scene 4: the return.** The player reads both replies to Elowen on her step. She considers them for a long time, chin on knees.

**ELOWEN:** "They both say they were right."
**ELOWEN:** "And they both say they were there."
**ELOWEN:** "So maybe it was both. And it's just that *nobody was looking at the other one.*"
> ► **"Maybe."** — **ELOWEN:** "I'll write that down."
> ► **"That's a very good answer."** — **ELOWEN:** "It's a *guess.*"
> ► **"Don't tell them."** — **ELOWEN:** "I'm going to tell them *both.*"

**Coda: the two drawings.** Elowen pins her drawing to the door, a sky half gold, half deep blue, a line of grey between.

**ELOWEN:** "My teacher says that isn't how the sky works."
**ELOWEN:** "I said: *this one does.*"
> ► **"It's a good sky."** — **ELOWEN:** "It's the one we've got."
> ► **"Will you ask them again?"** — **ELOWEN:** "When I'm older. When they've had time to think."
*A sprite on the roof, who has been listening for some time, gently nudges the drawing straight.*

**Outcomes and receipt.**
- Elowen has two answers and a third of her own. **The quest does not say who was right.** If the player embroidered either reply, Elowen catches it and asks for the original.
- **Receipt:** a child's drawing of a half-and-half sky pinned in the Last Glade; a second, pinned at the Thorn Throne's gate by a Winter sentry who will not say who put it there.
- **Unexplained seed:** whether the dusk was ever a compromise, or something else.

<!-- quest
id: qst_evd_day_or_night
title: Day or Night
rank: S
type: Investigation
giver: npc_elowen_briarlight
region: reg_everdusk
level: 174
act: 5
requires_rank: S
reward: 73000 | 3150 | 335000
sets: evd_day_night_done
summary: A nine-year-old asks the one question about the dusk nobody has answered: who won the argument. She wants both courts' replies, exactly.
objectives:
  talk npc_elowen_briarlight
  reach everdusk_summer_and_winter_edges
  choice exact_sure_or_felt
-->

---

## 10. A Guest at the Last Glade

*S · OddJob · the Last Glade · giver Lady Calanthe Evenfall*

**The short version.** The Summer Court is holding a feast in its last glade, and has done something unthinkable: it has invited a mortal as its *guest of honour.* Lady Calanthe asks the player to attend. The rules of guesting are strict, and the fey are watching.

**What is really going on.** The feast is not a trap. It is the court's way of saying *we are still here.* A guest of honour must follow nine rules: no thanks, no names, no refusals, no leaving early, no lies, no shortcuts, no iron, no sleep, and no grief. The last is the hardest, because the Summer Court is grieving, and will ask the player to help it pretend it is not.

**Scene 1: the invitation.**

**CALANTHE:** "We have not held a feast in fifty years. We have forgotten how."
**CALANTHE:** "You will be our guest. You will eat what is offered, twice. You will say what is true, and nothing else."
**CALANTHE:** "You will not grieve. That would be unmannerly."
> ► **"Why me?"** — **CALANTHE:** "Because you are not afraid of us. It is a rare quality."
> ► **"What is the feast for?"** — **CALANTHE:** "To prove we exist."
> ► **"I'll come."** — **CALANTHE:** "Good. Wear something that will not frighten the moths."

**Scene 2: the table.** Under a ring of floating lanterns, the Summer Court's last two hundred nobles sit at a long table of woven roots. They are beautiful, thin and bright-eyed. Behind them, the thorns lean closer.

**NOBLE (to the player):** "Tell me something true."
**YOU:** "I'm afraid of heights."
**NOBLE:** "That is a good truth. Another."
*(Gameplay: a dialogue-rule puzzle; each answer must be true, and none may contain thanks or a name.)*
> ► **(Tell a small truth.)** — Applause, polite.
> ► **(Tell a hard truth.)** — A silence, then warmth.
> ► **(Ask them a truth in return.)** — The table brightens.

**Scene 3: the last rule.** Late in the night, an old courtier, with moth-wing hair, lets her smile slip.

**OLD COURTIER:** "Eleven glades. Gone. I was born in the fourth."
**OLD COURTIER:** "I am not grieving. I am *noticing.*"
**OLD COURTIER:** "Tell me you do not think me rude."
> ► **"You are not rude."** — She nods, grateful but unthanking.
> ► **"You may grieve. I won't tell."** — **OLD COURTIER:** "...That is a lie of the kindest sort."
> ► **"Tell me about the fourth glade."** — She does, for an hour.

**Scene 4: the toast.** At the dawn that is not a dawn, Calanthe raises a cup.

**CALANTHE:** "To the Last Glade. May it be the last of its kind. And may it be, by some courtesy, not the last."
*The table drinks. The thorns, a moment, hold still.*

**Coda: the place laid.** At the end of the feast, Calanthe walks the player to the glade's edge, past the leaning thorns.

**CALANTHE:** "We have laid a place at the table. It will stay laid. It is not a debt."
**CALANTHE:** "It is a... what do mortals call it? A *standing invitation.*"
**CALANTHE:** "I am told it is the opposite of a bargain."
> ► **"I'll come when I can."** — **CALANTHE:** "That is not a promise. It is better."
> ► **"The thorns are closer."** — **CALANTHE:** "Yes. Let them be. We have a feast to remember."

**Outcomes and receipt.**
- The feast is held. The Summer Court is still afraid, still ringed with thorns and still short of champions, but for one night it is also a court. If the player broke a rule (a thanks, a name), the court forgives it publicly and counts it privately.
- **Receipt:** a golden leaf pressed in the player's journal that smells of honey; a place laid at the Last Glade's table for the player, always.
- The thorns remain; the war is **not** resolved.

<!-- quest
id: qst_evd_last_glade_guest
title: A Guest at the Last Glade
rank: S
type: OddJob
giver: npc_lady_calanthe_evenfall
region: reg_everdusk
level: 180
act: 5
requires_rank: S
reward: 78000 | 3350 | 350000
sets: evd_last_glade_guest_done
summary: The Summer Court holds a feast in its last glade and invites a mortal as guest of honour. The rules of guesting are strict, and grief is forbidden.
objectives:
  talk npc_lady_calanthe_evenfall
  reach everdusk_last_glade_table
  choice small_hard_or_ask
-->
