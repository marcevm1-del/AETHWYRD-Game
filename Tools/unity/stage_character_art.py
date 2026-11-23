#!/usr/bin/env python3
"""Stages generated character and locomotion FBX into the Unity project.

The Blender pipeline writes into Art/Blender/{CharacterLibrary,AnimationLibrary}, which are gitignored:
they are source libraries, re-buildable from the generators. Unity cannot read a gitignored folder on a
fresh checkout, and that has already cost us three PlayMode failures once (monster art missing in a
worktree on 2026-11-21, which looked like a code fault for twenty minutes). So the files Unity needs are
copied under Game/Assets and committed; *.fbx goes through git-lfs (.gitattributes).

    python Tools/unity/stage_character_art.py [--ids human_male_base ...] [--check]

--check copies nothing and exits non-zero if anything staged is missing or stale, which is what a gate
wants. Without it, files are copied and the report says what changed.

Build the sources first:
    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_character_library.py -- --ids <id>
    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_locomotion_clips.py -- --body <id>
"""
from __future__ import annotations

import argparse
import hashlib
import json
import shutil
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]

CHAR_SRC = ROOT / "Art" / "Blender" / "CharacterLibrary"
CLIP_SRC = ROOT / "Art" / "Blender" / "AnimationLibrary" / "HumanLocomotion"
MANIFEST = ROOT / "Data" / "Characters" / "locomotion_clips.json"

CHAR_DST = ROOT / "Game" / "Assets" / "_Game" / "Art" / "Models" / "Characters"
CLIP_DST = ROOT / "Game" / "Assets" / "_Game" / "Art" / "Animation" / "Humanoid"

DEFAULT_IDS = ["human_male_base"]


def digest(path: Path) -> str:
    h = hashlib.sha1()
    with path.open("rb") as fh:
        for chunk in iter(lambda: fh.read(1 << 20), b""):
            h.update(chunk)
    return h.hexdigest()


def same(src: Path, dst: Path) -> bool:
    if not dst.exists():
        return False
    if src.stat().st_size != dst.stat().st_size:
        return False
    return digest(src) == digest(dst)


def plan_one(src: Path, dst: Path, problems: list[str], label: str) -> tuple[Path, Path] | None:
    """Returns the copy to make, or None when nothing needs doing. Records a problem if the source is absent."""
    if not src.exists():
        problems.append(f"{label}: source missing, {src.relative_to(ROOT)} - run its generator first")
        return None
    if same(src, dst):
        return None
    return (src, dst)


def main(argv: list[str]) -> int:
    ap = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    ap.add_argument("--ids", nargs="*", default=DEFAULT_IDS, help="character ids to stage")
    ap.add_argument("--check", action="store_true", help="report only; non-zero if anything is missing or stale")
    args = ap.parse_args(argv)

    problems: list[str] = []
    copies: list[tuple[Path, Path]] = []

    # --- the clip set comes from the manifest, never from a hardcoded list, so a clip added to the
    # generator cannot quietly ship unstaged.
    if not MANIFEST.exists():
        print(f"FAIL {MANIFEST.relative_to(ROOT)} is missing; nothing defines which clips exist", file=sys.stderr)
        return 1
    manifest = json.loads(MANIFEST.read_text(encoding="utf-8"))
    clip_names = [c["name"] for c in manifest["clips"]]
    if not clip_names:
        print("FAIL the manifest lists no clips", file=sys.stderr)
        return 1

    for name in clip_names:
        got = plan_one(CLIP_SRC / f"{name}.fbx", CLIP_DST / f"{name}.fbx", problems, f"clip {name}")
        if got:
            copies.append(got)

    for cid in args.ids:
        d = CHAR_SRC / cid
        for ext in ("fbx", "json"):
            got = plan_one(d / f"{cid}.{ext}", CHAR_DST / f"{cid}.{ext}", problems, f"character {cid}.{ext}")
            if got:
                copies.append(got)

    # The manifest itself is read by the PlayMode test, which cannot reach Data/ from a built player.
    got = plan_one(MANIFEST, CLIP_DST / "locomotion_clips.json", problems, "manifest")
    if got:
        copies.append(got)

    if args.check:
        for src, dst in copies:
            print(f"STALE {dst.relative_to(ROOT)}")
        for p in problems:
            print(f"MISSING {p}")
        if copies or problems:
            print(f"\nFAIL {len(copies)} stale, {len(problems)} missing")
            return 1
        print(f"PASS {len(clip_names)} clips and {len(args.ids)} character(s) staged and current")
        return 0

    if problems:
        for p in problems:
            print(f"FAIL {p}", file=sys.stderr)
        return 1

    CHAR_DST.mkdir(parents=True, exist_ok=True)
    CLIP_DST.mkdir(parents=True, exist_ok=True)
    for src, dst in copies:
        shutil.copy2(src, dst)
        print(f"staged {dst.relative_to(ROOT)}  ({dst.stat().st_size // 1024} KB)")

    print(f"\nOK {len(copies)} file(s) copied; {len(clip_names)} clips, {len(args.ids)} character(s) current")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv[1:]))
