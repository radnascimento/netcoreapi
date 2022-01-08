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
        public long IdOrder { get; set; }
        public long IdProduct { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int IdStateOrderItem { get; set; }

        public int Id { get; set; }
        public DateTime DateOperation { get; set; }

    }
}
