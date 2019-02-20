namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Customers ON");


            Sql("INSERT INTO Customers (Id,Name,Gender,IsSubscribedTonewsLetter,MemberShipTypeId) VALUES (5,'Rose','Female',False,1)");
            Sql("INSERT INTO Customers (Id,Name,Gender,IsSubscribedTonewsLetter,MemberShipTypeId) VALUES (6,'Marry','Female',False,4)");
            Sql("INSERT INTO Customers (Id,Name,Gender,IsSubscribedTonewsLetter,MemberShipTypeId) VALUES (7,'Harry','Male',False,3)");

         

        }

        public override void Down()
        {
        }
    }
}
