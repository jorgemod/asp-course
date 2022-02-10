using ContosoCraft.models;
using ContosoCraft.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCraft.controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;

        }
        public JsonFileProductService ProductService { get;  }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        //[Route("Rate")]
        //[HttpGet]
        //public ActionResult Get([FromQuery] string ProductId,[FromQuery] int Rating)
        //{
         //   ProductService.AddRating(ProductId, Rating);
          //  return Ok();
        //}

        [Route("Rate")]
        [HttpPost]
        public ActionResult Post([FromForm] string ProductId, [FromForm] string Rating)
        {

            
            try
            {
                var rate = Convert.ToInt32(Rating);
                ProductService.AddRating(ProductId, rate);
                return Ok("Rate inserted");
            }
            catch (Exception)
            {
                return BadRequest("Rating most be a int");
                throw;
            }
            
            
            
        }
        
    }
}
