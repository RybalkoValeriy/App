using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Domain.Abstract;
using App.Domain.Entites;


namespace App.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 2;
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Product
        public ViewResult List(int page = 1)
        {
            var model =
                repository.Products.OrderBy(x => x.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
            return View(model);
        }
    }
}