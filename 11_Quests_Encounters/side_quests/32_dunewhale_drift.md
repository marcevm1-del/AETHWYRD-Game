# 11e-32 — Dunewhale Drift, the Moving Town: Ten Side Quests (draft)

> *"We do not say 'where are we.' We say 'where is she taking us.'"*
> — Drift proverb

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). Hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**Region:** `reg_dunewhale_drift` (the town on Thalassa's back, Thalassa's Crown, the Glass Trails, the open sand). **Rank band:** B–A. **Tone:** swaying, close, proud, tender toward the whale, wary of strangers.

**Placement notes.**
- **Thalassa** is the last known sand-whale. She is swimming faster and singing less. **Glassmaw** has followed her for a month. No quest here kills Glassmaw, explains why Thalassa is afraid, or finds another whale. Hints only.
- Customs used: births are announced to her and deaths sung into her ear; the whale-singers guide her; visitors get seasick; the town trades at oases.
- Earlier pattern quests set here are not repeated.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | Sea Legs, Sand Legs | B | OddJob | Purser Mira Lashline | Comedy of seasickness |
| 2 | The Calendar of Her Songs | B | Investigation | Archivist Oben Cordwain | A pattern in silences |
| 3 | A Lullaby the Whale Does Not Know | B | Hidden | Singer-in-Training Kesi | A child's song |
| 4 | Barnacle Rot | B | Defense | Rigger Haldane Hookmark | Cables failing |
| 5 | The Glass Garden | B | Exploration | Glazier Anselm Tarr | Beauty left by a monster |
| 6 | Sand-Fish Season | B | Gathering | Netmaster Ruan | Plain, warm work |
| 7 | A Death Sung Wrong | A | Faction | Singer Dalia Oneiros | Grief and a mistake |
| 8 | The Captain's Vote | A | Faction | Captain Bram Saltwind | An election at sea |
| 9 | The Other Town | A | Exploration | Old Teodor Wake | A memory of three whales |
| 10 | What She Hums at Night | A | Hidden | Singer Iolanthe Veil | A seed, unexplained |

## Cast

<!-- npc
id: npc_mira_lashline
name: Purser Mira Lashline
tier: townsfolk
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Purser who greets visitors
backstory: A brisk purser who has watched a thousand land-dwellers lose their lunch and keeps a bucket, a ginger biscuit and a polite smile ready for each.
-->
<!-- npc
id: npc_oben_cordwain
name: Archivist Oben Cordwain
tier: major
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Keeper of the calendar of Thalassa's songs
backstory: A stooped archivist who keeps nine generations of song-records and has noticed the silences are no longer random.
-->
<!-- npc
id: npc_kesi_singer
name: Kesi
tier: townsfolk
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Whale-singer in training
backstory: A nervous eleven-year-old apprentice who is not yet allowed to sing to Thalassa and has been writing her a song in secret.
-->
<!-- npc
id: npc_haldane_hookmark
name: Rigger Haldane Hookmark
tier: townsfolk
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Master rigger of the hide-cables
backstory: A weathered rigger who has re-hooked the town's cables for thirty years and swears the barnacles are letting go on purpose.
-->
<!-- npc
id: npc_anselm_tarr
name: Glazier Anselm Tarr
tier: townsfolk
race: Human
region: reg_dunewhale_drift
settlement: The Glass Trails
role: Glazier who gathers Glassmaw's glass
backstory: A quiet glazier who turns the worm's trails into lamps and windows and feels guilty that he finds them beautiful.
-->
<!-- npc
id: npc_ruan_netmaster
name: Netmaster Ruan
tier: townsfolk
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Netmaster of the sand-fishers
backstory: A broad, cheerful netmaster whose crews have fed the town through every lean month and who is short of hands this season.
-->
<!-- npc
id: npc_dalia_oneiros
name: Singer Dalia Oneiros
tier: major
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Whale-singer who sings the dead
backstory: A grave, precise whale-singer who sang a death into Thalassa's ear in the wrong key last month and cannot forgive herself.
-->
<!-- npc
id: npc_bram_saltwind
name: Captain Bram Saltwind
tier: major
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Captain of the Drift
backstory: An easy-going elected captain facing the first contested vote in forty years, over whether to turn Thalassa toward the sea.
-->
<!-- npc
id: npc_teodor_wake
name: Old Teodor Wake
tier: townsfolk
race: Human
region: reg_dunewhale_drift
settlement: The town on Thalassa's back
role: Oldest rider of the Drift
backstory: A ninety-year-old rider who remembers the great festival of the three whale-towns as a boy and talks to the empty horizon as if it were still there.
-->
<!-- npc
id: npc_iolanthe_veil
name: Singer Iolanthe Veil
tier: major
race: Human
region: reg_dunewhale_drift
settlement: Thalassa's Crown
role: Night-singer of the Crown
backstory: A sleepless whale-singer who keeps the night watch on the Crown and has begun to hear Thalassa hum a song nobody taught her.
-->

