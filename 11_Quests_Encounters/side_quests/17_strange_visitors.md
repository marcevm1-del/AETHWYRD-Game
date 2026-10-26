# 11e-17 — Strange Visitors: Five Road Encounters (draft)

> *"The road is a bad place to be in a hurry, and a good place to be interrupted."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 7 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** The player is on the way somewhere else, and *something* is in the road: a puppet on a milestone, a cart with no driver, an old woman with a ledger of last words, a chest that blinks, a highwayman with an odd rule. These are **short** (10–15 minutes), **self-contained**, and **never required.** They borrow the idea of *surprising encounters on the way to somewhere else*, and make each one an original story.

**How they trigger.** Each is a **road encounter** keyed to a region and a *time of day* (the world cue is the visitor themselves). Each appears **at most once per save** and is *never* announced on the map. A short Journal note records it. Each can be walked past.

**Rules.** Nobody dangerous is "just a monster." Nobody punishes a polite refusal. The tone is **gentle odd**: warm, a little uncanny, never grim.

| # | Quest | Rank | Region | The visitor |
|---|---|---|---|---|
| 1 | The Puppet on the Milestone | E | Aldmere | A marionette who waits |
| 2 | The Cart That Pulled Itself | D | Velmark | A cake, sixty years late |
| 3 | The Collector of Last Words | C | Aldmere | An old woman with a ledger |
| 4 | The Mimic Who Wanted a Friend | D | Aldmere | A chest that blinks |
| 5 | The Highwayman Who Took Only Burdens | B | Strife Marches | A thief with a strange kindness |

## Cast

<!-- npc
id: npc_barnaby_spindle
name: Barnaby Spindle
tier: townsfolk
race: Human
region: reg_aldmere
settlement: The Ashby road
role: Travelling puppeteer
backstory: A cheerful, flustered travelling puppeteer who inherited his master's marionettes and has just discovered that one of them has gone for a walk.
-->
<!-- npc
id: npc_cart_driver_ghost
name: The Driver of the Late Cart
tier: townsfolk
race: Ghost
region: reg_velmark
settlement: The white road
role: Ghost carter
backstory: A polite ghost in a flour-dusted coat, driving a cart he has driven for sixty years toward a wedding that has not been held since.
-->
<!-- npc
id: npc_maudlin_penn
name: Old Maudlin Penn
tier: townsfolk
race: Human
region: reg_aldmere
settlement: The royal road
role: Collector of last words
backstory: A brisk, unsentimental old woman who writes down the last words of every traveller who will tell her, and has filled forty-one ledgers.
-->
<!-- npc
id: npc_chester_mimic
name: Chester
tier: townsfolk
race: Mimic
region: reg_aldmere
settlement: The barrow road
role: A friendly chest
backstory: A large, battered chest with a very long tongue and a great deal of loot, who has been waiting for someone to open him *kindly* for two hundred years.
-->
<!-- npc
id: npc_dunmore_light_hand
name: Dunmore the Light-Handed
tier: major
race: Human
region: reg_strife_marches
settlement: The border baronies
role: Highwayman
backstory: A courteous, sad-eyed highwayman who stops travellers on the Marches road and takes, with an apology, only the heaviest thing they carry.
-->

---

## 1. The Puppet on the Milestone

*E · OddJob · the Ashby road · giver Barnaby Spindle*

**The encounter.** At dawn, a small marionette sits on the milestone outside Ashby, legs dangling, strings slack. It is wearing a tiny blue coat. It is looking down the road.

**Scene 1: the puppeteer.** A flustered man in a patched coat comes panting up the road.

**BARNABY:** "*There* you are! Don't *look* at him. He's *shy.*"
**BARNABY:** "I'm Barnaby Spindle. That's *Little Ned.* He was my master's. He... walks."
**BARNABY:** "Not *always.* Only since the master died. Every dawn he sits on a milestone and *waits.*"
> ► **"Waits for what?"** — **BARNABY:** "I don't *know.*"
> ► **"Is he alive?"** — **BARNABY:** "He's *wood.* With *opinions.*"
> ► **"Let me talk to him."** — **BARNABY:** "He won't answer. But he *listens.*"

**Scene 2: the puppet.** The player sits beside Little Ned on the milestone. The marionette tilts its head. A tiny wooden hand lifts, and points back along the road, toward a distant hill.

**BARNABY:** "He's pointing at the old theatre. Where the master died."
**BARNABY:** "I never went back. It was... a *bad* day."
> ► **"Let's go."** — **BARNABY:** "...Together?"
> ► **"What happened?"** — **BARNABY:** "The master had a stroke on stage. In the middle of a *comedy.*"
> ► **"Maybe Ned wants the show finished."** — **BARNABY:** "...Oh."

