# 11e-23 — Goldmere Coast, the Salvage Shore: Ten Side Quests (draft)

> *"Half the port is built from the timber of one great fleet that sank in a single night."*
> — Gazetteer, Goldmere Coast

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light.

**Region:** `reg_goldmere_coast` (Port Goldmere, the Drowned Mermaid inn, the pirate stilt-towns on the outer reef, the Sunken Fleet, the wreck-tide, the safe channel). **Rank band:** B–A. **Tone:** salt, rope and rum, with a cold current underneath. Everyone is cheerful, quarrelsome and a little afraid, and the generosity runs deepest where it cost the least. Warm where a stranger gets a bowl of soup.

**Placement notes.**
- **Krakenmother Ys** is the region's Tyrant. She drags ships down before they wreck and keeps the cargo in her hoard. No quest here kills her or ends the raids; the quests change how the coast *prepares*, argues and mourns, and quest 9 lets the port decide whether to offer her anything.
- **Salvage law** is the law that matters: whoever first lays a hand on a wreck owns it. Pirate captains are elected and removed by their crews. Divers drop a coin into the sea before every descent and keep the first thing they find on a wreck as a charm. The dead are buried at sea **with their boots on**, so they can walk home along the bottom.
- Goldmerers pray to Vex above all, because every dive is a gamble. The coast speaks of "the sea's share."
- Earlier pattern quests in this region: *Heads, Tails and the Edge*, *The Lighthouse That Wasn't Lit*, *Back Pay for the Dead* and *The Honest Scale*. None is a prerequisite here.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Hot Meal and No Crew | B | Exploration | Salvage-Captain Marisol Dray | Mystery: a ship, a table laid |
| 2 | Neutral Ground | B | Faction | Captain Hollis Crake | Comic-warm: a truce on a rope bridge |
| 3 | Three Bidders Dead | B | Investigation | Auctioneer Dunstan Gavelle | Mystery: a map with a missing margin |
| 4 | Whose Boots Are These | B | Hidden | Tolly Sandwick | Tender: the sea sends one a year |
| 5 | The Parrot Who Kept the Books | B | OddJob | Hostess Perpetua Gull | Comic-warm: a bird overheard everything |
| 6 | The Bridges of Saltreach | B | Defense | Rope-Captain Duvessa Pike | Action: raiders on the rope-ways |
| 7 | The Flagship's Bell | A | Exploration | Diver-Master Ossian Haldane | Mystery: the fleet's last night |
| 8 | The Channel Moves | A | Escort | Pilot Marguerite Calloway | Action: a grain convoy through shifting water |
| 9 | A Tribute Proposed | A | Faction | Salvage-Speaker Evander Slate | Dilemma: feed the Krakenmother? |
| 10 | The Sea's Coins | A | Investigation | Dive-Mother Ketura Maine | Tender: who takes the divers' offering |

## Cast

<!-- npc
id: npc_marisol_dray
name: Salvage-Captain Marisol Dray
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Salvage captain who found the drifting ship
backstory: A shrewd, fair salvage captain who was first aboard a crewless ship with a hot dinner on its table, and who is no longer certain the law has been honoured.
-->
<!-- npc
id: npc_captain_oswin_teague
name: Captain Oswin Teague
tier: major
race: Human
region: reg_goldmere_coast
settlement: Saltreach stilt-town
role: Captain of the drifting ship
backstory: A proud, embarrassed captain who ordered his crew into the boats on a hunch and has been too ashamed to explain the hunch to anyone.
-->
<!-- npc
id: npc_captain_hollis_crake
name: Captain Hollis Crake
tier: major
race: Human
region: reg_goldmere_coast
settlement: Saltreach stilt-town
role: Elected captain of the stilt-town
backstory: A big-voiced pirate captain who wants a truce with the port to fight the Krakenmother and cannot bring himself to walk first onto the port's end of the bridge.
-->
<!-- npc
id: npc_councillor_mabyn_sallow
name: Councillor Mabyn Sallow
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Salvage-council member for the harbour reefs
backstory: A dry, careful councillor who would like a truce, will not say so, and refuses to walk first onto the stilt-town's end of the bridge.
-->
<!-- npc
id: npc_auctioneer_gavelle
name: Auctioneer Dunstan Gavelle
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere, the Drowned Mermaid
role: Auctioneer of salvage claims
backstory: A theatrical, silver-tongued auctioneer who cut the margin off a map to raise the bidding, and has now buried three bidders without once letting himself think why.
-->
<!-- npc
id: npc_tolly_sandwick
name: Tolly Sandwick
tier: townsfolk
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere, the Sea-Steps
role: Beachcombing child, aged ten
backstory: A fierce, freckled beachcomber who found a pair of boots on the tide-line and will not let anyone else touch them until she knows whose they are.
-->
<!-- npc
id: npc_cobbler_jessup_lamb
name: Old Cobbler Jessup Lamb
tier: townsfolk
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Retired bootmaker
backstory: A retired bootmaker who can tell a pair's maker, year and last owner by the stitch, and who has been waiting years for someone to ask.
-->
<!-- npc
id: npc_perpetua_gull
name: Hostess Perpetua Gull
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere, the Drowned Mermaid
role: Innkeeper of the Drowned Mermaid
backstory: A broad, good-humoured innkeeper who has run the Drowned Mermaid for thirty years and owns a parrot with a perfect memory and no sense of occasion.
-->
<!-- npc
id: npc_duvessa_pike
name: Rope-Captain Duvessa Pike
tier: major
race: Human
region: reg_goldmere_coast
settlement: Saltreach stilt-town
role: Elected rope-captain of the bridges
backstory: A lean, one-handed rope-captain who maintains every bridge on the outer reef and has never yet lost a person off one.
-->
<!-- npc
id: npc_ossian_haldane
name: Diver-Master Ossian Haldane
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Master of the deep-divers
backstory: A weathered diver-master who has dived the Sunken Fleet for forty years and is certain the flagship's bell has been rung since the night it sank.
-->
<!-- npc
id: npc_marguerite_calloway
name: Pilot Marguerite Calloway
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Channel pilot
backstory: A quiet, exacting pilot who carries the safe channel in her head, redraws it every dawn and has just found that it moved while she slept.
-->
<!-- npc
id: npc_salvage_speaker_slate
name: Salvage-Speaker Evander Slate
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere, Salvage Hall
role: Speaker of the salvage council
backstory: A practical, worn speaker who has presided over every council vote for eleven years and has never before been asked whether the port should pay a monster.
-->
<!-- npc
id: npc_captain_wilhelmina_stroud
name: Captain Wilhelmina Stroud
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere
role: Salvage captain, tribute's advocate
backstory: A hard-faced salvage captain who has lost four ships to the Krakenmother and sincerely believes a bribe is cheaper than a war.
-->
<!-- npc
id: npc_ketura_maine
name: Dive-Mother Ketura Maine
tier: major
race: Human
region: reg_goldmere_coast
settlement: Port Goldmere, the Dive-Houses
role: Teacher of the young divers
backstory: A calm, sharp-eyed dive-mother who has taught three hundred children to drop a coin before they dive, and has found out that the coins are vanishing.
-->

