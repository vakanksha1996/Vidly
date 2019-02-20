namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnametoMemberShipType : DbMigration
    {
        public override void Up()
        {
           
            AddColumn("dbo.MemberShipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "Name", c => c.String(nullable: false));

        }
    }
}
