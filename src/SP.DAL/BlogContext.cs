using Microsoft.Data.Entity;
using SP.Entities;

namespace SP.DAL
{
    public class BlogContext: DbContext
    {

        public BlogContext()
                : base()
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
