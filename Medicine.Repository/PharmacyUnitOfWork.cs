using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class PharmacyUnitOfWork : IDisposable
    {
        private MedicineDbContext _context;
        private PharmacyRepository _pharmacyRepository;
        public PharmacyUnitOfWork(MedicineDbContext context)
        {
            _context = context;
            _pharmacyRepository = new PharmacyRepository(_context);
        }

        public PharmacyRepository PharmacyRepository => _pharmacyRepository;

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
