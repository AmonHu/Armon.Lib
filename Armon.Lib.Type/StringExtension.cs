using System.Text;

namespace Armon.Lib.Type
{
    public class StringExtension
    {
        public static List<string> Split(string s, params char[]? separator) 
        {
            if (string.IsNullOrWhiteSpace(s)) 
            {
                return new();
            }
            return s.Split(separator).ToList();
        }


        public static int GetLength(string s)
        {
            var bytes = new ASCIIEncoding().GetBytes(s);
            int length = 0;
            foreach (byte b in bytes)
            {
                if (b == 63)
                {
                    length += 2;
                }
                else
                {
                    length += 1;
                }
            }
            return length;
        }

        public static string From(byte[] b, Encoding? encoding)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding.GetString(b);
        }

        public static string From(List<string> s, char? separator)
        {
            if (separator == null) 
            {
                return string.Join("", s);
            }
            
            return string.Join((char)separator, s);
        }
    }
}