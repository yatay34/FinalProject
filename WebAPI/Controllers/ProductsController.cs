using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //ATTIBUTE
    public class ProductsController : ControllerBase
    {
        //loosely coupled --gevşek bağlı
        //naming convention
        //IoC Container-Inversion of Control (değişimin kontrolü)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        ////HttpGet ile çağrılabilir client trfndan 
        //[HttpGet]
        //public List<Product> Get()
        //{
        //    //Dependency chain---bağımlılık zinciri!
        //    IProductService productService = new ProductManager(new EfProductDal()); 
        //    var result = productService.GetAll();
        //    return result.Data; 
        //}
         
        //[HttpGet]
        //public List<Product> Get()
        //{  
        //    var result = _productService.GetAll();
        //    return result.Data; 
        //}

        //Swagger
        [HttpGet("getall")]
        public IActionResult Get()
        {  
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result); //200
            }

            return BadRequest(result); //400
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message); 
        }
    }
}