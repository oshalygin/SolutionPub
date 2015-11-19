using System;
using Moq;
using SP.DAL;
using Xunit;

namespace SP.BLL.Tests
{
    public class TwitterBLLTests
    {
        private Mock<ITwitterResourceAccess> _twitterResourceAccess;

//        [Fact]
        public void ShouldReturnDifferenceOfOneMinute()
        {
            _twitterResourceAccess = new Mock<ITwitterResourceAccess>();
            var sut = new TwitterBLL(_twitterResourceAccess.Object);

            var expected = 1;
            var date = DateTime.Now.AddMinutes(1).ToLocalTime();
            var postedDate = sut.ParsePostedDate(date);
            Console.WriteLine("---------------");
            Console.WriteLine($"Minutes: {postedDate.MinutesFromPostedDate}");
            Console.WriteLine($"Seconds: {postedDate.SecondsFromPostedDate}");
            Console.WriteLine("---------------");

            Assert.Equal(expected, postedDate.MinutesFromPostedDate);

        }
    }
}