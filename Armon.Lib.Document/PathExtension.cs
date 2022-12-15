namespace Armon.Lib.Document
{
    public static class PathExtension
    {
        public static bool IsFile(string path)
        {
            return File.Exists(path);
        }

        public static bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public static bool Exists(string path) 
        {
            return File.Exists(path) || Directory.Exists(path);
        }
    }
}