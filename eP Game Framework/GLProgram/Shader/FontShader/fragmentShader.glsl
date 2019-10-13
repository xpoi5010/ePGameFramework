#version 400 core

in vec4 color;
in vec2 texCoord;
out vec4 outColor;
uniform sampler2D textureSampler;

void main()
{
    outColor = color * texture(textureSampler,texCoord);
}
