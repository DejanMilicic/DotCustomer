namespace DotCustomer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DotCustomerCustomer", "BillingAddress_Id", "dbo.DotCustomerCustomerAddress");
            DropForeignKey("dbo.DotCustomerCustomer", "ShippingAddress_Id", "dbo.DotCustomerCustomerAddress");
            DropIndex("dbo.DotCustomerCustomer", new[] { "BillingAddress_Id" });
            DropIndex("dbo.DotCustomerCustomer", new[] { "ShippingAddress_Id" });
            AddColumn("dbo.DotCustomerCustomer", "Title", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "Company", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "Street", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "StreetNumber", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "City", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "Zip", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "Country", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "State", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "Province", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "Phone", c => c.String());
            AddColumn("dbo.DotCustomerCustomer", "SubscribedToNewsletter", c => c.Boolean(nullable: false));
            DropColumn("dbo.DotCustomerCustomer", "BillingAddress_Id");
            DropColumn("dbo.DotCustomerCustomer", "ShippingAddress_Id");
            DropTable("dbo.DotCustomerCustomerAddress");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.DotCustomerCustomer", "ShippingAddress_Id", c => c.Int());
            AddColumn("dbo.DotCustomerCustomer", "BillingAddress_Id", c => c.Int());
            DropColumn("dbo.DotCustomerCustomer", "SubscribedToNewsletter");
            DropColumn("dbo.DotCustomerCustomer", "Phone");
            DropColumn("dbo.DotCustomerCustomer", "Province");
            DropColumn("dbo.DotCustomerCustomer", "State");
            DropColumn("dbo.DotCustomerCustomer", "Country");
            DropColumn("dbo.DotCustomerCustomer", "Zip");
            DropColumn("dbo.DotCustomerCustomer", "City");
            DropColumn("dbo.DotCustomerCustomer", "StreetNumber");
            DropColumn("dbo.DotCustomerCustomer", "Street");
            DropColumn("dbo.DotCustomerCustomer", "Company");
            DropColumn("dbo.DotCustomerCustomer", "Title");
            CreateIndex("dbo.DotCustomerCustomer", "ShippingAddress_Id");
            CreateIndex("dbo.DotCustomerCustomer", "BillingAddress_Id");
            AddForeignKey("dbo.DotCustomerCustomer", "ShippingAddress_Id", "dbo.DotCustomerCustomerAddress", "Id");
            AddForeignKey("dbo.DotCustomerCustomer", "BillingAddress_Id", "dbo.DotCustomerCustomerAddress", "Id");
        }
    }
}
