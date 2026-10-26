# 11e-16 — Guild Ladders: Five Faction Tests (draft)

> *"You do not join a guild by asking. You join it by passing one very specific afternoon."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 6 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** Many open-world RPGs give each faction a long ladder of chores. These give each faction **one vivid test** instead: a single sitting that shows *what the faction values*, with a real choice and a receipt in the faction's own space. Each is a *door*, not a chain; a later faction questline can take it up.

**Factions used** (Canon faction table): the **Shadow Syndicate**, the **Mages' Academy**, the **Merchants' Consortium**, the **Holy Church of Lumina** and the **Beastkin Federation**.

**Rules.** No faction is simply good or evil. The test always has a **kind answer** and a **faction answer**, and the player can choose either; neither shuts a door. Reputation changes are described in prose (Canon §6: local, witness-based reputation). Nobody here *requires* the player to join.

| # | Faction | Quest | Region | Rank | The test |
|---|---|---|---|---|---|
| 1 | Shadow Syndicate | The Nobody Test | Aldmere | C | Steal a ledger; leave a gift |
| 2 | Mages' Academy | The Thesis Defence | Aldmere City | D | Defend an odd idea in a hall of skeptics |
| 3 | Merchants' Consortium | The Honest Scale | Goldmere Coast | B | Audit a market that is just *a little* off |
| 4 | Holy Church of Lumina | The Candle Count | Aldmere City | C | Audit a parish that is *poor* |
| 5 | Beastkin Federation | The Alpha's Dinner | Fanghold | B | A ceremony of small courtesies |

## Cast

<!-- npc
id: npc_nobody_courier_tess
name: Tess of the Third Stair
tier: major
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Syndicate runner
backstory: A quick, bright runner for the Shadow Syndicate who delivers Nobody's tests and has never once been told what they are for.
-->
<!-- npc
id: npc_magister_halloran
name: Magister Halloran Quince
tier: major
race: Human
region: reg_aldmere
settlement: Arcanum Spire
role: Magister of the Academy's Hall of Questions
backstory: A tall, dry magister who has spent forty years asking students why they believe what they believe and has failed only twice to be surprised by the answer.
-->
<!-- npc
id: npc_consortium_auditor_serafina
name: Auditor Serafina Galt
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Merchants' Consortium auditor
backstory: A sharp, pleasant auditor who has caught fourteen cheats in the Goldmere markets and has begun to suspect that the fifteenth is herself.
-->
<!-- npc
id: npc_father_corvin_pell
name: Father Corvin
tier: major
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Parish priest of St. Ansel's, Tallow Lane
backstory: A thin, worn priest of a very poor parish who has kept the books of his church for thirty years and has never once had them balance.
-->
<!-- npc
id: npc_alpha_dorjan
name: Alpha Dorjan
tier: major
race: Wolf-kin
region: reg_fanghold
settlement: Fanghold
role: Alpha of the Beastkin Federation's eastern packs
backstory: A grey-muzzled wolf-kin Alpha who has hosted three thousand dinners and has never forgiven a single bad manner, and has never once refused anyone a second helping.
-->

---

## 1. The Nobody Test

*C · Faction · Aldmere City · giver Tess of the Third Stair · faction: Shadow Syndicate*

**The offer.** A runner finds the player on the street and hands over a sealed note: *"A ledger sits in Merchant Pell's counting-room. Take it. Tonight. Leave a gift in its place. —N."*

