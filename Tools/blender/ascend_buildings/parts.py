"""
Shared detail parts, instanced many times per building: roof tiles, shingles, slates, thatch bundles, barrel tiles,
leaves, wall stones, bricks, planks, logs, grass tufts and flowers.

A part key is "<shape>|<material key>", for example "tile_flat|roof_a" or "stone_b|stone~2". Every part is slightly
irregular (a seeded jitter per shape), so repeated parts read as hand-made rather than stamped.

Part frames:
- Roof covers: width along X (centred), length up the slope along +Y from y = 0, thickness up +Z from z = 0.
- Wall pieces (stones, bricks, planks, logs): length along X (centred), front face on y = 0 with depth going +Y (into
  the wall), height up +Z from z = 0.
"""
import math
import random

import numpy as np

from .geo import Geo, rounded_box, trs


def _jitter(v, amount, seed, keep_bottom=False):
    rng = np.random.default_rng(seed)
    j = rng.uniform(-amount, amount, v.shape)
    if keep_bottom:
        j[:, 2] = np.where(v[:, 2] < v[:, 2].min() + 1e-4, 0, j[:, 2])
    return v + j


def _rb(size, r, seg, offset, jitter=0.0, seed=0, taper=0.0):
    """A rounded box moved by offset, with optional vertex jitter and a top taper (narrower at +Z)."""
    v, f = rounded_box(size, r, seg)
    if taper:
        t = (v[:, 2] - v[:, 2].min()) / max(1e-6, np.ptp(v[:, 2]))
        v[:, 0] *= 1 - taper * t
    if jitter:
        v = _jitter(v, jitter, seed)
    return v + np.asarray(offset), f


def _arc_tile(radius, length, thick, convex, segs=8):
    """A half-pipe tile along +Y: concave (a pan, open upward) or convex (a cap, open downward), resting on z = 0."""
    a0 = 0.0 if convex else math.pi
    angs = [a0 + math.pi * k / segs for k in range(segs + 1)]
    verts = []
    for y in (0.0, length):
        for rr in (radius, radius - thick):
            for a in angs:
                verts.append((rr * math.cos(a), y, rr * math.sin(a)))
    n = segs + 1
    o0, i0, o1, i1 = 0, n, 2 * n, 3 * n
    faces = []
    for k in range(segs):
        faces.append((o0 + k, o1 + k, o1 + k + 1, o0 + k + 1))      # outer shell, facing away from the axis
        faces.append((i0 + k, i0 + k + 1, i1 + k + 1, i1 + k))      # inner shell, facing the axis
        faces.append((o0 + k, o0 + k + 1, i0 + k + 1, i0 + k))      # end at y = 0
        faces.append((o1 + k, i1 + k, i1 + k + 1, o1 + k + 1))      # end at y = length
    faces.append((o0, i0, i1, o1))
    faces.append((o0 + segs, o1 + segs, i1 + segs, i0 + segs))
    v = np.array(verts)
    v[:, 2] -= v[:, 2].min()
    return v, faces