---

## 1. A Hot Meal and No Crew

*B · Exploration · the wreck-tide shallows · giver Salvage-Captain Marisol Dray*

**The short version.** Marisol found a three-masted ship drifting on the wreck-tide with no crew aboard and a hot dinner on the captain's table. By salvage law, whoever laid a hand on it first owns it. Marisol is sure she did. The captain is sure he didn't give it up. She asks the player to board it before the council rules.

**What is really going on.** The ship's captain, Oswin Teague, ordered every soul into the boats an hour before the Krakenmother's brood surfaced, on a hunch, a smell of cold water in the galley. The crew rowed to Saltreach. He left dinner on the table on purpose, to show he meant to come back. Salvage law counts *abandonment* as giving up a claim; a laid table counts as the opposite.

**Scene 1: the quay.**

**MARISOL:** "The soup was *hot.* Hot, player. The whole ship smelled of onion."
**MARISOL:** "I laid a hand on the rail before anyone. I called the claim. Now there's a captain somewhere who says it isn't *abandoned.*"
**MARISOL:** "I'd like to know the truth before I take a ship from a man who isn't dead."
> ► **"Let's look at the ship."** — **MARISOL:** "Mind the deck. It's *wet.*"
> ► **"What does the law say?"** — **MARISOL:** "That I'm in the right. I don't *like* it."
> ► **"What if he comes back?"** — **MARISOL:** "Then I'll give it back, with an apology."

**Scene 2: the ship.** Warm light still burns in the great cabin. A table is laid for eleven. Eleven bowls. Eleven spoons. A pot on the hob, going cold.

**MARISOL:** "No blood. No struggle. Just supper."
*On the captain's desk, a log open to the last entry: "Cold in the galley. Don't like it. Boats out." The ink is still wet.*

> ► **"He ran."** — **MARISOL:** "Ran from what?"
> ► **"He left on purpose."** — **MARISOL:** "Then it isn't abandoned."
> ► **"Something warned him."** — **MARISOL:** "A smell. Of cold water. That is not nothing."

**Scene 3: Saltreach.** In a stilt-town tavern, Captain Teague sits with eleven shaken sailors and a bowl of soup he has not touched.

**TEAGUE:** "I'm not a superstitious man. I've salted my own boots with fear for thirty years. But that day, I *knew.*"
**TEAGUE:** "I put the table out as a sign. *I meant to come back.* I swear to every day-god."
**TEAGUE:** "I did not think anyone would *take her.*"

**Scene 4: the ruling.** At Salvage Hall, the council waits. Two claims, both honest.

> ► **"Rule for Marisol. The law is the law."** — Teague bows his head and accepts the ruling.
> ► **"Rule for Teague. A laid table is an intent."** — The ship is returned; Marisol accepts it with grace and a small bruise.
> ► **"Split the claim."** — A shared ownership that suits nobody and satisfies everyone.

**MARISOL:** "I would like it recorded that I was *right.*"
**TEAGUE:** "I would like it recorded that I was *scared.*"

**Outcomes and receipt.**
- The ship is awarded. The ruling sets a new rule in the salvage book: a table laid with food counts as an intent to return.
- **Receipt:** a chalked line on the quay marking where the ship was moored; eleven bowls set out on the council table at the next meeting.

