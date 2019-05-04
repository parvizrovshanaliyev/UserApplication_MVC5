namespace UserApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CategoryId", "dbo.Category");
            DropIndex("dbo.AspNetUsers", new[] { "CategoryId" });
            DropColumn("dbo.AspNetUsers", "CategoryId");
            DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "CategoryId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CategoryId");
            AddForeignKey("dbo.AspNetUsers", "CategoryId", "dbo.Category", "Id");
        }
    }
}
