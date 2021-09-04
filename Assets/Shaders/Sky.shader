﻿// (c) 2020 Tongzhou Yu

Shader "Custom/Sky"
{
    Properties
    {
        [Enum(CompareFunction)] stest("Stencil Comp", Int) = 3
        //[Enum(Equal,3,NotEqual,6)] stest("Stencil Test",int)= 3
		_MainTex("Texture", 2D) = "white" {}
        [Enum(UV0,0,UV1,1)] _UVSec("UV Set for secondary textures", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "PerformanceChecks" = "False" }
        LOD 100
		Cull Front


        Pass
        {
			Stencil{
			Ref 1
			Comp[stest]
		}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
