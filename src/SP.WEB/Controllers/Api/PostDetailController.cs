using AutoMapper;
using Microsoft.AspNet.Mvc;
using SP.BLL;
using SP.Entities;
using SP.WEB.Models;


namespace SP.WEB.Controllers.Api
{
    [Route("api/[controller]")]
    public class PostDetailController : Controller
    {
        private readonly IPostBLL _postBll;

        public PostDetailController(IPostBLL postBll)
        {
            _postBll = postBll;
        }

        [HttpGet]
        public IActionResult Get(string postUrlTitle)
        {
            var posts = _postBll.GetPostByUrlTitle(postUrlTitle);
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

        [HttpDelete]
        public IActionResult Delete([FromBody] int postId)
        {
            var success = _postBll.DeletePost(postId);
            if (success)
            {
                return Ok();
            }
            return HttpBadRequest();

        }
    }
}
