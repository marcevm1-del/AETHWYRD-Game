# 11e-31 — Whitewater Reach, the White Coast: Ten Side Quests (draft)

> *"Fishers here marry the sea first and their spouses second. It is in the vows."*
> — Gazetteer, Whitewater Reach

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 10 plants an unexplained seed.

**Region:** `reg_whitewater_reach` (the ice-fishing villages, the Marriage Rock, the Bone Bergs, the Broken Floe). **Rank band:** A–S. **Tone:** small, tough, stubborn, superstitious about the sea and practical about everything else.

**Placement notes.**
- **Ysgrath, the Ice-Jaw Leviathan,** is the region's Tyrant. It breaks floes from below, is drawn to the vibration of footsteps, and has broken the winter ice under three villages. No quest here kills Ysgrath.
- Customs the quests rely on: every fisher is **married to the sea at sixteen** at the Marriage Rock, *before* any human marriage; offerings of fish are made before every voyage; the sea is a *jealous spouse;* disputes are settled by contests of skill; villages move between rock and ice with the seasons.
- **Rank note.** This region's band reaches rank **S**. Quests 9 and 10 are the first S-rank side quests; rewards are first-pass and extrapolated from the guild promotion table (S: level 166–205; GP 3,000; see `Data/World/guild_ranks.json`).
- Earlier pattern quests here: *A Quiet Place to Wait* and *A Calf Lost on the Ice*.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Divorce From the Sea | A | Faction | Orla Seaward | A first, in a sea-married land |
| 2 | The Berg With Something Inside | A | Exploration | Ice-Reader Juno | A thing waking in the ice |
| 3 | Quiet Feet | A | Faction | Brisa Softfoot | A village learns to walk softly |
| 4 | The Sixteenth Year | A | OddJob | Nerys Coldwater | A girl afraid of her wedding |
| 5 | A Doll for the Sea | A | Hidden | Ovi | A very small offering |
| 6 | The Broken Floe | A | Investigation | Scholar Kjeld Rimeworth | Mapping a monster's route |
| 7 | Ice Wyrm Season | A | Defense | Camp-Warden Taga Whitebrow | A winter camp under attack |
| 8 | A Wedding Under the Aurora | A | OddJob | Celebrant Dorin Netweaver | Vows with a third party |
| 9 | The Boat-Eaters' Reckoning | S | Investigation | Elder Isbrand Keelsplit | A shame, remembered |
| 10 | What the Bone Bergs Carry | S | Exploration | Cartographer Wenna Bonefield | A skeleton, unfinished |

## Cast

<!-- npc
id: npc_orla_seaward
name: Orla Seaward
tier: major
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Fisher who wants a divorce from the sea
backstory: A stubborn, dry-humoured fisher of forty who has pulled nets for twenty-four years and has decided, after losing a husband and a son to the water, that the marriage is over.
-->
<!-- npc
id: npc_ice_reader_juno
name: Ice-Reader Juno
tier: major
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Ice-reader of the northern villages
backstory: A tiny, sharp-eyed ice-reader who can tell the thickness of a floe by the sound of a spoon tapped on it and who has noticed that one of the Bone Bergs is *humming.*
-->
<!-- npc
id: npc_brisa_softfoot
name: Brisa Softfoot
tier: major
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Teacher of the soft step
backstory: A light-footed grandmother who has crossed the ice a thousand times without once waking anything and who has been told, for fifty years, that this is not a skill.
-->
<!-- npc
id: npc_nerys_coldwater
name: Nerys Coldwater
tier: townsfolk
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Girl about to marry the sea
backstory: A quiet, brave sixteen-year-old who has to marry the sea at the Marriage Rock this week and has not slept since her father drowned two winters ago.
-->
<!-- npc
id: npc_ovi_child
name: Ovi
tier: townsfolk
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Six-year-old who owes the sea a doll
backstory: A solemn six-year-old who has noticed that grown-ups give the sea fish and blood, and has decided it is probably lonely and ought to have a doll.
-->
<!-- npc
id: npc_scholar_kjeld
name: Scholar Kjeld Rimeworth
tier: major
race: Human
region: reg_whitewater_reach
settlement: The Broken Floe
role: Ice-scholar
backstory: A thin, cheerful scholar who has measured every tooth-mark on the Broken Floe and is quietly certain that the leviathan hunts in a pattern.
-->
<!-- npc
id: npc_taga_whitebrow
name: Camp-Warden Taga Whitebrow
tier: major
race: Human
region: reg_whitewater_reach
settlement: The winter camp
role: Warden of a winter camp
backstory: A flinty camp-warden who has kept a winter camp of three hundred alive for nineteen seasons and has not yet lost an ice-wyrm argument.
-->
<!-- npc
id: npc_dorin_netweaver
name: Celebrant Dorin Netweaver
tier: townsfolk
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Celebrant of weddings
backstory: A round, jolly celebrant of weddings who has married four hundred couples and has never once forgotten the sea's clause.
-->
<!-- npc
id: npc_isbrand_keelsplit
name: Elder Isbrand Keelsplit
tier: major
race: Human
region: reg_whitewater_reach
settlement: Ice-fishing villages
role: Elder of the Boat-Eater families
backstory: A heavy, solemn elder descended from the crews who survived a frozen winter by eating their own boats, and who has carried the family's shame for sixty years.
-->
<!-- npc
id: npc_wenna_bonefield
name: Cartographer Wenna Bonefield
tier: major
race: Human
region: reg_whitewater_reach
settlement: The Bone Bergs
role: Cartographer of the Bone Bergs
backstory: A gaunt, tireless cartographer who has charted every Bone Berg for thirty years and has been assembling, on a beach, the skeleton of something that does not exist.
-->

