namespace DotCustomer.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DotCustomer.Infrastructure.EntityFramework.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
