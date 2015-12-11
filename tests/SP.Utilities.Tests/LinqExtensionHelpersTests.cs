using System.Linq;
using Xunit;

namespace SP.Utilities.Tests
{
    public class LinqExtensionHelpersTests
    {

        [Fact]
        public void ShouldReturnCorrectNumberOfElementsWhenCallingDistinctBy()
        {
            const int expected = 1;
            var actual = Mother.ListOfUsersWithNonDistinctFirstNames
                .DistinctBy(x => x.FirstName).Count();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DistinctByShouldNotBeEqualToStandardDistinctLinqMethod()
        {
            var distinct = Mother.ListOfUsersWithNonDistinctFirstNames
                .Distinct().Count();
            var distinctBy = Mother.ListOfUsersWithNonDistinctFirstNames
                .DistinctBy(x => x.FirstName)
                .Count();
            
            Assert.NotEqual(distinct, distinctBy);
        }
    }
}
