"""
World diorama: the continent as a stylised tabletop model, for the world-map screen and promo art.

blender -b --factory-startup -P Tools/blender/world_diorama.py -- --repo <repo>
        [--out-dir 10_World/maps] [--only continent,heartland,spine] [--res 1920x1080] [--samples 24] [--up 3]
        [--seed 7] [--exag 5.5] [--outline] [--no-toon] [--no-labels] [--placement-only] [--report-json <path>]

Reads Data/World/physical_map.json (see 10_World/physical_geography.md, sections 10-11) and builds, in Blender units of 1 km
(x east, y north; the map's y runs south so y_blender = -y_map):
  * Terrain: the 0.5 km cells are upsampled with Catmull-Rom cubic interpolation (--up 3 = one node every 1/6 km). Biome
    colours meet in one short step (sharpened weights, not a wide blend). Mountains get ridged multi-scale noise plus a crest
    taper (jagged spines, not tubes); rock colour comes from slope and from the sun (warm tan / ochre lit, violet-grey in
    shadow); snow follows height and slope with a ragged cel edge. Lakes are flattened, river valleys carved, settlement
    pads levelled, farmland patchwork round Brindlewick and Aldmere. Sea: pale cyan shallows, a crisp foam line, deep
    #3F86B0, sparse world-space-noise sparkle (nothing tiles), and an ocean plane that fades to the horizon haze, so no slab
    edge or plinth is rendered (they stay in the file, hidden).
  * Dressing: low-poly conifer / broadleaf / palm / dead trees by biome (merged instance meshes, capped) plus a forest LOD set
    (every third tree at 2.2x) used only in the continent view; house clusters at every settlement; the 13 roads and 30
    rivers as draped ribbons; flat-bottomed cumulus lifted clear of the peaks, and stylised cumulus banks in the spine sky.
  * Look: terrain is a hard two-tone cel (shadow tint 0.58 0.56 0.78 below N.L 0.32, cream light above, computed from the
    normal against the one NW sun), a 0.22 cream rim on the lit side, hard strata bands on rock. Painted sky gradient fixed
    to the horizon of each shot. Optional Freestyle outlines (--outline). Parchment plates (ink #3A2A1C on #F3E6C8) with
    leader lines and an "Aetheria" cartouche are a camera overlay, auto-nudged so they do not overlap.
Renders diorama_continent.png, diorama_heartland.png and diorama_spine.png (low angle over the Dragon Spine).
Deterministic: all random input comes from numpy default_rng(--seed); --placement-only prints and writes the SHA-256 of the
placement data (trees, houses, clouds) without rendering.
"""
import argparse
import hashlib
import json
import math
import os
import sys
import time

import numpy as np

try:
    import bpy
    from mathutils import Vector
except ImportError:  # py_compile / hashing outside Blender
    bpy = None

argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
ap = argparse.ArgumentParser(prog="world_diorama")
ap.add_argument("--repo", default=".")
ap.add_argument("--out-dir", default="")
ap.add_argument("--only", default="continent,heartland,spine")
ap.add_argument("--res", default="1920x1080")
ap.add_argument("--samples", type=int, default=24)
ap.add_argument("--up", type=int, default=3, help="upsample factor over the 0.5 km cells")
ap.add_argument("--seed", type=int, default=7)
ap.add_argument("--exag", type=float, default=2.4)
ap.add_argument("--tree-cap", type=int, default=40000)
ap.add_argument("--tree-spacing", type=float, default=0.24)
ap.add_argument("--tree-scale", type=float, default=1.4)
ap.add_argument("--house-scale", type=float, default=1.0)
ap.add_argument("--cloud-cap", type=int, default=12)
ap.add_argument("--outline", action="store_true")
ap.add_argument("--no-toon", action="store_true")
ap.add_argument("--no-labels", action="store_true")
ap.add_argument("--placement-only", action="store_true")
ap.add_argument("--report-json", default="")
args = ap.parse_args(argv)
REPO = os.path.abspath(args.repo)
OUT = os.path.abspath(args.out_dir) if args.out_dir else os.path.join(REPO, "10_World", "maps")
RES = tuple(int(v) for v in args.res.lower().split("x"))
T0 = time.time()


def log(*a):
    print("[%6.1fs]" % (time.time() - T0), *a, flush=True)


# ---------------------------------------------------------------------------------------------------------------
# Data
D = json.load(open(os.path.join(REPO, "Data", "World", "physical_map.json"), encoding="utf-8"))
W, H, CK = D["grid"]["width"], D["grid"]["height"], D["grid"]["cellKm"]
EXTX, EXTY = W * CK, H * CK
elev = np.array(D["elevation"]["rows"], dtype=np.float64)
biome = np.array([list(r) for r in D["biomes"]["rows"]])
CODES = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
region = np.array([[CODES.find(c) if c != "." else -1 for c in r] for r in D["regions"]["rows"]], dtype=np.int32)
LEGEND = D["regions"]["legend"]
RNAME = {r["id"]: r["name"] for r in D["regionStats"]}
U = args.up
NX, NY = W * U + 1, H * U + 1
SX, SY = EXTX / (NX - 1), EXTY / (NY - 1)          # node spacing, km
XN = np.arange(NX) * SX
YN = np.arange(NY) * SY                              # map y (south)
rng = np.random.default_rng(args.seed)


# ---------------------------------------------------------------------------------------------------------------
# Numerics
def smooth(a, b, x):
    t = np.clip((np.asarray(x, dtype=np.float64) - a) / (b - a), 0, 1)
    return t * t * (3 - 2 * t)


def lin(c):
    c = np.asarray(c, dtype=np.float64) / 255.0
    return np.where(c <= 0.04045, c / 12.92, ((c + 0.055) / 1.055) ** 2.4)


def blur(a, sigma):
    """Separable Gaussian blur with edge padding; works on (h, w) or (h, w, c)."""
    if sigma <= 0:
        return a.copy()
    r = int(math.ceil(3 * sigma))
    k = np.exp(-0.5 * (np.arange(-r, r + 1) / sigma) ** 2)
    k /= k.sum()
    out = a.astype(np.float64)
    for ax in (0, 1):
        pad = [(0, 0)] * out.ndim
        pad[ax] = (r, r)
        p = np.pad(out, pad, mode="edge")
        n = out.shape[ax]
        acc = np.zeros_like(out)
        for i, w in enumerate(k):
            acc += w * np.take(p, np.arange(i, i + n), axis=ax)
        out = acc
    return out


def _cubic_axis(a, f, axis):
    n = a.shape[axis]
    i0 = np.floor(f).astype(np.int64)
    t = f - i0
    ws = (-0.5 * t ** 3 + t ** 2 - 0.5 * t, 1.5 * t ** 3 - 2.5 * t ** 2 + 1, -1.5 * t ** 3 + 2 * t ** 2 + 0.5 * t,
          0.5 * t ** 3 - 0.5 * t ** 2)
    shape = [1] * a.ndim
    shape[axis] = len(f)
    out = 0
    for k, w in zip((-1, 0, 1, 2), ws):
        out = out + np.take(a, np.clip(i0 + k, 0, n - 1), axis=axis) * w.reshape(shape)
    return out


def resample(a, fy, fx):
    """Catmull-Rom resample of a coarse (h, w[, c]) field at fractional cell indices fy (rows), fx (cols)."""
    return _cubic_axis(_cubic_axis(a.astype(np.float64), fy, 0), fx, 1)


FYN = YN / CK - 0.5     # coarse index of every node row / column (cell centres sit at integer indices)
FXN = XN / CK - 0.5


def up(a):
    return resample(a, FYN, FXN)


def lattice_noise(spacing_km, seed):
    """Smooth value noise in [0, 1] at the nodes; lattice spacing in km."""
    r = np.random.default_rng(seed)
    g = r.random((int(EXTY / spacing_km) + 4, int(EXTX / spacing_km) + 4))
    return np.clip(resample(g, YN / spacing_km + 1, XN / spacing_km + 1), 0, 1)


def bil(F, x, ym):
    """Bilinear sample of a node field at map points (x km, y km south)."""
    fx = np.clip(np.asarray(x) / SX, 0, NX - 1.001)
    fy = np.clip(np.asarray(ym) / SY, 0, NY - 1.001)
    i, j = fx.astype(np.int64), fy.astype(np.int64)
    tx, ty = fx - i, fy - j
    return (F[j, i] * (1 - tx) * (1 - ty) + F[j, i + 1] * tx * (1 - ty) + F[j + 1, i] * (1 - tx) * ty
            + F[j + 1, i + 1] * tx * ty)


def stamp(field, pts, radius, value=1.0):
    """Raise `field` (node grid) to value * falloff round each map point; deterministic, windowed."""
    rn = int(math.ceil(radius / min(SX, SY))) + 1
    for x, y in pts:
        ci, cj = int(round(x / SX)), int(round(y / SY))
        i0, i1, j0, j1 = max(0, ci - rn), min(NX, ci + rn + 1), max(0, cj - rn), min(NY, cj + rn + 1)
        if i0 >= i1 or j0 >= j1:
            continue
        d = np.hypot(XN[None, i0:i1] - x, YN[j0:j1, None] - y)
        np.maximum(field[j0:j1, i0:i1], value * (1 - smooth(0.0, radius, d)), out=field[j0:j1, i0:i1])


def densify(pts, step):
    out = [pts[0]]
    for a, b in zip(pts, pts[1:]):
        n = max(1, int(math.hypot(b[0] - a[0], b[1] - a[1]) / step))
        out += [(a[0] + (b[0] - a[0]) * k / n, a[1] + (b[1] - a[1]) * k / n) for k in range(1, n + 1)]
    return out


# ---------------------------------------------------------------------------------------------------------------
# Terrain fields
log("fields: grid %dx%d nodes (up %d)" % (NX, NY, U))
SET = D["settlements"]
SETD = {s["id"]: s for s in SET}
HOUSES_N = {"capital": 70, "city": 26, "town": 16, "port": 16, "market": 8, "village": 9, "monastery": 7, "fortress": 14,
            "fort": 8, "hamlet": 5, "farmland": 5, "farmstead": 3, "camp": 4, "inn": 2, "shrine": 2, "eyrie": 4, "glade": 3}
EMPH = {"aldmere": 70, "brindlewick": 22}
HOUSE_W = {"aldmere": 0.15, "brindlewick": 0.17}


def house_count(s):
    return EMPH.get(s["id"], HOUSES_N.get(s["kind"], 3))


def house_w(s):
    return HOUSE_W.get(s["id"], 0.11) * args.house_scale


def cluster_radius(s):
    n, w = house_count(s), house_w(s)
    return max(0.12, 1.45 * w * math.sqrt(n / math.pi))


land_c = (elev >= 0).astype(np.float64)
ELc = blur(elev, 0.9)
ELc = np.where(elev >= 0, np.maximum(ELc, 2.0), np.minimum(ELc, -2.0))
E = up(ELc)                                          # metres, smooth
LAKE_c = (biome == "l").astype(np.float64)
Lk = np.clip(up(blur(LAKE_c, 0.6)), 0, 1)
lake_h = up(blur(elev * LAKE_c, 0.6)) / np.maximum(up(blur(LAKE_c, 0.6)), 1e-3)
lk_w = smooth(0.35, 0.6, Lk)
E = np.where(lk_w > 0, E * (1 - lk_w) + (lake_h - 1.5) * lk_w, E)

n_low, n_mid, n_hi = lattice_noise(3.0, 11), lattice_noise(0.9, 12), lattice_noise(0.28, 13)
# Rivers: carve valleys, collect ribbon data
OCC = np.zeros((NY, NX))                              # things trees must keep clear of
CARVE = np.zeros((NY, NX))
RIVERS = []
for r in D["rivers"]:
    ps = r["pathSmooth"]
    pts = densify([(p[0], p[1]) for p in ps], 0.16)
    wid = np.interp(np.linspace(0, len(ps) - 1, len(pts)), np.arange(len(ps)), [p[3] for p in ps])
    RIVERS.append((r["id"], pts, wid))
    stamp(CARVE, pts, 0.32, 1.0)
    stamp(OCC, pts, 0.16, 1.0)
