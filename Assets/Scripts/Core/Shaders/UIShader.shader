Shader "Custom/UIShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _SpeedX ("Scroll Speed X", float) = 1
        _SpeedY ("Scroll Speed Y", float) = 1

        [MaterialToggle] _UseGlow ("Use Glow", Float ) = 0
        _GlowColor ("Tint Color", Color) = (1,1,1,1)
        _GlowIntencity("Intencity", Range(0,10)) = 1
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Overlay"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
        }
        Stencil
        {
            Ref 1
            Comp Always
            Pass Replace
            //ZWrite On
        }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                float4 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _GlowColor;
            float _GlowIntencity;
            float _UseGlow;
            float _SpeedX;
            float _SpeedY;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color * _Color;
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.texcoord.x += _SpeedX * _Time.x;
                o.texcoord.y += _SpeedY * _Time.y;
                //o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 texcol = tex2D(_MainTex, i.texcoord) * i.color;

                if(_UseGlow > 0.5)
                {
                    float distance = 1.0 - length(i.texcoord - 0.5);
                    float glow = _GlowIntencity * distance * 2.0;
                    half4 glowColor = half4(_GlowColor.rgb, glow);
                    texcol += glowColor * _GlowIntencity;
                }
                return texcol;
            }
            ENDCG
        }
    }
    FallBack "UI/Default"
}
