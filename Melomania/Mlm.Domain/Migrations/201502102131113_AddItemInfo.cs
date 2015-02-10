namespace Mlm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musics", "Item_Information_Like_Count", c => c.Int(nullable: false));
            AddColumn("dbo.Musics", "Item_Information_Repost_Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musics", "Item_Information_Repost_Count");
            DropColumn("dbo.Musics", "Item_Information_Like_Count");
        }
    }
}
