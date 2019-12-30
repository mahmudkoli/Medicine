using Medicine.Entities;
using Medicine.Common;
using Medicine.Repository;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Services
{
    public class MedicineService
    {
        private MedicineUnitOfWork _medicineUnitOfWork;
        public MedicineService()
        {
            _medicineUnitOfWork = new MedicineUnitOfWork(new MedicineDbContext());
        }

        public string AddByAdmin(MedicineInfo entity)
        {
            try
            {
                var newEntity = new MedicineInfo()
                {
                    Name = entity.Name,
                    MedicineType = entity.MedicineType,
                    MedicineSize = entity.MedicineSize,
                    Details = entity.Details,
                    ImageUrl = entity.ImageUrl,
                    CompanyId = entity.CompanyId,
                    ContributorId = entity.ContributorId,
                    TotalPrice = entity.TotalPrice,
                    UnitPrice = entity.UnitPrice,
                    Status = EnumMedicineStatus.Approved
                };

                _medicineUnitOfWork.MedicineRepository.Add(newEntity);
                _medicineUnitOfWork.Save();

                return newEntity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }

        public IEnumerable<MedicineInfo> GetAll()
        {
            return _medicineUnitOfWork.MedicineRepository.GetAll();
        }

        public IEnumerable<MedicineInfo> GetAllPending()
        {
            return _medicineUnitOfWork.MedicineRepository.GetAll().Where(x => x.Status == EnumMedicineStatus.Pending);
        }

        public MedicineInfo GetById(string id)
        {
            return _medicineUnitOfWork.MedicineRepository.GetById(id);
        }

        public string Update(MedicineInfo entity)
        {
            try
            {
                var existsEntity = _medicineUnitOfWork.MedicineRepository.GetById(entity.Id);

                existsEntity.Name = entity.Name;
                existsEntity.MedicineType = entity.MedicineType;
                existsEntity.MedicineSize = entity.MedicineSize;
                existsEntity.Details = entity.Details;
                existsEntity.ImageUrl = String.IsNullOrEmpty(entity.ImageUrl) ? existsEntity.ImageUrl : entity.ImageUrl;
                existsEntity.CompanyId = entity.CompanyId;
                existsEntity.TotalPrice = entity.TotalPrice;
                existsEntity.UnitPrice = entity.UnitPrice;
                existsEntity.UpdatedAt = DateTime.Now;

                _medicineUnitOfWork.MedicineRepository.Update(existsEntity);
                _medicineUnitOfWork.Save();

                return existsEntity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }
    }
}
