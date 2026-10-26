# 11e-03 — Greymoor, the Silent Fen: Ten Side Quests (draft)

> *"The abbey sank into the bog a lifetime ago, monks and all. The villagers still keep its feast days, out of habit and out of fear."*
> — Gazetteer, Greymoor

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 8–10 touch the Choir of Silence's erasure of memory; the Red Prophet is not named.

**Region:** `reg_greymoor` (stilt-villages, the Walking Hut market, the Witchwood, the sunken abbey). **Rank band:** D–C. **Tone:** soft, damp, close-knit, and slowly haunted. People here speak quietly because voices carry over water, and they are quietly afraid of a silence that has started to *take things*.

**Placement notes.**
- Greymoor has **no lord**. Each stilt-village is run by a moot of elders; the witches of the Witchwood are healers *and* judges. Quests 2 and 5 are about how that system works.
- The **Hollow Abbot** is the region's Tyrant and leads the Choir of Silence. Where the Choir passes, sound dies and memories fray. No quest here kills him. Quests 8–10 are how Greymoor *prepares*.
- **Tomás Reyes's diary** is found in a witch's hut during the main story (Act II). These quests never mention it and never contradict it.
- The player has a *quiet* reading of Greymoor available: no shouting in dialogue, no combat in the villages.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Walking Hut Loses Its Way | D | Investigation | Tolliver Pegg | A gentle road story |
| 2 | The Eel Moot | D | Faction | Elder Marrel Sedge | A trial about a trap |
| 3 | Lanterns in Jars | D | OddJob | Idony Fenwater | A wisp that remembers |
| 4 | The Clapper in the Peat | D | Exploration | Sorrel | A boy, a bell, a preserved monk |
| 5 | The Witch's Price | D | Faction | Granny Hexel | A witches' court |
| 6 | High Water on the Stilts | D | Defense | Alder Rushmoor | Three villages, one flood |
| 7 | Tea with the Hag of Lowmere | C | Faction | Ysmay of Lowmere | Etiquette with teeth |
| 8 | The Ferryman's Holiday | C | Hidden | Ferryman Odran | One night on the pole |
| 9 | The Choir Passes | C | Investigation | Hester Mallow | Memory, spoken aloud |
| 10 | The Book of Small Things | C | Faction | Mother Yarrow | A village writes itself down |

## Cast (new supporting NPCs)

<!-- npc
id: npc_tolliver_pegg
name: Tolliver Pegg
tier: major
race: Human
region: reg_greymoor
settlement: The Walking Hut market
role: Walking Hut trader
backstory: A round, soft-spoken trader who inherited the Walking Hut from his grandmother and has never once felt it was his to own.
secret: The Hut talks to him when no one else is listening.
-->
<!-- npc
id: npc_marrel_sedge
name: Elder Marrel Sedge
tier: major
race: Human
region: reg_greymoor
settlement: Greymoor stilt-village
role: Moot elder
backstory: A thin, patient elder who has presided over four hundred moots without ever raising her voice, and whose silence is more feared than any shout.
-->
<!-- npc
id: npc_idony_fenwater
name: Idony Fenwater
tier: townsfolk
race: Human
region: reg_greymoor
settlement: Greymoor stilt-village
role: Wisp farmer
backstory: A quiet widow who farms will-o-wisps in jars for lantern-light and talks to each of them by name.
-->
<!-- npc
id: npc_sorrel_boy
name: Sorrel
tier: townsfolk
race: Human
region: reg_greymoor
settlement: Greymoor stilt-village
role: Eel-fisher's son
backstory: A nine-year-old who has decided that the village's silence is his fault, because he was the last one to ring the abbey bell.
-->
<!-- npc
id: npc_granny_hexel
name: Granny Hexel
tier: major
race: Human
region: reg_greymoor
settlement: The Witchwood
role: Witch-judge of the Witchwood
backstory: A tiny, ancient witch-judge who has not lost a case in sixty years and who believes law is the kindest thing anyone can give a frightened person.
-->
<!-- npc
id: npc_alder_rushmoor
name: Alder Rushmoor
tier: major
race: Human
region: reg_greymoor
settlement: Greymoor stilt-village
role: Flood warden
backstory: A thick-armed flood warden who has pulled sixty people out of the water and never once been thanked in the same sentence as his name.
-->
<!-- npc
id: npc_ysmay_hag
name: Ysmay of Lowmere
tier: major
race: Hag
region: reg_greymoor
settlement: Lowmere
role: Bog hag
backstory: A tall, stooped bog hag with beautiful manners, who has not had a guest in two hundred years and has been practising ever since.
secret: She is terrified of the guest not coming.
-->
<!-- npc
id: npc_ferryman_odran
name: Ferryman Odran
tier: major
race: Human
region: reg_greymoor
settlement: Lowmere Reach
role: Ferryman of the drowned
backstory: A tall, patient ferryman who carries the drowned of Greymoor to the sunken abbey, and who has not slept a night through in forty years.
-->
<!-- npc
id: npc_hester_mallow
name: Hester Mallow
tier: townsfolk
race: Human
region: reg_greymoor
settlement: Greymoor stilt-village
role: Widow, reed-weaver
backstory: A sharp-tongued widow who has been forgetting her husband's face for six months, and who writes his name on her hand every morning.
-->
<!-- npc
id: npc_mother_yarrow
name: Mother Yarrow
tier: major
race: Human
region: reg_greymoor
settlement: The Witchwood
role: Witch-elder, keeper of the book
backstory: A warm, practical witch-elder who believes the best protection against forgetting is a very large pile of paper.
-->

