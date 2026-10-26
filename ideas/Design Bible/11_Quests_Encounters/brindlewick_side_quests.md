# 11d — Brindlewick Side Quests (draft)

> *"Nobody comes to Brindlewick for the quests. They stay for the stew."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. These **36 quests** carry the NPC arcs in [[Design Bible/07_Characters/brindlewick_storylines|`07_Characters/brindlewick_storylines.md`]]. Their data is in `Data/Quests/quests.json` (checked by `npm run validate`), their flags in `Data/Quests/story_flags.json`, and three new supporting NPCs (Sister Ivy Thorne, Inquisitor Halvane, Archivist Orrow) in `Data/NPCs/npcs.json`. Nothing here changes a locked Canon row; the additions are listed in Canon §6 ("Brindlewick storylines and side quests").

⚠️ **Spoilers:** several quests plant clues for the Caspian and Nocturne reveals.

## 1. How these quests are built

They follow [[Design Bible/11_Quests_Encounters/quest_outcome_grammar|`quest_outcome_grammar.md`]]: one **offer**, two or three **approaches**, a small **outcome record** and a visible **receipt**. In the data, branches are `choice` objectives (the outcome is stored as a runtime outcome record, not as separate quest rows).

| Rule | What it means here |
|---|---|
| **Small first** | Most quests take 10–25 minutes. The big ones (*Joren's Last Contract*, *The Cookbook Question*) take 30–45 |
| **Alternate routes** | None of these quests gates the main story. Skipping one closes only its receipt |
| **A receipt each** | Every quest ends in something you can *see*: a lit lantern, a new chair, a notice, a changed song |
| **No real-time pressure** | No quest expires on a wall clock; time pressure is in-game days only (Canon: in-game-time continuity) |
| **Signposted loss** | Deaths and permanent losses are always offered as a clear choice with the cost stated before the player commits |
| **Named monsters stay impersonal** | Scarjaw is a danger the region has; he is never "the one who beat you" (Canon §4d) |
| **Hard to miss, easy to skip** | Quest-givers are visible in the town's daily rhythm; a quest in the board's margin is never required |

## 2. The index

| Quest | Rank | Type | Giver | Act | Arc |
|---|---|---|---|---|---|
| Boxing Barn | F | OddJob | Sister Pell | 1 | Pell and Ivy |
| Candles for the Hall | F | Delivery | Widow Aster | 1 | Aster and Corwin |
| Junior Receptionist Day | F | OddJob | Tamsin Orphan | 1 | The Orphans |
| Payday at the Griffon | F | OddJob | Marta Gruel | 1 | Marta and Teo |
| The Overdue Books | F | OddJob | Eolande Fairweather | 1 | Eolande |
| The Sound of Rank | F | OddJob | Fiddler Corwin | 1 | Aster and Corwin |
| Yesterday's Bread | F | OddJob | Hugo Brand | 1 | The Orphans |
| A Story for a Scale | E | OddJob | Old Sal | 1 | Small stories |
| Bo's Moon Drawings | E | Investigation | Bo Orphan | 1 | The Orphans |
| Joren's Last Contract | E | Exploration | Widow Aster | 1 | Aster and Corwin |
| Lantern Night in Brindlewick | E | OddJob | Widow Aster | 1 | Aster and Corwin |
| Notes in the Margins | E | Investigation | Eolande Fairweather | 1 | Eolande |
| The Buried Sword | E | Hidden | Old Hollis | 1 | Hollis |
| The Name of the Blade | E | OddJob | Brannoc Emberfist | 1 | Small stories |
| The Stable Boy's Broom | E | OddJob | Teo Gruel | 1 | Marta and Teo |
| Brindlewick's Got Talent | E | OddJob | Rosie Quill | 2 | Rosie and Nobody |
| Six Years at D | E | OddJob | Brutus Kale | 2 | Brutus |
| The Boy on the North Road | E | Escort | Marta Gruel | 2 | Marta and Teo |
| The Fog Merchant's Coin | E | OddJob | Traveling Merchant Pell | 2 | Small stories |
| The Inquisitor at the Shrine | E | Faction | Sister Pell | 2 | Pell and Ivy |
| The North Road Ledger | E | Investigation | Guild Clerk Wendel | 2 | Holt, Tomlin and Pike |
| The Sack We Don't Open | E | Exploration | Farmer Hesk | 2 | Hollis |
| The Wolves' Second Race | E | Bounty | Dax Rowan | 2 | The Crimson Wolves |
| Tomlin Tries Again | E | OddJob | Guard Tomlin | 2 | Holt, Tomlin and Pike |
| A Home Soon | D | Investigation | Lark Orphan | 2 | The Orphans |
| The Quiet Pharmacy | D | Faction | Fennick Reed | 2 | Pell and Ivy |
| The Reading Room Audit | D | Faction | Eolande Fairweather | 2 | Eolande |
| The Tune Under the Hymn | D | Investigation | Fiddler Corwin | 2 | Aster and Corwin |
| Every Bed in the Griffon | D | Faction | Marta Gruel | 3 | Marta and Teo |
| The Count at the Gate | D | Defense | Captain Holt | 3 | Holt, Tomlin and Pike |
| The Fifth Attempt | D | OddJob | Brutus Kale | 3 | Brutus |
| A Letter in a Familiar Hand | C | Investigation | Sister Pell | 3 | Pell and Ivy |
| Edric's Sword | C | OddJob | Marta Gruel | 3 | Marta and Teo |
| Left-Handed Forms | C | Investigation | Guild Clerk Wendel | 3 | Wendel |
| Rosie's Second Verse | C | Investigation | Rosie Quill | 3 | Rosie and Nobody |
| The Cookbook Question | C | Investigation | Eolande Fairweather | 3 | Eolande |


Rank and level follow the existing Ring 1 pattern (F: levels 1–6, E: 8–12; D and C quests are **revisits** that appear when the player returns to Brindlewick at higher rank). Reward numbers are **first-pass tuning**, copied from the nearest existing quest of the same rank; hand them to `systems-designer` before Ring 2.

**Suggested ring placement:**

| Ring | Quests |
|---|---|
| **Ring 1 (Act I, F–E)** | Payday at the Griffon, The Stable Boy's Broom, Candles for the Hall, The Sound of Rank, Joren's Last Contract, Lantern Night in Brindlewick, Boxing Barn, The Overdue Books, Notes in the Margins, Six Years at D, The Buried Sword, Junior Receptionist Day, Bo's Moon Drawings, Yesterday's Bread, A Story for a Scale, The Name of the Blade |
| **Ring 1 (Act II, E)** | The Boy on the North Road, The North Road Ledger, Tomlin Tries Again, The Inquisitor at the Shrine, The Sack We Don't Open, Brindlewick's Got Talent, The Wolves' Second Race, The Fog Merchant's Coin |
| **Ring 2+ (D, C: revisits)** | Every Bed in the Griffon, Edric's Sword, The Count at the Gate, The Tune Under the Hymn, The Quiet Pharmacy, A Letter in a Familiar Hand, The Reading Room Audit, The Cookbook Question, The Fifth Attempt, Rosie's Second Verse, Left-Handed Forms, A Home Soon |

## 3. The quests

### Marta and Teo

#### Payday at the Griffon

`qst_odd_payday_at_the_griffon` · **F** OddJob · giver *Marta Gruel* · Lv 3+ · region `reg_aldmere`

> Payday means drinking, and drinking means fists. Marta needs someone sober by the door.

- **When:** First payday evening after registration; the common room is full.
- **Gate:** Act 1+; quests `qst_main_bowl_of_stew`
- **Approaches:**
  - **Talk it down:** a Rank-F persuasion check against three regulars; Rosie's song can help.
  - **Hands:** pull the worst offender outside; Brutus Kale watches and remembers.
  - **Mug and song:** leave the brawl to burn itself out and clear the tables; slower, safer.
- **Outcomes:**
  - Any method keeps the room. The method changes who owes you a favour (Rosie, Brutus, nobody).
  - After closing Marta leaves her ledger open. One page has a line of red ink across it and the word *paid*.
- **Receipt:** Marta calls you by name instead of "rookie". The ledger is visible on the bar shelf from now on.
- **Reward:** 70 g · 8 GP · 180 XP + itm_minor_hp_potion · sets `marta_ledger_seen`

#### The Stable Boy's Broom

`qst_odd_stable_boys_broom` · **E** OddJob · giver *Teo Gruel* · Lv 8+ · region `reg_aldmere`

> Teo has been sneaking out at night. He asks you to come and say nothing.

- **When:** After *Payday*; night, Hollis's Yard.
- **Gate:** Act 1+; quests `qst_odd_payday_at_the_griffon`
- **Approaches:**
  - **Tell Marta:** she is hurt, then furious at Hollis, then quiet.
  - **Keep the secret:** Teo trusts you; Hollis does not.
  - **Broker a bargain:** Teo trains by day and does not pass the north gate until he is sixteen; Hollis swears it in front of both.
- **Outcomes:**
  - *Tell:* Marta locks the stable gate for a week, then unlocks it. *Secret:* a hidden-training flag that colours *The Boy on the North Road*. *Bargain:* the best outcome, and the only one that makes Marta laugh.
- **Receipt:** Teo trains in daylight in two of the three branches; the Griffon's stable broom is replaced by a wooden sword.
- **Reward:** 150 g · 12 GP · 500 XP · sets `teo_broom_resolved`

#### The Boy on the North Road

`qst_esc_boy_on_north_road` · **E** Escort · giver *Marta Gruel* · Lv 10+ · region `reg_whisperwood`

> Teo has followed a party north to "help". Marta asks you to bring him home, and not to shame him.

- **When:** After the Goblin Chief's death; Teo is gone by morning.
- **Gate:** Act 2+; flags `teo_broom_resolved`, `tyrant_slain_reg_whisperwood`
- **Approaches:**
  - **Bring him home:** an easy escort with a hard conversation.
  - **Let him prove it:** he fights one small wolf under your watch; success is earned, not given.
  - **Ask Holt:** the gate log shows who saw him leave; faster, and Holt owes Marta a quiet word.
- **Outcomes:**
  - Teo returns in all branches; the line he says on the way home changes. Marta never asks what happened, and the Griffon's door stays open at night.
- **Receipt:** Holt's gate log shows Teo's name; Marta stops locking the stable.
- **Reward:** 180 g · 14 GP · 600 XP · sets `teo_north_road_resolved`

#### Every Bed in the Griffon

`qst_fac_every_bed_in_the_griffon` · **D** Faction · giver *Marta Gruel* · Lv 38+ · region `reg_aldmere`

> Marrowgate is gone and the refugees have nowhere to go. Marta has forty beds and sixty people.

- **When:** Immediately after Marrowgate falls.
- **Gate:** rank D+; Act 3+; flags `marrowgate_fell`
- **Approaches:**
  - **Supply run:** herbs, blankets and broth from Fennick, Ines and Hugo.
  - **Triage:** decide who sleeps inside (the injured, the old, the children, the guild-sworn).
  - **Mind the room:** keep tempers cool when a Marrowgate survivor recognises you.
- **Outcomes:**
  - No branch turns anyone away; the choices change who sleeps where and who thanks you by name later. A named Marrowgate child is placed with a family in town, and returns in Act V.
- **Receipt:** Cots in the common room, a pot on all night, Whiskers asleep on a refugee child. The board gains a "Refugee aid" notice.
- **Reward:** 1300 g · 80 GP · 5500 XP + itm_minor_hp_potion · sets `griffon_shelters_refugees`

#### Edric's Sword

`qst_odd_edrics_sword` · **C** OddJob · giver *Marta Gruel* · Lv 62+ · region `reg_aldmere`

> Marta takes her husband's sword off the wall and asks you to carry it to Brannoc.

- **When:** Act III onward, after C-Rank.
- **Gate:** rank C+; Act 3+
- **Approaches:**
  - **Reforge:** Brannoc asks the sword's name; Marta has never told anyone. You find it at the cairn where Edric held the pass.
  - **Ask Holt:** he is the rookie Edric saved. He has never told her.
  - **Give it to Teo or Marta:** either is accepted, each with its own scene.
- **Outcomes:**
  - The sword is reforged either way. Holt tells Marta; the Morrowsday dinner that follows is the only scene in the arc without a joke.
  - In the empty bracket over the bar Marta hangs the ledger.
- **Receipt:** The sword leaves the wall; Holt eats at the Griffon on Morrowsday; the ledger gains a page that opens before a debt exists.
- **Reward:** 3600 g · 200 GP · 13000 XP · sets `edrics_sword_resolved`

### Holt, Tomlin and Pike

#### The North Road Ledger

`qst_inv_north_road_ledger` · **E** Investigation · giver *Guild Clerk Wendel* · Lv 10+ · region `reg_aldmere`

> Wendel has found a line in the town accounts that matches no road. He asks you to look, because he cannot.

- **When:** Act II; the first week after E-Rank.
- **Gate:** Act 2+; flags `rank_e_reached`
- **Approaches:**
  - **Expose** to the council: the town loses its patrol and gains honesty.
  - **Help him pay:** the patrol stays and Pike owes you.
  - **Replace the patrol with locals:** Tomlin and three rookie volunteers become the road watch.
- **Outcomes:**
  - The mercenaries leave when Vesper swells in all three branches. What differs is who is on the road after they go.
  - Pike's nerves ease or worsen. In the *help* branch he gives you a key to the town stores.
- **Receipt:** The north road has a new patrol, or none, and a notice at the gate.
- **Reward:** 240 g · 18 GP · 800 XP + itm_copper_compass · sets `pike_road_payments_known`

#### Tomlin Tries Again

`qst_odd_tomlin_tries_again` · **E** OddJob · giver *Guard Tomlin* · Lv 8+ · region `reg_aldmere`

> Tomlin failed the registration appraisal on one question. He asks you to help him answer it.

- **When:** Act II; a quiet afternoon at the north gate.
- **Gate:** Act 2+; flags `rank_e_reached`
- **Approaches:**
  - **Coach him:** the question is *Why do you want to fight?* Tomlin has never wanted to; he wants to guard.
  - **Ask Wendel for the form:** the oath has a second clause for wardens.
  - **Stand with him:** you are in the room, and say nothing.
- **Outcomes:**
  - Tomlin passes the appraisal as a **Warden**, a guard-class registration the clerks had forgotten they offered. He keeps the card under his tabard.
- **Receipt:** Tomlin wears an oak card under his tabard, and waves rookies through the gate with his hand over his heart.
- **Reward:** 160 g · 12 GP · 450 XP · sets `tomlin_registration_resolved`

#### The Count at the Gate

`qst_def_count_at_the_gate` · **D** Defense · giver *Captain Holt* · Lv 40+ · region `reg_aldmere`

> A surge of undead walks the north road. Holt needs another set of eyes on the gate, and an honest count at dawn.

- **When:** Act III; a night with the road open.
- **Gate:** rank D+; Act 3+
- **Approaches:**
  - **Hold the gate:** stand with Tomlin on the wall.
  - **Cut them down on the road:** go out with the rookies and hold the line.
  - **Count them home:** your party carries the wounded back; Holt pins one stone per rookie.
- **Outcomes:**
  - Everyone comes back in the *count* branch, and Holt says so out loud, once. In the others, the stones differ and the board is repaired the next morning.
- **Receipt:** The tally board is rebuilt in stone; the number of white stones matches the number of names.
- **Reward:** 1400 g · 90 GP · 6000 XP · sets `holt_count_resolved`

### Aster and Corwin

#### Candles for the Hall

`qst_deliv_candles_for_the_hall` · **F** Delivery · giver *Widow Aster* · Lv 2+ · region `reg_aldmere`

> The guild hall's candles are low. Aster asks you to carry a bundle to Wendel, and to stay for tea.

- **When:** Any day after registration.
- **Gate:** Act 1+; flags `guild_registered`
- **Approaches:**
  - **Carry and stay:** hear Joren's name for the first time.
  - **Carry and leave:** the tea waits, and Aster says nothing.
- **Outcomes:**
  - The quest opens *Joren's Last Contract* in the first branch. Both branches are fine; the second just closes the door a little.
- **Receipt:** The Hall of Cards gains a row of Aster's candles.
- **Reward:** 40 g · 6 GP · 110 XP + itm_healing_herb · sets `aster_candles_delivered`

#### The Sound of Rank

`qst_odd_sound_of_rank` · **F** OddJob · giver *Fiddler Corwin* · Lv 1+ · region `reg_aldmere`

> The blind fiddler claims he can tell your rank by the sound of your steps. He asks you to prove him wrong.

- **When:** Any day, in Guild Square.
- **Gate:** Act 1+; flags `guild_registered`
- **Approaches:**
  - **Walk, run, sneak:** he is right every time. He tells you what the step sounds like.
- **Outcomes:**
  - Corwin gives a short tune for your rank. When you rank up, he plays a new one (a *receipt* per rank). In Act III he says *"You step like someone carrying a promise."*
- **Receipt:** A tune in the square changes whenever your rank does.
- **Reward:** 30 g · 6 GP · 100 XP · sets `corwin_rank_ear_met`

#### Joren's Last Contract

`qst_exp_joren_last_contract` · **E** Exploration · giver *Widow Aster* · Lv 9+ · region `reg_whisperwood`

> Joren was gathering moon-moss for his mother's wicks when he died. Aster asks you to finish the contract.

- **When:** After Aster's first tea; the camp is on the edge of the Named hobgoblin Scarjaw's range.
- **Gate:** Act 1+; flags `aster_candles_delivered`, `rank_e_reached`
- **Approaches:**
  - **Sneak** past the lair and return by dusk.
  - **Lure:** Scarjaw's range overlaps a wolf pack; the ecology can be your tool.
  - **Fight:** only when ready. The quest never requires it; Scarjaw is a D+ rare spawn.
  - **Come back later:** the contract waits, and Aster knows.
- **Outcomes:**
  - The player returns with Joren's pack, his card and the moss. Aster does not cry; she plants the moss in a pot on her sill.
  - She lights the lantern for Joren once, in the Hall of Cards, and stops lighting it daily. Scarjaw is never *Joren's killer* in dialogue; he is a danger the region has.
- **Receipt:** Joren's card is moved from a shelf to a wall; the north road gains a line of lanterns.
- **Reward:** 230 g · 18 GP · 750 XP + itm_healing_herb · sets `joren_contract_resolved`

#### Lantern Night in Brindlewick

`qst_odd_lantern_night_brindlewick` · **E** OddJob · giver *Widow Aster* · Lv 9+ · region `reg_aldmere`

> Every autumn the town lights a lantern for each name in the Hall of Cards. Aster shows you how to make one.

- **When:** Autumn only, repeating each year; a new line each time.
- **Gate:** Act 1+; flags `aster_candles_delivered`
- **Approaches:**
  - **Light for someone you lost:** the player writes a name (or leaves it blank).
  - **Light for someone you haven't met yet:** an ambiguous, hopeful line.
  - **Carry the orphans' lanterns:** Tamsin gives orders.
- **Outcomes:**
  - Your lantern hangs in the square for the rest of the save. Each autumn it is a different lantern, drawn from what you did that year.
  - This is the same evening on which the Act V reveal takes place; the lanterns the player made here are the lights in the square.
- **Receipt:** Your lantern hangs on the third line from the fountain.
- **Reward:** 200 g · 16 GP · 650 XP · sets `lantern_night_brindlewick_joined`

#### The Tune Under the Hymn

`qst_inv_tune_under_the_hymn` · **D** Investigation · giver *Fiddler Corwin* · Lv 38+ · region `reg_aldmere`

> Corwin heard the orphans singing at noon and dropped his bow. He knows the tune. He does not know why.

- **When:** Act II; a clear noon.
- **Gate:** rank D+; Act 2+; flags `met_brother_caspian`
- **Approaches:**
  - **Listen at the wall:** you hear it without being seen.
  - **Ask Eolande for the words:** she can read the Old Weave-tongue, but only half of them.
  - **Ask Corwin about his grandmother:** she called it a hymn from *the lost city*.
- **Outcomes:**
  - No NPC says the answer. The player has a clue: the orphans' hymn is older than the orphanage, and the same tune was hummed by a Valdrisian refugee's grandchild.
  - Corwin plays the tune to the end only in Act V.
- **Receipt:** A pinned clue on the Mystery Board; Corwin plays one line less in the square.
- **Reward:** 1250 g · 75 GP · 5200 XP · sets `clue_orphan_melody`

### Pell and Ivy

#### Boxing Barn

`qst_odd_boxing_barn` · **F** OddJob · giver *Sister Pell* · Lv 5+ · region `reg_aldmere`

> Sister Pell boxes in the barn behind the shrine on weekends. She says a good cleric is a good guard first.

- **When:** Any Solenday afternoon.
- **Gate:** Act 1+; flags `guild_registered`
- **Approaches:**
  - **Spar:** she teaches Guard Break by being hit.
  - **Watch:** the regulars teach you the town's gossip.
- **Outcomes:**
  - Either branch teaches the basics of Guard Break as a tutorial. A player who wins the third bout hears her say *"I used to be paid for this."*
- **Receipt:** Weekend bouts: one more cheering regular for every win.
- **Reward:** 60 g · 8 GP · 170 XP · sets `pell_boxing_met`

#### The Inquisitor at the Shrine

`qst_fac_inquisitor_at_the_shrine` · **E** Faction · giver *Sister Pell* · Lv 12+ · region `reg_aldmere`

> An Inquisitor has arrived in Brindlewick. Pell goes white, and asks you not to say she is here.

- **When:** Act II. If the Act I runes went to the Church, he asks for you by name; otherwise he arrives hunting Elira.
- **Gate:** Act 2+; flags `rank_e_reached`
- **Approaches:**
  - **Hide her:** the shrine hides her in the barn, and the Inquisitor leaves puzzled.
  - **Confront him:** Halvane was her superior; Pell speaks for the first time in twenty years.
  - **Expose her:** she is arrested, the shrine goes dark, and Brindlewick learns what the Order does.
- **Outcomes:**
  - No branch ends the arc; each changes what the shrine looks like and how Pell talks about her past. The exposure branch is a real loss, recoverable later (a long, quiet scene).
- **Receipt:** The shrine's door is open, closed or locked; the barn has a second shadow.
- **Reward:** 280 g · 22 GP · 900 XP · sets `inquisitor_shrine_resolved`

#### The Quiet Pharmacy

`qst_fac_quiet_pharmacy` · **D** Faction · giver *Fennick Reed* · Lv 38+ · region `reg_aldmere`

> Fennick sends a parcel of medicine somewhere every month. This month he cannot carry it.

- **When:** Act II; before or after Elira's rescue.
- **Gate:** rank D+; Act 2+
- **Approaches:**
  - **Deliver quietly.**
  - **Conceal the route:** ask Pell for cover.
  - **Report:** the Church pays; Elira's ending changes.
- **Outcomes:**
  - The medicine reaches Elira in the first two branches. A player who reports is paid in Church favour and loses a quiet friend.
- **Receipt:** Fennick's shelf has one fewer bottle; Elira's route is on your private map.
- **Reward:** 1200 g · 75 GP · 5000 XP + itm_minor_hp_potion · sets `quiet_pharmacy_resolved`

#### A Letter in a Familiar Hand

`qst_inv_letter_familiar_hand` · **C** Investigation · giver *Sister Pell* · Lv 62+ · region `reg_aldmere`

> Pell has received a letter in Sister Ivy's hand for the first time in twenty years. It says only: *Ask him where Mira went.*

- **When:** Act III; during or after the fake-Mina period.
- **Gate:** rank C+; Act 3+
- **Approaches:**
  - **Ask Caspian:** he answers kindly and plausibly (*"adopted"*, *"north"*). Every word is true and none is complete.
  - **Search the ledger room:** a hard stealth room in the orphanage.
  - **Show Pell the letter:** she asks you to come with her to find Ivy when you can.
- **Outcomes:**
  - No reveal. The letter and Caspian's answer are **clues** pinned to the Mystery Board. Ivy is not met until Act V (Canon: Kaede's journal).
