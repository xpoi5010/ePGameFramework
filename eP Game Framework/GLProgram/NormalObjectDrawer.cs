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
    public class NormalObjectDrawer
    {
        
        static GLProgram baseProgram;

        static int VAO = 0;

        static int VBO = 0;

        const int ArraySize = 30;

        public static int ClientWidth { get; set; }

        public static int ClientHeight { get; set; }

        public static void Initizate()
        {
            string vs = Resource.ResourceReader.ReadString("ePGameFramework.GLProgram.Shader.NormalObjectShader.vertexShader.glsl");
            string gs = Resource.ResourceReader.ReadString("ePGameFramework.GLProgram.Shader.NormalObjectShader.geometryShader.glsl");
            string fs = Resource.ResourceReader.ReadString("ePGameFramework.GLProgram.Shader.NormalObjectShader.fragmentShader.glsl");
            baseProgram = new GLProgram();
            baseProgram.Init(vs, gs,fs);
            CreateVertexArray();
        }

        private static void CreateVertexArray()
        {
            GL.GenVertexArrays(1, out VAO);
            GL.GenBuffers(1, out VBO);
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 2 * sizeof(float));
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(2, 4, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 4 * sizeof(float));
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(3, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 8 * sizeof(float));
            GL.EnableVertexAttribArray(3);
            GL.VertexAttribPointer(4, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 9 * sizeof(float));
            GL.EnableVertexAttribArray(4);
            GL.VertexAttribPointer(5, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 11 * sizeof(float));
            GL.EnableVertexAttribArray(5);
            GL.VertexAttribPointer(6, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 13 * sizeof(float));
            GL.EnableVertexAttribArray(6);
            GL.VertexAttribPointer(7, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 15 * sizeof(float));
            GL.EnableVertexAttribArray(7);
            GL.VertexAttribPointer(8, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 17 * sizeof(float));
            GL.EnableVertexAttribArray(8);
            GL.VertexAttribPointer(9, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 18 * sizeof(float));
            GL.EnableVertexAttribArray(9);
            GL.VertexAttribPointer(10, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 19 * sizeof(float));
            GL.EnableVertexAttribArray(10);
            GL.VertexAttribPointer(11, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 20 * sizeof(float));
            GL.EnableVertexAttribArray(11);
            GL.VertexAttribPointer(12, 3, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 21 * sizeof(float));
            GL.EnableVertexAttribArray(12);
            GL.VertexAttribPointer(13, 3, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 24 * sizeof(float));
            GL.EnableVertexAttribArray(13);
            GL.VertexAttribPointer(14, 3, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 27 * sizeof(float));
            GL.EnableVertexAttribArray(14);
            /*
            GL.VertexAttribPointer(15, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 24 * sizeof(float));
            GL.EnableVertexAttribArray(15);
            GL.VertexAttribPointer(16, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 25 * sizeof(float));
            GL.EnableVertexAttribArray(16);
            GL.VertexAttribPointer(17, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 26 * sizeof(float));
            GL.EnableVertexAttribArray(17);
            GL.VertexAttribPointer(18, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 27 * sizeof(float));
            GL.EnableVertexAttribArray(18);
            GL.VertexAttribPointer(19, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 28 * sizeof(float));
            GL.EnableVertexAttribArray(19);
            GL.VertexAttribPointer(20, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 29 * sizeof(float));
            GL.EnableVertexAttribArray(20);
            */

        }

        /*4*/

        static float[] lastArr = new float[ArraySize*4];

        public static void DrawArray(float[] arr,Texture2D texture)
        {
            texture?.BindTexture();
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, arr.Length * sizeof(float), arr, BufferUsageHint.StaticDraw);
            baseProgram.UseProgram();
            GL.DrawArrays(PrimitiveType.Points, 0, 1);
        }

        public static void DrawArray(float[] arr, Texture2D[] textures)
        {
            if (!(textures is null))
            {
                GL.BindTextures(0, textures.Length, Array.ConvertAll(textures, x => x.textureID));
            }
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, arr.Length * sizeof(float), arr, BufferUsageHint.StaticDraw);
            baseProgram.UseProgram();
            GL.DrawArrays(PrimitiveType.Points, 0, 1);
        }

        public static void SetClientSize(int Width,int height)
        {
            baseProgram.UseProgram();
            baseProgram.SetIVec2("clientSize", Width, height);
            ClientWidth = Width;
            ClientHeight = height;
        }

        public static string GetProgramInfoLog()
        {
            return GL.GetProgramInfoLog(baseProgram.BaseProgram);
        } 
    }

    public class NormalObjectVertexArray
    {
        public int VAO;
    }
}
