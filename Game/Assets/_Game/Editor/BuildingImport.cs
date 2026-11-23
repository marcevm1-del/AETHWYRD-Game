using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Imports the building models (Art/Models/Buildings, from Tools/blender/town_buildings.py) ready for the toon
    /// shader: every vertex gets its smoothed normal (the average over all faces meeting at that position) written into
    /// UV3 (TEXCOORD3), which the Ascend/Toon outline pass pushes the hull along, so the flat-shaded meshes' hard edges
    /// get an unbroken ink line. The vertex colour (COLOR) is albedo in the toon shader, so buildings get opaque white
    /// there: their colour lives in the materials, and the result must not depend on what Unity supplies for a missing stream.
    /// Skinned meshes (characters, monsters) never come through here, so their UV3 stays empty and the outline uses their
    /// skinned normal (UV data is not skinned).
    /// </summary>
    public sealed class BuildingImport : AssetPostprocessor
    {
        /// <summary>Bump when the data written below changes: Unity then reimports every building on its own.</summary>
        public override uint GetVersion() => 2; // 1 (implicit) wrote the smoothed normal into COLOR; 2 writes UV3 + white COLOR

        const string Folder = "Assets/_Game/Art/Models/Buildings/";

        void OnPreprocessModel()
        {
            if (!assetPath.StartsWith(Folder)) return;
            var importer = (ModelImporter)assetImporter;
            importer.isReadable = false;
            importer.importNormals = ModelImporterNormals.Import;
            importer.importAnimation = false;
            importer.animationType = ModelImporterAnimationType.None;
        }

        void OnPostprocessModel(GameObject root)
        {
            if (!assetPath.StartsWith(Folder)) return;
            foreach (var mf in root.GetComponentsInChildren<MeshFilter>())
                if (mf.sharedMesh != null) WriteSmoothNormals(mf.sharedMesh);
        }

        /// <summary>Averages the normals of vertices that share a position and stores them in UV3 (xyz, unit length); COLOR becomes white.</summary>
        public static void WriteSmoothNormals(Mesh mesh)
        {
            var verts = mesh.vertices;
            var normals = mesh.normals;
            if (normals == null || normals.Length != verts.Length) return;
            var sums = new Dictionary<Vector3Int, Vector3>();
            Vector3Int Key(Vector3 v) => new Vector3Int(Mathf.RoundToInt(v.x * 1000f), Mathf.RoundToInt(v.y * 1000f), Mathf.RoundToInt(v.z * 1000f));
            for (int i = 0; i < verts.Length; i++)
            {
                var k = Key(verts[i]);
                sums[k] = (sums.TryGetValue(k, out var s) ? s : Vector3.zero) + normals[i];
            }
            var smooth = new List<Vector3>(verts.Length);
            var colors = new Color32[verts.Length];
            for (int i = 0; i < verts.Length; i++)
            {
                var n = sums[Key(verts[i])];
                smooth.Add(n.sqrMagnitude > 1e-8f ? n.normalized : normals[i]);
                colors[i] = new Color32(255, 255, 255, 255);
            }
            mesh.SetUVs(3, smooth);   // channel 3 = TEXCOORD3; channel 1 is the lightmap UV, 2 realtime GI
            mesh.colors32 = colors;
        }
    }
}
