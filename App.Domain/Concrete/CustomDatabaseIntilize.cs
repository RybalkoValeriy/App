using System.Collections.Generic;
using System.Data.Entity;
using App.Domain.Entites;

namespace App.Domain.Concrete
{
    public class CustomDatabaseIntilize : CreateDatabaseIfNotExists<EFDataContext>
    {
        protected override void Seed(EFDataContext context)
        {
            var propducts = new List<Product>
            {
                new Product
                {
                    ProductID=1,
                    Name="Product1",
                    Descr="Descr",
                    Price=800,
                    Category="Categ1"
                },
                new Product
                {
                    ProductID=2,
                    Name="Product2",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=3,
                    Name="Product3",
                    Descr="Descr",
                    Price=800,
                    Category="Categ3"
                },
                new Product
                {
                    ProductID=4,
                    Name="Product4",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=5,
                    Name="Product5",
                    Descr="Descr",
                    Price=800,
                    Category="Categ3"
                },
                new Product
                {
                    ProductID=6,
                    Name="Product6",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=7,
                    Name="Product7",
                    Descr="Descr",
                    Price=800,
                    Category="Categ1"
                },
                new Product
                {
                    ProductID=8,
                    Name="Product8",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=9,
                    Name="Product9",
                    Descr="Descr",
                    Price=800,
                    Category="Categ3"
                },
                new Product
                {
                    ProductID=10,
                    Name="Product10",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=11,
                    Name="Product11",
                    Descr="Descr",
                    Price=800,
                    Category="Categ1"
                },
                new Product
                {
                    ProductID=12,
                    Name="Product12",
                    Descr="Descr",
                    Price=800,
                    Category="Categ3"
                },
                new Product
                {
                    ProductID=13,
                    Name="Product13",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=14,
                    Name="Product14",
                    Descr="Descr",
                    Price=800,
                    Category="Categ3"
                },
                new Product
                {
                    ProductID=15,
                    Name="Product15",
                    Descr="Descr",
                    Price=800,
                    Category="Categ4"
                },
                new Product
                {
                    ProductID=16,
                    Name="Product16",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=17,
                    Name="Product17",
                    Descr="Descr",
                    Price=800,
                    Category="Categ3"
                },
                new Product
                {
                    ProductID=18,
                    Name="Product18",
                    Descr="Descr",
                    Price=800,
                    Category="Categ2"
                },
                new Product
                {
                    ProductID=19,
                    Name="Product19",
                    Descr="Descr",
                    Price=800,
                    Category="Categ1"
                },
                new Product
                {
                    ProductID=20,
                    Name="Product20",
                    Descr="Descr",
                    Price=800,
                    Category="Categ1"
                },
                new Product
                {
                    ProductID=21,
                    Name="Product21",
                    Descr="Descr",
                    Price=800,
                    Category="Categ4"
                }
            };
            context.Products.AddRange(propducts);
            context.SaveChanges();
        }
    }
}
