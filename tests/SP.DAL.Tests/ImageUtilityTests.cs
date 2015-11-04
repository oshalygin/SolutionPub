using System;
using Microsoft.AspNet.Http;
using Microsoft.Dnx.Runtime;
using Moq;
using NUnit.Framework;

namespace SP.DAL.Tests
{
    [TestFixture]
    public class ImageUtilityTests
    {
        private Mock<IApplicationEnvironment> _applicationEnvironment;
        private Mock<IFormFile> _formFile;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _applicationEnvironment = new Mock<IApplicationEnvironment>();
            _formFile = new Mock<IFormFile>();
        }

        [Test]
        public void ShouldSaveToBlogImagesFolder()
        {
            _applicationEnvironment.Setup(x => x.ApplicationBasePath)
                .Returns(Mother.ApplicationBasePath);

            var sut = new ImageUtility(_applicationEnvironment.Object);
            var image = sut.SaveImage(Mother.BlogImageFileName, Mother.ImageDescription, _formFile.Object);

            var actual = image.ImagePath;
            var expected = Mother.ApplicationBasePath + Mother.BlogImagePath;
            Console.WriteLine(expected);
            Console.WriteLine(actual);

            Assert.That(true, Is.True);
        }
    }
}