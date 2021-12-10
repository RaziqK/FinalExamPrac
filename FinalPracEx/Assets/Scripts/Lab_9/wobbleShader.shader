Shader "Custom/wobbleShader"
{
    Properties{
        _Color("Tint", Color) = (0, 0, 0, 1)
        _MainTex("Texture", 2D) = "white" {}
        _Metallic("Metalness", Range(0, 1)) = 0
        _Emission("Emission", color) = (0, 0, 0)
        _Amplitude("Wave Size", Range(0, 1)) = 0.4
        _Frequency("Wave Frequency", Range(1, 8)) = 2
        _AnimationSpeed("Animation Speed", Range(0, 5)) = 1
    }
        SubShader{
            Tags{"RenderType" = "Opaque" "Queue" = "Geometry"}
            CGPROGRAM

            sampler2D _MainTex;
            fixed4 _Color;
            half _Metallic;
            half3 _Emission;

            float _Amplitude;
            float _Frequency;
            float _AnimationSpeed;

            struct Input {
                float2 uv_MainTex;
            };

            void vert(inout appdata_full data) {
                float4 modifiedPos = data.vertex;
                modifiedPos.y += sin(data.vertex.x * _Frequency + _Time.y * _AnimationSpeed) * _Amplitude;
                data.vertex = modifiedPos;
            }

            void surf(Input i, inout SurfaceOutputStandard o) {
                fixed4 col = tex2D(_MainTex, i.uv_MainTex);
                col *= _Color;
                o.Albedo = col.rgb;
                o.Metallic = _Metallic;
                o.Emission = _Emission;
            }

            #pragma surface surf Standard fullforwardshadows vertex:vert

            ENDCG
        } //end Subshader
            FallBack "Standard"
}