<!-- quest
id: qst_gmc_hot_meal_no_crew
title: A Hot Meal and No Crew
rank: B
type: Exploration
giver: npc_marisol_dray
region: reg_goldmere_coast
level: 88
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: gmc_hot_meal_ruled
summary: A crewless ship with a hot dinner on its table raises a salvage-law claim, and the captain's reason for leaving it was a hunch.
objectives:
  talk npc_marisol_dray
  talk npc_captain_oswin_teague
  reach drifting_ship_great_cabin
  choice dray_teague_or_split
-->

---

## 2. Neutral Ground

*B · Faction · the Saltreach rope bridge · giver Captain Hollis Crake*

**The short version.** Captain Crake of Saltreach wants a truce with Port Goldmere so the two can fight the Krakenmother together. The port wants it too. Neither will walk first. They have asked the player to stand in the middle of the rope bridge and negotiate.

**What is really going on.** Both parties have been sending each other letters for a month. Both want the truce. Both are waiting for the other to offer the first concession, because the loser of a coastal negotiation is known by who stepped forward first. They are less afraid of the Krakenmother than of looking foolish.

**Scene 1: the bridge.**

**CRAKE:** "I'll *not* walk first. I'm a captain. I was elected."
**SALLOW (from the other end):** "I'll not walk first. I sit on the salvage council. We have *procedures.*"
**CRAKE:** "We want the same thing!"
**SALLOW:** "That is not the *point.*"
> ► **"What do you each want?"** — **CRAKE:** "A truce!" **SALLOW:** "An *arrangement.*"
> ► **"Who goes first?"** — **BOTH:** "Not me."
> ► **"Stand in the middle."** — **CRAKE:** "It *sways.*"

**Scene 2: the ropes.** The player walks to the middle of the bridge, where it dips alarmingly over a tide-pool, and sets down a stool. It sways. A gull lands on it.

**CRAKE:** "You're mad."
**SALLOW:** "Mind the planks."
**PLAYER:** "Sit."
*Both captains, glaring, edge forward until they are four paces apart. Each stops. Neither will take the next step.*

**Scene 3: the deadlock.** The player tries to find a way.

> ► **"Both take one step, on a count."** — A tense, ridiculous countdown.
> ► **"Both sing the same verse."** — A shanty rises, half in Crake's gravel and half in Sallow's dry tenor.
> ► **"Cut the bridge in half and meet in the middle."** — A mad, practical solution with a rope-axe and a plank.

**CRAKE:** (muttering) "She's got a *terrible* voice."
**SALLOW:** (humming harmonies, to her visible horror) "...I know this one."

**Scene 4: the oath.** Both parties, sodden with sea-spray and a little ashamed, shake hands on the bridge, with a gull on the stool between them.

**CRAKE:** "I'd have done it a month ago if she'd walked first."
**SALLOW:** "I would have walked first if he'd have walked first."

**Outcomes and receipt.**
- The truce is struck: the port and Saltreach will share watch-fires, pilot-boats and wreck-warnings against the brood. Neither is allowed to say who gave way.
- **Receipt:** a stool nailed to the middle of the bridge with a brass plate reading *"Neutral ground";* a shared shanty added to the evening roster in both places.

<!-- quest
id: qst_gmc_neutral_ground
title: Neutral Ground
rank: B
type: Faction
giver: npc_captain_hollis_crake
region: reg_goldmere_coast
level: 91
act: 4
requires_rank: B
reward: 10500 | 630 | 46000
sets: gmc_truce_struck
summary: A pirate captain and a port councillor both want a truce and neither will walk first onto the other's end of a rope bridge.
objectives:
  talk npc_captain_hollis_crake
  talk npc_councillor_mabyn_sallow
  reach saltreach_rope_bridge_middle
  choice count_sing_or_cut
-->

---

## 3. Three Bidders Dead

*B · Investigation · the Drowned Mermaid · giver Auctioneer Dunstan Gavelle*

**The short version.** The map to the Sunken Fleet's flagship is up for auction at the Drowned Mermaid. Three earlier bidders went to look for the wreck and did not come back. Gavelle wants to know whether the map is cursed, so he can sell it honestly. He has not been entirely honest with himself.

**What is really going on.** The map is real. The margin, which Gavelle trimmed to make the parchment look cleaner, held a warning written in dive-code: *"Brood-water. Do not go below the second reef."* The bidders went below the second reef. The sea-hags and the Krakenmother's brood do the rest. It is not a curse. It is a missing margin.

**Scene 1: the auction house.**

**GAVELLE:** "A *remarkable* piece. A relic of the Sunken Fleet. Provenance certified. Condition, immaculate."
**GAVELLE:** "I've lost three bidders. It is *distressing.* It is also, I understand, very good for business."
**GAVELLE:** "I would like you to tell me there's no curse."
> ► **"Show me the map."** — **GAVELLE:** "With *gloves.*"
> ► **"How did they die?"** — **GAVELLE:** "At sea. Doing what they do."
> ► **"What if there is a curse?"** — **GAVELLE:** "Then we have an *attraction.*"

