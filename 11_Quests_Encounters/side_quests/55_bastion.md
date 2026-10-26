# 11e-55 — Bastion, the City of Rings: Ten Side Quests (draft)

> *"Bastion builds a new ring every time the horde breaks the outermost one. There are many rings."*
> — Gazetteer, Bastion

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 8 plants an unexplained seed.

**Region:** `reg_bastion` (the outer ring and its villages, the fields between the rings, the Broken Rings, the Citadel, the Stone of Founding). **Rank band:** B–S. **Tone:** stoic, practical, dark-humoured; songs about walls; warmth in the work of hands.

**Placement notes.**
- **Thrakka, Sabretooth Khan of the Steppe Horde,** is the region's Tyrant, besieging the outermost ring. **No quest here kills or defeats Thrakka or ends the siege.** The region stays `besieged`; no quest here uses the SiegeDefence type (those belong to the main siege track), so none sets `region_state`. Quests 5 and 10 are ordinary *Defense* quests that hold one place for one night.
- Customs the quests rely on: a **Warden** chosen by the **captains of the rings;** the outermost ring's captain is the most honoured and most likely to die; **a stone from the last broken ring is built into each new one;** walls are believed to hold the builders' spirits; every child learns to lay stone and hold a spear; songs are about walls.
- **Rank note.** Quests 1 to 3 are rank B, 4 to 7 rank A, 8 to 10 rank S (levels 166-176). S rewards are extrapolated from `Data/World/guild_ranks.json` and are first-pass.
- **Beastkin.** The horde's riders are beastkin (here a single **Wolfkin** deserter); nothing here says what Thrakka is *owed* or *wants* beyond the gazetteer.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Flaw in the Footing | B | Investigation | Mason Odrun Flintlay | A sabotage with a reason |
| 2 | The Deserter Who Wanted a Hearing | B | Escort | Tarn Hollowgrass | A rider, a sister, a message |
| 3 | Barley Between the Rings | B | Gathering | Farmwife Hesper Furrow-Reeve | Harvest in a no-man's field |
| 4 | Cold Joints | A | Investigation | Captain Joram Vellacott | How the walls really break |
| 5 | The Drum at Fennel Row | A | Defense | Sergeant Mab Thistlewick | One village, one night |
| 6 | The Captain's Stone | A | OddJob | Widow Ansa Keelgrave | A family's mark in a new wall |
| 7 | Whether to Hold the Outer Ring | A | Faction | Ring-Captain Teodra Mossgate | Captains who disagree |
| 8 | The Gate That Faced Inward | S | Hidden | Archivist Perdita Underhill | The fort under the city |
| 9 | A Cub in the Broken Rings | S | OddJob | Wren Gravelmouth | A child's enemy, very small |
| 10 | The Night Between the Rings | S | Defense | Master Mason Berwyn Stonehall | Time bought with bodies and nerve |

## Cast

<!-- npc
id: npc_odrun_flintlay
name: Mason Odrun Flintlay
tier: major
race: Dwarf
region: reg_bastion
settlement: Bastion new ring
role: Mason who found a flaw in the new ring's footing
backstory: A broad, careful dwarf mason with forty years of wall behind him who knows exactly how a footing is poisoned and by whom.
-->
<!-- npc
id: npc_tarn_hollowgrass
name: Tarn Hollowgrass
tier: major
race: Wolfkin
region: reg_bastion
settlement: Bastion outer ring
role: Horde rider who deserted
backstory: A lean wolfkin rider of the Steppe Horde who walked into the outer ring under a white cloth with a message he will only give to the Warden.
-->
<!-- npc
id: npc_warden_ysolt_greywall
name: Warden Ysolt Greywall
tier: major
race: Human
region: reg_bastion
settlement: The Citadel
role: Warden of Bastion
backstory: A sparse, hard-voiced Warden chosen by the captains of the rings, who sleeps four hours a night and keeps a list of every captain who has died holding the outer wall.
-->
<!-- npc
id: npc_hesper_furrow_reeve
name: Farmwife Hesper Furrow-Reeve
tier: townsfolk
race: Human
region: reg_bastion
settlement: Between the rings
role: Farmwife with a field no one can reach
backstory: A weathered farmwife who has harvested the same barley field for thirty years and sees no reason that a horde should stop her.
-->
<!-- npc
id: npc_joram_vellacott
name: Captain Joram Vellacott
tier: major
race: Human
region: reg_bastion
settlement: Bastion outer ring
role: Captain of the outermost ring
backstory: The honoured, tired captain of the outer ring, who has buried six lieutenants and is determined not to bury a seventh without understanding why the walls fall.
-->
<!-- npc
id: npc_mab_thistlewick
name: Sergeant Mab Thistlewick
tier: townsfolk
race: Halfling
region: reg_bastion
settlement: Fennel Row
role: Sergeant of a village militia
backstory: A stout halfling sergeant whose militia of thirty has held a village between rings for four summers by habit, fury and pie.
-->
<!-- npc
id: npc_ansa_keelgrave
name: Widow Ansa Keelgrave
tier: townsfolk
race: Human
region: reg_bastion
settlement: Bastion new ring
role: Widow of a fallen outer-ring captain
backstory: A tall, quiet widow whose husband held the outer wall for nine years and whose family has not yet been given a place in the next one.
-->
<!-- npc
id: npc_teodra_mossgate
name: Ring-Captain Teodra Mossgate
tier: major
race: Human
region: reg_bastion
settlement: The fourth ring
role: Captain of an inner ring
backstory: A clear-eyed inner-ring captain who thinks the outer ring is a grave being dug one soldier at a time and has said so, in public, to the Warden.
-->
<!-- npc
id: npc_perdita_underhill
name: Archivist Perdita Underhill
tier: major
race: Gnome
region: reg_bastion
settlement: The Citadel
role: Archivist of the Citadel
backstory: A bright, dusty archivist who keeps the records of the first fort and has just found a floor plan that does not match any gate in the city.
-->
<!-- npc
id: npc_wren_gravelmouth
name: Wren Gravelmouth
tier: townsfolk
race: Human
region: reg_bastion
settlement: The Broken Rings
role: Nine-year-old scavenger of the Broken Rings
backstory: A fierce nine-year-old who hunts for useful scrap among the broken rings and has found something that purrs.
-->
<!-- npc
id: npc_berwyn_stonehall
name: Master Mason Berwyn Stonehall
tier: major
race: Human
region: reg_bastion
settlement: Bastion new ring
role: Master mason of the next ring
backstory: A stooped master mason with plaster in his beard who has laid the foundation of eight rings and knows to the hour how long the next one needs.
-->