# Ridged multi-scale noise: sharp crests that run along the range, and a crest taper that lowers everything between the
# crests, so the high ground reads as jagged spines and not as round tubes.
_rg = lambda n_: (1 - np.abs(2 * n_ - 1)) ** 1.5
RIDGE = np.clip(0.56 * _rg(lattice_noise(1.7, 31)) + 0.33 * _rg(lattice_noise(0.62, 32)) + 0.108 * _rg(lattice_noise(0.24, 33)), 0, 1)
_hf = smooth(450, 1400, E)
E = E + _hf * 420.0 * (RIDGE - 0.38) * (E > 3)
E = E - smooth(1250, 2700, E) * 430.0 * (1 - RIDGE) ** 1.3 * (E > 3)
E = E - CARVE * 7.0 * (E > 3)
# Per-peak cone stamps (round 4). Peaks: the named ones in physical_map.json, secondary ones every 2.5-4.5 km along each range
# crest, and local maxima of the blurred relief where a massif has no crest data. Each is a slightly concave cone with 5-9
# radial ridges (ridged noise in azimuth), blended into the range through a wide (about 4 km) foothill ramp. Own rng: the
# shared placement rng is untouched.
_pr = np.random.default_rng(args.seed + 888)
PEAKS = []                                            # (x km, y km, height m)
for rg_ in D["ranges"]:
    for pk in rg_.get("peaks", []):
        PEAKS.append((pk["at"][0], pk["at"][1], float(pk["m"]) * (0.92 + 0.08 * _pr.random())))
    cr_ = densify([(c[0], c[1]) for c in rg_["crest"]], 0.25)
    acc_ = 1.5
    for a_, b_ in zip(cr_, cr_[1:]):
        acc_ += math.hypot(b_[0] - a_[0], b_[1] - a_[1])
        if acc_ >= 3.4 + 2.4 * _pr.random():
            acc_ = 0.0
            PEAKS.append((b_[0] + (_pr.random() - 0.5) * 0.9, b_[1] + (_pr.random() - 0.5) * 0.9,
                          min(2950.0, rg_["maxM"]) * (0.55 + 0.30 * _pr.random())))
_Eb8 = blur(E, 8)
_cand = np.argwhere((_Eb8[::3, ::3] > 1500))
_cand = _cand[np.argsort(-_Eb8[::3, ::3][_cand[:, 0], _cand[:, 1]], kind="stable")]
_taken = [(p_[0], p_[1]) for p_ in PEAKS]
for j_, i_ in _cand:
    x_, y_ = XN[i_ * 3], YN[j_ * 3]
    if all(math.hypot(x_ - tx, y_ - ty) > 4.2 for tx, ty in _taken):
        _taken.append((x_, y_))
        PEAKS.append((x_, y_, min(2900.0, float(_Eb8[j_ * 3, i_ * 3]) * (0.95 + 0.2 * _pr.random()))))
log("peaks", len(PEAKS))
CONE = np.zeros((NY, NX))
FREL = np.zeros((NY, NX))                             # fraction of the winning peak's own height (for snow caps)
_gxm, _gym = XN[None, :], YN[:, None]
for (px_, py_, ph_) in PEAKS:
    R_ = 3.0 + ph_ / 1000.0 * 0.95
    i0_, i1_ = max(0, int((px_ - R_) / SX)), min(NX, int((px_ + R_) / SX) + 2)
    j0_, j1_ = max(0, int((py_ - R_) / SY)), min(NY, int((py_ + R_) / SY) + 2)
    if i1_ <= i0_ or j1_ <= j0_:
        continue
    dx_, dy_ = _gxm[:, i0_:i1_] - px_, _gym[j0_:j1_, :] - py_
    d_ = np.hypot(dx_, dy_)
    th_ = np.arctan2(dy_, dx_)
    nr_ = int(5 + _pr.integers(0, 5))
    ph0 = _pr.random() * 6.28
    wob = 0.5 * np.sin(2 * th_ + _pr.random() * 6.28) * d_ / R_
    rd_ = (1 - np.abs(np.sin(nr_ * 0.5 * th_ + ph0 + wob * 3.0))) ** 1.6
    t_ = np.clip(1 - d_ / R_, 0, 1)
    prof = t_ ** 1.45 * (0.88 + 0.22 * rd_ * smooth(0.0, 0.5, t_))
    cur = ph_ * prof
    cs = CONE[j0_:j1_, i0_:i1_]
    fs = FREL[j0_:j1_, i0_:i1_]
    m_ = cur > cs
    fs[m_] = (prof * (1.0))[m_]
    cs[m_] = cur[m_]
_Elow = blur(E, 10)
_M = smooth(450, 1250, blur(E, 14))                   # wide foothill ramp, about 4 km
_Emt = np.maximum(CONE, 0.42 * _Elow) + (E - _Elow) * 0.12
E = np.where(E > 3, E * (1 - _M) + _Emt * _M, E)
FREL = FREL * _M
# Lakes only on flat ground: where the stamped relief under a lake is steeper than about 8% the water is dropped (no water on
# any slope); the rest stay flat basins.
_gy0, _gx0 = np.gradient(blur(E, 2.0), SY * 1000.0, SX * 1000.0)
LK_OK = 1 - smooth(0.05, 0.08, blur(np.hypot(_gx0, _gy0), 4.0))
LKD = np.clip(up(blur(LAKE_c, 0.6)) * 3.0, 0, 1) * (1 - LK_OK)
lk_w = lk_w * LK_OK
E = np.where(lk_w > 0, E * (1 - lk_w) + (lake_h - 1.5) * lk_w, E)      # lakes stay flat

# Settlement pads
Eb = blur(E, 1.5)
for s in SET:
    if s.get("inWater") == "sea":
        continue
    r = cluster_radius(s)
    d = np.hypot(XN[None, :] - s["x"], YN[:, None] - s["y"])
    target = float(bil(Eb, s["x"], s["y"]))
    w = 1 - smooth(r * 0.9, r * 1.6, d)
    land_only = E > 3
    E = np.where(land_only, E * (1 - w) + target * w, E)
    stamp(OCC, [(s["x"], s["y"])], r * 1.2, 1.0)

LAND = E > 0
SEA = ~LAND
depth = np.maximum(-E, 0)
# Heights in Blender units
Z = np.where(LAND, E / 1000.0 * args.exag, -0.03 * (1 - np.exp(-depth / 60.0)))
wave_x, wave_y = np.meshgrid(XN, -YN)
WAVE = (lattice_noise(0.9, 41) - 0.5) * 0.012 + (lattice_noise(0.33, 42) - 0.5) * 0.006      # world-space noise: nothing repeats
Z = Z + np.where(SEA, WAVE * smooth(2.0, 30.0, depth), 0.0)
Z = np.where(lk_w > 0.5, E / 1000.0 * args.exag - 0.004, Z)

Eg = blur(E, 0.7)
gy, gx = np.gradient(Eg, SY * 1000.0, SX * 1000.0)
SLOPE = np.hypot(gx, gy)                              # m per m
gzy, gzx = np.gradient(Z, SY, SX)
GZ = np.hypot(gzx, gzy)                               # blender z per km

# Colours -----------------------------------------------------------------------------------------------------------
TINT = {"p": (150, 196, 98), "f": (84, 150, 80), "w": (112, 138, 92), "s": (206, 192, 112), "m": (150, 142, 124),
        "v": (150, 132, 104), "t": (222, 230, 226), "d": (236, 204, 142), "j": (58, 142, 88), "i": (176, 170, 214),
        "x": (156, 84, 98), "a": (170, 164, 126), "n": (246, 248, 250), "b": (204, 182, 132), "l": (110, 170, 196),
        "~": (110, 170, 196)}
C0 = np.zeros((H, W, 3))
for k, v in TINT.items():
    C0[biome == k] = v
num = blur(C0 * land_c[..., None], 1.15)
den = blur(land_c, 1.15)[..., None]
CL_soft = np.clip(up(num) / np.maximum(up(den), 1e-3), 0, 255)
# Hard-ish cel blend: each biome gets a blurred weight, sharpened with a power, so neighbouring biomes meet in one short
# step (about 0.2 km) and not in a wide smear.
_acc, _ws = np.zeros((NY, NX, 3)), np.zeros((NY, NX))
for k, v in TINT.items():
    wk = np.clip(up(blur((biome == k).astype(np.float64) * land_c, 0.55)), 0, 1) ** 20
    _acc += wk[..., None] * np.array(v, dtype=np.float64)
    _ws += wk
CL = np.where((_ws > 1e-5)[..., None], _acc / np.maximum(_ws, 1e-9)[..., None], CL_soft)
CL = np.clip(CL, 0, 255)
CL = CL + (np.array((120, 152, 94), dtype=np.float64) - CL) * LKD[..., None]        # dropped lake: foothill green, not water

paint = (n_low - 0.5) * 0.10 + (n_mid - 0.5) * 0.07 + (n_hi - 0.5) * 0.05
CL = CL * (1 + paint[..., None])
CL[..., 0] *= 1 + (n_mid - 0.5) * 0.05        # slight warm/cool drift: painterly colour patches
CL[..., 2] *= 1 - (n_mid - 0.5) * 0.05
# forest floor: two-step clump contrast so a big forest is not one flat green
_clump = np.floor(np.clip(n_hi * 2.2, 0, 1.99)) * 0.5
_bf = smooth(0.46, 0.54, np.clip(up(blur(np.isin(biome, ["f", "j", "w"]).astype(np.float64), 0.8)), 0, 1))   # hard edge: no halo
CL = CL * (1 - 0.10 * _bf[..., None] * (1 - _clump[..., None] * 1.0))

ROCK_C = np.array((136, 126, 118))
SNOW_C = np.array((244, 247, 252))
SAND_C, WET_C = np.array((238, 222, 172)), np.array((208, 190, 144))
# Mountain faces: slope-based colour, warm tan / ochre in the light, violet-grey in the shadow. The lit/shadow split uses
# the same sun as the shader, with the same hard terminator, so the baked colour and the cel ramp agree.
ROCK_LIT_A, ROCK_LIT_B, ROCK_SHD = np.array((208, 182, 144)), np.array((196, 160, 116)), np.array((228, 214, 198))
SUN_TO = np.array((-1.0, 1.0, 1.1))
SUN_TO = SUN_TO / np.linalg.norm(SUN_TO)
TERM = 0.32                                           # shader terminator threshold on N.L


def mix(a, b, t):
    return a + (b - a) * np.asarray(t)[..., None]


Eg_ = E
log("land elevation p50 %.0f p90 %.0f p99 %.0f max %.0f m" % tuple(np.percentile(E[E > 3], [50, 90, 99, 100])))
_gzy2, _gzx2 = np.gradient(blur(Z, 2.0), SY, SX)       # low-pass normal: one lit half and one shaded half per cone
_nz = 1.0 / np.sqrt(_gzx2 ** 2 + _gzy2 ** 2 + 1.0)
NDL = (-_gzx2 * SUN_TO[0] + _gzy2 * SUN_TO[1] + SUN_TO[2]) * _nz
lit_f = smooth(TERM - 0.03, TERM + 0.03, NDL)       # hard terminator
slope_n = SLOPE + (n_hi - 0.5) * 0.14
col = mix(CL, ROCK_C, smooth(1250, 1500, Eg_) * 0.55)            # alpine scree tint
rock = np.clip(smooth(0.50, 0.70, slope_n) * smooth(850, 1300, Eg_) + smooth(1250, 1750, Eg_) * 0.9, 0, 1)      # green foothills first, rock higher up
rock_c = mix(ROCK_SHD, mix(ROCK_LIT_A, ROCK_LIT_B, smooth(0.35, 0.65, n_mid)), lit_f)
rock_c = rock_c * (0.94 + 0.12 * n_hi[..., None])
col = mix(col, rock_c, rock)
# Foothills: volcanic / mountain ground below the rock line is green or warm tan, never mud brown
_vm = np.clip(up(blur(np.isin(biome, ["v", "m", "a"]).astype(np.float64), 0.6)) * 1.5, 0, 1)
col = mix(col, np.array((128, 156, 94), dtype=np.float64), _vm * smooth(250, 500, Eg_) * (1 - smooth(900, 1300, Eg_)) * (1 - rock) * 0.8)
# Snow: height plus slope, ragged edge from noise, then one short step (cel). It follows the terrain: steep faces stay bare.
snowbiome = up(blur(np.isin(biome, ["n"]).astype(np.float64), 0.8))
sf = smooth(2380, 2900, Eg_ + (n_mid - 0.5) * 480 + (n_hi - 0.5) * 240) * (1 - 0.92 * smooth(0.62, 1.0, SLOPE + (n_hi - 0.5) * 0.1)) + snowbiome * 0.9
_rel = smooth(0.80, 0.84, FREL + (n_hi - 0.5) * 0.10 + (n_mid - 0.5) * 0.05) * smooth(1500, 1900, Eg_)    # top ~18% of every peak
sf = np.maximum(sf, _rel)
snow = np.clip(smooth(0.38, 0.48, sf), 0, 1)
col = mix(col, SNOW_C, snow)
coast_low = (1 - smooth(4, 20, E)) * (E > 0)
nearsea = smooth(0.04, 0.5, blur((~LAND).astype(np.float64), 2.5))
beach = np.clip(coast_low * nearsea * 1.8, 0, 1) * (1 - snow)
col = mix(col, SAND_C, beach)
col = mix(col, WET_C, (1 - smooth(0.4, 3.2, E)) * (E > 0) * nearsea)

# Cast shadows: march the height field toward the sun (north-west, which is -x and -y in map cells) and tint the lowlands a
# lavender where a mountain blocks the sun. Baked into the vertex colour, so it costs nothing at render time.
_dcell = math.hypot(SX, SY)
_tan = SUN_TO[2] / math.hypot(SUN_TO[0], SUN_TO[1])
CAST = np.zeros((NY, NX))
for _j in range(1, 60):
    _sh = np.full((NY, NX), -9.0)
    _sh[_j:, _j:] = Z[:-_j, :-_j] - _tan * _j * _dcell
    CAST = np.maximum(CAST, smooth(0.0, 0.05, _sh - Z))
