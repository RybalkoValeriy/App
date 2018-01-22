using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entites;

namespace App.Domain.Concrete
{
    public class EFDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
