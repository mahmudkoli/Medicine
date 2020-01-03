using Medicine.Common;
using Medicine.Entities;
using Medicine.Repository;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Services
{
    public class PharmacyService
    {
        private PharmacyUnitOfWork _companyUnitOfWork;
        public PharmacyService()
        {
            _companyUnitOfWork = new PharmacyUnitOfWork(new MedicineDbContext());
        }

        public IEnumerable<User> GetAll()
        {
            return _companyUnitOfWork.PharmacyRepository.GetAll().Where(x => x.UserRole == Role.Pharmacy);
        }
    }
}
