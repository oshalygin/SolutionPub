using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using SP.Entities;

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
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SolutionPub;Trusted_Connection=True;MultipleActiveResultSets=true");
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