- **Receipt:** Pell starts keeping a lantern lit in the shrine window, which Aster notices.
- **Reward:** 3500 g · 200 GP · 14000 XP · sets `ivy_letter_read`

### Eolande

#### The Overdue Books

`qst_odd_overdue_books` · **F** OddJob · giver *Eolande Fairweather* · Lv 2+ · region `reg_aldmere`

> Eolande's library has lost eleven books. She has a list of borrowers, and a lot of patience.

- **When:** Any day after registration.
- **Gate:** Act 1+; flags `guild_registered`
- **Approaches:**
  - **Politely ask**, **trade a favour**, or **play detective** (Whiskers is sitting on the last book).
- **Outcomes:**
  - Dax claims he was *researching*; Brutus is secretly reading a romance. Whiskers' book is a very old children's primer with a nine-throne picture on page one.
- **Receipt:** A reading nook appears in the library; the shelf is full for the first time in a year.
- **Reward:** 50 g · 6 GP · 140 XP · sets `eolande_books_returned`

#### Notes in the Margins

`qst_inv_notes_in_the_margins` · **E** Investigation · giver *Eolande Fairweather* · Lv 9+ · region `reg_aldmere`

> The library's cookbook has margin notes in Eolande's hand. They are not about cooking.

- **When:** After the books are returned.
- **Gate:** Act 1+; flags `eolande_books_returned`
- **Approaches:**
  - **Decode the first recipe:** it is a real recipe; the next two are not.
  - **Ask Eolande directly:** she answers with a question.
  - **Leave it:** the cookbook stays on the shelf, and you can come back.
