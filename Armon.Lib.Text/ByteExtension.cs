using System.Text;

namespace Armon.Lib.Text
{
    public static class ByteExtension
    {
        public static byte[] From(string s, Encoding? encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return encoding.GetBytes(s);
        }

        public static byte[] From(Stream stream)
        {
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
