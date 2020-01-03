using Medicine.Common;
using Medicine.Entities;
using Medicine.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Entities
{
    public class MedicineInfo : Entity
    {
        [Required]
        [Display(Name = "Medicine Name")]
        public string Name { get; set; }
        [Display(Name = "Medicine Type")]
        public string MedicineType { get; set; }
        [Display(Name = "Medicine Size")]
        public string MedicineSize { get; set; }
        public string Details { get; set; }
        [Display(Name = "Medicine Image")]
        public string ImageUrl { get; set; }
        public EnumMedicineStatus Status { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        public int ReportCount { get; set; }
        [Required]
        [Display(Name = "Medicine Company")]
        public string CompanyId { get; set; }
        public virtual User Company { get; set; }
        

        [Display(Name = "Contributor")]
        public string ContributorId { get; set; }
        public virtual User Contributor { get; set; }

    }
}
