using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using SP.BLL;
using SP.Entities;
using SP.WEB.Models;

namespace SP.WEB.Controllers.Api
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostBLL _postBll;

        public PostController(IPostBLL postBll)
        {
            _postBll = postBll;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string page, [FromQuery]int pageSize)
        {
            if (string.IsNullOrEmpty(page))
            {
                const int totalNumberOfPosts = 10;
                var totals = new BlogTotals
                {
                    TotalNumberOfPosts = totalNumberOfPosts
                };

                return Ok(totals);
            }

            int pageToDisplay;
            var parsedPage = int.TryParse(page, out pageToDisplay);

            if (!parsedPage)
            {
                return HttpBadRequest("Invalid page entered");
            }

            var posts = Mapper
                .Map<IEnumerable<Post>, IEnumerable<PostViewModel>>
                (_postBll.Get(pageToDisplay));

            return Ok(posts);
        }

      

    }
}