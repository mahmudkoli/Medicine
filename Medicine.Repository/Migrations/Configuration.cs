namespace Medicine.Repository.Migrations
{
    using Medicine.Common;
    using Medicine.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Medicine.Repository.Context.MedicineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Medicine.Repository.Context.MedicineDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Email,
                new User()
                {
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = CustomCrypto.Hash(DefaultValue.UserPassword),
                    IsEmailVerified = true,
                    UserRole = Role.Admin
                }
                );

            context.Companies.AddOrUpdate(x => x.Name,
                new Company() { Name = "Square Limited" },
                new Company() { Name = "Beximco Limited" },
                new Company() { Name = "Pharmaceutical Limited" });
        }
    }
}
