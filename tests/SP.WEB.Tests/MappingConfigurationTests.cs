using AutoMapper;
using Xunit;

namespace SP.WEB.Tests
{
    public class MappingConfigurationTests
    {

        [Fact]
        public void ConfirmConfiguration()
        {
            Mapper.Initialize(configuration => configuration.AddProfile<MappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }

    }
}
