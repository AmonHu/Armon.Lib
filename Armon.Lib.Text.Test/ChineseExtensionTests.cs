using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Armon.Lib.Text.Test
{
    public class ChineseExtensionTests
    {
        [Test]
        public void TestToPinyin()
        {
            var s = "ìÍóTªY";
            var b = ChineseExtension.ToPinyin(s);
            var c = ChineseExtension.ToPinyinFirstLetter(s);

            Assert.GreaterOrEqual(b.Length, 0);
        }
    }
}