# 11e-12 — Bargains of the Eight: Five Shrine Quests (draft)

> *"Every god asks for something. Only some of them tell you what it costs."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 2 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** A powerful patron sets a *strange, self-contained task* with its own **tone**. One is comic, one tender, one earnest, one loud, one eerie. They do not connect. Each ends on a choice with a cost shown *first*, and a small, specific reward.

**How they fit Canon.** Canon (cosmology): every region has shrines to two or three of the Eight, and daily prayer builds **Devotion**. An **Avatar** audience is a late-game reward and is **not** used here. These five are **shrine-herald quests**: the god speaks through an offering-bowl, a lamp-flicker or a dream, and a *human herald* explains. They are the `Divine` quest type. Devotion rewards are described in prose; no new items are added to `Data/`.

**Rules.** The cost is stated before the player commits. Nobody is harmed by the god's task unless the player *chooses* harm. No god is the villain; they are *different*. Ilvaris is not featured (the Weaver of Fates, Canon §3), and Whiskers (Vex in disguise) is **not** referred to.

| # | God | Quest | Region | Tone |
|---|---|---|---|---|
| 1 | Vex, the Laughing Coin | Heads, Tails and the Edge | Goldmere Coast | Comic, kind |
| 2 | Morrowyn, the Lantern Keeper | A Lantern for the Unclaimed | Strife Marches | Tender |
| 3 | Thorgrim, the Anvil Father | The Smallest Job | Gearholm | Earnest |
| 4 | Kaelthas, the Storm Banner | A Banner for the Coward | Stormreach | Loud, honourable |
| 5 | Maelis, the Silver Dreamer | The Dream That Was Yours | Haneul | Eerie, quiet |

## Cast (heralds)

<!-- npc
id: npc_coin_priest_lucrezio
name: Coin-Priest Lucrezio
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Coin-priest of Vex's shrine
backstory: A cheerful, ruined coin-priest of Vex who has lost every bet he ever made and takes it as a mark of the god's favour.
-->
<!-- npc
id: npc_sister_mercy_aldous
name: Sister Mercy Aldous
tier: major
race: Human
region: reg_strife_marches
settlement: The border baronies
role: Lantern-sister of Morrowyn
backstory: A soft-spoken lantern-sister who has been walking the Marches' battlefields for twenty years, lighting a lantern for every body she finds.
-->
<!-- npc
id: npc_journeyman_pott
name: Journeyman Pott Brasswick
tier: major
race: Gnome
region: reg_gearholm
settlement: The Undercity
role: Thorgrim's journeyman smith
backstory: A cheerful journeyman smith of the Undercity who has spent eleven years working on one apprentice-piece and has never once finished it.
-->
<!-- npc
id: npc_halla_thunderbrow
name: Banner-Warden Halla Thunderbrow
tier: major
race: Human
region: reg_stormreach
settlement: Stormreach cliff-towns
role: Banner-warden of Kaelthas's shrine
backstory: A broad, booming banner-warden who has carried Kaelthas's banner through eleven storms and believes courage is a thing you do, not a thing you have.
-->
<!-- npc
id: npc_dreamwarden_soyeon
name: Dreamwarden Soyeon
tier: major
race: Human
region: reg_haneul
settlement: Haneul
role: Dream-warden of Maelis's shrine
backstory: A pale, serene dream-warden who sleeps three hours a night in the shrine so that the god's visions have somewhere to land.
-->

---

## 1. Heads, Tails and the Edge

*B · Divine · Port Goldmere · herald Coin-Priest Lucrezio · god: Vex*

**The short version.** Vex has asked for a wager. The stakes: a fisherman's debt. The terms: the player may call it, but the coin may land on its *edge*.

**The cost, stated first.** Lucrezio says: *"If you lose, you pay the fisherman's debt yourself. If you win, you pay nothing. If the coin lands on its edge, the god has a plan, and nobody has ever known what it is."*

**What is really going on.** The fisherman, **Orrin Dace**, owes a loan to a salvage syndicate and cannot pay. He has prayed to Vex for luck for eleven years. The god's answer is: *"Show me you can lose well."* The coin is a test of generosity, not luck.

