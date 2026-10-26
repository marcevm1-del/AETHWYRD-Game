# 11e-08 — Iron Hold, the Forge Under the Mountains: Ten Side Quests (draft)

> *"The dwarves sealed the deepest shaft after something answered their hammers from below. The seal is warm to the touch."*
> — Gazetteer, Iron Hold

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 6 touches the unexplained sealed shaft; it is a seed, never answered.

**Region:** `reg_iron_hold` (Karak Dûn, the Ashen Mines, the furnace-heart, the outer labour camps). **Rank band:** C–A. **Tone:** dry, proud, loyal, funny in a way outsiders often miss. Everything is made of stone and sentiment.

**Placement notes.**
- **Skarn, the Fire Giant Warlord**, is the region's Tyrant. He has an army and wants the forges and the **furnace-heart** that feeds them. No quest here kills Skarn.
- **General Ignarok** (the Flame Unbroken) is an Act IV story antagonist who invades Iron Hold. These quests never involve him and are written to play before *or* after his arc.
- Dwarves are organised into **clans by craft** and ruled by a **High Thane** elected from the clan heads. Laws are carved in stone and changed only with great difficulty. Quest 4 is about that.
- Customs the quests rely on: every smith keeps a **hearth-stone** from their first forge; losing it is a terrible omen. **Thorsday** is the day of the great forging. Drinking contests are sacred.
- Human, gnome and orc labourers work the outer mines for wages, and some have lived there for generations. Quests 1 and 3 use that boundary.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Stone She Carried | C | Investigation | Hesta Coalhand | An omen, a child, a stone |
| 2 | Three Hundred and One Mugs | C | OddJob | Grumbald Oakbarrel | The sacred contest, gently ridiculous |
| 3 | The Tap Code | C | Investigation | Dibble Quickpick | A rescue through rock |
| 4 | Amend the Law | C | Faction | Fizzwick Gearsoft | Bureaucracy in stone |
| 5 | The Giant's Envoy | B | Faction | High Thane Brunhild Ironvow | A parley under a banner |
| 6 | The Seal Is Warm | B | Exploration | Runemaster Orm Sparkbrow | One hammer-stroke, unanswered |
| 7 | Runes in Cold Iron | B | Hidden | Kessa Quickspark | A secret worth sharing |
| 8 | A Flame From Every Forge | B | Faction | Dorn Coalheart | Relighting the heart |
| 9 | The Thane's Granddaughter | A | Escort | High Thane Brunhild Ironvow | A rescue under the volcano |
| 10 | The Anvil That Counted | A | Hidden | Old Baldur Anvilfast | One blow, a thousand years late |

## Cast (new supporting NPCs)

<!-- npc
id: npc_hesta_coalhand
name: Hesta Coalhand
tier: major
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: Master smith of the Coalhand clan
backstory: A broad, laconic master smith who has kept her first-forge hearth-stone in her apron pocket for sixty years and has just reached into the pocket and found it gone.
-->
<!-- npc
id: npc_grumbald_oakbarrel
name: Grumbald Oakbarrel
tier: townsfolk
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: Keeper of the Great Hall's record mug
backstory: A round, solemn keeper of the Great Hall's record mug, who has kept the tally for fifty years and believes it is the most important number in Iron Hold.
-->
<!-- npc
id: npc_dibble_quickpick
name: Foreman Dibble Quickpick
tier: major
race: Gnome
region: reg_iron_hold
settlement: Ashen Mines camps
role: Gnome foreman, outer mines
backstory: A quick, anxious gnome foreman who has worked the outer mines for forty years and has never lost a crew.
-->
<!-- npc
id: npc_fizzwick_gearsoft
name: Engineer Fizzwick Gearsoft
tier: major
race: Gnome
region: reg_iron_hold
settlement: Karak Dûn
role: Gnome engineer
backstory: A cheerful gnome engineer who believes any problem can be solved with a lever, a plaque and enough paperwork.
-->
<!-- npc
id: npc_brunhild_ironvow
name: High Thane Brunhild Ironvow
tier: major
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: High Thane of Karak Dûn
backstory: A grim, fair-minded High Thane who has held the seat for twenty-three years and has lost sleep over every single one.
secret: She has kept a letter from Skarn for a month and has not opened it.
-->
<!-- npc
id: npc_orm_sparkbrow
name: Runemaster Orm Sparkbrow
tier: major
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: Runemaster of the sealed shaft
backstory: A quiet, ink-stained runemaster who has maintained the seal on the deepest shaft for seventy years and has never once been asked what is behind it.
-->
<!-- npc
id: npc_kessa_quickspark
name: Kessa Quickspark
tier: townsfolk
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: Rune-smith apprentice
backstory: A bright, stubborn apprentice rune-smith who has taught herself half of a forbidden technique from broken fragments in the scrap-heap.
-->
<!-- npc
id: npc_dorn_coalheart
name: Furnace-Warden Dorn Coalheart
tier: major
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: Warden of the furnace-heart
backstory: A broad, soot-faced furnace-warden who tends the great forge-heart and has not seen daylight in eleven years.
-->
<!-- npc
id: npc_embra_ironvow
name: Embra Ironvow
tier: townsfolk
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: The Thane's eleven-year-old granddaughter
backstory: A very composed eleven-year-old who has been taught knots, locks and bad news by her grandmother, and who treats a kidnapping as an inconvenience.
-->
<!-- npc
id: npc_baldur_anvilfast
name: Old Baldur Anvilfast
tier: major
race: Dwarf
region: reg_iron_hold
settlement: Karak Dûn
role: Anvil-keeper of the Great Hall
backstory: An ancient, one-eyed anvil-keeper who has struck the first blow on Thorsday for three hundred years and has never once missed it.
-->

