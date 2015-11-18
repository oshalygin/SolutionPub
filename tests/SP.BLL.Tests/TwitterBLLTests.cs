using System;
using Moq;
using SP.DAL;
using Xunit;

namespace SP.BLL.Tests
{
    public class TwitterBLLTests
    {
        private Mock<TwitterResourceAccess> _twitterResourceAccess;

        public void ShouldReturnDifferenceOfOneMinute()
        {
            _twitterResourceAccess = new Mock<TwitterResourceAccess>();
            var sut = new TwitterBLL(_twitterResourceAccess.Object);

            var expected = 1;
            var date = DateTime.Now.AddMinutes(1).ToLocalTime();
            var postedDate = sut.ParsePostedDate(date);

            Assert.Equal(expected, postedDate.MinutesFromPostedDate);

        }
    }
}