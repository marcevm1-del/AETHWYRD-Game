# 11e-15 — Contracts with a Twist: Five Investigation Hunts (draft)

> *"The job says 'monster.' The evidence says 'neighbour.' Read the evidence."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 5 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** A guild contract names a monster and a price. Investigation shows the job is **misread**: the "monster" is trapped, grieving, hungry, defending something, or doing a job nobody remembers. The pattern borrows the *shape* of the monster-contract-with-an-investigation idea and rebuilds it on Ascend's **field journal and hunt deduction** (Canon §6 proposal): evidence is recorded, hypotheses are tested, and **brute force remains viable**.

**How the Journal handles it.** Each quest lists **Evidence** (what the player can find), **Hypotheses** (what the evidence could mean; some are wrong), and **Approaches** (kill, drive off, negotiate, fix). The Journal never says which hypothesis is right; it says which are *supported*, *contradicted* or *untested*. The player can skip all of it and fight (a legitimate route, with a worse receipt). Canon §4d: no monster remembers the player.

**Rules.** No Tyrant is the "monster." No outcome is lost silently. The guild pays for *solved*, not *slain*, but a kill still pays at a reduced rate.

| # | Quest | Rank | Region | The "monster" |
|---|---|---|---|---|
| 1 | The Beast That Ate the Bridge | C | Moraveil | A river-troll mother |
| 2 | The Tithe-Hound | C | Velmark | A stone hound with a duty |
| 3 | The Head That Grew Back | B | Xochitl Mire | A hydra head no one fed |
| 4 | Back Pay for the Dead | B | Goldmere Coast | A ghost crew with an invoice |
| 5 | A Calf Lost on the Ice | A | Whitewater Reach | A hunting floe |

## Cast (contract clients)

<!-- npc
id: npc_farmer_orlo_marrow
name: Orlo Marrow
tier: townsfolk
race: Human
region: reg_moraveil
settlement: Moraveil market town
role: Farmer, bridge-owner
backstory: A gruff, tired farmer whose only bridge to the market has been smashed every night for a week, and who has had enough of being polite about it.
-->
<!-- npc
id: npc_reeve_quarrel
name: Reeve Matthias Quarrel
tier: major
race: Human
region: reg_velmark
settlement: Velmark ducal towns
role: Reeve of the White Duchies
backstory: A prim, anxious reeve who has collected the duchy's tithes for twenty years and is now being followed through the streets by a stone dog.
-->
<!-- npc
id: npc_boatwright_ixchel
name: Boatwright Tzitzi
tier: townsfolk
race: Human
region: reg_xochitl_mire
settlement: River-cities
role: Boatwright
backstory: A stout, practical boatwright who has lost four canoes to a hydra's head this month and would very much like to know why only one head does it.
-->
<!-- npc
id: npc_harbour_clerk_vandersee
name: Harbour-Clerk Vandersee
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Harbour clerk
backstory: A fussy, thorough harbour clerk who has received eleven invoices from a ghost ship this month and has not yet decided whether to pay them.
-->
<!-- npc
id: npc_leviathan_calf
name: The Lost Calf
tier: townsfolk
race: Leviathan
region: reg_whitewater_reach
settlement: The open ice
role: Lost leviathan calf
backstory: A pale, enormous, frightened leviathan calf that has lost its pod in a storm and has decided that the nearest warm voices are its family.
-->
<!-- npc
id: npc_elder_nuka
name: Elder Nuka
tier: major
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Village elder
backstory: A small, fierce village elder whose ice-fishing village has been followed for three weeks by a floe that moves against the current.
-->

---

## 1. The Beast That Ate the Bridge

*C · Bounty · Moraveil market town · client Orlo Marrow*

**The contract.** *"Beast destroys farm-bridge nightly. Reward: 4,000. Dead or driven off."*

**Scene 1: the client.**

**ORLO:** "Seven nights. Seven. Every morning, the stones are scattered along the bank. Not smashed. *Scattered.*"
**ORLO:** "A man has to get to market. I have a hog to sell. I've a wife who wants to know why the bridge keeps falling."
**ORLO:** "Kill it. I don't care what it is."
> ► **"What do you know about it?"** — **ORLO:** "Big. Wet. It comes at night."
> ► **"Has anyone seen it?"** — **ORLO:** "My boy saw a... *shape.*"

