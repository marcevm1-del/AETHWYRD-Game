"""
Regional building styles.

A *family* is an architectural tradition: how walls are built, the roof form and covering, windows, doors, footings,
ornaments and a palette. A *region* (one per gazetteer entry in 10_World/gazetteer.md) picks a family and overrides
whatever makes it its own (colours, snow, ruin, extra ornaments). `resolve(region)` merges the two into a Style.

Palette keys used by the generator:
  wall_a..wall_e   wall paint / plaster / board variants      trim, trim_dark   timber, frames, posts
  stone, stone_dark, mortar   masonry                          roof_a..roof_d    roof coverings
  roof_under       roof deck and fascia                        ridge             ridge caps
  door, frame, shutter, glass, lamp, metal, accent, accent_b   cloth_a, cloth_b  banners, awnings, canvas
  water            fountain, well and trough water (never "glass": windows and water stay separate, review N1)
  roof_copper      copper roofs and cones (dwarven granary silo)   banner_field  a banner's field when the style sets it
  leaf, moss, flower_a..flower_d, snow, glow (runes, crystals), gold, ground
A key may carry a tone suffix: "stone~1" is a darker shade of stone, ~2 lighter, ~3 slightly darker, ~4 slightly lighter.
"""
import copy

TONES = {1: 0.82, 2: 1.12, 3: 0.92, 4: 1.05}

BASE_PALETTE = {
    "wall_a": (0.93, 0.86, 0.70), "wall_b": (0.95, 0.80, 0.62), "wall_c": (0.93, 0.72, 0.70), "wall_d": (0.72, 0.82, 0.90),
    "wall_e": (0.74, 0.88, 0.78), "trim": (0.30, 0.18, 0.10), "trim_dark": (0.18, 0.11, 0.07), "stone": (0.62, 0.60, 0.56),
    "stone_dark": (0.42, 0.40, 0.38), "mortar": (0.50, 0.48, 0.44), "roof_a": (0.20, 0.42, 0.72), "roof_b": (0.80, 0.30, 0.18),
    "roof_c": (0.28, 0.55, 0.30), "roof_d": (0.36, 0.40, 0.48), "roof_under": (0.20, 0.14, 0.10), "ridge": (0.26, 0.22, 0.22),
    "door": (0.42, 0.24, 0.12), "frame": (0.32, 0.20, 0.11), "shutter": (0.20, 0.45, 0.70), "glass": (0.55, 0.72, 0.82),
    "lamp": (1.00, 0.72, 0.32), "metal": (0.18, 0.18, 0.20), "accent": (0.75, 0.25, 0.20), "accent_b": (0.95, 0.78, 0.30),
    "cloth_a": (0.82, 0.24, 0.24), "cloth_b": (0.95, 0.82, 0.38), "leaf": (0.25, 0.55, 0.20), "moss": (0.30, 0.45, 0.18),
    "flower_a": (0.92, 0.22, 0.28), "flower_b": (0.98, 0.55, 0.75), "flower_c": (1.00, 0.85, 0.25), "flower_d": (0.45, 0.55, 0.95),
    "snow": (0.94, 0.96, 1.00), "glow": (0.35, 0.95, 0.90), "gold": (1.00, 0.76, 0.28), "ground": (0.45, 0.38, 0.28),
    "wood_light": (0.62, 0.45, 0.28), "thatch": (0.78, 0.62, 0.32),
    # lit window panes (emissive: the key contains "glow") and forge embers on chimney caps (emissive: "ember")
    "window_glow": (1.00, 0.72, 0.36), "ember": (1.00, 0.50, 0.12),
    # review N1: water has its own key in every family (#7FB3D0); review B1: copper cone #B87333
    "water": (0.50, 0.70, 0.82), "roof_copper": (0.48, 0.17, 0.03),  # copper as linear (#B87333 read as straw)
}

DEFAULTS = dict(
    label="", walls="plaster", ground_walls=None, wall_keys=("wall_a",), base="plinth", base_h=0.55,
    roof="gable", tower_roof="cone", round_roof="cone", pitch=50.0, overhang=0.45, cover="tile_flat",
    roof_keys=("roof_a",), ridge="tile", curve=0.0, window="shutter", door="plank", floor_h=2.9, jetty=0.0,
    chimney="stone", band="beam", corner="post", extras=(), ruin=0.0, snow=False, remap={}, stilt_h=1.8,
    window_w=0.95, window_h=1.15, parapet=False, palette={},
    # window_glass: the palette key for window panes ("window_glow" lights them). banner_scale: banner size factor.
    # cover_mix: (cover, roof_key, chance, ridge) gives that share of a region's buildings another roof covering.
    window_glass="glass", banner_scale=1.0, cover_mix=None,
    # ember_cap: forge chimneys carry a glowing coal bed and grate instead of the plain lamp slab (Iron Hold).
    ember_cap=False,
    # forge_mouth: the smithy's hearth shows a 1.2 x 0.8 m glowing mouth in its open bay (Iron Hold, review B3).
    forge_mouth=False,
    # banner_keys: (field, charge) palette keys of every banner. facade_banner_cap: most facade banners per front.
    # facade_banner_min_area: no facade banners on a block whose footprint is under this many m2 (review N6).
    banner_keys=("cloth_a", "cloth_b"), facade_banner_cap=2, facade_banner_min_area=0.0,
)

