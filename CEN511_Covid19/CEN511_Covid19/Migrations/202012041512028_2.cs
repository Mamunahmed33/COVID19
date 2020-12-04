namespace CEN511_Covid19.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "HealthStatus_HealthStatusID", "dbo.HealthStatus");
            DropIndex("dbo.AspNetUsers", new[] { "HealthStatus_HealthStatusID" });
            AddColumn("dbo.HealthStatus", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.HealthStatus", "User_Id");
            AddForeignKey("dbo.HealthStatus", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "HealthStatus_HealthStatusID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "HealthStatus_HealthStatusID", c => c.Int());
            DropForeignKey("dbo.HealthStatus", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.HealthStatus", new[] { "User_Id" });
            DropColumn("dbo.HealthStatus", "User_Id");
            CreateIndex("dbo.AspNetUsers", "HealthStatus_HealthStatusID");
            AddForeignKey("dbo.AspNetUsers", "HealthStatus_HealthStatusID", "dbo.HealthStatus", "HealthStatusID");
        }
    }
}