**Scene 3: the show.** In the dusty, half-collapsed theatre, a half-built stage and a half-finished play, *The Fox and the Bell.* Little Ned walks onto the boards, and stops.

**BARNABY:** (very quietly) "It's the last scene. He never finished the last scene."
*Barnaby, hands trembling, takes up the strings. The player reads the last lines from a battered script. Little Ned bows to an empty audience.*
**LITTLE NED (via Barnaby's voice):** "...And so the fox rang the bell, and *everyone came home.*"
*From the back of the theatre, a single, soft clap. No one is there.*

**Outcomes and receipt.**
- The play is finished. Little Ned sits quietly in Barnaby's lap; he never walks off again. If the player declines, Ned still waits on the milestone.
- **Receipt:** a tiny blue marionette coat hangs in Barnaby's wagon; the milestone has a small carved fox.

<!-- quest
id: qst_pat_visitor_puppet
title: The Puppet on the Milestone
rank: E
type: OddJob
giver: npc_barnaby_spindle
region: reg_aldmere
level: 16
act: 2
requires_rank: E
reward: 280 | 20 | 900
sets: pat_visitor_puppet_done
summary: A marionette sits on a milestone each dawn, waiting. Its puppeteer's master died before finishing the last scene.
objectives:
  talk npc_barnaby_spindle
  reach ashby_old_theatre
  choice finish_listen_or_leave
-->

---

## 2. The Cart That Pulled Itself

*D · OddJob · the white road · giver the Driver of the Late Cart*

**The encounter.** At dusk on a lonely stretch of the White Duchies' road, a cart rolls past with no horse. A lantern hangs from the front. A very pale man in a flour-dusted coat sits on the driver's bench, holding the reins of nothing.

**Scene 1: the driver.**

**DRIVER:** "Good evening! Would you mind awfully if I asked for *directions?*"
**DRIVER:** "I am delivering a wedding cake. To the Hallowmere house. I am *rather late.*"
**DRIVER:** "...Sixty years, I think. I lost count at the second toll-booth."
> ► **"The Hallowmere house is gone."** — **DRIVER:** "Gone?"
> ► **"Who's the wedding for?"** — **DRIVER:** "Miss Alis Hallowmere and Mr. Bartholomew Reed."
> ► **"What's in the cake?"** — **DRIVER:** "Seven layers. Almond. And a *secret.*"

**Scene 2: the old couple.** A short road away, in a small cottage, lives a very old woman, **Alis Reed**, née Hallowmere. She has never forgotten the cake.

**ALIS:** "The cake! The *cake.* Oh, my. My mother cried for a week."
**ALIS:** "We married anyway. In the *rain.* With a loaf of bread. We were very happy."
**ALIS:** "Bartholomew died, four years ago."
**ALIS:** "...But I should *like* the cake."
> ► **"I'll bring the driver."** — **ALIS:** "Do."
> ► **"I'll bring the cake."** — **ALIS:** "Oh, *yes.*"

**Scene 3: the delivery.** At the cottage gate, the ghost cart arrives. The cake, seven tiers, perfectly intact, white sugar, a tiny pair of sugar-doves, is carried to the table. Alis, in her good dress, cuts the first slice.

**ALIS:** "...Almond."
**ALIS:** "And the secret?"
**DRIVER:** "A *very small* silver ring, madam. At the *centre.*"
*Alis finds it. She holds it up in the lamplight. It fits.*
**ALIS:** (laughing, crying) "...Bartholomew would have *loved* this."

**Outcomes and receipt.**
- The driver's delivery is complete; he drives *away*, and the cart dissolves into dust and moonlight. Alis keeps the ring.
- **Receipt:** a seven-tier cake on the cottage table; a small sugar-dove on the player's Journal page.

<!-- quest
id: qst_pat_visitor_late_cart
title: The Cart That Pulled Itself
rank: D
type: OddJob
giver: npc_cart_driver_ghost
region: reg_velmark
level: 40
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: pat_visitor_late_cart_done
summary: A ghost carter on the White Duchies' road is sixty years late delivering a wedding cake.
objectives:
  talk npc_cart_driver_ghost
  reach velmark_hallowmere_cottage
  choice bring_driver_or_cake
-->

---

## 3. The Collector of Last Words

*C · OddJob · the royal road · giver Old Maudlin Penn*

**The encounter.** On the royal road, an old woman sits at a roadside table with a stack of ledgers, a pot of ink and a handwritten sign: *"LAST WORDS COLLECTED. NO CHARGE. NO NONSENSE."*

**Scene 1: the table.**

**MAUDLIN:** "Sit. You look like someone who'll say something interesting."
**MAUDLIN:** "I collect last words. I've forty-one ledgers. Seven thousand, two hundred and eight."
**MAUDLIN:** "Most of them are *rubbish.* People are *very* bad at it."
> ► **"Why?"** — **MAUDLIN:** "Because I'm *nosy.*"
> ► **"What's the best one?"** — **MAUDLIN:** "'I forgot to feed the cat.'"
> ► **"I'm not dying."** — **MAUDLIN:** "Nobody *is.* Until they are."

**Scene 2: the ledgers.** The old woman leafs through a few.

*"Oh, the soup's gone cold."*
*"Tell Margit I forgive her."*
*"It's very *bright.*"*
*"Is it raining?"*
*"I'd like another biscuit."*

**MAUDLIN:** "They're not *grand.* They're *human.* That's the *point.*"
**MAUDLIN:** "A person's last words are their *first honest* words."
> ► **"What do people say, mostly?"** — **MAUDLIN:** "A name. Or an apology."
> ► **"Do you ever regret it?"** — **MAUDLIN:** "...Sometimes."
> ► **"What would yours be?"** — **MAUDLIN:** "I'm *asking you.*"

**Scene 3: the question.** The old woman leans in, pen poised.

**MAUDLIN:** "If you had one sentence. To anyone. *What would it be?*"
*(Gameplay: the player writes, or chooses from a handful, a sentence. It is recorded in Maudlin's ledger, and, in a small touch, in the player's Journal, as a line they can reread.)*
> ► **"I'm glad I came."**
> ► **"Thank you, all of you."**
> ► **"I'll see you at the end."**
> ► **(Write your own.)**

**MAUDLIN:** (reading it back, a little rough) "...That'll do. That'll do *very* well."

**Scene 4: the last page.** As the player rises, Maudlin presses a folded page into their hand.

**MAUDLIN:** "That's mine. For when I go."
**MAUDLIN:** "Don't read it *yet.* Give it to someone who'll want to."
*Written on the page, in a very small hand: "It was a good road."*

**Outcomes and receipt.**
- The player's line is recorded; Maudlin's ledger is carried to the next traveller. If the player writes something *silly*, she writes it exactly as given, which is the whole point.
- **Receipt:** a folded page in the Journal; a small wooden sign appears at roadside, with the player's line carved at the bottom.

<!-- quest
id: qst_pat_visitor_last_words
title: The Collector of Last Words
rank: C
type: OddJob
giver: npc_maudlin_penn
region: reg_aldmere
level: 62
act: 3
requires_rank: C
reward: 3700 | 205 | 14000
sets: pat_visitor_last_words_done
summary: An old woman at a roadside table collects people's last words. She asks the player for theirs.
objectives:
  talk npc_maudlin_penn
  choice glad_thanks_end_or_own
-->

---

## 4. The Mimic Who Wanted a Friend

*D · OddJob · the barrow road · giver Chester*

**The encounter.** On the barrow road, beside a half-collapsed cairn, sits a handsome old chest, iron-banded, with a heavy padlock and a very faint, anxious *blink.*

**Scene 1: the chest.**

**CHESTER:** (a small, wet voice from within) "...Is somebody *there?*"
**CHESTER:** "Please don't *scream.* I'm not going to *bite.* I mean, I *can.* I *don't.*"
**CHESTER:** "I'm Chester. I'm a chest. I've been a chest for two hundred years. I'm *very* good at it."
> ► **"You're a mimic."** — **CHESTER:** "*Technically.* But that's a *rude* word."
> ► **"Why are you talking to me?"** — **CHESTER:** "Because nobody ever *opens* me *kindly.*"
> ► **"What's in you?"** — **CHESTER:** "Gold. A great deal of *gold.* And a spoon."

**Scene 2: the confession.** The chest, trembling, explains: *everyone* who ever found him *screamed* and *ran*, or *hit* him. *He's never been asked how he is.*

**CHESTER:** "I'm *lonely.* There. I said it."
**CHESTER:** "I eat the occasional adventurer's boot. But I *never* hurt anyone. I just *wait.*"
**CHESTER:** "I'd love a friend. A friend who *opens* me and says: *hello, Chester.*"
> ► **"Hello, Chester."** — A long, wobbling silence.
> ► **"Can I take the gold?"** — **CHESTER:** "Of *course.* It's *yours.* I only *keep* it."
> ► **"Come with me."** — **CHESTER:** "...To *where?*"

**Scene 3: the opening.** The player, very gently, lifts the lid. Inside: a great heap of old coin, a rusted sword, a pair of dusty reading-glasses, a *spoon*, and, at the back, a *very* small, very damp tongue.

**CHESTER:** (muffled, delighted) "*Hello.*"
**PLAYER:** "Hello, Chester."
**CHESTER:** "...*Hello!*"
*(Gameplay: the player may take *some* of the gold, all, none or *give* something. Chester accepts any gift with a small, reverent *"thank you."*)*

**Scene 4: the road.** The player has three choices for Chester's future.
- **Leave him** on the barrow road with a *signpost:* *"Open kindly."*
- **Take him** to the Griffon in Brindlewick, where Whiskers will *judge* him.
- **Leave him a book.** A *very* long book. A dictionary.

**CHESTER:** "...I've never had a *dictionary.* I'll read it *all.*"

**Outcomes and receipt.**
- Chester becomes a gentle roadside fixture. *If the player took all the gold,* he is *quiet,* not angry.
- **Receipt:** a carved signpost, *"Chester. Open kindly."*; travellers leave him small gifts.

<!-- quest
id: qst_pat_visitor_mimic
title: The Mimic Who Wanted a Friend
rank: D
type: OddJob
giver: npc_chester_mimic
region: reg_aldmere
level: 38
act: 2
requires_rank: D
reward: 1400 | 85 | 5800
sets: pat_visitor_mimic_done
summary: A mimic that looks like a chest has waited two hundred years to be opened kindly.
objectives:
  talk npc_chester_mimic
  reach aldmere_barrow_road_cairn
  choice leave_take_or_book
-->

---

## 5. The Highwayman Who Took Only Burdens

*B · Hidden · the border baronies · giver Dunmore the Light-Handed*

**The encounter.** On the Marches road, at dusk, a man in a long coat steps from the hedge, a mask over his eyes, a pistol-less hand outstretched.

**Scene 1: the stand.**

**DUNMORE:** "Good evening. I am a highwayman. This is a robbery. I apologise for the inconvenience."
**DUNMORE:** "I shall take only the *heaviest thing you carry.* Not coin. Not a blade. *The heaviest thing.*"
**DUNMORE:** "You will not miss it. I promise."
> ► **"What do you mean?"** — **DUNMORE:** "You know *exactly* what I mean."
> ► **"I'll fight you."** — **DUNMORE:** "Of course. I'd be *delighted.*"
> ► **"Take it."** — **DUNMORE:** "Thank you."

**Scene 2: the burden.** The highwayman takes the player's hand, closes his eyes and *draws.* A thin silver thread unspools from the player's chest, and in his palm, a small, dark, faintly glowing stone appears.

**DUNMORE:** "...Ah. *There.*"
**DUNMORE:** "That is *your* regret. The biggest one."
**DUNMORE:** "I'll *keep* it for you. For a day. A week. As long as you like."
> ► **"What do I lose?"** — **DUNMORE:** "Only the *weight.* Not the *memory.*"
> ► **"Give it back."** — **DUNMORE:** "...Are you sure?"
> ► **"How long have you done this?"** — **DUNMORE:** "Since I stopped being able to *carry* mine."

**Scene 3: the gallery.** Dunmore leads the player to a small campfire in a hollow. Around it hang a hundred small glowing stones, each a different colour, each a stolen *burden.*

**DUNMORE:** "People do not like to *give* them away. So I *take* them. With an apology."
**DUNMORE:** "I cannot *destroy* them. I can only *keep* them. And, *very* occasionally, return them to someone who is ready."
> ► **"Is mine ready?"** — **DUNMORE:** "You tell me."
> ► **"What's the biggest one?"** — **DUNMORE:** (quietly) "...*Mine.* It is *very* heavy."
> ► **"Can I help you?"** — **DUNMORE:** "...Perhaps."

**Scene 4: the choice.** The player may *take their burden back*, *leave it a while*, or *take on* someone else's.

**DUNMORE:** (gently) "A burden *carried* is not a failure. A burden *shared* is not a *theft.*"
*(Whatever the player chooses, the burden is *named* in a short, personal line, never a lecture.)*

**Outcomes and receipt.**
- Dunmore remains on the road. If the player returns his own burden, *his stone* glows a little *lighter.*
- **Receipt:** a small glowing stone in the player's Journal; the Marches road has a new tale: *"The Light-Handed Man."*

<!-- quest
id: qst_pat_visitor_highwayman
title: The Highwayman Who Took Only Burdens
rank: B
type: Hidden
giver: npc_dunmore_light_hand
region: reg_strife_marches
level: 90
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: pat_visitor_highwayman_done
summary: A highwayman on the Marches road takes only the heaviest thing a traveller carries, and keeps it safe.
objectives:
  talk npc_dunmore_light_hand
  reach marches_highwayman_hollow
  choice reclaim_leave_or_share
-->
