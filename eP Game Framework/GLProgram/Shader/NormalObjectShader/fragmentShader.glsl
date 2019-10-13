//Normal Object Shader
/*
   eP Game Framework 1.0.5
   Normal Object Shader is usage for 2D Normal Object 
*/
#version 420
const float BlurSigma = 0.84352201f;
in gsOut
{
	vec2 originSize;
	vec4 objColor;
	vec2 texCoord;
	float haveTex;
	float texOffsetX;
	float texOffsetY;
	mat3 Kernel;
} outp;
uniform sampler2D textureContent;
out vec4 fragColor;

void applyKernel();

void main()
{
	if (outp.haveTex == 0)
		fragColor = outp.objColor;
	else
		applyKernel();
}

void applyKernel()
{
	float offsetX = (outp.texOffsetX) / outp.originSize.x;
	float offsetY = (outp.texOffsetY) / outp.originSize.y;
	vec2 offsets[9] = 
	{
		vec2(-offsetX,-offsetY),vec2(0 ,-offsetY),vec2(offsetX,-offsetY),
		vec2(-offsetX,0),vec2(0,0),vec2(offsetX,0),
		vec2(-offsetX,offsetY),vec2(0,offsetY),vec2(offsetX,offsetY)
	};
	mat3 Kernel = outp.Kernel;
	vec4 color = vec4(0.0f);
    int radius = 5;
    
    vec4 pixels[9];
	for(int x = 0; x < 3 ; x++)
	{
		for (int y = 0; y < 3; y++)
		{
            color += Kernel[y][x] * texture(textureContent, outp.texCoord.st + (offsets[x + (y * 3)]));
		}
	}
	fragColor = color * outp.objColor;
}

