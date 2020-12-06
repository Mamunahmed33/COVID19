namespace CEN511_Covid19.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Symptoms", "PatientName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Symptoms", "PatientName", c => c.Boolean(nullable: false));
        }
    }
}
