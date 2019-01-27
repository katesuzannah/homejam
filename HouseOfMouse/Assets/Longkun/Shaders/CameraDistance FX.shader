// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DepthRingPass" {

Properties {
   _MainTex ("", 2D) = "white" {} //this texture will have the rendered image before post-processing
   _RingWidth("ring width", Float) = 0.01
   _Ajust("_Ajust", float) = 1
  
}

SubShader {
Tags { "RenderType"="Opaque" }
Pass{
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

sampler2D _CameraDepthTexture;
float _Ajust;
float4 _StartPoint;
float _Distance;

float4 _Vector_X;
float4 _Vector_Y;
float4 _Screem_Center;





struct v2f {
   float4 ClipPos : SV_POSITION;
   float4 scrPos:TEXCOORD1;
};

struct VertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 ray : TEXCOORD1;

			};
//Our Vertex Shader
v2f vert (VertIn v){
   v2f o;
   o.ClipPos = UnityObjectToClipPos(v.vertex);
   o.scrPos = ComputeScreenPos(o.ClipPos);
   o.scrPos.y = o.scrPos.y;
  
   return o;
}

sampler2D _MainTex; //Reference in Pass is necessary to let us use this variable in shaders

//Our Fragment Shader
half4 frag (v2f i) : COLOR{

   //extract the value of depth for each screen position from _CameraDepthExture
   float depthValue = Linear01Depth (tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r);
   fixed4 orgColor = tex2Dproj(_MainTex, i.scrPos);

   float3 wsPos =  (_Vector_X*i.scrPos.x + _Vector_Y*i.scrPos.y+_Screem_Center)*depthValue + _WorldSpaceCameraPos; //See C# camera to explenation
   float dist =distance(wsPos, _StartPoint);

   fixed4 Final;

   if((dist <  _Distance && dist >_Distance-_Ajust)||depthValue==1 ){
   		Final = orgColor;
   }else{
   		
   		float bw = (orgColor.x+orgColor.y+orgColor.z)/3;
   		Final =float4(bw,bw,bw,0);
   }

  return Final;
    
}
ENDCG
}
}
FallBack "Diffuse"
}
