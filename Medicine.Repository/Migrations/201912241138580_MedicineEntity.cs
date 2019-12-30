namespace Medicine.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicineInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        MedicineType = c.String(),
                        MedicineSize = c.String(),
                        Details = c.String(),
                        ImageUrl = c.String(),
                        Status = c.Int(nullable: false),
                        CompanyId = c.String(nullable: false, maxLength: 128),
                        ContributorId = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ContributorId)
                .Index(t => t.CompanyId)
                .Index(t => t.ContributorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineInfoes", "ContributorId", "dbo.Users");
            DropForeignKey("dbo.MedicineInfoes", "CompanyId", "dbo.Companies");
            DropIndex("dbo.MedicineInfoes", new[] { "ContributorId" });
            DropIndex("dbo.MedicineInfoes", new[] { "CompanyId" });
            DropTable("dbo.MedicineInfoes");
            DropTable("dbo.Companies");
        }
    }
}
