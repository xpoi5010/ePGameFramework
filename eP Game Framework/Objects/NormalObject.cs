using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ePGameFramework.GLProgram;
using ePGameFramework.Animation;
using ePGameFramework.Texture;
using OpenTK;
using ePGameFramework.Texture.Effect;

namespace ePGameFramework.Objects
{
    public class NormalObject:IDrawableObject
    {
        private AnimationType<float> xAnimation = new AnimationType<float>();

        public AnimationType<float> XAnimation => xAnimation;

        public float X
        {
            get
            {
                return xAnimation.BaseObject;
            }
            set
            {
                xAnimation.BaseObject = value;
            }
        }

        private AnimationType<float> yAnimation = new AnimationType<float>();

        public AnimationType<float> YAnimation => yAnimation;

        public float Y
        {
            get
            {
                return yAnimation.BaseObject;
            }
            set
            {
                yAnimation.BaseObject = value;
            }
        }

        private AnimationType<float> widthAnimation = new AnimationType<float>();

        public AnimationType<float> WidthAnimation => widthAnimation;

        public float Width
        {
            get
            {
                return widthAnimation.BaseObject;
            }
            set
            {
                widthAnimation.BaseObject = value;
            }
        }

        private AnimationType<float> heightAnimation = new AnimationType<float>();

        public AnimationType<float> HeightAnimation =>heightAnimation;

        public float Height
        {
            get
            {
                return heightAnimation.BaseObject;
            }
            set
            {
                heightAnimation.BaseObject = value;
            }
        }

        private AnimationType<int> rAnimation = new AnimationType<int>();

        public AnimationType<int> RAnimation =>rAnimation;

        public int R
        {
            get
            {
                return rAnimation;
            }
            set
            {
                rAnimation.BaseObject = value;
            }
        }

        private AnimationType<int> gAnimation = new AnimationType<int>();

        public AnimationType<int> GAnimation =>gAnimation;

        public int G
        {
            get
            {
                return gAnimation;
            }
            set
            {
                gAnimation.BaseObject = value;
            }
        }

        private AnimationType<int> bAnimation = new AnimationType<int>();

        public AnimationType<int> BAnimation => bAnimation;

        public int B
        {
            get
            {
                return bAnimation;
            }
            set
            {
                bAnimation.BaseObject = value;
            }
        }

        private AnimationType<int> aAnimation = new AnimationType<int>();

        public AnimationType<int> AlphaAnimation => aAnimation;

        public int Alpha
        {
            get
            {
                return aAnimation;
            }
            set
            {
                aAnimation.BaseObject = value;
            }
        }

        private AnimationType<float> rotationAnimation = new AnimationType<float>();

        public AnimationType<float> RotationAnimation => rotationAnimation;

        public float Rotation
        {
            get
            {
                return rotationAnimation;
            }
            set
            {
                rotationAnimation.BaseObject = value;
            }
        }

        public AngleUnit RotationUnit { get; set; } = AngleUnit.Deg;

        public Texture2D Texture { get; set; }

        public NormalObject()
        {
            xAnimation.ValueController = Controllers.FloatController;
            yAnimation.ValueController = Controllers.FloatController;
            widthAnimation.ValueController = Controllers.FloatController;
            heightAnimation.ValueController = Controllers.FloatController;
            RAnimation.ValueController = Controllers.IntController;
            GAnimation.ValueController = Controllers.IntController;
            BAnimation.ValueController = Controllers.IntController;
            aAnimation.ValueController = Controllers.IntController;
            rotationAnimation.ValueController = Controllers.FloatController;
            xAnimation.ValueConverter = ValueConverters.FloatConverter;
            yAnimation.ValueConverter = ValueConverters.FloatConverter;
            widthAnimation.ValueConverter = ValueConverters.FloatConverter;
            heightAnimation.ValueConverter = ValueConverters.FloatConverter;
            rAnimation.ValueConverter = ValueConverters.IntConverter;
            gAnimation.ValueConverter = ValueConverters.IntConverter;
            bAnimation.ValueConverter = ValueConverters.IntConverter;
            aAnimation.ValueConverter = ValueConverters.IntConverter;
            rotationAnimation.ValueConverter = ValueConverters.FloatConverter;
        }
        public ObjectPosition ObjectPosition { get; set; }

        public PanelPosition PanelPosition { get; set; }

        public EffectKernel Effect { get; set; } = new DefaultEffect();

        public void Draw()
        {
            DateTime lastUpdateTime = DateTime.Now;
            ProcessAnimation(lastUpdateTime);
            if (Alpha == 0)
                return;
            bool HaveTexture = !(Texture is null);
            int ht = HaveTexture ? 1 : 0;
            Vector2[] texCoord = HaveTexture ? Texture.TexCoord : new Vector2[4];
            Effect.ApplyEffect();
            float[] kernel = Effect.GetKernelArray();
            float[] array =
            {
                X,Y,
                Width,Height,
                R/255f,G/255f,B/255f,Alpha/255f,
                ht,
                texCoord[0].X,texCoord[0].Y,
                texCoord[1].X,texCoord[1].Y,
                texCoord[2].X,texCoord[2].Y,
                texCoord[3].X,texCoord[3].Y,
                (int)PanelPosition,
                (int)ObjectPosition,
                Rotation,
                (int)RotationUnit,
                kernel[0],kernel[1],kernel[2],
                kernel[3],kernel[4],kernel[5],
                kernel[6],kernel[7],kernel[8],
            };
            NormalObjectDrawer.DrawArray(array, Texture);
        }

        private void ProcessAnimation(DateTime lastUpdateTime)
        {
            xAnimation.RunningAnimation(lastUpdateTime);
            yAnimation.RunningAnimation(lastUpdateTime);
            widthAnimation.RunningAnimation(lastUpdateTime);
            heightAnimation.RunningAnimation(lastUpdateTime);
            rAnimation.RunningAnimation(lastUpdateTime);
            gAnimation.RunningAnimation(lastUpdateTime);
            bAnimation.RunningAnimation(lastUpdateTime);
            aAnimation.RunningAnimation(lastUpdateTime);
            rotationAnimation.RunningAnimation(lastUpdateTime);
        }

        public void LoadTexture(string Path)
        {
            Texture = TextureManagement.LoadTexture(Path, true);
        }
    }


    /*
     * top           0
     * 
     * centre        1
     * 
     * Bottom        2
     * 
     *    0          1       2
     * Left     Centre   Right
     * 
     */
    public enum ObjectPosition
    {
        TopLeft = 0,
        TopCentre = 1,
        TopRight = 2,
        CentreLeft = 4,
        Centre = 5,
        CentreRight = 6,
        BottomLeft = 8,
        BottomCentre = 9,
        BottomRight = 10,
    }

    /*
     * top           0
     * 
     * centreU       1
     * 
     * centreD       2
     * 
     * Bottom        3
     * 
     * 0      1       2        3
     * Left   CentreL CentreR  Right
     * 
     */
    public enum PanelPosition
    {
        TopLeft = 0,
        TopCentreL = 1,
        TopCentreR = 2,
        TopRight = 3,
        CentreULeft = 4,
        CentreUL = 5,
        CentreUR = 6,
        CentreURight = 7,
        CentreDLeft=8,
        CentreDL = 9,
        CentreDR = 10,
        CentreDRight = 11,
        BottomLeft = 12,
        BottomCentreL = 13,
        BottomCentreR = 14,
        BottomRight = 15
    }

    public enum AngleUnit
    {
        Deg,Rad
    }
}
