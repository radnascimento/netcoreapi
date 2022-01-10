using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.EntityDTO
{
    public class OrderDto
    {
        public long IdCustomer { get; set; }
        [Required]
        public int IdTypePayment { get; set; }
        [Required]
        public int IdTypeDelivery { get; set; }
        [Required]
        public long IdAddressDelivery { get; set; }
        public decimal OrderDiscountPrice { get; set; }
        [Required]
        public List<OrderItemDto> Itens { get; set; }
        [Required]
        public decimal OrderDeliveryPrice { get; set; }

    }
}
