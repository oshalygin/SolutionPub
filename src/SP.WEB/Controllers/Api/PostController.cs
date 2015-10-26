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
        public IEnumerable<PostViewModel> Get()
        {

            var posts = Mapper
                .Map<IEnumerable<Post>, IEnumerable<PostViewModel>>
                (_postBll.Get(0));            
            
            return posts;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
