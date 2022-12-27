
namespace Armon.Lib.Text
{
    public static class UuidExtension
    {
        public static string New(string format = "N")
        {
            return Guid.NewGuid().ToString(format);
        }

        public static string New16()
        {
            var g = Guid.NewGuid();
            var i = g.ToByteArray().Aggregate(1, (current, b) => current * (b + 1));
            return $"{i - DateTime.Now.Ticks:x}";
        }
    }
}
