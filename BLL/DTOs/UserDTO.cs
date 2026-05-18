using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is Required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be in between 3 to 50 characters.")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Email Address is required.")]
        [EmailAddress (ErrorMessage ="Invalid Email Address!")]
        public string Email { get; set; }
        [Required (ErrorMessage ="Password is Required")]
        [MinLength(6, ErrorMessage ="Minimum 6 Digit")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Phone Number is Required")]
        [RegularExpression(@"^(013|014|015|016|017|018|019)\d{8}$", ErrorMessage = "Phone number must start with 013 to 019.")]
        [StringLength(11, MinimumLength =11, ErrorMessage ="Phone Number must Be 11 digit")]
        public string Phone { get; set; }
        [Required (ErrorMessage ="Please Select your Blood Group")]
        public int BloodGroupId { get; set; }

        public string BloodGroup { get; set; }
        public string? Role { get; set; }
        public DateOnly? LastDonationDate { get; set; }
        [Required(ErrorMessage ="Date of Birth is required.")]
        public DateOnly Dob { get; set; }
        [Required (ErrorMessage ="Please confirm your password.")]
        [MinLength(6, ErrorMessage = "Minimum 6 Digit")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
