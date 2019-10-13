#version 420 core

layout (points) in;
layout (triangle_strip, max_vertices = 4) out;

in gsIn
{
    vec2 size;
    vec2 texCoords[4];
    vec4 color;
} inpu[];

out vec4 color;

out vec2 texCoord;

void main()
{
    vec4 pos = gl_in[0].gl_Position;
     vec4 position = pos;
     color = inpu[0].color;
     texCoord = inpu[0].texCoords[0];
     gl_Position = position;
    EmitVertex();   
    texCoord = inpu[0].texCoords[1];
    gl_Position = position + vec4( inpu[0].size.x, 0, 0.0, 0.0);
    EmitVertex();
    texCoord = inpu[0].texCoords[3];
    gl_Position = position + vec4( 0,  -inpu[0].size.y, 0.0, 0.0);
    EmitVertex();
    texCoord = inpu[0].texCoords[2];
    gl_Position = position + vec4( inpu[0].size.x,  -inpu[0].size.y, 0.0, 0.0);
    EmitVertex();
    EndPrimitive();
}


