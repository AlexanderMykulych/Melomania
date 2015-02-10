namespace Mlm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMusic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Track = c.Binary(),
                        Information_Name = c.String(),
                        Information_Autor = c.String(),
                        Information_Album = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Information_Name", c => c.String());
            AddColumn("dbo.Users", "Information_Surname", c => c.String());
            AddColumn("dbo.Users", "Information_Address", c => c.String());
            AddColumn("dbo.Users", "Information_About", c => c.String());
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "About");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "About", c => c.String());
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "Information_About");
            DropColumn("dbo.Users", "Information_Address");
            DropColumn("dbo.Users", "Information_Surname");
            DropColumn("dbo.Users", "Information_Name");
            DropTable("dbo.Musics");
        }
    }
}
