// Forces a re-import of the monster models so the material postprocessor runs over models already in the project,
// then reports which shaders they ended up on.
//
//   Unity.exe -batchmode -quit -projectPath Game -executeMethod Ascend.EditorTools.ReimportMonsters.Run
//   Unity.exe -batchmode -quit -projectPath Game -executeMethod Ascend.EditorTools.ReimportMonsters.RunOneFamily
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    public static class ReimportMonsters
    {
        const string Dir = "Assets/_Game/Art/Models/Monsters";

        public static void Run() => Reimport(Dir, int.MaxValue);

        /// <summary>One family first: a full re-import of 680 models is slow and this proves the mechanism.</summary>
        public static void RunOneFamily() => Reimport(Dir + "/Lycanthropes", int.MaxValue);

        static void Reimport(string dir, int limit)
        {
            var guids = AssetDatabase.FindAssets("t:Model", new[] { dir });
            Debug.Log("[reimport] " + guids.Length + " models under " + dir);
            var n = 0;
            foreach (var g in guids)
            {
                if (n >= limit) break;
                AssetDatabase.ImportAsset(AssetDatabase.GUIDToAssetPath(g), ImportAssetOptions.ForceUpdate);
                n++;
            }
            AssetDatabase.Refresh();

            var shaders = new Dictionary<string, int>();
            foreach (var g in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(g);
                foreach (var m in AssetDatabase.LoadAllAssetsAtPath(path).OfType<Material>())
                {
                    var name = m.shader != null ? m.shader.name : "(null)";
                    shaders.TryGetValue(name, out var c);
                    shaders[name] = c + 1;
                }
            }
            foreach (var kv in shaders.OrderByDescending(k => k.Value))
                Debug.Log("[reimport] shader: " + kv.Key + "  x" + kv.Value);
            Debug.Log("[reimport] re-imported " + n);
            if (Application.isBatchMode) EditorApplication.Exit(0);
        }
    }
}
