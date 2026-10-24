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

Edit the source JSON, validate it, and rerun the relevant review before treating a tuned value as approved. This vault note is generated and will be overwritten on rebuild.
