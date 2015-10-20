using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var result = controller.Index() as ViewResult;
            Assert.NotNull(result);


        }

    }
}
