namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoriKistAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriLists",
                c => new
                    {
                        favoriListID = c.Int(nullable: false, identity: true),
                        uyrID = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        TopListeUcret = c.Int(nullable: false),
                        Uye_uyeID = c.Int(),
                    })
                .PrimaryKey(t => t.favoriListID)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .ForeignKey("dbo.Uyes", t => t.Uye_uyeID)
                .Index(t => t.UrunId)
                .Index(t => t.Uye_uyeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriLists", "Uye_uyeID", "dbo.Uyes");
            DropForeignKey("dbo.FavoriLists", "UrunId", "dbo.Uruns");
            DropIndex("dbo.FavoriLists", new[] { "Uye_uyeID" });
            DropIndex("dbo.FavoriLists", new[] { "UrunId" });
            DropTable("dbo.FavoriLists");
        }
    }
}
