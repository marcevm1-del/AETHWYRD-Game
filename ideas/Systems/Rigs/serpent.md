---
type: monster-rig
id: rig:serpent
tags: [rig, animation, serpent]
---
# serpent rig

Limbless long bodies: snakes, giant worms, eels, sea serpents. Spline-driven spine (16 bones) with a follow-the-head path solver.

| Field | Value |
|---|---|
| Aliases | snake, wyrm, eel, worm, sandworm, basilisk |
| Species using rig | 21 |
| Families represented | Killer Insects, Undead, Reptiles, Elementals & Spirits, Aquatic, Sandborne |
| Bone count · budget | 21 · 24 |
| Unity avatar · material | Generic · scaled |
| Reference size · axis | 4 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"slither","froude":0.4,"legFrac":0.06},{"name":"strike_lunge","froude":12,"legFrac":0.06},{"name":"swim","froude":0.8,"legFrac":0.06}],"fantasyMult":1,"turnDegPerSecAt1m":300,"accelG":0.8,"jumpHeightFrac":0,"canClimb":"trees","canSwim":true,"canFly":false,"hovers":false,"burrows":"worm_variants"}
- **Physics profile:** {"shapeK":0.002,"density":1150,"collider":{"type":"capsule_chain","count":5,"radiusFrac":0.035},"gravityScale":1.2,"linearDrag":0.2,"knockbackResist":0.4,"launchable":"head_only","ragdoll":"chain_physics","deathStyle":"limp_chain"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"slither","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"coil_idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"rear_up_threat","frames":30,"loop":false,"rootMotion":false,"events":[{"f":4,"e":"telegraph"}]},{"name":"strike","frames":18,"loop":false,"rootMotion":true,"events":[{"f":8,"e":"hit_on"},{"f":11,"e":"hit_off"}]},{"name":"constrict_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"burrow","frames":40,"loop":false,"rootMotion":false,"events":[]},{"name":"emerge","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["spline_follow_head","lateral_undulation_by_speed","coil_when_idle","tongue_flick_idle","body_hugs_terrain"]

## Default hurtboxes

- **head** — sphere; radius 0.03; damage multiplier default
- **spine_02** — sphere; radius 0.035; damage multiplier default
- **spine_05** — sphere; radius 0.035; damage multiplier default
- **spine_08** — sphere; radius 0.035; damage multiplier default
- **spine_11** — sphere; radius 0.035; damage multiplier default
- **spine_14** — sphere; radius 0.035; damage multiplier default

## Species

- [[Monsters/Killer Insects/Tunnel Centipede|Tunnel Centipede]] — anim_serpent, 0.24 m high, rigId rig selection
- [[Monsters/Undead/Lantern Leech|Lantern Leech]] — anim_serpent, 0.02 m high, rigId rig selection
- [[Monsters/Reptiles/Crocodile Wyrm|Crocodile Wyrm]] — anim_serpent, 0.28 m high, rigId rig selection
- [[Monsters/Reptiles/Hydra|Hydra]] — anim_serpent, 0.36 m high, rigId rig selection
- [[Monsters/Reptiles/Gorgon Wyrm|Gorgon Wyrm]] — anim_serpent, 0.56 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Salamander Spirit|Salamander Spirit]] — anim_serpent, 0.04 m high, rigId rig selection
- [[Monsters/Aquatic/Sea Serpent|Sea Serpent]] — anim_serpent, 0.8 m high, rigId rig selection
- [[Monsters/Sandborne/Sandworm|Sandworm]] — anim_serpent, 1.6 m high, rigId rig selection
- [[Monsters/Killer Insects/Iron Centipede|Iron Centipede]] — anim_serpent, 0.24 m high, rigId rig selection
- [[Monsters/Undead/Ancient Lantern Leech|Ancient Lantern Leech]] — anim_serpent, 0.04 m high, rigId rig selection
- [[Monsters/Reptiles/Gale Crocodile Wyrm|Gale Crocodile Wyrm]] — anim_serpent, 0.28 m high, rigId rig selection
- [[Monsters/Reptiles/Frost Hydra|Frost Hydra]] — anim_serpent, 0.36 m high, rigId rig selection
- [[Monsters/Reptiles/Elder Gorgon Wyrm|Elder Gorgon Wyrm]] — anim_serpent, 0.9 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Crag Salamander Spirit|Crag Salamander Spirit]] — anim_serpent, 0.04 m high, rigId rig selection
- [[Monsters/Aquatic/Abyssal Sea Serpent|Abyssal Sea Serpent]] — anim_serpent, 0.8 m high, rigId rig selection
- [[Monsters/Sandborne/Elder Sandworm|Elder Sandworm]] — anim_serpent, 2.56 m high, rigId rig selection
- [[Monsters/Killer Insects/Radiant Centipede|Radiant Centipede]] — anim_serpent, 0.24 m high, rigId rig selection
- [[Monsters/Undead/Greater Lantern Leech|Greater Lantern Leech]] — anim_serpent, 0.04 m high, rigId rig selection
- [[Monsters/Sandborne/Glassmaw, Worm of the Endless Dune|Glassmaw, Worm of the Endless Dune]] — anim_serpent, 2.8 m high, rigId rig selection
- [[Monsters/Reptiles/Xibalbar, the Hydra of the Mire|Xibalbar, the Hydra of the Mire]] — anim_serpent, 0.4 m high, rigId rig selection
- [[Monsters/Aquatic/The Nameless Tide, a Serpent Without a Name|The Nameless Tide, a Serpent Without a Name]] — anim_serpent, 1.2 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
