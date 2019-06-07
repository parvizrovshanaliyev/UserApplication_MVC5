namespace UserApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleAppId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserAppId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserAppId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleAppId" });
            DropColumn("dbo.AspNetUserRoles", "Id");
            DropColumn("dbo.AspNetUserRoles", "UserAppId");
            DropColumn("dbo.AspNetUserRoles", "RoleAppId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUserRoles", "RoleAppId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "UserAppId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "Id", c => c.String());
            CreateIndex("dbo.AspNetUserRoles", "RoleAppId");
            CreateIndex("dbo.AspNetUserRoles", "UserAppId");
            AddForeignKey("dbo.AspNetUserRoles", "UserAppId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleAppId", "dbo.AspNetRoles", "Id");
        }
    }
}
