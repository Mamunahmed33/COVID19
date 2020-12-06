namespace CEN511_Covid19.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Symptoms", "PatientName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Symptoms", "PatientName");
        }
    }
}
