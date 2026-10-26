# 11e-05 — Sylvaran, the Canopy Kingdom: Ten Side Quests (draft)

> *"The elves remember planting these trees. The trees remember something older that grew there first."*
> — Gazetteer, Sylvaran

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 6 plants an *unexplained* hint about what grew in Sylvaran before the elves; it is a seed and is never answered.

**Region:** `reg_sylvaran` (Canopy City Lothaniel, the moonwell hamlets, the forest floor, the World Tree). **Rank band:** D–B. **Tone:** formal, slow, beautiful, and quietly afraid. The elves are proud, ancient and slow to admit they need help.

**Placement notes.**
- **Mycelia the Spore Lord** is the region's Tyrant. A blight spreads through the roots, softening bark and minds alike. No quest here kills her.
- The main Act III Sylvaran arc (the World Tree's Blight, Prince Thalien and the Dark Elf exiles, *restore or burn the blighted root*) is **not** touched. These quests sit beside it.
- Court elves of Lothaniel are formal and status-conscious; the moonwell hamlets below are wood elves who find the court absurd. Humans, gnomes and beastfolk live in the trade quarters and are charged twice as much until they earn respect. Quests 1, 2 and 4 use that friction.
- Moonwells are sacred and may not be drunk from without permission. Sylvasday is the realm's holy day.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Crooked Bridge | D | OddJob | Ilmarin Thistledown | A craft, a quarrel, a better path |
| 2 | The Girl Who Drank the Moon | D | Investigation | Elwyn Moonfern | A child, a sacred well, a court |
| 3 | A Bow Must Be Asked For | D | OddJob | Aerendil Ashwood | Patience, a tree that says no |
| 4 | Two Hundred Years of Silence | C | Faction | Lady Thessaly Elmwhisper | The slowest feud in Aetheria |
| 5 | The Gentle Spores | C | Investigation | Oriel Fenwood | A kindly blight |
| 6 | What the Trees Remember | C | Exploration | Ashael of the Silver Bark | A seed, left open |
| 7 | The Pilgrim and the World Tree | C | Escort | Joran Tarn | A human at a holy place |
| 8 | A Cup of Sunwine | B | Investigation | Chamberlain Eredhel Fairbrook | Murder at the garden party |
| 9 | The Rootward Watch | B | Defense | Bowmaster Lirael Swiftthorn | A hamlet defended by archers |
| 10 | The Last Planting | B | Faction | Old Ambrael | One more seed |

## Cast (new supporting NPCs)

<!-- npc
id: npc_ilmarin_thistledown
name: Ilmarin Thistledown
tier: townsfolk
race: Elf
region: reg_sylvaran
settlement: Canopy City Lothaniel
role: Apprentice bridge-grower
backstory: A restless wood-elf apprentice who has grown nine bridges for the court and is quietly convinced the court has been asking for the wrong ones.
-->
<!-- npc
id: npc_elwyn_moonfern
name: Elwyn Moonfern
tier: major
race: Elf
region: reg_sylvaran
settlement: Moonwell hamlets
role: Moonwell hamlet keeper
backstory: A weary wood-elf mother and the keeper of her hamlet's moonwell, who is learning that her child has done something nobody has done in a thousand years.
-->
<!-- npc
id: npc_aerendil_ashwood
name: Aerendil Ashwood
tier: major
race: Elf
region: reg_sylvaran
settlement: Canopy City Lothaniel
role: Master bowyer
backstory: A patient master bowyer who has made two thousand bows and has never once taken wood without asking the tree first.
-->
<!-- npc
id: npc_thessaly_elmwhisper
name: Lady Thessaly Elmwhisper
tier: major
race: Elf
region: reg_sylvaran
settlement: Canopy City Lothaniel
role: Elder of House Elmwhisper
backstory: A three-hundred-year-old noblewoman of Lothaniel who has not spoken to her sister in two hundred years and no longer remembers why.
secret: She still sets a second place at every meal.
-->
<!-- npc
id: npc_oriel_fenwood
name: Oriel Fenwood
tier: major
race: Elf
region: reg_sylvaran
settlement: Moonwell hamlets
role: Hamlet warden
backstory: A calm, careful warden of a moonwell hamlet who has begun to feel unreasonably cheerful and does not trust it.
-->
<!-- npc
id: npc_ashael_dryad
name: Ashael of the Silver Bark
tier: major
race: Dryad
region: reg_sylvaran
settlement: The forest floor
role: Dryad of an old silver birch
backstory: A shy, ancient dryad bound to a silver birch older than Lothaniel, who has recently begun to dream of something that was in the forest before the elves.
-->
<!-- npc
id: npc_joran_tarn
name: Joran Tarn
tier: townsfolk
race: Human
region: reg_sylvaran
settlement: Canopy City Lothaniel
role: Pilgrim
backstory: A grey-bearded human carpenter who has walked four hundred miles to reach the World Tree, and who will not say why.
secret: His daughter died under a tree.
-->
<!-- npc
id: npc_eredhel_fairbrook
name: Chamberlain Eredhel Fairbrook
tier: major
race: Elf
region: reg_sylvaran
settlement: Canopy City Lothaniel
role: Chamberlain of the Queen's court
backstory: A precise, observant chamberlain who has managed the Queen's household for a century and whose first rule is that nothing unexpected may happen at a garden party.
-->
<!-- npc
id: npc_lirael_swiftthorn
name: Bowmaster Lirael Swiftthorn
tier: major
race: Elf
region: reg_sylvaran
settlement: Moonwell hamlets
role: Bowmaster of the Rootward Watch
backstory: A young-looking wood-elf bowmaster who has trained every archer in the Rootward Watch and is, by her own account, only a hundred and forty.
-->
<!-- npc
id: npc_old_ambrael
name: Old Ambrael
tier: major
race: Elf
region: reg_sylvaran
settlement: The forest floor
role: Retired tree-planter
backstory: An elf so old that even the court has stopped counting, who has planted a tree every year for nine hundred years and has one seed left.
-->

---

## 1. The Crooked Bridge

*D · OddJob · Canopy City Lothaniel · giver Ilmarin Thistledown*

**The short version.** Ilmarin's latest living bridge has grown crooked. It no longer joins the court terrace to the market quarter. It sweeps *down* toward the moonwell hamlets. The court wants it cut. Ilmarin wants to know why it grew that way.

**What is really going on.** Bridges grow toward what they are *asked* for, and also toward what the tree *wants*. This one grew toward the hamlets because the hamlets' children have been climbing to the court for generations to see the lights, and the tree remembers every footstep. It is not crooked. It is *kind*.

**Scene 1: the terrace.**

**ILMARIN:** "Nine bridges. Nine, I have grown for this court. Every one exactly as asked. And *this* one..."
*He gestures at a long green arch that curves away from the terrace, away from the market, and down through the leaves.*
**ILMARIN:** "It goes *down*. It's not meant to go down."
**ILMARIN:** "The court says: cut it. Re-grow it. I say: let me find out *why*."
> ► **"What do bridges want?"** — **ILMARIN:** "To join. That's all. That's *all*."
> ► **"What did you ask for?"** — **ILMARIN:** "Court terrace to market quarter. A hundred paces. Straight."
> ► **"Why would it go down?"** — **ILMARIN:** "I haven't the faintest. I'm hoping you do."

**Scene 2: the walk.** Following the bridge down through layers of leaf and branch, the player sees where it ends: a quiet wooden landing in front of a moonwell hamlet. A dozen elf children sit along the rail with their feet dangling, watching the court lanterns.

**CHILD:** "Is it true that the lanterns all light at once?"
**ILMARIN:** "They do. At dusk. Each one, from the High Terrace down."
**CHILD:** "We've never seen it. Mama says we can't go up. The court charges."
> ► **"The court charges to cross?"** — **CHILD:** "Two coppers for a *child*."
> ► **"Is that fair?"** — **CHILD:** "It's the law."
> ► **"Would you like to see it?"** — **CHILD:** "...More than anything."

**Scene 3: the court.** In the council of elder houses, the player and Ilmarin plead for the bridge. Lord Eldrath Brightspear, severe and tall, speaks for the court.

**ELDRATH:** "A bridge is a *work of statecraft*. It does not wander."
**ILMARIN:** "It's a living thing, my lord. It goes where it is *loved*."
**ELDRATH:** "That is a sentiment, not a justification."
> ► **"The bridge is a gift."** — **ELDRATH:** "A gift to whom?"
> ► **"The bridge shows what the court has forgotten."** — **ELDRATH:** "...Careful."
> ► **"Cut a toll-free path."** — **ELDRATH:** "Absurd."

**Scene 4: the lighting.** At dusk, the council relents *a little*. The bridge stays. And for one evening only, the court lanterns are lit from the High Terrace down. A hundred children cross the crooked bridge in a long, quiet line.

**CHILD:** "It's like the stars came down."
**ILMARIN:** (to the player, very quietly) "That's the bridge I would have grown, if anyone had asked me."

**Outcomes and receipt.**
- The bridge stays as a free children's crossing at dusk, with the court's grudging approval. If the player argues poorly, the bridge is allowed to stand but is *closed after dark*.
- **Receipt:** a hundred small lanterns hang along the crooked bridge; Ilmarin becomes a full bridge-grower; the court's toll on children quietly lapses.

<!-- quest
id: qst_syl_crooked_bridge
title: The Crooked Bridge
rank: D
type: OddJob
giver: npc_ilmarin_thistledown
region: reg_sylvaran
level: 40
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: syl_bridge_resolved
summary: A living bridge has grown crooked, away from the court and down toward the moonwell hamlets. The court wants it cut.
objectives:
  talk npc_ilmarin_thistledown
  reach lothaniel_crooked_bridge_landing
  choice gift_mirror_or_toll_free
-->

---

## 2. The Girl Who Drank the Moon

*D · Investigation · the moonwell hamlets · giver Elwyn Moonfern*

**The short version.** Elwyn's seven-year-old daughter drank from the hamlet's moonwell, which is forbidden. The well's glow has gone out. The child now *shines*.

**What is really going on.** Moonwells are not simple pools. They are *seeds of the World Tree's own light*. Once in a thousand years, a well chooses a child. The court will insist the glow be "returned." The truth is that it cannot be, without harming her.

**Scene 1: the hamlet.**

**ELWYN:** "She's seven. She's *seven*. She was thirsty. She didn't *know*."
**ELWYN:** "The well is dark. The court's inspector will be here at dawn. And look at her."
*In the corner, a small child sleeps on a pile of moss, faintly, steadily glowing like a candle behind frosted glass.*
**ELWYN:** "She's not hurt. She's *happy*. That's the thing. She's happier than she's ever been."
> ► **"Has this happened before?"** — **ELWYN:** "Not in any story I know."
> ► **"What does the court do?"** — **ELWYN:** "It will say the well was *profaned*. It will say she must be... *emptied*."
> ► **"I'll help."** — **ELWYN:** "Thank you. Be quick."

**Scene 2: the elder.** The player consults an old moonwell-singer, **Maeve Dusk**, who lives alone at the next well.

**MAEVE:** "I've sung to moonwells for four hundred years. I have never seen a well *choose*."
**MAEVE:** "The legends say it happened once. A child, a well, a thousand years ago. She became the first Warden of the World Tree."
**MAEVE:** "The court has forgotten. Or *prefers* to."
> ► **"Can the glow be returned?"** — **MAEVE:** "It can. And the child will be *dimmer* for the rest of her life."
> ► **"What if we let her keep it?"** — **MAEVE:** "Then the court will say she is a danger."
> ► **"Is she a danger?"** — **MAEVE:** "She is a *child*."

**Scene 3: the inspector.** At dawn, Court Inspector **Halvarin Dawnspire** arrives with two silent guards.

**HALVARIN:** "The well is dark. The child shines. The law is clear."
**ELWYN:** "She's a *child*."
**HALVARIN:** "She is a *vessel*. We will return what was taken."
> ► **"Cite the legend."** — **HALVARIN:** "Legends are not law."
> ► **"Offer a trial."** — **HALVARIN:** "A trial of what?"
> ► **"Let her speak."** — **HALVARIN:** (a long, startled pause) "...Very well."

**Scene 4: the child.** The girl, **Nia**, wakes, looks at the inspector, and says, calmly:

**NIA:** "The well said I could."
**NIA:** "It was very sad. It was dark in there. It wanted someone to be in the light."
**NIA:** "I'm not scared. Are *you* scared?"
*The inspector says nothing for a long time.*

**Outcomes and receipt.**
- The player persuades the inspector to *report* the event to the Queen rather than punish it. Nia is declared a "ward of the well" and begins a quiet apprenticeship under Maeve.
- **Receipt:** the moonwell is a very faint blue again; Nia's glow is a small, steady light; the hamlet's children leave small stones at the well.

<!-- quest
id: qst_syl_girl_drank_moon
title: The Girl Who Drank the Moon
rank: D
type: Investigation
giver: npc_elwyn_moonfern
region: reg_sylvaran
level: 44
act: 2
requires_rank: D
reward: 1700 | 100 | 6800
sets: syl_moon_resolved
summary: A seven-year-old drank from a forbidden moonwell. The well is dark and the child now shines. The court wants the glow returned.
objectives:
  talk npc_elwyn_moonfern
  reach sylvaran_moonwell_hamlet
  choice legend_trial_or_child_speaks
-->

---

## 3. A Bow Must Be Asked For

*D · OddJob · Canopy City Lothaniel · giver Aerendil Ashwood*

**The short version.** A bowyer's apprentice must finish a *war-bow* by tomorrow's dusk. The wood must be *asked for*. The tree has said no.

**What is really going on.** The apprentice, **Caelyn**, has never been refused. The ash tree she wants *is* a good one. But it has a nesting owl in its crown, and it says: *not this year.* Caelyn has to learn that a "no" is a gift.

**Scene 1: the workshop.**

**AERENDIL:** "I have made two thousand bows. I have never once taken wood without asking."
**AERENDIL:** "Caelyn has seven days to make a war-bow for the Rootward Watch. The ash at the river bend is ideal. She has asked it three times."
**AERENDIL:** "It has refused. Three times."
> ► **"What do I do?"** — **AERENDIL:** "Listen. A tree says no for a reason."
> ► **"Can't she take it anyway?"** — **AERENDIL:** (sharply) "No."

**Scene 2: the ash.** At the river bend, the player and Caelyn stand before a very old ash. A great horned owl blinks from a branch.

**CAELYN:** "I asked *nicely*. I sang. I offered it seeds."
**ASH (a slow rustle, understood rather than heard):** *Not this year.*
**CAELYN:** "It's *true*. It does say that."
> ► **"Ask why."** — The ash shows a nest in its crown: three owlets, newly hatched.
> ► **"Offer a trade."** — The ash is silent.
> ► **"Ask another tree."** — **CAELYN:** "They're all *worse*."

**Scene 3: the storm-limb.** At the far end of the forest, a great oak has been struck by lightning and has dropped a limb. Fallen wood, already dead, is not a taking; it is a *gift*.

**AERENDIL (distant):** "A tree cannot say no to a limb it has already let go."
> ► **"Take the storm-limb."** — **CAELYN:** "It's *not as good*."
> ► **"Let Caelyn decide."** — She stares at the limb for a long time.

**Scene 4: the bow.** In the workshop, Caelyn shapes the dead limb into a bow. It is not perfect. It has a knot; it flexes oddly. She hands it to the Rootward Watch captain.

**CAPTAIN:** "It's... not what I asked."
**CAELYN:** "No. It's *better*. It was already part of the storm."
*The captain draws it, and the arrow flies true.*

**Outcomes and receipt.**
- The bow is finished with the storm-limb; the ash's owlets fledge in the autumn; Caelyn is accepted as a journeyman.
- **Receipt:** a small carved owl hangs in the workshop; the player is granted a bow that cannot be bought, only *asked for*.

<!-- quest
id: qst_syl_bow_asked
title: A Bow Must Be Asked For
rank: D
type: OddJob
giver: npc_aerendil_ashwood
region: reg_sylvaran
level: 42
act: 2
requires_rank: D
reward: 1600 | 95 | 6500
sets: syl_bow_resolved
summary: A bowyer's apprentice has to make a war-bow in a week. The ash she wants has said no three times.
objectives:
  talk npc_aerendil_ashwood
  reach sylvaran_river_bend_ash
  choice storm_limb_or_other_tree
-->

---

## 4. Two Hundred Years of Silence

*C · Faction · Canopy City Lothaniel · giver Lady Thessaly Elmwhisper*

**The short version.** Lady Thessaly has not spoken to her sister for two hundred years. She no longer remembers why. She would like someone to ask.

**What is really going on.** The sisters, **Thessaly** and **Linwe**, fell out over a borrowed book. The book was *lost*. Each blamed the other. Linwe died in the quarrel's second century. Her ghost, a faint figure in the Elmwhisper library, still haunts the shelf where the book was kept, waiting for an apology that was never sent.

**Scene 1: the parlour.**

**THESSALY:** "I have the second place set at every meal. I do not know why. It is *habit*."
**THESSALY:** "My sister Linwe and I had a falling-out. I think it was over a book. Or a bird. I truly cannot remember."
**THESSALY:** "I would like to know what I have been *angry about* for two centuries."
> ► **"Where is your sister now?"** — **THESSALY:** "She died. Sixty years ago. I did not attend."
> ► **"Have you tried to remember?"** — **THESSALY:** "I have tried *everything*."
> ► **"I'll find out."** — **THESSALY:** "Thank you. Be gentle. I am *very old*."

**Scene 2: the library.** Dust, moonlight, a ring of lost volumes. At the far end, a shelf with a single gap. A pale shape stands before it.

**LINWE (ghost):** "...Is that you, Thessaly?"
**PLAYER:** "A friend of hers."
**LINWE:** "She never came. I waited. I waited at this shelf, because that is where we *last spoke*."
**LINWE:** "She said I had lost her book. I said she had. We both... *said things*."
> ► **"Which book?"** — **LINWE:** "*The Annals of the Willow.* Her grandmother's."
> ► **"Do you still blame her?"** — **LINWE:** "I never... *stopped*."
> ► **"She's still setting a place for you."** — **LINWE:** (a silence) "...She *is*?"

**Scene 3: the search.** The player finds the book in an unlikely place: *wedged behind a shelf*, where a stray cat had once dragged it to nest. It is warm. It has kittens' fur in it. It has been there for two hundred years.

**THESSALY:** (reading the book, hands trembling) "...It was never lost."
**THESSALY:** "It was never *anyone's fault*."

**Scene 4: the supper.** In the Elmwhisper dining room, a table is set for two. Thessaly sits at one end. At the other, in a faint and silvery shimmer, Linwe takes her seat.

**THESSALY:** "I am sorry."
**LINWE:** "So am I."
**THESSALY:** "I am very, very sorry."
**LINWE:** "...Pass the salt, sister."

**Outcomes and receipt.**
- The reconciliation is complete in every branch. If the player *reads the book aloud* at supper, Linwe is released; if they leave it unread, she stays a while.
- **Receipt:** the second place at the Elmwhisper table is now occupied by a flower; the book sits on its shelf, open.

<!-- quest
id: qst_syl_two_hundred_years
title: Two Hundred Years of Silence
rank: C
type: Faction
giver: npc_thessaly_elmwhisper
region: reg_sylvaran
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: syl_silence_resolved
summary: A three-hundred-year-old noblewoman hasn't spoken to her sister in two hundred years and can't remember why.
objectives:
  talk npc_thessaly_elmwhisper
  reach elmwhisper_library
  choice read_leave_or_burn
-->

---

## 5. The Gentle Spores

*C · Investigation · the moonwell hamlets · giver Oriel Fenwood*

**The short version.** Oriel is the warden of a hamlet where *everyone* has begun to feel unreasonably cheerful. She has begun to distrust it.

**What is really going on.** A **spore garden** has bloomed beneath the hamlet, tended by a half-awake mushroom-folk named **Pell Bracken** who thinks he is a gardener. Mycelia the Spore Lord's blight has a *pleasant* phase: gentle, warm, agreeable. By the time anyone feels sad about it, they have agreed to everything.

**Scene 1: the green.**

**ORIEL:** "We used to quarrel. About fences, about tithes, about the goat. Now nobody *argues*."
**ORIEL:** "I should be glad. I'm... *suspicious*. It's too easy."
**ORIEL:** "Yesterday I agreed to give away my best chair. I don't *remember deciding*."
> ► **"When did it start?"** — **ORIEL:** "Three weeks ago. After the first mushrooms came up."
> ► **"What's changed?"** — **ORIEL:** "The air smells... sweet."
> ► **"Let me look."** — **ORIEL:** "I don't trust myself to follow."

**Scene 2: the garden.** Beneath the hamlet, in a root cave, glowing mushrooms in ordered rows. A small mushroom-folk gardener in a straw hat hums as he waters them.

**PELL:** "Oh! Visitors! Do sit. Do. The spores are *lovely* this year."
**PELL:** "I don't remember planting them. But they're so *happy*. And everyone who comes down smiles."
**PELL:** "I think I'm the best gardener in the forest."
> ► **"Who taught you?"** — **PELL:** "Nobody. It just... grew."
> ► **"Have you been eating them?"** — **PELL:** "Of course! They're delicious."
> ► **"Come with me."** — **PELL:** "Oh, I couldn't. They'd *miss* me."

**Scene 3: the choice.** The spore garden is a branch of the blight. Pell is its unwitting caretaker. The player has three options, none of them clean.

> ► **"Burn the garden."** — Pell weeps; the hamlet's cheerfulness falls away; the quarrels return.
> ► **"Cure Pell first."** — A long, delicate sequence: pulling the spores from his lungs. He wakes *sad*, which is the best sign.
> ► **"Leave it, and warn the court."** — The court investigates, slowly.

**PELL (cured):** "...Oh. Oh no. What have I done?"
**ORIEL:** "You've done nothing."
**PELL:** "I've been *growing* it."

**Scene 4: the argument.** At dawn, the hamlet gathers at the green. For the first time in weeks, there is a *row*. About fences. About the goat. About who should have the chair.

**ORIEL:** (very quietly, smiling) "...Listen to them."
**ORIEL:** "I've never been so glad to hear a quarrel."

**Outcomes and receipt.**
- *Cure Pell* is the best outcome; he becomes a Warden's helper and the first elf-friendly mushroom-folk. *Burn* costs the hamlet a season's honey. *Warn the court* is slow, and the hamlet is suffering when the Queen's healers arrive.
- **Receipt:** a small shrine of ash and spore-lamps sits in the root cave; the hamlet's arguments resume with great enthusiasm.

<!-- quest
id: qst_syl_gentle_spores
title: The Gentle Spores
rank: C
type: Investigation
giver: npc_oriel_fenwood
region: reg_sylvaran
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: syl_spores_resolved
summary: A hamlet has grown suspiciously cheerful. A spore garden beneath it is tended by a gardener who doesn't know what he's growing.
objectives:
  talk npc_oriel_fenwood
  reach sylvaran_spore_garden
  choice burn_cure_or_warn
-->

---

## 6. What the Trees Remember

*C · Exploration · the forest floor · giver Ashael of the Silver Bark*

**The short version.** A dryad has begun to dream of something that was in the forest before the elves. She asks the player to follow the dreams to their end.

**What is really going on.** *Nothing is explained.* The quest is a deliberate seed. The player is shown *fragments*: a circle of dead moss, an unfamiliar carving, a pool of black water that reflects a different sky. The dryad's dream is never resolved, and the quest ends with a question.

**Scene 1: the birch.**

**ASHAEL:** "I am old. Older than the court. Older than the oldest bridge."
**ASHAEL:** "But I have begun to dream of something older than *I*."
**ASHAEL:** "A circle. A hum. Eight shapes in a ring, and a ninth, *smaller*, walking away."
> ► **"What do the shapes look like?"** — **ASHAEL:** "Tall. Slow. Not elf. Not dwarf. *Something else*."
> ► **"Why do you dream of them now?"** — **ASHAEL:** "Because the roots are *loosening*. The blight has woken old memories."
> ► **"I'll follow the dream."** — **ASHAEL:** "Thank you. Be gentle. They are very old."

**Scene 2: the trail.** The player follows a trail of dead moss, in a pattern of rings, to a clearing of black water. A single flat stone stands at the water's edge, inscribed with a spiral.

**JOURNAL (auto):** *The spiral resembles the carvings on the nine thrones. It is not the same. It is older.*
> ► **(Touch the stone.)** — A hum, felt in the teeth.
> ► **(Sketch the spiral.)** — The Journal records it.
> ► **(Say nothing.)** — The pool ripples once.

**Scene 3: the pool.** In the black water, for a heartbeat, the sky is *different*: wider, stranger, with a ring of pale light that does not belong to Aetheria's moons.

**ASHAEL:** (very quietly) "...I remember that sky."
**ASHAEL:** "I have *never seen it*."
> ► **"What does it mean?"** — **ASHAEL:** "I don't know."
> ► **"Is it dangerous?"** — **ASHAEL:** "I think it is... *patient*."
> ► **"We should tell the court."** — **ASHAEL:** "They would cut it down."

**Scene 4: the silence.** On the walk home, the dryad stops at the edge of her birch.

**ASHAEL:** "Thank you. For *looking*. I did not want to look alone."
**ASHAEL:** "I will keep the spiral. And I will dream again, perhaps."
*She touches the bark, and the leaves shiver, as if in answer to something far away.*

**Outcomes and receipt.**
- No explanation is given. The player may tell the court, the Queen's archivist, or no one. Each choice affects *how long* before the seed returns.
- **Receipt:** a faint spiral appears on the birch's bark and in the Journal; no other change.
- **Canon-safe:** this quest adds *no fact* beyond "something older grew here." It does not name, date or explain.

<!-- quest
id: qst_syl_trees_remember
title: What the Trees Remember
rank: C
type: Exploration
giver: npc_ashael_dryad
region: reg_sylvaran
level: 68
act: 3
requires_rank: C
reward: 4500 | 245 | 16500
sets: syl_remember_resolved
summary: A dryad dreams of something older than the elves. She asks you to follow the dream to its end, and the quest never explains it.
objectives:
  talk npc_ashael_dryad
  reach sylvaran_spiral_stone
  choice court_archivist_or_silence
-->

---

## 7. The Pilgrim and the World Tree

*C · Escort · Canopy City Lothaniel · giver Joran Tarn*

**The short version.** Joran has walked four hundred miles to reach the World Tree. Humans are not forbidden, but they are not welcomed. He does not say why he came.

**What is really going on.** Joran's daughter, **Mena**, died at nine in a storm when a tree fell on her. He has spent six years hating trees. Then he dreamed of a great one that spoke his daughter's name. He wants to stand under the World Tree and *ask it to forgive him*. He does not know whether he is asking the tree to forgive him, or himself.

**Scene 1: the gate.**

**JORAN:** "I've never asked for help. Not once. I'm not a man who asks."
**JORAN:** "But I can't go in alone. They won't let me."
**JORAN:** "I'm a carpenter. I've cut trees all my life. I'm... not sure they'll want me near."
> ► **"Why do you want to go?"** — **JORAN:** "I'd rather not say."
> ► **"I'll escort you."** — **JORAN:** "Thank you."

**Scene 2: the ascent.** The climb through the layered city is slow. A guard stops them at every terrace; the player speaks for Joran each time. A court-lady looks at his boots with open disdain.

**COURT-LADY:** "A human. In Lothaniel. *How quaint.*"
**JORAN:** (quietly) "I'll leave if you'd like."
> ► **"He's a guest."** — The court-lady, startled, steps aside.
> ► **"He's a pilgrim."** — The guards bow, grudgingly.
> ► **"He's with me."** — A short, tense moment.

**Scene 3: the root.** At the foot of the World Tree, a single root rises from the earth like a wall. Beyond it, in the quiet, a ring of wooden benches.

**JORAN:** (kneeling) "I cut down trees for forty years. Then one fell on her. I don't know whether to hate them or thank them."
**JORAN:** "I came to ask. I don't know what."
*A single leaf, silver-green, drifts down and lands on his open hand.*

**Scene 4: the answer.** The World Tree does not speak. But a *warmth* spreads from the root, and a wind stirs the canopy, and for a moment every leaf in Lothaniel turns.

**JORAN:** (a long silence) "...She's all right."
**JORAN:** "I don't know how I know. But she's all right."
**JORAN:** "Thank you, tree."

**Outcomes and receipt.**
- Joran returns home; if the player invites him, he settles in a moonwell hamlet and carves furniture *from fallen wood only*.
- **Receipt:** a small carved bench stands at the World Tree's root, with a single line cut in it: *"Mena."*

<!-- quest
id: qst_syl_pilgrim
title: The Pilgrim and the World Tree
rank: C
type: Escort
giver: npc_joran_tarn
region: reg_sylvaran
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: syl_pilgrim_resolved
summary: A human carpenter has walked four hundred miles to reach the World Tree. He won't say why.
objectives:
  talk npc_joran_tarn
  escort npc_joran_tarn
  reach world_tree_root
  choice speak_for_him_or_let_him
-->

---

## 8. A Cup of Sunwine

*B · Investigation · the Queen's garden party · giver Chamberlain Eredhel Fairbrook*

**The short version.** The Queen's garden party must have *no surprises.* A guest has collapsed over a cup of sunwine. Eredhel needs the culprit found before the guests notice.

**What is really going on.** The poisoned cup was meant for the *Queen's heir*, **Prince Thalien**, but the cup was swapped at the last moment by a young servant who had noticed the wine smelled wrong. The poisoner is a court physician, **Naeris Valorn**, who believes the Prince is *too gentle with the blight* and that his death would "save the realm." She is a patriot.

**Scene 1: the pavilion.**

**EREDHEL:** "Guest Aldric Thorne collapsed at the second toast. He will live. Barely."
**EREDHEL:** "The cup was meant for someone else. I would like to know *who*, and *why*, before the Queen's ninth course."
**EREDHEL:** "You will be seated at Table Six. You are, officially, a *visiting dignitary of the Merchants' Consortium*."
> ► **"Who are my tablemates?"** — **EREDHEL:** "Two lords, a poet, and the Prince's tutor."
> ► **"How long do I have?"** — **EREDHEL:** "Until dessert."

**Scene 2: the party.** A beautiful, tense investigation across a garden terrace: interviews with guests, a glance at the kitchens, a sleight-of-hand around the sunwine barrel. Each guest speaks in layered, formal, passive-aggressive elven courtesies.

**POET:** "The wine was *sweet.* Too sweet. I told the steward."
**TUTOR:** "The Prince declined his cup. He said it smelled of... *copper*."
**SERVANT (a girl, white-faced):** "I... I swapped the cups. I'm so sorry. I didn't want to see anyone die."
> ► **"You saved his life."** — **SERVANT:** "...I did?"
> ► **"Who gave you the cup?"** — **SERVANT:** "A lady in a green sash."
> ► **"Where is she?"** — **SERVANT:** "I don't know."

**Scene 3: the physician.** The player follows a green sash to the physician's pavilion. Naeris Valorn sits at her table, calmly, with a book.

**NAERIS:** "I am not a murderer. I am a *physician*."
**NAERIS:** "The Prince is too gentle with the blight. He would *nurse* a rotting root while the realm burns around him. If he sits the throne, we are lost."
**NAERIS:** "I was trying to *save* it."
> ► **"You tried to kill him."** — **NAERIS:** "I tried to *prevent* him."
> ► **"The realm is not yours to save."** — **NAERIS:** "...Whose is it?"
> ► **"Let the Queen decide."** — **NAERIS:** "She will have me hanged."

**Scene 4: the verdict.** At the ninth course, the Queen herself rises. The pavilion falls silent.

**QUEEN:** "I am told there was an irregularity."
**EREDHEL:** "A *minor* one, Majesty."
**QUEEN:** "I would like to hear it."
*The player must decide how much to say, and to whom.*
> ► **(Name the physician.)** — A public arrest; Prince Thalien is spared the knowledge.
> ► **(Name no one; hand the evidence to Eredhel.)** — A quiet trial.
> ► **(Tell the Prince privately.)** — Thalien is shaken; his Act III scenes gain one extra line.

**Outcomes and receipt.**
- Whatever the player decides, the physician is held; the servant is rewarded; the garden party resumes at dessert.
- **Receipt:** a green sash hangs in Eredhel's study; the servant becomes a royal page; the player receives an invitation to the Queen's private supper.
- **Canon-safe:** the Prince is a Sylvaran main-story character. This quest does not decide his arc; it only shows what the court says about it.

<!-- quest
id: qst_syl_sunwine
title: A Cup of Sunwine
rank: B
type: Investigation
giver: npc_eredhel_fairbrook
region: reg_sylvaran
level: 92
act: 3
requires_rank: B
reward: 11000 | 650 | 48000
sets: syl_sunwine_resolved
summary: A guest has collapsed at the Queen's garden party over a cup of sunwine meant for the Prince.
objectives:
  talk npc_eredhel_fairbrook
  reach lothaniel_garden_pavilion
  choice name_hand_over_or_tell_prince
-->

---

## 9. The Rootward Watch

*B · Defense · the moonwell hamlets · giver Bowmaster Lirael Swiftthorn*

**The short version.** A spore-touched beast herd is coming for a moonwell hamlet. The Rootward Watch has forty archers and one night. Lirael wants a swordsman in the line.

**What is really going on.** The beasts are *not* wild. They are being *driven*: Mycelia's blight has softened their minds and pulled them toward the moonwell, whose light is the only thing in the forest that *hurts* the blight. The hamlet is not merely a town; it is a *target*.

**Scene 1: the line.**

**LIRAEL:** "I've trained every archer in this Watch. The youngest is nineteen. The oldest is *me*."
**LIRAEL:** "The herd is two hundred strong. Elk, boar, a few wolves. Spore-touched. They'll hit the east hedge at dawn."
**LIRAEL:** "I have a plan. It requires a *sword in the line*, to hold the gap. That's you."
> ► **"What's the plan?"** — **LIRAEL:** "Volley. Reload. Hold. Repeat."
> ► **"What if the line breaks?"** — **LIRAEL:** "Then we die beautifully."
> ► **"I'll hold the gap."** — **LIRAEL:** "Good. Stand where I point."

**Scene 2: the night.** Preparation: stakes, torches, water for the archers, a ring of stones around the moonwell. The younger archers whisper; one, a boy named **Taelor**, is shaking.

**TAELOR:** "I've never loosed on something that was *alive*."
**LIRAEL:** "They are not alive. They are *driven*."
**LIRAEL:** "You will not enjoy it. You are not meant to."

**Scene 3: the dawn.** A defence sequence in three waves: the first, light; the second, heavy; the third, an elk the size of a house with glowing fungus down its spine. The archers loose in volleys; the player holds the gap.

*(Gameplay: wave defense, positional play, volley calls. The player's job is to stay in the gap and protect the archers behind.)*

**LIRAEL:** "*Hold!* Hold, hold, *loose!*"
**TAELOR:** (voice breaking) "I *hit* it!"
**LIRAEL:** "You hit it. Reload."

**Scene 4: the light.** At the height of the third wave, the moonwell flares: a single blue beam, wide as a doorway, striking the great elk. Spores boil off its back. It *stops*, shudders, and stands very still.

**LIRAEL:** "...The well."
**ELK:** *(looks at the hamlet, confused, and slowly turns away)*
**TAELOR:** "It's... *going home*."

**Outcomes and receipt.**
- The hamlet stands. If the player takes casualties, the Watch loses a few; if not, nobody dies. Lirael is changed by the elk's retreat.
- **Receipt:** the east hedge bears a long row of arrow-notched stakes; Taelor is promoted; Lirael carves a hundred-and-forty-first notch on her bow.

<!-- quest
id: qst_syl_rootward_watch
title: The Rootward Watch
rank: B
type: Defense
giver: npc_lirael_swiftthorn
region: reg_sylvaran
level: 96
act: 3
requires_rank: B
reward: 12000 | 700 | 52000
sets: syl_watch_resolved
summary: A spore-touched beast herd is coming for a moonwell hamlet. The Rootward Watch has forty archers and one night.
objectives:
  talk npc_lirael_swiftthorn
  defend sylvaran_east_hedge
  choice hold_the_gap_or_flank
-->

---

## 10. The Last Planting

*B · Faction · the edge of the blight · giver Old Ambrael*

**The short version.** Ambrael has planted a tree every year for nine hundred years. He has one seed left. He wants to plant it at the edge of the blight, and he is too old to walk there alone.

**What is really going on.** The seed is *the last of its kind*: a **sunroot**, a tree that burns away spores with its light. It has not grown in the wild for a thousand years. If it takes, it can hold the blight back for centuries. It will also *kill Ambrael*, because the planting requires the planter's life-light to wake the seed. He knows. He has never told the court.

**Scene 1: the hollow.**

**AMBRAEL:** "Nine hundred and one years. One tree each spring. I have forgotten most of their names."
**AMBRAEL:** "I have one seed. A sunroot. I carried it from the old forest, before the court was a court."
**AMBRAEL:** "I would like to plant it where it *matters*."
> ► **"Where?"** — **AMBRAEL:** "The edge of the blight. A day's walk south."
> ► **"What does it do?"** — **AMBRAEL:** "It burns. Gently. All that is wrong."
> ► **"Why not give it to the court?"** — **AMBRAEL:** "They would put it in a *garden*."

**Scene 2: the walk.** A slow, quiet journey through a darkening forest. The trees grow soft and strange; spores drift. Ambrael tells stories: the first tree he ever planted; a lost love; a long-ago war.

**AMBRAEL:** "I planted an oak for each of my children. They were oaks. I was a poor father, but a *good gardener*."
**AMBRAEL:** "I have decided that is enough."

**Scene 3: the edge.** At the edge of the blight, a great grey sprawl of soft bark and pale fungus. A single patch of bare earth waits, as if it had been cleared for this.

**AMBRAEL:** "Here."
*He kneels, digs with his bare hands, and holds the seed in his palm. It is small, round, faintly golden.*
**AMBRAEL:** "It needs a little of me. Not much."
> ► **"What does it cost?"** — **AMBRAEL:** (gently) "Everything. And very little."
> ► **"Let me do it."** — **AMBRAEL:** "It must be the planter. It must be *me*."
> ► **"Is there another way?"** — **AMBRAEL:** "I have looked for nine hundred years."

**Scene 4: the planting.** Ambrael presses the seed into the earth and rests his hand on the soil. A pale gold glow spreads from his palm. Slowly, gently, a green shoot unfurls, taller with every breath.

**AMBRAEL:** "Oh. Oh, it's *lovely*."
**AMBRAEL:** "Tell them... tell them it was a good garden."
*The shoot becomes a sapling, then a young tree, then a tree. Ambrael sits against its trunk, smiles, and does not get up.*

**Outcomes and receipt.**
- The sunroot holds the blight back along a mile of the border. The player decides how Ambrael is buried (at the root, in the court, in the hollow). The court names the tree **Ambrael's Light**.
- **Receipt:** a pale gold tree stands at the blight's edge; spore-light dims for a mile around it; a bench is carved at its root.
- **Canon-safe:** the quest is a slow, personal ending that *does not* resolve the blight or the Spore Lord.

<!-- quest
id: qst_syl_last_planting
title: The Last Planting
rank: B
type: Faction
giver: npc_old_ambrael
region: reg_sylvaran
level: 100
act: 3
requires_rank: B
reward: 14000 | 800 | 60000
sets: syl_planting_resolved
summary: An elf who has planted a tree every year for nine hundred years has one seed left, and wants to plant it at the edge of the blight.
objectives:
  talk npc_old_ambrael
  escort npc_old_ambrael
  reach sylvaran_blight_edge
  choice plant_with_him_or_alone
-->
