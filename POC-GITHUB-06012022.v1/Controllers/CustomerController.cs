using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
using POC_GITHUB_06012022.v1.EntityDTO;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Model;
using POC_GITHUB_06012022.v1.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POC_GITHUB_06012022.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : MyControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ICustomerAddressService _customerAddressService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService,
            IMapper mapper, ICustomerAddressService customerAddressService,
            ILogger<CustomerController> logger
            )
        {
            _customerService = customerService;
            _mapper = mapper;
            _customerAddressService = customerAddressService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(JsonConvert.SerializeObject(await _customerService.GetAll()));
        }

        [HttpGet("{id},{history}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get(int id, bool history = false)
        {
            if (!history)
            {
                return Ok(JsonConvert.SerializeObject(await _customerService.Get(id)));
            }
            else if (history)
            {
                return Ok(JsonConvert.SerializeObject(await _customerService.GetHistory(id)));
            }
            else return NotFound();

        }

        [HttpPost]
        public async Task<Customer> Post([FromBody] CustomerDto value)
        {
            if (!ModelState.IsValid) return null;

            var customer = _mapper.Map<Customer>(value);
            customer.IdUser = 0;
            customer = await _customerService.Save(customer);

            return customer;
        }


        [HttpPost]
        [Route("IncludeAddress")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> IncludeAddress([FromBody] CustomerAddressDto customerAddress)
        {
            if (!ModelState.IsValid)           // Invokes the build-in
                return BadRequest(ModelState);


            var customeraddress = _mapper.Map<CustomerAddress>(customerAddress);
            customeraddress.IdUser = IdAuthenticated;

            return Ok(await _customerAddressService.Save(customeraddress));
        }

        [HttpPut("{id},{idstatecustomer}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Put(long id, [FromBody] CustomerDto value, int idstatecustomer)
        {
            if (idstatecustomer < 1) return BadRequest("Parameter idstatecustomer is required. For more information check EnumStateCustomer");


            var customer = _mapper.Map<Customer>(value);
            customer.IdCustomer = id;
            customer.IdUser = IdAuthenticated;
            customer.IdStateCustomer = idstatecustomer;
            
            await _customerService.Update(customer, idstatecustomer);

            return Ok();
        }


        [HttpDelete("{id}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.Get(id);

            if (customer == null) return NotFound();

            customer.IdUser = IdAuthenticated;

            await _customerService.Delete(customer);

            return Ok();

        }
    }
}
