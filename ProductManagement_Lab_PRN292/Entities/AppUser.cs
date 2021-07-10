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
        //FirstName
        [PersonalData]
        [Required(ErrorMessage = "FirstName is Required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "FirstName must be between 4 and 20 character in length.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        //LastName
        [PersonalData]
        [Required(ErrorMessage = "LastName is Required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "LastName must be between 4 and 20 character in length.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //Dob
        [PersonalData]
        [Required(ErrorMessage = "Date Of Birth is Required")]
        [MinimumAge(18, ErrorMessage = "User must be 18 years or older")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }
    }
}
