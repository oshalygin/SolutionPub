using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string CalculatePostedFromDate(long weeks, long days, long hours, long minutes, long seconds)
        {
            var weekExpression = (weeks > 1) ? "weeks" : "week";
            var dayExpression = (days > 1) ? "days" : "day";
            var hourExpression = (hours > 1) ? "hours" : "hour";
            var minuteExpression = (minutes > 1) ? "minutes" : "minute";
            var secondExpression = (seconds > 1) ? "seconds" : "second";

            if (weeks > 0)
            {
                return $"{weeks} {weekExpression} ago";
            }
            if (days > 0)
            {
                return $"{days} {dayExpression} ago";
            }
            if (hours > 0)
            {
                return $"{hours} {hourExpression} and {minutes} {minuteExpression} ago";
            }
            return minutes > 0
                ? $"{minutes} {minuteExpression} ago"
                : $"{seconds} {secondExpression} ago";
        }

        private static long DivideWithRemainder(long numerator, long denominator, out long remainder)
        {
            remainder = numerator%denominator;
            return numerator/denominator;
        }
    }
}