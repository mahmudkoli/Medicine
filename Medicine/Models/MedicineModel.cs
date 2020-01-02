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
    public class MedicineModel : MedicineInfo
    {
        private MedicineService _medicineService;
        private CompanyService _companyService;


        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFileBase { get; set; }

        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<string> MedicineTypes { get; set; }
        public IEnumerable<string> MedicineSizes { get; set; }

        public MedicineModel()
        {
            _medicineService = new MedicineService();
            _companyService = new CompanyService();
        }

        public MedicineModel(string id) : this()
        {
            var existingEntity = _medicineService.GetById(id);
            if (existingEntity != null)
            {
                this.Id = existingEntity.Id;
                this.Name = existingEntity.Name;
                this.MedicineType = existingEntity.MedicineType;
                this.MedicineSize = existingEntity.MedicineSize;
                this.TotalPrice = existingEntity.TotalPrice;
                this.UnitPrice = existingEntity.UnitPrice;
                this.Details = existingEntity.Details;
                this.ContributorId = existingEntity.ContributorId;
                this.Contributor = existingEntity.Contributor;
                this.CompanyId = existingEntity.CompanyId;
                this.Company = existingEntity.Company;
                this.ImageUrl = existingEntity.ImageUrl;
                this.Status = existingEntity.Status;
                this.CreatedAt = existingEntity.CreatedAt;
                this.UpdatedAt = existingEntity.UpdatedAt;
            }
        }

        public string Add()
        {
            this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase, this.Name, this.Id, "Medicine");
            this.ContributorId = AuthenticatedUserModel.GetUserFromIdentity().Id;
            return _medicineService.AddByAdmin(this);
        }

        public string Update()
        {
            this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase, this.Name, this.Id, "Medicine");
            return _medicineService.Update(this);
        }

        public IEnumerable<MedicineInfo> GetAll()
        {
            return _medicineService.GetAll();
        }

        public IEnumerable<MedicineInfo> GetAllPending()
        {
            return _medicineService.GetAllPending();
        }

        public void LoadAllListData()
        {
            this.Companies = _companyService.GetAll();
            this.MedicineTypes = DefaultValue.MedicineTypes;
            this.MedicineSizes = DefaultValue.MedicineSizes;

        }
    }
}
