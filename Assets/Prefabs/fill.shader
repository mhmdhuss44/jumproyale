Shader "Custom/Fill"
{
    Properties
    {
        _InsideColor("Inside Color", Color) = (1, 0, 0, 0.5)
    }

        SubShader
    {
        Tags { "RenderType" = "Transparent" }
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            fixed4 _InsideColor;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = _InsideColor;
                col.a *= 0.5; // Adjust transparency here
                return col;
            }
            ENDCG
        }
    }

        FallBack "Diffuse"
}