---

## 1. The Flaw in the Footing

*B · Investigation · the new ring · giver Mason Odrun Flintlay*

**The short version.** Odrun found a hollow in the new ring's footing: stone laid over rubble instead of rock. Someone knew where to hide it.

**What is really going on.** A conscripted mason named Pell, whose village was swallowed by the new ring's line, laid the hollow on purpose. He did not want the horde to win. He wanted the ring moved off his mother's grave. Odrun suspected as much; he wants someone who will not simply report it.

**Scene 1: the footing.**

**ODRUN:** "Forty years on walls. I know a bad footing. This is not *bad.* This is *clever.*"
**ODRUN:** "Rubble under a skim of good stone. It will stand for a season. Then it will go."
**ODRUN:** "Whoever laid it knew the survey. That is a mason."
> ► **"Who laid it?"** — **ODRUN:** "I have a list of four. I have an idea of one."
> ► **"Can it be fixed?"** — **ODRUN:** "Cut out, relaid. Three days. But I want the *why.*"
> ► **"Did the horde pay someone?"** — **ODRUN:** "If it did, I would not be asking you quietly."

**Scene 2: the mason.** Pell is a lanky young man scrubbing a trowel that is already clean. He does not run.

**PELL:** "My mother's grave is on the line. The surveyors put the wall on it."
**PELL:** "I asked them to move it a spade's width. They said: *the wall does not bend.*"
**PELL:** "So I made it bend."
> ► **"You endangered the whole ring."** — **PELL:** "I know. I know. I laid it *shallow.* I meant to fix it."
> ► **"Where is the grave?"** — **PELL:** "Under the third course. Beside the east tower."
> ► **"Would a marker have been enough?"** — **PELL:** (a long silence) "...I never asked for a marker."

**Scene 3: the choice.** Odrun and the player stand on the ring's rim at dusk.

**ODRUN:** "I can report him. It is a hanging matter, in wartime, for sabotage."
**ODRUN:** "Or I can say it was a survey error, fix it, and tell no one."
**ODRUN:** "Or we can move the line a spade's width, and be a little late."
> ► **"Report it truthfully."** — **ODRUN:** (heavily) "Then I report it with a note that he was grieving."
> ► **"Call it a survey error."** — **ODRUN:** "I have lied for less. Never for a better reason."
> ► **"Shift the line."** — **ODRUN:** "...The Warden will have my beard. But yes."

**Scene 4: the course.** Whichever way, the hollow is cut out and relaid. A small stone with no mark is built into the third course, beside the east tower.

**PELL:** "What is it?"
**ODRUN:** "A stone from the last broken ring. Your mother is in the wall now. Same as the builders."

**Scene 3b: the third course.** While Pell works, Odrun shows the player how a good footing is read, the way a doctor reads a pulse.

**ODRUN:** "Lay your palm flat. Cold is good. Damp is bad. Hollow is a lie."
**ODRUN:** "Every mason in this city has a mark. You learn it before you learn your letters. Pell's is a small bird."
**ODRUN:** "A man who signs his work in a bird does not poison a wall out of malice. He does it out of grief that has nowhere else to stand."
*He taps the rubble with a hammer. It answers with a flat, dead note, like a bell with a crack.*
**ODRUN:** "I will not hang a boy for loving his mother. But I will not let him sleep on it either."

**Outcomes and receipt.**
- Report: Pell is sentenced to a labour term on the next ring, which the Warden commutes after Odrun's note. Survey error: Pell works the footing himself, quietly, for a season. Shift: the ring is three days late and the grave is inside the wall.
- **Receipt:** a stone-mason's mark, scratched by Pell on the new course: a small bird.

<!-- quest
id: qst_bas_flaw_footing
title: The Flaw in the Footing
rank: B
type: Investigation
giver: npc_odrun_flintlay
region: reg_bastion
level: 90
act: 4
requires_rank: B
reward: 11000 | 650 | 46000
sets: bas_flaw_footing_done
summary: A mason found a deliberate hollow in the new ring's footing. Whoever laid it knew the survey.
objectives:
  talk npc_odrun_flintlay
  reach bastion_new_ring_footing
  choice report_error_or_shift
-->

---

## 2. The Deserter Who Wanted a Hearing

*B · Escort · the outer ring and the Citadel · giver Tarn Hollowgrass*

**The short version.** A horde rider walked into the outer ring under a white cloth. He says he has a message for the Warden, and the sentries want to hang him.

**What is really going on.** Tarn has no secret about Thrakka. His message is small and personal: his younger sister was taken to the Steppe's winter camp and cannot walk. He wants the Warden to allow a truce for one day so a cart can fetch her. He has no right to ask, and he knows it.

**Scene 1: the gate.** A sentry pins Tarn's arms. Tarn does not struggle.