---

## 1. The Stone She Carried

*C · Investigation · Karak Dûn · giver Hesta Coalhand*

**The short version.** Every dwarven smith keeps the stone from their first forge. Hesta's is missing. By custom, a smith without her hearth-stone is *unlucky*. Hesta does not believe in luck. She is very upset.

**What is really going on.** The stone was not stolen. It was *carried off by a child*, **Zuri**, an eight-year-old orc from the outer camps, who found it on the ground, thought it was a pretty rock and gave it to her mother as a gift. Her mother, **Dagna**, is a labourer. She has been terrified of reporting it, because "labourers who touch a smith's stone get *flogged*."

**Scene 1: the forge.**

**HESTA:** "Sixty years in my apron. Sixty years. And this morning, *gone*."
**HESTA:** "I don't believe in omens. I am a *rational woman*. But the hall is murmuring, and the apprentices won't look at me."
**HESTA:** "Find it. Quietly. I'd rather no one know it was missing."
> ► **"When did you last see it?"** — **HESTA:** "Yesterday. At the cooling trough."
> ► **"Who's been near you?"** — **HESTA:** "Everyone. It's a *forge*."
> ► **"I'll find it."** — **HESTA:** "Thank you."

**Scene 2: the trail.** The search winds through the great hall, the cooling trough, the outer yards. A smith's apprentice mutters that "the labourers pick things up." A guard says the same. A cart-boy tells you, quietly, that he *saw a small orc child by the trough*.

**CART-BOY:** "She wasn't *stealing*. She was... picking."
**CART-BOY:** "She had it in her hand. She looked at it like it was a *flower*."

**Scene 3: the camp.** In the outer labour camp, among rows of canvas tents, a thin orc woman sits at a cookfire. In her lap, a small grey stone, carefully polished.

**DAGNA:** "I didn't *take* it. She *found* it. She gave it to me."
**DAGNA:** "I tried to give it back. But how? A labourer walks up to a master smith and says *'here'*? They'd call it theft."
**DAGNA:** "I've been awake three nights. I was going to leave it at the gate."
> ► **"Come with me."** — **DAGNA:** "To the smith?"
> ► **"She's not going to punish you."** — **DAGNA:** "She's a *dwarf*."
> ► **"I'll carry it."** — **DAGNA:** "...Would you?"

**Scene 4: the return.** In the forge, Hesta holds her stone in both hands. She looks at the player. She looks at the thin orc woman, standing in the doorway with her daughter.

**HESTA:** "...Zuri, is it? You found my stone?"
**ZURI:** (small) "It was pretty."
**HESTA:** "It *is* pretty. I've never noticed."
*She sits Zuri on the anvil-bench and, very slowly, hands her a tiny hammer.*
**HESTA:** "This is for the child who finds things. In my forge, you may *always* pick up a stone."

**Outcomes and receipt.**
- The stone is returned; Hesta apprentices Zuri; the forge's rule *"No labourer to be flogged for finding"* is quietly adopted.
- **Receipt:** a small, polished pebble sits beside Hesta's hearth-stone on the forge shelf; the outer camps send her a loaf of bread on every Thorsday.

<!-- quest
id: qst_ih_stone_she_carried
title: The Stone She Carried
rank: C
type: Investigation
giver: npc_hesta_coalhand
region: reg_iron_hold
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: ih_stone_resolved
summary: A master smith's first-forge hearth-stone is missing, which is an omen. The finder is an orc child who thought it was pretty.
objectives:
  talk npc_hesta_coalhand
  reach ih_outer_labour_camp
  choice return_quietly_or_publicly
-->

---

## 2. Three Hundred and One Mugs

*C · OddJob · the Great Hall · giver Grumbald Oakbarrel*

**The short version.** The Great Hall's record is **three hundred mugs**, held by a dwarf called Old Thrumm. A gnome called Fizzy has just drunk three hundred and one. Grumbald, the keeper of the tally, does not believe it.

**What is really going on.** Fizzy has not drunk three hundred and one mugs. The record mug has a *false bottom*, built in the old days by a bartender who wanted to make the record look *harder*. Fizzy has, in fact, drunk three hundred and one *fair* mugs, and the record holder drank a hundred and eighty. The truth is that *everyone* has been cheating, for centuries.

**Scene 1: the hall.**

**GRUMBALD:** "The record has stood for two hundred and seven years. *Three hundred mugs.* Old Thrumm, in the year of the Great Frost."
**GRUMBALD:** "Last night a gnome, a *gnome*, drank three hundred and one. I counted. I counted *twice*."
**GRUMBALD:** "I do not believe it. I want a *witness.*"
> ► **"Who's the gnome?"** — **GRUMBALD:** "Fizzy. A cheerful menace."
> ► **"What do you want me to do?"** — **GRUMBALD:** "Drink beside him. Count his mugs. And *report.*"
> ► **"What's in the mugs?"** — **GRUMBALD:** "Stout. And a *great deal* of foam."

