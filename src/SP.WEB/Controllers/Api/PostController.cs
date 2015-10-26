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
        private IPostBLL _postBll;

        public PostController(IPostBLL postBll)
        {
            _postBll = postBll;
        }
        
        [Route("{page}")]
        [HttpGet]
        public IActionResult Get(int page)
        {
            var pageSize = 5;
            var posts = Mapper
                .Map<IEnumerable<Post>, IEnumerable<PostViewModel>>
                (_postBll.Get(page, pageSize));

            return Ok(posts);

        }

        [HttpGet]
        public IActionResult Get()
        {
            var totalNumberOfPosts = 10;
            var totals = new BlogTotals
            {
                TotalNumberOfPosts = totalNumberOfPosts
            };

            return Ok(totals);

        }
        
    }
}
