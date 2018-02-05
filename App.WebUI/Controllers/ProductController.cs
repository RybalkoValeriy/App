using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Domain.Abstract;
using App.Domain.Entites;
using App.WebUI.Infrastructure;
using App.WebUI.Models;

namespace App.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 5;
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Product
        public ViewResult List(int page = 1)
        {
            ProductView model = new ProductView
            {
                Products = repository.Products.OrderBy(x => x.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPrePage = PageSize,
                    TotalItem = repository.Products.Count()
                }
            };
            return View(model);
        }
    }
}