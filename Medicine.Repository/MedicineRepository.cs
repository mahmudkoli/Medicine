using Medicine.Common;
using Medicine.Entities;
using Medicine.Repository.Base;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class MedicineRepository : Repository<MedicineInfo>
    {
        private MedicineDbContext _context;

        public MedicineRepository(MedicineDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<MedicineInfo> GetAll(string medicineName, string medicineSize, string medicineType)
        {
            return _context.MedicineInfos.Where(c => !c.IsDeleted && 
            (string.IsNullOrEmpty(medicineName) || c.Name.Contains(medicineName)) && 
            (string.IsNullOrEmpty(medicineSize) || c.MedicineSize.ToLower() == medicineSize.ToLower()) && 
            (string.IsNullOrEmpty(medicineType) || c.MedicineType.ToLower() == medicineType.ToLower())).OrderByDescending(x => x.CreatedAt);
        }

        public void ChangeStatus(string id, EnumMedicineStatus status)
        {
            var entity = _context.MedicineInfos.FirstOrDefault(x => x.Id == id);
            entity.Status = status;
            entity.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
