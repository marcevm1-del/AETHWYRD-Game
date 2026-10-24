---
type: tuning-reference
source: Data/World/world_tuning.json
tags: [system, tuning]
---
# World Tuning

Shared calendar, siege, prosperity and inn tuning used by the engine-agnostic game rules. The weekday order and day length are locked in Canon; the numeric details remain data-driven.

| Key | Value |
|---|---|
| `version` | 1 |
| `notes` | World-rule tuning: calendar, regional sieges, inns. Read by Code/Ascend.Core (WorldTuning). |
| `currency.baseUnit` | copper |
| `currency.displayOrder` | copper, silver, gold, platinum, mithril |
| `currency.denominations` | [object Object], [object Object], [object Object], [object Object], [object Object] |
| `currency.conversionRate` | 100 |
| `currency.autoMakeChange` | true |
| `calendar.dayLengthRealMinutes` | 90 |
| `calendar.hoursPerDay` | 24 |
| `calendar.weekdays` | Solenday, Maelsday, Thorsday, Sylvasday, Kaelsday, Morrowsday, Vexday |
| `calendar.dawnHour` | 6 |
| `calendar.dayParts.morning` | 6, 10 |
| `calendar.dayParts.day` | 10, 17 |
| `calendar.dayParts.dusk` | 17, 20 |
| `calendar.dayParts.night` | 20, 6 |
| `siege.minAttacksPerWeek` | 1 |
| `siege.maxAttacksPerWeek` | 2 |
| `siege.secondAttackChance` | 0.5 |
| `siege.duskChance` | 0.8 |
| `siege.duskHour` | 18 |
| `siege.nightHour` | 21 |
| `siege.announceDaysAhead` | 1 |
| `siege.escalationPerWeek` | 1 |
| `siege.maxEscalation` | 5 |
| `siege.weakenedEscalationReduction` | 2 |
| `siege.autoResolve.baseThreat` | 40 |
| `siege.autoResolve.escalationThreat` | 8 |
| `siege.autoResolve.safetyWeight` | 0.5 |
| `siege.autoResolve.guardWeight` | 3 |
| `siege.autoResolve.adventurerWeight` | 6 |
| `siege.autoResolve.barricadeWeight` | 2 |
| `siege.autoResolve.variance` | 20 |
| `siege.autoResolve.repelMargin` | 10 |
| `siege.autoResolve.costlyMargin` | -10 |
| `siege.autoResolve.maxWealthLoss` | 15 |
| `siege.autoResolve.maxSafetyLoss` | 20 |
| `siege.autoResolve.maxBuildingsDamaged` | 3 |
| `siege.autoResolve.prosperityFloor` | 10 |
| `inns.restedXpBonus` | 0.05 |
| `inns.wellRestedXpBonus` | 0.1 |
| `inns.mealBonusHours` | 1 |
| `inns.bathBonusHours` | 1 |
| `inns.regular.guestNights` | 3 |
| `inns.regular.regularNights` | 10 |
| `inns.regular.familyNights` | 30 |
| `inns.tab.creditLimitCopper` | 600 |
| `inns.tab.ranks` | F, E |
| `companions.notes` | Companion field AI, Ring 0 prototype (12_Systems/companion_field_ai.md). Distances in metres, times in seconds; assistPower is a multiple of a normal hit. |
| `companions.followDistance` | 2.5 |
| `companions.personalSpace` | 1.4 |
| `companions.regroupDistance` | 20 |
| `companions.leash` | 12 |
| `companions.reachM` | 1.8 |
| `companions.attackIntervalSec` | 1.1 |
| `companions.attackPower` | 1 |
| `companions.assistPower` | 2.5 |
| `companions.dodgeCooldownSec` | 2 |
| `companions.dodgeDistance` | 2.5 |
| `companions.downedSec` | 20 |
| `companions.banterCooldownSec` | 25 |
| `bestiary.notes` | hud_and_ui.md §9 appraisal tiers for the Bestiary: 1 seen (name, rank, Menace), 2 HP, element and weakness, 3 attacks, drops and lore; the stamp needs tier 3 and every drop found. Taming fills an entry to tier 3 at once (systems.md §7.4). |
| `bestiary.seenRadius` | 20 |
| `bestiary.tier2Kills` | 3 |
| `bestiary.tier3Kills` | 10 |
| `taming.notes` | systems.md §7.1: weaken below the HP threshold without killing, raise calm and keep fear down, then offer (CHA + Tamer skill check, favourite food bonus). |
| `taming.weakenHpFraction` | 0.3 |
| `taming.nearMeters` | 4 |
| `taming.calmPerSec` | 10 |
| `taming.crouchCalmPerSec` | 8 |
| `taming.fearPerAttack` | 30 |
| `taming.fearPerDodge` | 15 |
| `taming.fearDecayPerSec` | 4 |
| `taming.likedFoodCalm` | 35 |
| `taming.wrongFoodFear` | 10 |
| `taming.baseChance` | 0.2 |
| `taming.calmWeight` | 0.006 |
| `taming.fearWeight` | 0.006 |
| `taming.chaWeight` | 0.01 |
| `taming.likedFoodBonus` | 0.15 |
| `taming.tamerBonus` | 0.15 |
| `taming.enrageChance` | 0.35 |
| `taming.retrySec` | 60 |
| `taming.activePartners` | 3 |
| `taming.bondPerAssists` | 3 |
| `taming.partnerGrowthPerLevel` | 0.06 |
| `taming.maxBond` | 10 |
| `taming.evolveBond` | 5 |
| `taming.knockedOutSec` | 20 |
| `taming.supportHealFraction` | 0.03 |
| `taming.supportHealEverySec` | 6 |
| `taming.wildnessNotes` | After RimWorld's per-animal wildness and manhunter-on-tame-fail chance (design reference, 13_Production/reference_games.md): how hard a species is to win over, and how likely a failed offer makes it turn on you, by behaviour. |
| `taming.wildnessByBehavior.Passive` | 0.2 |
| `taming.wildnessByBehavior.Territorial` | 0.5 |
| `taming.wildnessByBehavior.Swarm` | 0.55 |
| `taming.wildnessByBehavior.Guardian` | 0.6 |
| `taming.wildnessByBehavior.Ambush` | 0.65 |
| `taming.wildnessByBehavior.Pack` | 0.7 |
| `taming.wildnessByBehavior.Skittish` | 0.75 |
| `taming.wildnessByBehavior.Aggressive` | 0.85 |
| `taming.wildnessWeight` | 0.3 |
| `taming.enrageByBehavior.Passive` | 0 |
| `taming.enrageByBehavior.Skittish` | 0.05 |
| `taming.enrageByBehavior.Ambush` | 0.25 |
| `taming.enrageByBehavior.Territorial` | 0.3 |
| `taming.enrageByBehavior.Guardian` | 0.3 |
| `taming.enrageByBehavior.Swarm` | 0.35 |
| `taming.enrageByBehavior.Pack` | 0.4 |
| `taming.enrageByBehavior.Aggressive` | 0.5 |
| `taming.nuzzleEveryMinutes` | 8 |
| `taming.trainabilityNotes` | After RimWorld's trainability (none / intermediate / advanced): which partner orders a family can learn. none = Follow only; intermediate = Follow, Hold; advanced = Follow, Hold, Focus. Families not listed are intermediate. |
| `taming.trainabilityByFamily.Beasts` | advanced |
| `taming.trainabilityByFamily.Avians` | advanced |
| `taming.trainabilityByFamily.Lycanthropes` | advanced |
| `taming.trainabilityByFamily.Reptiles` | advanced |
| `taming.trainabilityByFamily.Familiars & Gentle Creatures` | advanced |
| `taming.trainabilityByFamily.Chimeras & Mythic Beasts` | advanced |
| `taming.trainabilityByFamily.Dragons` | advanced |
| `taming.trainabilityByFamily.Slimes` | intermediate |
| `taming.trainabilityByFamily.Insects & Arachnids` | intermediate |
| `taming.trainabilityByFamily.Killer Insects` | intermediate |
| `taming.trainabilityByFamily.Elementals & Spirits` | intermediate |
| `taming.trainabilityByFamily.Aquatic` | intermediate |
| `taming.trainabilityByFamily.Plants & Fungi` | none |
| `taming.untameableFamilies` | Goblinoids, Humanoid Enemies, Undead, Constructs & Mimics, Demons |
| `taming.favouriteFood.Slimes` | itm_healing_herb |
| `taming.favouriteFood.Beasts` | itm_mat_prime_meat |
| `taming.favouriteFood.Avians` | itm_mat_seed |
| `taming.favouriteFood.Insects & Arachnids` | itm_mat_sap |
| `taming.favouriteFood.Plants & Fungi` | itm_mat_sap |
| `taming.favouriteFood.Elementals & Spirits` | itm_core_f |
| `taming.favouriteFood.Familiars & Gentle Creatures` | itm_healing_herb |
| `map.notes` | 12_Systems/world_map.md: the map starts blank and inks itself. Visited lands are inked, heard-of lands pencilled. The guild's map seal names the surface up to a ring at each guild rank; the System overlay (rank-coloured zones, grid) arrives at Rank E (hud_and_ui.md §16). The local map inks a grid of areaCellMetres cells within areaRevealMetres of you. Seas (named on the atlas) get their name on your map once a land within seaNameRange map units of the label is on it. |
| `map.startVisited` | reg_whisperwood |
| `map.startHeard` | reg_aldmere, reg_greymoor, reg_labyrinth_upper |
| `map.guildMapRings.E` | 3 |
| `map.guildMapRings.D` | 4 |
| `map.guildMapRings.C` | 5 |
| `map.guildMapRings.B` | 6 |
| `map.guildMapRings.A` | 7 |
| `map.systemOverlayRank` | E |
| `map.areaCellMetres` | 4 |
| `map.areaRevealMetres` | 14 |
| `map.seaNameRange` | 30 |
| `map.seas` | [object Object], [object Object] |

Edit the source JSON, validate it, and rerun the relevant review before treating a tuned value as approved. This vault note is generated and will be overwritten on rebuild.