**Scene 1: the shrine.**

**LUCREZIO:** "Welcome, welcome! Do not touch the bowl. Or *do*. The god enjoys a gamble."
**LUCREZIO:** "The god has a *wager.* It is a very small wager. The stakes are Orrin Dace's debt: two hundred silver. A coin. Heads, tails... or something *else.*"
**LUCREZIO:** "If you win, the debt is cancelled. If you lose, *you* pay it."
> ► **"Why me?"** — **LUCREZIO:** "The god likes strangers. Strangers lose interestingly."
> ► **"What's the catch?"** — **LUCREZIO:** "There is always a catch. It is Vex."
> ► **"I'll take the bet."** — **LUCREZIO:** "Wonderful! Call it in the air."

**Scene 2: the flip.** In the shrine's torchlit hall, a plain bronze coin spins in the air. The player calls it.

**COIN (a bright, chiming voice, half-laughter):** *"Heads? Tails? ...How about neither?"*
*The coin lands, rolls, wobbles, and stands on its edge. A hush.*
**LUCREZIO:** (whispering) "...The edge. I have not seen the edge in *forty years*."
> ► **"What now?"** — **LUCREZIO:** "The god's plan."
> ► **"Is that a win?"** — **LUCREZIO:** "It is... *a third thing.*"

**Scene 3: the plan.** A voice, tiny and golden, speaks from the coin.

**VEX (via the coin):** *"Here is the game. The fisherman owes two hundred. You may pay it for him. Or... you may find a way for him to pay it himself, by sunset, honestly."*
**VEX:** *"If he does, you owe nothing, and neither does he."*
**VEX:** *"If you pay it for him, he stays in debt to *you*, which he will hate."*
> ► **"I'll find a way."** — The player has a day, a town and a fisherman.

**Scene 4: the sunset.** The player runs a comic caper through Port Goldmere: selling a boat-load of cod at the dawn market, a wager in a dockside tavern, a very strange tide that leaves a chest of coins on a sandbar.

**ORRIN:** "...I don't understand how this happened."
**LUCREZIO:** "It is *luck*, Orrin."
**ORRIN:** "It was *work*."
**LUCREZIO:** "It is the same thing, if you squint."

**Outcomes and receipt.**
- The debt is paid honestly; Vex's coin is returned to the bowl, standing on its edge. If the player simply paid, the coin falls *tails*.
- **Receipt:** the bowl keeps a coin on its edge; a very small, one-time **luck blessing** (prose only) lasts a day.

<!-- quest
id: qst_pat_bargain_vex
title: Heads, Tails and the Edge
rank: B
type: Divine
giver: npc_coin_priest_lucrezio
region: reg_goldmere_coast
level: 98
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: pat_bargain_vex_done
summary: Vex has set a wager over a fisherman's debt. The coin lands on its edge, and the god has a plan.
objectives:
  talk npc_coin_priest_lucrezio
  reach goldmere_vex_shrine
  choice find_a_way_or_pay
-->

---

## 2. A Lantern for the Unclaimed

*B · Divine · the border baronies · herald Sister Mercy Aldous · god: Morrowyn*

**The short version.** Morrowyn keeps the memory of the dead. Mercy has lit a lantern for every body she has found on the Marches' battlefields. One hundred remain unnamed. She asks for help to name them.

**The cost, stated first.** *"Each name costs a day. You will not be paid. You will be tired. And one of them may be someone you know."*

**What is really going on.** The Marches have changed hands so often that no one has kept the roll of the dead. Each unclaimed body carries a small, personal object: a ring, a button, a child's drawing. If the player pieces together the clues, the dead can be *named*, and their lanterns lit with a name.

**Scene 1: the field.**

**MERCY:** "One hundred. I carry the number like a stone."
**MERCY:** "Each one had a name. Each one had someone who waited. I light a lantern for every one. But a lantern without a name is only a *light.*"
**MERCY:** "Morrowyn asks that every light have a *name*."
> ► **"How do I find names?"** — **MERCY:** "Look at what they carried."
> ► **"One hundred?"** — **MERCY:** "It will take as long as it takes."
> ► **"I'll help."** — **MERCY:** "Bless you. Bring tea."

