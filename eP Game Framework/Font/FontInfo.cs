using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SharpFNT;
using System.IO;
using ePGameFramework.IO;
using OpenTK;
using ePGameFramework.GLProgram;
using ePGameFramework.Objects;
using ePGameFramework.Texture;

namespace ePGameFramework.Font
{
    public class FontInfo
    {
        public BitmapFont BitmapFontInfo { get; set; }

        public Texture2D[] Pages { get; set; }

        public string FontName => BitmapFontInfo.Info.Face;

        public int FontSize => BitmapFontInfo.Info.Size;

        public FontInfo(BitmapFont BitmapFontInfo, Texture2D[] Pages)
        {
            this.BitmapFontInfo = BitmapFontInfo;
            this.Pages = Pages;
        }
        
    }
}
