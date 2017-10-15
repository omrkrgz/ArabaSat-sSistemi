namespace Araba.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Durums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Arabalar", "DurumlarID", c => c.Int(nullable: false));
            CreateIndex("dbo.Arabalar", "DurumlarID");
            AddForeignKey("dbo.Arabalar", "DurumlarID", "dbo.Durums", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arabalar", "DurumlarID", "dbo.Durums");
            DropIndex("dbo.Arabalar", new[] { "DurumlarID" });
            DropColumn("dbo.Arabalar", "DurumlarID");
            DropTable("dbo.Durums");
        }
    }
}
