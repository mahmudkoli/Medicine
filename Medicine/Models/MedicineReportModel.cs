using Medicine.Common;
using Medicine.Entities;
using Medicine.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Medicine.Web.Models
{
    public class MedicineReportModel : MedicineReport
    {
        private MedicineService _medicineService;
        private MedicineReportService _medicineReportService;
        private PharmacyService _pharmacyServiceService;


        [Display(Name = "File")]
        public HttpPostedFileBase DocumentFileBase { get; set; }
        public IEnumerable<User> Pharmacies { get; set; }

        public MedicineReportModel()
        {
            _medicineService = new MedicineService();
            _medicineReportService = new MedicineReportService();
            _pharmacyServiceService = new PharmacyService();
        }

        public string Add()
        {
            this.DocumentUrl = CustomFile.SaveDocumentFile(this.DocumentFileBase, "MedicineReport", this.Id, "MedicineReport");
            this.ComplainantId = AuthenticatedUserModel.GetUserFromIdentity().Id;
            var  newId = _medicineReportService.Add(this);
            _medicineService.MedicineReportInc(this.MedicineInfoId);
            return newId;
        }

        public MedicineInfo GetMedicineInfo(string id)
        {
            return _medicineService.GetById(id);
        }

        public IEnumerable<User> GetAllPharmacies()
        {
            return _pharmacyServiceService.GetAll();
        }
    }
}
