using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity.Infrastructure;
using Xunit;

namespace SP.DAL.Tests
{
    public class TestDataSeeder
    {
        private UserManager<ApplicationUser> _userManager; 

        public TestDataSeeder(UserManager<ApplicationUser> userManager )
        {
            _userManager = userManager;

        }
   
        [Fact]
        public void SeedBlogPostTagAndComments()
        {


            var context = new BlogContext();
            var seeder = new SeedData(context);
            var success = seeder.SeedPostTagComments();

            Assert.False(success);


        }

        [Fact]
        public async Task SeedUserData()
        {
            var context = new BlogContext();
            var seeder = new SeedData(context);
           await  seeder.SeedUserData(_userManager);

            Assert.True(true);
        }

    }
}
