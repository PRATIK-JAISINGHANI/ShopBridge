namespace ShopBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVariant",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Size = c.String(),
                        ItemId = c.Guid(nullable: false),
                        Price = c.Single(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemVariant");
        }
    }
}