---

## 1. A Divorce From the Sea

*A · Faction · the Marriage Rock · giver Orla Seaward*

**The short version.** Orla has fished for twenty-four years and lost a husband and a son to the water. She wants a divorce from the sea. By the elders' law, it has never been done.

**What is really going on.** The vow has *no* exit, because nobody ever wanted one. But the sea, being a *spouse,* may be *asked.* Orla does not want to *abandon* the sea; she wants to stop being *afraid* of it. The player's job is to carry her case to the Marriage Rock.

**Scene 1: the dock.**

**ORLA:** "Twenty-four years. A good marriage. Mostly."
**ORLA:** "Then it took Eno. Then it took the boy. *Twice* I made an offering. *Twice* it said no."
**ORLA:** "I'd like out. The elders say: *impossible.*"
> ► **"What does the vow say?"** — **ORLA:** "'*Till the ice takes me.*'"
> ► **"Is there precedent?"** — **ORLA:** "None. *That's* the point."
> ► **"I'll plead it."** — **ORLA:** "Thank you. Bring a fish."

**Scene 2: the elders.** In a low, smoky hall, six elders sit round a fire.

**ELDER:** "It is *not done.*"
**ORLA:** "It is *not forbidden.*"
**ELDER:** "Because no one has been so *foolish* as to *ask.*"
> ► **"The vow is silent on divorce."** — A rustle.
> ► **"Ask the sea."** — **ELDER:** "*Ask?*"
> ► **"Offer a trial separation."** — **ELDER:** "...A *what?*"

**Scene 3: the Rock.** At dawn on the Marriage Rock, Orla, a basket of fish and a lantern. The tide slides in. She speaks to the water.

**ORLA:** "You took them. I'm *angry.*"
**ORLA:** "I'm *not leaving.* I just need a *rest.*"
*A long silence. A single, slow swell lifts the rock. A seal's head appears, watches, vanishes. Then, from the deep, a low, wet sound, almost a laugh.*
**ELDER (whispering):** "...It *agrees.*"

**Scene 4: the clause.** The elders add a new line to the vow: *"...or until the sea and the fisher agree to rest."*

**ORLA:** "A rest."
**ORLA:** "Not a divorce. A *rest.*"
**ORLA:** "...That's *all* I wanted."

**Outcomes and receipt.**
- A new, formal custom: the *Rest.* If the player pushes for a *full* divorce, the elders refuse; Orla accepts the Rest anyway.
- **Receipt:** a small cairn on the Marriage Rock, *"Orla's Rest;"* the sea, at dusk, lifts a single wave to her door.

<!-- quest
id: qst_whr_divorce_sea
title: A Divorce From the Sea
rank: A
type: Faction
giver: npc_orla_seaward
region: reg_whitewater_reach
level: 124
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: whr_divorce_done
summary: A fisher who lost a husband and a son to the water wants to divorce the sea. The vow has no exit.
objectives:
  talk npc_orla_seaward
  reach whitewater_marriage_rock
  choice silent_ask_or_rest
-->

---

## 2. The Berg With Something Inside

*A · Exploration · the Bone Bergs · giver Ice-Reader Juno*

**The short version.** A Bone Berg is drifting toward a village. Juno can hear it *humming.* Something inside is *moving.*

**What is really going on.** The berg holds a *sky-whale,* a huge, gentle, wing-finned creature, frozen mid-migration in a storm centuries ago and now *waking.* It is not dangerous. It is *very* confused.

