Shader "Custom/ColorSwapGPU"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_SwipMask("Swipe Mask", 2D) = "white"{}
		_SwipRange("Swip Range", Range(0,1)) = 0
		_CutOff("Cut Off", Range(-1,1)) = 0.5
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		[HDR]_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimRange("Rim Range", Range(1,20)) = 5
		_RimPower("Rim Power", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
		struct Input {
		float3 viewDir;
		float3 worldNormal;
		float2 uv_SwipMask;
		};

        half _Glossiness;
        half _Metallic;
		half _SwipRange;
		half _CutOff;
		sampler2D _SwipMask;
        fixed4 _Color;
		fixed4 _RimColor;
		half _RimRange;
		half _RimPower;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
			//UNITY_DEFINE_INSTANCED_PROP(half, _SwipRange)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
         
		
			float test = saturate(tex2D(_SwipMask, IN.uv_SwipMask).r-0.1) - _SwipRange >_CutOff ? 0 :1;
			fixed4 c = lerp(float4(1, 1, 1, 1), _Color,test);
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
			float3 rimLight =pow(1-saturate(dot(normalize(IN.viewDir), IN.worldNormal)), _RimRange)*_RimColor *_RimPower;
			o.Emission = rimLight;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			

        }
        ENDCG
    }
    FallBack "Diffuse"
}
