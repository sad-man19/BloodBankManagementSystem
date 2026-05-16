using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class BloodGroupInventoryDTO
    {
        public int Id { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        public int Inventory { get; set; }
    }
}
