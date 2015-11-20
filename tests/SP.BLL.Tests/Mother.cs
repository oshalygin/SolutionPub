using System;
using System.Collections.Generic;
using System.Linq;
using SP.Entities;

namespace SP.BLL.Tests
{
    public static class Mother
    {

        public static double FiveMinutes => 5;
        public static int OneMonth => 1;
        public static double FourteenHours => 14;

        public static IEnumerable<Post> PostsWithoutTagsOrComments
        {
            get
            {
                int numberOfPosts = 17;

                var bodyTextFirstSample =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Donec ac placerat mauris, quis rutrum turpis";

                var bodyTextSecondSample =
                    "Aenean sed fringilla lectus, vitae placerat mi. Proin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Proin in sem ac dolor vestibulum sodales a nec lacus. Praesent lectus quam, interdum a condimentum accumsan, congue in ante. Phasellus at mi euismod, mollis dui in, ornare nisl.";

                var postList = new List<Post>();

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
                        PostedDate = new DateTime(2015, 5, (i + 1)),
                        Title = i%2 == 0 ? "AngularJS Routing" : "JavaScript Fundamentals",
                        UrlTitle = i%2 == 0 ? "AngularJS-Routing" : "JavaScript-Fundamentals",
                        Views = random.Next(100),
                        PhotoPath = @"C:\dev\PhotoPath",
                        Inactive = false
                    };


                    postList.Add(post);
                }
                return postList.AsEnumerable();
            }
        }
    }
}