using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Import settings for the Whisperwood foliage kit (Art/Models/Foliage, from Tools/blender/build_foliage_kit.py):
    /// flat-shaded meshes with one vertex colour per face and one fol_* material per palette tone. Unlike
    /// <see cref="BuildingImport"/> this leaves the vertex colours alone (they are the albedo), so the foliage is placed
    /// without the outline pass, whose hull reads vertex colour as a smoothed normal.
    /// </summary>
    public sealed class FoliageImport : AssetPostprocessor
    {
        const string Folder = "Assets/_Game/Art/Models/Foliage/";

        void OnPreprocessModel()
        {
            if (!assetPath.StartsWith(Folder)) return;
            var importer = (ModelImporter)assetImporter;
            importer.isReadable = false;
            importer.importNormals = ModelImporterNormals.Import;
            importer.importAnimation = false;
            importer.animationType = ModelImporterAnimationType.None;
            importer.importCameras = false;
            importer.importLights = false;
        }
    }
}
