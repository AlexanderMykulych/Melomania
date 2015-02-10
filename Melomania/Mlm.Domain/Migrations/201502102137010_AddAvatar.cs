namespace Mlm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Avatar_Picture", c => c.Binary());
            AddColumn("dbo.Users", "Avatar_MimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Avatar_MimeType");
            DropColumn("dbo.Users", "Avatar_Picture");
        }
    }
}
