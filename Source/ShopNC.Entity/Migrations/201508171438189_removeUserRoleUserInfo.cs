namespace ShopNC.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserRoleUserInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoleUserInfo", "UserRole_ID", "dbo.UserRole");
            DropForeignKey("dbo.UserRoleUserInfo", "UserInfo_ID", "dbo.UserInfo");
            DropIndex("dbo.UserRoleUserInfo", new[] { "UserRole_ID" });
            DropIndex("dbo.UserRoleUserInfo", new[] { "UserInfo_ID" });
            DropTable("dbo.UserRoleUserInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoleUserInfo",
                c => new
                    {
                        UserRole_ID = c.Int(nullable: false),
                        UserInfo_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_ID, t.UserInfo_ID });
            
            CreateIndex("dbo.UserRoleUserInfo", "UserInfo_ID");
            CreateIndex("dbo.UserRoleUserInfo", "UserRole_ID");
            AddForeignKey("dbo.UserRoleUserInfo", "UserInfo_ID", "dbo.UserInfo", "ID");
            AddForeignKey("dbo.UserRoleUserInfo", "UserRole_ID", "dbo.UserRole", "ID");
        }
    }
}
