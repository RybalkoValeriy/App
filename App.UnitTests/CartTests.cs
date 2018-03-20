using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain;
using App.WebUI;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App.Domain.Abstract;
using App.Domain.Entites;
using App.WebUI.Controllers;

namespace App.UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product{ProductID=1,Name="P1", Category="C1" }
                }.AsQueryable()
                );
            Cart cart = new Cart();
            CartController cartController = new CartController(mock.Object, null);
            // Act
            cartController.AddToCart(cart, 1, null);
            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }

        [TestMethod]
        public void Adding_Product_To_cart_Goes_To_Cart_Screen()
        {
            //Arrnage
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product{ProductID=1,Name="P1", Category="C1" }
                }.AsQueryable()
                );
            Cart cart = new Cart();
            CartController cartController = new CartController(mock.Object, null);
            //Act
            RedirectToRouteResult result = cartController.AddToCart(cart, 2, "myUrl");
            //Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        // Метод который гарантирует что мы не сможем сделать заказ с пустой корзиной
        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            // Arrange
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            ShippingDetails shippingDetails = new ShippingDetails();
            CartController controller = new CartController(null, mock.Object);
            // Act
            ViewResult result = controller.Checkout(cart, shippingDetails);
            // Assert
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());

            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        // Ошибка валидации данных при оформлении заказа
        [TestMethod]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            // Arrange
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            cart.AddItem(new Product() { ProductID = 1 }, 1);
            CartController controller = new CartController(null, mock.Object);
            controller.ModelState.AddModelError("error", "error");
            // Act
            ViewResult viewResult = controller.Checkout(cart, new ShippingDetails());
            // Assert
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            Assert.AreEqual("", viewResult.ViewName);
            Assert.AreEqual(false, viewResult.ViewData.ModelState.IsValid);
        }

        // Удачный заказ
        [TestMethod]
        public void Can_Checkout_And_Submit_Order()
        {
            // Arrange
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            cart.AddItem(new Product() { ProductID = 1 }, 1);
            CartController controller = new CartController(null, mock.Object);
            // Act
            ViewResult viewResult = controller.Checkout(cart, new ShippingDetails());
            // Assert
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());
            Assert.AreEqual("Compleated", viewResult.ViewName);
            Assert.AreEqual(true, viewResult.ViewData.ModelState.IsValid);
        }
    }
}
