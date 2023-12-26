namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSepetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sepets",
                c => new
                    {
                        sepetID = c.Int(nullable: false, identity: true),
                        uyrID = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        TopUcret = c.Int(nullable: false),
                        Uye_uyeID = c.Int(),
                    })
                .PrimaryKey(t => t.sepetID)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .ForeignKey("dbo.Uyes", t => t.Uye_uyeID)
                .Index(t => t.UrunId)
                .Index(t => t.Uye_uyeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sepets", "Uye_uyeID", "dbo.Uyes");
            DropForeignKey("dbo.Sepets", "UrunId", "dbo.Uruns");
            DropIndex("dbo.Sepets", new[] { "Uye_uyeID" });
            DropIndex("dbo.Sepets", new[] { "UrunId" });
            DropTable("dbo.Sepets");
        }
    }
}
