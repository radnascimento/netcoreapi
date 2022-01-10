using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.EntityDTO;
using POC_GITHUB_06012022.v1.Model;
using POC_GITHUB_06012022.v1.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POC_GITHUB_06012022.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : MyControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, IMapper mapper, ILogger<ProductController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;

        }

    [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(JsonConvert.SerializeObject(await _productService.GetAll()));
        }

        [HttpGet("{id},{history}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get(int id, bool history = false)
        {
            if (!history)
            {
                return Ok(JsonConvert.SerializeObject(await _productService.Get(id)));
            }
            else if (history)
            {
                return Ok(JsonConvert.SerializeObject(await _productService.GetHistory(id)));
            }
            else return NotFound();

        }


        [HttpPost]
        [Authorize(Roles = "employee,manager")]
        public async Task<Product> Post([FromBody] ProductDto value)
        {

            if (!ModelState.IsValid) return null;
            
            var product = _mapper.Map<Product>(value);
            
            product.IdUser = IdAuthenticated;
            
            product = await _productService.Save(product);

            return product;
        }



        [HttpPut("{id},{idstateproduct}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Put(long id, [FromBody] ProductDto value, int idstateproduct)
        {
            var product = _mapper.Map<Product>(value);
            product.IdProduct = id;
            product.IdUser = IdAuthenticated;

            await _productService.Update(product, idstateproduct);

            return Ok();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _productService.Get(id);

            if (customer == null) return NotFound();

            customer.IdUser = IdAuthenticated;

            await _productService.Delete(customer);

            return Ok();

        }

    }
}