**SENTRY:** "He walked in. Under a rag. Says he's a *messenger.*"
**TARN:** "A deserter. I would not say messenger. It sounds too important."
**TARN:** "I want to speak to your Warden. Nobody else. Please."
> ► **"What is your message?"** — **TARN:** "It is not for the gate."
> ► **"Why should we trust you?"** — **TARN:** "You should not. But I walked in alone."
> ► **"I'll take him."** — **SENTRY:** "Your head, then."

**Scene 2: the road.** The way to the Citadel is lined with silent townsfolk. A child throws a pebble. It bounces off Tarn's shoulder.

**TARN:** "I do not blame them."
**TARN:** "On the steppe we are told your walls are a wound. I came to see the wound. It has gardens."
*He looks at a woman hauling a barrow of cabbages, and says nothing for a while.*

**Scene 3: the Warden.** Warden Ysolt Greywall hears him standing, without a chair.

**YSOLT:** "Speak."
**TARN:** "My sister is eleven. She cannot walk. The camp moves north in nine days. They will not carry her."
**TARN:** "I ask one day. A cart. Two of yours, unarmed. I will walk ahead."
**YSOLT:** "You ask me to open a road to the horde."
**TARN:** "I ask you to open a road to a *child.*"
> ► **"Grant the truce."** — The room goes very quiet.
> ► **"Offer an escort instead."** — **YSOLT:** "Then it is on you."
> ► **"Refuse."** — **TARN:** (very low) "I understand."

**Scene 4: the answer.** Ysolt does not grant a truce. She does not refuse. She says only:

**YSOLT:** "The Warden cannot. A mason's cart might wander."
**YSOLT:** "Carts do wander. In wartime. It would be a pity if one lost its way north."
*Tarn bows, very low, and does not trust himself to speak.*

**Scene 2b: the white cloth.** At the Citadel's outer gate, a baker presses a loaf into the escort's hands without a word, then walks away with her face turned.

**TARN:** "Why would she do that?"
**ESCORT:** "Because she lost a son at the Ford, and she has decided that you are not the one who owes her."
**TARN:** "I owe her anyway."
**ESCORT:** "Eat the bread."
*Tarn eats the bread. It is the first thing he has eaten in two days. He weeps without making a sound.*
**TARN:** "On the steppe we say the cities poison their food. I thought I would die of it."
**TARN:** "It is only bread."
> ► **"It is only bread."** — He nods, wiping his face with a rough wolfkin hand.

**Outcomes and receipt.**
- Truce: a single day's quiet at the north road; the girl is brought south. Escort: the player and two guards go in quiet and return at dawn with the child. Refusal: Tarn leaves alone and is not seen again; a note of thanks arrives months later with no signature.
- **Receipt:** a wolfkin-braided cord Tarn gave his sister, handed to the player for safekeeping.
- **Canon-safe:** Thrakka is not described or named by Tarn. The horde's motives are not explained.

<!-- quest
id: qst_bas_deserter_hearing
title: The Deserter Who Wanted a Hearing
rank: B
type: Escort
giver: npc_tarn_hollowgrass
region: reg_bastion
level: 94
act: 4
requires_rank: B
reward: 11500 | 680 | 48000
sets: bas_deserter_done
summary: A horde rider walked in under a white cloth. He wants to ask the Warden for one day's road for his sister.
objectives:
  talk npc_tarn_hollowgrass
  escort npc_tarn_hollowgrass
  talk npc_warden_ysolt_greywall
  choice truce_escort_or_refuse
-->

---

## 3. Barley Between the Rings

*B · Gathering · a field between the rings · giver Farmwife Hesper Furrow-Reeve*

**The short version.** Thirty years of harvest stand in a field between the fifth and sixth rings. Hesper will not let it rot. The field is in reach of the horde's scouts.

**What is really going on.** Bastion's granaries are lower than the Warden admits. The barley is not only Hesper's pride; it is a third of next month's bread for a ward. Hesper knows this and is too stubborn to let anyone else carry it.

**Scene 1: the gate.**

**HESPER:** "Three hundred sheaves. Standing. The scouts have been past it twice and did not burn it. That will not last."
**HESPER:** "I am sixty-four. I cut a sheaf in nine breaths. I can do better with help."
> ► **"Isn't it too dangerous?"** — **HESPER:** "It is a field. It has been dangerous since the first ring."
> ► **"Why not wait for an escort?"** — **HESPER:** "Because the scouts have eyes and the barley has a week."
> ► **"I'll cut."** — **HESPER:** "Bring a sickle and a good back."

**Scene 2: the field.** Gold stalks to the waist. The wind combs them in long waves. Far off, a line of riders drifts along the horizon, small as seeds.

**HESPER:** "Bend low. Cut low. Move slow."
**HESPER:** "A cutting person looks like a sheaf. A running person looks like a rabbit."
*Over three hours they cut a hundred and forty sheaves. The riders do not turn.*

**Scene 3: the riders.** At noon, four riders do turn, and canter closer.

**HESPER:** (flatly) "Well."
> ► **"Stand and face them."** — The riders slow, circle, and ride off.
> ► **"Drop flat."** — The riders pass within thirty paces and do not see.
> ► **"Light a smoke signal."** — The ring's archers answer; the riders retreat from the range.

**Scene 4: the wagon.** The barley goes back on a borrowed cart, a dozen sheaves lost to the wind.

**HESPER:** "Take a sheaf for yourself."
**HESPER:** "Not for the bread. For luck. Hang it over your door."
*The player sets it on the Warden's steps, where it stands for months, drying gold.*

**Scene 2b: the counting.** Between sheaves, Hesper tells the player the thing she has told no one: the numbers.

**HESPER:** "The Warden says the granaries are full. They are two-thirds. A cook told me."
**HESPER:** "I do not blame her. If the city knew, the city would panic, and a panicking city is worse than a hungry one."
**HESPER:** "So I cut. Quietly. And I do not say why."
*She straightens, one hand at her back, and looks along the golden rows.*
**HESPER:** "My mother used to say: a harvest is a promise you keep with your back."
**HESPER:** "I have kept it thirty years. I would like to keep it thirty-one."
> ► **"You will."** — She snorts. "Keep cutting."

