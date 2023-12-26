namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeniTablolar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CokSatans",
                c => new
                    {
                        cokSatanID = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cokSatanID)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.Yenis",
                c => new
                    {
                        yeniID = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.yeniID)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yenis", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.CokSatans", "UrunId", "dbo.Uruns");
            DropIndex("dbo.Yenis", new[] { "UrunId" });
            DropIndex("dbo.CokSatans", new[] { "UrunId" });
            DropTable("dbo.Yenis");
            DropTable("dbo.CokSatans");
        }
    }
}
