namespace Medicine.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityUpdatess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineReports", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineReports", "Status");
        }
    }
}
