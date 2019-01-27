Shader "Hidden/Desaturation"
{
    Properties
    {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Mask("Mask Texture", 2D) = "white" {}
		_Intensity("Intensity", Range(-2,2)) = 1.0
		
	
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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
			sampler2D _MainTex;
			sampler2D _Mask;
			float _Intensity;

            fixed4 frag (v2f i) : SV_Target
            {
			   fixed4 original = tex2D(_MainTex, i.uv);
				fixed lum = saturate(Luminance(original.rgb));
				fixed maskAmount = saturate(tex2D(_Mask, i.uv).r-_Intensity);

				fixed4 output;
				output.rgb = lerp(original.rgb, fixed3(lum,lum,lum), maskAmount);
				output.a = original.a;
				return output;
            }
            ENDCG
        }
    }
}