**Scene 2: the evidence.**
- **The map** has been trimmed on three sides; the cut edge is newer than the paper.
- **A dive-code mark** survives in the corner: the sign for *brood-water.*
- **The three bidders'** logbooks, held by the Mermaid's cloakroom, all end at the second reef.
- **The previous owner**, a drunken old diver, remembers the margin. He cut his own thumb on it.

**OLD DIVER (Wick Barnacle):** "It said *don't.* In black ink. In my own grandfather's hand."
**OLD DIVER:** "I told the man. He said it ruined the *composition.*"

**Scene 3: the confession.** The player confronts the auctioneer in his private office, with the map between them.

**GAVELLE:** "I did not *kill* them."
**GAVELLE:** "I trimmed a *margin.*"
> ► **"You trimmed their warning."** — **GAVELLE:** (a long silence) "...Yes."
> ► **"How many bidders now?"** — **GAVELLE:** "Seven. Fewer, after tonight."
> ► **"What will you do?"** — **GAVELLE:** "That is... a very good question."

**Scene 4: the sale.**

> ► **"Withdraw the map."** — Gavelle closes the sale and refunds every bid.
> ► **"Sell it, margin restored."** — The warning is sewn back and the map sold with an honest note.
> ► **"Post the warning on the auction door."** — A public notice, signed by Gavelle in his own hand.

**GAVELLE:** "I have sold wrecks for thirty years. This is the first time I have been ashamed of one."

**Outcomes and receipt.**
- The warning is restored in some form. The three dead are named at the sea-steps. Gavelle remains an auctioneer, less theatrical and more careful.
- **Receipt:** the restored margin stitched back onto the map, displayed in a glass case; three candles on the Drowned Mermaid's mantel for the dead bidders.

<!-- quest
id: qst_gmc_three_bidders
title: Three Bidders Dead
rank: B
type: Investigation
giver: npc_auctioneer_gavelle
region: reg_goldmere_coast
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: gmc_map_margin_restored
summary: A flagship map has killed three bidders, and its missing margin carried a warning the auctioneer cut away.
objectives:
  talk npc_auctioneer_gavelle
  reach drowned_mermaid_map_vault
  choice withdraw_restore_or_post
-->

---

## 4. Whose Boots Are These

*B · Hidden · the Sea-Steps · giver Tolly Sandwick*

**The short version.** Ten-year-old Tolly found a pair of sea-worn boots on the tide-line and has sat on them for three days. She knows the custom: a pair of boots with no owner must be walked home. She needs someone to tell her whose they are.

**What is really going on.** The boots are very old. The stitching and the toe-plate belong to a tannery that burned eighty years ago. They belonged to a sailor of the Sunken Fleet. Every year, the sea sends one pair of boots up to the Sea-Steps, a sailor walking home along the bottom as the old saying has it. This year the boots came late, and the whole port had stopped expecting them.

**Scene 1: the beach.**

**TOLLY:** "They're *mine.* I found them. But they're not *mine.* They're somebody's."
**TOLLY:** "My gran says you have to walk them home. But I don't know where home *is.*"
**TOLLY:** "Nobody's come to ask for them."
> ► **"Can I see?"** — **TOLLY:** "You can look. Don't touch."
> ► **"Who might know?"** — **TOLLY:** "Old Jessup does boots."
> ► **"We'll find out."** — **TOLLY:** "I'm coming too."

**Scene 2: the cobbler.** A narrow shop smelling of leather and wax. Old Jessup Lamb holds the boots up to the lamp, turning them slowly.

**JESSUP:** "Fleet boots. Eighty years if a day. The toe-plate's from Marrow & Daughters on Sail Lane. The old tannery."
**JESSUP:** "Left foot's been resoled. Whoever wore these was *careful.* Whoever wore these had a mother who made him oil them."
*Inside the left boot, scratched on the lining with a nail: a name, and a ship.*

**Scene 3: the name.** The fleet's muster-roll is kept in the port archive. The boy was seventeen, a ship's boy on a tender. He is on the list of the lost.

**ARCHIVIST:** "No grave. No descendants known. He is the only one of his family on the roll."
**TOLLY:** "So nobody's coming?"
> ► **"We are."** — **TOLLY:** "All right."
> ► **"The sea sent them."** — **TOLLY:** "She sends one a year. I read that."
> ► **"We should bury them."** — **TOLLY:** "At the steps. With a song."

**Scene 4: the walking.** At dusk, the boots are carried down the Sea-Steps, step by step, by Tolly and the player. Divers, sailors and tavern-keepers fall in behind, and a shanty rises without anyone starting it.

**TOLLY:** "He was *seventeen.* That's not even old."
**JESSUP:** "No, love. It isn't."

> ► **"Set them in the water."** — The tide takes them, slowly.
> ► **"Keep them at the steps."** — A small shrine, with a bowl for coins.
> ► **"Walk them to the end."** — Tolly carries them out along the reef, as far as the tide allows.

**Outcomes and receipt.**
- The boots are given back to the sea, or kept as a shrine. The old custom is revived with a new line: *"The sea sends one a year, and the port walks him home."*
- **Receipt:** a pair of stone boots set at the foot of the Sea-Steps; the boy's name, cut in the lowest step.

