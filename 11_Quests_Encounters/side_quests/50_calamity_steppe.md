# 11e-50 — Calamity Steppe, the Land of Calamities: Ten Side Quests (draft)

> *"Never name a monster on the steppe until you are off it."*
> — guild cartographers' saying, Gazetteer, Calamity Steppe

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[second_set_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 3 and 8 plant unexplained seeds.

**Region:** `reg_calamity_steppe` (the eastern edge and watchtowers, the open grass, the Salt Pans, the Tusks). **Rank band:** S–SS. **Tone:** vast, quiet, dangerous and unexpectedly tender; giants that mostly want to eat grass; small people doing careful, stubborn work among them.

**Placement notes.**
- The steppe has **no Tyrant, no settlements and no siege.** Nobody lives there; every NPC in this file is an expedition member, a guild officer, a pilgrim or a hermit, met at the **edge, in a caravan or at a watchtower.** No quest kills a Calamity or any named giant, and none explains why Calamities are walking the same way this year.
- Customs the quests rely on: **never name a monster on the steppe until you are off it** (the file's monsters are called by descriptions, not names, while on the grass); the eastern clans leave offerings at the steppe's edge to keep the first monsters where they are; the guild charts monster trails like rivers and issues licences only to the highest ranks; the grass closes trails within days.
- **Rank note.** Quests 1-6 are S; quests 7-10 are SS (level 206+). SS rewards are first-pass and extrapolated from the guild promotion table (S to SS: level 205, GP 50,000; see `Data/World/guild_ranks.json`).
- Quest 6 collects `steppe_ship_bird_feather`, a plain descriptive id that does not exist in `Data/Items`; the validator does not check collect targets.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Chart Without Names | S | Investigation | Cartographer Brevin Tarrant | Mapping the unnameable |
| 2 | What the Clans Leave at the Edge | S | Hidden | Offering-Keeper Ruuk Dawnpaw | A very small gift |
| 3 | The Trail That Bends | S | Investigation | Tower-Warden Cadogan Pike | Giants all turning one way |
| 4 | Fights at the White Flats | S | Escort | Scholar Fitzroy Amberlane | A researcher, a salt lick, a rule |
| 5 | The Hermit's Crater Garden | S | OddJob | Hermit Bellamy Quarrel | A garden where no garden should be |
| 6 | A Feather as Long as a Boat | S | Gathering | Skywatcher Corra Windfall | A shed feather, a nest, a chick |
| 7 | Beneath the Grass | SS | Exploration | Caravan-Mistress Dunya Ironwheel | A wagon in a burrow |
| 8 | The Hollow Inside the Tusks | SS | Exploration | Bone-Reader Jorun Tuskward | A ring and its footprints |
| 9 | The Grave the Grass Closed | SS | OddJob | Captain Rhosyn Fellowes | A brother's cairn, a rope |
| 10 | The Calf in the Dry River | SS | Faction | Beastmaster Wrenna Grassmantle | A small giant and a herd |

## Cast

<!-- npc
id: npc_brevin_tarrant
name: Cartographer Brevin Tarrant
tier: major
race: Human
region: reg_calamity_steppe
settlement: The eastern watchtowers
role: Guild cartographer of monster trails
backstory: A dry, tireless guild cartographer who has charted eleven Calamity trails and has never once spoken a monster's name on the grass, and who keeps a notebook of the descriptions she uses instead.
-->
<!-- npc
id: npc_ruuk_dawnpaw
name: Offering-Keeper Ruuk Dawnpaw
tier: major
race: Wolfkin
region: reg_calamity_steppe
settlement: The steppe's eastern edge
role: Wolfkin offering-keeper at the steppe's edge
backstory: A grey-muzzled Wolfkin of the eastern clans who has laid offerings on the steppe's edge for fifty years and who has begun to suspect that something out there has started leaving offerings back.
-->
<!-- npc
id: npc_cadogan_pike
name: Tower-Warden Cadogan Pike
tier: major
race: Human
region: reg_calamity_steppe
settlement: The eastern watchtowers
role: Warden of the northernmost guild watchtower
backstory: A stooped, methodical warden who counts the Calamities leaving the steppe and who has spent the year staring at a chart on which every trail bends the same way.
-->
<!-- npc
id: npc_fitzroy_amberlane
name: Scholar Fitzroy Amberlane
tier: major
race: Human
region: reg_calamity_steppe
settlement: The Salt Pans
role: Scholar of giant behaviour
backstory: A cheerful, ink-stained scholar who has watched the giants fight over salt for three seasons from a hide a mile off and who has decided, against all advice, to get closer.
-->
<!-- npc
id: npc_bellamy_quarrel
name: Hermit Bellamy Quarrel
tier: townsfolk
race: Human
region: reg_calamity_steppe
settlement: The open grass
role: Hermit who grows a garden in a crater
backstory: A weathered, polite hermit of seventy who walked onto the steppe nine years ago to die and has instead been growing peas in a footprint-crater, undisturbed by anything.
-->
<!-- npc
id: npc_corra_windfall
name: Skywatcher Corra Windfall
tier: major
race: Human
region: reg_calamity_steppe
settlement: The eastern watchtowers
role: Watcher of the ship-sized birds
backstory: A lean, patient watcher who has spent six years counting the huge birds that ride the thermals and who needs one of their shed feathers for the guild's collection.
-->
<!-- npc
id: npc_dunya_ironwheel
name: Caravan-Mistress Dunya Ironwheel
tier: major
race: Human
region: reg_calamity_steppe
settlement: The armoured caravan
role: Mistress of an armoured steppe caravan
backstory: A stout, unflappable caravan-mistress who has crossed the steppe nineteen times with a wagon train of S-rank scholars and who has just lost a wagon through the ground.
-->
<!-- npc
id: npc_jorun_tuskward
name: Bone-Reader Jorun Tuskward
tier: major
race: Human
region: reg_calamity_steppe
settlement: The Tusks
role: Bone-reader who studies the Tusks
backstory: A quiet, lanky scholar who reads old bone as others read books and who has walked the ring of the Tusks nineteen times, counting the footprints.
-->
<!-- npc
id: npc_rhosyn_fellowes
name: Captain Rhosyn Fellowes
tier: major
race: Human
region: reg_calamity_steppe
settlement: The armoured caravan
role: Expedition captain looking for a grave
backstory: A grim, careful captain whose younger brother died on the steppe six years ago and who has come back with a coil of rope and a star-chart to find the cairn the grass has since closed.
-->
<!-- npc
id: npc_wrenna_grassmantle
name: Beastmaster Wrenna Grassmantle
tier: major
race: Human
region: reg_calamity_steppe
settlement: The Salt Pans
role: Beastmaster who watches a calf
backstory: A calm, grass-stained beastmaster who has followed a single lost behemoth calf across the steppe for a month and who will not let it be eaten.
-->

---

## 1. The Chart Without Names

*S · Investigation · the eastern edge · giver Cartographer Brevin Tarrant*

**The short version.** Brevin must chart a fresh Calamity trail across the grass. Guild superstition forbids naming a monster until you are off the steppe, and she means to follow it to the letter. She needs a partner who can describe without naming.

**What is really going on.** The rule is half superstition and half method. A name pins a thing to a place; a description lets it move. Brevin's trick is to chart a trail by what it *does:* a flattened mile, a salt-lick drained, a dry river bent. The player learns to see the beast through its footprints.

**Scene 1: the tower.**

**BREVIN:** "Eleven trails. Never a name. Not once."
**BREVIN:** "You will say 'the big one,' 'the wide one,' 'the one that sighed.' You will not say what it *is.*"
**BREVIN:** "Not until we're back at the tower."
> ► **"Is it just superstition?"** — **BREVIN:** "Mostly. I'd rather not find out about the rest."
> ► **"What do we need?"** — **BREVIN:** "Eyes, ink, patience. And a strong stomach."
> ► **"I'll partner."** — **BREVIN:** "Good. No names."

**Scene 2: the trail.** A day into the grass, under a huge sky, the two reach a swathe of flattened stalks a quarter-mile wide, and a hollow where something has lain down.

**BREVIN:** "Describe it."
> ► **"Wide. Heavy. Slow."** — **BREVIN:** "Acceptable."
> ► **"It slept here."** — **BREVIN:** "Better. Why?"
> ► **"It's called a..."** — **BREVIN:** "*Don't.*"

**Scene 3: the almost.** At dusk, on a low rise, the trail's maker comes into view as a hill that moves. The player must not name it, and must keep Brevin from naming it, and must keep the caravan oxen quiet.

> ► **(Whisper a description.)** — Brevin writes it down.
> ► **(Say nothing.)** — A long silence.
> ► **(Give it a pet name under your breath.)** — The grass hisses.

**Scene 4: the tower.** Back at the tower, Brevin finally says the name aloud, once, to an empty room.

**BREVIN:** "There. That's the first time in two years."
**BREVIN:** "It sounds smaller indoors."

**Outcomes and receipt.**
- The trail is charted without names. If the player gave the beast a pet name, the chart is marked "unreliable" and Brevin smiles about it.
- **Receipt:** a chart with seven descriptions and no names, framed on the tower wall.

<!-- quest
id: qst_cal_chart_no_names
title: The Chart Without Names
rank: S
type: Investigation
giver: npc_brevin_tarrant
region: reg_calamity_steppe
level: 164
act: 5
requires_rank: S
reward: 66000 | 2850 | 300000
sets: cal_chart_no_names_done
summary: A cartographer must chart a Calamity trail without ever naming the beast that made it.
objectives:
  talk npc_brevin_tarrant
  reach steppe_flattened_swathe
  choice describe_silent_or_pet
-->

---

## 2. What the Clans Leave at the Edge

*S · Hidden · the steppe's eastern edge · giver Offering-Keeper Ruuk Dawnpaw*

**The short version.** For fifty years Ruuk has left offerings of meat and braided grass at the steppe's edge to keep the first monsters where they are. This morning, beside his bowl, someone has left one back.

**What is really going on.** It is a knot of grass, braided with stalks of a kind that grows nowhere near the edge. No one has seen who left it. The gesture is small, kind and entirely unexplained. The player's job is to decide how to answer.

**Scene 1: the edge.**

**RUUK:** "Fifty years I have laid this bowl. Nothing has ever touched it but crows."
**RUUK:** "And now this."
*In the grass beside the bowl, a small, tight knot of green blades, neatly braided.*
> ► **"Who left it?"** — **RUUK:** "I do not know. That is why I asked you."
> ► **"Is it dangerous?"** — **RUUK:** "I think it is *polite.*"
> ► **"What do you want to do?"** — **RUUK:** "Answer it. I do not know how."

**Scene 2: the watch.** For a night and a day the two wait on the edge, lantern low. The steppe breathes. Once, very far off, a great shape lifts its head and lowers it again.

**RUUK:** "My grandmother said: you leave the offering and you leave quickly."
**RUUK:** "I have always stayed. I have never known why."
> ► **"Stay a while."** — The wind rises, then falls.
> ► **"Leave, as the custom says."** — Ruuk hesitates.
> ► **"Speak to it."** — **RUUK:** "Gently."

**Scene 3: the answer.** At dusk, Ruuk braids a second knot from the bowl's grass and sets it in the same place. The player is asked to add something of their own.

> ► **(A feather.)** — It catches the wind.
> ► **(A small stone.)** — It sits quietly.
> ► **(Nothing. Only your hand beside his.)** — Ruuk nods.

**Scene 4: the morning.** In the grey light, the knot is gone. In its place, a smooth, white pebble no bigger than a thumbnail.

**RUUK:** "...Fifty years."
**RUUK:** "I shall keep it."

**Outcomes and receipt.**
- A tiny correspondence begins. If the player left nothing, Ruuk's second knot is unanswered for a week, and then the pebble comes anyway.
- **Receipt:** a white pebble on a string around Ruuk's neck.
- **Canon-safe:** this is a **pure seed.** Who or what left the first knot is **unexplained.**

<!-- quest
id: qst_cal_clan_offering
title: What the Clans Leave at the Edge
rank: S
type: Hidden
giver: npc_ruuk_dawnpaw
region: reg_calamity_steppe
level: 168
act: 5
requires_rank: S
reward: 68000 | 2950 | 310000
sets: cal_clan_offering_done
summary: After fifty years of offerings at the steppe's edge, something has left one back.
objectives:
  talk npc_ruuk_dawnpaw
  reach steppe_eastern_edge_bowl
  choice feather_stone_or_hand
-->

---

## 3. The Trail That Bends

*S · Investigation · the northernmost watchtower · giver Tower-Warden Cadogan Pike*

**The short version.** Cadogan has charted every Calamity that left the steppe this year. Every trail, however it began, bends the same way. He wants someone to walk the bend and tell him what is there.

**What is really going on.** There is nothing there. At the bend, in the open grass, the trails curve in a long, graceful arc around a spot that is, as far as anyone can see, entirely ordinary. The giants do not touch it, do not name it and do not stop. The quest ends on the arc.

**Scene 1: the chart.**

**CADOGAN:** "Forty-one trails. They begin north, south, west. They end east."
**CADOGAN:** "And in the middle, every one of them *bends.*"
**CADOGAN:** "I am not a fanciful man. I would like to be wrong."
> ► **"Where's the bend?"** — **CADOGAN:** "Two days out. A grassy patch."
> ► **"Is it a hazard?"** — **CADOGAN:** "Not that anyone has said."
> ► **"I'll walk it."** — **CADOGAN:** "Take chalk. Mark the line."

**Scene 2: the walk.** Two days across the grass, the sky wide and blue. Ahead, a faint pattern in the stalks: a long curve of flattened green.

*The arc is half a mile across. Inside it, the grass is waist-high and untouched. Birds sing in it.*
> ► **"Walk the edge."** — A slow circle.
> ► **"Step inside."** — The air is very still.
> ► **"Measure the curve."** — Perfectly regular.

**Scene 3: the centre.** At the centre, a patch of ordinary soil, a flat stone and nothing else. No bones, no carvings, no magic the player can detect.

**JOURNAL (auto):** *The stone is smooth, grey and warm from the sun. It has no markings. The grass around it is slightly greener.*
> ► **(Sit on the stone.)** — It is just a stone.
> ► **(Chalk the arc and leave.)** — **CADOGAN (later):** "Good."
> ► **(Dig beneath it.)** — A foot down, there is only earth.

**Scene 4: the chart.** Back at the tower, Cadogan adds the arc to the map, and, after a long time, a small circle in its centre.

**CADOGAN:** "I thought it would be a thing."
**CADOGAN:** "It is only a place. They are all going round it."

**Outcomes and receipt.**
- The arc is charted. If the player dug, the soil is replaced and nothing changes.
- **Receipt:** a small circle on a chart, labelled by Cadogan in pencil: "Unknown."
- **Canon-safe:** this is a **pure seed.** Why the Calamities bend, and where they are going, is **not explained.**

<!-- quest
id: qst_cal_trail_bends
title: The Trail That Bends
rank: S
type: Investigation
giver: npc_cadogan_pike
region: reg_calamity_steppe
level: 172
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: cal_trail_bends_done
summary: Every Calamity trail charted this year bends around the same empty patch of grass.
objectives:
  talk npc_cadogan_pike
  reach steppe_the_bend
  choice sit_chalk_or_dig
-->

---

## 4. Fights at the White Flats

*S · Escort · the Salt Pans · giver Scholar Fitzroy Amberlane*

**The short version.** Fitzroy has watched the giants fight over salt for three seasons from a hide a mile off. He wants to get close enough to see why they stop. He needs an escort across the white.

**What is really going on.** The fights are not to the death. They are, Fitzroy believes, a ritual: two giants lock horns, push, and at some moment *both* back away. He wants to witness the moment of release. The player must keep him alive, quiet and downwind.

**Scene 1: the hide.**

**FITZROY:** "Three seasons. A hundred and four fights. Not one death."
**FITZROY:** "I'd like to know what makes them stop."
**FITZROY:** "I should warn you I have a terrible sense of danger."
> ► **"What do you need?"** — **FITZROY:** "A chaperone. And a very long lens."
> ► **"How close?"** — **FITZROY:** "A quarter mile."
> ► **"I'll escort you."** — **FITZROY:** "Splendid! Don't let me wander."

**Scene 2: the white.** The Salt Pans glare under the sun. In the distance, two shapes the size of hills circle each other, slow as tides.

**FITZROY:** (whispering) "There. The one with the broken horn."
*The two giants lower their heads. The sound of the impact rolls across the flats.*
> ► **"Stay down."** — Fitzroy flattens.
> ► **"Move to the lee."** — Salt crunches underfoot.
> ► **"Keep your lens steady."** — Fitzroy steadies.

**Scene 3: the release.** The giants push, groan and lean. At the third minute, one makes a small, low sound, and both step back at the same instant.

**FITZROY:** "...It *called* it."
**FITZROY:** "One of them said 'enough.' I'm certain."
> ► **"Write it down."** — He scribbles frantically.
> ► **"Did it look hurt?"** — **FITZROY:** "No. Relieved."
> ► **"Time to go."** — A third giant looms.

**Scene 4: the retreat.** A cloud of salt rises as the third giant lumbers toward them. The player and Fitzroy retreat to the hide in a shambling run.

**FITZROY (panting):** "I think it was only curious."
**FITZROY:** "I think *I* was the interesting one."

**Outcomes and receipt.**
- Fitzroy returns with the observation. If the player rushed him, he missed the release and has to wait a season to see another.
- **Receipt:** a field-book page titled "On the Courtesy of Giants."

<!-- quest
id: qst_cal_white_flats
title: Fights at the White Flats
rank: S
type: Escort
giver: npc_fitzroy_amberlane
region: reg_calamity_steppe
level: 176
act: 5
requires_rank: S
reward: 72000 | 3100 | 330000
sets: cal_white_flats_done
summary: A scholar wants to see why giants who fight over salt always stop. He needs an escort across the Salt Pans.
objectives:
  talk npc_fitzroy_amberlane
  escort npc_fitzroy_amberlane
  reach steppe_salt_pans_fight
  choice down_lee_or_steady
-->

---

## 5. The Hermit's Crater Garden

*S · OddJob · the open grass · giver Hermit Bellamy Quarrel*

**The short version.** Bellamy walked onto the steppe nine years ago to die. He has instead grown peas in a footprint-crater, and something large keeps stepping carefully round the edge. He wants help carrying a harvest out.

**What is really going on.** The garden survives because the giants avoid it. Whether out of tenderness or mere habit, nobody knows. Bellamy does not want to be rescued. He wants his peas to reach someone who has never eaten a steppe-grown pea.

**Scene 1: the crater.**

**BELLAMY:** "I came to be eaten. I think they find me too stringy."
**BELLAMY:** "The soil is marvellous. Rich as butter."
**BELLAMY:** "I've forty pounds of peas and no one to give them to."
> ► **"You've lived here nine years?"** — **BELLAMY:** "Nine and a half. I count the winters."
> ► **"Aren't you afraid?"** — **BELLAMY:** "Constantly. It keeps the knees limber."
> ► **"I'll carry them."** — **BELLAMY:** "Bless you. They shell best at dusk."

**Scene 2: the harvest.** A long, domestic afternoon, picking and shelling in the crater's lee. A great shadow passes over the rim and does not stop.

**BELLAMY:** "That's the old one. Every evening, round about now. Goes round the crater. Never in."
> ► **"Wave to it."** — **BELLAMY:** "Don't encourage it."
> ► **"Offer it a pea."** — **BELLAMY:** "...Good heavens."
> ► **"Stay still."** — The shadow moves on.

**Scene 3: the road.** At dawn the two set out east with six sacks of peas, a very small donkey and a rather large amount of dignity.

**BELLAMY:** "I haven't walked this far since I came."
> ► **"Go slowly."** — He grins.
> ► **"Take my arm."** — He accepts.
> ► **"We could leave some for the giant."** — **BELLAMY:** "Oh, I've already left some."

**Scene 4: the tower.** At the watchtower, the garrison queues for peas. Bellamy, seventy and sunburned, accepts a chair and a cup of tea.

**BELLAMY:** "I never meant to be a gardener."
**BELLAMY:** "I'd like to go back, you know. If someone could look after the donkey."

**Outcomes and receipt.**
- The peas are delivered; Bellamy chooses to return to his crater. If the player offered the giant a pea, a single enormous footprint is found beside the garden next spring.
- **Receipt:** a seed packet labelled "Crater peas, steppe-grown," sold at the tower for a copper.

<!-- quest
id: qst_cal_crater_garden
title: The Hermit's Crater Garden
rank: S
type: OddJob
giver: npc_bellamy_quarrel
region: reg_calamity_steppe
level: 166
act: 5
requires_rank: S
reward: 67000 | 2900 | 305000
sets: cal_crater_garden_done
summary: A hermit has grown peas for nine years in a footprint-crater. He wants the harvest carried to the tower.
objectives:
  talk npc_bellamy_quarrel
  reach steppe_crater_garden
  choice wave_offer_or_still
-->

---

## 6. A Feather as Long as a Boat

*S · Gathering · the thermal cliffs · giver Skywatcher Corra Windfall*

**The short version.** Corra needs one shed feather from the ship-sized birds for the guild's collection. Feathers fall where nests are. Nests are on cliffs.

**What is really going on.** The feather is not hard to find; the nest it fell from holds a chick that is not yet fledged. The player must retrieve the feather without disturbing the nest, the chick or the parents, and decide what to do when the chick, left alone, calls out.

**Scene 1: the tower.**

**CORRA:** "Six years. Four hundred birds. One feather I haven't got."
**CORRA:** "The guild wants one for the hall. I'd like it fairly come by."
**CORRA:** "They moult in spring. They nest on the western cliffs."
> ► **"How big?"** — **CORRA:** "As long as a boat. Light as a leaf."
> ► **"Can I just pick one up?"** — **CORRA:** "If you can find one that isn't guarded."
> ► **"I'll fetch it."** — **CORRA:** "Quietly. They have long memories."

**Scene 2: the cliffs.** A high, wind-torn ridge. Giant feathers drift past like sails. Far above, a shape the size of a galleon circles.

*(Gameplay: stealth climb; avoid the thermals, keep out of the parents' line of sight.)*
> ► **"Wait for the parents to leave."** — Patience pays.
> ► **"Move while the shadow passes."** — Risky, fast.
> ► **"Follow the wind-line."** — A gentle path.

**Scene 3: the nest.** On a ledge, a feather as long as a boat, lying across a nest of branches. Beside it, a downy grey chick the size of a cottage, blinking.

**CHICK (a thin, high peep):** *"...Mama?"*
> ► **"Take the feather and go."** — The chick peeps again, louder.
> ► **"Sing it quiet."** — The chick calms.
> ► **"Wait with it."** — A long, warm hour.

**Scene 4: the return.** The mother lands on the ledge, huge and silent. She looks at the player. She looks at the feather in the player's hands.

**MOTHER (a voice like wind through a canyon):** *"...Keep it."*
*She settles over the chick. The player backs away slowly.*

**Outcomes and receipt.**
- The feather is delivered. If the player took it quickly, the chick cries for hours; if the player waited, the mother returns unprompted.
- **Receipt:** a feather as long as a boat hanging in the guild hall; a small grey down-feather tucked in the player's pack.

<!-- quest
id: qst_cal_ship_feather
title: A Feather as Long as a Boat
rank: S
type: Gathering
giver: npc_corra_windfall
region: reg_calamity_steppe
level: 180
act: 5
requires_rank: S
reward: 74000 | 3150 | 335000
sets: cal_ship_feather_done
summary: The guild wants a shed feather from the ship-sized birds. The nearest one lies in a nest with a chick.
objectives:
  talk npc_corra_windfall
  collect steppe_ship_bird_feather 1
  choice wait_move_or_follow
-->

---

## 7. Beneath the Grass

*SS · Exploration · the open grass · giver Caravan-Mistress Dunya Ironwheel*

**The short version.** A wagon of the caravan has dropped through the ground into a burrow. Dunya has eleven scholars aboard, three hours of air and a rule against descending.

**What is really going on.** The burrow is a tunnel dug by a giant that is not at home. The wagon rests in a hollow thirty feet down. The player must go down, reach the scholars and bring them up before the tunnel's owner returns, without waking the tunnel.

**Scene 1: the hole.**

**DUNYA:** "Nineteen crossings. Never lost a wagon to the ground."
**DUNYA:** "Eleven aboard. A cartographer, a bone-reader and nine who'll never let me forget this."
**DUNYA:** "Three hours of air. I can't send my own crew down. The ground is soft."
> ► **"What's the rule?"** — **DUNYA:** "Don't go in. I'm breaking it."
> ► **"Is the tunnel used?"** — **DUNYA:** "Recently."
> ► **"I'll go."** — **DUNYA:** "Take the harness. Don't touch the walls."

**Scene 2: the descent.** A dark, cool spiral of packed earth, smooth as a throat. Faint blue fungus lines the walls. Below, a lantern flickers.

*(Gameplay: stealth descent; vibration-sensitive floor.)*
**SCHOLAR (from below):** "Is that a rope? Oh, thank the sky."
> ► **"Stay still."** — A sigh of relief.
> ► **"How many hurt?"** — **SCHOLAR:** "Bruises. And a pride."
> ► **"I'm bringing the rope."** — **SCHOLAR:** "Gently, please."

**Scene 3: the climb.** One by one, eleven scholars climb the rope. The tunnel hums faintly with a sound like a very large animal breathing in its sleep.

> ► **(Hush them.)** — They climb silently.
> ► **(Hum back.)** — The breathing quiets.
> ► **(Hurry them.)** — A tremor shakes the walls.

**Scene 4: the surface.** The last scholar emerges into the daylight and kneels in the grass. Dunya counts heads twice, and then a third time.

**DUNYA:** "Eleven."
**DUNYA:** "I'll buy the next round of tea. For the rest of my life."

**Outcomes and receipt.**
- All eleven are saved. If the player hurried the climb, the tunnel shakes and the wagon is lost.
- **Receipt:** a hole in the grass filled with stones and a flag; Dunya's caravan carries a coil of spare rope on every wagon.

<!-- quest
id: qst_cal_beneath_grass
title: Beneath the Grass
rank: SS
type: Exploration
giver: npc_dunya_ironwheel
region: reg_calamity_steppe
level: 208
act: 6
requires_rank: SS
reward: 135000 | 5500 | 650000
sets: cal_beneath_grass_done
summary: A caravan wagon has fallen through the ground into a giant's burrow with eleven scholars aboard.
objectives:
  talk npc_dunya_ironwheel
  reach steppe_burrow_hollow
  choice hush_hum_or_hurry
-->

---

## 8. The Hollow Inside the Tusks

*SS · Exploration · the Tusks · giver Bone-Reader Jorun Tuskward*

**The short version.** Every Calamity visits the Tusks, the ring of colossal bones at the steppe's centre. Jorun has counted the footprints for nineteen circuits. They all point inward. None point out.

**What is really going on.** Inside the ring, at its centre, is a hollow in the earth the size of a house. It is empty. The prints end at its lip. This is a seed. It explains nothing about the Tusks, the Calamities or what died here.

**Scene 1: the ring.**

**JORUN:** "Nineteen circuits. Forty-three hundred prints. Every one points in."
**JORUN:** "None points out."
**JORUN:** "I would like to see what is at the middle. I would not like to go alone."
> ► **"How do the giants leave?"** — **JORUN:** "They don't leave by the prints. They leave by the grass."
> ► **"Is it safe?"** — **JORUN:** "I have never seen a giant at the Tusks. Only their trails."
> ► **"I'll come."** — **JORUN:** "Quietly. Please."

**Scene 2: the entrance.** Between two bones like the ribs of a drowned cathedral, a path of bare, trampled earth. The air feels very old. A faint warmth rises from the ground.

*The prints crowd together, deepening towards the centre.*
> ► **"Walk beside the prints."** — A slow approach.
> ► **"Walk in them."** — They are far too large.
> ► **"Count them as we go."** — **JORUN:** "Thank you."

**Scene 3: the hollow.** At the centre, a shallow circular pit, smooth as a bowl, perhaps twenty feet across. It is empty. At its lip, the prints end, side by side, nose to nose, as though every giant had stopped here and stood.

**JORUN:** (whispering) "...They all *stopped.*"
**JORUN:** "I do not know what they did next."
> ► **(Step into the hollow.)** — The earth is warm.
> ► **(Touch a bone.)** — It hums, very faintly.
> ► **(Stand at the lip, as they did.)** — A hush falls.

**Scene 4: the exit.** The two leave without speaking. Behind them, the wind passes through the bones with a long low note.

**JORUN:** "I shall not publish this."
**JORUN:** "I shall draw it. And keep the drawing."

**Outcomes and receipt.**
- The hollow is recorded; nothing is explained. If the player stood at the lip, a faint outline of a footprint appears on the ground when the player leaves.
- **Receipt:** a drawing of a hollow in a bone-reader's private notebook.
- **Canon-safe:** this is a **pure seed.** What the Tusks are, what died here, and why the Calamities visit are **not explained.**

<!-- quest
id: qst_cal_tusks_hollow
title: The Hollow Inside the Tusks
rank: SS
type: Exploration
giver: npc_jorun_tuskward
region: reg_calamity_steppe
level: 214
act: 6
requires_rank: SS
reward: 140000 | 5700 | 680000
sets: cal_tusks_hollow_done
summary: Every Calamity visits the Tusks, and every footprint points in. A bone-reader wants to see what is at the centre.
objectives:
  talk npc_jorun_tuskward
  reach steppe_tusks_hollow
  choice step_touch_or_lip
-->

---

## 9. The Grave the Grass Closed

*SS · OddJob · the open grass · giver Captain Rhosyn Fellowes*

**The short version.** Six years ago Rhosyn's brother died on the steppe and was buried under a cairn. The grass has closed over it. She has a coil of rope and a star-chart, and she cannot find it alone.

**What is really going on.** The cairn is gone. The steppe grows over everything within days. But the stars do not move, and the brother, a surveyor, left his own chart. The player and Rhosyn must find the grave by triangulation, and then decide what to leave on it that the grass will not eat.

**Scene 1: the camp.**

**RHOSYN:** "Six years. I've crossed four times. Each time I've missed it."
**RHOSYN:** "Emrys buried a marker. A cairn of salt-blocks. The grass has had it."
**RHOSYN:** "I have his chart. I have my own. I do not have patience."
> ► **"What do you remember?"** — **RHOSYN:** "A low hill. Three stars over it. A dry river."
> ► **"What do you want to leave?"** — **RHOSYN:** "Something that stays."
> ► **"I'll help."** — **RHOSYN:** "Thank you. Don't hurry me."

**Scene 2: the night survey.** Under a sky packed with stars, the two lay out a baseline with rope and pegs, shoot bearings and compare charts.

**RHOSYN:** "Emrys taught me this."
**RHOSYN:** "He said: the sky does the remembering for us."
> ► **"Check the bearings."** — Slow, steady work.
> ► **"Trust the stars."** — A quiet certainty.
> ► **"Let her lead."** — Rhosyn takes the sights.

**Scene 3: the hill.** At dawn, a low rise, three stars still faint over it, and a dry riverbed at its foot. Rhosyn kneels in the grass and presses her palm to the earth.

**RHOSYN:** "Here."
**RHOSYN:** "I think here."
> ► **(Dig carefully.)** — A flat white stone, still under the sod.
> ► **(Leave the earth undisturbed.)** — Rhosyn nods.
> ► **(Offer to mark it.)** — She hands you a brass plate.

**Scene 4: the marker.** Rhosyn sets a brass plate into the ground, flush with the soil, engraved with a name and a date. She does not say anything for a long time.

**RHOSYN:** "The grass will cover it."
**RHOSYN:** "That's all right. Now I know where it is."

**Outcomes and receipt.**
- The grave is found and marked. If the player dug, Rhosyn finds the stone but sleeps badly; if the earth was left, she finds peace.
- **Receipt:** a brass plate, flush with the soil, over a closed grave; a star-chart with a new mark in Rhosyn's hand.

<!-- quest
id: qst_cal_grave_closed
title: The Grave the Grass Closed
rank: SS
type: OddJob
giver: npc_rhosyn_fellowes
region: reg_calamity_steppe
level: 218
act: 6
requires_rank: SS
reward: 145000 | 5900 | 700000
sets: cal_grave_closed_done
summary: Six years ago a surveyor was buried on the steppe. The grass has closed over the cairn, and his sister wants to find it.
objectives:
  talk npc_rhosyn_fellowes
  reach steppe_closed_grave_hill
  choice dig_leave_or_mark
-->

---

## 10. The Calf in the Dry River

*SS · Faction · a dry riverbed · giver Beastmaster Wrenna Grassmantle*

**The short version.** A behemoth calf, no taller than a house, has strayed from its herd and wandered into a dry riverbed. Wrenna has followed it for a month. A predator herd is closing in.

**What is really going on.** The calf is not in danger from the predators' hunger so much as from its own bewilderment. It needs to be walked, slowly, back to the herd's trail by someone it will follow. Wrenna has the patience; the player has the strength to hold a gap open.

**Scene 1: the riverbed.**

**WRENNA:** "A month. Every dawn I walk beside it. Every night I sing."
**WRENNA:** "It follows me now. A little. It does not follow my voice when there are teeth."
**WRENNA:** "The predators will be here in a day."
> ► **"Where's the herd?"** — **WRENNA:** "Four miles south. I can see the dust."
> ► **"Why not leave it?"** — **WRENNA:** "Would you?"
> ► **"I'll hold the gap."** — **WRENNA:** "Thank you. Don't fight them. Just stand."

**Scene 2: the walk.** At dawn, the two lead a calf the size of a barn out of the riverbed, along the baked clay, over a low saddle. Dust rises ahead. Something growls on the wind.

**WRENNA:** (singing, low) "Come, little hill, come, little hill..."
> ► **"Walk behind the calf."** — It feels safer.
> ► **"Walk ahead."** — It follows more eagerly.
> ► **"Hum the song."** — The calf's ears twitch.

**Scene 3: the gap.** At a narrow cut in the hills, a pack of lean, yellow-eyed predators fans out. Each is the size of a house. The player steps between them and the calf.

*(Gameplay: hold position; the predators test, circle and retreat if the player does not strike.)*
> ► **(Stand still.)** — The leader pauses.
> ► **(Show a torch.)** — The pack flinches.
> ► **(Draw your weapon.)** — The pack roars.

**Scene 4: the herd.** At the edge of the dust, a dozen adult behemoths lift their heads. The largest lowers her muzzle to the calf and breathes, once, over its back.

**WRENNA:** "There you are."
**WRENNA:** "Go on, little hill."

**Outcomes and receipt.**
- The calf rejoins the herd. If the player drew a weapon, the predators attack and the calf bolts, and Wrenna must start again.
- **Receipt:** a small tuft of calf-hair tied to Wrenna's staff; a song that the caravans hum while crossing the grass.

<!-- quest
id: qst_cal_calf_dry_river
title: The Calf in the Dry River
rank: SS
type: Faction
giver: npc_wrenna_grassmantle
region: reg_calamity_steppe
level: 224
act: 6
requires_rank: SS
reward: 150000 | 6200 | 740000
sets: cal_calf_river_done
summary: A lost behemoth calf is being followed by predators. A beastmaster needs help walking it back to its herd.
objectives:
  talk npc_wrenna_grassmantle
  reach steppe_dry_riverbed_cut
  choice stand_torch_or_weapon
-->
