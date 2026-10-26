# 07d — Brindlewick Storylines: The People of the Cradle (draft)

> *"Everyone in Brindlewick is waiting for somebody to come back."*
> — Captain Holt, to a rookie, at the north gate

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Everything below *builds on* NPCs, secrets and clues that already exist in `Data/NPCs/npcs.json`, `10_World/brindlewick.md`, `02_Lore/story.md` and Canon §3. New names, backstories and links are marked **⚙ new** and are listed as proposals in Canon §6 ("Brindlewick storylines"). The quests that carry these arcs are in [[Design Bible/11_Quests_Encounters/brindlewick_side_quests|`11_Quests_Encounters/brindlewick_side_quests.md`]]; their data is in `Data/Quests/quests.json`.

⚠️ **Contains spoilers** (Caspian, Nocturne, the harvest, Vesper).

## 1. Why these arcs

Brindlewick is the Ring 1 hub and the town the player returns to for the whole game. Right now it has one named secret for almost every resident and almost no *story* for them. This pass gives each of the town's main people **a want, a fear, a small arc across the six Acts and a visible ending**, and ties the arcs to each other so that the town feels like one place, not forty vending machines.

Design rules, all taken from Canon and the pillars:

| Rule | How it shows up |
|---|---|
| **A world that remembers** | Every arc ends in a *receipt* the player can see: a lit lantern, a new chair, a changed line of dialogue, a board notice |
| **Warmth over comedy** | Funny scenes exist, but every arc has at least one scene that is simply kind |
| **No silent loss** | Nobody dies from a missed dodge or a missed timer. Deaths are story choices, clearly signposted (Canon §5) |
| **Clues are fair and spread** | The big Canon secrets (Caspian, Mina) get *new* clues from these NPCs, but never a clue that only one NPC can give |
| **Small first, big later** | Acts I–II arcs are personal and local; Acts III–V connect each arc to the war without turning the person into a lore dispenser |
| **Alternate routes** | No arc is a gate. Skipping a quest closes only that quest's receipt, never the main story |
| **Named monsters stay impersonal** | Scarjaw and the Goblin Chief matter to people, never "to you" (Canon §4d) |

## 2. The web

The arcs interlock. Five hidden bonds hold the town together; the player discovers them one by one, and each discovery changes how two familiar NPCs talk to each other.

```
 Edric Gruel (dead) ──saved a rookie──▶ Captain HOLT ──counts every returner──▶ Guard TOMLIN
        │                                  │
   MARTA & TEO  ◀── Morrowsday dinner ─────┘                 HOLLIS ──secretly teaches── TEO
        │                                                       │
   the Hall of Cards ◀── Widow ASTER (Joren)                  BRUTUS ──trains in Hollis's Yard
        ▲
  SISTER PELL ◀─old friends─▶ Sister IVY ⚙ ──left── Orphanage of the Small Lantern ◀── HUGO's bread
        │                                              ▲        ▲          ▲
   FENNICK ──medicine──▶ Elira                  BO's drawings  LARK's date  CORWIN's melody
        
  EOLANDE ──cookbook──▶ Kaede's journal            WENDEL's forms ─▶ "Mina" ◀── NOBODY ◀── ROSIE
```

| Bond | Who it connects | Revealed by |
|---|---|---|
| **The rookie Edric saved** | Marta, Holt, Tomlin | *Edric's Sword* (Act III) |
| **The old novitiate** ⚙ | Pell and Ivy Thorne | *A Letter in a Familiar Hand* |
| **The lullaby** ⚙ | Corwin and the orphans' hymn (and, later, Vesper) | *The Tune Under the Hymn* |
| **The yard** | Hollis, Teo, Brutus, Tomlin | *The Stable Boy's Broom*, *Six Years at D* |
| **The ledger of the unpaid** | Marta, Aster, the Hall of Cards | *Payday at the Griffon*, *Joren's Last Contract* |

---

## 3. The arcs

Each arc lists: **want / fear**, **canon anchors**, **beats by Act**, **choices**, and **where it ends**. Quest names in *italics* are in the side-quest file.

### 3.1 Marta Gruel and Teo — *The Ledger of the Unpaid*

