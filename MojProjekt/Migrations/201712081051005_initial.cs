namespace MojProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "customer_ID", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "customer_ID" });
            AddColumn("dbo.Invoices", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Invoices", "City", c => c.String(nullable: false));
            AddColumn("dbo.Invoices", "PostCode", c => c.String(nullable: false));
            AddColumn("dbo.Invoices", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Invoices", "NIP", c => c.String(nullable: false));
            DropColumn("dbo.Invoices", "customer_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "customer_ID", c => c.Int());
            DropColumn("dbo.Invoices", "NIP");
            DropColumn("dbo.Invoices", "Address");
            DropColumn("dbo.Invoices", "PostCode");
            DropColumn("dbo.Invoices", "City");
            DropColumn("dbo.Invoices", "Name");
            CreateIndex("dbo.Invoices", "customer_ID");
            AddForeignKey("dbo.Invoices", "customer_ID", "dbo.Customers", "ID");
        }
    }
}
