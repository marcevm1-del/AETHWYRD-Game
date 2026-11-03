"""Global hydraulic + thermal erosion of the mountain relief, in numpy (no scipy, no numba).

One world raster (RES metres, the whole map) is built from the pre-erosion field `field._pre_erosion` (base elevation + domain-warped
ridged relief + the raised crest networks of the named peaks), eroded with a stream-power law over D8 flow routing and flow
accumulation (Kahn's algorithm, vectorised by rounds), plus thermal (talus) erosion and pit filling. The result, `delta` (eroded
minus base elevation) and `slope`, is cached on disk under Art/Blender/WorldTerrain/cache/ keyed by a hash of the data, the seed
and the code, and tiles sample it bicubically. Every tile reads the same raster, so tile joins stay bit-exact.

Determinism: fixed order, fixed iteration count, float32/float64 numpy only; the same inputs give the same raster.
"""
import hashlib
import os
import time

import numpy as np

VERSION = "eros-4"
RES = 50.0
ITERS = 60
K_INCISE = 0.30          # incision per iteration = K * sqrt(area in cells) * slope, capped at 45 % of the drop to the receiver
TALUS = 0.78             # tan of the angle of repose used by the thermal pass (about 38 degrees)
OFFS = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)]


_RF = {}


def _dirfactors(shape):
    """Fixed per-cell, per-direction preference factors (0.8-1.2): break the D8 grid-direction bias so valleys do not run in straight lines."""
    if shape not in _RF:
        _RF[shape] = [(0.8 + 0.4 * np.random.RandomState(9100 + k).random_sample(shape)).astype(np.float32) for k in range(8)]
    return _RF[shape]


def receivers(h, fixed):
    """D8 steepest-descent receivers (flat indices) and the slope to them. Fixed cells (sea, border) and pits are roots."""
    Ny, Nx = h.shape
    hp = np.pad(h, 1, mode="edge")
    best = np.zeros(h.shape, np.float32)
    bestw = np.zeros(h.shape, np.float32)
    bi = np.full(h.shape, -1, np.int8)
    rf = _dirfactors(h.shape)
    for k, (dy, dx) in enumerate(OFFS):
        nb = hp[1 + dy:1 + dy + Ny, 1 + dx:1 + dx + Nx]
        s = (h - nb) / np.float32(RES * (1.41421356 if (dy and dx) else 1.0))
        sw = s * rf[k]
        m = (sw > bestw) & (s > 0)
        bestw = np.where(m, sw, bestw)
        best = np.where(m, s, best)
        bi = np.where(m, np.int8(k), bi)
    idx = np.arange(h.size, dtype=np.int64).reshape(h.shape)
    off = np.array([dy * Nx + dx for dy, dx in OFFS], dtype=np.int64)
    rec = np.where(bi >= 0, idx + off[np.maximum(bi, 0)], idx)
    rec[fixed] = idx[fixed]
    best[fixed] = 0.0
    return rec.ravel(), best.ravel()


def accumulate(rec):
    """Drainage area (in cells) by peeling the flow forest from its leaves, in rounds."""
    N = rec.size
    ids = np.arange(N, dtype=np.int64)
    nr = rec != ids
    indeg = np.bincount(rec[nr], minlength=N).astype(np.int32)
    A = np.ones(N, np.float64)
    front = np.nonzero(indeg == 0)[0]
    while front.size:
        r = rec[front]
        m = r != front
        f2, r2 = front[m], r[m]
        if r2.size == 0:
            break
        np.add.at(A, r2, A[f2])
        np.subtract.at(indeg, r2, 1)
        cand = np.unique(r2)
        front = cand[indeg[cand] == 0]
    return A


def pit_fill(h, fixed, passes=3):
    Ny, Nx = h.shape
    for _ in range(passes):
        hp = np.pad(h, 1, mode="edge")
        m8 = None
        for dy, dx in OFFS:
            nb = hp[1 + dy:1 + dy + Ny, 1 + dx:1 + dx + Nx]
            m8 = nb if m8 is None else np.minimum(m8, nb)
        pit = (h < m8) & ~fixed
        h = np.where(pit, m8 + np.float32(0.05), h)
    return h


def thermal(h, W, passes=2, rate=0.35):
    for _ in range(passes):
        for ax, sh in ((0, 1), (0, -1), (1, 1), (1, -1)):
            diff = h - np.roll(h, sh, ax)
            ex = np.maximum(diff - np.float32(TALUS * RES), 0.0) * np.float32(rate * 0.5) * W
            h = h - ex + np.roll(ex, -sh, ax)
    return h


def erode(R0, W, fixed, protect, iters=ITERS, K=K_INCISE, log=print):
    h = R0.astype(np.float32).copy()
    Wf = (W * protect).astype(np.float32)
    t0 = time.time()
    for it in range(iters):
        h = pit_fill(h, fixed)
        rec, slope = receivers(h, fixed)
        A = accumulate(rec)
        hf = h.ravel()
        drop = np.maximum(hf - hf[rec], 0.0)
        E = K * np.sqrt(A) * slope
        E = np.minimum(E, 0.45 * drop) * Wf.ravel()
        h = (hf - E).astype(np.float32).reshape(h.shape)
        h = thermal(h, Wf)
        if it % 8 == 0:
            log("    erosion pass %d/%d  max incision %.1f m  (%.0fs)" % (it + 1, iters, float(E.max()), time.time() - t0))
    return pit_fill(h, fixed, 2)


def cache_path(repo, key):
    d = os.path.join(repo, "Art", "Blender", "WorldTerrain", "cache")
    os.makedirs(d, exist_ok=True)
    return os.path.join(d, "erosion_%s.npz" % key)


def make_key(parts):
    h = hashlib.sha256()
    h.update(VERSION.encode())
    h.update(repr((RES, ITERS, K_INCISE, TALUS)).encode())
    h.update(open(__file__, "rb").read())
    for p in parts:
        h.update(p if isinstance(p, bytes) else repr(p).encode())
    return h.hexdigest()[:20]