---

## 1. The Walking Hut Loses Its Way

*D · Investigation · the Walking Hut market · giver Tolliver Pegg*

**The short version.** The Walking Hut has started walking in circles. It has never done that. Tolliver does not know how to ask a house what is wrong.

**What is really going on.** The Hut is not lost. It is *homesick*. It was built by a witch-carpenter as one of a pair, and the other Hut walked into the Choir of Silence's path years ago and never came back. The Hut is circling because it is trying to find the road its sibling took.

**Scene 1: the market.**

**TOLLIVER:** "I know how it sounds. A hut, walking in circles."
**TOLLIVER:** "But it's *always* walked the same road. Reed-village, then Lowmere, then the Witchwood edge. Four hundred years. And this week: round, round, round. It won't leave the middle of the fen."
**TOLLIVER:** "I can't ask it. It doesn't answer. It *creaks*."
> ► **"Have you tried listening?"** — **TOLLIVER:** "To a house?"
> ► **"What changed?"** — **TOLLIVER:** "Nothing. Except the silence, I suppose. The Choir was close last week."
> ► **"I'll walk with it."** — **TOLLIVER:** "Bring a lantern."

**Scene 2: the walk.** For a night you walk beside the Hut. It creaks in patterns: three low, two high, pause. Tolliver translates, uncertainly.

**TOLLIVER:** "Three low is 'stop'. Two high is 'look'. I think the pause means 'please'."
**TOLLIVER:** "It's been saying 'please' for three days."
The Hut turns, drags a foot, and turns again. Each lap, the circle widens a little.

**Scene 3: the other door.** At the edge of the circle, half-sunk in the bog, there is a door. It is not a ruin. It is a *second Hut*, wedged in black water, its legs buried to the knee.

**TOLLIVER:** (whisper) "Oh. Oh, my."
**HUT:** *(a long, low creak that shivers through the planks)*
**TOLLIVER:** "It's been looking for *this*."
> ► **"Can we free it?"** — Peat-digging, rope, and patience.
> ► **"Is it alive?"** — **TOLLIVER:** "I don't know. I never knew about the first."
> ► **"Why did it stop walking?"** — **TOLLIVER:** "The silence took its voice."

**Scene 4: the pull.** With ropes, winches and a long night, the second Hut is dragged free. It sags, shudders, and, very slowly, lifts one leg out of the mud.

**TOLLIVER:** "...It's *walking*."
The two Huts stand side by side, facing the same way. One creaks: three low, two high, pause. The other answers.

**Outcomes and receipt.**
- Either the sibling Hut follows the first as a second market stall, or (if the player chooses) it is *given a home* in the Witchwood.
- **Receipt:** two Huts walk the fen on different days; a small lantern burns at each doorway; Tolliver says "please" to the Hut every morning.

<!-- quest
id: qst_gm_walking_hut
title: The Walking Hut Loses Its Way
rank: D
type: Investigation
giver: npc_tolliver_pegg
region: reg_greymoor
level: 38
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: gm_hut_resolved
summary: The Walking Hut has started walking in circles. It is looking for its sibling, which the Choir's silence swallowed.
objectives:
  talk npc_tolliver_pegg
  reach greymoor_hut_circle
  reach greymoor_second_hut
  choice follow_or_witchwood_home
-->

---

## 2. The Eel Moot

*D · Faction · Greymoor stilt-village · giver Elder Marrel Sedge*

**The short version.** Two families both claim the same eel trap. The moot cannot decide. The elder asks you to *witness*: to say, quietly, what you saw.

**What is really going on.** The trap belonged to a man who died without a will. His brother and his adopted daughter both claim it. The adopted daughter, **Nessa**, is thirteen and has been running the trap alone for a year. The brother, **Corm**, wants it because the family is poor. No one has said so out loud.

**Scene 1: the moot house.**

