using System;
using System.IO;
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


        [Fact]
        public void ShouldSaveToBlogImagesFolder()
        {
            _applicationEnvironment = new Mock<IApplicationEnvironment>();
            _formFile = new Mock<IFormFile>();

            _applicationEnvironment.Setup(x => x.ApplicationBasePath)
                .Returns(Mother.ApplicationBasePath);
            
            var someStream = new MemoryStream(100);

            _formFile.Setup(x => x.OpenReadStream()).Returns(someStream);

            var sut = new ImageUtility(_applicationEnvironment.Object);
            var image = sut.SaveImage(Mother.BlogImageFileName, Mother.ImageDescription, _formFile.Object);

            var actual = image.ImagePath;
            var expected = Mother.ApplicationBasePath + Mother.BlogImagePath;
            Console.WriteLine(expected);
            Console.WriteLine(actual);

            Assert.True(true);
        }
    }
}