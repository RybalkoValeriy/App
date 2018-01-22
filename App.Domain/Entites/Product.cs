using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entites
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