**Scene 2: the contest.** In the packed Great Hall, the player sits beside a very small, very flushed gnome. A long table of mugs stretches into the dark. The crowd roars each time a mug is set down.

*(Gameplay: a pacing mini-game. The player drinks a small stout alongside Fizzy, mostly *watching*: noting the mugs, the foam, the odd little tap of the mug against the table. Each mug has a number etched on the base.)*

**FIZZY:** (to the player, hiccuping) "Don't... tell them... I'm *winning*."
**FIZZY:** "It's the... *foam*."

**Scene 3: the false bottom.** After the contest, the player examines the record mug in its glass case. A thin seam runs round its base. A tiny catch, the size of a thumbnail.

**GRUMBALD:** "...That's not supposed to be there."
**GRUMBALD:** "That's a *false bottom.* A quarter of the mug is *wood*."
*The player lifts the mug. A pair of dried, bitter-smelling sponges falls out.*
**GRUMBALD:** "...Oh."
**GRUMBALD:** "Oh, *no*."
> ► **"The record is a lie."** — **GRUMBALD:** "It was *beautiful* lie."
> ► **"Keep it quiet."** — **GRUMBALD:** "For *how long*?"
> ► **"Tell the hall."** — **GRUMBALD:** "...They'll *riot*."

**Scene 4: the revision.** In front of the whole hall, Grumbald reads a new tally.

**GRUMBALD:** "The record stands at one hundred and eighty, by Old Thrumm."
**GRUMBALD:** "And the *new* record, at three hundred and one *fair* mugs, by *Fizzy Gearsoft, gnome of the outer camps*."
*A pause. Then a roar. A *happy* roar.*
**OLD THRUMM:** "...A hundred and eighty! That's *still* a lot of ale!"

**Outcomes and receipt.**
- The record is revised; both Thrumm and Fizzy are honoured. If the player hides the truth, the record stands, and the false bottom is replaced in secret.
- **Receipt:** a small gnome-sized mug sits beside the old record mug; Fizzy buys the player a drink every Thorsday.

<!-- quest
id: qst_ih_three_hundred_mugs
title: Three Hundred and One Mugs
rank: C
type: OddJob
giver: npc_grumbald_oakbarrel
region: reg_iron_hold
level: 60
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: ih_mugs_resolved
summary: A gnome has drunk one mug more than the Great Hall's two-hundred-year record. The record mug has a false bottom.
objectives:
  talk npc_grumbald_oakbarrel
  reach ih_great_hall_table
  choice tell_keep_quiet_or_revise
-->

---

## 3. The Tap Code

*C · Investigation · the Ashen Mines · giver Foreman Dibble Quickpick*

**The short version.** A shaft has collapsed in the Ashen Mines. Eleven miners are trapped below. They are tapping on the rock. The pattern is not the standard code.

**What is really going on.** The miners are *alive*. But the pattern they are tapping is a new code they invented, a way to count the living without wasting air. And in the middle of their message is a rhythm that is *not theirs*: three slow beats, repeated, from deeper below.

**Scene 1: the camp.**

**DIBBLE:** "Eleven. Eleven good miners. The collapse was *clean*; the shaft is intact for twenty yards. They have air for six hours."
**DIBBLE:** "They're tapping. I've never *heard* a pattern like it. I don't know what they're saying."
**DIBBLE:** "I have a code book. It is *useless.*"
> ► **"Can I listen?"** — **DIBBLE:** "Please. Put your ear to the rock."
> ► **"What do we know?"** — **DIBBLE:** "Eleven alive. Two injured. One shaft."
> ► **"Where are they?"** — **DIBBLE:** "Forty fathoms. Under the old lode."

**Scene 2: the rock.** The player presses an ear to the stone. A pattern of short and long taps, then a pause, then another. Between them, faint, a *different* sound: slow, heavy, rhythmic.

**TAP (decoded):** *"ELEVEN. TWO HURT. AIR GOOD. NOT ALONE."*
**DIBBLE:** "'Not alone'? Of *course* they're not alone. There are *eleven* of them!"
**PLAYER:** "No. *Listen.*"
*Three slow beats from below. Pause. Three slow beats.*
**DIBBLE:** "...That's *not* a miner."
> ► **"What is it?"** — **DIBBLE:** "I don't *know*."
> ► **"Where's it coming from?"** — **DIBBLE:** "Deeper."
> ► **"Ignore it."** — **DIBBLE:** "...We *have* to."

**Scene 3: the dig.** A gameplay sequence of careful tunnelling, shoring and rock-reading. The player coordinates a dig crew via the tap code, answering the trapped miners and slowly cutting a path.

**TAP (decoded):** *"HEAR IT? IT ANSWERS."*
**PLAYER (tapping):** *"WE HEAR. HOLD."*
**TAP:** *"IT KNOWS OUR CODE."*

**Scene 4: the breakthrough.** The rock gives way. Eleven filthy, grinning dwarves and gnomes spill into the lamplight. The last, an old foreman, lingers a moment at the dark hole.

**OLD FOREMAN:** "It *answered*. Every tap. In *our* rhythm."
**OLD FOREMAN:** "I'd swear on my hammer."
**DIBBLE:** "...Seal the shaft."
**OLD FOREMAN:** "Aye. Seal it. Properly."
*The player and Dibble look at the dark.*

