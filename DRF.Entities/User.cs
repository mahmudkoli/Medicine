using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Entities.Base;

namespace Medicine.Entities
{
    public class User : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }
        [Required]
        public string UserRole { get; set; }
        public string ImageUrl { get; set; }
    }
}
