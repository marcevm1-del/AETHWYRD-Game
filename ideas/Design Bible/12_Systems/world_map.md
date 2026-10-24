# World Map (system)

> **Built (Ring 0).** Geography follows the atlas (`Tools/atlas/aetheria_atlas.html`) and `10_World/world_map_concept.md`. Map placement data lives in `Data/World/regions.json → map`, and the tuning in `Data/World/world_tuning.json → map`. The code is in Core (`WorldMapTerrain`, `WorldMapPainter`, `MapKnowledge`) and Unity (`PlayerMap`, `LocalMapArea`, `WorldMapWindow`, `MapArt`).

## 1. One map, three consumers

The coastline comes from a single function, the atlas's land field. It is ported to C# bit-for-bit, and tests pin it to values computed by the atlas's own JavaScript.

| Consumer | Uses |
|---|---|
| The atlas (browser) | its original JavaScript |
| The game | Core paints the map on a worker thread when the game loads (about 1–3 s, never on the main thread) |
| Review images / design canvas | `ASCEND_MAP=<folder> npm test` writes the painted, parchment and blank-paper PNGs |

Every surface land has an anchor (`map.at`, in a 150 × 100 grid with x east and y south), a `radius`, the `terrain` it paints and its towns' positions (`map.places`). Underworld regions mark their surface gate (`map.gate`). The Sky Archipelago `floats`. The validator checks that every defended town has a map position. The tests check four things:
- every land owns its own anchor;
- every town sits inside its own land;
- the isles are islands;
- the map's corners are sea.

## 2. The painted map

It has the following layers, all generated (no hand-painted art):
- **Relief:** a height field rises from the shore, with small hills everywhere and ridged noise where the land is rough (mountain, volcanic, tundra, demon). Light falls from the north-west.
- **Terrain colour:** a palette per terrain kind, blended softly across terrain and land edges, greyer high up and snowy on the highest peaks and in tundra. Coasts have a sandy rim.
- **Sea:** depth shading from the coastline outward, with three ripple lines echoing the coast.
- **Coastline:** inked, with sub-pixel edges.
- **Rivers:** start on high ground in wooded, mountain, tundra and swamp lands and walk downhill to the sea (the atlas's river walk).
- **Roads:** dashed, joining each mainland land to its two nearest neighbours.
- **Borders:** dotted lines between lands.
- **Symbols:** peaks on a coarse grid where the land is high (snow-capped, volcanic ones glowing); tree clusters in forest, jungle and spirit woods; dunes; reeds; snow hummocks; demon spikes; grass ticks. All drawn back to front.

Two looks come from the same geometry:
- **Painted (colour):** used for review and the canvas.
- **Parchment (ink and wash on paper):** the in-game map. It is painted over a **blank sheet** (fibres, stains, scorched edges), which is also kept on its own.

## 3. What the player's map shows (hud_and_ui.md §8)

"It starts blank. It inks itself as you explore." Each region is in one of three states:

| State | Shown as | How it happens |
|---|---|---|
| **Visited** | Fully inked, with towns, Tyrant and siege banner | You're in it: Whisperwood from the start; future regions on arrival |
| **Heard** | A grey pencil sketch with a faint italic name | Talk in Brindlewick (Aldmere, Greymoor, the Great Labyrinth); **accepting a quest** pencils in its region; **each guild rank's map seal** names the surface up to a ring (E→3, D→4, C→5, B→6, A→7) |
| **Unknown** | Blank parchment | Everything else |

Inked edges bleed raggedly into the paper, and the sea near known coasts is inked with them. Hearing never undoes a visit. The atlas's two **seas** (the Veiled Sea, west; the Sundered Sea, east; `world_tuning.json → map.seas`) get their names once a land within 30 units of the label is on your map.

**Labels** follow common cartography rules (checked against Mapbox's cartography guidance): you and the tracked objective are placed first, then land names (visited before heard), then siege banners, seas, towns and gates only where they fit without overlapping. Town names appear from 2.4× zoom, gate names from 2×. Names carry a parchment halo, and pencilled names keep 4.5:1 contrast on the paper. Siege state is written out as well as coloured.

**System overlay** (from Rank E, the guild map seal; hud_and_ui.md §16):
- every known land is tinted with its ring colour;
- a blue 10-unit grid is laid over the sheet;
- each label gets a ring and rank chip.

The **siege state** of visited lands shows as a red ⚑ (Besieged or Weakened) or a green ⚑ (Liberated). The current region's state comes live from the siege system.

## 4. The local Area map

The playable patch (`LocalMapArea`: a 200 m square around Brindlewick in Ring 0) is drawn from above by an orthographic camera, with characters hidden. The drawing is restyled as ink on parchment: levels stretched, Sobel edges inked, colour kept faint.

- **Fog:** a 4 m cell grid inks itself within 14 m of you as you walk. Explored cells are saved, compressed, with the region states (`SaveGame.Map`).
- **Markers** (only on inked ground): waystones (an attuned one glows in the region's siege colour, §28), people (a ! when they have a quest for you), named places, ready herb patches, pines and scrap heaps, and your coin lantern.
- **Always shown:** **you** (an arrow turned to your facing) and the **tracked objective** (★, clamped to the edge when off the sheet).
- **Also on the sheet:** a compass, a 20 m scale bar, and "Explored N%".

## 5. Controls

| Action | Keyboard / mouse | Gamepad |
|---|---|---|
| Open / close the map | Tab or M (Esc closes) | View (B closes) |
| Area / World page | 1 / 2 or click the tabs | LB / RB |
| Zoom (World) | Scroll, + / − | Triggers |
| Pan (World) | Drag, WASD, arrows | Left stick |
| Centre on you | C | R3 |
| System overlay | O | Y |
| Read a land | Hover with the mouse | The crosshair at the centre |

The Bag moved from View to **Menu** on the gamepad, so the map can take View as hud_and_ui.md §15 lists it. Under the minimap, the HUD shows the current region and "Tab: map".

## 6. Scale

One world-map unit is a kilometre, so the continent is about 150 × 100 km. The Ring 0 field is a fifth of a unit across, so "you are here" sits on Brindlewick. This is a **proposal**: travel time per unit is still open (world_map_concept.md §5).

## 7. Data mismatch to resolve

`regions.json` puts Brindlewick and Millbrook in **Whisperwood**, and the atlas does too. But most Ring 0 quests are filed under **reg_aldmere**, and world.md lists "Brindlewick & Meadows" as an Aldmere sub-zone. The map follows regions.json, so the area is Whisperwood and Aldmere is pencilled in as the neighbouring capital. One of the two should change (flagged in Canon §6).