**Evidence (Journal).**
- **Stones are moved in one direction**, upstream, not scattered; none is broken.
- **Wet, three-toed prints** lead to a flooded cave a half-mile away.
- **A cracked eggshell**, *very large*, lies at the cave mouth.
- **A goblin fisher** reports a "grey mother" in the river, who has been very quiet.

**Hypotheses.**
- *A bridge-eating beast.* **Contradicted** (nothing is eaten).
- *A territorial troll.* **Partly supported** (but it is not attacking people).
- *A mother building a nest.* **Supported.**

**Scene 2: the cave.** In a half-flooded cave, a vast, grey river-troll sits curled around a nest of heaped stones. A single, large, pale egg rests in the middle.

**TROLL (low, gentle rumble, not a threat):** "*...Go away.*"
**TROLL:** "*I am building. I am almost done.*"
**TROLL:** "*The water is rising. The egg must be dry.*"
> ► **"You're moving the bridge."** — **TROLL:** "*...I am borrowing it.*"
> ► **"We can help."** — **TROLL:** "*Help?*"
> ► **"The farmer needs the bridge."** — **TROLL:** "*...The egg needs the stones more.*"

**Approaches.**
- **Brute force.** The player may fight the troll. She is strong, wounded and *defending an egg.* The guild pays half.
- **Drive off.** She will leave, abandoning the egg. The egg is *lost.*
- **Negotiate.** The player and the farmer's family build the troll a *proper dry shelter* on the high bank, from fresh-cut stone; the bridge is rebuilt.
- **Moraveil's way.** The goblin fisher and the farmer's daughter work *together*, as the truce's founders did.

**Scene 3: the building.** Over a day, the goblins and humans of Moraveil haul stone. The troll watches. At sunset, the egg is lifted into its new, dry hollow.

**ORLO:** (grudging) "...I'll admit it. I didn't know."
**TROLL:** "*Thank you, small ones.*"
**ORLO:** "...Bring it a ham."

**Outcomes and receipt.**
- A *negotiated* outcome pays the full reward; a hatchling appears within a season, and the troll becomes the bridge's guardian.
- **Receipt:** a stone troll's-nest beside the bridge; a ham on a plate at the foot each Vexday.

<!-- quest
id: qst_pat_contract_bridge
title: The Beast That Ate the Bridge
rank: C
type: Bounty
giver: npc_farmer_orlo_marrow
region: reg_moraveil
level: 66
act: 3
requires_rank: C
reward: 4200 | 230 | 16000
sets: pat_contract_bridge_done
summary: A beast has been wrecking a farm-bridge every night. The stones are moved, not broken, and a very large egg lies by a flooded cave.
objectives:
  talk npc_farmer_orlo_marrow
  reach moraveil_flooded_cave
  choice fight_drive_off_or_build
-->

---

## 2. The Tithe-Hound

*C · Investigation · the White Duchies · client Reeve Matthias Quarrel*

**The contract.** *"Stone dog follows citizens through streets. Frightens children. Reward: 3,800. Destroy or remove."*

**Scene 1: the reeve.**

**QUARREL:** "It follows *me.* And only me. I'm the reeve! I collect the tithes! I do *nothing* wrong!"
**QUARREL:** "It sits outside my door. It watches me eat. It has begun to *breathe.*"
*Outside the window, a large, grey stone hound sits on the cobbles, perfectly still, facing the door.*
> ► **"Has it hurt anyone?"** — **QUARREL:** "*No.* It simply... *waits.*"
> ► **"Why you?"** — **QUARREL:** "I have no idea."
> ► **"When did it start?"** — **QUARREL:** "Last Tuesday. After I found... a ledger."

**Evidence.**
- **The hound's collar** is carved: *"Tithe-Hound of the First Duke."*
- **The ledger** lists tithes *owed to the land*, not the duke: *"One stone in ten to the quarry; one grain in ten to the field."*
- **No tithe has been paid in four generations.**
- **The hound follows only those who handled the ledger.**

**Hypotheses.**
- *A cursed statue.* **Contradicted** (it has never harmed anyone).
- *A watchdog for the duke.* **Contradicted** (the duke is dead).
- *The land's creditor.* **Supported.**

