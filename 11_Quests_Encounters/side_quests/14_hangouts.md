# 11e-14 — Hangouts: Five Companion Bond Quests (draft)

> *"The best fights in a party game happen at the campfire."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 4 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** A short, self-contained **companion bond quest**: a small errand, a conversation with real choices, and a quiet ending. It borrows the *shape* of the "hangout event" idea (a character-and-errand story with branching dialogue) and rebuilds it on Ascend's own relationship rules.

**How it differs from a mood-meter event.** Ascend's pacing doc (`07_Characters/companion_relationship_pacing.md`) tracks *Trust, Respect, Closeness and Tension* separately, and Canon §5 protects recoverable loss. So:
- **There is no fail state.** A hangout always ends. Choices change *which* of the four shifts, never whether the companion stays.
- **Choices are tagged** in these docs with the dimension they move: `[Closeness]`, `[Trust]`, `[Respect]`, `[Tension]`. The tags are design notes, not UI.
- **No hidden points per line.** A hangout has *one* or *two* weighty choices; the rest is texture.
- **Endings are warm, not graded.** Different choices give different closing scenes, not a better or worse reward.

**Rules.** Friendship beats only. Romance, where a companion is eligible, remains opt-in and is not advanced here (Canon §4). These do **not** touch any companion's personal arc: no Greyhollow massacre, no Silver Fang reveal, no Unfinished Blade, no Debt of a Thousand Coins. They happen *around* those arcs. The companion must be in the party to give the quest.

| # | Companion | Quest | Region | Rank | Mood |
|---|---|---|---|---|---|
| 1 | Lyra Brightwood | The Longest Lunch | Aldmere City | E | Loud, funny, quietly generous |
| 2 | Kiri | First Snow | Moraveil | D | Hushed, small, a smile |
| 3 | Bram Copperpot | The Honest Game | Lirian | D | Comic, then tender |
| 4 | Sir Aldric Voss | A Pint With the Captain | Aldmere City | D | Dry, wistful |
| 5 | Torvald Stonebeard | A Nail for the Anvil | Iron Hold | C | Gruff, sentimental |

## Cast (companion records)

<!-- npc
id: npc_kiri
name: Kiri
tier: core
race: Wolf-kin
region: reg_aldmere
settlement: Ashby
role: Companion (Rogue)
backstory: A quiet, fierce wolf-kin rogue freed from slavers on the Ashby road, who is motivated mostly by food and is, very slowly, learning to smile.
romanceable: true
-->
<!-- npc
id: npc_sir_aldric_voss
name: Sir Aldric Voss
tier: core
race: Human
region: reg_aldmere
settlement: Aldmere City
role: Companion (Guardian)
backstory: A stoic, dry-humoured disgraced knight and former captain of the Royal Guard, who drinks a little too much and keeps his old oath closer than he admits.
romanceable: true
-->
<!-- npc
id: npc_bram_copperpot
name: Bram Copperpot
tier: core
race: Halfling
region: reg_aldmere
settlement: Aldmere City
role: Companion (Merchant)
backstory: A greedy, cowardly, absurdly lucky halfling merchant who runs from every fight and somehow lands a critical hit, and who is loyal underneath all of it.
romanceable: true
-->

---

## 1. The Longest Lunch

*E · Companion · Aldmere City · companion Lyra Brightwood*

**The short version.** Lyra has decided to eat at *every* stall in Hall Square before the day is out. It is a challenge. It is also, under the surface, a way of not thinking about money.

**What is really going on.** Lyra sends nearly everything she earns home to her village. She has not had a proper meal in a month. She can't admit it. The "challenge" is a joke she is making to herself.

**Scene 1: the square.**

**LYRA:** "Thirty-one stalls! *Thirty-one!* I counted. I'm going to eat at every one."
**LYRA:** "Before you say anything: I'm *fine.* I'm *very* fine. I'm *famished*, but that's different."
**LYRA:** "You're coming. You're my *witness.*"
> ► **"I'll witness."** — **LYRA:** "Excellent. Bring a very large appetite."
> ► **"Do you have the coin?"** — **LYRA:** "...Details."
> ► **"What's the occasion?"** — **LYRA:** "A Tuesday!"

