# 11e-30 — Stormreach, the Lightning Coast: Ten Side Quests (draft)

> *"The bolts in the cliff are lightning rods. The towns were built after the first ones worked."*
> — Gazetteer, Stormreach

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light.

**Region:** `reg_stormreach` (the cliff-towns, the Black Peaks, the Rod Forest, the Roc's Nest). **Rank band:** B–A. **Tone:** loud, cheerful, fearless and slightly mad. The people are bolted to the rock above a sea that never calms, and they *like* it.

**Placement notes.**
- **Raikaru, the Storm Roc,** is the region's Tyrant. It nests in the thunderheads and *feeds on the storms,* which grow fiercer each month. Lightning has struck two towns and the fleets cannot go out. No quest here kills Raikaru; quests 3 and 10 change how the region prepares and what the roc *is.*
- Customs the quests rely on: **lightning that strikes a person is a blessing, if they survive;** the dead are **left on high peaks for the lightning to take;** each cliff-town is governed by its **storm-caller** and a council of elders; Stormreach **rope is the strongest in the world;** eggs and guano from the cliffs are the economy.
- Earlier pattern quests here: *A Banner for the Coward* (Kaelthas) and *Cairn of Winds* (a puzzle).
- The three gazetteer hooks (a storm-caller who lost her power; a trapped fleet; a found roc egg) are quests 1, 2 and 3.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Storm-Caller Who Went Quiet | B | Investigation | Isaura Windlass | Grief that frightens a storm |
| 2 | A Rope Along the Cliffs | B | Defense | Harbour-Warden Tavi Longline | A chain of volunteers |
| 3 | The Egg in the Gatherer's Basket | A | Hidden | Pila Seabrow | A tiny future Tyrant |
| 4 | The Best Rope in the World | B | OddJob | Rope-Master Gurr | A craft contest |
| 5 | Struck, and Blessed | B | Hidden | Odd Thunderhand | A man who wants to be ordinary |
| 6 | The Guano Accords | B | Faction | Reeve Marga Bellows | Two towns, one cliff |
| 7 | Rod Forest | B | Defense | Rod-Warden Fenwick Sparks | Apprentices in a bad storm |
| 8 | A Funeral for the Lightning | A | Escort | Ysa Ashpeak | Carrying the dead up the peaks |
| 9 | The Fledgling's Feather | A | Exploration | Hermit Old Bolt | A thunderbird, stuck |
| 10 | The Nest Seen by Lightning | A | Hidden | Councillor Eila Greyfeather | One drawing, by flashes |

## Cast

<!-- npc
id: npc_isaura_windlass
name: Isaura Windlass
tier: major
race: Human
region: reg_stormreach
settlement: Stormreach cliff-towns
role: Storm-caller who has lost her power
backstory: A tall, proud storm-caller of the town of Highmast who has not been able to call a single spark in forty days and has told everyone the roc stole it.
secret: The roc did not take her power; grief did.
-->
<!-- npc
id: npc_tavi_longline
name: Harbour-Warden Tavi Longline
tier: major
race: Human
region: reg_stormreach
settlement: Stormreach cliff-towns
role: Harbour-warden of a trapped cove
backstory: A big-voiced, cheerful harbour-warden whose fishing fleet has been trapped in a cove by the storm for nine days and who has not stopped laughing, because the alternative is worse.
-->
<!-- npc
id: npc_pila_seabrow
name: Pila Seabrow
tier: townsfolk
race: Human
region: reg_stormreach
settlement: The egg-cliffs
role: Egg-gatherer
backstory: A wiry, fearless egg-gatherer who has found, in her basket after a morning on the cliffs, an egg the size of a cask that is warm and humming.
-->
<!-- npc
id: npc_rope_master_gurr
name: Rope-Master Gurr
tier: major
race: Human
region: reg_stormreach
settlement: Stormreach cliff-towns
role: Master rope-maker
backstory: A huge, soft-spoken rope-master who has won the Rope Contest eleven years running and has been secretly hoping someone would beat him for the last three.
-->
<!-- npc
id: npc_odd_thunderhand
name: Odd Thunderhand
tier: townsfolk
race: Human
region: reg_stormreach
settlement: Stormreach cliff-towns
role: Man struck by lightning
backstory: A quiet, thoughtful fisherman who was struck by lightning three years ago, survived, and has been treated like a saint ever since, which he finds exhausting.
-->
<!-- npc
id: npc_marga_bellows
name: Reeve Marga Bellows
tier: major
race: Human
region: reg_stormreach
settlement: The guano cliffs
role: Reeve of the guano-cliffs
backstory: A brusque, loud-voiced reeve who has presided over eleven guano disputes and says the birds are fairer judges than anyone on the council.
-->
<!-- npc
id: npc_fenwick_sparks
name: Rod-Warden Fenwick Sparks
tier: major
race: Human
region: reg_stormreach
settlement: The Rod Forest
role: Warden of the Rod Forest
backstory: A scorched, cheerful rod-warden who has trained forty storm-callers and has been struck seventeen times, which he calls a good average.
-->
<!-- npc
id: npc_ysa_ashpeak
name: Ysa Ashpeak
tier: townsfolk
race: Human
region: reg_stormreach
settlement: Ashpeak
role: Daughter of a dead storm-caller
backstory: A broad-shouldered daughter of a storm-caller who died in his sleep and who has been told, by custom, that he must be carried to a peak to be taken by lightning, in a storm that may kill the carriers.
-->
<!-- npc
id: npc_hermit_old_bolt
name: Hermit Old Bolt
tier: major
race: Human
region: reg_stormreach
settlement: The Black Peaks
role: Hermit of the Black Peaks
backstory: A wild-haired hermit who has lived among the thunderbirds for thirty years and speaks to them in a language that mostly consists of clicks and tea.
-->
<!-- npc
id: npc_eila_greyfeather
name: Councillor Eila Greyfeather
tier: major
race: Human
region: reg_stormreach
settlement: Stormreach cliff-towns
role: Councillor of the storm-callers' guild
backstory: A grey-haired councillor who has never seen the Roc's Nest and has decided, at seventy, that it is time someone drew it.
-->

---

## 1. The Storm-Caller Who Went Quiet

*B · Investigation · Highmast · giver Isaura Windlass*

**The short version.** Isaura has not called a single spark in forty days. She says the roc took her power. She has asked the player to find where.

**What is really going on.** The roc took nothing. Isaura's *brother* was killed by lightning on the Black Peaks six weeks ago. He was not blessed; he *did not survive.* The storm, a living thing in Stormreach belief, *recoils from grief,* and her sorrow has made her *unreachable.*

**Scene 1: the tower.**

**ISAURA:** "Forty days. *Forty.* I raised my hand in the old way, and the sky did *nothing.*"
**ISAURA:** "The roc took it. It *must* have. It *eats* storms. It ate *mine.*"
**ISAURA:** "Find it. Get it *back.*"
> ► **"When did it stop?"** — **ISAURA:** "Six weeks ago."
> ► **"What happened six weeks ago?"** — **ISAURA:** "...Nothing. Nothing *special.*"
> ► **"I'll look."** — **ISAURA:** "Bring a rod."

**Scene 2: the search.** The player follows rumours up the cliffs and down. Storm-callers, rope-makers and egg-gatherers each give a piece.

**GATHERER:** "Six weeks ago? That's the week her brother *went up the peaks.*"
**ROPE-MAKER:** "Mattis. *Good lad.* He was struck on the Third Peak. *He didn't wake.*"
**ELDER:** "She won't talk about it. *Won't mourn.* She just... *works.*"

**Scene 3: the peak.** At dusk, the player leads Isaura to the Third Peak, where a small cairn stands.

**ISAURA:** "I'm *not* going up."
**ISAURA:** "He was *blessed.* That's what we say. He was *taken.* It's an *honour.*"
**ISAURA:** (very quietly) "It's *not* an honour. It's my *brother.*"
> ► **"You can grieve."** — **ISAURA:** "A storm-caller doesn't."
> ► **"The storm is listening."** — **ISAURA:** "...What?"
> ► **"Say his name."** — **ISAURA:** "...Mattis."

**Scene 4: the sky.** She says it again, louder. A low rumble rolls across the peaks. The clouds, which have been flat and sullen for forty days, *shiver.*

**ISAURA:** "*Mattis!*"
*She raises her hand. For the first time in forty days, a single white spark leaps from her fingertips and arcs, gently, into the dark.*
**ISAURA:** (weeping, laughing) "...It's *back.*"
**ISAURA:** "It was never *gone.* *I* was."

**Outcomes and receipt.**
- Isaura's power returns; the roc was never involved. If the player *blames the roc,* her power does *not* return until she mourns, later.
- **Receipt:** a cairn of white stones on the Third Peak; Isaura calls a small, silent storm each dusk in her brother's name.

<!-- quest
id: qst_str_storm_caller_quiet
title: The Storm-Caller Who Went Quiet
rank: B
type: Investigation
giver: npc_isaura_windlass
region: reg_stormreach
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: str_quiet_done
summary: A storm-caller has lost her power and blames the roc. She hasn't mourned her brother.
objectives:
  talk npc_isaura_windlass
  reach stormreach_third_peak
  choice grieve_listen_or_name
-->

---

## 2. A Rope Along the Cliffs

*B · Defense · the trapped cove · giver Harbour-Warden Tavi Longline*

**The short version.** A fishing fleet is trapped in a cove by a storm. The only way to reach it is a rope, carried by hand, along three miles of cliff, in the dark. Tavi has a hundred volunteers and no plan.

**What is really going on.** The rope must be *anchored* at six points on the cliff face. Each anchor is a *person.* If any one *lets go,* the line falls. The storm is *worse* than the harbour-warden admits.

**Scene 1: the harbour.**

**TAVI:** (laughing, shouting over the wind) "*Nine days!* Nine days they've been out there! They'll be *eating* the *ropes!*"
**TAVI:** "A rope! *That's* all we need! A very *long* one!"
**TAVI:** "Gurr's best! Eight hundred fathoms! *Three miles!*"
> ► **"How do we carry it?"** — **TAVI:** "By *hand.* In *relays.* Six *anchors.*"
> ► **"What if the storm worsens?"** — **TAVI:** "It *will.*"
> ► **"I'll take an anchor."** — **TAVI:** "*Splendid!* Take the *worst* one."

**Scene 2: the climb.** A tense, dark, windswept defense sequence. The player holds the fourth anchor, a crack in the cliff, a belay-peg, a hundred-foot drop. The rope hums. Lightning flashes; waves boom below.

*(Gameplay: a holding-the-line defense. Wind gusts push the player; a rope-chain minigame lets nearby anchors *call* in time with the player.)*

**ANCHOR 3:** "*Hold!*"
**ANCHOR 5:** "*Hold!*"
**PLAYER:** "*Holding!*"
**TAVI (from the cliff):** "*Keep it TAUT!*"

**Scene 3: the slip.** At the midpoint, a rope-maker's apprentice, **Pim,** slips. The line shudders. He hangs, one-handed, from the cliff.

> ► **"Let the next anchor take it."** — A calm, risky choice.
> ► **"Swing to him."** — A daring rescue.
> ► **"Shout for the relay."** — The chain responds.

**Scene 4: the cove.** At dawn, the rope reaches the trapped fleet. One by one, forty boats are hauled out along it, hand over hand, into the harbour. Tavi, hoarse, stands at the end, laughing until he cries.

**TAVI:** "*All of them!* All *forty!*"
**TAVI:** "I told the council! I said, '*Rope!*' And they said '*madness!*'"
**TAVI:** "It *was* madness! It *worked!*"

**Outcomes and receipt.**
- The fleet is saved. If any anchor failed, the line holds *thanks to the relay,* but a boat is *lost.*
- **Receipt:** a rope-bridge permanent along the cliff, named *"Tavi's Line;"* the town celebrates *Rope Day.*

<!-- quest
id: qst_str_rope_cliffs
title: A Rope Along the Cliffs
rank: B
type: Defense
giver: npc_tavi_longline
region: reg_stormreach
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: str_rope_done
summary: A fishing fleet is trapped in a cove. A three-mile rope must be carried along the cliffs, anchored by a chain of volunteers.
objectives:
  talk npc_tavi_longline
  defend stormreach_cliff_rope
  choice next_anchor_swing_or_relay
-->

---

## 3. The Egg in the Gatherer's Basket

*A · Hidden · the egg-cliffs · giver Pila Seabrow*

**The short version.** Pila found an egg the size of a cask. It is warm. It hums. She is quite sure it is the roc's.

**What is really going on.** *It is.* The egg is not *Raikaru's,* but its *clutch-mate's:* a second roc, still unborn, that Raikaru has *abandoned* because it *eats* storms and an egg would be *a rival.* The egg is dying of cold. If it hatches, the Stormreach may have *two* rocs; if it dies, the cliffs lose a *future* that might not follow its parent.

**Scene 1: the cliffs.**

**PILA:** "I've gathered eggs since I was six. *Gull.* *Tern.* *Fulmar.* Never one *this* big."
**PILA:** "It's *warm.* It *hums.* If I put my ear to it, it's got a *heartbeat.*"
**PILA:** "I think it's a *roc.* And I think it's *cold.*"
> ► **"Why is it here?"** — **PILA:** "It was in a nest, abandoned. High. Alone."
> ► **"Why not destroy it?"** — **PILA:** "I *thought* about it."
> ► **"What do you want?"** — **PILA:** "I don't know. *Help.*"

**Scene 2: the council.** The player brings the egg (wrapped in sealskins) to the council. Four elders argue.

**ELDER 1:** "A roc! *Destroy it!* Before it hatches!"
**ELDER 2:** "It's a *life.* We are *not* murderers."
**ELDER 3:** "It will *grow.* It will *feed on storms.* Like its *parent.*"
**ELDER 4:** "Perhaps not. Perhaps it will feed on *something else.*"
> ► **"Destroy it."** — A grim, silent choice.
> ► **"Hide it."** — A risk.
> ► **"Return it."** — A long journey.
> ► **"Raise it."** — **PILA:** "...*Me?*"

**Scene 3: the warmth.** Whichever choice, the egg grows warmer in the player's hands. At last, a thin crack runs across the shell. A tiny, damp, glaring eye looks out.

**CHICK (a thin, tiny, outraged shriek):** *"...*SQUAWK.*"*
*It is, undeniably, a roc. It is also, undeniably, the size of a loaf of bread.*

**Scene 4: the feeding.** The player and Pila, three days in, are covered in feathers and fish-guts. The chick eats *everything.* At night it sits on Pila's shoulder and *hums.*

**PILA:** "It doesn't eat *storms.* It eats *herring.*"
**PILA:** "I don't know what it'll eat when it's *big.*"
**PILA:** "But it *likes* me."
*(If the player returned the egg to the cliffs, the chick, hatched, flies up into the thunderheads, and Raikaru, far above, *rumbles,* a note that no one in Stormreach has heard before: *surprise.*)*

**Outcomes and receipt.**
- The player chooses the chick's fate. *Raised,* it becomes a gentle, huge friend; *returned,* it flies free; *hidden,* it grows in secret; *destroyed,* the region is *quieter,* sadder. The Tyrant fight is unchanged, but Raikaru's pre-fight line varies.
- **Receipt:** a roc-feather in the player's Journal; a small cap of down on Pila's pillow.

<!-- quest
id: qst_str_roc_egg
title: The Egg in the Gatherer's Basket
rank: A
type: Hidden
giver: npc_pila_seabrow
region: reg_stormreach
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 130000
sets: str_egg_done
summary: An egg-gatherer found a roc's egg, abandoned and cold. The council argues over destroying it.
objectives:
  talk npc_pila_seabrow
  reach stormreach_abandoned_nest
  choice destroy_hide_return_or_raise
-->

---

## 4. The Best Rope in the World

*B · OddJob · Stormreach · giver Rope-Master Gurr*

**The short version.** Gurr has won the Rope Contest eleven years running. He wants someone to beat him. He has built a rope he cannot beat, and he is *miserable.*

**What is really going on.** Gurr loves *rope* more than winning. He wants a *rival.* The player, a stranger, is the only person who has *never* tried. A contest is held; the player may *cheat, lose or compete.*

**Scene 1: the rope-walk.**

**GURR:** "Eleven. Eleven *years.* I've *won* the contest eleven times."
**GURR:** "I'd *love* to be beaten."
**GURR:** "Nobody *tries.* They all say '*Gurr is Gurr.*'"
> ► **"Why do you want to lose?"** — **GURR:** "So I can *learn.*"
> ► **"What's the contest?"** — **GURR:** "Strength. *Knots.* And *story.* A rope must have a *story.*"
> ► **"I'll try."** — **GURR:** "*Do.*"

**Scene 2: the lesson.** A funny, warm training montage. The player learns three knots, one splice and the rope-makers' creed: *"Every strand is a friend."*

**GURR:** "Don't *pull.* *Listen.* The rope *tells* you."
**GURR:** "No! That's a *granny.* That's a *clove.* That's a... *I don't know what that is.*"

**Scene 3: the contest.** In the harbour, a crowd of rope-makers, fishers and children. Each competitor lays a rope on the *trial rack.* Weights are hung. The player's rope, thin and strange, holds.

**JUDGE:** "...It's *strong.*"
**JUDGE:** "...And *beautiful.*"
**GURR:** (softly) "...That's a *story.*"
> ► **"Tell the story."** — The player tells it.
> ► **"Hold the weights."** — A tense, sweaty moment.
> ► **"Concede."** — **GURR:** "*No!*"

**Scene 4: the winner.** The player's rope *holds longer* than Gurr's, by one second.

**GURR:** (stunned) "...*Twelve.*"
**GURR:** "No. *One.*"
**GURR:** "*One.* I've *been beaten.*"
*He sits down on a coil of rope, laughing and crying at once.*

**Outcomes and receipt.**
- The Rope Contest has a new champion; Gurr takes the player as an *apprentice rival.* If the player *cheated,* Gurr knows, and is *quietly* heartbroken.
- **Receipt:** a small coil of the player's rope hangs in the Rope Hall; Gurr signs all his ropes with *two* names.

<!-- quest
id: qst_str_best_rope
title: The Best Rope in the World
rank: B
type: OddJob
giver: npc_rope_master_gurr
region: reg_stormreach
level: 88
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: str_rope_contest_done
summary: A rope-master who has won eleven years running secretly wants someone to beat him.
objectives:
  talk npc_rope_master_gurr
  reach stormreach_rope_hall
  choice tell_hold_or_concede
-->

---

## 5. Struck, and Blessed

*B · Hidden · Stormreach · giver Odd Thunderhand*

**The short version.** Odd was struck by lightning three years ago and survived. Everyone calls him *blessed.* He would like to be called *Odd.*

**What is really going on.** Odd is a quiet, thoughtful fisherman. He has been *asked to bless babies,* *heal the sick,* *predict the weather,* *judge disputes.* He can do *none* of it. He wants to *fish.* The town will not *let* him.

**Scene 1: the dock.**

**ODD:** "Good day. I'm Odd. Odd Thunderhand. I'm... *blessed.*"
**ODD:** "That's what they *say.* I was struck. I *lived.* They think it *means* something."
**ODD:** "I think it means I was standing in a *bad place.*"
> ► **"Can you heal?"** — **ODD:** "Gods, *no.* I can *gut a cod.*"
> ► **"What do you want?"** — **ODD:** "To go *fishing.* In *peace.*"
> ► **"Why not tell them?"** — **ODD:** "I *have.* They say that's *modesty.*"

**Scene 2: the queue.** A short, funny, painful scene: a line of villagers waits outside Odd's door. A woman with a sick child. A man with a boat to bless. A boy who wants a *wish.*

**WOMAN:** "Please, blessed one. Touch my baby."
**ODD:** "I'm *not.* I'm... *please.* I'm a *fisherman.*"
**WOMAN:** "You were *chosen.*"
**ODD:** "I was *unlucky.*"
> ► **"Let him speak."** — The crowd goes quiet.
> ► **"Tell them what it was like."** — A sober, honest account.
> ► **"Take him fishing."** — The player *removes* him.

**Scene 3: the truth.** In the middle of the harbour, from a small boat, Odd tells them.

**ODD:** "It was *white.* And then it was *dark.* And I woke up in a boat."
**ODD:** "That's *all.* There was no *voice.* No *light.* No *meaning.*"
**ODD:** "I'm *alive.* I'm *grateful.* I'm *Odd.* That's *enough.*"
*A long silence. Then a very old fisherman, from the back:*
**OLD FISHERMAN:** "...I was *struck* in my *youth.* I said *the same.* Nobody *believed* me."

**Scene 4: the quiet.** Over the next week, the queue thins. A small, tentative group of villagers, *the Struck,* begins to meet at the harbour, not to be blessed, but to talk.

**ODD:** "...They're *talking.* About *what it's like.*"
**ODD:** "I think that's... *what I needed.*"

**Outcomes and receipt.**
- Odd is allowed to fish; the town respects it. *If the player took him fishing without explanation,* the queue returns.
- **Receipt:** a small group of the Struck meets weekly at the harbour; Odd's boat carries no blessing, only *a name.*

<!-- quest
id: qst_str_struck_blessed
title: Struck, and Blessed
rank: B
type: Hidden
giver: npc_odd_thunderhand
region: reg_stormreach
level: 90
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: str_struck_done
summary: A man struck by lightning is treated as a saint by the whole town. He would like to go fishing.
objectives:
  talk npc_odd_thunderhand
  reach stormreach_harbour_queue
  choice speak_tell_or_fish
-->

---

## 6. The Guano Accords

*B · Faction · the guano cliffs · giver Reeve Marga Bellows*

**The short version.** Two cliff-towns have quarrelled for eleven years over a single cliff. The birds nest there. The guano is valuable. Marga says the birds should decide.

**What is really going on.** The cliff is a *shared* nesting ground; each town takes *only part.* The birds *prefer* one side, not by *town,* but by *wind.* Whoever lets the birds *choose* gets the richest harvest.

**Scene 1: the cliff.**

**MARGA:** "Eleven years. *Eleven.* Two towns. One cliff. *Two* councils, *sixty* lawyers, *one* decision: *none.*"
**MARGA:** "I propose a *novel* approach. *Ask the birds.*"
**MARGA:** "They've been *nesting* there for *ten thousand years.* They know *better.*"
> ► **"How do we ask?"** — **MARGA:** "We *watch.* For a season."
> ► **"What if they pick *one* side?"** — **MARGA:** "Then that's *their* side."
> ► **"I'll watch."** — **MARGA:** "Bring a *telescope.*"

**Scene 2: the season.** A fast, funny montage over a summer. The player, with a representative from each town, records which part of the cliff the birds use on each day. They notice a pattern: *morning wind from the east, evening wind from the west.* The east face is used *at dawn;* the west at *dusk.*

**TOWN A'S REP:** "They prefer *our* side!"
**TOWN B'S REP:** "They prefer *OURS!*"
**PLAYER:** "They prefer... *both.* At different times."

**Scene 3: the accord.** At a joint council, the player lays out the findings.

> ► **"Split by time, not place."** — Town A takes dawn; Town B takes dusk.
> ► **"Split by season."** — A calmer solution.
> ► **"Let the birds be."** — A radical one.

**MARGA:** "A *shift system.*"
**MARGA:** "I have been *thinking* about this for *eleven years.* And *no one* thought of *time.*"

**Scene 4: the first harvest.** At dawn, Town A's gatherers climb the east face. At dusk, Town B's climb the west. The birds, undisturbed, nest in peace.

**MARGA:** "...They've *stopped* quarrelling."
**MARGA:** "It's *rather dull,* actually. I'm *quite* disappointed."

**Outcomes and receipt.**
- The Guano Accords are signed; the harvest *grows* by a third. If the player chooses *"let the birds be,"* the harvest is *smaller* but the birds *return in greater numbers.*
- **Receipt:** a two-faced stone on the cliff, one side marked *"Dawn,"* one *"Dusk;"* Marga sleeps for three days.

<!-- quest
id: qst_str_guano_accords
title: The Guano Accords
rank: B
type: Faction
giver: npc_marga_bellows
region: reg_stormreach
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: str_guano_done
summary: Two cliff-towns have quarrelled for eleven years over a single cliff of nesting birds.
objectives:
  talk npc_marga_bellows
  reach stormreach_guano_cliff
  choice time_season_or_birds
-->

---

## 7. Rod Forest

*B · Defense · the Rod Forest · giver Rod-Warden Fenwick Sparks*

**The short version.** Forty apprentice storm-callers are training in the Rod Forest when a storm worse than any forecast descends. Fenwick has ten minutes to bring them in.

**What is really going on.** The storm is *Raikaru's wing-beat.* The roc is *close.* The apprentices are *young.* The Rod Forest, a field of a thousand lightning rods, is the *safest* place, *if* used properly, and the *most dangerous,* if not.

**Scene 1: the forest.**

**FENWICK:** "*Ten minutes!* I said *ten!* The clouds say *five!*"
**FENWICK:** "Forty apprentices! *Spread* across the forest! Some *five hundred yards* from the shelter!"
**FENWICK:** "Get them *in!*"
> ► **"What do I do?"** — **FENWICK:** "Run. *Shout.* Don't *touch* a rod."
> ► **"What if they panic?"** — **FENWICK:** "They *will.*"
> ► **"Go."** — **FENWICK:** "*Splendid!* Move!"

**Scene 2: the run.** A fast, loud defense sequence. The player sprints through the Rod Forest, gathering apprentices: a boy frozen in fear, a girl who wants to *stay* and call the storm, a pair of twins arguing about the best path.

*(Gameplay: a pursuit-defense; lightning strikes the rods in patterns the player can read; each apprentice must be guided to the shelter by a safe path.)*

**APPRENTICE:** "I can *do* it! I can *call* it!"
**PLAYER:** "Not *this* one."
**APPRENTICE:** "*Why?*"
**PLAYER:** "Because *it's calling you.*"

**Scene 3: the last apprentice.** A small, wild-haired girl, **Sori,** stands at the very centre of the forest, hands raised, singing, *her hair standing straight up.* The sky above her swirls.

**SORI:** (in a trance) "*It's... so... beautiful.*"
**FENWICK (shouting from the shelter):** "*SORI! Come in!*"
> ► **"Take her hand."** — A leap of faith.
> ► **"Call to her."** — **SORI:** "...Mm?"
> ► **"Sing with her."** — A risky, harmonious choice.

**Scene 4: the shelter.** The apprentices crowd into the stone shelter as the sky *explodes.* A hundred bolts hit a hundred rods at once. The whole forest *sings.* Fenwick stands in the doorway, laughing.

**FENWICK:** "*All forty!* Not a *singe!*"
**FENWICK:** "That's the *best* storm I've *ever* seen!"
**SORI:** (tiny, awed) "...I *felt* it."

**Outcomes and receipt.**
- All forty apprentices live. Sori, who *sang to the storm,* becomes the forest's youngest *full* storm-caller.
- **Receipt:** a scorched mark on the shelter wall, *"Forty."*; Fenwick adds a new rule to the training: *"Know when to come in."*

<!-- quest
id: qst_str_rod_forest
title: Rod Forest
rank: B
type: Defense
giver: npc_fenwick_sparks
region: reg_stormreach
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: str_rod_forest_done
summary: Forty apprentice storm-callers are in the Rod Forest when a storm worse than forecast arrives, and one of them won't come in.
objectives:
  talk npc_fenwick_sparks
  defend stormreach_rod_forest
  choice take_call_or_sing
-->

---

## 8. A Funeral for the Lightning

*A · Escort · the Black Peaks · giver Ysa Ashpeak*

**The short version.** By custom, a dead storm-caller is carried to a high peak for the lightning to take. Ysa's father died in his sleep. The storm is the worst of the year. The custom says *tonight.*

**What is really going on.** Ysa does not want to carry her father into a storm that could kill her. Her family, the *Ashpeaks,* say *custom.* The elders say *custom.* The player is asked to *carry him,* or to help Ysa *find another way.*

**Scene 1: the house.**

**YSA:** "He was a storm-caller. Forty years. He *loved* the lightning."
**YSA:** "By law, he goes to a peak. By *custom,* tonight. In *this.*"
**YSA:** "I will *do it.* I don't want to. But I *will.*"
> ► **"Why tonight?"** — **YSA:** "The lightning must *take him* before the *dawn.*"
> ► **"Is there another way?"** — **YSA:** "I don't *know.*"
> ► **"I'll help."** — **YSA:** "Thank you."

**Scene 2: the climb.** A slow, windswept, grave journey up the Black Peaks, with a stretcher, a rope and a gale. Four others come: *a brother, a cousin, an old friend, an old foe.* The old foe, **Hobbe Dray,** is a man who quarrelled with Ysa's father for thirty years.

**HOBBE:** "I came to *carry.* I never said I *liked* him."
**HOBBE:** "But he was the *best* of us."
*They carry the stretcher in silence. Lightning flashes.*

**Scene 3: the peak.** At the summit, a cairn of dark stones, scorched white. The storm is *directly overhead.* The carriers lay the body down.

**YSA:** "I don't want to *leave* him."
**HOBBE:** "He's already *gone.*"
**YSA:** "I *know.*"
> ► **"Say a word."** — **YSA:** "*Goodbye, Da.*"
> ► **"Stay with her."** — The player waits.
> ► **"Bring him down."** — A quiet, controversial choice.

**Scene 4: the bolt.** A tremendous, silent flash. A column of white fire strikes the cairn. When the dazzle fades, the stretcher is empty; a faint, scorched ring marks the stone.

**YSA:** (a long breath) "...He's *home.*"
*Hobbe Dray, without a word, takes off his cap and, for the first time in thirty years, bows his head to the Ashpeak house.*

**Outcomes and receipt.**
- The funeral is complete. If the player brought the body *down,* the Ashpeaks are *scandalised,* but Ysa is *alive;* a quiet new custom takes hold.
- **Receipt:** a ring of white stones on the peak; the Ashpeak and Dray families share a table at the next Rope Day.

<!-- quest
id: qst_str_lightning_funeral
title: A Funeral for the Lightning
rank: A
type: Escort
giver: npc_ysa_ashpeak
region: reg_stormreach
level: 124
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: str_funeral_done
summary: A dead storm-caller must be carried to a peak for the lightning, in the worst storm of the year.
objectives:
  talk npc_ysa_ashpeak
  escort npc_ysa_ashpeak
  reach stormreach_black_peak_summit
  choice word_stay_or_bring_down
-->

---

## 9. The Fledgling's Feather

*A · Exploration · the Black Peaks · giver Hermit Old Bolt*

**The short version.** A young thunderbird has a broken wing and is stuck on a ledge. Old Bolt cannot reach it. He asks for a climber, and a feather.

**What is really going on.** A thunderbird's feather is *the only known shield against the roc's lightning.* It is *freely given,* never *taken.* The fledgling will give a feather to someone who *helps.* It is also the first step in a *relationship* between the people of Stormreach and the thunderbirds.

**Scene 1: the hut.**

**OLD BOLT:** (a long string of clicks, then, in plain speech) "She's on a *ledge.* A *young* one. Broken *wing.* Can't *fly.*"
**OLD BOLT:** "I've *tea.* I've *clicks.* I've no *legs.*"
**OLD BOLT:** "Climb up. *Bring her down.*"
> ► **"What do thunderbirds eat?"** — **OLD BOLT:** "*Storm.* *Fish.* *Biscuits.*"
> ► **"Will she bite?"** — **OLD BOLT:** "*Possibly.*"
> ► **"I'll climb."** — **OLD BOLT:** "*Clicks.*"

**Scene 2: the climb.** A tense, beautiful climb up a wet cliff, with rope, pegs and a long, quiet gale. Halfway, a trio of *thunder-gulls* wheel overhead, croaking.

**Scene 3: the ledge.** On the ledge, a young thunderbird, half the size of a house, wings crackling faintly, one hanging limp. Its eye, huge, gold, wary, fixes on the player.

**THUNDERBIRD (a low, rolling rumble; subtitled):** *"...Hurt."*
> ► **(Offer a fish.)** — She eats.
> ► **(Show empty hands.)** — She waits.
> ► **(Splint the wing.)** — A delicate, tender sequence.

*(Gameplay: a calm, patient healing; the thunderbird's spark flickers; the player must not startle her.)*

**Scene 4: the feather.** At last, the wing is bound. The thunderbird flexes it, wincing. She turns her head, plucks a single, long, white-gold feather from her chest and lays it on the ledge.

**THUNDERBIRD:** *"...Take."*
*The feather hums in the player's hand, faintly, like a struck bell.*
**OLD BOLT (when the player returns):** "*A feather.* From a *thunderbird.* *Freely given.*"
**OLD BOLT:** "That's the *first* in three hundred years."

**Outcomes and receipt.**
- The thunderbird recovers; the feather is kept as a shield against lightning (a *story* item, prose only). If the player *took* a feather, the thunderbird *leaves.*
- **Receipt:** a small nest on Old Bolt's roof; a thunderbird calls each dusk.

<!-- quest
id: qst_str_fledgling_feather
title: The Fledgling's Feather
rank: A
type: Exploration
giver: npc_hermit_old_bolt
region: reg_stormreach
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: str_feather_done
summary: A young thunderbird with a broken wing is stuck on a ledge. A feather freely given is the only shield against the roc's lightning.
objectives:
  talk npc_hermit_old_bolt
  reach stormreach_thunderbird_ledge
  choice fish_hands_or_splint
-->

---

## 10. The Nest Seen by Lightning

*A · Hidden · the Rod Forest · giver Councillor Eila Greyfeather*

**The short version.** The Roc's Nest is visible only during lightning flashes. Nobody has ever drawn it. Eila, who is seventy, wants a drawing by morning.

**What is really going on.** The nest is *not* a nest. It is a *vast, spiralling lattice of woven lightning,* a structure *grown* by the roc over centuries. The council has assumed it is a *cave.* A drawing will show it is *a city of storm.* The player's task is not to *fight,* but to *see.*

**Scene 1: the councillor.**

**EILA:** "I am seventy. I've never seen the Roc's Nest. *No one has.*"
**EILA:** "It's only *visible* in a lightning-flash. For a *heartbeat.* Everyone says: *a nest.*"
**EILA:** "I'd like to know *what it is.* Before I die."
> ► **"How do I see it?"** — **EILA:** "From the top of the tallest rod. In a storm."
> ► **"What do I do?"** — **EILA:** "Draw it. *Quickly.*"
> ► **"I'll go."** — **EILA:** "Bring *charcoal.*"

**Scene 2: the climb.** A terrifying, beautiful climb up the tallest rod in the Rod Forest, three hundred feet of wet iron, in a gale, with a satchel of charcoal and rolled paper. The storm *builds.*

*(Gameplay: a high-risk traversal with timed lightning-flashes. The player must *draw* in the instants between strikes; each flash reveals a different part of the nest.)*

**Scene 3: the nest.** In a *great* flash, the player sees it: not a nest of sticks, but a vast, *glowing lattice,* a thousand miles of woven lightning, a *city* of bridges and spires and arches, suspended in the thunderhead, *breathing.*

**PLAYER (to themself):** "...*It's not a nest.*"
*Another flash. A vast, slow shape moves through the lattice: Raikaru, enormous, calm, *tending* it.*
> ► **(Draw the whole.)** — A rough, vast sketch.
> ► **(Draw the roc.)** — A moment of awe.
> ► **(Draw the detail.)** — A fine, quick study.

**Scene 4: the council.** At dawn, the player lays the sketch before the council. A long, stunned silence.

**EILA:** "...It's *beautiful.*"
**ELDER:** "It's a *city.*"
**ELDER 2:** "It's a *home.*"
**EILA:** (softly) "It's *not* a *nest.* It's... *a thing it made.* For *itself.*"
**EILA:** "...We've been *calling it a monster.* For two hundred years."

**Outcomes and receipt.**
- The drawing hangs in the council hall. Raikaru's pre-fight line changes: the roc is *not* only a storm-eater, but a *builder.* The Tyrant fight is unchanged.
- **Receipt:** a charcoal drawing of a city in the clouds, framed in storm-glass; Eila, at seventy, climbs the tallest rod herself.

<!-- quest
id: qst_str_nest_lightning
title: The Nest Seen by Lightning
rank: A
type: Hidden
giver: npc_eila_greyfeather
region: reg_stormreach
level: 138
act: 4
requires_rank: A
requires_quests: qst_str_roc_egg
reward: 34000 | 1700 | 150000
sets: str_nest_done
summary: The Roc's Nest is visible only by lightning flashes. A councillor of seventy wants a drawing by morning.
objectives:
  talk npc_eila_greyfeather
  reach stormreach_tallest_rod
  choice whole_roc_or_detail
-->
