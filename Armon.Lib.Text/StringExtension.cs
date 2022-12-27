using System.Text;
using System.Text.RegularExpressions;

namespace Armon.Lib.Text
{
    public class StringExtension
    {
        public static List<string> Split(string s, params char[]? separator)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            return s.Split(separator).ToList();
        }

        public static int GetLengthByEncoding(string s, Encoding? encoding = null)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            encoding ??= Encoding.UTF8;
            return encoding.GetByteCount(s);
        }

        public static string From(byte[] b, Encoding? encoding = null)
        {
            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }
            encoding ??= Encoding.UTF8;
            return encoding.GetString(b);
        }

        public static string From(List<string> s, char? separator = null)
        {
            if (separator == null)
            {
                return string.Join("", s);
            }

            return string.Join((char)separator, s);
        }

        public static int Count(string s, string t)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            return Regex.Matches(s, t).Count;
        }

        public static string ToSBC(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127) 
                {
                    c[i] = (char)(c[i] + 65248);
                }
            }
            return new string(c);
        }

        public static string ToDBC(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
    }
}