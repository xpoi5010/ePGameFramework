using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePGameFramework.IO;
using ePGameFramework.Texture;
using SharpFNT;

namespace ePGameFramework.Font
{
    public static class FontManager
    {
        private static List<FontInfo> fonts = new List<FontInfo>();

        public static FontInfo GetFont(string FontFamily,int FontSize)
        {
            return fonts.Find(x => x.FontName == FontFamily && x.FontSize == FontSize);
        }

        public static void LoadFont(PathMode PathMode,string Path,string FileName)
        {
            PathInfo PathInfo = new PathInfo(PathMode, Path);
            BitmapFont bf = BitmapFont.FromStream(PathInfo.GetFile(FileName), true);
            if (ContainFont(bf.Info.Face, bf.Info.Size))
                return;
            Texture2D[] textures = new Texture2D[bf.Pages.Count];
            foreach (KeyValuePair<int, string> keyValue in bf.Pages)
            {
                Texture2D texture = new Texture2D();
                texture.InitTexture(PathInfo.GetFile(keyValue.Value));
                textures[keyValue.Key] = texture;
            }
            FontInfo fi = new FontInfo(bf,textures);
            fonts.Add(fi);
        }

        public static bool ContainFont(string FontFamily, int FontSize)
        {
            return fonts.Exists(x => x.FontName == FontFamily && x.FontSize == FontSize);
        }

        public static void LoadDefalutFont()
        {
            LoadFont(PathMode.EmbeddedResource, "ePGameFramework.Font.DefaultFont.noto75", "noto75.fnt");
        }
    }
}
