namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameMembershipTypeFree : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NAME = 'Free' WHERE MembershipTypeID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
