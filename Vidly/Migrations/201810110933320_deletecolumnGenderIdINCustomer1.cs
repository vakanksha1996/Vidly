namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecolumnGenderIdINCustomer1 : DbMigration
    {
        public override void Up()
        {
            Sql("alter table Customers drop column Gender");


        }
        
        public override void Down()
        {
        }
    }
}
