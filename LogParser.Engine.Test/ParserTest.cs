using System.IO.Compression;
using System.Reflection;

namespace LogParser.Engine.Test
{
    [TestClass]
    [DeploymentItem(@"log.zip")]
    public class ParserTest
    {
        static string outputDir;
        [ClassInitialize]
        public static async Task ClassInitialize(TestContext testContext)
        {
            var dir = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location);
            outputDir = Path.Combine(dir, "Output");
            if (Directory.Exists(outputDir))
            {
                Directory.Delete(outputDir, true);
            }
                Directory.CreateDirectory(outputDir);
            ZipFile.ExtractToDirectory(Path.Combine(dir, "log.zip"), outputDir);

        }

        [ClassCleanup]
        public static async Task ClassCleanup()
        {
            if (Directory.Exists(outputDir))
                Directory.Delete(outputDir, true);
        }


        [TestMethod]
        public void StartParseFolder_OK()
        {
            Parser p = new Parser();
            p.StartParseFolder(Path.Combine(outputDir, "log"));

          var data =   p.GetView(new DateTime(2024, 04, 24, 14, 10, 0), DateTime.MaxValue);
        }
    }
}