CAST = blur(CAST, 0.8) * (LAND) * (1 - smooth(900, 1500, E))
col = mix(col, col * np.array((0.84, 0.83, 0.95)), CAST * (1 - snow))

# Farmland patchwork round Brindlewick and Aldmere
FARM = [(206, 190, 96), (156, 196, 98), (190, 170, 90), (120, 176, 90)]
for sid, ring in (("brindlewick", 2.2), ("aldmere", 3.0), ("millbrook", 1.0)):
    s = SETD.get(sid)
    if not s:
        continue
    r0 = cluster_radius(s) * 1.35
    d = np.hypot(XN[None, :] - s["x"], YN[:, None] - s["y"])
    ang = 0.35
    u = (XN[None, :] - s["x"]) * math.cos(ang) + (YN[:, None] - s["y"]) * math.sin(ang)
    v = -(XN[None, :] - s["x"]) * math.sin(ang) + (YN[:, None] - s["y"]) * math.cos(ang)
    pid = (np.floor(u / 0.30).astype(np.int64) * 73856093) ^ (np.floor(v / 0.22).astype(np.int64) * 19349663)
    pid = (pid % 4).astype(np.int64)
    fc = np.array(FARM, dtype=np.float64)[pid]
    ring_w = smooth(r0, r0 + 0.2, d) * (1 - smooth(r0 + ring, r0 + ring + 0.35, d)) * (E > 3) * (SLOPE < 0.18) * (1 - snow)
    col = mix(col, fc, ring_w * 0.75)

# Lakes
col = mix(col, np.array((104, 172, 204)), lk_w)

# Sea: pale cyan shallow ring, a crisp foam line at the coast, deep colour #3F86B0. Colours are pre-divided by the cream
# light so that the lit result is exactly the colour written here; the sea needs no ramp tint.
Lf = LAND.astype(np.float64)
Lb1, Lb2 = blur(Lf, 2.0), blur(Lf, 7.0)
shallow = np.clip(np.maximum(1 - smooth(0, 120, depth), np.clip(Lb2 * 2.2, 0, 1)), 0, 1)
SH, MID, DEEP = np.array((176, 236, 228)), np.array((98, 178, 206)), np.array((63, 134, 176))
sea_c = mix(mix(DEEP, MID, smooth(0.08, 0.38, shallow)), SH, smooth(0.55, 0.85, shallow))
sea_c = sea_c * (1 + (n_mid[..., None] - 0.5) * 0.06 * smooth(0.1, 0.5, shallow)[..., None])
wob = (lattice_noise(0.55, 21) - 0.5) * 0.06 + (lattice_noise(1.7, 22) - 0.5) * 0.05
q = Lb1 + wob * smooth(0.0, 0.08, Lb1)
foam1 = smooth(0.085, 0.095, q) * (1 - smooth(0.125, 0.135, q))                # the foam line, crisp
foam2 = smooth(0.036, 0.042, q) * (1 - smooth(0.054, 0.060, q)) * 0.55 * smooth(0.008, 0.02, Lb1)          # a fainter outer wave line
foam_edge = (1 - smooth(0, 2.0, depth)) * SEA
foam = np.clip(np.maximum.reduce([foam1, foam2, foam_edge]) * SEA, 0, 1)
sea_c = mix(sea_c, np.array((250, 252, 248)), np.clip(foam * 1.0, 0, 1))
_cream = lin(np.array((255, 241, 214)))
_lin_sea = lin(np.clip(sea_c, 0, 255)) / _cream
sea_c = np.clip(np.where(_lin_sea <= 0.0031308, _lin_sea * 12.92, 1.055 * np.maximum(_lin_sea, 1e-9) ** (1 / 2.4) - 0.055), 0, 1) * 255
col = np.where(SEA[..., None] & (lk_w < 0.5)[..., None], sea_c, col)
col = np.clip(col, 0, 255)
GLOSS = np.where(SEA | (lk_w > 0.5), 1.0, 0.0) * (1 - foam)                       # sparkle mask (world-space noise in the shader)
ROCKM = np.where(LAND, rock * 0.12, 0.0)          # faint bump on rock faces only
# strata only on real cliffs (steeper than about 55 degrees) below the snowline, so the main faces stay smooth
CLIFFM = np.where(LAND, smooth(1.2, 1.6, SLOPE * args.exag) * (1 - smooth(2000, 2400, E)) * (1 - snow), 0.0)


# ---------------------------------------------------------------------------------------------------------------
# Placement (deterministic; no bpy needed)
def zat(x, ym):
    return bil(Z, x, ym)


def biome_at(x, ym):
    i = np.clip((np.asarray(x) / CK).astype(np.int64), 0, W - 1)
    j = np.clip((np.asarray(ym) / CK).astype(np.int64), 0, H - 1)
    return biome[j, i]


Eb_hi = blur(elev, 3.0)
EBH = up(Eb_hi)
TREE_T = {"conifer": 0, "broadleaf": 1, "palm": 2, "dead": 3}
PALS = {  # (trunk, foliage A, foliage B) sRGB
    "conifer": ((88, 62, 44), (40, 94, 70), (62, 124, 84)),
    "conifer_cold": ((88, 62, 44), (50, 98, 86), (92, 142, 120)),
    "broad": ((98, 68, 46), (92, 164, 80), (128, 198, 96)),
    "broad_dark": ((90, 62, 42), (66, 134, 70), (96, 168, 84)),
    "jungle": ((98, 68, 46), (40, 140, 84), (70, 180, 100)),
    "swamp": ((84, 70, 52), (92, 118, 70), (122, 146, 84)),
    "spirit": ((98, 68, 46), (226, 140, 178), (246, 182, 204)),
    "palm": ((150, 112, 80), (80, 168, 92), (118, 200, 108)),
    "dead": ((116, 98, 86), (116, 98, 86), (140, 122, 106)),
}


def place_trees():
    sp = args.tree_spacing
    gx_ = np.arange(sp * 0.5, EXTX, sp)
    gy_ = np.arange(sp * 0.5, EXTY, sp)
    GX, GY = np.meshgrid(gx_, gy_)
    GX, GY = GX.ravel(), GY.ravel()
    n = len(GX)
    R = rng.random((n, 7))
    X = GX + (R[:, 0] - 0.5) * sp * 0.9
    Y = GY + (R[:, 1] - 0.5) * sp * 0.9
    X, Y = np.clip(X, 0.05, EXTX - 0.05), np.clip(Y, 0.05, EXTY - 0.05)
    b = biome_at(X, Y)
    e = bil(E, X, Y)
    sl = bil(SLOPE, X, Y)
    occ = bil(OCC, X, Y)
    snw = bil(snow, X, Y)
    dens = bil(n_low, X, Y) * 0.8 + bil(n_mid, X, Y) * 0.4
    prob = np.zeros(n)
    PB = {"f": 0.62, "j": 0.72, "p": 0.07, "w": 0.30, "s": 0.02, "d": 0.012, "m": 0.24, "a": 0.36, "v": 0.09, "t": 0.12,
          "i": 0.48, "x": 0.14, "b": 0.08}
    for k, v in PB.items():
        prob[b == k] = v
    prob *= np.clip(0.25 + 1.5 * (dens - 0.2), 0.0, 1.8)
    prob = np.where(b == "m", prob * (1 - smooth(1100, 1700, e)), prob)
    prob = np.where(b == "a", prob * (1 - smooth(1500, 2100, e)), prob)
    ok = (e > 4) & (sl < 0.55) & (occ < 0.2) & (snw < 0.35) & (bil(lk_w, X, Y) < 0.2)
    keep = ok & (R[:, 2] < prob)
    idx = np.nonzero(keep)[0]
    if len(idx) > args.tree_cap:                      # deterministic cap: lowest random keys survive
        idx = idx[np.argsort(R[idx, 3], kind="stable")[: args.tree_cap]]
        idx.sort()
    X, Y, b, e, R = X[idx], Y[idx], b[idx], e[idx], R[idx]
    t = np.zeros(len(idx), dtype=np.int64)
    pal = np.empty(len(idx), dtype=object)
    lat = Y
    r4 = R[:, 4]
    for i in range(len(idx)):
        k = b[i]
        if k == "f":
            pc = 0.85 if lat[i] < 35 else (0.40 if lat[i] < 75 else 0.12)
            if r4[i] < pc:
                t[i], pal[i] = 0, ("conifer_cold" if lat[i] < 30 else "conifer")
            elif r4[i] > 0.92 and lat[i] > 70:
                t[i], pal[i] = 2, "palm"
            else:
                t[i], pal[i] = 1, ("broad_dark" if lat[i] < 60 else "broad")
        elif k == "j":
            t[i], pal[i] = (1, "jungle") if r4[i] < 0.62 else (2, "palm")
        elif k == "p":
            t[i], pal[i] = (0, "conifer") if (lat[i] < 28 and r4[i] < 0.6) else (1, "broad")
        elif k == "w":
            t[i], pal[i] = (3, "dead") if r4[i] < 0.55 else (1, "swamp")
        elif k in ("m", "a"):
            t[i], pal[i] = 0, ("conifer_cold" if e[i] > 900 else "conifer")
        elif k == "t":
            t[i], pal[i] = 0, "conifer_cold"
        elif k == "i":
            t[i], pal[i] = 1, "spirit"
        elif k in ("v", "x"):
            t[i], pal[i] = 3, "dead"
        elif k == "d":
            t[i], pal[i] = (2, "palm") if r4[i] < 0.6 else (3, "dead")
        elif k == "b":
            t[i], pal[i] = 2, "palm"
        else:
            t[i], pal[i] = 1, "broad"
    base_h = np.array([0.42, 0.34, 0.40, 0.30])[t] * args.tree_scale
    hscale = base_h * (0.75 + 0.5 * R[:, 5])
    hscale = np.where(t == 0, hscale * (1 - 0.4 * smooth(900, 1700, e)), hscale)
    yaw = R[:, 6] * 2 * math.pi
    return dict(x=X, y=Y, t=t, pal=pal, h=hscale, yaw=yaw, bright=0.9 + 0.2 * R[:, 3])


def place_houses():
    out = []
    for s in SET:
        if s.get("inWater"):
            out.append(dict(s=s, skip=s["inWater"]))
            continue
        n, w = house_count(s), house_w(s)
        r = cluster_radius(s)
        hr = np.random.default_rng(args.seed * 1000 + sum(ord(c) for c in s["id"]))
        pts = []
        golden = math.pi * (3 - math.sqrt(5))
        for i in range(n):
            rr = r * math.sqrt((i + 0.5) / n)
            th = i * golden + hr.random() * 0.25
            x, y = s["x"] + rr * math.cos(th), s["y"] + rr * math.sin(th)
            if s["id"] == "aldmere" and rr < 0.12:
                continue                                    # the keep sits in the middle
            if bil(CARVE, x, y) > 0.5:
                continue
            if bil(E, x, y) <= 3 or bil(lk_w, x, y) > 0.3:
                continue
            yaw = (round(hr.random() * 4) * math.pi / 2 + (hr.random() - 0.5) * 0.3) if s["id"] != "aldmere" else th + math.pi / 2
            pts.append((x, y, yaw, w * (0.85 + 0.35 * hr.random()), int(hr.integers(0, 3)), int(hr.integers(0, 3))))
        out.append(dict(s=s, pts=pts, r=r, w=w))
    return out


def place_clouds():
    sp = 2.4
    gx_ = np.arange(sp * 0.5, EXTX, sp)
    gy_ = np.arange(sp * 0.5, EXTY, sp)
    GX, GY = np.meshgrid(gx_, gy_)
    GX, GY = GX.ravel(), GY.ravel()
    R = rng.random((len(GX), 8))
    X, Y = GX + (R[:, 0] - 0.5) * sp, GY + (R[:, 1] - 0.5) * sp
    eh = bil(EBH, np.clip(X, 0, EXTX), np.clip(Y, 0, EXTY))
    score = smooth(500, 1100, eh) * (1 - smooth(1700, 2300, eh)) * (0.45 + bil(n_low, X, Y)) * 0.9
    idx = np.nonzero(R[:, 2] < score)[0]
    if len(idx) > args.cloud_cap:
        idx = idx[np.argsort(R[idx, 3], kind="stable")[: args.cloud_cap]]
        idx.sort()
    cl = []
    for i in idx:
        z0 = float(bil(Z, X[i], Y[i]))
        zb = float(bil(EBH, X[i], Y[i])) / 1000.0 * args.exag
        zpk = max(float(bil(Z, np.clip(X[i] + dx_, 0, EXTX), np.clip(Y[i] + dy_, 0, EXTY))) for dx_, dy_ in
                  ((0, 0), (1.4, 0), (-1.4, 0), (0, 1.4), (0, -1.4), (1.0, 1.0), (-1.0, 1.0), (1.0, -1.0), (-1.0, -1.0)))
        zc = max(zb + 0.5 + 1.0 * R[i, 4], z0 * 0.6 + 0.6, zpk + 0.9 + 0.8 * R[i, 4])
        cl.append(dict(x=float(X[i]), y=float(Y[i]), z=zc, r=0.9 + 0.9 * R[i, 5], seed=int(R[i, 6] * 1e6)))
    return cl


