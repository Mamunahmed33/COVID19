namespace CEN511_Covid19.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Symptoms", "Indigestion", c => c.Boolean(nullable: false));
            DropColumn("dbo.Symptoms", "Ingigestion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Symptoms", "Ingigestion", c => c.Boolean(nullable: false));
            DropColumn("dbo.Symptoms", "Indigestion");
        }
    }
}
