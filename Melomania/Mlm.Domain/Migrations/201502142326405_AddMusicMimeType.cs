namespace Mlm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMusicMimeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musics", "MimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musics", "MimeType");
        }
    }
}