**Outcomes and receipt.**
- All eleven live. The shaft is sealed; the "answer" is recorded, unexplained, in the mine's log.
- **Receipt:** a small stone plaque at the shaft mouth reads: *"Eleven came up. One answered."* The miners' union adopts the new tap code.
- **Canon-safe:** the quest adds a *second* unexplained answer from below, tying to the sealed shaft (quest 6) without defining it.

<!-- quest
id: qst_ih_tap_code
title: The Tap Code
rank: C
type: Investigation
giver: npc_dibble_quickpick
region: reg_iron_hold
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: ih_tap_resolved
summary: Eleven miners are trapped below the Ashen Mines, tapping a new code. Something deeper is tapping back.
objectives:
  talk npc_dibble_quickpick
  reach ih_collapsed_shaft
  choice answer_ignore_or_seal
-->

---

## 4. Amend the Law

*C · Faction · Karak Dûn · giver Engineer Fizzwick Gearsoft*

**The short version.** A six-hundred-year-old law is carved in stone, and it says gnomes may not use fire in the main halls. Fizzwick's new lamp is a *candle*. He would like to be allowed to use it.

**What is really going on.** The law is a bureaucratic accident: it was carved after a long-ago fire, and was meant to apply to *open flames*, not enclosed lamps. But laws in Iron Hold are changed only by carving a *new law over the old one*, which no one has done in four hundred years. Fizzwick has a loophole.

**Scene 1: the office.**

**FIZZWICK:** "A candle! A *safe* candle! Enclosed, glass-shielded, self-extinguishing in a draught!"
**FIZZWICK:** "And the law says: *no fire in the main halls.* By gnomes."
**FIZZWICK:** "Not *dwarves*. By *gnomes*. A law from six hundred years ago, carved after the Great Hall Fire, which was *our fault*, I grant you."
> ► **"Why not just ask?"** — **FIZZWICK:** "It's *carved in stone*."
> ► **"What's the loophole?"** — **FIZZWICK:** "I'm *building* it."
> ► **"I'll help."** — **FIZZWICK:** "Excellent. Bring a chisel."

**Scene 2: the hall of laws.** In a long gallery of carved walls, rows of old, deep law-glyphs run floor to ceiling. The Stonecutters' Clan Elder, **Gurda Hammerfall**, stands with arms folded.

**GURDA:** "A law is a law. Six hundred years."
**GURDA:** "You want to *amend* it? We do not amend. We *carve over.* And no one has carved over in four hundred years."
**GURDA:** "It requires the signatures of *three* clan heads."
> ► **"What if it's a plaque?"** — **GURDA:** "A plaque is not a law."
> ► **"What if it *explains* the law?"** — **GURDA:** "...Go on."
> ► **"What if we ask the Thane?"** — **GURDA:** "She will say *no.*"

**Scene 3: the plaque.** Fizzwick builds an elegant bronze plaque, to be bolted to the original stone, bearing the text: *"By 'open flame' this law is understood to mean unshielded flame. Enclosed lamps are hereby understood to be permitted. — Interpreted this day."*

**FIZZWICK:** "It doesn't *change* the law. It *interprets* it."
**GURDA:** (slowly) "...That is... *within custom*."
**GURDA:** "Interpretations are not forbidden. Only *amendments*."

**Scene 4: the signatures.** In the hall of laws, three clan heads, a bored scribe and a very nervous gnome gather around the plaque. Each signs. The plaque is bolted to the wall. A small, silent pause. Then:

**GURDA:** (a rare smile) "...That's the *first* new thing in this hall in four hundred years."
**FIZZWICK:** "I've never been so proud of a *bracket*."
*He lights the candle. It burns steadily, in its tiny glass house.*

**Outcomes and receipt.**
- The plaque stands; gnomes may use enclosed lamps; a few old laws begin to attract *plaques*.
- **Receipt:** a cheerful row of enclosed candles lines the gnomish quarter; Fizzwick is made an Honorary Stoneinterpreter.

<!-- quest
id: qst_ih_amend_the_law
title: Amend the Law
rank: C
type: Faction
giver: npc_fizzwick_gearsoft
region: reg_iron_hold
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: ih_law_resolved
summary: A six-hundred-year-old law forbids gnomes from lighting flame in the main halls. A plaque might interpret it without amending it.
objectives:
  talk npc_fizzwick_gearsoft
  reach ih_hall_of_laws
  choice plaque_signature_or_thane
-->

---

## 5. The Giant's Envoy

*B · Faction · Karak Dûn · giver High Thane Brunhild Ironvow*

**The short version.** Skarn has sent an envoy under a white banner. The High Thane has agreed to receive him, and she wants someone who is *not* a dwarf to be in the room.

**What is really going on.** The envoy is a fire-giant diplomat named **Kesh-Ur**. His offer is *real*: Skarn will withdraw his army if Karak Dûn gives him the furnace-heart *for one night*. The Thane believes it is a trick. The envoy believes it is a *sincere* proposal. Both are partly right.

**Scene 1: the hall.**

**BRUNHILD:** "A fire giant under a white banner. In *my* hall."
**BRUNHILD:** "I will receive him. I am the High Thane; I do not refuse an envoy. But I would like someone beside me who cannot be accused of having an *interest*."
**BRUNHILD:** "You are not a dwarf. You are not a giant. You will *do*."
> ► **"What does he want?"** — **BRUNHILD:** "A night with the heart."
> ► **"Why would Skarn do that?"** — **BRUNHILD:** "I do not know. That is why I am afraid."
> ► **"I'll witness."** — **BRUNHILD:** "Good. Stand on my left. Say nothing unless I look at you."

