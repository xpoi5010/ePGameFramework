//Normal Object Shader
/*
   eP Game Framework 1.0.3
   Normal Object Shader is usage for 2D Normal Object
*/
#version 430 core

layout (location = 0) in vec2 point;
layout (location = 1) in vec2 size;
layout (location = 2) in vec4 color;
layout (location = 3) in float HaveTexture;
layout (location = 4) in vec2 TexCoord[4];
layout (location = 8) in float PanelPosition;
layout (location = 9) in float ObjectPosition;
layout (location = 10) in float Angle;
layout (location = 11) in float AngleUnit;
layout (location = 12) in mat3 Kernel;

uniform ivec2 clientSize;

out gsIn
{
	vec4 color;
	vec2 texCoords[4];
	float HaveTexture;
	vec2 size;
	int PanelPosition;
	int ObjectPosition;
	float Angle;
	float AngleUnit;
	mat3 Kernel;
} gsInput;

void main()
{
	vec2 pos;
	pos.x = (point.x / float(clientSize.x)) * 2;
	pos.y = (point.y / float(clientSize.y)) * 2;
	vec2 resize;
	resize.x = (size.x / float(clientSize.x)) * 2;
	resize.y= (size.y / float(clientSize.y)) * 2;
    gl_Position = vec4(pos,1.0f,1.0f);
	gsInput.color = color;
	gsInput.texCoords = TexCoord;
	gsInput.HaveTexture = HaveTexture;
	gsInput.size = resize;
	gsInput.PanelPosition = int(PanelPosition);
	gsInput.ObjectPosition = int(ObjectPosition);
	gsInput.Angle = Angle;
	gsInput.AngleUnit = AngleUnit;
	gsInput.Kernel = Kernel;
}

