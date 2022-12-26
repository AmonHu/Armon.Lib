using System.Text;

namespace Armon.Lib.Text.Test
{
    public class StringExtensionTests
    {
        [Test]
        public void TestSplit()
        {
            var s = "1111211";
            var b = StringExtension.Split(s, '1');
            var count = StringExtension.Count(s, "1");
            Assert.That(count + 1, Is.EqualTo(b.Count));
        }

        [Test]
        public void TestGetLengthByEncoding()
        {
            var s = "123一二三";
            var b = StringExtension.GetLengthByEncoding(s, Encoding.Default);
            var length = s.Length;
            Assert.GreaterOrEqual(b, length);
        }

        [Test]
        public void TestFrom()
        {
            var l = new List<string> { "1", "2", "3", "4", "5" };
            var r = StringExtension.From(l, 'X');
            Assert.IsNotEmpty(r);

            var s = "我们";
            var b = ByteExtension.From(s);
            r = StringExtension.From(b);
            Assert.That(s, Is.EqualTo(r));
        }

        [Test]
        public void TestCount()
        {
            var s = "我们我我我我我我哈哈哈哈";
            var c = StringExtension.Count(s, "我");
            Assert.That(c, Is.EqualTo(7));
        }
    }
}