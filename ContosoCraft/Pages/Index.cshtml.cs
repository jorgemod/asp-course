using ContosoCraft.models;
using ContosoCraft.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCraft.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //importamos nuestro servicio
        public JsonFileProductService ProductService;
        //importamos nuestro model
        public IEnumerable<Product> Products { get; private set; }
        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;

        }

        //este es un metodo http get
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
