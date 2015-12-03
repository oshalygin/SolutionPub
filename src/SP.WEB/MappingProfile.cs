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
                        src => src.Tags.Select(x => x.Tag)))
                .ForMember(dest => dest.Comments, options => options.Ignore());
                        


            CreateMap<Tweet, TweetViewModel>()
                .ForMember(dest => dest.OriginalPostedDate,
                    options => options.MapFrom(
                        src => src.DatePosted.OriginalPostedDate))
                .ForMember(dest => dest.WeeksFromPostedDate,
                    options => options.MapFrom(
                        src => src.DatePosted.WeeksFromPostedDate))
                .ForMember(dest => dest.DaysFromPostedDate,
                    options => options.MapFrom(
                        src => src.DatePosted.DaysFromPostedDate))
                .ForMember(dest => dest.HoursFromPostedDate,
                    options => options.MapFrom(
                        src => src.DatePosted.HoursFromPostedDate))
                .ForMember(dest => dest.MinutesFromPostedDate,
                    options => options.MapFrom(
                        src => src.DatePosted.MinutesFromPostedDate))
                .ForMember(dest => dest.SecondsFromPostedDate,
                    options => options.MapFrom(
                        src => src.DatePosted.SecondsFromPostedDate))
                .ForMember(dest => dest.PostedFromDate,
                    options => options.Ignore());


            CreateMap<Tag, TagViewModel>().ReverseMap();
            
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Image, ImageViewModel>().ReverseMap();
        }
    }
}