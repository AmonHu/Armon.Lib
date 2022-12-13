namespace Armon.Lib.Text.Test
{
    public class Base64ExtensionTests
    {
        [Test]
        public void Test()
        {
            string s = "1111111";
            var b = Base64Extension.Encode(s);
            var sd = Base64Extension.Decode(b);
            Assert.That(sd, Is.EqualTo(s));
        }
    }
}