Shader "Tutorial/Basic"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Color("Main Color", Color) = (0.5, 1, 1, 1)
	}
		SubShader
	{
		Tags{ 
			"Queue" = "Transparent" 
			"IgnoreProjector" = "True" 
			"RenderType" = "Transparent" 
		}
		Cull Off
		ZWrite Off
		ZTest Always
		Fog { Mode Off }
		Lighting Off

		Pass
		{
			
			SetTexture[_MainTex] {
				ConstantColor [_Color]
				Combine texture * constant
			}


			//Material
			//{
				//Diffuse[_Color]
			//}
			
		}
	}
}
