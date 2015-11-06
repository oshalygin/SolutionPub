using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using SP.BLL;
using SP.Entities;
using SP.WEB.Models;


namespace SP.WEB.Controllers.Api
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly ITagBLL _tagBll;
        public TagController(ITagBLL tagBll)
        {
            _tagBll = tagBll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tags = Mapper
                .Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>
                (_tagBll.Get());

            return Ok(tags);
        }

        [HttpGet]
        [Route("{tagName}")]
        public IActionResult Get(int tagName)
        {
            var tag = _tagBll.GetTag(tagName);
            if (tag == null)
            {
                return HttpNotFound();
            }

            var tagViewModel = Mapper.Map<Tag, TagViewModel>(tag);
            return Ok(tagViewModel);
        }


        public IActionResult Remove(int tagId)
        {
            return null;
        }
    }
}
