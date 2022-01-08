using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity
{
    public class Order
    {

        [Key]
        public long IdOrder { get; set; }
        public long IdCustomer { get; set; }
        public int IdStateOrder { get; set; }
        public int IdTypePayment { get; set; }
        public int IdTypeDelivery { get; set; }
        public long IdAddressDelivery { get; set; }
        public decimal OrderDiscountPrice { get; set; }
        public decimal OrderDeliveryPrice { get; set; }


        public decimal TotalOrderPrice
        {
            get
            {
                return (Itens.Sum(x => x.UnitPrice) + OrderDeliveryPrice) - OrderDiscountPrice;

            }

        }


        public int Id { get; set; }
        public DateTime DateOperation { get; set; }
        public List<OrderItem> Itens { get; set; }

    }
}
