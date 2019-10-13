#warning OpenGL Library is used.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpFNT;
using ePGameFramework.Texture;
using ePGameFramework.GLProgram;
using OpenTK;
using System.Text.RegularExpressions;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using ePGameFramework.Objects;

namespace ePGameFramework.Font
{
    public class FontDrawer
    {
        private BitmapFont FontInfo { get; set; }

        private Texture2D[] Pages { get; set; }

        private Dictionary<int, List<float>> FontBuffer = new Dictionary<int, List<float>>();

        public int FontSize => FontInfo.Info.Size;

        public string FontName => FontInfo.Info.Face;

        private string baseString = "";

        int VAO = 0;

        int VBO = 0;

        public float X { get; set; }

        public float Y { get; set; }

        public float Margin { get; set; }

        public float Scale { get; set; }

        private bool stringChanged { get; set; }

        public TextAlign TextAlign { get; set; } = TextAlign.Left;

        private float lastUpdateX = 0;

        private float lastUpdateY = 0;

        public float Width { get; set; }

        public float Height { get; set; }

        public bool AutoSize { get; set; }

        public ObjectPosition ObjectPosition { get; set; }

        public Color FontColor
        {
            get
            {
                Color c = Color.FromArgb
                    (
                        (int)(color.W * 255),
                        (int)(color.X * 255),
                        (int)(color.Y * 255),
                        (int)(color.Z * 255));
                return c;
            }
            set
            {
                color = new Vector4(value.R / 255f, value.G / 255f, value.B / 255f, value.A / 255f);
            }
        }

        public float R
        {
            get
            {
                return (color.X * 255);
            }
            set
            {
                color.X = value / 255f;
            }
        }

        public float G
        {
            get
            {
                return (color.Y * 255);
            }
            set
            {
                color.Y = value / 255f;
            }
        }

        public float B
        {
            get
            {
                return (color.Z * 255);
            }
            set
            {
                color.Z = value / 255f;
            }
        }

        public float Alpha
        {
            get
            {
                return (color.W * 255);
            }
            set
            {
                color.W = value / 255f;
            }
        }

        private Vector4 color = new Vector4();

        const int ArraySize = 15;

        public string Text
        {
            get
            {
                return baseString;
            }
            set
            {
                if (baseString == value)
                    return;
                baseString = value;
                stringChanged = true;
            }
        }

        public FontDrawer(string FontFamily,int FontSize)
        {
            FontInfo fi = FontManager.GetFont(FontFamily, FontSize);
            FontInfo = fi.BitmapFontInfo;
            Pages = fi.Pages;
            CreateVertexArray();
            CreateFontBuffer();
        }

