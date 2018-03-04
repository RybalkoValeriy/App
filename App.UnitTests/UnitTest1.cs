using System;
using System.Linq;
using System.Web.Mvc;
using App.Domain.Abstract;
using App.Domain.Entites;
using App.WebUI.Controllers;
using App.WebUI.HtmlHelpers;
using App.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace App.UnitTests
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrage
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                TotalItem = 38,
                CurrentPage = 2,
                ItemsPrePage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLink(pagingInfo, pageUrlDelegate);
            // Accept
            Assert.AreEqual(result.ToString(),
                @"<li><a href=""Page1"">1</a></li>" +
                @"<li class=""active""><a href=""Page2"">2</a></li>" +
                @"<li><a href=""Page3"">3</a></li>" +
                @"<li><a href=""Page4"">4</a></li>"
                );
        }

        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
            .Returns(
            new Product[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
                new Product { ProductID = 4, Name = "P4" },
                new Product { ProductID = 5, Name = "P5" }
            }.AsQueryable());
            ProductController controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };
            // Act
            ProductView result = (ProductView)controller.List(null, 2).Model;
            // Assert
            Product[] productArray = result.Products.ToArray();
            Assert.IsTrue(productArray.Length == 2);
            Assert.AreEqual(productArray[0].ProductID, 4);
            Assert.AreEqual(productArray[1].ProductID, 5);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                new Product[]
                {
                    new Product{ProductID=1,Name="P1",Category="C1" },
                    new Product{ProductID=2,Name="P2",Category="C2" },
                    new Product{ProductID=3,Name="P3",Category="C3" },
                    new Product{ProductID=4,Name="P4",Category="C1" },
                    new Product{ProductID=5,Name="P5",Category="C2" },
                    new Product{ProductID=6,Name="P6",Category="C3" },
                    new Product{ProductID=7,Name="P7",Category="C1" },
                    new Product{ProductID=8,Name="P8",Category="C2" },
                    new Product{ProductID=9,Name="P9",Category="C2" }
                }.AsQueryable()
                );
            ProductController controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };
            // Act
            Product[] resultControllerProduct = ((ProductView)controller.List("C2", 1).Model)
                .Products
                .ToArray();
            // Assert
            Assert.AreEqual(resultControllerProduct.Length, 3);
            Assert.IsTrue(resultControllerProduct[0].Name == "P2" && resultControllerProduct[0].Category == "C2");
        }
    }
}
