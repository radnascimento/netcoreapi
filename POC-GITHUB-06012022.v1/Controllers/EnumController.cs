using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace POC_GITHUB_06012022.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {

        [HttpGet]
        [Route("GetEnumCustomerAddress")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetEnumCustomerAddress()
        {
            return Ok(Util.GetEnumCustomerAddress());
        }

        [HttpGet]
        [Route("GetEnumStateProduct")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetEnumStateProduct()
        {
            return Ok(Util.GetEnumStateProduct());
        }

        [HttpGet]
        [Route("GetEnumStateCustomer")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetEnumStateCustomer()
        {
            return Ok(Util.GetEnumStateCustomer());
        }

        [HttpGet]
        [Route("GetEnumStateOrder")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetEnumStateOrder()
        {
            return Ok(Util.GetEnumStateOrder());
        }

        [HttpGet]
        [Route("GetEnumStateOrderItem")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetEnumStateOrderItem()
        {
            return Ok(Util.GetEnumStateOrderItem());
        }

        [HttpGet]
        [Route("GetEnumTypeDelivery")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetEnumTypeDelivery()
        {
            return Ok(Util.GetEnumTypeDelivery());
        }

        [HttpGet]
        [Route("GetEnumTypePayment")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetEnumTypePayment()
        {
            return Ok(Util.GetEnumTypePayment());
        }
    }
}
