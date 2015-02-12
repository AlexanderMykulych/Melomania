namespace Mlm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_Confident_Id", "dbo.Confidents");
            DropIndex("dbo.Users", new[] { "User_Confident_Id" });
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "User_Confident_Id");
            DropTable("dbo.Confidents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Confidents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "User_Confident_Id", c => c.Guid());
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Login");
            CreateIndex("dbo.Users", "User_Confident_Id");
            AddForeignKey("dbo.Users", "User_Confident_Id", "dbo.Confidents", "Id");
        }
    }
}