<!-- quest
id: qst_gmc_whose_boots
title: Whose Boots Are These
rank: B
type: Hidden
giver: npc_tolly_sandwick
region: reg_goldmere_coast
level: 98
act: 4
requires_rank: B
reward: 11500 | 690 | 50000
sets: gmc_boots_walked_home
summary: A child finds eighty-year-old boots on the tide-line and the custom says someone must walk them home.
objectives:
  talk npc_tolly_sandwick
  talk npc_cobbler_jessup_lamb
  reach port_goldmere_sea_steps
  choice water_shrine_or_reef
-->

---

## 5. The Parrot Who Kept the Books

*B · OddJob · the Drowned Mermaid · giver Hostess Perpetua Gull*

**The short version.** Perpetua's parrot, Admiral, has a perfect memory and no discretion. For thirty years it has been repeating, in a sweet voice, every word spoken at the inn. This week it has begun repeating the council's private accounts. The council would like it silenced. Perpetua would like it not to be eaten.

**What is really going on.** Admiral overheard two salvage captains cooking the port's books to hide how badly the Krakenmother has dented the income. The figures are real. The real income is half what the council has announced. The parrot has been reciting the true figures to anyone who buys a drink.

**Scene 1: the taproom.**

**PERPETUA:** "He's a *good* bird. He just says things."
**ADMIRAL:** "*Ninety thousand short! Ninety thousand short! Don't tell the Speaker!*"
**PERPETUA:** "He's been doing that since Tuesday."
> ► **"Where did he learn that?"** — **PERPETUA:** "From my back room. Where the council *meets.*"
> ► **"Is it true?"** — **PERPETUA:** "I would not like to say. I would like to *sell rum.*"
> ► **"What do you need?"** — **PERPETUA:** "To keep my parrot, and my licence."

**Scene 2: the council.** Two furious captains in the back room.

**CAPTAIN (Barnaby Stoat):** "We want that bird *quiet.*"
**CAPTAIN (Hesper Kell):** "We want it *gone.*"
**ADMIRAL (from the window):** "*Gone! Gone! Don't tell the Speaker!*"
> ► **"Teach it a new song."** — A long, comic afternoon of shanty rehearsal.
> ► **"Take the bird away for a while."** — A quiet boarding at a friend's farm.
> ► **"Let the council face it."** — Tell the truth about the figures and let the bird off.

**Scene 3: the afternoon.** With a bag of nuts and a lot of patience, the player tries to retrain the bird. It is not easy.

**ADMIRAL:** "*The Speaker's gone to the privy! Ninety thousand short!*"
**PERPETUA:** "That one was *new.*"

**Scene 4: the open hall.** At the next council, the figures are read out in full, by Admiral, from a perch on the Speaker's chair, to a hall that has been listening for weeks.

**SPEAKER SLATE:** "I... thank the bird."
**ADMIRAL:** "*Thank you! Thank you! Don't tell the Speaker!*"

**Outcomes and receipt.**
- The true accounts are published, and the council begins to budget honestly. If the player took the bird away, the figures come out later and angrier. If the player taught it a new song, the bird becomes the inn's official shanty-leader.
- **Receipt:** a brass perch in Salvage Hall engraved *"Admiral, auditor";* a new column in the port ledger, headed *"What we actually have."*

<!-- quest
id: qst_gmc_parrot_books
title: The Parrot Who Kept the Books
rank: B
type: OddJob
giver: npc_perpetua_gull
region: reg_goldmere_coast
level: 101
act: 4
requires_rank: B
reward: 12000 | 710 | 52000
sets: gmc_parrot_figures_aired
summary: A parrot has been reciting the council's true accounts, which show the port's income is half what has been announced.
objectives:
  talk npc_perpetua_gull
  reach drowned_mermaid_back_room
  choice song_boarding_or_truth
-->

---

## 6. The Bridges of Saltreach

*B · Defense · the outer reef · giver Rope-Captain Duvessa Pike*

**The short version.** Sea-hags and the Krakenmother's brood have begun hitting the stilt-town of Saltreach at night. The rope bridges are the town's only way off the reef. Duvessa has to keep them standing while the town moves its children to the port.

**What is really going on.** The raiders are not trying to kill the villagers. They are cutting the ropes: the bridges are the only things holding the stilt-towns together, and the Krakenmother has noticed that a town without bridges is a town of islands. Every rope held is a family saved; every rope cut is a house cut off.

**Scene 1: the bridge-house.**

**DUVESSA:** "I've kept these bridges forty years. Not one body off one. I don't mean to start."
**DUVESSA:** "There are sixty children on the reef tonight. The port will take them. But they have to *cross.*"
**DUVESSA:** "I have two hands. One's a hook."
> ► **"What do you need?"** — **DUVESSA:** "Four of you. On the rails."
> ► **"What's coming?"** — **DUVESSA:** "Hags, I think. They climb."
> ► **"Where do we hold?"** — **DUVESSA:** "The middle span. It's the longest."

**Scene 2: the night.** The moon is a thin sliver. The bridge sways under lanterns. A long line of children, wrapped in blankets, files out across it.

**CHILD:** "It's *wobbling.*"
**DUVESSA:** "It's supposed to, love. It's how it *stays up.*"
*Far below, the water ripples. Dark shapes break the surface, climbing pilings.*

