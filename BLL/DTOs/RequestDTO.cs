using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class RequestDTO
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please Select Blood group")]
        public int BloodGroupId { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Quantity must be in between 1 to 10.")]
        public int Quantity { get; set; }
        [Required]
        public DateOnly ReqDate { get; set; }
        public string Status { get; set; }

        //only for display purpose
        public string? UserName { get; set; }
        public string? BloodGroup { get; set; }
    }
}
