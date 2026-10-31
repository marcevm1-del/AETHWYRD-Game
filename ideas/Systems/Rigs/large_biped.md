---
type: monster-rig
id: rig:large_biped
tags: [rig, animation, large-biped]
---
# large_biped rig

Hulking bipeds 2.5–5 m: wide shoulders, long arms (can knuckle-walk), heavy footfalls. Humanoid avatar with an extra belly jiggle bone.

| Field | Value |
|---|---|
| Aliases | ogre, troll, minotaur, treant, giant_humanoid, hobgoblin_large |
| Species using rig | 49 |
| Families represented | Goblinoids, Orcs, Ogres & Giants, Minotaurs & Beastmen, Plants & Fungi, Yokai-Inspired Spirits, Floor-born |
| Bone count · budget | 35 · 55 |
| Unity avatar · material | Humanoid · flesh |
| Reference size · axis | 3.5 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.2,"legFrac":0.48},{"name":"run","froude":1,"legFrac":0.48},{"name":"knuckle_charge","froude":1.8,"legFrac":0.48}],"fantasyMult":1.1,"turnDegPerSecAt1m":380,"accelG":0.45,"jumpHeightFrac":0.15,"canClimb":false,"canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.018,"density":1000,"collider":{"type":"capsule","radiusFrac":0.2,"heightFrac":1},"gravityScale":1.3,"linearDrag":0.05,"knockbackResist":0.75,"launchable":"only_while_staggered","ragdoll":"partial","deathStyle":"heavy_fall_dust"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":32,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":16,"e":"footstep_R"}]},{"name":"run","frames":20,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":10,"e":"footstep_R"}]},{"name":"walk_back","frames":32,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_L","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_R","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"knuckle_charge","frames":18,"loop":true,"rootMotion":true,"events":[]},{"name":"ground_pound","frames":45,"loop":false,"rootMotion":false,"events":[{"f":8,"e":"telegraph"},{"f":28,"e":"hit_on"},{"f":30,"e":"land"}]},{"name":"grab_attempt","frames":36,"loop":false,"rootMotion":true,"events":[]},{"name":"grab_hold_loop","frames":30,"loop":true,"rootMotion":false,"events":[]},{"name":"throw_held","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"roar","frames":60,"loop":false,"rootMotion":false,"events":[{"f":12,"e":"vocal"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_06","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["look_at_target","foot_ik_ground","heavy_breathing","footstep_camera_shake","ground_crack_decal_on_land"]

## Default hurtboxes

- **head** — sphere; radius 0.08; damage multiplier default
- **chest** — capsule; radius 0.17; damage multiplier default
- **belly** — sphere; radius 0.15; damage multiplier default
- **thigh_L** — capsule; radius 0.07; damage multiplier default
- **thigh_R** — capsule; radius 0.07; damage multiplier default
- **forearm_L** — capsule; radius 0.05; damage multiplier default
- **forearm_R** — capsule; radius 0.05; damage multiplier default

## Species

- [[Monsters/Goblinoids/Goblin King|Goblin King]] — anim_large_biped, 2.8 m high, rigId rig selection
- [[Monsters/Goblinoids/Oni Warlord|Oni Warlord]] — anim_large_biped, 4.5 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Ogre|Ogre]] — anim_large_biped, 3.5 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Troll|Troll]] — anim_large_biped, 3.2 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Hill Giant|Hill Giant]] — anim_large_biped, 7 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Cyclops|Cyclops]] — anim_large_biped, 6 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Frost Giant|Frost Giant]] — anim_large_biped, 9 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Fire Giant|Fire Giant]] — anim_large_biped, 9 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Orc Disaster|Orc Disaster]] — anim_large_biped, 4 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Primeval Titan-Kin|Primeval Titan-Kin]] — anim_large_biped, 40 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Titan Remnant|Titan Remnant]] — anim_large_biped, 300 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Calf Minotaur|Calf Minotaur]] — anim_large_biped, 2 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Minotaur|Minotaur]] — anim_large_biped, 3.2 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Labyrinth Minotaur|Labyrinth Minotaur]] — anim_large_biped, 4 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Taurgrim, the Maze King|Taurgrim, the Maze King]] — anim_large_biped, 6 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Treant Sapling|Treant Sapling]] — anim_plant_walker, 2 m high, override rig selection
- [[Monsters/Plants & Fungi/Spore Lord|Spore Lord]] — anim_plant_walker, 3 m high, override rig selection
- [[Monsters/Yokai-Inspired Spirits/Oni|Oni]] — anim_large_biped, 3.5 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Hunger Colossus|Hunger Colossus]] — anim_large_biped, 30 m high, rigId rig selection
- [[Monsters/Floor-born/Floor Tyrant|Floor Tyrant]] — anim_large_biped, 8 m high, rigId rig selection
- [[Monsters/Goblinoids/Zephyr Goblin King|Zephyr Goblin King]] — anim_large_biped, 2.8 m high, rigId rig selection
- [[Monsters/Goblinoids/Radiant Oni Warlord|Radiant Oni Warlord]] — anim_large_biped, 4.5 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Rime Ogre|Rime Ogre]] — anim_large_biped, 3.5 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Cinder Troll|Cinder Troll]] — anim_large_biped, 3.2 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Hill Giant|Vesper-Touched Hill Giant]] — anim_large_biped, 7 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Cyclops|Vesper-Touched Cyclops]] — anim_large_biped, 6 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Frost Giant|Vesper-Touched Frost Giant]] — anim_large_biped, 9 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Cinder Giant|Cinder Giant]] — anim_large_biped, 9 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Elder Orc Disaster|Elder Orc Disaster]] — anim_large_biped, 6.4 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Elder Primeval Titan-Kin|Elder Primeval Titan-Kin]] — anim_large_biped, 64 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Vesper-Touched Calf Minotaur|Vesper-Touched Calf Minotaur]] — anim_large_biped, 2 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Deep Minotaur|Deep Minotaur]] — anim_large_biped, 3.2 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Vesper-Touched Labyrinth Minotaur|Vesper-Touched Labyrinth Minotaur]] — anim_large_biped, 4 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Bog Treant Sapling|Bog Treant Sapling]] — anim_plant_walker, 2 m high, override (base species) rig selection
- [[Monsters/Plants & Fungi/Bog Spore Lord|Bog Spore Lord]] — anim_plant_walker, 3 m high, override (base species) rig selection
- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Oni|Vesper-Touched Oni]] — anim_large_biped, 3.5 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Rain Hunger Colossus|Rain Hunger Colossus]] — anim_large_biped, 30 m high, rigId rig selection
- [[Monsters/Floor-born/Greater Floor Tyrant|Greater Floor Tyrant]] — anim_large_biped, 12.8 m high, rigId rig selection
- [[Monsters/Goblinoids/Ancient Goblin King|Ancient Goblin King]] — anim_large_biped, 4.2 m high, rigId rig selection
- [[Monsters/Goblinoids/Blight Oni Warlord|Blight Oni Warlord]] — anim_large_biped, 4.5 m high, rigId rig selection
- [[Monsters/Plants & Fungi/Mycelia, the Spore Lord|Mycelia, the Spore Lord]] — anim_plant_walker, 5 m high, override rig selection
- [[Monsters/Orcs, Ogres & Giants/Skarn, the Fire Giant Warlord|Skarn, the Fire Giant Warlord]] — anim_large_biped, 9.5 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Grakkus, the Orc Disaster|Grakkus, the Orc Disaster]] — anim_large_biped, 4.5 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Kurogane, the Oni Warlord|Kurogane, the Oni Warlord]] — anim_large_biped, 4.5 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Ymgrir, the Frost Sovereign|Ymgrir, the Frost Sovereign]] — anim_large_biped, 11 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Wuxiang, the Hunger Colossus|Wuxiang, the Hunger Colossus]] — anim_large_biped, 30 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Zahhar, King of the Divs|Zahhar, King of the Divs]] — anim_large_biped, 8 m high, rigId rig selection
- [[Monsters/Plants & Fungi/The Briar King, Lord of the Winter Court|The Briar King, Lord of the Winter Court]] — anim_plant_walker, 4 m high, override rig selection
- [[Monsters/Orcs, Ogres & Giants/Ukhu-Tal, Stone Giant of the First Making|Ukhu-Tal, Stone Giant of the First Making]] — anim_large_biped, 25 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
