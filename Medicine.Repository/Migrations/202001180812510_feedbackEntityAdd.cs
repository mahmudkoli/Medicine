namespace Medicine.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbackEntityAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportFeedbacks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MedicineReportId = c.String(nullable: false, maxLength: 128),
                        FeedbackMessage = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicineReports", t => t.MedicineReportId, cascadeDelete: true)
                .Index(t => t.MedicineReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportFeedbacks", "MedicineReportId", "dbo.MedicineReports");
            DropIndex("dbo.ReportFeedbacks", new[] { "MedicineReportId" });
            DropTable("dbo.ReportFeedbacks");
        }
    }
}
