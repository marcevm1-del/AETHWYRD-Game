using System.Collections;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Regression tests for the bugs in reports/baseline_2026-10-25.md, run against the built Ring 0 scene.
    /// The player's real save is never read: PlayerSave.Folder points at an empty temporary folder.
    /// </summary>
    public sealed class BaselineBugsPlayModeTests
    {
        string _saveFolder, _folderWas;

        [UnitySetUp]
        public IEnumerator FreshGameInTheField()
        {
            _folderWas = PlayerSave.Folder;
            _saveFolder = Path.Combine(Path.GetTempPath(), "ascend_qa_baseline_" + System.Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_saveFolder);
            PlayerSave.Folder = _saveFolder; // a new game: no slot to load
            yield return SceneManager.LoadSceneAsync("Ring0_Graybox", LoadSceneMode.Single);
            yield return null;
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator UnloadTheField()
        {
            var empty = SceneManager.CreateScene("Empty_" + Time.frameCount);
            SceneManager.SetActiveScene(empty);
            var field = SceneManager.GetSceneByName("Ring0_Graybox");
            if (field.isLoaded) yield return SceneManager.UnloadSceneAsync(field);
            GameTime.Clear();
            AggroDirector.Reset();
            PlayerSave.Folder = _folderWas;
            try { Directory.Delete(_saveFolder, true); } catch (System.Exception) { }
        }

        /// <summary>Bug: captures show the player at 1/162 HP on a new game.</summary>
        [UnityTest]
        public IEnumerator ANewGameStartsAtFullHealth()
        {
            var combat = Object.FindFirstObjectByType<PlayerCombat>();
            var defense = combat.GetComponent<PlayerDefense>();
            Assert.IsNotNull(defense, "the player has PlayerDefense");
            Assert.AreEqual(Mathf.Max(1, combat.Stats.Hp), defense.MaxHp, "max HP follows the derived stats");
            Assert.AreEqual(defense.MaxHp, defense.Hp, $"a new game starts at full health (got {defense.Hp}/{defense.MaxHp})");
            yield return null;
        }

        /// <summary>Bug: NPC name labels read mirrored when the camera is on the far side of the NPC.</summary>
        [UnityTest]
        public IEnumerator NpcNameLabelsFaceTheCameraFromEverySide()
        {
            var cam = Camera.main;
            Assert.IsNotNull(cam, "main camera");
            var follow = cam.GetComponent<ThirdPersonCamera>();
            if (follow != null) follow.enabled = false; // hold the camera where the test puts it
            var labels = Object.FindObjectsByType<TextMesh>(FindObjectsSortMode.None).Where(t => t.name.StartsWith("Label_npc_")).ToList();
            Assert.Greater(labels.Count, 0, "NPC name labels in the scene");

            var mirrored = new System.Collections.Generic.List<string>();
            foreach (var side in new[] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right })
            {
                foreach (var label in labels)
                {
                    Vector3 at = label.transform.position;
                    cam.transform.position = at + side * 6f + Vector3.up * 0.5f;
                    cam.transform.rotation = Quaternion.LookRotation(at - cam.transform.position);
                    yield return null; // let any billboard run its Update/LateUpdate
                    // TextMesh glyphs read correctly when the label's +Z points away from the viewer.
                    float facing = Vector3.Dot(label.transform.forward, (at - cam.transform.position).normalized);
                    if (facing <= 0.5f) mirrored.Add(System.FormattableString.Invariant($"{label.name} seen from {side} (dot {facing:0.00})"));
                }
            }
            Assert.IsEmpty(mirrored, "labels not facing the camera: " + string.Join("; ", mirrored.Take(12)) + (mirrored.Count > 12 ? $" … (+{mirrored.Count - 12})" : ""));
        }
    }
}
