# 11e-29 — Xochitl Mire, the Flower Rivers: Ten Side Quests (draft)

> *"The old river-kings fed the swamp so that it would not feed on them. The tradition lapsed."*
> — Gazetteer, Xochitl Mire

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the third regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light.

**Region:** `reg_xochitl_mire` (the river-cities on their lagoon islands, the floating gardens, the canoe-roads and their carved posts, the flower markets, the Feeding Steps, the Star Tower). **Rank band:** C–B. **Tone:** ceremonial, busy, warm, and very watchful. Everything has a ritual, a market and a drum, and under every one of them the water is faintly, patiently moving. The people are proud of their rituals and a little defensive about the one they dropped.

**Placement notes.**
- **Xibalbar, the Hydra of the Mire,** is the region's Tyrant. It hunts along the canoe-roads and grows back every head it loses. No quest here kills it. Quests 6, 7 and 9 change how the cities prepare, what they believe about why it woke, and whether they speak to each other at all.
- **Naming.** The river-cities here carry English-glossed names (Marigold Reach, Heron Stair, Three Canoes, Reed Crown, Salt Lantern). Personal names and titles are invented in a loosely river-country spirit, **not** the names of real deities or real peoples' gods; the day-gods are never named. Nothing in these quests is a sacrifice of a person. The old feeding rites are shown as what the gazetteer says they were: *offerings*, and the quarrel about what the last river-king added to them.
- **Customs the quests rely on.** Every morning, flowers go onto the canals. Cacao beans are money. Canoe-roads are marked by carved posts that only a road-warden may move. A match between cities is a matter of honour. Chinampa-keepers settle drifting-land disputes by the "three dawns" rule. The league of river-cities meets in a ring of canoes.
- Earlier quests in this region: *The Ball Court of the River-Kings* (Priest-Astronomer Citlalin) and *The Head That Grew Back* (Boatwright Tzitzi, the head Itzel). Nothing here repeats them.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Garden That Drifted | C | OddJob | Chinampa-Keeper Nenetl | A garden, a goat, and the three-dawns rule |
| 2 | The Match on the Far Side | C | Escort | Captain Ocelotl | A team, a canoe-road, and a long way round |
| 3 | A Blanket by Canoe | C | Delivery | Old Weaver Teyolia | A grandmother's gift, across cut water |
| 4 | The Posts Have Moved | C | Investigation | Road-Warden Calli | Someone is changing the road |
| 5 | Clay Beans | C | OddJob | Market-Judge Cozcatl | A forged currency, and a shortage |
| 6 | The Priest Who Came Back | B | Investigation | Steward Ihuitl | What the old rites really asked |
| 7 | What the Star-Counters Saw | B | Exploration | Star-Counter Yolotli | Two tables, one pattern |
| 8 | Flowers for the Night Causeway | B | Defense | Market-Warden Tlali | The morning offering, defended |
| 9 | The Ring of Equal Water | B | Faction | League Herald Cuicatl | Five kings and no one wants the head seat |
| 10 | The Boy Who Stopped Feeding the River | B | Escort | Ayotl | Flowers, a father, and a mud island |

## Cast