**Scene 2b: the lunch.** At midday Hesper unwraps a cloth beside the stooks and offers the player a heel of bread and a hard, sharp cheese.

**HESPER:** "My husband brought me this cheese on the day we married. Thirty-four years ago. He is dead. The cheese is not, quite."
**HESPER:** "He used to say the field was the only honest thing in Bastion, because it asks nothing it will not give back."
*She chews slowly, watching the horizon where the riders are still dots.*
**HESPER:** "Eat. A man cannot cut barley on honour alone."

**Outcomes and receipt.**
- The barley goes to the ward's ovens. If the player stood and faced the riders, the soldiers on the wall hear of it and do not stop talking for a week.
- **Receipt:** a small braided barley knot, hung over the player's door.

<!-- quest
id: qst_bas_barley_rings
title: Barley Between the Rings
rank: B
type: Gathering
giver: npc_hesper_furrow_reeve
region: reg_bastion
level: 98
act: 4
requires_rank: B
reward: 11800 | 700 | 49000
sets: bas_barley_done
summary: A farmwife's last field stands between two rings, in sight of the horde's scouts. A third of a ward's bread depends on it.
objectives:
  talk npc_hesper_furrow_reeve
  collect bastion_barley_sheaf 200
  choice stand_flat_or_signal
-->

---

## 4. Cold Joints

*A · Investigation · the outer ring · giver Captain Joram Vellacott*

**The short version.** The outer ring's walls fail in a single night, every time. Joram wants someone to find out how, before he buries a seventh lieutenant.

**What is really going on.** The horde does not break the wall with strength. Sabretooth riders scratch at one place: the *cold joints,* the seams where a day's masonry ended and the next day's began, laid on stone cooled over the night. The mortar there never took. The horde has learned the masons' calendar.

**Scene 1: the rampart.**

**JORAM:** "Six lieutenants. Six walls. Each fell on a night of frost."
**JORAM:** "They do not climb. They do not ram. They *scratch.* In one place. Then it goes."
**JORAM:** "Find out where, and why there."
> ► **"Have the masons looked?"** — **JORAM:** "They say the mortar is sound. They say it kindly."
> ► **"Can I see the last breach?"** — **JORAM:** "It is a rubble heap. You will see it in a night."
> ► **"I'll watch."** — **JORAM:** "Take cloaks. The frost is vicious."

**Scene 2: the night watch.** The player hides in a gap on the parapet. Far below, shapes pad through the frost-white grass. Massive sabretooth cats, riders silent on their backs. They ride along the wall at a walk, as if reading it.

**RIDER (below, very low):** "Here. Here."
*A cat's claws scrape a single seam. A small stone drops away, then another.*
**RIDER:** "The cold joint. Day nine."

**Scene 3: the mason.** In the morning, Odrun's cousin, a mason named Beck, examines the seam.

**BECK:** "That's a day-end. We stop at dusk, mortar goes cold, next morning we start on top."
**BECK:** "It's meant to be keyed. But in a rush we don't key. And they *know.*"
**BECK:** "Somebody counted our days."
> ► **"Tell Joram first."** — The captain listens, face stone.
> ► **"Tell the masons first."** — Beck winces, then nods.
> ► **"Bait it."** — **BECK:** "Leave a false joint? ...Ha. Yes."

**Scene 4: the trap or the fix.** Whichever course is taken, a week later the player stands on the wall in the frost again. The riders arrive. They scratch.

**RIDER:** "Here."
*The seam is keyed, braced, and gives nothing. The cat's claws skid. The rider stares, then pulls the cat away.*
**JORAM:** (a dry rasp of a laugh) "Seven weeks since I last heard a rider say a word."

**Scene 2b: the masons' calendar.** In the masons' yard, Beck unrolls the working calendar: a long strip of linen marked with dots for every course laid, day by day.

**BECK:** "Every day a dot. Every rest a gap. Anyone who watches the yard can read it."
**BECK:** "A smoke from the kiln means mortar is mixed. A lull means a cold day. Anyone with eyes on the ring for a week knows our rhythm."
**BECK:** "And a horde has had eyes on us for fifty years."
*He lays his hand flat on the linen.*
**BECK:** "I don't think they're clever. I think they're *patient.* It is worse."
> ► **"Change the rhythm."** — **BECK:** "Yes. Never lay the same hour twice. Ha. That would drive a mason mad."

**Outcomes and receipt.**
- Joram: the wall is keyed in every joint within the month. Masons first: a mason's guild standard is written. Bait: a false joint, well-watched, draws a scouting party into archer range.
- **Receipt:** a keyed stone block with the date and the words *"cold joint, mended"* chiselled by Beck.

<!-- quest
id: qst_bas_cold_joints
title: Cold Joints
rank: A
type: Investigation
giver: npc_joram_vellacott
region: reg_bastion
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: bas_cold_joints_done
summary: The outer ring falls in one night, every time. The captain wants to know how the horde knows where to scratch.
objectives:
  talk npc_joram_vellacott
  reach bastion_outer_ring_parapet
  choice captain_masons_or_bait
-->

---

## 5. The Drum at Fennel Row

*A · Defense · Fennel Row, between the rings · giver Sergeant Mab Thistlewick*

**The short version.** Thirty militiamen hold a village of two hundred between the fourth and fifth rings. Tonight a raiding band is coming for the granary. Mab is out of arrows and out of patience.

**What is really going on.** The raiders are a probing party, not a charge: forty riders testing whether the village will be abandoned. If Fennel Row falls, the horde learns the fifth ring's flank is thin. Mab does not need a hero. She needs someone to be *loud* in the right places.

