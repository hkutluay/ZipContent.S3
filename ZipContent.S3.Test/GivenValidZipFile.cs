using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ZipContent.Core;

namespace ZipContent.S3.Test
{
    [TestClass]
    public class GivenValidZipFile
    {
      
        public GivenValidZipFile()
        {
          
        }

        [TestMethod]
        public async Task ExtractedFileCountShouldMatch()
        {

            var partialReader = new S3PartialFileReader(TestContext.GetAmazonS3Client(), "ZipFiles", "foo.zip");
            var lister = new ZipContentLister(partialReader);
            var content = await lister.GetContents();
            Assert.AreEqual(content.Count, 1);
        }

        [TestMethod]
        public async Task ShouldHaveExpectedFileName()
        {

            var partialReader = new S3PartialFileReader(TestContext.GetAmazonS3Client(), "ZipFiles", "foo.zip");
            var lister = new ZipContentLister(partialReader);
            var content = await lister.GetContents();
            Assert.AreEqual(content[0].FullName, "foo.txt");
        }
    }
}