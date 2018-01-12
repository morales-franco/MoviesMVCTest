namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
