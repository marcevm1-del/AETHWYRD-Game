"""Review helpers: lay out rows of buildings per region for a quick visual check (used during development)."""
import bpy

from . import archetypes, generate, styles

ROW = ["cottage", "house", "shop", "inn", "temple", "watchtower"]


def clear(scene=None):
    sc = scene or bpy.context.scene
    for o in list(sc.objects):
        if "ab_archetype" in o:
            bpy.data.objects.remove(o)


def rows(regions, row=None, seed=3, spacing=24.0, detail="high"):
    out = []
    for j, rid in enumerate(regions):
        fam = styles.REGIONS[rid][1]
        items = list(row or ROW)
        for extra in archetypes.SIGNATURES.get(fam, [])[:2]:
            if extra not in items:
                items.append(extra)
        for i, a in enumerate(items):
            o = generate.building(a, rid, seed, detail, location=(i * spacing, -j * spacing * 1.2, 0))
            out.append(o)
    return out
