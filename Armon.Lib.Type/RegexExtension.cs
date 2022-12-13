using System.Text.RegularExpressions;

namespace Armon.Lib.Type
{
    public static class RegexExtension
    {
        private static bool IsMatch(string s, string pattern)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            return Regex.IsMatch(s, pattern);
        }

        public static bool IsEmail(string s)
        {
            var pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return IsMatch(s, pattern);
        }

        public static bool IsIp(string s)
        {
            var pattern = @"^((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))$";
            return IsMatch(s, pattern);
        }


        public static bool IsNumeric(string s)
        {
            var pattern = @"^\-?[0-9]+$";
            return IsMatch(s, pattern);
        }


        public static bool IsUnicode(string s)
        {
            var pattern = @"^[\u4E00-\u9FA5\uE815-\uFA29]+$";
            return IsMatch(s, pattern);
        }

        public static bool IsUrl(string s)
        {
            var pattern = @"^(https?|ftp|file|ws)://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";
            return IsMatch(s, pattern);
        }

        public static bool IsMobile(string s)
        {
            var pattern = @"(^\d{18}$)|(^\d{15}$)";
            return IsMatch(s, pattern);
        }
    }
}