| | |
|---|---|
| **Want** | Keep her son off the north road, and keep every rookie fed |
| **Fear** | That Teo becomes one more name she has to write "paid" beside |
| **Canon anchors** | Feeds every rookie on credit; lost her husband to a wyvern twenty years ago; his sword hangs over the bar; **secret:** has never collected a debt from an adventurer who died. Teo secretly trains with Hollis at night |
| **⚙ new** | Husband: **Edric Gruel**, a B-Rank who held a pass so rookies could run. She keeps a **ledger with one page per rookie**; a dead rookie's page is closed in red ink with the word *paid*. She has never told anyone what the red ink means |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I | Marta feeds you on credit (existing). On payday the tavern needs a steady hand; you glimpse a page with red ink | *Payday at the Griffon* | Marta starts calling you by name instead of "rookie" |
| I–II | You catch Teo sneaking to Hollis's Yard at night and decide who to tell | *The Stable Boy's Broom* | Teo trains in daylight (all branches); the *Marta knows / secret kept / bargain* variants change two lines at the bar |
| II | After the Goblin Chief's death, Teo tries to follow a party north to "help" | *The Boy on the North Road* | Holt's gate log shows Teo's name; Marta stops locking the stable at night |
| III | Marrowgate falls; refugees fill the Griffon to the rafters | *Every Bed in the Griffon* | Cots in the common room, a pot on all night, Whiskers asleep on a refugee child; the board gains a "Refugee aid" notice |
| III–IV | Marta asks you to carry Edric's sword to Brannoc | *Edric's Sword* | The sword leaves the wall. In the empty bracket Marta hangs the ledger |
| V | If the orphan mystery is solved early, the children are housed at the Griffon for a night; Marta turns the orphans' supper into a feast she charges nothing for | *(story beat)* | The first time the ledger has a page opened with no debt |
| After | Teo's path is decided (below) | — | Epilogue card |

**Choices and endings (Teo):**
- **Registers at F** — Marta signs the card herself, and for the first time writes a name in the ledger *before* a debt exists.
- **Keeps the inn and trains with Hollis** — becomes the town's youngest gate warden.
- **Takes the sword** — if the player chose to give Edric's sword to Teo, not Marta. Both are acceptable; the line differs.

**Rules:** Marta stays `canDie: true` in data only for signposted story choices; this arc contains none. If a future Canon decision adds one, it must not be this arc's.

### 3.2 Captain Holt, Guard Tomlin and Mayor Pike — *Counting Them Home*

| | |
|---|---|
| **Want** | Holt: that no rookie goes unnoticed. Tomlin: a second chance at the card. Pike: to keep the town alive without anyone knowing what it costs |
| **Fear** | Holt: the day the count doesn't come out even. Tomlin: that envy is all he is. Pike: being found out |
| **Canon anchors** | Holt "counts every one that comes back"; Tomlin failed Guild registration; Pike became mayor because nobody else wanted it and **secretly pays Strife Marches mercenaries to patrol the north road** |
| **⚙ new** | Holt is the rookie Edric Gruel saved; he has never told Marta. Holt keeps a tally board in the gate house: a white stone per returner, a black stone per loss |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I | The player walks past the tally board; Holt nods when you return from your first contract | *(ambient)* | A white stone appears for you |
| I–II | Wendel finds the mayor's "road maintenance" invoices don't match any road | *The North Road Ledger* | Pike's secret is known to the player; the north road patrol changes by choice (below) |
| II | Tomlin asks for help with the oath question that failed him | *Tomlin Tries Again* | He holds an oak card; wears it *under* his tabard |
| II–III | A surge at night; Holt asks for a second pair of eyes on the gate | *The Count at the Gate* | The tally board is rebuilt; the number of stones reads true |
| III | Marrowgate refugees arrive. Pike has to choose between his secret and the town's coffers | *(story beat)* | Pike's mercenaries leave if exposed; if kept secret they leave anyway when Vesper swells, and Holt notices first |
| III–IV | Edric's sword reveals who the saved rookie was | *Edric's Sword* | Holt and Marta share a Morrowsday dinner; the Griffon gives him a table by the fire |
| V | On Lantern Night the tally board is the only record that anyone *is* here | *(story beat)* | Holt's white stones are carried to the lanterns |

