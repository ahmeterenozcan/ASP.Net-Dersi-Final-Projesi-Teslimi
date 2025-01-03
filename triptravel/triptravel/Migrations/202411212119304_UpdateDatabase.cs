namespace triptravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
          //  AddColumn("dbo.Blogs", "VideoUrl", c => c.String());
        }
        
        public override void Down()
        {
           // DropColumn("dbo.Blogs", "VideoUrl");
        }
    }
}
