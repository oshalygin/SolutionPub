using Microsoft.AspNet.Http;
using Microsoft.Dnx.Runtime;
using Moq;
using Xunit;

namespace SP.DAL.Tests
{
    public class ImageUtilityTests
    {
        private Mock<IApplicationEnvironment> _applicationEnvironment;
        private Mock<IFormFile> _formFile;

        //TODO: Need to figure out how to test some of this stuff..
        [Fact]
        public void ShouldSaveToBlogImagesFolder()
        {

            _applicationEnvironment = new Mock<IApplicationEnvironment>();
            _formFile = new Mock<IFormFile>();

            _applicationEnvironment.Setup(x => x.ApplicationBasePath)
                .Returns(@"C:\dev\");

            var sut = new ImageUtility(_applicationEnvironment.Object);
//            sut.SaveImage();

        }
    }
}
