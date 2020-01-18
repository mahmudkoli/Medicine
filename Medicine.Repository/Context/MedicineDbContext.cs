using Medicine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository.Context
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext() : base("MedicineConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MedicineInfo> MedicineInfos { get; set; }
        public DbSet<MedicineReport> MedicineReports { get; set; }
        public DbSet<ReportFeedback> ReportFeedbacks { get; set; }
    }
}
