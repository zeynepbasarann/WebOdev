namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urunyeni : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uruns", "kategoriID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uruns", "kategoriID");
        }
    }
}