**Scene 2: the first duke's promise.** In the White Duchies' archive, a very old charter: *"The first duke paid the land a tithe for its stones. His heirs stopped paying."* (Gazetteer echo.)

**HOUND (via a soft, grinding voice):** "*...The account is open.*"
**HOUND:** "*One stone in ten. One grain in ten. Four generations behind.*"
**QUARREL:** (white) "It *talks?*"
> ► **"How much do we owe?"** — **HOUND:** "*Four generations. Eight hundred stones. One thousand sacks.*"
> ► **"What if we pay?"** — **HOUND:** "*Then the account is closed.*"
> ► **"What if we don't?"** — **HOUND:** "*...Then I wait.*"

**Approaches.**
- **Destroy it.** A very tough fight; the hound is a durable statue. The guild pays; the debt remains, and *the Tithe Colossus (the region's Tyrant) grows hungrier*.
- **Pay it.** Over a week, the duchy's towns deliver a token tithe: eight hundred small stones in a pile, a thousand symbolic grains. The hound rolls over.
- **Negotiate a schedule.** A yearly tithe, enshrined in law.

**Scene 3: the payment.** At the quarry, a procession of clerks and children carries stones and grain to the hound. It sits, patient, watching.

**HOUND:** "*...Paid.*"
**QUARREL:** (weeping with relief) "It said *paid.* I'm *paid.*"
*The hound lies down, curls up, and, very gradually, becomes part of the pavement.*

**Outcomes and receipt.**
- A *paid* or *scheduled* outcome improves the region's mood; the Tithe Colossus' pre-fight line changes (the account is partly closed).
- **Receipt:** a small stone dog on the quarry steps; each spring, the White Duchies celebrate Tithe Day.

<!-- quest
id: qst_pat_contract_tithe_hound
title: The Tithe-Hound
rank: C
type: Investigation
giver: npc_reeve_quarrel
region: reg_velmark
level: 68
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: pat_contract_tithe_hound_done
summary: A stone hound follows the duchy's reeve through the streets. It is the land's creditor, and four generations of tithes are unpaid.
objectives:
  talk npc_reeve_quarrel
  reach velmark_archive_charter
  choice destroy_pay_or_schedule
-->

---

## 3. The Head That Grew Back

*B · Bounty · the river-cities · client Boatwright Tzitzi*

**The contract.** *"Hydra head attacks canoes on the Flower River. Reward: 9,000. Kill the head."*

**Scene 1: the boatwright.**

**TZITZI:** "Four canoes. *Four.* Smashed to kindling. Only *one* head does it, always the same, always the *left.*"
**TZITZI:** "Everyone says: cut it off. It grows back. Everyone knows. But one head, *always the same*, why?"
> ► **"Which head?"** — **TZITZI:** "The one with the bad eye."
> ► **"Has anyone cut it off?"** — **TZITZI:** "Twice. It came back *angrier.*"
> ► **"I'll look."** — **TZITZI:** "Bring a canoe. A *good* one."

**Evidence.**
- **The hydra's heads** are each *marked* with a river-king's glyph, painted in old pigment.
- **The left head's glyph** is *faded and flaking*.
- **A ritual bowl** on a half-sunk altar holds the stone of a *forgotten fish-offering.*
- **Priests of the river-cities** confirm: *each head was fed a tithe of fish, by name.*

**Hypotheses.**
- *A rogue head.* **Partly supported** (it is the only one that attacks).
- *A hungry head.* **Supported** (the offering lapsed).
- *A possessed head.* **Contradicted.**

**Scene 2: the altar.** At a half-sunk altar in the mire, a priest sits on a rotting log, weeping softly.

**PRIEST:** "We stopped feeding them. Four hundred years. *Every other head* has been quiet, because they have *eaten.*"
**PRIEST:** "The left head's offering was lost. We forgot. It never *stopped asking.*"
> ► **"Feed it."** — **PRIEST:** "It must be *by name.*"
> ► **"Cut it."** — **PRIEST:** "It will grow back. It will be *hungrier.*"
> ► **"What's its name?"** — **PRIEST:** "...I do not know."

**Approaches.**
- **Cut it.** An enormous, fast fight. The head returns within a week, angrier.
- **Feed it.** A ritual meal, a *tithe of fish*, offered at dusk; the player must *choose a name.* The player's choice is accepted (the head has *no name left*).
- **Learn the name.** A long search in river-city archives yields the head's old name: **Itzel.**

**Scene 3: the offering.** At dusk, on a raft, the player sets a banana-leaf platter of silver fish before the left head. The head, great, slow, bright-eyed, lowers itself.

**PLAYER:** "...Itzel."
*The head blinks. It does not strike. It takes a single fish, then another, in a slow, ceremonial rhythm.*
**HEAD (a deep, soft rumble):** "*...Thank you.*"

**Outcomes and receipt.**
- The head is *fed*; the attacks stop. If the player *named* it, a second ritual is added to the calendar.
- **Receipt:** a fish-offering raft launched each dusk; Xibalbar's pre-fight line includes *"Itzel eats."*

<!-- quest
id: qst_pat_contract_hydra_head
title: The Head That Grew Back
rank: B
type: Bounty
giver: npc_boatwright_ixchel
region: reg_xochitl_mire
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: pat_contract_hydra_head_done
summary: One head of the mire's hydra smashes canoes. It is always the left, and it always grows back, because nobody has fed it in four hundred years.
objectives:
  talk npc_boatwright_ixchel
  reach xochitl_half_sunk_altar
  choice cut_feed_or_learn_name
-->

---

## 4. Back Pay for the Dead

*B · Bounty · Port Goldmere · client Harbour-Clerk Vandersee*

**The contract.** *"Phantom ship, 'the Merry Anselm,' harassing the harbour. Reward: 8,500. Sink or exorcise."*

**Scene 1: the clerk.**

**VANDERSEE:** "Eleven invoices. *Eleven.* Each one on gilt-edged paper, written in a very old hand."
**VANDERSEE:** "The ship sits at the mouth of the harbour. It does not attack. It *bills.*"
**VANDERSEE:** "I would like it *sunk.* I would also like to know *why a ghost ship has an accounts department.*"
> ► **"What do the invoices say?"** — **VANDERSEE:** "'Wages owed to crew of the Merry Anselm, forty-one years. Two hundred silver per head.'"
> ► **"Who owes them?"** — **VANDERSEE:** "The *port.* Apparently."
> ► **"Why the port?"** — **VANDERSEE:** "They say the ship was *salvaged.* And not *paid for.*"

**Evidence.**
- **The ship's manifest** (recovered by a diver) lists *forty-one crew, with wages unpaid since the wreck.*
- **A salvage ledger** from the port's records: the Merry Anselm was *raised, stripped, and sunk again*, its crew's wages *never settled.*
- **The ghost crew** has *never harmed anyone.* They have only *billed.*

**Hypotheses.**
- *A malicious ghost ship.* **Contradicted.**
- *A hungry spirit.* **Contradicted.**
- *Unfinished business.* **Supported.**

**Scene 2: the ship.** On the deck, a very polite ghost in a captain's coat, a ledger under his arm.

**CAPTAIN ANSELM:** "Ah! A representative of the port. Excellent. Please, sit. We have *grievances.*"
**CAPTAIN ANSELM:** "Forty-one years. Forty-one *men.* Each owed two hundred silver. And a *small* matter of an unpaid funeral."
**CAPTAIN ANSELM:** "I do not *haunt*, you understand. I *audit.*"
> ► **"The port is bankrupt."** — **CAPTAIN ANSELM:** "That is a *very* interesting claim."
> ► **"I'll negotiate."** — **CAPTAIN ANSELM:** "Splendid."
> ► **"You're dead."** — **CAPTAIN ANSELM:** "That is *not a defence.*"

**Approaches.**
- **Sink it.** The ship is a tough spectral foe; the crew *scatters* and the invoices *continue.*
- **Exorcise.** A quick rite; the crew is *quieted*, not *paid.*
- **Negotiate.** A settlement of 8,200 silver, a funeral, a small plaque and a *signature.* The port council, in a comic scene, argues the settlement down by three silver.

**Scene 3: the payment.** On the deck, in the dawn light, forty-one ghostly sailors line up. One by one, the player hands each a small bag of silver (symbolic) and a handshake.

**SAILOR:** "Pleasure doing business."
**CAPTAIN ANSELM:** "...Settled. *All settled.*"
*The ship's lanterns glow. One by one, the crew steps to the rail and dissolves into spray.*

**Outcomes and receipt.**
- The ship is released; the port's records are corrected. A *sunk* ship leaves a very annoying ghost-invoice in the clerk's office.
- **Receipt:** a plaque at the mouth of the harbour: *"The Merry Anselm. Paid in full."*

<!-- quest
id: qst_pat_contract_ghost_invoice
title: Back Pay for the Dead
rank: B
type: Bounty
giver: npc_harbour_clerk_vandersee
region: reg_goldmere_coast
level: 96
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: pat_contract_ghost_invoice_done
summary: A phantom ship sends invoices to the harbour clerk. Its crew is owed forty-one years of unpaid wages.
objectives:
  talk npc_harbour_clerk_vandersee
  reach goldmere_merry_anselm
  choice sink_exorcise_or_negotiate
-->

---

## 5. A Calf Lost on the Ice

*A · Bounty · the ice-fishing villages · client Elder Nuka*

**The contract.** *"Hunting floe pursues village. Destroy floe. Reward: 28,000."*

**Scene 1: the elder.**

**NUKA:** "Three weeks. It follows us. Against the current. Against the *wind.* A floe the size of a barn."
**NUKA:** "We move the village. It moves. We break camp at night. It is *there* at dawn."
**NUKA:** "It does not attack. It *waits.* And it is *wet* in a way ice should not be."
> ► **"Is it alive?"** — **NUKA:** "I do not know."
> ► **"What do you want?"** — **NUKA:** "To sleep."
> ► **"I'll look."** — **NUKA:** "Take a dog."

**Evidence.**
- **The floe's underside** is *warm* and *breathing.*
- **A faint, high song** (almost a whistle) comes from beneath it.
- **A trail of *blubber-oil*** marks its path from a distant gap in the ice.
- **A fisher's account:** *"The floe came the day after the big storm broke the Leviathan's pod."*

**Hypotheses.**
- *A hunting beast.* **Contradicted.**
- *A tracking spell.* **Contradicted.**
- *A lost calf.* **Supported.**

**Scene 2: the floe.** The player, in a small boat, nears the floe at dawn. Beneath the ice, a vast, pale, smooth shape, a calf of a great white leviathan, small only in comparison, turns and looks up. Its eye is the size of a shield.

**CALF (a high, thin, plaintive whistle; subtitled):** *"...Mother?"*
**NUKA (earlier):** "Ysgrath breaks the floes from below. She is not a *calf's* mother."
**PLAYER:** "No. But somebody's is."

**Scene 3: the guiding.** The player must lead the calf *home*, a long, slow journey across the open sea toward the sound of the pod, with a lantern, a whistle and a patient dog.

*(Gameplay: a gentle, moving escort. The calf follows the lantern; storms and wandering ice-wolves test the player's patience.)*

**CALF:** *(a trembling song)*
> ► **(Sing back.)** — The calf quiets.
> ► **(Light the lantern.)** — It follows.
> ► **(Fight the ice-wolves.)** — A short skirmish.

**Scene 4: the pod.** At the edge of a vast, frozen bay, a great chorus of whistles. The calf surges forward, and out of the water rises a vast, pale mother, who nudges it, once, and sings.

**NUKA (from the shore):** "...She *knows* it."
*The pod turns north and, one by one, sinks into the dark.*

**Outcomes and receipt.**
- The calf is returned; the floe never returns. If the player *destroyed* the floe, the calf dies, and the pod is *angry*; Ysgrath's fight is harder.
- **Receipt:** a small whale-bone whistle in the player's Journal; the village names its next child *Calf.*

<!-- quest
id: qst_pat_contract_calf
title: A Calf Lost on the Ice
rank: A
type: Bounty
giver: npc_elder_nuka
region: reg_whitewater_reach
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: pat_contract_calf_done
summary: A floe has followed an ice-fishing village for three weeks, against the current. It is a lost leviathan calf.
objectives:
  talk npc_elder_nuka
  reach whitewater_hunting_floe
  escort npc_leviathan_calf
  choice destroy_guide_or_sing
-->
