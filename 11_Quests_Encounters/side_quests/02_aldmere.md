# 11e-02 — Aldmere, the Crown Valley: Ten Side Quests (draft)

> *"Every farm along the valley has a sword buried under its doorstep, and every family has its own story about why."*
> — Gazetteer, Aldmere

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 9 proposes a backstory for Ashgrave, the Oathless Baron.

**Region:** `reg_aldmere` (the Royal Valley farms, Ashby, Greyhollow Village, Aldmere City). **Rank band:** E–C. **Tone:** pastoral at the edges, political at the centre, and with a dead army walking the road at night.

**Placement notes.**
- The Greyhollow dead march out under **Ashgrave's** banner. The siege is a *region state*; none of these quests kills Ashgrave or ends the siege (that is his Tyrant fight). Quests 2, 7 and 10 change how people *understand* the dead, not whether the siege exists.
- Aldmere City is the safest large place in the world by day. Court quests (8, 9) assume the council of crown, Church and Guild that Canon already names.
- Do not treat the quests as a chain. Each stands alone; 7 and 10 share a thread and play best in that order.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Sword Under Every Doorstep | E | Investigation | Calla Reeve | Family secret, quietly eerie |
| 2 | The Ring in the Barrow | E | Exploration | Ysolt Marne | Romance, with the dead as hosts |
| 3 | The River Toll Quarrel | E | Faction | Hatty Swan | Politics from the bottom up |
| 4 | The Wheel Thief of Eastgate | E | Investigation | Maud Axle | A caper that ends in a race |
| 5 | The Plough Finds a Ledger | D | Investigation | Rook Tull | Old hunger, restitution |
| 6 | The Friend in the Mirror | D | Investigation | Edda Pryor | Gentle horror, loneliness |
| 7 | Stand Down, Soldier | D | Faction | Agna Dunmoor | A ritual of rest |
| 8 | The Duelist's Last Request | C | Hidden | Bertram Colt | Honourable losing |
| 9 | The King Wants to Go Fishing | C | Escort | Osric Finch | A quiet rebellion |
| 10 | What the Baron Refused | C | Investigation | Archivist Orrow | The dead have a reason |

## Cast (new supporting NPCs)

<!-- npc
id: npc_calla_reeve
name: Calla Reeve
tier: townsfolk
race: Human
region: reg_aldmere
settlement: Royal Valley farms
role: Farmer, last of the Reeve line
backstory: A stubborn twenty-six-year-old who has just inherited the family farm and has found the sword under the doorstep that her family has never talked about.
secret: She has been leaving a cup of milk by the barrow road every night for a year and doesn't know why.
-->
<!-- npc
id: npc_ysolt_marne
name: Ysolt Marne
tier: townsfolk
race: Human
region: reg_aldmere
settlement: Ashby
role: Bride-to-be, baker
backstory: A cheerful, furious baker whose fiancé has gone missing the night before their wedding with a stolen shovel and a loaf of her best bread.
-->
<!-- npc
id: npc_hatty_swan
name: Hatty Swan
tier: major
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Bargewoman, river-guild speaker
backstory: A short, loud bargewoman who speaks for the river guild and has been fined for shouting at three different nobles in one week.
-->
<!-- npc
id: npc_maud_axle
name: Maud Axle
tier: townsfolk
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Cartwright, Eastgate
backstory: A cheerful cartwright of Eastgate who has had eleven wheels disappear from her yard in a week and is deciding whether to be angry or impressed.
-->
<!-- npc
id: npc_rook_tull
name: Rook Tull
tier: townsfolk
race: Human
region: reg_aldmere
settlement: Royal Valley farms
role: Farmhand
backstory: A quiet, wiry farmhand whose plough turned up a rotted strongbox, and who is not sure whether finding it is a blessing or a trap.
-->
<!-- npc
id: npc_edda_pryor
name: Edda Pryor
tier: major
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Matron, Candle Street orphanage
backstory: A tired, kind matron who has run the Candle Street orphanage for thirty years and has never before been afraid of one of her own children's nightmares.
-->
<!-- npc
id: npc_agna_dunmoor
name: Sister Agna Dunmoor
tier: major
race: Human
region: reg_aldmere
settlement: Greyhollow Village
role: Morrowyn's lantern-keeper, Greyhollow
backstory: A blunt, tireless lantern-keeper of Morrowyn who has buried the Greyhollow dead four times over and is tired of burying them again.
-->
<!-- npc
id: npc_bertram_colt
name: Ser Bertram Colt
tier: major
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Retired tournament duelist
backstory: A retired duelist of seventy who once won the Gentle Lance three years running, and who has never told his granddaughter that the third win was a gift.
-->
<!-- npc
id: npc_osric_finch
name: Osric Finch
tier: major
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Royal valet
backstory: A calm, long-suffering royal valet who has served three kings and has never once been asked what he thinks.
secret: He has been secretly loyal to the king, not to the Crown, for twenty years.
-->

---

## 1. A Sword Under Every Doorstep

