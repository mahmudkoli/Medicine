using Medicine.Common;
using Medicine.Entities;
using Medicine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Web.Areas.Admin.Model
{
    public class CompanyPharmacyModel : User
    {
        private PharmacyService _pharmacyService;
        private CompanyService _companyService;

        public CompanyPharmacyModel()
        {
            _pharmacyService = new PharmacyService();
            _companyService = new CompanyService();
        }

        public string Add()
        {
            if (this.UserRole == Role.Company)
                return _companyService.Add(this);
            else if (this.UserRole == Role.Pharmacy)
                return _pharmacyService.Add(this);
            else return string.Empty;
        }

        public IEnumerable<User> GetAllCompany()
        {
            return _companyService.GetAll();
        }

        public IEnumerable<User> GetAllPharmacy()
        {
            return _pharmacyService.GetAll();
        }
    }
}