FAMILIES = {
    # ---- the heartland ------------------------------------------------------------------------------------------
    "storybook": dict(
        label="Storybook half-timber (anime pastoral)", walls="timber_frame", ground_walls="timber_frame",
        wall_keys=("wall_a", "wall_b", "wall_c", "wall_d", "wall_e"), base="plinth", roof="gable", pitch=54,
        cover="tile_flat", roof_keys=("roof_a", "roof_b", "roof_c", "roof_d"), ridge="tile", window="shutter",
        door="arched", jetty=0.22, chimney="stone", band="beam", corner="post",
        extras=("flower_boxes", "lanterns", "weathervane", "ivy"),
    ),
    "fenland": dict(
        label="Fen stilt village (weathered boards, reed thatch)", walls="board", wall_keys=("wall_a", "wall_b", "wall_c"),
        base="stilts", stilt_h=1.9, roof="gable", pitch=52, cover="thatch", roof_keys=("roof_a", "roof_b"), ridge="roll",
        window="shutter", door="plank", chimney="pipe", band="beam", corner="post", extras=("lanterns", "moss", "ropes"),
        palette={"wall_a": (0.46, 0.41, 0.34), "wall_b": (0.38, 0.34, 0.29), "wall_c": (0.52, 0.46, 0.36),
                 "roof_a": (0.62, 0.55, 0.36), "roof_b": (0.46, 0.50, 0.30), "trim": (0.24, 0.20, 0.16),
                 "shutter": (0.32, 0.45, 0.36), "lamp": (0.75, 1.0, 0.55), "stone": (0.40, 0.42, 0.38)},
    ),
    "elven": dict(
        label="Elven living wood (leaf-scale roofs)", walls="living", wall_keys=("wall_a", "wall_b"), base="platform",
        base_h=0.7, roof="curved", tower_roof="onion", round_roof="onion", pitch=58, curve=0.55, overhang=0.6,
        cover="leaf", roof_keys=("roof_a", "roof_b", "roof_c"), ridge="none", window="round", door="round",
        chimney="none", band="none", corner="column", extras=("vines", "crystals", "lanterns"),
        palette={"wall_a": (0.86, 0.80, 0.64), "wall_b": (0.78, 0.72, 0.58), "trim": (0.42, 0.30, 0.20),
                 "trim_dark": (0.30, 0.22, 0.15), "roof_a": (0.30, 0.62, 0.36), "roof_b": (0.24, 0.55, 0.52),
                 "roof_c": (0.78, 0.66, 0.30), "glass": (0.55, 0.95, 0.85), "lamp": (0.70, 1.0, 0.85),
                 "glow": (0.55, 1.0, 0.85), "stone": (0.70, 0.72, 0.66), "door": (0.46, 0.34, 0.22)},
    ),
    "mushroom": dict(
        label="Thimblefolk toadstools (leaf-thatched workshops)", walls="plaster", wall_keys=("wall_a", "wall_b"),
        base="none", roof="curved", curve=0.4, pitch=48, overhang=0.6, tower_roof="cap", round_roof="cap", cover="leaf",
        roof_keys=("leaf", "roof_b"), ridge="none", window="round", door="round", chimney="pipe", band="none",
        corner="none", extras=("spots", "tufts", "lanterns", "flower_boxes"),
        remap={"cottage": "mushroom_house", "house": "mushroom_house", "townhouse": "mushroom_tower",
               "shop": "mushroom_shop", "inn": "mushroom_cluster", "tavern": "mushroom_cluster",
               "guild_hall": "mushroom_cluster", "temple": "mushroom_tower", "watchtower": "mushroom_tower",
               "library": "mushroom_tower", "granary": "mushroom_house", "smithy": "mushroom_smithy",
               "barn": "mushroom_barn", "stable": "mushroom_stable", "gatehouse": "mushroom_gate",
               "wall_segment": "hedge_wall"},
        palette={"wall_a": (0.94, 0.90, 0.80), "wall_b": (0.90, 0.84, 0.70), "roof_a": (0.82, 0.18, 0.15),
                 "roof_b": (0.62, 0.36, 0.20), "roof_c": (0.55, 0.32, 0.62), "accent": (0.98, 0.96, 0.90),
                 "door": (0.50, 0.32, 0.18)},
    ),
    "lagoon": dict(
        label="Lagoon canal city (pastel stucco, barrel tiles)", walls="plaster", ground_walls="rusticated",
        wall_keys=("wall_a", "wall_b", "wall_c", "wall_d"), base="plinth", base_h=0.4, roof="hip", pitch=24,
        overhang=0.35, cover="barrel", roof_keys=("roof_a", "roof_b"), ridge="tile", window="arched", door="arched",
        floor_h=3.1, chimney="funnel", band="stone", corner="quoin", extras=("balconies", "flower_boxes", "awnings", "mooring_poles"),
        palette={"wall_a": (0.93, 0.66, 0.60), "wall_b": (0.94, 0.76, 0.46), "wall_c": (0.95, 0.86, 0.70),
                 "wall_d": (0.80, 0.46, 0.34), "stone": (0.90, 0.88, 0.82), "roof_a": (0.76, 0.38, 0.22),
                 "roof_b": (0.70, 0.44, 0.30), "shutter": (0.24, 0.46, 0.36), "frame": (0.88, 0.86, 0.80)},
    ),
    "steppe": dict(
        label="Wind-plains (felt yurts, stone forts)", walls="rubble", wall_keys=("wall_a", "wall_b"), base="plinth",
        base_h=0.3, roof="gable", pitch=30, cover="plank", roof_keys=("roof_a", "roof_b"), ridge="board", round_roof="yurt",
        window="slit", door="double", chimney="none", band="beam", corner="post",
        extras=("banners", "ropes", "cloth_bands", "facade_banners"), banner_scale=2.0,
        facade_banner_cap=1, facade_banner_min_area=40.0,  # review N6: 1 per front, none under 40 m2 (yurts keep their pole banner)
        remap={"cottage": "yurt", "house": "yurt_large"},
        # red cloth_a / blue cloth_b bands on eaves and door frames of every building, banners 2x, stone #B8A58A
        palette={"wall_a": (0.76, 0.68, 0.55), "wall_b": (0.68, 0.61, 0.50), "stone": (0.72, 0.65, 0.54),
                 "roof_a": (0.45, 0.33, 0.22), "roof_b": (0.38, 0.30, 0.22), "cloth_a": (0.78, 0.20, 0.14),
                 "cloth_b": (0.20, 0.36, 0.66), "accent": (0.90, 0.86, 0.76)},
    ),
    "dwarven": dict(
        label="Dwarven basalt halls (runes and bronze)", walls="ashlar", wall_keys=("stone",), base="plinth", base_h=0.8,
        roof="hip", tower_roof="pyramid", pitch=32, overhang=0.3, cover="slate", roof_keys=("roof_a", "roof_b"),
        ridge="tile", window="slit", door="double", floor_h=3.3, chimney="forge", band="stone", corner="quoin",
        extras=("runes", "lanterns", "buttresses"),
        palette={"stone": (0.27, 0.26, 0.29), "stone_dark": (0.18, 0.17, 0.19), "mortar": (0.14, 0.13, 0.15),
                 "roof_a": (0.30, 0.30, 0.34), "roof_b": (0.55, 0.36, 0.22), "trim": (0.72, 0.45, 0.20),
                 "frame": (0.72, 0.45, 0.20), "door": (0.30, 0.22, 0.16), "glow": (1.0, 0.55, 0.15),
                 "lamp": (1.0, 0.60, 0.20), "glass": (0.95, 0.55, 0.20)},
    ),
    "whitestone": dict(
        label="White-stone duchies (ashlar, slate, arches)", walls="ashlar", wall_keys=("stone",), base="plinth",
        base_h=0.5, roof="hip", tower_roof="cone", pitch=50, overhang=0.35, cover="slate", roof_keys=("roof_a", "roof_b"),
        ridge="tile", window="arched", door="arched", floor_h=3.2, chimney="stone", band="stone", corner="quoin",
        extras=("banners", "flower_boxes", "finials"),
        palette={"stone": (0.90, 0.88, 0.82), "stone_dark": (0.74, 0.72, 0.66), "mortar": (0.70, 0.68, 0.62),
                 "roof_a": (0.30, 0.36, 0.46), "roof_b": (0.26, 0.30, 0.36), "frame": (0.22, 0.24, 0.30),
                 "shutter": (0.22, 0.32, 0.55), "cloth_a": (0.20, 0.34, 0.68), "cloth_b": (0.95, 0.80, 0.35)},
    ),
    # ---- the eastern lands --------------------------------------------------------------------------------------
    "hoshizora": dict(
        label="Star-sky cedar halls (curved tiled roofs)", walls="post_panel", wall_keys=("wall_a",), base="platform",
        base_h=0.7, roof="curved", tower_roof="curved", round_roof="curved", pitch=38, curve=0.6, overhang=0.9,
        cover="barrel", roof_keys=("roof_a", "roof_b"), ridge="raised", window="lattice", door="sliding", floor_h=3.0,
        chimney="none", band="beam", corner="column", extras=("paper_lanterns", "noren"),
        remap={"temple": "pagoda", "gatehouse": "torii_gate", "granary": "kura"},  # kura: raised white storehouse (B1)
        palette={"wall_a": (0.95, 0.93, 0.88), "trim": (0.26, 0.16, 0.10), "trim_dark": (0.16, 0.10, 0.07),
                 "roof_a": (0.24, 0.28, 0.34), "roof_b": (0.42, 0.30, 0.22), "stone": (0.66, 0.64, 0.60),
                 "accent": (0.85, 0.22, 0.12), "cloth_a": (0.18, 0.24, 0.42), "lamp": (1.0, 0.425, 0.119),  # glow sat >= 50%
                 "frame": (0.30, 0.20, 0.12), "glass": (0.96, 0.92, 0.82)},
    ),
    "shenlu": dict(
        label="Hundred-stair sect halls (red columns, glazed tiles)", walls="post_panel", wall_keys=("wall_a",),
        base="platform", base_h=0.9, roof="curved", tower_roof="curved", round_roof="curved", pitch=36, curve=0.85,
        overhang=1.0, cover="barrel", roof_keys=("roof_a", "roof_b"), ridge="raised", window="lattice", door="double",
        floor_h=3.2, chimney="none", band="beam", corner="column", extras=("paper_lanterns", "banners"),
        remap={"temple": "pagoda", "gatehouse": "paifang_gate"},
        palette={"wall_a": (0.94, 0.90, 0.82), "trim": (0.72, 0.14, 0.10), "trim_dark": (0.45, 0.10, 0.08),
                 "roof_a": (0.18, 0.46, 0.34), "roof_b": (0.86, 0.66, 0.20), "stone": (0.86, 0.85, 0.80),
                 "frame": (0.55, 0.12, 0.09), "accent": (0.18, 0.46, 0.55), "lamp": (1.0, 0.45, 0.25),
                 "cloth_a": (0.80, 0.16, 0.12), "glass": (0.96, 0.90, 0.75)},
    ),
    "haneul": dict(
        label="Sky-gate hanok (dancheong beams, grey tiles)", walls="post_panel", wall_keys=("wall_a",), base="platform",
        base_h=0.8, roof="curved", tower_roof="curved", round_roof="curved", pitch=34, curve=0.5, overhang=1.0,
        cover="barrel", roof_keys=("roof_a",), ridge="raised", window="lattice", door="sliding", floor_h=3.0,
        chimney="none", band="beam", corner="column", extras=("paper_lanterns", "dancheong"),
        remap={"gatehouse": "torii_gate"},
        palette={"wall_a": (0.95, 0.94, 0.90), "trim": (0.58, 0.20, 0.14), "trim_dark": (0.20, 0.50, 0.46),
                 "roof_a": (0.30, 0.31, 0.34), "stone": (0.72, 0.70, 0.66), "accent": (0.20, 0.52, 0.48),
                 "accent_b": (0.95, 0.75, 0.25), "frame": (0.40, 0.24, 0.14), "glass": (0.96, 0.93, 0.85)},
    ),
    # ---- the north ----------------------------------------------------------------------------------------------
    "nordic": dict(
        label="Fjord longhouses (logs, turf roofs, dragon boards)", walls="log", wall_keys=("wall_a", "wall_b"),
        base="plinth", base_h=0.45, roof="gable", pitch=42, overhang=0.4, cover="turf", roof_keys=("roof_a",),
        ridge="dragon", window="shutter", door="plank", chimney="none", band="none", corner="log_ends",
        extras=("snow", "lanterns", "carvings"), snow=True,
        remap={"house": "longhouse", "inn": "longhouse_hall"},
        palette={"wall_a": (0.40, 0.27, 0.18), "wall_b": (0.34, 0.24, 0.17), "trim": (0.26, 0.17, 0.11),
                 "roof_a": (0.36, 0.48, 0.26), "stone": (0.45, 0.46, 0.48), "shutter": (0.60, 0.20, 0.16),
                 "accent": (0.70, 0.22, 0.18), "door": (0.30, 0.20, 0.13)},
    ),
    # ---- the south and the deserts ------------------------------------------------------------------------------
    "desert": dict(
        label="Glass-desert adobe (flat roofs, domes, vigas)", walls="adobe", wall_keys=("wall_a", "wall_b", "wall_c"),
        base="none", roof="flat", tower_roof="dome", round_roof="dome", parapet=True, cover="plaster",
        roof_keys=("roof_a",), ridge="none", window="horseshoe", door="arched", floor_h=3.1, chimney="none", band="none",
        corner="none", extras=("vigas", "awnings", "pots"),
        # domes only on civic and temple types (<= 1 in 4): towers of guild/town hall and library, domed_hall, and
        # the remapped temple and bathhouse below. Flat roofs no longer get a dome each.
        remap={"temple": "domed_temple", "bathhouse": "domed_bathhouse"},
        palette={"wall_a": (0.88, 0.72, 0.52), "wall_b": (0.82, 0.62, 0.44), "wall_c": (0.92, 0.82, 0.66),
                 "roof_a": (0.94, 0.90, 0.82), "trim": (0.42, 0.28, 0.16), "shutter": (0.14, 0.55, 0.66),
                 "door": (0.20, 0.40, 0.55), "cloth_a": (0.86, 0.36, 0.20), "cloth_b": (0.95, 0.88, 0.70),
                 "frame": (0.40, 0.26, 0.14)},
    ),
    "garden": dict(
        label="Garden cities (ochre brick, turquoise domes, iwans)", walls="brick", wall_keys=("wall_a",), base="plinth",
        base_h=0.45, roof="flat", tower_roof="onion", round_roof="dome", parapet=True, cover="glaze",
        roof_keys=("roof_a", "roof_b"), ridge="none", window="pointed", door="pointed", floor_h=3.3, chimney="none",
        band="tile", corner="column", extras=("tile_bands", "finials", "fountains"),
        remap={"temple": "domed_temple", "bathhouse": "domed_bathhouse"},  # onions on civic and temple types only
        palette={"wall_a": (0.84, 0.66, 0.44), "stone": (0.84, 0.66, 0.44), "mortar": (0.92, 0.86, 0.74),
                 "roof_a": (0.10, 0.56, 0.62), "roof_b": (0.12, 0.30, 0.62), "accent": (0.10, 0.56, 0.62),
                 "accent_b": (0.95, 0.92, 0.85), "trim": (0.12, 0.30, 0.62), "frame": (0.10, 0.40, 0.50),
                 "door": (0.36, 0.22, 0.12)},
    ),
    "coastal": dict(
        label="Salvage coast (ship timber, clapboard, stilts)", walls="clapboard", wall_keys=("wall_a", "wall_b", "wall_c"),
        base="stilts", stilt_h=1.4, roof="gable", pitch=40, cover="shingle", roof_keys=("roof_a", "roof_b"),
        ridge="board", window="porthole", door="plank", chimney="pipe", band="beam", corner="post",
        extras=("ropes", "nets", "lanterns", "buoys"), remap={"temple": "lighthouse"},
        palette={"wall_a": (0.92, 0.92, 0.88), "wall_b": (0.36, 0.56, 0.70), "wall_c": (0.48, 0.38, 0.30),
                 "roof_a": (0.30, 0.38, 0.46), "roof_b": (0.66, 0.26, 0.20), "trim": (0.30, 0.24, 0.20),
                 "frame": (0.92, 0.92, 0.88), "shutter": (0.30, 0.50, 0.66), "accent": (0.85, 0.30, 0.20)},
    ),
    "jungle": dict(
        label="Temple jungle (carved stone, palm thatch)", walls="carved", wall_keys=("wall_a", "wall_b"), base="terrace",
        base_h=1.0, roof="hip", tower_roof="pyramid", pitch=56, overhang=0.7, cover="thatch", roof_keys=("roof_a", "roof_b"),
        ridge="roll", window="trapezoid", door="trapezoid", chimney="none", band="stone", corner="none",
        extras=("vines", "flower_boxes", "moss", "painted_bands"), remap={"temple": "stepped_pyramid"},
        palette={"wall_a": (0.76, 0.70, 0.56), "wall_b": (0.70, 0.64, 0.52), "stone": (0.70, 0.66, 0.54),
                 "roof_a": (0.70, 0.56, 0.30), "roof_b": (0.58, 0.50, 0.28), "accent": (0.10, 0.62, 0.60),
                 "accent_b": (0.86, 0.26, 0.20), "trim": (0.40, 0.30, 0.20)},
    ),
    "andean": dict(
        label="Carved-mountain terraces (fitted stone, steep thatch)", walls="fitted", wall_keys=("stone",), base="terrace",
        base_h=0.8, roof="gable", pitch=60, overhang=0.35, cover="thatch", roof_keys=("roof_a",), ridge="roll",
        window="trapezoid", door="trapezoid", chimney="none", band="none", corner="none", extras=("textiles", "tufts"),
        palette={"stone": (0.62, 0.57, 0.50), "stone_dark": (0.50, 0.46, 0.40), "mortar": (0.40, 0.37, 0.33),
                 "roof_a": (0.82, 0.70, 0.40), "cloth_a": (0.82, 0.18, 0.20), "cloth_b": (0.95, 0.70, 0.15),
                 "accent": (0.20, 0.45, 0.70), "trim": (0.40, 0.30, 0.20)},
    ),
    # ---- the made and the strange -------------------------------------------------------------------------------
    "clockwork": dict(
        label="Clockwork tiers (brick, brass, copper roofs)", walls="brick", wall_keys=("wall_a",), base="plinth",
        base_h=0.5, roof="gable", tower_roof="dome", pitch=46, overhang=0.35, cover="metal", roof_keys=("roof_a", "roof_b"),
        ridge="board", window="arched", door="double", floor_h=3.2, chimney="brick", band="stone", corner="quoin",
        extras=("pipes", "gears", "lanterns", "rivets"),
        palette={"wall_a": (0.62, 0.28, 0.20), "stone": (0.62, 0.28, 0.20), "mortar": (0.72, 0.66, 0.58),
                 "stone_dark": (0.40, 0.36, 0.34), "roof_a": (0.35, 0.62, 0.55), "roof_b": (0.70, 0.42, 0.25),
                 "trim": (0.85, 0.62, 0.25), "metal": (0.85, 0.62, 0.25), "frame": (0.22, 0.20, 0.20),
                 "lamp": (1.0, 0.613, 0.119)},  # brass gas glow, linear; sRGB saturation 62% (style guide >= 50%)
    ),
    "gothic": dict(
        label="Dark spires (black stone, pointed arches, silk lanterns)", walls="ashlar", wall_keys=("stone",),
        base="plinth", base_h=0.6, roof="gable", tower_roof="spire", pitch=62, overhang=0.3, cover="slate",
        roof_keys=("roof_a", "roof_b"), ridge="tile", window="pointed", door="pointed", floor_h=3.3, chimney="stone",
        band="stone", corner="buttress", extras=("lanterns", "finials", "webs"), window_glass="window_glow",
        palette={"stone": (0.30, 0.27, 0.34), "stone_dark": (0.20, 0.18, 0.23), "mortar": (0.16, 0.15, 0.18),
                 "roof_a": (0.24, 0.20, 0.30), "roof_b": (0.18, 0.16, 0.22), "glass": (0.70, 0.45, 1.0),
                 "lamp": (0.78, 0.48, 1.0), "frame": (0.16, 0.14, 0.18), "door": (0.25, 0.14, 0.18),
                 "cloth_a": (0.45, 0.18, 0.55), "glow": (0.78, 0.48, 1.0), "window_glow": (0.78, 0.48, 1.0)},
    ),
    "celestial": dict(
        label="Heavenfolk marble (gold trim, domes, columns)", walls="ashlar", wall_keys=("stone",), base="platform",
        base_h=0.8, roof="flat", tower_roof="dome", round_roof="dome", parapet=True, cover="glaze", roof_keys=("roof_a",),
        ridge="none", window="arched", door="arched", floor_h=3.6, chimney="none", band="stone", corner="column",
        extras=("crystals", "finials", "domes", "wings"),
        palette={"stone": (0.95, 0.95, 0.97), "stone_dark": (0.82, 0.84, 0.88), "mortar": (0.86, 0.86, 0.90),
                 "roof_a": (0.62, 0.78, 0.95), "trim": (1.0, 0.78, 0.30), "frame": (1.0, 0.78, 0.30),
                 "glass": (0.62, 0.86, 1.0), "glow": (0.60, 0.88, 1.0), "door": (0.95, 0.88, 0.70)},
    ),
    "ancient": dict(
        label="Labyrinth stone (grey blocks, glowing runes)", walls="ashlar", wall_keys=("stone",), base="platform",
        base_h=0.5, roof="flat", tower_roof="pyramid", round_roof="dome", parapet=True, cover="slab", roof_keys=("stone",),
        ridge="none", window="slit", door="arched", floor_h=3.4, chimney="none", band="stone", corner="column",
        extras=("runes", "moss"), ruin=0.25,
        palette={"stone": (0.55, 0.56, 0.58), "stone_dark": (0.40, 0.41, 0.44), "mortar": (0.30, 0.31, 0.33),
                 "glow": (0.30, 0.92, 0.85), "lamp": (0.30, 0.92, 0.85), "frame": (0.40, 0.41, 0.44)},
    ),
}

