using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Entities
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [Required(ErrorMessage = "FirstName is Required")]

        public string FirstName { get; set; }
        [PersonalData]
        [Required(ErrorMessage = "LastName is Required")]

        public string LastName { get; set; }
        [PersonalData]

        [Required(ErrorMessage = "Date Of Birth is Required")]
        public DateTime Dob { get; set; }
    }
}
