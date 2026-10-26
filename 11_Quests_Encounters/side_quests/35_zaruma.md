# 11e-35 — Zaruma, the Gold Road: Ten Side Quests (draft)

> *"Generosity is a sacred duty. A king who hoards is soon replaced."*
> — Gazetteer, Zaruma

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 3 and 6 plant unexplained seeds.

**Region:** `reg_zaruma` (the gold-road towns at the wells, the Golden Mile, the Griots' Baobab, the Southern Mines). **Rank band:** B-A (data band B-A; the region is `besieged`). **Tone:** proud, hospitable, argumentative, musical; wealth that is only worth anything when it is given away.

**Placement notes.**
- **Mansacor, the Gold-Eating Manticore,** is the region's Tyrant. It eats the gold first and then the caravaneers, and its hide is flecked with gold. **No quest here kills, drives off or defeats Mansacor.** It is heard, seen at a distance or fed a decoy; the road stays dangerous. Quest 9 (`Defense`) fights a *lesser* chimera pack, not the Tyrant, and no quest uses `SiegeDefence`.
- **Open points left alone.** The griot hook's forgotten verse is *said to name the manticore's weakness;* quest 3 never recovers that line. The miner hook's seam the manticore will not touch (quest 6) is **not explained.**
- Customs the quests rely on: towns stand at **wells** along the gold road; **griots** keep history, genealogy and song, and every noble family has one; **generosity is a sacred duty** and a king who hoards is replaced; the **miners of the south** are a separate people with their own language who guard the mines' secrets; kings make pilgrimages and give gold away; the road trades **gold, salt, ivory, cloth, books and kola nuts.**
- Rewards follow the B and A rows of `Data/World/guild_ranks.json` and the neighbouring files (Moraveil, Whitewater Reach).

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | Heavier Than Their Camels | B | Escort | Caravan-Master Ibori Dakar | Tense-comic: a decoy caravan |
| 2 | The Open Hand's Ledger | B | Faction | Elder-Treasurer Mosi Kamarah | Dilemma: a generous king with an empty hand |
| 3 | The Missing Verse | B | Investigation | Griot Fantah Koroma | Mystery: a song with a hole in it |
| 4 | The Well Won't Be Hurried | B | OddJob | Well-Warden Abeni Tafari | Warm-comic: two caravans, one well |
| 5 | Kola Before Dark | B | Delivery | Carter Bahati Dube | Race: a naming day and a long road |
| 6 | The Seam It Will Not Touch | A | Hidden | Delver Sheka Nyambura | Strange: an unexplained seed |
| 7 | The Golden Mile by Night | A | Exploration | Mother Adwoa Lemba | Quiet: a road that remembers |
| 8 | The Griot's Apprentice | A | Companion | Zola Marimba | Tender: a girl who forgets |
| 9 | Market Day at the Well | A | Defense | Market-Marshal Rashidi Ngoma | Action: a lesser pack at the market |
| 10 | The Test of the Open Hand | A | Divine | Day-Priest Tendai Olufemi | Contemplative: a gift that must cost |

## Cast

<!-- npc
id: npc_ibori_dakar
name: Caravan-Master Ibori Dakar
tier: major
race: Human
region: reg_zaruma
settlement: Zaruma gold-road towns
role: Caravan-master of the northern run
backstory: A broad, weathered caravan-master of fifty who has lost nine camels, two guards and one very good cook to the gold road, and who has finally decided to cheat the thing that keeps eating them.
-->
<!-- npc
id: npc_mosi_kamarah
name: Elder-Treasurer Mosi Kamarah
tier: major
race: Human
region: reg_zaruma
settlement: Zaruma gold-road towns
role: Treasurer of the council of elders
backstory: A neat, anxious treasurer of the council of elders who has watched the royal vault empty for two years and has not found a way to tell a generous king that he cannot afford to be.
-->
<!-- npc
id: npc_fantah_koroma
name: Griot Fantah Koroma
tier: major
race: Human
region: reg_zaruma
settlement: Griots' Baobab
role: Griot of the founding song
backstory: A large, courteous griot who has sung the kingdom's founding song for forty years without once missing a line, until the night he reached the fourth verse and found it was not there.
-->
<!-- npc
id: npc_abeni_tafari
name: Well-Warden Abeni Tafari
tier: townsfolk
race: Human
region: reg_zaruma
settlement: Zaruma gold-road towns
role: Warden of a town well
backstory: A formidable, laughing well-warden who has settled sixty years of disputes over a single well and who will hear no argument that is not first offered a cup of water.
-->
<!-- npc
id: npc_bahati_dube
name: Carter Bahati Dube
tier: townsfolk
race: Human
region: reg_zaruma
settlement: Zaruma gold-road towns
role: Kola carter
backstory: A wiry carter with a cracked cart-wheel and a promise to deliver kola nuts to a naming ceremony before sunrise, whose grandmother will not name the child without them.
-->
<!-- npc
id: npc_sheka_nyambura
name: Delver Sheka Nyambura
tier: major
race: Human
region: reg_zaruma
settlement: The Southern Mines
role: Miner of the southern hills
backstory: A watchful, quiet miner of the southern people who speaks the mine-tongue first and the trade-tongue only when she has to, and who has found a seam she is afraid to tell anyone about.
-->
<!-- npc
id: npc_adwoa_lemba
name: Mother Adwoa Lemba
tier: major
race: Human
region: reg_zaruma
settlement: Griots' Baobab
role: Elder griot of the road songs
backstory: An old, small, formidable griot with a voice like a rusted bell who has sung every mile of the gold road but one, and who intends to sing that one before she dies.
-->
<!-- npc
id: npc_zola_marimba
name: Zola Marimba
tier: townsfolk
race: Human
region: reg_zaruma
settlement: Griots' Baobab
role: Griot's apprentice
backstory: A bright, anxious ten-year-old kora player who can play anything she has heard once and cannot remember her own family genealogy for longer than a day.
-->
<!-- npc
id: npc_rashidi_ngoma
name: Market-Marshal Rashidi Ngoma
tier: major
race: Human
region: reg_zaruma
settlement: Zaruma gold-road towns
role: Marshal of a gold-road market
backstory: A big, genial market-marshal who has kept the peace of the biggest well-town market for twenty years with a bell, a smile and a reputation for fairness.
-->
<!-- npc
id: npc_tendai_olufemi
name: Day-Priest Tendai Olufemi
tier: major
race: Human
region: reg_zaruma
settlement: Zaruma gold-road towns
role: Priest of the day-gods
backstory: A calm, dry-humoured priest of the day-gods' temple at the largest well-city, who believes generosity is a muscle and has put a good many pilgrims through its exercises.
-->

---

## 1. Heavier Than Their Camels

*B · Escort · the gold road, north run · giver Caravan-Master Ibori Dakar*

**The short version.** Ibori has lost nine camels, two guards and one very good cook to the gold road. This season he has a plan: a decoy caravan of gilded lead, ten camels heavy with worthless ballast, to draw the thing that eats gold off the real caravan's road. He needs an escort for the decoy.

**What is really going on.** The plan will work for one pass and one pass only. The manticore is not stupid; it is hungry, and a hungry mind learns. The decoy's escort must also do the cruel thing: keep the crew from knowing how close the creature is. The hard choice is how to treat the decoy's drovers, who are being paid to lead a bait.

**Scene 1: the yard.**

**IBORI:** "Look at them. Ten camels. All of them walking a little heavier than they need to."
**IBORI:** "Gilded lead. Gold on the outside, the rest of it a very expensive lie."
**IBORI:** "It eats the gold first. I'd like to give it something to eat that isn't mine."
> ► **"What about the drovers?"** — **IBORI:** "They're told it's a decoy. They're paid triple."
> ► **"It'll learn."** — **IBORI:** "Then we'll have one clean run."
> ► **"I'll escort."** — **IBORI:** "Stay near the lead camel. She has opinions."

**Scene 2: the road.** The decoy sets out at dawn under red dust. The drovers, lean and silent, sing a work-song to keep their nerve. By noon a tight line of vultures is circling overhead.

**DROVER:** "They know."
**DROVER:** "They always know."
**DROVER:** "Is it true it laughs?"
> ► **"It laughs."** — The drover goes pale.
> ► **"Don't think about it."** — The drover tries.
> ► **"Sing louder."** — The song swells.

**Scene 3: the pass.** At the narrows by the dry riverbed the road bends, and from the scrub comes a long, low, golden shape, a lion's body, a scorpion's tail curled over its back, a man's face fixed in a permanent grin. It stops at fifty paces. It sniffs. It looks at the gilded loads and then at the player.

**MANTICORE (a warm, ruinous, almost friendly voice):** "*Gold.* How kind."
> ► **(Stand your ground.)** — The beast pads forward.
> ► **(Cut the decoy loose.)** — The ropes fall, the camels bolt.
> ► **(Offer it the lead camel's pack.)** — A bribe.

It takes the gilded load in its jaws, tears the pack, and the first flake of lead falls out. It stops, puzzled. Then it laughs, a cold, human chuckle, drops the pack and pads off into the scrub, in no hurry at all.

**IBORI (later, shaking):** "It *knew.*"
**IBORI:** "It let us go. It let us *go.*"

**Scene 4: the gate.** The decoy reaches the next town intact. The real caravan, three days behind, takes the dry riverbed path unharmed. Ibori drinks a cup of water with a hand that shakes only a little.

**IBORI:** "One clean run. That's all I wanted."
**IBORI:** "It'll know better next time."

**Afterword: the cook.** In the evening Ibori finally asks the question he has been avoiding: which of the drovers should he thank, and how. The player can tell him the truth, that the song kept the line steady when nobody would admit to being afraid, and watch him quietly raise their pay. The gilded brick on his gate is joined by a smaller one marked with the name of the camel that bolted, and was, to everyone's surprise, the first to come home.

**Outcomes and receipt.**
- The caravan passes. If the player cut the decoy loose, two camels are lost but no drovers; if they bribed the beast, the drovers are shaken but whole. **Mansacor is not harmed and not driven off;** it learns the trick.
- **Receipt:** a gilded lead brick on Ibori's yard gate, labelled *One Clean Run;* the drovers' work-song gains a new verse.

<!-- quest
id: qst_zrm_heavier_camels
title: Heavier Than Their Camels
rank: B
type: Escort
giver: npc_ibori_dakar
region: reg_zaruma
level: 88
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: zrm_decoy_done
summary: A caravan-master sends a decoy of gilded lead down the gold road to give the gold-eating manticore something to chew on.
objectives:
  talk npc_ibori_dakar
  escort npc_ibori_dakar
  choice stand_cut_or_bribe
-->

---

## 2. The Open Hand's Ledger

*B · Faction · the royal city · giver Elder-Treasurer Mosi Kamarah*

**The short version.** The king is generous, which is the law. He is also running out of gold. Mosi cannot tell him so; a king who hoards is replaced, and the council fears that a king who is told he is poor will start to hoard. He needs someone to find a way for the king to remain generous while the vault refills.

**What is really going on.** The king is not a fool. He has been giving away more than he takes because the road is closed, and his people, who need his gifts more than ever, would be hurt by a king who stopped. The problem is not money; it is *what generosity means* when you have no gold.

**Scene 1: the vault.**

**MOSI:** "Two years ago the vault held eleven thousand weights. Now it holds four."
**MOSI:** "The king gives to every pilgrim, every widow, every singer. It is his duty."
**MOSI:** "If I tell him, he will stop. If he stops, they'll say he hoards. And then..."
> ► **"What does the council say?"** — **MOSI:** "That I should find a solution."
> ► **"What does the king say?"** — **MOSI:** "That I worry too much."
> ► **"I'll find one."** — **MOSI:** "I am grateful. Please be gentle."

**Scene 2: the elders.** The council meets under an awning of woven grass. A dozen elders, each with a griot at their shoulder, listen with the courtesy of people who disagree.

**ELDER 1:** "Raise the road tax."
**ELDER 2:** "On a closed road? Fool."
**ELDER 3:** "Give less."
**ELDER 1:** "And be called a *hoarder?*"
> ► **"Give differently."** — **ELDER 3:** "What does that mean?"
> ► **"Ask the merchants."** — **ELDER 2:** "They'll want something."
> ► **"Ask the king."** — **ELDER 1:** "He'll give it away."

**Scene 3: the audience.** The king, a tall, gentle man of sixty, receives the player in a courtyard hung with indigo. He is not a fool; he knows.

**KING:** "I know the vault, Mosi. I count it myself, at night."
**KING:** "A king who gives gold he has not got is a thief. A king who gives nothing is a hoarder. What is a king who gives *time?*"
> ► **"A king who sits with petitioners."** — The king ponders.
> ► **"A king who opens the libraries."** — A bright idea.
> ► **"A king who sends his griots to the poor."** — A cheaper song.

**Scene 4: the new ledger.** The council adopts a plan: the king will give less gold and more *presence;* the libraries will open their reading rooms to the poor, the royal griots will sing in the market and the royal granary will feed the hungry. The vault will refill, slowly, with the road's return. The griots compose a verse.

**MOSI:** "It is not the same as gold."
**KING:** "It is not. But it is not a hoard."

**Afterword: the reading room.** The first reading room opens in the north tower of the royal library, with benches, tallow candles and a griot to read aloud for those who cannot. The poor come cautiously at first and then in numbers. Mosi stands at the door counting heads out of habit, loses count, and writes on his ledger beside the new column: *More than I can add.* The king visits unannounced, sits at the back, and falls asleep during a sad poem.

**Outcomes and receipt.**
- A new custom of royal giving begins. If the player proposed the libraries, a reading room opens to the poor within the month; if the griots, a new song spreads along the road. The vault stays low.
- **Receipt:** a small brass ledger in Mosi's desk with a new column headed *Given Without Weight;* a song about the king who gave his hours.

<!-- quest
id: qst_zrm_open_hand
title: The Open Hand's Ledger
rank: B
type: Faction
giver: npc_mosi_kamarah
region: reg_zaruma
level: 92
act: 4
requires_rank: B
reward: 10800 | 640 | 46000
sets: zrm_ledger_done
summary: The generous king is running out of gold, and the treasurer cannot tell him without making him a hoarder.
objectives:
  talk npc_mosi_kamarah
  reach zaruma_royal_courtyard
  choice presence_libraries_or_songs
-->

---

## 3. The Missing Verse

*B · Investigation · the Griots' Baobab · giver Griot Fantah Koroma*

**The short version.** The kingdom's founding song has seven verses. Fantah has sung all seven for forty years. Last week, at the fourth, his voice simply... went round it. He cannot remember the verse. By the old story, it is the verse that names the manticore's weakness. He wants to find it, from other griots, before it is lost.

**What is really going on.** *The verse is not recovered.* Over six days the player collects variants from griots of different towns and families, each of whom remembers the verse's *shape* but not its words. The quest is about how memory works in a culture without writing, and what a community does when it loses a line. **The weakness is never named.** The quest ends with a song that has a hole in it, and a promise.

**Scene 1: the baobab.**

**FANTAH:** "Forty years. Seven verses. Not a word wrong."
**FANTAH:** "Then the fourth. A silence like a missing tooth."
**FANTAH:** "They say that verse tells how to hurt it. I'd like to know what I've lost."
> ► **"Could someone else know it?"** — **FANTAH:** "A dozen griots might. If they've not forgotten too."
> ► **"Can it be written down?"** — **FANTAH:** "A griot who writes is a griot who has stopped listening."
> ► **"I'll ask around."** — **FANTAH:** "Bring them tea. They talk more with tea."

**Scene 2: the gathering.** Over six days the player travels from well to well. At each, a griot is found: a young one with a cheerful kora, a blind one with a drum, a woman who has never sung before strangers.

**YOUNG GRIOT:** "It went: 'the lion's — no.' 'The gold's — no.'"
**BLIND GRIOT:** "It rhymed with *road.* I'm sure of that."
**WOMAN:** "My mother sang it to me. It made me cry. I don't remember why."
> ► **"Hum the tune."** — A tune, half-formed.
> ► **"What were you doing when you last heard it?"** — A memory, but not the words.
> ► **"What did it feel like?"** — A shared, odd silence.

**Scene 3: the pieces.** At the baobab, the griots sit in a ring, each humming their fragment. The pieces do not fit: one is in the wrong metre, one is a lullaby, one a joke. The verse, if it ever was one, has been worn down by two hundred years of tongues.

**FANTAH:** "It was once whole."
**MOTHER ADWOA (from the edge):** "It was once *mine.* I forgot it too."
> ► **"Perhaps a lost verse is the point."** — A hush.
> ► **"Perhaps it is hidden on purpose."** — A rustle.
> ► **"Let's write what we have."** — A scandal.

**Scene 4: the hole.** After a long argument, the griots decide to sing the founding song with a pause where the fourth verse should be: one breath of silence, held by the whole circle, to mark what has been lost.

**FANTAH:** "A song with a hole in it."
**FANTAH:** "A hole someone may one day fill."
The silence at the fourth verse is long, shared and oddly beautiful.

**Afterword: the breath.** The first town to sing the founding song with the new pause is Wellmouth, where the whole market stops at the fourth verse and holds its breath together, children included. A small girl at the back, bored, says in a clear voice that she can hear the missing words. Everyone turns. She shrugs and says she is joking, but looks pleased. Fantah, afterwards, tells the player that someone always says that, and that it is the sign the silence is working.

**Outcomes and receipt.**
- The verse is *not* recovered. If the player pushed to write, a few griots leave, offended, and the pieces are kept in a book that is never opened. If they accepted the hole, the pause becomes part of the song.
- **Receipt:** a breath of silence at the fourth verse, sung in every town; Fantah's quiet, steady voice.
- **Canon-safe:** this is a seed. It does not say what the weakness is, whether it is real, or who forgot the verse first. It answers no open question.

<!-- quest
id: qst_zrm_missing_verse
title: The Missing Verse
rank: B
type: Investigation
giver: npc_fantah_koroma
region: reg_zaruma
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: zrm_verse_done
summary: A griot has forgotten the fourth verse of the founding song, the one said to name the manticore's weakness, and goes looking for it in other mouths.
objectives:
  talk npc_fantah_koroma
  reach zaruma_griots_baobab
  choice hole_write_or_hidden
-->

---

## 4. The Well Won't Be Hurried

*B · OddJob · a gold-road well-town · giver Well-Warden Abeni Tafari*

**The short version.** Two caravans arrive at the well on the same afternoon. The well gives water enough for one. By custom the well-warden settles it, and by custom generosity is a sacred duty. Abeni's answer is a contest in which each caravan tries to give the other the first cup. She needs a judge.

**What is really going on.** This is the old, funny, deadly serious custom of Zaruma: two parties in need, each too proud to drink first. Abeni has watched the contest go badly for sixty years and has learned that the winner is never the one who gives more, only the one who gives *first.* The player is asked to judge, honestly, and to notice the one small child at the back who is thirsty.

**Scene 1: the well.**

**ABENI:** "Sixty years, one well. I've settled forty-one disputes with a cup."
**ABENI:** "The Dakar run and the salt caravan, in the same hour. Both proud."
**ABENI:** "I'll hold the water. You judge the giving."
> ► **"What are the rules?"** — **ABENI:** "Give. And mean it."
> ► **"How long?"** — **ABENI:** "Until someone drinks."
> ► **"I'll judge."** — **ABENI:** "Don't be clever. Be fair."

**Scene 2: the contest.** Two leaders, an old salt-trader named Hassan, a young caravan-mistress named Kesia, face each other across the well. Each insists the other drinks first. Each offers a gift. The gifts escalate: a camel, a blanket, a song, a cousin.

**HASSAN:** "You are younger. You drink."
**KESIA:** "You are older. You *drink.*"
**HASSAN:** "I insist."
**KESIA:** "I insist *more.*"
> ► **"Let the oldest drink."** — Hassan sighs.
> ► **"Let the thirstiest drink."** — Both look around.
> ► **"Let them draw lots."** — A silence.

**Scene 3: the child.** At the back, a small boy, dust-grey, has said nothing. He is eight and has been walking since dawn. When the player looks at him, he looks politely away, as if thirst were rude.

**ABENI (quietly):** "He's been standing there an hour."
> ► **"Give him the cup."** — The well-warden smiles.
> ► **"Ask him what he needs."** — He whispers: "Water."
> ► **"Make the leaders see him."** — Shame, and grace.

**Scene 4: the cup.** The boy drinks. The two leaders, stunned, stand silent. Then Hassan laughs, and Kesia laughs, and the contest dissolves into a general scramble to be the one to fetch the next cup.

**ABENI:** "Forty-two."
**ABENI:** "Not a drop wasted."
The two caravans make camp side by side, and by evening are sharing a fire.

**Afterword: the cup.** In the weeks that follow, Abeni sends boys with cups to the player's camp, unasked. She tells the wardens of the next three wells about the contest, the pause and the boy who would not ask. "It was never about who gives more," she says, laughing. "It is about who notices the one at the back." By autumn it has become the road's favourite story, told differently at every well, and always ending with a cup. The boy, when last heard of, has grown tall, carries water for the caravans and refuses payment, on the grounds that he is still repaying a very old cup.

**Outcomes and receipt.**
- The dispute is settled. If the player judged by thirst, Abeni records it as a precedent; if they judged by lots, she shakes her head and says nothing.
- **Receipt:** a small clay cup on the well-rim engraved with a boy's name; the two caravans travel together for a season.

<!-- quest
id: qst_zrm_well_hurried
title: The Well Won't Be Hurried
rank: B
type: OddJob
giver: npc_abeni_tafari
region: reg_zaruma
level: 100
act: 4
requires_rank: B
reward: 12500 | 730 | 53000
sets: zrm_well_done
summary: Two proud caravans reach a one-caravan well at once, each insisting the other drink first. A well-warden needs a judge.
objectives:
  talk npc_abeni_tafari
  reach zaruma_town_well
  choice oldest_thirstiest_or_lots
-->

---

## 5. Kola Before Dark

*B · Delivery · the gold road to a southern town · giver Carter Bahati Dube*

**The short version.** A naming ceremony takes place at sunrise. The grandmother will not name the child without kola nuts, and the carter who carries them has a cracked wheel, two days' road and a manticore somewhere in between. Bahati asks the player to carry the kola themselves.

**What is really going on.** The nuts are not the point; the *delivery* is. The grandmother holds the naming as a test of whether a family can still reach each other across the road, which has been closed for two years. A child unnamed past the seventh day is, by custom, left to the grandmother's name alone. The player's task is to cross a road everyone has stopped using.

**Scene 1: the cart.**

**BAHATI:** "A cracked wheel. A child with no name. A grandmother with a *standing.*"
**BAHATI:** "I can't make it. You can run."
**BAHATI:** "Kola in a basket. Don't spill. Don't *eat* them. They're *bitter.*"
> ► **"How far?"** — **BAHATI:** "A night and a morning."
> ► **"What about the manticore?"** — **BAHATI:** "Avoid it."
> ► **"I'll go."** — **BAHATI:** "Run by the wells. They're lit."

**Scene 2: the road.** Three paths: the Golden Mile, scarred and fast; the scrub, hidden but rough; the line of wells, safe but slow. The player chooses.

**JOURNAL (auto):** *The kola must reach the town by first light.*
> ► **(Take the Golden Mile.)** — A bare, glittering stretch.
> ► **(Take the scrub.)** — Thorns and hyenas.
> ► **(Follow the wells.)** — Friendly lamps, long detours.

On the Mile, the player hears a low, cold laugh from the dark. On the scrub, a hyena pack. At the wells, three hospitable wardens, each wanting to feed the courier.

**Scene 3: the dark hour.** An hour before dawn, the player is running across a dry riverbed with the basket under one arm. A light flickers ahead: a small town, a lantern, a group of waiting figures. Someone is singing, softly, a lullaby with no name in it.

**GRANDMOTHER (calling):** "Is that the *kola?*"
> ► **"I have it."** — Cheers.
> ► **"I'm late."** — **GRANDMOTHER:** "You're exactly on time."
> ► **"I'm sorry."** — **GRANDMOTHER:** "For what?"

**Scene 4: the naming.** At dawn, with a tiny, furious baby in her arms, the grandmother takes a kola, breaks it, and gives half to the child's lips.

**GRANDMOTHER:** "Welcome, little one. Your name is Kwesi-of-the-Road-That-Was-Reopened."
**BAHATI (arriving, wheel mended, panting):** "I told you she'd come."
The family cheers; the baby cries; the player is fed three breakfasts.

**Afterword: the road.** The family keeps the player three days, which is, the grandmother informs them, the minimum polite visit. Each night someone new arrives from a neighbouring town, having heard the road is open, and the household grows louder. On the last evening the baby is passed round the fire and, when it reaches the player, stops crying and stares with great seriousness. "He is judging you," the grandmother says. "Be gentle. He will remember." At dawn the player leaves with a parcel of food, a blessing in three languages and a small kola nut wrapped in cloth, which the grandmother says is for the road home, and not to be eaten until it is needed.

**Outcomes and receipt.**
- The child is named. If the player took the Golden Mile, the story spreads along the road; if the wells, three wardens add the baby to their guest-lists.
- **Receipt:** a kola-nut shell hung over the cradle; the road, for one morning, is used by a dozen families who had stayed off it.

<!-- quest
id: qst_zrm_kola_dark
title: Kola Before Dark
rank: B
type: Delivery
giver: npc_bahati_dube
region: reg_zaruma
level: 106
act: 4
requires_rank: B
reward: 13500 | 780 | 58000
sets: zrm_kola_done
summary: A naming ceremony at sunrise needs kola nuts that a carter with a cracked wheel cannot get there in time.
objectives:
  talk npc_bahati_dube
  reach zaruma_southern_town
  choice mile_scrub_or_wells
-->

---

## 6. The Seam It Will Not Touch

*A · Hidden · the Southern Mines · giver Delver Sheka Nyambura*

**The short version.** In a side-gallery of a southern mine, Sheka has found a seam of gold that the manticore will not go near. It will tear through any other vein, any other cart. This one it leaves alone. She does not know why. She does not want anyone to know.

**What is really going on.** *Nothing is explained.* The seam is ordinary gold by every test the miners can think of, yet the manticore avoids it at a distance of two hundred paces. The miners' people guard their mines' secrets jealously, and Sheka is breaking a custom by even asking a stranger. The quest ends with a decision, not an answer.

**Scene 1: the gallery.**

**SHEKA:** (in the mine-tongue first; the trade-tongue second) "We say nothing of the veins. Not even to the king."
**SHEKA:** "But this one... I do not like keeping it alone."
**SHEKA:** "The beast will not touch it. I have watched it for three weeks."
> ► **"Why me?"** — **SHEKA:** "You are not of the road."
> ► **"Is it dangerous?"** — **SHEKA:** "No one has been hurt."
> ► **"I'll look."** — **SHEKA:** "Do not speak. The walls listen."

**Scene 2: the seam.** In a low, narrow gallery, lit by a single oil-lamp, the seam runs across the rock like a bright vein in a wrist. It is pure, soft and ordinary. The air is slightly cooler.

**SHEKA:** "The others say it is cursed. I say it is *shy.*"
The miners have left small offerings along the gallery wall: a bead, a twist of salt, a child's tooth.
> ► **(Touch the seam.)** — Cold, but nothing more.
> ► **(Listen to the wall.)** — A faint, steady hum.
> ► **(Leave it be.)** — A quiet courtesy.

**Scene 3: the night watch.** That night, from a ledge above the shaft, the player and Sheka watch the dark. Near midnight, a long, low shape pads up the valley, stops at the foot of the gallery road, lifts its head and sniffs the air. For a long minute it stands, grinning, motionless. Then it turns and goes.

**MANTICORE (barely audible):** "...*Not that one.*"
> ► **"Why not?"** — **SHEKA:** "I do not know."
> ► **"It remembers something."** — **SHEKA:** "Or it is afraid."
> ► **"Tell the king."** — **SHEKA:** "No."

**Scene 4: the keeping.** The player and Sheka sit at the gallery mouth. Sheka lays out three options on the ground: tell the king, tell the council of miners, or tell no one and leave the seam as it is.

**SHEKA:** "If the king learns, he will want it mined. If the council learns, they will argue for a year. If no one learns, it stays."
> ► **"Tell the council."** — A cautious path.
> ► **"Tell no one."** — A silent one.
> ► **"Tell the king."** — A dangerous one.

**Afterword: the offerings.** Before leaving the gallery, Sheka asks the player to leave an offering of their own, and shows how: a small thing from the road, placed at the gallery mouth with no words. The player can place a bead, a twist of salt or nothing at all. Sheka does not remark on which. "The seam is not asking for payment," she says, almost to herself. "But it is good manners to bring something to a house you are visiting."

**Outcomes and receipt.**
- The decision is made. If the player told the council, the miners begin a long debate; if no one, the seam stays quiet. If the king, he leaves it alone, to everyone's surprise.
- **Receipt:** a bead left at the gallery mouth; a faint cool breath on the miners' neck-cloths when they pass.
- **Canon-safe:** this is a pure seed. It does not say why the manticore avoids the seam, whether the gold is special or what the offerings mean. It answers no open question.

<!-- quest
id: qst_zrm_seam_untouched
title: The Seam It Will Not Touch
rank: A
type: Hidden
giver: npc_sheka_nyambura
region: reg_zaruma
level: 122
act: 5
requires_rank: A
reward: 28000 | 1400 | 125000
sets: zrm_seam_done
summary: A miner has found a seam of gold that the manticore will not go near, and she does not know why.
objectives:
  talk npc_sheka_nyambura
  reach zaruma_southern_seam
  choice council_none_or_king
-->

---

## 7. The Golden Mile by Night

*A · Exploration · the Golden Mile · giver Mother Adwoa Lemba*

**The short version.** Mother Adwoa has sung every mile of the gold road but one: the Golden Mile, where the first queen's road was paved in gold and then eaten. She wants to walk it at night, with someone to guard her, and listen. She says the road still has a song.

**What is really going on.** The Mile is scarred and bare, and the manticore has followed it ever since. Adwoa believes the road *remembers,* in the stones that were once under gold. The quest is a quiet walk, a quieter song, and a choice about whether to leave something behind. The rival queen is not named.

**Scene 1: the baobab.**

**ADWOA:** "Every mile has a song. The Mile has none. It was too grand to sing, then it was too sad."
**ADWOA:** "I am old. I'd like to hear it before I go."
**ADWOA:** "Walk with me. Say little."
> ► **"Is it safe?"** — **ADWOA:** "No."
> ► **"What will we hear?"** — **ADWOA:** "Whatever the road wants to tell."
> ► **"I'll walk with you."** — **ADWOA:** "Bring water. My voice is old."

**Scene 2: the road.** Under a hard half-moon, the Golden Mile is a pale strip of scoured stone, scarred with long shallow grooves where something heavy once dragged. Adwoa walks slowly, one hand on the player's arm, humming to herself.

**ADWOA:** "Here. The first stone."
**ADWOA:** "The queen walked here. She was *proud.*"
**ADWOA:** "And frightened. You can hear that, in the stone."
> ► **"I hear nothing."** — **ADWOA:** "Listen again."
> ► **"I hear wind."** — **ADWOA:** "That is also a voice."
> ► **"I hear something."** — **ADWOA:** "Good."

**Scene 3: the song.** Halfway along the Mile, Adwoa stops and begins to sing, in a voice like a rusted bell. It is not a song that anyone has sung before. It is made of the road: the tick of a cooling stone, the sigh of a night-wind through the scrub, a faint ring from a far-off well. Out in the dark, a pale shape moves, watching.

**ADWOA (singing):** "*She laid her pride in gold, and the gold went hungry...*"
> ► **(Guard the road.)** — The watching shape does not come closer.
> ► **(Join the song.)** — A thin second voice.
> ► **(Lay a coin on the stone.)** — An offering.

**Scene 4: the end of the Mile.** At the road's southern end, where the paving stops and the plain scrub begins, Adwoa falls silent. She sits on a stone and lays her palms flat on the road.

**ADWOA:** "It has a song now."
**ADWOA:** "It was always going to. It needed someone to ask."
She sleeps, small and content, until dawn.

**Afterword: the cairn.** Weeks later griots from three towns walk the Mile in the daytime and sing the new song at its southern end, each adding a stone to the cairn of coins. Mother Adwoa, too frail to walk it twice, is carried in a chair. She listens with her eyes closed and says only that they sing it too fast. The younger griots, chastened, begin again, slowly, and for the first time the road seems to listen.

**Outcomes and receipt.**
- The Mile is sung. If the player laid a coin, it is found the next morning, untouched; the road accepts it. If they joined the song, Adwoa teaches them the second voice. **The manticore does not appear, and is not spoken to.**
- **Receipt:** a new song, "The Golden Mile," sung at the baobab; a small cairn of coins at the road's southern end.

<!-- quest
id: qst_zrm_mile_night
title: The Golden Mile by Night
rank: A
type: Exploration
giver: npc_adwoa_lemba
region: reg_zaruma
level: 126
act: 5
requires_rank: A
reward: 29500 | 1480 | 130000
sets: zrm_mile_done
summary: An elder griot who has sung every mile of the gold road but one wants to walk the Golden Mile at night and hear its song.
objectives:
  talk npc_adwoa_lemba
  reach zaruma_golden_mile_south
  choice guard_join_or_coin
-->

---

## 8. The Griot's Apprentice

*A · Companion · the Griots' Baobab · giver Zola Marimba*

**The short version.** Zola is ten. She plays the kora beautifully, and she can play anything she has heard once. She cannot remember her own family's genealogy for longer than a day. A griot who cannot remember is a griot who is lost. She wants the player to help her learn what to do instead.

**What is really going on.** Zola is not a failure; she is a different kind of memory, a memory of *sound,* not of *lists.* The old griots have not known how to teach her. The player is asked to travel with her for three days and to help her find a way to remember that works.

**Scene 1: the baobab.**

**ZOLA:** "I can play any song you hum. I can play a song I heard once last year."
**ZOLA:** "I can't remember who my grandmother's grandmother was. It goes right out of my head."
**ZOLA:** "A griot who forgets is a griot who lies."
> ► **"What do the elders say?"** — **ZOLA:** "Try harder."
> ► **"What do you want?"** — **ZOLA:** "To be a griot."
> ► **"Let's find a way."** — **ZOLA:** "Do you promise?"

**Scene 2: the walk.** For three days, the player and Zola walk the gold road, from well to well. At each, Zola meets a griot and asks how they remember. A woman ties knots in a cord. A man draws a map on his arm. An old blind master sings a chain of names to a single melody, one note per ancestor.

**BLIND MASTER:** "I never remembered a name. I remembered a *tune.* The name came after."
**ZOLA:** (breathless) "A tune for every name."
> ► **"Try it with your family."** — Zola frowns.
> ► **"Try it with a name you love."** — She brightens.
> ► **"Try it on the kora."** — She plays, and stops.

**Scene 3: the first tune.** On the second night, by a small fire, Zola plays a tune for her grandmother's name. It is a bright, wobbling one. She plays the next, for her grandmother's mother. The two tunes rhyme. By the sixth ancestor, she is playing a song.

**ZOLA:** "It's... a *song.* It's all a song."
**ZOLA:** "Play it back!"
> ► **"I can't."** — **ZOLA:** "Oh. Right. Only I can."
> ► **"I'll hum along."** — She laughs.
> ► **"Teach it to me."** — She does, shyly.

**Scene 4: the genealogy.** On the third morning, back at the baobab, Zola sings her family's whole line, nine generations, as a single tune. The old griots listen, astonished. One of them, a stern old woman, wipes her eyes.

**OLD GRIOT:** "Nobody has done that since my mother's mother."
**ZOLA:** "It's *easy.* You just have to sing it."
**OLD GRIOT:** "...Yes. Yes, child, that is all."

**Afterword: the tune.** A month later Zola's nine-note phrase is being whistled by children in three villages, none of whom know what it means. One of them, asked, says it is "the name of a good friend." Zola, hearing this, flushes with pleasure and writes to the player: a short note in a crooked hand, with a tune scribbled in the margin, which she says is theirs. It is, she explains, very hard to forget someone once you have given them a tune.

**Outcomes and receipt.**
- Zola finds her memory. If the player taught her tune-for-name, she teaches it to other children; if they hummed along, she keeps it as a private song.
- **Receipt:** a nine-note phrase Zola plays at the baobab each dawn; the player is added, in tune, to her list of people to remember.

<!-- quest
id: qst_zrm_griot_apprentice
title: The Griot's Apprentice
rank: A
type: Companion
giver: npc_zola_marimba
region: reg_zaruma
level: 128
act: 5
requires_rank: A
reward: 30000 | 1500 | 132000
sets: zrm_apprentice_done
summary: A ten-year-old kora prodigy who cannot remember her family's genealogy needs a different way to remember.
objectives:
  talk npc_zola_marimba
  reach zaruma_baobab_dawn
  choice family_love_or_kora
-->

---

## 9. Market Day at the Well

*A · Defense · a gold-road market town · giver Market-Marshal Rashidi Ngoma*

**The short version.** The biggest market on the north road is full of gold: traders have been hoarding for the day the road reopens. A pack of lesser chimeras has caught the scent and is drifting down from the scrub. They are not Mansacor. They are only a pack. But they are enough to empty a market.

**What is really going on.** The chimeras are lean, strange and hungry, and they follow the smell of gold the way the Tyrant does. Rashidi does not want a massacre; he wants the pack turned. The player must hold the market's east side while the traders decide whether to run, hide or negotiate. **Mansacor is not present and is not named.**

**Scene 1: the bell.**

**RASHIDI:** "Twenty years. One bell, one smile. Never needed a sword."
**RASHIDI:** "They're a mile out, a dozen of them. They'll be here before dusk."
**RASHIDI:** "I can't clear the market. Half the traders are carrying their whole fortune."
> ► **"What do they want?"** — **RASHIDI:** "Gold."
> ► **"Can we turn them?"** — **RASHIDI:** "With what?"
> ► **"I'll hold the east side."** — **RASHIDI:** "Mind the children."

**Scene 2: the market.** *(Gameplay: wave defense; three entrances, a bell-signal system and a crowd of civilians; the player decides where to stand, where to bait and where to fall back.)* The stalls are shuttered, the awnings drawn. Women and children are herded into the well-court. A group of old men, unflappable, continue to play at the draughts-board.

**TRADER:** "If they take my gold, I'm ruined."
**TRADER 2:** "If they take *you,* you're dead."
> ► **"Scatter coins as bait."** — A gleaming trail.
> ► **"Stand at the gate."** — A bold stand.
> ► **"Shut the market and hide."** — Slow and tense.

**Scene 3: the pack.** At dusk, a dozen shapes slink out of the scrub: lion-headed, goat-bodied, serpent-tailed, none larger than a pony. They circle, sniffing. One, the leader, a scarred creature with a patch of gold fur on its flank, stops at the gate and looks at the player.

**CHIMERA (a low, hungry bleat):** "*Gold.*"
> ► **(Give it a coin.)** — It sniffs, and eats.
> ► **(Stand firm.)** — A tense stare.
> ► **(Strike first.)** — A fierce skirmish.

**Scene 4: the dawn.** If the pack was baited, it follows the trail of coins out of the market and into the scrub, and does not return. If they fought, the pack scatters, leaving the market bruised but standing. Rashidi rings the bell once, and the old men, who have not stopped playing, announce that the game is a draw.

**RASHIDI:** "Not a stall lost."
**RASHIDI:** "Not a child hurt."
**RASHIDI:** "I owe you a very large meal."

**Afterword: the draw.** In the morning Rashidi sits at the board with the old men, losing graciously to the one who has not looked up from his pieces in twenty years. He tells the player that the market will open as usual tomorrow, with the bell and the smile, and with one new rule: every stall will keep a small bag of salt-licks by the gate, "in case the neighbours get hungry." The traders agree, grumbling, and then, to everyone's surprise, argue over who should contribute most.

**Outcomes and receipt.**
- The market holds. If the player baited the pack with coins, the leader's gold-fleck patch is seen again, from a distance, and the traders leave a tithe at the gate. If they fought, a few chimeras die and the rest return in a month.
- **Receipt:** a brass coin nailed to the market gate, labelled *For the Hungry;* Rashidi's bell rings twice at dusk, now.

<!-- quest
id: qst_zrm_market_well
title: Market Day at the Well
rank: A
type: Defense
giver: npc_rashidi_ngoma
region: reg_zaruma
level: 130
act: 5
requires_rank: A
reward: 31000 | 1550 | 135000
sets: zrm_market_done
summary: A pack of lesser chimeras, drawn by the market's hoarded gold, is drifting down from the scrub toward the biggest market on the north road.
objectives:
  talk npc_rashidi_ngoma
  defend zaruma_market_east
  choice bait_stand_or_hide
-->

---

## 10. The Test of the Open Hand

*A · Divine · the temple of the day-gods · giver Day-Priest Tendai Olufemi*

**The short version.** Tendai runs a test for pilgrims, a test of generosity. Anyone can give gold. He wants to know if a person can give what *costs.* He asks the player to take the test, and then to judge, honestly, whether it is a good one.

**What is really going on.** The temple's test is old: three gifts, each harder than the last. The first is easy (a coin). The second costs something the giver values (a keepsake). The third costs something the giver does not know they have (time, pride, a grudge). Tendai suspects his test has grown too clever, and that pilgrims now *perform* generosity instead of *feeling* it.

**Scene 1: the temple.**

**TENDAI:** "Generosity is a muscle. A priest's job is to work it."
**TENDAI:** "I've put eleven hundred pilgrims through three gifts. Not one has failed."
**TENDAI:** "That frightens me."
> ► **"Why does that frighten you?"** — **TENDAI:** "A test no one fails is a *show.*"
> ► **"What are the gifts?"** — **TENDAI:** "A coin. A keepsake. And then... something harder."
> ► **"I'll take it."** — **TENDAI:** "Don't prepare. Prepare, and you'll perform."

**Scene 2: the first and second gifts.** At the first altar, the player gives a coin; at the second, a keepsake. A pilgrim in the queue gives a ring, tears sliding down her face. A man gives his boots. A small boy gives a pebble, solemnly.

**PILGRIM:** "It was my mother's."
**TENDAI (quietly):** "Do you feel lighter?"
**PILGRIM:** "I feel... *seen.*"
> ► **"What did you give?"** — A choice, left open.
> ► **"Does it help?"** — **TENDAI:** "Some."
> ► **"Is it real?"** — **TENDAI:** "Sometimes."

**Scene 3: the third gift.** The third altar is bare, a plain stone in a plain room, lit by a single window. A beggar sits beside it, an old woman, thin and tired, with a tin cup.

**TENDAI:** "Give her something. I won't say what."
> ► **(Give her coin.)** — She takes it, and says nothing.
> ► **(Give her your time.)** — You sit beside her.
> ► **(Give her your grudge.)** — A harder gift; you tell her what you cannot forgive.

**BEGGAR:** (as the player sits) "You're the first who has *stayed.*"

**Scene 4: the verdict.** Tendai takes the player aside. The beggar was a temple servant, paid to wait. She has sat there eleven hundred times. She says, often, that she is tired of being a prop.

**TENDAI:** "She's right. My test has become a play."
**TENDAI:** "I'd like to give her a day off. And stop pretending."
> ► **"Close the test."** — He is shaken.
> ► **"Keep the test, but make it honest."** — He thinks.
> ► **"Let the beggar choose."** — She does.

**Afterword: the stone.** For a week after the test, pilgrims come to the courtyard and sit on the unpainted stone, and the beggar, whose name is Naledi, sits beside them for as long as they like. She has a sharp tongue and a fund of terrible riddles. Tendai watches from the colonnade with his arms folded and a look of wary hope. "If it still works," he says to the player, "it will be because nobody is performing. And I'll never be sure."

**Outcomes and receipt.**
- The test is reformed. If the player sat with the beggar, she tells them her real name; if they gave a grudge, she forgives it on behalf of no one in particular and the player feels lighter. If the test was closed, pilgrims are asked only to sit.
- **Receipt:** an unpainted stone in the temple courtyard, where anyone may sit beside anyone; the servant's name carved in the wall.

<!-- quest
id: qst_zrm_open_hand_test
title: The Test of the Open Hand
rank: A
type: Divine
giver: npc_tendai_olufemi
region: reg_zaruma
level: 132
act: 5
requires_rank: A
reward: 32000 | 1600 | 140000
sets: zrm_test_done
summary: A priest who has put eleven hundred pilgrims through a test of generosity suspects the test has become a performance.
objectives:
  talk npc_tendai_olufemi
  reach zaruma_temple_third_altar
  choice coin_time_or_grudge
-->