*E · Investigation · Royal Valley farms · giver Calla Reeve*

**The short version.** Calla has inherited a farm and, under the doorstep, a sword nobody in her family will explain. Her neighbours all have swords under their steps, too. None of them will say why.

**What is really going on.** Each sword is a *truce token*. During the three wars, soldiers from the Greyhollow barrow company were quartered on the valley farms. The families who sheltered them buried a sword under the door as a pledge: *"we kept your soldiers; keep our farm."* The dead remember. The Reeve doorstep sword is the reason the Reeve farm has never been attacked at night.

**Scene 1: the doorstep.**

**CALLA:** "Two months I've been in charge. Two months! And I find *this*."
*She holds up a rusted blade wrapped in oilcloth.*
**CALLA:** "Ma won't talk about it. Gran said: 'Put it back.' That's all! 'Put it back.'"
**CALLA:** "I want to know why. And I want to know before I decide whether to put it back."
> ► **"Ask the neighbours."** — **CALLA:** "I did. They shut their doors."
> ► **"Where was it buried?"** — **CALLA:** "Right under the step. Wrapped in a cloth. And there was a... cup. A little clay cup."
> ► **"Put it back."** — **CALLA:** "Not until I *know*."

**Scene 2: the neighbours.** Three farms, three reactions. At the **Marlowe farm**, an old woman grips her broom; at the **Pell farm**, a boy peeks through a gap in the door; at the **Dunsby farm**, the farmer says only:

**DUNSBY:** "We don't talk about the swords. Not in daylight."
**DUNSBY:** "Come back after dark. Bring a lantern. Stay on the road."

**Scene 3: the road at night.** Along the barrow road, skeletal soldiers march in a slow column toward the west, ignoring the farms. At the Reeve gate the column *bends*: the lead soldier stops, salutes the doorstep, and steps around.

**CALLA:** (whisper) "Did you see that? He *saluted*."
**SERGEANT (skeleton):** *(hollow, formal)* "House of Reeve. Quartered. Fed. Shelter given. The count is... paid."
> ► **"Who are you?"** — **SERGEANT:** "Ashgrave's company. We keep the old terms."
> ► **"Are you hostile?"** — **SERGEANT:** "To looters. To the oathless. Not to a house with a sword on its step."
> ► **"What do you want?"** — **SERGEANT:** "The sword under the step. Do not remove it. It is... the only door we know."

**Scene 4: the choice.** Back at the farm, Calla holds the sword.

**CALLA:** "So that's it. It's a treaty. My great-grandfather made a *treaty* with a dead army, and nobody told me."
> ► **"Put it back."** — **CALLA:** "...Right. I'll keep the cup full."
> ► **"Take it to the Church."** — **CALLA:** "Then the dead lose their door. And the next family. And the next."
> ► **"Tell the valley."** — **CALLA:** "They know. They just don't say it."

**Outcomes and receipt.**
- In every branch Calla learns the truth. *Put it back* keeps the truce and gains a quiet ally; *Church* ends the Reeve farm's protection and sours Calla; *tell the valley* starts a quiet movement to name every sword.
- **Receipt:** a small clay cup of milk sits at the Reeve doorstep every night and is empty by dawn. Other farms leave one too.
- **Canon-safe:** the quest does not change Ashgrave's siege or his Tyrant fight.

<!-- quest
id: qst_ald_doorstep_sword
title: A Sword Under Every Doorstep
rank: E
type: Investigation
giver: npc_calla_reeve
region: reg_aldmere
level: 16
act: 1
requires_flags: rank_e_reached
reward: 300 | 22 | 1000
sets: ald_doorstep_resolved
summary: Calla has found a sword under her doorstep. Every farm in the valley has one. The barrow dead remember why.
objectives:
  talk npc_calla_reeve
  reach barrow_road_night
  choice put_back_church_or_tell
-->

---

## 2. The Ring in the Barrow

*E · Exploration · Ashby · giver Ysolt Marne*

**The short version.** The groom has vanished the night before his wedding, with a shovel and a loaf of bread. The bride suspects the barrows.

**What is really going on.** **Dane Marne** has gone into a Greyhollow barrow to recover his great-grandfather's wedding ring, buried with the old soldier. He wants to marry in it. He is also quite sure that if he *asks politely*, the dead will let him.

**Scene 1: the bakery.**

**YSOLT:** "He's gone. Dane's gone. Wedding's at noon. I've got *forty loaves* and a *groom-shaped hole*."
**YSOLT:** "He left a note. 'Gone to fetch Gran's ring. Back by dawn. Love you. Don't be cross.' *Don't be cross.* I'm going to be so cross."
> ► **"Where would he go?"** — **YSOLT:** "The barrow. There's only one barrow he'd be daft enough for."
> ► **"I'll find him."** — **YSOLT:** "Take this bread. He forgot it. He always forgets it."

**Scene 2: the barrow.** The mound is quiet. Skeleton guards stand in a ring and do not move. At the entrance, a shovel stuck upright in the earth, and a hand-lettered sign: *"I'M INSIDE. PLEASE DON'T MIND."*

