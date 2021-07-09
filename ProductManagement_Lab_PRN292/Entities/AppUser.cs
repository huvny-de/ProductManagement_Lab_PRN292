using Microsoft.AspNetCore.Identity;
using ProductManagement_Lab_PRN292.Validations;
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
        [StringLength(20, MinimumLength = 4, ErrorMessage = "FirstName must be between 4 and 20 character in length.")]

        public string FirstName { get; set; }
        [PersonalData]
        [Required(ErrorMessage = "LastName is Required")]

        [StringLength(20, MinimumLength = 4, ErrorMessage = "LastName must be between 4 and 20 character in length.")]
        public string LastName { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Date Of Birth is Required")]
        [MinimumAge(18, ErrorMessage = "User must be 18 years or older")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
    }
}