**Scene 1: the common.**

**MAB:** "Thirty. All over fifty or under sixteen. Two with working bows."
**MAB:** "I have flour, barrels, a church bell, and a very large drum."
**MAB:** "I intend to fight with all four."
> ► **"What's the drum for?"** — **MAB:** "Noise. Cats hate it."
> ► **"Where do you want me?"** — **MAB:** "The granary. If they get that, we are done."
> ► **"What's the plan?"** — **MAB:** "Be stubborn. In order."

**Scene 2: dusk.** Villagers roll barrels into a ring. Children fill sacks. An old man oils a rusted hook.

**VILLAGER:** "Is it true that cats fear fire?"
**MAB:** "No. They fear *noise.* Fire merely irritates them."
**MAB:** "Hit the drum on three. And again. And again. Do not stop till I say."

**Scene 3: the raid.** In the grey before dawn the first cats pad out of the grass, riders low. The drum begins. The church bell joins it. A volley of flour sacks bursts in the dark, white clouds in a hundred faces.

**RIDER:** "What *is* that?"
**MAB:** "*Breakfast!*"
> ► **"Hold the granary door."** — The player stands alone at the oak door against three riders, and holds.
> ► **"Take the drum."** — The player drums until their arms burn, and the cats shy at the noise.
> ► **"Break their line."** — A burst of force splits the riders; the cats panic, and the band scatters.

**Scene 4: the morning.** The band withdraws before the sun is fully up. The village is wrecked and standing. Mab surveys the common.

**MAB:** "Eleven barrels. A bell with a dent. One thatched roof."
**MAB:** "And Fennel Row."
*She sits on an overturned bucket and, for the first time in two days, does not stand up.*

**Scene 2b: the pie.** An hour before dusk Mab inspects the defences. The defences include seven pies, cooling on the sill of the granary.

**MAB:** "Rhubarb. They are for after."
**MAB:** "The last time we held this row we ate nothing for two days. I swore that the next time, we would eat *after.*"
**MAB:** "A village that fights on an empty stomach will remember it. A village that fights knowing a pie is waiting fights like cats."
*She sets a hand on the nearest crust, protectively.*
**MAB:** "Touch the pies before the fight and I will have you posted to the latrine."
> ► **"I'll guard the pies."** — **MAB:** "Good. Everyone needs a post worth dying for."

**Scene 2b: the bell-ringer.** An old man named Dobb climbs the church tower with a mallet and a flask, and winks at the player from the window.

**DOBB:** "Forty years I rang for weddings. Never once for a war."
**DOBB:** "I find I rather prefer it. A bell on a wedding is polite. A bell in a war is *useful.*"
*He takes a swig, spits in his palms and grips the rope.*
**DOBB:** "Tell the sergeant I am ready. And tell her I have a very large lung."

**Outcomes and receipt.**
- Fennel Row holds. Each role of the player earns a different gift: the granary door, a thanks from the ward; the drum, a drumming song written about the night; the line-break, riders who do not return to that flank for a month.
- **Receipt:** a dented church-bell clapper, hung from a ribbon, rung only when Fennel Row needs help.

<!-- quest
id: qst_bas_fennel_row
title: The Drum at Fennel Row
rank: A
type: Defense
giver: npc_mab_thistlewick
region: reg_bastion
level: 124
act: 4
requires_rank: A
reward: 28000 | 1450 | 126000
sets: bas_fennel_row_done
summary: Thirty militiamen hold a village between the rings. Tonight a raiding band tests it.
objectives:
  talk npc_mab_thistlewick
  defend bastion_fennel_row
  choice door_drum_or_line
-->

---

## 6. The Captain's Stone

*A · OddJob · the new ring · giver Widow Ansa Keelgrave*

**The short version.** A stone from each broken ring goes into the next. Ansa's husband held the outer wall for nine years and died holding it. His family has not been given a place in the new ring.

**What is really going on.** Custom allows one family to set one stone per broken ring. The masons have forgotten Ansa's husband's name. The rule is not cruel; it is merely stretched past its limit by too many deaths. Ansa does not want a monument. She wants one small stone in the right course.

**Scene 1: the porch.**

**ANSA:** "Nine years, Hale held the outer wall. Nine. The record says six."
**ANSA:** "There is a stone from his ring waiting in the yard. Nobody has come to place it."
**ANSA:** "I would carry it myself. It weighs as much as he did."
> ► **"I'll carry it."** — **ANSA:** "Together. If you will."
> ► **"Why isn't it placed?"** — **ANSA:** "Because the rolls are behind. The masons are good people."
> ► **"What do you want on it?"** — **ANSA:** "His name. Not much else."

**Scene 2: the mason's yard.** Berwyn Stonehall's apprentices are stacking dressed stone. A tired clerk consults a ledger.

**CLERK:** "Keelgrave. Keelgrave. Ah. Captain Hale Keelgrave, outer ring, six years. Stone number nine hundred and four."
**ANSA:** "Nine years."
**CLERK:** "The roll says six."
> ► **"Show me the roll."** — The clerk produces it; three years are written in another hand, crossed out.
> ► **"Take her word."** — **CLERK:** "I'd like to. I need a witness."
> ► **"I'm the witness."** — **CLERK:** "...That will do."

**Scene 3: the course.** At dusk the stone is rolled on log rollers up the ramp: Ansa leading, the player behind, two masons' boys pulling. A ring-captain stops to watch, and takes off his helm.

**ANSA:** (breathless) "Not much further."
**ANSA:** "Hale hated ceremony. He would call this a lot of fuss."
> ► **"Say his name."** — Ansa says it. The ramp is silent.
> ► **"Set the stone."** — The stone settles into the course with a deep, gritty sound.
> ► **"Add a line."** — A mason's chisel inscribes a short line: *He held it.*

**Scene 4: the mark.**

