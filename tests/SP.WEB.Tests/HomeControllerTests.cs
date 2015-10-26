using Microsoft.AspNet.Mvc;
using SP.WEB.Controllers;
using Xunit;

namespace SP.WEB.Tests
{
    public class HomeControllerTests
    {

        [Fact]
        public void IndexReturnsView()
        {
            var controller = new HomeController();
            var page = 1;

            var result = controller.Index(page) as ViewResult;
            Assert.NotNull(result);

            
        }

    }
}
