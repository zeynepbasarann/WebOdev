namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sepetTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sepets", "Uye_uyeID", "dbo.Uyes");
            DropIndex("dbo.Sepets", new[] { "Uye_uyeID" });
            RenameColumn(table: "dbo.Sepets", name: "Uye_uyeID", newName: "uyeID");
            AlterColumn("dbo.Sepets", "uyeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sepets", "uyeID");
            AddForeignKey("dbo.Sepets", "uyeID", "dbo.Uyes", "uyeID", cascadeDelete: true);
            DropColumn("dbo.Sepets", "uyrID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sepets", "uyrID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sepets", "uyeID", "dbo.Uyes");
            DropIndex("dbo.Sepets", new[] { "uyeID" });
            AlterColumn("dbo.Sepets", "uyeID", c => c.Int());
            RenameColumn(table: "dbo.Sepets", name: "uyeID", newName: "Uye_uyeID");
            CreateIndex("dbo.Sepets", "Uye_uyeID");
            AddForeignKey("dbo.Sepets", "Uye_uyeID", "dbo.Uyes", "uyeID");
        }
    }
}