---

## 1. Sea Legs, Sand Legs

*B · OddJob · the town gangways · giver Purser Mira Lashline*

**Short version.** Mira has a week's worth of land-dwelling arrivals and a staff down with colds. She needs someone to meet the ferry-sleds, walk the sick to the infirmary and keep their dignity intact.

**Really going on.** Seasickness is the town's one reliable joke, and under it is pride: a visitor who walks the streets steadily is accepted a little faster. The player learns the *gait* (knees soft, eyes on the horizon) and teaches it. A noble in fine boots refuses to learn and insists on dignity.

**Scenes.**
**MIRA:** "Eyes on the horizon, hand on the rope, and *never* say 'I'm fine.' That's what they say right before."
> ► **"Do you get used to it?"** — **MIRA:** "Eleven years to get used to *land.* I was sick for a month when I visited."
> ► **"I'll take the gangway."** — **MIRA:** "Bucket's under the rail."

*A noble in embroidered boots refuses the ginger biscuit, then the bucket. The player may hold the rope, distract with conversation, or let it happen.* Afterward the noble, green and humbled, asks for the biscuit twice.

**Outcomes.** Kind help earns the noble's quiet gratitude; mocking costs a small reputation. **Receipt:** a ginger biscuit in the pocket; visitors greet the player as "steady-legs."

<!-- quest
id: qst_dwd_sea_legs
title: Sea Legs, Sand Legs
rank: B
type: OddJob
giver: npc_mira_lashline
region: reg_dunewhale_drift
level: 92
act: 3
requires_rank: B
reward: 10000 | 600 | 44000
sets: dwd_sea_legs_done
summary: A purser needs help guiding seasick land-dwellers through the swaying town without losing their dignity.
objectives:
  talk npc_mira_lashline
  reach dunewhale_gangway
  choice rope_talk_or_laugh
-->

---

## 2. The Calendar of Her Songs

*B · Investigation · the archive loft · giver Archivist Oben Cordwain*

**Short version.** Nine generations of records say Thalassa sings at the new moon, at storms and at births. Lately she skips. Oben wants to know whether the silences follow a pattern.

**Really going on.** They do: each silence is shorter than the interval before Glassmaw's last approach. She is not silent from sorrow; she is *listening.* Oben cannot say for what. The player is shown only the pattern, not the cause.

**Scenes.**
**OBEN:** "Nine hundred entries. Four hundred and twelve songs. Look at the gaps."
*The player cross-references the calendar with the Glass Trails' ages on a long table of tide-charts and lantern oil.*
**OBEN:** "She stops *before* it comes. Every time. As if she hears it coming."
> ► **"She is afraid."** — **OBEN:** "Perhaps. Or she is *keeping quiet* so it cannot hear."
> ► **"Could the town sing for her?"** — **OBEN:** "The singers will say no."

**Outcomes.** Oben adds a line to the calendar: *"She is listening."* **Receipt:** a page in the Journal showing the gaps as a diagram. No explanation of what she hears.

