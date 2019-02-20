namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            Sql("alter table Customers ADD Gender nvarchar(10)");
        }
        
        public override void Down()
        {
            
        }
    }
}
