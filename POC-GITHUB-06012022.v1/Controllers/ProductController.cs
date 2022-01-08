using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.EntityDTO;
using POC_GITHUB_06012022.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POC_GITHUB_06012022.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(JsonConvert.SerializeObject(await _productService.GetAll()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(JsonConvert.SerializeObject(await _productService.Get(id)));
        }

        //public ProductController(Iprodu)
        //{ 
        //}



        //[HttpGet]
        //[Route("GetAll")]
        ////[Authorize(Roles = "employee,manager")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(JsonConvert.SerializeObject(await _orderService.GetAll()));
        //}

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
      
        [HttpPost]
        public async Task Post([FromBody] ProductDto product)
        {
            await _productService.Save(_mapper.Map<Product>(product));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
