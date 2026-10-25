using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Imports the building models (Art/Models/Buildings, from Tools/blender/town_buildings.py) ready for the toon
    /// shader: every vertex gets its smoothed normal (the average over all faces meeting at that position) written into
    /// the vertex colour, which the Ascend/Toon outline pass pushes the hull along, so the flat-shaded meshes' hard edges
    /// get an unbroken ink line.
    /// </summary>
    public sealed class BuildingImport : AssetPostprocessor
    {
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

        /// <summary>Averages the normals of vertices that share a position and stores them, as 0–1 colours, in the mesh.</summary>
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
            var colors = new Color[verts.Length];
            for (int i = 0; i < verts.Length; i++)
            {
                var n = sums[Key(verts[i])];
                n = n.sqrMagnitude > 1e-8f ? n.normalized : normals[i];
                colors[i] = new Color(n.x * 0.5f + 0.5f, n.y * 0.5f + 0.5f, n.z * 0.5f + 0.5f, 1f);
            }
            mesh.colors = colors;
        }
    }
}
