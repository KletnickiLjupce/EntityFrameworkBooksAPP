namespace EntityFrameworkBooksAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCounttoBookModl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Count", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Count");
        }
    }
}
