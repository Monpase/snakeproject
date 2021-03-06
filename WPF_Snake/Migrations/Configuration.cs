namespace WPF_Snake.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Documents;

    internal sealed class Configuration : DbMigrationsConfiguration<WPF_Snake.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WPF_Snake.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Records.AddOrUpdate(x => x.ID,
                new Record { Name = "Player 1", Result = 60, Rank = 1, ID = 1 },
                new Record { Name = "Player 2", Result = 30, Rank = 2, ID = 2 },
                new Record { Name = "Player 3", Result = 20, Rank = 3, ID = 3 }
                );
            context.SaveChanges();
        }
    }
}
