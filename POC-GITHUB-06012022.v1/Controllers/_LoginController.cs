using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POC_GITHUB_06012022.v1.EntityDTO;
using POC_GITHUB_06012022.v1.Model;
using POC_GITHUB_06012022.v1.Repository;
using POC_GITHUB_06012022.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _LoginController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ILogger<_LoginController> _logger;

        public _LoginController(ICustomerService customerService, IMapper mapper, ILogger<_LoginController> logger)
        {
            _customerService = customerService;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserDto model)
        {
            if (!ModelState.IsValid)           // Invokes the build-in
                return BadRequest(ModelState);


            var customer = await _customerService.Get(model.Username);

            if (customer == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var user = UserRepository.Get(model.Username, model.Password, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
