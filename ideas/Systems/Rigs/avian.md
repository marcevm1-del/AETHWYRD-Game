---
type: monster-rig
id: rig:avian
tags: [rig, animation, avian]
---
# avian rig

Feathered fliers. Hops on the ground, flaps/glides in air, dive attacks. Feather chains are spring bones.

| Field | Value |
|---|---|
| Aliases | bird, crow, roc, cockatrice, feathered |
| Species using rig | 23 |
| Families represented | Avians, Yokai-Inspired Spirits |
| Bone count · budget | 31 · 40 |
| Unity avatar · material | Generic · feathered |
| Reference size · axis | 0.6 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"hop","froude":1.5,"legFrac":0.25},{"name":"run","froude":3,"legFrac":0.25}],"fantasyMult":1,"turnDegPerSecAt1m":600,"accelG":1.2,"jumpHeightFrac":0.8,"canClimb":false,"canSwim":"surface","canFly":true,"hovers":"brief","flySpeedMult":3}
- **Physics profile:** {"shapeK":0.04,"density":350,"collider":{"type":"sphere","radiusFrac":0.2,"centerZFrac":0.33},"gravityScale":1,"linearDrag":0.5,"knockbackResist":0.05,"launchable":true,"ragdoll":"full","deathStyle":"tumble_feathers_burst"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"hop","frames":16,"loop":true,"rootMotion":true,"events":[]},{"name":"run","frames":12,"loop":true,"rootMotion":true,"events":[]},{"name":"fly_hover","frames":30,"loop":true,"rootMotion":false,"events":[]},{"name":"fly_forward","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"fly_glide","frames":40,"loop":true,"rootMotion":true,"events":[]},{"name":"takeoff","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"fly_land","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"dive","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"peck","frames":18,"loop":false,"rootMotion":false,"events":[{"f":8,"e":"hit_on"},{"f":10,"e":"hit_off"}]},{"name":"dive_strike","frames":24,"loop":false,"rootMotion":true,"events":[{"f":2,"e":"telegraph"},{"f":16,"e":"hit_on"},{"f":20,"e":"hit_off"}]},{"name":"steal_grab","frames":24,"loop":false,"rootMotion":true,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["head_stabilize_while_moving","look_at_target_head_tilt","feather_spring","bank_into_turns_in_air"]

## Default hurtboxes

- **head** — sphere; radius 0.06; damage multiplier default
- **body** — capsule; radius 0.1; damage multiplier default
- **wing_radius_L** — capsule; radius 0.03; damage multiplier default
- **wing_radius_R** — capsule; radius 0.03; damage multiplier default

## Species

- [[Monsters/Avians/Giant Crow|Giant Crow]] — anim_avian, 0.28 m high, override rig selection
- [[Monsters/Avians/Cockatrice|Cockatrice]] — anim_avian, 0.37 m high, rigId rig selection
- [[Monsters/Avians/Harpy|Harpy]] — anim_avian, 0.74 m high, rigId rig selection
- [[Monsters/Avians/Thunderbird|Thunderbird]] — anim_avian, 3.68 m high, rigId rig selection
- [[Monsters/Avians/Roc|Roc]] — anim_avian, 13.8 m high, rigId rig selection
- [[Monsters/Avians/Phoenix|Phoenix]] — anim_avian, 2.76 m high, rigId rig selection
- [[Monsters/Avians/Simurrah|Simurrah]] — anim_avian, 9.2 m high, rigId rig selection
- [[Monsters/Avians/Eternal Phoenix|Eternal Phoenix]] — anim_avian, 13.8 m high, rigId rig selection
- [[Monsters/Avians/Aethernax, the Sky Devourer|Aethernax, the Sky Devourer]] — anim_avian, 184 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Tengu|Tengu]] — anim_avian, 0.92 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Great Tengu King|Great Tengu King]] — anim_avian, 2.76 m high, rigId rig selection
- [[Monsters/Avians/Brine Crow|Brine Crow]] — anim_avian, 0.28 m high, override (base species) rig selection
- [[Monsters/Avians/Vesper-Touched Cockatrice|Vesper-Touched Cockatrice]] — anim_avian, 0.37 m high, rigId rig selection
- [[Monsters/Avians/Phantom Harpy|Phantom Harpy]] — anim_avian, 0.74 m high, rigId rig selection
- [[Monsters/Avians/Tide Thunderbird|Tide Thunderbird]] — anim_avian, 3.68 m high, rigId rig selection
- [[Monsters/Avians/Cloud Roc|Cloud Roc]] — anim_avian, 13.8 m high, rigId rig selection
- [[Monsters/Avians/Vesper-Touched Phoenix|Vesper-Touched Phoenix]] — anim_avian, 2.76 m high, rigId rig selection
- [[Monsters/Avians/Elder Simurrah|Elder Simurrah]] — anim_avian, 14.72 m high, rigId rig selection
- [[Monsters/Avians/Brine Eternal Phoenix|Brine Eternal Phoenix]] — anim_avian, 13.8 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Tengu|Vesper-Touched Tengu]] — anim_avian, 0.92 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Ruin Great Tengu King|Ruin Great Tengu King]] — anim_avian, 2.76 m high, rigId rig selection
- [[Monsters/Avians/Raikaru, the Storm Roc|Raikaru, the Storm Roc]] — anim_avian, 16.1 m high, rigId rig selection
- [[Monsters/Avians/Aquilon, the Roc Sovereign|Aquilon, the Roc Sovereign]] — anim_avian, 18.4 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
