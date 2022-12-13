using System.Text.RegularExpressions;

namespace Armon.Lib.Currency
{
    public class YuanExtension
    {
        public static string Parse(decimal d) 
        {
            var format = "#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A";
            var s = d.ToString(format);

            var pattern = @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))";
            var replacement = "${b}${z}";
            s = Regex.Replace(s, pattern, replacement);

            MatchEvaluator evaluator = (Match m) =>
            {
                var digit = "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万亿兆京垓秭穰";
                var index = m.Value[0] - '-';
                return digit[index].ToString();
            };

            s = Regex.Replace(s, ".", evaluator);
            return s;
        }
    }
}