> ► **"Hold the rail."** — A fierce, sweaty fight on the planks.
> ► **"Light the underside."** — Flare-pots strung beneath the span; the hags flinch from the glare.
> ► **"Cut the far span and ferry them."** — A bold, risky pivot to the boats.

**Scene 3: the crossing.** The last of the children are halfway across when a rope parts with a crack like a whip.

**DUVESSA:** "Splice! *Now!*"
*The player and the rope-captain race along the span, with a hook and a knife, tying knots faster than the sea can cut.*

**Scene 4: the dawn.** The last child reaches the port. The bridge still stands.

**DUVESSA:** "Sixty-two. I counted two extra. Don't tell the port."

**Outcomes and receipt.**
- The bridges hold and the children are safe. The method the player chose decides whether the span survives or is replaced by ferries. Saltreach is not saved, but it is not drowned.
- **Receipt:** a knotted rope hung on the bridge-house door for every child; a new, stronger span with a lantern at every post.

<!-- quest
id: qst_gmc_bridges_saltreach
title: The Bridges of Saltreach
rank: B
type: Defense
giver: npc_duvessa_pike
region: reg_goldmere_coast
level: 105
act: 4
requires_rank: B
requires_quests: qst_gmc_neutral_ground
reward: 13000 | 760 | 56000
sets: gmc_saltreach_bridges_held
summary: Raiders cut the rope-ways of a stilt-town while its children are moved to the port.
objectives:
  talk npc_duvessa_pike
  defend saltreach_middle_span
  choice rail_lights_or_ferry
-->

---

## 7. The Flagship's Bell

*A · Exploration · the Sunken Fleet · giver Diver-Master Ossian Haldane*

**The short version.** Ossian has dived the Sunken Fleet for forty years. He swears the flagship's bell has been rung every night since the fleet sank, though the ship lies at forty fathoms. He has never found who rings it. He asks the player to dive with him one last time.

**What is really going on.** The bell is rung by a loose clapper, pulled by the tide against the flagship's rudder-chain. The answer is plain. The ship itself is not. Its cargo hold is unaccountably dry, and the log on the captain's desk is legible after two hundred years. The bell is only the first of several small wrongnesses the wreck keeps.

**Scene 1: the dive-house.**

**OSSIAN:** "Forty years. I've heard it every night I slept near the water. One stroke. Then three. Then one."
**OSSIAN:** "The old divers say it's a ghost. I say it's a clapper. But I want to *see.*"
**OSSIAN:** "I'm sixty-eight. I don't have many more descents."
> ► **"I'll dive with you."** — **OSSIAN:** "Good. Drop your coin first."
> ► **"What do you expect?"** — **OSSIAN:** "A clapper. And an old man being foolish."
> ► **"What's below?"** — **OSSIAN:** "The fleet. And a very large dark."

**Scene 2: the descent.** The player drops a coin into the sea, and descends. Cold water. Drifting wrecks like drowned cathedrals. In the green gloom, the flagship, a vast hull furred with coral.

**OSSIAN (via signal-line):** "There. The stern. See the chain?"
*A bell, big as a barrel, hangs in its cradle. As a swell passes, the clapper lifts, strikes once, twice. A third, softer stroke.*

**Scene 3: the great cabin.** The flagship's admiral-cabin is dry, lit by dim, drifting lanterns of unnamed jellyfish. On the desk, a log.

**OSSIAN (hushed):** "It's *legible.*"
*The final entry reads: "The sea has asked for its share. We have none to give. Ring the bell until morning."*

> ► **"Read it aloud."** — Ossian's voice trembles; he does not finish.
> ► **"Copy it."** — A careful job, in a dry-tight case.
> ► **"Leave it undisturbed."** — The log stays where it lies.

**Scene 4: the bell.** On the way up, Ossian stops at the bell, takes the clapper in his hand, and for the first time in forty years rings it himself: one stroke, then three, then one.

**OSSIAN:** "I wanted to know who was ringing it."
**OSSIAN:** "It was always going to be *someone who stayed.*"

**Outcomes and receipt.**
- The mystery of the bell is solved; the greater mystery of the dry cabin is left open. The log's last line is taken ashore, or left in its place, as the player chooses. Nothing in the wreck answers who "the sea" asked, or what the share was.
- **Receipt:** a copy of the last log entry mounted at the Sea-Steps; a brass bell of the same weight hung in the dive-house, rung each dusk in the old pattern.

<!-- quest
id: qst_gmc_flagship_bell
title: The Flagship's Bell
rank: A
type: Exploration
giver: npc_ossian_haldane
region: reg_goldmere_coast
level: 122
act: 4
requires_rank: A
requires_quests: qst_gmc_three_bidders
reward: 28000 | 1500 | 125000
sets: gmc_flagship_bell_found
summary: A diver-master swears the flagship's bell has rung every night since the Sunken Fleet went down, and the wreck hides a dry cabin and a legible log.
objectives:
  talk npc_ossian_haldane
  reach sunken_fleet_flagship_stern
  choice read_copy_or_leave
-->

---

## 8. The Channel Moves

*A · Escort · the safe channel · giver Pilot Marguerite Calloway*

