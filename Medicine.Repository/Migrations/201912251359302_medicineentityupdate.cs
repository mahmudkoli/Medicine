namespace Medicine.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medicineentityupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineInfoes", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MedicineInfoes", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineInfoes", "UnitPrice");
            DropColumn("dbo.MedicineInfoes", "TotalPrice");
        }
    }
}
