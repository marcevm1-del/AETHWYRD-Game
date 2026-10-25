# Buildings: Our Kit vs Typical Anime Fantasy Towns

> Compares Brindlewick's buildings (`13_Production/town_buildings.md`) with the town style common to anime and anime-styled games, and sets the changes the kit adopts.
>
> **Shared look, no copying.** Reference points are styles everyone recognises:
> - the European-village isekai look (Axel in *KonoSuba*, the towns of *Frieren* and *Re:Zero*);
> - Studio Ghibli's towns (*Kiki's Delivery Service*, *Howl's Moving Castle*);
> - anime-styled games such as *Genshin Impact*'s Mondstadt.
>
> We borrow the shared visual language, never anyone's buildings, layouts or assets.

## 1. What makes a town read as "anime"

| Trait | Typical anime town | Why it matters |
|---|---|---|
| **Silhouette** | Exaggerated storybook proportions: tall, steep roofs (often 50–60°, up to half the building's height), big overhangs, flared eaves, tall chimneys; towers with "witch-hat" cones, dormers, bay windows, balconies; deliberate asymmetry; in Ghibli, gentle sags and leans | Shapes are read at a glance, from far away and in silhouette against painted skies |
| **Colour** | High-key and saturated but harmonious: white/cream plaster, warm wood, vivid roofs (vermilion, cobalt, teal, orange), a colour family per district, flower boxes everywhere | The palette carries mood; nothing muddy or grey-brown |
| **Shading** | Cel shading in 2–3 tones; shadows tinted cool (blue/violet), not black; a soft rim light; clean ink outlines on silhouettes and creases (or crisp shape edges); bloom on lamps and sky | The single biggest "this is anime" cue |
| **Detail density** | Lots of small, readable story props: signs with picture icons (bread, potion, sword), banners and bunting, lanterns, hanging plants, ivy, laundry, crates | Every street feels lived in; signs tell you what a shop is without text |
| **Landmarks** | A clock tower or cathedral as the skyline anchor, a fountain plaza, an imposing guild hall, a mage tower, stone bridges, windmills, a manor or castle on the hill | Orientation and postcard moments |
| **Surfaces** | Flat or hand-painted colour with gentle gradients; stones drawn as shapes, not noisy textures | Keeps the frame clean and readable |

## 2. Where our kit stood (first 34 models)

| Trait | Before | Verdict |
|---|---|---|
| Silhouette | Timber-frame houses with gable roofs at about 35–45°, modest overhangs, mostly symmetric boxes; only the temple and gate had towers | **Too sensible.** The roofs read as realistic European, not storybook |
| Colour | Muted, slightly desaturated palette (dusty blue and brick roofs, greyish stone) | **Too realistic.** It reads as a sim, not anime |
| Shading | Unity URP Lit (physically based); no outlines | **The biggest gap** |
| Detail | Good start: signs, banners, lanterns, shutters, barrels, chimneys | **Close.** Missing flowers, greenery, bunting and icon signs |
| Landmarks | Guild hall, temple, windmill, gatehouse | **Missing** the skyline anchor (clock tower), a fountain, a mage tower, bridges |
| Surfaces | Flat colours, cobbled plaza in shapes | **Already on-style** |

## 3. What the kit now does (adopted)

1. **Steeper, chunkier roofs.**
   - Roof rise ×1.35 on every gable, about 50–55°.
   - Flared eaves and thick fascia boards along the eaves.
   - Taller chimneys and tower cones.
   - Weathervanes and finials on landmarks.
2. **Anime palette.**
   - Brighter cream and white plaster with warmer timber.
   - Saturated roof colours (vermilion, cobalt, teal, orange, violet, green).
   - Lighter, warmer stone.
3. **Life on every facade.**
   - Flower boxes under front windows, in red, pink and yellow.
   - Ivy on some walls.
   - Bunting across streets.
   - Shop signs with picture icons: bread, potion, needle and thread, book, flower, cup, saw, tankard.
4. **New shapes.**
   - Corner turrets with witch-hat roofs.
   - Dormers, bay windows and balconies.
   - Arched doorways.
   - Round and mushroom-capped cottages.
5. **Landmarks.** A clock tower (the skyline anchor), a fountain for the plaza, a mage tower, a bathhouse, a town hall, a stone bridge and an observatory.
6. **Cel shading and outlines in Unity** (`Ascend/Toon`), on every building and structure:
   - two-tone shading with a cool, violet-tinted shadow;
   - a soft rim light;
   - lamps, forges and runes that glow;
   - a thin dark ink outline (inverted hull along smoothed normals, which an import step writes into each building mesh).
7. **Fifty buildings.** 16 from the first pass plus 34 new: shops and trades, houses, civic buildings and landmarks, and farm buildings (the list is in `town_buildings.md`).

## 4. Still to do (beyond buildings)

- The rest of the scene (ground, trees, NPCs, monsters) is still URP Lit. Moving it to the same toon shader makes the frame consistent. Characters will need their own variant: face shadows and hair highlights.
- A painted sky and a light bloom pass on lamps and windows at dusk.