**DANE:** *(from within)* "Hello! Is that Ysolt? I'm all right! They're being awfully reasonable!"
*You descend. Dane sits at a small table in the burial hall, drinking tea from a chipped cup, across from a skeletal captain in a rusted helm.*
**CAPTAIN:** "He asked. He *asked*. Nobody has asked in four hundred years."
**DANE:** "I said: 'Excuse me, sir, I'd like to borrow my great-grandfather's ring for a wedding.' And he said: 'Of course.'"
**CAPTAIN:** "...On one condition."

**Scene 3: the condition.** The captain wants the *bride* to attend. In person. Because he has not seen a wedding in four centuries.

**CAPTAIN:** "We kept the oath. We kept the farms. We did not keep... joy. We would like to see it."
**DANE:** "It's a lot to ask."
> ► **"I'll bring her."** — **CAPTAIN:** "Bring the bread. And music."
> ► **"This is a bad idea."** — **CAPTAIN:** "...It is."
> ► **"What if she refuses?"** — **DANE:** "She'll be cross. But she'll come."

**Scene 4: the wedding in the barrow.** At sundown, Ysolt arrives, furious, with a dress, a ribbon, and forty loaves. The dead stand in rows with their hands clasped. A skeletal piper plays three notes of a long-forgotten tune.

**YSOLT:** "You *idiot*."
**DANE:** "I know."
**YSOLT:** "You *beautiful* idiot."
*The captain removes his helm.*
**CAPTAIN:** "...Is it always like this?"
**YSOLT:** "Yes."

**Outcomes and receipt.**
- The wedding takes place in the barrow or, if the player prefers, in the Ashby chapel with the dead as guests outside the door. Either way the dead leave the bride a gift: a thin silver band.
- **Receipt:** the Greyhollow dead stop attacking Ashby *at the Marne house only*; a ring of candles is left on the barrow road every anniversary.

<!-- quest
id: qst_ald_ring_in_barrow
title: The Ring in the Barrow
rank: E
type: Exploration
giver: npc_ysolt_marne
region: reg_aldmere
level: 17
act: 1
requires_flags: rank_e_reached
reward: 300 | 22 | 1000
sets: ald_ring_resolved
summary: A groom has vanished the night before his wedding to ask a barrow's dead for his great-grandfather's ring. They said yes, on one condition.
objectives:
  reach greyhollow_barrow_hall
  talk npc_ysolt_marne
  choice chapel_or_barrow_wedding
-->

---

## 3. The River Toll Quarrel

*E · Faction · Aldmere City · giver Hatty Swan*

**The short version.** Two noble houses and the river guild have been arguing over a toll for forty years. Hatty Swan has decided today is the day it ends, and has hired you to stand beside her.

**What is really going on.** The toll is a distraction. Lord **Corvane** and Lady **Halloway** both want the *customs office*, which controls who sees what cargo. Hatty wants fair rates; what she does not know is that a third party is hoping the quarrel will go on forever.

**Scene 1: the quay.**

**HATTY:** "Stand there. Look dangerous. Don't say anything. If anyone asks, you're my *legal counsel*."
**HATTY:** "Forty years. FORTY. My father paid that toll, and his father, and what's it paid for? A bridge that falls down every spring and a lord who can't spell 'barge'!"
> ► **"Why me?"** — **HATTY:** "You look like someone who gets paid to stand there."
> ► **"What do you want?"** — **HATTY:** "A fair toll. One. Posted. On a board. Where anyone can *read* it."

**Scene 2: the council chamber.** A narrow room. Lord Corvane (fat, silk-wrapped) and Lady Halloway (thin, precise) sit at opposite ends. Between them, a clerk with a ledger.

**CORVANE:** "The river belongs to the crown. The toll is the crown's. I am the crown's *steward*."
**HALLOWAY:** "The river belongs to the valley. The toll is the valley's. I am the valley's *advocate*."
**HATTY:** "The river belongs to the *fish*, you posturing lumps."
*The clerk sighs.*
> ► **"Propose a joint board."** — Both lords are insulted; the clerk is intrigued.
> ► **"Ask to see the ledger."** — The clerk goes pale.
> ► **"Let Hatty speak."** — She does, at length.

**Scene 3: the ledger.** The player discovers that *neither lord has been paid the toll in three years*. The money has been going to a third account: the **Merchants' Consortium**'s Aldmere office.

**CLERK:** "I... was told not to say. The Consortium *prefers* the quarrel to continue. Every day of dispute, the toll is held in escrow. Escrow earns interest."
**HATTY:** "*Interest*? On MY toll?"
> ► **"Expose the Consortium."** — A major public scene; the Consortium retaliates mildly.
> ► **"Quietly settle."** — The lords agree privately; the Consortium keeps its cut.
> ► **"Use it as leverage."** — The player gets a favour from the clerk.

