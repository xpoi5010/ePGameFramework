using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ePGameFramework.Texture
{
    public static class TextureManagement
    {
        private static Dictionary<string,Texture2D> baseDictionary = new Dictionary<string, Texture2D>();

        public static Texture2D LoadTexture(string FileName,bool AutoCreate)
        {
            if (!baseDictionary.ContainsKey(FileName))
            {
                if (AutoCreate)
                {
                    Texture2D texture = new Texture2D();
                    texture.InitTexture(FileName);
                    baseDictionary.Add(FileName, texture);
                    return texture;
                }
                else
                {
                    throw new Exception();
                }
            }
            return baseDictionary[FileName];
        }

        public static Texture2D CreateTexture(string Name,Stream stream)
        {
            if (baseDictionary.ContainsKey(Name))
            {
                throw new Exception();
            }
            Texture2D texture = new Texture2D();
            texture.InitTexture(stream);
            baseDictionary.Add(Name, texture);
            return texture;
        }
    }
}
