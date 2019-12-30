using Medicine.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Entities
{
    public class Company : Entity
    {
        [Required]
        [Display(Name= "Company Name")]
        public string Name { get; set; }
    }
}
