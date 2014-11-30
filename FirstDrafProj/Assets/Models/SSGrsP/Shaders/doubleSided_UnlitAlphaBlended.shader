Shader "SIJO/doubleSided/Unlit_AlphaCutOffBlended" {
	Properties {
		_Color ("Main Color", Color) = (.5, .5, .5, .5)
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
		_Cutoff ("Base Alpha cutoff", Range (0,.9)) = .5
	}
	SubShader {
		// Set up basic lighting
		Material {
			Diffuse [unlit]
		}
		Lighting Off

		// Render both front and back facing polygons.
		Cull Off

		// first pass:
		//   render any pixels that are more than [_Cutoff] opaque
		Pass 
		{
			AlphaTest Greater [_Cutoff]
			SetTexture [_MainTex] 
			{
				constantColor [_Color]
				combine texture * constant, texture * constant
			}
		}

		// Second pass:
		//   render in the semitransparent details.
		Pass {
			// Dont write to the depth buffer
			ZWrite off
			// Don't write pixels we have already written.
			ZTest Less
			// Only render pixels less or equal to the value
			AlphaTest LEqual [_Cutoff]

			// Set up alpha blending
			Blend SrcAlpha OneMinusSrcAlpha

			SetTexture [_MainTex] 
			{
				constantColor [_Color]
				combine texture * constant, texture * constant
			}
		}
	}
} 