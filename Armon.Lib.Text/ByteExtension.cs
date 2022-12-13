using System.Text;

namespace Armon.Lib.Text
{
    public static class ByteExtension
    {
        public static byte[] From(string s, Encoding? encoding) 
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding.GetBytes(s);
        }
    }
}
