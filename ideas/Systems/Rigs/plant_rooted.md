---
type: monster-rig
id: rig:plant_rooted
tags: [rig, animation, plant-rooted]
---
# plant_rooted rig

Rooted plants that attack in place: man-eating flowers, vine traps, ambush trees. Can uproot to relocate slowly.

| Field | Value |
|---|---|
| Aliases | plant, man_eater_plant, vine, flower_monster, tree_ambush |
| Species using rig | 19 |
| Families represented | Plants & Fungi |
| Bone count · budget | 30 · 40 |
| Unity avatar · material | Generic · wood |
| Reference size · axis | 2 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"uproot_crawl","froude":0.05,"legFrac":0.2}],"fantasyMult":1,"turnDegPerSecAt1m":180,"accelG":0.2,"jumpHeightFrac":0,"canClimb":false,"canSwim":false,"canFly":false,"hovers":false,"stationary":true}
- **Physics profile:** {"shapeK":0.03,"density":700,"collider":{"type":"capsule","radiusFrac":0.12,"heightFrac":0.9},"gravityScale":1,"linearDrag":1,"knockbackResist":1,"launchable":false,"ragdoll":"none","deathStyle":"wilt_collapse"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"dormant","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"awaken","frames":40,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"vine_lash","frames":30,"loop":false,"rootMotion":false,"events":[{"f":4,"e":"telegraph"},{"f":16,"e":"hit_on"},{"f":20,"e":"hit_off"}]},{"name":"vine_grab_pull","frames":50,"loop":false,"rootMotion":false,"events":[]},{"name":"chomp","frames":24,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"hit_on"},{"f":13,"e":"hit_off"}]},{"name":"uproot","frames":60,"loop":false,"rootMotion":false,"events":[]},{"name":"uproot_crawl","frames":60,"loop":true,"rootMotion":true,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["wind_sway","vine_fabrik_reach_to_target","bulb_track_target","dormant_disguise_pose"]

## Default hurtboxes

- **bulb** — sphere; radius 0.15; damage multiplier default
- **stem_02** — capsule; radius 0.07; damage multiplier default
- **vine_03_L** — capsule; radius 0.03; damage multiplier default
- **vine_03_R** — capsule; radius 0.03; damage multiplier default

## Species

- [[Monsters/Plants & Fungi/Thornvine|Thornvine]] — anim_plant_rooted, 3 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Man-Eater Plant|Man-Eater Plant]] — anim_plant_rooted, 2.5 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Treant Sapling|Treant Sapling]] — anim_plant_walker, 2 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Spore Lord|Spore Lord]] — anim_plant_walker, 3 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Corpse Flower|Corpse Flower]] — anim_plant_rooted, 4 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Elder Treant|Elder Treant]] — anim_plant_walker, 12 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Ancient Treant|Ancient Treant]] — anim_plant_walker, 30 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Worldroot Behemoth|Worldroot Behemoth]] — anim_plant_walker, 80 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Blighted World Root|Blighted World Root]] — anim_plant_rooted, 300 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Vesper-Touched Thornvine|Vesper-Touched Thornvine]] — anim_plant_rooted, 3 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Vine Man-Eater Plant|Vine Man-Eater Plant]] — anim_plant_rooted, 2.5 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Bog Treant Sapling|Bog Treant Sapling]] — anim_plant_walker, 2 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Bog Spore Lord|Bog Spore Lord]] — anim_plant_walker, 3 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Blaze Corpse Flower|Blaze Corpse Flower]] — anim_plant_rooted, 4 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Tide Elder Treant|Tide Elder Treant]] — anim_plant_walker, 12 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Bog Ancient Treant|Bog Ancient Treant]] — anim_plant_walker, 30 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Thunder Worldroot Behemoth|Thunder Worldroot Behemoth]] — anim_plant_walker, 80 m high, keyword rig selection
- [[Monsters/Plants & Fungi/Mycelia, the Spore Lord|Mycelia, the Spore Lord]] — anim_plant_walker, 5 m high, keyword rig selection
- [[Monsters/Plants & Fungi/The Briar King, Lord of the Winter Court|The Briar King, Lord of the Winter Court]] — anim_plant_walker, 4 m high, keyword rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
