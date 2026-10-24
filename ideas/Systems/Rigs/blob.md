---
type: monster-rig
id: rig:blob
tags: [rig, animation, blob]
---
# blob rig

Slimes and oozes: a gel dome with jiggle lobes. Moves by hopping; squash & stretch is the whole performance.

| Field | Value |
|---|---|
| Aliases | slime, ooze, jelly_blob |
| Species using rig | 43 |
| Families represented | Slimes |
| Bone count · budget | 11 · 12 |
| Unity avatar · material | Generic · gel |
| Reference size · axis | 0.5 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"hop","froude":2.2,"legFrac":0.5},{"name":"hop_fast","froude":6,"legFrac":0.5},{"name":"ooze_crawl","froude":0.08,"legFrac":0.5}],"fantasyMult":1,"turnDegPerSecAt1m":360,"accelG":0.6,"jumpHeightFrac":1.6,"canClimb":"walls_slow","canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.5,"density":1050,"collider":{"type":"sphere","radiusFrac":0.45,"centerZFrac":0.42},"gravityScale":1.6,"linearDrag":0.4,"knockbackResist":0.1,"launchable":true,"ragdoll":"none","deathStyle":"splat_dissolve"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"hop","frames":24,"loop":true,"rootMotion":true,"events":[{"f":6,"e":"land"}]},{"name":"hop_fast","frames":16,"loop":true,"rootMotion":true,"events":[{"f":4,"e":"land"}]},{"name":"ooze_crawl","frames":40,"loop":true,"rootMotion":true,"events":[]},{"name":"split","frames":40,"loop":false,"rootMotion":false,"events":[{"f":25,"e":"vfx"}]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["squash_stretch_from_velocity","jiggle_on_hit","look_at_target","inner_item_wobble","surface_tension_wobble_idle"]

## Default hurtboxes

- **core** — sphere; radius 0.42; damage multiplier default
- **inner_item** — sphere; radius 0.08; damage multiplier default

## Species

