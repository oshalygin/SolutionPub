using Microsoft.Data.Entity;
using SP.Entities;
using Microsoft.Framework.ConfigurationModel;

namespace SP.DAL
{
    public class BlogContext : DbContext
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
            base.OnConfiguring(optionsBuilder);
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
