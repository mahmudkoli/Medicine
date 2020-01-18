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
    public class ReportFeedback : Entity
    {

        [Required]
        [Display(Name = "Report")]
        public string MedicineReportId { get; set; }
        public virtual MedicineReport MedicineReport { get; set; }
        public string FeedbackMessage { get; set; }
    }
}
