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
            foreach (var npc in new[] { "npc_mina_feathersby", "npc_farmer_odo", "npc_marta_gruel", "npc_captain_holt", "npc_lyra_brightwood", "npc_fennick_reed" })
                Assert.IsTrue(givers.Contains(npc), npc + " is in the field");
            Assert.IsNotNull(Object.FindFirstObjectByType<QuestBoard>(), "the guild board");
            Assert.IsNotNull(Object.FindFirstObjectByType<SiegeDirector>(), "the siege director");
            Assert.IsNotNull(Object.FindFirstObjectByType<WorldClock>(), "the clock");
            Assert.AreEqual(2, Object.FindObjectsByType<Waystone>(FindObjectsSortMode.None).Length, "both waystones (start and treeline) have their component");
            Assert.Greater(Object.FindFirstObjectByType<SiegeDirector>().Templates.Length, 0, "raider templates");
        }
    }
}
