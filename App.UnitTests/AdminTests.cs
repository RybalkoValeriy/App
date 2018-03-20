using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App.Domain.Abstract;
using App.Domain.Entites;
using System.Web.Mvc;
using App.WebUI.Controllers;

namespace App.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_ContainsAll_Products()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product(){ProductID=1,Name="P1", Price=100 },
                    new Product(){ProductID=2,Name="P2", Price=100 },
                    new Product(){ProductID=3,Name="P3", Price=100 }
                }.AsQueryable()
                );
            AdminController adminController = new AdminController(mock.Object);
            // Act
            Product[] result = ((IEnumerable<Product>)adminController.Index().ViewData.Model).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0].ProductID, 1);
            Assert.AreEqual(result[1].ProductID, 2);
            Assert.AreEqual(result[2].ProductID, 3);
        }
    }
}