**Scene 1: the ice.**

**JUNO:** "I can tell a floe's thickness by the *sound* of a spoon. *That* berg is humming a *B-flat.*"
**JUNO:** "Bones don't hum. *Things hum.*"
**JUNO:** "It's drifting toward Hearthmere. *Two days.* I'd like to know what's inside before it *arrives.*"
> ► **"Is it dangerous?"** — **JUNO:** "I do not *know.*"
> ► **"What do you want?"** — **JUNO:** "A look. *Inside.*"
> ► **"I'll go."** — **JUNO:** "Bring a lantern. *And a very long rope.*"

**Scene 2: the berg.** A beautiful, hushed climb through a hollow of blue ice. Bones as long as boats arch overhead. At the centre, a vast chamber. In the ice, a shape, a colossal, translucent whale with a *wing* for each fin, curled like a sleeping cat.

**WHALE (a vast, slow, thrumming note; subtitled):** *"...Where... is... the... wind?"*
> ► **"You're in the ice."** — **WHALE:** *"...Ah."*
> ► **"It's a long time since."** — **WHALE:** *"...How long?"*
> ► **"I'll get you out."** — **WHALE:** *"...Gently."*

**Scene 3: the thaw.** A slow, careful, spellbinding sequence in which the player and a handful of village ice-cutters, with fire, lantern-light and song, thaw the berg *from the inside out,* a few inches a day.

**CUTTER:** "It's *warm.* The ice around it's *warm.*"
**WHALE:** *"...I remember... singing."*

**Scene 4: the flight.** At last, on the third dawn, the berg splits. A vast, slow shape unfolds, a huge, shimmering wing, then another, and the sky-whale rises, trailing a long white banner of mist, and sings a single, tremendous, wordless note that shakes the whole coast.

**JUNO:** (hoarse) "...*Oh.*"
*The whale wheels once over Hearthmere, turns north and vanishes into cloud. Along the shore, the villagers stand in silence. Then, very slowly, the children start to sing it back.*

**Outcomes and receipt.**
- The sky-whale is freed. If the player rushes the thaw, the berg *shatters,* and the whale is *hurt* but still flies.
- **Receipt:** a faint, wing-shaped hollow in the ice; the village keeps the whale's note as its dawn-song.

<!-- quest
id: qst_whr_berg_inside
title: The Berg With Something Inside
rank: A
type: Exploration
giver: npc_ice_reader_juno
region: reg_whitewater_reach
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: whr_berg_done
summary: A Bone Berg drifting toward a village hums a single note. A frozen sky-whale is waking inside it.
objectives:
  talk npc_ice_reader_juno
  reach whitewater_humming_berg
  choice thaw_rush_or_song
-->

---

## 3. Quiet Feet

*A · Faction · the northern villages · giver Brisa Softfoot*

**The short version.** The leviathan is drawn to the vibration of footsteps. Brisa has crossed the ice a thousand times without waking anything. She wants to teach three villages.

**What is really going on.** Brisa's *soft step* is not a trick; it is a *way of walking:* weight low, heel last, a pause between each stride. It takes a season to learn. The villages have *one week.* The player is asked to *learn it first,* and *teach.*

**Scene 1: the ice.**

**BRISA:** "Fifty years. *Not once* has the leviathan found me."
**BRISA:** "They call it a *knack.* It's *not.* It's *manners.*"
**BRISA:** "Watch."
*She steps onto the ice. There is no sound. No crack. No ripple.*
> ► **"Teach me."** — **BRISA:** "It is *boring.*"
> ► **"What's the trick?"** — **BRISA:** "Be *polite* to the floor."
> ► **"How long?"** — **BRISA:** "A *season.* You've a *week.*"

**Scene 2: the lesson.** A funny, humbling, slow sequence. The player's first steps *boom.* The second *thump.* Brisa shakes her head. The player practises on *felt,* on *snow,* on *a trampoline of hides.*

**BRISA:** "No! You *stomp* like a *walrus.*"
**BRISA:** "*Heel last.* *Weight low.* *Breathe.*"
**BRISA:** "*Better.* You *stomp* like a *polite* walrus."

**Scene 3: the crossing.** At the end of the week, the player leads a line of forty villagers across a mile of black ice, each in felt boots, each stepping in the print before. At the halfway mark, a deep, slow *thrum* from below. The line freezes.

**VILLAGER (whisper):** "*It's under us.*"
**BRISA (quietly):** "*Breathe.* *Heel last.*"
> ► **(Stand still.)** — The thrum passes.
> ► **(Keep walking, softly.)** — A bolder choice.
> ► **(Hum.)** — **BRISA:** "*No!*"

