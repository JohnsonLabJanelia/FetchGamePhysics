Shader "Hidden/DepthShader"
{
   Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("_MainTex", 2D) = "white" {}
    }

    SubShader
    {
        CGINCLUDE
        inline float Linear01FromEyeToLinear01FromNear(float depth01)
        {
            float near = _ProjectionParams.y;
            float far = _ProjectionParams.z;
            return (depth01 - near/far) * (1 + near/far);
        }
        ENDCG
        
        // markers that specify that we don't need culling
        // or comparing/writing to the depth buffer
        Cull Off
        ZWrite Off
        ZTest Always

        Tags { "RenderType"="Opaque" }

        // Pass
        // {
        //     CGPROGRAM
        //     #pragma vertex vert
        //     #pragma fragment frag

        //     #include "UnityCG.cginc"

        //     // //the depth texture
        //     sampler2D _CameraDepthNormalsTexture;

        //     sampler2D _MainTex;

        //     float4x4 UNITY_MATRIX_IV;

        //     half4 _Color;

        //     struct appdata
        //     {
        //         float4 vertex : POSITION;
        //         float2 uv : TEXCOORD0;
        //     };

        //     struct v2f
        //     {
        //         float4 vertex : SV_POSITION;
        //         float depth : DEPTH;
        //         float2 uv : TEXCOORD0;
        //         UNITY_VERTEX_OUTPUT_STEREO
        //     };

        //     v2f vert(appdata input)
        //     {
        //         v2f output;

        //         // output.vertex = UnityObjectToClipPos(input.vertex);
        //         // output.depth = -UnityObjectToClipPos(input.vertex).z * _ProjectionParams.w;
        //         // output.uv = input.uv;

        //         UNITY_SETUP_INSTANCE_ID(input);
        //         UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
        //         output.vertex = UnityObjectToClipPos(input.vertex);
        //         output.uv.xyz = COMPUTE_VIEW_NORMAL;
        //         output.uv.w = COMPUTE_DEPTH_01;

        //         return output;
        //     }

        //     fixed4 frag(v2f input) : SV_Target
        //     {
        //         // float invert = 1 - input.depth;
        //         // return fixed4(invert, invert, invert, 1) * _Color;

        //         // //get depth from depth texture
        //         // float depth = tex2D(_CameraDepthNormalsTexture, input.uv).r;
        //         // //linear depth between camera and far clipping plane
        //         // depth = Linear01Depth(depth);

        //         // //depth as distance from camera in units
        //         // depth *= _ProjectionParams.z;

        //         // return depth;

        //         // // Test with white screen.
        //         // return float4 (0, 0, 0, 0);

        //         // fixed4 col = tex2D(_MainTex, input.uv);
                
        //         // float4 NormalDepth;

        //         // DecodeDepthNormal(tex2D(_CameraDepthNormalsTexture, input.uv), NormalDepth.w, NormalDepth.xyz);

        //         // // float3 WorldNormal = mul(UNITY_MATRIX_IV, float4(NormalDepth.xyz, 0)).xyz;
        //         // // col.rgb = WorldNormal;
                
        //         // col.rgb = NormalDepth.w;

        //         // // col.rgb = NormalDepth.xyz;

        //         // if (NormalDepth.w >= 1.0) col.rgb = 0;
        //         // return col;

        //         float linearZFromNear = Linear01FromEyeToLinear01FromNear(input.uv.w);
        //         float k = 0.25; // compression factor
        //         return pow(linearZFromNear, k);
        //     }
        //     ENDCG
        
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct v2f {
                float4 pos : SV_POSITION;
                float4 nz : TEXCOORD0;
                UNITY_VERTEX_OUTPUT_STEREO
            };
            v2f vert( appdata_base v ) {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.pos = UnityObjectToClipPos(v.vertex);
                o.nz.xyz = COMPUTE_VIEW_NORMAL;
                o.nz.w = COMPUTE_DEPTH_01;
                return o;
            }
            fixed4 frag(v2f i) : SV_Target {
                float linearZFromNear = Linear01FromEyeToLinear01FromNear(i.nz.w);
                float k = 0.25; // compression factor
                return pow(linearZFromNear, k);
            }
            ENDCG
        }
    }

    // SubShader {
    //     Tags { "RenderType"="Opaque" }
    //     Pass {
    //         CGPROGRAM

    //         #pragma vertex vert
    //         #pragma fragment frag
    //         #include "UnityCG.cginc"

    //         struct v2f {
    //             float4 pos : SV_POSITION;
    //             float2 depth : TEXCOORD0;
    //         };

    //         v2f vert (appdata_base v) {
    //             v2f o;
    //             o.pos = UnityObjectToClipPos(v.vertex);
    //             UNITY_TRANSFER_DEPTH(o.depth);
    //             return o;
    //         }

    //         half4 frag(v2f i) : SV_Target {
    //             UNITY_OUTPUT_DEPTH(i.depth);
    //         }
    //         ENDCG
    //     }
    // }

    Fallback Off
}