<!-- quest
id: qst_dwd_calendar_songs
title: The Calendar of Her Songs
rank: B
type: Investigation
giver: npc_oben_cordwain
region: reg_dunewhale_drift
level: 94
act: 3
requires_rank: B
reward: 10500 | 620 | 46000
sets: dwd_calendar_done
summary: An archivist compares nine generations of Thalassa's songs and finds her silences fall before Glassmaw comes.
objectives:
  talk npc_oben_cordwain
  reach dunewhale_archive_loft
  choice afraid_listening_or_sing
-->

---

## 3. A Lullaby the Whale Does Not Know

*B · Hidden · Thalassa's Crown · giver Kesi*

**Short version.** Kesi, eleven, is not yet allowed to sing to Thalassa. She has written her a song anyway and wants someone to stand lookout on the Crown at dusk.

**Really going on.** The song is not a masterpiece; the notes are off in two places. But Thalassa's hide twitches at the third verse, and the town's cables hum in answer. A whale-singer on watch may notice, and the choice is whether to protect or reveal the child.

**Scenes.**
**KESI:** "Don't tell Singer Dalia. It's forbidden. But she's *alone,* and I know a song."
> ► **"Sing, I'll watch."** — **KESI:** "Don't look at me."
> ► **"It's against the rules."** — **KESI:** "I know."

*At dusk Kesi sings on the Crown. The hide stirs. The cables sigh. A whale-singer appears at the stair, listens, and says nothing.*

**Outcomes.** If the player kept watch, the singer lets it pass and later offers Kesi a place early; if the player reported her, Kesi is scolded but trusted less. **Receipt:** a hand-written lullaby, off-key, kept in the Journal; Thalassa's hum sometimes carries its tune.

<!-- quest
id: qst_dwd_lullaby
title: A Lullaby the Whale Does Not Know
rank: B
type: Hidden
giver: npc_kesi_singer
region: reg_dunewhale_drift
level: 90
act: 3
requires_rank: B
reward: 9500 | 580 | 42000
sets: dwd_lullaby_done
summary: An apprentice not yet allowed to sing to Thalassa has written her a song and needs a lookout.
objectives:
  talk npc_kesi_singer
  reach dunewhale_thalassas_crown
  choice watch_or_report
-->

---

## 4. Barnacle Rot

*B · Defense · the hide-cables · giver Rigger Haldane Hookmark*

**Short version.** Barnacle anchors are failing and houses are drifting. Haldane suspects a sand-ray swarm eating the barnacle roots.

**Really going on.** Not sabotage. The rays are starving, driven off their usual shoals by Glassmaw. Killing them is easy; feeding them is harder, and kinder.

**Scenes.**
**HALDANE:** "I've rigged this town thirty years. The barnacles are letting go on purpose. Spite, I say."
*Wave defense: sand-rays surge at the cable bases while the player re-hooks anchors.* Choices: scatter them with noise, lay out sand-fish bait away from the cables, or cull.

**Outcomes.** Baiting saves the rigging and spares the rays; culling saves it faster but empties the nearby sand of life. **Receipt:** a row of fresh iron hooks stamped with the player's mark.

<!-- quest
id: qst_dwd_barnacle_rot
title: Barnacle Rot
rank: B
type: Defense
giver: npc_haldane_hookmark
region: reg_dunewhale_drift
level: 96
act: 3
requires_rank: B
reward: 11000 | 650 | 48000
sets: dwd_barnacle_done
summary: Barnacle anchors are failing; starving sand-rays are eating the roots.
objectives:
  talk npc_haldane_hookmark
  defend dunewhale_hide_cables
  choice scatter_bait_or_cull
-->

---

## 5. The Glass Garden

*B · Exploration · the Glass Trails · giver Glazier Anselm Tarr*

**Short version.** Glassmaw's trails fuse into shapes the worm never meant: bells, trees, a long arch. Anselm wants help harvesting a glass garden before the next wind-storm shatters it.

