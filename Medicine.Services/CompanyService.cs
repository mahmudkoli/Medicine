﻿using Medicine.Common;
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
    public class CompanyService
    {
        private CompanyUnitOfWork _companyUnitOfWork;
        public CompanyService()
        {
            _companyUnitOfWork = new CompanyUnitOfWork(new MedicineDbContext());
        }

        public IEnumerable<User> GetAll()
        {
            return _companyUnitOfWork.ComapanyRepository.GetAll().Where(x => x.UserRole == Role.Company);
        }
    }
}
