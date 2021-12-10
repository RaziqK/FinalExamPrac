Shader "Custom/single_color"{

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

			struct appdata {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 position : SV_POSITION;
			};

			v2f vert(appdata v) {
				v2f o; //create new v2f instance

				//populate position of vertex
				o.position = UnityObjectToClipPos(v.vertex);
				return o; //return v2f information
			}

			//fragment shader
			fixed4 frag(v2f i) : SV_TARGET{
				return fixed4(0, 0, 1, 1);
			}

			ENDCG
		}
	}
}