log("placing")
TREES = place_trees()
HOUSES = place_houses()
CLOUDS = place_clouds()


def placement_hash():
    q = lambda a: np.round(np.asarray(a, dtype=np.float64) * 1000).astype(np.int64)
    h = hashlib.sha256()
    parts = {}
    tr = np.stack([TREES["t"], q(TREES["x"]), q(TREES["y"]), q(TREES["h"]), q(TREES["yaw"])], 1)
    ho = [[i, *q([p[0], p[1], p[2], p[3]]), p[4], p[5]] for i, hd in enumerate(HOUSES) for p in hd.get("pts", [])]
    ho = np.array(ho, dtype=np.int64).reshape(-1, 7)
    cl = np.array([[*q([c["x"], c["y"], c["z"], c["r"]]), c["seed"]] for c in CLOUDS], dtype=np.int64).reshape(-1, 5)
    for k, a in (("trees", tr), ("houses", ho), ("clouds", cl)):
        d = hashlib.sha256(np.ascontiguousarray(a).tobytes()).hexdigest()
        parts[k] = dict(count=int(len(a)), sha256=d)
        h.update(a.tobytes())
    parts["all"] = h.hexdigest()
    return parts


PH = placement_hash()
log("placement hash", PH["all"], "trees %d houses %d clouds %d" % (PH["trees"]["count"], PH["houses"]["count"], PH["clouds"]["count"]))
if args.report_json:
    os.makedirs(os.path.dirname(os.path.abspath(args.report_json)), exist_ok=True)
    json.dump(dict(seed=args.seed, up=U, placement=PH, skipped_settlements=[(h["s"]["id"], h["skip"]) for h in HOUSES if "skip" in h]),
              open(args.report_json, "w"), indent=1)
if args.placement_only or bpy is None:
    sys.exit(0)

# ---------------------------------------------------------------------------------------------------------------
# Blender build
log("building scene")
for o in list(bpy.data.objects):
    bpy.data.objects.remove(o)
for blk in (bpy.data.meshes, bpy.data.materials, bpy.data.curves, bpy.data.lights, bpy.data.cameras):
    for x in list(blk):
        blk.remove(x)
sc = bpy.context.scene
for e_ in ("BLENDER_EEVEE", "BLENDER_EEVEE_NEXT"):
    try:
        sc.render.engine = e_
        break
    except TypeError:
        continue
sc.view_settings.view_transform = "Standard"
sc.view_settings.look = "None"
sc.view_settings.exposure = 0.0
COLL = {n: bpy.data.collections.new(n) for n in ("Land", "Dressing", "Sky", "Overlay")}
for c in COLL.values():
    sc.collection.children.link(c)


def mesh_obj(name, V, T, C, smooth_shade=False, coll="Dressing", mat=None):
    """V (n,3) float, T (m,3) int tris, C (n,3) sRGB 0-255 per vertex (or None) -> object in collection."""
    V = np.asarray(V, dtype=np.float32)
    T = np.asarray(T, dtype=np.int32)
    me = bpy.data.meshes.new(name)
    me.vertices.add(len(V))
    me.vertices.foreach_set("co", V.ravel())
    me.loops.add(len(T) * 3)
    me.loops.foreach_set("vertex_index", T.ravel())
    me.polygons.add(len(T))
    me.polygons.foreach_set("loop_start", (np.arange(len(T)) * 3).astype(np.int32))
    me.update(calc_edges=True)
    if C is not None:
        ca = me.color_attributes.new("col", "FLOAT_COLOR", "POINT")
        rgba = np.concatenate([lin(C), np.ones((len(V), 1))], 1).astype(np.float32)
        ca.data.foreach_set("color", rgba.ravel())
    me.polygons.foreach_set("use_smooth", np.full(len(T), smooth_shade, dtype=bool))
    if mat:
        me.materials.append(mat)
    o = bpy.data.objects.new(name, me)
    COLL[coll].objects.link(o)
    return o


def set_gloss(o, g, rock_m=None, cliff=None):
    ca = o.data.color_attributes.new("surf", "FLOAT_COLOR", "POINT")
    rm_ = g if rock_m is None else rock_m
    cl_ = g if cliff is None else cliff
    rgba = np.stack([g, rm_, cl_, np.ones_like(g)], 1).astype(np.float32)
    ca.data.foreach_set("color", rgba.ravel())


def toon_material(name, shadow=(166, 162, 206), light=(255, 241, 214), hard=False, terrain=False):
    """Cel material. hard: a two-tone step (shadow / light) with a hard terminator; otherwise the soft three-stop ramp used
    for dressing. terrain: hard ramp plus strata bump on rock, a cream rim on the lit side, and a noise sparkle on water."""
    m = bpy.data.materials.new(name)
    m.use_nodes = True
    nt = m.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    N, L = nt.nodes.new, nt.links.new
    out = N("ShaderNodeOutputMaterial")
    colattr = N("ShaderNodeAttribute")
    colattr.attribute_name = "col"
    if args.no_toon:
        b = N("ShaderNodeBsdfPrincipled")
        b.inputs["Roughness"].default_value = 0.9
        L(colattr.outputs["Color"], b.inputs["Base Color"])
        L(b.outputs["BSDF"], out.inputs["Surface"])
        return m
    diff = N("ShaderNodeBsdfDiffuse")
    diff.inputs["Color"].default_value = (1, 1, 1, 1)
    sf = N("ShaderNodeAttribute")
    sf.attribute_name = "surf"
    sfs = N("ShaderNodeSeparateColor")
    L(sf.outputs["Color"], sfs.inputs["Color"])
    if terrain:
        tcoord = N("ShaderNodeTexCoord")
        mp = N("ShaderNodeMapping")
        mp.inputs["Scale"].default_value = STRATA_SCALE            # strata: thin in z, long in x and y
        L(tcoord.outputs["Object"], mp.inputs["Vector"])
        nz = N("ShaderNodeTexNoise")
        nz.inputs["Scale"].default_value = 1.0
        nz.inputs["Detail"].default_value = 3.0
        nz.inputs["Roughness"].default_value = 0.55
        L(mp.outputs["Vector"], nz.inputs["Vector"])
        bump = N("ShaderNodeBump")
        bump.inputs["Distance"].default_value = 0.03
        bst = N("ShaderNodeMath")
        bst.operation = "MULTIPLY"
        bst.inputs[1].default_value = 0.9
        L(sfs.outputs[1], bst.inputs[0])
        L(bst.outputs["Value"], bump.inputs["Strength"])
        L(nz.outputs["Fac"], bump.inputs["Height"])
        L(bump.outputs["Normal"], diff.inputs["Normal"])
    if terrain or hard:
        # N.L against the one sun, straight from the (bumped) normal. The world light would otherwise lift every face above
        # the terminator, so the terrain does not use the render's diffuse result at all.
        nd = N("ShaderNodeVectorMath")
        nd.operation = "DOT_PRODUCT"
        nd.inputs[1].default_value = tuple(float(v) for v in SUN_TO)
        if terrain:
            L(bump.outputs["Normal"], nd.inputs[0])
        else:
            gn = N("ShaderNodeNewGeometry")
            L(gn.outputs["Normal"], nd.inputs[0])
        lval = nd.outputs["Value"]
    else:
        s2r = N("ShaderNodeShaderToRGB")
        L(diff.outputs["BSDF"], s2r.inputs["Shader"])
        sep = N("ShaderNodeSeparateColor")
        L(s2r.outputs["Color"], sep.inputs["Color"])
        lval = sep.outputs[1]
    mr = N("ShaderNodeMapRange")
    mr.inputs["From Min"].default_value = 0.0
    mr.inputs["From Max"].default_value = 1.0
    mr.clamp = True
    L(lval, mr.inputs["Value"])
    ramp = N("ShaderNodeValToRGB")
    el = ramp.color_ramp.elements
    if hard:
        ramp.color_ramp.interpolation = "LINEAR"
        el[0].position, el[0].color = TERM - 0.03, (*lin(shadow), 1)      # shadow tint 0.58 0.56 0.78 (art_direction.md)
        el[1].position, el[1].color = TERM + 0.03, (*lin(light), 1)      # warm cream light #FFF1D6
    else:
        ramp.color_ramp.interpolation = "EASE"
        el[0].position, el[0].color = 0.22, (*lin(shadow), 1)
        el[1].position, el[1].color = 0.50, (*lin(light), 1)
        mid = el.new(0.36)
        mid.color = (*lin((222, 206, 214)), 1)
    L(mr.outputs["Result"], ramp.inputs["Fac"])
    mul = N("ShaderNodeMix")
    mul.data_type = "RGBA"
    mul.blend_type = "MULTIPLY"
    mul.inputs[0].default_value = 1.0
    L(colattr.outputs["Color"], mul.inputs[6])
    L(ramp.outputs["Color"], mul.inputs[7])
    final = mul.outputs[2]
    if terrain:
        # strata: hard horizontal bands (fract of z plus a slow wobble), a touch darker, on rock only
        zs = N("ShaderNodeSeparateXYZ")
        L(tcoord.outputs["Object"], zs.inputs["Vector"])
        zk = N("ShaderNodeMath")
        zk.operation = "MULTIPLY"
        zk.inputs[1].default_value = 0.55
        L(zs.outputs["Z"], zk.inputs[0])
        zw = N("ShaderNodeMath")
        zw.operation = "MULTIPLY_ADD"
        zw.inputs[1].default_value = 1.1
        L(nz.outputs["Fac"], zw.inputs[0])
        L(zk.outputs["Value"], zw.inputs[2])
        zf = N("ShaderNodeMath")
        zf.operation = "FRACT"
        L(zw.outputs["Value"], zf.inputs[0])
        zg = N("ShaderNodeMath")
        zg.operation = "GREATER_THAN"
        zg.inputs[1].default_value = 0.62
        L(zf.outputs["Value"], zg.inputs[0])
        zr = N("ShaderNodeMath")
        zr.operation = "MULTIPLY"
        L(zg.outputs["Value"], zr.inputs[0])
        L(sfs.outputs[2], zr.inputs[1])
        zd = N("ShaderNodeMath")
        zd.operation = "MULTIPLY_ADD"
        zd.inputs[1].default_value = -0.08
        zd.inputs[2].default_value = 1.0
        L(zr.outputs["Value"], zd.inputs[0])
        smul = N("ShaderNodeMix")
        smul.data_type = "RGBA"
        smul.blend_type = "MULTIPLY"
        smul.inputs[0].default_value = 1.0
        L(final, smul.inputs[6])
        L(zd.outputs["Value"], smul.inputs[7])
        final = smul.outputs[2]
        # cream rim on the lit side of silhouettes (0.22), hard-edged
        lw = N("ShaderNodeLayerWeight")
        lw.inputs["Blend"].default_value = 0.4
        rm = N("ShaderNodeMapRange")
        rm.inputs["From Min"].default_value = 0.62
        rm.inputs["From Max"].default_value = 0.70
        L(lw.outputs["Fresnel"], rm.inputs["Value"])
        litm = N("ShaderNodeMath")
        litm.operation = "GREATER_THAN"
        litm.inputs[1].default_value = TERM
        L(lval, litm.inputs[0])
        rimv = N("ShaderNodeMath")
        rimv.operation = "MULTIPLY"
        L(rm.outputs["Result"], rimv.inputs[0])
        L(litm.outputs["Value"], rimv.inputs[1])
        rim_s = N("ShaderNodeMath")
        rim_s.operation = "MULTIPLY"
        rim_s.inputs[1].default_value = 0.22
        L(rimv.outputs["Value"], rim_s.inputs[0])
        rimc = N("ShaderNodeVectorMath")
        rimc.operation = "SCALE"
        rimc.inputs[0].default_value = tuple(float(v) for v in lin(np.array((255, 244, 214))))
        L(rim_s.outputs["Value"], rimc.inputs["Scale"])
        add1 = N("ShaderNodeMix")
        add1.data_type = "RGBA"
        add1.blend_type = "ADD"
        add1.inputs[0].default_value = 1.0
        L(final, add1.inputs[6])
        L(rimc.outputs["Vector"], add1.inputs[7])
        final = add1.outputs[2]
        # sea sparkle: sparse bright flecks from world-space noise (never tiles); mask from the vertex attribute R
        sp_mp = N("ShaderNodeMapping")
        sp_mp.inputs["Scale"].default_value = (1.7, 1.7, 1.7)
        L(tcoord.outputs["Object"], sp_mp.inputs["Vector"])
        spn = N("ShaderNodeTexNoise")
        spn.inputs["Scale"].default_value = 1.0
        spn.inputs["Detail"].default_value = 1.0
        L(sp_mp.outputs["Vector"], spn.inputs["Vector"])
        spr = N("ShaderNodeMapRange")
        spr.inputs["From Min"].default_value = 0.72
        spr.inputs["From Max"].default_value = 0.745
        L(spn.outputs["Fac"], spr.inputs["Value"])
        spm = N("ShaderNodeMath")
        spm.operation = "MULTIPLY"
        L(spr.outputs["Result"], spm.inputs[0])
        L(sfs.outputs[0], spm.inputs[1])
        sps = N("ShaderNodeMath")
        sps.operation = "MULTIPLY"
        sps.inputs[1].default_value = 0.16
        L(spm.outputs["Value"], sps.inputs[0])
        spc = N("ShaderNodeVectorMath")
        spc.operation = "SCALE"
        spc.inputs[0].default_value = (1.0, 1.0, 1.0)
        L(sps.outputs["Value"], spc.inputs["Scale"])
        add2 = N("ShaderNodeMix")
        add2.data_type = "RGBA"
        add2.blend_type = "ADD"
        add2.inputs[0].default_value = 1.0
        L(final, add2.inputs[6])
        L(spc.outputs["Vector"], add2.inputs[7])
        final = add2.outputs[2]
    emi = N("ShaderNodeEmission")
    L(final, emi.inputs["Color"])
    emi.inputs["Strength"].default_value = 1.0
    if terrain:
        L(emi.outputs["Emission"], out.inputs["Surface"])
        return m
    gl = N("ShaderNodeBsdfGlossy")
    gl.inputs["Roughness"].default_value = 0.22
    gl.inputs["Color"].default_value = (1, 0.97, 0.9, 1)
    glv = N("ShaderNodeMath")
    glv.operation = "MULTIPLY"
    glv.inputs[1].default_value = 0.16
    L(sfs.outputs[0], glv.inputs[0])
    mixs = N("ShaderNodeMixShader")
    L(glv.outputs["Value"], mixs.inputs["Fac"])
    L(emi.outputs["Emission"], mixs.inputs[1])
    L(gl.outputs["BSDF"], mixs.inputs[2])
    L(mixs.outputs["Shader"], out.inputs["Surface"])
    return m


