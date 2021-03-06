﻿using System;
using System.Linq;
using Moq;
using SP.DAL;
using Xunit;

namespace SP.BLL.Tests
{
    public class PostBLLTests
    {

        private Mock<IPostDataAccess> _postDataAccess;

        //TODO: Switch to Nunit later because it has a setup/teardown...Currently NUnit doesn't support vNext
        [Fact]
        public void ShouldReturnAllPostsWhenNoDateRangeIsEntered()
        {
            _postDataAccess = new Mock<IPostDataAccess>();
            _postDataAccess.Setup(x => x.GetPostsByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Mother.PostsWithoutTagsOrComments);
                                

            var sut = new PostBLL(_postDataAccess.Object);

            var posts = sut.GetPostsByDateRange(null, null);
                    
            Assert.Equal(Mother.PostsWithoutTagsOrComments.Count(), posts.Count());

        }

    }
}
