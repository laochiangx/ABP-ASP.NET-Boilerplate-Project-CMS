namespace JCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JCMS : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "ABP.AuditLogs", newSchema: "dbo");
            MoveTable(name: "ABP.BackgroundJobs", newSchema: "dbo");
            MoveTable(name: "ABP.Features", newSchema: "dbo");
            MoveTable(name: "ABP.Editions", newSchema: "dbo");
            MoveTable(name: "ABP.Languages", newSchema: "dbo");
            MoveTable(name: "ABP.LanguageTexts", newSchema: "dbo");
            MoveTable(name: "ABP.Notifications", newSchema: "dbo");
            MoveTable(name: "ABP.NotificationSubscriptions", newSchema: "dbo");
            MoveTable(name: "ABP.OrganizationUnits", newSchema: "dbo");
            MoveTable(name: "ABP.Permissions", newSchema: "dbo");
            MoveTable(name: "ABP.Roles", newSchema: "dbo");
            MoveTable(name: "ABP.Users", newSchema: "dbo");
            MoveTable(name: "ABP.UserClaims", newSchema: "dbo");
            MoveTable(name: "ABP.UserLogins", newSchema: "dbo");
            MoveTable(name: "ABP.UserRoles", newSchema: "dbo");
            MoveTable(name: "ABP.Settings", newSchema: "dbo");
            MoveTable(name: "ABP.TenantNotifications", newSchema: "dbo");
            MoveTable(name: "ABP.Tenants", newSchema: "dbo");
            MoveTable(name: "ABP.UserAccounts", newSchema: "dbo");
            MoveTable(name: "ABP.UserLoginAttempts", newSchema: "dbo");
            MoveTable(name: "ABP.UserNotifications", newSchema: "dbo");
            MoveTable(name: "ABP.UserOrganizationUnits", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.UserOrganizationUnits", newSchema: "ABP");
            MoveTable(name: "dbo.UserNotifications", newSchema: "ABP");
            MoveTable(name: "dbo.UserLoginAttempts", newSchema: "ABP");
            MoveTable(name: "dbo.UserAccounts", newSchema: "ABP");
            MoveTable(name: "dbo.Tenants", newSchema: "ABP");
            MoveTable(name: "dbo.TenantNotifications", newSchema: "ABP");
            MoveTable(name: "dbo.Settings", newSchema: "ABP");
            MoveTable(name: "dbo.UserRoles", newSchema: "ABP");
            MoveTable(name: "dbo.UserLogins", newSchema: "ABP");
            MoveTable(name: "dbo.UserClaims", newSchema: "ABP");
            MoveTable(name: "dbo.Users", newSchema: "ABP");
            MoveTable(name: "dbo.Roles", newSchema: "ABP");
            MoveTable(name: "dbo.Permissions", newSchema: "ABP");
            MoveTable(name: "dbo.OrganizationUnits", newSchema: "ABP");
            MoveTable(name: "dbo.NotificationSubscriptions", newSchema: "ABP");
            MoveTable(name: "dbo.Notifications", newSchema: "ABP");
            MoveTable(name: "dbo.LanguageTexts", newSchema: "ABP");
            MoveTable(name: "dbo.Languages", newSchema: "ABP");
            MoveTable(name: "dbo.Editions", newSchema: "ABP");
            MoveTable(name: "dbo.Features", newSchema: "ABP");
            MoveTable(name: "dbo.BackgroundJobs", newSchema: "ABP");
            MoveTable(name: "dbo.AuditLogs", newSchema: "ABP");
        }
    }
}