- [[Monsters/Slimes/Blue Slime|Blue Slime]] — anim_blob, 0.4 m high, override rig selection
- [[Monsters/Slimes/Green Slime|Green Slime]] — anim_blob, 0.4 m high, override rig selection
- [[Monsters/Slimes/Red Slime|Red Slime]] — anim_blob, 0.5 m high, rigId rig selection
- [[Monsters/Slimes/Poison Slime|Poison Slime]] — anim_blob, 0.6 m high, rigId rig selection
- [[Monsters/Slimes/Bubble Slime|Bubble Slime]] — anim_blob, 0.3 m high, rigId rig selection
- [[Monsters/Slimes/Metal Slime|Metal Slime]] — anim_blob, 0.3 m high, rigId rig selection
- [[Monsters/Slimes/Mimic Slime|Mimic Slime]] — anim_blob, 1 m high, rigId rig selection
- [[Monsters/Slimes/Frost Slime|Frost Slime]] — anim_blob, 0.5 m high, rigId rig selection
- [[Monsters/Slimes/Cube Slime|Cube Slime]] — anim_blob, 0.8 m high, rigId rig selection
- [[Monsters/Slimes/King Slime|King Slime]] — anim_blob, 3 m high, rigId rig selection
- [[Monsters/Slimes/Ember Ooze|Ember Ooze]] — anim_blob, 1.5 m high, rigId rig selection
- [[Monsters/Slimes/Storm Slime|Storm Slime]] — anim_blob, 1.2 m high, rigId rig selection
- [[Monsters/Slimes/Abyss Slime|Abyss Slime]] — anim_blob, 4 m high, rigId rig selection
- [[Monsters/Slimes/Prismatic Slime Sovereign|Prismatic Slime Sovereign]] — anim_blob, 8 m high, rigId rig selection
- [[Monsters/Slimes/Primordial Ooze|Primordial Ooze]] — anim_blob, 40 m high, rigId rig selection
- [[Monsters/Slimes/Meadow Slime|Meadow Slime]] — anim_blob, 0.4 m high, override (base species) rig selection
- [[Monsters/Slimes/Vesper-Touched Green Slime|Vesper-Touched Green Slime]] — anim_blob, 0.4 m high, override (base species) rig selection
- [[Monsters/Slimes/Moss Slime|Moss Slime]] — anim_blob, 0.5 m high, rigId rig selection
- [[Monsters/Slimes/Vesper-Touched Poison Slime|Vesper-Touched Poison Slime]] — anim_blob, 0.6 m high, rigId rig selection
- [[Monsters/Slimes/Greater Bubble Slime|Greater Bubble Slime]] — anim_blob, 0.5 m high, rigId rig selection
- [[Monsters/Slimes/Gilded Slime|Gilded Slime]] — anim_blob, 0.3 m high, rigId rig selection
- [[Monsters/Slimes/Bog Mimic Slime|Bog Mimic Slime]] — anim_blob, 1 m high, rigId rig selection
- [[Monsters/Slimes/Elder Frost Slime|Elder Frost Slime]] — anim_blob, 0.8 m high, rigId rig selection
- [[Monsters/Slimes/Phantom Cube Slime|Phantom Cube Slime]] — anim_blob, 0.8 m high, rigId rig selection
- [[Monsters/Slimes/Deep King Slime|Deep King Slime]] — anim_blob, 3 m high, rigId rig selection
- [[Monsters/Slimes/Ruin Ooze|Ruin Ooze]] — anim_blob, 1.5 m high, rigId rig selection
- [[Monsters/Slimes/Cinder Slime|Cinder Slime]] — anim_blob, 1.2 m high, rigId rig selection
- [[Monsters/Slimes/Ruin Abyss Slime|Ruin Abyss Slime]] — anim_blob, 4 m high, rigId rig selection
- [[Monsters/Slimes/Cavern Prismatic Slime Sovereign|Cavern Prismatic Slime Sovereign]] — anim_blob, 8 m high, rigId rig selection
- [[Monsters/Slimes/Night Slime|Night Slime]] — anim_blob, 0.4 m high, override (base species) rig selection
- [[Monsters/Slimes/Gale Slime|Gale Slime]] — anim_blob, 0.4 m high, override (base species) rig selection
- [[Monsters/Slimes/Vesper-Touched Red Slime|Vesper-Touched Red Slime]] — anim_blob, 0.5 m high, rigId rig selection
- [[Monsters/Slimes/Greater Poison Slime|Greater Poison Slime]] — anim_blob, 1 m high, rigId rig selection
- [[Monsters/Slimes/Ash Slime|Ash Slime]] — anim_blob, 0.3 m high, rigId rig selection
- [[Monsters/Slimes/Vesper-Touched Metal Slime|Vesper-Touched Metal Slime]] — anim_blob, 0.3 m high, rigId rig selection
- [[Monsters/Slimes/Sky Mimic Slime|Sky Mimic Slime]] — anim_blob, 1 m high, rigId rig selection
- [[Monsters/Slimes/Vesper-Touched Frost Slime|Vesper-Touched Frost Slime]] — anim_blob, 0.5 m high, rigId rig selection
- [[Monsters/Slimes/Glacier Cube Slime|Glacier Cube Slime]] — anim_blob, 0.8 m high, rigId rig selection
- [[Monsters/Slimes/Blight King Slime|Blight King Slime]] — anim_blob, 3 m high, rigId rig selection
- [[Monsters/Slimes/Ancient Ember Ooze|Ancient Ember Ooze]] — anim_blob, 2.3 m high, rigId rig selection
- [[Monsters/Slimes/Elder Storm Slime|Elder Storm Slime]] — anim_blob, 1.9 m high, rigId rig selection
- [[Monsters/Slimes/Phantom Abyss Slime|Phantom Abyss Slime]] — anim_blob, 4 m high, rigId rig selection
- [[Monsters/Slimes/Iron Prismatic Slime Sovereign|Iron Prismatic Slime Sovereign]] — anim_blob, 8 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
