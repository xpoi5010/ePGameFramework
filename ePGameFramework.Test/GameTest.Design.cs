using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePGameFramework.Animation;
using ePGameFramework.Texture;
using ePGameFramework.Font;
using ePGameFramework.Objects;

namespace ePGameFramework.Test
{
    public partial class GameTest
    {
        NormalObject Cursor;

        Text Player;

        NormalObject Key1;

        NormalObject Key2;

        NormalObject UserImg;

        NormalObject PlayerBG;

        NormalObject Background;

        NormalObject debug_BG;

        Text debug_message;

        public void Initize()
        {
            //------------------------
            //  Main
            //------------------------

            this.Width = 1280;
            this.Height = 720;
            this.VSync = OpenTK.VSyncMode.Off;

            //------------------------
            //  Background
            //------------------------

            Background = new NormalObject()
            {
                X = 0,
                Y = 0,
                Width = 1280,
                Height = 720,
                R = 255,
                G = 255,
                B = 255,
                Alpha = 255,
                ObjectPosition = ObjectPosition.TopLeft,
                PanelPosition = PanelPosition.TopLeft
            };
            Background.Texture = TextureManagement.LoadTexture(@"D:\osu!\Songs\968171 MIMI feat Hatsune Miku - Mizuoto to Curtain\qt-miku.jpg", true);
            this.DrawableObjects.Add(Background);

            //------------------------
            //  Cursor
            //------------------------

            Cursor = new NormalObject()
            {
                X=0,
                Y=0,
                Width=40,
                Height=40,
                R=255,
                G=0,
                B=255,
                Alpha=255,
                ObjectPosition = ObjectPosition.Centre,
                PanelPosition = PanelPosition.TopLeft
            };
            Cursor.Texture = TextureManagement.LoadTexture(@"D:\osu!\Skins\404 AimNotFound 2018-10-20 EZ\cursor.png", true);
            this.DrawableObjects.Add(Cursor);

            //------------------------
            //  Key1
            //------------------------

            Key1 = new NormalObject()
            {
                X = 20,
                Y = 20,
                Width = 40,
                Height = 40,
                R = 255,
                G = 0,
                B = 255,
                Alpha = 255,
                ObjectPosition = ObjectPosition.Centre,
                PanelPosition = PanelPosition.TopLeft
            };
            this.DrawableObjects.Add(Key1);

            //------------------------
            //  Key2
            //------------------------

            Key2 = new NormalObject()
            {
                X = 60,
                Y = 20,
                Width = 40,
                Height = 40,
                R = 255,
                G = 255,
                B = 0,
                Alpha = 255,
                ObjectPosition = ObjectPosition.Centre,
                PanelPosition = PanelPosition.TopLeft
            };
            this.DrawableObjects.Add(Key2);

            //------------------------
            //   PlayerBG
            //------------------------
            PlayerBG = new NormalObject()
            {
                X = 80,
                Y = 0,
                Width = 160,
                Height = 37.5f,
                R = 35,
                G = 35,
                B = 35,
                Alpha = 175,
                ObjectPosition = ObjectPosition.TopLeft,
                PanelPosition = PanelPosition.TopLeft
            };
            this.DrawableObjects.Add(PlayerBG);


            //------------------------
            //  Player 29cdb5
            //------------------------

            Player = new Text()
            {
                X=90,
                Y=0,
                R = 0x29,
                G = 0xcd,
                B=0xb5,
                Alpha = 128,
                Scale=0.5f,
                Margin = 0
            };
            this.DrawableObjects.Add(Player);

            //C:\Users\xpoi5\Downloads\3100232.jfif

            //------------------------
            //  UserImg
            //------------------------

            UserImg = new NormalObject()
            {
                X = 50,
                Y = 50,
                Width = 80,
                Height = 80,
                R = 255,
                G = 255,
                B = 255,
                Alpha = 255,
                ObjectPosition = ObjectPosition.Centre,
                PanelPosition = PanelPosition.TopLeft,
                Rotation = 0f,
                RotationUnit = AngleUnit.Deg
            };
            UserImg.Texture = TextureManagement.LoadTexture(@"DebugFile\3100232.jfif", true);
            this.DrawableObjects.Add(UserImg);

            //------------------------
            //  Debug MessageBox
            //------------------------

            debug_BG = new NormalObject()
            {
                X = 90,
                Y = 50,
                Width = 300,
                Height = 100,
                R = 35,
                G = 35,
                B = 35,
                Alpha = 0,
                ObjectPosition = ObjectPosition.TopLeft,
                PanelPosition = PanelPosition.TopLeft
            };

            this.DrawableObjects.Add(debug_BG);

            debug_message = new Text()
            {
                X = 90f,
                Y = 62.5f,
                R = 255,
                G = 255,
                B = 255,
                Alpha = 128,
                Scale = 0.5f,
                Margin = 0
            };
            this.DrawableObjects.Add(debug_message);
        }
    }
}
