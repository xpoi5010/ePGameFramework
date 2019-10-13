using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace ePGameFramework.Texture
{
    public class Texture2D
    {
        public int textureID = 0;

        private Vector2[] texCoord = new Vector2[4];

        public Vector2[] TexCoord => texCoord;

        public int Width { get; set; }

        public int Height { get; set; }

        public Texture2D()
        {

        }

        public void InitTexture(string Path)
        {
            using(FileStream fs = new FileStream(Path,FileMode.Open))
            {
                InitTexture(fs);
            }
        }

        public void SetRange(int X,int Y,int Width,int Height)
        {
            float fx = (float)X / this.Width;
            float fy = (float)Y / this.Height;
            float fw = (float)Width / this.Width;
            float fh = (float)Height / this.Height;
            texCoord = new Vector2[]
            {
                new Vector2(fx,fy),new Vector2(fx+fw,fy),
                new Vector2(fx+fw,fy+fh),new Vector2(fx,fy+fh)
            };
        }

        public void InitTexture(Stream stream)
        {
            Bitmap bmp = new Bitmap(stream);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);
            GL.TextureParameter(textureID, TextureParameterName.TextureWrapS, (int)(TextureWrapMode.ClampToEdge));
            GL.TextureParameter(textureID, TextureParameterName.TextureWrapT, (int)(TextureWrapMode.ClampToEdge));
            GL.TextureParameter(textureID, TextureParameterName.TextureMagFilter, (int)(TextureMagFilter.Linear));
            GL.TextureParameter(textureID, TextureParameterName.TextureMinFilter, (int)(TextureMinFilter.Linear));
            this.Width = bmp.Width;
            this.Height = bmp.Height;
            bmp.Dispose();
            SetRange(0, 0, Width, Height);
        }

        public void BindTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, textureID);
        }
    }
}