# Region -> family plus overrides. Order and names follow 10_World/gazetteer.md.
REGIONS = {
    # Aldmere, the royal valley: ashlar ground floors, slate roofs dominant, royal blue #3357AD and gold banners,
    # finials on civic-sized buildings. Pitch 54, turrets and flower boxes stay (review P1).
    "aldmere": ("Aldmere", "storybook", dict(ground_walls="ashlar", cover="slate", roof_keys=("roof_d", "roof_d", "roof_a"),
                                            extras=("flower_boxes", "lanterns", "weathervane", "facade_banners", "civic_finials"), banner_scale=1.7,
                                            banner_keys=("banner_field", "cloth_a"),  # review B4: gold field #D9A833, blue charge
                                            palette={"roof_d": (0.30, 0.34, 0.42), "roof_a": (0.24, 0.36, 0.62),
                                                     "stone": (0.84, 0.81, 0.74), "stone_dark": (0.66, 0.63, 0.58),
                                                     "mortar": (0.62, 0.60, 0.56), "cloth_a": (0.20, 0.34, 0.68),
                                                     "cloth_b": (0.95, 0.78, 0.30), "banner_field": (0.85, 0.66, 0.20)})),
    # Whisperwood, the forest village: timber, moss and lanterns, thatch on 1 roof in 3, ivy, warmer plaster.
    "whisperwood": ("Whisperwood", "storybook", dict(
        extras=("flower_boxes", "lanterns", "weathervane", "ivy", "climbing_ivy", "moss", "facade_lanterns"),
        cover_mix=("thatch", "thatch", 1.0 / 3.0, "roll"),
        palette={"wall_a": (0.95, 0.85, 0.64), "wall_b": (0.96, 0.78, 0.55), "wall_c": (0.94, 0.73, 0.60),
                 "wall_d": (0.92, 0.82, 0.62), "wall_e": (0.86, 0.84, 0.62), "trim": (0.34, 0.20, 0.10),
                 "thatch": (0.76, 0.60, 0.30)})),
    # Greymoor: wall_c lifted to #8A7A62, two green lanterns (#BFFF8C) per house front, painted doors #4F7A6A.
    "greymoor": ("Greymoor", "fenland", dict(extras=("lanterns", "moss", "ropes", "facade_lanterns"),
                                            palette={"wall_c": (0.54, 0.48, 0.38), "door": (0.31, 0.48, 0.42),
                                                     "lamp": (0.388, 1.0, 0.119)})),  # #BFFF8C hue at 62% sRGB saturation, linear
    "labyrinth_upper": ("Great Labyrinth (Floors 1-40)", "ancient", {}),
    "labyrinth_deep": ("Great Labyrinth (Floors 41-90)", "ancient", dict(ruin=0.4, palette={"glow": (0.25, 0.75, 1.0), "stone": (0.36, 0.44, 0.48)})),
    "labyrinth_abyss": ("Great Labyrinth (Floors 91-120)", "ancient", dict(palette={"glow": (1.0, 0.92, 0.65), "stone": (0.30, 0.30, 0.34)})),
    "sylvaran": ("Sylvaran", "elven", {}),
    "mossdeep": ("Mossdeep", "mushroom", {}),
    "lirian": ("Lirian", "lagoon", {}),
    "fanghold": ("Fanghold", "steppe", {}),
    # Iron Hold (review B3): basalt kept; bronze bands 0.44 m (2x the old 0.22 band) replace the stone band; copper
    # roof_b on 1 roof in 3; forge-orange #FF8C26 on runes, windows and lamps; forge chimneys carry an ember cap
    # (construct.chimney). Region-only, so Dragon Spine keeps the plain dwarven family (review fix).
    "iron_hold": ("Iron Hold", "dwarven", dict(
        band="none", extras=("runes", "lanterns", "buttresses", "bronze_bands"), window_glass="window_glow",
        roof_keys=("roof_a", "roof_a", "roof_b"), ember_cap=True, forge_mouth=True,
        # review N1: dark, cool water #5E8FA8, so the fountain contrasts with the forge glow
        palette={"roof_b": (0.72, 0.45, 0.20), "window_glow": (1.0, 0.55, 0.15), "ember": (1.0, 0.55, 0.15),
                 "water": (0.37, 0.56, 0.66)})),
    "moraveil": ("Moraveil", "storybook", dict(palette={"wall_a": (0.92, 0.84, 0.62), "roof_a": (0.62, 0.36, 0.20)})),
    "strife_marches": ("Strife Marches", "storybook", dict(ground_walls="rubble", roof_keys=("roof_d", "roof_b"),
                                                          palette={"wall_a": (0.84, 0.80, 0.70), "wall_b": (0.80, 0.74, 0.64)})),
    "velmark": ("Velmark", "whitestone", {}),
    "hoshizora": ("Hoshizora", "hoshizora", {}),
    "kitsune_isles": ("Kitsune Isles", "hoshizora", dict(palette={"trim": (0.82, 0.22, 0.12), "roof_a": (0.28, 0.24, 0.30)})),
    "frostveil": ("Frostveil", "nordic", {}),
    "shen_lu": ("Shen-Lu", "shenlu", {}),
    "haneul": ("Haneul", "haneul", {}),
    "whitewater_reach": ("Whitewater Reach", "nordic", dict(cover="plank", palette={"wall_a": (0.50, 0.46, 0.42), "roof_a": (0.40, 0.42, 0.46)})),
    # Umbravel: stone #4C4557 -> #5A5068, lit violet windows (#C77AFF, family window_glow), warm amber silk lanterns
    # on every facade (ornaments.silk): review B3 puts the lamp back to #FFB852 (linear 1.0, 0.48, 0.09), one cool and
    # one warm light per facade.
    "umbravel": ("Umbravel", "gothic", dict(extras=("lanterns", "webs", "silk"),
                                            palette={"lamp": (1.0, 0.48, 0.09), "window_glow": (0.571, 0.195, 1.0), "stone": (0.35, 0.31, 0.41),
                                                     "stone_dark": (0.25, 0.22, 0.29), "mortar": (0.20, 0.18, 0.23)})),
    "sunscar": ("Sunscar", "desert", {}),
    "goldmere_coast": ("Goldmere Coast", "coastal", {}),
    "zarvan": ("Zarvan", "garden", {}),
    "zaruma": ("Zaruma", "desert", dict(remap={"watchtower": "adobe_tower", "temple": "adobe_mosque_hall"},
                                        palette={"wall_a": (0.74, 0.48, 0.32), "wall_b": (0.68, 0.44, 0.30), "wall_c": (0.80, 0.56, 0.38)})),
    "dunewhale_drift": ("Dunewhale Drift", "coastal", dict(base="stilts", cover="canvas", palette={"wall_a": (0.80, 0.70, 0.52), "roof_a": (0.92, 0.86, 0.70)})),
    "xochitl_mire": ("Xochitl Mire", "jungle", dict(base="stilts", extras=("flower_boxes", "painted_bands", "vines"))),
    "lumbaya": ("Lumbaya", "jungle", dict(ruin=0.2)),
    "stormreach": ("Stormreach", "whitestone", dict(cover="metal", extras=("lightning_rods", "lanterns"),
                                                  palette={"stone": (0.32, 0.33, 0.36), "roof_a": (0.45, 0.48, 0.50), "roof_b": (0.70, 0.42, 0.25)})),
    "true_name_isles": ("True-Name Isles", "coastal", dict(palette={"wall_a": (0.96, 0.95, 0.92), "roof_a": (0.22, 0.42, 0.66)})),
    "hollow_sea": ("Hollow Sea", "coastal", dict(palette={"wall_a": (0.30, 0.28, 0.26), "lamp": (0.35, 0.95, 0.80), "glass": (0.35, 0.95, 0.80)})),
    "ashira_vale": ("Ashira Vale", "storybook", dict(extras=("flower_boxes", "lanterns", "ivy", "bunting"))),
    "dragon_spine": ("Dragon Spine", "dwarven", dict(extras=("prayer_flags", "bone_ribs"), palette={"trim": (0.90, 0.86, 0.75), "cloth_a": (0.80, 0.20, 0.16)})),
    "sky_archipelago": ("Sky Archipelago", "celestial", dict(ruin=0.35)),
    "heavenreach": ("Heavenreach", "celestial", dict(snow=True, palette={"stone": (0.70, 0.72, 0.76)})),
    "vharlen": ("Vharlen", "whitestone", dict(palette={"stone": (0.60, 0.62, 0.64), "roof_a": (0.22, 0.24, 0.28), "cloth_a": (0.70, 0.14, 0.12)})),
    "gearholm": ("Gearholm", "clockwork", {}),
    "cinderhole": ("Cinderhole", "clockwork", dict(palette={"wall_a": (0.34, 0.25, 0.22), "stone": (0.34, 0.25, 0.22), "lamp": (1.0, 0.45, 0.15)})),
    "bastion": ("Bastion", "whitestone", dict(palette={"stone": (0.80, 0.72, 0.58), "roof_a": (0.55, 0.30, 0.22), "cloth_a": (0.70, 0.18, 0.14)})),
    "everdusk": ("Everdusk", "elven", dict(palette={"roof_a": (0.75, 0.50, 0.25), "roof_b": (0.55, 0.30, 0.45), "lamp": (1.0, 0.75, 0.40)})),
    "apu_highlands": ("Apu Highlands", "andean", {}),
    "lustrine_shores": ("Lustrine Shores", "coastal", dict(palette={"lamp": (0.65, 0.82, 1.0), "glass": (0.65, 0.82, 1.0)})),
    "quaking_lands": ("Quaking Lands", "fenland", dict(base="plinth", extras=("ropes", "lanterns"))),
    "aurumdeep": ("Aurumdeep", "whitestone", dict(ruin=0.3, palette={"stone": (0.82, 0.70, 0.45), "roof_a": (0.85, 0.62, 0.22)})),
    "nox_dominion": ("Nox Dominion", "gothic", dict(palette={"stone": (0.16, 0.14, 0.16), "glass": (1.0, 0.30, 0.15), "lamp": (1.0, 0.35, 0.15), "glow": (1.0, 0.35, 0.15), "window_glow": (1.0, 0.30, 0.15)})),
    "calamity_steppe": ("Calamity Steppe", "steppe", {}),
    "the_maw": ("The Maw", "steppe", dict(palette={"wall_a": (0.50, 0.44, 0.40)})),
    "root_of_the_world": ("Root of the World", "ancient", dict(extras=("runes", "crystals"), palette={"glow": (0.75, 0.85, 1.0)})),
    "vesper": ("Vesper", "ancient", dict(ruin=0.45, palette={"stone": (0.58, 0.26, 0.22), "glow": (1.0, 0.35, 0.30)})),
}