- **Outcomes:**
  - The notes are a pattern: *proofing times*, *yield*, *the share that is lost at the top*. They are not yet proof of anything, and the quest says so.
  - Dialogue only: a Transported or Reincarnated player may recognise a growth curve. This is a flavour line and has no mechanical effect (Canon §4).
- **Receipt:** Eolande lets you into the back room; the cookbook has a ribbon in it.
- **Reward:** 200 g · 16 GP · 650 XP · sets `cookbook_margins_decoded`

#### The Reading Room Audit

`qst_fac_reading_room_audit` · **D** Faction · giver *Eolande Fairweather* · Lv 40+ · region `reg_aldmere`

> An Academy archivist is coming to inventory the Brindlewick library. Eolande has one night to decide what it contains.

- **When:** Act II; a visit that coincides with the Church hunting Elira.
- **Gate:** rank D+; Act 2+
- **Approaches:**
  - **Hide the cookbook** in a place the archivist will not look (the orphanage, Aster's candle shop, a tavern table under Whiskers).
  - **Hand it over:** the Academy gets the notes; Eolande keeps her job.
  - **Copy it:** two nights of work; the original goes to the archivist.
- **Outcomes:**
  - No branch is wrong. *Hide* is risky and rewarding; *hand over* is safe and changes the Academy's standing; *copy* gives Eolande a second copy that survives to Act V.
- **Receipt:** A poster of the cookbook on the library wall, or an empty shelf where it used to be.
- **Reward:** 1300 g · 80 GP · 5400 XP · sets `reading_room_audit_resolved`

#### The Cookbook Question

`qst_inv_the_cookbook_question` · **C** Investigation · giver *Eolande Fairweather* · Lv 63+ · region `reg_aldmere`

> "Mina" asked Eolande for the cookbook by name. Mina has never cooked in her life.

- **When:** Act III, after the swap.
- **Gate:** rank C+; Act 3+; flags `act3_nocturne_replaces_mina`
- **Approaches:**
  - **Confront "Mina":** she deflects well; you lose the element of surprise.
  - **Watch her:** one more clue accrues.
  - **Tell Nobody:** the Syndicate knows by nightfall.
- **Outcomes:**
  - A **fair clue** that something about the guild receptionist is wrong. Together with the left-handed forms, Rosie's verse and Nobody's warning, it makes the early-exposure route a *four-clue* investigation (Canon requires only that it be possible).
- **Receipt:** A pinned clue; Eolande lowers her voice around "Mina".
- **Reward:** 3300 g · 190 GP · 12500 XP · sets `clue_mina_cookbook`

### Brutus

#### Six Years at D

`qst_odd_six_years_at_d` · **E** OddJob · giver *Brutus Kale* · Lv 10+ · region `reg_aldmere`

> The morning after the brawl you find Brutus swinging at a post behind the Griffon, alone.

- **When:** Act II; dawn, any day after the Tavern Brawl.
- **Gate:** Act 2+; quests `qst_hidden_tavern_brawl`
- **Approaches:**
  - **Coach:** you teach him the one stance he never learned.
  - **Push:** he bristles and works harder.
  - **Leave him be:** the next scene is short, kind and a little sad.
- **Outcomes:**
  - In every branch Brutus leaves you alone at the tavern. In the first two, he tells you about the last room of the C trial.
- **Receipt:** He sits at the back table instead of the middle one; rookies notice.
- **Reward:** 210 g · 16 GP · 700 XP · sets `brutus_six_years_met`

#### The Fifth Attempt

`qst_odd_fifth_attempt` · **D** OddJob · giver *Brutus Kale* · Lv 42+ · region `reg_aldmere`

> Brutus has booked the C trial again. He asks you to be his second in the Gauntlet's last room.

- **When:** Act III; before Marrowgate.
- **Gate:** rank D+; Act 3+; flags `brutus_six_years_met`
- **Approaches:**
  - **Be his second:** stand at the arena edge and call the timing.
  - **Step back:** he must do it alone; he fails and tries again.
  - **Spar first:** Hollis's Yard, three days.
- **Outcomes:**
  - Brutus passes the C trial in two of the three branches. Examiner Garrick breaks his jaw for the twelfth time and says it was worth it.
- **Receipt:** Brutus wears a C-Rank card at the Griffon and buys a round for rookies.
- **Reward:** 1500 g · 95 GP · 6200 XP · sets `brutus_fifth_attempt_resolved`

### Hollis

#### The Buried Sword

`qst_hidden_buried_sword` · **E** Hidden · giver *Old Hollis* · Lv 10+ · region `reg_aldmere`

> After the tenth defeat Hollis digs up the third post. The sword underneath is not his.

- **When:** Triggered by losing to Hollis's broom ten times (Canon hidden trigger).
- **Gate:** Act 1+; flags `swordsman_class_trained`
- **Approaches:**
  - **Hear the story:** Corporal Ansa Veldt, who died beside him in the old war.
  - **Keep the sword:** Hollis refuses it. You can hold it for him.
  - **Return it to the post:** he nods and does not speak.
- **Outcomes:**
  - In every branch Hollis opens the yard at night. He says the old war's name only once, and the quest does not date it.
- **Receipt:** The third post has a small cut at its base; Hollis adds a lantern there on Lantern Night.
- **Reward:** 220 g · 18 GP · 750 XP · sets `hollis_buried_sword_story`

#### The Sack We Don't Open

`qst_exp_sack_we_dont_open` · **E** Exploration · giver *Farmer Hesk* · Lv 12+ · region `reg_aldmere`

> Every granary in Aldmere keeps one sealed sack that is never opened. Millbrook's is the one the goblins keep trying to reach.

- **When:** Act II, after the granary defence.
- **Gate:** Act 2+; quests `qst_def_goblins_granary`
- **Approaches:**
  - **Open it** with the town's blessing (Hesk, Pike, Caspian).
  - **Open it quietly:** Hollis finds out.
  - **Leave it sealed:** the goblins' interest dies down; Hesk breathes again.
- **Outcomes:**
  - The sack holds **names**: the Millbrook dead of the Grey Harvest (951–953), written on strips of burlap. It is a memorial, not a mystery.
  - Hollis reads the names on Lantern Night.
- **Receipt:** A memorial wall in the granary; Hesk stops leaving food out.
- **Reward:** 260 g · 20 GP · 850 XP · sets `grey_sack_opened`

### Rosie and Nobody

#### Brindlewick's Got Talent

`qst_odd_brindlewicks_got_talent` · **E** OddJob · giver *Rosie Quill* · Lv 11+ · region `reg_aldmere`

> Rosie needs a judge for the town's talent show. One of the contestants is not what they seem.

- **When:** Act II; a Vexday evening.
- **Gate:** Act 2+; flags `rank_e_reached`
- **Approaches:**
  - **Judge honestly.**
  - **Judge kindly.**
  - **Spot the imp** before the finale and take it outside.
- **Outcomes:**
  - The imp is a disguised guest; it wants to sing, and is very good. It can be spared.
- **Receipt:** A regular Vexday show at the stage; the talent show's winner is sung about for a month.
- **Reward:** 240 g · 18 GP · 800 XP · sets `rosie_talent_show_done`

#### Rosie's Second Verse

`qst_inv_rosies_second_verse` · **C** Investigation · giver *Rosie Quill* · Lv 62+ · region `reg_aldmere`

> Rosie dropped a verse tonight. It is the one that means *someone is watching*.

- **When:** Act III; after the swap.
- **Gate:** rank C+; Act 3+; flags `act3_nocturne_replaces_mina`
- **Approaches:**
  - **Extract Rosie to Umbravel:** she is safe, and the guild loses its window.
  - **Keep her as a window:** risky, informative.
  - **Use her as bait** (**signposted**): she can be lost.
- **Outcomes:**
  - The player chooses with the cost spelled out before they commit. A lost Rosie is a grave, a song, and a stage left empty.
- **Receipt:** Rosie's stage is dark, lit or gone.
- **Reward:** 3400 g · 195 GP · 13500 XP · sets `rosie_second_verse_resolved`

### Wendel

#### Left-Handed Forms

`qst_inv_left_handed_forms` · **C** Investigation · giver *Guild Clerk Wendel* · Lv 64+ · region `reg_aldmere`

> Wendel brings you three forms signed in the wrong hand. He is too polite to say whose.

- **When:** Act III, after the swap; a fourth form comes from a rank-up ceremony.
- **Gate:** rank C+; Act 3+; flags `act3_nocturne_replaces_mina`
- **Approaches:**
  - **Confront "Mina":** a bad idea; she is better at this than you.
  - **Wait for the fourth form:** the ceremony is the proof.
  - **Take it to Nobody:** Mina's sister knows what she is looking at.
- **Outcomes:**
  - This is the *paperwork* route to exposing Nocturne early, alongside Appraisal and Nobody (Canon §3). It does not end the Act III arc; it makes the reveal a choice.
- **Receipt:** Wendel files the forms in quadruplicate; the guild clerk is the only one who stays calm.
- **Reward:** 3600 g · 200 GP · 14000 XP · sets `clue_left_handed_forms`

### The Orphans

#### Junior Receptionist Day

`qst_odd_junior_receptionist_day` · **F** OddJob · giver *Tamsin Orphan* · Lv 3+ · region `reg_aldmere`

> Tamsin wants to be Mina when she grows up. Today she is Mina and you are an extremely impressive rookie.

- **When:** Any afternoon at noon, when the orphans visit the square.
- **Gate:** Act 1+; flags `met_brother_caspian`
- **Approaches:**
  - **Play along.**
  - **Faint at the right moment** (it is the only correct answer).
- **Outcomes:**
  - Mina, delighted, gives Tamsin a spare badge.
  - Act III replay: Tamsin asks to play again, the replacement "Mina" declines, and Tamsin remarks that she is never late but always says the wrong tea (a Nocturne clue).
- **Receipt:** Tamsin sits at the guild counter on weekends. After the swap she sits at the *edge* of it.
- **Reward:** 30 g · 6 GP · 120 XP · sets `tamsin_receptionist_day_done`

#### Bo's Moon Drawings

`qst_inv_bos_moon_drawings` · **E** Investigation · giver *Bo Orphan* · Lv 8+ · region `reg_aldmere`

> Bo only talks to Whiskers. He draws the two moons, over and over. Whiskers watches you until you notice.

- **When:** Act I; the drawings are pinned around town.
- **Gate:** Act 1+; flags `met_brother_caspian`
- **Approaches:**
  - **Find the six drawings** (Temple Hill, the mill wheel, the market, the guild, the watchtower, the barn).
  - **Ask Whiskers:** he purrs and leads you to the first one.
- **Outcomes:**
  - The drawings show **the red moon with buildings on it, a bridge, and a lantern with no flame**. Only the last is the orphanage's. A pinned clue on the Mystery Board: Bo draws Valdrisia and he does not know why.
- **Receipt:** Bo speaks to you once. It is one word.
- **Reward:** 180 g · 14 GP · 550 XP · sets `clue_bo_drawings`

#### A Home Soon

`qst_inv_a_home_soon` · **D** Investigation · giver *Lark Orphan* · Lv 38+ · region `reg_aldmere`

> Lark tells everyone she will be adopted on the next Blood Vesper. She is so happy that nobody has the heart to ask where.

- **When:** Act II; the ledger turns up in the cult's papers you recover.
- **Gate:** rank D+; Act 2+
- **Approaches:**
  - **Keep her close:** invite her to the Griffon on Blood Vesper.
  - **Ask Caspian:** he is gentle and certain.
  - **Take the ledger to Pell or the Guild.**
- **Outcomes:**
  - Lark is **not** taken on Blood Vesper in any branch where the player is with her. The other children are not yet safe: a partial save, not a solution. Canon's "solve it early" variant needs the full Mystery Board.
- **Receipt:** Lark gets a night at the Griffon. Marta gives her a second helping.
- **Reward:** 1300 g · 80 GP · 5500 XP · sets `clue_lark_adoption`

#### Yesterday's Bread

`qst_odd_yesterdays_bread` · **F** OddJob · giver *Hugo Brand* · Lv 2+ · region `reg_aldmere`

> Hugo takes yesterday's bread to the orphanage every noon. Today his hands are full and a queue has formed.

- **When:** Noon, any day after meeting Caspian.
- **Gate:** Act 1+; flags `met_brother_caspian`
- **Approaches:**
  - **Carry the basket.**
  - **Count the loaves:** there are never enough, yet the children are never hungry.
- **Outcomes:**
  - Hugo notices, quietly, that the orphans never seem to get hungrier. Caspian thanks you. *"Bring the children sweets, child."*
- **Receipt:** Hugo gives you a roll every time you pass, and says nothing.
- **Reward:** 40 g · 6 GP · 110 XP · sets `yesterdays_bread_delivered`

### The Crimson Wolves

#### The Wolves' Second Race

`qst_rival_wolves_second_race` · **E** Bounty · giver *Dax Rowan* · Lv 12+ · region `reg_whisperwood`

> Pim has stolen a bounty from under you again, and apologised, and Dax has finally decided to race you for it.

- **When:** Act II; Whisperwood edge.
- **Gate:** Act 2+; quests `qst_rival_crimson_wolves`
- **Approaches:**
  - **Race fairly.**
  - **Cheat first:** Pim cheats; it is a joke that everyone knows.
  - **Team up:** the Wolves are still rivals, but now they owe you a drink.
- **Outcomes:**
  - Dax drops a letter in the confusion: his father wants him home. Pim returns the stolen bounty with an apology. Isolde asks you to teach her something.
- **Receipt:** A different chair at the Wolves' table in each branch.
- **Reward:** 260 g · 20 GP · 850 XP · sets `wolves_second_race_resolved`

### Small stories

#### A Story for a Scale

`qst_odd_story_for_a_scale` · **E** OddJob · giver *Old Sal* · Lv 9+ · region `reg_aldmere`

> Old Sal will trade you a scale from the Rainbow Koi, if you tell him a story he has not heard.

- **When:** Any dawn at the Millrace dock, after three other quests.
- **Gate:** Act 1+
- **Approaches:**
  - **Tell a true story:** the game builds it from three of your completed quests.
- **Outcomes:**
  - Sal critiques it like a bard: the dull parts, the unbelievable parts, the part he liked best. The scale grants a small, one-time luck effect.
- **Receipt:** The Millrace dock gains a plaque with your story's title.
- **Reward:** 200 g · 14 GP · 600 XP · sets `sal_scale_traded`

#### The Fog Merchant's Coin

`qst_odd_fog_merchants_coin` · **E** OddJob · giver *Traveling Merchant Pell* · Lv 12+ · region `reg_whisperwood`

> A fox-kin peddler sells things she swears she found. One of them sings when you hold it.

- **When:** A foggy morning, Whisperwood edge.
- **Gate:** Act 2+
- **Approaches:**
  - **Buy the coin.**
  - **Trade a story for it.**
  - **Ask where she found it:** she points at the sky.
- **Outcomes:**
  - The coin is **Valdrisian**. It hums at a note that Corwin recognises. A clue only, with no mechanical effect.
- **Receipt:** Corwin hums the same note in the square.
- **Reward:** 250 g · 18 GP · 800 XP · sets `clue_vesper_coin`

#### The Name of the Blade

`qst_odd_name_of_the_blade` · **E** OddJob · giver *Brannoc Emberfist* · Lv 9+ · region `reg_aldmere`

> Brannoc will not sell a blade to anyone who has not told him its name. He asks yours.

- **When:** After you own a weapon of your own.
- **Gate:** Act 1+
- **Approaches:**
  - **Name your blade** (any text).
  - **Refuse:** Brannoc weeps anyway.
  - **Ask Torvald:** his unfinished blade has no name.
- **Outcomes:**
  - A named blade is remembered by the game (dialogue, one-liners). It has no mechanical effect.
- **Receipt:** Brannoc engraves the name on the blade; Torvald watches and says nothing.
- **Reward:** 180 g · 14 GP · 550 XP · sets `blade_named`


## 4. The two mysteries, as clue maps

Brindlewick holds both of the game's early mysteries (Canon §3). These quests add **fair, discoverable clues** so that each can be solved early, without any single clue being gated behind one NPC.

### 4.1 The Orphanage of the Small Lantern (Caspian)

| # | Clue | Source | Status |
|---|---|---|---|
| 1 | The orphans' songs are in Old Weave-tongue (hymns to the red moon) | Orphanage | Canon |
| 2 | "Closed for prayer" every Blood Vesper | Orphanage | Canon |
| 3 | Whiskers refuses to enter | Orphanage | Canon |
| 4 | Caspian always knows where you are | Caspian | Canon |
| 5 | "Adopted" orphans are never seen again; their names are on the cult ledger (Act II) | Cult ledger | Canon (extended by *A Home Soon*) |
| 6 | The red-eyed hobgoblin's runes match the stitching on Caspian's blindfold | *Goblin Chief* | Canon |
| 7 | Caspian never comments on rank (*"Rank is a cage, child."*) | Caspian | Canon |
| 8 | The System Voice (Fractured) glitches near him | System | Canon |
| 9 | **Aster's candles gutter inside the orphanage** | *Candles for the Hall*, *Lantern Night* | ⚙ new |
| 10 | **Bo's drawings: the red moon with buildings; a lantern with no flame** | *Bo's Moon Drawings* | ⚙ new |
| 11 | **The orphans' tune is Corwin's grandmother's hymn from "the lost city"** | *The Tune Under the Hymn* | ⚙ new |
| 12 | **Hugo notices the orphans never grow hungrier** | *Yesterday's Bread* | ⚙ new |
| 13 | **Ivy's letter: *"Ask him where Mira went."*** | *A Letter in a Familiar Hand* | ⚙ new |
| 14 | **The fog merchant's coin hums the same note** | *The Fog Merchant's Coin* | ⚙ new |

**Solving it early (proposal):** pin **8 of the 14** clues on the Mystery Board, including at least one *place*, one *person* and one *paper* clue, and bring them to Sister Pell and the Guild **before Lantern Night in Act V**. The orphans are then taken in by the town; Caspian's reveal changes to a confrontation. This is the "solve it early" variant that Canon already promises, with a concrete threshold the writers and engineers can test.

### 4.2 The Mina problem (Nocturne)

| # | Clue | Source | Status |
|---|---|---|---|
| 1 | "Mina" forgets the inside joke from registration | Act III rank-up | Canon |
| 2 | She now writes with her left hand | Guild counter | Canon |
| 3 | Whiskers hisses at her | Guild hall | Canon |
| 4 | She stops fainting at absurd feats | Any feat event | Canon |
| 5 | Her tea order changes | The Sleeping Griffon | Canon |
| 6 | Her B-Rank speech uses a Vharlen-noble word | B ceremony | Canon |
| 7 | Nobody contacts you: *"That isn't my sister."* | Rogue questline | Canon |
| 8 | **"Mina" asked Eolande for a cookbook by name** | *The Cookbook Question* | ⚙ new |
| 9 | **Left-handed forms in triplicate (then quadruplicate)** | *Left-Handed Forms* | ⚙ new |
| 10 | **Rosie drops the "watched" verse** | *Rosie's Second Verse* | ⚙ new |
| 11 | **Tamsin: "Mina is never late, but she always says the wrong tea"** | *Junior Receptionist Day* (Act III revisit) | ⚙ new |

## 5. Authoring notes

- **Dialogue** follows `11_Quests_Encounters/guild_hall_talk_and_lexicon.md`: plain words, short lines, warmth over jokes.
- **Rewards** are deliberately modest. The reward is the receipt.
- **Reward items** are existing items only (`itm_healing_herb`, `itm_minor_hp_potion`, `itm_copper_compass`). Proposed new items (Aster's lantern, Joren's pack, Marta's ledger page) are *cosmetic or flavour* and are not in `Data/Items/` yet.
- **Scarjaw** is represented by the existing `mon_hobgoblin` species. A Named variant is a bestiary task; it is not required to ship these quests.
- **Marrowgate's fall** (`marrowgate_fell`) is a **story** flag set by the Act III battle, not by a side quest; if the Act III beat moves, change the flag's setter, not these quests.
- **Edric Gruel** and **Joren** are never NPCs. They exist only as names, a sword, a card and a lantern. The quests ask the player to *remember* them.

## 6. Open questions

| # | Question | Default |
|---|---|---|
| 1 | Does the **Warden** registration (*Tomlin Tries Again*) become a real class-ladder entry, or stay a one-off? | One-off, a clerk's footnote |
| 2 | Do the Ring 2+ revisits need their own **town state** art, or just dialogue? | Dialogue and one prop each |
| 3 | Should *A Story for a Scale* read three **actual** completed quests, or a fixed set? | Actual, if the world-memory record supports it; fixed otherwise |
| 4 | Which of the 36 quests should appear on the **Weekly Board**? | None; they are NPC-offered and appear in the journal |
