"""Tiles: addressing, sampling the height field on a tile grid, surface colours, 16-bit heightmap + sidecar writers.

A tile is a square of `size_m` metres (default 10 km) sampled every `res_m` metres (default 20 m; 10 m for close-ups),
(size/res + 1) samples per side so neighbouring tiles share their edge row/column exactly. Tile origins are integer
metres, so the world coordinate of every sample is exact and shared edges are bit-identical.
Row 0 of every raster is the NORTH edge (map y smaller), column 0 the WEST edge.
"""
import hashlib
import json
import math
import struct
import zlib
from dataclasses import dataclass

import numpy as np

from . import noise
from .noise import smoothstep
from .world import RING0_SIZE_M

H_MIN_M, H_MAX_M = -1800.0, 3400.0          # fixed 16-bit encoding range, the same for every tile
GENERATOR = "ascend_terrain/1"


@dataclass(frozen=True)
class TileSpec:
    x0_m: int
    y0_m: int
    size_m: int = 10000
    res_m: int = 20
    label: str = ""

    @property
    def n(self):
        return self.size_m // self.res_m + 1

    @property
    def x0_km(self):
        return self.x0_m / 1000.0

    @property
    def y0_km(self):
        return self.y0_m / 1000.0

    @property
    def tid(self):
        f = lambda v: ("%g" % (v / 1000.0))
        return "x%s_y%s_s%g_r%d" % (f(self.x0_m), f(self.y0_m), self.size_m / 1000.0, self.res_m)

    @property
    def name(self):
        return (self.label + "_" if self.label else "") + self.tid

    @property
    def bbox_m(self):
        return (self.x0_m, self.y0_m, self.x0_m + self.size_m, self.y0_m + self.size_m)

    def neighbour(self, dx, dy, label=""):
        return TileSpec(self.x0_m + dx * self.size_m, self.y0_m + dy * self.size_m, self.size_m, self.res_m, label)


def tile_at(tx, ty, size_km=10.0, res_m=20, label=""):
    S = int(round(size_km * 1000))
    return TileSpec(int(tx * S), int(ty * S), S, res_m, label)


def tile_centered(cx_km, cy_km, size_km=10.0, res_m=20, label=""):
    """Tile of the given size centred as near as possible to a point; origin snapped to 0.5 km."""
    S = int(round(size_km * 1000))
    x0 = int(round((cx_km * 1000 - S / 2) / 500.0)) * 500
    y0 = int(round((cy_km * 1000 - S / 2) / 500.0)) * 500
    return TileSpec(x0, y0, S, res_m, label)


def tiles_for_bbox(x0_km, y0_km, x1_km, y1_km, size_km=10.0, res_m=20, world=None):
    S = size_km
    ts = []
    for ty in range(int(math.floor(y0_km / S)), int(math.ceil(y1_km / S))):
        for tx in range(int(math.floor(x0_km / S)), int(math.ceil(x1_km / S))):
            if world is not None and (tx * S >= world.width_km or ty * S >= world.height_km or tx < 0 or ty < 0):
                continue
            ts.append(tile_at(tx, ty, size_km, res_m))
    return ts


# ---------------------------------------------------------------------------------------------------------------
# Surface

PALETTE = {                # sRGB 0-255
    "plains": (156, 192, 94), "steppe": (206, 190, 112), "forest": (92, 142, 72), "jungle": (62, 132, 74), "swamp": (98, 124, 86),
    "tundra": (176, 182, 158), "desert": (228, 198, 130), "volcanic": (96, 74, 70), "spirit": (142, 152, 202), "demon": (126, 74, 90),
    "beach": (232, 216, 166), "snow": (240, 244, 247), "rock": (130, 122, 114),
    "road": (201, 166, 107), "pad": (190, 164, 112), "riverbed": (150, 138, 110),
    "sea_shallow": (150, 204, 192), "sea_deep": (62, 104, 132),
}
SNOWLINE_KM_M = [(0, 1100), (32, 1500), (40, 2250), (66, 2800), (72, 6000), (100, 6000)]


def snowline_m(y_km):
    ys, vs = zip(*SNOWLINE_KM_M)
    return np.interp(y_km, ys, vs)


def srgb_to_linear(c):
    c = np.asarray(c, dtype=np.float64)
    return np.where(c <= 0.04045, c / 12.92, ((c + 0.055) / 1.055) ** 2.4)


