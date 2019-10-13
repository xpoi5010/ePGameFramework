using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Resources;

namespace ePGameFramework.Resource
{
    public static class ResourceReader
    {
        public static string ReadString(string Path)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            using (Stream s = ass.GetManifestResourceStream(Path))
            {
                byte[] TextBinary = new byte[s.Length];
                s.Read(TextBinary, 0, TextBinary.Length);
                string Text = Encoding.UTF8.GetString(TextBinary);
                return Text;
            }
        }

        public static Stream ReadStream(string Path)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            Stream s = ass.GetManifestResourceStream(Path);
            return s;
        }

        public static string[] GetPaths(string AssemblyNamespace)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            string[] output = ass.GetManifestResourceNames();
            output = Array.FindAll(output, x => x.Contains(AssemblyNamespace));
            return output;
        }

        public static bool Exist(string Path)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            using(Stream s = ReadStream(Path))
            {
                return !(s is null);
            }
        }

        public static string GetParentPath(string Path)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            ManifestResourceInfo mri =  ass.GetManifestResourceInfo(Path);
            return mri.ReferencedAssembly.ToString();
        }
    }
}
