namespace Medicine.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicineReports",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ComplainantId = c.String(nullable: false, maxLength: 128),
                        PharmacyId = c.String(nullable: false, maxLength: 128),
                        MedicineInfoId = c.String(nullable: false, maxLength: 128),
                        AskingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        DocumentUrl = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ComplainantId, cascadeDelete: false)
                .ForeignKey("dbo.MedicineInfoes", t => t.MedicineInfoId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.PharmacyId, cascadeDelete: false)
                .Index(t => t.ComplainantId)
                .Index(t => t.PharmacyId)
                .Index(t => t.MedicineInfoId);
            
            AddColumn("dbo.Users", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineReports", "PharmacyId", "dbo.Users");
            DropForeignKey("dbo.MedicineReports", "MedicineInfoId", "dbo.MedicineInfoes");
            DropForeignKey("dbo.MedicineReports", "ComplainantId", "dbo.Users");
            DropIndex("dbo.MedicineReports", new[] { "MedicineInfoId" });
            DropIndex("dbo.MedicineReports", new[] { "PharmacyId" });
            DropIndex("dbo.MedicineReports", new[] { "ComplainantId" });
            DropColumn("dbo.Users", "ImageUrl");
            DropTable("dbo.MedicineReports");
        }
    }
}
