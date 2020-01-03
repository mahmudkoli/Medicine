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

            // user
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

            // comapny
            context.Users.AddOrUpdate(x => x.Email,
                new User()
                {
                    Name = "Square Limited",
                    Email = "square@gmail.com",
                    Address = "Dhaka",
                    Password = CustomCrypto.Hash(DefaultValue.UserPassword),
                    IsEmailVerified = true,
                    UserRole = Role.Company
                },
                new User()
                {
                    Name = "Beximco Limited",
                    Email = "beximco@gmail.com",
                    Address = "Dhaka",
                    Password = CustomCrypto.Hash(DefaultValue.UserPassword),
                    IsEmailVerified = true,
                    UserRole = Role.Company
                },
                new User()
                {
                    Name = "Pharmaceutical Limited",
                    Email = "pharma@gmail.com",
                    Address = "Dhaka",
                    Password = CustomCrypto.Hash(DefaultValue.UserPassword),
                    IsEmailVerified = true,
                    UserRole = Role.Company
                }
                );

            // pharmacy
            context.Users.AddOrUpdate(x => x.Email,
                new User()
                {
                    Name = "Ronoda Pharmacy",
                    Email = "ronoda@gmail.com",
                    Address = "Dhaka",
                    Password = CustomCrypto.Hash(DefaultValue.UserPassword),
                    IsEmailVerified = true,
                    UserRole = Role.Pharmacy
                }
                );
        }
    }
}