**Scene 2: the parley.** The envoy is nine feet tall, in a robe of cooling slag-glass. His voice is slow, cultured, tired.

**KESH-UR:** "Great Thane. I bear the word of Skarn, who is my king."
**KESH-UR:** "He wishes the furnace-heart. Not to *keep*. To *use*, for one night."
**KESH-UR:** "In return, his armies withdraw. Karak Dûn is spared. Iron Hold is *free*."
**BRUNHILD:** "And what does he want it *for*?"
**KESH-UR:** (a long pause) "...To *wake* something."
> ► **"What?"** — **KESH-UR:** "I am forbidden to say."
> ► **"Is Skarn mad?"** — **KESH-UR:** "No. Merely *old*."
> ► **"Refuse."** — **BRUNHILD:** "I *intend* to."

**Scene 3: the private word.** After the parley, Brunhild takes the player into a small, cold chamber.

**BRUNHILD:** "I have a letter. From Skarn. It has sat on my desk for a month."
**BRUNHILD:** "I never opened it. I was afraid of what it would say."
**BRUNHILD:** "Open it."
*Inside: a single line.* "THE ANSWER IS WARM. LET ME LISTEN."
> ► **"What does it mean?"** — **BRUNHILD:** "I do not know. But I think it concerns the shaft."
> ► **"Burn it."** — **BRUNHILD:** "...I considered that."
> ► **"Take it to Runemaster Orm."** — **BRUNHILD:** "Yes. I thought you might say that."

**Scene 4: the answer.** At dusk, the envoy stands before the Thane for the last time.

**BRUNHILD:** "The answer is *no*. The heart is not for loan."
**KESH-UR:** (gravely) "I will convey it."
**KESH-UR:** (very quietly, to the player) "Tell the runemaster: *the answer is not asking to be freed. It is asking to be heard.*"

**Outcomes and receipt.**
- The offer is refused; the envoy returns unharmed. The cryptic message is the seed for quest 6. The siege continues.
- **Receipt:** a white banner hangs in the Thane's hall, as a standing custom of parley; Brunhild thanks you with a small, rune-carved token.
- **Canon-safe:** the quest hints that Skarn has some knowledge of the sealed shaft. It does not explain what.

<!-- quest
id: qst_ih_giants_envoy
title: The Giant's Envoy
rank: B
type: Faction
giver: npc_brunhild_ironvow
region: reg_iron_hold
level: 92
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: ih_envoy_resolved
summary: Skarn has sent an envoy under a white banner, offering to withdraw his army if the Thane lends him the furnace-heart for one night.
objectives:
  talk npc_brunhild_ironvow
  reach ih_thane_hall_parley
  choice refuse_open_letter_or_burn
-->

---

## 6. The Seal Is Warm

*B · Exploration · the sealed shaft · giver Runemaster Orm Sparkbrow*

*Best played after quests 3 and 5.*

**The short version.** Runemaster Orm has maintained the seal on the deepest shaft for seventy years. It is warm. It is *getting warmer*. He wants someone to stand beside him while he checks it.

**What is really going on.** *Nothing is revealed.* The seal is a lattice of old runes that hum faintly. Behind it, a single hammer-stroke answers the player's. The runemaster decides, after deliberation, **not to answer a second time**.

**Scene 1: the vault.**

**ORM:** "Seventy years. I have never once been *lonely* down here."
**ORM:** "I check the runes every dusk. They hold. They always hold."
**ORM:** "But the seal is *warm.* A little more each year. This month, the warmest I have ever felt."
> ► **"What's behind it?"** — **ORM:** "I do not know. No one *has* known, in a thousand years."
> ► **"What does warm mean?"** — **ORM:** "That *something* is pressing."
> ► **"I'll stand with you."** — **ORM:** "Thank you. I would not like to do this alone."

**Scene 2: the descent.** A long, quiet, stone-lined stair under the mountain, past rows of rune-carved lintels, each one older than the last. At the bottom, a vast circular door of black metal, covered in spiralling glyphs.

**ORM:** "There. The Seal."
*The door is warm to the touch, like a living thing's flank.*
**ORM:** "Put your hand on it."
> ► **(Touch the seal.)** — A pulse, slow and regular, rises through your palm.
> ► **(Read the runes.)** — They are a *lock*, and also, faintly, a *lullaby*.
> ► **(Step back.)** — Orm nods.

**Scene 3: the stroke.** From the far side of the door, a single, deep, distant *clang*. As if a hammer had struck a bell the size of a mountain.

**ORM:** (very quietly) "...That is the first time I have heard it."
**ORM:** "My grandfather said it answered, once. I thought he was a drunk."
*The sound comes again. And again. A pattern, three slow strokes.*
**ORM:** "It is... *counting.*"
> ► **"Answer it."** — **ORM:** "No."
> ► **"What does it want?"** — **ORM:** "It *wants to be heard*. That is not the same as being *answered*."
> ► **"Seal it harder."** — **ORM:** "That would be... a *lie*."

**Scene 4: the choice.** Orm takes a small silver hammer from his belt and holds it over the seal. His hand shakes.

