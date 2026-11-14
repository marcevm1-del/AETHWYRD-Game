# Combat clip sets per weapon family (animator-rigger, job 2)

Ten weapon families, each with a Ready stance, the chain hits, a heavy Charge loop and the special attacks, authored on the human rig (`human_v1`) and driven by the attack-chain windows in `Data/Combat/combat_tuning.json` (`attackTiming`). All motion is original and procedural; nothing third-party.

## Build and check
```
set ASCEND_CHARACTERS_DIR=<folder holding ascend_characters>        (only until branch claude/humans-base is merged)
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_combat_clips.py [-- --families blade_1h,bow --previews <dir> --no-export]
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_combat.py [-- --self-test]
```
Output: `Art/Blender/AnimationLibrary/Combat/<family>.fbx` (gitignored; armature only, one take per clip named `Cmb_<family>_<Clip>`) and the committed manifest `Data/Characters/combat_clips.json`. `npm run build` validates the manifest (`Tools/validate/animation_checks.js`).

## How the windows drive the clips
Each attack clip is exactly `startup + active + recovery` of its hit weight, with these animation events on exact frames (they go to `CombatAnimationBridge.OnAnimEvent`; they are recorded, never used for rules):

| Event | Frame |
|---|---|
| `StartupEnd` and `ActiveBegin` | `startupSec * fps` (the contact pose: the hit lands on the first active frame) |
| `ActiveEnd` | `(startup + active) * fps` |
| `RecoveryEnd` | the last frame |

Poses: ready, then the wind-up (the telegraph, reached at 62 % of the startup), the contact pose on `ActiveBegin`, the follow-through at `ActiveEnd`, then back to ready. Heavy motions use larger amplitudes (scale 0.85 light, 1.0 medium, 1.2 heavy, 1.05 launch).

**fps is derived**: the smallest of 30, 50, 60, 100, 120, 200, 240 at which every window is a whole number of frames. For the current tuning that is **50 fps** (light 21 f, medium 31 f, heavy 42 f, launch 28 f). If a later tuning change fits none of them the build stops instead of rounding. The manifest stores a hash of the `attackTiming` block and the windows; `npm run build` fails when the tuning changed and the clips were not rebuilt.

Weights: chain hits are light, light, ..., medium (the Swordsman Slash Chain pattern; `AttackChain` takes the weight from each hit). Special clips: HeavyRelease, Riposte and Slam use heavy, Launcher uses launch, SkillCast uses medium, which matches the `Special` states in `animation_clips_required.md`.

## Families
`weaponToFamily` in the manifest maps every weapon name to a family. The check derives the required set from `Data/Items/items.json` `weaponType` plus every class weapon list in `Data/Classes/classes.json`, so a weapon cannot ship without a family.

| Family | Weapons | Hits | Grip |
|---|---|---|---|
| blade_1h | sword, 1h_sword, short_sword, katana, shield, tower_shield | 4 | one hand |
| blade_2h | greatsword | 4 | two hands |
| dual_blades | daggers, dual_swords, ritual_dagger | 4 | two weapons |
| blunt_1h | mace, hammer, wrench, censer | 3 | one hand |
| polearm | spear, lance, halberd, glaive, naginata, trident, bo_staff | 4 | two hands |
| staff_caster | staff, wand, grimoire, orb, holy_tome, bone_staff, tool_staff, tome | 3 | cast gestures |
| bow | shortbow, longbow, crossbow, throwing_knives, throwables | 3 | draw and release |
| unarmed | fists, knuckles, gauntlets, greaves | 5 (four jabs alternating hands, then a kick) | hands |
| whip | whip, rod, bell, flute_tamer | 3 | whip flicks |
| instrument | lute, flute, harp, war_drum, violin_blade, violin | 3 | strikes with the instrument |

Clips per family: `Ready` (loop, 2 s), `Hit1..HitN`, `Charge` (loop, 1 s), `HeavyRelease`, `Riposte`, `Launcher`, `Slam`, `SkillCast`.

**Hit rule** (also in the manifest): a chain's hit `i` (0-based) plays `<family>_Hit<i+1>`; when a chain is longer than the family's hit count the extra hits repeat from Hit2 (`Hit(2 + (i-1) % (hitCount-1))`), so the 17-hit Hundred Fists flurry loops its middle hits.

## What is measured (both bodies, every clip)
Length and events against the tuning read from `combat_tuning.json`, a readable telegraph (the weapon hand travels at least 0.20 m from the wind-up to the contact pose; measured minimum 0.24 m), forward reach at contact (at least 0.30 m), nothing under the floor, loops close (Ready, Charge), the baked action reproduces the pose, and the same hash on a second build. `check_combat.py --self-test` breaks a window length, a wind-up and a foot height on purpose and fails unless each is caught (all three were caught). The first run of the checks found real problems that were then fixed: the bow draw and release were the same pose (no telegraph), and the launcher's tiptoe finish put a toe under the floor on two families.

## Decisions (overrule freely)
1. **The weapon hand is the right hand**; the game parents the weapon to `RightHand` (both hands for two-handed families; the off hand follows the weapon hand at a hand-width offset). The unarmed jabs alternate hands (Hit2 and Hit4 mirrored).
2. **50 fps**, not 30 (above): exact frames beat the 30 fps convention here, and Unity resamples per clip.
3. **Feet stay planted through a hit** (a staggered stance with small shifts); the lunge is the motor's (`lungeM`), as `animation_clips_required.md` says. Only the kick, slam and launcher move the feet or lift the heels.
4. **Families are shared where the motion is shared**: a halberd and a trident play the polearm set; the bard's instruments play one strike set. Weapon-specific refinements are per-family edits in `ascend_animation/combat.py`.

## Not done / not verified
- Unity: nothing was imported or run (another session owns Unity). Needed there: import each family FBX as Humanoid with "Copy From Other Avatar"; set Loop Time on `Ready` and `Charge`; add the four events per attack clip from the manifest (`events`, in frames at the clip's fps; FBX files from Blender do not carry them); point the Combat layer states at the clips by `weaponToFamily` and the hit rule.
- The previews are side views, where torso twist does not show. A front or top view of the slashes has not been reviewed by eye, only measured.
- Air chain (L L L H) hits, the guard/block pose, hurt reactions and the Slam's airborne approach are not separate clips; Slam is a ground slam.