**Scene 4: the shore.** On the far bank, forty villagers collapse in the snow, laughing, silent, shaking.

**BRISA:** "...*Forty.* In one *week.*"
**BRISA:** "It took me *fifty years* to teach *one.*"
**VILLAGER:** "You never *asked.*"

**Outcomes and receipt.**
- The three villages learn the soft step; the leviathan, hungry, finds *no vibration.* If the player hummed, the thrum *follows* them.
- **Receipt:** a pair of felt boots at the village door, *"for guests;"* the children play a game of *Quiet Feet.*

<!-- quest
id: qst_whr_quiet_feet
title: Quiet Feet
rank: A
type: Faction
giver: npc_brisa_softfoot
region: reg_whitewater_reach
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: whr_quiet_feet_done
summary: The leviathan is drawn to footsteps. A grandmother who can cross the ice without waking it has one week to teach three villages.
objectives:
  talk npc_brisa_softfoot
  reach whitewater_black_ice_crossing
  choice stand_walk_or_hum
-->

---

## 4. The Sixteenth Year

*A · OddJob · the Marriage Rock · giver Nerys Coldwater*

**The short version.** Nerys must marry the sea at the Marriage Rock this week. Her father drowned two winters ago. She is afraid. She asks the player to stand as her witness.

**What is really going on.** Nerys does not want to *refuse.* She wants to *mean it.* She is afraid the vow will be *a lie,* because she is angry with the sea. The player's job is to *walk her through it,* and *not tell her what to feel.*

**Scene 1: the cottage.**

**NERYS:** "I'm sixteen on Thursday. The ceremony is on Friday."
**NERYS:** "I'm supposed to *love* it. The sea. Everyone says it's like a *second family.*"
**NERYS:** "It took my *father.*"
> ► **"Do you have to?"** — **NERYS:** "If I don't, I can't fish."
> ► **"What do you want?"** — **NERYS:** "To not *lie.*"
> ► **"I'll stand with you."** — **NERYS:** "Thank you."

**Scene 2: the practice.** For three days, the player walks with Nerys along the shore. She tells stories: her father's songs, his terrible puns, the way he always *tapped* the boat three times before launching.

**NERYS:** "He used to say: '*You don't marry the sea. You *ask* it to stay out of your way.*'"
**NERYS:** "I think *that's* the vow. Underneath."

**Scene 3: the Rock.** On Friday, at dawn, the whole village gathers. Nerys stands at the water's edge. The celebrant asks her to speak the old vow.

**CELEBRANT:** "*Do you take the sea...*"
**NERYS:** (a long silence) "...I do."
**NERYS:** "*I take it. As a neighbour. As a* hard *neighbour. As a thing my father loved.*"
**NERYS:** "*I'll not promise to love it. I promise to* respect *it.*"
> ► **(Stand silently.)** — The village stays quiet.
> ► **(Say, "She means it.")** — A single voice.
> ► **(Squeeze her hand.)** — A small anchor.

**Scene 4: the answer.** The tide, which has been receding, turns, and a single gentle wave laps at her feet.

**NERYS:** (softly) "...It's *listening.*"

**Outcomes and receipt.**
- Nerys is married to the sea on her own terms; the elders *allow* the modified vow. If the player told her what to feel, she *recites* the old vow, *hollow.*
- **Receipt:** a small carved fish on her father's boat; Nerys taps it three times before each launch.

<!-- quest
id: qst_whr_sixteenth_year
title: The Sixteenth Year
rank: A
type: OddJob
giver: npc_nerys_coldwater
region: reg_whitewater_reach
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: whr_sixteenth_done
summary: A sixteen-year-old must marry the sea this week. Her father drowned two winters ago, and she doesn't want to lie.
objectives:
  talk npc_nerys_coldwater
  reach whitewater_marriage_rock_dawn
  choice silent_voice_or_hand
-->

---

## 5. A Doll for the Sea

*A · Hidden · a village shore · giver Ovi*

**The short version.** Ovi, six, has noticed that grown-ups give the sea *fish and blood.* She thinks it is lonely. She has a doll. She would like help.

**What is really going on.** The doll is *very* precious. The sea, the village believes, never returns an offering. But on this day, *something* is returned: a small, luminous, perfect shell, and, inside it, *a message.*

**Scene 1: the shore.**

