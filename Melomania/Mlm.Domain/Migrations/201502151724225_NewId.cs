namespace Mlm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Track = c.Binary(),
                        MimeType = c.String(),
                        Information_Name = c.String(),
                        Information_Autor = c.String(),
                        Information_Album = c.String(),
                        Item_Information_Like_Count = c.Int(nullable: false),
                        Item_Information_Repost_Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Avatar_Picture = c.Binary(),
                        Avatar_MimeType = c.String(),
                        Information_Name = c.String(),
                        Information_Surname = c.String(),
                        Information_Address = c.String(),
                        Information_About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMusics",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Music_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Music_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Musics", t => t.Music_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Music_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMusics", "Music_Id", "dbo.Musics");
            DropForeignKey("dbo.UserMusics", "User_Id", "dbo.Users");
            DropIndex("dbo.UserMusics", new[] { "Music_Id" });
            DropIndex("dbo.UserMusics", new[] { "User_Id" });
            DropTable("dbo.UserMusics");
            DropTable("dbo.Users");
            DropTable("dbo.Musics");
        }
    }
}
