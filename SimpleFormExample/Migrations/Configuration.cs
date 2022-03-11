namespace SimpleFormExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleFormExample.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleFormExample.AppDbContext context)
        {
            context.Countries.Add(new Entities.Countries { Name = "Estados Unidos" });
            context.Countries.Add(new Entities.Countries { Name = "Puerto Rico" });
            context.Countries.Add(new Entities.Countries { Name = "Otro" });
            base.Seed(context);
        }
    }
}
