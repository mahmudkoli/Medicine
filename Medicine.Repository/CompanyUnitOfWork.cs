using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class CompanyUnitOfWork : IDisposable
    {
        private MedicineDbContext _context;
        private CompanyRepository _companyRepository;
        public CompanyUnitOfWork(MedicineDbContext context)
        {
            _context = context;
            _companyRepository = new CompanyRepository(_context);
        }

        public CompanyRepository ComapnyRepository => _companyRepository;

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