**MARREL:** "Sit. Speak softly. Voices carry over water, and we do not shout here."
**MARREL:** "Two families. One trap. We have heard the claims. I would like to hear what a stranger saw."
**MARREL:** "You may say what you saw. You may not say what you think. Is that understood?"
> ► **"What did I see?"** — **MARREL:** "That is for you to say."
> ► **"I'm not sure I can."** — **MARREL:** "Then say that."

**Scene 2: the witness walk.** The player visits the trap at dawn, the eel-sheds, and both houses. Details accumulate, none of them decisive:
- Nessa has re-woven the trap's reeds three times.
- Corm has paid its debts, quietly, twice.
- A third party, **Old Pettifer**, has been telling each of them what the other said.

**NESSA:** "He doesn't *want* it. He wants it *gone*. So nobody can say I took it."
**CORM:** "I don't want to take it from her. I want somebody to say it was fair."

**Scene 3: the testimony.** Back at the moot house, the player speaks. Everyone listens in a hush so deep you can hear the water.

> ► **"Nessa has kept the trap alive."** — A statement of fact.
> ► **"Corm has paid the debts."** — Also fact.
> ► **"Old Pettifer has been carrying words between them."** — A third, awkward fact.

**MARREL:** "Pettifer. Is this true?"
**PETTIFER:** "...I only said what I heard."
**MARREL:** "You said it *wrong*, Pettifer."

**Scene 4: the ruling.** The moot does not rule for either. It rules that **the trap shall be held in common**, with Nessa as trap-keeper and Corm as debtor-keeper, until Nessa is of age.

**NESSA:** "...That's not winning."
**CORM:** "It's not losing."
**MARREL:** "It's a moot. We do not do winning."

**Outcomes and receipt.**
- Which facts the player stresses sets the *tone* of the ruling: Nessa gets more standing, Corm gets more standing, or Pettifer is shamed.
- **Receipt:** a plank bridge links the two houses; the eel trap has two names carved on its lip; Marrel nods to the player in the street.

<!-- quest
id: qst_gm_eel_moot
title: The Eel Moot
rank: D
type: Faction
giver: npc_marrel_sedge
region: reg_greymoor
level: 40
act: 2
requires_rank: D
reward: 1600 | 95 | 6500
sets: gm_moot_resolved
summary: Two families claim the same eel trap. The moot asks a stranger to say, quietly, what they saw.
objectives:
  talk npc_marrel_sedge
  reach greymoor_eel_trap
  choice nessa_corm_or_pettifer
-->

---

## 3. Lanterns in Jars

*D · OddJob · Greymoor stilt-village · giver Idony Fenwater*

**The short version.** Idony farms will-o-wisps in jars. One of them has begun to hum a tune. She would like to know whose.

**What is really going on.** Wisps carry the *last light* of whatever drowned them. This one carries the last song of **Dunstan Ferrow**, a boatman who drowned while singing his daughter to sleep. His daughter, now grown and with a child of her own, lives two villages away. She has never heard it.

**Scene 1: the wisp barn.**

**IDONY:** "Hush now, love. Hush. That's one of mine. Number nine. She's a *quiet* one usually."
**IDONY:** "But for three nights she's been humming. Same tune. I've tried humming it back, but I only get as far as the second bar."
> ► **"May I listen?"** — **IDONY:** "Sit. Be still."
> ► **"What do wisps normally do?"** — **IDONY:** "Glow, mostly. Sometimes sulk."

**Scene 2: the tune.** In the quiet barn, a thin silver note rises from the jar. The player hears four bars of a lullaby, the melody simple and old.

**IDONY:** "I've never heard it. But I think... I think it's *somebody's*."
**IDONY:** "Wisps don't make things up. They *keep* things."

**Scene 3: the search.** The player asks around three villages. A hymn-singer recognises the second bar. A weaver knows the third. A tavern-keeper names the song: *"The Reed-Boat Lullaby."* The boatman who sang it: **Dunstan Ferrow**, drowned twenty years ago.

**TAVERN-KEEPER:** "His girl's still alive. Marwen. She lives past the third mere, in the willow house."
**TAVERN-KEEPER:** "She doesn't remember him singing. She was a baby."

**Scene 4: the willow house.** Marwen answers the door with a small child on her hip.

**MARWEN:** "A song? I don't... I never learned a song from him."
*The wisp-jar glows. The tune rises.*
**MARWEN:** (very quietly) "I know this."
**MARWEN:** "I sing this. To Wen. I don't know where I learned it."
**MARWEN:** "...It was *him*."
> ► **"Hold the jar."** — She does.
> ► **"Let the wisp go."** — Idony's heart breaks, a little.
> ► **"Sing it together."** — A three-part lullaby by the door.

