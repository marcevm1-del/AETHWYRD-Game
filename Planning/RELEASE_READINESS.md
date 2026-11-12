# Release readiness

What a release of AETHWYRD requires, and where the project stands against it. Release and Steam planning are **parked by the owner's decision** until near the end (`Canon.md` §1, `13_Production/production.md` §6). This page therefore does not plan a release. It fixes the criteria so that "ready" has a meaning when the time comes, and it records the few release-related facts that already constrain today's work.

## 1. Three kinds of release

| Kind | Audience | Earliest sensible point | Gate |
|---|---|---|---|
| Internal build | The owner | Now: the Ring 0 standalone build exists | `QUALITY_GATES.md` gates 4 to 6 |
| Slice build | The owner and one or a few outsiders | Roadmap phase 5 | `VERTICAL_SLICE_PLAN.md` §5 |
| Public release (Early Access or 1.0) | Players | Owner's decision; `production.md` §6 suggests not before Rings 4 to 5 for Early Access | §2 below |

## 2. Criteria for a public release

A public build is ready when every row is **Passed** with evidence. Today's state is given so nobody mistakes the distance.

| # | Area | Requirement | State on 2026-11-12 |
|---|---|---|---|
| 1 | Content | The promised scope for that release is playable start to finish with no dead quests | Not met: one field; 19 of 32 quests completable |
| 2 | Stability | No crash or blocker in a full playthrough; a soak test of several hours | Not tested |
| 3 | Automated tests | Core and PlayMode green on the release commit, recorded | Core passed today; PlayMode last recorded 2026-11-08 |
| 4 | Performance | 60 fps at 1080p on the stated minimum PC (GTX 1650) in the heaviest scene; load times measured | Not tested: no measurement exists |
| 5 | Saves | Saves from every earlier public build load; version rule in force; product identity final | Rule not written; product is "Game" by "DefaultCompany" (R19) |
| 6 | Input | Keyboard and mouse and gamepad fully supported; rebinding | Rebinding not built |
| 7 | Accessibility | The floor in `Canon.md` §6 (telegraph shapes, colorblind palettes, reduced flash, hold or toggle) verified | Built; not re-verified since 2026-11-08 |
| 8 | Presentation | Player character, creature and building art within budget; styled UI; music and sound | Not met: capsule player, capsule creatures, placeholder UI, no sound |
| 9 | Licences | Every third-party asset, font, tool output and audio file is in `13_Production/third_party_assets.md` with a licence that allows commercial use | Register exists; several packs are "not imported until their licence is confirmed" |
| 10 | Legal | The named-monster rules reviewed by an IP lawyer, as `13_Production/canon_watch_list_2026-11-08.md` notes; nothing taken from another studio's game | Not done |
| 11 | Rating | Teen rating content rules checked across all text and art | Not done |
| 12 | Store | Account, page, capsule art, trailer, achievements, cloud save, controller and Steam Deck checks | Parked; the owner's accounts and purchases |
| 13 | Text | Player-facing text proofread; spoilers gated by act | Not done |
| 14 | Build | Versioned, reproducible build from a tagged commit; executable and product named | Build script exists; names are placeholders |

## 3. What this means for today

Four items above are cheap now and expensive later, and are in the plan for that reason:

1. **Product identity and the save path** (row 5): UPG-028. Decide the names before any build leaves the PC.
2. **A recorded test and performance baseline** (rows 3, 4): UPG-026, UPG-027.
3. **The asset register kept current** (row 9): a rule in `CONTENT_PRODUCTION_PIPELINE.md` §4.
4. **A soak-test habit** once the slice exists (row 2).

Everything else on this page waits for the owner to reopen release planning.

## 4. Who signs

A slice build: the owner, after the milestone review (`qa-tester`, `technical-director`, `documentation-auditor`, `red-team-reviewer`). A public release: the owner alone. No agent declares a release ready.