STRATA_SCALE = (1.1, 1.1, 0.9)
MAT = toon_material("DioramaToon")
MAT_T = toon_material("DioramaTerrain", hard=True, terrain=True)
MAT_CLOUD = toon_material("CloudToon", shadow=(168, 182, 226), light=(255, 254, 252), hard=True)


def flat_material(name, rgb):
    m = bpy.data.materials.new(name)
    m.use_nodes = True
    nt = m.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    out = nt.nodes.new("ShaderNodeOutputMaterial")
    em = nt.nodes.new("ShaderNodeEmission")
    em.inputs["Color"].default_value = (*lin(rgb), 1)
    nt.links.new(em.outputs["Emission"], out.inputs["Surface"])
    return m


# -- terrain slab
log("terrain mesh")
xs, ys = np.meshgrid(XN, YN)
V = np.stack([xs, -ys, Z], -1).reshape(-1, 3)
idx = np.arange(NX * NY).reshape(NY, NX)
a_, b_, c_, d_ = idx[:-1, :-1], idx[1:, :-1], idx[1:, 1:], idx[:-1, 1:]
# split each quad on its shorter diagonal-free fixed pattern (alternating) to avoid directional artefacts
flip = ((np.arange(NX - 1)[None, :] + np.arange(NY - 1)[:, None]) % 2).astype(bool)
t1 = np.where(flip[..., None], np.stack([a_, b_, c_], -1), np.stack([a_, b_, d_], -1))
t2 = np.where(flip[..., None], np.stack([a_, c_, d_], -1), np.stack([b_, c_, d_], -1))
TRI = np.concatenate([t1.reshape(-1, 3), t2.reshape(-1, 3)])
terr = mesh_obj("Terrain", V, TRI, col.reshape(-1, 3), smooth_shade=True, coll="Land", mat=MAT_T)
set_gloss(terr, GLOSS.ravel(), ROCKM.ravel(), CLIFFM.ravel())
# skirt (cutaway edge) and plinth
BOT = -1.0
rim = []
for i in range(NX):
    rim.append((i, 0))
for j in range(1, NY):
    rim.append((NX - 1, j))
for i in range(NX - 2, -1, -1):
    rim.append((i, NY - 1))
for j in range(NY - 2, 0, -1):
    rim.append((0, j))
sv, st, sc_ = [], [], []
n_r = len(rim)
for k, (i, j) in enumerate(rim):
    z = Z[j, i]
    sv.append((XN[i], -YN[j], z))
    sc_.append(col[j, i])
    sv.append((XN[i], -YN[j], BOT))
    depth_c = np.array((36, 74, 108)) if SEA[j, i] else np.array((90, 66, 48))
    sc_.append(depth_c)
for k in range(n_r):
    k2 = (k + 1) % n_r
    a0, b0, a1, b1 = 2 * k, 2 * k + 1, 2 * k2, 2 * k2 + 1
    st += [(a0, b0, b1), (a0, b1, a1)]
SKIRT_OBJ = mesh_obj("Skirt", sv, st, np.array(sc_), smooth_shade=False, coll="Land", mat=MAT)


def box(x0, y0, z0, x1, y1, z1, colr):
    vv = [(x0, y0, z0), (x1, y0, z0), (x1, y1, z0), (x0, y1, z0), (x0, y0, z1), (x1, y0, z1), (x1, y1, z1), (x0, y1, z1)]
    tt = [(0, 2, 1), (0, 3, 2), (4, 5, 6), (4, 6, 7), (0, 1, 5), (0, 5, 4), (1, 2, 6), (1, 6, 5), (2, 3, 7), (2, 7, 6), (3, 0, 4), (3, 4, 7)]
    return vv, tt, [colr] * 8


def join_boxes(name, boxes, coll="Land"):
    VV, TT, CC = [], [], []
    for b in boxes:
        v, t, c = box(*b[:6], b[6])
        TT += [(i + len(VV), j + len(VV), k + len(VV)) for i, j, k in t]
        VV += v
        CC += c
    return mesh_obj(name, VV, TT, np.array(CC), coll=coll, mat=MAT)


M = 2.2
WOOD, WOOD2 = (122, 84, 52), (96, 64, 40)
join_boxes("Plinth", [(-M, -EXTY - M, BOT - 0.9, EXTX + M, M, BOT, WOOD),
                      (-M - 0.4, -EXTY - M - 0.4, BOT - 1.5, EXTX + M + 0.4, M + 0.4, BOT - 0.9, WOOD2),
                      (-0.45, -EXTY - 0.45, BOT, 0.0, 0.45, 0.30, WOOD2),                       # raised frame rim
                      (EXTX, -EXTY - 0.45, BOT, EXTX + 0.45, 0.45, 0.30, WOOD2),
                      (0.0, -EXTY - 0.45, BOT, EXTX, -EXTY, 0.30, WOOD2),
                      (0.0, 0.0, BOT, EXTX, 0.45, 0.30, WOOD2)])
tbl = join_boxes("Table", [(-600, -600, BOT - 1.9, 600, 600, BOT - 1.5, (255, 255, 255))])
tbl.data.materials.clear()
tbl.data.materials.append(flat_material("TableMist", (203, 226, 238)))      # blends into the sky horizon
# The slab edge, plinth and table are kept in the file but not rendered: the sea runs on to the horizon (an ocean plane the
# same colour as the deep water, fading to the sky mist), so no skirt or cut edge shows anywhere.
for _o in (SKIRT_OBJ, bpy.data.objects["Plinth"], tbl):
    _o.hide_render = True
    _o.hide_viewport = True
ocean_m = bpy.data.materials.new("OceanFar")
ocean_m.use_nodes = True
_nt = ocean_m.node_tree
for _n in list(_nt.nodes):
    _nt.nodes.remove(_n)
_out, _em, _at = (_nt.nodes.new(t) for t in ("ShaderNodeOutputMaterial", "ShaderNodeEmission", "ShaderNodeAttribute"))
_at.attribute_name = "col"
_nt.links.new(_at.outputs["Color"], _em.inputs["Color"])
_nt.links.new(_em.outputs["Emission"], _out.inputs["Surface"])
_gx = np.unique(np.concatenate([np.linspace(-170, 0, 14), np.linspace(0, EXTX, 11), np.linspace(EXTX, EXTX + 170, 14), [-2500, EXTX + 2500]]))
_gy = np.unique(np.concatenate([np.linspace(-EXTY - 170, -EXTY, 14), np.linspace(-EXTY, 0, 8), np.linspace(0, 170, 14), [-EXTY - 2500, 2500]]))
_OX, _OY = np.meshgrid(_gx, _gy)
_od = np.hypot(np.maximum(0, np.maximum(-_OX, _OX - EXTX)), np.maximum(0, np.maximum(_OY, -EXTY - _OY)))
_oc = mix(np.array((63, 134, 176), dtype=np.float64), np.array((238, 244, 240), dtype=np.float64), smooth(18, 150, _od))   # deep -> haze
_oi = np.arange(_OX.size).reshape(_OX.shape)
_ot = np.concatenate([np.stack([_oi[:-1, :-1], _oi[1:, :-1], _oi[1:, 1:]], -1).reshape(-1, 3),
                      np.stack([_oi[:-1, :-1], _oi[1:, 1:], _oi[:-1, 1:]], -1).reshape(-1, 3)])
OCEAN = mesh_obj("OceanFar", np.stack([_OX.ravel(), _OY.ravel(), np.full(_OX.size, -0.031)], 1), _ot, _oc.reshape(-1, 3), coll="Land", mat=ocean_m)

# -- ribbons (rivers, roads)


def ribbon(pts, widths, lift, colr, floor_z=None):
    """Triangle strip draped on the terrain; pts map km; widths km (scalar or per point)."""
    pts = np.asarray(pts, dtype=np.float64)
    L = len(pts)
    widths = np.broadcast_to(np.asarray(widths, dtype=np.float64), (L,))
    tang = np.zeros_like(pts)
    tang[1:-1] = pts[2:] - pts[:-2]
    tang[0], tang[-1] = pts[1] - pts[0], pts[-1] - pts[-2]
    tn = np.hypot(tang[:, 0], tang[:, 1])[:, None]
    tang = tang / np.maximum(tn, 1e-9)
    nrm = np.stack([-tang[:, 1], tang[:, 0]], 1)
    z = zat(pts[:, 0], pts[:, 1]) + lift + 0.5 * widths * 0.5 * bil(GZ, pts[:, 0], pts[:, 1])
    z = np.maximum(z, 0.004 + lift) if floor_z is None else z
    left, right = pts + nrm * widths[:, None] * 0.5, pts - nrm * widths[:, None] * 0.5
    v = np.empty((2 * L, 3))
    v[0::2] = np.column_stack([left[:, 0], -left[:, 1], z])
    v[1::2] = np.column_stack([right[:, 0], -right[:, 1], z])
    k = np.arange(L - 1) * 2
    t = np.concatenate([np.stack([k, k + 1, k + 3], 1), np.stack([k, k + 3, k + 2], 1)])
    return v, t, np.tile(np.array(colr, dtype=np.float64), (2 * L, 1))


def merge_meshes(parts):
    VV, TT, CC, off = [], [], [], 0
    for v, t, c in parts:
        VV.append(v)
        TT.append(t + off)
        CC.append(c)
        off += len(v)
    return np.concatenate(VV), np.concatenate(TT), np.concatenate(CC)


log("rivers and roads")
parts_bank, parts_water = [], []
for rid, pts, wid in RIVERS:
    pts = [p for p in pts if bil(E, p[0], p[1]) > -1]
    if len(pts) < 3:
        continue
    w = np.clip(0.05 + 0.0034 * np.interp(np.linspace(0, 1, len(pts)), np.linspace(0, 1, len(wid)), wid), 0.055, 0.26)
    parts_bank.append(ribbon(pts, w * 1.7, 0.006, (206, 228, 204)))
    parts_water.append(ribbon(pts, w, 0.013, (72, 150, 196)))
if parts_bank:
    mesh_obj("RiverBanks", *merge_meshes(parts_bank), coll="Land", mat=MAT)
    vv = merge_meshes(parts_water)
    ro = mesh_obj("Rivers", vv[0], vv[1], vv[2], coll="Land", mat=MAT)
    set_gloss(ro, np.full(len(vv[0]), 0.6))
road_edge, road_core = [], []
for rd in D["roads"]:
    pts = densify([(p[0], p[1]) for p in rd["points"]], 0.14)
    stamp(OCC, pts, 0.14, 1.0)
    road_edge.append(ribbon(pts, 0.105, 0.010, (150, 116, 80)))
    road_core.append(ribbon(pts, 0.075, 0.016, (226, 200, 142)))
ve = merge_meshes(road_edge)
mesh_obj("RoadEdge", *ve, coll="Land", mat=MAT)
vc = merge_meshes(road_core)
mesh_obj("Roads", *vc, coll="Land", mat=MAT)


