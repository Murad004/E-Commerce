using E_Commerce.Business.Abstract;
using E_Commerce.Entities.Concrete;
using E_Commerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        public IActionResult Index(int page = 1, int category = 0)
        {
            
            int pageSize = 10;
            var products = _productService.GetByCategory(category);
            var vm = new ProductListViewModel()
            {
                Products =products.Skip((page-1)*pageSize).Take(pageSize).ToList() 
            };

            List<Product> SortedList = vm.Products.OrderBy(o => o.UnitPrice).ToList();
            vm.Products = SortedList;

            return View(vm);
        }
    }
}
