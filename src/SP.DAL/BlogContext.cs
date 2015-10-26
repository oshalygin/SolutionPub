using Microsoft.Data.Entity;
using SP.Entities;
using System.Configuration;
using Microsoft.Framework.ConfigurationModel;

namespace SP.DAL
{
    public class BlogContext: DbContext
    {

        public BlogContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new Configuration();
            var connectionString = configuration.Get("Data:ConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