**OVI:** "I've been *watching.* Everyone gives it *fish.* And *blood.* It never gives *anything.*"
**OVI:** "I think it's *lonely.* I think it wants a *friend.*"
**OVI:** "I've a doll. *Mim.* She's my *best.* I'd like to give her."
> ► **"Are you sure?"** — **OVI:** "No. But it's *fair.*"
> ► **"What will you tell it?"** — **OVI:** "'*Look after her.*'"
> ► **"I'll go with you."** — **OVI:** "Good. Don't *talk.*"

**Scene 2: the offering.** At dusk, at the water's edge, Ovi sets the doll on the tide-line. She whispers.

**OVI:** "*Hello. I'm Ovi. This is Mim. She's my best. Please look after her. Don't let her get cold.*"
*A long silence. A wave comes in, gently, and lifts the doll. It floats, face up, out of sight.*
**OVI:** (small) "...*Bye, Mim.*"

**Scene 3: the night.** Ovi sleeps badly. In the morning, the player and Ovi return to the shore. On the sand, in the exact spot, lies a small, perfect, pearly shell.

**OVI:** "...*It's a present.*"
*Inside the shell, a tiny, wet, ink-black note, written in a language that is all curves:*
**PLAYER (reading aloud, as the shell hums):** "*She is warm. Thank you. I was lonely.*"
**OVI:** (gasping) "*I was* right."

**Scene 4: the village.** Ovi shows the shell to the elders, who stare in awe.

**ELDER:** "...The sea has *never* written."
**ELDER:** "In *eleven hundred years.*"
**OVI:** "Well. *I asked nicely.*"

**Outcomes and receipt.**
- The sea answers; the village starts leaving *small, kind* gifts as well as fish. If the player *explains* it away, Ovi still believes.
- **Receipt:** a shell on Ovi's windowsill that sings at high tide; a new tradition: *"Dolls for the Sea."*

<!-- quest
id: qst_whr_doll_sea
title: A Doll for the Sea
rank: A
type: Hidden
giver: npc_ovi_child
region: reg_whitewater_reach
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: whr_doll_done
summary: A six-year-old thinks the sea is lonely and offers it her best doll. The sea writes back.
objectives:
  talk npc_ovi_child
  reach whitewater_village_shore_dusk
  choice sure_message_or_accompany
-->

---

## 6. The Broken Floe

*A · Investigation · the Broken Floe · giver Scholar Kjeld Rimeworth*

**The short version.** The Broken Floe is a field of shattered ice where the leviathan surfaced. Kjeld has measured every tooth-mark. He believes the leviathan hunts in a *pattern.*

**What is really going on.** The leviathan's route is *a spiral,* tightening round the villages. It follows *warmth.* If the villages are *cooled* (by moving a hearth, by a night of silence), it will *not* surface where predicted.

**Scene 1: the floe.**

**KJELD:** "Four hundred tooth-marks. *Four hundred.* I've catalogued them *all.*"
**KJELD:** "It surfaces at *intervals.* Four, six, nine, thirteen *days.* A *spiral.*"
**KJELD:** "It's going to surface at *Greywater.* In *nine days.*"
> ► **"How do you know?"** — **KJELD:** "*Math.* And *a lot of tea.*"
> ► **"Can we stop it?"** — **KJELD:** "We can *dodge* it."
> ► **"I'll check your numbers."** — **KJELD:** "*Please.*"

**Scene 2: the proof.** On the ice, the player and Kjeld set up a ring of *listening posts:* hollow bone tubes, pressed to the ice.

**KJELD:** "It *hears* us. We can *hear* it."
*Under the ice, a slow, enormous *throb.* A pulse. A *breath.*
**KJELD:** "*That's* its heartbeat. *Eleven beats a minute.*"
> ► **"It's tracking a village."** — **KJELD:** "*Yes.*"
> ► **"It follows warmth."** — **KJELD:** "...*Ah.*"
> ► **"It's patient."** — **KJELD:** "It's *very patient.*"

**Scene 3: the plan.** The player and Kjeld devise a plan: *cool the village.* On the predicted night, Greywater's hearths are banked, its lamps shuttered, its people sent inland, leaving *a single warm decoy,* a large iron stove on a sled, in the *wrong* place.

**VILLAGER:** "It's *madness.* We're *abandoning* the village."
**KJELD:** "For *one night.*"

**Scene 4: the surface.** At midnight, on the ice, a vast, white, glowing shape rises under the decoy. The floe *cracks.* Jaws of living ice close on an empty stove. A great, baffled sound rolls across the bay.

**KJELD:** (whispering) "*It worked.*"
**KJELD:** "It ate a *stove.*"
*The leviathan sinks back, slowly, into the dark.*

