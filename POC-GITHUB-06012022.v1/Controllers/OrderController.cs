using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Model;
using POC_GITHUB_06012022.v1.Services;
using POC_GITHUB_06012022.v1.Validator;
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
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(JsonConvert.SerializeObject(await _orderService.GetAll()));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(JsonConvert.SerializeObject(await _orderService.Get(id)));
        }

        [HttpPost]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Post([FromBody] Order value)
        {
            try
            {
                value.IdUser = IdAuthenticated;
                await _orderService.Save(value);
                
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError("Erro trying to save the new Order", ex.Message);
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Put(int id, [FromBody] Order value)
        {

            value.IdUser = IdAuthenticated;
            
            await _orderService.Update(value);
            
            return Ok();

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.Get(id);
            order.IdUser = IdAuthenticated;
            
            await _orderService.Delete(order);

            return Ok();
        }
    }
}
