namespace Armon.Lib.Document.Test
{
    public class IniExtensionTests
    {
        private readonly string path = "d://test.iii";
        private IniExtension ini;
        [SetUp]
        public void Setup()
        {
            ini = new IniExtension(this.path);
        }

        [Test]
        public void TestWrite()
        {
            ini.Write("host", "host1", "127.0.0.1");
            ini.Write("host", "host2", "127.0.0.2");
            Assert.Pass();
        }

        [Test]
        public void TestClear()
        {
            ini.Clear();
            Assert.Pass();
        }

        [Test]
        public void TestClearSection()
        {
            ini.Clear("host");
            Assert.Pass();
        }

        [Test]
        public void TestRead()
        {
            var host1 =  ini.Read("host","host1");
            Assert.That(host1, Is.EqualTo("127.0.0.1"));
        }
    }
}