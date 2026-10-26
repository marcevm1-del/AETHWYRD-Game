# 11e-54 — Sky Archipelago, the Abandoned Heights: Ten Side Quests (draft)

> *"The Titans left their tables set, as if they meant to come back."*
> — Gazetteer, Sky Archipelago

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 3, 9 and 10 plant unexplained seeds.

**Region:** `reg_sky_archipelago` (the Set Tables, the Broken Bridges, the wild gardens, the Highest Island's storm). **Rank band:** S–SS. **Tone:** hushed, cold, tender; the loneliness of a place that was left in the middle of a meal.

**Placement notes.**
- **No Tyrant, no siege.** The region is `liberated` and `noSiege`. Zephiel is the Act IV story boss and is *not* touched, named in dialogue or hinted at beyond the storm already in the gazetteer.
- Customs the quests rely on: guild **expedition licences**; the **Heavenfolk** of Heavenreach call the islands sacred and drive off visitors; **scholars, scavengers and hermits** camp for a season; maps are always out of date because the islands drift.
- **Rank note.** Quests 1 to 7 are rank S (levels 166-176). Quests 8 to 10 are rank SS (level 206 and up); SS rewards are extrapolated from the S-to-SS promotion row in `Data/World/guild_ranks.json` and are first-pass.
- **No answers given.** What the Titans were, why they left, what the machines are for, and what the storm guards stay unexplained. Every seed is labelled.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | What Was for Dinner | S | Investigation | Scholar Ysmere Quillbrook | A question about a meal |
| 2 | The Whale in the Tower | S | Escort | Hermit Oswin Thistlewake | A trapped, patient giant |
| 3 | The Bridge That Grows | S | Investigation | Bridge-Warden Sereth Skyhand | A machine that wants to finish |
| 4 | A Licence to Be Quiet | S | Faction | Licence-Officer Mirelle Tarn-Voss | A code of manners for two peoples |
| 5 | The Stranded Crew | S | Escort | Quartermaster Dessa Kell | Pirates with a dead airship |
| 6 | Thin Air | S | Hidden | Old Ruan Pelt | A hermit losing his words |
| 7 | Cuttings From the Hanging Garden | S | Gathering | Botanist Halloran Vesper-Moss | A tree that fruits upward |
| 8 | The Knife Goes Home | SS | Companion | Edda Brightmantle | A family's long errand |
| 9 | The Serpents' Amphitheatre | SS | Exploration | Songwright Calder Windfall | A choir without singers |
| 10 | The Count at the Edge of the Storm | SS | Investigation | Stormwatcher Veyra Cloudmantle | A thunder with a rhythm |

## Cast

<!-- npc
id: npc_ysmere_quillbrook
name: Scholar Ysmere Quillbrook
tier: major
race: Human
region: reg_sky_archipelago
settlement: The Set Tables
role: Scholar of Titan table customs
backstory: A rumpled, patient scholar who has spent three seasons at the Titan banquet hall and wants only to know what the feast was going to be.
-->
<!-- npc
id: npc_oswin_thistlewake
name: Hermit Oswin Thistlewake
tier: major
race: Human
region: reg_sky_archipelago
settlement: The tower ruins
role: Hermit who feeds a trapped sky whale
backstory: A weathered hermit who has camped beside a ruined tower for two seasons, singing to the sky whale caught in its stairwell.
-->
<!-- npc
id: npc_sereth_skyhand
name: Bridge-Warden Sereth Skyhand
tier: major
race: Heavenfolk
region: reg_sky_archipelago
settlement: The Broken Bridges
role: Heavenfolk warden of the Broken Bridges
backstory: A grave Heavenfolk who counts the bridges each month and is uneasy that one of them is getting longer.
-->
<!-- npc
id: npc_mirelle_tarn_voss
name: Licence-Officer Mirelle Tarn-Voss
tier: major
race: Human
region: reg_sky_archipelago
settlement: Expedition landing
role: Guild expedition licence officer
backstory: A brisk, tired guild officer who issues licences for the archipelago and is tired of being shouted at by both scholars and Heavenfolk.
-->
<!-- npc
id: npc_elder_quillon_aerith
name: Elder Quillon Aerith
tier: major
race: Heavenfolk
region: reg_sky_archipelago
settlement: Expedition landing
role: Heavenfolk elder who speaks for the sacred islands
backstory: A tall, dry-humoured Heavenfolk elder who dislikes visitors on principle and has never once refused a good argument.
-->
<!-- npc
id: npc_dessa_kell
name: Quartermaster Dessa Kell
tier: major
race: Human
region: reg_sky_archipelago
settlement: A grounded airship
role: Quartermaster of a stranded scavenger crew
backstory: A square, practical quartermaster whose airship lost its lift stones three weeks ago and who has rationed forty people on the same hall of white stone.
-->
<!-- npc
id: npc_ruan_pelt
name: Old Ruan Pelt
tier: townsfolk
race: Human
region: reg_sky_archipelago
settlement: A garden terrace
role: Hermit who has stayed too many seasons
backstory: A cheerful old hermit who has camped on one terrace for nine seasons and has begun to lose the names of ordinary things.
-->
<!-- npc
id: npc_halloran_vesper_moss
name: Botanist Halloran Vesper-Moss
tier: major
race: Halfling
region: reg_sky_archipelago
settlement: The Hanging Garden
role: Botanist studying the upward-fruiting trees
backstory: A small, tireless botanist who has catalogued eleven trees that grow their fruit toward the sky and one that does not.
-->
<!-- npc
id: npc_edda_brightmantle
name: Edda Brightmantle
tier: major
race: Human
region: reg_sky_archipelago
settlement: Expedition landing
role: Daughter of the expedition leader who brought back a Titan knife
backstory: A quiet woman of sixty whose mother carried a Titan's table knife down from the Highest Island and who has never forgiven the knife for being the reason her mother left again.
-->
<!-- npc
id: npc_calder_windfall
name: Songwright Calder Windfall
tier: major
race: Human
region: reg_sky_archipelago
settlement: The amphitheatre island
role: Songwright who listens to the wind serpents
backstory: A thin, restless songwright who has transcribed the wind serpents' nightly choir in an amphitheatre built for far larger audiences.
-->
<!-- npc
id: npc_veyra_cloudmantle
name: Stormwatcher Veyra Cloudmantle
tier: major
race: Heavenfolk
region: reg_sky_archipelago
settlement: The Highest Island's outer ledge
role: Heavenfolk stormwatcher
backstory: A calm Heavenfolk who has watched the circling storm for eleven years and has begun to suspect that it is counting.
-->

---

## 1. What Was for Dinner

*S · Investigation · the Set Tables · giver Scholar Ysmere Quillbrook*

**The short version.** The Titan banquet hall has stood laid for a feast for longer than anyone can say. Ysmere wants to know what the courses were.

**What is really going on.** The plates hold no food, only the pale dust of stone and glass. But the *service* is readable: forks by course, a bowl for each hand, and at the far end one setting laid *lower* than the rest, with a cup that fits no Titan. Ysmere does not need the menu. She needs someone to tell her whether it is all right to stop.

**Scene 1: the hall.** Ysmere has chalked the tables into squares.

**YSMERE:** "Three seasons. Four hundred settings. Not a crumb."
**YSMERE:** "I thought: if I know what they were going to eat, I know who they were expecting."
**YSMERE:** "Everyone asks what *happened.* Nobody asks what was for *dinner.*"
> ► **"What have you found?"** — **YSMERE:** "Courses. Eleven of them. The eleventh dish is *covered.*"
> ► **"Why does it matter?"** — **YSMERE:** "Because a laid table is a promise."
> ► **"Show me the covered dish."** — **YSMERE:** "Carefully. It is the size of a cart wheel."

**Scene 2: the long table.** The player walks the length of it. Dust shifts underfoot. Plates stand in rows, bowls the size of fountains, cups one could bathe in. Near the end, the settings shrink.

**YSMERE:** "There. A child's setting. Or a guest's. Or a servant's."
**YSMERE:** "The chair is *tall,* so they sat on a cushion. Look. A groove in the stone."
*The cup is the size of a mortal's pitcher. Beside it, set with great care, a spoon.*
**YSMERE:** "They laid a place for someone *our* size."

**Scene 3: the cover.** At the head of the hall stands the eleventh dish, a dome of white stone.

**YSMERE:** (quietly) "I have not lifted it. I told myself it was method."
**YSMERE:** "I think I have been afraid it is *empty.*"
> ► **"I'll lift it."** — The dome comes up. Beneath it: clean white stone and a single faint ring where something once stood. Ysmere breathes out. *It was not empty. It was* taken.
> ► **"Leave it covered."** — **YSMERE:** "...Yes. Perhaps a promise should stay sealed."
> ► **"Set a lamp beside it."** — The player lights a lantern at the small setting. The hall holds the glow a long time.

**Scene 4: the note.** Ysmere writes in her book, then stops and tears the page out.

**YSMERE:** "I'll write *'unknown.'* It is truer than a guess."

**Scene 3b: the cart wheel.** Before the lid is touched, Ysmere asks the player to sit with her at the small setting while she eats her lunch, a habit she began in the second season.

**YSMERE:** "I always bring bread. I put a crust on the child's plate. It seems only polite."
**YSMERE:** "The wind takes it by evening. I have never seen it go."
**YSMERE:** "My colleagues say I am sentimental. I say that a laid table is a *conversation,* and I would rather answer than analyse."
*She breaks the crust and sets half on the small plate. For a moment the whole hall seems to listen.*
**YSMERE:** "If I am wrong about all of it, I have still been a good guest."
> ► **"You are a good guest."** — She laughs, and wipes her eyes with her sleeve.

**Outcomes and receipt.**
- Lifted: the ring-mark becomes a Journal sketch; Ysmere publishes it as *a question,* not an answer. Left covered: she keeps the dome closed and marks the hall *'do not disturb.'* Lamp: the lantern is left burning, and later expeditions find it still lit.
- **Receipt:** a small spoon-shaped charm of white stone, from the child's setting; Ysmere will not take payment for it.
- **Canon-safe:** the identity of the intended guest is a pure seed and is never resolved.

<!-- quest
id: qst_sky_dinner
title: What Was for Dinner
rank: S
type: Investigation
giver: npc_ysmere_quillbrook
region: reg_sky_archipelago
level: 166
act: 5
requires_rank: S
reward: 66000 | 2900 | 305000
sets: sky_dinner_done
summary: A scholar wants to know what the Titans were going to eat at the Set Tables. The eleventh dish is still covered.
objectives:
  talk npc_ysmere_quillbrook
  reach sky_set_tables_eleventh_dish
  choice lift_leave_or_lamp
-->

---

## 2. The Whale in the Tower

*S · Escort · a ruined Titan tower · giver Hermit Oswin Thistlewake*

**The short version.** A sky whale drifted into a collapsed tower and cannot turn around. Oswin has fed it for two seasons. Winter winds are coming.

**What is really going on.** The tower is the problem *and* the nest: the whale has begun to treat its broken stairwell as a cradle. If the tower is cut away, the whale will not understand why it is leaving. Oswin does not want it hurt. He wants it *asked.*

**Scene 1: the camp.**

**OSWIN:** "Her name is Marra. I named her. It seemed rude not to."
**OSWIN:** "She came in after a storm. She cannot back out. Whales don't."
**OSWIN:** "The winds turn in nine days. After that the tower will shed stone on her."
> ► **"Can we break the tower?"** — **OSWIN:** "She will think it is the sky falling."
> ► **"What does she respond to?"** — **OSWIN:** "Humming. A low C. Bring something that hums."
> ► **"I'll help."** — **OSWIN:** "Bring a rope. A great deal of rope."

**Scene 2: the stairwell.** A spiral of white stone, wide as a street, and in it, filling it, the vast patient shape of a whale: finned wings folded, one eye the size of a cartwheel, watching the player with infinite calm. The air hums.

**MARRA (a deep, slow chord; subtitled):** *"...small ones... again..."*
> ► **"We've come to help."** — *The chord rises, curious.*
> ► **"Is it safe here?"** — *A low, sad note.*
> ► **"Can you go up?"** — *A long pause. Then:* "...*Up is where the roof fell.*"

**Scene 3: the three ways.** Oswin lays out what he has found.

**OSWIN:** "We can widen the east arch. It's old, but it holds the tower's weight."
**OSWIN:** "We can lead her down the stair a turn at a time, the way she came. She won't like going backward."
**OSWIN:** "Or we leave her, and I stay with her till spring."
> ► **"Widen the arch."** — The east arch is cut and Marra rises into open sky, but the tower groans and a wing of it falls.
> ► **"Guide her down the stair."** — Four days of humming, one turn at a time. Marra backs out slowly, whale-fashion, confused and gracious.
> ► **"Stay with her."** — Oswin nods. The player builds a windbreak and leaves supplies.

**Scene 4: the leaving.** However it is done, Marra eventually hangs in open air beside the tower, vast and amazed.

**OSWIN:** (hoarse) "Well. You didn't say goodbye."
*The whale circles once, sings a chord that makes the whole terrace ring, and drifts toward the clouds.*
**OSWIN:** "...She'll be back. They always come back to the one who named them."

**Scene 3b: the rope.** In the nine days before the winter winds, the player, Oswin and a dozen sky-hardy volunteers from the landing string guy-lines across the stair, to keep it from shedding stone onto the whale's back.

**OSWIN:** "If a pillar falls she will not know what hit her. She will only know it hurt."
**VOLUNTEER:** "Why do you sing to her? She can't understand the words."
**OSWIN:** "She understands that I am *there.* That is most of what a word is for."
*Each night he sits on the lowest step and tells the whale the day's news: which clouds came, which bird was rude. Marra answers with a single, rumbling note, like a cat settling.*
**OSWIN:** "Good girl. Sleep."
> ► **"Hum with him."** — The low C wavers, then steadies in two voices.

**Outcomes and receipt.**
- The arch: the whale is free fast; a Titan tower wing is lost. The stair: the slowest, kindest way; Oswin lets the player name the next whale. Staying: Marra winters in the tower; Oswin and the player share a quiet season.
- **Receipt:** a long, pale feather-baleen comb Oswin carved for Marra and left for the player.

<!-- quest
id: qst_sky_whale_tower
title: The Whale in the Tower
rank: S
type: Escort
giver: npc_oswin_thistlewake
region: reg_sky_archipelago
level: 168
act: 5
requires_rank: S
reward: 68000 | 3000 | 315000
sets: sky_whale_tower_done
summary: A sky whale has wedged into a ruined Titan tower. The winter winds are nine days away.
objectives:
  talk npc_oswin_thistlewake
  escort npc_oswin_thistlewake
  choice arch_stair_or_stay
-->

---

## 3. The Bridge That Grows

*S · Investigation · the Broken Bridges · giver Bridge-Warden Sereth Skyhand*

**The short version.** One of the Titans' broken bridges has grown forty paces since spring. Something is rebuilding it, and it is not hurrying.

**What is really going on.** A Titan machine, a pale many-limbed builder the height of a house, lays one white block a day. It is working from a plan that predates the island's drift, and the span is aimed at where the next island *was.* If it finishes, it will end in open air, like its brothers. Sereth is torn: the bridge is sacred, and so is the builder.

**Scene 1: the ledge.**

**SERETH:** "I count the bridges every new moon. This one is longer."
**SERETH:** "My grandmother counted it too. It was shorter, and then *not,* and then she stopped counting because it frightened her."
**SERETH:** "The sacred things are meant to be still."
> ► **"Have you seen what builds it?"** — **SERETH:** "Only at dusk. I do not go closer."
> ► **"Does it harm anyone?"** — **SERETH:** "No. That is the worry."
> ► **"I'll look."** — **SERETH:** "Be respectful. It may be a guest."

**Scene 2: the builder.** At dusk, from a crouch behind a fallen pillar, the player watches. A tall, pale shape unfolds from the bridge's end. Many hands. Each lays one block, presses it with a palm, and a thin line of gold crawls through the seam like a held breath.

**BUILDER (a soft chime; no words):** *chime, chime, rest.*
*It pauses at the span's end. A long arm lifts toward the horizon, toward where a distant shape floats a few miles off. Then it lowers, patient. Lays another block.*

**Scene 3: the plan.** The player finds a square of stone etched with lines, a diagram half worn by wind.

**SERETH:** "That is a plan. For *this* bridge. And that line is the old position of the island it joins."
**SERETH:** "It is aimed at an island that is not there."
> ► **"Tell it."** — The player taps the plan and points; the builder pauses. *Chime. Chime. A very long rest.*
> ► **"Let it finish."** — Sereth nods. "Then it ends in air. Like all of them."
> ► **"Move the island."** — Sereth stares. "...That cannot be done." The player does not argue.

**Scene 4: the dusk.** The builder lays its day's block. It does not change course. It does not stop.

**SERETH:** (softly) "It is not wrong. It is *faithful.*"
**SERETH:** "Is that better, or worse?"

**Scene 3b: the guest book.** On the bridge, beside the builder's work, Sereth keeps a small stone book where every visitor writes a line. Most write "I was here." Sereth writes a tally.

**SERETH:** "My grandmother's tally stops at forty-three. Mine is at nine hundred and six."
**SERETH:** "Each block is one day. I do not write when it rains, because the builder does not lay on rainy days. It is the only thing it respects."
**SERETH:** "A thing that respects the rain cannot be wholly foreign to us."
*She hands the player the pen. The player writes a line, and Sereth reads it, and says nothing, and turns the page gently.*
> ► **"Write a line for the builder."** — **SERETH:** "It will not read it. But I will."
> ► **"Add a tally."** — She nods, once.

**Outcomes and receipt.**
- Tell it: the builder pauses for a night, then resumes along the same line; Sereth takes this as a kind of reply. Let it finish: the guild is told the bridge is "alive, harmless, unfinished." Move the island: the player marks a drift chart for the Heavenfolk and the builder keeps building.
- **Receipt:** a hand-sized white block, warm to the touch for a day, that Sereth lets the player carry.
- **Canon-safe:** pure seed. What the builder is, who it serves and why it follows an old plan is never explained.

<!-- quest
id: qst_sky_bridge_grows
title: The Bridge That Grows
rank: S
type: Investigation
giver: npc_sereth_skyhand
region: reg_sky_archipelago
level: 170
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: sky_bridge_grows_done
summary: A Titan machine is rebuilding a broken bridge toward an island that drifted away long ago.
objectives:
  talk npc_sereth_skyhand
  reach sky_growing_bridge_end
  choice tell_finish_or_chart
-->

---

## 4. A Licence to Be Quiet

*S · Faction · Expedition landing · giver Licence-Officer Mirelle Tarn-Voss*

**The short version.** The guild licences expeditions. The Heavenfolk drive expeditions off. Mirelle wants a code of conduct both sides will sign before somebody gets hurt.

**What is really going on.** Neither side wants a war of manners. The Heavenfolk object not to *visitors* but to *noise, digging and taking.* The guild's scholars object to being treated as thieves. Both would accept a short list, if each side believed the other wrote half of it.

**Scene 1: the landing.**

**MIRELLE:** "Last month a Heavenfolk patrol turned back fourteen scholars. Nobody was hurt. Fourteen people have written to me about it."
**MIRELLE:** "I have a list of rules. They hate it. The Heavenfolk have a list of rules. The scholars hate *that.*"
> ► **"What do you need from me?"** — **MIRELLE:** "A neutral party. Someone who can walk between."
> ► **"What do the Heavenfolk want?"** — **MIRELLE:** "To be asked. Mostly."
> ► **"I'll talk to them."** — **MIRELLE:** "Be polite. They'll check."

**Scene 2: the elder.** Elder Quillon Aerith receives the player on a cold terrace and does not offer tea.

**QUILLON:** "The islands were taught to us by the Titans' own teachers. You dig where the teachers walked."
**QUILLON:** "You do not need to stay away. You need to *tread lightly.*"
**QUILLON:** "Tell your guild that a footprint is not a theft. A *spade* is."
> ► **"Would you accept a no-digging rule?"** — **QUILLON:** "Without the word 'except.'"
> ► **"Would you accept guided visits?"** — **QUILLON:** "...Possibly. By someone I choose."
> ► **"Would you accept an apology?"** — **QUILLON:** "For what? ...Ah. For the fourteen. That is *kind.*"

**Scene 3: the scholars.** Back at the landing a dozen scholars argue loudly over a map.

**SCHOLAR:** "A year of work! And I am to be *quiet?*"
**MIRELLE:** "You are to be *quiet near the sacred halls.* Not everywhere."
**SCHOLAR:** "...How is that not everywhere?"

**Scene 4: the signing.** The code is short: *No digging at the Set Tables. A Heavenfolk guide for the three sacred islands. Relics seen are drawn, not taken. A bell at each landing, rung on arrival.* Both parties sign on the same page, the guild on the left, the Heavenfolk on the right, a thumbwidth of blank paper between them.

> ► **(Add a clause for relic-taking in emergencies.)** — **QUILLON:** "Emergencies are what thieves are made of." The clause is cut.
> ► **(Add a clause for a yearly meeting.)** — Both parties laugh, then agree.
> ► **(Leave the code as is.)** — **MIRELLE:** "Short is good. Short gets read."

**Scene 3b: the bell.** On the second day a scholar, furious, rings the landing bell for a full minute before the code is even drafted, to prove it can be done.

**SCHOLAR:** "Is that a violation? There is no rule yet!"
**MIRELLE:** "There is a rule that you are *annoying.* It is old, and it is unwritten, and it applies to everyone."
**QUILLON:** (arriving, dry) "Bell-ringing is permitted. Over-ringing is a sign of insecurity."
*A ripple of laughter runs through both camps, the first time anyone on the landing has laughed in front of the other side.*
**MIRELLE:** (to the player, low) "Write that down. That is the thing that will get us a signature."
> ► **"Make the bell part of the code."** — Mirelle exhales. "Yes. Yes, make it the bell."

**Outcomes and receipt.**
- The code is signed in whatever form the player pushes. If the emergency clause is kept, it is the only rule the Heavenfolk later dispute. The yearly meeting becomes a festival.
- **Receipt:** a small brass landing bell with *both* factions' marks on it.

<!-- quest
id: qst_sky_licence_quiet
title: A Licence to Be Quiet
rank: S
type: Faction
giver: npc_mirelle_tarn_voss
region: reg_sky_archipelago
level: 170
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: sky_licence_quiet_done
summary: The guild licenses expeditions and the Heavenfolk drive them off. A neutral hand is needed for a code both will sign.
objectives:
  talk npc_mirelle_tarn_voss
  talk npc_elder_quillon_aerith
  choice no_dig_guides_or_meeting
-->

---

## 5. The Stranded Crew

*S · Escort · an airship wreck on a cold island · giver Quartermaster Dessa Kell*

**The short version.** Forty scavengers lost their lift stones and sit on a ledge. They came for relics. They want, now, only to go home.

**What is really going on.** The crew *are* scavengers, but they have not looted anything in three weeks. The captain has promised each of them a share that will not come. Dessa wants the player to carry the crew to the landing. The Heavenfolk would rather the crew be driven off than helped, and the guild would rather they be arrested.

**Scene 1: the ledge.**

**DESSA:** "Forty of us. Eleven days of food. Three of us are children."
**DESSA:** "Yes, we came for relics. Yes, that was stupid. Can we talk about that after we are *home?*"
> ► **"Where's your captain?"** — **DESSA:** "Sulking in the hold. He has not spoken since the lift stones died."
> ► **"What do you carry?"** — **DESSA:** "Rope. Lamps. Eleven days of food."
> ► **"I'll guide you."** — **DESSA:** "Thank you. I do not say that to many."

**Scene 2: the captain.** A broad man sits among crates and does not stand.

**CAPTAIN GALE-TALLY:** "A share, I told them. A share of the Set Tables silver."
**CAPTAIN GALE-TALLY:** "There is no silver. Only plates, and plates are not silver, and I have been a fool."
**DESSA:** "He has been a fool *loudly* for three weeks."
> ► **"Come with us."** — He rises, slowly.
> ► **"Stay if you want."** — **DESSA:** "He'll come. He is just proud."
> ► **"What do you owe them?"** — **CAPTAIN GALE-TALLY:** "An apology. And a boat."

**Scene 3: the crossing.** The path to the landing is a mile of bridge with holes in it. Forty people cross it in single file, the children roped between adults, the captain last.

**CHILD:** "Is it far?"
**DESSA:** "Not far."
**CHILD:** "You said that three miles ago."
**DESSA:** "I say it whenever I am sure of the *direction.*"
> ► **(Carry a child.)** — She holds on very tightly.
> ► **(Test the bridge ahead.)** — A loose slab is found and bypassed.
> ► **(Sing something.)** — Forty people hum along, off-key.

**Scene 4: the landing.** Mirelle's clerks wait with soup.

**MIRELLE:** "Names, please. And I will need to know what you took."
**DESSA:** "Nothing. We took *nothing,* and we would like that written down."
*She finds, in the crowd, the sixteen-year-old cook, and hugs him without a word.*

**Scene 3b: the night on the ledge.** Before the crossing, the crew spends a night in the lee of the wreck, and the player keeps watch with Dessa.

**DESSA:** "When I was a girl, I thought the sky was a ceiling. A very tall one."
**DESSA:** "I joined the crew to prove it was not. I have proved it. It is a floor, and I am standing on a bad part of it."
**DESSA:** "I do not blame the Titans for leaving. If I could have, I would have taken my table with me."
*Behind them a child coughs, and someone sings a lullaby under the breath. Dessa listens until it ends.*
**DESSA:** "Forty people. Three days home. I will not lose one."
> ► **"Neither will I."** — She nods, and does not say anything else.

**Outcomes and receipt.**
- Every crew member crosses unless the player fails the bridge. The guild fines the captain, not the crew, if the player speaks for them; if the player stays silent, the captain loses his licence entirely.
- **Receipt:** a tin whistle that belonged to the cook; it plays one note.

<!-- quest
id: qst_sky_stranded_crew
title: The Stranded Crew
rank: S
type: Escort
giver: npc_dessa_kell
region: reg_sky_archipelago
level: 172
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: sky_stranded_crew_done
summary: Forty scavengers lost their lift stones and are stranded on a cold island, with eleven days of food.
objectives:
  talk npc_dessa_kell
  escort npc_dessa_kell
  choice captain_fate_carry_or_sing
-->

---

## 6. Thin Air

*S · Hidden · a garden terrace · giver Old Ruan Pelt*

**The short version.** Ruan has camped on one terrace for nine seasons. He is losing the names of things. He wants someone to carry a letter down, and remember the letter for him.

**What is really going on.** The thin, cold air at this height thins memory too. Ruan is not ill; he is *tired of staying.* He has been hiding that he wants to go home, because he has told everyone he never would. The letter is to a granddaughter.

**Scene 1: the terrace.** A neat camp. Pots, a hanging kettle. On the stone wall, small labels in a cramped hand: *WALL. KETTLE. SKY.*

**RUAN:** "Hello. Hello, friend. Sit. Sit on the... the... the thing."
**RUAN:** "Stool."
**RUAN:** "Yes. *Stool.* It is going. They go in the afternoons."
> ► **"How long have you been here?"** — **RUAN:** "Nine seasons. Or ten. The kettle knows."
> ► **"Do you want to leave?"** — **RUAN:** "I told everyone I never would."
> ► **"Can I help?"** — **RUAN:** "A letter. If you would. I have it here. I think."

**Scene 2: the letter.** Ruan searches his coat three times. He finds it in the kettle.

**RUAN:** "To my granddaughter. Her name is... it is a flower. A... a..."
**RUAN:** "Heather. It is *Heather.*"
**RUAN:** "I have been writing the same letter for two years. It says *I am well.* It does not say *come and get me.*"
> ► **"Write that you miss her."** — **RUAN:** "That is the part I cannot *spell.*"
> ► **"Write that you are well."** — **RUAN:** "...That is what I wrote. It is not true."
> ► **"Write whatever you want."** — **RUAN:** "...Then I want to say it plainly."

**Scene 3: the walk down.** The player offers to carry Ruan, and he insists on walking. The path is long. He names things as they pass.

**RUAN:** "Cloud. Bridge. Cold. *Cold.* I remember cold."
**RUAN:** "Tell me the names again, if I lose them."
*By the second mile he has lost 'bridge.' By the third, he is humming instead.*

**Scene 4: the landing.** A girl of about seventeen sits at the landing with a bundle of heather. She has been coming every season.

**HEATHER:** "Grandfather."
**RUAN:** (a long pause) "...I know you."

**Scene 3b: the labels.** Before the descent, Ruan shows the player the whole camp, label by label, and the player learns what he is afraid to lose.

**RUAN:** "KETTLE. That is easy. STOOL. I got it back. HEATHER."
**RUAN:** "There is a label for her, on the wall, by my bed. I do not need to read it."
**RUAN:** "I am afraid that one day I will read it and not know why it is the biggest."
*He touches the label gently, as one touches a sleeping child's hair. Then he sits straight on the stool, and says it plainly: "I would like to go home now."*
> ► **"Then we'll go."** — He folds the label into his pocket.

**Scene 2b: the neighbours.** On the way down they pass the camps of other hermits, who raise a hand to Ruan without a word, and he raises one back, whole and certain.

**RUAN:** "That is the weaver. And that is the man who keeps bees, though I cannot think how. And that is... that is..."
**RUAN:** "A good neighbour. I will remember that, if nothing else."
*A woman at the next terrace calls out, "Going down at last, Ruan?" and he answers, with unexpected firmness, "Going home."*

**Outcomes and receipt.**
- If the letter said *come,* Heather brings a mule and a warm room. If it said only *well,* she sits with him until he asks to go home. If the player spoke for him, the thin-air forgetting eases a little at lower altitude.
- **Receipt:** a pressed sprig of heather, and a label in a cramped hand: *FRIEND.*

<!-- quest
id: qst_sky_thin_air
title: Thin Air
rank: S
type: Hidden
giver: npc_ruan_pelt
region: reg_sky_archipelago
level: 174
act: 5
requires_rank: S
reward: 72000 | 3100 | 330000
sets: sky_thin_air_done
summary: A hermit who has stayed too long is losing the names of things. He wants a letter carried to his granddaughter.
objectives:
  talk npc_ruan_pelt
  reach sky_landing_below_terrace
  choice miss_well_or_plain
-->

---

## 7. Cuttings From the Hanging Garden

*S · Gathering · the Hanging Garden · giver Botanist Halloran Vesper-Moss*

**The short version.** Eleven trees fruit upward. A twelfth fruits downward. Halloran wants a cutting from each, for a living record.

**What is really going on.** The twelfth tree is *old,* oldest of all, and its downward fruit falls forever through open sky. Halloran is not collecting for study; she is collecting so that a garden will *survive the island's eventual drift.* One cutting must be taken from the oldest tree, and it will cost the tree a branch.

**Scene 1: the roots.** The Hanging Garden is a forest whose roots dangle beneath the island in pale curtains.

**HALLORAN:** "I count eleven that fruit toward the sky. Plums, if plums were silver."
**HALLORAN:** "One tree does not. It drops its fruit into the clouds. I have never seen it land."
**HALLORAN:** "I do not want a *specimen.* I want a *seedling.*"
> ► **"Why a seedling?"** — **HALLORAN:** "Because islands drift. Someday this one may not be here."
> ► **"What will it cost the trees?"** — **HALLORAN:** "A twig each. The twelfth, a branch."
> ► **"I'll gather them."** — **HALLORAN:** "Bring paper. Wrap them damp."

**Scene 2: the eleven.** The player climbs among the root-curtains, collecting twigs. Each tree has a different silver smell: lemon, ash, rain.

**HALLORAN (calling up):** "Don't pull! *Coax!*"
*A root-curtain parts. Beyond it, a white bird sits on a branch, preening.*
**HALLORAN:** "That one is always there. I call her Madam."

**Scene 3: the twelfth.** An enormous trunk, silvered with age. Its fruit hangs below the island's lip, falling slowly, never reaching.

**HALLORAN:** "I cannot reach it. Nobody can. The branch is over open air."
**HALLORAN:** "I would not ask, but she is the oldest."
> ► **"I'll cut a branch."** — The player ties a rope and reaches out over the drop. A long, silvery branch comes away.
> ► **"I'll take a fruit instead."** — The player catches one, mid-fall, with a net. It weighs nothing at all.
> ► **"Leave her alone."** — **HALLORAN:** (after a moment) "...Yes. Eleven is a good number."

**Scene 4: the planting.** Halloran presses the cuttings into a long clay tray.

**HALLORAN:** "If these take, there will be a garden somewhere that did not have one."
**HALLORAN:** "I'll plant the first in Heavenreach. If they'll let me."

**Scene 3b: Madam.** While Halloran packs the trays, the white bird from the root-curtains lands on the player's shoulder and refuses to be shooed.

**HALLORAN:** "She has never done that. She dislikes everybody."
**HALLORAN:** "I think she's making an assessment."
**HALLORAN:** "If she approves of you, she will follow you to the terrace, and then she will be rude to the cuttings."
*The bird tilts her head, eyes the clay trays and utters one dry, scornful chirp.*
**HALLORAN:** "That is a yes. Possibly. With reservations."
> ► **"Take her with us."** — **HALLORAN:** "She will go where she pleases. She always has."

**Scene 2b: the damp wrapping.** Halloran teaches the player how to wrap a cutting so it survives the climb, with wet moss and a wick of wool.

**HALLORAN:** "A cutting is a very small, very stubborn person. It needs water, a little darkness, and someone who believes in it."
**HALLORAN:** "Talk to them, if you like. I do. I tell them what a lovely view they are about to leave."
*She tucks a twig into its cradle and strokes it once with a thumb.*
**HALLORAN:** "There. Brave little thing."

**Outcomes and receipt.**
- Branch: the twelfth tree is wounded but lives; the cutting takes in a week. Fruit: a single silver seed that sprouts a sapling with fruit that hangs *down.* Leave: eleven cuttings, and a promise to return.
- **Receipt:** a small clay pot with one of the trees, which blooms once a season at the player's quarters.

<!-- quest
id: qst_sky_hanging_garden
title: Cuttings From the Hanging Garden
rank: S
type: Gathering
giver: npc_halloran_vesper_moss
region: reg_sky_archipelago
level: 176
act: 5
requires_rank: S
reward: 75000 | 3200 | 340000
sets: sky_hanging_garden_done
summary: A botanist wants a cutting from each of twelve strange trees so a garden can outlast the drifting island.
objectives:
  talk npc_halloran_vesper_moss
  collect sky_garden_cutting 11
  choice branch_fruit_or_leave
-->

---

## 8. The Knife Goes Home

*SS · Companion · Expedition landing and the Set Tables · giver Edda Brightmantle*

**The short version.** Within living memory an expedition brought down a Titan's table knife the size of a man. It has sat in a guild vault ever since. Edda wants it carried back.

**What is really going on.** Edda's mother led that expedition and went back up alone a year later. She did not return. Edda has never decided whether she wants the knife back at the Tables to *finish the meal* or to *follow her mother.* The honest answer is that she wants permission to stop being angry.

**Scene 1: the vault.** A cold stone room. The knife lies on a rack: a long blade of pale, dull metal.

**EDDA:** "It is heavier than it looks. Heavier than Mother was."
**EDDA:** "She said, once, that it felt like it had been *set down* for a moment."
**EDDA:** "I think it should go back."
> ► **"Why now?"** — **EDDA:** "Because I am sixty, and she is not coming to ask for it."
> ► **"Will the guild release it?"** — **EDDA:** "I have the signature. It took eleven years."
> ► **"I'll carry it with you."** — **EDDA:** "That is all I wanted to hear."

**Scene 2: the climb.** Edda is not young, and the knife is not light. The player and Edda carry it between them up the long white stair, resting at each landing.

**EDDA:** "Mother used to say the stairs were too wide for us. As if the Titans were expecting someone larger."
**EDDA:** "I always wondered who."
*A wind turns; the knife hums faintly in its wrapping.*
**EDDA:** "It *likes* it up here."

**Scene 3: the table.** At the Set Tables, a place is laid for the knife: an empty slot on the table's edge, polished by the wind.

**EDDA:** "That is where it goes. I looked, in Mother's notes. A drawing of the setting. A knife-shaped gap."
> ► **"Set it down."** — The knife slides into the gap with a soft click. The table seems to settle.
> ► **"Let Edda do it."** — Edda lays her hand on the hilt. Her shoulders drop.
> ► **"Wait."** — Edda hesitates, then says, "No. I want to do it now."

**Scene 4: the note.** Behind the setting, Edda finds a folded paper held down by a stone: her mother's writing. It is short.

**EDDA:** (reading) "*'Edda: I was wrong to take it. I'm going to stay a little longer. Don't worry. Eat something.'*"
*She laughs, and then she cannot stop.*

**Scene 3b: the stair.** Halfway up the great stair, Edda sits down hard on a step and does not get up for several minutes.

**EDDA:** "Forgive me. My knees are sixty. The rest of me is eleven."
**EDDA:** "She left on a morning like this. I stood at the foot of these steps and said: *you will be back for dinner.*"
**EDDA:** "That was the last thing I ever said that was a lie and a prayer at once."
*The player waits. Below, the wind carries the faint, far sound of the landing bell.*
**EDDA:** "I think I am ready now. Give me your arm. No, the other one."
> ► **"Take the other arm."** — She laughs, and they go on.

**Outcomes and receipt.**
- Whichever way the knife is set down, it stays: the gap is closed, the table whole. If Edda is allowed to place it herself, she reads the note aloud to the empty hall.
- **Receipt:** a small whittled knife from Edda: *"For cutting something worth cutting."*
- **Canon-safe:** what became of Edda's mother is **not** answered. The note is a seed.

<!-- quest
id: qst_sky_knife_home
title: The Knife Goes Home
rank: SS
type: Companion
giver: npc_edda_brightmantle
region: reg_sky_archipelago
level: 206
act: 5
requires_rank: SS
reward: 140000 | 6000 | 650000
sets: sky_knife_home_done
summary: A family has kept a Titan's table knife for two generations. Its keeper wants it carried back to the Set Tables.
objectives:
  talk npc_edda_brightmantle
  escort npc_edda_brightmantle
  choice set_edda_or_wait
-->

---

## 9. The Serpents' Amphitheatre

*SS · Exploration · the amphitheatre island · giver Songwright Calder Windfall*

**The short version.** Each night the wind serpents gather in a vast Titan amphitheatre and sing, though nobody is there to hear them. Calder has the first twelve bars. He cannot find the thirteenth.

**What is really going on.** The serpents are rehearsing something that was *taught* to them. The song is incomplete because the last section was never sung, or never recorded; there is a gap, and the serpents leave it, every night, exactly the same length.

**Scene 1: the seats.**

**CALDER:** "A hundred thousand seats. Built for creatures I will never meet."
**CALDER:** "The serpents arrive at moonrise. They coil on the stage. They sing for exactly one hour."
**CALDER:** "And every night they stop in the same place, and wait. For something."
> ► **"What do they wait for?"** — **CALDER:** "I think, an answer."
> ► **"Can you write it?"** — **CALDER:** "Twelve bars. I hear the thirteenth in my head and I do not know if it is mine."
> ► **"I'll listen."** — **CALDER:** "Sit at the back. They dislike being stared at."

**Scene 2: the night.** At moonrise, shapes slide into the arena: long, translucent serpents, each as long as a ship, coiling slowly into a ring. One draws breath. The air itself becomes a note.

**SERPENT CHOIR (soft, layered; subtitled):** *a rising, aching phrase, then eleven more, each answered by the next*
*On the twelfth bar they all stop. The silence is exact. It is long. Nobody moves.*
**CALDER:** (whispering) "There. *There.*"

**Scene 3: the answer.** The player and Calder discuss what to do in the silence.

> ► **"Sing a bar."** — The player sings, badly. The serpents tilt their heads. One flicks its tail and the sound dissolves into laughter-like ripples.
> ► **"Play the thirteenth Calder hears."** — Calder raises his flute and plays. The serpents listen with their whole bodies; after a long moment, the lead serpent *responds,* in a different key.
> ► **"Stay silent."** — The silence continues. The serpents wait, then slowly disperse. Calder nods.

**Scene 4: the morning.** Calder lowers his flute.

**CALDER:** "They did not take it. They did not *refuse* it. They *considered* it."
**CALDER:** "I think that's the most polite thing anyone's ever done to my music."

**Scene 2b: the first night.** Before the real hearing, Calder explains what the transcription cost him: three notebooks, two flutes, and the trust of a patron who wanted something he could sell.

**CALDER:** "The patron wanted a symphony. I gave him a field recording. He called it *'an unfinished wind.'*"
**CALDER:** "I think the serpents would agree with him. I think they know it is unfinished."
**CALDER:** "That is why they stop. Not because they have forgotten. Because they are being *careful.*"
*The first of the serpents drifts over the empty seats like a silk banner, and the whole stage hums.*
**CALDER:** "Do you feel it? In the teeth?"
> ► **"I feel it in my chest."** — **CALDER:** "That is where it was written for."

**Outcomes and receipt.**
- Sing or play: the serpents add one note to the next night's song, a new thirteenth bar that no one wrote. Silence: they keep the gap, and Calder transcribes it as a rest.
- **Receipt:** a wind-chime of shed serpent scale that rings the same twelve bars in any breeze.
- **Canon-safe:** pure seed. Who taught the serpents, and what the gap is for, are never explained.

<!-- quest
id: qst_sky_serpent_choir
title: The Serpents' Amphitheatre
rank: SS
type: Exploration
giver: npc_calder_windfall
region: reg_sky_archipelago
level: 208
act: 5
requires_rank: SS
reward: 145000 | 6200 | 670000
sets: sky_serpent_choir_done
summary: Wind serpents sing in a Titan amphitheatre every night and stop at the same bar. A songwright wants to know what they wait for.
objectives:
  talk npc_calder_windfall
  reach sky_amphitheatre_stage
  choice sing_play_or_silence
-->

---

## 10. The Count at the Edge of the Storm

*SS · Investigation · the Highest Island's outer ledge · giver Stormwatcher Veyra Cloudmantle*

**The short version.** The storm around the Highest Island has thundered for decades. Veyra has noticed that it *rolls* in a pattern. She wants a second pair of ears, at the edge.

**What is really going on.** The storm is not a weather event Veyra can predict; it is a *rhythm,* like a very slow pulse. Veyra's fear is not that the storm will reach her. It is that something inside is *counting down.* The player is not going in; the Highest Island is not touched. The quest is listening.

**Scene 1: the ledge.**

**VEYRA:** "Eleven years. Every night I count the thunder. Forty-one, then a pause, then forty-one."
**VEYRA:** "Last winter it was forty. This winter, forty-one again. I think it has been waiting."
**VEYRA:** "I want you to count with me. In case I am wrong."
> ► **"Why not the guild?"** — **VEYRA:** "They would say it is weather."
> ► **"What do you think it counts?"** — **VEYRA:** "I do not like to say."
> ► **"I'll count."** — **VEYRA:** "Two tallies. Mine and yours. Then we compare."

**Scene 2: the night.** The wind is a wall. Lightning walks the clouds in great pale columns. The player and Veyra sit under a stone lip, tallies in hand.

**VEYRA:** "Thirty-nine. Forty. Forty-one."
*A silence so long the player thinks it is over. Then the first thunder of the next set.*
**VEYRA:** "There. It begins again. Do you hear it? The *spacing* has a shape."

**Scene 3: the pattern.** By the third set, the tallies agree.

**VEYRA:** "Forty-one, and then a lull of forty-one breaths. The same number, twice."
**VEYRA:** "Whatever is counting, it is counting *itself.*"
> ► **"It might be a lock."** — **VEYRA:** "Or a heartbeat. Or a prayer."
> ► **"Don't go closer."** — **VEYRA:** "I was never going to. I only wanted to be *less alone* with it."
> ► **"Write it down for the guild."** — **VEYRA:** "They will not believe it. But it should be written."

**Scene 4: the dawn.** The storm quiets, as it does, for a single hour. The Highest Island is a dark shape behind the cloud.

**VEYRA:** "Thank you. I could not have said it aloud to anyone who would not agree."
*She folds her tally into the player's palm.*
**VEYRA:** "If it changes, tell me. Whatever you hear."

**Scene 3b: the rest between sets.** In the forty-first breath, Veyra shows the player the pocket notebook where she has kept her tallies, a thousand pages of numbers in small, careful rows.

**VEYRA:** "In eleven years I have never missed a night. I was ill once, and a hawk kept the count for me."
**VEYRA:** "I know it sounds foolish. But it is *company.*"
**VEYRA:** "Whatever is in there, it has been counting for longer than I have. It seems rude to stop listening."
*Thunder rolls once, a long, low note, then silence. The player begins to count. The silence is exactly as long as Veyra said.*
**VEYRA:** "There. You hear it? You are not imagining it."
> ► **"I hear it."** — She lets out a breath she has held for eleven years.

**Outcomes and receipt.**
- The tallies are filed with the Heavenfolk and the guild as *"observations"* only. If the player recommends the guild post a watch, a second watcher is sent; if not, Veyra keeps her post alone.
- **Receipt:** the folded tally, in two hands, and a copper whistle Veyra uses to call her hawk.
- **Canon-safe:** pure seed. It does **not** identify what the storm guards, say who lives on the Highest Island, mention Zephiel or imply any danger.

<!-- quest
id: qst_sky_storm_count
title: The Count at the Edge of the Storm
rank: SS
type: Investigation
giver: npc_veyra_cloudmantle
region: reg_sky_archipelago
level: 210
act: 5
requires_rank: SS
reward: 150000 | 6500 | 700000
sets: sky_storm_count_done
summary: A stormwatcher has noticed that the storm around the Highest Island thunders in a pattern. She wants a second set of ears.
objectives:
  talk npc_veyra_cloudmantle
  reach sky_highest_island_ledge
  choice lock_alone_or_record
-->
