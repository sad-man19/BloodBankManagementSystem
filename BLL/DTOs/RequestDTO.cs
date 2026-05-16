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
        [Required]
        public int BloodGroupId { get; set; }
        [Required]
        [Range(1, 15, ErrorMessage = "Quantity must be in between 1 to 15.")]
        public int Quantity { get; set; }
        [Required]
        public DateOnly ReqDate { get; set; }
        public string Status { get; set; }
    }
}
