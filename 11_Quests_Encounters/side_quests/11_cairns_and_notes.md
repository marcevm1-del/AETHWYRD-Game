# 11e-11 — Cairns and Notes: Five Found-Story Quests (draft)

> *"The best quest in a place is the one the place was already telling."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 1 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** The player *finds* a scene (a laid table, a dark lantern, a stair, an empty tent, an abandoned sled) and reads it: objects, a note, a faint echo. Nobody offers a quest. The story is **already over**, except for one thing someone left unfinished. The player may finish it, or not. Nothing here is a marker on the map.

**How they start.** There is no exclamation mark. Each quest has a **world cue** (the player's chosen guidance channel, Canon §6): a lantern that sways with no wind, a bird that lands and waits, a drifting petal, a distant bell. Once found, the scene adds a **Journal note**, and a *voice* or *echo* becomes the quest-giver in the data. Echoes are gentle, never hostile, and never "remember" the player (Canon §4d).

**Rules these keep.** No fail state; no combat required; every one is *completable by a careful player who only reads*. The reward is always a receipt in the world.

| # | Quest | Rank | Region | Mood |
|---|---|---|---|---|
| 1 | The Table Set for Six | B | Sunscar | A seat saved for a friend |
| 2 | The Lighthouse That Wasn't Lit | B | Goldmere Coast | Keeping the dark on purpose |
| 3 | Ninety-Nine Steps | B | Shen-Lu | A stair of stories, one blank |
| 4 | The Wedding Tent | C | Strife Marches | A truce that never got to be signed |
| 5 | A Quiet Place to Wait | A | Whitewater Reach | A dog, a sled, a promise |

## Cast (echoes and voices)

<!-- npc
id: npc_echo_guide_tamar
name: Echo of Guide Tamar
tier: townsfolk
race: Human
region: reg_sunscar
settlement: The Qadira road
role: Echo of a caravan guide
backstory: A faint, patient echo of a caravan guide who died keeping her party together, and who has been waiting a very long time for the sixth chair to be filled.
-->
<!-- npc
id: npc_voice_keeper_orsolya
name: Voice of Keeper Orsolya
tier: townsfolk
race: Human
region: reg_goldmere_coast
settlement: The Dark Light
role: Voice in a lighthouse lamp
backstory: A tired, wry voice that speaks from a lamp that has not been lit in thirty years, and that would very much like to explain itself.
-->
<!-- npc
id: npc_voice_on_the_stair
name: The Voice on the Stair
tier: townsfolk
race: Spirit
region: reg_shen_lu
settlement: The Hundred-Stair Mountains
role: Voice of the stair
backstory: A soft, unhurried voice that counts the steps of a mountain stair, one word for each, and has never once reached a hundredth.
-->
<!-- npc
id: npc_echo_captain_reva
name: Echo of Captain Reva Sunder
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: The border baronies
role: Echo of a mercenary captain
backstory: A brisk, weary echo of a mercenary captain who arranged a wedding between two rival companies and died the morning of it.
-->
<!-- npc
id: npc_echo_whaler_ketil
name: Echo of Ketil the Whaler
tier: townsfolk
race: Human
region: reg_whitewater_reach
settlement: The ice shelf
role: Echo of an old whaler
backstory: A gentle, tired echo of an old whaler who sat down on his sled to rest and did not get up, and who is very proud of his dog.
-->

---

## 1. The Table Set for Six

*B · Exploration · the Qadira road · found scene; echo of Guide Tamar*

**World cue.** On the road to the Oasis of Qadira, in a dry wash, a ring of five weather-polished skeletons sits around a table of sun-bleached planks. A lantern hangs from a pole above it, swaying with no wind.

**The scene.** The table is set for six. Five seats are occupied. One is empty, its cup *full of water*, a small, perfect sphere that does not evaporate. A scrap of oilcloth is pinned under the cup.

> *"She went for the well at dawn. We said we would wait. We are waiting. — T."*

**Scene 1: the cup.** The player touches the cup. The air shivers. A faint figure forms behind the empty chair: a lean woman in a faded guide's veil.

**TAMAR (echo):** "...You came the wrong way. The road is *that* way."
**TAMAR:** "Forgive me. I do not always remember I am dead."
**TAMAR:** "We were seven. A storm closed the pass. I took one water-skin and went for Qadira's well. The others said: *we will wait.*"
> ► **"Who went for the water?"** — **TAMAR:** "I did. I am the sixth. I think I did not come back."
> ► **"They're still waiting?"** — **TAMAR:** "They are *very* good at waiting."
> ► **"What do you want?"** — **TAMAR:** "To sit down. And I cannot, until I know I *got there*."

**Scene 2: the long walk.** The player follows a trail of faint, bright footprints in the sand, visible only at dusk. Two miles on, at the mouth of a dry gully, a single skeleton lies half-buried, a water-skin still clutched to its chest, *empty*. It lies a hundred paces from a well that was *dry the day it died*.

**TAMAR (echo, appearing):** "...Oh."
**TAMAR:** "I found the well. It was dry. So I came *back*. I did not make it."
**TAMAR:** "I was bringing them *nothing*."
> ► **"You were coming back."** — **TAMAR:** "Yes."
> ► **"The well was dry for everyone."** — **TAMAR:** "Then I was *right to go*."
> ► **"They never knew."** — **TAMAR:** "...That is the worst part."

**Scene 3: the water.** The player carries Tamar's bones, wrapped in her own veil, the long way back. At the table, the five seated skeletons do not move. But the *cup*, the full cup, begins to tremble.

**ECHO OF THE LEADER:** (a deeper voice from the oldest chair) "*You are late.*"
**TAMAR:** "...I'm sorry."
**ECHO OF THE LEADER:** "*We saved your seat.*"
*She sits. For the first time, the six chairs are full.*
> ► **(Pour the cup out onto the sand.)** — The water vanishes into a patch of green.
> ► **(Leave the cup.)** — It stays, perfect and still.
> ► **(Drink to them.)** — A gentle, silent toast.

**Scene 4: the dusk.** The seven figures rise, one at a time, and walk toward the horizon. The lantern above the table gutters. The skeletons settle into white sand. A single palm seedling pokes through where the cup stood.

**Outcomes and receipt.**
- The caravan guides are at rest. The player may bury them or leave them as they are. Either way, the lantern is *lit* the next dusk, and caravans use it as a landmark.
- **Receipt:** a palm tree grows at the table; the Qadira water-keepers add a seventh line to their shore-songs: *"They waited."*

<!-- quest
id: qst_pat_cairn_sixth_chair
title: The Table Set for Six
rank: B
type: Exploration
giver: npc_echo_guide_tamar
region: reg_sunscar
level: 104
act: 4
requires_rank: B
reward: 12000 | 700 | 52000
sets: pat_cairn_sixth_chair_done
summary: A caravan guide's echo sits at a laid table with an empty chair. The sixth guide went for water and never came back.
objectives:
  reach sunscar_set_table
  reach sunscar_dry_gully
  choice pour_leave_or_toast
-->

---

## 2. The Lighthouse That Wasn't Lit

*B · Investigation · the Dark Light, Goldmere Coast · found scene; voice of Keeper Orsolya*

**World cue.** Along the Goldmere cliffs, one of the old lighthouses is *dark*, and ships steer *away* from it, as if by habit. A gull perches on its rail, waiting.

**The scene.** The lamp-room door is unlocked. A logbook lies open on the desk, the last entry dated thirty years ago:

> *"The wreck-tide has shifted. Tonight I will not light it. Orsolya."*

**Scene 1: the log.** The player reads the log backward. Every entry has a ship's name, a date, and the word *"lit"* or *"dark."*

*"Tidehawk: lit. Safe."*
*"Marguerite: lit. Safe."*
*"Windlass: lit. Lost with all hands. The Krakenmother came up under the light."*
*"The Reedcutter: dark. Safe."*

**VOICE (from the lamp):** "...You've read it, then."
**VOICE:** "I'd hoped someone would. Thirty years is a long time to be the only one who knows."
> ► **"You stopped lighting it."** — **VOICE:** "I *started not lighting it*. There is a difference."
> ► **"Why?"** — **VOICE:** "Because the light *draws her*."
> ► **"Who is 'her'?"** — **VOICE:** "You know who."

**Scene 2: the truth.** The Krakenmother Ys follows the light as moths follow a lantern: wherever a lighthouse burns, her coils come near. A lit lamp *saves* ships from rocks, but it *calls* the wreck-tide. The lighthouse keeper had to choose between the rocks and the kraken. She chose the kraken's absence.

**VOICE:** "A dark coast kills a few ships a year. A lit coast kills a *fleet* in a night."
**VOICE:** "I counted, you see. I'm an honest keeper."
**VOICE:** "Nobody ever thanked me for the ships I didn't lose."

**Scene 3: the choice.** The player may relight the lamp, keep it dark, or find a third way.

> ► **"Relight it."** — Ships are safe from rocks; the wreck-tide returns. A hard, true consequence.
> ► **"Keep it dark."** — Keeper Orsolya's judgement is honoured; some ships still founder.
> ► **"Light it with a shield."** — A tricky, partial solution: a *shuttered* lamp that flashes only when called by a ship's own signal.
> ► **"Tell the harbour board."** — The board is stunned; the keeper's story is told; the port's rules change.

**Scene 4: the lamp.** Whichever the player chooses, Orsolya's voice drifts, quietly, out of the lantern like breath out of a cold room.

**ORSOLYA:** "Thank you. For *deciding with me*."
**ORSOLYA:** "It is a lonely thing to decide alone."
*The lamp, for a moment, lights up in a faint, gold, spectral glow, and then settles.*

**Outcomes and receipt.**
- The lighthouse is lit, dark or signal-lit. Each option has a *regional receipt* (shipping, salvage, a changed Krakenmother pre-fight line). There is no right answer; the log records every ship that sails either way.
- **Receipt:** a small plaque on the tower: *"Orsolya, who counted."*

<!-- quest
id: qst_pat_cairn_dark_light
title: The Lighthouse That Wasn't Lit
rank: B
type: Investigation
giver: npc_voice_keeper_orsolya
region: reg_goldmere_coast
level: 100
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: pat_cairn_dark_light_done
summary: A lighthouse has been dark for thirty years. The keeper's log says she stopped lighting it on purpose.
objectives:
  reach goldmere_dark_lighthouse
  talk npc_voice_keeper_orsolya
  choice relight_dark_shutter_or_report
-->

---

## 3. Ninety-Nine Steps

*B · Exploration · the Hundred-Stair Mountains · found scene; the Voice on the Stair*

**World cue.** On a quiet, un-trodden side-stair of Shen-Lu, a single drifting white petal hangs in the air, floating *upward*, one step at a time.

**The scene.** Each step bears a short carved line, a sentence or two, in an old brush-script. They are small stories. Ninety-nine of them. The hundredth step is smooth and blank.

*Step 1: "A farmer who loved a mountain."*
*Step 17: "A thief who gave it all away to a stranger in the snow."*
*Step 44: "A monk who forgave her teacher, too late."*
*Step 73: "A child who counted stars and lost count and was happy."*
*Step 99: "A traveller who climbed this stair, and read every step, and wept at the last one."*

**Scene 1: the climb.** The player climbs. At each step the voice reads, softly, in the dark of the cloud-line:

**VOICE:** "One. A farmer who loved a mountain."
**VOICE:** "Two. A girl who was afraid of the dark, and became a lamplighter."
*(Gameplay: a slow, quiet climb through ninety-nine tiny scenes; the player may linger at any step to hear the full story, a short text with a tiny scene, a petal, a bell.)*
> ► **(Listen to every step.)** — The climb takes an hour. It is worth it.
> ► **(Skip some.)** — The voice sighs, and continues.
> ► **(Say a story aloud.)** — The voice stops, and listens.

**Scene 2: the ninety-ninth.** At the ninety-ninth step, the voice is silent for a long time.

**VOICE:** "...Ninety-nine."
**VOICE:** "I have counted this far for four hundred years. I have never reached the end."
**VOICE:** "The hundredth is blank. By the founder's rule, it must be filled by *someone who has climbed*."
> ► **"By whom?"** — **VOICE:** "By the one who climbs. And reads. And has a story."
> ► **"What story?"** — **VOICE:** "Yours. A small one."
> ► **"Why have you waited?"** — **VOICE:** "Because the people who climbed did not *have* one."

**Scene 3: the hundredth.** The player carves (in a simple, guided mini-game) a single sentence on the blank step. The player *chooses the words*: a short line, selected from a handful of phrases, or written freely.

*Possible lines:*
- *"A stranger who came from nowhere and stayed."*
- *"A swordsman who put down the sword."*
- *"Someone who read all ninety-nine."*

**VOICE:** (very quietly) "...One hundred."
**VOICE:** "Thank you. I can rest."

**Scene 4: the sky.** The stair ends at a small, clean terrace of white stone, open to the sky. A single seat of stone faces the view. A faint trace of a smile in the voice, as it fades into the cloud.

**Outcomes and receipt.**
- The hundredth step bears the player's line. Shen-Lu's pilgrims add it to the stair's "Hundred Tales," and the stair is no longer silent.
- **Receipt:** a small stone seat at the top; a new petal falls on each step at dawn.

<!-- quest
id: qst_pat_cairn_ninety_nine
title: Ninety-Nine Steps
rank: B
type: Exploration
giver: npc_voice_on_the_stair
region: reg_shen_lu
level: 108
act: 4
requires_rank: B
reward: 13000 | 760 | 56000
sets: pat_cairn_ninety_nine_done
summary: A quiet stair in Shen-Lu has ninety-nine carved stories and a blank hundredth step. The voice that counts them has never reached the end.
objectives:
  reach shenlu_ninety_nine_stair 3
  reach shenlu_hundredth_step
  choice carve_a_line
-->

---

## 4. The Wedding Tent

*C · Exploration · the border baronies · found scene; echo of Captain Reva Sunder*

**World cue.** On a ridge in the Strife Marches, at dusk, a long white tent stands among the scrub, its flaps tied open, its lanterns lit though no one has lit them. A banner of *two* flags, tied together, hangs from a pole.

**The scene.** The tent is set for a feast: a long table, forty places, half-eaten food gone to dust, two chairs at the head decorated with faded ribbons. At each place, a name card in two hands: *"Ashcombe Company"* on one side, *"Redfall Company"* on the other.

> *Printed on a worn invitation: "Join us for the joining of the two houses of the Marches. A treaty, a wedding, a feast. We will be forty on each side. Come in peace."*

**Scene 1: the echo.**

**REVA (echo):** "...You're early. The groom isn't here yet."
**REVA:** "I'm Captain Reva Sunder. I arranged all this. The Ashcombe and the Redfall have fought over this ridge for thirty years. A wedding, I said. A *wedding*. Nobody ever died at a wedding."
**REVA:** "...Well. I did."
> ► **"What happened?"** — **REVA:** "A scout. A rumour. Someone said the other side had come armed. The morning of the wedding."
> ► **"Where are the guests?"** — **REVA:** "They never came. Not *really*."
> ► **"Where's the couple?"** — **REVA:** "Hm. That's the part I can't remember."

**Scene 2: the search.** The player explores the ridge. In the Ashcombe camp: a groom's coat, folded. In the Redfall camp: a bride's veil, wrapped in paper. Between the two, a path, trodden through the scrub, where, at night, two figures *met in secret* for a whole spring.

**NOTE IN THE COAT:** *"Marren: I will not marry for a treaty. I will marry for you."*
**NOTE IN THE VEIL:** *"Tobyn: I do not care who the captains are. I care that you walk with me."*

**REVA (echo, soft):** "...They were *in love.* I arranged the wedding of two people *who already were.*"
**REVA:** "And I never *knew.*"

**Scene 3: the vows.** The player carries the two notes to the table. A pair of faint figures forms at the head, hand in hand: a lean young man and a freckled young woman, both in their wedding clothes. They are very young.

**MARREN:** "Are we late?"
**TOBYN:** "We are *very* late."
**REVA:** "...You came."
> ► **"Say the vows."** — The echo-couple does.
> ► **"Read the notes aloud."** — They weep and laugh.
> ► **"Let the captains' echoes speak."** — Two older echoes, one from each camp, take their places.

**Scene 4: the treaty.** At the head of the table, between two empty goblets, a scroll unrolls itself: a treaty, written in two hands, *signed*. The two company-banners lower, tie together, and rise as one.

**REVA:** "...That's the first thing I ever finished."
*The tent's lanterns brighten. The echoes, forty on each side, raise their glasses.*

**Outcomes and receipt.**
- The echoes are at peace; the ridge becomes neutral ground in the Marches' folk memory. If the player *doesn't* complete the vows, the tent remains, lit.
- **Receipt:** a stone pair of rings at the ridge; mercenaries from both companies leave small tokens on the path.

<!-- quest
id: qst_pat_cairn_wedding_tent
title: The Wedding Tent
rank: C
type: Exploration
giver: npc_echo_captain_reva
region: reg_strife_marches
level: 74
act: 3
requires_rank: C
reward: 4600 | 255 | 17000
sets: pat_cairn_wedding_tent_done
summary: A wedding tent stands on a ridge in the Strife Marches, set for two rival companies. The couple never arrived.
objectives:
  reach marches_wedding_tent
  reach marches_secret_path
  choice vows_notes_or_captains
-->

---

## 5. A Quiet Place to Wait

*A · Exploration · the ice shelf · found scene; echo of Ketil the Whaler*

**World cue.** On the white shelf of Whitewater Reach, a single dog sits very still, facing the horizon, beside an overturned sled. It does not bark. It does not move. It looks, with perfect patience, at the same spot on the ice.

**The scene.** The dog is a sled-hound, thin, old, *alive*, and wearing a hand-stitched coat. The sled behind it holds a small bundle, a flask of cold tea, a harpoon and a folded note:

> *"Pilot: Stay. I will be back by supper. I am just going to see about the fish. — K."*

**Scene 1: the dog.** The dog does not bark, but it notices the player. Its tail thumps once.

**PILOT (via a gentle, wordless bark):** *(a single low *whuff*, and a look)*
*(Gameplay: the player can approach, feed, speak. The dog accepts food, but returns to its post.)*
> ► **(Give it a fish.)** — It eats with dignity.
> ► **(Sit with it.)** — It leans against your leg.
> ► **(Read the note aloud.)** — The dog's ears flick.

**Scene 2: the whaler.** Following the dog's gaze, the player crosses a mile of ice to a low pressure-ridge, where a figure sits, upright and unmoving, in a heavy fur coat, a line still held in frozen fingers. At the end of the line, a hole in the ice, a single silver fish just visible below.

**KETIL (echo):** "...Ah. Did he send you?"
**KETIL:** "I told him *stay.* He's a good lad. He stays."
**KETIL:** "It is a *very long supper*, I am afraid. I got to fishing, and... the cold is quiet here."
> ► **"You've been gone since the first snow."** — **KETIL:** (a long, slow breath) "...Have I? It feels like an afternoon."
> ► **"Pilot's still waiting."** — **KETIL:** "...He would."
> ► **"Come home."** — **KETIL:** "I am not sure I can."

**Scene 3: the tea.** Ketil's echo shares the last of the tea. He tells the story: a good winter; a bad catch; the line bit; he sat, only to rest; the cold took him gently.

**KETIL:** "I was not afraid. That's the odd part. I was just... *tired*."
**KETIL:** "But I told the boy to stay. And he's an honest dog."
> ► **"He's old. He needs to be released."** — **KETIL:** "Yes. I will tell him."
> ► **"Walk back with him."** — **KETIL:** "...I would like that."
> ► **"Take his place."** — **KETIL:** "You *would* not."

**Scene 4: the call.** Ketil rises, impossibly light, and calls across the ice in a voice like wind in a rope:

**KETIL:** "*Pilot! Come!*"
*The old dog is on his feet at once, tail a blur, bounding across the shelf. He leaps. For a moment, impossibly, there are two shapes on the ice, an old man and an old dog, running toward the horizon.*
**KETIL (echo, fading):** "*Supper's ready, lad.*"
*The sled settles. The ice is empty. A light, steady snow falls.*

**Outcomes and receipt.**
- The echo is at rest. Pilot (the living dog, in the first scene) is *not* gone: the player may bring him to Whitewater's village, where a family takes him in. If the player prefers, Pilot follows the player.
- **Receipt:** a small hand-stitched dog-coat in the player's Journal; the fishing village names its first litter of pups *Ketil's*.

<!-- quest
id: qst_pat_cairn_quiet_wait
title: A Quiet Place to Wait
rank: A
type: Exploration
giver: npc_echo_whaler_ketil
region: reg_whitewater_reach
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: pat_cairn_quiet_wait_done
summary: An old sled-dog sits beside an overturned sled on the ice, waiting for a whaler who said he would be back by supper.
objectives:
  reach whitewater_sled_shelf
  reach whitewater_pressure_ridge
  choice release_walk_or_take_dog
-->
