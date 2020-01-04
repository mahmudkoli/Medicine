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
        private PharmacyUnitOfWork _pharmacyUnitOfWork;
        public PharmacyService()
        {
            _pharmacyUnitOfWork = new PharmacyUnitOfWork(new MedicineDbContext());
        }

        public IEnumerable<User> GetAll()
        {
            return _pharmacyUnitOfWork.PharmacyRepository.GetAll().Where(x => x.UserRole == Role.Pharmacy);
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
                    UserRole = Role.Pharmacy
                };
                _pharmacyUnitOfWork.PharmacyRepository.Add(newEntity);

                _pharmacyUnitOfWork.Save();

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