**ANSA:** "That is all. That is all I wanted."
*A child nearby, holding a spear taller than herself, murmurs the wall-song under her breath: "Stone on stone on stone, a name beneath each course."*

**Scene 2b: the record room.** Before the stone is moved, Ansa shows the player the ledger of fallen captains in the Warden's hall, a list thirty pages long, all in the same hand.

**ANSA:** "She writes them herself. Every one. In her own hand, the night they die."
**ANSA:** "She wrote Hale's name wrong the first time. She crossed it out and wrote it again, and she wept, which I am told she does not do."
**ANSA:** "That is why I do not blame the clerk. A city that has this many names to carry will drop one sometimes."
*Her finger rests on a line: "Hale Keelgrave, outer ring, six years." Someone has scratched out the six and written nine above it.*
**ANSA:** "She corrected it herself. Months ago. Nobody told the masons."

**Outcomes and receipt.**
- The stone is placed in the course with the right name; the roll is corrected to nine years. If the player added a line, the same phrase later appears on other stones.
- **Receipt:** a small chip of the stone, which Ansa presses into the player's hand.

<!-- quest
id: qst_bas_captains_stone
title: The Captain's Stone
rank: A
type: OddJob
giver: npc_ansa_keelgrave
region: reg_bastion
level: 125
act: 4
requires_rank: A
reward: 28000 | 1450 | 126000
sets: bas_captains_stone_done
summary: A widow wants her husband's stone from the broken ring set into the new one. The roll says six years. He held nine.
objectives:
  talk npc_ansa_keelgrave
  reach bastion_new_ring_course
  choice name_set_or_line
-->

---

## 7. Whether to Hold the Outer Ring

*A · Faction · the Citadel council · giver Ring-Captain Teodra Mossgate*

**The short version.** Teodra says the outer ring is a grave dug a soldier at a time. She wants it abandoned in favour of the next one. The Warden says no.

**What is really going on.** Both are right in different ways. Teodra's numbers are correct: the outer ring costs more than it holds. The Warden knows that giving up a ring tells the horde, and the city, that the walls can be *given.* Bastion is not a rule or an argument. It is a habit, and habits are fragile.

**Scene 1: the fourth ring.**

**TEODRA:** "Two hundred and eleven dead holding the outer ring this year. Two hundred and eleven."
**TEODRA:** "Every one a person I could have kept alive by moving them inside."
**TEODRA:** "I am not a coward. I am a *clerk with a spear.*"
> ► **"What do you want?"** — **TEODRA:** "A vote. Of all the captains."
> ► **"What does the Warden say?"** — **TEODRA:** "That rings do not retreat."
> ► **"Show me the numbers."** — **TEODRA:** "Of course."

**Scene 2: the Warden.** Ysolt Greywall does not look up from the list of captains' names she keeps by her bed.

**YSOLT:** "She is right. And I will not do it."
**YSOLT:** "The day Bastion gives a ring, it learns it *can.* After that the next ring is easier to give. And the next."
**YSOLT:** "I am not saving the ring. I am saving the *habit.*"
> ► **"Is there a middle way?"** — **YSOLT:** "Tell me one."
> ► **"People are dying."** — **YSOLT:** "Yes. Every name is on this list."
> ► **"Teodra isn't wrong."** — **YSOLT:** "No. She never is. It is her curse."

**Scene 3: the council.** The captains gather in the Citadel hall, twelve of them, boots ringing.

**TEODRA:** "I propose we withdraw the outer garrison to the fifth ring and hold the outer as a trap."
**CAPTAIN:** "Withdraw? We would be *conceding.*"
**TEODRA:** "We would be *living.*"
> ► **"Propose a smaller garrison."** — A murmur; Ysolt's brow lifts.
> ► **"Propose a rotation."** — The captains lean in.
> ► **"Propose a vote and let it fall."** — **YSOLT:** "Then we vote."

**Scene 4: the verdict.** The council votes. It does not vote to abandon the outer ring. It votes, narrowly, to rotate its garrison every month, and to move every non-essential family inward.

**TEODRA:** "Not what I wanted."
**YSOLT:** "Not what I wanted either. That is how I know it is fair."

**Scene 2b: the numbers.** Teodra spreads three sheets of figures across her table and lets the player read them in silence.

**TEODRA:** "Cost of holding the outer ring: one soldier in nine, every year."
**TEODRA:** "Cost of the next ring built without the outer to hold the horde: two soldiers in nine, for one summer, and then none."
**TEODRA:** "I have done the sums ten times. They always say: let it go."
*Her pen taps once, hard, against the page.*
**TEODRA:** "And yet. I look at the Warden's face, and I see someone for whom numbers are not the whole of it. I envy her that. I also think it will kill us."
> ► **"Both can be true."** — **TEODRA:** "That is exactly what I am afraid of."

**Outcomes and receipt.**
- The outer ring holds, with a leaner garrison. Death rolls fall. If the player chose the vote, Teodra and Ysolt accept the result; a stricter rule is added to the oath that *any captain may call a vote.*
- **Receipt:** Teodra's old clerk's pen, a spear-shaped nib, left on the player's table with a note: *"Count me among the habits."*

<!-- quest
id: qst_bas_hold_outer
title: Whether to Hold the Outer Ring
rank: A
type: Faction
giver: npc_teodra_mossgate
region: reg_bastion
level: 126
act: 4
requires_rank: A
reward: 28500 | 1500 | 127000
sets: bas_hold_outer_done
summary: An inner-ring captain wants the outer ring abandoned. The Warden refuses. Both have numbers.
objectives:
  talk npc_teodra_mossgate
  talk npc_warden_ysolt_greywall
  choice smaller_rotate_or_vote
-->

---

## 8. The Gate That Faced Inward

*S · Hidden · the Citadel's undercroft · giver Archivist Perdita Underhill*