**Scene 2: the names.** A series of short, quiet scenes across the battlefield. At each body: an object, a place, a story.
- **A brass button** from a regiment's coat, still stamped with its number. The regiment's roll is in a mercenary fort.
- **A child's drawing** of a horse, folded small, with a village name on the back.
- **A ring**, engraved with initials, and a date.
- **A mouth-harp**, small and well-worn.

*(Gameplay: a gentle detective/archive sequence; the player collects objects, visits forts and villages, and returns with names. Most names can be recovered; a handful remain *unnamed*.)*

**VILLAGER:** "That drawing's my boy's. He ran off to the war in spring."
**VILLAGER:** (a long silence) "...Thank you."

**Scene 3: the unnamed.** Near the end, the player finds a body with *nothing*: no ring, no button. Only a pair of well-mended boots.

**MERCY:** "Some have *nothing.* I name them *anyway.* We call them... *Companion.*"
**MERCY:** "Everyone is someone's companion."
> ► **"Name this one."** — The player may choose *any* name.
> ► **"Leave it as Companion."** — A quiet, true choice.
> ► **"Dedicate it to someone you've lost."** — A personal, private beat.

**Scene 4: the lanterns.** At dusk, a hundred lanterns glow in the field, each with a small card bearing a name. Morrowyn's presence is a *warmth*, not a voice: a gentle gold light in each flame.

**MERCY:** (very quietly) "...They're *home.*"

**Outcomes and receipt.**
- The names are recorded in the Marches' memorial roll; families come to the field. Some bodies are carried home.
- **Receipt:** a field of small lanterns that never needs lighting; Morrowyn's Devotion deepens (prose only); a letter arrives from a family the player helped.

<!-- quest
id: qst_pat_bargain_morrowyn
title: A Lantern for the Unclaimed
rank: B
type: Divine
giver: npc_sister_mercy_aldous
region: reg_strife_marches
level: 90
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: pat_bargain_morrowyn_done
summary: A lantern-sister has lit a lantern for every body she found on the Marches' battlefields. One hundred have no name.
objectives:
  talk npc_sister_mercy_aldous
  reach marches_battlefield_graves 5
  choice name_companion_or_dedicate
-->

---

## 3. The Smallest Job

*B · Divine · the Undercity · herald Journeyman Pott Brasswick · god: Thorgrim*

**The short version.** Thorgrim asks for a single, perfect repair: a child's broken toy-clock. No magic. No shortcuts.

**The cost, stated first.** *"It will take longer than you think. You will want to cheat. The god will know."*

**What is really going on.** Pott's apprentice-piece, a small clockwork bird, has never been finished because he fears *finishing is the end of learning.* The god's task is to teach him the opposite: *a small thing done properly is the whole of the craft.*

**Scene 1: the workshop.**

**POTT:** "Eleven years. A clockwork *sparrow.* I have never made it sing."
**POTT:** "Thorgrim sent a child. She has a toy-clock; it broke in the damp of the Undercity. *Fix it.* That is the whole of the god's request."
**POTT:** "No magic, no tricks. Just *hands.*"
> ► **"That's all?"** — **POTT:** "That is all, and it is *everything.*"
> ► **"Why the child?"** — **POTT:** "Because her toy is the first thing the god has asked about in a hundred years."
> ► **"I'll do it."** — **POTT:** "Good. Wash your hands first."

**Scene 2: the work.** A slow, meditative crafting sequence in Pott's workshop: disassembling the toy, cleaning the gears, polishing the pins, finding a tiny, missing screw in the bottom of a tin of buttons.

*(Gameplay: a patient mini-game. The player must not use a tool the god would disapprove of: no shortcuts, no spells. Each step is a small decision: clean the pin or replace it; keep the original spring or fashion a new one.)*

**CHILD (Lotte, aged seven):** "Is it going to take long?"
**PLAYER:** "A bit."
**CHILD:** "That's all right. It's *my clock.*"

**Scene 3: the temptation.** At the end, the spring is cracked. A shiny, simple spell would mend it in a heartbeat. Pott watches.

