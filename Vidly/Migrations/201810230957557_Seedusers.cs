namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
VALUES (N'48abc85a-7e2c-479b-907c-2fa854f470e9', N'guest@vidly.com', 0, N'AGfsOHD3E8FUA8IdJytzgVXWQXNo4cFrHfHnPiajtI4Q/M5VSVRJPde9f7OoR8WWAA==', N'abb1fa06-4bfe-404c-be5b-be8b0fb0362a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
VALUES (N'c2b62a0a-e500-4e99-9df5-59e04dfd1cca', N'admin@vidly.com', 0, N'ADnaya8wxp7UN9FPynd2qBf4nGLyMPnvzVOGSZ2kCW6ArTATGgQ0sRLTDOxg4v7QFA==', N'de9c54b7-e3f1-4d7f-8717-20654d69667e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
               ");
      Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) 
       VALUES (N'68ee4607-38b9-4f58-84cc-a14dd9d75b72', N'CanManageMovies')
            ");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2b62a0a-e500-4e99-9df5-59e04dfd1cca', N'68ee4607-38b9-4f58-84cc-a14dd9d75b72')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