**Outcomes and receipt.**
- If the player gives the wisp to Marwen, it lives on her windowsill; if released, it rises as a thin light above the fen.
- **Receipt:** a wisp-jar sits on Marwen's sill; a lullaby appears in the player's Journal, and in the tavern's repertoire.

<!-- quest
id: qst_gm_lanterns_in_jars
title: Lanterns in Jars
rank: D
type: OddJob
giver: npc_idony_fenwater
region: reg_greymoor
level: 36
act: 2
requires_rank: D
reward: 1400 | 85 | 5800
sets: gm_wisp_resolved
summary: A farmed wisp hums a lullaby nobody remembers. It is the last song of a drowned boatman, and his daughter has been singing it without knowing why.
objectives:
  talk npc_idony_fenwater
  reach greymoor_willow_house
  choice give_release_or_sing
-->

---

## 4. The Clapper in the Peat

*D · Exploration · the sunken abbey · giver Sorrel*

**The short version.** A nine-year-old thinks the Silence is *his fault*, because he was the last to ring the abbey bell. He wants to ring it again.

**What is really going on.** The bell's clapper has been missing for years. It was removed by a monk, **Brother Quillon**, who is still in the abbey, preserved in the peat, still holding it. Quillon hid the clapper because *the bell's ring was drawing the Choir of Silence* long before anyone understood. He has been keeping it from the villagers to keep them safe.

**Scene 1: the stilt-house.**

**SORREL:** "It was me. I rang it. The last time. And then the quiet came."
**SORREL:** "Mam says it's the Abbot. Gran says it's the fog. But I rang it, so it's *me*."
**SORREL:** "I want to ring it again. To undo it. Please. I can't climb the tower, and nobody will take me."
> ► **"It isn't your fault."** — **SORREL:** "Then why did it go quiet?"
> ► **"I'll take you."** — **SORREL:** "*Really?*"
> ► **"Tell me what happened."** — **SORREL:** "I rang it. Three times. It sounded *so* big. And then the fog came."

**Scene 2: the tower.** At low tide, you wade through black water to the leaning bell tower. Inside, the stair is slick, the bell dark and heavy. The clapper is missing.

**SORREL:** "It was *right there*. It's gone."
Beneath the bell, a trapdoor. Below it, a flooded crypt, and a figure sitting upright in the water, as preserved as a pressed flower.

**Scene 3: the monk.** Brother Quillon's lips move without sound. A faint voice rises in the peat-light.

**QUILLON:** "...Child. You came."
**QUILLON:** "I kept it. I kept the clapper. I am sorry."
**QUILLON:** "The bell *calls*, child. Not only the faithful. It calls the Choir. I took the heart out of it to save you."
**SORREL:** "...It wasn't me?"
**QUILLON:** "It was never you."
> ► **"Give the clapper to the village."** — **QUILLON:** "Then they may ring it. And it may call."
> ► **"Leave it hidden."** — **QUILLON:** "That is wise. And lonely."
> ► **"Keep it ourselves."** — **QUILLON:** "...Then you are its keeper. I am glad to be released."

**Scene 4: the bell.** On the surface, at dusk, Sorrel looks at the silent bell and then at the player.

**SORREL:** "I don't want to ring it any more. Not if it calls *them*."
**SORREL:** "But I'd like to hear it once. Just once."
*The player may strike the bell once with the clapper, in a deep, clear note that carries for a mile, and then wrap the clapper in cloth.*

**Outcomes and receipt.**
- The player chooses what happens to the clapper. Ringing it once draws a small, manageable wave of Choir-touched dead; hiding it keeps the peace.
- **Receipt:** Sorrel stops blaming himself; a small cairn marks Brother Quillon's crypt, with a loaf left on it every Morrowsday.

<!-- quest
id: qst_gm_clapper_peat
title: The Clapper in the Peat
rank: D
type: Exploration
giver: npc_sorrel_boy
region: reg_greymoor
level: 42
act: 2
requires_rank: D
reward: 1700 | 100 | 6800
sets: gm_clapper_resolved
summary: A boy believes the Silence is his fault because he rang the abbey bell last. The clapper was taken by a monk who is still guarding it in the peat.
objectives:
  talk npc_sorrel_boy
  reach greymoor_abbey_crypt
  choice give_hide_or_keep
-->

---

## 5. The Witch's Price

*D · Faction · the Witchwood · giver Granny Hexel*

**The short version.** A child has stolen from a witch's cupboard. By the fen's law, the witches must judge the case. Granny Hexel needs someone to speak *for* the child.

**What is really going on.** The child, **Tuck**, took a jar of salve to heal his sister's burn. He didn't know the price was a *memory*. The witch he stole from, **Aunt Bramble**, wants him banished from the Witchwood for a year. Granny Hexel wants to hear a better argument.

