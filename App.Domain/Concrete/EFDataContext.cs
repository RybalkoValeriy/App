using System.Data.Entity;
using App.Domain.Entites;

namespace App.Domain.Concrete
{
    public class EFDataContext : DbContext
    {
        public EFDataContext() : base("EFDataContext")
        {
            Database.SetInitializer<EFDataContext>(new CustomDatabaseIntilize());
        }

        public DbSet<Product> Products { get; set; }
    }
}