def build(key):
    """Returns the Geo of the part named by key."""
    shape, mat = key.split("|", 1)
    g = Geo()
    seed = sum(ord(c) * (i + 1) for i, c in enumerate(shape))
    rng = random.Random(seed)

    # ---- roof covers --------------------------------------------------------------------------------------------
    if shape.startswith("tile_flat"):
        v, f = _rb((0.30, 0.40, 0.035), 0.013, 1, (0, 0.20, 0.0175), 0.004, seed)
        g.add(v, f, mat)
    elif shape.startswith("shingle"):
        w = {"shingle_a": 0.17, "shingle_b": 0.23, "shingle_c": 0.29}.get(shape, 0.23)
        v, f = _rb((w, 0.44, 0.045), 0.012, 1, (0, 0.22, 0.0225), 0.006, seed)
        v[:, 2] *= np.clip(1.25 - v[:, 1] / 0.44 * 0.5, 0.75, 1.25)  # thicker at the butt end
        g.add(v, f, mat)
    elif shape.startswith("slate"):
        w = {"slate_a": 0.26, "slate_b": 0.32}.get(shape, 0.3)
        v, f = _rb((w, 0.46, 0.028), 0.006, 1, (0, 0.23, 0.014), 0.008, seed)
        g.add(v, f, mat)
    elif shape.startswith("thatch"):
        v, f = _rb((0.62, 0.95, 0.16), 0.075, 2, (0, 0.475, 0.08), 0.02, seed)
        g.add(v, f, mat)
        for k in range(3):  # straw tufts poking out of the bundle's lower edge
            x = (k - 1) * 0.18 + rng.uniform(-0.04, 0.04)
            v2, f2 = _rb((0.14, 0.18, 0.06), 0.028, 1, (x, 0.03, 0.05), 0.012, seed + k)
            g.add(v2, f2, mat)
    elif shape == "barrel_pan":
        v, f = _arc_tile(0.13, 0.42, 0.025, False, 8)
        g.add(v, f, mat)
    elif shape == "barrel_cap":
        v, f = _arc_tile(0.085, 0.42, 0.022, True, 8)
        g.add(v, f, mat)
    elif shape == "barrel_end":
        g.cylinder(0.095, 0.05, mat, trs((0, 0, 0.0), (90, 0, 0)), segs=12, bevel=0.012)
    elif shape.startswith("leaf"):
        sq = {"leaf_a": (0.34, 0.6), "leaf_b": (0.28, 0.5)}.get(shape, (0.3, 0.55))
        g.sphere(0.5, mat, trs((0, sq[1] / 2, 0.03), (0, 0, 0), (sq[0], sq[1], 0.07)), segs=10, rings=6)
        g.box((0.025, sq[1] * 0.9, 0.02), mat, None, (0, sq[1] / 2, 0.06))  # the midrib
    elif shape == "plank_roof":
        v, f = _rb((0.24, 1.0, 0.05), 0.014, 1, (0, 0.5, 0.025), 0.006, seed)
        g.add(v, f, mat)
    elif shape == "seam":
        v, f = _rb((0.05, 1.0, 0.05), 0.02, 2, (0, 0.5, 0.0), 0.0, seed)
        g.add(v, f, mat)
    elif shape == "ridge_tile":
        v, f = _arc_tile(0.15, 0.36, 0.03, True, 10)
        g.add(v, f, mat, trs((0, 0, 0), (0, 0, -90)))
    # ---- wall pieces --------------------------------------------------------------------------------------------
    elif shape.startswith("stone"):
        dims = {"stone_a": (0.5, 0.26, 0.30), "stone_b": (0.42, 0.24, 0.27), "stone_c": (0.62, 0.28, 0.32),
                "stone_d": (0.36, 0.22, 0.28)}.get(shape, (0.5, 0.26, 0.3))
        v, f = _rb(dims, 0.06, 2, (0, dims[1] / 2, dims[2] / 2), 0.018, seed)
        g.add(v, f, mat)
    elif shape.startswith("ashlar"):
        dims = {"ashlar_a": (0.6, 0.3, 0.32), "ashlar_b": (0.9, 0.3, 0.32)}.get(shape, (0.6, 0.3, 0.32))
        v, f = _rb(dims, 0.025, 2, (0, dims[1] / 2, dims[2] / 2), 0.006, seed)
        g.add(v, f, mat)
    elif shape.startswith("boulder"):  # fitted / rubble stone: rounder and lumpier
        dims = {"boulder_a": (0.55, 0.3, 0.38), "boulder_b": (0.4, 0.3, 0.3), "boulder_c": (0.7, 0.32, 0.45)}.get(
            shape, (0.5, 0.3, 0.35))
        v, f = _rb(dims, 0.11, 2, (0, dims[1] / 2, dims[2] / 2), 0.03, seed)
        g.add(v, f, mat)
    elif shape == "brick":
        v, f = _rb((0.24, 0.11, 0.075), 0.01, 1, (0, 0.055, 0.0375), 0.003, seed)
        g.add(v, f, mat)
    elif shape.startswith("plank"):
        w = {"plank_a": 0.2, "plank_b": 0.26, "plank_c": 0.16}.get(shape, 0.2)
        v, f = _rb((w, 0.045, 1.0), 0.012, 1, (0, 0.0225, 0.5), 0.004, seed)
        g.add(v, f, mat)
    elif shape == "clapboard":
        v, f = _rb((1.0, 0.04, 0.22), 0.01, 1, (0, 0.02, 0.11), 0.0, seed)
        g.add(v, f, mat, trs((0, 0, 0), (-6, 0, 0)))
    elif shape == "log":
        prof = [(0.0, -0.5), (0.11, -0.5), (0.135, -0.48), (0.14, -0.45), (0.145, 0.0), (0.14, 0.45), (0.135, 0.48),
                (0.11, 0.5), (0.0, 0.5)]
        g.lathe(prof, mat, trs((0, 0.14, 0.14), (0, 90, 0)), segs=10, cap_bottom=False, cap_top=False)
    elif shape == "log_end":  # the cut face ring, a lighter disc
        g.cylinder(0.118, 0.02, mat, trs((0, 0, 0), (0, 90, 0)), segs=10)
    # ---- greenery and small things ------------------------------------------------------------------------------
    elif shape == "tuft":
        for k in range(6):
            a = k * 60 + rng.uniform(-20, 20)
            g.lathe([(0.03, 0.0), (0.0, rng.uniform(0.16, 0.26))], mat,
                    trs((0.03 * math.cos(math.radians(a)), 0.03 * math.sin(math.radians(a)), 0), (rng.uniform(-25, 25), rng.uniform(-25, 25), 0)),
                    segs=4, cap_top=False)
    elif shape == "bush":
        for k in range(7):
            r = rng.uniform(0.14, 0.24)
            g.sphere(r, mat, trs((rng.uniform(-0.2, 0.2), rng.uniform(-0.2, 0.2), r * 0.8 + rng.uniform(0, 0.1))), segs=8, rings=6)
    elif shape == "flower":
        g.sphere(0.06, mat, None, segs=6, rings=4)
    elif shape == "ivy":
        for k in range(5):
            g.sphere(rng.uniform(0.05, 0.09), mat, trs((rng.uniform(-0.12, 0.12), 0, rng.uniform(-0.12, 0.12)), (0, 0, 0), (1, 0.45, 1)), segs=6, rings=4)
    elif shape == "spot":
        g.sphere(0.5, mat, trs((0, 0, 0), (0, 0, 0), (1, 1, 0.25)), segs=10, rings=5)
    elif shape == "cobble":
        v, f = _rb((0.24, 0.22, 0.1), 0.045, 1, (0, 0, 0.05), 0.015, seed)
        g.add(v, f, mat)
    elif shape == "rivet":
        g.sphere(0.025, mat, None, segs=6, rings=3, squash=0.6)
    else:
        g.box((0.2, 0.2, 0.2), mat)
    return g
