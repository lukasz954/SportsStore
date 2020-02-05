using SportsStore.Domain.Repository;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = _productRepository.Products
                .Where(p => p.Category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category ==null ?
                    _productRepository.Products.Count():
                    _productRepository.Products.Where(e=>e.Category==category).Count()
                },
            CurrentCategory = category
            };
            return View(model);
        }
    }
}