        private void CreateVertexArray()
        {
            GL.GenVertexArrays(1, out VAO);
            GL.GenBuffers(1, out VBO);
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 2 * sizeof(float));
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 4 * sizeof(float));
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(3, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 6 * sizeof(float));
            GL.EnableVertexAttribArray(3);
            GL.VertexAttribPointer(4, 2, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 8 * sizeof(float));
            GL.EnableVertexAttribArray(4);
            GL.VertexAttribPointer(5, 4, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 10 * sizeof(float));
            GL.EnableVertexAttribArray(5);
            GL.VertexAttribPointer(6, 1, VertexAttribPointerType.Float, false, ArraySize * sizeof(float), 14 * sizeof(float));
            GL.EnableVertexAttribArray(6);
        }

        public void CreateFontBuffer()
        {
            if (FontInfo is null)
                throw new Exception("");
            FontBuffer.Clear();
            foreach (KeyValuePair<int,string> value in FontInfo.Pages)
            {
                FontBuffer.Add(value.Key, new List<float>());
            }
        }
        public int debug = 0;
        private void UpdateStringBuffer()
        {
            foreach (KeyValuePair<int, List<float>> value in FontBuffer)
                value.Value.Clear();
            UpdateStringBuffer(Text, Scale, new Vector2(X, Y), Margin, color);
            stringChanged = false;
        }

        private void UpdateStringBuffer(string Text, float Scale, Vector2 BasePoint, float Margin, Vector4 color)
        {
            lastUpdateX = BasePoint.X;
            lastUpdateY = BasePoint.Y;
            float lineHeight = this.FontInfo.Info.Size * Scale + Margin * 2f;
            string[] Lines;
            Vector2 b = BasePoint;
            if (Text.Contains("\r\n"))
            {
                Lines = Regex.Split(Text, "\\r\\n");
            }
            else if (Text.Contains("\r"))
            {
                Lines = Regex.Split(Text, "\\r");
            }
            else if (Text.Contains("\n"))
            {
                Lines = Regex.Split(Text, "\\n");
            }
            else
            {
                UpdateLine(Text, Scale, BasePoint, Margin, color);
                return;
            }
            foreach (string s in Lines)
            {
                UpdateLine(s, Scale, b, Margin, color);
                b.Y += lineHeight;
            }

            if (AutoSize)
               this.Height = b.Y;
            
        }
        private void UpdateLine(string Text, float Scale, Vector2 BasePoint, float Margin, Vector4 color)
        {
            float Y = BasePoint.Y;//+ Margin + FontSize;
            float X = BasePoint.X;
            foreach (char cha in Text)
            {
                char newCha = cha;

                if (!FontInfo.Characters.ContainsKey(newCha))
                    newCha = '?';

                Character c = FontInfo.Characters[cha];
                float[] arr = GetArray(
                    new Vector2(X, Y),
                    new Vector2(c.X, c.Y),
                    new Vector2(c.XOffset * Scale, c.YOffset * Scale),
                    new Vector2(c.Width, c.Height),
                    color,
                    Scale,Pages[c.Page]);
                FontBuffer[c.Page].AddRange(arr);
                X += c.XAdvance * Scale;
            }
            if(AutoSize)
            {
                if (this.Width < X)
                    this.Width = X;
            }
        }

        private float[] GetArray(Vector2 originPoint, Vector2 texturePoint, Vector2 offsetPoint, Vector2 size, Vector4 Color, float Scale,Texture2D texture)
        {
            float[] arr =
            {
                originPoint.X,originPoint.Y,
                texturePoint.X,texturePoint.Y,
                offsetPoint.X,offsetPoint.Y,
                texture.Width,texture.Height,
                size.X,size.Y,
                Color.X,Color.Y,Color.Z,Color.W,
                Scale

            };
            return arr;
        }

        public void UpdateText()
        {

        }

        public void Draw()
        {
            if (Text.Length <= Pages.Length*3)
            { 
                DrawWithoutBuffer();
                return;
            }
            if (stringChanged)
                UpdateStringBuffer();
            Vector2 offset = new Vector2(X - lastUpdateX, Y - lastUpdateY);
            FontProgram.SetOffset(offset.X, offset.Y);
            foreach(KeyValuePair<int,List<float>> value in FontBuffer)
            {
                if (value.Value.Count == 0)
                    continue;
                Pages[value.Key].BindTexture();
                float[] arr = value.Value.ToArray();
                GL.BindVertexArray(VAO);
                GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
                GL.BufferData(BufferTarget.ArrayBuffer, arr.Length * sizeof(float), arr, BufferUsageHint.StaticDraw);
                FontProgram.UseProgram();
                GL.DrawArrays(PrimitiveType.Points, 0, arr.Length / ArraySize);
            }
            FontProgram.SetOffset(0,0);
        }

        private void DrawWithoutBuffer()
        {
            if (this.Alpha == 0)
                return;
            DrawWithoutBuffer(Text, Scale, new Vector2(X, Y), Margin, color);
        }

        private void DrawWithoutBuffer(string Text, float Scale, Vector2 BasePoint, float Margin, Vector4 color)
        {
            float lineHeight = this.FontInfo.Info.Size * Scale + Margin * 2f;
            string[] Lines;
            Vector2 b = BasePoint;
            if (Text.Contains("\r\n"))
            {
                Lines = Regex.Split(Text, "\\r\\n");
            }
            else if (Text.Contains("\r"))
            {
                Lines = Regex.Split(Text, "\\r");
            }
            else if (Text.Contains("\n"))
            {
                Lines = Regex.Split(Text, "\\n");
            }
            else
            {
                DrawLine(Text, Scale, BasePoint, Margin, color);
                return;
            }
            foreach (string s in Lines)
            {
                DrawLine(s, Scale, b, Margin, color);
                b.Y += lineHeight;
            }
        }
        private void DrawLine(string Text, float Scale, Vector2 BasePoint, float Margin, Vector4 color)
        {
            float Y = BasePoint.Y;//+ Margin + FontSize;
            float X = BasePoint.X;
            FontProgram.SetOffset(0, 0);
            foreach (char cha in Text)
            {
                char newCha = cha;
                if (!FontInfo.Characters.ContainsKey(newCha))
                    newCha = '?';
                Character c = FontInfo.Characters[cha];
                float[] arr = GetArray(
                    new Vector2(X, Y),
                    new Vector2(c.X, c.Y),
                    new Vector2(c.XOffset * Scale, c.YOffset * Scale),
                    new Vector2(c.Width, c.Height),
                    color,
                    Scale, Pages[c.Page]);
                Pages[c.Page].BindTexture();
                GL.BindVertexArray(VAO);
                GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
                GL.BufferData(BufferTarget.ArrayBuffer, arr.Length * sizeof(float), arr, BufferUsageHint.StaticDraw);
                FontProgram.UseProgram();
                GL.DrawArrays(PrimitiveType.Points, 0, arr.Length / ArraySize);
                X += c.XAdvance * Scale;
            }
            if (this.Width < X)
                this.Width = X;
        }
    }

    public enum TextAlign 
    { 
        Left,Right,Center,
    }
}
