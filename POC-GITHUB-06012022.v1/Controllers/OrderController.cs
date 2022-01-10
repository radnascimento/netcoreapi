using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.EntityDTO;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Infrastructure;
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
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IMapper mapper)
        {
            _orderService = orderService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(JsonConvert.SerializeObject(await _orderService.GetAll()));
        }

        [HttpGet("{id},{history}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get(long id, bool history = false)
        {
            if (!history)
            {
                return Ok(JsonConvert.SerializeObject(await _orderService.Get(id)));
            }
            else if (history)
            {
                return Ok(JsonConvert.SerializeObject(await _orderService.GetHistory(id)));
            }
            else return NotFound();

        }

        [HttpPost]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Post([FromBody] OrderDto value)
        {
            try
            {
                var order = _mapper.Map<Order>(value);

                order.IdUser = IdAuthenticated;
                await _orderService.Save(order);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro trying to save the new Order", ex.Message);
                return StatusCode(500, "Internal server error");
            }

        }


        
        [HttpPut("{id},{idstateorder}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderDto value, int idstateorder)
        {
            if (idstateorder < 1 ) return BadRequest("Parameter idstateorder is required. For more information check EnumStateOrder");

            //todo validade idstateorder

            var order = _mapper.Map<Order>(value);

            order.IdUser = IdAuthenticated;

            await _orderService.Update(order, idstateorder);

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
