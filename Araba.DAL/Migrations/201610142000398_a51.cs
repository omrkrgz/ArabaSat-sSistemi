namespace Araba.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a51 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Durums", newName: "Durumlar");
            RenameTable(name: "dbo.Markas", newName: "Markalar");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Markalar", newName: "Markas");
            RenameTable(name: "dbo.Durumlar", newName: "Durums");
        }
    }
}