**Pike's choice (*The North Road Ledger*):** expose to the council (the town loses its patrol and gains honesty), keep the secret and help him pay (the patrol stays; Pike owes you), or force him to hire locals (Tomlin and three rookie volunteers become the road watch). Each leaves a visible change on the north road.

**⚙ Option for the director (not drafted):** the mercenaries could be Dorran "Red Ledger" Hask's company, so that Lyra meets the men who burned her village *guarding our road*. Strong, but it is a large change to Lyra's arc; see Canon §6.

### 3.3 Widow Aster and Corwin — *A Lantern for Joren*

| | |
|---|---|
| **Want** | Aster: to know how her son died, and to stop lighting the lantern. Corwin: to hear the song finish |
| **Fear** | Aster: that stopping means forgetting. Corwin: that the tune has no ending |
| **Canon anchors** | Aster makes the Lantern Night lanterns and lights one daily for a son who never came back; his card is in the Hall of Cards; he was **Scarjaw's first victim**. Corwin is a blind fiddler who knows rank by footsteps |
| **⚙ new** | Joren was an F-Rank gathering moon-moss for his mother's wicks. Corwin's grandmother hummed a lullaby she called "a hymn from the lost city"; it matches the orphans' Old Weave-tongue hymn |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I | Candles for the guild hall; Aster says Joren's name for the first time | *Candles for the Hall* | The guild hall gains a new row of candles |
| I | Corwin names your rank by your footsteps | *The Sound of Rank* | A tune in the square changes with your rank |
| I–II | You recover Joren's pack and finish his last contract: moon-moss for her wicks | *Joren's Last Contract* | Aster lights a lantern for Joren once, at the Hall of Cards, not daily |
| II | Autumn: Lantern Night in Brindlewick. Aster teaches you to make your own lantern | *Lantern Night in Brindlewick* | Your lantern hangs in the square for the rest of the save |
| II–III | Corwin hears the orphans' hymn at noon and falters | *The Tune Under the Hymn* | A **clue**: the tune is older than the orphanage and is from "the lost city" |
| V | The Lantern Night reveal. Aster's lanterns burn steady in a sky full of red light; Corwin plays the tune to the end | *(story beat)* | The only light in the square is the town's own |

**⚙ New clue (proposal):** *Aster's candles gutter inside the orphanage, however the door is shut.* It joins the eight clues already in Canon (see the clue map in the quest file). A player can read it as damp air. A second playthrough reads it as the flame refusing the room.

### 3.4 Sister Pell and Sister Ivy — *The Village She Wouldn't Burn*

| | |
|---|---|
| **Want** | Pell: to be useful without being owned. Ivy: for the children to stop being sold |
| **Fear** | Pell: that she let her friend walk into the dark. Ivy: that she is right |
| **Canon anchors** | Pell: cheerful cleric trainer, boxes in the barn on weekends, **was an Inquisitor who refused to burn a village**. **Sister Ivy Thorne** is the Choir of Mirrors' leader, a former orphanage nun, redeemable by Kaede's journal |
| **⚙ new** | They were novices together. Ivy served at the Orphanage of the Small Lantern before she left the Order, because the "adopted" children never wrote back. Pell wrote to her every year; Ivy stopped answering |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I | A friendly bout in the barn; Pell teaches Guard Break by being hit | *Boxing Barn* | Weekend bouts, one more crowd cheer each time you win |
| II | The Inquisitor from Act I arrives, or the Church starts hunting Elira. Pell recognises him | *The Inquisitor at the Shrine* | Pell is hidden, confronted or exposed (choice); the shrine changes accordingly |
| II | A quiet supply line to a fugitive saint | *The Quiet Pharmacy* | Fennick, Pell and Elira's network is on the map; Elira's ending state improves if you kept it quiet |
| III | A letter in Ivy's hand: *"Ask him where Mira went."* | *A Letter in a Familiar Hand* | **Clue** pinned to the Mystery Board; Pell asks you to go with her to find Ivy |
| V | Show Ivy Kaede's journal (Act V, Guild Vault). She defects (Canon) | *(story beat)* | Pell and Ivy meet for the first time in twenty years; the reunion scene is long, quiet, and without music |
| V | The orphans are saved before the Lantern Night reveal or not (Mystery Board) | *(story beat)* | Pell is the first to reach the children if you solved it; she is the last if you didn't |
| After | Pell's weekend bout with Brother Ansel, the Gentle Fist, becomes a post-game event | *(optional)* | The barn is full |

