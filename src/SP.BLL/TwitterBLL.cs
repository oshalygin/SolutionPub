using System;
using System.Collections.Generic;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class TwitterBLL : ITwitterBLL
    {
        private readonly ITwitterResourceAccess _twitterResourceAccess;

        public TwitterBLL(ITwitterResourceAccess twitterResourceAccess)
        {
            _twitterResourceAccess = twitterResourceAccess;
        }


        public IEnumerable<Tweet> Get()
        {
            return _twitterResourceAccess.Get();
        }

        public DatePosted ParsePostedDate(DateTime date)
        {
            var datePosted = new DatePosted() { OriginalPostedDate = date };
            var seconds = DateTime.Now.ToLocalTime()
                .Subtract(date).Seconds;




            return datePosted;
            

        }
    }
}