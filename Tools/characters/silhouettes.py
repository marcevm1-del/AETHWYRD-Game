"""Draws the character silhouette library (Data/Characters/silhouettes.json) and measures how distinct the outlines are.

Each concept is drawn as a solid black figure from its shape axes (hair, outer garment, sleeves, lower garment, armour,
weapon, build, stance, headwear), so the library can be judged the way the brief asks: by outline, from a distance.
Distinctness is measured on the drawn masks: for every pair in a family, the overlap (intersection over union) of the
two outlines after aligning their feet. A pair above --max-iou fails.

    python Tools/characters/silhouettes.py                 # writes 07_Characters/silhouettes/*.png and prints the report
    python Tools/characters/silhouettes.py --check-only     # report only, exit 1 if any pair is too similar
Needs Pillow (pip install pillow). Deterministic: the same data draws the same pixels.
"""
import argparse
import json
import math
import os
import sys

from PIL import Image, ImageDraw, ImageFont

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", ".."))
DATA = os.path.join(ROOT, "Data", "Characters", "silhouettes.json")
OUT = os.path.join(ROOT, "07_Characters", "silhouettes")

W, H = 240, 440          # one figure tile
GROUND = 418
INK = 0                  # mask value for the figure (L mode, 0 = black)

BUILD = {"slim": 0.86, "average": 1.0, "sturdy": 1.16, "heavy": 1.36}