def _col(name):
    return np.array(PALETTE[name], dtype=np.float64) / 255.0


GROUND_TONES = {          # (lit, shade) sRGB 0-255 per vegetated biome; plains are the style-guide trio (art_direction.md section 9)
    "plains": ((140, 200, 96), (94, 154, 74)), "forest": ((108, 174, 85), (74, 138, 69)), "jungle": ((79, 168, 96), (52, 134, 79)),
    "swamp": ((126, 158, 106), (94, 126, 90)), "steppe": ((200, 188, 110), (168, 160, 88)), "tundra": ((180, 188, 160), (142, 152, 126)),
}
DIRT = (201, 166, 107)     # #C9A66B
DIRT_BIOME = {"plains": 1.0, "forest": 0.35, "jungle": 0.2, "swamp": 0.5, "steppe": 1.3, "tundra": 0.7}
ROCK_STRATA = ((196, 182, 156), (158, 148, 134), (122, 114, 108), (176, 132, 100))   # warm light, mid, dark, rust band
SAND_TONES = ((238, 208, 146), (231, 199, 134))


def _rgb(c):
    return np.array(c, dtype=np.float64) / 255.0


def tone_fields(Xf, Yf):
    """Soft patches of shade (large) and dirt (small), 0..1. Three-tone ground = lit grass, shade grass, dirt."""
    big = 0.6 * noise.fbm(Xf, Yf, 420.0, 3, 191) + 0.4 * noise.fbm(Xf, Yf, 140.0, 3, 192)
    shade = smoothstep(-0.02, 0.22, -big)
    dirt = smoothstep(0.30, 0.46, noise.fbm(Xf, Yf, 210.0, 3, 193) + 0.25 * noise.fbm(Xf, Yf, 55.0, 2, 196))
    return shade, dirt


