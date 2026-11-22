// Monster models carry their colour in a vertex-colour attribute: the generator paints skin, belly counter-shading
// and species markings per vertex, and the FBX export preserves it. Unity's model importer, though, assigns
// Universal Render Pipeline/Lit, which ignores vertex colour completely — so every one of the 680 monsters rendered
// as flat grey plastic and nobody noticed, because the data was there the whole time (measured 2026-11-22: 378 of
// 378 sampled materials on URP/Lit).
//
// AscendToon.shader already declares `float4 color : COLOR` and reads it. This points monster materials at it on
// import, which is the one place the decision belongs: it then applies to every re-export without anyone
// remembering to do it.
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Ascend.EditorTools
{
    public sealed class MonsterMaterialPostprocessor : AssetPostprocessor
    {
        const string MonsterDir = "Assets/_Game/Art/Models/Monsters";
        const string ToonShader = "Ascend/Toon";

        bool IsMonster => assetPath != null && assetPath.Replace('\\', '/').StartsWith(MonsterDir);

        /// <summary>
        /// Called for each material a model import creates. This is the hook that fires for EMBEDDED materials,
        /// which is what our models use. The obvious-looking OnAssignMaterialModel only runs when a model is set to
        /// external materials, so it never fired here - measured, not assumed: a re-import of 21 models produced no
        /// log line from it and left all 163 materials on URP/Lit.
        /// </summary>
        /// <summary>
        /// The modern FBX material hook. Two earlier attempts are recorded because each looked right and did
        /// nothing: OnAssignMaterialModel only fires for EXTERNAL materials, and OnPostprocessMaterial only for the
        /// legacy description path. Both left all 163 materials of the Lycanthropes on URP/Lit, measured twice.
        /// </summary>
        void OnPreprocessMaterialDescription(MaterialDescription description, Material material, AnimationClip[] clips)
        {
            Apply(material);
        }

        void OnPostprocessMaterial(Material material)
        {
            Apply(material);
        }

        void Apply(Material material)
        {
            if (!IsMonster || material == null) return;

            var shader = Shader.Find(ToonShader);
            if (shader == null)
            {
                // Say so rather than silently shipping grey monsters again: a missing shader is exactly the kind of
                // thing that would otherwise be invisible until someone looked at the game.
                Debug.LogWarning("[monster-mat] shader '" + ToonShader + "' not found; leaving " + assetPath
                                 + " on the importer's default. Monster vertex colours will not render.");
                return;
            }

            material.shader = shader;
            // The generator's colours are the model's colours; the material must not tint them.
            if (material.HasProperty("_BaseColor")) material.SetColor("_BaseColor", Color.white);
            if (material.HasProperty("_Color")) material.SetColor("_Color", Color.white);
        }
    }
}
