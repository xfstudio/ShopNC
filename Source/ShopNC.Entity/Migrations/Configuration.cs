namespace ShopNC.Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopNC.Entity.Mapping.ShopNCContext>
    {
        public Configuration()
        {
            //自动迁移 数据库添加了 __MigrationHistory表
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

          //  AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopNC.Entity.Mapping.ShopNCContext context)
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
        }
    }
}