def surface(field, ev, X, Y, h, slope):
    """Albedo (sRGB 0-1, shape (...,3)) and splat weights (veg, rock, sand, snow) from soft biome masks, slope, height.
    Ground is three-tone (lit / shade / dirt patches, soft edged); mountains get cel-banded strata, slope colour and a
    slope+height snow mask."""
    M = ev.masks
    shape = h.shape
    hf = h.ravel()
    Xf, Yf = X.ravel(), Y.ravel()
    shade, dirt = tone_fields(Xf, Yf)
    sl = slope.ravel()
    ph = hf / 36.0 + 0.6 * noise.fbm(Xf, Yf, 260.0, 2, 96)
    layer = np.floor(ph)
    hv = noise._hash(layer, np.zeros_like(layer), 97)
    pick = np.where(hv < 0.12, 3, np.minimum((hv * 3.4).astype(int), 2))           # light / mid / dark layers, a rare rust band
    strata = np.array([_rgb(c) for c in ROCK_STRATA])[pick]
    cliff = smoothstep(0.55, 1.2, sl)
    # normal slopes are smooth, softly varied rock; the cel strata show only on true cliffs, and faintly
    rock_n = 0.5 + 0.5 * noise.fbm(Xf, Yf, 140.0, 3, 103)
    rock_base = _rgb(ROCK_STRATA[0])[None, :] * (1 - rock_n)[:, None] * 0.55 + _rgb(ROCK_STRATA[1])[None, :] * (0.45 + 0.55 * rock_n)[:, None]
    rock_base = rock_base * (1.0 + 0.05 * noise.fbm(Xf, Yf, 600.0, 2, 104))[:, None]
    cliffw = smoothstep(0.85, 1.3, sl) * 0.5
    strata = rock_base + (strata - rock_base) * cliffw[:, None]
    strata = strata * (1.0 - 0.16 * cliff)[:, None] * np.array([1.0, 1.0, 1.04])[None, :]       # steep faces darker and a touch cooler
    names = ["plains", "steppe", "forest", "jungle", "swamp", "tundra", "desert", "volcanic", "spirit", "demon", "beach"]
    acc = np.zeros((hf.size, 3))
    wsum = np.zeros(hf.size)
    for nm in names:
        w = M[nm].ravel()
        if nm in GROUND_TONES:
            lit, sha = GROUND_TONES[nm]
            c = _rgb(lit)[None, :] + (_rgb(sha) - _rgb(lit))[None, :] * shade[:, None]
            dw = np.clip(dirt * DIRT_BIOME[nm], 0, 1) * 0.85
            c = c + (_rgb(DIRT)[None, :] - c) * dw[:, None]
        elif nm == "desert":
            c = _rgb(SAND_TONES[0])[None, :] + (_rgb(SAND_TONES[1]) - _rgb(SAND_TONES[0]))[None, :] * shade[:, None]
        elif nm == "volcanic":                                      # basalt: the same cel strata, darker and warmer
            c = strata * np.array([0.72, 0.66, 0.66])[None, :]
        else:
            c = _col(nm)[None, :] * (1.0 + 0.06 * noise.fbm(Xf, Yf, 70.0, 3, 91))[:, None]
        acc += w[:, None] * c
        wsum += w
    # mountains: forest foot, banded rock above
    mt = M["mountain"].ravel() + 0.0
    snl0 = snowline_m(Yf / 1000.0)
    tl = snl0 - 450.0                                                      # the vegetation limit sits under the snowline
    a_forest = smoothstep(tl - 1000.0, tl - 350.0, hf + 60.0 * noise.fbm(Xf, Yf, 500.0, 2, 105))
    a_rock = smoothstep(tl - 150.0, tl + 450.0, hf + 60.0 * noise.fbm(Xf, Yf, 500.0, 2, 106))
    lit, sha = GROUND_TONES["forest"]
    foot = _rgb(lit)[None, :] + (_rgb(sha) - _rgb(lit))[None, :] * shade[:, None]
    meadow = _rgb((150, 172, 104))[None, :] + (_rgb((118, 146, 90)) - _rgb((150, 172, 104)))[None, :] * shade[:, None]
    mcol = foot * (1 - a_forest)[:, None] + meadow * (a_forest * (1 - a_rock))[:, None] + strata * a_rock[:, None]
    alt = a_rock
    acc += mt[:, None] * mcol
    wsum += mt
    sn = M["snow"].ravel()
    acc += sn[:, None] * _col("snow")
    wsum += sn
    col = np.where(wsum[:, None] > 0.05, acc / np.maximum(wsum, 1e-6)[:, None], _rgb(GROUND_TONES["plains"][0])[None, :])
    volc = np.clip(M["volcanic"].ravel() + M["demon"].ravel(), 0, 1)
    vegc = foot * (1 - a_forest)[:, None] + meadow * a_forest[:, None]             # old volcanic ground greens over below the treeline
    col = col + (vegc - col) * (0.7 * volc * (1 - a_rock))[:, None]
    beach = smoothstep(0.2, 0.7, M["beach"].ravel()) * (1 - smoothstep(6, 25, hf))
    desert = smoothstep(0.35, 0.8, M["desert"].ravel())
    tl_ = snowline_m(Yf / 1000.0) - 450.0
    rockw = smoothstep(0.75, 1.18, sl + 0.08 * noise.fbm(Xf, Yf, 120.0, 3, 93)) * (0.30 + 0.70 * smoothstep(tl_ - 900.0, tl_ - 100.0, hf))
    rockw = np.maximum(rockw, smoothstep(1.0, 1.3, sl)) * (1 - 0.7 * np.maximum(beach, desert * 0.8))
    rockc = strata * (1 + 0.05 * noise.fbm(Xf, Yf, 35.0, 3, 94))[:, None]
    col = col + (rockc - col) * rockw[:, None]
    # talus / scree aprons under the cliffs: moderate slopes just below steep ones, pale grey-brown
    scree = smoothstep(0.38, 0.55, sl) * (1.0 - smoothstep(0.80, 1.05, sl)) * smoothstep(tl_ - 800.0, tl_ - 200.0, hf) * np.clip(M["mountain"].ravel() + M["volcanic"].ravel(), 0, 1)
    scree = scree * (0.5 + 0.5 * smoothstep(-0.2, 0.3, noise.fbm(Xf, Yf, 90.0, 3, 107)))
    col = col + (_rgb((176, 164, 148))[None, :] * (1 + 0.06 * noise.fbm(Xf, Yf, 30.0, 2, 108))[:, None] - col) * (0.75 * scree)[:, None]
    # desert: lee (slip) faces a darker, warmer sand and windward faces a touch lighter, so the large dunes read in the colour too
    if desert.max() > 0.05:
        step = float(abs(X[0, 1] - X[0, 0])) or 20.0
        gy_, gx_ = np.gradient(h, step)
        th_ = math.radians(35.0)
        dzu = (gx_ * math.cos(th_) + gy_ * math.sin(th_)).ravel()
        lee = smoothstep(0.10, 0.35, -dzu) * desert
        wind = smoothstep(0.04, 0.12, dzu) * desert
        col = col * (1.0 - 0.17 * lee)[:, None] * np.array([1.0, 0.97, 0.93])[None, :] ** lee[:, None]
        col = col * (1.0 + 0.04 * wind)[:, None]
    # snow: height above the snowline AND not on cliffs; crisp edge (cel), patchy near the line
    snl = snowline_m(Yf / 1000.0)
    stp_ = float(abs(X[0, 1] - X[0, 0])) or 20.0
    kk = max(1, int(round(60.0 / stp_)))
    lap = ((np.roll(h, kk, 0) + np.roll(h, -kk, 0) + np.roll(h, kk, 1) + np.roll(h, -kk, 1) - 4.0 * h) / (kk * stp_) ** 2).ravel()
    gully = smoothstep(0.0004, 0.003, lap)
    convex = smoothstep(0.0004, 0.003, -lap)
    snoise = 130.0 * noise.fbm(Xf, Yf, 1800.0, 2, 95) + 25.0 * noise.fbm(Xf, Yf, 500.0, 2, 109) + 110.0 * gully - 150.0 * convex
    # volcanic and demon ground carry no snow below the line + 450 m (caps only above that)
    volc_block = volc * (1.0 - smoothstep(snl + 350.0, snl + 700.0, hf))
    snoww = smoothstep(snl - 25, snl + 90, hf + snoise) * (1 - smoothstep(0.85, 1.35, sl)) * (1 - 0.9 * volc_block)
    snoww = np.maximum(snoww, 0.9 * sn * (1 - volc_block))
    snoww = np.where(snoww > 0.5, 0.5 + 0.5 * smoothstep(0.5, 0.62, snoww), snoww * smoothstep(0.38, 0.5, snoww) * 2.0)
    # cel snow: lit / mid / lavender shade tones (hard steps, lee faces of the light and wind-drift patches), rock showing through on steep bits
    stp = float(abs(X[0, 1] - X[0, 0])) or 20.0
    gy2, gx2 = np.gradient(h, stp)
    dzl = (0.85 * gx2 - 0.5 * gy2).ravel()
    shade_s = smoothstep(0.10, 0.13, -dzl + 0.10 * noise.fbm(Xf, Yf, 70.0, 2, 97) + 0.08 * noise.fbm(Xf, Yf, 230.0, 2, 98))
    mid_s = smoothstep(0.02, 0.05, noise.fbm(Xf, Yf, 190.0, 3, 99) + 0.2 * noise.fbm(Xf, Yf, 60.0, 2, 100))
    s_lit, s_mid, s_sh = _rgb((246, 248, 253)), _rgb((222, 228, 246)), _rgb((184, 186, 226))
    scol = s_lit[None, :] + (s_mid - s_lit)[None, :] * mid_s[:, None]
    scol = scol + (s_sh[None, :] - scol) * shade_s[:, None]
    sw = np.clip(snoww, 0, 1)
    outc = smoothstep(0.95, 0.98, sl + 0.15 * noise.fbm(Xf, Yf, 60.0, 2, 101) + 0.08 * noise.fbm(Xf, Yf, 240.0, 2, 102)) * (sw > 0.2)
    scol = scol + (rockc * 0.95 - scol) * outc[:, None]
    col = col + (scol - col) * sw[:, None]
    sandw = np.maximum(beach, desert)
    col = col + (_col("beach") - col) * (0.65 * beach)[:, None]
    # floodplain meadows: grass-green, little bare dirt
    wvf = ev.wv.ravel() * (1.0 - np.clip(M["mountain"].ravel(), 0, 1))
    col = col + (_rgb((146, 204, 98))[None, :] - col) * (0.40 * wvf)[:, None]
    # roads, pads, river beds
    rw = ev.road_w.ravel() * 0.9 * (0.55 + 0.45 * smoothstep(0.35, 0.8, ev.road_w.ravel()))        # a worn core, the shoulders stay grassy
    col = col + (_rgb(DIRT) - col) * rw[:, None]
    # packed earth only on the flat of a settlement pad (and, for Ring 0 settlements, the field's square plus a margin), not the whole skirt
    pw = np.zeros(hf.size)
    for st in field.w.settlements:
        cx_, cy_ = st["at"][0] * 1000.0, st["at"][1] * 1000.0
        if st.get("ring0"):
            inner = np.maximum(np.abs(Xf - cx_), np.abs(Yf - cy_))
            pw = np.maximum(pw, 0.6 * (1.0 - smoothstep(100.0, 135.0, inner)))
        else:
            d_ = np.hypot(Xf - cx_, Yf - cy_)
            pw = np.maximum(pw, 0.45 * (1.0 - smoothstep(0.35 * st["flat"], 0.7 * st["flat"], d_)))
    col = col + (_col("pad") - col) * pw[:, None]
    cw = ev.river_w.ravel() * 0.7
    col = col + (_col("riverbed") - col) * cw[:, None]
    # lake shores: a sand margin on gentle ground, pale scree where the shore is steep
    lmq = ev.lake_m.ravel()
    shore = smoothstep(0.16, 0.28, lmq) * (1.0 - smoothstep(0.40, 0.56, lmq))
    shore_col = _col("beach")[None, :] * (1 - smoothstep(0.25, 0.6, sl))[:, None] + _rgb((172, 160, 144))[None, :] * smoothstep(0.25, 0.6, sl)[:, None]
    col = col + (shore_col - col) * (0.8 * shore)[:, None]
    # sea floor and lake floor: depth tint
    under = np.where(ev.lake_m.ravel() > 0.4, hf < ev.lake_s.ravel(), hf < 0.0)
    ref = np.where(ev.lake_m.ravel() > 0.4, ev.lake_s.ravel(), 0.0)
    dep = np.clip((ref - hf) / 250.0, 0, 1) ** 0.6
    wcol = _col("sea_shallow")[None, :] + (_col("sea_deep") - _col("sea_shallow"))[None, :] * dep[:, None]
    sandy = smoothstep(8.0, 0.0, ref - hf)
    wcol = wcol + (_col("beach") - wcol) * (0.55 * sandy)[:, None]
    col = np.where(under[:, None], wcol, col)
    snoww = np.clip(snoww, 0, 1)
    veg = np.clip(1.0 - rockw - sandw * 0.8 - snoww, 0, 1)
    splat = np.stack([veg, rockw, np.clip(sandw, 0, 1) * (1 - snoww), snoww], 1)
    return np.clip(col, 0, 1).reshape(shape + (3,)), splat.reshape(shape + (4,))


