using App.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.WebUI.Models
{
    public class ProductView
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}