# -- instanced low-poly dressing (templates are unit-height, merged per type)
class Tpl:
    def __init__(self):
        self.V, self.T, self.M = [], [], []

    def add(self, v, t, m):
        o = len(self.V)
        self.V += [tuple(p) for p in v]
        self.T += [(a + o, b + o, c + o) for a, b, c in t]
        self.M += [m] * len(v) if isinstance(m, int) else list(m)

    def frustum(self, c0, c1, r0, r1, sides, m, rot=0.0, cap=True):
        ang = [rot + 2 * math.pi * k / sides for k in range(sides)]
        v = [(c0[0] + r0 * math.cos(a), c0[1] + r0 * math.sin(a), c0[2]) for a in ang]
        v += [(c1[0] + r1 * math.cos(a), c1[1] + r1 * math.sin(a), c1[2]) for a in ang]
        t = []
        for k in range(sides):
            k2 = (k + 1) % sides
            t += [(k, k2, sides + k2), (k, sides + k2, sides + k)]
        if cap:
            v.append(c1)
            t += [(sides + k, sides + (k + 1) % sides, 2 * sides) for k in range(sides)]
        self.add(v, t, m)

    def sphere(self, c, r, segs, rings, sz, mlow, mhigh):
        v, t = [(c[0], c[1], c[2] - r * sz)], []
        for j in range(1, rings):
            ph = math.pi * j / rings
            for k in range(segs):
                a = 2 * math.pi * k / segs + (j % 2) * math.pi / segs
                v.append((c[0] + r * math.sin(ph) * math.cos(a), c[1] + r * math.sin(ph) * math.sin(a), c[2] - r * sz * math.cos(ph)))
        v.append((c[0], c[1], c[2] + r * sz))
        top = len(v) - 1
        for k in range(segs):
            t.append((0, 1 + (k + 1) % segs, 1 + k))
        for j in range(rings - 2):
            for k in range(segs):
                a0, a1 = 1 + j * segs + k, 1 + j * segs + (k + 1) % segs
                b0, b1 = a0 + segs, a1 + segs
                t += [(a0, a1, b1), (a0, b1, b0)]
        for k in range(segs):
            t.append((top, top - segs + k, top - segs + (k + 1) % segs))
        self.add(v, t, [mlow if p[2] < c[2] else mhigh for p in v])

    def tri(self, a, b, c, m):
        self.add([a, b, c], [(0, 1, 2), (0, 2, 1)], m)

    def arrays(self):
        return np.array(self.V), np.array(self.T, dtype=np.int64), np.array(self.M, dtype=np.int64)


def tpl_conifer():
    t = Tpl()
    t.frustum((0, 0, 0), (0, 0, 0.25), 0.05, 0.04, 4, 0, cap=False)
    t.frustum((0, 0, 0.15), (0, 0, 0.62), 0.30, 0.0, 6, 1, cap=False)
    t.frustum((0, 0, 0.38), (0, 0, 0.84), 0.23, 0.0, 6, 2, rot=0.5, cap=False)
    t.frustum((0, 0, 0.62), (0, 0, 1.0), 0.15, 0.0, 6, 1, cap=False)
    return t.arrays()


def tpl_broad():
    t = Tpl()
    t.frustum((0, 0, 0), (0, 0, 0.42), 0.06, 0.045, 4, 0, cap=False)
    t.sphere((0, 0, 0.66), 0.30, 6, 4, 1.0, 1, 2)
    t.sphere((0.14, 0.08, 0.50), 0.18, 5, 3, 0.9, 1, 2)
    return t.arrays()


def tpl_palm():
    t = Tpl()
    top = (0.12, 0, 0.74)
    t.frustum((0, 0, 0), top, 0.05, 0.035, 4, 0, cap=False)
    for k in range(6):
        a = k * math.pi / 3 + 0.2
        c, s = math.cos(a), math.sin(a)
        tip = (top[0] + c * 0.40, top[1] + s * 0.40, top[2] - 0.12)
        l_ = (top[0] + c * 0.18 - s * 0.09, top[1] + s * 0.18 + c * 0.09, top[2] + 0.07)
        r_ = (top[0] + c * 0.18 + s * 0.09, top[1] + s * 0.18 - c * 0.09, top[2] + 0.07)
        t.add([top, l_, tip, r_], [(0, 1, 2), (0, 2, 3), (0, 2, 1), (0, 3, 2)], 1 if k % 2 else 2)
    return t.arrays()


def tpl_dead():
    t = Tpl()
    t.frustum((0, 0, 0), (0, 0, 0.85), 0.06, 0.018, 4, 0)
    for z0, a in ((0.35, 0.3), (0.5, 2.4), (0.62, 4.4)):
        c, s = math.cos(a), math.sin(a)
        t.frustum((0, 0, z0), (c * 0.28, s * 0.28, z0 + 0.22), 0.035, 0.008, 3, 2)
    return t.arrays()


TPLS = [tpl_conifer(), tpl_broad(), tpl_palm(), tpl_dead()]


def build_instances(name, tpl, inst, coll="Dressing"):
    """inst: dict with arrays x, y (map), z, yaw, sx (horizontal scale), sz (vertical), pal (n,3,3 colours), bright."""
    v0, t0, m0 = tpl
    n = len(inst["x"])
    if n == 0:
        return None
    c, s = np.cos(inst["yaw"]), np.sin(inst["yaw"])
    vx = v0[None, :, 0] * inst["sx"][:, None]
    vy = v0[None, :, 1] * inst["sx"][:, None]
    VX = vx * c[:, None] - vy * s[:, None] + inst["x"][:, None]
    VY = vx * s[:, None] + vy * c[:, None] + inst["y"][:, None]
    VZ = v0[None, :, 2] * inst["sz"][:, None] + inst["z"][:, None]
    V = np.stack([VX, -VY, VZ], -1).reshape(-1, 3)
    T = (t0[None, :, :] + (np.arange(n) * len(v0))[:, None, None]).reshape(-1, 3)
    C = inst["pal"][np.arange(n)[:, None], m0[None, :]] * inst["bright"][:, None, None]
    return mesh_obj(name, V, T, np.clip(C.reshape(-1, 3), 0, 255), coll=coll, mat=MAT)


log("trees")
TREE_OBJS, LOD_OBJS = [], []
tr = TREES
tz = zat(tr["x"], tr["y"]) - 0.01
for ti, tname in enumerate(("Conifers", "Broadleaf", "Palms", "Dead")):
    sel = np.nonzero(tr["t"] == ti)[0]
    if not len(sel):
        continue
    pal = np.array([PALS[tr["pal"][i]] for i in sel], dtype=np.float64)
    TREE_OBJS.append(build_instances(tname, TPLS[ti], dict(x=tr["x"][sel], y=tr["y"][sel], z=tz[sel], yaw=tr["yaw"][sel],
                                                            sx=tr["h"][sel] * (0.9 if ti != 0 else 0.8), sz=tr["h"][sel], pal=pal,
                                                            bright=tr["bright"][sel])))
    # Forest LOD for the continent view: every third tree, drawn 2.2x larger with stronger light/dark contrast, so a big forest
    # reads as readable trees and not a green smear. Same placement data (a deterministic subsample), one more mesh per type.
    k3 = np.arange(len(sel)) % 3 == 0
    lb = np.where(np.arange(len(sel)) % 2 == 0, 1.12, 0.84)[k3]
    LOD_OBJS.append(build_instances("LOD_" + tname, TPLS[ti], dict(x=tr["x"][sel][k3], y=tr["y"][sel][k3], z=tz[sel][k3], yaw=tr["yaw"][sel][k3],
                                                                  sx=tr["h"][sel][k3] * (0.9 if ti != 0 else 0.8) * 2.2, sz=tr["h"][sel][k3] * 2.2,
                                                                  pal=pal[k3], bright=tr["bright"][sel][k3] * lb)))

# houses
FAM = {
    "storybook": ((237, 219, 178), [(51, 107, 184), (204, 76, 46), (70, 120, 80), (76, 92, 117)]),
    "desert": ((224, 184, 133), [(196, 146, 98), (36, 140, 168), (214, 168, 112)]),
    "north": ((102, 69, 46), [(240, 245, 255), (92, 122, 66), (226, 232, 244)]),
    "east": ((242, 237, 224), [(61, 71, 87), (46, 117, 87), (148, 51, 36)]),
    "dwarf": ((98, 94, 104), [(184, 115, 51), (69, 66, 74), (158, 71, 51)]),
    "lagoon": ((237, 168, 153), [(194, 97, 56), (194, 97, 56), (92, 143, 178)]),
    "coast": ((235, 235, 224), [(92, 143, 178), (217, 76, 51), (92, 143, 178)]),
    "ashlar": ((230, 224, 209), [(76, 92, 117), (76, 92, 117), (51, 87, 173)]),
    "jungle": ((194, 178, 143), [(178, 143, 76), (178, 143, 76), (26, 158, 153)]),
    "dark": ((76, 69, 87), [(61, 51, 76), (61, 51, 76), (150, 80, 70)]),
}
FAMOF = {}
for k, regs in {"desert": ("sunscar", "zaruma", "zarvan", "dunewhale_drift", "apu_highlands"),
                "north": ("frostveil", "whitewater_reach"),
                "east": ("hoshizora", "kitsune_isles", "shen_lu", "haneul"),
                "dwarf": ("iron_hold", "dragon_spine", "gearholm", "cinderhole"),
                "lagoon": ("lirian",), "coast": ("goldmere_coast", "true_name_isles", "lustrine_shores"),
                "ashlar": ("velmark", "vharlen", "stormreach", "bastion"),
                "jungle": ("xochitl_mire", "lumbaya"), "dark": ("nox_dominion", "everdusk")}.items():
    for r in regs:
        FAMOF["reg_" + r] = k


def tpl_house():
    t = Tpl()
    w, d, h = 1.0, 0.72, 0.5
    v = [(-w / 2, -d / 2, 0), (w / 2, -d / 2, 0), (w / 2, d / 2, 0), (-w / 2, d / 2, 0),
         (-w / 2, -d / 2, h), (w / 2, -d / 2, h), (w / 2, d / 2, h), (-w / 2, d / 2, h)]
    t.add(v, [(0, 1, 5), (0, 5, 4), (1, 2, 6), (1, 6, 5), (2, 3, 7), (2, 7, 6), (3, 0, 4), (3, 4, 7)], 0)
    ov = 0.07
    rv = [(-w / 2 - ov, -d / 2 - ov, h), (w / 2 + ov, -d / 2 - ov, h), (w / 2 + ov, d / 2 + ov, h), (-w / 2 - ov, d / 2 + ov, h),
          (-w / 2 - ov, 0, h + 0.46), (w / 2 + ov, 0, h + 0.46)]
    t.add(rv, [(0, 1, 5), (0, 5, 4), (3, 4, 5), (3, 5, 2), (0, 4, 3), (1, 2, 5), (0, 3, 4), (1, 5, 2), (0, 5, 1), (3, 5, 4), (3, 2, 5), (0, 4, 3)], 1)
    t.frustum((0.28, 0.1, h + 0.08), (0.28, 0.1, h + 0.40), 0.07, 0.06, 4, 2, rot=0.78)
    return t.arrays()


def tpl_keep():
    t = Tpl()
    t.frustum((0, 0, 0), (0, 0, 0.75), 0.42, 0.40, 8, 0, rot=0.39, cap=False)
    t.frustum((0, 0, 0.75), (0, 0, 1.05), 0.48, 0.48, 8, 2, rot=0.39)
    t.frustum((0, 0, 1.05), (0, 0, 1.75), 0.50, 0.0, 8, 1, rot=0.39, cap=False)
    for k in range(4):
        a = k * math.pi / 2 + math.pi / 4
        cx, cy = 0.62 * math.cos(a), 0.62 * math.sin(a)
        t.frustum((cx, cy, 0), (cx, cy, 0.55), 0.17, 0.16, 6, 0, cap=False)
        t.frustum((cx, cy, 0.55), (cx, cy, 0.95), 0.2, 0.0, 6, 1, cap=False)
    return t.arrays()


def tpl_wall():
    t = Tpl()
    v, tt, _ = box(-0.5, -0.5, 0, 0.5, 0.5, 1.0, 0)
    t.add(v, tt, 0)
    return t.arrays()


log("houses")
HPLACED = []
ALD_RING = []
for hd in HOUSES:
    if "pts" not in hd or not hd["pts"]:
        continue
    s = hd["s"]
    wall, roofs = FAM[FAMOF.get(s["region"], "storybook")]
    if s["id"] == "brindlewick":
        roofs = [(214, 84, 52), (232, 120, 60), (204, 64, 44)]
    if s["id"] == "aldmere":
        roofs = [(51, 87, 173), (51, 87, 173), (76, 92, 117)]
    for (x, y, yaw, w, rk, wk) in hd["pts"]:
        wc = np.array(wall, dtype=np.float64) * (0.94 + 0.06 * wk)
        HPLACED.append((x, y, yaw, w, np.array([wc, np.array(roofs[rk % len(roofs)], dtype=np.float64), (150, 140, 130)]), s["id"]))
if HPLACED:
    n = len(HPLACED)
    hx = np.array([h[0] for h in HPLACED])
    hy = np.array([h[1] for h in HPLACED])
    hz = zat(hx, hy) - 0.012
    inst = dict(x=hx, y=hy, z=hz, yaw=np.array([h[2] for h in HPLACED]), sx=np.array([h[3] for h in HPLACED]),
                sz=np.array([h[3] for h in HPLACED]), pal=np.array([h[4] for h in HPLACED]), bright=np.ones(n))
    build_instances("Houses", tpl_house(), inst)
