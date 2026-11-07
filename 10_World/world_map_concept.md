# World Map Concept

> **Source of truth for positions:** the atlas at `Tools/atlas/aetheria_atlas.html` (region anchors on a 150 × 100 grid, coastline seed 1207). `Data/World/regions.json` stays authoritative for each region's ring, ranks, Tyrant and settlements. This page reads the atlas as a map and checks the lore against it; it adds no new places.
> **In game:** `12_Systems/world_map.md` (the painted map, the inking parchment map and the local Area map).
> **Visual:** the design canvas *Aethwyrd World Map Concept* (claude.ai/artifact/GFrTTqADaot19C1719p4sE): the surface rendered from the atlas's own terrain, a heartland inset and an Underworld cross-section.

## 1. The big shape (as the atlas draws it)

- **One continent** with a ragged coast; only the **Kitsune Isles** (north-east) and the **True-Name Isles** (east) lie offshore. The **Sky Archipelago** floats beyond the north-east coast and **Vesper** (R9) is the red moon.
- **The heartland is in the middle:** Aldmere (R2) at the centre with the Labyrinth gate just north-west of its anchor, Whisperwood (R1) south-east of it holding **Brindlewick** and **Millbrook**, and Greymoor (R2) further south-east.
- **Danger rises outward:** Ring 3 (Sylvaran, Mossdeep, Lirian) hugs the heartland; Ring 4 (Fanghold, Moraveil, Iron Hold, Velmark, Strife Marches) circles it; Rings 5–7 fill the coasts.
- **North:** a snow belt (Frostveil, Whitewater Reach) with Cinderhole and the Dragon Spine's volcanic peaks below it; Shen-Lu and Haneul in the north-east mountains; Heavenreach at the north-east tip.
- **East coast:** Hoshizora, Lirian's canal cities, Gearholm, the Strife Marches and the Goldmere Coast.
- **South:** desert kingdoms (Sunscar, Zaruma, Zarvan, Dunewhale Drift) and the Lustrine Shores and Quaking Lands in the south-east.
- **West:** the hostile side. Vharlen, Bastion and Stormreach face the **Calamity Steppe** (R8) and the **Nox Dominion** (R8) in the north-west corner; Everdusk, Ashira Vale, Xochitl Mire, Lumbaya and the Apu Highlands run down the south-west.

## 2. Underworld gates (atlas anchors)

| Gate | Surface position | Reaches |
|---|---|---|
| Great Labyrinth | just north-west of Aldmere's centre | floors 1–120 |
| Umbravel | south of Mossdeep | layer 1 |
| Hollow Sea | beside the Goldmere Coast | layer 2 |
| Aurumdeep | under Zarvan | layer 3 |
| The Maw | west coast, next to the Calamity Steppe | layer 4 |
| Root of the World | in Whisperwood, beside Brindlewick | layer 5 |

The Root of the World's gate sitting in the starting forest is a strong story hook. The deepest place in the world is reachable from the first region, but only at the end.

## 3. The five corridors checked against the atlas

`02_Lore/history.md` §XX.b says there are six corridors but describes five. All five fit the atlas:

1. **River and grain:** Brindlewick → Aldmere → Velmark → the Lirian coast.
2. **Mountain craft and oath:** Aldmere → Iron Hold → Cinderhole → the Dragon Spine.
3. **Sanctuary and memorial:** Aldmere → Sylvaran → Ashira Vale (the Gentle Warden's vale).
4. **Coastal weather and navigation:** Lirian → Goldmere Coast, then by sea to the True-Name Isles.
5. **Desert glass and caravan:** Mossdeep → Sunscar, then Zaruma, Zarvan and the Dunewhale Drift.

## 4. Heartland inset

Brindlewick (F, built) sits in western Whisperwood. Millbrook is east on the stream. Aldmere City and the Labyrinth gate are north-west, with Ashby, the Royal Valley farms and Greyhollow (village, Keep and barrows, where Ashgrave rides out) around it. The Hollowpine Highlands lie north-east toward Velmark and Iron Hold. Greymoor Marsh and its Walking Hut market are south-east.

The in-game Ring 0 scene (Whisperwood field north of Brindlewick, North Gate) is a local close-up and doesn't contradict this. It is the patch of wood around the town.

## 5. Physical geography

The atlas's relief is turned into heights, rivers, lakes, ranges, passes and climate belts by `Tools/atlas/build_physical_map.js`. The output is `Data/World/physical_map.json` and the image `10_World/maps/physical_map.png`. The details are in [[physical_geography]].

In short:
- a northern wall of mountains (Iron Hold, Cinderhole, the Dragon Spine, Frostveil) is crossed by the Karak Dûn and Ashen Mines passes;
- a north-eastern massif covers Hoshizora, Haneul, Gearholm and Heavenreach;
- a 141 km trunk river runs from Sylvaran through Aldmere, Velmark and Lirian to the Goldmere Coast, and the River and grain corridor follows it;
- all five corridors above are passable under 2,000 m.

It also lists where the region data disagrees with the relief: Lirian and Stormreach are landlocked, and Vharlen and the Quaking Lands are mostly low.

## 6. Open questions

- Where the sixth corridor goes.
- Hollowpine: world.md lists the Hollowpine Highlands as an Aldmere sub-zone, while the atlas makes Grukk the "goblin chief of Hollowpine" in Whisperwood. The inset puts the highlands on the Whisperwood–Aldmere border; please confirm.
- Scale: how many minutes on foot from Brindlewick to Aldmere City.
