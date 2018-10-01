using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Demo.Service.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Demo.Service.DBContext.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Demo.Service.DBContext.DemoContext";
        }
    }
}
