namespace UserApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USERROLES : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUserRoles", "Id", c => c.String());
            AddColumn("dbo.AspNetUserRoles", "UserAppId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "RoleAppId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.AspNetUserRoles", "UserAppId");
            CreateIndex("dbo.AspNetUserRoles", "RoleAppId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleAppId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserAppId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserAppId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleAppId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleAppId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserAppId" });
            DropColumn("dbo.AspNetUserRoles", "Discriminator");
            DropColumn("dbo.AspNetUserRoles", "RoleAppId");
            DropColumn("dbo.AspNetUserRoles", "UserAppId");
            DropColumn("dbo.AspNetUserRoles", "Id");
        }
    }
}
