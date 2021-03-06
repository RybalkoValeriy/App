﻿using System;
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
        public int PageSize = 3;
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            ProductView model = new ProductView
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(x => x.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    // Текущая страница
                    CurrentPage = page,
                    // кол-во товаров на страницу
                    ItemsPrePage = PageSize,
                    // всего товаров
                    TotalItem = category == null ? 
                    repository.Products.Count(): 
                    repository.Products.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            };
            var m = model.PagingInfo.TotalPage;
            return View(model);
        }
    }
}