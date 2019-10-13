using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace ePGameFramework.GLProgram
{
    public class GLProgram
    {
        public int BaseProgram = 0;

        public GLProgram()
        {

        }

        public void Init(string vs,string fs)
        {
            int vsi = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vsi, vs);
            GL.CompileShader(vsi);
            int status = 0;
            GL.GetShader(vsi, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                throw new Exception(GL.GetShaderInfoLog(vsi));
            }
            int fsi = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fsi, fs);
            GL.CompileShader(fsi);
            GL.GetShader(fsi, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                throw new Exception(GL.GetShaderInfoLog(fsi));
            }
            BaseProgram = GL.CreateProgram();
            GL.AttachShader(BaseProgram, vsi);
            GL.AttachShader(BaseProgram, fsi);
            GL.LinkProgram(BaseProgram);
            GL.GetProgram(BaseProgram, GetProgramParameterName.LinkStatus, out status);
            if(status == 0)
            {
                throw new Exception(GL.GetProgramInfoLog(BaseProgram));
            }
            GL.DeleteShader(vsi);
            GL.DeleteShader(fsi);
        }

        public void Init(string vs, string gs,string fs)
        {
            int vsi = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vsi, vs);
            GL.CompileShader(vsi);
            int status = 0;
            GL.GetShader(vsi, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                throw new Exception(GL.GetShaderInfoLog(vsi));
            }
            int gsi = GL.CreateShader(ShaderType.GeometryShader);
            GL.ShaderSource(gsi, gs);
            GL.CompileShader(gsi);
            GL.GetShader(gsi, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                throw new Exception(GL.GetShaderInfoLog(gsi));
            }
            int fsi = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fsi, fs);
            GL.CompileShader(fsi);
            GL.GetShader(fsi, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                throw new Exception(GL.GetShaderInfoLog(fsi));
            }
            BaseProgram = GL.CreateProgram();
            GL.AttachShader(BaseProgram, vsi);
            GL.AttachShader(BaseProgram, gsi);
            GL.AttachShader(BaseProgram, fsi);
            GL.LinkProgram(BaseProgram);
            GL.GetProgram(BaseProgram, GetProgramParameterName.LinkStatus, out status);
            if (status == 0)
            {
                throw new Exception(GL.GetProgramInfoLog(BaseProgram));
            }
            GL.DeleteShader(vsi);
            GL.DeleteShader(gsi);
            GL.DeleteShader(fsi);
        }

        public void UseProgram()
        {
            GL.UseProgram(BaseProgram);
        }

        public void SetInt(string VarName, int value)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform1(Location, value);
        }

        public void SetDouble(string VarName, double value)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform1(Location, value);
        }

        public void SetFloat(string VarName, float value)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform1(Location, value);
        }

        public void SetUint(string VarName, uint value)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform1(Location,value);
        }



        public void SetVec2(string VarName, Vector2 value)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform2(Location, value);
        }

        public void SetIVec2(string VarName, int X,int Y)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform2(Location, X,Y);
        }

        public void SetVec3(string VarName, Vector3 value)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform3(Location, value);
        }

        public void SetVec4(string VarName, Vector4 value)
        {
            int Location = GL.GetUniformLocation(BaseProgram, VarName);
            GL.Uniform4(Location, value);
        }
    }
}
