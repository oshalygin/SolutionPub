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
        public IActionResult Get([FromQuery] string page)
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

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var posts = _postBll.GetPostById(id);
            if (posts == null)
            {
                return HttpNotFound();
            }

            var postsViewModel = Mapper.Map<Post, PostViewModel>(posts);
            return Ok(postsViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostViewModel newPost)
        {
            if (newPost == null)
            {
                return HttpBadRequest("No Post was received");
            }
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            var postToSave = Mapper.Map<PostViewModel, Post>(newPost);
            var savedPost = _postBll.SaveNewPost(postToSave);
            if (savedPost == null)
            {
                //TODO: This feels a bit hacky, look into refactoring
                return new HttpStatusCodeResult(400);
            }

            return Created(Request.Host + Request.Path, savedPost);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PostViewModel updatedPost)
        {
            if (updatedPost == null)
            {
                return new NoContentResult();
            }
            if (!ModelState.IsValid)
            {
                return HttpBadRequest("Input Validation Errors");
            }
            var parsedPost = Mapper.Map<PostViewModel, Post>(updatedPost);
            var post = _postBll.UpdatePost(parsedPost);
            if (post == null)
            {
                return HttpBadRequest("Trying to update a post that does not already exist");
            }

            var postViewModel = Mapper.Map<Post, PostViewModel>(post);

            return Ok(postViewModel);

        }

    }
}