**Outcomes and receipt.**
- Greywater is *spared;* the villages adopt Kjeld's *decoy-stove* method. If the player *doubts* the math, the village is *evacuated* but *damaged.*
- **Receipt:** a rusted iron stove, half-sunk in the ice, at the Broken Floe; Kjeld's chart hangs in every village hall.

<!-- quest
id: qst_whr_broken_floe
title: The Broken Floe
rank: A
type: Investigation
giver: npc_scholar_kjeld
region: reg_whitewater_reach
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: whr_floe_done
summary: A scholar has mapped the leviathan's surfacings and thinks it hunts in a spiral, following warmth.
objectives:
  talk npc_scholar_kjeld
  reach whitewater_broken_floe
  choice decoy_evacuate_or_doubt
-->

---

## 7. Ice Wyrm Season

*A · Defense · the winter camp · giver Camp-Warden Taga Whitebrow*

**The short version.** Every winter, ice wyrms hunt near the camp. This year there are *twice* as many. Taga has three hundred souls, fifty fighters and a plan.

**What is really going on.** The wyrms are driven by *hunger,* not malice. The leviathan has been *eating their prey.* Taga's plan is not to *kill* them, but to *turn them,* with fire, noise and a trail of fish.

**Scene 1: the camp.**

**TAGA:** "Nineteen winters. I've never lost the camp. I've never *won* the argument with the wyrms, either."
**TAGA:** "They're *thin.* They're *desperate.* They'll come at *night.*"
**TAGA:** "I don't want to *kill* them. I want to *redirect.*"
> ► **"How?"** — **TAGA:** "Fire. Noise. And *fish.* A *trail* of fish, *away* from the camp."
> ► **"What if they ignore it?"** — **TAGA:** "Then we *fight.*"
> ► **"I'll hold the east line."** — **TAGA:** "Good. Don't *run.*"

**Scene 2: the night.** A long, cold, tense defense. A ring of fires. A line of fish, dragged in a long curve across the ice. Drums, horns, a ring of villagers with torches.

*(Gameplay: wave defense; the player must keep the fish-line intact and guide the wyrms *away,* not kill them.)*

**WYRM (a long, hissing, hungry rasp):** *"...Fish."*
**TAGA:** "*Steady! Steady!*"

**Scene 3: the pack-leader.** A huge, white, scarred wyrm rises at the east line. It stares at the player. It does not strike.

**WYRM LEADER:** *"...Hungry."*
> ► **"Feed it."** — A mountain of fish.
> ► **"Stand your ground."** — A tense silence.
> ► **"Fight."** — A savage skirmish.

**Scene 4: the dawn.** The wyrms, fed, follow the fish-trail out onto the open sea. At dawn, the camp is intact, every fire still burning.

**TAGA:** "...*Nineteen winters.*"
**TAGA:** "And I've never *won* before."
**TAGA:** "*I've* never *won.*"

**Outcomes and receipt.**
- The camp is safe; the wyrms depart. If the player *fought,* a few wyrms die, and the others return next winter, angrier.
- **Receipt:** a fish-trail marked with flags; a carved wyrm on the camp gate, *"Fed, not fought."*

<!-- quest
id: qst_whr_wyrm_season
title: Ice Wyrm Season
rank: A
type: Defense
giver: npc_taga_whitebrow
region: reg_whitewater_reach
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: whr_wyrm_done
summary: Hungry ice wyrms are hunting a winter camp of three hundred. The warden wants them turned, not killed.
objectives:
  talk npc_taga_whitebrow
  defend whitewater_winter_camp
  choice feed_stand_or_fight
-->

---

## 8. A Wedding Under the Aurora

*A · OddJob · a shore village · giver Celebrant Dorin Netweaver*

**The short version.** Two fishers are to be married under the aurora. Both are *already married to the sea.* The sea, by custom, must *give them away.*

**What is really going on.** The sea does not *answer* on demand. The celebrant needs the water to be *calm,* the aurora to be *out,* and a *tide-sign* of consent, all on the same night. It is *a logistics problem,* with a *delicate* dimension of *faith.*

**Scene 1: the celebrant.**

**DORIN:** "Four hundred weddings. *Four hundred.* I've never missed *the sea's clause.*"
**DORIN:** "'*The sea gives, and the sea takes, and the sea gives away.*'"
**DORIN:** "It requires the sea to *consent.* By *rising* at the right moment. *Tonight.*"
> ► **"What if it doesn't?"** — **DORIN:** "Then we *wait.* A week."
> ► **"Is there a trick?"** — **DORIN:** "There's a *song.* And a *very* long speech."
> ► **"I'll help."** — **DORIN:** "Bring *tea.*"

