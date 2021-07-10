using Microsoft.AspNetCore.Identity;
using ProductManagement_Lab_PRN292.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Models
{
    public class UserManageViewModel
    {
        //
        public string Id { get; set; }
        //UserName
        [Required]
        [RegularExpression(@"\w{5,15}", ErrorMessage = "Username is invalid, can only contain letters or digits or underscore. Length(5-15)")]
        [Display(Name = "User Name")]

        public string UserName { get; set; }
        //FirstName
        [Required(ErrorMessage = "FirstName is Required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "FirstName must be between 4 and 20 character in length.")]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        //LastName
        [Required(ErrorMessage = "LastName is Required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "LastName must be between 4 and 20 character in length.")]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        //Email
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //PhoneNumber
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        // Date of Birth
        [PersonalData]
        [Required(ErrorMessage = "Date Of Birth is Required")]
        [MinimumAge(18, ErrorMessage = "User must be 18 years or older")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }
        //Lockout
        public bool Lockout { get; set; }
        //Password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        //Confirm Password
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