**Scene 4: the board.** On the quay, a new wooden board: *River Toll: 3 copper per barge, 1 per skiff, paid at the quay, receipted.* Hatty stands under it and cries a little.

**HATTY:** "Forty years. Forty... and it took a *board*."

**Outcomes and receipt.**
- *Expose:* the toll is fixed, the Consortium's Aldmere office is audited, and the player is publicly thanked. *Settle:* the toll is fixed, the Consortium escapes, and the clerk is quietly grateful. *Leverage:* the toll is fixed and the player earns a favour.
- **Receipt:** a toll board stands at the quay; river goods in Aldmere City are 5% cheaper (a bounded market modifier, per Canon §6 item economy rules).

<!-- quest
id: qst_ald_river_toll
title: The River Toll Quarrel
rank: E
type: Faction
giver: npc_hatty_swan
region: reg_aldmere
level: 18
act: 1
requires_flags: rank_e_reached
reward: 340 | 24 | 1100
sets: ald_toll_resolved
summary: Two noble houses and the river guild have argued over a toll for forty years. The ledger shows the money has been going somewhere else.
objectives:
  talk npc_hatty_swan
  reach aldmere_council_chamber
  choice expose_settle_or_leverage
-->

---

## 4. The Wheel Thief of Eastgate

*E · Investigation · Aldmere City · giver Maud Axle*

**The short version.** Eleven wheels have vanished from Maud's yard in a week. She wants the thief. She would also like to know how a thief carries eleven wheels.

**What is really going on.** The thief is a hedgehog-kin kid called **Nib**, nine, building a racer for the Eastgate Soapbox Derby. The derby's rules say *wheels must be hand-made*. Nib has no money and, apparently, no shame.

**Scene 1: the yard.**

**MAUD:** "Eleven. Eleven wheels. Oak, iron-rimmed, perfect. Gone."
**MAUD:** "And there's no cart-track. No drag marks. Just... *spokes in the mud, in a circle*."
**MAUD:** "I'm not angry. I'm *impressed*. But I'm also out two hundred copper."
> ► **"Stake out the yard."** — **MAUD:** "Wear a hat. He'll see your head."
> ► **"Check the neighbours."** — **MAUD:** "Everyone loves my wheels. That's the problem."

**Scene 2: the stakeout.** At midnight a small figure climbs the yard wall, a rope looped over one shoulder, a scrap of cloth tied around each foot. He selects a wheel with the care of a jeweller.

**NIB:** (whisper to himself) "Number twelve. Beautiful. Ma'll be furious."
*You step out.*
**NIB:** "AHH. Hello. I wasn't doing anything."
**NIB:** "...I was doing a *lot* of things. But not *bad* things. Well, one bad thing."
> ► **"Why wheels?"** — **NIB:** "For the Derby! The prize is a *gold coin*."
> ► **"You stole from Maud."** — **NIB:** "I'll pay her back! I'll pay her *double*!"
> ► **"Show me the racer."** — **NIB:** *(beaming)* "Come on."

**Scene 3: the racer.** In a collapsed warehouse, a soapbox racer: six wheels, three rudders, a bell. It is a magnificent, ridiculous machine.

**NIB:** "It's called *The Gale*. It's the fastest thing in Aldmere. It just needs better wheels."
**NIB:** "Maud's are the best. I know. I tried the others."
> ► **"Take it to Maud."** — **NIB:** "She'll hate it."
> ► **"I'll buy the wheels."** — **NIB:** "...You would?"
> ► **"Enter the Derby with him."** — **NIB:** "You can be my *crew*!"

**Scene 4: the Derby.** The whole of Eastgate lines the hill. Soapbox racers rattle, wobble and collapse. *The Gale* shoots down the slope with Nib hunched at the front and the player riding behind. Maud, in the crowd, screams *"MY WHEELS!"* and cheers at the same time.

**Outcomes and receipt.**
- Win or lose, Maud forgives Nib, hires him as an apprentice, and teaches him to make wheels properly.
- **Receipt:** *The Gale* stands in Maud's yard; Nib races each spring; Eastgate children chalk wheels on the road.

<!-- quest
id: qst_ald_wheel_thief
title: The Wheel Thief of Eastgate
rank: E
type: Investigation
giver: npc_maud_axle
region: reg_aldmere
level: 15
act: 1
requires_flags: rank_e_reached
reward: 260 | 20 | 900
sets: ald_wheels_resolved
summary: Eleven wheels have vanished from a cartwright's yard. The thief is a nine-year-old building a soapbox racer.
objectives:
  reach eastgate_yard_night
  talk npc_maud_axle
  choice take_it_to_maud_buy_or_race
-->

---

## 5. The Plough Finds a Ledger

*D · Investigation · Royal Valley farms · giver Rook Tull*

**The short version.** A plough turns up a rotted strongbox. Inside: coin, and a ledger. The ledger names a family still seated on the king's council.

