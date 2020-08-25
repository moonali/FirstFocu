using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using TestProjectForFirstfocus.Models;
using TestProjectForFirstfocus.ProductRepository;
using TestProjectForFirstfocus.ViewModel;

namespace TestProjectForFirstfocus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(string searchString)
        {
            var productRepository = new ProductRepository.ProductRepository();
            if (!string.IsNullOrEmpty(searchString))
            {
                return View(productRepository.SearchProducts(searchString));
            }
            return View(productRepository.GetProducts());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var productRepository = new ProductRepository.ProductRepository();
            return View(productRepository.GetProductsDetail(id));
        }    
    }
}
