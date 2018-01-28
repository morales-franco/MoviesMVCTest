namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3c5c5f53-df22-44c2-ab16-460d65eb3fce', N'admin@test.com', 0, N'AOdJloYvN1snvf5LKXMzJ6QT+xOaZacyWio+7ks02BRFDQJqeX5gIZRkJN/ZiOBWUQ==', N'7afafc50-b35a-4cd6-bb3c-eadc00ac5620', NULL, 0, 0, NULL, 1, 0, N'admin@test.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7a651115-d1bf-4756-81ac-4fbc60cd6b75', N'CanManagerMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3c5c5f53-df22-44c2-ab16-460d65eb3fce', N'7a651115-d1bf-4756-81ac-4fbc60cd6b75')");
        }

        public override void Down()
        {
        }
    }
}
