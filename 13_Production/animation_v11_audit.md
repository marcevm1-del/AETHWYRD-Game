# Animation v11 audit (Wave A1)

What existed before Wave A1, what A1 built, what is skipped. Placeholder = works in game with primitive-bone clips; replace with real humanoid clips (see `animation_clips_required.md`). Status below reflects the code as written; the new PlayMode tests have not been run yet (lead runs Unity).

Source spec: `upgrade v11` at the repo root (movement states, V = Vb x Mstate x Mterrain x Mcondition, animation-driven attack windows, foot IK). Wave A1 plan notes: side-session `a1_plan.md`.

## What existed (not duplicated)
| Existing | Where | A1 relation |
|---|---|---|
| Motion rules: walk, run, sprint, jump, dodge, coyote, jump buffer, variable jump, stamina | `Runtime/Player/PlayerMotor.cs`, numbers in `Data/Combat/combat_tuning.json` `movement` and `dodge` | Untouched. The animation layer only reads it. |
| Attack string, phases Startup/Active/Recovery, timings | `Code/Ascend.Core/AttackChain.cs`, `Runtime/Combat/PlayerCombat*.cs` | Untouched. The bridge polls `Chain.Phase`. No event added, no Core change. |
| Monster animation (25 shared rigs, MonsterMotion) | `Code/Unity/Runtime`, `MonsterAnimatorPlayModeTests` | Separate system, not reused or changed. Player has its own controller. |
| Player visual | Ring0SceneBuilder primitive `Body`/`Facing` | Kept; renderers are hidden when `Visual` exists (T2 scene edit). |

No second motor, no second combat state machine, no second tuning source: speeds for the blend tree come from `Data/Player/locomotion.json`, which mirrors combat_tuning (validator cross-checks within 0.01).

## Built in A1
| Requirement | Status | Evidence |
|---|---|---|
| Locomotion table (state x terrain x condition, slope, blend, damping) as data | done | `Data/Player/locomotion.json`, `Code/Ascend.Core/Locomotion.cs`, `Code/Ascend.Core.Tests/LocomotionTests.cs`, `Data/Schemas/locomotion.schema.json` |
| 1D blend tree Idle/Walk/Run/Sprint on Speed, thresholds 0 / 2.2 / 6.5 / 9.5 | done (placeholder clips) | `Editor/PlayerAnimationAssets.cs`; tests `Walk_`, `Run_`, `Sprint_...SelectThe...Clip`, `Idle_AtRest...` |
| Foot-slide control (`SpeedMult` 0.6..1.6) | done | `PlayerAnimationDriver.ComputeSpeedMult`; test `Run_SpeedMultStaysInsideTheFootSlideClamp` |
| Jump > JumpStart > Fall > Land > Locomotion | done (placeholder) | controller states; tests `Jump_GoesJumpStartThenFallThenLandThenLocomotion`, `Jump_FiresTheJumpTriggerOnceOnTakeoff` |
| Walk-off-ledge goes straight to Fall | done | tests `LedgeWalkOff_...` (2) |
| Grounded exit grace 0.08 s (no flicker on steps) | done | `PlayerAnimationDriver`; tests `GroundedParam_...` (2) |
| Dodge state with the dodge duration (0.42 s) | done (placeholder) | clip length read from combat_tuning; test `Dodge_EntersDodgeState...` |
| Combat layer driven by real chain phases; playback scaled to the live phase window | done (placeholder clips) | `CombatAnimationBridge`, controller layer 1; tests `Combat_...` (3) |
| Foot IK | decision below | `Runtime/Player/FootIK.cs`; tests `FootIkWeight_...` (3), `FootIk_On...` (2 UnityTests) |
| Driver tolerates bare players (no Animator, no combat) | done | `PlayerAnimationDriver` no-ops; existing PlayMode tests must stay green (lead to confirm count) |

## Foot IK decision
Animation Rigging is not installed and not allowed (no new packages). The placeholder rig is Generic (no Avatar), where `OnAnimatorIK` goals do not exist. So `FootIK` has two paths:
- Generic path (used now): `LateUpdate` raycasts, lowers `Hips` by the lowest foot delta and lifts each foot transform. Automated by the tests.
- Humanoid path: `OnAnimatorIK` with `SetIKPosition/Rotation`, active when `animator.isHuman`. Written, **not tested** until a humanoid import exists (needs the "IK Pass" box on a layer).
Off while dodging, airborne (0.08 s grace), above `blend.sprintEnter` (8 m/s); weight eases over 0.15 s.

## Skipped / deferred
Swim, climb, vault, glide, flying, mounts, facial animation, the Animation Studio editor window, turn-in-place, hurt/death/rest/interact states, special-move clips (heavy, riposte, launcher, slam, skill have only the shared Active pose; the Special int is passed for later), animation events from real clips (receiver exists, records only), humanoid foot-IK test, Animator-driven root motion (everything is in-place, motor stays authoritative).

## Awaiting the user
Proposed terrain and condition multipliers in `locomotion.json` (swamp 0.7, mountain 0.85, exhausted 0.75, attacking 0.6, charging 0.5, ...) are new tuning, not Canon, and do not change PlayerMotor yet (only animation thresholds). Whether PlayerMotor should adopt the table is a later decision.

## Open test risks (for the lead's first Unity run)
- Tests were written without running Unity. Exact transition timing (exit times, 0.03 s combat transitions) could make a state be skipped between frames; the tests record the next state during transitions to tolerate this.
- `FootIk_OnASideSlope...` depends on the 20 degree slope tilting the two feet by about 0.09 m and on `FootProbe` running after FootIK in LateUpdate.


## Review follow-ups (code-reviewer, not yet done)
- Driver ticks in `LateUpdate`, so parameters reach the Animator one frame late (invisible at 60 fps).
- `SpeedMult` is 1 between walk and sprint speed; per-bracket foot-slide control is a later tuning pass.
- `AttachPlayerVisual` rebuilds `Player.controller` on every scene build (GUID kept, YAML diff each time).
- Chained dodge may start up to 0.1 s late (Dodge to Locomotion has no interruption source).
- FootIK ground mask is `~0`: other characters count as ground; restrict to terrain/static layers.
- `blend.walkEnter/runEnter/idleMaxSpeed/hysteresis` are validated but unused at runtime; only `sprintEnter` is read (FootIK).