**Scene 1: the court.**

**HEXEL:** "You are not of the fen. That makes you the perfect advocate. You have no grudge and no kin."
**HEXEL:** "The law is simple. He stole. She lost. He owes. The *price* is what we decide."
**HEXEL:** "Make it a good argument. I am bored of bad ones."
> ► **"I'll argue for him."** — **HEXEL:** "Good. Don't shout."
> ► **"What's the usual price?"** — **HEXEL:** "A year's exile. Or a memory."

**Scene 2: the case.** In the witches' circle, five witches sit in a ring of stones. Aunt Bramble is cold, precise, and afraid. The boy sits very still.

**BRAMBLE:** "He stole a jar of *Heartease*. It is not a salve. It is a *year of my life*, brewed and bottled. I will not get that year back."
**TUCK:** "I didn't know. Sis was screaming."
**BRAMBLE:** "Ignorance is not payment."
> ► **"He did it to save her."** — **BRAMBLE:** "Many do."
> ► **"What would make it fair?"** — **BRAMBLE:** "A year. His. Or yours."
> ► **"Brew another jar."** — **BRAMBLE:** "That takes a year. I have not got a year to give."

**Scene 3: the offer.** The player may offer *a year of service* (a quest chain collecting rare herbs for Bramble), *a memory* (a harmless but real one: the smell of your first winter), or *a favour owed*.

**HEXEL:** "She asked for a year. You are offering a *season*. That is not the same."
**BRAMBLE:** "I would take a memory."
> ► **"I'll give one."** — **BRAMBLE:** "Name it."
> ► **"I'll serve a season."** — **BRAMBLE:** "...Done, if it is *proper* service."

**Scene 4: the judgement.** Granny Hexel raises one finger.

**HEXEL:** "The boy stole. The witch lost. The advocate paid. The case is closed."
**HEXEL:** "And, Aunt Bramble: the jar was *left within reach of a child*. That is *your* price."
*Aunt Bramble opens her mouth, shuts it, and nods.*

**Outcomes and receipt.**
- The player decides the form of payment. *Memory* gives a one-line mild loss (a Journal note: *"You no longer remember what winter smelled like."*); *service* gives herbs and a witch's gratitude; *favour* gives a future debt.
- **Receipt:** Tuck delivers a loaf to your door each Sylvasday; Aunt Bramble puts a lock on her cupboard.

<!-- quest
id: qst_gm_witch_price
title: The Witch's Price
rank: D
type: Faction
giver: npc_granny_hexel
region: reg_greymoor
level: 44
act: 2
requires_rank: D
reward: 1700 | 100 | 6900
sets: gm_price_resolved
summary: A child stole a jar of salve from a witch. Granny Hexel needs an outsider to argue for him in the witches' court.
objectives:
  talk npc_granny_hexel
  reach witchwood_court
  choice memory_service_or_favour
-->

---

## 6. High Water on the Stilts

*D · Defense · Greymoor stilt-village · giver Alder Rushmoor*

**The short version.** The three rivers have stopped agreeing. A flood is coming tonight. Alder needs help moving three villages before the water rises.

**What is really going on.** Nothing supernatural. This is *just a flood*, a very good one, with real stakes. The question is **who goes first**: the sick, the animals, the stored grain, or the children. The player's choices decide which losses the villages absorb.

**Scene 1: the dyke.**

**ALDER:** "It's tonight. I can read the river like a face, and tonight it's *lying*."
**ALDER:** "Three villages. Sixty people. Eight punts. We can't move everything."
**ALDER:** "I need someone who can lift, steer, and make a hard call without crying about it. Can you do that?"
> ► **"I'll help."** — **ALDER:** "Take the east punt."
> ► **"What goes first?"** — **ALDER:** "The sick. The children. Everything else is stuff."
> ► **"What if we can't save everything?"** — **ALDER:** "Then we choose. And we live with it."

**Scene 2: the evacuation.** A long, structured sequence: the player ferries villagers in punts through rising water, with each trip a choice of *who* and *what*.
- **Village A (reed-weavers):** the elders, the cradles, a pen of goats.
- **Village B (eel-fishers):** a sick child, a nets-and-tackle store, a boathouse.
- **Village C (peat-cutters):** stored peat for winter, a stubborn old man who refuses to leave.

**OLD MAN (Village C):** "I've lived here seventy years. I'm not leaving for a *puddle*."
> ► **"The puddle's at your knees."** — **OLD MAN:** "It's a *brisk* puddle."
> ► **"Carry him."** — The player hauls him, protesting, into the punt.
> ► **"Stay with him."** — The old man grumbles, then sits.

