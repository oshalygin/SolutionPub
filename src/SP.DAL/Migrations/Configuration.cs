namespace SP.DAL.Migrations
{
    using System.Data.Entity.Migrations;


    internal sealed class Configuration : DbMigrationsConfiguration<SP.DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SP.DAL.BlogContext context)
        {

        }
    }
}
