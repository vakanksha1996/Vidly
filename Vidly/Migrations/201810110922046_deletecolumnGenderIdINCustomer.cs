namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecolumnGenderIdINCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER table Customers DROP column Gender");
        }
        
        public override void Down()
        {
        }
    }
}
