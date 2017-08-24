Shader "testShader/Outline"
{
	Properties
	{
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(1.0, 5.0)) = 1.03
	}

	CGINCLUDE
	#include "UnityCG.cginc"

	struct appdata
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f
	{
		float4 pos : POSITION;
		float3 normal : NORMAL;
	};

	float _OutlineWidth;
	float4 _OutlineColor;

	v2f vert(appdata input)
	{
		input.vertex.xyz *= _OutlineWidth; // Multiply each vertex by the width on the outline direction
		
		v2f output;
		UNITY_INITIALIZE_OUTPUT(v2f, output);
		output.pos = UnityObjectToClipPos(input.vertex);
		return output;
	}

	ENDCG


	SubShader
	{
		Tags { "Queue" = "Transparent" }

		//Render the outline
		Pass {
			ZWrite Off // turn off the z buffer so that we can write over it

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f index) : COLOR {
				return _OutlineColor;
			}
			ENDCG
		}

		//Render the object on top of the outline
		Pass {
			ZWrite On

			Material
			{
				Diffuse[_Color]
				Ambient[_Color]
			}

			Lighting On

			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}

			SetTexture[_MainTex]
			{
				Combine previous * primary DOUBLE
			}
		}
	}
}
