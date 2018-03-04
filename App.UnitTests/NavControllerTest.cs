using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using App.Domain.Abstract;
using App.Domain.Entites;
using App.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace App.UnitTests
{
    [TestClass]
    public class NavControllerTest
    {
        [TestMethod]
        public void Can_Create_Categories()
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
            NavController controller = new NavController(mock.Object);
            // Act
            string[] resultCategories = ((IEnumerable<string>)controller.MenuNav().Model).ToArray();
            // Assert
            Assert.AreEqual(resultCategories.Length, 3);
            Assert.AreEqual(resultCategories[0], "C1");
            Assert.AreEqual(resultCategories[1], "C2");
            Assert.AreEqual(resultCategories[2], "C3");
        }

        [TestMethod]
        public void Indicates_Select_Category()
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
            NavController controller = new NavController(mock.Object);
            string selectCategory = "C2";
            // Act
            var result = controller.MenuNav(selectCategory).ViewBag.SelectCateg;
            // Assert
            Assert.AreEqual(selectCategory, result);
        }

    }
}
