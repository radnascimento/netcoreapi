using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.EntityDTO
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
                
    }
}
