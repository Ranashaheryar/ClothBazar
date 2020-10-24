namespace ClothBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitalized : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Decription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Decription = c.String(),
                        Catagory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Catagories", t => t.Catagory_ID)
                .Index(t => t.Catagory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Catagory_ID", "dbo.Catagories");
            DropIndex("dbo.Products", new[] { "Catagory_ID" });
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