**Scene 3: the crest.** At midnight the water peaks. The dyke groans. A final choice: *reinforce the dyke* with the village's last timber (saving Village C's peat) or *open the sluice* to relieve pressure (flooding the fields but protecting the stilts).

**ALDER:** "If we open it, the peat's gone."
**ALDER:** "If we don't, the stilts may go."

**Scene 4: the morning.** The water falls. Mud, ruined thatch, soaked grain. No one is lost.

**ALDER:** "...We did it. We *lost* a lot. But we did it."
**ALDER:** "Nobody's said my name in the same sentence as 'thank you' in forty years. I'd like to hear it once."
> ► **"Thank you, Alder."** — He says nothing, and turns away to hide his face.

**Outcomes and receipt.**
- All sixty survive. Choices determine which village loses what; each carries a *receipt* for months.
- **Receipt:** a high-water mark is carved on the dyke with the date and *"No one lost."* Alder's name is added below.

<!-- quest
id: qst_gm_high_water
title: High Water on the Stilts
rank: D
type: Defense
giver: npc_alder_rushmoor
region: reg_greymoor
level: 40
act: 2
requires_rank: D
reward: 1800 | 100 | 7000
sets: gm_flood_resolved
summary: A flood is coming to three stilt-villages. The player decides who and what goes first, and whether to open the sluice.
objectives:
  talk npc_alder_rushmoor
  defend greymoor_dyke
  reach greymoor_three_villages 3
  choice dyke_or_sluice
-->

---

## 7. Tea with the Hag of Lowmere

*C · Faction · Lowmere · giver Ysmay of Lowmere*

**The short version.** A bog hag has invited you to tea. She has not had a guest in two hundred years. If you get the manners wrong, you are the main course. If you get them right, she may be the kindest host in Greymoor.

**What is really going on.** Ysmay is not hungry. She is *desperately lonely* and has practised etiquette for two centuries. She is terrified that the guest will leave. Her "wrong manners = death" rule is a rehearsed bluff to keep guests from leaving in the first place.

**Scene 1: the invitation.**

**YSMAY:** "Do come in. Do. Mind the threshold; it bites. Wipe your feet. *Both* feet. Good."
**YSMAY:** "Sit. Not there; that's *mine*. There. Lovely."
**YSMAY:** "I should explain the *rules*. There are three. Do not refuse tea. Do not compliment the cake. Do not, under any circumstances, *leave early*."
> ► **"Why not compliment the cake?"** — **YSMAY:** "It is *terrible*. I know."
> ► **"What happens if I leave early?"** — **YSMAY:** "...Nothing! Nothing at all. It would simply be *rude*."
> ► **"I'd be glad to stay."** — **YSMAY:** (a long, startled pause) "...Would you?"

**Scene 2: the tea.** A fussy, haunted tea party in a hut full of unlit candles and hundreds of unused teacups. Each conversational choice is a *manners test*; wrong answers are met by an eyebrow, never by violence. The player learns that every cup has a name on it, *the guest who never came*.

**YSMAY:** "That one is for Mr Fenwater. And that one for the vicar. And that one for... I forget."
**YSMAY:** "I set them out every year. In case."

**Scene 3: the cake.** She brings the cake. It is, indeed, terrible: grey, lopsided, faintly sorrowful.
> ► **"It's delicious."** — **YSMAY:** (stricken) "You *lie*."
> ► **"It's honest."** — **YSMAY:** "...I like that."
> ► **"May I help with the recipe?"** — **YSMAY:** "...You would?"

**Scene 4: the bake.** The player and Ysmay bake a second cake together in her cold stove. It is *good*.

**YSMAY:** "I thought I would never. I thought... a hag could not *make* something nice."
**YSMAY:** "You will come again?"
> ► **"Yes."** — **YSMAY:** (a tear in her voice) "I'll set a cup."
> ► **"If you'll visit me, too."** — **YSMAY:** "...I do not *go out*."
> ► **"Come to the Walking Hut market."** — **YSMAY:** "Do you think they'd *let* me?"

**Outcomes and receipt.**
- The player earns a hag's friendship, a cup with their name, and an invitation to tea every Morrowsday.
- **Receipt:** the Lowmere hut has a lit window at night; a cup with the player's name sits on the shelf; Ysmay starts a small bakery stall at the Walking Hut market.

<!-- quest
id: qst_gm_tea_hag
title: Tea with the Hag of Lowmere
rank: C
type: Faction
giver: npc_ysmay_hag
region: reg_greymoor
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: gm_tea_resolved
summary: A bog hag with beautiful manners has invited you to tea, and has been practising for two hundred years.
objectives:
  talk npc_ysmay_hag
  reach lowmere_hut
  choice honest_polite_or_help_bake
