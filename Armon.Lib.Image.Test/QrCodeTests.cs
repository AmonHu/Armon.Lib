namespace Armon.Lib.Image.Test
{
    public class Tests
    {
        private string source = "";
        [SetUp]
        public void Setup()
        {
            this.source = "https://www.bing.com";
        }

        [Test]
        public void Test()
        {
            var b = QrCode.Encode(this.source);
            var t = QrCode.Decode(b);
            Assert.That(t, Is.EqualTo(source));
        }
    }
}