**The short version.** The safe channel into Port Goldmere shifts a little with every storm. This dawn it shifted a long way. Marguerite has a grain convoy of nine ships waiting, and a channel that no longer matches her chart. She asks the player to guide the convoy through while she re-sounds it.

**What is really going on.** The Krakenmother's brood has been dragging the sandbars. The channel is not wider or narrower: it is *crooked,* bending to bring ships close to the reef where the brood waits. The grain is the port's winter. A cautious convoy loses a day and a ship; a bold one loses a ship in a different place.

**Scene 1: the pilot-house.**

**MARGUERITE:** "I redraw it every dawn. It matched yesterday. It doesn't match *today.*"
**MARGUERITE:** "The bottom's been *moved.* Sandbars don't move on their own."
**MARGUERITE:** "I have nine grain-ships and about four hours of tide."
> ► **"Can you sound it?"** — **MARGUERITE:** "With a lead-line. By hand. In the dark."
> ► **"What moved it?"** — **MARGUERITE:** "I have a theory. I don't like it."
> ► **"I'll guide them."** — **MARGUERITE:** "Take the bow-boat. Keep your lantern high."

**Scene 2: the first reach.** The lead-boat edges forward, the player at the bow with a sounding line. The convoy follows in a ragged, anxious line.

**MARGUERITE (calling):** "Six fathoms! Five! *Four!* Turn to port!"
*A dark shape slides beneath the keel, vast and oily, and is gone.*

**Scene 3: the choice.** Three routes, none of them safe.

> ► **"The old channel, widened."** — A long, careful detour, with a sandbar to cross.
> ► **"The reef-edge shortcut."** — A fast, dangerous path along the brood's own water.
> ► **"Split the convoy."** — Three small groups on three routes, with no spare pilot.

**CAPTAIN (of the *Honest Mary*):** "I don't like the water! It's the wrong *colour!*"
**MARGUERITE:** "It's the *right* colour. For where we're going."

**Scene 4: the harbour.** The last grain-ship crosses the bar in a long, tilting, gold-lit dusk, scraping the keel on sand. Behind it, a dark ripple slides into the deep and is gone.

**MARGUERITE:** "Nine of nine."
**MARGUERITE:** "I want it noted that I was *very frightened.*"

**Outcomes and receipt.**
- The convoy arrives; the grain feeds the port for the winter. The route decides the loss: none, one hull or three damaged. Marguerite redraws the channel, and starts doing it twice a day.
- **Receipt:** a new channel chart pinned in the pilot-house, marked in red where the bottom moved; nine grain-sacks stacked at the Salvage Hall door.

<!-- quest
id: qst_gmc_channel_moves
title: The Channel Moves
rank: A
type: Escort
giver: npc_marguerite_calloway
region: reg_goldmere_coast
level: 128
act: 4
requires_rank: A
requires_quests: qst_gmc_bridges_saltreach
reward: 30000 | 1560 | 132000
sets: gmc_grain_convoy_arrived
summary: The brood has crooked the safe channel, and nine grain-ships need a guide through shifting water.
objectives:
  talk npc_marguerite_calloway
  escort npc_marguerite_calloway
  reach port_goldmere_safe_channel_bar
  choice widen_shortcut_or_split
-->

---

## 9. A Tribute Proposed

*A · Faction · Salvage Hall · giver Salvage-Speaker Evander Slate*

**The short version.** Captain Stroud has stood up in the salvage council and proposed that the port pay the Krakenmother a tribute: one cargo in ten, laid in the deep each tide, in exchange for peace. The vote is tied. The Speaker has never been asked such a question before and wants an outsider to take testimony.

**What is really going on.** Stroud's proposal is sincere. She has lost four ships and a brother. Opposing her are the stilt-town captains, who say a monster fed once will want feeding forever. Neither side is a fool. The tribute might buy a month, or a decade, or a different kind of war. Nobody knows what the Krakenmother would take, or what she would do with it.

**Scene 1: the Hall.**

**SLATE:** "Eleven years in this chair. I've settled boundary disputes, wreck claims, a duel over a *goat.*"
**SLATE:** "I have never been asked whether to pay a monster."
**SLATE:** "I would like testimony. From someone who isn't afraid, or who isn't *admitting* it."
> ► **"What's the proposal?"** — **SLATE:** "One in ten. Laid in the deep."
> ► **"Who supports it?"** — **SLATE:** "The ones who've lost the most."
> ► **"I'll take testimony."** — **SLATE:** "Thank you. I'll find chairs."

**Scene 2: the testimony.** Stroud speaks first, hard-faced and even.

**STROUD:** "I've lost four ships. A brother. A husband's grave. I'd have paid anything to keep them."
**STROUD:** "It isn't surrender. It's *rent.*"
*A stilt-town captain, grey with weather, stands to answer.*
**CAPTAIN (Odalia Fenn):** "And in a year she'll want one in *five.* They always do."

**Scene 3: the questions.** The player asks the Hall three things.

> ► **"What does she take now?"** — Ships, mostly, and the cargo with them. Not the crews, if they row fast.
> ► **"Has anyone ever tried to bargain?"** — A long, uneasy silence. A diver says, quietly, that one has.
> ► **"What do the divers say?"** — A slow chorus: the sea has a share, and has always had one.