**The short version.** In the Citadel's records is a plan of the first fort that does not match any gate in the city. It has a gate that faces *inward.*

**What is really going on.** The oldest fort, the one before the rings, had a gate opening not toward the steppe but toward the fort's own heart, into a courtyard that is now solid foundation. Nobody knows why. The player and Perdita dig, quietly, to find a door that has been walled up since the grandparents' time.

**Scene 1: the archive.**

**PERDITA:** "The plan is sixty years older than the oldest map. It shows the first fort: a square, a keep, a wall."
**PERDITA:** "And here, in the keep's own wall, a gate. Facing the *inside.*"
**PERDITA:** "A gate into the middle of the fort. There is nothing in the middle but foundation."
> ► **"Could it be a drawing error?"** — **PERDITA:** "Not in that hand. He never made errors."
> ► **"Why does it matter?"** — **PERDITA:** "Because someone *built a gate to something.*"
> ► **"Let's look."** — **PERDITA:** "Bring a lamp and a crowbar. And discretion."

**Scene 2: the undercroft.** Down narrow steps, past casks of old grain. At the far wall, a plastered arch, painted over a dozen times.

**PERDITA:** "There. Hear that? Hollow."
*The player taps the plaster. A hollow, dry sound.*
**PERDITA:** "Somebody walled this up. Carefully. With no mark."

**Scene 3: the door.** They break through. Behind the plaster is a small round chamber, bare, dry and cold. On the floor, a ring of worn stone, scuffed by feet. In the centre, a single bench, facing the gate.

**PERDITA:** (very softly) "A room for sitting. Facing the gate."
**PERDITA:** "Facing the gate that faces in."
*On the bench lies a folded cloak, perfectly preserved, and a tin cup.*
> ► **"Leave it as it is."** — Perdita nods. "Yes. It is not ours."
> ► **"Take the cup to the Warden."** — The cup is plain, its rim worn smooth by lips.
> ► **"Sit on the bench."** — The player sits. The room is very quiet. Perdita, after a long moment, sits too.

**Scene 4: the closing.** They re-plaster the arch, leaving a small mark on the inside.

**PERDITA:** "I will not write what I think. I will write *'a bench, facing a gate.'*"
**PERDITA:** "It seems to be enough."

**Scene 2b: the plan, unrolled.** In the archive, Perdita spreads the whole old plan across a table and weights its corners with inkwells.

**PERDITA:** "Here is the gate to the north, the steppe gate. Here, to the south, a postern. And here, in the heart of the keep, the *inward* gate."
**PERDITA:** "Whoever drew it was careful. Every door has a name. The inward gate has none."
**PERDITA:** "I counted the lines. He drew it four times. Each time, he left the name blank, as if he meant to fill it in, and then did not."
*She smooths a curling corner.*
**PERDITA:** "I have worked here thirty years. I thought I knew every secret this city had. I find I rather like being wrong."

**Outcomes and receipt.**
- The chamber is resealed or left open; the Warden is told or is not. Nothing else is found; nothing else happens.
- **Receipt:** a sketch of the chamber and the bench in the Journal. No explanation.
- **Canon-safe:** pure seed. Who sat on the bench, and what the inward-facing gate was for, are never explained.

<!-- quest
id: qst_bas_inward_gate
title: The Gate That Faced Inward
rank: S
type: Hidden
giver: npc_perdita_underhill
region: reg_bastion
level: 166
act: 5
requires_rank: S
reward: 66000 | 2900 | 305000
sets: bas_inward_gate_done
summary: A plan of the first fort shows a gate that faces inward. Behind a plastered arch in the undercroft is a bench.
objectives:
  talk npc_perdita_underhill
  reach bastion_undercroft_arch
  choice leave_cup_or_sit
-->

---

## 9. A Cub in the Broken Rings

*S · OddJob · the Broken Rings · giver Wren Gravelmouth*

**The short version.** Wren, nine, hunts scrap among the ruins of broken rings. She has found a sabretooth cub. It purrs. It is the horde's mount's child.

**What is really going on.** The cub's mother was killed in a skirmish, and the cub has been living on Wren's stolen sausages. Wren knows exactly what a sabretooth is. She does not care. She wants the cub to live, and she does not know where it should go.

**Scene 1: the rubble.**

**WREN:** "I'm not scared of him. He's *this* big."
**WREN:** "He bit me. Gently. Look."
**WREN:** "Don't tell the sergeant. Please."
> ► **"What is it?"** — **WREN:** "A cat. A very small cat."
> ► **"It's a sabretooth."** — **WREN:** "*He* doesn't know."
> ► **"Where's his mother?"** — **WREN:** (very quietly) "...Gone."

**Scene 2: the cub.** In a nest of sacking, between two fallen blocks, a tawny cub the size of a cat sleeps, fangs not yet grown, one paw over its nose. It opens a gold eye and chirps.

**CUB (a tiny, hoarse chirp):** *mrrrp?*
*It crawls across the sacking and bumps its head against the player's hand.*
**WREN:** "He likes you. He doesn't like anyone."

**Scene 3: the question.** Wren sits with her knees up.

**WREN:** "The sergeants say the horde's cats must all die. But he's *small.*"
**WREN:** "What do I do with him?"
> ► **"Keep him in the city."** — **WREN:** "Where? He'll be bigger than the barn."
> ► **"Take him north, to the horde."** — **WREN:** "They'd *eat* me!"
> ► **"Give him to Tarn."** — Wren perks up. "The wolf-man? He seemed... all right."

**Scene 4: the leaving.** However the cub is placed, Wren hugs it for a long time, nose in its fur.

**WREN:** "He's going to forget me."
**WREN:** "No he won't. Cats don't. Do they?"
*The cub licks her chin. It does not answer. It does not need to.*