class Palette:
    def __init__(self, pid, colours):
        self.id = pid
        self.colours = colours

    def colour(self, key):
        base, _, tone = key.partition("~")
        c = self.colours.get(base) or BASE_PALETTE.get(base) or (1.0, 0.0, 1.0)
        f = TONES.get(int(tone), 1.0) if tone else 1.0
        return tuple(min(1.0, max(0.0, x * f)) for x in c)


class Style:
    """A family merged with a region's overrides. Attributes mirror DEFAULTS."""

    def __init__(self, region, family, params, palette):
        self.region = region
        self.family = family
        self.__dict__.update(params)
        self.extras = set(params.get("extras", ()))
        self.palette = palette

    def has(self, extra):
        return extra in self.extras


def resolve(region="whisperwood", family=None, overrides=None):
    """The Style for a region (or a bare family when region is None), with optional extra overrides."""
    if region:
        name, fam, ro = REGIONS[region]
    else:
        name, fam, ro = (family, family, {})
    fam = family or fam
    p = copy.deepcopy(DEFAULTS)
    p.update(copy.deepcopy(FAMILIES[fam]))
    pal = dict(BASE_PALETTE)
    pal.update(FAMILIES[fam].get("palette", {}))
    for k, v in ro.items():
        if k == "palette":
            pal.update(v)
        elif k == "remap":
            p["remap"] = dict(p.get("remap", {}), **v)
        else:
            p[k] = v
    for k, v in (overrides or {}).items():
        if k == "palette":
            pal.update(v)
        else:
            p[k] = v
    pid = region if (region and (ro.get("palette") or (overrides or {}).get("palette"))) else fam
    return Style(region or fam, fam, p, Palette(pid, pal))
