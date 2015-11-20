using System;
using Moq;
using SP.DAL;
using Xunit;

namespace SP.BLL.Tests
{
    public class TwitterBLLTests
    {
        private Mock<ITwitterResourceAccess> _twitterResourceAccess;

        [Fact]
        public void ShouldBeWithinRangeOfFiveMinutes()
        {
            _twitterResourceAccess = new Mock<ITwitterResourceAccess>();
            var sut = new TwitterBLL(_twitterResourceAccess.Object);

            var date = DateTime.Now.ToLocalTime().AddMinutes(Mother.FiveMinutes);
            var postedDate = sut.ParsePostedDate(date);
            
            Assert.InRange(postedDate.MinutesFromPostedDate, 3, 6);

        }

        [Fact]
        public void ShouldBeWithinRangeOfOneMonth()
        {
            _twitterResourceAccess = new Mock<ITwitterResourceAccess>();
            var sut = new TwitterBLL(_twitterResourceAccess.Object);


            var date = DateTime.Now.ToLocalTime().AddMonths(Mother.OneMonth);
            var postedDate = sut.ParsePostedDate(date);

            Assert.InRange(postedDate.WeeksFromPostedDate, 3, 5);
        }

        [Fact]
        public void ShouldBeWithinRangeOfFourteenHours()
        {
            _twitterResourceAccess = new Mock<ITwitterResourceAccess>();
            var sut = new TwitterBLL(_twitterResourceAccess.Object);


            var date = DateTime.Now.ToLocalTime().AddHours(Mother.FourteenHours);
            var postedDate = sut.ParsePostedDate(date);

            Assert.InRange(postedDate.HoursFromPostedDate, 13, 15);
        }
    }
}