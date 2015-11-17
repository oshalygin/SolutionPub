using System.Collections.Generic;
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

            return Ok(tweets);
        }
    }
}
