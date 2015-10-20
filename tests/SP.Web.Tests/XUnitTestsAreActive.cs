using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SP.WEB.Tests
{
    public class XUnitTestsAreActive
    {

        [Fact]
        public void ConfigurationIsSuccessful()
        {
            var expected = 5 + 5;
            var actual = 8;

            Assert.Equal(expected,actual);
        }
    }
}