# Aldmere keep and wall ring, Brindlewick hall
for sid, kw in (("aldmere", 0.42), ("brindlewick", 0.26)):
    s = SETD[sid]
    kp = dict(x=np.array([s["x"]]), y=np.array([s["y"]]), z=np.array([float(zat(s["x"], s["y"])) - 0.01]), yaw=np.array([0.3]),
              sx=np.array([kw]), sz=np.array([kw]), bright=np.ones(1))
    if sid == "aldmere":
        kp["pal"] = np.array([[[226, 220, 205], [51, 87, 173], [219, 168, 51]]], dtype=np.float64)
        build_instances("AldmereKeep", tpl_keep(), kp)
        r = cluster_radius(s) * 1.12
        segs = 28
        wx = np.array([s["x"] + r * math.cos(2 * math.pi * k / segs) for k in range(segs)])
        wy = np.array([s["y"] + r * math.sin(2 * math.pi * k / segs) for k in range(segs)])
        wz = zat(wx, wy) - 0.012
        seg_len = 2 * math.pi * r / segs
        T_ = tpl_wall()
        # stretch each wall block tangentially: use the box x axis, yaw along the tangent
        build_instances("AldmereWall", T_, dict(x=wx, y=wy, z=wz, yaw=np.array([2 * math.pi * k / segs + math.pi / 2 for k in range(segs)]),
                                               sx=np.full(segs, seg_len * 1.02), sz=np.full(segs, 0.16),
                                               pal=np.tile(np.array([[[176, 164, 138], [176, 164, 138], [176, 164, 138]]], dtype=np.float64), (segs, 1, 1)),
                                               bright=np.ones(segs)))
        # towers on the wall: reuse small keeps
        tx, ty = wx[::4], wy[::4]
        build_instances("AldmereTowers", tpl_keep(), dict(x=tx, y=ty, z=zat(tx, ty) - 0.01, yaw=np.zeros(len(tx)),
                                                          sx=np.full(len(tx), 0.12), sz=np.full(len(tx), 0.12),
                                                          pal=np.tile(np.array([[[226, 220, 205], [51, 87, 173], [219, 168, 51]]], dtype=np.float64), (len(tx), 1, 1)),
                                                          bright=np.ones(len(tx))))
    else:
        kp["pal"] = np.array([[[237, 219, 178], [204, 64, 44], [150, 140, 130]]], dtype=np.float64)
        build_instances("BrindlewickHall", tpl_house(), dict(kp, sx=np.array([0.30]), sz=np.array([0.40])))

# clouds
log("clouds")


def tpl_puff():
    """A cumulus lump: round on top, flat-ish underside (so it reads as a cloud, not a flat disc)."""
    t = Tpl()
    t.sphere((0, 0, 0), 1.0, 16, 9, 0.85, 0, 0)
    V, T, M = t.arrays()
    V = V.copy()
    V[:, 2] = np.maximum(V[:, 2], -0.42)
    return V, T, M


PUFF = tpl_puff()


def cumulus(rs, cx, cy, cz, width, nl=7, axis=None):
    """One cumulus cluster as lump lists (x, y, z, sx, sz, yaw). Base row of lumps with taller lumps stacked on top."""
    ax = rs.random() * 2 * math.pi if axis is None else axis
    out = []
    for k in range(nl):
        u = (k / (nl - 1) - 0.5) * 2 if nl > 1 else 0.0
        top = k % 3 == 1
        rad = width * (0.20 + 0.16 * (1 - abs(u))) * (0.8 + 0.4 * rs.random()) * (1.0 if not top else 0.82)
        off = u * width * 0.5
        out.append((cx + off * math.cos(ax), cy + off * math.sin(ax),
                    cz + (rad * 0.55 if top else 0.0) + 0.35 * rad * (1 - abs(u)), rad * 1.15, rad, rs.random() * 6.28))
    return out


cl_l = []
cr = np.random.default_rng(args.seed + 99)
for c in CLOUDS:
    cl_l += cumulus(cr, c["x"], c["y"], c["z"] + 1.0, c["r"] * 1.5, nl=5)       # lifted clear of the peaks (placement already clears the highest ground nearby)
CLOUD_OBJ = None
if cl_l:
    A = np.array(cl_l)
    n = len(A)
    CLOUD_OBJ = build_instances("Clouds", PUFF, dict(x=A[:, 0], y=A[:, 1], z=A[:, 2], yaw=A[:, 5], sx=A[:, 3], sz=A[:, 4],
                                                     pal=np.tile(np.array([[[250, 252, 255]] * 3], dtype=np.float64), (n, 1, 1)),
                                                     bright=np.ones(n)), coll="Sky")
    CLOUD_OBJ.data.materials.clear()
    CLOUD_OBJ.data.materials.append(MAT_CLOUD)
    for p_ in CLOUD_OBJ.data.polygons:
        p_.use_smooth = True

# world + sun
w = bpy.data.worlds.new("DioramaSky")
w.use_nodes = True
nt = w.node_tree
for n in list(nt.nodes):
    nt.nodes.remove(n)
tc, sep, ramp, bg, wo = (nt.nodes.new(t) for t in ("ShaderNodeTexCoord", "ShaderNodeSeparateXYZ", "ShaderNodeValToRGB", "ShaderNodeBackground", "ShaderNodeOutputWorld"))
# painted gradient fixed to the frame (Window y); shoot() slides its stops so the haze sits on the horizon of each shot
nt.links.new(tc.outputs["Window"], sep.inputs["Vector"])
nt.links.new(sep.outputs["Y"], ramp.inputs["Fac"])
SKY_RAMP = ramp
_el = ramp.color_ramp.elements
_el[0].position, _el[0].color = 0.0, (*lin((238, 244, 240)), 1)              # horizon haze, a touch warm
_el[1].position, _el[1].color = 0.62, (*lin((84, 150, 226)), 1)              # zenith
_m1 = _el.new(0.10)
_m1.color = (*lin((182, 222, 242)), 1)
_m2 = _el.new(0.30)
_m2.color = (*lin((126, 186, 236)), 1)
nt.links.new(ramp.outputs["Color"], bg.inputs["Color"])
bg.inputs["Strength"].default_value = 1.0
nt.links.new(bg.outputs["Background"], wo.inputs["Surface"])
sc.world = w
sun = bpy.data.objects.new("Sun", bpy.data.lights.new("Sun", "SUN"))
sc.collection.objects.link(sun)
sun.data.energy = 1.0
sun.data.color = (1.0, 0.96, 0.88)
sun.data.angle = math.radians(5)
to_ground = Vector((1.0, -1.0, -1.1)).normalized()      # light travels from the north-west
sun.rotation_euler = to_ground.to_track_quat("-Z", "Y").to_euler()
try:
    sc.eevee.use_shadows = True
    sc.eevee.shadow_ray_count = 2
    sc.eevee.shadow_step_count = 6
except AttributeError:
    pass

if args.outline:
    sc.render.use_freestyle = True
    vl = bpy.context.view_layer
    vl.use_freestyle = True
    sc.render.line_thickness_mode = "ABSOLUTE"
    sc.render.line_thickness = 0.8 * RES[1] / 1080
    ls = vl.freestyle_settings.linesets.new("InkDressing")
    ls.select_by_visibility = True
    ls.select_by_collection = True
    ls.collection = COLL["Dressing"]
    ls.select_silhouette, ls.select_border, ls.select_crease = True, False, False
    ls.linestyle.color = (0.16, 0.11, 0.09)
    ls.linestyle.thickness = 1.0

# ---------------------------------------------------------------------------------------------------------------
# Labels and cartouche (camera overlay)
INK = flat_material("Ink", (58, 42, 28))                      # #3A2A1C
PARCH = flat_material("Parchment", (243, 230, 200))          # #F3E6C8
PARCH2 = flat_material("ParchmentDark", (214, 193, 150))
BORDER = flat_material("Border", (92, 62, 38))
GOLD = flat_material("Gold", (196, 150, 52))


def quad(name, mat, coll="Overlay"):
    o = mesh_obj(name, [(-.5, -.5, 0), (.5, -.5, 0), (.5, .5, 0), (-.5, .5, 0)], [(0, 1, 2), (0, 2, 3)], None, coll=coll, mat=mat)
    return o


def ovl_setup(cam):
    from bpy_extras.object_utils import world_to_camera_view  # noqa: F401
    bpy.context.view_layer.update()
    vf = cam.data.view_frame(scene=sc)
    dist = 1.0
    fr = [v * (dist / -vf[0].z) for v in vf]
    fw, fh = fr[0].x - fr[2].x, fr[0].y - fr[2].y
    return dist, fw, fh, fh / RES[1]


class Overlay:
    def __init__(self, cam):
        self.cam = cam
        self.dist, self.fw, self.fh, self.unit = ovl_setup(cam)
        self.made = []
        self.boxes = []
        self.anchors = []
        self.mcache = {}

    def place(self, o, x, y, depth, ang=0.0):
        lx, ly = (x / RES[0] - 0.5) * self.fw, (y / RES[1] - 0.5) * self.fh
        o.location = self.cam.matrix_world @ Vector((lx, ly, -self.dist * depth))
        if ang:
            from mathutils import Quaternion
            o.rotation_mode = "QUATERNION"
            o.rotation_quaternion = self.cam.rotation_euler.to_quaternion() @ Quaternion((0, 0, 1), ang)
        else:
            o.rotation_euler = self.cam.rotation_euler
        for a in ("visible_shadow",):
            if hasattr(o, a):
                setattr(o, a, False)

    def rect(self, name, mat, x, y, w, h, depth, ang=0.0):
        o = quad(name, mat)
        o.scale = (w * self.unit, h * self.unit, 1)
        self.place(o, x, y, depth, ang)
        self.made.append(o)

    def line(self, x0, y0, x1, y1, th, mat, depth):
        ln = math.hypot(x1 - x0, y1 - y0)
        if ln < 1:
            return
        self.rect("LL", mat, (x0 + x1) / 2, (y0 + y1) / 2, ln, th, depth, math.atan2(y1 - y0, x1 - x0))

    def text(self, s, x, y, px, mat, depth, bold=False):
        cu = bpy.data.curves.new("T_" + s, "FONT")
        cu.body = s
        cu.size = px * self.unit * 1.35
        cu.align_x, cu.align_y = "CENTER", "CENTER"
        o = bpy.data.objects.new("T_" + s, cu)
        COLL["Overlay"].objects.link(o)
        o.data.materials.append(mat)
        self.place(o, x, y, depth)
        self.made.append(o)
        bpy.context.view_layer.update()
        return o.dimensions.x / self.unit

    def measure(self, s, px):
        key = (s, round(px, 2))
        if key not in self.mcache:
            tmp = bpy.data.curves.new("m", "FONT")
            tmp.body, tmp.size = s, px * self.unit * 1.35
            to = bpy.data.objects.new("m", tmp)
            COLL["Overlay"].objects.link(to)
            bpy.context.view_layer.update()
            self.mcache[key] = to.dimensions.x / self.unit
            bpy.data.objects.remove(to)
            bpy.data.curves.remove(tmp)
        return self.mcache[key]

    def label(self, s, at, px):
        """Parchment plate (ink #3A2A1C on #F3E6C8) with a short leader line to the anchor. Greedy auto-nudge: tries a ring of
        offsets round the anchor and keeps the first plate that overlaps no earlier plate, the cartouche or the frame edge."""
        from bpy_extras.object_utils import world_to_camera_view
        u = world_to_camera_view(sc, self.cam, Vector(at))
        if u.z <= 0 or not (0.02 < u.x < 0.98 and 0.03 < u.y < 0.97):
            return False
        tw = self.measure(s, px) + 18
        th = px * 1.8
        ax, ay = u.x * RES[0], u.y * RES[1]
        g = 4
        cands = []
        for k, lift in enumerate((th * 0.75 + 8, th * 1.55 + 12, th * 2.35 + 18, th * 3.2 + 24, th * 4.2 + 30)):
            for dx in (0, -0.62, 0.62, -1.2, 1.2):
                cands.append((dx * tw, lift))
            if k == 0:
                cands += [(tw * 0.62 + 10, 0.0), (-tw * 0.62 - 10, 0.0), (0.0, -(th * 0.75 + 8))]
        pick = None
        for dx, dy in cands:
            x, y = ax + dx, ay + dy
            b = (x - tw / 2 - g, y - th / 2 - g, x + tw / 2 + g, y + th / 2 + g)
            if b[0] < 6 or b[2] > RES[0] - 6 or b[1] < 6 or b[3] > RES[1] - 6:
                continue
            if any(b[0] < q[2] and b[2] > q[0] and b[1] < q[3] and b[3] > q[1] for q in self.boxes):
                continue
            pick = (x, y, b)
            break
        if pick is None:
            return False
        x, y, b = pick
        self.boxes.append(b)
        self.anchors.append((ax, ay))
        # leader: from the plate edge to the summit / town, with a small ink diamond on the anchor
        ex = min(max(ax, x - tw / 2 + 6), x + tw / 2 - 6)
        ey = y - th / 2 if ay < y else y + th / 2
        if math.hypot(ax - ex, ay - ey) > 5:
            self.line(ex, ey, ax, ay, 2.0, INK, 1.0004)
        self.rect("LA", INK, ax, ay, 7, 7, 1.0003, math.pi / 4)
        self.rect("LB_" + s, BORDER, x, y, tw + 5, th + 5, 1.0)
        self.rect("LC_" + s, PARCH, x, y, tw, th, 0.9995)
        self.text(s, x, y - th * 0.03, px, INK, 0.999)
        return True

    def cartouche(self, title, sub, x, y, w, h):
        self.boxes.append((x - w / 2 - 12, y - h / 2 - 12, x + w / 2 + 12, y + h / 2 + 12))
        self.rect("CB1", BORDER, x, y, w + 16, h + 16, 1.0)
        self.rect("CB2", GOLD, x, y, w + 8, h + 8, 0.9998)
        self.rect("CC", PARCH, x, y, w, h, 0.9996)
        self.rect("CB3", PARCH2, x, y, w - 18, h - 18, 0.9994)
        self.rect("CC2", PARCH, x, y, w - 23, h - 23, 0.9992)
        for sx_, sy_ in ((-1, -1), (1, -1), (-1, 1), (1, 1)):
            self.rect("CD", GOLD, x + sx_ * (w / 2 - 12), y + sy_ * (h / 2 - 12), 11, 11, 0.9990)
        self.text(title, x, y + h * 0.13, h * 0.36, INK, 0.9990)
        # ornament: gold rule with a diamond and two dots
        ry = y - h * 0.16
        self.rect("CL1", GOLD, x - w * 0.19, ry, w * 0.26, 2.5, 0.9990)
        self.rect("CL2", GOLD, x + w * 0.19, ry, w * 0.26, 2.5, 0.9990)
        self.rect("CO", GOLD, x, ry, 13, 13, 0.9989, math.pi / 4)
        self.rect("CO2", BORDER, x, ry, 5, 5, 0.9988, math.pi / 4)
        for sx_ in (-1, 1):
            self.rect("CO3", GOLD, x + sx_ * w * 0.345, ry, 6, 6, 0.9990, math.pi / 4)
        self.text(sub, x, y - h * 0.31, h * 0.15, INK, 0.9990)

    def clear(self):
        for o in self.made:
            d = o.data
            bpy.data.objects.remove(o)
            if d and d.users == 0:
                (bpy.data.curves if isinstance(d, bpy.types.TextCurve) else bpy.data.meshes).remove(d)
        self.made = []


