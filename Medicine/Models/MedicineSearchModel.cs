using Medicine.Common;
using Medicine.Entities;
using Medicine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Web.Models
{
    public class MedicineSearchModel
    {
        public string SMedicineName { get; set; }
        public string SMedicineType { get; set; }
        public string SMedicineSize { get; set; }

        private MedicineService _medicineService;

        public IEnumerable<string> MedicineTypes { get; set; }
        public IEnumerable<string> MedicineSizes { get; set; }
        public IEnumerable<MedicineInfo> Medicines { get; set; }

        public MedicineSearchModel()
        {
            _medicineService = new MedicineService();
            this.MedicineTypes = DefaultValue.MedicineTypes;
            this.MedicineSizes = DefaultValue.MedicineSizes;
        }

        public MedicineSearchModel(string medicineName, string medicineSize, string medicineType) : this()
        {
            this.Medicines = _medicineService.GetAll(medicineName, medicineSize, medicineType);
        }
    }
}
