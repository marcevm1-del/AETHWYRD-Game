# 11e-10 — Frostveil, the Long Winter: Ten Side Quests (draft)

> *"The skalds of Skjaldheim sing of a summer that lasted a hundred years. No one living has seen one."*
> — Gazetteer, Frostveil

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 6 and quest 7 plant *unexplained* seeds about the Shattered Sky and an ancient summer; neither is ever answered.

**Region:** `reg_frostveil` (Skjaldheim, the longhouse steads, the fjords, the glaciers, the Shattered Sky). **Rank band:** B–A. **Tone:** stoic, warm, and slow, with a joke told in the middle of the worst storm. Fire is hospitality, and hospitality is law.

**Placement notes.**
- **Ymgrir, the Frost Sovereign**, is the region's Tyrant. His breath freezes the sea; the fishing fleets are trapped; the jarls have called the **Thing** early to debate electing a war-king. No quest here kills Ymgrir.
- **Garmrok, the World-Eater Wolf,** is a Calamity event (Act V) whose habitat includes Frostveil. These quests never involve him.
- Customs the quests rely on: **letting a hearth fire die is a crime**; the **Last Fire** at Skjaldheim has burned six hundred years; the dead are sent to sea in **burning ships**; **skalds** are historians, lawgivers and entertainers; a king is elected **only in war and only for its duration**.
- The three hooks in the gazetteer (the Last Fire's sacred wood, the returned survivor, the skald who wants a saga about the living) are quests 1, 6 and 5.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | Wood for the Last Fire | B | Gathering | Fire-Keeper Hrefna | A grove behind enemy lines |
| 2 | The Frozen Fleet | B | Defense | Harbourmaster Eyvind | Two hundred sailors, one channel |
| 3 | A Frost Troll at the Door | B | Faction | Goodwife Gudrun | Hospitality tested |
| 4 | A Burning Ship on Ice | B | OddJob | Thora Jarl's-Widow | A funeral, improvised |
| 5 | A Saga About the Living | B | Faction | Skald Ragnhild | Who deserves to be sung? |
| 6 | The Survivor Who Came Back Older | A | Investigation | Old Halvard | A door left ajar |
| 7 | A Cave of Summer | A | Exploration | Ice-Guide Sigrid | Warmth inside the glacier |
| 8 | The Thing | A | Faction | Lawspeaker Vigdis | A war-king, or none |
| 9 | The Last Fire Goes Out | A | Defense | Fire-Keeper Hrefna | One night at the hearth |
| 10 | The Saga, Sung | A | Hidden | Skald Ragnhild | The last verse |

## Cast (new supporting NPCs)

<!-- npc
id: npc_hrefna_firekeeper
name: Fire-Keeper Hrefna
tier: major
race: Human
region: reg_frostveil
settlement: Skjaldheim
role: Keeper of the Last Fire
backstory: A broad-shouldered, soft-spoken keeper of the Last Fire who has not slept more than three hours at a stretch in nineteen years and has never once complained.
-->
<!-- npc
id: npc_eyvind_harbourmaster
name: Harbourmaster Eyvind
tier: major
race: Human
region: reg_frostveil
settlement: Skjaldheim harbour
role: Harbourmaster
backstory: A grizzled harbourmaster who has counted every ship in and out of the fjord for thirty years and has just lost count of forty.
-->
<!-- npc
id: npc_gudrun_goodwife
name: Goodwife Gudrun
tier: townsfolk
race: Human
region: reg_frostveil
settlement: Longhouse steads
role: Goodwife of a longhouse stead
backstory: A formidable goodwife with six children, forty chickens and an unbroken rule that no one is turned from her door, which is about to be tested.
-->
<!-- npc
id: npc_thora_widow
name: Thora Jarl's-Widow
tier: major
race: Human
region: reg_frostveil
settlement: Longhouse steads
role: Widow of Jarl Bjorn Ironmantle
backstory: A tall, composed widow who has been told her husband must be sent to sea in a burning ship and has been told the sea is frozen.
-->
<!-- npc
id: npc_skald_ragnhild
name: Skald Ragnhild
tier: major
race: Human
region: reg_frostveil
settlement: Skjaldheim
role: Skald of Skjaldheim
backstory: A sharp, restless skald who has memorised four hundred sagas about the dead and who is, for the first time, writing one about someone who might be alive on the day it is finished.
-->
<!-- npc
id: npc_old_halvard
name: Old Halvard
tier: major
race: Human
region: reg_frostveil
settlement: Skjaldheim
role: Survivor of the northern fleet
backstory: A bent, white-bearded man who sailed north with the fleet forty years ago, aged nineteen, and has walked back into Skjaldheim looking sixty and speaking like a boy.
secret: He remembers the sky opening, and does not think it was an accident.
-->
<!-- npc
id: npc_sigrid_iceguide
name: Ice-Guide Sigrid
tier: major
race: Human
region: reg_frostveil
settlement: The high glaciers
role: Glacier guide
backstory: A lean, laconic glacier guide who has led forty travellers across the high ice and never lost one, and who has just found a cave that is warm.
-->
<!-- npc
id: npc_lawspeaker_vigdis
name: Lawspeaker Vigdis
tier: major
race: Human
region: reg_frostveil
settlement: Skjaldheim
role: Lawspeaker of the Thing
backstory: A dry, austere lawspeaker who has recited the whole of Frostveil's law from memory every winter for thirty years and finds it the only reliable form of comfort.
-->

---

## 1. Wood for the Last Fire

*B · Gathering · Skjaldheim · giver Fire-Keeper Hrefna*

**The short version.** The Last Fire at Skjaldheim has burned for six hundred years. The sacred wood it burns is nearly gone, and the only grove left is in Ymgrir's territory.

**What is really going on.** The grove's trees are *winter-proof*, but not winter-*born*: their rings still hold the memory of old summers. When burned, they release *warmth that is older than the glacier*. Ymgrir's frost trolls guard the grove not because it is sacred but because the *trees are the one thing in Frostveil he cannot freeze*.

**Scene 1: the hearth.**

**HREFNA:** "Six hundred years. Never once out."
**HREFNA:** "I tend it as my mother tended it, and her mother. We burn only the grove-wood. Nothing else will do."
**HREFNA:** "Two logs left. And then... I do not say it aloud."
> ► **"Where's the grove?"** — **HREFNA:** "Three days north. Past the ice-wall. In the Sovereign's reach."
> ► **"Why that wood?"** — **HREFNA:** "Because it remembers summer."
> ► **"I'll fetch it."** — **HREFNA:** "Thank you. Bring a sledge. Bring a *prayer*."

**Scene 2: the ice-wall.** A long, hard, hushed trek north along the glacier's edge. The wind cuts like knives. Frost trolls, huge, slow, grey as the ice, stand watch in pairs.

**TROLL (a deep, groaning voice):** "...*No wood.*"
**TROLL:** "*The Sovereign says: no wood. No summer. No warm.*"
> ► **"Fight."** — A hard, cold fight on the glacier.
> ► **"Sneak."** — A tense crawl in whiteout.
> ► **"Talk."** — The troll listens, slowly.

**Scene 3: the grove.** Beyond a ring of ice, a small stand of black-barked trees, bare of leaves, ringed by *dry earth* where no snow lies. A faint, impossible warmth rises from the ground.

**HREFNA (earlier):** "You will know it. The snow does not touch it."
*The player touches the bark. For a heartbeat, the cold falls away, and the scent of green things, hot stone and a long-dead summer rushes through the grove.*
**PLAYER:** "...It's *warm.*"
> ► **"Take what's needed."** — A respectful harvest.
> ► **"Take a seedling."** — Hrefna may later plant it.
> ► **"Take nothing, and report."** — The grove must be defended.

**Scene 4: the return.** The sledge creaks home through a blizzard. At the hearth, Hrefna lifts the first log, whispers a prayer, and lays it on the Last Fire.

**HREFNA:** "...There."
*The fire roars. A warm gold light spills through the hold's great hall. For one long, silent moment, every face turns toward it, and *every person in the hall can smell summer*.*

**Outcomes and receipt.**
- The Last Fire has fuel for a year (and a seedling, if the player brought one). If the player fought, a few frost trolls remain wounded; if they talked, the troll became an informant.
- **Receipt:** a small pile of grove-wood lies by the hearth; Hrefna keeps a seedling in a pot on the hall sill.

<!-- quest
id: qst_fv_wood_last_fire
title: Wood for the Last Fire
rank: B
type: Gathering
giver: npc_hrefna_firekeeper
region: reg_frostveil
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: fv_wood_resolved
summary: The Last Fire has two logs left. The sacred grove that supplies it is in Ymgrir's territory.
objectives:
  talk npc_hrefna_firekeeper
  reach frostveil_sacred_grove
  choice fight_sneak_or_talk
-->

---

## 2. The Frozen Fleet

*B · Defense · the outer fjords · giver Harbourmaster Eyvind*

**The short version.** Forty fishing boats are frozen in the outer fjord. Two hundred sailors are living on them, rationing, burning furniture. Eyvind needs a path cut before the next storm.

**What is really going on.** Ymgrir's breath freezes the water *just beyond* a certain line. Eyvind has charted it. If the sleds reach the fleet and a channel is cut *along the line* in six hours, the ships can be towed out. The challenge is *speed*, and the frost trolls that prowl the ice.

**Scene 1: the quay.**

**EYVIND:** "Forty ships. Two hundred souls. Three weeks. And last night, a *crack* in the ice."
**EYVIND:** "I counted forty-one. I counted forty. I counted forty-one again. I'm *tired*."
**EYVIND:** "I need a sled-team, a cutting crew, and *someone who can fight on ice*."
> ► **"What's the plan?"** — **EYVIND:** "Cut a channel. Tow them. Run."
> ► **"What are the dangers?"** — **EYVIND:** "Trolls. Cold. And the *ice itself*."
> ► **"I'll lead the sleds."** — **EYVIND:** "Good. Keep moving."

**Scene 2: the ice.** A high-intensity defense sequence across a frozen fjord. Sleds drag cutting-saws; crews of fishermen hack at the ice with hot-stone wedges. Frost trolls surge up from below, shattering plates; the player holds a line.

*(Gameplay: wave defense on a shifting ice field. The ice cracks under heavy hits; the player must keep the cutters protected and the channel straight.)*

**CREW-CAPTAIN:** "Forty yards! *Forty!* Keep cutting!"
**TROLL:** "*...Sovereign...says...stop.*"
**PLAYER:** "Not today."

**Scene 3: the fleet.** At the first frozen ship, a ragged crew greets the player with a ragged cheer. Their stores are nearly gone. A child, no more than ten, hands the player a half-eaten biscuit.

**CHILD:** "We saved you a bit."
**PLAYER:** "...Thank you."
> ► **"Give them food."** — A quick scene of relief.
> ► **"Keep cutting."** — The channel inches onward.
> ► **"Carry the sick first."** — A short, sober triage.

**Scene 4: the tow.** Under a pale, unsteady sun, forty ships creak, shudder and *move*. One by one they slide into the channel, ropes taut, oars rising, sailors singing. Behind them, the ice closes again with a long, low groan.

**EYVIND:** (hoarse) "...Forty. All of them."
**EYVIND:** "I counted *forty*."
*He sits down on a bollard and puts his head in his hands.*

**Outcomes and receipt.**
- The fleet is freed. If the player prioritises the sick, a few boats are lost; if they hold the line, all survive. The outer fjord freezes again within the week.
- **Receipt:** a strip of coloured cloth hangs on every boat that came home; Skjaldheim's harbour has a new custom: every returning ship rings a bell.

<!-- quest
id: qst_fv_frozen_fleet
title: The Frozen Fleet
rank: B
type: Defense
giver: npc_eyvind_harbourmaster
region: reg_frostveil
level: 96
act: 4
requires_rank: B
reward: 12000 | 700 | 52000
sets: fv_fleet_resolved
summary: Forty fishing boats and two hundred sailors are frozen in the outer fjord. A channel must be cut before the next storm.
objectives:
  talk npc_eyvind_harbourmaster
  defend frostveil_outer_fjord
  choice feed_cut_or_carry
-->

---

## 3. A Frost Troll at the Door

*B · Faction · a longhouse stead · giver Goodwife Gudrun*

**The short version.** A frost troll has knocked on Gudrun's door. It is cold. It is hungry. It is very polite. By the law of the hearth, no guest may be turned away.

**What is really going on.** The troll, **Grumm**, is not one of Ymgrir's. He is a *deserter*: he left the Sovereign's host because he could no longer bear the cold. He wants to sit by a fire for one night. The law of the hearth says he may. His size, his bulk and his fur-coat of icicles say otherwise.

**Scene 1: the door.**

**GUDRUN:** "Do not look at him. He is *polite*. That is what is *frightening*."
**GUDRUN:** "He knocked. He *said please*. He said he's cold. I have six children, forty chickens and a *law*."
**GUDRUN:** "I will not break the law. But I will not have my children *eaten*."
> ► **"Let me talk to him."** — **GUDRUN:** "Thank you."
> ► **"What does the law say?"** — **GUDRUN:** "A guest at the hearth is a guest."
> ► **"I'll stay by the fire."** — **GUDRUN:** "Good. Sit by the children."

**Scene 2: the guest.** The troll is nine feet tall, his hair frozen to his shoulders, his hands blue. He bows low in the doorway.

**GRUMM:** "Good... evening. I am... *Grumm*."
**GRUMM:** "I was one of the Sovereign's. I left. I am... *cold*. It is a different kind of cold, *inside*."
**GRUMM:** "I would like to sit. By a fire. For one night."
**GUDRUN:** (white-knuckled) "Sit. *Slowly.*"
> ► **"Where will you go after?"** — **GRUMM:** "I do not know."
> ► **"Why did you leave?"** — **GRUMM:** "I saw a fire once. In a window. I could not stop thinking about it."
> ► **"Do you eat people?"** — **GRUMM:** (shocked) "*No!* I eat... *fish*."

**Scene 3: the night.** An odd, tender, comic evening. The troll sits in a corner, huge and meek, a mug of broth cradled in both hands. The children stare. The youngest, a small girl, climbs into his lap.

**GIRL:** "You're *cold.*"
**GRUMM:** (very still) "...Yes."
**GIRL:** "I'll *warm you.*"
*She tucks a small woollen blanket round his enormous knee.*
**GUDRUN:** (whispering) "...Oh, no. Oh, *no*."

**Scene 4: the morning.** The troll leaves at dawn, a small blanket tied around his neck. At the door, he turns.

**GRUMM:** "...Thank you. For the *law.*"
**GUDRUN:** "It's not mine."
**GRUMM:** "It is *now*."
*He walks into the white. In a small, quiet voice, Gudrun says to the player:*
**GUDRUN:** "There will be more of them, won't there?"

**Outcomes and receipt.**
- Grumm leaves, grateful; in later quests, he may return as a friendly figure, or an informant. If the player *drove him off*, he dies of the cold, and the hearth is quiet for a week.
- **Receipt:** a small blanket hangs on a peg by the door; Gudrun adds a second bowl of broth to every night's table.

<!-- quest
id: qst_fv_troll_at_door
title: A Frost Troll at the Door
rank: B
type: Faction
giver: npc_gudrun_goodwife
region: reg_frostveil
level: 98
act: 4
requires_rank: B
reward: 12500 | 720 | 54000
sets: fv_troll_resolved
summary: A frost troll has knocked on a goodwife's door. By the law of the hearth, no guest may be turned away.
objectives:
  talk npc_gudrun_goodwife
  reach frostveil_longhouse_hearth
  choice welcome_watch_or_drive_off
-->

---

## 4. A Burning Ship on Ice

*B · OddJob · the longhouse steads · giver Thora Jarl's-Widow*

**The short version.** The dead of Frostveil are sent to sea in burning ships. The fjord is frozen. Thora's husband, Jarl Bjorn, must still be sent.

**What is really going on.** The law says the funeral ship must *reach the open water* before it burns. The nearest open water is two leagues of frozen fjord away. Thora has decided to drag the ship across the ice, with a hundred mourners, and to burn it at the water's edge.

**Scene 1: the ship.**

**THORA:** "He died at the Thing. Of age. Quietly. He was sixty-one, and my husband for thirty years."
**THORA:** "By law, he goes to sea in a burning ship. The sea is *ice*."
**THORA:** "I will not break the law. I will not *bury* him. I will *drag the ship*."
> ► **"How?"** — **THORA:** "Sleds. Ropes. A hundred people."
> ► **"It's two leagues."** — **THORA:** "I know."
> ► **"I'll pull."** — **THORA:** "Thank you. Your hands are *wanted*."

**Scene 2: the pull.** A long, slow, haunting sequence across the ice. A hundred mourners harness themselves to ropes; the funeral ship, a small, finely carved vessel, creaks across the white. Wind, silence, the crunch of boots.

**MOURNER:** "He taught me to read the tides."
**MOURNER 2:** "He gave me my first boat."
**MOURNER 3:** "He once let a thief go, and the thief *came back* with a sheep."
*Each tells a story. Each pulls harder.*
> ► **(Tell a story of your own.)** — The line steadies.
> ► **(Say nothing.)** — The silence carries.
> ► **(Sing a verse.)** — A thin, shaky chorus joins.

**Scene 3: the edge.** At the edge of the ice, where the black water finally shows, a long, jagged line of open sea. The mourners lay the ship at the water's edge. Thora lights the pyre herself.

**THORA:** "Go well, my husband."
**THORA:** "Go well, and *far*."
*The flames climb the sails. The ship begins, impossibly, to slide, pushed by a thin, steady current, toward the open water.*

**Scene 4: the sea.** The burning ship drifts out, a small, bright star on the black. A hundred mourners stand in silence. Then, one by one, they begin to sing.

**THORA:** (very quietly, to the player) "He would have *hated* this."
**THORA:** "He would have said: *too much fuss*."
*She laughs, and then, for the first time that day, she weeps.*

**Outcomes and receipt.**
- Bjorn's funeral is completed; Thora, who might have been the next Lawspeaker, quietly takes a smaller role. If the player is silent, the line struggles, but the mourners sing.
- **Receipt:** a small burn-scar on the ice that does not refreeze; a tall stone with Bjorn's name stands at the water's edge.

<!-- quest
id: qst_fv_burning_ship
title: A Burning Ship on Ice
rank: B
type: OddJob
giver: npc_thora_widow
region: reg_frostveil
level: 100
act: 4
requires_rank: B
reward: 13000 | 760 | 56000
sets: fv_ship_resolved
summary: A jarl's funeral ship must reach open water to burn. The fjord is frozen for two leagues.
objectives:
  talk npc_thora_widow
  reach frostveil_ice_edge
  choice story_silence_or_song
-->

---

## 5. A Saga About the Living

*B · Faction · Skjaldheim · giver Skald Ragnhild*

**The short version.** The skalds of Frostveil sing only of the dead. Ragnhild wants to write one about someone who is *still alive*. She wants the player to help her choose whom.

**What is really going on.** A saga about the dead is a *lament*. A saga about the living is a *promise*. Ragnhild believes Frostveil needs a story that is *not finished*, because the people are tired of endings. She has three candidates, and a fear: the one she writes about must be *brave enough to be written about*.

**Scene 1: the skald's hall.**

**RAGNHILD:** "Four hundred sagas. Every one of them ends with a funeral."
**RAGNHILD:** "I am tired of funerals. I want a saga with a *beginning*."
**RAGNHILD:** "I have three people in mind. I would like *you* to meet them. And then tell me who deserves to be sung."
> ► **"Why me?"** — **RAGNHILD:** "Because you're not from here. You'll see what we cannot."
> ► **"Who are they?"** — **RAGNHILD:** "A net-mender. A boy. A shield-maiden."
> ► **"I'll meet them."** — **RAGNHILD:** "Good. Take notes. And be *fair*."

**Scene 2: the three.**
- **Aud the net-mender,** sixty-eight, who has mended every net in Skjaldheim for fifty years and refuses all thanks: *"A net is a net. It's not a *deed*."*
- **Tryggve, age eleven,** who has kept a fire lit at the harbour every night since his father's ship went missing: *"If he sees it, he'll come home."*
- **Sunniva the shield-maiden,** thirty, who has stood in every shield-wall in the last war and now trains the young: *"I do not want a saga. I want them to *live*."*

**AUD:** (peering at the player) "A saga? For *me*? Don't be daft."
**TRYGGVE:** "I'm *not* a hero. I'm... *waiting*."
**SUNNIVA:** "I have buried too many songs."
> ► **(Talk to each three times.)** — A different scene each time.
> ► **(Give each a small gift.)** — A small, unexpected reaction.
> ► **(Ask each what they'd want sung.)** — Three very different answers.

**Scene 3: the decision.** At the skald's hall, the player sits with Ragnhild. Three notes lie on the table.

**RAGNHILD:** "Well?"
> ► **"Aud."** — **RAGNHILD:** "A saga about *thread*. I like it."
> ► **"Tryggve."** — **RAGNHILD:** "A saga about *hope.* It will break their hearts."
> ► **"Sunniva."** — **RAGNHILD:** "A saga about *the living after the war.*"
> ► **"All three."** — **RAGNHILD:** (a long silence) "That is a *very* big saga."

**Scene 4: the first verse.** Ragnhild takes up her harp. She plays a single, trembling chord.

**RAGNHILD:** "*Hear me. There was a woman who mended nets...*"
*(or: a boy who kept a fire; or: a woman who stood in the line.)*
**RAGNHILD:** (stopping, hoarse) "...It's *good*."
**RAGNHILD:** "It's the *first* thing I've written that doesn't end."

**Outcomes and receipt.**
- The saga's subject is chosen; the others receive a short *verse*. The choice sets the saga's tone for quest 10.
- **Receipt:** the subject's name is carved on the skald's hall bench; Aud, Tryggve or Sunniva is invited to the Thing.

<!-- quest
id: qst_fv_saga_living
title: A Saga About the Living
rank: B
type: Faction
giver: npc_skald_ragnhild
region: reg_frostveil
level: 102
act: 4
requires_rank: B
reward: 14000 | 800 | 60000
sets: fv_saga_resolved
summary: A skald wants to write a saga about someone who is still alive, and asks the player to help choose whom.
objectives:
  talk npc_skald_ragnhild
  reach frostveil_three_candidates 3
  choice aud_tryggve_sunniva_or_all
-->

---

## 6. The Survivor Who Came Back Older

*A · Investigation · Skjaldheim · giver Old Halvard*

**The short version.** Forty years ago, a fleet sailed north to find the source of the Shattered Sky and never returned. Halvard was nineteen. He has walked back into Skjaldheim, looking sixty and speaking like a boy.

**What is really going on.** *Nothing is explained.* Halvard remembers a *single night*. By his own count, he has been gone three weeks. He has *aged forty years*. The quest is a deliberate seed: the player listens, records, and is given one image: *a door left ajar*.

**Scene 1: the hall.**

**HALVARD:** "I... am sorry. I am lost. I was told the fleet was *here*. I was told there was a harbour."
**HALVARD:** "This is *Skjaldheim*, is it not? I know this fire. I know *that* bench. But everyone is... *older*."
**HALVARD:** "Where is my captain? Where is *Captain Sverri*?"
> ► **"How long were you gone?"** — **HALVARD:** "Three weeks. Perhaps four."
> ► **"It's been forty years."** — **HALVARD:** "*No.*"
> ► **"Sit. Eat."** — **HALVARD:** "Thank you. I'm... *hungry.*"

**Scene 2: the story.** Over a long, slow supper, Halvard tells it:

**HALVARD:** "We sailed north. Seven ships. The sky grew... strange. Wide. Pale. *Cracked*."
**HALVARD:** "And then we reached it. The place. The *Shattered Sky.* A tear, high above, like *glass* with a light behind it."
**HALVARD:** "The captain said: *it is only the aurora.* But it wasn't."
**HALVARD:** "It was... a *door.* Left ajar. By someone who meant to *come back*."
> ► **"A door to where?"** — **HALVARD:** "I... do not know. I saw only the crack."
> ► **"Who left it?"** — **HALVARD:** "I do not know that either."
> ► **"What happened to the fleet?"** — **HALVARD:** "They *went in*. I was ordered to stay. I stayed."

**Scene 3: the evidence.** In his ragged coat, Halvard carries a small, flat stone: smooth, black, and warm. When the player holds it, a faint voice speaks, in no language, and falls silent.

**HALVARD:** "I do not know what it is. It was on the deck when I woke."
> ► **"Keep it."** — **HALVARD:** "I... would like to."
> ► **"Take it to the skalds."** — **HALVARD:** "They will sing it into legend."
> ► **"Leave it with the Thing."** — **HALVARD:** "...They will not understand."

**Scene 4: the quiet.** Halvard sits by the Last Fire and looks into the flames for a long time.

**HALVARD:** "I am an old man now. And I am *nineteen*."
**HALVARD:** "I would like to go home. But I do not know *which* one."
*Hrefna lays a hand on his shoulder, and says nothing.*

**Outcomes and receipt.**
- Halvard settles at the Last Fire; the stone is recorded in the player's Journal and remains *unexplained*.
- **Receipt:** a pinned note on the Mystery Board titled *"A Door Left Ajar"*; Halvard tells the story to any child who asks.
- **Canon-safe:** the quest does not explain the Shattered Sky and adds no fact beyond what Halvard saw.

<!-- quest
id: qst_fv_survivor_older
title: The Survivor Who Came Back Older
rank: A
type: Investigation
giver: npc_old_halvard
region: reg_frostveil
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 130000
sets: fv_survivor_resolved, clue_shattered_sky
summary: A man from the fleet that sailed north forty years ago has come back, aged forty years in what he says was three weeks.
objectives:
  talk npc_old_halvard
  reach frostveil_last_fire
  choice keep_skalds_or_thing
-->

---

## 7. A Cave of Summer

*A · Exploration · the high glaciers · giver Ice-Guide Sigrid*

**The short version.** Sigrid has led forty travellers across the high ice and never lost one. Yesterday, she found a cave that is *warm*.

**What is really going on.** Inside the glacier lies a pocket of *ancient summer*, a hollow in the ice with green grass, wildflowers, a small stream and a patch of golden light. It is the skalds' hundred-year summer, *preserved*. It is dying. Ymgrir's breath is reaching it.

**Scene 1: the ice.**

**SIGRID:** "Forty crossings. I've never lost a soul. I'm *proud* of it."
**SIGRID:** "Yesterday I fell into a crevasse. And at the bottom, *there was a door.*"
**SIGRID:** "It's warm. I have *seen* grass."
> ► **"Where?"** — **SIGRID:** "Four hours up. Past the ice-fall."
> ► **"Is it safe?"** — **SIGRID:** "I'm... not sure."
> ► **"I'll go."** — **SIGRID:** "Bring a rope."

**Scene 2: the descent.** A beautiful, perilous descent into the glacier's blue heart. Walls of ice hum with a faint pulse. A narrow tunnel opens into a vast, warm hollow.

**SIGRID:** (whispering) "...Oh."
*Before them, a meadow of green grass, wildflowers, a gurgling stream and a single, small, golden-leaved tree. Above, the ice ceiling glows like a lantern.*
**SIGRID:** "It's... *summer.*"
> ► **"It's real."** — **SIGRID:** "I've been here an hour. I haven't *breathed*."
> ► **"It's dying."** — **SIGRID:** "...I know."
> ► **"Who else knows?"** — **SIGRID:** "No one."

**Scene 3: the meadow.** In the grass, a single, ragged figure sits: a very old woman in a faded blue cloak, humming softly.

**OLD WOMAN:** "...Ah. A visitor. How *unlikely.*"
**OLD WOMAN:** "I am Eira. I was the last skald to sing the hundred-year summer. I have been here, I think, a *very* long time."
**OLD WOMAN:** "I have been keeping it *warm*."
> ► **"How?"** — **EIRA:** "By *singing.*"
> ► **"It's dying."** — **EIRA:** "...I know. I am very tired."
> ► **"Come with us."** — **EIRA:** "If I leave, it ends."

**Scene 4: the choice.** The meadow is a *memory* given shape by the skald's song. It will outlast her only if someone takes up the song.

> ► **"I'll learn it."** — **EIRA:** "Then sit. It will take... a *while.*"
> ► **"We'll bring the skalds."** — **EIRA:** "They will argue."
> ► **"Let it end."** — **EIRA:** (a long breath) "...Perhaps that is mercy."

**EIRA:** "Summer is not a thing you *keep*. It is a thing you *carry*."
*She laughs, softly, and begins to hum. The meadow brightens. The player listens.*

**Outcomes and receipt.**
- The cave of summer survives with a *new keeper* (the player, a skald, or Sigrid), or ends gently. The song is learned only if the player stays.
- **Receipt:** a faint warm patch on the glacier where the entrance lies; a small golden leaf in the player's Journal.
- **Canon-safe:** the cave is a *seed* about Frostveil's hundred-year summer. It does not explain the cause of winter.

<!-- quest
id: qst_fv_cave_summer
title: A Cave of Summer
rank: A
type: Exploration
giver: npc_sigrid_iceguide
region: reg_frostveil
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: fv_summer_resolved
summary: A glacier guide has found a warm cave with green grass inside the ice. It is the skalds' hundred-year summer, and it is dying.
objectives:
  talk npc_sigrid_iceguide
  reach frostveil_glacier_cave
  choice learn_bring_or_let_end
-->

---

## 8. The Thing

*A · Faction · Skjaldheim · giver Lawspeaker Vigdis*

**The short version.** The jarls have called the Thing early. By law a king is elected *only in war and only for its duration*. Vigdis needs a neutral witness for the vote.

**What is really going on.** Three candidates seek the war-kingship: **Jarl Sigrun**, a hardliner who wants to march on Ymgrir; **Jarl Ottar**, a cautious veteran who wants to *wait for the thaw*; and **Jarl Hallveig**, who proposes *no king at all*, only a council. The vote is a knife-edge. A single procedural error could void it.

**Scene 1: the hall.**

**VIGDIS:** "Three hundred and sixty-one laws. I have recited every one of them every winter for thirty years."
**VIGDIS:** "And not one of them tells me what to do *today*."
**VIGDIS:** "I need a witness. Not of Frostveil. Not a jarl. Someone who will *write down what is said*."
> ► **"What's the vote?"** — **VIGDIS:** "Sigrun, Ottar or Hallveig. Or *none*."
> ► **"What can go wrong?"** — **VIGDIS:** "Everything."
> ► **"I'll witness."** — **VIGDIS:** "Sit at my left. Do *not* speak unless I look at you."

**Scene 2: the speeches.** In Skjaldheim's great hall, three hundred jarls, thanes and free farmers sit on benches. Each candidate speaks.

**SIGRUN:** "We have waited. We have *frozen*. We have buried our dead in ice. *March.*"
**OTTAR:** "I have seen what a frost giant does to a shield-wall. We do not *win*. We *wait*."
**HALLVEIG:** "A king is a rope with one end. A council is *a net*."
> ► **(Record each speech.)** — The player's notes become part of the Thing's roll.
> ► **(Question the candidates.)** — A short, sharp exchange.
> ► **(Remain silent.)** — **VIGDIS:** (a nod) "Wise."

**Scene 3: the error.** At the second round of voting, a clerk miscounts. A jarl stands, shouting that the vote is *void*.

**VIGDIS:** (low) "I need you now."
> ► **"The count is wrong."** — Public correction; tempers flare.
> ► **"The law allows a recount."** — A procedural fix.
> ► **"Let it stand."** — The result is clouded.

**Scene 4: the verdict.** After a long, tense recount, the hall votes. The bronze bowl rings.

**VIGDIS:** (reading) "Sigrun: ninety-seven. Ottar: ninety-eight. Hallveig: ninety-six. None: seventy."
**VIGDIS:** "...No candidate has a majority."
*A long silence.*
**VIGDIS:** "By law, when no king is chosen, *the Thing itself rules.*"
**HALLVEIG:** (very quietly) "...That is what I *wanted*."

**Outcomes and receipt.**
- The Thing rules by council; if the player's notes are used, the council adopts *a standing record* for the first time. The war with Ymgrir proceeds by *consensus*, with all three candidates as captains.
- **Receipt:** a long bench in the great hall inscribed with the three candidates' names; Vigdis keeps the player's notes in the law-chest.

<!-- quest
id: qst_fv_the_thing
title: The Thing
rank: A
type: Faction
giver: npc_lawspeaker_vigdis
region: reg_frostveil
level: 136
act: 4
requires_rank: A
reward: 34000 | 1700 | 150000
sets: fv_thing_resolved
summary: The jarls have called the Thing to elect a war-king. A neutral witness is needed for a vote that could go three ways, or none.
objectives:
  talk npc_lawspeaker_vigdis
  reach frostveil_great_hall
  choice correct_recount_or_let_stand
-->

---

## 9. The Last Fire Goes Out

*A · Defense · Skjaldheim · giver Fire-Keeper Hrefna*

*Best played after quests 1 and 3.*

**The short version.** Ymgrir's blizzard has reached Skjaldheim. The Last Fire must not go out. It is in the middle of the hold. Hrefna has one night, one hearth and everyone she can gather.

**What is really going on.** Ymgrir does not want to *kill* anyone. He wants the winter to be *true*. The Last Fire is the one thing in Frostveil that says otherwise. If it dies, so does the memory of every fire it was lit from.

**Scene 1: the hearth.**

**HREFNA:** "It is the *worst* storm I have ever seen."
**HREFNA:** "The wind is *inside the hall.* I have fed it everything. The grove-wood. The benches. The *doors.*"
**HREFNA:** "We need *more.* We need *something that burns for a reason.*"
> ► **"What do we burn?"** — **HREFNA:** "Everything we can bear to lose."
> ► **"How long?"** — **HREFNA:** "Until dawn."
> ► **"I'll hold the hearth."** — **HREFNA:** "Thank you. Stand *close.*"

**Scene 2: the night.** A long, slow, brutal defence. Waves of blizzard-wraiths and frost-wolves hurl themselves at the doors. The hold's people form lines: one at each door, one at the hearth, one feeding the fire.

*(Gameplay: wave defense with a resource meter. The fire's strength depends on what the player and the hold feed it: wood, tapestries, treasure, *stories.* Each sacrifice is a small scene.)*

**BLIZZARD-WRAITH:** *(a voice like cracking ice)* "*...Let it go out. It is only a fire.*"
**HREFNA:** "It is *not* only a fire."
> ► **(Burn a tapestry.)** — The hall sighs.
> ► **(Burn a sword.)** — A proud warrior weeps.
> ► **(Burn a letter.)** — A quiet, awful choice.
> ► **(Tell a story.)** — The fire flares *brighter*.

**Scene 3: the dark hour.** At the darkest point, the fire shrinks to a single flickering coal. A hundred faces watch. The wind howls. Hrefna, exhausted, kneels at the hearth.

**HREFNA:** "...I cannot."
**TRYGGVE (the boy from quest 5, if met):** (small voice) "I've brought mine."
*He holds out a tiny lantern, lit from his own harbour-fire.*
**HREFNA:** "...Oh."
*One by one, the people of Skjaldheim step forward with candles, lanterns, torches: small fires from their own hearths, laid in the great grate.*

**Scene 4: the dawn.** When the first grey light reaches the hold, the Last Fire stands, small, sooty and unbroken, ringed by a thousand small flames. The storm has passed. The wraiths are gone.

**HREFNA:** (a whisper) "...Six hundred and one years."
**HREFNA:** "It is not the fire that kept us. It is *us* that kept the fire."
*She sits down on the hearth-stone and, for the first time in nineteen years, sleeps.*

**Outcomes and receipt.**
- The Last Fire survives; Skjaldheim holds. The siege continues, but the Sovereign's winter loses a night.
- **Receipt:** a ring of small lanterns burns forever around the Last Fire; Hrefna's seat is now shared by two keepers.

<!-- quest
id: qst_fv_last_fire_out
title: The Last Fire Goes Out
rank: A
type: Defense
giver: npc_hrefna_firekeeper
region: reg_frostveil
level: 140
act: 4
requires_rank: A
requires_quests: qst_fv_wood_last_fire
reward: 36000 | 1700 | 148000
sets: fv_lastfire_resolved
summary: Ymgrir's blizzard has reached Skjaldheim. The Last Fire must not go out.
objectives:
  talk npc_hrefna_firekeeper
  defend frostveil_skjaldheim_hearth
  choice burn_tapestry_sword_or_story
-->

---

## 10. The Saga, Sung

*A · Hidden · Skjaldheim · giver Skald Ragnhild*

*Requires quests 5 and 8.*

**The short version.** The Thing is over. The war is decided. Ragnhild will sing her saga of the living at the closing feast. She has one verse left unwritten. She asks the player to write it.

**What is really going on.** The last verse of a saga is the *hardest*. By tradition, it is the verse where the skald names *what the hero did*, and what it *meant*. Ragnhild has written every verse but one. She wants it written by someone who was *there*.

**Scene 1: the hall.**

**RAGNHILD:** "I have written forty-one verses. Forty-*one*. And the last one is blank."
**RAGNHILD:** "I could write it. I know how it *ends*. But it would be *my* ending."
**RAGNHILD:** "I would like it to be *yours*."
> ► **"What do I write?"** — **RAGNHILD:** "One line. What *they* did. What it *meant*."
> ► **"What if it's wrong?"** — **RAGNHILD:** "A saga is *never* right. It is only *true*."
> ► **"I'll write it."** — **RAGNHILD:** "Thank you."

**Scene 2: the line.** The player is given a small wax tablet and a bone stylus. Beside it, a short, spare verse form, in the old skaldic metre. The choices:
- **A line of triumph.** *"They broke the ice and brought the ships home."*
- **A line of tenderness.** *"They kept a fire for those who could not."*
- **A line of silence.** *"And they were, and are."*

> ► **(Choose a line, or write your own.)** — The verse goes into the saga.

**RAGNHILD:** (reading) "...That is *perfect.*"
**RAGNHILD:** "I could not have written it."

**Scene 3: the feast.** At the closing feast, three hundred people sit at long tables under a ceiling of smoke. Ragnhild, harp on her knee, rises.

**RAGNHILD:** "I have sung of the dead for thirty years. Tonight I sing of the *living.*"
*She begins. The saga unfolds: the net-mender, the boy, the shield-maiden; the fleet, the fire; the Thing. The audience weeps, laughs and, at the last line, falls silent.*
**RAGNHILD:** *(singing)* "...*And the one who came from nowhere stayed, and was loved.*"

**Scene 4: the quiet.** After the last note, no one moves. Then, from the back of the hall, a single, slow clap. Then another. Then a thousand.

**RAGNHILD:** (very quietly, to the player) "It does not *end*, you see."
**RAGNHILD:** "A saga about the living has no last verse. It has *a next one.*"

**Outcomes and receipt.**
- The saga is sung; the player's line is quoted at every feast. The subject of quest 5 (Aud, Tryggve or Sunniva) is *present*, and speaks one line.
- **Receipt:** the saga is added to Skjaldheim's roll; a small bone stylus hangs in the player's home.

<!-- quest
id: qst_fv_saga_sung
title: The Saga, Sung
rank: A
type: Hidden
giver: npc_skald_ragnhild
region: reg_frostveil
level: 144
act: 4
requires_rank: A
requires_quests: qst_fv_saga_living, qst_fv_the_thing
reward: 36000 | 1700 | 150000
sets: fv_saga_sung_resolved
summary: The skald will sing her saga of the living at the closing feast. She has one verse left, and wants the player to write it.
objectives:
  talk npc_skald_ragnhild
  reach frostveil_closing_feast
  choice triumph_tenderness_or_silence
-->
