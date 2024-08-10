namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Database.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Database.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            /*
            for (int i = 1; i <= 10; i++)
            {
                context.Categories.AddOrUpdate(
                        new DAL.Database.Models.Category()
                        {
                            Category_ID = i,
                            Name = Guid.NewGuid().ToString().Substring(1, 10),
                            
                        }
                    );
            }
            */

            /*
            Random rnd = new Random();
            for (int i = 1; i <= 10; i++)
            {
                context.Newses.AddOrUpdate(
                        new DAL.Database.Models.News()
                        {
                            News_ID = i,
                            Title = "Title "+i,
                            Description = (Guid.NewGuid().ToString().Substring(1, 10)),
                            Date = new DateTime(DateTime.Now.Year, 1, 1).AddDays(rnd.Next(365)),
                            Category_ID = (rnd.Next(1, 11))
                        }
                    );
            }

            */



        }
    }
}
