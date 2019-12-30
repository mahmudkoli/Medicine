using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class MedicineUnitOfWork : IDisposable
    {
        private MedicineDbContext _context;
        private MedicineRepository _medicineRepository;
        public MedicineUnitOfWork(MedicineDbContext context)
        {
            _context = context;
            _medicineRepository = new MedicineRepository(_context);
        }

        public MedicineRepository MedicineRepository => _medicineRepository;

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
