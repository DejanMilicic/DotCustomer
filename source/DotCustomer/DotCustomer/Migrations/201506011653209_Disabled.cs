namespace DotCustomer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Disabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DotCustomerCustomer", "Disabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DotCustomerCustomer", "Disabled");
        }
    }
}
