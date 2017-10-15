namespace Araba.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Markas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Arabalar", "KullaniciID", c => c.String(maxLength: 128));
            AddColumn("dbo.Arabalar", "MarkaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Arabalar", "KullaniciID");
            CreateIndex("dbo.Arabalar", "MarkaID");
            AddForeignKey("dbo.Arabalar", "MarkaID", "dbo.Markas", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Arabalar", "KullaniciID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arabalar", "KullaniciID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arabalar", "MarkaID", "dbo.Markas");
            DropIndex("dbo.Arabalar", new[] { "MarkaID" });
            DropIndex("dbo.Arabalar", new[] { "KullaniciID" });
            DropColumn("dbo.Arabalar", "MarkaID");
            DropColumn("dbo.Arabalar", "KullaniciID");
            DropTable("dbo.Markas");
        }
    }
}
