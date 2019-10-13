using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePGameFramework.Font;
using ePGameFramework.Animation;

namespace ePGameFramework.Objects
{
    public class Text : IDrawableObject
    {
        private FontDrawer BaseDrawer;

        public string FontFamily { get; set; } = "Noto Sans CJK TC Regular";

        public int FontSize { get; set; } = 75;

        private AnimationType<float> scaleani = new AnimationType<float>();

        public AnimationType<float> ScaleAnimation => scaleani;

        public float Scale 
        {
            get
            {
                return scaleani.BaseObject;
            }

            set
            {
                scaleani.ClearAllAnimation();
                scaleani.BaseObject = value;
            }
        }

        public float Margin { get; set; } = 0;

        private AnimationType<float> xani = new AnimationType<float>();

        public AnimationType<float> XAnimation => xani;

        public float X
        {
            get
            {
                return xani.BaseObject;
            }
            set
            {
                xani.ClearAllAnimation();
                xani.BaseObject = value;
            }
        }

        private AnimationType<float> yani = new AnimationType<float>();

        public AnimationType<float> YAnimation => yani;

        public float Y
        {
            get
            {
                return yani.BaseObject;
            }
            set
            {
                yani.ClearAllAnimation();
                yani.BaseObject = value;
            }
        }

        private AnimationType<int> contentAni = new AnimationType<int>();

        public AnimationType<int> ContentAnimation => contentAni;

        private string baseString = "";

        public string Content 
        {
            get
            {
                return baseString.Substring(0, contentAni.BaseObject);
            }
            set
            {
                contentAni.ClearAllAnimation();
                contentAni.BaseObject = value.Length;
                baseString = value;
            }
        }

        private AnimationType<float> rani = new AnimationType<float>();

        public AnimationType<float> RAnimation => rani;

        public bool AutoSize { get; set; }

        private AnimationType<float> widthani = new AnimationType<float>();

        public AnimationType<float> WidthAnimation => widthani;

        public float Width
        {
            get
            {
                return widthani.BaseObject;
            }
            set
            {
                widthani.ClearAllAnimation();
                widthani.BaseObject = value;
            }
        }

        private AnimationType<float> heightani = new AnimationType<float>();

        public AnimationType<float> HeightAnimation => heightani;

        public float Height
        {
            get
            {
                return heightani.BaseObject;
            }
            set
            {
                heightani.ClearAllAnimation();
                heightani.BaseObject = value;
            }
        }

        public float R
        {
            get
            {
                return rani.BaseObject;
            }
            set
            {
                rani.ClearAllAnimation();
                rani.BaseObject = value;
            }
        }

        private AnimationType<float> gani = new AnimationType<float>();

        public AnimationType<float> GAnimation => gani;

        public float G
        {
            get
            {
                return gani.BaseObject;
            }
            set
            {
                gani.ClearAllAnimation();
                gani.BaseObject = value;
            }
        }

        private AnimationType<float> bani = new AnimationType<float>();

        public AnimationType<float> BAnimation => bani;

        public float B
        {
            get
            {
                return bani.BaseObject;
            }
            set
            {
                bani.ClearAllAnimation();
                bani.BaseObject = value;
            }
        }

        private AnimationType<float> alphaani = new AnimationType<float>();

        public AnimationType<float> AlphaAnimation => alphaani;

        public float Alpha
        {
            get
            {    
                return alphaani.BaseObject;
            }
            set
            {
                alphaani.ClearAllAnimation();
                alphaani.BaseObject = value;
            }
        }



        public Text()
        {
            Initize();
            InitizeAnimation();
        }

        public void Draw()
        {
            if (BaseDrawer is null)
                Initize();
            if(BaseDrawer.FontName != FontFamily || BaseDrawer.FontSize != FontSize)
                Initize();
            UpdateAnimation();
            UpdateFontDrawer();
        }

        public void Initize()
        {
            BaseDrawer = new FontDrawer(this.FontFamily, this.FontSize);
        }

        private void UpdateAnimation()
        {
            DateTime now = DateTime.Now;
            scaleani.RunningAnimation(now);
            xani.RunningAnimation(now);
            yani.RunningAnimation(now);
            rani.RunningAnimation(now);
            gani.RunningAnimation(now);
            bani.RunningAnimation(now);
            alphaani.RunningAnimation(now);
            contentAni.RunningAnimation(now);
            if(AutoSize)
            {
                widthani.RunningAnimation(now);
                heightani.RunningAnimation(now);
            }
        }

        private void InitizeAnimation()
        {
            scaleani.ValueController = Controllers.FloatController;
            xani.ValueController = Controllers.FloatController;
            yani.ValueController = Controllers.FloatController;
            rani.ValueController = Controllers.FloatController;
            gani.ValueController = Controllers.FloatController;
            bani.ValueController = Controllers.FloatController;
            alphaani.ValueController = Controllers.FloatController;
            contentAni.ValueController = Controllers.IntController;
            scaleani.ValueConverter = ValueConverters.FloatConverter;
            xani.ValueConverter = ValueConverters.FloatConverter;
            yani.ValueConverter = ValueConverters.FloatConverter;
            rani.ValueConverter = ValueConverters.FloatConverter;
            gani.ValueConverter = ValueConverters.FloatConverter;
            bani.ValueConverter = ValueConverters.FloatConverter;
            alphaani.ValueConverter = ValueConverters.FloatConverter;
            contentAni.ValueConverter = ValueConverters.IntConverter;
        }

        private void UpdateFontDrawer()
        {
            BaseDrawer.X = X;
            BaseDrawer.Y = Y;
            BaseDrawer.Margin = Margin;
            BaseDrawer.Scale = Scale;
            BaseDrawer.R = R;
            BaseDrawer.G = G;
            BaseDrawer.B = B;
            BaseDrawer.Alpha = Alpha;
            BaseDrawer.Text = Content;
            BaseDrawer.Draw();
        }
    }
}