**Scene 4: the vote.** The tie breaks according to the player's testimony.

> ► **"Test a small offering first."** — A single sealed chest, laid in the deep at night under watch.
> ► **"Refuse, and spend the gold on defences."** — Stroud sits down, jaw tight.
> ► **"Offer something that isn't gold."** — A shanty, a boot, a lantern, laid at the Sea-Steps.

**STROUD:** "If I'm wrong, I'll say so."
**SLATE:** "Noted."

**Outcomes and receipt.**
- The vote is cast. What the Krakenmother makes of any of it is left for the tide. The port has chosen how it faces her, in the open, with its eyes open.
- **Receipt:** the vote tally nailed to the Hall door with each captain's name; a sealed chest, a bare sea-step or a row of lanterns at the water's edge, depending on the choice.

<!-- quest
id: qst_gmc_tribute_proposed
title: A Tribute Proposed
rank: A
type: Faction
giver: npc_salvage_speaker_slate
region: reg_goldmere_coast
level: 134
act: 4
requires_rank: A
requires_quests: qst_gmc_neutral_ground
reward: 32000 | 1620 | 138000
sets: gmc_tribute_decided
summary: A salvage captain proposes paying the Krakenmother one cargo in ten, and the council's vote is tied.
objectives:
  talk npc_salvage_speaker_slate
  talk npc_captain_wilhelmina_stroud
  choice test_refuse_or_nongold
-->

---

## 10. The Sea's Coins

*A · Investigation · the Dive-Houses · giver Dive-Mother Ketura Maine*

**The short version.** Every diver drops a coin into the sea before every descent. For weeks, someone has been taking the coins from the shallows at night. Ketura wants the thief found before the young divers lose faith in the custom.

**What is really going on.** The thief is a pack of reef-orphans, six children aged six to twelve, who have been living in a wrecked hull since the Krakenmother took their parents' ship. They are collecting the coins to buy food. They are not stealing from the sea; they believe the sea is feeding them, which, in a way, it is. But something larger has been watching the coin-shallows too.

**Scene 1: the dive-house.**

**KETURA:** "Three hundred children. Every one taught to drop a coin. Every one *does.*"
**KETURA:** "Last week I dropped mine and watched it fall. In the morning, it was gone."
**KETURA:** "I would like to know who is taking from the sea."
> ► **"Who would?"** — **KETURA:** "A thief. Or a hungry child. They're hard to tell apart."
> ► **"What do the divers say?"** — **KETURA:** "That the sea has stopped accepting."
> ► **"I'll watch."** — **KETURA:** "Bring a lantern. And a blanket."

**Scene 2: the night watch.** On the coin-shallows, under a pale moon, the player waits. Small bare feet pad across the sand. A thin, quick shadow bends and straightens.

**CHILD (a girl, Dab):** "Don't tell. *Please.* We need them."
*Behind her, five more small figures, huddled, wide-eyed.*

> ► **"Why do you take them?"** — **DAB:** "Because they're *there.*"
> ► **"Where are you living?"** — **DAB:** "The *Brine Maiden.* She's a wreck. She's warm."
> ► **"I won't tell."** — **DAB:** "Promise?"

**Scene 3: the hulk.** A half-sunk hull in the shallows, hung with sailcloth and fishing-line. Six sleeping-nooks, six tin cups and a pot of weed-soup.

**DAB:** "The sea sends us coins. She *does.* We never asked for more than we need."
*As the player listens, the water at the hull's far side ripples. A huge, dark shape lies in the shallows, still as a stone, and watches the children.*

> ► **"Lead the children away at once."** — A quiet retreat, cup by cup.
> ► **"Stay and guard them."** — A tense, patient night in the hulk.
> ► **"Speak to the shape."** — The player addresses the dark. It does not answer. After a long time, it sinks.

**Scene 4: the dive-house.** In the morning, the six are brought before the dive-mother. She looks at them for a long time.

**KETURA:** "I taught three hundred children to give to the sea. I never taught one how to *take.*"

> ► **"Let them stay at the dive-houses."** — Six new beds, and six new apprentices.
> ► **"Find them a family."** — A slower, kinder placement.
> ► **"Leave the custom as it is."** — Ketura will tell the old divers the sea is merciful.

**Outcomes and receipt.**
- The coin-thief is found and the children are cared for. The custom is changed or not, according to the player's word. The dark shape in the shallows is never explained.
- **Receipt:** a second coin-bowl by the Sea-Steps, marked *"for the hungry";* six small hammocks in the dive-houses, with names stitched on.

<!-- quest
id: qst_gmc_sea_coins
title: The Sea's Coins
rank: A
type: Investigation
giver: npc_ketura_maine
region: reg_goldmere_coast
level: 140
act: 4
requires_rank: A
requires_quests: qst_gmc_whose_boots
reward: 34000 | 1680 | 146000
sets: gmc_sea_coins_solved
summary: Someone has been taking the coins divers drop for the sea, and the thieves are hungry children watched by something very large.
objectives:
  talk npc_ketura_maine
  reach brine_maiden_hulk
  choice lead_guard_or_speak
-->