**ORM:** "I could answer. One stroke. And perhaps it would be *satisfied*."
**ORM:** "Or perhaps it would never stop."
> ► **(Let him strike.)** — The seal warms, then cools.
> ► **(Stop him.)** — The seal holds; the hammering fades.
> ► **(Strike beside him.)** — A great, slow, answering stroke from the dark, one beat in perfect time.

**ORM:** "...I will not answer. Not tonight."
**ORM:** "But I will *listen*. Every dusk."

**Outcomes and receipt.**
- The seal holds in all branches. The player chooses whether Orm answers, doesn't, or is helped to. No branch reveals what is behind it.
- **Receipt:** a small stone bench is placed before the seal; Orm sits there every dusk with his hand on the door.
- **Canon-safe:** this is the single most important *seed* in the region. It does not name or explain the answerer.

<!-- quest
id: qst_ih_seal_is_warm
title: The Seal Is Warm
rank: B
type: Exploration
giver: npc_orm_sparkbrow
region: reg_iron_hold
level: 96
act: 4
requires_rank: B
requires_quests: qst_ih_tap_code
reward: 12000 | 700 | 52000
sets: ih_seal_resolved
summary: The seal on the deepest shaft is warm and getting warmer. A single hammer-stroke answers from behind it.
objectives:
  talk npc_orm_sparkbrow
  reach ih_sealed_shaft
  choice answer_listen_or_seal
-->

---

## 7. Runes in Cold Iron

*B · Hidden · the scrap-heap · giver Kessa Quickspark*

**The short version.** Kessa has taught herself half of a forbidden rune-technique from fragments in the scrap-heap. The master rune-smiths do not want it spread. She wants to teach it anyway.

**What is really going on.** The technique is **cold-iron runework**: the art of enchanting steel without fire. It was lost after a catastrophic forge-accident two hundred years ago, and the masters have kept the fragments secret out of *fear*. Kessa's half-technique works. It would cut the cost of enchanted gear by half, and put it in the hands of every labourer in the outer camps.

**Scene 1: the scrap-heap.**

**KESSA:** "Shh. They'll hear. Come in. *Come in.*"
*She leads the player to a dim alcove behind a rusting forge. A single lamp. A dozen bent strips of steel, each etched with runes.*
**KESSA:** "I found a fragment. Then another. Then... I started *guessing.*"
**KESSA:** "It works. Look."
*She sets a strip on the anvil and touches it with a pin. A thin line of cold blue light runs along it.*
> ► **"Cold-iron?"** — **KESSA:** "The masters call it *forbidden.* They won't say why."
> ► **"Does it work?"** — **KESSA:** "Half. It needs a second half I haven't found."
> ► **"Who else knows?"** — **KESSA:** "You."

**Scene 2: the masters.** At the Runemasters' Hall, a ring of stern grey-bearded dwarves hears the player out. Runemaster **Hild Starmantle**, the eldest, shakes her head.

**HILD:** "We keep that technique *buried* for a reason."
**HILD:** "Two hundred years ago, a forge-accident killed forty smiths. The cold-iron *failed*, and the runes *burst*."
**HILD:** "We swore never to teach it. We swore never to *use* it."
> ► **"Why did it fail?"** — **HILD:** "Because the smith was *proud*."
> ► **"What if it could be made safe?"** — **HILD:** "That is a *very* big if."
> ► **"Teach Kessa."** — **HILD:** "She is a *child*."

**Scene 3: the proof.** The player carries a rune-strip to the great forge-heart for a test. A moment of tense silence. The strip glows, steadies, and then... holds.

**HILD:** (reluctantly) "...It did not burst."
**HILD:** "Perhaps the girl found the *safe* half. By accident."
**KESSA:** (very small) "I didn't *find* it. I *worked it out*."
> ► **"She's earned it."** — **HILD:** "I have not yet decided."
> ► **"Let the masters test it."** — **HILD:** "That is the *right* answer."
> ► **"Teach the camps."** — **HILD:** "...Not yet."

**Scene 4: the apprenticeship.** Hild, after long deliberation, takes Kessa as her apprentice and *opens the second half of the technique* to a small circle of labourers, under supervision.

**HILD:** "We hid it out of fear. Fear is a poor reason for forgetting."
**HILD:** "You will teach it *carefully.* And you will teach it *slowly.*"
**KESSA:** "Yes, Master."

**Outcomes and receipt.**
- The technique is preserved and shared; the cost of cold-iron runework in the outer camps falls. If the player argues for secrecy, Kessa is apprenticed quietly and the technique is hidden again.
- **Receipt:** a plain iron plaque in the scrap-heap alcove: *"Found, 1024 SC, by Kessa Quickspark."* A cold blue lamp burns there.

<!-- quest
id: qst_ih_runes_cold_iron
title: Runes in Cold Iron
rank: B
type: Hidden
giver: npc_kessa_quickspark
region: reg_iron_hold
level: 98
act: 4
requires_rank: B
reward: 12500 | 720 | 54000
sets: ih_runes_resolved
summary: An apprentice has rebuilt half of a forbidden rune-technique from scrap. The masters want it kept buried.
objectives:
  talk npc_kessa_quickspark
  reach ih_runemasters_hall
  choice share_test_or_hide
-->

---

## 8. A Flame From Every Forge

*B · Faction · the furnace-heart · giver Furnace-Warden Dorn Coalheart*