**POTT:** "You *could.* I would not blame you."
> ► **"Use the spell."** — The clock ticks; the god is quiet.
> ► **"Make a new spring."** — Three hours; a fresh, honest spring.
> ► **"Ask Pott for help."** — He, too, has a way.

**Scene 4: the tick.** The toy ticks. Very quietly, very evenly.

**CHILD:** "...It's *singing.*"
**POTT:** (a rough whisper) "...Look at that."
*Beside the toy, on the bench, the unfinished clockwork sparrow suddenly gives a single, clear chirp.*
**POTT:** "...Oh. *Oh.*"

**Outcomes and receipt.**
- The clock is fixed; Pott finishes his sparrow within a week. If the player used the spell, the god's blessing is *thin*; the toy ticks, but the sparrow does not sing.
- **Receipt:** a small clockwork sparrow perches in Pott's window; Thorgrim's Devotion deepens (prose only).

<!-- quest
id: qst_pat_bargain_thorgrim
title: The Smallest Job
rank: B
type: Divine
giver: npc_journeyman_pott
region: reg_gearholm
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: pat_bargain_thorgrim_done
summary: Thorgrim asks for one perfect repair of a child's broken toy-clock, with no magic and no shortcuts.
objectives:
  talk npc_journeyman_pott
  reach gearholm_undercity_workshop
  choice spell_new_spring_or_help
-->

---

## 4. A Banner for the Coward

*B · Divine · the cliff-towns · herald Banner-Warden Halla Thunderbrow · god: Kaelthas*

**The short version.** Kaelthas hates cowards. A soldier named **Dag Wirren** fled a battle and wants to come home. Halla asks the player to carry the god's banner for him.

**The cost, stated first.** *"If Dag fails, the god's judgement is harsh: Dag will be exiled from every cliff-town. If you carry the banner, you carry the risk."*

**What is really going on.** Dag did not flee from fear. He fled with a *wounded friend on his back*. His commander called it desertion. The god's court, a gathering of storm-callers, will judge him. The banner is the symbol of the *challenge by courage*: Dag must walk through a lightning-storm on the cliff to prove he is not a coward.

**Scene 1: the shrine.**

**HALLA:** "I am the warden of the Banner. I have carried it through eleven storms. I have never *once* been afraid."
**HALLA:** "That is not courage. That is *bad weather sense.*"
**HALLA:** "Dag Wirren wants to walk the storm. Alone, with the banner. It is the old way of proving courage."
> ► **"Why not carry it yourself?"** — **HALLA:** "Because I have nothing to prove."
> ► **"Why does Dag want to?"** — **HALLA:** "Because they call him a deserter."
> ► **"I'll carry it."** — **HALLA:** "Not *for* him. *With* him."

**Scene 2: Dag.** A lean, haunted man in a tattered coat, hands clasped.

**DAG:** "They say I ran. I did. I ran *toward* the medics, with Tom on my back."
**DAG:** "Tom died anyway. And I'm the man who ran."
**DAG:** "Kaelthas will not say I'm brave. But he might say I'm *not a coward.*"
> ► **"Walk with me."** — **DAG:** "Thank you."
> ► **"Are you ready?"** — **DAG:** "No. But I never was."
> ► **"Let me hold the banner."** — **DAG:** "...Together."

**Scene 3: the storm.** On the highest cliff-path, in a booming, white-hot storm, the player and Dag walk together, banner raised. Lightning splits the sky.

