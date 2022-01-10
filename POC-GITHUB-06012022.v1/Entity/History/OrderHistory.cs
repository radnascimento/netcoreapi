using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity.History
{
    public class OrderHistory
    {

        [Key]
        public long IdOrderHistory { get; set; }
        public long IdOrder { get; set; }
        [Required]
        public long IdCustomer { get; set; }
        [Required]
        public int IdStateOrder { get; set; }
        [Required]
        public int IdTypePayment { get; set; }
        [Required]
        public int IdTypeDelivery { get; set; }
        [Required]
        public long IdAddressDelivery { get; set; }
        public decimal OrderDiscountPrice { get; set; }
        public decimal OrderDeliveryPrice { get; set; }
        [Required]
        public long IdUser { get; set; }
        
        [Required]
        public DateTime DateOperation { get; set; }
        public List<OrderItem> Itens { get; set; }
    }
}
