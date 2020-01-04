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

        public string Add(User entity)
        {
            try
            {
                var newEntity = new User()
                {
                    Name = entity.Name,
                    Email = entity.Email,
                    Phone = entity.Phone,
                    Address = entity.Address,
                    Password = CustomCrypto.Hash(DefaultValue.UserPassword),
                    IsEmailVerified = true,
                    ActivationCode = Guid.NewGuid(),
                    UserRole = Role.Company
                };
                _companyUnitOfWork.ComapanyRepository.Add(newEntity);

                _companyUnitOfWork.Save();

                return newEntity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }
    }
}