**What is really going on.** During the **Grey Harvest (951–953)**, the **Ventnor** family hoarded wheat and sold it at famine prices. The ledger lists each household that paid, and what they paid it for: *a child's life, a spouse's life, a farm's survival*. The Ventnors are now Aldmere's wealthiest family.

**Scene 1: the field.**

**ROOK:** "I don't want it. I want to want it. It's gold, isn't it? But the ledger's wrong. Somehow wrong."
*He hands over a swollen book, water-stained, its ink bleeding.*
**ROOK:** "I can't read all of it. But I recognise the names. They're... us. They're *our families*."
> ► **"Read it to me."** — **ROOK:** "I'll try."
> ► **"Who owns the field?"** — **ROOK:** "The Ventnors. Since forever."
> ► **"What do you want?"** — **ROOK:** "I want my grandmother's name off that page."

**Scene 2: the reading.** In the farmhouse kitchen, by candle, you piece the ledger together. Each entry: a household name, a date, a sum, and a short note in a tidy hand.
*"Tull, Berta. Her son. Paid in full. Delivered."*
**ROOK:** "That's... my great-aunt. She had a son. He died. She never spoke of it."
**ROOK:** "She paid for grain, and it was *too late*."

**Scene 3: the Ventnor house.** In the capital, a polished hall. A silver-haired woman, Lady **Ventnor**, receives you with perfect courtesy.

**LADY VENTNOR:** "I see. You have found a ledger. I wonder if you understand what a *ledger* is."
**LADY VENTNOR:** "It is a record of a transaction. Nothing more. They paid; my ancestor delivered. There was no crime. There was a *market*."
**LADY VENTNOR:** "I should add that this house has paid for every harvest festival in the valley for fifty years. If you wish to expose us, you will be exposing the people who fed the valley in the next famine."
> ► **"Expose them."** — **LADY VENTNOR:** "Then you will be remembered as the one who did."
> ► **"Demand restitution."** — **LADY VENTNOR:** "...How much?"
> ► **"Bury the ledger."** — **LADY VENTNOR:** "A wise choice. I shall not forget it."

**Scene 4: the choice.** Back in the field, the player decides how to use the ledger.
- **Expose:** a public hearing; the Ventnors lose their council seat; the valley is divided.
- **Restitution:** the Ventnors pay a "Grey Harvest Fund" to every named family's descendants; Lady Ventnor never forgives you.
- **Bury:** Rook takes the coin, buries the ledger, and *remembers*.

**Outcomes and receipt.**
- **Expose:** a memorial stone stands in the valley; Ventnor retainers avoid you.
- **Restitution:** the Fund pays; several farms in the valley prosper.
- **Bury:** Rook is quiet; years later, he plants a tree over the box.

<!-- quest
id: qst_ald_ledger
title: The Plough Finds a Ledger
rank: D
type: Investigation
giver: npc_rook_tull
region: reg_aldmere
level: 38
act: 2
requires_rank: D
reward: 1500 | 90 | 6500
sets: ald_ledger_resolved
summary: A plough turns up a rotted strongbox and a ledger from the Grey Harvest. It names the family that sold grain at famine prices, and the families that paid.
objectives:
  talk npc_rook_tull
  reach ventnor_house
  choice expose_restitution_or_bury
-->

---

## 6. The Friend in the Mirror

*D · Investigation · Candle Street Orphanage, Aldmere City · giver Edda Pryor*

**The short version.** The children of Candle Street say they have a *friend in the mirror* who tells them kind things at night. They are sleeping better than they have in years. Matron Edda is terrified.

**What is really going on.** The "friend" is a **lonely shade**, the leftover of a child who died in the building two hundred years ago and who has been waiting for someone to talk back. A pamphlet pushed under the orphanage door bears a hand-mirror sigil and the words *"They will always see you. Join us."* (a Choir of Mirrors recruiting seed; no explicit link).

**Scene 1: the nursery.**

**EDDA:** "They're sleeping. All of them. Not a nightmare in three weeks. And I'm *frightened*, because I don't know why."
**EDDA:** "Last night I stood at the door and heard Pim say: 'Thank you.' To the mirror. And I saw her smile at *nothing*."
> ► **"Has anything been taken?"** — **EDDA:** "No. Nothing. They're just... *happier*."
> ► **"Can I see the mirror?"** — **EDDA:** "It's in the nursery. Please don't break it."

**Scene 2: the vigil.** At midnight, in the nursery, you sit with a lantern. The mirror's surface shivers. A small pale face appears behind your own reflection.

**MIRROR-CHILD:** "...You're new."
**MIRROR-CHILD:** "Nobody ever stays. They all say goodnight and *leave*."
**MIRROR-CHILD:** "I'm Tam. I was seven. I'm... still seven."
> ► **"How long have you been here?"** — **TAM:** "Since the fever. I don't count."
> ► **"What do you tell the children?"** — **TAM:** "That they're good. That they're not alone. That's all."
> ► **"Do you want to go?"** — **TAM:** "...Where?"

**Scene 3: the pamphlet.** A rolled paper pushed under the door the same night. A crude sigil, a hand mirror. A line of print: *"They will always see you. Join us."*