**Really going on.** The beauty is real and the monster is real. Anselm is torn, and the player may decide whether to take, leave or merely record. A glass tree rings when the wind passes, and the note is the same as Thalassa's lowest hum.

**Scenes.** A hushed trek along shining trails; Anselm tapping panes and weeping a little. 
> ► **(Harvest the best pieces.)** — Lamps and windows for the town.
> ► **(Record and leave.)** — Anselm sketches the whole garden.
> ► **(Shatter the arch.)** — A bright ruin; **ANSELM:** "...I didn't want it to stay either."

**Outcomes.** Each path leaves a different relic. **Receipt:** a glass bell that rings Thalassa's low note.

<!-- quest
id: qst_dwd_glass_garden
title: The Glass Garden
rank: B
type: Exploration
giver: npc_anselm_tarr
region: reg_dunewhale_drift
level: 96
act: 3
requires_rank: B
reward: 11000 | 650 | 48000
sets: dwd_glass_garden_done
summary: Glassmaw's trails have fused into a beautiful garden of glass that the next storm will shatter.
objectives:
  talk npc_anselm_tarr
  reach dunewhale_glass_garden
  choice harvest_record_or_shatter
-->

---

## 6. Sand-Fish Season

*B · Gathering · the open sand · giver Netmaster Ruan*

**Short version.** The glittering sand-fish run for three days. Ruan is short of hands and the town is short of food.

**Really going on.** Plain, warm, communal. The run is also a cheerful reminder of how much of the town's year depends on one whale's route. Ruan's crew sings net-songs that borrow phrases from Thalassa's own.

**Scenes.** A long lively day in a net line; Ruan teaches the crew to haul on the beat. A child falls in the sand and is hauled out laughing.
> ► **(Haul with the crew.)** — Full nets.
> ► **(Scout ahead for Glassmaw.)** — Safer but slower.
> ► **(Sing with them.)** — The sand-fish swarm thicker.

**Outcomes.** A feast on the third night. **Receipt:** a sand-fish scale charm; Ruan's crew sings the player's verse next season.

<!-- quest
id: qst_dwd_sandfish
title: Sand-Fish Season
rank: B
type: Gathering
giver: npc_ruan_netmaster
region: reg_dunewhale_drift
level: 92
act: 3
requires_rank: B
reward: 10000 | 600 | 44000
sets: dwd_sandfish_done
summary: Glittering sand-fish run for three days and the netmaster is short of hands.
objectives:
  talk npc_ruan_netmaster
  collect sand_fish 20
  choice haul_scout_or_sing
-->

---

## 7. A Death Sung Wrong

*A · Faction · Thalassa's Crown · giver Singer Dalia Oneiros*

**Short version.** Dalia sang a death into Thalassa's ear in the wrong key. She cannot forgive herself and asks for a witness while she tries to sing it right.

**Really going on.** The dead man's family forgave her at once. It is Dalia who cannot. The player's role is to listen, and decide whether to tell her the truth: that no one in the town heard the mistake but her.

**Scenes.**
**DALIA:** "A half-tone flat. One note. He is in the sand, and I sent him there wrong."
> ► **"Sing it again."** — A long, steady, painful take.
> ► **"Who heard it?"** — **DALIA:** "Thalassa."
> ► **"Did she mind?"** — A silence. **DALIA:** "She hummed it back. The right way."

*Thalassa's hum rolls up through the Crown, a half-tone above where Dalia stopped. The correction is gentle.*

**Outcomes.** Dalia forgives herself, or does not, depending on whether the player pressed. **Receipt:** a tuning fork left on the Crown.

<!-- quest
id: qst_dwd_death_sung_wrong
title: A Death Sung Wrong
rank: A
type: Faction
giver: npc_dalia_oneiros
region: reg_dunewhale_drift
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: dwd_death_sung_done
summary: A whale-singer sang a death into Thalassa's ear in the wrong key and cannot forgive herself.
objectives:
  talk npc_dalia_oneiros
  reach dunewhale_thalassas_crown
  choice resing_ask_or_listen
-->

---

## 8. The Captain's Vote

