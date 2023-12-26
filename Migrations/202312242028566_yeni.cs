namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        egitimAd = c.String(),
                        turID = c.Int(nullable: false),
                        yazarID = c.Int(nullable: false),
                        dilID = c.Int(nullable: false),
                        yorumID = c.Int(nullable: false),
                        Resim = c.String(),
                        ucret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Dils", t => t.dilID, cascadeDelete: true)
                .ForeignKey("dbo.Turs", t => t.turID, cascadeDelete: true)
                .ForeignKey("dbo.Yazars", t => t.yazarID, cascadeDelete: true)
                .Index(t => t.turID)
                .Index(t => t.yazarID)
                .Index(t => t.dilID);
            
            
        }
        
        public override void Down()
        {
            
            
            DropForeignKey("dbo.Uruns", "yazarID", "dbo.Yazars");
            DropForeignKey("dbo.Uruns", "turID", "dbo.Turs");
            DropForeignKey("dbo.Uruns", "dilID", "dbo.Dils");
            DropIndex("dbo.Uruns", new[] { "dilID" });
            DropIndex("dbo.Uruns", new[] { "yazarID" });
            DropIndex("dbo.Uruns", new[] { "turID" });
            DropTable("dbo.Uruns");
            
        }
    }
}
