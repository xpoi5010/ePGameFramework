#version 420 core

layout (points) in;
layout (triangle_strip, max_vertices = 4) out;

in gsIn
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
} inpu[];

out gsOut
{
    vec2 originSize;
    vec4 objColor;
    vec2 texCoord;
    float haveTex;
	float texOffsetX;
	float texOffsetY;
    mat3 Kernel;
} outp;

uniform ivec2 clientSize;

void process();

void rotate(float angle,float angleunit,in out vec2[4] points);

void main()
{
	process();

}

void process()
{
	vec4 pos = gl_in[0].gl_Position;
	outp.objColor = inpu[0].color;
	outp.haveTex = inpu[0].HaveTexture;
	int posit = inpu[0].PanelPosition;
	int xp = posit & 3;
	int yp = posit >> 2;
    outp.originSize = inpu[0].size * clientSize / 2;
    outp.texOffsetX = inpu[0].texCoords[1].x - inpu[0].texCoords[0].x;
    outp.texOffsetY = inpu[0].texCoords[3].y - inpu[0].texCoords[0].y;
    outp.Kernel = inpu[0].Kernel;
	float x1 =
		xp == 0 ? pos.x - 1f :
		xp == 1 ? -pos.x :
		xp == 2 ? pos.x :
		xp == 3 ? 1f - pos.x : 0;

	float y1 =
		yp == 0 ? 1f - pos.y :
		yp == 1 ? pos.y :
		yp == 2 ? -pos.y :
		yp == 3 ? pos.y - 1f : 0;


	int objpos = inpu[0].ObjectPosition;
	xp = objpos & 3;
	yp = objpos >> 2;
	x1 -=
		xp == 0 ? 0 :
		xp == 1 ? inpu[0].size.x * 0.5f :
		xp == 2 ? inpu[0].size.x : 0;
	y1 +=
		yp == 0 ? 0 :
		yp == 1 ? inpu[0].size.y * 0.5f :
		yp == 2 ? inpu[0].size.y : 0;
	float x2 = x1 + inpu[0].size.x;
	float y2 = y1 - inpu[0].size.y;
	vec2 points[4] = 
	{
	    vec2(x1,y1),vec2(x2,y1),
		vec2(x1,y2),vec2(x2,y2)
	};
	rotate(inpu[0].Angle,inpu[0].AngleUnit,points);
    outp.texCoord = inpu[0].texCoords[0];
	gl_Position = vec4(points[0], 1.0f, 1.0f);
	EmitVertex();
	outp.texCoord = inpu[0].texCoords[1];
	gl_Position = vec4(points[1], 1.0f, 1.0f);
	EmitVertex();
	outp.texCoord = inpu[0].texCoords[3];
	gl_Position = vec4(points[2], 1.0f, 1.0f);
	EmitVertex();
	outp.texCoord = inpu[0].texCoords[2];
	gl_Position = vec4(points[3], 1.0f, 1.0f);
	EmitVertex();
	EndPrimitive();
}

void rotate(float angle,float angleunit,in out vec2[4] points)
{
    int objpos = inpu[0].ObjectPosition;
	int xp = objpos & 3;
	int yp = objpos >> 2;

    const float arrX[3]=
	{
	    0.0f , 0.5f, 1.0f
	};

	const float arrY[3]=
	{
	    0.0f , 0.5f, 1.0f
	};
	float angleRad = angleunit==0 ? angle/180*3.14159265359f : angle;
	vec2 centerPoint = vec2(
	                   (points[0].x + (points[1].x - points[0].x)* arrX[xp])*clientSize.x,
					   (points[0].y + (points[2].y - points[0].y)* arrY[yp])*clientSize.y);
	for(int i =0;i<4;i++)
	{
	    vec2 fixedPoint = points[i]*clientSize - centerPoint;
		mat2 rotateMatrix = mat2(
		    cos(angleRad),-sin(angleRad),
			sin(angleRad),cos(angleRad)
		);
		points[i] = (rotateMatrix*fixedPoint + centerPoint)/clientSize;
	}

    
}

