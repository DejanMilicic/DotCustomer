namespace DotCustomer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DotCustomerCustomerAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        Province = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        SubscribedToNewsletter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DotCustomerCustomer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BillingAddress_Id = c.Int(),
                        ShippingAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DotCustomerCustomerAddress", t => t.BillingAddress_Id)
                .ForeignKey("dbo.DotCustomerCustomerAddress", t => t.ShippingAddress_Id)
                .Index(t => t.BillingAddress_Id)
                .Index(t => t.ShippingAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DotCustomerCustomer", "ShippingAddress_Id", "dbo.DotCustomerCustomerAddress");
            DropForeignKey("dbo.DotCustomerCustomer", "BillingAddress_Id", "dbo.DotCustomerCustomerAddress");
            DropIndex("dbo.DotCustomerCustomer", new[] { "ShippingAddress_Id" });
            DropIndex("dbo.DotCustomerCustomer", new[] { "BillingAddress_Id" });
            DropTable("dbo.DotCustomerCustomer");
            DropTable("dbo.DotCustomerCustomerAddress");
        }
    }
}
