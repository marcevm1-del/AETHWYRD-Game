"""
The expression set: weights (0..1) over the atomic shape keys of face_rig.py. No visemes and no lip-sync: nothing here is tied to speech;
`mouth_open_*` appear only as part of emotions (a laugh, a gasp). Left/right keys come in pairs; an expression lists a pair as `_LR` and
the builder expands it, so an asymmetrical expression (smug, wink, thinking) has to say so explicitly.
"""


def both(prefix, w):
    return {prefix + "_L": w, prefix + "_R": w}


def merge(*ds):
    out = {}
    for d in ds:
        out.update(d)
    return out


EXPRESSIONS = {
    "neutral": {},
    "happy": merge({"mouth_smile_wide": 0.6}, both("brow_up", 0.15)),
    "joy": merge({"mouth_smile_wide": 1.0, "mouth_open_small": 0.5}, both("eyes_happy", 1.0), both("brow_up", 0.3)),
    "laugh": merge({"mouth_smile_wide": 1.0, "mouth_open_wide": 0.8}, both("eyes_happy", 1.0), both("brow_up", 0.4)),
    "sad": merge({"mouth_frown": 0.8, "eyes_look_down": 0.5}, both("brow_inner_up", 0.9), both("brow_outer_down", 0.5), both("eyes_narrow", 0.25)),
    "worried": merge({"mouth_frown": 0.4, "mouth_pressed": 0.3}, both("brow_inner_up", 1.0), both("eyes_wide", 0.15)),
    "angry": merge({"mouth_frown": 0.7, "mouth_pressed": 0.6}, both("brow_inner_down", 1.0), both("brow_outer_up", 0.3), both("eyes_narrow", 0.35)),
    "surprised": merge({"mouth_o": 0.9}, both("brow_up", 1.0), both("eyes_wide", 1.0)),
    "shy": merge({"mouth_smile_wide": 0.3, "eyes_look_down": 0.7, "eyes_look_right": 0.3}, both("brow_inner_up", 0.4)),
    "smug": {"mouth_smirk_L": 1.0, "brow_up_R": 0.6, "brow_down_L": 0.3, "eyes_narrow_L": 0.4, "eyes_narrow_R": 0.4},
    "determined": merge({"mouth_pressed": 0.8}, both("brow_inner_down", 0.6), both("eyes_narrow", 0.15)),
    "tired": merge({"mouth_frown": 0.25, "eyes_look_down": 0.3}, both("eyes_narrow", 0.8), both("brow_inner_up", 0.3)),
    "pain": merge({"mouth_frown": 0.6, "mouth_pressed": 0.5}, both("eyes_close", 1.0), both("brow_inner_up", 1.0)),
    "embarrassed": merge({"mouth_o": 0.3, "mouth_smile_wide": 0.2, "eyes_look_down": 0.5}, both("brow_inner_up", 0.8)),
    "thinking": {"eyes_look_up": 0.8, "eyes_look_left": 0.4, "brow_up_R": 0.5, "mouth_smirk_R": 0.3, "mouth_pressed": 0.3},
    "sleepy": merge({"mouth_open_small": 0.3}, both("eyes_close", 0.9), both("brow_down", 0.3)),
    "sulking": merge({"mouth_pout": 1.0, "eyes_look_left": 0.4}, both("brow_inner_down", 0.4), both("eyes_narrow", 0.3)),
    "wink": {"eyes_close_L": 1.0, "mouth_smile_wide": 0.6, "brow_up_R": 0.2},
    "blink": merge({}, both("eyes_close", 1.0)),
}

# Blink behaviour for the game's face driver (data, not an animation system): a blink closes in `closeSec`, holds, opens in `openSec`; the
# next one comes after a random interval; a double blink now and then.
BLINK = dict(intervalSec=[2.0, 5.5], closeSec=0.06, holdSec=0.03, openSec=0.09, doubleBlinkChance=0.12, keys=["eyes_close_L", "eyes_close_R"])
TRANSITION = dict(defaultBlendSec=0.18, notes="blend weights linearly, ease-out; a transition to or from `blink` or `sleepy` is 0.08 s")
FORBIDDEN_NAME_PARTS = ("viseme", "phoneme", "lipsync", "lip_sync")
