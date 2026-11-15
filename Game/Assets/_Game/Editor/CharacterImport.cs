using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Imports generated characters (Tools/blender/ascend_characters, FBX copied into Art/Models/Characters/) ready to play:
    /// Humanoid avatar from the T-pose, blend shapes kept for the face rig, the generator's CH_* materials switched to
    /// Ascend/ToonCharacter, and the smoothed outline normal written into UV3 (the vertex colour carries the paint, and UV1/UV2
    /// carry the colour-slot masks written by slots.py). See 13_Production/character_system.md, "How Unity should import it".
    /// </summary>
    public sealed class CharacterImport : AssetPostprocessor
    {
        public const string Folder = "Assets/_Game/Art/Models/Characters/";
        public const string Shader = "Ascend/ToonCharacter";

        void OnPreprocessModel()
        {
            if (!assetPath.StartsWith(Folder)) return;
            var importer = (ModelImporter)assetImporter;
            importer.animationType = ModelImporterAnimationType.Human;
            importer.avatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;
            importer.importBlendShapes = true;
            importer.importNormals = ModelImporterNormals.Import;
            importer.importAnimation = false;
            importer.isReadable = false;
            importer.materialImportMode = ModelImporterMaterialImportMode.ImportViaMaterialDescription;
        }

        void OnPostprocessMaterial(Material material)
        {
            if (!assetPath.StartsWith(Folder) || material == null || !material.name.StartsWith("CH_")) return;
            var s = UnityEngine.Shader.Find(Shader);
            if (s == null) { Debug.LogWarning($"[CharacterImport] {Shader} not found; {material.name} keeps its shader"); return; }
            material.shader = s;
            material.SetColor("_BaseColor", Color.white);
            if (material.name.StartsWith("CH_eyes") || material.name.StartsWith("CH_face")) material.SetFloat("_OutlineWidth", 0f); // decals: no ink hull
            else material.SetFloat("_OutlineWidth", 0.006f);
        }

        void OnPostprocessModel(GameObject root)
        {
            if (!assetPath.StartsWith(Folder)) return;
            int masked = 0, meshes = 0;
            foreach (var r in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
            {
                var mesh = r.sharedMesh;
                if (mesh == null) continue;
                meshes++;
                WriteSmoothNormalsToUv3(mesh);
                var slots = new List<Vector2>();
                mesh.GetUVs(1, slots);
                if (slots.Count == mesh.vertexCount) masked++;
            }
            if (masked < meshes)
                Debug.LogWarning($"[CharacterImport] {assetPath}: {meshes - masked} of {meshes} meshes have no colour-slot masks (UV1); re-export with the current generator to make them recolourable");
        }

        /// <summary>Averages the normals of vertices that share a position and stores them in UV3 for the outline pass.</summary>
        public static void WriteSmoothNormalsToUv3(Mesh mesh)
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
            for (int i = 0; i < verts.Length; i++)
            {
                var n = sums[Key(verts[i])];
                smooth.Add(n.sqrMagnitude > 1e-8f ? n.normalized : normals[i]);
            }
            mesh.SetUVs(3, smooth);
        }
    }
}