### 3.5 Magistra Eolande Fairweather — *The Cookbook*

| | |
|---|---|
| **Want** | To know *why* the System exists, without being ruined for asking |
| **Fear** | That the answer is worse than the question |
| **Canon anchors** | Fired from the Academy for asking why the System exists; **hides her research on the harvest inside a cookbook** in the library |
| **⚙ new** | Her notes are coded as recipes. *Proofing times* are growth curves; *yield* is the share lost at the top. She has the pattern, not the proof, and thinks it is "a tithe" |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I | Overdue books are all over town | *The Overdue Books* | The library has a full shelf for the first time; a reading nook appears |
| I–II | She teaches you to read a margin; the first recipe is a real recipe | *Notes in the Margins* | The cookbook can be found; you can choose not to |
| II | The Academy sends an archivist to audit | *The Reading Room Audit* | Hide the book, hand it over, or copy it; Academy and Church standings change accordingly |
| III | "Mina" asks Eolande for the cookbook by name. Mina has never cooked | *The Cookbook Question* | **Clue** for the Nocturne reveal; unlocks an early exposure route |
| V | Kaede's journal confirms the pattern. Eolande decodes her own recipes | *(story beat)* | The Reading Room opens; her notes hang beside Kaede's |
| V–VI | The player decides who gets to know (ending-dependent) | *(story beat)* | Epilogue card: the library is public, hidden or burned |

**Tone guard:** the harvest is **not** revealed by the cookbook. It is *hinted*, in a form that is still a recipe on first reading. The old-world perspective of a Transported or Reincarnated player may notice that "proofing curves" look like leveling curves, as a line of dialogue only; no persistent advantage (Canon §4).

### 3.6 Brutus Kale — *Stuck at D*