**EDDA:** "I found five of these. Different houses. Same sigil."
**TAM:** "A woman came. She said she could *keep* me. She said the mirror was *all anyone needed*."
*Tam's reflection flickers.*
**TAM:** "I don't want to be kept. I want to go *home*."

**Scene 4: the choice.**
> ► **"Give Tam a name on the wall."** — The orphanage's founders' wall gets a plaque; Tam smiles.
> ► **"Light a candle for her."** — Morrowyn's rite; Tam fades.
> ► **"Cover the mirror."** — The children cry; Tam stays.

**Outcomes and receipt.**
- The player decides how Tam rests. All branches protect the children and reveal that a Mirrors-sigil woman has been visiting houses.
- **Receipt:** a small plaque in the nursery; a pinned *Mirrors recruiting* clue on the Mystery Board (a seed for Sister Ivy's later arc).
- **Rule:** no combat is required; the dead girl is never a monster.

<!-- quest
id: qst_ald_mirror_friend
title: The Friend in the Mirror
rank: D
type: Investigation
giver: npc_edda_pryor
region: reg_aldmere
level: 36
act: 2
requires_rank: D
reward: 1400 | 85 | 6200
sets: ald_mirror_resolved, clue_mirrors_pamphlet
summary: The children of a Candle Street orphanage have a friend in the mirror. A pamphlet bearing a hand-mirror sigil has been pushed under the door.
objectives:
  reach candle_street_nursery_night
  talk npc_edda_pryor
  choice name_candle_or_cover
-->

---

## 7. Stand Down, Soldier

*D · Faction · Greyhollow · giver Sister Agna Dunmoor*

**The short version.** Each night the Greyhollow dead march the same road and stop at the same crossroads. Sister Agna wants to know *why*, and to give them an order no one has given in four hundred years.

**What is really going on.** The dead are waiting for a command from a captain's seal. The seal lies in an unmarked cairn near Greyhollow Village. Using it will let the lesser dead rest. It will *not* touch Ashgrave himself, and it will not end the siege.

**Scene 1: the lantern house.**

**AGNA:** "Four times I've buried this village. Four times they've risen. I'm not a young woman, and the dead are not a patient congregation."
**AGNA:** "They march to the crossroads. They stop. They *wait*. And in the morning they're gone."
**AGNA:** "I think they're waiting for a word."
> ► **"What word?"** — **AGNA:** "I don't know. That's why I called you."
> ► **"You think they can be commanded?"** — **AGNA:** "I think they were *soldiers*."

**Scene 2: the crossroads.** At midnight the column halts. A hundred skeletal soldiers stand at attention in the moonlight, every helm pointed at an empty stone plinth.

**AGNA:** (whisper) "There. Every night. They wait for someone to stand on that stone."
**AGNA:** "No one has. They say it's cursed."
> ► **(Stand on the plinth.)** — The soldiers' skull-sockets flare.
> ► **(Keep watching.)** — You see an old banner folded at the plinth's base.

**Scene 3: the cairn.** A short trek to a cairn marked with a rusted sword. Beneath, a thick leather case containing a captain's seal and a folded order, brittle with age:

*"To all companies of the Greyhollow muster: stand down. Go home. The war is over. — Captain Merrin Halt."*

**AGNA:** "He never delivered it. He died on the road, with the order in his coat."
**AGNA:** "Four hundred years they've been waiting for the captain."

**Scene 4: the order.** At the crossroads, the player steps onto the plinth and reads the order aloud.

**PLAYER (read):** "To all companies of the Greyhollow muster: stand down. Go home. The war is over."
*A long silence. Then, one by one, the soldiers lower their weapons. They kneel. Their bones glow, then fade.*
**SERGEANT:** "...Sir. We... are discharged?"
**AGNA:** "You're discharged."
**SERGEANT:** "Then I would like to go home."
*He dissolves into a drift of pale petals.*

**Outcomes and receipt.**
- A third of the Greyhollow dead are put to rest. The siege remains (Ashgrave and his inner guard are untouched). The road is safer; a handful of dead *stay*, because they do not believe the order, and the player can meet one of them in quest 10.
- **Receipt:** the crossroads plinth holds a lantern; Sister Agna keeps a ledger of names.

<!-- quest
id: qst_ald_stand_down
title: Stand Down, Soldier
rank: D
type: Faction
giver: npc_agna_dunmoor
region: reg_aldmere
level: 40
act: 2
requires_rank: D
reward: 1600 | 95 | 6800
sets: ald_stand_down_resolved
summary: The Greyhollow dead wait nightly at a crossroads for an order nobody has given. A captain's seal in an old cairn can discharge the lesser dead.
objectives:
  talk npc_agna_dunmoor
  reach greyhollow_crossroads_night
  reach merrin_halt_cairn
  choice read_the_order
-->

---

## 8. The Duelist's Last Request

*C · Hidden · Aldmere City · giver Ser Bertram Colt*

**The short version.** A retired duelist asks you to fight him in a mock duel, in front of his granddaughter, and to lose. Politely.

**What is really going on.** **Bertram Colt** won the Gentle Lance three years running. The third win was a *gift*: his opponent, injured and weeping, let him have it. Bertram has never told his granddaughter **Isa**. She thinks he's a legend. She is about to enter her first tournament, and she is *terrified of disappointing him*.

**Scene 1: the practice yard.**

**BERTRAM:** "I am seventy. I have a bad knee, a bad shoulder, and, I'm told, a bad attitude."
**BERTRAM:** "But I have a granddaughter who thinks I am the finest swordsman in Aldmere. And I should like her to keep thinking it a while longer."
**BERTRAM:** "Fight me. A friendly bout. Wooden blades. And *let me win*."
> ► **"You want me to throw the fight?"** — **BERTRAM:** "Politely. With grace."
> ► **"What if I refuse?"** — **BERTRAM:** "Then I shall fight you for real, and I will lose, and she will watch."
> ► **"Why?"** — **BERTRAM:** *(pause)* "Because it is the last thing she will ever see me do."

**Scene 2: the duel.** At dawn in the practice yard, Isa (fifteen, wiry, nervous) watches from the fence. The duel is a fighting mini-game with a twist: the player must *appear* to try, while letting Bertram land three clean touches.

**BERTRAM:** *(low, mid-parry)* "Not so obvious. Make me work for it."
**BERTRAM:** *(low)* "Good. Again. One more."
**ISA:** *(from the fence)* "Grandpa's *so good*!"

**Scene 3: the truth.** After the bout, Isa runs over.

**ISA:** "That was *amazing*. Wasn't that amazing?"
**BERTRAM:** "It was... adequate."
*Isa studies the player's face. She is not stupid.*
**ISA:** "...You let him win."
> ► **"I did."** — **ISA:** "...Why?"
> ► **"He's very good."** — **ISA:** "He's *seventy*."
> ► **"Ask your grandfather."** — **ISA:** (turning) "Grandpa?"

**Scene 4: the confession.** In the dim kitchen, Bertram tells Isa the story of the third win. She listens in silence.

**ISA:** "So the third trophy... was a gift."
**BERTRAM:** "It was. And the first two were *mine*. And I've been afraid ever since that you would think less of the first two."
**ISA:** "Grandpa. I think *more*."
**ISA:** "You gave someone a win. That's... that's the best thing you ever did."

**Outcomes and receipt.**
- In all branches Isa enters her first tournament. If she learns the truth, she fights *better*; if she doesn't, she is still in awe.
- **Receipt:** Bertram's Gentle Lance hangs in the practice yard with a small card: *"Won, 3 times. Given, once."* Isa enters the Aldmere circuit next season.

<!-- quest
id: qst_ald_duelist_request
title: The Duelist's Last Request
rank: C
type: Hidden
giver: npc_bertram_colt
region: reg_aldmere
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: ald_duelist_resolved
summary: A retired duelist asks you to lose a mock duel in front of his granddaughter. He has been hiding a gift for forty years.
objectives:
  talk npc_bertram_colt
  reach aldmere_practice_yard
  choice lose_win_or_confess
-->

---

## 9. The King Wants to Go Fishing

*C · Escort · Aldmere City · giver Osric Finch*

**The short version.** King Alaric IV has asked for one afternoon of fishing. His council has refused. His valet asks you to get him out of the palace.

**What is really going on.** The king is weak, tired and watched. He has not seen the river in years. He wants to remember what ordinary Aldmerians are like. He also wants to hear, without a council in the way, what the valley is saying about the Archbishop.

**Scene 1: the pantry.**

**OSRIC:** "Do not speak. Do not look at the guards. If anyone asks, you are the new under-gardener."
**OSRIC:** "The king would like to fish. Today. Alone. *Properly*. I have never been asked for anything in forty years, and this is the first thing I wanted to give him."
> ► **"Is this treason?"** — **OSRIC:** "It is... *unscheduled*."
> ► **"The Archbishop will notice."** — **OSRIC:** "The Archbishop notices everything. That is why you are here."
> ► **"What does the king want?"** — **OSRIC:** "To be a person for an afternoon."

**Scene 2: the escape.** A comic-tense stealth sequence through the palace kitchens. A pair of Inquisitors on patrol; a corgi that sees through the disguise; a long, wordless look from a maid who is pretending not to notice.

**KING ALARIC:** (in a stolen cloak, whispering) "Is this what stealth is?"
**KING ALARIC:** "I never expected it to be so... *crouchy*."

**Scene 3: the river.** On a quiet bend, the king casts a line. Farmers pass; one stops.

**FARMER:** "Evening, friend."
**KING ALARIC:** "Evening."
**FARMER:** "Any luck?"
**KING ALARIC:** "Not yet."
**FARMER:** "Take the grey fly. Fish prefer it since the new toll."
*The king looks, surprised, at the player.*
**KING ALARIC:** "I have been told the toll was *fair*."
> ► **"It is, mostly."** — A smile.
> ► **"The farmers don't think so."** — The king listens.
> ► **"Ask him yourself."** — He does.

**Scene 4: the question.** The farmer, unaware, talks for an hour about grain prices, the Church's new tithe, and "that Archbishop's long face."

**KING ALARIC:** (later, on the bank) "I did not know. They tell me *everything is well*. And then a man with a fish tells me otherwise."
**KING ALARIC:** "...Thank you. For the afternoon."
**KING ALARIC:** "I think I would like to be the sort of king who does this *more often*."

**Outcomes and receipt.**
- The player gets the king home before curfew. If the Inquisitors catch them, Osric takes the blame (a long-term consequence for the Archbishop's reach).
- **Receipt:** a fishing rod stands in the king's study; the toll board on the quay gets a royal seal; Alaric invites the player to a private supper in Act IV.

<!-- quest
id: qst_ald_king_fishing
title: The King Wants to Go Fishing
rank: C
type: Escort
giver: npc_osric_finch
region: reg_aldmere
level: 64
act: 3
requires_rank: C
reward: 4200 | 230 | 15500
sets: ald_king_resolved
summary: King Alaric IV has asked for one afternoon of fishing. His valet asks you to get him out of the palace.
objectives:
  talk npc_osric_finch
  escort npc_osric_finch
  reach aldmere_river_bend
  choice return_before_curfew_or_stay
-->

---

## 10. What the Baron Refused

*C · Investigation · Greyhollow · giver Archivist Orrow*

**The short version.** Archivist Orrow has found Ashgrave's letters in a sealed barrow chest. They are addressed to a king, and they are not what the legends say.

**What is really going on (proposal).** **Baron Ashgrave** was not oathless out of treachery. During the **Grey Harvest (951–953)**, the king ordered him to seize the valley's grain for the capital. Ashgrave refused, because it would have starved his own villages. He broke his oath to protect them. The dead who march *are his company hauling grain to the starving*, and they have been doing it ever since. Nobody told them the famine ended.

**Scene 1: the archive.**

**ORROW:** "I verify things. It is my one virtue. And I have verified something I wish I had not."
**ORROW:** "These are Ashgrave's own letters. The wax is intact. The hand is genuine. And the content is... not what the ballads say."
> ► **"What do they say?"** — **ORROW:** "That he refused an order. *The* order."
> ► **"Why show me?"** — **ORROW:** "Because you can reach Greyhollow. I cannot."

**Scene 2: the letters.** The player reads three:
*"To His Majesty: I cannot seize the grain. They will starve. I would sooner be oathless than a murderer."*
*"To my captains: the wagons go west. Not east. West. We will feed the villages first."*
*"To my wife: if I do not return, know that I did not die a traitor. I died a man who kept his word to the wrong king."*

**ORROW:** "He was not a traitor. He was a man who chose his own oath over his king's."
**ORROW:** "And the dead who march? They are *still* carrying the grain."

**Scene 3: the march.** At night on the barrow road, a column of skeletal soldiers drags empty wagons westward, sacks of nothing slung over their shoulders. They halt at the farms; the lead soldier bows to the doorstep sword; they march on.

**SERGEANT:** "More grain. More. They are hungry in the west."
> ► **"The famine is over."** — **SERGEANT:** "...Is it?"
> ► **"Where are you taking it?"** — **SERGEANT:** "Where the Baron ordered. West."
> ► **"Can I help?"** — **SERGEANT:** "*...Do you have grain?*"

**Scene 4: the choice.** The player can bring real grain to the column (Millbrook, Brindlewick, or any farm), or tell Orrow to publish the letters, or both.

**ORROW:** "If I publish, the Church will say it is forgery. If I do not, he is a villain forever."
**SERGEANT:** (receiving a sack) "...The west will eat tonight."
*He lays the sack at the edge of a field and salutes the empty horizon.*

**Outcomes and receipt.**
- Ashgrave's reputation shifts in the region's rumours; the Tyrant fight remains but gains new pre-fight dialogue (a *stand-down offer* is not an option; he is a Tyrant).
- **Receipt:** the Greyhollow road has fields of wheat planted by the dead's own grain; the barrow's banners are repaired by grateful villagers.
- **Proposal (Canon §6):** Ashgrave's backstory as the Baron who refused the Grey Harvest seizure.

<!-- quest
id: qst_ald_baron_refused
title: What the Baron Refused
rank: C
type: Investigation
giver: npc_archivist_orrow
region: reg_aldmere
level: 66
act: 3
requires_rank: C
requires_quests: qst_ald_stand_down
reward: 4500 | 245 | 16500
sets: ald_baron_resolved
summary: Ashgrave's sealed letters say he refused an order to seize the valley's grain in the Grey Harvest. The dead who march are still hauling it.
objectives:
  talk npc_archivist_orrow
  reach greyhollow_barrow_chest
  reach barrow_road_night
  choice publish_feed_or_both
-->
