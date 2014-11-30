Shader "SIJO/oneSided/Unlit_withColorOverride" 
{
    Properties 
    {
        _Color ("Main Color", COLOR) = (1,1,1,1)
        _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
    }
    SubShader 
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        
        
        
        // Set up alpha blending
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass 
        {
        	ZWrite On
            Material 
            {
                //Diffuse [unlit]
                //Ambient [_Color]
            }
            Lighting On
            Cull Back
            SetTexture [_MainTex] 
			{
				constantColor [_Color]
				combine texture * constant, texture * constant
			}
        }
    }
} 