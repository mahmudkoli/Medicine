using Medicine.Common;
using Medicine.Entities;
using Medicine.Services;
using Medicine.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Web.Areas.Admin.Model
{
    public class MedicineReportModel : MedicineReport
    {

        private MedicineReportService _medicineReportService;
        //private MedicineService _medicineService;
        //private CompanyService _companyService;

        public MedicineReportModel()
        {
            _medicineReportService = new MedicineReportService();
            //_medicineService = new MedicineService();
            //_companyService = new CompanyService();
        }

        public MedicineReportModel(string id) : this()
        {
            var existingEntity = _medicineReportService.GetById(id);
            if (existingEntity != null)
            {
                this.Id = existingEntity.Id;
                this.ComplainantId = existingEntity.ComplainantId;
                this.Complainant = existingEntity.Complainant;
                this.MedicineInfoId = existingEntity.MedicineInfoId;
                this.MedicineInfo = existingEntity.MedicineInfo;
                this.PharmacyId = existingEntity.PharmacyId;
                this.Pharmacy = existingEntity.Pharmacy;
                this.AskingPrice = existingEntity.AskingPrice;
                this.Comment = existingEntity.Comment;
                this.Status = existingEntity.Status;
                this.DocumentUrl = existingEntity.DocumentUrl;
            }
        }

        public IEnumerable<MedicineReport> GetAllForPharmacy()
        {
            return _medicineReportService.GetAllForPharmacy(AuthenticatedUserModel.GetUserFromIdentity().Id);
        }

        public IEnumerable<MedicineReport> GetAllForCompany()
        {
            return _medicineReportService.GetAllForCompany(AuthenticatedUserModel.GetUserFromIdentity().Id);
        }

        public IEnumerable<MedicineReport> GetAllPendingForPharmacy()
        {
            return _medicineReportService.GetAllPendingForPharmacy(AuthenticatedUserModel.GetUserFromIdentity().Id);
        }

        public IEnumerable<MedicineReport> GetAllPendingForCompany()
        {
            return _medicineReportService.GetAllPendingForCompany(AuthenticatedUserModel.GetUserFromIdentity().Id);
        }

        public void ChangeStatus(string id, EnumMedicineReportStatus status)
        {
            _medicineReportService.ChangeStatus(id, status);
        }

        public IEnumerable<MedicineReport> GetAll()
        {
            return _medicineReportService.GetAll();
        }

        public IEnumerable<MedicineReport> GetAllPending()
        {
            return _medicineReportService.GetAllPending();
        }
    }
}
