---
type: monster-rig
id: rig:aquatic
tags: [rig, animation, aquatic]
---
# aquatic rig

Fish-like swimmers. Body-wave swimming (carangiform), leap attacks out of water, flops on land.

| Field | Value |
|---|---|
| Aliases | fish, shark, piranha, sea_beast |
| Species using rig | 14 |
| Families represented | Shadows, Aquatic, Sandborne, Familiars & Gentle Creatures |
| Bone count · budget | 13 · 24 |
| Unity avatar · material | Generic · scaled |
| Reference size · axis | 1.5 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"swim","froude":1,"legFrac":0.3},{"name":"burst","froude":6,"legFrac":0.3}],"fantasyMult":1,"turnDegPerSecAt1m":400,"accelG":1,"jumpHeightFrac":1,"canClimb":false,"canSwim":true,"canFly":false,"hovers":false,"waterOnly":true}
- **Physics profile:** {"shapeK":0.02,"density":1150,"collider":{"type":"capsule","axis":"y","radiusFrac":0.12,"heightFrac":0.9},"gravityScale":1,"buoyancy":1,"linearDrag":1,"knockbackResist":0.3,"launchable":true,"ragdoll":"chain_physics","deathStyle":"float_belly_up"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"swim","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"burst","frames":12,"loop":false,"rootMotion":true,"events":[]},{"name":"leap_bite","frames":30,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":16,"e":"hit_on"},{"f":20,"e":"hit_off"}]},{"name":"flop_land","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["sine_wave_spine_by_speed","buoyancy_bob","flop_on_land","school_boids_optional"]

## Default hurtboxes

- **head** — sphere; radius 0.1; damage multiplier default
- **spine_03** — capsule; radius 0.12; damage multiplier default

## Species

- [[Monsters/Shadows/Night Leviathan|Night Leviathan]] — anim_fish, 12 m high, rigId rig selection
- [[Monsters/Aquatic/Glowfin Angler|Glowfin Angler]] — anim_fish, 1.2 m high, rigId rig selection
- [[Monsters/Aquatic/Leviathan Young|Leviathan Young]] — anim_fish, 24 m high, rigId rig selection
- [[Monsters/Aquatic/Leviathan|Leviathan]] — anim_fish, 240 m high, rigId rig selection
- [[Monsters/Sandborne/Dunewhale Thalassa|Dunewhale Thalassa]] — anim_fish, 360 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Rainbow Koi|Rainbow Koi]] — anim_fish, 0.2 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Sky Whale|Sky Whale]] — anim_fish, 32 m high, rigId rig selection
- [[Monsters/Shadows/Greater Night Leviathan|Greater Night Leviathan]] — anim_fish, 19.2 m high, rigId rig selection
- [[Monsters/Aquatic/Phantom Glowfin Angler|Phantom Glowfin Angler]] — anim_fish, 1.2 m high, rigId rig selection
- [[Monsters/Aquatic/Phantom Leviathan Young|Phantom Leviathan Young]] — anim_fish, 24 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Crag Koi|Crag Koi]] — anim_fish, 0.2 m high, rigId rig selection
- [[Monsters/Familiars & Gentle Creatures/Greater Sky Whale|Greater Sky Whale]] — anim_fish, 51.2 m high, rigId rig selection
- [[Monsters/Aquatic/Ysgrath, the Ice-Jaw Leviathan|Ysgrath, the Ice-Jaw Leviathan]] — anim_fish, 18 m high, rigId rig selection
- [[Monsters/Aquatic/Lumen-Eater, the Abyss Angler|Lumen-Eater, the Abyss Angler]] — anim_fish, 4.8 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
