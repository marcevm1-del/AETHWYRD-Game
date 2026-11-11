using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Ascend.Game;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Builds the Title scene (Phase 1B front end) and puts it first in the build: Title at index 0, the Ring 0 field at index 1.
    ///   Unity.exe -batchmode -projectPath Game -quit -executeMethod Ascend.EditorTools.TitleSceneBuilder.BuildBatch
    /// The scene is nearly empty on purpose: a camera and a <see cref="FrontEndController"/>, which draws every screen and builds the
    /// creator's preview stage at runtime. Regenerating is safe. Re-running Ring0SceneBuilder moves the field back to index 0 in the editor's
    /// build list; BuildPlayer always passes Title then Ring 0 itself, so the player is unaffected (run this builder again to restore the list).
    /// </summary>
    public static class TitleSceneBuilder
    {
        public const string ScenePath = "Assets/_Game/Scenes/Title.unity";
        const string FieldPath = "Assets/_Game/Scenes/Ring0_Graybox.unity";

        [MenuItem("Ascend/Front End/Build Title Scene")]
        public static void Build() => BuildInternal(false);

        public static void BuildBatch() => BuildInternal(true);

        static void BuildInternal(bool batch)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ScenePath));
                var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

                var camGo = new GameObject("Main Camera") { tag = "MainCamera" };
                var cam = camGo.AddComponent<Camera>();
                cam.clearFlags = CameraClearFlags.SolidColor;
                cam.backgroundColor = new Color(0.05f, 0.06f, 0.14f, 1f);
                cam.cullingMask = 0;
                camGo.AddComponent<AudioListener>();
                camGo.AddComponent<UnityEngine.Rendering.Universal.UniversalAdditionalCameraData>();

                new GameObject("FrontEnd").AddComponent<FrontEndController>();

                EditorSceneManager.SaveScene(scene, ScenePath);

                var list = new System.Collections.Generic.List<EditorBuildSettingsScene> { new EditorBuildSettingsScene(ScenePath, true) };
                if (File.Exists(FieldPath)) list.Add(new EditorBuildSettingsScene(FieldPath, true));
                list.AddRange(EditorBuildSettings.scenes.Where(s => s.path != ScenePath && s.path != FieldPath));
                EditorBuildSettings.scenes = list.ToArray();

                Debug.Log("[Ascend] Title scene built: " + ScenePath + " (build index 0; Ring 0 at index 1)");
                if (batch) EditorApplication.Exit(0);
            }
            catch (System.Exception e)
            {
                Debug.LogError("[Ascend] Title scene build failed: " + e);
                if (batch) EditorApplication.Exit(1);
            }
        }
    }
}