class Fig:
    """A figure under construction: a 1-bit mask plus the anchor points the parts hang from."""

    def __init__(self, shape, family):
        self.s = shape
        self.fem = family == "feminine"
        self.img = Image.new("L", (W, H), 255)
        self.d = ImageDraw.Draw(self.img)
        tall = 330 if self.fem else 346
        crouch = shape["stance"] == "crouch"
        self.h = tall * (0.74 if crouch else 1.0)
        self.k = BUILD[shape["build"]] * (1.12 if shape["armor"] == "full_heavy" else 1.0)
        self.cx = W / 2
        self.lean = {"lean": 0.16, "crouch": 0.08}.get(shape["stance"], 0.0)   # forward shear of the upper body
        u = self.h / 7.25                                                      # one head unit
        self.u = u
        self.head_r = u * 0.52
        self.top = GROUND - self.h
        self.chin = self.top + u
        self.shoulder_y = self.top + u * 1.45
        self.waist_y = self.top + u * 3.0
        self.hip_y = self.top + u * 3.6
        self.knee_y = self.top + u * 5.35
        self.sh_w = u * (0.78 if self.fem else 0.95) * self.k                   # half width at the shoulders
        self.hip_w = u * (0.72 if self.fem else 0.66) * self.k

    # ---------------------------------------------------------------- helpers
    def x(self, dx, y):
        """Horizontal position, sheared by the lean above the hips."""
        t = max(0.0, (self.hip_y - y) / (self.hip_y - self.top))
        return self.cx + dx + self.lean * t * self.u * 2.2

    def poly(self, pts):
        self.d.polygon([(self.x(dx, y), y) for dx, y in pts], fill=INK)

    def ell(self, dx, y, rx, ry):
        cx = self.x(dx, y)
        self.d.ellipse([cx - rx, y - ry, cx + rx, y + ry], fill=INK)

    def line(self, pts, w):
        P = [(self.x(dx, y), y) for dx, y in pts]
        self.d.line(P, fill=INK, width=int(max(1, w)), joint="curve")
        for p in (P[0], P[-1]):
            self.d.ellipse([p[0] - w / 2, p[1] - w / 2, p[0] + w / 2, p[1] + w / 2], fill=INK)

    # ---------------------------------------------------------------- the body, back to front
    def draw(self):
        self.back_items()
        self.legs()
        self.lower()
        self.torso()
        self.outer()
        self.arms()
        self.armor()
        self.head()
        self.front_items()
        return self.img

    def back_items(self):
        s, u = self.s, self.u
        if s["outer"] == "cape":
            self.poly([(-self.sh_w * 0.9, self.shoulder_y), (self.sh_w * 0.9, self.shoulder_y), (self.sh_w * 1.9, self.knee_y + u * 0.6), (-self.sh_w * 1.9, self.knee_y + u * 0.6)])
        if s["outer"] == "hooded_cloak":
            self.poly([(-self.sh_w * 0.8, self.chin), (self.sh_w * 0.8, self.chin), (self.sh_w * 1.7, self.knee_y + u * 0.3), (-self.sh_w * 1.7, self.knee_y + u * 0.3)])
        if s["outer"] == "scarf_long" or s["accent"] == "scarf":
            y = self.chin + u * 0.25
            self.line([(0, y), (self.sh_w * 1.6, y + u * 0.9), (self.sh_w * 2.6, y + u * 2.1)], u * 0.32)
        if s["accent"] == "sash_tails":
            y = self.waist_y
            self.line([(-self.hip_w * 0.6, y), (-self.hip_w * 1.6, y + u * 1.5)], u * 0.2)
            self.line([(-self.hip_w * 0.4, y), (-self.hip_w * 1.1, y + u * 1.8)], u * 0.16)
        if s["accent"] == "feathers":
            for i in range(3):
                self.line([(self.sh_w * 0.6, self.shoulder_y), (self.sh_w * (1.5 + 0.35 * i), self.shoulder_y - u * (0.9 - 0.3 * i))], u * 0.18)
        if s["headwear"] == "headband_tails":
            y = self.top + u * 0.35
            self.line([(-self.head_r, y), (-self.head_r * 2.6, y + u * 0.7), (-self.head_r * 3.3, y + u * 0.4)], u * 0.14)
            self.line([(-self.head_r, y), (-self.head_r * 2.4, y + u * 1.0)], u * 0.12)
        w = s["weapon"]
        if w == "katana_back":
            self.line([(-self.sh_w * 1.2, self.top + u * 0.1), (self.sh_w * 1.0, self.waist_y)], u * 0.16)
        if w == "dual_back":
            self.line([(-self.sh_w * 1.1, self.top + u * 0.3), (self.sh_w * 0.2, self.waist_y - u * 0.2)], u * 0.14)
            self.line([(self.sh_w * 1.1, self.top + u * 0.3), (-self.sh_w * 0.2, self.waist_y - u * 0.2)], u * 0.14)
        if w == "greatsword_back":
            self.line([(-self.sh_w * 1.5, self.top - u * 0.7), (self.sh_w * 1.2, self.hip_y + u * 0.6)], u * 0.42)
            self.line([(-self.sh_w * 1.1, self.top + u * 0.05), (-self.sh_w * 0.4, self.top - u * 0.45)], u * 0.18)
        if w == "bow_back":
            cx = self.x(0, self.shoulder_y)
            r = u * 2.0
            self.d.arc([cx - r * 0.7, self.shoulder_y - r * 0.9, cx + r * 1.2, self.shoulder_y + r * 1.4], 200, 340, fill=INK, width=int(u * 0.15))
        self.hair(back=True)

    def legs(self):
        s, u = self.s, self.u
        st = s["stance"]
        spread = {"neutral": 0.35, "guard": 0.75, "wide": 1.45, "lean": 0.9, "crouch": 1.2, "draw_ready": 0.9, "arms_crossed": 0.55, "casual": 0.55}[st]
        thick = u * 0.42 * self.k * (1.1 if s["footwear"] == "boots_heavy" else 1.0)
        for sgn in (-1, 1):
            hx = sgn * self.hip_w * 0.5
            fx = sgn * (self.hip_w * 0.5 + u * spread * 0.55)
            if st == "lean" and sgn < 0:
                fx = -self.hip_w * 0.5 - u * 1.2
            kx = (hx + fx) / 2 + (sgn * u * 0.35 if st == "crouch" else 0)
            ky = (self.hip_y + GROUND) / 2
            self.line([(hx, self.hip_y), (kx, ky), (fx, GROUND - u * 0.08)], thick)
            foot = u * (0.5 if s["footwear"] != "boots_heavy" else 0.62)
            self.ell(fx + sgn * foot * 0.25, GROUND - u * 0.1, foot * 0.75, u * 0.14)
            if s["footwear"] == "boots_heavy":
                self.line([(fx, GROUND - u * 1.3), (fx, GROUND - u * 0.15)], thick * 1.35)

    def lower(self):
        s, u = self.s, self.u
        L = s["lower"]
        hw = self.hip_w
        if L == "trousers_wide":
            self.poly([(-hw, self.waist_y), (hw, self.waist_y), (hw * 1.7, GROUND - u * 0.4), (-hw * 1.7, GROUND - u * 0.4)])
        elif L == "hakama":
            self.poly([(-hw * 1.05, self.waist_y), (hw * 1.05, self.waist_y), (hw * 2.3, GROUND - u * 0.15), (-hw * 2.3, GROUND - u * 0.15)])
        elif L == "cargo":
            self.poly([(-hw, self.waist_y), (hw, self.waist_y), (hw * 1.45, GROUND - u * 0.6), (-hw * 1.45, GROUND - u * 0.6)])
            for sgn in (-1, 1):
                self.ell(sgn * hw * 1.35, self.knee_y - u * 0.4, u * 0.3, u * 0.38)
        elif L == "skirt_knee":
            self.poly([(-hw * 0.95, self.waist_y), (hw * 0.95, self.waist_y), (hw * 1.75, self.knee_y + u * 0.2), (-hw * 1.75, self.knee_y + u * 0.2)])
        elif L == "skirt_long":
            self.poly([(-hw, self.waist_y), (hw, self.waist_y), (hw * 2.0, GROUND - u * 0.2), (-hw * 2.0, GROUND - u * 0.2)])
        elif L == "skirt_split":
            for sgn in (-1, 1):
                self.poly([(sgn * hw * 0.1, self.waist_y), (sgn * hw, self.waist_y), (sgn * hw * 2.4, self.knee_y + u * 0.9), (sgn * hw * 0.9, self.knee_y + u * 0.2)])
        elif L == "shorts_leggings":
            self.poly([(-hw * 1.05, self.waist_y), (hw * 1.05, self.waist_y), (hw * 1.25, self.hip_y + u * 0.75), (-hw * 1.25, self.hip_y + u * 0.75)])
        else:  # trousers_slim
            self.poly([(-hw, self.waist_y), (hw, self.waist_y), (hw * 0.95, self.hip_y + u * 0.3), (-hw * 0.95, self.hip_y + u * 0.3)])

    def torso(self):
        sw, hw, u = self.sh_w, self.hip_w, self.u
        self.poly([(-sw, self.shoulder_y), (sw, self.shoulder_y), (hw * 0.95, self.waist_y), (hw, self.hip_y), (-hw, self.hip_y), (-hw * 0.95, self.waist_y)])
        self.line([(0, self.chin - u * 0.1), (0, self.shoulder_y + u * 0.1)], u * 0.42)

    def outer(self):
        s, u = self.s, self.u
        sw, o = self.sh_w, s["outer"]
        if o == "short_jacket":
            self.poly([(-sw * 1.08, self.shoulder_y), (sw * 1.08, self.shoulder_y), (sw * 1.12, self.hip_y), (-sw * 1.12, self.hip_y)])
        elif o == "haori_knee":
            self.poly([(-sw * 1.06, self.shoulder_y), (sw * 1.06, self.shoulder_y), (sw * 1.5, self.knee_y + u * 0.35), (sw * 0.25, self.knee_y + u * 0.25), (-sw * 0.25, self.knee_y + u * 0.25), (-sw * 1.5, self.knee_y + u * 0.35)])
        elif o == "long_coat":
            self.poly([(-sw * 1.04, self.shoulder_y), (sw * 1.04, self.shoulder_y), (sw * 1.2, self.knee_y + u * 1.05), (-sw * 1.2, self.knee_y + u * 1.05)])
        elif o == "robe_floor":
            self.poly([(-sw * 1.05, self.shoulder_y), (sw * 1.05, self.shoulder_y), (sw * 2.0, GROUND - u * 0.05), (-sw * 2.0, GROUND - u * 0.05)])
        elif o == "vest":
            self.poly([(-sw * 1.02, self.shoulder_y), (sw * 1.02, self.shoulder_y), (sw * 1.05, self.waist_y + u * 0.2), (-sw * 1.05, self.waist_y + u * 0.2)])

    def arms(self):
        s, u = self.s, self.u
        st, sl = s["stance"], s["sleeves"]
        sy = self.shoulder_y + u * 0.15
        thick = u * 0.36 * self.k
        poses = {
            "neutral": [((1.0, 0.95), (1.1, 1.95)), ((1.0, 0.95), (1.1, 1.95))],
            "guard": [((1.25, 0.75), (0.35, 0.2)), ((1.25, 0.75), (0.55, 0.05))],
            "wide": [((1.9, 0.35), (2.7, 0.15)), ((1.9, 0.35), (2.6, 0.55))],
            "lean": [((1.0, 0.9), (1.4, 1.6)), ((0.6, 0.85), (-0.2, 1.3))],
            "crouch": [((1.5, 0.75), (1.9, 1.35)), ((1.5, 0.75), (1.2, 1.55))],
            "draw_ready": [((0.9, 0.85), (-0.35, 1.45)), ((1.35, 0.85), (1.9, 1.25))],
            "arms_crossed": [((1.25, 0.85), (-0.4, 0.95)), ((1.25, 0.85), (-0.4, 0.85))],
            "casual": [((1.55, 0.9), (0.95, 1.45)), ((1.0, 0.95), (1.1, 1.95))],
        }[st]
        for sgn, ((ex, ey), (hx, hy)) in zip((-1, 1), poses):
            S = (sgn * self.sh_w * 0.92, sy)
            E = (sgn * (self.sh_w * 0.6 + u * ex * 0.55), sy + u * ey)
            Hd = (sgn * (self.sh_w * 0.3 + u * hx * 0.55), sy + u * hy)
            self.line([S, E, Hd], thick)
            if s["armor"] == "gauntlets_heavy" or s["armor"] == "full_heavy":
                self.ell(*Hd, u * 0.42, u * 0.42)
                self.line([E, Hd], thick * 1.9)
            else:
                self.ell(*Hd, u * 0.2, u * 0.2)
            if sl == "wide":
                self.poly([E, (E[0] + sgn * u * 0.2, E[1] - u * 0.2), (Hd[0] + sgn * u * 0.3, Hd[1] + u * 0.25), (Hd[0] - sgn * u * 0.1, Hd[1] + u * 1.0), (E[0] - sgn * u * 0.4, E[1] + u * 0.5)])
            elif sl == "bell":
                self.poly([E, (Hd[0] + sgn * u * 0.55, Hd[1] + u * 0.3), (Hd[0] - sgn * u * 0.55, Hd[1] + u * 0.3)])
            if s["weapon"] == "shield_arm" and sgn < 0:
                self.ell(*E, u * 0.95, u * 1.1)

    def armor(self):
        s, u = self.s, self.u
        a = s["armor"]
        sw = self.sh_w
        if a in ("shoulder_one", "shoulders_both", "lamellar", "full_heavy"):
            for sgn in ((-1,) if a == "shoulder_one" else (-1, 1)):
                r = u * (0.62 if a != "full_heavy" else 0.78)
                self.ell(sgn * sw * 1.05, self.shoulder_y + u * 0.2, r, r * 0.7)
        if a in ("chest_plate", "full_heavy"):
            self.poly([(-sw * 1.12, self.shoulder_y + u * 0.2), (sw * 1.12, self.shoulder_y + u * 0.2), (sw * 0.95, self.waist_y + u * 0.15), (-sw * 0.95, self.waist_y + u * 0.15)])
        if a in ("lamellar", "full_heavy"):
            hw = self.hip_w
            self.poly([(-hw * 1.2, self.waist_y), (hw * 1.2, self.waist_y), (hw * 1.85, self.hip_y + u * 1.1), (-hw * 1.85, self.hip_y + u * 1.1)])

    def hair(self, back):
        s, u = self.s, self.u
        hs, ln = s["hair"], s["hairLength"]
        r = self.head_r
        hy = self.top + r
        drop = {"short": 0.6, "medium": 1.5, "long": 2.8, "very_long": 4.2}[ln] * u
        if back:
            if hs == "long_straight":
                self.poly([(-r * 1.05, hy), (r * 1.05, hy), (r * 1.15, hy + drop), (-r * 1.15, hy + drop)])
            elif hs == "long_wild":
                pts = [(-r * 1.1, hy)]
                n = 7
                for i in range(n + 1):
                    x = -r * 1.6 + i * (r * 3.2 / n)
                    pts.append((x, hy + drop * (0.75 if i % 2 else 1.0)))
                pts.append((r * 1.1, hy))
                self.poly(pts)
            elif hs == "ponytail_high":
                self.line([(-r * 0.5, self.top + r * 0.1), (-r * 1.4, self.top + r * 0.4), (-r * 1.6, hy + drop)], u * 0.42)
            elif hs == "twin_tails":
                for sgn in (-1, 1):
                    self.line([(sgn * r * 0.85, self.top + r * 0.5), (sgn * r * 1.8, hy + drop * 0.4), (sgn * r * 1.6, hy + drop)], u * 0.36)
            elif hs == "braid_side":
                self.line([(r * 0.8, hy), (r * 1.15, hy + drop * 0.5), (r * 0.9, hy + drop)], u * 0.24)
            return
        # front: the head, then the hair mass over it
        if hs == "hidden":
            return
        if hs == "spiky":
            pts = []
            for i in range(9):
                a = math.pi * (1.05 + i * 0.112)
                rr = r * (1.55 if i % 2 == 0 else 1.05)
                pts.append((math.cos(a) * rr, hy + math.sin(a) * rr))
            pts.append((r * 1.0, hy + r * 0.2))
            pts.append((-r * 1.0, hy + r * 0.2))
            self.poly(pts)
        elif hs == "bob":
            self.poly([(-r * 1.2, hy - r * 0.2), (0, hy - r * 1.25), (r * 1.2, hy - r * 0.2), (r * 1.2, hy + r * 1.0), (-r * 1.2, hy + r * 1.0)])
        elif hs == "fringe_heavy":
            self.ell(0, hy - r * 0.2, r * 1.3, r * 1.15)
        elif hs == "bun":
            self.ell(0, hy - r * 0.05, r * 1.08, r * 1.05)
            self.ell(0, self.top - r * 0.35, r * 0.62, r * 0.55)
        elif hs == "topknot":
            self.ell(0, hy - r * 0.05, r * 1.04, r * 1.02)
            self.line([(0, self.top), (r * 0.15, self.top - r * 1.0)], u * 0.26)
        elif hs == "undercut":
            self.poly([(-r * 1.0, hy), (-r * 0.9, self.top - r * 0.45), (r * 1.15, self.top - r * 0.6), (r * 1.05, hy)])
        elif hs == "curly":
            for a in range(0, 360, 40):
                ang = math.radians(a)
                self.ell(math.cos(ang) * r * 0.95, hy - r * 0.15 + math.sin(ang) * r * 0.9, r * 0.45, r * 0.45)
        else:  # cap_short and the long styles' crown
            self.ell(0, hy - r * 0.08, r * 1.1, r * 1.08)
        hw = s["headwear"]
        if hw == "kasa_hat":
            self.poly([(-r * 3.1, self.top + r * 0.35), (0, self.top - r * 0.9), (r * 3.1, self.top + r * 0.35)])
        elif hw == "hood_up":
            self.ell(0, hy, r * 1.45, r * 1.35)
            self.poly([(-r * 1.4, hy), (r * 1.4, hy), (self.sh_w * 0.9, self.shoulder_y), (-self.sh_w * 0.9, self.shoulder_y)])
        elif hw == "ribbon_bow":
            for sgn in (-1, 1):
                self.poly([(0, self.top - r * 0.2), (sgn * r * 1.2, self.top - r * 0.9), (sgn * r * 1.15, self.top + r * 0.3)])
        elif hw == "cap":
            self.ell(0, self.top + r * 0.45, r * 1.15, r * 0.7)
            self.poly([(r * 0.6, self.top + r * 0.65), (r * 2.0, self.top + r * 0.85), (r * 0.6, self.top + r * 0.95)])
        elif hw == "horned_helm":
            self.ell(0, hy - r * 0.05, r * 1.2, r * 1.15)
            for sgn in (-1, 1):
                self.poly([(sgn * r * 0.7, self.top + r * 0.2), (sgn * r * 2.0, self.top - r * 1.1), (sgn * r * 1.1, self.top + r * 0.5)])
        elif hw == "flower_pin":
            self.ell(r * 1.05, self.top + r * 0.35, r * 0.38, r * 0.38)

    def head(self):
        self.ell(0, self.top + self.head_r, self.head_r * 0.92, self.head_r)
        self.hair(back=False)

    def front_items(self):
        s, u = self.s, self.u
        w = s["weapon"]
        if w == "katana_hip":
            self.line([(self.hip_w * 0.7, self.waist_y + u * 0.1), (-self.hip_w * 2.6, self.hip_y + u * 1.2)], u * 0.15)
        elif w == "dual_hip":
            for sgn in (-1, 1):
                self.line([(sgn * self.hip_w * 0.8, self.waist_y + u * 0.2), (sgn * self.hip_w * 2.0, self.hip_y + u * 1.0)], u * 0.13)
        elif w == "dagger_belt":
            self.line([(self.hip_w * 1.0, self.waist_y + u * 0.1), (self.hip_w * 1.25, self.hip_y + u * 0.35)], u * 0.12)
        elif w == "staff":
            self.line([(self.sh_w * 2.0, self.top - u * 0.9), (self.sh_w * 2.0, GROUND)], u * 0.17)
            self.ell(self.sh_w * 2.0, self.top - u * 0.9, u * 0.3, u * 0.3)
        if s["accent"] == "tassels":
            for sgn in (-1, 1):
                self.line([(sgn * self.hip_w * 0.9, self.waist_y), (sgn * self.hip_w * 1.0, self.hip_y + u * 0.8)], u * 0.1)
        if s["accent"] == "belt_pouches":
            for sgn in (-1, 1):
                self.ell(sgn * self.hip_w * 1.05, self.waist_y + u * 0.35, u * 0.26, u * 0.3)


