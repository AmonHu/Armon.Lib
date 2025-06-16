using System.Text;

namespace Armon.Lib.Text
{
    public class Base64Extension
    {
        public static string Encode(byte[] b)
        {
            b ??= Array.Empty<byte>();
            return Convert.ToBase64String(b);
        }

        public static string Encode(string s, Encoding? encoding = null)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            encoding ??= Encoding.UTF8;
            var b = encoding.GetBytes(s);
            return Encode(b);
        }

        public static string Decode(string s, Encoding? encoding = null)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            encoding ??= Encoding.UTF8;
            var b = Convert.FromBase64String(s);
            return encoding.GetString(b);
        }
    }
}