<!-- npc
id: npc_xoc_nenetl
name: Chinampa-Keeper Nenetl
tier: major
race: Human
region: reg_xochitl_mire
settlement: Marigold Reach
role: Keeper of the Marigold Reach floating gardens
backstory: A broad, laughing chinampa-keeper whose finest garden has just untied itself in the night and floated, goat and all, into the canal of a rival city.
-->
<!-- npc
id: npc_xoc_tochin
name: Chinampa-Keeper Tochin
tier: townsfolk
race: Human
region: reg_xochitl_mire
settlement: Heron Stair
role: Keeper of the Heron Stair floating gardens
backstory: A thin, careful chinampa-keeper who woke to find another city's garden moored against his own, and who is entirely certain it is a diplomatic gift.
-->
<!-- npc
id: npc_xoc_ocelotl
name: Captain Ocelotl
tier: major
race: Human
region: reg_xochitl_mire
settlement: Marigold Reach
role: Captain of the Marigold Reach ball team
backstory: A bruised, loud ball-team captain who has trained for a whole season to meet the Heron Stair team, and who will not forfeit because a hydra happens to live between the two cities.
-->
<!-- npc
id: npc_xoc_teyolia
name: Old Weaver Teyolia
tier: major
race: Human
region: reg_xochitl_mire
settlement: Three Canoes
role: Weaver and grandmother
backstory: A very old weaver at Three Canoes who has woven a cradle-blanket for a great-grandchild in Reed Crown and cannot get it across the water that now separates them.
-->
<!-- npc
id: npc_xoc_calli
name: Road-Warden Calli
tier: major
race: Human
region: reg_xochitl_mire
settlement: Salt Lantern
role: Warden of the Salt Lantern canoe-road
backstory: A methodical road-warden who has kept the carved posts of the Salt Lantern road for twenty years and takes personal offence at any post that is a hand's width from where it should be.
-->
<!-- npc
id: npc_xoc_mayel
name: Old Fisherwoman Mayel
tier: townsfolk
race: Human
region: reg_xochitl_mire
settlement: Salt Lantern
role: Retired fisherwoman
backstory: A tiny, sun-dark fisherwoman who has fished the Salt Lantern channels for sixty years and has quietly decided that some roads are better than the posts say.
-->
<!-- npc
id: npc_xoc_cozcatl
name: Market-Judge Cozcatl
tier: major
race: Human
region: reg_xochitl_mire
settlement: Heron Stair
role: Judge of the Heron Stair market
backstory: A dignified market-judge who has not lost a coin to a forger in thirty years and has just been handed a sack of cacao beans that are, on inspection, made of clay.
-->
<!-- npc
id: npc_xoc_papalotl
name: Potter Papalotl
tier: townsfolk
race: Human
region: reg_xochitl_mire
settlement: Heron Stair
role: Potter of the lower canal
backstory: A broad, anxious potter with a family of seven and a kiln that keeps making very good little brown beans.
-->
<!-- npc
id: npc_xoc_ihuitl
name: Steward Ihuitl
tier: major
race: Human
region: reg_xochitl_mire
settlement: Reed Crown
role: Steward to the king of Reed Crown
backstory: A careful, anxious steward who has been told by the king to find out what the old feeding rites really were, and by every priest in the city that he should not.
-->
<!-- npc
id: npc_xoc_mecatl
name: Priest Mecatl
tier: major
race: Human
region: reg_xochitl_mire
settlement: Reed Crown
role: Old priest who has returned from exile
backstory: A very old, soft-spoken priest who was driven out when the feeding rites were abandoned and has come back, alone, with a basket of maize and a story nobody will let him finish.
-->
<!-- npc
id: npc_xoc_yolotli
name: Star-Counter Yolotli
tier: major
race: Human
region: reg_xochitl_mire
settlement: The Star Tower
role: Young astronomer at the Star Tower
backstory: A young, sleepless star-counter who has found the same pattern in two sets of tables that should never have agreed and is terrified of being right.
-->
<!-- npc
id: npc_xoc_nochtli
name: Star-Counter Nochtli
tier: major
race: Human
region: reg_xochitl_mire
settlement: Marigold Reach
role: Senior astronomer of the Marigold Reach observatory
backstory: A stately old astronomer who has kept the Marigold Reach tables for fifty years and finds it deeply impolite that a young person should disagree with them, particularly when she is right.
-->
<!-- npc
id: npc_xoc_tlali
name: Market-Warden Tlali
tier: major
race: Human
region: reg_xochitl_mire
settlement: Marigold Reach, the Night Causeway
role: Warden of the night flower market
backstory: A brisk, tireless warden who has run the night flower market for fifteen years and has never once let a morning offering go out short.
-->
<!-- npc
id: npc_xoc_cuicatl
name: League Herald Cuicatl
tier: major
race: Human
region: reg_xochitl_mire
settlement: Three Canoes
role: Herald of the league of river-cities
backstory: A fussy, sing-song herald who has been told to seat five kings in a ring of canoes and has only now realised that nobody wants the head.
-->
<!-- npc
id: npc_xoc_ayotl
name: Ayotl
tier: townsfolk
race: Human
region: reg_xochitl_mire
settlement: Salt Lantern
role: Fisher's son, aged ten
backstory: A fierce, grieving ten-year-old who has stopped putting flowers on the water because he says the river takes things and does not give them back.
-->
<!-- npc
id: npc_xoc_itzmin
name: Fisher Itzmin
tier: townsfolk
race: Human
region: reg_xochitl_mire
settlement: A reed island in the Salt Lantern channel
role: Stranded fisher
backstory: Ayotl's father, who has been marooned on a mud island since the canoe-road was cut, and who has been catching just enough fish to keep a very small fire.
-->

---

## 1. The Garden That Drifted

*C · OddJob · the Marigold Reach canal · giver Chinampa-Keeper Nenetl*

**The short version.** In the night, Nenetl's finest floating garden untied itself and drifted four canals over, with its goat, into the water of Heron Stair. Under the three-dawns rule, a garden that sits against another city's bank for three dawns belongs to that city. It is the second dawn.

**What is really going on.** Nobody stole it. The mooring-reeds rotted. Tochin, the keeper on the other side, did not tie it up. He is sincerely, politely, delighted. Neither keeper is at fault, but neither will say so, and the goat has become a diplomatic problem.

**Scene 1: the Marigold Reach canal.**

**NENETL:** "My whole *season* is on that garden. Beans, squash, forty rows of marigolds, and a goat named Her Excellency."
**NENETL:** "It's the second dawn! If it sits there until tomorrow, it's *Heron Stair's!* Go and fetch it!"
**NENETL:** "And be tactful! I have been accused of being unsubtle."
> ► **"Can't you just pull it back?"** — **NENETL:** "It is *moored* to their bank. If I touch their reed, it is a *theft.*"
> ► **"What if I ask Tochin?"** — **NENETL:** "He will ask for a consideration."
> ► **"I'll talk to him."** — **NENETL:** "Mind the goat. She bites."

**Scene 2: Heron Stair.** A thin, polite man in a feathered cape stands on the bank, admiring the garden as though it were his own.

**TOCHIN:** "A gift! A magnificent gift! Truly, the Marigold Reach people are generous."
**TOCHIN:** "I would of course be *delighted* to return it, if they asked the proper way."
**TOCHIN:** "The proper way, as it happens, involves a formal request, a gift of equal value, and a night's hospitality."
> ► **"That's three dawns."** — **TOCHIN:** "It is a very *thorough* proper way."
> ► **"What if we shared it?"** — **TOCHIN:** (a pause) "...Shared?"
> ► **"Can I move it myself?"** — **TOCHIN:** "If you can do it without touching our reed."

**Scene 3: the options.**

