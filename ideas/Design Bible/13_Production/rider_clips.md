# Rider poses for the ground mounts (animator-rigger, job 3)

Rider clips for the five ground-mount families of `Data/Companions/mounts.json` (horse, wolf, bear, desert beast, large ground monster), authored on the human rig (`human_v1`). They animate the **rider only**; the mount's own body motion (its 25-rig procedural gait) carries the rider rigidly, and the clips add what a rider does on top: the pelvis absorbing the stride, the torso leaning into the speed, hands on the reins or harness, a short sitting swing, getting on and off, and being thrown. Original and procedural, nothing third-party. Mount rules (no flying, aquatic or celestial mounts; mounted combat limits) are unchanged and not touched here.

## Build and check
```
set ASCEND_CHARACTERS_DIR=<folder holding ascend_characters>       (only until branch claude/humans-base is merged)
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_rider_clips.py [-- --families horse,bear --previews <dir> --no-export]
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_riders.py [-- --self-test]
```
Output: `Art/Blender/AnimationLibrary/Riders/<family>.fbx` (gitignored; armature only, one take per clip, `Rid_<family>_<Clip>`), and the committed manifest `Data/Characters/rider_clips.json`. `npm run build` validates it (`Tools/validate/animation_checks.js`).

## Clips per family (11)
| Clip | Loop | Length | Notes |
|---|---|---|---|
| Idle | yes | 2.4 s | breathing, a glance, hands resting on the reins or harness |
| Walk, Trot, Gallop | yes | 1.1 s, 0.7 s, 0.5 s (one mount gait cycle) | drive the clip's normalised time from the mount's gait phase; the pelvis bobs and pitches, the torso leans in (more at Gallop), the body sways in the saddle |
| Hit1, Hit2, Hit3, Skill | no | the light, light, medium and medium windows of `combat_tuning.json` (21, 21, 31, 31 frames at 50 fps) | the combat motions' upper body only, at 0.7 amplitude, legs on the mount; exactly `mountedCombat.maxChainHits` (3) chain hits; events as in `combat_clips.md` |
| MountUp | no | 0.9 s | from standing beside the mount on its left: boot into the stirrup, pull up, swing the right leg over, settle; ends exactly on the Idle pose |
| Dismount | no | 0.8 s | starts on the Idle pose, swings the leg back over, slides down, lands standing on the left |
| Stagger | no | 0.8 s | the stagger-dismount rule: a jolt, an arc over the left side, ends curled on the ground (a Get-up clip is still to do) |

Families differ in how the rider sits (thigh spread, thigh and knee flexion, lean) and holds on (reins, wolf ruff, bear shoulder hump, one-hand saddle horn on desert beasts, harness handles on the large monster), and in how hard the mount rocks the rider (bob, pitch, lean and sway amplitudes per gait).

## Placement (what the Unity side has to do)
The manifest's `placement` text and `anchors` say it: place the rider armature so its **Hips** bone sits on the saddle anchor (a bone of the mount rig plus an offset), then the clip moves the Hips by (`hx`, `hz`) metres from that seat. Anchors, derived per rig used by the mount species (`rig_quad_large`: `spine_02`, `rig_hexapod`: `thorax`; offsets in the mount rig's normalised units, to be multiplied by the mount's size): `RIGS_ANCHOR` in `Tools/blender/ascend_animation/rider.py`. The ground clips start or end with the hips at standing hip height minus the family's `seatHeightM`.

## What is measured (both bodies, every clip)
Straddling (knees at least 0.30 m apart in every seated clip; measured minimum 0.48 m), pelvis travel while seated at most 8 cm, loops close, every seated clip starts and ends within 12 cm of the seated Idle pose, attacks start and end on it, MountUp ends on it and Dismount/Stagger begin on it (within 3 cm), the ground ends stand at the family's standing height, attack windows and events equal `combat_tuning.json` (read by the check, not by the clip code), the baked action reproduces the pose, and a second build gives the same hashes. `check_riders.py --self-test` closes the thighs, lifts the MountUp end pose and lengthens an attack window, and fails unless each is caught (all three were). The validator also fails when a mount family has no rider clips, when a mount species uses a rig without a saddle anchor, and when `attackTiming` or `maxChainHits` changed after the build.

## Decisions (overrule freely)
1. **Seat heights and anchor offsets are placeholders** (`seatHeightPlaceholder: true`): horse 1.30 m, wolf 0.95, bear 1.35, desert beast 1.10, large ground monster 1.90 m. There are no mount models in the repo, only the rigs, so the saddle height of a species cannot be measured; the art session should calibrate them on the models. The ground clips are the only ones that depend on them.
2. **Left-side mounting only**, as most games do; a right-side variant would be a mirror of the same keys.
3. **Rider legs are FK astride** (thigh spread about the vertical axis, knee and ankle flexion); the feet have no stirrup contact to solve because there are no stirrups in the data yet.
4. **No weapon-switch or bow-aiming clips**: mounted combat is limited to light chain hits and small skills by `mountedCombat` (no big, aerial or channelled skills). A mounted bow draw could reuse the bow family's `Hit` upper body.

## Not done / not verified
- Unity: nothing imported or run (another session owns it). Needed there: place the rider on the saddle anchor of each mount, import the FBXs as Humanoid with "Copy From Other Avatar", set Loop Time on Idle/Walk/Trot/Gallop, add the attack events from the manifest, drive the gait clips by the mount's phase.
- How the pose fits an actual mount body (knee clearance against the flanks, hand positions against a real withers/ruff) could not be checked without mount models; only the rider's own geometry is measured.
- No Get-up, no mount rear-up/brace reactions, no steering-lean clips (the pelvis roll in the gait clips is a fixed sway, not driven by turning).
