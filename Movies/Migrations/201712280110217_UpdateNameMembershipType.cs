namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NAME = 'Pay as You Go' WHERE MembershipTypeID = 0");
            Sql("UPDATE MembershipTypes SET NAME = 'Montly' WHERE MembershipTypeID = 1");
            Sql("UPDATE MembershipTypes SET NAME = 'Weekly' WHERE MembershipTypeID = 2");
            Sql("UPDATE MembershipTypes SET NAME = 'Daily' WHERE MembershipTypeID = 3");
            
        }
        
        public override void Down()
        {
        }
    }
}
