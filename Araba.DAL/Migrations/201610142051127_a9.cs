namespace Araba.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotograflar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Yol = c.String(nullable: false),
                        ArabamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arabalar", t => t.ArabamID, cascadeDelete: true)
                .Index(t => t.ArabamID);
            
            CreateTable(
                "dbo.Modeller",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Yıl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Renkler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vitesler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Arabalar", "Kilometre", c => c.String());
            AddColumn("dbo.Arabalar", "ModellerID", c => c.Int(nullable: false));
            AddColumn("dbo.Arabalar", "ViteslerID", c => c.Int(nullable: false));
            AddColumn("dbo.Arabalar", "RenklerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Durumlar", "Ad", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Markalar", "Ad", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.YakitTurleri", "Ad", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.Arabalar", "ModellerID");
            CreateIndex("dbo.Arabalar", "ViteslerID");
            CreateIndex("dbo.Arabalar", "RenklerID");
            AddForeignKey("dbo.Arabalar", "ModellerID", "dbo.Modeller", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Arabalar", "RenklerID", "dbo.Renkler", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Arabalar", "ViteslerID", "dbo.Vitesler", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arabalar", "ViteslerID", "dbo.Vitesler");
            DropForeignKey("dbo.Arabalar", "RenklerID", "dbo.Renkler");
            DropForeignKey("dbo.Arabalar", "ModellerID", "dbo.Modeller");
            DropForeignKey("dbo.Fotograflar", "ArabamID", "dbo.Arabalar");
            DropIndex("dbo.Fotograflar", new[] { "ArabamID" });
            DropIndex("dbo.Arabalar", new[] { "RenklerID" });
            DropIndex("dbo.Arabalar", new[] { "ViteslerID" });
            DropIndex("dbo.Arabalar", new[] { "ModellerID" });
            AlterColumn("dbo.YakitTurleri", "Ad", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Markalar", "Ad", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Durumlar", "Ad", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Arabalar", "RenklerID");
            DropColumn("dbo.Arabalar", "ViteslerID");
            DropColumn("dbo.Arabalar", "ModellerID");
            DropColumn("dbo.Arabalar", "Kilometre");
            DropTable("dbo.Vitesler");
            DropTable("dbo.Renkler");
            DropTable("dbo.Modeller");
            DropTable("dbo.Fotograflar");
        }
    }
}