**Scene 2: the stalls.** A long, cheerful, ridiculous tour. Every stall is a small joke or kindness: a dumpling-seller who insists on a rhyme; a pie-vendor whose pastry is, objectively, a crime against taste; a very old woman with a very small kettle.

**LYRA:** (with her mouth full) "This one's *incredible.* Taste it."
**LYRA:** "No, *taste* it."
**LYRA:** "...That one is *terrible.* Eat it anyway. It's a *quest.*"

*(Gameplay: a string of short, funny dialogue beats. The player's choices of what to say at each stall are texture, not meter.)*

**Scene 3: the coin.** At stall twenty-two, Lyra reaches into her pouch and finds, to her surprise, three coppers. She stares at them.

**LYRA:** "...Oh."
**LYRA:** "I forgot. I sent it. The rest. Last week."
**LYRA:** "I was going to *bluff* the last nine stalls."
> ► **"Let me pay."** — `[Closeness]` **LYRA:** "No! ...Well. *Fine.* But I'm paying you back."
> ► **"Split it."** — `[Respect]` **LYRA:** "*Ha.* A fair partner."
> ► **"Why do you send it all?"** — `[Trust]` **LYRA:** "Because they're *my* people."
> ► **"You could keep some."** — `[Tension]` **LYRA:** "That's *easy* for you to say."

**Scene 4: the last stall.** At the final stall, a tiny stall with a very old man selling sweet chestnut buns, Lyra gets the last bun and, with great ceremony, tears it in half.

**LYRA:** "*Witness.* We have done it."
**LYRA:** "...Thanks. For not asking."
**LYRA:** "I'm going to be okay. I'm *going* to be S-Rank. And then they'll *never* go hungry."
*(Depending on the choices: she shares a half with the player; she pockets one for her village; or she gives it to a hungry child.)*

**Outcomes and receipt.**
- Each choice colours Lyra's later banter (about money, home and the player). No branch loses Lyra.
- **Receipt:** Lyra buys the player a bun on every first of the month; she starts keeping a *small* purse for herself.

<!-- quest
id: qst_pat_hang_lyra
title: The Longest Lunch
rank: E
type: Companion
giver: npc_lyra_brightwood
region: reg_aldmere
level: 22
act: 2
requires_rank: E
reward: 300 | 22 | 1000
sets: pat_hang_lyra_done
summary: Lyra decides to eat at every one of Hall Square's thirty-one stalls in a day. It is a joke she is making to herself about money.
objectives:
  talk npc_lyra_brightwood
  reach aldmere_hall_square_stalls 31
  choice pay_split_ask_or_nudge
-->

---

## 2. First Snow

*D · Companion · Moraveil · companion Kiri*

**The short version.** The first snow of the year has fallen on the Truce Country. Kiri has never seen snow *this* way, from a warm place, with nothing to fear.

**What is really going on.** Kiri spent her childhood in slavers' wagons. Snow, to her, is cold and danger. She has not told anyone that snow is also *a thing that can fall softly.* This hangout is about a very small, very quiet smile.

**Scene 1: the porch.** Early morning at a Moraveil inn. The fields are white. Kiri stands at the porch rail, watching the flakes with a very still face.

**KIRI:** "...It's quiet."
**KIRI:** "I don't like it."
**KIRI:** "I don't *dislike* it."
> ► **"Do you want to go inside?"** — **KIRI:** "No."
> ► **"Do you want to go out?"** — **KIRI:** "...Maybe."
> ► **"I'll stay with you."** — `[Closeness]` **KIRI:** "...Okay."

**Scene 2: the chestnuts.** Down the lane a goblin vendor sells roasted chestnuts from a tiny, steaming cart. The smell reaches Kiri before the sight. She pauses mid-step.

**KIRI:** "...Hot."
**VENDOR (goblin):** "Ten coppers a bag! Hot, hot, *hot*!"
> ► **"Buy her a bag."** — `[Closeness]` Kiri's tail flicks.
> ► **"Ask what she likes."** — `[Trust]` **KIRI:** "...Food."
> ► **"Share a bag."** — `[Respect]` **KIRI:** "...Fair."

**Scene 3: the field.** On the way back, they pass an unbroken white field. A group of village children are running through it, shrieking, making a very bad snowman.

**CHILD:** "Hey! You! Wolf-lady! Do you want to *play*?"
**KIRI:** (frozen) "...Play?"
**CHILD:** "We're making an army!"
> ► **"Join them."** — `[Closeness]` A tentative step.
> ► **"Let Kiri decide."** — `[Respect]` A long, slow silence.
> ► **"Throw a snowball."** — `[Tension]` Kiri's ears flatten; it is *too much*, too fast.
> ► **"Suggest a different game."** — `[Trust]` **KIRI:** "...Thank you."

**Scene 4: the smile.** Eventually, with an air of enormous suspicion, Kiri picks up a small handful of snow and, with great precision, throws it at the nearest child. It hits the child squarely on the shoulder.

**CHILD:** "*Ha!* She *hit* me!"
**KIRI:** (very quietly) "...I did."
*A tiny, startled, almost-invisible smile. It is gone before the player can be sure.*
**KIRI:** "Don't tell anyone."

**Outcomes and receipt.**
- Each choice gives a slightly different smile, and a different thing Kiri says *later*. A snowball too early is *recovered* by the player's next kindness (Canon §5: no hard failure).
- **Receipt:** a small snowman outside the inn with a hand-drawn *wolf ear*; Kiri keeps a handful of chestnut shells in her pocket.

<!-- quest
id: qst_pat_hang_kiri
title: First Snow
rank: D
type: Companion
giver: npc_kiri
region: reg_moraveil
level: 42
act: 2
requires_rank: D
reward: 1600 | 95 | 6500
sets: pat_hang_kiri_done
summary: The first snow of the year falls on Moraveil. Kiri has never seen snow from somewhere warm, with nothing to fear.
objectives:
  talk npc_kiri
  reach moraveil_snow_field
  choice join_decide_throw_or_suggest
-->

---

## 3. The Honest Game

*D · Companion · Lirian · companion Bram Copperpot*

**The short version.** Bram is tired of being called lucky. He wants to prove he can win *honestly* at a card game. He needs the player to be a witness, and an honest opponent.

**What is really going on.** Bram's "luck" is real and uncanny, and it has cost him every friend he ever made at a table. He wants, just once, to lose *fairly* so that someone will believe him when he wins.

**Scene 1: the card room.**

**BRAM:** "Look. I'm *not* a cheat. I have *never* cheated. But everyone *thinks* I do."
**BRAM:** "I want a game. A *fair* one. And I want to *lose.*"
**BRAM:** "Do you know how *hard* that is? It's *very hard.*"
> ► **"Why lose?"** — **BRAM:** "Because if I *can* lose, I'm not a magician."
> ► **"I'll play you."** — **BRAM:** "Thank you. Don't go easy."
> ► **"What if you win?"** — **BRAM:** "Then I'm *cursed.* Obviously."

**Scene 2: the game.** At a lantern-lit table, the player and Bram play a small, brisk, funny card game. Every hand, Bram's cards come up *perfectly.* A pair of aces. A royal flush. The player's hands are a *disaster*.

**BRAM:** (looking at his cards, appalled) "...Not *again.*"
**BRAM:** "I swear I am *trying* to lose."
**BRAM:** "I tried to discard the ace. It came *back.*"
*(Gameplay: a card game in which the player's role is to *beat* Bram's absurd luck, or to *help* him lose.)*

**Scene 3: the temptation.** Halfway through, Bram, desperate, whispers:

**BRAM:** "Could you... *cheat* for me? Just a little? Just so I *lose*?"
> ► **"Cheat for him."** — `[Closeness]` `[Tension]` A small, kind lie.
> ► **"Play it straight."** — `[Respect]` The game goes on.
> ► **"Tell him to cheat himself."** — `[Trust]` **BRAM:** "...That's cold."
> ► **"Change the game."** — `[Closeness]` A new game, where *luck* does not apply.

**Scene 4: the loss.** In the end, after eleven rounds of impossibly good hands, the player *finds* a game in which Bram's luck does not help: a guessing game, a riddle-match. And at last, Bram loses.

**BRAM:** (looking at his lost chips, awed) "...I *lost.*"
**BRAM:** "I lost! *Look!* I lost!"
**BRAM:** (to the room) "*I LOST!*"
*The card room, silent, stares. Someone, in the back, begins to clap.*

**Outcomes and receipt.**
- However the player handles the cheat, Bram wins his *honest* loss. If the player cheated for him, he learns about it later and is *touched*, not angry.
- **Receipt:** a framed losing hand on Bram's wall; Bram insists on buying every round of drinks that night.

<!-- quest
id: qst_pat_hang_bram
title: The Honest Game
rank: D
type: Companion
giver: npc_bram_copperpot
region: reg_lirian
level: 44
act: 2
requires_rank: D
reward: 1700 | 100 | 6800
sets: pat_hang_bram_done
summary: Bram wants to lose a card game fairly, to prove his luck isn't a trick. His luck refuses.
objectives:
  talk npc_bram_copperpot
  reach lirian_card_room
  choice cheat_straight_or_change
-->

---

## 4. A Pint With the Captain

*D · Companion · Aldmere City · companion Sir Aldric Voss*

**The short version.** Aldric proposes a pint at the old guard-house. The pint is not the point. He wants to walk past his old post once, with someone beside him.

**What is really going on.** Aldric was captain of the Royal Guard. The barracks are still staffed, by young guards who do not know him. He wants to see it again without being *seen.* He will not talk about Greyhollow. He will talk about a *door.*

**Scene 1: the tavern.**

**ALDRIC:** "A pint. One. *Maybe two.* I want a walk, not a sermon."
**ALDRIC:** "I am going to the old guard-house. I would like not to go alone."
**ALDRIC:** "I do not intend to *say* anything. I intend to *look.*"
> ► **"I'll come."** — **ALDRIC:** "Good."
> ► **"Should you?"** — `[Respect]` **ALDRIC:** "No. But I *want* to."
> ► **"Do you want me to talk?"** — **ALDRIC:** "God, no."

**Scene 2: the barracks.** At dusk, the two stand in the shadow of a gate-house across the square. Young guards in fresh tabards laugh, drill, argue about a card game.

**ALDRIC:** "That door. The oak one with the iron studs. I replaced the hinge myself. Eleven years ago."
**ALDRIC:** "It still sticks. In winter."
*A young guard, struggling with the door, kicks it, and it opens with a groan.*
**ALDRIC:** (quietly, a ghost of a smile) "...Always the *same* spot."

**Scene 3: the offer.** A young guard, no more than eighteen, looks across the square and sees Aldric standing still in the dusk. He stares. He straightens.

**YOUNG GUARD:** "...Captain Voss?"
**ALDRIC:** (frozen) "...I am no one's captain."
**YOUNG GUARD:** "Sir. My father served under you."
> ► **"Let him speak."** — `[Respect]` The guard salutes.
> ► **"Step in front of Aldric."** — `[Trust]` The player takes the conversation.
> ► **"Walk away."** — `[Tension]` Aldric follows, stiffly.
> ► **"Introduce yourselves."** — `[Closeness]` A gentler thing.

**Scene 4: the second pint.** Afterward, at a quiet tavern, Aldric sits with his pint untouched.

**ALDRIC:** "He called me *sir.*"
**ALDRIC:** "I did not know anyone still would."
**ALDRIC:** "Thank you for... *standing there.*"
*(If the player chose "Let him speak" or "Introduce yourselves," Aldric orders a second pint, for the player.)*

**Outcomes and receipt.**
- Aldric's own arc is untouched; this is the small, ordinary thing around it. A branch in which the young guard salutes *the player too* adds a small line to later banter.
- **Receipt:** a small chip on a tavern table, from Aldric's ring; the guard-house door is oiled the next winter, by an anonymous hand.

<!-- quest
id: qst_pat_hang_aldric
title: A Pint With the Captain
rank: D
type: Companion
giver: npc_sir_aldric_voss
region: reg_aldmere
level: 40
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: pat_hang_aldric_done
summary: Aldric wants to walk past his old guard-post once, with someone beside him, and say nothing.
objectives:
  talk npc_sir_aldric_voss
  reach aldmere_old_guardhouse
  choice speak_step_or_introduce
-->

---

## 5. A Nail for the Anvil

*C · Companion · Karak Dûn · companion Torvald Stonebeard*

**The short version.** Torvald is grumpy. He is also, in a hold full of dwarves, *homesick.* He offers to teach the player to forge one nail. It takes all night.

**What is really going on.** Torvald keeps an unfinished blade wrapped in cloth (his own arc, untouched). Teaching a nail is his way of saying: *start with something small and finish it.* He will not mention the blade.

**Scene 1: the forge.**

**TORVALD:** "A nail. One. I am *not* going to teach you a sword. I'd be *ashamed.*"
**TORVALD:** "A nail is the *first* thing. And the *last.* Every smith worth the name has made a *thousand.*"
**TORVALD:** "Stand there. Hold this. *No, the other end.*"
> ► **"Why a nail?"** — **TORVALD:** "Because it's *small.* And if you can finish a small thing, you can finish anything."
> ► **"I'm no smith."** — **TORVALD:** "That's why you're *here.*"
> ► **"Ready."** — **TORVALD:** "Of course you are. *No, you're not.*"

**Scene 2: the forging.** A slow, patient crafting sequence. Heat, iron, hammer, quench. Torvald hums a deep, low forge-song: a few simple bars, over and over.

*(Gameplay: a short, rhythmic mini-game. The player strikes on the beat; Torvald corrects. A *good* nail is not about strength, but about *timing.*)*

**TORVALD:** "Not so hard. It's *iron*, not an *enemy.*"
**TORVALD:** "Again."
**TORVALD:** "*Again.*"
> ► **(Sing along.)** — `[Closeness]` Torvald, startled, sings louder.
> ► **(Strike in silence.)** — `[Respect]` He nods, impressed.
> ► **(Ask about the song.)** — `[Trust]` **TORVALD:** "My da's. It's about a nail."

**Scene 3: the wrapped blade.** On the way out, the player passes a corner of the forge, where a long, cloth-wrapped shape leans against the wall. Torvald stops, stiffens.

**TORVALD:** "...That is *not* a nail."
**TORVALD:** "Do not touch it. Please."
> ► **"I won't."** — `[Trust]` **TORVALD:** "Thank you."
> ► **"What is it?"** — `[Tension]` **TORVALD:** "A *job.* One I haven't finished."
> ► **"When you're ready."** — `[Respect]` **TORVALD:** "...Aye."

**Scene 4: the nail.** At dawn, a single, plain, slightly crooked nail lies on the anvil. It is the player's.

**TORVALD:** (inspecting it, grudging) "...It'll *hold.*"
**TORVALD:** "Keep it. It's the *first.* Everyone remembers their first."
*He wraps it in a scrap of cloth and presses it into the player's hand.*

**Outcomes and receipt.**
- Whatever the player chose, Torvald's blade is not discussed again until its own arc. A *sing-along* branch adds a forge-song to Torvald's idle chatter.
- **Receipt:** a small, crooked iron nail in the player's Journal; Torvald hums the forge-song when the player walks past a forge.

<!-- quest
id: qst_pat_hang_torvald
title: A Nail for the Anvil
rank: C
type: Companion
giver: npc_torvald_stonebeard
region: reg_iron_hold
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: pat_hang_torvald_done
summary: Torvald offers to teach the player to forge a single nail. It takes all night, and a wrapped blade stays in the corner.
objectives:
  talk npc_torvald_stonebeard
  reach ih_torvald_forge
  choice sing_silence_or_ask
-->
