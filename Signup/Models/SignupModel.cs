using System;
using System.ComponentModel.DataAnnotations;

namespace Signup.Models
{
    public class SignupModel
    {
        [Key]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "Phone number cannot be more than 15 characters.")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot be more than 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        [StringLength(50, ErrorMessage = "State cannot be more than 50 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "City cannot be more than 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string Confirmpassword { get; set; }
    }
}
