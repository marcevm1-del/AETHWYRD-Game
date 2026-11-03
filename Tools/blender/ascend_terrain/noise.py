"""Deterministic lattice noise on world coordinates (metres). Pure numpy, no state: the same (x, y, seed) always gives
the same value, so tiles that share an edge get identical values there."""
import numpy as np

_M32 = np.uint64(0xFFFFFFFF)


def _hash(ix, iy, seed):
    """Integer lattice hash -> float in [0, 1)."""
    with np.errstate(over="ignore"):
        n = (ix.astype(np.int64) & 0xFFFFFFFF).astype(np.uint64) * np.uint64(374761393)
        n = (n + (iy.astype(np.int64) & 0xFFFFFFFF).astype(np.uint64) * np.uint64(668265263)) & _M32
        n = (n + np.uint64((seed * 2246822519 + 3266489917) & 0xFFFFFFFF)) & _M32
        n = ((n ^ (n >> np.uint64(13))) * np.uint64(1274126177)) & _M32
        n = (n ^ (n >> np.uint64(16))) & _M32
        n = (n * np.uint64(2654435761)) & _M32
        n = n ^ (n >> np.uint64(15))
    return (n & _M32).astype(np.float64) / 4294967296.0


def value(x, y, wavelength, seed):
    """Smooth value noise in [-1, 1]; x, y in metres."""
    u, v = x / wavelength, y / wavelength
    iu, iv = np.floor(u), np.floor(v)
    fu, fv = u - iu, v - iv
    fu = fu * fu * fu * (fu * (fu * 6 - 15) + 10)
    fv = fv * fv * fv * (fv * (fv * 6 - 15) + 10)
    a = _hash(iu, iv, seed)
    b = _hash(iu + 1, iv, seed)
    c = _hash(iu, iv + 1, seed)
    d = _hash(iu + 1, iv + 1, seed)
    top = a + (b - a) * fu
    bot = c + (d - c) * fu
    return (top + (bot - top) * fv) * 2.0 - 1.0


_ROT = [(0.8, 0.6), (0.6, -0.8), (-0.28, 0.96), (0.96, 0.28), (0.5, -0.866), (-0.866, -0.5)]


def fbm(x, y, wavelength, octaves, seed, gain=0.5, lacunarity=2.0, ridged=False):
    """Fractal noise, roughly in [-1, 1]. Each octave is rotated so the lattice axes do not show.
    ridged=True returns sharp crests in [0, 1] (1 on the crest line)."""
    amp, tot, out = 1.0, 0.0, np.zeros_like(x, dtype=np.float64)
    wl = wavelength
    for o in range(octaves):
        c, s = _ROT[o % len(_ROT)]
        xr, yr = x * c - y * s + 1013.7 * o, x * s + y * c - 577.3 * o
        n = value(xr, yr, wl, seed + 101 * o)
        if ridged:
            n = 1.0 - np.abs(n)
            n = n * n
        out += n * amp
        tot += amp
        amp *= gain
        wl /= lacunarity
    return out / tot


def smoothstep(a, b, x):
    t = np.clip((x - a) / (b - a), 0.0, 1.0)
    return t * t * (3.0 - 2.0 * t)
