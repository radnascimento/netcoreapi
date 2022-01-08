using Microsoft.AspNetCore.Mvc;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.EntityDTO;
using POC_GITHUB_06012022.v1.Services;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Model;
using POC_GITHUB_06012022.v1.Repository;
using Microsoft.AspNetCore.Authorization;
using POC_GITHUB_06012022.v1.Enum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POC_GITHUB_06012022.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ICustomerAddressService _customerAddressService;

        public CustomerController(ICustomerService customerService,
            IMapper mapper, ICustomerAddressService customerAddressService
            )
        {
            _customerService = customerService;
            _mapper = mapper;
            _customerAddressService = customerAddressService;

        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(JsonConvert.SerializeObject(await _customerService.GetAll()));
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.Retrieve(id);

            if (customer != null)
                return Ok(JsonConvert.SerializeObject(customer));
            else
                return NotFound();
        }


        [HttpPost]
        //[Authorize(Roles = "employee,manager")]
        public async Task<Customer> Post([FromBody] CustomerDto value)
        {

            if (!ModelState.IsValid)           // Invokes the build-in
                return null;


            var customer = await _customerService.Save(_mapper.Map<Customer>(value));

            return customer;
        }


        [HttpPost]
        [Route("IncludeAddress")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> IncludeAddress([FromBody] CustomerAddressDto customerAddress)
        {
            if (!ModelState.IsValid)           // Invokes the build-in
                return BadRequest(ModelState);

            return Ok(await _customerAddressService.Save(_mapper.Map<CustomerAddress>(customerAddress)));
        }


        [HttpGet]
        [Route("GetAddress")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAddress(long idCustomer)
        {
            var address = await _customerAddressService.Retrieve(idCustomer);

            return Ok(address);
        }
      
        [HttpPut("{id}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer =  await _customerService.Retrieve(id);
            
            if (customer == null) return NotFound();

            await _customerService.Delete(customer);

            return Ok();

        }


    }
}
