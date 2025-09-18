Shader "Unlit/Transparent Colored test"
{
	Properties
	{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "black" {}
	}

		SubShader
	{
		LOD 200

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"DisableBatching" = "True"
		}

//		1��Blend SrcAlpha OneMinusSrcAlpha ����ģʽ(͸���Ȼ��)
//����дͼƬ����
//2��Blend OneMinusDstColor One ������(soft Additive)
//����дͼƬ����
//3��Blend DstColor Zero ��Ƭ����(Multiply)���
//����дͼƬ����
//4��Blend DstColor SrcColor �������(2X Multiply)
//����дͼƬ����
//5�� �䰵
//
//BlendOp Min
//Blend One One
//1
//2
//����дͼƬ����
//6������
//
//BlendOp Max
//Blend One One
//1
//2
//����дͼƬ����
//7��Blend OneMinusDstColor One ��ɫ
//����дͼƬ����
//8��Blend One One ���Ա䵭
//����дͼƬ����

		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Offset -1, -1
//			Blend SrcAlpha OneMinusSrcAlpha  //����ģʽ(͸���Ȼ��)
		//          Blend SrcAlpha OneMinusSrcAlpha
//          Blend OneMinusDstColor One //������(soft Additive)
//          Blend DstColor Zero  //��Ƭ���� (Multiply)���
//          Blend DstColor SrcColor  //������� (2X Multiply)
          BlendOp Max
//          Blend One One    //���Ա䵭
          Blend OneMinusDstColor One

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;

			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			v2f o;

			v2f vert(appdata_t v)
			{
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				o.color = v.color;
				return o;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				return tex2D(_MainTex, IN.texcoord) * IN.color;
			}
			ENDCG
		}
	}

		SubShader
			{
				LOD 100

				Tags
				{
					"Queue" = "Transparent"
					"IgnoreProjector" = "True"
					"RenderType" = "Transparent"
					"DisableBatching" = "True"
				}

				Pass
				{
					Cull Off
					Lighting Off
					ZWrite Off
					Fog { Mode Off }
					Offset -1, -1
				//ColorMask RGB
//          Blend SrcAlpha OneMinusSrcAlpha
//          Blend OneMinusDstColor One
//          Blend DstColor Zero
//          Blend DstColor SrcColor
          BlendOp Max
//         Blend One One
          Blend OneMinusDstColor One


				ColorMaterial AmbientAndDiffuse

				SetTexture[_MainTex]
				{
					Combine Texture * Primary
				}
			}
			}
}