*(Gameplay: a tense, scenic walk with timed lightning strikes; the player may shield, steady, or hold Dag's hand. The test is *not to run*.)*

**DAG:** (shouting over the thunder) "*I'm scared!*"
**HALLA (from the cliff):** "*Good!* Keep walking!"
**DAG:** "*I'm still scared!*"
**HALLA:** "*That's what it's FOR!*"

**Scene 4: the verdict.** At the cliff's end, the storm-callers wait. A flash of white. A voice like a great bell.

**KAELTHAS (via the banner):** *"COURAGE IS WALKING WHILE AFRAID. THE MAN IS NO COWARD."*
**HALLA:** (softly, to Dag) "...Welcome home."
*Dag sinks to his knees, weeping. The banner flaps.*

**Outcomes and receipt.**
- Dag is cleared; if the player walked *for* him (not with), the god's judgement is thin, and Dag is cleared only in part.
- **Receipt:** the banner is raised over the shrine with a second name stitched on it; Kaelthas's Devotion deepens (prose only).

<!-- quest
id: qst_pat_bargain_kaelthas
title: A Banner for the Coward
rank: B
type: Divine
giver: npc_halla_thunderbrow
region: reg_stormreach
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: pat_bargain_kaelthas_done
summary: A soldier who fled a battle carrying a wounded friend asks to walk the storm under Kaelthas's banner to be cleared of cowardice.
objectives:
  talk npc_halla_thunderbrow
  reach stormreach_storm_cliff
  choice walk_with_hold_or_for
-->

---

## 5. The Dream That Was Yours

*B · Divine · Haneul · herald Dreamwarden Soyeon · god: Maelis*

**The short version.** Maelis sends a dream. The player wakes, and *someone they have never met* is waiting, to be told something.

**The cost, stated first.** *"The dream will tell you something you may not want to say."*

**What is really going on.** The dream shows the player a stranger, **Min-jun**, a nineteen-year-old exam candidate, alone in a small room, *about to fail* the great examination because he does not believe he deserves to pass. The god's request is a simple kindness: *tell him he does.*

**Scene 1: the shrine.**

**SOYEON:** "You slept at the shrine last night. I watched. You dreamed."
**SOYEON:** "I know what you saw. Maelis shows me *each dream* as the dreamer sees it."
**SOYEON:** "Do you remember a boy, a window, and a lamp?"
> ► **"I remember."** — **SOYEON:** "Good. The god wants you to find him."
> ► **"It was just a dream."** — **SOYEON:** "No dream at *this* shrine is *just.*"
> ► **"Who is he?"** — **SOYEON:** "A candidate. He sits the examination at dawn."

**Scene 2: the search.** The player roams Haneul's lantern-lit alleys. Clues from the dream surface: a particular red-lacquer window; a blue lamp; a certain stair in a certain inn. People along the way, tutors, street-sellers, a poet, offer small pieces of the picture.

**TUTOR:** "A boy in a blue lamp? That's the Kim lad. He's *very* gifted. He thinks he's a fraud."
**POET:** "Everyone is, a little, on exam eve."

**Scene 3: the boy.** In a small, cramped room, a thin young man sits at a table, a stack of textbooks untouched, staring at the wall.

**MIN-JUN:** "Who... are you?"
**PLAYER:** "A stranger. I had a dream."
**MIN-JUN:** "That's... *odd.*"
**MIN-JUN:** "I'm going to fail. I know it. I studied for four years and I don't *know* anything."
> ► **"You know more than you think."** — **MIN-JUN:** "That's what everyone says."
> ► **"What do you want?"** — **MIN-JUN:** "To stop being afraid."
> ► **"I dreamed you passed."** — **MIN-JUN:** (a long silence) "...You did?"

**Scene 4: the dawn.** The player sits with Min-jun, quizzing him gently, until the sky pales. At last he stands, straightens his coat and takes a breath.

**MIN-JUN:** "I think... I'll go."
**MIN-JUN:** "Whatever happens."
**SOYEON (later, at the shrine):** "He did not pass the first round."
**PLAYER:** "...Oh."
**SOYEON:** "He passed the *second.* The god's dreams are *kind*, not always *right.*"

**Outcomes and receipt.**
- Min-jun sits the examination; his result depends on the player's words, and on his own work. He may fail, pass, or *choose a different road*.
- **Receipt:** a small blue lamp is lit at Soyeon's shrine; Maelis's Devotion deepens (prose only); a letter from Min-jun arrives a season later.

<!-- quest
id: qst_pat_bargain_maelis
title: The Dream That Was Yours
rank: B
type: Divine
giver: npc_dreamwarden_soyeon
region: reg_haneul
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: pat_bargain_maelis_done
summary: Maelis sends the player a dream of a stranger about to fail the great examination. The god asks only for a kindness.
objectives:
  talk npc_dreamwarden_soyeon
  reach haneul_candidate_room
  choice encourage_ask_or_promise
-->
