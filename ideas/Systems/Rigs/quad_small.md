---
type: monster-rig
id: rig:quad_small
tags: [rig, animation, quad-small]
---
# quad_small rig

Small quadrupeds 0.3–0.8 m long. Hind-dominant: hopping or bounding gaits, ears and tail are their acting.

| Field | Value |
|---|---|
| Aliases | rabbit, rat, fox, small_beast, rodent, hare |
| Species using rig | 27 |
| Families represented | Beasts, Reptiles, Yokai-Inspired Spirits, Floor-born, Sandborne, Familiars & Gentle Creatures |
| Bone count · budget | 34 · 36 |
| Unity avatar · material | Generic · flesh |
| Reference size · axis | 0.5 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.3,"legFrac":0.33},{"name":"hop","froude":6,"legFrac":0.33},{"name":"bound","froude":22,"legFrac":0.33}],"fantasyMult":1,"turnDegPerSecAt1m":540,"accelG":1.6,"jumpHeightFrac":2,"canClimb":false,"canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.03,"density":1000,"collider":{"type":"capsule","axis":"y","radiusFrac":0.16,"heightFrac":0.85},"gravityScale":1.6,"linearDrag":0.1,"knockbackResist":0.05,"launchable":true,"ragdoll":"full","deathStyle":"ragdoll_tumble"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":36,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":9,"e":"footstep_R"},{"f":18,"e":"footstep_R"},{"f":27,"e":"footstep_L"}]},{"name":"trot","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"gallop","frames":16,"loop":true,"rootMotion":true,"events":[{"f":3,"e":"footstep_L"},{"f":11,"e":"footstep_R"}]},{"name":"circle_L","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"circle_R","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"hop","frames":14,"loop":true,"rootMotion":true,"events":[{"f":2,"e":"land"}]},{"name":"bound","frames":12,"loop":true,"rootMotion":true,"events":[{"f":1,"e":"land"}]},{"name":"sit_up_listen","frames":60,"loop":false,"rootMotion":false,"events":[]},{"name":"dig","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"thump_warning","frames":20,"loop":false,"rootMotion":false,"events":[{"f":8,"e":"vocal"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["nose_twitch_idle","ear_track_sound","look_at_target","foot_ik_ground","body_tilt_on_slope"]

## Default hurtboxes

- **head** — sphere; radius 0.09; damage multiplier default
- **spine_02** — capsule; radius 0.12; damage multiplier default

## Species

- [[Monsters/Beasts/Horned Rabbit|Horned Rabbit]] — anim_quad_small, 0.27 m high, override rig selection
- [[Monsters/Beasts/Jackalope|Jackalope]] — anim_quad_small, 0.27 m high, rigId rig selection
- [[Monsters/Beasts/Moon Hare|Moon Hare]] — anim_quad_small, 0.34 m high, rigId rig selection
- [[Monsters/Reptiles/Swamp Toad|Swamp Toad]] — anim_quad_small, 0.34 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Fox Spirit|Fox Spirit]] — anim_quad_small, 0.68 m high, rigId rig selection
- [[Monsters/Floor-born/Floor Crawler|Floor Crawler]] — anim_quad_small, 0.54 m high, rigId rig selection
- [[Monsters/Sandborne/Sand Skink|Sand Skink]] — anim_quad_small, 0.34 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Moss Tortoise|Moss Tortoise]] — anim_quad_small, 0.54 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Fluffcap Sheep|Fluffcap Sheep]] — anim_quad_small, 0.68 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Mana Fox|Mana Fox]] — anim_quad_small, 0.41 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Ember Kitten|Ember Kitten]] — anim_quad_small, 0.27 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Snowmole|Snowmole]] — anim_quad_small, 0.27 m high, rigId rig selection
- [[Monsters/Beasts/Ancient Horned Rabbit|Ancient Horned Rabbit]] — anim_quad_small, 0.41 m high, override (base species) rig selection
- [[Monsters/Beasts/Crag Jackalope|Crag Jackalope]] — anim_quad_small, 0.27 m high, rigId rig selection
- [[Monsters/Beasts/Phantom Moon Hare|Phantom Moon Hare]] — anim_quad_small, 0.34 m high, rigId rig selection
- [[Monsters/Reptiles/Frost Toad|Frost Toad]] — anim_quad_small, 0.34 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Greater Fox Spirit|Greater Fox Spirit]] — anim_quad_small, 1.09 m high, rigId rig selection
- [[Monsters/Floor-born/Thunder Floor Crawler|Thunder Floor Crawler]] — anim_quad_small, 0.54 m high, rigId rig selection
- [[Monsters/Sandborne/Greater Sand Skink|Greater Sand Skink]] — anim_quad_small, 0.54 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Crag Moss Tortoise|Crag Moss Tortoise]] — anim_quad_small, 0.54 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Rime Fluffcap Sheep|Rime Fluffcap Sheep]] — anim_quad_small, 0.68 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Ember Mana Fox|Ember Mana Fox]] — anim_quad_small, 0.41 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Moss Kitten|Moss Kitten]] — anim_quad_small, 0.27 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Sky Snowmole|Sky Snowmole]] — anim_quad_small, 0.27 m high, rigId rig selection
- [[Monsters/Beasts/Elder Horned Rabbit|Elder Horned Rabbit]] — anim_quad_small, 0.41 m high, override (base species) rig selection
- [[Monsters/Beasts/Phantom Jackalope|Phantom Jackalope]] — anim_quad_small, 0.27 m high, rigId rig selection
- [[Monsters/Beasts/Elder Moon Hare|Elder Moon Hare]] — anim_quad_small, 0.54 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
