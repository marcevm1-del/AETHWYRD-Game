# Ground mount species notes

Bestiary-side notes for the species that `Data/Companions/mounts.json` lists as ground mounts (rules in `12_Systems/companions_and_mounts.md`, stable care in `12_Systems/stables.md`). Mount numbers (speed, stamina, carry, unlock rank) belong to `mounts.json` and `Mounts.cs`; this page covers what the *animal* is: how it looks, why it carries a rider, and where the species and the mount data disagree. Ground only: no flying, aquatic, dragon or celestial mounts (Canon §6, ground mounts).

Species values below are read from `Data/Monsters/species.json` and are not a second source of truth.

## Roster at a glance

| Mount family | Species | Rank | Size | Element | Rig | Wild behaviour |
|---|---|---|---|---|---|---|
| Horse | Thunderhorn Elk (`mon_thunderhorn_elk`) | C | 2.8 m | Lightning | `rig_quad_large` | Territorial |
| Wolf | Forest Wolf (`mon_forest_wolf`) | F+ | 1.2 m | None | `rig_quad_large` | Skittish |
| Wolf | Dire Wolf (`mon_dire_wolf`) | D | 2.0 m | None | `rig_quad_large` | Pack |
| Wolf | Frost Fenrir Pup (`mon_frost_fenrir_pup`) | B | 1.5 m | Ice | `rig_quad_large` | Skittish |
| Bear | Bandit Bear (`mon_bandit_bear`) | E+ | 2.2 m | None | `rig_quad_large` | Pack |
| Bear | Elder Bandit Bear (`mon_elder_bandit_bear`) | D+ | 3.5 m | None | `rig_quad_large` | Pack |
| Desert beast | Giant Lizard (`mon_giant_lizard`) | E | 2.0 m | Earth | `rig_quad_large` | Passive |
| Desert beast | Dune Scorpion (`mon_dune_scorpion`) | D | 2.0 m | Poison | `rig_hexapod` | Territorial |
| Desert beast | Elder Dune Scorpion (`mon_elder_dune_scorpion`) | C | 3.2 m | Poison | `rig_hexapod` | Ambush |
| Large ground monster | Wild Boar (`mon_wild_boar`) | E | 1.4 m | Earth | `rig_quad_large` | Skittish |
| Large ground monster | Behemoth Calf (`mon_behemoth_calf`) | B+ | 4.0 m | Earth | `rig_quad_large` | Pack |
| Large ground monster | Sabretooth King (`mon_sabretooth_king`) | A | 3.2 m | Ice | `rig_quad_large` | Skittish |

## Families

### Horse family: stands in with the Thunderhorn Elk
Branching antlers that crackle in storms; Fanghold, Vharlen and Hoshizora highlands. It stands in as the "horse" because it is the only large hoofed quadruped on `rig_quad_large` among the ground mounts. A ridden elk keeps its antlers (the saddle sits behind them, which is a `technical-artist` concern for the rider's camera). Its Lightning element is flavour only while mounted: mounted combat limits ban channelled skills.

### Wolf family
A progression of one animal: the Forest Wolf (grey-green fern coat, skittish, the starter), the Dire Wolf (horse-sized, jagged fangs, a pack animal) and the Frost Fenrir Pup (frosted fur, freezing breath). All three are `Fire`-weak and share one body plan, so a single mount rig and saddle point serve the whole family. The Pup is a "pup" only in lore; at 1.5 m it is saddle-sized, and its B rank is the family's ceiling.

### Bear family
The Bandit Bear (dark mask band across the eyes) and its Elder variant (3.5 m, `variantKind: elder`). Slow and sturdy; the carry bonus family. The elder is the only variant-tier species among the mounts, so its look must stay the base bear's, scaled and scarred, never a new body plan.

### Desert beast family
Giant Lizard (sun-baked scales, frilled neck, passive), Dune Scorpion and Elder Dune Scorpion (glass-like tail stinger, poison). The scorpions are the roster's only hexapods (`rig_hexapod`, SPD 70): they are mounts whose gait differs from every other family. See the open items.

### Large ground monster family
Wild Boar (curved tusks, iron-wire bristles), Behemoth Calf (stone-plated back, stump-like legs, 4 m) and Sabretooth King (two sabre fangs as long as swords). Late-game, slow, high carry.

## Open items for other owners (nothing here was changed in data)

1. **Unlock rank versus species rank (systems-designer / items-designer):** the horse family unlocks at rank F but its only species is a rank C monster; the Wolf family unlocks at E but includes a rank B pup. Not a bug (the unlock is the *player's* guild rank, not the animal's), but players will meet a C-rank animal as a rank-F ride. The horse gap is the open question 6 in `companions_and_mounts.md`.
2. **A true horse (bestiary-designer, needs the user's OK):** proposal for Canon §6 rather than an edit: add a plain, non-elemental `Horse` species in a beast family of `Tools/monster_gen/families.js` at rank F, so the horse family has a starter and the Thunderhorn Elk becomes its upgrade. Adding a species changes the 680-species Canon count, so it needs approval first.
3. **Scorpion mounts (animator-rigger, gameplay-engineer):** the scorpions are the only hexapod mounts. I did not check whether `rig_hexapod` has a rider seat; if it has none, either give hexapods a seat socket or move the scorpions to a non-mount role. Recorded here, not decided.
4. **Mythic ground species left out on purpose:** Nightmare Steed (B+), Unicorn (A) and Dune Unicorn (A+) are horse-shaped but Mythic or Spirit; `companions_and_mounts.md` keeps them out as mounts. They stay wild-only.
