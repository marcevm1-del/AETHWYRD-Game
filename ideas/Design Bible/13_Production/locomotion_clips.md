# Humanoid locomotion clips (animator-rigger, job 1)

The base-layer clip set for the two human bases: **Idle, Walk, Run, Sprint, JumpStart, Fall, Land, LandHard (optional), Dodge**. Names, loop flags, lengths and speeds follow `animation_clips_required.md` and the states in `Player.controller`. All clips are original and procedural (no Mixamo, no third-party data), so `third_party_assets.md` needs no entry.

## Build and check
```
set ASCEND_CHARACTERS_DIR=<folder that contains ascend_characters>     (only until branch claude/humans-base is merged)
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_locomotion_clips.py [-- --clips Walk,Dodge --previews <dir> --no-export]
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_locomotion.py [-- --self-test]
```
Output: one FBX per clip under `Art/Blender/AnimationLibrary/HumanLocomotion/` (gitignored: armature only, Humanoid bone names, same axis fix as the character FBX), and the committed manifest `Data/Characters/locomotion_clips.json` (frames, fps, loop, design speed, stride, measured metrics, pose hash). `npm run build` validates the manifest (`Tools/validate/animation_checks.js`); it cannot see the FBX files.

## How the clips are made
`Tools/blender/ascend_animation/`:
- `posing.py`: a pose is a delta per bone relative to its parent, written in the rig's rest axes (T-pose, facing -Y, left = +X), converted to Blender's local rotations. Quaternion signs are kept continuous.
- `pose_params.py`: one flat parameter dict describes a whole body (pelvis, spine, head, arms, fingers, legs by two-bone IK with explicit ankle targets, or by FK for the roll). `build_pose` is the only code that knows the skeleton.
- `gait.py`: cyclic gaits. The stance foot moves backward under the pelvis at exactly the design speed (heel strike pivots about the heel, toe-off about the ball), so feet do not slide at that speed. The pelvis height is derived from leg reach, so the bob follows the stride. Arms swing against the legs; shoulders counter-rotate the pelvis.
- `clips.py`: the clips. Key-posed clips use a monotone cubic (no overshoot).
- `analysis.py`: loop closure, ground contact and foot slide, lowest bone, reach clamping, bake round-trip, pose hash. `preview.py`: side-view contact sheets.

Authored on `human_male_base`; checked on `human_female_base` too (both share the hip height and bone names, and Humanoid retargeting carries the clips to every variant).

## The clips
| Clip | Controller state | Loop | Length | Notes |
|---|---|---|---|---|
| Idle | Locomotion tree @ 0 | yes | 3.0 s (90 f) | breathing, one slow weight shift, a glance |
| Walk | tree @ 2.2 | yes | 0.9 s (27 f) | stride 1.98 m per cycle at 2.2 m/s, stance 60 % |
| Run | tree @ 6.5 | yes | 0.6 s (18 f) | stride 3.9 m, stance 30 % (a flight phase), 9 deg lean |
| Sprint | tree @ 9.5 | yes | 0.5 s (15 f) | stride 4.75 m, stance 25 %, 19 deg lean |
| JumpStart | JumpStart | no | 14 f (0.467 s) | crouch, drive up on the toes, leaves the ground; hands over to Fall |
| Fall | Fall | yes | 0.8 s (24 f) | arms out, legs trailing, a small flutter |
| Land | Land | no | 11 f (0.367 s) | soft: absorb with knees and hips, spring back to the Idle stance |
| LandHard | (optional, not wired) | no | 21 f (0.7 s) | deep crouch, one arm reaching, slow rise |
| Dodge | Dodge | no | **0.42 s = 21 f at 50 fps** | forward roll in place, a 360 degree pelvis pitch, curled up, out into a run stance |

30 fps except Dodge: 0.42 s is 12.6 frames at 30 fps, but exactly 21 frames at 50 fps, so the clip length equals `combat_tuning.json` `dodge.durationSec` with no rounding. Unity resamples per clip; import it as its own FBX. All clips are in place with no root motion; the Dodge pelvis is lifted automatically wherever any bone would go under the floor.

## Measured (both bodies; see the manifest)
Foot slide at the design speed in the stance phase is under 1 % for Walk, Run and Sprint. Loops close to 0.0 mm; the baked action reproduces the authored pose to 0.0 mm; the lowest bone never goes below the floor. Hip height range: Walk 0.70-0.90 m, Run 0.68-0.88, Sprint 0.66-0.88 (rest hip height 0.92).

## Decisions (overrule freely)
1. **Stride follows the controller's speeds, not a natural walk.** The doc asks for Walk 2.2 m/s with a 0.9-1.1 s cycle, which is a 2 m stride on 0.88 m legs. The pelvis therefore bobs about 20 cm and the walk reads as a purposeful power walk. A natural walk would be about 1.6 m/s; if the Walk blend-tree threshold dropped to 1.6, the clip could be re-authored with a calmer stride (`GAITS["walk"]` in `gait.py`: `v`, `s`). The shortest cycle in each allowed range was used, because a longer cycle only lengthens the stride.
2. **No Mixamo.** Hand-authored procedural clips keep the repo free of third-party motion and need no Adobe account.
3. **Dodge at 50 fps** (above).
4. Facial shape keys, finger articulation beyond a relaxed curl, and cloth/hair motion are not part of this job (the extra hair and cloak bones stay at rest; the game drives them as spring bones).

## Not verified here
Unity import (Humanoid avatar mapping, clip loop flags, animator wiring, `SpeedMult` against the design speeds) was not run: another session owns Unity. When it is: import the FBXs with Animation Type Humanoid and "Copy From Other Avatar" (the character FBX), tick Loop Time on the loop clips, and replace the `PlayerAnimationAssets.cs` placeholders.

## Known gaps
Turn clips, back/side dodge rolls, Hurt/Death/Rest/Interact/Get-up are in `animation_clips_required.md` as later work and are not made. Walk uses the same stride for the whole speed range; at low stick input the controller should blend to Idle through `SpeedMult`.
