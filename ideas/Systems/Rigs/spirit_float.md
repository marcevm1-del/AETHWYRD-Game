---
type: monster-rig
id: rig:spirit_float
tags: [rig, animation, spirit-float]
---
# spirit_float rig

Legless floating beings. No gravity, motion from noise curves; a trailing tail chain made of VFX. Phases through thin walls (Menace 4+).

| Field | Value |
|---|---|
| Aliases | wisp, ghost, spirit, elemental, wraith, phantom, fairy, floating |
| Species using rig | 44 |
| Families represented | Undead, Shadows, Elementals & Spirits, Aberrations, Yokai-Inspired Spirits, Vesperites (Moon Raiders), Sandborne |
| Bone count · budget | 12 · 20 |
| Unity avatar · material | Generic · spirit |
| Reference size · axis | 1 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"drift","froude":0.3,"legFrac":0.5},{"name":"dash","froude":6,"legFrac":0.5}],"fantasyMult":1,"turnDegPerSecAt1m":720,"accelG":0.8,"jumpHeightFrac":0,"canClimb":false,"canSwim":"passes_through","canFly":true,"hovers":true,"hoverHeightFrac":0.3,"flySpeedMult":1}
- **Physics profile:** {"shapeK":0.1,"density":1,"collider":{"type":"sphere","radiusFrac":0.25,"centerZFrac":0.6},"gravityScale":0,"linearDrag":1.5,"knockbackResist":0,"launchable":"floats_up","ragdoll":"none","deathStyle":"dissolve_into_motes"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"drift","frames":60,"loop":true,"rootMotion":true,"events":[]},{"name":"dash","frames":12,"loop":false,"rootMotion":true,"events":[]},{"name":"phase_out","frames":20,"loop":false,"rootMotion":false,"events":[]},{"name":"phase_in","frames":20,"loop":false,"rootMotion":false,"events":[]},{"name":"cast_orb","frames":36,"loop":false,"rootMotion":false,"events":[{"f":6,"e":"telegraph"},{"f":22,"e":"hit_on"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["hover_noise_bob","trail_spring","face_camera_partial","phase_flicker_when_hit","light_intensity_pulse"]

## Default hurtboxes

- **core** — sphere; radius 0.14; damage multiplier default
- **upper** — sphere; radius 0.16; damage multiplier default

## Species

- [[Monsters/Undead/Ghost|Ghost]] — anim_floating, 1.7 m high, rigId rig selection
- [[Monsters/Undead/Wraith|Wraith]] — anim_floating, 2 m high, rigId rig selection
- [[Monsters/Undead/Banshee|Banshee]] — anim_floating, 1.8 m high, rigId rig selection
- [[Monsters/Undead/Lich|Lich]] — anim_floating, 2.2 m high, rigId rig selection
- [[Monsters/Undead/Lich Emperor|Lich Emperor]] — anim_floating, 3 m high, rigId rig selection
- [[Monsters/Shadows/Shadow Wisp|Shadow Wisp]] — anim_floating, 0.4 m high, rigId rig selection
- [[Monsters/Shadows/Umbral Reaper|Umbral Reaper]] — anim_floating, 3 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Wisp|Wisp]] — anim_floating, 0.3 m high, override rig selection
- [[Monsters/Elementals & Spirits/Will-o'-Wisp|Will-o'-Wisp]] — anim_floating, 0.3 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Pixie|Pixie]] — anim_flyer_small, 0.2 m high, override rig selection
- [[Monsters/Elementals & Spirits/Ifrit|Ifrit]] — anim_floating, 5 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Storm Djinn|Storm Djinn]] — anim_floating, 4 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Elemental Sovereign|Elemental Sovereign]] — anim_floating, 20 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Elemental Primarch|Elemental Primarch]] — anim_floating, 40 m high, rigId rig selection
- [[Monsters/Aberrations/Thousand-Eyed Watcher|Thousand-Eyed Watcher]] — anim_floating, 6 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Lantern Ghost|Lantern Ghost]] — anim_floating, 0.6 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Crimson Choir Seraph|Crimson Choir Seraph]] — anim_floating, 3.5 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Vesper Harvester|Vesper Harvester]] — anim_floating, 6 m high, rigId rig selection
- [[Monsters/Sandborne/Glass Wraith|Glass Wraith]] — anim_floating, 2 m high, rigId rig selection
- [[Monsters/Undead/Vesper-Touched Ghost|Vesper-Touched Ghost]] — anim_floating, 1.7 m high, rigId rig selection
- [[Monsters/Undead/Ash Wraith|Ash Wraith]] — anim_floating, 2 m high, rigId rig selection
- [[Monsters/Undead/Tide Banshee|Tide Banshee]] — anim_floating, 1.8 m high, rigId rig selection
- [[Monsters/Undead/Bog Lich|Bog Lich]] — anim_floating, 2.2 m high, rigId rig selection
- [[Monsters/Undead/Bog Lich Emperor|Bog Lich Emperor]] — anim_floating, 3 m high, rigId rig selection
- [[Monsters/Shadows/Vesper-Touched Shadow Wisp|Vesper-Touched Shadow Wisp]] — anim_floating, 0.4 m high, rigId rig selection
- [[Monsters/Shadows/Greater Umbral Reaper|Greater Umbral Reaper]] — anim_floating, 4.8 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Storm Wisp|Storm Wisp]] — anim_floating, 0.3 m high, override (base species) rig selection
- [[Monsters/Elementals & Spirits/Vesper-Touched Will-o'-Wisp|Vesper-Touched Will-o'-Wisp]] — anim_floating, 0.3 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Elder Pixie|Elder Pixie]] — anim_flyer_small, 0.3 m high, override (base species) rig selection
- [[Monsters/Elementals & Spirits/Phantom Ifrit|Phantom Ifrit]] — anim_floating, 5 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Crag Djinn|Crag Djinn]] — anim_floating, 4 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Venom Elemental Sovereign|Venom Elemental Sovereign]] — anim_floating, 20 m high, rigId rig selection
- [[Monsters/Aberrations/Deep Thousand-Eyed Watcher|Deep Thousand-Eyed Watcher]] — anim_floating, 6 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Phantom Lantern Ghost|Phantom Lantern Ghost]] — anim_floating, 0.6 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Phantom Crimson Choir Seraph|Phantom Crimson Choir Seraph]] — anim_floating, 3.5 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Ancient Vesper Harvester|Ancient Vesper Harvester]] — anim_floating, 9 m high, rigId rig selection
- [[Monsters/Sandborne/Elder Glass Wraith|Elder Glass Wraith]] — anim_floating, 3.2 m high, rigId rig selection
- [[Monsters/Undead/Blight Ghost|Blight Ghost]] — anim_floating, 1.7 m high, rigId rig selection
- [[Monsters/Undead/Vesper-Touched Wraith|Vesper-Touched Wraith]] — anim_floating, 2 m high, rigId rig selection
- [[Monsters/Undead/Gilded Banshee|Gilded Banshee]] — anim_floating, 1.8 m high, rigId rig selection
- [[Monsters/Undead/Ancient Lich|Ancient Lich]] — anim_floating, 3.3 m high, rigId rig selection
- [[Monsters/Undead/The Hollow Abbot, Choir of Silence|The Hollow Abbot, Choir of Silence]] — anim_floating, 2.2 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Ilyanthe, the Moon Harvester|Ilyanthe, the Moon Harvester]] — anim_floating, 6 m high, rigId rig selection
- [[Monsters/Undead/The Mad Magician of Aurumdeep, Sinker of Kingdoms|The Mad Magician of Aurumdeep, Sinker of Kingdoms]] — anim_floating, 2 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