**Scene 2: the preparations.** A funny, warm montage: tuning drums, choosing a song, hauling the couple's relatives across the ice, rehearsing the speech six times.

**BRIDE (Sunna):** "I'm *so nervous.* I've never been *married* before. Well, to a *person.*"
**GROOM (Piet):** "I've been married to the *sea* for twenty years."
**BRIDE:** "How's *that* going?"
**GROOM:** "Very *quietly.*"

**Scene 3: the vigil.** At midnight, the whole village stands on the shore. The aurora is *absent.* The water is *flat.* The celebrant, sweating, starts the speech.

> ► **(Sing the old song.)** — A thin, wavering melody.
> ► **(Stall with a joke.)** — A tense laugh.
> ► **(Wait in silence.)** — A long, still moment.

**DORIN:** "...*Any minute now.*"
**DORIN:** "*Any minute.*"

**Scene 4: the sign.** At the last possible moment, the sky *ignites:* green, violet, gold. The sea, flat as glass, rises in a single, silent, shining swell and sets the bride's hem *gently wet.*

**DORIN:** (in tears) "...*It gave her away.*"
*The couple kiss. The village erupts. High above, the aurora ripples like a banner.*

**Outcomes and receipt.**
- The couple are married. If the sea *refused* (by the player stalling too long), the wedding is *postponed* a week, and the couple laugh about it.
- **Receipt:** a small blue ribbon on every wedding hat; the aurora is said to *come early* for the couple's anniversary.

<!-- quest
id: qst_whr_aurora_wedding
title: A Wedding Under the Aurora
rank: A
type: OddJob
giver: npc_dorin_netweaver
region: reg_whitewater_reach
level: 124
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: whr_wedding_done
summary: Two fishers married to the sea are to wed under the aurora. The sea, by custom, must give them away.
objectives:
  talk npc_dorin_netweaver
  reach whitewater_shore_wedding
  choice sing_joke_or_wait
-->

---

## 9. The Boat-Eaters' Reckoning

*S · Investigation · the ice-fishing villages · giver Elder Isbrand Keelsplit*

**The short version.** Sixty years ago a storm froze a fishing fleet in place, and the crews survived by eating their boats. Their descendants are called *Boat-Eaters.* It is an insult. Isbrand wants to know what the boats *thought.*

**What is really going on.** The families are ashamed, not of *eating wood,* but of what *else* they ate. The old logs say *"the boats."* Isbrand has found a hidden log, in a different hand, that says *"and the dog."* The shame is *real.* The player's job is not to *absolve.* It is to *witness.*

**Scene 1: the hall.**

**ISBRAND:** "My grandfather was a Boat-Eater. They called him that to his *face.*"
**ISBRAND:** "He never *spoke* of it. He *died* of it."
**ISBRAND:** "I've found a log he *hid.* I'd like someone to read it with me."
> ► **"What's in it?"** — **ISBRAND:** "The truth."
> ► **"Why me?"** — **ISBRAND:** "Because you aren't *one of us.*"
> ► **"I'll read it."** — **ISBRAND:** "Thank you."

**Scene 2: the log.** In a low room, by candle, the player and Isbrand read a stained, brittle book.

*"Day 19. The boats are gone. We have eaten the last timber."*
*"Day 22. The dog, Pili, is thin. She does not complain."*
*"Day 24. We drew lots. God forgive us. We drew lots."*

**ISBRAND:** (very quietly) "...I did not know."
**ISBRAND:** "I thought it was just *wood.*"
> ► **"They survived."** — **ISBRAND:** "At *what cost.*"
> ► **"They were starving."** — **ISBRAND:** "I *know.*"
> ► **"What do you want to do?"** — **ISBRAND:** "I do not *know.*"

**Scene 3: the families.** At a gathering of the Boat-Eater families, in the village hall, a hundred people sit in silence. Isbrand reads. A very old woman, a survivor's daughter, weeps.

**OLD WOMAN:** "*Pili.* I remember *Pili.* She was *warm.* She slept on my *feet.*"
**OLD WOMAN:** "I was *four.*"
> ► **"We remember her."** — A long silence.
> ► **"They did what they had to."** — A rustle.
> ► **"They were not monsters."** — **OLD WOMAN:** "No. They were *hungry.*"

**Scene 4: the memorial.** On the shore, the families build a small cairn of timber, and, in its middle, a single, carved wooden dog.

**ISBRAND:** "For *Pili.*"
**ISBRAND:** "For the *boats.* For the *crews.*"
**ISBRAND:** "For all of us who *lived.*"
*A hundred people lay a piece of wood on the cairn. No one speaks.*