**The short version.** The furnace-heart that feeds Karak Dûn's forges is *guttering*. Skarn's army presses at the gates. Dorn needs a spark from every clan's forge to *re-kindle* it.

**What is really going on.** The furnace-heart is not just a furnace. It is the dwarves' shared fire, the thing that makes Karak Dûn *one* hold instead of nineteen clans. If the heart goes out, the clans will drift apart. The ritual of relighting requires *a flame from every forge*, carried to the heart *by hand*, by someone not of that clan.

**Scene 1: the heart.**

**DORN:** "Eleven years I have tended this. Eleven years without a sunrise."
**DORN:** "It's *guttering.* The fire doesn't *want* to burn."
**DORN:** "I think it is *lonely*. It was lit by every clan, once. It has not been *relit* in six hundred years."
> ► **"What do you need?"** — **DORN:** "A flame from every forge. Nineteen clans."
> ► **"Why me?"** — **DORN:** "Because you're not a clan. You belong to none, and none can claim you."
> ► **"I'll carry them."** — **DORN:** "Thank you. Do not let them go out."

**Scene 2: the nineteen.** A long, episodic quest through the city's forges. Each clan has a different idea of what a "spark" means:
- **The Coalhands:** a stubborn ember in a clay lantern.
- **The Anvilfasts:** a single hammer-strike, caught in a bucket.
- **The Stonecutters:** a flame from a chisel's last strike.
- **The Gnome Engineers:** a *tiny* clockwork flame.
- **The Orc Labourers:** a camp-fire coal, offered with pride.
- *(...and so on; fourteen others, each with a one-line story.)*

**CLAN HEAD:** "A flame? For the *heart*? I would be *honoured*."
**CLAN HEAD (another):** "Why should I give *anything* to the Thane's pet furnace?"
> ► **(Persuade, bargain, or earn each flame.)** — Each clan has its own approach.

**Scene 3: the walk.** At the foot of the heart's great chamber, the player lays nineteen small lanterns in a ring. A thousand dwarves, gnomes and orcs have gathered in the dark, hushed.