# ---------------------------------------------------------------------------------------------------------------
# Building a tile

class TileData:
    pass


def build_tile(field, spec: TileSpec, with_surface=True):
    n = spec.n
    P = 3                                                      # a ring of 3 samples round the tile: slopes and curvature are exact at the edges
    idx = np.arange(-P, n + P, dtype=np.int64)
    X = (spec.x0_m + idx * spec.res_m).astype(np.float64)[None, :].repeat(n + 2 * P, 0)
    Y = (spec.y0_m + idx * spec.res_m).astype(np.float64)[:, None].repeat(n + 2 * P, 1)
    ev = field.evaluate(X, Y)
    ev.wv = field._valley(X.ravel(), Y.ravel())[0].reshape(X.shape)           # river-valley (floodplain) weight, for colour and dressing
    t = TileData()
    t.spec = spec
    H = ev.h
    sl = (slice(P, -P), slice(P, -P))
    t.h = H[sl].copy()
    gyH, gxH = np.gradient(H, float(spec.res_m))
    slope_full = np.hypot(gxH, gyH)
    t.slope = slope_full[sl].copy()
    q = np.clip(np.rint((t.h - H_MIN_M) / (H_MAX_M - H_MIN_M) * 65535.0), 0, 65535).astype(np.uint16)
    t.u16 = q
    t.sha256 = hashlib.sha256(np.ascontiguousarray(q).astype("<u2").tobytes()).hexdigest()
    t.pad_w, t.road_w, t.lake_m, t.lake_s, t.river_w = (a[sl].copy() for a in (ev.pad_w, ev.road_w, ev.lake_m, ev.lake_s, ev.river_w))
    t.X, t.Y = X[sl], Y[sl]
    t.valley = ev.wv[sl].astype(np.float32)
    if with_surface:
        t.albedo, t.splat = surface(field, ev, X, Y, H, slope_full)
        t.albedo, t.splat = t.albedo[sl], t.splat[sl]
        t.masks = {k: np.asarray(ev.masks[k]).reshape(H.shape)[sl].astype(np.float32) for k in
                   ("forest", "plains", "jungle", "swamp", "desert", "tundra", "mountain", "steppe", "volcanic", "snow", "beach", "spirit", "demon", "sea")}
    t.rivers = field.river_features(spec.bbox_m)
    t.lakes = [l for l in field.w.lakes if not (l["bbox"][0] * 1000 > spec.bbox_m[2] or l["bbox"][2] * 1000 < spec.bbox_m[0]
                                               or l["bbox"][1] * 1000 > spec.bbox_m[3] or l["bbox"][3] * 1000 < spec.bbox_m[1])]
    return t


