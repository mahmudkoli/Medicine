using Medicine.Common;
using Medicine.Entities;
using Medicine.Repository.Base;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class MedicineReportRepository : Repository<MedicineReport>
    {
        private MedicineDbContext _context;

        public MedicineReportRepository(MedicineDbContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatus(string id, EnumMedicineReportStatus status)
        {
            var entity = _context.MedicineReports.FirstOrDefault(x => x.Id == id);
            entity.Status = status;
            entity.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
