namespace ShopNC.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoleUserInfoByList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoleUserInfo",
                c => new
                    {
                        UserRole_ID = c.Int(nullable: false),
                        UserInfo_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_ID, t.UserInfo_ID })
                .ForeignKey("dbo.UserRole", t => t.UserRole_ID)
                .ForeignKey("dbo.UserInfo", t => t.UserInfo_ID)
                .Index(t => t.UserRole_ID)
                .Index(t => t.UserInfo_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleUserInfo", "UserInfo_ID", "dbo.UserInfo");
            DropForeignKey("dbo.UserRoleUserInfo", "UserRole_ID", "dbo.UserRole");
            DropIndex("dbo.UserRoleUserInfo", new[] { "UserInfo_ID" });
            DropIndex("dbo.UserRoleUserInfo", new[] { "UserRole_ID" });
            DropTable("dbo.UserRoleUserInfo");
        }
    }
}