def hillshade_rgb(t, exag=1.6):
    """Top-down shaded colour image (uint8) for quick looks; sun from the north-west."""
    h = t.h
    r = t.spec.res_m
    gy, gx = np.gradient(h, r)
    nx, ny, nz = -gx * exag, -gy * exag, np.ones_like(h)           # row axis points south
    nl = np.sqrt(nx * nx + ny * ny + nz * nz)
    lx, ly, lz = -0.55, -0.55, 0.63                                 # light comes from the north-west, above
    shade = np.clip((nx * lx + ny * ly + nz * lz) / nl, 0, 1)
    shade = 0.35 + 0.75 * shade
    rgb = t.albedo * shade[..., None]
    water = (h < 0) | (t.lake_m > 0.5) & (h < t.lake_s)
    wcol = np.array([0.30, 0.52, 0.66])
    rgb = np.where(water[..., None], 0.55 * rgb + 0.45 * wcol * shade[..., None], rgb)
    return (np.clip(rgb, 0, 1) * 255 + 0.5).astype(np.uint8)


# ---------------------------------------------------------------------------------------------------------------
# PNG I/O (no external libs): 16-bit greyscale, 8-bit RGB/RGBA

def _chunk(tag, data):
    c = struct.pack(">I", len(data)) + tag + data
    return c + struct.pack(">I", zlib.crc32(tag + data) & 0xFFFFFFFF)


