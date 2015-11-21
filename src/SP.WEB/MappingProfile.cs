using System.Linq;
using AutoMapper;
using SP.Entities;
using SP.WEB.Models;

namespace SP.WEB
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Tags,
                    options => options.MapFrom(
                        src => src.Tags.Select(x => x.Tag)));


            CreateMap<Tag, TagViewModel>();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Image, ImageViewModel>().ReverseMap();
        }
    }
}