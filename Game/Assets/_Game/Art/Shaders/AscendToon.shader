// Anime-style toon shading for buildings and structures (13_Production/anime_building_style.md):
// two-tone cel shading with a cool, violet-tinted shadow, a soft rim light, emission for lamps and runes, and an
// inverted-hull ink outline. The outline pushes vertices along the smoothed normal the import step writes into UV3
// (TEXCOORD3, BuildingImport.cs), so flat-shaded hard edges don't crack; meshes without it (all skinned ones) fall back
// to the vertex normal. The vertex colour (COLOR) is albedo: characters and monsters are painted into the Blender
// colour attribute `Col`, exported as sRGB, and multiplied into _BaseColor here (converted to linear first).
Shader "Ascend/Toon"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
        _ShadowTint ("Shadow Tint", Color) = (0.58, 0.56, 0.78, 1)
        _ShadowStep ("Shadow Step", Range(0, 1)) = 0.5
        _ShadowSoftness ("Shadow Softness", Range(0.001, 0.3)) = 0.03
        _AmbientStrength ("Ambient Strength", Range(0, 1)) = 0.35
        _RimColor ("Rim Color", Color) = (1, 0.97, 0.9, 0.22)
        _RimPower ("Rim Power", Range(0.5, 8)) = 3.5
        [HDR] _EmissionColor ("Emission", Color) = (0, 0, 0, 0)
        _OutlineColor ("Outline Color", Color) = (0.16, 0.11, 0.09, 1)
        _OutlineWidth ("Outline Width (m)", Range(0, 0.1)) = 0.03
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" "Queue" = "Geometry" }

        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        CBUFFER_START(UnityPerMaterial)
            half4 _BaseColor;
            half4 _ShadowTint;
            half _ShadowStep;
            half _ShadowSoftness;
            half _AmbientStrength;
            half4 _RimColor;
            half _RimPower;
            half4 _EmissionColor;
            half4 _OutlineColor;
            half _OutlineWidth;
        CBUFFER_END
        ENDHLSL

        Pass
        {
            Name "ToonForward"
            Tags { "LightMode" = "UniversalForward" }
            Cull Back
            ZWrite On

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
            #pragma multi_compile_fragment _ _SHADOWS_SOFT _SHADOWS_SOFT_LOW _SHADOWS_SOFT_MEDIUM _SHADOWS_SOFT_HIGH
            #pragma multi_compile_fog
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes { float4 positionOS : POSITION; float3 normalOS : NORMAL; float4 color : COLOR; };
            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float fogFactor : TEXCOORD2;
                half3 albedoMul : TEXCOORD3;   // vertex colour, linear
            };

            Varyings Vert(Attributes v)
            {
                Varyings o;
                VertexPositionInputs p = GetVertexPositionInputs(v.positionOS.xyz);
                o.positionCS = p.positionCS;
                o.positionWS = p.positionWS;
                o.normalWS = TransformObjectToWorldNormal(v.normalOS);
                o.fogFactor = ComputeFogFactor(p.positionCS.z);
                o.albedoMul = SRGBToLinear(saturate(v.color.rgb));   // FBX vertex colours arrive sRGB-encoded
                return o;
            }

            half4 Frag(Varyings i) : SV_Target
            {
                float3 n = normalize(i.normalWS);
                Light main = GetMainLight(TransformWorldToShadowCoord(i.positionWS));
                half ndl = dot(n, main.direction) * 0.5h + 0.5h;                       // half-Lambert
                half lit = smoothstep(_ShadowStep - _ShadowSoftness, _ShadowStep + _ShadowSoftness, ndl * main.shadowAttenuation);
                half3 tone = lerp(_ShadowTint.rgb, half3(1, 1, 1), lit);              // two tones: lit, or tinted shadow
                half3 albedo = _BaseColor.rgb * i.albedoMul;                            // material tint x painted vertex colour
                half3 col = albedo * tone * main.color + albedo * SampleSH(n) * _AmbientStrength;
                float3 view = normalize(GetWorldSpaceViewDir(i.positionWS));
                half rim = pow(1.0h - saturate(dot(n, view)), _RimPower) * _RimColor.a * lit;
                col += _RimColor.rgb * rim + _EmissionColor.rgb;
                col = MixFog(col, i.fogFactor);
                return half4(col, 1);
            }
            ENDHLSL
        }

        // The ink outline: back faces of a hull pushed out along the smoothed normal (UV3), drawn after the
        // forward pass (URP draws an SRPDefaultUnlit pass for the same renderer).
        Pass
        {
            Name "Outline"
            Tags { "LightMode" = "SRPDefaultUnlit" }
            Cull Front
            ZWrite On

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            #pragma multi_compile_fog

            struct Attributes { float4 positionOS : POSITION; float3 normalOS : NORMAL; float3 smoothOS : TEXCOORD3; };
            struct Varyings { float4 positionCS : SV_POSITION; float fogFactor : TEXCOORD0; };

            Varyings Vert(Attributes v)
            {
                Varyings o;
                // A missing UV channel reads as zero, so a zero-length vector means 'no smoothed normal': use the normal.
                float3 smooth = dot(v.smoothOS, v.smoothOS) < 1e-4 ? v.normalOS : v.smoothOS;
                float3 posOS = v.positionOS.xyz + normalize(smooth) * _OutlineWidth;
                o.positionCS = TransformObjectToHClip(posOS);
                o.fogFactor = ComputeFogFactor(o.positionCS.z);
                return o;
            }

            half4 Frag(Varyings i) : SV_Target
            {
                return half4(MixFog(_OutlineColor.rgb, i.fogFactor), 1);
            }
            ENDHLSL
        }

        Pass
        {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" }
            ZWrite On
            ZTest LEqual
            ColorMask 0
            Cull Back

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            #pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            float3 _LightDirection;
            float3 _LightPosition;
            struct Attributes { float4 positionOS : POSITION; float3 normalOS : NORMAL; };

            float4 Vert(Attributes v) : SV_POSITION
            {
                float3 posWS = TransformObjectToWorld(v.positionOS.xyz);
                float3 nWS = TransformObjectToWorldNormal(v.normalOS);
            #if _CASTING_PUNCTUAL_LIGHT_SHADOW
                float3 lightDir = normalize(_LightPosition - posWS);
            #else
                float3 lightDir = _LightDirection;
            #endif
                float4 pos = TransformWorldToHClip(ApplyShadowBias(posWS, nWS, lightDir));
            #if UNITY_REVERSED_Z
                pos.z = min(pos.z, UNITY_NEAR_CLIP_VALUE);
            #else
                pos.z = max(pos.z, UNITY_NEAR_CLIP_VALUE);
            #endif
                return pos;
            }

            half4 Frag() : SV_Target { return 0; }
            ENDHLSL
        }

        Pass
        {
            Name "DepthOnly"
            Tags { "LightMode" = "DepthOnly" }
            ZWrite On
            ColorMask R
            Cull Back

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            struct Attributes { float4 positionOS : POSITION; };
            float4 Vert(Attributes v) : SV_POSITION { return TransformObjectToHClip(v.positionOS.xyz); }
            half4 Frag() : SV_Target { return 0; }
            ENDHLSL
        }

        Pass
        {
            Name "DepthNormals"
            Tags { "LightMode" = "DepthNormals" }
            ZWrite On
            Cull Back

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            struct Attributes { float4 positionOS : POSITION; float3 normalOS : NORMAL; };
            struct Varyings { float4 positionCS : SV_POSITION; float3 normalWS : TEXCOORD0; };
            Varyings Vert(Attributes v)
            {
                Varyings o;
                o.positionCS = TransformObjectToHClip(v.positionOS.xyz);
                o.normalWS = TransformObjectToWorldNormal(v.normalOS);
                return o;
            }
            half4 Frag(Varyings i) : SV_Target { return half4(normalize(i.normalWS), 0); }
            ENDHLSL
        }
    }
    FallBack "Hidden/Universal Render Pipeline/FallbackError"
}
