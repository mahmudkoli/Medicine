using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Models.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "District")]
        public string District { get; set; }
        [Display(Name = "Weight")]
        public float? Weight { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string RoleName { get; set; }

    }
}
