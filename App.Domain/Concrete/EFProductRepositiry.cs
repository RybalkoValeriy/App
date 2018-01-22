using App.Domain.Abstract;
using App.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Concrete
{
    public class EFProductRepositiry : IProductRepository
    {
        private EFDataContext context = new EFDataContext();

        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }

            set
            {
            }
        }

    }
}
