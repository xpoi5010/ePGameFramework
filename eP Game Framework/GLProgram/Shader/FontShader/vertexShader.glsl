#version 420 core

layout (location = 0) in vec2 OriginPoint;
layout (location = 1) in vec2 TexturePoint;
layout (location = 2) in vec2 OffsetPoint;
layout (location = 3) in vec2 TextureSize;
layout (location = 4) in vec2 size;
layout (location = 5) in vec4 color;
layout (location = 6) in float scale;
out gsIn
{
    vec2 size;
    vec2 texCoords[4];
    vec4 color;
} outp;
uniform ivec2 clientSize;
uniform vec2 offset;

void main()
{
    float fx = TexturePoint.x / TextureSize.x;
    float fy = TexturePoint.y / TextureSize.y;
    float fw = size.x / TextureSize.x;
    float fh = size.y / TextureSize.y;
    vec2 texC[4] =
    {
        vec2(fx,fy),vec2(fx+fw,fy),
        vec2(fx+fw,fy+fh),vec2(fx,fy+fh)
    };
	vec2 newSize = size * scale;
    outp.texCoords = texC;
    fx = ((OriginPoint.x+OffsetPoint.x + offset.x)/float(clientSize.x)*2)-1;
    fy = 1 - ((OriginPoint.y+OffsetPoint.y + offset.y)/float(clientSize.y)*2);
    gl_Position = vec4(fx,fy,1.0f,1.0f);
    outp.size.x = newSize.x/clientSize.x*2;
    outp.size.y = newSize.y/clientSize.y*2;
    outp.color = color;
}
 
