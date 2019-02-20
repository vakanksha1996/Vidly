namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewmigration : DbMigration
    {
        public override void Up()
        {
            Sql("update Movies set NumberAvailable=0 where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
