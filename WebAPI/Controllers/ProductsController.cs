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

        //HttpGet ile çağrılabilir client trfndan 
        [HttpGet]
        public List<Product> Get()
        {
            ////Dependency chain---bağımlılık zinciri!
            //IProductService productService = new ProductManager(new EfProductDal());

            var result = _productService.GetAll();
            return result.Data;

        }



    }
}