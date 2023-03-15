namespace Armon.Lib.Document.Test
{
    public class SharedDirectoryTests
    {
        private readonly string path = @"\\172.16.2.25\Shared";
        private readonly User user = new User
        {
            Id = "Diauto",
            Password = "diatuo"
        };

        private SharedDirectory sharedDirectory;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestGetDirectories()
        {
            sharedDirectory = new SharedDirectory(this.path, user);
            var files = sharedDirectory.GetDirectories("*.txt");
            Assert.GreaterOrEqual(files.Length, 1);
            Assert.Pass();
        }
    }
}