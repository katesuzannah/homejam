// Upgrade NOTE: commented out 'float4x4 _CameraToWorld', a built-in variable
// Upgrade NOTE: replaced '_CameraToWorld' with 'unity_CameraToWorld'

// Upgrade NOTE: commented out 'float4x4 _CameraToWorld', a built-in variable

Shader "Hidden/ScanRingEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float3 worldDir : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
				float near = _ProjectionParams.y;
				float4 D = mul(unity_CameraToWorld, float4(o.uv.xy*2-1,near,1));
				D.xyz /= D.w;
				D.xyz -= _WorldSpaceCameraPos;
				float4 D0 = mul(unity_CameraToWorld,float4(0,0,near,1));
				D0.xyz /= D0.w;
				D0.xyz -= _WorldSpaceCameraPos;
				o.worldDir = D.xyz / length(D0.xyz);
                return o;
            }

          
			sampler2D _CameraDepthTexture;
			sampler2D _MainTex;
			

            fixed4 frag (v2f i) : SV_Target
            {
				float depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv)).r;
				
			float3 wpos = (i.worldDir*depth) + _WorldSpaceCameraPos;
				fixed4 col;
				if (length(wpos) >= 50 && length(wpos) <= 51) {
					col = float4(1, 0, 0, 1);
				}
				else {
					col = tex2D(_MainTex, i.uv);
				}
                
         
                return col;
            }
            ENDCG
        }
    }
}
