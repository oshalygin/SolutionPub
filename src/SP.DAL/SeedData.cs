using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.OptionsModel;
using SP.Entities;

namespace SP.DAL
{
    public class SeedData
    {

        private readonly BlogContext _context;

        public SeedData(BlogContext context)
        {
            _context = context;
        }

        public bool SeedPostTagComments()
        {
            if (!_context.Posts.Any())
            {
                int numberOfPosts = 17;

                var bodyTextFirstSample =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Donec ac placerat mauris, quis rutrum turpis";

                var bodyTextSecondSample =
                    "Aenean sed fringilla lectus, vitae placerat mi. Proin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Proin in sem ac dolor vestibulum sodales a nec lacus. Praesent lectus quam, interdum a condimentum accumsan, congue in ante. Phasellus at mi euismod, mollis dui in, ornare nisl.";

                var postList = new List<Post>();

                var angularJsTag = new Tag {TimesUsed = 3, Name = "angularjs"};
                var javaScriptTag = new Tag {TimesUsed = 6, Name = "javascript"};
                var cSharpTag = new Tag {TimesUsed = 2, Name = "csharp"};

                _context.Tags.Add(angularJsTag);
                _context.Tags.Add(javaScriptTag);
                _context.Tags.Add(cSharpTag);

                var random = new Random();


                for (int i = 0; i < numberOfPosts; i++)
                {
                    var post = new Post
                    {
                        Preview =
                            i%2 == 0 ? bodyTextFirstSample.Substring(50, 400) : bodyTextSecondSample.Substring(50, 400),
                        Body =
                            i%2 == 0
                                ? bodyTextFirstSample + "<br><br>" + bodyTextSecondSample
                                : bodyTextSecondSample + "<br><br>" + bodyTextFirstSample,
                        PostedDate = DateTime.UtcNow,
                        Title = i%2 == 0 ? "AngularJS Routing" : "JavaScript Fundamentals",
                        UrlTitle = i%2 == 0 ? "AngularJS-Routing" : "JavaScript-Fundamentals",
                        Views = random.Next(100),
                        PhotoPath = @"C:\dev\PhotoPath",
                        Inactive = false,
                        Comments = BuildCommentList(random.Next(7))
                    };


                    postList.Add(post);
                }

                _context.Posts.AddRange(postList);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Comment> BuildCommentList(int commentSize)
        {
            var commentList = new List<Comment>();
            for (int i = 0; i < commentSize; i++)
            {
                var comment = new Comment
                {
                    DateOfComment = DateTime.UtcNow,
                    Body = i%3 == 0
                        ? "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."
                        : "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur"
                };


                commentList.Add(comment);
            }
            return commentList;
        }
    }
}