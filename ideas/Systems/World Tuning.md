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
| `taming.untameableFamilies` | Goblinoids, Humanoid Enemies, Undead, Constructs & Mimics, Demons |
| `taming.favouriteFood.Slimes` | itm_healing_herb |
| `taming.favouriteFood.Beasts` | itm_mat_prime_meat |
| `taming.favouriteFood.Avians` | itm_mat_seed |
| `taming.favouriteFood.Insects & Arachnids` | itm_mat_sap |
| `taming.favouriteFood.Plants & Fungi` | itm_mat_sap |
| `taming.favouriteFood.Elementals & Spirits` | itm_core_f |
| `taming.favouriteFood.Familiars & Gentle Creatures` | itm_healing_herb |

Edit the source JSON, validate it, and rerun the relevant review before treating a tuned value as approved. This vault note is generated and will be overwritten on rebuild.
