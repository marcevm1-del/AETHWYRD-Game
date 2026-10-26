# 11e-25 — Shen-Lu, the Hundred-Stair Mountains: Ten Side Quests (draft)

> *"The sects were one school before the Hundred-Stair Schism. Their founders' graves face away from each other."*
> — Gazetteer, Shen-Lu

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the third regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 4 plants a seed about the Colossus's making and answers nothing. Quests 7 and 9 change how the sects prepare.

**Region:** `reg_shen_lu` (the sect foothill towns, the Jade Crossroads and the Wandering Dragon Inn, the Hundred Stair, the Grey Peaks). **Rank band:** B–A. **Tone:** formal, proud, steeped in tea and incense, with a good deal of comedy in the gap between what a sect says about itself and what it does on a Tuesday. Underneath it, a silence on the grey peaks like held breath.

**Placement notes.**
- **Wuxiang, the Hunger Colossus,** is the region's Tyrant: a giant of mountain stone and stolen qi that devours the qi of the peaks and cannot be fought with qi. **No quest here kills it or stops its walking.** Quests 4, 7, 8 and 9 touch it from the side: what the sects *know*, how the villages *move*, and how people learn to *fight without the thing it eats*.
- **Which sect made Wuxiang is not answered.** Quest 4 follows a thread and leaves it open; no quest names the maker.
- Customs the quests rely on: **precedence** (sects are served in an order that is itself a quarrel); **the stair-bow** (a disciple bows at every hundredth step to the mountain, never to a person); **the cold cup** (a guest is first offered tea that has stood a night, to show the host holds no grudge); **tablet-tending** (every founder's grave is swept by someone on the first day of the month).
- Earlier pattern quest here: *Ninety-Nine Steps* (the side-stair and the Voice).

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Bird Who Knew the Manual | B | Investigation | Innkeeper Pei Lanxiu | A talking mynah and three furious sects |
| 2 | A Herb That Does Not Grow | B | Escort | Master Gao Liren | A master's pride, a student's cough |
| 3 | The First Bout in Forty Years | B | Defense | Steward Wen Haoyu | A tournament stage and a grudge |
| 4 | The Hand Behind the Hunger | A | Investigation | Elder Shu Mingzhe | A thread that must not be pulled too far |
| 5 | Letters Between Two Graves | B | Exploration | Gardener Old Fu | Two unopened letters |
| 6 | A Bucket for Every Step | B | Faction | Carrier-boss Tian Gua | Water carriers on strike |
| 7 | The Tiger on the Grey Pass | A | Capture | Huntress Ren Xuelian | A hungry thing with no qi to eat |
| 8 | The Night the Mountain Walked | A | Defense | Headman Bo Jiangshu | An evacuation by lantern and rope |
| 9 | Hands Without Qi | A | Trial | Master Lu Zhiyan | A sect's most heretical lesson |
| 10 | Tea for Three Precedences | B | Delivery | Tea-seller Yan Pu | A cup, three sects, noon |

## Cast

<!-- npc
id: npc_pei_lanxiu
name: Innkeeper Pei Lanxiu
tier: major
race: Human
region: reg_shen_lu
settlement: Jade Crossroads
role: Innkeeper of a rival teahouse beside the Wandering Dragon Inn
backstory: A brisk, watchful innkeeper who has hosted every sect's grudges for twenty years and has a shelf of lacquered boxes marked with the names of men who have paid for her silence.
-->
<!-- npc
id: npc_mynah_the_scribe
name: Scribe, the Mynah
tier: townsfolk
race: Bird
region: reg_shen_lu
settlement: Jade Crossroads
role: Talking mynah that holds a secret manual
backstory: A glossy black mynah with a yellow eye and a remarkable memory, taught a manual one phrase at a time by a disciple who thought a bird would never be searched.
-->
<!-- npc
id: npc_master_gao_liren
name: Master Gao Liren
tier: major
race: Human
region: reg_shen_lu
settlement: Cloudfall Sect foothill
role: Master of the Cloudfall Sect
backstory: A stern, silver-bearded master whose best student has fallen ill with the drain, and who has already decided that the cure must be a rare herb because the alternative is too frightening to say.
-->
<!-- npc
id: npc_lin_yuehua
name: Lin Yuehua
tier: townsfolk
race: Human
region: reg_shen_lu
settlement: Cloudfall Sect foothill
role: Ill disciple
backstory: A thin, determined young cultivator whose breath has started to catch on the stairs and who has been hiding it from her master for a month.
-->
<!-- npc
id: npc_steward_wen_haoyu
name: Steward Wen Haoyu
tier: major
race: Human
region: reg_shen_lu
settlement: Jade Crossroads
role: Steward of the old tournament ground
backstory: A tidy, anxious steward who swept the empty tournament ground every morning for forty years and has just been told, by three sects at once, that it may be needed again.
-->
<!-- npc
id: npc_elder_shu_mingzhe
name: Elder Shu Mingzhe
tier: major
race: Human
region: reg_shen_lu
settlement: Stillwater Sect
role: Elder of the Stillwater Sect
backstory: A courteous, tired elder whose sect has been accused three times of making the Colossus and who would very much like an outsider to prove otherwise before anyone checks.
secret: She is not certain her own sect is innocent, and has not looked at a certain sealed room in thirty years.
-->
<!-- npc
id: npc_old_fu
name: Old Fu
tier: townsfolk
race: Human
region: reg_shen_lu
settlement: The Hundred Stair
role: Gardener of the founders' graves
backstory: A bent, cheerful gardener who has swept both founders' graves on the first of every month for fifty years and who has never once been thanked by either sect.
-->
<!-- npc
id: npc_tian_gua
name: Carrier-boss Tian Gua
tier: townsfolk
race: Human
region: reg_shen_lu
settlement: Ironwood Foothill
role: Boss of the water carriers
backstory: A wide, loud, soft-hearted carrier-boss who has hauled water up a thousand steps to disciples for thirty years and has finally run out of patience with being thanked in advance.
-->
<!-- npc
id: npc_ren_xuelian
name: Huntress Ren Xuelian
tier: major
race: Human
region: reg_shen_lu
settlement: Foothill hunters' lodge
role: Mountain huntress
backstory: A lean, soft-spoken huntress who has tracked tigers on the high slopes since she was a girl and has just found the first one she cannot bring herself to hunt.
-->
<!-- npc
id: npc_headman_bo_jiangshu
name: Headman Bo Jiangshu
tier: major
race: Human
region: reg_shen_lu
settlement: Greywater Village
role: Village headman
backstory: A short, steady headman of a village under a grey peak, who has watched the pines go bare and the wells go strange and who has decided to move his people before anyone orders him to.
-->
<!-- npc
id: npc_master_lu_zhiyan
name: Master Lu Zhiyan
tier: major
race: Human
region: reg_shen_lu
settlement: Ashen Reed Sect
role: Master of the Ashen Reed Sect
backstory: A blunt, weathered master of a small sect that has always taught the body before the qi and is now being quietly mocked for it, and is about to stop being mocked.
-->
<!-- npc
id: npc_yan_pu
name: Tea-seller Yan Pu
tier: townsfolk
race: Human
region: reg_shen_lu
settlement: Jade Crossroads
role: Tea-seller
backstory: A cheerful, anxious tea-seller who has been given three contradictory orders from three sects for a single noon delivery and is quietly drafting his will.
-->

---

## 1. The Bird Who Knew the Manual

*B · Investigation · the Jade Crossroads · giver Innkeeper Pei Lanxiu*

**The short version.** A secret manual has vanished from a sealed room. Three sects blame one another. All three have sent disciples to Pei Lanxiu's teahouse, which is now full of men glaring over their cups.

**What is really going on.** No one stole it. A young disciple, afraid of being searched at the gate, taught the manual to a mynah, one phrase at a time, and the bird has been perched on a teahouse beam ever since, reciting the first third in the wrong order. The disciple fled in shame. The bird is the only copy and cheerfully unaware.

**Scene 1: the teahouse.**

**PEI:** "Three sects. Three tables. Nobody has ordered a second pot in two days. I am losing *money* on this feud."
**PEI:** "They each say the others took the *Heron-Step Manual.* They each have a very good reason to be furious."
**PEI:** "I would like a stranger to find it before somebody's teacup becomes a weapon."
> ► **"What do you know?"** — **PEI:** "That my mynah has started saying very odd things."
> ► **"Who saw it last?"** — **PEI:** "A disciple who left at dawn. He did not pay."
> ► **"I'll look."** — **PEI:** "Sit. Don't glare. It's catching."

**Scene 2: the beam.** The player spends an evening in the teahouse. A glossy black mynah on a roof beam clears its throat.

**SCRIBE:** "*...the heron lifts the left foot before the breath, not after.*"
**SCRIBE:** "*Second stance, rotate the wrist. Third stance, forget the second.*"
**SCRIBE:** "Pei! Pei! The tea is *cold!*"
*A disciple at the Redwater table stiffens. Another turns pale.*
> ► **"Quiet! He is quoting."** — The room freezes.
> ► **"Keep him talking."** — The bird obliges.
> ► **"Take the bird upstairs."** — Pei sighs and opens a door.

**Scene 3: the fugitive.** In a pine-grove shrine outside the town, the runaway disciple, **Wen Ji,** kneels with an empty bowl.

**WEN JI:** "I could not take the pages. The gate-guard feels every sleeve. So I taught it to a bird."
**WEN JI:** "I thought I would collect him in a week."
**WEN JI:** "The bird has opinions. He changed the third stance."
> ► **"Come back with me."** — He flinches.
> ► **"The manual should be shared."** — **WEN JI:** "That is exactly what my master would hang me for."
> ► **"Tell the sects yourself."** — A long silence.

**Scene 4: the tea.** The player gathers the three sects' envoys at Pei's largest table. The mynah recites, from the top. It takes an hour. It is *very wrong,* and the envoys, to their growing horror, begin correcting it.

**REDWATER ENVOY:** "The *right* foot, you foolish bird."
**CRANE ENVOY:** "It's the *left!* My master taught me the left!"
*By the third pot, the three envoys are arguing about footwork together, and nobody notices when they begin to agree.*

**Outcomes and receipt.**
- The manual is not stolen, merely *remembered by a bird.* If the sects were gathered, they agree to copy it jointly and record the corrections; if Wen Ji is returned, he is forgiven by the narrowest margin; if the bird is hidden, the feud simmers on, and the mynah gets a long holiday.
- **Receipt:** a small brass perch with a name plate, *Scribe,* on Pei's beam, and a shared sheet of corrections pinned beside it.

<!-- quest
id: qst_shl_bird_manual
title: The Bird Who Knew the Manual
rank: B
type: Investigation
giver: npc_pei_lanxiu
region: reg_shen_lu
level: 90
act: 4
requires_rank: B
reward: 10500 | 620 | 45000
sets: shl_bird_done
summary: Three sects blame each other for a missing manual, which has been hiding in a teahouse mynah's memory.
objectives:
  talk npc_pei_lanxiu
  talk npc_mynah_the_scribe
  reach shenlu_pine_shrine
  choice return_share_or_hide
-->

---

## 2. A Herb That Does Not Grow

*B · Escort · the Grey Peaks · giver Master Gao Liren*

**The short version.** The Cloudfall Sect's finest disciple is ill with the drain. Her master wants a spirit herb from a grey peak. The player is to carry him there.

**What is really going on.** There is no spirit herb. Grey peaks grow nothing that feeds on qi, because the Colossus has eaten it. The player and Master Gao will climb to a barren slope and find one scrub of plain mountain moss, which has survived because it needs *no* qi at all. It is no cure. But the girl's real illness is that she has been cultivating harder to keep up, and the drain is feeding on the effort.

**Scene 1: the master.**

**GAO:** "My best student has a cough. A cultivator does not cough. I have sent for a spirit herb from the grey peaks."
**GAO:** "I have sent *three* men. None came back with it."
**GAO:** "You will take me. I have not left my sect in nineteen years, but the herb is *there.*"
> ► **"What is the herb?"** — **GAO:** "Frostbloom. Grows on high ledges."
> ► **"Is she dying?"** — **GAO:** "She is *ill.* Those are different."
> ► **"I'll take you."** — **GAO:** "Do not speak of this to Yuehua."

**Scene 2: the climb.** The pines thin. The mist turns bone-pale. The stair at the grey line has no moss, no birds and no sound at all.
*(Gameplay: a quiet climb; the player's qi-based abilities fade on the grey slopes, a first taste of Wuxiang's appetite; Gao leans heavily on the player.)*

**GAO:** "It is so quiet. I did not remember this."
**GAO:** "There used to be a crane here."
> ► **"Rest a moment."** — **GAO:** "I will rest when I am dead."
> ► **"Lean on me."** — **GAO:** (He does, without a word.)
> ► **"Tell me about Yuehua."** — **GAO:** "She stays late. She trains till she sways. I told her to."

**Scene 3: the ledge.** On the ledge, a thin bed of grey-green moss, and no frostbloom. Gao stares for a long time.

**GAO:** "...It is not here."
**GAO:** "There is nothing here that could be."
**GAO:** "I told her to train harder. I told her *every day.*"
> ► **"The herb was never the cure."** — He nods slowly.
> ► **"Take the moss; it might help."** — It will not, but it may comfort.
> ► **"What will you do now?"** — **GAO:** "...Go down. And tell her to stop."

**Scene 4: the stair down.** At the sect gate, Yuehua is waiting on the lowest step, her shoulders drawn up against a cough she is trying to hide.

**YUEHUA:** "Master. You went to the grey peaks."
**GAO:** "I did. I am an old fool. Sit down. We will begin with a rest."
**YUEHUA:** "A... *rest?*"

**Outcomes and receipt.**
- Yuehua is ordered to rest, drink broth and do no forms for a month; the cough eases. The moss is planted in the sect's courtyard in a plain clay pot. Gao stops requiring his disciples to train past a bell.
- **Receipt:** a plain clay pot of grey moss on the sect steps, and a new sect rule carved under the gate: *No one is to train after the evening bell.*

<!-- quest
id: qst_shl_herb_not_grow
title: A Herb That Does Not Grow
rank: B
type: Escort
giver: npc_master_gao_liren
region: reg_shen_lu
level: 94
act: 4
requires_rank: B
reward: 11000 | 640 | 46000
sets: shl_herb_done
summary: A master climbs a grey peak to fetch a spirit herb for his ill student, and finds there is none and never was.
objectives:
  talk npc_master_gao_liren
  escort npc_master_gao_liren
  reach shenlu_grey_ledge
  talk npc_lin_yuehua
  choice moss_truth_or_comfort
-->

---

## 3. The First Bout in Forty Years

*B · Defense · the Jade Crossroads · giver Steward Wen Haoyu*

**The short version.** The great tournament ended in a massacre within living memory. Three sects have agreed, for the first time in forty years, to hold one small friendly bout. The steward wants it to end with everyone alive.

**What is really going on.** Three sects each have a faction that wants the bout to fail, and each has quietly sent one man to make it so. They are not assassins; they are loyalists with sharpened pins, flasks of oil and a very bad idea. The steward does not know who they are. The player has one afternoon to find them without insulting a single guest.

**Scene 1: the swept ground.**

**WEN:** "I have swept this ground every morning for forty years. Nobody has fought on it since."
**WEN:** "Tomorrow, at noon, three young disciples will cross hands on this stone. Slowly. Politely. With *rules.*"
**WEN:** "If anyone bleeds, the sects will not speak for another forty years."
> ► **"What do you need me to do?"** — **WEN:** "Stand where I can't, and see what I can't."
> ► **"Who might spoil it?"** — **WEN:** "Everyone has a cousin."
> ► **"I'll keep the peace."** — **WEN:** "Do it without anyone noticing, please."

**Scene 2: the crowd.** The ground fills with bright robes, fans, and rumours. The player moves among the stalls and stands looking for loose planks, odd flasks, a too-quiet man at the end of a bench.
*(Gameplay: social-stealth defense. Spot the three saboteurs without a public scene.)*

**TEAHOUSE BOY:** "Sir, that man poured something on the rail."
**SPECTATOR:** "Is that a *pin* in his sleeve?"
> ► **"Quietly take his arm."** — A tense whisper.
> ► **"Ask him to hold your cup."** — A friendly intercept.
> ► **"Call out his name and sect."** — He bolts; the crowd gasps.

**Scene 3: the bout.** The three disciples cross hands, slowly, solemnly. Halfway through, the oiled rail gives way and a plank swings loose.
*(Gameplay: catch the plank, steady the stand, keep the bout going.)*

**WEN:** "Don't stop! They must *not* stop!"
**DISCIPLE:** (calmly) "We are not stopping."

**Scene 4: the closing bow.** The bout ends in a draw. The three disciples bow to one another, and, startled, to the steward.

**WEN:** "...Nobody bled."
**WEN:** "I need to sit down."

**Outcomes and receipt.**
- The tournament is held without bloodshed. If the saboteurs were intercepted quietly, they are sent home unnamed and the sects are none the wiser; if exposed, the sects are shamed into a formal truce.
- **Receipt:** a single white lantern on the swept ground, lit on the day of every bout, and the steward's broom hung on the wall of the stand.

<!-- quest
id: qst_shl_first_bout
title: The First Bout in Forty Years
rank: B
type: Defense
giver: npc_steward_wen_haoyu
region: reg_shen_lu
level: 98
act: 4
requires_rank: B
reward: 11500 | 660 | 48000
sets: shl_bout_done
summary: Three sects hold a tiny friendly bout for the first time in forty years, and each has sent a saboteur to spoil it.
objectives:
  talk npc_steward_wen_haoyu
  defend shenlu_tournament_ground
  choice quiet_cup_or_call_out
-->

---

## 4. The Hand Behind the Hunger

*A · Investigation · the Stillwater Sect · giver Elder Shu Mingzhe*

**The short version.** Elder Shu's sect has been accused three times of making the Colossus. She asks the player to find out which rival really did, before anyone looks at her own cellar.

**What is really going on.** The player follows three trails: a rival's quarry, a rival's forge, a rival's stone-binding inscription. Each points back to the *united school* from before the Schism, whose techniques every sect still uses in a different dialect. Nothing here names the maker. What the player finds is that the question has been asked wrongly: the thing that made Wuxiang was *taught,* long ago, to all of them.

**Scene 1: the elder.**

**SHU:** "Three accusations in five years. Stillwater did not do this. I believe that. I would prefer you *prove* it, for I have not looked everywhere myself."
**SHU:** "Find which sect it was. Bring the evidence to me, and only to me."
**SHU:** "I will not ask you to leave a stone unturned. I will ask you to *carry* them carefully."
> ► **"Why come to an outsider?"** — **SHU:** "An insider would be believed by no one."
> ► **"What do you fear I will find?"** — **SHU:** "Nothing. I have no fear. Next question."
> ► **"I'll look."** — **SHU:** "Thank you. Do not lose anything."

**Scene 2: the three trails.** At a rival sect's quarry, a cut face of stone bears the mark of a binding inscription. At a forge, a broken casting mould is stamped with the same hand. At a ruined shrine on the Hundred Stair, the inscription is carved *plainly,* on a lintel, in the old united-school brush-script.
*(Gameplay: three short investigation sites. Each is interrupted by a different sect's patrol; the player may bargain, bluff or hide.)*

**QUARRY FOREMAN:** "That mark? Everybody cuts that mark. It's in the primer."
**FORGE BOSS:** "It means 'bind and hold.' Nothing sinister."
**OLD CARETAKER:** "That was the *old school's* hand. We all have it. We don't talk about whose it was."
> ► **"Who taught it?"** — **CARETAKER:** "No one living."
> ► **"Is it in Stillwater's primer?"** — **CARETAKER:** "...It is."
> ► **"Who still uses it?"** — **CARETAKER:** "The sect that stopped admitting they do."

**Scene 3: the report.** The player returns to the elder with an honest finding: nothing names a sect, and everything names the school they all came from.

**SHU:** "...So it could be any of us."
**SHU:** "It could be *mine.*"
*She is silent a long time. She does not look at the north wall of her study.*
> ► **"Burn the report."** — She hesitates.
> ► **"Publish it to all three sects."** — A scandal, but an honest one.
> ► **"Keep it, and open the sealed room together."** — **SHU:** "...Not yet."

**Scene 4: the answer she gives.** Shu stands, takes a key from her sleeve, and sets it on the table without a word. She does not open the room that day.

**Outcomes and receipt.**
- Nothing is solved; the player leaves with a closed folder, three trails and an elder who now knows that *not asking* is also a kind of answer. If the report is published, the three sects begin sending envoys to each other's archives. If it is burned, the elder keeps her silence and the seed grows quietly.
- **Receipt:** a key on a cord around the elder's neck, and a new line in Stillwater's weekly rite: *"What we have not examined, we do not know."*

<!-- quest
id: qst_shl_hand_behind_hunger
title: The Hand Behind the Hunger
rank: A
type: Investigation
giver: npc_elder_shu_mingzhe
region: reg_shen_lu
level: 128
act: 4
requires_rank: A
reward: 29500 | 1540 | 130000
sets: shl_hunger_done
summary: An elder asks the player to learn which rival sect made the Colossus, and the trails all lead back to the single school they once shared.
objectives:
  talk npc_elder_shu_mingzhe
  reach shenlu_binding_sites 3
  talk npc_elder_shu_mingzhe
  choice burn_publish_or_keep
-->

---

## 5. Letters Between Two Graves

*B · Exploration · the Hundred Stair · giver Gardener Old Fu*

**The short version.** The two founders' graves face away from each other. Old Fu has swept both for fifty years. Last month, sweeping the south one, he found a letter.

**What is really going on.** There are two letters, one beneath each grave-stele, each addressed to the other founder, each sealed in wax that has not been broken in two hundred years. Fu has never opened them and will not. He wants the player to carry them across the pass to where they were meant to go.

**Scene 1: the gardener.**

**FU:** "Fifty years. First of the month. The east grave and the west. I have swept them both and nobody has thanked me."
**FU:** "Don't mistake me. I'm not asking for thanks. I'm asking for a favour."
**FU:** "I found a letter. Then another. They're for each other."
> ► **"Have you read them?"** — **FU:** "I am old, not rude."
> ► **"Why now?"** — **FU:** "I don't have many first-of-months left."
> ► **"I'll carry them."** — **FU:** "Thank you. Mind the steps."

**Scene 2: the walk.** The graves are three hours' climb apart, down a stair on one side of the mountain and up another. The player carries both letters, one in each hand, like a pair of birds.
*(Gameplay: a long, quiet traverse; weather, a stair-bow at every hundredth step, small moments with passing disciples who stare at the letters and cannot say why.)*

**YOUNG DISCIPLE:** "Are those from... *them?*"
**OLD NUN:** "Don't open them. Don't ever."
> ► **"Whose are they?"** — **OLD NUN:** "I will not say. I will say that I have been waiting to see this."
> ► **"I won't open them."** — **YOUNG DISCIPLE:** "I'd have wanted to."
> ► **"Do you know what they say?"** — **OLD NUN:** "Nobody does. That is why we have been afraid for two hundred years."

**Scene 3: the exchange.** At the west grave, the player lays the letter from the east by the stele and, at the east grave, the letter from the west. As each seal touches the stone, the wax *softens.* Neither letter opens. Neither burns. The wind, which has been blowing the same way for as long as anyone remembers, shifts.

**FU:** "...Did you feel that?"
**FU:** "It's the first time in fifty years the pines have leaned the *other* way."

**Scene 4: the decision.** The letters rest at their new graves. The player can leave them sealed, ask a senior of each sect to open them, or ask Fu to decide.

> ► **"Leave them sealed."** — A quiet, unread peace.
> ► **"Let both sects open them together."** — A possible reconciliation, or a scandal.
> ► **"It is Fu's to decide."** — **FU:** "...Leave them. I think they've said enough."

**Outcomes and receipt.**
- The letters remain sealed or are opened, depending on choice; their contents are not shown. In every case, one elder from each sect sits at the Hundred Stair on the first of the month and sweeps, together, for the first time.
- **Receipt:** two new brooms propped between the graves, and one of the stele-lamps turned to face the other.

<!-- quest
id: qst_shl_letters_graves
title: Letters Between Two Graves
rank: B
type: Exploration
giver: npc_old_fu
region: reg_shen_lu
level: 102
act: 4
requires_rank: B
reward: 12200 | 700 | 51000
sets: shl_letters_done
summary: A gardener finds sealed letters beneath each of the two founders' graves, each addressed to the other, and asks the player to carry them across.
objectives:
  talk npc_old_fu
  reach shenlu_west_grave
  reach shenlu_east_grave
  choice sealed_open_or_fu
-->

---

## 6. A Bucket for Every Step

*B · Faction · Ironwood Foothill · giver Carrier-boss Tian Gua*

**The short version.** Every day the water-carriers haul a thousand steps of water to a sect that has never once learned their names. Today they put the buckets down.

**What is really going on.** The carriers are not asking for coin. They are asking for the one thing a sect cannot give by decree: to be *seen.* The sect's disciples pass them daily on the stair with their eyes lowered, according to the rule of precedence, and the carriers have decided to break it politely.

**Scene 1: the stair-foot.**

**TIAN:** "Thirty years. A thousand steps. Two buckets each. We know every disciple by the sound of their feet."
**TIAN:** "Not one of them knows my name."
**TIAN:** "Today we put the buckets down. If the sect wants water, they can come and ask."
> ► **"What do you want?"** — **TIAN:** "A thank-you, said looking at us."
> ► **"The sect will be furious."** — **TIAN:** "They'll be *thirsty,* and that is better."
> ► **"I'll mediate."** — **TIAN:** "Don't let them bribe us. We'd take it, and hate it."

**Scene 2: the sect gate.** The sect's steward, a stiff man named **Jiao,** does not understand what has happened.

**JIAO:** "The water is late. This is a breach of duty. Has someone paid you to disrupt us?"
**JIAO:** "We have never mistreated them. They are paid. They are *fed.*"
> ► **"Have you ever spoken to one?"** — **JIAO:** "...Of course. I say 'water.'"
> ► **"What are their names?"** — **JIAO:** "...They are carriers."
> ► **"Try carrying a bucket."** — **JIAO:** "I am a *steward.*"

**Scene 3: the bucket.** The player persuades Jiao and three bored disciples to carry a bucket up the stair. It takes them an hour. They arrive grey-faced.

**DISCIPLE:** "A thousand steps. With two. *Every day?*"
**TIAN (grinning):** "Twice on market days."
*(Gameplay: a light comic escort-up-the-stair; the disciples drop one bucket and are comically sorry.)*

**Scene 4: the bow.** At the sect gate, the disciples line up with the carriers.

**JIAO:** (stiffly) "Tian Gua. Thank you for the water."
**TIAN:** "...Say my name again."
**JIAO:** "Tian Gua."
*The carriers, all forty of them, pick up their buckets, and bow back.*

**Outcomes and receipt.**
- The strike ends. The sect adds a stair-bow to the carriers, learns forty names and builds a rest-shelf halfway up. If the player bribed Jiao to "fix it quietly," the carriers go back to work but stop speaking to the sect altogether.
- **Receipt:** a roster of forty names carved into the first step, and a plain wooden bench halfway up the stair.

<!-- quest
id: qst_shl_bucket_every_step
title: A Bucket for Every Step
rank: B
type: Faction
giver: npc_tian_gua
region: reg_shen_lu
level: 104
act: 4
requires_rank: B
reward: 12500 | 720 | 52000
sets: shl_bucket_done
summary: The water-carriers of a sect stair put down their buckets and ask only to be thanked by name.
objectives:
  talk npc_tian_gua
  reach shenlu_sect_gate
  choice carry_name_or_bribe
-->

---

## 7. The Tiger on the Grey Pass

*A · Capture · the Grey Peaks · giver Huntress Ren Xuelian*

**The short version.** A spirit tiger, starving, has come down from a grey peak and taken three goats. The village wants it gone. The huntress has found its tracks and cannot bring herself to follow them.

**What is really going on.** The tiger is not a man-eater. It is a qi-eater, a spirit beast whose mountain has been drained, and it wanders the village edges because the people's cooking fires are the nearest warmth with qi in it. It is dying slowly of hunger that no meat can feed.

**Scene 1: the lodge.**

**REN:** "Forty years on these slopes. I know a tiger by its tread. This one doesn't hunt. It *drifts.*"
**REN:** "It takes the goat's warmth, not the goat. I found three goats whole, cold, untouched."
**REN:** "The village wants it dead. The elders want it caged. I'd like to know what *it* wants."
> ► **"You haven't hunted it."** — **REN:** "No."
> ► **"What do you need?"** — **REN:** "Someone to hold the line while I look in its eye."
> ► **"Let's find it."** — **REN:** "Walk soft. It's already afraid of us."

**Scene 2: the grey pass.** The tracks climb into a bare ravine where the pines are skeletons. The player's own qi-skills go dim.

**REN:** "There."
*On a flat rock, a magnificent tiger the colour of old brass lies flat on its belly, ribs showing, with eyes like lamp-oil going out.*
> ► **"Approach slowly."** — It lifts its head.
> ► **"Leave a fire."** — It sniffs the ember.
> ► **"Retreat."** — **REN:** "No. If we go, it follows."

**Scene 3: the fire.** A small cooking fire, built from the village's own hearth-embers, draws the tiger forward. It lies beside it, eyes half closed, and its breathing evens.

**REN:** "It's not feeding on the meat. It's feeding on the *warmth.* The qi in it."
**REN:** "It will starve in a month. There's no mountain left to feed it."
> ► **"Take it to a living mountain."** — A long journey.
> ► **"Cage it at the village, and feed it fire."** — **REN:** "It will die tame."
> ► **"End it quickly."** — **REN:** "...I will not stop you. I will not forgive you."

**Scene 4: the road.** If the player takes it to a living mountain, the tiger follows a lantern-bearer, in slow, padding stages, up the long south road to a high green ridge where, at dusk, it lifts its head and the pines hum.

**REN:** "It's gone in."
**REN:** "I never asked it for anything. I think that's why it let me."

**Outcomes and receipt.**
- The tiger lives, in a far green forest, where villagers occasionally see a flash of brass at dusk. If caged, it lives a few months and Ren leaves the lodge for good. If ended, the village is safe and quieter, and Ren does not speak to the player again.
- **Receipt:** a bronze-coloured tuft of fur on a hook by the lodge door, and a new rule: *Leave an ember at the village edge on grey nights.*

<!-- quest
id: qst_shl_tiger_grey_pass
title: The Tiger on the Grey Pass
rank: A
type: Capture
giver: npc_ren_xuelian
region: reg_shen_lu
level: 124
act: 4
requires_rank: A
reward: 28500 | 1500 | 126000
sets: shl_tiger_done
summary: A starving spirit tiger drifts toward villages for warmth, and a huntress will not hunt it.
objectives:
  talk npc_ren_xuelian
  reach shenlu_grey_ravine
  choice relocate_cage_or_end
-->

---

## 8. The Night the Mountain Walked

*A · Defense · Greywater Village · giver Headman Bo Jiangshu*

**The short version.** Wuxiang is walking through the next valley. In a night, the village must climb the stair to safety in the dark, with every lantern dimming as the Colossus draws near.

**What is really going on.** Cultivators' qi-lanterns do not just dim near the Colossus; they *drain,* and the villagers have always trusted them. The headman has planned an evacuation by rope, drum and oil-lamp, the oldest tools, because nothing the Colossus eats can be put out by it. The player's job is to keep a line moving, not to fight.

**Scene 1: the headman.**

**BO:** "The pines on the north ridge went grey last night. Not dead. Grey, like ash."
**BO:** "My grandmother used to say, 'When the mountain walks, go uphill.' She was wrong about almost everything, but not that."
**BO:** "I need a line of people on the stair by dark, and no qi-lantern among them."
> ► **"How many?"** — **BO:** "Two hundred and eleven. Plus eleven goats."
> ► **"Where do they go?"** — **BO:** "The old shelter at the hundredth step. It's cold, and it has a door."
> ► **"I'll hold the line."** — **BO:** "Hold it gently."

**Scene 2: the stair at dusk.** The village forms up. Ropes are strung between stakes. A boy beats a slow, steady drum so the line keeps its time. Lanterns of paper and tallow bob in the dusk.
*(Gameplay: defense / escort. The player lights, re-lights, rescues stragglers, carries a woman with a broken ankle, and keeps the drum-beat going. Any qi-light the player carries fades, and every oil-lamp stays bright.)*

**VILLAGER:** "My lantern's gone dark!"
**BO:** "Use fire! *Fire,* not light!"
> ► **"Share your lamp."** — A hundred small flames.
> ► **"Take the rear."** — The player guards the slowest.
> ► **"Beat the drum."** — The line holds its time.

**Scene 3: the footstep.** Far across the valley, a thud. The ground shakes once. A rim of grey spreads across the far ridge, and the pines on it bow and go pale.

**BO:** "It's not coming for us."
**BO:** "It's just *walking.* And we are in the way of its walking."
*A child begins to cry. The drum goes on.*
> ► **"Sing."** — A children's counting rhyme.
> ► **"Say nothing."** — The silence carries.
> ► **"Hold her hand."** — The child is calmed.

**Scene 4: the shelter.** At dawn, the village is in the hundred-step shelter. The valley below is grey. The cooking fires are still lit.

**BO:** "Two hundred and eleven. And eleven goats."
**BO:** "My grandmother was right."

**Outcomes and receipt.**
- Everyone lives; the village is moved up the mountain permanently, and neighbouring villages adopt its drill. The Colossus is not seen, fought or slowed.
- **Receipt:** a rope-and-drum evacuation plan painted on the village gate, and a row of oil-lamps lit on the hundredth step on the first of every month.

<!-- quest
id: qst_shl_night_mountain_walked
title: The Night the Mountain Walked
rank: A
type: Defense
giver: npc_headman_bo_jiangshu
region: reg_shen_lu
level: 133
act: 4
requires_rank: A
requires_quests: qst_shl_herb_not_grow
reward: 31000 | 1600 | 138000
sets: shl_walked_done
summary: A village climbs the stair in the dark to escape the Hunger Colossus's path, using rope, drums and oil-lamps instead of qi-lanterns.
objectives:
  talk npc_headman_bo_jiangshu
  defend shenlu_greywater_stair
  reach shenlu_hundredth_step_shelter
  choice share_rear_or_drum
-->

---

## 9. Hands Without Qi

*A · Trial · the Ashen Reed Sect · giver Master Lu Zhiyan*

**The short version.** Master Lu's small sect has always taught the body first, the qi second. Rival sects have mocked it for decades. Wuxiang eats qi. Lu wants a fair trial of the old way against the new.

**What is really going on.** Lu is not trying to win. He knows that if the sects cannot fight Wuxiang *with* qi, they must learn to fight with something else, and the only sect that has the answer is the one that has been laughed at. He needs the greater sects to attend a trial in good faith, and a neutral judge to watch it.

**Scene 1: the master.**

**LU:** "Forty years I have taught footwork, breath and bone. They call it 'the beggar's art.'"
**LU:** "Wuxiang eats qi. A man who has only qi has nothing to fight with. A man who has *bone* still has a fist."
**LU:** "I need a trial. In the open. With the great sects watching. And someone to say, honestly, who won."
> ► **"What are the stakes?"** — **LU:** "A hearing. That's all."
> ► **"Will they come?"** — **LU:** "If they think I'll lose."
> ► **"I'll judge."** — **LU:** "Be fair. It's the hardest thing."

**Scene 2: the trial ground.** Three sect champions arrive with their retinues, smiling politely. Lu's pupil, a stocky teenager named **Tai,** steps forward in plain cotton.

**CHAMPION:** "We will fight with qi. You may fight however you like."
**TAI:** "Thank you for the courtesy."
*(Gameplay: the player judges three bouts. In each, the qi-champion begins strongly, then the grey ring around the ground, a ward Lu has laid with ash and salt, drains their qi, and the contest becomes one of bone and breath.)*
> ► **"Stop the bout."** — The champions protest.
> ► **"Let it run."** — The pupil holds.
> ► **"Call the ward."** — Lu looks away.

**Scene 3: the ruling.** After the third bout, the champions stand panting. The crowd is hushed.

**CHAMPION:** "...We lost our qi in that ring. That is not fair."
**LU:** "No. It is not. It is what Wuxiang will do."
**LU:** "I did not need you to lose. I needed you to *feel* it."
> ► **"Declare it a draw."** — A diplomatic ruling.
> ► **"Declare Lu's way sound."** — A bold ruling.
> ► **"Declare the ward unfair, and the trial a lesson."** — A careful ruling.

**Scene 4: the offer.** The champions confer. One of them, a woman with a scar, steps forward.

**CHAMPION (scarred):** "Teach us the footwork. Before the next peak goes grey."
**LU:** "...All of it?"
**CHAMPION:** "Whatever there is time for."

**Outcomes and receipt.**
- The Ashen Reed Sect's old way is taught, in part, at three other sects; the sects begin to add a *qi-less hour* to their daily training. The Colossus is not fought or slowed.
- **Receipt:** a bare, ash-ringed training circle at each sect gate, and a beggar's bowl hung over the Ashen Reed door, filled with coins by the other sects.

<!-- quest
id: qst_shl_hands_without_qi
title: Hands Without Qi
rank: A
type: Trial
giver: npc_master_lu_zhiyan
region: reg_shen_lu
level: 140
act: 4
requires_rank: A
requires_quests: qst_shl_night_mountain_walked
reward: 33500 | 1680 | 146000
sets: shl_hands_done
summary: A small sect that teaches the body before qi asks the greater sects to try its way, now that Wuxiang eats qi.
objectives:
  talk npc_master_lu_zhiyan
  reach shenlu_ashen_ring
  choice draw_lu_or_lesson
-->

---

## 10. Tea for Three Precedences

*B · Delivery · the Jade Crossroads · giver Tea-seller Yan Pu*

**The short version.** Yan Pu has been ordered by three sects to deliver the first cup of the noon hour, each to be served before the others. The three tables are twenty paces apart.

**What is really going on.** Precedence is a quarrel, and the tea-seller has been caught in the middle of it. The player cannot solve the quarrel. The player can find a way to serve three cups so that none is served first.

**Scene 1: the stall.**

**YAN:** "Redwater says: 'First cup to us, as the elder house.' Crane says: 'First cup to us, as the founding house.' Ashen Reed says nothing, but I know they expect it."
**YAN:** "Noon is in forty minutes. I have one tray."
**YAN:** "Whichever I serve first, the other two will leave. Whichever I serve last, they will remember it for a generation."
> ► **"Can you serve all at once?"** — **YAN:** "I only have two hands."
> ► **"What's the oldest custom?"** — **YAN:** "The cold cup."
> ► **"I'll carry one."** — **YAN:** "Oh, thank the mountains."

**Scene 2: the cold cup.** The player recalls the oldest courtesy: a guest is first offered the cup that has *stood the night,* to show the host holds no grudge. A cold cup is served before a hot, and it belongs to no one's precedence.
*(Gameplay: a comic dash between three tables; carry three trays, dodge a goose, set cups on the right sides.)*

**REDWATER ENVOY:** "Why is mine *cold?*"
**YAN:** "It is... the *old* courtesy, honoured sir."
**CRANE ENVOY:** "Why is mine cold?"
**YAN:** "It is... the same courtesy, honoured sir."
> ► **"Serve all three cold, at once."** — A sly equality.
> ► **"Serve the hot at the same breath."** — The tea is a diplomatic triumph.
> ► **"Serve yourself first."** — **YAN:** "I can't!"

**Scene 3: the toast.** The three envoys sip. Each looks at the others over the rim. Each realises, with a little annoyance, that none of them has been served first.

**ASHEN REED ENVOY:** "Well. That's clever."
**REDWATER ENVOY:** "Whose idea was that?"
**YAN:** (faintly) "...The mountain's, I believe."

**Scene 4: the settlement.** The three envoys leave coins for a fourth cup, which Yan pours for himself on the stall step, hands shaking.

**YAN:** "I'm alive."
**YAN:** "I'll be putting that on the signboard."

**Outcomes and receipt.**
- The tea-seller is spared. The Crossroads adopts "cold cup, then hot" as the custom for mixed tables. If the player served all three cold at once, the envoys remain amused for a week.
- **Receipt:** a new painted signboard, *"Yan Pu, Tea. Served Cold First."*

<!-- quest
id: qst_shl_tea_three_precedences
title: Tea for Three Precedences
rank: B
type: Delivery
giver: npc_yan_pu
region: reg_shen_lu
level: 106
act: 4
requires_rank: B
reward: 13000 | 760 | 54000
sets: shl_tea_done
summary: A tea-seller must serve three sects the first cup at the same noon and needs a way to do it without insulting any.
objectives:
  talk npc_yan_pu
  reach shenlu_three_tables
  choice cold_hot_or_self
-->