> ► **(Tow it back with a long pole and a rope that touches no one's reed.)** — A tense, watery comedy, at dusk.
> ► **(Persuade both keepers to share the garden.)** — A bridge-garden between two cities, a shared harvest.
> ► **(Offer Tochin a gift of equal value: a very large pumpkin.)** — He is deeply moved.

*On the water, the goat watches the whole negotiation with an expression of profound, aristocratic disdain. Once, it eats part of a hat.*

**TOCHIN:** (as the pole comes tight) "I will say, for the record, that I never, never touched the reed."
**NENETL:** "You did not *tie* the reed."
**TOCHIN:** "That is not the same as touching."

**Outcomes and receipt.**
- The garden is returned before the third dawn, or (if shared) becomes a floating link between the cities. In every version, the goat is moved to a safe pen and the hat is replaced.
- **Receipt:** a pair of new mooring-posts carved with both cities' signs, and a goat on the Heron Stair side of the canal, eating marigolds, by general agreement.

<!-- quest
id: qst_xoc_garden_drifted
title: The Garden That Drifted
rank: C
type: OddJob
giver: npc_xoc_nenetl
region: reg_xochitl_mire
level: 58
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: xoc_garden_drifted_done
summary: A floating garden has drifted into another city's canal, and the three-dawns rule is about to hand it over.
objectives:
  talk npc_xoc_nenetl
  talk npc_xoc_tochin
  choice tow_share_or_gift
-->

---

## 2. The Match on the Far Side

*C · Escort · the Marigold Reach to Heron Stair canoe-road · giver Captain Ocelotl*

**The short version.** The match between Marigold Reach and Heron Stair has been played every spring for two hundred years. This year, a hydra lives between them. Ocelotl intends to play anyway, and needs her team brought across the water.

**What is really going on.** The canoe-road between the cities runs past Xibalbar's hunting-lagoon. The posts that mark the safe channel are carved with the old signs, and a road-warden's map shows two routes: the posted road, short and watched, and the star-road, long and lit by night. A forfeit would be an insult, and a season's honour.

**Scene 1: the training court.**

**OCELOTL:** "Eleven players. Four canoes. One road. We play at the dawn of the festival, or we do not play."
**OCELOTL:** "My cousin says forfeit. My cousin lost a tooth in this game and he *still* says forfeit. I say we play."
**OCELOTL:** "I need someone to get us across. I do not need someone to do the playing."
> ► **"What's the risk?"** — **OCELOTL:** "Something big in the water."
> ► **"What if you lose?"** — **OCELOTL:** "Then we lose on the court. Not on the way."
> ► **"I'll take you."** — **OCELOTL:** "Bring a drum. Out of respect."

**Scene 2: the road.** Four canoes of players, in feathered caps, singing under their breath. The posts are carved with herons, one every hundred strokes. Ahead, the water goes dark and still.

**OCELOTL:** "Keep your paddles quiet. We are a team, not a ceremony."
*Something, below, turns over once. The water rises in a long slow swell, and a trail of bubbles crosses the canoe-road ahead.*
> ► **(Stay on the posted road, silent.)** — The shortest way, and the most exposed.
> ► **(Take the long star-road.)** — Arrive late, but safe.
> ► **(Draw the hunt away with a decoy canoe.)** — A risky job for a very small boat.

**Scene 3: the dawn.** The teams meet on the court at the edge of Heron Stair, the stands thin, the crowd hushed. A single drum starts. The first throw is made. Behind the stands, out on the water, a very large shape surfaces, watches, and sinks.

**OCELOTL:** (grinning, bleeding slightly from the lip) "We made it. Now we have to win."

**Outcomes and receipt.**
- The match is played. The result depends on the road taken; a rested team on the star-road wins narrowly, an exhausted team on the posted road loses with honour, a team that used the decoy wins in a manner that is argued about for years.
- **Receipt:** a ball signed by both teams, hung in the Marigold Reach court, with a carved line beneath it: *We played.*

<!-- quest
id: qst_xoc_match_far_side
title: The Match on the Far Side
rank: C
type: Escort
giver: npc_xoc_ocelotl
region: reg_xochitl_mire
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: xoc_match_far_side_done
summary: A ball team must cross the hydra's hunting-water to play the spring match against a rival city.
objectives:
  talk npc_xoc_ocelotl
  escort npc_xoc_ocelotl
  choice posted_star_or_decoy
-->

---

## 3. A Blanket by Canoe

*C · Delivery · Three Canoes to Reed Crown · giver Old Weaver Teyolia*

**The short version.** A great-grandchild is about to be born in Reed Crown. The grandmother lives in Three Canoes. The canoe-road between them has been cut for a month. Teyolia has woven a blanket and cannot carry it. She has also, for good measure, a basket of letters.

**What is really going on.** The cities are cut off. Messages do not travel. The weaver's blanket is the first package to go in thirty days, and the whole of Three Canoes has noticed. By evening she has been handed forty letters, eleven small gifts and a pot of honey.

**Scene 1: the weaver's house.**

**TEYOLIA:** "Three months of weaving. Blue for the river, white for the foam, a little red at the hem, for the sun."
**TEYOLIA:** "My granddaughter says the birth is in nine days. I am eighty-eight. I will not be paddling."
**TEYOLIA:** "Take it. Please. And forgive the neighbours. They have been *knocking.*"
> ► **"Who else is sending things?"** — **TEYOLIA:** "Everyone. I think I'm the excuse."
> ► **"Is the road safe?"** — **TEYOLIA:** "No. But a blanket does not weigh much."
> ► **"I'll take it."** — **TEYOLIA:** "Tell her it is warm. Tell her it is *from me.*"

**Scene 2: the neighbours.** By dusk, a small crowd has gathered at the weaver's door: a baker with a basket of rolls for her sister, a boy with a letter for his father, an old fisherman who wants only to send a word to a friend he has not spoken to in thirty years.

**NEIGHBOUR:** "It's only a *small* parcel."
**NEIGHBOUR:** "It's only a *short* note."
**NEIGHBOUR:** "Tell him it's only a *little* pie."
*The player's pack grows until the canoe sits low.*
> ► **"I can't carry it all."** — **TEYOLIA:** "Choose with your heart."
> ► **"I'll carry what I can."** — **TEYOLIA:** "That is all anyone does."
> ► **"I'll make two trips."** — **TEYOLIA:** "I did not say that."

**Scene 3: the crossing.** Under a thin moon, the canoe slides along the carved posts. Twice, the water rises in a slow, heavy swell. Once, a very long shape passes beneath, and the canoe rocks in its wake.

> ► **(Cross by night, silent.)** — The quietest way.
> ► **(Cross at dawn, with the flower-boats.)** — The hunt sleeps, a little.
> ► **(Take the long reed-bridge route.)** — Slow, dry, and watched.

**Scene 4: Reed Crown.** The player arrives at the pier at first light. A young woman, heavily pregnant, stands waiting on the steps, holding a lamp.

**GRANDDAUGHTER:** "It is from my grandmother! I know the colours!"
*She unfolds the blanket on the pier, in the dawn, and holds it to her face. Then she reads the first letter aloud to a crowd that has quietly gathered, and begins to cry.*

**Outcomes and receipt.**
- The blanket and the letters arrive. The child is born nine days later, and the first parcel in a month sets off a small, joyful stream of canoes.
- **Receipt:** a line of coloured thread tied to the pier-post at Reed Crown, one strand for every letter that arrived. It is still growing.

<!-- quest
id: qst_xoc_blanket_canoe
title: A Blanket by Canoe
rank: C
type: Delivery
giver: npc_xoc_teyolia
region: reg_xochitl_mire
level: 66
act: 3
requires_rank: C
reward: 4100 | 225 | 15500
sets: xoc_blanket_canoe_done
summary: A grandmother's blanket must cross cut water to reach a great-grandchild, with a whole city's letters in the same canoe.
objectives:
  talk npc_xoc_teyolia
  reach xochitl_reed_crown_pier
  choice night_dawn_or_bridge
-->

---

## 4. The Posts Have Moved

*C · Investigation · the Salt Lantern canoe-road · giver Road-Warden Calli*

**The short version.** Three of the carved posts on the Salt Lantern road have been moved. Not far: a pole's length, no more. Boats following the new line pass half a canoe-length from deep water. Calli has been moving them back every morning. Every night, they move again.

**What is really going on.** An old fisherwoman, Mayel, is moving them. She has watched Xibalbar's hunting for a month and found that the heads strike along the old line. She has been shifting the posts to draw boats just outside its reach. It is a crime to move a post. It is also working: nobody has been taken from the road in eleven days.

**Scene 1: the road-warden's hut.**

**CALLI:** "A post is a promise. It says, *Here is the road.* If it moves, the promise lies."
**CALLI:** "Three moved, a pole's length. Every night. Someone is meddling with the road."
**CALLI:** "It is probably a child. Or a rival warden. Or a *smuggler.*"
> ► **"Why would anyone move posts?"** — **CALLI:** "To rob a boat."
> ► **"Is anyone hurt?"** — **CALLI:** "No. That's what bothers me."
> ► **"I'll watch tonight."** — **CALLI:** "I'll bring a lantern. And a stern face."

**Evidence.**
- **The new line** runs almost exactly parallel to the old, a pole's length to the east, away from the deep channel.
- **The marks** on the posts show they were moved by a lever, gently, with a padded pole.
- **A small canoe** with a single paddler has been seen on the road each evening, at the turn of the tide.
- **The nearest hut** belongs to Mayel, who has not fished in a month.

**Scene 2: the vigil.** At moonrise, the player lies in the reeds. A tiny canoe slides out, paddled by an old woman in a straw hat. She stops at a post, wedges a pole under its base, and leans.

**MAYEL:** "You have been there a while. I heard you breathing. You breathe like a young man."
**MAYEL:** "I am doing no harm."
**MAYEL:** "The big one sits *there* on the ebb. See the swirl? Boats on the old line pass over its mouth. I've moved the line. I should have asked. But who do you ask?"
> ► **"You'll be fined."** — **MAYEL:** "Then fine me."
> ► **"It's working."** — **MAYEL:** "Eleven days."
> ► **"Why not tell Calli?"** — **MAYEL:** "He would have *measured* it."

**Scene 3: the choice.** The wardens' law is strict. A moved post is a broken promise. But the new line has saved lives.

> ► **(Report Mayel to the wardens.)** — The posts are moved back and the old line stands. Mayel is fined.
> ► **(Bring Calli to see the swirl himself.)** — The warden changes his mind.
> ► **(Help Mayel carve proper new posts.)** — The line is made official, with a new sign.

**CALLI:** (standing on the old line at the ebb, watching the swirl) "...That is a *mouth.*"
**MAYEL:** "I did say."
**CALLI:** "You did not say it in the form of a *petition.*"

**Outcomes and receipt.**
- The Salt Lantern road is re-posted on Mayel's line, and the wardens enter her name in the road-book as its "second hand". If she was reported, the old line stands for a month, and two boats are lost to the shallows before it is changed.
- **Receipt:** three new posts, carved with a small straw hat beneath the sign of the heron.

<!-- quest
id: qst_xoc_posts_moved
title: The Posts Have Moved
rank: C
type: Investigation
giver: npc_xoc_calli
region: reg_xochitl_mire
level: 69
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: xoc_posts_moved_done
summary: Someone is moving the canoe-road posts at night. The new line is a little safer.
objectives:
  talk npc_xoc_calli
  talk npc_xoc_mayel
  choice report_show_or_carve
-->

---

## 5. Clay Beans

*C · OddJob · the Heron Stair market · giver Market-Judge Cozcatl*

**The short version.** Cacao beans are money in the Mire. Someone has been paying for fish with beans made of baked clay, painted to match. Cozcatl has thirty sacks of them and an angry fish-market.

**What is really going on.** The forger is a potter named Papalotl, whose seven children are hungry. With the canoe-roads cut, real beans have grown scarce, and the market has run out of small change. Papalotl made his first batch for a child's game. Someone offered to buy them. The market, to be fair, has been quietly using them for a week.

**Scene 1: the market-judge's stall.**

**COZCATL:** "In thirty years I have never been cheated of a bean. And now I have been cheated of *three hundred.*"
**COZCATL:** "They are very good. The colour is right. The weight is right. The *sound* is right. It is a work of *art.*"
**COZCATL:** "I would like to arrest the man. And possibly shake his hand."
> ► **"Where did they come from?"** — **COZCATL:** "A potter. We think."
> ► **"What's the penalty?"** — **COZCATL:** "Forgery of the cacao is the worst crime a market knows."
> ► **"I'll find him."** — **COZCATL:** "Be gentle. I think he is a *good* forger."

**Scene 2: the potter.** On the lower canal, a broad, anxious man is feeding seven children from a single pot of beans, the real kind.

**PAPALOTL:** "I only made a few. For the little ones' game. They were so *pretty.*"
**PAPALOTL:** "Then the baker asked for a handful. For change. She had no change. Nobody has any change."
**PAPALOTL:** "I did not mean it as *money.* It became money."
> ► **"Why not stop?"** — **PAPALOTL:** "Have you seen the price of a fish?"
> ► **"What if the market asked for them?"** — **PAPALOTL:** (a long pause) "...Asked?"
> ► **"Show me the kiln."** — **PAPALOTL:** "It is my children's, mostly."

**Scene 3: the options.** Cozcatl cannot excuse the forgery. But a market without small change will not last the season.

> ► **(Arrest Papalotl.)** — The law is upheld, and the market runs short.
> ► **(Propose a market-stamped clay token.)** — Official small change, marked with the Heron Stair sign.
> ► **(Collect the beans and give them back as toys.)** — The fish-sellers grumble.

**COZCATL:** "...A token. Stamped. Valued at a tenth of a bean. Redeemable at the market-house."
**PAPALOTL:** "My children will be *rich.*"
**COZCATL:** "Your children will be *licensed.*"

**Outcomes and receipt.**
- The beans become tokens, and Papalotl becomes the market's licensed token-maker. If he was arrested, the market goes without small change for a fortnight, and Cozcatl, privately, appeals for his release.
- **Receipt:** a little clay token on a string in the market-house, stamped with a heron and a kiln.

<!-- quest
id: qst_xoc_clay_beans
title: Clay Beans
rank: C
type: OddJob
giver: npc_xoc_cozcatl
region: reg_xochitl_mire
level: 73
act: 3
requires_rank: C
reward: 4600 | 255 | 17000
sets: xoc_clay_beans_done
summary: A market is flooded with baked-clay cacao beans, made by a potter who just wanted to feed his children.
objectives:
  talk npc_xoc_cozcatl
  talk npc_xoc_papalotl
  choice arrest_token_or_return
-->

---

## 6. The Priest Who Came Back

*B · Investigation · Reed Crown and the Feeding Steps · giver Steward Ihuitl*

**The short version.** An old priest has come home to Reed Crown, driven out a generation ago when the feeding rites were abandoned as barbaric. He wants to restore them. Half the city is horrified. The other half is quietly frightened. The king wants to know what the rites actually were.

**What is really going on.** The rites were offerings: maize, flowers, jade, and a day's labour from every family to dredge the lagoon channels. They were gentle and orderly. What made them hateful was the last river-king's addition: the **Pledging**, in which each family gave a child to serve the temple for life. The city did not abandon the feeding. It abandoned the Pledging, and the feeding went with it, because nobody was sure which was which.

**Scene 1: the steward.**

**IHUITL:** "The old priest says the swamp slept because we fed it. The king says that is superstition. I say I would like the king to ask someone who was there."
**IHUITL:** "I am told the rites were barbaric. I have never read a line of them."
**IHUITL:** "Mecatl will tell you. He will tell you *everything.* That is the difficulty."
> ► **"What does the city fear?"** — **IHUITL:** "That he is right."
> ► **"What does the king fear?"** — **IHUITL:** "That he is wrong."
> ► **"I'll talk to him."** — **IHUITL:** "Bring something to eat. He's very thin."

**Scene 2: Mecatl.** On the temple steps, an old man sits with a basket of maize cakes.

**MECATL:** "I fed the lagoon for forty years. Cakes, flowers, a bit of jade. I was never afraid of it. It was like feeding a very large, very quiet guest."
**MECATL:** "Then the king added the Pledging. A child from each house. To serve at the Steps. For life."
**MECATL:** "I said no. I was sent away. The priests who stayed stopped the whole thing, to be safe, and the whole thing stopped, and so did the Pledging, and so did everything else."
**MECATL:** "I do not want the Pledging. I want the cakes."
> ► **"Is that all the rite was?"** — **MECATL:** "That is all it was *for.*"
> ► **"Will feeding it stop the hydra?"** — **MECATL:** "I do not know. Nobody knows. That is the honest answer."
> ► **"Show me the Steps."** — **MECATL:** "They are under the weeds."

**Scene 3: the Feeding Steps.** At the lagoon's edge, a broad stair of carved stone leads down into dark water. On the walls, under centuries of moss, the player scrubs a patch clean: a frieze of families, in procession, carrying baskets and bundles. At the bottom, a line of reeds. Nothing else.

*There is no mention of a Pledging. It was added later, on a different stone, in a different hand.*

> ► **(Report to the king that the rites were gentle.)** — Mecatl is allowed to offer maize and flowers at dawn.
> ► **(Report that the Pledging was added later.)** — The city begins to argue about its own history.
> ► **(Say nothing; let Mecatl feed the lagoon alone.)** — He climbs down at dawn with a basket.

**MECATL:** (setting down a cake on the lowest step, very quietly) "Here. This is for you. I am sorry it has been so long."
*The water does not move. After a long time, a single ripple crosses the lagoon, from the far side to the near, and fades.*

**Outcomes and receipt.**
- The king allows a trial feeding: maize, flowers, and a day's dredging per family, and no Pledging. No one knows what, if anything, it will do. If the player kept silent, Mecatl feeds the lagoon alone, and a handful of fishermen, one by one, come down to join him.
- **Receipt:** a basket on the lowest Feeding Step, replaced every dawn. No one sees it empty.

<!-- quest
id: qst_xoc_priest_came_back
title: The Priest Who Came Back
rank: B
type: Investigation
giver: npc_xoc_ihuitl
region: reg_xochitl_mire
level: 90
act: 4
requires_rank: B
reward: 10400 | 610 | 45000
sets: xoc_priest_back_done
summary: An exiled priest wants to restore the feeding rites. The city does not know what they really were.
objectives:
  talk npc_xoc_ihuitl
  talk npc_xoc_mecatl
  reach xochitl_feeding_steps
  choice report_pledging_or_silence
-->

---

## 7. What the Star-Counters Saw

*B · Exploration · the Star Tower · giver Star-Counter Yolotli*

**The short version.** The Star Tower's astronomers say the stars explain why the hydra woke. The old observatory at Marigold Reach says they do not. Yolotli has two sets of tables that should disagree and do not, and she is afraid to say what they agree on.

**What is really going on.** The two observatories count their days differently: one from sunrise, one from sunset. When the tables are lined up properly, a pattern appears. The hydra hunts hardest on the nights of the dark moon, and its worst hunts follow a long count that began exactly when the rites stopped. The pattern does not say why it woke. It says *when to stay indoors.*

**Scene 1: the tower.**

**YOLOTLI:** "Two sets of tables. Eighty years of nights. They *should* disagree. They don't."
**YOLOTLI:** "Old Nochtli says I have made a mistake. I have checked it nine times."
**YOLOTLI:** "If it is what I think it is, it is the first useful thing the stars have told us in a generation. And I am afraid to publish it."
> ► **"Why afraid?"** — **YOLOTLI:** "Because people will act on it. And if I am wrong, they will die for me."
> ► **"What do the tables say?"** — **YOLOTLI:** "Stay home on the dark moon."
> ► **"Show me."** — **YOLOTLI:** "Bring a cup of cacao. It's a long night."

**Scene 2: the comparison.** The player spends a night in the tower with Yolotli and a stack of knotted cords. The two sets of tables seem to say nothing alike, until Yolotli notices that one counts the day from dawn and one from dusk.

*The cords, shifted by half a day, line up. A line of dark-moon nights stretches back through eighty years, each one marked, in the margins of the older tables, with a tiny drawing of a boat.*
> ► **"They've been recording the boats."** — **YOLOTLI:** "Lost boats. Every dark moon. For eighty years."
> ► **"Before the rites stopped?"** — **YOLOTLI:** "Fewer. Almost none."
> ► **"What does Nochtli say?"** — **YOLOTLI:** "He has always known. He thought it was a coincidence."

**Scene 3: Nochtli.** At Marigold Reach, a stately old man in a feathered cape receives the news with great composure.

**NOCHTLI:** "Young woman, you have used the dusk-count, which is *vulgar.*"
**YOLOTLI:** "And it is *right.*"
**NOCHTLI:** (after a long silence) "...Yes. I rather think it is."
*He unrolls a scroll, a third set of tables, hidden in his own study for forty years, and sets it on the table beside hers.*

> ► **(Publish the pattern openly to every city.)** — The canoe-roads empty on dark-moon nights.
> ► **(Give it to the league and let them decide.)** — Slower, and more orderly.
> ► **(Wait one more dark moon to confirm.)** — Safer for the truth, and less safe for travellers.

**Outcomes and receipt.**
- The cities learn to keep in on dark-moon nights, and the canoe-roads grow quiet on schedule. If the pattern was held back, three boats are lost in the following month. Nochtli and Yolotli publish their joint tables under both names.
- **Receipt:** a painted moon-stone at every canoe-road junction, black on the dark nights, with a small boat drawn in white and the words: *Not tonight.*

<!-- quest
id: qst_xoc_star_counters
title: What the Star-Counters Saw
rank: B
type: Exploration
giver: npc_xoc_yolotli
region: reg_xochitl_mire
level: 94
act: 4
requires_rank: B
reward: 11000 | 640 | 47000
sets: xoc_star_counters_done
summary: Two observatories' tables, lined up by half a day, show the hydra hunts hardest on dark-moon nights.
objectives:
  talk npc_xoc_yolotli
  reach xochitl_star_tower_tables
  talk npc_xoc_nochtli
  choice publish_league_or_wait
-->

---

## 8. Flowers for the Night Causeway

*B · Defense · the night flower market at Marigold Reach · giver Market-Warden Tlali*

**The short version.** Every morning, flowers go onto the canals. Every night, they are sold at the Night Causeway, a mile of stalls on a stone road above the lagoon. The hydra has started to probe the Causeway from the water. Tlali refuses to close it. If the flowers do not go out, the offering is short, and everyone remembers what that means.

**What is really going on.** The Causeway runs along the southern edge of the hunting-lagoon. The heads do not attack the stalls; they test the edge, curious and slow. If a stall is shaken, or a lantern falls, they strike. The fight is to keep the market calm while four hundred sellers load their barges in the dark.

**Scene 1: the causeway.**

**TLALI:** "Four hundred stalls. Marigolds, lilies, the river-orchid, every colour the city will lay at its door tomorrow."
**TLALI:** "If I close the market, we have no flowers. If we have no flowers, there is no offering. I have never been short."
**TLALI:** "Tonight there are three heads on the south side, and they are *looking.*"
> ► **"What do they do?"** — **TLALI:** "Nothing. Yet."
> ► **"What do you need?"** — **TLALI:** "A line of people who do not shout."
> ► **"I'll hold the south side."** — **TLALI:** "Do it quietly. And stand upwind of the lilies."

**Scene 2: the night.** The market is a long, bright river of lantern light. Sellers move among the stalls with soft voices, passing baskets hand to hand. From the lagoon, a slow, wet sound, then the slide of a long neck over stone.

*Three things go wrong at once.*
- **A lantern falls** at stall ninety and the oil begins to spread.
- **A barge slips its mooring** and drifts toward the south side.
- **A child, calling for her mother,** runs out onto the causeway edge.

> ► **(Put out the fire, quietly.)** — Sand, a wet cloth, a calm voice.
> ► **(Catch the barge.)** — A quick, wet scramble.
> ► **(Get the child.)** — A long dive, a short shout.

**TLALI:** "Do not run! Do not shout! Pass the baskets inward!"
*Four hundred sellers, in the dark, slowly pick up their wares and turn their backs to the water. The nearest head hangs above the stalls, swaying. It looks at the marigolds. It lowers itself, slowly, back into the lagoon.*

**Scene 3: the dawn.** The barges set out in the first grey light, low in the water, heaped with flowers. The offering goes out on time.

> ► **(Build a floating reed screen along the south edge.)** — A long-term defence, and a beautiful one.
> ► **(Move the market inward, behind the stalls.)** — Less dramatic, and safer.
> ► **(Leave it as it is.)** — Brave, and a little foolish.

**Outcomes and receipt.**
- The flowers go out on time and nobody is hurt. The market is made safer by the choice made: a screen of woven reed, a shorter causeway, or nothing at all.
- **Receipt:** a line of floating reed-lanterns along the south edge of the Night Causeway, lit at dusk. They are called the Quiet Row.

<!-- quest
id: qst_xoc_night_causeway
title: Flowers for the Night Causeway
rank: B
type: Defense
giver: npc_xoc_tlali
region: reg_xochitl_mire
level: 98
act: 4
requires_rank: B
reward: 11800 | 680 | 49500
sets: xoc_night_causeway_done
summary: The night flower market runs beside the hydra's lagoon. Four hundred sellers must load the morning offering without a sound.
objectives:
  talk npc_xoc_tlali
  defend xochitl_night_causeway
  choice fire_barge_or_child
-->

---

## 9. The Ring of Equal Water

*B · Faction · Three Canoes · giver League Herald Cuicatl*

**The short version.** For the first time in a generation the league of river-cities is meeting. The tradition is a ring of canoes, with the most honoured king seated nearest the Feeding Steps. Nobody wants the honour any more. Five kings have declined the head seat in as many different ways.

**What is really going on.** Each king is quietly afraid of sitting nearest the lagoon, and none will admit it. The herald has until the day of the league to find a seating that is honourable, fair, and not within sight of the hydra's water.

**Scene 1: the herald's canoe.**

**CUICATL:** "Five kings! Five *dignities!* Five seats, and the best of them is the *worst!*"
**CUICATL:** "Marigold Reach says it is too humble. Heron Stair says it is too grand. Reed Crown says it has a bad back. Salt Lantern says it will sit wherever Three Canoes sits, which is a *lie,* and Three Canoes says nothing at all."
**CUICATL:** "I am a herald. I announce. I am *not* a *diplomat.*"
> ► **"What if there's no head?"** — **CUICATL:** "There is *always* a head!"
> ► **"What does tradition say?"** — **CUICATL:** "That the nearest seat is the most honoured. And no one wants to be *honoured.*"
> ► **"I'll help."** — **CUICATL:** "Bless you. Bring a very large pot of cacao."

**Scene 2: the kings.** The player visits the five kings, each in their own canoe, each with a different worry.

- **The King of Marigold Reach** wants not to be accused of being proud.
- **The King of Heron Stair** wants not to be accused of being afraid.
- **The Queen of Reed Crown** wants to be seated well away from the Steps, for reasons she does not state.
- **The King of Salt Lantern** wants whoever sits near the Steps to be a person he trusts.
- **The Queen of Three Canoes** wants nothing, and is therefore the most frightening.

**QUEEN OF THREE CANOES:** "I have noticed that nobody asked me what I wanted."
> ► **"What do you want?"** — **QUEEN:** "A ring that does not rank us."
> ► **"What does a ring without rank look like?"** — **QUEEN:** "...A circle. Lashed. No head."
> ► **"Thank you."** — **QUEEN:** "You are the first to say it."

**Scene 3: the ring.** The player has three ways to seat the kings.
- **The lashed ring:** all five canoes tied rim to rim, no head.
- **The lot:** each king draws a cacao bean from a bowl; the lowest draws the head seat.
- **The feast:** a meal laid on a central raft, with the kings seated by how late they arrive.

> ► **(Lash the canoes in a ring.)** — The Queen of Three Canoes smiles.
> ► **(Draw lots.)** — The King of Marigold Reach draws the head seat, and visibly pales.
> ► **(Hold a feast.)** — Chaotic, loud, and surprisingly effective.

**CUICATL:** (raising a conch, in a faint voice) "The league is... *seated.*"
*Five canoes rock gently together in the evening light. For the first time in a generation, five kings are looking at one another across a very small stretch of water.*

**Outcomes and receipt.**
- The league meets. The shape of the ring decides how the meeting goes: a lashed ring produces the first agreement in years, lots produce honest grumbling, and the feast produces a surprising number of marriages.
- **Receipt:** a ring of five posts in the Three Canoes lagoon, each carved with a city's sign, set rim to rim. It is called the Ring of Equal Water.

<!-- quest
id: qst_xoc_ring_equal_water
title: The Ring of Equal Water
rank: B
type: Faction
giver: npc_xoc_cuicatl
region: reg_xochitl_mire
level: 102
act: 4
requires_rank: B
requires_quests: qst_xoc_blanket_canoe
reward: 12400 | 710 | 52000
sets: xoc_ring_water_done
summary: The league of river-cities meets for the first time in a generation, and no king wants the most honoured seat.
objectives:
  talk npc_xoc_cuicatl
  reach xochitl_three_canoes_ring
  choice lash_lot_or_feast
-->

---

## 10. The Boy Who Stopped Feeding the River

*B · Escort · the Salt Lantern channel · giver Ayotl*

**The short version.** Ten-year-old Ayotl has stopped putting flowers on the water. He says the river takes things and does not give them back. His father has been missing for nineteen days. Ayotl is certain he is on the old reed island at the end of the channel, and no one will take him there.

**What is really going on.** He is right. Itzmin is alive on a mud island, catching enough fish to keep a very small fire. His canoe is gone. The channel to the island runs past the hydra's hunting-water, and the only safe time to cross is the slack of the ebb.

**Scene 1: the pier.**

**AYOTL:** "I put a flower on the water every morning. Every morning. And it took him."
**AYOTL:** "My mother says it doesn't work like that. But *I* put the flower, and *then* it took him."
**AYOTL:** "I'm not doing it any more. Not until he's back."
> ► **"What do you think happened?"** — **AYOTL:** "He's on the island. I can *feel* it."
> ► **"What does your mother say?"** — **AYOTL:** "That he's gone. But she keeps his bowl out."
> ► **"I'll take you."** — **AYOTL:** "You'll take me? Really?"

**Scene 2: the crossing.** At the slack of the ebb, the player poles a small canoe along the channel. Ayotl sits in the bow, silent. The reeds close in on either side. Somewhere ahead, a long wet shape lifts and settles.

**AYOTL:** "Shh."
*The canoe drifts. A head rises beside it, enormous and still, and looks down at them through the reeds. It does not strike. It watches for a long breath, and then slowly sinks.*
> ► **(Pole through at the slack, silent.)** — The shortest, hardest way.
> ► **(Cut across the reed-beds on foot.)** — Slow, but out of sight.
> ► **(Float a flower-boat as a distraction.)** — Ayotl must decide.

**Scene 3: the island.** At the end of the channel, a mud island the size of a market-stall. A thin plume of smoke rises from a fire the size of a hand. A bearded man in a ragged cloak turns, and stares, and drops his fishing line.

**ITZMIN:** "Ayotl?"
**AYOTL:** "You didn't come home."
**ITZMIN:** "I couldn't. The canoe..."
**AYOTL:** "I know. I know. I came."
*The boy does not run, at first. He stands very still. Then he does, all at once, in the mud, with a sound like a small animal.*

**Scene 4: the flower.** On the way back, at the mouth of the channel, Ayotl takes a small blue flower from his pocket, crushed from the journey. He looks at it for a long time.

> ► **(Say nothing.)** — He decides for himself.
> ► **(Tell him it's all right if he doesn't.)** — He nods.
> ► **(Tell him thank you is not the same as please.)** — He thinks about it.

*He sets it on the water. It floats, slowly, away toward the dark lagoon.*

**AYOTL:** "That one's for saying *thank you.*"

**Outcomes and receipt.**
- Father and son return. Ayotl floats flowers again, but never in the way he did before: now each one is for something. If the player said nothing, he keeps the habit of silence for a month and then, one morning, begins to talk to the river.
- **Receipt:** a tiny canoe carved from a single reed, on Ayotl's windowsill, with a flower in it. The Salt Lantern road-wardens add a post at the island's mouth, carved with a small reed hut.

<!-- quest
id: qst_xoc_boy_stopped_feeding
title: The Boy Who Stopped Feeding the River
rank: B
type: Escort
giver: npc_xoc_ayotl
region: reg_xochitl_mire
level: 106
act: 4
requires_rank: B
reward: 13000 | 760 | 56000
sets: xoc_boy_feeding_done
summary: A grieving boy has stopped putting flowers on the water. His father is alive on a mud island at the end of the channel.
objectives:
  talk npc_xoc_ayotl
  escort npc_xoc_ayotl
  reach xochitl_salt_lantern_reed_island
  choice pole_walk_or_flower
-->
