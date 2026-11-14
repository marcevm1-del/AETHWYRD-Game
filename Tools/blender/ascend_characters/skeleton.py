"""
The rig contract of every Ascend human: Unity HumanBodyBones names, one hierarchy, one set of extra (non-humanoid)
chains for hair and cloak. Positions come from layout.py; this file only knows names and parents, so the validator
and the Node-side data check can compare against the same list.

Unity maps these names automatically (Hips, Spine, Chest, UpperChest, Neck, Head, LeftShoulder ... LeftToes and the
fifteen finger bones per hand). The extras are plain transforms under Head / UpperChest that Unity's Humanoid avatar
ignores; the game can drive them as spring bones. They are always present, weighted or not, so that every variant
shares one skeleton.
"""

FINGERS = ("Thumb", "Index", "Middle", "Ring", "Little")
SEGMENTS = ("Proximal", "Intermediate", "Distal")

# (name, parent) in creation order: parents always come before their children
HUMANOID = [("Hips", None), ("Spine", "Hips"), ("Chest", "Spine"), ("UpperChest", "Chest"), ("Neck", "UpperChest"),
            ("Head", "Neck")]
for _s in ("Left", "Right"):
    HUMANOID += [(_s + "Shoulder", "UpperChest"), (_s + "UpperArm", _s + "Shoulder"), (_s + "LowerArm", _s + "UpperArm"),
                 (_s + "Hand", _s + "LowerArm")]
    for _f in FINGERS:
        _p = _s + "Hand"
        for _seg in SEGMENTS:
            HUMANOID.append((_s + _f + _seg, _p))
            _p = _s + _f + _seg
    HUMANOID += [(_s + "UpperLeg", "Hips"), (_s + "LowerLeg", _s + "UpperLeg"), (_s + "Foot", _s + "LowerLeg"),
                 (_s + "Toes", _s + "Foot")]

EXTRAS = [("HairBack_1", "Head"), ("HairBack_2", "HairBack_1"), ("HairBack_3", "HairBack_2"),
          ("HairSideL_1", "Head"), ("HairSideL_2", "HairSideL_1"), ("HairSideR_1", "Head"), ("HairSideR_2", "HairSideR_1"),
          ("CloakBack_1", "UpperChest"), ("CloakBack_2", "CloakBack_1"), ("CloakBack_3", "CloakBack_2")]

ALL = HUMANOID + EXTRAS
PARENT = dict(ALL)
NAMES = [n for n, _ in ALL]
HUMANOID_NAMES = [n for n, _ in HUMANOID]
EXTRA_NAMES = [n for n, _ in EXTRAS]
MAX_INFLUENCES = 4


def mirror(name):
    """LeftHand <-> RightHand, HairSideL_1 <-> HairSideR_1; names without a side return themselves."""
    if name.startswith("Left"):
        return "Right" + name[4:]
    if name.startswith("Right"):
        return "Left" + name[5:]
    if "SideL" in name:
        return name.replace("SideL", "SideR")
    if "SideR" in name:
        return name.replace("SideR", "SideL")
    return name


def check_names(names):
    """Problems (list of strings) between a set of bone names and the contract; empty when it matches."""
    have, want = set(names), set(NAMES)
    out = ["missing bone " + n for n in sorted(want - have)]
    out += ["unexpected bone " + n for n in sorted(have - want)]
    return out
