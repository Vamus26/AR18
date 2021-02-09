Shader "Unlit/testshader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		Pass
		{ 
			Alphatest Greater 1 
			SetTexture[_MainTex] 
		}
		Pass
		{
			Blend DstColor Zero Tags {"Lightmode" = "ForwardBase"}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
			#include "UnityCG.cginc"
			#include "AutoLight.cginc"

			struct v2f
			{
				LIGHTING_COORDS(0,1)
				float4 pos : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}
			
			fixed4 frag (v2f i) : COLOR
			{
				float atten = LIGHT_ATTENUATION(i);
				return atten;
			}
			ENDCG
		}
	}Fallback "Diffuse"
}
