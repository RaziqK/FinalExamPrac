Shader "Custom/basic_color"{
	Properties{
		_Color("Color", Color) = (0, 0, 0, 1)
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader{
		Pass{
			Tags{
				"RenderType" = "Opaque"
				"Queue" = "Geometry"
			}

			CGPROGRAM
			#include "unityCG.cginc"

			#pragma vertex vert
			#pragma fragment frag

			fixed4 _Color;
			sampler2D _MainTex;

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v) {
				v2f o; //create new v2f instance

				//populate position of vertex
				o.position = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o; //return v2f information
			}

			//fragment shader
			fixed4 frag(v2f i) : SV_TARGET{
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				return col;
			}

			ENDCG
		}
	}
}