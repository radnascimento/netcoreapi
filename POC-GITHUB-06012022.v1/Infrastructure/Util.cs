using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Enum.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Infrastructure
{

    public class UtilEnum
    {
        public int id { get; set; }
        public string Description { get; set; }
    }

    public static class Util
    {
        public static string GetEnumTypePayment()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumTypePayment.GetValues(typeof(EnumTypePayment)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();
        }


        public static string GetEnumTypeDelivery()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumTypeDelivery.GetValues(typeof(EnumTypeDelivery)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();

        }
    

        public static string GetEnumCustomerAddress()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumCustomerAddress.GetValues(typeof(EnumCustomerAddress)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();

        }

        public static string GetEnumStateCustomer()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumStateCustomer.GetValues(typeof(EnumStateCustomer)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();
        }

        public static string GetEnumStateOrder()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumStateOrder.GetValues(typeof(EnumStateOrder)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();
        }

        public static string GetEnumStateProduct()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumStateProduct.GetValues(typeof(EnumStateProduct)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();

        }

        public static string GetEnumStateOrderItem()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumStateOrderItem.GetValues(typeof(EnumStateOrderItem)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();

        }
        

    }


}
