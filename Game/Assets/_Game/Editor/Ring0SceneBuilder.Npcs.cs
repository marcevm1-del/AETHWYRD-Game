using System.Linq;
using Ascend.Game;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Quest NPCs and "reach" places for the test fields. NPCs are coloured capsule stand-ins with a name label and a
    /// floating quest marker ("!" offer, "?" hand in) until characters are modelled; ids are from npcs.json.
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        static void BuildQuestNpcs(Transform world)
        {
            var root = new GameObject("NPCs").transform;
            // Brindlewick side of the field (Ring 0).
            Npc(root, "npc_mina_feathersby", new Vector3(3.5f, 0, -3f), new Color(0.85f, 0.55f, 0.75f));   // guild receptionist
            Npc(root, "npc_rodrick_hale", new Vector3(8f, 0, -5.5f), new Color(0.45f, 0.35f, 0.6f));    // the F→E trial (Goblin Chief of Hollowpine)
            Npc(root, "npc_farmer_odo", new Vector3(4.5f, 0, 3.5f), new Color(0.75f, 0.6f, 0.35f));        // by the slime patch, clear of the test ramp
            Npc(root, "npc_marta_gruel", new Vector3(-6.5f, 0, -1.5f), new Color(0.85f, 0.4f, 0.3f));        // the Sleeping Griffon's keeper
            Npc(root, "npc_torvald_stonebeard", new Vector3(-4f, 0, -5f), new Color(0.5f, 0.4f, 0.35f));   // smithy stall
            Npc(root, "npc_traveling_merchant_pell", new Vector3(5f, 0, 25f), new Color(0.9f, 0.6f, 0.2f)); // wagon at the Whisperwood edge
            // Ottoline's escort job: from her wagon, out of the gate and east to Millbrook, with goblin ambushes.
            var cart = root.Find("npc_traveling_merchant_pell").gameObject.AddComponent<EscortNpc>();
            cart.Followers = new[] { root.Find("Label_npc_traveling_merchant_pell"), root.Find("Marker_npc_traveling_merchant_pell") };
            cart.Route = new[] { new Vector3(5f, 0, 22.5f), new Vector3(0f, 0, 22.5f), new Vector3(0f, 0, 17f), new Vector3(14f, 0, 10f), new Vector3(22f, 0, 2f) };
            // Whisperwood side, by the treeline waystone and the ruins.
            Npc(root, "npc_lyra_brightwood", new Vector3(3f, 0, 27f), new Color(0.95f, 0.8f, 0.4f));
            // Lyra can join you as a companion (companion_field_ai.md Ring 0 prototype); off until she does.
            var lyra = root.Find("npc_lyra_brightwood").gameObject.AddComponent<CompanionAI>();
            lyra.Followers = new[] { root.Find("Label_npc_lyra_brightwood"), root.Find("Marker_npc_lyra_brightwood") };
            lyra.enabled = false;
            Npc(root, "npc_fennick_reed", new Vector3(-7f, 0, 29f), new Color(0.45f, 0.75f, 0.45f));
            Npc(root, "npc_eolande_fairweather", new Vector3(7f, 0, 30f), new Color(0.55f, 0.5f, 0.9f));
            Npc(root, "npc_dax_rowan", new Vector3(-12f, 0, 31f), new Color(0.8f, 0.25f, 0.25f));

            Npc(root, "npc_captain_holt", new Vector3(-3f, 0, 18.5f), new Color(0.6f, 0.6f, 0.7f));        // the gate's watch captain (siege contracts)

            // The guild board beside Mina: today's Day Special, dailies and the weekly commission.
            var board = Prim(PrimitiveType.Cube, "GuildBoard", new Vector3(6f, 1.1f, -3.5f), new Vector3(1.8f, 1.4f, 0.15f), Mat("Wood", new Color(0.55f, 0.38f, 0.24f)), root);
            board.transform.rotation = Quaternion.Euler(0, -30f, 0);
            board.AddComponent<QuestGiver>().NpcId = "npc_guild_clerk_wendel";
            board.AddComponent<QuestBoard>();
            Label(root, new Vector3(6f, 2.1f, -3.5f), "Guild Board", new Color(1f, 0.9f, 0.6f), 0.035f);

            Place(root, "brindlewick_north_gate", new Vector3(0, 0, 20f), 3.5f);
            // Stand-ins for the other places quests and board jobs send you (reach objectives in quests.json and weekly_board.json).
            Landmark(root, "Old Watchtower", "Old Watchtower", new Vector3(-25f, 0, 40f));
            Landmark(root, "Boar den, Whisperwood", "Boar den", new Vector3(-20f, 0, 62f));
            Landmark(root, "Rooftops of Brindlewick", "Rooftops of Brindlewick", new Vector3(-12f, 0, -12f));
            Landmark(root, "Orphanage of the Small Lantern", "Orphanage of the Small Lantern", new Vector3(12f, 0, -10f));
            Landmark(root, "Temple Hill graveyard", "Temple Hill graveyard", new Vector3(-18f, 0, -8f));
            Landmark(root, "hollis_yard_dawn", "Old Hollis's yard", new Vector3(-8f, 0, -11f));
            Landmark(root, "Millbrook turnip field", "Millbrook turnip field", new Vector3(18f, 0, 6f));
            Landmark(root, "millbrook_fields_night", "Millbrook fields", new Vector3(21f, 0, 12f));
            Landmark(root, "mistvale_farms", "Mistvale farms", new Vector3(23f, 0, -14f));
            BuildSiege();
            BuildGathering(root);

            // Defence events (defend objectives at a spot): Millbrook's granary (Hesk's quest) and the training-yard mock raid.
            Npc(root, "npc_farmer_hesk", new Vector3(24f, 0, 1f), new Color(0.7f, 0.55f, 0.3f));
            Defence(root, "millbrook_granary", "Millbrook granary", new Vector3(26f, 0, 4f), new[] { "mon_goblin:4", "mon_goblin:4" });
            Defence(root, "Training yard mock raid", "Training yard", new Vector3(-9f, 0, 15f), new[] { "mon_blue_slime:3", "mon_horned_rabbit:2" });
            Place(root, "whisperwood_ruins_mural", new Vector3(0, 0, 88f), 10f);
        }

        /// <summary>
        /// Whisperwood's raids on the Brindlewick gate: a SiegeDirector plus one inactive template per raider species
        /// (its blockout model when exported, else a labelled capsule), cloned at runtime for each wave.
        /// </summary>
        static void BuildSiege()
        {
            var director = new GameObject("SiegeDirector").AddComponent<SiegeDirector>();
            director.Gate = new Vector3(0, 0, 21.5f);
            director.Muster = new Vector3(0, 0, 50f);
            var holder = new GameObject("SiegeTemplates");
            var waves = AscendData.Db.SiegeWaves["reg_whisperwood"];
            var templates = new System.Collections.Generic.List<GameObject>();
            var standIn = Mat("MonsterStandIn", new Color(0.8f, 0.45f, 0.55f));
            foreach (var id in waves.Waves.SelectMany(w => w.Units).Select(u => u.SpeciesId).Distinct())
            {
                var wrapper = new GameObject("Raider_" + id);
                wrapper.transform.SetParent(holder.transform, false);
                var at = new Vector3(0, 0, 0.01f); // faces -z (toward the gate) when cloned with the march rotation
                if (!Model(wrapper.transform, id, id, at))
                {
                    float size = AscendData.Db.Species.TryGetValue(id, out var sp) && sp.SizeMeters > 0 ? (float)sp.SizeMeters : 1f;
                    var s = new Vector3(size * 0.45f, size * 0.5f, size * 0.45f);
                    Dummy(wrapper.transform, id, PrimitiveType.Capsule, at + Vector3.up * s.y, s, standIn);
                }
                templates.Add(wrapper);
            }
            holder.SetActive(false);
            director.Templates = templates.ToArray();
        }

        /// <summary>Gathering nodes (gathering.json): herb patches, mushroom rings, weeping pines and scrap heaps.</summary>
        static void BuildGathering(Transform parent)
        {
            var root = new GameObject("Gathering").transform;
            root.SetParent(parent, false);
            var leaf = Mat("Herb", new Color(0.35f, 0.75f, 0.35f));
            var cap = Mat("Mushroom", new Color(0.85f, 0.3f, 0.25f));
            var bark = Mat("Bark", new Color(0.36f, 0.26f, 0.18f));
            var amber = Mat("Sap", new Color(0.95f, 0.65f, 0.15f), 0.8f);
            var scrap = Mat("Scrap", new Color(0.5f, 0.5f, 0.52f), 0.5f);
            int n = 0;
            void Node(string id, Vector3 at)
            {
                var go = new GameObject($"Gather_{id.Substring(5)}_{++n}");
                go.transform.SetParent(root, false);
                go.transform.position = at;
                var fresh = new GameObject("Fresh");
                fresh.transform.SetParent(go.transform, false);
                switch (id)
                {
                    case "node_herb_patch":
                        for (int i = 0; i < 4; i++) Prim(PrimitiveType.Sphere, "Leaf", at + new Vector3((i % 2) * 0.4f - 0.2f, 0.15f, (i / 2) * 0.4f - 0.2f), new Vector3(0.45f, 0.3f, 0.45f), leaf, fresh.transform, keepCollider: false);
                        break;
                    case "node_mushroom_ring":
                        for (int i = 0; i < 6; i++) { float a = i * Mathf.PI / 3f; Prim(PrimitiveType.Cylinder, "Cap", at + new Vector3(Mathf.Cos(a), 0.12f, Mathf.Sin(a)) * 0.7f, new Vector3(0.25f, 0.12f, 0.25f), cap, fresh.transform, keepCollider: false); }
                        break;
                    case "node_sap_tree":
                        Prim(PrimitiveType.Cylinder, "Trunk", at + Vector3.up * 2f, new Vector3(0.6f, 2f, 0.6f), bark, go.transform);
                        Prim(PrimitiveType.Sphere, "Sap", at + new Vector3(0, 1.2f, -0.32f), new Vector3(0.3f, 0.4f, 0.15f), amber, fresh.transform, keepCollider: false);
                        break;
                    default:
                        for (int i = 0; i < 4; i++) Prim(PrimitiveType.Cube, "Scrap", at + new Vector3(i * 0.3f - 0.45f, 0.2f + (i % 2) * 0.2f, (i % 3) * 0.25f), new Vector3(0.5f, 0.3f, 0.4f), scrap, fresh.transform, Quaternion.Euler(0, i * 37f, i * 11f), keepCollider: false);
                        break;
                }
                var node = go.AddComponent<GatherNode>();
                node.NodeId = id; node.Fresh = fresh;
            }
            // Brindlewick field
            Node("node_herb_patch", new Vector3(10f, 0, -8f));
            Node("node_herb_patch", new Vector3(-10f, 0, 6f));
            Node("node_herb_patch", new Vector3(14f, 0, 14f));
            Node("node_scrap_heap", new Vector3(-11.5f, 0, 15.5f));
            // Whisperwood
            Node("node_herb_patch", new Vector3(6f, 0, 34f));
            Node("node_herb_patch", new Vector3(-14f, 0, 40f));
            Node("node_herb_patch", new Vector3(12f, 0, 58f));
            Node("node_mushroom_ring", new Vector3(-6f, 0, 54f));
            Node("node_mushroom_ring", new Vector3(8f, 0, 72f));
            Node("node_sap_tree", new Vector3(-22f, 0, 36f));
            Node("node_sap_tree", new Vector3(21f, 0, 46f));
            Node("node_sap_tree", new Vector3(-7f, 0, 79f));
            Node("node_scrap_heap", new Vector3(5f, 0, 63f));
        }

        /// <summary>A defend-objective spot: a fenced square with a sign, and the DefenceSpot that runs the attack.</summary>
        static void Defence(Transform parent, string placeId, string shownAs, Vector3 at, string[] waves)
        {
            var go = new GameObject("Defence_" + placeId);
            go.transform.SetParent(parent, false);
            go.transform.position = at;
            var spot = go.AddComponent<DefenceSpot>();
            spot.PlaceId = placeId; spot.Waves = waves;
            var wood = Mat("Wood", new Color(0.55f, 0.38f, 0.24f));
            for (int i = 0; i < 4; i++) // a low fence around the spot
            {
                float a = i * Mathf.PI / 2f;
                var c = at + new Vector3(Mathf.Cos(a), 0, Mathf.Sin(a)) * 3f + Vector3.up * 0.4f;
                Prim(PrimitiveType.Cube, $"Fence_{placeId}_{i}", c, new Vector3(i % 2 == 0 ? 0.15f : 4f, 0.8f, i % 2 == 0 ? 4f : 0.15f), wood, parent);
            }
            Label(parent, at + Vector3.up * 2.2f, shownAs, new Color(1f, 0.92f, 0.7f), 0.03f);
        }

        static void Npc(Transform parent, string npcId, Vector3 feet, Color color)
        {
            var go = Prim(PrimitiveType.Capsule, npcId, feet + Vector3.up * 0.9f, new Vector3(0.6f, 0.9f, 0.6f), Mat("Npc_" + npcId, color), parent);
            go.transform.rotation = Quaternion.LookRotation(new Vector3(-feet.x, 0, -feet.z).normalized + Vector3.forward * 0.001f);
            var giver = go.AddComponent<QuestGiver>();
            giver.NpcId = npcId;

            var label = Label(parent, feet + Vector3.up * 2.05f, AscendData.Db.Npcs.TryGetValue(npcId, out var n) ? $"{n.Name}\n<size=36>{n.Role}</size>" : npcId, Color.white, 0.03f);
            label.GetComponent<TextMesh>().richText = true;
            label.name = "Label_" + npcId;
            label.GetComponent<FaceCamera>().NpcName = true; // hidden while the HUD draws its nameplate
            var marker = Label(parent, feet + Vector3.up * 2.65f, "", new Color(1f, 0.85f, 0.2f), 0.09f);
            marker.name = "Marker_" + npcId;
            giver.SetMarker(marker.GetComponent<TextMesh>());
        }

        static GameObject Label(Transform parent, Vector3 at, string text, Color color, float size)
        {
            var go = new GameObject("Label");
            go.transform.SetParent(parent, false);
            go.transform.position = at;
            var tm = go.AddComponent<TextMesh>();
            tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            go.GetComponent<MeshRenderer>().sharedMaterial = tm.font.material;
            tm.characterSize = size; tm.fontSize = 48; tm.anchor = TextAnchor.LowerCenter; tm.alignment = TextAlignment.Center;
            tm.color = color; tm.text = text;
            go.AddComponent<FaceCamera>(); // turn toward the camera at runtime so it never reads mirrored
            return go;
        }

        static QuestPlace Place(Transform parent, string placeId, Vector3 at, float radius)
        {
            var go = new GameObject("Place_" + placeId);
            go.transform.SetParent(parent, false);
            go.transform.position = at;
            var p = go.AddComponent<QuestPlace>();
            p.PlaceId = placeId; p.Radius = radius;
            return p;
        }

        /// <summary>A stand-in for a named place a quest sends you to: a lantern post with its name, until the real spot is built.</summary>
        static void Landmark(Transform parent, string placeId, string shownAs, Vector3 at)
        {
            Place(parent, placeId, at, 4f).ShownAs = shownAs;
            Prim(PrimitiveType.Cylinder, "Landmark_" + placeId, at + Vector3.up * 1.2f, new Vector3(0.15f, 1.2f, 0.15f), Mat("Wood", new Color(0.55f, 0.38f, 0.24f)), parent);
            Prim(PrimitiveType.Sphere, "Lamp_" + placeId, at + Vector3.up * 2.5f, Vector3.one * 0.35f, Mat("Lamp", new Color(1f, 0.85f, 0.45f), 0.8f), parent, keepCollider: false);
            Label(parent, at + Vector3.up * 2.9f, shownAs, new Color(1f, 0.92f, 0.7f), 0.03f);
        }
    }
}