**Outcomes and receipt.**
- The shame is *named* and *held;* the insult *Boat-Eater* loses its edge. If the player *absolves,* the families feel *patronised.*
- **Receipt:** a cairn of timber with a wooden dog on the shore; a new custom: every winter, a piece of wood is added.

<!-- quest
id: qst_whr_boat_eaters
title: The Boat-Eaters' Reckoning
rank: S
type: Investigation
giver: npc_isbrand_keelsplit
region: reg_whitewater_reach
level: 170
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: whr_boat_eaters_done
summary: Sixty years ago a frozen fleet's crews survived by eating their boats. A hidden log says there was something else.
objectives:
  talk npc_isbrand_keelsplit
  reach whitewater_boat_eater_hall
  choice survived_starving_or_not_monsters
-->

---

## 10. What the Bone Bergs Carry

*S · Exploration · the Bone Bergs · giver Cartographer Wenna Bonefield*

**The short version.** Wenna has charted the Bone Bergs for thirty years. On a beach, she has been assembling the skeleton of something that does not exist. She is *nearly* done. She needs a last bone.

**What is really going on.** *Nothing is explained.* The skeleton is of a creature *unlike any in the bestiary:* a long, ringed, many-ribbed body with a skull shaped like an *open hand.* The last bone, from the heart of the farthest berg, completes a *hollow,* and the hollow is *shaped.* The quest ends on a question.

**Scene 1: the beach.**

**WENNA:** "Thirty years of bergs. Bones from *all* of them. I've been *assembling* them."
**WENNA:** "Look."
*On the shingle, a vast skeleton lies in a rough, graceful curve, three hundred feet long, ribs like arches, a skull like a cupped palm.*
**WENNA:** "It's *not* a whale. It's *not* a wyrm. It's *not in any book.*"
> ► **"What is it?"** — **WENNA:** "I do not *know.*"
> ► **"What's missing?"** — **WENNA:** "The *heart.* There's a *hollow.*"
> ► **"I'll find it."** — **WENNA:** "Be careful. It is *deep.*"

**Scene 2: the berg.** A long, cold, quiet expedition to the farthest Bone Berg, a mountain of ice with ribs poking through. At its heart, a chamber, and, in the chamber's centre, a single, pale, perfectly round bone, the size of a barrel, *warm.*

*(Gameplay: a quiet traversal; no combat; the player must avoid disturbing the berg's balance.)*

**JOURNAL (auto):** *The bone is not a bone. It is smooth, faintly luminous, and cold as starlight.*
> ► **(Lift it.)** — It is *very* heavy.
> ► **(Listen to it.)** — A hum, deep and slow.
> ► **(Leave it.)** — **WENNA (later):** "...Perhaps *wise.*"

**Scene 3: the heart.** On the beach, the player and Wenna lower the bone into the hollow. A deep, soundless *click.* The skeleton *brightens,* a faint, pale glow rising from every joint.

**WENNA:** (whispering) "...It's *aware.*"
*The skeleton does not move. But the sea, three hundred feet away, *rises,* just a few inches, and holds.*
> ► **"What is it?"** — **WENNA:** "I think it's *a mother.*"
> ► **"Is it alive?"** — **WENNA:** "*No.* But it's not *dead.*"
> ► **"Take it apart."** — **WENNA:** "*No.*"

**Scene 4: the silence.** After a long hour, the glow fades. The sea settles. Wenna sits on the shingle, drawing.

**WENNA:** "I have been trying to *finish* it for thirty years. And now it's *finished,* I do not know *what I made.*"
**WENNA:** "But it's *beautiful.*"

**Outcomes and receipt.**
- The skeleton stands on the beach as a quiet, strange monument; the leviathan, when it surfaces nearby, *circles* it and leaves.
- **Receipt:** a sketch in the player's Journal of a skeleton and a hollow; no explanation.
- **Canon-safe:** this is a pure seed. It does not explain the skeleton, the leviathan's reaction or the Bone Bergs.

<!-- quest
id: qst_whr_bone_bergs_carry
title: What the Bone Bergs Carry
rank: S
type: Exploration
giver: npc_wenna_bonefield
region: reg_whitewater_reach
level: 176
act: 5
requires_rank: S
reward: 75000 | 3200 | 340000
sets: whr_bone_bergs_done
summary: A cartographer has assembled on a beach the skeleton of something that does not exist. She needs one last bone.
objectives:
  talk npc_wenna_bonefield
  reach whitewater_farthest_bone_berg
  choice lift_listen_or_leave
-->