*A · Faction · the town square · giver Captain Bram Saltwind*

**Short version.** For the first time in forty years the captaincy is contested, over one question: turn Thalassa toward the sea, or keep her in the sand. Bram asks for help making sure the vote is fair.

**Really going on.** Both sides love her. One fears Glassmaw will keep chasing them; the other fears the ocean will be too much for a sand-whale. Neither is wrong, and neither can be proven. The player's job is the *process:* honest counts, quiet nights, no threats.

**Scenes.** Rope-ballot counting by lantern; a heckler; a quiet rider who changes the tally by confessing she cannot decide.
> ► **(Guard the ballots.)** — A tense night.
> ► **(Hear both sides.)** — Long speeches.
> ► **(Cast no opinion.)** — **BRAM:** "Good. Stay out of it. It's ours."

**Outcomes.** The vote is close; the result is announced but Thalassa's own course is not decided by it (no resolution). **Receipt:** a rope-ballot knot kept as a keepsake.

<!-- quest
id: qst_dwd_captains_vote
title: The Captain's Vote
rank: A
type: Faction
giver: npc_bram_saltwind
region: reg_dunewhale_drift
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: dwd_vote_done
summary: A contested captaincy turns on whether to steer the sand-whale toward the sea.
objectives:
  talk npc_bram_saltwind
  reach dunewhale_town_square
  choice guard_hear_or_abstain
-->

---

## 9. The Other Town

*A · Exploration · the Glass Trails · giver Old Teodor Wake*

**Short version.** Teodor, ninety, remembers the great festival of the three whale-towns and wants to see where the second whale fell. He cannot walk the sand alone.

**Really going on.** The place is a field of old glass and bones, and, half-buried, a rope-bridge between two towns that no longer exist. Teodor sings the festival song once, alone. The wind answers with a few notes from the glass.

**Scenes.** A long, gentle escort; Teodor naming the dead by their house-colours. At the field he lays a ribbon and speaks to the horizon.
> ► **(Stand with him.)** — Silence.
> ► **(Ask about the festival.)** — A delighted story.
> ► **(Help him sing.)** — The wind answers.

**Outcomes.** Teodor is at peace. **Receipt:** a faded festival ribbon.

<!-- quest
id: qst_dwd_other_town
title: The Other Town
rank: A
type: Exploration
giver: npc_teodor_wake
region: reg_dunewhale_drift
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: dwd_other_town_done
summary: The oldest rider wants to see where the second whale-town fell.
objectives:
  talk npc_teodor_wake
  escort npc_teodor_wake
  reach dunewhale_fallen_town
-->

---

## 10. What She Hums at Night

*A · Hidden · Thalassa's Crown · giver Singer Iolanthe Veil*

**Short version.** Iolanthe keeps the night watch and has begun to hear Thalassa hum a song no one taught her. She asks the player to listen with her.

**Really going on.** *Nothing is explained.* The tune has four phrases. The first is Kesi's lullaby; the second is Dalia's corrected key; the third is unknown; the fourth rises, as if waiting for an answer. The quest ends before an answer.

**Scenes.**
**IOLANTHE:** "She's singing *back.* Not to us. To something."
> ► **(Listen.)** — Four phrases.
> ► **(Hum the fourth.)** — The hide stills, then ripples.
> ► **(Say nothing.)** — **IOLANTHE:** "Wise."

**Outcomes.** A sketch of four phrases in the Journal. **Canon-safe:** a pure seed; it does not say what she is answering.

<!-- quest
id: qst_dwd_hums_night
title: What She Hums at Night
rank: A
type: Hidden
giver: npc_iolanthe_veil
region: reg_dunewhale_drift
level: 134
act: 4
requires_rank: A
reward: 32500 | 1620 | 142000
sets: dwd_hums_done
summary: The night-singer hears Thalassa hum a four-phrase song no one taught her.
objectives:
  talk npc_iolanthe_veil
  reach dunewhale_crown_night
  choice listen_hum_or_silence
-->
