using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using SP.BLL;
using SP.Entities;
using SP.WEB.Models;

namespace SP.WEB.Controllers.Api
{
    [Route("api/[controller]")]
    public class TwitterController : Controller
    {
        private readonly ITwitterBLL _twitterBll;
        public TwitterController(ITwitterBLL twitterBll)
        {
            _twitterBll = twitterBll;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var tweets = Mapper.Map<IEnumerable<Tweet>, IEnumerable<TweetViewModel>>
                (_twitterBll.Get());

            tweets.ToList().ForEach(x=>
            {
                x.PostedFromDate =
                    _twitterBll.CalculatePostedFromDate(x.WeeksFromPostedDate, x.DaysFromPostedDate,
                        x.HoursFromPostedDate, x.MinutesFromPostedDate, x.SecondsFromPostedDate);
            });

            return Ok(tweets);
        }
    }
}
