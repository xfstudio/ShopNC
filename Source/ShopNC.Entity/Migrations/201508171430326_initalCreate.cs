namespace ShopNC.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 16),
                        TrueName = c.String(maxLength: 8),
                        Password = c.String(nullable: false, maxLength: 16),
                        Email = c.String(maxLength: 32),
                        Phone = c.String(maxLength: 11),
                        TelePhone = c.String(maxLength: 32),
                        Address = c.String(maxLength: 64),
                        Gender = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                        CreateTime = c.DateTime(),
                        EditeTime = c.DateTime(),
                        Editor = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ENName = c.String(nullable: false, maxLength: 16),
                        CNName = c.String(maxLength: 16),
                        Remark = c.String(maxLength: 1024),
                        Status = c.Byte(nullable: false),
                        CreateTime = c.DateTime(),
                        EditeTime = c.DateTime(),
                        Editor = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRoleR",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfo", t => t.UserID)
                .ForeignKey("dbo.UserRole", t => t.RoleID)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
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
            DropForeignKey("dbo.UserRoleR", "RoleID", "dbo.UserRole");
            DropForeignKey("dbo.UserRoleR", "UserID", "dbo.UserInfo");
            DropForeignKey("dbo.UserRoleUserInfo", "UserInfo_ID", "dbo.UserInfo");
            DropForeignKey("dbo.UserRoleUserInfo", "UserRole_ID", "dbo.UserRole");
            DropIndex("dbo.UserRoleUserInfo", new[] { "UserInfo_ID" });
            DropIndex("dbo.UserRoleUserInfo", new[] { "UserRole_ID" });
            DropIndex("dbo.UserRoleR", new[] { "RoleID" });
            DropIndex("dbo.UserRoleR", new[] { "UserID" });
            DropTable("dbo.UserRoleUserInfo");
            DropTable("dbo.UserRoleR");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserInfo");
        }
    }
}
