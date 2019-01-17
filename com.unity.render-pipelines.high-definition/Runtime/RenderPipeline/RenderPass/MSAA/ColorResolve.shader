Shader "Hidden/HDRP/ColorResolve"
{
    HLSLINCLUDE
        #pragma target 4.5
        #pragma only_renderers d3d11 ps4 xboxone vulkan metal switch
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #pragma enable_d3d11_debug_symbols

        Texture2DMSArray<float4> _ColorTextureMS;

        struct Attributes
        {
            uint vertexID : SV_VertexID;
        };

        struct Varyings
        {
            float4 positionCS : SV_POSITION;
            float2 texcoord   : TEXCOORD0;
        };

        Varyings Vert(Attributes input)
        {
            Varyings output;
            output.positionCS = GetFullScreenTriangleVertexPosition(input.vertexID);
            output.texcoord   = GetFullScreenTriangleTexCoord(input.vertexID) * _ScreenSize.xy;
            return output;
        }

        float4 SampleColorTexture(float2 pixelCoords, uint sampleIndex)
        {
            return LOAD_TEXTURE2D_ARRAY_MSAA(_ColorTextureMS, pixelCoords, unity_StereoEyeIndex, sampleIndex);
        }

        float4 Frag1X(Varyings input) : SV_Target
        {
            int2 pixelCoords = int2(TexCoordStereoOffset(input.texcoord));
            return SampleColorTexture(pixelCoords, 0);
        }

        float4 Frag2X(Varyings input) : SV_Target
        {
            int2 pixelCoords = int2(TexCoordStereoOffset(input.texcoord));
            return FastTonemapInvert((FastTonemap(SampleColorTexture(pixelCoords, 0)) + FastTonemap(SampleColorTexture(pixelCoords, 1))) * 0.5f);
        }

        float4 Frag4X(Varyings input) : SV_Target
        {
            int2 pixelCoords = int2(TexCoordStereoOffset(input.texcoord));
            return FastTonemapInvert((FastTonemap(SampleColorTexture(pixelCoords, 0)) + FastTonemap(SampleColorTexture(pixelCoords, 1))
                            + FastTonemap(SampleColorTexture(pixelCoords, 2)) + FastTonemap(SampleColorTexture(pixelCoords, 3))) * 0.25f);
        }

        float4 Frag8X(Varyings input) : SV_Target
        {
            int2 pixelCoords = int2(TexCoordStereoOffset(input.texcoord));
            return FastTonemapInvert((FastTonemap(SampleColorTexture(pixelCoords, 0)) + FastTonemap(SampleColorTexture(pixelCoords, 1))
                            + FastTonemap(SampleColorTexture(pixelCoords, 2)) + FastTonemap(SampleColorTexture(pixelCoords, 3))
                            + FastTonemap(SampleColorTexture(pixelCoords, 4)) + FastTonemap(SampleColorTexture(pixelCoords, 5))
                            + FastTonemap(SampleColorTexture(pixelCoords, 6)) + FastTonemap(SampleColorTexture(pixelCoords, 7))) * 0.125f);
        }
    ENDHLSL
    SubShader
    {
        Tags{ "RenderPipeline" = "HDRenderPipeline" }

        // 0: MSAA 1x
        Pass
        {
            ZWrite Off ZTest Always Blend Off Cull Off

            HLSLPROGRAM
                #pragma vertex Vert
                #pragma fragment Frag1X
            ENDHLSL
        }

        // 1: MSAA 2x
        Pass
        {
            ZWrite Off ZTest Always Blend Off Cull Off

            HLSLPROGRAM
                #pragma vertex Vert
                #pragma fragment Frag2X
            ENDHLSL
        }

        // 2: MSAA 4X
        Pass
        {
            ZWrite Off ZTest Always Blend Off Cull Off

            HLSLPROGRAM
                #pragma vertex Vert
                #pragma fragment Frag4X
            ENDHLSL
        }

        // 3: MSAA 8X
        Pass
        {
            ZWrite Off ZTest Always Blend Off Cull Off

            HLSLPROGRAM
                #pragma vertex Vert
                #pragma fragment Frag8X
            ENDHLSL
        }
    }
    Fallback Off
}
