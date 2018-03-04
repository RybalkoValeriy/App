using App.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult MenuNav(string category=null)
        {
            ViewBag.SelectCateg = category;
            IEnumerable<string> categories = repository.Products
                .Select(c => c.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}