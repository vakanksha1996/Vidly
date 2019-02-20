namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='02/02/1996' where Id=2");
            Sql("UPDATE Customers SET Birthdate='02/05/1999' where Id=3");
            Sql("UPDATE Customers SET Birthdate='12/02/1998' where Id=4");

        }

        public override void Down()
        {
        }
    }
}
