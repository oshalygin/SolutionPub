using AutoMapper;
using SP.Entities;
using SP.WEB.Models;

namespace SP.WEB
{
    public class MappingProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Image, ImageViewModel>().ReverseMap();
        }

    }
}
