using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ePGameFramework.IO
{
    public class PathInfo
    {
        public PathInfo(PathMode pm,string path)
        {
            this.PathMode = pm;
            this.Path = path;
        }

        public PathMode PathMode { get; set; }

        public string Path { get; set; }

        public Stream GetFile(string FileName)
        {
            if(PathMode == PathMode.EmbeddedResource)
            {
                return Resource.ResourceReader.ReadStream(GetFullPath(FileName));
            }
            else if (PathMode == PathMode.UnixPath||PathMode == PathMode.WindowsPath)
            {
                return new FileStream(GetFullPath(FileName),FileMode.Open);
            }
            else
            {
                throw new Exception($"Function: {nameof(ePGameFramework.IO.PathInfo.GetFile)}");
            }
        }

        public string GetFullPath(string FileName)
        {
            switch (PathMode)
            {
                case PathMode.EmbeddedResource:
                    return $"{Path}.{FileName}";
                case PathMode.UnixPath:
                    return $"{Path}/{FileName}";
                case PathMode.WindowsPath:
                    return $"{Path}\\{FileName}";
                default:
                    throw new Exception($"Function: {nameof(ePGameFramework.IO.PathInfo.GetFullPath)}");
            }
        }

        public bool Exist(string FileName)
        {
            if (PathMode == PathMode.EmbeddedResource)
            {
                return Resource.ResourceReader.Exist(GetFullPath(FileName));
            }
            else if (PathMode == PathMode.UnixPath || PathMode == PathMode.WindowsPath)
            {
                return File.Exists(GetFullPath(FileName));
            }
            else
            {
                throw new Exception($"Function: {nameof(ePGameFramework.IO.PathInfo.Exist)}");
            }
        }

        public string[] GetFiles()
        {
            if (PathMode == PathMode.EmbeddedResource)
            {
                return Resource.ResourceReader.GetPaths(Path);
            }
            else if (PathMode == PathMode.UnixPath || PathMode == PathMode.WindowsPath)
            {
                return Directory.GetFiles(Path);
            }
            else
            {
                throw new Exception($"Function: {nameof(ePGameFramework.IO.PathInfo.GetFiles)}");
            }
        }
    }

    public enum PathMode
    {
        EmbeddedResource,
        WindowsPath,
        UnixPath
    }
}
