using POC_GITHUB_06012022.v1.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity
{
    public class OrderItem
    {
        [Key]
        public long IdOrderItem { get; set; }
        [Required]
        public long IdOrder { get; set; }
        [Required]
        public long IdProduct { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int IdStateOrderItem { get; set; }
        [Required]
        public long IdUser { get; set; }
        [Required]
        public DateTime DateOperation { get; set; }

    }
}