| | |
|---|---|
| **Want** | To be a C-Rank and stop being afraid |
| **Fear** | The last room of the C trial |
| **Canon anchors** | D-Rank tavern bully, six years at D; **secret:** terrified of failing the C trial again |
| **⚙ new** | He has failed the trial four times, always in the same room (the Gauntlet's last arena). He practises alone at dawn behind the Griffon |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I–II | The brawl (existing) | *The Tavern Brawl* | Rank-reveal moment |
| II | You find him at dawn | *Six Years at D* | He stops picking on rookies, or picks on them less; the tavern notices |
| II–III | You are his second for the fifth attempt | *The Fifth Attempt* | He is C-Rank; Examiner Garrick's jaw cracks for the twelfth time |
| III | Marrowgate. Brutus holds a bridge. Reinforce him, or the wounded | *(story beat)* | Alive and C-Rank, alive and wounded, or dead. **Signposted choice** |
| IV–V | If alive, Brutus becomes Hollis's yard assistant and the rookies' first line of defence | — | The sparring ring has a second instructor |

### 3.7 Old Hollis — *The Broom and the Buried Sword*

| | |
|---|---|
| **Want** | To teach one more good swordsman before the end |
| **Fear** | That the old war never ended |
| **Canon anchors** | One-armed ex-B-Rank, trains with a broomstick, once trained a Blade Master; buried sword under the third post; tearjerker #1 is **Hollis's Last Lesson** (he fights one last time to buy you time) |
| **⚙ new** | The buried sword belonged to **Corporal Ansa Veldt**, who died beside him in the old war where he lost the arm. The war is never named in the quest; the Marches War (978–981) is the likely fit but the dates stay with the director. Hollis also knows the "hungry years" songs and reads the Grey Sack's names on Lantern Night |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I | *A Thousand Swings* (existing) | existing | — |
| I–II | After ten broom defeats, he digs the sword up and tells the story | *The Buried Sword* | He lets you use the practice yard at night |
| II | The Grey Sack in Millbrook's granary is opened for the first time in seventy years | *The Sack We Don't Open* | A memorial in Millbrook; Hollis reads the names on Lantern Night |
| III | Teo graduates from broom to wooden sword | *(story beat)* | Hollis's yard has a third regular student |
| V | **Hollis's Last Lesson** (Canon tearjerker #1) | *(story beat)* | His fight gives the player time; the broom is left at the third post |
| After | If he survives (a flag earned across the arc), he walks the yard at dawn, one-armed, with a student on each side | — | The yard has his name |

**Rule:** the Last Lesson is the one Canon story death in this arc. It is **earned, signposted and optional** (the "survived" variant exists for a high-trust arc); it is never a surprise.

### 3.8 Rosie Quill and "Nobody" — *Who She Sings For*

| | |
|---|---|
| **Want** | Rosie: to be loved *and* useful. Nobody: to find her sister |
| **Fear** | Rosie: being unmasked. Nobody: being right |
| **Canon anchors** | Rosie reports to the Syndicate, through it to Nobody; Nobody is Mina's sister and the first to realise Mina has been replaced |
| **⚙ new** | Rosie's songs are signals: key changes mean "safe", a dropped verse means "watched". She does not know why the Syndicate wants Brindlewick's gossip, only that she is owed her brother's debt back |

| Act | Beat | Quest | Receipt |
|---|---|---|---|
| I–II | A talent show; one contestant is a disguised imp (Canon sample) | *Brindlewick's Got Talent* | Rosie's stage gets a regular Vexday show |
| II–III | Rosie warns the player in song about someone in the guild | *Rosie's Second Verse* | **Clue** for the Nocturne reveal |
| III | "Mina" notices Rosie noticing. Nocturne begins to close in | *(story beat)* | The player chooses: extract Rosie to Umbravel (safe), keep her as a window into the guild (risky), or use her as bait (**signposted**; she can be lost) |
| IV | Nobody and Rosie sing the same song from two rooms | *(story beat)* | The Syndicate's door opens |

### 3.9 Wendel and Rodrick — *Triplicate*

| | |
|---|---|
| **Want** | Wendel: for someone to notice him. Rodrick: a successor who isn't him |
| **Canon anchors** | Wendel files every report in triplicate; Rodrick can die (Marrowgate / Cult / Act IV); "Mina" writes left-handed from Act III |
| **⚙ new** | Wendel notices the **left-handed forms** (three differently-signed copies) before anyone else, and is too polite to say so. The paperwork is a *third* route to exposing Nocturne early, alongside Appraisal and Nobody |

Beats: *The North Road Ledger* (Act II, with Pike), *Left-Handed Forms* (Act III, Wendel brings you three forms; collect a fourth by a rank-up ceremony), and a quiet beat in Act IV where Wendel is the only person at the guild who doesn't change how he speaks to the new Guild Master. If Rodrick dies, Wendel is the one who sits with his chair.

### 3.10 The Orphans and Hugo — *The Small Lantern*

| | |
|---|---|
| **Want** | Tamsin: to be a receptionist. Bo: to be understood. Lark: to be adopted. Hugo: to keep feeding them |
| **Fear** | All of them: being forgotten |
| **Canon anchors** | Tamsin runs the others; Bo only speaks to Whiskers and draws the red moon *with buildings on it*; **Lark's name is on the cult ledger found in Act II** (saved if solved early); Hugo gives the orphanage yesterday's bread every noon and is Caspian's friend |
| **Rule** | The orphans are `canDie: false`. The mystery is solvable *before* the reveal; if it is not, the reveal is a tragedy that the game does not spell out in gore |

| Orphan | Arc | Quest | Clue on the Mystery Board |
|---|---|---|---|
| **Tamsin** | A "Junior Receptionist Day" in which she plays Mina and you play an absurd rookie. Later she shadows the real Mina's replacement | *Junior Receptionist Day* | She notices "Mina" is never late for a rank-up but "always says the wrong tea" (Act III) |
| **Bo** | Six drawings of the red moon with towers, a bridge and a lantern with no flame | *Bo's Moon Drawings* | The drawings show Valdrisia; the unlit lantern shows the orphanage |
| **Lark** | She tells everyone she will be adopted soon; the date is on a ledger | *A Home Soon* | The date arrives in Act II; if the player is with her, she stays |
| **Hugo** | His bread is the sweets Caspian asks for. He is the only adult who has noticed the orphans never get hungrier | *Yesterday's Bread* | Hugo's confession is a pre-Act-V clue and a late-game receipt |

### 3.11 The Crimson Wolves — *Rivals and Roads*

| | |
|---|---|
| **Want** | Dax: to be taken seriously. Isolde: to be told her magic matters. Pim: to stop apologising |
| **Fear** | Dax: his father's letter. Isolde: being replaceable. Pim: being found out |
| **Canon anchors** | Arrogant E-Rank swordsman from a minor noble family; sleepy mage who thinks the player is cooler; halfling scout who steals bounties and apologises |
| **⚙ new** | Dax's father has ordered him home; Pim sends every copper to a sick sibling; Isolde learned to cast from a manual Dax paid for |

Beats: the Crimson Wolves race (existing), *The Wolves' Second Race* (Act II, they steal a bounty and bring it back with an apology), a letter from Dax's father (Act III), and an Act IV choice: the Wolves can stand with the militia, split, or go home. Each result is a line in the Griffon's rumours and a different chair at their usual table.

### 3.12 The Smaller Stories

Short, complete, no arc required. Each has one quest.

| NPC | Story | Quest |
|---|---|---|
| **Old Sal** | A scale for a story. The tale must be *yours*: it is built from three things you actually did | *A Story for a Scale* |
| **Pell the merchant** | Her wares come from Vesper. A coin sings when you hold it | *The Fog Merchant's Coin* |
| **Brannoc and Torvald** | He will not sell a blade that has not been named; Torvald's unfinished blade has no name | *The Name of the Blade* |
| **Gilda, Fennick, Ines** | A haggle you can lose on purpose, a poison you can learn to spot, a cloak you can have mended | (folded into the quests above) |

---

## 4. Town states

Quest results do not need a branch per NPC. They roll up into a small number of **town-level receipts** that the player can see without opening a menu:

| State | Visible cue | Set by |
|---|---|---|
| **Marta's ledger** | A new page opens; the sword leaves the wall | *Edric's Sword* |
| **The tally board** | White and black stones; later, a new row | Holt's arc |
| **The Hall of Cards** | Joren's card is moved from a shelf to a wall; names are lit | *Joren's Last Contract*, *Lantern Night in Brindlewick* |
| **The yard** | One, two or three students; Brutus on the porch | Hollis and Brutus |
| **The reading room** | Full shelves, nook, a poster of the cookbook | Eolande's arc |
| **The stage** | A regular Vexday show; a different song when "Mina" walks in | Rosie's arc |
| **The orphanage** | The lantern with no flame; if solved early, the lamp lit and the door open | The Mystery Board |

## 5. The Orphanage mystery, in one place

The eight clues already in Canon (the Old-Weave-tongue hymns, "closed for prayer" on Blood Vesper, Whiskers refusing the door, Caspian knowing where you are, the cult ledger, the runes on the blindfold, no comment on rank, the System Voice glitching) stay as they are. This pass adds **six more** that any player can find in Act I–III. See the clue map in the side-quest file.

## 6. Open questions

| # | Question | Default |
|---|---|---|
| 1 | Is **Ivy Thorne** a former Brindlewick nun, or from a different Aldmere orphanage? | Brindlewick, because it makes Pell's arc and the Act II ledger one story |
| 2 | Does **Corwin's lullaby** make Valdrisian refugees' descendants a *playable* culture, or a single clue? | A single clue (minimum canon) |
| 3 | Are the north-road mercenaries **Hask's company**? | No, for now (see 3.2) |
| 4 | Does **Hollis** survive? | The "survived" variant exists, earned by the arc |
| 5 | Can **Marta** die in a future Canon decision? | Not in this arc |
| 6 | Does the **Grey Sack** hold names (this doc) or seed grain? | Names: it is a memorial, not a mystery |

## 7. Production

- All arcs are authored as **short scenes with reusable beats**: a conversation, a place, a receipt. None needs a bespoke cutscene before Ring 2.
- Ring 0 needs **none** of these. Ring 1 (Brindlewick) can ship with the Act I–II beats only; each later arc is a self-contained add.
- Dialogue and receipts follow `11_Quests_Encounters/quest_outcome_grammar.md`.
