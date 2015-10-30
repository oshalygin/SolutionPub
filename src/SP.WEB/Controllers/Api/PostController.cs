using System;
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

        [HttpGet]
        public IActionResult Get([FromQuery]string page, [FromQuery]string pageSize)
        {
            if (string.IsNullOrEmpty(page) || string.IsNullOrWhiteSpace(pageSize))
            {
                var totalNumberOfPosts = 10;
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



        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var posts = _postBll.GetPost(id);
            if (posts == null)
            {
                return HttpNotFound();
            }

            var postsViewModel = Mapper.Map<Post, PostViewModel>(posts);
            return Ok(postsViewModel);

        }

    }
}
