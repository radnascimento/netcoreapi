using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity
{
    public class User
    {
        [Key]
        public long IdUser { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
