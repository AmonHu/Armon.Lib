namespace Armon.Lib.Text.Test
{
    public class StringExtensionTests
    {
        [Test]
        public void TestSplit()
        {
            string s = "1111211";
            var b = StringExtension.Split(s, '1');
            var count = StringExtension.Count(s, "1");
            Assert.AreEqual(b.Count, count + 1);
        }
    }
}