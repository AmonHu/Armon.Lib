using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace Armon.Lib.Text
{
    public static class ChineseExtension
    {
        public static string ToPinyin(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                var spell = GetSpell(s[i]);
                sb.Append(spell);
            }

            return sb.ToString().ToUpper();
        }


        public static string ToPinyinFirstLetter(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                var spell = GetSpell(s[i])[0];
                sb.Append(spell);
            }

            return sb.ToString().ToUpper();
        }

        private static string GetSpell(char chr)
        {
            var pinyin = NPinyin.Pinyin.GetPinyin(chr);

            var IsValid = ChineseChar.IsValidChar(pinyin[0]);
            if (!IsValid)
            {
                return pinyin;
            }

            var chineseChar = new ChineseChar(pinyin[0]);
            foreach (string value in chineseChar.Pinyins)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    pinyin = value.Remove(value.Length - 1, 1);
                }
            }

            return pinyin;
        }
    }
}
