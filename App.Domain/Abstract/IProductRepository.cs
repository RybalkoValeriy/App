using App.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; set; }
    }
}