**Scene 2b: the sausage.** Wren shows the player her secret supplier, a scarred butcher who has been "losing" sausages for three weeks and has not once reported the theft.

**BUTCHER:** "A sausage goes missing. A crumb of bread. I don't count anymore."
**BUTCHER:** "My late wife would have fed her. She fed every stray. I would be a poor husband to her memory if I stopped."
**WREN:** "He knows!"
**BUTCHER:** "Of course I know. Whose idea do you think it was to leave the back door unlatched?"
*Wren stares. Then she throws her arms around his apron.*
**WREN:** "I didn't say it was a *sabretooth,* though."
**BUTCHER:** "Wren. I have a *butcher's* nose."

**Scene 2b: the nest's visitor.** That night the cub hunts, badly, a beetle on the rubble, and Wren sits very still while it pounces on her shoelace instead.

**WREN:** "He thinks he is a hunter. He is mostly a sock."
**WREN:** "I will not say he is a good boy. I will say he is trying."
*The cub trips, rolls, and lies on its back with all four paws in the air, outraged at the ground.*
**WREN:** "See? A very fierce animal."
> ► **"Very fierce."** — She nods gravely, and offers it a bit of sausage.

**Outcomes and receipt.**
- The cub is raised quietly in a stable at the Citadel (the Warden pretends not to see); or carried north under a white cloth to a camp that will keep it; or given to the deserter's sister, who has asked for something small to hold.
- **Receipt:** a tiny claw-shaped charm on a string; Wren wears it for the rest of the siege.

<!-- quest
id: qst_bas_cub_rings
title: A Cub in the Broken Rings
rank: S
type: OddJob
giver: npc_wren_gravelmouth
region: reg_bastion
level: 168
act: 5
requires_rank: S
reward: 68000 | 3000 | 315000
sets: bas_cub_rings_done
summary: A nine-year-old has hidden a sabretooth cub in the ruins of a broken ring. She does not know where it should go.
objectives:
  talk npc_wren_gravelmouth
  reach bastion_broken_ring_nest
  choice keep_north_or_tarn
-->

---

## 10. The Night Between the Rings

*S · Defense · the outer ring and the new ring · giver Master Mason Berwyn Stonehall*

**The short version.** The masons need one more night to close the next ring. The horde has broken the outer one early. The gap between them is a village of four thousand, and Berwyn needs the night.

**What is really going on.** This is the shape of Bastion: the old ring breaks, the new ring is not quite done, and the people between must be brought through a gap that is still being laid. The ring will not hold. It is not meant to. The player's job is to keep the gap *open* and the people *moving* until the last course is set.

**Scene 1: the new ring.**

**BERWYN:** "One night. That is all I ask. The last course is not dry. The east gate is not hung."
**BERWYN:** "The outer ring went three days early."
**BERWYN:** "There are four thousand people between the old wall and mine. They will not all fit before the horde arrives."
> ► **"What do you need?"** — **BERWYN:** "Time. Hands. A gate that does not fall."
> ► **"Can they all get in?"** — **BERWYN:** "If we are fast and nobody stops to pack."
> ► **"I'll hold the road."** — **BERWYN:** "Do not hold it too well. We have to close it afterward."

**Scene 2: the road.** A river of lanterns runs through the dark: families, goats, carts, grandmothers carried on doors. At the road's far end, the half-built gate yawns.

**BERWYN (shouting up):** "Faster! The cats are on the hill!"
*A far-off horn sounds. Then a second, nearer.*

**Scene 3: the choices.** Three bottlenecks need holding at once.

> ► **"Hold the ford."** — The player stands in the shallows with a line of spearmen as the first cats surge.
> ► **"Carry the wounded."** — The player runs a stretcher shuttle from the outer ring's infirmary, again and again.
> ► **"Hang the gate."** — The player and a dozen masons haul the east gate-leaf up on ropes, hand over hand.

**SERGEANT:** "They're through the first line!"
**BERWYN:** "Not yet. *Not yet.* One more course!"

**Scene 4: the closing.** Near dawn the last family stumbles through. The gate-leaf swings home. A mason slaps the final stone into its course.

**BERWYN:** (hoarsely) "Done. The new ring is done."
*From beyond it, a roar rises. A fall of stone. The outer ring, finally, is gone.*
**BERWYN:** "A stone from that ring goes into the next one. Find me a stone."
*A child in the crowd holds up a fist-sized chunk of the broken wall.*

**Scene 2b: the last course.** At midnight Berwyn stops everything for one minute. He walks the length of the unfinished ring with a lantern, and lays his hand on every tower.

**BERWYN:** "Eight rings. I have set the footing of eight. I have buried none of them."
**BERWYN:** "A city is a long promise. I have helped to make eight of it."
**BERWYN:** "If the ninth fails, it will not be the stone. It will be that we did not have the *time.*"
*He turns to the player, plaster in his beard, eyes bright.*
**BERWYN:** "So. Give me the time. I will do the rest."
> ► **"You'll have it."** — He claps a hand to the player's shoulder and goes back to work.

**Outcomes and receipt.**
- The new ring stands. The horde is at its gate by sunrise. The number saved depends on the choices: the ford saves the rear, the stretchers the wounded, the gate the whole city.
- **Receipt:** the child's chunk of broken wall, now mortared into the new ring, with the player's mark scratched on its underside.
- **Canon-safe:** the siege goes on. Thrakka is not seen, named or addressed.

<!-- quest
id: qst_bas_night_between
title: The Night Between the Rings
rank: S
type: Defense
giver: npc_berwyn_stonehall
region: reg_bastion
level: 172
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: bas_night_between_done
summary: The outer ring broke early and the next is not done. Four thousand people stand between them. The masons need one night.
objectives:
  talk npc_berwyn_stonehall
  defend bastion_road_between_rings
  choice ford_wounded_or_gate
-->
