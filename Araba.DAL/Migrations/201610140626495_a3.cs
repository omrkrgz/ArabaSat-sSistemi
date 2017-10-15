namespace Araba.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Arabalar", name: "MarkaID", newName: "MarkalarID");
            RenameIndex(table: "dbo.Arabalar", name: "IX_MarkaID", newName: "IX_MarkalarID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Arabalar", name: "IX_MarkalarID", newName: "IX_MarkaID");
            RenameColumn(table: "dbo.Arabalar", name: "MarkalarID", newName: "MarkaID");
        }
    }
}