def mask(fig):
    """The figure as a set of opaque pixels, aligned on the feet and the body centre."""
    px = fig.load()
    return {(x, y) for y in range(H) for x in range(W) if px[x, y] < 128}


def iou(a, b):
    return len(a & b) / max(1, len(a | b))


def sheet(entries, family, cats, title):
    cols = 10
    rows = (len(entries) + cols - 1) // cols
    pad, lab = 6, 46
    tw, th = W // 2 + pad, H // 2 + lab
    img = Image.new("RGB", (cols * tw + pad, rows * th + 70), (232, 228, 236))
    d = ImageDraw.Draw(img)
    try:
        f1 = ImageFont.truetype("DejaVuSans-Bold.ttf", 22)
        f2 = ImageFont.truetype("DejaVuSans.ttf", 11)
    except OSError:
        f1 = f2 = ImageFont.load_default()
    d.text((pad + 4, 12), title, fill=(40, 30, 60), font=f1)
    d.text((pad + 4, 42), "Data/Characters/silhouettes.json · drawn by Tools/characters/silhouettes.py · columns: the 10 categories", fill=(90, 80, 110), font=f2)
    for i, (e, fig) in enumerate(entries):
        c, r = cats.index(e["category"]), i % 3
        x0, y0 = pad + c * tw, 70 + r * th
        small = fig.resize((W // 2, H // 2), Image.LANCZOS)
        tile = Image.new("RGB", small.size, (250, 248, 252))
        tile.paste((24, 18, 34), mask=small.point(lambda v: 255 - v))
        img.paste(tile, (x0, y0))
        d.text((x0 + 2, y0 + H // 2 + 2), e["id"].replace("sil_", ""), fill=(60, 50, 80), font=f2)
        name = e["name"] if len(e["name"]) <= 20 else e["name"][:19] + "…"
        d.text((x0 + 2, y0 + H // 2 + 16), name, fill=(30, 25, 40), font=f2)
    return img


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--check-only", action="store_true")
    ap.add_argument("--max-iou", type=float, default=0.85, help="two outlines overlapping more than this are too alike")
    ap.add_argument("--out", default=OUT)
    a = ap.parse_args()
    data = json.load(open(DATA, encoding="utf-8"))
    cats = [c["id"] for c in data["categories"]]
    worst_all, fails = [], 0
    for family, title in (("feminine", "AETHWYRD silhouette library · female family (30)"), ("masculine", "AETHWYRD silhouette library · male family (30)")):
        es = sorted([e for e in data["silhouettes"] if e["family"] == family], key=lambda e: (cats.index(e["category"]), e["id"]))
        figs = [(e, Fig(e["shape"], family).draw()) for e in es]
        masks = [mask(f) for _, f in figs]
        pairs = []
        for i in range(len(es)):
            for j in range(i + 1, len(es)):
                pairs.append((iou(masks[i], masks[j]), es[i]["id"], es[j]["id"]))
        pairs.sort(reverse=True)
        mean = sum(p[0] for p in pairs) / len(pairs)
        bad = [p for p in pairs if p[0] > a.max_iou]
        fails += len(bad)
        print(f"{family}: {len(es)} silhouettes, {len(pairs)} pairs, mean overlap {mean:.2f}, most alike {pairs[0][1]}/{pairs[0][2]} at {pairs[0][0]:.2f}, pairs above {a.max_iou}: {len(bad)}")
        for p in pairs[:5]:
            print(f"   {p[1]} ~ {p[2]}  {p[0]:.2f}")
        worst_all.append(pairs[0])
        if not a.check_only:
            os.makedirs(a.out, exist_ok=True)
            sheet(figs, family, cats, title).save(os.path.join(a.out, f"silhouettes_{family}.png"), optimize=True)
    if not a.check_only:
        print("wrote", os.path.relpath(a.out, ROOT))
    sys.exit(1 if fails else 0)


if __name__ == "__main__":
    main()
