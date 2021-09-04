Shader "Portal/PortalDoor"
{
    Properties
    {
        
    }
    SubShader
    {
        ColorMask 0
        ZWrite Off
        Cull off //test
        
        Stencil {
            Ref 1
            //Comp always //test
            Pass replace
        }
        
        Pass 
       {

       }
    }
}
