using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Enum;
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
        public static string GetEnumCustomerAddress()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumCustomerAddress.GetValues(typeof(EnumCustomerAddress)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString()});
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();

        }
        
        public static string GetEnumStateCustomer()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumCustomerAddress.GetValues(typeof(EnumStateCustomer)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();
        }

        public static string GetEnumStateOrder()
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumCustomerAddress.GetValues(typeof(EnumStateOrder)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();
        }

        public static string GetEnumStateProduct() 
        {
            List<UtilEnum> utilEnums = new List<UtilEnum>();

            foreach (var item in EnumCustomerAddress.GetValues(typeof(EnumStateProduct)))
            {
                utilEnums.Add(new UtilEnum { id = (int)item, Description = item.ToString() });
            }

            return JsonConvert.SerializeObject(utilEnums).ToString();

        }

    }


}
