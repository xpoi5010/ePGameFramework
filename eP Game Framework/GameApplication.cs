using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ePGameFramework.GLProgram;
using ePGameFramework.Objects;
using System.Drawing;
using ePGameFramework.Animation;
using ePGameFramework.Texture;
using ePGameFramework.Font;
using SharpFNT;
using ePGameFramework.IO;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace ePGameFramework
{
    public class GameApplication:GameWindow
    {
        public List<IDrawableObject> DrawableObjects { get; set; }
        public GameApplication()
        {
            Window.WindowInfo.Width = this.Width;
            Window.WindowInfo.Height = this.Height;
            this.Title = "eP Game Framework with OpenTK";
            GL.Enable(EnableCap.Blend);
            NormalObjectDrawer.Initizate();
            FontProgram.Active();
            FontManager.LoadDefalutFont();
            DrawableObjects = new List<IDrawableObject>();
        }

        public DateTime StartupTime { get; set; }

        private double fps = 0;

        public double FPS => fps;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, this.Width, this.Height);
            Window.WindowInfo.Width = this.Width;
            Window.WindowInfo.Height = this.Height;
            NormalObjectDrawer.SetClientSize(this.Width, this.Height);
            FontProgram.SetClientSize(this.Width, this.Height);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            fps = 1 / e.Time;
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            foreach (IDrawableObject drawableObject in DrawableObjects)
            {
                drawableObject.Draw();
            }
            this.SwapBuffers();
        }

        public new void Run()
        {
            StartupTime = DateTime.Now;
            base.Run();
        }

        public string Render
        { 
            get
            {
                return GL.GetString(StringName.Renderer);
            }
        }
    }
}
