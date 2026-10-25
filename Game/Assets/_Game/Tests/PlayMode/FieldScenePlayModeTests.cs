using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The built Ring 0 / Whisperwood scene has what the quest data needs (places, givers, the board, the siege).</summary>
    public sealed class FieldScenePlayModeTests
    {
        string _saveFolder;

        [SetUp]
        public void SandboxTheSave()
        {
            // The field's PlayerSave loads on Start: point it at an empty folder so the player's real slot is never read or written.
            _saveFolder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ascend_qa_field_" + System.Guid.NewGuid().ToString("N"));
            System.IO.Directory.CreateDirectory(_saveFolder);
            PlayerSave.Folder = _saveFolder;
        }

        [UnityTearDown]
        public IEnumerator UnloadTheField()
        {
            // The field has its own player, monsters and clock: unload it so later tests start clean.
            var empty = SceneManager.CreateScene("Empty_" + Time.frameCount);
            SceneManager.SetActiveScene(empty);
            var field = SceneManager.GetSceneByName("Ring0_Graybox");
            if (field.isLoaded) yield return SceneManager.UnloadSceneAsync(field);
            GameTime.Clear();
            AggroDirector.Reset();
            PlayerSave.Folder = null;
            try { System.IO.Directory.Delete(_saveFolder, true); } catch (System.Exception) { }
        }

        [UnityTest]
        public IEnumerator EveryReachTargetAndGiverExistsInTheField()
        {
            yield return SceneManager.LoadSceneAsync("Ring0_Graybox", LoadSceneMode.Single);
            yield return null;
            var places = Object.FindObjectsByType<QuestPlace>(FindObjectsSortMode.None).Select(p => p.PlaceId).ToHashSet();
            var db = AscendData.Db;
            var reach = db.Quests.Values.SelectMany(q => q.Objectives)
                .Concat(db.WeeklyQuests.Values.Where(w => w.Playable).SelectMany(w => w.Objectives))
                .Where(o => o.Kind == "reach").Select(o => o.Target).Distinct().ToList();
            var missing = reach.Where(t => !places.Contains(t)).ToList();
            Assert.IsEmpty(missing, "reach targets without a place: " + string.Join(", ", missing));

            // Defend targets: settlements and the north gate are covered by live raids; every other spot needs a DefenceSpot.
            var spots = Object.FindObjectsByType<DefenceSpot>(FindObjectsSortMode.None).Select(d => d.PlaceId).ToHashSet();
            var defend = db.Quests.Values.SelectMany(q => q.Objectives)
                .Concat(db.WeeklyQuests.Values.Where(w => w.Playable).SelectMany(w => w.Objectives))
                .Where(o => o.Kind == "defend" && o.Target != "{settlement}" && o.Target != "North Gate").Select(o => o.Target).Distinct().ToList();
            var undefended = defend.Where(t => !spots.Contains(t)).ToList();
            Assert.IsEmpty(undefended, "defend targets without a defence spot: " + string.Join(", ", undefended));

            var givers = Object.FindObjectsByType<QuestGiver>(FindObjectsSortMode.None).Select(g => g.NpcId).ToHashSet();
            foreach (var npc in new[] { "npc_mina_feathersby", "npc_rodrick_hale", "npc_farmer_odo", "npc_marta_gruel", "npc_captain_holt", "npc_lyra_brightwood", "npc_fennick_reed" })
                Assert.IsTrue(givers.Contains(npc), npc + " is in the field");
            Assert.IsTrue(Object.FindObjectsByType<QuestGiver>(FindObjectsSortMode.None).Where(g => g.GetComponent<QuestBoard>() == null).All(g => g.HasMarker), "every NPC keeps its !/? marker in the saved scene");
            Assert.IsNotNull(Object.FindFirstObjectByType<EscortNpc>(), "Ottoline's escort");
            Assert.IsTrue(Object.FindObjectsByType<CompanionAI>(FindObjectsInactive.Include, FindObjectsSortMode.None).Any(c => c.GetComponent<QuestGiver>().NpcId == "npc_lyra_brightwood" && !c.enabled), "Lyra is ready to join (not yet travelling)");
            Assert.IsNotNull(Object.FindFirstObjectByType<QuestBoard>(), "the guild board");
            var nodes = Object.FindObjectsByType<GatherNode>(FindObjectsSortMode.None);
            Assert.GreaterOrEqual(nodes.Length, 10, "gathering nodes");
            Assert.AreEqual(nodes.Length, nodes.Select(x => x.Key).Distinct().Count(), "each node has its own save key");
            Assert.IsTrue(nodes.All(x => x.Data != null && x.Fresh != null), "every node is set up");
            Assert.IsNotNull(Object.FindFirstObjectByType<SiegeDirector>(), "the siege director");
            Assert.IsNotNull(Object.FindFirstObjectByType<WorldClock>(), "the clock");
            Assert.AreEqual(2, Object.FindObjectsByType<Waystone>(FindObjectsSortMode.None).Length, "both waystones (start and treeline) have their component");
            Assert.Greater(Object.FindFirstObjectByType<SiegeDirector>().Templates.Length, 0, "raider templates");

            // Monsters live in the forest and beyond: none inside the town ward, where you start.
            Assert.IsNotNull(Object.FindFirstObjectByType<TownWard>(), "Brindlewick's ward");
            var inTown = Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None).Where(m => TownWard.Contains(m.transform.position)).Select(m => m.SpeciesId).ToList();
            Assert.IsEmpty(inTown, "monsters living in town: " + string.Join(", ", inTown));
            Assert.IsTrue(TownWard.Contains(Object.FindFirstObjectByType<PlayerCombat>().transform.position), "you start inside the ward");
        }
    }
}
