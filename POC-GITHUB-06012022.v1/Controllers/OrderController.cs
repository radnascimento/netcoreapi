using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Model;
using POC_GITHUB_06012022.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POC_GITHUB_06012022.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : MyControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(JsonConvert.SerializeObject(await _orderService.GetAll()));
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(JsonConvert.SerializeObject(await _orderService.Get(id)));
        }

        [HttpPost]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Post([FromBody] Order value)
        {
            try
            {
                value.IdUser = IdAuthenticated;

                await _orderService.Save(value);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "employee,manager")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "employee,manager")]
        public void Delete(int id)
        {
        }
    }
}
