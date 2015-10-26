using Microsoft.Data.Entity;
using SP.Entities;
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
            var connectionString = configuration.Get("Data:DefaultConnection:ConnectionString");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
