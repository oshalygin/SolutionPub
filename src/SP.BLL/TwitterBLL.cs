using System;
using System.Collections.Generic;
using System.Linq;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class TwitterBLL : ITwitterBLL
    {
        private const int NumberOfSecondsOrMinutes = 60;
        private const int NumberOfHoursInOneDay = 24;
        private const int NumberOfDaysInAWeek = 7;

        private readonly ITwitterResourceAccess _twitterResourceAccess;

        public TwitterBLL(ITwitterResourceAccess twitterResourceAccess)
        {
            _twitterResourceAccess = twitterResourceAccess;
        }


        public IEnumerable<Tweet> Get()
        {
            return _twitterResourceAccess
                .Get()
                .Select(tweet => new Tweet()
                {
                    Id = tweet.Id,
                    Body = tweet.Body,
                    DatePosted = ParsePostedDate(tweet.DatePosted.OriginalPostedDate)
                });
        }

        public DatePosted ParsePostedDate(DateTime date)
        {
            long seconds;
            long minutes;
            long days;
            long hours;

            var datePosted = new DatePosted() {OriginalPostedDate = date};
            var totalSeconds = DateTime.Now.ToLocalTime()
                .Subtract(date.ToLocalTime())
                .TotalSeconds;
            var parsedSeconds = Math.Abs((long) totalSeconds);


            var totalMinutes = DivideWithRemainder(parsedSeconds, NumberOfSecondsOrMinutes, out seconds);
            var totalHours = DivideWithRemainder(totalMinutes, NumberOfSecondsOrMinutes, out minutes);
            var totalDays = DivideWithRemainder(totalHours, NumberOfHoursInOneDay, out hours);
            var weeks = DivideWithRemainder(totalDays, NumberOfDaysInAWeek, out days);


            datePosted.SecondsFromPostedDate = parsedSeconds;

            datePosted.SecondsFromPostedDate = seconds;
            datePosted.MinutesFromPostedDate = minutes;
            datePosted.HoursFromPostedDate = hours;
            datePosted.DaysFromPostedDate = days;
            datePosted.WeeksFromPostedDate = weeks;

            return datePosted;
        }

        private static long DivideWithRemainder(long numerator, long denominator, out long remainder)
        {
            remainder = numerator%denominator;
            return numerator/denominator;
        }
    }
}