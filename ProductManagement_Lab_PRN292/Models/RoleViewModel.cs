using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Role Name must be between 4 and 15 character in length.")]
        public string RoleName { get; set; }
    }
}
