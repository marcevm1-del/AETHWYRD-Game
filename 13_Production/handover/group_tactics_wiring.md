# Group tactics: Unity wiring brief (Wave A3, ai-engineer)

Core is done (Wave A2): `Code/Ascend.Core/GroupTactics.cs` plus optional hooks in `MonsterAi.cs`. Nothing in Unity passes the new fields yet, so in-game behaviour is unchanged. Rules (Canon §4d): peers are symmetric, no captain/commander/rank of any kind, nothing is remembered about the player, nothing survives the end of a fight, no randomness outside the brain's injected `IRandom`.

## What `MonsterController` must pass in `AiSense` (all optional, 0/false = old behaviour)
| Field | Fill with |
|---|---|
| `PlayerHpFraction` | player HP / max HP (0-1). Leave 0 to switch the HP-aware retreat tweaks off. |
| `AlliesNear` | living monsters of any species in the fight within about the alert radius (feeds `ThreatLevel` only). `PackmatesNear` stays as is. |
| `FlankSlot` | 1-based slot from `FlankSlots.Assign` (below); 0 for none. |
| `FlankSlotCount` | slot count in play this frame (usually `min(packSize, tuning.SlotCountClamped)`); 0 uses the tuning default. |
| `YieldToken` | `PeerCoordinator.ShouldYield(selfId, members, tuning)` this frame. |

## Each frame, from the live pack list
1. Build the list of live monsters currently engaged with the same target (the same list the aggro-token code already walks). Member id = a stable per-fight int (spawn index); it only has to be stable and unique during the fight.
2. `var slots = FlankSlots.Assign(ids, tuning)`; give each monster `slots[id]` and the slot count. Assignment is by sorted id, so it is deterministic and distinct for the first `FlankSlotCount` members (extras wrap).
3. Build `PackMember { Id, HpFraction, WantsToken }` for each (`WantsToken` = last `AiCommand.WantsToken`, or it holds the token). `ShouldYield` is the same function for everyone: among members that want a token, the healthier keeps it when it is at least `YieldHpGap` healthier (the real HP difference is compared, no buckets); a smaller difference counts as equal and falls to the lowest id. (Edge case: with three or more contenders whose HP differences straddle the gap the "beats" relation can be a cycle; everyone yields for that moment and the `YieldSec` hold ends it. Worth a look if it shows in play.) This is a contest rule, not a role.
4. When `ShouldYield` is true for a token holder the brain skips its windup, sets `ReleaseToken`, and keeps circling; the game returns the token to the pool as it does for any `ReleaseToken`. Hold the yield for `GroupTacticsTuning.YieldSec` before re-asking (a per-monster timer owned by the controller, cleared when the fight ends or the monster resets).

## Reading the output
- `AiCommand.FlankAngleDeg`: when `Move == Circle` and a slot was supplied, aim the circling target point at this angle (degrees) from the player-to-pack approach axis, at the usual circle radius. Otherwise 0 (circle as today).
- `AiCommand.ThreatLevel` (0-1): information only (animation barks, tuning telemetry); it does not change the brain's choices.

## Tuning
`combat_tuning.json` `groupTactics` is the single source of truth and is exposed as `Repo/Db.Tuning.GroupTactics`. On spawn assign `brain.Tactics = tuning.GroupTactics.ToTuning()` (build it once and share it; do not allocate per tick). The in-code `GroupTacticsTuning` defaults equal the JSON (a test pins that). `groupTactics.enabled = false` (mapped to `GroupTacticsTuning.Enabled`) makes the brain behave exactly as before tactics: player HP ignored, `YieldToken` ignored, no flank angle, `ThreatLevel` 0.

New keys under `retreat`, now data and mapped: `pressOnPlayerHp` (0.25), `pressOnRetreatScale` (0.5), `healthyPlayerHp` (0.75), `outnumberedRetreatBonus` (0.1). Reserved, read by nothing yet (do not wire expecting an effect): `flank.slotRadiusM`, `flank.reassignSec`, `retreat.packRetreatHpFraction`, `retreat.regroupHpFraction`, `retreat.regroupSec`, `threat.cautiousAbove`, `threat.boldBelow`, `yield.cooldownSec`.

`AiSense.PlayerHpFraction <= 0` keeps its "not supplied" meaning (the HP-aware retreat tweaks stay off), so the controller must send the real fraction, and a dead or zero-HP player reads as "not supplied" too. That is intentional for now.

Do not add state to the controller that outlives a fight. Do not add state to the controller that outlives a fight.

## Do not
Add a leader/rank field, remember anything about the player between fights, or pick slots with `UnityEngine.Random`. Use sorted ids.
