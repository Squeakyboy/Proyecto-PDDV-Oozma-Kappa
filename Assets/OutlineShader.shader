Shader "Custom/OutlineV2" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1, 0.5, 0, 1)
        _OutlineWidth ("Outline Width", Range(0, 0.1)) = 0.03
    }

    SubShader {
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }

        // --- PRIMER PASO: Render del reborde ---
        Pass {
            Name "OUTLINE"
            Cull Front // Renderiza las caras traseras

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
            };

            float _OutlineWidth;
            float4 _OutlineColor;

            v2f vert(appdata v) {
                v2f o;
                
                // Escala el vértice en el espacio de la vista (para crear silueta)
                float3 normal = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal); // Normal en view-space
                normal.z = -0.5; // Aplanar la normal para evitar "inflado"
                normal = normalize(normal) * _OutlineWidth;
                
                float3 scaledVertex = v.vertex.xyz + normal;
                o.pos = UnityObjectToClipPos(scaledVertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                return _OutlineColor;
            }
            ENDCG
        }

        // --- SEGUNDO PASO: Render del modelo normal ---
        Pass {
            Name "MAIN"
            Cull Back // Renderiza las caras frontales

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}