**What the test is for.** Nobody (the Syndicate's frontier leader, Canon) does not want thieves. She wants people who can take what they need and leave a *kindness.* The ledger belongs to a lender who has been squeezing a street of poor shopkeepers.

**Scene 1: the note.**

**TESS:** "She wants it done tonight. I don't know why. She never tells me."
**TESS:** "Take the ledger. Leave a gift. *A gift.* That's the whole test."
**TESS:** "She said: *a thief who cannot give is only a thief.*"
> ► **"What gift?"** — **TESS:** "That's *your* question."
> ► **"Who's it for?"** — **TESS:** "...I don't know."
> ► **"Why a test?"** — **TESS:** "To see who you are in the dark."

**Scene 2: the counting-room.** A stealth sequence through a tidy, cold lender's house. Locks, a sleeping clerk, a guard-dog that is, to everyone's surprise, a very friendly spaniel. In the counting-room, a heavy ledger lies open on a desk.

*(Gameplay: stealth with multiple solutions; the player may pick locks, bribe the spaniel, or simply walk in with a lantern and pretend to be an auditor.)*

**Scene 3: the ledger.** Reading by lantern, the player sees names and sums: forty small debts, each a shopkeeper's life. Beside one, a note: *"Overdue, 3 days. Call in tomorrow."*

> ► **"Take it."** — The ledger goes into the satchel.
> ► **"Burn it."** — **TESS (later):** "...She said *take.*"
> ► **"Copy it."** — A quieter, cleverer choice.

**Scene 4: the gift.** In place of the ledger, the player leaves a *gift.* The test is open-ended; the Syndicate has a few ideas.
- **A small bag of coin**, enough to pay one debt.
- **A forged receipt**, clearing the three overdue shopkeepers.
- **A letter**, to the lender, in the voice of the street, asking for mercy.
- **A bundle of bread and a hot pie**, because the clerk will find it first.

**NOBODY (via Tess, next day):** "She says: *the debt was never the point.*"
**NOBODY:** "She says: *what you leave behind tells me what you are.*"

**Outcomes and receipt.**
- The Syndicate admits the player to its first circle; a gift of kindness earns a *warmer* welcome than a gift of mere cleverness. If the player burns the ledger, Nobody is *amused*, not angry.
- **Receipt:** a small chalk mark on the player's door, a Syndicate sign meaning *"known."*

<!-- quest
id: qst_pat_guild_nobody_test
title: The Nobody Test
rank: C
type: Faction
giver: npc_nobody_courier_tess
region: reg_aldmere
level: 64
act: 3
requires_rank: C
reward: 3900 | 215 | 15000
sets: pat_guild_nobody_done
summary: The Shadow Syndicate's test: take a lender's ledger, and leave a gift in its place.
objectives:
  talk npc_nobody_courier_tess
  reach aldmere_lenders_counting_room
  choice take_burn_or_copy
-->

---

## 2. The Thesis Defence

*D · Faction · Arcanum Spire · giver Magister Halloran Quince · faction: Mages' Academy*

**The offer.** The Academy admits outsiders by *argument.* The player has been invited to defend a thesis before the Hall of Questions. The topic is theirs to choose, but it must be *something they actually believe.*

**What the test is for.** The Academy prizes honesty over cleverness. Halloran will pick apart any thesis, but he is *delighted* by an honest one.

**Scene 1: the magister.**

**HALLORAN:** "Choose a thing you believe. Not a thing you think I'll *like.* A thing you *believe.*"
**HALLORAN:** "I shall attack it from every side. The point is not to win. The point is to learn how you *lose.*"
**HALLORAN:** "You have one night to prepare."
> ► **"What if I'm wrong?"** — **HALLORAN:** "Then you will learn something *delightful.*"
> ► **"What do other candidates choose?"** — **HALLORAN:** "Things that sound like theses."
> ► **"I have one."** — **HALLORAN:** "Splendid."

**Scene 2: the thesis.** The player selects a **thesis**, an actual belief about the world the player has formed in play. Four options *(each tied to the player's own play):*
- **"Mercy is a form of strength."** (if the player has been merciful)
- **"Rank is a language, not a ladder."** (the guild theme)
- **"Monsters are not a different kind of person."** (if the player has tamed or spared)
- **"Small kindnesses are the real magic."** (a personal choice)

**Scene 3: the hall.** In a tiered amphitheatre, forty scholars in grey sit in rows. Halloran begins, courteously, to dismantle.

**HALLORAN:** "You say *mercy is a form of strength.* But a mercy shown by the weak is only *surrender.*"
> ► **"Mercy requires the power to refuse."** — **HALLORAN:** "...Interesting."
> ► **"I've shown mercy and still won."** — **HALLORAN:** "Anecdote."
> ► **"I don't know. You're right."** — **HALLORAN:** "*Excellent.*"
**HALLORAN:** "You've understood the exercise."

*(Gameplay: a dialogue duel in which the player's arguments are scored by *honesty* and *coherence*, not eloquence. Admitting uncertainty earns marks.)*

**Scene 4: the verdict.** At the end, the Hall votes by *lowering lamps.* Half the lamps go down. Half stay up.

**HALLORAN:** "A split. I have not seen a split in nine years."
**HALLORAN:** "That is the *best* result. Come in."

**Outcomes and receipt.**
- Any outcome admits the player to the Academy's public library; a *split* verdict adds a seat at the Hall of Questions.
- **Receipt:** the player's thesis is copied into the Academy's *Book of Honest Arguments*, with a small footnote in Halloran's hand.

<!-- quest
id: qst_pat_guild_thesis
title: The Thesis Defence
rank: D
type: Faction
giver: npc_magister_halloran
region: reg_aldmere
level: 44
act: 2
requires_rank: D
reward: 1700 | 100 | 6800
sets: pat_guild_thesis_done
summary: The Academy admits outsiders by argument. The player must defend something they honestly believe before the Hall of Questions.
objectives:
  talk npc_magister_halloran
  reach arcanum_hall_of_questions
  choice mercy_rank_monsters_or_kindness
-->

---

## 3. The Honest Scale

*B · Faction · Port Goldmere · giver Auditor Serafina Galt · faction: Merchants' Consortium*

**The offer.** The Consortium wants a market audited, quietly. The market is *almost* honest. The player's job is to find the *one* scale that is off by a hair.

**What the test is for.** The Consortium prizes fair dealing *as good business.* A cheat is a bad investment. But it also prizes *discretion*, and the player's report will decide what happens to the cheat.

**Scene 1: the auditor.**

**SERAFINA:** "Forty stalls. Forty scales. Thirty-nine true."
**SERAFINA:** "One is off by *two grains.* It costs a buyer nothing, and a seller a *fortune* over a year."
**SERAFINA:** "I will not tell you which. I want to know whether you can *tell.*"
> ► **"Why not just check them?"** — **SERAFINA:** "Because the *cheat* knows how."
> ► **"What will you do to the cheat?"** — **SERAFINA:** "That depends on your report."
> ► **"I'll find it."** — **SERAFINA:** "Bring a feather."

**Scene 2: the stalls.** A funny, careful sequence in a bright market. The player weighs identical feathers on forty scales; talks to vendors; notes who is *too* friendly, who is too *rushed*, and who is *proudly* honest.

**FISHMONGER:** "My scale? Honest as a priest!"
**SPICE-SELLER:** "Check it. Check it *twice.*"
**OLD WOMAN (bread):** "I do not *own* a scale. I use my *hands.*"

**Scene 3: the cheat.** The off scale belongs to **Dorotea**, the old bread-woman, who has *no* scale. She borrows her *neighbour's*, which is two grains off, and has been *since the day he died.* She has never known.

**DOROTEA:** "I thought it was *fine.* My husband's. He was a careful man."
**DOROTEA:** "Oh, no. Oh, *no.* Have I been cheating my *customers*?"
> ► **"Report her."** — The Consortium fines a sad old woman.
> ► **"Fix the scale."** — A quiet, honest repair.
> ► **"Report the scale, not the woman."** — The Consortium recalibrates.
> ► **"Offer to refund."** — A small, generous gesture.

**Scene 4: the report.** The player brings the report to Serafina.

**SERAFINA:** "Thorough. *Kind.* I did not *ask* for kind."
**SERAFINA:** "...I was hoping for it."

**Outcomes and receipt.**
- The player decides what the Consortium does to Dorotea; the fairest answer is a recalibration. A harsh report earns Consortium respect and Dorotea's despair.
- **Receipt:** the Consortium adds a *scale-checking day* to the Goldmere market; Dorotea sends a loaf each week.

<!-- quest
id: qst_pat_guild_honest_scale
title: The Honest Scale
rank: B
type: Faction
giver: npc_consortium_auditor_serafina
region: reg_goldmere_coast
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: pat_guild_honest_scale_done
summary: The Consortium wants a market audited quietly. One scale of forty is off by two grains, and the owner doesn't know.
objectives:
  talk npc_consortium_auditor_serafina
  reach goldmere_market_forty_stalls 40
  choice report_fix_or_refund
-->

---

## 4. The Candle Count

*C · Faction · Tallow Lane · giver Father Corvin · faction: Holy Church of Lumina*

**The offer.** The Church sends auditors to every parish. Father Corvin's books have never balanced. This year the auditor is the player.

**What the test is for.** The Church values *order* and, when it is at its best, *mercy.* The auditor's report decides whether Corvin is censured or supported. The books are off because he feeds forty people a week out of the parish funds.

**Scene 1: the priest.**

**CORVIN:** "Welcome to St. Ansel's. The roof leaks. The bell is cracked. The books do not balance."
**CORVIN:** "I am told you are the auditor. I would offer tea. We have *water.*"
**CORVIN:** "Please be thorough. I would like to be *understood.*"
> ► **"I'll start with the books."** — **CORVIN:** "Of course."
> ► **"How many do you feed?"** — **CORVIN:** "...Forty. Sometimes fifty."
> ► **"You don't have to be afraid."** — **CORVIN:** "I am, a little."

**Scene 2: the counting.** An audit as a quiet, tense scene: the player counts candles, bread, coin, coal. The numbers do not balance by eleven silver a month. In a back room, a long table, a pot of soup, and forty faces.

**PARISHIONER:** "He gives it away. All of it. He doesn't *eat.*"
**CHILD:** "He says he's not hungry. But I *saw.*"

**Scene 3: the report.** The player writes the report. The Church's template has a column for *irregularities* and a column for *explanations.* The player may fill in either.

> ► **"Report the irregularity."** — Corvin is formally censured; the parish funds are frozen.
> ► **"Report the explanation."** — Corvin is called in, gently.
> ► **"Fix the books."** — The player makes up the eleven silver from their own purse.
> ► **"Take it to the bishop."** — A different approach, a bigger audience.

**Scene 4: the answer.** A fortnight later, a letter arrives.

*"To Father Corvin: the Church acknowledges the irregularities in the books of St. Ansel's. The diocese will cover the eleven silver per month, from the alms-box, henceforth. A bell will follow."*

**CORVIN:** (reading, shaking) "...A *bell.*"

**Outcomes and receipt.**
- The player's report shapes the diocese's response; a kind report earns a kind answer, but the Church takes *time.* A harsh report censures Corvin, who accepts it quietly.
- **Receipt:** a new bell hangs in St. Ansel's tower; the parish table seats fifty.

<!-- quest
id: qst_pat_guild_candle_count
title: The Candle Count
rank: C
type: Faction
giver: npc_father_corvin_pell
region: reg_aldmere
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: pat_guild_candle_count_done
summary: The Church sends the player to audit a poor parish whose books have never balanced, because its priest feeds fifty people a week.
objectives:
  talk npc_father_corvin_pell
  reach aldmere_tallow_lane_parish
  choice irregularity_explanation_or_fix
-->

---

## 5. The Alpha's Dinner

*B · Faction · Fanghold · giver Alpha Dorjan · faction: Beastkin Federation*

**The offer.** The Alpha invites the player to dinner. There are no tests, no questions. There are, however, forty *small courtesies*, and he will notice every one.

**What the test is for.** The Federation values hospitality, and judges guests by how they *receive* it. The Alpha does not want warriors; he wants *good company.*

**Scene 1: the yurt.**

**DORJAN:** "Come. Sit. Do not ask whose seat it is. It is *yours.*"
**DORJAN:** "Eat first. Talk later. A hungry guest *lies.*"
**DORJAN:** "There are *rules*, of course. I will not tell you what they are."
> ► **"May I ask?"** — **DORJAN:** "You may *ask.* That is the *first* rule."
> ► **"I'll follow your lead."** — **DORJAN:** "*Good.*"
> ► **"Is this a test?"** — **DORJAN:** "Everything is."

**Scene 2: the dinner.** A long, warm, comic, tense dinner in a lantern-lit yurt. Forty small things to notice:
- *Do you wait to be served?*
- *Do you praise the host, or the food?*
- *Do you offer the first cup to the wind?*
- *Do you ask for a second helping?* (Yes: a *compliment.*)
- *Do you notice the youngest cub is being ignored?*
- *Do you eat the strange dish without grimacing?*

**CUB (small, shy):** "...Are you the big one? From the guild?"
**PLAYER:** "...I am."
**CUB:** "Can you eat with a *bone spoon*?"
> ► **"Teach me."** — The cub, enchanted, does.
> ► **"No."** — **CUB:** "...Okay."
> ► **"Show me, and I'll show you a trick."** — Both laugh.

**Scene 3: the strange dish.** Near the end, Dorjan places a bowl of something grey and wobbling before the player.

**DORJAN:** "Fermented mare's milk. A local delicacy."
**DORJAN:** "It is an *acquired taste.*"
> ► **(Eat it with enthusiasm.)** — **DORJAN:** "...Genuine."
> ► **(Eat it politely.)** — **DORJAN:** "Polite."
> ► **(Decline.)** — **DORJAN:** "...Honest."
> ► **(Offer it to the wind first.)** — **DORJAN:** (a long silence) "*...That is the correct answer.*"

**Scene 4: the nod.** At the end of the dinner, the Alpha rises. He does not make a speech. He lays a single grey wolf-fur on the player's shoulders, and nods.

**DORJAN:** "You were a good guest."
**DORJAN:** "That is the *only* thing the Federation asks."

**Outcomes and receipt.**
- The player's behaviours shape the dinner's tone; any honest answer is respected. The Federation opens its yurts to the player, and the *Alpha title* (a late Exalted reward) is one step nearer.
- **Receipt:** a wolf-fur shawl, kept in the player's Journal; the cub sends a drawing of the player with a bone spoon.

<!-- quest
id: qst_pat_guild_alpha_dinner
title: The Alpha's Dinner
rank: B
type: Faction
giver: npc_alpha_dorjan
region: reg_fanghold
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: pat_guild_alpha_dinner_done
summary: The Beastkin Federation's Alpha invites the player to dinner. There are forty small courtesies, and he will notice every one.
objectives:
  talk npc_alpha_dorjan
  reach fanghold_alphas_yurt
  choice eat_polite_decline_or_wind
-->
