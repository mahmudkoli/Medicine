namespace Medicine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(),
                        BloodGroup = c.String(),
                        DateOfBirth = c.DateTime(),
                        District = c.String(),
                        Weight = c.Single(),
                        Address = c.String(),
                        Gender = c.String(),
                        ImageUrl = c.String(),
                        RoleName = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
