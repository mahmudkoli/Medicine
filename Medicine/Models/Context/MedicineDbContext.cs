using Medicine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Models.Context
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext() : base("MedicineConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