def write_png(path, arr, level=6):
    """arr: uint16 (H,W) -> 16-bit grey; uint8 (H,W,3|4) -> RGB/RGBA."""
    arr = np.ascontiguousarray(arr)
    if arr.dtype == np.uint16 and arr.ndim == 2:
        hgt, wid = arr.shape
        ct, bd = 0, 16
        raw = arr.astype(">u2").view(np.uint8).reshape(hgt, wid * 2)
    elif arr.dtype == np.uint8 and arr.ndim == 3:
        hgt, wid, ch = arr.shape
        ct, bd = {3: 2, 4: 6}[ch], 8
        raw = arr.reshape(hgt, wid * ch)
    else:
        raise ValueError("unsupported array")
    body = np.zeros((hgt, raw.shape[1] + 1), dtype=np.uint8)
    body[:, 1:] = raw
    data = (b"\x89PNG\r\n\x1a\n" + _chunk(b"IHDR", struct.pack(">IIBBBBB", wid, hgt, bd, ct, 0, 0, 0))
            + _chunk(b"IDAT", zlib.compress(body.tobytes(), level)) + _chunk(b"IEND", b""))
    with open(path, "wb") as f:
        f.write(data)


def read_png16(path):
    """Reads back a 16-bit greyscale PNG written by write_png (filter 0 only)."""
    b = open(path, "rb").read()
    assert b[:8] == b"\x89PNG\r\n\x1a\n"
    pos, idat, wid, hgt = 8, b"", 0, 0
    while pos < len(b):
        ln = struct.unpack(">I", b[pos:pos + 4])[0]
        tag = b[pos + 4:pos + 8]
        d = b[pos + 8:pos + 8 + ln]
        if tag == b"IHDR":
            wid, hgt, bd, ct = struct.unpack(">IIBB", d[:10])
            assert bd == 16 and ct == 0
        elif tag == b"IDAT":
            idat += d
        pos += 12 + ln
    raw = np.frombuffer(zlib.decompress(idat), dtype=np.uint8).reshape(hgt, wid * 2 + 1)
    assert (raw[:, 0] == 0).all()
    return raw[:, 1:].copy().view(">u2").reshape(hgt, wid).astype(np.uint16)


