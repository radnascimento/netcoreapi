using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public _LoginController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserDto model)
        {
            if (!ModelState.IsValid)           // Invokes the build-in
                return BadRequest(ModelState);


            var customer = await _customerService.Retrieve(model.Username);

            if (customer == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var user = UserRepository.Get(model.Username, model.Password);

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