def region_info(rid):
    k = LEGEND.index(rid)
    js, is_ = np.nonzero(region == k)
    if not len(js):
        return None
    return ((is_.mean() + 0.5) * CK, (js.mean() + 0.5) * CK)


def anchor(xm, ym, lift=0.25):
    return (xm, -ym, float(zat(xm, ym)) + lift)


def sky_cumulus(cam, yaw, pitch, lens):
    """Stylised cumulus banks painted into the sky behind the range (spine view). Own seeded rng: placement hash unaffected."""
    rs = np.random.default_rng(args.seed + 555)
    fwd = np.array((-math.sin(math.radians(yaw)), math.cos(math.radians(yaw))))            # blender x, y
    right = np.array((math.cos(math.radians(yaw)), math.sin(math.radians(yaw))))
    camp = np.array((cam.location.x, cam.location.y))
    lumps = []
    for k in range(13):
        dist = 95 + 90 * rs.random()
        lat = (rs.random() - 0.5) * dist * 1.25
        elev = math.radians(0.8 + 0.5 * (pitch * 0 + 14.0) * rs.random())
        p2 = camp + fwd * dist + right * lat
        z = cam.location.z + dist * math.tan(elev)
        wid = 5.5 + 6.0 * rs.random()
        for lp in cumulus(rs, p2[0], -p2[1], z, wid * 1.5, nl=7, axis=math.atan2(-right[1], right[0])):
            lumps.append(lp)
    A = np.array(lumps)
    n = len(A)
    o = build_instances("SkyCumulus", PUFF, dict(x=A[:, 0], y=A[:, 1], z=A[:, 2], yaw=A[:, 5], sx=A[:, 3], sz=A[:, 4],
                                                 pal=np.tile(np.array([[[250, 252, 255]] * 3], dtype=np.float64), (n, 1, 1)),
                                                 bright=np.ones(n)), coll="Sky")
    o.data.materials.clear()
    o.data.materials.append(MAT_CLOUD)
    for p_ in o.data.polygons:
        p_.use_smooth = True
    return o


def far_isles(cam, yaw):
    """Spine view only: a few low conical islands and a flat sea-fog band far behind the range (own rng, no placement effect)."""
    rs = np.random.default_rng(args.seed + 777)
    fwd = np.array((-math.sin(math.radians(yaw)), math.cos(math.radians(yaw))))
    right = np.array((math.cos(math.radians(yaw)), math.sin(math.radians(yaw))))
    camp = np.array((cam.location.x, cam.location.y))
    made = []
    for k in range(3):
        dist = 165 + 85 * rs.random()
        p2 = camp + fwd * dist + right * ((rs.random() - 0.5) * 300 * (0.6 + 0.4 * k / 2))
        rx, ry = 6 + 12 * rs.random(), 4 + 8 * rs.random()
        hh, n = 1.4 + 2.8 * rs.random(), 28
        hz = float(smooth(160, 260, dist))                         # hazier with distance
        mixh = lambda c_: tuple(np.array(c_, dtype=np.float64) * (1 - 0.55 * hz) + np.array((205, 224, 238)) * 0.55 * hz)
        rot = rs.random() * 6.28
        rj = [1 + 0.30 * (rs.random() - 0.5) * 2 for _ in range(n)]
        V = [(p2[0] + 0.12 * rx * (rs.random() - 0.5), p2[1] + 0.12 * ry * (rs.random() - 0.5), hh)]
        C = [mixh((226, 228, 232))]
        T = []
        for ring, (rf, zf, cc) in enumerate(((0.45, 0.60, (150, 140, 150)), (0.85, 0.24, (104, 148, 100)), (1.25, -0.03, (118, 188, 138)))):
            for i in range(n):
                a = 2 * math.pi * i / n
                lx, ly = r_ = rx * rf * rj[i] * math.cos(a), ry * rf * rj[i] * math.sin(a)
                V.append((p2[0] + lx * math.cos(rot) - ly * math.sin(rot), p2[1] + lx * math.sin(rot) + ly * math.cos(rot),
                          hh * zf if zf > 0 else -0.03))
                C.append(mixh(cc))
        for ring in range(3):
            for i in range(n):
                i2 = (i + 1) % n
                if ring == 0:
                    T.append((0, 1 + i, 1 + i2))
                else:
                    a0, a1, b0, b1 = 1 + (ring - 1) * n + i, 1 + (ring - 1) * n + i2, 1 + ring * n + i, 1 + ring * n + i2
                    T += [(a0, b0, b1), (a0, b1, a1)]
        o = mesh_obj("FarIsle%d" % k, V, T, np.array(C, dtype=np.float64), smooth_shade=True, coll="Sky", mat=MAT)
        made.append(o)
    lumps = []
    for k in range(0):          # sea-fog lumps read as flat ice floes; islands alone carry the depth
        dist = 125 + 80 * rs.random()
        p2 = camp + fwd * dist + right * ((rs.random() - 0.5) * dist * 1.1)
        lumps.append((p2[0], -p2[1], 0.1 + 0.15 * rs.random(), 9 + 9 * rs.random(), 0.22 + 0.18 * rs.random(), math.atan2(-right[1], right[0])))
    if not lumps:
        return made
    A = np.array(lumps)
    n_ = len(A)
    fog = build_instances("SeaFog", PUFF, dict(x=A[:, 0], y=A[:, 1], z=A[:, 2], yaw=A[:, 5], sx=A[:, 3], sz=A[:, 4],
                                               pal=np.tile(np.array([[[208, 228, 242]] * 3], dtype=np.float64), (n_, 1, 1)),
                                               bright=np.ones(n_)), coll="Sky")
    fog.data.materials.clear()
    fog.data.materials.append(MAT_CLOUD)
    made.append(fog)
    return made


def shoot(name, target_map, dist, yaw, pitch, lens, sub, labels, lsize, clouds=True, aim_lift=0.0, lod=False, sky=False):
    cam = bpy.data.objects.get("Cam") or bpy.data.objects.new("Cam", bpy.data.cameras.new("Cam"))
    if cam.name not in sc.collection.objects:
        sc.collection.objects.link(cam)
    tz_ = float(zat(*target_map)) + aim_lift
    tgt = Vector((target_map[0], -target_map[1], tz_))
    d = Vector((math.sin(math.radians(yaw)) * math.cos(math.radians(pitch)), -math.cos(math.radians(yaw)) * math.cos(math.radians(pitch)),
                math.sin(math.radians(pitch))))
    cam.location = tgt + d * dist
    cam.rotation_euler = (-d).to_track_quat("-Z", "Y").to_euler()
    cam.data.lens = lens
    cam.data.clip_start, cam.data.clip_end = 0.05, 3000
    sc.camera = cam
    sc.render.resolution_x, sc.render.resolution_y = RES
    sc.render.resolution_percentage = 100
    if CLOUD_OBJ:
        CLOUD_OBJ.hide_render = not clouds
    for o in TREE_OBJS:
        o.hide_render = lod
    for o in LOD_OBJS:
        o.hide_render = not lod
    yh = min(0.97, 0.5 + math.tan(math.radians(pitch)) * lens / (36.0 * RES[1] / RES[0]))      # horizon height in the frame
    sp_ = 1.0 - yh
    ee = SKY_RAMP.color_ramp.elements
    for k_, pos_ in ((3, 1.0), (2, yh + 0.62 * sp_), (1, yh + 0.30 * sp_), (0, yh)):
        ee[k_].position = pos_
    bpy.context.view_layer.update()
    skyo = sky_cumulus(cam, yaw, pitch, lens) if sky else None
    far = far_isles(cam, yaw) if sky else []
    ov = Overlay(cam)
    if not args.no_labels:
        cw, ch = RES[0] * 0.185, RES[1] * 0.125
        ov.cartouche("AETHERIA", sub, 24 + 8 + cw / 2, RES[1] - 24 - 8 - ch / 2, cw, ch)
        for text, at in labels:
            ov.label(text, at, lsize)
    sc.render.image_settings.file_format = "PNG"
    sc.eevee.taa_render_samples = args.samples
    sc.render.filepath = os.path.join(OUT, name)
    os.makedirs(OUT, exist_ok=True)
    t = time.time()
    bpy.ops.render.render(write_still=True)
    log("RENDER %s %.1fs (%d overlay items)" % (sc.render.filepath, time.time() - t, len(ov.made)))
    ov.clear()
    for o_ in far:
        me_ = o_.data
        bpy.data.objects.remove(o_)
        bpy.data.meshes.remove(me_)
    if skyo:
        me = skyo.data
        bpy.data.objects.remove(skyo)
        bpy.data.meshes.remove(me)


RIDS = list(LEGEND)
only = [s.strip() for s in args.only.split(",") if s.strip()]
ald, brn = SETD["aldmere"], SETD["brindlewick"]
if "continent" in only:
    labs = []
    for r in RIDS:
        c = region_info(r)
        if c:
            labs.append((RNAME.get(r, r), anchor(c[0], c[1], 0.5)))
    shoot("diorama_continent.png", (75.0, 50.0), 150.0, -10.0, 49.0, 35.0, "The Continent", labs, 16 * RES[1] / 1080, True, lod=True)
if "heartland" in only:
    cx, cy = (ald["x"] + brn["x"]) / 2 + 0.5, (ald["y"] + brn["y"]) / 2
    labs = [("Aldmere", anchor(ald["x"], ald["y"], 0.95)), ("Brindlewick", anchor(brn["x"], brn["y"], 0.65))]
    for r in ("reg_whisperwood", "reg_greymoor", "reg_velmark", "reg_sylvaran"):
        c = region_info(r)
        if c and abs(c[0] - cx) < 22 and abs(c[1] - cy) < 14:
            labs.append((RNAME[r], anchor(c[0], c[1], 0.5)))
    shoot("diorama_heartland.png", (cx, cy), 17.0, -24.0, 36.0, 35.0, "The Heartland", labs, 22 * RES[1] / 1080, False)
if "spine" in only:
    def summit(cx_, cy_, r_):
        best = (-9.0, cx_, cy_)
        for yy in np.arange(cy_ - r_, cy_ + r_ + 1e-6, SY):
            for xx in np.arange(cx_ - r_, cx_ + r_ + 1e-6, SX):
                zz = float(zat(xx, yy))
                if zz > best[0]:
                    best = (zz, xx, yy)
        return best[1], best[2]
    sx_, sy_ = summit(88.0, 29.0, 2.5)
    bx_, by_ = summit(90.3, 32.8, 2.0)
    labs = [("Dragon Spine", anchor(sx_, sy_, 0.08)), ("The Burning Peaks", anchor(bx_, by_, 0.08))]
    log("summits", sx_, sy_, bx_, by_)
    shoot("diorama_spine.png", (90.0, 27.0), 66.0, -50.0, 8.0, 32.0, "The Dragon Spine", labs, 22 * RES[1] / 1080, False, aim_lift=1.5, sky=True)
log("DONE")
