using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class MedicineReportUnitOfWork : IDisposable
    {
        private MedicineDbContext _context;
        private MedicineReportRepository _medicineReportRepository;
        public MedicineReportUnitOfWork(MedicineDbContext context)
        {
            _context = context;
            _medicineReportRepository = new MedicineReportRepository(_context);
        }

        public MedicineReportRepository MedicineReportRepository => _medicineReportRepository;

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
