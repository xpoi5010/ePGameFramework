using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using ePGameFramework.Texture;

namespace ePGameFramework.GLProgram
{
    public static class FontProgram
    {
        static GLProgram baseProgram;

        public static void Active()
        {
            string vs = Resource.ResourceReader.ReadString("ePGameFramework.GLProgram.Shader.FontShader.vertexShader.glsl");
            string gs = Resource.ResourceReader.ReadString("ePGameFramework.GLProgram.Shader.FontShader.geometryShader.glsl");
            string fs = Resource.ResourceReader.ReadString("ePGameFramework.GLProgram.Shader.FontShader.fragmentShader.glsl");
            baseProgram = new GLProgram();
            baseProgram.Init(vs, gs, fs);
        }

        public static void UseProgram()
        {
            baseProgram.UseProgram();
        }

        public static void SetClientSize(int Width,int Height)
        {
            baseProgram.UseProgram();
            baseProgram.SetIVec2("clientSize", Width, Height);
        }

        public static void SetOffset(float X,float Y)
        {
            baseProgram.UseProgram();
            baseProgram.SetVec2("offset",new Vector2( X, Y));
        }
    }
}
