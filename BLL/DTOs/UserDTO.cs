using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [StringLength(11, MinimumLength =11)]
        public string Phone { get; set; }
        [Required]
        public int BloodGroupId { get; set; }
        public string Role { get; set; }
        public DateOnly? LastDonationDate { get; set; }
        [Required]
        public DateOnly Dob { get; set; }
    }
}
