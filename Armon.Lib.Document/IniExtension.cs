using System.Runtime.InteropServices;
using System.Text;

namespace Armon.Lib.Document
{
    public class IniExtension
    {
        private readonly string path;

        public IniExtension(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.path);
        }


		public string Read(string section, string key)
        {
            var sb = new StringBuilder();
            GetPrivateProfileString(section, key, "", sb, 255, this.path);
            return sb.ToString();
        }



        public void Clear()
        {
            File.Delete(this.path);
        }

        public void Clear(string section)
        {
            this.Write(section, null, null);
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);
    }

    
}