-->

---

## 8. The Ferryman's Holiday

*C · Hidden · Lowmere Reach · giver Ferryman Odran*

**The short version.** The ferryman who carries Greymoor's drowned to the abbey asks you to take the pole for one night. He has not slept in forty years.

**What is really going on.** Odran is dying of exhaustion, and no one knows. Each night he ferries a dozen souls across the black water. Tonight, the player does it. Each passenger tells a micro-story; the player decides how to answer.

**Scene 1: the landing.**

**ODRAN:** "You'll think me mad. I'm not. I'm *tired*."
**ODRAN:** "Forty years. A dozen a night. They don't speak. They don't need to. But I *listen*."
**ODRAN:** "One night. That's all. Take the pole. Keep to the line of lanterns. Do not step off the boat, and do not argue with the water."
> ► **"I'll do it."** — **ODRAN:** "Thank you. I shall sleep like a stone."
> ► **"Is it dangerous?"** — **ODRAN:** "Only to the heart."

**Scene 2: the crossing.** At midnight, passengers step aboard, one at a time. Each is a Greymoor soul who has drowned: a washerwoman, a child, a poacher, a priest, a soldier, a lamplighter, a fiddler. Each *talks*, slowly, quietly. Each wants one thing.

- **The washerwoman:** "Tell my daughter the shirt is in the chest."
- **The child:** "Is it far? ...Will it hurt?"
- **The poacher:** "I took more than I needed. Tell them I'm sorry."
- **The priest:** "I never rang the bell. I wanted to. Would *you*?"
> ► **(Each passenger: a gentle choice. Comfort, truth, or silence.)**

**Scene 3: the soldier.** The seventh passenger is a young soldier in a Greyhollow banner-cloak.

**SOLDIER:** "I'm not drowned, sir. I'm... *lost*. I walked the wrong road. I'm supposed to be on a wagon. West. They're hungry in the west."
*(If the player has done quest 10 of Aldmere, the soldier recognises the Greyhollow road.)*
> ► **"Where were you going?"** — **SOLDIER:** "Home. If I remember it."
> ► **"I'll take you."** — **SOLDIER:** "...Thank you."

**Scene 4: the dawn.** At the far shore, the abbey bell-tower rises from the mist. One by one, the passengers step out onto the black stone. The last to leave is the child, who takes your hand.

**CHILD:** "It didn't hurt."
**CHILD:** "Thank you for the boat."
*Back at the landing, Odran is asleep on the dock, a smile on his face.*

**Outcomes and receipt.**
- Every passenger's response is stored as a *kindness record*; a few of them come back as visions in Act V.
- **Receipt:** Odran sleeps until noon; a second, smaller ferry stands at Lowmere Reach for the player's night shifts.

<!-- quest
id: qst_gm_ferryman_holiday
title: The Ferryman's Holiday
rank: C
type: Hidden
giver: npc_ferryman_odran
region: reg_greymoor
level: 64
act: 3
requires_rank: C
reward: 4000 | 220 | 15000
sets: gm_ferry_resolved
summary: The ferryman who carries Greymoor's dead asks you to take the pole for one night. Each passenger has one thing to say.
objectives:
  talk npc_ferryman_odran
  reach lowmere_reach_night
  reach greymoor_abbey_shore
  choice comfort_truth_or_silence
-->

---

## 9. The Choir Passes

*C · Investigation · Greymoor stilt-village · giver Hester Mallow*

**The short version.** The Choir of Silence is passing through the village tonight. Hester has been forgetting her husband for six months. She wants to remember him before it gets worse.

**What is really going on.** The Choir does not kill. It *takes memory*, like a tide taking sand. Each villager loses a different piece: a name, a face, a song. Hester's husband is already half gone. Tonight is the worst night yet.

**Scene 1: the reed-weaver's house.**

**HESTER:** "I write his name on my hand. Every morning. *Alder.* No, that's the flood-warden. *Ewan.* Ewan. I look at it and... nothing."
**HESTER:** "I know he was tall. I know he sang. I know I loved him. I don't know what he *looked* like."
**HESTER:** "The Choir comes tonight. I'd like to be awake for it. With someone who'll *remember*."
> ► **"I'll stay with you."** — **HESTER:** "Good. Bring a lamp."
> ► **"Tell me about him."** — **HESTER:** "I'll try. Ask me small things."
> ► **"What do you want to keep?"** — **HESTER:** "His laugh. I can't hear it any more."

**Scene 2: the vigil.** For the whole night the player talks with Hester, asking *small* questions: what he ate, how he laced his boots, what he said when the kettle boiled over. Each memory Hester recovers is a candle lit. As the Choir approaches, the candles gutter.

