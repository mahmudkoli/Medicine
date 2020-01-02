namespace Medicine.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineInfoes", "ReportCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.MedicineInfoes", "ReportCount");
        }
    }
}
