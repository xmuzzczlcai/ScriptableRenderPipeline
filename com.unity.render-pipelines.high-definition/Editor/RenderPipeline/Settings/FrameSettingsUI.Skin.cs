using UnityEditor.Rendering;
using UnityEngine;

namespace UnityEditor.Experimental.Rendering.HDPipeline
{
    partial class FrameSettingsUI
    {
        const string renderingPassesHeaderContent = "Rendering Passes";
        const string renderingSettingsHeaderContent = "Rendering";
        const string xrSettingsHeaderContent = "XR Settings";
        const string lightSettingsHeaderContent = "Lighting";
        const string asyncComputeSettingsHeaderContent = "Async Compute";
        
        static readonly GUIContent transparentPrepassContent = CoreEditorUtils.GetContent("Transparent Prepass|When enabled, Cameras using these Frame Settings process a transparent prepass.");
        static readonly GUIContent transparentPostpassContent = CoreEditorUtils.GetContent("Transparent Postpass|When enabled, Cameras using these Frame Settings process a transparent postpass.");
        static readonly GUIContent motionVectorContent = CoreEditorUtils.GetContent("Motion Vectors|When enabled, Cameras using these Frame Settings process a motion vector pass.");
        static readonly GUIContent objectMotionVectorsContent = CoreEditorUtils.GetContent("Object Motion Vectors||When enabled, Cameras using these Frame Settings process a object motion vector pass.");
        static readonly GUIContent decalsContent = CoreEditorUtils.GetContent("Decals|When enabled, Cameras using these Frame Settings process a decal render pass.");
        static readonly GUIContent roughRefractionContent = CoreEditorUtils.GetContent("Rough Refraction|When enabled, Cameras using these Frame Settings process a rough refraction render pass.");
        static readonly GUIContent distortionContent = CoreEditorUtils.GetContent("Distortion|When enabled, Cameras using these Frame Settings process a distortion render pass.");
        static readonly GUIContent postprocessContent = CoreEditorUtils.GetContent("Postprocess|When enabled, Cameras using these Frame Settings process a postprocessing render pass.");
        static readonly GUIContent litShaderModeContent = CoreEditorUtils.GetContent("Lit Shader Mode|Specifies the Lit Shader Mode Cameras using these Frame Settings use to render the Scene.");
        static readonly GUIContent depthPrepassWithDeferredRenderingContent = CoreEditorUtils.GetContent("Depth Prepass With Deferred Rendering");
        static readonly GUIContent opaqueObjectsContent = CoreEditorUtils.GetContent("Opaque Objects");
        static readonly GUIContent transparentObjectsContent = CoreEditorUtils.GetContent("Transparent Objects");
        static readonly GUIContent realtimePlanarReflectionContent = CoreEditorUtils.GetContent("Enable Realtime Planar Reflection"); 
        static readonly GUIContent msaaContent = CoreEditorUtils.GetContent("MSAA|When enabled, Cameras using these Frame Settings calculate MSAA when they render the Scene.");
        static readonly GUIContent shadowContent = CoreEditorUtils.GetContent("Shadow");
        static readonly GUIContent contactShadowContent = CoreEditorUtils.GetContent("Contact Shadows");
        static readonly GUIContent shadowMaskContent = CoreEditorUtils.GetContent("Shadow Masks");
        static readonly GUIContent ssrContent = CoreEditorUtils.GetContent("SSR");
        static readonly GUIContent ssaoContent = CoreEditorUtils.GetContent("SSAO");
        static readonly GUIContent subsurfaceScatteringContent = CoreEditorUtils.GetContent("Subsurface Scattering");
        static readonly GUIContent transmissionContent = CoreEditorUtils.GetContent("Transmission");
        static readonly GUIContent atmosphericScatteringContent = CoreEditorUtils.GetContent("Atmospheric Scattering");
        static readonly GUIContent volumetricContent = CoreEditorUtils.GetContent("Volumetrics");
        static readonly GUIContent reprojectionForVolumetricsContent = CoreEditorUtils.GetContent("Reprojection For Volumetrics");
        static readonly GUIContent lightLayerContent = CoreEditorUtils.GetContent("LightLayers");

        // Async compute
        static readonly GUIContent asyncComputeContent = CoreEditorUtils.GetContent("Async Compute|This will have an effect only if target platform supports async compute.");
        static readonly GUIContent lightListAsyncContent = CoreEditorUtils.GetContent("Build Light List in Async");
        static readonly GUIContent SSRAsyncContent = CoreEditorUtils.GetContent("SSR in Async");
        static readonly GUIContent SSAOAsyncContent = CoreEditorUtils.GetContent("SSAO in Async");
        static readonly GUIContent contactShadowsAsyncContent = CoreEditorUtils.GetContent("Contact Shadows in Async");
        static readonly GUIContent volumeVoxelizationAsyncContent = CoreEditorUtils.GetContent("Volumetrics Voxelization in Async");


        static readonly GUIContent frameSettingsHeaderContent = CoreEditorUtils.GetContent("Frame Settings Overrides|Default FrameSettings are defined in your Unity Project's HDRP Asset.");
    }
}
