using SportsStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository _productRepository;
        public NavController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = _productRepository.Products
                                             .Select(v => v.Category)
                                             .Distinct()
                                             .OrderBy(v=>v);
            return PartialView(categories);
        }
    }
}