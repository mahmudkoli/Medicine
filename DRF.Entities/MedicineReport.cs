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
    public class MedicineReport : Entity
    {
        [Required]
        [Display(Name = "Complainant")]
        public string ComplainantId { get; set; }
        public virtual User Complainant { get; set; }
        [Required]
        [Display(Name = "Pharmacy")]
        public string PharmacyId { get; set; }
        public virtual User Pharmacy { get; set; }
        [Required]
        [Display(Name = "Medicine")]
        public string MedicineInfoId { get; set; }
        public virtual MedicineInfo MedicineInfo { get; set; }
        public decimal AskingPrice { get; set; }
        public string Comment { get; set; }
        public EnumMedicineReportStatus Status { get; set; }
        public string DocumentUrl { get; set; }
    }
}