**HESTER:** "He ate his eggs *cold*. He said they tasted of... of the morning."
**HESTER:** "He had a whistle. A little whistle. Two notes. *Up-down.*"
*The player writes each detail on Hester's hand, in ink.*

**Scene 3: the passing.** At midnight, the Choir arrives: a pale procession, faces blank, mouths open in silent song. The candles gutter one by one. Hester's grip tightens.

**HESTER:** "It's... it's *taking*."
**PLAYER (speaking aloud):** "He whistled. Up-down."
*The nearest candle flares.*
**HESTER:** (whisper) "*Up-down.*"
> ► **(Keep speaking.)** — Each spoken memory anchors a candle.
> ► **(Guard her.)** — You stand between her and the Choir.

**Scene 4: the dawn.** The Choir passes. The candles are cold. Hester's hand is black with ink. She looks at the player, tired and *whole*.

**HESTER:** "I remember his laugh."
**HESTER:** "It was a *terrible* laugh. It was like a donkey with a cold."
*She laughs, and it sounds just like the one she described.*

**Outcomes and receipt.**
- Hester keeps most of Ewan's memory; the rest is written on her wall in her own hand.
- **Receipt:** a "memory wall" of small inked details in Hester's house; the village adopts the idea in quest 10.

<!-- quest
id: qst_gm_choir_passes
title: The Choir Passes
rank: C
type: Investigation
giver: npc_hester_mallow
region: reg_greymoor
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: gm_choir_resolved
summary: The Choir of Silence passes through the village tonight. A widow wants to hold on to her husband's memory for one more night.
objectives:
  talk npc_hester_mallow
  defend greymoor_reed_house_night
  choice speak_guard_or_both
-->

---

## 10. The Book of Small Things

*C · Faction · the Witchwood · giver Mother Yarrow*

**The short version.** Mother Yarrow believes the best defence against forgetting is a very large pile of paper. She needs the whole fen to write down what it wants to keep.

**What is really going on.** The Choir of Silence erases *large* memories first: names, faces, histories. Small things, a way of laughing, a favourite spoon, survive longer. The Book is a witch-ward: *a village's small things, written down and bound, will be remembered even if the villagers forget.*

**Scene 1: the cottage.**

**YARROW:** "I'm old. I'm tired. And I've buried too many good people who forgot to be remembered."
**YARROW:** "So we write. Everything. Not the big things, the *little* things. The shape of a spoon. The song your grandmother hummed. Which of your sisters cheats at cards."
**YARROW:** "You're not from here. You can go where I can't. Will you collect for me?"
> ► **"What do you need?"** — **YARROW:** "A page from every house. A true one."
> ► **"Won't the Choir erase the Book?"** — **YARROW:** "Maybe. But paper is *patient*."

**Scene 2: the collecting.** The player visits stilt-villages and cottages. Each household has one small thing:
- A **weaver** who counts stitches aloud in her sleep.
- A **cheesemaker** who hums when stirring.
- A **boy** who always puts his left boot on first.
- A **widow** (Hester) who writes names in ink.
- A **fisherman** who never, ever whistles near the eel-sheds.

**VILLAGER:** "That's... that's not worth writing down."
**PLAYER:** "It's exactly what's worth writing down."

**Scene 3: the binding.** At the Witchwood, witches bind the loose pages into a single thick volume with fen-reed twine and wax. The cover is blank.

**YARROW:** "What do we call it?"
> ► **"The Book of Small Things."**
> ► **"The Fen Remembers."**
> ► **"Leave it blank."**

**Scene 4: the first night.** The Choir passes the Witchwood. The witches hold the Book aloft. Its pages glow, faintly. Villagers who forgot their own names this week, wake up the next morning with their *favourite spoon* in their hands and a clear picture of why they love it.

**YARROW:** "It works. It *works*. Oh, my dear. It works."

**Outcomes and receipt.**
- The Book is a lasting ward against the Choir: villagers who have a page in it lose *less* each pass. This is a regional state, not a combat buff.
- **Receipt:** the Book sits on a lectern in the Witchwood; each village keeps a page; when the Hollow Abbot's Tyrant fight comes, the Book changes his pre-fight dialogue.

<!-- quest
id: qst_gm_book_small_things
title: The Book of Small Things
rank: C
type: Faction
giver: npc_mother_yarrow
region: reg_greymoor
level: 68
act: 3
requires_rank: C
requires_quests: qst_gm_choir_passes
reward: 4600 | 250 | 17000
sets: gm_book_resolved
summary: A witch-elder believes the best defence against the Choir of Silence is writing down the small things people want to keep.
objectives:
  talk npc_mother_yarrow
  reach greymoor_villages_pages 5
  choice name_the_book
-->