def decode_height(u16):
    return H_MIN_M + u16.astype(np.float64) / 65535.0 * (H_MAX_M - H_MIN_M)


# ---------------------------------------------------------------------------------------------------------------
# Sidecar

def sidecar(world, field, t, files, extra=None):
    s = t.spec
    h = t.h
    d = {
        "format": "ascend-terrain-heightmap/1",
        "generator": GENERATOR,
        "name": s.name,
        "seed": field.seed,
        "tile": {"x0Km": s.x0_km, "y0Km": s.y0_km, "sizeKm": s.size_m / 1000.0, "x1Km": (s.x0_m + s.size_m) / 1000.0,
                 "y1Km": (s.y0_m + s.size_m) / 1000.0,
                 "tileX": s.x0_m / s.size_m, "tileY": s.y0_m / s.size_m},
        "resolutionM": s.res_m,
        "samples": s.n,
        "axes": "raster row 0 = north edge (map y = y0Km), column 0 = west edge (map x = x0Km); sample (i,j) at x = x0Km + i*res/1000, y = y0Km + j*res/1000; "
                "map y runs south. Edge rows/columns are shared with the neighbouring tile.",
        "encoding": {"bits": 16, "minM": H_MIN_M, "maxM": H_MAX_M, "formula": "heightM = minM + value / 65535 * (maxM - minM)",
                     "stepM": (H_MAX_M - H_MIN_M) / 65535.0},
        "heightmapSha256": t.sha256,
        "stats": {"minM": float(h.min()), "maxM": float(h.max()), "meanM": float(h.mean()), "seaFraction": float((h < 0).mean()),
                  "maxSlope": float(t.slope.max()), "p99Slope": float(np.percentile(t.slope, 99))},
        "files": files,
        "seaLevelM": 0.0,
        "settlements": [], "roads": [], "rivers": [], "lakes": [], "peaks": [],
    }
    bb = s.bbox_m
    for st in world.settlements:
        x, y = st["at"][0] * 1000, st["at"][1] * 1000
        if bb[0] - 400 <= x <= bb[2] + 400 and bb[1] - 400 <= y <= bb[3] + 400:
            e = {"name": st["name"], "atKm": list(st["at"]), "size": st["size"], "padFlatRadiusM": st["flat"], "padSkirtM": st["skirt"],
                 "padHeightM": round(field.pad_height(st["name"]), 3), "source": st["source"]}
            if st.get("ring0"):
                e["ring0"] = {"sizeM": RING0_SIZE_M, "centreKm": list(st["at"]), "heightM": round(field.pad_height(st["name"]), 3),
                              "note": "the pad is exactly flat (no noise, no road, no river) for %g m round the centre, so the hand-built Ring 0 field fits" % st["flat"]}
            d["settlements"].append(e)
    for pl in field.road_lines_in(bb):
        d["roads"].append({"id": pl.id, "lengthKm": round(pl.length / 1000.0, 3)})
    for r in t.rivers:
        step = max(1, int(round(100.0 / 20.0)))
        d["rivers"].append({"id": r["id"], "name": r["name"], "flowIndex": r["flow"],
                            "points": [[round(p[0] / 1000, 4), round(p[1] / 1000, 4), round(float(w), 2), round(float(hw * 2), 1)]
                                       for p, w, hw in zip(r["P"][::step], r["ws"][::step], r["hw"][::step])],
                            "pointFields": "[xKm, yKm, waterSurfaceM, widthM]"})
    for l in t.lakes:
        d["lakes"].append({"id": l["id"], "surfaceM": l["surface"], "atKm": list(l["at"])})
    for p in world.peaks:
        x, y = p["at"][0] * 1000, p["at"][1] * 1000
        if bb[0] <= x <= bb[2] and bb[1] <= y <= bb[3]:
            d["peaks"].append({"name": p["name"], "atKm": list(p["at"]), "listedM": p["m"]})
    if extra:
        d.update(extra)
    return d


def save_json(path, obj):
    with open(path, "w", encoding="utf-8", newline="\n") as f:
        json.dump(obj, f, indent=1, ensure_ascii=False)
        f.write("\n")
