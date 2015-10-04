using System.Data.Entity;
using System.Security.AccessControl;
using System.Security.Policy;
using SP.Entities;

namespace SP.DAL
{
    public class BlogContext: DbContext
    {
        public BlogContext()
                :base(@"Data Source=(localdb)\mssqllocaldb;
          Initial Catalog=NinjaContext;
          Integrated Security=True;")
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PublicImage> PublicImages { get; set; }


    }
}
