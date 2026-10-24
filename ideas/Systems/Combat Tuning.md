---
type: tuning-reference
source: Data/Combat/combat_tuning.json
tags: [system, tuning]
---
# Combat Tuning

Central tuning values for movement, camera, defense, attacks, poise, reactions, damage, style and feedback. Values are measured in the units described by the source data.

| Key | Value |
|---|---|
| `version` | 1 |
| `notes` | Feel-tuning values referenced by 12_Systems/combat.md (marked with a gear icon). Units: seconds, meters, meters/second, degrees. |
| `inputBufferSec` | 0.2 |
| `softLockAngleDeg` | 45 |
| `camera.distance` | 4.5 |
| `camera.fov` | 60 |
| `camera.groupPullBackDistance` | 6 |
| `camera.shakeMax` | 0.6 |
| `movement.walkSpeed` | 2.2 |
| `movement.runSpeed` | 6.5 |
| `movement.sprintSpeed` | 9.5 |
| `movement.sprintStaminaPerSec` | 12 |
| `movement.jumpHeight` | 1.6 |
| `dodge.durationSec` | 0.42 |
| `dodge.iframeSec` | 0.24 |
| `dodge.distance` | 4.2 |
| `dodge.staminaCost` | 20 |
| `dodge.maxChain` | 2 |
| `dodge.perfectDodgeWindowSec` | 0.15 |
| `flashTime.timeScale` | 0.25 |
| `flashTime.durationSec` | 0.8 |
| `parry.parryWindowSec` | 0.12 |
| `parry.blockDamageReduction` | 0.7 |
| `parry.riposteHitstopSec` | 0.16 |
| `combo.budgetPerString` | 3 |
| `combo.budgetRefillSec` | 2 |
| `combo.chargeLevels` | 0.4, 0.9, 1.5 |
| `combo.chargePowerMult` | 1, 1.3, 1.7, 2.2 |
| `combo.guardBreakLevel` | 2 |
| `combo.riposteWindowSec` | 1 |
| `hitstop.light` | 0.04 |
| `hitstop.medium` | 0.07 |
| `hitstop.heavy` | 0.11 |
| `hitstop.launch` | 0.08 |
| `hitstop.ultimate` | 0.18 |
| `attackTiming.notes` | Seconds per chain hit: startup -> active (hit lands on the first active frame) -> recovery. A buffered press starts the next hit when recovery begins. Dodge-cancel from active frame 1 (combat.md 4.1). |
| `attackTiming.light.startupSec` | 0.1 |
| `attackTiming.light.activeSec` | 0.08 |
| `attackTiming.light.recoverySec` | 0.24 |
| `attackTiming.medium.startupSec` | 0.16 |
| `attackTiming.medium.activeSec` | 0.1 |
| `attackTiming.medium.recoverySec` | 0.36 |
| `attackTiming.heavy.startupSec` | 0.26 |
| `attackTiming.heavy.activeSec` | 0.12 |
| `attackTiming.heavy.recoverySec` | 0.46 |
| `attackTiming.launch.startupSec` | 0.14 |
| `attackTiming.launch.activeSec` | 0.1 |
| `attackTiming.launch.recoverySec` | 0.32 |
| `attackTiming.chainResetSec` | 0.6 |
| `attackTiming.reachM` | 2.2 |
| `attackTiming.arcDeg` | 120 |
| `attackTiming.lungeM` | 0.35 |
| `reactions.auraDurationSec` | 6 |
| `reactions.freezeDurationSec` | 2.5 |
| `reactions.shatterBonus` | 1.8 |
| `reactions.stormPrisonStunSec` | 1.2 |
| `poise.small_biped` | 30 |
| `poise.quad_small` | 20 |
| `poise.blob` | 25 |
| `poise.medium_biped` | 50 |
| `poise.quad_large` | 70 |
| `poise.large_biped` | 140 |
| `poise.golem` | 200 |
| `poise.dragon` | 400 |
| `poiseRegen.delaySec` | 2.5 |
| `poiseRegen.fractionPerSec` | 0.25 |
| `bossBreakKnockdownSec` | 4 |
| `ai.maxSimultaneousAttackers` | 2 |
| `style.thresholds.C` | 0 |
| `style.thresholds.B` | 100 |
| `style.thresholds.A` | 250 |
| `style.thresholds.S` | 450 |
| `style.thresholds.SS` | 700 |
| `style.thresholds.SSS` | 1000 |
| `style.hitPoints.light` | 10 |
| `style.hitPoints.medium` | 15 |
| `style.hitPoints.heavy` | 25 |
| `style.hitPoints.launch` | 20 |
| `style.hitPoints.ultimate` | 80 |
| `style.hitPoints.skill` | 20 |
| `style.varietyMultiplier` | 1.5 |
| `style.varietyWindowHits` | 6 |
| `style.bonus.reaction` | 40 |
| `style.bonus.perfectDodge` | 60 |
| `style.bonus.parry` | 60 |
| `style.bonus.launchToSlam` | 50 |
| `style.decayPerSec` | 20 |
| `style.decayDelaySec` | 2 |
| `style.repeatPenaltyAfter` | 4 |
| `style.dropRanksOnHit` | 1 |
| `style.pointsCap` | 1200 |
| `style.xpBonus.C` | 0 |
| `style.xpBonus.B` | 0.05 |
| `style.xpBonus.A` | 0.1 |
| `style.xpBonus.S` | 0.15 |
| `style.xpBonus.SS` | 0.2 |
| `style.xpBonus.SSS` | 0.3 |
| `style.dropBonus.C` | 0 |
| `style.dropBonus.B` | 0 |
| `style.dropBonus.A` | 0.05 |
| `style.dropBonus.S` | 0.05 |
| `style.dropBonus.SS` | 0.1 |
| `style.dropBonus.SSS` | 0.1 |
| `damage.defenseConstant` | 100 |
| `damage.weaknessMult` | 1.5 |
| `damage.resistMult` | 0.5 |
| `damage.critBaseMult` | 1.5 |
| `damage.variance` | 0.95, 1.05 |
| `damage.stealthMult` | 2 |
| `feedback.notes` | Hit feedback (combat.md §7). Shake amplitude in metres before the accessibility scale; capped by camera.shakeMax. |
| `feedback.shake.light` | 0 |
| `feedback.shake.medium` | 0.08 |
| `feedback.shake.heavy` | 0.18 |
| `feedback.shake.launch` | 0.08 |
| `feedback.shake.ultimate` | 0.4 |
| `feedback.shakeDecaySec` | 0.25 |
| `feedback.damageNumbers` | true |
| `feedback.damageNumberRiseM` | 0.8 |
| `feedback.damageNumberSec` | 0.7 |
| `resources.notes` | combat.md §6: SP/MP regeneration per second, Awakening from Style points and HP lost, skill slots. |
| `resources.spRegenPerSec` | 8 |
| `resources.mpRegenPerSec` | 4 |
| `resources.awakeningMax` | 100 |
| `resources.awakeningPerStylePoint` | 0.12 |
| `resources.awakeningPerHpPercentLost` | 0.5 |
| `resources.skillSlots` | 4 |
| `firestorm.notes` | Fire + Wind reaction (combat.md §7): burst on the triggering hit, then a burning zone that damages every tick. |
| `firestorm.burstMult` | 1.5 |
| `firestorm.radiusM` | 4 |
| `firestorm.durationSec` | 4 |
| `firestorm.tickSec` | 0.5 |
| `firestorm.tickPower` | 0.35 |

Edit the source JSON, validate it, and rerun the relevant review before treating a tuned value as approved. This vault note is generated and will be overwritten on rebuild.
