using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using SP.Entities;
using System.Linq;

namespace SP.DAL
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PostTag> PostTag { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString;
            var configuration = new ConfigurationBuilder().SetBasePath(@"..\")
                .AddJsonFile("config.json");

            var databaseConfiguration = configuration.Providers.Single();
            databaseConfiguration.TryGet("Data:DefaultConnection:ConnectionString", out connectionString);

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>().HasKey(primarykey => new
            {
                primarykey.PostId,
                primarykey.TagId
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}