**DORN:** "Now. One at a time."
*The player lifts the first lantern, a small clay ember. A hush. A single breath.*
*The flame is poured into the heart's grate. It flickers. It catches.*
> ► **(Pour all nineteen.)** — Each flame flares in turn.
> ► **(Say the clan's name as you pour.)** — The crowd answers each name.
> ► **(Pour the nineteenth first.)** — An odd, bold choice; the heart *laughs*.

**Scene 4: the roar.** When the last spark falls, the heart *roars*. A column of white-gold fire climbs the shaft to the roof of the world. A wave of heat and light washes over the crowd.

**DORN:** (weeping, grinning) "...It's *awake.*"
**DORN:** "It's *awake!* Look at it!"
*A thousand voices rise, not in a cheer, but in a single, held note, like a great organ.*

**Outcomes and receipt.**
- The heart burns steady; Karak Dûn's forges are stronger by a visible margin (a regional state, not a buff). The siege is not ended, but the dwarves hold with new heart.
- **Receipt:** nineteen small lamps ring the heart's chamber; each clan's spark is marked with a name; Dorn climbs to the surface for a day.

<!-- quest
id: qst_ih_flame_every_forge
title: A Flame From Every Forge
rank: B
type: Faction
giver: npc_dorn_coalheart
region: reg_iron_hold
level: 100
act: 4
requires_rank: B
reward: 14000 | 800 | 58000
sets: ih_flame_resolved
summary: The furnace-heart is guttering. Dorn needs a flame from each of nineteen clan forges, carried by a non-dwarf, to relight it.
objectives:
  talk npc_dorn_coalheart
  reach ih_nineteen_forges 19
  choice pour_name_or_bold
-->

---

## 9. The Thane's Granddaughter

*A · Escort · the Ashen Mines · giver High Thane Brunhild Ironvow*

**The short version.** Skarn's orcs have taken the Thane's granddaughter, **Embra**, as a hostage. The Thane cannot send the army without condemning the girl. She asks for a quiet rescue.

**What is really going on.** Embra is eleven. She is held in a hot, brutal camp in the volcanic mines, guarded by orc warlords loyal to Skarn. But the camp is *not* under Skarn's direct command: its master, **Warlord Grakkor**, took her on his *own* initiative, hoping to bargain for his own power. Skarn does not know.

**Scene 1: the chamber.**

**BRUNHILD:** "She is my granddaughter. She is *eleven*. She took a cart to the forge-market, and she did not come back."
**BRUNHILD:** "I have fifty thousand dwarves. I cannot spend one on a *rescue*. It would be *treason*."
**BRUNHILD:** "I can ask *you*."
> ► **"Where is she?"** — **BRUNHILD:** "A camp in the Ashen Mines. Warlord Grakkor's."
> ► **"What do you need?"** — **BRUNHILD:** "Quiet. Quickness. *Mercy*."
> ► **"I'll bring her home."** — **BRUNHILD:** "I will not forget it."

**Scene 2: the camp.** A hot, red, sulphur-wreathed stealth sequence through the volcanic mines. Lava channels glow in the walls; orc sentries pace on iron catwalks; black smoke hangs in the rafters.

**EMBRA (in a cage, calmly):** "You're late."
**EMBRA:** "I've already unpicked the lock. I was waiting for you to *distract* them."
> ► **"You... unpicked it?"** — **EMBRA:** "My grandmother taught me. Knots, locks and bad news."
> ► **"Quietly."** — **EMBRA:** "Naturally."
> ► **"Run."** — **EMBRA:** "Not without my *hammer*."

**Scene 3: the hammer.** Embra insists on retrieving her small ceremonial hammer from the warlord's tent. The player must slip through the camp's heart.

**WARLORD GRAKKOR:** (asleep, snoring) "...zzzz..."
*Embra tiptoes. She nearly succeeds. A sentry stirs.*
> ► **(Fight.)** — A short, loud skirmish.
> ► **(Sneak.)** — A tense, silent crawl.
> ► **(Offer Grakkor a bargain.)** — A very brief, very strange negotiation.

**GRAKKOR:** (waking, blinking) "...Who's *that*?"
**EMBRA:** "Your *prisoner*, sir. Escaping."
**GRAKKOR:** "...Oh. Right. *Sentries!*"

**Scene 4: the return.** At dawn, in the Thane's hall, a very dusty eleven-year-old dwarf strides in, hammer on her shoulder.

**EMBRA:** "Grandmother. I escaped."
**BRUNHILD:** (kneeling, hoarse) "So I see."
**EMBRA:** "I had help."
**BRUNHILD:** "I know."
*She looks at the player over the child's head.*
**BRUNHILD:** "...Thank you."

**Outcomes and receipt.**
- Embra is rescued; Warlord Grakkor's camp is dissolved, or (in the bargain branch) turned against Skarn. The Thane gives the player a clan-token, granting passage in Karak Dûn.
- **Receipt:** a small hammer hangs at the player's belt: *Embra's.* She sends letters each season.

<!-- quest
id: qst_ih_thanes_granddaughter
title: The Thane's Granddaughter
rank: A
type: Escort
giver: npc_brunhild_ironvow
region: reg_iron_hold
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 130000
sets: ih_granddaughter_resolved
summary: Skarn's orcs have taken the Thane's granddaughter hostage. The Thane cannot spend an army on a rescue.
objectives:
  talk npc_brunhild_ironvow
  reach ih_grakkor_camp
  escort npc_embra_ironvow
  choice fight_sneak_or_bargain
-->

---

## 10. The Anvil That Counted

*A · Hidden · the Great Hall · giver Old Baldur Anvilfast*

*Best played on a Thorsday.*

**The short version.** On every Thorsday, Old Baldur strikes the first blow on the Great Hall's anvil. For three hundred years he has never missed. This Thorsday he asks the player to strike it *instead*.

**What is really going on.** The Great Anvil counts. Every stroke struck on it for a thousand years is recorded in the stone. There is one stroke that has *never* been counted: the first. The anvil *remembers* it was struck, but not by whom. Baldur, who cannot bear to leave the legend unfinished, believes the player is the one.

**Scene 1: the hall.**

**BALDUR:** "Three hundred years, I have struck the first blow. Never missed. Never once."
**BALDUR:** "But the anvil... it *counts*, you see. Every blow. And I have always known there was one it never counted."
**BALDUR:** "The *first.* The very first. The one that started the hold."
> ► **"Who struck it?"** — **BALDUR:** "No one knows. That is the point."
> ► **"What do you want?"** — **BALDUR:** "For you to strike it. Tonight."
> ► **"Why me?"** — **BALDUR:** "Because the anvil asked."

**Scene 2: the preparation.** In the Great Hall, as the Thorsday forging begins, a thousand dwarves stand in rows, each with a hammer. The anvil, a vast black slab, is *warm.*

**BALDUR:** "It has been warm since you came into the hall."
**BALDUR:** "Strike it. Not hard. *True.*"
*A great, ancient hammer is placed in the player's hands. It is heavier than it looks.*
> ► **(Strike once, true.)** — A deep, ringing note.
> ► **(Strike three times.)** — The anvil is silent.
> ► **(Hesitate.)** — Baldur nods.

**Scene 3: the stroke.** The blow lands. The anvil *sings*, a single, enormous note that fills the hall and shivers the stones. A thousand hammers answer, in unison, in the same pitch.

**BALDUR:** (whispering) "...That's it."
**BALDUR:** "That's the one it was waiting for."
*Along the anvil's face, a thin line of glowing runes appears, spelling a single word in a language older than Dwarvish.*

**Scene 4: the word.** The runes fade. Baldur is crying openly.

**BALDUR:** "I never knew what it would say."
**BALDUR:** "It says... *'Again.'*"
**BALDUR:** (laughing, tearful) "Three hundred years. And the anvil just wanted to be *struck* again."

**Outcomes and receipt.**
- The anvil's first stroke is "counted"; Baldur retires, content. The Great Hall adds a new tradition: on each Thorsday, a *guest* strikes the second blow.
- **Receipt:** the anvil's runes now read *"Again."* Baldur gives the player a small hammer-head, warm to the touch.

<!-- quest
id: qst_ih_anvil_counted
title: The Anvil That Counted
rank: A
type: Hidden
giver: npc_baldur_anvilfast
region: reg_iron_hold
level: 134
act: 4
requires_rank: A
reward: 34000 | 1700 | 148000
sets: ih_anvil_resolved
summary: The Great Anvil has counted every blow for a thousand years except the first. Old Baldur asks the player to strike it.
objectives:
  talk npc_baldur_anvilfast
  reach ih_great_hall_anvil
  choice strike_once_thrice_or_wait
-->
