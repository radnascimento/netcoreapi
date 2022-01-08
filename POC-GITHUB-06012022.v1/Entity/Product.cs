using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity
{
    public class Product
    {
        [Key]
        public long IdProduct { get; set; }

        public string NameProduct { get; set; }

        public int IdStateProduct { get; set; }

        [Required]
        public DateTime DateOperation { get; set; }

    }
}
